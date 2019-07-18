Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient
Imports System.Text

Public Class ServicesAdmin

    Inherits System.Web.UI.Page
    Dim connstr As String
    Private selectedServices As New ArrayList()
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblErrorMessage As System.Web.UI.WebControls.Label
    Protected WithEvents TxtCustomerId As System.Web.UI.WebControls.TextBox

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim loginId As String
        loginId = Request("TxtCustomerId")
        lblErrorMessage.Visible = False

        If Page.IsPostBack Then
            'Session("cid") = loginId
            If loginId <> "" Then
                If (CustomerExists(loginId)) Then
                    Dim customerId As String = ServicesManager.GetCustomerID(loginId)
                    Response.Redirect("ServicesDetail.aspx?txtCustomerID=" & customerId)
                Else
                    lblErrorMessage.Text = "The CustomerId you entered , Does not Exist.Try again!"
                    lblErrorMessage.Visible = True
                End If
            Else
                lblErrorMessage.Text = "Please Fill In the CustomerId."
                lblErrorMessage.Visible = True
            End If
        End If
    End Sub

    Private Function CustomerExists(ByVal loginId As String) As Boolean
        Return AdminManager.CustomerExists(loginId)
    End Function



End Class
