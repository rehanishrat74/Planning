Option Strict On
Option Explicit On 

#Region "Import Libraries "
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
#End Region

Public Class SupportTable
    Inherits BusinessTable
    Private SalesForecastTable As SalesForecast
    Private GATable As GeneralAssumption
    Private IncomeStatementTable As IncomeStatement

    Private TotalSales As DataRow
    Private CollectionDaysRow As DataRow
    Private SalesOnCreditPercents As DataRow
    Private CostOfUnitSales As DataRow
    Private InventoryTurnover As DataRow
    Private TotalCostOfSales As DataRow
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        SalesForecastTable = New SalesForecast(connData, currentPlan)
        GATable = New GeneralAssumption(connData, currentPlan)
        IncomeStatementTable = New IncomeStatement(connData, currentPlan)

        TotalSales = SalesForecastTable.GetTotalSales
        CollectionDaysRow = GATable.GetCollectionDays
        SalesOnCreditPercents = GATable.GetSalesOnCreditPercent
        CostOfUnitSales = SalesForecastTable.GetCostOfUnitSales
        InventoryTurnover = GATable.GetInventoryTurnover
        TotalCostOfSales = IncomeStatementTable.GetTotalCostOfSales

        TableName = "Support Table"
        Caption = "Support Table"
   PopulateDataTable(currentPlan)
        PostProcess()
    End Sub
#End Region
#Region "Public Methods"
    Public Function GetIncomeStatementTable() As IncomeStatement
        Return IncomeStatementTable
    End Function
    Public Function GetSalesForecastTable() As SalesForecast
        Return SalesForecastTable
    End Function
    Public Function GetGeneralAssumptionsTable() As GeneralAssumption
        Return GATable
    End Function
    Public Function GetAccountsRecieveable() As DataRow
        Return Rows(0)
    End Function
    Public Function GetInventory() As DataRow
        Return Rows(2)
    End Function
    Public Function GetChangeInInventory() As DataRow
        Return Rows(3)
    End Function
