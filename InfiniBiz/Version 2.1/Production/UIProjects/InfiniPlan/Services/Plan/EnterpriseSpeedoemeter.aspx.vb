
Option Strict Off
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO

Public Class EnterpriseSpeedoemeter

    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page
    Dim dtUserRigths As DataTable

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents EnterpriseMeter As System.Web.UI.WebControls.Table
    Protected WithEvents EnterprisePanel As System.Web.UI.WebControls.Panel
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblZoomEntity As System.Web.UI.WebControls.Label
    Protected WithEvents test As System.Web.UI.WebControls.Table
    Protected WithEvents btnAdv As System.Web.UI.WebControls.Button
    Protected WithEvents PanelEnterpriseZoom As System.Web.UI.WebControls.Panel
    Protected WithEvents Enterprisezoommeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents EnterpriseimgbtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents ZoomEnteriprseMeter As System.Web.UI.WebControls.Table
    Protected WithEvents EnterpriseAdvanceMeters As System.Web.UI.WebControls.Table
    Protected WithEvents lblPeriod As System.Web.UI.WebControls.Label
    Protected WithEvents DropDownList1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents DrpSelectTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTimePeriod As System.Web.UI.WebControls.Label
    Protected WithEvents StaticEnterprise As System.Web.UI.WebControls.Table

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        ' InitiliazeLanguage()
    End Sub

    Private Sub InitiliazeLanguage()



    End Sub


