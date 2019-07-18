Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Public Class Welcome
    Inherits PlanBase
    ' Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTableHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Imagebutton2 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton3 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton5 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton6 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton7 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Imagebutton8 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents lnkHome As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkText As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkTable As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkCharts As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanPreview As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkExportPlan As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanWizard As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkClosePlan As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Imagebutton1 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Img1 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents Imagebutton4 As System.Web.UI.HtmlControls.HtmlImage
    Public ObjPlan As Plan
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
        Me.lnkHome.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkHome")
        Me.lnkCharts.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkCharts")
        Me.lnkText.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkText")
        Me.lnkTable.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkTable")
        Me.lnkPlanPreview.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanPreview")
        Me.lnkExportPlan.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkExportPlan")
        Me.lnkPlanWizard.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanWizard")
        Me.lnkClosePlan.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkClosePlan")
        ' Me.lnkPlanLine.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanLine")

    End Sub
    Private _pageID As Integer = -1

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Dim strCurrencyStatus As DataSet = ObjPlan.GetProfileCurrency(GetConnectionData, CurrentPlan.PlanID)

        SetCustomerCurrency = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        Session("CurrecnyName") = CType(strCurrencyStatus.Tables(0).Rows(0).Item(1), String)
        Dim Check As Boolean = GetProWebCustomer
        If Check = True Then
            If Not IsNothing(Request.QueryString("cmd")) Then _pageID = CInt(Request.QueryString("cmd"))

            If _pageID < 0 Then

            Else
                If (Not Page.IsPostBack) Then
                    Dim redirectURL As String
                    Select Case _pageID
                        Case 0
                            redirectURL = "/InfiniPlan/Services/Welcome.aspx"
                        Case 1 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
                        Case 2 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
                        Case 3 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"
                        Case 4 ' if it is plan preview
                            redirectURL = "/InfiniPlan/Services/PlanPreview/PlanPreview.htm"
                        Case 5 ' if it is export plan
                            redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
                        Case 6 ' if it is export plan
                            redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"

                        Case 7
                            redirectURL = "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"

                        Case 8
                            redirectURL = "/InfiniPlan/Services/Business Tracker/PlanTracker.aspx"
                        Case 9
                            redirectURL = "/InfiniPlan/Services/MeterWizard/MeterWizard.aspx"
                            ' redirectURL = "/InfiniPlan/Services/MeterWizard/Speedometer.aspx"

                        Case 10
                            If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                                Session("test") = Nothing
                                redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                            Else
                                'otherwise just close the plan that is refresh the sessions.
                                Session("test") = Nothing
                                redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                            End If


                        Case Else ' if it is anything Else by Error then 
                            redirectURL = "/InfiniPlan/Services/Welcome.aspx"
                    End Select
                    Response.Redirect(redirectURL)
                End If
            End If


        Else
            If Not IsNothing(Request.QueryString("cmd")) Then _pageID = CInt(Request.QueryString("cmd"))

            If _pageID < 0 Then

            Else
                If (Not Page.IsPostBack) Then
                    Dim redirectURL As String
                    Select Case _pageID
                        Case 0
                            redirectURL = "/InfiniPlan/Services/Welcome.aspx"
                        Case 1 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
                        Case 2 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
                        Case 3 ' if it is table
                            redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"
                        Case 4 ' if it is plan preview
                            redirectURL = "/InfiniPlan/Services/PlanPreview/PlanPreview.htm"
                        Case 5 ' if it is export plan
                            redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
                        Case 6 ' if it is export plan
                            redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"

                        Case 7
                            redirectURL = "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"

                        Case 8

                            If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
                                redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
                            Else
                                'otherwise just close the plan that is refresh the sessions.
                                redirectURL = "/InfiniPlan/Services/Plan/ClosePlan.aspx"
                            End If
                        Case 9

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
                End If
            End If

        End If

        If Not Session("test") Is Nothing And Check = True Then

            Session("test") = Nothing
            '  Response.Redirect("/InfiniPlan/Services/MeterWizard/Speedometer.aspx?" + CType(Session("Speedometer"), String))
            Response.Redirect("/InfiniPlan/Services/MeterWizard/MeterWizard.aspx?" + CType(Session("MeterWizard"), String))

        Else
            CurPage = 0
            CurItem = 0
        End If
         
    End Sub
    Private Sub lnkText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkText.Click
        Dim redirectURL As String

        redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
        Response.Redirect(redirectURL)

    End Sub

    Private Sub lnkHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkHome.Click
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

    'Private Sub lnkPlanLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim redirectURL As String

    '    redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"
    '    Response.Redirect(redirectURL)
    'End Sub
End Class
