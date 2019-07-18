#Region ":::::::::::::::: Imports Liabraries ::::::::::::::::"

Imports System.Data
Imports System.Data.SqlClient
Imports Infinilogic.CreditCardValidation
Imports Microsoft.Toolkits.EnterpriseLocalization
Imports System.Threading
Imports System.Globalization
#End Region


''' -----------------------------------------------------------------------------
''' Project	 : www.accountscentre.com
''' Class	 : AccountsCentre.Web.ServiceOrder
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.abid]	31/01/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ServiceOrder
    Inherits System.Web.UI.UserControl

#Region ":::::::::::::::: Declaration ::::::::::::::::"

#Region "++++++++++++++++ Public Evnets ++++++++++++++++"

    Public Event ProcessOrder()
    Public Event ServiceNext()

#End Region

#Region "++++++++++++++++ Private Members ++++++++++++++++"

    Private ePageName As OrderPageName
    Private bRetry As Boolean = False
    'Private htCheckBoxNames As New Hashtable
    Protected productJavaScript, defaultSelectionScript As String
    Protected checkBoxJavaScript As String = "<script>  var checkBoxNames=new Array(), checkBoxValues=new Array(); </script> "
    Dim index As Integer

#End Region

#Region "++++++++++++++++ Controls ++++++++++++++++"

    Protected WithEvents btnServiceNext As System.Web.UI.WebControls.Button
    Protected WithEvents trOrderToal As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblRetry As System.Web.UI.WebControls.Label
    Protected WithEvents lblCustomerID As System.Web.UI.WebControls.Label
    Protected WithEvents tdOrderAmount As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlPaymentOptions As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMethod As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents txtDeliveryAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnPaymentMethod As System.Web.UI.WebControls.Button
    Protected WithEvents txtBankName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtChequeNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSortCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTransactionRefNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnBankTransfer As System.Web.UI.WebControls.Button
    Protected WithEvents pnlBankTransfer As System.Web.UI.WebControls.Panel
    Protected WithEvents txtCardHolderName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCardNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCardAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSecurityCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnCrCardInfo As System.Web.UI.WebControls.Button
    Protected WithEvents pnlCrCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblCardName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode As System.Web.UI.WebControls.Label
    Protected WithEvents txtIssueNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnAmexInfo As System.Web.UI.WebControls.Button
    Protected WithEvents tdCardHeading As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trStartDate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdStartDate As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trIssueNumber As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents pnlCards As System.Web.UI.WebControls.Panel
    Protected WithEvents cmbCardNames As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbExpiryMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbExpiryYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbStartMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cmbStartYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents pnlInfomration As System.Web.UI.WebControls.Panel
    Protected WithEvents tdInformation As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlGrid As System.Web.UI.WebControls.Panel
    Protected WithEvents trPackagesPlanHeading As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPackagesPlanGrid As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents grdPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents trProductsHeading As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trProductsGrid As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents grdPurchasedPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdPurchasedProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents tcExp As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tcAbtExp As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trRenewPackagesHeading As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trRenewProductsHeading As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trRenewPackagesGrid As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trRenewProductsGrid As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trLegends As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents dgrdOrder As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnRetry As System.Web.UI.WebControls.Button
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents lblOrderNo As System.Web.UI.WebControls.Label
#End Region

#Region "Localization Toolkit Varibales"
    Protected rs As ElementResourceSet
    Protected _culture As CultureInfo
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
    Protected WithEvents Td10 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td11 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td12 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trDiscount As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdDiscount As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblpostback_check As System.Web.UI.WebControls.Label
#End Region
#End Region

#Region ":::::::::::::::: Web Form Designer Generated Code ::::::::::::::::"

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region ":::::::::::::::: Properties ::::::::::::::::"

    Public Property IsRetry() As Boolean
        Get
            Return IIf(lblRetry.Text <> "", True, False)
        End Get
        Set(ByVal VALUE As Boolean)
            lblRetry.Text = IIf(VALUE, "OK", "")
        End Set

    End Property

    Public ReadOnly Property IsCreditCard() As Boolean
        Get
            Return IIf(rbtPaymentMethod.SelectedValue = "Credit Card", True, False)
        End Get
    End Property

    Public ReadOnly Property IsAmexOrSwitchCard() As Boolean
        Get
            Return IIf(CreditCard = "AMEX Card" OrElse CreditCard = "Switch Card", True, False)
        End Get
    End Property

    Public ReadOnly Property IsDebitCard() As Boolean
        Get
            Return IIf(CreditCard = "Debit Card", True, False)
        End Get
    End Property

    Public ReadOnly Property DeliveryAddress() As String
        Get
            Return txtDeliveryAddress.Text
        End Get
    End Property

    Public ReadOnly Property BankName() As String
        Get
            Return txtBankName.Text
        End Get
    End Property

    Public ReadOnly Property ChequeNumber() As String
        Get
            Return txtChequeNo.Text
        End Get
    End Property

    Public ReadOnly Property SortCode() As String
        Get
            Return txtSortCode.Text
        End Get
    End Property

    Public ReadOnly Property TransactionRefNo() As String
        Get
            Return txtTransactionRefNo.Text
        End Get
    End Property

    Public ReadOnly Property CreditCard() As String
        Get
            Return cmbCardNames.SelectedValue
        End Get
    End Property

    Public ReadOnly Property CardHolderName() As String
        Get
            Return txtCardHolderName.Text
        End Get
    End Property

    Public ReadOnly Property CardNumber() As String
        Get
            Return txtCardNumber.Text
        End Get
    End Property

    Public ReadOnly Property CardExpiryDate() As String
        Get
            Dim dateCardExpires As Date = DateSerial(cmbExpiryYear.SelectedValue, cmbExpiryMonth.SelectedValue + 1, 0)

            Return (dateCardExpires.Month & "/" & dateCardExpires.Day & "/" & dateCardExpires.Year)
        End Get
    End Property

    Public ReadOnly Property CardAddress() As String
        Get
            Return txtCardAddress.Text
        End Get
    End Property

    Public ReadOnly Property SecurityCode() As String
        Get
            Return txtSecurityCode.Text
        End Get
    End Property

    Public ReadOnly Property CardStartDate() As String
        Get
            Dim dateCardStart As Date = DateSerial(cmbStartYear.SelectedValue, cmbStartMonth.SelectedValue + 1, 0)

            Return (dateCardStart.Month & "/" & dateCardStart.Day & "/" & dateCardStart.Year)

        End Get
    End Property

    Public ReadOnly Property IssueNumber() As String
        Get
            Return txtIssueNumber.Text
        End Get
    End Property

    Public Property OrderNumber() As Integer
        Get
            Return IIf(lblOrderNo.Text <> "", CInt(lblOrderNo.Text), -1)
        End Get
        Set(ByVal Value As Integer)
            lblOrderNo.Text = Value
        End Set
    End Property

    Public Property CustomerID() As Integer
        Get
            If Page.User.Identity.IsAuthenticated Then
                Return Int32.Parse(Page.User.Identity.Name)
            Else
                Return CInt(lblCustomerID.Text)
            End If
            'If ePageName.NewCustomer OrElse ePageName.ServiceRegistration Then
            '    Return CInt(lblCustomerID.Text)
            'Else
            '    Return Int32.Parse(Page.User.Identity.Name)
            'End If

        End Get
        Set(ByVal Value As Integer)
            lblCustomerID.Text = Value
        End Set
    End Property

    Public ReadOnly Property OrderAmount() As Double
        Get
            Select Case ePageName
                Case OrderPageName.NewCustomer, OrderPageName.UpdateServices, OrderPageName.ServiceRegistration
                    '------------------------------
                    Dim dblOrderAmt As Double
                    ProdcutPackageXML(dblOrderAmt)
                    Return dblOrderAmt
                    '-----------------------------
                Case OrderPageName.UpdatePayment
                    Return -1
                Case Else
                    Return -1
            End Select
        End Get
    End Property

    Public ReadOnly Property PackagesGrid() As DataGrid
        Get
            Return grdPackages
        End Get
    End Property

    Public ReadOnly Property ProductsGrid() As DataGrid
        Get
            Return grdProducts
        End Get
    End Property

    Public ReadOnly Property PurchasedPackagesGrid() As DataGrid
        Get
            Return grdPurchasedPackages
        End Get
    End Property

    Public ReadOnly Property PurchasedProductsGrid() As DataGrid
        Get
            Return grdPurchasedProducts
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''     PageName property
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	31/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    '''     Public Property PageName() As String
    Public Property PageName() As String
        Get
            Select Case Me.ePageName
                Case OrderPageName.NewCustomer
                    Return "New Customer"
                Case OrderPageName.UpdatePayment
                    Return "Update Payment"
                Case OrderPageName.UpdateServices
                    Return "Update Services"
                Case OrderPageName.ServiceRegistration
                    Return "Service Registarion"
                Case Else
                    Return ""
            End Select

        End Get
        Set(ByVal Value As String)
            Select Case Value
                Case "New Customer"
                    ePageName = OrderPageName.NewCustomer
                Case "Update Payment"
                    ePageName = OrderPageName.UpdatePayment
                Case "Update Services"
                    ePageName = OrderPageName.UpdateServices
                Case "Service Registarion"
                    ePageName = OrderPageName.ServiceRegistration
                Case Else
                    ePageName = OrderPageName.None
            End Select
        End Set
    End Property
