Imports InfiniLogic.AccountsCentre.common
Imports System.Web.Mail

Public Class WebForm1
    Inherits System.Web.UI.Page

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
        Dim errorMsg As String
        'Put user code to initialize the page here
        Response.Write(CommonBase.SendEmail("afaq@infinilogic.com", "afaq@infinilogic.com", _
                                     "Test Email", "Test Email", MailFormat.Html))

        'Dim mail As New System.Web.Mail.MailMessage
        'mail.To = "afaq@infinilogic.com"
        'mail.From = "afaq@infinilogic.com"
        'mail.Subject = "Test Email"
        'mail.Body = "Test Email"
        'mail.BodyFormat = MailFormat.Html
        'System.Web.Mail.SmtpMail.SmtpServer = "127.0.0.1"

        ''If ConfigReader.GetItem(ConfigVariables.SMTP_Authentication) = "1" Then
        ''    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
        ''    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigReader.GetItem(ConfigVariables.SMTPUserID)) 'set your username here
        ''    mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigReader.GetItem(ConfigVariables.SMTPPassword))  'set your password here
        ''End If
        'Try
        '    System.Web.Mail.SmtpMail.Send(mail)
        '    'Raise mail sucess event
        'Catch ex As Exception
        '    errorMsg = ex.Message
        '    'Raise mail fail event            
        'Finally
        '    mail = Nothing
        'End Try

        'Response.Write(errorMsg)
    End Sub

End Class
