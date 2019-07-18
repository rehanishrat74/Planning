'Changed by - Win-saira

Option Strict On
Option Explicit On 
#Region "...........Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient

#End Region

Public Class Payroll
    Inherits BusinessTable

    Private GATable As GeneralAssumption
    Private PersonnelBurdenPercent As DataRow
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        GATable = New GeneralAssumption(connData, currentPlan)
        PersonnelBurdenPercent = GATable.GetPersonnelBurdenPercent

        Me.TableName = "Payroll"
        Caption = "Payroll"

        Dim ds As DataSet
        If currentPlan.DisplayExpense Then
            Dim commandDetail As New InfiniCommand("BPL_GetPayrollDetailsCategorized")
            commandDetail.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, commandDetail)
        Else
            Dim commandDetail As New InfiniCommand("BPL_GetPayrollDetails")
            commandDetail.AddParameter("@PlanID", currentPlan.PlanID)
            ds = DataAccess.ExecuteDataSet(connData, commandDetail)
        End If
        PopulateDataTable(ds, currentPlan)

        PostProcess()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()

        If _currentPlan.DisplayExpense = True Then
            AddNewRow("Production Personnel", "")
            AddDBTable(ds.Tables(0), 1)
            AddNewRow("-Sub Total", currentPlan.Currency)
            AddNewRow("", "")
            AddNewRow("Sales And Marketing Personnel", "")
            AddDBTable(ds.Tables(1), 1)
            AddNewRow("-Sub Total", currentPlan.Currency)
            AddNewRow("", "")
            AddNewRow("General And Administration Personnel", "")
            AddDBTable(ds.Tables(2), 1)
            AddNewRow("-Sub Total", currentPlan.Currency)
            AddNewRow("", "")
            AddNewRow("Other Personnel", "")
            AddDBTable(ds.Tables(3), 1)
            AddNewRow("-Sub Total", currentPlan.Currency)
        Else
            AddNewRow("Personnel", "")
            AddDBTable(ds.Tables(0), 1)
            AddNewRow("-Sub Total", currentPlan.Currency)
        End If
        AddNewRow("", "")

        AddNewRow("Total Payroll", currentPlan.Currency)
        AddNewRow("Payroll Burden", currentPlan.Currency)
        AddNewRow("Total Payroll Expenditures", currentPlan.Currency)


        If _currentPlan.DisplayExpense = True Then
            MakeSumColumn(1, 12, GetRowNumber("Production Personnel") + 1, GetRowNumber("Production Personnel.Sub Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("Sales And Marketing Personnel") + 1, GetRowNumber("Sales And Marketing Personnel.Sub Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("General And Administration Personnel") + 1, GetRowNumber("General And Administration Personnel.Sub Total") - 1, 13)
            MakeSumColumn(1, 12, GetRowNumber("Other Personnel") + 1, GetRowNumber("Other Personnel.Sub Total") - 1, 13)

            If ds.Tables(0).Rows.Count > 0 Then
                AddExpressionToRow("Sum([R{#'Production Personnel'+1}:R[-1]])", GetRowNumber("Production Personnel.Sub Total"))
            Else
                AddExpressionToRow("0", GetRowNumber("Production Personnel.Sub Total"))
            End If
            If ds.Tables(1).Rows.Count > 0 Then
                AddExpressionToRow("Sum([R{#'Sales And Marketing Personnel'+1}:R[-1]])", GetRowNumber("Sales And Marketing Personnel.Sub Total"))
            Else
                AddExpressionToRow("0", GetRowNumber("Sales And Marketing Personnel.Sub Total"))
            End If
            If ds.Tables(2).Rows.Count > 0 Then
                AddExpressionToRow("Sum([R{#'General And Administration Personnel'+1}:R[-1]])", GetRowNumber("General And Administration Personnel.Sub Total"))
            Else
                AddExpressionToRow("0", GetRowNumber("General And Administration Personnel.Sub Total"))
            End If
            If ds.Tables(3).Rows.Count > 0 Then
                AddExpressionToRow("Sum([R{#'.Other Personnel'+1}:R[-1]])", GetRowNumber("Other Personnel.Sub Total"))
            Else
                AddExpressionToRow("0", GetRowNumber("Other Personnel.Sub Total"))
            End If
            AddExpressionToRow("R{#'Production Personnel.Sub Total'}+R{#'Sales And Marketing Personnel.Sub Total'}+R{#'General And Administration Personnel.Sub Total'}+R{#'Other Personnel.Sub Total'}", GetRowNumber("Total Payroll"))
        Else
            MakeSumColumn(1, 12, GetRowNumber("Personnel") + 1, GetRowNumber("Personnel.Sub Total") - 1, 13)
            If ds.Tables(0).Rows.Count > 0 Then
                AddExpressionToRow("Sum([R{#'Personnel'+1}:R[-1]])", GetRowNumber("Personnel.Sub Total"))
            Else
                AddExpressionToRow("0", GetRowNumber("Personnel.Sub Total"))
            End If
            AddExpressionToRow("R{#'Personnel.Sub Total'}", GetRowNumber("Total Payroll"))
        End If
        AddExpressionToRow("(PersonnelBurden[Column[]]*R{#'Total Payroll'})/100", GetRowNumber("Payroll Burden"))
        AddExpressionToCell("Sum([R" + GetRowNumber("Payroll Burden").ToString() + "C1:R" + GetRowNumber("Payroll Burden").ToString() + "C12])", GetRowNumber("Payroll Burden"), 13)
        'AddExpressionToCell("R17C1+R17C2+R17C3+R17C4+R17C5+R17C6+R17C7+R17C8+R17C9+R17C10+R17C11+R17C12", GetRowNumber("Payroll Burden"), 13)
        AddExpressionToRow("R{#'Total Payroll'}+R{#'Payroll Burden'}", GetRowNumber("Total Payroll Expenditures"))
    End Sub
    Private Function UpdatePayrollData(ByRef connData As ConnectionData, ByVal BusinessId As String, ByVal PayrollArrList As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As PeriodicCellValue
        For Each sp In PayrollArrList
            command = New InfiniCommand("BPL_UpdateExpenseValue")
            command.AddParameter("@PlanID", BusinessId)
            command.AddParameter("@expenseID", sp.CategoryID)
            command.AddParameter("@PeriodName", sp.PeriodID)
            command.AddParameter("@expenseValue", sp.Value)
            Try
                DataAccess.ExecuteNonQuery(connData, command)
            Catch e As Exception
                Throw New BizPlanDBInvalidDataException("Formate Error ")

            End Try
        Next
    End Function
    Private Function AddPayrollAccount(ByVal Name As String, ByVal UIid As Object) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_InsertPayrollAccount")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@AccountName", Name)
        commandDetail.AddParameter("@UIId", UIid)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function AddProductionPayrollAccount(ByVal Name As String, ByVal UIid As Object) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_InsertProductsPayrollAccount")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@AccountName", Name)
        commandDetail.AddParameter("@UIId", UIid)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function AddSalesAndMarketingPayrollAccount(ByVal Name As String, ByVal UIid As Object) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_InsertSalesAndMarketingPayrollAccount")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@AccountName", Name)
        commandDetail.AddParameter("@UIId", UIid)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function AddGeneralAndAdministrativePayrollAccount(ByVal Name As String, ByVal UIid As Object) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_InsertGeneralAndAdministrationPayrollAccount")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@AccountName", Name)
        commandDetail.AddParameter("@UIId", UIid)

        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function AddOtherPayrollAccount(ByVal Name As String, ByVal UIid As Object) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_InsertOtherPayrollAccount")
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        commandDetail.AddParameter("@AccountName", Name)
        commandDetail.AddParameter("@UIId", UIid)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function DeletePayrollAccount(ByVal AccountID As String) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_DeleteExpenseAccount")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
    Private Function RenamePayrollAccount(ByVal AccountID As String, ByVal NewName As String) As Boolean
        Dim commandDetail As New InfiniCommand("BPL_RenameExpenseAccount")
        commandDetail.AddParameter("@ExpenseID", AccountID)
        commandDetail.AddParameter("@ExpenseName", NewName)
        commandDetail.AddParameter("@PlanID", _currentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, commandDetail)
    End Function
