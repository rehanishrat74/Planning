#Region ":::::::::::::::: Imports Liabraries ::::::::::::::::"

Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Web.Mail
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Xml
Imports Infinilogic.CreditCardValidation

#End Region

#Region ":::::::::::::::: CLASS -> UpdatePaymentInfo ::::::::::::::::"

Public Class UpdatePayementInfo
    Inherits PageTemplate

#Region "<<< <<< <<< <<< <<< Web Form Designer Generated Code >>> >>> >>> >>> >>>"

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblOrderNo As System.Web.UI.WebControls.Label

    Private WithEvents objCXL As New CXLProcessing
    Private objCXLOrder As New CXLOrderProcessing
    Public CompanyName As String
    Private AutoGenInv As String
    Dim AutoGenInvoiceNo As String
    Private objUser As AccountsCentre.BLL.User
    Protected WithEvents dgrdUpdatePayInfo As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents lblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents dgrdOrder As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMethod As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDeliveryAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaymentMethod As System.Web.UI.WebControls.Button
    Protected WithEvents pnlChkBank As System.Web.UI.WebControls.Panel
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
    Protected WithEvents lblCardName1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode1 As System.Web.UI.WebControls.Label
    Protected WithEvents btnRetry As System.Web.UI.WebControls.Button
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents pnlRetryPayment As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents txtIssueNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdCardHeading As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trStartDate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdStartDate As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trIssueNumber As System.Web.UI.HtmlControls.HtmlTableRow

    Private intOrderNo As Integer

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Event handlers >>> >>> >>> >>> >>>"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        objUser = New User

        pnlInformation.Visible = False

        CompanyName = Session("CompanyName")
        pnlRetryPayment.Visible = False

        'Put user code to initialize the page here
        If Not IsUpdateOrderPayment() Then

            If Not IsPostBack Then
                '---------------------------
                ' Try
                intOrderNo = -1
                SetDataSource()
                ' Catch ex As Exception
                ' End Try
                '---------------------------
            End If
        Else
            SetOrderInfo(intOrderNo)
            ShowControls(False, False, False, False, True, False)
        End If

        'Reset for future purpose
        Session("CompanyName") = CompanyName

        '---------------
        FillMonthList()
        FillYearList()
        '---------------
    End Sub

    Protected Sub lnkPay_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)

        intOrderNo = lnk.CommandName
        If lnk.CommandArgument Is Nothing Then
            lblStatus.Text = String.Empty
        Else
            lblStatus.Text = lnk.CommandArgument
        End If

        SetOrderInfo(intOrderNo)
        ShowControls(False, False, False, False, True, False)
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
                    'Try
                    UpdatePayment(lblOrderNo.Text, lblStatus.Text)
                    'Catch ex As Exception
                    '    Response.Redirect("/Common/ErrorPage.aspx")
                    'End Try
            End Select
        Else
            pnlInformation.Visible = True
        End If
        'If VerifyCreditCardPanel() Then

        '    If ddlCardNames.SelectedItem.Text = "AMEX Card" Then

        '        ShowControls(False, False, True, False, False, False)

        '        lblCardName.Text = txtCardHolderName.Text
        '        lblCardNumber.Text = txtCardNumber.Text

        '        lblExpiryDate.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        '        lblCardAddress.Text = txtCardAddress.Text
        '        lblSecurityCode.Text = txtSecurityCode.Text

        '        '**************(MNS)****************
        '        SetFocus(ddlAmexSDMonth)
        '        '***********************************

        '    ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

        '        ShowControls(False, False, False, True, False, False)

        '        lblCardName1.Text = txtCardHolderName.Text
        '        lblCardNumber1.Text = txtCardNumber.Text

        '        lblExpiryDate1.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        '        lblCardAddress1.Text = txtCardAddress.Text
        '        lblSecurityCode1.Text = txtSecurityCode.Text

        '        '**************(MNS)****************
        '        SetFocus(ddlDrCardSDMonth)
        '        '***********************************

        '    Else

        '        Try
        '            UpdatePayment(lblOrderNo.Text, lblStatus.Text)
        '        Catch ex As Exception
        '            Response.Redirect("/Common/ErrorPage.aspx")
        '        End Try
        '    End If


        'End If
    End Sub

    Private Sub btnAmexInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmexInfo.Click
        Dim dteStartDate, dteEndDate As Date
        Dim strMsg As String

        dteStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
        dteEndDate = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        Select Case ddlCardNames.SelectedItem.Text
            Case "AMEX Card"
                'If dteStartDate < Now Then
                '    strMsg = ACCMessage.Account_AXCardSTDate
                'ElseIf dteStartDate > dteEndDate Then
                If dteStartDate > dteEndDate Then
                    strMsg = ACCMessage.Account_AXCardSTDate & " 'Start date' can't be greater than 'Expiry date'."
                End If
                Exit Select
            Case "Switch Card"
                'If dteStartDate < Now Then
                '    strMsg = "Please enter a valid 'Valid From' date."
                'ElseIf dteStartDate > dteEndDate Then
                    If dteStartDate > dteEndDate Then
                        strMsg = ACCMessage.Account_AXCardSTDate & " 'Valid From' date can't be greater than 'Expiry date'."
                    End If
                    Exit Select
            Case Else
                    If VerifyDebitCardPanel() Then
                        UpdatePayment(lblOrderNo.Text, lblStatus.Text)
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
            UpdatePayment(lblOrderNo.Text, lblStatus.Text)
        Else
            ' When form controls voilate the business rules
            strMsg = "<li>" & Replace(strMsg, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strMsg

        End If
    End Sub

    'Private Sub btnDrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrCardInfo.Click
    '    If VerifyDebitCardPanel() = True Then
    '        '---------------------------------------------
    '        UpdatePayment(lblOrderNo.Text, lblStatus.Text)
    '        '---------------------------------------------
    '    End If
    'End Sub

    Private Sub btnPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentMethod.Click
        If VerifyPaymentMethodPanel() = True Then

            If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then

                ShowControls(False, True, False, False, False, False)

                SetFocus(ddlCardNames)

            Else
                ShowControls(False, False, False, False, False, True)
                SetFocus(txtBankName)
            End If
        End If
    End Sub

    Private Sub btnBankTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankTransfer.Click
        If VerifyBankTransactionPanel() = True Then
            UpdatePayment(lblOrderNo.Text, lblStatus.Text)
        End If
    End Sub

    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        SetOrderInfo(lblOrderNo.Text)
        ShowControls(False, False, False, False, True, False)
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        ShowError("", False)
        ShowMessage("", False)
        SetDataSource()
    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Helper Functions and Procedures >>> >>> >>> >>> >>>"

    Private Sub SetCardHeadings(ByVal CardType As Integer)
        ShowControls(False, False, True, False, False, False)

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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub SetDataSource()
        'Dim dt As DataTable = objUser.AccGetPaymentInfo(CustomerID)

        Dim dr As SqlDataReader
        Try
            '--------------------------------------------------------------------------------------------------
            Trace.Write("Start to set data source by calling objUser.AccGetPaymentInfo(" & CustomerID & ")")
            dr = objCXLOrder.AccGetPaymentInfo(CustomerID)
            dgrdUpdatePayInfo.DataSource = dr
            dgrdUpdatePayInfo.DataBind()
            ShowControls(True, False, False, False, False, False)
            Trace.Write("End to set data source by calling objUser.AccGetPaymentInfo(" & CustomerID & ")")
            '--------------------------------------------------------------------------------------------------
        Catch ex As Exception
        Finally
            dr.Close()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="OrderNo"></param>
    ''' <param name="strStatus"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub UpdatePayment(ByVal OrderNo As Integer, ByVal strStatus As String)

        '-----------------------------------------
        ' recording order no
        intOrderNo = OrderNo

        ' Clear AutoGenerated
        AutoGenInv = ""
        '-----------------------------------------

        '------------------------------------------------------------------------
        ' Get User Details
        Dim strAC, strUserEmail, strContactName, strName, _
            strCompStatus, strOrderDate, strPayProcessBy, _
            strWintiprocess, strCustomerUID, strGenericCode, _
            strGKey, strCreditCardType, strCreditCardNo, _
            strCreditCardName, strCreditCardAddress, strMsg, strIssueNo As String

        Dim objCryptography As New Cryptography
        Dim dteCardExpires As Date
        Dim strGKeyLen As Integer = 1024, intTrackID As Integer = 0
        Dim objUser As New User
        Dim dsUser As DataSet
        Dim SumCartOrderAmount As Double
        '--------------------------------------------------------------------------

        '--------------------------------------------------------------------------------
        ' Declaration of Card related variables
        Dim strCardType, strCardNo, strCardName, strCardAddress, strCardExpires, _
            strStartDate, strEndDate, strBankName, strChequeNo, strSortCode, _
            strBankTranRefNo, strPaymentMode, strSecurityCode As String

        strCardType = String.Empty
        strCardNo = String.Empty
        strCardName = String.Empty
        strCardAddress = String.Empty
        strStartDate = New Date(2000, 1, 1)
        strEndDate = strStartDate
        strCardExpires = String.Empty
        '----------------------------------------------------------------------------------

        ' Getting customer data
        Try
            '---------------------------------------------------------------------------------------
            Trace.Write("Calling objUser.GetCustomerData(" & CustomerID & ")")
            dsUser = objUser.GetCustomerData(CustomerID)

            If dsUser.Tables(0).Rows.Count < 1 Then
                '---------------------------------------------------------------------
                Trace.Write("Record has not found for customer id is " & CustomerID)
                Exit Sub
                '---------------------------------------------------------------------
            End If
            '----------------------------------------------------------------------------------------
        Catch ex As Exception
            '----------------------------------------------------------------------------------------------------------------------
            Trace.Write("Exception has generated for the method objUser.GetCustomerData(" & CustomerID & ") and stop to process.")
            ''Exit Sub
            Throw ex
            '----------------------------------------------------------------------------------------------------------------------
        End Try

        Trace.Write("Successfully called objUser.GetCustomerData(" & CustomerID & ")")

        '------------------------------------------------
        Dim drUser As DataRow = dsUser.Tables(0).Rows(0)

        strAC = drUser("AC")
        strUserEmail = drUser("Email")
        strContactName = drUser("ContactName")
        strName = drUser("Name")
        strCompStatus = drUser("CompStatus")
        strCustomerUID = drUser("cart_customer_uid")
        '------------------------------------------------

        '------------------------------------------------------------------------------------------------
        ' order related info
        Dim dblOrderAmount As Double
        Dim sqlDrOrder As SqlDataReader

        strGenericCode = "826"

        Try
            '==================================== START TRY BLOCK ====================================
            Trace.Write("Calling objUser.AccGetOrderDetails(" & CustomerID & "," & OrderNo & ")")
            sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, OrderNo)

            If sqlDrOrder.Read Then
                '----------------------------------------------------------
                If Not IsDBNull(sqlDrOrder.Item("GenericCode")) Then
                    strGenericCode = sqlDrOrder.Item("GenericCode")
                End If
                '-----------------------------------------------------------
            Else
                '---------------------------
                strOrderDate = Now.ToString
                dblOrderAmount = 0D
                '---------------------------
            End If
            '==================================== END TRY BLOCK ====================================
        Catch ex As Exception
            '--------


            Throw ex
            '--------
        Finally
            '-------------------------------
            If (Not sqlDrOrder Is Nothing) AndAlso (Not sqlDrOrder.IsClosed) Then
                sqlDrOrder.Close()
            End If
            '-------------------------------
        End Try

        Trace.Write("Successfully called objUser.AccGetOrderDetails(" & CustomerID & "," & OrderNo & ")")
        '------------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------
        ' Calculate Order amount and Outstanding balance
        dblOrderAmount = objCXL.CalculateAccProdAmount(CustomerID, OrderNo, SumCartOrderAmount, intTrackID)
        '--------------------------------------------------------------------------------------

        '-------------------------------------------
        ' PASSWORD ENCRYPTION
        strGKey = objCXLOrder.AccGetLogKey(CustomerID)
        Dim isCreditCard As Boolean = False
        Dim strRobotStartDate, strRobotExpiryDate As String
        '--------------------------------------------


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START IF FOR PAYMENT METHOD ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' Option to choose Cheque Or Bank Transfer / Credit Card

        If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then
            '------------------------------------------------------------------------------------------------
            strCreditCardType = ddlCardNames.SelectedItem.Text
            strCreditCardNo = txtCardNumber.Text
            strCreditCardName = txtCardHolderName.Text
            strCreditCardAddress = txtCardAddress.Text

            If txtSecurityCode.Text <> "" Then
                strSecurityCode = txtSecurityCode.Text
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
            strEndDate = strCardExpires

            strPaymentMode = "CC"
            isCreditCard=True 
            '------------------------------------------------------------------------------------------------

        ElseIf rbtPaymentMethod.SelectedItem.Value.ToString = "Cheque Or Bank Transfer" Then

            '---------------------------------------------------------------------------------
            strBankName = txtBankName.Text
            strChequeNo = txtChequeNo.Text
            strSortCode = txtSortCode.Text
            strBankTranRefNo = txtTransactionRefNo.Text
            strPaymentMode = "CB"
            '---------------------------------------------------------------------------------

        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END IF FOR PAYMENT METHOD ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        ''' If user select credit card option then did he select AMEX or Debit card
        Dim strCustomerAddressForEmail As String = drUser("Street") & "<br> " & drUser("Town") & "<br>" & drUser("State") & "<br>" & drUser("PostCode") & "<br>" & drUser("Country")
        '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START IF FOR CREDIT CARD TYPE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        If ddlCardNames.SelectedItem.Text = "AMEX Card" OrElse ddlCardNames.SelectedItem.Text = "Switch Card" Then

            '---------------------------------------------------------------------------------------------------
            strStartDate = DateSerial(ddlAmexSDYear.SelectedItem.Text, ddlAmexSDMonth.SelectedItem.Text + 1, 0)
            strEndDate = strCardExpires 'DateSerial(ddlAmexEDYear.SelectedItem.Text, ddlAmexEDMonth.SelectedItem.Text + 1, 0)

            Dim intDaySD, intMonthSD, intYearSD As Integer
            'Dim intDayED, intMonthED, intYearED As Integer

            intDaySD = CInt(Day(strStartDate))
            intMonthSD = CInt(Month(strStartDate))
            intYearSD = CInt(Year(strStartDate))


            strStartDate = intMonthSD & "/" & intDaySD & "/" & intYearSD
            'strEndDate = intDayED & "/" & intMonthED & "/" & intYearED
            '---------------------------------------------------------------------------------------------------

        ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

            '------------------------------------------------------------------------------------------------------


            If txtIssueNumber.Text <> "" Then
                strIssueNo = txtIssueNumber.Text
            End If
            '-------------------------------------------------------------------------------------------------------
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END IF FOR CREDIT CARD TYPE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        ' Checking payment mode wheather it is live or test
        Trace.Write("Calling objUser.AccGetPaymentMode() for Test or Live mode.")

        '----------------------------------------------------
        Dim strMode As String = objCXL.GetPaymentMethodString
        '----------------------------------------------------

        Trace.Write("Succefully called objUser.AccGetPaymentMode() for Test or Live mode. Mode is " & strMode)



        Dim strServiceStatus As String  ' For return's result from webservices

        '---------------------------------------------------------------------------------------------------------------------------------------
        ' Calling Repayment Webservices
        Trace.Write("Calling RepaymentCXL.")

        Dim strReturn As String = ""

        strServiceStatus = objCXL.RepaymentCXL(strReturn, OrderNo, CustomerID, strCreditCardType, strCreditCardNo, _
                                        strCreditCardName, strCreditCardAddress, strCardExpires, _
                                        strIssueNo, strSecurityCode, strStartDate, strEndDate, _
                                        strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                                        dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strPaymentMode)

        Trace.Write("Repayment XML : " & strReturn)
        Trace.Write("Successfully called RepaymentCXL and return " & strServiceStatus)

        'strServiceStatus = "0" 'dummy due to change in previous code
        'Dim dteCardExpire, dteStartDate As Date
        'dteCardExpire = GetDate(strCardExpires)
        'dteStartDate = GetDate(strStartDate)


        'objCXL.UpdateInvoiceInfo(OrderNo, strCardType, strCardName, strCardNo, strCardAddress, dteCardExpire, strIssueNo, strSecurityCode, dteStartDate, dteCardExpire, strBankName, strChequeNo, strSortCode, strBankTranRefNo)
        '---------------------------------------------------------------------------------------------------------------------------------------


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START IF FOR CXL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' If the resulted value is numeric then it successfully recorded
        If IsNumeric(strServiceStatus) Then
            '----------------------------------------------------------------------------------------------------------------

            CXLProcessing.InsertOrderIntoCxlRobot(isCreditCard, strCustomerUID, OrderNo, dblOrderAmount, True, txtCardNumber.Text, ddlCardNames.SelectedItem.Text, ddlCardNames.SelectedItem.Text, txtCardAddress.Text, txtSecurityCode.Text, txtIssueNumber.Text, "826", "GBP", strStartDate, strCardExpires, intTrackID)
            ShowMessage("Order payment successfull.<br>PLEASE DO NOT RETRY.", True)
            SetDataSource()
            Exit Sub


            ' Now Calling Collection CXL 
            Trace.Write("Calling CollectionCXL.")
            ' old code from here
            strServiceStatus = objCXL.CollectionCXL(CustomerID, strCustomerUID, OrderNo, strMode, strGenericCode, strPaymentMode, strReturn)

            Trace.Write("CollectionService XML : " & strReturn)
            Trace.Write("Successfully called CollectionCXL and return " & strServiceStatus)

            ' Checking returned result
            If objCXL.CheckCollectionStatus(CustomerID, strCustomerUID, OrderNo, strServiceStatus, strPaymentMode, True) Then
                ShowControls(False, False, False, False, False, False)
                pnlRetryPayment.Visible = True
            Else
                SetDataSource()
            End If
            '----------------------------------------------------------------------------------------------------------------
        Else
            '---------------------------------------------------------------------------------------------------
            ' Display error and get bank or credit card inforation
            ShowError("Some information is missing please give correct information. " & strServiceStatus, True)
            SetDataSource()
            objCXL.AccInsertPaymentErrorLog(CustomerID, lblOrderNo.Text, Now, 0, strServiceStatus)
            '---------------------------------------------------------------------------------------------------
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END IF FOR CXL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    End Sub

    Private Function GetDate(ByVal DateValue As String) As Date
        Dim strExpiry() As String = Split(DateValue, "/")
        Dim dteCardExpire As New Date(strExpiry(2), strExpiry(0), strExpiry(1))

        Return dteCardExpire
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function CalculateAccProdAmount() As Double
        '-------------------------------------------------------------------------
        ' Dim objSelectServices As New Administration.BLL.CustomerSelectedServices
        Dim sqlDrOrder As SqlDataReader
        Dim result As Double = 0
        '-------------------------------------------------------------------------

        Try
            '-----------------------------------------------------------------------
            'Dim dt As DataTable = objSelectServices.GetCustomerServices(CustomerID)
            'Dim dr As DataRow

            sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, lblOrderNo.Text)
            '-----------------------------------------------------------------------

            While sqlDrOrder.Read

                '---------------------------------------------------------------------------------
                'For Each dr In dt.Rows
                '-----------------------------------------------------------------------------
                '  If dr("ProductCode") = sqlDrOrder("code") Then
                result += (CDbl(sqlDrOrder("ProdAmount"))) ' + CDbl(sqlDrOrder("ProdAmount")) * CDbl(sqlDrOrder("Tax")) / 100)
                'Exit For
                ' End If
                '-----------------------------------------------------------------------------
                'Next
                '---------------------------------------------------------------------------------
            End While
        Catch ex As Exception
            Throw ex
        Finally
            '---------------------------------
            If Not sqlDrOrder Is Nothing AndAlso Not sqlDrOrder.IsClosed Then
                sqlDrOrder.Close()
            End If
            '---------------------------------
        End Try

        Return result
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
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowError(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayError
        '-------------------------------------------------------------------------
        ErrorMessage = msg
        ErrorSpan.Visible = isVisible
        ErrorSpan.Attributes.Add("STYLE", "WIDTH: 600px;")
        pnlInformation.Visible = isVisible
        '-------------------------------------------------------------------------
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
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowMessage(ByVal msg As String, ByVal isVisible As Boolean) Handles objCXL.DisplayMessage
        InfoMessage = msg
        InfoSpan.Visible = isVisible
        pnlInformation.Visible = isVisible
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="isDGPayInfo"></param>
    ''' <param name="isCrCardInfo"></param>
    ''' <param name="isAMEX"></param>
    ''' <param name="isDebitCard"></param>
    ''' <param name="isChqBnk"></param>
    ''' <param name="isBankTransfer"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowControls(ByVal isDGPayInfo As Boolean, ByVal isCrCardInfo As Boolean, _
                            ByVal isAMEX As Boolean, ByVal isDebitCard As Boolean, _
                            ByVal isChqBnk As Boolean, ByVal isBankTransfer As Boolean)

        '------------------------------------------
        dgrdUpdatePayInfo.Visible = isDGPayInfo
        pnlCrCardInfo.Visible = isCrCardInfo
        pnlAmexCardInfo.Visible = isAMEX
        'pnlDrCardInfo.Visible = isDebitCard
        pnlChkBank.Visible = isChqBnk
        pnlBankTransfer.Visible = isBankTransfer
        '------------------------------------------

        If Not isDGPayInfo Then
            pnlOrder.Visible = True
        Else
            pnlOrder.Visible = False
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function VerifyCreditCardPanel() As Boolean

        '----------------------------------------------------------------------------------
        VerifyCreditCardPanel = False ' Intentionally make it
        Dim objRegExp As New Infinilogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim dteCrCardExpires As Date
        Dim strMsg As String
        '----------------------------------------------------------------------------------

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        '---------------------------------------------------------------------
        objRegExp.Add("txtCardHolderName", "0700302550", "Card Holder Name")
        objRegExp.Add("txtCardNumber", "0100100200", "Card Number")
        objRegExp.Add("txtCardAddress", "0203502550", "Card Address")
        objRegExp.Add("txtSecurityCode", "0100100101", "Security Code")
        '---------------------------------------------------------------------


        ' Get the return message
        '----------------------------------------
        strReturnMessage = objRegExp.ScanPage(Me)
        '----------------------------------------

        dteCrCardExpires = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

        If dteCrCardExpires < Now() Then
            '--------------------------------------------------------
            strMsg = ACCMessage.Account_CrCardExpiryDate

            If strReturnMessage = "" Then
                strReturnMessage = strMsg
            Else
                strReturnMessage = strReturnMessage & "," & strMsg
            End If
            '---------------------------------------------------------
        End If



        '----------------------------------------------------------------------------------
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
            '------------------------------------------------------------------------------------------------------
            ' When form controls voilate the business rules
            VerifyCreditCardPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
            '-------------------------------------------------------------------------------------------------------
        End If
        '----------------------------------------------------------------------------------

        objRegExp = Nothing

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function VerifyDebitCardPanel() As Boolean

        '----------------------------------------------------------------------------------
        VerifyDebitCardPanel = False ' Intentionally make it
        Dim objRegExp As New Infinilogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim dteStartDate As Date
        Dim strMsg As String
        '----------------------------------------------------------------------------------

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        '------------------------------------------------------
        objRegExp.Add("txtIssueNumber", "0100100020", "Issue Number")
        '------------------------------------------------------

        ' Get the return message
        '----------------------------------------
        strReturnMessage = objRegExp.ScanPage(Me)
        '----------------------------------------

        'dteStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

        'If dteStartDate < Now() Then
        '    ---------------------------------------------------------
        '    strMsg = ACCMessage.Account_DrCardDate

        '    If strReturnMessage = "" Then
        '        strReturnMessage = strMsg
        '    Else
        '        strReturnMessage = strReturnMessage & "," & strMsg
        '    End If
        '    ----------------------------------------------------------
        'End If

        If txtIssueNumber.Text.Length > 2 Then
            strReturnMessage = "Issue number at most two digits long."
        End If

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyDebitCardPanel = True
        Else
            '--------------------------------------------------------------------------------------------------------
            ' When form controls voilate the business rules
            VerifyDebitCardPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
            '-------------------------------------------------------------------------------------------------------
        End If

        objRegExp = Nothing

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="OrderID"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub SetOrderInfo(ByVal OrderID As Integer)
        lblOrderNo.Text = OrderID
        Dim dr As SqlDataReader

        Try
            dr = objCXLOrder.AccGetOrderDetails(CustomerID, OrderID)
            dgrdOrder.DataSource = dr
            dgrdOrder.DataBind()
        Catch ex As Exception
        Finally
            dr.Close()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub FillMonthList()
        Dim i As Integer = 1
        Dim j As Integer = 12

        For i = i To j
            ddlMonth.Items.Add(i)
            ddlAmexSDMonth.Items.Add(i)
            'ddlAmexEDMonth.Items.Add(i)
            'ddlDrCardSDMonth.Items.Add(i)
        Next

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub FillYearList()

        Dim x As Integer = 2000
        Dim y As Integer = 2050

        For x = x To y
            ddlYear.Items.Add(x)
            ddlAmexSDYear.Items.Add(x)
            'ddlAmexEDYear.Items.Add(x)
            'ddlDrCardSDYear.Items.Add(x)
        Next

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function EmailSubject() As String
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer
        Dim objTemplate As New TemplateReader

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent("LGIN")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        Return strTemplateSubject

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="Name"></param>
    ''' <param name="strLoginID"></param>
    ''' <param name="strpassword"></param>
    ''' <param name="strCustomerAddress"></param>
    ''' <param name="strServicesInformation"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function SelectEmailContent(ByVal Name As String, ByVal strLoginID As String, Optional ByVal strpassword As String = "", Optional ByVal strCustomerAddress As String = "", Optional ByVal strServicesInformation As String = "") As String
        Dim strFullName As String = Name 'strSurName & strFirstName & strSecondName
        Dim LoginID As String = strLoginID 'intRndNo & intCustomerID
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer
        Dim objTemplate As New TemplateReader

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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="OrderID"></param>
    ''' <param name="CustomerID"></param>
    ''' <param name="LoginID"></param>
    ''' <param name="PayAmt"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub CreateAutoGeneratedInvoice(ByVal OrderID As Integer, ByVal CustomerID As Integer, ByVal LoginID As Integer, ByVal PayAmt As Double)

        '--------------------------------------------------------------------------------------------------------
        AutoGenInv = "<Data><order_id>" & OrderID & "</order_id><merchant_id>2</merchant_id>" & _
                                    "<merchant_uid>26</merchant_uid>" & _
                                    "<customer_id>" & CustomerID & "</customer_id>" & _
                                    "<cart_customer_uid>" & LoginID & "</cart_customer_uid>" & _
                                    "<track_id><!--TRACKID--></track_id><pay_amt>" & PayAmt & "</pay_amt>" & _
                                    "</Data>"
        '--------------------------------------------------------------------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="TrackID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function AutoGeneratedInvoice(ByVal TrackID As Integer) As Boolean

        'If Not AutoGenInv = "" Then
        '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        '    AutoGenInv = Replace(AutoGenInv, "<!--TRACKID-->", TrackID.ToString)
        '    Trace.Write("AutoGeneratedInvoice XML : " & AutoGenInv)

        '    Dim o As New com.webservices.ishops.WebService

        '    '-------------------------------------------------------------------------------------------------------------------------------------------------------
        '    Dim key As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        '    Dim userid As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        '    Dim pwd As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        '    Dim domain As String = EncryptionDecryption.DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        '    o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        '    Dim res As String = o.Auto_Generate_Invoice_Update_ProOrderInvoice(AutoGenInv)

        '    o.Dispose()
        '    o = Nothing
        '    Trace.Write("Response AutoGeneratedInvoice XML : " & res)
        '    '-------------------------------------------------------------------------------------------------------------------------------------------------------

        '    Dim ds As New DataSet
        '    Dim strID, strMsg As String

        '    Try
        '        '-------------------------------------------------------------------------------------
        '        ds = ConvertXMLToDataSet(res)
        '        '-------------------------------------------------------------------------------------

        '        If ds.Tables.Count > 0 Then ' don't blank message
        '            If ds.Tables(0).Rows.Count > 0 Then
        '                '---------------------------------------------------------------------------------------------------------------------------------------------
        '                strID = ds.Tables(0).Rows(0)(0)
        '                strMsg = ds.Tables(0).Rows(0)(1)
        '                AutoGenInvoiceNo = ds.Tables(0).Rows(0)(2)

        '                If strID <> 0 Then
        '                    '--------------------------------------------------------------------------------------------------------------------------------------
        '                    ShowError("Order has been processed but Invoice can't generated. Due to following reason.<br>" & strMsg & "<br> Please contact with your administrator.", True)
        '                    AccInsertPaymentErrorLog(CustomerID, lblOrderNo.Text, Date.Now, strID, strMsg)
        '                    SetDataSource()
        '                    Return False
        '                    '---------------------------------------------------------------------------------------------------------------------------------------
        '                End If
        '                '-----------------------------------------------------------------------------------------------------------------------------------------------
        '            End If
        '        Else ' blank message
        '            '---------------------------------------------------------------------------------------------------------------------------------------------------------
        '            ShowError("Order has been processed but Invoice can't generated.<br> Please contact with your administrator.", True)
        '            AccInsertPaymentErrorLog(CustomerID, lblOrderNo.Text, Date.Now, 0, "Auto_Generate_Invoice_Update_ProOrderInvoice return blank message which is '" & res & "'")
        '            Return False
        '            '----------------------------------------------------------------------------------------------------------------------------------------------------------
        '        End If

        '    Catch ex As Exception
        '        ShowError("Order has been processed but Invoice can't generated.<br> Please contact with your administrator.", True)
        '        Return False
        '    End Try
        '    '---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        'End If

        Return True
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function VerifyPaymentMethodPanel() As Boolean

        '--------------------------------------------------------------------------------------------------------
        VerifyPaymentMethodPanel = False ' Intentionally make it
        Dim objRegExp As New Infinilogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim rowCount As Integer = 0
        '--------------------------------------------------------------------------------------------------------

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        If strMsg = "" Then
            '--------------------------------------------------------------------------
            ' Add the controls 
            objRegExp.Add("txtDeliveryAddress", "0203502551", "Delivery Address")

            ' Get the return message
            strReturnMessage = objRegExp.ScanPage(Me)
            '--------------------------------------------------------------------------
        End If

        ' Now make decision, whether error has been returned or not 

        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyPaymentMethodPanel = True
        Else
            '--------------------------------------------------------------------------------------------------------
            ' When form controls voilate the business rules
            VerifyPaymentMethodPanel = False
            strReturnMessage = Replace(strReturnMessage, ",", "<li>")
            If strMsg = "" Then
                '------------------------------------------------------------------------------------------------------
                ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br><li>" & strReturnMessage
                '------------------------------------------------------------------------------------------------------
            ElseIf strMsg = "0" Then
                '---------------------------------------
                ErrorMessage = strReturnMessage & "<Br>"
                '---------------------------------------
            Else
                '------------------------------------------------------------------------------------------------
                ErrorMessage = "Following Packages/Products have same Services. " & "<Br><Br>" & strReturnMessage
                '------------------------------------------------------------------------------------------------
            End If
            '--------------------------------------------------------------------------------------------------------
        End If

        objRegExp = Nothing

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	07/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function VerifyBankTransactionPanel() As Boolean

        '--------------------------------------------------------------------------------------------------------
        VerifyBankTransactionPanel = False ' Intentionally make it
        Dim objRegExp As New Infinilogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        '--------------------------------------------------------------------------------------------------------

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        '-------------------------------------------------------------------------------
        objRegExp.Add("txtBankName", "0700300501", "Bank Name")
        objRegExp.Add("txtChequeNo", "0700300101", "Cheque No.")
        objRegExp.Add("txtSortCode", "0700300101", "Sort Code")
        objRegExp.Add("txtTransactionRefNo", "0700300101", "Transaction Reference No.")
        '-------------------------------------------------------------------------------

        ' Get the return message
        '----------------------------------------
        strReturnMessage = objRegExp.ScanPage(Me)
        '----------------------------------------

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyBankTransactionPanel = True
        Else
            '---------------------------------------------------------------------------------------------------
            ' When form controls voilate the business rules
            VerifyBankTransactionPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
            '---------------------------------------------------------------------------------------------------
        End If

        objRegExp = Nothing

    End Function

    Private Function IsUpdateOrderPayment() As Boolean

        If Not (Session("OrderID") Is Nothing) Then
            intOrderNo = Session("OrderID")
            lblStatus.Text = "N"
            Session("OrderID") = Nothing
            Return True
        End If

        Return False
    End Function

#End Region

    
End Class

#End Region

