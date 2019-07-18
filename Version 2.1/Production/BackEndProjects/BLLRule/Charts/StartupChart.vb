Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO


Public Class StartupChart
    Inherits ChartGenerator

#Region ".................Private Members "

    Private expensesArray() As Object = New Object(0) {}
    Private assetsArray() As Object = New Object(0) {}
    Private investmentArray() As Object = New Object(0) {}
    Private loansArray() As Object = New Object(0) {}

#End Region

    Public Sub New()
        _Caption = "Startup Details"
    End Sub

#Region "....................Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String
        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If
        Dim catArray() As Object = New Object(0) {"Startup"}

        ' Set the chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New Owc11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Startup Details"
        wc.XAxisCaption = "Startup"
        wc.YAxisCaption = currentPlan.Currency '"$"
        wc.HasLegend = True
        wc.ChartType = chType

        wc.AddSeries("Expenses", New Object(0) {"Expenses"}, expensesArray)
        wc.AddSeries("Assets", New Object(0) {"Assets"}, assetsArray)
        wc.AddSeries("Investment", New Object(0) {"Investment"}, investmentArray)
        wc.AddSeries("Loans", New Object(0) {"Loans"}, loansArray)
        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function

    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim catArray() As Object = New Object(0) {"Startup"}

        ' Set the chart Values 
        SetChartValues(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Startup Details"
        wc.XAxisCaption = "Startup"
        wc.YAxisCaption = currentPlan.Currency ' "$"

        wc.AddSeries("Expenses", New Object(0) {"Expenses"}, expensesArray)
        wc.AddSeries("Assets", New Object(0) {"Assets"}, assetsArray)
        wc.AddSeries("Investment", New Object(0) {"Investment"}, investmentArray)
        wc.AddSeries("Loans", New Object(0) {"Loans"}, loansArray)

        Return wc.GetChartXML()
    End Function

#End Region

#Region "....................Helper Methods"


    Private Sub SetChartValues(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)

        Dim startupCategories As ArrayList = StartupDetails.GetStartupCategories(connData, currentPlan.PlanID)
        Dim startupCategory As startupCategory

        For Each startupCategory In startupCategories
            ' Add a blank Line
            If startupCategory.CategoryName = "Startup Expenses" Then
                expensesArray(0) = startupCategory.CategoryTotal
            End If
            If startupCategory.CategoryName = "Startup Assets Needed" Then
                assetsArray(0) = startupCategory.CategoryTotal
            End If
            If startupCategory.CategoryName = "Investment" Then
                investmentArray(0) = startupCategory.CategoryTotal
            End If
            If startupCategory.CategoryName = "Short Term Liabilities" Then
                loansArray(0) = startupCategory.CategoryTotal
            End If
            If startupCategory.CategoryName = "Long Term Liabilities" Then
                loansArray(0) = CDbl(loansArray(0)) + startupCategory.CategoryTotal
            End If
        Next

    End Sub

#End Region

End Class