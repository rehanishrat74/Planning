Imports System.Data
Imports System.Data.SqlClient

Public Class admin
    Inherits System.Web.UI.Page
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Sub DoLogin()

        Dim UserId As String = "admin"
        Dim UserUId As String
        Dim UserPassword As String
        Dim dbPassword As String = "admin"

        UserUId = Trim(TextBox1.Text)
        UserPassword = Trim(TextBox2.Text)

        If UserUId = "" Then
            Label3.Text = "Please enter User ID. "
            Exit Sub
        End If
        If UserPassword = "" Then
            Label3.Text = "Please enter User Password. "
            Exit Sub
        End If
        Label3.Text = ""

        If UserId <> UserUId Then
            Label3.Text = "Please enter Valid User ID. "
            Exit Sub
        End If
        If UserPassword <> dbPassword Then
            Label3.Text = "Please enter Valid User Password. "
            Exit Sub
        End If
        Response.Redirect("ServicesAdmin.aspx")
    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Page.IsPostBack Then
            DoLogin()
        End If

    End Sub
End Class
