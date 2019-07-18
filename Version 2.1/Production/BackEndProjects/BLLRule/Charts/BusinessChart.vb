#Region "............Imports "
Imports Owc11
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.Common
Imports System.Reflection
#End Region

Public Class BusinessChart
    Implements IBusinessChart

#Region "Private Memebers "

    Private _chSpace As ChartSpace
    Private _objChart As ChChart

#End Region

#Region "Constructor "

    Public Sub New(ByVal chSp As ChartSpace)
        _chSpace = chSp
        _objChart = _chSpace.Charts.Add(0)
    End Sub

#End Region

#Region ".......................Interface Implementation "

#Region "Properties "

    Public ReadOnly Property GetChartSpace() As ChartSpace Implements IBusinessChart.GetChartSpace
        Get
            Return _chSpace
        End Get
    End Property

    Public ReadOnly Property GetChart() As ChChart Implements IBusinessChart.GetChart
        Get
            Return _objChart
        End Get
    End Property

    Public Property ChartType() As ChartChartTypeEnum Implements IBusinessChart.ChartType
        Get
            Return _objChart.Type
        End Get
        Set(ByVal Value As ChartChartTypeEnum)
            _objChart.Type = Value
        End Set
    End Property

    Public Property XAxisCaption() As String Implements IBusinessChart.XAxisCaption
        Get
            Return _objChart.Axes(0).Title.Caption
        End Get
        Set(ByVal Value As String)
            _objChart.Axes(0).HasTitle = True
            _objChart.Axes(0).Title.Caption = Value
        End Set
    End Property

    Public Property YAxisCaption() As String Implements IBusinessChart.YAxisCaption
        Get
            Return _objChart.Axes(1).Title.Caption
        End Get
        Set(ByVal Value As String)
            _objChart.Axes(1).HasTitle = True
            _objChart.Axes(1).Title.Caption = Value
        End Set
    End Property

    Public Property ChartTitle() As String Implements IBusinessChart.ChartTitle
        Get
            Return _objChart.Title.Caption
        End Get
        Set(ByVal Value As String)
            _objChart.HasTitle = True
            _objChart.Title.Caption = Value
            _objChart.Title.Font.Bold = True
            _objChart.Title.Font.Underline = UnderlineStyleEnum.owcUnderlineStyleSingle
        End Set
    End Property

    Public Property ChartSpaceTitle() As String Implements IBusinessChart.ChartSpaceTitle
        Get
            Return _chSpace.ChartSpaceTitle.Caption
        End Get
        Set(ByVal Value As String)

            _chSpace.HasChartSpaceTitle = True
            _chSpace.ChartSpaceTitle.Caption = Value
            _chSpace.ChartSpaceTitle.Font.Bold = True
            _chSpace.ChartSpaceTitle.Font.Underline = UnderlineStyleEnum.owcUnderlineStyleSingle
        End Set
    End Property

    Public Property HasLegend() As Boolean Implements IBusinessChart.HasLegend
        Get
            Return _objChart.HasLegend
        End Get
        Set(ByVal Value As Boolean)
            _objChart.HasLegend = Value
            _objChart.Legend.Position = ChartLegendPositionEnum.chLegendPositionBottom
        End Set
    End Property


#End Region

#Region "Methods "

    Public Sub AddSeries(ByVal seriesName As String, ByVal categories() As Object, ByVal values() As Object) Implements IBusinessChart.AddSeries
        Dim objSeries As ChSeries
        objSeries = _objChart.SeriesCollection.Add
        objSeries.SetData(ChartDimensionsEnum.chDimSeriesNames, OWC11.ChartSpecialDataSourcesEnum.chDataLiteral, seriesName)
        ' Set the Categories 
        objSeries.SetData(ChartDimensionsEnum.chDimCategories, OWC11.ChartSpecialDataSourcesEnum.chDataLiteral, categories)
        ' Set the Value Data
        objSeries.SetData(ChartDimensionsEnum.chDimValues, Owc11.ChartSpecialDataSourcesEnum.chDataLiteral, values)

    End Sub

    Public Sub SaveChart(ByVal chartFileName As String) Implements IBusinessChart.SaveChart
        _chSpace.ExportPicture(chartFileName, "GIF", 640, 480)
        _chSpace.GetPicture()
    End Sub

    Public Function GetChartXML() As String Implements IBusinessChart.GetChartXML
        Return _chSpace.XMLData
    End Function
#End Region

#End Region
    Public Shared ReadOnly Property GetMonths(ByVal CurrentPlan As BLL.BusinessPlan) As Object()
        Get
            Dim _months() As Object = New Object(11) {}
            Dim MonthNames As String() = [Enum].GetNames(GetType(BusinessPlanMonths))
            Dim i As Integer
            For i = 0 To MonthNames.Length - 1
                MonthNames(i) = BusinessTable.GetDisplayNameForColumnName(MonthNames(i), CurrentPlan)
            Next
            MonthNames.CopyTo(_months, 0)   ' New String() {"Home", "Plan Manager", "My Plans", "Preferences"}
            Return _months
        End Get
    End Property

    Public Shared ReadOnly Property GetYears(ByVal CurrentPlan As BLL.BusinessPlan) As Object()
        Get
            Dim _years() As Object = New Object(4) {}
            Dim YearNames As String() = [Enum].GetNames(GetType(BusinessPlanYears))
            'ReDim Preserve YearNames(YearNames.Length)
            'YearNames(YearNames.Length - 1) = "Year0"
            Dim i As Integer
            For i = 0 To YearNames.Length - 1
                YearNames(i) = BusinessTable.GetDisplayNameForColumnName(YearNames(i), CurrentPlan)
            Next
            YearNames.CopyTo(_years, 0)
            Return CType(_years, Object())
        End Get
    End Property
    Public Shared Function CreateChart(ByVal ConnData As ConnectionData, ByVal CurrPlan As BLL.BusinessPlan, ByVal ChartName As String, ByVal FileName As String) As BusinessChart
        Dim Chart As IChartGenerator
        Dim ChartType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + ChartName + "Chart")
        Chart = CType(Activator.CreateInstance(ChartType), IChartGenerator)
        Chart.GenerateChart(ConnData, CurrPlan, FileName, Chart.ChartType)
    End Function
End Class
