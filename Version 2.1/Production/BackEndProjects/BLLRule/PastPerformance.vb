'Changed by - Win-saira

Option Strict On
Option Explicit On 

#Region "Imports Statements "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data
Imports System.Data.SqlClient

#End Region

Public Class PastPerformance
    Inherits BusinessTable

    Dim inventory As Boolean

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        Me.TableName = "PastPerformance"
        Caption = "Past Performance"

        Dim commandDetail As New InfiniCommand("BPL_GetPastPerformance")
        commandDetail.AddParameter("@PlanID", currentPlan.PlanID)

        Dim dsDetail As DataSet = DataAccess.ExecuteDataSet(connData, commandDetail)

        Dim command As New InfiniCommand("BPL_GetPastPerformanceCategories")
        command.AddParameter("@PlanID", currentPlan.PlanID)

        Dim dsCat As DataSet = DataAccess.ExecuteDataSet(connData, command)

        inventory = currentPlan.ManageInventory
        PopulateDataTable(dsCat, dsDetail, currentPlan)
        PostProcess()
    End Sub
#End Region
    Public Overrides Sub Save()
        Dim PastPerformanceArrList As New ArrayList(10)
        Dim performanceYear As Integer
        Dim numVal() As String

        Dim StartupArrList As New ArrayList
        Dim NewText As String
        Dim Row As Integer, Column As Integer
        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")
            If (numVal(1).TrimStart("0"c) > "0") Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    PastPerformanceArrList.Add(New CellValue(CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (PastPerformanceArrList.Count > 0) Then
            UpdatePastPerformance(_ConnData, PastPerformanceArrList)
            PastPerformanceArrList.Clear()
        End If
        Saved()
    End Sub
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Heading", GetType(String)))
        Columns.Add(New DataColumn(" ", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub
#Region "Past Performance Operations"
    Public Shared Function GetPastPerformanceYear(ByVal connData As ConnectionData, ByVal businessID As String) As String

        Dim command As New InfiniCommand("BPL_GetPastPerformanceYear")
        command.AddParameter("@PlanID", businessID)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, command)

        Dim year As String = "unKnown"
        If reader.Read Then
            year = CStr(reader(0))
        End If
        Return year
    End Function
    Public Shared Function GetPastPerformanceDetails(ByVal connData As ConnectionData, ByVal businessID As String) As ArrayList
        Dim command As New InfiniCommand("BPL_GetPastPerformance")
        command.AddParameter("@PlanID", businessID)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, command)
        Dim details As New ArrayList(10)
        Dim tmpCell As PastPerformanceCell
        While reader.Read
            tmpCell = New PastPerformanceCell
            tmpCell.AccountParentID = CStr(reader(1))

            tmpCell.AccountID = CStr(reader(2))
            tmpCell.AccountName = CStr(reader(3))
            tmpCell.PerformanceYear = CInt(reader(4))
            tmpCell.PerformanceValue = CInt(reader(5))
            details.Add(tmpCell)
        End While
        Return details
    End Function
    Public Function UpdatePastPerformance(ByVal connData As ConnectionData, ByRef PastPerf As ArrayList) As Boolean
        Dim command As New InfiniCommand("BPL_UpdatePastPerformanceCell")
        Dim sp As CellValue
        For Each sp In PastPerf
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@accountID", sp.CategoryID)
            command.AddParameter("@performanceYear", CStr(CInt(_CurrentPlan.StartYear) - 1))
            command.AddParameter("@performanceValue", sp.Value)
            DataAccess.ExecuteNonQuery(connData, command)
            command.ClearParameters()
        Next
    End Function

    Public Shared Function GetPastPerformance(ByRef conndata As ConnectionData, ByVal businessid As String) As PastperformanceTable
        Dim ppDetails As ArrayList = PastPerformance.GetPastPerformanceDetails(conndata, businessid)
        Dim categoryName As String
        Dim PastPerformanceData As New PastperformanceTable
        Dim ppCell As PastPerformanceCell
        For Each ppCell In ppDetails
            PastPerformanceData.Year = CInt(ppCell.PerformanceYear)
            Select Case (Trim(ppCell.AccountName))
                Case "Sales"
                    PastPerformanceData.Sales = ppCell.PerformanceValue
                Case "Gross Margin"
                    PastPerformanceData.GrossMargin = ppCell.PerformanceValue
                Case "Collection period (days)"
                    PastPerformanceData.CollectionPeriod = ppCell.PerformanceValue
                Case "Inventory turnover"
                    PastPerformanceData.InventoryTurnOver = ppCell.PerformanceValue
                Case "Operating Expenses"
                    PastPerformanceData.OperatingExpenses = ppCell.PerformanceValue
                Case "Cash"
                    PastPerformanceData.Cash = ppCell.PerformanceValue
                Case "Accounts receiveable"
                    PastPerformanceData.AccountsReceiveable = ppCell.PerformanceValue
                Case "Inventory"
                    PastPerformanceData.Inventory = ppCell.PerformanceValue
                Case "Other Short-term Assets"
                    PastPerformanceData.OtherShortTermAssets = ppCell.PerformanceValue
                Case "Capital Assets"
                    PastPerformanceData.CapitalAssets = ppCell.PerformanceValue
                Case "Accumulated Depreciation"
                    PastPerformanceData.AccumulatedDepreciation = ppCell.PerformanceValue
                Case "Short-term Notes"
                    PastPerformanceData.ShortTermNotes = ppCell.PerformanceValue
                Case "Other ST Liabilities"
                    PastPerformanceData.OtherShortTermLiabilities = ppCell.PerformanceValue
                Case "Accounts Payable"
                    PastPerformanceData.AccountsPayable = ppCell.PerformanceValue
                Case "Long-term Liabilities"
                    PastPerformanceData.LongTermLiabilities = ppCell.PerformanceValue
                Case "Paid in Capital"
                    PastPerformanceData.PaidInCapital = ppCell.PerformanceValue
                Case "Retained Earnings"
                    PastPerformanceData.RetainedEarning = ppCell.PerformanceValue
                Case "Earnings"
                    PastPerformanceData.Earning = ppCell.PerformanceValue
                Case "Payment days"
                    PastPerformanceData.PaymentDays = ppCell.PerformanceValue
                Case "Sales on credit"
                    PastPerformanceData.SalesOnCreditPercent = ppCell.PerformanceValue
            End Select
        Next
        Return PastPerformanceData
    End Function
#End Region

#Region "Performance NEW DataTable"
    Private Function PopulateDataTable(ByRef dsCat As DataSet, ByVal dsDetail As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataTable
        Dim drTemp As DataRow
        Dim dt As BusinessTable = Me
        Dim i As Integer = 1
        Dim dtNo As Integer = 0

        AddHeadings()

        Dim dr As DataRow

        Dim x As Integer
        Dim Rowno As Integer = 0
        Dim CatID As String = "U_0"
        Dim ExpenseId As Integer = 0


        For Each drTemp In dsDetail.Tables(0).Rows
            If CatID <> CStr(drTemp(1)) Then
                CatID = CStr(drTemp(1))
                If CatID = "U_1" Then
                    AddNewRow("Past Performance", "")
                End If

                If CatID = "U_2" Then
                    AddNewRow("", "")
                    AddNewRow("Short-term Assets", "")
                End If

                If CatID = "U_3" Then
                    AddNewRow("-Total Short-term Assets", currentPlan.Currency)
                    AddNewRow("", "")
                    AddNewRow("Long-term Assets", "")
                End If

                If CatID = "U_4" Then
                    AddNewRow("-Total Long-term Assets", currentPlan.Currency)
                    AddNewRow("-Total Assets", currentPlan.Currency)
                    AddNewRow("", "")
                    AddNewRow("Short-term Liabilities", "")
                End If

                If CatID = "U_5" Then
                    AddNewRow("-Total Short-term Liabilities", currentPlan.Currency)
                    AddNewRow("", "")
                    AddNewRow("Long-term Liabilities", "")
                End If

                If CatID = "U_6" Then
                    AddNewRow("-Total Long-term Liabilities", currentPlan.Currency)
                    AddNewRow("-Total Liabilities", currentPlan.Currency)
                    AddNewRow("", "")
                    AddNewRow("Capital", "")
                End If

                If CatID = "U_7" Then
                    '  AddNewRow("-Retained Earning")
                    AddNewRow("-Total Capital", currentPlan.Currency)
                    AddNewRow("-Total Liabilities and Capital", currentPlan.Currency)
                    AddNewRow("", "")
                    AddNewRow("Others", "")
                End If

                'CatID = CInt(drTemp(1))

            End If
            dr = Me.NewRow

            If ((CStr(drTemp(2)) = "U_14" Or CStr(drTemp(2)) = "U_11") And inventory) Or CStr(drTemp(2)) <> "U_14" Then
                dr(0) = "-" & CStr(drTemp(3))
                dr(1) = CStr(drTemp(5))
                dr(2) = CStr(drTemp(2))
                If (CStr(dr(2)) = "U_9" Or CStr(dr(2)) = "U_10" Or CStr(dr(2)) = "U_11" Or CStr(dr(2)) = "U_24") Then
                    Me.AddDBRow(dr, 0, "")
                Else
                    Me.AddDBRow(dr, 0, _CurrentPlan.Currency)
                End If
            End If

            If UCase(CStr(drTemp(3)).TrimStart(CChar("-"))) = UCase("Gross Margin") Then
                AddNewRow("-Gross Margin %", "")
                AddExpressionToCell("Round((R[-1]*100)/R[-2],2)&'%'", 3, 1)
            End If
        Next
        AddNewRow("-Receivables turnover", "")

        'AddExpressionToCell("Sum([R[-4]:R[-1]])", 13, 1)    ' Total Short-term Assets
        AddExpressionToCell("Sum([R" + (GetRowNumber("Short-term Assets") + 1).ToString() + ":R[-1]])", GetRowNumber("Total Short-term Assets"), 1) ' Total Short-term Assets
        AddExpressionToCell("R[-2]-R[-1]", GetRowNumber("Total Long-term Assets"), 1)   ' Total Long-term Assets

        AddExpressionToCell("R" + GetRowNumber("Total Short-term Assets").ToString + "+R" + GetRowNumber("Total Long-term Assets").ToString, GetRowNumber("Total Assets"), 1)               ' Total Assets

        AddExpressionToCell("Sum([R[-3]:R[-1]])", GetRowNumber("Total Short-term Liabilities"), 1)    ' Sub-total Short-term Liabilities

        AddExpressionToCell("R[-1]", GetRowNumber("Total Long-term Liabilities"), 1)                 ' Sub-total Long-term Liabilities

        '  AddExpressionToCell("R25+R29", 30, 1)               ' Total Liabilities

        AddExpressionToCell("R" + GetRowNumber("Total Short-term Liabilities").ToString + "+R" + GetRowNumber("Total Long-term Liabilities").ToString, GetRowNumber("Total Liabilities"), 1)               ' Total Assets


        'AddExpressionToCell("R19-(R30+R33+R35)", 34, 1)     ' Retained Earnings

        AddExpressionToCell("R" + GetRowNumber("Total Assets").ToString + "-(R" + GetRowNumber("Total Liabilities").ToString + "+R[-1]+R[1])", GetRowNumber("Total Capital") - 2, 1)   ' Retained Earnings

        AddExpressionToCell("Sum([R[-3]:R[-1]])", GetRowNumber("Total Capital"), 1)    ' Total Capital

        AddExpressionToCell("R" + GetRowNumber("Total Liabilities").ToString + "+R" + GetRowNumber("Total Capital").ToString, GetRowNumber("Total Liabilities and Capital"), 1)               'Total Liabilities and Capital

        AddExpressionToCell("Round(R[-1]/R" + (GetRowNumber("Short-term Assets") + 2).ToString + ",2)", GetRowNumber("Receivables turnover"), 1) ' Receivables Turnover

        Return dt
    End Function
#End Region

End Class
