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

Public Class Printing
    ' Inherits System.Web.UI.Page
    Inherits PrintingBase
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lnkPlanPreview As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkExportPlan As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkPlanOutline As System.Web.UI.WebControls.LinkButton
    Protected WithEvents ImagebuttonPreview As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonExport As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImagebuttonPlanoutline As System.Web.UI.HtmlControls.HtmlImage
    Dim redirectURL As String

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private Sub InitiliazeLanguage()
        Me.lnkPlanPreview.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanPreview")
        Me.lnkExportPlan.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkExportPlan")
        Me.lnkPlanOutline.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkPlanOutLine")
        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_plan_welcome_Printing")
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lnkPlanOutline.Visible = False
        ImagebuttonPlanoutline.Visible = False

        lnkPlanPreview.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")

        If Not IsNothing(Request.QueryString("printid")) And Not Page.IsPostBack Then
            CurPage = 3
            CurItem = CType(Request.QueryString("printid"), Integer)
            Select Case CurItem
                Case 0
                    '  lnkPlanPreview_Click(sender, e)
                    CurPage = 3
                    CurItem = 0
                    lnkPlanPreview.Visible = True
                    lnkExportPlan.Visible = True
                    ImagebuttonPreview.Visible = True
                    ImagebuttonExport.Visible = True
                    Exit Sub
                    redirectURL = Nothing '"/InfiniPlan/Services/PlanPreview/PlanPreview.htm"
                Case 1
                    redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
                    Response.Redirect(redirectURL)
                Case 2

                    redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"
                    Response.Redirect(redirectURL)
                Case 10
                    SetFocus()
                    redirectURL = Nothing
            End Select

        Else
            If Not Page.IsPostBack Then

                CurPage = 3
                CurItem = 0
            End If
        End If

        If Not Session("merchantProUserID") Is Nothing Then

            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String))
            Dim dr As DataRow
            If dtUserRigths.Select("  Modelid  = 67 And ModelOptionId = 1 ").Length > 0 Then lnkPlanPreview.Visible = True : ImagebuttonPreview.Visible = True
            If dtUserRigths.Select("  Modelid  = 67 And ModelOptionId = 2 ").Length > 0 Then lnkExportPlan.Visible = True : ImagebuttonExport.Visible = True
        Else
            lnkPlanPreview.Visible = True
            lnkExportPlan.Visible = True
            ImagebuttonPreview.Visible = True
            ImagebuttonExport.Visible = True
        End If
    End Sub

    Private Sub SetFocus()
        Dim Script As New System.Text.StringBuilder

        With Script
            .Append("<script language='javascript'>")
            
            .Append("GetFocus();")
            .Append("</script>")
        End With
        RegisterStartupScript("setFocus", Script.ToString())
    End Sub
    Private Sub lnkPlanPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanPreview.Click
        Dim redirectURL As String
        CurItem = 0
        redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx?printid=0"
        Response.Redirect(redirectURL)

    End Sub

    Private Sub lnkExportPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkExportPlan.Click
        Dim redirectURL As String
        CurItem = 1
        redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx?printid=1"
        Response.Redirect(redirectURL)
    End Sub

    Private Sub lnkPlanOutline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkPlanOutline.Click
        Dim redirectURL As String
        CurItem = 2
        redirectURL = "/InfiniPlan/Services/Printing/Printing.aspx?printid=2"
        Response.Redirect(redirectURL)
    End Sub

End Class
