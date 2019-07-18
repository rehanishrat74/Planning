Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient
Imports System.Text

Public Class ServicesAdmin2
    Inherits System.Web.UI.Page
    Dim connstr As String
    Private selectedServices As New ArrayList()
    Protected CustomerId As String
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents HyperLink1 As System.Web.UI.WebControls.HyperLink


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

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If (Request("txtCustomerID") <> "") Then
            CustomerId = Request("txtCustomerID")
        End If

        Dim Serviceid As String = Request("id")
        Dim action As String = Request("action")

        If Not Page.IsPostBack Then
            If action = "Disable" Then
                DisableService(Serviceid)
                UpdateServices()
            ElseIf action = "Enable" Then
                EnableService(Serviceid)
                UpdateServices()
            End If
        End If
        UpdateServices()
    End Sub

    Public Sub BindGrid()
        Dim ds As DataSet = AdminManager.GetAllServices
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()
    End Sub

    Public Function GetStatus(ByVal Id As Object) As String
        Dim Test As String = CType(Id, String).ToString
        Dim result As Boolean = selectedServices.Contains(Test)
        If (Not result) Then
            Return "Activate This Service"
        Else
            Return "DeActivate This Service"
        End If
    End Function

    Public Function GetUrl(ByVal Id As Object) As String
        Dim Test As String = CType(Id, String).ToString
        Dim result As Boolean = selectedServices.Contains(Test)
        If (Not result) Then
            Return "ServicesDetail.aspx?txtCustomerID=" & CustomerId & "&id=" & Test & "&action=Enable" ' txtCustomerID=" & CustomerId & "&
        Else
            Return "ServicesDetail.aspx?txtCustomerID=" & CustomerId & "&id=" & Test & "&action=Disable" 'txtCustomerID=" & CustomerId & "&
        End If



    End Function

    Private Sub EnableService(ByVal serviceID As String)
        Try
            AdminManager.EnableService(CustomerId, serviceID)
        Catch sqle As Exception
            Response.Write("Error Enabling Service." & sqle.Message)
        Catch e As Exception
            Response.Write("Unknown Error Occured." & e.Message)
        End Try
    End Sub

    Private Sub DisableService(ByVal serviceID As String)
        Try
            AdminManager.DisableService(CustomerId, serviceID)
        Catch sqle As Exception
            Response.Write("Error Disabling Service." & sqle.Message)
        Catch e As Exception
            Response.Write("Unknown Error Occured." & e.Message)
        End Try
    End Sub

    Private Function IsServicePresent(ByVal serviceID As String) As Boolean
        If AdminManager.IsServicePresent(CustomerId, serviceID) Then
            Return True
        Else
            Return False
        End If
        Return False
    End Function

    Private Sub UpdateServices()
        GetCustomerSelectedServices()
        BindGrid()
    End Sub

    Private Function GetCustomerSelectedServices() As ArrayList
        Dim reader As SqlDataReader = AdminManager.GetActiveServices(CustomerId)
        While reader.Read
            Dim id As String = reader("SERVICEID")
            selectedServices.Add(id)
        End While
        Return selectedServices
    End Function
End Class
