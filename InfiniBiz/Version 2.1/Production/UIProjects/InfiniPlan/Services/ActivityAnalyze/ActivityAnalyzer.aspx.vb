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

Public Class ActivityAnalyzer
    Inherits BizPlanWebBase
    '  Inherits System.Web.UI.Page
    Dim dtDomainInfo As DataTable, dtCustomerIDs As DataTable
    Dim dateStart As String, dateEnd As String, DomainName As String, site_url As String
    Dim _orderCount As Integer, _productCount As Integer, _visitCount As Integer, _referrerCount As Integer, _oppertinutyCount As Integer, _keywordCount As Integer
    Protected WithEvents dgOverView As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgParent As System.Web.UI.WebControls.DataGrid
    Dim _Activity As Infinilogic.BusinessPlan.BLLRules.Activity
    Protected WithEvents lnktable As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCountry As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblHeader1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label

    Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
    Protected WithEvents lblCustom As System.Web.UI.WebControls.Label
    Protected WithEvents imgGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents countrychk As System.Web.UI.HtmlControls.HtmlInputCheckBox
    Protected WithEvents overviewpanel As System.Web.UI.WebControls.Panel
    Dim _caption() As String = {"Products", "Orders", "Visits", "Keywords", "Opportunities", "Referrers"}
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label

    Protected WithEvents ddlHisrotyOption As System.Web.UI.WebControls.DropDownList
    Protected WithEvents BDPLiteFrom As BasicFrame.WebControls.BDPLite
    Protected WithEvents BDPLiteTo As BasicFrame.WebControls.BDPLite
    Protected WithEvents DatePanel As System.Web.UI.WebControls.Panel
    Protected WithEvents myAnalyzerPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Today As System.Web.UI.WebControls.Label
    Protected WithEvents Se_Today As System.Web.UI.WebControls.Label
    Protected WithEvents Lastday As System.Web.UI.WebControls.Label
    Protected WithEvents Se_LastDay As System.Web.UI.WebControls.Label
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents Se_CurrentWeek As System.Web.UI.WebControls.Label
    Protected WithEvents CurrentMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Se_CurrentMonth As System.Web.UI.WebControls.Label
    Protected WithEvents LastMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Se_LastMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Period As System.Web.UI.WebControls.Label
    Protected WithEvents Se_Period As System.Web.UI.WebControls.Label
    Protected WithEvents lbProduct As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbOrders As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbVisits As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbKeywords As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbOpportunity As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbReferrer As System.Web.UI.WebControls.LinkButton
    Dim _baseAnalyzer As New AnalyzerBase

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
        Trace.Warn(" -----------------Page_Load Starts --------------------------- ")
        dtDomainInfo = _Activity.MerchantInformation(GetConnectionData.CustomerID)

        If dtDomainInfo.Rows.Count > 0 Then
            DomainName = dtDomainInfo.Rows(0).Item("domain_name")
            Session("DomainName") = DomainName
        End If
        Try
            'If Session("Analyzedate") Is Nothing Then
            '    BDPLiteFrom.Enabled = False
            '    BDPLiteTo.Enabled = False
            'ElseIf Session("Analyzedate") = 1 Then
            '    BDPLiteFrom.Enabled = True
            '    BDPLiteTo.Enabled = True
            'End If

            Dim IstLoad As String = IIf(viewstate("Analyzer") Is Nothing, 1, viewstate("Analyzer"))

            If IstLoad = 1 Then
                Try
                    ddlHisrotyOption.SelectedIndex = 0
                    ddlHisrotyOption_SelectedIndexChanged(sender, e)
                    viewstate("Analyzer") = IIf(IstLoad = "1", "2", "2")

                Catch ex As Exception
                    Session("Analyzer") = Nothing
                    Trace.Warn("Error in  Session( Analyzer )")
                End Try
            Else
            End If


        Catch ex As Exception

            Dim _Err As String = ex.Message
            Trace.Warn(" ----------------------Page_Load Exception------------------: " & _Err)
        End Try

        Trace.Warn(" --------------------------Page_Load Ends ------------------------")
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

                dtCustomerIDs = _Activity.GetOrderCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                _list.Clear()
                For Each dr In dtCustomerIDs.Rows
                    If Not _list.Contains(dr("CustomerID")) Then
                        _list.Add(dr("CustomerID"))
                        _InorderCount = _InorderCount + _Activity.PostOrderCount(GetConnectionData, CStr(dr("CustomerID")), Session("PeriodStart"), Session("PeriodTo"), DomainName)
                    End If
                Next
                _visitCount = _Activity.GetVisitsCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_visitCount))
                _productCount = _Activity.GetProductCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_productCount))
                _orderCount = _InorderCount
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_orderCount))
                _referrerCount = _Activity.GetReferrerCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_referrerCount))
                _oppertinutyCount = _Activity.GetoppertinutyCount(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
                Trace.Warn("--------------------PopulateBoard ---------------------: " & CStr(_oppertinutyCount))

                Session("product") = _productCount
                Session("order") = _orderCount
                Session("visit") = _visitCount
                Session("kword") = 0
                Session("opper") = _oppertinutyCount
                Session("referrer") = _referrerCount
            End If
            lblDate.Text = "<b>Time From :</b>&nbsp;" & Session("PeriodStart") & "&nbsp;&nbsp;<b>To :</b> &nbsp;" & Session("PeriodTo")

        Catch ex As Exception
            Dim _Err As String = ex.Message
            Trace.Warn("--------------------PopulateBoard Exception---------------------: " & _Err)

        End Try
        RenderLinkButtons()
        Trace.Warn(" ---------------------PopulateBoard Ends -----------------------")
    End Function

    
    Public Sub RenderLinkButtons()
        Trace.Warn(" ---------------------RenderLinkButtons Starts -----------------------")
        Me.lbProduct.Text = " Products" & "(" & _productCount & ")"
        Me.lbOrders.Text = " Orders" & "(" & _orderCount & ")"
        Me.lbVisits.Text = " Visits" & "(" & _visitCount & ")"
        Me.lbKeywords.Text = " Keywords" & "(" & "0" & ")"
        Me.lbOpportunity.Text = " Opportunities" & "(" & _oppertinutyCount & ")"
        Me.lbReferrer.Text = " Referrers" & "(" & _referrerCount & ")"
        Trace.Warn(" ---------------------RenderLinkButtons Ends -----------------------")
    End Sub

    Private Sub ddlHisrotyOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHisrotyOption.SelectedIndexChanged

      
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("Analyzedate") = Nothing

        GetDates()

    End Sub

    Private Sub GetDates()
        Trace.Warn(" ----------------------------GetDates Starts------------------- ")
        Try

            Session("TrackAnalyzer") = True
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
                        Session("PeriodStart") = Date.Now.ToLongDateString
                        BDPLiteFrom.SelectedValue = Session("PeriodStart")
                    Else
                        dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                    End If

                    If BDPLiteTo.SelectedValue Is Nothing Then
                        dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                        Session("PeriodTo") = Date.Now.ToLongDateString
                        BDPLiteTo.SelectedValue = Session("PeriodTo")
                    Else
                        dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                    End If

                Else

                    If (BDPLiteFrom.SelectedValue) Is Nothing Then
                        dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                        Session("PeriodStart") = Date.Now.ToLongDateString
                        BDPLiteFrom.SelectedValue = Session("PeriodStart")
                    Else
                        dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                    End If
                    Dim a As Integer


                    If BDPLiteTo.SelectedValue Is Nothing Then
                        dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                        Session("PeriodTo") = Date.Now.ToLongDateString
                        BDPLiteTo.SelectedValue = Session("PeriodTo")
                    Else
                        dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                    End If

                    Me.ddlHisrotyOption.SelectedIndex = 5

                End If
            End If
            Session("PeriodStart") = dateStart
            Session("PeriodTo") = dateEnd

            Trace.Warn("  GetDates :Session(SessionStart):" & Session("PeriodStart"))
            Trace.Warn("  GetDates :Session(SessionEnd) :" & Session("PeriodTo"))
            PopulateBoard()
        Catch ex As Exception

            Dim _Err As String = ex.Message
            Trace.Warn(" ------------------GetDates Exception-------------------------: <br>" & _Err)
        End Try
        Trace.Warn(" -----------------------GetDates ends -------------------- ")
    End Sub


    Private Sub lbProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbProduct.Click
        GetDates()
     
        lblHeader.Text = _caption(0)

        Dim _ds As DataTable
        If Session("product") = 0 Then
            dgOverView.Visible = False
            _set()
        Else
            Session("stage") = Nothing
            Session("stage") = 1
            _reset()
            RenderOverview(GridStages.Product)
            RenderGridforUI(GridStages.Product, ddlCountry.Items(0).Value)
            overviewpanel.Visible = True
        End If

        lblCountry.Visible = False
        ddlCountry.Visible = False
    End Sub

    Private Sub RenderOverview(ByVal _stage As GridStages)
        Trace.Warn(" -------------------RenderOverview Starts -----------------------")

        Try
            dgOverView.Visible = True
            Dim _ds As DataTable
            If _stage = GridStages.Product Then
                _ds = _baseAnalyzer.RenderDataGridforProductOverview(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
            ElseIf _stage = GridStages.Referrer Then
                _ds = _baseAnalyzer.RenderDataGridforReferrerOverview(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName)
            End If
            dgOverView.DataSource = _ds
            dgOverView.DataBind()

        Catch ex As Exception

            Trace.Warn(" -------------------RenderOverview Exception -----------------------" & ex.Message)


        End Try
        Trace.Warn(" -------------------RenderOverview ends -----------------------")

    End Sub

    Private Sub lbOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbOrders.Click
        GetDates()
        dgOverView.Visible = False
        lblHeader.Text = _caption(1)
        Dim _ds As DataTable
        If Session("order") = 0 Then
            _set()
        Else
            _reset()
            Session("stage") = Nothing
            Session("stage") = 2
            PopulateCountry(GridStages.Order)
            RenderGridforUI(GridStages.Order, ddlCountry.Items(0).Value)
            overviewpanel.Visible = False
        End If

    End Sub

    Private Sub lbVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbVisits.Click
        GetDates()
        dgOverView.Visible = False
        lblHeader.Text = _caption(2)
        Dim _ds As DataTable
        If Session("visit") = 0 Then
            _set()
        Else
            _reset()
            Session("stage") = Nothing
            Session("stage") = 3
            PopulateCountry(GridStages.Visit)
            RenderGridforUI(GridStages.Visit, ddlCountry.Items(0).Value)
            overviewpanel.Visible = False
        End If

    End Sub

    Private Sub lbKeywords_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbKeywords.Click
        GetDates()
        overviewpanel.Visible = False
        dgOverView.Visible = False
        lblHeader.Text = _caption(3)
        Dim _ds As DataTable
        If Session("kword") = 0 Then
            _set()
        Else
            _reset()
            Session("stage") = Nothing
            Session("stage") = 4
            RenderGridforUI(GridStages.Keywords, ddlCountry.Items(0).Value)
            overviewpanel.Visible = False
        End If
    End Sub

    Private Sub lbOpportunity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbOpportunity.Click
        GetDates()
        dgOverView.Visible = False
        lblHeader.Text = _caption(4)


        If Session("opper") = 0 Then
            _set()
        Else
            _reset()
            Session("stage") = Nothing
            Session("stage") = 5
            PopulateCountry(GridStages.Oppertiunity)
            RenderGridforUI(GridStages.Oppertiunity, ddlCountry.Items(0).Value)
            overviewpanel.Visible = False
        End If

    End Sub

    Private Sub lbReferrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbReferrer.Click
        GetDates()

        lblHeader.Text = _caption(5)
        Dim _ds As DataTable
        If Session("referrer") = 0 Then
            dgOverView.Visible = False
            _set()
        Else
            _reset()
            Session("stage") = Nothing
            Session("stage") = 6
            PopulateCountry(GridStages.Referrer)
            RenderOverview(GridStages.Referrer)
            RenderGridforUI(GridStages.Referrer, ddlCountry.Items(0).Value)
            overviewpanel.Visible = True
        End If

    End Sub

    Private Sub PopulateCountry(ByVal _stage As GridStages)

        ddlCountry.Items.Clear()
        Dim _ds As DataSet
        _ds = _Activity.GetCountrylist(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName, _stage)

        ddlCountry.Items.Add(New ListItem("Default", "Default"))

        For Each _dr As DataRow In _ds.Tables(0).Rows
            ddlCountry.Items.Add(New ListItem(_dr(0), _dr(0)))

        Next



    End Sub

    Public Sub RenderGridforUI(ByVal _stage As GridStages, ByVal _country As String)
        Trace.Warn(" -------------------RenderGridforUI Starts -----------------------")

        Dim _dt As DataTable
        Try
            Trace.Warn(GetConnectionData.CustomerID)
            Trace.Warn(Session("PeriodStart"))
            Trace.Warn(Session("PeriodTo"))
            Trace.Warn(DomainName)
            Trace.Warn(_stage)

            _dt = _baseAnalyzer.RenderDataGrid(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName, _stage, _country)
            dgParent.DataSource = _dt
            dgParent.DataBind()
        Catch ex As Exception

            Trace.Warn(" -------------------RenderGridforUI Exception -----------------------|<br>" & ex.Message)

        End Try
        Trace.Warn(" -------------------RenderGridforUI ends -----------------------")

    End Sub

    Public Sub _set()
        lblNo.Visible = True
        lblNo.Text = "No Record"
        lblCountry.Visible = False
        ddlCountry.Visible = False
        dgParent.Visible = False
    End Sub

    Public Sub _reset()

        lblNo.Visible = False
        dgParent.Visible = True
        lblCountry.Visible = False
        lblCountry.Visible = True
        ddlCountry.Visible = True

    End Sub

    Private Sub ddlCountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCountry.SelectedIndexChanged
        Dim _dt As DataTable
        Dim _country As String = ddlCountry.SelectedValue




        '  If _country = "Default" Then
        RenderGridforUI(Session("stage"), _country)
        '  Else
        '_dt = _baseAnalyzer.RenderDataGridOppertunityCountry(GetConnectionData.CustomerID, Session("PeriodStart"), Session("PeriodTo"), DomainName, GridStages.OppertiunityCountry, _country)
        'dgParent.DataSource = _dt
        'dgParent.DataBind()

        ' End If

    End Sub

    Private Sub imgGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgGo.Click

        If (BDPLiteFrom.SelectedValue) Is Nothing Then
            dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
            Session("PeriodStart") = Date.Now.ToLongDateString
            BDPLiteFrom.SelectedValue = Session("PeriodStart")
        Else
            dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
        End If

        If BDPLiteTo.SelectedValue Is Nothing Then
            dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
            Session("PeriodTo") = Date.Now.ToLongDateString
            BDPLiteTo.SelectedValue = Session("PeriodTo")
        Else
            dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
        End If

        Me.ddlHisrotyOption.SelectedIndex = 5

        Session("PeriodStart") = dateStart
        Session("PeriodTo") = dateEnd

        Trace.Warn("  GetDates :Session(SessionStart):" & Session("PeriodStart"))
        Trace.Warn("  GetDates :Session(SessionEnd) :" & Session("PeriodTo"))

        PopulateBoard()

    End Sub


End Class

Public Enum GridStages

    Product = 1
    Order = 2
    Visit = 3
    Keywords = 4
    Oppertiunity = 5
    Referrer = 6


End Enum













