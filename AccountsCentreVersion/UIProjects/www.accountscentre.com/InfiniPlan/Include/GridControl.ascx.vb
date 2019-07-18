Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Text
Imports System
 

Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL

Imports System.Data.SqlClient
 
Imports System.io

Public Class GridControl
    Inherits System.Web.UI.UserControl
 
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Public basePage As BizPlanWebBase

    Public KeybasePage As BizPlanWebBase
    Public objPlan As Infinilogic.BusinessPlan.BLLRules.Plan
    Protected WithEvents GNavigator As GridNavigator

    Protected WithEvents btncreateinvoice As System.Web.UI.WebControls.Button
    Protected WithEvents dgProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lbltitleofgrid As System.Web.UI.WebControls.Label
    Protected WithEvents lblidsearch As System.Web.UI.WebControls.Label
    Protected WithEvents txtfrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblnamesearch As System.Web.UI.WebControls.Label
    Protected WithEvents txtto As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnsearch As System.Web.UI.WebControls.Button
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents InvoiceItems As System.Web.UI.WebControls.Label
    Protected WithEvents dgInvItems As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnImport As System.Web.UI.WebControls.Button
    Protected WithEvents btncancel As System.Web.UI.WebControls.Button
    Protected WithEvents Search As System.Web.UI.WebControls.Label
    Protected WithEvents SearchTest As System.Web.UI.WebControls.Label
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        InitiliazeLanguage()

    End Sub

#End Region

    Private Sub InitiliazeLanguage()
        KeybasePage = CType(Me.Page, BizPlanWebBase)

        Me.lbltitleofgrid.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblProductTitle")
        Me.Search.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblSearchRecordTitle")
        Me.SearchTest.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblSearchRecordMessage")
        Me.lblidsearch.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblId")
        Me.lblnamesearch.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblName")
        Me.btnsearch.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_btnSearch")
        Me.btnImport.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_btnImport")
        Me.btncancel.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_btnCancel")
        ' Me.lblError1.text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblError1")
        '  Me.lblError2.text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblError2")


    End Sub
#Region "Class variables"

    Public Code As String
    Dim Product As String
    Public InsertOrder As Integer

    Public LedgerID As String
    Dim Expense As String
    Dim ds As DataSet
    Private _selectedProducts As DataTable
    Private _selectedExpenses As DataTable
    Dim ChkGoClick As Boolean = False
    Private grid As Integer
    Public MaxRow As Boolean = True
    Public Event SelectedProductsClicked(ByVal SelectedProducts As DataTable)
    Public Event ProductCancelClicked()

    Private Const SELECTED_PRODUCTS_LIST As String = "SELECTED_PRODUCTS_LIST_Key"
    Private Const PRODUCTS_LIST As String = "PRODUCTS_LIST_KEY"
    Private Const SELECTED_PRODUCTS As String = "SELECTED_PRODUCTS_KEY"

    Private Const EXPENSES_LIST As String = "EXPENSES_LIST_KEY"
    Private Const SELECTED_EXPENSES As String = "SELECTED_EXPENSES_KEY"
    Private Const SELECTED_EXPENSES_LIST As String = "SELECTED_EXPENSES_LIST_Key"

    Public XMLstring As StringBuilder

#End Region
    Public a As BusinessTable 'RowNameExists
