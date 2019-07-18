Imports System.Data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL

Public Class ProductActivation
    Private colEnableWeb As New System.Collections.Specialized.NameValueCollection
    Private colEnableDesktop As New System.Collections.Specialized.NameValueCollection

    'This Function Return New CustomerID 
    Public Function Activate(ByVal ResellerID As String, _
                                ByVal ChildCustomerID As Integer, _
                                ByVal ProductCode As String, _
                                ByVal OrderNo As Integer, _
                                ByVal SerialNo As Integer, _
                                ByVal Language As String, _
                                ByVal CompanyName As String, _
                                ByVal IsOffsiteReseller As Boolean, _
                                ByVal IsOnsiteReseller As Boolean, _
                                ByVal IsMerchant As Boolean, _
                                ByVal LogUniquePath As String, _
                                ByVal ParentID As Integer, _
                                ByVal AccountsProServiceID As Integer, _
                                ByVal CurrencyID As Integer, _
                                ByVal CurrencySign As String) As String
        Dim Success As Boolean

        '-------------------------------------------------------------------------------
        Dim sCustomerAction As String = ""
        Dim oACRegBLL As New Administration.BLL.ACRegistrationBLL
        Dim dtACUByID As DataTable
        
        If ChildCustomerID = -1 Then
            Dim NewCustomerID As Integer
            Dim ParentPassword, ParentLogKey As String

            WriteDebugInfo("calling GetCustomerData", LogUniquePath)
            ParentPassword = (New User).GetCustomerData(ParentID).Tables(0).Rows(0).Item("Cart_Customer_pass")
            WriteDebugInfo("GetCustomerData is ok", LogUniquePath)
            ParentLogKey = (New User).GetLogKey(ParentID)

            Dim objCrypt As New InfiniLogic.AccountsCentre.common.Cryptography
            ParentPassword = objCrypt.DeCrypt(ParentPassword, ParentLogKey)

            WriteDebugInfo("CreateSubCustomer is calling", LogUniquePath)
            NewCustomerID = CreateSubCustomer(ParentID, ParentPassword)
            WriteDebugInfo("CreateSubCustomer is ok and NewCustomerID=" & NewCustomerID, LogUniquePath)

            WriteDebugInfo("Calling AddAccountsCentreUser", LogUniquePath)
            InfiniLogic.AccountsCentre.BLL.User.AddAccountsCentreUser(NewCustomerID, CompanyName)
            WriteDebugInfo("AddAccountsCentreUser is ok", LogUniquePath)

            WriteDebugInfo("Calling AddResellerCustomersDetail", LogUniquePath)
            InfiniLogic.AccountsCentre.BLL.User.AddResellerCustomersDetail(ParentID, NewCustomerID)
            WriteDebugInfo("AddResellerCustomersDetail is ok", LogUniquePath)
            ChildCustomerID = NewCustomerID
        Else
            WriteDebugInfo("Existing Company Selected", LogUniquePath)
            WriteDebugInfo("ChildCustomerID=" & ChildCustomerID, LogUniquePath)
        End If

        '------Getting Merchant CurrencyDBCustomerID ----------Start
        Dim CurrencyDBCustomerID As String = ""

        WriteDebugInfo("Calling GetResellerCurrencyDBCustomerID: ResellerID = " & ResellerID, LogUniquePath)
        CurrencyDBCustomerID = GetResellerCurrencyDBCustomerID(ResellerID)
        WriteDebugInfo("GetResellerCurrencyDBName is ok: GetResellerCurrencyDBCustomerID = " & CurrencyDBCustomerID, LogUniquePath)
        '------Getting Merchant CurrencyDBCustomerID ----------End

        WriteDebugInfo("MapCustomerSelectedService is calling:", LogUniquePath)
        WriteDebugInfo("    CurrencyDBCustomerID=" & CurrencyDBCustomerID, LogUniquePath)
        WriteDebugInfo("    ChildCustomerID=" & ChildCustomerID, LogUniquePath)
        WriteDebugInfo("    ProductCode=" & ProductCode, LogUniquePath)
        WriteDebugInfo("    OrderNo=" & OrderNo, LogUniquePath)
        WriteDebugInfo("    AccountsProServiceID=" & AccountsProServiceID, LogUniquePath)
        Success = MapCustomerSelectedService(CurrencyDBCustomerID, ChildCustomerID, ProductCode, OrderNo, AccountsProServiceID)
        WriteDebugInfo("MapCustomerSelectedService is ok and return = " & Success, LogUniquePath)

        If AccountsProServiceID <> -1 Then
            Merchant.UpdateCurrencyInfo_MerchantID(ChildCustomerID, AccountsProServiceID, CurrencyID, CurrencySign)
        End If

        Dim GlobalCompanyID As String
        '---------------AddMerchant In InfiniOffice------------Start
        Dim objIOService As New InfiniLogic.AccountsCentre.BLL.InfiniOfficeService
        WriteDebugInfo("Calling CallIOServices: ChildID = " & ChildCustomerID & " - OrderID=" & OrderNo, LogUniquePath)
        GlobalCompanyID = objIOService.CallIOServices(ChildCustomerID, OrderNo)
        WriteDebugInfo("CallIOServices is ok: GlobalCompanyID=" & GlobalCompanyID, LogUniquePath)
        '---------------AddMerchant In InfiniOffice------------End

        '--------------------------------Inform To FH----------------------------------
        WriteDebugInfo("Create IBZservices Object", LogUniquePath)
        Dim FHService As New FHResellerCustomer.IBZservices
        WriteDebugInfo("done!", LogUniquePath)
        WriteDebugInfo("Set Activation Info", LogUniquePath)

        '---------------Applying Format on OrderNo----------Start
        'Modified by:   M.Yousuf
        'Date:          Feb 22, 2007
        'Description:   OrderID can be duplicate so from now it will concatenate with
        '               reseller id and length of resellerid
        'Example:       112606       5295     06
        '               ------       ----     --
        '               ResellerID   OrderID  Len(ResellerID's Length)
        '
        '               Last two digits show the length of Resellerid
        '               which is: 112606
        '               remaining digits are orderid: 5295
        '----------------------------------------------------------
        Dim LongOrderID As String = System.Configuration.ConfigurationSettings.AppSettings("LongOrderID")
        WriteDebugInfo("LongOrderID=" & LongOrderID, LogUniquePath)
        Dim FH_OrderNo As String
        If LongOrderID = "1" Then
            Dim ResellerIDLength As String = IIf((ResellerID.Length & "").Length = 1, "0" & ResellerID.Length, ResellerID.Length)
            FH_OrderNo = ResellerID & OrderNo & ResellerIDLength
        Else
            FH_OrderNo = OrderNo
        End If

        '---------------Applying Format on OrderNo----------End

        WriteDebugInfo("CustomerID=" & ParentID, LogUniquePath)
        WriteDebugInfo("OrderNo=" & OrderNo, LogUniquePath)
        WriteDebugInfo("FH_OrderNo=" & FH_OrderNo, LogUniquePath)
        WriteDebugInfo("ChildCustomerID =" & ChildCustomerID, LogUniquePath)
        WriteDebugInfo("CompanyName=" & CompanyName, LogUniquePath)
        WriteDebugInfo("GlobalCompanyID=" & GlobalCompanyID, LogUniquePath)


        Dim ActivationInfo As New FHResellerCustomer.activationinfo
        ActivationInfo.customerid = ParentID
        ActivationInfo.orderno = FH_OrderNo
        ActivationInfo.entityid = ChildCustomerID
        ActivationInfo.entityname = CompanyName
        ActivationInfo.globalcompanyid = GlobalCompanyID

        If IsOnsiteReseller Then
            'for resellerpro, resellerpro-plus referer is 1005
            ActivationInfo.referrer = "1005"
        ElseIf IsOffsiteReseller Then
            'for api reseller referer is 1012
            ActivationInfo.referrer = "1012"
        Else
            'for other acc products ... referer is 1009
            ActivationInfo.referrer = "1009"
        End If

        '''Updated by MFK on 12 JAN 2007 to vary referrer according to productcode
        'Select Case ProductCode
        '    Case "528", "529"   'for resellerpro, resellerpro-plus referer is 1005
        '        ActivationInfo.referrer = "1005"
        '    Case "530"   'for api reseller referer is 1012
        '        ActivationInfo.referrer = "1012"
        '    Case Else 'for other acc products ... referer is 1009
        '        ActivationInfo.referrer = "1009"
        'End Select
        WriteDebugInfo("Referrer=" & ActivationInfo.referrer, LogUniquePath)
        WriteDebugInfo("done!", LogUniquePath)
        WriteDebugInfo("Set pcodeinfo", LogUniquePath)
        Dim PCodeInfo(0) As FHResellerCustomer.pcodeinfo
        PCodeInfo(0) = New FHResellerCustomer.pcodeinfo
        WriteDebugInfo("ProductCode = " & ProductCode, LogUniquePath)
        PCodeInfo(0).productcode = ProductCode
        PCodeInfo(0).serialno = SerialNo
        PCodeInfo(0).newserialno = SerialNo
        PCodeInfo(0).renewable = 1
        PCodeInfo(0).renewduration = 12
        WriteDebugInfo("done!", LogUniquePath)
        ActivationInfo.productcodes = PCodeInfo

        WriteDebugInfo("ActivateProduct Calling", LogUniquePath)
        WriteDebugInfo("    ActivationInfo.referrer=" & ActivationInfo.referrer, LogUniquePath)
        WriteDebugInfo("    ActivationInfo.entityid=" & ActivationInfo.entityid, LogUniquePath)
        WriteDebugInfo("    ActivationInfo.entityname=" & ActivationInfo.entityname, LogUniquePath)
        WriteDebugInfo("    ActivationInfo.orderno=" & ActivationInfo.orderno, LogUniquePath)
        WriteDebugInfo("    ActivationInfo.globalcompanyid=" & ActivationInfo.globalcompanyid, LogUniquePath)

        WriteDebugInfo("    PCodeInfo(0).productcode=" & PCodeInfo(0).productcode, LogUniquePath)
        WriteDebugInfo("    PCodeInfo(0).serialno=" & PCodeInfo(0).serialno, LogUniquePath)
        WriteDebugInfo("    PCodeInfo(0).newserialno=" & PCodeInfo(0).newserialno, LogUniquePath)
        WriteDebugInfo("    PCodeInfo(0).renewable=" & PCodeInfo(0).renewable, LogUniquePath)
        WriteDebugInfo("    PCodeInfo(0).renewduration=" & PCodeInfo(0).renewduration, LogUniquePath)
        WriteDebugInfo("    PCodeInfo(0).productcode=" & PCodeInfo(0).productcode, LogUniquePath)
        Dim ReturnMSG As FHResellerCustomer.returnmsg
        ReturnMSG = FHService.activateProducts(ActivationInfo)
        WriteDebugInfo("ActivateProduct is ok", LogUniquePath)
        WriteDebugInfo("ERRCODE=" & ReturnMSG.ERRORCODE.ToString(), LogUniquePath)
        WriteDebugInfo("ERRDESC=" & ReturnMSG.ERRORDESC.ToString(), LogUniquePath)

        If Not ReturnMSG.ERRORCODE.ToString().Trim().Equals("0") Then
            Dim serviceParameter As New System.Text.StringBuilder
            serviceParameter.Append("customerid=" & ParentID & "::")
            serviceParameter.Append("orderno=" & OrderNo & "::")
            serviceParameter.Append("globalcompanyid=" & ActivationInfo.globalcompanyid & "::")

            serviceParameter.Append("entityid=" & ChildCustomerID & "::")
            serviceParameter.Append("entityname=" & CompanyName & "::")
            serviceParameter.Append("referrer=" & ActivationInfo.referrer & "::")
            serviceParameter.Append("productcode=" & ProductCode & "::")
            serviceParameter.Append("SerialNo=" & SerialNo & "::")
            serviceParameter.Append("renewable=" & 0 & "::")
            serviceParameter.Append("renewduration=" & 0)

            InfiniLogic.AccountsCentre.BLL.User.AddWebServiceLog(Web.HttpContext.Current.Request.Url.Host & "/account/customer.asmx.vb", _
                                "activate", _
                                "http://webservices.infinibiz.com/customer.php", _
                                "activateProducts", _
                                serviceParameter.ToString, ReturnMSG.ERRORCODE.ToString, ReturnMSG.ERRORDESC)
        End If
        '------------------------------------done--------------------------------------

        Return ChildCustomerID
    End Function

    Public Function GetResellerCurrencyDBInfo(ByVal ResellerID As String) As DataSet
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(0).Value = ResellerID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfiniShopMainDB.dbo.RSS_Robot_GetResellerCurrencyDBInfo", arParams)

        Return ds
    End Function

    Public Function GetResellerCurrencyDBCustomerID(ByVal ResellerID As String) As String
        Return GetResellerCurrencyDBInfo(ResellerID).Tables(0).Rows(0).Item("CDBCustomerID")
    End Function

    Public Function CreateSubCustomer(ByVal CustomerID As Integer, ByVal ParentPassword As String) As Integer
        'Get Gkey and encrypted password
        Dim strGKeyLen As Integer = 1024
        Dim strGKey, strPassword, strEncryptPassword As String
        Dim objCryptography As New InfiniLogic.AccountsCentre.common.Cryptography
        strPassword = GetPassword()
        'strPassword = ParentPassword
        strGKey = objCryptography.KeyGen(strGKeyLen)
        strEncryptPassword = objCryptography.EnCrypt(strPassword, strGKey)

        'Get Random value as a prefix of Customer ID, to make Customer Login ID
        Dim intRndNo As Integer
        intRndNo = GetRandomValue()

        Dim NewCustomerID As Integer
        NewCustomerID = CreateCustomerFromAnother(CustomerID, intRndNo, strEncryptPassword, strGKey)
        Return NewCustomerID
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

    Private Function IsProductCodeAvailable(ByVal ProductCode As String, _
                                           ByVal ProductCodeList As String) As Boolean
        Dim ProductCodeListArray() As String = ProductCodeList.Split(New Char() {","})
        For Each Item As String In ProductCodeListArray
            If Item.ToUpper = ProductCode.ToUpper Then
                Return True     'ProductCode found!
            End If
        Next
        Return False            'ProductCode not found!
    End Function

    Private Function CreateCustomerFromAnother(ByVal SourceCustomerID As Integer _
                                            , ByVal RandomValue As Integer _
                                            , ByVal Cart_Customer_Pass As String _
                                            , ByVal GKey As String) As Integer
        Dim Cmd = New CommandData
        Cmd.AddParameter("@SourceCustomerID", SourceCustomerID)
        Cmd.AddParameter("@RandomValue", RandomValue)
        Cmd.AddParameter("@Cart_Customer_Pass", Cart_Customer_Pass)
        Cmd.AddParameter("@GKey", GKey)
        Cmd.AddParameter("@NewCustomerID", 0, ParameterDirection.Output)

        Cmd.CmdText = "DBServer.InfinishopMainDB.dbo.RSS_CreateRS_ACCustomer"
        Cmd.Execute(ExecutionType.ExecuteNonQuery)

        Dim NewCustomerID As Integer
        NewCustomerID = Cmd.Item("@NewCustomerID")

        Cmd.ClearParameters()
        Cmd.CloseConnection()

        Return NewCustomerID
    End Function

    Public Function MapCustomerSelectedService(ByVal CurrencyDBCustomerID As Integer, _
                                            ByVal CustomerID As Integer, _
                                            ByVal ProductCode As String, _
                                            ByVal OrderNo As Integer, _
                                            ByVal AccountsProServiceID As Integer) As Boolean

        Dim dsCustomers As DataSet
        Dim dsServiceInfo As New DataSet
        Dim strExpiryDate As String = GetExpiryDate(CurrencyDBCustomerID, OrderNo)
        Dim intServiceID As Integer
        Dim strServiceName As String
        Dim strServiceOption As String

        Dim strLogin As String

        dsCustomers = SelectCustomers(CustomerID)   'select * from customer

        strLogin = dsCustomers.Tables(0).Rows(0).Item("cart_customer_uid")

        dsServiceInfo = Serviceinfo(ProductCode)

        Dim PackageCode As String = ProductCode
        Dim strCode As String
        Dim i As Integer
        For i = 0 To dsServiceInfo.Tables(0).Rows.Count - 1
            intServiceID = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceID")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceID"))   'ds.Tables(0).Rows(i).Item("ServiceID")
            strServiceName = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceName")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("ServiceName"))
            strServiceOption = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("Status")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("status"))
            strCode = IIf(IsDBNull(dsServiceInfo.Tables(0).Rows.Item(i).Item("ProductCode")), "", dsServiceInfo.Tables(0).Rows.Item(i).Item("ProductCode"))
            If (strServiceOption And ACC_ServiceOptions.DesktopApplication) = ACC_ServiceOptions.DesktopApplication Then
                colEnableDesktop.Add(intServiceID, strServiceName)
            Else
                colEnableWeb.Add(intServiceID, strServiceName)
            End If
            ManageAccountsCentreServices(intServiceID, CustomerID, strLogin, "Enable", strExpiryDate)

            'Manager customer rights on application level using parameter
            'CustomerID, PackageCode, ProductCode, ServiceID, 
            System.Web.HttpContext.Current.Trace.Write("Calling ManagerCustomerRights")
            ManagerCustomerRights(CustomerID, PackageCode, strCode, intServiceID)
            System.Web.HttpContext.Current.Trace.Write("ManagerCustomerRights is ok")
        Next


        'If IShop package is selected then activate accounts pro w.r.t AccountsProServiceID
        If AccountsProServiceID <> -1 Then

            System.Web.HttpContext.Current.Trace.Write("Calling GetServiceInfo: AccountsProServiceID=" & AccountsProServiceID)
            Dim dsService As DataSet = GetServiceInfo(AccountsProServiceID)
            System.Web.HttpContext.Current.Trace.Write("GetServiceInfo is ok")

            intServiceID = AccountsProServiceID

            strServiceName = dsService.Tables(0).Rows(0).Item("ServiceName")
            System.Web.HttpContext.Current.Trace.Write("strServiceName = " & strServiceName)

            strServiceOption = dsService.Tables(0).Rows(0).Item("Status")
            System.Web.HttpContext.Current.Trace.Write("strServiceOption = " & strServiceOption)

            strCode = dsService.Tables(0).Rows(0).Item("ProductCode")
            System.Web.HttpContext.Current.Trace.Write("strCode = " & strCode)

            If (strServiceOption And ACC_ServiceOptions.DesktopApplication) = ACC_ServiceOptions.DesktopApplication Then
                colEnableDesktop.Add(intServiceID, strServiceName)
            Else
                colEnableWeb.Add(intServiceID, strServiceName)
            End If

            System.Web.HttpContext.Current.Trace.Write("Calling ManageAccountsCentreServices")
            ManageAccountsCentreServices(intServiceID, CustomerID, strLogin, "Enable", strExpiryDate)
            System.Web.HttpContext.Current.Trace.Write("ManageAccountsCentreServices is ok")

            'Manager customer rights on application level using parameter
            'CustomerID, PackageCode, ProductCode, ServiceID, 
            System.Web.HttpContext.Current.Trace.Write("Calling ManagerCustomerRights")
            ManagerCustomerRights(CustomerID, PackageCode, strCode, intServiceID)
            System.Web.HttpContext.Current.Trace.Write("ManagerCustomerRights is ok")
        End If

        Return True
    End Function

    Public Shared Function GetServiceInfo(ByVal ServiceID As Integer) As DataSet
        Dim SQLParam(0) As SqlClient.SqlParameter
        SQLParam(0) = New SqlParameter("@ServiceID", SqlDbType.Int)
        SQLParam(0).Value = ServiceID

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetServiceInfo_ServiceID", SQLParam)
    End Function

    Private Sub ManagerCustomerRights(ByVal CustomerID As Long, ByVal PackageCode As String, ByVal ProductCode As String, ByVal ServiceID As Integer)
        Dim SQLParam(3) As SqlClient.SqlParameter
        SQLParam(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        SQLParam(0).Value = CustomerID
        SQLParam(1) = New SqlParameter("@PackageCode", SqlDbType.VarChar, 20)
        SQLParam(1).Value = PackageCode
        SQLParam(2) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 20)
        SQLParam(2).Value = ProductCode
        SQLParam(3) = New SqlParameter("@ServiceID", SqlDbType.Int)
        SQLParam(3).Value = ServiceID

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_ManagerCustomerRights", SQLParam)
    End Sub


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
                .Execute(ExecutionType.ExecuteNonQuery)

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
                objSM = New InfiniLogic.AccountsCentre.BLL.ServicesManager(Val(customerID), strDatabaseName)
            End If

            objSM.ProcessServices()

            objSM = Nothing

            If (serviceID = 5 Or serviceID = 14) And serviceStatus = "Enable" Then
                Dim CamService As New Administration.BLL.ActivateService
                CamService.ActivateService(customerID + 0, customerUID, serviceID + 0)
                CamService = Nothing
            End If
            Return True
        Else
            Return False

        End If
    End Function

    Private Function GetExpiryDate(ByVal CurrencyDBCustomerID As Integer, ByVal OrderID As Integer) As DateTime
        Dim ExpiryDate As DateTime
        Dim SQLParam(1) As SqlClient.SqlParameter
        SQLParam(0) = New SqlClient.SqlParameter("@OrderID", SqlDbType.BigInt)
        SQLParam(0).Value = OrderID
        SQLParam(1) = New SqlClient.SqlParameter("@ExpiryDate", SqlDbType.DateTime)
        SQLParam(1).Direction = ParameterDirection.Output

        SqlHelper.ExecuteNonQuery(CurrencyDBCustomerID, CommandType.StoredProcedure, "RSS_GetOrderExpiryDate", SQLParam)

        '---Fix for few months----Start
        Dim FixCurrencyDBBug As String = System.Configuration.ConfigurationSettings.AppSettings("FixCurrencyDBBug")
        If IsDBNull(SQLParam(1).Value) AndAlso FixCurrencyDBBug = "1" Then
            SqlHelper.ExecuteNonQuery(2, CommandType.StoredProcedure, "RSS_GetOrderExpiryDate", SQLParam)
        End If
        '---Fix for few months----End
        ExpiryDate = SQLParam(1).Value

        Return ExpiryDate
    End Function

    Private Function SelectCustomers(ByVal intCustomerID As String) As DataSet
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        sqlParam(0) = New SqlClient.SqlParameter("@intCustomerID", SqlDbType.VarChar, 10)
        sqlParam(0).Value = intCustomerID
        Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.ADMIN_SelectCustomers", sqlParam)
        Return ds
    End Function

    Private Function Serviceinfo(ByVal PackageCode As String) As DataSet
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParam(0) = New SqlClient.SqlParameter("@PackageCode", SqlDbType.VarChar, 10)
        sqlParam(0).Value = PackageCode

        Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.Admin_serviceInfo", sqlParam)
        Return ds
    End Function

    Private Sub WriteDebugInfo(ByVal sText As String, ByVal LogPath As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(LogPath)
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub
End Class
