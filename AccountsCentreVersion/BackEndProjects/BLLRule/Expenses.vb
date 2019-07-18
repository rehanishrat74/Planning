
Option Strict On
Option Explicit On 

#Region "Imports"

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common


#End Region

Public Class Expenses
    Inherits BusinessTable
    Public strOtherDeptRowDel As String
    Public strOtherDeptRowRen As String
    Private Liabilities As LiabilitiesTable
    Private SalesForecastTable As SalesForecast
    Private GATable As GeneralAssumption
    Private PayrollTable As Payroll
    Public status As Boolean
    Public Objstatus As CustomerStatus
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
    Dim ProRowHash As Hashtable
    Dim expenseHeading As New ArrayList
    Dim ds As DataSet
    Public BPObject As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Private Sub New()

    End Sub


    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal parm As Integer)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Expenses"
        Caption = "Expenses"

        PayrollTable = New Payroll(connData, currentPlan)
        PayrollExpense = PayrollTable.GetTotalPayrollExpense
        ProductionPayroll = PayrollTable.GetProductionPayroll
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OthersPayroll = PayrollTable.GetOtherPayroll
        PayrollBurden = PayrollTable.GetPayrollBurden

        Dim dblPayExp As Double = CType(PayrollExpense.Item(13), Double)
        Dim dblPayBurdin As Double = CType(PayrollBurden.Item(13), Double)
        BPObject.Payroll_Expense = dblPayExp
        BPObject.Payroll_Burden = dblPayBurdin

    End Sub

    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal parm As Integer, ByVal Periodid As Integer)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Expenses"
        Caption = "Expenses"

        PayrollTable = New Payroll(connData, currentPlan)
        PayrollExpense = PayrollTable.GetTotalPayrollExpense
        ProductionPayroll = PayrollTable.GetProductionPayroll
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OthersPayroll = PayrollTable.GetOtherPayroll
        PayrollBurden = PayrollTable.GetPayrollBurden

        Dim dblPayExp As Double = CType(PayrollExpense.Item(Periodid), Double)
        Dim dblPayBurdin As Double = CType(PayrollBurden.Item(Periodid), Double)
        BPObject.Payroll_Expense = dblPayExp
        BPObject.Payroll_Burden = dblPayBurdin

    End Sub


    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Expenses"
        Caption = "Expenses"
        status = Objstatus.CustomerSerivceStatus(connData)
        ProRowHash = New Hashtable(50)
        PayrollTable = New Payroll(connData, currentPlan)
        PayrollExpense = PayrollTable.GetTotalPayrollExpense
        ProductionPayroll = PayrollTable.GetProductionPayroll
        SalesAndMarketingPayroll = PayrollTable.GetSalesAndMarketingPayrollExpense
        GeneralAndAdministrativePayroll = PayrollTable.GetGeneralAndAdministrativePayrollExpense
        OthersPayroll = PayrollTable.GetOtherPayroll
        PayrollBurden = PayrollTable.GetPayrollBurden

        If status = True Then
            If currentPlan.DisplayExpense Then
                Dim command As New InfiniCommand("BPL_GetOperatingExpensesCategorized")
                command.AddParameter("@PlanID", currentPlan.PlanID)
                ds = DataAccess.ExecuteDataSet(connData, command)
            Else
                Dim command As New InfiniCommand("BPL_GetOperatingExpensesLinked")
                command.AddParameter("@PlanID", currentPlan.PlanID)
                ds = DataAccess.ExecuteDataSet(connData, command)
            End If
        Else
            If currentPlan.DisplayExpense Then
                Dim command As New InfiniCommand("BPL_GetOperatingExpensesCategorized")
                command.AddParameter("@PlanID", currentPlan.PlanID)
                ds = DataAccess.ExecuteDataSet(connData, command)
            Else
                Dim command As New InfiniCommand("BPL_GetOperatingExpenses")
                command.AddParameter("@PlanID", currentPlan.PlanID)
                ds = DataAccess.ExecuteDataSet(connData, command)
            End If
        End If


        If ds.Tables.Count <> 0 Then
            Dim a As Integer
            For a = 0 To ds.Tables(1).Rows.Count - 1
                If CType(ds.Tables(1).Rows(a).Item(19), String) <> "0" Then

                    ProRowHash.Add(ds.Tables(1).Rows(a).ItemArray(17), ds.Tables(1).Rows(a).ItemArray(19))
                End If
            Next
        End If


        PopulateDataTable(ds, currentPlan)


        PostProcess()

    End Sub

    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()


        If _currentPlan.DisplayExpense = True Then
            AddNewRow("Operating Expenses", "")
           

            AddNewRow("-Sales And Marketing Expenses", "")
            AddNewRow("--Sales And Marketing Payroll", currentPlan.Currency)

            AddDBTable(ds.Tables(1), 3)
            AddNewRow("--Sales & Marketing Total", currentPlan.Currency)
            '  AddNewRow("--Sales & Marketing %", "")
            AddNewRow("", "")
            AddNewRow("-General & Admin Expenses", "")
            AddNewRow("--General & Admin Payroll", currentPlan.Currency)
            AddNewRow("--Payroll Burden", currentPlan.Currency)
            AddDBTable(ds.Tables(2), 3)
            AddNewRow("--General & Admin Total", currentPlan.Currency)
            '   AddNewRow("--General & Admin %", "")
            AddNewRow("", "")
            AddNewRow("-Other Expenses", "")
            AddNewRow("--Others Payroll", currentPlan.Currency)
            AddDBTable(ds.Tables(3), 3)
            AddNewRow("--Others Total", currentPlan.Currency)
            '    AddNewRow("--Others %", "")
            AddExpenseHeadings()
        Else

            AddNewRow("Operating Expenses", "")
            AddNewRow("-Payroll Expense", currentPlan.Currency)
            AddNewRow("-Payroll Burden", currentPlan.Currency)
            AddDBTable(ds.Tables(1), 1)
        End If

        AddNewRow("Total Operating Expenses", currentPlan.Currency)
        AddNewRow("", "")


        AddExpressionToRow("PayrollBurden[Column[]]", GetRowNumber("Payroll Burden"))
        If _currentPlan.DisplayExpense = True Then
            MakeSumColumn(1, 12, GetRowNumber("Sales And Marketing Expenses") + 1, GetRowNumber("Sales & Marketing Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("General & Admin Expenses") + 1, GetRowNumber("General & Admin Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("Other Expenses") + 1, GetRowNumber("Others Total") - 1, 13)

            '   AddExpressionToRow("ProductionPayroll(Column[])", GetRowNumber("Production Payroll"), True)
            AddExpressionToRow("SalesAndMarketingPayroll(Column[])", GetRowNumber("Sales And Marketing Payroll"), True)
            MakeSumRow(GetRowNumber("Sales And Marketing Expenses") + 1, GetRowNumber("Sales & Marketing Total") - 1, GetRowNumber("Sales & Marketing Total"))        'Sales & Marketing Expense Total
            ' MakePercentageRow(GetRowNumber("Sales & Marketing Total"), SalesRow, GetRowNumber("Sales & Marketing %"))    'Sales And Marketing %
            AddExpressionToRow("GeneralAndAdministrativePayroll(Column[])", GetRowNumber("General & Admin Payroll"), True)
            MakeSumRow(GetRowNumber("General & Admin Expenses") + 1, GetRowNumber("General & Admin Total") - 1, GetRowNumber("General & Admin Total"))          'General & Admin Expense Total
            ' MakePercentageRow(GetRowNumber("General & Admin Total"), SalesRow, GetRowNumber("General & Admin %"))    'General And Admin   % 
            AddExpressionToRow("OthersPayroll(Column[])", GetRowNumber("Others Payroll"), True)
            AddExpressionToRow("Sum([R{#'Operating Expenses.Other Expenses'+1}:R[-1]])", GetRowNumber("Others Total")) 'Total Cost of Expense Others
            '  MakePercentageRow(GetRowNumber("Others Total"), SalesRow, GetRowNumber("Others %"))    'Others %
            AddExpressionToRow("Round(R{#'Sales & Marketing Total'}+R{#'General & Admin Total'}+R{#'Others Total'},0)", GetRowNumber("Total Operating Expenses"))          'Total Operating Expenses
        Else
            AddExpressionToRow("TotalPayroll(Column[])", GetRowNumber("Payroll Expense"), True)
            AddExpressionToRow("Round(Sum([R{#'Operating Expenses'+1}:R[-1]]),0)", GetRowNumber("Total Operating Expenses"))               'Total Operating Expenses
            MakeSumColumn(1, 12, GetRowNumber("Operating Expenses") + 1, GetRowNumber("Total Operating Expenses") - 1, 13)
        End If
        'MakeDifferenceRow(GetRowNumber("Gross Margin"), GetRowNumber("Total Operating Expenses"), GetRowNumber("Profit Before Interest and Taxes"))        'Profit before Interest and Taxes


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

    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
        Dim parentId As String
        Dim completeRowName As String
        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")

            'Dim SetPosotion As String = ""
            'Try
            '    AddExpenseAccount(RowName, SetPosotion)
            '    Return True
            'Catch ex As Exception
            '    Return False
            ' End Try
        ElseIf (Position <> -1) Then

            If _currentPlan.DisplayExpense = True Then
                If Position = 0 Then Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")
                If expenseHeading.Contains(RowName.ToUpper.Trim) = True Then Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
                completeRowName = GetRowName(Position) & RowName
                If Not rowNameExists(completeRowName, Position) Then
                    Try
                        parentId = GetParentId(Position)
                        AddExpenseAccount(RowName, Me.Rows(Position).Item("id"), parentId)
                        Return True
                    Catch ex As Exception
                        Return False
                    End Try
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
                End If
            Else
                If Not rowNameExists(RowName, Position) Then
                    Try
                        AddExpenseAccount(RowName, Me.Rows(Position).Item("id"), "U_10")
                        Return True
                    Catch ex As Exception
                        Return False
                    End Try
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
                End If
            End If
            End If
    End Function

    Private Sub AddExpenseAccount(ByVal Name As String, ByVal UIId As Object, ByVal ParentId As String)
        Dim commandDetail As New InfiniCommand("BPL_InsertOperatingExpense")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@ExpenseName", Name)
        commandDetail.AddParameter("@UIId", UIId)
        commandDetail.AddParameter("@ParentId", ParentId)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub

    Public Overrides Function DeleteRow(ByVal RowNumber As Integer) As Boolean
        Try
            Dim ID As String = CStr(Rows(RowNumber)("ID"))
           
            If ID.Length > 0 Then

                strOtherDeptRowDel = DeleteExpenseAccount_Row(ID)
                If strOtherDeptRowDel = "Other" Or strOtherDeptRowDel = "Depreciation" Then
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")

                Else
                    DeleteExpenseAccount(ID)
                End If



            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            End If
            Return True
        Catch ex As Exception

            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            Return False
        End Try
    End Function

    Private Sub DeleteExpenseAccount(ByVal AccountID As String)
        Dim commandDetail As New InfiniCommand("BPL_DeleteExpenseAccount")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@PlanId", _currentplan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub

    Private Function DeleteExpenseAccount_Row(ByVal AccountID As String) As String
        Dim commandDetail As New InfiniCommand("BPL_DeleteExpenseAccount_row")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@PlanId", _currentplan.PlanID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(_connData, commandDetail), SqlDataReader)
        If rd.Read Then

            Return CStr(rd(0))
        End If


    End Function


    Public Overrides Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        If Not rowNameExists(NewName, RowNumber) Then
            If Trim(NewName) = "" Then Return False
            Dim rowID As String = CStr(Rows(RowNumber)("ID"))
            If ProRowHash.Count <> 0 Then
                If ProRowHash.ContainsKey(rowID) Then
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_LinkedRow")
                    Return False
                End If
            End If
            Try
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    strOtherDeptRowRen = RenameExpenseAccount_Row(ID)
                    If strOtherDeptRowRen = "Other" Or strOtherDeptRowRen = "Depreciation" Then
                        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                    Else
                        RenameExpenseAccount(ID, NewName)
                    End If
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                End If
                Return True
            Catch ex As Exception
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                Return False
            End Try
        Else
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        End If
    End Function

    Private Sub RenameExpenseAccount(ByVal AccountID As String, ByVal NewName As String)
        Dim commandDetail As New InfiniCommand("BPL_RenameExpenseCategory")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@expenseName", NewName)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Sub

    Private Function RenameExpenseAccount_Row(ByVal AccountID As String) As String
        Dim commandDetail As New InfiniCommand("BPL_RenameExpenseCategory_row")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(_connData, commandDetail), SqlDataReader)
        If rd.Read Then

            Return CStr(rd(0))
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

    Public Overrides Function RowNum(ByVal Position As Integer) As Object
        If (Position = -1) Then
            Return ""
        Else
            Return (Me.Rows(Position).Item("id"))
        End If


    End Function
    Private Function GetParentId(ByVal position As Integer) As String
        Dim tablePosition As Integer = 0

        If position >= GetRowNumber("Sales And Marketing Expenses") And position <= GetRowNumber("Sales & Marketing Total") Then tablePosition = 1
        If position >= GetRowNumber("General & Admin Expenses") And position <= GetRowNumber("General & Admin Total") Then tablePosition = 2
        If position >= GetRowNumber("Other Expenses") And position <= GetRowNumber("Others Total") Then tablePosition = 3

        Return ds.Tables(tablePosition).Rows(0).Item("ParentId").ToString
    End Function
    Function GetRowName(ByVal position As Integer) As String
        Dim completeRowName As String

        If position >= GetRowNumber("Sales And Marketing Expenses") And position <= GetRowNumber("Sales & Marketing Total") Then
            completeRowName = "Operating Expenses.Sales And Marketing Expenses.Sales And Marketing Payroll."
        End If
        If position >= GetRowNumber("General & Admin Expenses") And position <= GetRowNumber("General & Admin Total") Then
            completeRowName = "Operating Expenses.General & Admin Expenses.Payroll Burden."
        End If
        If position >= GetRowNumber("Other Expenses") And position <= GetRowNumber("Others Total") Then
            completeRowName = "Operating Expenses.Other Expenses.Others Payroll."
        End If

        Return completeRowName
    End Function
    Sub AddExpenseHeadings()
        expenseHeading.Add(UCase("Operating Expenses"))
        expenseHeading.Add(UCase("Sales And Marketing Expenses"))
        expenseHeading.Add(UCase("Sales And Marketing Payroll"))
        expenseHeading.Add(UCase("Sales & Marketing Total"))
        expenseHeading.Add(UCase("General & Admin Expenses"))
        expenseHeading.Add(UCase("General & Admin Payroll"))
        expenseHeading.Add(UCase("Payroll Burden"))
        expenseHeading.Add(UCase("General & Admin Total"))
        expenseHeading.Add(UCase("Other Expenses"))
        expenseHeading.Add(UCase("Others Payroll"))
        expenseHeading.Add(UCase("Others Total"))
    End Sub
End Class
