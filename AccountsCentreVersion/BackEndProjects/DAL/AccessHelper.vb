Option Strict On
Option Explicit On 

#Region "Import Libraries"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Collections.Specialized
Imports System.Security.Cryptography
#End Region

Public Class AccessHelper

    Inherits DatabaseHelper

    Private _cn As IDbConnection
    Private _cmd As IDbCommand

#Region " Infini Accounts Express overloads Functions"

    Public Overrides Function ExecuteReader(ByVal cnData As ConnectionData, ByRef objCommand As InfiniCommand) As IDataReader

        PrepareCommand(cnData, objCommand)
        Dim dr As IDataReader = _cmd.ExecuteReader()
        Return dr
        _cn.Close()

    End Function

    Public Overrides Function ExecuteDataset(ByVal cnData As ConnectionData, ByRef objCommand As InfiniCommand) As DataSet

        Dim ds As New DataSet
        PrepareCommand(cnData, objCommand)

        'create the DataAdapter & DataSet
        Dim da As OleDbDataAdapter = New OleDbDataAdapter(CType(_cmd, OleDbCommand))

        'fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds)

        'return the dataset
        Return ds
        _cn.Close()

    End Function

    Public Overrides Function ExecuteNonQuery(ByVal cnData As ConnectionData, ByRef objCommand As InfiniCommand) As Integer

        Dim returnValue As Integer
        PrepareCommand(cnData, objCommand)

        _cmd.CommandTimeout = 300
        'finally, execute the command.
        returnValue = _cmd.ExecuteNonQuery()

        Return returnValue
        _cn.Close()

    End Function

    'Public Overrides Function ExecuteScalar(ByVal cnData As ConnectionData, ByRef objCommand As InfiniCommand) As Object

    '    Dim returnValue As Object
    '    PrepareCommand(cnData, objCommand)

    '    'finally, execute the command.
    '    returnValue = _cmd.ExecuteScalar()

    '    Return returnValue

    'End Function

#Region "Private Methods "

    Private Sub PrepareCommand(ByRef cnData As ConnectionData, ByRef objCommand As InfiniCommand)

        Dim _Strsql As String

        _cn = ConnectionFactory.GetConnection(cnData)
        _cmd = New OleDbCommand
        Try
            If (_cn.State = ConnectionState.Closed) Then
                _cn.Open()
            End If
        Catch sqle As OleDbException
            Throw New Exception(" : " & sqle.Message)
        Catch e As Exception
            Throw New Exception(" : " & e.Message)
        End Try

        _Strsql = AccessQueries.GetQueryString(objCommand)

        If objCommand.CommandName = "UPDATECOMPANYLOGO" Then
            LogoUpdate(objCommand)
        Else
            'associate the connection with the command
            _cmd.Connection = _cn
            'set the command text (stored procedure name or SQL statement)
            _cmd.CommandText = _Strsql
        End If

        'Return

    End Sub

    Private Sub LogoUpdate(ByRef objCommand As InfiniCommand)

        'Dim cmd As New OleDbCommand()
        'Dim DR As OleDbDataReader
        Dim param As New OleDbParameter
        With param
            .Value = CObj(objCommand.Parameter(0))
            .DbType = DbType.Binary
        End With
        'Dim conn As New OleDbConnection(ConfigurationSettings.AppSettings("AccessConnStr"))
        'conn.Open()
        objCommand = Nothing
        _cmd.Connection = _cn
        With _cmd
            '.Connection = conn
            .CommandText = "Update TblCompany Set Logo=(?)" '"insert into myfile (file) values(?)"
            .CommandType = CommandType.Text
            .Parameters.Add(param)
            '.ExecuteNonQuery()
        End With
        'With _cmd
        '    .Parameters.Add(param)
        'End With

    End Sub

#End Region

#End Region

End Class
