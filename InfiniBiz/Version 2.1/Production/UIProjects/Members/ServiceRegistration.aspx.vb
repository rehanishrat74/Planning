#Region ":::::::::::::::: Imports Libraries ::::::::::::::::"
Imports System.Collections.Specialized
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Mail
Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports System.IO
Imports System.Xml
Imports System.Web.Security
#End Region

''' -----------------------------------------------------------------------------
''' Project	 : www.accountscentre.com
''' Class	 : AccountsCentre.Web.ServiceRegistration
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.abid]	02/02/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ServiceRegistration
    Inherits PageTemplate

#Region ":::::::::::::::: Declaration ::::::::::::::::"

    Private dtCompanies As DataTable
    Private dvCompanies As DataView
    Private bSignUp As Boolean = False
    Private objUser As New User
    Private WithEvents objCXL As New CXLProcessing
    Private objCXLOrder As New CXLOrderProcessing
    Protected WithEvents lblCustomerID As System.Web.UI.WebControls.Label
    Private objCryptography As New Cryptography

    Const ACC_ISFORMCOMPLETED As String = "ACC_ISFORMCOMPLETED"

    '~~~~~~~~~~~ START DECLARATION ~~~~~~~~~~~
    Private intCustomerID, intRndNo, _
        intTrackID, intParentCustomerID As Integer

    Private strAc, strInvoiceName, strStreet, _
        strTown, strCountryCode, strCountry, _
        strPostCode, strContName, strPh, _
        strFax, strEmail, strNotes, strUID, _
        strEncryptPassword, strState, strTime, _
        strFnew, strFModified, strStoreName, _
        lngMerchantID, strGKey, strEncryptKey, _
        strOrderNo, strDeliveryAddress, strCustPh, _
         strFShipped, strCardType, strCardNo, _
        strCardName, strCardExpires, strCardAddress, _
        strCustomerAddress, strStartDate, strEndDate, _
        strPayProcessBy, strBankName, strChequeNo, _
        strSortCode, strBankTranRefNo, strWintiprocess, _
        strProductCodes, strMsg, strLoginID, _
        strServiceStatus, strReturn, strPaymentMode, SecurityCode, _
        strTo, strSubject, strBody, strCustomerAddressForEmail, _
        strUserPassword, strCompaign, strCreditCardType, strCreditCardNo, _
        strCreditCardName, strCreditCardAddress, strIssueNo As String

    Private dteOrderDate, dtePromiseShipDate As Date
    Private dblDiscount, dblOrderAmount As Double
    Private bolAsExcluded As Boolean
    Private strGKeyLen As Integer = 1024
    Protected WithEvents listCompany As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnCompanyList As System.Web.UI.WebControls.Button
    Protected WithEvents pnlCompanyList As System.Web.UI.WebControls.Panel
    Protected WithEvents lbluseridpassword As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblpassword As System.Web.UI.WebControls.Label
    Protected WithEvents lblnewcustomer As System.Web.UI.WebControls.Label
    Protected WithEvents lblinvoicename1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContactName1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblpassword1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblconfirmpassword As System.Web.UI.WebControls.Label
    Protected WithEvents lblstreet2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcity2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblstatecounty As System.Web.UI.WebControls.Label
    Protected WithEvents lblpostcode2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcountry2 As System.Web.UI.WebControls.Label
    Protected WithEvents lbltelephone As System.Web.UI.WebControls.Label
    Protected WithEvents lblfax2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblemail2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblnotes As System.Web.UI.WebControls.Label
    Protected WithEvents lblselectcompnany As System.Web.UI.WebControls.Label
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Tr2 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    '~~~~~~~~~~~  END DECLARATION  ~~~~~~~~~~~

    Dim isCxlError As Boolean = False

#End Region

#Region ":::::::::::::::: Web Form Designer Generated Code ::::::::::::::::"

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtCustomerID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button
    Protected WithEvents btnSignUP As System.Web.UI.WebControls.Button
    Protected WithEvents pnlAuhtenticate As System.Web.UI.WebControls.Panel
    Protected WithEvents ucServiceOrder As ServiceOrder
    Protected WithEvents pnlSingUp As System.Web.UI.WebControls.Panel
    Protected WithEvents txtInvoiceName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtContactName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtConfirmPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStreet As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTown As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtState As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCountry As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtTelephone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNotes As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCreateAccount As System.Web.UI.WebControls.Button
    Protected WithEvents trPassword As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPasswordConfirm As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtSignUpPwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region ":::::::::::::::: Event handlers ::::::::::::::::"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        '****************Muhammad Ubaid********************************
        'Dim strRefEmail As String = Session(Me.ACC_ORDER_HERE_COMPAIGN)

        'If strRefEmail Is Nothing OrElse strRefEmail = "" Then
        '    strCompaign = "WEB"
        'Else
        '    strCompaign = Session(Me.ACC_ORDER_HERE_COMPAIGN)
        'End If

        '  If Not Page.User.Identity.IsAuthenticated Then '(strIdentity Is Nothing) OrElse strIdentity = "" Then
        ' If Session(Me.ACC_ORDER_HERE_LINK) = "" Then RedirectTo(ACC_Redirection.SIGNIN)
        ' End If
        '**************************************************************

        'viewstate.Add("HashTableUpgradeList", viewstate.Item("HashTableUpgradeList"))
        'viewstate.Add("OrderUpgradeAmount", viewstate.Item("OrderUpgradeAmount"))
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        ErrorMessage = ""

        SignIn()

        lblStatus.Text = "SignIn"
        If ErrorMessage = "" Then
            pnlAuhtenticate.Visible = False
            pnlSingUp.Visible = False
            pnlCompanyList.Visible = True

            PrepareCompanyList()
        Else
            ucServiceOrder.ShowError(ErrorMessage, True)
            ErrorMessage = ""
        End If

    End Sub

    Private Sub btnSignUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSignUP.Click
        pnlSingUp.Visible = True
        pnlAuhtenticate.Visible = False
        BindCountry(ddlCountry)
    End Sub

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click

        If VerifyCustomerDetailPanel() = True Then
            lblStatus.Text = "SignUp"
            ProceedContinue()
        Else
            lblStatus.Text = ""
            ErrorMessage = ""
        End If
    End Sub

    Private Sub DisplayAuthentication() Handles ucServiceOrder.ServiceNext

        If (Not Page.User.Identity.Name Is Nothing) AndAlso Page.User.Identity.Name <> "" AndAlso CustomerID > 0 Then
            pnlCompanyList.Visible = True
            PrepareCompanyList()
            lblStatus.Text = "SignIn"
        Else
            pnlAuhtenticate.Visible = True
        End If

    End Sub

    Private Sub InsertData() Handles ucServiceOrder.ProcessOrder

        '----------------------------------------------------
        bSignUp = IIf(lblStatus.Text = "SignIn", False, True)
        '----------------------------------------------------

        With ucServiceOrder
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            If bSignUp Then
                If Not .IsRetry Then
                    '------------------------------------------
                    strGKey = objCryptography.KeyGen(strGKeyLen)
                    '------------------------------------------
                Else
                    '------------------------------------------------
                    intCustomerID = CInt(lblCustomerID.Text)
                    strGKey = objCXLOrder.AccGetLogKey(intCustomerID)
                    '------------------------------------------------
                End If
            Else
                'Dim strTemp As String
                'CheckOrder(strTemp)
                strGKey = objCXLOrder.AccGetLogKey(CustomerID)
            End If

            '----------------------------------
            ' PASSWORD ENCRYPTION
            strTime = Now
            strFnew = "y"
            strFModified = "n"
            strStoreName = "ACCOUNTSCENTRE"
            strPayProcessBy = "AC"
            strWintiprocess = "n"
            strIssueNo = ""
            '----------------------------------

            '***********************************************************
            ' RANDOM NO. GENERATION FOR AC FIELD OF THE CUSTOMER TABLE

            Randomize()
            intRndNo = Int(Rnd() * 89) + 10

            '***********************************************************

            '--------------------------------------------------------------------
            ' THESE FIELDS ARE USED FOR INVOICE 
            strOrderNo = "@ORD"
            dblDiscount = 0.0
            strFShipped = "n"
            dteOrderDate = Now()
            strDeliveryAddress = .DeliveryAddress
            dtePromiseShipDate = DateSerial(Year(Now), Month(Now), Day(Now) + 7)

            '--------------------------------------------------------------------

            '------------------------------------
            strStartDate = New Date(2000, 1, 1)
            strEndDate = strStartDate
            strCardExpires = strEndDate
            '------------------------------------

            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : Bank / Cheque/ Credit Card IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            ' Option to choose Cheque Or Bank Transfer / Credit Card

            If .IsCreditCard Then
                '---------------------------------------------------------------
                strCreditCardType = .CreditCard
                strCreditCardNo = .CardNumber
                strCreditCardName = .CardHolderName
                strCreditCardAddress = .CardAddress

                strCardType = objCryptography.EnCrypt(.CreditCard, strGKey)
                strCardNo = objCryptography.EnCrypt(.CardNumber, strGKey)
                strCardName = objCryptography.EnCrypt(.CardHolderName, strGKey)
                strCardAddress = objCryptography.EnCrypt(.CardAddress, strGKey)
                '---------------------------------------------------------------

                '----------------------------------
                If .SecurityCode <> "" Then
                    SecurityCode = .SecurityCode
                End If
                '----------------------------------

                '--------------------
                strCardExpires = .CardExpiryDate
                'If .IsRetry Then strCardExpires = New Date(Year(strCardExpires), Month(strCardExpires), Day(strCardExpires))
                strPaymentMode = "CC"
                '--------------------

            Else
                '------------------------------------
                strBankName = .BankName
                strChequeNo = .ChequeNumber
                strSortCode = .SortCode
                strBankTranRefNo = .TransactionRefNo
                strPaymentMode = "CB"
                '------------------------------------
            End If
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : Bank / Cheque/ Credit Card IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : AMEX / DEBIT CARDS IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            If .IsAmexOrSwitchCard Then

                '-----------------------------
                strStartDate = .CardStartDate
                strEndDate = strCardExpires
                '-----------------------------

            ElseIf .IsDebitCard Then

                '-----------------------------
                If .IssueNumber <> "" Then
                    strIssueNo = .IssueNumber
                End If
                '-----------------------------

            End If

            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END : AMEX / DEBIT CARDS IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            '---------------------------------------------------
            strProductCodes = .ProdcutPackageXML(dblOrderAmount)
            'dblOrderAmount -= CDbl(ViewState.Item("OrderUpgradeAmount"))
            '---------------------------------------------------


            If bSignUp Then
                '--------------------------------------------------------------------
                '---------------------------------------------------------
                strAc = "a"
                strInvoiceName = txtInvoiceName.Text

                strUID = "uid"
                strStreet = txtStreet.Text
                strTown = txtTown.Text
                strState = txtState.Text
                strPostCode = UCase(txtPostCode.Text)

                strCountryCode = ddlCountry.SelectedItem.Value
                strCountry = ddlCountry.SelectedItem.Text
                strContName = txtContactName.Text
                strPh = txtTelephone.Text
                strFax = txtFax.Text
                strEmail = txtEmailAddress.Text
                strNotes = txtNotes.Text
                strCustPh = txtTelephone.Text

                'RETRIEVING MERCHANT ID
                lngMerchantID = Mid$(objUser._strDatabaseName, 2)

                strEncryptPassword = objCryptography.EnCrypt(txtSignUpPwd.Text, strGKey)
                '-------------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------------------------------------------
                strCustomerAddress = strStreet & " " & strTown & " " & strState & " " & strPostCode & " " & strCountry
                strCustomerAddressForEmail = strStreet & "<br> " & strTown & "<br>" & strState & "<br>" & strPostCode & "<br>" & strCountry
                '------------------------------------------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------------------------------------------------
                If Not (Session("ACC_GV_RegistrationMode") Is Nothing) Then
                    intParentCustomerID = CInt(Session("ACC_GV_ParentCustomerID"))
                    If (Session("ACC_GV_RegistrationMode") = RegistrationMode.ExcludedFromGlobalView) Then bolAsExcluded = True
                End If
                '----------------------------------------------------------------------------------------------------------------

                strUserPassword = txtSignUpPwd.Text
                RegisterUser()

            Else 'bSignUP
                '--------------------------------------------------------------------                
                Dim ds As DataSet = objUser.GetCustomerData(CustomerID)

                Try
                    If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
                        ' set the result of data row
                        Dim dt1 As DataTable = ds.Tables(0)
                        Dim dr1 As DataRow = dt1.Rows(0)

                        If Not IsDBNull(dr1.Item(0)) Then strAc = dr1.Item(0)
                        If Not IsDBNull(dr1.Item(1)) Then strStreet = dr1.Item(1)
                        If Not IsDBNull(dr1.Item(2)) Then strTown = dr1.Item(2)
                        If Not IsDBNull(dr1.Item(3)) Then strState = dr1.Item(3)
                        If Not IsDBNull(dr1.Item(4)) Then strCountry = dr1.Item(4)
                        If Not IsDBNull(dr1.Item(5)) Then strPostCode = dr1.Item(5)
                        If Not IsDBNull(dr1.Item(6)) Then strCustPh = dr1.Item(6)
                        If Not IsDBNull(dr1.Item(7)) Then strEmail = dr1.Item(7)
                        If Not IsDBNull(dr1.Item(11)) Then strInvoiceName = dr1.Item(11)
                        If Not IsDBNull(dr1.Item(11)) Then strLoginID = dr1.Item(12)
                        If Not IsDBNull(dr1.Item("Cart_customer_pass")) Then strUserPassword = objCryptography.DeCrypt(dr1.Item("Cart_customer_pass"), strGKey)
                    End If
                Catch ex As Exception
                    Throw ex
                End Try

                strCustomerAddressForEmail = strStreet & "<br> " & strTown & "<br>" & strState & "<br>" & strPostCode & "<br>" & strCountry
                PlaceOrder()
                '--------------------------------------------------------------------
            End If ' bSignUp
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        End With ' ServiceOrder
    End Sub

    Private Sub btnCompanyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompanyList.Click

        With listCompany
            If .SelectedIndex < 0 Then
                '-------------------------------------------------------------
                ShowError("Please select the company from the list below.", True)
                '-------------------------------------------------------------
            Else
                '-----------------------------------------------
                Dim objItem As ListItem = .SelectedItem
                Dim objCollection As ArrayList
                Dim structCustomer As CustomerInformation

                If Not Session("UpdateServiceCompanyList") Is Nothing Then
                    objCollection = CType(Session("UpdateServiceCompanyList"), ArrayList)
                    structCustomer = CType(objCollection(.SelectedIndex), CustomerInformation)

                    With structCustomer
                        ProcessCompany(.MemberCustomerID, .LoginID, .CompanyName, .CompanyRegNo)
                    End With
                End If

                Session("UpdateServiceCompanyList") = Nothing

                '-----------------------------------------------
            End If
        End With
    End Sub

#End Region

#Region ":::::::::::::::: Helper Functions/Procedures ::::::::::::::::"

    Private Function VerifyCustomerDetailPanel() As Boolean

        VerifyCustomerDetailPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String

        txtPostCode.Text = UCase(txtPostCode.Text)
        '==========================================================='
        ' Regular Expression syntax:                                '
        ' --              ---              ----      -              '
        ' 00              000              0000      0              '
        ' Category ID     Expression ID    Length    Optional *     '

        '* If field is optional then, value will be 1.              '
        '==========================================================='

        ' Add the controls 
        If ddlCountry.SelectedItem.Text = "United Kingdom" Then
            objRegExp.Add("txtPostCode", "0400200300", "Postcode")
        Else
            If Trim(txtPostCode.Text) = "" Then
                strMsg = "txtPostCode"
            End If
        End If

        objRegExp.Add("txtInvoiceName", "0700502550", "Invoice Name")
        objRegExp.Add("txtSignUpPwd", "0203400160", "Password")
        objRegExp.Add("txtConfirmPassword", "0203400160", "Confirm Password")
        objRegExp.Add("txtStreet", "0700300600", "Street")
        objRegExp.Add("txtTown", "0700300300", "Town")
        objRegExp.Add("txtState", "0700302550", "State")
        objRegExp.Add("txtContactName", "0700302551", "Contact Name")
        objRegExp.Add("txtTelephone", "0700600800", "Telephone")
        objRegExp.Add("txtFax", "0700600801", "Fax")
        objRegExp.Add("txtEmailAddress", "0400302550", "Email")
        objRegExp.Add("txtNotes", "0203502551", "Notes")

        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        If txtSignUpPwd.Text <> txtConfirmPassword.Text Then

            If strMsg = "" Then
                strMsg = ACCMessage.Account_PasswordMatching
            Else
                strMsg &= "," & ACCMessage.Account_PasswordMatching
            End If

            If strReturnMessage = "" Then
                strReturnMessage = strMsg
            Else
                strReturnMessage = strReturnMessage & "," & strMsg
            End If

        End If

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyCustomerDetailPanel = True
            ErrorMessage = ""
        Else
            ' When form controls voilate the business rules
            VerifyCustomerDetailPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
            ucServiceOrder.ShowError(ErrorMessage, True)
        End If

        objRegExp = Nothing

    End Function

    Private Sub SignIn()
        Dim exp As String = "txtuserid-0203400200-You must enter a valid userid,txtpassword-0203402550-You must enter a valid password"
        exp = ApplyRegularExpressions(exp)
        If Len(exp) > 0 Then
            ErrorMessage = exp
            Exit Sub
        End If

        'Dim objCryptography As New Cryptography
        Dim objUser As New User
        SignInAccountsCentreUSer(txtCustomerID.Text, txtPassword.Text)
    End Sub

    Private Sub ProceedContinue()

        pnlAuhtenticate.Visible = False
        pnlSingUp.Visible = False
        pnlCompanyList.Visible = False

        ucServiceOrder.ProceedServicesRegistration()

    End Sub

    Private Sub RegisterUser()

        Dim bCXLResult As Boolean = False
        Dim isRepaySuccess As Boolean = True  ' when there is no repayment

        Dim strRepayment As String
        intTrackID = 0


        With ucServiceOrder

            If .IsRetry Then
                '-----------------------------------------------------
                Dim strMode As String = objCXL.GetPaymentMethodString
                '-----------------------------------------------------

                '-------------------------------------------------------------
                Dim dsUser As DataSet = objUser.GetCustomerData(intCustomerID)
                '-------------------------------------------------------------

                ' Getting Login ID
                If dsUser.Tables.Count > 0 Then
                    '--------------------------------------------------------------
                    If dsUser.Tables(0).Rows.Count > 0 Then
                        strInvoiceName = dsUser.Tables(0).Rows(0).Item(11)
                        strLoginID = dsUser.Tables(0).Rows(0).Item("cart_customer_uid")
                        strEmail = dsUser.Tables(0).Rows(0).Item("Email")
                    End If
                    '--------------------------------------------------------------
                End If

                '-------------------------------------------------------------------------
                dblOrderAmount = 0
                objCXL.CalculateAccProdAmount(intCustomerID, .OrderNumber, dblOrderAmount, intTrackID)
                'dblOrderAmount -= CDbl(ViewState.Item("OrderUpgradeAmount"))
                '-------------------------------------------------------------------------                

                '================================================================================
                ' Comment following lines of code when cxl robot deployed.

                'strStartDate = GetDate(strStartDate)
                'strCardExpires = GetDate(strCardExpires)
                'strEndDate = strCardExpires

                '''''''***********************************************************************************************
                '''''''::::::::::::::::::::::::::::::::::::::Muhammad Ubaid:::::::::::::::::::::::::::::::::::::::::::
                '''''''***********************************************************************************************
                '''''''I have commited following code for retry bug credit card number not found repalce strMode with 
                '''''''strPaymentMode
                '''''''***********************************************************************************************
                '''''''strServiceStatus = objCXL.RepaymentCXL(strReturn, .OrderNumber, intCustomerID, strCreditCardType, strCreditCardNo, _
                '''''''                        strCreditCardName, strCreditCardAddress, strCardExpires, _
                '''''''                                strIssueNo, SecurityCode, strStartDate, strEndDate, _
                '''''''                                strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                '''''''                                dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strMode)

                'strServiceStatus = objCXL.RepaymentCXL(strReturn, .OrderNumber, intCustomerID, strCreditCardType, strCreditCardNo, _
                '                       strCreditCardName, strCreditCardAddress, strCardExpires, _
                '                               strIssueNo, SecurityCode, strStartDate, strEndDate, _
                '                               strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                '                               dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strPaymentMode)

                'Trace.Write("Repayment XML : " & strReturn)
                'Trace.Write("Successfully called RepaymentCXL and return " & strServiceStatus)
                'isRepaySuccess = IsNumeric(strServiceStatus)
                '****************************************************************************************************
                '=======================================================================================

                '========================================================================================
                ' remove comment from following lines of code when cxl robot is not deploy.

                Dim dteCardExpire, dteStartDate As Date
                dteCardExpire = GetDate(strCardExpires)
                dteStartDate = GetDate(strStartDate)

                objCXL.UpdateInvoiceInfo(.OrderNumber, strCardType, strCardName, strCardNo, strCardAddress, dteCardExpire, strIssueNo, SecurityCode, dteStartDate, dteCardExpire, strBankName, strChequeNo, strSortCode, strBankTranRefNo)
                isRepaySuccess = True
                '============================================================================================================

                strRepayment = "r"
                '----------------------------------------------------------------------------------------------------------

            Else 'for .IsRetry
                '----------------------------------------------------------------------------------------------------------
                strMsg = objUser.AddCustomer(intCustomerID, strAc, "strSurName", strInvoiceName, "strSecondName", strStreet, _
                                     strTown, strCountryCode, strCountry, strPostCode, strContName, strPh, _
                                     strFax, strEmail, strNotes, strUID, strEncryptPassword, strState, strTime, _
                                     strFnew, strFModified, strStoreName, lngMerchantID, strGKey, strEncryptKey, _
                                     intRndNo, strOrderNo, strDeliveryAddress, strCustPh, dblDiscount, strFShipped, _
                                     dteOrderDate, dtePromiseShipDate, strCardType, strCardNo, strCardName, _
                                     strCardExpires, strCardAddress, strCustomerAddress, dblOrderAmount, _
                                     strStartDate, strEndDate, SecurityCode, strIssueNo, strPayProcessBy, _
                                     strBankName, strChequeNo, strSortCode, strBankTranRefNo, strWintiprocess, _
                                     strProductCodes, intParentCustomerID, bolAsExcluded, strCompaign)

                strLoginID = intRndNo & intCustomerID
                '----------------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------
                ucServiceOrder.OrderNumber = objCXL.GetLastOrderNo(intCustomerID)
                UpdateSalePrice()
                strRepayment = "n"
                '-----------------------------------------------------------------------
            End If '.IsRetry
            '--------------------------------------------------------------------    

            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : CustomerID is not equal to ZERO IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            If intCustomerID <> 0 Then

                .CustomerID = intCustomerID

                '---------------------------------------------------------------------
                Dim strCompanyName As String = CStr(Session("ACC_GV_ProcessCompany"))
                Dim strCompanyNumber As String = CStr(Session("ACC_GV_CompanyNumber"))
                Session("ACC_GV_ProcessCompany") = Nothing
                Session("ACC_GV_CompanyNumber") = Nothing
                '---------------------------------------------------------------------

                '-----------------------------------------------------------------------------
                objUser.LoadAccountscetreUser(intCustomerID, strCompanyName, strCompanyNumber)
                '-----------------------------------------------------------------------------


                If (Not (Session("ACC_GV_RegistrationMode") Is Nothing)) And (Not .IsRetry) Then
                    '------------------------------------------------------------------------------------------------------------
                    objUser.UpdateFormationsHouseSubAccount(strCompanyName, strCompanyNumber, intCustomerID, intParentCustomerID)
                    objUser.UpdateCompStatus(intCustomerID, 2)
                    '------------------------------------------------------------------------------------------------------------
                End If


                '----------------------------------------------------------------
                Dim isEnableService As Boolean
                If isRepaySuccess Then
                    '================================================================================
                    ' Comment following lines of code when cxl robot deployed.
                    'bCXLResult = CallCXLProcessing(intCustomerID, strPaymentMode, isEnableService)
                    '================================================================================

                    '========================================================================================
                    ' remove comment from following lines of code when cxl robot is not deploy.
                    'Dim sw As System.IO.StreamWriter
                    'sw = System.IO.File.CreateText("d:\cardDate.txt")
                    'sw.WriteLine("Start Date: " & strStartDate & " -- Expire Date: " & strCardExpires)
                    'sw.Close()
                    CXLProcessing.InsertOrderIntoCxlRobot(.IsCreditCard, strLoginID, .OrderNumber, dblOrderAmount, .IsRetry, .CardNumber, .CreditCard, .CreditCard, .CardAddress, .SecurityCode, .IssueNumber, "826", "GBP", strStartDate, strCardExpires, intTrackID)
                    bCXLResult = False
                    '========================================================================================
                Else
                    ShowError("Some information is missing please give correct information. " & strServiceStatus, True)
                    objCXL.AccInsertPaymentErrorLog(CustomerID, .OrderNumber, Now, 0, strServiceStatus)
                    bCXLResult = True
                End If
                '----------------------------------------------------------------

                If Not bCXLResult Then
                    '--------------------------------------------------------------------------------------------------------
                    Dim colSelectedServices As NameValueCollection = GetSelectedProducts(False, .PackagesGrid, .ProductsGrid)
                    Dim InfoMsg As String = CommonBase.EmailMessages(ACC_Email_Messages.New_Account_Email_Template)
                    Dim strPurchasedServiceList = CommonBase.CreateList(colSelectedServices)
                    '--------------------------------------------------------------------------------------------------------

                    '----------------------------------------------------------------------------------------------
                    InfoMsg = InfoMsg.Replace("[Name]", strInvoiceName)
                    InfoMsg = InfoMsg.Replace("[LoginID]", strLoginID)
                    InfoMsg = InfoMsg.Replace("[Password]", txtSignUpPwd.Text)
                    InfoMsg = InfoMsg.Replace("[ServicesInformation]", strPurchasedServiceList)
                    InfoMsg = InfoMsg.Replace("[Address]", strEmail)
                    .ShowMessage(InfoMsg, True)
                    '----------------------------------------------------------------------------------------------

                    '----------------------------------------------------------------
                    Dim strServicesInformation As String = .ProdcutPackageXML(, True)
                    strTo = strEmail.ToString
                    '----------------------------------------------------------------

                    'If Not Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then
                    '-----------------------------------------------------------------------------------------------------
                    strSubject = ACCMessage.Email_AccountRegistration
                    strBody = "Dear valued customer," & vbCrLf & vbCrLf & _
                    "We have received your account information provided by you through " & vbCrLf & _
                    "http://www.accountscentre.com" & vbCrLf & vbCrLf & _
                    "Your request of account activation is under process and you will receive a " & _
                    "user id and password for login purposes via another email within 24 hours. " & vbCrLf & vbCrLf & _
                    "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
                    "Email:   support@AccountsCentre.com" & vbCrLf & _
                    "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"
                    '-----------------------------------------------------------------------------------------------------

                    '------------------------------------------------------------------------------
                    Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
                    SendEmail(True, colSelectedServices, strPurchasedServiceList, strBCC, isEnableService)
                    '------------------------------------------------------------------------------

                    '--------------------------------------------------------------------------------------------------------------------------------
                    Dim strFullName As String = strInvoiceName
                    Dim LoginID As String = intRndNo & intCustomerID
                    Dim strTemplateSubject As String = EmailSubject()
                    strBody = SelectEmailContent("ACSA", strFullName, LoginID, txtSignUpPwd.Text, strCustomerAddressForEmail, strPurchasedServiceList)
                    '--------------------------------------------------------------------------------------------------------------------------------

                    '--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                         ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                         strTemplateSubject, strBody.ToString, MailFormat.Html, strBCC) = "" Then
                        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                    Else
                        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                    End If
                End If 'mail send
            End If
            '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END : CustomerID is not equal to ZERO IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            '============= NEW MODIFICATION FOR RETRY PAYMENT =======================

            If bCXLResult Then
                '---------------------------------
                lblCustomerID.Text = intCustomerID
                .OrderSucces(False)
                '---------------------------------
            Else
                Session.Remove(Me.ACC_ISFORMCOMPLETED)
                Session.Remove(Me.ACC_ORDER_HERE_LINK)
                Session.Remove(Me.ACC_ORDER_HERE_COMPAIGN)
                .OrderSucces(True)
            End If

            .ControlsDiable()

        End With ' ucServiceOrder
    End Sub

    Private Sub UpdateSalePrice()
        Dim ht As Hashtable = CType(viewstate.Item("HashTableUpgradeList"), Hashtable)
        Dim strProdCode As String, salePrice As Double

        If ht Is Nothing OrElse ht.Count < 1 Then
            Exit Sub
        End If

        For Each obj As Object In ht.Keys
            strProdCode = CStr(obj)
            salePrice = CDbl(ht(strProdCode))
            objCXL.UpdateSalePrice(ucServiceOrder.OrderNumber, strProdCode, salePrice)
        Next
    End Sub

    Private Sub PlaceOrder()
        Dim objTemplate As New TemplateReader
        Dim bCXLResult As Boolean = False
        Dim isRepaySuccess As Boolean = True  ' when there is no repayment
        Dim strFrom, strRepayment As String
        intCustomerID = CustomerID
        intTrackID = 0

        With ucServiceOrder
            .CustomerID = CustomerID

            If .IsRetry Then
                '------------------------------------------------------------------------
                Dim strMode As String = objCXL.GetPaymentMethodString
                dblOrderAmount = 0
                objCXL.CalculateAccProdAmount(intCustomerID, .OrderNumber, dblOrderAmount, intTrackID)
                dblOrderAmount -= CDbl(ViewState.Item("OrderUpgradeAmount"))
                '-------------------------------------------------------------------------
                strStartDate = GetDate(strStartDate)
                strCardExpires = GetDate(strCardExpires)
                strEndDate = strCardExpires


                '***********************************************************************************************
                '::::::::::::::::::::::::::::::::::::::Muhammad Ubaid:::::::::::::::::::::::::::::::::::::::::::
                '***********************************************************************************************
                'I have commited following code for retry bug credit card number not found repalce strMode with 
                'strPaymentMode
                '***********************************************************************************************

                'strServiceStatus = objCXL.RepaymentCXL(strReturn, .OrderNumber, intCustomerID, strCreditCardType, strCreditCardNo, _
                '                        strCreditCardName, strCreditCardAddress, strCardExpires, _
                '                                strIssueNo, SecurityCode, strStartDate, strEndDate, _
                '                                strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                '                                dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strMode)
                strServiceStatus = objCXL.RepaymentCXL(strReturn, .OrderNumber, intCustomerID, strCreditCardType, strCreditCardNo, _
                                        strCreditCardName, strCreditCardAddress, strCardExpires, _
                                                strIssueNo, SecurityCode, strStartDate, strEndDate, _
                                                strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                                                dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strPaymentMode)

                '***********************************************************************************************


                'Dim dteCardExpire, dteStartDate As Date
                'dteCardExpire = GetDate(strCardExpires)
                'dteStartDate = GetDate(strStartDate)


                'objCXL.UpdateInvoiceInfo(.OrderNumber, strCardType, strCardName, strCardNo, strCardAddress, dteCardExpire, strIssueNo, SecurityCode, dteStartDate, dteCardExpire, strBankName, strChequeNo, strSortCode, strBankTranRefNo)

                isRepaySuccess = IsNumeric(strServiceStatus)
                strRepayment = "r"
            Else
                '  dblOrderAmount -= CDbl(ViewState.Item("OrderUpgradeAmount"))
                '--------------------------------------------------------------------------------------------------------------------
                objUser.InsertInvoice(intCustomerID, strAc, strTime, strFnew, strOrderNo, strDeliveryAddress, strCustPh, _
                                      dblDiscount, strFShipped, dteOrderDate, dtePromiseShipDate, strCardType, strCardNo, _
                                      strCardName, strCardExpires, strCardAddress, strCustomerAddress, dblOrderAmount, _
                                      strStartDate, strEndDate, SecurityCode, strIssueNo, strPayProcessBy, strBankName, _
                                      strChequeNo, strSortCode, strBankTranRefNo, strWintiprocess, strProductCodes, strCompaign)
                '--------------------------------------------------------------------------------------------------------------------

                '-----------------------------------------------------------------------
                ucServiceOrder.OrderNumber = objCXL.GetLastOrderNo(intCustomerID)
                UpdateSalePrice()
                strRepayment = "n"
                '-----------------------------------------------------------------------
            End If

            If intCustomerID <> 0 Then
                '--------------------------------------------
                objUser.LoadAccountscetreUser(CustomerID)
                FillExpiryRelatedSessionVariables(CustomerID)
                '--------------------------------------------

                '----------------------------------------------------------------
                Dim strServicesInformation As String = .ProdcutPackageXML(, True)
                Dim isEnableService As Boolean
                Dim strPurchasedServiceList = CommonBase.CreateList(GetSelectedProducts(False, .PackagesGrid, .ProductsGrid))
                '----------------------------------------------------------------

                '------------------------------------------------------------------------------------------------------
                If isRepaySuccess Then
                    '====================== NEW CHANGE ======================'
                    ' Date          : 28th Feb. 2006
                    ' Reason        : Automatically order process by ROBOT
                    ' Modified by   : Abid Ali
                    '========================================================'

                    ' Before Change i.e. calling CXL from ishop webservices
                    'bCXLResult = CallCXLProcessing(strLoginID, strPaymentMode, isEnableService)

                    CXLProcessing.InsertOrderIntoCxlRobot(.IsCreditCard, strLoginID, .OrderNumber, dblOrderAmount, .IsRetry, .CardNumber, .CreditCard, .CreditCard, .CardAddress, .SecurityCode, .IssueNumber, "826", "GBP", strStartDate, strCardExpires, intTrackID)
                    'New change
                    'bCXLResult = False
                Else
                    ShowError("Some information is missing please give correct information. " & strServiceStatus, True)
                    objCXL.AccInsertPaymentErrorLog(CustomerID, .OrderNumber, Now, 0, strServiceStatus)
                    bCXLResult = True
                End If
                '------------------------------------------------------------------------------------------------------


                If Not bCXLResult Then
                    '----------------------------------------------
                    strTo = strEmail.ToString
                    strFrom = ACCMessage.Email_DefaultEmailAddress
                    strSubject = ACCMessage.Email_UpdateServices
                    '----------------------------------------------

                    '--------------------------------------------------
                    Dim strEmailTemplate As String
                    Dim strTemplateSubject As String, intActive As Integer
                    Dim dsEmailContent As DataSet
                    '--------------------------------------------------

                    '---------------------------------------------------------------------
                    dsEmailContent = objTemplate.SelectEmailContent("ACRW")
                    strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
                    strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
                    '---------------------------------------------------------------------

                    '-----------------------------------------------------------------------------
                    Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
                    strbuilder.Replace("[Name]", strInvoiceName).ToString()
                    strbuilder.Replace("[LoginID]", strLoginID).ToString()
                    strbuilder.Replace("[Address]", strCustomerAddress).ToString()
                    strbuilder.Replace("[ServicesInformation]", strPurchasedServiceList).ToString()
                    '------------------------------------------------------------------------------

                    '--------------------------------------------------------------------------------------------------------
                    Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
                    SendEmail(False, GetSelectedProducts(False, .PackagesGrid, .ProductsGrid), strPurchasedServiceList, strBCC, True)
                    '--------------------------------------------------------------------------------------------------------
                End If
                '--------------------------------------------------------------------------------------------------------------------
            End If

            '============= NEW MODIFICATION FOR RETRY PAYMENT =======================



            If bCXLResult Then
                '---------------------------------
                lblCustomerID.Text = CustomerID
                .OrderSucces(False)
                '---------------------------------
            Else
                .ShowMessage(ACCMessage.Account_UpdateCustomerServices, True)
                Session.Remove(Me.ACC_ISFORMCOMPLETED)
                Session.Remove(Me.ACC_ORDER_HERE_LINK)
                Session.Remove(Me.ACC_ORDER_HERE_COMPAIGN)
                .OrderSucces(True)
            End If

            .ControlsDiable()
        End With ' ucServerOrder
    End Sub

    Public Function SelectEmailContent(ByVal TemplateName As String, ByVal Name As String, ByVal strLoginID As String, Optional ByVal strpassword As String = "", Optional ByVal strCustomerAddress As String = "", Optional ByVal strServicesInformation As String = "") As String
        Dim objTemplate As New TemplateReader
        Dim strFullName As String = Name 'strSurName & strFirstName & strSecondName
        Dim LoginID As String = strLoginID 'intRndNo & intCustomerID
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent(TemplateName)
        strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")

        Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
        strbuilder.Replace("[Name]", strFullName).ToString()
        strbuilder.Replace("[LoginID]", LoginID).ToString()
        strbuilder.Replace("[Password]", strpassword).ToString()
        strbuilder.Replace("[Address]", strCustomerAddress).ToString()
        strbuilder.Replace("[ServicesInformation]", strServicesInformation).ToString()
        strbuilder.Replace("[OrderID]", ucServiceOrder.OrderNumber).ToString()
        strbuilder.Replace("\Administration\images\logo.jpg", "https:\\www.accountscentre.com\images\logo.jpg")
        Return strbuilder.ToString

    End Function

    Public Function EmailSubject() As String
        Dim objTemplate As New TemplateReader
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent("LGIN")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        Return strTemplateSubject

    End Function

    Private Sub PrepareCompanyList()
        '------------------------------------------------------------
        PrepareMe()
        If listCompany.Items.Count >= 1 Then
            pnlCompanyList.Visible = True
            pnlAuhtenticate.Visible = False
        End If
        '------------------------------------------------------------
    End Sub

    Private Sub PrepareMe(Optional ByVal bRefreshCombo As Boolean = False, Optional ByVal sGVStatusFilter As String = "NA")
        '-------------------------------------------

        Session("ACC_GV_ProcessCompany") = Nothing
        Session("ACC_GV_CompanyNumber") = Nothing
        '-------------------------------------------

        'Session vars are being expired after some time but do not redirect to Sign in page
        'and it keeps itself signed in so in this case its redirected to sign out page.

        If Session("ACC_GV_ParentCustomerID") Is Nothing Then
            '----------------
            SignInTheParent()
            '----------------
        End If

        '---------------------------------------------------------------------------
        Trace.Write("Appending the Dataview with Companies Info")
        Trace.Write("Parent Customer ID" & Session("ACC_GV_ParentCustomerID") & ".")
        '---------------------------------------------------------------------------

        '---------------------------------------------------------------------------------------------------------------------
        Dim objGlobalView As New GlobalView
        dtCompanies = objGlobalView.getAllCompaniesByFH(Session("ACC_GV_ParentCustomerID"), Session("ACC_GV_Companies"), True)
        dvCompanies = dtCompanies.DefaultView
        '---------------------------------------------------------------------------------------------------------------------

        '-------------------------------------------------------------------------
        Trace.Write("start sorting the filering values")

        If sGVStatusFilter = "NA" Then : dvCompanies.RowFilter = ""
        Else : dvCompanies.RowFilter = sGVStatusFilter : End If

        Trace.Write("start sorting the grid values")

        dvCompanies.Sort = "CompName"
        '-------------------------------------------------------------------------

        Trace.Write("Pass the sorting func and entering into Postback condition")


        If Not bRefreshCombo Then
            '-----------------------------------------------------------------
            GetGlobalViewCompaniesAndInfo(Session("ACC_GV_ParentCustomerID"))
            Trace.Write("Pass Formationshouse webservice status message")
            '-----------------------------------------------------------------

            If dvCompanies.Count > 0 Then
                '--------------------------------------------------------------
                Trace.Write("Entering into Companies greater than 0 condtion")



                Dim sCompanyName As String
                If IsDBNull(Session("ACC_GV_LastAddedCompName")) = False Then
                    sCompanyName = CStr(Session("ACC_GV_LastAddedCompName"))
                Else
                    sCompanyName = ""
                End If


                Session("ACC_GV_LastAddedCompName") = Nothing

                ProcessIfUserCanBeAddedToGlobalView()

                Trace.Write("Passing ProcessIfUserCanBeAddedToGlobalView fucntion")

                '----------------
                ShowCompanyList()
                '----------------

                Trace.Write("Passing ShowSummaryInformation fucntion")


            Else
                '------------------------------------------------
                CreateGlobalView()
                Trace.Write("Passing CreateGlobalView fucntion")
                '------------------------------------------------
            End If
        End If

        Trace.Write("Exit from all functions")

    End Sub

    Private Sub ShowCompanyList()
        '----------------------------------
        Dim dr As DataRow
        Dim objListItem As ListItem
        Dim strMCID As String
        Dim strCompRegNo, strLID, strCompName As String
        Dim objCollection As New ArrayList
        Dim objCustInfo As CustomerInformation
        Dim index As Integer = 1
        '----------------------------------

        ' If there is only one company then there is no need to resign in again
        'If dtCompanies.Rows.Count = 1 Then
        '    ShowPaymentMethod()
        '    Exit Sub
        'End If

        For Each dr In dtCompanies.Rows
            '--------------------------------------------------------------------------
            Trace.Write("ShowCompanyList ::: Start to Extract Company's values")
            strMCID = IIf(IsDBNull(dr("MemberCustomerID")), "", dr("MemberCustomerID"))
            strCompRegNo = IIf(IsDBNull(dr("CompRegNo")), "", dr("CompRegNo"))
            strCompName = IIf(IsDBNull(dr("CompName")), "Your Company Name", dr("CompName"))
            strLID = IIf(IsDBNull(dr("cart_customer_uid")), "NOT ADDED", dr("cart_customer_uid"))
            Trace.Write("ShowCompanyList ::: End of Extract Company's values")
            '--------------------------------------------------------------------------

            '----------------------------------------------------------------------------------------
            objCustInfo = New CustomerInformation(strLID, strCompName, strMCID, strCompRegNo)
            objCollection.Add(objCustInfo)

            Trace.Write("ShowCompanyList [ Row " & index & " ] ---> " & objCustInfo.ToString)
            index += 1
            '----------------------------------------------------------------------------------------

            '----------------------------------------------------------------------
            Trace.Write("ShowCompanyList ::: Start to Add Company into List box")
            objListItem = New ListItem(strCompName, strCompName)
            objListItem.Selected = False

            listCompany.Items.Add(objListItem)
            Trace.Write("ShowCompanyList ::: End of Add Company into List box")
            '----------------------------------------------------------------------

        Next

        '--------------------------------------------------
        Session("UpdateServiceCompanyList") = objCollection
        '--------------------------------------------------
    End Sub

    Private Sub SignInTheParent()
        '--------------------------------------------------------------------
        Dim sParentUserUID As String = ParentUserID
        FormsAuthentication.SignOut()
        SignInAccountsCentreUSer(sParentUserUID, "DUMMYPASSWORD", True, True)
        '--------------------------------------------------------------------
    End Sub

    Private Sub GetGlobalViewCompaniesAndInfo(ByVal CustomerID As Int32)
        '---------------------------------------------------
        Dim sqlDR As SqlDataReader
        Dim objGlobalView As New GlobalView
        sqlDR = objGlobalView.GetUserInformation(CustomerID)
        '---------------------------------------------------

        If sqlDR.Read() Then
            '-----------------------------------------------------
            Session("ACC_GV_RegCompCount") = sqlDR("TotalRegComp")
            Session("ACC_GV_ExcCompCount") = sqlDR("TotalExcComp")
            '-----------------------------------------------------
        Else
            '----------------------------------
            Session("ACC_GV_RegCompCount") = 0
            Session("ACC_GV_ExcCompCount") = 0
            '----------------------------------
        End If

        If Not sqlDR Is Nothing Then
            '-------------------------------------------
            If sqlDR.IsClosed = False Then sqlDR.Close()
            sqlDR = Nothing
            '-------------------------------------------
        End If
    End Sub

    Private Sub ProcessIfUserCanBeAddedToGlobalView()
        '-----------------------------------------------------
        Dim objGlobalView As New GlobalView
        Dim iCustomerID As Integer

        If Session("ACC_GV_ParentCustomerID") <> Nothing Then
            iCustomerID = Session("ACC_GV_ParentCustomerID")
        Else
            iCustomerID = CustomerID
        End If
        '-----------------------------------------------------

        '---------------------------------------------------------------------------------------------------
        Dim sqlDRParentUser As SqlDataReader = objGlobalView.GetParentUserGlobalViewStatus(iCustomerID) 'OK
        If sqlDRParentUser.Read() Then
            If sqlDRParentUser.Item(1) <> 0 Then
                GoTo B4End
            End If
        End If
        '---------------------------------------------------------------------------------------------------
B4End:
        '--------------------------------------
        If Not sqlDRParentUser Is Nothing Then
            sqlDRParentUser.Close()
            sqlDRParentUser = Nothing
        End If
        '--------------------------------------
    End Sub

    Private Function CreateGlobalView() As Boolean
        '--------------------------------------------------------------
        Dim sResult As String
        Dim objGlobalView As New GlobalView
        sResult = objGlobalView.AddInGlobalView(CustomerID, CustomerID)
        '--------------------------------------------------------------

        '---------------------
        If sResult = "" Then
            PrepareMe(True)
            Return True
        Else
            Return False
        End If
        '---------------------
    End Function

    Private Sub ProcessCompany(ByVal sRegisteredID As String, ByVal sRegisteredUserID As String, ByVal sCompName As String, ByVal sCompNumber As String)

        '-------------------------------------
        Dim strDummyPassword = "DUMMYPASSWORD"
        '-------------------------------------

        If IsNumeric(sRegisteredID) AndAlso sRegisteredID <> "NOT ADDED" Then
            '-----------------------------------------------------------------------------
            'Signout and Signin Child Company
            If (sRegisteredID <> CustomerID) Then
                FormsAuthentication.SignOut()
                SignInAccountsCentreUSer(sRegisteredUserID, strDummyPassword, True, True)
            End If

            ' Old Update service's style from here for the selected company
            Dim strRenewProducts As String
            If Not CheckOrder(strRenewProducts) Then
                ShowMessage(strRenewProducts, True)
            End If

            ProceedContinue()
            '-----------------------------------------------------------------------------
        Else
            'Sign in the parent!
            'SignInTheParent()
            Session("ACC_GV_ProcessCompany") = sCompName
            Session("ACC_GV_CompanyNumber") = sCompNumber
            Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView
            'Response.Redirect("/Account/NewCustomer.aspx")
            RegisterFHUser()
        End If
    End Sub

    Private Sub RegisterFHUser()

        lblStatus.Text = "SignUp"
        pnlAuhtenticate.Visible = False
        pnlSingUp.Visible = True
        pnlCompanyList.Visible = False

        BindCountry(ddlCountry)

        If Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then
            trPassword.Visible = False
            trPasswordConfirm.Visible = False
        End If

        If Not (Session("ACC_GV_RegistrationMode") Is Nothing) Then
            '''''Dim oUser As New User
            '''''Dim strCompanyNumber As String = CStr(Session("ACC_GV_CompanyNumber"))
            '''''If oUser.CheckDuplicateCompStatus(strCompanyNumber) = False Then
            '''''    ErrorMessage = "Company with the given Registeration number '" & strCompanyNumber & "' is already a verifi"
            '''''End If
            GetCustomerInformation()


            Session(Me.ACC_ISFORMCOMPLETED) = Boolean.FalseString
        End If

        If Session(Me.ACC_ISFORMCOMPLETED) = "" Then Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Home))
    End Sub

    Private Sub GetCustomerInformation()

        ' RETRIEVING CUSTOMER'S DETAILS

        Dim ds = New DataSet
        Dim objUser As New User
        Dim strName As String

        ds = objUser.GetCustomerData(CInt(Session("ACC_GV_ParentCustomerID")))

        If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
            ' set the result of data row
            Dim dt1 As DataTable = ds.Tables(0)
            Dim dr1 As DataRow = dt1.Rows(0)

            With dr1

                If Not IsDBNull(.Item("Street")) Then txtStreet.Text = .Item("Street")
                If Not IsDBNull(.Item("Town")) Then txtTown.Text = .Item("Town")
                If Not IsDBNull(.Item("State")) Then txtState.Text = .Item("State")
                If Not IsDBNull(.Item("Postcode")) Then txtPostCode.Text = .Item("Postcode")
                If Not IsDBNull(.Item("Telephone")) Then txtTelephone.Text = .Item("Telephone")
                If Not IsDBNull(.Item("Email")) Then txtEmailAddress.Text = .Item("Email")
                If Not IsDBNull(.Item("ContactName")) Then txtContactName.Text = .Item("ContactName")
                If Not IsDBNull(.Item("Fax")) Then txtFax.Text = .Item("Fax")
                If Not IsDBNull(.Item("Notes")) Then txtNotes.Text = .Item("Notes")
                If Not IsDBNull(.Item("Name")) Then strName = .Item("Name")

            End With

            '---------------------------
            txtInvoiceName.Text = strName
            '---------------------------

            If Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then
                GetPassword()
                txtConfirmPassword.Text = txtSignUpPwd.Text
            End If

        End If

    End Sub

    Private Sub GetPassword()

        Randomize()
        txtSignUpPwd.Text = CInt(Int(90 * Rnd()) + 10)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtSignUpPwd.Text = txtPassword.Text & CInt(Int(90 * Rnd()) + 10)

    End Sub

    Public Function CheckOrder(ByRef RenewProducts As String) As Boolean
        Dim result As Boolean = True
        Dim ds As DataSet
        Dim strProduct As String
        Dim htPurchasedProduct As New Hashtable

        Dim hTable As Hashtable = GetProducts(ucServiceOrder.PackagesGrid, ucServiceOrder.ProductsGrid)

        ds = objUser.ACC_UpdatePackageProductDetails(CustomerID, PackageOptions.EnableSale, _
                                                    ServiceOptions.EnableSale)



        If hTable.Count > 0 Then
            Dim index As Integer
            'RenewProducts = "Renewable Package(s)/Product(s).<bR><br><ui>"

            For index = 2 To 3
                With ds.Tables(index)
                    For Each dtRow As DataRow In .Rows
                        strProduct = dtRow.Item("ProductCode")
                        htPurchasedProduct.Add(strProduct, dtRow.Item("ProductName") & "#" & dtRow.Item("Status") & "#" & dtRow.Item("Sale_Price"))

                        'If hTable.Contains(strProduct) Then
                        '    result = False
                        '    RenewProducts &= "," & dtRow.Item("ProductName")
                        'End If
                    Next
                End With
            Next

            'RenewProducts = Replace(RenewProducts, ",", "<li>") & "</ui>"
        End If

        If GetUpgradeProducts(hTable, htPurchasedProduct, RenewProducts) Then
            result = False
        End If

        Return result
    End Function

    Private Function GetUpgradeProducts(ByVal htProduct As Hashtable, ByVal htPurchased As Hashtable, ByRef ReturnString As String) As Boolean

        Dim strProduct, renewProducts, upgradeProducts As String
        Dim index As Integer, upgradeAmount, dblProductAmount As Double, dtTable As DataTable
        Dim dv As DataView, strProdValues(), strSelectedProd() As String
        Dim isAnyRenew, isAnyUpgrade As Boolean
        Dim htUpgradeList As New Hashtable


        upgradeAmount = 0
        renewProducts = "Renewable Package(s)/Product(s).<bR><br><ui>"
        upgradeProducts = "Upgraded Package(s)/Product(s).<bR><br><ui>"

        dtTable = objCXL.GetProductUpgrade()

        For Each obj As Object In htProduct.Keys
            strProduct = CStr(obj)

            If htPurchased.Contains(strProduct) Then
                strProdValues = Split(htPurchased(strProduct), "#")
                renewProducts &= "," & strProdValues(0)
                isAnyRenew = True
            Else

                For Each dr As DataRow In dtTable.Rows
                    'If strProduct = dr("ParentProdCode") Then
                    '    If htPurchased.Contains(strProduct) Then
                    '        strProdValues = Split(htPurchased(strProduct), "#")
                    '        renewProducts &= "," & dr("ParentProductName")
                    '        isAnyRenew = True
                    '        Exit For
                    '    End If
                    'End If

                    If strProduct = dr("ProductCode") Then
                        If htPurchased.Contains(dr("ParentProdCode")) Then
                            strProdValues = Split(htPurchased(dr("ParentProdCode")), "#")
                            strSelectedProd = Split(htProduct(strProduct), "#")
                            If strProdValues(1) <> 2 Then
                                upgradeProducts &= "," & dr("ProductName")
                                upgradeAmount += dr("ParentSalePrice")
                                dblProductAmount = CDbl(strSelectedProd(1)) - CDbl(dr("ParentSalePrice"))
                                htUpgradeList.Add(strProduct, dblProductAmount.ToString)
                                isAnyUpgrade = True
                            Else
                                renewProducts &= "," & strProdValues(0)
                                isAnyRenew = True
                            End If
                            Exit For
                        End If
                    End If
                Next

            End If
        Next

        viewstate.Add("HashTableUpgradeList", htUpgradeList)
        viewstate.Add("OrderUpgradeAmount", upgradeAmount.ToString)

        ReturnString = ""

        If isAnyRenew Then
            ReturnString = renewProducts & "</ui>"
        End If

        If isAnyUpgrade Then
            If ReturnString = "" Then
                ReturnString = upgradeProducts
            Else
                ReturnString &= "<br><br>" & upgradeProducts & "</ui>"
            End If
        End If

        ReturnString = Replace(ReturnString, ",", "<li>")

        Return (isAnyRenew Or isAnyUpgrade)

    End Function

    Private Function GetProducts(ByVal ParamArray Grid() As DataGrid) As Hashtable
        Dim hTable As New Hashtable(20)

        For Each dgrid As DataGrid In Grid
            For Each dgItem As DataGridItem In dgrid.Items
                Dim myCheckbox As CheckBox = CType(dgItem.Cells(0).Controls(1), CheckBox)

                If myCheckbox.Checked Then
                    Dim dblProdAmount = CDbl(Mid(dgItem.Cells(3).Text, 2))
                    hTable.Add(dgItem.Cells(4).Text.Trim, dgItem.Cells(4).Text.Trim & "#" & dblProdAmount)
                End If
            Next
        Next

        Return hTable

    End Function

    Private Sub SendEmail(ByVal IsNewCustomer As Boolean, ByVal colSelectedServices As NameValueCollection, ByVal strServicesInformation As String, ByVal strBCC As String, ByVal IsEnableService As Boolean)

        Dim templateName As String


        If ucServiceOrder.IsCreditCard Then
            If IsEnableService Then
                ' by credit card
                '-------------------------------------------------------------------------
                If IsNewCustomer Then
                    templateName = "ACCP"
                    Dim pdfLinkProduct As String = Session("special_pdf_products")
                    If pdfLinkProduct = Nothing Then pdfLinkProduct = ""
                    If pdfLinkProduct.Length > 0 Then
                        If pdfLinkProduct.Equals("108") Then
                            strServicesInformation = strServicesInformation + "<br></b></strong>In order to access the InfiniPlan user manual, kindly visit:<br><a href='http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf'>http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf</a>"
                            Session("special_pdf_products") = ""
                        End If
                    End If
                    strBody = SelectEmailContent(templateName, strInvoiceName, strLoginID, strUserPassword, strCustomerAddressForEmail, strServicesInformation)
                Else
                    templateName = "LGIN"
                    Dim pdfLinkProduct As String = Session("special_pdf_products")
                    If pdfLinkProduct = Nothing Then pdfLinkProduct = ""
                    If pdfLinkProduct.Length > 0 Then
                        If pdfLinkProduct.Equals("108") Then
                            strServicesInformation = strServicesInformation + "<br></b></strong>In order to access the InfiniPlan user manual, kindly visit:<br><a href='http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf'>http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf</a>"
                            Session("special_pdf_products") = ""
                        End If
                    End If
                    strBody = SelectEmailContent(templateName, strInvoiceName, strLoginID, strUserPassword, strCustomerAddressForEmail, strServicesInformation) ' Me.SendEmailForServiceEnable(intCustomerID, colSelectedServices)
                End If
                '-------------------------------------------------------------------------

                '-------------------------------------------------------------------------------------------------------------
                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                     strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html, strBCC) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If
                '-------------------------------------------------------------------------------------------------------------
            Else
                '-----------------------------------
                If IsNewCustomer Then
                    templateName = "ACSA"
                    Dim pdfLinkProduct As String = Session("special_pdf_products")
                    If pdfLinkProduct = Nothing Then pdfLinkProduct = ""
                    If pdfLinkProduct.Length > 0 Then
                        If pdfLinkProduct.Equals("108") Then
                            strServicesInformation = strServicesInformation + "<br></b></strong>In order to access the InfiniPlan user manual, kindly visit:<br><a href='http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf'>http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf</a>"
                            Session("special_pdf_products") = ""
                        End If
                    End If
                    strBody = SelectEmailContent(templateName, strInvoiceName, strLoginID, strUserPassword, strCustomerAddressForEmail, strServicesInformation)
                Else
                    templateName = "AUSA"
                    Dim pdfLinkProduct As String = Session("special_pdf_products")
                    If pdfLinkProduct = Nothing Then pdfLinkProduct = ""
                    If pdfLinkProduct.Length > 0 Then
                        If pdfLinkProduct.Equals("108") Then
                            strServicesInformation = strServicesInformation + "<br></b></strong>In order to access the InfiniPlan user manual, kindly visit:<br><a href='http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf'>http://www.accountscentre.com/manuals/IPlan-UserGuide.pdf</a>"
                            Session("special_pdf_products") = ""
                        End If
                    End If
                    strBody = SelectEmailContent(templateName, strInvoiceName, strLoginID, strUserPassword, strCustomerAddressForEmail, strServicesInformation) 'Me.SendEmailForServiceEnable(intCustomerID, colSelectedServices, , templateName)
                End If
                '-----------------------------------

                '--------------------------------------------------------------------------------------------------------------------------------------
                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                     strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html, strBCC) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If
                '--------------------------------------------------------------------------------------------------------------------------------------
            End If
        Else
            ' by bank 
            '-----------------------------------
            If IsNewCustomer Then
                templateName = "ACBP"
            Else
                templateName = "AUBP"
            End If
            '-----------------------------------

            '--------------------------------------------------------------------------------------------------------------------------------------
            strBody = SelectEmailContent(templateName, strInvoiceName, strLoginID, strUserPassword, strCustomerAddressForEmail, strServicesInformation)
            '--------------------------------------------------------------------------------------------------------------------------------------

            '--------------------------------------------------------------------------------------------------------------------------------------
            If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                 strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html, strBCC) = "" Then
                EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            Else
                EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            End If
            '--------------------------------------------------------------------------------------------------------------------------------------
        End If
        Session("special_pdf_products") = ""
    End Sub

    Private Function GetDate(ByVal DateValue As String) As Date
        Dim strExpiry() As String = Split(DateValue, "/")
        Dim dteCardExpire As New Date(strExpiry(2), strExpiry(0), strExpiry(1))

        Return dteCardExpire
    End Function
