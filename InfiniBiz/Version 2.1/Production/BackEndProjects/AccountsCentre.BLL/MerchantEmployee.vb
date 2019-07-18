Imports System.Data
Imports InfiniLogic.AccountsCentre.DAL

Public Class MerchantEmployee
    Public Shared Function GetEmployeeMerchant(ByVal EmployeeID As String) As DataSet
        Dim SqlParam() As System.Data.SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        SqlParam(0) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar, 500)
        SqlParam(0).Value = EmployeeID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "getEmployeeMerchant", SqlParam)
        Return ds
    End Function
End Class
