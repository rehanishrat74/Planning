Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class ProfitMonthlyChart
    Inherits ChartGenerator

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim categoriesArray() As Object = BusinessChart.GetMonths(currentPlan)
        Dim valuesArray() As Object = GetProfitMonthly(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Profit Monthly "
        wc.XAxisCaption = "Months"
        wc.YAxisCaption = currentPlan.Currency ' "Rs."
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Profit", categoriesArray, valuesArray)

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
#End Region

#Region "Helper Methods"

    Private Function GetProfitMonthly(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Object()
        Dim dt As New IncomeStatement(connData, currentPlan)
        Dim NetIncome(11) As Object
        Array.Copy(dt.GetNetProfit2.ItemArray, 1, NetIncome, 0, 12)
        Return NetIncome
    End Function
#End Region
End Class
