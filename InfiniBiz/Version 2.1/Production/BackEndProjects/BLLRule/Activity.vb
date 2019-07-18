Option Explicit On 
Option Strict Off

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.web
 
Public Class Activity

#Region "Order Detail "

    Public Shared Function GetMerchantInfo_MerchantID(ByVal MerchantID As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetMerchantInfo_MerchantID: ")


       


        Dim cmd As New CommandData
        cmd.AddParameter("@MerchantID", MerchantID)
        cmd.CmdText = "DBServer.InfinishopMainDB.dbo.RSS_GetMerchantInfo"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends GetMerchantInfo_MerchantID: ")
            Return _ds


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetMerchantInfo_MerchantID : ")
            Throw ex
        End Try

    End Function

    Public Shared Function GetOrderedProducts(ByVal MerchantID As String, ByVal orderID As String) As DataTable
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderedProducts: ")


      

        Dim ds As DataSet
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        sqlParams(0) = New SqlClient.SqlParameter("@OrderID", SqlDbType.VarChar)
        sqlParams(0).Value = orderID
        sqlParams(1) = New SqlClient.SqlParameter("@MIdentity", SqlDbType.BigInt)
        sqlParams(1).Value = Convert.ToInt32(MerchantID)

        ds = Infinilogic.AccountsCentre.DAL.SqlHelper.ExecuteDataset(Convert.ToInt32(MerchantID), CommandType.StoredProcedure, "CollectionService_Administration_ORDER_GETDETAIL", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("ends GetOrderedProducts: ")
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
            End If



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetOrderedProducts: ")
            Throw ex
        End Try
    End Function

    Public Shared Function GETINVOICEPAYSTATUS(ByVal MerchantID As String, ByVal InvoiceNo As String) As Boolean
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GETINVOICEPAYSTATUS: ")

 

        Dim Cmd As New CommandData(MerchantID)
        Cmd.AddParameter("@MIdentity", MerchantID)
        Cmd.AddParameter("@InvNo", InvoiceNo)
        Cmd.CmdText = "ACCOUNTSPRO_GETINVOICEPAYSTATUS"
        Dim Value As String = CType(Cmd.Execute(ExecutionType.ExecuteScalar), String)
        Cmd.CloseConnection()
            System.Web.HttpContext.Current.Trace.Warn("ends GETINVOICEPAYSTATUS : ")
        If Value = "Y" Then
            Return True
        Else
            Return False
            End If



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GETINVOICEPAYSTATUS  : ")
            Throw ex
        End Try
    End Function

    Public Structure GetPaymentModeResult
        Public PaymentMode As String
        Public Status As String
    End Structure

    Public Shared Function GetPaymentMode(ByVal MerchantID As String, ByVal OrderID As String) As GetPaymentModeResult
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetPaymentMode : ")


    
        Dim SQLParam(3) As SqlClient.SqlParameter
        SQLParam(0) = New SqlClient.SqlParameter("@MerchantID", SqlDbType.Int)
        SQLParam(0).Value = MerchantID
        SQLParam(1) = New SqlClient.SqlParameter("@OrderID", SqlDbType.VarChar, 50)
        SQLParam(1).Value = OrderID

        SQLParam(2) = New SqlClient.SqlParameter("@Payment_Mode", SqlDbType.VarChar, 2)
        SQLParam(2).Direction = ParameterDirection.Output
        SQLParam(3) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar, 1)
        SQLParam(3).Direction = ParameterDirection.Output
        Infinilogic.AccountsCentre.DAL.SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetPaymentMode", SQLParam)

        Dim objResult As New GetPaymentModeResult
        objResult.PaymentMode = IIf(IsDBNull(SQLParam(2).Value), "", SQLParam(2).Value)
        objResult.Status = IIf(IsDBNull(SQLParam(3).Value), "", SQLParam(3).Value)
            System.Web.HttpContext.Current.Trace.Warn("ends GetPaymentMode : ")
            Return objResult



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetPaymentMode : ")
            Throw ex
        End Try
        'RSS_GetPaymentMode
    End Function

    Public Shared Function IsCouponAvailable(ByVal MerchantID As Integer, ByVal OrderID As Integer) As Boolean
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start IsCouponAvailable : ")


       

        Dim SQLParam(2) As SqlClient.SqlParameter
        SQLParam(0) = New SqlClient.SqlParameter("@MerchantID", SqlDbType.Int)
        SQLParam(0).Value = MerchantID
        SQLParam(1) = New SqlClient.SqlParameter("@OrderID", SqlDbType.VarChar, 50)
        SQLParam(1).Value = OrderID
        SQLParam(2) = New SqlClient.SqlParameter("@Status", SqlDbType.Bit)
        SQLParam(2).Direction = ParameterDirection.Output

        Infinilogic.AccountsCentre.DAL.SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "Dbserver.CouponSystem.dbo.Infinishop_GetIsCouponProduct", SQLParam)
            System.Web.HttpContext.Current.Trace.Warn("ends IsCouponAvailable : ")
            Return SQLParam(2).Value



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  IsCouponAvailable : ")
            Throw ex
        End Try



    End Function

    Public Shared Function GetCurrencySign(ByVal MerchantID As String) As String
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetCurrencySign : ")


    
        Dim cmd As New CommandData
        cmd.AddParameter("@customerID", MerchantID)
            cmd.CmdText = "DBServer.InfinishopMainDB.dbo.Acc_GetCurrencySign"
            Dim _sign As String = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows(0).Item(0)
            System.Web.HttpContext.Current.Trace.Warn("ends GetCurrencySign : ")
            Return _sign

         
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetCurrencySign : ")
            Throw ex
        End Try
    End Function

    Public Shared Function GetRequestDetail(ByVal rid As Integer, ByVal mid As Integer) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetRequestDetail : ")


     
        Dim cmd As New CommandData(mid)
        cmd.AddParameter("@rid", rid)


            cmd.CmdText = "CollectionService_Administration_GetRequestDetail"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends GetRequestDetail : ")
            Return _ds


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetRequestDetail  : ")
            Throw ex
        End Try
    End Function

    Public Shared Function GetMerchantLogKeyByRequest(ByVal rid As Integer) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetMerchantLogKeyByRequest : ")


    
        Dim cmd As New CommandData
        cmd.AddParameter("@rid", rid)


        cmd.CmdText = "DBServer.InfinishopMainDB.dbo.CollectionService_Administration_GetMerchantLogKey_ByRequest"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends GetMerchantLogKeyByRequest : ")
            Return _ds


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetMerchantLogKeyByRequest : ")
            Throw ex
        End Try

    End Function


