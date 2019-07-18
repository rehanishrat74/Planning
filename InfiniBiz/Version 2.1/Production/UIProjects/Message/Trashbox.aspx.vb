Public Class MessageTrashbox
    Inherits MessageDefault
    
    Protected WithEvents lblsubject As System.Web.UI.WebControls.Label
    Protected WithEvents lblservice As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.HtmlControls.HtmlInputButton
    
    Protected WithEvents Button2 As System.Web.UI.HtmlControls.HtmlInputButton


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
        ShowBox(MessageDefault.MessageBoxEnum.TRASHBOX)
        If Request("ACT") = "DEL" Then
            DeleteBoxMessages(MessageDefault.MessageBoxEnum.TRASHBOX, Request("MSG"))
            ShowBox(MessageDefault.MessageBoxEnum.TRASHBOX)
        ElseIf Request("ACT") = "RES" Then
            RestoreMessages(Request("MSG"))
            ShowBox(MessageDefault.MessageBoxEnum.TRASHBOX)
        ElseIf Request("MSG") <> "" Then
            ShowboxMessage(MessageDefault.MessageBoxEnum.TRASHBOX, Request("MSG"))
        End If
    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        'TheMenu("TRS").IsSelected = True
    End Sub

End Class
