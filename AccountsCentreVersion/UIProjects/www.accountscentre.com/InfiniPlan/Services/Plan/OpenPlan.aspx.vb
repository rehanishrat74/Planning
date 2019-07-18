#Region "Imports "
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Web.Common
#End Region

Public Class OpenPlan
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents dgPlanList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub

#End Region

    Private Sub InitiliazeLanguage()

        Me.dgPlanList.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanName")
        Me.dgPlanList.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanDescription")
        Me.dgPlanList.Columns(2).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListDeletePlan")

    End Sub


#Region "PAGE_LOAD"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        CurPage = -1
        CurItem = -1

        Dim planID As String
        Dim strid As String()
        Dim cmd As String = Request.QueryString("cmd")
        If Not Page.IsPostBack Then
            Dim dt As DataTable

            If Not Request.QueryString("pid") Is Nothing Then

                planID = Request.QueryString("pid")
                If planID.IndexOf(",") > 0 Then
                    strid = planID.Split(","c)
                    planID = strid(0)
                    '  Session("Speedometer") = strid(1)
                    Session("MeterWizard") = strid(1)
                Else
                    planID = planID
                End If

            End If

                If planID > "0" Then
                    HttpContext.Current.Session("CurrencyValue") = ""
                    BusinessPlanSummary = Plan.GetBusinessPlanSummary(GetConnectionData, planID)
                    'BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, planID)
                    If CurrentPlan.IsOngoing Then
                        CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
                    Else
                        CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
                    End If
                    Response.Redirect("/InfiniPlan/Services/Welcome.aspx")
                Else
                    Me.BindGrid()
                    'Dim plansTable As DataTable
                    'If cmd = "samples" Then
                    '    plansTable = Plan.GetSamplePlansList(GetConnectionData)
                    '    'plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)
                    'Else
                    '    plansTable = Plan.GetPlansList(GetConnectionData)
                    'End If

                    'If (plansTable.Rows.Count > 0) Then
                    '    lblMessage.Visible = False
                    '    dgPlanList.DataSource = plansTable.DefaultView
                    '    dgPlanList.DataBind()
                    'Else
                    '    dgPlanList.Visible = False
                    '    lblMessage.ForeColor = Color.Red
                    '    lblMessage.Text = "There are no existing plans available."
                    'End If
                End If
            End If
    End Sub
#End Region

#Region "METHODS"
    Private Sub BindGrid()
        Dim plansTable As DataTable
        plansTable = Plan.GetPlansList(GetConnectionData)

        If (plansTable.Rows.Count > 0) Then
            lblMessage.Visible = False
            dgPlanList.DataSource = plansTable.DefaultView
            dgPlanList.DataBind()
        Else
            dgPlanList.Visible = False
            lblMessage.CssClass = "lblErrosMessage"                 'lblMessage.ForeColor = Color.Red
            lblMessage.Text = "There are no existing plans available."
        End If
    End Sub
#End Region

#Region "EVENTS"
    Private Sub dgPlanList_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgPlanList.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim imageDelte As ImageButton
            imageDelte = CType(e.Item.Cells(2).FindControl("Delete"), ImageButton)
            imageDelte.Attributes.Add("onclick", "javascript:return confirm('Do you really want to delete this record ?')")
        End If
    End Sub
    Private Sub dgPlanList_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgPlanList.ItemCommand
        If e.CommandName = "Delete" Then
            Dim planId As String = CStr(e.Item.Cells(3).Text)
            If planId > "0" Then
                Plan.PermanentlyDeletePlan(GetConnectionData, planId)
                'Refresh the dataGrid.
                Me.BindGrid()
            End If
        End If
    End Sub
#End Region

End Class
