Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient

Public Class SignIn
    'Inherits System.Web.UI.Page
    Inherits PageTemplate

    Protected WithEvents txtuserid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Private _strDatabaseName As String = String.Empty
    Private _strDataSource As String = String.Empty
    Protected WithEvents btnForgotPassword As System.Web.UI.WebControls.Button
    Protected WithEvents btnRegister As System.Web.UI.WebControls.Button
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell




    Protected WithEvents btnSignin As System.Web.UI.WebControls.Button

    'Public Shared ReadOnly SignInAttemptFailed As String = ACCMessage.Account_SignInAttemptFailed

    '  Private _objUser As New User()
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

        'Added by Afaq Ali on 5-dec-2005 for Common Login
        'RedirectTo(ACC_Redirection.SIGNIN)

        '*********(MNS)************
        SetFocus(txtuserid)
        '**************************

        If User.Identity.IsAuthenticated Then Response.Redirect("/default.aspx")
        If Page.IsPostBack Then



        End If
    End Sub


    '    'Private Function SignIn()

    '    Dim exp As String = "txtuserid-0100100080-You must enter a valid userid,txtpassword-0203400160-You must enter a valid password"
    '    exp = ApplyRegularExpressions(exp)
    '    If Len(exp) > 0 Then
    '        ErrorMessage = exp
    '        Exit Function
    '    End If

    '    Dim objCryptography As New Cryptography()
    '    Dim objUser As New User()

    '    Dim blnMsg As Boolean

    '    Dim strUserID, strPassword, Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
    '    Dim CustomerID As Int32 'Unique ID for employer
    '    Dim strGKeyLen As Integer = 1024
    '    Dim intReturnValue, intReturnValue1 As Int16

    '    ErrorMessage = String.Empty
    '    CustomerID = 0
    '    strLogKey = String.Empty
    '    strDatabaseName = String.Empty
    '    intReturnValue = 0
    '    intReturnValue1 = 0

    '    strUserID = txtuserid.Text  ' Login ID
    '    strPassword = txtpassword.Text ' Plain text Password

    '    'Verify the user credentials and get the customer ID and Database names.
    '    Dim b As Boolean

    '    objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
    '    'objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, _strDataSource, b)

    '    strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)

    '    If intReturnValue = 0 Then

    '        ErrorMessage = SignInAttemptFailed


    '    Else

    '        If strPassword.ToString = strDecryptPassword.ToString Then

    '            ' Customer specific info related to Message board.
    '            Dim oReader As Collection
    '            oReader = objUser.LoadAccountscetreUser(CustomerID)
    '            Session("UserUID") = strUserID
    '            Session("UserEmail") = oReader.Item("email")
    '            Session("MSGPERPAGE") = oReader.Item("msgperpage")

    '            ' Save minimal state info and redirect to the page.
    '            Response.Cookies.Add(New HttpCookie("CustomerName", oReader.Item("name")))
    '            Response.Cookies.Add(New HttpCookie("DatabaseName", _strDatabaseName))
    '            Response.Cookies.Add(New HttpCookie("DataSource", _strDataSource))
    '            ' Check the customer services and activate them
    '            '/.................................Rem SR
    '            'UpdateCustomerStatusIfAnyServiceExpired()
    '            Dim objSubscriptionStatus As New SubscripitonStatus
    '            Dim StrServiceName As String
    '            objSubscriptionStatus.updateCustSelSrvStatusIfAnySrvExpired(CustomerID)
    '            '................................./
    '            'DoServices(CustomerID)
    '            Dim cServices As ArrayList = AccountsCentre.BLL.ServicesManager.GetServicesAllowed(CustomerID)
    '            Session("Services") = cServices
    '            FormsAuthentication.SetAuthCookie(CustomerID.ToString, False)
    '            'Response.Write("Url=" & FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))
    '            'Response.End()


    '            If Left(Trim(UCase(FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))), 9) = "/DEFAULT." Then
    '                'FormsAuthentication.RedirectFromLoginPage(CustomerID.ToString, False)


    '                '/..........................................Rem SR
    '                'xResponse.Redirect("/members/default.aspx")
    '                If objSubscriptionStatus.doesItRequireSubscriptionPrompt(CustomerID) = True Then
    '                    Response.Redirect("subscription.aspx")
    '                Else
    '                    Response.Redirect("/members/default.aspx")
    '                End If
    '                '........................................../

    '            Else

    '                '/..........................................Rem SR
    '                'xFormsAuthentication.RedirectFromLoginPage(CustomerID.ToString, False)
    '                Dim iSlashPos As Integer
    '                Dim sServiceName As String

    '                If Len(FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False)) > 0 Then
    '                    sServiceName = FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False).Substring(1)
    '                    iSlashPos = InStr(sServiceName, "/")
    '                    If iSlashPos <> 0 Then
    '                        sServiceName = Left(sServiceName, iSlashPos - 1)
    '                    Else
    '                        sServiceName = ""
    '                    End If
    '                End If

    '                If objSubscriptionStatus.doesItRequireSubscriptionPrompt(CustomerID, sServiceName) = True Then
    '                    Response.Redirect("subscription.aspx?ourl=" & FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))
    '                Else
    '                    FormsAuthentication.RedirectFromLoginPage(CustomerID.ToString, False)
    '                End If
    '                '........................................../


    '                End If

    '        Else

    '                ErrorMessage = SignInAttemptFailed

    '        End If
    '        End If

    'End Function

    Private Function SignIn()

        Dim exp As String = "txtuserid-0203400200-You must enter a valid userid,txtpassword-0203402550-You must enter a valid password"
        exp = ApplyRegularExpressions(exp)
        If Len(exp) > 0 Then
            ErrorMessage = exp
            Exit Function
        End If

        'Dim objCryptography As New Cryptography
        Dim objUser As New User
        SignInAccountsCentreUSer(txtuserid.Text, txtpassword.Text, False, True)
        Response.Redirect("https://ac.infiniplan.com/infiniplan/services/plan/planmanager.aspx")
        'Dim blnMsg As Boolean

        'Dim strUserID, strPassword, Password, strGKey, strDecryptPassword, strEncryptPassword, strLogKey, strDatabaseName As String
        'Dim CustomerID As Int32 'Unique ID for employer
        'Dim strGKeyLen As Integer = 1024
        'Dim intReturnValue, intReturnValue1 As Int16

        'ErrorMessage = String.Empty
        'CustomerID = 0
        'strLogKey = String.Empty
        'strDatabaseName = String.Empty
        'intReturnValue = 0
        'intReturnValue1 = 0

        'strUserID = txtuserid.Text  ' Login ID
        'strPassword = txtpassword.Text ' Plain text Password

        ''Verify the user credentials and get the customer ID and Database names.
        'Dim b As Boolean

        'objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, b)
        ''objUser.VerifySignIn(strUserID, Password, CustomerID, strLogKey, intReturnValue, _strDatabaseName, _strDataSource, b)

        'strDecryptPassword = objCryptography.DeCrypt(Password, strLogKey)

        'If intReturnValue = 0 Then

        '    ErrorMessage = SignInAttemptFailed


        'Else

        '    If strPassword.ToString = strDecryptPassword.ToString Then

        '        ' Customer specific info related to Message board.
        '        Dim oReader As Collection
        '        Dim objCustomer As New User()
        '        Dim ds As DataSet
        '        Dim strEmailCustomer As String

        '        ds = objCustomer.GetCustomerData(CustomerID)

        '        If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
        '            ' set the result of data row
        '            Dim dt1 As DataTable = ds.Tables(0)
        '            Dim dr1 As DataRow = dt1.Rows(0)

        '            If Not IsDBNull(dr1.Item(7)) Then
        '                strEmailCustomer = dr1.Item(7)
        '            Else
        '                strEmailCustomer = strNullString
        '            End If

        '        End If

        '        oReader = objUser.LoadAccountscetreUser(CustomerID)
        '        Session("UserUID") = strUserID
        '        If IsDBNull(oReader.Item("email")) Or strEmailCustomer = strNullString Then
        '            Session("UserEmail") = strNullString
        '        Else
        '            Session("UserEmail") = oReader.Item("email")
        '        End If
        '        Session("MSGPERPAGE") = oReader.Item("msgperpage")
        '        Session("CustomerName") = oReader.Item("name")

        '        ' Save minimal state info and redirect to the page.
        '        Response.Cookies.Add(New HttpCookie("CustomerName", oReader.Item("name")))
        '        Response.Cookies.Add(New HttpCookie("DatabaseName", _strDatabaseName))
        '        Response.Cookies.Add(New HttpCookie("DataSource", _strDataSource))

        '        ' Check the customer services and activate them

        '        'DoServices(CustomerID)
        '        Dim cServices As ArrayList = AccountsCentre.BLL.ServicesManager.GetServicesAllowed(CustomerID)
        '        Session("Services") = cServices
        '        FormsAuthentication.SetAuthCookie(CustomerID.ToString, False)
        '        'Response.Write("Url=" & FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))
        '        'Response.End()

        '        If Left(Trim(UCase(FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False))), 9) = "/DEFAULT." Then
        '            'FormsAuthentication.RedirectFromLoginPage(CustomerID.ToString, False)
        '            Response.Redirect("https://www.accountscentre.com/members/default.aspx")

        '        Else

        '            ' Get the redirect url
        '            Dim RedirectURL As String = FormsAuthentication.GetRedirectUrl(CustomerID.ToString, False)

        '            ' Here we'll explicitly redirect the url to secure mode. For development purpose
        '            ' we've mark comment on it. But make sure that before deployment this line is un-comment.
        '            '--------------------------------------------------------------------------------------------------------
        '            Response.Redirect("https://www.AccountsCentre.com" & RedirectURL)
        '            '--------------------------------------------------------------------------------------------------------

        '            ' For development purpose we'll redirect to the respective url
        '            'Response.Redirect(RedirectURL)

        '        End If

        '    Else

        '        ErrorMessage = SignInAttemptFailed

        '    End If
        '    End If

    End Function

    Private Function DoServices(ByVal intcustomerID As Int32)
        Dim SM As ServicesManager
        'Dim ServicesAllowed As ArrayList

        If (_strDatabaseName = String.Empty) Then
            SM = New ServicesManager(intcustomerID)
        Else
            SM = New ServicesManager(intcustomerID, _strDatabaseName)
        End If
        'Response.Write("Before Call   " & intcustomerID)
        SM.ProcessServices()
        'Response.Write("After Call ")
        'Response.End()
    End Function

    Private Sub btnForgotPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForgotPassword.Click
        Response.Redirect("/account/forgotpassword.aspx")
    End Sub

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        Response.Redirect("/account/newcustomer.aspx")
    End Sub

    '*****************************************
    '' SetFocus Function (MNS)
    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub btnSignin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignin.Click
        SignIn()
    End Sub
End Class