#Region "Properties     "


    Private _gridBehaviour As MultiGridTypes = GridBehaviour ' MultiGridTypes.Product

    Public Property GridBehaviour() As MultiGridTypes
        Get
            Return (_gridBehaviour)
        End Get
        Set(ByVal Value As MultiGridTypes)
            _gridBehaviour = Value
        End Set
    End Property

    Public Property GridTitle() As String
        Get
            Return (lbltitleofgrid.Text)
        End Get
        Set(ByVal Value As String)
            lbltitleofgrid.Text = Value
        End Set
    End Property

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        grid = _gridBehaviour
        basePage = CType(Me.Page, BizPlanWebBase)
        lblerror.Visible = False

        If Not (Page.IsPostBack) Then
            Select Case grid
                Case MultiGridTypes.Product
                    _selectedProducts = CType(Session(SELECTED_PRODUCTS_LIST), DataTable)
                    If _selectedProducts Is Nothing Then _selectedProducts = GetInvItemsTable_Product()
                    Session(SELECTED_PRODUCTS_LIST) = _selectedProducts
                Case MultiGridTypes.Expenses
                    _selectedExpenses = CType(Session(SELECTED_EXPENSES_LIST), DataTable)
                    If _selectedExpenses Is Nothing Then _selectedExpenses = GetInvItemsTable_Expenses()
                    Session(SELECTED_EXPENSES_LIST) = _selectedExpenses
            End Select

            If basePage.GetProWebCustomer = False Then
                GNavigator.LastPageIndex = 0
            Else
                GNavigator.LastPageIndex = objPlan.GetMultiSelPageCounts(basePage.CurrentPlan.PlanID, basePage.GetConnectionData, _gridBehaviour)

                GNavigator.Grid = "dgProducts"
                BindGrid(_gridBehaviour)
                BindInvItemsGrid()
            End If


        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsearch.Click


        If Not ValidateFields() Then
            lblerror.Visible = True
            lblerror.Text = "Enter criteria for search"
            Exit Sub
        End If
        Dim strID As String
        Dim strName As String
        strID = txtfrom.Text
        strName = txtto.Text
        ChkGoClick = True
        Dim dt As DataTable
        dt = objPlan.GetMultiList(basePage.GetConnectionData, basePage.CurrentPlan.PlanID _
        , _gridBehaviour, ChkGoClick, , , , strID, strName)


        If (dt.Rows.Count <= 0) Then
            lblerror.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblError2")
            lblerror.Visible = True
            txtfrom.Text = ""
            txtto.Text = ""
            Exit Sub
        End If
        lblerror.Text = ""
        lblerror.Visible = False
        GNavigator.ShowNavigator = False
        dgProducts.AllowPaging = True
        dgProducts.CurrentPageIndex = 0
        dgProducts.DataSource = dt
        dgProducts.DataBind()
        Select Case grid
            Case MultiGridTypes.Product
                Session(PRODUCTS_LIST) = dt
            Case MultiGridTypes.Expenses
                Session(EXPENSES_LIST) = dt
        End Select
        txtfrom.Text = ""
        txtto.Text = ""

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancel.Click
        Select Case grid
            Case MultiGridTypes.Product
                Session(SELECTED_PRODUCTS_LIST) = Nothing
            Case MultiGridTypes.Expenses
                Session(SELECTED_EXPENSES_LIST) = Nothing
        End Select


        Response.Redirect("Table.aspx?tableID=" + basePage.CurrentTableid)
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click

        Select Case grid
            Case MultiGridTypes.Product
                _selectedProducts = CType(Session(SELECTED_PRODUCTS_LIST), DataTable)
                InsertOrder = basePage.CurrentRow()
                If (_selectedProducts.Rows.Count = 0) Then
                    lblerror.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblError1")
                    lblerror.Visible = True
                Else
                    XMLstring = New StringBuilder
                    Dim ResultantXMLExpense As StringBuilder = BuildXML(XMLstring, _selectedProducts)
                    objPlan.InsertImportedRecords(basePage.GetConnectionData, basePage.CurrentPlan.PlanID _
                    , ResultantXMLExpense, _gridBehaviour, InsertOrder)
                    Session(SELECTED_PRODUCTS_LIST) = Nothing
                    Response.Redirect("Table.aspx?tableID=" + basePage.CurrentTableid)
                End If

            Case MultiGridTypes.Expenses
                _selectedExpenses = CType(Session(SELECTED_EXPENSES_LIST), DataTable)
                InsertOrder = basePage.CurrentRow()
                If (_selectedExpenses.Rows.Count = 0) Then
                    lblerror.Text = KeybasePage.ResMgr.GetString("BizPlan_Services_Plan_Tables_SaleForCost_lblError1")
                    lblerror.Visible = True
                Else
                    XMLstring = New StringBuilder
                    Dim ResultantXMLExpense As StringBuilder = BuildXML(XMLstring, _selectedExpenses)
                    objPlan.InsertImportedRecords(basePage.GetConnectionData, basePage.CurrentPlan.PlanID _
                    , ResultantXMLExpense, _gridBehaviour, InsertOrder)
                    Session(SELECTED_EXPENSES_LIST) = Nothing
                    Response.Redirect("Table.aspx?tableID=" + basePage.CurrentTableid)
                End If
        End Select

    End Sub

    Public Function BuildXML(ByVal XMLstring As StringBuilder, ByVal _selectedProducts As System.data.DataTable) As StringBuilder
        Select Case _gridBehaviour
            Case MultiGridTypes.Product
                With XMLstring
                    .Append("<ROOT>")
                    Dim qoute As Char = """"c
                    Dim ProductrowLoop As Integer
                    ProductrowLoop = InsertOrder
                    Dim count As Integer
                    For count = 0 To _selectedProducts.Rows.Count() - 1
                        Code = CType(_selectedProducts.Rows(count).Item(0), String)
                        Product = CType(_selectedProducts.Rows(count).Item(1), String)

                        Product = Product.Replace("&", "and")
                        ProductrowLoop = ProductrowLoop + 1
                        .Append("<ROW ")

                        .Append(" " + " ProductID=" + qoute)
                        .Append("aa" + qoute)

                        .Append(" " + " PlanID=" + qoute)
                        .Append(basePage.CurrentPlan.PlanID + qoute)

                        .Append(" " + "ProductName=" + qoute)
                        .Append(Product + qoute)

                        .Append(" " + " Unit=" + qoute)
                        .Append("1" + qoute)

                        .Append(" " + " ProCode=" + qoute)
                        .Append(Code + qoute)

                        .Append(" " + " InsertOrder=" + qoute)
                        .Append(CType(ProductrowLoop, String) + qoute)

                        .Append(" />")

                    Next
                    .Append("</ROOT>")
                    ProductrowLoop = 0
                End With

                Return XMLstring
            Case MultiGridTypes.Expenses
                With XMLstring
                    .Append("<ROOT>")
                    Dim qoute As Char = """"c
                    Dim ExpensesrowLoop As Integer
                    ExpensesrowLoop = InsertOrder
                    Dim count As Integer
                    For count = 0 To _selectedProducts.Rows.Count() - 1
                        LedgerID = CType(_selectedProducts.Rows(count).Item(0), String)
                        Expense = CType(_selectedProducts.Rows(count).Item(1), String)
                        Expense = Expense.Replace("&", "and")
                        '    a.RowNameExistsPro(Expense)
                        ExpensesrowLoop = ExpensesrowLoop + 1
                        .Append("<ROW ")

                        .Append(" " + " ExpenseID =" + qoute)
                        .Append("aa" + qoute)

                        .Append(" " + "ExpenseName=" + qoute)
                        .Append(Expense + qoute)

                        .Append(" " + " ParentID=" + qoute)
                        .Append("U_10" + qoute)

                        .Append(" " + " PlanID=" + qoute)
                        .Append(basePage.CurrentPlan.PlanID + qoute)

                        .Append(" " + " Unit=" + qoute)
                        .Append("1" + qoute)

                        .Append(" " + " InsertOrder=" + qoute)
                        .Append(CType(ExpensesrowLoop, String) + qoute)

                        .Append(" " + " ProLedgetID =" + qoute)
                        .Append(LedgerID + qoute)


                        .Append(" />")

                    Next
                    .Append("</ROOT>")
                    ExpensesrowLoop = 0
                End With
                Return XMLstring
        End Select


    End Function
