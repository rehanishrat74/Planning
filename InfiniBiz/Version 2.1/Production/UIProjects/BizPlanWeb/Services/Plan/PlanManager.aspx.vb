' Modified by Win-Saira 
' Date : 27/02/2006

Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing

Public Class PlanManager
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents plnMain As System.Web.UI.WebControls.Panel
    Protected WithEvents MainTStrip As Microsoft.Web.UI.WebControls.TabStrip
    Protected WithEvents LastPlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgExportedPlans As System.Web.UI.WebControls.DataGrid
    Protected WithEvents imgBtnNewPlan As System.Web.UI.WebControls.Button

    Dim ObjCustomer As CustomerStatus

    Protected WithEvents mpHoriz As Microsoft.Web.UI.WebControls.MultiPage
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastPlan As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents space2 As System.Web.UI.WebControls.Label
    Protected WithEvents space5 As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton3 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton4 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton5 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents LinkButton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LinkButton3 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LinkButton4 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Datagrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents space1 As System.Web.UI.WebControls.Label
    Protected WithEvents ExistingPlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents space3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMyPlan As System.Web.UI.WebControls.Label
    Protected WithEvents SamplePlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtPlanName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents btnAdvSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents PanelUserPlans As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelSmaplePlans As System.Web.UI.WebControls.Panel
    Protected WithEvents lblSmaplePlans As System.Web.UI.WebControls.Label
    Protected WithEvents Panelbtnback As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        InitiliazeLanguage()
    End Sub
    Private Sub InitiliazeLanguage()
        Me.lblHeading.Text = ResMgr.GetString("bizplan_services_plan_planmanager_title_lblHeading")

        'exsisting plan grid 
        Me.ExistingPlanGrid.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanName")
        Me.ExistingPlanGrid.Columns(2).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanDescription")
        Me.ExistingPlanGrid.Columns(3).HeaderText = ResMgr.GetString("bizplanweb_services_plan_planmanager_griddate")
        Me.ExistingPlanGrid.Columns(4).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListDeletePlan")
        ' Sample Plan Grid
        Me.SamplePlanGrid.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlan")
        Me.SamplePlanGrid.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlanDescription")
        'recent plan grid





    End Sub

