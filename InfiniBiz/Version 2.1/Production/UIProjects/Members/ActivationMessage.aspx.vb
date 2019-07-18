Public Class ActivationMessage
    'Inherits PageTemplate
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnMyAccount As System.Web.UI.WebControls.Button
    Protected WithEvents hlnkWebsite As System.Web.UI.WebControls.HyperLink
    Protected WithEvents tdWebsite2 As System.Web.UI.HtmlControls.HtmlGenericControl

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Protected trWebsite1 As UI.HtmlControls.HtmlTableRow
    Protected trWebsite2 As UI.HtmlControls.HtmlTableRow

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then

            Dim WebsiteName As String = Session("WebsiteName")
            If Not WebsiteName Is Nothing AndAlso WebsiteName <> "" Then
                Session("WebsiteName") = ""
                trWebsite1.Visible = True
                trWebsite2.Visible = True
                hlnkWebsite.Text = WebsiteName
                hlnkWebsite.NavigateUrl = "http://" & WebsiteName
            Else
                trWebsite1.Visible = False
                trWebsite2.Visible = False
            End If

            'If Session("IsReseller") = "1" Then
            '    btnGotoResellerSystem.Visible = True
            '    btnStartAC.Visible = False
            'End If
        End If
    End Sub

    Private Sub btnStartAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Response.Redirect("/globalview/globalview.aspx")
    End Sub

    Private Sub btnMyAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyAccount.Click
        Response.Redirect("https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & Session(PageTemplate.Session_ServiceID)) ' Redirect to Home page.
    End Sub

    Private Sub btnGotoResellerSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim objService As New ResellerAutoLogin.ResellerServices
        Dim objInfo As New ResellerAutoLogin.LoginInfo
        Dim objResult As ResellerAutoLogin.AutoLoginResult
        objInfo.customeruid = Session(PageTemplate.Session_ParentUID)
        objInfo.password = Session(PageTemplate.Session_ParentPassword)
        objInfo.serviceid = Session(PageTemplate.Session_ServiceID)
        objResult = objService.autoLogin(objInfo)

        If objResult.ERRORCODE = "0" Then
            Response.Redirect(objResult.link)
        End If
    End Sub
End Class
