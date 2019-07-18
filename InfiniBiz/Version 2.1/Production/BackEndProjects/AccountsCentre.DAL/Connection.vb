Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web
'************************************************************************************

' NameSpace: InfiniPayroll.DAL
' Class: Connection

' Description: 
'   This class provide access to data sources (MS SQL Server database and XML files).
'   Class methods and properties communicate with these data sources and enables other layers
'   to use these data sources. 
'   It provides the Connection String of the default database which stores the initial data requires to run this service.
'   It also provides customize Connection String of a given database.

'************************************************************************************

Public Class Connection



#Region " Declarations"

    Private Shared sqlUserID As String = ConfigReader.GetItem(ConfigVariables.SQLUserID)
    Private Shared sqlPassword As String = ConfigReader.GetItem(ConfigVariables.SQLPassword)
    Public Const DEFAULT_DATABASE As String = "DBGateWay"
    Private Shared _strDatabaseName As String
    Private Shared _blnIsEncrypted As Boolean
    Private _isAdministrator As Boolean
    Private _sqlUserID As String
    Private _sqlPassword As String
    Private _sqlDataSource As String
    Private _sqlInitialCatalog As String
    Public Shared CONNECTIONSLIST As New Hashtable(5000)
    Public Shared AuthenticatedUser As Boolean


#Region "Testing Variables"
#If TEST Then
    Public Shared temp As Int16
    Public Shared USERID As Integer
#End If

#End Region

#End Region


    Shared Sub New()

#If Not TEST Then
        AuthenticatedUser=httpcontext.Current.User.Identity.IsAuthenticated 
#End If

        RefreshConnectionList()
    End Sub
    Private Sub New()
    End Sub ' New

#Region " Class Properties"
    Public Enum DBUsers
        DBAdmin = 0
        SQLUser = 1
    End Enum

    Public Shared Property DatabaseName() As String
        Get
            Return _strDatabaseName
        End Get
        Set(ByVal Value As String)
            _strDatabaseName = Value
        End Set
    End Property 'DatabaseName
    '____________________________________________________________________________

#End Region

#Region " Class Functions/Methods"

    '*******************************************************************
    'Synopsis   :  Provides the connection string of the default database i.e. "DBGateway".
    'Inputs       :  None
    'Assume     :  Database name has given. If it is not given then get the 
    '                   Default_Database constant value.
    'Returns    :   Complete connection string. 
    '*******************************************************************

    Public Overloads Shared Function GetConnectionString(Optional ByVal employerid As Integer = 0) As String

        Return ConnectionString(GetConnStringParams(employerid))

    End Function

    Public Shared Function GetConnStringParams(Optional ByVal employerId As Integer = 0) As ConnStringParam
        Dim sqlDataSource, databasename As String
        sqlDataSource = ConfigReader.GetItem(ConfigVariables.DataSource)    '"Default Server"
        databasename = ConfigReader.GetItem(ConfigVariables.InitialCatalog)   'DEFAULT_DATABASE 

        Dim connParam As ConnStringParam

        If Not (Not AuthenticatedUser AndAlso employerId = 0) Then

            Dim CustomerID As Integer

#If TEST Then
            CustomerID = USERID
#Else

            If employerId > 0 Then
                CustomerID = employerId
            Else
                CustomerID = HttpContext.Current.User.Identity.Name
            End If

