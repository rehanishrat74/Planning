Imports DTS
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Data
Imports System.Collections
Imports System.IO
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.Common
Public Class ServicesManager

#Region "   Instance Variables ........... "


    Private _strConnectionString As String
    Private _intCustomerID As Int32
    Private _strDatabaseName As String = ""
    Private _strServerName As String = ""

#End Region

#Region "  Constructors .............."

    Public Sub New(ByVal customerId As Int32)
        _intCustomerID = customerId
        _strDatabaseName = CreateDatabase(_intCustomerID)
        _strServerName = GetServerName(_intCustomerID)
    End Sub

    Public Sub New(ByVal customerId As Int32, ByVal dbName As String)
        _intCustomerID = customerId
        _strDatabaseName = dbName
        _strServerName = GetServerName(customerId)
    End Sub

#End Region

#Region "   Public  Methods .............."

    Public Function ProcessServices() As Boolean

        InsertLog("Calling GetServiceNames")
        Dim servicesAllowed As Hashtable = GetServiceNames()
        InsertLog("Successfully called GetServiceNames. Total Services Allowed is " & servicesAllowed.Count)

        Dim tmpItem As Object
        Dim ServiceName As String
        Dim managerName As String
        Dim intCount As Integer = 0

        InsertLog("Getting SQLAdminID")
        Dim strAdminUID As String = ConfigReader.GetItem(ConfigVariables.SQLAdminID)
        InsertLog("Gettng SQLAdminPassword")
        Dim strAdminPassword As String = ConfigReader.GetItem(ConfigVariables.SQLAdminPassword)

        InsertLog("Enter into loop for each service.")
        For Each tmpItem In servicesAllowed.Keys

            InsertLog(intCount.ToString & vbTab & "Getting service name from servicesAllowed.")
            ServiceName = Trim(CType(servicesAllowed(tmpItem), String))
            InsertLog("Sercvice Name : " & ServiceName)

            Try
                '*********************************************************************************
                'Added by Afaq Ali on jan 6, 2006
                'Modified by M.Yousuf on May 24, 2007
                '*********************************************************************************
                InsertLog("Checking Conditions....")
                If CInt(tmpItem) = 1 AndAlso CheckServiceForCustomer(_intCustomerID, 10) Then
                    InsertLog("Calling UpgradeService for tmpItem=1 and condtion #1.")
                    UpgradeService(_intCustomerID, 1, 10)
                    InsertLog("successfully called UpdateService for tmpItem=1 and condtion #1.")
                ElseIf CInt(tmpItem) = 10 AndAlso CheckServiceForCustomer(_intCustomerID, 1) Then
                    InsertLog("Conditon #2 : tmpItem=10 & instantiate DTS package")
                    Dim oPKG As New DTS.Package

                    InsertLog("Calling LoadFromSQLServer")
                    oPKG.LoadFromSQLServer(_strServerName, strAdminUID, strAdminPassword, DTSSQLServerStorageFlags.DTSSQLStgFlag_Default, , , , "ExpressToProWeb")

                    InsertLog("Setting Database Server Source : " & _strServerName)
                    oPKG.Connections.Item("Publisher").DataSource = _strServerName

                    InsertLog("Setting Database Name : " & _strDatabaseName)
                    oPKG.Connections.Item("Publisher").Catalog = _strDatabaseName

                    InsertLog("Setting Global Variable (MIdentity) : " & _intCustomerID)
                    oPKG.GlobalVariables.Item("MIdentity").Value = _intCustomerID
                    InsertLog("calling DTS Execute.")
                    oPKG.Execute()

                    InsertLog("calling DTS UnItitilize.")
                    oPKG.UnInitialize()
                    oPKG = Nothing

                    InsertLog("calling SetTableExistsInCSS.")
                    SetTableExistsInCSS(_intCustomerID, tmpItem)

                    InsertLog("calling UpgradeService.")
                    UpgradeService(_intCustomerID, 1, 10)
                    InsertLog("successfully called UpgradeService.")
                Else
                    '*********************************************************************************
                    InsertLog("ELSE : instantiate DTS package")
                    InsertLog("1")
                    Dim Param() As SqlParameter = New SqlParameter(3) {}
                    InsertLog("2")
                    Param(0) = New SqlParameter("@ServerName", SqlDbType.VarChar)
                    Param(0).Value = _strServerName
                    InsertLog("3")
                    Param(1) = New SqlParameter("@DatabaseName", SqlDbType.VarChar)
                    Param(1).Value = _strDatabaseName
                    InsertLog("4")
                    Param(2) = New SqlParameter("@ServiceName", SqlDbType.VarChar)
                    Param(2).Value = ServiceName
                    InsertLog("5")
                    Param(3) = New SqlParameter("@MIdentity", SqlDbType.Int)
                    Param(3).Value = _intCustomerID
                    InsertLog("Calling ACC_CallDTS with parameters")
                    InsertLog("ServerName= " & _strServerName)
                    InsertLog("DatabaseName= " & _strDatabaseName)
                    InsertLog("ServiceName= " & ServiceName)
                    InsertLog("MIdentity= " & _intCustomerID)

                    SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "ACC_CallDTS", Param)

                    'Dim oPKG As New DTS.Package

                    'InsertLog("Calling LoadFromSQLServer")
                    'oPKG.LoadFromSQLServer(_strServerName, strAdminUID, strAdminPassword, DTSSQLServerStorageFlags.DTSSQLStgFlag_Default, , , , ServiceName)

                    'InsertLog("Setting Database Server Source : " & _strServerName)
                    'oPKG.Connections.Item("Publisher").DataSource = _strServerName

                    'InsertLog("Setting Database Name : " & _strDatabaseName)
                    'oPKG.Connections.Item("Publisher").Catalog = _strDatabaseName

                    'InsertLog("calling DTS Execute.")
                    'oPKG.Execute()

                    'InsertLog("calling DTS UnItitilize.")
                    'oPKG.UnInitialize()
                    'oPKG = Nothing

                    InsertLog("calling SetTableExistsInCSS.")
                    SetTableExistsInCSS(_intCustomerID, tmpItem)
                    InsertLog("successfully called SetTableExistsInCSS.")
                End If

            Catch exp As Exception
                InsertLog("Exception : " & exp.Message & vbNewLine & exp.StackTrace)
                Throw New Exception("Service Encountered the Following Error.Class :'" & ServiceName & "'" & exp.Message)

            End Try
            intCount += 1
        Next
        servicesAllowed.Clear()
        servicesAllowed = Nothing
    End Function

    'Public Shared Function AddServiceActivationTrack(ByVal ResellerID As String, _
    '                                                    ByVal OrderID As String, _
    '                                                    ByVal CompanyID As String) As Long
    '    Dim STrackID As Long

    '    Dim SQLParam(3) As SqlParameter
    '    SQLParam(0) = New SqlParameter("@OrderID", SqlDbType.BigInt)
    '    SQLParam(0).Value = OrderID
    '    SQLParam(1) = New SqlParameter("@CompanyID", SqlDbType.BigInt)
    '    SQLParam(1).Value = CompanyID
    '    SQLParam(2) = New SqlParameter("@STrackID", SqlDbType.BigInt)
    '    SQLParam(2).Direction = ParameterDirection.Output
    '    SQLParam(3) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
    '    SQLParam(3).Value = ResellerID

    '    SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_AddServiceActivationTrack", SQLParam)
    '    STrackID = SQLParam(2).Value
    '    Return STrackID
    'End Function

    'Public Shared Sub AddServiceActivationTrackDetail(ByVal STrackID As String, _
    '                                                        ByVal ProductCode As String, _
    '                                                        ByVal SerialNo As Integer)
    '    Dim SQLParam(2) As SqlParameter
    '    SQLParam(0) = New SqlParameter("@STrackID", SqlDbType.BigInt)
    '    SQLParam(0).Value = STrackID
    '    SQLParam(1) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 50)
    '    SQLParam(1).Value = ProductCode
    '    SQLParam(2) = New SqlParameter("@FHSerialNo", SqlDbType.Int)
    '    SQLParam(2).Value = SerialNo

    '    SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_AddServiceActivationTrackDetail", SQLParam)
    'End Sub

    ' Previous work for Services Enable/Disable .


    'Public Function ProcessServices() As Boolean
    '    Dim servicesAllowed As Hashtable = GetServiceNames()
    '    Dim tmpItem As Object
    '    Dim ServiceName As String
    '    Dim managerName As String

    '    Dim strAdminUID As String = ConfigReader.GetItem(ConfigVariables.SQLAdminID)
    '    Dim strAdminPassword As String = ConfigReader.GetItem(ConfigVariables.SQLAdminPassword)

    '    For Each tmpItem In servicesAllowed.Keys

    '        ServiceName = Trim(CType(servicesAllowed(tmpItem), String))

    '        Try

    '            Shell("d:\dbscripts\osql.exe -S DATACENTRE -U " & strAdminUID & " -P " & strAdminPassword & " -d " & _strDatabaseName & " -n -i d:\dbscripts\" & ServiceName & ".sql", AppWinStyle.NormalFocus, True)
    '            SetTableExistsInCSS(_intCustomerID, tmpItem)


    '        Catch exp As Exception

    '            Throw New Exception("Service Encountered the Following Error.Class :'" & ServiceName & "'" & exp.Message)
    '        End Try
    '    Next
    '    servicesAllowed.Clear()
    '    servicesAllowed = Nothing
    'End Function

    'Public Shared Function IsServiceActivated(ByVal ResellerID As String, ByVal OrderID As Long, ByVal ProductCode As String, ByVal SerialNo As Integer) As IsServiceActivatedResult
    '    Dim SQLParam(5) As SqlParameter
    '    SQLParam(0) = New SqlParameter("@OrderID", SqlDbType.BigInt)
    '    SQLParam(0).Value = OrderID
    '    SQLParam(1) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 50)
    '    SQLParam(1).Value = ProductCode
    '    SQLParam(2) = New SqlParameter("@SerialNo", SqlDbType.Int)
    '    SQLParam(2).Value = SerialNo
    '    SQLParam(3) = New SqlParameter("@Success", SqlDbType.Bit)
    '    SQLParam(3).Direction = ParameterDirection.Output
    '    SQLParam(4) = New SqlParameter("@CompanyID", SqlDbType.BigInt)
    '    SQLParam(4).Direction = ParameterDirection.Output
    '    SQLParam(5) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
    '    SQLParam(5).Value = ResellerID

    '    SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_IsServiceActivated", SQLParam)

    '    Dim objIsServiceActivatedResult As New IsServiceActivatedResult
    '    objIsServiceActivatedResult.ServiceAlreadyActivated = SQLParam(3).Value
    '    objIsServiceActivatedResult.CustomerID = IIf(IsDBNull(SQLParam(4).Value), "-1", SQLParam(4).Value)
    '    Return objIsServiceActivatedResult
    'End Function
    'Public Structure IsServiceActivatedResult
    '    Public ServiceAlreadyActivated As Boolean
    '    Public CustomerID As Long
    'End Structure

