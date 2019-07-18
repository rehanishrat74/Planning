Imports System.Data

Public Class InfiniParameter

    Private _parameterName As String
    Private _parameterValue As Object
    'Private _parameterValue2 As Byte()
    Private _parameterType As DbType

#Region "Constructors"

    Public Sub New(ByVal paramName As String, ByVal paramValue As Object)
        _parameterName = paramName
        _parameterValue = paramValue
        _parameterType = DbType.String '(New String("")).GetType
    End Sub

    'Public Sub New(ByVal paramName As String, ByVal paramValue As String, ByVal paramType As Type)
    '    _parameterName = paramName
    '    _parameterValue = paramValue
    '    _parameterType = paramType
    'End Sub

    Public Sub New(ByVal paramName As String, ByVal paramValue As Object, ByVal paramType As DbType)
        _parameterName = paramName
        _parameterValue = paramValue
        _parameterType = paramType
    End Sub

    'Public Sub New(ByVal paramName As String, ByVal paramValue As Byte(), ByVal paramType As DbType)
    '    _parameterName = paramName
    '    _parameterValue2 = paramValue
    '    _parameterType = paramType
    'End Sub


#End Region


#Region "ReadOnly  Properties"

    Public ReadOnly Property Name() As String
        Get
            Return _parameterName
        End Get
    End Property

    Public ReadOnly Property Value() As Object
        Get
            Return _parameterValue
        End Get
    End Property

    'Public ReadOnly Property Value2() As Byte()
    '    Get
    '        Return _parameterValue2
    '    End Get
    'End Property

    Public ReadOnly Property Type() As DbType
        Get
            Return _parameterType
        End Get
    End Property

#End Region

End Class
