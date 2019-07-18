Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class meters
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents hypComposeMeter As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypMeterListing As System.Web.UI.WebControls.HyperLink
    Dim daArray As Array, daArrayChild As Array, daSelectArray As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hypSpeedoMeters As System.Web.UI.WebControls.HyperLink
    Protected WithEvents pnlMeter As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMeterWizard As System.Web.UI.WebControls.Panel
    Protected WithEvents ibtnPrintDetail As System.Web.UI.WebControls.ImageButton
    Protected WithEvents iBtnMeterWizard As System.Web.UI.WebControls.ImageButton

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

            Trace.Write("meters start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            MeterWizard()
            Speedoemeter()
 
            Trace.Write("meters end page")
        Catch ex As Exception
            Trace.Warn("meters start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
    End Sub

    Private Sub MeterWizard()
        'Select
        Trace.Write("Select  Modelid  = 61 ")
        daSelectArray = dtUserRigths.Select("  Modelid  = 61 ")
        Trace.Write("Select" + Str(daSelectArray.Length))
        If daSelectArray.Length > 0 Then
            Me.iBtnMeterWizard.Enabled = True
            'meter wizard
            Trace.Write(" meter wizard  Modelid  = 144 ")
            daArray = dtUserRigths.Select("  Modelid  = 144 ")
            Trace.Write("Meter Wizard  " + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.iBtnMeterWizard.Enabled = True
                MeterWizardOptions()
            Else
                Me.iBtnMeterWizard.Enabled = False
            End If
            daArray = Nothing
        Else
            Me.iBtnMeterWizard.Enabled = False
        End If
        daSelectArray = Nothing
    End Sub

    Private Sub MeterWizardOptions()
        'Compose Meters
        Trace.Write("meter wizard option id = 1 ")
        daArrayChild = dtUserRigths.Select("  Modelid  = 144 and modeloptionid=1 ")
        Trace.Write("meter wizard option id = 1" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypComposeMeter.Enabled = True
        Else
            Me.hypComposeMeter.Enabled = False
        End If
        daArrayChild = Nothing

        ' Meters Listing
        Trace.Write("meter wizard option id = 2")
        daArrayChild = dtUserRigths.Select("  Modelid  = 144 and modeloptionid=2 ")
        Trace.Write("meter wizard option id = 2" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypMeterListing.Enabled = True
        Else
            Me.hypMeterListing.Enabled = False
        End If
        daArrayChild = Nothing
    End Sub

    Private Sub Speedoemeter()
        'Spdo Manager
        Trace.Write("speedoemter manager 63")
        daArray = dtUserRigths.Select("  Modelid  = 63 ")
        Trace.Write("speedoemter manager" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypSpeedoMeters.Enabled = True
        Else
            Me.hypSpeedoMeters.Enabled = False

        End If
        daArray = Nothing
    End Sub

    Private Sub iBtnMeterWizard_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles iBtnMeterWizard.Click
        Try

            If CurrentPlan.PlanID = Nothing Then
                Response.Redirect("../Plan/PlanManager.aspx")
            End If

            Trace.Write("meters end page")
        Catch ex As Exception
            Trace.Warn("meters start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

        Me.pnlMeter.Visible = False
        Me.pnlMeterWizard.Visible = True
    End Sub
 
    Private Sub pnlMeter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlMeter.Load
        '  Meters
        Trace.Write("meter wizard option id = 1 ")
        daArrayChild = dtUserRigths.Select("  Modelid  = 144 and (modeloptionid=1 or modeloptionid=2) ")
        Trace.Write("meter wizard option id = 1" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.pnlMeterWizard.Enabled = True
        Else
            Me.pnlMeterWizard.Enabled = False
        End If
        daArrayChild = Nothing

     
    End Sub
End Class
