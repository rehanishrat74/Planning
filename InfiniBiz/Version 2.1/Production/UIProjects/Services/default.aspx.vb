Public Class ServicesDefault
    Inherits PageTemplate
    'Inherits System.Web.UI.Page

    Protected WithEvents servicearea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
   
    Protected WithEvents TheMenu As New LeftMenu
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
        '    .AddItem("IMG", "/images/onlineservices.jpg", "/services/default.aspx", True)
        '    .AddItem("ANNL", "    ::. Annual Accounts", "annual.aspx")
        '    .AddItem("BKPN", "    ::. Book Keeping", "bookkeeping.aspx")
        '    .AddItem("CSTR", "    ::. Collection Service", "customer.aspx")
        '    .AddItem("CORP", "    ::. Corporation Tax", "corporationtax.aspx")
        '    .AddItem("PAYE", "    ::. Payroll", "payroll.aspx")
        '    .AddItem("DCAT", "    ::. Dormant Company Account", "Dormant.aspx")
        '    .AddItem("APRW", "    ::. Accounts Pro (web)", "accountsproweb.aspx")
        'End With
        'menuarea.InnerHtml = TheMenu.Render
        If Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 12) = "DEFAULT.ASPX" Then servicearea.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("ONLINESERVICESPAGE")

        TheMenu = Nothing
    End Sub


End Class
