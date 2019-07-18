' Modified by - Win-saira 

Option Strict On  ' Block Implicit Conversions
Option Explicit On  ' Block Undeclared Variable Usage

#Region "Imports  "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient

#End Region

Public Class BalanceSheet
    Inherits BusinessTable
    Private CashFlowTable As CashFlow
    Private Liabilities As LiabilitiesTable
    Private IncomeStatementTable As IncomeStatement
    Private TempT As SupportTable
    Private CashDetailsTable As CashDetails
    Private GATable As GeneralAssumption

    Private ShortTermNotes As DataRow
    Private LongTermLiabilities As DataRow
    Private AccountsReceivable As DataRow
    Private AccountsPayable As DataRow
    Private CashBalance As DataRow
    Private Dividends As DataRow
    Private CapitalExpenditure As DataRow
    Private NetProfit As DataRow
    Private Inventory As DataRow
    Private InventoryTurnOver As DataRow
    Private Depreciation As DataRow
    Private CapitalInput As DataRow
    Private ChangeInOtherSTAssets As DataRow
    Private IncDecOtherLiabilities As DataRow
    Private CostOfUnitSales As DataRow
    Private TotalCostofsales As DataRow
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        _IsEditable = False
        CashFlowTable = New CashFlow(connData, currentPlan)

        IncomeStatementTable = CashFlowTable.GetIncomeStatement
        CashDetailsTable = CashFlowTable.GetCashDetails
        Liabilities = IncomeStatementTable.GetLiabilities
        TempT = CashFlowTable.GetSupportTable
        GATable = IncomeStatementTable.GetGeneralAssumption

        AccountsPayable = CashDetailsTable.GetAccountsPayable
        ShortTermNotes = Liabilities.GetShortTermNotes
        LongTermLiabilities = Liabilities.GetLongTermLiabilities
        AccountsReceivable = TempT.GetAccountsRecieveable
        CashBalance = CashFlowTable.GetCashBalance
        Dividends = CashFlowTable.GetDividends
        CapitalExpenditure = CashFlowTable.GetCapitalExpenditure
        NetProfit = IncomeStatementTable.GetNetProfit2()
        Inventory = TempT.GetInventory
        InventoryTurnOver = GATable.GetInventoryTurnover
        Depreciation = IncomeStatementTable.GetDepreciation
        CapitalInput = CashFlowTable.GetCapitalInput
        ChangeInOtherSTAssets = CashFlowTable.GetChangeInOtherSTAssets
        CostOfUnitSales = IncomeStatementTable.GetSalesForecast.GetCostOfUnitSales
        TotalCostofsales = IncomeStatementTable.GetTotalCostOfSales
        IncDecOtherLiabilities = CashFlowTable.GetIncDecOtherLiabilities
        Me.TableName = "BalanceSheet"
        Caption = "Balance Sheet"
 PopulateDataTable(currentPlan)
        PostProcess()
    End Sub
