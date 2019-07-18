Option Strict On
Option Explicit On 

Public Class ConnectionData


    Private _ServiceName As String
    Private _DataSource As String
    Private _DatabaseName As String
    Private _SQLUserID As String
    Private _SQLPassword As String

    '    Private _CustomerID As Int32

#Region "Constructors "

    Public Sub New()
        _ServiceName = ""
        _DataSource = ""
        _DatabaseName = ""
    End Sub


#End Region


#Region "Properties "

    Public Property ServiceName() As String
        Get
            Return _ServiceName
        End Get
        Set(ByVal Value As String)
            _ServiceName = Value
        End Set
    End Property

    Public Property DataSource() As String
        Get
            Return _DataSource
        End Get
        Set(ByVal Value As String)
            _DataSource = Value
        End Set
    End Property

    Public Property DatabaseName() As String
        Get
            Return _DatabaseName
        End Get
        Set(ByVal Value As String)
            _DatabaseName = Value
        End Set
    End Property

    Public Property SQLUserID() As String
        Get
            Return _SQLUserID
        End Get
        Set(ByVal Value As String)
            _SQLUserID = Value
        End Set
    End Property

    Public Property SQLPassword() As String
        Get
            Return _SQLPassword
        End Get
        Set(ByVal Value As String)
            _SQLPassword = Value
        End Set
    End Property


#End Region



End Class