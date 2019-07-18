Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Public Class TextBase
    Inherits BizPlanWebBase
    Implements ITextBase
    'Inherits System.Web.UI.Page

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
    
    Protected _mainNavigator() As String

    Public Overrides ReadOnly Property Navigator() As String()
        Get
            '_mainNavigator = [Enum].GetNames(GetType(TablesNavigator)) ' New String() {"Home", "Plan Manager", "My Plans", "Preferences"}
            _mainNavigator = ChartNames()
            Return _mainNavigator
        End Get
    End Property

    Private Function ChartNames() As String()


        Dim tmpArr() As String = New String() {} '{"Chart A", "Chart B", "Chart C", "Chart D", "Chart E"}
        Return tmpArr
    End Function



End Class


