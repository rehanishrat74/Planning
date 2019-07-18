Imports System.Data.SqlClient
Imports System.Web
Imports InfiniLogic.AccountsCentre.DAL

Public Class InfiniAccountManagementManager
    Implements IInfiniManagers


    Public Sub New()

    End Sub

    Sub ExecuteService(ByVal intCustomerId As Int32) Implements IInfiniManagers.ExecuteService

        '~~~~~ This Flag denotes the Success/Failure of the Procedure 
        Dim Flag As Boolean

        '~~~~~ The Parameters Array to be passed to Stored Procedure 
        Dim databaseName As String = ServicesManager.GetDatabaseName(intCustomerId)
        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@DatabaseName", SqlDbType.VarChar, 50)
        arrParams(0).Value = databaseName
        arrParams(1) = New SqlParameter("@customerID", SqlDbType.VarChar, 50)
        arrParams(1).Value = intCustomerId
        'SqlHelper.ConnectionString = Connection.GetConnectionString(True)
        Try
            Flag = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "Acc_CreateCAMTablesAndProcedures", arrParams)
        Catch sqle As SqlException
            Throw New Exception(sqle.Message)
        End Try

    End Sub


End Class
