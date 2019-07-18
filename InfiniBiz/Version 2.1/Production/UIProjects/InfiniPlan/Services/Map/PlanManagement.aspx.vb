Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class PlanManagement
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array, daSelectArray As Array, daArrayChild As Array
    Protected WithEvents hypSelectPlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypClosePlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPlanWizard As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypSamplePlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypText As System.Web.UI.WebControls.HyperLink

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hypCreatePlan As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("PlanManagement start page")

            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            Create()
            SelectPlan()
            SamplePlan()

           
            Trace.Write("PlanManagement start page end ")
        Catch ex As Exception

            Trace.Warn("PlanManagment start page" + ex.Message)
        End Try
    End Sub

    Private Sub Create()
        'Create 
        Trace.Write("create  Modelid  = 59 ")
        daArray = dtUserRigths.Select("  Modelid  = 59 ")
        Trace.Write("create" + Str(daArray.Length))
        If daArray.Length > 0 Then
            hypCreatePlan.Enabled = True
        Else
            Me.hypCreatePlan.Enabled = False
        End If
        daArray = Nothing
    End Sub

    Private Sub SelectPlan()
        'Select
        Trace.Write("select  Modelid  = 61 ")
        daSelectArray = dtUserRigths.Select("  Modelid  = 61 ")
        Trace.Write("Select" + Str(daSelectArray.Length))
        If daSelectArray.Length > 0 Then
            Me.hypSelectPlan.Enabled = True
 
            'Close Plan
            Trace.Write("close  Modelid  = 148 ")
            daArray = dtUserRigths.Select("  Modelid  =148 ")
            Trace.Write("Close" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypClosePlan.Enabled = True
            Else
                Me.hypClosePlan.Enabled = False
            End If
            daArray = Nothing

            'Wizard
            Trace.Write("Wizard  Modelid  = 69 ")
            daArray = dtUserRigths.Select("  Modelid  =69 ")
            Trace.Write("wizard" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypPlanWizard.Enabled = True
            Else
                Me.hypPlanWizard.Enabled = False
            End If
            daArray = Nothing

            'Text
            Trace.Write("Text  Modelid  = 65 ")
            daArray = dtUserRigths.Select("  Modelid  =65 ")
            Trace.Write("Text" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypText.Enabled = True
                TextDetail()
            Else
                Me.hypText.Enabled = False
            End If
            daArray = Nothing

        Else
            Trace.Write("Select  Modelid=61 not found ")
            Me.hypSelectPlan.Enabled = False
            Me.hypClosePlan.Enabled = False
            Me.hypPlanWizard.Enabled = False
            Me.hypText.Enabled = False
        End If
        daSelectArray = Nothing
    End Sub

    Private Sub SamplePlan()

        Trace.Write("sample  Modelid  = 159")
        daArray = dtUserRigths.Select("  Modelid  = 159  ")
        Trace.Write("Sample Plan" + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypSamplePlan.Enabled = True
        Else
            Me.hypSamplePlan.Enabled = False
        End If
        daArray = Nothing
    End Sub


    Private Sub TextDetail()


    End Sub

End Class
