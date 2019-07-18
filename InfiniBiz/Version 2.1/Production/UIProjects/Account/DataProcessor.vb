#Region "Libraries"
Imports System.Xml
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL
#End Region

Public Class DataProcessor

#Region "Instance Variable"
    Private oCmd As CommandData
    Private colEnableWeb As New System.Collections.Specialized.NameValueCollection
    Private colEnableDesktop As New System.Collections.Specialized.NameValueCollection
    Private Path As String
#End Region
    
#Region "Constructor"
    Public Sub New(ByVal UniquePath As String)
        oCmd = New CommandData
        Path = UniquePath
    End Sub
#End Region
    
#Region "Public Function"

    
    Public Function MapCustomerSelectedService(ByVal CustomerID As Integer _
                                            , ByVal ProductCode As String _
                                            , ByVal OrderNo As Integer) As Boolean

        Dim dsCustomers As DataSet
        Dim dsServiceInfo As New DataSet
        Dim strExpiryDate As String = GetExpiryDate(OrderNo)
        Dim intServiceID As Integer
        Dim strServiceName As String
        Dim strServiceOption As String

        Dim strLogin As String

        WriteDebugInfo("SelectCustomers Calling")
        dsCustomers = SelectCustomers(CustomerID)   'select * from customer
        WriteDebugInfo("SelectCustomers is ok")

        strLogin = dsCustomers.Tables(0).Rows(0).Item("cart_customer_uid")

        WriteDebugInfo("Serviceinfo Calling")
        dsServiceInfo = Serviceinfo(ProductCode)
        WriteDebugInfo("Serviceinfo is ok")

        Dim i As Integer
        For i = 0 To dsServiceInfo.Tables(0).Rows.Count - 1
            intServiceID = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceID")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceID"))   'ds.Tables(0).Rows(i).Item("ServiceID")
            strServiceName = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceName")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceName"))
            strServiceOption = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("Status")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("status"))
            If (strServiceOption And ACC_ServiceOptions.DesktopApplication) = ACC_ServiceOptions.DesktopApplication Then
                colEnableDesktop.Add(intServiceID, strServiceName)
            Else
                colEnableWeb.Add(intServiceID, strServiceName)
            End If
            WriteDebugInfo("ManageAccountsCentreServices Calling")
            ManageAccountsCentreServices(intServiceID, CustomerID, strLogin, "Enable", strExpiryDate)
            WriteDebugInfo("ManageAccountsCentreServices is ok")
        Next

        Return True
    End Function

   
    Public Function CreateSubCustomer(ByVal CustomerID As Integer, ByVal ParentPassword As String) As Integer
        'Get Gkey and encrypted password
        Dim strGKeyLen As Integer = 1024
        Dim strGKey, strPassword, strEncryptPassword As String
        Dim objCryptography As New Cryptography
        'strPassword = GetPassword()
        strPassword = ParentPassword
        strGKey = objCryptography.KeyGen(strGKeyLen)
        strEncryptPassword = objCryptography.EnCrypt(strPassword, strGKey)

        'Get Random value as a prefix of Customer ID, to make Customer Login ID
        Dim intRndNo As Integer
        intRndNo = GetRandomValue()

        Dim NewCustomerID As Integer
        WriteDebugInfo("CreateCustomerFromAnother Calling with following parameter:")
        NewCustomerID = CreateCustomerFromAnother(CustomerID, intRndNo, strEncryptPassword, strGKey)
        WriteDebugInfo("CreateCustomerFromAnother with NewCustomerID=" & NewCustomerID)

        Return NewCustomerID
    End Function

#End Region

