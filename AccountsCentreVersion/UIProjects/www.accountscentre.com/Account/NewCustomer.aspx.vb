#Region "Imports Libraries"
Imports System.Collections.Specialized
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Mail
Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports System.IO
Imports System.Xml
'Imports System.Text
#End Region

'http://www.accountscentre.com/Account/NewCustomer.aspx

Public Class NewCustomer

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region " Controls used in page."

    Protected WithEvents pnlCustomerForm1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCustomerDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCustomerRegistration As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlPaymentMethod As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCrCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAmexCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlDrCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblSurName As System.Web.UI.WebControls.Label
    Protected WithEvents lblFirstName As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecondName As System.Web.UI.WebControls.Label
    Protected WithEvents lblStreet As System.Web.UI.WebControls.Label
    Protected WithEvents lblTown As System.Web.UI.WebControls.Label
    Protected WithEvents lblState As System.Web.UI.WebControls.Label
    Protected WithEvents lblPostCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
    Protected WithEvents lblContactName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPh As System.Web.UI.WebControls.Label
    Protected WithEvents lblFax As System.Web.UI.WebControls.Label
    Protected WithEvents txtSurName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSecondName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtStreet As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTown As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtState As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtPostCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlCountry As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtContactName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTelephone As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFax As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmailAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNotes As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCreateAccount As System.Web.UI.WebControls.Button
    Protected WithEvents rbtPaymentMethod As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDeliveryAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaymentMethod As System.Web.UI.WebControls.Button
    Protected WithEvents btnCrCardInfo As System.Web.UI.WebControls.Button
    Protected WithEvents ddlCardNames As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCardHolderName As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCardNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCardAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSecurityCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAmexInfo As System.Web.UI.WebControls.Button
    Protected WithEvents ddlAmexSDYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAmexSDMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAmexEDYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAmexEDMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblCardName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardName1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode1 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlDrCardSDYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlDrCardSDMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtIssueNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnDrCardInfo As System.Web.UI.WebControls.Button
    Protected WithEvents pnlBankTransfer As System.Web.UI.WebControls.Panel
    Protected WithEvents txtBankName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChequeNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSortCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransactionRefNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBankTransfer As System.Web.UI.WebControls.Button
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents txtConfirmPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents grdPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents trPassword As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPasswordConfirm As System.Web.UI.HtmlControls.HtmlTableRow


    '     Message that will display on customer creation.
    Public NewCustomerCreated As String = String.Empty
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell

    Dim objTemplate As New InfiniLogic.AccountsCentre.BLL.TemplateReader
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Const ACC_ISFORMCOMPLETED As String = "ACC_ISFORMCOMPLETED"

    Private OrderNo As String = ""
    Protected WithEvents lblErrorInfoMsg As System.Web.UI.WebControls.Label
    Private strCustomerID As String = ""
#End Region

