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
                Try
                    intOrderNo = -1
                    SetDataSource()
                Catch ex As Exception
                End Try
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
                    Try
                        UpdatePayment(lblOrderNo.Text, lblStatus.Text)
                    Catch ex As Exception
                        Response.Redirect("/Common/ErrorPage.aspx")
                    End Try
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
            strCreditCardName, strCreditCardAddress, strMsg As String

        Dim objCryptography As New Cryptography
        Dim dteCardExpires As Date
        Dim intSecurityCode, intIssueNo As Integer
        Dim strGKeyLen As Integer = 1024
        Dim objUser As New User
        Dim dsUser As DataSet
        Dim SumCartOrderAmount As Double
        '--------------------------------------------------------------------------

        '--------------------------------------------------------------------------------
        ' Declaration of Card related variables
        Dim strCardType, strCardNo, strCardName, strCardAddress, strCardExpires, _
            strStartDate, strEndDate, strBankName, strChequeNo, strSortCode, _
            strBankTranRefNo, strPaymentMode As String

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
            Exit Sub
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
        dblOrderAmount = objCXL.CalculateAccProdAmount(CustomerID, OrderNo, SumCartOrderAmount)
        '--------------------------------------------------------------------------------------

        '-------------------------------------------
        ' PASSWORD ENCRYPTION
        strGKey = objCXLOrder.AccGetLogKey(CustomerID)
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

            strCardExpires = intDayCEx & "/" & intMonthCEx & "/" & intYearCEx

            strPaymentMode = "CC"
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

            'intDayED = CInt(Day(strEndDate))
            'intMonthED = CInt(Month(strEndDate))
            'intYearED = CInt(Year(strEndDate))

            strStartDate = intDaySD & "/" & intMonthSD & "/" & intYearSD
            'strEndDate = intDayED & "/" & intMonthED & "/" & intYearED
            '---------------------------------------------------------------------------------------------------

        ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

            '------------------------------------------------------------------------------------------------------
            ' Dim intDayDrSD, intMonthDrSD, intYearDrSD As Integer

            'strStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

            'intDayDrSD = CInt(Day(strStartDate))
            'intMonthDrSD = CInt(Month(strStartDate))
            'intYearDrSD = CInt(Year(strStartDate))

            ' strStartDate = intDayDrSD & "/" & intMonthDrSD & "/" & intYearDrSD

            If txtIssueNumber.Text <> "" Then
                intIssueNo = txtIssueNumber.Text
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

        strServiceStatus = objCXL.RepaymentCXL(strReturn, OrderNo, CustomerID, strCardType, strCardNo, _
                                        strCardName, strCardAddress, strCardExpires, _
                                        intIssueNo.ToString, intSecurityCode.ToString, strStartDate, strEndDate, _
                                        strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                                        dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strMode)

        Trace.Write("Repayment XML : " & strReturn)
        Trace.Write("Successfully called RepaymentCXL and return " & strServiceStatus)
        '---------------------------------------------------------------------------------------------------------------------------------------


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START IF FOR CXL ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' If the resulted value is numeric then it successfully recorded
        If IsNumeric(strServiceStatus) Then
            '----------------------------------------------------------------------------------------------------------------
            ' Now Calling Collection CXL 
            Trace.Write("Calling CollectionCXL.")

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
        Finally
            '---------------------------------
            If Not sqlDrOrder.IsClosed Then
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
        Dim objRegExp As New InfiniLogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
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
        Dim objRegExp As New InfiniLogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
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
        objRegExp.Add("txtIssueNumber", "0100100100", "Issue Number")
        '------------------------------------------------------

        ' Get the return message
        '----------------------------------------
        strReturnMessage = objRegExp.ScanPage(Me)
        '----------------------------------------

        'dteStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

        'If dteStartDate < Now() Then
        '    '---------------------------------------------------------
        '    strMsg = ACCMessage.Account_DrCardDate

        '    If strReturnMessage = "" Then
        '        strReturnMessage = strMsg
        '    Else
        '        strReturnMessage = strReturnMessage & "," & strMsg
        '    End If
        '    '----------------------------------------------------------
        'End If


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

        Dim x As Integer = Now.Year
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
        Dim objRegExp As New InfiniLogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
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
        Dim objRegExp As New InfiniLogic.AccountsCentre.common.RegularExpressions   ' Object of InfinLogic library
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

