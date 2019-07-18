Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web

Public Class PlanWizardView
    ' Inherits System.Web.UI.Page
    Inherits PlanWizardBase
    Dim IPquery As IPlanWizardQuery
    Public Symbol As String
    Public ObjPlan As Plan
    Public CurrencyName As String
    Public loopCount As Integer
    Public DDLOptions As DataSet
    Private redirectURL As String
    Public dtCurrency As DataTable
    Dim dtUserRigths As DataTable
#Region "Members Declaration"

    Private query As New PlanWizardQuery
    Private queryResponse As New PlanWizardResponse
    Private controller As PlanWizardController
    Friend WithEvents model As IPlanWizardModel
    Protected WithEvents valRE As System.Web.UI.WebControls.RegularExpressionValidator
    Protected WithEvents valRequired As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents valRange As System.Web.UI.WebControls.RangeValidator
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblText As System.Web.UI.WebControls.Label
    Protected WithEvents optFirst As System.Web.UI.WebControls.RadioButton
    Protected WithEvents optSecond As System.Web.UI.WebControls.RadioButton
    Protected WithEvents optThird As System.Web.UI.WebControls.RadioButton
    Protected WithEvents cmbDateMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtAnswer As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtDateYear As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents lblUnit As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlanWizardHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents DDlCurrency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents hdnIsNew As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnStatus As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Private optArray(3) As System.web.UI.WebControls.RadioButton

#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents PlanWizardNav1 As Infinilogic.BusinessPlan.Web.PlanWizardNav
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        InitiliazeLanguage()
    End Sub
    Private Sub InitiliazeLanguage()
        Me.btnBack.Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_btnBack")
        Me.btnCancel.Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_btnCancel")
        Me.btnNext.Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_btnNext")
        Me.btnFinish.Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_btnFinish")
        Me.lblPlanWizardHeading.Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_lblPlanWizardHeading")
        CType(Me.PlanWizardNav1.FindControl("lblPlanNavTitle"), Label).Text = ResMgr.GetString("bizplanweb_services_planwizard_palnwizerdview_lblPlanNavTitle")
    End Sub
#End Region

