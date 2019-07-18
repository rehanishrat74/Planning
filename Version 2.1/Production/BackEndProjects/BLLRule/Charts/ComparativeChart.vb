Imports Owc11
Imports System.Drawing
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.Data
Imports System.IO
Imports System.web


Public Class ComparativeChart
    Inherits ChartGenerator

#Region "Private Variables "
    Private PCValuesArray()() As Object
    ' Potential Customer Names 
    Private PCNames() As Object
    Dim chartValue As String()      '// hold values that come from tracker page
#End Region

#Region "Interface Implementation "

    Public Overrides Function GenerateChart(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal chartFileName As String, ByVal chType As ChartChartTypeEnum) As String

        If (File.Exists(chartFileName)) Then
            File.Delete(chartFileName)
        End If

        If IsNothing(HttpContext.Current.Session("CompChartValues")) Then
            HttpContext.Current.Response.Redirect("/InfiniPlan/Services/Plan/Home.aspx")
        End If

        Dim categoriesArray() As Object = New Object(0) {}



        chartValue = CType(HttpContext.Current.Session("CompChartValues"), String())

        If chartValue(0) = "Annual Chart" Then
            categoriesArray(0) = "" 'chartValue(4) & " TO " & chartValue(6)         '// set the xaxis value

            ' Set the Chart Values 
            SetChartValuesYearly(connData, currentPlan)
        Else
            categoriesArray(0) = "" ' chartValue(3)
            ' Set the Chart Values 
            SetChartValuesMonthly(connData, currentPlan)
        End If

        If chartValue(8) = "Sales / Product" Then categoriesArray(0) = ""

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = chartValue(8)
        '  wc.XAxisCaption = "Years"
        If chartValue(8) = "Sales / Product" Then wc.XAxisCaption = HttpContext.Current.Session("productName").ToString
        wc.YAxisCaption = currentPlan.Currency '"Rs."
        wc.HasLegend = True
        wc.ChartType = chType

        Dim i As Integer = 0
        For i = 0 To PCValuesArray.Length - 1
            wc.AddSeries(CStr(PCNames(i)), categoriesArray, PCValuesArray(i))
        Next

        wc.SaveChart(chartFileName)
        Return chartFileName
    End Function
    Public Overrides Function GetChartXML(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String
        Dim categoriesArray() As Object = New Object(0) {}
        categoriesArray(0) = "First 12 Months"
        ' Set the Chart Values 
        SetChartValuesMonthly(connData, currentPlan)

        Dim Chspace As New OWC11.ChartSpace
        ' Make a Web Chart Object and Configure it 
        Dim wc As New BusinessChart(Chspace)
        wc.ChartSpaceTitle = "Business Plan"
        wc.ChartTitle = "Market Analysis"
        wc.XAxisCaption = "Years"
        wc.YAxisCaption = currentPlan.Currency ' "Rs."

        Dim i As Integer = 0
        For i = 0 To PCValuesArray.Length - 1
            wc.AddSeries(CStr(PCNames(i)), categoriesArray, PCValuesArray(i))
        Next

        Return wc.GetChartXML()

    End Function

#End Region

#Region "Helper Methods"

    Private Sub SetChartValuesMonthly(ByVal connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)

        Dim objPlan As Plan
        Dim _dt As BusinessTable
        Dim BPObjectPayroll As InfiniLogic.BusinessPlan.BLL.BusinessPlan

        Dim ds As DataSet = objPlan.GetMonthlyIncomeStatemnt(connData, currentPlan.PlanID, CInt(chartValue(1)), CType(currentPlan.SalesForecastType, Integer))
        Dim dsPro As DataSet = objPlan.GetMonthlyIncomeStatemntPro(connData, currentPlan.PlanID, chartValue(2))

        _dt = CType(BusinessTable.CreateMonthlyIOforPayroll(connData, currentPlan, "Expenses", CInt(chartValue(1))), BusinessTable)

        Dim actualTotal(0) As Integer
        Dim estimatedTotal(0) As Integer
        Dim ebitExpense(1) As Integer
        Dim ebitGrossProfit(1) As Integer


        If chartValue(5) = "Sales" Then

            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(0))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("TotalSales"))
        End If


        If chartValue(5) = "Cost of Sales" Then
            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(1))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("TotalCostofSales"))
        End If

        If chartValue(5) = "Gross Profit" Then
            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(0)) - CInt(dsPro.Tables(1).Rows(0).Item(1))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("GrossProfit"))
        End If

        If chartValue(5) = "Operating Expenses" Then
            actualTotal(0) = CInt(dsPro.Tables(4).Rows(0).Item("ExpenseValue"))
            actualTotal(0) += CInt(dsPro.Tables(5).Rows(0).Item("SalariesWagesValue"))

            estimatedTotal(0) = CInt(ds.Tables(3).Rows(0).Item("TotalExpenses"))
            estimatedTotal(0) += CInt(BPObjectPayroll.Payroll_Burden)
        End If

        If chartValue(5) = "EBIT" Then
            ebitGrossProfit(0) = CInt(dsPro.Tables(1).Rows(0).Item(0)) - CInt(dsPro.Tables(1).Rows(0).Item(1))
            ebitGrossProfit(1) = CInt(ds.Tables(1).Rows(0).Item("GrossProfit"))


            ebitExpense(0) = CInt(dsPro.Tables(4).Rows(0).Item("ExpenseValue"))
            ebitExpense(1) = CInt(ds.Tables(3).Rows(0).Item("TotalExpenses"))


            actualTotal(0) = ebitGrossProfit(0) - (ebitExpense(0) + CInt(dsPro.Tables(5).Rows(0).Item("SalariesWagesValue")))
            estimatedTotal(0) = ebitGrossProfit(1) - (ebitExpense(1) + CInt(BPObjectPayroll.Payroll_Burden))
        End If

        If chartValue(5) = "Sales / Product" Then
            If CType(HttpContext.Current.Session("ProductName"), String) = "" Then
                actualTotal(0) = 0
                estimatedTotal(0) = 0
            Else

                actualTotal(0) = GetActualSalesValue(CType(HttpContext.Current.Session("ProductName"), String), dsPro.Tables(0).DefaultView)

                estimatedTotal(0) = GetEstimatedSalesValue(CType(HttpContext.Current.Session("ProductName"), String), ds.Tables(0).DefaultView)
            End If
        End If

        PCValuesArray = New Object(1)() {}
        PCNames = New Object(1) {}

        PCValuesArray(0) = New Object(0) {}
        PCNames(0) = "Actual"

        PCValuesArray(1) = New Object(0) {}
        PCNames(1) = "Estamated"

        Array.Copy(actualTotal, 0, PCValuesArray(0), 0, 1)
        Array.Copy(estimatedTotal, 0, PCValuesArray(1), 0, 1)


    End Sub
    Private Sub SetChartValuesYearly(ByVal connData As ConnectionData, ByVal currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)

        Dim objPlan As Plan
        Dim _dt As BusinessTable
        Dim BPObjectPayroll As InfiniLogic.BusinessPlan.BLL.BusinessPlan

        Dim ds As DataSet = objPlan.GetAnnualIncomeStatemnt(connData, currentPlan.PlanID, CType(currentPlan.SalesForecastType, Integer))
        Dim dsPro As DataSet = objPlan.GetAnnualIncomeStatemntPro(connData, currentPlan.PlanID, chartValue(7))

        _dt = CType(BusinessTable.CreateAnnualIOforPayroll(connData, currentPlan, "Expenses"), BusinessTable)

        Dim actualTotal(0) As Integer
        Dim estimatedTotal(0) As Integer
        Dim ebitExpense(1) As Integer
        Dim ebitGrossProfit(1) As Integer


        If chartValue(5) = "Sales" Then
            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(0))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("Sales"))
        End If


        If chartValue(5) = "Cost of Sales" Then
            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(1))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("Cost"))
        End If

        If chartValue(5) = "Gross Profit" Then
            actualTotal(0) = CInt(dsPro.Tables(1).Rows(0).Item(0)) - CInt(dsPro.Tables(1).Rows(0).Item(1))

            estimatedTotal(0) = CInt(ds.Tables(1).Rows(0).Item("GP"))
        End If

        If chartValue(5) = "Operating Expenses" Then
            actualTotal(0) = CInt(dsPro.Tables(4).Rows(0).Item("ExpenseValue"))
            actualTotal(0) += CInt(dsPro.Tables(5).Rows(0).Item("SalariesWagesValue"))

            estimatedTotal(0) = CInt(ds.Tables(3).Rows(0).Item("TotalExpenses"))
            estimatedTotal(0) += CInt(BPObjectPayroll.Payroll_Burden)
        End If

        If chartValue(5) = "EBIT" Then
            ebitGrossProfit(0) = CInt(dsPro.Tables(1).Rows(0).Item(0)) - CInt(dsPro.Tables(1).Rows(0).Item(1))
            ebitGrossProfit(1) = CInt(ds.Tables(1).Rows(0).Item("GP"))

            ebitExpense(0) = CInt(dsPro.Tables(4).Rows(0).Item("ExpenseValue"))
            ebitExpense(1) = CInt(ds.Tables(3).Rows(0).Item("TotalExpenses"))

            actualTotal(0) = ebitGrossProfit(0) - (ebitExpense(0) + CInt(dsPro.Tables(5).Rows(0).Item(0)))
            estimatedTotal(0) = ebitGrossProfit(1) - (ebitExpense(1) + CInt(BPObjectPayroll.Payroll_Burden))
        End If

        If chartValue(5) = "Sales / Product" Then
            If CType(HttpContext.Current.Session("ProductName"), String) = "" Then
                actualTotal(0) = 0
                estimatedTotal(0) = 0
            Else
                actualTotal(0) = GetActualSalesValue(CType(HttpContext.Current.Session("ProductName"), String), dsPro.Tables(0).DefaultView)

                estimatedTotal(0) = GetYearlyEstimatedSalesValue(CType(HttpContext.Current.Session("ProductName"), String), ds.Tables(0).DefaultView)
            End If
        End If


        PCValuesArray = New Object(1)() {}
        PCNames = New Object(1) {}

        PCValuesArray(0) = New Object(0) {}
        PCNames(0) = "Actual"

        PCValuesArray(1) = New Object(0) {}
        PCNames(1) = "Estamated"

        Array.Copy(actualTotal, 0, PCValuesArray(0), 0, 1)
        Array.Copy(estimatedTotal, 0, PCValuesArray(1), 0, 1)


    End Sub
    Private Function GetEstimatedSalesValue(ByVal productName As String, ByVal dv As DataView) As Integer

        dv.RowFilter = "Product='" & productName & "'"
        If dv.Count > 0 Then
            Return CType(dv.Item(0).Item("Sales"), Integer)
        End If

        Return 0
    End Function
    Private Function GetYearlyEstimatedSalesValue(ByVal productName As String, ByVal dv As DataView) As Integer

        dv.RowFilter = "Productname='" & productName & "'"
        If dv.Count > 0 Then
            Return CType(dv.Item(0).Item("Sales"), Integer)
        End If

        Return 0
    End Function
    Private Function GetActualSalesValue(ByVal productName As String, ByVal dv As DataView) As Integer

        dv.RowFilter = "ProductName='" & productName & "'"
        If dv.Count > 0 Then
            Return CType(dv.Item(0).Item("Sales"), Integer)
        End If

        Return 0
    End Function
#End Region
End Class