#End Region

#Region "   Private Methods .............."

    Private Function UpgradeService(ByVal Customerid As Integer, ByVal ServiceFrom As Integer, ByVal ServiceTo As Integer) As Boolean

        Dim Success As Boolean
        Dim arrParams As SqlParameter() = New SqlParameter(2) {}
        arrParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arrParams(0).Value = Customerid
        arrParams(1) = New SqlParameter("@ServiceIDFrom", SqlDbType.Int)
        arrParams(1).Value = ServiceFrom
        arrParams(2) = New SqlParameter("@ServiceIDTo", SqlDbType.Int)
        arrParams(2).Value = ServiceTo

        Try
            Dim objTemp As Object
            objTemp = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ADMIN_UpgradeCustomerSelectedServices", arrParams)
            If Not IsDBNull(objTemp) Then
                If CInt(objTemp) = 1 Then
                    Success = True
                Else
                    Success = False
                End If
            Else
                Success = False
            End If
        Catch sqle As SqlException
            Throw New Exception(sqle.Message)
        End Try
        Return Success

    End Function

    Private Function GetServiceNames() As Hashtable

        Dim CustomerID As Int32 = _intCustomerID
        Dim serviceNames As New Hashtable

        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = CustomerID
        Try

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_GetServiceNames", arrParams)
            While reader.Read
                serviceNames.Add(reader("ServiceID"), reader("Name"))
            End While
        Catch sqle As SqlException
            Throw New Exception("Service Names Cannot be retrieved ." & sqle.Message)
        End Try

        '    'returning the ArrayList of String values 
        Return serviceNames
    End Function

    Public Shared Function GetServerName(ByVal customerId As String) As String
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerId

        Dim ServerName As String
        ServerName = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfiniShopMainDB.dbo.Acc_GetDatabaseName", arrParams).Tables(0).Rows(0).Item("server_name")

        Return ServerName
    End Function

    Private Function CreateDatabase(ByVal customerId As Int32) As String
        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 50)
        arrParams(0).Value = customerId
        arrParams(1) = New SqlParameter("@message", SqlDbType.NVarChar, 100)
        arrParams(1).Direction = ParameterDirection.Output
        arrParams(1).Value = ""

        Try

            SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "Acc_CreateDatabase", arrParams)
            Return arrParams(1).Value

        Catch sqle As Exception  ' SqlException
            Throw New Exception("Database Cannot be Created." & sqle.Message)
        End Try

    End Function

    Private Sub SetTableExistsInCSS(ByVal customerId As Int32, ByVal serviceId As Int32)
        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.Int)
        arrParams(0).Value = customerId
        arrParams(1) = New SqlParameter("@serviceID", SqlDbType.Int)
        arrParams(1).Value = serviceId
        Try
            SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.ACC_SetTableExistsInCSS", arrParams)
        Catch sqle As Exception  ' SqlException
            Throw New Exception("Table Exists couldn't be set." & sqle.Message)
        End Try
    End Sub

    Private Sub InsertLog(ByVal text As String)
        '#If FileWrite Then
        Dim sw As StreamWriter = Nothing
        Dim dirName As String = "D:/ACC_BLL"
        Dim fileName As String = dirName & "/ServiceManager_CID_" & _intCustomerID & ".txt"

        Try
            If Not Directory.Exists(dirName) Then
                Directory.CreateDirectory(dirName)
            End If

            If File.Exists(fileName) Then
                sw = File.AppendText(fileName)
            Else
                sw = File.CreateText(fileName)
            End If

            sw.WriteLine("Date : " & Now.ToString & vbTab & " ~~ " & text)


        Catch ex As Exception
        Finally
            If Not sw Is Nothing Then
                sw.Close()
            End If

            sw = Nothing
        End Try
        '#End If
    End Sub
