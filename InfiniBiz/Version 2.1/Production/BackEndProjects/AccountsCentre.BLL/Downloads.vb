Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient

Public Class Downloads
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     Get all services with specific given options and customer id.
    ''' </summary>
    ''' <param name="lCustomerID"> Customer ID </param>
    ''' <param name="lServiceOptions"> Service Options </param>
    ''' <returns>
    ''' Returns a data table that has a mode column.
    '''           0		--Buy
    '''           1		--Request    
    '''           2		--Download
    ''' </returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.shifatullah]	23/05/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetServicesByOptions(ByVal sCustomerID As String, ByVal lServiceOptions As Long) As DataTable
        Dim sqlprm As SqlParameter()
        Try
            'SqlHelper.ConnectionString = Connection.GetConnectionString

            sqlprm = New SqlParameter(1) {}
            sqlprm(0) = New SqlParameter("@vcustomerID", SqlDbType.VarChar, 18)
            sqlprm(0).Value = sCustomerID

            sqlprm(1) = New SqlParameter("@biServiceOptions", SqlDbType.BigInt)
            sqlprm(1).Value = lServiceOptions
            Dim dt As DataTable
            dt = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.ACC_GetCustomerServicesByOptions", sqlprm).Tables(0)
            Return dt
            'Catch x As Exception
            '    Throw New Exception("GetServicesByOptions() generated exception. " & x.Message)
        Finally
            sqlprm = Nothing
        End Try
    End Function

    Public Function SetCSSStatus(ByVal customerID As Integer, ByVal serviceID As Integer, ByVal status As Boolean) As Boolean
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        sqlParam(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.Int)
        sqlParam(0).Value = customerID

        sqlParam(1) = New SqlClient.SqlParameter("@ServiceID", SqlDbType.Int)
        sqlParam(1).Value = serviceID

        sqlParam(2) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 7)
        sqlParam(2).Value = IIf(status, "Enable", "Disable")

        'Not in use... placed here as they are required by SP!.................
        sqlParam(3) = New SqlClient.SqlParameter("@hdate", SqlDbType.DateTime)
        sqlParam(3).Value = Date.Today
        sqlParam(4) = New SqlClient.SqlParameter("@ReturnVal", SqlDbType.Int)
        sqlParam(4).Direction = ParameterDirection.Output
        '......................................................................

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ADMIN_SetCustomerSelectedServices", sqlParam)
    End Function
End Class
