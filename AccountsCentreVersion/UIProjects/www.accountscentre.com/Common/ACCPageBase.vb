Imports System.Web.Security
Imports System.Web.Mail
Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports System.Data.SqlClient


Public Class ACCPageBase
    Inherits PageBase

    Private Sub Page_Error(ByVal Sender As Object, ByVal E As EventArgs) Handles MyBase.Error
        Try
            Dim Ex As Exception
            Dim body As String

            Ex = Server.GetLastError
            Server.ClearError()
            body = "Exception   : " & Ex.InnerException.ToString & "<br>" & _
                    "Source     : " & Ex.Source.ToString & "<br>" & _
                    "Messege    : " & Ex.Message.ToString & "<br>" & _
                    "Stack Trace: " & Ex.StackTrace.ToString & "<br>"

            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "errors@accountscentre.com", CustomerID & " - " & Now & " - Payroll Error", body, MailFormat.Html)

        Catch ex As Exception

        Finally
            Response.Redirect("/Common/ErrorPage.aspx")
        End Try

        Dim ds As New DataSet

    End Sub
End Class
