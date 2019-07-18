'Changed by - Win-saira

Option Strict On
Option Explicit On 
#Region "Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common
#End Region

Public Class IncomeStatement
    Inherits BusinessTable

#Region "Private Members"
    Private Liabilities As LiabilitiesTable
    Private SalesForecastTable As SalesForecast
    Private GATable As GeneralAssumption
    Private PayrollTable As Payroll
    Private Expenses As Expenses
    Private ShortTermNotes As DataRow
    Private LongTermLiabilities As DataRow
    Private PayrollExpense As DataRow
    Private ProductionPayroll As DataRow
    Private SalesAndMarketingPayroll As DataRow
    Private GeneralAndAdministrativePayroll As DataRow
    Private OthersPayroll As DataRow
    Private TaxRates As DataRow
    Private ShortTermInterestRates As DataRow
    Private LongTermInterestRates As DataRow
    Private TotalSales As DataRow
    Private CostOfUnitSales As DataRow
    Private PayrollBurden As DataRow
#End Region
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal GATable As GeneralAssumption, ByVal SalesForecastTable As SalesForecast)
        MyBase.New(connData, currentPlan)
        Me.TableName = "IncomeStatement"
        Caption = "Profit and Loss (Income Statement)"

        Me.GATable = GATable
        Me.SalesForecastTable = SalesForecastTable
        PayrollTable = New Payroll(connData, currentPlan)
        Liabilities = New LiabilitiesTable(connData, currentPlan)

        TaxRates = GATable.GetTaxRates
        ShortTermInterestRates = GATable.GetShortTermInterestRates
        LongTermInterestRates = GATable.GetLongTermInterestRates

        PayrollExpense = PayrollTable.GetTotalPayrollExpense
        ProductionPayroll = PayrollTable.GetProductionPayroll
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OthersPayroll = PayrollTable.GetOtherPayroll
        PayrollBurden = PayrollTable.GetPayrollBurden

        ShortTermNotes = Liabilities.GetShortTermNotes
        LongTermLiabilities = Liabilities.GetLongTermLiabilities

        TotalSales = SalesForecastTable.GetTotalSales()
        CostOfUnitSales = SalesForecastTable.GetCostOfUnitSales

        Dim ds As DataSet
        If currentPlan.DisplayExpense Then
            Dim command As New InfiniCommand("BPL_GetOperatingExpensesCategorized")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, command)
        Else
            Dim command As New InfiniCommand("BPL_GetOperatingExpenses")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, command)
        End If
        PopulateDataTable(ds, currentPlan)


        PostProcess()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        Me.TableName = "IncomeStatement"
        Caption = "Profit and Loss (Income Statement)"

        PayrollTable = New Payroll(connData, currentPlan)
        'GATable = New GeneralAssumption(connData, currentPlan)
        GATable = PayrollTable.GetGeneralAssumptions
        Liabilities = New LiabilitiesTable(connData, currentPlan)
        SalesForecastTable = New SalesForecast(connData, currentPlan)

        TaxRates = GATable.GetTaxRates
        ShortTermInterestRates = GATable.GetShortTermInterestRates
        LongTermInterestRates = GATable.GetLongTermInterestRates

        PayrollExpense = PayrollTable.GetTotalPayrollExpense
        ProductionPayroll = PayrollTable.GetProductionPayroll
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OthersPayroll = PayrollTable.GetOtherPayroll
        PayrollBurden = PayrollTable.GetPayrollBurden

        ShortTermNotes = Liabilities.GetShortTermNotes
        LongTermLiabilities = Liabilities.GetLongTermLiabilities

        TotalSales = SalesForecastTable.GetTotalSales()
        CostOfUnitSales = SalesForecastTable.GetCostOfUnitSales

        Dim ds As DataSet
        If currentPlan.DisplayExpense Then
            Dim command As New InfiniCommand("BPL_GetOperatingExpensesCategorized")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, command)
        Else

            Dim command As New InfiniCommand("BPL_GetOperatingExpenses")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, command)
        End If
        PopulateDataTable(ds, currentPlan)


        PostProcess()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByVal businessID As Integer)
        Dim command As New InfiniCommand("BPL_GetIncomeStatement")
        command.AddParameter("@PlanID", businessID)

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        Dim dt1 As DataTable = ds.Tables(0)

        'Return dt1
    End Sub
