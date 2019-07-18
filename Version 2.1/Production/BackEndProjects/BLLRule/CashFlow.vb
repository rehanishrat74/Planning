' Modified by - Win-saira 

Option Strict On
Option Explicit On 

#Region "Import Libraries "
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common
#End Region

Public Class CashFlow
    Inherits BusinessTable

#Region "Private Members"
    Private CashDetailsTable As CashDetails
    Private IncomeStatementTable As IncomeStatement
    Private TempT As SupportTable

    Private AccountsReceivable As DataRow
    Private AccountsPayable As DataRow
    Private NetProfit As DataRow
    Private ChangeInInventory As DataRow
    Private Depreciation As DataRow
#End Region
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "CashFlow"
        Caption = "Cash Flow"

        Dim command As New InfiniCommand("BPL_GetCashFlow")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        PopulateDataTable(ds, currentPlan)

        CashDetailsTable = New CashDetails(connData, currentPlan, Rows(GetRowNumber("Change in Other ST Assets")), Rows(GetRowNumber("Capital Expenditure")))

        IncomeStatementTable = CashDetailsTable.GetIncomeStatement
        TempT = CashDetailsTable.GetSupportTable

        AccountsPayable = CashDetailsTable.GetAccountsPayable
        NetProfit = IncomeStatementTable.GetNetProfit2
        AccountsReceivable = TempT.GetAccountsRecieveable
        ChangeInInventory = TempT.GetChangeInInventory
        Depreciation = IncomeStatementTable.GetDepreciation

        PostProcess()
    End Sub
