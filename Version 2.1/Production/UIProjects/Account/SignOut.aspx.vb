Imports System.Web.Security

Public Class SignOut
    Inherits PageTemplate

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

        FormsAuthentication.SignOut() 'Clear the current user session.
        ClearSessionVariables()
        RedirectTo(BLL.ACC_Redirection.SIGNOUT)
        '        Response.Redirect("http://www.accountscentre.com") ' Redirect to Home page.
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
