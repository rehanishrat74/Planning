' Modified by - Win-saira 


#Region "Imports "
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.WebControls
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Reflection
'Imports Microsoft.ApplicationBlocks.UIProcess
#End Region


Public Class Table
    ' Inherits System.Web.UI.Page
    Inherits TablesBase
    Dim dtUserRigths As DataTable

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Public isRecord As Boolean
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents firstButton As System.Web.UI.WebControls.Button
    Public Status As Boolean
    ' protected withevents gridDiv as  system.Web.UI.HtmlControls.
    Public objPlan As Plan
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents tblcontents As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents GridControlPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents msg As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents bgTable As Infinilogic.BusinessPlan.WebControls.BusinessGrid
    Protected WithEvents gridPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents InsertButton As System.Web.UI.WebControls.Button
    Protected WithEvents ImportButton As System.Web.UI.WebControls.Button
    Protected WithEvents DeleteButton As System.Web.UI.WebControls.Button
    Protected WithEvents btnRename As System.Web.UI.WebControls.Button
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents btnCopyRest As System.Web.UI.WebControls.Button
    Protected WithEvents ChooseGrid1 As GridControl
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents btnImportBack As System.Web.UI.WebControls.Button
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel
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

        Me.InsertButton.Text = ResMgr.GetString("bizplanweb_services_tables_table_InsertButton")
        Me.DeleteButton.Text = ResMgr.GetString("bizplanweb_services_tables_table_DeleteButton")
        Me.btnRename.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnRename")
        Me.btnUpdate.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnUpdate")
        Me.btnCopyRest.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnCopyRest")
        Me.btnBack.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnBack")
        Me.btnNext.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnNext")
        Me.lblHeader.Text = ResMgr.GetString("bizplanweb_services_tables_table_lblHeader")
        Me.ImportButton.Text = ResMgr.GetString("bizplanweb_services_tables_table_ImportButton")
        Me.btnImportBack.Text = ResMgr.GetString("bizplanweb_services_tables_table_btnImportBack")
        Me.msg.Text = ResMgr.GetString("bizplanweb_services_tables_table_msg")

    End Sub
#Region "................. Private Members "

    Private _tableID As Integer = -1
    Private _dt As BusinessTable
#End Region

#Region "................ Page Load "
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AttributeSettings()

        If Not IsNothing(Request.QueryString("tableID")) Then
            _tableID = CInt(Request.QueryString("tableID"))
            Session("LinkTable") = _tableID
            tblcontents.Visible = False
            If (Not Page.IsPostBack) Then
                PostBackSetting()
            End If

            If Page.IsPostBack Then
                ONPostBackSetting()
            End If
        Else
            If IsNothing(Session("LinkTable")) Then
                '''' nisar add
                If Not Session("merchantProUserID") Is Nothing Then
                    _tableID = RetunrTableId()
                Else
                    _tableID = 0
                End If
                ''''end


            Else
                _tableID = CType(Session("LinkTable"), Integer)
            End If

            tblcontents.Visible = False
            If (Not Page.IsPostBack) Then
                PostBackSetting()
            End If

            If Page.IsPostBack Then
                ONPostBackSetting()
            End If
        End If

        StatusSettings(_tableID)

        NavigatorSetting(_tableID)


        '// it is only use for change grid border color
        If Request.Url.Host = "www.accountscentre.com" Then
            bgTable.BorderColor = Color.SteelBlue
        Else
            bgTable.BorderColor = CType(ColorTranslator.FromHtml("#c0c0c0"), Color)
        End If
    End Sub
    Public Function RetunrTableId() As Integer
        Dim iRetrun As Integer
        Dim i As Integer
        Dim expression As String = System.String.Empty
        Dim dr() As DataRow
        dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String))
        dr = dtUserRigths.Select(" Modelid = 65 ")
        iRetrun = Convert.ToInt16(dr(0)("ModelOptionId"))
        Return iRetrun - 1
    End Function
    Private Sub AttributeSettings()
        InsertButton.Attributes.Add("onClick", "javascript:void(0);return GetNewRowName();")
        btnUpdate.Attributes.Add("onClick", "javascript:void(0);return UpdateGrid();")
        DeleteButton.Attributes.Add("onClick", "javascript:void(0);return DeleteRow();")
        btnRename.Attributes.Add("onClick", "javascript:void(0);return RenameRow();")
        btnCopyRest.Attributes.Add("onClick", "javascript:void(0);return CopyRest();")
        lblMessage.Visible = False
        Status = GetProWebCustomer
        'If (Status = False) And _tableID = TableStatus.IncomeStatement Then
        'Else

        'End If


    End Sub
    Private Function StatusSettings(ByVal _tableID As Integer) As String
        If (Status = True) Then
            If (_tableID = TableStatus.SalesForecast) Then
                ChooseGrid1.GridBehaviour = MultiGridTypes.Product
                CurrentTableid = CType(_tableID, String)
                ImportButton.Enabled = True
                ImportButton.Attributes.Add("OnInit", "this.className ='MBUTTONACCPRO'; ")
                ImportButton.Attributes.Add("onmouseover", "this.className ='MBUTTONACCPROON' ; ")
                ImportButton.Attributes.Add("onmouseout", "this.className ='MBUTTONACCPRO'; ")


            ElseIf _tableID = TableStatus.Expenses Then
                ChooseGrid1.GridBehaviour = MultiGridTypes.Expenses
                CurrentTableid = CType(_tableID, String)
                ImportButton.Enabled = True
                ImportButton.Attributes.Add("OnInit", "this.className ='MBUTTONACCPRO'; ")
                ImportButton.Attributes.Add("onmouseover", "this.className ='MBUTTONACCPROON'; ")
                ImportButton.Attributes.Add("onmouseout", "this.className ='MBUTTONACCPRO'; ")
            Else
                ImportButton.Enabled = False

            End If
            isRecord = objPlan.FetchRecordInfo(GetConnectionData, ChooseGrid1.GridBehaviour, CurrentPlan.PlanID)

        Else
            ImportButton.Enabled = False
            ImportButton.Visible = False
        End If
        'If isRecord = False Then
        '    ImportButton.Attributes.Add("onClick", "javascript:StopImport();")
        'End If
    End Function
    Private Function NavigatorSetting(ByVal _tableID As Integer) As String
        CurPage = 1
        CurItem = _tableID
        navController = New PlanNavigator(Me, GetConnectionData, CurrentPlan, GetTableNameFromID(_tableID, CurrentPlan))
    End Function
    Private Sub PostBackSetting()
        gridPanel.Visible = True
        btnUpdate.Visible = True
        ProcessTable(_tableID)
        bgTable.DataSource = _dt.DefaultView
        bgTable.DataBind()
    End Sub
    Private Sub ONPostBackSetting()
        gridPanel.Visible = True
        btnUpdate.Visible = True
        ProcessTable(_tableID)
        bgTable.DataSource = _dt.DefaultView
        bgTable.DataBind()

    End Sub