#End Region

#Region "   Shared Methods .............."

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Checks if the service is avaiable for the customer or not.
    ''' </summary>
    '''     ''' <param name="CustomerID"></param>
    ''' <param name="ServiceID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.afaq]	1/4/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function CheckServiceForCustomer(ByVal CustomerID As Integer, ByVal ServiceID As Integer) As Boolean
        Dim ProductExists As Boolean
        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arrParams(0).Value = CustomerID
        arrParams(1) = New SqlParameter("@ServiceID", SqlDbType.Int)
        arrParams(1).Value = ServiceID

        Try
            Dim objTemp As Object
            objTemp = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ADMIN_CheckServiceForCustomer", arrParams)
            If Not IsDBNull(objTemp) Then
                If CInt(objTemp) = 1 Then
                    ProductExists = True
                Else
                    ProductExists = False
                End If
            Else
                ProductExists = False
            End If
        Catch sqle As SqlException
            Throw New Exception(sqle.Message)
        End Try
        Return ProductExists

    End Function
    Public Shared Function GetDatabaseName(ByVal customerId As String) As String

        Dim databaseName As String
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerId

        Try
            Dim objTemp As Object
            objTemp = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "Acc_GetDatabaseName", arrParams)
            If Not IsDBNull(objTemp) Then
                databaseName = CStr(objTemp)
            End If

        Catch sqle As SqlException
            Throw New Exception(sqle.Message)
        End Try
        Return databaseName
    End Function
    Public Shared Function GetCurrencyID(ByVal customerID As Integer) As String
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerID
        Dim sign
        Try
            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_GetCurrencyID", arrParams)
            While reader.Read
                sign = reader("currencyID")
            End While
        Catch sqle As SqlException
            Throw New Exception("Currency ID Cannot be retrieved ." & sqle.Message)
        End Try
        Return sign
    End Function
    Public Shared Function GetServicesAllowed(ByVal customerID As Integer) As ArrayList

        Dim serviceNames As New ArrayList
        Dim databaseName As String
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerID
        Try

            Dim reader As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_GetServicesAllowed", arrParams)
            While reader.Read
                serviceNames.Add(reader("Name"))
            End While
        Catch sqle As SqlException
            Throw New Exception("Service Names Cannot be retrieved ." & sqle.Message)
        End Try
        '    'returning the ArrayList of String values 
        Return serviceNames
    End Function
    Public Shared Function GetCustomerID(ByVal loginId As String) As String

        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@loginID", SqlDbType.VarChar, 10)
        arrParams(0).Value = loginId

        Dim customerId As String = ""

        Try

            customerId = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "Acc_GetCustomerID", arrParams)
        Catch sqle As SqlException
            Throw New Exception("Customer Does Not exists." & sqle.Message)
        End Try
        Return customerId
    End Function
    Public Shared Function AllowedServicesMenu(ByVal CustomerID As Integer) As SqlClient.SqlDataReader
        Dim cmd As New InfiniLogic.AccountsCentre.DAL.CommandData
        Dim sqlDR As SqlClient.SqlDataReader

        With cmd
            Try
                .CmdText = "Acc_GetServicesAllowed"
                .AddParameter("@CustomerID", CustomerID)

                sqlDR = .Execute(DAL.ExecutionType.ExecuteReader)

            Catch ex As Exception
                sqlDR.Close()
                .CloseConnection()
            End Try
        End With

        Return sqlDR
    End Function
    Public Shared Function GetPurchasebleServices(ByVal CustomerID As Integer, Optional ByVal ServiceOption As Long = AccountsCentre.BLL.ServiceOptions.EnableSale) As SqlClient.SqlDataReader
        Dim cmd As New InfiniLogic.AccountsCentre.DAL.CommandData
        Dim sqlDR As SqlClient.SqlDataReader

        With cmd
            Try
                .CmdText = "DbServer.InfinishopMainDb.dbo.Acc_GetServicesToPurchase"
                .AddParameter("@CustomerID", CustomerID)
                .AddParameter("@PackageOption", ServiceOption)

                sqlDR = .Execute(DAL.ExecutionType.ExecuteReader)

            Catch ex As Exception
                sqlDR.Close()
                .CloseConnection()
            End Try
        End With

        Return sqlDR
    End Function
    Public Shared Function GetServicesDependencies() As DataTable
        Dim ds As DataSet = Nothing
        Dim sqlDR As SqlDataReader
        Dim cmd As New DAL.CommandData

        Try
            With cmd
                .CmdText = "DbServer.InfinishopMainDb.dbo.ACC_GetDependentProducts"

                ds = .Execute(DAL.ExecutionType.ExecuteDataSet)
            End With

            Return ds.Tables(0)

        Catch ex As Exception
        Finally
            cmd.CloseConnection()
            cmd = Nothing
        End Try

        Return Nothing
    End Function
    Public Shared Function GetReSellerProducts(ByVal ReSellerId As Integer) As String
        '''Created By Muhammad Ubaid
        '''Date:16-May-2006
        '''Purpuse To Get the ReSeller Products by means of webservice of infinibiz
        '''and Return the products xml
        '''"<products><product id='104' name='Infinishops'/></products>"

        Dim objWebService As New com.infinibiz.webservices.IBZservices
        Dim ReSellerProducts As New com.infinibiz.webservices.returnResellerProducts
        Dim ProductsCounter As Integer = 0
        Dim ProductsXml As String = "<products>"
        '"<products><product id='CP31' name='value Accounting'/><product id='CP9' name='Express formation'/><product id='CP37' name='virtual office'/><product id='CP28' name='payroll services'/><product id='182' name='collection services'/><product id='103' name='collection services'/></products>"  
        Dim productsInfo As New com.infinibiz.webservices.productinfo
        Dim Acc_Products As New AccountsCentre.DAL.CommandData
        Dim ds_products As DataSet
        ReSellerProducts = objWebService.getResellerProducts(ReSellerId)
        For ProductsCounter = 0 To ReSellerProducts.products.Length - 1
            productsInfo = ReSellerProducts.products.GetValue(ProductsCounter)
            ProductsXml += "<product id='" + productsInfo.code + "' name='" + productsInfo.name + "'/>"
        Next
        ProductsXml += "</products>"
        With Acc_Products
            .CmdType = CommandType.StoredProcedure
            .CmdText = "DbServer.InfinishopMainDb.dbo.Get_Acc_products"
            .AddParameter("@doc", ProductsXml)
            ds_products = .Execute(ExecutionType.ExecuteDataSet)
            ProductsXml = ds_products.GetXml
            .CloseConnection()
        End With
        Return ProductsXml
    End Function
    Public Shared Function GetCustomerLoginID(ByVal customerid As String) As String
        '''Created By Muhammad Ubaid
        '''Date:16-May-2006
        '''it return the login id...

        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerid", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerid

        Dim loginId As String = ""

        Try
            loginId = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "Acc_GetCustomerLoginId", arrParams)
        Catch sqle As SqlException
            Throw New Exception("Customer Does Not exists." & sqle.Message)
        End Try
        Return loginId
    End Function
    Public Shared Function GetReSellerID(ByVal customerid As String) As String
        '''Created By Muhammad Ubaid
        '''Date:26-May-2006
        '''it return the Reseller id...
        Dim cmd As New InfiniLogic.AccountsCentre.DAL.CommandData
        Dim Resellerid As String
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}

        arrParams(0) = New SqlParameter("@customerid", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerid

        Try
            Resellerid = SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "[DBSERVER].[InfinishopMainDB].[DBO].Acc_Get_ReSeller_Id", arrParams)
        Catch sqle As SqlException
            Throw New Exception("Customer Does Not exists." & sqle.Message)
        End Try

        Return Resellerid

    End Function
    Public Shared Function VerifyUser(ByVal strUserID As String, ByVal strPassword As String)
        '''Created By Muhammad Ubaid
        '''Date:26-May-2006
        '''
        '***************************************************
        System.Web.HttpContext.Current.Trace.Warn("------Verify User strat-----")

        Dim objCryptography As New Cryptography
        Dim objUser As New User
        Dim blnMsg As Boolean
        Dim Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
        Dim CustomerID As Int32 'Unique ID for employer
        Dim strGKeyLen As Integer = 1024
        Dim intReturnValue, intReturnValue1 As Int16
        Dim _strDatabaseName As String = String.Empty

        Dim b As Boolean
        Dim returnXml As String = ""

        CustomerID = 0
        strLogKey = String.Empty
        strDatabaseName = String.Empty
        intReturnValue = 0
        intReturnValue1 = 0
        System.Web.HttpContext.Current.Trace.Warn("variables initilized..")
        System.Web.HttpContext.Current.Trace.Warn("Calling objUser.VerifySignIn")
        objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
        strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)

        Try
            If intReturnValue = 0 Then
                System.Web.HttpContext.Current.Trace.Warn("intReturnValue=0")
                returnXml = "<data><error code='1' desc='user not found' /></data>"
            Else
                System.Web.HttpContext.Current.Trace.Warn("matching password")
                If strPassword.ToString = strDecryptPassword.ToString Then
                    System.Web.HttpContext.Current.Trace.Warn("password verified...")
                    System.Web.HttpContext.Current.Trace.Warn("calling reseller id")
                    If CType(GetReSellerID(CustomerID), Integer) > 0 Then
                        System.Web.HttpContext.Current.Trace.Warn("Reseller Found..")
                        returnXml = "<data><error code='0' desc='user is authenticated' customerid='" & CustomerID & "'/></data>"
                    Else
                        System.Web.HttpContext.Current.Trace.Warn("Reseller Not Found")
                        returnXml = "<data><error code='1' desc='user not found'/></data>"
                    End If
                Else
                    System.Web.HttpContext.Current.Trace.Warn("password not found")
                    returnXml = "<data><error code='1' desc='user not found'/></data>"
                End If
            End If
            Return Trim(returnXml)
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception occur in verifyuser" & ex.Message & " -->" & ex.Source)
            System.Web.HttpContext.Current.Trace.Warn("stack Trace" & ex.StackTrace)
            returnXml = "<data><error code='-11' desc='Unknown Error'/></data>"
        End Try
    End Function
    Public Shared Function GetInactivateProducts(ByVal customerId As String) As DataSet
        '''Created By Muhammad Ubaid
        '''Date:14-JUNE-2006
        '''Purpuse To Get the ReSeller Products by means of webservice of infinibiz
        '''and Return data set
        Dim objWebService As New FHResellerCustomer.IBZservices
        Dim inactivateProductsRequest As New FHResellerCustomer.getInactiveProductsRequest
        Dim inactivateProductsResponse As New FHResellerCustomer.getInactiveProductsResponse
        Dim inactivateProductsInfoList As New FHResellerCustomer.infolist
        Dim ProductsCounter As Integer = 0
        Dim ErrorCode As Object
        Dim ErrorDesc As Object
        Dim ProductsXml As String = "<products>"
        '"<products><product id="104"  serialno="1" orderno="19803"/>  <product id="182"  serialno="2" orderno="19803"/>  <product id="CP1"  serialno="3" orderno="19803"/>  <product id="CP28"  serialno="4" orderno="19803"/><product id="CP28"  serialno="66" orderno="19803"/><product id="CP31"  serialno="5" orderno="19803"/>  <product id="CP37"  serialno="6" orderno="19803"/>  <product id="CP53"  serialno="7" orderno="19803"/>  <product id="CP7"  serialno="8" orderno="19803"/>  <product id="CP9"  serialno="9" orderno="19803"/>  </products>"
        Dim Acc_Products As New AccountsCentre.DAL.CommandData
        Dim ds_products As DataSet
        Try
            inactivateProductsRequest.customeruid = GetCustomerLoginID(customerId)
            inactivateProductsResponse = objWebService.getInactiveProducts(inactivateProductsRequest)
            ErrorCode = inactivateProductsResponse.ERRORCODE
            ErrorDesc = inactivateProductsResponse.ERRORDESC
            ' If ErrorCode = 0 Then
            For Each products As Object In inactivateProductsResponse.info
                inactivateProductsInfoList = products
                ProductsXml += "<product id='" + inactivateProductsInfoList.productcode + "' serialno='" + inactivateProductsInfoList.serialno + "' orderno='" + inactivateProductsInfoList.orderno + "'/>"
            Next
            ProductsXml += "</products>"
            With Acc_Products
                .CmdType = CommandType.StoredProcedure
                .CmdText = "DbServer.InfinishopMainDb.dbo.Rss_Get_Inactivate_products"
                .AddParameter("@doc", ProductsXml)
                ds_products = .Execute(ExecutionType.ExecuteDataSet)
                .CloseConnection()
            End With
            Return ds_products
            '   End If
        Catch ex As Exception
        End Try
    End Function
#End Region

End Class

