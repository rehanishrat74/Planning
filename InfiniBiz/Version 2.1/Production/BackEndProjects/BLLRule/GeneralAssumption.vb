'Changed by - Win-saira

Option Strict On
Option Explicit On 
#Region "Imports"

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common

#End Region

Public Class GeneralAssumption
    Inherits BusinessTable

    Protected inventory, sellOnCredit As Boolean

#Region "General Assumptions Operations "
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "GeneralAssumption"
        Caption = "General Assumptions"
        inventory = currentPlan.ManageInventory
        sellOnCredit = currentPlan.SellOnCredit

        Dim command As New InfiniCommand("BPL_GetGeneralAssumptions")
        command.AddParameter("@PlanID", currentPlan.PlanID)

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        PopulateDataTable(ds)
        PostProcess()
    End Sub
    Public Overrides Sub Save()
        Dim _changedCells As New ArrayList
        Dim NewText As String
        Dim numVal() As String

        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")

            If (numVal(1).TrimStart("0"c) > "0") Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    If numVal(1).TrimStart("0"c) = "3" Or numVal(1).TrimStart("0"c) = "4" Or numVal(1).TrimStart("0"c) = "5" Then
                        If Not REValidator.IsPositiveNumber(NewText, 3) Then
                            Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                        End If
                    Else
                        If Not REValidator.IsPercentage(NewText) Then
                            Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                        End If
                    End If
                    ' Update for All Columns Except Totals And ID
                    _changedCells.Add(New PeriodicCellValue(e.Column.ColumnName, strIdVal, NewText))
                End If
            End If
        Next
        If (_changedCells.Count > 0) Then
            Dim tmpCell As PeriodicCellValue
            For Each tmpCell In _changedCells
                UpdateCellValue(tmpCell.CategoryID, tmpCell.PeriodID, CSng(Val(tmpCell.Value)))
            Next
            _changedCells.Clear()
        End If
        Saved()
    End Sub
    Private Function UpdateCellValue(ByVal assumpID As String, ByVal monthName As String, ByVal newValue As Single) As Boolean

        Dim command As New InfiniCommand("BPL_UpdateGeneralAssumtionDetails")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@assumptionID", assumpID)
        command.AddParameter("@monthName", monthName)
        command.AddParameter("@newValue", newValue)
        Try
            DataAccess.ExecuteNonQuery(_connData, command)
        Catch e As Exception
            Return False
        End Try
        Return True
    End Function
#End Region

#Region "Private Methods"
    Private Function PopulateDataTable(ByVal ds As DataSet) As DataTable
        Dim dt As DataTable = Me
        Dim GATable As New DataTable
        Dim drArray As DataRow()
        Dim i, j As Integer

        AddHeadings()
        GATable = ds.Tables(0).Copy()

        i = 0
        Do While i < GATable.Rows.Count
            If CStr(GATable.Rows(i).Item(17)) = "U_5" And Not inventory Then
                GATable.Rows.Remove(GATable.Rows(i))
            ElseIf CStr(GATable.Rows(i).Item(17)) = "U_8" And Not sellOnCredit Then
                GATable.Rows.Remove(GATable.Rows(i))
            ElseIf CStr(GATable.Rows(i).Item(17)) = "U_4" And Not sellOnCredit Then
                GATable.Rows.Remove(GATable.Rows(i))
            Else
                i += 1
            End If
        Loop

        AddDBTable(GATable, 0)
        AddExpressionToColumn("Round(Sum([C1:C12])/12,2)", 0, GATable.Rows.Count - 1, 13)
        If sellOnCredit Then AddExpressionToRow("C[-1]", GetRowNumber("Collection Days Estimator"), 2, 13)
        Return dt
    End Function
#End Region
    Public Function GetShortTermInterestRates() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Short-term Interest Rate %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetLongTermInterestRates() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Long-term Interest Rate %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetPaymentDays() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Payment Days Estimator"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetCollectionDays() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Collection Days Estimator"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetInventoryTurnover() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Inventory Turnover Estimator"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetTaxRates() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Tax Rate %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetExpensesInCash() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Expenses in Cash %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetSalesOnCreditPercent() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Sales on Credit %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
    Public Function GetPersonnelBurdenPercent() As DataRow
        Dim tempRow As DataRow
        Try
            tempRow = Rows(GetRowNumber("Personnel Burden %"))
        Catch ex As Exception
            tempRow = Me.Rows(0)
            For i As Integer = 0 To 17
                tempRow.Item(i) = 0
            Next
        End Try
        Return tempRow
    End Function
End Class