#End Region

#Region "................ Private Methods"
    Private Sub ProcessTable(ByVal tableID As Integer)
        Try
            Dim nav As String() = CurrentNavigator
            If (nav Is Nothing) Then nav = Navigator
            _dt = CType(BusinessTable.CreateTable(GetConnectionData, CurrentPlan, nav(tableID)), BusinessTable)
            bgTable.Editable = _dt.IsEditable
            gridPanel.Visible = True
            Session("name") = nav(_tableID)
            lblHeader.Text = ResMgr.GetString("bizplanweb_services_tables_table_lnk" & nav(_tableID))
            'lblHeader.Text = nav(_tableID)
        Catch ex As Exception
            lblMessage.Text = ResMgr.GetString("bizplan_error_lblErrorMessage") ' "Error Occured."
            lblMessage.ForeColor = Color.Red
            lblMessage.Visible = True
            gridPanel.Visible = False
        End Try
    End Sub
    Private Sub InsertButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        If Request.Form.Item("Save") = "Yes" Then
            Update()
        End If
        If Not REValidator.IsIdentifier(Request.Form.Item("NewRowName")) Then
            lblMessage.Text = ResMgr.GetString("bizplanweb_services_plan_planmanager_InvalidNameError")
            '"The row could not be inserted because the name was invalid."
            lblMessage.Visible = True
            Exit Sub
        End If
        Try
            'If (Status = True And _tableID = 5) Then

            '    _dt.InsertProductWithPro(CInt(Request.Form.Item("SelectedRowNumber")), Request.Form.Item("NewRowName"), CurrentPlan.BusinessGoods)
            '    ReloadPlan()
            '    Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'Else
            _dt.InsertRow(CInt(Request.Form.Item("SelectedRowNumber")), Request.Form.Item("NewRowName"))
            ReloadPlan()
            Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'End If
        Catch ex As BizPlanDBInvalidDataException
            lblMessage.Text = ResMgr.GetString(ex.Message) '  "Insert Opertation is not allowed" 'ResMgr.GetString("bizplan_error_name_lblErrorMessage") '"The row could not be inserted because the name was invalid."
            lblMessage.Visible = True
        End Try
    End Sub

    Private Sub DeleteButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        If Request.Form.Item("Save") = "Yes" Then
            Update()
        End If
        Try
            'If (Status = True And _tableID = 5) Then

            '    _dt.DeleteProductWithPro(CInt(Request.Form.Item("SelectedRowNumber")))
            '    ReloadPlan()
            '    Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'Else
            _dt.DeleteRow(CInt(Request.Form.Item("SelectedRowNumber")))
            ReloadPlan()
            Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'End If
        Catch ex As BizPlanDBInvalidDataException
            lblMessage.Text = ResMgr.GetString(ex.Message)  ' "Delete Opertation is not allowed on selected Cell"  ' ResMgr.GetString("bizplan_error_name_lblErrorMessage")  '"The row could not be inserted because the name was invalid."
            lblMessage.Visible = True
        End Try
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Update()
        ReloadPlan()
        'Dim ChangedCells As Collection = GetChangedCells(Request.Form.Item("ChangedCells"))
        'Dim flag As Boolean = _dt.ApplyCellChanges(ChangedCells)
        'If flag Then
        '    lblMessage.Text = "The record has been updated"
        'Else
        '    lblMessage.Text = "The record has not been updated due to some technical problems.Kindly check the data you entered."
        'End If
        'lblMessage.Visible = True
    End Sub
    Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRename.Click
        If Request.Form.Item("Save") = "Yes" Then
            Update()
        End If

        If Not REValidator.IsIdentifier(Request.Form.Item("NewRowName")) Then
            lblMessage.Text = ResMgr.GetString("bizplanweb_services_plan_planmanager_InvalidReNameError")
            lblMessage.Visible = True
            Exit Sub
        End If

        Try
            'If (Status = True And _tableID = 5) Then
            '    _dt.RenameProductWithPro(CInt(Request.Form.Item("SelectedRowNumber")), Request.Form.Item("NewRowName"))
            '    ReloadPlan()
            '    Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'Else
            _dt.RenameRow(CInt(Request.Form.Item("SelectedRowNumber")), Request.Form.Item("NewRowName"))
            ReloadPlan()
            Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
            'End If

        Catch ex As BizPlanDBInvalidDataException
            lblMessage.Text = ResMgr.GetString(ex.Message)   '  "Rename Opertation is not allowed on selected Cell" ' ResMgr.GetString("bizplan_error_name_lblErrorMessage")
            lblMessage.Visible = True
        End Try
    End Sub

    Private Function GetChangedCells(ByVal ChangedCellsString As String) As Collection
        Dim ChangedCells As New Collection
        Try
            Dim CellStrings() As String = ChangedCellsString.Split(CChar(";"))
            Dim CellString As String
            For Each CellString In CellStrings
                Dim CellCoords() As String = CellString.Split(CChar(","))
                ChangedCells.Add(New ChangedCell(CInt(CellCoords(0)), CInt(CellCoords(1)), CellCoords(2)))
            Next
        Catch ex As Exception
        End Try
        Return ChangedCells
    End Function

    Private Sub Update()
        Dim ChangedCells As Collection = GetChangedCells(Request.Form.Item("ChangedCells"))
        Dim flag As Boolean = _dt.ApplyCellChanges(ChangedCells)
        If flag Then
            lblMessage.Text = ResMgr.GetString("bizplan_error_no_lblErrorMessage")
        Else
            lblMessage.Text = ResMgr.GetString("bizplan_error_yes_lblErrorMessage")
        End If
        lblMessage.Visible = True
        ProcessTable(_tableID)
        bgTable.DataSource = _dt.DefaultView
        bgTable.DataBind()
    End Sub

    Private Sub ReloadPlan()
        BusinessPlanSummary = Plan.GetBusinessPlanSummary(GetConnectionData, CurrentPlan.PlanID)
        'BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, planID)
        If CurrentPlan.IsOngoing Then
            CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
        Else
            CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
        End If
    End Sub
