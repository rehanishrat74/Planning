Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Data

''' -----------------------------------------------------------------------------
''' Project	 : AccountsCentre.BLL
''' Class	 : AccountsCentre.BLL.CustomerDocuments
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.abid]	06/01/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CustomerDocuments

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ID"></param>
    ''' <param name="CustomerID"></param>
    ''' <param name="ServiceID"></param>
    ''' <param name="FileYear"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	06/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetAccCustomerFile(Optional ByVal ID As Integer = -1, Optional ByVal CustomerID As Integer = -1, Optional ByVal ServiceID As Integer = -1, Optional ByVal FileYear As String = "") As DataTable
        '---------------------------------
        Dim objCmd As New CommandData
        Dim ds As DataSet
        '---------------------------------
        Try
            With objCmd

                '----------------------------------------------------------------
                .CmdText = "DbServer.InfinishopMainDb.dbo.ACC_GetFiledDocuments"
                '----------------------------------------------------------------

                If ID <> -1 Then
                    '-----------------------
                    .AddParameter("@ID", ID)
                    '-----------------------
                Else
                    If CustomerID <> -1 Then
                        '---------------------------------------
                        .AddParameter("@CustomerID", CustomerID)
                        '---------------------------------------
                    End If

                    If ServiceID <> -1 Then
                        '---------------------------------------
                        .AddParameter("@ServiceID", ServiceID)
                        '---------------------------------------
                    End If

                    If FileYear <> "" Then
                        '---------------------------------------
                        .AddParameter("@FileYear", FileYear)
                        '---------------------------------------
                    End If

                End If

                ds = .Execute(ExecutionType.ExecuteDataSet)

            End With


        Catch ex As Exception
            objCmd.CloseConnection()
            Return Nothing
        End Try

        '--------------
        Return ds.Tables(0)
        '--------------
    End Function

End Class
