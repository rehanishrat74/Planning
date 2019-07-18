
Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Microsoft.Web.UI.WebControls

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class PlanTracker
    Inherits PlanTrackerBase
    ' Inherits System.Web.UI.Page

    Private NavId As Integer
    Protected WithEvents hypPlanManagment As System.Web.UI.WebControls.HyperLink
    Protected WithEvents iBtnIllustrations As System.Web.UI.WebControls.ImageButton
    Protected WithEvents hypMeters As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPrint As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblFirstHelp As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecondHelp As System.Web.UI.WebControls.Label
    Protected WithEvents WizardCurrecny As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lblThirddHelp As System.Web.UI.WebControls.Label
    Protected WithEvents Mainpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents hypIncome_monthly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypIncome_yearly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBalance_monthly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBalance_yearly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents standardpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblChartHelp As System.Web.UI.WebControls.Label
    Protected WithEvents lblChartSelection As System.Web.UI.WebControls.Label
    Protected WithEvents optMonthlyChart As System.Web.UI.WebControls.RadioButton
    Protected WithEvents optAnnualChart As System.Web.UI.WebControls.RadioButton
    Protected WithEvents btnOk As System.Web.UI.WebControls.Button
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlTrackerCharts As System.Web.UI.WebControls.Panel
    Protected WithEvents lblAnnaulchart As System.Web.UI.WebControls.Label
    Protected WithEvents lblMonthlychart As System.Web.UI.WebControls.Label
    Protected WithEvents lblSelectMonth As System.Web.UI.WebControls.Label
    Protected WithEvents cmbMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblChartYear As System.Web.UI.WebControls.Label
    Protected WithEvents lblSelectChartType As System.Web.UI.WebControls.Label
    Protected WithEvents cmbChartType As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents btnback As System.Web.UI.WebControls.Button
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlTrackerChartsOption As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblStandardHead As System.Web.UI.WebControls.Label
    Protected WithEvents lblIO As System.Web.UI.WebControls.Label
    Protected WithEvents ImgButMonthlyIO As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkMonthlyIO As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ImgButAnnualIO As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkAnnualIO As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblBS As System.Web.UI.WebControls.Label
    Protected WithEvents ImgButMonthlyBS As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkMonthlyBS As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ImgButAnnualBS As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkAnnualBS As System.Web.UI.WebControls.LinkButton
    Dim dtUserRigths As DataTable

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
     
    Public objPlanvb As Plan
   
    Public currecnyval As String
 
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

        Me.lblHeading.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblHeading")
        'Me.lblFirstHelp.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblFirstHelp")
        ' Me.lblSecondHelp.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblSecondHelp")
        'Me.LnkBtnReportProceed.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_LnkBtnProceed")
        'Me.lblIO.text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblIO")
        'Me.lblBS.text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblBS")
        'Me.lnkMonthlyIO.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lnkMonthlyIO")
        'Me.lnkAnnualIO.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lnkAnnualIO")
        'Me.lnkMonthlyBS.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lnkMonthlyBS")
        'Me.lnkAnnualBS.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lnkAnnualBS")
        'Me.lblStandardHead.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblStandardHead")

        Me.optMonthlyChart.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_optMonthlyChart")
        Me.optAnnualChart.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_optAnnualChart")
        Me.btnOk.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_btnOK")
        Me.lblSelectChartType.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblSelectChartType")
        Me.lblSelectMonth.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblSelectMonth")
        Me.btnShow.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_btnShow")
        Me.btnback.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_btnBack")


        Me.lblMonthlychart.Text = ResMgr.GetString("bizplanweb_Services_Business Tracker_PlanTracker_lblMonthlychart")
        Me.lblAnnaulchart.Text = ResMgr.GetString("bizplanweb_Services_Business Tracker_PlanTracker_lblAnnaulchart")
        Me.lblChartSelection.Text = ResMgr.GetString("bizplanweb_Services_Business Tracker_PlanTracker_lblChartSelection")
        Me.lblChartHelp.Text = ResMgr.GetString("bizplanweb_Services_Business Tracker_PlanTracker_lblChartHelp")



    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjPlan As New BusinessPlan.BLL.BusinessPlan
        NavId = CInt(Request.QueryString("NavigationD"))
        Dim dsName As DataSet = objPlanvb.GetCurrencyName(GetConnectionData, CurrentPlan.PlanID)
        Dim strName As String = CType(dsName.Tables(0).Rows(0).Item(0), String)
        If GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then

          

            If Request.UrlReferrer.AbsolutePath = "/InfiniPlan/Services/Charts/ComparisionChart.aspx" Then
                CurPage = 5
                CurItem = NavId
                GetSpecificPanel() '// this is use to get last working panel
                lblHeading.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblHeading")
                Exit Sub
            End If

            'Dim path As String = Request.QueryString("ret")
            'If path = "1" Then
            'If Not IsPostBack Then
            'lblHeading.Text = "Standatd Reports"
            'End If
            'Else
            '''''Nisar Start
            '''''If Not IsPostBack And NavId = 0 Then
            '''''    lblHeading.Text = "Comparison Reports"
            '''''    PanelVisibilities(False)
            '''''    standardpanel.Visible = True
            '''''Else
            '''''    If NavId = 1 And pnlTrackerChartsOption.Visible = False Then
            '''''        lblHeading.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblHeading")
            '''''        PanelVisibilities(False)
            '''''        pnlTrackerCharts.Visible = True
            '''''    End If
            '''''End If

            If Not IsPostBack And NavId = 0 Then
                If Not Session("merchantProUserID") Is Nothing Then
                    dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
                    If dtUserRigths.Select("  Modelid  = 69 And ModelOptionId = 1 ").Length > 0 Then
                        lblHeading.Text = "Comparison Reports"
                        PanelVisibilities(False)
                        standardpanel.Visible = True
                    Else
                        NavId = 1
                        If NavId = 1 And pnlTrackerChartsOption.Visible = False Then
                            lblHeading.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblHeading")
                            PanelVisibilities(False)
                            pnlTrackerCharts.Visible = True
                        End If
                    End If
                Else
                    lblHeading.Text = "Comparison Reports"
                    PanelVisibilities(False)
                    standardpanel.Visible = True
                End If
            Else
                If NavId = 1 And pnlTrackerChartsOption.Visible = False Then
                    lblHeading.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_lblHeading")
                    PanelVisibilities(False)
                    pnlTrackerCharts.Visible = True
                End If
            End If

            ''''' Nisar End
            'End If
        Else


            currecnyval = CType(Session("CurrecnyName"), String) + " " + CType(GetCustomerCurrency.Split(","c).GetValue(1), String)
            Session("Year") = Nothing
            Session("date") = Nothing
            standardpanel.Visible = False
            lblFirstHelp.Text = ResMgr.GetString("BizPlan_Services_Tracker_PlanTracker_lblFirstHelp")

            lblSecondHelp.Text = "Please use "

            lblThirddHelp.Text = "to change the currency of your business plan (" + strName + " " + CurrentPlan.Currency + ") according to your Accounts Centre profile ( " + currecnyval + ")."
            Session("currency") = "1"

            'Code here 
        End If
        CurPage = 5
        CurItem = NavId
    End Sub

    Private Sub lnkMonthlyIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkMonthlyIO.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=1")
    End Sub

    Private Sub lnkAnnualIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAnnualIO.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=2")

    End Sub

    Private Sub lnkMonthlyBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkMonthlyBS.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=3")
    End Sub

    Private Sub lnkAnnualBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkAnnualBS.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=4")
    End Sub


    'Private Sub LnkBtnReportProceed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LnkBtnReportProceed.Click
    '    Mainpanel.Visible = False
    '    standardpanel.Visible = True
    '    lblHeading.Text = "Standatd Reports"
    'End Sub

 


    Private Sub ImgButMonthlyIO_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgButMonthlyIO.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=1")
    End Sub

    Private Sub ImgButMonthlyBS_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgButMonthlyBS.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=3")
    End Sub

    Private Sub ImgButAnnualIO_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgButAnnualIO.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=2")
    End Sub

    Private Sub ImgButAnnualBS_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgButAnnualBS.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=4")
    End Sub

    'Private Sub LnkBtnChartProceed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkBtnChartProceed.Click
    '    PanelVisibilities(False)
    '    pnlTrackerCharts.Visible = True
    'End Sub
    Private Sub PanelVisibilities(ByVal status As Boolean)
        Mainpanel.Visible = status
        standardpanel.Visible = status
        pnlTrackerCharts.Visible = status
        pnlTrackerChartsOption.Visible = status
    End Sub
    Private Sub addMonthds()
        cmbMonth.Items.Clear()
        Dim startingYear As Integer
        Dim startingMonth As Integer

        startingYear = CurrentPlan.StartYear
        startingMonth = CInt([Enum].Parse(GetType(BusinessPlanMonths), CurrentPlan.StartMonth))

        Dim strKeyMonthArry As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", _
                "Aug", "Sep", "Oct", "Nov", "Dec"}
        Dim strValueMonthArry As String() = {"January", "February", "March", "April", "May", "June", "July", _
        "August", "September", "October", "November", "December"}

        For i As Integer = 0 To 11
            cmbMonth.Items.Add(New ListItem(strValueMonthArry.GetValue(startingMonth).ToString & ", " & startingYear, strKeyMonthArry.GetValue(startingMonth).ToString & " " & startingYear))
            startingMonth += 1
            If startingMonth > 11 Then
                startingYear += 1
                startingMonth = 0
            End If
        Next
    End Sub
    Private Sub addChartTypes()
        cmbChartType.Items.Clear()
        cmbChartType.Items.Add(New ListItem("Sales", "0"))
        cmbChartType.Items.Add(New ListItem("Sales / Product", "5"))
        cmbChartType.Items.Add(New ListItem("Cost of Sales", "1"))
        cmbChartType.Items.Add(New ListItem("Gross Profit", "2"))
        cmbChartType.Items.Add(New ListItem("Operating Expenses", "3"))
        cmbChartType.Items.Add(New ListItem("EBIT", "4"))
    End Sub
    Private Sub btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
        PanelVisibilities(False)
        pnlTrackerChartsOption.Visible = True

        lblChartYear.Visible = False
        lblSelectMonth.Visible = False
        lblMonthlychart.Visible = False
        lblAnnaulchart.Visible = False
        cmbMonth.Visible = False

        addChartTypes()         '// use to add chart types into chart type drop down box
        addMonthds()
        If optAnnualChart.Checked Then
            lblChartYear.Visible = True
            lblAnnaulchart.Visible = True
        Else
            lblSelectMonth.Visible = True
            lblMonthlychart.Visible = True
            cmbMonth.Visible = True
        End If
    End Sub

    Private Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim storeChartValues(8) As String

        If optAnnualChart.Checked = True Then storeChartValues(0) = "Annual Chart"
        If optMonthlyChart.Checked = True Then storeChartValues(0) = "Monthly Chart"

        storeChartValues(1) = CStr(CInt(cmbMonth.SelectedIndex) + 1)
        If cmbMonth.Visible = True Then
            storeChartValues(2) = cmbMonth.SelectedItem.Value
            storeChartValues(3) = cmbMonth.SelectedItem.Text
        End If
        storeChartValues(7) = cmbMonth.Items(0).Value
        storeChartValues(4) = cmbMonth.Items(0).Text
        storeChartValues(5) = cmbChartType.SelectedItem.Text
        storeChartValues(6) = cmbMonth.Items(cmbMonth.Items.Count - 1).Text
        storeChartValues(8) = cmbChartType.SelectedItem.Text


        Session("CompChartValues") = storeChartValues

        Response.Redirect("/InfiniPlan/Services/Charts/ComparisionChart.aspx", False)
    End Sub
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnback.Click
        PanelVisibilities(False)
        pnlTrackerCharts.Visible = True
    End Sub
    Private Sub GetSpecificPanel()
        Dim getChartValues As String()

        getChartValues = CType(Session("CompChartValues"), String())

        lblMonthlychart.Visible = False
        lblAnnaulchart.Visible = False

        If getChartValues.Length > 0 Then

            PanelVisibilities(False)                    '// false all panels
            pnlTrackerChartsOption.Visible = True       '// only visible chart specific panel

            lblChartYear.Visible = False
            lblSelectMonth.Visible = False
            cmbMonth.Visible = False

            addChartTypes()         '// use to add chart types into chart type drop down box
            addMonthds()            '// use to add months into drop down box

            If IsNothing(getChartValues(2)) Then
                lblChartYear.Visible = True
                optAnnualChart.Checked = True
                lblAnnaulchart.Visible = True
                optMonthlyChart.Checked = False
            Else
                lblSelectMonth.Visible = True
                cmbMonth.Visible = True
                lblMonthlychart.Visible = True
                optMonthlyChart.Checked = True
                optAnnualChart.Checked = False
            End If

        End If

    End Sub


End Class