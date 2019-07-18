#Region "......................Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.web
#End Region


Public Class TrackerCustomerPoint

    'Get Visit Parent Panel Data
    Public Shared Function GetVisitsParentGridData(ByVal connData As ConnectionData, ByVal StatrDate As String, ByVal DomainName As String) As DataSet

        Try

    

        Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
        _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMEROINT_GetVisitData")
        _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.StringFixedLength)

        _InfiniCommand.AddParameter("@StartDate", StatrDate, System.Data.DbType.String)

        Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try
    End Function

    'Get Visit Child Order Detail Panel Data
    Public Shared Function GetVisitChildOrderDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal _CustomerIDs As String) As DataSet





        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMEROINT_GetVisitOrdersDetails")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function

    'Get Product Child Order Detail Panel Data
    Public Shared Function GetVisitChildOrderDetailByProduct(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal _ProductIDs As String) As DataSet

        Try

        Catch ex As Exception

        End Try
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMEROINT_GetVisitOrdersDetailsByProduct")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@Productid", _ProductIDs, System.Data.DbType.StringFixedLength)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function


    'Get Visit Child Product Detail Panel Data
    Public Shared Function GetVisitChildCustomerDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal DomainName As String, ByVal _CustomerIDs As String) As DataSet




        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMEROINT_GetVisitCustomerDetails")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function

    'Get Visit parent order count to map in parent grid
    Public Shared Function GetVisitOrderCount(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal Customerid As String) As Integer

    
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMEROINT_GetVisitOrdersCount")

            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@CustomerId", Customerid, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try


    End Function

    'Get Product page order count to map in parent grid
    Public Shared Function GetVisitOrderCountByProduct(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal Productid As String) As Integer

 
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMEROINT_GetVisitOrdersCountByProduct")

            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@Productid", Productid, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If



        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function


    'Get Order Child   Detail Panel Data
    Public Shared Function GetOrderChildCustomerDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal _CustomerIDs As String) As DataSet

   
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMEROINT_GetOrderParentInfo")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function

    'Get Order Parent Panel Data
    Public Shared Function GetOrderParentGridData(ByVal connData As ConnectionData, ByVal StatrDate As String, ByVal DomainName As String) As DataSet


        Try



            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMEROINT_GetCustomerIDsOrderData")
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.StringFixedLength)

            _InfiniCommand.AddParameter("@StartDate", StatrDate, System.Data.DbType.String)

            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try
    End Function


    'Get Product Child Product Detail Panel Data
    Public Shared Function GetProductChildCustomerDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal DomainName As String, ByVal _ProductID As String) As DataSet

        Try

        Catch ex As Exception

        End Try
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetProductDataDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ProductId", _ProductID, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function

    'Get Product Parent Panel Data
    Public Shared Function GetProductParentGridData(ByVal connData As ConnectionData, ByVal DomainName As String, ByVal StartDate As String) As DataSet

        Try

        Catch ex As Exception

        End Try
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetProductData")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)

            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)

            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function


    'Used in Visit,Product,Order Node
    Public Shared Function getMerchantInformation(ByRef connData As ConnectionData) As DataTable
        Try



            Dim cmd As New CommandData(connData.CustomerID)
            cmd.AddParameter("@CustomerId", connData.CustomerID)
            cmd.CmdText = "CUSTOMERPOINT_GetDomainNameByCustomerID"
            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)

        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try
    End Function

    'Used in Visit,Product,Order Node
    Public Shared Function GetCurrentSessions(ByVal connData As ConnectionData, ByVal _DomainName As String) As DataSet

        Try

        Catch ex As Exception

        End Try
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetCurrentSessions")
            _InfiniCommand.AddParameter("@DomainName", _DomainName, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)


        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn(ex.Message)
        End Try

    End Function

    'Used to give product xml and gets product name
    Public Shared Function GetProductDetailByProductIDs(ByVal connData As ConnectionData, ByVal _Products As String) As DataSet




            Dim ds As DataSet

            Try

                Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
                _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("CUSTOMERPOINT_GETPRODUCTDETAILS")
                _InfiniCommand.AddParameter("@merchant_id", connData.CustomerID, System.Data.DbType.UInt32)
                _InfiniCommand.AddParameter("@products", _Products, System.Data.DbType.StringFixedLength)
                Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

            Catch ex As Exception

                System.Web.HttpContext.Current.Trace.Warn(ex.Message)
            End Try

    End Function


End Class
