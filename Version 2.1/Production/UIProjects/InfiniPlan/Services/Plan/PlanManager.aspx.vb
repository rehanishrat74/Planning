' Modified by Win-Saira 
' Date : 27/02/2006

Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing

Public Class PlanManager
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
    Public bool As Boolean
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlanName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnAdvSearch As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents PanelUserPlans As System.Web.UI.WebControls.Panel
    Protected WithEvents lblSmaplePlans As System.Web.UI.WebControls.Label
    Protected WithEvents PanelSmaplePlans As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents Panelbtnback As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Public ObjPlan As Plan
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
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents SamplePlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents MainTStrip As Microsoft.Web.UI.WebControls.TabStrip
    Protected WithEvents LastPlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ExistingPlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents ExistingPlanGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents imgBtnNewPlan As System.Web.UI.WebControls.Button


    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents mpHoriz As Microsoft.Web.UI.WebControls.MultiPage
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblMyPlan As System.Web.UI.WebControls.Label
    Protected WithEvents lblLastPlan As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel5 As System.Web.UI.WebControls.Panel
    Protected WithEvents space3 As System.Web.UI.WebControls.Label
    Protected WithEvents space2 As System.Web.UI.WebControls.Label

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

        Me.imgBtnNewPlan.Text = ResMgr.GetString("bizplan_services_plan_planmanager_imgBtnNewPlan")
        Me.MainTStrip.Items(0).Text = "New Plan"
        Me.MainTStrip.Items(2).Text = ResMgr.GetString("bizplan_services_plan_planmanager_istMainTStripitem")
        Me.MainTStrip.Items(4).Text = ResMgr.GetString("bizplan_services_plan_planmanager_secMainTStripitem")
        Me.MainTStrip.Items(6).Text = ResMgr.GetString("bizplan_services_plan_planmanager_thrMainTStripitem")
        'exsisting plan grid 
        Me.ExistingPlanGrid.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanName")
        Me.ExistingPlanGrid.Columns(2).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanDescription")
        Me.ExistingPlanGrid.Columns(3).HeaderText = ResMgr.GetString("bizplanweb_services_plan_planmanager_griddate")
        Me.ExistingPlanGrid.Columns(4).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListDeletePlan")
        ' Sample Plan Grid
        Me.SamplePlanGrid.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlan")
        Me.SamplePlanGrid.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlanDescription")
        'recent plan grid
        Me.LastPlanGrid.Columns(2).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanName")
        Me.LastPlanGrid.Columns(3).HeaderText = ResMgr.GetString("bizplanweb_services_plan_openplan_dgPlanListPlanDescription")
        Me.LastPlanGrid.Columns(4).HeaderText = ResMgr.GetString("bizplanweb_services_plan_planmanager_griddate")

    End Sub

#End Region

#Region ".......................Click Events "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        ' imgBtnNewPlan.Atributes.Add("onclick", "javascript:void(0);return StartWizard(0);")

        Session("test") = Nothing
        CurPage = 1
        CurItem = 0
        OpenRecentPlan()
        OpenSamplePlan()
        OpenMyPlan()
        Session("LinkTable") = Nothing
        Session("LinkChart") = Nothing
        imgBtnNewPlan.Attributes.Add("width", CType(Me.imgBtnNewPlan.Text, String))
    End Sub

    Private Sub imgBtnNewPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgBtnNewPlan.Click
        Response.Redirect("/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx")
    End Sub

    Private Sub ExistingPlanGrid_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles ExistingPlanGrid.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim imageDelte As ImageButton
            imageDelte = CType(e.Item.Cells(2).FindControl("Delete"), ImageButton)
            imageDelte.Attributes.Add("onclick", "javascript:return confirm('Do you really want to delete this record ?')")
            ' bool = Plan.BasePlanIDCheck(GetConnectionData, CStr(e.Item.Cells(0).Text))

            'If bool = False Then
            '   imageDelte.Attributes.Add("onclick", "javascript:return confirm('Do you really want to delete this record ?')")
            'Else
            '    imageDelte.Attributes.Add("onclick", "javascript:return alert('You can not delete Base Plan ')")
            'End If

        End If
    End Sub
     
    Private Sub ExistingPlanGrid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles ExistingPlanGrid.ItemCommand
        If e.CommandName = "Delete" Then
            Dim planId As String = CStr(e.Item.Cells(0).Text)
            If planId > "0" Then
                Plan.PermanentlyDeletePlan(GetConnectionData, planId)
                'bool = Plan.BasePlanIDCheck(GetConnectionData, CStr(e.Item.Cells(0).Text))
                'If bool = False Then
                '    Plan.PermanentlyDeletePlan(GetConnectionData, planId)
                'Else

                'End If
                'Refresh the dataGrid.
                Me.BindMyPlanGrid()
            End If
        End If
    End Sub
     Private Sub SamplePlanGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles SamplePlanGrid.PageIndexChanged

        SamplePlanGrid.CurrentPageIndex = e.NewPageIndex

        Dim plansTable As DataTable
        plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)

        SamplePlanGrid.DataSource = plansTable
        SamplePlanGrid.DataBind()

    End Sub

    Private Sub LastPlanGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles LastPlanGrid.PageIndexChanged
        LastPlanGrid.CurrentPageIndex = e.NewPageIndex
        Dim plansTable As DataTable
        plansTable = Plan.GetLastPlan(GetConnectionData)

        LastPlanGrid.DataSource = plansTable.DefaultView
        LastPlanGrid.DataBind()
    End Sub

    Private Sub ExistingPlanGrid_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles ExistingPlanGrid.PageIndexChanged
        ExistingPlanGrid.CurrentPageIndex = e.NewPageIndex
        Dim plansTable As DataTable
        plansTable = Plan.GetPlansList(GetConnectionData)
        ExistingPlanGrid.DataSource = plansTable.DefaultView
        ExistingPlanGrid.DataBind()
    End Sub


#End Region

#Region "....................... Subroutines "

    Private Sub OpenRecentPlan()
        Dim plansTable As DataTable
        plansTable = Plan.GetLastPlan(GetConnectionData)

        LastPlanGrid.DataSource = plansTable.DefaultView
        LastPlanGrid.DataBind()

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
                Else
                    SamplePlanGrid.Visible = False
                    lblMyPlan.CssClass = "lblhelpMessage"   'lblMyPlan.ForeColor = Color.Red


                    lblMyPlan.Text = "No new plan has been created by you, please create a new plan or access a sample plan."
  
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
        Else
            ExistingPlanGrid.Visible = False
            lblMyPlan.CssClass = "lblhelpMessage"      'lblMyPlan.ForeColor = Color.Red
            lblMyPlan.Text = "No new plan has been created by you, please create a new plan or access a sample plan."
            lblMyPlan.Visible = True
            space3.visible = True
        End If

        BindLastPlanGrid()

    End Sub
    
    Private Sub BindLastPlanGrid()
        Dim plansTable As DataTable
        plansTable = Plan.GetLastPlan(GetConnectionData)

        If (plansTable.Rows.Count > 0) Then
            lblLastPlan.Visible = False
            LastPlanGrid.DataSource = plansTable.DefaultView
            LastPlanGrid.DataBind()
        Else
            LastPlanGrid.Visible = False
            lblLastPlan.CssClass = "lblhelpMessage"    'lblLastPlan.ForeColor = Color.Red
            lblLastPlan.Text = "No new plan has been created by you, please create a new plan or access a sample plan"
            lblLastPlan.Visible = True
            space2.visible = True
        End If


    End Sub


#End Region



End Class
