Public Class PlanWizardQuery
    Implements IPlanWizardQuery

    Private _viewID As planQueries
    Private _viewType As QuestionTypes
    Private _title As String
    Private _text As String
    Private _helpText As String
    Private _optionItemList As New OptionsList
    Private _validationType As ValidationTypes
    Private _selectionID As Single
    Private _selectionText As String

    Public Property ViewID() As PlanQueries Implements IPlanWizardQuery.ViewID
        Get
            Return _viewID
        End Get
        Set(ByVal Value As PlanQueries)
            _viewID = Value
        End Set
    End Property

    Public Property ViewType() As QuestionTypes
        Get
            Return _viewType
        End Get
        Set(ByVal Value As QuestionTypes)
            _viewType = Value
        End Set
    End Property

    Public Property Title() As String
        Get
            Return _title
        End Get
        Set(ByVal Value As String)
            _title = Value
        End Set
    End Property

    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal Value As String)
            _text = Value
        End Set
    End Property

    Public Property HelpText() As String
        Get
            Return _helpText
        End Get
        Set(ByVal Value As String)
            _helpText = Value
        End Set
    End Property

    Public ReadOnly Property OptionItemList() As OptionsList
        Get
            Return _optionItemList
        End Get
    End Property

    Public Property ValidationType() As ValidationTypes
        Get
            Return _validationType
        End Get
        Set(ByVal Value As ValidationTypes)
            _validationType = Value
        End Set
    End Property

    Public Property SelectionID() As Single
        Get
            Return _selectionID
        End Get
        Set(ByVal Value As Single)
            _selectionID = Value
        End Set
    End Property

    Public Property SelectionText() As String
        Get
            Return _selectionText
        End Get
        Set(ByVal Value As String)
            _selectionText = Value
        End Set
    End Property

End Class

Public Class PlanWizardResponse
    Implements IPlanWizardResponse

    Private _viewID As planQueries
    Private _selectionID As Single
    Private _selectionText As String

    Public Property ViewID() As PlanQueries Implements IPlanWizardResponse.ViewID
        Get
            Return _viewID
        End Get
        Set(ByVal Value As PlanQueries)
            _viewID = Value
        End Set
    End Property

    Public Property SelectionID() As Single
        Get
            Return _selectionID
        End Get
        Set(ByVal Value As Single)
            _selectionID = Value
        End Set
    End Property

    Public Property SelectionText() As String
        Get
            Return _selectionText
        End Get
        Set(ByVal Value As String)
            _selectionText = Value
        End Set
    End Property

End Class


'A data structure that contains few important particulars of a plan
Public Class PlanParticulars

    Private _planID As Integer
    Private _name As String
    Private _description As String
    Private _dateCreated As String

    Public Sub New(ByVal planID As Integer, ByVal name As String, ByVal description As String, ByVal dateCreated As String)
        _planID = planID
        _name = name
        _description = description
        _dateCreated = dateCreated
    End Sub

    Public ReadOnly Property PlanID() As Integer
        Get
            Return _planID
        End Get
    End Property

    Public ReadOnly Property Name() As String
        Get
            Return _name
        End Get
    End Property

    Public ReadOnly Property Description() As String
        Get
            Return _description
        End Get
    End Property

    Public ReadOnly Property DateCreated() As String
        Get
            Return _dateCreated
        End Get
    End Property

End Class


'A list of plan particulars of type defined above
'used by the UI to display in a list control 
Public Class PlanList

    Private _list As New ArrayList

    Default Public ReadOnly Property item(ByVal id As Integer) As PlanParticulars
        Get
            Return CType(_list(id), PlanParticulars)
        End Get
    End Property

    Public Sub Add(ByVal planID As Integer, ByVal name As String, ByVal description As String, ByVal dateCreated As String)
        _list.Add(New PlanParticulars(planID, name, description, dateCreated))
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