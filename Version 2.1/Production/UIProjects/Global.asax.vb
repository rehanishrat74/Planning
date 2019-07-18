Imports System.Web
Imports System.Web.SessionState
Imports pwdsqlsrvdotnet
Imports rsaLibrary1


Public Class Global
    Inherits System.Web.HttpApplication

#Region " Component Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application is started
        Dim _XMLRead As New clspassword
        _XMLRead.xmlfilepath = Server.MapPath("/Data/Xml/initLoc.xml")
        Application("SALESACCOUNT") = "10000"
        Application("DEBTORSCONTROLACCOUNT") = "70100"
        Application("SALESTAXCONTROLACCOUNT") = "71100"
        Application("MATERIALSPURCHASEDACCOUNT") = "20000"
        Application("CREDITORSCONTROLACCOUNT") = "71000"
        Application("VATINPUTACCOUNT") = "71101"
        Application("DEFAULTBANK") = "70200"
        Application("MISPOSTING") = "49999"
        Application("SALESDISCOUNT") = "10100"
        Application("PURCHASEDISCOUNT") = "20010"
        Application("BADDEBTS") = "40000"
        Application("EXPEMAIL") = "\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
        Application("D") = _XMLRead.ExPath("D")
        Application("N") = _XMLRead.ExPath("N")
        Application("SQLUID_DataCentre") = _XMLRead.ExPath("SQLUID_DataCentre")
        Application("SQLPWD_DataCentre") = _XMLRead.ExPath("SQLPWD_DataCentre")
        Application("DefaultAdmin") = "ADMIN"
        Application("SMPTPUSER") = "support@accountscentre.com"
        Application("SMPTPPASSWORD") = "supp"
        'Application("SMTPSERVER") = "smtp.uk.colt.net"
        'Application("SMTPSERVER") = "213.86.130.41" 'For online/local server
        'Application("SMTPSERVER") = "192.168.1.8"  ' For local server
        'Application("SMTPSERVER") = "192.168.1.4" '"213.86.130.36" ' For online server
        Application("ADMINEMAIL") = "support@accountscentre.com"


        Application("ADMINEMAILCONFIRMATION") = "registrations@accountscentre.com"
        Application("BOTTOMMENU") = "<TABLE id='Tablexxx' cellSpacing='0' cellPadding='0' width='100%' border='0'><TR><TD style='WIDTH: 253px'><IMG style='WIDTH: 265px; HEIGHT: 17px' height='17' src='images\bottom.jpg' width='265'></TD><TD bgColor='#1c6fae'><FONT face='Verdana' color='#ffffff' size='1'><a href='index.aspx'>Home</a>| <a href='services.aspx'>Online Services</a> | <a href='gateway.aspx'>Gateway Registration</a> | <a href='infodesk.aspx'>Info Desk</a> | <a href='members.aspx'>Members</a> </FONT></TD></TR></TABLE>"
        Application("ADMINID") = "admin"
        _XMLRead = Nothing
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session is started
        'Session"
    End Sub

    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires at the beginning of each request
        If (Request.Path.IndexOf(Chr(92)) >= 0 Or _
        System.IO.Path.GetFullPath(Request.PhysicalPath) <> Request.PhysicalPath) Then
            Throw New HttpException(404, "Not Found")
        End If

    End Sub

    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires upon attempting to authenticate the use
    End Sub

    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when an error occurs
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the session ends
    End Sub

    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Fires when the application ends
    End Sub

End Class