#End Region
#Region "Public Methods"
    Public Overrides Sub Save()
        Dim CashFlowArrList As New ArrayList
        Dim NewText As String
        Dim Row As Integer
        Dim numVal() As String

        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")
            If (numVal(1).TrimStart("0"c) > "0") Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    If Not REValidator.IsDecimal(NewText, 0) Then
                        Throw New BizPlanInvalidDataException("bizplanweb_services_plan_planmanager_InvalidData")
                    End If
                    CashFlowArrList.Add(New PeriodicCellValue(e.Column.ColumnName, CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (CashFlowArrList.Count > 0) Then
            UpdateCashFlow(CashFlowArrList)
            CashFlowArrList.Clear()
        End If
        Saved()
    End Sub

    Private Function UpdateCashFlow(ByRef CashFlowArrList As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As PeriodicCellValue
        For Each sp In CashFlowArrList
            command = New InfiniCommand("BPL_UpdateCashFlow")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@CashFlowID", sp.CategoryID)
            command.AddParameter("@PeriodName", sp.PeriodID)
            command.AddParameter("@CashFlowValue", sp.Value)
            Try
                DataAccess.ExecuteNonQuery(_connData, command)
            Catch e As Exception
                Throw New BizPlanDBInvalidDataException("Formate Error ")
            End Try
        Next

    End Function

    ' It is Used By Charts 
    Public Shared Function GetCashFlowValues(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As Single(,)
        Dim dt As DataTable = New CashFlow(connData, currentPlan)
        Dim i As Integer
        Dim Profit As Single
        Dim Expenses As Single
        Dim CashBalance(16) As Single
        Dim row As Integer, col As Integer
        Dim dtCashflow(2, 12) As Single
        For col = 1 To 15

            Profit = CSng(dt.Rows(0).Item(col))
            Expenses = 0
            'If row >= 7 And row <= 12 Then
            For i = 2 To 7
                Profit += CSng(dt.Rows(i).Item(col))  'TList1.Grid.Cells(i, col).Value.Value())
            Next
            dt.Rows(8).Item(col) = Profit
            'End If

            If currentPlan.BusinessGoods = BusinessGoodsType.Services Then
                'If row >= 15 And row <= 18 Then
                For i = 10 To 13
                    Expenses += CSng(dt.Rows(i).Item(col)) 'TList1.Grid.Cells(i, col).Value.Value())
                Next
                'TList1.Grid.Cells(19, col).Value.Value()
                dt.Rows(14).Item(col) = Expenses
                'End If
                dt.Rows(15).Item(col) = Val(dt.Rows(8).Item(col)) - Val(dt.Rows(14).Item(col))
            Else
                'If row >= 15 And row <= 19 Then
                For i = 10 To 14
                    Expenses += CSng(dt.Rows(i).Item(col))
                Next
                dt.Rows(15).Item(col) = Expenses
                'End If
                dt.Rows(16).Item(col) = CSng(Val(dt.Rows(8).Item(col)) - Val(dt.Rows(15).Item(col)))
            End If
        Next

        If currentPlan.BusinessGoods = BusinessGoodsType.Services Then
            CashBalance(0) = 0.0
            dt.Rows(16).Item(1) = CSng(CashBalance(0)) + CSng(dt.Rows(15).Item(1)) 'TList1.Grid.Cells(20, 2).Value.Value())
            CashBalance(0) = CSng(dt.Rows(16).Item(1)) 'TList1.Grid.Cells(21, 2).Value.Value()
            For i = 1 To 15
                CashBalance(i) = CSng(CashBalance(i - 1)) + CSng(Val(dt.Rows(15).Item(i + 1))) 'TList1.Grid.Cells(20, i + 2).Value.Value())
                dt.Rows(16).Item(i + 1) = CashBalance(i)
            Next

            For i = 0 To 11
                dtCashflow(0, i) = CSng(dt.Rows(15).Item(i + 1))
                dtCashflow(1, i) = CSng(dt.Rows(16).Item(i + 1))
            Next

        Else
            CashBalance(0) = 0.0
            dt.Rows(17).Item(1) = CSng(CashBalance(0)) + CSng(dt.Rows(16).Item(1))
            CashBalance(0) = CSng(dt.Rows(17).Item(1))
            For i = 1 To 15
                CashBalance(i) = CSng(CashBalance(i - 1)) + CSng(Val(dt.Rows(16).Item(i + 1)))
                dt.Rows(17).Item(i + 1) = CashBalance(i)
            Next
            For i = 0 To 11
                dtCashflow(0, i) = CSng(dt.Rows(16).Item(i + 1))
                dtCashflow(1, i) = CSng(dt.Rows(17).Item(i + 1))
            Next
        End If
        Dim dtTemp As DataTable
        dtTemp = dt.Clone

        Return dtCashflow
    End Function
    Public Function GetSupportTable() As SupportTable
        Return TempT
    End Function
    Public Function GetCashDetails() As CashDetails
        Return CashDetailsTable
    End Function
    Public Function GetIncomeStatement() As IncomeStatement
        Return IncomeStatementTable
    End Function
    Public Function GetDividends() As DataRow
        Return Rows(GetRowNumber("Dividends"))
    End Function
    Public Function GetCapitalExpenditure() As DataRow
        Return Rows(GetRowNumber("Capital Expenditure"))
    End Function
    Public Function GetCapitalInput() As DataRow
        Return Rows(GetRowNumber("Capital Input"))
    End Function
    Public Function GetChangeInOtherSTAssets() As DataRow
        Return Rows(GetRowNumber("Change in Other ST Assets"))
    End Function
    Public Function GetNetCashFlow() As DataRow
        Return Rows(GetRowNumber("Net CashFlow"))
    End Function
    Public Function GetCashBalance() As DataRow
        Return Rows(GetRowNumber("Net CashFlow"))
    End Function
    Public Function GetShortTermBorrowings() As DataRow
        Return Rows(GetRowNumber("Current Borrowing(repayment)"))
    End Function
    Public Function GetIncDecOtherLiabilities() As DataRow
        Return Rows(GetRowNumber("Increase(decrease) Other Liabilities"))
    End Function
    Public Function GetStartingCash() As String
        If _currentPlan.IsOngoing Then
            Return CStr(_currentPlan.PastPerformanceData.Cash)
        Else
            Return CStr(_currentPlan.StartupData.CashRequirement)
        End If
    End Function
    Public Function GetPastAccountsReceivable() As String
        If _currentPlan.IsOngoing Then
            Return CStr(CLng(_currentPlan.PastPerformanceData.AccountsReceiveable))
        Else
            Return "0"
        End If
    End Function
#End Region
#Region "Private Methods"
    Private Sub PopulateDataTable(ByVal ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()

        AddNewRow("Net Profit", currentPlan.Currency)
        AddNewRow("Plus :", "")
        AddNewRow("-Depreciation", currentPlan.Currency)
        AddNewRow("-Change in Accounts Payable", currentPlan.Currency)
        AddDBTable(ds.Tables(0), 1)
        AddNewRow("-Subtotal", currentPlan.Currency)
        AddNewRow("Less :", "")

        If _CurrentPlan.SellOnCredit Then
            AddNewRow("-Change in Accounts Receivable", currentPlan.Currency)
        End If

        'Inventory
        If _currentPlan.ManageInventory Then
            AddNewRow("-Inventory", currentPlan.Currency)
        End If

        AddDBTable(ds.Tables(1), 1)
        AddNewRow("-Subtotal", currentPlan.Currency)
        AddNewRow("Net CashFlow", currentPlan.Currency)
        AddNewRow("Cash Balance", currentPlan.Currency)

        Dim NetProfitRow As Integer = GetRowNumber("Net Profit")
        AddExpressionToRow("NetProfit(Column[])", NetProfitRow, True)
        AddExpressionToCell("NetProfit(Column[])", NetProfitRow, 13, True)

        'Accounts Payable
        Dim AccountsPayableRow As Integer = GetRowNumber("Plus :.Change in Accounts Payable")
        AddExpressionToRow("AccountsPayable(Column[])-AccountsPayable(Column[]-1)", AccountsPayableRow, True)
        AddExpressionToCell("AccountsPayable(Column[])-PastAccountsPayable()", AccountsPayableRow, 1, True)
        AddExpressionToCell("AccountsPayable(Column[])-PastAccountsPayable()", AccountsPayableRow, 13, True)

        '   AddExpressionToCell("AccountsPayable(Column[])-PastAccountsPayable()", AccountsPayableRow, 14, True)

        Dim PlusSubtotalRow As Integer = GetRowNumber("Plus :.Subtotal")
        MakeSumColumn(1, 12, GetRowNumber("Plus :") + 1, PlusSubtotalRow - 1, 13)
        AddExpressionToRow("Round(R{#'Net Profit'}+Sum([R{#'Plus :'+1}:R[-1]]),2)", PlusSubtotalRow)

        If _CurrentPlan.SellOnCredit Then
            ' Accounts Receivable
            Dim AccountsReceivableRow As Integer = GetRowNumber("Less :.Change in Accounts Receivable")
            AddExpressionToRow("AccountsReceivable(Column[])-AccountsReceivable(Column[]-1)", AccountsReceivableRow, True)
            AddExpressionToCell("AccountsReceivable(Column[])-PastAccountsRecievable()", AccountsReceivableRow, 1, True)
            AddExpressionToCell("AccountsReceivable(Column[])-PastAccountsRecievable()", AccountsReceivableRow, 13, True)
            MakeSumColumn(1, 12, AccountsReceivableRow, GetRowNumber("Less :.Subtotal") - 1, 13)
        End If

        AddExpressionToRow("Depreciation(Column[])", GetRowNumber("Depreciation"), True)

        MakeSumRow(GetRowNumber("Less :") + 1, GetRowNumber("Less :.Dividends"), GetRowNumber("Less :.Subtotal"))

        MakeDifferenceRow(GetRowNumber("Plus :.Subtotal"), GetRowNumber("Less :.Subtotal"), GetRowNumber("Net CashFlow"))


        If _currentPlan.ManageInventory Then
            AddExpressionToRow("ChangeInInventory(Column[])", GetRowNumber("Less :.Inventory"), True)
            AddExpressionToCell("Sum([C1:C12])", GetRowNumber("Less :.Inventory"), 13)
        End If

        'Cash Balance
        Dim CashBalanceRow As Integer = GetRowNumber("Cash Balance")
        AddExpressionToCell("StartingCash[]+R[-1]", CashBalanceRow, 1)
        AddExpressionToRow("C[-1]+R[-1]", CashBalanceRow, 2, 12)
        AddExpressionToCell("C[-1]", CashBalanceRow, 13)
        AddExpressionToRow("C[-1]+R[-1]", CashBalanceRow, 14, 17)

    End Sub
    Private Sub CashFlow_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "STARTINGCASH"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.Cash)
                Else
                    ReturnValue = CStr(_currentPlan.StartupData.CashRequirement)
                End If
            Case "NETPROFIT"
                ReturnValue = CStr(NetProfit(CInt(ParameterList(0))))
            Case "PASTACCOUNTSRECIEVABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsReceiveable))
                Else
                    ReturnValue = "0"
                End If
            Case "ACCOUNTSRECEIVABLE"
                ReturnValue = CStr(AccountsReceivable(CInt(ParameterList(0))))
            Case "ACCOUNTSPAYABLE"
                ReturnValue = CStr(AccountsPayable(CInt(ParameterList(0))))
            Case "DEPRECIATION"
                ReturnValue = CStr(Depreciation(CInt(ParameterList(0))))
            Case "PASTACCOUNTSPAYABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsPayable))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.UnpaidExpenses))
                End If
            Case "CHANGEININVENTORY"
                ReturnValue = CStr(ChangeInInventory(CInt(ParameterList(0))))
        End Select
    End Sub
#End Region
End Class

