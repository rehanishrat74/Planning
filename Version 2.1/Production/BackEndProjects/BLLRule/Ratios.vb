'Changed by - Win-saira

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common

Public Class Ratios
    Inherits BusinessTable
    Public RatioCurrencyValue As String
#Region "Private Members"
    Private BalanceSheetTable As BalanceSheet
    Private IncomeStatementTable As IncomeStatement
    Private SalesForecastTable As SalesForecast
    Private Sales As DataRow
    Private TotalAssets As DataRow
    Private AccountsReceivable As DataRow
    Private Inventory As DataRow
    Private OtherShortTermAssets As DataRow
    Private TotalShortTermAssets As DataRow
    Private TotalLongTermAssets As DataRow
    Private OtherShortTermLiabilities As DataRow
    Private TotalShortTermLiabilities As DataRow
    Private LongTermLiabilities As DataRow
    Private TotalLiabilities As DataRow
    Private GrossMarginPercent As DataRow
    Private GrossMargin As DataRow
    Private NetProfit As DataRow
    Private ProfitBeforeInterestAndTaxes As DataRow
    Private ShortTermInterestExpense As DataRow
    Private LongTermInterestExpense As DataRow
    Private NetWorth As DataRow
#End Region

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        RatioCurrencyValue = currentPlan.Currency
        Caption = "Ratios"
        TableName = "RatiosAnalysis"

        BalanceSheetTable = New BalanceSheet(connData, currentPlan)
        IncomeStatementTable = BalanceSheetTable.GetIncomeStatement
        SalesForecastTable = IncomeStatementTable.GetSalesForecast
        Sales = SalesForecastTable.GetTotalSales
        TotalAssets = BalanceSheetTable.GetTotalAssets
        AccountsReceivable = BalanceSheetTable.GetAccountsReceivable
        Inventory = BalanceSheetTable.GetInventory
        OtherShortTermAssets = BalanceSheetTable.GetOtherShortTermAssets
        TotalShortTermAssets = BalanceSheetTable.GetTotalShortTermAssets
        TotalLongTermAssets = BalanceSheetTable.GetTotalLongTermAssets
        OtherShortTermLiabilities = BalanceSheetTable.GetOtherShortTermLiabilities
        TotalShortTermLiabilities = BalanceSheetTable.GetTotalShortTermLiabilities
        LongTermLiabilities = BalanceSheetTable.GetLongTermLiabilities
        TotalLiabilities = BalanceSheetTable.GetTotalLiabilities
        GrossMarginPercent = IncomeStatementTable.GetGrossMarginPercent
        GrossMargin = IncomeStatementTable.GetGrossMargin
        NetProfit = IncomeStatementTable.GetNetProfit2
        ProfitBeforeInterestAndTaxes = IncomeStatementTable.GetProfitBeforeInterestAndTaxes
        ShortTermInterestExpense = IncomeStatementTable.GetShortTermInterestExpense
        LongTermInterestExpense = IncomeStatementTable.GetLongTermInterestExpense
        NetWorth = BalanceSheetTable.GetNetWorth

        Dim command As New InfiniCommand("BPL_GetIndustryProfile")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        command.AddParameter("@InventoryFlag", currentPlan.ManageInventory)
        command.AddParameter("@SellOnCreditFlag", currentPlan.SellOnCredit)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        PopulateDataTable(ds)

        PostProcess()
    End Sub
