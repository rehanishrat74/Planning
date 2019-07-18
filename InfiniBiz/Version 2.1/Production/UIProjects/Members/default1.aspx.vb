Public Class MembersDefault
    Inherits PageTemplate
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuares As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents TheMenu As New LeftMenu(150)
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    'Private Sub menuarea_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuarea.Init
    '    With TheMenu
    '        '.AddItem("IMG", "/images/members.jpg", "/members/default1.aspx", True)
    '        '.AddItem("MYAC", "::. My Account", "/members/default.aspx")
    '        '.AddItem("PROF", "::. Profile", "profile.aspx")
    '        'If User.Identity.IsAuthenticated Then
    '        '.AddItem("SGNN", "::. Sign Out", "/account/signout.aspx")
    '        '.AddItem("UPSRV", "::. Update Services", "https://www.accountscentre.com/Members/UpdateServices.aspx")
    '        '  .AddItem("ORDER", "::. Order History", "https://www.accountscentre.com/Members/orderHistory.aspx")
    '        'Else
    '        '    .AddItem("SGNN1", "::. Sign In", "https://www.accountscentre.com/account/signin.aspx")
    '        '    .AddItem("REGR", "::. Registration", "https://www.accountscentre.com/Account/newcustomer.aspx")
    '        'End If
    '        '.AddItem("MEM1", "/images/index1.jpg", "", True, , False)
    '    End With
    '    '  menuarea.InnerHtml = TheMenu.Render
    '    If Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 13) = "DEFAULT1.ASPX" Then membersarea.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("MEMBERS")
    '    TheMenu = Nothing
    'End Sub


    Private Sub membersarea_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles membersarea.Init
        If Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 13) = "DEFAULT1.ASPX" Then membersarea.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("MEMBERS")
        TheMenu = Nothing
    End Sub
End Class
