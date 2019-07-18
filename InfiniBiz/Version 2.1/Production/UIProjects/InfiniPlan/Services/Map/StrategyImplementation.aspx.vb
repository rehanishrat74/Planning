
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class StrategyImplementation
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypSalesForecast As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSalesPrograms As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMilestone As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypStrategyImplementation As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypstrategy_pyramids As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSalesStrategy As System.Web.UI.WebControls.HyperLink
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
            Trace.Write("StrategyImplementation start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Strategy and Implementation Summary 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 22")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =22 ")
            Trace.Write("Text  Modelid  = 65 ,22 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypStrategyImplementation.Enabled = True
            Else
                Me.hypStrategyImplementation.Enabled = False
            End If
            daArray = Nothing


            'Strategy Pyramids 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 23")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =23 ")
            Trace.Write("Text  Modelid  = 65 ,23 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypstrategy_pyramids.Enabled = True
            Else
                Me.hypstrategy_pyramids.Enabled = False
            End If
            daArray = Nothing


            'Sales Strategy 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 25 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =25")
            Trace.Write("Text  Modelid  = 65 ,25 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypSalesStrategy.Enabled = True
            Else
                Me.hypSalesStrategy.Enabled = False
            End If
            daArray = Nothing


            'Sales Forecast  
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 26 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 26")
            Trace.Write("Text  Modelid  = 65 ,26 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypSalesForecast.Enabled = True
            Else
                Me.hypSalesForecast.Enabled = False
            End If
            daArray = Nothing

            'Sales Programs 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 27 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 27")
            Trace.Write("Text  Modelid  = 65 ,27 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypSalesPrograms.Enabled = True
            Else
                Me.hypSalesPrograms.Enabled = False
            End If
            daArray = Nothing


            'Milestones
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 28 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 28")
            Trace.Write("Text  Modelid  = 65 ,28 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypMilestone.Enabled = True
            Else
                Me.hypMilestone.Enabled = False
            End If
            daArray = Nothing



            Trace.Write("StrategyImplementation start page")


        Catch ex As Exception
            Trace.Warn("StrategyImplementation start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
    End Sub

End Class
