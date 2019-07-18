
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web

Public Class PlanBase
    Inherits BizPlanWebBase
    Implements IPlanBase
    Public State As Boolean
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

#Region "Plan Navigator"

    Public Overrides ReadOnly Property Navigator() As String()
        Get
            'Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan Wizard", "Close Plan"}
            ' Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan OutLine", "Plan Wizard", "Close Plan"}
            State = GetProWebCustomer()
            If State = True Then
                Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan OutLine", "Plan Wizard", "Business Tracker", "MeterWizard", "Close Plan"}
                ' Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan OutLine", "Plan Wizard", "Business Tracker", "Close Plan"}

                Return mainNavigator
            Else
                Dim mainNavigator() As String = New String() {"Home", "Texts", "Tables", "Charts", "Plan Preview", "Export Plan", "Plan OutLine", "Plan Wizard", "Close Plan"}
                Return mainNavigator
            End If

        End Get
    End Property

#End Region


End Class
