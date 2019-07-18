#Region "Imports "
Imports System
Imports System.Web
Imports System.Text
Imports System.Globalization
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.UserControl
Imports System.Web.HttpContext
Imports System.Web.Security
Imports ACC_DAL = InfiniLogic.AccountsCentre.DAL
Imports ACC_BLL = InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web.Common
Imports System.Data.SqlClient
Imports System.Resources
Imports System.Threading
#End Region

Public Class BizPlanWebBase
    Inherits ACC_BLL.PageBase 'WebFormView
    Implements IBizPlanWebBase

#Region ".................... Constant Members ............."

    Const strNullString As String = ""

    ' Service Name 
    Private Const _serviceName As String = "BusinessPlanWeb"

#End Region

#Region "....................Private Members ............."

    'ConnectionData to maintain connection String 
    Private _connectionData As New ConnectionData
    Private cult As String

    Private _currentNavigator() As String
    Private _curPage, _curItem As Integer

    ' ConfigurationData Object 
    'Dim _configuration As AppConfig

#End Region

#Region ".................... Protected Members ............."

    'Protected Shared _arrServiceNames As ArrayList
    'Protected _blnIsCustomer As Boolean

    'Public Shared ReadOnly SignInAttemptFailed As String = ACC_BLL.ACCMessage.Account_SignInAttemptFailed

    ''Html span for displaying error messages
    'Protected ErrorSpan As HtmlGenericControl

    ''Html span for displaying information messages
    'Protected InfoSpan As HtmlGenericControl

    Protected _businessPlanSummary As Infinilogic.BusinessPlan.BLL.BusinessPlan

    ' Provide Type Enumeration : can be SQLClient , AccessClient etc
    Protected _clientType As ProviderType
    Protected navController As NavigatorBase
    Protected _culture As CultureInfo
    Protected Customer As Boolean
    Protected Customercurrency As String
    Protected ProdcutServiceName As String
    Protected PagesInfo As DataTable
    Protected SalesPricePerUnit As Int32
    Protected CostPricePerUnit As Int32
    Protected Tableid As String
    Protected Row As String
#End Region

