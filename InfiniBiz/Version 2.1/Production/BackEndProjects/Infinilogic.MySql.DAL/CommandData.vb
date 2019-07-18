Option Strict On
Option Explicit On


#Region "Import Libraries"

Imports System.Data
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
#End Region


Public Class MySql_CommandData


#Region " Protected Variables "

    Protected _blnIsNotTransaction As Boolean = True
    Protected _cmd As MySqlCommand
    Protected _conn As MySqlConnection
    Protected _strConnStr As String
    Protected _cmdText As String
    Protected _cmdType As CommandType = CommandType.Text
    Protected _sqlTransaction As MySqlTransaction
    Protected _blnIsConnectionClosed As Boolean
    Protected _blnIsDistributedTransaction As Boolean
    Protected _intTimeout As Integer = 30
#End Region

#Region " Constructors() "
    Public Sub New(ByVal ConnectionDB As MySql_Connection.ConnectTo)
        _cmd = New MySqlCommand

        _strConnStr = MySql_Connection.GetConnectionString(ConnectionDB) '"Data Source=datacentre;Initial Catalog=InfiniSolve;Persist Security Info=True;User ID=sqluser; Password =D8kjhy"
    End Sub

    'Public Sub New(ByVal CustomerID As Integer)
    '    _cmd = New MySqlCommand

    '    If CustomerID > 0 Then
    '        _strConnStr = Connection.GetConnectionString(CustomerID) '"Data Source=datacentre;Initial Catalog=InfiniSolve;Persist Security Info=True;User ID=sqluser; Password =D8kjhy"
    '    Else
    '        _strConnStr = Connection.GetConnectionString(True) '"Data Source=datacentre;Initial Catalog=InfiniSolve;Persist Security Info=True;User ID=sqluser; Password =D8kjhy"
    '    End If
    'End Sub


#End Region

