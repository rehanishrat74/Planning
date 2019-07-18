Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Public Class SaveSamplePlan
    Inherits PlanBase
    ' Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents btnNo As System.Web.UI.WebControls.Button
    Protected WithEvents tblSavePlan As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnReplaceNo As System.Web.UI.WebControls.Button
    Protected WithEvents btnReplaceYes As System.Web.UI.WebControls.Button
    Protected WithEvents tblReplacePlan As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents btnReplaceCancel As System.Web.UI.WebControls.Button
    Protected WithEvents hdnPlanName As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hdnPlanID As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents lblSavePlan As System.Web.UI.WebControls.Label
    Protected WithEvents lblOverwritePlan As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub

#End Region

    Private Sub InitiliazeLanguage()

        Me.lblMessage.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_lblMessage")
        Me.lblSavePlan.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_lblSavePlan")
        Me.btnSubmit.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnSubmit")
        Me.lblOverwritePlan.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_lblOverwritePlan")

        Me.btnNo.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnNo")
        Me.btnCancel.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnCancel")
        Me.btnReplaceYes.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnReplaceYes")
        Me.btnReplaceNo.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnReplaceNo")
        Me.btnReplaceCancel.Text = ResMgr.GetString("bizplanweb_services_plan_savesampleplan_btnReplaceCancel")

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then
            tblSavePlan.Visible = True
            tblReplacePlan.Visible = False
        End If
        btnReplaceNo.Attributes.Add("OnClick", "javascript:void(0);return getPlanName();")

        CurPage = -1
        CurItem = -1
        lblMessage.Text = ""
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try
            'CHECK IF THE PLAN WITH A SAME NAME EXISTS IN THE MERCHANT DATABASE.
            Dim PlanIDToBeOverWritten As Integer = Plan.CheckifPlanExistsWithTheSameName(GetConnectionData, CurrentPlan.PlanName)

            If PlanIDToBeOverWritten = 1 Then 'Show warning message
                tblSavePlan.Visible = False
                tblReplacePlan.Visible = True
            Else    'Save the Plan
                Plan.SaveSamplePlan(GetConnectionData, CurrentPlan.PlanID, "")
                Response.Redirect("/InfiniPlan/Services/Plan/ClosePlan.aspx")
            End If
        Catch ex As Exception
            lblMessage.Text = "Unable To Save Plan"
        End Try

    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Try
            Plan.PermanentlyDeletePlan(GetConnectionData, CurrentPlan.PlanID)
        Catch ex As Exception
            lblMessage.Text = "Unable To Perform Desired Operation"
        Finally
            Response.Redirect("/InfiniPlan/Services/Plan/ClosePlan.aspx")
        End Try
    End Sub

    Private Sub btnReplaceYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceYes.Click
        Plan.SaveSamplePlan(GetConnectionData, CurrentPlan.PlanID, "")
        Response.Redirect("/InfiniPlan/Services/Plan/ClosePlan.aspx")
    End Sub

    Private Sub btnReplaceNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceNo.Click

        If Not REValidator.IsIdentifier(hdnPlanName.Value.ToString()) Then
            lblMessage.Text = "Please enter a valid name for the Plan."
            lblMessage.Visible = True
            Exit Sub
        End If

        Try
            'CHECK IF THE PLAN WITH A SAME NAME EXISTS IN THE MERCHANT DATABASE.
            Dim PlanIDToBeOverWritten As Integer = Plan.CheckifPlanExistsWithTheSameName(GetConnectionData, hdnPlanName.Value.ToString())

            If PlanIDToBeOverWritten = 1 Then 'Show warning message
                tblSavePlan.Visible = False
                tblReplacePlan.Visible = True
            Else    'Save the Plan
                Plan.SaveSamplePlan(GetConnectionData, CurrentPlan.PlanID, hdnPlanName.Value.ToString())
                Response.Redirect("/InfiniPlan/Services/Plan/ClosePlan.aspx")
            End If
        Catch ex As Exception
            lblMessage.Text = "Unable To Save Plan"
        End Try

    End Sub

    Private Sub btnReplaceCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplaceCancel.Click
        tblSavePlan.Visible = True
        tblReplacePlan.Visible = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx")
    End Sub
End Class
