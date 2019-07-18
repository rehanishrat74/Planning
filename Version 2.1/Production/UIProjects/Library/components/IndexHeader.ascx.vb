Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common


Public Class IndexHeader
    Inherits System.Web.UI.UserControl
    Protected WithEvents q As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGO As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ddlACLanguages As System.Web.UI.WebControls.DropDownList
    Protected WithEvents tblMenu As System.Web.UI.HtmlControls.HtmlTable
    'Declarations



    Protected WithEvents CompanyAdmin As System.Web.UI.HtmlControls.HtmlGenericControl
    Friend Event LanguageChanged(ByVal languageName As String)
    Friend Event InfiniOfficeServiceError(ByVal errorCode As String, ByVal errorDescription As String)
    'Properties
    Friend ReadOnly Property CurrentLanguage() As String
        Get
            Return ddlACLanguages.SelectedValue
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
        'System.Net.ServicePointManager.CertificatePolicy = New TrustAllCertificatePolicy
        'Dim objInfiniOffice As com.InfiniOffice.www.InfiniOfficeServerService
        'Dim ctResultSet As com.InfiniOffice.www.ResultSet

        'Try
        '    objInfiniOffice = New com.InfiniOffice.www.InfiniOfficeServerService
        '    ctResultSet = objInfiniOffice.AuthenticateUser(txtUserID.Text, txtPassword.Text)
        '    If ctResultSet.code = "0" Then

        '        Dim sScript As String
        '        'sScript &= "<script> function loadWindow() {var w = window.open('http://www.infinioffice.com/index.php?SCREEN=welcome&sid=" & ctResultSet.sid & "',target='_blank','left=0,top=0,toolbar=no,location=no,status=no,resizable=no,menubar=no,scrollbars=no,width='+screen.availWidth+',height='+screen.availHeight);} loadWindow();</script>"
        '        'sScript &= "<script> function loadWindow() {var w = window.open('http://www.centre.biz/index.php?SCREEN=welcome&sid=" & ctResultSet.sid & "',target='_blank','left=0,top=0,toolbar=no,location=no,status=no,resizable=no,menubar=no,scrollbars=no,width='+screen.availWidth+',height='+screen.availHeight);} loadWindow();</script>"
        '        sScript &= "<script> function loadWindow()"
        '        sScript &= "{"
        '        sScript &= "var w = window.open('http://www.centre.biz/index.php?SCREEN=welcome&sid=" & ctResultSet.sid & "',target='_blank','left=0,top=0,toolbar=no,location=no,status=no,resizable=no,menubar=no,scrollbars=no,width='+screen.availWidth+',height='+screen.availHeight);"
        '        sScript &= "if (w)"
        '        sScript &= "{"
        '        sScript &= "var offset = (navigator.userAgent.indexOf(""Mac"") != -1 || navigator.userAgent.indexOf(""Gecko"") != -1 || navigator.appName.indexOf(""Netscape"") != -1) ? 0 : 4;"
        '        sScript &= "w.moveTo(-offset, -offset);"
        '        sScript &= "w.resizeTo(screen.availWidth + (2 * offset),screen.availHeight + (2 * offset));"
        '        ''sScript &= "	                   "
        '        ''sScript &= "	//w.resizeTo(screen.availWidth,screen.availHeight);"
        '        sScript &= "}"
        '        sScript &= "else"
        '        sScript &= "alert('Pop-Up Blocker is enabled so some of our features will not work properly and it is recommended that you should add this website in your safe list in order to avoid this message in future.');"
        '        sScript &= "}"
        '        sScript &= " loadWindow();</script>"




        '        Page.RegisterClientScriptBlock("showInfiniOffice", sScript)

        '    Else
        '        RaiseEvent InfiniOfficeServiceError(ctResultSet.code, ctResultSet.desc)
        '    End If
        'Catch ex As Exception
        '    RaiseEvent InfiniOfficeServiceError("", "Temporarily InfiniOffice's Login service is not available.")
        'Finally
        '    ctResultSet = Nothing
        '    objInfiniOffice.Dispose()
        '    objInfiniOffice = Nothing
        'End Try
    End Sub
    Private Sub SearchSite()

    End Sub
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Request("r") = "fh" Then
            AutoLoginFormationsHouse()
        End If
        chkSignINOUT()
    End Sub
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

        Dim index As Integer
        Dim strScript As String = "var availableServices = new Array();       " & _
                                  "var availableServicesName = new Array();       "

        If Me.Page.User.Identity.IsAuthenticated Then

            Dim sqlDR As SqlClient.SqlDataReader
            Try

                sqlDR = ServicesManager.AllowedServicesMenu(CustomerID)
                With sqlDR
                    While .Read
                        strScript &= "availableServices[" & index & "]='" & .Item("URL") & "';       " & _
                                     "availableServicesName[" & index & "]='" & .Item("Description") & "';       "
                        index += 1
                    End While
                End With
            Catch ex As Exception
            Finally
                If Not sqlDR.IsClosed Then
                    sqlDR.Close()
                End If

            End Try
        End If

        Return strScript
    End Function

    'Private Sub ddlACLanguages_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles ddlACLanguages.SelectedIndexChanged

    '    If ddlACLanguages.SelectedValue <> "" Then PageBase.RedirectToErrorPage(ACC_Error_Messages.DefaultMsg)

    'End Sub
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