Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class MarketAnalysis
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypMarketAnalysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypmarket_segmentation As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypTargetMarketSegmentStrategy As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMarketGrowth As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypindustry_analysis As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypIndustryParticipants As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypmaincompetitors As System.Web.UI.WebControls.HyperLink
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
            Trace.Write("MarketAnalysis start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Market Analysis Summary 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 15")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =15 ")
            Trace.Write("Text  Modelid  = 65 ,15 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypMarketAnalysis.Enabled = True
            Else
                Me.hypMarketAnalysis.Enabled = False
            End If
            daArray = Nothing

            'Market Segmentation 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 16")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =16 ")
            Trace.Write("Text  Modelid  = 65 ,16 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypmarket_segmentation.Enabled = True
            Else
                Me.hypmarket_segmentation.Enabled = False
            End If
            daArray = Nothing

            'Target Market Segment Strategy  
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 17 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 17 ")
            Trace.Write("Text  Modelid  = 65 ,17 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypTargetMarketSegmentStrategy.Enabled = True
            Else
                Me.hypTargetMarketSegmentStrategy.Enabled = False
            End If
            daArray = Nothing


            'Market Growth 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 18 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =18")
            Trace.Write("Text  Modelid  = 65 ,18 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypMarketGrowth.Enabled = True
            Else
                Me.hypMarketGrowth.Enabled = False
            End If
            daArray = Nothing


            'Industry Analysis 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 19 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 19")
            Trace.Write("Text  Modelid  = 65 ,19:" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypindustry_analysis.Enabled = True
            Else
                Me.hypindustry_analysis.Enabled = False
            End If
            daArray = Nothing

            'Industry Participants 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 20 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 20")
            Trace.Write("Text  Modelid  = 65 ,20 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypIndustryParticipants.Enabled = True
            Else
                Me.hypIndustryParticipants.Enabled = False
            End If
            daArray = Nothing

            'Main Competitors
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 21 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 21")
            Trace.Write("Text  Modelid  = 65 ,21 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypmaincompetitors.Enabled = True
            Else
                Me.hypmaincompetitors.Enabled = False
            End If
            daArray = Nothing



            Trace.Write("MarketAnalysis start page")


        Catch ex As Exception
            Trace.Warn("CompanyProfile start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

    End Sub

End Class
