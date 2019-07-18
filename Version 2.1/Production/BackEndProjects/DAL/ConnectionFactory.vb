Option Explicit On 
Option Strict On

#Region " Import Libraries "
Imports System
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports System.Text
#End Region

Public Class ConnectionFactory

    Public Shared Function GetConnection(ByRef cnData As ConnectionData) As IDbConnection
        Dim cn As IDbConnection
        Dim cnStr As String = Connection.GetConnectionString(cnData)

        Select Case cnData.ClientType
            Case ProviderType.AccessClient
                ' Return OleDbConnection to connect to Access
                cn = New OleDbConnection(cnStr)
            Case ProviderType.OracleClient
                ' Return OleDbConnection to connect to Oracle
                'cn = New OleDbConnection(cnStr)
            Case ProviderType.PostGresClient
                ' Return OleDbConnection to connect to PostGres
                ' cn = New OleDbConnection(cnStr)
            Case ProviderType.SQLClient
                ' Return SQLConnection to connect to Access
                cn = New SqlConnection(cnStr)
        End Select

        Return cn
    End Function

End Class
