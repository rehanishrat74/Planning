#Region ":::::::::::::::: Imports Libraries ::::::::::::::::"

Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common
Imports System.Web.Mail
Imports System.IO
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Data
Imports Infinilogic.CreditCardValidation
Imports System.Web.Security

#End Region

#Region ":::::::::::::::: CLASS -> UpdateServices ::::::::::::::::"

Public Class UpdateServices
    Inherits PageTemplate

#Region ":::::::::::::::: Controls and Fileds used in page. ::::::::::::::::"

#Region "**************** Controls ****************"

    Protected WithEvents txt As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlCustomerForm1 As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMethod As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDeliveryAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaymentMethod As System.Web.UI.WebControls.Button
    Protected WithEvents pnlPaymentMethod As System.Web.UI.WebControls.Panel
    Protected WithEvents txtBankName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChequeNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSortCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransactionRefNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBankTransfer As System.Web.UI.WebControls.Button
    Protected WithEvents pnlBankTransfer As System.Web.UI.WebControls.Panel
    Protected WithEvents ddlCardNames As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCardHolderName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCardNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtCardAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSecurityCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCrCardInfo As System.Web.UI.WebControls.Button
    Protected WithEvents pnlCrCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblCardName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode As System.Web.UI.WebControls.Label
    Protected WithEvents ddlAmexSDMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlAmexSDYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnAmexInfo As System.Web.UI.WebControls.Button
    Protected WithEvents pnlAmexCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdPurchasedPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdPurchasedProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tcExp As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tcAbtExp As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents hPck As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dPck As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hPrd As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dPrd As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hPPck As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dPPck As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents hPPrd As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dPPrd As System.Web.UI.HtmlControls.HtmlTableRow

    Protected WithEvents IsFormCompeleted22 As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents pnlCompanyList As System.Web.UI.WebControls.Panel
    Protected WithEvents listCompany As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnCompanyList As System.Web.UI.WebControls.Button
    Protected WithEvents hCriteria As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents hSort As System.Web.UI.HtmlControls.HtmlInputHidden
    'Public WithEvents IsFormCompeleted As HtmlControls.HtmlInputHidden
    Protected idxTopBar As IndexHeader

#End Region

#Region "**************** Fields ****************"

    Dim objTemplate As New InfiniLogic.AccountsCentre.BLL.TemplateReader
    Const ACC_ISFORMCOMPLETED As String = "ACC_ISFORMCOMPLETED"
    Const ACC_RENEW_PRODUCT As String = "ACC_RENEW_PRODUCT"

    Dim intCustomerID As Integer = CustomerID
    Private OrderNo As String = ""

    '---------------------------------------
    Private mbOnlySummary As Boolean
    Private dtCompanies As DataTable
    Public dvCompanies As DataView
    Private objGlobalView As New GlobalView
    Protected WithEvents btnRetry As System.Web.UI.WebControls.Button
    Protected WithEvents txtHiddenOrderID As System.Web.UI.WebControls.TextBox
    Protected WithEvents trStartDate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trIssueNumber As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdCardHeading As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtIssueNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdStartDate As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblupdateservices As System.Web.UI.WebControls.Label
    Protected WithEvents lblselectcompnany As System.Web.UI.WebControls.Label
    Protected WithEvents lblsubscriptionexpired As System.Web.UI.WebControls.Label
    Protected WithEvents lblsubscriptionaboutexpire As System.Web.UI.WebControls.Label
    Protected WithEvents lblavailablepackage As System.Web.UI.WebControls.Label
    Protected WithEvents lblpaymentmode As System.Web.UI.WebControls.Label
    Protected WithEvents lbldeliveryaddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblbankname As System.Web.UI.WebControls.Label
    Protected WithEvents lblchequeno As System.Web.UI.WebControls.Label
    Protected WithEvents lblsortcode As System.Web.UI.WebControls.Label
    Protected WithEvents lbltransactionrefno As System.Web.UI.WebControls.Label
    Protected WithEvents lblselectcard As System.Web.UI.WebControls.Label
    Protected WithEvents lblcardholdername2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcardnumber2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblexpirydate2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcardaddress2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblsecuritycode2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcardholder_name As System.Web.UI.WebControls.Label
    Protected WithEvents lblcard_number As System.Web.UI.WebControls.Label
    Protected WithEvents lblexpiry_date As System.Web.UI.WebControls.Label
    Protected WithEvents lblcard_address As System.Web.UI.WebControls.Label
    Protected WithEvents lblsecurity_code As System.Web.UI.WebControls.Label
    Protected WithEvents lblchoosedaterange As System.Web.UI.WebControls.Label
    Protected WithEvents lblstartdate As System.Web.UI.WebControls.Label
    Protected WithEvents lblenddate As System.Web.UI.WebControls.Label
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td9 As System.Web.UI.HtmlControls.HtmlTableCell
    Private WithEvents objCXL As New CXLProcessing
    '---------------------------------------
#End Region

#End Region

#Region ":::::::::::::::: Web Form Designer Generated Code ::::::::::::::::"

    '    This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        '        CODEGEN: This method call is required by the Web Form Designer
        '        Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region ":::::::::::::::: Old Methods before Company Selection Criteria ::::::::::::::::"

