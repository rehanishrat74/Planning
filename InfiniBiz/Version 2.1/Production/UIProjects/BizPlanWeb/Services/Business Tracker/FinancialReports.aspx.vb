
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

Public Class FinancialReports
    'Inherits System.Web.UI.Page
    Inherits PlanTrackerBase

#Region "Public Valriables"
    Public _ReportID As Integer = -1
    Public EstimatesSalseTotal As Double
    Public ActaulSalseTotal As Double
    Public ActaulSalseTotalPrevious As Double
    Public ActaulCOGSTotal As Double
    Public ActaulCOGSTotalPrevious As Double
    Public EstimatesCOGSTotal As Double
    Public EstimatesExpensesTotal As Double
    Public ActualExpensesTotal As Double
    Public ActualExpensesTotalPrevious As Double
    Dim GrossProfitEst As Double
    Dim GrossProfitAct As Double
    Dim GrossProfitActPrevious As Double
    Dim EBITValue As Double
    Dim EBITValueActual As Double
    Dim EBITValueActualPrevious As Double
    Public BPObject As InfiniLogic.BusinessPlan.BLL.BusinessPlan
    Public BPObjectPayroll As InfiniLogic.BusinessPlan.BLL.BusinessPlan
    Protected WithEvents Main As System.Web.UI.WebControls.Table
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblType As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Linkbutton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Linkbutton2 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Linkbutton3 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Linkbutton4 As System.Web.UI.WebControls.LinkButton
    Public objPlan As Plan
    Protected WithEvents btnHome As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Public Period As Integer
    Private _dt As BusinessTable
    Public Equity As Double
    Public totLibality As Double
    Public totassets As Double
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Public TOLLib_CAp As Double
    Public salaryActPrevious As Double
    Public salaryAct As Double
    Public salaryEst As Double
    Public salaryDev As Double
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCategoriesDescription As System.Web.UI.WebControls.Label
    Protected WithEvents lblComparison As System.Web.UI.WebControls.Label
    Protected WithEvents lblActual As System.Web.UI.WebControls.Label
    Protected WithEvents lblEstimated As System.Web.UI.WebControls.Label
    Protected WithEvents lblDeviation As System.Web.UI.WebControls.Label
    Public otherEst As Double
    Private bsDV As New DataView
    Private bsDVForLastYears As New DataView
    Protected WithEvents lblPrevious As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPreviosYears As System.Web.UI.WebControls.DropDownList
    Protected WithEvents AnnualHeader As System.Web.UI.WebControls.Panel
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents MonthlyPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblCategoriesDescriptionM As System.Web.UI.WebControls.Label
    Protected WithEvents lblComparisonM As System.Web.UI.WebControls.Label
    Protected WithEvents lblActualM As System.Web.UI.WebControls.Label
    Protected WithEvents lblEstimatedM As System.Web.UI.WebControls.Label
    Protected WithEvents lblDeviationM As System.Web.UI.WebControls.Label

    Protected WithEvents YearHeading As System.Web.UI.WebControls.Label
    Protected WithEvents MonthSelect As System.Web.UI.WebControls.Label
    Protected WithEvents Click As System.Web.UI.WebControls.Label
    Protected WithEvents YearlyYear As System.Web.UI.WebControls.Label
    Protected WithEvents YearHead As System.Web.UI.WebControls.Label
    Protected WithEvents cmbMonth As System.Web.UI.WebControls.DropDownList
