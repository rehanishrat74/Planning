Option Strict On
Option Explicit On 

Public Class ConnectionData
    Implements IConnectionData

    Private _serviceName As String
    Private _dataSource As String
    Private _databaseName As String
    Private _customerID As Integer = -1
    Private _sqlUserID As String
    Private _sqlPassword As String
    Private _clientType As ProviderType


#Region "Constructors "


    Public Sub New()
        _serviceName = ""
        _dataSource = ""
        _databaseName = ""
        _clientType = ProviderType.AccessClient
    End Sub

    Public Sub New(ByVal serviceName As String, ByVal dataSourceName As String, _
                    ByVal dbName As String, ByVal clType As ProviderType)
        _serviceName = serviceName
        _dataSource = dataSourceName
        _databaseName = dbName
        _clientType = clType
    End Sub

    Public Sub New(ByVal serviceName As String, ByVal dataSourceName As String, ByVal dbName As String)
        _serviceName = serviceName
        _dataSource = dataSourceName
        _databaseName = dbName
    End Sub


#End Region

#Region "Properties "

    Public Property ServiceName() As String Implements IConnectionData.ServiceName
        Get
            Return _serviceName
        End Get
        Set(ByVal Value As String)
            _serviceName = Value
        End Set
    End Property

    Public Property DataSource() As String Implements IConnectionData.DataSource
        Get
            Return _dataSource
        End Get
        Set(ByVal Value As String)
            _dataSource = Value
        End Set
    End Property

    Public Property DatabaseName() As String Implements IConnectionData.DatabaseName
        Get
            Return _databaseName
        End Get
        Set(ByVal Value As String)
            _databaseName = Value
        End Set
    End Property

    Public Property CustomerID() As Integer Implements IConnectionData.CustomerID
        Get
            Return _customerID
        End Get
        Set(ByVal Value As Integer)
            _customerID = Value
        End Set
    End Property

    Public Property SQLUserID() As String
        Get
            Return _sqlUserID
        End Get
        Set(ByVal Value As String)
            _sqlUserID = Value
        End Set
    End Property

    Public Property SQLPassword() As String
        Get
            Return _sqlPassword
        End Get
        Set(ByVal Value As String)
            _sqlPassword = Value
        End Set
    End Property

    Public Property ClientType() As ProviderType Implements IConnectionData.ClientType
        Get
            Return _clientType
        End Get
        Set(ByVal Value As ProviderType)
            _clientType = Value
        End Set
    End Property


#End Region

#Region "Method "

    Public Overrides Function ToString() As String

    End Function

#End Region

End Class