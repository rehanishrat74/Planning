Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class Tables
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array, daSelectArray As Array, daArrayChild As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlFinancialStatements As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlBasicInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlForeCast As System.Web.UI.WebControls.Panel
    Protected WithEvents hypBalanceSheet As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypCashFlowStatement As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypIncomeStatement As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBreakEvenAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypExpenses As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypRatios As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPayroll As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypGeneralAssumptions As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypStartupDetails As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPastPerformance As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMarketAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMilestones As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSalesForecast As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("Planning start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            Tables()

        Catch ex As Exception
            Trace.Write("Tables start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
        Trace.Write("Tables start page")


        Me.SetPanelsVisibles(Convert.ToInt16(Request.QueryString("panel").Trim))
        Select Case Convert.ToInt16(Request.QueryString("panel").Trim)
            Case 0
                SetPanelsPositions(Me.pnlFinancialStatements)
                Trace.Write("tables start page  Case 0")
            Case 1
                SetPanelsPositions(Me.pnlBasicInformation)
                Trace.Write("tables start page  Case 1")
            Case 2
                SetPanelsPositions(Me.pnlForeCast)
                Trace.Write("tables start page  Case 2")
        End Select
    End Sub

    Private Sub Tables()

        Me.SetPanelsVisibles(Convert.ToInt16(Request.QueryString("panel").Trim))

        Trace.Write("charts  Modelid  = 66,1 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=1")
        Trace.Write("charts  Modelid  = 66,1:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypGeneralAssumptions.Enabled = True
        Else
            Me.hypGeneralAssumptions.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,2 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=2")
        Trace.Write("charts  Modelid  = 66,2:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypStartupDetails.Enabled = True
        Else
            Me.hypStartupDetails.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,3")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=3")
        Trace.Write("charts  Modelid  = 66,3:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypBreakEvenAnalysis.Enabled = True
        Else
            Me.hypBreakEvenAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,4 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=4")
        Trace.Write("charts  Modelid  = 66,4:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypMarketAnalysis.Enabled = True
        Else
            Me.hypMarketAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,5 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=5")
        Trace.Write("charts  Modelid  = 66,5:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypPayroll.Enabled = True
        Else
            Me.hypPayroll.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,6 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=6")
        Trace.Write("charts  Modelid  = 66,6:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypSalesForecast.Enabled = True
        Else
            Me.hypSalesForecast.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,7 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=7")
        Trace.Write("charts  Modelid  = 66,7:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypExpenses.Enabled = True
        Else
            Me.hypExpenses.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,8 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=8")
        Trace.Write("charts  Modelid  = 66,8:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypMilestones.Enabled = True
        Else
            Me.hypMilestones.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,9 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=9")
        Trace.Write("charts  Modelid  = 66,9:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypIncomeStatement.Enabled = True
        Else
            Me.hypIncomeStatement.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,10 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=10")
        Trace.Write("charts  Modelid  = 66,10:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypCashFlowStatement.Enabled = True
        Else
            Me.hypCashFlowStatement.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,11 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=11")
        Trace.Write("charts  Modelid  = 66,11:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypBalanceSheet.Enabled = True
        Else
            Me.hypBalanceSheet.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,12 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=12")
        Trace.Write("charts  Modelid  = 66,12:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypRatios.Enabled = True
        Else
            Me.hypRatios.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 66,13 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and modeloptionid=13")
        Trace.Write("charts  Modelid  = 66,13:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypPastPerformance.Enabled = True
        Else
            Me.hypPastPerformance.Enabled = False
        End If
        daArray = Nothing



    End Sub

    Private Sub SetPanelsVisibles(ByVal panel As Int16)
        Me.pnlFinancialStatements.Visible = Convert.ToBoolean(IIf(panel = 0, True, False))
        Me.pnlBasicInformation.Visible = Convert.ToBoolean(IIf(panel = 1, True, False))
        Me.pnlForeCast.Visible = Convert.ToBoolean(IIf(panel = 2, True, False))
    End Sub

    Private Sub SetPanelsPositions(ByVal panel As UI.WebControls.Panel)
        panel.Style.Add("POSITION", "absolute")
        panel.Style.Add("TOP", "8px")
        panel.Style.Add("Z-INDEX", "102")
        panel.Style.Add("LEFT", "8px")
    End Sub

End Class
