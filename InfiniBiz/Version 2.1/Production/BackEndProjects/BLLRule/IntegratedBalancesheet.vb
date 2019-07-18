Option Strict On  ' Block Implicit Conversions
Option Explicit On  ' Block Undeclared Variable Usage

#Region "Imports  "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient
Imports System.Web.SessionState


Imports System.Data
 
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.AccountsCentre.DAL
Imports System.Resources
Imports System.Globalization
Imports System.Threading
Imports System.Reflection
Imports System.web

Imports System

Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.UserControl
Imports System.Web.HttpContext
Imports System.Web.Security
Imports ACC_DAL = InfiniLogic.AccountsCentre.DAL
Imports ACC_BLL = InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
 

#End Region


Public Class IntegratedBalancesheet
    Inherits BusinessTable

#Region " Variales "


    Private CashFlowTable As CashFlow
    Private Liabilities As LiabilitiesTable
    Private IncomeStatementTable As IncomeStatement
    Private TempT As SupportTable
    Private CashDetailsTable As CashDetails
    Private GATable As GeneralAssumption

    Private ShortTermNotes As DataRow
    Private LongTermLiabilities As DataRow
    Private AccountsReceivable As DataRow
    Private AccountsPayable As DataRow
    Private CashBalance As DataRow
    Private Dividends As DataRow
    Private CapitalExpenditure As DataRow
    Private NetProfit As DataRow
    Private Inventory As DataRow
    Private InventoryTurnOver As DataRow
    Private Depreciation As DataRow
    Private CapitalInput As DataRow
    Private ChangeInOtherSTAssets As DataRow
    Private IncDecOtherLiabilities As DataRow
    Private CostOfUnitSales As DataRow
    Private TotalCostofsales As DataRow

    Public startingCash As Double
    Public strACR As Double
    Public strInv As Double
    Public staSTA As Double
    Public staCapital As Double
    Public staDep As Double
    Public staNote As Double
    Public staAccpay As Double

    Public staSTL As Double
    Public staLongTL As Double
    Public staPaidCapital As Double
    Public strEarning As Double

    Public ObjCashBalance As Double
    Public ObjAccountsReceivable As Double
    Public ObjInventory As Double
    Public ObjChangeInOtherSTAssets As Double
    Public ObjCapitalExpenditure As Double
    Public ObjDepreciation As Double
    Public ObjAccountsPayable As Double
    Public ObjShortTermNotes As Double
    Public ObjIncDecOtherLiabilities As Double
    Public ObjLongTermLiabilities As Double
    Public ObjNetProfit As Double
    Public ObjCapitalInput As Double
    Public a As BusinessTable
    Public BPObject As InfiniLogic.BusinessPlan.BLL.BusinessPlan
#End Region

