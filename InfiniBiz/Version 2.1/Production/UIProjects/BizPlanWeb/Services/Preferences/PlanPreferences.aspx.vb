Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.BLL
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl


Public Class PlanPreferences
    'Inherits PlanPreferencesBase
    Inherits PlanBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents lblErrorMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblPlanPref As System.Web.UI.WebControls.Label
    Protected WithEvents ImgBtntnExportPlan As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lnkRtfFile As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblDateExported As System.Web.UI.WebControls.Label
    Protected WithEvents tblExported As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblPlanName As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlanSaveName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblIncludeTables As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIncludeTables As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblChartInclude As System.Web.UI.WebControls.Label
    Protected WithEvents ddlIncludeCharts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chkDownload As System.Web.UI.WebControls.CheckBox
    Protected WithEvents btnExport As System.Web.UI.WebControls.Button
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    'Protected WithEvents lblFormat As System.Web.UI.WebControls.Label
    'Protected WithEvents ddlSaveFormat As System.Web.UI.WebControls.DropDownList
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

        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_btnExport")
        Me.btnExport.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_btnExport")
        Me.lblPlanPref.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lblPlanPref")
        Me.lnkRtfFile.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lnkRtfFile")
        Me.lblDateExported.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lblDateExported")
        Me.lblPlanName.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lblPlanName")
        Me.lblIncludeTables.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lblIncludeTables")
        Me.lblChartInclude.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_lblChartInclude")
        Me.chkDownload.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_chkDownload")
        Me.txtPlanSaveName.Text = ResMgr.GetString("bizplanweb_services_preferences_planpreferences_txtPlanSaveName")

    End Sub
#Region "............. Private Members "

    Private _includeTables As Boolean
    Private _includeCharts As Boolean
    Private _planSaveFormat As String
    Private _planSaveName As String

#End Region


    '#Region "................... Private Methods "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '

        If Not (Page.IsPostBack) Then
            lblErrorMessage.Visible = False
            txtPlanSaveName.Text = CurrentPlan.PlanName
        End If

        ShowExportedPlan()

        CurPage = 3
        CurItem = 1

    End Sub

    Private Sub lnkRtfFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkRtfFile.Click
        DownloadHandler.DownloadFile(Response, GetConnectionData, CurrentPlan.PlanID)
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click


        _planSaveName = txtPlanSaveName.Text
        _planSaveFormat = "rtf" 'CStr(ddlSaveFormat.SelectedValue)
        _includeTables = CBool(ddlIncludeTables.SelectedValue)
        _includeCharts = CBool(ddlIncludeCharts.SelectedValue)

        Dim options As New ExportPlanOptions
        options.FileExtension = _planSaveFormat
        options.FileName = CurrentPlan.PlanName
        options.MimeType = "text/plain"
        options.IncludeTables = _includeTables
        options.IncludeCharts = _includeCharts

        'Dim planExporter As New WebExporter(GetConnectionData, CurrentPlan)
        'Dim planExporter As New ExportPlanHTML(GetConnectionData, CurrentPlan)
        Dim planExporter As New planExporter(GetConnectionData, CurrentPlan)
        Dim planRTF As String
        Try
            'planRTF = planExporter.ExportPlan(Server.MapPath("./ExportCharts") & "/", options)
            planRTF = planExporter.GetPlanRTF(Server.MapPath("./ExportCharts") & "/", options)
        Catch ex As Exception
            lblErrorMessage.Text = ResMgr.GetString("bizplan_planpreferences_lblErrorMessage1")  '"Plan could not be exported. " & ex.Message
            lblErrorMessage.Visible = True
            Return
        End Try


        Dim flag As Boolean
        flag = Plan.SaveExportedPlan(GetConnectionData, CurrentPlan, options, planRTF)
        If (True) Then
            lblErrorMessage.Text = ResMgr.GetString("bizplan_planpreferences_lblErrorMessage2")
            lblErrorMessage.ForeColor = Color.Blue
            '"Plan has been exported successfully and save in your database."
        Else
            lblErrorMessage.Text = ResMgr.GetString("bizplan_planpreferences_lblErrorMessage3") '"Plan has not been exported due to some tachnical error."
        End If
        lblErrorMessage.Visible = True

        ShowExportedPlan()

        If (chkDownload.Checked) Then
            ' If Immediate download is required , then prompt the download box
            DownloadHandler.DownloadFile(Response, GetConnectionData, CurrentPlan.PlanID)
        End If

    End Sub

    Private Sub ShowExportedPlan()

        Dim ds As DataSet = Plan.GetExportedPlan(GetConnectionData, CurrentPlan.PlanID)
        If ds.Tables(0).Rows.Count > 0 Then
            tblExported.Visible = True
            lnkRtfFile.Text = ds.Tables(0).Rows(0).Item("DefaultFileName").ToString() & "." & ds.Tables(0).Rows(0).Item("DefaultFileExtension").ToString()
            lblDateExported.Text = "Exported On: " & CDate(ds.Tables(0).Rows(0).Item("ExportDate")).ToShortDateString()
            lnkRtfFile.CssClass = "lnkRtfFilePlanPreferences_Style"     'lnkRtfFile.ForeColor = System.Drawing.Color.Blue
        Else
            tblExported.Visible = False
        End If

    End Sub




    Private Sub ImgBtntnExportPlan_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtntnExportPlan.Click
        DownloadHandler.DownloadFile(Response, GetConnectionData, CurrentPlan.PlanID)

    End Sub


End Class
