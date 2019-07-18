Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class Charts
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array, daSelectArray As Array, daArrayChild As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlInitialAnalysis As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMonthlyAnalysis As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlYearlyAnalysis As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlFinancialStatements As System.Web.UI.WebControls.Panel
    Protected WithEvents hypPastPerformance As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMarketAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBenchmark As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypHighlight As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProfitMonthly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypGrossMarginMonthly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSalesMonthly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProfitYearly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypGrossMarginYearly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSalesYearly As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBreakEvenAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypCashFlowAnalysis As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("Charts start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If
 
            Charts()
            Trace.Write("Charts start page")
        Catch ex As Exception
            Trace.Write("Charts start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try



        Select Case Convert.ToInt16(Request.QueryString("panel").Trim)
            Case 0
                Me.SetPanelsPositions(Me.pnlInitialAnalysis)
                Trace.Write("Charts start page  Case 0")
            Case 1
                Me.SetPanelsPositions(Me.pnlMonthlyAnalysis)
                Trace.Write("Charts start page  Case 1")
            Case 2
                Me.SetPanelsPositions(Me.pnlYearlyAnalysis)
                Trace.Write("Charts start page  Case 2")
            Case 3
                Me.SetPanelsPositions(Me.pnlFinancialStatements)
                Trace.Write("Charts start page  Case 3")
        End Select
    End Sub
    Private Sub Charts()

        Me.SetPanels(Convert.ToInt16(Request.QueryString("panel").Trim))

        Trace.Write("charts  Modelid  = 67,1 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=1")
        Trace.Write("charts  Modelid  = 67,1 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypBenchmark.Enabled = True
        Else
            Me.hypBenchmark.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,2 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=2")
        Trace.Write("charts  Modelid  = 67,2 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypBreakEvenAnalysis.Enabled = True
        Else
            Me.hypBreakEvenAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,3 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=3")
        Trace.Write("charts  Modelid  = 67,3 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypCashFlowAnalysis.Enabled = True
        Else
            Me.hypCashFlowAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,4")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=4")
        Trace.Write("charts  Modelid  = 67,4:" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypHighlight.Enabled = True
        Else
            Me.hypHighlight.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,5 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=5")
        Trace.Write("charts  Modelid  = 67,5: " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypMarketAnalysis.Enabled = True
        Else
            Me.hypMarketAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,6 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=6")
        Trace.Write("charts  Modelid  = 67,6 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypPastPerformance.Enabled = True
        Else
            Me.hypPastPerformance.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,7 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=7")
        Trace.Write("charts  Modelid  = 67,7: " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypProfitMonthly.Enabled = True
        Else
            Me.hypProfitMonthly.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,8 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=8")
        Trace.Write("charts  Modelid  = 67,8 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypProfitYearly.Enabled = True
        Else
            Me.hypProfitYearly.Enabled = False
        End If
        daArray = Nothing


        Trace.Write("charts  Modelid  = 67,9")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=9")
        Trace.Write("charts  Modelid  = 67,9: " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypGrossMarginMonthly.Enabled = True
        Else
            Me.hypGrossMarginMonthly.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,10 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=10")
        Trace.Write("charts  Modelid  = 67,10 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypGrossMarginYearly.Enabled = True
        Else
            Me.hypGrossMarginYearly.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,11 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=11")
        Trace.Write("charts  Modelid  = 67,11 :" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypSalesYearly.Enabled = True
        Else
            Me.hypSalesYearly.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("charts  Modelid  = 67,12")
        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid=12")
        Trace.Write("charts  Modelid  = 67,12: " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypSalesMonthly.Enabled = True
        Else
            Me.hypSalesMonthly.Enabled = False
        End If
        daArray = Nothing




    End Sub


    Private Sub SetPanels(ByVal panel As Int16)

        Me.pnlInitialAnalysis.Visible = Convert.ToBoolean(IIf(panel = 0, True, False))

        Me.pnlMonthlyAnalysis.Visible = Convert.ToBoolean(IIf(panel = 1, True, False))
        Me.pnlYearlyAnalysis.Visible = Convert.ToBoolean(IIf(panel = 2, True, False))
        Me.pnlFinancialStatements.Visible = Convert.ToBoolean(IIf(panel = 3, True, False))



    End Sub
    Private Sub SetPanelsPositions(ByVal panel As UI.WebControls.Panel)
        panel.Style.Add("POSITION", "absolute")
        panel.Style.Add("TOP", "8px")
        panel.Style.Add("Z-INDEX", "102")
        panel.Style.Add("LEFT", "8px")
    End Sub
End Class