#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, _
    ByVal Periodid As Integer)
        MyBase.New(connData, currentPlan)
        _IsEditable = False
        CashFlowTable = New CashFlow(connData, currentPlan)

        IncomeStatementTable = CashFlowTable.GetIncomeStatement
        CashDetailsTable = CashFlowTable.GetCashDetails
        Liabilities = IncomeStatementTable.GetLiabilities
        TempT = CashFlowTable.GetSupportTable
        GATable = IncomeStatementTable.GetGeneralAssumption

        AccountsPayable = CashDetailsTable.GetAccountsPayable
        ShortTermNotes = Liabilities.GetShortTermNotes
        LongTermLiabilities = Liabilities.GetLongTermLiabilities
        AccountsReceivable = TempT.GetAccountsRecieveable
        CashBalance = CashFlowTable.GetCashBalance

        Dividends = CashFlowTable.GetDividends
        CapitalExpenditure = CashFlowTable.GetCapitalExpenditure
        NetProfit = IncomeStatementTable.GetNetProfit2()
        Inventory = TempT.GetInventory
        InventoryTurnOver = GATable.GetInventoryTurnover
        Depreciation = IncomeStatementTable.GetDepreciation
        CapitalInput = CashFlowTable.GetCapitalInput
        ChangeInOtherSTAssets = CashFlowTable.GetChangeInOtherSTAssets
        CostOfUnitSales = IncomeStatementTable.GetSalesForecast.GetCostOfUnitSales
        TotalCostofsales = IncomeStatementTable.GetTotalCostOfSales
        IncDecOtherLiabilities = CashFlowTable.GetIncDecOtherLiabilities
        Me.TableName = "BalanceSheet"
        Caption = "Balance Sheet"

        MonthlyBalanceSheet(connData, currentPlan, Periodid)


    End Sub

    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        _IsEditable = False
        CashFlowTable = New CashFlow(connData, currentPlan)

        IncomeStatementTable = CashFlowTable.GetIncomeStatement
        CashDetailsTable = CashFlowTable.GetCashDetails
        Liabilities = IncomeStatementTable.GetLiabilities
        TempT = CashFlowTable.GetSupportTable
        GATable = IncomeStatementTable.GetGeneralAssumption

        AccountsPayable = CashDetailsTable.GetAccountsPayable
        ShortTermNotes = Liabilities.GetShortTermNotes
        LongTermLiabilities = Liabilities.GetLongTermLiabilities
        AccountsReceivable = TempT.GetAccountsRecieveable
        CashBalance = CashFlowTable.GetCashBalance

        Dividends = CashFlowTable.GetDividends
        CapitalExpenditure = CashFlowTable.GetCapitalExpenditure
        NetProfit = IncomeStatementTable.GetNetProfit2()
        Inventory = TempT.GetInventory
        InventoryTurnOver = GATable.GetInventoryTurnover
        Depreciation = IncomeStatementTable.GetDepreciation
        CapitalInput = CashFlowTable.GetCapitalInput
        ChangeInOtherSTAssets = CashFlowTable.GetChangeInOtherSTAssets
        CostOfUnitSales = IncomeStatementTable.GetSalesForecast.GetCostOfUnitSales
        TotalCostofsales = IncomeStatementTable.GetTotalCostOfSales
        IncDecOtherLiabilities = CashFlowTable.GetIncDecOtherLiabilities
        Me.TableName = "BalanceSheet"
        Caption = "Balance Sheet"
        AnnualBalanceSheet(connData, currentPlan, 12)


    End Sub


#End Region