#End Region

#Region ":::::::::::::::: Event Handlers ::::::::::::::::"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        ShowMessage("", False)
        index = 0

        If Not IsPostBack Then

            '-----------------
            FillMonths()
            FillYears()
            LoadGrids()
            trOrderToal.Visible = False
            trDiscount.Visible = False

            ' productJavaScript = CXLProcessing.GetProuctsDependencies()

            '-----------------
            _culture = Session("SelectedCulture")
            lblpostback_check.Text = _culture.Name
            'Else
            '    productJavaScript = CXLProcessing.GetProuctsDependencies()
        End If

        productJavaScript = CXLProcessing.GetProuctsDependencies()

        If pnlGrid.Visible = True Then
            _culture = Session("SelectedCulture")
            If lblpostback_check.Text <> _culture.Name Then
                LoadGrids()
                lblpostback_check.Text = _culture.Name
            End If
        End If

    End Sub

    Private Sub btnPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentMethod.Click
        If VerifyPaymentMethodPanel() = True Then

            If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then

                ' Set Visible CrCardInfo Panel
                ShowControls(False, False, False, True, False)
                SetFocus(cmbCardNames)

            Else
                ' Set Visible BankTransfer Panel
                ShowControls(False, False, True, False, False)
                SetFocus(txtBankName)

            End If
        Else
            LoadGrids()
        End If
    End Sub

    Private Sub btnBankTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankTransfer.Click
        If VerifyBankTransactionPanel() = True Then
            RaiseEvent ProcessOrder()
        End If
    End Sub

    Private Sub btnCrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrCardInfo.Click
        If VerifyCreditCardPanel() = True Then

            Select Case cmbCardNames.SelectedItem.Text
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
                    RaiseEvent ProcessOrder()
            End Select
        End If
    End Sub

    Private Sub btnAmexInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmexInfo.Click
        Dim dteStartDate, dteEndDate As Date
        Dim strMsg As String

        dteStartDate = DateSerial(cmbStartYear.SelectedValue, cmbStartMonth.SelectedValue + 1, 0)
        dteEndDate = DateSerial(cmbExpiryYear.SelectedValue, cmbExpiryMonth.SelectedValue + 1, 0)

        Select Case cmbCardNames.SelectedValue
            Case "AMEX Card"
                'Updated by Muhammad Ubaid
                'Resion: to remove the check from start date.
                ''If dteStartDate < Now Then
                ''    strMsg = common.ACCMessage.Account_AXCardSTDate
                ''ElseIf dteStartDate > dteEndDate Then
                If dteStartDate > dteEndDate Then
                    strMsg = common.ACCMessage.Account_AXCardSTDate & " 'Start date' can't be greater than 'Expiry date'."
                End If
                Exit Select
            Case "Switch Card"
                ''If dteStartDate < Now Then
                ''    strMsg = "Please enter a valid 'Valid From' date."
                ''ElseIf dteStartDate > dteEndDate Then
                If dteStartDate > dteEndDate Then
                    strMsg = common.ACCMessage.Account_AXCardSTDate & " 'Valid From' date can't be greater than 'Expiry date'."
                End If
                Exit Select
            Case Else
                If VerifyDebitCardPanel() Then
                    RaiseEvent ProcessOrder()
                End If
                Exit Sub
        End Select

        If strMsg = "" Then
            ' None of the control voilates business rules
            RaiseEvent ProcessOrder()
        Else
            ' When form controls voilate the business rules
            'pnlInformation.Visible = True
            strMsg = "Please enter valid data in the following field(s):" & "<Br><Br><li>" & Replace(strMsg, ",", "<li>")
            'ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strMsg

            ShowError(strMsg, True)

        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Dim myPage As BLL.PageBase = CType(Page, BLL.PageBase)
        myPage.RedirectTo(BLL.ACC_Redirection.HOMEPAGE)
    End Sub

    Private Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        lblRetry.Text = "ok"
        btnRetry.Visible = False
        btnFinish.Visible = False

        Dim objCXL As CXLProcessing

        'lblOrderNo.Text = objCXL.GetLastOrderNo(CustomerID)
        LoadUpdatePayment()
    End Sub

    Private Sub grdPurchasedProducts_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPurchasedProducts.ItemDataBound
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

    Private Sub grdPurchasedPackages_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPurchasedPackages.ItemDataBound
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

    Private Sub grdPackages_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPackages.ItemDataBound
        SetCheckBoxes(e)
    End Sub

    Private Sub grdProducts_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProducts.ItemDataBound
        SetCheckBoxes(e)
    End Sub

    Private Sub btnServiceNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnServiceNext.Click

        If Not VerifySelectedProducts() Then Exit Sub

        ShowControls(False, False, False, False, False)

        'Else
        btnServiceNext.Visible = False
        dgrdOrder.Visible = False
        trOrderToal.Visible = False
        RaiseEvent ServiceNext()
        ' End If


    End Sub