#Region " Web Form Designer Generated Code "

    '    This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        '        CODEGEN: This method call is required by the Web Form Designer
        '        Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If Not Page.IsPostBack Then

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
            End If

            FillMonthList()
            FillYearList()

            BindCountry(ddlCountry)

            pnlCustomerRegistration.Visible = True
            pnlCustomerDetail.Visible = False
            pnlInformation.Visible = False
            pnlPaymentMethod.Visible = False
            pnlBankTransfer.Visible = False
            pnlCrCardInfo.Visible = False
            pnlAmexCardInfo.Visible = False
            pnlDrCardInfo.Visible = False

            '**************(MNS)****************
            SetFocus(txtSurName)
            '***********************************

            Session(Me.ACC_ISFORMCOMPLETED) = Boolean.FalseString
        End If
        If Session(Me.ACC_ISFORMCOMPLETED) = "" Then Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Home))
    End Sub

    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click

        Dim blnCustomerStatus As Boolean = True

        Dim strSurName, strFirstName, strSecondName, strStreet, strTown, strState, strPostCode, _
        strCountry, strContName, strPh, strFax, strEmail, strNotes As String

        If VerifyCustomerDetailPanel() = True Then

            strSurName = txtSurName.Text
            strFirstName = txtFirstName.Text
            strSecondName = txtSecondName.Text
            strStreet = txtStreet.Text
            strTown = txtTown.Text
            strState = txtState.Text
            strPostCode = UCase(txtPostCode.Text)
            strCountry = ddlCountry.SelectedItem.Text
            strContName = txtContactName.Text
            strPh = txtTelephone.Text
            strFax = txtFax.Text
            strEmail = txtEmailAddress.Text
            strNotes = txtNotes.Text

            pnlCustomerRegistration.Visible = False
            pnlCustomerDetail.Visible = False
            pnlInformation.Visible = False
            pnlPaymentMethod.Visible = True
            lblSurName.Text = strSurName
            lblFirstName.Text = strFirstName
            lblSecondName.Text = strSecondName
            lblStreet.Text = strStreet
            lblTown.Text = strTown
            lblState.Text = strState
            lblPostCode.Text = strPostCode
            lblCountry.Text = strCountry
            lblContactName.Text = strContName
            lblPh.Text = strPh
            lblFax.Text = strFax
            lblEmail.Text = strEmail

            'If grdPackages.Visible Then SetFocus(grdPackages.Items(0).Cells(0).Controls(1))

        Else

            pnlInformation.Visible = True

        End If

    End Sub

    Private Sub btnPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentMethod.Click
        'Response.Write(Me.SendEmailForServiceEnable(106931, GetSelectedProducts(grdPackages, grdProducts)))

        'Response.End()
        If VerifyPaymentMethodPanel() = True Then

            If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then

                pnlCrCardInfo.Visible = True
                pnlPaymentMethod.Visible = False

                '**************(MNS)****************
                SetFocus(ddlCardNames)
                '***********************************

            Else

                pnlBankTransfer.Visible = True
                pnlPaymentMethod.Visible = False

                '**************(MNS)****************
                SetFocus(txtBankName)
                '***********************************

            End If

            pnlInformation.Visible = False

        Else

            pnlInformation.Visible = True

        End If

    End Sub

    Private Sub FillMonthList()
        Dim i As Integer = 1
        Dim j As Integer = 12

        For i = i To j
            ddlMonth.Items.Add(i)
            ddlAmexSDMonth.Items.Add(i)
            ddlAmexEDMonth.Items.Add(i)
            ddlDrCardSDMonth.Items.Add(i)
        Next

    End Sub

    Private Sub FillYearList()

        Dim x As Integer = Now.Year
        Dim y As Integer = 2050

        For x = x To y
            ddlYear.Items.Add(x)
            ddlAmexSDYear.Items.Add(x)
            ddlAmexEDYear.Items.Add(x)
            ddlDrCardSDYear.Items.Add(x)
        Next

    End Sub

    Private Sub FillCountriesList2()

        ddlCountry.DataSource = AccountsCentre.BLL.User.GetCountryName
        ddlCountry.DataTextField = "Name"
        ddlCountry.DataValueField = "Code"
        ddlCountry.DataBind()
        ddlCountry.SelectedIndex = CommonBase.Resources(ACC_Resource.DefaultCountry)

    End Sub

    Private Sub btnCrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrCardInfo.Click

        If VerifyCreditCardPanel() = True And VerifyCustomerDetailPanel() Then

            If ddlCardNames.SelectedItem.Text = "AMEX Card" Then

                pnlAmexCardInfo.Visible = True
                pnlCrCardInfo.Visible = False
                pnlInformation.Visible = False

                lblCardName.Text = txtCardHolderName.Text
                lblCardNumber.Text = txtCardNumber.Text

                lblExpiryDate.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

                lblCardAddress.Text = txtCardAddress.Text
                lblSecurityCode.Text = txtSecurityCode.Text

                '**************(MNS)****************
                SetFocus(ddlAmexSDMonth)
                '***********************************

            ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

                pnlCrCardInfo.Visible = False
                pnlDrCardInfo.Visible = True
                pnlInformation.Visible = False

                lblCardName1.Text = txtCardHolderName.Text
                lblCardNumber1.Text = txtCardNumber.Text

                lblExpiryDate1.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

                lblCardAddress1.Text = txtCardAddress.Text
                lblSecurityCode1.Text = txtSecurityCode.Text

                '**************(MNS)****************
                SetFocus(ddlDrCardSDMonth)
                '***********************************

            Else

                CustomerDetail()

            End If

        Else

            pnlInformation.Visible = True

        End If

    End Sub



    Private Sub btnAmexInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmexInfo.Click

        Dim dteStartDate, dteEndDate As Date
        Dim strMsg As String

        dteStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
        dteEndDate = DateSerial(ddlAmexEDYear.SelectedItem.Text, ddlAmexEDMonth.SelectedItem.Text + 1, 0)

        If dteStartDate < Now And dteEndDate < Now Then
            strMsg = ACCMessage.Account_AXCardSTDate
            strMsg = strMsg & "," & ACCMessage.Account_AXCardENDate

        ElseIf dteStartDate < Now Then
            strMsg = ACCMessage.Account_AXCardSTDate

        ElseIf dteEndDate < Now Then
            strMsg = ACCMessage.Account_AXCardENDate

        End If

        If strMsg = "" Then
            ' None of the control voilates business rules
            Call CustomerDetail()
        Else
            ' When form controls voilate the business rules
            pnlInformation.Visible = True
            strMsg = "<li>" & Replace(strMsg, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strMsg

        End If


    End Sub

    Private Sub btnDrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrCardInfo.Click

        If VerifyDebitCardPanel() = True Then
            Call CustomerDetail()
        Else
            pnlInformation.Visible = True

        End If

    End Sub

    Private Sub btnBankTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankTransfer.Click

        If VerifyBankTransactionPanel() = True Then
            Call CustomerDetail()
        Else
            pnlInformation.Visible = True
        End If
    End Sub

    Private Function CustomerDetail()

        Dim objUser As New User
        Dim objCryptography As New Cryptography

        Dim strAc, strSurName, strFirstName, strSecondName, strUID, strPassword, strStreet, strTown, _
        strState, strPostCode, strCountryCode, strCountry, strContName, strPh, strFax, strEmail, strNotes, _
        strEncryptKey, strEncryptPassword, strFnew, strFModified, strStoreName, strOrderNo, strFShipped, _
        strCardType, strCardNo, strCardName, strCardAddress, strCustomerAddress, strCarriageTC, _
        strWintiprocess, strPayProcessBy, strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
        strProductTaxCode, strDeliveryAddress, strCustPh, strCardExpires, strStartDate, strEndDate As String

        Dim strTo, strFrom, strSubject, strBody As String

        Dim dteOrderDate, dtePromiseShipDate As DateTime
        'Dim dteCardExpires As Date

        Dim dblDiscount, dblOrderAmount, dblCarriageNet, dblCarriageTaxRate, dblProductSalePrice, _
        dblTaxCodeRate, dblUnitPrice As Double

        Dim intRndNo, intEmployeesQty, intSecurityCode, intQty, intIssueNo, intProductID As Integer

        Dim lngMerchantID As Long
        Dim strGKey, strCreditCardType, strCreditCardNo, strCreditCardName, strCreditCardAddress As String
        Dim strGKeyLen As Integer = 1024
        Dim strMsg As String
        Dim strTime As DateTime

        '-----------
        OrderNo = ""
        '-----------

        strAc = "a"

        strSurName = txtSurName.Text
        strFirstName = txtFirstName.Text
        strSecondName = txtSecondName.Text

        strUID = "uid"
        strPassword = txtPassword.Text
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

        'RETRIEVING MERCHANT ID
        lngMerchantID = Mid$(objUser._strDatabaseName, 2)

        ' CUSTOMER KEY ENCRYPTION
        ' strEncryptKey = objCryptography.EncryptKey()

        ' PASSWORD ENCRYPTION
        strGKey = objCryptography.KeyGen(strGKeyLen)
        strEncryptPassword = objCryptography.EnCrypt(strPassword, strGKey)
        strTime = Now
        strFnew = "y"
        strFModified = "n"
        strStoreName = "ACCOUNTSCENTRE"

        Dim strLogType As String = "C"
        Dim intCustomerID As Integer
        Dim strPaymentMode As String

        '***********************************************************
        ' RANDOM NO. GENERATION FOR AC FIELD OF THE CUSTOMER TABLE

        Randomize()
        intRndNo = Int(Rnd() * 89) + 10

        '***********************************************************

        ' THESE FIELDS ARE USED FOR INVOICE 

        strOrderNo = "@ORD"
        dblDiscount = 0.0
        strFShipped = "n"
        dteOrderDate = Now()
        strDeliveryAddress = txtDeliveryAddress.Text
        strCustPh = txtTelephone.Text
        dtePromiseShipDate = DateSerial(Year(Now), Month(Now), Day(Now) + 7)

        '------------------------------------
        strStartDate = New Date(2000, 1, 1)
        strEndDate = strStartDate
        '------------------------------------

        '****************
        ' Option to choose Cheque Or Bank Transfer / Credit Card

        If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then

            strCreditCardType = ddlCardNames.SelectedItem.Text
            strCreditCardNo = txtCardNumber.Text
            strCreditCardName = txtCardHolderName.Text
            strCreditCardAddress = txtCardAddress.Text

            If txtSecurityCode.Text <> "" Then
                intSecurityCode = txtSecurityCode.Text
            End If

            strCardType = objCryptography.EnCrypt(strCreditCardType, strGKey)
            strCardNo = objCryptography.EnCrypt(strCreditCardNo, strGKey)
            strCardName = objCryptography.EnCrypt(strCreditCardName, strGKey)
            strCardAddress = objCryptography.EnCrypt(strCreditCardAddress, strGKey)

            strCardExpires = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

            Dim intDayCEx, intMonthCEx, intYearCEx As Integer

            intDayCEx = CInt(Day(strCardExpires))
            intMonthCEx = CInt(Month(strCardExpires))
            intYearCEx = CInt(Year(strCardExpires))

            strCardExpires = intMonthCEx & "/" & intDayCEx & "/" & intYearCEx

            strPaymentMode = "CC"

        ElseIf rbtPaymentMethod.SelectedItem.Value.ToString = "Cheque Or Bank Transfer" Then

            strBankName = txtBankName.Text
            strChequeNo = txtChequeNo.Text
            strSortCode = txtSortCode.Text
            strBankTranRefNo = txtTransactionRefNo.Text

            strPaymentMode = "CB"
        End If
        '****************
        strCustomerAddress = strStreet & " " & strTown & " " & strState & " " & strPostCode & " " & strCountry
        Dim strCustomerAddressForEmail As String = strStreet & "<br> " & strTown & "<br>" & strState & "<br>" & strPostCode & "<br>" & strCountry
        If ddlCardNames.SelectedItem.Text = "AMEX Card" Then

            strStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
            strEndDate = DateSerial(ddlAmexEDYear.SelectedItem.Text, ddlAmexEDMonth.SelectedItem.Text + 1, 0)

            Dim intDaySD, intMonthSD, intYearSD As Integer
            Dim intDayED, intMonthED, intYearED As Integer

            intDaySD = CInt(Day(strStartDate))
            intMonthSD = CInt(Month(strStartDate))
            intYearSD = CInt(Year(strStartDate))

            intDayED = CInt(Day(strEndDate))
            intMonthED = CInt(Month(strEndDate))
            intYearED = CInt(Year(strEndDate))


            strStartDate = intMonthSD & "/" & intDaySD & "/" & intYearSD
            strEndDate = intMonthED & "/" & intDayED & "/" & intYearED

        ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

            Dim intDayDrSD, intMonthDrSD, intYearDrSD As Integer

            strStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

            intDayDrSD = CInt(Day(strStartDate))
            intMonthDrSD = CInt(Month(strStartDate))
            intYearDrSD = CInt(Year(strStartDate))

            strStartDate = intMonthDrSD & "/" & intDayDrSD & "/" & intYearDrSD

            If txtIssueNo.Text <> "" Then
                intIssueNo = txtIssueNo.Text
            End If

        End If

        Dim strProductCodes As String = ProdcutPackageXML(dblOrderAmount)

        strPayProcessBy = "AC"
        strWintiprocess = "n"

        Dim intParentCustomerID As Integer
        Dim bolAsExcluded As Boolean = False

        If Not (Session("ACC_GV_RegistrationMode") Is Nothing) Then
            intParentCustomerID = CInt(Session("ACC_GV_ParentCustomerID"))
            If (Session("ACC_GV_RegistrationMode") = RegistrationMode.ExcludedFromGlobalView) Then bolAsExcluded = True
        End If

        'strMsg = objUser.AddCustomer(intCustomerID, strAc, strSurName, strFirstName, strSecondName, strStreet, _
        '                             strTown, strCountryCode, strCountry, strPostCode, strContName, strPh, _
        '                             strFax, strEmail, strNotes, strUID, strEncryptPassword, strState, strTime, _
        '                             strFnew, strFModified, strStoreName, lngMerchantID, strGKey, strEncryptKey, _
        '                             intRndNo, strOrderNo, strDeliveryAddress, strCustPh, dblDiscount, strFShipped, _
        '                             dteOrderDate, dtePromiseShipDate, strCardType, strCardNo, strCardName, _
        '                             strCardExpires, strCardAddress, strCustomerAddress, dblOrderAmount, _
        '                             strStartDate, strEndDate, intSecurityCode, intIssueNo, strPayProcessBy, _
        '                             strBankName, strChequeNo, strSortCode, strBankTranRefNo, strWintiprocess, _
        '                             strProductCodes, intParentCustomerID, bolAsExcluded)



        pnlInformation.Visible = True
        pnlCustomerDetail.Visible = False
        pnlCustomerRegistration.Visible = False
        pnlPaymentMethod.Visible = False
        pnlCrCardInfo.Visible = False
        pnlAmexCardInfo.Visible = False
        pnlDrCardInfo.Visible = False
        pnlBankTransfer.Visible = False

        If intCustomerID <> 0 Then


            Dim strCompanyName As String = CStr(Session("ACC_GV_ProcessCompany"))
            Dim strCompanyNumber As String = CStr(Session("ACC_GV_CompanyNumber"))
            Session("ACC_GV_ProcessCompany") = Nothing
            Session("ACC_GV_CompanyNumber") = Nothing

            objUser.LoadAccountscetreUser(intCustomerID, strCompanyName, strCompanyNumber)

            REM SR
            If Not (Session("ACC_GV_RegistrationMode") Is Nothing) Then
                objUser.UpdateFormationsHouseSubAccount(strCompanyName, strCompanyNumber, intCustomerID, intParentCustomerID)
                objUser.UpdateCompStatus(intCustomerID, 2)
            End If
            REM SR

            'If Not Session("ACC_GV_RegistrationMode") Is Nothing Then UpdateGlobalView(intCustomerID)

            'InfoMessage = ACCMessage.Account_NewCustomerCreated
            Dim colSelectedServices As NameValueCollection = GetSelectedProducts(False, grdPackages, grdProducts)

            '@ ----------------------------------------------------------------------------------
            '@      Modified by     : Abid Ali
            '@      Modified Date   : Friday, 9th December 2005     
            '@      Purpose         : To Call the CXL for Credit Carde Transaction of Order 
            '@ ----------------------------------------------------------------------------------


            If strPaymentMode = "CC" Then
                '-------------------------------------
                Dim strMode As String
                If objUser.AccGetPaymentMode() Then
                    strMode = "Live"
                Else
                    strMode = "Test"
                End If
                '-------------------------------------

                '------------------------------------------------------------------------------------------------------------
                Dim dsUser As DataSet = objUser.GetCustomerData(intCustomerID)


                '--------------------------------------------------------------------
                ' Getting Login ID
                If dsUser.Tables.Count > 0 Then
                    If dsUser.Tables(0).Rows.Count > 0 Then
                        strUID = dsUser.Tables(0).Rows(0).Item("cart_customer_uid")
                    End If
                End If
                '-------------------------------------------------------------------------

                '-----------------------------------------------------------------------
                ' Get OrderNo
                Try
                    OrderNo = GetOrderNo(intCustomerID)
                Catch ex As Exception
                End Try
                '-----------------------------------------------------------------------


                Trace.Write("Calling CXL......")
                Dim strStatusCXL As String = CollectionCXL(intCustomerID, strUID, OrderNo, strMode, 826, strPaymentMode)
                Trace.Write("Result : " & strStatusCXL)
                Trace.Write("Checking CXL Result.... ")

                strCustomerID = intCustomerID
                CheckCollectionStatus(strStatusCXL, strUID)
                '------------------------------------------------------------------------------------------------------------
            End If

            '@-----------------------------------------------------------------------------------
            '@      End of Modification
            '@ ----------------------------------------------------------------------------------


            Dim InfoMsg As String = CommonBase.EmailMessages(ACC_Email_Messages.New_Account_Email_Template) 'ACCMessage.Account_NewCustomerCreated
            InfoMsg = InfoMsg.Replace("[Name]", txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text)
            InfoMsg = InfoMsg.Replace("[LoginID]", intRndNo & intCustomerID)
            InfoMsg = InfoMsg.Replace("[Password]", txtPassword.Text)
            InfoMsg = InfoMsg.Replace("[ServicesInformation]", CommonBase.CreateList(colSelectedServices))

            InfoMessage = InfoMsg.Replace("[Address]", txtEmailAddress.Text)

            'Dim objEmail As New System.Web.Mail.MailMessage

            Dim strServicesInformation As String = ProdcutPackageXML(, True)

            strTo = strEmail.ToString

            If Not Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then

                strSubject = ACCMessage.Email_AccountRegistration
                strBody = "Dear valued customer," & vbCrLf & vbCrLf & _
                "We have received your account information provided by you through " & vbCrLf & _
                "http://www.accountscentre.com" & vbCrLf & vbCrLf & _
                "Your request of account activation is under process and you will receive a " & _
                "user id and password for login purposes via another email within 24 hours. " & vbCrLf & vbCrLf & _
                "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
                "Email:   support@AccountsCentre.com" & vbCrLf & _
                "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"



                strBody = Me.SendEmailForServiceEnable(intCustomerID, colSelectedServices)

                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                     strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If



                Dim strFullName As String = strSurName & strFirstName & strSecondName
                Dim LoginID As String = intRndNo & intCustomerID
                'Dim strEmailTemplate As String
                Dim strTemplateSubject As String = EmailSubject()
                strBody = SelectEmailContent(strFullName, LoginID, strPassword, strCustomerAddressForEmail, strServicesInformation)


                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                     ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                     strTemplateSubject, strBody.ToString, MailFormat.Html) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If
            Else

                strSubject = ACCMessage.Email_AccountRegistration
                strBody = "Dear valued customer, " & vbCrLf & vbCrLf & _
                          "We have received your Company's information provided by you through" & vbCrLf & _
                          "http://www.accountscentre.com" & vbCrLf & vbCrLf & _
                          "Your Company " & "'" & strCompanyName & "'" & " is activated with the following services:" & vbCrLf & vbCrLf & _
                          strServicesInformation & vbCrLf & vbCrLf & _
                          "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
                          "Email:   support@AccountsCentre.com" & vbCrLf & _
                          "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"


                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                     strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Text) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If


                Dim strFullName As String = strSurName & strFirstName & strSecondName
                Dim LoginID As String = intRndNo & intCustomerID
                'Dim strEmailTemplate As String
                Dim strTemplateSubject As String = EmailSubject()

                strBody = SelectEmailContent(strFullName, LoginID, strPassword, strCustomerAddressForEmail, strServicesInformation)
                Dim enabledWebApp As New System.Collections.Specialized.NameValueCollection

                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                     ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                     strTemplateSubject, strBody.ToString, MailFormat.Html) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If

            End If

            'objEmail = Nothing

        End If
        Session.Remove(Me.ACC_ISFORMCOMPLETED)
        Session.Remove(Me.ACC_ORDER_HERE_LINK)

        btnFinish.Visible = True
    End Function

    Private Function GetOrderNo(ByVal intCustID As Integer) As Integer
        Dim dr As SqlDataReader
        Dim objUser As New User
        Dim RetVal As Integer = -1

        Try
            dr = objUser.AccGetOrderDetails(intCustID)
            If dr.Read Then
                RetVal = CInt(dr("OrderNo"))
            End If
        Catch ex As Exception
        Finally
            dr.Close()
        End Try

        Return RetVal
    End Function


    Public Function SelectEmailContent(ByVal Name As String, ByVal strLoginID As String, Optional ByVal strpassword As String = "", Optional ByVal strCustomerAddress As String = "", Optional ByVal strServicesInformation As String = "") As String
        Dim strFullName As String = Name 'strSurName & strFirstName & strSecondName
        Dim LoginID As String = strLoginID 'intRndNo & intCustomerID
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent("ACSA")
        strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")

        Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
        strbuilder.Replace("[Name]", strFullName).ToString()
        strbuilder.Replace("[LoginID]", LoginID).ToString()
        strbuilder.Replace("[Password]", strpassword).ToString()
        strbuilder.Replace("[Address]", strCustomerAddress).ToString()
        strbuilder.Replace("[ServicesInformation]", strServicesInformation).ToString()
        Return strbuilder.ToString

    End Function

    Public Function EmailSubject() As String
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent("LGIN")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        Return strTemplateSubject

    End Function

    Private Sub pnlPaymentMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPaymentMethod.Load


        If Not Page.IsPostBack Then

            ' INSERT AMOUNT IN PRODUCT SELECTION OF REGISTRATION PROCESS

            Dim ds As New DataSet

            ds = BLL.User.ACC_GetProductsToSale 'PackageOptions.EnableSale, ServiceOptions.EnableSale)

            CheckOrderHereRow(ds)
            grdPackages.DataSource = ds.Tables(0)
            grdPackages.DataBind()
            grdPackages.Visible = ds.Tables(0).Rows.Count > 0

            grdProducts.DataSource = ds.Tables(1)
            grdProducts.DataBind()
            grdProducts.Visible = ds.Tables(1).Rows.Count > 0

        End If

    End Sub

    Private Function VerifyCustomerDetailPanel() As Boolean

        VerifyCustomerDetailPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String

        txtPostCode.Text = UCase(txtPostCode.Text)
        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        If ddlCountry.SelectedItem.Text = "United Kingdom" Then
            objRegExp.Add("txtPostCode", "0400200300", "Postcode")
        Else
            If Trim(txtPostCode.Text) = "" Then
                strMsg = "txtPostCode"
            End If
        End If

        objRegExp.Add("txtSurName", "0700500550", "Surname")
        objRegExp.Add("txtFirstName", "0700501000", "First Name")
        objRegExp.Add("txtSecondName", "0700501001", "Second Name ")
        objRegExp.Add("txtPassword", "0203400160", "Password")
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

        If txtPassword.Text <> txtConfirmPassword.Text Then

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
        Else
            ' When form controls voilate the business rules
            VerifyCustomerDetailPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyPaymentMethodPanel() As Boolean

        VerifyPaymentMethodPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim rowCount As Integer = 0
        'Loop through each DataGridItem, and determine which CheckBox controls
        'have been selected.
        Dim GridItem As DataGridItem
        For Each GridItem In grdPackages.Items
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
        Next
        For Each GridItem In grdProducts.Items
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
        Next
        If rowCount < 1 Then
            strMsg = "Atleast one product must be selected."
            strReturnMessage = strMsg
            strMsg = rowCount
        Else

            Dim objuser As New User
            Dim dr As System.Data.SqlClient.SqlDataReader

            dr = objuser.ACC_VerifySelectedPackages(ProdcutPackageXML)

            While dr.Read

                strMsg = strMsg & " , " & dr.Item("ProductName")

            End While

            strReturnMessage = strMsg

        End If

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        If strMsg = "" Then
            ' Add the controls 
            objRegExp.Add("txtDeliveryAddress", "0203502551", "Delivery Address")

            ' Get the return message
            strReturnMessage = objRegExp.ScanPage(Me)
        End If

        ' Now make decision, whether error has been returned or not 

        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyPaymentMethodPanel = True
        Else
            ' When form controls voilate the business rules
            VerifyPaymentMethodPanel = False
            strReturnMessage = Replace(strReturnMessage, ",", "<li>")
            If strMsg = "" Then
                ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br><li>" & strReturnMessage
            ElseIf strMsg = "0" Then
                ErrorMessage = strReturnMessage & "<Br>"
            Else
                ErrorMessage = "Following Packages/Products have same Services. " & "<Br><Br>" & strReturnMessage
            End If
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyCreditCardPanel() As Boolean

        VerifyCreditCardPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim dteCrCardExpires As Date
        Dim strMsg As String

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        objRegExp.Add("txtCardHolderName", "0700302550", "Card Holder Name")
        objRegExp.Add("txtCardNumber", "0100100200", "Card Number")
        objRegExp.Add("txtCardAddress", "0203502550", "Card Address")
        objRegExp.Add("txtSecurityCode", "0100100101", "Security Code")


        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        dteCrCardExpires = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        If dteCrCardExpires < Now() Then

            strMsg = ACCMessage.Account_CrCardExpiryDate

            If strReturnMessage = "" Then
                strReturnMessage = strMsg
            Else
                strReturnMessage = strReturnMessage & "," & strMsg
            End If

        End If

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyCreditCardPanel = True
        Else
            ' When form controls voilate the business rules
            VerifyCreditCardPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyBankTransactionPanel() As Boolean

        VerifyBankTransactionPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        objRegExp.Add("txtBankName", "0700300501", "Bank Name")
        objRegExp.Add("txtChequeNo", "0700300101", "Cheque No.")
        objRegExp.Add("txtSortCode", "0700300101", "Sort Code")
        objRegExp.Add("txtTransactionRefNo", "0700300101", "Transaction Reference No.")



        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyBankTransactionPanel = True
        Else
            ' When form controls voilate the business rules
            VerifyBankTransactionPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyDebitCardPanel() As Boolean

        VerifyDebitCardPanel = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim dteStartDate As Date
        Dim strMsg As String

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 

        objRegExp.Add("txtIssueNo", "0100100100", "Issue No.")


        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        dteStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

        If dteStartDate < Now() Then

            strMsg = ACCMessage.Account_DrCardDate

            If strReturnMessage = "" Then
                strReturnMessage = strMsg
            Else
                strReturnMessage = strReturnMessage & "," & strMsg
            End If

        End If


        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyDebitCardPanel = True
        Else
            ' When form controls voilate the business rules
            VerifyDebitCardPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    '*****************************************
    '' SetFocus Function (MNS)
    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
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

            If InStr(strName, " ") > 0 Then
                txtSurName.Text = strName.Substring(0, strName.IndexOf(" "))
            Else
                txtSurName.Text = strName
            End If

            txtSurName.Text = Trim(txtSurName.Text)
            strName = strName.Remove(0, Len(txtSurName.Text))

            If Not strName = String.Empty Then
                strName.Trim()
                txtFirstName.Text = strName.Substring(0, strName.IndexOf(" "))
                txtFirstName.Text = Trim(txtFirstName.Text)
                strName.Remove(0, Len(txtFirstName.Text))
            End If

            If Not strName = String.Empty Then
                strName.Trim()
                txtSecondName.Text = strName
            End If

            If Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then
                GetPassword()
                txtConfirmPassword.Text = txtPassword.Text
            End If

        End If

    End Sub

    Private Sub GetPassword()

        Randomize()
        txtPassword.Text = CInt(Int(90 * Rnd()) + 10)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & Chr(Int(26 * Rnd()) + 97)
        Randomize()
        txtPassword.Text = txtPassword.Text & CInt(Int(90 * Rnd()) + 10)

    End Sub

    Private Function ProdcutPackageXML(Optional ByRef dblOrderAmount As Double = 0, _
                                   Optional ByVal bolEmailText As Boolean = False) As String

        Dim strProductCodes As New System.Text.StringBuilder

        If Not bolEmailText Then

            strProductCodes.Append("<ROOT>")

        End If

        If bolEmailText Then
            Dim ds As New DataSet

            ds = BLL.User.ACC_GetProductsToSale() '.ACC_PackageProductDetails(PackageOptions.EnableSale, ServiceOptions.EnableSale)
            PackageProductCodeIterations(strProductCodes, ds.Tables(0), grdPackages, dblOrderAmount, bolEmailText)

            PackageProductCodeIterations(strProductCodes, ds.Tables(1), grdProducts, dblOrderAmount, bolEmailText)
        Else
            PackageProductCodeIterations(strProductCodes, grdPackages.DataSource, grdPackages, dblOrderAmount, bolEmailText)

            PackageProductCodeIterations(strProductCodes, grdProducts.DataSource, grdProducts, dblOrderAmount, bolEmailText)

            strProductCodes.Append("</ROOT>")
        End If


        Return strProductCodes.ToString

    End Function

    Private Sub PackageProductCodeIterations(ByRef strProductCodes As System.Text.StringBuilder, _
                                             ByRef dt As DataTable, ByRef Grid As DataGrid, _
                                             Optional ByRef dblOrderAmount As Double = 0, _
                                             Optional ByVal bolEmailText As Boolean = False)

        Dim rowCount As Integer = 0
        'Loop through each DataGridItem, and determine which CheckBox controls
        'have been selected.
        Dim GridItem As DataGridItem

        For Each GridItem In Grid.Items
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked Then
                If bolEmailText Then
                    strProductCodes.Append(dt.Rows(rowCount).Item("ProductName") & vbCrLf)
                Else
                    strProductCodes.Append("<Product Code=""")
                    ' strProductCodes.Append(dt.Rows(rowCount).Item("ProductCode"))
                    strProductCodes.Append(GridItem.Cells(4).Text.ToString)
                    'strProductCodes.Append(dt.Rows(rowCount).Item("ProductCode"))
                    strProductCodes.Append("""/>")
                    '------------------------------------------------------------------
                    Dim dblProdAmount = CDbl(Mid(GridItem.Cells(3).Text, 2))
                    Dim dblProdTax = CDbl(GridItem.Cells(5).Text)

                    dblOrderAmount += dblProdAmount + dblProdAmount * dblProdTax / 100
                    '-------------------------------------------------------------------
                End If
            End If
            rowCount += 1
        Next

    End Sub

    Private Sub grdPackages_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPackages.ItemDataBound

        SetCheckBox(e)

    End Sub

    Public Sub SetCheckBox(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

        If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then

            Select Case e.Item.ItemType

                Case ListItemType.AlternatingItem, ListItemType.Item
                    '                    Response.Write(e.Item.DataItem("ProductCode"))
                    Dim chkBox As CheckBox
                    chkBox = CType(e.Item.Cells(0).Controls(1), CheckBox)
                    chkBox.Checked = e.Item.DataItem("ProductCode") = Session(Me.ACC_ORDER_HERE_LINK)

                    If chkBox.Checked Then chkBox.Visible = False

            End Select
        End If
    End Sub

    Private Sub grdProducts_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProducts.ItemDataBound
        SetCheckBox(e)
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        RedirectTo(ACC_Redirection.HOMEPAGE)

    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="msg"></param>
    '@ <param name="isVisible"></param>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Private Sub ShowError(ByVal msg As String, Optional ByVal isVisible As Boolean = False)
        '-------------------------------------------------------------------------
        lblErrorInfoMsg.Text = msg
        lblErrorInfoMsg.Visible = isVisible
        lblErrorInfoMsg.ForeColor = Color.Red
        '-------------------------------------------------------------------------
    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="msg"></param>
    '@ <param name="isVisible"></param>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Private Sub ShowMessage(ByVal msg As String, Optional ByVal isVisible As Boolean = False)
        lblErrorInfoMsg.Text = msg
        lblErrorInfoMsg.Visible = isVisible
        lblErrorInfoMsg.ForeColor = Color.Green
    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="strStatus"></param>
    '@ <param name="LoginID"></param>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Private Sub CheckCollectionStatus(ByVal strStatus As String, ByVal LoginID As String)

        Dim ds As New DataSet

        Dim strCollectionTID, strResponseCode, strRefNo, strMsg As String

        Try
            '-----------------------------------
            ds = ConvertXMLToDataSet(strStatus)
            '-----------------------------------

            If ds.Tables(0).Columns.Count > 2 Then ' CXL Response has more than two column 

                '-------------------------------------------
                strCollectionTID = ds.Tables(0).Rows(0)(0)
                strResponseCode = ds.Tables(0).Rows(0)(1)
                strRefNo = ds.Tables(0).Rows(0)(2)
                strMsg = ds.Tables(0).Rows(0)(3)
                '-------------------------------------------

                If CInt(strResponseCode) = 0 Then   ' CXL Transaction Succesfull
                    '--------------------------------------------------------------------------------------------------------------------------------

                    If rbtPaymentMethod.SelectedValue = "Credit Card" Then
                        '-----------------------
                        EnableServices(LoginID)
                        '-----------------------
                    End If

                    '-------------------------------------------------------------------------------
                    ShowMessage("Order payment has been successed.<br> Please do not retry.", True)
                    '-------------------------------------------------------------------------------

                    If CInt(strCollectionTID) < 0 Then
                        '----------------------------------------------------------------------------------------------------------------------------------
                        Dim strBody As String = "<b>Login ID " & LoginID & "<br>Order No. " & OrderNo & "</b><br>Payment has been successed but return TracID is " & strCollectionTID
                        '----------------------------------------------------------------------------------------------------------------------------------

                        '------------------------------------------------------------------------------------------------------------
                        CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", strBody, MailFormat.Html, _
                                ConfigReader.GetItem(ConfigVariables.SMTPUserID))
                        '------------------------------------------------------------------------------------------------------------
                    End If

                    '-------------------------------------------------------------------------------------------------------------------------------------
                ElseIf CInt(strResponseCode) > 0 Then   ' Decline Order
                    '-------------------------------------------------------------------------------------------
                    If strResponseCode = "30" Then
                        ShowError("Credit Card declined.", True)

                        '----------------------------------------------------------------------------------------------------------------------------------
                        Dim strBody As String = "<b>Login ID " & LoginID * "<br>Order No. " & OrderNo & "</b><br>Credit Card declined but return TracID is " & strCollectionTID
                        '----------------------------------------------------------------------------------------------------------------------------------


                        '------------------------------------------------------------------------------------------------------------
                        CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                ACCMessage.Email_DefaultEmailAddress, "Calling CXL in New Customer.", strBody, MailFormat.Html, _
                                ConfigReader.GetItem(ConfigVariables.SMTPUserID))
                        '------------------------------------------------------------------------------------------------------------
                    Else
                        ShowError(strMsg, True)
                    End If
                    ' Error Log
                    ' AccInsertPaymentErrorLog(strCustomerID, OrderNo, Date.Now, strResponseCode, strMsg)
                    '-------------------------------------------------------------------------------------------
                Else    ' < 0 
                    '-------------------------------------------------------------------------------------------
                    ShowError(strMsg, True)
                    ' Error Log
                    AccInsertPaymentErrorLog(strCustomerID, OrderNo, Date.Now, strResponseCode, strMsg)
                    '-------------------------------------------------------------------------------------------
                End If


            Else ' CX Transaction failure
                '--------------------------------------------------------------------
                ShowResponseError(ds.Tables(0).Rows(0)(0), ds.Tables(0).Rows(0)(1))
                '--------------------------------------------------------------------
            End If
        Catch ex As Exception
        End Try
    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="xmlData"></param>
    '@ <returns></returns>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Public Function ConvertXMLToDataSet(ByVal xmlData As String) As DataSet
        Dim stream As StringReader = Nothing
        Dim reader As XmlTextReader = Nothing

        Try
            '---------------------------------
            Dim xmlDS As New DataSet
            stream = New StringReader(xmlData)
            reader = New XmlTextReader(stream)
            xmlDS.ReadXml(reader)
            Return xmlDS
            '---------------------------------
        Catch
            Return Nothing
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="ErrorCode"></param>
    '@ <param name="ErrorMsg"></param>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Private Sub ShowResponseError(ByVal ErrorCode As String, ByVal ErrorMsg As String)

        ''' NOTE : first two 
        ''' CRITICAL ERRORS // THAT SHOULD NOT SUPPOSE TO COME IN ANY CONDITION 
        ''' then 'GENERAL(ERRORS)



        If ErrorCode <> "-500" Then
            '-------------------------------------------------------------------------------------------------------------------------------

            '''<ERRORCODE>-903</ERRORCODE>
            '''<ERRORMSG>Transaction is Partially Failed. Please contact system Administrator. </ERRORMSG>"

            '''<ERRORCODE>-1</ERRORCODE>
            ''' <ERRORMSG>Transaction Paritally Failed or All Unsucessfull. Please contact System Administrator </ERRORMSG>

            '''<ERRORCODE>-900</ERRORCODE>
            ''' <ERRORMSG>Collection Service is not available for the specified Merchant. Please contact System Administrator.</ERRORMSG>

            '''<ERRORCODE>-550</ERRORCODE>
            '''<ERRORMSG>Transaction already done before Or Invalid Transaction Amount. Transaction Amount must be more than 0.</ERRORMSG>

            '''<ERRORCODE>-501</ERRORCODE>
            '''<ERRORMSG>Transaction Amount must be less than Remaining Balance Amount of the given Order.</ERRORMSG>


            ShowMessage("Order is under process. Please contact with administration.", True)
            '-------------------------------------------------------------------------------------------------------------------------------
        ElseIf ErrorCode = "-500" Then
            '-------------------------------------------------------------------------------------------------------------------------------
            '''<ERRORCODE>-500</ERRORCODE>
            '''<ERRORMSG>Not Approved Floor Limit of customer. Notification has been sent to Administrator and waiting for further acceptance.</ERRORMSG>
            ''' OR
            ''' <ERRORMSG>You are exceding limit of no of transactions allowed per day. Please refer to site Administrator.</ERRORMSG>
            ShowError("For order number " & OrderNo & ". <br>" & ErrorMsg, True)
            '-------------------------------------------------------------------------------------------------------------------------------
        End If

        '----------------------------------------------------------------------------------
        AccInsertPaymentErrorLog(strCustomerID, OrderNo, Date.Now, ErrorCode, ErrorMsg)
        '
        '----------------------------------------------------------------------------------
    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="CustomerID"></param>
    '@ <param name="CustomerUID"></param>
    '@ <param name="OrderID"></param>
    '@ <param name="Mode"></param>
    '@ <param name="GenericCode"></param>
    '@ <param name="PaymentMode"></param>
    '@ <returns></returns>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Private Function CollectionCXL(ByVal CustomerID As String, ByVal CustomerUID As String, _
                                   ByVal OrderID As String, ByVal Mode As String, _
                                   ByVal GenericCode As String, ByVal PaymentMode As String) As String

        '---------------------------------------------------------------------------------------------
        Dim strXML As String = "<Data><Sender>ACCOUNTSCENTRE</Sender><MerchantID>2</MerchantID>" & _
                                "<MerchantUID>26</MerchantUID><CustomerID>" & _
                                CustomerID & "</CustomerID><CustomerUID>" & _
                                CustomerUID & "</CustomerUID><OrderID>" & _
                                OrderID & "</OrderID><Mode>" & _
                                Mode & "</Mode><GenericCode>" & _
                                GenericCode & "</GenericCode><PaymentMode>" & _
                                PaymentMode & "</PaymentMode></Data>"

        Trace.Write("CollectionCXL XML : " & strXML)
        '---------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------
        Dim o As New com.webservices.ishops.WebService

        Dim key As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        Dim userid As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        Dim pwd As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        Dim domain As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        Dim res As String = o.CollectionServices(strXML)

        o.Dispose()
        o = Nothing
        '--------------------------------------------------------------------------------------------------------

        Return res
    End Function

    Private Sub EnableServices(ByVal LoginID)

        '-------------------------------------------------------------------------
        Dim objSelectServices As New Administration.BLL.CustomerSelectedServices
        Dim sqlDrOrder As SqlDataReader
        Dim objUser As New User
        '-------------------------------------------------------------------------

        Try
            '-----------------------------------------------------------------------
            Dim dt As DataTable = objSelectServices.GetCustomerServices(strCustomerID)
            Dim dr As DataRow

            sqlDrOrder = objUser.AccGetOrderDetails(strCustomerID, OrderNo)
            '-----------------------------------------------------------------------

            While sqlDrOrder.Read
                '--------------------------------------------------------------------------------------------------------
                For Each dr In dt.Rows
                    '-----------------------------------------------------------------------------------------------------
                    If dr("ProductCode") = sqlDrOrder("code") Then
                        objSelectServices.ManageAccountsCentreServices(dr("ServiceID"), strCustomerID, LoginID, "Enable", Now)
                        Exit For
                    End If
                    '-----------------------------------------------------------------------------------------------------
                Next
                '--------------------------------------------------------------------------------------------------------
            End While

        Catch ex As Exception
        Finally
            sqlDrOrder.Close()
        End Try
    End Sub

    '@ -----------------------------------------------------------------------------
    '@ <summary>
    '@ 
    '@ </summary>
    '@ <param name="CustomerID"></param>
    '@ <param name="OrderID"></param>
    '@ <param name="ErrorDate"></param>
    '@ <param name="ErrorCode"></param>
    '@ <param name="ErrorMsg"></param>
    '@ <remarks>
    '@ </remarks>
    '@ <history>
    '@ 	[win.abid]	09/12/2005	Created
    '@ </history>
    '@ -----------------------------------------------------------------------------
    Public Sub AccInsertPaymentErrorLog(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal ErrorDate As DateTime, ByVal ErrorCode As Integer, ByVal ErrorMsg As String)
        Dim objUser As User
        objUser.AccInsertPaymentErrorLog(CustomerID, OrderID, ErrorDate, ErrorCode, ErrorMsg)
    End Sub
End Class