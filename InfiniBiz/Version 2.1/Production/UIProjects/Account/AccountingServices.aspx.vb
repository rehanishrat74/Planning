Imports InfiniLogic.AccountsCentre.common
Imports System.Web.Security

Imports InfiniLogic.AccountsCentre
Public Class AccountingServices
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

    Private Function DoLogin(ByVal objSecure As SecureQueryString, ByVal PageURL As String)
        With objSecure
            Dim MerchantID As String = .Item("MerchantID")
            Dim MerchantUID As String = .Item("MerchantUID")
            Trace.Write("MerchantID = " & MerchantID)
            Trace.Write("MerchantUID = " & MerchantUID)
            Trace.Write("IsMerchant = " & .Item("IsMerchant"))
            Trace.Write("IoEmployeeID = " & .Item("IoEmployeeID"))
            Trace.Write("UserID = " & .Item("UserID"))
            If Not Request.IsAuthenticated OrElse System.Web.HttpContext.Current.User.Identity.Name <> MerchantID Then
                Session.Clear()
                If Not BLL.Validation.IsUserAllowed(MerchantUID) Then
                    Response.Write("User authentication failed!")
                    Exit Function
                End If
                'FormsAuthentication.SignOut()
                Trace.Write("Calling SignInAccountsCentreUSer")
                Dim result As String = SignInAccountsCentreUSer(MerchantUID, "", True, True)
                Trace.Write("SignInAccountsCentreUSer is ok")

                Trace.Write(result)
                Trace.Write("Login Success")

                '**********************************************************************
                'If login from employee then set following sessions and variables
                BLL.PageBase.isEmployee = Not CBool(.Item("IsMerchant"))
                Session(PageTemplate.session_IsEmployee) = BLL.PageBase.isEmployee
                If BLL.PageBase.isEmployee Then
                    BLL.PageBase.merchantEmployeeID = .Item("IoEmployeeID")
                    Session(PageTemplate.session_EmployeeID) = .Item("IoEmployeeID")
                    Session("MerchantProUserID") = .Item("UserID")
                End If
                '*************************************************************************
            End If
        End With
        If PageURL.Length > 0 Then
            Session(Session_InsideIO) = True
            Response.Redirect(PageURL)
            Exit Function
        End If
    End Function

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim PageURL As String = ""
            Dim strQueryString As String = ""
            Dim objSecure As SecureQueryString = Nothing
            If Not Request("q") Is Nothing Then
                strQueryString = Request("q")
                Trace.Write("q = " & strQueryString)
                objSecure = New SecureQueryString(strQueryString)
                PageURL = objSecure.Item("PageURL")
                PageURL = CStr(PageURL).Replace("//equal//", "=")
                DoLogin(objSecure, PageURL)
            ElseIf (Not Request("goto") Is Nothing) AndAlso (Not Request("config") Is Nothing) Then
                strQueryString = Request("config")
                Trace.Write("config = " & strQueryString)
                objSecure = New SecureQueryString(strQueryString)
                PageURL = Request("goto")
                DoLogin(objSecure, PageURL)
            Else
                Response.Write("Invalid User!")
            End If
        Catch ex As Threading.ThreadAbortException
            Trace.Warn("Threading.ThreadAbortException Raised!")
        Catch ex As Exception
            Trace.Warn("Exception occured in AccountingServices.aspx.vb")
            Trace.Warn("Message = " & ex.Message)
            Trace.Warn("StackTrace = " & ex.StackTrace)
            Throw ex
        End Try
    End Sub

End Class
