Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class IplanText
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim daArray As Array, daArrayChild As Array, daSelectArray As Array
    Protected WithEvents hypExecutiveSummary As System.Web.UI.WebControls.HyperLink
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hypCompanyProfile As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProductsServicesSummary As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMarketAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypStrategyImplementation As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypManagementDetails As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypFinancialPlanOptions As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("print start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            SetPanelRight()


     

            If CurrentPlan.PlanID = Nothing Then
                Response.Redirect("../Plan/PlanManager.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
    End Sub

    Private Sub SetPanelRight()

        'Executive Summary Information
        Trace.Write("plan print modelid = 65 and (modeloptionid=1,2,3,4,5,6")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=1 or modeloptionid=2 or modeloptionid=3 or modeloptionid=4 or modeloptionid=5 or modeloptionid=6)")
        Trace.Write("plan print modelid = 65,1,2,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypExecutiveSummary.Enabled = True
        Else
            Me.hypExecutiveSummary.Enabled = False
        End If
        daArrayChild = Nothing

        'Company Profile
        Trace.Write("plan print modelid = 65 and (modeloptionid= 7,8,9,10")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=7 or modeloptionid=8 or modeloptionid=9 or modeloptionid=10 )")
        Trace.Write("plan print modelid = 65,1,2,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypCompanyProfile.Enabled = True
        Else
            Me.hypCompanyProfile.Enabled = False
        End If
        daArrayChild = Nothing

        'Products and Services Summary
        Trace.Write("plan print modelid = 65 and (modeloptionid=11,12,13,14")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=11 or modeloptionid=12 or modeloptionid=13 or modeloptionid=14) ")
        Trace.Write("plan print modelid = 65,1,2,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypProductsServicesSummary.Enabled = True
        Else
            Me.hypProductsServicesSummary.Enabled = False
        End If
        daArrayChild = Nothing

        'Market Analysis
        Trace.Write("plan print modelid = 65 and (modeloptionid=15,16,17,18,19,20,21")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=15 or modeloptionid=16 or modeloptionid=17 or modeloptionid=18 or modeloptionid=19 or modeloptionid=20 or modeloptionid=21) ")
        Trace.Write("plan print modelid = 65,15,16,17,18,19,20,21" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypMarketAnalysis.Enabled = True
        Else
            Me.hypMarketAnalysis.Enabled = False
        End If
        daArrayChild = Nothing

        'Strategy and Implementation
        Trace.Write("plan print modelid = 65 and (modeloptionid=1 or modeloptionid=2 or modeloptionid=3")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=22 or modeloptionid=23 or modeloptionid=24 or modeloptionid=25 or modeloptionid=26 or modeloptionid=27 or modeloptionid=28) ")
        Trace.Write("plan print modelid = 65,22,23,24,25,26,27,28" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypStrategyImplementation.Enabled = True
        Else
            Me.hypStrategyImplementation.Enabled = False
        End If
        daArrayChild = Nothing

        'Management Details
        Trace.Write("plan print modelid = 65 and (modeloptionid=29,30,31,32")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=29 or modeloptionid=30 or modeloptionid=31 or modeloptionid=32) ")
        Trace.Write("plan print modelid = 65,29,30,31,32" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypManagementDetails.Enabled = True
        Else
            Me.hypManagementDetails.Enabled = False
        End If
        daArrayChild = Nothing

        'Financial Plan Options
        Trace.Write("plan print modelid = 65 and (modeloptionid=33,34,35,36,37,38,39,40")
        daArrayChild = dtUserRigths.Select("  Modelid  = 65 and (modeloptionid=33 or modeloptionid=34 or modeloptionid=35 or modeloptionid=36 or modeloptionid=37 or modeloptionid=38 or modeloptionid=39 or modeloptionid=40)")
        Trace.Write("plan print modelid = 65,1,2,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypFinancialPlanOptions.Enabled = True
        Else
            Me.hypFinancialPlanOptions.Enabled = False
        End If
        daArrayChild = Nothing

    End Sub
End Class
