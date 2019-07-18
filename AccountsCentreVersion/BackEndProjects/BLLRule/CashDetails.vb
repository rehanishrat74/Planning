Option Strict On  ' Block Implicit Conversions
Option Explicit On  ' Block Undeclared Variable Usage

#Region "Imports  "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient

#End Region

Public Class CashDetails
    Inherits BusinessTable

    Private IncomeStatementTable As IncomeStatement
    Private SalesForecastTable As SalesForecast
    Private GATable As GeneralAssumption
    Private TempT As SupportTable
    Private PayrollTable As Payroll

    Private AccountsReceivable As DataRow
    Private ShortTermBorrowings As DataRow
    Private LongTermBorrowings As DataRow
    Private TaxesIncured As DataRow
    Private CostOfUnitSales As DataRow
    Private ShortTermInterestExpense As DataRow
    Private LongTermInterestExpense As DataRow
    Private PaymentDaysRow As DataRow
    Private OtherPayroll As DataRow
    Private TotalSales As DataRow
    Private CashBalance As DataRow
    Private Dividends As DataRow
    Private CapitalExpenditure As DataRow
    Private ChangeInOtherSTAsset As DataRow
    Private NetProfit As DataRow
    Private ProductionPayroll As DataRow
    Private SalesAndMarketingPayroll As DataRow
    Private GeneralAndAdministrativePayroll As DataRow
    Private TotalPayroll As DataRow
    Private OperatingExpense As DataRow
    Private Inventory As DataRow
    Private ExpensesPaidInCash As DataRow
    Private Depreciation As DataRow
    Private PayrollBurden As DataRow

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Dim CashFlowTable As New CashFlow(connData, currentPlan)
        Me.ChangeInOtherSTAsset = CashFlowTable.GetChangeInOtherSTAssets
        Me.CapitalExpenditure = CashFlowTable.GetCapitalExpenditure

        TempT = New SupportTable(connData, currentPlan)
        IncomeStatementTable = TempT.GetIncomeStatementTable 'New IncomeStatement(connData, currentPlan, GATable, SalesForecastTable)
        SalesForecastTable = TempT.GetSalesForecastTable
        GATable = TempT.GetGeneralAssumptionsTable
        PayrollTable = IncomeStatementTable.GetPayroll

        ShortTermInterestExpense = IncomeStatementTable.GetShortTermInterestExpense
        LongTermInterestExpense = IncomeStatementTable.GetLongTermInterestExpense
        TaxesIncured = IncomeStatementTable.GetTaxesIncured
        OperatingExpense = IncomeStatementTable.GetTotalOperatingExpense
        Depreciation = IncomeStatementTable.GetDepreciation
        PayrollBurden = PayrollTable.GetPayrollBurden

        'Commented and new lines added by Afaq on Jan 26, 2006
        'TotalSales = SalesForecastTable.GetTotalSales()
        'CostOfUnitSales = SalesForecastTable.GetCostOfUnitSales
        TotalSales = IncomeStatementTable.GetCostOfSales()
        CostOfUnitSales = IncomeStatementTable.GetCostOfUnitSales()

        AccountsReceivable = TempT.GetAccountsRecieveable
        Inventory = TempT.GetInventory

        PaymentDaysRow = GATable.GetPaymentDays
        ExpensesPaidInCash = GATable.GetExpensesInCash

        TotalPayroll = PayrollTable.GetTotalPayrollExpense
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OtherPayroll = PayrollTable.GetOtherPayroll
        ProductionPayroll = PayrollTable.GetProductionPayroll()


        Me.TableName = "CashDetails"
        Caption = "Cash Details"

        AddHeadings()

        Dim command As New InfiniCommand("BPL_GetBorrowingDetails")
        command.AddParameter("@PlanID", currentPlan.PlanID)

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        ShortTermBorrowings = ds.Tables(0).Rows(0)
        LongTermBorrowings = ds.Tables(0).Rows(1)
        ChangeInOtherSTAsset = ds.Tables(0).Rows(2)

        PopulateDataTable(currentPlan)

        PostProcess()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal ChangeInOtherSTAsset As DataRow, ByVal CapitalExpenditure As DataRow)
        MyBase.New(connData, currentPlan)

        Me.ChangeInOtherSTAsset = ChangeInOtherSTAsset
        Me.CapitalExpenditure = CapitalExpenditure

        TempT = New SupportTable(connData, currentPlan)
        IncomeStatementTable = TempT.GetIncomeStatementTable 'New IncomeStatement(connData, currentPlan, GATable, SalesForecastTable)
        SalesForecastTable = TempT.GetSalesForecastTable
        GATable = TempT.GetGeneralAssumptionsTable
        PayrollTable = IncomeStatementTable.GetPayroll

        ShortTermInterestExpense = IncomeStatementTable.GetShortTermInterestExpense
        LongTermInterestExpense = IncomeStatementTable.GetLongTermInterestExpense
        TaxesIncured = IncomeStatementTable.GetTaxesIncured
        OperatingExpense = IncomeStatementTable.GetTotalOperatingExpense
        Depreciation = IncomeStatementTable.GetDepreciation
        PayrollBurden = PayrollTable.GetPayrollBurden

        'Commented and new lines added by Afaq on Jan 26, 2006
        'TotalSales = SalesForecastTable.GetTotalSales()
        'CostOfUnitSales = SalesForecastTable.GetCostOfUnitSales
        TotalSales = IncomeStatementTable.GetCostOfSales()
        CostOfUnitSales = IncomeStatementTable.GetCostOfUnitSales()

        AccountsReceivable = TempT.GetAccountsRecieveable
        Inventory = TempT.GetInventory

        PaymentDaysRow = GATable.GetPaymentDays
        ExpensesPaidInCash = GATable.GetExpensesInCash

        TotalPayroll = PayrollTable.GetTotalPayrollExpense
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OtherPayroll = PayrollTable.GetOtherPayroll
        ProductionPayroll = PayrollTable.GetProductionPayroll()

        Me.TableName = "CashDetails"
        Caption = "Cash Details"

        AddHeadings()

        Dim command As New InfiniCommand("BPL_GetBorrowingDetails")
        command.AddParameter("@PlanID", currentPlan.PlanID)

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        ShortTermBorrowings = ds.Tables(0).Rows(0)
        LongTermBorrowings = ds.Tables(0).Rows(1)
        ChangeInOtherSTAsset = ds.Tables(0).Rows(2)
