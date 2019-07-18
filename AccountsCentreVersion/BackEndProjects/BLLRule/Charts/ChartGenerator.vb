Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO

Public MustInherit Class ChartGenerator
    Implements IChartGenerator

    Protected _Caption As String
    ' NetCashFlow Values 
    Protected NCFvalArray() As Object = New Object(15) {}
    ' Cash Balance
    Protected CBvalArray() As Object = New Object(15) {}
    Public _ChartType As ChartChartTypeEnum
#Region "Interface Implementation "
    Public Property ChartType() As ChartChartTypeEnum Implements IChartGenerator.ChartType
        Get
            Return _ChartType
        End Get
        Set(ByVal Value As ChartChartTypeEnum)
            _ChartType = Value
        End Set
    End Property
    Public ReadOnly Property Caption() As String Implements IChartGenerator.Caption
        Get
            Return _Caption
        End Get
    End Property
    Public MustOverride Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String Implements IChartGenerator.GenerateChart
    Public Overridable Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As String Implements IChartGenerator.GetChartXML
        Return ""
    End Function
    Public Function GetImage(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal chType As ChartChartTypeEnum) As Image Implements IChartGenerator.GetImage
        Return Image.FromFile(GenerateChart(connData, currentPlan, "TempChart.bmp", ChartChartTypeEnum.chChartTypeColumn3D))
    End Function
    Public Function GetImage(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Image Implements IChartGenerator.GetImage
        Return Image.FromFile(GenerateChart(connData, currentPlan, "TempChart.bmp", ChartType))
    End Function
#End Region

    Public Sub New()
        ChartType = ChartChartTypeEnum.chChartTypeColumn3D
    End Sub
End Class