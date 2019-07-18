Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class SalesYearlyChart
    Inherits ChartGenerator

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = BusinessChart.GetYears(currentPlan)
        Dim valuesArray() As Object = GetSalesYearly(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Sales Yearly "
        wc.XAxisCaption = "Years"
        wc.YAxisCaption = currentPlan.Currency '"Currency"
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Sales", categoriesArray, valuesArray)

        wc.SaveChart(chartFileName)

        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = BusinessChart.GetYears(currentPlan)
        Dim valuesArray() As Object = GetSalesYearly(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Sales Yearly "
        wc.XAxisCaption = "Years"
        wc.YAxisCaption = currentPlan.Currency ' "Currency"

        wc.AddSeries("Sales", categoriesArray, valuesArray)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("Sales Yearly", "Months", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("Sales", "Sales")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("Sales", CSng(valuesArray(i)))
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

    Private Function GetSalesYearly(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Object()
        Dim dt As New SalesForecast(connData, currentPlan)
        Dim sales(4) As Object
        Array.Copy(dt.GetTotalSales.ItemArray, 13, sales, 0, 5)
        Return sales
    End Function
#End Region
End Class