#End Region
    Dim strFlashVar As String
    Dim stryear, strLastYear, strBiannual, strLastBiannual, strQuarter, strLastQuarter As String
    Dim strFrom, strTo, strLastFrom, strLastTo As String
    Dim dtTody As New Date
    Dim dtPre As New Date
    Dim dtBiYear As New Date
    Dim dtQYear As New Date
    Dim StartDate As String
    Dim EndDate As String
    Dim Objplan As Plan
    Dim StartLastDate As String
    Dim EndLastDate As String
    Dim sCurrency As String
    Dim CompanyID As Integer
    Dim objBS As BalancesheetReport
    Private bsDV As New DataView
    Dim ObjCustomer As CustomerStatus

    Dim planname As String
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

    Public businessnameSystem As String
    Public updatedClipSystem As String
    Public updatedLargeClipSystem As String
    Public objPlanvbSystem As Plan
    Public monthSystem As New Hashtable
    Public RealTimeBitSystem As Boolean
    Public movieSystem As String
    Public movieZoomSystem As String
    Public boolMeternameSystem As Boolean
    Dim boolCheckSystem As Boolean
    Dim plannameSystem As String
    Dim strCurrencyStatus As DataSet
    Dim dsIO As DataSet
    Dim dssystem As DataSet
    Dim Type As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        dsIO = ObjCustomer.GetPlansListforMeters_Enterprise(GetConnectionData)
        CompanyID = ObjCustomer.GetSystemMeters(GetConnectionData)
        SetFocus(testpanel)
        SetDateandCurrency()
 
        If Not IsNothing(Request.QueryString("Zoomid")) And Not Page.IsPostBack Then
            Type = Request.QueryString("Zoomid")
            ZoomMeters(Type)

        Else
            LoadEnterpriseMeters()
            If CompanyID = 0 Then
                dssystem = Nothing
            Else
                dssystem = ObjCustomer.GetPlansListforMeters_EnterPriseSystem(CompanyID)
                If dssystem.Tables(0).Rows.Count = 0 Then dssystem = Nothing
            End If

            If (dsIO.Tables(0).Rows.Count <> 0) Then
                Load_treeView(dsIO, dssystem)
            End If

        End If



        'If (dsIO.Tables(0).Rows.Count = 0 And dssystem Is Nothing) Then

        'Else
        '    If (dsIO.Tables(0).Rows.Count <> 0) Then
        '        Load_treeView(dsIO, dssystem)
        '    Else

        '    End If
        'End If
 
    End Sub

    Private Sub ZoomMeters(ByVal Type As String)
        PanelEnterpriseZoom.Visible = True
        lblZoomEntity.Visible = True
        ZoomEnteriprseMeter.Visible = True
        Session("Advance") = 1
        Dim strMeterId As String = Type 'Request.Form.Item("MeterOption")
        Dim strSystemId As String = Request.Form.Item("Midentity")
        If strMeterId = "" Then
            lblZoomEntity.Text = "+"
            btnAdv.Visible = False
            Exit Sub
        ElseIf strMeterId = "P" Or strMeterId = "S" Or strMeterId = "O" Or strMeterId = "C" Or strMeterId = "ROI" Then
            Session("strMeterId") = strMeterId
            lblZoomEntity.Visible = True
            EnterpriseStatusAdvance(strMeterId)
            Enterprisezoommeter.Visible = False
            btnAdv.Visible = False
            EnterpriseimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdv.Visible = False
            EnterpriseAdvanceMeters.Visible = True
            EnterpriseMeter.Visible = False
            StaticEnterprise.Visible = False

        Else
            Session("strMeterId") = strMeterId
            Session("strSystemId") = Request.QueryString("id")
            lblZoomEntity.Visible = True
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
            EnterpriseStatusAdvance_Enterprise(strMeterId)
            Enterprisezoommeter.Visible = False
            btnAdv.Visible = False
            EnterpriseimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdv.Visible = False
            EnterpriseAdvanceMeters.Visible = True
            EnterpriseMeter.Visible = False
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
        End If
    End Sub

    Public Sub Load_treeView(ByVal ds As DataSet, ByVal dssystem As DataSet)

        Try
            StaticEnterprise.Visible = True
            EnterpriseMeter.Visible = True
            Dim mylabel As System.Web.UI.WebControls.TextBox
            mylabel = New System.Web.UI.WebControls.TextBox
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim A_id As String
                Dim MeterName As String
                Dim _row As TableRow
                Dim _column As TableCell
                Dim inloopChk, outloopChk, counter, countVal, iloc, maxCount, rowDiff, interRowVal As Integer
                Dim totalRows As Integer = ds.Tables(0).Rows.Count
                Dim trRowscount As Integer = CInt(Math.Ceiling(totalRows / 5))

                For outloopChk = 1 To trRowscount
                    _row = New TableRow
                    _row.Attributes.Add("class", "SmallMeter")

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
                        movie = CType(ds.Tables(0).Rows(inloopChk).Item(3), String)
                        A_id = CType(ds.Tables(0).Rows(inloopChk).Item(0), String)
                        MeterName = CType(ds.Tables(0).Rows(inloopChk).Item(2), String)
                        planname = ObjCustomer.PopulateMeterTreeManager(CType(ds.Tables(0).Rows(inloopChk).Item(1), String), GetConnectionData)
                        'Realtime Work 

                        RealTimeBit = CType(ds.Tables(0).Rows(inloopChk).Item(5), String)
                        If RealTimeBit = True Then
                            Dim largeMeter As String = CType(ds.Tables(0).Rows(inloopChk).Item(4), String)
                            Dim ToDay As String = movie.Substring(movie.IndexOf("ProEndDate=") + 11, (movie.IndexOf("PlanStartDate=") - 12) - movie.IndexOf("ProEndDate="))
                            Dim ToDayLarge As String = largeMeter.Substring(largeMeter.IndexOf("ProEndDate=") + 11, (largeMeter.IndexOf("PlanStartDate=") - 12) - largeMeter.IndexOf("ProEndDate="))
                            updatedClip = movie.Replace(ToDay, Date.Now.ToLongDateString)
                            updatedLargeClip = largeMeter.Replace(ToDayLarge, Date.Now.ToLongDateString)
                            If (ToDay <> Date.Now.ToLongDateString) Then
                                movie = ObjCustomer.updateRealTimeDate(A_id, updatedClip, updatedLargeClip, GetConnectionData)
                            Else
                                movie = movie
                            End If
                        Else

                        End If
                        Dim MagnifyMeter As String = " <u>" + MeterName + "</u>   " + " (" + planname + ")" + " " + "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=" & CType(A_id, String) & "'  onclick='SetZoomValueEnterPrise(this.value,1)'  runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "

                        _column.Text = movie + MagnifyMeter

                        '  _column.Text = movie + "<input type=radio name='myradiogroup' onclick='SetZoomValueEnterPrise(this.value,1)' value=" & CType(A_id, String) & "> <u> " + MeterName + "</u>   " + " (" + planname + ")"
                        _row.Cells.Add(_column)
                    Next
                    EnterpriseMeter.Controls.Add(_row)
                    iloc = counter + iloc + 1
                    countVal = iloc
                Next
                EnterpriseMeter.Controls.Add(_row)

            End If
            If Not dssystem Is Nothing Then
                Dim MagnifySystemMeter As String
                Dim A_idSystem As String
                Dim MeterNameSystem As String
                Dim inloopChkSystem, outloopChkSystem, counterSystem, countValSystem, ilocSystem, maxCountSystem, rowDiffSystem, interRowValSystem As Integer

                Dim _rowSystem As TableRow
                Dim _columnSystem As TableCell
                Dim totalRowsSystem As Integer = dssystem.Tables(0).Rows.Count
                Dim trRowscountSystem As Integer = CInt(Math.Ceiling(totalRowsSystem / 5))

                For outloopChkSystem = 1 To trRowscountSystem
                    _rowSystem = New TableRow
                    _rowSystem.Attributes.Add("class", "SmallMeter")

                    counterSystem = 4
                    maxCountSystem = counterSystem + ilocSystem
                    rowDiffSystem = totalRowsSystem - maxCountSystem
                    If (rowDiffSystem <= 0) Then
                        interRowValSystem = (totalRowsSystem - inloopChkSystem)
                        interRowValSystem = interRowValSystem - 1 + inloopChkSystem
                    Else
                        interRowValSystem = maxCountSystem
                    End If
                    maxCountSystem = interRowValSystem
                    For inloopChkSystem = countValSystem To maxCountSystem
                        _columnSystem = New TableCell
                        movieSystem = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(3), String)
                        A_idSystem = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(0), String)
                        MeterNameSystem = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(2), String)
                        plannameSystem = ObjCustomer.PopulateMeterTreeManagerSystem(CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(1), String), CompanyID)
                        'Realtime Work 

                        RealTimeBitSystem = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(5), String)
                        If RealTimeBitSystem = True Then
                            Dim largeMeterSystem As String = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(4), String)
                            Dim ToDaySystem As String = movieSystem.Substring(movieSystem.IndexOf("ProEndDate=") + 11, (movieSystem.IndexOf("PlanStartDate=") - 12) - movieSystem.IndexOf("ProEndDate="))
                            Dim ToDayLargeSystem As String = largeMeterSystem.Substring(largeMeterSystem.IndexOf("ProEndDate=") + 11, (largeMeterSystem.IndexOf("PlanStartDate=") - 12) - largeMeterSystem.IndexOf("ProEndDate="))
                            updatedClipSystem = movieSystem.Replace(ToDay, Date.Now.ToLongDateString)
                            updatedLargeClipSystem = largeMeterSystem.Replace(ToDayLargeSystem, Date.Now.ToLongDateString)
                            If (ToDay <> Date.Now.ToLongDateString) Then
                                movieSystem = ObjCustomer.updateRealTimeDate_System(A_idSystem, updatedClipSystem, updatedLargeClipSystem, CompanyID)
                            Else
                                movieSystem = movieSystem
                            End If
                        Else

                        End If

                        _columnSystem.Text = movieSystem + "<u> " + MeterNameSystem + "</u>   " + " (" + plannameSystem + ")   <a href='EnterpriseSpeedoemeter.aspx?Zoomid=" & CType(Trim(A_idSystem), String) & "&id=" & CompanyID & "'  onclick='SetZoomValueSystem(this.value," & CompanyID & ")'  runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "

                        '"<input type=radio name='myradiogroup' onclick='SetZoomValueSystem(this.value," & CompanyID & ")' value=" & CType(A_idSystem, String) & "> <u> " + MeterNameSystem + "</u>   " + " (" + plannameSystem + ")"

                        _rowSystem.Cells.Add(_columnSystem)
                    Next
                    EnterpriseMeter.Controls.Add(_rowSystem)
                    ilocSystem = counterSystem + ilocSystem + 1
                    countValSystem = ilocSystem
                Next
                EnterpriseMeter.Controls.Add(_rowSystem)

            Else

            End If
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Sub

    Private Function GetBalanceSheetValues(ByVal fromDate As Date, ByVal toDate As Date, ByVal findingValues As String) As String

        bsDV.RowFilter = "Description='" & findingValues & "'"
        If bsDV.Count > 0 Then
            Return FormatNumber(bsDV.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If
    End Function

    Private Sub SetDateandCurrency()
        Dim intIndex As Integer = DrpSelectTime.SelectedIndex
        Dim dtTody As New Date
        Dim dtPre As New Date
        Dim dtBiYear As New Date
        Dim dtQYear As New Date
        dtTody = Now
        Select Case intIndex
            Case 0

                '#

                Dim dPreYear As New Date
                dPreYear = Now.AddYears(-1)
                Dim dFirstPreYear As New Date(dPreYear.Year, 1, 1)
                Dim dFirstCurYear As New Date(Now.Year, 1, 1)
                Dim CurrentYearStart As String = dFirstCurYear.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentYearEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
                Dim PreviousYearStart As String = dFirstPreYear.ToLongDateString + " " + "00:00:00.000"

                Dim lastmonth As Date = dFirstPreYear.AddMonths(11)
                Dim lastday As Integer = dFirstPreYear.AddMonths(11).DaysInMonth(dFirstPreYear.Year, dFirstPreYear.Month)
                Dim PreviousYearEnd As New Date(dPreYear.Year, lastmonth.Month, lastday)
                Dim PreviousYearEnd1 As String
                PreviousYearEnd1 = PreviousYearEnd.ToLongDateString + " " + "23:59:59.000"


                '#

                dtPre = dtTody.AddYears(-1)
                dtPre = dtPre.AddDays(1)
                strFrom = CurrentYearStart
                strTo = CurrentYearEnd
                strLastFrom = PreviousYearStart
                strLastTo = PreviousYearEnd1



                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dFirstCurYear.ToLongDateString + "</u><b> To </b> <u>" + Date.Now.ToLongDateString + "</u>" _
                & "<br><b> Previous Period : </b><u>" + dFirstPreYear.ToLongDateString + "</u><b> To </b> <u>" + PreviousYearEnd.ToLongDateString + "</u>"
            Case 1
                strTo = Format(dtTody, "MMM dd yyyy 23:59:59.000")

                dtPre = dtTody.AddMonths(-6)
                dtPre = dtPre.AddDays(1)
                strFrom = Format(dtPre, "MMM dd yyyy 00:00:00.000")

                strLastTo = Format(dtPre.AddDays(-1), "MMM dd yyyy 23:59:59.000")
                Dim previous As Date = dtPre.AddMonths(-6)
                strLastFrom = Format(previous, "MMM dd yyyy 00:00:00.000")

                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dtPre.ToLongDateString + "</u><b> To </b> <u>" + Date.Now.ToLongDateString + "</u>" _
              & "<br><b> Previous Period : </b><u>" + previous.ToLongDateString + "</u><b> To </b> <u>" + dtPre.AddDays(-1).ToLongDateString + "</u>"

            Case 2

                strTo = Format(dtTody, "MMM dd yyyy 23:59:59.000")

                dtPre = dtTody.AddMonths(-3)
                dtPre = dtPre.AddDays(1)
                strFrom = Format(dtPre, "MMM dd yyyy 00:00:00.000")

                strLastTo = Format(dtPre.AddDays(-1), "MMM dd yyyy 23:59:59.000")
                Dim previous As Date = dtPre.AddMonths(-3)
                strLastFrom = Format(previous, "MMM dd yyyy 00:00:00.000")

                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dtPre.ToLongDateString + "</u><b> To </b> <u>" + Date.Now.ToLongDateString + "</u>" _
                         & "<br><b> Previous Period : </b><u>" + previous.ToLongDateString + "</u><b> To </b> <u>" + dtPre.AddDays(-1).ToLongDateString + "</u>"

        End Select

        strCurrencyStatus = Objplan.GetProfileCurrency(GetConnectionData, "")
        sCurrency = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)
    End Sub

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

    Public Sub LoadEnterpriseMeters()
        StaticEnterprise.Visible = True
        EnterpriseMeter.Visible = True
        btnAdv.Visible = False
        Dim tr_profit As TableRow
        tr_profit = New TableRow

        Dim tr_OutCome As TableRow
        tr_OutCome = New TableRow

        Dim tr_ROI As TableRow
        tr_ROI = New TableRow

        Dim td_profit As TableCell
        td_profit = New TableCell

        Dim td_Sales As TableCell
        td_Sales = New TableCell

        Dim td_COGS As TableCell
        td_COGS = New TableCell

        Dim td_Overheads As TableCell
        td_Overheads = New TableCell

        Dim td_ROI As TableCell
        td_ROI = New TableCell

        tr_profit.Attributes.Add("class", "SmallMeter")
        tr_OutCome.Attributes.Add("class", "SmallMeter")
        td_profit.ColumnSpan = 3




        Dim MagnifyProfit As String = "<u>" + "<b>Profit</b>" + " " + "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=P'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifySales As String = "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=S'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifyCOGS As String = "<u>" + "<b>COGS </b>" + " " + "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=C'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifyOverheads As String = "<u>" + "<b>Overheads</b>" + " " + "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=O'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
        Dim MagnifyROI As String = "<u>" + "<b>ROI</b>" + " " + "<a href='EnterpriseSpeedoemeter.aspx?Zoomid=ROI'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "


        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                          & "&dateStart=" & strFrom _
                         & "&dateEnd=" & strTo _
                           & "&dateLastStart=" & strLastFrom _
                         & "&dateLastEnd=" & strLastTo _
                           & "&Currency=" & sCurrency _
                            & "&Name=Profit" _
                                  & "&Type=Profit"

        td_profit.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                         & "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
         & "</object> <br>" + MagnifyProfit
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("P", String) & ">  <u>" + "<b>Profit</b><br><br><br><br>" + " "

        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                           & "&dateStart=" & strFrom _
                          & "&dateEnd=" & strTo _
                            & "&dateLastStart=" & strLastFrom _
                          & "&dateLastEnd=" & strLastTo _
                            & "&Currency=" & sCurrency _
                             & "&Name=Sales" _
                                   & "&Type=Sales"
        td_Sales.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                        & "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
            & "</object> <br> <u>" + "<b>Sales</b>" + " " + MagnifySales
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("S", String) & ">  <u>" + "<b>Sales</b> " + " "

        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                          & "&dateStart=" & strFrom _
                         & "&dateEnd=" & strTo _
                           & "&dateLastStart=" & strLastFrom _
                         & "&dateLastEnd=" & strLastTo _
                           & "&Currency=" & sCurrency _
                            & "&Name=COGS" _
                                  & "&Type=COGS"
        td_COGS.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                    & "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
               & "</object> <br>" + MagnifyCOGS
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("C", String) & ">  <u>" + "<b>COGS</b> " + " "

        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                           & "&dateStart=" & strFrom _
                          & "&dateEnd=" & strTo _
                            & "&dateLastStart=" & strLastFrom _
                          & "&dateLastEnd=" & strLastTo _
                            & "&Currency=" & sCurrency _
                             & "&Name=Overheads" _
                                   & "&Type=Overheads"

        td_Overheads.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        & "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
               & "</object> <br>" + MagnifyOverheads
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("O", String) & ">  <u>" + "<b>Overheads</b> " + " "


        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                         & "&dateStart=" & strFrom _
                        & "&dateEnd=" & strTo _
                          & "&dateLastStart=" & strLastFrom _
                        & "&dateLastEnd=" & strLastTo _
                          & "&Currency=" & sCurrency _
                           & "&Name=ROI" _
                                 & "&Type=ROI"


        td_ROI.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='EnterpriseActuallROI' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallROI.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
 & "<embed src='/MeterTesting/EnterpriseActuallROI.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
   & "</object> <br>" + MagnifyROI
        ' <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("ROI", String) & ">  <u>" + "<b>ROI</b> " + " "


        tr_profit.Cells.Add(td_profit)
        tr_profit.Cells.Add(td_Sales)
        tr_profit.Cells.Add(td_COGS)
        tr_profit.Cells.Add(td_Overheads)
        tr_profit.Cells.Add(td_ROI)

        StaticEnterprise.Rows.Add(tr_profit)



    End Sub

    Private Sub Enterprisezoommeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Enterprisezoommeter.Click

        Dim strMeterId As String = Request.Form.Item("MeterOption")
        Dim strSystemId As String = Request.Form.Item("Midentity")
        If strMeterId = "" Then
            lblZoomEntity.Text = "+"
            btnAdv.Visible = False
            Exit Sub
        ElseIf strMeterId = "P" Or strMeterId = "S" Or strMeterId = "O" Or strMeterId = "C" Or strMeterId = "ROI" Then
            Session("strMeterId") = strMeterId
            lblZoomEntity.Visible = True
            ' LoadMeterZoomView(strMeterId)
            ' btnAdv.Visible = True
            ' EnterpriseAdvanceMeters.Visible = True
            btnAdv_Click(sender, e)
        Else
            Session("strMeterId") = strMeterId
            Session("strSystemId") = strSystemId
            lblZoomEntity.Visible = True
            ' LoadMeterZoomView_Enterprise(strMeterId)
            ' btnAdv.Visible = True
            ' EnterpriseAdvanceMeters.Visible = True
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
            btnAdv_Click(sender, e)
        End If
    End Sub

    Public Function LoadMeterZoomView_Enterprise(ByVal id As String) As String
        Dim dsLoadSaveClip As DataSet
        Dim AnalysisId As String

        Dim ZoomEntity As String
        Dim SystemId As String
        AnalysisId = Session("strMeterId")
        SystemId = Session("strSystemId")
        Dim ds1 As DataSet
        Dim ds As DataSet
        Dim plan As String
        If SystemId <> "" Then
            plan = ObjCustomer.GetPlanidZoomViewSystem(AnalysisId, SystemId)
            ds = ObjCustomer.GetZoomViewSystem(plan, AnalysisId, SystemId)
        Else
            plan = ObjCustomer.GetPlanidZoomView(AnalysisId, GetConnectionData)
            ds = ObjCustomer.GetZoomView(plan, AnalysisId, GetConnectionData)
        End If


        ZoomEntity = CType(ds.Tables(0).Rows(0).Item(4), String)
        lblZoomEntity.Text = CType(ds.Tables(0).Rows(0).Item(1), String)

        Dim dPreMonth As New Date
        Dim dPreYear As New Date
        Dim row_merchant As TableRow
        Dim cell As TableCell
        row_merchant = New TableRow
        row_merchant.Attributes.Add("class", "MerchantMeter")
        cell = New TableCell
        cell.Text = ZoomEntity
        row_merchant.Cells.Add(cell)
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterEnterprise.jpg'  visible= true runat='server'>"
        tr_Br.Attributes.Add("class", "MerchantMeter")
        tr_Br.Cells.Add(tc_Br)
        ZoomEnteriprseMeter.Controls.Add(row_merchant)
        ZoomEnteriprseMeter.Controls.Add(tr_Br)
        Session("strMeterId") = id
    End Function

    Public Function LoadMeterZoomView(ByVal id As String) As String

        If id = "P" Then
            lblZoomEntity.Text = "Profit"
        ElseIf id = "S" Then
            lblZoomEntity.Text = "Sales"
        ElseIf id = "C" Then
            lblZoomEntity.Text = "COGS"
        ElseIf id = "O" Then
            lblZoomEntity.Text = "Overheads"
        ElseIf id = "ROI" Then
            lblZoomEntity.Text = "ROI"
        End If

        Dim dPreMonth As New Date
        Dim dPreYear As New Date

        Dim row_merchant As TableRow
        Dim cell As TableCell

        row_merchant = New TableRow
        row_merchant.Attributes.Add("class", "MerchantMeter")
        cell = New TableCell


        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                  & "&dateStart=" & strFrom _
                 & "&dateEnd=" & strTo _
                   & "&dateLastStart=" & strLastFrom _
                 & "&dateLastEnd=" & strLastTo _
                   & "&Currency=" & sCurrency _
                    & "&Name=" & lblZoomEntity.Text _
                               & "&Type=" & lblZoomEntity.Text


        If id = "ROI" Then
            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='EnterpriseActuallROI' align='middle'>" _
                          & "<param name='allowScriptAccess' value='sameDomain' /> " _
                          & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                          & "<param name='movie' value='/MeterTesting/EnterpriseActuallROI.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
 & "<embed src='/MeterTesting/EnterpriseActuallROI.swf?" + strFlashVar + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
 & "</object> " _
                          & "<br>   "
        Else
            cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
                   & "<param name='allowScriptAccess' value='sameDomain' /> " _
                   & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                   & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
    & "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
    & "</object> " _
                                   & "<br>"
        End If

        row_merchant.Cells.Add(cell)
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterEnterprise.jpg'  visible= true runat='server'>"
        tr_Br.Attributes.Add("class", "MerchantMeter")
        tr_Br.Cells.Add(tc_Br)
        ZoomEnteriprseMeter.Controls.Add(row_merchant)
        'ZoomEnteriprseMeter.Caption = "My zoom meter"
        ZoomEnteriprseMeter.Controls.Add(tr_Br)
        Session("strMeterId") = id
    End Function

    Private Sub btnAdv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdv.Click
        Session("Advance") = 1
        Dim strMeterId As String = CType(Session("strMeterId"), String)
        Dim strSystemId As String = Session("strSystemId")

        If strMeterId = "" Then
            Exit Sub
        ElseIf strMeterId = "P" Or strMeterId = "S" Or strMeterId = "O" Or strMeterId = "C" Or strMeterId = "ROI" Then
            EnterpriseStatusAdvance(strMeterId)
            Enterprisezoommeter.Visible = False
            btnAdv.Visible = False
            EnterpriseimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdv.Visible = False
            EnterpriseAdvanceMeters.Visible = True
            EnterpriseMeter.Visible = False
            StaticEnterprise.Visible = False
        Else
            EnterpriseStatusAdvance_Enterprise(strMeterId)
            Enterprisezoommeter.Visible = False
            btnAdv.Visible = False
            EnterpriseimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdv.Visible = False
            EnterpriseAdvanceMeters.Visible = True
            EnterpriseMeter.Visible = False
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
        End If


    End Sub

    Public Function EnterpriseStatusAdvance_Enterprise(ByVal strMeterId As String) As String


        Dim strSystemId As String = Session("strSystemId")

        lblZoomEntity.Visible = True
        Dim ds1 As DataSet
        Dim plan As String
        If strSystemId <> "" Then
            plan = ObjCustomer.GetPlanidZoomViewSystem(strMeterId, strSystemId)
            ds1 = ObjCustomer.GetZoomViewSystem(plan, strMeterId, strSystemId)
        Else
            plan = ObjCustomer.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds1 = ObjCustomer.GetZoomView(plan, strMeterId, GetConnectionData)
        End If


        Dim ZoomEntity As String = CType(ds1.Tables(0).Rows(0).Item(4), String)
        Dim Name As String = CType(ds1.Tables(0).Rows(0).Item(1), String)
        lblZoomEntity.Text = Name
        Dim tr As New TableRow
        Dim td As New TableCell
        td.Text = ZoomEntity
        tr.Cells.Add(td)
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"

        tr_Br.Attributes.Add("class", "trsettings")
        tr_Br.Cells.Add(tc_Br)
        ZoomEnteriprseMeter.Controls.Add(tr)
        ZoomEnteriprseMeter.Rows.Add(tr_Br)
        Load_treeViewAdvance(strMeterId, "", "")
        EnterpriseAdvanceMeters.Visible = True
        EnterpriseMeter.Visible = False
        StaticEnterprise.Visible = False

    End Function

    Public Sub Load_treeViewAdvance(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)
        Dim ds1 As DataSet
        Dim plan As String
        Dim strSystemId As String = Session("strSystemId")
        Dim strMeterId As String = Session("strMeterId")
        If strSystemId <> "" Then
            plan = ObjCustomer.GetPlanidZoomViewSystem(strMeterId, strSystemId)
            ds1 = ObjCustomer.GetZoomViewSystem(plan, strMeterId, strSystemId)
        Else
            plan = ObjCustomer.GetPlanidZoomView(strMeterId, GetConnectionData)
            ds1 = ObjCustomer.GetZoomView(plan, strMeterId, GetConnectionData)
        End If





        Dim ZoomEntity As String = CType(ds1.Tables(0).Rows(0).Item(4), String)
        Dim Barmeter As String = ZoomEntity.Replace("/ActuallSpeedOMeter", "/2barGraph")
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
        Dim devMeter As String = ZoomEntity.Replace("ActuallSpeedOMeter.swf", "DeviationScale.swf")
        devMeter = devMeter.Replace("width='200'", "width='325'")
        devMeter = devMeter.Replace("width='200'", "width='325'")


        _devcolumn.Text = devMeter
        _row.Cells.Add(_devcolumn)
        _row.Cells.Add(_space)
        _row.Cells.Add(_barcolumn)
        EnterpriseAdvanceMeters.Controls.Add(_row)

    End Sub

    Public Function EnterpriseStatusAdvance(ByVal id As String) As String
        If id = "P" Then
            lblZoomEntity.Text = "Profit"
        ElseIf id = "S" Then
            lblZoomEntity.Text = "Sales"
        ElseIf id = "C" Then
            lblZoomEntity.Text = "COGS"
        ElseIf id = "O" Then
            lblZoomEntity.Text = "Overheads"
        ElseIf id = "ROI" Then
            lblZoomEntity.Text = "ROI"
        End If
        Dim cell_adv As TableCell
        cell_adv = New TableCell
        Dim row_adv As TableRow
        row_adv = New TableRow

        Dim cell_adv_bar As TableCell
        cell_adv_bar = New TableCell

        'Dim fromDate As Date = DateValue("1/6/2007")
        'Dim toDate As Date = CDate(DateSerial(fromDate.Year, fromDate.Month + 12, 0))

        'Dim fromDate1 As Date = DateValue("1/6/2006")
        'Dim toDate1 As Date = CDate(DateSerial(fromDate1.Year, fromDate.Month + 12, 0))




        strFlashVar = "Customerid=" & CType(GetConnectionData.CustomerID, String) _
                                & "&dateStart=" & strFrom _
                               & "&dateEnd=" & strTo _
                                 & "&dateLastStart=" & strLastFrom _
                               & "&dateLastEnd=" & strLastTo _
                                 & "&Currency=" & sCurrency _
                                  & "&Name=" & lblZoomEntity.Text _
                                             & "&Type=" & lblZoomEntity.Text

        If id = "ROI" Then
            cell_adv.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='EnterpriseDeviationROI' align='middle'>" _
                               & "<param name='allowScriptAccess' value='sameDomain' /> " _
                               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                               & "<param name='movie' value='/MeterTesting/EnterpriseDeviationROI.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                               & "<embed src='/MeterTesting/EnterpriseDeviationROI.swf?" + strFlashVar + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                                & "</object> " _
                                & "<br>"

            cell_adv_bar.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='150' height='260' id='EnterpriseTwoBarROI' align='middle'>" _
                                   & "<param name='allowScriptAccess' value='sameDomain' /> " _
                                   & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                                   & "<param name='movie' value='/MeterTesting/EnterpriseTwoBarROI.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                                & "<embed src='/MeterTesting/EnterpriseTwoBarROI.swf?" + strFlashVar + "' quality='high' width='150' height='260' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                                   & "</object> " _
                                                                   & "<br>"

        Else

            cell_adv.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='EnterpriseDeviationScale' align='middle'>" _
                     & "<param name='allowScriptAccess' value='sameDomain' /> " _
                     & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                     & "<param name='movie' value='/MeterTesting/EnterpriseDeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                     & "<embed src='/MeterTesting/EnterpriseDeviationScale.swf?" + strFlashVar + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                     & "</object> " _
                     & "<br>"

            cell_adv_bar.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='150' height='260' id='EnterpriseTwoBarGraph' align='middle'>" _
                                   & "<param name='allowScriptAccess' value='sameDomain' /> " _
                                   & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
                                   & "<param name='movie' value='/MeterTesting/EnterpriseTwoBarGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                                     & "<embed src='/MeterTesting/EnterpriseTwoBarGraph.swf?" + strFlashVar + "' quality='high' width='150' height='260' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
                                  & "</object> " _
                                   & "<br>"

        End If





        row_adv.Cells.Add(cell_adv)
        row_adv.Cells.Add(cell_adv_bar)
        EnterpriseAdvanceMeters.Controls.Add(row_adv)
        LoadMeterZoomView(id)
    End Function

    Private Sub EnterpriseimgbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnterpriseimgbtnBack.Click

        'editmeter.Visible = True
        Session("Advance") = Nothing
        ZoomEnteriprseMeter.Visible = True
        Enterprisezoommeter.Visible = True
        btnAdv.Visible = False
        EnterpriseimgbtnBack.Visible = False

        EnterpriseAdvanceMeters.Visible = False
        EnterpriseMeter.Visible = True
        StaticEnterprise.Visible = True

        lblPeriod.Enabled = True
        DrpSelectTime.Enabled = True
        lblTimePeriod.Enabled = True

        PanelEnterpriseZoom.Visible = False
        lblZoomEntity.Visible = False
        ZoomEnteriprseMeter.Visible = False

    End Sub

    Private Sub DrpSelectTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpSelectTime.SelectedIndexChanged
        lblZoomEntity.Text = "+"

        If Not Session("Advance") Is Nothing Then
            Session("Advance") = 1
            Dim strMeterId As String = CType(Session("strMeterId"), String)
            If strMeterId = "" Then
                Exit Sub
            ElseIf strMeterId = "P" Or strMeterId = "S" Or strMeterId = "O" Or strMeterId = "C" Or strMeterId = "ROI" Then
                EnterpriseStatusAdvance(strMeterId)
                Enterprisezoommeter.Visible = False
                btnAdv.Visible = False
                EnterpriseimgbtnBack.Visible = True
                lblZoomEntity.Visible = True
                btnAdv.Visible = False
                EnterpriseAdvanceMeters.Visible = True
                EnterpriseMeter.Visible = False
                StaticEnterprise.Visible = False
            End If

        Else


        End If

    End Sub
End Class