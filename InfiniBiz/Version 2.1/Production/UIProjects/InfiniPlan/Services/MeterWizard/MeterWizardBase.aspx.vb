Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web

Public Class MeterWizardBase
    Inherits BizPlanWebBase
    Implements IMeterWizardBase


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

    Public Overrides ReadOnly Property Navigator() As String()
        Get
            Dim _mainNavigator() As String = New String() {"Compose Meter", "Meter Listing"}

            Return _mainNavigator
        End Get
    End Property



End Class
