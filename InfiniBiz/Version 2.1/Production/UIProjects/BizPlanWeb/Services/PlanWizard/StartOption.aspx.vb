Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web

Public Class StartOption
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase

#Region "Members Declaration"

    Private query As New MultipleQueryList
    Private queryResponse As New MultipleResponseList
    Private controller As PlanWizardController
    Friend WithEvents model As IPlanWizardModel
    Private redirectURL As String

    'Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents txtAnswer As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    'Protected WithEvents hdnIsNew As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnStatus As System.Web.UI.HtmlControls.HtmlInputHidden


#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents cmbDateMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtDateYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents hdnIsNew As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents txtTitle As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim Plan As BusinessPlan.BLL.BusinessPlan

        If Page.IsPostBack Then
            Plan = CType(Session.Item("plan"), BusinessPlan.BLL.BusinessPlan)
            Dim wizState As WizardState = CType(Session.Item("state"), WizardState)
            query = CType(Session.Item("query"), MultipleQueryList)
            model = PlanWizardManager.GetModel(GetConnectionData, Plan, query.ViewID, wizState)
        Else
            If Not IsNothing(Request.QueryString("queryID")) Then
                Plan = CType(Session.Item("plan"), BusinessPlan.BLL.BusinessPlan)
                query.ViewID = CType(CInt(Request.QueryString("queryID")), PlanQueries)
            Else
                Plan = New BusinessPlan.BLL.BusinessPlan(CurrentPlan)
                query.ViewID = PlanQueries.businessType
            End If

            Dim wizState As WizardState = CType(Session.Item("state"), WizardState)
            model = PlanWizardManager.GetModel(GetConnectionData, query.ViewID, Plan, True, wizstate.isBasic)
            'hdnIsNew.Value = "0"
            'PlanWizardNav1.Visible = True
            'model = PlanWizardManager.GetModel(GetConnectionData)
            hdnIsNew.Value = "1"
            'PlanWizardNav1.Visible = False
        End If

        controller = New PlanWizardController(model)

        If Not Page.IsPostBack Then
            controller.viewStart()

            cmbDateMonth.Items.Add(New ListItem("January", "Jan"))
            cmbDateMonth.Items.Add(New ListItem("February", "Feb"))
            cmbDateMonth.Items.Add(New ListItem("March", "Mar"))
            cmbDateMonth.Items.Add(New ListItem("April", "Apr"))
            cmbDateMonth.Items.Add(New ListItem("May", "May"))
            cmbDateMonth.Items.Add(New ListItem("June", "Jun"))
            cmbDateMonth.Items.Add(New ListItem("July", "Jul"))
            cmbDateMonth.Items.Add(New ListItem("August", "Aug"))
            cmbDateMonth.Items.Add(New ListItem("September", "Sep"))
            cmbDateMonth.Items.Add(New ListItem("October", "Oct"))
            cmbDateMonth.Items.Add(New ListItem("November", "Nov"))
            cmbDateMonth.Items.Add(New ListItem("December", "Dec"))
        End If

        lblHelp.Visible = True
        'hdnStatus.Value = "1"
        AddToSession()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        hdnStatus.Value = "2"
        setResponse()
        controller.viewCancel(queryResponse)
        If hdnIsNew.Value = "1" Then

        Else
            'BusinessPlanSummary = Plan.GetBusinessSummary(GetConnectionData, CurrentPlan.PlanName)
            'If CurrentPlan.IsOngoing Then
            '    CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
            'Else
            '    CurrentPlan.StartupData = Startup.GetStartup(GetConnectionData, CurrentPlan)
            'End If
        End If
        RemoveFromSession()
        Response.Redirect("/InfiniPlan/services/welcome.aspx")
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        If btnBack.Text = "  Yes  " Then
            controller.viewSave(True)
        Else
            setResponse()
            Try
                controller.viewBack(queryResponse)
            Catch ex As Exception
                lblError.Text = ex.Message

            End Try

            If redirectURL <> "" Then
                Response.Redirect(redirectURL)
            End If

        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        If btnNext.Text = "  No  " Then

            Dim IPquery As IPlanWizardQuery

            IPquery = model.GetPlanWizardQuery()
            Dim a As String = controller.GetNextView(IPquery.ViewID)

            If (a <> "/InfiniPlan/Services/PlanWizard/MultiOptions.aspx") Then
                redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
                'Response.Redirect(redirectURL)
            End If

        Else
            setResponse()
            Try
                controller.viewNext(queryResponse)
            Catch ex As Exception
                lblError.Text = ex.Message

            End Try

            If redirectURL <> "" Then
                Response.Redirect(redirectURL)
            End If

        End If

    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        hdnStatus.Value = "0"
        setResponse()
        Try
            controller.viewFinish(queryResponse)
        Catch ex As Exception
            lblError.Text = ex.Message
            LoadNavBar()
        End Try

    End Sub

