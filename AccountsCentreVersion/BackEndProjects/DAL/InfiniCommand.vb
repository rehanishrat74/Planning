Option Strict On

Public Class InfiniCommand

    Private _commandName As String
    Private _parametersCollection As ArrayList

#Region "Constructors "

    Public Sub New(ByVal commandName As String)
        _commandName = commandName
        _parametersCollection = New ArrayList(0)
    End Sub

#End Region

#Region "Overloaded Add Methods"

    Public Function AddParameter(ByVal paramName As String, ByVal paramValue As Object) As Boolean
        Dim newParameter As New InfiniParameter(paramName, paramValue)
        _parametersCollection.Add(newParameter)
    End Function

    Public Function AddParameter(ByVal paramName As String, ByVal paramValue As Object, ByVal paramType As DbType) As Boolean
        Dim newParameter As New InfiniParameter(paramName, paramValue, paramType)
        _parametersCollection.Add(newParameter)
    End Function

    Public Sub ClearParameters()
        _parametersCollection.Clear()
    End Sub

    'Public Function AddParameter(ByVal paramName As String, ByVal paramValue As Byte(), ByVal paramType As DbType) As Boolean
    '    Dim newParameter As New InfiniParameters(paramName, paramValue, paramType)
    '    _parametersCollection.Add(newParameter)
    'End Function

#End Region

#Region "Properties "

    Public ReadOnly Property CommandName() As String
        Get
            Return _commandName
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return (_parametersCollection.Count - 1)
        End Get
    End Property

    Public ReadOnly Property Parameters() As ArrayList
        Get
            Return _parametersCollection
        End Get
    End Property

    'Public ReadOnly Property Parameter(ByVal index As Integer) As String
    '    Get
    '        If index > -1 And index < _parametersCollection.Count Then
    '            Dim ip As InfiniParameters = CType(_parametersCollection(index), InfiniParameters)
    '            Return CStr(ip.Value)
    '        End If
    '    End Get
    'End Property

    Public ReadOnly Property Parameter(ByVal index As Integer) As Object
        Get
            If index > -1 And index < _parametersCollection.Count Then
                Dim ip As InfiniParameter = CType(_parametersCollection(index), InfiniParameter)
                Return ip.Value
            End If
        End Get
    End Property



#End Region

End Class