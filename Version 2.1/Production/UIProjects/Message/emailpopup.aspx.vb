Imports System.Web.Mail
Public Class emailpopup
    Inherits System.Web.UI.Page
    Protected WithEvents txtpsubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents email As System.Web.UI.WebControls.TextBox
    Protected WithEvents btpostreply As System.Web.UI.WebControls.Button
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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        If Not IsPostBack Then
            If Len(Session("UserEmail")) > 0 Then email.Text = Session("UserEmail") Else email.Text = "Please enter your email"
        End If
    End Sub
    Private Sub btpostreply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btpostreply.Click
        'Dim ob As New System.Web.Mail.MailMessage()

        'System.Web.Mail.SmtpMail.SmtpServer = Application("SMTPSERVER")
        ''System.Web.Mail.SmtpMail.SmtpServer
        'ob.Headers.Add("http://schemas.microsoft.com/cdo/configuration/smtperver", Application("SMTPSERVER"))
        'ob.Headers.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25)

        ''http://schemas.microsoft.com/cdo/configuration/smtpauthenticate
        'ob.Headers.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1)
        'ob.Headers.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "asifali@infinilogic.com")
        'ob.Headers.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "asifali")

        'ob.To = Application("ADMINEMAIL")
        'ob.From = "asif2k@hotmail.com"

        ''If Len(Session("UserEmail")) > 0 Then ob.From = Session("UserEmail") Else ob.From = "UnKnown"
        'ob.Subject = txtpsubject.Text
        'ob.Body = txtpMessage.Text
        'System.Web.Mail.SmtpMail.Send(ob)
        'ob = Nothing

        Dim mail As New System.Web.Mail.MailMessage()
        mail.To = Application("ADMINEMAIL")
        mail.From = email.Text
        If Len(Session("UserEmail")) > 0 Then mail.From = Session("UserEmail") Else If Len(email.Text) = 0 Then mail.From = "UnKnown@unknown.com"
        mail.Subject = txtpsubject.Text
        mail.Body = txtpMessage.Text
        PageTemplate.AuthMailMessage(mail, Application("SMPTPUSER"), Application("SMPTPPASSWORD"))
        System.Web.Mail.SmtpMail.SmtpServer = Application("SMTPSERVER")
        System.Web.Mail.SmtpMail.Send(mail)
        mail = Nothing
        Response.Redirect("emailpopup.aspx?PAGE=MAIL")
    End Sub
End Class
