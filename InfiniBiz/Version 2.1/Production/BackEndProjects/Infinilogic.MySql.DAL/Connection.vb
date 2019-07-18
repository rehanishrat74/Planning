Imports InfiniLogic.AccountsCentre.common
'Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web

Public Class MySql_Connection

    Public Enum ConnectTo
        FhDB = 0
        IoDB = 1
        NattingDB = 2
    End Enum

    Shared Sub New()
    End Sub

#Region " Class Functions/Methods"

    Public Shared Function GetConnectionString(ByVal ConnectionDB As ConnectTo) As String
        '"database=;server=192.168.1.68;User Id=web_proc;Password=abc123;pooling=false;"

        Dim conString As String = String.Empty
        Dim dbName As String = String.Empty
        Select Case ConnectionDB
            Case ConnectTo.FhDB
                Try
                    dbName = ConfigReader.GetItem(ConfigVariables.FH_MySqlDatabase)
                Catch ex As Exception
                End Try
                conString = "database=" & dbName & ";User ID =" & ConfigReader.GetItem(ConfigVariables.FH_MySqlUser) & ";Password=" & ConfigReader.GetItem(ConfigVariables.FH_MySqlPassword) & ";server=" & ConfigReader.GetItem(ConfigVariables.FH_MySqlServer) & ";pooling=false;"
            Case ConnectTo.IoDB
                Try
                    dbName = ConfigReader.GetItem(ConfigVariables.IO_MySqlDatabase)
                Catch ex As Exception
                End Try
                conString = "database=" & dbName & ";User ID =" & ConfigReader.GetItem(ConfigVariables.IO_MySqlUser) & ";Password=" & ConfigReader.GetItem(ConfigVariables.IO_MySqlPassword) & ";server=" & ConfigReader.GetItem(ConfigVariables.IO_MySqlServer) & ";pooling=false;"
            Case ConnectTo.NattingDB
                Try
                    dbName = ConfigReader.GetItem(ConfigVariables.NAT_MySqlDatabase)
                Catch ex As Exception
                End Try
                conString = "database=" & dbName & ";User ID =" & ConfigReader.GetItem(ConfigVariables.NAT_MySqlUser) & ";Password=" & ConfigReader.GetItem(ConfigVariables.NAT_MySqlPassword) & ";server=" & ConfigReader.GetItem(ConfigVariables.NAT_MySqlServer) & ";pooling=false;"
        End Select
        Return conString
    End Function

#End Region

End Class