Imports System
Imports System.Data.SqlClient
Imports System.Configuration
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common
Imports System.IO

Public Class User

    Public _strDatabaseName As String

    Public Shared Function GetAllCurrencyDBDetail() As DataSet
        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.RSS_GetAllCurrencyDBDetail", Nothing)
    End Function

    Public Enum OrderTypeEnum
        _New
        _Renew
        _Upgrade
    End Enum
    'Public _intNumberofEmployees As Integer
    'Public _dblGrossPay As Double
    'Public _dblDeduction As Double
    'Public _dblNetPaytodate As Double
    'Public _dblAllowances As Double
    Public Sub New()
        ' Retrieve the default database 'InfiniShopMainDB' connection string 
        'SqlHelper.ConnectionString = Connection.GetConnectionString()
    End Sub 'New   

    Public ReadOnly Property Status() As Boolean
        Get
            Return True
        End Get
    End Property


    Public Function HasResellerPackage(ByVal CustomerID As Int64) As Boolean
        Dim blnReturn As Boolean = False
        With New CommandData
            .AddParameter("@CustomerId", CustomerID)
            .CmdText = "DBServer.InfiniShopMainDB.dbo.ACC_HasResellerPackage"
            blnReturn = .Execute(ExecutionType.ExecuteScalar)
        End With
        Return blnReturn
    End Function

    Public Function LoadAccountscetreUser(ByVal userID As String, Optional ByVal strCompName As String = "Your Company Name", Optional ByVal strCompNumber As String = "") As Object
        Dim blnStatus As Boolean
        Dim valueReturns As New Collection
        Dim arParams() As SqlParameter = New SqlParameter(6) {}
        arParams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 50)
        arParams(0).Value = userID
        arParams(1) = New SqlParameter("@CompanyName", SqlDbType.VarChar, 250)
        arParams(1).Value = strCompName
        arParams(2) = New SqlParameter("@companynumber", SqlDbType.VarChar, 256)
        arParams(2).Value = strCompNumber
        arParams(3) = New SqlParameter("@name", SqlDbType.VarChar, 200)
        arParams(3).Direction = ParameterDirection.Output
        arParams(4) = New SqlParameter("@email", SqlDbType.VarChar, 200)
        arParams(4).Direction = ParameterDirection.Output
        arParams(5) = New SqlParameter("@msgperpage", SqlDbType.Int)
        arParams(5).Direction = ParameterDirection.Output
        arParams(6) = New SqlParameter("@ret", SqlDbType.Int)
        arParams(6).Direction = ParameterDirection.Output
        blnStatus = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.AC_GetAccountscentreUser", arParams)

        If blnStatus = True Then
            valueReturns.Add(arParams(3).Value, "name")
            valueReturns.Add(arParams(4).Value, "email")
            valueReturns.Add(arParams(5).Value, "msgperpage")

            If Val(arParams(6).Value) = 1 Then
                'MessageBoard.PostInboxMessage(userID, 100, "Accounts Centre", "New User Logged In", "New User Logged in at" & Date.Now.ToString)
            End If

            LoadAccountscetreUser = valueReturns
        End If
        valueReturns = Nothing

    End Function

    Public Shared Function ACC_PackageProductDetails(ByVal intPackageOptions As PackageOptions, _
                                              ByVal intServiceOptions As ServiceOptions) As DataSet

        Dim arParams() As SqlParameter = New SqlParameter(1) {}

        arParams(0) = New SqlParameter("@intPackageOptions", intPackageOptions)
        arParams(1) = New SqlParameter("@intServiceOptions", intServiceOptions)

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_PackagesDetail", arParams)


    End Function

    Public Shared Function ACC_GetProductsToSale() As DataSet
        Return ACC_PackageProductDetails(PackageOptions.EnableSale, ServiceOptions.EnableSale)
    End Function

    Public Function ACC_UpdatePackageProductDetails(ByVal intEmployerID As Int32, _
                                                    ByVal intPackageOptions As Int64, _
                                                    ByVal intServiceOptions As Int64) As DataSet

        Dim arParams() As SqlParameter = New SqlParameter(2) {}

        arParams(0) = New SqlParameter("@CustomerID", intEmployerID)
        arParams(1) = New SqlParameter("@intPackageOptions", intPackageOptions)
        arParams(2) = New SqlParameter("@intServiceOptions", intServiceOptions)

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_UpdatePackagesDetail", arParams)


    End Function

    Public Function ACC_VerifySelectedPackages(ByVal strPackagesCode As String) As SqlDataReader

        Dim arParams() As SqlParameter = New SqlParameter(0) {}

        arParams(0) = New SqlParameter("@strPackagesCode", SqlDbType.VarChar, 1000)
        arParams(0).Value = strPackagesCode.ToString

        Return SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_VerifySelectedPackages", arParams)


    End Function

    Public Function ACC_VerifyDownloadAllowed(ByVal intDownloadAble As ServiceOptions, _
                                            ByVal intDesktopApplication As ACC_ServiceOptions, _
                                            ByVal intServiceID As ServiceID) As Boolean

        Dim arParams() As SqlParameter = New SqlParameter(2) {}
        Dim dbReader As SqlDataReader
        arParams(0) = New SqlParameter("@PackageOptions", intDesktopApplication)
        arParams(1) = New SqlParameter("@ServiceOptions", intDownloadAble)
        arParams(2) = New SqlParameter("@intServiceID", intServiceID)
        Dim blnResult As Boolean = False

        Try
            dbReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_VerifyDownloadAllowed", arParams)
            blnResult = dbReader.Read()
            'If dbReader.HasRows Then

            '    Return Not IsDBNull(dbReader.Item(0))

            'End If
        Finally
            If Not dbReader.IsClosed Then dbReader.Close()
        End Try

        Return (blnResult)
    End Function

    Public Function VerifySignIn(ByVal userID As String, ByRef password As String, ByRef employerID As Int32, _
                                                    ByRef logKey As String, ByRef returnValue As Int16, ByRef databaseName As String, _
                                                    ByRef status As Boolean) As Boolean
        '**********************************
        Dim objPageBase As New AccountsCentre.BLL.PageBase
        '**********************************

        System.Web.HttpContext.Current.Trace.Warn("------------Start Verify SignIn-------------")
        Dim blnStatus As Boolean
        Dim arParams() As SqlParameter = New SqlParameter(5) {}

        arParams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 255)
        arParams(0).Value = userID
        System.Web.HttpContext.Current.Trace.Warn("userID-->" & userID)

        arParams(1) = New SqlParameter("@Password", SqlDbType.VarChar, 255)
        arParams(1).Direction = ParameterDirection.Output

        arParams(2) = New SqlParameter("@CustomerID", SqlDbType.Int)
        arParams(2).Direction = ParameterDirection.Output

        arParams(3) = New SqlParameter("@LogKey", SqlDbType.NVarChar, 1500)
        arParams(3).Direction = ParameterDirection.Output

        arParams(4) = New SqlParameter("@RET", SqlDbType.Char, 1)
        arParams(4).Direction = ParameterDirection.Output

        arParams(5) = New SqlParameter("@DBName", SqlDbType.VarChar, 10)
        arParams(5).Direction = ParameterDirection.Output

        'arParams(6) = New SqlParameter("@DataSource", SqlDbType.VarChar, 50)
        'arParams(6).Direction = ParameterDirection.Output
        ' SqlHelper.ConnectionString = Connection.GetConnectionString()
        System.Web.HttpContext.Current.Trace.Warn("calling [DBSERVER].[InfinishopMainDB].[DBO].[AC_VerifySignIn]")
        blnStatus = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "[DBSERVER].[InfinishopMainDB].[DBO].[AC_VerifySignIn]", arParams)
        status = blnStatus
        System.Web.HttpContext.Current.Trace.Warn("blnStatus-->" & blnStatus)
        If blnStatus = True Then

            Dim arReturnParams() As String = New String(4) {}
            arReturnParams(0) = arParams(1).Value.ToString
            arReturnParams(1) = Convert.ToInt32(arParams(2).Value)
            arReturnParams(2) = arParams(3).Value.ToString
            arReturnParams(3) = arParams(4).Value
            arReturnParams(4) = arParams(5).Value.ToString
            'arReturnParams(5) = arParams(6).Value.ToString

            password = arReturnParams(0)
            employerID = arReturnParams(1)
            logKey = arReturnParams(2)
            returnValue = Val(arReturnParams(3))
            databaseName = arReturnParams(4)
            'dataSource = arReturnParams(5)

            VerifySignIn = True
            System.Web.HttpContext.Current.Trace.Warn("VerifySignIn--> " & VerifySignIn)
        Else

            VerifySignIn = False
            System.Web.HttpContext.Current.Trace.Warn("VerifySignIn--> " & VerifySignIn)

        End If
        System.Web.HttpContext.Current.Trace.Warn("VerifySignIn End")
    End Function


    Public Function VerifyEmployerRegistration(ByVal employerID As Integer, ByRef returnValue As Int16) As Boolean

        Dim blnStatus As Boolean

        Dim arParams() As SqlParameter = New SqlParameter(1) {}


        arParams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 200)
        arParams(0).Value = employerID

        arParams(1) = New SqlParameter("RETURN_VALUE", SqlDbType.Int)
        arParams(1).Direction = ParameterDirection.ReturnValue


        blnStatus = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "[DBSERVER].[InfinishopMainDB].[DBO].[PAY_VerfiyEmployerRegistration]", arParams)

        If blnStatus = True Then

            Dim arReturnParams() As String = New String(1) {}

            arReturnParams(0) = Convert.ToInt32(arParams(1).Value.ToString)
            returnValue = arReturnParams(0)

            VerifyEmployerRegistration = True

        Else

            VerifyEmployerRegistration = False

        End If


    End Function

    Public Function SendEMail(ByVal strTo As String, ByVal strFrom As String, ByVal strSubject As String, ByVal strBody As String) As Boolean

        Dim Mail

        Try
            Mail = CreateObject("CDONTS.NewMail")

            Call Mail.Send(strFrom, strTo, strSubject, strBody)
            SendEMail = True
        Catch
            SendEMail = False
            Exit Function

        Finally
            ' SendEMail = True
        End Try

    End Function

    Public Function ForgotPassword(ByVal email As String, ByVal CustomerName As String) As DataSet

        Dim blnStatus As Boolean
        Dim ds As New DataSet

        Dim arParams() As SqlParameter = New SqlParameter(2) {}


        arParams(0) = New SqlParameter("@email", SqlDbType.VarChar, 255)
        arParams(0).Value = email

        arParams(1) = New SqlParameter("@CustomerName", SqlDbType.VarChar, 255)
        arParams(1).Value = CustomerName

        arParams(2) = New SqlParameter("@RETVALUE", SqlDbType.Int)
        arParams(2).Direction = ParameterDirection.Output

        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "[DBSERVER].[InfinishopMainDB].[DBO].[PAY_ForgotPassword_Dataset]", arParams)

        If Not (ds.Tables(0).Rows.Count < 1) Then ' if dataset is not empty

            ForgotPassword = ds
        Else
            ForgotPassword = Nothing

        End If

    End Function



    ''/*****************************************************************/
    '' BELOW ARE THE METHODS FOR ACCOUNTS CENTRE REGISTRATION PROCESS
    ''/*****************************************************************/

    'Public Function GetCountryCode(ByVal countryName As String) As String

    '    Dim strCountryCode As String

    '    strCountryCode = SqlHelper.ExecuteScalar(0, "DBSERVER.InfinishopMainDB.DBO.PAY_GetCountryCode", countryName)

    '    Return strCountryCode

    'End Function

    Public Shared Function GetCountryName() As DataSet

        Return SqlHelper.ExecuteDataset(0, "DBSERVER.InfinishopMainDB.DBO.PAY_CountryName")

    End Function

    ' SYNOPSIS : It will be used to get Formation House ID
    ' INPUT :    Formation House name stored in Merchant table.
    ' RETURN :   Formation House ID 
    '---------------------------------------------------------------------------------
    Public Function GetDatabaseName(ByVal storeName As String) As String

        Dim strDBName As String
        Dim mMsg As Boolean
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        strDBName = Convert.ToString(0, SqlHelper.ExecuteScalar("DBSERVER.InfinishopMainDB.DBO.PAY_GetDatabaseName", storeName))
        GetDatabaseName = strDBName
        _strDatabaseName = GetDatabaseName

    End Function

    Public Function AddCustomer(ByRef employerID As Int32, ByVal pAC As String, ByVal pSurName As String, _
                                ByVal pFirstName As String, ByVal pSecondName As String, ByVal pStreet As String, _
                                ByVal pTown As String, ByVal pCcode As String, ByVal pCountry As String, _
                                ByVal pPostCode As String, ByVal pContName As String, ByVal pPh As String, _
                                ByVal pFax As String, ByVal pEmail As String, ByVal pNotes As String, _
                                ByVal pUID As String, ByVal pPW As String, ByVal pState As String, _
                                ByVal pVTime As DateTime, ByVal pFNew As String, ByVal pFModified As String, _
                                ByVal pStoreName As String, ByVal pMerchantID As Long, ByVal pGKey As String, _
                                ByVal pCiphertext As String, ByVal pRndVal As Integer, ByVal pOrderNo As String, _
                                ByVal pDeliveryAdd As String, ByVal pCustTel As String, ByVal pDiscount As Double, _
                                ByVal pFShipped As String, ByVal pOrderDate As DateTime, ByVal pPromiseDate As DateTime, _
                                ByVal pCardType As String, ByVal pCardNo As String, ByVal pCardName As String, _
                                ByVal pCardExpires As String, ByVal pCardAddress As String, ByVal pCustomerAddress As String, _
                                ByVal pOrderAmount As Double, ByVal pStartDate As String, ByVal pEndDate As String, _
                                ByVal pSecurityCode As String, ByVal pIssueNo As String, ByVal pPayProcessBy As String, _
                                ByVal pBankName As String, ByVal pChequeNo As String, ByVal pSortCode As String, _
                                ByVal pBankTranRefNo As String, ByVal pWintiprocess As String, ByVal pProductCodes As String, _
                                ByVal intParentCustomerID As Integer, Optional ByVal bitAsExculded As Boolean = False, Optional ByVal pCampaign As String = "WEB") As Boolean

        Dim intStatus As Integer
        Dim arParams() As SqlParameter = New SqlParameter(53) {}

        '    '** INSERTING THE INPUT PARAMETERS IN THE ARRAY 
        '    '** THAT WILL BE USED IN STORED PROCEDURE

        arParams(0) = New SqlParameter("@ac", SqlDbType.VarChar, 50)
        arParams(0).Value = pAC

        arParams(1) = New SqlParameter("@surname", SqlDbType.VarChar, 50)
        arParams(1).Value = pSurName

        'arParams(2) = New SqlParameter("@firstname", SqlDbType.VarChar, 100)
        arParams(2) = New SqlParameter("@firstname", SqlDbType.VarChar, 255) ' 255 = Length(SurName) + Lenght (FirstName) + Length(LastName)
        arParams(2).Value = pFirstName

        arParams(3) = New SqlParameter("@secondname", SqlDbType.VarChar, 100)
        arParams(3).Value = pSecondName

        arParams(4) = New SqlParameter("@street", SqlDbType.VarChar, 60)
        arParams(4).Value = pStreet

        arParams(5) = New SqlParameter("@town", SqlDbType.VarChar, 30)
        arParams(5).Value = pTown

        arParams(6) = New SqlParameter("@ccode", SqlDbType.VarChar, 3)
        arParams(6).Value = pCcode

        arParams(7) = New SqlParameter("@country", SqlDbType.VarChar, 255)
        arParams(7).Value = pCountry

        arParams(8) = New SqlParameter("@postcode", SqlDbType.VarChar, 30)
        arParams(8).Value = pPostCode

        arParams(9) = New SqlParameter("@cont_name", SqlDbType.VarChar, 255)
        arParams(9).Value = pContName

        arParams(10) = New SqlParameter("@telephone", SqlDbType.NVarChar, 80)
        arParams(10).Value = pPh

        arParams(11) = New SqlParameter("@fax", SqlDbType.NVarChar, 80)
        arParams(11).Value = pFax

        arParams(12) = New SqlParameter("@cart_customer_email", SqlDbType.VarChar, 255)
        arParams(12).Value = pEmail

        arParams(13) = New SqlParameter("@cart_customer_notes", SqlDbType.VarChar, 8000)
        arParams(13).Value = pNotes


        arParams(14) = New SqlParameter("@cart_customer_uid", SqlDbType.VarChar, 255) ' not required
        arParams(14).Value = pUID

        arParams(15) = New SqlParameter("@cart_customer_pass", SqlDbType.VarChar, 255) ' not required
        arParams(15).Value = pPW

        arParams(16) = New SqlParameter("@cart_customer_state", SqlDbType.VarChar, 255)
        arParams(16).Value = pState

        arParams(17) = New SqlParameter("@vtime", SqlDbType.DateTime) ' not required
        arParams(17).Value = pVTime

        arParams(18) = New SqlParameter("@fnew", SqlDbType.VarChar, 1) ' not required
        arParams(18).Value = pFNew

        arParams(19) = New SqlParameter("@fmodified", SqlDbType.VarChar, 1) ' not required
        arParams(19).Value = pFModified

        arParams(20) = New SqlParameter("@storename", SqlDbType.VarChar, 50) ' not required
        arParams(20).Value = pStoreName

        arParams(21) = New SqlParameter("@MerchantID", SqlDbType.Int) ' not required
        arParams(21).Value = pMerchantID

        arParams(22) = New SqlParameter("@GKey", SqlDbType.NVarChar, 1500)
        arParams(22).Value = pGKey

        arParams(23) = New SqlParameter("@CipherText", SqlDbType.VarChar, 8000)
        arParams(23).Value = pCiphertext

        arParams(24) = New SqlParameter("@RandomValue", SqlDbType.Int)
        arParams(24).Value = pRndVal

        arParams(25) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(25).Direction = ParameterDirection.Output

        arParams(26) = New SqlParameter("@order_no", SqlDbType.VarChar, 50)
        arParams(26).Value = pOrderNo

        arParams(27) = New SqlParameter("@del_add", SqlDbType.VarChar, 150)
        arParams(27).Value = pDeliveryAdd

        arParams(28) = New SqlParameter("@cust_tel", SqlDbType.VarChar, 20)
        arParams(28).Value = pCustTel

        arParams(29) = New SqlParameter("@discount", SqlDbType.Money)
        arParams(29).Value = pDiscount

        arParams(30) = New SqlParameter("@fshipped", SqlDbType.VarChar, 1)
        arParams(30).Value = pFShipped

        arParams(31) = New SqlParameter("@cart_invoice_orderdate", SqlDbType.DateTime)
        arParams(31).Value = pOrderDate

        arParams(32) = New SqlParameter("@cart_invoice_promiseshipdate", SqlDbType.DateTime)
        arParams(32).Value = pPromiseDate

        arParams(33) = New SqlParameter("@cart_invoice_cardtype", SqlDbType.VarChar, 255)
        arParams(33).Value = pCardType

        arParams(34) = New SqlParameter("@cart_invoice_cardno", SqlDbType.VarChar, 255)
        arParams(34).Value = pCardNo

        arParams(35) = New SqlParameter("@cart_invoice_cardname", SqlDbType.VarChar, 255)
        arParams(35).Value = pCardName

        arParams(36) = New SqlParameter("@cart_invoice_cardexpires", SqlDbType.VarChar, 10)
        arParams(36).Value = pCardExpires

        arParams(37) = New SqlParameter("@cart_invoice_cardaddress", SqlDbType.VarChar, 255)
        arParams(37).Value = pCardAddress

        arParams(38) = New SqlParameter("@cart_invoice_customeraddress", SqlDbType.VarChar, 255)
        arParams(38).Value = pCustomerAddress

        arParams(39) = New SqlParameter("@cart_invoice_orderamount", SqlDbType.Money)
        arParams(39).Value = pOrderAmount

        arParams(40) = New SqlParameter("@start_date", SqlDbType.VarChar, 10)
        arParams(40).Value = pStartDate

        arParams(41) = New SqlParameter("@end_date", SqlDbType.VarChar, 10)
        arParams(41).Value = pEndDate

        arParams(42) = New SqlParameter("@security_code", SqlDbType.VarChar, 10)
        arParams(42).Value = IIf((pSecurityCode Is Nothing) OrElse pSecurityCode = "", "", pSecurityCode)

        arParams(43) = New SqlParameter("@issue_no", SqlDbType.VarChar, 2)
        arParams(43).Value = pIssueNo

        arParams(44) = New SqlParameter("@PayProcessBy", SqlDbType.NVarChar, 2)
        arParams(44).Value = pPayProcessBy

        arParams(45) = New SqlParameter("@BankName", SqlDbType.NVarChar, 50)
        arParams(45).Value = pBankName

        arParams(46) = New SqlParameter("@ChequeNo", SqlDbType.NVarChar, 10)
        arParams(46).Value = pChequeNo

        arParams(47) = New SqlParameter("@SortCode", SqlDbType.NVarChar, 10)
        arParams(47).Value = pSortCode

        arParams(48) = New SqlParameter("@BankTrRefNo", SqlDbType.NVarChar, 10)
        arParams(48).Value = pBankTranRefNo

        arParams(49) = New SqlParameter("@wintiprocess", SqlDbType.NVarChar, 1)
        arParams(49).Value = pWintiprocess

        arParams(50) = New SqlParameter("@ProductCodes", SqlDbType.NVarChar, 1000)
        arParams(50).Value = pProductCodes

        arParams(51) = New SqlParameter("@ParentCustomerID", SqlDbType.BigInt)
        arParams(51).Value = intParentCustomerID

        arParams(52) = New SqlParameter("@AsExcluded", SqlDbType.Bit)
        arParams(52).Value = bitAsExculded

        arParams(53) = New SqlParameter("@Campaign", SqlDbType.VarChar, 5)
        arParams(53).Value = pCampaign

        intStatus = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.PAY_AddEmployer", arParams)

        Dim arReturnParams() As String = New String(49) {}
        arReturnParams(0) = arParams(25).Value.ToString

        ' set the employerID reference to the outupt parameter of AddCustomer sp.
        employerID = arReturnParams(0)

        Return employerID

    End Function


    'function Added after integration with CXcel CollectionService WebService
    'Replacement of AddCustomer()


    'Public Function AddCustomer(ByRef employerID As Int32, ByVal pAC As String, ByVal pSurName As String, _
    '                              ByVal pFirstName As String, ByVal pSecondName As String, ByVal pStreet As String, _
    '                              ByVal pTown As String, ByVal pCcode As String, ByVal pCountry As String, _
    '                              ByVal pPostCode As String, ByVal pContName As String, ByVal pPh As String, _
    '                              ByVal pFax As String, ByVal pEmail As String, ByVal pNotes As String, _
    '                              ByVal pUID As String, ByVal pPW As String, ByVal pState As String, _
    '                              ByVal pVTime As DateTime, ByVal pFNew As String, ByVal pFModified As String, _
    '                              ByVal pStoreName As String, ByVal pMerchantID As Long, ByVal pGKey As String, _
    '                              ByVal pCiphertext As String, ByVal pRndVal As Integer, ByVal pOrderNo As String, _
    '                              ByVal pDeliveryAdd As String, ByVal pCustTel As String, ByVal pDiscount As Double, _
    '                              ByVal pFShipped As String, ByVal pOrderDate As DateTime, ByVal pPromiseDate As DateTime, _
    '                              ByVal pCardType As String, ByVal pCardNo As String, ByVal pCardName As String, _
    '                              ByVal pCardExpires As String, ByVal pCardAddress As String, ByVal pCustomerAddress As String, _
    '                              ByVal pOrderAmount As Double, ByVal pStartDate As String, ByVal pEndDate As String, _
    '                              ByVal pSecurityCode As Integer, ByVal pIssueNo As Integer, ByVal pPayProcessBy As String, _
    '                              ByVal pBankName As String, ByVal pChequeNo As String, ByVal pSortCode As String, _
    '                              ByVal pBankTranRefNo As String, ByVal pWintiprocess As String, ByVal pProductCodes As String) As Int32

    '    Dim CustomerID As Int32

    '    Dim dr As SqlDataReader
    '    Dim ProductDetails As New Text.StringBuilder(1000)

    '    Dim cmdData As New CommandData
    '    With cmdData
    '        .CmdText = "DBSERVER.InfinishopMainDB.DBO.ACC_AddCustomer"
    '        .AddParameter("@ac", pAC)
    '        .AddParameter("@surname", pSurName) '
    '        .AddParameter("@firstname", pFirstName)
    '        .AddParameter("@secondname", pSecondName)
    '        .AddParameter("@street", pStreet)
    '        .AddParameter("@town", pTown)
    '        .AddParameter("@ccode", pCcode)
    '        .AddParameter("@country", pCountry)
    '        .AddParameter("@postcode", pPostCode)
    '        .AddParameter("@cont_name", pContName)
    '        .AddParameter("@telephone", pPh)
    '        .AddParameter("@fax", pFax) ' nvarchar(80) = null,
    '        .AddParameter("@cart_customer_email", pEmail) ' varchar(255),
    '        .AddParameter("@cart_customer_notes", pNotes) ' varchar(250) = null,
    '        .AddParameter("@cart_customer_uid", pUID) ' varchar(255),' not required
    '        .AddParameter("@cart_customer_pass", pPW) ' varchar(255), ' not required
    '        .AddParameter("@cart_customer_state", pState) ' varchar(255) = null,
    '        .AddParameter("@vtime", pVTime) ' datetime,' not required
    '        .AddParameter("@fnew", pFNew) ' varchar(1),' not required
    '        .AddParameter("@fmodified", pFModified) ' varchar(1),' not required
    '        .AddParameter("@storename", pStoreName) ' varchar(50),' not required
    '        .AddParameter("@MerchantID", pMerchantID) ' int,' not required
    '        .AddParameter("@GKey", pGKey) ' nvarchar(1500),
    '        .AddParameter("@CipherText", pCiphertext) ' varchar(8000),
    '        .AddParameter("@RandomValue", pRndVal) ' int,
    '        .AddParameter("@CustomerID", 0, ParameterDirection.Output) ' bigint OUTPUT
    '        .Execute(ExecutionType.ExecuteNonQuery)
    '        CustomerID = .Item("@CustomerID")

    '        If CustomerID = 0 Then Return CustomerID

    '        .ClearParameters()

    '        .AddParameter("@ProductCodes", pProductCodes)
    '        .CmdText = "ACC_ProductInfo"
    '        dr = .Execute(ExecutionType.ExecuteReader)

    '        With dr
    '            While .Read
    '                ProductDetails.Append("<Product ")
    '                ProductDetails.Append("code = """ & .Item("code") & """ ")
    '                ProductDetails.Append("id = """ & .Item("ID") & """ ")
    '                ProductDetails.Append("price = """ & .Item("price") & """ ")
    '                ProductDetails.Append("tax = """ & .Item("tax") & """ ")
    '                ProductDetails.Append("taxcode = """ & .Item("taxcode") & """ ")
    '                ProductDetails.Append(" />")
    '            End While
    '            dr.Close()

    '        End With

    '    End With

    '    Dim WS As New WebServices(WebService.OrderNew)
    '    With WS

    '        .AddXMLNode("Sender", "Accountscentre")
    '        .AddXMLNode("MerchantID", )
    '        .AddXMLNode("CustomerID", )
    '        .AddXMLNode("MerchantUID", )
    '        .AddXMLNode("CustomerUID", )
    '        .AddXMLNode("OrderID", String.Empty)
    '        .AddXMLNode("PaymentMode", String.Empty)
    '        .AddXMLNode("Mode", "Test")
    '        '.CallWebService()
    '    End With

    'End Function


    Public Function ProductDetail() As DataSet

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.M2.DBO.Pay_ProductDetail")

    End Function

    Public Function EmployerSummary(ByVal EmployerID As Integer) As Object
        'SqlHelper.ConnectionString = Connection.GetConnectionString()
        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@EmployerId", SqlDbType.Int)
        arParams(0).Value = EmployerID
        Return SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "PAY_GetEmployerSummary", arParams)
    End Function

    Public Function GetCTRSummary(ByVal CustomerID As Integer) As Collection
        'Dim aa(6)
        'SqlHelper.ConnectionString = Connection.GetConnectionString(CustomerID)
        Dim sqldr As SqlDataReader
        Dim squery As String
        Dim Summary As New Collection
        'Summary.Add(PCT)
        'squery = "select * from OpenQuery(DBServer" & "," & "'Select * from InfiniShopMainDb.dbo.AccountsCentreUser where UserId = '" & Cu_ID & "'')"
        squery = "select S3F17,S3F18,S3F38 from Section3 where id = 'temp' or id =  (select Max(id) from Section3)"
        Try
            sqldr = SqlHelper.ExecuteReader(CustomerID, CommandType.Text, squery)
            If sqldr.Read Then
                Summary.Add(IIf(IsDBNull(sqldr("S3F17")), 0, sqldr("S3F17")), "PCTCT")
                Summary.Add(IIf(IsDBNull(sqldr("S3F18")), 0, sqldr("S3F18")), "FII")
                Summary.Add(IIf(IsDBNull(sqldr("S3F38")), 0, sqldr("S3F38")), "TL")
                Summary.Add(Val(IIf(IsDBNull(sqldr("S3F17")), 0, sqldr("S3F17"))) + Val(IIf(IsDBNull(sqldr("S3F18")), 0, sqldr("S3F18"))), "Profits")
            End If
        Finally
            If Not sqldr.IsClosed Then sqldr.Close()
            If Not sqldr Is Nothing Then sqldr = Nothing
        End Try
        Return Summary
    End Function

    Public Function GetSTASummary(ByVal CustomerID As Integer) As Collection
        'Dim aa(6)
        ' SqlHelper.ConnectionString = Connection.GetConnectionString(CustomerID)
        Dim sqldr As SqlDataReader
        Dim squery As String
        Dim Summary As New Collection
        'squery = "select * from OpenQuery(DBServer" & "," & "'Select * from InfiniShopMainDb.dbo.AccountsCentreUser where UserId = '" & Cu_ID & "'')"
        squery = "select Tangibles,CashBank,TurnOver,PAT,NetAssets from StatutoryAccounts where id = 'temp' or id =  (select Max(id) from StatutoryAccounts)"
        Try
            sqldr = SqlHelper.ExecuteReader(CustomerID, CommandType.Text, squery)
            If sqldr.Read Then
                Summary.Add(IIf(IsDBNull(sqldr("Tangibles")), 0, sqldr("Tangibles")), "Tangibles")
                Summary.Add(IIf(IsDBNull(sqldr("CashBank")), 0, sqldr("CashBank")), "CashBank")
                Summary.Add(IIf(IsDBNull(sqldr("TurnOver")), 0, sqldr("TurnOver")), "TurnOver")
                Summary.Add(IIf(IsDBNull(sqldr("PAT")), 0, sqldr("PAT")), "PAT")
                Summary.Add(IIf(IsDBNull(sqldr("NetAssets")), 0, sqldr("NetAssets")), "NetAssets")
            End If
        Finally
            If Not sqldr.IsClosed Then sqldr.Close()
            If Not sqldr Is Nothing Then sqldr = Nothing
        End Try
        Return Summary
    End Function

    Public Function ExpressAccountSummary(ByVal EmployerID As Integer) As Object
        'SqlHelper.ConnectionString = Connection.GetConnectionString(EmployerID)
        Return SqlHelper.ExecuteReader(EmployerID, CommandType.StoredProcedure, "EXPRESS_GetAccountSummary")
    End Function

    Public Function GetCAMSummary(ByVal mid As Integer) As Collection
        Dim coll As New Collection
        Dim _cDataReader As SqlDataReader
        Dim sqlParam As SqlParameter() = New SqlParameter(3) {}

        sqlParam(0) = New SqlParameter("@mid", SqlDbType.NVarChar, 50)
        sqlParam(0).Value = mid
        sqlParam(1) = New SqlParameter("@MBAL", SqlDbType.Money)
        sqlParam(1).Direction = ParameterDirection.Output
        sqlParam(2) = New SqlParameter("@PBAL", SqlDbType.Money)
        sqlParam(2).Direction = ParameterDirection.Output
        sqlParam(3) = New SqlParameter("@BankFund", SqlDbType.Money)
        sqlParam(3).Direction = ParameterDirection.Output
        'SqlHelper.ConnectionString = Connection.GetConnectionString(mid)
        Try
            _cDataReader = SqlHelper.ExecuteReader(mid, CommandType.StoredProcedure, "CAM_MerchantBalanceActivity", sqlParam)
        Finally
            If Not _cDataReader.IsClosed Then _cDataReader.Close()
            If Not _cDataReader Is Nothing Then _cDataReader = Nothing
        End Try

        coll.Add(sqlParam(1).Value.ToString(), "MBAL")
        coll.Add(sqlParam(2).Value.ToString(), "PBAL")
        coll.Add(sqlParam(3).Value.ToString(), "BankFund")
        Return coll
    End Function

    ' ************************ (MNS)
    '   Function for Retrieving Customer's Selected Services


    ' ************************ (MNS)
    '   Function for Retrieving Customer's Data

    Public Function GetCustomerData(ByVal intCustomerID As Int32) As DataSet

        Dim ds As DataSet
        Dim arParams() As SqlParameter = New SqlParameter(0) {}

        arParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(0).Value = intCustomerID

        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_GetCustomerDetail", arParams)

        Return ds

    End Function

    ' ************************ (MNS)
    '   Function for Inserting Invoice

    Public Function InsertInvoice(ByRef intCustomerID As Int32, ByVal pAC As String, ByVal pVTime As DateTime, _
                                  ByVal pFNew As String, ByVal pOrderNo As String, ByVal pDeliveryAdd As String, _
                                  ByVal pCustTel As String, ByVal pDiscount As Double, ByVal pFShipped As String, _
                                  ByVal pOrderDate As DateTime, ByVal pPromiseDate As DateTime, ByVal pCardType As String, _
                                  ByVal pCardNo As String, ByVal pCardName As String, ByVal pCardExpires As String, _
                                  ByVal pCardAddress As String, ByVal pCustomerAddress As String, ByVal pOrderAmount As Double, _
                                  ByVal pStartDate As String, ByVal pEndDate As String, ByVal pSecurityCode As String, _
                                  ByVal pIssueNo As String, ByVal pPayProcessBy As String, ByVal pBankName As String, _
                                  ByVal pChequeNo As String, ByVal pSortCode As String, ByVal pBankTranRefNo As String, _
                                  ByVal pWintiprocess As String, ByVal pProductCodes As String, Optional ByVal pCampaign As String = "WEB") As Boolean

        Dim intStatus As Boolean
        Dim arParams() As SqlParameter = New SqlParameter(29) {}

        '    '** INSERTING THE INPUT PARAMETERS IN THE ARRAY 
        '    '** THAT WILL BE USED IN STORED PROCEDURE

        arParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(0).Value = intCustomerID

        arParams(1) = New SqlParameter("@CustomerAC", SqlDbType.VarChar, 50)
        arParams(1).Value = pAC

        arParams(2) = New SqlParameter("@vtime", SqlDbType.DateTime) ' not required
        arParams(2).Value = pVTime

        arParams(3) = New SqlParameter("@fnew", SqlDbType.VarChar, 1) ' not required
        arParams(3).Value = pFNew

        arParams(4) = New SqlParameter("@order_no", SqlDbType.VarChar, 50)
        arParams(4).Value = pOrderNo

        arParams(5) = New SqlParameter("@del_add", SqlDbType.VarChar, 150)
        arParams(5).Value = pDeliveryAdd

        arParams(6) = New SqlParameter("@cust_tel", SqlDbType.VarChar, 20)
        arParams(6).Value = pCustTel

        arParams(7) = New SqlParameter("@discount", SqlDbType.Money)
        arParams(7).Value = pDiscount

        arParams(8) = New SqlParameter("@fshipped", SqlDbType.VarChar, 1)
        arParams(8).Value = pFShipped

        arParams(9) = New SqlParameter("@cart_invoice_orderdate", SqlDbType.DateTime)
        arParams(9).Value = pOrderDate

        arParams(10) = New SqlParameter("@cart_invoice_promiseshipdate", SqlDbType.DateTime)
        arParams(10).Value = pPromiseDate

        arParams(11) = New SqlParameter("@cart_invoice_cardtype", SqlDbType.VarChar, 255)
        arParams(11).Value = pCardType

        arParams(12) = New SqlParameter("@cart_invoice_cardno", SqlDbType.VarChar, 255)
        arParams(12).Value = pCardNo

        arParams(13) = New SqlParameter("@cart_invoice_cardname", SqlDbType.VarChar, 255)
        arParams(13).Value = pCardName

        arParams(14) = New SqlParameter("@cart_invoice_cardexpires", SqlDbType.VarChar, 10)
        arParams(14).Value = pCardExpires

        arParams(15) = New SqlParameter("@cart_invoice_cardaddress", SqlDbType.VarChar, 255)
        arParams(15).Value = pCardAddress

        arParams(16) = New SqlParameter("@cart_invoice_customeraddress", SqlDbType.VarChar, 255)
        arParams(16).Value = pCustomerAddress

        arParams(17) = New SqlParameter("@cart_invoice_orderamount", SqlDbType.Money)
        arParams(17).Value = pOrderAmount

        arParams(18) = New SqlParameter("@start_date", SqlDbType.VarChar, 10)
        arParams(18).Value = pStartDate

        arParams(19) = New SqlParameter("@end_date", SqlDbType.VarChar, 10)
        arParams(19).Value = pEndDate

        arParams(20) = New SqlParameter("@security_code", SqlDbType.VarChar, 10)
        arParams(20).Value = IIf((pSecurityCode Is Nothing) OrElse pSecurityCode = "", "", pSecurityCode)

        arParams(21) = New SqlParameter("@issue_no", SqlDbType.VarChar, 2)
        arParams(21).Value = pIssueNo

        arParams(22) = New SqlParameter("@PayProcessBy", SqlDbType.NVarChar, 2)
        arParams(22).Value = pPayProcessBy

        arParams(23) = New SqlParameter("@BankName", SqlDbType.NVarChar, 50)
        arParams(23).Value = pBankName

        arParams(24) = New SqlParameter("@ChequeNo", SqlDbType.NVarChar, 10)
        arParams(24).Value = pChequeNo

        arParams(25) = New SqlParameter("@SortCode", SqlDbType.NVarChar, 10)
        arParams(25).Value = pSortCode

        arParams(26) = New SqlParameter("@BankTrRefNo", SqlDbType.NVarChar, 10)
        arParams(26).Value = pBankTranRefNo

        arParams(27) = New SqlParameter("@wintiprocess", SqlDbType.NVarChar, 1)
        arParams(27).Value = pWintiprocess

        arParams(28) = New SqlParameter("@ProductCodeS", SqlDbType.NVarChar, 1000)
        arParams(28).Value = pProductCodes

        arParams(29) = New SqlParameter("@Campaign", SqlDbType.VarChar, 5)
        arParams(29).Value = pCampaign

        intStatus = SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_InsertInvoice", arParams)

        Return intStatus

    End Function

    Public Function UpdateCustomerRegistration(ByRef intCustomerID As Int32, ByVal pEmail As String) As Boolean

        Dim intStatus As Boolean
        Dim arParams() As SqlParameter = New SqlParameter(1) {}

        '    '** INSERTING THE INPUT PARAMETERS IN THE ARRAY 
        '    '** THAT WILL BE USED IN STORED PROCEDURE

        arParams(0) = New SqlParameter("@CustomerID", SqlDbType.BigInt)
        arParams(0).Value = intCustomerID

        arParams(1) = New SqlParameter("@email", SqlDbType.VarChar, 255)
        arParams(1).Value = pEmail

        Return intStatus
    End Function
    REM SR [UPDATE SUB ACCOUNT TO FORMATIONS HOUSE AND UPDATE COMPANY INFORMATION IN ACCOUNTS CENTRE]
    Public Sub UpdateFormationsHouseSubAccount(ByVal CompanyName As String, ByVal CompanyNumber As String, ByVal SubAccount As String, ByVal CustomerID As String)
        '[Update Sub Account Information]
        Dim oAccSrv As New AccServices.FHservices
        Dim oSubAccInfo As New AccServices.subaccountInfo
        oSubAccInfo.companyname = CompanyName
        oSubAccInfo.companynumber = CompanyNumber
        oSubAccInfo.customerid = CustomerID
        oSubAccInfo.subaccount = SubAccount
        oAccSrv.updateAccountSubid(oSubAccInfo)
        oAccSrv.Dispose()
        oAccSrv = Nothing

        '[Update Company Information]
        'UpdateCompanyInformation(SubAccount)
    End Sub

    Public Sub UpdateCompStatus(ByVal CustomerID As Integer, ByVal CompStatus As Integer)
        Dim oCmd As New CommandData
        oCmd.AddParameter("@nCustomerID", CustomerID)
        oCmd.AddParameter("@iCompStatus", CompStatus)

        oCmd.CmdText = "DBSERVER.Infinishopmaindb.dbo.ACC_UpdateCompStatus"
        oCmd.Execute(ExecutionType.ExecuteNonQuery)
        oCmd.ClearParameters()
    End Sub

    Public Function GetACUserRecordByID(ByVal UserID As Integer) As DataTable
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        'User ID
        sqlParams(0) = New SqlClient.SqlParameter("@iUserID", SqlDbType.Int)
        sqlParams(0).Value = UserID

        'Get Table via Stored Procedure
        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.ACC_GetACUserRecordByID", sqlParams).Tables(0)

        'Set values to nothing
        sqlParams = Nothing
    End Function

    Public Function AccGetOrderDetails(ByVal CustomerID As Integer, Optional ByVal OrderID As Integer = -1, Optional ByVal IsLast As Boolean = False, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetOrderDetail"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)
                If OrderID <> -1 Then
                    .AddParameter("@OrderNo", OrderID, ParameterDirection.Input)
                End If

                If IsLast Then
                    .AddParameter("@IsLast", IsLast, ParameterDirection.Input)
                End If

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        '--------
        Return dr
        '--------
    End Function

    Public Function AccGetInvoiceDetails(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetInvoiceDetails"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetInvoiceInfo(ByVal InvocieNo As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetInvoiceInfo"

                'Parameters
                .AddParameter("@InvoiceNo", InvocieNo, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetCustomerData(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetCustomerData"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With
        Return dr
    End Function

    Public Function AccGetInvoiceRptPdf(ByVal InvocieNo As Integer, ByVal chInvRpt As Char, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "Acc_GetInvoiceRptPdf"

                'Parameters
                .AddParameter("@InvoiceNo", InvocieNo, ParameterDirection.Input)
                .AddParameter("@IsInvRpt", chInvRpt.ToString, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetPaymentInfo(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "ACC_GetPaymentInfoByCustID"

                ' Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr

    End Function

    Public Function AccGetInvoicePdfTemplate(Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "Acc_GetInvoiceTemplate"
                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function

    Public Function AccGetCompanyInfo(Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "Acc_GetCompanyInfo"
                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With
        Return dr
    End Function

    Public Function AccGetProductDetail(ByVal ProductCode As String, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetProductDetails"

                .AddParameter("@Code", ProductCode, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function

    Public Function AccGetPaymentMode() As Boolean
        Dim cmdData As New CommandData
        Dim isLive As Boolean = False

        With cmdData
            Try
                .CmdText = "Dbserver.InfinishopMainDb.dbo.Acc_GetPaymentMode"
                isLive = CType(.Execute(ExecutionType.ExecuteScalar), Boolean)
            Catch ex As Exception
            Finally
                .CloseConnection()
            End Try
        End With

        Return isLive

    End Function

    Public Sub AccInsertPaymentErrorLog(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal ErrorDate As DateTime, ByVal ErrorCode As Integer, ByVal ErrorMsg As String)

        Dim cmdData As New CommandData

        With cmdData
            Try
                '---------------------------------------------------------------------------------
                .CmdText = "DbServer.InfinishopMainDb.dbo.Acc_InsertPaymentErrorLog"
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)
                .AddParameter("@OrderID", OrderID, ParameterDirection.Input)
                .AddParameter("@ErrorDate", ErrorDate, ParameterDirection.Input)
                .AddParameter("@ErrorCode", ErrorCode, ParameterDirection.Input)
                .AddParameter("@ErrorMsg", ErrorMsg, ParameterDirection.Input)
                .Execute(ExecutionType.ExecuteNonQuery)
                '---------------------------------------------------------------------------------
            Catch ex As Exception
                Trace.Write("AccInsertPaymentErrorLog generate excception : " & ex.Message)
            Finally
                .CloseConnection()
            End Try
        End With
    End Sub

    Public Function AccGetLogKey(ByVal CustomerID As Integer) As String
        Dim cmd As New CommandData
        Dim dr As SqlDataReader

        With cmd
            Try
                .CmdText = "DbServer.InfinishopMainDb.dbo.ACC_GetLogKey"
                .CmdType = CommandType.StoredProcedure
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)

                If dr.Read Then
                    Return dr.Item(0)
                End If
            Catch ex As Exception
            Finally
                dr.Close()
                .CloseConnection()
            End Try
        End With
        Return ""
    End Function

    Public Function AccGetResponseCode(ByVal OrderID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "ACC_GetResponseCode"
                .AddParameter("@OrderID", OrderID)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function


    Public Sub UpdateInvoiceInfo(ByVal OrderID As Integer, ByVal CreditCardType As String, ByVal CreditCardName As String, ByVal CreditCardNo As String, ByVal CreditCardAddress As String, ByVal CardExpireDate As Date, ByVal IssueNo As String, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal BankName As String, ByVal ChequeNo As String, ByVal SortCode As String, ByVal BankTransferNo As String, Optional ByVal CCStatus As String = "N")

        Dim cmd As New CommandData

        Try
            With cmd
                .AddParameter("@OrderID", OrderID)
                .AddParameter("@CreditCardType", CreditCardType)
                .AddParameter("@CreditCardName", CreditCardName)
                .AddParameter("@CreditCardNo", CreditCardNo)
                .AddParameter("@CreditCardAddress", CreditCardAddress)
                .AddParameter("@CreditCardExpires", CardExpireDate)
                .AddParameter("@StartDate", StartDate)
                .AddParameter("@EndDate", EndDate)
                .AddParameter("@IssueNo", IssueNo)
                .AddParameter("@SecurityCode", SecurityCode)
                .AddParameter("@BankName", BankName)
                .AddParameter("@ChequeNo", ChequeNo)
                .AddParameter("@SortCode", SortCode)
                .AddParameter("@BankTransferNo", BankTransferNo)
                .AddParameter("@CCStatus", CCStatus)

                .CmdText = "DbServer.M2.dbo.ACC_UpdateInvoice"

                .Execute(ExecutionType.ExecuteNonQuery)
            End With

        Catch ex As Exception
            Throw ex
        Finally
            cmd.CloseConnection()
            cmd = Nothing
        End Try

    End Sub
    'Created by Muhammad Furqan Khan on 06th Sept 2006
    Public Sub UpdateOrderType(ByVal OrderID As String, ByVal ProductCode As String, ByVal OrderType As OrderTypeEnum)
        Try
            With New CommandData
                Dim oType As String = String.Empty
                Select Case OrderType
                    Case OrderTypeEnum._New
                        oType = "N"
                    Case OrderTypeEnum._Renew
                        oType = "R"
                    Case OrderTypeEnum._Upgrade
                        oType = "U"
                    Case Else
                        oType = String.Empty
                End Select
                If oType <> String.Empty Then
                    .AddParameter("@ORDERID", OrderID)
                    .AddParameter("@PRODCODE", ProductCode)
                    .AddParameter("@ORDERTYPE", oType)
                    .CmdText = "DbServer.M2.dbo.ACC_UpdateOrderType"
                    .Execute(ExecutionType.ExecuteNonQuery)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Created by Muhammad Furqan Khan on 14th Sept 2006
    Public Function GetParentChildProfile(ByVal ChildID As Int64) As DataSet
        Try
            With New CommandData
                Dim oType As String = String.Empty
                .AddParameter("@CHILDID", ChildID)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_GetParentChildProfile"
                Dim dsData As DataSet
                dsData = .Execute(ExecutionType.ExecuteDataSet)
                ReplaceDbNullWithEmptyString(dsData)
                Return dsData
            End With
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.User.vb"" ""Function : GetParentChildProfile"" Description :" & ex.Message)
        End Try
    End Function

    'Created by Muhammad Furqan Khan on 14th Sept 2006
    'Modified by Muhammad Furqan Khan on 18th Sept 2006
    Public Sub SetIOServiceError(ByVal Referer As String, ByVal ChildID As Int64, ByVal MerchantID As String, ByVal ServiceURL As String, ByVal ServiceMethod As String, ByVal Description As String, Optional ByVal ErrorFixed As Boolean = False)
        Try
            With New CommandData
                Dim oType As String = String.Empty
                .AddParameter("@REF", Referer)
                .AddParameter("@CHILDID", ChildID)
                .AddParameter("@MERCHANTID", MerchantID)
                .AddParameter("@SERVICEURL", ServiceURL)
                .AddParameter("@SERVICEMETHOD", ServiceMethod)
                .AddParameter("@ERRORDESC", Description)
                .AddParameter("@SUCCESS", ErrorFixed)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_SetIOServiceError"
                .Execute(ExecutionType.ExecuteNonQuery)
            End With
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.User.vb"" ""Function : GetParentChildProfile"" Description :" & ex.Message)
        End Try
    End Sub

    'Created by Muhammad Furqan Khan on 14th Sept 2006
    'Modified by Muhammad Furqan Khan on 18th Sept 2006
    Public Sub ReplaceDbNullWithEmptyString(ByRef DsData As DataSet)
        If Not IsNothing(DsData) Then
            For Each dtdata As DataTable In DsData.Tables
                For Each drdata As DataRow In dtdata.Rows
                    Dim columns As Int32 = drdata.ItemArray.Length
                    For counter As Int32 = 0 To columns - 1
                        If IsDBNull(drdata(counter)) Then
                            drdata(counter) = String.Empty
                            On Error Resume Next
                        End If
                    Next
                Next
            Next
        End If
    End Sub

    'Created by Muhammad Furqan Khan on 27th Sept 2006
    Public Function GetPackageProducts(ByVal PackageCode As String) As DataTable
        Try
            With New CommandData
                Dim dsProducts As DataSet
                .AddParameter("@PACKAGECODE", PackageCode)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_GetPackageProducts"
                dsProducts = .Execute(ExecutionType.ExecuteDataSet)
                If dsProducts.Tables.Count > 0 Then
                    Return dsProducts.Tables(0)
                Else
                    Return Nothing
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Created by Muhammad Furqan Khan on 27th Sept 2006
    Public Function GetCustomerSelectedServices(ByVal CustomerID As String) As DataTable
        Try
            With New CommandData
                Dim dsProducts As DataSet
                .AddParameter("@CustomerID", CustomerID)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_GetCustomerSelectedServices"
                dsProducts = .Execute(ExecutionType.ExecuteDataSet)
                If dsProducts.Tables.Count > 0 Then
                    Return dsProducts.Tables(0)
                Else
                    Return Nothing
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function ACC_PackageProductDetailsCulture(ByVal intPackageOptions As PackageOptions, _
                                              ByVal intServiceOptions As ServiceOptions, ByVal culture As String) As DataSet
        'Created by Muhammad Ubaid
        Dim arParams() As SqlParameter = New SqlParameter(2) {}

        arParams(0) = New SqlParameter("@intPackageOptions", intPackageOptions)
        arParams(1) = New SqlParameter("@intServiceOptions", intServiceOptions)
        arParams(2) = New SqlParameter("@culture", culture)

        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ACC_PackagesDetailWithCulture", arParams)


    End Function

    'Created by M. Yousuf
    'Date: Dec 11, 2006
    Public Shared Function IsAvailableInACCustomerGrouping(ByVal CustomerID As String) As Boolean
        Dim rdr As SqlDataReader
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        Try
            sqlParams(0) = New SqlClient.SqlParameter("@MemberCustomerID", SqlDbType.BigInt)
            sqlParams(0).Value = CustomerID
            System.Web.HttpContext.Current.Trace.Warn("Calling RSS_IsAvailableInACCG")
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_IsAvailableInACCG", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("RSS_IsAvailableInACCG is ok")
            If rdr.Read() Then
                System.Web.HttpContext.Current.Trace.Warn("AvailableInACCustomerGrouping Return True")
                Return True
            Else
                System.Web.HttpContext.Current.Trace.Warn("AvailableInACCustomerGrouping Return False")
                Return False
            End If

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        Finally
            '-------------------------------------------------------------------------------
            If Not rdr Is Nothing AndAlso rdr.IsClosed Then rdr.Close()
            '-------------------------------------------------------------------------------
        End Try
    End Function

    'Created by M. Yousuf
    'Date: Dec 11, 2006
    Public Shared Sub AddAccountsCentreUser(ByVal UserID As String, ByVal CompanyName As String)
        Try
            Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

            sqlParams(0) = New SqlClient.SqlParameter("@UserID", SqlDbType.BigInt)
            sqlParams(0).Value = UserID
            sqlParams(1) = New SqlClient.SqlParameter("@CompanyName", SqlDbType.VarChar)
            sqlParams(1).Value = CompanyName

            System.Web.HttpContext.Current.Trace.Warn("Calling RSS_AddAccountsCentreUser")
            SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_AddAccountsCentreUser", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("RSS_AddAccountsCentreUser is ok")
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception in AddAccountsCentreUser")
            System.Web.HttpContext.Current.Trace.Warn("    Message = " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("    Source = " & ex.Source)
        End Try
    End Sub

    Public Shared Sub AddAccountsCentreGrouping(ByVal ParentID As String, ByVal SubCustomerID As String)
        System.Web.HttpContext.Current.Trace.Warn("In AddAccountsCentreGrouping")
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        sqlParams(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = ParentID
        sqlParams(1) = New SqlClient.SqlParameter("@MemberCustomerID", SqlDbType.BigInt)
        sqlParams(1).Value = SubCustomerID

        System.Web.HttpContext.Current.Trace.Warn("Calling RSS_AddAccountsCentreGrouping")
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_AddAccountsCentreGrouping", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("RSS_AddAccountsCentreGrouping is ok")
    End Sub

    Public Shared Sub ClearParentSelfEntry(ByVal CustomerID As String)
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}

        sqlParams(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = CustomerID

        System.Web.HttpContext.Current.Trace.Warn("Calling RSS_ClearSelfEntryACCG")
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_ClearSelfEntryACCG", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("RSS_ClearSelfEntryACCG is ok")
    End Sub

    Public Shared Sub AddResellerCustomersDetail(ByVal ParentID As String, ByVal SubCustomerID As String)
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        sqlParams(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = ParentID
        sqlParams(1) = New SqlClient.SqlParameter("@SubCustomerID", SqlDbType.BigInt)
        sqlParams(1).Value = SubCustomerID

        System.Web.HttpContext.Current.Trace.Warn("Calling RSS_AddResellerCustomersDetail")
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_AddResellerCustomersDetail", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("RSS_AddResellerCustomersDetail is ok")
    End Sub

    Public Shared Function GetParentID(ByVal ChildID As String) As String
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParams(0) = New SqlClient.SqlParameter("@CHILDID", SqlDbType.VarChar)
        sqlParams(0).Value = ChildID

        System.Web.HttpContext.Current.Trace.Warn("Calling ACC_GetParentChildProfile")
        Dim ds As DataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.ACC_GetParentChildProfile", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("ACC_GetParentChildProfile is ok")

        Return ds.Tables(0).Rows(0).Item("customer_id")
    End Function

    Public Shared Function GetProductName(ByVal ProductCode As String) As String
        Dim ProductName As String = ""
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParams(0) = New SqlClient.SqlParameter("@ProductCode", SqlDbType.VarChar)
        sqlParams(0).Value = ProductCode

        Dim rdr As SqlDataReader
        Try
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.M2.dbo.RSS_GetProductName", sqlParams)
            If rdr.Read() Then
                ProductName = rdr("cart_product_name")
            End If
        Catch ex As Exception
            Throw ex
        Finally
            '-------------------------------------------------------------------------------
            If Not rdr Is Nothing AndAlso rdr.IsClosed Then rdr.Close()
            '-------------------------------------------------------------------------------
        End Try
        Return ProductName
    End Function

    Public Shared Sub AddWebServiceLog(ByVal CallerAppName As String, _
                                            ByVal CallerMethodName As String, _
                                            ByVal WebServiceURL As String, _
                                            ByVal WebMethodName As String, _
                                            Optional ByVal Parameter As String = "", _
                                            Optional ByVal ErrorCode As String = "", _
                                            Optional ByVal ErrorDesc As String = "", _
                                            Optional ByVal ExceptionMessage As String = "", _
                                            Optional ByVal StackTrace As String = "")
        Try
            If CallerAppName.Length >= 1000 Then
                CallerAppName = CallerAppName.Substring(0, 999)
            End If
            If CallerMethodName.Length >= 1000 Then
                CallerMethodName = CallerMethodName.Substring(0, 999)
            End If
            If WebServiceURL.Length >= 1000 Then
                WebServiceURL = WebServiceURL.Substring(0, 999)
            End If
            If WebMethodName.Length >= 1000 Then
                WebMethodName = WebMethodName.Substring(0, 999)
            End If
            If Parameter.Length >= 1000 Then
                Parameter = Parameter.Substring(0, 999)
            End If
            If ErrorCode.Length >= 1000 Then
                ErrorCode = ErrorCode.Substring(0, 99)
            End If
            If ErrorDesc.Length >= 1000 Then
                ErrorDesc = ErrorDesc.Substring(0, 999)
            End If
            If ExceptionMessage.Length >= 1000 Then
                ExceptionMessage = ExceptionMessage.Substring(0, 999)
            End If
        Catch ex As Exception
        End Try

        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(8) {}
        sqlParams(0) = New SqlClient.SqlParameter("@CallerAppName", SqlDbType.VarChar)
        sqlParams(0).Value = CallerAppName
        sqlParams(1) = New SqlClient.SqlParameter("@CallerMethodName", SqlDbType.VarChar)
        sqlParams(1).Value = CallerMethodName
        sqlParams(2) = New SqlClient.SqlParameter("@WebServiceURL", SqlDbType.VarChar)
        sqlParams(2).Value = WebServiceURL
        sqlParams(3) = New SqlClient.SqlParameter("@WebMethodName", SqlDbType.VarChar)
        sqlParams(3).Value = WebMethodName
        sqlParams(4) = New SqlClient.SqlParameter("@Parameter", SqlDbType.VarChar)
        sqlParams(4).Value = Parameter
        sqlParams(5) = New SqlClient.SqlParameter("@ErrorCode", SqlDbType.VarChar)
        sqlParams(5).Value = ErrorCode
        sqlParams(6) = New SqlClient.SqlParameter("@ErrorDesc", SqlDbType.VarChar)
        sqlParams(6).Value = ErrorDesc
        sqlParams(7) = New SqlClient.SqlParameter("@ExceptionMessage", SqlDbType.VarChar)
        sqlParams(7).Value = ExceptionMessage
        sqlParams(8) = New SqlClient.SqlParameter("@StackTrace", SqlDbType.VarChar)
        sqlParams(8).Value = StackTrace

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.AddWebServiceLog", sqlParams)
    End Sub

    Public Shared Function GetCustomerID(ByVal CustomerUID As String) As String
        Dim rdr As SqlDataReader
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        Dim customer_id As String = ""
        Try
            sqlParams(0) = New SqlClient.SqlParameter("@cart_customer_uid", SqlDbType.VarChar)
            sqlParams(0).Value = CustomerUID
            System.Web.HttpContext.Current.Trace.Warn("Calling RSS_GetCustomerID")
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetCustomerID", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("RSS_GetCustomerID is ok")
            If rdr.Read() Then
                customer_id = IIf(IsDBNull(rdr("customer_id")), "", rdr("customer_id"))
                System.Web.HttpContext.Current.Trace.Warn("customer_id = " & customer_id)
            Else
                System.Web.HttpContext.Current.Trace.Warn("no record found!")

            End If
            'password = IIf(IsDBNull(rdr("Password")), "", rdr("Password"))
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        Finally
            '-------------------------------------------------------------------------------
            If Not rdr Is Nothing AndAlso rdr.IsClosed Then rdr.Close()
            '-------------------------------------------------------------------------------
        End Try
        Return customer_id
    End Function

    Public Shared Function GetCustomerUID(ByVal CustomerID As String) As String
        Dim rdr As SqlDataReader
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        Dim loginid As String = ""
        Try
            sqlParams(0) = New SqlClient.SqlParameter("@customer_id", SqlDbType.BigInt)
            sqlParams(0).Value = CustomerID
            System.Web.HttpContext.Current.Trace.Warn("Calling RSS_GetCustomerUID")
            rdr = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetCustomerUID", sqlParams)
            System.Web.HttpContext.Current.Trace.Warn("RSS_GetCustomerUID is ok")
            If rdr.Read() Then
                loginid = IIf(IsDBNull(rdr("cart_customer_uid")), "", rdr("cart_customer_uid"))
                System.Web.HttpContext.Current.Trace.Warn("CustomerUID = " & loginid)
            Else
                System.Web.HttpContext.Current.Trace.Warn("record not found ::CustomerID = " & CustomerID)
            End If

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        Finally
            If Not rdr Is Nothing AndAlso rdr.IsClosed Then rdr.Close()
            '-------------------------------------------------------------------------------
        End Try
        Return loginid
    End Function

    Public Shared Function IsReseller(ByVal CustomerID As String) As DataSet
        Dim ds As DataSet
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParams(0) = New SqlClient.SqlParameter("@ResellerID", SqlDbType.BigInt)
        sqlParams(0).Value = CustomerID
        System.Web.HttpContext.Current.Trace.Warn("Calling RSS_IsReseller")
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_IsReseller", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("RSS_IsReseller is ok")

        Return ds
    End Function


    Public Shared Function IsAPIReseller(ByVal ResellerID As String) As Boolean
        Dim Result As Boolean
        Dim ds As DataSet
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
        sqlParams(0) = New SqlClient.SqlParameter("@ResellerID", SqlDbType.VarChar)
        sqlParams(0).Value = ResellerID
        System.Web.HttpContext.Current.Trace.Warn("Calling RSS_IsAPIReseller")
        ds = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_IsAPIReseller", sqlParams)
        System.Web.HttpContext.Current.Trace.Warn("RSS_IsAPIReseller is ok")
        If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
            Result = False
        Else
            Result = True
        End If
        Return Result
    End Function

    Public Function GetLogKey(ByVal CustomerID As String) As String
        Dim LogKey As String = ""
        Dim sqlParams() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        sqlParams(0) = New SqlClient.SqlParameter("@CustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = CustomerID
        sqlParams(1) = New SqlClient.SqlParameter("@LogKey", SqlDbType.NVarChar, 1500)
        sqlParams(1).Value = LogKey
        sqlParams(1).Direction = ParameterDirection.Output
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RS_GetLogKey", sqlParams)

        LogKey = sqlParams(1).Value

        Return LogKey
    End Function
    'Created by Muhammad Ubaid
    Public Shared Sub setEmailStatus(ByVal customerid As Int64, ByVal bit As Byte)
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@customerid", customerid)
        param(1) = New SqlParameter("@bit", bit)
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBSERVER.InfiniShopMainDB.dbo.acc_set_Emailstatus", param)
    End Sub

    'Created by Muhammad Ubaid
    'Date: 22-Feb-2007
    'It sets Employee's Employer ID
    Public Shared Sub setEmpEmployerID(ByRef employeeInfo As Array)

        Dim objCryptography As New Cryptography
        Dim customerID As String
        Dim cmd As New CommandData
        Dim rd As SqlDataReader
        Dim self As New BLL.User
        Try
            With cmd
                .AddParameter("@EmployeeID", employeeInfo.GetValue(0))
                .CmdType = CommandType.StoredProcedure
                .CmdText = "getEmployeeMerchant"
                rd = .Execute(ExecutionType.ExecuteReader)
            End With
            If rd.Read Then
                With employeeInfo
                    .SetValue(CStr(rd("Merchant_uid")), 2)
                    .SetValue(CStr(rd("Merchant_id")), 3)
                    .SetValue(CStr(objCryptography.DeCrypt(CStr(rd("merchantPass")), CStr(rd("LogKey")))), 4)
                    .SetValue(CStr(rd("LogKey")), 5)
                    .SetValue(CStr(rd("LogType")), 6)
                    .SetValue(CStr(rd("UserName")), 7)
                    .SetValue(CStr(rd("employeePass")), 8)
                    .SetValue(CStr(rd("userid")), 10)
                    .SetValue("False", 9)
                    customerID = rd("customerid")
                End With
            End If
            self.verifyEmployee(employeeInfo, customerID)
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        Finally
            cmd.CloseConnection()
        End Try
    End Sub
    'Created by Muhammad Ubaid
    'Date : 26-Feb-2007
    Private Sub verifyEmployee(ByRef employeeinfo As Array, ByVal customerid As String)
        Try
            Dim objCryptography As New Cryptography
            With employeeinfo
                '            If CStr(.GetValue(1)).Trim = objCryptography.DeCrypt(.GetValue(8), .GetValue(5)) Then
                If CStr(.GetValue(1)).Trim = getMerchantCustomerPassword(employeeinfo, customerid).Trim Then
                    .SetValue("True", 9)
                Else
                    .SetValue("0", 0) : .SetValue("0", 1) : .SetValue("0", 2) : .SetValue("0", 3)
                    .SetValue("0", 4) : .SetValue("0", 5) : .SetValue("0", 6) : .SetValue("0", 7)
                    .SetValue("0", 8) : .SetValue("False", 9) : .SetValue("0", 10)
                End If
            End With
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        End Try
    End Sub
    Private Function getMerchantCustomerPassword(ByRef employeeInfo As Array, ByRef customerid As String) As String
        Try
            Dim rd As SqlDataReader
            Dim param() As SqlParameter = New SqlParameter(1) {}
            param(0) = New SqlParameter("@CustomerID", customerid)
            param(1) = New SqlParameter("@MIdentity", employeeInfo.GetValue(3))
            rd = SqlHelper.ExecuteReader(CInt(employeeInfo.GetValue(3)), CommandType.StoredProcedure, "dbo.getMerchantCustomerPassword", param)
            If rd.Read Then
                Return rd("Cart_Customer_Pass")
            End If
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        End Try
    End Function

    Public Function FetchAllowedProductsForUser(ByVal EmployeeID As String, ByVal CustomerID As String) As String()

        With New CommandData(CustomerID)
            .CmdText = "ACCOUNTSPRO_FETCHALLOWEDSERVICES"
            .AddParameter("@UserID", EmployeeID)
            Dim DS As DataSet = .Execute(ExecutionType.ExecuteDataSet)
            Dim AllowdProds() As String = New String(DS.Tables(0).Rows.Count - 1) {}
            Dim i As Int16 = 0
            For Each dr As DataRow In DS.Tables(0).Rows
                AllowdProds(i) = dr("ProductCode")
                i += 1
            Next
            Array.Sort(AllowdProds)
            Return AllowdProds
        End With

    End Function


    'Public Function ProductSummarize(ByVal dcfrom As String, ByVal dcto As String, ByVal childID As String, ByVal compname As String, ByVal parentID As String) As DataTable

    '    Dim ds As DataSet, Infinids As DataSet
    '    Dim dr As DataRow, dr1 As DataRow, bank As Decimal, cc As Decimal, other As Decimal, gross As Decimal
    '    Dim dt As New DataTable, dc As DataColumn, DRow As DataRow

    '    Try

    '        With New CommandData(childID)
    '            'With New CommandData(2)
    '            .CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE"
    '            .AddParameter("@MIDentity", childID)
    '            .AddParameter("@DATEFROM", CType(dcfrom, Date))
    '            .AddParameter("@DATETO", CType(dcto, Date))
    '            '.AddParameter("@MIDentity", 2)
    '            ds = .Execute(ExecutionType.ExecuteDataSet)

    '            dc = New DataColumn("CompanyName", GetType(String))
    '            dt.Columns.Add(dc)
    '            dc = New DataColumn("bybank", GetType(String))
    '            dt.Columns.Add(dc)
    '            dc = New DataColumn("bycc", GetType(String))
    '            dt.Columns.Add(dc)
    '            dc = New DataColumn("other", GetType(String))
    '            dt.Columns.Add(dc)
    '            dc = New DataColumn("bygross", GetType(String))
    '            dt.Columns.Add(dc)

    '            If ds.Tables(0).Rows.Count <> 0 Then
    '                For Each dr In ds.Tables(0).Rows
    '                    bank += CType(dr(3), Decimal)
    '                    cc += CType(dr(4), Decimal)
    '                    other += CType(dr(5), Decimal)
    '                    gross += CType(dr(6), Decimal)
    '                Next

    '                DRow = dt.NewRow()
    '                DRow("CompanyName") = compname
    '                DRow("bybank") = CType(Format(bank, "0.00"), String)
    '                DRow("bycc") = CType(Format(cc, "0.00"), String)
    '                DRow("other") = CType(Format(other, "0.00"), String)
    '                DRow("bygross") = CType(Format(gross, "0.00"), String)

    '                dt.Rows.Add(DRow)
    '            End If
    '            'Return dt
    '            .ClearParameters()
    '            .CloseConnection()

    '        End With


    '        With New CommandData
    '            .CmdText = "DBServer.InfinishopMainDB.dbo.ADMIN_GETCHILDCOMPANIESHAVINGPRO"
    '            .AddParameter("@Customerid", parentID)
    '            '.AddParameter("@Customerid", 2)
    '            Infinids = .Execute(ExecutionType.ExecuteDataSet)

    '            For Each dr1 In Infinids.Tables(1).Rows
    '                DRow = dt.NewRow()
    '                DRow("CompanyName") = dr1(1)
    '                DRow("bybank") = "-"
    '                DRow("bycc") = "-"
    '                DRow("other") = "-"
    '                DRow("bygross") = "-"
    '                dt.Rows.Add(DRow)
    '            Next

    '        End With
    '        Return dt
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    End Try
    'End Function

    'Public Shared Function ProductSummaryDetail(ByVal dcfrom As String, ByVal dcto As String, ByVal ChildID As Integer) As DataSet

    '    Dim ds As DataSet
    '    Dim cmd As New CommandData(ChildID)
    '    'Dim cmd As New CommandData(2)
    '    Dim WEL As String

    '    Try
    '        cmd.CmdType = CommandType.StoredProcedure
    '        cmd.CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE"
    '        cmd.AddParameter("@MIDentity", ChildID)
    '        cmd.AddParameter("@DATEFROM", CType(dcfrom, Date))
    '        cmd.AddParameter("@DATETO", CType(dcto, Date))
    '        'cmd.AddParameter("@MIDentity", 2)
    '        ds = cmd.Execute(ExecutionType.ExecuteDataSet)
    '        Return ds

    '    Catch ex As Exception
    '        Throw New Exception("ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE" & ex.Message)
    '    Finally
    '        cmd.CloseConnection()
    '        cmd = Nothing
    '    End Try

    'End Function

    'Public Function productSalesDetail(ByVal dcfrom As String, ByVal dcto As String, ByVal ChildID As Integer, ByVal code As String) As DataSet
    '    Dim cmd As New CommandData(ChildID)
    '    'Dim cmd As New CommandData(2)
    '    With cmd
    '        .CmdType = CommandType.StoredProcedure
    '        .CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSALESDETAIL"
    '        cmd.AddParameter("@MIDentity", ChildID)
    '        cmd.AddParameter("@DATEFROM", CType(dcfrom, Date))
    '        cmd.AddParameter("@DATETO", CType(dcto, Date))
    '        'cmd.AddParameter("@MIDentity", 2)
    '        .AddParameter("@Code", code)
    '        Try
    '            Return .Execute(ExecutionType.ExecuteDataSet)
    '        Catch ex As Exception
    '            Throw New Exception(ex.Message)
    '        Finally
    '            .CloseConnection()
    '            cmd = Nothing
    '        End Try
    '    End With
    'End Function

#Region "Sales Report Functions"

    Public Function GetAllChildCompaniesHavingPro(ByVal parentID As Integer) As DataSet
        Dim xml As String
        With New CommandData
            .CmdText = "DBServer.InfinishopMainDB.dbo.ADMIN_GETCHILDCOMPANIESHAVINGPRO"
            .AddParameter("@Customerid", parentID)
            Return .Execute(ExecutionType.ExecuteDataSet)
        End With
    End Function

    Public Function ProductSummarize(ByVal tempds As DataSet, ByVal dcfrom As String, ByVal dcto As String, ByVal childID As String, ByVal compname As String, ByVal parentID As String) As DataTable

        Dim ds As DataSet, Infinids As DataSet
        Dim dr As DataRow, dr1 As DataRow, bank As Decimal, cc As Decimal, other As Decimal, gross As Decimal
        Dim dt As New DataTable, dc As DataColumn, DRow As DataRow


        dc = New DataColumn("CompanyName", GetType(String)) : dt.Columns.Add(dc)
        dc = New DataColumn("bybank", GetType(String)) : dt.Columns.Add(dc)
        dc = New DataColumn("bycc", GetType(String)) : dt.Columns.Add(dc)
        dc = New DataColumn("other", GetType(String)) : dt.Columns.Add(dc)
        dc = New DataColumn("bygross", GetType(String)) : dt.Columns.Add(dc)
        dc = New DataColumn("childID", GetType(String)) : dt.Columns.Add(dc)

        'Try
        If Not tempds Is Nothing AndAlso tempds.Tables.Count <> 0 AndAlso tempds.Tables(0).Rows.Count <> 0 Then
            For Each dr In tempds.Tables(0).Rows

                With New CommandData(dr(0))
                    .CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE"
                    .AddParameter("@MIDentity", dr(0)) 'childID)
                    .AddParameter("@DATEFROM", CType(dcfrom, Date))
                    .AddParameter("@DATETO", CType(dcto, Date))
                    ds = .Execute(ExecutionType.ExecuteDataSet)

                    If ds.Tables(0).Rows.Count <> 0 Then

                        For Each dr1 In ds.Tables(0).Rows
                            bank += CType(dr1(3), Decimal) : cc += CType(dr1(4), Decimal) : other += CType(dr1(5), Decimal)
                            gross += CType(dr1(6), Decimal)
                        Next

                        DRow = dt.NewRow()
                        DRow("CompanyName") = dr(1) : DRow("bybank") = CType(Format(bank, "0.00"), String)
                        DRow("bycc") = CType(Format(cc, "0.00"), String) : DRow("other") = CType(Format(other, "0.00"), String)
                        DRow("bygross") = CType(Format(gross, "0.00"), String) : DRow("childID") = dr(0)

                        dt.Rows.Add(DRow)

                        .ClearParameters()
                        .CloseConnection()
                    Else
                        DRow = dt.NewRow()
                        DRow("CompanyName") = dr(1)
                        DRow("bybank") = "-"
                        DRow("bycc") = "-"
                        DRow("other") = "-"
                        DRow("bygross") = "-"
                        DRow("childID") = dr(0)
                        dt.Rows.Add(DRow)
                    End If
                End With
            Next
        End If
        Return dt

        'Comment By:    M.Yousuf
        'Date:          Oct 03, 2007
        'Desc:          Renew throw orignal exception instead of only old exception msg
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
    End Function

    Public Shared Function ProductSummaryDetail(ByVal dcfrom As String, ByVal dcto As String, ByVal ChildID As Integer) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(ChildID)
        Dim WEL As String

        Try
            cmd.CmdType = CommandType.StoredProcedure
            cmd.CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE"
            cmd.AddParameter("@MIDentity", ChildID)
            cmd.AddParameter("@DATEFROM", CType(dcfrom, Date))
            cmd.AddParameter("@DATETO", CType(dcto, Date))
            ds = cmd.Execute(ExecutionType.ExecuteDataSet)
            Return ds
        Catch ex As Exception
            Throw New Exception("ACCOUNTSPRO_INFINIBIZPRODUCTSUMMARIZE" & ex.Message)
        Finally
            cmd.CloseConnection()
            cmd = Nothing
        End Try

    End Function

    Public Function productSalesDetail(ByVal dcfrom As String, ByVal dcto As String, ByVal ChildID As Integer, ByVal code As String) As DataSet
        Dim cmd As New CommandData(ChildID)
        With cmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_INFINIBIZPRODUCTSALESDETAIL"
            cmd.AddParameter("@MIDentity", ChildID)
            cmd.AddParameter("@DATEFROM", CType(dcfrom, Date))
            cmd.AddParameter("@DATETO", CType(dcto, Date))
            .AddParameter("@Code", code)
            Try
                Return .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            Finally
                .CloseConnection()
                cmd = Nothing
            End Try
        End With
    End Function

#End Region
End Class