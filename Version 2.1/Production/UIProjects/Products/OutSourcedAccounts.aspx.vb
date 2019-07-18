Imports InfiniLogic.AccountsCentre.BLL

Public Class OutSourcedAccounts
    Inherits PageBase 'System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlCompanyProfile As System.Web.UI.WebControls.Panel
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuares As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents returnurl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents IMG As System.Web.UI.WebControls.ImageButton
    Protected WithEvents OrderHere1 As InfiniLogic.AccountsCentre.BLL.OrderHere

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

    'Private Sub IMG_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IMG.Click
    '    If User.Identity.IsAuthenticated = True Then

    '        Response.Redirect("https://www.accountscentre.com/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("https://www.accountscentre.com/Account/SignIn.aspx")
    '    End If
    'End Sub
End Class
