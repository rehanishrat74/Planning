Imports System.Web.Services
Imports InfiniLogic.AccountsCentre.common

<System.Web.Services.WebService(Namespace:="http://tempuri.org/AtheneSystem/Athene")> _
Public Class Athene

    Inherits System.Web.Services.WebService
    Dim objMethodCalls As New MethodCalls

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

    <WebMethod(EnableSession:=True)> _
    Public Function AthenaInsertQuestionAnswer(ByVal QuestionId As Integer, ByVal Question As String, ByVal Answer As String, ByVal CategoryId As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As ResultMessage

        Dim Result As New ResultMessage
        Try
            Dim response As String
            response = objMethodCalls.InsertProductQuestionAnswer(QuestionId, Question, Answer, CategoryId, Customerid, EmployeeId)
            Result.Message = "Insert Product and Question Sucessfull"
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = ExceptionFormatter2.Formatter.HandleException(ex, "pro.errors@accountscentre.com", "support@infinibiz.com", "AccountsPro")
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "pro.errors@accountscentre.com", "Athena system Errors", body, Mail.MailFormat.Html)
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
            Result.Message = "Insert Product and Question Failed" + " " + ex.Message
        End Try
        Return Result

    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function AthenaUpdateQuestionAnswer(ByVal QuestionId As Integer, ByVal Question As String, ByVal Answer As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As ResultMessage

        Dim Result As New ResultMessage
        Try
            Dim response As String
            response = objMethodCalls.UpdateQuestionAnswer(QuestionId, Question, Answer, Customerid, EmployeeId)
            Result.Message = "Update Question Sucessfull"
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = ExceptionFormatter2.Formatter.HandleException(ex, "pro.errors@accountscentre.com", "support@infinibiz.com", "AccountsPro")
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "pro.errors@accountscentre.com", "Athena system Errors", body, Mail.MailFormat.Html)
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
            Result.Message = "Update Question Failed" + " " + ex.Message
        End Try
        Return Result

    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function AthenaInsertCategory(ByVal CategoryId As Integer, ByVal CategoryName As String, ByVal ParentId As Integer, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As ResultMessage

        Dim Result As New ResultMessage
        Try
            Dim response As String
            response = objMethodCalls.InsertCategory(CategoryId, CategoryName, ParentId, Customerid, EmployeeId)
            Result.Message = "Insert Category Sucessfull"
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = ExceptionFormatter2.Formatter.HandleException(ex, "pro.errors@accountscentre.com", "support@infinibiz.com", "AccountsPro")
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "pro.errors@accountscentre.com", "Athena system Errors", body, Mail.MailFormat.Html)
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
            Result.Message = "Insert Category Failed" + " " + ex.Message

        End Try
        Return Result

    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function AthenaUpdateCategory(ByVal CategoryId As String, ByVal CategoryName As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As ResultMessage

        Dim Result As New ResultMessage
        Try
            Dim response As String
            response = objMethodCalls.UpdateCategory(CategoryId, CategoryName, Customerid, EmployeeId)
            Result.Message = "Update Category Sucessfull"
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = ExceptionFormatter2.Formatter.HandleException(ex, "pro.errors@accountscentre.com", "support@infinibiz.com", "AccountsPro")
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "pro.errors@accountscentre.com", "Athena system Errors", body, Mail.MailFormat.Html)
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
            Result.Message = "Update Category Failed" + " " + ex.Message

        End Try
        Return Result

    End Function

    Public Structure ResultMessage
        Public Message As String
    End Structure

End Class
