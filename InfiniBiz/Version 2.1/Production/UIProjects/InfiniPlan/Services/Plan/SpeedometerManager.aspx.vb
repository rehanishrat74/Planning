Option Strict Off
Option Explicit On 
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing
Imports System.Text

Public Class SpeedometerManager
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim AnalysisId As String
    Dim planname As String
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents btnNew As System.Web.UI.WebControls.Button
    Protected WithEvents Listmeter As System.Web.UI.WebControls.Table
    Public dsClip As DataSet
    Protected WithEvents mainpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Public businessname As String
    Public updatedClip As String
    Public updatedLargeClip As String
    Public objPlanvb As Plan
    Public month As New Hashtable
    Public RealTimeBit As Boolean
    Public movie As String
    Public movieZoom As String
    Public boolMetername As Boolean
    Dim boolCheck As Boolean
    Public obj As CustomerStatus
    Protected WithEvents meterimg As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Panelnoclip As System.Web.UI.WebControls.Panel
    Protected WithEvents AdvanceMeters As System.Web.UI.WebControls.Table
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMeterName As System.Web.UI.WebControls.Label
    Protected WithEvents lblZoomEntitName As System.Web.UI.WebControls.Label
    Protected WithEvents MeterZoomView As System.Web.UI.WebControls.Table
    Protected WithEvents imgbtnAdv As System.Web.UI.WebControls.Button
    Protected WithEvents PanelZoom As System.Web.UI.WebControls.Panel
    Protected WithEvents editmeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents zoommeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents deletemter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents PanelListing As System.Web.UI.WebControls.Panel
    Protected WithEvents mainpanel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents MerchantMeter As System.Web.UI.WebControls.Table
    Public dsFAvoritesClip As DataSet
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tsHoriz As Microsoft.Web.UI.WebControls.TabStrip

    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Private _dt As BusinessTable
    Public totLibality As Double
    Public totassets As Double
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Public TOLLib_CAp As Double

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
        InitializeComponent()
    End Sub

