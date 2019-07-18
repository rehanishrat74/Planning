' Modified by - Win-saira 

Option Strict On
Option Explicit On 
#Region "Imports "

Imports Infinilogic.BusinessPlan.BLL
'Imports Infinilogic.Data
Imports InfiniLogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Common
#End Region

Public Class BreakEvenAnalysis
    Inherits BusinessTable
    Public RatioCurrencyValue As String
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "BreakEvenAnalysis"
        Caption = "Break Even Analysis"
        RatioCurrencyValue = currentPlan.Currency

        Dim cmd As New InfiniCommand("BPL_GetBreakEvenValues")
        cmd.AddParameter("@PlanID", currentPlan.PlanID)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, cmd)

        Dim brEvenValues As New BreakEvenValues
        'Dim count As Integer = 0
        If reader.Read() Then
            brEvenValues.BreakEvenId = CStr(reader(1))
            brEvenValues.PlanID = CStr(reader(2))
            brEvenValues.APURevenue = CSng(reader(3))
            brEvenValues.APUVariableCost = CSng(reader(4))
            brEvenValues.EstMonthlyFixCost = CSng(reader(5))
        End If
        Dim i As Integer = 1
        'Uzair

        AddHeadings()

        Dim dr As DataRow
        AddNewRow("Assumptions:", "")

        dr = AddNewRow("Average Per-unit Revenue", currentPlan.Currency)
        dr(1) = brEvenValues.APURevenue
        dr(2) = 1

        dr = AddNewRow("Average Per-unit Variable Cost", currentPlan.Currency)
        dr(1) = brEvenValues.APUVariableCost
        dr(2) = 1

        dr = AddNewRow("Estimated Monthly Fixed Cost", currentPlan.Currency)
        dr(1) = brEvenValues.EstMonthlyFixCost
        dr(2) = 1

        AddNewRow("", "")
        AddNewRow("Break Even Analysis:", "")
        AddNewRow("Monthly Units Break-Even", "")
        AddExpressionToCell("Round(R{#'Estimated Monthly Fixed Cost'}/(R{#'Average Per-unit Revenue'}-R{#'Average Per-unit Variable Cost'}),0)", GetRowNumber("Monthly Units Break-Even"), 1)

        AddNewRow("Monthly Sales Break-Even", currentPlan.Currency)
        AddExpressionToCell("Round(R{#'Estimated Monthly Fixed Cost'}/(1-(R{#'Average Per-unit Variable Cost'}/R{#'Average Per-unit Revenue'})),0)", GetRowNumber("Monthly Sales Break-Even"), 1)

        PostProcess()
    End Sub
#End Region
    Public Overrides Sub Save()
        Dim Breakeven As New BreakEvenValues
        If Not (REValidator.IsDecimal(CStr(DefaultView(1)(1)), 0) And REValidator.IsDecimal(CStr(DefaultView(2)(1)), 0) And REValidator.IsDecimal(CStr(DefaultView(3)(1)), 0)) Then
            Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
        End If
        Breakeven.APURevenue = CSng(DefaultView(1)(1))
        Breakeven.APUVariableCost = CSng(DefaultView(2)(1))
        Breakeven.EstMonthlyFixCost = CSng(DefaultView(3)(1))
        Breakeven.PlanID = _CurrentPlan.PlanID
        SaveBreakEven(Breakeven)
        Saved()
    End Sub
#Region "BreakEven"
    Public Shared Function GetBreakEvenObj(ByRef connData As ConnectionData, ByVal businessId As String) As BreakEvenValues
        Dim cmd As New InfiniCommand("BPL_GetBreakEvenValues")
        cmd.AddParameter("@PlanID", businessId)
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, cmd)

        Dim brEvenValues As New BreakEvenValues
        'Dim count As Integer = 0
        If reader.Read() Then
            brEvenValues.PlanID = CStr(reader(2))
            brEvenValues.APURevenue = CSng(reader(3))
            brEvenValues.APUVariableCost = CSng(reader(4))
            brEvenValues.EstMonthlyFixCost = CSng(reader(5))
        End If
        Return brEvenValues
    End Function

    Private Function SaveBreakEven(ByRef brEvenValues As BreakEvenValues) As Boolean
        'Dim arrParams As SqlParameter() = New SqlParameter(7) {}
        Dim command As InfiniCommand
        command = New InfiniCommand("BPL_UpdateBreakEvenValues")

        command.AddParameter("@PlanID", brEvenValues.PlanID)
        command.AddParameter("@apuRevenue", brEvenValues.APURevenue)
        command.AddParameter("@apuVarCost", brEvenValues.APUVariableCost)
        command.AddParameter("@emFixCost ", brEvenValues.EstMonthlyFixCost)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function

#Region ".................. BreakEven For Web "
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("Industry Performance", GetType(String)))
        Columns.Add(New DataColumn("Value", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub
#End Region

#End Region
End Class
