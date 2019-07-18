Imports InfiniLogic.AccountsCentre.BLL
Public Class InfoDeskTaxUpdates
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
        InitializeComponent()
    End Sub

#End Region

    Sub ShowTaxupdate(ByVal Id As Object)
        Dim oReader As Object
        oReader = MessageBoard.GetTaxUpdate(Id)
        While oReader.read()
            membersarea.InnerHtml = oReader("taxupdate")
        End While
        oReader = Nothing

    End Sub
    Public Sub ShowTaxupdatesList()

        Dim oReader As Object, i As Boolean = False
        oReader = MessageBoard.GetTaxUpdatesList
        TheMenu.AddItem("a1", "&nbsp;&nbsp;<b><u>Archives</u></b>", "", False, False, False, 40, , True)
        While oReader.read()
            If nLetter <= 0 Then
                If i = False Then nLetter = Val(oReader("id"))
            End If
            If Val(oReader("id")) = nLetter Then
                TheMenu.AddItem("N" & oReader("id"), "&nbsp;" & Format(oReader("date"), "dd/MM/yyyy"), "/infodesk/taxupdates.aspx?TXT=" & oReader("id"), False, True, False, 15, True)
            Else
                TheMenu.AddItem("N" & oReader("id"), "&nbsp;" & Format(oReader("date"), "dd/MM/yyyy"), "/infodesk/TaxUpdates.aspx?TXT=" & oReader("id"), False, False, False, 15, True)
            End If
            i = True
        End While
        oReader = Nothing
    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

    End Sub
    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        nLetter = Val(Request("txt"))
        ShowTaxupdatesList()
        ShowTaxupdate(nLetter)
        'TheMenu("M2").IsSelected = True
    End Sub
End Class
