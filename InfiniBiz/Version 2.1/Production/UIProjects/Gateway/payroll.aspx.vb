Imports InfiniLogic.AccountsCentre.BLL
Public Class GatewaysPayroll
    Inherits GatewaysDefault
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If UCase(Request("ACT")) = "REQ" Then
            MessageBoard.PostInboxMessage(customerid, "ADMIN", "Payroll", "Gateway request", "Infini Payroll", 0)
            Literal1.Text = "<font color=red><b>Gateway registration request has been sent, you will be informed shortly of a confirmation.</b></font>"
        End If
    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        ' TheMenu("PAYE").IsSelected = True

    End Sub
End Class
