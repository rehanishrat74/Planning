Imports InfiniLogic.AccountsCentre.BLL

Public Class MessageInbox
    Inherits MessageDefault
#Region " Web Form Designer Generated Code "
    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        'InitializeComponent()
    End Sub
    
    Protected WithEvents lblsubject As System.Web.UI.WebControls.Label
    Protected WithEvents lblservice As System.Web.UI.WebControls.Label
    Protected WithEvents btnback As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents Button2 As System.Web.UI.HtmlControls.HtmlInputButton
    

#End Region
#Region "Variable Declaration"
    Dim strMessageType As String
#End Region
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Request("ACT") = "DEL" Then
            DeleteBoxMessages(MessageDefault.MessageBoxEnum.INBOX, Request("MSG"))
            ShowBox(MessageDefault.MessageBoxEnum.INBOX)
        ElseIf Request("ACT") = "POST" Then
            PostMessage()
        ElseIf Request("MSG") <> "" Then
            ShowboxMessage(MessageDefault.MessageBoxEnum.INBOX, Request("MSG"))
        Else
            ShowBox(MessageDefault.MessageBoxEnum.INBOX)
        End If
    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        TheMenu("INB").IsSelected = True
    End Sub


End Class
