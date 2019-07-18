Imports System.Data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common
Imports System.IO

Public NotInheritable Class CustomerProfile

    Public Shared Function GetProfile(ByVal UserId) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        REM SR
        'xDim SqlStr As String = "SELECT * from " & SqlHelper.InfiniMainDB & "AccountscentreUser Where userid='" & UserId & "'"
        Dim SqlStr As String
        REM SR CR_00001
        SqlStr = "SELECT a.*, c.name, c.street, c.town, c.country, c.cont_name, c.telephone, c.fax, c.cart_customer_email, c.cart_customer_notes, c.postcode, c.cart_customer_state FROM " & SqlHelper.InfiniMainDB & "AccountscentreUser a " & _
                 "INNER JOIN  " & SqlHelper.InfiniMainDB & "Customer c ON a.userid=c.Customer_id " & _
                 "Where a.userid='" & UserId & "'"

        'SqlStr = "SELECT a.*, c.name, c.street, c.town, c.country, c.cont_name, c.telephone, c.fax, c.cart_customer_email, c.cart_customer_notes, c.postcode, c.cart_customer_state FROM " & SqlHelper.InfiniMainDB & "AccountscentreUser a " & _

        '        "INNER JOIN  " & SqlHelper.InfiniMainDB & "Customer c ON a.userid=c.Customer_id " & _

        '        "Where a.userid='" & UserId & "'"

        REM SR
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        datareader.Read()
        GetProfile = datareader
    End Function
    'xPublic Shared Sub UpdateProfile(ByVal UserID, ByVal compname, ByVal compregno, ByVal compaddress, ByVal comppostcode, ByVal compcity, ByVal compcountry, ByVal compphone, ByVal compfax, ByVal compemail, ByVal compwebsite, ByVal compperson, ByVal compdesignation, ByVal compcontact, ByVal complinbuss, ByVal compdesbuss, ByVal compemps, ByVal compwork, ByVal compyear, ByVal compDirector, ByVal compSec, ByVal compTaxRef, ByVal compEmpID)
    REM SR CR_00001
    'xPublic Shared Sub UpdateProfile(ByVal UserID, ByVal compname, ByVal compregno, ByVal compaddress, ByVal comppostcode, ByVal compcity, ByVal compcountry, ByVal compphone, ByVal compfax, ByVal compemail, ByVal compwebsite, ByVal compperson, ByVal compdesignation, ByVal compcontact, ByVal complinbuss, ByVal compdesbuss, ByVal compemps, ByVal compwork, ByVal compyear, ByVal compDirector, ByVal compSec, ByVal compTaxRef, ByVal compEmpID, ByVal name, ByVal street, ByVal town, ByVal country, ByVal cont_name, ByVal telephone, ByVal fax, ByVal cart_customer_email, ByVal cart_customer_notes, ByVal postcode, ByVal cart_customer_state, ByVal ccode)
    Public Shared Sub UpdateProfile(ByVal UserID, ByVal compname, ByVal compregno, ByVal compaddress, ByVal comppostcode, ByVal compcity, ByVal compcountry, ByVal compphone, ByVal compfax, ByVal compemail, ByVal compwebsite, ByVal compperson, ByVal compdesignation, ByVal compcontact, ByVal complinbuss, ByVal compdesbuss, ByVal compemps, ByVal compwork, ByVal compyear, ByVal compDirector, ByVal compSec, ByVal compTaxRef, ByVal compEmpID, ByVal name, ByVal street, ByVal town, ByVal country, ByVal cont_name, ByVal telephone, ByVal fax, ByVal cart_customer_email, ByVal cart_customer_notes, ByVal postcode, ByVal cart_customer_state, ByVal ccode, ByVal CurrencyID)
        REM SR CR_00001
        Dim arParams() As SqlParameter = New SqlParameter(35) {}
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        ' SqlHelper.ConnectionString = Connection.GetConnectionString
        arParams(0) = New SqlParameter("@compname", compname)
        arParams(1) = New SqlParameter("@compregno", compregno)
        arParams(2) = New SqlParameter("@compaddress", compaddress)
        arParams(3) = New SqlParameter("@comppostcode", comppostcode)
        arParams(4) = New SqlParameter("@compcity", compcity)
        arParams(5) = New SqlParameter("@compcountry", compcountry)
        arParams(6) = New SqlParameter("@compphone", compphone)
        arParams(7) = New SqlParameter("@compfax", compfax)
        arParams(8) = New SqlParameter("@compemail", compemail)
        arParams(9) = New SqlParameter("@compwebsite", compwebsite)
        arParams(10) = New SqlParameter("@compperson", compperson)
        arParams(11) = New SqlParameter("@compdesignation", compdesignation)
        arParams(12) = New SqlParameter("@compcontact", compcontact)
        arParams(13) = New SqlParameter("@complinbuss", complinbuss)
        arParams(14) = New SqlParameter("@compdesbuss", compdesbuss)
        arParams(15) = New SqlParameter("@compemps", compemps)
        arParams(16) = New SqlParameter("@compwork", compwork)
        arParams(17) = New SqlParameter("@compyear", compyear)
        arParams(18) = New SqlParameter("@compDirector", compDirector)
        arParams(19) = New SqlParameter("@compSec", compSec)
        arParams(20) = New SqlParameter("@compTaxRefId", compTaxRef)
        arParams(21) = New SqlParameter("@compEmpID", compEmpID)
        arParams(22) = New SqlParameter("@userid", UserID)
        'For Customers
        arParams(23) = New SqlParameter("@name", name)
        arParams(24) = New SqlParameter("@street", street)
        arParams(25) = New SqlParameter("@town", town)
        arParams(26) = New SqlParameter("@country", country)
        arParams(27) = New SqlParameter("@cont_name", cont_name)
        arParams(28) = New SqlParameter("@telephone", telephone)
        arParams(29) = New SqlParameter("@fax", fax)
        arParams(30) = New SqlParameter("@cart_customer_email", cart_customer_email)
        arParams(31) = New SqlParameter("@cart_customer_notes", cart_customer_notes)
        arParams(32) = New SqlParameter("@postcode", postcode)
        arParams(33) = New SqlParameter("@cart_customer_state", cart_customer_state)
        arParams(34) = New SqlParameter("@ccode", ccode)
        arParams(35) = New SqlParameter("@CurrencyID", CurrencyID)
        REM SR CR_00001
        'For Gateway Registration
        'arParams(35) = New SqlParameter("@UserCode", GGUserCode)
        'arParams(36) = New SqlParameter("@Password", GGPassword)
        'arParams(37) = New SqlParameter("@PINCode", GGPINCode)
        'arParams(35) = New SqlParameter("@Dated", Date.Now)
        REM SR CR_00001
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "UPDATEPROFILE", arParams)

    End Sub
    Public Shared Function IsGatewayReady(ByVal CustomerID As Object, ByVal ServiceName As String, ByRef PayeID As Object, ByRef CtrId As Object) As Boolean
        Dim datareader As SqlDataReader, sqlstr As String = ""
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        'sqlstr = "select count(*) from " & SqlHelper.InfiniMainDB & "CustomerSelectedServices C," & SqlHelper.InfiniMainDB & "Service S where C.ServiceID=S.[ID] and C.Gateway='Y' and S.[Name]='" & ServiceName & "' and C.CustomerID=" & CustomerID
        sqlstr = "select count(*),(select  PAYEID from " & SqlHelper.InfiniMainDB & "AccountscentreUser where  UserID='" & CustomerID & "' ) as PayeID,(select  CTRID from " & SqlHelper.InfiniMainDB & "AccountscentreUser where  UserID='" & CustomerID & "' ) as CtrID from " & SqlHelper.InfiniMainDB & "CustomerSelectedServices C," & SqlHelper.InfiniMainDB & "Service S  where C.ServiceID=S.[ID] and C.Gateway='Y' and S.[Name]='" & ServiceName & "' and C.CustomerID=" & CustomerID
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, sqlstr)
        datareader.Read()
        If Val(datareader(0)) >= 1 Then
            PayeID = datareader(1)
            CtrId = datareader(2)
            Return True
        Else
            PayeID = 0
            CtrId = 0
            Return False
        End If
        datareader.Close()
        datareader = Nothing
    End Function
    Public Shared Function GetCountries() As DataTable
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "ACC_GetCountries").Tables(0)
    End Function

    Public Shared Function GetCurrencies() As DataTable
        InfiniLogic.AccountsCentre.DAL.SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "ACC_GetCurrencies").Tables(0)
    End Function

    ' For Payroll
    Public Function Update(ByVal employerID As Int32, ByVal street As String, ByVal town As String, _
                                       ByVal postcode As String, ByVal contname As String, ByVal telephone As String, _
                                       ByVal fax As String, ByVal email As String, ByVal state As String, _
                                       ByVal companyName As String, ByVal payeOfficeNo As String, ByVal payeReferenceNo As String, _
                                       ByVal accountReferenceNo As String, ByVal nino As String, ByVal businessType As String, _
                                       ByVal employeesQty As Integer, ByVal isDirector As Boolean, ByVal CompanyRegNo As String, _
                                       ByVal DateOfIncorporation As Date, ByVal DateOfPayDay As Date, ByVal FrequencyOfPayment As String, ByVal AccountOfficeReference As String, Optional ByVal currTaxYear As Int16 = 0, Optional ByVal strECON As String = "") As Boolean


        If (currTaxYear = 0) Then
            currTaxYear = CommonBase.CurrentTaxYear
        End If

        Update = False

        'Create parameter array

        Dim cmdData As New CommandData
        With cmdData
            Try

                .CmdText = "[DBSERVER].[InfinishopMainDB].[DBO].[PAY_UpdateEmployer]"
                .AddParameter("@employerID", employerID)
                .AddParameter("@street", street)
                .AddParameter("@town", town)
                .AddParameter("@postcode", postcode)
                .AddParameter("@contactname", contname)
                .AddParameter("@telephone", telephone)
                .AddParameter("@fax", fax)
                .AddParameter("@email", email)
                .AddParameter("@state", state)
                .AddParameter("@companyName", companyName)
                .AddParameter("@payeOfficeNo", payeOfficeNo)
                .AddParameter("@payeReferenceNo", payeReferenceNo)
                .AddParameter("@accountReferenceNo", accountReferenceNo)
                .AddParameter("@nino", nino)
                .AddParameter("@businessType", businessType)
                .AddParameter("@employeesQty", employeesQty)
                .AddParameter("@Director", isDirector)
                .AddParameter("@CompanyRegNo", CompanyRegNo)
                .AddParameter("@DateOfIncorporation", DateOfIncorporation)
                .AddParameter("@DateOfPayDay", DateOfPayDay)
                .AddParameter("@FrequencyOfPayment", FrequencyOfPayment)
                .AddParameter("@currentTaxYear", currTaxYear)
                .AddParameter("@AccountOfficeReference", AccountOfficeReference)
                If strECON <> "" Then .AddParameter("@ECON", strECON)
                If .Execute(ExecutionType.ExecuteNonQuery) > 0 Then Update = True
            Catch e As Exception

            Finally
                .CloseConnection()
            End Try

        End With

        Return Update
    End Function


    ' For Express

    Public Function UpdateCompanyInfo(ByVal CustomerID As Integer, ByVal Name As String, ByVal Street As String, ByVal City As String, _
                                  ByVal PCode As String, ByVal Country As String, ByVal Telephone As String, _
                                  ByVal Fax As String, ByVal EMail As String, ByVal VatNo As String, _
                                  ByVal Logo As Array, ByVal LogoName As String, ByVal Checked As Boolean, ByVal ServiceName As String, _
                                    Optional ByVal MerchantID As Integer = 2)

        Dim arParams() As SqlParameter

        If Checked = True Then

            arParams = New SqlParameter(12) {}

        Else

            arParams = New SqlParameter(10) {}

        End If

        Dim cmd As New CommandData(CustomerID)

        arParams(0) = New SqlParameter("@Name", SqlDbType.VarChar)
        arParams(0).Value = Name

        arParams(1) = New SqlParameter("@Street", SqlDbType.VarChar)
        arParams(1).Value = Street

        arParams(2) = New SqlParameter("@City", SqlDbType.VarChar)
        arParams(2).Value = City

        arParams(3) = New SqlParameter("@PostalCode", SqlDbType.VarChar)
        arParams(3).Value = PCode

        arParams(4) = New SqlParameter("@Country", SqlDbType.VarChar)
        arParams(4).Value = Country

        arParams(5) = New SqlParameter("@Telephone", SqlDbType.VarChar)
        arParams(5).Value = Telephone

        arParams(6) = New SqlParameter("@Fax", SqlDbType.VarChar)
        arParams(6).Value = Fax

        arParams(7) = New SqlParameter("@EMail", SqlDbType.VarChar)
        arParams(7).Value = EMail

        arParams(8) = New SqlParameter("@VatNo", SqlDbType.VarChar)
        arParams(8).Value = VatNo

        arParams(9) = New SqlParameter("@TranDateTime", SqlDbType.DateTime)
        arParams(9).Value = Date.Now

        arParams(10) = New SqlParameter("@MIdentity", SqlDbType.Int)
        arParams(10).Value = MerchantID

        If Checked = True Then

            arParams(11) = New SqlParameter("@Logo", SqlDbType.Image)
            arParams(11).Value = Logo

            arParams(12) = New SqlParameter("@LogoName", SqlDbType.VarChar)
            arParams(12).Value = LogoName

        End If


        If Checked = True And ServiceName = "Express" Then

            SqlHelper.ExecuteNonQuery(CustomerID, CommandType.StoredProcedure, "EXPRESS_UPDATECOMPANYINFOWITHLOGO", arParams)

        ElseIf Checked = True And ServiceName = "AccountsProWeb" Then

            SqlHelper.ExecuteNonQuery(CustomerID, CommandType.StoredProcedure, "ACCOUNTSPRO_UPDATECOMPANYINFOWITHLOGO", arParams)

        ElseIf Checked = False And ServiceName = "Express" Then

            SqlHelper.ExecuteNonQuery(CustomerID, CommandType.StoredProcedure, "Express_UPDATECOMPANYINFOWITHOUTLOGO", arParams)

        ElseIf Checked = False And ServiceName = "AccountsProWeb" Then

            SqlHelper.ExecuteNonQuery(CustomerID, CommandType.StoredProcedure, "ACCOUNTSPRO_UPDATECOMPANYINFOWITHOUTLOGO", arParams)

        End If

    End Function


    Public Function GetPayrollData(ByVal employerID As Int32) As DataSet
        Try

            Dim sqlParam As SqlParameter() = New SqlParameter(0) {}
            sqlParam(0) = New SqlParameter("@CustomerID", SqlDbType.Int, 4)
            sqlParam(0).Value = employerID

            Return SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "[DBSERVER].[InfinishopMainDB].[DBO].[PAY_GetEmployerDetail]", sqlParam)

        Catch ex As Exception

        End Try

    End Function

    Public Function GetExpressData(ByVal CustomerID As Int32, ByVal ServiceName As String) As DataSet

        Try
            If ServiceName = "Express" Then

                Return SqlHelper.ExecuteDataset(CustomerID, CommandType.StoredProcedure, "EXPRESS_GETCOMPANYINFO")
            ElseIf ServiceName = "AccountsProWeb" Then

                Return SqlHelper.ExecuteDataset(CustomerID, CommandType.StoredProcedure, "ACCOUNTSPRO_GETCOMPANYINFO")
            End If

        Catch ex As Exception

        End Try
    End Function



    Public Function UpdateFHCustomerDataToAC(ByVal CustomerID As String) As Array


        Dim objGlobalView As New GlobalView
        Dim sDirsNSects(1) As String
        Dim str(15) As String


        Try

            Dim objFHCustomerData As New com.formationshouse.www.FHservices
            Dim objCompInfo As com.formationshouse.www.CompanyInfo
            Dim objadd As com.formationshouse.www.AddressInfo



            objCompInfo = objFHCustomerData.getCompanyBySubid(CustomerID)


            If Not objCompInfo.companyname Is Nothing Then

                str(0) = objCompInfo.ard
                str(1) = objCompInfo.companyname
                str(2) = objCompInfo.companynumber
                str(3) = objGlobalView.getCompanyAddressString(objCompInfo.address)
                str(4) = objCompInfo.address.postcode
                str(5) = objCompInfo.address.posttown
                str(6) = objCompInfo.address.country
                str(7) = objCompInfo.domainname

                sDirsNSects = objGlobalView.getDirectorNSecretary(objCompInfo.officerinfo)

                str(8) = sDirsNSects(0)
                str(9) = sDirsNSects(1)
                str(10) = objCompInfo.taxcode
                str(11) = objCompInfo.eincdate
                str(12) = ""                'objCompInfo.email
                str(13) = ""                'objCompInfo.fax
                str(14) = objCompInfo.taxissuedate
                str(15) = ""               'objCompInfo.telephone



                UpdateFHCustomer(CustomerID, str(1), str(2), str(3), str(4), str(5), str(6), str(7), str(8), str(9), objCompInfo.taxcode)



            Else

                Exit Function

            End If

            Return str


        Catch ex As Exception

        Finally



        End Try


    End Function

    Public Sub UpdateFHCustomer(ByVal UserID, ByVal compname, ByVal compregno, ByVal compaddress, ByVal comppostcode, ByVal compcity, ByVal compcountry, ByVal compwebsite, ByVal compDirector, ByVal compSec, ByVal compTaxRef)


        Dim arParams() As SqlParameter = New SqlParameter(10) {}

        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        arParams(0) = New SqlParameter("@UserID", UserID)
        arParams(1) = New SqlParameter("@compname", compname)
        arParams(2) = New SqlParameter("@compregno", compregno)
        arParams(3) = New SqlParameter("@compaddress", compaddress)
        arParams(4) = New SqlParameter("@comppostcode", comppostcode)
        arParams(5) = New SqlParameter("@compcity", compcity)
        arParams(6) = New SqlParameter("@compcountry", compcountry)
        arParams(7) = New SqlParameter("@compwebsite", compwebsite)
        arParams(8) = New SqlParameter("@compDirector", compDirector)
        arParams(9) = New SqlParameter("@compSec", compSec)
        arParams(10) = New SqlParameter("@compTaxRefId", compTaxRef)

        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "ACC_UpdateFHCustomer", arParams)

    End Sub
    Public Function CheckTransaction(ByVal CustomerID As Integer) As Boolean
        'Added by Muhammad Ubaid
        '21-June-2006
        Dim result As String

        Dim arParams() As SqlParameter = New SqlParameter(0) {}
        arParams(0) = New SqlParameter("@CustomerID", CustomerID)

        Dim Dr As SqlDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "ACCOUNTSPRO_CHECKTRANSACTIONS", arParams)
        While Dr.Read
            If Not IsDBNull(Dr.Item(0)) Then result = CStr((Dr.Item(0)))
        End While

        If result.Equals("TRUE") Then
            CheckTransaction = True
        Else
            CheckTransaction = False
        End If

        Dr.Close()
        Dr = Nothing
    End Function
End Class
