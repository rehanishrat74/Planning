#Region "Libraries"
Imports Infinilogic.AccountsCentre
Imports Infinilogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Diagnostics
Imports System.IO

#End Region

Public Class Secure
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
        Dim strUserID, strPassword As String
        WriteDebugInfo("------------Start Log-----------------")
        Try
            Dim strQueryString As String = Request("q")
            Dim objSecureQueryString As New SecureQueryString(strQueryString)

            With objSecureQueryString
                strUserID = .Item("UserID")
                strPassword = .Item("Password")
                Session(ACC_SessionID) = .Item(ACC_SessionID)
                WriteDebugInfo("UserId " + strUserID + "----Password-- " + strPassword + "----Session---- " + Session(ACC_SessionID))

                WriteDebugInfo("Calling SignInAccountsCentreUSer with parameters")
                WriteDebugInfo("    strUserID = " & strUserID)
                WriteDebugInfo("    strPassword = " & strPassword)
                SignInAccountsCentreUSer(strUserID, strPassword, False, True)
                WriteDebugInfo("SignInAccountsCentreUSer is ok")

                'Response.Redirect("~Members/CompanyList.aspx")
            End With
        Catch ee As Exception
            WriteDebugInfo("DoLogin.aspx->TimeStamp:" & Now)
            WriteDebugInfo("Exception: " & ee.ToString)
            WriteDebugInfo("Request(q): " & Request("q"))
            WriteDebugInfo("Message: " + ee.Message)
            RedirectTo(BLL.ACC_Redirection.SIGNIN)
        End Try

    End Sub

    Private Sub WriteDebugInfo(ByVal sText As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
                System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\Secure.aspx.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub
End Class
