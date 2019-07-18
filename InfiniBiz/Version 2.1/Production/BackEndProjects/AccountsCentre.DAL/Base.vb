Public Class Base2

    Public Shared Function GetDBName(ByVal CustomerID As Integer) As String
        Return CType(Connection.GetConnStringParams(CustomerID), ConnStringParam).DBName
    End Function



End Class