#End Region

#Region "Model Event Handlers"

    Private Sub Model_Changed() Handles model.StateChanged

        Dim IPquery As IPlanWizardQuery

        IPquery = model.GetPlanWizardQuery()
        Dim a As String = controller.GetNextView(IPquery.ViewID)

        If (a <> "/InfiniPlan/Services/PlanWizard/StartOption.aspx") Then
            redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
            Return
        End If

        query = CType(IPquery, MultipleQueryList)
        UpdateView()
        AddToSession()

    End Sub

    Private Sub Model_Started() Handles model.WizardStarted

        Dim IPquery As IPlanWizardQuery
        IPquery = model.GetPlanWizardQuery()
        Dim a As String = controller.GetNextView(IPquery.ViewID)

        If (a <> "/InfiniPlan/Services/PlanWizard/StartOption.aspx") Then
            redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
            Return
        End If

        query = CType(IPquery, MultipleQueryList)
        UpdateView()
        AddToSession()

    End Sub

    Private Sub Model_Finished(ByVal exists As Boolean, ByVal errMessoage As String) Handles model.WizardFinished
        If exists Then
            lblText.Text = errMessoage
            btnNext.Text = "  No  "
            btnNext.Enabled = True
            btnBack.Text = "  Yes  "
            'Hide Various Controls
            btnFinish.Visible = False
            txtDateYear.Visible = False
            cmbDateMonth.Visible = False
            txtTitle.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            lblHelp.Visible = False

            hdnStatus.Value = "1"
            AddToSession()
        Else
            controller.viewSave(True)
        End If
    End Sub

    Private Sub Model_PlanCreated(ByVal planName As String) Handles model.NewPlanCreated
        BusinessPlanSummary = Plan.GetBusinessSummary(GetConnectionData, planName)
        If CurrentPlan.IsOngoing Then
            CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
        Else
            CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
        End If
        RemoveFromSession()
        'hdnStatus.Value = "2"
        Response.Redirect("/InfiniPlan/services/welcome.aspx")
    End Sub

#End Region

#Region "Private Helper Mehods"

    Private Sub setResponse()

        Dim response As PlanWizardResponse = New PlanWizardResponse
        response.SelectionText = txtTitle.Text
        queryResponse.Add(response)

        response = New PlanWizardResponse
        response.SelectionText = cmbDateMonth.SelectedItem.Value
        response.SelectionID = CInt(txtDateYear.Text)
        queryResponse.Add(response)

        queryResponse.ViewID = query.ViewID

    End Sub

    Private Sub UpdateView()

        txtTitle.Text = query.item(0).SelectionText
        txtDateYear.Text = query.item(1).SelectionID.ToString()
        cmbDateMonth.SelectedValue = query.item(1).SelectionText

    End Sub

    Private Sub AddToSession()
        Session.Add("query", model.GetPlanWizardQuery())
        Session.Add("plan", model.GetPlan())
        Session.Add("state", model.GetWizardState())
    End Sub

    Private Sub RemoveFromSession()
        Session.Remove("query")
        Session.Remove("plan")
        Session.Remove("state")
    End Sub

    Private Sub LoadNavBar()
        'PlanWizardNav1.CurrentView = query.ViewID
        'PlanWizardNav1.CurrentPlan = model.GetPlanSettingsList()
    End Sub
#End Region

End Class
