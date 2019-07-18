Imports Infinilogic.BusinessPlan.Web.Common
Public Class ErrorPage
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblError As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Protected WithEvents lftBar As New Infinilogic.BusinessPlan.Web.LeftBar

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '

        If Session.Item("errorText") Is Nothing Then
            lblError.Visible = False
            lblError.Text = ""
        Else
            lblError.Visible = True
            lblError.Text = CType(Session.Item("errorText"), String)
            Session.Remove("errorText")
        End If

        lblError.Text = "We apologise for this error as we could not comply with your request. A notification of this error has been sent to our systems administrators who are already working to resolve this problem."


    End Sub

End Class
