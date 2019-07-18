Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL
Imports Infinilogic.AccountsCentre.common
Imports System.Data

Public Class ProductActivation
    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents rb1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lstCompanyName As System.Web.UI.WebControls.ListBox
    Protected WithEvents rb2 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents txtCompanyName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblDomainName As System.Web.UI.WebControls.Label
    Protected WithEvents txtDomainName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlCompanyInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPaymentProcessBy As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPaymentProcessorID As System.Web.UI.WebControls.Label
    Protected WithEvents txtPaymentProcessorID As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPaymentProcessorPassword As System.Web.UI.WebControls.Label
    Protected WithEvents txtPaymentProcessorPassword As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPaymentProcessorCertificate As System.Web.UI.WebControls.Label
    Protected WithEvents txtPaymentProcessorCertificate As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlPaymentProcessor As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtChequePayableTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtChequeAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlBank_OR_CheckDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBankName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBankAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBankAccountName As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBankAccountNumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBankSortCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlBankTransferDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblemail As System.Web.UI.WebControls.Label
    Protected WithEvents ddlemail As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents btnActivate As System.Web.UI.WebControls.Button
    Protected WithEvents txtAPIResellerURL As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label11 As System.Web.UI.WebControls.Label
    Protected WithEvents trAPIResellerDomainInfo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ddlCurrencyDB As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trCurrency As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trMessage As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trResellerQuestion As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblwaitmsg As System.Web.UI.WebControls.Label
    Protected WithEvents btnStartAC As System.Web.UI.WebControls.Button
    Protected WithEvents btnGotoResellerSystem As System.Web.UI.WebControls.Button
    Protected WithEvents btnMyAccount As System.Web.UI.WebControls.Button
    Protected WithEvents pnlSuccess As System.Web.UI.WebControls.Panel
    Protected WithEvents trPaymentProcessorID As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPaymentProcessorPassword As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents trPaymentProcessorCertificate As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents rbRegDomainInfo As System.Web.UI.WebControls.RadioButton
    Protected WithEvents txtRegDomainName As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlExtention As System.Web.UI.WebControls.DropDownList
    Protected WithEvents btnCheckAvailability As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rbAlreadyRegDomainName As System.Web.UI.WebControls.RadioButton
    Protected WithEvents txtAlreadyRegDomainName As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlIShopDomainInfo As System.Web.UI.WebControls.Panel
    Protected WithEvents Label13 As System.Web.UI.WebControls.Label
    Protected WithEvents label121 As System.Web.UI.WebControls.Label
    Protected WithEvents pnl1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label14 As System.Web.UI.WebControls.Label
    Protected WithEvents Label12 As System.Web.UI.WebControls.Label
    Protected WithEvents Label101 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlBankNote As System.Web.UI.WebControls.Panel
    Protected WithEvents lblPaymentProcessorCurrency As System.Web.UI.WebControls.Label
    Protected WithEvents ddlPaymentProcessorCurrency As System.Web.UI.WebControls.DropDownList
    Protected WithEvents trPaymentProcessorCurrency As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label19 As System.Web.UI.WebControls.Label
    Protected WithEvents txtBIC As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label110 As System.Web.UI.WebControls.Label
    Protected WithEvents txtIBANNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label111 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSwiftCode As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private _GeneralInfo As GeneralInfo
    Private _PaymentProcessorInfo As InfiniLogic.AccountsCentre.BLL.Merchant.PaymentProcessor

    Private Structure GeneralInfo
        Public ResellerID As String
        Public ParentCustomerID As Integer
        Public ChildCustomerID As Integer
        Public ProductCode As String
        Public OrderNo As Integer
        Public SerialNo As Integer
        Public Language As String

        Public APIResellerCodeList As String
        Public ResellerProCodeList As String
        'Public InfinishopMerchatCodeList As String

        Public IsAPIReseller As Boolean
        Public IsResellerPackageAvailable As Boolean
        Public IsInfinishopCustomer As Boolean
    End Structure

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim sTime As String = Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Session("UniquePath") = sTime

        trMessage.Visible = False
        If Not Page.IsPostBack Then
            WriteDebugInfo("Calling PrepareMe")
            PrepareMe()
            WriteDebugInfo("PrepareMe is ok")
        Else
            LoadGeneralInfo_Session()
            LoadPaymentProcessorInfo_Session()
        End If

        'btnActivate.Attributes.Add("onclick", "DisableControl('" & btnBack.ClientID & "'); DisableControl('" & btnActivate.ClientID & "'); wait();")
        btnActivate.Attributes.Add("onclick", "wait();Hide();")
        '------------
        txtCompanyName.Attributes.Add("onClick", "EnableChk('rb2')")
        lstCompanyName.Attributes.Add("onClick", "EnableChk('rb1')")

        txtRegDomainName.Attributes.Add("onClick", "EnableChk('rbRegDomainInfo')")
        ddlExtention.Attributes.Add("onClick", "EnableChk('rbRegDomainInfo')")
        txtAlreadyRegDomainName.Attributes.Add("onClick", "EnableChk('rbAlreadyRegDomainName')")
    End Sub

    Private Sub SetPaymentProcessorInfo_Session()
        Session("_PaymentProcessorInfo") = _PaymentProcessorInfo
    End Sub

    Private Sub SetGeneralInfo_Session()
        Session("_GeneralInfo") = _GeneralInfo
    End Sub

    Private Sub LoadGeneralInfo_Session()
        If Not Session("_GeneralInfo") Is Nothing Then
            _GeneralInfo = Session("_GeneralInfo")
        End If
    End Sub

    Private Sub LoadPaymentProcessorInfo_Session()
        If Not Session("_PaymentProcessorInfo") Is Nothing Then
            _PaymentProcessorInfo = Session("_PaymentProcessorInfo")
        End If
    End Sub

    Private Sub Clear_Session()
        Session.Remove("_GeneralInfo")
        Session.Remove("_PaymentProcessorInfo")
    End Sub

    Public Sub PrepareMe()
        _GeneralInfo = New GeneralInfo
        '-----------getting Parameter from query string----------Start
        Dim parameter As String
        parameter = Request("detail")
        Dim objSecureQueryString As New SecureQueryString(parameter)
        parameter = objSecureQueryString.Item("detail")
        WriteDebugInfo("parameter = " & parameter)

        Dim Detail() As String
        WriteDebugInfo("spliting")
        Detail = parameter.Split(New Char() {"^"})

        If Not Detail Is Nothing Then
            WriteDebugInfo("POSTED VALUES:")
            Dim ii As Integer
            For ii = 0 To Detail.Length - 1
                WriteDebugInfo("    " & Detail(ii))
            Next
        End If

        _GeneralInfo.ParentCustomerID = Detail(0)
        _GeneralInfo.ProductCode = Detail(1)
        _GeneralInfo.OrderNo = Detail(2)
        _GeneralInfo.SerialNo = Detail(3)
        _GeneralInfo.Language = Detail(4)
        Trace.Write("Session(PageTemplate.Session_ResellerID) is empty: " & (Session(PageTemplate.Session_ResellerID) = ""))
        If Session(PageTemplate.Session_ResellerID) = "" Then
            WriteDebugInfo("Calling GetResellerOrder_CustomerID")
            WriteDebugInfo("    MainDBCustomerID=" & _GeneralInfo.ParentCustomerID)
            WriteDebugInfo("    OrderNo=" & _GeneralInfo.OrderNo)
            Session(PageTemplate.Session_ResellerID) = (New InfiniLogic.AccountsCentre.BLL.ResellerCustomer).GetResellerOrder_CustomerID(_GeneralInfo.ParentCustomerID, _GeneralInfo.OrderNo)
            WriteDebugInfo("GetResellerOrder_CustomerID is ok: Session(PageTemplate.Session_ResellerID)=" & Session(PageTemplate.Session_ResellerID))
        End If

        _GeneralInfo.ResellerID = Session(PageTemplate.Session_ResellerID)
        WriteDebugInfo("_GeneralInfo.ResellerID=" & _GeneralInfo.ResellerID)
        '-----------getting Parameter from query string----------End

        'Check that this activation is new 
        Dim objIsServiceActivatedResult As New BizAPI_Service.IsOrderActivatedResult
        WriteDebugInfo("Calling IsServiceActivated")
        objIsServiceActivatedResult = BizAPI_Service.IsOrderActivated(_GeneralInfo.ResellerID, _GeneralInfo.OrderNo, _GeneralInfo.ProductCode, _GeneralInfo.SerialNo)
        WriteDebugInfo("IsServiceActivated is ok")
        If objIsServiceActivatedResult.ServiceAlreadyActivated Then
            WriteDebugInfo("objIsServiceActivatedResult.ServiceAlreadyActivated" & objIsServiceActivatedResult.ServiceAlreadyActivated)
            WriteDebugInfo("objIsServiceActivatedResult.CustomerID" & objIsServiceActivatedResult.CompanyID)
            Response.Redirect("https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & Session(PageTemplate.Session_ServiceID))  ' Redirect to Home page.
            Exit Sub
        End If

        '-------Initialize Company List---------Start
        Dim objGlobalView As New GlobalView
        Dim bRetFormationsHouseProblem As Boolean
        Dim GVCompanies As DataTable
        Dim UserUID As String
        Dim dtCompanies As DataTable
        Dim dvCompanies As DataView

        UserUID = (New User).GetCustomerUID(_GeneralInfo.ParentCustomerID)
        WriteDebugInfo("UserUID=" & UserUID)

        WriteDebugInfo("Calling getAllCompanies")
        GVCompanies = objGlobalView.getAllCompanies(_GeneralInfo.ParentCustomerID, UserUID, bRetFormationsHouseProblem)
        WriteDebugInfo("done!")

        WriteDebugInfo("Calling getAllCompaniesByFH")
        dtCompanies = objGlobalView.getAllCompaniesByFH(_GeneralInfo.ParentCustomerID, GVCompanies, True)
        WriteDebugInfo("done!")

        If dtCompanies.Rows.Count = 0 Then
            lstCompanyName.Items.Add("Your Company Name")
        Else
            lstCompanyName.DataTextField = "CompName"
            lstCompanyName.DataValueField = "MemberCustomerID"
            lstCompanyName.DataSource = dtCompanies
            lstCompanyName.DataBind()
        End If
        lstCompanyName.SelectedIndex = 0
        '-------Initialize Company List---------End


        _GeneralInfo.APIResellerCodeList = System.Configuration.ConfigurationSettings.AppSettings("APIResellerCodeList")
        _GeneralInfo.ResellerProCodeList = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCodeList")
        '_GeneralInfo.InfinishopMerchatCodeList = System.Configuration.ConfigurationSettings.AppSettings("InfinishopMerchatCodeList")
        WriteDebugInfo("APIResellerCodeList = " & _GeneralInfo.APIResellerCodeList)
        WriteDebugInfo("ResellerProCodeList = " & _GeneralInfo.ResellerProCodeList)
        'WriteDebugInfo("InfinishopMerchatCodeList = " & _GeneralInfo.InfinishopMerchatCodeList)

        Trace.Warn("ProductCode=" & _GeneralInfo.ProductCode)
        trCurrency.Visible = False
        trAPIResellerDomainInfo.Visible = False
        trResellerQuestion.Visible = False
        trMessage.Visible = False
        pnlSuccess.Visible = False

        If IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.APIResellerCodeList) Then
            _GeneralInfo.IsAPIReseller = True
            _GeneralInfo.IsInfinishopCustomer = False
            _GeneralInfo.IsResellerPackageAvailable = True

            trAPIResellerDomainInfo.Visible = True
            trResellerQuestion.Visible = True
            BindCurrencyDBCombo()
        ElseIf IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.ResellerProCodeList) Then
            _GeneralInfo.IsAPIReseller = False
            _GeneralInfo.IsInfinishopCustomer = True
            _GeneralInfo.IsResellerPackageAvailable = True

            'Dim QACompanyName As String = ""
            'WriteDebugInfo("Calling GetCompanyName_OrderID: ResellerID=" & _GeneralInfo.ResellerID & "-OrderID=" & _GeneralInfo.OrderNo & "-ProductCode=" & _GeneralInfo.ProductCode)
            'QACompanyName = Infinilogic.AccountsCentre.BLL.ResellerCustomer.GetCompanyName_OrderID(Session(PageTemplate.Session_ResellerID), _GeneralInfo.OrderNo, _GeneralInfo.ProductCode)
            'WriteDebugInfo("GetCompanyName_OrderID is ok: QACompanyName = " & QACompanyName)
            'txtCompanyName.Text = QACompanyName
            BindPaymentProcessor()

            BindCurrencyDBCombo()
            trResellerQuestion.Visible = True
            'ElseIf IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.InfinishopMerchatCodeList) Then
        ElseIf Merchant.IsInfiniShopAvailable_Package(_GeneralInfo.ProductCode) Then
            _GeneralInfo.IsAPIReseller = False
            _GeneralInfo.IsInfinishopCustomer = True
            _GeneralInfo.IsResellerPackageAvailable = False

            'Dim QACompanyName As String = ""
            'WriteDebugInfo("Calling GetCompanyName_OrderID: ResellerID=" & Session(PageTemplate.Session_ResellerID) & "-OrderID=" & _GeneralInfo.OrderNo)
            'QACompanyName = Infinilogic.AccountsCentre.BLL.ResellerCustomer.GetCompanyName_OrderID(Session(PageTemplate.Session_ResellerID), _GeneralInfo.OrderNo, _GeneralInfo.ProductCode)
            'WriteDebugInfo("GetCompanyName_OrderID is ok: QACompanyName = " & QACompanyName)
            'txtCompanyName.Text = QACompanyName
            'Trace.Warn("QACompanyName=" & QACompanyName)
            BindPaymentProcessor()

        End If

        ShowNextStep(_GeneralInfo.IsInfinishopCustomer)

        SetGeneralInfo_Session()
    End Sub

    Private Sub BindCurrencyDBCombo()
        Dim ds As DataSet
        ds = InfiniLogic.AccountsCentre.BLL.User.GetAllCurrencyDBDetail()
        ddlCurrencyDB.DataTextField = "Currency"
        ddlCurrencyDB.DataValueField = "DBID"
        ddlCurrencyDB.DataSource = ds
        ddlCurrencyDB.DataBind()
        If _GeneralInfo.IsAPIReseller Then
            trCurrency.Visible = True
        Else
            trCurrency.Visible = False
        End If
    End Sub

    Private Sub BindPaymentProcessor()
        Dim ds As DataSet
        ds = InfiniLogic.AccountsCentre.BLL.Merchant.GetALLPaymentProcessor
        ddlPaymentProcessBy.DataTextField = "AccountName"
        ddlPaymentProcessBy.DataValueField = "PaymentProcessorID"
        ddlPaymentProcessBy.DataSource = ds
        ddlPaymentProcessBy.DataBind()
        LoadPaymentProcessorInfo(1)
    End Sub

    Private Sub LoadPaymentProcessorInfo(ByVal PaymentProcessorID As String)
        _PaymentProcessorInfo = New InfiniLogic.AccountsCentre.BLL.Merchant.PaymentProcessor
        Dim dr As DataRow = InfiniLogic.AccountsCentre.BLL.Merchant.GetALLPaymentProcessor_ID(PaymentProcessorID).Tables(0).Rows(0)

        _PaymentProcessorInfo.PaymentProcessorID = dr.Item("PaymentProcessorID")
        _PaymentProcessorInfo.AccountName = dr.Item("AccountName")
        _PaymentProcessorInfo.ID_Required = IIf(IsDBNull(dr.Item("ID_Required")), "", dr.Item("ID_Required"))
        _PaymentProcessorInfo.Password_Required = IIf(IsDBNull(dr.Item("Password_Required")), "", dr.Item("Password_Required"))
        _PaymentProcessorInfo.Certificate_Required = IIf(IsDBNull(dr.Item("Certificate_Required")), "", dr.Item("Certificate_Required"))
        _PaymentProcessorInfo.Currency_Required = IIf(IsDBNull(dr.Item("Currency_Required")), "", dr.Item("Currency_Required"))

        _PaymentProcessorInfo.ID_Label = IIf(IsDBNull(dr.Item("ID_Label")), "", dr.Item("ID_Label"))
        _PaymentProcessorInfo.Password_Label = IIf(IsDBNull(dr.Item("Password_Label")), "", dr.Item("Password_Label"))
        _PaymentProcessorInfo.Certificate_Label = IIf(IsDBNull(dr.Item("Certificate_Label")), "", dr.Item("Certificate_Label"))
        _PaymentProcessorInfo.Currency_Label = IIf(IsDBNull(dr.Item("Currency_Label")), "", dr.Item("Currency_Label"))

        _PaymentProcessorInfo.ID_RegEx = IIf(IsDBNull(dr.Item("ID_RegEx")), "", dr.Item("ID_RegEx"))
        _PaymentProcessorInfo.Password_RegEx = IIf(IsDBNull(dr.Item("Password_RegEx")), "", dr.Item("Password_RegEx"))
        _PaymentProcessorInfo.Certificate_RegEx = IIf(IsDBNull(dr.Item("Certificate_RegEx")), "", dr.Item("Certificate_RegEx"))

        lblPaymentProcessorID.Text = _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.ID_Label
        lblPaymentProcessorPassword.Text = _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.Password_Label
        lblPaymentProcessorCertificate.Text = _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.Certificate_Label
        lblPaymentProcessorCurrency.Text = _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.Currency_Label

        trPaymentProcessorID.Visible = _PaymentProcessorInfo.ID_Required
        trPaymentProcessorPassword.Visible = _PaymentProcessorInfo.Password_Required
        trPaymentProcessorCertificate.Visible = _PaymentProcessorInfo.Certificate_Required

        trPaymentProcessorCurrency.Visible = False
        If _PaymentProcessorInfo.Currency_Required Then
            Dim dsSupportedCurrency As DataSet = Merchant.PaymentProcessor_GetSupportedCurrencies(_PaymentProcessorInfo.PaymentProcessorID)
            If (Not dsSupportedCurrency Is Nothing) AndAlso dsSupportedCurrency.Tables.Count <> 0 AndAlso dsSupportedCurrency.Tables(0).Rows.Count <> 0 Then
                ddlPaymentProcessorCurrency.DataSource = dsSupportedCurrency
                ddlPaymentProcessorCurrency.DataTextField = "Currency"
                ddlPaymentProcessorCurrency.DataValueField = "ISO_Code"
                ddlPaymentProcessorCurrency.DataBind()
                trPaymentProcessorCurrency.Visible = _PaymentProcessorInfo.Currency_Required
            End If
        End If

        SetPaymentProcessorInfo_Session()
    End Sub

    Private Function IsProductCodeAvailable(ByVal ProductCode As String, _
                                           ByVal ProductCodeList As String) As Boolean
        Dim ProductCodeListArray() As String = ProductCodeList.Split(New Char() {","})
        For Each Item As String In ProductCodeListArray
            If Item.ToUpper = ProductCode.ToUpper Then
                Return True     'ProductCode found!
            End If
        Next
        Return False            'ProductCode not found!
    End Function

    Private Sub rb1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged
        RadioButtonHandler()
    End Sub

    Private Sub rb2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb2.CheckedChanged
        RadioButtonHandler()
    End Sub

    Private Sub RadioButtonHandler()
        'Dim ExistingCompany As Boolean = rb1.Checked
        'lstCompanyName.Enabled = ExistingCompany
        'txtCompanyName.Enabled = Not ExistingCompany
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If Not Page_IsValid() Then Exit Sub
        If _GeneralInfo.IsInfinishopCustomer Then
            'If IShop is going to activate on existing company
            'then verify that this company does not have IShop
            If rb2.Checked = False Then
                If Not lstCompanyName.SelectedItem.Text.Equals(lstCompanyName.SelectedItem.Value) Then
                    _GeneralInfo.ChildCustomerID = lstCompanyName.SelectedItem.Value
                    If InfiniLogic.AccountsCentre.BLL.Merchant.IsInfinishopCustomer(_GeneralInfo.ChildCustomerID) Then
                        trMessage.Visible = True
                        Dim CompanyName As String = lstCompanyName.SelectedItem.Text
                        If CompanyName.Length > 20 Then
                            CompanyName = CompanyName.Substring(0, 20) & "..."
                        End If
                        Dim Message As String = "<li>This product is already activated on Company : [" & CompanyName & "]"
                        lblError.Text = Message
                        Exit Sub
                    Else
                        trMessage.Visible = False
                    End If
                End If
            End If

        End If

        SetSteps(Steps.SecondPanel)
        If lblError.Text = "" Then
            trMessage.Visible = False
            lblMessage.Text = ""
        End If
    End Sub

    Private Sub IsInfinishopAlreadyAvailable()
        If rb2.Checked = False Then
            If lstCompanyName.SelectedItem.Text.Equals(lstCompanyName.SelectedItem.Value) Then
                _GeneralInfo.ChildCustomerID = _GeneralInfo.ParentCustomerID
            Else
                _GeneralInfo.ChildCustomerID = lstCompanyName.SelectedItem.Value
            End If
        Else
            _GeneralInfo.ChildCustomerID = _GeneralInfo.ParentCustomerID
        End If


    End Sub


    Private Sub SetSteps(ByVal _step As Steps)
        If _step = Steps.FirstPanel Then
            pnlCompanyInformation.Visible = True
            pnlPaymentProcessor.Visible = True
            pnlIShopDomainInfo.Visible = True
            btnNext.Visible = True

            pnlBank_OR_CheckDetail.Visible = False
            pnlBankTransferDetail.Visible = False
            pnlBankNote.Visible = False
            btnBack.Visible = False
            btnActivate.Visible = False
        ElseIf _step = Steps.SecondPanel Then
            pnlCompanyInformation.Visible = False
            pnlPaymentProcessor.Visible = False
            pnlIShopDomainInfo.Visible = False
            btnNext.Visible = False

            pnlBank_OR_CheckDetail.Visible = True
            pnlBankTransferDetail.Visible = True
            pnlBankNote.Visible = True
            btnBack.Visible = True
            btnActivate.Visible = True

            If lblError.Text = "" Then
                trMessage.Visible = False
                lblMessage.Text = ""
            End If
        ElseIf _step = Steps.FinishPanel Then
            pnlCompanyInformation.Visible = False
            pnlPaymentProcessor.Visible = False
            btnNext.Visible = False

            pnlBank_OR_CheckDetail.Visible = False
            pnlBankTransferDetail.Visible = False
            pnlBankNote.Visible = False
            btnBack.Visible = False
            btnActivate.Visible = False

            If lblError.Text = "" Then
                trMessage.Visible = False
                lblMessage.Text = ""
            End If
            pnlSuccess.Visible = True
        End If
    End Sub

    Private Sub ShowNextStep(ByVal Value As Boolean)
        btnNext.Visible = Value
        btnActivate.Visible = Not Value
        pnlIShopDomainInfo.Visible = Value
        ShowPaymentProcessor(Value)
    End Sub

    Private Sub ShowPaymentProcessor(ByVal Value As Boolean)
        pnlPaymentProcessor.Visible = Value
    End Sub

    Private Sub WriteDebugInfo(ByVal sText As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            Dim dirPath As String = "d:\CustomerProcessing Trace\" & Session("UniquePath")
            If Not System.IO.Directory.Exists(dirPath) Then
                System.IO.Directory.CreateDirectory(dirPath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(dirPath & "\CompanyList.aspx.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub

    Private Function Page_IsValid() As Boolean
        Dim Valid As Boolean = True
        If rb2.Checked Then
            If txtCompanyName.Text.Trim.Length = 0 Then
                trMessage.Visible = True
                lblError.Text = "<li>New Company name can't be empty"
                Valid = False
            Else
                trMessage.Visible = False
            End If
        Else
            If lstCompanyName.SelectedIndex = -1 Then
                trMessage.Visible = True
                Dim Message As String = "<li>Please Select a Company Name"
                lblError.Text = Message
                WriteDebugInfo("Please Select a Company Name")
                Valid = False
            Else
                trMessage.Visible = False
            End If
        End If

        If _GeneralInfo.IsInfinishopCustomer Then
            If rbRegDomainInfo.Checked Then
                If Not Validated_RegMyDomain() Then
                    Valid = False
                Else
                    If Not IsDomainNameAvailable_RegDomain() Then Valid = False
                End If
            Else
                If Not Validated_AlreadyHaveDomain() Then Valid = False
            End If

            'Validated Payment Processor
            Trace.Warn("_PaymentProcessorInfo.ID_Required=" & _PaymentProcessorInfo.ID_Required)
            If _PaymentProcessorInfo.ID_Required Then
                If txtPaymentProcessorID.Text = "" Then
                    trMessage.Visible = True
                    Valid = False
                    lblError.Text &= "<li>" & _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.ID_Label.ToLower & " can't be empty"
                Else
                    Trace.Warn("_PaymentProcessorInfo.ID_RegEx=" & _PaymentProcessorInfo.ID_RegEx)
                    If Not InfiniLogic.AccountsCentre.BLL.Validation.Validate(txtPaymentProcessorID.Text, _PaymentProcessorInfo.ID_RegEx) Then
                        trMessage.Visible = True
                        Valid = False
                        lblError.Text &= "<li>Invalid Format [" & _PaymentProcessorInfo.AccountName & "  " & _PaymentProcessorInfo.ID_Label & "]"
                    Else
                        trMessage.Visible = False
                    End If
                End If
            End If

            If _PaymentProcessorInfo.Password_Required Then
                If txtPaymentProcessorPassword.Text = "" Then
                    trMessage.Visible = True
                    Valid = False
                    lblError.Text &= "<li>" & _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.Password_Label.ToLower & " can't be empty"
                Else
                    If Not InfiniLogic.AccountsCentre.BLL.Validation.Validate(txtPaymentProcessorPassword.Text, _PaymentProcessorInfo.Password_RegEx) Then
                        trMessage.Visible = True
                        Valid = False
                        lblError.Text &= "<li>Invalid Format [" & _PaymentProcessorInfo.AccountName & "  " & _PaymentProcessorInfo.Password_Label & "]"
                    Else
                        trMessage.Visible = False
                    End If
                End If
            End If

            If _PaymentProcessorInfo.Certificate_Required Then
                If txtPaymentProcessorCertificate.Text = "" Then
                    trMessage.Visible = True
                    Valid = False
                    lblError.Text &= "<li>" & _PaymentProcessorInfo.AccountName & " " & _PaymentProcessorInfo.Certificate_Label.ToLower & " can't be empty"
                Else
                    If Not InfiniLogic.AccountsCentre.BLL.Validation.Validate(txtPaymentProcessorCertificate.Text, _PaymentProcessorInfo.Certificate_RegEx) Then
                        trMessage.Visible = True
                        Valid = False
                        lblError.Text &= "<li>Invalid Format [" & _PaymentProcessorInfo.AccountName & "  " & _PaymentProcessorInfo.Certificate_Label & "]"
                    Else
                        trMessage.Visible = False
                    End If
                End If
            End If
        End If

        If Not Valid Then trMessage.Visible = True

        Return Valid
    End Function

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click
        If Not Page_IsValid() Then Exit Sub
        If lblError.Text = "" Then
            trMessage.Visible = False
            lblMessage.Text = ""
        End If

        Dim CompanyName As String = ""
        Dim DomainName As String = ""

        If rb2.Checked = False Then
            WriteDebugInfo("listCompany.SelectedItem.Value   = " & lstCompanyName.SelectedItem.Value)
            WriteDebugInfo("listCompany.SelectedItem.Text   = " & lstCompanyName.SelectedItem.Text)
            If lstCompanyName.SelectedItem.Text.Equals(lstCompanyName.SelectedItem.Value) Then
                _GeneralInfo.ChildCustomerID = -1 '_GeneralInfo.ParentCustomerID
            Else
                _GeneralInfo.ChildCustomerID = lstCompanyName.SelectedItem.Value
            End If
        Else
            _GeneralInfo.ChildCustomerID = -1 '_GeneralInfo.ParentCustomerID
        End If

        If _GeneralInfo.IsInfinishopCustomer Then
            If rbRegDomainInfo.Checked Then
                DomainName = txtRegDomainName.Text & "." & ddlExtention.SelectedItem.Text
            Else
                DomainName = txtAlreadyRegDomainName.Text
            End If
        ElseIf _GeneralInfo.IsAPIReseller Then
            DomainName = txtAPIResellerURL.Text

            Dim splitDomainName() As String = DomainName.Split(New Char() {"."})
            If splitDomainName.Length < 3 Then
                trMessage.Visible = True
                Dim Message As String = "<li>Please enter valid Domain Name"

                lblError.Text = Message
                WriteDebugInfo(Message)
                Exit Sub
            Else
                trMessage.Visible = False
                If DomainName.StartsWith("www.") Then
                    WriteDebugInfo("www. found!")
                    WriteDebugInfo("Old Domain Name = " & DomainName)
                    DomainName = DomainName.Substring(DomainName.IndexOf(".") + 1, DomainName.Length - DomainName.IndexOf(".") - 1)
                    WriteDebugInfo("New Domain Name = " & DomainName)
                End If
            End If
        End If

        Dim ProductName As String
        Dim ResellerUID As String = (New InfiniLogic.AccountsCentre.BLL.User).GetCustomerUID(_GeneralInfo.ResellerID)
        'ProductName = Infinilogic.AccountsCentre.BLL.User.GetProductName(_GeneralInfo.ProductCode)

        WriteDebugInfo("Calling GetProductName: ResellerUID=" & ResellerUID & " -- ProductCode=" & _GeneralInfo.ProductCode)
        ProductName = InfiniLogic.AccountsCentre.BLL.Reseller.GetProductName(ResellerUID, _GeneralInfo.ProductCode)
        WriteDebugInfo("GetProductName is ok: ProductName=" & ProductName)
        Dim msg As New System.Text.StringBuilder(lblwaitmsg.Text)
        msg.Replace("[SERVICENAME]", ProductName)
        lblwaitmsg.Text = msg.ToString()
        WriteDebugInfo("lblwaitmsg.Text =" & lblwaitmsg.Text)

        If rb2.Checked Then
            WriteDebugInfo("Company Name = " & txtCompanyName.Text)
            CompanyName = txtCompanyName.Text
        Else
            WriteDebugInfo("Company Name = " & lstCompanyName.SelectedItem.ToString())
            CompanyName = lstCompanyName.SelectedItem.ToString()
        End If

        '-----------Activate Company on Database-----------------Start
        Dim LogUniquePath As String = "d:\CustomerProcessing Trace\" & Session("UniquePath") & "\CompanyList.aspx.vb Trace.txt"
        Dim objProductActivation As New InfiniLogic.AccountsCentre.BLL.ProductActivation
        _GeneralInfo.ChildCustomerID = objProductActivation.Activate(Session(PageTemplate.Session_ResellerID), _GeneralInfo.ChildCustomerID, _GeneralInfo.ProductCode, _GeneralInfo.OrderNo, _GeneralInfo.SerialNo, _GeneralInfo.Language, CompanyName, _GeneralInfo.APIResellerCodeList, _GeneralInfo.ResellerProCodeList, LogUniquePath, _GeneralInfo.ParentCustomerID)
        '-----------Activate Company on Database-----------------End

        '-----------Add Service Track-----------Start
        Dim STrackID As Long
        WriteDebugInfo("Calling AddOrderTrack")
        BizAPI_Service.AddOrderTrack(Session(PageTemplate.Session_ResellerID), _GeneralInfo.OrderNo, _GeneralInfo.ChildCustomerID, _GeneralInfo.ProductCode, _GeneralInfo.SerialNo)
        WriteDebugInfo("AddOrderTrack ok!")
        '-----------Add Service Track-----------End

        Dim dsCustomerData As DataSet = (New InfiniLogic.AccountsCentre.BLL.User).GetCustomerData(_GeneralInfo.ParentCustomerID)
        Dim CustomerName As String = IIf(IsDBNull(dsCustomerData.Tables(0).Rows(0).Item("Name")), "", dsCustomerData.Tables(0).Rows(0).Item("Name"))
        Dim CustomerEmail As String = IIf(IsDBNull(dsCustomerData.Tables(0).Rows(0).Item("Email")), "", dsCustomerData.Tables(0).Rows(0).Item("Email"))

        If _GeneralInfo.IsInfinishopCustomer Then
            If rbRegDomainInfo.Checked Then
                Dim TestMerchantAccount As Boolean
                Dim TestCustomerAccount As Boolean

                WriteDebugInfo("Calling IsTestReseller(" & _GeneralInfo.ResellerID & ")")
                TestMerchantAccount = InfiniLogic.AccountsCentre.BLL.Merchant.IsTestReseller(_GeneralInfo.ResellerID)
                WriteDebugInfo("IsTestReseller is ok: TestMerchantAccount = " & TestMerchantAccount)

                WriteDebugInfo("Calling IsTestCustomer(" & _GeneralInfo.ParentCustomerID & ")")
                TestCustomerAccount = InfiniLogic.AccountsCentre.BLL.Merchant.IsTestCustomer(_GeneralInfo.ParentCustomerID)
                WriteDebugInfo("IsTestCustomer is ok: TestCustomerAccount = " & TestCustomerAccount)

                '----------------Call U_D Service-------------------Start
                Dim objUDService As New UD_Service(LogUniquePath)
                Dim Domain_ERRORCODE As String
                Dim Domain_ERRORDESC As String

                'Dim RegDomainMode As String = System.Configuration.ConfigurationSettings.AppSettings("RegDomainMode").ToString
                'WriteDebugInfo("RegDomainMode=" & RegDomainMode)
                If (Not TestMerchantAccount) AndAlso (Not TestCustomerAccount) Then
                    Dim LiveResult As New UD_Service.RegLiveDomainResult
                    WriteDebugInfo("Calling RegLiveDomain")
                    WriteDebugInfo("    DomainName=" & DomainName)
                    WriteDebugInfo("    CompanyName=" & CompanyName)
                    WriteDebugInfo("    ChildCustomerID=" & _GeneralInfo.ChildCustomerID)
                    WriteDebugInfo("    CustomerEmail=" & CustomerEmail)
                    LiveResult = objUDService.RegLiveDomain(DomainName, CompanyName, _GeneralInfo.ChildCustomerID, True, CustomerEmail)
                    WriteDebugInfo("RegLiveDomain is ok")
                    Domain_ERRORCODE = LiveResult.ERRORCODE
                    Domain_ERRORDESC = LiveResult.ERRORDESC
                Else
                    Dim TestResult As New UD_Service.RegTestDomainResult
                    WriteDebugInfo("Calling RegTestDomain")
                    WriteDebugInfo("    DomainName=" & DomainName)
                    WriteDebugInfo("    CompanyName=" & CompanyName)
                    WriteDebugInfo("    ChildCustomerID=" & _GeneralInfo.ChildCustomerID)
                    WriteDebugInfo("    CustomerEmail=" & CustomerEmail)
                    TestResult = objUDService.RegTestDomain(DomainName, CompanyName, _GeneralInfo.ChildCustomerID, True, CustomerEmail)
                    WriteDebugInfo("RegTestDomain is ok")
                    Domain_ERRORCODE = TestResult.ERRORCODE
                    Domain_ERRORDESC = "Test -- " & TestResult.ERRORDESC
                End If

                If Domain_ERRORCODE = "0" Then
                    Dim Pending As Integer
                    If (TestMerchantAccount AndAlso TestCustomerAccount) Then
                        Pending = 1
                    Else
                        Pending = 0
                    End If

                    WriteDebugInfo("Pending = " & Pending)
                    'Success
                    WriteDebugInfo("Success:")
                    WriteDebugInfo("Calling AddDomainInfo")
                    WriteDebugInfo("    ResellerID=" & _GeneralInfo.ResellerID)
                    WriteDebugInfo("    CustomerID=" & _GeneralInfo.ChildCustomerID)
                    WriteDebugInfo("    OrderID=" & _GeneralInfo.OrderNo)
                    WriteDebugInfo("    ProductCode=" & _GeneralInfo.ProductCode.ToUpper)
                    WriteDebugInfo("    DaemonAccepted=" & True)
                    WriteDebugInfo("    DaemonAcceptedTime=" & Now)
                    WriteDebugInfo("    DomainName=" & DomainName)
                    WriteDebugInfo("    CompanyName=" & CompanyName)
                    WriteDebugInfo("    DaemonMessage=" & Domain_ERRORCODE & "::" & Domain_ERRORDESC)
                    WriteDebugInfo("    Status=" & 0)
                    Dim objDomainInfo As New DomainInfo
                    objDomainInfo.AddDomainInfo(_GeneralInfo.ResellerID, _
                                                _GeneralInfo.ChildCustomerID, _
                                                _GeneralInfo.OrderNo, _
                                                _GeneralInfo.ProductCode.ToUpper, _
                                                True, _
                                                Now, _
                                                DomainName, _
                                                CompanyName, _
                                                Domain_ERRORCODE & "::" & Domain_ERRORDESC, _
                                                Pending)
                    'Pending = 0
                    WriteDebugInfo("AddDomainInfo is ok: ReturnValue = False")
                Else
                    'Error
                    Dim objDomainInfo As New DomainInfo
                    WriteDebugInfo("Error:")
                    WriteDebugInfo("Calling AddDomainInfo")
                    WriteDebugInfo("    ResellerID=" & _GeneralInfo.ResellerID)
                    WriteDebugInfo("    CustomerID=" & _GeneralInfo.ChildCustomerID)
                    WriteDebugInfo("    OrderID=" & _GeneralInfo.OrderNo)
                    WriteDebugInfo("    ProductCode=" & _GeneralInfo.ProductCode.ToUpper)
                    WriteDebugInfo("    DaemonAccepted=" & False)
                    WriteDebugInfo("    DaemonAcceptedTime=" & Now)
                    WriteDebugInfo("    DomainName=" & DomainName)
                    WriteDebugInfo("    CompanyName=" & CompanyName)
                    WriteDebugInfo("    DaemonMessage=" & Domain_ERRORCODE & "::" & Domain_ERRORDESC)
                    WriteDebugInfo("    Status=" & -1)
                    objDomainInfo.AddDomainInfo(_GeneralInfo.ResellerID, _
                                                _GeneralInfo.ChildCustomerID, _
                                                _GeneralInfo.OrderNo, _
                                                _GeneralInfo.ProductCode.ToUpper, _
                                                False, _
                                                Now, _
                                                DomainName, _
                                                CompanyName, _
                                                Domain_ERRORCODE & "::" & Domain_ERRORDESC, _
                                                -1) 'Error
                    WriteDebugInfo("AddDomainInfo is ok: ReturnValue = False")
                End If
                '----------------Call U_D Service-------------------End

            End If

            Dim dName As String
            If rbAlreadyRegDomainName.Checked Then
                dName = DomainName
            Else
                dName = "www." & DomainName
            End If

            '-------------Insert Data In Merchant Table----------------Start
            Dim IPAddress As String = System.Configuration.ConfigurationSettings.AppSettings("IPAddress")
            Dim ServerPort As String = System.Configuration.ConfigurationSettings.AppSettings("ServerPort")
            Dim TemplateID As String = System.Configuration.ConfigurationSettings.AppSettings("DefaultTemplateID")

            WriteDebugInfo("Calling AddMerchantForInfiniShops:")
            WriteDebugInfo("    ipAddress=" & IPAddress)
            WriteDebugInfo("    serverPort=" & ServerPort)
            WriteDebugInfo("    templateID=" & TemplateID)
            InfiniLogic.AccountsCentre.BLL.Merchant.AddMerchantForInfiniShops(_GeneralInfo.ChildCustomerID, dName, TemplateID, IPAddress, ServerPort)
            WriteDebugInfo("AddMerchantForInfiniShops is ok")
            '-------------Insert Data In Merchant Table----------------End

            '--------------Insert PaymentProcessor-------------------Start
            Dim PaymentProcessorID As String = txtPaymentProcessorID.Text
            Dim PaymentProcessorPassword As String = txtPaymentProcessorPassword.Text
            Dim PaymentProcessorCertificate As String = txtPaymentProcessorCertificate.Text
            Dim PaymentProcessorCurrencyCode As String = "-1"
            Dim i As Integer = ddlPaymentProcessorCurrency.SelectedIndex
            If i <> -1 Then
                PaymentProcessorCurrencyCode = ddlPaymentProcessorCurrency.SelectedItem.Value
            End If

            WriteDebugInfo("Calling AddPaymentProcessor")
            WriteDebugInfo("MerchantID= " & _GeneralInfo.ChildCustomerID)
            WriteDebugInfo("PaymentProcessorID.Length= " & PaymentProcessorID.Length)
            WriteDebugInfo("PaymentProcessorPassword.Length= " & PaymentProcessorPassword.Length)
            WriteDebugInfo("PaymentProcessorCertificate.Length= " & PaymentProcessorCertificate.Length)
            WriteDebugInfo("PaymentProcessorCurrencyCode = " & PaymentProcessorCurrencyCode)

            Dim Success As Boolean = False
            Try
                Success = InfiniLogic.AccountsCentre.BLL.Merchant.AddPaymentProcessor(_GeneralInfo.ChildCustomerID, _
                                                                            _PaymentProcessorInfo, _
                                                                            PaymentProcessorID, _
                                                                            PaymentProcessorPassword, _
                                                                            PaymentProcessorCertificate, _
                                                                            PaymentProcessorCurrencyCode)
            Catch ex As Exception
                WriteDebugInfo("EXCEPTION")
                WriteDebugInfo("Message= " & ex.Message)
                WriteDebugInfo("StackTrace= " & ex.StackTrace)
            End Try
            WriteDebugInfo("AddPaymentProcessor is ok: Success= " & Success)
            '--------------Insert PaymentProcessor-------------------End

            '--------------Update Bank Detail--------------Start
            Dim ChequePayTo As String, _
                ChequeAddress As String, _
                BankName As String, _
                BankAddress As String, _
                BankAccountName As String, _
                BankAccountNumber As String, _
                BankSortCode As String, _
                BIC As String, _
                IBANNum As String, _
                SwiftCode As String

            ChequePayTo = txtChequePayableTo.Text
            ChequeAddress = txtChequeAddress.Text
            BankName = txtBankName.Text
            BankAddress = txtBankAddress.Text
            BankAccountName = txtBankAccountName.Text
            BankAccountNumber = txtBankAccountNumber.Text
            BankSortCode = txtBankSortCode.Text
            BIC = txtBIC.Text
            IBANNum = txtIBANNo.Text
            SwiftCode = txtSwiftCode.Text

            WriteDebugInfo("Calling UpdateBankDetail")
            InfiniLogic.AccountsCentre.BLL.Merchant.UpdateBankDetail(_GeneralInfo.ChildCustomerID, _
                            ChequePayTo, _
                            ChequeAddress, _
                            BankName, _
                            BankAddress, _
                            BankAccountName, _
                            BankAccountNumber, _
                            BankSortCode, _
                            BIC, _
                            IBANNum, _
                            SwiftCode)
            WriteDebugInfo("UpdateBankDetail is ok")
            '--------------Update Bank Detail--------------Start
        End If

        '---------------Inserting BizAPI Credential---------------Start
        'If IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.APIResellerCodeList) OrElse IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.ResellerProCodeList) Then
        If _GeneralInfo.IsResellerPackageAvailable Then
            InfiniLogic.AccountsCentre.BLL.Reseller.InsertBizAPICredential(Session(PageTemplate.Session_ParentUID), _GeneralInfo.ChildCustomerID)
        End If
        '---------------Inserting BizAPI Credential---------------End

        '---------------Calling Reseller Service---------------Start
        If _GeneralInfo.IsResellerPackageAvailable Then
            Dim DBID As String
            If Not _GeneralInfo.IsAPIReseller Then
                WriteDebugInfo("Calling GetResellerCurrencyDBID: ProductCode=" & _GeneralInfo.ProductCode)
                DBID = InfiniLogic.AccountsCentre.BLL.Reseller.GetResellerCurrencyDBID(_GeneralInfo.ProductCode)
                WriteDebugInfo("GetResellerCurrencyDBID is ok: DBID=" & DBID)
            Else
                DBID = ddlCurrencyDB.SelectedItem.Value
            End If
            Dim SendEmail As Boolean = IIf(ddlemail.SelectedItem.Value = 1, True, False)

            Dim dName As String
            If rbAlreadyRegDomainName.Checked Then
                dName = DomainName
            Else
                dName = "www." & DomainName
            End If
            WriteDebugInfo("Calling CallResellerService:")
            WriteDebugInfo("    IsInfinishopCustomer=" & _GeneralInfo.IsInfinishopCustomer)
            WriteDebugInfo("    CurrencyDBID=" & DBID)
            WriteDebugInfo("    ResellerID=" & _GeneralInfo.ChildCustomerID)
            WriteDebugInfo("    ResellerURL=" & dName)
            WriteDebugInfo("    SendEmail=" & SendEmail)
            WriteDebugInfo("    GeneratorID =" & Session(PageTemplate.Session_ResellerID))
            InfiniLogic.AccountsCentre.BLL.Reseller.BuildResellerService(_GeneralInfo.IsInfinishopCustomer, DBID, _GeneralInfo.ChildCustomerID, dName, SendEmail, _GeneralInfo.ResellerID, _GeneralInfo.OrderNo)
            WriteDebugInfo("CallResellerService is ok")
        End If
        '---------------Calling Reseller Service---------------End

        '---------------Calling Build Website Service----------Start
        If Not _GeneralInfo.IsResellerPackageAvailable AndAlso _GeneralInfo.IsInfinishopCustomer Then
            'If Merchant.IsInfiniShopAvailable_Package(_GeneralInfo.ProductCode) Then
            'In merchant service SendEmail and CurrnecyDBID is using default values
            Dim CurrencyDBID As String = "1"
            Dim MerchantID As String = _GeneralInfo.ChildCustomerID
            Dim MerchantURL As String
            Dim GeneratorID As String = _GeneralInfo.ResellerID
            Dim SendEmail As Boolean = False
            _GeneralInfo.IsInfinishopCustomer = True

            Dim dName As String
            If rbAlreadyRegDomainName.Checked Then
                dName = DomainName
            Else
                dName = "www." & DomainName
            End If

            MerchantURL = dName

            Dim objBuildMerchantResult As InfiniLogic.AccountsCentre.BLL.Merchant.BuildMerchantResult
            WriteDebugInfo("Calling Merchant Service:")
            WriteDebugInfo("    IsInfinishopCustomer=" & _GeneralInfo.IsInfinishopCustomer)
            WriteDebugInfo("    CurrencyDBID=" & CurrencyDBID)
            WriteDebugInfo("    MerchantID =" & MerchantID)
            WriteDebugInfo("    MerchantURL =" & MerchantURL)
            WriteDebugInfo("    GeneratorID =" & GeneratorID)

            WriteDebugInfo("Merchant Service is ok")
            objBuildMerchantResult = InfiniLogic.AccountsCentre.BLL.Merchant.BuildMerchant(_GeneralInfo.IsInfinishopCustomer, CurrencyDBID, MerchantID, MerchantURL, GeneratorID, _GeneralInfo.OrderNo, SendEmail)
            WriteDebugInfo("objBuildMerchantResult.ERRORCODE=" & objBuildMerchantResult.ErrorCode)
            WriteDebugInfo("objBuildMerchantResult.ERRORDESC=" & objBuildMerchantResult.ErrorDesc)
        End If
        '---------------Calling Build Website Service----------End

        '---------------AddMerchant In InfiniOffice------------Start
        Dim objIOService As New InfiniLogic.AccountsCentre.BLL.InfiniOfficeService
        WriteDebugInfo("Calling CallIOServices: ChildID = " & _GeneralInfo.ChildCustomerID & " - OrderID=" & _GeneralInfo.OrderNo)
        objIOService.CallIOServices(_GeneralInfo.ChildCustomerID, _GeneralInfo.OrderNo)
        WriteDebugInfo("CallIOServices is ok")
        '---------------AddMerchant In InfiniOffice------------End

        '--------------------Send Email-----------------------Start
        Dim objEmailService As New BizAPI_EmailService.EmailService
        Dim EmailResult As String
        Dim ServiceInformation As String = ProductName
        If IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.APIResellerCodeList) Then
            WriteDebugInfo("Calling SendEmail_RAPI")
            EmailResult = objEmailService.SendEmail_RAPI(Session(PageTemplate.Session_ResellerID), CustomerEmail, "", "", CustomerName, ServiceInformation)     'API Reseller
            WriteDebugInfo("SendEmail_RAPI is ok: EmailResult  = " & EmailResult)
        ElseIf IsProductCodeAvailable(_GeneralInfo.ProductCode, _GeneralInfo.ResellerProCodeList) Then
            WriteDebugInfo("Calling SendEmail_RPAN")
            EmailResult = objEmailService.SendEmail_RPAN(Session(PageTemplate.Session_ResellerID), CustomerEmail, "", "", CustomerName, ServiceInformation)   'Reseller Pro/ Pro Plus
            WriteDebugInfo("SendEmail_RPAN is ok: EmailResult = " & EmailResult)
        End If
        '--------------------Send Email-----------------------End

        If _GeneralInfo.IsResellerPackageAvailable Then
            btnGotoResellerSystem.Visible = True
            btnStartAC.Visible = False
        End If

        SetSteps(Steps.FinishPanel)
        Clear_Session()

        'Response.Write("<script>_HideBar();</script>")
    End Sub

    Enum Steps
        FirstPanel
        SecondPanel
        FinishPanel
    End Enum

    Private Sub ddlPaymentProcessBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentProcessBy.SelectedIndexChanged
        Dim PaymentProcessorID = ddlPaymentProcessBy.SelectedItem.Value
        LoadPaymentProcessorInfo(PaymentProcessorID)
    End Sub

    Private Sub btnStartAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartAC.Click
        Response.Redirect("../globalview/globalview.aspx")
    End Sub

    Private Sub btnMyAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyAccount.Click
        'Response.Redirect("https://services.infinibiz.com/account/index.php")
        Response.Redirect("https://services.infinibiz.com/account/index.php?ACTION=MAIN&sid=" & Session(PageTemplate.Session_ServiceID)) ' Redirect to Home page.
    End Sub

    Private Sub btnGotoResellerSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGotoResellerSystem.Click
        Dim objService As New ResellerAutoLogin.ResellerServices
        Dim objInfo As New ResellerAutoLogin.LoginInfo
        Dim objResult As ResellerAutoLogin.AutoLoginResult
        objInfo.customeruid = Session(PageTemplate.Session_ParentUID)
        objInfo.password = Session(PageTemplate.Session_ParentPassword)
        objInfo.serviceid = Session(PageTemplate.Session_ServiceID)
        objResult = objService.autoLogin(objInfo)

        If objResult.ERRORCODE = "0" Then
            Response.Redirect(objResult.link)
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        SetSteps(Steps.FirstPanel)
    End Sub

    'Private Sub btnCheckAvailability_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not Validated_RegMyDomain() Then Exit Sub
    '    IsDomainNameAvailable_RegDomain()
    'End Sub

    Private Function Validated_AlreadyHaveDomain() As Boolean
        Dim Valid As Boolean = True
        Dim DomainName As String = txtAlreadyRegDomainName.Text

        If DomainName = "" Then
            trMessage.Visible = True
            lblError.Text &= "<li>Domain Name can't be empty"
            Valid = False
        Else
            If Valid Then trMessage.Visible = False
        End If

        'If DomainName.StartsWith("www.") AndAlso Valid Then
        '    trMessage.Visible = True
        '    lblError.Text &= "<li>Please Remove ""www."" in Domain Name"
        '    Valid = False
        'Else
        '    If Valid Then trMessage.Visible = False
        'End If

        Dim arr() As String = DomainName.Split(New Char() {"."})
        If arr.Length <= 2 AndAlso Valid Then
            trMessage.Visible = True
            lblError.Text &= "<li>Please enter a valid domain name"
            Valid = False
        Else
            If Valid Then trMessage.Visible = False
        End If

        Return Valid
    End Function

    Private Function IsDomainNameAvailable_RegDomain() As Boolean
        Dim Valid As Boolean
        Dim DomainName As String = txtRegDomainName.Text & "." & ddlExtention.SelectedItem.Text
        trMessage.Visible = True
        If UD_Service.IsDomainAvailable(DomainName) Then
            Valid = True
            lblMessage.Text &= "<li>Congratulation, " & DomainName & " is available!"
        Else
            Valid = False
            lblError.Text &= "<li>Sorry, " & DomainName & " is not available!"
        End If
        Return Valid
    End Function

    Private Function Validated_RegMyDomain() As Boolean
        Dim Valid As Boolean = True
        Dim DomainName As String = txtRegDomainName.Text & "." & ddlExtention.SelectedItem.Text

        If txtRegDomainName.Text = "" Then
            trMessage.Visible = True
            lblError.Text &= "<li>Domain Name can't be empty"
            Valid = False
        Else
            If Valid Then trMessage.Visible = False
        End If

        If DomainName.StartsWith("www.") Then
            trMessage.Visible = True
            lblError.Text &= "<li>Please Remove ""www."" in Domain Name"
            Valid = False
        Else
            If Valid Then trMessage.Visible = False
        End If

        Return Valid
    End Function


    Private Sub rbRegDomainInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRegDomainInfo.CheckedChanged
        rbDomainNameHandler()
    End Sub

    Private Sub rbAlreadyRegDomainName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAlreadyRegDomainName.CheckedChanged
        rbDomainNameHandler()
    End Sub

    Private Sub rbDomainNameHandler()
        'Dim Value As Boolean = rbRegDomainInfo.Checked

        'txtRegDomainName.Enabled = Value
        'btnCheckAvailability.Enabled = Value
        'ddlExtention.Enabled = Value

        'txtAlreadyRegDomainName.Enabled = Not Value
    End Sub

    Private Sub btnCheckAvailability_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnCheckAvailability.Click
        If Not Validated_RegMyDomain() Then Exit Sub
        IsDomainNameAvailable_RegDomain()
    End Sub
End Class



