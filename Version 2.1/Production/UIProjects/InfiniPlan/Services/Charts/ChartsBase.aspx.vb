Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common

Public Class ChartsBase
    Inherits BizPlanWebBase
    Implements IChartsBase

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

    'Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    'Put user code to initialize the page here
    'End Sub


    Public Overrides ReadOnly Property Navigator() As String()
        Get

            Dim _mainNavigator() As String = [Enum].GetNames(GetType(BusinessPlanChartType))  ' New String() {"Home", "Plan Manager", "My Plans", "Preferences"}
            If Not CurrentPlan.IsOngoing Then
                _mainNavigator(5) = "Startup"
            End If
            Return _mainNavigator
        End Get
    End Property

    Public Shared Function GetChartNameFromID(ByVal ChartID As Integer, ByVal CurrentPlan As BLL.BusinessPlan) As String
        Dim tmpArray() As String = [Enum].GetNames(GetType(BusinessPlanChartType))
        ' Check the Business Type and Add appropriate Links 
        If Not CurrentPlan.IsOngoing Then
            tmpArray(5) = "Startup"
        End If
        If ChartID >= 0 And ChartID < tmpArray.Length Then
            Return tmpArray(ChartID)
        Else
            Return tmpArray(0)
        End If
    End Function

    Public Shared Function GetChartID(ByVal ChartName As String) As Integer
        Select Case ChartName
            Case "Startup"
                Return 5
            Case "Benchmark"
                Return 0
            Case "BreakEvenAnalysis"
                Return 1
            Case "CashFlow"
                Return 2
            Case "Highlights"
                Return 3
            Case "MarketAnalysis"
                Return 4
            Case "PastPerformance"
                Return 5
            Case "ProfitMonthly"
                Return 6
            Case "ProfitYearly"
                Return 7
            Case "GrossMarginMonthly"
                Return 8
            Case "GrossMarginYearly"
                Return 9
            Case "SalesYearly"
                Return 10
            Case "SalesMonthly"
                Return 11
        End Select
        Return 0
    End Function



End Class
