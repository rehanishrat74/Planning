Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class BreakEvenAnalysisChart
    Inherits ChartGenerator

#Region "Private Variables "
    ' Break Even Values 
    Private BEArray() As Object = New Object(2) {}

#End Region

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String
        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        categoriesArray = BEArray

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "BreakEven Analysis"
        wc.XAxisCaption = "Monthly Units Break-Even "
        wc.YAxisCaption = currentPlan.Currency '"Currency"
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Break Even", categoriesArray, BEArray)
        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)
        categoriesArray = BEArray
        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "BreakEven Analysis"
        wc.XAxisCaption = "Monthly Units Break-Even "
        wc.YAxisCaption = currentPlan.Currency '"Currency"

        wc.AddSeries("Break Even", categoriesArray, BEArray)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("BreakEven Analysis", "Monthly Units Break-Even", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("Sales", "Sales")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("Sales", CSng(BEArray(i)))
        '        ChartXML.EndCategory()
        '    End If
        'Next
        'ChartXML.EndData()
        'ChartXML.EndChart()
        'ChartXML.EndChartSpace()

        ''wc.ChartType = chType
        'Return ChartXML.XMLData
    End Function
#End Region

#Region "Helper Methods"

    Private Sub SetChartValues(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        Dim BreakEven As BreakEvenValues
        Dim MonthlyUnit As Single
        Dim MonthlySales As Single
        BreakEven = BreakEvenAnalysis.GetBreakEvenObj(connData, currentPlan.PlanID)
        MonthlyUnit = -1 * BreakEven.EstMonthlyFixCost '/ (BreakEven.APURevenue - BreakEven.APUVariableCost)
        If (BreakEven.APURevenue = 0) Then
            MonthlySales = 0
        Else
            MonthlySales = BreakEven.EstMonthlyFixCost / (1 - (BreakEven.APUVariableCost / BreakEven.APURevenue))
        End If
        BEArray(0) = MonthlyUnit
        'BEArray(1) = 0
        'BEArray(2) = 0
        BEArray(2) = MonthlySales
    End Sub

#End Region

    Public Sub New()
        ChartType = ChartChartTypeEnum.chChartTypeLine
    End Sub
End Class