#End Region
#Region "Private Methods"
    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()

        AddNewRow("Sales", "")
        AddNewRow("Direct Cost Of Sales", currentPlan.Currency)

        If _currentPlan.DisplayExpense = True Then
            AddNewRow("Production Payroll", currentPlan.Currency)
            AddDBTable(ds.Tables(0), 0)
            AddNewRow("Total Cost Of Sales", currentPlan.Currency)
            AddNewRow("", "")
            AddNewRow("Gross Margin", currentPlan.Currency)
            AddNewRow("Gross Margin %", "")
            AddNewRow("", "")
            AddNewRow("Operating Expenses", "")
            AddNewRow("-Sales And Marketing Expenses", "")
            AddNewRow("--Sales And Marketing Payroll", currentPlan.Currency)
            AddDBTable(ds.Tables(1), 3, False)
            AddNewRow("--Sales & Marketing Total", currentPlan.Currency)
            AddNewRow("--Sales & Marketing %", "")
            AddNewRow("", "")
            AddNewRow("-General & Admin Expenses", "")
            AddNewRow("--General & Admin Payroll", currentPlan.Currency)
            AddNewRow("--Payroll Burden", currentPlan.Currency)
            AddDBTable(ds.Tables(2), 3, False)
            AddNewRow("--General & Admin Total", currentPlan.Currency)
            AddNewRow("--General & Admin %", "")
            AddNewRow("", "")
            AddNewRow("-Other Expenses", "")
            AddNewRow("--Others Payroll", currentPlan.Currency)
            AddDBTable(ds.Tables(3), 3, False)
            AddNewRow("--Others Total", currentPlan.Currency)
            AddNewRow("--Others %", "")
        Else
            AddDBTable(ds.Tables(0), 0)
            AddNewRow("Total Cost Of Sales", currentPlan.Currency)
            AddNewRow("", "")
            AddNewRow("Gross Margin", currentPlan.Currency)
            AddNewRow("Gross Margin %", "")
            AddNewRow("", "")
            AddNewRow("Operating Expenses", currentPlan.Currency)
            AddNewRow("-Payroll Expense", currentPlan.Currency)
            AddNewRow("-Payroll Burden", currentPlan.Currency)
            AddDBTable(ds.Tables(1), 1, False)
        End If

        AddNewRow("-Total Operating Expenses", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Profit Before Interest and Taxes", currentPlan.Currency)
        AddNewRow("Interest Expense Short Term", currentPlan.Currency)
        AddNewRow("Interest Expense Long Term", currentPlan.Currency)
        AddNewRow("Taxes Incurred", currentPlan.Currency)
        AddNewRow("Net Profit", currentPlan.Currency)
        AddNewRow("Net Profit / Sales %", "")

        Dim SalesRow As Integer = GetRowNumber("Sales")
        AddExpressionToRow("TotalSales(Column[])", SalesRow, True)
        AddExpressionToRow("CostOfUnitSales(Column[])", GetRowNumber("Direct Cost Of Sales"), True)
        MakeSumRow(GetRowNumber("Direct Cost Of Sales"), GetRowNumber("Total Cost Of Sales") - 1, GetRowNumber("Total Cost Of Sales"))          'Total Cost of Sales
        MakeDifferenceRow(SalesRow, GetRowNumber("Total Cost Of Sales"), GetRowNumber("Gross Margin"))     'Gross Margin
        ' MakePercentageRow(GetRowNumber("Gross Margin"), SalesRow, GetRowNumber("Gross Margin %"))     'Gross %
        '  MakePercentageRow(GetRowNumber("Gross Margin"), SalesRow, GetRowNumber("Gross Margin %"), "change")    'Gross %
          

        MakeSumColumn(1, 12, SalesRow, GetRowNumber("Other"), 13)

        AddExpressionToRow("PayrollBurden[Column[]]", GetRowNumber("Payroll Burden"))
        If _currentPlan.DisplayExpense = True Then
            MakeSumColumn(1, 12, GetRowNumber("Sales And Marketing Expenses") + 1, GetRowNumber("Sales & Marketing Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("General & Admin Expenses") + 1, GetRowNumber("General & Admin Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("Other Expenses") + 1, GetRowNumber("Others Total") - 1, 13)

            AddExpressionToRow("ProductionPayroll(Column[])", GetRowNumber("Production Payroll"), True)
            AddExpressionToRow("SalesAndMarketingPayroll(Column[])", GetRowNumber("Sales And Marketing Payroll"), True)
            MakeSumRow(GetRowNumber("Sales And Marketing Expenses") + 1, GetRowNumber("Sales & Marketing Total") - 1, GetRowNumber("Sales & Marketing Total"))        'Sales & Marketing Expense Total
            MakePercentageRow(GetRowNumber("Sales & Marketing Total"), SalesRow, GetRowNumber("Sales & Marketing %"))    'Sales And Marketing %
            AddExpressionToRow("GeneralAndAdministrativePayroll(Column[])", GetRowNumber("General & Admin Payroll"), True)
            MakeSumRow(GetRowNumber("General & Admin Expenses") + 1, GetRowNumber("General & Admin Total") - 1, GetRowNumber("General & Admin Total"))          'General & Admin Expense Total
            MakePercentageRow(GetRowNumber("General & Admin Total"), SalesRow, GetRowNumber("General & Admin %"))    'General And Admin   % 
            AddExpressionToRow("OthersPayroll(Column[])", GetRowNumber("Others Payroll"), True)
            AddExpressionToRow("Sum([R{#'Operating Expenses.Other Expenses'+1}:R[-1]])", GetRowNumber("Others Total")) 'Total Cost of Expense Others
            MakePercentageRow(GetRowNumber("Others Total"), SalesRow, GetRowNumber("Others %"))    'Others %
            AddExpressionToRow("Round(R{#'Sales & Marketing Total'}+R{#'General & Admin Total'}+R{#'Others Total'},0)", GetRowNumber("Total Operating Expenses"))          'Total Operating Expenses
        Else
            AddExpressionToRow("TotalPayroll(Column[])", GetRowNumber("Payroll Expense"), True)
            AddExpressionToRow("Round(Sum([R{#'Operating Expenses'+1}:R[-1]]),0)", GetRowNumber("Total Operating Expenses"))               'Total Operating Expenses
            MakeSumColumn(1, 12, GetRowNumber("Operating Expenses") + 1, GetRowNumber("Total Operating Expenses") - 1, 13)
        End If
        MakeDifferenceRow(GetRowNumber("Gross Margin"), GetRowNumber("Total Operating Expenses"), GetRowNumber("Profit Before Interest and Taxes"))        'Profit before Interest and Taxes

        ' Short Term Interest
        AddExpressionToRow("Round(((ShortTermInterestRates(Column[])*ShortTermNotes(Column[]))/100)/12,0)", GetRowNumber("Interest Expense Short Term"), 1, 12, True) ' Short Term Interest
        AddExpressionToCell("Sum([C1:C12])", GetRowNumber("Interest Expense Short Term"), 13, True)
        AddExpressionToRow("Round(((ShortTermInterestRates(Column[])*((ShortTermNotes(Column[])+ShortTermNotes(Column[]-1))/2))/100),0)", GetRowNumber("Interest Expense Short Term"), 14, 17, True) ' Short Term Interest

        ' Long Term Interest
        AddExpressionToRow("Round(((LongTermInterestRates(Column[])*LongTermLiabilities(Column[]))/100)/12,0)", GetRowNumber("Interest Expense Long Term"), 1, 12, True) ' Long Term Interest
        AddExpressionToCell("Sum([C1:C12])", GetRowNumber("Interest Expense Long Term"), 13, True)
        AddExpressionToRow("Round(((LongTermInterestRates(Column[])*((LongTermLiabilities(Column[])+LongTermLiabilities(Column[]-1))/2))/100),0)", GetRowNumber("Interest Expense Long Term"), 14, 17, True) ' Long Term Interest

        'Net Profit
        AddExpressionToRow("(TaxRates[Column[]]/100)*(R{#'Profit Before Interest and Taxes'}-(R{#'Interest Expense Short Term'}+R{#'Interest Expense Long Term'}))", GetRowNumber("Taxes Incurred"))
        AddExpressionToRow("R{#'Profit Before Interest and Taxes'}-(R{#'Interest Expense Short Term'}+R{#'Interest Expense Long Term'}+R{#'Taxes Incurred'})", GetRowNumber("Net Profit"))
     
        MakePercentageRow(GetRowNumber("Net Profit"), SalesRow, GetRowNumber("Net Profit / Sales %"))    'Gross %
        MakePercentageRow(GetRowNumber("Gross Margin"), SalesRow, GetRowNumber("Gross Margin %"))


    End Sub
    Private Sub IncomeStatement_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "SHORTTERMINTERESTRATES"
                ReturnValue = CStr(ShortTermInterestRates(CInt(ParameterList(0))))
            Case "LONGTERMINTERESTRATES"
                ReturnValue = CStr(LongTermInterestRates(CInt(ParameterList(0))))
            Case "SHORTTERMNOTES"
                ReturnValue = CStr(ShortTermNotes(CInt(ParameterList(0))))
            Case "LONGTERMLIABILITIES"
                ReturnValue = CStr(LongTermLiabilities(CInt(ParameterList(0))))
            Case "TOTALPAYROLL"
                ReturnValue = CStr(PayrollExpense(CInt(ParameterList(0))))
            Case "PRODUCTIONPAYROLL"
                ReturnValue = CStr(ProductionPayroll(CInt(ParameterList(0))))
            Case "SALESANDMARKETINGPAYROLL"
                ReturnValue = CStr(SalesAndMarketingPayroll(CInt(ParameterList(0))))
            Case "GENERALANDADMINISTRATIVEPAYROLL"
                ReturnValue = CStr(GeneralAndAdministrativePayroll(CInt(ParameterList(0))))
            Case "OTHERSPAYROLL"
                ReturnValue = CStr(OthersPayroll(CInt(ParameterList(0))))
            Case "TAXRATES"
                ReturnValue = CStr(TaxRates(CInt(ParameterList(0))))
            Case "COSTOFUNITSALES"
                ReturnValue = CStr(CostOfUnitSales(CInt(ParameterList(0))))
            Case "TOTALSALES"
                ReturnValue = CStr(TotalSales(CInt(ParameterList(0))))
            Case "PAYROLLBURDEN"
                ReturnValue = CStr(PayrollBurden(CInt(ParameterList(0))))
        End Select
    End Sub

    Private Sub AddExpenseAccount(ByVal Name As String, ByVal UIId As Object)
        Dim commandDetail As New InfiniCommand("BPL_InsertOperatingExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)

        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub AddProductionExpenseAccount(ByVal Name As String, ByVal UIId As Object)
        Dim commandDetail As New InfiniCommand("BPL_InsertProductionExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub AddSalesAndMarketingExpenseAccount(ByVal Name As String, ByVal UIId As Object)
        Dim commandDetail As New InfiniCommand("BPL_InsertSalesAndMarketingExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub AddGeneralAndAdministrativeExpenseAccount(ByVal Name As String, ByVal UIId As Object)
        Dim commandDetail As New InfiniCommand("BPL_InsertGeneralAndAdministrationExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub AddOtherExpenseAccount(ByVal Name As String, ByVal UIId As Object)
        Dim commandDetail As New InfiniCommand("BPL_InsertOtherExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub DeleteExpenseAccount(ByVal AccountID As String)
        Dim commandDetail As New InfiniCommand("BPL_DeleteExpenseAccount")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
    Private Sub RenameExpenseAccount(ByVal AccountID As String, ByVal NewName As String)
        Dim commandDetail As New InfiniCommand("BPL_RenameExpenseCategory")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@expenseName", NewName)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub
#End Region
#Region "Public Methods"
    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")
        ElseIf (Position <> -1) Then

            If Not rowNameExists(RowName, Position) Then
                Try
                    If _CurrentPlan.DisplayExpense Then
                        If Position >= GetRowNumber("Direct Cost Of Sales") And Position <= GetRowNumber("Total Cost Of Sales") Then
                            AddProductionExpenseAccount(RowName, Me.Rows(Position).Item("id"))
                        Else
                            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellInsertError")
 
                        End If
                    Else
                        If Position >= GetRowNumber("Direct Cost Of Sales") And Position <= GetRowNumber("Total Cost Of Sales") Then
                            AddProductionExpenseAccount(RowName, Me.Rows(Position).Item("id"))
                        Else
                            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellInsertError")
 
                        End If
                    End If
                    Return True
                Catch ex As Exception
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellInsertError")
 
                End Try
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")

            End If
        End If


    End Function
    Public Overrides Function DeleteRow(ByVal RowNumber As Integer) As Boolean
         
        Try
            If RowNumber >= GetRowNumber("Direct Cost Of Sales") And RowNumber <= GetRowNumber("Total Cost Of Sales") Then
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    DeleteExpenseAccount(ID)
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")

                End If
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            End If
        Catch ex As Exception
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            Return False
        End Try
    End Function
    Public Overrides Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        If Not rowNameExists(NewName, RowNumber) Then
            If Trim(NewName) = "" Then Return False
            Try
                If RowNumber >= GetRowNumber("Direct Cost Of Sales") And RowNumber <= GetRowNumber("Total Cost Of Sales") Then
                    Dim ID As String = CStr(Rows(RowNumber)("ID"))
                    If ID.Length > 0 Then
                        RenameExpenseAccount(ID, NewName)
                    Else
                        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")

                    End If
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                End If
            Catch ex As Exception
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")

            End Try
        Else
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        End If
    End Function
    Public Overrides Sub Save()
        Dim IncomeArrList As New ArrayList
        Dim NewText As String
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
                    IncomeArrList.Add(New PeriodicCellValue(CStr(Columns(e.Column.Ordinal).ColumnName).ToUpper, CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (IncomeArrList.Count > 0) Then
            UpdateIncome(IncomeArrList)
            IncomeArrList.Clear()
        End If
        Saved()
    End Sub
    Public Function UpdateIncome(ByVal IncomeArrList As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As PeriodicCellValue
        For Each sp In IncomeArrList
            command = New InfiniCommand("BPL_UpdateExpenseValue")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@expenseID", sp.CategoryID)
            command.AddParameter("@PeriodName", sp.PeriodID)
            command.AddParameter("@expenseValue", sp.Value)
            Try
                DataAccess.ExecuteNonQuery(_connData, command)
            Catch e As Exception
                Throw New BizPlanDBInvalidDataException("Invalid format")
            End Try

        Next
        Return True
    End Function

    Public Function GetPayroll() As Payroll
        Return PayrollTable
    End Function
    Public Function GetGeneralAssumption() As GeneralAssumption
        Return GATable
    End Function
    Public Function GetSalesForecast() As SalesForecast
        Return SalesForecastTable
    End Function
    Public Function GetLiabilities() As LiabilitiesTable
        Return Liabilities
    End Function
    Public Function GetTotalCostOfSales() As DataRow
        Return Rows(GetRowNumber("Total Cost Of Sales"))
    End Function
    Public Function GetTotalOperatingExpense() As DataRow
        Return Rows(GetRowNumber("Total Operating Expenses"))
    End Function
    Public Function GetShortTermInterestExpense() As DataRow
        Return Rows(GetRowNumber("Interest Expense Short Term"))
    End Function
    Public Function GetLongTermInterestExpense() As DataRow
        Return Rows(GetRowNumber("Interest Expense Long Term"))
    End Function
    Public Function GetTaxesIncured() As DataRow
        Return Rows(GetRowNumber("Taxes Incurred"))
    End Function
    Public Function GetGrossMargin() As DataRow
        Return Rows(GetRowNumber("Gross Margin"))
    End Function
    Public Function GetGrossMarginPercent() As DataRow
        Return Rows(GetRowNumber("Gross Margin %"))
    End Function
    Public Function GetDepreciation() As DataRow
        Return Rows(GetRowNumber("Depreciation"))
    End Function
    Public Function GetNetProfit2() As DataRow
        Return Rows(GetRowNumber("Net Profit"))
    End Function
    Public Function GetNetProfit() As DataTable
        Dim dtNetProfit As DataTable = Clone()
        Dim dr As DataRow = dtNetProfit.NewRow
        Dim dNP As DataRow = GetNetProfit2()
        Dim i As Integer
        For i = 0 To Columns.Count - 1
            dr(i) = dNP(i)
        Next
        dtNetProfit.Rows.Add(dr)
        Return dtNetProfit
    End Function
    Public Function GetProfitBeforeInterestAndTaxes() As DataRow
        Return Rows(GetRowNumber("Profit Before Interest and Taxes"))
    End Function
    Public Function GetCostOfSales() As DataRow
        Return Rows(GetRowNumber("Total Cost Of Sales"))
    End Function
    Public Function GetCostOfUnitSales() As DataRow
        Return Rows(GetRowNumber("Direct Cost Of Sales"))
    End Function
#End Region

     
End Class