#End Region
    Dim ObjCustomer As CustomerStatus
    Private bsDV As New DataView
    Dim Objplan As Plan
    Dim dtUserRigths As DataTable

    Public BPObject As InfiniLogic.BusinessPlan.BLL.BusinessPlan
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFocus(testpanel)
        Dim intloop As Integer
        Dim ds As DataSet
        Dim Type As String



        If Not IsNothing(Request.QueryString("Zoomid")) And Not Page.IsPostBack Then
            Type = Request.QueryString("Zoomid")
            EnterPriseZoomMeter(Type)
            mainpanel.Visible = True
            editmeter.Visible = False
        ElseIf Not IsNothing(Request.QueryString("Editid")) And Not Page.IsPostBack Then
            Type = Request.QueryString("Editid")
            EnterPriseEditMeter(Type)
            mainpanel.Visible = True
            editmeter.Visible = False
        Else
            ds = ObjCustomer.GetPlansListforMeters(GetConnectionData)
            BusinessStatus()
            If ds.Tables(0).Rows.Count = 0 Then
                mainpanel.Visible = True
            Else
                mainpanel.Visible = True
                Load_treeView(ds)
            End If
        End If

        If Not Session("merchantProUserID") Is Nothing Then
            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            Dim dr As DataRow
            If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 1 ").Length > 0 Then editmeter.Visible = False
        Else
            editmeter.Visible = False
        End If

        CurPage = 2
        CurItem = 0
    End Sub
    Public Sub EnterPriseZoomMeter(ByVal SelectedRowNumber As String)
        Dim strMeterId As String = SelectedRowNumber
        PanelZoom.Visible = True
        lblZoomEntitName.Visible = True
        MeterZoomView.Visible = True
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        ElseIf strMeterId = "TD" Or strMeterId = "MTD" Or strMeterId = "YTD" Then
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            AdvanceMeters.Visible = True
            BusinessStatusAdvance(strMeterId)
            editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            AdvanceMeters.Visible = True
            Listmeter.Visible = False
            MerchantMeter.Visible = False
        Else
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            Dim ds As DataSet
            Dim plan As String
            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds = obj.GetZoomView(plan, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            If clipslection = "rbIActuals.Checked" Then imgbtnAdv.Visible = False Else imgbtnAdv.Visible = True
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name

            editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            Dim ds1 As DataSet

            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds1 = obj.GetZoomView(plan, strMeterId, GetConnectionData)

            lblZoomEntitName.Text = Name
            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = ZoomEntity
            tr.Cells.Add(td)
            Dim tr_Br As New TableRow
            Dim tc_Br As New TableCell
            tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"

            tr_Br.Attributes.Add("class", "trsettings")
            tr_Br.Cells.Add(tc_Br)
            MeterZoomView.Controls.Add(tr)
            MeterZoomView.Rows.Add(tr_Br)
            Load_treeViewAdvance(strMeterId, "", "")
            AdvanceMeters.Visible = True
            Listmeter.Visible = False
            MerchantMeter.Visible = False
            Session("Load") = 1


        End If
    End Sub

    Private Sub EnterPriseEditMeter(ByVal SelectedRowNumber As String)
      

        Dim strMeterId As String = SelectedRowNumber
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Dim ds As DataSet
            Dim plan As String
            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds = obj.GetZoomView(plan, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            Session("test") = 1
            Response.Redirect("/infiniplan/services/plan/openplan.aspx?pid=" + plan + ",QID=" + strMeterId)

        End If

    End Sub


    Public Function BusinessStatus() As String

        Dim dPreMonth As New Date
        Dim dPreYear As New Date
        Dim row_merchant As TableRow
        Dim cell_day As TableCell
        Dim cell_month As TableCell
        Dim cell_year As TableCell
        row_merchant = New TableRow
        cell_day = New TableCell
        cell_month = New TableCell
        cell_year = New TableCell
        ' row_merchant.Attributes.Add("class", "MerchantMeter")
        row_merchant.Attributes.Add("class", "SmallMeter")
        Dim CurrentdateStart As String = Date.Now.ToLongDateString + " " + "00:00:00.000"
        Dim CurrentdateEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
        Dim PreviousdayStart As String = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
        Dim PreviousdayEnd As String = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.000"

        dPreMonth = Now.AddMonths(-1)
        Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
        Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
        Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
        Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
        Dim PreviousmonthStart As String = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
        Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
        Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
        Dim PreviousmonthEnd1 As String
        PreviousmonthEnd1 = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.000"

        dPreYear = Now.AddYears(-1)
        Dim dFirstPreYear As New Date(dPreYear.Year, 1, 1)
        Dim dFirstCurYear As New Date(Now.Year, 1, 1)
        Dim CurrentYearStart As String = dFirstCurYear.ToLongDateString + " " + "00:00:00.000"
        Dim CurrentYearEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
        Dim PreviousYearStart As String = dFirstPreYear.ToLongDateString + " " + "00:00:00.000"

        'Test
        Dim lastmonth As Date = dFirstPreYear.AddMonths(11)
        Dim lastday As Integer = dFirstPreYear.AddMonths(11).DaysInMonth(dFirstPreYear.Year, dFirstPreYear.Month)
        Dim PreviousYearEnd As New Date(dPreYear.Year, lastmonth.Month, lastday)
        Dim PreviousYearEnd1 As String
        PreviousYearEnd1 = PreviousYearEnd.ToLongDateString + " " + "23:59:59.000"
        'test

        Dim strCurrencyStatus As DataSet = Objplan.GetProfileCurrency(GetConnectionData, "")
        Dim sCurrency As String = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)

        Dim strFlashVarDay As String = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&CurrentdateStart=" & CurrentdateStart _
        & "&CurrentdateEnd=" & CurrentdateEnd _
        & "&PreviousdayStart=" & PreviousdayStart _
        & "&PreviousdayEnd=" & PreviousdayEnd _
            & "&Currency=" & sCurrency _
                    & "&Name=Today"
        '''' Nisar Changing start
        Dim MagnifyToday As String = "<u>" + "<b>Today</b>" + " " + "<a href='SpeedometerManager.aspx?Zoomid=TD'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifyToMonth As String = "<u>" + "<b>This Month</b>" + " " + "<a href='SpeedometerManager.aspx?Zoomid=MTD'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifyToYear As String = "<u>" + "<b>This Year</b>" + " " + "<a href='SpeedometerManager.aspx?Zoomid=YTD'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "


        cell_day.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='MerchantActuallSpeedOMeter' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" + strFlashVarDay + "  '>" _
        & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
          & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarDay + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
        & "</object><br>" + MagnifyToday

        ' & "</object><br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("TD", String) & ">  <u>" + "<b>Today</b>" + " "



        Dim strFlashVarMonth As String = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                  & "&CurrentdateStart=" & CurrentmonthStart _
            & "&CurrentdateEnd=" & CurrentmonthEnd _
            & "&PreviousdayStart=" & PreviousmonthStart _
            & "&PreviousdayEnd=" & PreviousmonthEnd1 _
            & "&Currency=" & sCurrency _
                    & "&Name=This Month"
        '''' Nisar Changing Start

        cell_month.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='MerchantActuallSpeedOMeter' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" + strFlashVarMonth + " '>" _
        & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarMonth + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
        & "</object> <br>" + MagnifyToMonth
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("MTD", String) & ">  <u>" + "<b>This Month</b>" + " "

        Dim strFlashVarYear As String = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
      & "&CurrentdateStart=" & CurrentYearStart _
     & "&CurrentdateEnd=" & CurrentYearEnd _
     & "&PreviousdayStart=" & PreviousYearStart _
     & "&PreviousdayEnd=" & PreviousYearEnd1 _
     & "&Currency=" & sCurrency _
             & "&Name=This Year"
        '''' Nisar Changing Start

        cell_year.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='MerchantActuallSpeedOMeter' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" + strFlashVarYear + " '>" _
        & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
   & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarYear + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
 & "</object><br>" + MagnifyToYear
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("YTD", String) & ">  <u>" + "<b>This Year</b>"
        row_merchant.Cells.Add(cell_year)
        row_merchant.Cells.Add(cell_month)
        row_merchant.Cells.Add(cell_day)

        MerchantMeter.Controls.Add(row_merchant)

    End Function

    Public Function BusinessStatusZoom(ByVal id As String) As String

        Dim dPreMonth As New Date
        Dim dPreYear As New Date

        Dim row_merchant As TableRow
        Dim cell As TableCell

        row_merchant = New TableRow
        cell = New TableCell

        row_merchant.Attributes.Add("class", "MerchantMeter")

        Dim strCurrencyStatus As DataSet = Objplan.GetProfileCurrency(GetConnectionData, "")
        Dim sCurrency As String = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)

        Dim CurrentdateStart As String = Date.Now.ToLongDateString + " " + "00:00:00.000"
        Dim CurrentdateEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
        Dim PreviousdayStart As String = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
        Dim PreviousdayEnd As String = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.000"

        Dim strFlashVarDay As String
        Dim strFlashVarMonth As String
        Dim strFlashVarYear As String

        If id = "TD" Then

            strFlashVarDay = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
              & "&CurrentdateStart=" & CurrentdateStart _
          & "&CurrentdateEnd=" & CurrentdateEnd _
          & "&PreviousdayStart=" & PreviousdayStart _
          & "&PreviousdayEnd=" & PreviousdayEnd _
              & "&Currency=" & sCurrency _
                    & "&Name=Today"
            ''' Nisar Changing Start

            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarDay + "'>" _
            & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
   & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarDay + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
  & "</object><br>"


            '''' Nisar Changing End
            lblZoomEntitName.Text = "Today"
        ElseIf id = "MTD" Then

            dPreMonth = Now.AddMonths(-1)
            Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
            Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
            Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
            Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
            Dim PreviousmonthStart As String = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"

            Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
            Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
            Dim PreviousmonthEnd1 As String
            PreviousmonthEnd1 = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.000"



            '  Dim PreviousmonthEnd As String = dPreMonth.ToLongDateString + " " + "23:59:59.000"
            strFlashVarMonth = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                    & "&CurrentdateStart=" & CurrentmonthStart _
              & "&CurrentdateEnd=" & CurrentmonthEnd _
              & "&PreviousdayStart=" & PreviousmonthStart _
              & "&PreviousdayEnd=" & PreviousmonthEnd1 _
              & "&Currency=" & sCurrency _
                    & "&Name=This Month"



            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarMonth + "'>" _
            & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
            & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarMonth + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object> <br> "



            '''' Nisar Changing End
            lblZoomEntitName.Text = "This Month"
        ElseIf id = "YTD" Then
            dPreYear = Now.AddYears(-1)
            Dim dFirstPreYear As New Date(dPreYear.Year, 1, 1)
            Dim dFirstCurYear As New Date(Now.Year, 1, 1)
            Dim CurrentYearStart As String = dFirstCurYear.ToLongDateString + " " + "00:00:00.000"
            Dim CurrentYearEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
            Dim PreviousYearStart As String = dFirstPreYear.ToLongDateString + " " + "00:00:00.000"
            'Test
            Dim lastmonth As Date = dFirstPreYear.AddMonths(11)
            Dim lastday As Integer = dFirstPreYear.AddMonths(11).DaysInMonth(dFirstPreYear.Year, dFirstPreYear.Month)
            Dim PreviousYearEnd As New Date(dPreYear.Year, lastmonth.Month, lastday)
            Dim PreviousYearEnd1 As String
            PreviousYearEnd1 = PreviousYearEnd.ToLongDateString + " " + "23:59:59.000"
            'test

            '   Dim PreviousYearEnd As String = dPreYear.ToLongDateString + " " + "23:59:59.000"

            strFlashVarYear = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                 & "&CurrentdateStart=" & CurrentYearStart _
                & "&CurrentdateEnd=" & CurrentYearEnd _
                & "&PreviousdayStart=" & PreviousYearStart _
                & "&PreviousdayEnd=" & PreviousYearEnd1 _
                & "&Currency=" & sCurrency _
                    & "&Name=This Year"

            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarYear + "'>" _
            & "<param name='movie' value='/MeterTesting/MerchantActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                       & "<embed src='/MeterTesting/MerchantActuallSpeedOMeter.swf?" + strFlashVarYear + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                & "</object><br> "


            '''' Nisar Changing End
            lblZoomEntitName.Text = "This Year"
        End If
        row_merchant.Cells.Add(cell)
        lblZoomEntitName.Visible = True

        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterMerchant.jpg'  visible= true runat='server'>"
        tr_Br.Attributes.Add("class", "MerchantMeter")
        tr_Br.Cells.Add(tc_Br)
        MeterZoomView.Controls.Add(row_merchant)
        MeterZoomView.Controls.Add(tr_Br)
        Session("strMeterId") = id
    End Function

    Public Function BusinessStatusAdvance(ByVal id As String) As String
        ' Test 

        'Test

        Dim dPreMonth As New Date
        Dim dPreYear As New Date

        Dim row_merchant As TableRow
        Dim cell As TableCell
        Dim cellBar As TableCell
        row_merchant = New TableRow
        cell = New TableCell
        cellBar = New TableCell
        row_merchant.Attributes.Add("class", "MerchantMeter")

        Dim strCurrencyStatus As DataSet = Objplan.GetProfileCurrency(GetConnectionData, "")
        Dim sCurrency As String = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)

        Dim CurrentdateStart As String = Date.Now.ToLongDateString + " " + "00:00:00.000"
        Dim CurrentdateEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
        Dim PreviousdayStart As String = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
        Dim PreviousdayEnd As String = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.000"

        Dim strFlashVarDay As String
        Dim strFlashVarMonth As String
        Dim strFlashVarYear As String

        If id = "TD" Then

            strFlashVarDay = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
              & "&CurrentdateStart=" & CurrentdateStart _
          & "&CurrentdateEnd=" & CurrentdateEnd _
          & "&PreviousdayStart=" & PreviousdayStart _
          & "&PreviousdayEnd=" & PreviousdayEnd _
              & "&Currency=" & sCurrency _
                    & "&Name=ToDay"


            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarDay + "  '>" _
            & "<param name='movie' value='/MeterTesting/MerchantDeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                   & "<embed src='/MeterTesting/MerchantDeviationScale.swf?" + strFlashVarDay + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object><br>"

            cellBar.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='150' height='260' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarDay + "  '>" _
            & "<param name='movie' value='/MeterTesting/MerchantTwoBarGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                   & "<embed src='/MeterTesting/MerchantTwoBarGraph.swf?" + strFlashVarDay + "' quality='high' width='150' height='260' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object><br>"


        ElseIf id = "MTD" Then

            dPreMonth = Now.AddMonths(-1)
            Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
            Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
            Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
            Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
            Dim PreviousmonthStart As String = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"

            Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
            Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
            Dim PreviousmonthEnd1 As String

            PreviousmonthEnd1 = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.000"
            strFlashVarMonth = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                    & "&CurrentdateStart=" & CurrentmonthStart _
              & "&CurrentdateEnd=" & CurrentmonthEnd _
              & "&PreviousdayStart=" & PreviousmonthStart _
              & "&PreviousdayEnd=" & PreviousmonthEnd1 _
              & "&Currency=" & sCurrency _
                    & "&Name=This Month"

            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarMonth + " '>" _
            & "<param name='movie' value='/MeterTesting/MerchantDeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
              & "<embed src='/MeterTesting/MerchantDeviationScale.swf?" + strFlashVarMonth + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object> <br> "

            cellBar.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='150' height='260' id='MerchantActuallSpeedOMeter' align='middle'>" _
           & "<param name='allowScriptAccess' value='sameDomain' /> " _
             & "<PARAM NAME=FlashVars VALUE='" + strFlashVarMonth + " '>" _
           & "<param name='movie' value='/MeterTesting/MerchantTwoBarGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                & "<embed src='/MeterTesting/MerchantTwoBarGraph.swf?" + strFlashVarMonth + "' quality='high' width='150' height='260' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                & "</object> <br> "

        ElseIf id = "YTD" Then
            dPreYear = Now.AddYears(-1)
            Dim dFirstPreYear As New Date(dPreYear.Year, 1, 1)
            Dim dFirstCurYear As New Date(Now.Year, 1, 1)
            Dim CurrentYearStart As String = dFirstCurYear.ToLongDateString + " " + "00:00:00.000"
            Dim CurrentYearEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"

            Dim lastmonth As Date = dFirstPreYear.AddMonths(11)
            Dim lastday As Integer = dFirstPreYear.AddMonths(11).DaysInMonth(dFirstPreYear.Year, dFirstPreYear.Month)

            Dim PreviousYearStart As String = dFirstPreYear.ToLongDateString + " " + "00:00:00.000"
            Dim PreviousYearEnd As New Date(dPreYear.Year, lastmonth.Month, lastday)

            Dim PreviousYearEnd1 As String
            PreviousYearEnd1 = PreviousYearEnd.ToLongDateString + " " + "23:59:59.000"


            strFlashVarYear = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                 & "&CurrentdateStart=" & CurrentYearStart _
                & "&CurrentdateEnd=" & CurrentYearEnd _
                & "&PreviousdayStart=" & PreviousYearStart _
                & "&PreviousdayEnd=" & PreviousYearEnd1 _
                & "&Currency=" & sCurrency _
                    & "&Name=This Year"

            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MerchantActuallSpeedOMeter' align='middle'>" _
            & "<param name='allowScriptAccess' value='sameDomain' /> " _
              & "<PARAM NAME=FlashVars VALUE='" + strFlashVarYear + " '>" _
            & "<param name='movie' value='/MeterTesting/MerchantDeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                         & "<embed src='/MeterTesting/MerchantDeviationScale.swf?" + strFlashVarYear + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object><br> "

            cellBar.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='150' height='260' id='MerchantActuallSpeedOMeter' align='middle'>" _
                       & "<param name='allowScriptAccess' value='sameDomain' /> " _
                         & "<PARAM NAME=FlashVars VALUE='" + strFlashVarYear + " '>" _
                       & "<param name='movie' value='/MeterTesting/MerchantTwoBarGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                            & "<embed src='/MeterTesting/MerchantTwoBarGraph.swf?" + strFlashVarYear + "' quality='high' width='150' height='260' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
             & "</object><br> "


        End If
        row_merchant.Cells.Add(cell)
        row_merchant.Cells.Add(cellBar)
        AdvanceMeters.Controls.Add(row_merchant)
        Session("strMeterId") = Nothing
        Session("strMeterId") = id
        BusinessStatusZoom(id)
    End Function

    Public Sub Load_treeView(ByVal ds As DataSet)
        Dim mylabel As System.Web.UI.WebControls.TextBox
        mylabel = New System.Web.UI.WebControls.TextBox
        lblMsg.CssClass = "trsettings1"
        lblMsg.Visible = True
        lblMsg.Text = "This is a list of all the <b> Speedometers</b>  from all the plans.  "
        Dim xx As HtmlControls.HtmlTextArea
        Dim A_id As String
        Dim MeterName As String


        Dim _row As TableRow
        Dim _rowIcons As TableRow
        Dim _column As TableCell
        Dim _columnIcons As TableCell
        Dim inloopChk, outloopChk, counter, countVal, iloc, maxCount, rowDiff, interRowVal As Integer
        Dim totalRows As Integer = ds.Tables(0).Rows.Count
        Dim trRowscount As Integer = CInt(Math.Ceiling(totalRows / 5))

        For outloopChk = 1 To trRowscount
            _row = New TableRow
            _rowIcons = New TableRow
            _row.Attributes.Add("class", "SmallMeter")
            _rowIcons.Attributes.Add("class", "SmallMeter")

            counter = 4
            maxCount = counter + iloc
            rowDiff = totalRows - maxCount
            If (rowDiff <= 0) Then
                interRowVal = (totalRows - inloopChk)
                interRowVal = interRowVal - 1 + inloopChk
            Else
                interRowVal = maxCount
            End If
            maxCount = interRowVal
            For inloopChk = countVal To maxCount
                _column = New TableCell
                _columnIcons = New TableCell
                movie = CType(ds.Tables(0).Rows(inloopChk).Item(3), String)
                A_id = CType(ds.Tables(0).Rows(inloopChk).Item(0), String)
                MeterName = CType(ds.Tables(0).Rows(inloopChk).Item(2), String)
                planname = obj.PopulateMeterTreeManager(CType(ds.Tables(0).Rows(inloopChk).Item(1), String), GetConnectionData)
                'Realtime Work 

                RealTimeBit = CType(ds.Tables(0).Rows(inloopChk).Item(5), String)
                If RealTimeBit = True Then
                    Dim largeMeter As String = CType(ds.Tables(0).Rows(inloopChk).Item(4), String)
                    Dim ToDay As String = movie.Substring(movie.IndexOf("ProEndDate=") + 11, (movie.IndexOf("PlanStartDate=") - 12) - movie.IndexOf("ProEndDate="))
                    Dim ToDayLarge As String = largeMeter.Substring(largeMeter.IndexOf("ProEndDate=") + 11, (largeMeter.IndexOf("PlanStartDate=") - 12) - largeMeter.IndexOf("ProEndDate="))
                    updatedClip = movie.Replace(ToDay, Date.Now.ToLongDateString)
                    updatedLargeClip = largeMeter.Replace(ToDayLarge, Date.Now.ToLongDateString)
                    If (ToDay <> Date.Now.ToLongDateString) Then
                        movie = obj.updateRealTimeDate(A_id, updatedClip, updatedLargeClip, GetConnectionData)
                    Else
                        movie = movie
                    End If
                Else

                End If

                Dim _sbMovie As New StringBuilder
                Dim _sbOptions As New StringBuilder
                _sbMovie.Append(movie)
                _column.Text = _sbMovie.ToString



                _sbOptions.Append("<a href='SpeedometerManager.aspx?Editid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/editmetersmall.jpg' style='border-style: none'  runat=server ID='edit' alt='Edit'></a>   ")
                _sbOptions.Append("<a href='SpeedometerManager.aspx?Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a><br>   ")

                '   st1.Append("<a href='Speedometer.aspx?AnalysisID=1&Deleteid=" & CType(A_id, String) & "&isDeleted=' runat=server onclick=javascript:SetdeleteMeter('" & A_id.Trim & "');><img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete'></a><br>")
                '   st1.Append("<a href='#'   runat=server onclick=javascript:SetdeleteMeter('" & A_id.Trim & "');><img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete'></a><br>")

                _sbOptions.Append("<u> " + MeterName + "</u>   " + " (" + planname + ")")
                _sbOptions.Append("<br>")
                _columnIcons.Text = _sbOptions.ToString

                _row.Cells.Add(_column)
                _rowIcons.Cells.Add(_columnIcons)

                '   _column.Text = movie + "<input type=radio name='myradiogroup' onclick='SetRbValue1(this.value,1)' value=" & CType(A_id, String) & "> <u> " + MeterName + "</u>   " + " (" + planname + ")"

                _row.Cells.Add(_column)
            Next
            Listmeter.Controls.Add(_row)
            Listmeter.Controls.Add(_rowIcons)
            iloc = counter + iloc + 1
            countVal = iloc
        Next
        Listmeter.Controls.Add(_row)
        Listmeter.Controls.Add(_rowIcons)
        Session("test") = 1
    End Sub

    Public Function setMeterName(ByVal name, ByVal plan) As String
        Dim b As String
        Dim e As String
        Dim d As String
        Dim a As String = name  ' + "   " + " (" + plan + ")"
        Dim c As String = plan
        'If (c.Length > 12) Then
        '    e = c.Substring(0, 11)

        'End If
        If (a.Length > 12) Then


            d = a.Substring(0, 11)
            d = d.Trim(" ")
            b = d + "... <br>"

        Else
            Dim test As New Label

            b = a
        End If
        Return b


    End Function

    Private Sub SetFocus(ByVal FocusControl As Control)
        Dim Script As New System.Text.StringBuilder
        Dim ClientID As String = FocusControl.ClientID
        With Script
            .Append("<script language='javascript'>")
            .Append("document.getElementById('")
            .Append(ClientID)
            .Append("').focus();")
            .Append("</script>")
        End With
        RegisterStartupScript("setFocus", Script.ToString())
    End Sub

    Private Sub InitiliazeLanguage()
        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkSpeedometermanager")

    End Sub

    Private Sub editmeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles editmeter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Dim ds As DataSet
            Dim plan As String
            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds = obj.GetZoomView(plan, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            Session("test") = 1
            Response.Redirect("/infiniplan/services/plan/openplan.aspx?pid=" + plan + ",QID=" + strMeterId)

        End If

    End Sub

    Private Sub zoommeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles zoommeter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")

        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        ElseIf strMeterId = "TD" Or strMeterId = "MTD" Or strMeterId = "YTD" Then
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            ' BusinessStatusZoom(strMeterId)
            '  imgbtnAdv.Visible = True
            AdvanceMeters.Visible = True
            imgbtnAdv_Click(sender, e)
        Else
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            Dim ds As DataSet
            Dim plan As String
            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds = obj.GetZoomView(plan, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            If clipslection = "rbIActuals.Checked" Then imgbtnAdv.Visible = False Else imgbtnAdv.Visible = True
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            'Dim tr As New TableRow
            'Dim td As New TableCell
            'td.Text = ZoomEntity
            'tr.Cells.Add(td)
            'Dim tr_Br As New TableRow
            'Dim tc_Br As New TableCell
            'tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"
            'tr_Br.Attributes.Add("class", "trsettings")
            'tr_Br.Cells.Add(tc_Br)
            'MeterZoomView.Controls.Add(tr)
            'MeterZoomView.Rows.Add(tr_Br)
            imgbtnAdv_Click(sender, e)
        End If
    End Sub

    Private Sub imgbtnAdv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbtnAdv.Click

        Dim strMeterId As String = Session("strMeterId")
        If strMeterId = "" Then
            Exit Sub
        ElseIf strMeterId = "TD" Or strMeterId = "MTD" Or strMeterId = "YTD" Then
            BusinessStatusAdvance(strMeterId)
            editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            AdvanceMeters.Visible = True
            Listmeter.Visible = False
            MerchantMeter.Visible = False
        Else

            editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            Dim ds1 As DataSet
            Dim plan As String
            plan = obj.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds1 = obj.GetZoomView(plan, strMeterId, GetConnectionData)

            Dim ds As DataSet = obj.GetZoomView(plan, strMeterId, GetConnectionData)
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = ZoomEntity
            tr.Cells.Add(td)
            Dim tr_Br As New TableRow
            Dim tc_Br As New TableCell
            tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"

            tr_Br.Attributes.Add("class", "trsettings")
            tr_Br.Cells.Add(tc_Br)
            MeterZoomView.Controls.Add(tr)
            MeterZoomView.Rows.Add(tr_Br)
            Load_treeViewAdvance(strMeterId, "", "")
            AdvanceMeters.Visible = True
            Listmeter.Visible = False
            MerchantMeter.Visible = False
            Session("Load") = 1

        End If

    End Sub

    Private Sub imgbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgbtnBack.Click



        'editmeter.Visible = false
        If Not Session("merchantProUserID") Is Nothing Then

            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            Dim dr As DataRow
            If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 1 ").Length > 0 Then editmeter.Visible = False
        Else
            editmeter.Visible = False
        End If
        zoommeter.Visible = True
        imgbtnAdv.Visible = False
        imgbtnBack.Visible = False

        AdvanceMeters.Visible = False
        Listmeter.Visible = True
        MerchantMeter.Visible = True

        PanelZoom.Visible = False
        lblZoomEntitName.Visible = False
        MeterZoomView.Visible = False


    End Sub

    Public Sub Load_treeViewAdvance(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)
        Dim ds1 As DataSet
        Dim plan As String
        plan = obj.GetPlanidZoomView(Meterid, GetConnectionData)

        Dim ds As DataSet = obj.GetZoomView(plan, Meterid, GetConnectionData)
        Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
        'Dim Barmeter As String = ZoomEntity.Replace("ActuallSpeedOMeter.swf", "2barGraph.swf")
        Dim Barmeter As String = ZoomEntity.Replace("/ActuallSpeedOMeter", "/2barGraph")
        ' Barmeter = Barmeter.Replace("ActuallSpeedOMeter.swf", "2barGraph.swf")
        Barmeter = Barmeter.Replace("width='200'", "width='150'")
        Barmeter = Barmeter.Replace("height='220'", "height='260'")
        Barmeter = Barmeter.Replace("width='200'", "'width='150'")
        Barmeter = Barmeter.Replace("height='220'", "height='260'")
        Dim _row As TableRow
        Dim _barcolumn As TableCell
        Dim _devcolumn As TableCell
        Dim _space As TableCell
        _row = New TableRow
        _devcolumn = New TableCell
        _barcolumn = New TableCell
        _space = New TableCell
        _barcolumn.Text = Barmeter
        _space.Text = "&nbsp"
        'Dim devMeter As String = ZoomEntity.Replace("ActuallSpeedOMeter.swf", "DeviationScale.swf")
        Dim devMeter As String = ZoomEntity.Replace("ActuallSpeedOMeter.swf", "DeviationScale.swf")
        '  devMeter = devMeter.Replace("/ActuallSpeedOMeter", "/DeviationScale")
        devMeter = devMeter.Replace("width='200'", "width='325'")
        devMeter = devMeter.Replace("width='200'", "width='325'")


        _devcolumn.Text = devMeter
        _row.Cells.Add(_devcolumn)
        _row.Cells.Add(_space)
        _row.Cells.Add(_barcolumn)
        AdvanceMeters.Controls.Add(_row)

    End Sub



End Class
