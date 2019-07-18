
Imports System.IO
Imports System.text
Imports System.data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL


Public Class CustomerPointMethods

    Public Shared Function getMerchantInformation(ByRef Customerid As Integer) As DataTable

        Dim planid As String
        Dim Trackerid As String, str_userid As String, str_loginid As String, impid As String
        Dim str_domain As String, str_logininfo As String

        Dim cmd As New CommandData(Customerid)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.CmdText = "CUSTOMERPOINT_GetDomainNameByCustomerID"

        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)

    End Function


    Public Shared Function GetVisitsCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal DomainName As String) As Integer
        Dim _VisitsCount As Integer

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DomainName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMEROINT_GetVisitCount"
        _VisitsCount = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows.Count

        Return _VisitsCount

    End Function




    Public Shared Function GetProductCount(ByRef Customerid As Integer, ByVal StartDate As String, ByVal DomainName As String) As Integer
        Dim _productCount As Integer

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DomainName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetProductCount"
        _productCount = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows(0).Item(0)

        Return _productCount
    End Function

    Public Shared Function GetOrderCount(ByRef Customerid As Integer, ByVal StartDate As String, ByVal DoaminName As String) As DataTable
 
        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetCustomerIDsList"
        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)


    End Function

    Public Shared Function PostOrderCount(ByVal Midentity As Integer, ByVal Customerid As String, ByVal StartDate As String, ByVal DoaminName As String) As Integer

        Dim cmd As New CommandData(Midentity)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.AddParameter("@midentity", Midentity)
        cmd.CmdText = "CUSTOMERPOINT_GetOrderCountByCustomerID"
        Return CType(cmd.Execute(ExecutionType.ExecuteScalar), Integer)


    End Function

    Public Shared Function GetMenuForTracker(ByVal CustomerpointID As String) As DataSet

        Dim cmd As New CommandData
        cmd.AddParameter("@CustomerpointID", CustomerpointID)
        cmd.CmdText = "DBSERVER.INFINISHOPMAINDB.DBO.CUSTOMEROINT_GetNodebyCustomerPointID"
        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

    End Function




End Class