#End Region
#Region "Private Methods"
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Heading", GetType(String)))
        Columns.Add(New DataColumn("Starting Balances", GetType(String), ""))
        Columns.Add(New DataColumn("Jan", GetType(String)))
        Columns.Add(New DataColumn("Feb", GetType(String)))
        Columns.Add(New DataColumn("Mar", GetType(String)))
        Columns.Add(New DataColumn("Apr", GetType(String)))
        Columns.Add(New DataColumn("May", GetType(String)))
        Columns.Add(New DataColumn("Jun", GetType(String)))
        Columns.Add(New DataColumn("Jul", GetType(String)))
        Columns.Add(New DataColumn("Aug", GetType(String)))
        Columns.Add(New DataColumn("Sep", GetType(String)))
        Columns.Add(New DataColumn("Oct", GetType(String)))
        Columns.Add(New DataColumn("Nov", GetType(String)))
        Columns.Add(New DataColumn("Dec", GetType(String)))
        Columns.Add(New DataColumn("YearTotal", GetType(String)))
        Columns.Add(New DataColumn("Year1", GetType(String)))
        Columns.Add(New DataColumn("Year2", GetType(String)))
        Columns.Add(New DataColumn("Year3", GetType(String)))
        Columns.Add(New DataColumn("Year4", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub

    Private Function PopulateDataTable(ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataTable
        AddHeadings()

        AddNewRow("Assets", "")
        AddNewRow("-Short-term Assets", "")
        AddNewRow("--Cash Balance", currentPlan.Currency)
        If _CurrentPlan.SellOnCredit Then
            AddNewRow("--Accounts Receivable", currentPlan.Currency)
        End If
        If _currentPlan.ManageInventory Then
            AddNewRow("--Inventory", currentPlan.Currency)
        End If
        AddNewRow("--Other Short-term Assets", currentPlan.Currency)
        AddNewRow("--Total Short-term Assets", currentPlan.Currency)
        AddNewRow("-Long-term Assets", "")
        AddNewRow("--Capital Assets", currentPlan.Currency)
        AddNewRow("--Accumulated Depreciation", currentPlan.Currency)
        AddNewRow("--Total Long-term Assets", currentPlan.Currency)
        AddNewRow("-Total Assets", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Liabilities And Capital", "")
        AddNewRow("-Accounts Payable", currentPlan.Currency)
        AddNewRow("-Short-term Notes", currentPlan.Currency)
        AddNewRow("-Other Short-term Liabilities", currentPlan.Currency)
        AddNewRow("-Subtotal Short-term Liabilities", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("-Long-term Liabilities", currentPlan.Currency)
        AddNewRow("-Total liabilities", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("-Paid-in Capital", currentPlan.Currency)
        AddNewRow("-Earnings", currentPlan.Currency)
        AddNewRow("-Retained Earnings", currentPlan.Currency)
        AddNewRow("-Total Capital", currentPlan.Currency)
        AddNewRow("-Total Liabilities And Capital", currentPlan.Currency)
        AddNewRow("-Net Worth", currentPlan.Currency)
        AddNewRow("Check Line", "")


        'Cash
        AddExpressionToRow("C[-1]+CashBalance(Column[])", 2, True)
        AddExpressionToCell("StartupCash()", 2, 1, True)
        AddExpressionToCell("C[-1]", 2, 14, True)
        AddExpressionToCell("C[-1]+CashBalance(15)", 2, 15, True)
        AddExpressionToCell("C[-1]+CashBalance(16)", 2, 16, True)
        AddExpressionToCell("C[-1]+CashBalance(17)", 2, 17, True)
        AddExpressionToCell("C[-1]+CashBalance(18)", 2, 18, True)


        'Accounts Revievable
        If _CurrentPlan.SellOnCredit Then
            If _CurrentPlan.SalesOnCreditPercent = 0 Then
                AddExpressionToRow("0", 3, True)
            Else
                AddExpressionToRow("AccountsReceivable(Column[])", 3, True)
                AddExpressionToCell("PastAccountsRecievable()", 3, 1, True)
            End If
        End If

        ' Inventory
        If _CurrentPlan.ManageInventory Then
            Dim InventoryRow As Integer = GetRowNumber("Inventory")
            If _currentPlan.IsOngoing Then
                AddExpressionToRow("(CostOfUnitSales(Column[])*12)/InventoryTurns(Column[])", InventoryRow, True)
            Else
                AddExpressionToRow("Inventory(Column[])", InventoryRow, True)
            End If
            AddExpressionToCell("StartingInventory()", InventoryRow, 1, True)
            AddExpressionToCell("C[-1]", InventoryRow, 14)
            AddExpressionToCell("CostOfUnitSales(Column[])*C[-1]/TotalCostofSales(Column[])*LastInventoryRate(Column[])/InventoryTurns(Column[])", InventoryRow, 15, True)
            AddExpressionToCell("CostOfUnitSales(Column[])*C[-1]/TotalCostofSales(Column[])*LastInventoryRate(Column[])/InventoryTurns(Column[])", InventoryRow, 16, True)
            AddExpressionToCell("CostOfUnitSales(Column[])*C[-1]/TotalCostofSales(Column[])*LastInventoryRate(Column[])/InventoryTurns(Column[])", InventoryRow, 17, True)
            AddExpressionToCell("CostOfUnitSales(Column[])*C[-1]/TotalCostofSales(Column[])*LastInventoryRate(Column[])/InventoryTurns(Column[])", InventoryRow, 18, True)

        End If

        AddExpressionToRow("R[-3]+R[-1]", GetRowNumber("Total liabilities"), True)   ' Total Liabilities 

        'Capital Assets
        Dim CapitalAssetsRow As Integer = GetRowNumber("Capital Assets")
        AddExpressionToRow("C[-1]+CapitalExpense(Column[])", CapitalAssetsRow, True)
        AddExpressionToCell("StartingCapitalAssets()", CapitalAssetsRow, 1, True)
        AddExpressionToCell("C[-1]", CapitalAssetsRow, 14, True)

        'Accumulated Depreciation
        Dim AccDepreciationRow As Integer = GetRowNumber("Accumulated Depreciation")
        AddExpressionToRow("Depreciation(Column[])+C[-1]", AccDepreciationRow, True)
        AddExpressionToCell("StartingAccDep(Column[])", AccDepreciationRow, 1, True)
        AddExpressionToCell("C[-1]", AccDepreciationRow, 14, True)

        'Paidin Capital
        Dim PaidInRow As Integer = GetRowNumber("Paid-in Capital")
        AddExpressionToRow("CapitalInput(Column[])+C[-1]", PaidInRow, True)
        AddExpressionToCell("StartingCapital(Column[])", PaidInRow, 1, True)
        AddExpressionToCell("C[-1]", PaidInRow, 14, True)

        'Earnings
        Dim EarningRow As Integer = GetRowNumber("Earnings")
        AddExpressionToRow("C[-1]+NetProfit(Column[])", EarningRow, 1, 13, True)
        'AddExpressionToCell("NetProfit(Column[])", EarningRow, 14, True)
        AddExpressionToRow("NetProfit(Column[])", EarningRow, 14, 18, True)

        AddExpressionToCell("StartingEarning()", EarningRow, 1, True)
        AddExpressionToCell("NetProfit(Column[])", EarningRow, 2, True)

        ' Long Term Liabilities
        Dim LongTermLiabilitiesRow As Integer = GetRowNumber("Long-term Liabilities")
        AddExpressionToRow("LongTermLiabilities(Column[])", LongTermLiabilitiesRow, True)
        AddExpressionToCell("StartingLTL()", LongTermLiabilitiesRow, 1, True)
        AddExpressionToCell("C[-1]", LongTermLiabilitiesRow, 14, True)

        ' Other Short-term Liabilities
        Dim OtherSTL As Integer = GetRowNumber("Other Short-term Liabilities")
        AddExpressionToRow("C[-1]+IncDecOtherLiabilities(Column[])", OtherSTL, True)
        AddExpressionToCell("StartingOtherSTL(Column[])", OtherSTL, 1, True)
        AddExpressionToCell("C[-1]", OtherSTL, 14)

        ' Other Short-term Assets
        Dim OtherSTAssets As Integer = GetRowNumber("Other Short-term Assets")
        AddExpressionToRow("ChangeInOtherSTAssets(Column[])+C[-1]", OtherSTAssets, True)
        AddExpressionToCell("StartingSTAssets(Column[])", OtherSTAssets, 1, True)
        AddExpressionToCell("C[-1]", OtherSTAssets, 14, True)

        ' Short Term Notes
        Dim ShortTermNotesRow As Integer = GetRowNumber("Short-term Notes")
        AddExpressionToRow("ShortTermNotes(Column[])", ShortTermNotesRow, True)
        AddExpressionToCell("StartingSTL()", ShortTermNotesRow, 1, True)

        'Accounts Payable
        Dim AccountsPayableRow As Integer = GetRowNumber("Accounts Payable")
        AddExpressionToRow("AccountsPayable(Column[])", AccountsPayableRow, True)
        AddExpressionToCell("PastAccountsPayable()", AccountsPayableRow, 1, True)

        ' *
        MakeSumRow(GetRowNumber("Short-term Assets") + 1, GetRowNumber("Total Short-term Assets") - 1, GetRowNumber("Total Short-term Assets"), True)        ' SubTotal Short Term Assets
        MakeDifferenceRow(GetRowNumber("Capital Assets"), GetRowNumber("Accumulated Depreciation"), GetRowNumber("Total Long-term Assets"), True)   ' SubTotal Long  Term Assets 
        AddExpressionToRow("R{#'Total Short-term Assets'}+R{#'Total Long-term Assets'}", GetRowNumber("Total Assets"), True) ' Total Assets 

        MakeSumRow(GetRowNumber("Liabilities And Capital") + 1, GetRowNumber("Subtotal Short-term Liabilities") - 1, GetRowNumber("Subtotal Short-term Liabilities"), True)      ' SubTotal Short Term Liabilities  

        'Retained Earnings
        Dim RetainedEarningRow As Integer = GetRowNumber("Retained Earnings")
        AddExpressionToRow("C[-1]-Dividend(Column[])", RetainedEarningRow, True)
        AddExpressionToCell("R{#'Total Assets'}-(R{#'Total liabilities'}+R{#'Paid-in Capital'}+R{#'Earnings'})", RetainedEarningRow, 1, True)
        AddExpressionToCell("(C[-1]+R[-1]C[-1])-Dividend(Column[])", RetainedEarningRow, 2, True)
        AddExpressionToCell("R{#'Total Assets'}-(R{#'Total liabilities'}+R{#'Paid-in Capital'}+R{#'Earnings'})", RetainedEarningRow, 14, True)
        AddExpressionToRow("(C[-1]+R[-1]C[-1])-Dividend(Column[])", RetainedEarningRow, 15, 18, True)

        MakeSumRow(GetRowNumber("Paid-in Capital"), GetRowNumber("Retained Earnings"), GetRowNumber("Total Capital"))              ' Total Capital

        AddExpressionToRow("R{#'Total Capital'}+R{#'Total liabilities'}", GetRowNumber("Total Liabilities And Capital"), True)   ' Total Capital And Liabilities

        ' Net Worth
        AddExpressionToRow("R{#'Total Assets'}-R{#'Total liabilities'}", GetRowNumber("Net Worth"), True)
        AddExpressionToCell("C[-1]", GetRowNumber("Net Worth"), 14, True)

        AddExpressionToRow("Round(R{#'Total Assets'}-R{#'Total Liabilities And Capital'},0)", GetRowNumber("Check Line"), True) ' Check Line

        Dim i As Integer
        For i = 0 To Rows.Count - 1
            Rows(i)("ID") = ""
        Next
        Return Me
    End Function
#End Region
#Region "Public Methods"
    Public Function GetCashFlow() As CashFlow
        Return CashFlowTable
    End Function
    Public Function GetIncomeStatement() As IncomeStatement
        Return IncomeStatementTable
    End Function
    Public Function GetTotalAssets() As DataRow
        Return Rows(GetRowNumber("Total Assets"))
    End Function
    Public Function GetAccountsReceivable() As DataRow
        If _CurrentPlan.SellOnCredit Then
            Return Rows(GetRowNumber("Accounts Receivable"))
        End If
    End Function
    Public Function GetInventory() As DataRow
        If _currentPlan.ManageInventory Then
            Return Rows(GetRowNumber("Inventory"))
        End If
    End Function
    Public Function GetOtherShortTermAssets() As DataRow
        Return Rows(GetRowNumber("Other Short-term Assets"))
    End Function
    Public Function GetTotalShortTermAssets() As DataRow
        Return Rows(GetRowNumber("Total Short-term Assets"))
    End Function
    Public Function GetTotalLongTermAssets() As DataRow
        Return Rows(GetRowNumber("Total Long-term Assets"))
    End Function
    Public Function GetOtherShortTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Other Short-term Liabilities"))
    End Function
    Public Function GetTotalShortTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Subtotal Short-term Liabilities"))
    End Function
    Public Function GetLongTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Long-term Liabilities"))
    End Function
    Public Function GetTotalLiabilities() As DataRow
        Return Rows(GetRowNumber("Total liabilities"))
    End Function
    Public Function GetNetWorth() As DataRow
        Return Rows(GetRowNumber("Net Worth"))
    End Function
#End Region
    Private Sub BalanceSheet_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "DIVIDEND"
                ReturnValue = CStr(Dividends(CInt(ParameterList(0)) - 1))
            Case "NETPROFIT"
                ReturnValue = CStr(NetProfit(CInt(ParameterList(0)) - 1))
            Case "CASHBALANCE"
                ReturnValue = CStr(CashBalance(CInt(ParameterList(0)) - 1))
            Case "CAPITALEXPENSE"
                ReturnValue = CStr(CapitalExpenditure(CInt(ParameterList(0)) - 1))
            Case "STARTINGEARNING"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Earning)
                Else
                    ReturnValue = "0"
                End If
            Case "STARTINGINVENTORY"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Inventory)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.StartupInventory)
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
            Case "PASTACCOUNTSPAYABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsPayable))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.UnpaidExpenses))
                End If
            Case "ACCOUNTSRECEIVABLE"
                ReturnValue = CStr(AccountsReceivable(CInt(ParameterList(0)) - 1))
            Case "SHORTTERMNOTES"
                ReturnValue = CStr(ShortTermNotes(CInt(ParameterList(0)) - 1))
            Case "CAPITALINPUT"
                ReturnValue = CStr(CapitalInput(CInt(ParameterList(0)) - 1))
            Case "LONGTERMLIABILITIES"
                ReturnValue = CStr(LongTermLiabilities(CInt(ParameterList(0)) - 1))
            Case "ACCOUNTSPAYABLE"
                ReturnValue = CStr(AccountsPayable(CInt(ParameterList(0)) - 1))
            Case "DEPRECIATION"
                ReturnValue = CStr(Depreciation(CInt(ParameterList(0)) - 1))
            Case "INVENTORYTURNS"
                ReturnValue = CStr(InventoryTurnOver(CInt(ParameterList(0)) - 1))
            Case "LASTINVENTORYRATE"
                ReturnValue = CStr(InventoryTurnOver(CInt(ParameterList(0)) - 2))

            Case "INVENTORY"
                ReturnValue = CStr(Inventory(CInt(ParameterList(0)) - 1))
            Case "CHANGEINOTHERSTASSETS"
                ReturnValue = CStr(ChangeInOtherSTAssets(CInt(ParameterList(0)) - 1))
            Case "STARTINGOTHERSTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.OtherShortTermLiabilities))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.InterestFreeShortTermLiabilities))
                End If
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
            Case "STARTINGINVENTORY"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Inventory)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.StartupInventory)
                End If
            Case "STARTINGCAPITAL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.PaidInCapital)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.TotalInvestment)
                End If
            Case "STARTINGACCDEP"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.AccumulatedDepreciation)
                Else
                    ReturnValue = "0"
                End If
            Case "STARTINGSTASSETS"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.OtherShortTermAssets)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.OtherShortTermAssets)
                End If
            Case "COSTOFUNITSALES"
                ReturnValue = CStr(CostOfUnitSales(CInt(ParameterList(0)) - 1))
                'Case Else
                '    MsgBox(FunctionName)
            Case "TOTALCOSTOFSALES"
                ReturnValue = CStr(TotalCostofsales(CInt(ParameterList(0)) - 2))
            Case "INCDECOTHERLIABILITIES"
                ReturnValue = CStr(IncDecOtherLiabilities(CInt(ParameterList(0)) - 1))

        End Select
    End Sub
End Class