#Region "Main Grid Events"

    Private Sub dgProducts_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProducts.ItemCreated
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            e.Item.Attributes.Add("onmousemove", "this.className='Grid_OnMouseMove';")      'e.Item.Attributes.Add("onmousemove", "this.style.backgroundColor='#ECF4FC';")
            e.Item.Attributes.Add("onmouseout", "this.className='Grid_OnMouseOut';")        'e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white';")
        End If
    End Sub

    Public Function CheckStatus(ByVal prdStatus As Boolean) As Boolean

        If prdStatus = False Then

            Return False

        Else

            Return True

        End If

    End Function



    Private Sub dgProducts_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgProducts.ItemDataBound
        If e.Item.ItemType = ListItemType.Header Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridHeaderBar"
            Next
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridInnerLines"
            Next
        End If
        Select Case grid
            Case MultiGridTypes.Product
                e.Item.Cells(1).Visible = False
                'e.Row.Cells(4).Visible = False
                'e.Row.Cells(5).Visible = False
            Case MultiGridTypes.Expenses
                e.Item.Cells(1).Visible = False
                'e.Row.Cells(4).Visible = False
                'e.Row.Cells(5).Visible = False
        End Select
    End Sub

    Public Sub dgProducts_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim query As String
        Dim chkTemp As CheckBox = CType(sender, CheckBox)
        Dim dgi As DataGridItem
        dgi = CType(chkTemp.Parent.Parent, DataGridItem)
        If (chkTemp.Checked = True) Then

            Select Case grid
                Case MultiGridTypes.Product
                    Dim pCode As String = dgi.Cells(2).Text
                    _selectedProducts = CType(Session(SELECTED_PRODUCTS_LIST), DataTable)

                    If (_selectedProducts.Rows.Count >= 99) Then
                    Else
                        Dim dr As DataRow = _selectedProducts.NewRow
                        dr("ProductCode") = pCode : dr("ProductName") = dgi.Cells(3).Text
                        _selectedProducts.Rows.Add(dr)
                        Session(SELECTED_PRODUCTS_LIST) = _selectedProducts
                    End If
                Case MultiGridTypes.Expenses
                    Dim pCode As String = dgi.Cells(2).Text
                    _selectedExpenses = CType(Session(SELECTED_EXPENSES_LIST), DataTable)

                    If (_selectedExpenses.Rows.Count >= 99) Then
                    Else
                        Dim dr As DataRow = _selectedExpenses.NewRow
                        dr("LedgerCode") = pCode : dr("ExpenseName") = dgi.Cells(3).Text
                        _selectedExpenses.Rows.Add(dr)
                        Session(SELECTED_EXPENSES_LIST) = _selectedExpenses
                    End If
            End Select
        End If
        BindInvItemsGrid()
    End Sub

    Public Sub dgInvItems_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Dim query As String
        Dim pCode As String = e.Item.Cells(1).Text

        If grid = MultiGridTypes.Product Then
            _selectedProducts = CType(Session(SELECTED_PRODUCTS_LIST), DataTable)
            query = "ProductCode='" & pCode & "'"
            Dim drArr() As DataRow = _selectedProducts.Select(query)
            _selectedProducts.Rows.Remove(drArr(0))
            lblerror.Text = ""
            BindInvItemsGrid()
        ElseIf grid = MultiGridTypes.Expenses Then
            _selectedExpenses = CType(Session(SELECTED_EXPENSES_LIST), DataTable)
            query = "LedgerCode='" & pCode & "'"
            Dim drArr() As DataRow = _selectedExpenses.Select(query)
            _selectedExpenses.Rows.Remove(drArr(0))
            lblerror.Text = ""
            BindInvItemsGrid()
        End If

        If grid = MultiGridTypes.Product Then
            BindProductsGrid(CType(Session(PRODUCTS_LIST), DataTable))
        ElseIf grid = MultiGridTypes.Expenses Then
            BindProductsGrid(CType(Session(EXPENSES_LIST), DataTable))
        End If
    End Sub

    Private Function ValidateFields() As Boolean
        If Trim(txtfrom.Text) = "" And Trim(txtto.Text) = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub dgProducts_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgProducts.PageIndexChanged
        dgProducts.CurrentPageIndex = e.NewPageIndex
        Select Case grid
            Case MultiGridTypes.Product
                BindProductsGrid(CType(Session(PRODUCTS_LIST), DataTable))
            Case MultiGridTypes.Expenses
                BindProductsGrid(CType(Session(EXPENSES_LIST), DataTable))
        End Select
    End Sub

    Private Sub BindProductsGrid(ByRef dt As DataTable)
        dgProducts.DataSource = dt
        dgProducts.DataBind()
    End Sub

    Private Sub BindInvItemsGrid()
        Select Case grid
            Case MultiGridTypes.Product
                Dim selectedProducts As DataTable = CType(Session(SELECTED_PRODUCTS_LIST), DataTable)
                If Not (selectedProducts Is Nothing) Then
                    If (selectedProducts.Rows.Count > 0) Then
                        dgInvItems.DataSource = selectedProducts
                        dgInvItems.DataBind()
                        dgInvItems.Visible = True
                    Else
                        dgInvItems.Visible = False
                    End If
                Else
                    dgInvItems.Visible = False
                End If
            Case MultiGridTypes.Expenses
                Dim selectedExpenses As DataTable = CType(Session(SELECTED_EXPENSES_LIST), DataTable)
                If Not (selectedExpenses Is Nothing) Then
                    If (selectedExpenses.Rows.Count > 0) Then
                        dgInvItems.DataSource = selectedExpenses
                        dgInvItems.DataBind()
                        dgInvItems.Visible = True
                    Else
                        dgInvItems.Visible = False
                    End If
                Else
                    dgInvItems.Visible = False
                End If
        End Select
    End Sub

    Sub BindGrid(ByVal grid As MultiGridTypes, Optional ByVal Flag As String = "1", Optional ByVal PageType As Integer = 0, _
                    Optional ByVal CompareValue As String = "-1")
        Try
            Dim dt As DataTable
            dt = objPlan.GetList(basePage.GetConnectionData, basePage.CurrentPlan.PlanID, grid, Flag, PageType, CompareValue)
            dgProducts.DataSource = dt
            dgProducts.DataBind()
            If grid = MultiGridTypes.Product Then
                Session(PRODUCTS_LIST) = dt
            ElseIf (grid = MultiGridTypes.Expenses) Then
                Session(EXPENSES_LIST) = dt
            End If
        Catch ex As Exception
            Response.Write(ex.Message)
        End Try
    End Sub