#End Region
 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim BoolStatus As Boolean

        BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        HttpContext.Current.Session("CopyPlanid") = Nothing
        SetProWebCustomer = BoolStatus

        Setting()

 
            Session("test") = Nothing
 
    End Sub

    Private Sub dgExportedPlans_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgExportedPlans.PageIndexChanged
        dgExportedPlans.CurrentPageIndex = e.NewPageIndex
        Dim dtaa As DataTable = Plan.GetExportedPlansList(GetConnectionData)
        dgExportedPlans.DataSource = dtaa
        dgExportedPlans.DataBind()
    End Sub

    Public Sub Setting()

        Session("Bar") = Nothing
        CurPage = 1
        CurItem = 0

        OpenSamplePlan()
        OpenMyPlan()
        Session("LinkTable") = Nothing
        Session("LinkChart") = Nothing

    End Sub
 
    Private Sub ExistingPlanGrid_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ExistingPlanGrid.ItemDataBound
        'If e.Item.ItemType = ListItemType.Header Then
        '    Dim i As Integer
        '    For i = 0 To e.Item.Cells.Count - 1
        '        e.Item.Cells(i).CssClass = "GridHeaderBar"
        '    Next
        'End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridInnerLines"
            Next
        End If

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim imageDelte As ImageButton
            imageDelte = CType(e.Item.Cells(2).FindControl("Delete"), ImageButton)
            imageDelte.Attributes.Add("onclick", "javascript:return confirm('Do you really want to delete this record ?')")
        End If
    End Sub

    Private Sub ExistingPlanGrid_ItemCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles ExistingPlanGrid.ItemCommand
        If e.CommandName = "Delete" Then
            Dim planId As String = CStr(e.Item.Cells(0).Text)
            If planId > "0" Then
                Plan.PermanentlyDeletePlan(GetConnectionData, planId)
                'Refresh the dataGrid.
                Me.BindMyPlanGrid()
            End If
        End If
    End Sub

    Private Sub SamplePlanGrid_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles SamplePlanGrid.PageIndexChanged

        SamplePlanGrid.CurrentPageIndex = e.NewPageIndex

        Dim plansTable As DataTable
        plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)

        SamplePlanGrid.DataSource = plansTable
        SamplePlanGrid.DataBind()

    End Sub
 
    Private Sub ExistingPlanGrid_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles ExistingPlanGrid.PageIndexChanged
        ExistingPlanGrid.CurrentPageIndex = e.NewPageIndex
        Dim plansTable As DataTable
        plansTable = Plan.GetPlansList(GetConnectionData)
        ExistingPlanGrid.DataSource = plansTable.DefaultView
        ExistingPlanGrid.DataBind()
    End Sub


    Private Sub OpenSamplePlan()

        Dim planID As String
        If Not Page.IsPostBack Then
            Dim dt As DataTable

            If Not Request.QueryString("pid") Is Nothing Then
                planID = Request.QueryString("pid")
            End If

            'A Plan Is Selected To Be Copied.
            If Not (planID Is Nothing) Then
                BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, planID)
                If CurrentPlan.IsOngoing Then
                    CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
                Else
                    CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
                End If
                Response.Redirect("/InfiniPlan/Services/Welcome.aspx")
            Else 'For The First Time.
                Dim plansTable As DataTable
                plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)

                If (plansTable.Rows.Count > 0) Then
                    lblMyPlan.Visible = False
                    SamplePlanGrid.DataSource = plansTable.DefaultView
                    SamplePlanGrid.DataBind()
                    lblMyPlan.Text = "Please click on the <b>plan name</b> to open that plan. To Search a plan from the complete list, please enter the plan name in the text box and click the <b>Go</b> button. "
                    lblMyPlan.Visible = True
                Else
                    SamplePlanGrid.Visible = False
                    'lblMyPlan.ForeColor = Color.Red


                    lblMyPlan.Text = "No plan has been created yet. Please use the <b>Create Plan</b> option to create a plan, or select a sample plan from the list by clicking the <b>Advance</b> button ."

                End If
            End If
        End If
    End Sub
 
    Private Sub OpenMyPlan()

        Dim planID As String
        Dim cmd As String = Request.QueryString("cmd")
        Session("planid") = cmd
        If Not Page.IsPostBack Then
            Dim dt As DataTable

            If Not Request.QueryString("pid") Is Nothing Then
                planID = (Request.QueryString("pid"))
            End If

            If planID > "0" Then
                BusinessPlanSummary = Plan.GetBusinessPlanSummary(GetConnectionData, planID)
                'BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, planID)
                If CurrentPlan.IsOngoing Then
                    CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
                Else
                    CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
                End If
                Response.Redirect("/InfiniPlan/Services/Welcome.aspx")
            Else
                Me.BindMyPlanGrid()
            End If
        End If
        Session("planid") = Nothing
    End Sub

    Private Sub BindMyPlanGrid()
        Dim plansTable As DataTable
        plansTable = Plan.GetPlansList(GetConnectionData)

        If (plansTable.Rows.Count > 0) Then
            lblMyPlan.Visible = False
            ExistingPlanGrid.DataSource = plansTable.DefaultView
            ExistingPlanGrid.DataBind()
            lblMyPlan.Text = "Please click on the <b>plan name</b> to open that plan. To Search a plan from the complete list, please enter the plan name in the text box and click the <b>Go</b> button. "
            lblMyPlan.Visible = True

        Else
            ExistingPlanGrid.Visible = False

            lblMyPlan.Text = "No plan has been created yet. Please use the <b>Create Plan</b> option to create a plan, or select a sample plan from the list by clicking the <b>Advance</b> button. "
            lblMyPlan.Visible = True
            btnGo.Enabled = False
            txtPlanName.Enabled = False
            lblerror.Visible = False

        End If

    End Sub

    Private Function ValidateFields() As Boolean
        If Trim(txtPlanName.Text) = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGo.Click

        lblerror.Text = ""

        If Not ValidateFields() Then
            lblerror.Visible = True
            lblerror.Text = "Enter criteria for search"
            Exit Sub
        End If
        Dim planname As String
        Dim strName As String
        planname = txtPlanName.Text

        Dim ds As DataSet
        ds = Plan.SearchPlanByName(GetConnectionData, planname)


        If (ds.Tables(0).Rows.Count <= 0) Then
            lblerror.Text = ResMgr.GetString("BizPlan_Services_Plan_SearchPlan_Plan_lblError2")
            lblerror.Visible = True
            txtPlanName.Text = ""

            Exit Sub
        End If
        ExistingPlanGrid.AllowPaging = True
        ExistingPlanGrid.CurrentPageIndex = 0
        ExistingPlanGrid.DataSource = ds.Tables(0)
        ExistingPlanGrid.DataBind()

    End Sub

    Private Sub btnAdvSearch_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnAdvSearch.Click

        PanelSmaplePlans.Visible = True
        PanelUserPlans.Visible = False
        lblSmaplePlans.Text = "Following is a list of sample plans. Please import/open a plan by clicking on its name."
        lblSmaplePlans.CssClass = "lblhelpMessage"
        BtnBack.Visible = True
        Panelbtnback.Visible = True
    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        PanelSmaplePlans.Visible = False
        PanelUserPlans.Visible = True

        Panelbtnback.Visible = False
        lblerror.Text = ""
        lblerror.Visible = False
    End Sub
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Response.Redirect("/InfiniPlan/Services/Plan/EnterpriseSpeedoemeter.aspx")

    End Sub

    Private Sub SamplePlanGrid_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles SamplePlanGrid.ItemDataBound
        'If e.Item.ItemType = ListItemType.Header Then
        '    Dim i As Integer
        '    For i = 0 To e.Item.Cells.Count - 1
        '        e.Item.Cells(i).CssClass = "GridHeaderBar"
        '    Next
        'End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridInnerLines"
            Next
        End If
    End Sub
End Class