#End Region

    Public Shared Function GetVisitsCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As Integer

        Dim _VisitsCount As Integer
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetVisitsCount : ")

            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@DomainName", DomainName)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetVisitCount"
            _VisitsCount = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows.Count


            System.Web.HttpContext.Current.Trace.Warn("ends GetVisitsCount : ")
            Return _VisitsCount
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetVisitsCount : ")
            Throw ex
        End Try
    End Function
    Public Shared Function GetProductCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As Integer
        Dim _productCount As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start  GetProductCount : ")

      

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DomainName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetProductCount"
        _productCount = CInt(CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows(0).Item(0))



            System.Web.HttpContext.Current.Trace.Warn("ends GetProductCount : ")
            Return _productCount
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetProductCount : ")
            Throw ex
        End Try
    End Function
    Public Shared Function GetOrderCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderCount : ")

     
        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCustomerIDsList"
        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)
            System.Web.HttpContext.Current.Trace.Warn("ends GetOrderCount : ")

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetOrderCount : ")
            Throw ex
        End Try

    End Function
    Public Shared Function PostOrderCount(ByVal connData As ConnectionData, ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start PostOrderCount : ")



     
        Dim cmd As New CommandData(connData.CustomerID)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.AddParameter("@midentity", connData.CustomerID)
            cmd.CmdText = "ActivityAnalyzer_GetOrderCountByCustomerID"
            Dim _count As Integer = CType(cmd.Execute(ExecutionType.ExecuteScalar), Integer)
            System.Web.HttpContext.Current.Trace.Warn("ends PostOrderCount : ")
            Return _count


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception PostOrderCount : ")
            Throw ex
        End Try

    End Function
    Public Shared Function ParentOrderCount(ByVal Mid As Integer, ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start ParentOrderCount : ")



      
        Dim cmd As New CommandData(Mid)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.AddParameter("@midentity", Mid)
        cmd.CmdText = "ActivityAnalyzer_GetOrderCountByCustomerID"
            Dim _count As Integer = CType(cmd.Execute(ExecutionType.ExecuteScalar), Integer)
            System.Web.HttpContext.Current.Trace.Warn("ends ParentOrderCount : ")
            Return _count



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  ParentOrderCount : ")
            Throw ex
        End Try
    End Function
    Public Shared Function GetReferrerCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetReferrerCount : ")



     

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetReferrer"
        Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Dim _count As Integer = CInt(_ds.Tables(0).Rows(0).Item(0))
            System.Web.HttpContext.Current.Trace.Warn("ends GetReferrerCount : ")
            Return _count



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetReferrerCount  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function GetoppertinutyCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetoppertinutyCount : ")



       
        Dim cmd As New CommandData(Customerid)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.AddParameter("@midentity", Customerid)
        cmd.CmdText = "ActivityAnalyzer_GetOppertinuityCount"
        Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Dim _count As Integer = CInt(_ds.Tables(0).Rows(0).Item(0))
            System.Web.HttpContext.Current.Trace.Warn("ends GetoppertinutyCount : ")

            Return _count
       
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetoppertinutyCount : ")
            Throw ex
        End Try

    End Function


    Public Shared Function RenderDataGridforProduct(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforProduct : ")

         

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetProductParentInformation"
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforProduct : ")

            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
           
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  RenderDataGridforProduct : ")
            Throw ex
        End Try

    End Function
    Public Shared Function RenderDataGridforProductOverView(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforProductOverView : ")

     

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetProductParentInformationOverView"
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforProductOverView : ")

            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
         
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforProductOverView  : ")
            Throw ex
        End Try

    End Function

    Public Shared Function RenderDataGridforReferrerOverView(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforReferrerOverView : ")

      

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetReferrerParentInformationOverView"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforReferrerOverView : ")
            Return _ds



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforReferrerOverView  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function DetailReferrerOverView(ByVal ReferrerName As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start DetailReferrerOverView : ")

        

        Dim cmd As New CommandData
        cmd.AddParameter("@ReferrerName", ReferrerName)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_DetailReferrerOverView"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends DetailReferrerOverView : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  DetailReferrerOverView : ")
            Throw ex
        End Try

    End Function

    Public Shared Function RenderDataGridforOrder(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforOrder : ")

   
        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetOrderParentInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforOrder : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforOrder  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function RenderDataGridforVisit(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforVisit : ")

      
        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetVisitParentInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforVisit : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforVisit  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function RenderDataGridforReferrer(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforReferrer : ")

       
        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetReferrerParentInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforReferrer : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforReferrer  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function RenderDataGridforOppertinuty(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforOppertinuty : ")

       
        Dim cmd As New CommandData(Customerid)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@EndDate", EndDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.AddParameter("@midentity ", Customerid)
        cmd.CmdText = "ActivityAnalyzer_GetOppertinuityParentInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforOppertinuty : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforOppertinuty  : ")
            Throw ex
        End Try

    End Function

  
    Public Shared Function RenderDataGridforProductDetail(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforProductDetail : ")


            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@Customerid", Customerid)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetProductChildInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforProductDetail : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforProductDetail  : ")
            Throw ex
        End Try

    End Function
    Public Shared Function RenderDataGridforOrderDetail(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforOrderDetail : ")


            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@Customerid", Customerid)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetOrderChildInformation"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforOrderDetail : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforOrderDetail  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function RenderDataGridforVisitDetail(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("StartRenderDataGridforVisitDetail  : ")


            Dim cmd As New CommandData(_mid)
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@Customerid", Customerid)
            cmd.AddParameter("@midentity", _mid)
            cmd.CmdText = "ActivityAnalyzer_GetOrderChildInformationDetail"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforVisitDetail : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforVisitDetail : ")
            Throw ex
        End Try

    End Function
    Public Shared Function RenderDataGridforReferrerDetail(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforReferrerDetail : ")



            Dim cmd As New CommandData(_mid)
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@Customerid", Customerid)
            cmd.AddParameter("@midentity", _mid)
            cmd.CmdText = "ActivityAnalyzer_GetOrderChildInformationDetail"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforReferrerDetail : ")
            Return _ds
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  RenderDataGridforReferrerDetail: ")
            Throw ex
        End Try

    End Function
    Public Shared Function RenderDataGridforReferrerDetailbySid(ByVal Sid As String, ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforReferrerDetailbySid : ")



            Dim cmd As New CommandData(_mid)
            cmd.AddParameter("@Sid", Sid)
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@Customerid", Customerid)
            cmd.AddParameter("@midentity", _mid)
            cmd.CmdText = "ActivityAnalyzer_GetOrderChildInformationDetailbySid"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforReferrerDetailbySid : ")
            Return _ds
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  RenderDataGridforReferrerDetailbySid : ")
            Throw ex
        End Try

    End Function
    Public Shared Function GetProductDetails(ByVal CustomerID As Integer, ByVal _Products As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetProductDetails : ")


            Dim ds As DataSet


            Dim cmd As New CommandData(CustomerID)
            cmd.CmdText = "ActivityAnalyzer_GETPRODUCTDETAILS"
            cmd.AddParameter("@merchant_id", CustomerID)
            cmd.AddParameter("@products", _Products)
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends GetProductDetails : ")
            Return _ds
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetProductDetails : ")
            Throw ex
        End Try

    End Function

    Public Shared Function GetOrderCountbyMID(ByVal StartDate As String, ByVal EndDate As String, ByVal Customerid As Integer, ByVal MID As Integer) As Integer
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderCountbyMID : ")



            Dim ds As DataSet




            Dim cmd As New CommandData(MID)
            cmd.CmdText = "ActivityAnalyzer_GetOrderCountByCustomerID"
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@CustomerId", Customerid)
            cmd.AddParameter("@midentity", MID)

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            System.Web.HttpContext.Current.Trace.Warn("End GetOrderCountbyMID : ")
            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetOrderCountbyMID : ")
            Throw ex
        End Try

    End Function
    Public Shared Function GetOrderCountbyMIDSession(ByVal StartDate As String, ByVal EndDate As String, ByVal SessionID As String, ByVal Customerid As Integer, ByVal MID As Integer) As Integer
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderCountbyMIDSession : ")




            Dim ds As DataSet




            Dim cmd As New CommandData(MID)
            cmd.CmdText = "ActivityAnalyzer_GetOrderCountBySession_CustomerID"
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@SessionID", SessionID)
            cmd.AddParameter("@CustomerId", Customerid)
            cmd.AddParameter("@midentity", MID)

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("End GetOrderCountbyMIDSession : ")

            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetOrderCountbyMIDSession : ")
            Throw ex
        End Try

    End Function


    Public Shared Function GetOrderCountbyProductID(ByVal StartDate As String, ByVal EndDate As String, ByVal ProductID As String, ByVal Customerid As Integer) As Integer
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderCountbyProductID : ")



            Dim ds As DataSet




            Dim cmd As New CommandData(Customerid)
            cmd.CmdText = "ActivityAnalyzer_GetOrderCountbyProductID"
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@ProductID", ProductID)
            cmd.AddParameter("@midentity", Customerid)

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            System.Web.HttpContext.Current.Trace.Warn("end GetOrderCountbyProductID : ")
            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetOrderCountbyProductID : ")
            Throw ex
        End Try

    End Function
    Public Shared Function GetCustomerOrderDetail(ByVal Mid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal _CustomerIDs As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetCustomerOrderDetail : ")




            Dim ds As DataSet




            Dim cmd As New CommandData(Mid)
            cmd.CmdText = "ActivityAnalyzer_GetCustomerOrderDetail"
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@CustomerID", _CustomerIDs)
            cmd.AddParameter("@midentity", Mid)
            System.Web.HttpContext.Current.Trace.Warn("end GetCustomerOrderDetail : ")
            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)



        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception GetCustomerOrderDetail  : ")
            Throw ex
        End Try

    End Function
    Public Shared Function MerchantInformation(ByVal Customerid As Integer) As DataTable

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start MerchantInformation : ")




            Dim cmd As New CommandData
            cmd.AddParameter("@CustomerId", Customerid)
            cmd.CmdText = "DBSERVER.InfiniShopMainDB.DBO.ActivityAnalyzer_GetDomainNameByCustomerID"

            Dim _dt As DataTable = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)
            System.Web.HttpContext.Current.Trace.Warn("ends MerchantInformation : ")
            Return _dt
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception MerchantInformation  : ")
            Throw ex
        End Try
    End Function

    Public Shared Function AnalyzeCurrentSessions(ByVal connData As ConnectionData, ByVal _DomainName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start AnalyzeCurrentSessions : ")




            Dim ds As DataSet



            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCurrentSessions")
            _InfiniCommand.AddParameter("@DomainName", _DomainName, System.Data.DbType.StringFixedLength)
            Dim _ds As DataSet = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            System.Web.HttpContext.Current.Trace.Warn("end AnalyzeCurrentSessions : ")
            Return _ds


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception AnalyzeCurrentSessions : ")
            Throw ex
        End Try

    End Function
    Public Shared Function GetOrderInfo(ByVal MerchantID As String, ByVal orderID As String) As DataRow
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderInfo : ")



            Dim ds As DataSet
            Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            sqlParams(0) = New SqlClient.SqlParameter("@OrderID", SqlDbType.VarChar)
            sqlParams(0).Value = orderID
            sqlParams(1) = New SqlClient.SqlParameter("@MIdentity", SqlDbType.BigInt)
            sqlParams(1).Value = Convert.ToInt32(MerchantID)
            ds = Infinilogic.AccountsCentre.DAL.SqlHelper.ExecuteDataset(Convert.ToInt32(MerchantID), CommandType.StoredProcedure, "CollectionService_Administration_ORDER_GET", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("ends GetOrderInfo : ")
            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                Return ds.Tables(0).Rows(0)
            Else
                HttpContext.Current.Trace.Warn("Record not found")
                Return Nothing
            End If


        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetOrderInfo: ")
            Throw ex
        End Try
    End Function

    Public Shared Function GetCountrylist(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal _stage As Integer) As DataSet
        Dim _ds As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetCountrylist : ")




            Select Case _stage
                Case 1

                Case 2
                    Dim cmd As New CommandData
                    cmd.AddParameter("@StartDate", StartDate)
                    cmd.AddParameter("@EndDate", EndDate)
                    cmd.AddParameter("@DomainName", DomainName)
                    cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCountrylistforOrder"
                    _ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                Case 3
                    Dim cmd As New CommandData
                    cmd.AddParameter("@StartDate", StartDate)
                    cmd.AddParameter("@EndDate", EndDate)
                    cmd.AddParameter("@DomainName", DomainName)
                    cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCountrylistforVisits"
                    _ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                Case 4
                Case 5
                    Dim cmd As New CommandData
                    cmd.AddParameter("@StartDate", StartDate)
                    cmd.AddParameter("@EndDate", EndDate)
                    cmd.AddParameter("@DomainName", DomainName)
                    cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCountrylistforOppartunity"
                    _ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                Case 6
                    Dim cmd As New CommandData
                    cmd.AddParameter("@StartDate", StartDate)
                    cmd.AddParameter("@EndDate", EndDate)
                    cmd.AddParameter("@DomainName", DomainName)
                    cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCountrylistforReferrer"
                    _ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            End Select



            System.Web.HttpContext.Current.Trace.Warn("ends GetCountrylist : ")
            Return _ds
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetCountrylist : " & ex.Message)
            Throw ex
        End Try
    End Function

    Public Shared Function RenderDataGridforOppertinutyByCountry(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforOppertinutyByCountry : ")


            Dim cmd As New CommandData(Customerid)
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@DomainName", DoaminName)
            cmd.AddParameter("@CountryName", CountryName)
            cmd.AddParameter("@midentity ", Customerid)
            cmd.CmdText = "ActivityAnalyzer_GetOppertinuityParentInformationbyCountry"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforOppertinutyByCountry : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforOppertinutyByCountry  : ")
            Throw ex
        End Try

    End Function

    Public Shared Function GetOrderCountByCountry(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start GetOrderCountByCountry : ")


            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@DomainName", DoaminName)
            cmd.AddParameter("@CountryName", CountryName)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetCustomerIDsListByCountry"
            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)
            System.Web.HttpContext.Current.Trace.Warn("ends GetOrderCountByCountry : ")

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  GetOrderCountByCountry : ")
            Throw ex
        End Try

    End Function
    Public Shared Function RenderDataGridforVisitByCountry(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforVisitByCountry : ")


            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@DomainName", DoaminName)
            cmd.AddParameter("@CountryName", CountryName)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetVisitParentInformationByCountry"
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforVisitByCountry : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforVisitByCountry  : ")
            Throw ex
        End Try
    End Function
    Public Shared Function RenderDataGridforReferrerByCountry(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataSet
        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforReferrerByCountry : ")


            Dim cmd As New CommandData
            cmd.AddParameter("@StartDate", StartDate)
            cmd.AddParameter("@EndDate", EndDate)
            cmd.AddParameter("@DomainName", DoaminName)
            cmd.AddParameter("@CountryName", CountryName)
            cmd.CmdText = "DBSERVER.TRACKER.DBO.ActivityAnalyzer_GetReferrerParentInformationbyCountry "
            Dim _ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforReferrerByCountry : ")
            Return _ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception RenderDataGridforReferrerByCountry  : ")
            Throw ex
        End Try
    End Function


    Public Shared Function RenderDataGridforProductCategory(ByVal Customerid As Integer, ByVal ProductID As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforProductCategory : ")



            Dim cmd As New CommandData(Customerid)


            cmd.AddParameter("@Midentity", Customerid)
            cmd.AddParameter("@products", ProductID)
            cmd.CmdText = "CategoryAnalyzer_GetProductCategory"
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforProductCategory : ")

            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  RenderDataGridforProductCategory : ")
            Throw ex
        End Try

    End Function

    Public Shared Function RenderDataGridforProductCategoryChild(ByVal Customerid As Integer, ByVal _categoryName As String, ByVal ProductID As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Start RenderDataGridforProductCategoryChild : ")



            Dim cmd As New CommandData(Customerid)


            cmd.AddParameter("@Midentity", Customerid)
            cmd.AddParameter("@products", ProductID)
            cmd.AddParameter("@Category", _categoryName)
            cmd.CmdText = "CategoryAnalyzer_GetProductCategoryDetail"
            System.Web.HttpContext.Current.Trace.Warn("ends RenderDataGridforProductCategoryChild : ")

            Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception  RenderDataGridforProductCategoryChild : ")
            Throw ex
        End Try

    End Function

End Class
