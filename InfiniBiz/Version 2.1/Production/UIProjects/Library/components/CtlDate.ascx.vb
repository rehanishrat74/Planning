Public Class CtlDate
    Inherits System.Web.UI.UserControl
    Private Const _startYear As Integer = 1940 '1955
    Private Const _yearGap As Integer = 75 '60
    Private _date As Date
    Private _enabled As Boolean = True
#Region " Web Form Designer Generated Code "

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DDLDate1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLMonth1 As System.Web.UI.WebControls.DropDownList
    Protected WithEvents DDLYear1 As System.Web.UI.WebControls.DropDownList
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        PopulateYearDropDownList()
        SetTodayDate()
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.DDLDate1.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        Me.DDLMonth1.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        Me.DDLYear1.Attributes("onChange") = "ValidateDate('" & Me.ClientID & "');"
        'Me.DDLYear1.Attributes("onClick") = "ValidateDate('01/02/2000')"
        LoadDate()
    End Sub
    Private Sub LoadDate()
        Me._date = New Date(Me.DDLYear1.SelectedItem.Text, Me.DDLMonth1.SelectedValue, Me.DDLDate1.SelectedValue)
    End Sub
    Private Sub PopulateYearDropDownList()

        Dim Counter As Integer
        For Counter = _startYear To _startYear + _yearGap
            Me.DDLYear1.Items.Add(New ListItem(Counter, Counter))
        Next

    End Sub

    Private Sub SetTodayDate()
        Me._date = Today
        Me.DDLDate1.SelectedIndex = Today.Day - 1
        Me.DDLMonth1.SelectedIndex = Today.Month - 1
        Me.DDLYear1.SelectedIndex = Me.DDLYear1.Items.IndexOf(New ListItem(Today.Year))
    End Sub

    Private Sub SetDate(ByVal inputDate As Date)
        Me._date = inputDate
        Me.DDLDate1.SelectedIndex = inputDate.Day - 1
        Me.DDLMonth1.SelectedIndex = inputDate.Month - 1
        Me.DDLYear1.SelectedIndex = Me.DDLYear1.Items.IndexOf(New ListItem(inputDate.Year))
    End Sub

    Private Sub Enable(ByVal enable As Boolean)
        Me.DDLYear1.Enabled = enable
        Me.DDLDate1.Enabled = enable
        Me.DDLMonth1.Enabled = enable
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