#End Region

#Region ":::::::::::::::: CXL Implementation ::::::::::::::::"

    Private Function CallCXLProcessing(ByVal CustID As Integer, ByVal PaymentMode As String, Optional ByRef IsEnableService As Boolean = False) As Boolean


        '**************************************************************************************************
        '**I've committed it for genrating the tracID in both cases CB/CC ***************************
        '**************************************************************************************************
        'If PaymentMode = "CC" Then
        '**************************************************************************************************
        Dim strReturn As String = ""
        Dim strUID As String = ""
        Dim objUser As New User

        '------------------------------------------------------
        Dim strMode As String = objCXL.GetPaymentMethodString()
        '------------------------------------------------------

        '-------------------------------------------------------------
        If lblStatus.Text = "SignIn" Then
            intCustomerID = CustomerID
        Else
            intCustomerID = CustID
        End If

        Dim dsUser As DataSet = objUser.GetCustomerData(intCustomerID)
        '-------------------------------------------------------------

        ' Getting Login ID
        If dsUser.Tables.Count > 0 Then
            '--------------------------------------------------------------
            If dsUser.Tables(0).Rows.Count > 0 Then
                strUID = dsUser.Tables(0).Rows(0).Item("cart_customer_uid")
            End If
            '--------------------------------------------------------------
        End If
        '-------------------------------------------------------------------------



        Trace.Write("Calling CXL......")

        Dim strStatusCXL As String = objCXL.CollectionCXL(intCustomerID, strUID, ucServiceOrder.OrderNumber, strMode, 826, PaymentMode, strReturn)

        Trace.Write("CollectionService XML : " & strReturn)
        Trace.Write("Result : " & strStatusCXL)
        Trace.Write("Checking CXL Result.... ")

        Return objCXL.CheckCollectionStatus(intCustomerID, strUID, ucServiceOrder.OrderNumber, strStatusCXL, PaymentMode, False, IsEnableService)
        '------------------------------------------------------------------------------------------------------------
        '**************************************************************************************************
        'End If             
        '**************************************************************************************************

        Return False
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="isVisible"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowError(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayError
        '---------------------------------------
        ucServiceOrder.ShowError(msg, isVisible)
        isCxlError = isVisible
        '---------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="msg"></param>
    ''' <param name="isVisible"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowMessage(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayMessage
        '---------------------------------------
        ucServiceOrder.ShowMessage(msg, isVisible)
        '---------------------------------------
    End Sub


#End Region

End Class
