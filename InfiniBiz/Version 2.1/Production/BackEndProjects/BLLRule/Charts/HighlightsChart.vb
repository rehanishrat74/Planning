Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO
Public Class HighlightsChart
    Inherits ChartGenerator

#Region "Private Members"
    ' Gross Margin Array 
    Private gmValuesArray() As Object = New Object(4) {}
    ' Sales Array 
    Private saleValuesArray() As Object = New Object(4) {}
#End Region

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = BusinessChart.GetYears(currentPlan)
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Highlights "
        wc.XAxisCaption = "Months "
        wc.YAxisCaption = currentPlan.Currency '"Currency"
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Gross Margin", categoriesArray, gmValuesArray)
        wc.AddSeries("Sales", categoriesArray, saleValuesArray)

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = BusinessChart.GetYears(currentPlan)
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Highlights "
        wc.XAxisCaption = "Months "
        wc.YAxisCaption = currentPlan.Currency '"Currency"

        wc.AddSeries("Gross Margin", categoriesArray, gmValuesArray)
        wc.AddSeries("Sales", categoriesArray, saleValuesArray)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("Highlights", "Months", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("Sales", "Sales")
        'ChartXML.AddSeries("GrossMargin", "Gross Margin")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("Sales", CSng(saleValuesArray(i)))
        '        ChartXML.AddValue("GrossMargin", CSng(gmValuesArray(i)))
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

    Private Sub SetChartValues(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        Dim dt As New IncomeStatement(connData, currentPlan)
        Dim sf As New SalesForecast(connData, currentPlan)
        Array.Copy(sf.GetTotalSales.ItemArray, 13, saleValuesArray, 0, 5)
        Array.Copy(dt.GetGrossMargin.ItemArray, 13, gmValuesArray, 0, 5)
    End Sub
#End Region
End Class
