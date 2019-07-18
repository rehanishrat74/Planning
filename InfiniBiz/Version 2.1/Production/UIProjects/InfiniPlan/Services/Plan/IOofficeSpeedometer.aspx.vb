Option Strict Off
 

Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO

Public Class IOofficeSpeedometer
    'Inherits System.Web.UI.Page

    Inherits BizPlanWebBase

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

    Public obj As CustomerStatus

    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblZoomEntity As System.Web.UI.WebControls.Label
    Protected WithEvents InfiniOfficeMeter As System.Web.UI.WebControls.Table
    Protected WithEvents InfiniOfficeAdvanceMeters As System.Web.UI.WebControls.Table
    Protected WithEvents InfiniOfficePanel As System.Web.UI.WebControls.Panel
    Protected WithEvents InfiniOfficezoommeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents InfiniOfficeimgbtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents ZoomInfiniOfficeMeter As System.Web.UI.WebControls.Table
    Protected WithEvents btnAdvInfiniOffice As System.Web.UI.WebControls.Button
    Protected WithEvents PanelInfiniOfficeZoom As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlManagerInfiniOffice As System.Web.UI.WebControls.Panel

    Protected WithEvents lblTimePeriod As System.Web.UI.WebControls.Label
    Protected WithEvents DrpSelectTime As System.Web.UI.WebControls.DropDownList
    Protected WithEvents StaticIO As System.Web.UI.WebControls.Table
    Protected WithEvents lblPeriod As System.Web.UI.WebControls.Label
    Dim dssystem As DataSet
    Dim Type As String, SysID As String
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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


        Dim ds As DataSet = ObjCustomer.GetPlansListforMeters_IO(GetConnectionData)
        CompanyID = obj.GetSystemMeters(GetConnectionData)
          SetFocus(testpanel)
        SetDateandCurrency()

        If Not IsNothing(Request.QueryString("Zoomid")) And Not Page.IsPostBack Then
            Type = Request.QueryString("Zoomid")
            SysID = Request.QueryString("id")
            ZoomMetersIO(Type)

        Else
            LoadIOMeters()
            If CompanyID = 0 Then
                dssystem = Nothing
            Else
                dssystem = ObjCustomer.GetPlansListforMeters_IOSystem(CompanyID)
                If dssystem.Tables(0).Rows.Count = 0 Then dssystem = Nothing
            End If

            If (ds.Tables(0).Rows.Count <> 0) Then
                Load_treeView(ds, dssystem)
            End If

        End If

    End Sub
    Private Sub ZoomMetersIO(ByVal Type As String)

        PanelInfiniOfficeZoom.Visible = True
        lblZoomEntity.Visible = True
        ZoomInfiniOfficeMeter.Visible = True

        Session("Advance") = 1

        Dim strMeterIdIO As String = Type
        Dim strSystemIdIO As String = SysID


      
        If strMeterIdIO = "" Then
            lblZoomEntity.Text = "+"
            btnAdvInfiniOffice.Visible = False
            Exit Sub

        ElseIf strMeterIdIO = "S" Then
            Session("strMeterIdIO") = strMeterIdIO
            Session("strSystemIdIO") = strSystemIdIO
            lblZoomEntity.Visible = True
         
            InfiniOfficeAdvanceMeters.Visible = True

            IOStatusAdvance(strMeterIdIO)

            InfiniOfficeimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdvInfiniOffice.Visible = False
            ZoomInfiniOfficeMeter.Visible = True
            InfiniOfficeMeter.Visible = False
            StaticIO.Visible = False

        Else
            Session("strMeterIdIO") = strMeterIdIO
            Session("strSystemIdIO") = strSystemIdIO
            lblZoomEntity.Visible = True
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
      
            ZoomInfiniOfficeMeter.Visible = True

            StaticIO.Visible = False
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
            InfiniOfficezoommeter.Visible = False
            btnAdvInfiniOffice.Visible = False
            InfiniOfficeimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            Dim ds1 As DataSet
            Dim plan As String
            If strSystemIdIO <> "" Then
                plan = obj.GetPlanidZoomViewSystem(strMeterIdIO, strSystemIdIO)
                ds1 = obj.GetZoomViewSystem(plan, strMeterIdIO, strSystemIdIO)
            Else
                plan = obj.GetPlanidZoomView(strMeterIdIO, GetConnectionData)
                ds1 = obj.GetZoomView(plan, strMeterIdIO, GetConnectionData)
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
            ZoomInfiniOfficeMeter.Controls.Add(tr)
            ZoomInfiniOfficeMeter.Rows.Add(tr_Br)
            Load_treeViewAdvance(strMeterIdIO, "", "")
            InfiniOfficeAdvanceMeters.Visible = True
            InfiniOfficeMeter.Visible = False
        End If
    End Sub

    Public Sub LoadIOMeters()
        StaticIO.Visible = True
        InfiniOfficeMeter.Visible = True
        btnAdvInfiniOffice.Visible = False

        Dim AnalysisId As String = Session("strMeterIdIO")
        Dim SystemId As String = Session("strSystemIdIO")
        Dim CustomerId As String
        If SystemId <> "" Then
            CustomerId = SystemId
        Else
            CustomerId = GetConnectionData.CustomerID
        End If


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
        Dim MagnifySales As String = "<a href='IOofficeSpeedometer.aspx?Zoomid=S'  onclick='SetZoomValue(this.value,1)' runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "

        strFlashVar = "Customerid=" & CustomerId _
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
 & "</object> " _
               & "<br>  <u>" + "<b>Sales</b>" + " " + MagnifySales
        '<input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("S", String) & ">  <u>" + "<b>Sales</b> " + " "




        tr_profit.Cells.Add(td_Sales)
        StaticIO.Rows.Add(tr_profit)


    End Sub

    Private Sub SetDateandCurrency()
        Dim strCurrencyStatus As DataSet = Objplan.GetProfileCurrency(GetConnectionData, "")
        sCurrency = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)


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
    End Sub

    Public Sub Load_treeView(ByVal ds As DataSet, ByVal dssystem As DataSet)


        Try
            StaticIO.Visible = True
            InfiniOfficeMeter.Visible = True
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
                        Dim MagnifyMeterIO As String = " <u>" + MeterName + "</u>   " + " (" + planname + ")" + " " + "<a href='IOofficeSpeedometer.aspx?Zoomid=" & CType(A_id, String) & "'  onclick='SetZoomValueIO(this.value,1)'  runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "

                        _column.Text = movie + MagnifyMeterIO
                        '"<input type=radio name='myradiogroup' onclick='SetZoomValueIO(this.value,1)' value=" & CType(A_id, String) & "> <u> " + MeterName + "</u>   " + " (" + planname + ")"

                        _row.Cells.Add(_column)
                    Next
                    InfiniOfficeMeter.Controls.Add(_row)
                    iloc = counter + iloc + 1
                    countVal = iloc
                Next
                InfiniOfficeMeter.Controls.Add(_row)

            End If
            If Not dssystem Is Nothing Then
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
                        plannameSystem = obj.PopulateMeterTreeManagerSystem(CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(1), String), CompanyID)
                        'Realtime Work 

                        RealTimeBitSystem = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(5), String)
                        If RealTimeBitSystem = True Then
                            Dim largeMeterSystem As String = CType(dssystem.Tables(0).Rows(inloopChkSystem).Item(4), String)
                            Dim ToDaySystem As String = movieSystem.Substring(movieSystem.IndexOf("ProEndDate=") + 11, (movieSystem.IndexOf("PlanStartDate=") - 12) - movieSystem.IndexOf("ProEndDate="))
                            Dim ToDayLargeSystem As String = largeMeterSystem.Substring(largeMeterSystem.IndexOf("ProEndDate=") + 11, (largeMeterSystem.IndexOf("PlanStartDate=") - 12) - largeMeterSystem.IndexOf("ProEndDate="))
                            updatedClipSystem = movieSystem.Replace(ToDay, Date.Now.ToLongDateString)
                            updatedLargeClipSystem = largeMeterSystem.Replace(ToDayLargeSystem, Date.Now.ToLongDateString)
                            If (ToDay <> Date.Now.ToLongDateString) Then
                                movieSystem = obj.updateRealTimeDate_System(A_idSystem, updatedClipSystem, updatedLargeClipSystem, CompanyID)
                            Else
                                movieSystem = movieSystem
                            End If
                        Else

                        End If

                        _columnSystem.Text = movieSystem + "<u> " + MeterNameSystem + "</u>   " + " (" + plannameSystem + ")   <a href='IOofficeSpeedometer.aspx?Zoomid=" & CType(Trim(A_idSystem), String) & "&id=" & CompanyID & "'  onclick='SetZoomValueSystem(this.value," & CompanyID & ")'  runat=server ><img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   "
                        '"<input type=radio name='myradiogroup' onclick='SetZoomValueSystem(this.value," & CompanyID & ")' value=" & CType(A_idSystem, String) & "> <u> " + MeterNameSystem + "</u>   " + " (" + plannameSystem + ")"

                        _rowSystem.Cells.Add(_columnSystem)
                    Next
                    InfiniOfficeMeter.Controls.Add(_rowSystem)
                    ilocSystem = counterSystem + ilocSystem + 1
                    countValSystem = ilocSystem
                Next
                InfiniOfficeMeter.Controls.Add(_rowSystem)

            Else

            End If
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Sub

    Private Sub InfiniOfficezoommeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles InfiniOfficezoommeter.Click

        Dim strMeterIdIO As String = Request.Form.Item("MeterOption")
        Dim strSystemIdIO As String = Request.Form.Item("Midentity")
        If strMeterIdIO = "" Then
            lblZoomEntity.Text = "+"
            btnAdvInfiniOffice.Visible = False
            Exit Sub

        ElseIf strMeterIdIO = "S" Then
            Session("strMeterIdIO") = strMeterIdIO
            Session("strSystemIdIO") = strSystemIdIO
            lblZoomEntity.Visible = True
            ' LoadMeterZoomView_IO(strMeterIdIO)
            ' btnAdvInfiniOffice.Visible = True
            InfiniOfficeAdvanceMeters.Visible = True

            btnAdvInfiniOffice_Click(sender, e)
        Else
            Session("strMeterIdIO") = strMeterIdIO
            Session("strSystemIdIO") = strSystemIdIO
            lblZoomEntity.Visible = True
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
            'LoadMeterZoomView(strMeterIdIO)
            ' btnAdvInfiniOffice.Visible = True
            ZoomInfiniOfficeMeter.Visible = True

            btnAdvInfiniOffice_Click(sender, e)
        End If
    End Sub

    Public Function LoadMeterZoomView_IO(ByVal id As String) As String

        If id = "S" Then
            lblZoomEntity.Text = "Sales"

        End If

        Dim AnalysisId As String = Session("strMeterIdIO")
        Dim SystemId As String = Session("strSystemIdIO")
        Dim CustomerId As String
        If SystemId <> "" Then
            CustomerId = SystemId
        Else
            CustomerId = GetConnectionData.CustomerID
        End If


        Dim dPreMonth As New Date
        Dim dPreYear As New Date

        Dim row_merchant As TableRow
        Dim cell As TableCell




        row_merchant = New TableRow
        row_merchant.Attributes.Add("class", "MerchantMeter")
        cell = New TableCell

        strFlashVar = "Customerid=" & CustomerId _
                  & "&dateStart=" & strFrom _
                 & "&dateEnd=" & strTo _
                   & "&dateLastStart=" & strLastFrom _
                 & "&dateLastEnd=" & strLastTo _
                   & "&Currency=" & sCurrency _
                    & "&Name=" & lblZoomEntity.Text _
                               & "&Type=" & lblZoomEntity.Text


        cell.Text = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='235' id='EnterpriseActuallSpeedOMeter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' /> " _
               & "<PARAM NAME=FlashVars VALUE='" + strFlashVar + " '>" _
               & "<param name='movie' value='/MeterTesting/EnterpriseActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
