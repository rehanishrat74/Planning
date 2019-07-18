Imports Owc11
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.BLL

Public Interface IBusinessChart

    ' ReadOnly Properties 
    ReadOnly Property GetChartSpace() As ChartSpace
    ReadOnly Property GetChart() As ChChart

    ' Properties 
    Property ChartType() As ChartChartTypeEnum
    Property XAxisCaption() As String
    Property YAxisCaption() As String
    Property ChartTitle() As String
    Property ChartSpaceTitle() As String
    Property HasLegend() As Boolean

    ' Methods 
    Sub AddSeries(ByVal seriesName As String, ByVal categories() As Object, ByVal values() As Object)
    Sub SaveChart(ByVal chartFileName As String)
    Function GetChartXML() As String
End Interface
