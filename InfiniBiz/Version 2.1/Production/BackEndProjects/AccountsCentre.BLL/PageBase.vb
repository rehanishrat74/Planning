Imports System
Imports System.Web
Imports System.Text
Imports System.Globalization
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.webControls
Imports System.Web.UI.UserControl
Imports System.Web.HttpContext
Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Microsoft.Toolkits.EnterpriseLocalization
Imports System.io

'imports InfiniLogic.AccountsCentre.

'----------------------------------------------------------------
' Namespace: InfiniPayroll.Web
' Class: PageBase
'
' Description: 
'   Base class for all ASP+ pages in the Accounts Centre web application.
'   The code-behind base class for all aspx pages.
'   Provides html span controls (ErrorSpan, InfoSpan) and properties(EmployerID, ErrorMessage, InfoMessage ).
'----------------------------------------------------------------

Public Class PageBase
    'Inherits System.Web.UI.Page
    Inherits LocalizedPage ' FOR LOCALIZATION

    'Protected Shared _arrServiceNames As ArrayList

    Protected _blnIsCustomer As Boolean
    Protected Const ACC_COMPANY_PAGE_REDIRECT As String = "Acc_Company_Page_Redirect"
    Public Const ACC_ORDER_HERE_LINK As String = "Acc_Order_Here_Link"
    Public Const ACC_ORDER_HERE_COMPAIGN As String = "Acc_Order_Here_Compaign"

    Protected REDIRECTING_QS_VARIABLE As String = "req"
    'Html span for displaying error messages
    Protected ErrorSpan As HtmlGenericControl

    'Html span for displaying information messages
    Protected InfoSpan As HtmlGenericControl

    'ConnectionData to maintain connection String 
    Private _connectionData As New ConnectionData

    ' Service Name 
    Private Const _serviceName As String = "AccountsCentre"

    '    Public Shared ReadOnly SignInAttemptFailed As String = ACCMessage.Account_SignInAttemptFailed
    Public ReadOnly SignInAttemptFailed As String = ACCMessage.Account_SignInAttemptFailed
    Public Shared ReadOnly ACC_SessionID As String = "ACC_SessionID"
    Public Shared ReadOnly ACC_USERS_SIGN_IN As String = "ACC_SignedIn_Users"
    Public Shared isEmployee As Boolean = False
    Public Shared merchantEmployeeID As String = String.Empty

    '********************************************************************************
    'updated by Muhammad Furqan Khan on 24-JUL-2007
    'this session variable is used in header, footer and bottom bar to identify
    'that the page is opened inside InfiniOffice and they should not be visible.
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow

    Public Const Session_InsideIO As String = "Session_InsideIO"
    Public Const Session_CompanyStatus As String = "Session_CompanyStatus"
    Public Const Session_Gateway As String = "Session_Gateway"
    Public Const Session_UserCode As String = "Session_UserCode"
    Public Const Session_Password As String = "Session_Password"
    Public Const Session_CTRPINCode As String = "Session_CTRPINCode"
    Public Const Session_PAYEPINCode As String = "Session_PAYEPINCode"
    Public Const Session_UserEmail As String = "Session_UserEmail"


    'Cause specified text to be displayed as an error message on the page

    Protected Sub CheckService(ByVal ID As ServiceID)

        CheckServiceStatus(ID)

        Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
        sqlparam(0) = New SqlParameter("@ID", ID)
        Dim dr As SqlClient.SqlDataReader
        Dim Status As Boolean

        Try
            dr = SqlHelper.ExecuteReader(SqlHelper.EstablishAdminConnection(), CommandType.StoredProcedure, "[DBGATEWAY].[DBO].[ACC_CheckServiceStatus]", sqlparam)
            dr.Read()
            Status = Integer.Parse(dr.Item("Status"))
        Finally
            If Not dr.IsClosed Then dr.Close()
            If Not dr Is Nothing Then dr = Nothing
        End Try

        If Not Status AndAlso ACC_ServiceOptions.EnabledForCustomers Then Response.Redirect("/Common/ServiceError.aspx")
    End Sub

    Protected Property ErrorMessage() As String
        Get
            HttpContext.Current.Trace.Write("ErrorSpan.InnerHtml = " & ErrorSpan.InnerHtml)
            ErrorMessage = ErrorSpan.InnerHtml
        End Get
        Set(ByVal Value As String)
            Dim _stringBuilder As New StringBuilder(Value)
            _stringBuilder.Replace("\r\n", "<br>")
            HttpContext.Current.Trace.Write("_stringBuilder.ToString = " & _stringBuilder.ToString)
            HttpContext.Current.Trace.Write("ErrorSpan Is Nothing = " & Convert.ToString(ErrorSpan Is Nothing))
            HttpContext.Current.Trace.Write("ErrorSpan.InnerHtml = " & ErrorSpan.InnerHtml)
            ErrorSpan.InnerHtml = _stringBuilder.ToString
        End Set
    End Property

    'Cause specified text to be displayed as informative message on the page
    Protected Property InfoMessage() As String
        Get
            InfoMessage = InfoSpan.InnerHtml
        End Get
        Set(ByVal Value As String)
            InfoSpan.InnerHtml = Value
        End Set
    End Property

    'Provide Customer ID persistence during session
    Public ReadOnly Property CustomerID() As Int32
        Get
            Return Int32.Parse(User.Identity.Name)
        End Get
    End Property

    ' Provide true/false value whether employer has registered itself or not.
    Protected Property IsCustomer() As Boolean
        Get
            Return _blnIsCustomer
        End Get
        Set(ByVal Value As Boolean)
            _blnIsCustomer = Value
        End Set
    End Property

    'Protected Function SetServicesName(ByRef services As ArrayList)
    '    _arrServiceNames = services
    'End Function

    'Protected Function GetServicesName() As ArrayList
    '    Return _arrServiceNames
    'End Function

    Protected ReadOnly Property DatabaseName() As String
        Get
            Return Request.Cookies("DatabaseName").Value
        End Get
    End Property

    Protected ReadOnly Property DataSource() As String
        Get
            Return Request.Cookies("DataSource").Value
        End Get
    End Property

    Protected ReadOnly Property ServiceName() As String
        Get
            Return _serviceName
        End Get
    End Property

    Protected ReadOnly Property ConnectionData() As ConnectionData
        Get
            _connectionData.DatabaseName = DatabaseName
            _connectionData.DataSource = DataSource
            Return _connectionData
        End Get
    End Property

    Protected ReadOnly Property CustomerName() As String
        Get
            Return Request.Cookies("CustomerName").Value
        End Get
    End Property

    Protected ReadOnly Property IsServiceAllowed(ByVal SName As String) As Boolean

        Get
            Try
                'Dim servicesAllowed As ArrayList = ServicesManager.GetServicesAllowed(CustomerID)0
                Dim servicesAllowed As ArrayList = Session("Services")
                If servicesAllowed.Contains(SName) Then
                    Return True
                Else
                    Return False
                End If
            Catch ee As Exception
                Return False
            End Try
        End Get
    End Property

    Public ReadOnly Property IsServiceExpired(ByVal SName As String) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAlreadyExpired"), Hashtable)
            Return servicesExpired.ContainsValue(SName)
        End Get
    End Property

    Public ReadOnly Property IsServiceExpired(ByVal ID As Integer) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAlreadyExpired"), Hashtable)
            Return servicesExpired.ContainsKey(ID)
        End Get
    End Property

    Public ReadOnly Property IsServiceAboutToExpire(ByVal SName As String) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAboutToExpire"), Hashtable)
            Return servicesExpired.ContainsValue(SName)
        End Get
    End Property

    Public ReadOnly Property IsServiceAboutToExpire(ByVal ID As Integer) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAboutToExpire"), Hashtable)
            Return servicesExpired.ContainsKey(ID)
        End Get
    End Property

    Protected Shared Sub CheckRedirection()

        With HttpContext.Current
            If Not IsNothing(.Session(ACC_COMPANY_PAGE_REDIRECT)) Then

                Dim RedirectUrl As String = .Session(ACC_COMPANY_PAGE_REDIRECT)
                .Trace.Write(Now & "After getting Session value Redirection::::RedirectURL=" & RedirectUrl)

                If Not RedirectUrl.StartsWith("https://") Then
                    .Trace.Write(Now & "RedirectUrl.StartsWith https:// ::::RedirectURL=" & RedirectUrl)
                    If RedirectUrl.StartsWith("http://") Then
                        RedirectUrl = RedirectUrl.Replace("http://", "https://")
                        .Trace.Write(Now & "RedirectUr is replaced by https:// ::::RedirectURL=" & RedirectUrl)
                    Else
                        .Trace.Write(Now & "before https insertion ::::RedirectURL=" & RedirectUrl)
                        RedirectUrl = RedirectUrl.Insert(0, "https://")
                        .Trace.Write(Now & "RedirectUrl has https:// as prefix ::::RedirectURL=" & RedirectUrl)
                    End If

                End If

                .Session(ACC_COMPANY_PAGE_REDIRECT) = Nothing
                .Trace.Write(Now & "Before Redirection::::RedirectURL=" & RedirectUrl)
                .Response.Redirect(RedirectUrl)
            End If


        End With
    End Sub

    Private Shared Sub RedirectToCompanyInfoPage()
        HttpContext.Current.Trace.Write("redirecting to Employer page")
        HttpContext.Current.Response.Redirect("/members/profile.aspx")
    End Sub

    Public Shared Sub RedirectToEmployerPage(Optional ByVal RedirectOpt As RedirectionOptions = RedirectionOptions.DefaultRedirection, Optional ByVal strPath As String = "")
        With HttpContext.Current
            Select Case RedirectOpt
                Case RedirectionOptions.CustomRedirection
                    .Session(ACC_COMPANY_PAGE_REDIRECT) = strPath
                Case RedirectionOptions.RedirectBack
                    .Session(ACC_COMPANY_PAGE_REDIRECT) = .Request.Url.AbsoluteUri
            End Select
        End With
        RedirectToCompanyInfoPage()
    End Sub

    Public Sub RedirectTo(ByVal direction As ACC_Redirection, Optional ByVal strQueryString As String = "")
        Dim strRedirectionPage As String
        Select Case direction
            Case ACC_Redirection.HOMEPAGE

                strRedirectionPage = CommonBase.Resources(ACC_Resource.ACC_Home)
                'Added by Afaq Ali on 5-dec-2005 for Common Login
            Case ACC_Redirection.SIGNIN

                strRedirectionPage = CommonBase.Resources(ACC_Resource.ACC_SIGNIN)
            Case ACC_Redirection.SIGNOUT

                strRedirectionPage = CommonBase.Resources(ACC_Resource.ACC_SIGNOUT)
            Case ACC_Redirection.GlobalView

                strRedirectionPage = "https://" & Request.Url.Host & "/globalview/globalview.aspx" 'CommonBase.Resources(ACC_Resource.ACC_GLOBALVIEW)

        End Select

        'If strQueryString <> "" Then strRedirectionPage &= strQueryString

        Response.Redirect(strRedirectionPage)
    End Sub


    Private Sub CheckServiceStatus(ByVal ID As ServiceID)
        If IsServiceExpired(ID) Then
            Response.Redirect("https://www.accountscentre.com/globalview/subscription.aspx")
        End If
    End Sub

    Protected Function GetServerName() As String
        Return Request.ServerVariables("SERVER_NAME")
    End Function

    Public Function VerifyUserCredentials(ByVal strUserID As String, ByVal strPassword As String, ByRef iRetCustomerID As Integer) As Boolean
        Dim _strDatabaseName As String = String.Empty
        Dim _strDataSource As String = String.Empty

        Dim objCryptography As New Cryptography
        Dim objUser As New User

        Dim blnMsg As Boolean

        Dim Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
        Dim CustomerID As Int32 'Unique ID for employer
        Dim strGKeyLen As Integer = 1024
        Dim intReturnValue, intReturnValue1 As Int16

        ErrorMessage = String.Empty
        CustomerID = 0
        strLogKey = String.Empty
        strDatabaseName = String.Empty
        intReturnValue = 0
        intReturnValue1 = 0

        'Verify the user credentials and get the customer ID and Database names.
        Dim b As Boolean

        objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
        strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)

        If intReturnValue = 0 Or strPassword.ToString <> strDecryptPassword.ToString Then
            ErrorMessage = SignInAttemptFailed
            Return False
        Else
            iRetCustomerID = CustomerID
            Return True
        End If
    End Function

    Public Sub PrepareParentGlobalView(ByVal CustomerID As Object)
        '  Response.Redirect("https://www.accountscentre.com/accountspro/default.aspx")
        Dim objGlobalView As New GlobalView

        If Session("ACC_GV_ParentCustomerID") = Nothing Then
            'Parent is being login....
            Session("ACC_GV_ParentCustomerID") = CustomerID

            'Added this cookie, so that on having finsihed the time out of session we may use it
            'for re-sign in process.
            Response.Cookies.Add(New HttpCookie("ACC_GV_ParentUserUID", Session("UserUID")))

            Session("ACC_GV_ParentUserUID") = Session("UserUID")
            Dim bRetFormationsHouseProblem As Boolean
            Session("ACC_GV_Companies") = objGlobalView.getAllCompanies(CustomerID, Session("UserUID"), bRetFormationsHouseProblem)
            'To update Inc date and ARDs.......
            Dim dtCompanies As DataTable = objGlobalView.getAllCompaniesByFH(Session("ACC_GV_ParentCustomerID"), Session("ACC_GV_Companies"), False)
            If IsNothing(dtCompanies) = False Then
                dtCompanies.Clear() : dtCompanies.Dispose() : dtCompanies = Nothing
            End If
            'To update Inc date and ARDs.......
            Session("ACC_GV_FormationsHouseAvailable") = Not bRetFormationsHouseProblem
            Dim sqlDR As SqlDataReader
            sqlDR = objGlobalView.GetUserInformation(CustomerID)

            If sqlDR.Read() Then
                Session("ACC_GV_RegCompCount") = sqlDR("TotalRegComp")
                Session("ACC_GV_ExcCompCount") = sqlDR("TotalExcComp")
            Else
                Session("ACC_GV_RegCompCount") = 0
                Session("ACC_GV_ExcCompCount") = 0
            End If

            If Not sqlDR Is Nothing Then
                sqlDR.Close()
                sqlDR = Nothing
            End If
        End If
    End Sub

    Private Sub RedirectAppropriately(ByVal CustomerID As Int32, ByVal bSilentMode As Boolean)
        Dim _accountsCentreDotCom As String = "https://" & Request.Url.Host
        'ACCOUNTS CENTRE USER
        If Session(ACC_ORDER_HERE_LINK) <> "" Then Exit Sub 'Response.Redirect("https://www.accountscentre.com/members/ServiceRegistration.aspx")
        If Left(Trim(UCase(FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))), 9) = "/DEFAULT." Then
            If IsAnyServiceExpiredOrAboutToExpired = True Then
                If isEmployee Then
                    'Response.Redirect(_accountsCentreDotCom & "/AccountsPro/default.aspx")
                    Response.Redirect(_accountsCentreDotCom & "/globalview/globalview.aspx")
                Else
                    Response.Redirect(_accountsCentreDotCom & "/globalview/subscription.aspx")

                End If
            Else
                If bSilentMode = False Then
                    'Response.Redirect(_accountsCentreDotCom & "/globalview/globalview.aspx")
                    If isEmployee Then
                        'Response.Redirect(_accountsCentreDotCom & "/AccountsPro/default.aspx")  'Response.Redirect("") 'Accounts_Pro
                        Response.Redirect(_accountsCentreDotCom & "/globalview/globalview.aspx")
                    Else
                        RedirectTo(ACC_Redirection.GlobalView)
                    End If

                Else
                    'RedirectTo("---for internal login---------members/default.aspx--------------")
                    If Not isEmployee Then
                        Response.Redirect(_accountsCentreDotCom & "/members/default.aspx")

                    Else
                        'Response.Redirect(_accountsCentreDotCom & "/AccountsPro/default.aspx")
                        Response.Redirect(_accountsCentreDotCom & "/globalview/globalview.aspx")
                    End If
                End If
            End If
        Else
            'Get the redirect url
            Dim RedirectURL As String = FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False)
            Dim sServiceName As String = GetServiceName(RedirectURL)

            If IsServiceAboutToExpire(sServiceName) Or IsServiceExpired(sServiceName) Then
                If isEmployee Then
                    ' related to employee service which is not declared yet
                Else
                    'Response.Redirect(_accountsCentreDotCom & "/globalview/subscription.aspx?ourl=" & RedirectURL)
                    Response.Redirect("https://" & Request.Url.Host & "/globalview/subscription.aspx?ourl=" & RedirectURL)
                End If
            Else
                If isEmployee Then
                    ' related to employee service which is not declared yet
                Else
                    'Response.Redirect(_accountsCentreDotCom & RedirectURL)
                    Response.Redirect("https://" & Request.Url.Host & RedirectURL)
                End If
            End If
        End If
    End Sub

    REM SR
    Public Function GetUserPassword(ByVal strUserID As String) As String
        Dim _strDatabaseName As String = String.Empty
        Dim _strDataSource As String = String.Empty

        Dim objCryptography As New Cryptography
        Dim objUser As New User

        Dim blnMsg As Boolean

        Dim Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
        Dim CustomerID As Int32 'Unique ID for employer
        Dim strGKeyLen As Integer = 1024
        Dim intReturnValue, intReturnValue1 As Int16

        'ErrorMessage = String.Empty
        CustomerID = 0
        strLogKey = String.Empty
        strDatabaseName = String.Empty
        intReturnValue = 0
        intReturnValue1 = 0

        'Verify the user credentials and get the customer ID and Database names.
        Dim b As Boolean

        objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
        strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)
        Return strDecryptPassword
    End Function
    REM SR

    Private Function GetServiceName(ByVal sURL As String) As String
        If Len(sURL) > 0 Then
            Dim sServiceName As String
            Dim iSlashPos As Integer
            sServiceName = sURL.Substring(1)
            iSlashPos = InStr(sServiceName, "/")
            If iSlashPos > 0 Then
                sServiceName = Left(sServiceName, iSlashPos - 1)
                'Return (SubscriptionStatus.GetProperServiceMapping(sServiceName))
            End If
        End If
        Return String.Empty
    End Function


    'Private Sub httpcontext.Current.Trace.Write(ByVal sText As String)
    '    'If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
    '    '    System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
    '    'End If
    '    'Dim sw As System.IO.StreamWriter
    '    'sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\PageBase.vb Trace.txt")
    '    'sw.WriteLine(Now & " -- " & sText)
    '    'sw.Close()
    'End Sub

    Public Function SignInAccountsCentreUSer(ByVal strUserID As String, ByVal strPassword As String, Optional ByVal bSilentMode As Boolean = False, Optional ByVal bDoNotRedirect As Boolean = False) As String
        HttpContext.Current.Trace.Write("In SignInAccountsCentreUSer")
        Dim _strDatabaseName As String = String.Empty
        Dim _strDataSource As String = String.Empty
        Dim objCryptography As New Cryptography
        Dim objUser As New User
        Dim blnMsg As Boolean
        Dim Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
        'Muhammad Ubaid
        Dim CustomerID As Object 'Int32 'Unique ID for employer
        '***************************
        Dim strGKeyLen As Integer = 1024
        Dim intReturnValue, intReturnValue1 As Int16
        HttpContext.Current.Trace.Write("ErrorMessage = String.Empty")
        'ErrorMessage = String.Empty
        HttpContext.Current.Trace.Write("OK!")
        CustomerID = 0
        strLogKey = String.Empty
        strDatabaseName = String.Empty
        intReturnValue = 0
        intReturnValue1 = 0

        'Verify the user credentials and get the customer ID and Database names.
        Dim b As Boolean
        HttpContext.Current.Trace.Write("Calling VerifySignIn")
        objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
        HttpContext.Current.Trace.Write("VerifySignIn is ok intReturnValue=" & intReturnValue)

        'objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, _strDataSource, b)
        ' objFile.WriteLine("strUserID = " + strUserID + " Password= " + Password + " CustomerID = " + CustomerID + " strLogKey = " + strLogKey + " intReturnValue = " + intReturnValue + " _strDatabaseName = " + _strDatabaseName + " b = " + b)
        REM SR 14 Jan 2005 'Code:GlobalView'
        'RxstrDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)
        If bSilentMode = False Then
            HttpContext.Current.Trace.Write("Calling DeCrypt")
            strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)
            HttpContext.Current.Trace.Write("DeCrypt is ok strDecryptPassword=" & strDecryptPassword)
            '       objFile.WriteLine("strDecryptPassword = " + strDecryptPassword)

        Else
            HttpContext.Current.Trace.Write("strDecryptPassword = """" ")
            strDecryptPassword = ""
        End If
        REM SR 14 Jan 2005 

        HttpContext.Current.Trace.Write("intReturnValue = " & intReturnValue)
        If intReturnValue = 0 Then
            HttpContext.Current.Trace.Write("SignInAttemptFailed")
            ErrorMessage = SignInAttemptFailed
            '      objFile.WriteLine("ErrorMessage" + ErrorMessage)
            '     objFile.Close()
        Else
            REM SR 14 Jan 2005 'Code:GlobalView'
            'RxIf strPassword.ToString = strDecryptPassword.ToString Then
            HttpContext.Current.Trace.Write("Checking Condition bSilentMode=" & bSilentMode)
            If strPassword.ToString = strDecryptPassword.ToString Or bSilentMode = True Then
                HttpContext.Current.Trace.Write("if bSilentMode = True then")
                ' Customer specific info related to Message board.
                Dim oReader As Collection
                Dim objCustomer As New User
                Dim ds As DataSet
                Dim strEmailCustomer As String

                REM SR CR_00001
                HttpContext.Current.Trace.Write("CompanyStatus.NotUKBased")
                Dim CompStatus As CompanyStatus = CompanyStatus.NotUKBased
                Dim IsGatewayRegistered As Boolean = False
                Dim sUserCode, sPassword, sPAYEPinCode As String, sCTRPINCode As String
                HttpContext.Current.Trace.Write("Calling GetCustomerData")
                ds = objCustomer.GetCustomerData(CustomerID)
                HttpContext.Current.Trace.Write("GetCustomerData is ok")
                REM SR CR_00001

                If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
                    ' set the result of data row
                    Dim dt1 As DataTable = ds.Tables(0)
                    Dim dr1 As DataRow = dt1.Rows(0)

                    If Not IsDBNull(dr1.Item(7)) Then
                        strEmailCustomer = dr1.Item(7)

                    Else
                        strEmailCustomer = String.Empty
                    End If

                    REM SR CR_00001
                    CompStatus = dr1.Item("CompStatus")
                    HttpContext.Current.Trace.Write("CompStatus=" & CompStatus)

                    IsGatewayRegistered = (dr1.Item("Gateway") = "Y")
                    HttpContext.Current.Trace.Write("IsGatewayRegistered =" & IsGatewayRegistered)

                    sUserCode = dr1.Item("Usercode")
                    HttpContext.Current.Trace.Write("sUserCode =" & sUserCode)

                    sPassword = dr1.Item("Password")
                    HttpContext.Current.Trace.Write("sPassword =" & sPassword)

                    sPAYEPinCode = dr1.Item("PAYEPinCode")
                    HttpContext.Current.Trace.Write("sPAYEPinCode =" & sPAYEPinCode)

                    sCTRPINCode = dr1.Item("CTRPINCode")
                    HttpContext.Current.Trace.Write("sCTRPINCode =" & sCTRPINCode)
                    REM SR CR_00001
                End If

                REM SR [Company updation]
                Try
                    Dim oCP As New CustomerProfile
                    If CompStatus = CompanyStatus.BothCompaniesHouseAndFormationsHouse Then
                        HttpContext.Current.Trace.Write("UpdateFHCustomerDataToAC")
                        oCP.UpdateFHCustomerDataToAC(CustomerID)
                        HttpContext.Current.Trace.Write("ok")
                    End If
                    oCP = Nothing
                Catch
                    Trace.Write("Calling Exception in FMH webservice")

                End Try
                REM SR
                HttpContext.Current.Trace.Write("Calling LoadAccountscetreUser")
                oReader = objUser.LoadAccountscetreUser(CustomerID)
                HttpContext.Current.Trace.Write("LoadAccountscetreUser is ok")
                REM SR CR_00001
                Session(PageBase.Session_CompanyStatus) = CompStatus
                Session(PageBase.Session_Gateway) = IsGatewayRegistered
                Session(PageBase.Session_UserCode) = sUserCode
                Session(PageBase.Session_Password) = sPassword
                Session(PageBase.Session_CTRPINCode) = sCTRPINCode
                Session(PageBase.Session_PAYEPINCode) = sPAYEPinCode
                REM SR CR_00001

                Session("UserUID") = strUserID
                If IsDBNull(oReader.Item("email")) Or strEmailCustomer = String.Empty Then
                    Session(PageBase.Session_UserEmail) = String.Empty
                Else
                    Session(PageBase.Session_UserEmail) = oReader.Item("email")
                End If
                HttpContext.Current.Trace.Write("MSGPERPAGE")
                Session("MSGPERPAGE") = oReader.Item("msgperpage")
                HttpContext.Current.Trace.Write("CustomerName")
                Session("CustomerName") = oReader.Item("name")

                ' Save minimal state info and redirect to the page.
                ' Response.Cookies.Add(New HttpCookie("CustomerName", oReader.Item("name")))
                If IsDBNull(oReader.Item("name")) Then
                    Response.Cookies.Add(New HttpCookie("CustomerName", " "))
                Else
                    Response.Cookies.Add(New HttpCookie("CustomerName", oReader.Item("name")))
                End If
                Response.Cookies.Add(New HttpCookie("DatabaseName", _strDatabaseName))
                Response.Cookies.Add(New HttpCookie("DataSource", _strDataSource))
                '/.................................Rem SR                
                FillExpiryRelatedSessionVariables(CustomerID)
                '................................./
                ' Check the customer services and activate them
                'DoServices(CustomerID)
                HttpContext.Current.Trace.Write("Calling GetServicesAllowed")
                Dim cServices As ArrayList = AccountsCentre.BLL.ServicesManager.GetServicesAllowed(CustomerID)
                HttpContext.Current.Trace.Write("GetServicesAllowed is ok")
                Session("Services") = cServices
                FormsAuthentication.SetAuthCookie(CustomerID.ToString, False)

                'Response.Write("Url=" & FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))
                'Response.End()

                REM SR GlobalView
                HttpContext.Current.Trace.Write("Calling PrepareParentGlobalView")
                PrepareParentGlobalView(CustomerID)
                HttpContext.Current.Trace.Write("PrepareParentGlobalView is ok")


                HttpContext.Current.Trace.Write("bDoNotRedirect = " & bDoNotRedirect)
                If bDoNotRedirect = False Then RedirectAppropriately(CustomerID, bSilentMode)
                REM SR GlobalView
            Else
                HttpContext.Current.Trace.Write("SignInAttemptFailed=" & SignInAttemptFailed)
                ErrorMessage = SignInAttemptFailed
            End If
        End If

        HttpContext.Current.Trace.Write("SignInAccountsCentreUSer END")
    End Function

    Protected ReadOnly Property ParentUserID() As String
        Get
            Return Request.Cookies("ACC_GV_ParentUserUID").Value
        End Get
    End Property

    Public Function SignOutDestroy()
        Session("IsEmployerRegistered") = Nothing
        Session.Abandon()
        FormsAuthentication.SignOut() 'Clear the current user session.
    End Function

    Protected ReadOnly Property IsAnyServiceExpiredOrAboutToExpired() As Boolean
        Get
            Dim bResult As Boolean
            Dim servicesExpired As Hashtable = CType(Session("ServicesAlreadyExpired"), Hashtable)
            Dim servicesAboutToExpire As Hashtable = CType(Session("ServicesAboutToExpire"), Hashtable)

            bResult = (servicesAboutToExpire.Count > 0) Or (servicesExpired.Count > 0)

            Return bResult
        End Get
    End Property

    REM SR
    Protected Sub FillExpiryRelatedSessionVariables(ByVal CustomerID As Integer)
        Dim objSubscriptionStatus As New SubscriptionStatus
        Dim HtServicesAboutToExpire As Hashtable
        Dim HtServicesAlreadyExpired As Hashtable



        'Keep the customer services that are about to expire
        HtServicesAboutToExpire = objSubscriptionStatus.getServicesHashTableByStatus(SubscriptionStatus.CustSrvStatusBehavior.Last3MonthsPeriod, CustomerID)
        Session("ServicesAboutToExpire") = HtServicesAboutToExpire

        'Keep the customer services that are already expired
        HtServicesAlreadyExpired = objSubscriptionStatus.getServicesHashTableByStatus(SubscriptionStatus.CustSrvStatusBehavior.OverDueDate, CustomerID)
        Session("ServicesAlreadyExpired") = HtServicesAlreadyExpired

        objSubscriptionStatus = Nothing
    End Sub
    REM SR

    Private Sub ClearSessionVariables()
        Session("ACC_GV_Companies") = Nothing

        Session("ACC_GV_ParentCustomerID") = Nothing
        Session("ACC_GV_ParentUserUID") = Nothing

        Session("ACC_GV_RegCompCount") = Nothing
        Session("ACC_GV_ExcCompCount") = Nothing

        Session("ACC_GV_LastAddedCompName") = Nothing
        Session("ACC_GV_FormationsHouseAvailable") = Nothing

        Session("ACC_GV_RegistrationMode") = Nothing

        '*********************************************************************************************
        'It's Add by Muhammad Ubaid To make difference between AccountsCentre and Accounts.InfiniBiz
        '*********************************************************************************************
        Session("ACC_Application_Path") = Nothing
        '*********************************************************************************************

    End Sub

    Public Shared Function GetImage(ByVal svrName As ServiceID) As String
        Dim strImagePath As String = "http://" & HttpContext.Current.Request.Url.Host

        Return strImagePath & Switch(svrName = ServiceID.AccountManagement, "/infiniimages/logoCam.jpg", _
                       svrName = ServiceID.AccountsPro, "/infiniimages/LogoAccounts-pro.jpg", _
                       svrName = ServiceID.CTReturn, "/infiniimages/logoCTReturn.jpg", _
                       svrName = ServiceID.DormantAccount, "/infiniimages/Logo-DCA.jpg", _
                       svrName = ServiceID.Express, "/infiniimages/logoExpress.jpg", _
                       svrName = ServiceID.InfiniShops, "", _
                       svrName = ServiceID.Payroll, "/infiniimages/logo-Payroll.jpg", _
                       svrName = ServiceID.SAccounts, "/infiniimages/LogoAnnual.jpg", _
                       svrName = ServiceID.AccountsProWeb, "/images/LogoAccountsproWeb.jpg", _
                       svrName = ServiceID.InfiniBizPlan, "/images/LogoInfiniPlan.jpg")


    End Function

    Public Shared Sub RedirectToErrorPage(Optional ByVal id As ACC_Error_Messages = ACC_Error_Messages.DefaultMsg)

        Current.Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Home) & _
                            CommonBase.Resources(ACC_Resource.ACC_ERROR_PAGE) & _
                            "?id=" & id)
    End Sub

    Public Function MyPageResource(ByVal strName As String) As String

        Dim strfile, fileSegments() As String
        fileSegments = Request.Url.Segments
        'For Each Str As String In fileName
        '    Write(Str)
        'Next
        'writeEnd()
        strfile = fileSegments(fileSegments.Length - 1).Split(".")(0)
        'writeEnd(strfile)
        Dim manager As New System.Resources.ResourceManager(System.Reflection.Assembly.GetCallingAssembly.GetName(True).Name & "." & strfile, _
        System.Reflection.Assembly.GetCallingAssembly())
        Return manager.GetString(strName)
    End Function

    Public Function CheckOrderHereRow(ByVal ds As DataSet) As Boolean
        Dim result As Boolean = True

        If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then
            result = False
            For Each dt As DataTable In ds.Tables

                For Each dtRow As DataRow In dt.Rows
                    If dtRow.Item("ProductCode") <> Session(Me.ACC_ORDER_HERE_LINK) Then
                        dtRow.Delete()
                    Else
                        result = True
                    End If
                Next
                dt.AcceptChanges()
            Next

        End If

        Return result
    End Function

    Public Sub SetOrderHereCheck(ByVal chkBox As HtmlInputCheckBox, ByVal e As DataGridItemEventArgs)

        If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then
            chkBox.Checked = (e.Item.DataItem("Productcode") = Session(Me.ACC_ORDER_HERE_LINK))
            If chkBox.Checked Then chkBox.Visible = False

        End If

    End Sub

    Public Sub DownloadFile(ByVal CompleteFileName As String)
        Dim iStream As System.IO.Stream

        ' Buffer to read 10K bytes in chunk:
        Dim iFileDownloadLength As Integer = 100000

        Dim buffer(iFileDownloadLength) As Byte

        ' Length of the file:
        Dim length As Integer

        ' Total bytes to read:
        Dim dataToRead As Long

        ' Identify the file to download including its path.
        Dim filepath As String = CompleteFileName

        ' Identify the file name.
        Dim filename As String = System.IO.Path.GetFileName(filepath)

        Try
            ' Open the file.
            iStream = New System.IO.FileStream(filepath, System.IO.FileMode.Open, _
                                                   IO.FileAccess.Read, IO.FileShare.Read)

            ' Total bytes to read:
            dataToRead = iStream.Length
            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & filename)
            Response.AddHeader("Content-Length", dataToRead)
            'Response.Write(dataToRead & "#")  not working
            ' Read the bytes.
            While dataToRead > 0
                ' Verify that the client is connected.
                If Response.IsClientConnected Then
                    ' Read the data in buffer
                    length = iStream.Read(buffer, 0, iFileDownloadLength)

                    ' Write the data to the current output stream.
                    Response.OutputStream.Write(buffer, 0, length)

                    ' Flush the data to the HTML output.
                    Response.Flush()

                    ReDim buffer(iFileDownloadLength) ' Clear the buffer
                    dataToRead = dataToRead - length
                Else
                    'prevent infinite loop if user disconnects
                    dataToRead = -1
                End If
            End While
            Response.End()
        Finally
            If IsNothing(iStream) = False Then
                ' Close the file.
                iStream.Close()
            End If
        End Try
    End Sub

    REM SR CR_00001
    'Provide Company Status Information
    Protected Property UKCompanyStatus() As CompanyStatus
        Set(ByVal Value As CompanyStatus)
            Session(PageBase.Session_CompanyStatus) = Value
        End Set
        Get
            If Session(PageBase.Session_CompanyStatus) = Nothing Then Session(PageBase.Session_CompanyStatus) = CompanyStatus.NotUKBased
            Return CType(Session(PageBase.Session_CompanyStatus), CompanyStatus)
        End Get
    End Property
    Protected Property IsGatewayRegistered() As Boolean
        Set(ByVal Value As Boolean)
            Session(PageBase.Session_Gateway) = Value
        End Set
        Get
            If Session(PageBase.Session_Gateway) = Nothing Then Session(PageBase.Session_Gateway) = False
            Return CType(Session(PageBase.Session_Gateway), Boolean)
        End Get
    End Property
    Protected Property GatewayUserCode() As String
        Get
            If Session(PageBase.Session_UserCode) = Nothing Then Session(PageBase.Session_UserCode) = ""
            Return CType(Session(PageBase.Session_UserCode), String)
        End Get
        Set(ByVal Value As String)
            Session(PageBase.Session_UserCode) = Value
        End Set
    End Property
    Protected Property GatewayPassword() As String
        Get
            If Session(PageBase.Session_Password) = Nothing Then Session(PageBase.Session_Password) = ""
            Return CType(Session(PageBase.Session_Password), String)
        End Get
        Set(ByVal Value As String)
            Session(PageBase.Session_Password) = ""
        End Set
    End Property
    Protected Property GatewayCTRPINCode() As String
        Get
            If Session(PageBase.Session_CTRPINCode) = Nothing Then Session(PageBase.Session_CTRPINCode) = ""
            Return CType(Session(PageBase.Session_CTRPINCode), String)
        End Get
        Set(ByVal Value As String)
            Session(PageBase.Session_CTRPINCode) = Value
        End Set
    End Property
    Protected Property GatewayPAYEPINCode() As String
        Get
            If Session(PageBase.Session_PAYEPINCode) = Nothing Then Session(PageBase.Session_PAYEPINCode) = ""
            Return CType(Session(PageBase.Session_PAYEPINCode), String)
        End Get
        Set(ByVal Value As String)
            Session(PageBase.Session_PAYEPINCode) = Value
        End Set
    End Property


    Public Shared Sub BindCountry(ByVal drp As DropDownList, Optional ByVal SelectCountry As String = "")
        If SelectCountry = "" Then SelectCountry = CommonBase.Resources(ACC_Resource.DefaultCountry)
        With drp
            .DataSource = BLL.User.GetCountryName
            .DataTextField = "Name"
            .DataValueField = "Code"
            .DataBind()

            Dim lstitem As ListItem = .Items.FindByText(SelectCountry)
            lstitem.Selected = True
        End With
    End Sub
    REM SR CR_00001


    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If Not IsNothing(Session(Session_InsideIO)) AndAlso Session(Session_InsideIO) = True Then
            If Not trTopMain Is Nothing Then
                trTopMain.Visible = False
                trTopMain.EnableViewState = False
            End If
            If Not tdLeftMain Is Nothing Then
                tdLeftMain.Visible = False
                tdLeftMain.EnableViewState = False
            End If
            If Not trBottomMain Is Nothing Then
                trBottomMain.Visible = False
                trBottomMain.EnableViewState = False
            End If
        End If

        Dim URL As String

        With Request
            URL = .ServerVariables("URL").ToLower
            Dim Logoutpage As String = "http://services.infinibiz.com"

            If URL <> Logoutpage AndAlso URL <> "/common/errorpage.aspx" AndAlso User.Identity.IsAuthenticated AndAlso _
                CheckLoggedOutUser() Then
                RemoveUserFromList()
                Response.Redirect(Logoutpage)
            End If
        End With

    End Sub

    Public Function CheckLoggedOutUser() As Boolean
        Dim SessionID As String = IIf(System.Web.HttpContext.Current.Session(ACC_SessionID) Is Nothing, "", System.Web.HttpContext.Current.Session(ACC_SessionID))
        If SessionID = "" OrElse SessionID Is Nothing Then
            Return False
        Else
            Dim col As New Hashtable
            col = System.AppDomain.CurrentDomain.GetData(ACC_USERS_SIGN_IN)
            Trace.Warn("col Is Nothing" & (col Is Nothing))
            If Not col Is Nothing Then
                Return Not col.ContainsKey(SessionID)
            End If
        End If
    End Function

    Public Sub RemoveUserFromList()
        Dim col As New Hashtable
        col.Remove(Session(ACC_SessionID))
        AppDomain.CurrentDomain.SetData(ACC_USERS_SIGN_IN, col)
    End Sub

    Public Sub SetError(ByVal ParamArray strErrors As String())
        Dim strErr As New StringBuilder(25)
        With strErr

            .Append("<ul>")
            For Each Str As String In strErrors
                .Append("<li>")
                .Append(Str)
                .Append("</li>")
            Next
            .Append("</ul>")

        End With

        With ErrorSpan
            .InnerHtml = strErr.ToString
            .Disabled = False
            .Visible = True
        End With

    End Sub

    Public Sub SetInfo(ByVal ParamArray strInfo() As String)
        Dim strErr As New StringBuilder(25)
        With strErr

            .Append("<ul>")
            For Each Str As String In strInfo
                .Append("<li>")
                .Append(Str)
                .Append("</li>")
            Next
            .Append("</ul>")

        End With

        With InfoSpan
            .InnerHtml = strErr.ToString
            .Disabled = False
            .Visible = True
        End With

    End Sub


    '  Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
    '    Try
    '        Dim Ex As Exception
    '        Ex = Server.GetLastError
    '        Dim body As String
    '        Server.ClearError()

    '        body = ExceptionFormatter.Formatter.GetFormattedString(ex)

    '        Dim mail As New System.Web.Mail.MailMessage
    '        mail.To = "errors@infinibiz.com"
    '        mail.From = ConfigReader.GetItem(ConfigVariables.SMTPUserID)
    '        mail.Subject = "ERROR :: "
    '        mail.Body = body
    '        mail.BodyFormat = Web.Mail.MailFormat.Html
    '        System.Web.Mail.SmtpMail.SmtpServer = ConfigReader.GetItem(ConfigVariables.SMTPSERVER)

    '        If ConfigReader.GetItem(ConfigVariables.SMTP_Authentication) = "1" Then
    '            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
    '            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigReader.GetItem(ConfigVariables.SMTPUserID)) 'set your username here
    '            mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigReader.GetItem(ConfigVariables.SMTPPassword))  'set your password here
    '        End If
    '        System.Web.Mail.SmtpMail.Send(mail)

    '        Server.Transfer("../account/ErrorPage.aspx")
    '    Catch ex As Exception
    '        System.Web.HttpContext.Current.Trace.Warn("PageBase EXCEPTION")
    '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
    '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
    '    Finally
    '    End Try
    'End Sub
End Class

#Region ":::::::::::::::::;Enum(s)::::::::::::::::::"


Public Enum ServiceID

    Express = 1
    Payroll = 2
    CTReturn = 3
    AccountManagement = 5
    SAccounts = 7
    AccountsPro = 8
    DormantAccount = 9
    AccountsProWeb = 10
    OutsourcedAccountsDepartment = 13
    AccountsProGST = 14
    InfiniBizPlan = 15
    InfiniShops = 16
    InfiniHR = 17
    InfiniBuyer = 18
    ExpressGST = 19
    InfiniSales = 20
    AccountsProEuro = 23

End Enum


Public Enum PageProtocol
    HTTP
    HTTS
End Enum

Public Enum RegistrationMode
    ParentCustomer = 1
    MemberOfGlobalView = 2
    ExcludedFromGlobalView = 3
End Enum

Public Enum CompanyStatus
    NotUKBased = 0
    CompaniesHouseOnly = 1
    BothCompaniesHouseAndFormationsHouse = 2
End Enum

Public Enum RedirectionOptions
    DefaultRedirection
    RedirectBack
    CustomRedirection
End Enum

Public Enum ACC_Redirection
    HOMEPAGE
    SIGNIN
    SIGNOUT
    GlobalView
End Enum
#End Region