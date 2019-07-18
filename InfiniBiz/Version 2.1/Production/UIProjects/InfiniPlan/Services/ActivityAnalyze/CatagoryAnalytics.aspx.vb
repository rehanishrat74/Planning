
Option Explicit On 
Option Strict Off

Imports System.IO
Imports System.Text

Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules



Imports System.Web.UI.WebControls
Public Class CatagoryAnalytics
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page
    Dim dateStart As String, dateEnd As String, DomainName As String, site_url As String
    Dim _Activity As Infinilogic.BusinessPlan.BLLRules.Activity
    Dim dtDomainInfo As DataTable
    Dim _orderCount As Integer, _productCount As Integer = 0, _visitCount As Integer, _referrerCount As Integer, _oppertinutyCount As Integer, _keywordCount As Integer
    Protected WithEvents abc As System.Web.UI.HtmlControls.HtmlInputImage
    Protected WithEvents dgCatagory As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
    Protected WithEvents ddlHisrotyOption As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCustom As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLiteFrom As BasicFrame.WebControls.BDPLite
    Protected WithEvents BDPLiteTo As BasicFrame.WebControls.BDPLite
    Protected WithEvents imgGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents DatePanel As System.Web.UI.WebControls.Panel

    Protected WithEvents lbOrders As System.Web.UI.WebControls.LinkButton

    Protected WithEvents lbKeywords As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbOpportunity As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbReferrer As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCountry As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dgOverView As System.Web.UI.WebControls.DataGrid
    Protected WithEvents overviewpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblNo As System.Web.UI.WebControls.Label
    Protected WithEvents dgParent As System.Web.UI.WebControls.DataGrid
    Protected WithEvents myAnalyzerPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents countrychk As System.Web.UI.HtmlControls.HtmlInputCheckBox
    Protected WithEvents lnktable As System.Web.UI.HtmlControls.HtmlTable

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        Trace.Warn(" -----------------CatagoryAnalytics Page_Load Starts --------------------------- ")
        dtDomainInfo = _Activity.MerchantInformation(GetConnectionData.CustomerID)
        If dtDomainInfo.Rows.Count > 0 Then
            DomainName = dtDomainInfo.Rows(0).Item("domain_name")
            Session("DomainNameCat") = DomainName
        End If
        Dim IstLoadCat As String = IIf(viewstate("AnalyzerCat") Is Nothing, 1, viewstate("AnalyzerCat"))

        If IstLoadCat = 1 Then
            Try
                ddlHisrotyOption.SelectedIndex = 0
                ddlHisrotyOption_SelectedIndexChanged(sender, e)
                viewstate("AnalyzerCat") = IIf(IstLoadCat = "1", "2", "2")

            Catch ex As Exception

                Trace.Warn("Error in  Session( Analyzer )")
            End Try
        Else
        End If
        Trace.Warn(Session("PeriodStartCat"))
        Trace.Warn(Session("PeriodToCat"))
        'GetDates()
        Trace.Warn(" -----------------CatagoryAnalytics Page_Load Starts --------------------------- ")
    End Sub
   
    Public Function PopulateBoard()
        Trace.Warn(" -------------------PopulateBoard Starts -----------------------")
        Try
            Dim counter As Integer = 0, _InorderCount As Integer = 0
            Dim dr As DataRow
            If dtDomainInfo.Rows.Count > 0 Then
                Dim _list As New ArrayList
                site_url = "http://" + DomainName
                System.Web.HttpContext.Current.Trace.Warn("site_url" + site_url)
                System.Web.HttpContext.Current.Trace.Warn("Menu Xml Starts")
                _visitCount = _Activity.GetVisitsCount(GetConnectionData.CustomerID, Session("PeriodStartCat"), Session("PeriodToCat"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_visitCount))

                '  _productCount = _Activity.GetProductCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_productCount))

                Session("visitcat") = _visitCount
                Session("productcat") = _productCount
                If Session("visitcat") = 0 Then
                    _set()
                Else
                           _reset()
                    RenderGridforUI(1, "")
                End If
            End If
       
        Catch ex As Exception
            Dim _Err As String = ex.Message
            Trace.Warn("--------------------PopulateBoard Exception---------------------: " & _Err)
        End Try
        Trace.Warn(" ---------------------PopulateBoard Ends -----------------------")
    End Function

    Public Sub _set()
        lblNo.Visible = True
        lblNo.Text = "No Record"

        dgCatagory.Visible = False

    End Sub

    Public Sub _reset()

        lblNo.Visible = False
        Me.dgCatagory.Visible = True
       

    End Sub

    Private Sub ddlHisrotyOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHisrotyOption.SelectedIndexChanged

        BDPLiteFrom.SelectedValue = ""
        BDPLiteTo.SelectedValue = ""
        Session("AnalyzedateCat") = Nothing
        GetDates()

    End Sub


    Private Sub imgGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGo.Click
        Trace.Warn("CatagoryAnalytics btn Go starts ")

        If (BDPLiteFrom.SelectedValue) Is Nothing Then
            dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
            Session("PeriodStartCat") = Date.Now.ToLongDateString
            BDPLiteFrom.SelectedValue = Session("PeriodStartCat")
        Else
            dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
        End If

        If BDPLiteTo.SelectedValue Is Nothing Then
            dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
            Session("PeriodToCat") = Date.Now.ToLongDateString
            BDPLiteTo.SelectedValue = Session("PeriodToCat")
        Else
            dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
        End If

        Me.ddlHisrotyOption.SelectedIndex = 5

        Session("PeriodStartCat") = dateStart
        Session("PeriodToCat") = dateEnd

        Trace.Warn("  GetDates :Session(SessionStartCat):" & Session("PeriodStartCat"))
        Trace.Warn("  GetDates :Session(SessionEndCat) :" & Session("PeriodToCat"))

        Trace.Warn("CatagoryAnalytics btn Go ends ")
        GetDates()
    End Sub

    Private Sub GetDates()
        Trace.Warn(" ----------------------------GetDates Starts------------------- ")
        Try

            Session("TrackAnalyzerCat") = True
            Dim dPreMonth As New Date
            Dim dsdomain As DataSet
            dsdomain = _Activity.AnalyzeCurrentSessions(GetConnectionData, DomainName)
            If Not dsdomain Is Nothing And dsdomain.Tables.Count = 1 Then
                If ddlHisrotyOption.SelectedIndex = 0 Then
                    dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                ElseIf ddlHisrotyOption.SelectedIndex = 1 Then
                    dateStart = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
                    dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
                ElseIf ddlHisrotyOption.SelectedIndex = 2 Then
                    Dim week As New TimeSpan(6, 23, 59, 59)
                    dateStart = Date.Today.Subtract(week).ToLongDateString + " " + "00:00:00.000"
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                ElseIf ddlHisrotyOption.SelectedIndex = 3 Then
                    dPreMonth = Now.AddMonths(-1)
                    Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                    Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                    Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                    Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                    dateStart = CurrentmonthStart
                    dateEnd = CurrentmonthEnd
                ElseIf ddlHisrotyOption.SelectedIndex = 4 Then
                    dPreMonth = Now.AddMonths(-1)
                    Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                    Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                    Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                    Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                    dateStart = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
                    Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
                    Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
                    dateEnd = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.999"
                ElseIf ddlHisrotyOption.SelectedIndex = 5 Then

                    If (BDPLiteFrom.SelectedValue) Is Nothing Then
                        dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                        Session("PeriodStartCat") = Date.Now.ToLongDateString
                        BDPLiteFrom.SelectedValue = Session("PeriodStartCat")
                    Else
                        dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                    End If

                    If BDPLiteTo.SelectedValue Is Nothing Then
                        dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                        Session("PeriodToCat") = Date.Now.ToLongDateString
                        BDPLiteTo.SelectedValue = Session("PeriodToCat")
                    Else
                        dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                    End If

                Else

                    If (BDPLiteFrom.SelectedValue) Is Nothing Then
                        dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                        Session("PeriodStartCat") = Date.Now.ToLongDateString
                        BDPLiteFrom.SelectedValue = Session("PeriodStartCat")
                    Else
                        dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                    End If
                    Dim a As Integer


                    If BDPLiteTo.SelectedValue Is Nothing Then
                        dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                        Session("PeriodToCat") = Date.Now.ToLongDateString
                        BDPLiteTo.SelectedValue = Session("PeriodToCat")
                    Else
                        dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                    End If

                    Me.ddlHisrotyOption.SelectedIndex = 5

                End If
            End If
            Session("PeriodStartCat") = dateStart
            Session("PeriodToCat") = dateEnd

            Trace.Warn("  GetDates :Session(SessionStartCat):" & Session("PeriodStartCat"))
            Trace.Warn("  GetDates :Session(SessionEndCat) :" & Session("PeriodToCat"))

            lblDate.Text = "<b>Time From :</b>&nbsp;" & Session("PeriodStartCat") & "&nbsp;&nbsp;<b>To :</b> &nbsp;" & Session("PeriodToCat")
            PopulateBoard()
        Catch ex As Exception

            Dim _Err As String = ex.Message
            Trace.Warn(" ------------------GetDates Exception-------------------------: <br>" & _Err)
        End Try
        Trace.Warn(" -----------------------GetDates ends -------------------- ")
    End Sub
    Dim _baseAnalyzer As New AnalyzerBase
    Public Sub RenderGridforUI(ByVal _stage As GridStages, ByVal _country As String)
        Trace.Warn(" -------------------RenderGridforUI Starts -----------------------")

        Dim _dt As DataTable
        Try
            Trace.Warn(GetConnectionData.CustomerID)
            Trace.Warn(Session("PeriodStartCat"))
            Trace.Warn(Session("PeriodToCat"))
            Trace.Warn(DomainName)
            Trace.Warn(_stage)

            _dt = _baseAnalyzer.RenderDataGridforProductCatagory(GetConnectionData.CustomerID, Session("PeriodStartCat"), Session("PeriodToCat"), DomainName)
            dgCatagory.DataSource = _dt
            dgCatagory.DataBind()
        Catch ex As Exception

            Trace.Warn(" -------------------RenderGridforUI Exception -----------------------|<br>" & ex.Message)

        End Try
        Trace.Warn(" -------------------RenderGridforUI ends -----------------------")

    End Sub

End Class