#End Region
#Region "Private Methods"
    Private Function PopulateDataTable(ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataTable
        Dim dt As DataTable = Me
        AddHeadings()
        AddNewRow("Accounts Recievable", currentPlan.Currency)
        AddNewRow("Changes in Accounts Recievable", currentPlan.Currency)
        AddNewRow("Inventory", currentPlan.Currency)
        AddNewRow("ChangeInInventory", currentPlan.Currency)


        If _CurrentPlan.SalesOnCreditPercent = 0 Then
            AddExpressionToRow("0", 0)
        Else
            If _CurrentPlan.IsOngoing Then
                AddExpressionToRow("Round((CollectionDays(Column[])*SalesOnCredit(Column[])*12)/365,0)", 0)
            Else
                AddExpressionToCell("Round(Min(((CollectionDays(Column[])*SalesOnCredit(Column[])*12)/365),SalesOnCredit(Column[])*Column[]),0)", 0, 1)
                AddExpressionToCell("Round(Min(((CollectionDays(Column[])*SalesOnCredit(Column[])*12)/365),SalesOnCredit(Column[])*Column[]),0)", 0, 2)
                AddExpressionToCell("Round(Min(((CollectionDays(Column[])*SalesOnCredit(Column[])*12)/365),SalesOnCredit(Column[])*Column[]),0)", 0, 3)
            End If
        End If
        AddExpressionToCell("Round((SalesOnCredit(Column[])*CDaysLogistics(1,Column[])+SalesOnCredit(Column[]-1)*CDaysLogistics(2,Column[])+SalesOnCredit(Column[]-2)*CDaysLogistics(3,Column[])+SalesOnCredit(Column[]-3)*CDaysLogistics(4,Column[])),0)", 0, 4)
        AddExpressionToCell("Round((SalesOnCredit(Column[])*CDaysLogistics(1,Column[])+SalesOnCredit(Column[]-1)*CDaysLogistics(2,Column[])+SalesOnCredit(Column[]-2)*CDaysLogistics(3,Column[])+SalesOnCredit(Column[]-3)*CDaysLogistics(4,Column[])+SalesOnCredit(Column[]-4)*CDaysLogistics(5,Column[])),0)", 0, 5)
        AddExpressionToRow("Round((SalesOnCredit(Column[])*CDaysLogistics(1,Column[])+SalesOnCredit(Column[]-1)*CDaysLogistics(2,Column[])+SalesOnCredit(Column[]-2)*CDaysLogistics(3,Column[])+SalesOnCredit(Column[]-3)*CDaysLogistics(4,Column[])+SalesOnCredit(Column[]-4)*CDaysLogistics(5,Column[])+SalesOnCredit(Column[]-5)*CDaysLogistics(6,Column[])),0)", 0, 6, 12)
        AddExpressionToCell("C[-1]", 0, 13)
        AddExpressionToRow("Round(((CollectionDays(Column[])/CollectionDays(Column[]-1))*(C[-1]/SalesOnCredit(Column[]-1))*SalesOnCredit(Column[])),0)", 0, 14, 17)

        'Inventory
        If _currentPlan.ManageInventory Then
            'If (Trim(_currentPlan.BusinessGoods) <> "Services") Then
            If _CurrentPlan.IsOngoing Then
                AddExpressionToRow("Round((CostOfUnitSales(Column[])*12)/InventoryTurns(Column[]),0)", 2, 1, 12)
            Else
                AddExpressionToCell("Round(Max((CostOfUnitSales(Column[])*12)/InventoryTurns(Column[]),StartingInventory()-CostOfUnitSales(Column[])),0)", 2, 1)
                AddExpressionToRow("Round(Max((CostOfUnitSales(Column[])*12)/InventoryTurns(Column[]),C[-1]-CostOfUnitSales(Column[])),0)", 2, 2, 12)
            End If
        End If
        AddExpressionToCell("C[-1]", 2, 13)
        AddExpressionToRow("Round(((CostOfUnitSales(Column[])*C[-1])/TotalCostOfSales(Column[]-1))*(InventoryTurns(Column[]-1)/InventoryTurns(Column[])),0)", 2, 14, 17)

        AddExpressionToRow("R[-1]-R[-1]C[-1]", 3)
        AddExpressionToCell("R[-1]-StartingInventory()", 3, 1)
        Return dt
    End Function
#End Region
    Private Sub CashFlow_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "PASTACCOUNTSRECIEVABLE"
                If _CurrentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsReceiveable))
                Else
                    ReturnValue = "0"
                End If
            Case "TOTALSALES"
                ReturnValue = CStr(TotalSales(CInt(ParameterList(0))))
            Case "SALESONCREDIT"
                ReturnValue = CStr(CSng(TotalSales(CInt(ParameterList(0)))) * CSng(SalesOnCreditPercents(CInt(ParameterList(0)))) / 100)
            Case "SALESONCREDITPERCENTS"
                ReturnValue = CStr(SalesOnCreditPercents(CInt(ParameterList(0))))
            Case "COLLECTIONDAYS"
                ReturnValue = CStr(CollectionDaysRow(CInt(ParameterList(0))))
            Case "CDAYSLOGISTICS"
                Dim CollectionDays As Integer = CInt(CollectionDaysRow(CInt(ParameterList(1))))
                Dim Index As Integer = CInt(ParameterList(0))
                Select Case Index
                    Case 1
                        If (CollectionDays > 30) Then
                            ReturnValue = "1"
                        Else
                            ReturnValue = CStr(CollectionDays / 30)
                        End If
                    Case 2
                        If CollectionDays > 30 And CollectionDays < 61 Then
                            ReturnValue = CStr((CollectionDays - 30) / 30)
                        Else
                            If CollectionDays > 60 Then
                                ReturnValue = "1"
                            Else
                                ReturnValue = "0"
                            End If
                        End If
                    Case 3
                        If CollectionDays > 60 And CollectionDays < 91 Then
                            ReturnValue = CStr((CollectionDays - 60) / 30)
                        Else
                            If CollectionDays > 90 Then
                                ReturnValue = "1"
                            Else
                                ReturnValue = "0"
                            End If
                        End If
                    Case 4
                        If CollectionDays > 90 And CollectionDays < 121 Then
                            ReturnValue = CStr((CollectionDays - 90) / 30)
                        Else
                            If CollectionDays > 120 Then
                                ReturnValue = "1"
                            Else
                                ReturnValue = "0"
                            End If
                        End If
                    Case 5
                        If CollectionDays > 120 And CollectionDays < 151 Then
                            ReturnValue = CStr((CollectionDays - 120) / 30)
                        Else
                            If CollectionDays > 150 Then
                                ReturnValue = "1"
                            Else
                                ReturnValue = "0"
                            End If
                        End If
                    Case 6
                        If CollectionDays > 150 And CollectionDays < 181 Then
                            ReturnValue = CStr((CollectionDays - 150) / 30)
                        Else
                            If CollectionDays > 180 Then
                                ReturnValue = "1"
                            Else
                                ReturnValue = "0"
                            End If
                        End If
                End Select
            Case "INVENTORYTURNS"
                ReturnValue = CStr(InventoryTurnover(CInt(ParameterList(0))))
            Case "COSTOFUNITSALES"
                ReturnValue = CStr(CostOfUnitSales(CInt(ParameterList(0))))
            Case "TOTALCOSTOFSALES"
                ReturnValue = CStr(TotalCostOfSales(CInt(ParameterList(0))))
            Case "STARTINGINVENTORY"
                If _CurrentPlan.IsOngoing Then
                    ReturnValue = CStr(Math.Round(_CurrentPlan.PastPerformanceData.Inventory, 0))
                Else
                    ReturnValue = CStr(Math.Round(_CurrentPlan.StartupData.StartupInventory, 0))
                End If
        End Select
    End Sub
End Class


