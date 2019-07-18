Imports System
Imports System.Windows.Forms
Imports Infinilogic.BusinessPlan.DAL


Public Class BizPlanBase
    Inherits System.Windows.Forms.Form


#Region "Private Class Members"

    'Database Location 
    Private _applicationDirectory As String '= System.AppDomain.CurrentDomain.BaseDirectory
    ' DatabaseName 
    Private _databaseName As String '= "BizPlan2"
    ' Datasource Name 
    Private _dataSource As String '= "furqanpc" '_applicationDirectory
    ' Service Name 
    Private _serviceName As String '= "BizPlanDesktop"

#End Region

#Region "Protected Members"

    ' ConnectionData 
    Protected _connectionData As ConnectionData
    ' BusinessType 
    Protected Shared _businessPlanSummary As BusinessPlan
    ' Provide Type Enumeration : can be SQLClient , AccessClient etc
    Protected _clientType As ProviderType
    ' Display Type Enumeration : can be Text , Table , Chart
    Protected _mdiDisplayState As DisplayState = DisplayState.Table
    ' ConfigurationData Object 
    Dim _configuration As AppConfig


#End Region

#Region "Constructors"

    Protected Sub New()
        _configuration = New AppConfig
        _applicationDirectory = _configuration.AppDirectory
        _databaseName = _configuration.Database
        _dataSource = Environ$("computername") & "\" & _configuration.DataSource       ' "furqanpc"  ' _applicationDirectory
        _serviceName = _configuration.ServiceName   ' "BizPlanDesktop"
        _clientType = _configuration.ClientType
        _connectionData = New ConnectionData(_serviceName, _dataSource, _databaseName, _clientType)
        _connectionData.SQLUserID = _configuration.SQLUserID
        _connectionData.SQLPassword = _configuration.SQLPassword
    End Sub

#End Region

#Region "ReadOnly / WriteOnly Properties "

    Public ReadOnly Property GetConnectionData() As ConnectionData
        Get
            Return _connectionData
        End Get
    End Property

    Public ReadOnly Property CurrentPlan() As BusinessPlan
        Get
            Return _businessPlanSummary
        End Get
    End Property

    Public ReadOnly Property Configuration() As AppConfig
        Get
            Return _configuration
        End Get
    End Property

    Public WriteOnly Property BusinessPlanSummary() As BusinessPlan
        Set(ByVal Value As BusinessPlan)
            _businessPlanSummary = Value
        End Set
    End Property

#End Region

End Class