#Region ":::::::::::::::: CLASS -> CXLProcessing ::::::::::::::::"

Public Class CXLProcessing

#Region "<<< <<< <<< <<< <<< Event declaration >>> >>> >>> >>> >>>"

    'Public Delegate Sub ShowInformation(ByVal Message As String, ByVal IsVisible As Boolean)
    'Public ShowError, ShowMessage As ShowInformation

    Public Event DisplayMessage(ByVal Message As String, ByVal IsVisible As Boolean)
    Public Event DisplayError(ByVal Message As String, ByVal IsVisible As Boolean)


#End Region

#Region "<<< <<< <<< <<< <<< CXL and Helper functions/procedures >>> >>> >>> >>> >>>"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intCustID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetLastOrderNo(ByVal intCustID As Integer) As Integer
        Dim dr As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        Dim RetVal As Integer = -1

        Try
            dr = objCXLOrder.AccGetOrderDetails(intCustID, IsLast:=True)

            While dr.Read
                RetVal = CInt(dr("OrderNo"))
            End While

        Catch ex As Exception
        Finally
            dr.Close()
        End Try

        Return RetVal
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''   this mehtod check return order status and if response code is 
    '''     equal to 30 then retunr true else return false
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="LoginID"></param>
    ''' <param name="OrderNo"></param>
    ''' <param name="strStatus"></param>
    ''' <param name="PaymentMethod"></param>
    ''' <param name="IsUpdatePaymentInfo"></param>
    ''' <returns>True if ResponseCode is equal to 30</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	29/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CheckCollectionStatus(ByVal CustomerID As Integer, ByVal LoginID As Integer, ByVal OrderNo As Integer, ByVal strStatus As String, ByVal PaymentMethod As String, Optional ByVal IsUpdatePaymentInfo As Boolean = False) As Boolean

        Dim ds As New DataSet
        Dim sqlDR As SqlDataReader
        Dim strCollectionTID, strResponseCode, strRefNo, strMsg As String

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~ RESPONSE CODE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' ----------------------------------------------------------------------------------
        '| CASE |   MESSAGE             |       REASON                                      |
        '-----------------------------------------------------------------------------------
        '| 00    | AUTH code: nnnnnn    | The card is accepted and authorisation granted    |
        '|       |                      | ( nnnnnn can be an alphanumeric value between 2   |
        '|       |                      | and 8 digits.                                     |
        '-----------------------------------------------------------------------------------
        '| 2    | Referral B            | The card had been rejected as over ceiling limit. |
        '-----------------------------------------------------------------------------------
        '| 5    | Not Authorised        | Authorisation has been refused.                   |
        '|      | Declined              | Authorisation has been refused.                   |
        '|      | Error Resubmit        | Problem with card data.                           |
        '|      | AAV Fail: nn          | AAV Response code.                                |
        '-----------------------------------------------------------------------------------
        '| 30   | Invalid Merchant      | The merchant number used is not set-up.           |
        '|      | Referral X            | The card has expired.                             |
        '|      | Invalid Trans         | The card has expired.                             |
        '|      | Invalid Amount        | The card has expired.                             |
        '|      | Invalid Card No       | The card has expired.                             |
        '|      | Duplicate Trans       | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 54   | Expired Card          | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 91   | COMMS FAULT           | Returned by CCARD to indicate local Comms fault   |
        '|      |                       | (i.e. modem problem).                             |
        '-----------------------------------------------------------------------------------
        '| 92   | Manual AUTH           | Remote acquirer not responding.                   |
        '-----------------------------------------------------------------------------------
        ' Some response codes and message test may vary according to the acquirer. For a 
        ' definitive list of response codes and messages please refer to the acquirer's
        ' Technical Specification.


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

                    If PaymentMethod = "CC" Then
                        '-------------------------------------------
                        EnableServices(CustomerID, LoginID, OrderNo)
                        '-------------------------------------------
                    End If

                    '-------------------------------------------------------------------------------
                    If IsUpdatePaymentInfo Then
                        'ShowMessage("Order payment has been successed.<br> Please do not retry.", True)
                        RaiseEvent DisplayMessage("Order payment successfull.<br>PLEASE DO NOT RETRY.", True)
                    End If
                    '-------------------------------------------------------------------------------

                    If CInt(strCollectionTID) < 0 Then
                        '----------------------------------------------------------------------------------------------------------------------------------
                        Dim strBody As String = "<b>Login ID " & LoginID & "<br>Order No. " & OrderNo & "</b><br>Payment has been successed but return TracID is " & strCollectionTID
                        '----------------------------------------------------------------------------------------------------------------------------------

                        '------------------------------------------------------------------------------------------------------------
                        If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", strBody, MailFormat.Html, _
                                ConfigReader.GetItem(ConfigVariables.EmailBCC)) Then
                            EmailManager.CreatDBLog(CustomerID, "ACSA", strBody.ToString, "", ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                        Else
                            EmailManager.CreatDBLog(CustomerID, "ACSA", strBody.ToString, "", ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                        End If
                        '------------------------------------------------------------------------------------------------------------
                    End If

                    '-------------------------------------------------------------------------------------------------------------------------------------
                ElseIf CInt(strResponseCode) > 0 Then   ' Credit Card Decline
                    '-------------------------------------------------------------------------------------------
                    Select Case CInt(strResponseCode)
                        Case 2, 5, 30, 54, 91, 92

                            RaiseEvent DisplayError(GetPredefinedError(CInt(strResponseCode)), True)

                            '-------------------------------------------------------------------------------------------------------------------------------------------------------
                            Dim strBody As String = "<b>Login ID " & LoginID & "<br>Order No. " & OrderNo & "</b><br>Credit Card declined but return TracID is " & strCollectionTID
                            '-------------------------------------------------------------------------------------------------------------------------------------------------------

                            '------------------------------------------------------------------------------------------------------------
                            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                    ACCMessage.Email_DefaultEmailAddress, "Calling CXL in Update Services.", strBody, MailFormat.Html, _
                                    ConfigReader.GetItem(ConfigVariables.EmailBCC))
                            '------------------------------------------------------------------------------------------------------------

                            Return True ' because response code is 30

                        Case Else
                            RaiseEvent DisplayError(strMsg, True) : Exit Select
                    End Select
                  
                    '-------------------------------------------------------------------------------------------
                Else    ' < 0 
                    '-------------------------------------------------------------------------------------------
                    If (CInt(strResponseCode <> -500)) Then
                        RaiseEvent DisplayError(strMsg, True)
                    End If

                    ' Error Log
                    AccInsertPaymentErrorLog(CustomerID, OrderNo, Date.Now, strResponseCode, strMsg)
                    '-------------------------------------------------------------------------------------------
                End If


            Else ' CX Transaction failure
                '--------------------------------------------------------------------
                ShowResponseError(CustomerID, OrderNo, ds.Tables(0).Rows(0)(0), ds.Tables(0).Rows(0)(1))
                '--------------------------------------------------------------------
            End If
        Catch ex As Exception
        End Try

        Return False ' because response code is not 30
    End Function

    Private Function GetPredefinedError(ByVal ResponseCode As Integer) As String

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~ RESPONSE CODE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' ----------------------------------------------------------------------------------
        '| CASE |   MESSAGE             |       REASON                                      |
        '-----------------------------------------------------------------------------------
        '| 00    | AUTH code: nnnnnn    | The card is accepted and authorisation granted    |
        '|       |                      | ( nnnnnn can be an alphanumeric value between 2   |
        '|       |                      | and 8 digits.                                     |
        '-----------------------------------------------------------------------------------
        '| 2    | Referral B            | The card had been rejected as over ceiling limit. |
        '-----------------------------------------------------------------------------------
        '| 5    | Not Authorised        | Authorisation has been refused.                   |
        '|      | Declined              | Authorisation has been refused.                   |
        '|      | Error Resubmit        | Problem with card data.                           |
        '|      | AAV Fail: nn          | AAV Response code.                                |
        '-----------------------------------------------------------------------------------
        '| 30   | Invalid Merchant      | The merchant number used is not set-up.           |
        '|      | Referral X            | The card has expired.                             |
        '|      | Invalid Trans         | The card has expired.                             |
        '|      | Invalid Amount        | The card has expired.                             |
        '|      | Invalid Card No       | The card has expired.                             |
        '|      | Duplicate Trans       | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 54   | Expired Card          | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 91   | COMMS FAULT           | Returned by CCARD to indicate local Comms fault   |
        '|      |                       | (i.e. modem problem).                             |
        '-----------------------------------------------------------------------------------
        '| 92   | Manual AUTH           | Remote acquirer not responding.                   |
        '-----------------------------------------------------------------------------------
        ' Some response codes and message test may vary according to the acquirer. For a 
        ' definitive list of response codes and messages please refer to the acquirer's
        ' Technical Specification.

        Select Case ResponseCode
            Case 2
                Return "The card had been rejected as over ceiling limit."
            Case 5
                Return "Authorisation has been refused OR Problem with card data OR AAV Response Code."
            Case 30
                Return "Invalid card number OR The card has expired."
            Case 91
                Return "Returned by CARD to indicate local Communications fault (i.e. modem problem)."
            Case 92
                Return "Remote acquirer not responding."
            Case Else
                Return ""
        End Select
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderNo"></param>
    ''' <param name="ErrorCode"></param>
    ''' <param name="ErrorMsg"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowResponseError(ByVal CustomerID As Integer, ByVal OrderNo As Integer, ByVal ErrorCode As String, ByVal ErrorMsg As String)

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


            'ShowMessage("Order is under process. Please contact with administration.", True)
            RaiseEvent DisplayMessage("Order is under process. Please contact with administration.", True)
            '-------------------------------------------------------------------------------------------------------------------------------
        ElseIf ErrorCode = "-500" Then
            '-------------------------------------------------------------------------------------------------------------------------------
            '''<ERRORCODE>-500</ERRORCODE>
            '''<ERRORMSG>Not Approved Floor Limit of customer. Notification has been sent to Administrator and waiting for further acceptance.</ERRORMSG>
            ''' OR
            ''' <ERRORMSG>You are exceding limit of no of transactions allowed per day. Please refer to site Administrator.</ERRORMSG>
            RaiseEvent DisplayError("For order number " & OrderNo & ". <br>" & ErrorMsg, True)
            'ShowError("For order number " & OrderNo & ". <br>" & ErrorMsg, True)
            '-------------------------------------------------------------------------------------------------------------------------------
        End If

        '----------------------------------------------------------------------------------
        AccInsertPaymentErrorLog(CustomerID, OrderNo, Date.Now, ErrorCode, ErrorMsg)
        '
        '----------------------------------------------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="CustomerUID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="Mode"></param>
    ''' <param name="GenericCode"></param>
    ''' <param name="PaymentMode"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CollectionCXL(ByVal CustomerID As String, ByVal CustomerUID As String, _
                                   ByVal OrderID As String, ByVal Mode As String, _
                                   ByVal GenericCode As String, ByVal PaymentMode As String, ByRef ReturnValue As String) As String

        '---------------------------------------------------------------------------------------------
        Dim strXML As String = "<Data><Sender>ACCOUNTSCENTRE</Sender><MerchantID>2</MerchantID>" & _
                                "<MerchantUID>26</MerchantUID><CustomerID>" & _
                                CustomerID & "</CustomerID><CustomerUID>" & _
                                CustomerUID & "</CustomerUID><OrderID>" & _
                                OrderID & "</OrderID><Mode>" & _
                                Mode & "</Mode><GenericCode>" & _
                                GenericCode & "</GenericCode><PaymentMode>" & _
                                PaymentMode & "</PaymentMode></Data>"

        ReturnValue = "CollectionCXL XML : " & strXML
        '---------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------
        Dim o As New com.webservices.ishops.WebService

        Dim key As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        Dim userid As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        Dim pwd As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        Dim domain As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        Dim res As String = o.CollectionServices(strXML)

        o.Dispose()
        o = Nothing
        '--------------------------------------------------------------------------------------------------------

        Return res
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="ErrorDate"></param>
    ''' <param name="ErrorCode"></param>
    ''' <param name="ErrorMsg"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AccInsertPaymentErrorLog(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal ErrorDate As DateTime, ByVal ErrorCode As Integer, ByVal ErrorMsg As String)
        Dim objCXLOrder As New CXLOrderProcessing
        objCXLOrder.AccInsertPaymentErrorLog(CustomerID, OrderID, ErrorDate, ErrorCode, ErrorMsg)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xmlData"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="LoginID"></param>
    ''' <param name="OrderNo"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub EnableServices(ByVal CustomerID As Integer, ByVal LoginID As Integer, ByVal OrderNo As Integer)

        '-------------------------------------------------------------------------
        Dim objSelectServices As New Administration.BLL.CustomerSelectedServices
        Dim sqlDrOrder As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        '-------------------------------------------------------------------------

        Try
            '-----------------------------------------------------------------------
            'Dim dt As DataTable = objSelectServices.GetCustomerServices(CustomerID)
            'Dim dr As DataRow

            ' sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, OrderNo, False, True)
            '-----------------------------------------------------------------------

            While sqlDrOrder.Read
                '--------------------------------------------------------------------------------------------------------
                ' For Each dr In dt.Rows
                '-----------------------------------------------------------------------------------------------------
                'If dr("ProductCode") = sqlDrOrder("code") Then
                objSelectServices.ManageAccountsCentreServices(sqlDrOrder("ServiceID"), CustomerID, LoginID, "Enable", DateAdd(DateInterval.Year, 1, Now))
                '  Exit For
                'End If
                '-----------------------------------------------------------------------------------------------------
                ' Next
                '--------------------------------------------------------------------------------------------------------
            End While

        Catch ex As Exception
        Finally
            sqlDrOrder.Close()
        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intCustID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetOrderNo(ByVal intCustID As Integer) As Integer
        Dim dr As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        Dim RetVal As Integer = -1

        Try
            dr = objCXLOrder.AccGetOrderDetails(intCustID)
            If dr.Read Then
                RetVal = CInt(dr("OrderNo"))
            End If
        Catch ex As Exception
        Finally
            dr.Close()
        End Try

        Return RetVal
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="PaymentMethod"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetPaymentMethodString() As String
        Dim objCXLOrder As New CXLOrderProcessing
        If objCXLOrder.AccGetPaymentMode() Then
            Return "Live"
        End If

        Return "Test"

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ReturnValue"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="CustomerID"></param>
    ''' <param name="CardType"></param>
    ''' <param name="CardNo"></param>
    ''' <param name="CardName"></param>
    ''' <param name="CardAddress"></param>
    ''' <param name="CardExpiry"></param>
    ''' <param name="IssueNumber"></param>
    ''' <param name="SecurityCode"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="BankName"></param>
    ''' <param name="BankChqNo"></param>
    ''' <param name="BankSortCode"></param>
    ''' <param name="BankRefNo"></param>
    ''' <param name="RPInvAmt"></param>
    ''' <param name="RPPaidAmt"></param>
    ''' <param name="RPOutstandingAmt"></param>
    ''' <param name="RPNewAmt"></param>
    ''' <param name="PayMode"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function RepaymentCXL(ByRef ReturnValue As String, ByVal OrderID As String, ByVal CustomerID As String, _
                                   ByVal CardType As String, ByVal CardNo As String, _
                                   ByVal CardName As String, ByVal CardAddress As String, _
                                   ByVal CardExpiry As String, ByVal IssueNumber As String, _
                                   ByVal SecurityCode As String, ByVal StartDate As String, _
                                   ByVal EndDate As String, ByVal BankName As String, _
                                   ByVal BankChqNo As String, ByVal BankSortCode As String, _
                                   ByVal BankRefNo As String, ByVal RPInvAmt As Double, _
                                   ByVal RPPaidAmt As Double, ByVal RPOutstandingAmt As Double, ByVal RPNewAmt As Double, Optional ByVal PayMode As String = "CC") As String

        '--------------------------------------------------------------------------------------------------------
        Dim strXML As String = "<ShoppingCart>" & _
                             "<OrderInfo>" & _
                             "	<OrderID>" & OrderID & "</OrderID>" & _
                             "	<CustomerID>" & CustomerID & "</CustomerID>" & _
                             "	<MerchantID>2</MerchantID>"
        If PayMode = "CC" Then
            Dim objDate As DateTime

            If CardExpiry <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(CardExpiry, DateTime)
                CardExpiry = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            If StartDate <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(StartDate, DateTime)
                StartDate = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            If EndDate <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(EndDate, DateTime)
                EndDate = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            '-------------------------------------------------------------------------
            strXML = strXML & "	<CardType>" & CardType & "</CardType>" & _
                         "	<CardNumber>" & CardNo & "</CardNumber>" & _
                         "	<CardName>" & CardName & "</CardName>" & _
                         "	<CardAddress>" & CardAddress & "</CardAddress>" & _
                         "	<CardExpiry>" & CardExpiry & "</CardExpiry>" & _
                         "	<IssueNumber>" & IssueNumber & "</IssueNumber>" & _
                         "	<SecurityCode>" & SecurityCode & "</SecurityCode>" & _
                         "	<StartDate>" & StartDate & "</StartDate>" & _
                         "	<EndDate>" & EndDate & "</EndDate>" & _
                         "	<BankName></BankName>" & _
                         "	<BankChequeNo></BankChequeNo>" & _
                         "	<BankSortCode></BankSortCode>" & _
                         "	<BankReferenceNumber></BankReferenceNumber>"
            '-------------------------------------------------------------------------
        Else
            '-------------------------------------------------------------------------
            strXML = strXML & "	<CardType></CardType>" & _
                         "	<CardNumber></CardNumber>" & _
                         "	<CardName></CardName>" & _
                         "	<CardAddress></CardAddress>" & _
                         "	<CardExpiry></CardExpiry>" & _
                         "	<IssueNumber></IssueNumber>" & _
                         "	<SecurityCode></SecurityCode>" & _
                         "	<StartDate></StartDate>" & _
                         "	<EndDate></EndDate>" & _
                         "	<BankName> " & BankName & "</BankName>" & _
                         "	<BankChequeNo>" & BankChqNo & "</BankChequeNo>" & _
                         "	<BankSortCode>" & BankSortCode & "</BankSortCode>" & _
                         "	<BankReferenceNumber>" & BankRefNo & "</BankReferenceNumber>"
            '-------------------------------------------------------------------------
        End If

        '----------------------------------------------------------------------------------------
        strXML = strXML & "	<RPInvoiceAmount>" & RPInvAmt & "</RPInvoiceAmount>" & _
                     "	<RPPaidAmount>" & RPPaidAmt & "</RPPaidAmount>" & _
                     "	<RPOutstandingAmount>" & RPOutstandingAmt & "</RPOutstandingAmount>" & _
                     "	<RPNewAmount>" & RPNewAmt & "</RPNewAmount>" & _
                     "</OrderInfo>" & _
                    "</ShoppingCart>"
        '----------------------------------------------------------------------------------------


        ReturnValue = "Repayment XML : " & strXML
        '--------------------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------
        Dim o As New com.webservices.ishops.WebService

        Dim key As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        Dim userid As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        Dim pwd As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        Dim domain As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        Dim res As String = o.Order_Repayment(strXML)

        o.Dispose()
        o = Nothing
        '--------------------------------------------------------------------------------------------------------
        Return res
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Calculate the Accounts Centre order amount and also
    '''  return outstanding amount through optional refrense parameter
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="SumCartOrderAmount"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	03/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CalculateAccProdAmount(ByVal CustomerID As String, ByVal OrderID As Integer, Optional ByRef SumCartOrderAmount As Double = 0D) As Double
        '---------------------------------------------
        Dim sqlDrOrder As SqlDataReader
        Dim result As Double = 0
        Dim PreviousPaidAmount, DiscountAmount, _
            CarriageNet, CarriageTaxRate, _
            SumCarriageCharges As Double
        Dim objCXLOrder As New CXLOrderProcessing
        Dim isFirstRecord As Boolean = True
        '---------------------------------------------

        Try
            '-----------------------------------------------------------
            sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, OrderID)
            '-----------------------------------------------------------

            While sqlDrOrder.Read

                If isFirstRecord Then
                    '-------------------------------------------------------------------------
                    ' CALCULATION THE SUM OF CART AMOUNT 
                    PreviousPaidAmount = Val(sqlDrOrder.Item("pay_amt") & "")
                    DiscountAmount = Val(sqlDrOrder.Item("discount") & "")

                    'CALCULATE THE TOTAL SHIPMENT CHARGES
                    CarriageNet = Val(sqlDrOrder.Item("Carriage") & "")
                    CarriageTaxRate = Val(sqlDrOrder.Item("car_tax_rate") & "")
                    SumCarriageCharges = CarriageNet + ((CarriageNet * CarriageTaxRate) / 100)

                    isFirstRecord = False
                    '-------------------------------------------------------------------------
                End If

                '----------------------------------------------------------------------------------------------------------
                result += CDbl(sqlDrOrder("ProdAmount")) ' + CDbl(sqlDrOrder("ProdAmount")) * CDbl(sqlDrOrder("Tax")) / 100)
                '----------------------------------------------------------------------------------------------------------
            End While

            '---------------------------------------------------------------------------------------
            SumCartOrderAmount = (result + SumCarriageCharges) - DiscountAmount - PreviousPaidAmount
            '---------------------------------------------------------------------------------------

        Catch ex As Exception
        Finally
            '---------------------------------
            If Not sqlDrOrder.IsClosed Then
                sqlDrOrder.Close()
            End If
            '---------------------------------
        End Try

        Return result
    End Function
#End Region

#Region "<<< <<< <<< <<< <<< Encryption/Decryption procedure >>> >>> >>> >>> >>>"

    Private Function EncryptString128Bit(ByVal vstrTextToBeEncrypted As String, _
                                    ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ******  Strip any null character from string to be encrypted    ******
        '   **********************************************************************

        vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged

        '   ***********************************************************************
        '   ******  Create the encryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
              objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
              CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch



        End Try

        '   ***********************************************************************
        '   ******   Return encryptes value (converted from  byte Array to   ******
        '   ******   a base64 string).  Base64 is MIME encoding)             ******
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    Private Function DecryptString128Bit(ByVal vstrStringToBeDecrypted As String, _
                                        ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim intCtr As Integer
        Dim strReturnString As String = String.Empty
        Dim achrCharacterArray() As Char
        Dim intIndex As Integer

        '   *****************************************************************
        '   ******   Convert base64 encrypted value to byte array      ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Create the decryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   *****************************************
        '   ******   Return decypted value     ******
        '   *****************************************

        Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

    End Function

    Private Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

#End Region

End Class

#End Region