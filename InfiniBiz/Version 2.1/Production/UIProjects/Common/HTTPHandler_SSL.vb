Imports System.Web

Public Class HTTPHandler_SSL
    Implements IHttpModule

    Dim objHttpApplication As HttpApplication
    Dim URL As String

    Public Sub Init(ByVal context As System.Web.HttpApplication) Implements System.Web.IHttpModule.Init
        AddHandler context.BeginRequest, AddressOf Me.OnBeginRequest
    End Sub

    Public Sub Dispose() Implements System.Web.IHttpModule.Dispose

    End Sub

    Public Sub OnBeginRequest(ByVal s As Object, ByVal e As EventArgs)

        objHttpApplication = CType(s, HttpApplication)

        With objHttpApplication.Request
            URL = .ServerVariables("URL").ToLower

            If .ServerVariables("SERVER_PORT") = 80 AndAlso (isSSLPage() OrElse isSSLFolder()) Then

                Dim strSecureURL As New System.Text.StringBuilder(80)

                strSecureURL.Append("https://")
                strSecureURL.Append(.ServerVariables("SERVER_NAME"))
                strSecureURL.Append(URL)
                Dim strQueryString As String = .ServerVariables("QUERY_STRING")
                If strQueryString <> "" Then
                    strSecureURL.Append("?")
                    strSecureURL.Append(strQueryString)
                End If
                objHttpApplication.Response.Redirect(strSecureURL.ToString)
            End If

        End With

    End Sub

    Public Function isSSLPage() As Boolean

        With objHttpApplication.Request
            Return (ConfigurationSettings.AppSettings("ssl_pages").IndexOf(URL) <> -1)
        End With
    End Function

    Public Function isSSLFolder() As Boolean
        Dim strSSLFolder As String

        Dim strSSL_folders As String = ConfigurationSettings.AppSettings("ssl_folders")

        If strSSL_folders <> "" Then
            Dim strSSLFolders As String() = strSSL_folders.ToLower.Split(",")


            For Each strSSLFolder In strSSLFolders
                If URL.IndexOf(strSSLFolder) > -1 Then
                    Return True
                End If
            Next
        End If

        Return False
    End Function

    'Public Sub ApplySSL(ByVal objContext As HttpContext) Implements IHttpHandler.ProcessRequest

    '    With objContext.Request
    '        If .ServerVariables("SERVER_PORT") = 80 Then

    '            URL = .ServerVariables("SERVER_NAME") & .ServerVariables("URL")

    '            Dim strSecureURL As New System.Text.StringBuilder(80)

    '            strSecureURL.Append("https://")
    '            strSecureURL.Append(URL)
    '            Dim strQueryString As String = .ServerVariables("QUERY_STRING")
    '            If strQueryString <> "" Then
    '                strSecureURL.Append("?")
    '                strSecureURL.Append(strQueryString)
    '            End If
    '            objContext.Response.Redirect(strSecureURL.ToString)
    '        Else

    '        End If

    '    End With
    'End Sub

End Class