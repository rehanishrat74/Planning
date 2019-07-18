Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://accounts.infinibiz.com/accounts.infinibiz.Web/DomainService")> _
Public Class DomainService
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

    '<WebMethod(EnableSession:=True, CacheDuration:=120)> _
    ' Public Function IsDomainNameAvailable(ByVal ControlID As String, ByVal DomainName As String, ByVal ToolTipLen As Integer) As String
    '    HttpContext.Current.Trace.Write("ControlID=" & ControlID)
    '    HttpContext.Current.Trace.Write("DomainName=" & DomainName)
    '    HttpContext.Current.Trace.Write("ToolTipLen=" & ToolTipLen)
    '    HttpContext.Current.Trace.Write("IsAuthenticated=" & System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
    '    If System.Web.HttpContext.Current.User.Identity.IsAuthenticated Then
    '        HttpContext.Current.Trace.Write("Identity.Name=" & System.Web.HttpContext.Current.User.Identity.Name)
    '        Dim Result As String
    '        Dim bResult As String
    '        If UD_Service.IsDomainAvailable(DomainName) Then
    '            Result = "Domain is available"
    '            bResult = "1"
    '        Else
    '            Result = "Domain is not available"
    '            bResult = "0"
    '        End If
    '        Return ControlID & ">" & ToolTipLen & ">" & bResult & ">" & Result
    '    End If
    '    Return ""
    'End Function

End Class
