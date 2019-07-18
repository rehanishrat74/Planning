Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class MarketAnalysisChart
    Inherits ChartGenerator

#Region "Private Variables "
    Private PCValuesArray()() As Object
    ' Potential Customer Names 
    Private PCNames() As Object
#End Region

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = New Object(4) {}
        Array.Copy(BusinessChart.GetYears(currentPlan), 0, categoriesArray, 0, 5)
        categoriesArray(0) = "First 12 Months"
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Market Analysis"
        wc.XAxisCaption = "Years"
        wc.YAxisCaption = currentPlan.Currency '"Rs."
        wc.HasLegend = True
        wc.ChartType = chType

        Dim i As Integer = 0
        For i = 0 To PCValuesArray.Length - 1
            wc.AddSeries(CStr(PCNames(i)), categoriesArray, PCValuesArray(i))
        Next

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = New Object(4) {}
        Array.Copy(BusinessChart.GetYears(currentPlan), 0, categoriesArray, 0, 5)
        categoriesArray(0) = "First 12 Months"
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Market Analysis"
        wc.XAxisCaption = "Years"
        wc.YAxisCaption = currentPlan.Currency ' "Rs."
        
        Dim i As Integer = 0
        For i = 0 To PCValuesArray.Length - 1
            wc.AddSeries(CStr(PCNames(i)), categoriesArray, PCValuesArray(i))
        Next

        Return wc.GetChartXML()

        'Dim i As Integer

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("Market Analysis", "Years", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'For i = 0 To PCValuesArray.Length - 1
        '    ChartXML.AddSeries(CStr(PCNames(i)).Replace(" ", ""), CStr(PCNames(i)))
        'Next
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'For i = 0 To categoriesArray.Length - 1
        '    ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '    Dim j As Integer
        '    For j = 0 To PCValuesArray.Length - 1
        '        ChartXML.AddValue(CStr(PCNames(j)).Replace(" ", ""), CSng(PCValuesArray(j)(i)))
        '    Next
        '    ChartXML.EndCategory()
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
        Dim dt As New MarketAnalysis(connData, currentPlan)
        PCValuesArray = New Object(dt.Rows.Count - 1)() {}
        PCNames = New Object(dt.Rows.Count - 1) {}
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In dt.Rows
            PCValuesArray(i) = New Object(5) {}
            PCNames(i) = dr(0)
            i += 1
        Next
        For i = 0 To PCValuesArray.Length - 1
            Array.Copy(dt.Rows(i).ItemArray, 2, PCValuesArray(i), 0, 5)
        Next
    End Sub

#End Region
End Class
