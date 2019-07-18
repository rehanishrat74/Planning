Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://accounts.infinibiz.Web/CommonServices")> _
Public Class CommonServices
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
    ' Public Function IsDomainNameAvailable(ByVal ControlID As String, ByVal DomainName As String, ByVal ToolTipLen As Integer) As IsDomainNameAvailableResult
    '    HttpContext.Current.Trace.Write("ControlID=" & ControlID)
    '    HttpContext.Current.Trace.Write("DomainName=" & DomainName)
    '    HttpContext.Current.Trace.Write("ToolTipLen=" & ToolTipLen)
    '    HttpContext.Current.Trace.Write("IsAuthenticated=" & System.Web.HttpContext.Current.User.Identity.IsAuthenticated)

    '    Dim Result As New IsDomainNameAvailableResult
    '    Try
    '        Result.MethodName = "IsDomainNameAvailable"
    '        If System.Web.HttpContext.Current.User.Identity.IsAuthenticated Then
    '            HttpContext.Current.Trace.Write("Identity.Name=" & System.Web.HttpContext.Current.User.Identity.Name)
    '            Dim Msg As String
    '            Dim bResult As String
    '            If UD_Service.IsDomainAvailable(DomainName) Then
    '                Msg = "Domain is available"
    '                bResult = "1"
    '            Else
    '                Msg = "Domain is not available"
    '                bResult = "0"
    '            End If
    '            Result.Response = ControlID & ">" & ToolTipLen & ">" & bResult & ">" & Msg
    '        End If
    '    Catch ex As Exception
    '        HttpContext.Current.Trace.Warn("Exception")
    '        HttpContext.Current.Trace.Warn("Message=" & ex.Message)
    '        HttpContext.Current.Trace.Warn("StackTrace=" & ex.StackTrace)
    '        Result.Response = ""
    '    End Try
    '    Return Result
    'End Function

    <WebMethod(EnableSession:=True, CacheDuration:=120)> _
    Public Function IsCompanyNameAvailable(ByVal ControlID As String, ByVal CompanyName As String, ByVal ToolTipLen As Integer) As IsCompanyNameAvailableResult
        HttpContext.Current.Trace.Write("ControlID=" & ControlID)
        HttpContext.Current.Trace.Write("CompanyName=" & CompanyName)
        HttpContext.Current.Trace.Write("ToolTipLen=" & ToolTipLen)
        HttpContext.Current.Trace.Write("IsAuthenticated=" & System.Web.HttpContext.Current.User.Identity.IsAuthenticated)

        Dim Result As New IsCompanyNameAvailableResult
        Try
            Result.MethodName = "IsCompanyNameAvailable"
            If System.Web.HttpContext.Current.User.Identity.IsAuthenticated Then
                HttpContext.Current.Trace.Write("Identity.Name=" & System.Web.HttpContext.Current.User.Identity.Name)

                Dim bResult As String
                Dim Msg As String

                Dim ParentCustomerID As String = Session("ACC_GV_ParentCustomerID")
                HttpContext.Current.Trace.Write("ParentCustomerID = " & ParentCustomerID)

                Dim objIsCompanyNameAvailable As InfiniLogic.AccountsCentre.BLL.InfiniOfficeService.IsCompanyNameAvailableResult
                objIsCompanyNameAvailable = InfiniLogic.AccountsCentre.BLL.InfiniOfficeService.IsCompanyNameAvailableForRegistration(ParentCustomerID, CompanyName)
                HttpContext.Current.Trace.Write("IsAvailable = " & objIsCompanyNameAvailable.IsAvailable)
                If objIsCompanyNameAvailable.IsAvailable Then
                    Msg = "Compnay name is available"
                    bResult = "1"
                Else
                    Msg = "Company name is not available"
                    bResult = "0"
                End If
                Result.Response = ControlID & ">" & ToolTipLen & ">" & bResult & ">" & Msg
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception")
            HttpContext.Current.Trace.Warn("Message=" & ex.Message)
            HttpContext.Current.Trace.Warn("StackTrace=" & ex.StackTrace)
            Result.Response = ""
        End Try
        Return Result
    End Function

    Public Structure IsCompanyNameAvailableResult
        Public MethodName As String
        Public Response As String
    End Structure

    Public Structure IsDomainNameAvailableResult
        Public MethodName As String
        Public Response As String
    End Structure

End Class
