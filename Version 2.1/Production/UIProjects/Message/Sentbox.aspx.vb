Public Class MessageSentbox
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

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ShowBox(MessageDefault.MessageBoxEnum.SENTBOX)
        If Request("ACT") = "DEL" Then
            DeleteBoxMessages(MessageDefault.MessageBoxEnum.SENTBOX, Request("MSG"))
            ShowBox(MessageDefault.MessageBoxEnum.SENTBOX)
        ElseIf Request("MSG") <> "" Then
            ShowboxMessage(MessageDefault.MessageBoxEnum.SENTBOX, Request("MSG"))
        End If
    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        '   TheMenu("SNT").IsSelected = True
    End Sub

End Class
