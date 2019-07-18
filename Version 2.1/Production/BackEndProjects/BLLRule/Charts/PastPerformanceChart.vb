Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class PastPerformanceChart
    Inherits ChartGenerator

    ' Performance Year Array 
    Private PYArray() As Object = New Object(0) {}
    ' Sales Array 
    Private salesArray() As Object = New Object(0) {}
    ' Gross Margin Array 
    Private GMArray() As Object = New Object(0) {}
    ' Operating Expenses Array 
    Private OpExpArray() As Object = New Object(0) {}


#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = {"Last year"}
        ' Set the Chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Past Performance"
        wc.XAxisCaption = ""
        wc.YAxisCaption = currentPlan.Currency ' "Currency"
        wc.HasLegend = True
        wc.ChartType = chType


        wc.AddSeries("Sales", categoriesArray, salesArray)
        wc.AddSeries("Gross Margin", categoriesArray, GMArray)
        wc.AddSeries("Operating Expenses", categoriesArray, OpExpArray)

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = {"Last year"}
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Past Performance"
        wc.XAxisCaption = ""
        wc.YAxisCaption = currentPlan.Currency ' "Currency"

        wc.AddSeries("Sales", categoriesArray, salesArray)
        wc.AddSeries("Gross Margin", categoriesArray, GMArray)
        wc.AddSeries("Operating Expenses", categoriesArray, OpExpArray)

        Return wc.GetChartXML()

        'Dim ChartXML As New ChartXMLGenerator
        'ChartXML.BeginChartSpace("Infini Biz Plan")
        'ChartXML.BeginChart("PastPerformance", "", "Currency", True)
        'ChartXML.BeginSeriesInfo()
        'ChartXML.AddSeries("Sales", "Sales")
        'ChartXML.AddSeries("GrossMargin", "Gross Margin")
        'ChartXML.AddSeries("OperatingExpenses", "Operating Expenses")
        'ChartXML.EndSeriesInfo()
        'ChartXML.BeginData()
        'Dim i As Integer
        'For i = 0 To categoriesArray.Length - 1
        '    If Not categoriesArray(i) Is Nothing Then
        '        ChartXML.BeginCategory(CStr(categoriesArray(i)))
        '        ChartXML.AddValue("Sales", CSng(salesArray(i)))
        '        ChartXML.AddValue("GrossMargin", CSng(GMArray(i)))
        '        ChartXML.AddValue("OperatingExpenses", CSng(OpExpArray(i)))
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
        Dim ppCell As PastPerformanceCell
        Dim StrName As String = PastPerformance.GetPastPerformanceYear(connData, currentPlan.PlanID)
        Dim ppDetails As ArrayList = PastPerformance.GetPastPerformanceDetails(connData, currentPlan.PlanID)
        For Each ppCell In ppDetails

            If (Trim(ppCell.AccountName) = ("Sales")) Then
                salesArray(0) = ppCell.PerformanceValue
            End If
            If (Trim(ppCell.AccountName) = ("Gross Margin")) Then
                GMArray(0) = ppCell.PerformanceValue
            End If
            If (Trim(ppCell.AccountName) = "Operating Expenses") Then
                OpExpArray(0) = ppCell.PerformanceValue
            End If
        Next
        PYArray(0) = StrName
    End Sub

#End Region

End Class
