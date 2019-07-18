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

Public Class Milestones
    Inherits BusinessTable
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Milestones"
        Caption = "Milestones"

        Dim command As New InfiniCommand("BPL_GetMilestones")
        'Dim command As New InfiniCommand("BPL_GetMilestoneTable")
        'command.AddParameter("@PlanID", currentPlan.PlanID)
        command.AddParameter("@PlanID", currentPlan.PlanID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
       PopulateDataTable(ds, currentPlan)
        PostProcess()
    End Sub
#End Region
#Region "Private Methods"
    Private Sub PopulateDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()
        AddDBTable(ds.Tables(0), 0)
        AddNewRow("Total Budget", currentPlan.Currency)
        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToCell("Sum([R0:R[-1]])", GetRowNumber("Total Budget"), 3)
        Else
            AddExpressionToCell("0", GetRowNumber("Total Budget"), 3)
        End If
    End Sub
    Private Function SaveMilestoneData(ByRef MilestoneArrList As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As New Milestone
        Dim x As Object
        For Each x In MilestoneArrList
            command = New InfiniCommand("BPL_UpdateMilestone")
            sp = CType(x, Milestone)
            command.AddParameter("@PlanID", sp.BizID)
            command.AddParameter("@MilestoneID", sp.MilestoneNo)
            command.AddParameter("@MilestoneName", sp.MilestoneName)
            command.AddParameter("@PlanstartDate", sp.PlanStartDate)
            command.AddParameter("@PlanendDate", sp.PlanEndDate)
            command.AddParameter("@Budget", sp.Budget)
            command.AddParameter("@Manager", sp.Manager)
            command.AddParameter("@Department", sp.Department)
            DataAccess.ExecuteNonQuery(_connData, command)
        Next
    End Function
    Private Function AddMilestone(ByVal Name As String, ByVal UIId As Object) As Boolean
        Dim command As New InfiniCommand("BPL_InsertMilestone")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@MilestoneName", Name)
        command.AddParameter("@UIId", UIId)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function DeleteMilestone(ByVal MilestoneID As String) As Boolean
        Dim command As New InfiniCommand("BPL_DeleteMilestone")
        command.AddParameter("@MilestoneID", MilestoneID)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function RenameMilestone(ByVal MilestoneID As String, ByVal NewName As String) As Boolean
        Dim command As New InfiniCommand("BPL_RenameMilestone")
        command.AddParameter("@MilestoneID", MilestoneID)
        command.AddParameter("@MilestoneName", NewName)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
#End Region
#Region "Public Methods "
    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean

        'If Not rowNameExists(RowName, Position) Then
        '    Try
        '        AddMilestone(RowName)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'Else
        '    Throw New BizPlanDBInvalidDataException("Row Already Exists.")
        'End If

        '--------------------------------

        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")

            'Dim SetPosotion As String = ""
            'Try
            '    AddMilestone(RowName, SetPosotion)

            '    'AddMarketSegment(RowName, SetPosotion)
            '    Return True
            'Catch ex As Exception
            '    Return False
            'End Try
        ElseIf (Position <> -1) Then
            If Not rowNameExists(RowName, Position) Then
                Try
                    AddMilestone(RowName, Me.Rows(Position).Item("id"))

                    '  AddMarketSegment(RowName, Me.Rows(Position).Item("id"))
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
                Return DeleteMilestone(ID)
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
            End If
            Return True
        Catch ex As Exception
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellDeleteError")
        End Try
    End Function
    Public Overrides Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        If Not rowNameExists(NewName, RowNumber) Then
            If Trim(NewName) = "" Then Return False
            Try
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    RenameMilestone(ID, NewName)
                Else
                    Throw New BizPlanDBInvalidDataException("Rename Operation not allowed on Selected cell.")

                End If
                Return True
            Catch ex As Exception

                Throw New BizPlanDBInvalidDataException("Rename Operation not allowed on Selected cell.")

            End Try
        Else
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        End If
    End Function
    Public Overrides Sub Save()
        Dim numVal() As String

        Dim MilestoneArrList As New ArrayList
        Dim dr As DataRowView
           Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")

            If (numVal(1).TrimStart("0"c) > "0") Then
                '  i += 1
                'If Not (REValidator.IsShortUKDate(CStr(dr(1))) And REValidator.IsShortUKDate(CStr(dr(2))) And REValidator.IsDecimal(CStr(dr(3)), 0) And REValidator.IsName(CStr(dr(4))) And REValidator.IsName(CStr(dr(5)))) Then
                'Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                ' End If
                Dim tempMilestone As New Milestone
                tempMilestone.BizID = _CurrentPlan.PlanID
                tempMilestone.MilestoneNo = CStr(e.Row("ID"))
                tempMilestone.MilestoneName = CStr(e.Row(0))
                tempMilestone.PlanStartDate = DateTime.Parse(CStr(e.Row(1)))
                tempMilestone.PlanEndDate = DateTime.Parse(CStr(e.Row(2)))
                tempMilestone.Budget = CType(e.Row(3), Double)
                
                tempMilestone.Manager = CStr(e.Row(4))
                tempMilestone.Department = CStr(e.Row(5))
                MilestoneArrList.Add(tempMilestone)
            End If

        Next
        SaveMilestoneData(MilestoneArrList)
        MilestoneArrList.Clear()
        Saved()
    End Sub
#End Region
#Region "Protected Methods"
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Milestones", GetType(String)))
        Columns.Add(New DataColumn("Plan Start Date", GetType(String)))
        Columns.Add(New DataColumn("Plan End Date", GetType(String)))
        Columns.Add(New DataColumn("Budget", GetType(String)))
        Columns.Add(New DataColumn("Manager", GetType(String)))
        Columns.Add(New DataColumn("Department", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub
#End Region
End Class