#Region " ................   IAccountsCenterBase Implementation  ............"

    ''Cause specified text to be displayed as an error message on the page

    'Protected Sub CheckService(ByVal ID As ServiceID) Implements IAccountsCentreBase.CheckService
    '    Dim sqlparam As SqlParameter() = New SqlParameter(0) {}
    '    sqlparam(0) = New SqlParameter("@ID", ID)

    '    Dim dr As SqlClient.SqlDataReader = ACC_DAL.SqlHelper.ExecuteReader(ACC_DAL.SqlHelper.EstablishConnection(), CommandType.StoredProcedure, "[DBGATEWAY].[DBO].[ACC_CheckServiceStatus]", sqlparam)
    '    dr.Read()
    '    If dr.Item("Status") = 0 Then Response.Redirect("/Common/ServiceError.aspx")
    'End Sub

    'Protected Property ErrorMessage() As String Implements IAccountsCentreBase.ErrorMeassage
    '    Get
    '        ErrorMessage = ErrorSpan.InnerHtml
    '    End Get
    '    Set(ByVal Value As String)
    '        Dim _stringBuilder As New StringBuilder(Value)
    '        _stringBuilder.Replace("\r\n", "<br>")
    '        ErrorSpan.InnerHtml = _stringBuilder.ToString
    '    End Set
    'End Property

    ''Cause specified text to be displayed as informative message on the page
    'Protected Property InfoMessage() As String Implements IAccountsCentreBase.InfoMessage
    '    Get
    '        InfoMessage = InfoSpan.InnerHtml
    '    End Get
    '    Set(ByVal Value As String)
    '        InfoSpan.InnerHtml = Value
    '    End Set
    'End Property

    ''Provide Customer ID persistence during session
    'Protected Overridable ReadOnly Property CustomerID() As Int32 Implements IAccountsCentreBase.CustomerID
    '    Get
    '        Return Int32.Parse(User.Identity.Name)  ' Int32.Parse(User.Identity.Name)
    '    End Get
    'End Property

    '' Provide true/false value whether employer has registered itself or not.
    'Protected Property IsCustomer() As Boolean Implements IAccountsCentreBase.IsCustomer
    '    Get
    '        Return _blnIsCustomer
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        _blnIsCustomer = Value
    '    End Set
    'End Property

    'Protected ReadOnly Property DatabaseName() As String Implements IAccountsCentreBase.DatabaseName
    '    Get
    '        Return "M4072"
    '        'Return Request.Cookies("DatabaseName").Value
    '    End Get
    'End Property

    'Protected ReadOnly Property DataSource() As String Implements IAccountsCentreBase.DataSource
    '    Get
    '        Return "win-furqan"
    '        'Return Request.Cookies("DataSource").Value
    '    End Get
    'End Property

    'Protected ReadOnly Property ServiceName() As String Implements IAccountsCentreBase.ServiceName
    '    Get
    '        Return _serviceName
    '    End Get
    'End Property

    ''~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    '' This method has some modification before Release
    ''~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    'Protected ReadOnly Property GetConnectionData() As ConnectionData Implements IAccountsCentreBase.GetConnectionData
    '    Get
    '        '_connectionData.DatabaseName = DatabaseName
    '        '_connectionData.DataSource = DataSource
    '        '_connectionData.ServiceName = ServiceName
    '        '_connectionData.ClientType = ProviderType.SQLClient
    '        _connectionData.DatabaseName = "M4072"
    '        _connectionData.DataSource = "win-furqan"
    '        _connectionData.ServiceName = ServiceName
    '        _connectionData.ClientType = ProviderType.SQLClient
    '        Return _connectionData
    '    End Get
    'End Property

    'Public ReadOnly Property CustomerName() As String
    '    Get
    '        Return Request.Cookies("CustomerName").Value
    '    End Get
    'End Property

    'Protected ReadOnly Property IsServiceAllowed(ByVal serviceName As String) As Boolean Implements IAccountsCentreBase.IsServiceAllowed
    '    Get
    '        Try
    '            'Dim servicesAllowed As ArrayList = ServicesManager.GetServicesAllowed(CustomerID)0
    '            Dim servicesAllowed As ArrayList = Session("Services")
    '            If servicesAllowed.Contains(serviceName) Then
    '                Return True
    '            Else
    '                Return False
    '            End If
    '        Catch ee As Exception
    '            Return False
    '        End Try
    '    End Get
    'End Property

    'Public Function SignInAccountsCentreUSer(ByVal strUserID As String, ByVal strPassword As String) As String Implements IAccountsCentreBase.SignInAccountsCentreUSer
    '    Dim _strDatabaseName As String = String.Empty
    '    Dim _strDataSource As String = String.Empty

    '    Dim objCryptography As New ACC_BLL.Cryptography
    '    Dim objUser As New ACC_BLL.User

    '    Dim blnMsg As Boolean

    '    Dim Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
    '    Dim CustomerID As Int32 'Unique ID for employer
    '    Dim strGKeyLen As Integer = 1024
    '    Dim intReturnValue, intReturnValue1 As Int16

    '    ErrorMessage = String.Empty
    '    CustomerID = 0
    '    strLogKey = String.Empty
    '    strDatabaseName = String.Empty
    '    intReturnValue = 0
    '    intReturnValue1 = 0


    '    'Verify the user credentials and get the customer ID and Database names.
    '    Dim b As Boolean

    '    objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
    '    'objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, _strDataSource, b)

    '    strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)

    '    If intReturnValue = 0 Then

    '        ErrorMessage = SignInAttemptFailed


    '    Else

    '        If strPassword.ToString = strDecryptPassword.ToString Then

    '            ' Customer specific info related to Message board.
    '            Dim oReader As Collection
    '            Dim objCustomer As New ACC_BLL.User
    '            Dim ds As DataSet
    '            Dim strEmailCustomer As String

    '            ds = objCustomer.GetCustomerData(CustomerID)

    '            If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
    '                ' set the result of data row
    '                Dim dt1 As DataTable = ds.Tables(0)
    '                Dim dr1 As DataRow = dt1.Rows(0)

    '                If Not IsDBNull(dr1.Item(7)) Then
    '                    strEmailCustomer = dr1.Item(7)
    '                Else
    '                    strEmailCustomer = strNullString
    '                End If

    '            End If

    '            oReader = objUser.LoadAccountscetreUser(CustomerID)
    '            Session("UserUID") = strUserID
    '            If IsDBNull(oReader.Item("email")) Or strEmailCustomer = strNullString Then
    '                Session("UserEmail") = strNullString
    '            Else
    '                Session("UserEmail") = oReader.Item("email")
    '            End If
    '            Session("MSGPERPAGE") = oReader.Item("msgperpage")
    '            Session("CustomerName") = oReader.Item("name")

    '            ' Save minimal state info and redirect to the page.
    '            Response.Cookies.Add(New HttpCookie("CustomerName", oReader.Item("name")))
    '            Response.Cookies.Add(New HttpCookie("DatabaseName", _strDatabaseName))
    '            Response.Cookies.Add(New HttpCookie("DataSource", _strDataSource))

    '            ' Check the customer services and activate them

    '            'DoServices(CustomerID)
    '            Dim cServices As ArrayList = AccountsCentre.BLL.ServicesManager.GetServicesAllowed(CustomerID)
    '            Session("Services") = cServices
    '            FormsAuthentication.SetAuthCookie(CustomerID.ToString, False)
    '            'Response.Write("Url=" & FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))
    '            'Response.End()

    '            If Left(Trim(UCase(FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))), 9) = "/DEFAULT." Then
    '                'FormsAuthentication.RedirectFromLoginPage(CustomerID.ToString, False)
    '                Response.Redirect("https://www.accountscentre.com/members/default.aspx")

    '            Else

    '                ' Get the redirect url
    '                Dim RedirectURL As String = FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False)

    '                ' Here we'll explicitly redirect the url to secure mode. For development purpose
    '                ' we've mark comment on it. But make sure that before deployment this line is un-comment.
    '                '--------------------------------------------------------------------------------------------------------
    '                Response.Redirect("https://www.AccountsCentre.com" & RedirectURL)
    '                '--------------------------------------------------------------------------------------------------------

    '                ' For development purpose we'll redirect to the respective url
    '                'Response.Redirect(RedirectURL)

    '            End If

    '        Else

    '            ErrorMessage = SignInAttemptFailed

    '        End If
    '    End If
    'End Function