#Region "**************** Event Handlers ****************"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Response.Redirect("/Members/ServiceRegistration.aspx")

        Trace.Write("Page Load Cusotmer ID : " & CustomerID)
        '-----------------------------
        ' set the non visibility of
        ' error message
        ShowErrorMessage("", True)
        'Dim strRenew As String = Request.QueryString("IsRenew")
        'Dim strProductCode As String = Request.QueryString("orderhere")

        'If strRenew = "Y" Then
        '    Session(ACC_RENEW_PRODUCT) = IIf(strProductCode = "CP57" OrElse strProductCode = "CP58", "CP53", strProductCode)
        'Else
        '    Session(ACC_RENEW_PRODUCT) = ""
        'End If
        '-----------------------------

        If Not Page.IsPostBack Then
            '--------------
            FillMonthList()
            FillYearList()
            '--------------

            '------------------------------------------------------------
            ' By default all panles can't be shown.
            ShowControls(False, False, False, False, False, False, False)
            ' Preparing all company list 
            PrepareCompanyList()
            '------------------------------------------------------------

            '-------------------------------------------------
            Session(ACC_ISFORMCOMPLETED) = Boolean.FalseString
            '-------------------------------------------------
        End If


        If Session(Me.ACC_ISFORMCOMPLETED) = "" Then
            '-------------------------------------------------------------
            Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Home))
            '-------------------------------------------------------------
        Else
            Session("ACC_ISUPDATESERVICES_VISITED") = True
        End If

    End Sub

    Private Sub pnlPaymentMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPaymentMethod.Load
        'If Not Page.IsPostBack Then
        '    '--------------
        '    RenderGrids()
        '    '--------------
        'End If
    End Sub

    Private Sub btnPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentMethod.Click

        If VerifyPaymentMethodPanel() = True Then

            If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then

                'pnlCrCardInfo.Visible = True
                'pnlPaymentMethod.Visible = False

                ' Set Visible CrCardInfo Panel
                ShowControls(False, False, False, False, True, False, False)
                SetFocus(ddlCardNames)

            Else

                'pnlBankTransfer.Visible = True
                'pnlPaymentMethod.Visible = False

                ' Set Visible BankTransfer Panel
                ShowControls(False, False, False, True, False, False, False)
                SetFocus(txtBankName)

            End If

            pnlInformation.Visible = False

        Else

            pnlInformation.Visible = True
            RenderGrids()
        End If

    End Sub

    Private Sub btnCrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrCardInfo.Click

        If VerifyCreditCardPanel() = True Then

            Select Case ddlCardNames.SelectedItem.Text
                Case "AMEX Card"
                    SetCardHeadings(1)
                    Exit Select
                Case "Debit Card"
                    SetCardHeadings(2)
                    Exit Select
                Case "Switch Card"
                    SetCardHeadings(3)
                    Exit Select
                Case Else
                    CustomerDetail()
            End Select
        Else
            pnlInformation.Visible = True
        End If

    End Sub

    Private Sub btnAmexInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmexInfo.Click

        Dim dteStartDate, dteEndDate As Date
        Dim strMsg As String

        dteStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
        dteEndDate = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        Select Case ddlCardNames.SelectedItem.Text
            Case "AMEX Card"
                If dteStartDate < Now Then
                    strMsg = ACCMessage.Account_AXCardSTDate
                ElseIf dteStartDate > dteEndDate Then
                    strMsg = ACCMessage.Account_AXCardSTDate & " 'Start date' can't be greater than 'Expiry date'."
                End If
                Exit Select
            Case "Switch Card"
                If dteStartDate < Now Then
                    strMsg = "Please enter a valid 'Valid From' date."
                ElseIf dteStartDate > dteEndDate Then
                    strMsg = ACCMessage.Account_AXCardSTDate & " 'Valid From' date can't be greater than 'Expiry date'."
                End If
                Exit Select
            Case Else
                If VerifyDebitCardPanel() Then
                    CustomerDetail()
                End If
                Exit Sub
        End Select

        'If dteStartDate < Now Then ' And dteEndDate < Now Then
        '    strMsg = ACCMessage.Account_AXCardSTDate
        '    'strMsg = strMsg & "," & ACCMessage.Account_AXCardENDate

        '    'ElseIf dteStartDate < Now Then
        '    '    strMsg = ACCMessage.Account_AXCardSTDate

        '    'ElseIf dteEndDate < Now Then
        '    '    strMsg = ACCMessage.Account_AXCardENDate

        'End If

        If strMsg = "" Then
            ' None of the control voilates business rules
            Call CustomerDetail()
        Else
            ' When form controls voilate the business rules
            'pnlInformation.Visible = True
            strMsg = "Please enter valid data in the following field(s):" & "<Br><Br><li>" & Replace(strMsg, ",", "<li>")
            'ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strMsg

            ShowErrorMessage(strMsg, True, True)

        End If


    End Sub

    'Private Sub btnDrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If VerifyDebitCardPanel() = True Then
    '        Call CustomerDetail()
    '    Else
    '        pnlInformation.Visible = True

    '    End If

    'End Sub

    Private Sub btnBankTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankTransfer.Click

        If VerifyBankTransactionPanel() = True Then
            Call CustomerDetail()
        Else
            pnlInformation.Visible = True
        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        RedirectTo(ACC_Redirection.HOMEPAGE)
    End Sub

#End Region