#End Region

#Region "Grid Navigation Functionality"

    Private Sub GNavigator_FirstPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNavigator.FirstPageClicked
        BindGrid(_gridBehaviour, "1", 0, "-1")
    End Sub

    Private Sub GNavigator_LastPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNavigator.LastPageClicked
        BindGrid(_gridBehaviour, "1", 3, "-1")
    End Sub

    Private Sub GNavigator_NextPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNavigator.NextPageClicked
        Dim cmpvalue As String
        Select Case grid
            Case MultiGridTypes.Product
                cmpvalue = dgProducts.Items(dgProducts.Items.Count - 1).Cells(2).Text
            Case MultiGridTypes.Expenses
                cmpvalue = dgProducts.Items(dgProducts.Items.Count - 1).Cells(2).Text
        End Select
        BindGrid(_gridBehaviour, "1", 2, cmpvalue)

    End Sub

    Private Sub GNavigator_PreviousPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNavigator.PreviousPageClicked
        Dim cmpvalue As String
        Select Case grid
            Case MultiGridTypes.Product
                cmpvalue = dgProducts.Items(0).Cells(2).Text
            Case MultiGridTypes.Expenses
                cmpvalue = dgProducts.Items(0).Cells(2).Text

        End Select
        BindGrid(_gridBehaviour, "1", 1, cmpvalue)

    End Sub

    Private Sub GNavigator_ShowListClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GNavigator.ShowListClicked
        lblerror.Text = ""
        lblerror.Visible = False
        BindGrid(_gridBehaviour, "1", 0, "-1")

    End Sub


    Private Function GetInvItemsTable_Product() As DataTable

        Dim InvTable As New DataTable("InvItems")
        Dim dc As DataColumn
        dc = New DataColumn("ProductCode", GetType(String))
        InvTable.Columns.Add(dc)
        dc = New DataColumn("ProductName", GetType(String))
        InvTable.Columns.Add(dc)

        Return InvTable
    End Function

    Private Function GetInvItemsTable_Expenses() As DataTable
        Dim InvTable As New DataTable("InvItems")
        Dim dc As DataColumn
        dc = New DataColumn("LedgerCode", GetType(String))
        InvTable.Columns.Add(dc)
        dc = New DataColumn("ExpenseName", GetType(String))
        InvTable.Columns.Add(dc)
        Return InvTable

    End Function

#End Region






End Class


