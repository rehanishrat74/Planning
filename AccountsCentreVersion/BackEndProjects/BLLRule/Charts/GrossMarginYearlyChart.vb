Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public Class GrossMarginYearlyChart
    Inherits ChartGenerator
    ' Gross Margin Array 
    Private gmValuesArray() As Object = New Object(4) {}

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
        wc.ChartTitle = "Gross Margin Yearly"
        wc.XAxisCaption = "Years "
        wc.YAxisCaption = currentPlan.Currency '"Rs."
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Gross Margin", categoriesArray, gmValuesArray)

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function


#End Region

#Region "Helper Methods"

    Private Sub SetChartValues(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        Dim dt As New IncomeStatement(connData, currentPlan)
        Array.Copy(dt.GetGrossMargin.ItemArray, 13, gmValuesArray, 0, 5)
    End Sub
#End Region
End Class