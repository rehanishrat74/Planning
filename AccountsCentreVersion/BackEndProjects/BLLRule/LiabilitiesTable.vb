Option Strict On  ' Block Implicit Conversions
Option Explicit On  ' Block Undeclared Variable Usage

#Region "Imports  "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient

#End Region

Public Class LiabilitiesTable
    Inherits BusinessTable
    Dim ShortTermBorrowings As DataRow
    Dim LongTermBorrowings As DataRow
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Liabilities"
        Caption = "Liabilities"
        AddHeadings()

        Dim command As New InfiniCommand("BPL_GetBorrowingDetails")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)


        'ShortTermBorrowings = ds.Tables(0).Rows(0)
        'LongTermBorrowings = ds.Tables(0).Rows(1)

        PopulateDataTable(ds, currentPlan)


        PostProcess()
    End Sub
#End Region
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


    Private Function PopulateDataTable(ByVal ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataTable

        AddDBRow(ds.Tables(0).Rows(0), 0, "")
        Rows(0)(0) = "Short Term Borrowings"
        AddNewRow("Short Term Notes", currentPlan.Currency)
        AddDBRow(ds.Tables(0).Rows(1), 0, "")
        Rows(2)(0) = "Short Term Borrowings"
        AddNewRow("Long Term Liabilities", currentPlan.Currency)


        'Short Term Notes
        AddExpressionToRow("R[-1]+C[-1]", 1)
        AddExpressionToCell("StartingSTL()", 1, 0)
        AddExpressionToCell("C[-1]", 1, 13)

        'Long Term Liabilities
        AddExpressionToRow("R[-1]+C[-1]", 3)
        AddExpressionToCell("StartingLTL()", 3, 0)
        AddExpressionToCell("C[-1]", 3, 13)

        Dim i As Integer
        For i = 0 To Rows.Count - 1
            Rows(i)("ID") = ""
        Next
    End Function
#End Region

    Private Sub BalanceSheet_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
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
        End Select
    End Sub
End Class