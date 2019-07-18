Imports System
Imports System.Data.SqlClient
Imports System.Configuration
Imports InfiniLogic.AccountsCentre.DAL
Public Class Merchant
    Public Shared Function GetALLPaymentProcessor() As DataSet
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetPaymentProcessor", Nothing)
        Return ds
    End Function

    Public Shared Sub UpdateCurrencyInfo_MerchantID(ByVal MerchantID As Integer, _
                                                        ByVal ServiceID As Integer, _
                                                        ByVal CurrencyID As Integer, _
                                                        ByVal CurrencySign As String)
        Dim SQLParam(3) As SqlClient.SqlParameter
        SQLParam(0) = New SqlClient.SqlParameter("@MerchantID", SqlDbType.Int)
        SQLParam(0).Value = MerchantID
        SQLParam(1) = New SqlClient.SqlParameter("@ServiceID", SqlDbType.Int)
        SQLParam(1).Value = ServiceID
        SQLParam(2) = New SqlClient.SqlParameter("@CurrencyID", SqlDbType.Int)
        SQLParam(2).Value = CurrencyID
        SQLParam(3) = New SqlClient.SqlParameter("@CurrencySign", SqlDbType.VarChar, 20)
        SQLParam(3).Value = CurrencySign

        System.Web.HttpContext.Current.Trace.Write("Calling RSS_UpdateCurrencyInfo_MerchantID")
        SqlHelper.ExecuteNonQuery(MerchantID, CommandType.StoredProcedure, "RSS_UpdateCurrencyInfo_MerchantID", SQLParam)
        System.Web.HttpContext.Current.Trace.Write("RSS_UpdateCurrencyInfo_MerchantID is ok")
    End Sub

    Public Shared Function IsInfiniShopAvailable_Package(ByVal PackageCode As String) As Boolean
        Dim SQLParam(1) As SqlClient.SqlParameter
        SQLParam(0) = New SqlClient.SqlParameter("@PackageCode", SqlDbType.VarChar, 50)
        SQLParam(0).Value = PackageCode
        SQLParam(1) = New SqlClient.SqlParameter("@Success", SqlDbType.Bit)
        SQLParam(1).Direction = ParameterDirection.Output
        System.Web.HttpContext.Current.Trace.Write("Calling RSS_IsInfiniShopAvailable_Package")
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_IsInfiniShopAvailable_Package", SQLParam)
        Dim Result As Boolean = SQLParam(1).Value
        System.Web.HttpContext.Current.Trace.Write("RSS_IsInfiniShopAvailable_Package is ok: Result=" & Result)
        Return Result
    End Function
    Public Shared Function IsInfinishopCustomer(ByVal CustomerID As Long) As Boolean
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParam(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParam(0).Value = CustomerID

        Dim rdr As SqlDataReader
        Try
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_IsInfinishopCustomer", sqlParam)

            If rdr.Read Then
                Return True
            Else
                Return False
            End If
        Catch ex As SqlException
            Throw ex
        Finally
            If Not rdr.IsClosed Then rdr.Close()
            If Not rdr Is Nothing Then rdr = Nothing
        End Try
    End Function

    Public Shared Function GetCurrencies(Optional ByVal MajorCurrency As Boolean = True) As DataTable
        Dim SqlParam(0) As SqlClient.SqlParameter
        SqlParam(0) = New SqlClient.SqlParameter("@MajorCurrency", SqlDbType.Bit)
        SqlParam(0).Value = MajorCurrency
        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.dbo.RSS_GetCurrencies", SqlParam).Tables(0)
    End Function

    Public Shared Function GetAccountsProServiceInfo_CurrencyID(ByVal CurrencyID As Integer) As AccountsProServiceInfo_Result
        Dim SqlParam(2) As SqlClient.SqlParameter
        SqlParam(0) = New SqlClient.SqlParameter("@CurrencyID", SqlDbType.Int)
        SqlParam(0).Value = CurrencyID
        SqlParam(1) = New SqlClient.SqlParameter("@AccountsProServiceID", SqlDbType.Int)
        SqlParam(1).Direction = ParameterDirection.Output
        SqlParam(2) = New SqlClient.SqlParameter("@Sign", SqlDbType.NVarChar, 255)
        SqlParam(2).Direction = ParameterDirection.Output

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetAccountsProServiceID_CurrencyID", SqlParam)

        Dim objResult As New AccountsProServiceInfo_Result
        objResult.CurrencyID = CurrencyID
        objResult.ServiceID = SqlParam(1).Value()
        objResult.CurrencySign = SqlParam(2).Value

        Return objResult
    End Function

    Public Structure AccountsProServiceInfo_Result
        Public CurrencyID As Integer
        Public ServiceID As Integer
        Public CurrencySign As String
    End Structure

    Public Shared Function GetALLPaymentProcessor_ID(ByVal PaymentProcessorID As Integer) As DataSet
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParam(0) = New SqlClient.SqlParameter("@PaymentProcessorID", SqlDbType.BigInt)
        sqlParam(0).Value = PaymentProcessorID
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetPaymentProcessor_ID", sqlParam)
        Return ds
    End Function

    Public Shared Function GetALLPaymentProcessor_CurrencyID(ByVal CurrencyID As Integer, ByVal Enabled As Boolean) As DataSet
        Dim sqlParam(1) As SqlClient.SqlParameter
        sqlParam(0) = New SqlClient.SqlParameter("@CurrencyID", SqlDbType.Int)
        sqlParam(0).Value = CurrencyID
        sqlParam(1) = New SqlClient.SqlParameter("@Enabled", SqlDbType.Bit)
        sqlParam(1).Value = Enabled
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetPaymentProcessor_CurrencyID", sqlParam)
        Return ds
    End Function

    'RSS_GetCurrencyInfo_CurrencyID
    Public Shared Function GetCurrencyInfo_CurrencyID(ByVal CurrencyID As Integer) As DataSet
        Dim sqlParam(0) As SqlClient.SqlParameter
        sqlParam(0) = New SqlClient.SqlParameter("@CurrencyID", SqlDbType.Int)
        sqlParam(0).Value = CurrencyID
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_GetCurrencyInfo_CurrencyID", sqlParam)
        Return ds
    End Function

    Public Shared Function AddPaymentProcessor(ByVal MerchantID As String, _
                                            ByVal _PaymentProcessor As PaymentProcessor, _
                                            ByVal PaymentProcessorID As String, _
                                            ByVal PaymentProcessorID2 As String, _
                                            ByVal PaymentProcessorPassword As String, _
                                            ByVal PaymentProcessorCertificate As String, _
                                            ByVal PaymentProcessorCurrencyCode As String) As Boolean
        Dim sqlParam(7) As SqlClient.SqlParameter
        sqlParam(0) = New SqlClient.SqlParameter("@MerchantID", SqlDbType.BigInt)
        sqlParam(0).Value = MerchantID
        sqlParam(1) = New SqlClient.SqlParameter("@PaymentProcessorID", SqlDbType.BigInt)
        sqlParam(1).Value = _PaymentProcessor.PaymentProcessorID
        sqlParam(2) = New SqlClient.SqlParameter("@ID", SqlDbType.NVarChar, 50)
        sqlParam(2).Value = PaymentProcessorID
        sqlParam(3) = New SqlClient.SqlParameter("@ID2", SqlDbType.VarChar, 50)
        sqlParam(3).Value = PaymentProcessorID2
        sqlParam(4) = New SqlClient.SqlParameter("@Password", SqlDbType.NVarChar, 50)
        sqlParam(4).Value = PaymentProcessorPassword
        sqlParam(5) = New SqlClient.SqlParameter("@Certificate", SqlDbType.Text)
        'sqlParam(4).Value = (New System.Text.ASCIIEncoding).GetBytes(PaymentProcessorCertificate)
        sqlParam(5).Value = PaymentProcessorCertificate
        sqlParam(6) = New SqlClient.SqlParameter("@CalledSuccessfully", SqlDbType.Bit)
        sqlParam(6).Direction = ParameterDirection.Output
        sqlParam(7) = New SqlClient.SqlParameter("@PaymentProcessorCurrencyCode", SqlDbType.VarChar, 10)
        sqlParam(7).Value = PaymentProcessorCurrencyCode

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.PaymentProcessor_Add", sqlParam)

        Dim Success As Boolean = sqlParam(6).Value
        Return Success
    End Function

    Public Shared Sub UpdateBankDetail(ByVal MerchantID As String, _
                                    ByVal ChequePayTo As String, _
                                    ByVal ChequeAddress As String, _
                                    ByVal BankName As String, _
                                    ByVal BankAddress As String, _
                                    ByVal BankAccountName As String, _
                                    ByVal BankAccountNumber As String, _
                                    ByVal BankSortCode As String, _
                                    ByVal BIC As String, _
                                    ByVal IBANNum As String, _
                                    ByVal SwiftCode As String)

        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
        sqlParam(0) = New SqlClient.SqlParameter("@merchant_id", SqlDbType.Int)
        sqlParam(0).Value = MerchantID
        sqlParam(1) = New SqlClient.SqlParameter("@chqPayTo", SqlDbType.VarChar, 255)
        sqlParam(1).Value = ChequePayTo
        sqlParam(2) = New SqlClient.SqlParameter("@chqAdd", SqlDbType.VarChar, 255)
        sqlParam(2).Value = ChequeAddress
        sqlParam(3) = New SqlClient.SqlParameter("@bankName", SqlDbType.VarChar, 255)
        sqlParam(3).Value = BankName
        sqlParam(4) = New SqlClient.SqlParameter("@bankAdd", SqlDbType.VarChar, 255)
        sqlParam(4).Value = BankAddress
        sqlParam(5) = New SqlClient.SqlParameter("@bankAccName", SqlDbType.VarChar, 255)
        sqlParam(5).Value = BankAccountName
        sqlParam(6) = New SqlClient.SqlParameter("@bankAccNo", SqlDbType.VarChar, 255)
        sqlParam(6).Value = BankAccountNumber
        sqlParam(7) = New SqlClient.SqlParameter("@bankSortCode", SqlDbType.VarChar, 255)
        sqlParam(7).Value = BankSortCode
        sqlParam(8) = New SqlClient.SqlParameter("@BIC", SqlDbType.VarChar, 255)
        sqlParam(8).Value = BIC
        sqlParam(9) = New SqlClient.SqlParameter("@IBANNum", SqlDbType.VarChar, 255)
        sqlParam(9).Value = IBANNum
        sqlParam(10) = New SqlClient.SqlParameter("@SwiftCode", SqlDbType.VarChar, 255)
        sqlParam(10).Value = SwiftCode
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDb.dbo.RSS_MERCHANT_UPDATE_BANKDETAILS", sqlParam)
    End Sub

    Public Shared Sub AddMerchantForInfiniShops(ByVal ResellerID As Int64, ByVal ResellerURL As String, ByVal templateID As String, ByVal ipAddress As String, ByVal serverPort As String)
        Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
        sqlParam(0) = New SqlClient.SqlParameter("@CustomerID", ResellerID)
        sqlParam(1) = New SqlClient.SqlParameter("@DomainName", ResellerURL)
        sqlParam(2) = New SqlClient.SqlParameter("@TemplateID", templateID)
        sqlParam(3) = New SqlClient.SqlParameter("@ServerIP", ipAddress)
        sqlParam(4) = New SqlClient.SqlParameter("@ServerPort", serverPort)
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfiniShopMainDB.dbo.RSS_Builder_MakeMerchant", sqlParam)
    End Sub


    'Private Shared Function GetNameValuesPair(ByVal FieldsToUpdate As String) As GetNameValuesPairResult
    '    Dim htNameValuePairs As New Hashtable
    '    Dim htACMerchantValuePairs As New Hashtable
    '    Dim htMerchantValuePairs As New Hashtable

    '    'Dim FieldsToUpdate As String = ""
    '    'FieldsToUpdate = "ACMerchant.GeneralAcquirer=STREAMLINE;ACMerchant.AmexAcquirer=AMERICAN EXPRESS;Merchant.ccProcBy=A"
    '    'FieldsToUpdate = "Merchant.ccProcBy=W"
    '    'FieldsToUpdate = "ACMerchant.GeneralAcquirer=PayPal;ACMerchant.AmexAcquirer=PayPal;Merchant.ccProcBy=P"

    '    Dim arrCompleteValues() As String = FieldsToUpdate.Split(New Char() {";"})
    '    Dim arrNameValuePair() As String

    '    For Each sCompleteValue As String In arrCompleteValues
    '        arrNameValuePair = sCompleteValue.Split(New Char() {"="})
    '        htNameValuePairs.Add(arrNameValuePair(0), arrNameValuePair(1))
    '    Next

    '    Dim IEnum As IEnumerator = htNameValuePairs.Keys.GetEnumerator()
    '    While IEnum.MoveNext
    '        If IEnum.Current.ToString.StartsWith("Merchant") Then
    '            htMerchantValuePairs.Add(IEnum.Current.ToString, htNameValuePairs(IEnum.Current.ToString))
    '        ElseIf IEnum.Current.ToString.StartsWith("ACMerchant") Then
    '            htACMerchantValuePairs.Add(IEnum.Current.ToString, htNameValuePairs(IEnum.Current.ToString))
    '        End If
    '    End While

    '    Dim objResult As New GetNameValuesPairResult
    '    objResult.htACMerchantValuePairs = htACMerchantValuePairs
    '    objResult.htMerchantValuePairs = htMerchantValuePairs
    '    Return objResult
    'End Function

    'Private Structure GetNameValuesPairResult
    '    Public htACMerchantValuePairs As Hashtable
    '    Public htMerchantValuePairs As Hashtable
    'End Structure

    Public Shared Function IsTestCustomer(ByVal MerchantID As String) As Boolean
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@ResellerID", SqlDbType.BigInt)
        arParams(0).Value = MerchantID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetResellerInfo", arParams)

        Dim CustomerType As String
        CustomerType = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("CustomerType")), "T", ds.Tables(0).Rows(0).Item("CustomerType"))

        If CustomerType.Trim.ToUpper = "L" Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Shared Function IsTestReseller(ByVal MerchantID As String) As Boolean
        Dim dsACMerchant As DataSet
        dsACMerchant = GetACMerchantInfo(MerchantID)

        Dim GeneralAcquirer As String = ""
        GeneralAcquirer = IIf(IsDBNull(dsACMerchant.Tables(0).Rows(0).Item("GeneralAcquirer")), "TEST ACCOUNT", dsACMerchant.Tables(0).Rows(0).Item("GeneralAcquirer"))
        GeneralAcquirer = GeneralAcquirer.Trim

        Dim ReturnValue As Boolean
        If GeneralAcquirer.ToUpper = "TEST ACCOUNT" Then
            ReturnValue = True
        Else
            ReturnValue = False
        End If

        Return ReturnValue
    End Function

    Public Shared Function GetACMerchantInfo(ByVal MerchantID As String) As DataSet
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@MerchantID", SqlDbType.BigInt)
        arParams(0).Value = MerchantID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetACMerchantInfo", arParams)

        Return ds
    End Function

    Public Shared Function BuildMerchant(ByVal IsInfinishopCustomer As Boolean, _
                                        ByVal CurrencyDBID As String, _
                                        ByVal MerchantID As String, _
                                        ByVal MerchantURL As String, _
                                        ByVal GeneratorID As String, _
                                        ByVal OrderNo As String, _
                                        ByVal SendEmail As Boolean) As BuildMerchantResult
        Dim objMerchantService As New com.reseller.webservices.ResellerService
        Dim objResellerInfo As New com.reseller.webservices.resellerinfo
        Dim objBuildResellerResult As com.reseller.webservices.buildresellerresult
        objResellerInfo.currencydbid = CurrencyDBID
        objResellerInfo.generatorid = GeneratorID
        objResellerInfo.isinfinishopcustomer = IsInfinishopCustomer
        objResellerInfo.orderid = OrderNo
        objResellerInfo.resellerid = MerchantID
        objResellerInfo.resellerurl = MerchantURL
        objResellerInfo.sendemail = SendEmail

        objBuildResellerResult = objMerchantService.CreateWebsiteForMerchant(objResellerInfo)
        Dim Result As New BuildMerchantResult
        Result.ErrorCode = objBuildResellerResult.ERRORCODE
        Result.ErrorDesc = objBuildResellerResult.ERRORDESC

        Return Result
    End Function

    Public Structure BuildMerchantResult
        Public ErrorCode As String
        Public ErrorDesc As String
    End Structure


    Public Shared Function PaymentProcessor_GetSupportedCurrencies(ByVal PaymentProcessorID As String) As DataSet
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@PaymentProcessorID", SqlDbType.BigInt)
        arParams(0).Value = PaymentProcessorID

        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.PaymentProcessor_GetSupportedCurrencies", arParams)
        Return ds
    End Function

    Public Shared Function IsDomainNameAvailable(ByVal DomainName As String) As Boolean
        Dim SqlParam(1) As SqlClient.SqlParameter
        SqlParam(0) = New SqlClient.SqlParameter("@DomainName", SqlDbType.VarChar, 100)
        SqlParam(0).Value = DomainName
        SqlParam(1) = New SqlClient.SqlParameter("@Available", SqlDbType.Bit)
        SqlParam(1).Direction = ParameterDirection.Output

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.dbo.RSS_IsDomainNameAvailable", SqlParam)
        Return SqlParam(1).Value
    End Function

    <Serializable()> _
    Public Structure PaymentProcessor
        Public PaymentProcessorID As Integer
        Public AccountName As String
        Public ID_Required As Boolean
        Public ID2_Required As Boolean
        Public Password_Required As Boolean
        Public Certificate_Required As Boolean
        Public Currency_Required As Boolean

        Public ID_Label As String
        Public ID2_Label As String
        Public Password_Label As String
        Public Certificate_Label As String
        Public Currency_Label As String

        Public ID_RegEx As String
        Public ID2_RegEx As String
        Public Password_RegEx As String
        Public Certificate_RegEx As String
    End Structure
End Class