& "<embed src='/MeterTesting/EnterpriseActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='200' height='235' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
& "</object> " _
                               & "<br>"


        row_merchant.Cells.Add(cell)
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterEnterprise.jpg'  visible= true runat='server'>"
        tr_Br.Attributes.Add("class", "MerchantMeter")
        tr_Br.Cells.Add(tc_Br)
        ZoomInfiniOfficeMeter.Controls.Add(row_merchant)

        ZoomInfiniOfficeMeter.Controls.Add(tr_Br)
        Session("strMeterIdIO") = id
    End Function


    Public Function LoadMeterZoomView(ByVal id As String) As String
        Dim dsLoadSaveClip As DataSet
        Dim AnalysisId As String

        Dim ZoomEntity As String
        Dim SystemId As String
        AnalysisId = Session("strMeterIdIO")
        SystemId = Session("strSystemIdIO")
        Dim ds1 As DataSet
        Dim ds As DataSet
        Dim plan As String
        If SystemId <> "" Then
            plan = obj.GetPlanidZoomViewSystem(AnalysisId, SystemId)
            ds = obj.GetZoomViewSystem(plan, AnalysisId, SystemId)
        Else
            plan = obj.GetPlanidZoomView(AnalysisId, GetConnectionData)
            ds = obj.GetZoomView(plan, AnalysisId, GetConnectionData)
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
        ZoomInfiniOfficeMeter.Controls.Add(row_merchant)
        ZoomInfiniOfficeMeter.Controls.Add(tr_Br)
        Session("strMeterIdIO") = id
    End Function

    Public Function IOStatusAdvance(ByVal id As String) As String
        If id = "S" Then
            lblZoomEntity.Text = "Sales"

        End If
        Dim cell_adv As TableCell
        cell_adv = New TableCell
        Dim row_adv As TableRow
        row_adv = New TableRow

        Dim AnalysisId As String = Session("strMeterIdIO")
        Dim SystemId As String = Session("strSystemIdIO")
        Dim CustomerId As String
        If SystemId <> "" Then
            CustomerId = SystemId
        Else
            CustomerId = GetConnectionData.CustomerID
        End If

        Dim cell_adv_bar As TableCell
        cell_adv_bar = New TableCell

        strFlashVar = "Customerid=" & CustomerId _
                                & "&dateStart=" & strFrom _
                               & "&dateEnd=" & strTo _
                                 & "&dateLastStart=" & strLastFrom _
                               & "&dateLastEnd=" & strLastTo _
                                 & "&Currency=" & sCurrency _
                                  & "&Name=" & lblZoomEntity.Text _
                                             & "&Type=" & lblZoomEntity.Text


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



        row_adv.Cells.Add(cell_adv)
        row_adv.Cells.Add(cell_adv_bar)
        InfiniOfficeAdvanceMeters.Controls.Add(row_adv)
        InfiniOfficezoommeter.Visible = False
        LoadMeterZoomView_IO(id)
    End Function

    Public Sub Load_treeViewAdvance_IO(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)
        Dim ds1 As DataSet
        Dim plan As String
        Dim strSystemIdIO As String = Session("strSystemIdIO")
        Dim strMeterIdIO As String = Session("strMeterIdIO")
        If strSystemIdIO <> "" Then
            plan = obj.GetPlanidZoomViewSystem(strMeterIdIO, strSystemIdIO)
            ds1 = obj.GetZoomViewSystem(plan, strMeterIdIO, strSystemIdIO)
        Else
            plan = obj.GetPlanidZoomView(strMeterIdIO, GetConnectionData)
            ds1 = obj.GetZoomView(plan, strMeterIdIO, GetConnectionData)
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
        InfiniOfficeAdvanceMeters.Controls.Add(_row)

    End Sub

    Private Sub btnAdvInfiniOffice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdvInfiniOffice.Click
        Session("Advance") = 1

        Dim strMeterIdIO As String = Session("strMeterIdIO")
        Dim strSystemIdIO As String = Session("strSystemIdIO")

        If strMeterIdIO = "" Then
            Exit Sub

        ElseIf strMeterIdIO = "S" Then
            IOStatusAdvance(strMeterIdIO)

            InfiniOfficeimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            btnAdvInfiniOffice.Visible = False
            ZoomInfiniOfficeMeter.Visible = True
            InfiniOfficeMeter.Visible = False
            StaticIO.Visible = False

        Else
            StaticIO.Visible = False
            lblPeriod.Enabled = False
            DrpSelectTime.Enabled = False
            lblTimePeriod.Enabled = False
            InfiniOfficezoommeter.Visible = False
            btnAdvInfiniOffice.Visible = False
            InfiniOfficeimgbtnBack.Visible = True
            lblZoomEntity.Visible = True
            Dim ds1 As DataSet
            Dim plan As String
            If strSystemIdIO <> "" Then
                plan = obj.GetPlanidZoomViewSystem(strMeterIdIO, strSystemIdIO)
                ds1 = obj.GetZoomViewSystem(plan, strMeterIdIO, strSystemIdIO)
            Else
                plan = obj.GetPlanidZoomView(strMeterIdIO, GetConnectionData)
                ds1 = obj.GetZoomView(plan, strMeterIdIO, GetConnectionData)
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
            ZoomInfiniOfficeMeter.Controls.Add(tr)
            ZoomInfiniOfficeMeter.Rows.Add(tr_Br)
            Load_treeViewAdvance(strMeterIdIO, "", "")
            InfiniOfficeAdvanceMeters.Visible = True
            InfiniOfficeMeter.Visible = False
        End If

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

    Public Sub Load_treeViewAdvance(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)
        Dim ds1 As DataSet
        Dim plan As String
        Dim strSystemIdIO As String = Session("strSystemIdIO")
        Dim strMeterIdIO As String = Session("strMeterIdIO")
        If strSystemIdIO <> "" Then
            plan = obj.GetPlanidZoomViewSystem(strMeterIdIO, strSystemIdIO)
            ds1 = obj.GetZoomViewSystem(plan, strMeterIdIO, strSystemIdIO)
        Else
            plan = obj.GetPlanidZoomView(strMeterIdIO, GetConnectionData)
            ds1 = obj.GetZoomView(plan, strMeterIdIO, GetConnectionData)
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
        InfiniOfficeAdvanceMeters.Controls.Add(_row)

    End Sub

    Private Sub InfiniOfficeimgbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfiniOfficeimgbtnBack.Click

        Session("Advance") = Nothing

        InfiniOfficezoommeter.Visible = True
        btnAdvInfiniOffice.Visible = False
        InfiniOfficeimgbtnBack.Visible = False

        InfiniOfficeAdvanceMeters.Visible = False
        InfiniOfficeMeter.Visible = True

        lblPeriod.Enabled = True
        DrpSelectTime.Enabled = True
        lblTimePeriod.Enabled = True

        PanelInfiniOfficeZoom.Visible = False
        lblZoomEntity.Visible = False
        ZoomInfiniOfficeMeter.Visible = False

    End Sub

    Private Sub DrpSelectTime_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrpSelectTime.SelectedIndexChanged
        lblZoomEntity.Text = "+"

        If Not Session("Advance") Is Nothing Then
            Session("Advance") = 1
            Dim strMeterIdIO As String = CType(Session("strMeterIdIO"), String)
            If strMeterIdIO = "" Then
                Exit Sub
            ElseIf strMeterIdIO = "S" Then
                IOStatusAdvance(strMeterIdIO)
                InfiniOfficezoommeter.Visible = False
                btnAdvInfiniOffice.Visible = False
                InfiniOfficeimgbtnBack.Visible = True

                InfiniOfficeAdvanceMeters.Visible = True
                InfiniOfficeMeter.Visible = False
                StaticIO.Visible = False
            End If

        Else


        End If

    End Sub

End Class
