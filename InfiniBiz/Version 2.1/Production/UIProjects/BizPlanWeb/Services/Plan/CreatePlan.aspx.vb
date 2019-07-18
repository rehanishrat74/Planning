Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing


Public Class CreatePlan
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Private _planFlag As Boolean
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents mpHoriz As Microsoft.Web.UI.WebControls.MultiPage
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents space1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnClosePlan As System.Web.UI.WebControls.Button
    Protected WithEvents imgBtnNewPlan1 As System.Web.UI.WebControls.Button
    Protected WithEvents imgBtnNewPlan As System.Web.UI.WebControls.Button


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
        Me.lblHeading.Text = ResMgr.GetString("bizplan_services_plan_createPlan_title_lblHeading")
        Me.imgBtnNewPlan.Text = ResMgr.GetString("bizplan_services_plan_planmanager_imgBtnNewPlan")


    End Sub
       

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim basePage As BizPlanWebBase
        basePage = CType(Me.Page, BizPlanWebBase)
        _planFlag = basePage.IsPlanOpened()
        If _planFlag = True Then
            imgBtnNewPlan.Enabled = False
            btnClosePlan.Visible = True
        Else
            imgBtnNewPlan.Enabled = True
            btnClosePlan.Visible = False
        End If


    End Sub
    Private Sub imgBtnNewPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgBtnNewPlan.Click
        Response.Redirect("/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx")
    End Sub


    Private Sub btnClosePlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClosePlan.Click
        Dim redirectURL As String
        If (Plan.CheckIfItIsASamplePlan(GetConnectionData, CurrentPlan.PlanID)) Then
            redirectURL = "/InfiniPlan/Services/Plan/SaveSamplePlan.aspx"
        Else
            BusinessPlanSummary = Nothing
            Session("LinkTable") = Nothing
            Session("LinkChart") = Nothing
            Session("test") = Nothing
            redirectURL = "/InfiniPlan/Services/Plan/CreatePlan.aspx"
        End If
        Response.Redirect(redirectURL)
    End Sub
End Class