#End Region
#Region "Private Methods"
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Heading", GetType(String)))
        Columns.Add(New DataColumn("Year0", GetType(String), ""))
        Columns.Add(New DataColumn("Year1", GetType(String)))
        Columns.Add(New DataColumn("Year2", GetType(String), ""))
        Columns.Add(New DataColumn("Year3", GetType(String), ""))
        Columns.Add(New DataColumn("Year4", GetType(String), ""))
        Columns.Add(New DataColumn("Industry Profile", GetType(String), ""))
        Columns.Add(New DataColumn("ID", GetType(String), ""))
    End Sub
    Private Function PopulateDataTable(ByVal ds As DataSet) As DataTable
        AddHeadings()

        AddDBTable(ds.Tables(0), 0)
        AddNewRow("", "")
        AddNewRow("Percent of Total Assets", "")
        AddDBTable(ds.Tables(1), 1)
        AddNewRow("", "")
        AddNewRow("Percent of Sales", "")
        AddDBTable(ds.Tables(2), 1)
        AddNewRow("", "")
        AddNewRow("Ratios", "")
        AddDBTable(ds.Tables(3), 1)

        If _currentPlan.IsOngoing Then
            AddExpressionToCell("Round((Sales(Column[])/PastSales(Column[]))*100,2)&'%'", GetRowNumber("Sales Growth"), 1, True)
        Else
            AddExpressionToCell("'0%'", GetRowNumber("Sales Growth"), 1, True)
        End If
        AddExpressionToCell("Round((Sales(Column[])/Sales(Column[]-1))*100,2)&'%'", GetRowNumber("Sales Growth"), 2, True)
        AddExpressionToCell("Round((Sales(Column[])/Sales(Column[]-1))*100,2)&'%'", GetRowNumber("Sales Growth"), 3, True)
        AddExpressionToCell("Round((Sales(Column[])/Sales(Column[]-1))*100,2)&'%'", GetRowNumber("Sales Growth"), 4, True)
        AddExpressionToCell("Round((Sales(Column[])/Sales(Column[]-1))*100,2)&'%'", GetRowNumber("Sales Growth"), 5, True)

        If _CurrentPlan.SellOnCredit Then
            AddExpressionToRow("Round((AccountsReceivable(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Accounts Receivable"), 1, 5, True)
        End If

        If _CurrentPlan.ManageInventory Then
            AddExpressionToRow("Round((Inventory(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Inventory"), 1, 5, True)


            'If _currentPlan.BusinessGoods = BusinessGoodsType.Services Then
            '    AddExpressionToRow("'0%'", GetRowNumber("Inventory"), 1, 5, True)
            'Else
            '    AddExpressionToRow("Round((Inventory(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Inventory"), 1, 5, True)
            'End If
        End If


        AddExpressionToCell("R[1]-(R[-1]+R[-2])", GetRowNumber("Other Short-term Assets"), 6)
        AddExpressionToCell("R[2]-R[1]", GetRowNumber("Total Short-term Assets"), 6)
        AddExpressionToCell("'100%'", GetRowNumber("Total Assets"), 6)
        AddExpressionToCell("R[-3]+R[-2]+R[-1]", GetRowNumber("Total Liabilities"), 6)
        AddExpressionToCell("R[-5]-R[-1]", GetRowNumber("Net Worth"), 6)
        AddExpressionToCell("'100%'", GetRowNumber("Sales"), 6)

        AddExpressionToRow("Round((OtherSTAssets(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Other Short-term Assets"), 1, 5, True)
        AddExpressionToRow("Round((TotalSTAssets(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Total Short-term Assets"), 1, 5, True)
        AddExpressionToRow("Round((TotalLTAssets(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Long-term Assets"), 1, 5, True)
        AddExpressionToRow("'100%'", GetRowNumber("Total Assets"), 1, 5, True)
        AddExpressionToRow("Round((OtherSTLiabilities(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Other Short-term Liabilities"), 1, 5, True)
        AddExpressionToRow("Round((TotalSTLiabilities(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Subtotal Short-term Liabilities"), 1, 5, True)
        AddExpressionToRow("Round((LTLiabilities(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Long-term Liabilities"), 1, 5, True)
        AddExpressionToRow("Round((TotalLiabilities(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Total Liabilities"), 1, 5, True)
        AddExpressionToRow("(R{#'Total Assets'}-R{#'Total Liabilities'})&'%'", GetRowNumber("Net Worth"), 1, 5, True)
        AddExpressionToRow("'100%'", GetRowNumber("Sales"), 1, 5, True)
        AddExpressionToRow("GrossMarginPercent(Column[])", GetRowNumber("Gross Margin"), 1, 5, True)
        AddExpressionToRow("Round(((GrossMargin(Column[])-NetProfit(Column[]))/Sales(Column[]))*100,2)&'%'", GetRowNumber("Selling General & Administrative Expenses"), 1, 5, True)
        AddExpressionToRow("Round((ProfitBeforeInterestAndTaxes(Column[])/Sales(Column[]))*100,2)&'%'", GetRowNumber("Profit Before Interest and Taxes"), 1, 5, True)
        AddExpressionToRow("Round((TotalSTAssets(Column[])/TotalSTLiabilities(Column[])),2)", GetRowNumber("Current"), 1, 5, True)
        If _CurrentPlan.ManageInventory Then
            AddExpressionToRow("Round(((TotalSTAssets(Column[])-Inventory(Column[]))/TotalSTLiabilities(Column[])),2)", GetRowNumber("Quick"), 1, 5, True)
        Else
            AddExpressionToRow("Round((TotalSTAssets(Column[])/TotalSTLiabilities(Column[])),2)", GetRowNumber("Quick"), 1, 5, True)
        End If
        AddExpressionToRow("Round((TotalLiabilities(Column[])/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Total Debt to Total Assets"), 1, 5, True)
        AddExpressionToRow("Round(((ProfitBeforeInterestAndTaxes(Column[])+STInterestExpense(Column[])+LTInterestExpense(Column[]))/NetWorth(Column[]))*100,2)&'%'", GetRowNumber("Pre-Tax Return on Net Worth"), 1, 5, True)
        AddExpressionToRow("Round(((ProfitBeforeInterestAndTaxes(Column[])+STInterestExpense(Column[])+LTInterestExpense(Column[]))/TotalAssets(Column[]))*100,2)&'%'", GetRowNumber("Pre-Tax Return on Assets"), 1, 5, True)
    End Function
    ' * changes Overrides to overloads
    Protected Overloads Sub AddDBTable(ByVal Table As DataTable, ByVal NestingLevel As Integer)
        Dim drTemp As DataRow
        For Each drTemp In Table.Rows
            If Table.Columns.Contains("Unit") Then
                If (UnitTypes.None = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, "")
                ElseIf (UnitTypes.Currecny = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, _CurrentPlan.Currency)
                ElseIf (UnitTypes.Percent = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, "")
                End If
            Else
                AddDBRow(drTemp, NestingLevel, "")
            End If
        Next
    End Sub
    ' * changes Overrides to overloads

    Protected Overloads Sub AddDBRow(ByVal Row As DataRow, ByVal NestingLevel As Integer, ByVal Unit As String)
        Dim drTemp As DataRow
        Dim i As Integer, j As Integer
        Dim Str As String
        For i = 1 To NestingLevel
            Str = Str & "-"
        Next
        drTemp = AddNewRow(Str & CStr(Row(0)), Unit)
        drTemp("Industry Profile") = Row("IndustryProfile")
        drTemp("ID") = Row("ID")
    End Sub

    Private Sub Ratios_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "PASTSALES"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.Sales)
                Else
                    ReturnValue = "0"
                End If
            Case "SALES"
                ReturnValue = CStr(Sales(12 + CInt(ParameterList(0))))
            Case "TOTALASSETS"
                ReturnValue = CStr(TotalAssets(13 + CInt(ParameterList(0))))
            Case "ACCOUNTSRECEIVABLE"
                ReturnValue = CStr(AccountsReceivable(13 + CInt(ParameterList(0))))
            Case "INVENTORY"
                ReturnValue = CStr(Inventory(13 + CInt(ParameterList(0))))




            Case "OTHERSTASSETS"
                ReturnValue = CStr(OtherShortTermAssets(13 + CInt(ParameterList(0))))
            Case "TOTALSTASSETS"
                ReturnValue = CStr(TotalShortTermAssets(13 + CInt(ParameterList(0))))
            Case "TOTALLTASSETS"
                ReturnValue = CStr(TotalLongTermAssets(13 + CInt(ParameterList(0))))
            Case "OTHERSTLIABILITIES"
                ReturnValue = CStr(OtherShortTermLiabilities(13 + CInt(ParameterList(0))))
            Case "TOTALSTLIABILITIES"
                ReturnValue = CStr(TotalShortTermLiabilities(13 + CInt(ParameterList(0))))
            Case "TOTALLTASSETS"
                ReturnValue = CStr(TotalLongTermAssets(13 + CInt(ParameterList(0))))
            Case "LTLIABILITIES"
                ReturnValue = CStr(LongTermLiabilities(13 + CInt(ParameterList(0))))
            Case "TOTALLIABILITIES"
                ReturnValue = CStr(TotalLiabilities(13 + CInt(ParameterList(0))))
            Case "GROSSMARGINPERCENT"
                ReturnValue = CStr(GrossMarginPercent(12 + CInt(ParameterList(0))))
            Case "GROSSMARGIN"
                ReturnValue = CStr(GrossMargin(12 + CInt(ParameterList(0))))
            Case "NETPROFIT"
                ReturnValue = CStr(NetProfit(12 + CInt(ParameterList(0))))
            Case "PROFITBEFOREINTERESTANDTAXES"
                ReturnValue = CStr(ProfitBeforeInterestAndTaxes(12 + CInt(ParameterList(0))))
            Case "STINTERESTEXPENSE"
                ReturnValue = CStr(ShortTermInterestExpense(12 + CInt(ParameterList(0))))
            Case "LTINTERESTEXPENSE"
                ReturnValue = CStr(LongTermInterestExpense(12 + CInt(ParameterList(0))))
            Case "NETWORTH"
                ReturnValue = CStr(NetWorth(13 + CInt(ParameterList(0))))
        End Select
    End Sub

