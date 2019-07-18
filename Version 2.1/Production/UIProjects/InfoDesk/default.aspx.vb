Public Class InfoDeskDefault
    'Inherits System.Web.UI.Page
    Inherits PageTemplate
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents infodeskarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    
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
    Private Sub menuarea_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuarea.Init
        'With TheMenu
        '    .AddItem("IMG", "/images/infodesk.jpg", "/infodesk/default.aspx", True)
        '    .AddItem("M6", "    ::. About Us", "aboutus.aspx")
        '    .AddItem("M5", "    ::. FAQs", "faq.aspx")
        '    .AddItem("M3", "    ::. Newsletters", "newsletters.aspx")
        '    .AddItem("M4", "    ::. New Services", "newservices.aspx")
        '    .AddItem("M2", "    ::. Tax Updates", "taxupdates.aspx")
        'End With
        'menuarea.InnerHtml = TheMenu.Render
        If Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 12) = "DEFAULT.ASPX" Then membersarea.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("INFODESKPAGE")
        TheMenu = Nothing
    End Sub
End Class
