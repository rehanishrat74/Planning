Imports InfiniLogic.AccountsCentre.BLL

Public Class MessageNotifications
    Inherits MessageDefault
    Protected WithEvents notification As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor
    

    'Inherits System.Web.UI.Page   

    Protected WithEvents nGrid As New System.Web.UI.WebControls.DataGrid


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        'InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        nGrid.PageSize = 10
        nGrid.DataSource = MessageBoard.GetNotifications(customerid)
        nGrid.DataBind()

    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        TheMenu("NTS").IsSelected = True
    End Sub

    Public Sub nGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles nGrid.ItemDataBound
        '
    End Sub

    Public Sub nGrid_Page(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles nGrid.PageIndexChanged
        '
    End Sub
End Class
