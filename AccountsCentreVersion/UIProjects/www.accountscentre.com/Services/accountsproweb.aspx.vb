Imports InfiniLogic.AccountsCentre.BLL

Public Class AccountsProWeb
    Inherits ServicesDefault
    'Inherits System.Web.UI.Page

    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Literal2 As System.Web.UI.WebControls.Literal

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        'InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '       Literal1.Text = "<a href='/Express'><B>Infini Ac`counts Express</b></a>"
    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        'TheMenu("BKPN").IsSelected = True
    End Sub

    Private Sub Literal1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Literal1.Init
        If IsServiceAllowed("AccountsProWeb") Then
            Literal1.Text = "<br><a href='/accountspro/default.aspx'><B>Infini Accounts Pro (web)</b></a>"
        End If
    End Sub

    Private Sub Literal2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Literal2.Init
        If IsServiceAllowed("AccountsProWeb") Then
            Literal2.Text = "<br><a href='/accountspro/default.aspx'><IMG title='Use Accounts Pro (web)' src='" & GetImage(ServiceID.AccountsProWeb) & "' border=0><a>"
        Else
            Literal2.Text = "<br><IMG title='Use Accounts Pro (web)' src='" & GetImage(ServiceID.AccountsProWeb) & "' border=0>"
        End If
    End Sub

End Class
