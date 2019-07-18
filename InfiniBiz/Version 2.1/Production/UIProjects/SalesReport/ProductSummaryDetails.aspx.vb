#Region "    Imports"
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Security
Imports System.Data.SqlClient
#End Region

Public Class ProductSummaryDetails
    Inherits PageTemplate

    Public _ID As String
#Region " Web Form Designer Generated Code "
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    End Sub
    Protected WithEvents dgProduct As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents lblglobalview As System.Web.UI.WebControls.Label
    Protected WithEvents hCriteria As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hSort As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            _ID = Request.QueryString("ID")
            bindGrid(_ID)
        End If
    End Sub
    Private Sub bindGrid(ByVal id As String)
        Dim objClassReport As New User
        Dim objDS As New DataSet
        Try
            objDS = objClassReport.productSalesDetail(Session("DCFROM"), Session("DCTO"), Session("InfiniBizChildID"), id)
            If objDS.Tables(0).Rows.Count > 0 Then
                BindData(objDS)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub BindData(ByVal objDS As DataSet)
        Try
            Dim Parent As DataColumn = objDS.Tables(0).Columns("code")
            Dim Child As DataColumn = objDS.Tables(1).Columns("code")
            Dim OrderRelation As DataRelation = New DataRelation("ProductRelation", Parent, Child, False)
            objDS.Relations.Add(OrderRelation)
            dgProduct.DataSource = objDS.Tables(0).DefaultView
            dgProduct.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("/SalesReport/ProducttSummary.aspx?vmx=" & _ID)
    End Sub

    Private Sub dgProduct_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProduct.ItemCreated
        If e.Item.ItemType = ListItemType.Header Then
            e.Item.Cells(0).Text = "ProductID"
            e.Item.Cells(1).Text = "Description"
            e.Item.Cells(2).Text = "Quantity"
            e.Item.Cells(3).Text = "Total Sales"
        ElseIf (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
            Dim exp As PlaceHolder
            exp = e.Item.Cells(4).FindControl("Expanded")
            Dim dgDetail As DataGrid = exp.FindControl("dgDetail")
            dgDetail.Columns(0).HeaderText = "ProductID"
            dgDetail.Columns(1).HeaderText = "Invoice #"
            dgDetail.Columns(2).HeaderText = "Inv.Date"
            dgDetail.Columns(3).HeaderText = "Quantity"
            dgDetail.Columns(4).HeaderText = "Sales Price"
            dgDetail.Columns(5).HeaderText = "Net Amount"
        End If
    End Sub
End Class
