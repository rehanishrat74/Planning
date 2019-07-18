#Region " Libraries "
Imports Microsoft.VisualBasic
Imports System.Web.Services
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Collections.Specialized

#End Region

<System.Web.Services.WebService(Namespace:="http://www.accountscentre.com/InfiniLogic.AccountsCentre.Web/Login")> _
Public Class Login
    Inherits System.Web.Services.WebService

    Protected ACC_USERS_SIGN_IN As String = "ACC_SignedIn_Users"

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function
    'Public Function DoLogin(ByVal strUserID As String, ByVal strPassword As String) As String()

    '<WebMethod()> _
    'Public Function AutoLogin(ByVal loginid As String, ByVal customerid As String, ByVal password As String, ByVal serviceid As String, ByVal language As String, ByVal code1 As String, ByVal code2 As String) As String()
    <WebMethod()> _
    Public Function AutoLogin(ByVal logininfo As AutoLoginStruct) As AutoLoginResult
        'Dim strResult() As String = New String(6) {}
        Dim autologinReturnMsg As AutoLoginResult

        'If AutoLogin.ValidateIP(Context.Request) = False Then
        '    strResult(0) = "-1"   'Any non zero value is considered an error!
        '    strResult(1) = ""
        'End If

        If logininfo.loginid = "" And logininfo.password = "" Then
            autologinReturnMsg.errorcode = "1"
            autologinReturnMsg.errordesc = "Parameters loginid and password are empty"
            autologinReturnMsg.sessionvar = ""
            autologinReturnMsg.sessionid = ""
            autologinReturnMsg.url = ""
            autologinReturnMsg.newwin = ""
            autologinReturnMsg.winparam = ""
            Return autologinReturnMsg
        ElseIf logininfo.loginid = "" OrElse logininfo.password = "" Then
            autologinReturnMsg.errorcode = "1"
            autologinReturnMsg.errordesc = "Parameter loginid is empty"
            autologinReturnMsg.sessionvar = ""
            autologinReturnMsg.sessionid = ""
            autologinReturnMsg.url = ""
            autologinReturnMsg.newwin = ""
            autologinReturnMsg.winparam = ""
            Return autologinReturnMsg

        End If


        Try
            Dim objSecureQueryString As New SecureQueryString

            With objSecureQueryString

                '.Add("UserID", strUserID)
                '.Add("Password", strPassword)
                .Add("UserID", logininfo.loginid)
                .Add("Password", logininfo.password)
                .ExpireTime = DateTime.MaxValue 'Now.AddMinutes(15.0)

                With autologinReturnMsg

                    .errorcode = "0"
                    .errordesc = ""
                    .sessionvar = ""
                    .sessionid = ""
                    .url = CommonBase.Resources(ACC_Resource.ACC_AUTOLOGIN) + "?q=" + .ToString()
                    .newwin = ""
                    .winparam = ""

                End With

                AccountsCentre.Web.AutoLogin.WriteDebugInfo("Login.asmx->TimeStamp:" & Now)
                AccountsCentre.Web.AutoLogin.WriteDebugInfo("UserID:" & logininfo.loginid)
                AccountsCentre.Web.AutoLogin.WriteDebugInfo("Password:" & logininfo.password)
                AccountsCentre.Web.AutoLogin.WriteDebugInfo("WebService Result:" & autologinReturnMsg.url)
            End With
        Catch e As Exception

            With autologinReturnMsg
                .errorcode = "1"
                .errordesc = e.Message
                .sessionvar = ""
                .sessionid = ""
                .url = ""
                .newwin = ""
                .winparam = ""
            End With
        End Try

        Return autologinReturnMsg
    End Function

    <WebMethod()> _
    Public Sub SignIn(ByVal CustomerID As Integer)

        Dim colSignedInUsers As NameValueCollection

        If Application(ACC_USERS_SIGN_IN) Is Nothing Then
            colSignedInUsers = New NameValueCollection

        Else
            colSignedInUsers = Application(ACC_USERS_SIGN_IN)
        End If
        If colSignedInUsers.Item(CustomerID.ToString) Is Nothing Then colSignedInUsers.Add(CustomerID, CustomerID)

        Application(ACC_USERS_SIGN_IN) = colSignedInUsers

    End Sub

    <WebMethod()> _
    Public Sub SignOut(ByVal customerid As Integer)

        If Application(ACC_USERS_SIGN_IN) Is Nothing Then Exit Sub

        Dim colSignedInUsers As NameValueCollection

        colSignedInUsers = Application(ACC_USERS_SIGN_IN)

        colSignedInUsers.Remove(customerid.ToString)

        Application(ACC_USERS_SIGN_IN) = colSignedInUsers

    End Sub
End Class

Public Structure AutoLoginStruct
    Public loginid As String
    Public customerid As String
    Public password As String
    Public serviceid As String
    Public language As String
    Public code1 As String
    Public code2 As String
End Structure

Public Structure AutoLoginResult
    Public errorcode As String
    Public errordesc As String
    Public sessionvar As String
    Public sessionid As String
    Public url As String
    Public newwin As String
    Public winparam As String
End Structure