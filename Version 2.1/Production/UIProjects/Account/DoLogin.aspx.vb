#Region "Libraries"

Imports InfiniLogic.AccountsCentre.Common

#End Region

Public Class DoLogin

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        'If AutoLogin.ValidateIP(Request) = False Then
        '    Response.Redirect("https://www.accountscentre.com/account/signin.aspx")
        'End If

        Dim strUserID, strPassword As String
        Try
            Dim strQueryString As String = Request("q")
            Dim objSecureQueryString As New SecureQueryString(strQueryString)
            'strserviceCaller = [Enum].IsDefined("", "")
            With objSecureQueryString
                strUserID = .Item("UserID")
                strPassword = .Item("Password")
                Session(ACC_SessionID) = .Item(ACC_SessionID)
            End With

        Catch ee As Exception
            'select case 
            'xResponse.Redirect("https://www.formationshouse.com/search/ereg/login.php")
            AutoLogin.WriteDebugInfo("DoLogin.aspx->TimeStamp:" & Now)
            AutoLogin.WriteDebugInfo("Exception:" & ee.ToString)
            AutoLogin.WriteDebugInfo("Request(q):" & Request("q"))
            'Response.Redirect("http://www.yahoo.com")
            RedirectTo(BLL.ACC_Redirection.SIGNIN)
        End Try
        SignInAccountsCentreUSer(strUserID, strPassword)

    End Sub



End Class