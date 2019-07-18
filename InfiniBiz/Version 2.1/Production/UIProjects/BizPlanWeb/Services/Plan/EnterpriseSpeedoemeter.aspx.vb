
Option Strict Off
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO

Public Class EnterpriseSpeedoemeter
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
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

    Dim objBS As BalancesheetReport
    Private bsDV As New DataView
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim strCurrencyStatus As DataSet = Objplan.GetProfileCurrency(GetConnectionData, "")
        sCurrency = CType(strCurrencyStatus.Tables(0).Rows(0).Item(0), String)
        sCurrency = sCurrency.Remove(0, sCurrency.IndexOf(" ") + 1)
        If Not Page.IsPostBack Then
            SetDate()
            LoadEnterpriseMeters()
        Else
            SetDate()
            LoadEnterpriseMeters()
        End If
        SetFocus(testpanel)
    End Sub

    Private Function GetBalanceSheetValues(ByVal fromDate As Date, ByVal toDate As Date, ByVal findingValues As String) As String

        bsDV.RowFilter = "Description='" & findingValues & "'"
        If bsDV.Count > 0 Then
            Return FormatNumber(bsDV.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If
    End Function

    Private Sub SetDate()
        Dim intIndex As Integer = DrpSelectTime.SelectedIndex
        Dim dtTody As New Date
        Dim dtPre As New Date
        Dim dtBiYear As New Date
        Dim dtQYear As New Date
        dtTody = Now
        Select Case intIndex
            Case 0

                dtPre = dtTody.AddYears(-1)
                dtPre = dtPre.AddDays(1)
                strFrom = Format(dtPre, "MMM dd yyyy 00:00:00.000")
                strTo = Format(dtTody, "MMM dd yyyy 23:59:59.000")
                strLastFrom = Format(dtPre.AddYears(-1), "MMM dd yyyy 00:00:00.000")
                strLastTo = Format(dtTody.AddYears(-1), "MMM dd yyyy 23:59:59.000")
                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dtPre.ToLongDateString + "</u><b> To </b> <u>" + dtTody.ToLongDateString + "</u>" _
                & "<br><b> Previous Period : </b><u>" + dtPre.AddYears(-1).ToLongDateString + "</u><b> To </b> <u>" + dtTody.AddYears(-1).ToLongDateString + "</u>"
            Case 1
                dtPre = dtTody.AddMonths(-6)
                dtPre = dtPre.AddDays(1)
                strFrom = Format(dtPre, "MMM dd yyyy 00:00:00.000")
                strTo = Format(dtTody, "MMM dd yyyy 23:59:59.000")
                strLastFrom = Format(dtPre.AddYears(-1), "MMM dd yyyy 00:00:00.000")
                strLastTo = Format(dtTody.AddYears(-1), "MMM dd yyyy 23:59:59.000")
                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dtPre.ToLongDateString + "</u><b> To </b> <u>" + dtTody.ToLongDateString + "</u>" _
          & "<br><b> Previous Period : </b><u>" + dtPre.AddYears(-1).ToLongDateString + "</u><b> To </b> <u>" + dtTody.AddYears(-1).ToLongDateString + "</u>"

            Case 2
                dtPre = dtTody.AddMonths(-3)
                dtPre = dtPre.AddDays(1)
                strFrom = Format(dtPre, "MMM dd yyyy 00:00:00.000")
                strTo = Format(dtTody, "MMM dd yyyy 23:59:59.000")
                strLastFrom = Format(dtPre.AddYears(-1), "MMM dd yyyy 00:00:00.000")
                strLastTo = Format(dtTody.AddYears(-1), "MMM dd yyyy 23:59:59.000")
                lblTimePeriod.Text = "<b>Current Period From : </b><u>" + dtPre.ToLongDateString + "</u><b> To </b> <u>" + dtTody.ToLongDateString + "</u>" _
            & "<br><b> Previous Period : </b><u>" + dtPre.AddYears(-1).ToLongDateString + "</u><b> To </b> <u>" + dtTody.AddYears(-1).ToLongDateString + "</u>"

        End Select
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
   & "</object> " _
               & "<br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("P", String) & ">  <u>" + "<b>Profit</b><br><br><br><br>" + " "

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
 & "</object> " _
               & "<br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("S", String) & ">  <u>" + "<b>Sales</b> " + " "

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
               & "</object> " _
               & "<br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("C", String) & ">  <u>" + "<b>COGS</b> " + " "

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
               & "</object> " _
                      & "<br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("O", String) & ">  <u>" + "<b>Overheads</b> " + " "


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
   & "</object> " _
                        & "<br> <input type=radio name='myradiogroup' onclick='SetZoomValue(this.value,1)' value=" & CType("ROI", String) & ">  <u>" + "<b>ROI</b> " + " "


        tr_profit.Cells.Add(td_profit)
        tr_OutCome.Cells.Add(td_Sales)
        tr_OutCome.Cells.Add(td_COGS)
        tr_OutCome.Cells.Add(td_Overheads)
        tr_ROI.Cells.Add(td_ROI)
        EnterpriseMeter.Rows.Add(tr_profit)
        EnterpriseMeter.Rows.Add(tr_OutCome)
        EnterpriseMeter.Rows.Add(tr_ROI)
    End Sub

    Private Sub Enterprisezoommeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles Enterprisezoommeter.Click

        Dim strMeterId As String = Request.Form.Item("MeterOption")

        If strMeterId = "" Then
            lblZoomEntity.Text = "+"
            btnAdv.Visible = False
            Exit Sub
        ElseIf strMeterId = "P" Or strMeterId = "S" Or strMeterId = "O" Or strMeterId = "C" Or strMeterId = "ROI" Then
            Session("strMeterId") = strMeterId
            lblZoomEntity.Visible = True
            LoadMeterZoomView(strMeterId)
            btnAdv.Visible = True
            EnterpriseAdvanceMeters.Visible = True

        End If
    End Sub

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
        End If


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
        lblZoomEntity.Text = "+"
        EnterpriseAdvanceMeters.Visible = False
        EnterpriseMeter.Visible = True

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
            End If

        Else


        End If

    End Sub
End Class