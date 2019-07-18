Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class PlanRoot
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array
    Dim ObjCustomer As CustomerStatus
    Public ObjPlan As Plan
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hypPlanManagment As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMeters As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPrint As System.Web.UI.WebControls.HyperLink
    Protected WithEvents iBtnIllustrations As System.Web.UI.WebControls.ImageButton

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

       

        Try
            Trace.Write("PlanRoot start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Select
            Trace.Write("select  Modelid  = 61 ")
            daArray = dtUserRigths.Select("  Modelid  = 61 ")
            Trace.Write("Select" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.iBtnIllustrations.Enabled = True
            Else
                Me.iBtnIllustrations.Enabled = False
            End If
            daArray = Nothing
            Trace.Write("PlanRoot start page")
        Catch ex As Exception
            Trace.Warn("PlanRoot start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
    End Sub

    Private Sub iBtnIllustrations_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnIllustrations.Click
        Response.Redirect("/InfiniPlan/Services/Map/Illustrations.aspx")
    End Sub
End Class
