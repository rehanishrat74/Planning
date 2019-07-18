Option Strict On  ' Block Implicit Conversions
Option Explicit On  ' Block Undeclared Variable Usage

Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data
Imports Infinilogic.BusinessPlan.BLL
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
 


Public Class BusinessPlan

    Inherits ACC_BLL.PageBase
 
#Region "Public Members"

' Previously all of these were private , but after discussion these were converted to public 
' because all data that reaches here is assumed to be valid , so no need of properties here
Public PlanID As String
Public PlanName As String
Public BusinessDescription As String
Public IsOngoing As Boolean
Public BusinessGoods As BusinessGoodsType
Public ManageInventory As Boolean
Public SellOnCredit As Boolean
Public SalesOnCreditPercent As Single
Public CollectionPeriod As Integer
Public PaymentDays As Integer
Public DisplayExpense As Boolean
Public InventoryTurnover As Single
Public ShortTermInterestRate As Single
Public LongTermInterestRate As Single
Public EstimatedTaxRate As Single
Public NonPayrollCashExpense As Single
Public StartYear As Integer
Public StartMonth As String
Public ProductCategoryName As String
Public SDCategoryName As String
Public OtherCategoryName As String
Public GACategoryName As String
'Public _StartupData As New Startup()
' Startup Table Data
Public StartupData As StartupTable
' Past Performance Table Data
Public PastPerformanceData As PastperformanceTable
Public PersonnelBurden As Single
Public StandardOrLongTerm As StandardLongTerm
Public SalesForecastType As SalesForecastType
Public BusinessName As String
Public CompanyBusinessOwnership As String
Public ContactDetails As String
Public Currency As String
#End Region

#Region "Constructors"

Public Sub New()

End Sub

Public Sub New(ByVal plan As BusinessPlan)
    Me.PlanID = plan.PlanID
    Me.PlanName = plan.PlanName
    Me.BusinessDescription = plan.BusinessDescription
    Me.IsOngoing = plan.IsOngoing
    Me.BusinessGoods = plan.BusinessGoods
    Me.ManageInventory = plan.ManageInventory
    Me.SellOnCredit = plan.SellOnCredit
    Me.SalesOnCreditPercent = plan.SalesOnCreditPercent
    Me.CollectionPeriod = plan.CollectionPeriod
    Me.PaymentDays = plan.PaymentDays
    Me.DisplayExpense = plan.DisplayExpense
    Me.InventoryTurnover = plan.InventoryTurnover
    Me.ShortTermInterestRate = plan.ShortTermInterestRate
    Me.LongTermInterestRate = plan.LongTermInterestRate
    Me.EstimatedTaxRate = plan.EstimatedTaxRate
    Me.NonPayrollCashExpense = plan.NonPayrollCashExpense
    Me.StartYear = plan.StartYear
    Me.StartMonth = plan.StartMonth
    Me.ProductCategoryName = plan.ProductCategoryName
    Me.SDCategoryName = plan.SDCategoryName
    Me.OtherCategoryName = plan.OtherCategoryName
    Me.GACategoryName = plan.GACategoryName
    'startup and pastperformances are set to nothing
    Me.StartupData = Nothing
    Me.PastPerformanceData = Nothing
    Me.PersonnelBurden = plan.PersonnelBurden
    Me.StandardOrLongTerm = plan.StandardOrLongTerm
    Me.SalesForecastType = plan.SalesForecastType
    Me.BusinessName = plan.BusinessName
    Me.CompanyBusinessOwnership = plan.CompanyBusinessOwnership
    Me.ContactDetails = plan.ContactDetails
    Me.Currency = plan.Currency
End Sub

#End Region
' Kindly refer to above note for description
' These properties are not be deleted before release version
#Region "Public Properties "

'Public ReadOnly Property PlanID() As Integer
'    Get
'        Return _businessID
'    End Get
'End Property

'Public Property PlanName() As String
'    Get
'        Return _businessName
'    End Get
'    Set(ByVal Value As String)
'        _businessName = Value
'    End Set
'End Property

'Public Property BusinessDescription() As String
'    Get
'        Return _businessDescription
'    End Get
'    Set(ByVal Value As String)
'        _businessDescription = Value
'    End Set
'End Property

'Public Property BusinessStatus() As String
'    Get
'        Return _businessStatus
'    End Get
'    Set(ByVal Value As String)
'        _businessStatus = Value
'    End Set
'End Property

'Public Property BusinessGoods() As String
'    Get
'        Return _businessGoods
'    End Get
'    Set(ByVal Value As String)
'        _businessGoods = Value
'    End Set
'End Property

'Public Property InventoryTurnover() As String
'    Get
'        Return _estimatedStockTurnover
'    End Get
'    Set(ByVal Value As String)
'        _estimatedStockTurnover = Value
'    End Set
'End Property

'Public Property ManageInventory() As Boolean
'    Get
'        Return _stockManagementSystem
'    End Get
'    Set(ByVal Value As Boolean)
'        _stockManagementSystem = Value
'    End Set
'End Property

'Public Property DisplayExpense() As Boolean
'    Get
'        Return _displayExpense
'    End Get
'    Set(ByVal Value As Boolean)
'        _displayExpense = Value
'    End Set
'End Property