#Region "**************** Helper functions ****************"

    Private Sub SetCardHeadings(ByVal CardType As Integer)
        ShowControls(False, False, False, False, False, True, False)

        lblCardName.Text = txtCardHolderName.Text
        lblCardNumber.Text = txtCardNumber.Text

        lblExpiryDate.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        lblCardAddress.Text = txtCardAddress.Text
        lblSecurityCode.Text = txtSecurityCode.Text

        Select Case CardType
            Case 1
                tdCardHeading.InnerText = "AMEX Card Information"
                trStartDate.Visible = True
                trIssueNumber.Visible = False
                tdStartDate.InnerText = "Start Date (mm / yyyy)"
                SetFocus(ddlAmexSDMonth)
                Exit Select
            Case 2
                tdCardHeading.InnerText = "Debit Card Information"
                trStartDate.Visible = False
                trIssueNumber.Visible = True
                SetFocus(txtIssueNumber)
                Exit Select
            Case 3
                tdCardHeading.InnerText = "Switch Card Information"
                trStartDate.Visible = True
                trIssueNumber.Visible = False
                tdStartDate.InnerText = "Valid From (mm / yyyy)"
                SetFocus(ddlAmexSDMonth)
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub

    Private Function CustomerDetail()

        ShowControls(False, True, False, False, False, False, False)
        ErrorSpan.Visible = False

        'If Session(ACC_ISFORMCOMPLETED) = "" Then Exit Function

        Dim objUser As New User
        Dim objCXLOrder As New CXLOrderProcessing
        Dim objCryptography As New Cryptography
        Dim ds As DataSet

        Dim strAc, strStreet, strTown, strState, strPostCode, strCountry, strEmail, strFnew, _
        strOrderNo, strFShipped, strCardType, strCardNo, strCardName, strCardAddress, strCustomerAddress, _
        strCarriageTC, strWintiprocess, strPayProcessBy, strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
        strProductCodes, strProductTaxCode, strDeliveryAddress, strCustPh, strCardExpires, strStartDate, strEndDate As String

        Dim strTo, strFrom, strSubject, strBody As String

        Dim dteOrderDate, dtePromiseShipDate As DateTime

        Dim dblDiscount, dblOrderAmount, dblCarriageNet, dblCarriageTaxRate, dblProductSalePrice, _
        dblTaxCodeRate, dblUnitPrice As Double

        Dim intRndNo, intEmployeesQty, intQty, intIssueNo, intProductID As Integer

        Dim strGKey, strCreditCardType, strSecurityCode, strCreditCardNo, strCreditCardName, strCreditCardAddress As String
        Dim strGKeyLen As Integer = 1024
        Dim strMsg As String
        Dim strTime As DateTime
        Dim isRetryPayment As Boolean = False

        ''-------------------------------------------
        strGKey = objCXLOrder.AccGetLogKey(CustomerID)
        ''--------------------------------------------

        'If strGKey = "" Then
        '--------------------------------------------
        'strGKey = objCryptography.KeyGen(strGKeyLen)
        '--------------------------------------------
        'End If

        Dim strLogType As String = "C"

        strTime = Now
        strFnew = "y"

        ' default value
        strPayProcessBy = "AC"
        ' strPayProcessBy = "s"
        '-----------
        OrderNo = ""
        '-----------


        '***********************************************************
        ' RETRIEVING CUSTOMER'S DETAILS

        ds = New DataSet

        ds = objUser.GetCustomerData(intCustomerID)
        Dim strFullName, strLoginName, strPaymentMode As String

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
                If Not IsDBNull(dr1.Item(11)) Then strFullName = dr1.Item(11)
                If Not IsDBNull(dr1.Item(11)) Then strLoginName = dr1.Item(12)
            End If
        Catch ex As Exception
            Throw ex
        End Try

        '***********************************************************

        ' THESE FIELDS ARE USED FOR INVOICE 

        strOrderNo = "@ORD"
        dblDiscount = 0.0
        strFShipped = "n"
        dteOrderDate = Now()
        strDeliveryAddress = txtDeliveryAddress.Text
        dtePromiseShipDate = DateSerial(Year(Now), Month(Now), Day(Now) + 7)

        '------------------------------------
        strStartDate = New Date(2000, 1, 1)
        strEndDate = strStartDate
        Dim isCreditCard As Boolean = False
        '------------------------------------

        '****************
        ' Option to choose Cheque Or Bank Transfer / Credit Card

        If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then
            '-------------------------------------------------------------------------------------------------
            strCreditCardType = ddlCardNames.SelectedItem.Text
            strCreditCardNo = txtCardNumber.Text
            strCreditCardName = txtCardHolderName.Text
            strCreditCardAddress = txtCardAddress.Text

            If txtSecurityCode.Text <> "" Then
                '-------------------------------------
                strSecurityCode = txtSecurityCode.Text
                '-------------------------------------
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
            isCreditCard = True
            '-------------------------------------------------------------------------------------------------
        ElseIf rbtPaymentMethod.SelectedItem.Value.ToString = "Cheque Or Bank Transfer" Then
            '-------------------------------------------------------------------------------
            strBankName = txtBankName.Text
            strChequeNo = txtChequeNo.Text
            strSortCode = txtSortCode.Text
            strBankTranRefNo = txtTransactionRefNo.Text

            strPaymentMode = "CB"
            '-------------------------------------------------------------------------------
        End If
        '****************

        strCustomerAddress = strStreet & " " & strTown & " " & strState & " " & strPostCode & " " & strCountry

        If ddlCardNames.SelectedItem.Text = "AMEX Card" OrElse ddlCardNames.SelectedItem.Text = "Switch Card" Then
            '-------------------------------------------------------------------------------
            strStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
            strEndDate = strCardExpires 'DateSerial(ddlAmexEDYear.SelectedItem.Text, ddlAmexEDMonth.SelectedItem.Text + 1, 0)

            Dim intDaySD, intMonthSD, intYearSD As Integer
            ' Dim intDayED, intMonthED, intYearED As Integer

            intDaySD = CInt(Day(strStartDate))
            intMonthSD = CInt(Month(strStartDate))
            intYearSD = CInt(Year(strStartDate))

            'intDayED = CInt(Day(strEndDate))
            'intMonthED = CInt(Month(strEndDate))
            'intYearED = CInt(Year(strEndDate))

            strStartDate = intMonthSD & "/" & intDaySD & "/" & intYearSD
            ' strEndDate = intMonthED & "/" & intDayED & "/" & intYearED

            '-------------------------------------------------------------------------------
        ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then
            '-------------------------------------------------------------------------------

            ' Dim intDayDrSD, intMonthDrSD, intYearDrSD As Integer

            ' strStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

            'intDayDrSD = CInt(Day(strStartDate))
            'intMonthDrSD = CInt(Month(strStartDate))
            'intYearDrSD = CInt(Year(strStartDate))

            'strStartDate = intMonthDrSD & "/" & intDayDrSD & "/" & intYearDrSD

            If txtIssueNumber.Text <> "" Then
                intIssueNo = txtIssueNumber.Text
            End If
            '-------------------------------------------------------------------------------
        End If


        strWintiprocess = "n"

        '---------------------------------------------------
        strProductCodes = ProdcutPackageXML(dblOrderAmount)
        '---------------------------------------------------

        '--------------------------------------------------------------------------------------------------------------------
        objUser.InsertInvoice(intCustomerID, strAc, strTime, strFnew, strOrderNo, strDeliveryAddress, strCustPh, _
                              dblDiscount, strFShipped, dteOrderDate, dtePromiseShipDate, strCardType, strCardNo, _
                              strCardName, strCardExpires, strCardAddress, strCustomerAddress, dblOrderAmount, _
                              strStartDate, strEndDate, strSecurityCode, intIssueNo, strPayProcessBy, strBankName, _
                              strChequeNo, strSortCode, strBankTranRefNo, strWintiprocess, strProductCodes)
        '--------------------------------------------------------------------------------------------------------------------

        If intCustomerID <> 0 Then
            '--------------------------------------------------------------------------------------------------------------------
            objUser.LoadAccountscetreUser(intCustomerID)
            InfoMessage = ACCMessage.Account_UpdateCustomerServices
            REM SR
            FillExpiryRelatedSessionVariables(CustomerID)
            REM SR
            'Dim objEmail As New System.Web.Mail.MailMessage

            Dim strServicesInformation As String = ProdcutPackageXML(, True)

            '====================== NEW CHANGE ======================'
            ' Date          : 28th Feb. 2006
            ' Reason        : Automatically order process by ROBOT
            ' Modified by   : Abid Ali
            '========================================================'
            OrderNo = objCXL.GetLastOrderNo(CustomerID)

            ' Before Change i.e. calling CXL from ishop webservices
            'isRetryPayment = CallCXLProcessing(strLoginName, strPaymentMode)

            CXLProcessing.InsertOrderIntoCxlRobot(isCreditCard, strLoginName, OrderNo, dblOrderAmount, False, strCardNo, strCardType, strCreditCardName, strCardAddress, txtSecurityCode.Text, txtIssueNumber.Text, "826", "GBP", strStartDate, strCardExpires)
            isRetryPayment = False

            strTo = strEmail.ToString
            strFrom = ACCMessage.Email_DefaultEmailAddress
            strSubject = ACCMessage.Email_UpdateServices


            Dim strEmailTemplate As String
            Dim strTemplateSubject As String, intActive As Integer
            Dim dsEmailContent As DataSet

            dsEmailContent = objTemplate.SelectEmailContent("ACRW")
            strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
            strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
            'intActive = dsEmailContent.Tables(0).Rows(0).Item("Active")



            Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
            strbuilder.Replace("[Name]", strFullName).ToString()
            strbuilder.Replace("[LoginID]", strLoginName).ToString()
            strbuilder.Replace("[Address]", strCustomerAddress).ToString()
            strbuilder.Replace("[ServicesInformation]", strServicesInformation).ToString()

            'strBody = "Thank you for subscription/renewal of valuable service(s) with Accounts Centre." & vbCrLf & _
            '                "This email confirms that your request is posted to Accounts Centre Support Team. " & vbCrLf & vbCrLf & _
            '                "You can log in to your account at https://www.accountscentre.com/account/signin.aspx " & vbCrLf & _
            '                "You have applied for/renewed the following service(s):" & vbCrLf & vbCrLf & _
            '                strServicesInformation & vbCrLf & vbCrLf & _
            '                "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
            '                "Email:   support@accountscentre.com " & vbCrLf & _
            '                "Phone:  +44 (0)207 016 2729 (9am - 1pm on weekdays)"

            '"You will receive another email informing you of confirmation of receipt, along with activation of subscribed " & vbCrLf & _
            '"services, generally within 24 working hours." & vbCrLf & vbCrLf & _

            strBody = Me.SendEmailForServiceEnable(intCustomerID, GetSelectedProducts(True, grdPackages, grdProducts, grdPurchasedPackages, grdPurchasedProducts))

            '--------------------------------------------------------------------
            Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
            '--------------------------------------------------------------------

            If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                 strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html, _
                                 strBCC) = "" Then
                EmailManager.CreatDBLog(intCustomerID, "LGIN", strBody.ToString, strFullName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            Else
                EmailManager.CreatDBLog(intCustomerID, "LGIN", strBody.ToString, strFullName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            End If

            'CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '                     strTo.ToString, strTemplateSubject, strbuilder.ToString, MailFormat.Html, _
            '                     ConfigReader.GetItem(ConfigVariables.SMTPUserID))

            'System.Web.Mail.SmtpMail.SmtpServer = Application("SMTPSERVER")

            'objEmail.From = Application("ADMINEMAIL")
            'objEmail.To = strTo.ToString
            'objEmail.Bcc = Application("ADMINEMAILCONFIRMATION")
            'objEmail.Subject = strSubject.ToString
            'objEmail.Body = strBody.ToString

            'PageTemplate.AuthMailMessage(objEmail, Application("SMPTPUSER"), Application("SMPTPPASSWORD"))
            'System.Web.Mail.SmtpMail.Send(objEmail)

            'objEmail = Nothing
            '--------------------------------------------------------------------------------------------------------------------
        End If


        '--------------------------------------
        'Session.Remove(Me.ACC_ORDER_HERE_LINK)
        'Session.Remove(ACC_ISFORMCOMPLETED)
        btnFinish.Visible = True
        '--------------------------------------

        If ErrorSpan.Visible Then
            InfoSpan.Visible = False
        End If
        '============= NEW MODIFICATION FOR RETRY PAYMENT =======================

        If isRetryPayment Then
            '----------------------------------------
            btnRetry.Visible = True
            '----------------------------------------
        Else
            Session.Remove(Me.ACC_ISFORMCOMPLETED)
            Session.Remove(Me.ACC_ORDER_HERE_LINK)
            'Session.Remove(ACC_RENEW_PRODUCT)
        End If
    End Function

    Private Sub FillMonthList()
        Dim i As Integer = 1
        Dim j As Integer = 12

        For i = i To j
            ddlMonth.Items.Add(i)
            ddlAmexSDMonth.Items.Add(i)
            ' ddlAmexEDMonth.Items.Add(i)
            ' ddlDrCardSDMonth.Items.Add(i)
        Next

    End Sub

    Private Sub FillYearList()

        Dim x As Integer = Now.Year
        Dim y As Integer = x + 25

        For x = x To y
            ddlYear.Items.Add(x)
            ddlAmexSDYear.Items.Add(x)
            'ddlAmexEDYear.Items.Add(x)
            'ddlDrCardSDYear.Items.Add(x)
        Next
    End Sub

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
            'Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
        Next
        For Each GridItem In grdProducts.Items
            Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
        Next
        REM SR
        For Each GridItem In grdPurchasedPackages.Items
            Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
        Next
        For Each GridItem In grdPurchasedProducts.Items
            Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
            If Not myCheckbox Is Nothing Then
                If myCheckbox.Checked = True Then
                    rowCount += 1
                End If
            End If
        Next
        REM SR
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

            'Credit Card validation
            Dim ccValidator As New CreditCardValidator(ddlCardNames.SelectedValue, txtCardNumber.Text, txtSecurityCode.Text.Trim)

            If Not ccValidator.Validate Then
                VerifyCreditCardPanel = False
                strReturnMessage &= ccValidator.ErrorMessage
                strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
                ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
            End If

            'Dim strCrCardError As String
            'Dim objCXL As New BLL.CXLOrderProcessing
            ''-------------------------------------------------------------------------------------------------------------------------------
            'If Not objCXL.VerifyCreditCardNumber(ddlCardNames.SelectedValue, txtCardNumber.Text, txtSecurityCode.Text, strCrCardError) Then
            '    VerifyCreditCardPanel = False
            '    strReturnMessage &= strCrCardError
            '    ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
            'End If
            ''-------------------------------------------------------------------------------------------------------------------------------

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

        objRegExp.Add("txtIssueNumber", "0100100100", "Issue No.")

        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        'dteStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

        'If dteStartDate < Now() Then

        '    strMsg = ACCMessage.Account_DrCardDate

        '    If strReturnMessage = "" Then
        '        strReturnMessage = strMsg
        '    Else
        '        strReturnMessage = strReturnMessage & "," & strMsg
        '    End If

        'End If

        If txtIssueNumber.Text.Length > 2 Then
            strReturnMessage = "Issue number at most two digits long."
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

    Private Function ProdcutPackageXML(Optional ByRef dblOrderAmount As Double = 0, _
                                   Optional ByVal bolEmailText As Boolean = False) As String

        Dim strProductCodes As New System.Text.StringBuilder
        Dim ds As DataSet
        Dim objUser As New User

        If Not bolEmailText Then

            strProductCodes.Append("<ROOT>")

        End If

        If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then
            PackageProductCodeIterations(strProductCodes, grdPackages.DataSource, grdPackages, dblOrderAmount, bolEmailText)

            REM SR
            PackageProductCodeIterations(strProductCodes, grdProducts.DataSource, grdPurchasedPackages, dblOrderAmount, bolEmailText)
            REM SR

            PackageProductCodeIterations(strProductCodes, grdPurchasedPackages.DataSource, grdProducts, dblOrderAmount, bolEmailText)

            REM SR
            PackageProductCodeIterations(strProductCodes, grdPurchasedProducts.DataSource, grdPurchasedProducts, dblOrderAmount, bolEmailText)


        Else
            ds = objUser.ACC_UpdatePackageProductDetails(intCustomerID, PackageOptions.EnableSale, _
                                                                      ServiceOptions.EnableSale)

            PackageProductCodeIterations(strProductCodes, ds.Tables(0), grdPackages, dblOrderAmount, bolEmailText)

            REM SR
            PackageProductCodeIterations(strProductCodes, ds.Tables(2), grdPurchasedPackages, dblOrderAmount, bolEmailText)
            REM SR

            PackageProductCodeIterations(strProductCodes, ds.Tables(1), grdProducts, dblOrderAmount, bolEmailText)

            REM SR
            PackageProductCodeIterations(strProductCodes, ds.Tables(3), grdPurchasedProducts, dblOrderAmount, bolEmailText)


        End If

        REM SR

        If Not bolEmailText Then

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
            Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
            If myCheckbox.Checked Then
                If bolEmailText Then
                    strProductCodes.Append(GridItem.Cells(1).Text.ToString & vbCrLf)
                    'strProductCodes.Append(dt.Rows(rowCount).Item("ProductName") & vbCrLf)
                Else
                    strProductCodes.Append("<Product Code=""")
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

    Private Sub grdPurchasedProducts_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPurchasedProducts.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item

                If e.Item.DataItem("ServiceEnabled") = 0 Then
                    e.Item.Cells(0).Text = "N/A"
                Else
                    SetCheckBox(e)

                End If

                If e.Item.DataItem("Status") = 2 Then
                    e.Item.ForeColor = Color.FromName(tcExp.BgColor)
                    e.Item.Font.Bold = UCase(tcExp.Style.Item("FONT-WEIGHT")) = "BOLD"
                ElseIf e.Item.DataItem("Status") = 1 Then
                    e.Item.ForeColor = Color.FromName(tcAbtExp.BgColor)
                    e.Item.Font.Bold = UCase(tcExp.Style.Item("FONT-WEIGHT")) = "BOLD"
                End If
        End Select
    End Sub

    Private Sub grdPurchasedPackages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPurchasedPackages.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item
                SetCheckBox(e)

                If e.Item.DataItem("Status") = 2 Then
                    e.Item.ForeColor = Color.FromName(tcExp.BgColor)
                    e.Item.Font.Bold = UCase(tcExp.Style.Item("FONT-WEIGHT")) = "BOLD"
                ElseIf e.Item.DataItem("Status") = 1 Then
                    e.Item.ForeColor = Color.FromName(tcAbtExp.BgColor)
                    e.Item.Font.Bold = UCase(tcExp.Style.Item("FONT-WEIGHT")) = "BOLD"
                End If
        End Select
    End Sub

    Private Sub RenderGrids()
        Dim ds, ds1 As DataSet

        Dim objuser As New User

        ' INSERT AMOUNT IN PRODUCT SELECTION OF REGISTRATION PROCESS

        ds = objuser.ACC_UpdatePackageProductDetails(intCustomerID, PackageOptions.EnableSale, _
                                                     ServiceOptions.EnableSale)

        If Not CheckOrderHereRow(ds) Then 'Session(ACC_RENEW_PRODUCT) = "" AndAlso (Not CheckOrderHereRow(ds)) Then
            Dim errID As ACC_Error_Messages '= ACC_Error_Messages.ACC_No_Product_Avaiable_For_Purchase

            If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then
                errID = ACC_Error_Messages.ACC_Selected_Service_Already_Purchased
                RedirectToErrorPage(errID)
            End If

        End If
        'Set Grid Headers Localization
        set_culture()
        'End 

        grdPackages.DataSource = ds.Tables(0)
        grdPackages.DataBind()
        REM SR
        hPck.Visible = ds.Tables(0).Rows.Count > 0
        dPck.Visible = ds.Tables(0).Rows.Count > 0
        grdPackages.Visible = ds.Tables(0).Rows.Count > 0
        REM SR

        grdProducts.DataSource = ds.Tables(1)
        grdProducts.DataBind()
        REM SR
        hPrd.Visible = ds.Tables(1).Rows.Count > 0
        dPrd.Visible = ds.Tables(1).Rows.Count > 0
        grdProducts.Visible = ds.Tables(1).Rows.Count > 0

        grdPurchasedPackages.DataSource = ds.Tables(2)
        grdPurchasedPackages.DataBind()
        hPPck.Visible = ds.Tables(2).Rows.Count > 0
        dPPck.Visible = ds.Tables(2).Rows.Count > 0
        grdPurchasedPackages.Visible = ds.Tables(2).Rows.Count > 0

        grdPurchasedProducts.DataSource = ds.Tables(3)
        grdPurchasedProducts.DataBind()

        hPPrd.Visible = ds.Tables(3).Rows.Count > 0
        dPPrd.Visible = ds.Tables(3).Rows.Count > 0
        grdPurchasedProducts.Visible = ds.Tables(3).Rows.Count > 0

        REM SR

        Dim intIndex As Int16

        'If Session("ACC_RENEW_PRODUCT") <> "" Then
        '    For intIndex = 0 To grdPurchasedPackages.Items.Count - 1
        '        If grdPurchasedPackages.Items(intIndex).Cells(0).Controls(1).Visible = True Then

        '            SetFocus(grdPurchasedPackages.Items(intIndex).Cells(0).Controls(1))
        '            intIndex = -1
        '            Exit For
        '        End If
        '    Next

        '    If intIndex > 0 Then
        '        For intIndex = 0 To grdPurchasedProducts.Items.Count - 1
        '            If grdPurchasedProducts.Items(intIndex).Cells(0).Controls(1).Visible = True Then
        '                SetFocus(grdPurchasedProducts.Items(intIndex).Cells(0).Controls(1))
        '                intIndex = -1
        '                Exit For
        '            End If
        '        Next
        '    End If
        'Else
        For intIndex = 0 To grdPackages.Items.Count - 1
            If grdPackages.Items(intIndex).Cells(0).Controls(1).Visible = True Then

                SetFocus(grdPackages.Items(intIndex).Cells(0).Controls(1))
                intIndex = -1
                Exit For
            End If
        Next

        If intIndex > 0 Then
            For intIndex = 0 To grdProducts.Items.Count - 1
                If grdProducts.Items(intIndex).Cells(0).Controls(1).Visible = True Then
                    SetFocus(grdProducts.Items(intIndex).Cells(0).Controls(1))
                    intIndex = -1
                    Exit For
                End If
            Next
        End If
        ' End If




    End Sub
    Private Sub set_culture()
        load_culture(idxTopBar.CultureName)
        Me.grdPackages.Columns(1).HeaderText = load_culturevalue("acc_ghpackagename")
        Me.grdPackages.Columns(2).HeaderText = load_culturevalue("acc_ghdescription")
        Me.grdPackages.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")

        Me.grdProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
        Me.grdProducts.Columns(2).HeaderText = load_culturevalue("acc_ghdescription")
        Me.grdProducts.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")


        Me.grdPurchasedPackages.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
        Me.grdPurchasedPackages.Columns(3).HeaderText = load_culturevalue("acc_ghdescription")
        Me.grdPurchasedPackages.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")

        Me.grdPurchasedProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
        Me.grdPurchasedProducts.Columns(2).HeaderText = load_culturevalue("acc_ghdescription")
        Me.grdPurchasedProducts.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")
    End Sub

    Private Sub grdPackages_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPackages.ItemDataBound
        SetCheckBox(e)
    End Sub

    Private Sub grdProducts_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProducts.ItemDataBound
        SetCheckBox(e)
    End Sub

    Public Sub SetCheckBox(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item
                Dim chkBox As HtmlInputCheckBox
                chkBox = CType(e.Item.Cells(0).Controls(1), HtmlInputCheckBox)
                chkBox.Value = e.Item.DataItem("ProductCode")
                SetOrderHereCheck(chkBox, e)
        End Select
    End Sub

#End Region

#End Region

#Region ":::::::::::::::: CXL Implementation ::::::::::::::::"

    Private Function CallCXLProcessing(ByVal LoginID As Integer, ByVal PaymentMode As String) As Boolean
        If PaymentMode = "CC" Then

            Dim strReturn As String = ""
            Dim strGenricCode As String = "826"

            '------------------------------------------------------
            Dim strMode As String = objCXL.GetPaymentMethodString()
            '------------------------------------------------------

            '-------------------------------------------
            OrderNo = objCXL.GetLastOrderNo(CustomerID)
            txtHiddenOrderID.Text = OrderNo
            '-------------------------------------------

            Trace.Write("Calling CXL......")

            Dim strStatusCXL As String = objCXL.CollectionCXL(CustomerID, LoginID, OrderNo, strMode, strGenricCode, PaymentMode, strReturn)

            Trace.Write("CollectionService XML : " & strReturn)
            Trace.Write("Result : " & strStatusCXL)
            Trace.Write("Checking CXL Result.... ")

            'Calling CheckCollectionStatus and return that value
            Return objCXL.CheckCollectionStatus(CustomerID, LoginID, OrderNo, strStatusCXL, PaymentMode)
            '------------------------------------------------------------------------------------------------------------
        End If

        Return False ' By Default 
    End Function

    Private Sub ShowError(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayError
        '-------------------------------------------------------------------------
        ShowErrorMessage(msg, isVisible, isVisible)
        '-------------------------------------------------------------------------
    End Sub

    Private Sub ShowMessage(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayMessage
        ShowInfoMessage(msg, isVisible, isVisible)
    End Sub

#End Region

#Region ":::::::::::::::: New Methods after Company Selection Criteria ::::::::::::::::"

#Region "**************** Event Handlers ****************"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnCompanyList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompanyList.Click

        With listCompany
            If .SelectedIndex < 0 Then
                '-------------------------------------------------------------
                ShowErrorMessage("Please select the company from the list below.", True, True)
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	03/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        Session("OrderID") = txtHiddenOrderID.Text
        Response.Redirect("/Invoice/UpdatePayementInfo.aspx")
    End Sub
#End Region

#Region "**************** Helper functions ****************"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareCompanyList()
        '------------------------------------------------------------
        PrepareMe()
        If listCompany.Items.Count >= 1 Then ShowControls(True, False, False, False, False, False, False)
        '------------------------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="bRefreshCombo"></param>
    ''' <param name="sGVStatusFilter"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub PrepareMe(Optional ByVal bRefreshCombo As Boolean = False, Optional ByVal sGVStatusFilter As String = "NA")
        '-------------------------------------------
        mbOnlySummary = False
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
        dtCompanies = objGlobalView.getAllCompaniesByFH(Session("ACC_GV_ParentCustomerID"), Session("ACC_GV_Companies"), True)
        dvCompanies = dtCompanies.DefaultView
        '---------------------------------------------------------------------------------------------------------------------

        '-------------------------------------------------------------------------
        Trace.Write("start sorting the filering values")

        If sGVStatusFilter = "NA" Then : dvCompanies.RowFilter = GetFilterString()
        Else : dvCompanies.RowFilter = sGVStatusFilter : End If

        Trace.Write("start sorting the grid values")

        If hSort.Value = "" Then : dvCompanies.Sort = "CompName"
        Else : dvCompanies.Sort = hSort.Value : End If
        '-------------------------------------------------------------------------

        Trace.Write("Pass the sorting func and entering into Postback condition")


        If Not IsPostBack Or bRefreshCombo Then
            '-----------------------------------------------------------------
            GetGlobalViewCompaniesAndInfo(Session("ACC_GV_ParentCustomerID"))
            Trace.Write("Pass Formationshouse webservice status message")
            '-----------------------------------------------------------------

            If dvCompanies.Count > 0 Then
                '--------------------------------------------------------------
                Trace.Write("Entering into Companies greater than 0 condtion")

                mbOnlySummary = True

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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub SignInTheParent()
        '--------------------------------------------------------------------
        Dim sParentUserUID As String = ParentUserID
        FormsAuthentication.SignOut()
        SignInAccountsCentreUSer(sParentUserUID, "DUMMYPASSWORD", True, True)
        '--------------------------------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowPaymentMethod()
        '--------------
        RenderGrids()
        ShowControls(False, False, True, False, False, False, False)
        '--------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function GetFilterString() As String
        '--------------------------
        Select Case hCriteria.Value
            Case 0 : Return "GVStatus=0"
            Case 1 : Return "GVStatus=1 or GVStatus=4"
            Case 2 : Return "GVStatus=2"
            Case Else : Return ""
        End Select
        '--------------------------
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub GetGlobalViewCompaniesAndInfo(ByVal CustomerID As Int32)
        '---------------------------------------------------
        Dim sqlDR As SqlDataReader
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ProcessIfUserCanBeAddedToGlobalView()
        '-----------------------------------------------------
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function CreateGlobalView() As Boolean
        '--------------------------------------------------------------
        Dim sResult As String
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sRegisteredID"></param>
    ''' <param name="sRegisteredUserID"></param>
    ''' <param name="sCompName"></param>
    ''' <param name="sCompNumber"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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
            ShowPaymentMethod()
            '-----------------------------------------------------------------------------
        Else
            'Sign in the parent!
            'SignInTheParent()
            Session("ACC_GV_ProcessCompany") = sCompName
            Session("ACC_GV_CompanyNumber") = sCompNumber
            Response.Redirect("/globalview/selectCustomer.aspx")
        End If
    End Sub

#End Region

#End Region

#Region ":::::::::::::::: Helper Functions/Procedures ::::::::::::::::"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="IsCompanyList"></param>
    ''' <param name="IsInformation"></param>
    ''' <param name="IsPaymentMethod"></param>
    ''' <param name="IsBankTransfer"></param>
    ''' <param name="IsCrCardInfo"></param>
    ''' <param name="IsAmexCardInfo"></param>
    ''' <param name="ISDrCardInfo"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowControls(ByVal IsCompanyList As Boolean, ByVal IsInformation As Boolean, ByVal IsPaymentMethod As Boolean, ByVal IsBankTransfer As Boolean, ByVal IsCrCardInfo As Boolean, ByVal IsAmexCardInfo As Boolean, ByVal ISDrCardInfo As Boolean)
        '------------------------------------------
        pnlCompanyList.Visible = IsCompanyList
        pnlInformation.Visible = IsInformation
        pnlPaymentMethod.Visible = IsPaymentMethod
        pnlBankTransfer.Visible = IsBankTransfer
        pnlCrCardInfo.Visible = IsCrCardInfo
        pnlAmexCardInfo.Visible = IsAmexCardInfo
        'pnlDrCardInfo.Visible = ISDrCardInfo
        '------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ErrMsg"></param>
    ''' <param name="IsVisible"></param>
    ''' <param name="IsPnlInformation"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowErrorMessage(Optional ByVal ErrMsg As String = "", Optional ByVal IsVisible As Boolean = False, Optional ByVal IsPnlInformation As Boolean = False)
        '------------------------------------------
        ErrorMessage = ErrMsg
        ErrorSpan.Visible = IsVisible
        pnlInformation.Visible = IsPnlInformation
        '------------------------------------------
    End Sub

    Private Sub ShowInfoMessage(Optional ByVal infoMsg As String = "", Optional ByVal IsVisible As Boolean = False, Optional ByVal IsPnlInformation As Boolean = False)
        '------------------------------------------
        InfoMessage = infoMsg
        InfoSpan.Visible = IsVisible
        pnlInformation.Visible = IsPnlInformation
        '------------------------------------------
    End Sub

#End Region

End Class

#End Region

#Region ":::::::::::::::: STRUCTURE -> CustomerInformation ::::::::::::::::"

''' -----------------------------------------------------------------------------
''' Project	 : www.accountscentre.com
''' Struct	 : AccountsCentre.Web.CustomerInformation
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     This structure used to strore company information
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.abid]	23/12/2005	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Structure CustomerInformation

#Region ":::::::::::::::: Declaration ::::::::::::::::"
    Public LoginID As String
    Public CompanyName, MemberCustomerID, CompanyRegNo As String
#End Region

#Region ":::::::::::::::: Constructor ::::::::::::::::"
    Public Sub New(ByVal LogID As String, ByVal CompName As String, ByVal MemberCustID As String, ByVal CompRegNo As String)
        LoginID = LogID
        CompanyName = CompName
        MemberCustomerID = MemberCustID
        CompanyRegNo = CompRegNo
    End Sub
#End Region

#Region ":::::::::::::::: ToString Function ::::::::::::::::"
    Public Overrides Function ToString() As String
        Return ("Login ID : " & LoginID & " ::::::: Company Name : " & CompanyName & " ::::::: Member Customer ID : " & MemberCustomerID & " ::::::: Company Registration No. : " & CompanyRegNo)
    End Function
#End Region
End Structure

#End Region