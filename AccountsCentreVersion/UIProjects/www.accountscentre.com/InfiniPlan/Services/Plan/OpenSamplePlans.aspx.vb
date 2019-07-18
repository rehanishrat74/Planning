#Region "Imports "
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Web.Common
#End Region
Public Class OpenSamplePlans
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents dgPlanList As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        Me.dgPlanList.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlan")
        Me.dgPlanList.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlanDescription")
    End Sub

#End Region

#Region "PAGE_LOAD"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        CurPage = -1
        CurItem = -1

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
                    lblMessage.Visible = False
                    dgPlanList.DataSource = plansTable.DefaultView
                    dgPlanList.DataBind()
                Else
                    dgPlanList.Visible = False
                    lblMessage.CssClass = "lblErrosMessage"    'lblMessage.ForeColor = Color.Red
                    lblMessage.Text = "There are no existing plans available."
                End If
            End If

        End If
    End Sub

#End Region
    
    '#Region "EVENTS"
    '    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
    '        If rdpYes.Checked = True Then 'OVERWRITE PREVIOUS PLAN.
    '            BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, CInt(ViewState("PlanID")), CInt(ViewState("PlanIDToBeOverWritten")), "")
    '            If CurrentPlan.IsOngoing Then
    '                CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
    '            Else
    '                CurrentPlan.StartupData = Startup.GetStartup(GetConnectionData, CurrentPlan)
    '            End If
    '            Response.Redirect("/BizPlanWeb/Services/Welcome.aspx")
    '        Else 'INSERT PLAN WITH NEW NAME. 
    '            If ValidateInput() Then
    '                BusinessPlanSummary = Plan.CopyPlanAndGetBusinessPlanSummary(GetConnectionData, CInt(ViewState("PlanID")), -1, txtPlanName.Text)
    '                If CurrentPlan.IsOngoing Then
    '                    CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
    '                Else
    '                    CurrentPlan.StartupData = Startup.GetStartup(GetConnectionData, CurrentPlan)
    '                End If
    '                Response.Redirect("/BizPlanWeb/Services/Welcome.aspx")
    '            End If
    '        End If
    '    End Sub
    '#End Region

    Private Sub dgPlanList_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgPlanList.PageIndexChanged

        dgPlanList.CurrentPageIndex = e.NewPageIndex

        Dim plansTable As DataTable
        plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)

        dgPlanList.DataSource = plansTable
        dgPlanList.DataBind()

    End Sub
End Class
