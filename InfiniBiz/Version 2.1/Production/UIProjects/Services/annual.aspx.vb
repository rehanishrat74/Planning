Public Class ServicesAnnual
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

    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        'TheMenu("ANNL").IsSelected = True
    End Sub
    Private Sub Literal1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Literal1.Init
        If IsServiceAllowed("SAccounts") Then
            Literal1.Text = "<br><a href='/Ctreturn/Forms/introduction.aspx'><B>Statutory Accounts</b></a>"
        End If
    End Sub

    Private Sub Literal2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Literal2.Init
        If IsServiceAllowed("SAccounts") Then
#If DEBUG Then
            Literal2.Text = "<br><a href='/Ctreturn/Forms/Introduction.aspx'><IMG title='Use Online Accounting' src='/images/LogoAnnual.jpg' border=0><a>"
#Else
Literal2.Text = "<br><a href='https://www.accountscentre.com/Ctreturn/Forms/Introduction.aspx'><IMG title='Use Online Accounting' src='/images/LogoAnnual.jpg' border=0><a>"
#End If

        Else
            Literal2.Text = "<br><IMG title='Use Online Accounting' src='/images/LogoAnnual.jpg' border=0>"
        End If
    End Sub

End Class