PopulateDataTable(currentPlan)

        PostProcess()
    End Sub
#End Region
    Public Function GetIncomeStatement() As IncomeStatement
        Return IncomeStatementTable
    End Function
    Public Function GetSupportTable() As SupportTable
        Return TempT
    End Function
#Region "Private Methods"
    Public Function GetShortTermBorrowings() As DataRow
        Return Rows(0)
    End Function
    Public Function GetShortTermNotes() As DataRow
        Return Rows(1)
    End Function
    Public Function GetLongTermBorrowings() As DataRow
        Return Rows(2)
    End Function
    Public Function GetLongTermLiabilities() As DataRow
        Return Rows(3)
    End Function
    Public Function GetAccountsPayable() As DataRow
        Return Rows(GetRowNumber("New balance"))
    End Function
    Private Function PopulateDataTable(ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataTable
        AddNewRow("Calculating new accounts payable", currentPlan.Currency)
        AddNewRow("-Operating Expenses", currentPlan.Currency)
        AddNewRow("-Less non-payable operating expenses", currentPlan.Currency)
        AddNewRow("--Payroll in operating expenses", currentPlan.Currency)
        AddNewRow("--Depreciation", currentPlan.Currency)
        AddNewRow("--Subtotal", currentPlan.Currency)
        AddNewRow("-Plus additional payables", currentPlan.Currency)
        AddNewRow("--Taxes Incured", currentPlan.Currency)
        AddNewRow("--Inventory purchase", currentPlan.Currency)
        AddNewRow("--Interest expense", currentPlan.Currency)
        AddNewRow("--Purchased assets, if they are positive", currentPlan.Currency)
        AddNewRow("--Other costs of Sales", currentPlan.Currency)
        AddNewRow("--Subtotal", currentPlan.Currency)
        AddNewRow("-Amount paid immediately", currentPlan.Currency)
        AddNewRow("-Remainder (new accounts payable)", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Payment Details", currentPlan.Currency)
        AddNewRow("-Payment Days", currentPlan.Currency)
        AddNewRow("-This month", currentPlan.Currency)
        AddNewRow("-From previous", currentPlan.Currency)
        AddNewRow("-Left from two months back", currentPlan.Currency)
        AddNewRow("-Left from three months back", currentPlan.Currency)
        AddNewRow("-Left from four months back", currentPlan.Currency)
        AddNewRow("-Left from five months back", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Handling Accounts Payable", currentPlan.Currency)
        AddNewRow("-Previous balance", currentPlan.Currency)
        AddNewRow("-New Accounts Payable", currentPlan.Currency)
        AddNewRow("--Payment on this months payables", currentPlan.Currency)
        AddNewRow("--Payments on previous balance", currentPlan.Currency)
        AddNewRow("-New balance", currentPlan.Currency)
        AddNewRow("--Payroll Burden", currentPlan.Currency)

        AddExpressionToRow("OperatingExpense(Column[])", 1)

        If _currentPlan.DisplayExpense = True Then
            AddExpressionToRow("-1*(SalesAndMarketingPayroll(Column[])+GeneralAndAdministrativePayroll(Column[])+OtherPayroll(Column[]))", 3)
        Else
            AddExpressionToRow("-1*TotalPayroll(Column[])", 3)
        End If
        AddExpressionToRow("-1*Depreciation(Column[])", 4)
        AddExpressionToRow("(R1+R3+R4)-R{#'Payroll Burden'}", 5)
        'AddExpressionToRow("R1+R3+R4", 5)

        'Taxes Incured
        AddExpressionToRow("TaxesIncured(Column[])", 7)

        'PayrollBurden
        AddExpressionToRow("PayrollBurden(Column[])", GetRowNumber("Payroll Burden"))

        'Inventory purchased
        AddExpressionToRow("(Inventory(Column[])-Inventory(Column[]-1))+CostOfUnitSales(Column[])", 8)
        AddExpressionToCell("(Inventory(Column[])-StartingInventory())+CostOfUnitSales(Column[])", 8, 1)
        AddExpressionToCell("Sum([C1:C12])", 8, 13)

        AddExpressionToRow("ShortTermInterestExpense(Column[])+LongTermInterestExpense(Column[])", 9) ' Interest Expense

        'Purchased Assets
        AddExpressionToRow("Max(CapitalExpense(Column[]),0)+Max(ChangeInOtherSTAsset(Column[]),0)", 10)
        AddExpressionToCell("Sum([C1:C12])", 10, 13)

        AddExpressionToRow("TotalSales(Column[])-(CostOfUnitSales(Column[])+ProductionPayroll(Column[]))", 11) 'Other Costs of Sales
        AddExpressionToRow("R5+Sum([R7:R[-1]])", 12) 'Sub-total
        AddExpressionToRow("R5+R7+R8+R10", 12, 13, 17)
        AddExpressionToRow("(R[-1]*ExpensesPaidInCash(Column[]))/100", 13) 'Amount paid immediately
        AddExpressionToCell("Sum([C1:C12])", 13, 13)

        'New Accounts Payable
        AddExpressionToRow("R[-2]-R[-1]", 14, 1, 12)
        AddExpressionToCell("Sum([C1:C12])", 14, 13)
        AddExpressionToRow("R[-2]-R26", 14, 14, 17)

        Dim PaymentDays As Integer
        AddExpressionToRow("PaymentDays(Column[])", 17)  ' Payment Days
        Dim i As Integer
        For i = 1 To 17
            PaymentDays = CInt(PaymentDaysRow(i))
            'This month
            If PaymentDays > 0 And PaymentDays < 31 Then
                AddExpressionToCell("(31-PaymentDays(Column[]))/30", 18, i)
            Else
                AddExpressionToCell("0", 18, i)

            End If

            'From previous month
            If PaymentDays > 0 And PaymentDays < 31 Then
                AddExpressionToCell("1-R[-1]", 19, i)
            Else
                If PaymentDays > 30 And PaymentDays < 61 Then
                    AddExpressionToCell("(61-PaymentDays(Column[]))/30", 19, i)
                Else
                    AddExpressionToCell("0", 19, i)
                End If
            End If

            'Left from two months back
            If PaymentDays > 30 And PaymentDays < 61 Then
                AddExpressionToCell("1-R[-1]", 20, i)
            Else
                If PaymentDays > 60 And PaymentDays < 91 Then
                    AddExpressionToCell("(91-PaymentDays(Column[]))/30", 20, i)
                Else
                    AddExpressionToCell("0", 20, i)
                End If
            End If

            'Left from three months back
            If PaymentDays > 60 And PaymentDays < 91 Then
                AddExpressionToCell("1-R[-1]", 21, i)
            Else
                If PaymentDays > 90 And PaymentDays < 121 Then
                    AddExpressionToCell("(121-PaymentDays(Column[]))/30", 21, i)
                Else
                    AddExpressionToCell("0", 21, i)
                End If
            End If

            'Left from four months back
            If PaymentDays > 90 And PaymentDays < 121 Then
                AddExpressionToCell("1-R[-1]", 22, i)
            Else
                If PaymentDays > 120 And PaymentDays < 151 Then
                    AddExpressionToCell("(151-PaymentDays(Column[]))/30", 22, i)
                Else
                    AddExpressionToCell("0", 22, i)
                End If
            End If

            'Left from five months back
            If PaymentDays > 120 And PaymentDays < 151 Then
                AddExpressionToCell("1-R[-1]", 23, i)
            Else
                If PaymentDays > 150 And PaymentDays < 181 Then
                    AddExpressionToCell("(181-PaymentDays(Column[]))/30", 23, i)
                Else
                    AddExpressionToCell("0", 23, i)
                End If
            End If
        Next

        ' Previous balance
        AddExpressionToRow("R[4]C[-1]", 26)
        AddExpressionToCell("PastAccountsPayable()", 26, 1)
        AddExpressionToCell("PastAccountsPayable()", 26, 13)

        ' New Accounts Payable
        AddExpressionToRow("R14", 27)

        ' Payments on this months payable
        AddExpressionToRow("Max(R18*R[-1]*-1,R[-1]*-1)", 28, 1, 12)
        AddExpressionToCell("Sum([C1:C12])", 28, 13)

        ' Payments on previous months payable
        AddExpressionToCell("Max(R19*R26*-1,R26*-1)", 29, 1)
        AddExpressionToCell("Max((R19*R27C[-1]*-1)+(R20*R26C[-1]*-1),R26*-1)", 29, 2)
        AddExpressionToCell("Max((R19*R27C[-1]*-1)+(R20*R27C[-2]*-1)+(R21*R26C[-2]*-1),R26*-1)", 29, 3)
        AddExpressionToCell("Max((R19*R27C[-1]*-1)+(R20*R27C[-2]*-1)+(R21*R27C[-3]*-1)+(R22*R26C[-3]*-1),R26*-1)", 29, 4)
        AddExpressionToCell("Max((R19*R27C[-1]*-1)+(R20*R27C[-2]*-1)+(R21*R27C[-3]*-1)+(R22*R27C[-4]*-1)+(R23*R26C[-3]*-1),R26*-1)", 29, 5)
        AddExpressionToCell("Max((R19*R27C[-1]*-1)+(R20*R27C[-2]*-1)+(R21*R27C[-3]*-1)+(R22*R27C[-4]*-1)+(R23*R27C[-5]*-1)+(R24*R27C[-5]*-1),R26*-1)", 29, 6)
        AddExpressionToRow("Max((R19*R27C[-1]*-1)+(R20*R27C[-2]*-1)+(R21*R27C[-3]*-1)+(R22*R27C[-4]*-1)+(R23*R27C[-5]*-1)+(R24*R27C[-6]*-1)+(R25*R27C[-5]*-1),R26*-1)", 29, 7, 12)
        AddExpressionToCell("Sum([C1:C12])", 29, 13)

        'New balance
        AddExpressionToRow("Sum([R[-4]:R[-1]])", 30, 1, 13)
        AddExpressionToRow("Max((PaymentDays(Column[])*R[-3])/365,2)", 30, 14, 17)
        For i = 0 To Rows.Count - 1
            Rows(i)("ID") = ""
        Next
    End Function
#End Region

    Private Sub BalanceSheet_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "DIVIDEND"
                ReturnValue = CStr(Dividends(CInt(ParameterList(0)) - 1))
            Case "TOTALSALES"
                ReturnValue = CStr(TotalSales(CInt(ParameterList(0))))
            Case "NETPROFIT"
                ReturnValue = CStr(NetProfit(CInt(ParameterList(0)) - 1))
            Case "CASHBALANCE"
                ReturnValue = CStr(CashBalance(CInt(ParameterList(0)) - 1))
            Case "STARTINGEARNING"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Earning)
                Else
                    ReturnValue = "0"
                End If
            Case "STARTUPCASH"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.Cash)
                Else
                    ReturnValue = CStr(_currentPlan.StartupData.CashRequirement)
                End If
            Case "STARTINGCAPITALASSETS"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.CapitalAssets)
                Else
                    ReturnValue = CStr(_currentPlan.StartupData.LongTermAssets)
                End If
            Case "PASTACCOUNTSRECIEVABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsReceiveable))
                Else
                    ReturnValue = "0"
                End If
            Case "SALESONCREDIT"
                ReturnValue = CStr(TotalSales(CInt(ParameterList(0))))
            Case "SHORTTERMBORROWINGS"
                ReturnValue = CStr(ShortTermBorrowings(CInt(ParameterList(0))))
            Case "LONGTERMBORROWINGS"
                ReturnValue = CStr(LongTermBorrowings(CInt(ParameterList(0))))
            Case "STARTINGSTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.ShortTermNotes))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.ShortTermLoan))
                End If
            Case "STARTINGLTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.LongTermLiabilities))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.LongTermLiabilities))
                End If
            Case "TAXESINCURED"
                ReturnValue = CStr(TaxesIncured(CInt(ParameterList(0))))
            Case "COSTOFUNITSALES"
                ReturnValue = CStr(CostOfUnitSales(CInt(ParameterList(0))))
            Case "SHORTTERMINTERESTEXPENSE"
                ReturnValue = CStr(ShortTermInterestExpense(CInt(ParameterList(0))))
            Case "LONGTERMINTERESTEXPENSE"
                ReturnValue = CStr(LongTermInterestExpense(CInt(ParameterList(0))))
            Case "PASTACCOUNTSPAYABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsPayable))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.UnpaidExpenses))
                End If
            Case "PAYMENTDAYS"
                ReturnValue = CStr(PaymentDaysRow(CInt(ParameterList(0))))
            Case "PRODUCTIONPAYROLL"
                ReturnValue = CStr(ProductionPayroll(CInt(ParameterList(0))))
            Case "OTHERPAYROLL"
                ReturnValue = CStr(OtherPayroll(CInt(ParameterList(0))))
            Case "SALESANDMARKETINGPAYROLL"
                ReturnValue = CStr(SalesAndMarketingPayroll(CInt(ParameterList(0))))
            Case "GENERALANDADMINISTRATIVEPAYROLL"
                ReturnValue = CStr(GeneralAndAdministrativePayroll(CInt(ParameterList(0))))
            Case "TOTALPAYROLL"
                ReturnValue = CStr(TotalPayroll(CInt(ParameterList(0))))
            Case "OPERATINGEXPENSE"
                ReturnValue = CStr(OperatingExpense(CInt(ParameterList(0))))
            Case "INVENTORY"
                ReturnValue = CStr(Inventory(CInt(ParameterList(0))))
            Case "STARTINGINVENTORY"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Inventory)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.StartupInventory)
                End If
            Case "EXPENSESPAIDINCASH"
                ReturnValue = CStr(ExpensesPaidInCash(CInt(ParameterList(0))))
            Case "DEPRECIATION"
                ReturnValue = CStr(Depreciation(CInt(ParameterList(0))))
            Case "CAPITALEXPENSE"
                ReturnValue = CStr(CapitalExpenditure(CInt(ParameterList(0))))
            Case "CHANGEINOTHERSTASSET"
                ReturnValue = CStr(ChangeInOtherSTAsset(CInt(ParameterList(0))))
            Case "PAYROLLBURDEN"
                ReturnValue = CStr(PayrollBurden(CInt(ParameterList(0))))
        End Select
    End Sub
End Class