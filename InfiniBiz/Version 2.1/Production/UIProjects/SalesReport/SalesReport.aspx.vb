#Region "    Imports"
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Security
Imports System.Data.SqlClient
#End Region

Public Class SalesReport
    Inherits PageTemplate

    Private objUser As New User
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblglobalview As System.Web.UI.WebControls.Label
    Protected WithEvents dgridSummaryInformation As System.Web.UI.WebControls.DataGrid
    Protected WithEvents hCriteria As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hSort As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnFind As System.Web.UI.WebControls.Button
    Protected WithEvents DCFROM As accounts.infinibiz.Web.DateCtrl
    Protected WithEvents DCTO As accounts.infinibiz.Web.DateCtrl

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
        If Page.IsPostBack = False Then
            Dim fromDate As String, toDate As String
            Dim intMonth As Integer
            Dim ds As DataSet, dr As DataRow

            intMonth = Now.DaysInMonth(Now.Year, Now.Month)
            DCFROM.Date = CType("1/" & Now.Month & "/" & Now.Year, Date)
            Session("DCFROM") = CType(DCFROM.Date, String)
            DCTO.Date = CType(intMonth & "/" & Now.Month & "/" & Now.Year, String)
            Session("DCTO") = DCTO.Date
            showInfiniBizProductSummarize(objUser.GetAllChildCompaniesHavingPro(Session("PID")))
        End If
    End Sub

    Function showInfiniBizProductSummarize(ByVal tds As DataSet)
        'Try
        dgridSummaryInformation.DataSource = objUser.ProductSummarize(tds, Session("DCFROM"), Session("DCTO"), Request.QueryString("vmx"), Session("InfiniBizProdSummerise"), Session("PID"))
        dgridSummaryInformation.DataBind()

        'Comment By:    M.Yousuf
        'Date:          Oct 03, 2007
        'Desc:          Renew throw orignal exception instead of only old exception msg
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
    End Function

    Private Sub dgridSummaryInformation_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgridSummaryInformation.ItemDataBound
        Dim Details As HyperLink
        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem Then
            Details = e.Item.FindControl("Detail")
            If e.Item.Cells(4).Text <> "-" Then
                With Details
                    .NavigateUrl = "/SalesReport/ProducttSummary.aspx?vmx=" & e.Item.Cells(6).Text
                    .Text = "Details"
                    .CssClass = "link-blue"
                    .Attributes.Add("onmouseover", "this.className='hover-link-blue'")
                    .Attributes.Add("onmouseout", "this.className='link-blue'")
                    .Font.Size = System.Web.UI.WebControls.FontUnit.Parse("10px")
                End With
            End If

        End If
    End Sub

    Private Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Dim objUser As New User
        Session("DCFROM") = CType(DCFROM.Date, String)
        Session("DCTO") = DCTO.Date
        Try
            dgridSummaryInformation.DataSource = objUser.ProductSummarize(objUser.GetAllChildCompaniesHavingPro(Session("PID")), Session("DCFROM"), Session("DCTO"), Session("InfiniBizChildID"), Session("InfiniBizProdSummerise"), Session("PID"))
            dgridSummaryInformation.DataBind()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
