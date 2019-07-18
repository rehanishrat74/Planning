Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class ExecutiveSummaryInformation
    '  Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypPlanCover As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypLegalPage As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypExecutiveSummary As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypObjectives As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMission As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypKeystoSuccess As System.Web.UI.WebControls.HyperLink
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
            Trace.Write("ExecutiveSummaryInformation start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Cover page
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 1")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 1 ")
            Trace.Write("Text  Modelid  = 65 ,1 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypPlanCover.Enabled = True
            Else
                Me.hypPlanCover.Enabled = False
            End If
            daArray = Nothing


            'Legal Page
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 2 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 2 ")
            Trace.Write("Text  Modelid  = 65 ,2 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypLegalPage.Enabled = True
            Else
                Me.hypLegalPage.Enabled = False
            End If
            daArray = Nothing


            'Excutive summanry
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 3 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =3")
            Trace.Write("Text  Modelid  = 65 ,3 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypExecutiveSummary.Enabled = True
            Else
                Me.hypExecutiveSummary.Enabled = False
            End If
            daArray = Nothing


            'Objective
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 4 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 4")
            Trace.Write("Text  Modelid  = 65 ,4 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypObjectives.Enabled = True
            Else
                Me.hypObjectives.Enabled = False
            End If
            daArray = Nothing


            'Mission
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 5 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 5 ")
            Trace.Write("Text  Modelid  = 65 ,5 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypMission.Enabled = True
            Else
                Me.hypMission.Enabled = False
            End If
            daArray = Nothing


            'Key To success
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 6 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 6 ")
            Trace.Write("Text  Modelid  = 65 ,6:" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypKeystoSuccess.Enabled = True
            Else
                Me.hypKeystoSuccess.Enabled = False
            End If
            daArray = Nothing
            Trace.Write("ExecutiveSummaryInformation start page")


        Catch ex As Exception
            Trace.Warn("ExecutiveSummaryInformation start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try


    End Sub

End Class
