Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules

Public Class ExportedPlans
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrorMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents SamplePlanGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents SamplePlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents SamplePlanGrid2 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgExportedPlans As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgExportedPlans1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel5 As System.Web.UI.WebControls.Panel

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
        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_plan_exportedplans_lblHeading")

        Me.dgExportedPlans.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_exportedplans_dgExpPlansColExportedPlans")
        Me.dgExportedPlans.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_exportedplans_dgExpPlansColPlanDescription")
        Me.dgExportedPlans.Columns(2).HeaderText = ResMgr.GetString("bizplanweb_services_plan_exportedplans_dgExpPlansCoFileName")
        Me.dgExportedPlans.Columns(3).HeaderText = ResMgr.GetString("bizplanweb_services_plan_exportedplans_dgExpPlansColExportDate")

    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Put user code to initialize the page here
        If Not Page.IsPostBack Then

            Dim businessID As String
            If (Not IsNothing(Request.QueryString("bid"))) Then businessID = CStr(Request.QueryString("bid"))

            If (businessID > "0") Then
                DownloadHandler.DownloadFile(Response, GetConnectionData, businessID)
                'Plan.GetExportedPlan(GetConnectionData, businessID)
            End If
            Dim dt As DataTable = Plan.GetExportedPlansList(GetConnectionData)
            If dt.Rows.Count > 0 Then
                lblMsg.Visible = False
                dgExportedPlans.DataSource = dt
                dgExportedPlans.DataBind()
            Else
                dgExportedPlans.Visible = False
                lblMsg.Text = "No plan have exoprted yet.Please use the export plan option to export a plan "
                lblMsg.CssClass = "lblhelpMessage"

                'lblMsg.ForeColor = Color.Red
                lblMsg.Visible = True
            End If
        End If


        'If GetProWebCustomer = True Then
        '    CurPage = 3
        '    CurItem = 0
        'Else
        '    CurPage = 2
        '    CurItem = 0
        'End If
    
        If GetProWebCustomer = True Then
            CurPage = 3
            CurItem = 0
        Else
            CurPage = 2
            CurItem = 0
        End If
    End Sub

 
    Private Sub dgExportedPlans_PageIndexChanged1(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgExportedPlans.PageIndexChanged
        dgExportedPlans.CurrentPageIndex = e.NewPageIndex
        Dim dtaa As DataTable = Plan.GetExportedPlansList(GetConnectionData)
        dgExportedPlans.DataSource = dtaa
        dgExportedPlans.DataBind()
    End Sub
End Class