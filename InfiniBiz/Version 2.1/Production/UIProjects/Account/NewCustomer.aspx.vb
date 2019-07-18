#Region ":::::::::::::::: Imports Libraries ::::::::::::::::"

Imports System.Collections.Specialized
Imports InfiniLogic.AccountsCentre
Imports Infinilogic.AccountsCentre.BLL
Imports System.Web.Mail
Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports System.IO
Imports System.Xml
Imports Infinilogic.CreditCardValidation
'Imports System.Text
#End Region

Public Class NewCustomer
    Inherits PageTemplate

#Region ":::::::::::::::: Controls and Fields used in page. ::::::::::::::::"

#Region "**************** Controls ****************"

    Protected WithEvents pnlCustomerForm1 As System.Web.UI.WebControls.Panel
    Protected WithEvents rbtPaymentMode As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCustomerDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCustomerRegistration As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlPaymentMethod As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlCrCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlAmexCardInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents lblStreet As System.Web.UI.WebControls.Label
    Protected WithEvents lblTown As System.Web.UI.WebControls.Label
    Protected WithEvents lblState As System.Web.UI.WebControls.Label
    Protected WithEvents lblPostCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
    Protected WithEvents lblContactName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPh As System.Web.UI.WebControls.Label
    Protected WithEvents lblFax As System.Web.UI.WebControls.Label
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
    Protected WithEvents lblCardName As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblExpiryDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCardAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblSecurityCode As System.Web.UI.WebControls.Label
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
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents lblErrorInfoMsg As System.Web.UI.WebControls.Label
    Protected WithEvents txtInvoiceName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblInvoiceName As System.Web.UI.WebControls.Label
    Protected WithEvents btnRetry As System.Web.UI.WebControls.Button
    Protected idxTopBar As IndexHeader

#End Region

#Region "**************** Fields ****************"
    '     Message that will display on customer creation.
    Public NewCustomerCreated As String = String.Empty
    Dim objTemplate As New Infinilogic.AccountsCentre.BLL.TemplateReader

    Protected productJavaScript, defaultSelectionScript As String
    Protected checkBoxJavaScript As String = "<script>  var checkBoxNames=new Array(), checkBoxValues=new Array(); </script> "
    Dim index As Integer

    Const ACC_ISFORMCOMPLETED As String = "ACC_ISFORMCOMPLETED"
    Private OrderNo As String = ""
    Private strCustomerID As String = ""
    Protected WithEvents txtHiddenCustomerID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtHiddenOrderID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtIssueNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents tdCardHeading As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trStartDate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdStartDate As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trIssueNumber As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblaccregistration As System.Web.UI.WebControls.Label
    Protected WithEvents lblpara As System.Web.UI.WebControls.Label
    Protected WithEvents lblinvoicename1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblContactName1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblstreet1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcity As System.Web.UI.WebControls.Label
    Protected WithEvents lblstate1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblpostcode1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcountry1 As System.Web.UI.WebControls.Label
    Protected WithEvents lbltelephone1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblfax1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblemail1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblinvoicename2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblcontactname2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblpassword As System.Web.UI.WebControls.Label
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
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td8 As System.Web.UI.HtmlControls.HtmlTableCell
    Private WithEvents objCXL As New CXLProcessing

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