#End Region

#Region ":::::::::::::::: Public Helper Functions/Procedures ::::::::::::::::"

    Public Sub ShowError(ByVal ErrorMsg As String, ByVal IsVisible As Boolean)
        Dim str As String = ""

        If pnlInfomration.Visible Then
            str = "<br>" & tdInformation.InnerHtml
        End If

        pnlInfomration.Visible = IsVisible
        tdInformation.InnerHtml = "<bR><font color=Red>" & ErrorMsg & "</font>" & str
    End Sub

    Public Sub ShowMessage(ByVal ErrorMsg As String, ByVal IsVisible As Boolean)
        Dim str As String = ""

        If pnlInfomration.Visible Then
            str = tdInformation.InnerHtml & "<br>"
        End If

        pnlInfomration.Visible = IsVisible
        tdInformation.InnerHtml = str & "<br>" & ErrorMsg & ""
    End Sub

    Public Sub SetCheckBoxes(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Dim myPage As BLL.PageBase = CType(Page, BLL.PageBase)

        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item
                Dim chkBox As CheckBox
                chkBox = CType(e.Item.Cells(0).Controls(1), CheckBox)
                ' htCheckBoxNames.Add(e.Item.DataItem("ProductCode"), chkBox.UniqueID)
                checkBoxJavaScript &= vbNewLine & "<script>  checkBoxNames[" & index & "]='" & chkBox.UniqueID & "'; checkBoxValues[" & index & "]='" & e.Item.DataItem("ProductCode") & "';  </script> "
                index += 1
                chkBox.Attributes.Add("onClick", "Checking('" & chkBox.UniqueID & "','" & e.Item.DataItem("ProductCode") & "');")

                If Session(myPage.ACC_ORDER_HERE_LINK) <> "" AndAlso Session(myPage.ACC_ORDER_HERE_LINK) = e.Item.DataItem("ProductCode") Then
                    chkBox.Checked = True
                    chkBox.Enabled = False
                    defaultSelectionScript = "<script>Checking('" & chkBox.UniqueID & "','" & e.Item.DataItem("ProductCode") & "');</script> "

                    'These lines are modified by Yousuf
                    'ElseIf Session("expired_products") <> "" Then
                ElseIf Session(myPage.ACC_ORDER_HERE_LINK) <> "" Then
                    Dim renewAll As String = Session("renewAll")
                    If renewAll Is Nothing Then renewAll = ""
                    If renewAll.ToLower().Equals("true") Then
                        'Dim temp As String = Session("expired_products")
                        Dim temp As String = Session(myPage.ACC_ORDER_HERE_LINK)
                        If (Not temp Is Nothing) Then
                            Dim split_char(0) As Char
                            split_char(0) = "^"
                            Dim expired_products() As String = temp.Split(split_char)

                            For Each expired_product As String In expired_products
                                If expired_product = e.Item.DataItem("ProductCode") Then
                                    chkBox.Checked = True
                                    chkBox.Enabled = False
                                End If
                            Next
                            defaultSelectionScript = defaultSelectionScript + "  <script>Checking('" & chkBox.UniqueID & "','" & e.Item.DataItem("ProductCode") & "');</script> "

                        End If
                        'code editing complete
                    End If
                End If
        End Select
    End Sub

    Public Sub SetCheckBox(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Dim myPage As BLL.PageBase = CType(Page, BLL.PageBase)

        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item
                Dim chkBox As HtmlInputCheckBox
                chkBox = CType(e.Item.Cells(0).Controls(1), HtmlInputCheckBox)
                chkBox.Value = e.Item.DataItem("ProductCode")


                'If Session(myPage.ACC_ORDER_HERE_LINK) <> "" AndAlso Session(myPage.ACC_ORDER_HERE_LINK) = e.Item.DataItem("ProductCode") Then
                '    chkBox.Checked = True
                'End If
                myPage.SetOrderHereCheck(chkBox, e)
        End Select
    End Sub

    Public Sub ProceedServicesRegistration()
        ShowControls(False, True, False, False, False)
        Dim dblOrderAmount, dblDiscount As Double

        If Page.User.Identity.IsAuthenticated Then
            Dim strTemp As String = ""
            CheckOrder(strTemp)
        End If

        'If btnServiceNext.CommandName = "Service" Then
        Dim OrderAmt As Double = 0
        Dim dt As DataTable = InvoiceDetail(OrderAmt)

        If dt.Rows.Count > 0 Then
            dgrdOrder.DataSource = dt
            dgrdOrder.DataBind()

            dblOrderAmount = OrderAmt
            ' tdOrderAmount.InnerText = FormatAmount(OrderAmt)

            btnServiceNext.CommandName = "ServiceEnd"
            'Else
            '    ShowError("Please select atleast one product.", True)
            '    LoadNewCustomerGrids()
            '    Exit Sub
        End If

        'If tdOrderAmount.InnerText Is Nothing OrElse tdOrderAmount.InnerText.Trim = "" Then
        '    dblOrderAmount = 0
        '    dblDiscount = 0
        'Else
        '    dblOrderAmount = CDbl(tdOrderAmount.InnerText.Substring(2))
        'End If

        'dblDiscount = CDbl(viewstate.Item("OrderUpgradeAmount"))

        '  dblOrderAmount -= dblDiscount

        'tdDiscount.InnerText = FormatAmount(dblDiscount)
        tdOrderAmount.InnerText = FormatAmount(dblOrderAmount)

        dgrdOrder.Visible = True
        trOrderToal.Visible = True
        'trDiscount.Visible = True
    End Sub

    Public Sub OrderSucces(ByVal IsSuccess As Boolean)

        btnFinish.Visible = True
        btnRetry.Visible = Not IsSuccess
    End Sub

    Public Sub ControlsDiable()
        ShowControls(False, False, False, False, False)
        dgrdOrder.Visible = False
        trOrderToal.Visible = False
        trDiscount.Visible = False
    End Sub

    Public Function FormatAmount(ByVal AmountValue As Double) As String
        Dim strAmt() As String = Split(AmountValue.ToString, ".")
        Dim retStr As String = "£"

        If strAmt.Length = 1 Then
            retStr &= " " & AmountValue & ".00"
        ElseIf strAmt.Length = 2 Then
            If strAmt(1).Length = 1 Then
                strAmt(1) &= "0"
            Else
                strAmt(1) = strAmt(1).Chars(0) & strAmt(1).Chars(1)
            End If

            retStr &= " " & strAmt(0) & "." & strAmt(1)
        End If


        Return retStr

    End Function
#End Region

#Region ":::::::::::::::: Private Helper Functions/Procedures ::::::::::::::::"

    Private Sub LoadGrids()

        Select Case ePageName
            Case OrderPageName.NewCustomer, OrderPageName.ServiceRegistration
                '---------------------
                set_culture("LoadNewCustomerGrids")
                LoadNewCustomerGrids()
                Exit Sub
                '---------------------
            Case OrderPageName.UpdatePayment
                '-------------------
                set_culture("LoadUpdateServices")
                LoadUpdateServices()
                Exit Sub
                '-------------------
            Case OrderPageName.UpdateServices
                '-------------------
                'set_culture("LoadUpdatePayment")
                LoadUpdatePayment()
                Exit Sub
                '-------------------
            Case Else
                ShowControls(False, False, False, False, False)
        End Select
    End Sub

    Private Sub LoadNewCustomerGrids()

        ' If Not Page.IsPostBack Then

        '------------------------------------------------------
        Dim ds As New DataSet
        Dim bPackages, bProducts As Boolean
        Dim myPage As BLL.PageBase = CType(Page, BLL.PageBase)
        '------------------------------------------------------

        '----------------------------------
        ds = BLL.User.ACC_GetProductsToSale     'PackageOptions.EnableSale, ServiceOptions.EnableSale)
        '----------------------------------

        'If Not myPage.CheckOrderHereRow(ds) Then
        '    Dim errID As common.ACC_Error_Messages

        '    If Session(myPage.ACC_ORDER_HERE_LINK) <> "" Then
        '        errID = common.ACC_Error_Messages.ACC_Selected_Service_Already_Purchased
        '        myPage.RedirectToErrorPage(errID)
        '    End If

        'End If

        trLegends.Visible = False

        '-------------------------------------------------------------------------
        If ePageName = OrderPageName.NewCustomer Then myPage.CheckOrderHereRow(ds)
        '-------------------------------------------------------------------------

        '----------------------------------------
        grdPackages.DataSource = ds.Tables(0)
        grdPackages.DataBind()
        bPackages = ds.Tables(0).Rows.Count > 0
        grdPackages.Visible = bPackages
        'trPackagesPlanHeading.Visible = bPackages

        'These lines are modified by Yousuf

        Dim i, j As Int16
        Dim s As String
        Dim myArr() As String
        Dim ch(0) As Char
        For i = 0 To grdPackages.Items.Count - 1
            s = grdPackages.Items(i).Cells(2).Text
            If s.Trim() <> "" Then
                If s.Trim() <> "&nbsp;" Then
                    ch(0) = "'"
                    myArr = s.Split(ch)
                    s = ""
                    For j = 0 To myArr.Length - 1
                        s = s + myArr(j) + "'"
                    Next
                    s = s.Substring(0, s.Length - 2)
                    'grdPackages.Items(i).Cells(6).Text = "<a href='#_self1' onClick=""callme(' " + s + " ', '" + grdPackages.Items(i).Cells(1).Text + "');"" style='font-size:X-Small;'>Detail</a>"
                    grdPackages.Items(i).Cells(6).Text = "<a id='pack" & i & "hr' href='#_self1' onClick=""ShowHide('pack" & i & "');"" style='font-size:X-Small;'>[Show]</a><div style='font-size:X-Small;' id='pack" & i & "' style='Display:none'>" + s + "</div>"
                End If
            End If
        Next
        grdPackages.Items(1).Cells(6).ID = "packcell"
        'end of modification
        '----------------------------------------


        '---------------------------------------
        grdProducts.DataSource = ds.Tables(1)
        grdProducts.DataBind()
        bProducts = ds.Tables(1).Rows.Count > 0
        grdProducts.Visible = bProducts
        trProductsHeading.Visible = bProducts

        'These lines are modified by Yousuf
        'Dim i, j As Int16   'this i and j is declared in above Yousuf edited code
        'Dim s As String    'this s is declared in above Yousuf edited code
        'Dim myArr() As String  'this myArr() is declared in above Yousuf edited code
        'Dim ch(0) As Char      'this ch(0) is declared in above Yousuf edited code
        i = j = 0
        s = ""
        ch(0) = " "

        For i = 0 To grdProducts.Items.Count - 1
            s = grdProducts.Items(i).Cells(2).Text
            If s.Trim() <> "" Then
                If s.Trim() <> "&nbsp;" Then
                    ch(0) = "'"
                    myArr = s.Split(ch)
                    s = ""
                    For j = 0 To myArr.Length - 1
                        s = s + myArr(j) + "'"
                    Next
                    s = s.Substring(0, s.Length - 2)
                    Dim p_name As String

                    'grdProducts.Items(i).Cells(6).Text = "<a href='#_self1' onClick=""callme(' " + s + " ', '" + grdProducts.Items(i).Cells(1).Text + "');"" style='font-size:X-Small;'>Detail</a>"
                    grdProducts.Items(i).Cells(6).Text = "<a id='pro" & i & "hr' href='#_self1' onClick=""ShowHide('pro" & i & "');"" style='font-size:X-Small;'>[Show]</a><div style='font-size:X-Small;' id='pro" & i & "' style='Display:none'>" + s + "</div>"
                End If
            End If
        Next
        grdProducts.Items(1).Cells(6).ID = "procell"
        'end of modification
        '---------------------------------------

        '-------------------------------------
        trRenewPackagesGrid.Visible = False
        trRenewPackagesHeading.Visible = False
        trRenewProductsGrid.Visible = False
        trRenewProductsHeading.Visible = False
        trPackagesPlanHeading.Visible = False
        '-------------------------------------

        '--------------------------------------------------------------
        If ePageName = OrderPageName.NewCustomer Then
            ShowControls(bProducts Or bPackages, True, False, False, False)
        Else
            btnServiceNext.Visible = True
            ShowControls(bProducts Or bPackages, False, False, False, False)
        End If
        '--------------------------------------------------------------
        'End If
    End Sub

    Private Sub LoadUpdateServices()
        '-----------------------------------------------------------------------
        Dim ds, ds1 As DataSet
        Dim objuser As New BLL.User
        Dim myPage As BLL.PageBase = CType(Page, BLL.PageBase)
        Dim bPackagesPlan, bProducts, bRenewPackages, bRenewProducts As Boolean
        '-----------------------------------------------------------------------

        ' INSERT AMOUNT IN PRODUCT SELECTION OF REGISTRATION PROCESS
        '----------------------------------------------------------------------------------------
        ds = objuser.ACC_UpdatePackageProductDetails(CustomerID, BLL.PackageOptions.EnableSale, _
                                                     BLL.ServiceOptions.EnableSale)
        '----------------------------------------------------------------------------------------

        If Not myPage.CheckOrderHereRow(ds) Then
            '-------------------------------------
            Dim errID As common.ACC_Error_Messages

            If Session(myPage.ACC_ORDER_HERE_LINK) <> "" Then
                errID = common.ACC_Error_Messages.ACC_Selected_Service_Already_Purchased
                myPage.RedirectToErrorPage(errID)
            End If
            '-----------------------------------------------------------------------
        End If

        '------------------------------------------------
        grdPackages.DataSource = ds.Tables(0)
        grdPackages.DataBind()
        REM SR
        bPackagesPlan = ds.Tables(0).Rows.Count > 0
        'trPackagesPlanHeading.Visible = bPackagesPlan
        trPackagesPlanGrid.Visible = bPackagesPlan
        '------------------------------------------------


        '------------------------------------------------
        grdProducts.DataSource = ds.Tables(1)
        grdProducts.DataBind()
        REM SR
        bProducts = ds.Tables(1).Rows.Count > 0
        trProductsHeading.Visible = bProducts
        trProductsGrid.Visible = bProducts
        '------------------------------------------------

        '------------------------------------------------
        grdPurchasedPackages.DataSource = ds.Tables(2)
        grdPurchasedPackages.DataBind()
        bRenewPackages = ds.Tables(2).Rows.Count > 0
        trRenewPackagesGrid.Visible = bRenewPackages
        trRenewPackagesHeading.Visible = bRenewPackages
        '------------------------------------------------

        '------------------------------------------------
        grdPurchasedProducts.DataSource = ds.Tables(3)
        grdPurchasedProducts.DataBind()
        bRenewProducts = ds.Tables(3).Rows.Count > 0
        trRenewProductsGrid.Visible = bRenewProducts
        trRenewProductsHeading.Visible = bRenewProducts
        '------------------------------------------------

        Dim intIndex As Int16

        For intIndex = 0 To grdPackages.Items.Count - 1
            '-----------------------------------------------------------------
            If grdPackages.Items(intIndex).Cells(0).Controls(1).Visible Then

                '---------------------------------------------------------
                SetFocus(grdPackages.Items(intIndex).Cells(0).Controls(1))
                intIndex = -1
                Exit For
                '---------------------------------------------------------
            End If
            '-----------------------------------------------------------------
        Next

        If intIndex > 0 Then
            For intIndex = 0 To grdProducts.Items.Count - 1
                '-----------------------------------------------------------------------
                If grdProducts.Items(intIndex).Cells(0).Controls(1).Visible = True Then
                    '---------------------------------------------------------
                    SetFocus(grdProducts.Items(intIndex).Cells(0).Controls(1))
                    intIndex = -1
                    Exit For
                    '---------------------------------------------------------
                End If
                '-----------------------------------------------------------------------
            Next
        End If
        ' End If



    End Sub

    Private Sub LoadUpdatePayment()
        Dim dr As SqlDataReader
        Dim objCXLOrder As New BLL.CXLOrderProcessing
        Dim dblTotal As Double = 0

        Try
            '--------------------------------------------------------
            dr = objCXLOrder.AccGetOrderDetails(CustomerID, OrderNumber)
            dgrdOrder.DataSource = dr
            dgrdOrder.DataBind()

            dr.Close()
            dr = Nothing

            dr = objCXLOrder.AccGetOrderDetails(CustomerID, OrderNumber)
            With dr
                While .Read
                    dblTotal += CDbl(.Item("ProdAmount"))
                End While
            End With

            trOrderToal.Visible = True
            tdOrderAmount.InnerText = FormatAmount(dblTotal)
            '--------------------------------------------------------

            '---------------------------------------------
            dgrdOrder.Visible = True
            ShowControls(False, True, False, False, False)
            '---------------------------------------------

        Catch ex As Exception
            '----------------------------------------------
            ShowControls(False, False, False, False, False)
            '----------------------------------------------
        Finally
            dr.Close()
        End Try
    End Sub
    ' Localization 

    'Private Sub load_culture()
    '    If Not IsPostBack Then

    '        rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
    '      Else
    '        _culture = Session("SelectedCulture")
    '        rs = Settings.CurrentManager.GetResourceSet(_culture, True, True)
    '        End If

    'End Sub


    Private Sub set_culture(ByVal grid_name As String)
        Select Case grid_name

            Case "LoadNewCustomerGrids"
                Me.grdPackages.Columns(1).HeaderText = load_culturevalue("acc_ghpackagename")
                Me.grdPackages.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdPackages.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")

                Me.grdProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
                Me.grdProducts.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdProducts.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")

            Case "LoadUpdateServices"
                Me.grdPackages.Columns(1).HeaderText = load_culturevalue("acc_ghpackagename")
                Me.grdPackages.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdPackages.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")

                Me.grdProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
                Me.grdProducts.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdProducts.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")


                Me.grdPurchasedPackages.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
                Me.grdPurchasedPackages.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdPurchasedPackages.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")


                Me.grdPurchasedProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
                Me.grdPurchasedProducts.Columns(2).HeaderText = load_culturevalue("acc_ghcostyear")
                Me.grdPurchasedProducts.Columns(6).HeaderText = load_culturevalue("acc_ghdescription")

                'Case "LoadUpdatePayment"
        End Select
    End Sub

    Private Function load_culturevalue(ByVal header_name As String) As String
        rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
        Return rs.GetProperty(header_name, "System.Web.UI.WebControls.Label", "Text")
    End Function

    ' End of Localization


    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub ShowControls(ByVal IsGridPanel As Boolean, ByVal IsPaymentOptions As Boolean, ByVal IsBankTransfer As Boolean, ByVal IsCrCardInfo As Boolean, ByVal IsCards As Boolean)
        pnlGrid.Visible = IsGridPanel
        pnlPaymentOptions.Visible = IsPaymentOptions
        pnlBankTransfer.Visible = IsBankTransfer
        pnlCrCardInfo.Visible = IsCrCardInfo
        pnlCards.Visible = IsCards
    End Sub

    Private Sub EmptyTextFileds()
        txtDeliveryAddress.Text = ""
        txtBankName.Text = ""
        txtChequeNo.Text = ""
        txtSortCode.Text = ""
        txtTransactionRefNo.Text = ""
        txtCardHolderName.Text = ""
        txtCardNumber.Text = ""
        txtCardAddress.Text = ""
        txtSecurityCode.Text = ""
        txtIssueNumber.Text = ""

        lblCardName.Text = ""
        lblCardNumber.Text = ""
        lblExpiryDate.Text = ""
        lblCardAddress.Text = ""
        lblSecurityCode.Text = ""
    End Sub

    Private Sub FillMonths()
        Dim month As Integer

        For month = 1 To 12
            cmbStartMonth.Items.Add(New ListItem(month.ToString, month.ToString))
            cmbExpiryMonth.Items.Add(New ListItem(month.ToString, month.ToString))
        Next
    End Sub

    Private Sub FillYears()
        Dim x As Integer = 2000
        Dim y As Integer = x + 25

        For x = x To y
            cmbStartYear.Items.Add(New ListItem(x.ToString, x.ToString))
            cmbExpiryYear.Items.Add(New ListItem(x.ToString, x.ToString))
        Next
    End Sub

    Private Function VerifyPaymentMethodPanel() As Boolean

        VerifyPaymentMethodPanel = False ' Intentionally make it
        Dim objRegExp As New common.RegularExpressions   ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim rowCount As Integer = 0
        'Loop through each DataGridItem, and determine which CheckBox controls
        'have been selected.
        Dim GridItem As DataGridItem

        If ePageName = OrderPageName.NewCustomer OrElse ePageName = OrderPageName.UpdateServices Then

            For Each GridItem In grdPackages.Items
                '--------------------------------------------------------------------------
                Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
                If myCheckbox.Checked = True Then
                    rowCount += 1
                End If
                '--------------------------------------------------------------------------
            Next

            For Each GridItem In grdProducts.Items
                '--------------------------------------------------------------------------
                Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
                If myCheckbox.Checked = True Then
                    rowCount += 1
                End If
                '--------------------------------------------------------------------------
            Next

            If ePageName = OrderPageName.UpdateServices Then

                For Each GridItem In grdPurchasedPackages.Items
                    '--------------------------------------------------------------------------------------------
                    Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
                    If myCheckbox.Checked = True Then
                        rowCount += 1
                    End If
                    '--------------------------------------------------------------------------------------------
                Next

                For Each GridItem In grdPurchasedProducts.Items
                    '--------------------------------------------------------------------------------------------
                    Dim myCheckbox As HtmlInputCheckBox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)
                    If Not myCheckbox Is Nothing Then
                        If myCheckbox.Checked = True Then
                            rowCount += 1
                        End If
                    End If
                    '--------------------------------------------------------------------------------------------
                Next

            End If

            If rowCount < 1 Then
                '-----------------------------------------------
                strMsg = "Atleast one product must be selected."
                strReturnMessage = strMsg
                strMsg = rowCount
                '-----------------------------------------------
            Else
                '---------------------------------------------------------
                Dim objuser As New BLL.User
                Dim dr As System.Data.SqlClient.SqlDataReader

                dr = objuser.ACC_VerifySelectedPackages(ProdcutPackageXML)

                While dr.Read
                    strMsg = strMsg & " , " & dr.Item("ProductName")
                End While

                strReturnMessage = strMsg
                '---------------------------------------------------------
            End If
        End If



        '==========================================================='
        ' Regular Expression syntax:                                '
        ' --              ---              ----      -              '
        ' 00              000              0000      0              '
        ' Category ID     Expression ID    Length    Optional *     '

        '* If field is optional then, value will be 1.              '
        '==========================================================='

        If strMsg = "" Then
            ' Add the controls 
            objRegExp.Add("txtDeliveryAddress", "0203502551", "Delivery Address")

            ' Get the return message
            strReturnMessage = objRegExp.ScanPage(Page)
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
                ShowError("Please enter valid data in the following field(s):" & "<Br><Br><li>" & strReturnMessage, True)
            ElseIf strMsg = "0" Then
                ShowError(strReturnMessage & "<Br>", True)
            Else
                ShowError("Following Packages/Products have same Services. " & "<Br><Br>" & strReturnMessage, True)
            End If
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyCreditCardPanel() As Boolean

        VerifyCreditCardPanel = False ' Intentionally make it
        Dim objRegExp As New common.RegularExpressions   ' Object of InfinLogic library
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
        strReturnMessage = objRegExp.ScanPage(Page)

        dteCrCardExpires = DateSerial(cmbExpiryYear.SelectedValue, cmbExpiryMonth.SelectedValue + 1, 0)

        If dteCrCardExpires < Now() Then

            strMsg = common.ACCMessage.Account_CrCardExpiryDate

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
            Dim ccValidator As New CreditCardValidator(cmbCardNames.SelectedValue, txtCardNumber.Text, txtSecurityCode.Text.Trim)

            If Not ccValidator.Validate Then
                VerifyCreditCardPanel = False
                strReturnMessage &= ccValidator.ErrorMessage
                strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
                ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
            End If

            'Dim strCrCardError As String
            'Dim objCXL As New BLL.CXLOrderProcessing
            ''-------------------------------------------------------------------------------------------------------------------------------
            'If Not objCXL.VerifyCreditCardNumber(cmbCardNames.SelectedValue, txtCardNumber.Text, txtSecurityCode.Text, strCrCardError) Then
            '    VerifyCreditCardPanel = False
            '    strReturnMessage &= strCrCardError
            '    ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
            'End If
            ''-------------------------------------------------------------------------------------------------------------------------------
        Else
            ' When form controls voilate the business rules
            VerifyCreditCardPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyBankTransactionPanel() As Boolean

        VerifyBankTransactionPanel = False ' Intentionally make it
        Dim objRegExp As New common.RegularExpressions   ' Object of InfinLogic library
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
        strReturnMessage = objRegExp.ScanPage(Page)

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyBankTransactionPanel = True
        Else
            ' When form controls voilate the business rules
            VerifyBankTransactionPanel = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
        End If

        objRegExp = Nothing

    End Function

    Private Function VerifyDebitCardPanel() As Boolean

        VerifyDebitCardPanel = False ' Intentionally make it
        Dim objRegExp As New common.RegularExpressions   ' Object of InfinLogic library
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

        objRegExp.Add("txtIssueNumber", "0100100020", "Issue No.")

        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Page)


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
            ShowError("Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage, True)
        End If

        objRegExp = Nothing

    End Function

    Public Function ProdcutPackageXML(Optional ByRef dblOrderAmount As Double = 0, _
                                  Optional ByVal bolEmailText As Boolean = False) As String

        Dim strProductCodes As New System.Text.StringBuilder
        Dim ds As New DataSet

        If Not bolEmailText Then

            strProductCodes.Append("<ROOT>")

        End If

        If ePageName = OrderPageName.NewCustomer OrElse ePageName = OrderPageName.ServiceRegistration Then

            If bolEmailText Then

                ds = BLL.User.ACC_GetProductsToSale() '.ACC_PackageProductDetails(PackageOptions.EnableSale, ServiceOptions.EnableSale)
                PackageProductCodeIterations(strProductCodes, ds.Tables(0), grdPackages, dblOrderAmount, bolEmailText)

                PackageProductCodeIterations(strProductCodes, ds.Tables(1), grdProducts, dblOrderAmount, bolEmailText)

            Else
                PackageProductCodeIterations(strProductCodes, grdPackages.DataSource, grdPackages, dblOrderAmount, bolEmailText)

                PackageProductCodeIterations(strProductCodes, grdProducts.DataSource, grdProducts, dblOrderAmount, bolEmailText)

                strProductCodes.Append("</ROOT>")
            End If
        ElseIf ePageName = OrderPageName.UpdateServices Then

            Dim objUser As New BLL.User
            Dim mypage As BLL.PageBase = CType(Page, BLL.PageBase)

            If Session(mypage.ACC_ORDER_HERE_LINK) <> "" Then
                PackageProductCodeIterations(strProductCodes, grdPackages.DataSource, grdPackages, dblOrderAmount, bolEmailText)

                REM SR
                PackageProductCodeIterations(strProductCodes, grdProducts.DataSource, grdPurchasedPackages, dblOrderAmount, bolEmailText)
                REM SR

                PackageProductCodeIterations(strProductCodes, grdPurchasedPackages.DataSource, grdProducts, dblOrderAmount, bolEmailText)

                REM SR
                PackageProductCodeIterations(strProductCodes, grdPurchasedProducts.DataSource, grdPurchasedProducts, dblOrderAmount, bolEmailText)


            Else
                ds = objUser.ACC_UpdatePackageProductDetails(CustomerID, BLL.PackageOptions.EnableSale, _
                                                                          BLL.ServiceOptions.EnableSale)

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
        Dim strProdCode As String
        Dim ht As Hashtable = CType(viewstate.Item("HashTableUpgradeList"), Hashtable)

        For Each GridItem In Grid.Items
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked Then
                If bolEmailText Then
                    strProductCodes.Append(dt.Rows(rowCount).Item("ProductName") & vbCrLf)
                Else
                    strProductCodes.Append("<Product Code=""")
                    strProdCode = GridItem.Cells(4).Text.ToString
                    strProductCodes.Append(strProdCode)
                    strProductCodes.Append("""/>")
                    '------------------------------------------------------------------
                    Dim dblProdAmount = CDbl(Mid(GridItem.Cells(3).Text, 2))
                    Dim dblProdTax = CDbl(GridItem.Cells(5).Text)

                    If Not ht Is Nothing AndAlso ht.Contains(strProdCode) Then
                        dblProdAmount -= CDbl(ht(strProdCode))
                    End If


                    dblOrderAmount += dblProdAmount + dblProdAmount * dblProdTax / 100
                    '-------------------------------------------------------------------
                End If
            End If
            rowCount += 1
        Next

    End Sub

    Private Sub SetCardHeadings(ByVal CardType As Integer)
        ShowControls(False, False, False, False, True)

        lblCardName.Text = txtCardHolderName.Text
        lblCardNumber.Text = txtCardNumber.Text

        lblExpiryDate.Text = CardExpiryDate

        lblCardAddress.Text = txtCardAddress.Text
        lblSecurityCode.Text = txtSecurityCode.Text

        Select Case CardType
            Case 1
                tdCardHeading.InnerText = "AMEX Card Information"
                trStartDate.Visible = True
                trIssueNumber.Visible = False
                tdStartDate.InnerText = "Start Date (mm / yyyy)"
                SetFocus(cmbStartMonth)
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
                SetFocus(cmbStartMonth)
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub

    Private Function InvoiceDetail(ByRef OrderAmnt As Double) As DataTable

        Dim dtInvoice As New DataTable("InvoiceList")

        With dtInvoice.Columns
            .Add("ProductName")
            .Add("Quantaty")
            .Add("UnitPrice")
            .Add("ProdAmount")
        End With

        FillInvoiceTable(grdPackages, dtInvoice, OrderAmnt)
        FillInvoiceTable(grdProducts, dtInvoice, OrderAmnt)


        Return dtInvoice

    End Function

    Private Sub FillInvoiceTable(ByVal Grid As DataGrid, ByRef InvoiceTable As DataTable, ByRef OrderAmt As Double)
        Dim drRow As DataRow
        Dim rowCount As Integer = 0
        'Loop through each DataGridItem, and determine which CheckBox controls
        'have been selected.
        Dim GridItem As DataGridItem
        Dim ht As Hashtable = CType(viewstate.Item("HashTableUpgradeList"), Hashtable)

        For Each GridItem In Grid.Items
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked Then

                drRow = InvoiceTable.NewRow

                '------------------------------------------------------------------
                Dim dblProdAmount As Double = CDbl(Mid(GridItem.Cells(3).Text, 2))
                Dim dblProdTax As Double = CDbl(GridItem.Cells(5).Text)
                Dim strProdCode As String = GridItem.Cells(4).Text

                If Not ht Is Nothing AndAlso ht.Contains(strProdCode) Then
                    dblProdAmount -= CDbl(ht(strProdCode))
                End If
                '-------------------------------------------------------------------

                With drRow
                    .Item("ProductName") = GridItem.Cells(1).Text
                    .Item("Quantaty") = "1"
                    .Item("UnitPrice") = dblProdAmount.ToString
                    .Item("ProdAmount") = (dblProdAmount + dblProdAmount * dblProdTax / 100).ToString
                End With

                InvoiceTable.Rows.Add(drRow)

                OrderAmt += (dblProdAmount + dblProdAmount * dblProdTax / 100)

            End If
        Next

    End Sub

    Private Function VerifySelectedProducts() As Boolean

        VerifySelectedProducts = False ' Intentionally make it
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String = String.Empty
        Dim rowCount As Integer = 0
        'Loop through each DataGridItem, and determine which CheckBox controls
        'have been selected.
        Dim GridItem As DataGridItem



        For Each GridItem In grdPackages.Items
            '--------------------------------------------------------------------------
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
            '--------------------------------------------------------------------------
        Next

        For Each GridItem In grdProducts.Items
            '--------------------------------------------------------------------------
            Dim myCheckbox As CheckBox = CType(GridItem.Cells(0).Controls(1), CheckBox)
            If myCheckbox.Checked = True Then
                rowCount += 1
            End If
            '--------------------------------------------------------------------------
        Next


        If rowCount < 1 Then
            '-----------------------------------------------
            strMsg = "Atleast one product must be selected."
            strReturnMessage = strMsg
            strMsg = rowCount
            '-----------------------------------------------
        Else
            '---------------------------------------------------------
            Dim objuser As New BLL.User
            Dim dr As System.Data.SqlClient.SqlDataReader

            dr = objuser.ACC_VerifySelectedPackages(ProdcutPackageXML)

            While dr.Read
                strMsg = strMsg & " , " & dr.Item("ProductName")
            End While

            strReturnMessage = strMsg
            '---------------------------------------------------------
        End If


        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifySelectedProducts = True
        Else
            ' When form controls voilate the business rules
            VerifySelectedProducts = False
            strReturnMessage = Replace(strReturnMessage, ",", "<li>")
            If strMsg = "0" Then
                ShowError(strReturnMessage & "<Br>", True)
            Else
                ShowError("Following Packages/Products have same Services. " & "<Br><Br>" & strReturnMessage, True)
            End If
        End If

    End Function
    Public Function CheckOrder(ByRef RenewProducts As String) As Boolean
        Dim result As Boolean = True
        Dim ds As DataSet
        Dim strProduct As String
        Dim htPurchasedProduct As New Hashtable
        Dim objUser As New BLL.User

        Dim hTable As Hashtable = GetProducts(PackagesGrid, ProductsGrid)

        ds = objUser.ACC_UpdatePackageProductDetails(CustomerID, BLL.PackageOptions.EnableSale, _
                                                    BLL.ServiceOptions.EnableSale)



        If hTable.Count > 0 Then
            Dim index As Integer
            'RenewProducts = "Renewable Package(s)/Product(s).<bR><br><ui>"

            For index = 2 To 3
                With ds.Tables(index)
                    For Each dtRow As DataRow In .Rows
                        strProduct = dtRow.Item("ProductCode")
                        htPurchasedProduct.Add(strProduct, dtRow.Item("ProductName") & "#" & dtRow.Item("Status"))

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
        Dim index As Integer, upgradeAmount As Double, dtTable As DataTable
        Dim dv As DataView, strProdValues() As String
        Dim isAnyRenew, isAnyUpgrade As Boolean, objCXL As New CXLProcessing
        Dim htUpgradeList As New Hashtable

        upgradeAmount = 0
        renewProducts = "Renewable Package(s)/Product(s).<bR><br><ui>"
        upgradeProducts = "Upgraded Package(s)/Product(s).<bR><br><ui>"

        dtTable = objCXL.GetProductUpgrade()

        For Each obj As Object In htProduct.Keys
            strProduct = CStr(obj).Trim

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

                    If strProduct = CStr(dr("ProductCode")).Trim Then
                        If htPurchased.Contains(dr("ParentProdCode")) Then
                            strProdValues = Split(htPurchased(dr("ParentProdCode")), "#")
                            If strProdValues(1) <> 2 Then
                                upgradeProducts &= "," & dr("ProductName")
                                upgradeAmount += dr("ParentSalePrice")
                                htUpgradeList.Add(strProduct, dr("ParentSalePrice"))
                                isAnyUpgrade = True
                            Else
                                renewProducts &= "," & strProduct
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
                    hTable.Add(dgItem.Cells(4).Text.Trim, dgItem.Cells(4).Text.Trim)
                End If
            Next
        Next

        Return hTable

    End Function
#End Region

End Class

#Region ":::::::::::::::: Enum OrderPageName ::::::::::::::::"

Public Enum OrderPageName As Integer
    None = 0
    NewCustomer = 1
    UpdateServices = 2
    UpdatePayment = 3
    ServiceRegistration = 4
End Enum

#End Region

