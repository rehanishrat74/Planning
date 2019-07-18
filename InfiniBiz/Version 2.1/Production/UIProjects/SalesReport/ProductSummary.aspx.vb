
#Region "    Imports"
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Security
Imports System.Data.SqlClient
#End Region

Public Class ProductSummary
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblglobalview As System.Web.UI.WebControls.Label
    Protected WithEvents dgProduct As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents hCriteria As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hSort As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim grossTotal As Decimal
    Dim byBankTotal As Decimal
    Dim byCCTotal As Decimal
    Dim byOthersTotal As Decimal
    Private ObjUser As New User

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Page.IsPostBack = False Then
            dgProduct.DataSource = ObjUser.ProductSummaryDetail(Session("DCFROM"), Session("DCTO"), Session("InfiniBizChildID"))
            dgProduct.DataBind()
        End If

    End Sub

    Private Sub dgProduct_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProduct.ItemDataBound

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            grossTotal += Decimal.Parse(DataBinder.Eval(e.Item.DataItem, "Gross"))
            byBankTotal += Decimal.Parse(DataBinder.Eval(e.Item.DataItem, "ByBank"))
            byCCTotal += Decimal.Parse(DataBinder.Eval(e.Item.DataItem, "ByCreditCard"))
            byOthersTotal += Decimal.Parse(DataBinder.Eval(e.Item.DataItem, "ByOthers"))
        ElseIf e.Item.ItemType = ListItemType.Footer Then
            e.Item.Cells(2).Text = String.Format("{0:#,###.00}", byBankTotal)
            e.Item.Cells(3).Text = String.Format("{0:#,###.00}", byCCTotal)
            e.Item.Cells(4).Text = String.Format("{0:#,###.00}", byOthersTotal)
            e.Item.Cells(5).Text = String.Format("{0:#,###.00}", grossTotal)
        End If

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("/SalesReport/SalesReport.aspx")
    End Sub

End Class