#Region "Event Handlers"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim Plan As BusinessPlan.BLL.BusinessPlan
        Session("Bar") = Nothing
        If Page.IsPostBack Then
            Plan = CType(Session.Item("plan"), BusinessPlan.BLL.BusinessPlan)
            Dim wizState As WizardState = CType(Session.Item("state"), WizardState)
            Dim qry As IPlanWizardQuery = CType(Session.Item("query"), IPlanWizardQuery)
            model = PlanWizardManager.GetModel(GetConnectionData, Plan, qry.ViewID, wizState)
            If Not (qry.ViewID = PlanQueries.PlanParticulars Or qry.ViewID = PlanQueries.bPlanParticulars Or qry.ViewID = PlanQueries.PlanStartAndTitle Or qry.ViewID = PlanQueries.bPlanStartAndTitle) Then
                query = CType(qry, PlanWizardQuery)
            End If
            If Plan.PlanID = Nothing Then
                Session("Bar") = 1
            Else
                Session("Bar") = Nothing
            End If
        Else
            If IsPlanOpened Then 'Not IsNothing(Request.QueryString("queryID")) Then
                Dim wizState As WizardState = CType(Session.Item("state"), WizardState)
                If Not IsNothing(Request.QueryString("queryID")) Then
                    Plan = CType(Session.Item("plan"), BusinessPlan.BLL.BusinessPlan)
                    query.ViewID = CType(CInt(Request.QueryString("queryID")), PlanQueries)
                Else
                    If CInt(Session("currency")) = 1 Then
                        Plan = New BusinessPlan.BLL.BusinessPlan(CurrentPlan)
                        query.ViewID = PlanQueries.Currency
                        Session("currency") = Nothing
                    Else
                        Plan = New BusinessPlan.BLL.BusinessPlan(CurrentPlan)
                        query.ViewID = PlanQueries.businessType
                    End If


                End If
                model = PlanWizardManager.GetModel(GetConnectionData, query.ViewID, Plan, False, wizstate.isBasic)
                hdnIsNew.Value = "0"
                PlanWizardNav1.Visible = True
            Else
                Dim wizState As WizardState = CType(Session.Item("state"), WizardState)
                If Not IsNothing(Request.QueryString("queryID")) Then
                    Plan = CType(Session.Item("plan"), BusinessPlan.BLL.BusinessPlan)
                    query.ViewID = CType(CInt(Request.QueryString("queryID")), PlanQueries)
                    model = PlanWizardManager.GetModel(GetConnectionData, query.ViewID, Plan, True, wizstate.isBasic)
                Else
                    model = PlanWizardManager.GetModel(GetConnectionData)
                    Session("Bar") = 1
                End If

                hdnIsNew.Value = "1"
                PlanWizardNav1.Visible = False
            End If
        End If

        controller = New PlanWizardController(model)

        'Control Settings==============================
        optArray.SetValue(optFirst, 0)
        optArray.SetValue(optSecond, 1)
        optArray.SetValue(optThird, 2)
        lblError.Text = ""

        If Not Page.IsPostBack Then


            'Populating the month names drop down
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

            'Populating the currency drop down
            dtCurrency = ObjPlan.GetCurrencySymbols(GetConnectionData).Tables(0)
            For i As Integer = 0 To dtCurrency.Rows.Count - 1

                DDlCurrency.Items.Add(New ListItem(CType(dtCurrency.Rows(i).Item(0), String), CType(dtCurrency.Rows(i).Item(1), String)))
            Next

            controller.viewStart()

        End If

        hdnStatus.Value = "1"
        AddToSession()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session("Bar") = Nothing
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
        If btnBack.Text = "  Yes " Then
            Session("Bar") = Nothing
            controller.viewSave(True)

        Else
            setResponse()
            Try
                controller.viewBack(queryResponse)
            Catch ex As BizPlanException
                lblError.Text = ex.Message
                LoadNavBar()
            End Try

            If redirectURL <> "" Then
                Response.Redirect(redirectURL)
            End If

        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If btnNext.Text = " No  " Then
            IPquery = model.GetPlanWizardQuery()
            Dim a As String
            a = controller.GetNextView(IPquery.ViewID)
            If (a <> "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx") Then
                redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
                Response.Redirect(redirectURL)
            End If
            btnFinish.Visible = True
            btnNext.Text = " Next "
            btnBack.Text = " Back "
            controller.viewSave(False)
            query = CType(model.GetPlanWizardQuery(), PlanWizardQuery)
            UpdateView()
        Else
            setResponse()
            Try
                controller.viewNext(queryResponse)
            Catch ex As Exception
                lblError.Text = ex.Message
                LoadNavBar()
            End Try
            If redirectURL <> "" Then
                Response.Redirect(redirectURL)
            End If

        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Session("Bar") = Nothing
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
        'Dim IPquery As IPlanWizardQuery
        IPquery = model.GetPlanWizardQuery()
        Dim a As String
        a = controller.GetNextView(IPquery.ViewID)
        If (a <> "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx") Then
            redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
            Return
        End If

        query = CType(IPquery, PlanWizardQuery)
        UpdateView()
        AddToSession()
    End Sub

    Private Sub Model_Started() Handles model.WizardStarted
        ' Dim IPquery As IPlanWizardQuery
        IPquery = model.GetPlanWizardQuery()
        Dim a As String = controller.GetNextView(IPquery.ViewID)

        If (a <> "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx") Then
            redirectURL = a & "?queryid=" & CInt(IPquery.ViewID)
            Return
        End If

        query = CType(IPquery, PlanWizardQuery)
        UpdateView()
        AddToSession()
    End Sub


    Private Sub Model_Finished(ByVal exists As Boolean, ByVal errMessoage As String) Handles model.WizardFinished
        If exists Then
            lblText.Text = errMessoage
            btnNext.Text = " No  "
            btnNext.Enabled = True
            btnBack.Text = "  Yes "
            btnBack.Enabled = True
            'Hide Various Controls
            btnFinish.Visible = False
            txtAnswer.Visible = False
            optFirst.Visible = False
            optSecond.Visible = False
            optThird.Visible = False
            optFirst.Checked = False
            optSecond.Checked = False
            optThird.Checked = False
            txtDateYear.Visible = False
            cmbDateMonth.Visible = False
            hdnStatus.Value = "1"
            PlanWizardNav1.CurrentPlan = model.GetPlanSettingsList()
            AddToSession()
        Else
            controller.viewSave(True)
        End If
    End Sub

    Private Sub Model_PlanCreated(ByVal planName As String) Handles model.NewPlanCreated
      



        If Not Session("merchantProUserID") Is Nothing Then
            Dim da As Array
            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String))
            da = dtUserRigths.Select(" Modelid  = 68  ")
            If da.Length > 0 Then
                PlanSettings(planName)
                Response.Redirect("/InfiniPlan/services/welcome.aspx")
            Else
                Response.Redirect("/InfiniPlan/Services/Plan/home.aspx")
            End If
        Else
            PlanSettings(planName)
            Response.Redirect("/InfiniPlan/services/welcome.aspx")
        End If


    End Sub

    Public Sub PlanSettings(ByVal planName As String)
        BusinessPlanSummary = Plan.GetBusinessSummary(GetConnectionData, planName)
        If CurrentPlan.IsOngoing Then
            CurrentPlan.PastPerformanceData = PastPerformance.GetPastPerformance(GetConnectionData, CurrentPlan.PlanID)
        Else
            CurrentPlan.StartupData = StartupDetails.GetStartup(GetConnectionData, CurrentPlan)
        End If
        RemoveFromSession()
        hdnStatus.Value = "2"
    End Sub
#End Region

