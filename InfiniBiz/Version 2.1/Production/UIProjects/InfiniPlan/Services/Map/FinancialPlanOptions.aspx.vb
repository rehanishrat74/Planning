Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class FinancialPlanOptions
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypFinancialPlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypImportantAssumptions As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypKeyFinancialIndicators As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBreakEvenAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProjectedProfitLoss As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProjectedCashFlow As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProjectedBalanceSheet As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBusinessRatio As System.Web.UI.WebControls.HyperLink
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
            Trace.Write("FinancialPlanOptions start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Financial Plan 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 33")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =33 ")
            Trace.Write("Text  Modelid  = 65 ,33 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypFinancialPlan.Enabled = True
            Else
                Me.hypFinancialPlan.Enabled = False
            End If
            daArray = Nothing


            'Important Assumptions 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 34 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 34 ")
            Trace.Write("Text  Modelid  = 65 ,34 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypImportantAssumptions.Enabled = True
            Else
                Me.hypImportantAssumptions.Enabled = False
            End If
            daArray = Nothing


            'Key Financial Indicators 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 35 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =35")
            Trace.Write("Text  Modelid  = 65 ,35 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypKeyFinancialIndicators.Enabled = True
            Else
                Me.hypKeyFinancialIndicators.Enabled = False
            End If
            daArray = Nothing


            'Break Even Analysis 
            Trace.Write("Text  Modelid  = 65 and modeloptionid =36 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 36")
            Trace.Write("Text  Modelid  = 65 ,36 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypBreakEvenAnalysis.Enabled = True
            Else
                Me.hypBreakEvenAnalysis.Enabled = False
            End If
            daArray = Nothing

            'Projected Profit & Loss
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 37 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 37")
            Trace.Write("Text  Modelid  = 65 ,37 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypProjectedProfitLoss.Enabled = True
            Else
                Me.hypProjectedProfitLoss.Enabled = False
            End If
            daArray = Nothing

            'Projected Cash Flow 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 38 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 38")
            Trace.Write("Text  Modelid  = 65 ,38 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypProjectedCashFlow.Enabled = True
            Else
                Me.hypProjectedCashFlow.Enabled = False
            End If
            daArray = Nothing

            'Projected Balance Sheet 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 39 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 39")
            Trace.Write("Text  Modelid  = 65 ,39 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypProjectedBalanceSheet.Enabled = True
            Else
                Me.hypProjectedBalanceSheet.Enabled = False
            End If
            daArray = Nothing

            'Business Ratio 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 40 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 40")
            Trace.Write("Text  Modelid  = 65 ,40 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypBusinessRatio.Enabled = True
            Else
                Me.hypBusinessRatio.Enabled = False
            End If
            daArray = Nothing

            Trace.Write("FinancialPlanOptions start page")


        Catch ex As Exception
            Trace.Warn("FinancialPlanOptions start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

    End Sub

End Class
