Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports InfiniLogic.AccountsCentre

Imports Microsoft.Toolkits.EnterpriseLocalization
Imports System.Resources
Imports System.threading
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class IndexHeader
    Inherits System.Web.UI.UserControl

    'initialization code for multilingual
    Protected _culture As CultureInfo
    Protected rs As ElementResourceSet
    Public js_path As String '= "/library/javascript/accmenu.js"
    Protected welcome_customer As String = "Welcome Customer"
    Protected WithEvents q As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGO As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlACLanguages As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpSelectLanguage As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblMenu As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblaccsignin As System.Web.UI.WebControls.Label

    Protected WithEvents signinlink As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents lblsearchsite As System.Web.UI.WebControls.Label
    Protected WithEvents tt As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img1 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img2 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img3 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img4 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Imagebutton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Imagebutton3 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Img5 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img6 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img7 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img8 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton4 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents GetThisVisibleFalse As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlSelection As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlGeneralBar As System.Web.UI.WebControls.Panel
    Protected WithEvents homeLink As System.Web.UI.HtmlControls.HtmlAnchor



    'Declarations



    Protected WithEvents CompanyAdmin As System.Web.UI.HtmlControls.HtmlGenericControl
    Friend Event LanguageChanged(ByVal languageName As String)
    Friend Event InfiniOfficeServiceError(ByVal errorCode As String, ByVal errorDescription As String)
    'Properties
    Friend ReadOnly Property CurrentLanguage() As String
        Get
            Return "en" 'ddlACLanguages.SelectedValue
        End Get
    End Property
    Public ReadOnly Property InfiniOfficeRedirectScript()
        Get
            Return ""
        End Get
    End Property
    Public ReadOnly Property CurrentUserScript()
        Get
            If Me.Page.User.Identity.IsAuthenticated Then

                Return "<script>var currentuser=" & Chr(34) & "Welcome Customer " & Session("UserUID") & Chr(34) & ";          " & AvailableServicesScript() & "</script>"
            Else
                Return "<script>var currentuser='';          " & AvailableServicesScript() & "</script>"
            End If
        End Get
    End Property
    'Events
    Private Sub ddlACLanguages_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RaiseEvent LanguageChanged(ddlACLanguages.SelectedValue)
    End Sub

    'Routines
    Private Sub Login()

    End Sub
    Private Sub SearchSite()

    End Sub

    'Protected ToolBarHTML As String = ""
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Modified by : Muhammad Furqan Khan  24-JUL-2007
        'Disable functionality if page is viewed inside infinioffice
        If Not IsNothing(Session(PageTemplate.Session_InsideIO)) AndAlso Session(PageTemplate.Session_InsideIO) Then
            Me.Visible = False
        Else
            homeLink.HRef = "https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & Session(PageTemplate.Session_ServiceID)


            load_culture()
            If Request("r") = "fh" Then
                AutoLoginFormationsHouse()
            End If
            chkSignINOUT()
        End If
        'Trace.Warn("HttpContext.Current.User.Identity.IsAuthenticated = " & HttpContext.Current.User.Identity.IsAuthenticated)
        ''ToolBar Service Modification Start -- Dec 12, 2006
        'If HttpContext.Current.User.Identity.IsAuthenticated Then
        '    Try
        '        ToolBarHTML = GetToolBarHTML()
        '    Catch ex As Exception
        '        System.Web.HttpContext.Current.Trace.Warn("Exception occure b/c of GetToolBarHTML")
        '        System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
        '        System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        '    End Try
        'End If
    End Sub

    'Private Function GetToolBarHTML() As String
    '    Dim Service As New com.infinibiz.webservices1.IBZservices
    '    Dim SessionInfo As New com.infinibiz.webservices1.getparameter
    '    Dim ReturnMsg As com.infinibiz.webservices1.returnmsg

    '    Trace.Warn("HttpContext.Current.User.Identity.Name = " & HttpContext.Current.User.Identity.Name)
    '    Dim CustomerID As String = HttpContext.Current.User.Identity.Name
    '    Dim objUser As New Infinilogic.AccountsCentre.BLL.User
    '    Dim ds As DataSet = objUser.GetParentChildProfile(CustomerID)
    '    Trace.Warn("Before CustomerID=" & CustomerID)
    '    If (Not ds Is Nothing) AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
    '        Trace.Warn("Parent Customer Found")
    '        CustomerID = ds.Tables(0).Rows(0).Item("customer_id")
    '    End If
    '    Trace.Warn("After CustomerID=" & CustomerID)
    '    SessionInfo.CUSTOMER_UID = Infinilogic.AccountsCentre.BLL.User.GetCustomerUID(CustomerID)
    '    SessionInfo.ITEM = "toolbar"
    '    SessionInfo.LANGUAGE = "eng"
    '    SessionInfo.REFERRER = "1009"
    '    SessionInfo.SESSIONID = Session(PageTemplate.Session_ServiceID)  'Session.SessionID

    '    Trace.Warn("SessionInfo.CUSTOMER_UID=" & SessionInfo.CUSTOMER_UID)
    '    Trace.Warn("SessionInfo.ITEM=" & SessionInfo.ITEM)
    '    Trace.Warn("SessionInfo.LANGUAGE=" & SessionInfo.LANGUAGE)
    '    Trace.Warn("SessionInfo.REFERRER=" & SessionInfo.REFERRER)
    '    Trace.Warn("SessionInfo.SESSIONID=" & SessionInfo.SESSIONID)

    '    ''Updated by MFK on 12 JAN 2007 to vary toolbar depending on
    '    ''wether customer has reseller package or not.
    '    Dim Value As String = ""
    '    If objUser.HasResellerPackage(CustomerID) Then
    '        Trace.Warn("HasResellerPackage = TRUE  :::: calling getResellerToolbar")
    '        ReturnMsg = Service.getResellerToolbar(SessionInfo)
    '        Trace.Warn("ReturnMsg.ERRORCODE=" & ReturnMsg.ERRORCODE.ToString)
    '        Trace.Warn("ReturnMsg.ERRORDESC=" & ReturnMsg.ERRORDESC)
    '        If ReturnMsg.ERRORCODE.ToString = "0" Then
    '            Value = ReturnMsg.VALUE
    '            Try
    '                Dim b As Byte() = Convert.FromBase64String(Value)
    '                Value = System.Text.ASCIIEncoding.ASCII.GetString(b)
    '            Catch ex As Exception
    '            End Try
    '            Trace.Warn("::Toolbar HTML::")
    '            Trace.Warn("ReturnMsg.ITEM= " & ReturnMsg.ITEM)
    '            Trace.Warn("ReturnMsg.VALUE= " & Value)
    '            'ReturnMsg.ITEM = ReturnMsg.ITEM.Replace("http://", "https://")
    '        End If
    '    Else
    '        Trace.Warn("HasResellerPackage = FALSE  :::: calling getSessionInfo")
    '        ReturnMsg = Service.getSessionInfo(SessionInfo)
    '        Trace.Warn("ReturnMsg.ERRORCODE=" & ReturnMsg.ERRORCODE.ToString)
    '        Trace.Warn("ReturnMsg.ERRORDESC=" & ReturnMsg.ERRORDESC)
    '        If ReturnMsg.ERRORCODE.ToString = "0" Then
    '            Value = ReturnMsg.VALUE
    '            Try
    '                Dim b As Byte() = Convert.FromBase64String(Value)
    '                Value = System.Text.ASCIIEncoding.ASCII.GetString(b)
    '            Catch ex As Exception
    '            End Try
    '            Trace.Warn("::Toolbar HTML::")
    '            Trace.Warn("ReturnMsg.ITEM= " & ReturnMsg.ITEM)
    '            Trace.Warn("ReturnMsg.VALUE= " & Value)
    '        End If
    '    End If

    '    Return Value
    'End Function

    Private Sub AutoLoginFormationsHouse()
        Dim ws As com.formationshouse.www.FHservices
        Dim oReturnMsg As com.formationshouse.www.ReturnMsg
        Dim sRedirectURL As String = ""
        Try
            'Response.Write("Page.User.Identity.IsAuthenticated=" & Page.User.Identity.IsAuthenticated)
            'Response.Write("UID=" & Session("UserUID"))
            'Response.Write("Pwd=" & CType(Page, BLL.PageBase).GetUserPassword(Session("UserUID")))

            If Page.User.Identity.IsAuthenticated Then
                Dim sPassword, sUserID As String
                sUserID = Session("UserUID")
                sPassword = CType(Page, BLL.PageBase).GetUserPassword(sUserID)
                System.Net.ServicePointManager.CertificatePolicy = New TrustAllCertificatePolicy
                ws = New com.formationshouse.www.FHservices
                oReturnMsg = ws.authUser(sUserID, sPassword)
                If oReturnMsg.ERRORCODE = 0.0 Then
                    sRedirectURL = "https://www.formationshouse.com/search/ereg/login.php?ACTION=ACLOGIN&lcode=" & oReturnMsg.LCODE & "&ui=" & oReturnMsg.UI
                End If
            Else
                sRedirectURL = "http://www.formationshouse.com"
            End If
        Catch ex As Exception
            AutoLogin.WriteDebugInfo("IndexHeader.ascx->TimeStamp:" & Now)
            AutoLogin.WriteDebugInfo("Exception:" & ex.ToString)
            Response.Redirect("http://www.formationshouse.com")
        Finally
            If Not ws Is Nothing Then
                ws.Dispose()
                ws = Nothing
            End If
        End Try
        If sRedirectURL <> "" Then
            Response.Redirect(sRedirectURL)
        End If
    End Sub
    Private ReadOnly Property CustomerID() As Int32
        Get
            Trace.Write("Index Header Customer ID : " & Page.User.Identity.Name)
            Return Int32.Parse(Page.User.Identity.Name)
        End Get
    End Property

    Private Sub btnGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sRedirectString As String
        sRedirectString = "http://info.centre.biz/info.php"
        sRedirectString &= "?q=" & q.Text
        sRedirectString &= "&ref=ac"
        sRedirectString &= "&siteonly=1"
        sRedirectString &= "&lang=en"
        Response.Redirect(sRedirectString)
    End Sub

    Private Sub InitializeComponent()

    End Sub

    Public Sub chkSignINOUT()

        '---------------------------------------------------
        ' Display menu if user is sign in 
        tblMenu.Visible = Page.User.Identity.IsAuthenticated
        '---------------------------------------------------

        'If Page.User.Identity.IsAuthenticated Then
        '    'signinlink.InnerHtml = "<B>Accounts Centre Sign Out</B>"
        '    'signinlink.HRef = "https://www.accountscentre.com/account/signout.aspx"
        'Else
        '    'signinlink.InnerHtml = "<B>Accounts Centre Sign In</B>"
        '    'signinlink.HRef = "https://www.accountscentre.com/account/signin.aspx"
        'End If
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Login()
    End Sub

    Private Sub lnkFHAutoLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AutoLoginFormationsHouse()
    End Sub

    Private Function AvailableServicesScript() As String

        '***********************************************************************
        'Updated by Muhammad Ubaid
        'Resion: Add Qurey String Class for Encription of CustomerId or ReSeller
        '***********************************************************************
        'Dim objQueryString As New SecureQueryString
        'Dim SecureCustomerid = "", SecureIsReSeller As String = ""
        '***************************************************************

        Dim index As Integer
        Dim strScript As String = "var availableServices = new Array();       " & _
                                  "var ProductCode = new Array();       " & _
                                  "var availableServicesName = new Array();       "

        If Me.Page.User.Identity.IsAuthenticated Then

            Dim sqlDR As SqlClient.SqlDataReader
            Try
                '********************************************************
                'objQueryString.Add("id", CustomerID)
                'objQueryString.Add("IsReSeller", True)
                '********************************************************

                sqlDR = ServicesManager.AllowedServicesMenu(CustomerID)
                With sqlDR
                    While .Read
                        'strScript &= "availableServices[" & index & "]='" & .Item("URL") & "?id=" & objQueryString.ToString & " ';       " & _
                        '"availableServicesName[" & index & "]='" & .Item("Description") & "';       "
                        strScript &= "availableServices[" & index & "]='" & .Item("URL") & " ';       " & _
                        "ProductCode[" & index & "]='" & .Item("ProductCode") & " ';       " & _
                        "availableServicesName[" & index & "]='" & .Item("Description") & "';       "
                        index += 1
                    End While
                End With
            Catch ex As Exception
            Finally
                If Not sqlDR Is Nothing AndAlso Not sqlDR.IsClosed Then

                    sqlDR.Close()
                End If

            End Try
        End If

        Return strScript
    End Function

    'Private Sub ddlACLanguages_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles ddlACLanguages.SelectedIndexChanged

    '    If ddlACLanguages.SelectedValue <> "" Then PageBase.RedirectToErrorPage(ACC_Error_Messages.DefaultMsg)

    'End Sub

    ' code for multilingual


    Public ReadOnly Property CultureName() As String
        Get
            Return Me.drpSelectLanguage.SelectedValue
        End Get
    End Property



    Public Sub load_culture()
        If Not IsPostBack Then
            'Settings.LoadCultureDropDownList(drpSelectLanguage, CultureDropDownTypes.NativeName, Nothing)
            If Not Session("SelectedCulture") Is Nothing Then
                _culture = Session("SelectedCulture")

            Else
                _culture = New CultureInfo("en")
                Session("SelectedCulture") = _culture
            End If
            '/****************************
            _culture = New CultureInfo("en")
            Session("SelectedCulture") = _culture
            '****************************/

            Thread.CurrentThread.CurrentUICulture = _culture
            Me.drpSelectLanguage.SelectedValue = Session("SelectedCulture").ToString
            select_culture()
        Else
            _culture = New CultureInfo("en")
            '_culture = New CultureInfo(Me.CultureName)
            Session("SelectedCulture") = _culture
            Thread.CurrentThread.CurrentUICulture = _culture
            Me.drpSelectLanguage.SelectedValue = Me.CultureName


            select_culture()
        End If
    End Sub
    Private Sub select_culture()
        'Select Case CultureName
        '    Case "en"
        '        Imagebutton1.ImageUrl = "\images\phone_fr.jpg"
        '        Imagebutton2.ImageUrl = "\images\phone_it.jpg"
        '        Imagebutton3.ImageUrl = "\images\phone_ru.jpg"
        '    Case "fr"
        '        Imagebutton1.ImageUrl = "\images\phone_en.jpg"
        '        Imagebutton2.ImageUrl = "\images\phone_it.jpg"
        '        Imagebutton3.ImageUrl = "\images\phone_ru.jpg"

        '    Case "it"
        '        Imagebutton1.ImageUrl = "\images\phone_en.jpg"
        '        Imagebutton2.ImageUrl = "\images\phone_fr.jpg"
        '        Imagebutton3.ImageUrl = "\images\phone_ru.jpg"
        '    Case "ru"
        '        Imagebutton1.ImageUrl = "\images\phone_en.jpg"
        '        Imagebutton2.ImageUrl = "\images\phone_fr.jpg"
        '        Imagebutton3.ImageUrl = "\images\phone_it.jpg"
        'End Select
    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        'Modified by : Muhammad Furqan Khan  24-JUL-2007
        'Disable functionality if page is viewed inside infinioffice
        If Not IsNothing(Session(PageTemplate.Session_InsideIO)) AndAlso Session(PageTemplate.Session_InsideIO) Then
            Me.Visible = False
        Else
            rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
            If Not PageBase.isEmployee Then
                js_path = rs.GetProperty("acc_lbljs_path", "System.Web.UI.WebControls.Label", "Text")
            Else
                js_path = "/library/javascript/Employee.js"
            End If
            welcome_customer = rs.GetProperty("acc_lblwelcome_customer ", "System.Web.UI.WebControls.Label", "Text")
        End If

        'img1 = rs.GetProperty("acc_components_indexheader_imgmainlogo", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img2 = rs.GetProperty("acc_components_indexheader_imgformationlogo", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img3 = rs.GetProperty("acc_components_indexheader_imgglobalbusiness", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img4 = rs.GetProperty("acc_components_indexheader_imghome", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img5 = rs.GetProperty("acc_components_indexheader_imgmyaccount", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img6 = rs.GetProperty("acc_components_indexheader_imgcheckemail", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img7 = rs.GetProperty("acc_components_indexheader_imgsupport", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img8 = rs.GetProperty("acc_components_indexheader_imgcontactus", "System.Web.UI.HtmlControls.HtmlImage", "Src")
        'img_phone = rs.GetProperty("acc_components_indexheader_imgphone", "System.Web.UI.HtmlControls.HtmlImage", "Src")

        'lblsearchsite = rs.GetProperty("acc_components_indexheader_lblsearchsite", "System.Web.UI.WebControls.Label", "Text")
        'btnGO.Text = rs.GetProperty("acc_components_indexheader_btngo", "System.Web.UI.WebControls.LinkButton", "Text")



    End Sub

    Public Sub imgselectlanguage(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        Select Case sender.ImageUrl
            Case "\images\phone_en.jpg"
                Me.drpSelectLanguage.SelectedIndex = 0
                '_culture = New CultureInfo("en")
                'Session("SelectedCulture") = _culture
            Case "\images\phone_fr.jpg"
                Me.drpSelectLanguage.SelectedIndex = 1
                '_culture = New CultureInfo("fr")
                'Session("SelectedCulture") = _culture
            Case "\images\phone_it.jpg"
                Me.drpSelectLanguage.SelectedIndex = 2
                '_culture = New CultureInfo("it")
                'Session("SelectedCulture") = _culture
            Case "\images\phone_ru.jpg"
                Me.drpSelectLanguage.SelectedIndex = 3
                '_culture = New CultureInfo("ru")
                'Session("SelectedCulture") = _culture
        End Select
        load_culture()

    End Sub



    Private Sub drpSelectLanguage_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpSelectLanguage.SelectedIndexChanged

        '_culture = New CultureInfo(drpSelectLanguage.SelectedValue)
        'Session("SelectedCulture") = _culture
        'Thread.CurrentThread.CurrentUICulture = _culture
        'select_culture()
        load_culture()

    End Sub


End Class



#Region "Trust All Certificates... It is used because it will communicate server to server"
Public Class TrustAllCertificatePolicy
    Implements System.Net.ICertificatePolicy
    Public Sub New()
    End Sub
    Public Function CheckValidationResult(ByVal sp As System.net.ServicePoint, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal req As System.Net.WebRequest, ByVal problem As Integer) As Boolean Implements System.Net.ICertificatePolicy.CheckValidationResult
        Return True
    End Function
End Class
#End Region