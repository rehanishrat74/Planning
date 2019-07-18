Imports System.Web.Security

Public Class SignOut
    Inherits System.Web.UI.Page

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
        'Trace.Warn("FormsAuthentication.SignOut()")
        Dim ServiceID As String = Session(PageTemplate.Session_ServiceID)
        FormsAuthentication.SignOut() 'Clear the current user session.
        'Trace.Warn("done")

        'Trace.Warn("ClearSessionVariables()")
        'ClearSessionVariables()
        'Trace.Warn("done")
        'RedirectTo(BLL.ACC_Redirection.SIGNOUT)

        'Dim script As String
        'script = "<script> window.location='https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & Session(PageTemplate.Session_ServiceID) & "' </script>"
        'Response.Write(script)
        Response.Redirect("https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & ServiceID)  ' Redirect to Home page.
    End Sub

    Private Sub ClearSessionVariables()
        Session("ACC_GV_Companies") = Nothing

        Session("ACC_GV_ParentCustomerID") = Nothing
        Session("ACC_GV_ParentUserUID") = Nothing

        Session("ACC_GV_RegCompCount") = Nothing
        Session("ACC_GV_ExcCompCount") = Nothing

        Session("ACC_GV_LastAddedCompName") = Nothing
        Session("ACC_GV_FormationsHouseAvailable") = Nothing

        Session("ACC_GV_RegistrationMode") = Nothing
    End Sub
End Class
