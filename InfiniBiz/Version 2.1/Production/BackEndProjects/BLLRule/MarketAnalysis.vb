'Changed by - Win-saira

Option Strict On
Option Explicit On 
#Region "................Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common
#End Region

Public Class MarketAnalysis
    Inherits BusinessTable

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "MarketAnalysis"

        Caption = "Market Analysis"

        Dim command As New InfiniCommand("BPL_GetMarketAnalysis")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        PopulateDataTable(ds, currentPlan)

        PostProcess()
    End Sub
#End Region
#Region "...................Public Methods"
    'Changed by : Saira 
    'Date : 11 Mar 2006 

    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
        'If Not rowNameExists(RowName, Position) Then
        '    Try
        '        If (Position = -1) Then
        '            Position = 0
        '        End If
        '        AddMarketSegment(RowName, Me.Rows(Position).Item("id"))
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'Else
        '    Throw New BizPlanDBInvalidDataException("Row Already Exists.")
        'End If

        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")
            'Dim SetPosotion As String = ""
            'Try
            '    AddMarketSegment(RowName, SetPosotion)
            '    Return True
            'Catch ex As Exception
            '    Return False
            'End Try
        ElseIf (Position <> -1) Then
            If Not rowNameExists(RowName, Position) Then
                Try
                    AddMarketSegment(RowName, Me.Rows(Position).Item("id"))
                    Return True
                Catch ex As Exception
                    Return False
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
                DeleteMarketSegment(ID)
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")

            End If
            Return True
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
                    RenameMarketSegment(ID, NewName)
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
        Dim MarketAnalysisArr As New ArrayList
        Dim NewText As String
        Dim numVal() As String
        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")

            If (numVal(1).TrimStart("0"c) > "0") Then

                '   If (Val(e.Row("ID")) > 0) Then
                If Not (e.Column.Ordinal = 7 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    If Not REValidator.IsDecimal(NewText, 0) Then
                        Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                    End If
                    ' Update for All Columns Except Totals And ID
                    Dim tmpMarketAnalysisObj As MarketAnalysisCell
                    tmpMarketAnalysisObj = New MarketAnalysisCell
                    tmpMarketAnalysisObj.CellBizID = _CurrentPlan.PlanID
                    tmpMarketAnalysisObj.CellYear = e.Column.ColumnName
                    tmpMarketAnalysisObj.PCID = CStr(e.Row(8))
                    tmpMarketAnalysisObj.CellTitle = CStr(e.Row(0))
                    tmpMarketAnalysisObj.GrowthRate = CSng(e.Row(1))
                    tmpMarketAnalysisObj.AnalysisValue = CSng(Val(NewText.TrimEnd(CChar("%"))))
                    MarketAnalysisArr.Add(tmpMarketAnalysisObj)
                End If
            End If
        Next
        If (MarketAnalysisArr.Count > 0) Then
            SaveMarketAnalysis(MarketAnalysisArr)
            MarketAnalysisArr.Clear()
        End If
        Saved()
    End Sub
    ' This method is used in charts
    Public Shared Function GetMarketAnalysis2(ByRef connData As ConnectionData, ByVal businessID As Integer) As ArrayList

        Dim command As New InfiniCommand("BPL_GetMarketAnalysis")
        command.AddParameter("@PlanID", businessID)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, command)


        Dim categoryList As New ArrayList(20)

        While reader.Read
            ' Build a startup cell 
            Dim tempCell As New MarketAnalysisCell
            tempCell.CellTitle = CStr(reader(0))
            tempCell.GrowthRate = CSng(reader(1))
            tempCell.CellYear = CStr(reader(2))
            tempCell.AnalysisValue = CSng(reader(3))
            tempCell.PCID = CType((reader(6)), String)
            ' Add it into the array list 
            categoryList.Add(tempCell)
        End While

        Return categoryList
    End Function
    ' Modified by Saira 
    ' Date - 9/3/2006
    Private Function SaveMarketAnalysis(ByVal MarketAnalysisArrList As ArrayList) As Boolean
        Dim sp As New MarketAnalysisCell
        Dim x As Object
        Dim command As InfiniCommand

        For Each x In MarketAnalysisArrList
            command = New InfiniCommand("BPL_UpdateMarketAnalysis")
            sp = CType(x, MarketAnalysisCell)
            command.AddParameter("@Period", sp.CellYear)
            command.AddParameter("@PCID", sp.PCID)
            command.AddParameter("@PlanID", sp.CellBizID)
            command.AddParameter("@maValue", sp.AnalysisValue)
            Try
                DataAccess.ExecuteNonQuery(_connData, command)
            Catch e As Exception
                Throw e
                Return False
            End Try
        Next
    End Function
#End Region

#Region "..................... Private Methods"
    Private Function AddMarketSegment(ByVal Name As String, ByVal UIId As Object) As Boolean
        Dim command As New InfiniCommand("BPL_InsertMarketSegment")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@SegmentName", Name)
        command.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function DeleteMarketSegment(ByVal SegmentID As String) As Boolean
        Dim command As New InfiniCommand("BPL_DeleteMarketSegment")
        command.AddParameter("@SegmentID", SegmentID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function RenameMarketSegment(ByVal SegmentID As String, ByVal NewName As String) As Boolean
        Dim command As New InfiniCommand("BPL_RenameMarketSegment")
        command.AddParameter("@SegmentID", SegmentID)
        command.AddParameter("@SegmentName", NewName)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Potential Customers", GetType(String)))
        Columns.Add(New DataColumn("GrowthRate", GetType(String)))
        Columns.Add(New DataColumn("Year0", GetType(String)))
        Columns.Add(New DataColumn("Year1", GetType(String)))
        Columns.Add(New DataColumn("Year2", GetType(String)))
        Columns.Add(New DataColumn("Year3", GetType(String)))
        Columns.Add(New DataColumn("Year4", GetType(String)))
        Columns.Add(New DataColumn("CAGR", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub

    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()
        AddDBTable(ds.Tables(0), 0)
        AddNewRow("Total", "")
        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R0:R[-1]])", GetRowNumber("Total"))
            'AddExpressionToCell("C7", GetRowNumber("Total"), 1)
            AddExpressionToColumn("Round(IfNotZero(C2)*(100*(((C[-1]/C2)^(1/4))-1)),2)&'%'", 0, GetRowNumber("Total"), 7)
            AddExpressionToCell("Round(IfNotZero(C2)*(100*(((Sum([R0C6:R[-1]C6])/Sum([R0C2:R[-1]C2]))^(1/4))-1)),2)&'%'", GetRowNumber("Total"), 1)

        Else
            AddExpressionToRow("0", GetRowNumber("Total"))
            AddExpressionToColumn("Round(0,2)&'%'", 0, GetRowNumber("Total"), 7)
        End If

    End Sub
#End Region

    Private Sub MarketAnalysis_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        If FunctionName = "IFNOTZERO" Then
            If Val(ParameterList(0)) = 0 Then
                ReturnValue = "0"
            Else
                ReturnValue = "1"
            End If
        End If
    End Sub
End Class