#Region " Public Function "
    ''' function should be used for Input Parameters only
    Public Sub AddParameter(ByVal name As String, ByVal value As Object, Optional ByVal direction As Data.ParameterDirection = ParameterDirection.Input)
        Dim _sqlParameter As New MySqlParameter(name, value)

        _sqlParameter.Direction = direction

        _cmd.Parameters.Add(_sqlParameter)

    End Sub

    ''' Function should be used for Output and InputOutput Parameters
    Public Sub AddParameter(ByVal name As String, ByVal value As Object, ByVal ParamType As SqlDbType, ByVal size As Integer, Optional ByVal direction As ParameterDirection = ParameterDirection.Input)
        Dim _sqlParameter As New MySqlParameter(name, ParamType)
        With _sqlParameter
            .Size = size
            .Direction = direction
            .Value = value
        End With
        _cmd.Parameters.Add(_sqlParameter)
    End Sub

    ''' Function should be used for Output and InputOutput Parameters
    Public Sub AddParameter(ByVal name As String, ByVal value As Object, ByVal ParamType As SqlDbType, Optional ByVal direction As ParameterDirection = ParameterDirection.Input)
        Dim _sqlParameter As New MySqlParameter(name, ParamType)
        With _sqlParameter
            .Direction = direction
            .Value = value
        End With
        _cmd.Parameters.Add(_sqlParameter)
    End Sub

    Public Sub ClearParameters()
        _cmd.Parameters.Clear()
    End Sub

    Private Sub SetConnection()

        _conn = New MySqlConnection(ConnectionString)
        _conn.Open()
        _cmd.Connection = _conn
        _blnIsConnectionClosed = False

    End Sub

    Protected Sub SetParameters()

        With _cmd
            .CommandText = _cmdText
            .CommandType = _cmdType
        End With
    End Sub

#Region " Execute() "

    Public Function Execute(ByVal Exectype As ExecutionType, Optional ByVal cmdBehavior As CommandBehavior = CommandBehavior.Default) As Object
        With _cmd
            SetParameters()
            If _blnIsNotTransaction OrElse _blnIsConnectionClosed Then SetConnection()

            Select Case Exectype
                Case ExecutionType.ExecuteReader
                    If _blnIsNotTransaction Then
                        Return .ExecuteReader(CommandBehavior.CloseConnection)
                    Else
                        Return .ExecuteReader(cmdBehavior)
                    End If
                Case ExecutionType.ExecuteNonQuery
                    Return .ExecuteNonQuery()
                Case ExecutionType.ExecuteDataSet
                    Try
                        Dim ds As New DataSet
                        Dim da As MySqlDataAdapter
                        da = New MySqlDataAdapter(_cmd)
                        da.Fill(ds)
                        Return ds
                    Catch E As Exception
                        Throw E
                    Finally
                        If _blnIsNotTransaction Then _conn.Dispose()
                    End Try

                Case ExecutionType.ExecuteScalar
                    Return .ExecuteScalar()
            End Select
        End With

    End Function

#End Region

#Region " Transaction Functions "

    'Public Sub BeginTransaction(ByVal strTransactionName As String, Optional ByVal IsDistributedTransaction As Boolean = False, Optional ByVal IsoLevel As IsolationLevel = IsolationLevel.ReadCommitted)
    '    SetConnection()
    '    CheckDisTributedTransaction(IsDistributedTransaction)
    '    _sqlTransaction = _conn.BeginTransaction(strTransactionName)
    '    _cmd.Transaction = _sqlTransaction
    '    _blnIsNotTransaction = False
    'End Sub


    Public Sub BeginTransaction(Optional ByVal IsDistributedTransaction As Boolean = False, Optional ByVal IsoLevel As IsolationLevel = IsolationLevel.ReadCommitted)
        SetConnection()
        CheckDisTributedTransaction(IsDistributedTransaction)
        _sqlTransaction = _conn.BeginTransaction(IsoLevel)
        _cmd.Transaction = _sqlTransaction
        _blnIsNotTransaction = False
    End Sub

    Public Sub Commit()
        ReCheckDistributedTransaction()
        _sqlTransaction.Commit()
        CloseConnection()
        _blnIsNotTransaction = True
    End Sub

    'Public Sub RollBack(Optional ByVal strTransactionName As String = "")
    Public Sub RollBack()
        ReCheckDistributedTransaction()
        'If strTransactionName <> "" Then
        '    _sqlTransaction.Rollback(strTransactionName)
        'Else
        _sqlTransaction.Rollback()
        'End If
        CloseConnection()
        _blnIsNotTransaction = True
    End Sub

    Public Sub CloseConnection(Optional ByVal dispose As Boolean = True)
        If (Not (_conn Is Nothing)) AndAlso _conn.State <> ConnectionState.Closed Then
            _blnIsDistributedTransaction = False
            _conn.Close()
            _blnIsConnectionClosed = True
        End If
        If Not (_conn Is Nothing) Then
            _conn.Dispose()
        End If
    End Sub

    Protected Sub CheckDisTributedTransaction(ByVal IsDistributedTransaction As Boolean)
        If IsDistributedTransaction Then
            _blnIsDistributedTransaction = IsDistributedTransaction
            With _cmd
                .CommandText = "set XACT_ABORT on"
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        End If
    End Sub

    Protected Sub ReCheckDistributedTransaction()
        _blnIsDistributedTransaction = False
    End Sub

#End Region

#End Region

#Region " Public Properties "


    Public ReadOnly Property Item(ByVal name As String) As Object
        Get
            Return _cmd.Parameters.Item(name).Value
        End Get
    End Property

    Public WriteOnly Property CmdText() As String
        Set(ByVal Value As String)
            _cmdText = Value
        End Set
    End Property

    Public WriteOnly Property CmdType() As CommandType

        Set(ByVal Value As CommandType)
            _cmdType = Value
        End Set
    End Property

    Public Property ConnectionString() As String
        Get
            Return _strConnStr
        End Get
        Set(ByVal Value As String)
            _strConnStr = Value
        End Set
    End Property

    Public ReadOnly Property _Connection() As MySqlConnection
        Get
            Return _conn
        End Get

    End Property

    Public Property _Transaction() As MySqlTransaction
        Get
            Return _sqlTransaction
        End Get
        Set(ByVal Value As MySqlTransaction)
            _sqlTransaction = Value
        End Set
    End Property
    Public Property ConnectionTimeOut() As Integer
        Get
            Return _intTimeout
        End Get
        Set(ByVal Value As Integer)
            _intTimeout = Value
        End Set
    End Property

#End Region
End Class


Public Enum ExecutionType
    ExecuteReader
    ExecuteNonQuery
    ExecuteDataSet
    ExecuteScalar
End Enum