#End Region

#Region "Public Methods"
    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
        'If Not rowNameExists(RowName, Position) Then
        '    Try
        '        If _CurrentPlan.DisplayExpense Then
        '            If Position >= GetRowNumber("Production Personnel") And Position <= GetRowNumber("Production Personnel.Sub Total") Then
        '                AddProductionPayrollAccount(RowName, )
        '            ElseIf Position >= GetRowNumber("Sales And Marketing Personnel") And Position <= GetRowNumber("Sales And Marketing Personnel.Sub Total") Then
        '                AddSalesAndMarketingPayrollAccount(RowName)
        '            ElseIf Position >= GetRowNumber("General And Administration Personnel") And Position <= GetRowNumber("General And Administration Personnel.Sub Total") Then
        '                AddGeneralAndAdministrativePayrollAccount(RowName)
        '            ElseIf Position >= GetRowNumber("Other Personnel") And Position <= GetRowNumber("Other Personnel.Sub Total") Then
        '                AddOtherPayrollAccount(RowName)
        '            End If
        '        Else
        '            AddPayrollAccount(RowName)
        '        End If
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'Else
        '    Throw New BizPlanDBInvalidDataException("Row Already Exists.")
        'End If
        Dim SetPosotion As String = ""

        If (Position = -1) Then

            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")

        ElseIf (Position <> -1) Then
            If Not rowNameExists(RowName, Position) Then
                Try
                    If _CurrentPlan.DisplayExpense Then
                        If Position >= GetRowNumber("Production Personnel") And Position <= GetRowNumber("Production Personnel.Sub Total") Then
                            AddProductionPayrollAccount(RowName, Me.Rows(Position).Item("id"))
                        ElseIf Position >= GetRowNumber("Sales And Marketing Personnel") And Position <= GetRowNumber("Sales And Marketing Personnel.Sub Total") Then
                            AddSalesAndMarketingPayrollAccount(RowName, Me.Rows(Position).Item("id"))
                        ElseIf Position >= GetRowNumber("General And Administration Personnel") And Position <= GetRowNumber("General And Administration Personnel.Sub Total") Then
                            AddGeneralAndAdministrativePayrollAccount(RowName, Me.Rows(Position).Item("id"))
                        ElseIf Position >= GetRowNumber("Other Personnel") And Position <= GetRowNumber("Other Personnel.Sub Total") Then
                            AddOtherPayrollAccount(RowName, Me.Rows(Position).Item("id"))
                        End If
                    Else
                        AddPayrollAccount(RowName, Me.Rows(Position).Item("id"))
                    End If
                Catch ex As Exception
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")

                End Try
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
            End If
        End If



    End Function
    Public Overrides Function DeleteRow(ByVal RowNumber As Integer) As Boolean
        Try
            Dim ID As String = CStr(Rows(RowNumber)("ID"))
            If ID.Length > 0 Then
                DeletePayrollAccount(ID)
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
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    RenamePayrollAccount(ID, NewName)
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

    Public Overrides Sub Save()
        Dim PayrollArrList As New ArrayList
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
                        Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                    End If
                    PayrollArrList.Add(New PeriodicCellValue(e.Column.ColumnName.ToUpper, CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (PayrollArrList.Count > 0) Then
            UpdatePayrollData(_ConnData, _CurrentPlan.PlanID, PayrollArrList)
            PayrollArrList.Clear()
        End If
        Saved()
    End Sub
    Public Function GetGeneralAssumptions() As GeneralAssumption
        Return GATable
    End Function
    Public Function GetProductionPayroll() As DataRow
        If _currentPlan.DisplayExpense = True Then
            Return Rows(GetRowNumber("Production Personnel.Sub Total"))
        Else
            Return Rows(0)
        End If
    End Function
    Public Function GetOtherPayroll() As DataRow
        If _currentPlan.DisplayExpense = True Then
            Return Rows(GetRowNumber("Other Personnel.Sub Total"))
        Else
            Return Rows(0)
        End If
    End Function
    Public Function GetTotalPayrollExpenditure() As DataRow
        Return Rows(GetRowNumber("Total Payroll Expenditures"))
    End Function
    Public Function GetPayrollBurden() As DataRow
        Return Rows(GetRowNumber("Payroll Burden"))
    End Function
    Public Function GetTotalPayrollExpense() As DataRow
        Return Rows(GetRowNumber("Total Payroll"))
    End Function
    Public Function GetSalesAndMarketingPayrollExpense() As DataRow
        If _currentPlan.DisplayExpense = True Then
            Return Rows(GetRowNumber("Sales And Marketing Personnel.Sub Total"))
        Else
            Return Rows(0)
        End If
    End Function
    Public Function GetGeneralAndAdministrativePayrollExpense() As DataRow
        If _currentPlan.DisplayExpense = True Then
            Return Rows(GetRowNumber("General And Administration Personnel.Sub Total"))
        Else
            Return Rows(0)
        End If
    End Function
#End Region

    Private Sub Payroll_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "PERSONNELBURDEN"
                ReturnValue = CStr(PersonnelBurdenPercent(CInt(ParameterList(0))))
        End Select
    End Sub
End Class