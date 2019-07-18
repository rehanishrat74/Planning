Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class illustrations
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array, daSelectArray As Array, daArrayChild As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlIllustrations As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCharts As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlBusinessTracker As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlTables As System.Web.UI.WebControls.Panel
    Protected WithEvents iBtnTables As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnCharts As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnBusinessTracker As System.Web.UI.WebControls.ImageButton
    Protected WithEvents hypFinancialStatements As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypBasicInformation As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypForeCast As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypChartInitialAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypChartMonthlyAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypChartYearlyAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypChartFinancialStatement As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypReports As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypCharts As System.Web.UI.WebControls.HyperLink

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
        'Put user code to initialize the page here

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
            Charts()
            BusinessTracker()


            If CurrentPlan.PlanID = Nothing Then

                Response.Redirect("../Plan/PlanManager.aspx")
            End If
        Catch ex As Exception
            Trace.Warn("illustrations start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
        
    End Sub

    Private Sub Tables()
        'table
        Trace.Write("Table  Modelid  = 66 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 ")
        Trace.Write("Tables " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.iBtnTables.Enabled = True
        Else
            Me.iBtnTables.Enabled = False
        End If
        daArray = Nothing

    End Sub

    Private Sub Charts()
        'Charts 
        Trace.Write("Charts  Modelid  = 67 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 ")
        Trace.Write("charts" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.iBtnCharts.Enabled = True
        Else
            Me.iBtnCharts.Enabled = False
        End If
        daArray = Nothing

        ' ChartsOptions()
    End Sub
    Private Sub ChartsOptions()

        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid<>6 and modeloptionid<>5 and modeloptionid<>1 and modeloptionid<>4")
        If daArray.Length > 0 Then
            Me.hypChartInitialAnalysis.Enabled = False
        Else
            Me.hypChartInitialAnalysis.Enabled = True
        End If
        daArray = Nothing

        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid<>7 and modeloptionid<>9 and modeloptionid<>12  ")
        If daArray.Length > 0 Then
            Me.hypChartMonthlyAnalysis.Enabled = False
        Else
            Me.hypChartMonthlyAnalysis.Enabled = True
        End If
        daArray = Nothing

        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid<>8 and modeloptionid<>10 and modeloptionid<>11  ")
        If daArray.Length > 0 Then
            Me.hypChartYearlyAnalysis.Enabled = False
        Else
            Me.hypChartYearlyAnalysis.Enabled = True
        End If
        daArray = Nothing

        daArray = dtUserRigths.Select("  Modelid  = 67 and modeloptionid<>2 and modeloptionid<>3  ")
        If daArray.Length > 0 Then
            Me.hypFinancialStatements.Enabled = False
        Else
            Me.hypFinancialStatements.Enabled = True
        End If
        daArray = Nothing
    End Sub
    Private Sub BusinessTracker()
        'Business tracker
        Trace.Write("Tracker  Modelid  = 70 ")
        daArray = dtUserRigths.Select("  Modelid  = 70 ")
        Trace.Write("Tracker" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.iBtnBusinessTracker.Enabled = True
            BTOptions()
        Else
            Me.iBtnBusinessTracker.Enabled = False
        End If
        daArray = Nothing
    End Sub
    Private Sub BTOptions()
        'Reports
        Trace.Write("BTracker Modelid  = 70 option id =1 ")
        daArrayChild = dtUserRigths.Select("  Modelid  = 70 and modeloptionid=1 ")
        Trace.Write("Business Tracker option 1 " + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypReports.Enabled = True
        Else
            Me.hypReports.Enabled = False
        End If
        daArrayChild = Nothing

        'Charts
        Trace.Write("BTracker Modelid  = 70 option id =2 ")
        daArrayChild = dtUserRigths.Select("  Modelid  = 70 and modeloptionid=2 ")
        Trace.Write("BT option id =2" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypCharts.Enabled = True
        Else
            Me.hypCharts.Enabled = False
        End If
        daArrayChild = Nothing


    End Sub
    Private Sub iBtnTables_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnTables.Click
        Trace.Write("BTracker Modelid  = 70   SetPanels(0) ")
        SetPanels(0)
        Me.SetPanelsPositions(Me.pnlTables)

    End Sub
    Private Sub iBtnBusinessTracker_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnBusinessTracker.Click
        Trace.Write("BTracker Modelid  = 70   SetPanels(2) ")
        SetPanels(2)
        Me.SetPanelsPositions(Me.pnlBusinessTracker)
    End Sub
    Private Sub iBtnCharts_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnCharts.Click
        Trace.Write("BTracker Modelid  = 70   SetPanels(1) ")
        SetPanels(1)
        Me.SetPanelsPositions(Me.pnlCharts)
 


    End Sub
    Private Sub SetPanels(ByVal panel As Int16)
        Me.pnlIllustrations.Visible = False
        Me.pnlTables.Visible = Convert.ToBoolean(IIf(panel = 0, True, False))
        Me.pnlCharts.Visible = Convert.ToBoolean(IIf(panel = 1, True, False))
        Me.pnlBusinessTracker.Visible = Convert.ToBoolean(IIf(panel = 2, True, False))
    End Sub
    Private Sub SetPanelsPositions(ByVal panel As UI.WebControls.Panel)
        panel.Style.Add("POSITION", "absolute")
        panel.Style.Add("TOP", "8px")
        panel.Style.Add("Z-INDEX", "102")
        panel.Style.Add("LEFT", "8px")
    End Sub

    Private Sub pnlTables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlTables.Load

        Trace.Write("hypFinancialStatements  Modelid  = 66 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and (modeloptionid=11 or modeloptionid=10 or modeloptionid=9 or modeloptionid=3 or modeloptionid=7 or modeloptionid=12 or modeloptionid=5) ")
        Trace.Write("hypFinancialStatements " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypFinancialStatements.Enabled = True
        Else
            Me.hypFinancialStatements.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("hypBasicInformation  Modelid  = 66 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and (modeloptionid=1 or modeloptionid=2 or modeloptionid=4 or modeloptionid=13) ")
        Trace.Write("hypBasicInformation " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypBasicInformation.Enabled = True
        Else
            Me.hypBasicInformation.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("hypForeCast  Modelid  = 66 ")
        daArray = dtUserRigths.Select("  Modelid  = 66 and (modeloptionid=6 or modeloptionid=8  ) ")
        Trace.Write("hypForeCast " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypForeCast.Enabled = True
        Else
            Me.hypForeCast.Enabled = False
        End If
        daArray = Nothing


    End Sub

    Private Sub pnlCharts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlCharts.Load

        Trace.Write("Initial Analysis  Modelid  = 67 ")
        daArray = dtUserRigths.Select("  Modelid  = 67  and (modeloptionid=1  or modeloptionid=4 or modeloptionid=5 or modeloptionid=6 ) ")
        Trace.Write("Initial Analysis " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypChartInitialAnalysis.Enabled = True
        Else
            Me.hypChartInitialAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("Monthly Analysis  Modelid  = 67 ")
        daArray = dtUserRigths.Select("  Modelid  = 67 and (modeloptionid=7 or modeloptionid=9 or modeloptionid=12 ) ")
        Trace.Write("Monthly Analysis " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypChartMonthlyAnalysis.Enabled = True
        Else
            Me.hypChartMonthlyAnalysis.Enabled = False
        End If
        daArray = Nothing

        Trace.Write("Yearly Analysis  Modelid  = 67 ")
        daArray = dtUserRigths.Select("  Modelid  = 67  and (modeloptionid=8 or modeloptionid=10 or modeloptionid=11  ) ")
        Trace.Write("Yearly Analysis " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypChartYearlyAnalysis.Enabled = True
        Else
            Me.hypChartYearlyAnalysis.Enabled = False
        End If
        daArray = Nothing


        Trace.Write("Financial Statement  Modelid  = 67 ")
        daArray = dtUserRigths.Select("  Modelid  = 67  and (modeloptionid=2 or modeloptionid=3 ) ")
        Trace.Write("Financial Statement " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypFinancialStatements.Enabled = True
        Else
            Me.hypFinancialStatements.Enabled = False
        End If
        daArray = Nothing

    End Sub


    Private Sub pnlBusinessTracker_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlBusinessTracker.Load

        Trace.Write("Reports   Modelid  = 70 ")
        daArray = dtUserRigths.Select("  Modelid  = 70  and  modeloptionid=1   ")
        Trace.Write("Tracker Reports  " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypReports.Enabled = True
        Else
            Me.hypReports.Enabled = False
        End If
        daArray = Nothing


        Trace.Write("Charts  Modelid  = 70 ")
        daArray = dtUserRigths.Select("  Modelid  = 70   and modeloptionid=2 ")
        Trace.Write(" Tracker Charts " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypCharts.Enabled = True
        Else
            Me.hypCharts.Enabled = False
        End If
        daArray = Nothing
    End Sub
End Class
