Public Class DateCtrl
    Inherits System.Web.UI.UserControl
    Private Const _startYear As Integer = 1996 '1955
    Private Const _yearGap As Integer = 15 '60
    Private _date As Date
    Private _enabled As Boolean = True
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DDLDate As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLYear As System.Web.UI.WebControls.DropDownList

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

#End Region

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        PopulateYearDropDownList()
        SetTodayDate()
        InitializeComponent()
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DDLDate.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        Me.DDLMonth.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        Me.DDLYear.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        'Me.DDLYear.Attributes("onClick") = "ValidateDate('01/02/2000')"
        LoadDate()
    End Sub
    Private Sub LoadDate()
        Me._date = New Date(Me.DDLYear.SelectedItem.Text, Me.DDLMonth.SelectedValue, Me.DDLDate.SelectedValue)
    End Sub
    Private Sub PopulateYearDropDownList()

        Dim Counter As Integer
        For Counter = _startYear To _startYear + _yearGap
            Me.DDLYear.Items.Add(New ListItem(Counter, Counter))
        Next

    End Sub

    Private Sub SetTodayDate()
        Me._date = Today
        Me.DDLDate.SelectedIndex = Today.Day - 1
        Me.DDLMonth.SelectedIndex = Today.Month - 1
        Me.DDLYear.SelectedIndex = Me.DDLYear.Items.IndexOf(New ListItem(Today.Year))
    End Sub

    Private Sub SetDate(ByVal inputDate As Date)
        Me._date = inputDate
        Me.DDLDate.SelectedIndex = inputDate.Day - 1
        Me.DDLMonth.SelectedIndex = inputDate.Month - 1
        Me.DDLYear.SelectedIndex = Me.DDLYear.Items.IndexOf(New ListItem(inputDate.Year))
    End Sub

    Private Sub Enable(ByVal enable As Boolean)
        Me.DDLYear.Enabled = enable
        Me.DDLDate.Enabled = enable
        Me.DDLMonth.Enabled = enable
    End Sub

    Public Property [Date]() As Date
        Get
            LoadDate()
            Return Me._date
        End Get
        Set(ByVal Value As Date)
            SetDate(Value)
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return Me._enabled
        End Get
        Set(ByVal Value As Boolean)
            Me._enabled = Value
            Me.Enable(Me._enabled)
        End Set
    End Property

End Class
