Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.Common

Imports System.Data.SqlClient

Public Class EmailManager

    Public Shared Function CreatDBLog(ByVal strCustomer_id As String, ByVal strTemplateCode As String, ByVal strMessage As String, ByVal strCustName As String, ByVal strCustEmail As String, ByVal strSubject As String, ByVal strSenderEmail As String, ByVal blnSuccess As Boolean, Optional ByVal txtException As String = "") As String

        Dim cmdData As New CommandData

        With cmdData

            Try
                .AddParameter("@Customer_id", strCustomer_id)
                .AddParameter("@TemplateCode", strTemplateCode)
                .AddParameter("@dated", Now.Date)
                .AddParameter("@Message", strMessage)
                .AddParameter("@Customer_Name", strCustName)
                .AddParameter("@Customer_Email", strCustEmail)
                .AddParameter("@Email_Subject", strSubject)
                .AddParameter("@Sender_Email", strSenderEmail)
                .AddParameter("@Successful", blnSuccess)
                .AddParameter("@Exception", txtException)

                .CmdText = "dbserver.InfinishopMainDB.dbo.ADMIN_InsertEmailLog"
                .Execute(ExecutionType.ExecuteNonQuery)
                CreatDBLog = "Success"

            Catch ex As Exception
                CreatDBLog = ex.Message
            Finally

                .CloseConnection()

            End Try

        End With

    End Function

End Class