#End Region

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Dim url As String = navController.MoveBackward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim url As String = navController.MoveForward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub
    Private Sub ImportButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportButton.Click
        '  If (_tableID = TableStatus.SalesForecast) Then
        If isRecord = True Then
            ContolSettings()
        Else
            InsertButton.Visible = False
            DeleteButton.Visible = False
            btnRename.Visible = False
            btnUpdate.Visible = False
            btnCopyRest.Visible = False
            bgTable.Visible = False
            gridPanel.Visible = False
            Panel1.Visible = True
            ImportButton.Visible = False
        End If


    End Sub
    Private Sub ContolSettings()
        InsertButton.Visible = False
        DeleteButton.Visible = False
        btnRename.Visible = False
        btnUpdate.Visible = False
        btnCopyRest.Visible = False
        bgTable.Visible = False
        gridPanel.Visible = False
        GridControlPanel.Visible = True
        ImportButton.Visible = False

        Dim RowValue As String = CType(_dt.RowNum(CInt(Request.Form.Item("SelectedRowNumber"))), String)
        Dim RowNumber As Integer = objPlan.RowIndex(GetConnectionData, RowValue, ChooseGrid1.GridBehaviour, CurrentPlan.PlanID)
        CurrentRow = RowNumber
        lblHeader.Text = CType(Session("name"), String) + " ( Import ) "
    End Sub


    Private Sub btnImportBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportBack.Click
        Response.Redirect("Table.aspx?tableID=" + CStr(_tableID))
    End Sub



End Class
