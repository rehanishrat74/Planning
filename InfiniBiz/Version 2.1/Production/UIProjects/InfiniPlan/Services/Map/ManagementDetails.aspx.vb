Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class ManagementDetails
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypManagementSummary As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hyporganizational As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypmanagement_teams As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPersonalPlan As System.Web.UI.WebControls.HyperLink
    Dim daArray As Array
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
        Try
            Trace.Write("ManagementDetails start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Management Summary
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 29")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =29")
            Trace.Write("Text  Modelid  = 65 ,29 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypManagementSummary.Enabled = True
            Else
                Me.hypManagementSummary.Enabled = False
            End If
            daArray = Nothing


            'Organizational Structure
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 30 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 30 ")
            Trace.Write("Text  Modelid  = 65 ,30 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hyporganizational.Enabled = True
            Else
                Me.hyporganizational.Enabled = False
            End If
            daArray = Nothing


            'Management Teams 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 31 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =31")
            Trace.Write("Text  Modelid  = 65 ,31 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypmanagement_teams.Enabled = True
            Else
                Me.hypmanagement_teams.Enabled = False
            End If
            daArray = Nothing


            'Personal Plan 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 32 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 32")
            Trace.Write("Text  Modelid  = 65 ,32:" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypPersonalPlan.Enabled = True
            Else
                Me.hypPersonalPlan.Enabled = False
            End If
            daArray = Nothing


            Trace.Write("ManagementDetails start page")


        Catch ex As Exception
            Trace.Warn("ManagementDetails start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
    End Sub

End Class
