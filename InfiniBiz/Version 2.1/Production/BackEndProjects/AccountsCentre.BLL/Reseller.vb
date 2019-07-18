Imports System.Data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common

Public Class Reseller
    Public Shared Sub InsertBizAPICredential(ByVal ParentUID As String, ByVal CustomerID As String)
        '---------------Inserting BizAPI Credential---------------Start
        Dim Credential_ResellerID As String = ""
        Dim Credential_Password As String = ""
        Credential_ResellerID = CustomerID
        Credential_Password = ""

        'Credential_Password = GetPassword()
        Dim ParentID As String = (New InfiniLogic.AccountsCentre.BLL.User).GetCustomerID(ParentUID)
        Credential_Password = MarketPlaceService.GetLivePassword(ParentID)

        Dim Key As String = (New InfiniLogic.AccountsCentre.BLL.User).GetLogKey(CustomerID)
        Dim objCryptography As New InfiniLogic.AccountsCentre.common.Cryptography

        Credential_Password = objCryptography.EnCrypt(Credential_Password, Key)
        InfiniLogic.AccountsCentre.BLL.ResellerCustomer.InsertBizAPICredential(Credential_ResellerID, Credential_Password)
    End Sub

    Public Shared Sub BuildResellerService(ByVal IsInfiniShopCustomer As Boolean, _
                                            ByVal CurrencyDBID As String, _
                                            ByVal ResellerID As String, _
                                            ByVal ResellerURL As String, _
                                            ByVal SendEmail As Boolean, _
                                            ByVal GeneratorID As String, _
                                            ByVal OrderID As String)
        Dim sTime As String = Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Dim dirPath As String = "d:\CustomerProcessing Trace\RS\" & sTime

        Try
            Dim ResellerService As New com.reseller.webservices.ResellerService
            Dim rinfo As New com.reseller.webservices.resellerinfo
            Dim Result As com.reseller.webservices.buildresellerresult

            rinfo.isinfinishopcustomer = IsInfiniShopCustomer
            rinfo.currencydbid = CurrencyDBID
            rinfo.resellerid = ResellerID
            rinfo.resellerurl = ResellerURL
            rinfo.sendemail = SendEmail
            rinfo.generatorid = GeneratorID
            rinfo.orderid = OrderID

            ResellerService.Timeout = 1200000 ' 20 min
            WriteDebugInfo("Calling BuildReseller", dirPath)
            WriteDebugInfo("    IsInfiniShopCustomer = " & IsInfiniShopCustomer, dirPath)
            WriteDebugInfo("    CurrencyDBID = " & CurrencyDBID, dirPath)
            WriteDebugInfo("    ResellerID = " & ResellerID, dirPath)
            WriteDebugInfo("    ResellerURL = " & ResellerURL, dirPath)
            WriteDebugInfo("    SendEmail = " & SendEmail, dirPath)
            WriteDebugInfo("    GeneratorID = " & GeneratorID, dirPath)
            WriteDebugInfo("    OrderID = " & OrderID, dirPath)
            Result = ResellerService.buildreseller(rinfo)
            WriteDebugInfo("buildreseller is ok", dirPath)
            WriteDebugInfo("Result.ERRORCODE " & Result.ERRORCODE, dirPath)
            WriteDebugInfo("Result.ERRORDESC " & Result.ERRORDESC, dirPath)
        Catch ex As Exception
            WriteDebugInfo("EXCEPTION", dirPath)
            WriteDebugInfo("Message: " & ex.Message, dirPath)
            WriteDebugInfo("StackTrace: " & ex.StackTrace, dirPath)
        End Try
    End Sub

    Public Shared Function GetProductName(ByVal ResellerUID As String, _
                                            ByVal ProductCode As String) As String
        Dim ProductName As String = ""
        Dim service As New com.infinibiz.webservices.IBZservices
        Dim ResellerProducts As com.infinibiz.webservices.returnResellerProducts
        ResellerProducts = service.getResellerProducts(ResellerUID)

        For Each item As com.infinibiz.webservices.productinfo In ResellerProducts.products
            If item.code = ProductCode Then
                ProductName = item.name
                Exit For
            End If
        Next

        Return ProductName
    End Function

    Public Shared Function GetResellerCurrencyDBID(ByVal PackageCode As String) As Integer
        Dim ResellerCurrencyDBID As Integer = -1
        Dim SQLParam(1) As SqlParameter
        SQLParam(0) = New SqlParameter("@PackageCode", SqlDbType.VarChar, 50)
        SQLParam(0).Value = PackageCode
        SQLParam(1) = New SqlParameter("@ResellerCurrencyDBID", SqlDbType.Int)
        SQLParam(1).Direction = ParameterDirection.Output
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetResellerCurrencyDBID", SQLParam)
        ResellerCurrencyDBID = SQLParam(1).Value
        Return ResellerCurrencyDBID
    End Function

    Private Shared Sub WriteDebugInfo(ByVal sText As String, ByVal dirPath As String)
        Try
            If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
                If Not System.IO.Directory.Exists(dirPath) Then
                    System.IO.Directory.CreateDirectory(dirPath)
                End If
                Dim sw As System.IO.StreamWriter
                sw = System.IO.File.AppendText(dirPath & "\ResellerBuilder Trace.txt")
                sw.WriteLine(Now & " -- " & sText)
                sw.Close()
            End If
        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        End Try
    End Sub
End Class