#Region ":::::::::::::::: Event Handlers ::::::::::::::::"

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
            'pnlDrCardInfo.Visible = False

            '**************(MNS)****************
            SetFocus(txtInvoiceName)
            '***********************************

            Session(Me.ACC_ISFORMCOMPLETED) = Boolean.FalseString
        End If

        productJavaScript = CXLProcessing.GetProuctsDependencies()

        If Session(Me.ACC_ISFORMCOMPLETED) = "" Then Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Home))
    End Sub

    Private Sub pnlPaymentMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPaymentMethod.Load

        Dim strGridLoad As String = ViewState.Item("GridLoadCount")

        If strGridLoad = "1" Then '**** " Condition Removed Due to Localization "

            ' INSERT AMOUNT IN PRODUCT SELECTION OF REGISTRATION PROCESS

            Dim ds As New DataSet

            ds = BLL.User.ACC_GetProductsToSale 'PackageOptions.EnableSale, ServiceOptions.EnableSale)

            CheckOrderHereRow(ds)
            grdPackages.DataSource = ds.Tables(0)
            set_culture()
            grdPackages.DataBind()
            grdPackages.Visible = ds.Tables(0).Rows.Count > 0
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
            If grdPackages.Items.Count > 0 Then
                grdPackages.Items(0).Cells(6).ID = "packcell"
            End If
            'end of modification

            grdProducts.DataSource = ds.Tables(1)
            grdProducts.DataBind()
            grdProducts.Visible = ds.Tables(1).Rows.Count > 0
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
            If grdProducts.Items.Count > 0 Then
                grdProducts.Items(0).Cells(6).ID = "procell"
            End If
            'end of modification

            ViewState.Remove("GridLoadCount")
            ViewState.Add("GridLoadCount", "2")
        Else
            If strGridLoad Is Nothing Then
                ViewState.Add("GridLoadCount", "1")
            Else
                ViewState.Remove("GridLoadCount")
                ViewState.Add("GridLoadCount", "2")
            End If
        End If

    End Sub
    Private Sub set_culture()
        'load_culture(idxTopBar.CultureName)
        'Me.grdPackages.Columns(1).HeaderText = load_culturevalue("acc_ghpackagename")
        'Me.grdPackages.Columns(2).HeaderText = load_culturevalue("acc_ghdescription")
        'Me.grdPackages.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")

        'Me.grdProducts.Columns(1).HeaderText = load_culturevalue("acc_ghproductname")
        'Me.grdProducts.Columns(2).HeaderText = load_culturevalue("acc_ghdescription")
        'Me.grdProducts.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")
    End Sub
    Private Sub btnCreateAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateAccount.Click

        '-------------------------------------------------------------------------------
        Dim blnCustomerStatus As Boolean = True
        'Dim strSurName As String
        Dim strFirstName, strSecondName, strStreet, strTown, strState, strPostCode, _
        strCountry, strContName, strPh, strFax, strEmail, strNotes As String
        Dim strInvoiceName As String
        '-------------------------------------------------------------------------------

        If VerifyCustomerDetailPanel() = True Then
            '-------------------------------------

            strInvoiceName = txtInvoiceName.Text
            'strSurName = txtSurName.Text
            'strFirstName = txtFirstName.Text
            'strSecondName = txtSecondName.Text
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
            lblInvoiceName.Text = strInvoiceName
            'lblSurName.Text = strSurName
            'lblFirstName.Text = strFirstName
            'lblSecondName.Text = strSecondName
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
            '-------------------------------------
        Else
            '-----------------------------
            pnlInformation.Visible = True
            '-----------------------------
        End If

    End Sub

    Private Sub btnPaymentMethod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaymentMethod.Click
        'Response.Write(Me.SendEmailForServiceEnable(106931, GetSelectedProducts(grdPackages, grdProducts)))

        'Response.End()
        If VerifyPaymentMethodPanel() = True Then
            If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then
                Session("special_pdf_products") = ""
                If isProductSelected("108", grdPackages, grdProducts) Then
                    Session("special_pdf_products") = "108"
                End If

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

    Private Sub btnCrCardInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrCardInfo.Click

        If (VerifyCreditCardPanel() = True) And (btnRetry.CommandName = "YES" OrElse VerifyCustomerDetailPanel()) Then
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
            'If ddlCardNames.SelectedItem.Text = "AMEX Card" Then

            '    pnlAmexCardInfo.Visible = True
            '    pnlCrCardInfo.Visible = False
            '    pnlInformation.Visible = False

            '    lblCardName.Text = txtCardHolderName.Text
            '    lblCardNumber.Text = txtCardNumber.Text

            '    lblExpiryDate.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

            '    lblCardAddress.Text = txtCardAddress.Text
            '    lblSecurityCode.Text = txtSecurityCode.Text

            '    '**************(MNS)****************
            '    SetFocus(ddlAmexSDMonth)
            '    '***********************************

            'ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then

            '    pnlCrCardInfo.Visible = False
            '    pnlDrCardInfo.Visible = True
            '    pnlInformation.Visible = False

            '    lblCardName1.Text = txtCardHolderName.Text
            '    lblCardNumber1.Text = txtCardNumber.Text

            '    lblExpiryDate1.Text = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)

            '    lblCardAddress1.Text = txtCardAddress.Text
            '    lblSecurityCode1.Text = txtSecurityCode.Text

            '    '**************(MNS)****************
            '    SetFocus(ddlDrCardSDMonth)
            '    '***********************************

            'Else

            '    CustomerDetail()

            'End If

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
            pnlInformation.Visible = True
            strMsg = "<li>" & Replace(strMsg, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strMsg

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
    Protected Sub btnRetry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetry.Click
        '---------------------------
        FlushFields()
        btnRetry.CommandName = "YES"
        '---------------------------

        '-------------------------------
        pnlInformation.Visible = False
        pnlPaymentMethod.Visible = True
        grdPackages.Visible = False
        grdProducts.Visible = False
        btnRetry.Visible = False
        btnFinish.Visible = False
        '-------------------------------

        '---------------------
        ShowError("", False)
        ShowMessage("", False)
        '---------------------
    End Sub

    Private Sub grdPackages_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdPackages.ItemDataBound

        SetCheckBox(e)

    End Sub

    Private Sub grdProducts_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles grdProducts.ItemDataBound
        SetCheckBox(e)
    End Sub

#End Region

#Region ":::::::::::::::: Helper Functions and Procedures ::::::::::::::::"

    Private Sub SetCardHeadings(ByVal CardType As Integer)
        pnlAmexCardInfo.Visible = True
        pnlCrCardInfo.Visible = False
        pnlInformation.Visible = False


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

    Private Sub FillCountriesList2()

        ddlCountry.DataSource = BLL.User.GetCountryName
        ddlCountry.DataTextField = "Name"
        ddlCountry.DataValueField = "Code"
        ddlCountry.DataBind()
        ddlCountry.SelectedIndex = CommonBase.Resources(ACC_Resource.DefaultCountry)

    End Sub

    Private Function CustomerDetail()

        Dim objUser As New User
        Dim objCXLOrder As New CXLOrderProcessing
        Dim objCryptography As New Cryptography
        'Dim strSurName, strFirstName, strSecondName As String

        Dim strAc, strUID, strPassword, strStreet, strTown, _
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

        Dim intRndNo, intEmployeesQty, intQty, intProductID As Integer

        Dim lngMerchantID As Long
        Dim strGKey, strCreditCardType, strIssueNo, strSecurityCode, strCreditCardNo, strCreditCardName, strCreditCardAddress As String
        Dim strGKeyLen As Integer = 1024
        Dim strMsg, strInvoiceName As String
        Dim strTime As DateTime
        Dim strLogType As String = "C"
        Dim intCustomerID As Integer
        Dim strPaymentMode As String
        Dim isRetryPayment As Boolean = False
        Dim isRepayment As Boolean = False

        If btnRetry.CommandName = "YES" Then
            isRepayment = True
        End If

        btnRetry.CommandName = "NO"

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : isRepayment IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        If Not isRepayment Then
            '-----------
            OrderNo = ""
            '-----------

            '---------------------------------------------------------
            strAc = "a"
            'strSurName = txtSurName.Text
            'strFirstName = txtFirstName.Text
            'strSecondName = txtSecondName.Text
            strInvoiceName = txtInvoiceName.Text

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

            strGKey = objCryptography.KeyGen(strGKeyLen)
            strEncryptPassword = objCryptography.EnCrypt(strPassword, strGKey)
            '-------------------------------------------------------------------
        Else
            '---------------------------------------------
            intCustomerID = CInt(txtHiddenCustomerID.Text)
            OrderNo = txtHiddenOrderID.Text
            strGKey = objCXLOrder.AccGetLogKey(intCustomerID)
            '--------------------------------------------
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END : isRepayment IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        '----------------------------------
        ' PASSWORD ENCRYPTION
        strTime = Now
        strFnew = "y"
        strFModified = "n"
        strStoreName = "ACCOUNTSCENTRE"
        'strStoreName = "formationshouse"
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
        strDeliveryAddress = txtDeliveryAddress.Text
        strCustPh = txtTelephone.Text
        dtePromiseShipDate = DateSerial(Year(Now), Month(Now), Day(Now) + 7)
        '--------------------------------------------------------------------

        '------------------------------------
        strStartDate = New Date(2000, 1, 1)
        strEndDate = strStartDate
        Dim isCreditCard As Boolean = False
        '------------------------------------

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : Bank / Cheque/ Credit Card IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' Option to choose Cheque Or Bank Transfer / Credit Card

        If rbtPaymentMethod.SelectedItem.Value.ToString = "Credit Card" Then
            '-------------------------------------------------
            strCreditCardType = ddlCardNames.SelectedItem.Text
            strCreditCardNo = txtCardNumber.Text
            strCreditCardName = txtCardHolderName.Text
            strCreditCardAddress = txtCardAddress.Text
            '-------------------------------------------------

            '------------------------------------------
            If txtSecurityCode.Text <> "" Then
                strSecurityCode = txtSecurityCode.Text
            End If
            '------------------------------------------

            '----------------------------------------------------------------------
            strCardType = objCryptography.EnCrypt(strCreditCardType, strGKey)
            strCardNo = objCryptography.EnCrypt(strCreditCardNo, strGKey)
            strCardName = objCryptography.EnCrypt(strCreditCardName, strGKey)
            strCardAddress = objCryptography.EnCrypt(strCreditCardAddress, strGKey)
            '----------------------------------------------------------------------

            '----------------------------------------------------------------------------------------
            strCardExpires = DateSerial(ddlYear.SelectedItem.Text, ddlMonth.SelectedItem.Text + 1, 0)
            '----------------------------------------------------------------------------------------

            '--------------------------------------------------------------------
            Dim intDayCEx, intMonthCEx, intYearCEx As Integer

            intDayCEx = CInt(Day(strCardExpires))
            intMonthCEx = CInt(Month(strCardExpires))
            intYearCEx = CInt(Year(strCardExpires))
            strCardExpires = intMonthCEx & "/" & intDayCEx & "/" & intYearCEx
            strPaymentMode = "CC"
            isCreditCard = True
            '--------------------------------------------------------------------

        ElseIf rbtPaymentMethod.SelectedItem.Value.ToString = "Cheque Or Bank Transfer" Then
            '--------------------------------------------
            strBankName = txtBankName.Text
            strChequeNo = txtChequeNo.Text
            strSortCode = txtSortCode.Text
            strBankTranRefNo = txtTransactionRefNo.Text
            strPaymentMode = "CB"
            '---------------------------------------------
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : Bank / Cheque/ Credit Card IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        '------------------------------------------------------------------------------------------------------------------------------------------
        strCustomerAddress = strStreet & " " & strTown & " " & strState & " " & strPostCode & " " & strCountry
        Dim strCustomerAddressForEmail As String = strStreet & "<br> " & strTown & "<br>" & strState & "<br>" & strPostCode & "<br>" & strCountry
        '------------------------------------------------------------------------------------------------------------------------------------------


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : AMEX / DEBIT CARDS IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        If ddlCardNames.SelectedItem.Text = "AMEX Card" OrElse ddlCardNames.SelectedItem.Text = "Switch Card" Then
            '--------------------------------------------------------------------------------------------------
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


            strStartDate = intMonthSD & "/" & intDaySD & "/" & intYearSD
            'strEndDate = intMonthED & "/" & intDayED & "/" & intYearED
            '--------------------------------------------------------------------------------------------------
        ElseIf ddlCardNames.SelectedItem.Text = "Debit Card" Then
            '--------------------------------------------------------------------------------------------------
            'Dim intDayDrSD, intMonthDrSD, intYearDrSD As Integer

            'strStartDate = DateSerial(ddlDrCardSDYear.SelectedItem.Text, ddlDrCardSDMonth.SelectedItem.Text + 1, 0)

            'intDayDrSD = CInt(Day(strStartDate))
            'intMonthDrSD = CInt(Month(strStartDate))
            'intYearDrSD = CInt(Year(strStartDate))

            'strStartDate = intMonthDrSD & "/" & intDayDrSD & "/" & intYearDrSD

            If txtIssueNumber.Text <> "" Then
                strIssueNo = txtIssueNumber.Text
            End If
            '--------------------------------------------------------------------------------------------------
        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END : AMEX / DEBIT CARDS IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~


        Dim strProductCodes As String = ProdcutPackageXML(dblOrderAmount)

        '----------------------
        strPayProcessBy = "AC"
        ' strPayProcessBy = "s"
        strWintiprocess = "n"
        '----------------------

        '------------------------------------
        Dim intParentCustomerID As Integer
        Dim bolAsExcluded As Boolean = False
        '------------------------------------

        '----------------------------------------------------------------------------------------------------------------
        If Not (Session("ACC_GV_RegistrationMode") Is Nothing) Then
            intParentCustomerID = CInt(Session("ACC_GV_ParentCustomerID"))
            If (Session("ACC_GV_RegistrationMode") = RegistrationMode.ExcludedFromGlobalView) Then bolAsExcluded = True
        End If
        '----------------------------------------------------------------------------------------------------------------

        Dim strReturn, strServiceStatus, strLoginID As String
        Dim isRepaySuccess As Boolean = True
        Dim intTrackID As Integer = 0


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : isRepayment IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        If Not isRepayment Then

            strMsg = objUser.AddCustomer(intCustomerID, strAc, "strSurName", strInvoiceName, "strSecondName", strStreet, _
                                         strTown, strCountryCode, strCountry, strPostCode, strContName, strPh, _
                                         strFax, strEmail, strNotes, strUID, strEncryptPassword, strState, strTime, _
                                         strFnew, strFModified, strStoreName, lngMerchantID, strGKey, strEncryptKey, _
                                         intRndNo, strOrderNo, strDeliveryAddress, strCustPh, dblDiscount, strFShipped, _
                                         dteOrderDate, dtePromiseShipDate, strCardType, strCardNo, strCardName, _
                                         strCardExpires, strCardAddress, strCustomerAddress, dblOrderAmount, _
                                         strStartDate, strEndDate, strSecurityCode, strIssueNo, strPayProcessBy, _
                                         strBankName, strChequeNo, strSortCode, strBankTranRefNo, strWintiprocess, _
                                         strProductCodes, intParentCustomerID, bolAsExcluded)

            strLoginID = intRndNo & intCustomerID



        Else
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
            dblOrderAmount = 0
            strStartDate = GetDate(strStartDate)
            strCardExpires = GetDate(strCardExpires)
            strEndDate = strCardExpires

            objCXL.CalculateAccProdAmount(intCustomerID, OrderNo, dblOrderAmount, intTrackID)

            '***********************************************************************************************
            '::::::::::::::::::::::::::::::::::::::Muhammad Ubaid:::::::::::::::::::::::::::::::::::::::::::
            '***********************************************************************************************
            'I have commited following code for retry bug credit card number not found repalce strMode with 
            'strPaymentMode
            '***********************************************************************************************
            'strServiceStatus = objCXL.RepaymentCXL(strReturn, OrderNo, intCustomerID, strCreditCardType, strCreditCardNo, _
            '                            strCreditCardName, strCreditCardAddress, strCardExpires, _
            '                                strIssueNo, strSecurityCode, strStartDate, strEndDate, _
            '                                strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
            '                                dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strMode)
            strServiceStatus = objCXL.RepaymentCXL(strReturn, OrderNo, intCustomerID, strCreditCardType, strCreditCardNo, _
                                                    strCreditCardName, strCreditCardAddress, strCardExpires, _
                                                        strIssueNo, strSecurityCode, strStartDate, strEndDate, _
                                                        strBankName, strChequeNo, strSortCode, strBankTranRefNo, _
                                                        dblOrderAmount, 0, dblOrderAmount, dblOrderAmount, strPaymentMode)
            '***********************************************************************************************

            Trace.Write("Repayment XML : " & strReturn)
            Trace.Write("Successfully called RepaymentCXL and return " & strServiceStatus)
            'Dim dteCardExpire, dteStartDate As Date
            'dteCardExpire = GetDate(strCardExpires)
            'dteStartDate = GetDate(strStartDate)


            'objCXL.UpdateInvoiceInfo(OrderNo, strCardType, strCardName, strCardNo, strCardAddress, dteCardExpire, strIssueNo, strSecurityCode, dteStartDate, dteCardExpire, strBankName, strChequeNo, strSortCode, strBankTranRefNo)
            isRepaySuccess = IsNumeric(strServiceStatus)
            'isRepaySuccess = True


        End If
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ END : isRepayment IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        '---------------------------------------
        pnlInformation.Visible = True
        pnlCustomerDetail.Visible = False
        pnlCustomerRegistration.Visible = False
        pnlPaymentMethod.Visible = False
        pnlCrCardInfo.Visible = False
        pnlAmexCardInfo.Visible = False
        ' pnlDrCardInfo.Visible = False
        pnlBankTransfer.Visible = False
        '---------------------------------------

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ START : CustomerID is not equal to ZERO IF ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        If intCustomerID <> 0 Then
            Dim strCompanyName As String = CStr(Session("ACC_GV_ProcessCompany"))
            Dim strCompanyNumber As String = CStr(Session("ACC_GV_CompanyNumber"))
            Session("ACC_GV_ProcessCompany") = Nothing
            Session("ACC_GV_CompanyNumber") = Nothing

            objUser.LoadAccountscetreUser(intCustomerID, strCompanyName, strCompanyNumber)

            REM SR
            If (Not (Session("ACC_GV_RegistrationMode") Is Nothing)) And (Not isRepayment) Then
                objUser.UpdateFormationsHouseSubAccount(strCompanyName, strCompanyNumber, intCustomerID, intParentCustomerID)
                objUser.UpdateCompStatus(intCustomerID, 2)
            End If
            REM SR

            'If Not Session("ACC_GV_RegistrationMode") Is Nothing Then UpdateGlobalView(intCustomerID)

            'InfoMessage = ACCMessage.Account_NewCustomerCreated
            ' Dim colSelectedServices As NameValueCollection = GetSelectedProducts(False, grdPackages, grdProducts)

            '====================== NEW CHANGE ======================'
            ' Date          : 28th Feb. 2006
            ' Reason        : Automatically order process by ROBOT
            ' Modified by   : Abid Ali
            '========================================================'

            ' Before Change i.e. calling CXL from ishop webservices
            Dim isEnableService As Boolean
            If isRepaySuccess Then
                OrderNo = objCXL.GetLastOrderNo(intCustomerID)


                'isRetryPayment = CallCXLProcessing(intCustomerID, strPaymentMode, isEnableService)

                CXLProcessing.InsertOrderIntoCxlRobot(isCreditCard, strLoginID, OrderNo, dblOrderAmount, isRepayment, strCardNo, strCardType, strCreditCardName, strCardAddress, txtSecurityCode.Text, txtIssueNumber.Text, "826", "GBP", strStartDate, strCardExpires, intTrackID)
                'isRetryPayment = False

            Else
                ShowError("Some information is missing please give correct information. " & strServiceStatus, True)
                objCXL.AccInsertPaymentErrorLog(CustomerID, OrderNo, Now, 0, strServiceStatus)
                isRetryPayment = True
            End If

            'new change
            'isRetryPayment = False

            'Dim InfoMsg As String = CommonBase.EmailMessages(ACC_Email_Messages.New_Account_Email_Template) 'ACCMessage.Account_NewCustomerCreated
            ''---------------------------------
            'InfoMsg = InfoMsg.Replace("[Name]", strInvoiceName)
            ''InfoMsg = InfoMsg.Replace("[Name]", txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text)
            'InfoMsg = InfoMsg.Replace("[LoginID]", strLoginID)
            'InfoMsg = InfoMsg.Replace("[Password]", txtPassword.Text)
            'InfoMsg = InfoMsg.Replace("[ServicesInformation]", CommonBase.CreateList(colSelectedServices))

            'InfoMessage = InfoMsg.Replace("[Address]", strEmail)

            ''Dim objEmail As New System.Web.Mail.MailMessage

            'Dim strServicesInformation As String = ProdcutPackageXML(, True)

            'strTo = strEmail.ToString

            'If Not Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView Then

            '    strSubject = ACCMessage.Email_AccountRegistration
            '    strBody = "Dear valued customer," & vbCrLf & vbCrLf & _
            '    "We have received your account information provided by you through " & vbCrLf & _
            '    "http://www.accountscentre.com" & vbCrLf & vbCrLf & _
            '    "Your request of account activation is under process and you will receive a " & _
            '    "user id and password for login purposes via another email within 24 hours. " & vbCrLf & vbCrLf & _
            '    "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
            '    "Email:   support@AccountsCentre.com" & vbCrLf & _
            '    "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"



            '    strBody = Me.SendEmailForServiceEnable(intCustomerID, colSelectedServices)
            '    '--------------------------------------------------------------------
            '    Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
            '    '--------------------------------------------------------------------

            '    If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '                         strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Html, strBCC) = "" Then
            '        'EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '        EmailManager.CreatDBLog(intCustomerID, "LGIN", strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '    Else
            '        'EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '        EmailManager.CreatDBLog(intCustomerID, "LGIN", strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '    End If



            '    Dim strFullName As String = strInvoiceName  'strSurName & strFirstName & strSecondName
            '    Dim LoginID As String = intRndNo & intCustomerID
            '    'Dim strEmailTemplate As String
            '    Dim strTemplateSubject As String = EmailSubject()
            '    strBody = SelectEmailContent("ACSA", strFullName, LoginID, strPassword, strCustomerAddressForEmail, strServicesInformation)


            '    If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '         ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '         strTemplateSubject, strBody.ToString, MailFormat.Html, strBCC) = "" Then
            '        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '    Else
            '        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '    End If
            'Else
            '    '--------------------------------------------------------------------
            '    Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
            '    '--------------------------------------------------------------------

            '    strSubject = ACCMessage.Email_AccountRegistration
            '    strBody = "Dear valued customer, " & vbCrLf & vbCrLf & _
            '              "We have received your Company's information provided by you through" & vbCrLf & _
            '              "http://www.accountscentre.com" & vbCrLf & vbCrLf & _
            '              "Your Company " & "'" & strCompanyName & "'" & " is activated with the following services:" & vbCrLf & vbCrLf & _
            '              strServicesInformation & vbCrLf & vbCrLf & _
            '              "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
            '              "Email:   support@AccountsCentre.com" & vbCrLf & _
            '              "Phone:   +44 (0)207 016 2729 (9am - 1pm on weekdays)"


            '    If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '         strTo.ToString, strSubject.ToString, strBody.ToString, MailFormat.Text, strBCC) = "" Then
            '        'EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '        EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '    Else
            '        'EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, txtSurName.Text & " " & txtFirstName.Text & " " & txtSecondName.Text, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '        EmailManager.CreatDBLog(intCustomerID, "", strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '    End If


            '    Dim strFullName As String = strInvoiceName 'strSurName & strFirstName & strSecondName
            '    Dim LoginID As String = intRndNo & intCustomerID
            '    'Dim strEmailTemplate As String
            '    Dim strTemplateSubject As String = EmailSubject()

            '    strBody = SelectEmailContent("ASCA", strFullName, LoginID, strPassword, strCustomerAddressForEmail, strServicesInformation)
            '    Dim enabledWebApp As New System.Collections.Specialized.NameValueCollection

            '    If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '         ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
            '         strTemplateSubject, strBody.ToString, MailFormat.Html, strBCC) = "" Then
            '        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
            '    Else
            '        EmailManager.CreatDBLog(intCustomerID, "ACSA", strBody.ToString, strFullName, ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTemplateSubject, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
            '    End If

            'End If

            ''objEmail = Nothing
            If Not isRetryPayment Then
                '--------------------------------------------------------------------------------------------------------
                Dim colSelectedServices As NameValueCollection = GetSelectedProducts(False, grdPackages, grdProducts)
                Dim InfoMsg As String = CommonBase.EmailMessages(ACC_Email_Messages.New_Account_Email_Template)
                Dim strPurchasedServiceList = CommonBase.CreateList(colSelectedServices)
                '--------------------------------------------------------------------------------------------------------

                '----------------------------------------------------------------------------------------------
                InfoMsg = InfoMsg.Replace("[Name]", strInvoiceName)
                InfoMsg = InfoMsg.Replace("[LoginID]", strLoginID)
                InfoMsg = InfoMsg.Replace("[Password]", txtPassword.Text)
                InfoMsg = InfoMsg.Replace("[ServicesInformation]", strPurchasedServiceList)
                InfoMsg = InfoMsg.Replace("[Address]", strEmail)
                'ShowMessage(InfoMsg, True)
                InfoMessage = InfoMsg
                '----------------------------------------------------------------------------------------------

                '----------------------------------------------------------------
                Dim strServicesInformation As String = ProdcutPackageXML(, True)
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
                SendEmail(strPaymentMode = "CC", intCustomerID, strLoginID, strPassword, strCustomerAddressForEmail, strEmail, strSubject.ToString, strInvoiceName, strPurchasedServiceList, strBCC, isEnableService)
                '------------------------------------------------------------------------------

                '--------------------------------------------------------------------------------------------------------------------------------
                Dim strFullName As String = strInvoiceName
                Dim LoginID As String = intRndNo & intCustomerID
                Dim strTemplateSubject As String = EmailSubject()
                strBody = SelectEmailContent("ACSA", strFullName, LoginID, txtPassword.Text, strCustomerAddressForEmail, strPurchasedServiceList)
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

        btnFinish.Visible = True

        '============= NEW MODIFICATION FOR RETRY PAYMENT =======================

        If isRetryPayment Then
            '----------------------------------------
            btnRetry.Visible = True
            txtHiddenCustomerID.Text = intCustomerID
            txtHiddenOrderID.Text = OrderNo
            '----------------------------------------
        Else
            Session.Remove(Me.ACC_ISFORMCOMPLETED)
            Session.Remove(Me.ACC_ORDER_HERE_LINK)
        End If

    End Function

    Private Function GetDate(ByVal DateValue As String) As Date
        Dim strExpiry() As String = Split(DateValue, "/")
        Dim dteCardExpire As New Date(strExpiry(2), strExpiry(0), strExpiry(1))

        Return dteCardExpire
    End Function

    'Public Function SelectEmailContent(ByVal Name As String, ByVal strLoginID As String, Optional ByVal strpassword As String = "", Optional ByVal strCustomerAddress As String = "", Optional ByVal strServicesInformation As String = "") As String
    '    Dim strFullName As String = Name 'strSurName & strFirstName & strSecondName
    '    Dim LoginID As String = strLoginID 'intRndNo & intCustomerID
    '    Dim strEmailTemplate As String
    '    Dim strTemplateSubject As String, intActive As Integer

    '    Dim dsEmailContent As DataSet
    '    dsEmailContent = objTemplate.SelectEmailContent("ACSA")
    '    strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
    '    strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")

    '    Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
    '    strbuilder.Replace("[Name]", strFullName).ToString()
    '    strbuilder.Replace("[LoginID]", LoginID).ToString()
    '    strbuilder.Replace("[Password]", strpassword).ToString()
    '    strbuilder.Replace("[Address]", strCustomerAddress).ToString()
    '    strbuilder.Replace("[ServicesInformation]", strServicesInformation).ToString()
    '    Return strbuilder.ToString

    'End Function

    Public Function EmailSubject() As String
        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer

        Dim dsEmailContent As DataSet
        dsEmailContent = objTemplate.SelectEmailContent("LGIN")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        Return strTemplateSubject

    End Function

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

        'objRegExp.Add("txtSurName", "0700500550", "Surname")
        'objRegExp.Add("txtFirstName", "0700501000", "First Name")
        'objRegExp.Add("txtSecondName", "0700501001", "Second Name ")
        objRegExp.Add("txtInvoiceName", "0700502550", "Invoice Name")
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

        objRegExp.Add("txtIssueNumber", "0100100020", "Issue Number")


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

            'If InStr(strName, " ") > 0 Then
            '    txtSurName.Text = strName.Substring(0, strName.IndexOf(" "))
            'Else
            '    txtSurName.Text = strName
            'End If

            'txtSurName.Text = Trim(txtSurName.Text)
            'strName = strName.Remove(0, Len(txtSurName.Text))

            'If Not strName = String.Empty Then
            '    strName.Trim()
            '    txtFirstName.Text = strName.Substring(0, strName.IndexOf(" "))
            '    txtFirstName.Text = Trim(txtFirstName.Text)
            '    strName.Remove(0, Len(txtFirstName.Text))
            'End If

            'If Not strName = String.Empty Then
            '    strName.Trim()
            '    txtSecondName.Text = strName
            'End If

            '---------------------------
            txtInvoiceName.Text = strName
            '---------------------------

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

    Public Sub SetCheckBox(ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)

        ' If Session(Me.ACC_ORDER_HERE_LINK) <> "" Then

        Select Case e.Item.ItemType

            Case ListItemType.AlternatingItem, ListItemType.Item
                '                    Response.Write(e.Item.DataItem("ProductCode"))
                Dim chkBox As CheckBox
                chkBox = CType(e.Item.Cells(0).Controls(1), CheckBox)

                ' htCheckBoxNames.Add(e.Item.DataItem("ProductCode"), chkBox.UniqueID)
                checkBoxJavaScript &= vbNewLine & "<script>  checkBoxNames[" & index & "]='" & chkBox.UniqueID & "'; checkBoxValues[" & index & "]='" & e.Item.DataItem("ProductCode") & "';  </script> "
                index += 1
                chkBox.Attributes.Add("onClick", "Checking('" & chkBox.UniqueID & "','" & e.Item.DataItem("ProductCode") & "');")

                If Session(ACC_ORDER_HERE_LINK) <> "" AndAlso Session(ACC_ORDER_HERE_LINK) = e.Item.DataItem("ProductCode") Then
                    chkBox.Checked = True
                    chkBox.Enabled = False
                    defaultSelectionScript = "<script>Checking('" & chkBox.UniqueID & "','" & e.Item.DataItem("ProductCode") & "');</script> "
                End If
                'chkBox.Checked = e.Item.DataItem("ProductCode") = Session(Me.ACC_ORDER_HERE_LINK)

                'If chkBox.Checked Then chkBox.Visible = False

        End Select
        ' End If
    End Sub

    Private Sub SendEmail(ByVal IsCreditCard As Boolean, ByVal intCustomerID As Integer, ByVal strLoginID As String, ByVal strUserPassword As String, ByVal strCustomerAddressForEmail As String, ByVal strTo As String, ByVal strSubject As String, ByVal strInvoiceName As String, ByVal strServicesInformation As String, ByVal strBCC As String, ByVal IsEnableService As Boolean)

        Dim templateName, strBody As String


        If IsCreditCard Then
            If IsEnableService Then
                ' by credit card
                '-------------------------------------------------------------------------

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
                '-------------------------------------------------------------------------------------------------------------
                If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                     strTo, strSubject, strBody.ToString, MailFormat.Html, strBCC) = "" Then
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                Else
                    EmailManager.CreatDBLog(intCustomerID, templateName, strBody.ToString, strInvoiceName, strTo.ToString, strSubject.ToString, ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                End If
                '-------------------------------------------------------------------------------------------------------------
            Else
                '-----------------------------------
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

            templateName = "ACBP"

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
#End Region

#Region ":::::::::::::::: CXL Implementation ::::::::::::::::"

    Private Function CallCXLProcessing(ByVal CustomerID As Integer, ByVal PaymentMode As String, Optional ByVal isEnableService As Boolean = False) As Boolean
        '**************************************************************************************************
        '**I've committed it for genrating the tracID in both cases CB/CC ***************************
        '**************************************************************************************************
        ' If PaymentMode = "CC" Then

        Dim strReturn As String = ""
        Dim strUID As String = ""
        Dim objUser As New User

        '------------------------------------------------------
        Dim strMode As String = objCXL.GetPaymentMethodString()
        '------------------------------------------------------

        '-------------------------------------------------------------
        Dim dsUser As DataSet = objUser.GetCustomerData(CustomerID)
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

        '-----------------------------------------------------------------------
        ' Get OrderNo
        'Try
        OrderNo = objCXL.GetLastOrderNo(CustomerID)
        'Catch ex As Exception
        'End Try
        '-----------------------------------------------------------------------


        Trace.Write("Calling CXL......")

        Dim strStatusCXL As String = objCXL.CollectionCXL(CustomerID, strUID, OrderNo, strMode, 826, PaymentMode, strReturn)

        Trace.Write("CollectionService XML : " & strReturn)
        Trace.Write("Result : " & strStatusCXL)
        Trace.Write("Checking CXL Result.... ")

        Return objCXL.CheckCollectionStatus(CustomerID, strUID, OrderNo, strStatusCXL, PaymentMode, False, isEnableService)
        '------------------------------------------------------------------------------------------------------------
        '**************************************************************************************************
        ' End If
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
        ErrorMessage = msg
        ErrorSpan.Visible = isVisible
        pnlInformation.Visible = isVisible
        'lblErrorInfoMsg.Text = msg
        'lblErrorInfoMsg.Visible = isVisible
        'lblErrorInfoMsg.ForeColor = Color.Red
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
        InfoMessage = msg
        InfoSpan.Visible = isVisible
        pnlInformation.Visible = isVisible
        'lblErrorInfoMsg.Text = msg
        'lblErrorInfoMsg.Visible = isVisible
        'lblErrorInfoMsg.ForeColor = Color.Green
        '---------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Flush All fields
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	29/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub FlushFields()
        txtStreet.Text = ""
        txtTown.Text = ""
        txtState.Text = ""
        txtPostCode.Text = ""
        txtContactName.Text = ""
        txtTelephone.Text = ""
        txtFax.Text = ""
        txtEmailAddress.Text = ""
        txtNotes.Text = ""
        txtDeliveryAddress.Text = ""
        txtCardHolderName.Text = ""
        txtCardNumber.Text = ""
        txtCardAddress.Text = ""
        txtSecurityCode.Text = ""
        txtIssueNumber.Text = ""
        txtBankName.Text = ""
        txtChequeNo.Text = ""
        txtSortCode.Text = ""
        txtTransactionRefNo.Text = ""
        txtConfirmPassword.Text = ""
        txtInvoiceName.Text = ""
    End Sub
#End Region

End Class