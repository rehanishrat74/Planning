Imports System.Web
Public Class HttpMod
    Implements IHttpModule

    Dim objHttpApplication As HttpApplication
    'Dim URL, PrvURL As String
    'Public Delegate Sub MyEventHandler(ByVal s As Object, ByVal e As EventArgs)
    'Public Event MyEvent As MyEventHandler

    Public Sub Dispose() Implements System.Web.IHttpModule.Dispose
    End Sub

    Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub
#Region "::::..............Functions And Sub Procedures ..............:::"

    Private Function ValidateRequestIP() As Boolean
        Return False
    End Function

    Public Sub OnBeginRequest(ByVal s As Object, ByVal e As EventArgs)

        If ValidateRequestIP() Then

        Else

        End If



        'objHttpApplication = CType(s, HttpApplication)
        'With objHttpApplication.Request
        '    'URL = .ServerVariables("URL").ToLower
        '    URL = (objHttpApplication.Request.Url.AbsoluteUri).ToLower
        '    If PrvURL = Nothing Then PrvURL = .ServerVariables("URL").ToLower
        '    If URLSOfCalling(URL) = True Then
        '        If URLSOfCaller(PrvURL) = True Then
        '            PrvURL = Nothing
        '        Else
        '            objHttpApplication.Response.Redirect(PrvURL)
        '        End If
        '    End If
        'End With
    End Sub
    'Public Function URLSOfCalling(ByVal CalllingURL As String) As Boolean
    '    Dim AccessedURL() As String = {"https://www.accountsCentre.com/Members.aspx", "https://www.accountsCentre.com/Services.aspx"}
    '    Dim incLoop As Byte
    '    For incLoop = 0 To incLoop = UBound(AccessedURL)
    '        If CalllingURL = AccessedURL(incLoop) Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Next
    'End Function
    'Public Function URLSOfCaller(ByVal CallerURL As String) As Boolean
    '    Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
    '    Dim URLString As String = CType(configurationAppSettings.GetValue("ValidCallerURLs", GetType(System.String)), String)
    '    Dim mysplit() As String
    '    CallerURL = InStr(8, CallerURL, "/")

    '    mysplit = Split(URLString, ",")
    '    Dim incLoop As Byte
    '    For incLoop = 0 To UBound(mysplit) - 1
    '        If CallerURL = mysplit(incLoop) Then Return True
    '    Next
    '    Return False
    'End Function
#End Region

End Class