'Public Property CollectionPeriod() As String
'    Get
'        Return _collectionPeriod
'    End Get
'    Set(ByVal Value As String)
'        _collectionPeriod = Value
'    End Set
'End Property

'Public Property SalesOnCreditPercent() As String
'    Get
'        Return _salesOnCredit
'    End Get
'    Set(ByVal Value As String)
'        _salesOnCredit = Value
'    End Set
'End Property

'Public Property ProductCategoryName() As String
'    Get
'        Return _productCategoryName
'    End Get
'    Set(ByVal Value As String)
'        _productCategoryName = Value
'    End Set
'End Property

'Public Property SDCategoryName() As String
'    Get
'        Return _SDCategoryName
'    End Get
'    Set(ByVal Value As String)
'        _SDCategoryName = Value
'    End Set
'End Property

'Public Property GACategoryName() As String
'    Get
'        Return _GACategoryName
'    End Get
'    Set(ByVal Value As String)
'        _GACategoryName = Value
'    End Set
'End Property

'Public Property OtherCategoryName() As String
'    Get
'        Return _otherCategoryName
'    End Get
'    Set(ByVal Value As String)
'        _otherCategoryName = Value
'    End Set
'End Property

'Public Property ShortTermInterestRate() As String
'    Get
'        Return _shortTermInterestRate
'    End Get
'    Set(ByVal Value As String)
'        _shortTermInterestRate = Value
'    End Set
'End Property

'Public Property LongTermInterestRate() As String
'    Get
'        Return _longTermInterestRate
'    End Get
'    Set(ByVal Value As String)
'        _longTermInterestRate = Value
'    End Set
'End Property

'Public Property EstimatedTaxRate() As String
'    Get
'        Return _estimatedTaxRate
'    End Get
'    Set(ByVal Value As String)
'        _estimatedTaxRate = Value
'    End Set
'End Property

'Public Property NonPayrollCashExpense() As String
'    Get
'        Return _nonPayrollCashExpense
'    End Get
'    Set(ByVal Value As String)
'        _nonPayrollCashExpense = Value
'    End Set
'End Property

'Public Property StartYear() As String
'    Get
'        Return _startYear
'    End Get
'    Set(ByVal Value As String)
'        _startYear = Value
'    End Set
'End Property

'Public Property StartMonth() As String
'    Get
'        Return _startMonth
'    End Get
'    Set(ByVal Value As String)
'        _startMonth = Value
'    End Set
'End Property

#End Region
    Public Shared dubFixAsset As Double
    Public Shared dubCurAsset As Double
    Public Shared dubTotAsset As Double
    Public Shared dubLongTLIB As Double
    Public Shared dubShortTLIB As Double
    Public Shared dubTotTLIB As Double
    Public Shared dubCap_Reserves As Double
    Public Shared Payrollexpense As Double
    Public Shared Payrollburdin As Double
    Public Shared dubTotCApital As Double
    Public Shared Property FixedAssets() As Double
        Get
            Return dubFixAsset
        End Get
        Set(ByVal Value As Double)
            dubFixAsset = Value

        End Set
    End Property
    Public Shared Property CurrentAssets() As Double
        Get
            Return dubCurAsset
        End Get
        Set(ByVal Value As Double)
            dubCurAsset = Value

        End Set
    End Property

    Public Shared Property TotalAssets() As Double
        Get
            Return dubTotAsset
        End Get
        Set(ByVal Value As Double)
            dubTotAsset = Value

        End Set
    End Property
    Public Shared Property LongTLIB() As Double
        Get
            Return dubLongTLIB
        End Get
        Set(ByVal Value As Double)
            dubLongTLIB = Value

        End Set
    End Property
    Public Shared Property ShortTLIB() As Double
        Get
            Return dubShortTLIB
        End Get
        Set(ByVal Value As Double)
            dubShortTLIB = Value

        End Set
    End Property

    Public Shared Property TotalTLIB() As Double
        Get
            Return dubTotTLIB
        End Get
        Set(ByVal Value As Double)
            dubTotTLIB = Value

        End Set
    End Property

    Public Shared Property TotalCapital() As Double
        Get
            Return dubTotCApital
        End Get
        Set(ByVal Value As Double)
            dubTotCApital = Value

        End Set
    End Property


    Public Shared Property Capital_Reserves() As Double
        Get
            Return dubCap_Reserves
        End Get
        Set(ByVal Value As Double)
            dubCap_Reserves = Value

        End Set
    End Property

    Public Shared Property Payroll_Expense() As Double
        Get
            Return PayrollExpense
        End Get
        Set(ByVal Value As Double)
            Payrollexpense = Value

        End Set
    End Property
    Public Shared Property Payroll_Burden() As Double
        Get
            Return Payrollburdin
        End Get
        Set(ByVal Value As Double)
            Payrollburdin = Value

        End Set
    End Property

End Class
Public Enum BusinessGoodsType
    Products = 0
    Services
    Both
End Enum
Public Enum SalesForecastType
    Units = 0
    Value
End Enum
Public Enum StandardLongTerm
    StandardTerm = 0
    LongTerm
End Enum


Public Enum MultiGridTypes As Integer
    Product = 0
    Expenses = 1
    Assets = 2
End Enum
