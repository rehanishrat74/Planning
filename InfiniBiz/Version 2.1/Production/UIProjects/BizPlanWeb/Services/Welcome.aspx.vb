Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Text

Public Class Welcome
    Inherits PlanBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTableHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lnkText As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkTable As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkCharts As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanPreview As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkExportPlan As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkClosePlan As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Public ObjPlan As Plan
    Protected WithEvents ImagebuttonText As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonTable As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonChart As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonPreview As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonExport As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonClose As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
        Protected WithEvents lnkPlanTracker As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ImagebuttonTracker As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents lnkPrint As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanWizard As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanMeter As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ImagebuttonPrint As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonWizarf As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonMeter As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
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
          Me.lnkCharts.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkCharts")
        Me.lnkText.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkText")
        Me.lnkTable.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkTable")
        Me.lnkPlanWizard.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanWizard")
        Me.lnkPrint.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPrint")

        Me.lnkPlanTracker.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanTracker")


        Me.lnkPlanMeter.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanMeter")


        Me.lnkClosePlan.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkClosePlan")
      
    End Sub
    Private _pageID As Integer = -1
    Dim Check As Boolean
    Dim dtUserRigths As DataTable
    Dim ObjCustomer As CustomerStatus
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim BoolStatus As Boolean
        BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        SetProWebCustomer = BoolStatus
         
        If CurrentPlan.PlanID = Nothing Then

            Response.Redirect("/InfiniPlan/Services/Plan/PlanManager.aspx")
        Else

            Dim strCurrencyStatus As DataSet = ObjPlan.GetProfileCurrency(GetConnectionData, CurrentPlan.PlanID)
            SetCustomerCurrency = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
            Session("CurrecnyName") = CType(strCurrencyStatus.Tables(0).Rows(0).Item(1), String)
            Check = GetProWebCustomer
            If Check = True Then
                If Not IsNothing(Request.QueryString("cmd")) Then _pageID = CInt(Request.QueryString("cmd"))
                If _pageID < 0 Then
                Else
                    CheckTrueSettings(_pageID)
                End If
            Else
                If Not IsNothing(Request.QueryString("cmd")) Then _pageID = CInt(Request.QueryString("cmd"))
                If _pageID < 0 Then
                Else
                    If (Not Page.IsPostBack) Then
                        lnkPlanMeter.Visible = False
                        lnkPlanTracker.Visible = False
                        ImagebuttonTracker.Visible = False
                        ImagebuttonMeter.Visible = False
                        CheckFalseSettings(_pageID)
                    End If
                End If
            End If

            If Not Session("merchantProUserID") Is Nothing Then

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String))
                Dim dr As DataRow
                If dtUserRigths.Select("  Modelid  = 64 ").Length > 0 Then lnkText.Visible = True : ImagebuttonText.Visible = True
                If dtUserRigths.Select("  Modelid  = 65 ").Length > 0 Then lnkTable.Visible = True : ImagebuttonTable.Visible = True
                If dtUserRigths.Select("  Modelid  = 66 ").Length > 0 Then lnkCharts.Visible = True : ImagebuttonChart.Visible = True
                If dtUserRigths.Select("  Modelid  = 67 ").Length > 0 Then lnkPrint.Visible = True : ImagebuttonPrint.Visible = True
                If dtUserRigths.Select("  Modelid  = 68 ").Length > 0 Then lnkPlanWizard.Visible = True : ImagebuttonWizarf.Visible = True
                If dtUserRigths.Select("  Modelid  = 69 ").Length > 0 Then lnkPlanTracker.Visible = True : ImagebuttonTracker.Visible = True
                If dtUserRigths.Select("  Modelid  =70 ").Length > 0 Then lnkPlanMeter.Visible = True : ImagebuttonMeter.Visible = True


            Else
                If Check = True Then
                    ImagebuttonText.Visible = True

                    ImagebuttonTable.Visible = True
                    ImagebuttonChart.Visible = True

                    ImagebuttonTracker.Visible = True
                    ImagebuttonPrint.Visible = True
                    ImagebuttonMeter.Visible = True
                    ImagebuttonWizarf.Visible = True

                    lnkText.Visible = True
                    lnkTable.Visible = True
                    lnkCharts.Visible = True
                    lnkPrint.Visible = True
                    lnkPlanWizard.Visible = True
                    lnkPlanTracker.Visible = True
                    lnkPlanMeter.Visible = True
                Else
                    ImagebuttonText.Visible = True

                    ImagebuttonTable.Visible = True
                    ImagebuttonChart.Visible = True


                    ImagebuttonPrint.Visible = True

                    ImagebuttonWizarf.Visible = True

                    lnkText.Visible = True
                    lnkTable.Visible = True
                    lnkCharts.Visible = True
                    lnkPrint.Visible = True
                    lnkPlanWizard.Visible = True

                End If
            End If
            CurPage = 0
            CurItem = 0

            If Not Request.QueryString("MeteridQID") Is Nothing Then
                Response.Redirect("/InfiniPlan/Services/MeterWizard/Speedometer.aspx?" + CType(Session("Speedometer"), String))
            End If
        End If
    End Sub

    Public Sub SessionSettings()
        Session("CALL") = 0
        Session("clipval") = Nothing
        Session("STG") = Nothing
        Session("selectedval") = Nothing
        Session("List") = Nothing
        Session("QID") = Nothing
        Session("bit") = Nothing
        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        Session("singleproduct") = Nothing
        Session("LoadList") = Nothing
        Session("ds") = Nothing
        Session("MID") = Nothing
        Session("MName") = Nothing
        Session("FLAnalysisid") = Nothing
    End Sub

    Public Sub CheckTrueSettings(ByVal _pageID As Integer)
        Dim redirectURL As String

        Select Case _pageID

            Case 0 ' if it is table
                redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
            Case 1 ' if it is table
                redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
            Case 2 ' if it is table
                redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"
            Case 3 ' if it is plan preview
                redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx"
                ' redirectURL = "/InfiniPlan/Services/PlanPreview/PlanPreview.htm"

                'Case 5 ' if it is export plan
                '    redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
                'Case 6 ' if it is export plan
                '    redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"

            Case 4
                redirectURL = "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"

            Case 5
                redirectURL = "/InfiniPlan/Services/Business Tracker/PlanTracker.aspx"

            Case 6
                ' redirectURL = "/InfiniPlan/Services/MeterWizard/MeterWizard.aspx"
                redirectURL = "/InfiniPlan/Services/MeterWizard/Speedometer.aspx"
            Case 7
                If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                    redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                Else
                    'otherwise just close the plan that is refresh the sessions.
                    redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                End If
          
            Case Else ' if it is anything Else by Error then 
                redirectURL = "/InfiniPlan/Services/Welcome.aspx"
        End Select
        Response.Redirect(redirectURL)

        If Not Session("test") Is Nothing And Check = True Then

            Session("test") = Nothing
            Response.Redirect("/InfiniPlan/Services/MeterWizard/Speedometer.aspx?" + CType(Session("Speedometer"), String))
            ' Response.Redirect("/InfiniPlan/Services/MeterWizard/MeterWizard.aspx?" + CType(Session("MeterWizard"), String))

        Else
            CurPage = 0
            CurItem = 0
        End If

    End Sub

    Public Sub CheckFalseSettings(ByVal _pageID As Integer)
        Dim redirectURL As String
        Select Case _pageID

            Case 0 ' if it is table
                redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
            Case 1 ' if it is table
                redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
            Case 2 ' if it is table
                redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"
            Case 3 ' if it is plan preview
                redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx"

            Case 4
                redirectURL = "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"

            Case 5

                If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                    redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                Else
                    'otherwise just close the plan that is refresh the sessions.
                    redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                End If
            Case 6

                If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                    redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                Else
                    'otherwise just close the plan that is refresh the sessions.
                    redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                End If

            Case 7

                If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                    redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                Else
                    'otherwise just close the plan that is refresh the sessions.
                    redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                End If
            Case Else ' if it is anything Else by Error then 
                redirectURL = "/InfiniPlan/Services/Welcome.aspx"
        End Select
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkText.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
        Response.Redirect(redirectURL)

    End Sub

    Private Sub lnkHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Welcome.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkTable.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkCharts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkCharts.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkPlanPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanPreview.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/PlanPreview/PlanPreview.htm"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkExportPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportPlan.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkPlanWizard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanWizard.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkClosePlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkClosePlan.Click

        Dim redirectURL As String
        'if it is a sample plan ask for save options.
        If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
            redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
        Else
            'otherwise just close the plan that is refresh the sessions.
            redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
        End If
        Response.Redirect(redirectURL)

    End Sub

    Private Sub lnkPlanTracker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanTracker.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Business%20Tracker/PlanTracker.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPrint.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkPlanMeter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanMeter.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/MeterWizard/Speedometer.aspx"
        Response.Redirect(redirectURL)
    End Sub
End Class
