'Changed by - Win-saira

Option Strict On
Option Explicit On 
#Region "...................... Imports "

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient
Imports Infinilogic.AccountsCentre.DAL

#End Region

Public Class StartupDetails
    Inherits BusinessTable
    Dim inventory As Boolean

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        Me.Currency = currentPlan.Currency
        Me.TableName = "StartupDetails"
        Caption = "Start-up"
        inventory = currentPlan.ManageInventory
        Dim commandDetail As New InfiniCommand("BPL_GetStartupDetails")
        commandDetail.AddParameter("@PlanID", currentPlan.PlanID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, commandDetail)

        PopulateDataTable(ds, currentPlan)

        PostProcess()
    End Sub
#End Region
#Region "Shared Methods"
    Public Shared Shadows ReadOnly Property IsPeriodic() As Boolean
        Get
            Return False
        End Get
    End Property
    Public Shared Function GetStartupCategories(ByRef connData As ConnectionData, ByVal BusinessID As String) As ArrayList

        'For Asset And Loans
        Dim command As New InfiniCommand("BPL_GetStartupCategories")
        command.AddParameter("@PlanID", BusinessID)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, command)

        Dim categoryList As New ArrayList(20)

        While reader.Read
            ' Build a startup cell 
            Dim tempCell As New StartupCategory
            tempCell.CategoryID = CStr(reader(0))
            tempCell.CategoryName = CStr(reader(1))
            tempCell.CategoryTotal = CSng(reader(2))
            ' Add it into the array list 
            categoryList.Add(tempCell)
        End While

        Return categoryList
    End Function

    'Public Shared Function InsertStartupCell2(ByVal connData As ConnectionData, ByVal businessID As Integer, ByRef Startup As ArrayList) As Boolean
    '    Dim command As InfiniCommand
    '    Dim sp As New StartupCell
    '    Dim x As Object
    '    For Each x In Startup
    '        sp = CType(x, StartupCell)
    '        command = New InfiniCommand("BPL_InsertStartupValue")
    '        command.AddParameter("@PlanID", businessID)
    '        command.AddParameter("@startupName", Trim(sp.StartupName))
    '        command.AddParameter("@startupValue", sp.startupValue)
    '        DataAccess.ExecuteNonQuery(connData, command)
    '    Next
    'End Function

    Private Function UpdateStartupExpenses(ByRef Startup As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As CellValue
        For Each sp In Startup
            command = New InfiniCommand("BPL_UpdateStartupExpense")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@StartupExpenseID", sp.CategoryID)
            command.AddParameter("@StartupExpenseValue", sp.Value)
            DataAccess.ExecuteNonQuery(_connData, command)
        Next
    End Function
    Private Function UpdateInvestments(ByRef Startup As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As CellValue
        For Each sp In Startup
            command = New InfiniCommand("BPL_UpdateInvestment")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@InvestorID", sp.CategoryID)
            command.AddParameter("@Investment", sp.Value)
            DataAccess.ExecuteNonQuery(_connData, command)
        Next
    End Function
    Private Function UpdateStartupValues(ByRef Startup As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As CellValue
        For Each sp In Startup
            command = New InfiniCommand("BPL_UpdateStartupValue")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@startupID", sp.CategoryID)
            command.AddParameter("@startupValue", sp.Value)
            DataAccess.ExecuteNonQuery(_connData, command)
        Next
    End Function

    Public Shared Function GetStartup(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As StartupTable
        Dim StartupDetails As New StartupDetails(connData, currentPlan)
        Dim StartupData As New StartupTable
        StartupData.CashRequirement = StartupDetails.GetStartupCashRequirements
        StartupData.StartupInventory = StartupDetails.GetStartupInventory
        StartupData.OtherShortTermAssets = StartupDetails.GetOtherShortTermAssets
        StartupData.LongTermAssets = StartupDetails.GetLongTermAssets
        StartupData.UnpaidExpenses = StartupDetails.GetUnpaidExpenses
        StartupData.ShortTermLoan = StartupDetails.GetShortTermLoans
        StartupData.InterestFreeShortTermLiabilities = StartupDetails.GetInterestFreeShortTermLiabilities
        StartupData.LongTermLiabilities = StartupDetails.GetLongTermLiabilities
        StartupData.TotalInvestment = StartupDetails.GetTotalInvestment
        Return StartupData
    End Function
#End Region
#Region "Public Methods"
    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean

        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")
        ElseIf (Position <> -1) Then
            If Not rowNameExists(RowName, Position) Then
                Try
                    If Position >= GetRowNumber("Startup Expenses") And Position <= GetRowNumber("Total Startup Expenses") Then
                        AddStartupExpense(RowName, Me.Rows(Position).Item("id"))
                    ElseIf Position >= GetRowNumber("Investment") And Position <= GetRowNumber("Total Investment") Then
                        AddInvestor(RowName, Me.Rows(Position).Item("id"))
                    Else
                        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellInsertError")
                    End If
                Catch ex As Exception
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellInsertError")
                    ' Return False
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
                If RowNumber > GetRowNumber("Startup Expenses") And RowNumber < GetRowNumber("Total Startup Expenses") Then
                    DeleteStartupExpense(ID)
                ElseIf RowNumber > GetRowNumber("Investment") And RowNumber < GetRowNumber("Total Investment") Then
                    DeleteInvestor(ID)
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
                End If
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            End If
            Return True
        Catch ex As Exception
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            '   Return False
        End Try
    End Function
    Public Overrides Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        'If rowNameExists(NewName, RowNumber) Then Return False
        If rowNameExists(NewName, RowNumber) Then Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        If Trim(NewName) = "" Then Return False
        Try
            Dim ID As String = CStr(Rows(RowNumber)("ID"))
            If ID.Length > 0 Then
                If RowNumber > GetRowNumber("Startup Expenses") And RowNumber < GetRowNumber("Total Startup Expenses") Then
                    RenameStartupExpense(ID, NewName)
                ElseIf RowNumber > GetRowNumber("Investment") And RowNumber < GetRowNumber("Total Investment") Then
                    RenameInvestor(ID, NewName)
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                End If
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
            End If
            Return True
        Catch ex As Exception
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
            ' Return False
        End Try
    End Function
    Public Overrides Sub Save()

        Dim h As New Hashtable(Rows.Count)
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In Rows
            h.Add(dr, i)
            i += 1
        Next
        Dim StartupExpenses As New ArrayList
        Dim Investments As New ArrayList
        Dim StartupValues As New ArrayList
        Dim NewText As String
        Dim numVal() As String

        Dim Row As Integer, Column As Integer
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
                    Dim sc As New CellValue(CStr(e.Row(2)), NewText)
                    Dim RowNumber As Integer = CInt(h(e.Row))  ' GetRowNumber(CStr(e.Row(0)).TrimStart(CChar("-")))
                    If RowNumber > GetRowNumber("Startup Expenses") And RowNumber < GetRowNumber("Total Startup Expenses") Then
                        StartupExpenses.Add(sc)
                    ElseIf RowNumber > GetRowNumber("Investment") And RowNumber < GetRowNumber("Total Investment") Then
                        Investments.Add(sc)
                    Else
                        StartupValues.Add(sc)
                    End If
                End If
            End If
        Next
        If (StartupExpenses.Count > 0) Then
            UpdateStartupExpenses(StartupExpenses)
            StartupExpenses.Clear()
        End If
        If (Investments.Count > 0) Then
            UpdateInvestments(Investments)
            Investments.Clear()
        End If
        If (StartupValues.Count > 0) Then
            UpdateStartupValues(StartupValues)
            StartupValues.Clear()
        End If
        Saved()
    End Sub
    Public Function GetStartupCashRequirements() As Integer
        Return CInt(Rows(GetRowNumber("Cash Requirements"))(1))
    End Function
    Public Function GetStartupInventory() As Integer
        'Return CInt(Rows(GetRowNumber("Startup Inventory"))(1))
        Try
            Return CInt(Rows(GetRowNumber("Startup Inventory"))(1))
        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function GetOtherShortTermAssets() As Integer
        Return CInt(Rows(GetRowNumber("Other Short-term Assets"))(1))
    End Function
    Public Function GetLongTermAssets() As Integer
        Return CInt(Rows(GetRowNumber("Long-term Assets"))(1))
    End Function
    Public Function GetUnpaidExpenses() As Integer
        Return CInt(Rows(GetRowNumber("Unpaid Expenses"))(1))
    End Function
    Public Function GetShortTermLoans() As Integer
        Return CInt(Rows(GetRowNumber("Short-term Loans"))(1))
    End Function
    Public Function GetInterestFreeShortTermLiabilities() As Integer
        Return CInt(Rows(GetRowNumber("Interest-free Short-term Loans"))(1))
    End Function
    Public Function GetLongTermLiabilities() As Integer
        Return CInt(Rows(GetRowNumber("Long-term Liabilities"))(1))
    End Function
    Public Function GetTotalInvestment() As Integer
        Return CInt(Rows(GetRowNumber("Total Investment"))(1))
    End Function
#End Region
#Region "Private Methods"
    Private Function AddStartupExpense(ByVal Name As String, ByVal UIiD As Object) As Boolean
        Dim command As New InfiniCommand("BPL_InsertStartupExpense")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@ExpenseName", Name)
        command.AddParameter("@UIiD", UIiD)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function DeleteStartupExpense(ByVal StartupExpenseID As String) As Boolean
        Dim command As New InfiniCommand("BPL_DeleteStartupExpense")
        command.AddParameter("@StartupExpenseID", StartupExpenseID)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function RenameStartupExpense(ByVal StartupExpenseID As String, ByVal NewName As String) As Boolean
        Dim command As New InfiniCommand("BPL_RenameStartupExpense")
        command.AddParameter("@StartupExpenseID", StartupExpenseID)
        command.AddParameter("@StartupExpenseName", NewName)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function RenameInvestor(ByVal StartupExpenseID As String, ByVal NewName As String) As Boolean
        Dim command As New InfiniCommand("BPL_RenameInvestor")
        command.AddParameter("@InvestorID", StartupExpenseID)
        command.AddParameter("@InvestorName", NewName)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function AddInvestor(ByVal Name As String, ByVal UIiD As Object) As Boolean
        Dim command As New InfiniCommand("BPL_InsertInvestor")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@InvestorName", Name)
        command.AddParameter("@UIiD", UIiD)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function DeleteInvestor(ByVal InvestorID As String) As Boolean
        Dim command As New InfiniCommand("BPL_DeleteInvestor")
        command.AddParameter("@InvestorID", InvestorID)
        command.AddParameter("@PlanId", _currentplan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Heading", GetType(String)))
        Columns.Add(New DataColumn(" ", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub
    ' Modified : Saira
    'Date : 20 Mar 2006 
    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)

        Dim SUtable As New DataTable
        Dim i As Integer = 0


        AddHeadings()
        AddNewRow("Startup Expenses", "")
        AddDBTable(ds.Tables(0), 1)
        AddNewRow("-Total Startup Expenses", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Startup Assets Needed", "")
        SUtable = ds.Tables(1).Copy()

        Do While i < SUtable.Rows.Count
            If CStr(SUtable.Rows(i).Item(2)) = "U_33" And Not inventory Then
                SUtable.Rows.Remove(SUtable.Rows(i))
            End If
            i += 1
        Loop
        AddDBTable(SUtable, 1)
        AddNewRow("-Total Startup Assets Needed", currentPlan.Currency)
        AddNewRow("-Total Startup Requirement", currentPlan.Currency)
        AddNewRow("-Left to Finance", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Startup Funding Plan", "")
        AddNewRow("Investment", currentPlan.Currency)
        AddDBTable(ds.Tables(2), 1)
        AddNewRow("-Total Investment", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Short-term Liabilities", "")
        AddDBTable(ds.Tables(3), 1)
        AddNewRow("-Total Short-term Liabilities", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Long-Term Liabilities", "")
        AddDBTable(ds.Tables(4), 1)
        AddNewRow("-Total Long-term Liabilities", currentPlan.Currency)
        AddNewRow("-Total Liabilities", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("-Gain/Loss at Startup", currentPlan.Currency)
        AddNewRow("-Total Capital", currentPlan.Currency)
        AddNewRow("-Total Liabilities and Capital", currentPlan.Currency)
        AddNewRow("-Check Line", "")

        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToCell("Sum([R{#'Startup Expenses'}:R[-1]])", GetRowNumber("Total Startup Expenses"), 1)
        Else
            AddExpressionToCell("0", GetRowNumber("Total Startup Expenses"), 1)
        End If
        AddExpressionToCell("Sum([R{#'Startup Assets Needed'}:R[-1]])", GetRowNumber("Total Startup Assets Needed"), 1)
        AddExpressionToCell("R{#'Total Startup Expenses'}+R{#'Total Startup Assets Needed'}", GetRowNumber("Total Startup Requirement"), 1)   ' Total Startup Requirements
        AddExpressionToCell("Max(R{#'Total Startup Requirement'}-(R{#'Total Investment'}+R{#'Total Liabilities'}),0)", GetRowNumber("Left to Finance"), 1) ' Left to Finance
        If ds.Tables(2).Rows.Count > 0 Then
            AddExpressionToCell("Sum([R{#'Investment'}:R[-1]])", GetRowNumber("Total Investment"), 1)
        Else
            AddExpressionToCell("0", GetRowNumber("Total Investment"), 1)
        End If
        AddExpressionToCell("Sum([R{#'Short-term Liabilities'}:R[-1]])", GetRowNumber("Total Short-term Liabilities"), 1)
        AddExpressionToCell("Sum([R{#'Long-Term Liabilities'}:R[-1]])", GetRowNumber("Total Long-term Liabilities"), 1)
        AddExpressionToCell("R{#'Total Short-term Liabilities'}+R{#'Total Long-term Liabilities'}", GetRowNumber("Total Liabilities"), 1)   ' Total Liabilities
        AddExpressionToCell("R{#'Total Startup Assets Needed'}-(R{#'Total Investment'}+R{#'Total Liabilities'})", GetRowNumber("Gain/Loss at Startup"), 1) ' Gain/Loss at Startup
        AddExpressionToCell("R{#'Total Investment'}+R{#'Gain/Loss at Startup'}", GetRowNumber("Total Capital"), 1)       ' Total Capital
        AddExpressionToCell("R{#'Total Liabilities'}+R{#'Total Capital'}", GetRowNumber("Total Liabilities and Capital"), 1)       ' Total Capital and Liabilities
        AddExpressionToCell("R{#'Total Startup Assets Needed'}-R{#'Total Liabilities and Capital'}", GetRowNumber("Check Line"), 1)       ' CheckLine
    End Sub
#End Region
End Class
