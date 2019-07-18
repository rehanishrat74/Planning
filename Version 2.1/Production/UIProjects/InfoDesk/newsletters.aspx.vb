Imports InfiniLogic.AccountsCentre.BLL
Public Class InfoDeskNewsletters
    Inherits InfoDeskDefault
   

    'Inherits System.Web.UI.Page

    Dim nLetter As Object
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        '  InitializeComponent()
    End Sub

#End Region

    Sub ShowNewsletter(ByVal Id As Object)
        Dim oReader As Object
        oReader = MessageBoard.GetNewsletter(ID)
        While oReader.read()
            membersarea.InnerHtml = oReader("newsletter")
        End While
        oReader = Nothing

    End Sub
    Sub ShowNewsletterList()

        Dim oReader As Object, i As Boolean = False
        oReader = MessageBoard.GetNewsletterList
        TheMenu.AddItem("a1", "&nbsp;&nbsp;<b><u>Archives</u></b>", "", False, False, False, 40, , True)
        While oReader.read()
            If nLetter <= 0 Then
                If i = False Then nLetter = Val(oReader("id"))
            End If
            If Val(oReader("id")) = nLetter Then
                TheMenu.AddItem("N" & oReader("id"), "&nbsp;" & Format(oReader("date"), "dd/MM/yyyy"), "/infodesk/newsletters.aspx?NEWS=" & oReader("id"), False, True, False, 15, True)
            Else
                TheMenu.AddItem("N" & oReader("id"), "&nbsp;" & Format(oReader("date"), "dd/MM/yyyy"), "/infodesk/newsletters.aspx?NEWS=" & oReader("id"), False, False, False, 15, True)
            End If
            i = True
        End While
        oReader = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        nLetter = Val(Request("news"))
        'ShowNewsletterList()
        ' ShowNewsletter(nLetter)
        ' TheMenu("M3").IsSelected = True
    End Sub
End Class
