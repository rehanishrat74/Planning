Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data
Imports System.Data.SqlClient
Public Class AdminManager

#Region "     Shared Methods  ..............."

    Public Shared Function EnableService(ByVal customerId As String, ByVal serviceID As Integer) As Boolean


        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 100)
        arrParams(0).Value = customerId
        arrParams(1) = New SqlParameter("@serviceID", SqlDbType.VarChar, 10)
        arrParams(1).Value = serviceID
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            If (IsServicePresent(customerId, serviceID)) Then
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Acc_EnableCustomerServiceByUpdate", arrParams)
            Else
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Acc_EnableCustomerServiceByInsert", arrParams)
            End If

        Catch sqle As SqlException
            Throw New Exception("EnableService() produced the Error." & sqle.Message)
        End Try
    End Function

    Public Shared Function DisableService(ByVal customerId As String, ByVal serviceID As Integer) As Boolean


        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 100)
        arrParams(0).Value = customerId
        arrParams(1) = New SqlParameter("@serviceID", SqlDbType.VarChar, 10)
        arrParams(1).Value = serviceID
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "Acc_DisableCustomerServiceByUpdate", arrParams)
        Catch sqle As SqlException
            Throw New Exception("EnableService() produced the Error." & sqle.Message)
        End Try
    End Function

    Public Shared Function GetActiveServices(ByVal customerId As String) As SqlDataReader
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 50)
        arrParams(0).Value = customerId
        Dim reader As SqlDataReader
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            reader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_GetActiveServices", arrParams)
        Catch sqle As SqlException
            Throw New Exception("GetActiveServices() produced the Error." & sqle.Message)
        End Try
        Return reader
    End Function

    Public Shared Function CustomerExists(ByVal customerId As String) As Boolean
        Dim arrParams As SqlParameter() = New SqlParameter(0) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 10)
        arrParams(0).Value = customerId
        Dim reader As SqlDataReader
        Dim result As Boolean
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            reader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_GetCustomer", arrParams)
            result = reader.Read

        Catch sqle As SqlException
            Throw New Exception("Customer Does Not exists." & sqle.Message)
        Finally
            If Not reader.IsClosed Then reader.Close()
            If Not reader Is Nothing Then reader = Nothing
        End Try
        Return result
    End Function

    Public Shared Function GetAllServices() As DataSet
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "Acc_GetAllServices", Nothing)
            Return ds
        Catch sqle As SqlException
            Throw New Exception("Customer Does Not exists." & sqle.Message)
        End Try


    End Function

    Public Shared Function IsServicePresent(ByVal customerId As String, ByVal serviceID As Integer) As Boolean
        Dim arrParams As SqlParameter() = New SqlParameter(1) {}
        arrParams(0) = New SqlParameter("@customerID", SqlDbType.VarChar, 100)
        arrParams(0).Value = customerId
        arrParams(1) = New SqlParameter("@serviceID", SqlDbType.VarChar, 10)
        arrParams(1).Value = serviceID
        Dim reader As SqlDataReader
        Dim result As Boolean
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString
            reader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "Acc_IsServicePresent", arrParams)
            result = reader.Read
        Catch sqle As SqlException
            Throw New Exception("IsServicePresent() produced the Error." & sqle.Message)
        Finally
            If Not reader.IsClosed Then reader.Close()
            If Not reader Is Nothing Then reader = Nothing
        End Try
        Return result
    End Function

#End Region

End Class
