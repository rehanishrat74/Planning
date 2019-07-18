#Region " Libraries "
Imports Microsoft.VisualBasic
Imports System.Web.Services
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Collections.Specialized

#End Region

<System.Web.Services.WebService(Namespace:="http://accounts.infinibiz.com/InfiniLogic.AccountsCentre.Web/Login")> _
Public Class Login
    Inherits System.Web.Services.WebService

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


    <WebMethod(enableSession:=True)> _
    Public Function AutoLogin(ByVal logininfo As AutoLoginStruct) As AutoLoginResult

        Dim autologinReturnMsg As AutoLoginResult
        Dim SessionID As String = logininfo.serviceid

        If logininfo.customerid = "" OrElse logininfo.password = "" Then
            autologinReturnMsg.ERRORCODE = "1"
            autologinReturnMsg.ERRORDESC = "Parameter loginid is empty"
            Return autologinReturnMsg
        End If

        Try
            Dim objSecureQueryString As New SecureQueryString
            logininfo.loginid = ServicesManager.GetCustomerLoginID(logininfo.customerid)

            With objSecureQueryString
                .Add("UserID", logininfo.loginid)
                .Add("Password", logininfo.password)
                .Add(PageTemplate.ACC_SessionID, SessionID)
                .ExpireTime = Now.AddSeconds(120)
                With autologinReturnMsg
                    .ERRORCODE = Errorcode.Successful
                    .ERRORDESC = "Operation Successful"
                    .value = SessionID
                    .newwin = "0"
                    .variablename = "sid"  'this variable is not used by www.accoutscentre.com so "n" is a dummy value 
                    .winparam = ""
                    '.link = CommonBase.Resources(ACC_Resource.ACC_AUTOLOGIN) + "?q=" + objSecureQueryString.ToString()
                    .link = "http://localhost/account/dologin.aspx?q=" + objSecureQueryString.ToString()
                End With
                SignIn(SessionID, logininfo.loginid)
                'AccountsCentre.Web.AutoLogin.WriteDebugInfo("Login.asmx->TimeStamp:" & Now)
                'AccountsCentre.Web.AutoLogin.WriteDebugInfo("UserID:" & logininfo.loginid)
                'AccountsCentre.Web.AutoLogin.WriteDebugInfo("Password:" & logininfo.password)
                'AccountsCentre.Web.AutoLogin.WriteDebugInfo("WebService Result:" & autologinReturnMsg.link)
            End With
        Catch e As Exception

            With autologinReturnMsg
                .ERRORCODE = Errorcode.UnknownError
                .ERRORDESC = e.Message
            End With
        End Try

        Return autologinReturnMsg
    End Function

    '<WebMethod()> _
    Public Sub SignIn(ByVal SessionID As String, ByVal CustomerID As Integer)

        Dim colSignedInUsers As Hashtable
        If AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN) Is Nothing Then
            colSignedInUsers = New Hashtable

        Else
            colSignedInUsers = AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN)

        End If

        If Not colSignedInUsers.ContainsKey(SessionID) Then colSignedInUsers.Add(SessionID, CustomerID)

        AppDomain.CurrentDomain.SetData(PageTemplate.ACC_USERS_SIGN_IN, colSignedInUsers)
        'Application(PageTemplate.ACC_USERS_SIGN_IN) = colSignedInUsers

    End Sub

    <WebMethod()> _
    Public Function LogOff(ByVal logoffinfo As AutoLogOffStruct) As logoffReturnMsg

        If Not AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN) Is Nothing Then

            Dim SessionID As String = logoffinfo.sid

            Dim colSignedInUsers As Hashtable

            colSignedInUsers = AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN)

            colSignedInUsers.Remove(SessionID)

            AppDomain.CurrentDomain.SetData(PageTemplate.ACC_USERS_SIGN_IN, colSignedInUsers)

        End If

        Dim logoffReturnMsg As New logoffReturnMsg

        logoffReturnMsg.ERRORCODE = Errorcode.Successful
        logoffReturnMsg.ERRORDESC = "Operation Successful"

        Return logoffReturnMsg

    End Function
End Class

'Public Structure AutoLoginStruct

'    Public customerid As String
'    Public password As String
'    Public serviceid As String
'    Public language As String
'    ' Public code1 As String
'    ' Public code2 As String
'    'Public reSellerId As String
'    Public loginid As String
'End Structure

'Public Structure AutoLoginResult
'    Public ERRORCODE As String
'    Public ERRORDESC As String
'    Public newwin As String
'    Public winparam As String
'    Public variablename As String
'    Public value As String
'    Public link As String
'    'Public sessionvar As String -> variablename
'    'Public sessionid As String -> value
'    'Public url As String -> link

'End Structure

'Public Structure AutoLogOffStruct
'    Public sid As String
'    Public refId As String

'End Structure

'Public Structure logoffReturnMsg

'    Public ERRORCODE As String
'    Public ERRORDESC As String

'End Structure

'Public Enum Errorcode
'    Successful = 0
'    InvalidInfo = -1
'    Session_Destruction_Failed = -2
'    UnknownError = -11
'End Enum