#Region "Private Helper Mehods"
    Private Sub setResponse()
        queryResponse = New BusinessPlan.BLLRules.PlanWizardResponse
        queryResponse.ViewID = query.ViewID
        If query.ViewType = QuestionTypes.calendarDate Then
            queryResponse.SelectionText = cmbDateMonth.SelectedItem.Value

            If IsNumeric(txtDateYear.Text) And query.ViewType = QuestionTypes.calendarDate Then
                queryResponse.SelectionID = CInt(txtDateYear.Text)
            Else
                queryResponse.SelectionID = 0
            End If
 
        ElseIf query.ViewType = QuestionTypes.Currency Then
            'Dim dsGetValue As DataSet = ObjPlan.GetListValue(GetConnectionData, DDlCurrency.SelectedItem.Value)
            'queryResponse.SelectionText = CType(dsGetValue.Tables(0).Rows(0).Item(0), String)
            queryResponse.SelectionText = DDlCurrency.SelectedItem.Value
        Else
            queryResponse.SelectionText = txtAnswer.Text
            If optFirst.Checked = True Then
                queryResponse.SelectionID = 0
            ElseIf optSecond.Checked = True Then
                queryResponse.SelectionID = 1
            ElseIf optThird.Checked = True Then
                queryResponse.SelectionID = 2
            End If
        End If

    End Sub

    Private Sub UpdateView()
        lblTitle.Text = ResMgr.GetString(query.Title)
        lblText.Text = ResMgr.GetString(query.Text)
        lblHelp.Text = ResMgr.GetString(query.HelpText)
        'lblTitle.Text = query.Title
        'lblText.Text = query.Text
        'lblHelp.Text = query.HelpText
        txtAnswer.Text = query.SelectionText

        txtAnswer.Visible = False
        optFirst.Visible = False
        optSecond.Visible = False
        optThird.Visible = False
        optFirst.Checked = False
        optSecond.Checked = False
        optThird.Checked = False
        txtDateYear.Visible = False
        cmbDateMonth.Visible = False
        DDlCurrency.Visible = False
        If query.ViewID = PlanQueries.finish Then
            btnNext.Enabled = False
            btnBack.Enabled = True
        ElseIf query.ViewID = PlanQueries.start Then
            btnNext.Enabled = True
            btnBack.Enabled = False
        ElseIf (query.ViewID = PlanQueries.planDescription Or query.ViewID = PlanQueries.bPlanDescription) And model.GetWizardState().isNew = False Then
            btnNext.Enabled = False
            btnBack.Enabled = True
        ElseIf (query.ViewID = PlanQueries.businessType Or query.ViewID = PlanQueries.bBusinessType) And model.GetWizardState().isNew = False Then
            btnNext.Enabled = True
            btnBack.Enabled = False
        Else
            btnNext.Enabled = True
            btnBack.Enabled = True
        End If

        'Conttrols Settings
        If query.ViewType = QuestionTypes.text Then
            txtAnswer.Visible = True
        ElseIf query.ViewType = QuestionTypes.Currency Then
            DDlCurrency.Visible = True
            ' DDlCurrency.SelectedValue = query.SelectionText
            DDlCurrency.SelectedValue = CStr(HttpContext.Current.Session("CurrencyValue"))
        ElseIf query.ViewType = QuestionTypes.yesNo Then
            optFirst.Visible = True
            optSecond.Visible = True
            optFirst.Text = ResMgr.GetString("PW_Options_Yes")
            optSecond.Text = ResMgr.GetString("PW_Options_No")
            If query.SelectionID = 0 Then
                optSecond.Checked = True
            Else
                optFirst.Checked = True
            End If
        ElseIf query.ViewType = QuestionTypes.options Then
            txtAnswer.Visible = False
            For i As Integer = 0 To query.OptionItemList.Count - 1
                optArray(i).Visible = True
                optArray(i).Text = ResMgr.GetString(query.OptionItemList(i).OptionText)
                If i = query.SelectionID Then optArray(i).Checked = True
            Next
        ElseIf query.ViewType = QuestionTypes.calendarDate Then
            txtDateYear.Visible = True
            cmbDateMonth.Visible = True
            txtDateYear.Text = query.SelectionID.ToString()
            cmbDateMonth.SelectedValue = query.SelectionText
            lblUnit.Text = ""
        ElseIf query.ViewType = QuestionTypes.none Then

        End If
  
        LoadNavBar()
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
 
            PlanWizardNav1.CurrentView = query.ViewID
      Dim getAll As QuerySettingsList = model.GetPlanSettingsList()
        Dim intQueryCount As Integer = getAll.Count
        Dim intloop As Integer
        For intloop = 0 To intQueryCount - 1
            getAll.item(intloop).QueryName = ResMgr.GetString(getAll.item(intloop).QueryName)
        Next
        PlanWizardNav1.CurrentPlan = getAll
    End Sub
#End Region

End Class
