Option Explicit On 
Option Strict On

Imports Infinilogic.BusinessPlan.DAL
Imports System.Xml
Imports System.IO


Public Class AppConfig


#Region "Private Members"

    Private Shared _xmlDoc As XmlDocument
    Private ba() As Byte = New Byte() {41, 145, 30, 143, 158, 164, 182, 219, 87, 222, 5, 225, 53, 18, 195, 87}

#End Region

#Region "Private Business Plan Variables"

    Private _applicationDirectory As String
    ' DatabaseName 
    Private _databaseName As String
    ' Datasource Name 
    Private _dataSource As String
    ' Service Name 
    Private _serviceName As String
    ' SQLUserID
    Private _sqlUserID As String
    ' SQLPassword
    Private _sqlPassword As String
    ' ProviderType 
    Private _clientType As ProviderType
    ' Last Plan ID 
    Private _lastPlanID As Integer

#End Region

    Public Sub New()
        If (IsNothing(_xmlDoc)) Then
            LoadConfiguration()
        End If
        AssignConfiguration()
    End Sub

#Region "Public Properties"

    Public ReadOnly Property ServiceName() As String
        Get
            Return _serviceName
        End Get
    End Property

    Public ReadOnly Property DataSource() As String
        Get
            Return _dataSource
        End Get
    End Property

    Public ReadOnly Property Database() As String
        Get
            Return _databaseName
        End Get
    End Property

    Public ReadOnly Property ClientType() As ProviderType
        Get
            Return _clientType
        End Get
    End Property

    Public ReadOnly Property SQLUserID() As String
        Get
            Return _sqlUserID
        End Get
    End Property

    Public ReadOnly Property SQLPassword() As String
        Get
            Return _sqlPassword
        End Get
    End Property

    Public ReadOnly Property AppDirectory() As String
        Get
            Return _applicationDirectory
        End Get
    End Property

    Public ReadOnly Property LastPlanID() As Integer
        Get
            Return _lastPlanID
        End Get
    End Property

#End Region

#Region "Private Methods "

    Private Sub LoadConfiguration()

        Dim fileName As String = "BizPlan.xml"
        _xmlDoc = New XmlDocument
        _xmlDoc.Load(fileName)

    End Sub

    Private Sub AssignConfiguration()

        _applicationDirectory = _xmlDoc.SelectSingleNode("//Directory").FirstChild.Value
        _serviceName = _xmlDoc.SelectSingleNode("//Name").FirstChild.Value
        _dataSource = _xmlDoc.SelectSingleNode("//DataSourceName").FirstChild.Value
        _databaseName = _xmlDoc.SelectSingleNode("//DatabaseName").FirstChild.Value
        _sqlUserID = _xmlDoc.SelectSingleNode("//UserID").FirstChild.Value
        _sqlPassword = _xmlDoc.SelectSingleNode("//Password").FirstChild.Value


        Dim isEncrypted As Boolean = Convert.ToBoolean(_xmlDoc.SelectSingleNode("//SQLData").Attributes(0).Value)
        If (isEncrypted) Then
            _sqlUserID = Encryptor.decrypt(_sqlUserID, ba)
            _sqlPassword = Encryptor.decrypt(_sqlPassword, ba)
        End If
        Dim s As Integer = CInt(_xmlDoc.SelectSingleNode("//ClientType").FirstChild.Value)
        If (s = 2) Then
            _clientType = ProviderType.SQLClient
        End If
        _lastPlanID = CInt(_xmlDoc.SelectSingleNode("//LastPlanID").FirstChild.Value)

    End Sub

#End Region

End Class
