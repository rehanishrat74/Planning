#Region " Import Libraries "
'Imports System
'Imports System.Collections.Specialized
'Imports System.Security.Cryptography
Imports System.Text
Imports Path = System.IO.Path
#End Region

Public Class Connection

    Private Sub New()
    End Sub ' New

#Region " Class Functions/Methods"

    Public Overloads Shared Function GetConnectionString(ByVal connData As ConnectionData) As String
        Return PrepareConnectionString(connData)
    End Function

    Private Shared Function PrepareConnectionString(ByVal connData As ConnectionData) As String

        Dim CnString, AppPath As String
        Dim _DataBaseName As String
        Dim _DataSource As String
        'Dim _Password As String
        Dim _ServiceName As String
        'Dim _UserID As String
        Dim _ProviderType As ProviderType

        _DataBaseName = connData.DatabaseName
        _DataSource = connData.DataSource
        '_Password = connData.Password
        _ServiceName = connData.ServiceName
        '_UserID = connData.UserID
        _ProviderType = connData.ClientType

        Select Case _ProviderType
            Case ProviderType.AccessClient
                ' Return OleDbConnection to connect to Access
                AppPath = Path.GetFullPath(_DataBaseName)
                _DataSource = AppPath.Replace("bin", "DataBase")
                CnString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" + _DataSource
            Case ProviderType.OracleClient
                ' Return OleDbConnection to connect to Oracle
            Case ProviderType.PostGresClient
                ' Return OleDbConnection to connect to PostGres
            Case ProviderType.SQLClient
                Dim sqlUserID, sqlPassword, sqlDataSource As String

                ' Following values will come from the component.
                sqlUserID = connData.SQLUserID
                sqlPassword = connData.SQLPassword
                sqlDataSource = connData.DataSource  '"DataCentre"

                'Prepare all values and return
                CnString = "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & sqlDataSource & ";Initial Catalog=" & connData.DatabaseName
                ' Return SQLConnection to connect to Access
        End Select

        'Prepare all values and return
        Return CnString

    End Function

#End Region

End Class