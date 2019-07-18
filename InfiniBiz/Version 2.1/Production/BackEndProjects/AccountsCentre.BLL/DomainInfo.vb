Imports System.Data

Public Class DomainInfo
    Public Sub AddDomainInfo(ByVal ResellerID As String, _
                                ByVal CustomerID As String, _
                                ByVal OrderID As String, _
                                ByVal ProductCode As String, _
                                ByVal DaemonAccepted As Boolean, _
                                ByVal DaemonAcceptedTime As Date, _
                                ByVal DomainName As String, _
                                ByVal CompanyName As String, _
                                ByVal DaemonMessage As String, _
                                ByVal Status As Integer)
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(9) {}
        sqlParams(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = CustomerID
        sqlParams(1) = New SqlClient.SqlParameter("@OrderID", SqlDbType.BigInt)
        sqlParams(1).Value = OrderID
        sqlParams(2) = New SqlClient.SqlParameter("@ProductCode", SqlDbType.VarChar)
        sqlParams(2).Value = ProductCode
        sqlParams(3) = New SqlClient.SqlParameter("@DaemonAccepted", SqlDbType.Bit)
        sqlParams(3).Value = DaemonAccepted
        sqlParams(4) = New SqlClient.SqlParameter("@DaemonAcceptedTime", SqlDbType.DateTime)
        sqlParams(4).Value = DaemonAcceptedTime
        sqlParams(5) = New SqlClient.SqlParameter("@DomainName", SqlDbType.VarChar)
        sqlParams(5).Value = DomainName
        sqlParams(6) = New SqlClient.SqlParameter("@CompanyName", SqlDbType.VarChar)
        sqlParams(6).Value = CompanyName
        sqlParams(7) = New SqlClient.SqlParameter("@DaemonMessage", SqlDbType.VarChar)
        sqlParams(7).Value = DaemonMessage
        sqlParams(8) = New SqlClient.SqlParameter("@Status", SqlDbType.Int)
        sqlParams(8).Value = Status
        sqlParams(9) = New SqlClient.SqlParameter("@ResellerID", SqlDbType.BigInt)
        sqlParams(9).Value = ResellerID

        InfiniLogic.AccountsCentre.DAL.SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_AddDomainInfo", sqlParams)
    End Sub

    Public Sub UpdateDomainInfo(ByVal DomainName As String, _
                                ByVal DaemonUpdateTime As Date, _
                                ByVal Status As Integer, _
                                ByVal popuserid As String, _
                                ByVal domainpass As String, _
                                ByVal ftppass As String, _
                                ByVal updateStatus As Integer, _
                                ByVal updatetype As Integer, _
                                ByVal duration As Decimal)
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}
        sqlParams(0) = New SqlClient.SqlParameter("@DomainName", SqlDbType.VarChar)
        sqlParams(0).Value = DomainName
        sqlParams(1) = New SqlClient.SqlParameter("@DaemonUpdatedTime", SqlDbType.DateTime)
        sqlParams(1).Value = DaemonUpdateTime
        sqlParams(2) = New SqlClient.SqlParameter("@Status", SqlDbType.Int)
        sqlParams(2).Value = Status
        sqlParams(3) = New SqlClient.SqlParameter("@popuserid", SqlDbType.VarChar)
        sqlParams(3).Value = popuserid
        sqlParams(4) = New SqlClient.SqlParameter("@domainpass", SqlDbType.VarChar)
        sqlParams(4).Value = domainpass
        sqlParams(5) = New SqlClient.SqlParameter("@ftppass", SqlDbType.VarChar)
        sqlParams(5).Value = ftppass
        sqlParams(6) = New SqlClient.SqlParameter("@updateStatus", SqlDbType.Int)
        sqlParams(6).Value = updateStatus
        sqlParams(7) = New SqlClient.SqlParameter("@type", SqlDbType.Int)
        sqlParams(7).Value = updatetype
        sqlParams(8) = New SqlClient.SqlParameter("@duration", SqlDbType.Decimal)
        sqlParams(8).Value = duration

        InfiniLogic.AccountsCentre.DAL.SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_UpdateDomainInfo", sqlParams)

    End Sub

    Public Shared Function GetDomainInfo(ByVal DomainName As String) As DataSet
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParams(0) = New SqlClient.SqlParameter("@DomainName", SqlDbType.VarChar)
        sqlParams(0).Value = DomainName

        Dim ds As DataSet
        ds = InfiniLogic.AccountsCentre.DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetDomainInfo_DomainName", sqlParams)
        Return ds
    End Function

    '
End Class