#Region "Private Function"
    
    Private Function GetExpiryDate(ByVal OrderID As Integer) As DateTime
        Dim rdr As SqlDataReader
        Dim ExpiryDate As DateTime
        Try
            Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            sqlParam(0) = New SqlClient.SqlParameter("@OrderID", SqlDbType.BigInt)
            sqlParam(0).Value = OrderID
            WriteDebugInfo("Executing RSS_GetOrderExpiryDate")
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.RSS_GetOrderExpiryDate", sqlParam)
            If rdr.Read() Then
                ExpiryDate = IIf(IsDBNull(rdr("ExpiryDate")), "", rdr("ExpiryDate"))
            End If
            WriteDebugInfo("RSS_GetOrderExpiryDate is ok and ExpiryDate=" & ExpiryDate.ToLongDateString())
            sqlParam = Nothing
        Catch ex As Exception
            WriteDebugInfo("EXCEPTION::")
            WriteDebugInfo("Input Parameter:")
            WriteDebugInfo("    OrderID=" & OrderID)
            WriteDebugInfo("Message::" & ex.Message)
            WriteDebugInfo("Source::" & ex.Source)
            Throw ex
        Finally
            If Not rdr Is Nothing AndAlso rdr.IsClosed Then rdr.Close()
        End Try

        Return ExpiryDate
    End Function

    
    Private Function ManageAccountsCentreServices(ByVal serviceID As Integer _
                                                , ByVal customerID As Integer _
                                                , ByVal customerUID As String _
                                                , ByVal serviceStatus As String _
                                                , ByVal hdate As DateTime) As Boolean

        Dim cmdData As New CommandData
        Dim returnVal As Int16
        With cmdData

            Try
                .AddParameter("@ServiceID", serviceID)
                .AddParameter("@CustomerID", customerID)
                .AddParameter("@Status", serviceStatus)
                .AddParameter("@hdate", hdate)
                .AddParameter("@ReturnVal", 0, SqlDbType.Int, 0, ParameterDirection.Output)

                .CmdText = "DBSERVER.InfinishopMainDB.DBO.ADMIN_SetCustomerSelectedServices"
                WriteDebugInfo("Executing ADMIN_SetCustomerSelectedServices")
                WriteDebugInfo("Parameters:")
                WriteDebugInfo("    serviceID=" & serviceID)
                WriteDebugInfo("    customerID=" & customerID)
                WriteDebugInfo("    serviceStatus=" & serviceStatus)
                WriteDebugInfo("    hdate=" & hdate)

                .Execute(ExecutionType.ExecuteNonQuery)
                WriteDebugInfo("done!")

                returnVal = .Item("@ReturnVal")
            Finally
                .CloseConnection()
            End Try
        End With

        If returnVal = 1 Then
            Dim objSM As InfiniLogic.AccountsCentre.BLL.ServicesManager
            Dim strDatabaseName As String = InfiniLogic.AccountsCentre.BLL.ServicesManager.GetDatabaseName(Val(customerID))

            If (strDatabaseName = String.Empty) Then
                objSM = New InfiniLogic.AccountsCentre.BLL.ServicesManager(Val(customerID))
            Else
                WriteDebugInfo("DataBaseName = " & strDatabaseName.ToString())
                objSM = New InfiniLogic.AccountsCentre.BLL.ServicesManager(Val(customerID), strDatabaseName)
            End If


            WriteDebugInfo("ProcessServices Calling")
            objSM.ProcessServices()
            WriteDebugInfo("ProcessServices is ok")

            objSM = Nothing

            If (serviceID = 5 Or serviceID = 14) And serviceStatus = "Enable" Then
                Dim CamService As New Administration.BLL.ActivateService

                WriteDebugInfo("ActivateService Calling")
                CamService.ActivateService(customerID + 0, customerUID, serviceID + 0)
                WriteDebugInfo("ActivateService is ok")
                CamService = Nothing
            End If

            Return True
        Else
            Return False

        End If

    End Function

    Private Function SelectCustomers(ByVal intCustomerID As String) As DataSet
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        sqlParam(0) = New SqlClient.SqlParameter("@intCustomerID", SqlDbType.VarChar, 10)
        sqlParam(0).Value = intCustomerID
        WriteDebugInfo("ADMIN_SelectCustomers Calling")
        Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.ADMIN_SelectCustomers", sqlParam)
        WriteDebugInfo("ADMIN_SelectCustomers is ok")
        Return ds
    End Function

    Private Function Serviceinfo(ByVal PackageCode As String) As DataSet
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParam(0) = New SqlClient.SqlParameter("@PackageCode", SqlDbType.VarChar, 10)
        sqlParam(0).Value = PackageCode

        WriteDebugInfo("Admin_serviceInfo Calling")
        Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.Admin_serviceInfo", sqlParam)
        WriteDebugInfo("Admin_serviceInfo is ok")

        Return ds
    End Function

    Private Function GetPassword() As String
        Dim sPwd As String
        Randomize() : sPwd = CInt(Int(90 * Rnd()) + 10)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & CInt(Int(90 * Rnd()) + 10)
        Return sPwd
    End Function

    Private Function GetRandomValue() As Integer
        Randomize()
        Return Int(Rnd() * 99) + 1
    End Function

    
    Private Function CreateCustomerFromAnother(ByVal SourceCustomerID As Integer _
                                            , ByVal RandomValue As Integer _
                                            , ByVal Cart_Customer_Pass As String _
                                            , ByVal GKey As String) As Integer
        oCmd.AddParameter("@SourceCustomerID", SourceCustomerID)
        oCmd.AddParameter("@RandomValue", RandomValue)
        oCmd.AddParameter("@Cart_Customer_Pass", Cart_Customer_Pass)
        oCmd.AddParameter("@GKey", GKey)
        oCmd.AddParameter("@NewCustomerID", 0, ParameterDirection.Output)

        WriteDebugInfo("Executing RSS_CreateRS_ACCustomer SP")
        oCmd.CmdText = "DBServer.InfinishopMainDB.dbo.RSS_CreateRS_ACCustomer"
        oCmd.Execute(ExecutionType.ExecuteNonQuery)
        WriteDebugInfo("RSS_CreateRS_ACCustomer is ok")

        'Get New Customer ID
        Dim NewCustomerID As Integer
        NewCustomerID = oCmd.Item("@NewCustomerID")

        oCmd.ClearParameters()

        'Pass back the new customer id
        Return NewCustomerID
    End Function

    Private Sub WriteDebugInfo(ByVal sText As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            If Not System.IO.Directory.Exists(Path) Then
                System.IO.Directory.CreateDirectory(Path)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(Path & "\DataProcessor.vb.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub

#End Region

End Class
