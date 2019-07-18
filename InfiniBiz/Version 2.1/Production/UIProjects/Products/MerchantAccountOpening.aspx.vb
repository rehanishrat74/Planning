Imports InfiniLogic.AccountsCentre.BLL

Public Class MerchantAccountOpening
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuares As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents returnurl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents IMG2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblmerchantaccountopening As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    'Private Sub IMG3_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IMG3.Click
    '    '    If User.Identity.IsAuthenticated = True Then

    '    '        Response.Redirect("https://www.accountscentre.com/Memebers/UpdateServices.aspx")
    '    '    Else
    '    '        Response.Redirect("https://www.accountscentre.com/Account/SignIn.aspx")
    '    '    End If

    '    Response.Redirect("http://www.formationshouse.com/optional_services.htm")
    'End Sub

    'Private Sub IMG4_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If User.Identity.IsAuthenticated = True Then

    '        Response.Redirect("https://www.accountscentre.com/Memebers/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("https://www.accountscentre.com/Account/SignIn.aspx")
    '    End If

    'End Sub

    Private Sub IMG2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IMG2.Click
        If User.Identity.IsAuthenticated = True Then

            Response.Redirect("https://www.accountscentre.com/Members/UpdateServices.aspx")
        Else
            Response.Redirect("https://www.accountscentre.com/Account/SignIn.aspx")
        End If
    End Sub
End Class