#End Region
#Region "Public Methods"
    Public Overrides Sub Save()
        Dim IndustryProfileArrayList As New ArrayList
        Dim NewText As String
        Dim numVal() As String

        Dim Row As Integer, Column As Integer
        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")

            If (numVal(1).TrimStart("0"c) > "0") Then
                If e.Column.ColumnName = "Industry Profile" Then
                    NewText = CStr(e.ProposedValue)
                    If Not REValidator.IsDecimal(NewText, 0) Then
                        Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                    End If
                    IndustryProfileArrayList.Add(New CellValue(CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (IndustryProfileArrayList.Count > 0) Then
            UpdateIndustryProfile(IndustryProfileArrayList)
            IndustryProfileArrayList.Clear()
        End If
        Saved()
    End Sub
    Private Function UpdateIndustryProfile(ByRef IndustryProfile As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As CellValue
        For Each sp In IndustryProfile
            command = New InfiniCommand("BPL_UpdateIndustryProfile")
            command.AddParameter("@PlanID", _currentplan.PlanID)
            command.AddParameter("@RatioID", sp.CategoryID)
            command.AddParameter("@RatioValue", sp.Value)
            DataAccess.ExecuteNonQuery(_connData, command)
        Next
    End Function
    Public Function GetSalesGrowth() As DataRow
        Return Rows(GetRowNumber("Sales Growth"))
    End Function
    Public Function GetGrossMargin() As DataRow
        Return Rows(GetRowNumber("Gross Margin"))
    End Function
    Public Function GetOperatingExpenses() As DataRow
        Return Rows(GetRowNumber("Selling General & Administrative Expenses"))
    End Function
    Public Function GetAccountsReceivable() As DataRow
        If _CurrentPlan.SellOnCredit Then
            Return Rows(GetRowNumber("Accounts Receivable"))
        Else
            Dim tempRow As DataRow
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 7
                tempRow.Item(i) = 0
            Next
            Return tempRow
        End If
    End Function
    Public Function GetBalanceSheet() As BalanceSheet
        Return BalanceSheetTable
    End Function
#End Region
End Class

