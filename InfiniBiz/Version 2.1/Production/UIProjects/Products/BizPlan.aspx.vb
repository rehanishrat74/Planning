Imports InfiniLogic.AccountsCentre.common

Public Class BizPlan
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents IMG As System.Web.UI.WebControls.ImageButton
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents OrderHere1 As InfiniLogic.AccountsCentre.BLL.OrderHere
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuares As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents returnurl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents lblbizplan As System.Web.UI.WebControls.Label
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell


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
        'Dim strProductCode As String = Request.QueryString("orderhere")

        'If (strProductCode <> "") Then
        '    Dim defPage As DefaultPage
        '    If defPage.isValidProductCode(strProductCode) Then

        '        OrderHere1.ProductCode = strProductCode
        '        Dim ee As New ImageClickEventArgs(1, 1)
        '        OrderHere1.OrderHere_Click(Me, ee)

        '    Else

        '        'Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Hom))
        '        RedirectToErrorPage(ACC_Error_Messages.ACC_Service_Not_Available_For_Sale)

        '    End If

        'End If
    End Sub

    'Private Sub OrderHere1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles OrderHere1.Click

    '    If User.Identity.IsAuthenticated = True Then

    '        Response.Redirect("https://www.accountscentre.com/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("https://www.accountscentre.com/Account/SignIn.aspx")
    '    End If
    'End Sub

End Class
