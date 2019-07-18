Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Owc11

Public Interface IChartGenerator
    ReadOnly Property Caption() As String
    Property ChartType() As ChartChartTypeEnum
    Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String
    Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As String
    Function GetImage(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chType As ChartChartTypeEnum) As System.Drawing.Image
    Function GetImage(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As System.Drawing.Image
End Interface