#End Region

    Dim objBS As BalancesheetReport
    Dim obj As ROI
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Public displayYear As Integer
    Public _loop As Integer
    Public intYear As Integer
    Public _MonthYear As String
    Public month As New Hashtable
    Protected WithEvents lblTime As System.Web.UI.WebControls.Label
    Protected WithEvents lnkBackMonth As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkNextMonth As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkFirst As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkLast As System.Web.UI.WebControls.ImageButton
    Dim MonthlyHeader As HtmlTable


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

        Me.btnBack.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_btnBack")
        Me.btnHome.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_btnHome")
        Me.lblActual.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblActual")
        Me.lblCategoriesDescription.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblCategoriesDescription")
        Me.lblComparison.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblComparison")
        Me.lblDeviation.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblDeviation")
        Me.lblEstimated.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblEstimated")
        Me.lblType.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblType")

        Me.lblCategoriesDescriptionM.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblCategoriesDescription")
        Me.lblComparisonM.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblComparison")
        Me.lblDeviationM.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblDeviation")
        Me.lblEstimatedM.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblEstimated")
        Me.lblActualM.Text = ResMgr.GetString("BizPlan_Services_Tracker_FinancialReport_lblActual")



    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

    

        DateSettings()

        _ReportID = CInt(Request.QueryString("_report"))

        If Not Page.IsPostBack Then

            addMonthds()

            PopulatePreviousYears()

            If _ReportID = 1 Then

                MonthlyHeadingSettins()
                MonthlyIncomeStatement(Period, lblTime.Text)

            ElseIf _ReportID = 2 Then

                    AnnaulHeadingSettins()
                    AnnualIncomeStatement(Period, CurrentPlan.StartMonth + CType(CurrentPlan.StartYear, String), "") ' CurrentPlan.StartMonth + CType(CurrentPlan.StartYear - 1, String))
                ElseIf _ReportID = 3 Then

                    MonthlyHeadingSettins()
                    MonthlyBalanceSheet(Period, lblTime.Text)

                ElseIf _ReportID = 4 Then

                    AnnaulHeadingSettins()
                    AnnualBalanceSheet(Period, CurrentPlan.StartMonth + CType(CurrentPlan.StartYear, String), "")  ', CurrentPlan.StartMonth + CType(CurrentPlan.StartYear - 1, String))
                End If
            Else
            'lblPreviousText.Text = ddlPreviosYears.SelectedItem.Text

            End If

        Catch ex As Exception

        End Try
        
    End Sub

    Public Sub MonthlyHeadingSettins()

        Dim Endingyear As Integer
        _MonthYear = CType(CurrentPlan.StartMonth, String) + " " + CType(CurrentPlan.StartYear, String)
        lblTime.Text = _MonthYear
        If CurrentPlan.StartMonth <> "Jan" Then Endingyear = CurrentPlan.StartYear + 1 Else Endingyear = CurrentPlan.StartYear
        MonthlyPanel.Visible = True
        If _ReportID = 1 Then
            lblType.Text = "Monthly Income Statment"
        ElseIf _ReportID = 3 Then
            lblType.Text = "Monthly Balance sheet"
        End If

        YearHead.Text = "Plan's Financial Year : " + cmbMonth.Items(0).Text + " To " + cmbMonth.Items(11).Text
        MonthSelect.Visible = True
        MonthSelect.Text = "Select a month : "
        Click.Visible = True
        Click.Text = "" '" (Click to change month)"
        cmbMonth.Visible = True
        Period = 1
        Dim startYear As Integer = CurrentPlan.StartYear
        Dim startMonth As String = CurrentPlan.StartMonth
    End Sub

    Public Sub AnnaulHeadingSettins()

        Dim Endingyear As Integer
        AnnualHeader.Visible = True
        YearHead.Text = "Plan's Financial Year : " + cmbMonth.Items(0).Text + " To " + cmbMonth.Items(11).Text

        If CurrentPlan.StartMonth <> "Jan" Then Endingyear = CurrentPlan.StartYear + 1 Else Endingyear = CurrentPlan.StartYear
        lblPrevious.Text = "Select Previous Year"
            If _ReportID = 2 Then
            lblType.Text = "Annual Income Statment"
        ElseIf _ReportID = 4 Then
            lblType.Text = "Annual Balance sheet"
        End If

        cmbMonth.Visible = False
        lblTime.Visible = True
        ' lblPreviousText.Text = ddlPreviosYears.SelectedItem.Text
        lblTime.Text = ": " + CType(CurrentPlan.StartMonth, String) + " " + _
          CType(CurrentPlan.StartYear, String) + " to " + CType(month.Item(11), String) + " " + CType(Endingyear, String)

    End Sub

    Public Sub MonthlyBalanceSheet(ByVal IOPeriod As Integer, ByVal DateFrom As String)

        Try


            'Dim dsProMBS As DataSet = objPlan.GetMonthlyBalanseSheetPro(GetConnectionData, CurrentPlan.PlanID, DateFrom)

            '// new and fixed dates
            Dim obj_BSReport As New Infinilogic.AccountsCentre.AccountsPro.WEB.BLL.ClassReport

            '// new Implementations
            Dim fromDate As Date = DateValue(DateFrom)
            Dim toDate As Date = CDate(DateSerial(fromDate.Year, fromDate.Month + 1, 0))
            Try
                bsDV = objBS.BalanceSheet(GetConnectionData, fromDate, toDate)
            Catch ex As Exception
                Dim strError As String = "AccountsProException"
            End Try
            Dim nav As String() = CurrentNavigator
            If (nav Is Nothing) Then nav = Navigator
            _dt = CType(BusinessTable.CreateMonthlyBalaceSheet(GetConnectionData, CurrentPlan, "IntegratedBalancesheet", IOPeriod), BusinessTable)


            Dim trspace1 As New TableRow
            Dim trspace2 As New TableRow
            Dim trspace3 As New TableRow

            Dim trspace4 As New TableRow
            Dim trspace5 As New TableRow
            Dim trspace6 As New TableRow

            Dim tdspace As New TableCell
            tdspace.Text = "&nbsp;"

            'Fixed Assets 
            Dim trs As New TableRow
            Dim tds As New TableCell

            tds.Text = "&nbsp;"
            tds.ForeColor = tds.ForeColor.White
            trs.Controls.Add(tds)

            Main.Rows.Add(trs)
            Dim tbFixedAssets As New TableCell
            Dim trFixedAssets As New TableRow
            Dim tbFixedAssetsXsign As New TableCell
            Dim tbFixedAssetsYsign As New TableCell
            Dim tbFixedAssetsXYsign As New TableCell

            tbFixedAssets.Text = "Assets"
            tbFixedAssets.CssClass = "ReportHeadingsBS"

            trFixedAssets.Controls.Add(tbFixedAssets)
            tbFixedAssets.Width = tbFixedAssets.Width.Percentage(53)

            tbFixedAssetsXsign.Width = tbFixedAssets.Width.Percentage(16)
            tbFixedAssetsYsign.Width = tbFixedAssets.Width.Percentage(16)
            tbFixedAssetsXYsign.Width = tbFixedAssets.Width.Percentage(28)
            tbFixedAssetsXsign.Text = ""
            tbFixedAssetsXsign.CssClass = "ReportHeadingsCenterBS"
            trFixedAssets.Controls.Add(tbFixedAssetsXsign)

            tbFixedAssetsYsign.Text = ""
            tbFixedAssetsYsign.CssClass = "ReportHeadingsCenterBS"

            trFixedAssets.Controls.Add(tbFixedAssetsYsign)

            tbFixedAssetsXYsign.Text = ""
            tbFixedAssetsXYsign.CssClass = "ReportHeadingsCenterBS"
            trFixedAssets.Controls.Add(tbFixedAssetsXYsign)
            Main.Rows.Add(trFixedAssets)

            Dim tbFixedAssetsAct As New TableCell
            Dim tbFixedAssetsEst As New TableCell
            Dim tbFixedAssetsDev As New TableCell

            Dim trName As New TableRow
            Dim tdname As New TableCell
            tdname.CssClass = "ReportTitles"
            tdname.Text = "Fixed Assets"
            trName.Controls.Add(tdname)

            tbFixedAssetsAct.Width = tbFixedAssetsAct.Width.Percentage(16)
            tbFixedAssetsEst.Width = tbFixedAssetsEst.Width.Percentage(16)
            tbFixedAssetsDev.Width = tbFixedAssetsDev.Width.Percentage(28)

            If bsDV Is Nothing Then
                tbFixedAssetsAct.Text = "0.0"
            Else

                tbFixedAssetsAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Fixed Assets")

            End If

            tbFixedAssetsAct.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsAct)

            tbFixedAssetsEst.Text = Format(CType(BPObject.FixedAssets, Double), "f")
            tbFixedAssetsEst.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsEst)

            tbFixedAssetsDev.Text = Format(CType(tbFixedAssetsAct.Text, Double) - BPObject.FixedAssets, "f")
            tbFixedAssetsDev.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsDev)

            Main.Rows.Add(trName)

            'Current Assets 
            Dim tbCurrentAsset As New TableCell
            Dim trCurrentAsset As New TableRow


            Dim tbCurrentAssetAct As New TableCell
            Dim tbCurrentAssetEst As New TableCell
            Dim tbCurrentAssetDev As New TableCell

            Dim trCurrentAssetSold As New TableRow
            Dim tdCurrentAssetSold As New TableCell
            tdCurrentAssetSold.CssClass = "ReportTitles"
            tdCurrentAssetSold.Text = "Current Assets"
            trCurrentAssetSold.Controls.Add(tdCurrentAssetSold)

            tbCurrentAssetAct.Width = tbCurrentAssetAct.Width.Percentage(16)
            tbCurrentAssetEst.Width = tbCurrentAssetEst.Width.Percentage(16)
            tbCurrentAssetDev.Width = tbCurrentAssetDev.Width.Percentage(28)

            If bsDV Is Nothing Then
                tbCurrentAssetAct.Text = "0.0"
            Else
                tbCurrentAssetAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total current Assets")

            End If

            tbCurrentAssetAct.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetAct)

            tbCurrentAssetEst.Text = Format(CType(BPObject.CurrentAssets, Double), "f")
            tbCurrentAssetEst.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetEst)

            tbCurrentAssetDev.Text = Format(CType(tbCurrentAssetAct.Text, Double) - BPObject.CurrentAssets, "f")
            tbCurrentAssetDev.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetDev)
            Main.Rows.Add(trCurrentAssetSold)

            'Asset Total 

            Dim trAssetTotal As New TableRow
            Dim tdAssetTotal As New TableCell

            Dim tdAssetTotalAct As New TableCell
            Dim tdAssetTotalEst As New TableCell
            Dim tdAssetTotalDev As New TableCell

            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = "aa"
            td.ForeColor = td.ForeColor.White
            tr.Controls.Add(td)
            tdAssetTotal.Text = "Total Assets "
            tdAssetTotal.CssClass = "BSColor"
            trAssetTotal.Controls.Add(tdAssetTotal)


            'totassets = CType(dsProMBS.Tables(0).Rows(0).ItemArray(1), Double) + CType(dsProMBS.Tables(1).Rows(2).Item(1), Double)
            'tdAssetTotalAct.Text = Format(CType(totassets, Double), "f")
            'tdAssetTotalAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Current Assets")
            tdAssetTotalAct.Text = CStr(Val(tbFixedAssetsAct.Text) + Val(tbCurrentAssetAct.Text))
            tdAssetTotalAct.CssClass = "ReportHeadingsCenterBS"
            trAssetTotal.Controls.Add(tdAssetTotalAct)


            tdAssetTotalEst.Text = Format(CType(BPObject.TotalAssets, Double), "f")
            tdAssetTotalEst.CssClass = "ReportHeadingsCenterBS"
            trAssetTotal.Controls.Add(tdAssetTotalEst)


            tdAssetTotalDev.Text = Format(CType(CType(tdAssetTotalAct.Text, Double) - BPObject.TotalAssets, Double), "f")
            tdAssetTotalDev.CssClass = "ReportHeadingsCenterBS"
            trAssetTotal.Controls.Add(tdAssetTotalDev)

            Main.Rows.Add(trAssetTotal)

            trspace1.Controls.Add(tdspace)

            Main.Rows.Add(trspace1)
            Main.Rows.Add(tr)
            'Long Term Libality 

            Dim tbLibility As New TableCell
            Dim trLibility As New TableRow

            tbLibility.Text = "Total Libilities and Equities"
            trLibility.Controls.Add(tbLibility)
            tbLibility.CssClass = "ReportHeadingsBS"
            Main.Rows.Add(trLibility)


            Dim trLibilityName As New TableRow
            Dim tdLibilityName As New TableCell

            Dim tbLibilityAct As New TableCell
            Dim tbLibilityEst As New TableCell
            Dim tbLibilityDev As New TableCell

            tdLibilityName.CssClass = "ReportTitles"
            tdLibilityName.Text = "Long Term Libilities"
            trLibilityName.Controls.Add(tdLibilityName)


            tbLibilityAct.Width = tbLibilityAct.Width.Percentage(16)
            tbLibilityEst.Width = tbLibilityEst.Width.Percentage(16)
            tbLibilityDev.Width = tbLibilityDev.Width.Percentage(28)

            If bsDV Is Nothing Then
                tbLibilityAct.Text = "0.0"
            Else

                tbLibilityAct.Text = GetBalanceSheetValues(fromDate, toDate, "Long Term Libality")
            End If

            tbLibilityAct.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityAct)

            tbLibilityEst.Text = Format(CType(BPObject.LongTLIB, Double), "f")
            tbLibilityEst.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityEst)

            'tbLibilityDev.Text = Format((BPObject.LongTLIB - Math.Abs(CType(dsProMBS.Tables(2).Rows(0).Item(1), Double))), "f")
            tbLibilityDev.Text = Format(BPObject.LongTLIB - Math.Abs(CType(tbCurrentAssetAct.Text, Double)), "f")
            tbLibilityDev.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityDev)
            Main.Rows.Add(trLibilityName)

            ''Short Term Libality 

            Dim tbShortLibility As New TableCell
            Dim trShortLibility As New TableRow




            Dim trShortLibilityName As New TableRow
            Dim tdShortLibilityName As New TableCell

            Dim tbShortLibilityAct As New TableCell
            Dim tbShortLibilityEst As New TableCell
            Dim tbShortLibilityDev As New TableCell

            tdShortLibilityName.CssClass = "ReportTitles"
            tdShortLibilityName.Text = "Short Term Libilities"
            trShortLibilityName.Controls.Add(tdShortLibilityName)


            tbShortLibilityAct.Width = tbShortLibilityAct.Width.Percentage(16)
            tbShortLibilityEst.Width = tbShortLibilityEst.Width.Percentage(16)
            tbShortLibilityDev.Width = tbShortLibilityDev.Width.Percentage(28)

            If bsDV Is Nothing Then
                tbShortLibilityAct.Text = "0.0"
            Else
                tbShortLibilityAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Current Liabilities")
            End If
            'tbShortLibilityAct.Text = Format(Math.Abs(CType(dsProMBS.Tables(1).Rows(1).Item(1), Double)), "f")


            tbShortLibilityAct.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityAct)

            tbShortLibilityEst.Text = Format(CType(BPObject.ShortTLIB, Double), "f")
            tbShortLibilityEst.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityEst)

            tbShortLibilityDev.Text = Format(BPObject.ShortTLIB - CType(tbShortLibilityAct.Text, Double), "f")
            tbShortLibilityDev.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityDev)
            Main.Rows.Add(trShortLibilityName)

            'Libility Total 

            Dim trLibilityTotal As New TableRow
            Dim tdLibilityTotal As New TableCell

            Dim tdLibilityTotalAct As New TableCell
            Dim tdLibilityTotalEst As New TableCell
            Dim tdLibilityTotalDev As New TableCell
            Dim tr1 As New TableRow
            Dim td1 As New TableCell
            td1.Text = "aa"
            td1.ForeColor = td1.ForeColor.White
            tr1.Controls.Add(td1)
            tdLibilityTotal.Text = "Total Libilities "
            tdLibilityTotal.CssClass = "ReportTitlesLIB"
            trLibilityTotal.Controls.Add(tdLibilityTotal)

            trLibilityTotal.Controls.Add(tdLibilityTotalAct)
            'totLibality = Math.Abs(CType(dsProMBS.Tables(1).Rows(1).Item(1), Double) + CType(dsProMBS.Tables(2).Rows(0).Item(1), Double))
            'tdLibilityTotalAct.Text = Format(totLibality, "f")
            If bsDV Is Nothing Then
                tdLibilityTotalAct.Text = "0.0"
            Else
                tdLibilityTotalAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Current Liabilities")
            End If


            tdLibilityTotalAct.CssClass = "ReportFigures"
            trLibilityTotal.Controls.Add(tdLibilityTotalEst)

            tdLibilityTotalEst.Text = Format(BPObject.dubTotTLIB, "f")
            tdLibilityTotalEst.CssClass = "ReportFigures"

            trLibilityTotal.Controls.Add(tdLibilityTotalDev)
            tdLibilityTotalDev.Text = Format(BPObject.dubTotTLIB - CType(tdLibilityTotalAct.Text, Double), "f")

            tdLibilityTotalDev.CssClass = "ReportFigures"

            Main.Rows.Add(trLibilityTotal)

            trspace1.Controls.Add(tdspace)
            Main.Rows.Add(trspace1)
            Main.Rows.Add(trspace1)
            Main.Rows.Add(tr1)
            'Total Capital

            Dim tbTotCapital As New TableCell
            Dim trTotCapital As New TableRow



            Dim trTotCapitalName As New TableRow
            Dim tdTotCapitalName As New TableCell
            Dim tr2 As New TableRow
            Dim td2 As New TableCell
            td2.Text = "aa"
            td2.ForeColor = td2.ForeColor.White
            tr2.Controls.Add(td2)
            Dim tbTotCapitalAct As New TableCell
            Dim tbTotCapitalEst As New TableCell
            Dim tbTotCapitalDev As New TableCell

            tdTotCapitalName.CssClass = "ReportTitles"
            tdTotCapitalName.Text = "Capital & Reserves"
            trTotCapitalName.Controls.Add(tdTotCapitalName)


            tbTotCapitalAct.Width = tbTotCapitalAct.Width.Percentage(16)
            tbTotCapitalEst.Width = tbTotCapitalEst.Width.Percentage(16)
            tbTotCapitalDev.Width = tbTotCapitalDev.Width.Percentage(28)
            If bsDV Is Nothing Then
                tbTotCapitalAct.Text = "0.0"

            Else
                tbTotCapitalAct.Text = GetBalanceSheetValues(fromDate, toDate, "Net Capital :")

            End If
            'tbTotCapitalAct.Text = Format((CType(dsProMBS.Tables(1).Rows(0).Item(1), Double) + CType(dsProMBS.Tables(3).Rows(0).Item(0), Double)), "f")

            tbTotCapitalAct.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalAct)

            tbTotCapitalEst.Text = Format(CType(BPObject.TotalCapital, Double), "f")
            tbTotCapitalEst.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalEst)

            tbTotCapitalDev.Text = Format(CType(tbTotCapitalAct.Text, Double) - BPObject.TotalCapital, "f")
            tbTotCapitalDev.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalDev)
            Main.Rows.Add(trTotCapitalName)
            trspace1.Controls.Add(tdspace)
            Main.Rows.Add(trspace1)
            Main.Rows.Add(trspace1)
            Main.Rows.Add(tr2)
            'Capital & Reserves

            Dim tbCap_Res As New TableCell
            Dim trCap_Res As New TableRow



            Dim trCap_ResName As New TableRow
            Dim tdCap_ResName As New TableCell

            Dim tbCap_ResAct As New TableCell
            Dim tbCap_ResEst As New TableCell
            Dim tbCap_ResDev As New TableCell

            tdCap_ResName.CssClass = "BSColor"
            tdCap_ResName.Text = "Total Libilities and Equities"
            trCap_ResName.Controls.Add(tdCap_ResName)


            tbCap_ResAct.Width = tbCap_ResAct.Width.Percentage(16)
            tbCap_ResEst.Width = tbCap_ResEst.Width.Percentage(16)
            tbCap_ResDev.Width = tbCap_ResDev.Width.Percentage(28)

            TOLLib_CAp = totassets - totLibality
            '  tbCap_ResAct.Text = Format(CType(dsProMBS.Tables(1).Rows(0).Item(1), Double) + totLibality, "f")
            'tbCap_ResAct.Text = Format(totassets - totLibality, "f")
            'tbCap_ResAct.Text = GetBalanceSheetValues(fromDate, toDate, "Net Assets :")

            tbCap_ResAct.Text = CStr(CType(tdLibilityTotalAct.Text, Double) + CType(tbTotCapitalAct.Text, Double))

            tbCap_ResAct.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResAct)

            tbCap_ResEst.Text = Format(BPObject.Capital_Reserves, "f")
            tbCap_ResEst.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResEst)

            tbCap_ResDev.Text = Format(BPObject.Capital_Reserves - CType(tbCap_ResAct.Text, Double), "f")
            tbCap_ResDev.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResDev)
            Main.Rows.Add(trCap_ResName)
            trspace1.Controls.Add(tdspace)
            Main.Rows.Add(trspace1)
            Main.Rows.Add(trspace1)
        Catch ex As Exception
            Dim strError As String = "InfiniplanException"
        End Try
    End Sub

    Public Sub AnnualBalanceSheet(ByVal IOPeriod As Integer, ByVal DateFrom As String, ByVal PreviousDate As String)

        lnkBackMonth.Visible = False
        lnkFirst.Visible = False
        lnkLast.Visible = False
        lnkNextMonth.Visible = False

        '  _dateFrom = "05/23/2007"
        ' _dateTo =   "04/01/2008"   

        Try
            ' Dim dsProMBS As DataSet = objPlan.GetYearlyBalanseSheetPro(GetConnectionData, CurrentPlan.PlanID, DateFrom)
            '// new and fixed dates
            Dim obj_BSReport As New Infinilogic.AccountsCentre.AccountsPro.WEB.BLL.ClassReport
            Dim fromDatePrevious As Date
            Dim toDaterevious As Date
            Dim fromDate As Date = DateValue(DateFrom)
            Dim toDate As Date = CDate(DateSerial(fromDate.Year, fromDate.Month + 12, 0))
            Dim bit As Boolean
            If PreviousDate = "" Then
                bit = False
            Else
                fromDatePrevious = DateValue(PreviousDate)
                toDaterevious = CDate(DateSerial(fromDatePrevious.Year, fromDatePrevious.Month + 12, 0))
                bit = True
            End If

            Try
                ' If Session("ProAnnualRecords") Is Nothing Then
                bsDV = objBS.BalanceSheet(GetConnectionData, fromDate, toDate)
                ' bsDV = obj.BalanceSheet(GetConnectionData, fromDate, toDate)

                Session("ProAnnualRecords") = bsDV
                bsDVForLastYears = Nothing
                '  Else
                'bsDV = CType(Session("ProAnnualRecords"), DataView)
                'If bit = True Then
                '    bsDVForLastYears = objBS.BalanceSheet(GetConnectionData, fromDatePrevious, toDaterevious)
                'Else
                '    bsDVForLastYears = Nothing
                'End If
                'End If
            Catch ex As Exception
                Dim strProError As String = "AccountsProError"
            End Try
            Dim nav As String() = CurrentNavigator
            If (nav Is Nothing) Then nav = Navigator
            If Session("PlanAnnualRecords") Is Nothing Then
                _dt = CType(BusinessTable.CreateAnualBalaceSheet(GetConnectionData, CurrentPlan, "IntegratedBalancesheet"), BusinessTable)
                Session("PlanAnnualRecords") = _dt
            Else
                _dt = CType(Session("PlanAnnualRecords"), BusinessTable)
            End If
            'Fixed Assets 
            Dim trs As New TableRow
            Dim tds As New TableCell

            tds.Text = "&nbsp;"
            tds.ForeColor = tds.ForeColor.White
            trs.Controls.Add(tds)
            trs = FillYearlyRows(tds, trs)
            Main.Rows.Add(trs)
            Dim tbFixedAssets As New TableCell
            Dim trFixedAssets As New TableRow
            Dim tbFixedAssetsXsign As New TableCell
            Dim tbFixedAssetsYsign As New TableCell
            Dim tbFixedAssetsXYsign As New TableCell
            Dim tbFixedAssetsPreviousSign As New TableCell
            tbFixedAssets.Text = "Assets"
            tbFixedAssets.CssClass = "ReportHeadingsBS"

            trFixedAssets.Controls.Add(tbFixedAssets)
            tbFixedAssets.Width = tbFixedAssets.Width.Percentage(41)
            tbFixedAssetsXsign.Width = tbFixedAssets.Width.Percentage(13)
            tbFixedAssetsYsign.Width = tbFixedAssets.Width.Percentage(13)
            tbFixedAssetsPreviousSign.Width = tbFixedAssets.Width.Percentage(20)
            tbFixedAssetsPreviousSign.Text = ""
            tbFixedAssetsPreviousSign.CssClass = "ReportHeadingsCenterBSYearly"

            trFixedAssets.Controls.Add(tbFixedAssetsPreviousSign)

            tbFixedAssetsXsign.Text = ""
            tbFixedAssetsXsign.CssClass = "ReportHeadingsCenterBS"

            trFixedAssets.Controls.Add(tbFixedAssetsXsign)

            tbFixedAssetsYsign.Text = ""
            tbFixedAssetsYsign.CssClass = "ReportHeadingsCenterBS"

            trFixedAssets.Controls.Add(tbFixedAssetsYsign)

            tbFixedAssetsXYsign.Text = ""
            tbFixedAssetsXYsign.CssClass = "ReportHeadingsCenterBS"
            trFixedAssets.Controls.Add(tbFixedAssetsXYsign)

            Main.Rows.Add(trFixedAssets)

            Dim tbFixedAssetsActPrevious As New TableCell
            Dim tbFixedAssetsAct As New TableCell
            Dim tbFixedAssetsEst As New TableCell
            Dim tbFixedAssetsDev As New TableCell

            Dim trName As New TableRow
            Dim tdname As New TableCell
            tdname.CssClass = "ReportTitles"
            tdname.Text = "Fixed Assets"
            trName.Controls.Add(tdname)
            tbFixedAssetsActPrevious.Width = tbFixedAssetsActPrevious.Width.Percentage(20)
            tbFixedAssetsAct.Width = tbFixedAssetsAct.Width.Percentage(13)
            tbFixedAssetsEst.Width = tbFixedAssetsEst.Width.Percentage(13)

            If bsDV Is Nothing Then
                tbFixedAssetsAct.Text = "0.0"
            Else

                tbFixedAssetsAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Fixed Assets")

            End If
            If bsDVForLastYears Is Nothing Then
                tbFixedAssetsActPrevious.Text = "0.0"

            Else
                tbFixedAssetsActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Total Fixed Assets")

            End If

            tbFixedAssetsActPrevious.CssClass = "ReportFiguresPrevious"
            trName.Controls.Add(tbFixedAssetsActPrevious)

            tbFixedAssetsAct.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsAct)

            tbFixedAssetsEst.Text = Format(CType(BPObject.FixedAssets, Double), "f")
            tbFixedAssetsEst.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsEst)

            tbFixedAssetsDev.Text = Format(CType(tbFixedAssetsAct.Text, Double) - BPObject.FixedAssets, "f")
            tbFixedAssetsDev.CssClass = "ReportFigures"
            trName.Controls.Add(tbFixedAssetsDev)

            Main.Rows.Add(trName)

            'Current Assets 
            Dim tbCurrentAssetAct As New TableCell
            Dim tbCurrentAssetEst As New TableCell
            Dim tbCurrentAssetDev As New TableCell

            Dim trCurrentAssetSold As New TableRow
            Dim tdCurrentAssetSold As New TableCell
            tdCurrentAssetSold.CssClass = "ReportTitles"
            tdCurrentAssetSold.Text = "Current Assets"
            trCurrentAssetSold.Controls.Add(tdCurrentAssetSold)

            tbCurrentAssetAct.Width = tbCurrentAssetAct.Width.Percentage(13)
            tbCurrentAssetEst.Width = tbCurrentAssetEst.Width.Percentage(13)

            If bsDV Is Nothing Then
                tbCurrentAssetAct.Text = "0.0"
            Else
                tbCurrentAssetAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total current Assets")

            End If

            Dim tbCurrentAssetActPrevious As New TableCell
            If bsDVForLastYears Is Nothing Then
                tbCurrentAssetActPrevious.Text = "0.0"

            Else
                tbCurrentAssetActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Total current Assets")
            End If

            tbCurrentAssetActPrevious.CssClass = "ReportFiguresPrevious"
            tbCurrentAssetActPrevious.Width = tbCurrentAssetActPrevious.Width.Percentage(20)
            trCurrentAssetSold.Controls.Add(tbCurrentAssetActPrevious)

            tbCurrentAssetAct.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetAct)

            tbCurrentAssetEst.Text = Format(CType(BPObject.CurrentAssets, Double), "f")
            tbCurrentAssetEst.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetEst)

            tbCurrentAssetDev.Text = Format(CType(tbCurrentAssetAct.Text, Double) - BPObject.CurrentAssets, "f")
            tbCurrentAssetDev.CssClass = "ReportFigures"
            trCurrentAssetSold.Controls.Add(tbCurrentAssetDev)
            Main.Rows.Add(trCurrentAssetSold)

            'Asset Total 

            Dim trAssetTotal As New TableRow
            Dim tdAssetTotal As New TableCell

            Dim tdAssetTotalAct As New TableCell
            Dim tdAssetTotalEst As New TableCell
            Dim tdAssetTotalDev As New TableCell

            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = "aa"
            td.ForeColor = td.ForeColor.White
            tr.Controls.Add(td)
            tdAssetTotal.Text = "Total Assets "
            tdAssetTotal.CssClass = "BSColor"
            trAssetTotal.Controls.Add(tdAssetTotal)

            Dim tdAssetTotalActPrevious As New TableCell
            tdAssetTotalActPrevious.Text = CStr(Val(tbFixedAssetsActPrevious.Text) + Val(tbCurrentAssetActPrevious.Text))
            tdAssetTotalActPrevious.CssClass = "ReportHeadingsCenterBSYearly"
            trAssetTotal.Controls.Add(tdAssetTotalActPrevious)

            trAssetTotal.Controls.Add(tdAssetTotalAct)
            tdAssetTotalAct.Text = CStr(Val(tbFixedAssetsAct.Text) + Val(tbCurrentAssetAct.Text))


            tdAssetTotalAct.CssClass = "ReportHeadingsCenterBS"
            trAssetTotal.Controls.Add(tdAssetTotalEst)

            tdAssetTotalEst.Text = Format(CType(BPObject.TotalAssets, Double), "f")
            tdAssetTotalEst.CssClass = "ReportHeadingsCenterBS"

            trAssetTotal.Controls.Add(tdAssetTotalDev)
            tdAssetTotalDev.Text = Format(CType(CType(tdAssetTotalAct.Text, Double) - BPObject.TotalAssets, Double), "f")

            tdAssetTotalDev.CssClass = "ReportHeadingsCenterBS"

            Main.Rows.Add(trAssetTotal)

            tr = FillYearlyRows(td, tr)
            Main.Rows.Add(tr)
            'Long Term Libality 

            Dim tbLibility As New TableCell
            Dim trLibility As New TableRow

            tbLibility.Text = "Total Libilities and Equities"
            trLibility.Controls.Add(tbLibility)
            tbLibility.CssClass = "ReportHeadingsBS"
            trLibility = FillYearlyRowsBS(tbLibility, trLibility)
            Main.Rows.Add(trLibility)


            Dim trLibilityName As New TableRow
            Dim tdLibilityName As New TableCell

            Dim tbLibilityAct As New TableCell
            Dim tbLibilityEst As New TableCell
            Dim tbLibilityDev As New TableCell

            tdLibilityName.CssClass = "ReportTitles"
            tdLibilityName.Text = "Long Term Libilities"
            trLibilityName.Controls.Add(tdLibilityName)


            tbLibilityAct.Width = tbLibilityAct.Width.Percentage(13)
            tbLibilityEst.Width = tbLibilityEst.Width.Percentage(13)
            '    tbLibilityDev.Width = tbLibilityDev.Width.Percentage(28)

            If bsDV Is Nothing Then
                tbLibilityAct.Text = "0.0"
            Else
                tbLibilityAct.Text = GetBalanceSheetValues(fromDate, toDate, "Long Term Libality")
            End If
            Dim tbLibilityActPrevious As New TableCell
            If bsDVForLastYears Is Nothing Then
                tbLibilityActPrevious.Text = "0.0"
            Else
                tbLibilityActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Long Term Libality")
            End If

            tbLibilityActPrevious.CssClass = "ReportFiguresPrevious"
            tbLibilityActPrevious.Width = tbLibilityActPrevious.Width.Percentage(20)
            trLibilityName.Controls.Add(tbLibilityActPrevious)

            tbLibilityAct.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityAct)

            tbLibilityEst.Text = Format(CType(BPObject.LongTLIB, Double), "f")
            tbLibilityEst.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityEst)

            tbLibilityDev.Text = Format(BPObject.LongTLIB - Math.Abs(CType(tbCurrentAssetAct.Text, Double)), "f")
            tbLibilityDev.CssClass = "ReportFigures"
            trLibilityName.Controls.Add(tbLibilityDev)
            Main.Rows.Add(trLibilityName)

            ''Short Term Libality 


            Dim trShortLibilityName As New TableRow
            Dim tdShortLibilityName As New TableCell

            Dim tbShortLibilityAct As New TableCell
            Dim tbShortLibilityEst As New TableCell
            Dim tbShortLibilityDev As New TableCell

            tdShortLibilityName.CssClass = "ReportTitles"
            tdShortLibilityName.Text = "Short Term Libilities"
            trShortLibilityName.Controls.Add(tdShortLibilityName)


            tbShortLibilityAct.Width = tbShortLibilityAct.Width.Percentage(13)
            tbShortLibilityEst.Width = tbShortLibilityEst.Width.Percentage(13)

            If bsDV Is Nothing Then
                tbShortLibilityAct.Text = "0.0"
            Else
                tbShortLibilityAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Current Liabilities")
            End If
            Dim tbShortLibilityActPrevious As New TableCell
            If bsDVForLastYears Is Nothing Then
                tbShortLibilityActPrevious.Text = "0.0"
            Else
                tbShortLibilityActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Total Current Liabilities")
            End If

            tbShortLibilityActPrevious.CssClass = "ReportFiguresPrevious"
            tbShortLibilityActPrevious.Width = tbShortLibilityActPrevious.Width.Percentage(20)
            trShortLibilityName.Controls.Add(tbShortLibilityActPrevious)

            tbShortLibilityAct.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityAct)

            tbShortLibilityEst.Text = Format(CType(BPObject.ShortTLIB, Double), "f")
            tbShortLibilityEst.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityEst)

            tbShortLibilityDev.Text = Format(BPObject.ShortTLIB - CType(tbShortLibilityAct.Text, Double), "f")
            tbShortLibilityDev.CssClass = "ReportFigures"
            trShortLibilityName.Controls.Add(tbShortLibilityDev)
            Main.Rows.Add(trShortLibilityName)

            'Libility Total 

            Dim trLibilityTotal As New TableRow
            Dim tdLibilityTotal As New TableCell

            Dim tdLibilityTotalAct As New TableCell
            Dim tdLibilityTotalEst As New TableCell
            Dim tdLibilityTotalDev As New TableCell
            Dim tr1 As New TableRow
            Dim td1 As New TableCell
            td1.Text = "aa"
            td1.ForeColor = td1.ForeColor.White
            tr1.Controls.Add(td1)
            tdLibilityTotal.Text = "Total Libilities "
            tdLibilityTotal.CssClass = "ReportTitlesLIB"
            trLibilityTotal.Controls.Add(tdLibilityTotal)

            Dim tbLibilityTotalActPrevious As New TableCell

            trLibilityTotal.Controls.Add(tbLibilityTotalActPrevious)

            trLibilityTotal.Controls.Add(tdLibilityTotalAct)
            If bsDV Is Nothing Then
                tdLibilityTotalAct.Text = "0.0"
            Else
                tdLibilityTotalAct.Text = GetBalanceSheetValues(fromDate, toDate, "Total Current Liabilities")
            End If
            If bsDVForLastYears Is Nothing Then
                tbLibilityTotalActPrevious.Text = "0.0"

            Else
                tbLibilityTotalActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Total Current Liabilities")

            End If
            tbLibilityTotalActPrevious.CssClass = "ReportFiguresPrevious"
            tdLibilityTotalAct.CssClass = "ReportFigures"
            trLibilityTotal.Controls.Add(tdLibilityTotalEst)

            tdLibilityTotalEst.Text = Format(BPObject.dubTotTLIB, "f")
            tdLibilityTotalEst.CssClass = "ReportFigures"

            trLibilityTotal.Controls.Add(tdLibilityTotalDev)
            tdLibilityTotalDev.Text = Format(BPObject.dubTotTLIB - CType(tdLibilityTotalAct.Text, Double), "f")

            tdLibilityTotalDev.CssClass = "ReportFigures"

            Main.Rows.Add(trLibilityTotal)
            tr1 = FillYearlyRows(td1, tr1)
            Main.Rows.Add(tr1)
            'Total Capital

            Dim trTotCapitalName As New TableRow
            Dim tdTotCapitalName As New TableCell
            Dim tr2 As New TableRow
            Dim td2 As New TableCell
            td2.Text = "aa"
            td2.ForeColor = td2.ForeColor.White
            tr2.Controls.Add(td2)
            Dim tbTotCapitalAct As New TableCell
            Dim tbTotCapitalEst As New TableCell
            Dim tbTotCapitalDev As New TableCell

            tdTotCapitalName.CssClass = "ReportTitles"
            tdTotCapitalName.Text = "Capital & Reserves"
            trTotCapitalName.Controls.Add(tdTotCapitalName)


            tbTotCapitalAct.Width = tbTotCapitalAct.Width.Percentage(13)
            tbTotCapitalEst.Width = tbTotCapitalEst.Width.Percentage(13)
            If bsDV Is Nothing Then
                tbTotCapitalAct.Text = "0.0"
            Else
                tbTotCapitalAct.Text = GetBalanceSheetValues(fromDate, toDate, "Net Capital :")
            End If
            Dim tbTotCapitalActPrevious As New TableCell
            If bsDVForLastYears Is Nothing Then
                tbTotCapitalActPrevious.Text = "0.0"
            Else
                tbTotCapitalActPrevious.Text = GetBalanceSheetValuesLastYears(fromDatePrevious, toDaterevious, "Net Capital :")
            End If

            tbTotCapitalActPrevious.Width = tbTotCapitalActPrevious.Width.Percentage(20)
            trTotCapitalName.Controls.Add(tbTotCapitalActPrevious)
            tbTotCapitalActPrevious.CssClass = "ReportFiguresPrevious"
            tbTotCapitalAct.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalAct)

            tbTotCapitalEst.Text = Format(CType(BPObject.TotalCapital, Double), "f")
            tbTotCapitalEst.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalEst)

            tbTotCapitalDev.Text = Format(CType(tbTotCapitalAct.Text, Double) - BPObject.TotalCapital, "f")
            tbTotCapitalDev.CssClass = "ReportFigures"
            trTotCapitalName.Controls.Add(tbTotCapitalDev)
            Main.Rows.Add(trTotCapitalName)
            tr2 = FillYearlyRows(td2, tr2)
            Main.Rows.Add(tr2)
            'Capital & Reserves


            Dim trCap_ResName As New TableRow
            Dim tdCap_ResName As New TableCell

            Dim tbCap_ResAct As New TableCell
            Dim tbCap_ResEst As New TableCell
            Dim tbCap_ResDev As New TableCell
            Dim tbCap_ResActPrevious As New TableCell

            Dim trSpace As New TableRow
            Dim tdSpace As New TableCell
            tdSpace.Text = "aa"
            tdSpace.ForeColor = td2.ForeColor.White
            trSpace.Controls.Add(tdSpace)


            tdCap_ResName.CssClass = "BSColor"
            tdCap_ResName.Text = "Total Libilities and Equities"
            trCap_ResName.Controls.Add(tdCap_ResName)


            tbCap_ResAct.Width = tbCap_ResAct.Width.Percentage(13)
            tbCap_ResEst.Width = tbCap_ResEst.Width.Percentage(13)
            '  tbCap_ResDev.Width = tbCap_ResDev.Width.Percentage(13)
            tbCap_ResActPrevious.Width = tbCap_ResActPrevious.Width.Percentage(20)
            TOLLib_CAp = totassets - totLibality

            tbCap_ResAct.Text = CStr(CType(tdLibilityTotalAct.Text, Double) + CType(tbTotCapitalAct.Text, Double))


            tbCap_ResActPrevious.Text = CStr(CType(tbLibilityTotalActPrevious.Text, Double) + CType(tbTotCapitalActPrevious.Text, Double))
            tbCap_ResActPrevious.Width = tbCap_ResActPrevious.Width.Percentage(20)
            trCap_ResName.Controls.Add(tbCap_ResActPrevious)
            tbCap_ResActPrevious.CssClass = "ReportHeadingsCenterBSYearly"
            tbCap_ResAct.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResAct)

            tbCap_ResEst.Text = Format(BPObject.Capital_Reserves, "f")
            tbCap_ResEst.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResEst)

            tbCap_ResDev.Text = Format(BPObject.Capital_Reserves - CType(tbCap_ResAct.Text, Double), "f")
            tbCap_ResDev.CssClass = "ReportHeadingsCenterBS"
            trCap_ResName.Controls.Add(tbCap_ResDev)
            Main.Rows.Add(trCap_ResName)
            trSpace = FillYearlyRows(tdSpace, trSpace)
            Main.Rows.Add(trSpace)
        Catch ex As Exception
            Dim strInfiniplanError As String = "AccountsProError"
        End Try
    End Sub

    Public Sub MonthlyIncomeStatement(ByVal IOPeriod As Integer, ByVal DateFrom As String)
        Dim ds As DataSet
        ds = objPlan.GetMonthlyIncomeStatemnt(GetConnectionData, CurrentPlan.PlanID, IOPeriod, CType(CurrentPlan.SalesForecastType, Integer))

        Dim dsPro As DataSet = objPlan.GetMonthlyIncomeStatemntPro(GetConnectionData, CurrentPlan.PlanID, DateFrom)

        Dim nav As String() = CurrentNavigator
        If (nav Is Nothing) Then nav = Navigator
        _dt = CType(BusinessTable.CreateMonthlyIOforPayroll(GetConnectionData, CurrentPlan, "Expenses", IOPeriod), BusinessTable)

        Dim trspace1 As New TableRow
        Dim trspace2 As New TableRow
        Dim trspace3 As New TableRow

        Dim trspace4 As New TableRow
        Dim trspace5 As New TableRow
        Dim trspace6 As New TableRow

        Dim tdspace As New TableCell
        tdspace.Text = "&nbsp;"
        ' Salse 
        Dim tbSales As New TableCell
        Dim trSales As New TableRow
        Dim tbSalesXsign As New TableCell
        Dim tbSalesYsign As New TableCell
        Dim tbSalesXYsign As New TableCell

        tbSales.Text = "Sales"
        tbSales.CssClass = "ReportHeadings"

        trSales.Controls.Add(tbSales)
        tbSales.Width = tbSales.Width.Percentage(53)

        tbSalesXsign.Width = tbSales.Width.Percentage(16)
        tbSalesYsign.Width = tbSales.Width.Percentage(16)
        tbSalesXYsign.Width = tbSales.Width.Percentage(28)
        tbSalesXsign.Text = ""
        tbSalesXsign.CssClass = "ReportHeadingsCenter"
        trSales.Controls.Add(tbSalesXsign)

        tbSalesYsign.Text = ""
        tbSalesYsign.CssClass = "ReportHeadingsCenter"

        trSales.Controls.Add(tbSalesYsign)

        tbSalesXYsign.Text = ""
        tbSalesXYsign.CssClass = "ReportHeadingsCenter"
        trSales.Controls.Add(tbSalesXYsign)
        Main.Rows.Add(trSales)
        Dim _rowloop1 As Integer
        For _rowloop1 = 0 To ds.Tables(0).Rows.Count - 1
            Dim strProductName As String = CType(ds.Tables(0).Rows(_rowloop1).Item(0), String)

            Dim tbSalesAct As New TableCell
            Dim tbSalsesEst As New TableCell
            Dim tbSalsesDev As New TableCell

            Dim trName As New TableRow
            Dim tdname As New TableCell
            tdname.CssClass = "ReportTitles"
            tdname.Text = strProductName
            trName.Controls.Add(tdname)

            tbSalesAct.Width = tbSalesAct.Width.Percentage(16)
            tbSalsesEst.Width = tbSalsesEst.Width.Percentage(16)
            tbSalsesDev.Width = tbSalsesDev.Width.Percentage(28)

            tbSalesAct.Text = Format(CType(dsPro.Tables(0).Rows(_rowloop1).Item(5), Double), "f")
            tbSalesAct.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalesAct)

            tbSalsesEst.Text = Format(CType(ds.Tables(0).Rows(_rowloop1).Item(4), Double), "f")
            tbSalsesEst.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalsesEst)

            tbSalsesDev.Text = Format(CType((dsPro.Tables(0).Rows(_rowloop1).Item(5)), Double) - _
             CType(ds.Tables(0).Rows(_rowloop1).Item(4), Double), "f")
            tbSalsesDev.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalsesDev)

            Main.Rows.Add(trName)
        Next

        Dim trSalesTotal As New TableRow
        Dim tdSalesTotal As New TableCell

        Dim tdSalesTotalAct As New TableCell
        Dim tdSalesTotalEst As New TableCell
        Dim tdSalesTotalDev As New TableCell

        tdSalesTotal.Text = "Total"
        tdSalesTotal.CssClass = "ReportTotalHeadings"
        trSalesTotal.Controls.Add(tdSalesTotal)

        trSalesTotal.Controls.Add(tdSalesTotalAct)

        If (CType(dsPro.Tables(1).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActaulSalseTotal = 0.0
        Else

            ActaulSalseTotal = CType(dsPro.Tables(1).Rows(0).Item(0), Double)
        End If


        tdSalesTotalAct.Text = Format(CType(ActaulSalseTotal, Double), "f")
        tdSalesTotalAct.CssClass = "ReportHeadingsCenter"

        trSalesTotal.Controls.Add(tdSalesTotalEst)
        EstimatesSalseTotal = CType(ds.Tables(1).Rows(0).Item(0), Double)
        tdSalesTotalEst.Text = Format(CType(ds.Tables(1).Rows(0).Item(0), Double), "f")
        tdSalesTotalEst.CssClass = "ReportHeadingsCenter"

        trSalesTotal.Controls.Add(tdSalesTotalDev)
        tdSalesTotalDev.Text = Format(ActaulSalseTotal - CType(ds.Tables(1).Rows(0).Item(0), Double), "f")

        tdSalesTotalDev.CssClass = "ReportHeadingsCenter"

        Main.Rows.Add(trSalesTotal)

        trspace1.Controls.Add(tdspace)
        Main.Rows.Add(trspace1)

        ' COST 
        Dim tbCOGS As New TableCell
        Dim trCOGS As New TableRow

        tbCOGS.Text = "Cost Of Sales"
        trCOGS.Controls.Add(tbCOGS)
        tbCOGS.CssClass = "ReportHeadings"
        Main.Rows.Add(trCOGS)
        Dim _rowloop2 As Integer
        For _rowloop2 = 0 To ds.Tables(0).Rows.Count - 1
            Dim COGS As String = CType(ds.Tables(0).Rows(_rowloop2).Item(0), String)

            Dim tbCOGSAct As New TableCell
            Dim tbCOGSEst As New TableCell
            Dim tbCOGSDev As New TableCell

            Dim trCostSold As New TableRow
            Dim tdCostSold As New TableCell
            tdCostSold.CssClass = "ReportTitles"
            tdCostSold.Text = COGS
            trCostSold.Controls.Add(tdCostSold)

            tbCOGSAct.Width = tbCOGSAct.Width.Percentage(16)
            tbCOGSEst.Width = tbCOGSEst.Width.Percentage(16)
            tbCOGSDev.Width = tbCOGSDev.Width.Percentage(28)

            tbCOGSAct.Text = Format(CType(dsPro.Tables(0).Rows(_rowloop2).Item(6), Double), "f")
            tbCOGSAct.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSAct)

            tbCOGSEst.Text = Format(CType(ds.Tables(0).Rows(_rowloop2).Item(5), Double), "f")
            tbCOGSEst.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSEst)

            tbCOGSDev.Text = Format(CType((dsPro.Tables(0).Rows(_rowloop2).Item(6)), Double) - _
             CType(ds.Tables(0).Rows(_rowloop2).Item(3), Double), "f")
            tbCOGSDev.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSDev)
            Main.Rows.Add(trCostSold)
        Next

        'Other 
        Dim tbothers As New TableCell
        Dim trothers As New TableRow
        tbothers.Text = "Others"
        trothers.Controls.Add(tbothers)
        tbothers.CssClass = "ReportTotalHeadings"
        Dim tbothersAct As New TableCell
        Dim tbothersEst As New TableCell
        Dim tbothersDev As New TableCell

        tbothersAct.Width = tbothersAct.Width.Percentage(16)
        tbothersEst.Width = tbothersEst.Width.Percentage(16)
        tbothersDev.Width = tbothersDev.Width.Percentage(28)

        tbothersAct.Text = "0.0"
        tbothersAct.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersAct)

        tbothersEst.Text = Format(CType(ds.Tables(4).Rows(0).Item(0), Double), "f")
        otherEst = CType(ds.Tables(4).Rows(0).Item(0), Double)
        tbothersEst.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersEst)

        tbothersDev.Text = Format(0.0 - CType(ds.Tables(4).Rows(0).Item(0), Double), "f")
        tbothersDev.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersDev)

        Main.Rows.Add(trothers)
        trspace3.Controls.Add(tdspace)
        Main.Rows.Add(trspace3)
        'Others End 

        Dim trCOGSTotal As New TableRow
        Dim tdCOGSTotalAct As New TableCell
        Dim tdCOGSTotalEst As New TableCell
        Dim tdCOGSTotalDev As New TableCell
        Dim tdCOGSTotal As New TableCell

        tdCOGSTotal.Text = "Total"
        tdCOGSTotal.CssClass = "ReportTotalHeadings"
        trCOGSTotal.Controls.Add(tdCOGSTotal)

        If (CType(dsPro.Tables(1).Rows(0).Item(1), Object).Equals(DBNull.Value)) Then
            ActaulCOGSTotal = 0.0
        Else
            ActaulCOGSTotal = CType(dsPro.Tables(1).Rows(0).Item(1), Double)
        End If

        tdCOGSTotalAct.Text = Format(CType(ActaulCOGSTotal, Double), "f")
        tdCOGSTotalAct.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalAct)
        EstimatesCOGSTotal = CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst
        tdCOGSTotalEst.Text = Format((CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst), "f")
        tdCOGSTotalEst.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalEst)

        tdCOGSTotalDev.Text = Format(ActaulCOGSTotal - (CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst), "f")

        tdCOGSTotalDev.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalDev)

        Main.Rows.Add(trCOGSTotal)

        trspace2.Controls.Add(tdspace)
        Main.Rows.Add(trspace2)


        ' GP 
        Dim tbGP As New TableCell
        Dim trGP As New TableRow

        tbGP.Text = "Gross Profit"
        trGP.Controls.Add(tbGP)
        tbGP.CssClass = "ReportHeadings"
        Dim tbGPAct As New TableCell
        Dim tbGPEst As New TableCell
        Dim tbGPDev As New TableCell

        tbGPAct.Width = tbGPAct.Width.Percentage(16)
        tbGPEst.Width = tbGPEst.Width.Percentage(16)
        tbGPDev.Width = tbGPDev.Width.Percentage(28)

        tbGPAct.Text = Format((ActaulSalseTotal - ActaulCOGSTotal), "f")
        tbGPAct.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPAct)
        GrossProfitAct = ActaulSalseTotal - ActaulCOGSTotal
        GrossProfitEst = EstimatesSalseTotal - EstimatesCOGSTotal

        tbGPEst.Text = Format(GrossProfitEst, "f")

        tbGPEst.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPEst)

        tbGPDev.Text = Format((0.0) - _
        GrossProfitEst, "f")
        tbGPDev.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPDev)

        Main.Rows.Add(trGP)
        trspace3.Controls.Add(tdspace)
        Main.Rows.Add(trspace3)

        ' Expnses 
        Dim tbExpenses As New TableCell
        Dim trExpenses As New TableRow

        tbExpenses.Text = "Operating Expenses "
        trExpenses.Controls.Add(tbExpenses)
        tbExpenses.CssClass = "ReportHeadings"
        Main.Rows.Add(trExpenses)

        Dim trpayroll As New TableRow
        Dim tdpayroll As New TableCell

        tdpayroll.CssClass = "ReportTitles"
        tdpayroll.Text = "Net Salary Expense"
        trpayroll.Controls.Add(tdpayroll)
        Main.Rows.Add(trpayroll)

        Dim tbpayrollAct As New TableCell
        Dim tbpayrollEst As New TableCell
        Dim tbpayrollDev As New TableCell

        tbpayrollAct.Width = tbpayrollAct.Width.Percentage(16)
        tbpayrollEst.Width = tbpayrollEst.Width.Percentage(16)
        tbpayrollDev.Width = tbpayrollDev.Width.Percentage(28)

        tbpayrollAct.Text = Format(CType(dsPro.Tables(5).Rows(0).Item(0), Double), "f")
        salaryAct = CType(dsPro.Tables(5).Rows(0).Item(0), Double)

        Dim salaryDev As Double
        tbpayrollAct.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollAct)

        salaryEst = BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden
        tbpayrollEst.Text = Format(BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden, "f")

        tbpayrollEst.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollEst)
        salaryDev = salaryEst - salaryAct
        tbpayrollDev.Text = Format((BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden) - salaryAct, "f")
        tbpayrollDev.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollDev)
        Main.Rows.Add(trpayroll)

        Dim _rowloop3 As Integer
        For _rowloop3 = 0 To ds.Tables(2).Rows.Count - 1
            Dim ExpenseName As String = CType(ds.Tables(2).Rows(_rowloop3).Item(0), String)
            Dim trExpName As New TableRow
            Dim tdExpName As New TableCell

            Dim tbExpensesAct As New TableCell
            Dim tbExpensesEst As New TableCell
            Dim tbExpensesDev As New TableCell

            tdExpName.CssClass = "ReportTitles"
            tdExpName.Text = ExpenseName
            trExpName.Controls.Add(tdExpName)

            tbExpensesAct.Width = tbExpensesAct.Width.Percentage(16)
            tbExpensesEst.Width = tbExpensesEst.Width.Percentage(16)
            tbExpensesDev.Width = tbExpensesDev.Width.Percentage(28)

            tbExpensesAct.Text = Format(CType(dsPro.Tables(3).Rows(_rowloop3).Item(3), Double), "f")
            ActualExpensesTotal = CType(dsPro.Tables(3).Rows(_rowloop3).Item(3), Double)
            tbExpensesAct.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesAct)

            tbExpensesEst.Text = Format(CType(ds.Tables(2).Rows(_rowloop3).Item(1), Double), "f")
            tbExpensesEst.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesEst)

            tbExpensesDev.Text = Format(CType((dsPro.Tables(3).Rows(_rowloop3).Item(3)), Double) - _
             CType(ds.Tables(2).Rows(_rowloop3).Item(1), Double), "f")
            tbExpensesDev.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesDev)
            Main.Rows.Add(trExpName)
        Next

        Dim trExpenseTotal As New TableRow
        Dim tdExpenseAct As New TableCell
        Dim tdExpenseEst As New TableCell
        Dim tdExpenseDev As New TableCell

        Dim tdExpenseTotal As New TableCell
        tdExpenseTotal.Text = "Total"
        tdExpenseTotal.CssClass = "ReportTotalHeadings"
        trExpenseTotal.Controls.Add(tdExpenseTotal)

        If (CType(dsPro.Tables(4).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActualExpensesTotal = 0.0 + salaryAct
        Else
            ActualExpensesTotal = CType(dsPro.Tables(4).Rows(0).Item(0), Double) + salaryAct

        End If

        tdExpenseAct.Text = Format(ActualExpensesTotal, "f")
        tdExpenseAct.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseAct)

        EstimatesExpensesTotal = Math.Round(CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden)
        tdExpenseEst.Text = Format(Math.Round((CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden)), "f")
        tdExpenseEst.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseEst)

        tdExpenseDev.Text = Format(Math.Round(CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden) - _
       (CType(dsPro.Tables(4).Rows(0).Item(0), Double)), "f")
        tdExpenseDev.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseDev)
        Main.Rows.Add(trExpenseTotal)

        trspace5.Controls.Add(tdspace)
        Main.Rows.Add(trspace5)
        ' EBIT 
        Dim tbEBIT As New TableCell

        Dim tdEBITAct As New TableCell
        Dim tdEBITEst As New TableCell
        Dim tdEBITDev As New TableCell
        Dim trEBIT As New TableRow
        EBITValue = GrossProfitEst - Math.Round(EstimatesExpensesTotal)
        tbEBIT.Text = "EBIT ( Earning before Interest & Taxes ) "
        trEBIT.Controls.Add(tbEBIT)
        tbEBIT.CssClass = "ReportHeadings"
        EBITValueActual = GrossProfitAct - ActualExpensesTotal
        tdEBITAct.Text = Format(Math.Ceiling(EBITValueActual), "f")
        tdEBITAct.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITAct)

        tdEBITEst.Text = Format((EBITValue), "f")
        tdEBITEst.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITEst)

        tdEBITDev.Text = Format(EBITValueActual - EBITValue, "f")
        tdEBITDev.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITDev)

        Main.Rows.Add(trEBIT)

        trspace6.Controls.Add(tdspace)
        Main.Rows.Add(trspace6)

    End Sub

    Public Sub AnnualIncomeStatement(ByVal IOPeriod As Integer, ByVal DateFrom As String, ByVal PreviousDate As String)
        lnkBackMonth.Visible = False
        lnkFirst.Visible = False
        lnkLast.Visible = False
        lnkNextMonth.Visible = False
        Dim ds As DataSet = objPlan.GetAnnualIncomeStatemnt(GetConnectionData, CurrentPlan.PlanID, CType(CurrentPlan.SalesForecastType, Integer))
        Dim dsPro As DataSet = objPlan.GetAnnualIncomeStatemntPro(GetConnectionData, CurrentPlan.PlanID, DateFrom)
        Dim dsProPrevious As DataSet = objPlan.GetAnnualIncomeStatemntPro(GetConnectionData, CurrentPlan.PlanID, PreviousDate)

        Dim nav As String() = CurrentNavigator
        If (nav Is Nothing) Then nav = Navigator
        _dt = CType(BusinessTable.CreateAnnualIOforPayroll(GetConnectionData, CurrentPlan, "Expenses"), BusinessTable)



        Dim trspace1 As New TableRow
        Dim trspace2 As New TableRow
        Dim trspace3 As New TableRow

        Dim trspace4 As New TableRow
        Dim trspace5 As New TableRow
        Dim trspace6 As New TableRow

        Dim tdspace As New TableCell
        tdspace.Text = "&nbsp;"
        ' Salse 
        Dim tbSales As New TableCell
        Dim trSales As New TableRow
        Dim tbSalesXsign As New TableCell
        Dim tbSalesYsign As New TableCell
        Dim tbSalesXYsign As New TableCell
        Dim tbSalesXYsignPrevious As New TableCell
        tbSales.Text = "Sales"
        tbSales.CssClass = "ReportHeadings"

        trSales.Controls.Add(tbSales)
        tbSales.Width = tbSales.Width.Percentage(41)

        tbSalesXsign.Width = tbSales.Width.Percentage(13)
        tbSalesYsign.Width = tbSales.Width.Percentage(13)
        '   tbSalesXYsign.Width = tbSales.Width.Percentage(28)
        tbSalesXYsignPrevious.Width = tbSalesXYsignPrevious.Width.Percentage(20)
        tbSalesXYsignPrevious.Text = " "
        tbSalesXYsignPrevious.CssClass = "ReportHeadingsYearly"
        trSales.Controls.Add(tbSalesXYsignPrevious)

        tbSalesXsign.Text = ""
        tbSalesXsign.CssClass = ""
        trSales.Controls.Add(tbSalesXsign)

        tbSalesYsign.Text = ""
        tbSalesYsign.CssClass = ""

        trSales.Controls.Add(tbSalesYsign)

        tbSalesXYsign.Text = ""
        tbSalesXYsign.CssClass = ""
        trSales.Controls.Add(tbSalesXYsign)
        Main.Rows.Add(trSales)
        Dim _rowloop1 As Integer
        For _rowloop1 = 0 To ds.Tables(0).Rows.Count - 1
            Dim strProductName As String = CType(ds.Tables(0).Rows(_rowloop1).Item(0), String)
            Dim tbSalesActPrevious As New TableCell
            Dim tbSalesAct As New TableCell
            Dim tbSalsesEst As New TableCell
            Dim tbSalsesDev As New TableCell

            Dim trName As New TableRow
            Dim tdname As New TableCell
            tdname.CssClass = "ReportTitles"
            tdname.Text = strProductName
            trName.Controls.Add(tdname)

            tbSalesAct.Width = tbSalesAct.Width.Percentage(13)
            tbSalsesEst.Width = tbSalsesEst.Width.Percentage(13)
            ' tbSalsesDev.Width = tbSalsesDev.Width.Percentage(28)
            tbSalesActPrevious.Width = tbSalesActPrevious.Width.Percentage(20)

            tbSalesActPrevious.Text = Format(CType(dsProPrevious.Tables(0).Rows(_rowloop1).Item(5), Double), "f")
            tbSalesActPrevious.CssClass = "ReportFiguresPrevious"
            trName.Controls.Add(tbSalesActPrevious)

            tbSalesAct.Text = Format(CType(dsPro.Tables(0).Rows(_rowloop1).Item(5), Double), "f")
            tbSalesAct.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalesAct)

            tbSalsesEst.Text = Format(CType(ds.Tables(0).Rows(_rowloop1).Item(2), Double), "f")
            tbSalsesEst.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalsesEst)

            tbSalsesDev.Text = Format(CType((dsPro.Tables(0).Rows(_rowloop1).Item(5)), Double) - _
             CType(ds.Tables(0).Rows(_rowloop1).Item(2), Double), "f")
            tbSalsesDev.CssClass = "ReportFigures"
            trName.Controls.Add(tbSalsesDev)

            Main.Rows.Add(trName)
        Next

        Dim trSalesTotal As New TableRow
        Dim tdSalesTotal As New TableCell

        Dim tdSalesTotalAct As New TableCell
        Dim tdSalesTotalEst As New TableCell
        Dim tdSalesTotalDev As New TableCell
        Dim tdSalesTotalActPrevious As New TableCell
        tdSalesTotal.Text = "Total"
        tdSalesTotal.CssClass = "ReportTotalHeadings"
        trSalesTotal.Controls.Add(tdSalesTotal)



        If (CType(dsPro.Tables(1).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActaulSalseTotal = 0.0
        Else

            ActaulSalseTotal = CType(dsPro.Tables(1).Rows(0).Item(0), Double)
        End If

        If (CType(dsProPrevious.Tables(1).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActaulSalseTotalPrevious = 0.0
        Else

            ActaulSalseTotalPrevious = CType(dsProPrevious.Tables(1).Rows(0).Item(0), Double)
        End If

        tdSalesTotalActPrevious.Text = Format(CType(ActaulSalseTotalPrevious, Double), "f")
        tdSalesTotalActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trSalesTotal.Controls.Add(tdSalesTotalActPrevious)

        tdSalesTotalAct.Text = Format(CType(ActaulSalseTotal, Double), "f")
        tdSalesTotalAct.CssClass = "ReportHeadingsCenter"
        trSalesTotal.Controls.Add(tdSalesTotalAct)


        trSalesTotal.Controls.Add(tdSalesTotalEst)
        EstimatesSalseTotal = CType(ds.Tables(1).Rows(0).Item(0), Double)
        tdSalesTotalEst.Text = Format(CType(ds.Tables(1).Rows(0).Item(0), Double), "f")
        tdSalesTotalEst.CssClass = "ReportHeadingsCenter"

        trSalesTotal.Controls.Add(tdSalesTotalDev)
        tdSalesTotalDev.Text = Format(ActaulSalseTotal - CType(ds.Tables(1).Rows(0).Item(0), Double), "f")


        tdSalesTotalDev.CssClass = "ReportHeadingsCenter"

        Main.Rows.Add(trSalesTotal)

        trspace1.Controls.Add(tdspace)
        Main.Rows.Add(trspace1)

        ' ' COST 

        Dim tbCOGS As New TableCell
        Dim trCOGS As New TableRow

        tbCOGS.Text = "Cost Of Sales"
        trCOGS.Controls.Add(tbCOGS)
        tbCOGS.CssClass = "ReportHeadings"
        trCOGS = FillYearlyRows(tbCOGS, trCOGS)
        Main.Rows.Add(trCOGS)
        Dim _rowloop2 As Integer
        For _rowloop2 = 0 To ds.Tables(0).Rows.Count - 1
            Dim COGS As String = CType(ds.Tables(0).Rows(_rowloop2).Item(0), String)
            Dim tbCOGSActPrevious As New TableCell
            Dim tbCOGSAct As New TableCell
            Dim tbCOGSEst As New TableCell
            Dim tbCOGSDev As New TableCell

            Dim trCostSold As New TableRow
            Dim tdCostSold As New TableCell
            tdCostSold.CssClass = "ReportTitles"
            tdCostSold.Text = COGS
            trCostSold.Controls.Add(tdCostSold)

            tbCOGSAct.Width = tbCOGSAct.Width.Percentage(13)
            tbCOGSEst.Width = tbCOGSEst.Width.Percentage(13)
            'tbCOGSDev.Width = tbCOGSDev.Width.Percentage(28)
            tbCOGSActPrevious.Width = tbCOGSActPrevious.Width.Percentage(20)

            tbCOGSActPrevious.Text = Format(CType(dsProPrevious.Tables(0).Rows(_rowloop2).Item(6), Double), "f")
            tbCOGSActPrevious.CssClass = "ReportFiguresPrevious"
            trCostSold.Controls.Add(tbCOGSActPrevious)

            tbCOGSAct.Text = Format(CType(dsPro.Tables(0).Rows(_rowloop2).Item(6), Double), "f")
            tbCOGSAct.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSAct)

            tbCOGSEst.Text = Format(CType(ds.Tables(0).Rows(_rowloop2).Item(3), Double), "f")
            tbCOGSEst.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSEst)

            tbCOGSDev.Text = Format(CType((dsPro.Tables(0).Rows(_rowloop2).Item(6)), Double) - _
             CType(ds.Tables(0).Rows(_rowloop2).Item(3), Double), "f")
            tbCOGSDev.CssClass = "ReportFigures"
            trCostSold.Controls.Add(tbCOGSDev)
            Main.Rows.Add(trCostSold)
        Next

        ' 'Other 
        Dim tbothers As New TableCell
        Dim trothers As New TableRow
        tbothers.Text = "Others"
        trothers.Controls.Add(tbothers)
        tbothers.CssClass = "ReportTotalHeadings"
        Dim tbothersActPrevious As New TableCell
        Dim tbothersAct As New TableCell
        Dim tbothersEst As New TableCell
        Dim tbothersDev As New TableCell

        tbothersAct.Width = tbothersAct.Width.Percentage(13)
        tbothersEst.Width = tbothersEst.Width.Percentage(13)
        '  tbothersDev.Width = tbothersDev.Width.Percentage(28)
        tbothersActPrevious.Width = tbothersActPrevious.Width.Percentage(20)

        tbothersActPrevious.Text = "0.0" 'Format("0.0", "f")
        tbothersActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trothers.Controls.Add(tbothersActPrevious)

        tbothersAct.Text = "0.0" 'Format("0.0", "f")
        tbothersAct.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersAct)

        tbothersEst.Text = Format(CType(ds.Tables(4).Rows(0).Item(0), Double), "f")
        otherEst = CType(ds.Tables(4).Rows(0).Item(0), Double)
        tbothersEst.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersEst)

        tbothersDev.Text = Format(0.0 - CType(ds.Tables(4).Rows(0).Item(0), Double), "f")
        tbothersDev.CssClass = "ReportHeadingsCenter"
        trothers.Controls.Add(tbothersDev)

        Main.Rows.Add(trothers)
        trspace3.Controls.Add(tdspace)
        Main.Rows.Add(trspace3)

        ' 'Others End 

        '' CoGS Total
        Dim trCOGSTotal As New TableRow
        Dim tdCOGSTotalActPrevious As New TableCell
        Dim tdCOGSTotalAct As New TableCell
        Dim tdCOGSTotalEst As New TableCell
        Dim tdCOGSTotalDev As New TableCell
        Dim tdCOGSTotal As New TableCell

        tdCOGSTotal.Text = "Total"
        tdCOGSTotal.CssClass = "ReportTotalHeadings"
        trCOGSTotal.Controls.Add(tdCOGSTotal)

        If (CType(dsPro.Tables(1).Rows(0).Item(1), Object).Equals(DBNull.Value)) Then
            ActaulCOGSTotal = 0.0
        Else
            ActaulCOGSTotal = CType(dsPro.Tables(1).Rows(0).Item(1), Double)
        End If

        If (CType(dsProPrevious.Tables(1).Rows(0).Item(1), Object).Equals(DBNull.Value)) Then
            ActaulCOGSTotalPrevious = 0.0
        Else
            ActaulCOGSTotalPrevious = CType(dsProPrevious.Tables(1).Rows(0).Item(1), Double)
        End If

        tdCOGSTotalActPrevious.Text = Format(CType(ActaulCOGSTotalPrevious, Double), "f")
        tdCOGSTotalActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trCOGSTotal.Controls.Add(tdCOGSTotalActPrevious)

        tdCOGSTotalAct.Text = Format(CType(ActaulCOGSTotal, Double), "f")
        tdCOGSTotalAct.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalAct)

        EstimatesCOGSTotal = CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst
        tdCOGSTotalEst.Text = Format((CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst), "f")
        tdCOGSTotalEst.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalEst)

        tdCOGSTotalDev.Text = Format(ActaulCOGSTotal - (CType(ds.Tables(1).Rows(0).Item(1), Double) + otherEst), "f")


        tdCOGSTotalDev.CssClass = "ReportHeadingsCenter"
        trCOGSTotal.Controls.Add(tdCOGSTotalDev)

        Main.Rows.Add(trCOGSTotal)

        trspace2.Controls.Add(tdspace)
        Main.Rows.Add(trspace2)

        ' ' GP 
        Dim tbGP As New TableCell
        Dim trGP As New TableRow

        tbGP.Text = "Gross Profit"
        trGP.Controls.Add(tbGP)
        tbGP.CssClass = "ReportHeadings"
        Dim tbGPActPrevious As New TableCell
        Dim tbGPAct As New TableCell
        Dim tbGPEst As New TableCell
        Dim tbGPDev As New TableCell

        tbGPAct.Width = tbGPAct.Width.Percentage(13)
        tbGPEst.Width = tbGPEst.Width.Percentage(13)
        '   tbGPDev.Width = tbGPDev.Width.Percentage(28)
        tbGPActPrevious.Width = tbGPActPrevious.Width.Percentage(20)

        tbGPActPrevious.Text = Format((ActaulSalseTotalPrevious - ActaulCOGSTotalPrevious), "f")
        tbGPActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trGP.Controls.Add(tbGPActPrevious)


        tbGPAct.Text = Format((ActaulSalseTotal - ActaulCOGSTotal), "f")
        tbGPAct.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPAct)

        GrossProfitActPrevious = ActaulSalseTotalPrevious - ActaulCOGSTotalPrevious
        GrossProfitAct = ActaulSalseTotal - ActaulCOGSTotal
        GrossProfitEst = EstimatesSalseTotal - EstimatesCOGSTotal
        tbGPEst.Text = Format(GrossProfitEst, "f")

        tbGPEst.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPEst)

        tbGPDev.Text = Format(((ActaulSalseTotal - ActaulCOGSTotal) - _
       GrossProfitEst), "f")
        tbGPDev.CssClass = "ReportHeadingsCenter"
        trGP.Controls.Add(tbGPDev)

        Main.Rows.Add(trGP)
        trspace3.Controls.Add(tdspace)
        Main.Rows.Add(trspace3)

        ' ' Expnses 
        Dim tbExpenses As New TableCell
        Dim trExpenses As New TableRow

        tbExpenses.Text = "Operating Expenses "
        trExpenses.Controls.Add(tbExpenses)
        tbExpenses.CssClass = "ReportHeadings"
        trExpenses = FillYearlyRows(tbExpenses, trExpenses)
        Main.Rows.Add(trExpenses)

        ' '  Payroll Expnses 
        Dim trpayroll As New TableRow
        Dim tdpayroll As New TableCell

        tdpayroll.CssClass = "ReportTitles"
        tdpayroll.Text = "Net Salary Expense"
        trpayroll.Controls.Add(tdpayroll)
        Main.Rows.Add(trpayroll)
        Dim tbpayrollActPrevious As New TableCell
        Dim tbpayrollAct As New TableCell
        Dim tbpayrollEst As New TableCell
        Dim tbpayrollDev As New TableCell

        tbpayrollAct.Width = tbpayrollAct.Width.Percentage(13)
        tbpayrollEst.Width = tbpayrollEst.Width.Percentage(13)
        'tbpayrollDev.Width = tbpayrollDev.Width.Percentage(28)
        tbpayrollActPrevious.Width = tbpayrollActPrevious.Width.Percentage(20)

        tbpayrollActPrevious.Text = Format(CType(dsProPrevious.Tables(5).Rows(0).Item(0), Double), "f")
        salaryActPrevious = CType(dsProPrevious.Tables(5).Rows(0).Item(0), Double)

        tbpayrollActPrevious.CssClass = "ReportFiguresPrevious"
        trpayroll.Controls.Add(tbpayrollActPrevious)


        tbpayrollAct.Text = Format(CType(dsPro.Tables(5).Rows(0).Item(0), Double), "f")
        salaryAct = CType(dsPro.Tables(5).Rows(0).Item(0), Double)
        Dim salaryDev As Double
        tbpayrollAct.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollAct)

        salaryEst = BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden
        tbpayrollEst.Text = Format(BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden, "f")

        tbpayrollEst.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollEst)
        salaryDev = salaryEst - salaryAct
        tbpayrollDev.Text = Format((BPObjectPayroll.Payroll_Expense + BPObjectPayroll.Payroll_Burden) - salaryAct, "f")
        tbpayrollDev.CssClass = "ReportFigures"
        trpayroll.Controls.Add(tbpayrollDev)
        Main.Rows.Add(trpayroll)

        Dim _rowloop3 As Integer
        For _rowloop3 = 0 To ds.Tables(2).Rows.Count - 1
            Dim ExpenseName As String = CType(ds.Tables(2).Rows(_rowloop3).Item(0), String)
            Dim trExpName As New TableRow
            Dim tdExpName As New TableCell
            Dim tbExpensesActPrevious As New TableCell
            Dim tbExpensesAct As New TableCell
            Dim tbExpensesEst As New TableCell
            Dim tbExpensesDev As New TableCell

            tdExpName.CssClass = "ReportTitles"
            tdExpName.Text = ExpenseName
            trExpName.Controls.Add(tdExpName)

            tbExpensesAct.Width = tbExpensesAct.Width.Percentage(13)
            tbExpensesEst.Width = tbExpensesEst.Width.Percentage(13)
            'tbExpensesDev.Width = tbExpensesDev.Width.Percentage(28)
            tbExpensesActPrevious.Width = tbExpensesActPrevious.Width.Percentage(20)

            tbExpensesActPrevious.Text = Format(CType(dsProPrevious.Tables(3).Rows(_rowloop3).Item(3), Double), "f")
            ActualExpensesTotalPrevious = CType(dsProPrevious.Tables(3).Rows(_rowloop3).Item(3), Double)
            tbExpensesActPrevious.CssClass = "ReportFiguresPrevious"
            trExpName.Controls.Add(tbExpensesActPrevious)

            tbExpensesAct.Text = Format(CType(dsPro.Tables(3).Rows(_rowloop3).Item(3), Double), "f")
            ActualExpensesTotal = CType(dsPro.Tables(3).Rows(_rowloop3).Item(3), Double)
            tbExpensesAct.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesAct)

            tbExpensesEst.Text = Format(CType(ds.Tables(2).Rows(_rowloop3).Item(2), Double), "f")
            tbExpensesEst.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesEst)

            tbExpensesDev.Text = Format(CType((dsPro.Tables(3).Rows(_rowloop3).Item(3)), Double) - _
             CType(ds.Tables(2).Rows(_rowloop3).Item(2), Double), "f")
            tbExpensesDev.CssClass = "ReportFigures"
            trExpName.Controls.Add(tbExpensesDev)
            Main.Rows.Add(trExpName)
        Next

        ' ' Expnses Total

        Dim trExpenseTotal As New TableRow

        Dim tdExpenseActPrevious As New TableCell
        Dim tdExpenseAct As New TableCell
        Dim tdExpenseEst As New TableCell
        Dim tdExpenseDev As New TableCell

        Dim tdExpenseTotal As New TableCell
        tdExpenseTotal.Text = "Total"
        tdExpenseTotal.CssClass = "ReportTotalHeadings"
        trExpenseTotal.Controls.Add(tdExpenseTotal)

        If (CType(dsPro.Tables(4).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActualExpensesTotal = 0.0 + salaryAct
        Else
            ActualExpensesTotal = CType(dsPro.Tables(4).Rows(0).Item(0), Double) + salaryAct

        End If

        If (CType(dsProPrevious.Tables(4).Rows(0).Item(0), Object).Equals(DBNull.Value)) Then
            ActualExpensesTotalPrevious = 0.0 + salaryActPrevious
        Else
            ActualExpensesTotalPrevious = CType(dsProPrevious.Tables(4).Rows(0).Item(0), Double) + salaryActPrevious

        End If

        tdExpenseActPrevious.Text = Format(ActualExpensesTotalPrevious, "f")

        tdExpenseActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trExpenseTotal.Controls.Add(tdExpenseActPrevious)

        tdExpenseAct.Text = Format(ActualExpensesTotal, "f")

        tdExpenseAct.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseAct)

        EstimatesExpensesTotal = CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden
        tdExpenseEst.Text = Format(Math.Round(CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden), "f")
        tdExpenseEst.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseEst)

        tdExpenseDev.Text = Format((CType(ds.Tables(3).Rows(0).Item(0), Double) + BPObjectPayroll.Payroll_Burden) - _
       CType(dsPro.Tables(4).Rows(0).Item(0), Double), "f")
        tdExpenseDev.CssClass = "ReportHeadingsCenter"
        trExpenseTotal.Controls.Add(tdExpenseDev)
        Main.Rows.Add(trExpenseTotal)

        trspace5.Controls.Add(tdspace)
        Main.Rows.Add(trspace5)

        ' ' EBIT 
        Dim tbEBIT As New TableCell

        Dim tdEBITActPrevious As New TableCell
        Dim tdEBITAct As New TableCell
        Dim tdEBITEst As New TableCell
        Dim tdEBITDev As New TableCell
        Dim trEBIT As New TableRow
        EBITValue = GrossProfitEst - Math.Round(EstimatesExpensesTotal)
        tbEBIT.Text = "EBIT ( Earning before Interest & Taxes ) "
        trEBIT.Controls.Add(tbEBIT)
        tbEBIT.CssClass = "ReportHeadings"

        EBITValueActualPrevious = GrossProfitActPrevious - ActualExpensesTotalPrevious
        tdEBITActPrevious.Text = Format(Math.Ceiling(EBITValueActualPrevious), "f")
        tdEBITActPrevious.CssClass = "ReportHeadingsCenterYearly"
        trEBIT.Controls.Add(tdEBITActPrevious)

        EBITValueActual = GrossProfitAct - ActualExpensesTotal
        tdEBITAct.Text = Format(Math.Ceiling(EBITValueActual), "f")
        tdEBITAct.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITAct)

        tdEBITEst.Text = Format((EBITValue), "f")
        tdEBITEst.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITEst)

        tdEBITDev.Text = Format(EBITValueActual - EBITValue, "f")
        tdEBITDev.CssClass = "ReportHeadingsCenter"
        trEBIT.Controls.Add(tdEBITDev)

        Main.Rows.Add(trEBIT)

        trspace6.Controls.Add(tdspace)
        Main.Rows.Add(trspace6)


    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/PlanTracker.aspx?ret=1")
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Response.Redirect("/InfiniPlan/services/welcome.aspx")
    End Sub

    Public Function DateSettings() As String
        lblName.Text = CurrentPlan.PlanName
        displayYear = CurrentPlan.StartYear

        Dim strMonthArry As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", _
        "Aug", "Sep", "Oct", "Nov", "Dec"}
        Dim intloop As Integer

        For intloop = 0 To strMonthArry.Length - 1

            Dim MonthID As Integer = CInt([Enum].Parse(GetType(BusinessPlanMonths), strMonthArry(intloop)))

            Dim StartMonthID As Integer = CInt([Enum].Parse(GetType(BusinessPlanMonths), CurrentPlan.StartMonth))
            MonthID = (MonthID + StartMonthID) Mod 12
            Session("ID") = StartMonthID
            month.Add(intloop, ([Enum].GetName(GetType(BusinessPlanMonths), MonthID)))

        Next
    End Function

    Private Function GetBalanceSheetValues(ByVal fromDate As Date, ByVal toDate As Date, ByVal findingValues As String) As String

        bsDV.RowFilter = "Description='" & findingValues & "'"

        If bsDV.Count > 0 Then
            Return FormatNumber(bsDV.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If

    End Function

    Private Function GetBalanceSheetValuesLastYears(ByVal fromDatePrevious As Date, ByVal toDaterevious As Date, ByVal findingValues As String) As String

        bsDVForLastYears.RowFilter = "Description='" & findingValues & "'"

        If bsDVForLastYears.Count > 0 Then
            Return FormatNumber(bsDVForLastYears.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If

    End Function

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

    Public Sub PopulatePreviousYears()
        ddlPreviosYears.Items.Clear()
        Dim intEndPreviousYear As Integer
        Dim startingMonth As Integer
        Dim intStartPreviousYear As Integer
        Dim endingMonth As Integer


        startingMonth = CInt([Enum].Parse(GetType(BusinessPlanMonths), CurrentPlan.StartMonth))

        Dim strValueMonthArry As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", _
     "Aug", "Sep", "Oct", "Nov", "Dec"}

        If startingMonth = 0 Then

            intStartPreviousYear = CurrentPlan.StartYear - 1
            intEndPreviousYear = intStartPreviousYear
        ElseIf startingMonth > 0 Then
            intStartPreviousYear = CurrentPlan.StartYear - 1
            intEndPreviousYear = intStartPreviousYear + 1
        End If

        For i As Integer = 0 To 11
            startingMonth += 1
            endingMonth = startingMonth
            If startingMonth > 11 Then
                startingMonth = 0
            End If
        Next

        Dim intloop As Integer
        ddlPreviosYears.Items.Add(New ListItem(""))

        For intloop = 0 To 10

            Dim strStartingDate As String = strValueMonthArry.GetValue(startingMonth).ToString & " " & (intStartPreviousYear) - intloop
            Dim strEndingingDate As String = strValueMonthArry.GetValue(endingMonth - 1).ToString & " " & (intEndPreviousYear) - intloop
            Dim strStartingDateval As String = strValueMonthArry.GetValue(startingMonth).ToString & (intStartPreviousYear) - intloop
            ddlPreviosYears.Items.Add(New ListItem(strStartingDate + " to " + strEndingingDate, strStartingDateval))

        Next
    End Sub

    Private Sub ddlPreviosYears_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPreviosYears.SelectedIndexChanged
        If _ReportID = 2 Then
            AnnualIncomeStatement(Period, CurrentPlan.StartMonth + CType(CurrentPlan.StartYear, String), ddlPreviosYears.SelectedValue)
        ElseIf _ReportID = 4 Then
            AnnualBalanceSheet(0, CurrentPlan.StartMonth + CType(CurrentPlan.StartYear, String), ddlPreviosYears.SelectedValue)
        End If
    End Sub

    Private Sub cmbMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMonth.SelectedIndexChanged
        If _ReportID = 1 Then
            MonthlyIncomeStatement(GertMonthIndex(cmbMonth.SelectedValue), cmbMonth.SelectedValue)
        ElseIf _ReportID = 3 Then
            MonthlyBalanceSheet(GertMonthIndex(cmbMonth.SelectedValue), cmbMonth.SelectedValue)
        End If
    End Sub

    Function GertMonthIndex(ByVal month As String) As Integer
        Dim mon As String() = Split(month, " ")
        If mon.Length > 1 Then
            Select Case mon(0)
                Case "Jan"
                    Return 1
                Case "Feb"
                    Return 2
                Case "Mar"
                    Return 3
                Case "Apr"
                    Return 4
                Case "May"
                    Return 5
                Case "Jun"
                    Return 6
                Case "Jul"
                    Return 7
                Case "Aug"
                    Return 8
                Case "Sep"
                    Return 9
                Case "Oct"
                    Return 10
                Case "Nov"
                    Return 11
                Case "Dec"
                    Return 12
                Case Else
                    Return 0
            End Select
        End If
    End Function

    Function FillYearlyRows(ByRef tc As TableCell, ByRef tr As TableRow) As TableRow

        Dim tbXsign As New TableCell
        Dim tbYsign As New TableCell
        Dim tbXYsign As New TableCell
        Dim tbXYsignPrevious As New TableCell

        tc.Width = tc.Width.Percentage(41)

        tbXsign.Width = tc.Width.Percentage(13)
        tbYsign.Width = tc.Width.Percentage(13)
        tbXYsignPrevious.Width = tbXYsignPrevious.Width.Percentage(20)
        tbXYsignPrevious.Text = " "
        tbXYsignPrevious.CssClass = "ReportHeadingsYearly"
        tr.Controls.Add(tbXYsignPrevious)

        tbXsign.Text = ""
        tbXsign.CssClass = ""
        tr.Controls.Add(tbXsign)

        tbYsign.Text = ""
        tbYsign.CssClass = ""

        tr.Controls.Add(tbYsign)

        tbXYsign.Text = ""
        tbXYsign.CssClass = ""
        tr.Controls.Add(tbXYsign)

        Return tr

    End Function

    Function FillYearlyRowsBS(ByRef tc As TableCell, ByRef tr As TableRow) As TableRow

        Dim tbXsign As New TableCell
        Dim tbYsign As New TableCell
        Dim tbXYsign As New TableCell
        Dim tbXYsignPrevious As New TableCell

        tc.Width = tc.Width.Percentage(41)

        tbXsign.Width = tc.Width.Percentage(13)
        tbYsign.Width = tc.Width.Percentage(13)
        tbXYsignPrevious.Width = tbXYsignPrevious.Width.Percentage(20)
        tbXYsignPrevious.Text = " "
        tbXYsignPrevious.CssClass = "ReportHeadingsBSYearly"
        tr.Controls.Add(tbXYsignPrevious)

        tbXsign.Text = ""
        tbXsign.CssClass = ""
        tr.Controls.Add(tbXsign)

        tbYsign.Text = ""
        tbYsign.CssClass = ""

        tr.Controls.Add(tbYsign)

        tbXYsign.Text = ""
        tbXYsign.CssClass = ""
        tr.Controls.Add(tbXYsign)

        Return tr

    End Function


End Class