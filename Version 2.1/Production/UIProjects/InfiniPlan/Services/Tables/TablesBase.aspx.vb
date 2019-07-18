Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web

Public Class TablesBase
    Inherits BizPlanWebBase
    Implements ITablesBase

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
            Dim tmpArray() As String = [Enum].GetNames(GetType(BusinessPlanTableType))
            ' Check the Business Type and Add appropriate Links 
            Dim tmpArray2() As String
            If CurrentPlan.IsOngoing Then
                tmpArray2 = [Enum].GetNames(GetType(OngoingTableType))
            Else
                tmpArray2 = [Enum].GetNames(GetType(StartupTableType))
            End If
            'Dim mainNavigator() As String = New String((tmpArray.Length + tmpArray2.Length) - 1) {}
            Dim mainNavigator() As String = New String((tmpArray2.Length - 1)) {}
            'Array.Copy(tmpArray, mainNavigator, tmpArray.Length)
            'Array.Copy(tmpArray2, 0, mainNavigator, tmpArray.Length, tmpArray2.Length)
            Array.Copy(tmpArray2, mainNavigator, tmpArray2.Length)
            CurrentNavigator = mainNavigator
            Return CurrentNavigator
        End Get
    End Property
    Public Shared Function GetTableNameFromID(ByVal TableID As Integer, ByVal CurrentPlan As BLL.BusinessPlan) As String
        Dim CurrentNavigator() As String
        Dim tmpArray() As String = [Enum].GetNames(GetType(BusinessPlanTableType))
        ' Check the Business Type and Add appropriate Links 
        Dim tmpArray2() As String
        If CurrentPlan.IsOngoing Then
            tmpArray2 = [Enum].GetNames(GetType(OngoingTableType))
        Else
            tmpArray2 = [Enum].GetNames(GetType(StartupTableType))
        End If
        'Dim mainNavigator() As String = New String((tmpArray.Length + tmpArray2.Length) - 1) {}
        Dim mainNavigator() As String = New String((tmpArray2.Length)) {}
        'Array.Copy(tmpArray, mainNavigator, tmpArray.Length)
        'Array.Copy(tmpArray2, 0, mainNavigator, tmpArray.Length, tmpArray2.Length)
        Array.Copy(tmpArray2, mainNavigator, tmpArray2.Length)
        CurrentNavigator = mainNavigator

        If TableID >= 0 And TableID < CurrentNavigator.Length Then
            Return CurrentNavigator(TableID)
        Else
            Return CurrentNavigator(0)
        End If
    End Function
    Public Shared Function GetTableID(ByVal TableName As String) As Integer

        Select Case TableName
            Case "GeneralAssumption"
                Return 0
            Case "BreakEvenAnalysis"
                Return 2
            Case "MarketAnalysis"
                Return 3
            Case "Payroll"
                Return 4
            Case "SalesForecast"
                Return 5
            Case "Milestones"
                Return 6
            Case "IncomeStatement"
                Return 7
            Case "CashFlow"
                Return 8
            Case "BalanceSheet"
                Return 9
            Case "RatiosAnalysis"
                Return 10
            Case "PastPerformance"
                Return 1
            Case "StartupDetails"
                Return 1
        End Select
        Return 0

    End Function
End Class