#Region "Private Methods"

    Public Function MonthlyBalanceSheet(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal Periodid As Integer) As Integer

        setStartingValues()

        Dim intloop1 As Integer
        For intloop1 = 1 To Periodid
            If (CType(CashBalance.Item(intloop1), String) = "") Then
                CashBalance.Item(intloop1) = 0.0
            End If
            ObjCashBalance = CType(CashBalance.Item(intloop1), Double) + ObjCashBalance
        Next
        ObjCashBalance = ObjCashBalance + startingCash

        ' If CType(CashBalance.Item(Periodid), String) = "" Then ObjCashBalance = 0.0 Else ObjCashBalance = CType(CashBalance.Item(Periodid), Double) + startingCash

        If CType(AccountsReceivable.Item(Periodid), String) = "" Then ObjAccountsReceivable = 0.0 + strACR Else ObjAccountsReceivable = CType(AccountsReceivable.Item(Periodid), Double)
        If CType(Inventory.Item(Periodid), String) = "" Then ObjInventory = 0.0 + strInv Else ObjInventory = CType(Inventory.Item(Periodid), Double)
        Dim intloop8 As Integer
        For intloop8 = 1 To Periodid
            If CType(ChangeInOtherSTAssets.Item(intloop8), String) = "" Then
                ObjChangeInOtherSTAssets = 0.0
            End If
            ObjChangeInOtherSTAssets = CType(ChangeInOtherSTAssets.Item(intloop8), Double) + ObjChangeInOtherSTAssets
        Next
        ObjChangeInOtherSTAssets = ObjChangeInOtherSTAssets + staSTA
        Dim intloop2 As Integer
        For intloop2 = 1 To Periodid
            If (CType(CapitalExpenditure.Item(intloop2), String) = "") Then
                CapitalExpenditure.Item(intloop2) = 0.0
            End If
            ObjCapitalExpenditure = CType(CapitalExpenditure.Item(intloop2), Double) + ObjCapitalExpenditure
        Next
        ObjCapitalExpenditure = ObjCapitalExpenditure + staCapital

        'If CType(CapitalExpenditure.Item(Periodid), String) = "" Then ObjCapitalExpenditure = 0.0 + staCapital Else ObjCapitalExpenditure = CType(CapitalExpenditure.Item(Periodid), Double) + staCapital

        Dim intloop3 As Integer
        For intloop3 = 1 To Periodid
            If (CType(Depreciation.Item(intloop3), String) = "") Then
                Depreciation.Item(intloop3) = 0.0
            End If
            ObjDepreciation = CType(Depreciation.Item(intloop3), Double) + ObjDepreciation
        Next
        ObjDepreciation = ObjDepreciation + staDep

        'If CType(Depreciation.Item(Periodid), String) = "" Then ObjDepreciation = 0.0 + staDep Else ObjDepreciation = CType(Depreciation.Item(Periodid), Double) + staDep

        If CType(AccountsPayable.Item(Periodid), String) = "" Then ObjAccountsPayable = 0.0 + staAccpay Else ObjAccountsPayable = CType(AccountsPayable.Item(Periodid), Double)
        If CType(ShortTermNotes.Item(Periodid), String) = "" Then ObjShortTermNotes = 0.0 + staNote Else ObjShortTermNotes = CType(ShortTermNotes.Item(Periodid), Double)
        '  If CType(IncDecOtherLiabilities.Item(Periodid), String) = "" Then ObjIncDecOtherLiabilities = 0.0 + staSTL Else ObjIncDecOtherLiabilities = CType(IncDecOtherLiabilities.Item(Periodid), Double) + staSTL
        Dim intloop4 As Integer
        For intloop4 = 1 To Periodid
            If (CType(IncDecOtherLiabilities.Item(intloop4), String) = "") Then
                IncDecOtherLiabilities.Item(intloop4) = 0.0
            End If
            ObjIncDecOtherLiabilities = CType(IncDecOtherLiabilities.Item(intloop4), Double) + ObjIncDecOtherLiabilities
        Next
        ObjIncDecOtherLiabilities = ObjIncDecOtherLiabilities + staSTL

        '  If CType(CapitalInput.Item(Periodid), String) = "" Then ObjCapitalInput = 0.0 + staPaidCapital Else ObjCapitalInput = CType(CapitalInput.Item(13), Double) + staPaidCapital
        Dim intloop5 As Integer
        For intloop5 = 1 To Periodid
            If (CType(CapitalInput.Item(intloop5), String) = "") Then
                CapitalInput.Item(intloop5) = 0.0
            End If
            ObjCapitalInput = CType(CapitalInput.Item(intloop5), Double) + ObjCapitalInput
        Next
        ObjCapitalInput = ObjCapitalInput + staPaidCapital

        '  If CType(NetProfit.Item(Periodid), String) = "" Then ObjNetProfit = 0.0 + strEarning Else ObjNetProfit = CType(NetProfit.Item(13), Double)
        Dim intloop6 As Integer
        For intloop6 = 1 To Periodid
            If (CType(NetProfit.Item(intloop6), String) = "") Then
                NetProfit.Item(intloop6) = 0.0
            End If
            ObjNetProfit = CType(NetProfit.Item(intloop6), Double) + ObjNetProfit
        Next
        ObjNetProfit = ObjNetProfit + staPaidCapital

        Dim shorttermassets As Double = ObjCashBalance + ObjAccountsReceivable + ObjInventory + ObjChangeInOtherSTAssets
        BPObject.CurrentAssets = shorttermassets
        Dim longtermassets As Double = ObjCapitalExpenditure - ObjDepreciation
        BPObject.FixedAssets = longtermassets
        Dim totassets As Double = shorttermassets + longtermassets
        BPObject.TotalAssets = totassets

        Dim shorttermlibalaity As Double = ObjAccountsPayable + ObjShortTermNotes + ObjIncDecOtherLiabilities
        If CType(LongTermLiabilities.Item(Periodid), String) = "" Then ObjLongTermLiabilities = 0.0 + staLongTL Else ObjLongTermLiabilities = CType(LongTermLiabilities.Item(Periodid), Double)
        BPObject.LongTLIB = ObjLongTermLiabilities
        BPObject.ShortTLIB = shorttermlibalaity

        Dim totlib As Double = shorttermlibalaity + ObjLongTermLiabilities
        BPObject.TotalTLIB = totlib
        Dim retainedearning As Double = totassets - totlib - ObjCapitalInput - ObjNetProfit
        Dim totcapital As Double = ObjCapitalInput + ObjNetProfit + Math.Round(retainedearning)
        Dim totlibncapital As Double = totcapital + totlib
        BPObject.Capital_Reserves = totlibncapital
        BPObject.TotalCapital = totcapital
    End Function

    Public Function AnnualBalanceSheet(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal Periodid As Integer) As Integer

        setStartingValues()

        Dim intloop1 As Integer
        For intloop1 = 1 To Periodid
            If (CType(CashBalance.Item(intloop1), String) = "") Then
                CashBalance.Item(intloop1) = 0.0
            End If
            ObjCashBalance = CType(CashBalance.Item(intloop1), Double) + ObjCashBalance
        Next
        ObjCashBalance = ObjCashBalance + startingCash

        ' If CType(CashBalance.Item(Periodid), String) = "" Then ObjCashBalance = 0.0 Else ObjCashBalance = CType(CashBalance.Item(Periodid), Double) + startingCash

        If CType(AccountsReceivable.Item(Periodid), String) = "" Then ObjAccountsReceivable = 0.0 + strACR Else ObjAccountsReceivable = CType(AccountsReceivable.Item(Periodid), Double)
        If CType(Inventory.Item(Periodid), String) = "" Then ObjInventory = 0.0 + strInv Else ObjInventory = CType(Inventory.Item(Periodid), Double)
        Dim intloop8 As Integer
        For intloop8 = 1 To Periodid
            If CType(ChangeInOtherSTAssets.Item(intloop8), String) = "" Then
                ObjChangeInOtherSTAssets = 0.0
            End If
            ObjChangeInOtherSTAssets = CType(ChangeInOtherSTAssets.Item(intloop8), Double) + ObjChangeInOtherSTAssets
        Next
        ObjChangeInOtherSTAssets = ObjChangeInOtherSTAssets + staSTA
        Dim intloop2 As Integer
        For intloop2 = 1 To Periodid
            If (CType(CapitalExpenditure.Item(intloop2), String) = "") Then
                CapitalExpenditure.Item(intloop2) = 0.0
            End If
            ObjCapitalExpenditure = CType(CapitalExpenditure.Item(intloop2), Double) + ObjCapitalExpenditure
        Next
        ObjCapitalExpenditure = ObjCapitalExpenditure + staCapital

        'If CType(CapitalExpenditure.Item(Periodid), String) = "" Then ObjCapitalExpenditure = 0.0 + staCapital Else ObjCapitalExpenditure = CType(CapitalExpenditure.Item(Periodid), Double) + staCapital

        Dim intloop3 As Integer
        For intloop3 = 1 To Periodid
            If (CType(Depreciation.Item(intloop3), String) = "") Then
                Depreciation.Item(intloop3) = 0.0
            End If
            ObjDepreciation = CType(Depreciation.Item(intloop3), Double) + ObjDepreciation
        Next
        ObjDepreciation = ObjDepreciation + staDep

        'If CType(Depreciation.Item(Periodid), String) = "" Then ObjDepreciation = 0.0 + staDep Else ObjDepreciation = CType(Depreciation.Item(Periodid), Double) + staDep

        If CType(AccountsPayable.Item(Periodid), String) = "" Then ObjAccountsPayable = 0.0 + staAccpay Else ObjAccountsPayable = CType(AccountsPayable.Item(Periodid), Double)
        If CType(ShortTermNotes.Item(Periodid), String) = "" Then ObjShortTermNotes = 0.0 + staNote Else ObjShortTermNotes = CType(ShortTermNotes.Item(Periodid), Double)
        '  If CType(IncDecOtherLiabilities.Item(Periodid), String) = "" Then ObjIncDecOtherLiabilities = 0.0 + staSTL Else ObjIncDecOtherLiabilities = CType(IncDecOtherLiabilities.Item(Periodid), Double) + staSTL
        Dim intloop4 As Integer
        For intloop4 = 1 To Periodid
            If (CType(IncDecOtherLiabilities.Item(intloop4), String) = "") Then
                IncDecOtherLiabilities.Item(intloop4) = 0.0
            End If
            ObjIncDecOtherLiabilities = CType(IncDecOtherLiabilities.Item(intloop4), Double) + ObjIncDecOtherLiabilities
        Next
        ObjIncDecOtherLiabilities = ObjIncDecOtherLiabilities + staSTL

        '  If CType(CapitalInput.Item(Periodid), String) = "" Then ObjCapitalInput = 0.0 + staPaidCapital Else ObjCapitalInput = CType(CapitalInput.Item(13), Double) + staPaidCapital
        Dim intloop5 As Integer
        For intloop5 = 1 To Periodid
            If (CType(CapitalInput.Item(intloop5), String) = "") Then
                CapitalInput.Item(intloop5) = 0.0
            End If
            ObjCapitalInput = CType(CapitalInput.Item(intloop5), Double) + ObjCapitalInput
        Next
        ObjCapitalInput = ObjCapitalInput + staPaidCapital

        '  If CType(NetProfit.Item(Periodid), String) = "" Then ObjNetProfit = 0.0 + strEarning Else ObjNetProfit = CType(NetProfit.Item(13), Double)
        Dim intloop6 As Integer
        For intloop6 = 1 To Periodid
            If (CType(NetProfit.Item(intloop6), String) = "") Then
                NetProfit.Item(intloop6) = 0.0
            End If
            ObjNetProfit = CType(NetProfit.Item(intloop6), Double) + ObjNetProfit
        Next
        ObjNetProfit = ObjNetProfit + staPaidCapital

        Dim shorttermassets As Double = ObjCashBalance + ObjAccountsReceivable + ObjInventory + ObjChangeInOtherSTAssets
        BPObject.CurrentAssets = shorttermassets
        Dim longtermassets As Double = ObjCapitalExpenditure - ObjDepreciation
        BPObject.FixedAssets = longtermassets
        Dim totassets As Double = shorttermassets + longtermassets
        BPObject.TotalAssets = totassets

        Dim shorttermlibalaity As Double = ObjAccountsPayable + ObjShortTermNotes + ObjIncDecOtherLiabilities
        If CType(LongTermLiabilities.Item(Periodid), String) = "" Then ObjLongTermLiabilities = 0.0 + staLongTL Else ObjLongTermLiabilities = CType(LongTermLiabilities.Item(Periodid), Double)
        BPObject.LongTLIB = ObjLongTermLiabilities
        BPObject.ShortTLIB = shorttermlibalaity

        Dim totlib As Double = shorttermlibalaity + ObjLongTermLiabilities
        BPObject.TotalTLIB = totlib
        Dim retainedearning As Double = totassets - totlib - ObjCapitalInput - ObjNetProfit
        Dim totcapital As Double = ObjCapitalInput + ObjNetProfit + Math.Round(retainedearning)
        Dim totlibncapital As Double = totcapital + totlib
        BPObject.Capital_Reserves = totlibncapital
        BPObject.TotalCapital = totcapital
    End Function


    'Public Function AnnualBalanceSheet(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String) As Integer

    '    setStartingValues()
    '    If CType(CashBalance.Item(13), String) = "" Then ObjCashBalance = 0.0 Else ObjCashBalance = CType(CashBalance.Item(13), Double) + startingCash
    '    If CType(AccountsReceivable.Item(13), String) = "" Then ObjAccountsReceivable = 0.0 + strACR Else ObjAccountsReceivable = CType(AccountsReceivable.Item(13), Double)
    '    If CType(Inventory.Item(13), String) = "" Then ObjInventory = 0.0 + strInv Else ObjInventory = CType(Inventory.Item(13), Double)
    '    If CType(ChangeInOtherSTAssets.Item(13), String) = "" Then ObjChangeInOtherSTAssets = 0.0 + staSTA Else ObjChangeInOtherSTAssets = CType(ChangeInOtherSTAssets.Item(13), Double) + staSTA
    '    If CType(CapitalExpenditure.Item(13), String) = "" Then ObjCapitalExpenditure = 0.0 + staCapital Else ObjCapitalExpenditure = CType(CapitalExpenditure.Item(13), Double) + staCapital
    '    If CType(Depreciation.Item(13), String) = "" Then ObjDepreciation = 0.0 + staDep Else ObjDepreciation = CType(Depreciation.Item(13), Double) + staDep
    '    If CType(AccountsPayable.Item(13), String) = "" Then ObjAccountsPayable = 0.0 + staAccpay Else ObjAccountsPayable = CType(AccountsPayable.Item(13), Double)
    '    If CType(ShortTermNotes.Item(13), String) = "" Then ObjShortTermNotes = 0.0 + staNote Else ObjShortTermNotes = CType(ShortTermNotes.Item(13), Double)
    '    If CType(IncDecOtherLiabilities.Item(13), String) = "" Then ObjIncDecOtherLiabilities = 0.0 + staSTL Else ObjIncDecOtherLiabilities = CType(IncDecOtherLiabilities.Item(13), Double) + staSTL

    '    If CType(CapitalInput.Item(13), String) = "" Then ObjCapitalInput = 0.0 + staPaidCapital Else ObjCapitalInput = CType(CapitalInput.Item(13), Double) + staPaidCapital
    '    If CType(NetProfit.Item(13), String) = "" Then ObjNetProfit = 0.0 + strEarning Else ObjNetProfit = CType(NetProfit.Item(13), Double)

    '    Dim shorttermassets As Double = ObjCashBalance + ObjAccountsReceivable + ObjInventory + ObjChangeInOtherSTAssets
    '    BPObject.CurrentAssets = shorttermassets
    '    Dim longtermassets As Double = ObjCapitalExpenditure - ObjDepreciation
    '    BPObject.FixedAssets = longtermassets
    '    Dim totassets As Double = shorttermassets + longtermassets
    '    BPObject.TotalAssets = totassets

    '    Dim shorttermlibalaity As Double = ObjAccountsPayable + ObjShortTermNotes + ObjIncDecOtherLiabilities
    '    If CType(LongTermLiabilities.Item(13), String) = "" Then ObjLongTermLiabilities = 0.0 + staLongTL Else ObjLongTermLiabilities = CType(LongTermLiabilities.Item(13), Double)
    '    BPObject.LongTLIB = ObjLongTermLiabilities
    '    BPObject.ShortTLIB = shorttermlibalaity

    '    Dim totlib As Double = shorttermlibalaity + ObjLongTermLiabilities
    '    BPObject.TotalTLIB = totlib
    '    Dim retainedearning As Double = totassets - totlib - ObjCapitalInput - ObjNetProfit
    '    Dim totcapital As Double = ObjCapitalInput + ObjNetProfit + Math.Round(retainedearning)
    '    Dim totlibncapital As Double = totcapital + totlib
    '    BPObject.Capital_Reserves = totlibncapital
    '    BPObject.TotalCapital = totcapital
    'End Function


    Public Function setStartingValues() As String
        If _currentPlan.IsOngoing Then
            startingCash = CType(_currentPlan.PastPerformanceData.Cash, Double)
        Else
            startingCash = CType(_currentPlan.StartupData.CashRequirement, Double)
        End If

        If _currentPlan.IsOngoing Then
            strACR = CType(_currentPlan.PastPerformanceData.AccountsReceiveable, Double)
        Else
            strACR = 0
        End If
        If _currentPlan.IsOngoing Then
            strInv = CType(_CurrentPlan.PastPerformanceData.Inventory, Double)
        Else
            strInv = CType(_CurrentPlan.StartupData.StartupInventory, Double)
        End If

        If _currentPlan.IsOngoing Then
            staSTA = CType(_CurrentPlan.PastPerformanceData.OtherShortTermAssets, Double)
        Else
            staSTA = CType(_CurrentPlan.StartupData.OtherShortTermAssets, Double)
        End If

        If _currentPlan.IsOngoing Then
            staCapital = CType(_currentPlan.PastPerformanceData.CapitalAssets, Double)
        Else
            staCapital = CType(_currentPlan.StartupData.LongTermAssets, Double)
        End If
        If _currentPlan.IsOngoing Then
            staDep = CType(_CurrentPlan.PastPerformanceData.AccumulatedDepreciation, Double)
        Else
            staDep = 0
        End If

        If _currentPlan.IsOngoing Then
            staAccpay = CType(CLng(_currentPlan.PastPerformanceData.AccountsPayable), Double)
        Else
            staAccpay = CType(CLng(_CurrentPlan.StartupData.UnpaidExpenses), Double)
        End If


        If _currentPlan.IsOngoing Then
            staNote = CType(CLng(_currentPlan.PastPerformanceData.ShortTermNotes), Double)
        Else
            staNote = CType(CLng(_CurrentPlan.StartupData.ShortTermLoan), Double)
        End If

        If _currentPlan.IsOngoing Then
            staSTL = CType(CLng(_currentPlan.PastPerformanceData.OtherShortTermLiabilities), Double)
        Else
            staSTL = CType(CLng(_CurrentPlan.StartupData.InterestFreeShortTermLiabilities), Double)
        End If

        If _currentPlan.IsOngoing Then
            staLongTL = CType(CLng(_currentPlan.PastPerformanceData.LongTermLiabilities), Double)
        Else
            staLongTL = CType(CLng(_CurrentPlan.StartupData.LongTermLiabilities), Double)
        End If
        ''Paid-in Capital
        If _currentPlan.IsOngoing Then
            staPaidCapital = CType(_CurrentPlan.PastPerformanceData.PaidInCapital, Double)
        Else
            staPaidCapital = CType(_CurrentPlan.StartupData.TotalInvestment, Double)
        End If

        '' Earnings

        If _currentPlan.IsOngoing Then
            strEarning = CType(_CurrentPlan.PastPerformanceData.Earning, Double)
        Else
            strEarning = 0
        End If
    End Function

    Private Sub BalanceSheet_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName

            Case "STARTUPCASH"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.Cash)
                Else
                    ReturnValue = CStr(_currentPlan.StartupData.CashRequirement)
                End If
            Case "PASTACCOUNTSRECIEVABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsReceiveable))
                Else
                    ReturnValue = "0"
                End If
            Case "STARTINGINVENTORY"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Inventory)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.StartupInventory)
                End If


            Case "STARTINGSTASSETS"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.OtherShortTermAssets)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.OtherShortTermAssets)
                End If


            Case "STARTINGCAPITALASSETS"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_currentPlan.PastPerformanceData.CapitalAssets)
                Else
                    ReturnValue = CStr(_currentPlan.StartupData.LongTermAssets)
                End If

            Case "STARTINGACCDEP"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.AccumulatedDepreciation)
                Else
                    ReturnValue = "0"
                End If



            Case "PASTACCOUNTSPAYABLE"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.AccountsPayable))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.UnpaidExpenses))
                End If

            Case "STARTINGSTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.ShortTermNotes))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.ShortTermLoan))
                End If

            Case "STARTINGOTHERSTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.OtherShortTermLiabilities))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.InterestFreeShortTermLiabilities))
                End If

            Case "STARTINGLTL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(CLng(_currentPlan.PastPerformanceData.LongTermLiabilities))
                Else
                    ReturnValue = CStr(CLng(_CurrentPlan.StartupData.LongTermLiabilities))
                End If

            Case "STARTINGCAPITAL"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.PaidInCapital)
                Else
                    ReturnValue = CStr(_CurrentPlan.StartupData.TotalInvestment)
                End If


            Case "STARTINGEARNING"
                If _currentPlan.IsOngoing Then
                    ReturnValue = CStr(_CurrentPlan.PastPerformanceData.Earning)
                Else
                    ReturnValue = "0"
                End If



            Case "DIVIDEND"
                ReturnValue = CStr(Dividends(CInt(ParameterList(0)) - 1))
            Case "NETPROFIT"
                ReturnValue = CStr(NetProfit(CInt(ParameterList(0)) - 1))
            Case "CAPITALEXPENSE"
                ReturnValue = CStr(CapitalExpenditure(CInt(ParameterList(0)) - 1))

            Case "ACCOUNTSRECEIVABLE"
                ReturnValue = CStr(AccountsReceivable(CInt(ParameterList(0)) - 1))
            Case "SHORTTERMNOTES"
                ReturnValue = CStr(ShortTermNotes(CInt(ParameterList(0)) - 1))
            Case "CAPITALINPUT"
                ReturnValue = CStr(CapitalInput(CInt(ParameterList(0)) - 1))
            Case "LONGTERMLIABILITIES"
                ReturnValue = CStr(LongTermLiabilities(CInt(ParameterList(0)) - 1))
            Case "ACCOUNTSPAYABLE"
                ReturnValue = CStr(AccountsPayable(CInt(ParameterList(0)) - 1))
            Case "DEPRECIATION"
                ReturnValue = CStr(Depreciation(CInt(ParameterList(0)) - 1))
            Case "INVENTORYTURNS"
                ReturnValue = CStr(InventoryTurnOver(CInt(ParameterList(0)) - 1))
            Case "LASTINVENTORYRATE"
                ReturnValue = CStr(InventoryTurnOver(CInt(ParameterList(0)) - 2))

            Case "INVENTORY"
                ReturnValue = CStr(Inventory(CInt(ParameterList(0)) - 1))
            Case "CHANGEINOTHERSTASSETS"
                ReturnValue = CStr(ChangeInOtherSTAssets(CInt(ParameterList(0)) - 1))

            Case "COSTOFUNITSALES"
                ReturnValue = CStr(CostOfUnitSales(CInt(ParameterList(0)) - 1))
                'Case Else
                '    MsgBox(FunctionName)
            Case "TOTALCOSTOFSALES"
                ReturnValue = CStr(TotalCostofsales(CInt(ParameterList(0)) - 2))
            Case "INCDECOTHERLIABILITIES"
                ReturnValue = CStr(IncDecOtherLiabilities(CInt(ParameterList(0)) - 1))
            Case "CASHBALANCE"
                ReturnValue = CStr(CashBalance(CInt(ParameterList(0)) - 1))

        End Select
    End Sub

