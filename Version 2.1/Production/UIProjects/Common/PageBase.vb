Imports System
Imports System.Web
Imports System.Text
Imports System.Globalization
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.UserControl
Imports System.Web.HttpContext
Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.common


'----------------------------------------------------------------
' Namespace: InfiniPayroll.Web
' Class: PageBase
'
' Description: 
'   The code-behind base class for all aspx pages.
'   Provides html span controls (ErrorSpan, InfoSpan) and properties(EmployerID, ErrorMessage, InfoMessage ).
'----------------------------------------------------------------

Public Class _PageBase
    Inherits System.Web.UI.Page

    'Html span for displaying error messages

    Protected ErrorSpan As HtmlGenericControl

    'Html span for displaying information messages

    Protected InfoSpan As HtmlGenericControl

    'Cause specified text to be displayed as an error message on the page

    Protected _blnIsCustomer As Boolean

    Protected Property ErrorMessage() As String
        Get
            ErrorMessage = ErrorSpan.InnerHtml
        End Get
        Set(ByVal Value As String)
            Dim _stringBuilder As New StringBuilder(Value)
            _stringBuilder.Replace("\r\n", "<br>")
            ErrorSpan.InnerHtml = _stringBuilder.ToString
        End Set
    End Property

    'Cause specified text to be displayed as informative message on the page

    Protected Property InfoMessage() As String
        Get
            InfoMessage = InfoSpan.InnerHtml
        End Get
        Set(ByVal Value As String)
            InfoSpan.InnerHtml = Value
        End Set
    End Property

    'Provide Employer ID persistence during session
    Protected ReadOnly Property CustomerID() As Int32
        Get
            Return Int32.Parse(User.Identity.Name)  ' Int32.Parse(User.Identity.Name)
            ' Return 11 'Convert.ToInt32(User.Identity.Name)
        End Get

    End Property

    ' Provide true/false value whether employer has registered itself or not.
    Protected Property IsCustomer() As Boolean
        Get
            Return _blnIsCustomer
        End Get
        Set(ByVal Value As Boolean)
            _blnIsCustomer = Value
        End Set
    End Property

    '----------------------------------------------------------------
    ' Sub ShowPanel:
    '   Helper sub used to make certain that the validators do not 
    '    fire when their parent panel is not visible.
    '----------------------------------------------------------------

    Protected Sub ShowPanel(ByRef panel As Panel, ByVal visible As Boolean)
        Dim validator As IValidator
        Dim ctrl As Control

        For Each ctrl In panel.Controls
            'check to see if its a validator
            If TypeOf ctrl Is IValidator Then
                validator = CType(ctrl, IValidator)
                ctrl.Visible = visible
                If Not visible Then
                    validator.Validate()
                End If
            End If
        Next
        panel.Visible = visible
    End Sub

    Sub Page_Error(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Error

        Try
            Dim Ex As Exception
            Dim body As String

            Ex = Server.GetLastError
            Server.ClearError()
            body = "Source     : " & Ex.Source.ToString & "<br>" & _
                    "Messege    : " & Ex.Message.ToString & "<br>" & _
                    "Stack Trace: " & Ex.StackTrace.ToString & "<br>"

            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "errors@accountscentre.com", "Accountscentre Administration", body, Mail.MailFormat.Html)

        Catch ex As Exception

        Finally
            Response.Redirect("/Common/ErrorPage.aspx")
        End Try

    End Sub


End Class