#End If


            If Not CONNECTIONSLIST.Contains(CustomerID) Then RefreshConnectionList()

            connParam = CONNECTIONSLIST(CustomerID)

            sqlDataSource = connParam.ServerName

            If employerId > 0 Then databasename = connParam.DBName


        End If


        connParam.DBName = databasename
        connParam.ServerName = sqlDataSource
        Return connParam
    End Function

    Public Shared Sub GetConnStringParams(ByRef sqlDataSource As String, ByRef databasename As String, ByVal employerid As Integer)

        Dim conn As New SqlConnection(ConnectionString(sqlDataSource, databasename))

        Dim cmd As New SqlCommand("DBSERVER.InfinishopMainDB.DBO.Acc_GetDatabaseName", conn)

        Dim dr As SqlDataReader
        Try


            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@CustomerID", employerid))
                conn.Open()
                dr = .ExecuteReader(CommandBehavior.SingleRow)
                With dr
                    .Read()
                    sqlDataSource = .Item("server_name")
                    databasename = .Item("db_name")
                End With

            End With

        Finally
            If Not dr.IsClosed Then dr.Close()
            conn.Close()
            conn.Dispose()

        End Try
    End Sub

    Public Shared Function ConnectionString(ByVal sqldatasource As String, ByVal databasename As String) As String
        Return "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & sqldatasource & ";Initial Catalog=" & databasename
    End Function

    Public Shared Function ConnectionString(ByVal connParam As ConnStringParam)
        With connParam
            Return "User ID=" & sqlUserID & ";Password=" & sqlPassword & ";Data Source=" & .ServerName & ";Initial Catalog=" & .DBName
        End With

    End Function


    Public Overloads Shared Function GetConnectionString(ByVal dBName As String) As String

        Dim sqlDataSource, databasename As String
        sqlDataSource = ConfigReader.GetItem(ConfigVariables.DataSource) 'DEFAULT_DATABASE
        databasename = ConfigReader.GetItem(ConfigVariables.InitialCatalog) '
        Dim conn As New SqlConnection(ConnectionString(sqlDataSource, databasename))
        Dim cmd As New SqlCommand("DBServer.InfiniShopMainDB.dbo.ACC_GetCustomerID", conn)
        Dim employerid As Integer
        Try

            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add("@db_name", dBName)
                conn.Open()
                employerid = .ExecuteScalar()
                Return GetConnectionString(employerid)
            End With
        Finally
            conn.Close()
            conn.Dispose()
        End Try

    End Function

    'Public Overloads Shared Function GetConnectionString(ByVal employerID As Int32) As String

    '    GetConnectionString = PrepareConnectionString(GetDataBaseName(employerID))
    'End Function

    'Public Overloads Shared Function GetAdminConnectionString() As String

    'End Function

    'Public Overloads Shared Function GetConnectionString(ByVal databaseName As String, ByVal isAdministrator As Boolean) As String

    'End Function

    Public Overloads Shared Function GetConnectionString(ByVal isAdministrator As Boolean) As String
        If isAdministrator = True Then

            'GetConnectionString = "User ID =" & GetAdminUserID() & ";Password=" & GetAdminPassword() & ";Data Source=DataCentre;Initial Catalog=DBGateway"
            'GetConnectionString = "User ID =dbadmin;Password=jb7T9fLS;Data Source=DataCentre;Initial Catalog=DBGateway"
            GetConnectionString = "User ID =" & ConfigReader.GetItem(ConfigVariables.SQLAdminID) & ";Password=" & ConfigReader.GetItem(ConfigVariables.SQLAdminPassword) & ";Data Source=" & ConfigReader.GetItem(ConfigVariables.DataSource) & ";Initial Catalog=" & ConfigReader.GetItem(ConfigVariables.InitialCatalog)
        End If

    End Function

    Private Overloads Shared Function GetDataBaseName(ByVal employerID As String) As String
        Return GetConnStringParams(employerID).DBName
    End Function

    Public Shared Sub RefreshConnectionList()
#If TEST Then
        temp += 1
#End If

        Dim sqlDataSource, databasename As String
        sqlDataSource = ConfigReader.GetItem(ConfigVariables.DataSource) 'DEFAULT_DATABASE
        databasename = ConfigReader.GetItem(ConfigVariables.InitialCatalog) '
        Dim conn As New SqlConnection(ConnectionString(sqlDataSource, databasename))
        Dim cmd As New SqlCommand("DBServer.InfiniShopMainDB.dbo.ACC_GetServersNames", conn)
        Dim dr As SqlDataReader
        Dim connParam As New ConnStringParam

        CONNECTIONSLIST.Clear()
        Try
            With cmd
                .CommandType = CommandType.StoredProcedure
                conn.Open()
                dr = .ExecuteReader(CommandBehavior.SingleResult)

                With dr
                    While .Read()

                        SyncLock CONNECTIONSLIST.SyncRoot

                            connParam.ServerName = IIf(IsDBNull(.Item("server_name")), ConfigReader.GetItem(ConfigVariables.DataSource), .Item("server_name"))
                            connParam.DBName = IIf(IsDBNull(.Item("db_name")), "M" & .Item("customer_id"), .Item("db_name"))
                            CONNECTIONSLIST.Add(CInt(.Item("customer_id")), connParam)

                        End SyncLock

                    End While
                End With

            End With
        Catch e As Exception
            Console.WriteLine(e.ToString)
            Console.WriteLine("Error on this connectionstring :::: " & conn.ConnectionString)
        Finally

        End Try

    End Sub

#End Region

End Class

Public Structure ConnStringParam
    Public ServerName As String
    Public DBName As String
End Structure


#Region " Class Decrypt "
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Class Decrypt

#Region " Shared Variables "

    Private Shared Key As Byte() = New Byte(15) {226, 252, 113, 76, 71, 39, 238, 147, 149, 243, 36, 205, 46, 127, 51, 31}
    Private Shared IV As Byte() = New Byte(7) {240, 3, 45, 219, 0, 176, 173, 59}

#End Region

    Public Shared Function decrypt(ByVal strEncryptedString As String) As String
        Try
            ' SetParameters()
            Dim buffer As Byte() = Convert.FromBase64String(strEncryptedString)
            Dim objDES As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider
            Dim md5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider
            objDES.Key = md5.ComputeHash(Key)
            objDES.IV = IV
            Return Encoding.ASCII.GetString(objDES.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length))
        Catch e As CryptographicException
            Throw New InvalidDataException
        Catch fe As FormatException
            Throw New InvalidDataException

        End Try

    End Function

End Class

#End Region

#Region " Class InvalidDataException "

Class InvalidDataException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

End Class

#End Region