#End Region

#Region "ReadOnly / WriteOnly Properties "

    Public ReadOnly Property GetCustomerID() As Integer
        Get
            Return MyBase.CustomerID
        End Get
    End Property


   

    Public ReadOnly Property StaticNavigator() As String()
        Get


            If GetProWebCustomer = True Then
                'Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan OutLine", "Plan Wizard", "Business Tracker", "Close Plan"}
                Dim mainNavigator() As String = New String() {"Texts", "Tables", "Charts", "Print", "Plan Wizard", "Business Tracker", "MeterWizard", "Close Plan"}
                Return mainNavigator
            Else
                Dim mainNavigator() As String = New String() {"Texts", "Tables", "Charts", "Print", "Plan Wizard", "Close Plan"}
                Return mainNavigator
            End If



        End Get
    End Property

    Public Overridable ReadOnly Property Navigator() As String() Implements IBizPlanWebBase.Navigator
        Get
            Dim mainNavigator() As String
            If GetProWebCustomer = True Then
                mainNavigator = New String() {"Create Plan", "Plan Manager", "Sample Plan", "Exported Plans", "Speedometer Manager", "Web Tracker"}

            Else
                mainNavigator = New String() {"Create Plan", "Plan Manager", "Sample Plan", "Exported Plans", "Web Tracker"}

            End If


            Return mainNavigator
        End Get
    End Property

    Public ReadOnly Property GetConnectionData() As ConnectionData Implements IBizPlanWebBase.GetConnectionData
        Get
            _connectionData.ClientType = ProviderType.SQLClient
            _connectionData.DatabaseName = "BizPlanWeb" 'ConnectionData.DatabaseName
            _connectionData.DataSource = "win-furqan\BusinessPlan" 'ConnectionData.DataSource
            '  _connectionData.ServiceName = ConnectionData.ServiceName
            _connectionData.SQLUserID = "sqluser" ' ConnectionData.SQLUserID
            _connectionData.SQLPassword = "D8kjhy" 'ConnectionData.SQLPassword
            _connectionData.CustomerID = MyBase.CustomerID
            Return _connectionData


        End Get
    End Property

    Public ReadOnly Property IsPlanOpened() As Boolean Implements IBizPlanWebBase.IsPlanOpened
        Get
            _businessPlanSummary = CType(Session("BUSINESS_SUMMARY"), InfiniLogic.BusinessPlan.BLL.BusinessPlan)
            If IsNothing(_businessPlanSummary) Then
                'Dim pageType As Type = GetType(Page)
                '   If ((TypeOf (Page) Is IPlanBase)) Then


                If (Not (TypeOf (Page) Is IPlanWizardBase)) And ((TypeOf (Page) Is IPlanBase)) Then

                    Response.Redirect("/InfiniPlan/Services/Plan/PlanManager.aspx")
                End If

                'Dim reqPath As String = Request.Path
                'Dim idx As Integer = reqPath.IndexOf("Services/Plan")
                'If idx < 0 Then
                '    Response.Redirect("/BizPlanWeb/Services/Plan/Home.aspx")
                'End If
                Return False
            Else
                Return True
            End If
        End Get
    End Property

    Public ReadOnly Property CurrentPlan() As InfiniLogic.BusinessPlan.BLL.BusinessPlan Implements IBizPlanWebBase.CurrentPlan
        Get
            '_businessPlanSummary = CType(Session("BUSINESS_SUMMARY"), Infinilogic.BusinessPlan.BLL.BusinessPlan)
            If IsPlanOpened Then Return _businessPlanSummary
        End Get
    End Property


    Public WriteOnly Property BusinessPlanSummary() As InfiniLogic.BusinessPlan.BLL.BusinessPlan Implements IBizPlanWebBase.BusinessPlanSummary
        Set(ByVal Value As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
            _businessPlanSummary = Value
            Session("BUSINESS_SUMMARY") = _businessPlanSummary
        End Set
    End Property


    Private _resMgr As ResourceManager
    Public Property GetCulture() As String
        Get
            cult = CType(Session("val"), String)
            Return cult
        End Get
        Set(ByVal Value As String)
            Session("val") = Value
        End Set
    End Property

    Public ReadOnly Property ResMgr() As ResourceManager
        Get
            If (_resMgr Is Nothing) Then
                If Not Session("SelectedCulture") Is Nothing Then
                    _culture = Session("SelectedCulture")
                Else
                    _culture = New CultureInfo("en")
                    Session("SelectedCulture") = _culture
                End If

                Thread.CurrentThread.CurrentUICulture = _culture
                _resMgr = New ResourceManager("Infinilogic.BusinessPlan.Web.Common.Strings", System.Reflection.Assembly.GetExecutingAssembly)
            End If

            Return _resMgr
        End Get
    End Property
    Public Property SelectCulture() As Integer
        Get
            Return _curItem
        End Get
        Set(ByVal Value As Integer)
            _curItem = Value
        End Set
    End Property

#End Region

    Public Property CurItem() As Integer
        Get
            Return _curItem
        End Get
        Set(ByVal Value As Integer)
            _curItem = Value
        End Set
    End Property

    Public Property CurPage() As Integer
        Get
            Return _curPage
        End Get
        Set(ByVal Value As Integer)
            _curPage = Value
        End Set
    End Property

    Public Property CurrentNavigator() As String()
        Get
            Return _currentNavigator
        End Get
        Set(ByVal Value As String())
            _currentNavigator = Value
        End Set
    End Property


    Public Function GetCustomerName() As String Implements IBizPlanWebBase.GetCustomerName
        Return MyBase.CustomerName
    End Function


    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error
        Try
            Dim Ex As Exception
            Dim body As String

            Ex = Server.GetLastError
            Session.Add("errorText", ex.Message)
            Server.ClearError()
            'body = "Customer (Devlopment)   : " & MyBase.CustomerID & "<br>" & _
            '        "Machine            : " & MyBase.Server.MachineName & "<br>" & _
            '        "Source     : " & Ex.Source.ToString & "<br>" & _
            '        "Messege    : " & Ex.Message.ToString & "<br>" & _
            '        "Stack Trace: " & Ex.StackTrace.ToString & "<br>"

            body = ExceptionFormatter2.Formatter.HandleException(Ex, "bizplan.errors@accountscentre.com", "support@infinibiz.com", "InfiniPlan")

            Dim a As String = "Source     : " & Ex.Source.ToString & "<br>" & _
                                          "Messege    : " & Ex.Message.ToString & "<br>" & _
                                                  "Stack Trace: " & Ex.StackTrace.ToString & "<br>"
            Session.Add("errorText", a)
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "infinibiz Administration", body, Mail.MailFormat.Html, )
            ' CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "errors@infinibiz.com", "infinibiz Administration", body, Mail.MailFormat.Html)

        Catch ex As Exception
            Session.Add("errorText", ex.Message)
        Finally
            '   Response.Redirect("/InfiniPlan/Services/Plan/ErrorPage.aspx")
        End Try
    End Sub

    'Properties Created for cheacking PROWEB status for Customer 


    Public WriteOnly Property SetCustomerCurrency() As String Implements IBizPlanWebBase.SetCustomerCurrency
        Set(ByVal Value As String)
            Customercurrency = Value
            Session("currecny") = Customercurrency
        End Set
    End Property

    Public ReadOnly Property GetCustomerCurrency() As String Implements IBizPlanWebBase.GetCustomerCurrency
        Get
            Return Session("currecny")
        End Get
    End Property


    Public WriteOnly Property SetProWebCustomer() As Boolean Implements IBizPlanWebBase.SetProWebCustomer
        Set(ByVal Value As Boolean)
            Customer = Value
            Session("Status") = Customer
        End Set
    End Property

    Public ReadOnly Property GetProWebCustomer() As Boolean Implements IBizPlanWebBase.GetProWebCustomer
        Get
            Return Session("Status")
        End Get
    End Property

    Public Property ProductName() As String Implements IBizPlanWebBase.ProductName
        Set(ByVal Value As String)
            ProdcutServiceName = Value
            Session("ProductName") = ProdcutServiceName
        End Set
        Get
            Return Session("ProductName")
        End Get
    End Property


    Public Property GetAllowedPages() As DataTable

        Get
            Return Session("AllowPages")
        End Get
        Set(ByVal Value As DataTable)
            PagesInfo = Value
            Session("AllowPages") = PagesInfo
        End Set
    End Property

#Region "Control Properties"
    Public Property CurrentTableid() As String Implements IBizPlanWebBase.CurrentTableid
        Set(ByVal Value As String)
            Tableid = Value
            Session("tableid") = Tableid
        End Set
        Get
            Return Session("tableid")
        End Get
    End Property

    Public Property CurrentRow() As Integer Implements IBizPlanWebBase.CurrentRow
        Set(ByVal Value As Integer)
            Row = Value
            Session("SelectedRow") = Row
        End Set
        Get
            Return Session("SelectedRow")
        End Get
    End Property


#End Region

End Class


