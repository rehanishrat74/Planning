Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Public Class Home
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText3 As System.Web.UI.WebControls.Label

    Dim ObjCustomer As CustomerStatus
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnStart As System.Web.UI.WebControls.Button

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
    Dim aa As Plan
    Private Sub InitiliazeLanguage()

        'Dim str As String = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkHome")
        Me.lblHeading1.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading1")
        Me.lblHeading2.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading2")
        Me.lblHeading3.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading3")
        Me.btnStart.Text = ResMgr.GetString("bizplanweb_services_plan_home_btnStart")
        Me.txtText1.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText1")
        Me.txtText2.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText2")
        Me.txtText3.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText3")
        ' Me.lblHeading.text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading")

    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Put user code to initialize the page here
        Dim BoolStatus As Boolean
        ' BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        HttpContext.Current.Session("CopyPlanid") = Nothing
        SetProWebCustomer = BoolStatus
        If Not Session("merchantProUserID") Is Nothing Then
            Session("AllowPages") = Nothing
            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            GetAllowedPages = dtUserRigths
            Dim dr As DataRow
            Dim da As Array
            da = dtUserRigths.Select("  Modelid  = 67 or Modelid  = 68 or Modelid  = 70 ")
            If da.Length > 0 Then
                btnStart.Visible = True
            Else
                btnStart.Visible = False
            End If

        Else
            btnStart.Visible = True

        End If


        If IsPlanOpened Then
            Response.Redirect("/InfiniPlan/Services/Welcome.aspx")
        End If
        CurPage = 0
        CurItem = 0

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Session("Bar") = Nothing
        Response.Redirect("/InfiniPlan/Services/Plan/PlanManager.aspx")
    End Sub
End Class
