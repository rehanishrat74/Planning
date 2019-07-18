Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class CashFlowChart
    Inherits ChartGenerator

    Public Sub New()
        _Caption = "Cash Flow"
    End Sub

#Region "Interface Implementation "
    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String
        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim NCFcatArray() As Object = New Object(15) {}

        Array.Copy(BusinessChart.GetMonths(currentPlan), 0, NCFcatArray, 0, 12)
        'Array.Copy(BusinessChart.GetYears, 0, NCFcatArray, 12, 4)
        ' Set the chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = Caption
        wc.XAxisCaption = "Months"
        wc.YAxisCaption = currentPlan.Currency  '"Currency"
        wc.HasLegend = True
        wc.ChartType = chType
        wc.AddSeries("Net Cashflow", NCFcatArray, NCFvalArray)
        wc.AddSeries("Cash Balance", NCFcatArray, CBvalArray)
        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function

    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = New Object(15) {}

        Dim NCFcatArray() As Object = New Object(15) {}

        Array.Copy(BusinessChart.GetMonths(currentPlan), 0, NCFcatArray, 0, 12)
        ' Set the chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = Caption
        wc.XAxisCaption = "Months"
        wc.YAxisCaption = currentPlan.Currency ' "Currency"
        wc.AddSeries("Net Cashflow", NCFcatArray, NCFvalArray)
        wc.AddSeries("Cash Balance", NCFcatArray, CBvalArray)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("Cash Flow", "", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("NetCashFlow", "Net Cash Flow")
        'ChartXML.AddSeries("CashBalance", "Cash Balance")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("NetCashFlow", CSng(NCFvalArray(i)))
        '        ChartXML.AddValue("CashBalance", CSng(CBvalArray(i)))
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
        Dim NCFArray() As Object = New Object(11) {}
        Dim dt As New CashFlow(connData, currentPlan)
        If Not currentPlan.BusinessGoods = BLL.BusinessGoodsType.Services Then
            Array.Copy(dt.GetNetCashFlow.ItemArray, 1, NCFvalArray, 0, 15)
            Array.Copy(dt.GetCashBalance.ItemArray, 1, CBvalArray, 0, 15)
        Else
            Array.Copy(dt.GetNetCashFlow.ItemArray, 1, NCFvalArray, 0, 15)
            Array.Copy(dt.GetCashBalance.ItemArray, 1, CBvalArray, 0, 15)
        End If

    End Sub

#End Region
End Class