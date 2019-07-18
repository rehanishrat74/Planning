
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing

Public Class SpeedometerManager
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim AnalysisId As String
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents btnNew As System.Web.UI.WebControls.Button
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table
    Public dsClip As DataSet
    Protected WithEvents mainpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Public businessname As String
    Public objPlanvb As Plan
    Dim boolCheck As Boolean
    Protected WithEvents meterimg As System.Web.UI.HtmlControls.HtmlImage
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

    Public BPObject As InfiniLogic.BusinessPlan.BLL.BusinessPlan
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFocus(testpanel)
        Dim intloop As Integer
        Dim dt As DataTable = ObjCustomer.GetPlansListforMeters(GetConnectionData)
        If dt.Rows.Count = 0 Then
            lblMsg.Visible = True
            mainpanel.Visible = False
            lblMsg.Text = "The <b>Favorites  List</b> is empty. <p>To add a speedometer to the list, click the <b>Add to Favourites</b> link on <b>Meter Listing</b> page from within a plan.</p>"
            lblMsg.CssClass = "lblhelpMessage"
        Else

            For intloop = 0 To dt.Rows.Count - 1
                businessname = ObjCustomer.GetPlansName(CType(dt.Rows(intloop).Item(0), String), GetConnectionData)
                LoadFlashFilesfromDb(CType(dt.Rows(intloop).Item(0), String), businessname)

            Next
        End If
        CurPage = 2
        CurItem = 0
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
    Private Sub InitiliazeLanguage()
        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkSpeedometermanager")

    End Sub
    Public Sub LoadFlashFilesfromDb(ByVal PlanID As String, ByVal planname As String)

        Dim loopa As Integer, loopb As Integer
        dsFAvoritesClip = ObjCustomer.Get_FlashClip(PlanID, GetConnectionData)
        If dsFAvoritesClip.Tables(0).Rows.Count = 0 Then
            lblMsg.Visible = True

            lblMsg.Text = "The <b> Favourites List </b> is empty. To add a speedometer to the list, click the <b> Add to Favourites</b>  link on <b> Meter Listing</b>  page from within a plan."
            lblMsg.CssClass = "lblhelpMessage"
        Else
            'Main Work
            lblMsg.CssClass = "trsettings1"
            lblMsg.Visible = True
            lblMsg.Text = "This is a list of all the <b> Favourites  Speedometers</b>  from all the plans. Click on a <b> Speedometer</b>  to open."
            Dim td_movie As TableCell
            Dim tr_movie As TableRow
            tr_movie = New TableRow
            For loopa = 0 To dsFAvoritesClip.Tables(0).Rows.Count - 1
                tr_movie.Attributes.Add("class", "trsettings")
                td_movie = New TableCell
                td_movie.Text = CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(3), String)
                '   td_movie.Text = CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(4), String)
                tr_movie.Cells.Add(td_movie)
            Next

            Table1.Rows.Add(tr_movie)

            Dim tr_Button As New TableRow
            Dim tc_Button As TableCell
            For loopb = 0 To dsFAvoritesClip.Tables(0).Rows.Count - 1
                tc_Button = New TableCell
                tr_Button.Attributes.Add("class", "trsettings")
                'If CType(dsFAvoritesClip.Tables(1).Rows(loopb).Item(5), String) = "rbImeter.Checked" Then
                tc_Button.Text = " <a href='/infiniplan/services/plan/openplan.aspx?pid=" + PlanID + ",QID=" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' " _
                & "id='FAV" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' runat=server class='trsettings'   ><u>" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(1), String) + "   " + "</u> (" + planname + ") </a>"

                'Else
                ' tc_Button.Text = "<u>" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(1), String) + "   " + "</u> (" + planname + ")  "
                    'tc_Button.Text = " <a href='/infiniplan/services/plan/openplan.aspx?pid=" + PlanID + ",CID=" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' " _
                    ' & "id='FAV" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' runat=server class='trsettings'   ><u>" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(1), String) + "   " + "</u> (" + planname + ") </a>"

                '  End If
                tr_Button.Cells.Add(tc_Button)
            Next
            Table1.Rows.Add(tr_Button)

            Dim tr_Br As New TableRow
            Dim tc_Br As New TableCell

            tc_Br.Text = "&nbsp;"
            tr_Br.Cells.Add(tc_Br)
            Table1.Rows.Add(tr_Br)
            'Main Work

        End If
        Session("test") = 1
    End Sub


End Class
