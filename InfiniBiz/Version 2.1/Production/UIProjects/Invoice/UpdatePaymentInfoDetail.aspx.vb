Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient

Public Class UpdatePaymentInfoDetail
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblOrderNo As System.Web.UI.WebControls.Label
    Protected WithEvents dgrdOrder As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblordernumber As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        load_culture(Session("SelectedCulture").ToString)
        Dim objUser As New User
        Dim intOrderNo As Integer = Request.Item("order")

        lblOrderNo.Text = intOrderNo.ToString

        'Dim dt As DataTable = objUser.AccGetOrderDetails(CustomerID, intOrderNo)

        'If dt.Rows.Count > 0 Then
        '    dgrdOrder.DataSource = dt.DefaultView
        '    dgrdOrder.DataBind()
        'End If

        Try
            Dim dr As SqlDataReader

            Try
                dr = objUser.AccGetOrderDetails(CustomerID, intOrderNo)
                dgrdOrder.DataSource = dr
                dgrdOrder.DataBind()
            Catch ex As Exception
            Finally
                dr.Close()
            End Try
        Catch ex As Exception
        End Try

    End Sub

End Class
