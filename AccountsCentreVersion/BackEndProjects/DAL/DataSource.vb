Option Explicit On 
Option Strict On

Public Class DataSource



    Public Shared Function GetDataFactory(ByVal connData As ConnectionData) As IDataFactory   'Implements IDataFactory.GetDataFactory

        Dim df As IDataFactory
        Select Case connData.ClientType

            Case ProviderType.SQLClient
                'Instantiate the DataFactory for SQL Client
                df = New SQLHelper()


            Case ProviderType.OracleClient
                'Instantiate the DataFactory for Oracle Client
                df = New OracleHelper()

            Case ProviderType.PostGresClient
                'Instantiate the DataFactory for PostGres Client
                df = New PostGresHelper()


            Case ProviderType.AccessClient
                'Instantiate the DataFactory for SQL Client
                df = New AccessHelper()

        End Select

        Return df
    End Function


    'Public Shared Function ExecuteReader(ByVal connData As ConnectionData, ByVal Command As InfiniCommand) As IDataReader

    'End Function




End Class