#End Region

#Region "Public Methods"
    Public Function GetCashFlow() As CashFlow
        Return CashFlowTable
    End Function
    Public Function GetIncomeStatement() As IncomeStatement
        Return IncomeStatementTable
    End Function
    Public Function GetTotalAssets() As DataRow
        Return Rows(GetRowNumber("Total Assets"))
    End Function
    Public Function GetAccountsReceivable() As DataRow
        If _CurrentPlan.SellOnCredit Then
            Return Rows(GetRowNumber("Accounts Receivable"))
        End If
    End Function
    Public Function GetInventory() As DataRow
        If _currentPlan.ManageInventory Then
            Return Rows(GetRowNumber("Inventory"))
        End If
    End Function
    Public Function GetOtherShortTermAssets() As DataRow
        Return Rows(GetRowNumber("Other Short-term Assets"))
    End Function
    Public Function GetTotalShortTermAssets() As DataRow
        Return Rows(GetRowNumber("Total Short-term Assets"))
    End Function
    Public Function GetTotalLongTermAssets() As DataRow
        Return Rows(GetRowNumber("Total Long-term Assets"))
    End Function
    Public Function GetOtherShortTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Other Short-term Liabilities"))
    End Function
    Public Function GetTotalShortTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Subtotal Short-term Liabilities"))
    End Function
    Public Function GetLongTermLiabilities() As DataRow
        Return Rows(GetRowNumber("Long-term Liabilities"))
    End Function
    Public Function GetTotalLiabilities() As DataRow
        Return Rows(GetRowNumber("Total liabilities"))
    End Function
    Public Function GetNetWorth() As DataRow
        Return Rows(GetRowNumber("Net Worth"))
    End Function
#End Region






End Class
