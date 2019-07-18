Public Enum QuestionTypes   'Describes the query types
    yesNo = 0
    options
    text
    calendarDate
    none
    MultipleVal
    NewDateOption
    Currency
End Enum



Public Enum ValidationTypes 'Describes the validation types
    None = 0
    Number
    Percentage
    Text
    CalendarDate
    PlanCurrency
End Enum

'Thsese enums are also used as keys for the items in the database
'Used to identify the queries irrespective of their ordering
Public Enum PlanQueries
    businessType = 0
    manageInventory
    inventoryTurnover
    sellOnCredit
    salesOnCredit
    collectionDays
    salesForcastType
    categorizedExpense
    personalBurden
    shortTermInterestRate
    taxRate
    nonPayrollExpense
    paymentDays
    startupOrOngoing
    planStartDate
    standardOrLongTerm
    planTitle
    longTermInterestRate
    planDescription
    basicAdvanced

    bBusinessType
    bManageInventory
    bInventoryTurnover
    bSellOnCredit
    bSalesOnCredit
    bCollectionDays
    bSalesForcastType
    bPersonalBurden
    bInterestRate
    bTaxRate
    bNonPayrollExpense
    bPaymentDays
    bStartupOrOngoing
    bPlanStartDate
    bPlanTitle
    bPlanDescription
    Currency
    bCurrency

    PlanParticulars
    ' BusinessName
    ' CompanyBusinessOwnership
    ' ContactDetails

    bPlanParticulars
    ' bBusinessName
    ' bCompanyBusinessOwnership
    ' bContactDetails

    PlanStartAndTitle
    bPlanStartAndTitle

    CreatePlan
    'Add new Queries before this comment
    start
    finish
End Enum

'Options displayed to the user that can be selected as an answer
Public Class QueryOption

    Private _optionID As Integer
    Private _optionText As String

    Public Property OptionID() As Integer
        Get
            Return _optionID
        End Get
        Set(ByVal Value As Integer)
            _optionID = Value
        End Set
    End Property

    Public Property OptionText() As String
        Get
            Return _optionText
        End Get
        Set(ByVal Value As String)
            _optionText = Value
        End Set
    End Property

End Class

'A list of options of type defined above
Public Class OptionsList

    Private _list As New ArrayList

    Default Public ReadOnly Property item(ByVal i As Integer) As QueryOption
        Get
            Return CType(_list(i), QueryOption)
        End Get
    End Property

    Public Sub Add(ByVal item As QueryOption)
        _list.Add(item)
    End Sub

    Public Sub Clear()
        _list.Clear()
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _list.Count
        End Get
    End Property

End Class
'Multiple
'A list of options of type defined above
Public Class MultipleQueryList
    Implements IPlanWizardQuery

    Private _viewID As PlanQueries
    Private _Mlist As New ArrayList

    Default Public ReadOnly Property item(ByVal i As Integer) As PlanWizardQuery
        Get
            Return CType(_Mlist(i), PlanWizardQuery)
        End Get
    End Property

    Public Sub Add(ByVal item As PlanWizardQuery)
        _Mlist.Add(item)
    End Sub

    Public Sub Clear()
        _Mlist.Clear()
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _Mlist.Count
        End Get
    End Property

    Public Property ViewID() As PlanQueries Implements IPlanWizardQuery.ViewID
        Get
            Return _viewID
        End Get
        Set(ByVal Value As PlanQueries)
            _viewID = Value
        End Set
    End Property

End Class
Public Class MultipleResponseList
    Implements IPlanWizardResponse

    Private _viewID As PlanQueries
    Private _Mlist As New ArrayList

    Default Public ReadOnly Property item(ByVal i As Integer) As PlanWizardResponse
        Get
            Return CType(_Mlist(i), PlanWizardResponse)
        End Get
    End Property

    Public Sub Add(ByVal item As PlanWizardResponse)
        _Mlist.Add(item)
    End Sub

    Public Sub Clear()
        _Mlist.Clear()
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _Mlist.Count
        End Get
    End Property

    Public Property ViewID() As PlanQueries Implements IPlanWizardResponse.ViewID
        Get
            Return _viewID
        End Get
        Set(ByVal Value As PlanQueries)
            _viewID = Value
        End Set
    End Property

End Class

'A data structure that holds the name, id and current value of any query
Public Class QuerySetting

    Private _QueryID As PlanQueries
    Private _QueryName As String
    Private _QueryValue As String

    Public Sub New(ByVal queryID As PlanQueries, ByVal queryName As String, ByVal queryValue As String)
        _QueryID = queryID
        _QueryName = queryName
        _QueryValue = queryValue
    End Sub

    Public ReadOnly Property QueryID() As PlanQueries
        Get
            Return _QueryID
        End Get
    End Property

    Public Property QueryName() As String
        Get
            Return _QueryName
        End Get
        Set(ByVal Value As String)
            _QueryName = Value

        End Set
    End Property

    Public ReadOnly Property QueryValue() As String
        Get
            Return _QueryValue
        End Get
    End Property

End Class

'A list of options of type defined above
'used by the UI to display a nav bar 
Public Class QuerySettingsList

    Private _list As New ArrayList

    Default Public ReadOnly Property item(ByVal id As Integer) As QuerySetting
        Get
            Return CType(_list(id), QuerySetting)
        End Get
    End Property

    Public Sub Add(ByVal queryID As PlanQueries, ByVal queryName As String, ByVal queryValue As String)
        _list.Add(New QuerySetting(queryID, queryName, queryValue))
    End Sub

    Public Sub Clear()
        _list.Clear()
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return _list.Count
        End Get
    End Property

End Class
