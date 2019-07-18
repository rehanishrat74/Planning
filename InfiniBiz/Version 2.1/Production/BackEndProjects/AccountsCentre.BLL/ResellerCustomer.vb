Imports System
Imports System.Data.SqlClient
Imports System.Configuration
Imports InfiniLogic.AccountsCentre.DAL

Public Class ResellerCustomer
    Public Shared Function GetResellerOrder_CustomerID(ByVal MainCustomerID As String, ByVal OrderID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@OrderID", SqlDbType.BigInt)
        arParams(0).Value = OrderID
        arParams(1) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(1).Value = MainCustomerID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetResellerOrder_CustomerID", arParams)
        Dim DomainName As String = ""
        If rdr.Read Then
            DomainName = rdr("ResellerID")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return DomainName
    End Function

    Public Shared Function GetResellerID_CustomerID(ByVal CustomerID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(0).Value = CustomerID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetResellerID_CustomerID", arParams)
        Dim DomainName As String = ""
        If rdr.Read Then
            DomainName = rdr("ResellerID")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return DomainName
    End Function

    Public Shared Function GetCompanyName_OrderID(ByVal ResellerID As String, _
                                                ByVal OrderID As String, _
                                                ByVal ProductCode As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(2) {}
        arParams(0) = New SqlParameter("@OrderID", SqlDbType.BigInt)
        arParams(0).Value = OrderID
        arParams(1) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(1).Value = ResellerID
        arParams(2) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 255)
        arParams(2).Value = ProductCode

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetDomainName_OrderID", arParams)
        Dim DomainName As String = ""
        If rdr.Read Then
            DomainName = rdr("CompanyName")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return DomainName
    End Function

    Public Shared Function GetDomainName_OrderID(ByVal ResellerID As String, _
                                                ByVal OrderID As String, _
                                                ByVal ProductCode As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(2) {}
        arParams(0) = New SqlParameter("@OrderID", SqlDbType.BigInt)
        arParams(0).Value = OrderID
        arParams(1) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(1).Value = ResellerID
        arParams(2) = New SqlParameter("@ProductCode", SqlDbType.VarChar, 255)
        arParams(2).Value = ProductCode

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetDomainName_OrderID", arParams)
        Dim DomainName As String = ""
        If rdr.Read Then
            DomainName = rdr("DomainName")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return DomainName
    End Function

    Public Shared Function GetMapACCustomerID(ByVal ResellerID As String, ByVal RCustomerID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(0).Value = ResellerID
        arParams(1) = New SqlParameter("@RCustomerID", SqlDbType.VarChar, 500)
        arParams(1).Value = RCustomerID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetResellerCustomerMapping", arParams)
        Dim AC_CustomerID As String = ""
        If rdr.Read Then
            AC_CustomerID = rdr("ACCustomerID")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return AC_CustomerID
    End Function


    Public Shared Function GetACCustomerID(ByVal ResellerID As String, ByVal RCustomerID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@MerchantID", SqlDbType.BigInt)
        arParams(0).Value = ResellerID
        arParams(1) = New SqlParameter("@RCustomerID", SqlDbType.VarChar, 255)
        arParams(1).Value = RCustomerID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "RSS_GetACCustomerID", arParams)
        Dim AC_CustomerID As String = ""
        If rdr.Read Then
            AC_CustomerID = rdr("CustomerID")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return AC_CustomerID
    End Function

    Public Shared Function GetMerchantCustomerID(ByVal MerchantID As String, ByVal CustomerUID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@MerchantID", SqlDbType.VarChar, 255)
        arParams(0).Value = MerchantID
        arParams(1) = New SqlParameter("@RCustomerUID", SqlDbType.VarChar, 255)
        arParams(1).Value = CustomerUID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "RSS_GetMerchantCustomerID", arParams)
        Dim ResellerCustomerUID As String = ""
        If rdr.Read Then
            ResellerCustomerUID = rdr("customer_id")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return ResellerCustomerUID
    End Function

    Public Shared Function GetMerchantCustomerUID(ByVal MerchantID As String, ByVal CustomerID As String) As String
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@MID", SqlDbType.VarChar, 255)
        arParams(0).Value = MerchantID
        arParams(1) = New SqlParameter("@customer_id", SqlDbType.VarChar, 255)
        arParams(1).Value = CustomerID

        Dim rdr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "RSS_GetMerchantCustomerUID", arParams)
        Dim ResellerCustomerUID As String = ""
        If rdr.Read Then
            ResellerCustomerUID = rdr("cart_customer_uid")
        End If
        Try
            rdr.Close()
        Catch ex As Exception
        End Try

        Return ResellerCustomerUID
    End Function

    Public Shared Sub InsertBizAPICredential(ByVal ResellerID As String, ByVal Password As String)
        Dim arParams() As SqlParameter = New SqlParameter(1) {}
        arParams(0) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(0).Value = ResellerID
        arParams(1) = New SqlParameter("@Password", SqlDbType.NVarChar, 1000)
        arParams(1).Value = Password

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_InsertBizAPICredential", arParams)
    End Sub
End Class
