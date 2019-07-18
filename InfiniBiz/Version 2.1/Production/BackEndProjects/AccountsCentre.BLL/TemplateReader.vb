#Region "Imports"
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
#End Region
Public Class TemplateReader

    Public Function SelectEmailContent(ByVal TemplateCode As String) As DataSet

        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParam(0) = New SqlClient.SqlParameter("@TemplateCode", SqlDbType.VarChar, 4)
        sqlParam(0).Value = TemplateCode

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "dbserver.InfinishopMainDB.dbo.ADMIN_SelectEmailContent", sqlParam)
       
    End Function

    Public Function SelectEmailContent(ByVal TemplateCode As String, ByVal culture As String) As DataSet
        Dim ds As New DataSet
        Try
            With New CommandData
                .AddParameter("@TemplateCode", TemplateCode)
                .AddParameter("@Culture", culture)
                .CmdText = "DBServer.InfinishopMainDB.dbo.ADMIN_SelectEmailContentCulture"
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
        Catch ex As Exception
        End Try
        Return ds
    End Function

End Class
