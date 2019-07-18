Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class BenchmarkChart
    Inherits ChartGenerator

#Region "Private Variables "
    ' Sales Growth Values 
    Private _year0Array() As Object = New Object(3) {}
    ' Gross Margin Array 
    Private _year1Array() As Object = New Object(3) {}
    ' Accountsw Recievables Array 
    Private _year2Array() As Object = New Object(3) {}
    ' Operating Expenses
    Private _year3Array() As Object = New Object(3) {}

    Private _year4Array() As Object = New Object(3) {}
#End Region

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = New Object(3) {"Sales", "Gross", "OpEx", "AR Est."}
        'categoriesArray(0) = "Sales"
        'Array.Copy(BusinessChart.GetYears, 0, categoriesArray, 1, 4)
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Benchmark"
        wc.XAxisCaption = ""
        wc.YAxisCaption = currentPlan.Currency ' "Currency"
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Year0", categoriesArray, _year0Array)
        wc.AddSeries("Year1", categoriesArray, _year1Array)
        wc.AddSeries("Year2", categoriesArray, _year2Array)
        wc.AddSeries("Year3", categoriesArray, _year3Array)
        wc.AddSeries("Year4", categoriesArray, _year4Array)

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = New Object(3) {"Sales", "Gross", "OpEx", "AR Est."}
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Benchmark"
        wc.XAxisCaption = ""
        wc.YAxisCaption = currentPlan.Currency ' "Currency"

        wc.AddSeries("Year0", categoriesArray, _year0Array)
        wc.AddSeries("Year1", categoriesArray, _year1Array)
        wc.AddSeries("Year2", categoriesArray, _year2Array)
        wc.AddSeries("Year3", categoriesArray, _year3Array)
        wc.AddSeries("Year4", categoriesArray, _year4Array)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("Benchmark", "", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("Year0", "Year0")
        'ChartXML.AddSeries("Year1", "Year1")
        'ChartXML.AddSeries("Year2", "Year2")
        'ChartXML.AddSeries("Year3", "Year3")
        'ChartXML.AddSeries("Year4", "Year4")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("Year0", CSng(_year0Array(i)))
        '        ChartXML.AddValue("Year1", CSng(_year1Array(i)))
        '        ChartXML.AddValue("Year2", CSng(_year2Array(i)))
        '        ChartXML.AddValue("Year3", CSng(_year3Array(i)))
        '        ChartXML.AddValue("Year4", CSng(_year4Array(i)))
        '        ChartXML.EndCategory()
        '    End If
        'Next
        'ChartXML.EndData()
        'ChartXML.EndChart()
        'ChartXML.EndChartSpace()

        ''wc.ChartType = chType
        'Return ChartXML.XMLData
    End Function

    'Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

    '    If (File.Exists(chartFileName)) Then
    '        File.Delete(chartFileName)
    '    End If
    '    Dim categoriesArray() As Object = New Object(4) {}
    '    categoriesArray(0) = "First 12 Months"
    '    Array.Copy(BusinessChart.GetYears, 0, categoriesArray, 1, 4)
    '    ' Set the Chart Values 
    '    SetChartValues(connData, currentPlan)

    '    Dim Chspace As New OWC11.ChartSpace
    '    ' Make a Web Chart Object and Configure it 
    '    Dim wc As New BusinessChart(Chspace)
    '    wc.ChartSpaceTitle = "Business Plan"
    '    wc.ChartTitle = "BenchMark"
    '    wc.XAxisCaption = "Months "
    '    wc.YAxisCaption = "Rs."
    '    wc.HasLegend = True
    '    wc.ChartType = chType

    '    wc.AddSeries("Gross Margin", categoriesArray, GMValuesArray)
    '    wc.AddSeries("Sales Growth", categoriesArray, SGValuesArray)
    '    wc.AddSeries("Accounts Recievables", categoriesArray, ARValuesArray)
    '    wc.AddSeries("Operating Expenses", categoriesArray, OpExpValuesArray)

    '    wc.SaveChart(chartFileName)
    '    Return chartFileName
    'End Function


#End Region

#Region "Helper Methods"

    Private Sub SetChartValues(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        Dim RatiosTable As New Ratios(connData, currentPlan)
        Dim SalesGrowthRow As DataRow
        Dim GrossMarginRow As DataRow
        Dim OperatingExpensesRow As DataRow
        Dim AccountsReceivableRow As DataRow

        SalesGrowthRow = RatiosTable.GetSalesGrowth
        GrossMarginRow = RatiosTable.GetGrossMargin
        OperatingExpensesRow = RatiosTable.GetOperatingExpenses
        AccountsReceivableRow = RatiosTable.GetAccountsReceivable

        _year0Array(0) = 1
        _year0Array(1) = 1
        _year0Array(2) = 1
        _year0Array(3) = 1

        _year1Array(0) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(2)) / 100, Val2(SalesGrowthRow(2)) / Val2(SalesGrowthRow(1))))
        _year1Array(1) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(2)) / 100, Val2(GrossMarginRow(2)) / Val2(GrossMarginRow(1))))
        _year1Array(2) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(2)) / 100, Val2(OperatingExpensesRow(2)) / Val2(OperatingExpensesRow(1))))
        _year1Array(3) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(2)) / 100, Val2(AccountsReceivableRow(2)) / Val2(AccountsReceivableRow(1))))

        _year2Array(0) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(3)) / 100, Val2(SalesGrowthRow(3)) / Val2(SalesGrowthRow(1))))
        _year2Array(1) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(3)) / 100, Val2(GrossMarginRow(3)) / Val2(GrossMarginRow(1))))
        _year2Array(2) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(3)) / 100, Val2(OperatingExpensesRow(3)) / Val2(OperatingExpensesRow(1))))
        _year2Array(3) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(3)) / 100, Val2(AccountsReceivableRow(3)) / Val2(AccountsReceivableRow(1))))

        _year3Array(0) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(4)) / 100, Val2(SalesGrowthRow(4)) / Val2(SalesGrowthRow(1))))
        _year3Array(1) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(4)) / 100, Val2(GrossMarginRow(4)) / Val2(GrossMarginRow(1))))
        _year3Array(2) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(4)) / 100, Val2(OperatingExpensesRow(4)) / Val2(OperatingExpensesRow(1))))
        _year3Array(3) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(4)) / 100, Val2(AccountsReceivableRow(4)) / Val2(AccountsReceivableRow(1))))

        _year4Array(0) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(5)) / 100, Val2(SalesGrowthRow(5)) / Val2(SalesGrowthRow(1))))
        _year4Array(1) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(5)) / 100, Val2(GrossMarginRow(5)) / Val2(GrossMarginRow(1))))
        _year4Array(2) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(5)) / 100, Val2(OperatingExpensesRow(5)) / Val2(OperatingExpensesRow(1))))
        _year4Array(3) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(5)) / 100, Val2(AccountsReceivableRow(5)) / Val2(AccountsReceivableRow(1))))
    End Sub

    'Private Sub SetChartValues(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
    '    Dim RatiosTable As New Ratios(connData, currentPlan)
    '    Dim SalesGrowthRow As DataRow
    '    Dim GrossMarginRow As DataRow
    '    Dim OperatingExpensesRow As DataRow
    '    Dim AccountsReceivableRow As DataRow

    '    SalesGrowthRow = RatiosTable.GetSalesGrowth
    '    GrossMarginRow = RatiosTable.GetGrossMargin
    '    OperatingExpensesRow = RatiosTable.GetOperatingExpenses
    '    AccountsReceivableRow = RatiosTable.GetAccountsReceivable

    '    Dim SalesGrowth(5) As Single
    '    Dim GrossMargin(5) As Single
    '    Dim OpEx(5) As Single
    '    Dim AR(5) As Single

    '    SalesGrowth(0) = 1
    '    SalesGrowth(1) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(2)) / 100, Val2(SalesGrowthRow(2)) / Val2(SalesGrowthRow(1))))
    '    SalesGrowth(2) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(3)) / 100, Val2(SalesGrowthRow(3)) / Val2(SalesGrowthRow(1))))
    '    SalesGrowth(3) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(4)) / 100, Val2(SalesGrowthRow(4)) / Val2(SalesGrowthRow(1))))
    '    SalesGrowth(4) = CSng(IIf(Val2(SalesGrowthRow(1)) = 0, Val2(SalesGrowthRow(5)) / 100, Val2(SalesGrowthRow(5)) / Val2(SalesGrowthRow(1))))

    '    GrossMargin(0) = 1
    '    GrossMargin(1) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(2)) / 100, Val2(GrossMarginRow(2)) / Val2(GrossMarginRow(1))))
    '    GrossMargin(2) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(3)) / 100, Val2(GrossMarginRow(3)) / Val2(GrossMarginRow(1))))
    '    GrossMargin(3) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(4)) / 100, Val2(GrossMarginRow(4)) / Val2(GrossMarginRow(1))))
    '    GrossMargin(4) = CSng(IIf(Val2(GrossMarginRow(1)) = 0, Val2(GrossMarginRow(5)) / 100, Val2(GrossMarginRow(5)) / Val2(GrossMarginRow(1))))

    '    OpEx(0) = 1
    '    OpEx(1) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(2)) / 100, Val2(OperatingExpensesRow(2)) / Val2(OperatingExpensesRow(1))))
    '    OpEx(2) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(3)) / 100, Val2(OperatingExpensesRow(3)) / Val2(OperatingExpensesRow(1))))
    '    OpEx(3) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(4)) / 100, Val2(OperatingExpensesRow(4)) / Val2(OperatingExpensesRow(1))))
    '    OpEx(4) = CSng(IIf(Val2(OperatingExpensesRow(1)) = 0, Val2(OperatingExpensesRow(5)) / 100, Val2(OperatingExpensesRow(5)) / Val2(OperatingExpensesRow(1))))

    '    AR(0) = 1
    '    AR(1) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(2)) / 100, Val2(AccountsReceivableRow(2)) / Val2(AccountsReceivableRow(1))))
    '    AR(2) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(3)) / 100, Val2(AccountsReceivableRow(3)) / Val2(AccountsReceivableRow(1))))
    '    AR(3) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(4)) / 100, Val2(AccountsReceivableRow(4)) / Val2(AccountsReceivableRow(1))))
    '    AR(4) = CSng(IIf(Val2(AccountsReceivableRow(1)) = 0, Val2(AccountsReceivableRow(5)) / 100, Val2(AccountsReceivableRow(5)) / Val2(AccountsReceivableRow(1))))

    '    Array.Copy(GrossMargin, 0, GMValuesArray, 0, 5)
    '    Array.Copy(SalesGrowth, 0, SGValuesArray, 0, 5)
    '    Array.Copy(AR, 0, ARValuesArray, 0, 5)
    '    Array.Copy(OpEx, 0, OpExpValuesArray, 0, 5)
    'End Sub


    Private Function Val2(ByVal Str As Object) As Single
        Return CSng(Val(CStr(Str).TrimEnd(CChar("%"))))
    End Function
#End Region

    Public Sub New()
        ChartType = ChartChartTypeEnum.chChartTypeColumnClustered
    End Sub
End Class
