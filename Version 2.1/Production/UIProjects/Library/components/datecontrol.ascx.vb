Public Class datecontrol
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents drpDay As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents drpYear As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "CLASS-DECLARATIONS"

    Public Const DATE_SEPERATOR As Char = "/"c
    Private _blnIsOptional As Boolean
    Private _day_startrange As Integer = 1
    Private _month_startrange As Integer = 1
    Private _year_startrange As Integer = Year(Now)

    Private _day_endrange As Integer = 31
    Private _month_endrange As Integer = 12
    Private _year_endrange As Integer = _year_startrange + 5

    Private _userdefined_startdate As Date
    Private _userdefined_enddate As Date

    Private _default_date As Date = Now

#End Region

#Region "PROPERTIES"

    Public ReadOnly Property GetDate() As Date
        Get
            'Try
            Return New Date(drpYear.SelectedItem.Text, drpMonth.SelectedValue, drpDay.SelectedValue)
            'Catch ex As Exception
            '    Return Nothing
            'End Try
        End Get
    End Property
    Public ReadOnly Property GetDateInString(Optional ByVal chSplitter As Char = DATE_SEPERATOR) As String
        Get
            'Try
            '    Dim a As Date = CDate(drpDay.SelectedItem.Text + "/" + drpMonth.SelectedItem.Text + "/" + drpYear.SelectedItem.Text)
            'Catch ex As Exception
            '    Return Nothing
            'End Try
            If chSplitter = DATE_SEPERATOR Then
                Return ToString()
            Else
                Return ToString.Replace(DATE_SEPERATOR, chSplitter)
            End If

        End Get
    End Property

    Public Overrides Function ToString() As String
        Return drpDay.SelectedItem.Text & DATE_SEPERATOR & drpMonth.SelectedItem.Text & DATE_SEPERATOR & drpYear.SelectedItem.Text
    End Function


    Public WriteOnly Property Enabled() As Boolean
        Set(ByVal Value As Boolean)
            drpDay.Enabled = Value
            drpMonth.Enabled = Value
            drpYear.Enabled = Value
        End Set
    End Property

    Public Property IsOptional() As Boolean
        Get
            Return _blnIsOptional
        End Get
        Set(ByVal Value As Boolean)
            _blnIsOptional = Value
        End Set
    End Property

#End Region

#Region "PUBLIC METHODS"

    Public Sub SetDate(ByVal inputdate As Date)

        If ValidateDateRange(inputdate) Then
            drpDay.SelectedValue = Day(inputdate)
            drpMonth.SelectedValue = Month(inputdate)
            drpYear.SelectedValue = Year(inputdate)
        End If
        _default_date = inputdate
    End Sub

    Public Sub SetDate(ByVal value As String)
        SetDate(CDate(value))
    End Sub

    Public Sub SetRange(ByVal StartDate As Date, ByVal EndDate As Date)
        _day_startrange = Day(StartDate) : _month_startrange = Month(StartDate) : _year_startrange = Year(StartDate)

        _day_endrange = Day(EndDate) : _month_endrange = Month(EndDate) : _year_endrange = Year(EndDate)

        _userdefined_startdate = StartDate : _userdefined_enddate = EndDate

        StoreRangeInViewState()
        Populate(True)
        SetDateAfterSetRange()
    End Sub

    Public Sub SetRange(ByVal StartDay As Integer, ByVal StartMonth As Integer, ByVal StartYear As Integer, ByVal EndDay As Integer, ByVal EndMonth As Integer, ByVal EndYear As Integer)
        Dim dtStartDate As Date = New Date(StartYear, StartMonth, StartDay)
        Dim dtEndDate As Date = New Date(EndYear, EndMonth, EndYear)
        SetRange(dtStartDate, dtEndDate)
    End Sub

    Public Function IsDateValid() As Boolean

        If IsOptional AndAlso IsNotSelected() Then
            Return True
        ElseIf Not IsSelected() Then
            Return False
        End If

        Return (Microsoft.VisualBasic.IsDate(drpDay.SelectedValue & DATE_SEPERATOR & drpMonth.SelectedValue & DATE_SEPERATOR & drpYear.SelectedValue))

    End Function

    Public Function IsSelected() As Boolean

        Return Not (drpDay.SelectedValue = String.Empty OrElse drpMonth.SelectedValue = String.Empty OrElse drpYear.SelectedValue = String.Empty)

    End Function

    Public Function IsNotSelected() As Boolean

        Return (drpDay.SelectedValue = String.Empty AndAlso drpMonth.SelectedValue = String.Empty AndAlso drpYear.SelectedValue = String.Empty)

    End Function

#End Region

#Region "PRIVATE METHODS"

    Private Sub StoreRangeInViewState()
        ViewState("_userdefined_startdate") = _userdefined_startdate
        ViewState("_userdefined_enddate") = _userdefined_enddate
    End Sub

    Private Sub Populate(Optional ByVal SetOptionalValue As Boolean = False)

        If (_year_startrange <> _year_endrange) Then
            _day_startrange = 1 : _day_endrange = 31
            _month_startrange = 1 : _month_endrange = 12
        ElseIf (_month_startrange <> _month_endrange) Then
            _day_startrange = 1 : _day_endrange = 31
        End If

        PopulateList(drpDay, _day_startrange, _day_endrange, SetOptionalValue)
        PopulateList(drpMonth, _month_startrange, _month_endrange, SetOptionalValue)
        PopulateList(drpYear, _year_startrange, _year_endrange, SetOptionalValue)

    End Sub

    Private Sub PopulateList(ByVal drp As DropDownList, ByVal startRange As Integer, ByVal endRange As Integer, ByVal SetOptionalValue As Boolean)
        drp.Items.Clear()
        Dim i As Integer

        For i = startRange To endRange
            drp.Items.Add(i)
        Next
        If IsOptional Then
            drp.Items.Insert(0, "")
            If SetOptionalValue Then drp.SelectedValue = ""
        End If
    End Sub

    Private Function ValidateDateRange(ByRef currentdate As Date) As Boolean
        If (_userdefined_enddate <> #12:00:00 AM# OrElse _userdefined_startdate <> #12:00:00 AM#) Then
            If Not (currentdate <= _userdefined_enddate AndAlso currentdate >= _userdefined_startdate) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub SetDateAfterSetRange()
        If Not IsOptional Then
            If Now <= _userdefined_enddate AndAlso Now >= _userdefined_startdate Then
                SetDate(Now)
            Else
                SetDate(_userdefined_startdate)
            End If
        End If
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not (IsPostBack) Then
            Populate(True)
            If Not IsOptional Then
                drpDay.SelectedValue = Day(_default_date)
                drpMonth.SelectedValue = Month(_default_date)
                drpYear.SelectedValue = Year(_default_date)
            End If

        End If
        _userdefined_enddate = ViewState("_userdefined_enddate")
        _userdefined_startdate = ViewState("_userdefined_startdate")
    End Sub

End Class

