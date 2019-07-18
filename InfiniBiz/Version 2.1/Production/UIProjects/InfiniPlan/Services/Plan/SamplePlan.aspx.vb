
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing

Public Class SamplePlan
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblSmaplePlans As System.Web.UI.WebControls.Label
    Protected WithEvents SamplePlanGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlSamplePlans As System.Web.UI.WebControls.Panel
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlanName As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents imgerror As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents BtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnAdvSearch As System.Web.UI.WebControls.LinkButton

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
                ' Sample Plan Grid
        Me.SamplePlanGrid.Columns(0).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlan")
        Me.SamplePlanGrid.Columns(1).HeaderText = ResMgr.GetString("bizplanweb_services_plan_opensamplsplan_OpenPlanDescription")
        'recent plan grid





    End Sub
#End Region
    Dim ObjCustomer As CustomerStatus
    Dim BoolStatus As Boolean

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        HttpContext.Current.Session("CopyPlanid") = Nothing
        SetProWebCustomer = BoolStatus

      
        

        PageLoadSetting()

            
    End Sub

    Public Sub PageLoadSetting()

        Try
 
        Session("Bar") = Nothing
        CurPage = 1
        CurItem = 0
        OpenSamplePlan()
        Session("LinkTable") = Nothing
        Session("LinkChart") = Nothing
        imgerror.Visible = False
        lblerror.Text = " "
        Session("Tracker") = 1
        Session("strMeterId") = Nothing
        Session("strSystemId") = Nothing
        Session("strMeterIdIO") = Nothing
        Session("strSystemIdIO") = Nothing
        Session("dateTo") = Nothing
        Session("dateFrom") = Nothing
        Session("date") = Nothing
        Session("test") = Nothing
        pnlSamplePlans.Visible = True
        lblSmaplePlans.Text = "Following is a list of sample plans. Please import/open a plan by clicking on its name.You can search Sample plan name."
        lblSmaplePlans.CssClass = "lblhelpMessage"

        Catch ex As Exception
            Dim strError As String = ex.Message
            imgerror.Visible = True
            lblerror.Text = "You can not import plan. Please try later in few minutes."
            imgerror.Visible = True
        End Try

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

    Private Sub SamplePlanGrid_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles SamplePlanGrid.ItemCreated
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            e.Item.Attributes.Add("onmousemove", "this.className='Grid_OnMouseMove1';")      'e.Item.Attributes.Add("onmousemove", "this.style.backgroundColor='#ECF4FC';")
            e.Item.Attributes.Add("onmouseout", "this.className='GridBody';")        'e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white';")
        End If
    End Sub

    Private Sub SamplePlanGrid_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles SamplePlanGrid.PageIndexChanged

        SamplePlanGrid.CurrentPageIndex = e.NewPageIndex

        Dim plansTable As DataTable
        plansTable = Plan.GetSamplePlansListFromRemoteServer(GetConnectionData)

        SamplePlanGrid.DataSource = plansTable
        SamplePlanGrid.DataBind()

    End Sub

    Private Sub OpenSamplePlan()

        Dim planID As String
        '  If Not Page.IsPostBack Then
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
                SamplePlanGrid.DataSource = plansTable.DefaultView
                SamplePlanGrid.DataBind()
            Else
                SamplePlanGrid.Visible = False
                'lblMyPlan.ForeColor = Color.Red



            End If
        End If

        lblerror.Visible = False
        imgerror.Visible =  False
        '    End If
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
            imgerror.Visible = True
            lblerror.Text = "Enter Plan name to search."
            Exit Sub
        End If
        Dim planname As String
        Dim strName As String
        planname = txtPlanName.Text

        Dim ds As DataSet
        ds = Plan.SearchSamplePlanByName(GetConnectionData, Trim(planname))


        If (ds.Tables(0).Rows.Count <= 0) Then
            lblerror.Text = ResMgr.GetString("BizPlan_Services_Plan_SearchPlan_Plan_lblError2")
            lblerror.Visible = True
            txtPlanName.Text = ""

            Exit Sub
        End If
        SamplePlanGrid.AllowPaging = True
        SamplePlanGrid.CurrentPageIndex = 0
        SamplePlanGrid.DataSource = ds.Tables(0)
        SamplePlanGrid.DataBind()
        BtnBack.Visible = True

    End Sub

    Private Sub BtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        txtPlanName.Text = ""
        BtnBack.Visible = False
        PageLoadSetting()
    End Sub
End Class
