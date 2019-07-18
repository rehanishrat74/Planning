Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL
Imports Infinilogic.AccountsCentre.common
Imports System.Data.SqlClient

Public Class CompanyList
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlCompanyList As System.Web.UI.WebControls.Panel
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlSuccess As System.Web.UI.WebControls.Panel
    Protected WithEvents lblselectcompnany As System.Web.UI.WebControls.Label
    Protected WithEvents listCompany As System.Web.UI.WebControls.ListBox
    Protected WithEvents btnContinue As System.Web.UI.WebControls.Button
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblwaitmsg As System.Web.UI.WebControls.Label
    Protected WithEvents btnStartAC As System.Web.UI.WebControls.Button
    Protected WithEvents btnMyAccount As System.Web.UI.WebControls.Button
    Protected WithEvents lblCurrencyDB As System.Web.UI.WebControls.Label
    Protected WithEvents ddlCurrencyDB As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblURL As System.Web.UI.WebControls.Label
    Protected WithEvents pnlResellerQuestion As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents pnlMessage As System.Web.UI.WebControls.Panel
    Protected WithEvents lblemail As System.Web.UI.WebControls.Label
    Protected WithEvents ddlemail As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblwww As System.Web.UI.WebControls.Label
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trDomainInfo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtAPIResellerURL As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents trAPIResellerDomainInfo As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents txtCompanyName As System.Web.UI.WebControls.TextBox
    Protected WithEvents chkNewCompanyOption As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents btnGotoResellerSystem As System.Web.UI.WebControls.Button

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private dtCompanies As DataTable
    Private dvCompanies As DataView

    Protected Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sTime As String = Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Session("UniquiPath") = sTime
        Trace.Warn("testing")

        If Not Page.IsPostBack Then
            WriteDebugInfo("Calling PrepareMe")
            PrepareMe()
            WriteDebugInfo("PrepareMe is ok")
        End If

    End Sub

    Private Sub PrepareMe()
        Try
            pnlCompanyList.Visible = True
            pnlSuccess.Visible = False

            Dim parameter As String

            parameter = Request("detail")
            Dim objSecureQueryString As New SecureQueryString(parameter)
            parameter = objSecureQueryString.Item("detail")

            'parameter = Server.UrlDecode(parameter)
            WriteDebugInfo("parameter = " & parameter)

            Dim Detail() As String
            Dim arr(0) As Char
            arr(0) = "^"
            WriteDebugInfo("spliting")
            Detail = parameter.Split(arr)

            If Not Detail Is Nothing Then
                WriteDebugInfo("POSTED VALUES:")
                Dim ii As Integer
                For ii = 0 To Detail.Length - 1
                    WriteDebugInfo("    " & Detail(ii))
                Next
            End If

            Dim ResellerID As String = ""
            Dim CustomerID As Integer
            Dim ProductCode As String
            Dim OrderNo As Integer
            Dim SerialNo As Integer
            Dim Language As String

            ResellerID = Session(PageTemplate.Session_ResellerID)
            CustomerID = Detail(0)
            ProductCode = Detail(1)
            OrderNo = Detail(2)
            SerialNo = Detail(3)
            Language = Detail(4)

            Session("clResellerID") = ResellerID
            Session("clCustomerID") = CustomerID
            Session("clProductCode") = ProductCode
            Session("clOrderNo") = OrderNo
            Session("clSerialNo") = SerialNo
            Session("clLanguage") = Language

            Dim objGlobalView As New GlobalView
            Dim bRetFormationsHouseProblem As Boolean
            Dim GVCompanies As DataTable
            Dim UserUID As String

            UserUID = (New User).GetCustomerUID(CustomerID)
            WriteDebugInfo("UserUID=" & UserUID)

            WriteDebugInfo("Calling getAllCompanies")
            GVCompanies = objGlobalView.getAllCompanies(CustomerID, UserUID, bRetFormationsHouseProblem)
            WriteDebugInfo("done!")

            WriteDebugInfo("Calling getAllCompaniesByFH")
            dtCompanies = objGlobalView.getAllCompaniesByFH(CustomerID, GVCompanies, True)
            WriteDebugInfo("done!")

            Dim APIReseller As String = System.Configuration.ConfigurationSettings.AppSettings("APIResellerCodeList")
            Dim ResellerProCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCodeList")
            Dim InfinishopMerchatCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("InfinishopMerchatCodeList")

            WriteDebugInfo("APIReseller = " & APIReseller)
            WriteDebugInfo("ResellerProCodeList = " & ResellerProCodeList)
            WriteDebugInfo("InfinishopMerchatCodeList = " & InfinishopMerchatCodeList)
            'Dim ResellerPro As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCode")
            'Dim ResellerProPlus As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProPlusCode")
            'Dim InfiniCommerce360 As String = System.Configuration.ConfigurationSettings.AppSettings("InfiniCommerce360")
            'Dim InfiniCommerce365 As String = System.Configuration.ConfigurationSettings.AppSettings("InfiniCommerce365")

            Dim ResellerPackageAvailable As Boolean = False
            Dim IsInfinishopCustomer As Boolean
            If ProductCode = APIReseller Then
                IsInfinishopCustomer = False
                ResellerPackageAvailable = True

                trDomainInfo.Visible = False
                trAPIResellerDomainInfo.Visible = True
            ElseIf IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
                IsInfinishopCustomer = True
                ResellerPackageAvailable = True

                trDomainInfo.Visible = True
                trAPIResellerDomainInfo.Visible = False

                Dim QACompanyName As String = ""
                WriteDebugInfo("Calling GetCompanyName_OrderID: ResellerID=" & ResellerID & "-OrderID=" & OrderNo & "-ProductCode=" & ProductCode)
                QACompanyName = Infinilogic.AccountsCentre.BLL.ResellerCustomer.GetCompanyName_OrderID(Session(PageTemplate.Session_ResellerID), OrderNo, ProductCode)
                WriteDebugInfo("GetCompanyName_OrderID is ok: QACompanyName = " & QACompanyName)
                txtCompanyName.Text = QACompanyName
            End If

            Trace.Warn("ProductCode=" & ProductCode)
            If IsProductCodeAvailable(ProductCode, InfinishopMerchatCodeList) Then
                Dim QACompanyName As String = ""
                WriteDebugInfo("Calling GetCompanyName_OrderID: ResellerID=" & Session(PageTemplate.Session_ResellerID) & "-OrderID=" & OrderNo)
                QACompanyName = Infinilogic.AccountsCentre.BLL.ResellerCustomer.GetCompanyName_OrderID(Session(PageTemplate.Session_ResellerID), OrderNo, ProductCode)
                WriteDebugInfo("GetCompanyName_OrderID is ok: QACompanyName = " & QACompanyName)
                txtCompanyName.Text = QACompanyName
                Trace.Warn("QACompanyName=" & QACompanyName)
            End If


            If dtCompanies.Rows.Count = 0 Then
                listCompany.Items.Add("Your Company Name")
            Else
                listCompany.DataTextField = "CompName"
                listCompany.DataValueField = "MemberCustomerID"
                listCompany.DataSource = dtCompanies
                listCompany.DataBind()
            End If

            WriteDebugInfo("Calling DataBind()")
            DataBind()
            WriteDebugInfo("DataBind() is ok")

            WriteDebugInfo("Generating client side javascript click event")
            btnContinue.Attributes.Add("onclick", "wait();")
            WriteDebugInfo("done!")

            If ResellerPackageAvailable Then
                pnlResellerQuestion.Visible = True
                Dim ds As DataSet
                ds = Infinilogic.AccountsCentre.BLL.User.GetAllCurrencyDBDetail()
                ddlCurrencyDB.DataTextField = "Currency"
                ddlCurrencyDB.DataValueField = "DBID"
                ddlCurrencyDB.DataSource = ds
                ddlCurrencyDB.DataBind()
            End If

            WriteDebugInfo("CompanyList Page is loaded!")
        Catch ex As Exception
            WriteDebugInfo("EXCEPTION: ")
            WriteDebugInfo("    Message: " & ex.Message)
            WriteDebugInfo("    StackTrace: " & ex.StackTrace)
            Throw ex
        End Try
    End Sub


    Private Sub WriteDebugInfo(ByVal sText As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            Dim dirPath As String = "d:\CustomerProcessing Trace\" & Session("UniquiPath")
            If Not System.IO.Directory.Exists(dirPath) Then
                System.IO.Directory.CreateDirectory(dirPath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(dirPath & "\CompanyList.aspx.vb Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        WriteDebugInfo("Continue is pressed!!")

        If chkNewCompanyOption.Checked Then
            If txtCompanyName.Text.Trim.Length = 0 Then
                lblMessage.Text = "New Company name can't be empty"
                Exit Sub
            End If
        Else
            If listCompany.SelectedIndex = -1 Then
                pnlMessage.Visible = True
                Dim Message As String = "Please Select a Company Name"

                lblMessage.Text = Message
                WriteDebugInfo("select Company first!")
                Exit Sub
            End If
        End If

        Dim APIResellerCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("APIResellerCodeList")
        Dim ResellerProCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCodeList")
        Dim InfinishopMerchatCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("InfinishopMerchatCodeList")
        'Dim ResellerProCode As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCode")
        'Dim ResellerProPlusCode As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProPlusCode")
        'Dim InfiniCommerce360 As String = System.Configuration.ConfigurationSettings.AppSettings("InfiniCommerce360")
        'Dim InfiniCommerce365 As String = System.Configuration.ConfigurationSettings.AppSettings("InfiniCommerce365")

        Dim IsAPIReseller As Boolean = False

        Dim ResellerPackageAvailable As Boolean = False
        Dim IsInfinishopCustomer As Boolean

        Dim CustomerID As Integer
        Dim ProductCode As String
        Dim OrderNo As Integer
        Dim SerialNo As Integer
        Dim Language As String
        Dim CompanyName As String

        If chkNewCompanyOption.Checked = False Then
            WriteDebugInfo("listCompany.SelectedItem.Value   = " & listCompany.SelectedItem.Value)
            WriteDebugInfo("listCompany.SelectedItem.Text   = " & listCompany.SelectedItem.Text)
            If listCompany.SelectedItem.Text.Equals(listCompany.SelectedItem.Value) Then
                CustomerID = Session("clCustomerID")
            Else
                CustomerID = listCompany.SelectedItem.Value   'Session("clCustomerID")
            End If
        Else
            CustomerID = Session("clCustomerID")
        End If
        'CustomerID = listCompany.SelectedItem.Value   'Session("clCustomerID")
        ProductCode = Session("clProductCode")
        OrderNo = Session("clOrderNo")
        SerialNo = Session("clSerialNo")
        Language = Session("clLanguage")

        If ProductCode = APIResellerCodeList Then
            IsInfinishopCustomer = False
            ResellerPackageAvailable = True
            IsAPIReseller = True
        ElseIf IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
            IsInfinishopCustomer = True
            ResellerPackageAvailable = True
            IsAPIReseller = False
        End If

        Dim DomainName As String = ""
        Dim ResellerID As String
        ResellerID = Session("clResellerID")
        If ResellerPackageAvailable And Not IsAPIReseller Then
            Dim objResellerCustomer As New Infinilogic.AccountsCentre.BLL.ResellerCustomer
            WriteDebugInfo("Calling GetDomainName_OrderID: ResellerID=" & Session(PageTemplate.Session_ResellerID) & " - OrderID=" & OrderNo & " - ProductCode=" & ProductCode)
            DomainName = objResellerCustomer.GetDomainName_OrderID(Session(PageTemplate.Session_ResellerID), OrderNo, ProductCode)
            WriteDebugInfo("GetDomainName_OrderID is ok")
        Else
            DomainName = txtAPIResellerURL.Text
        End If

        '------------New Modification--------Start
        If IsAPIReseller Then
            Dim splitDomainName() As String = DomainName.Split(New Char() {"."})
            If splitDomainName.Length < 3 Then
                pnlMessage.Visible = True
                Dim Message As String = "Please enter valid Domain Name"

                lblMessage.Text = Message
                WriteDebugInfo(Message)
                Exit Sub
            Else
                If DomainName.StartsWith("www.") Then
                    WriteDebugInfo("www. found!")
                    WriteDebugInfo("Old Domain Name = " & DomainName)
                    DomainName = DomainName.Substring(DomainName.IndexOf(".") + 1, DomainName.Length - DomainName.IndexOf(".") - 1)
                    WriteDebugInfo("New Domain Name = " & DomainName)
                End If
            End If
        End If
        '------------New Modification--------End

        WriteDebugInfo("Replace SERVICENAME")
        '-------------Replace SERVICENAME -----------------
        'RSS_GetProductName
        Dim ProductName As String
        ProductName = Infinilogic.AccountsCentre.BLL.User.GetProductName(ProductCode)
        Dim msg As New System.Text.StringBuilder(lblwaitmsg.Text)
        msg.Replace("[SERVICENAME]", ProductName)
        lblwaitmsg.Text = msg.ToString()
        WriteDebugInfo("lblwaitmsg.Text =" & lblwaitmsg.Text)
        '------------------- done!-------------------------

        If chkNewCompanyOption.Checked Then
            WriteDebugInfo("Company Name = " & txtCompanyName.Text)
            CompanyName = txtCompanyName.Text
        Else
            WriteDebugInfo("Company Name = " & listCompany.SelectedItem.ToString())
            CompanyName = listCompany.SelectedItem.ToString()
        End If

        WriteDebugInfo("CompanyName.Length = " & CompanyName.Length)
        If CompanyName.Length = 0 Then CompanyName = "Default Company Name"

        Dim RESULT As activateResult
        RESULT = activate(CustomerID, ProductCode, OrderNo, SerialNo, Language, CompanyName)

        WriteDebugInfo("ERRORCODE=" & RESULT.ERRORCODE)

        pnlCompanyList.Visible = False
        pnlSuccess.Visible = True

        If ProductCode = APIResellerCodeList OrElse IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
            btnGotoResellerSystem.Visible = True
            btnStartAC.Visible = False
        End If

        If Not RESULT.ERRORCODE.ToString().Trim().Equals("0") Then
            WriteDebugInfo("Some Error occure ERRORCODE=" & RESULT.ERRORCODE.ToString())
            WriteDebugInfo("ERRORDESC=" & RESULT.ERRORDESC.ToString())
            Throw New Exception("Exception: " & RESULT.ERRORDESC)
        End If

        '---------------Inserting BizAPI Credential---------------Start
        Dim Credential_ResellerID As String = ""
        Dim Credential_Password As String = ""
        Credential_ResellerID = RESULT.NewCustomerID
        Credential_Password = ""
        If ProductCode = APIResellerCodeList OrElse IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
            'Credential_Password = GetPassword()
            Dim ParentID As String = (New Infinilogic.AccountsCentre.BLL.User).GetCustomerID(Session(PageTemplate.Session_ParentUID))
            WriteDebugInfo("Calling GetLivePassword: ParentID=" & ParentID)
            Credential_Password = GetLivePassword(ParentID)
            WriteDebugInfo("GetLivePassword is ok. Credential_Password.Length " & Credential_Password.Length)

            Dim Key As String = (New Infinilogic.AccountsCentre.BLL.User).GetLogKey(RESULT.NewCustomerID)
            Dim objCryptography As New Infinilogic.AccountsCentre.common.Cryptography

            Credential_Password = objCryptography.EnCrypt(Credential_Password, Key)
            WriteDebugInfo("Calling InsertBizAPICredential: APIReseller")
            Infinilogic.AccountsCentre.BLL.ResellerCustomer.InsertBizAPICredential(Credential_ResellerID, Credential_Password)
            WriteDebugInfo("InsertBizAPICredential is ok")
        End If
        '---------------Inserting BizAPI Credential---------------End

        '---------------Calling Reseller Service---------------Start
        If ResellerPackageAvailable Then
            Dim DBID As String = ddlCurrencyDB.SelectedItem.Value
            Dim SendEmail As Boolean = IIf(ddlemail.SelectedItem.Value = 1, True, False)

            DomainName = "www." & DomainName
            WriteDebugInfo("Calling CallResellerService:")
            WriteDebugInfo("    IsInfinishopCustomer=" & IsInfinishopCustomer)
            WriteDebugInfo("    CurrencyDBID=" & DBID)
            WriteDebugInfo("    ResellerID=" & RESULT.NewCustomerID)
            WriteDebugInfo("    ResellerURL=" & DomainName)
            WriteDebugInfo("    SendEmail=" & SendEmail)
            WriteDebugInfo("    GeneratorID =" & Session(PageTemplate.Session_ResellerID))

            'CallResellerService(IsInfinishopCustomer, DBID, RESULT.NewCustomerID, DomainName, SendEmail, Session(PageTemplate.Session_ResellerID), OrderNo)
            ExecuteThread(IsInfinishopCustomer, DBID, RESULT.NewCustomerID, DomainName, SendEmail, Session(PageTemplate.Session_ResellerID), OrderNo)

            WriteDebugInfo("CallResellerService is ok")

            'give 4 sec so web builder process can be completed
            Threading.Thread.Sleep(4000)
        End If
        '---------------Calling Reseller Service---------------End

        '---------------Calling Build Website Service----------Start
        If IsProductCodeAvailable(ProductCode, InfinishopMerchatCodeList) Then
            'In merchant service SendEmail and CurrnecyDBID is using default values
            Dim CurrencyDBID As String = "1"
            Dim MerchantID As String = RESULT.NewCustomerID
            Dim MerchantURL As String
            Dim GeneratorID As String = Session(PageTemplate.Session_ResellerID)
            Dim SendEmail As Boolean = False
            IsInfinishopCustomer = True

            Dim objResellerCustomer As New Infinilogic.AccountsCentre.BLL.ResellerCustomer
            WriteDebugInfo("Calling GetDomainName_OrderID: ResellerID=" & Session(PageTemplate.Session_ResellerID) & " - OrderID=" & OrderNo & " - ProductCode=" & ProductCode)
            MerchantURL = objResellerCustomer.GetDomainName_OrderID(Session(PageTemplate.Session_ResellerID), OrderNo, ProductCode)
            WriteDebugInfo("GetDomainName_OrderID is ok")

            MerchantURL = "www." & MerchantURL

            Dim objMerchantService As New com.reseller.webservices.ResellerService
            Dim objResellerInfo As New com.reseller.webservices.resellerinfo
            Dim objBuildResellerResult As com.reseller.webservices.buildresellerresult
            objResellerInfo.currencydbid = CurrencyDBID
            objResellerInfo.generatorid = GeneratorID
            objResellerInfo.isinfinishopcustomer = IsInfinishopCustomer
            objResellerInfo.orderid = OrderNo
            objResellerInfo.resellerid = MerchantID
            objResellerInfo.resellerurl = MerchantURL
            objResellerInfo.sendemail = sendemail

            WriteDebugInfo("Calling Merchant Service:")
            WriteDebugInfo("    IsInfinishopCustomer=" & IsInfinishopCustomer)
            WriteDebugInfo("    CurrencyDBID=" & CurrencyDBID)
            WriteDebugInfo("    MerchantID =" & MerchantID)
            WriteDebugInfo("    MerchantURL =" & MerchantURL)
            WriteDebugInfo("    GeneratorID =" & GeneratorID)
            objBuildResellerResult = objMerchantService.CreateWebsiteForMerchant(objResellerInfo)
            WriteDebugInfo("Merchant Service is ok")

            WriteDebugInfo("objBuildResellerResult.ERRORCODE=" & objBuildResellerResult.ERRORCODE)
            WriteDebugInfo("objBuildResellerResult.ERRORDESC=" & objBuildResellerResult.ERRORDESC)
        End If
        '---------------Calling Build Website Service----------End

        '---------------AddMerchant In InfiniOffice------------Start
        Dim objIOService As New Infinilogic.AccountsCentre.BLL.InfiniOfficeService
        WriteDebugInfo("Calling CallIOServices: ChildID=" & RESULT.NewCustomerID & " - OrderID=" & OrderNo)
        objIOService.CallIOServices(RESULT.NewCustomerID, OrderNo)
        WriteDebugInfo("CallIOServices is ok")
        '---------------AddMerchant In InfiniOffice------------End

        '--------------------Send Email-----------------------Start
        Dim objEmailService As New BizAPI_EmailService.EmailService
        Dim ds As DataSet = (New Infinilogic.AccountsCentre.BLL.User).GetCustomerData(RESULT.NewCustomerID)
        Dim CustomerName As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Name")), "", ds.Tables(0).Rows(0).Item("Name"))
        Dim CustomerEmail As String = IIf(IsDBNull(ds.Tables(0).Rows(0).Item("Email")), "", ds.Tables(0).Rows(0).Item("Email"))


        Dim EmailResult As String
        Dim ServiceInformation As String = ProductName
        If ProductCode = APIResellerCodeList Then
            WriteDebugInfo("Calling SendEmail_RAPI")
            EmailResult = objEmailService.SendEmail_RAPI(Session(PageTemplate.Session_ResellerID), CustomerEmail, "", "", CustomerName, ServiceInformation)     'API Reseller
            WriteDebugInfo("SendEmail_RAPI is ok: EmailResult  = " & EmailResult)
        ElseIf IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
            WriteDebugInfo("Calling SendEmail_RPAN")
            EmailResult = objEmailService.SendEmail_RPAN(Session(PageTemplate.Session_ResellerID), CustomerEmail, "", "", CustomerName, ServiceInformation)   'Reseller Pro/ Pro Plus
            WriteDebugInfo("SendEmail_RPAN is ok: EmailResult = " & EmailResult)
        End If
        '--------------------Send Email-----------------------End

        pnlMessage.Visible = False
    End Sub

    '<MTAThread()> _
    Private Sub ExecuteThread(ByVal IsInfiniShopCustomer As Boolean, _
                                ByVal CurrencyDBID As String, _
                                ByVal ResellerID As String, _
                                ByVal ResellerURL As String, _
                                ByVal SendEmail As Boolean, _
                                ByVal GeneratorID As String, _
                                ByVal OrderID As String)
        Dim objResellerService As New ResellerService
        objResellerService.CurrencyDBID = CurrencyDBID
        objResellerService.GeneratorID = GeneratorID
        objResellerService.IsInfiniShopCustomer = IsInfiniShopCustomer
        objResellerService.OrderID = OrderID
        objResellerService.ResellerID = ResellerID
        objResellerService.ResellerURL = ResellerURL
        objResellerService.SendEmail = SendEmail

        WriteDebugInfo("Calling RunService()")
        objResellerService.RunService()
        WriteDebugInfo("RunService is ok")
        'Dim tResellerService As New System.Threading.Thread(AddressOf objResellerService.RunService)
        'WriteDebugInfo("Calling tResellerService.Start()")
        'tResellerService.Start()
        'WriteDebugInfo("tResellerService.Start() is ok")
    End Sub

    Private Class ResellerService
        Public IsInfiniShopCustomer As Boolean
        Public CurrencyDBID As String
        Public ResellerID As String
        Public ResellerURL As String
        Public SendEmail As String
        Public GeneratorID As String
        Public OrderID As String

        Public Sub RunService()
            CallResellerService(IsInfiniShopCustomer, CurrencyDBID, ResellerID, ResellerURL, SendEmail, GeneratorID, OrderID)
        End Sub

        Private Sub CallResellerService(ByVal IsInfiniShopCustomer As Boolean, _
                                            ByVal CurrencyDBID As String, _
                                            ByVal ResellerID As String, _
                                            ByVal ResellerURL As String, _
                                            ByVal SendEmail As Boolean, _
                                            ByVal GeneratorID As String, _
                                            ByVal OrderID As String)
            Dim sTime As String = Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
            Dim dirPath As String = "d:\CustomerProcessing Trace\RS\" & sTime

            Try
                Dim ResellerService As New com.reseller.webservices.ResellerService
                Dim rinfo As New com.reseller.webservices.resellerinfo
                Dim Result As com.reseller.webservices.buildresellerresult

                rinfo.isinfinishopcustomer = IsInfiniShopCustomer
                rinfo.currencydbid = CurrencyDBID
                rinfo.resellerid = ResellerID
                rinfo.resellerurl = ResellerURL
                rinfo.sendemail = SendEmail
                rinfo.generatorid = GeneratorID
                rinfo.orderid = OrderID

                ResellerService.Timeout = 1200000 ' 20 min
                WriteThreadLog("Calling buildreseller", dirPath)
                WriteThreadLog("    IsInfiniShopCustomer = " & IsInfiniShopCustomer, dirPath)
                WriteThreadLog("    ResellerID = " & ResellerID, dirPath)
                WriteThreadLog("    ResellerURL = " & ResellerURL, dirPath)
                WriteThreadLog("    SendEmail = " & SendEmail, dirPath)
                WriteThreadLog("    GeneratorID = " & GeneratorID, dirPath)
                WriteThreadLog("    OrderID = " & OrderID, dirPath)
                Result = ResellerService.buildreseller(rinfo)
                WriteThreadLog("buildreseller is ok", dirPath)
                WriteThreadLog("Result.ERRORCODE " & Result.ERRORCODE, dirPath)
                WriteThreadLog("Result.ERRORDESC " & Result.ERRORDESC, dirPath)
            Catch ex As Exception
                WriteThreadLog("EXCEPTION", dirPath)
                WriteThreadLog("Message: " & ex.Message, dirPath)
                WriteThreadLog("StackTrace: " & ex.StackTrace, dirPath)
            End Try
        End Sub

        Private Sub WriteThreadLog(ByVal sText As String, ByVal LogPath As String)

            Dim dirPath As String = LogPath
            If Not System.IO.Directory.Exists(dirPath) Then
                System.IO.Directory.CreateDirectory(dirPath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(dirPath & "\ResellerBuilder Trace.txt")
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()

        End Sub
    End Class

    'Private Sub RegisterDomain(ByVal DomainName As String, ByVal CompanyName As String, ByVal CustomerID As String)
    '    WriteDebugInfo("In RegisterDomain:")
    '    WriteDebugInfo("    DomainName=" & DomainName)
    '    WriteDebugInfo("    CompanyName=" & CompanyName)
    '    WriteDebugInfo("    CustomerID=" & CustomerID)

    '    Dim DomainRegistrationMode As String = System.Configuration.ConfigurationSettings.AppSettings("DomainRegistrationMode")
    '    WriteDebugInfo("DomainRegistrationMode = " & DomainRegistrationMode)

    '    If DomainRegistrationMode.ToUpper.Equals("LIVE") Then
    '        Dim CustomerName As String
    '        Dim EmailAddress As String

    '        Dim objUser As New Infinilogic.AccountsCentre.BLL.User
    '        Dim ds As DataSet = objUser.GetCustomerData(CustomerID)

    '        CustomerName = ds.Tables(0).Rows(0).Item("ContactName")
    '        EmailAddress = ds.Tables(0).Rows(0).Item("Email")

    '        Dim Service As com.u_d.webservices.UniversalDomainServices
    '        Dim memberinfo As New com.u_d.webservices.MemberInfo
    '        Dim Result As com.u_d.webservices.ReturnMsg
    '        Const RefererID As String = "1009"

    '        memberinfo.companyname = CompanyName
    '        memberinfo.email = EmailAddress
    '        memberinfo.isocode = "GB"
    '        memberinfo.name = CustomerName
    '        memberinfo.password = ""

    '        WriteDebugInfo("DomainName = " & DomainName)
    '        WriteDebugInfo("refererid = " & RefererID)
    '        WriteDebugInfo("CompanyName = " & CompanyName)
    '        WriteDebugInfo("CustomerID = " & CustomerID)
    '        WriteDebugInfo("CompanyNumber = ")
    '        WriteDebugInfo("Hosting = " & 0)

    '        WriteDebugInfo("memberinfo.companyname = " & memberinfo.companyname)
    '        WriteDebugInfo("memberinfo.email = " & memberinfo.email)
    '        WriteDebugInfo("memberinfo.isocode = " & memberinfo.isocode)
    '        WriteDebugInfo("memberinfo.name = " & memberinfo.name)
    '        WriteDebugInfo("memberinfo.password = " & memberinfo.password)

    '        WriteDebugInfo("Calling regDomain")
    '        Result = Service.regDomain(DomainName, RefererID, CompanyName, CustomerID, "", "0", memberinfo)
    '        WriteDebugInfo("regDomain is ok: Result.ERRORCODE=" & Result.ERRORCODE.ToString)

    '        'if ErrorCode is not 'zero' it means that service doesnot run successfully
    '        If Result.ERRORCODE.ToString <> "0" Then
    '            'if service fail than save all parameters of regDomain 
    '            'to database, so next time it can be called...
    '            Dim serviceParameter As New System.Text.StringBuilder
    '            serviceParameter.Append("domainname=" & DomainName & "::")
    '            serviceParameter.Append("refererid=" & RefererID & "::")
    '            serviceParameter.Append("companyname=" & CompanyName & "::")
    '            serviceParameter.Append("customerid=" & CustomerID & "::")
    '            serviceParameter.Append("companunumber=" & "" & "::")
    '            serviceParameter.Append("hosting=" & 0 & "::")
    '            serviceParameter.Append("memberinfo.companyname" & memberinfo.companyname & "::")
    '            serviceParameter.Append("memberinfo.email" & memberinfo.email & "::")
    '            serviceParameter.Append("memberinfo.isocode" & memberinfo.isocode & "::")
    '            serviceParameter.Append("memberinfo.name" & memberinfo.name & "::")
    '            serviceParameter.Append("memberinfo.password" & memberinfo.password)

    '            Infinilogic.AccountsCentre.BLL.User.AddWebServiceLog("accounts.infinibiz.com/member/companylist.aspx", _
    '            "RegisterDomain", _
    '            "http://webservices.u-d.com/domain.php", _
    '            "regDomain", _
    '            serviceParameter.ToString, _
    '            Result.ERRORCODE.ToString, _
    '            Result.ERRORDESC.ToString)
    '        End If
    '    End If
    '    WriteDebugInfo("RegisterDomain End")
    'End Sub


    Private Sub btnMyAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMyAccount.Click
        WriteDebugInfo("Response.Redirect(""https://services.infinibiz.com/account/index.php"")")
        Response.Redirect("https://services.infinibiz.com/account/index.php")
    End Sub

    Private Sub btnStartAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartAC.Click
        'WriteDebugInfo("Response.Redirect(""../globalview/GlobalView.aspx"")")
        Response.Redirect("../globalview/globalview.aspx")
    End Sub

    Public Function activate(ByVal CustomerID As Integer _
                                        , ByVal ProductCode As String _
                                        , ByVal OrderNo As Integer _
                                        , ByVal SerialNo As Integer _
                                        , ByVal Language As String _
                                        , ByVal CompanyName As String) As activateResult
        Dim logUniquePath As String = "d:\CustomerProcessing Trace\" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Dim FileName As String = "activate.txt"

        Try
            WriteDebugInfo("CustomerID=" & CustomerID)
            WriteDebugInfo("ProductCode=" & ProductCode)
            WriteDebugInfo("OrderNo=" & OrderNo)
            WriteDebugInfo("SerialNo=" & SerialNo)
            WriteDebugInfo("Language=" & Language)
            WriteDebugInfo("CompanyName=" & CompanyName)
            '------------------------Validation of Input parameter------------------------
            Dim valid As New Validation
            Dim ErrCode As Integer
            WriteDebugInfo("Validate Calling")
            ErrCode = valid.Validate(CustomerID, ProductCode, OrderNo, SerialNo, Language)
            WriteDebugInfo("Validate is ok with ErrCode=" & ErrCode)
            If ErrCode > 0 Then
                WriteDebugInfo(Now & " -- Input Parameters:")
                WriteDebugInfo(Now & " --     CustomerID=" & CustomerID)
                WriteDebugInfo(Now & " --     ProductCode=" & ProductCode)
                WriteDebugInfo(Now & " --     OrderNo=" & OrderNo)
                WriteDebugInfo(Now & " --     SerialNo=" & SerialNo)
                WriteDebugInfo(Now & " --     Language=" & Language)
                Return ErrCodeAndDescription(ErrCode)
            End If
            '------------------------------------done--------------------------------------

            Dim processor As New DataProcessor(logUniquePath)
            Dim NewCustomerID As Integer
            Dim Success As Boolean

            '-------------------------------------------------------------------------------
            Dim sCustomerAction As String = ""
            Dim oACRegBLL As New Administration.BLL.ACRegistrationBLL
            Dim dtACUByID As DataTable
            WriteDebugInfo("Calling GetACUserRecordByID")
            dtACUByID = oACRegBLL.GetACUserRecordByID(CustomerID)
            WriteDebugInfo("GetACUserRecordByID is ok")

            If (Not InfiniLogic.AccountsCentre.BLL.User.IsAvailableInACCustomerGrouping(CustomerID)) OrElse (dtACUByID Is Nothing OrElse Not (dtACUByID.Rows.Count > 0)) Then
                'Register New Customer and make it AccountsCentreUser
                Dim ParentPassword, ParentLogKey As String

                WriteDebugInfo("calling GetCustomerData")
                ParentPassword = (New User).GetCustomerData(CustomerID).Tables(0).Rows(0).Item("Cart_Customer_pass")
                WriteDebugInfo("GetCustomerData is ok")
                ParentLogKey = (New User).GetLogKey(CustomerID)

                Dim objCrypt As New Cryptography
                ParentPassword = objCrypt.DeCrypt(ParentPassword, ParentLogKey)

                WriteDebugInfo("CreateSubCustomer is calling")
                NewCustomerID = processor.CreateSubCustomer(CustomerID, ParentPassword)
                WriteDebugInfo("CreateSubCustomer is ok and NewCustomerID=" & NewCustomerID)

                WriteDebugInfo("Calling AddAccountsCentreUser")
                InfiniLogic.AccountsCentre.BLL.User.AddAccountsCentreUser(NewCustomerID, CompanyName)
                WriteDebugInfo("AddAccountsCentreUser is ok")

                Try
                    WriteDebugInfo("Calling AddAccountsCentreGrouping")
                    InfiniLogic.AccountsCentre.BLL.User.AddAccountsCentreGrouping(CustomerID, NewCustomerID)
                    WriteDebugInfo("AddAccountsCentreGrouping is ok")
                Catch ex As Exception
                    WriteDebugInfo("EXCEPTION::")
                    WriteDebugInfo("    Message:: " & ex.Message)
                    WriteDebugInfo("    Source:: " & ex.Source)
                End Try

                WriteDebugInfo("Calling AddResellerCustomersDetail")
                InfiniLogic.AccountsCentre.BLL.User.AddResellerCustomersDetail(CustomerID, NewCustomerID)
                WriteDebugInfo("AddResellerCustomersDetail is ok")
            Else
                WriteDebugInfo("Found AccountsCentreUser or AccountsCentreCustomerGrouping Record!!")
                NewCustomerID = CustomerID
                CustomerID = InfiniLogic.AccountsCentre.BLL.User.GetParentID(NewCustomerID)
            End If
            '-------------------------------------------------------------------------------

            WriteDebugInfo("MapCustomerSelectedService is calling:")
            WriteDebugInfo("    ChildCustomerID=" & NewCustomerID)
            WriteDebugInfo("    ProductCode=" & ProductCode)
            WriteDebugInfo("    OrderNo=" & OrderNo)
            Success = processor.MapCustomerSelectedService(NewCustomerID, ProductCode, OrderNo)
            WriteDebugInfo("MapCustomerSelectedService is ok and return = " & Success)

            '--------------------------------Inform To FH----------------------------------
            WriteDebugInfo("Create IBZservices Object")
            Dim FHService As New FHResellerCustomer.IBZservices
            WriteDebugInfo("done!")
            WriteDebugInfo("Set Activation Info")

            '---------------Applying Format on OrderNo----------Start
            'Modified by:   M.Yousuf
            'Date:          Feb 22, 2007
            'Description:   OrderID can be duplicate so from now it will concatenate with
            '               reseller id and length of resellerid
            'Example:       112606       5295     06
            '               ------       ----     --
            '               ResellerID   OrderID  Len(ResellerID's Length)
            '
            '               Last two digits show the length of Resellerid
            '               which is: 112606
            '               remaining digits are orderid: 5295
            '----------------------------------------------------------
            Dim FH_OrderNo As String
            'Dim ResellerIDLength As String = IIf((Session(PageTemplate.Session_ResellerID).Length & "").Length = 1, "0" & Session(PageTemplate.Session_ResellerID).Length, Session(PageTemplate.Session_ResellerID).Length)
            'FH_OrderNo = Session(PageTemplate.Session_ResellerID) & OrderNo & ResellerIDLength
            FH_OrderNo = OrderNo
            '---------------Applying Format on OrderNo----------End

            WriteDebugInfo("CustomerID=" & CustomerID)
            WriteDebugInfo("OrderNo=" & OrderNo)
            WriteDebugInfo("FH_OrderNo=" & FH_OrderNo)
            WriteDebugInfo("NewCustomerID=" & NewCustomerID)
            WriteDebugInfo("CompanyName=" & CompanyName)

            Dim ActivationInfo As New FHResellerCustomer.activationinfo
            ActivationInfo.customerid = CustomerID
            ActivationInfo.orderno = FH_OrderNo
            ActivationInfo.entityid = NewCustomerID
            ActivationInfo.entityname = CompanyName

            Dim APIResellerCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("APIResellerCodeList")
            WriteDebugInfo("APIResellerCodeList = " & APIResellerCodeList)
            Dim ResellerProCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCodeList")
            WriteDebugInfo("ResellerProCodeList  = " & ResellerProCodeList)

            If IsProductCodeAvailable(ProductCode, ResellerProCodeList) Then
                'for resellerpro, resellerpro-plus referer is 1005
                ActivationInfo.referrer = "1005"
            ElseIf IsProductCodeAvailable(ProductCode, APIResellerCodeList) Then
                'for api reseller referer is 1012
                ActivationInfo.referrer = "1012"
            Else
                'for other acc products ... referer is 1009
                ActivationInfo.referrer = "1009"
            End If

            '''Updated by MFK on 12 JAN 2007 to vary referrer according to productcode
            'Select Case ProductCode
            '    Case "528", "529"   'for resellerpro, resellerpro-plus referer is 1005
            '        ActivationInfo.referrer = "1005"
            '    Case "530"   'for api reseller referer is 1012
            '        ActivationInfo.referrer = "1012"
            '    Case Else 'for other acc products ... referer is 1009
            '        ActivationInfo.referrer = "1009"
            'End Select
            WriteDebugInfo("Referrer=" & ActivationInfo.referrer)
            WriteDebugInfo("done!")
            WriteDebugInfo("Set pcodeinfo")
            Dim PCodeInfo(0) As FHResellerCustomer.pcodeinfo
            PCodeInfo(0) = New FHResellerCustomer.pcodeinfo
            WriteDebugInfo("ProductCode = " & ProductCode)
            PCodeInfo(0).productcode = ProductCode
            PCodeInfo(0).serialno = SerialNo
            PCodeInfo(0).newserialno = SerialNo
            PCodeInfo(0).renewable = 0
            PCodeInfo(0).renewduration = 0
            WriteDebugInfo("done!")
            ActivationInfo.productcodes = PCodeInfo

            WriteDebugInfo("ActivateProduct Calling")
            Dim ReturnMSG As FHResellerCustomer.returnmsg
            ReturnMSG = FHService.activateProducts(ActivationInfo)
            WriteDebugInfo("ActivateProduct is ok")
            WriteDebugInfo("ERRCODE=" & ReturnMSG.ERRORCODE.ToString())
            WriteDebugInfo("ERRDESC=" & ReturnMSG.ERRORDESC.ToString())

            If Not ReturnMSG.ERRORCODE.ToString().Trim().Equals("0") Then
                Dim serviceParameter As New System.Text.StringBuilder
                serviceParameter.Append("customerid=" & CustomerID & "::")
                serviceParameter.Append("orderno=" & OrderNo & "::")
                serviceParameter.Append("entityid=" & CustomerID & "::")
                serviceParameter.Append("entityname=" & CompanyName & "::")
                serviceParameter.Append("referrer=" & 1009 & "::")
                serviceParameter.Append("productcode=" & ProductCode & "::")
                serviceParameter.Append("SerialNo=" & SerialNo & "::")
                serviceParameter.Append("renewable=" & 0 & "::")
                serviceParameter.Append("renewduration=" & 0)

                Infinilogic.AccountsCentre.BLL.User.AddWebServiceLog("accounts.infinibiz.com/account/customer.asmx.vb", _
                                    "activate", _
                                    "http://webservices.infinibiz.com/customer.php", _
                                    "activateProducts", _
                                    serviceParameter.ToString, ReturnMSG.ERRORCODE.ToString, ReturnMSG.ERRORDESC)
            End If
            '------------------------------------done--------------------------------------

            Return ErrCodeAndDescription(0, NewCustomerID)
        Catch ex As Exception
            If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
                System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\Exception Trace.txt")
            sw.WriteLine(Now & " -- EXCEPTION")
            sw.WriteLine(Now & " -- Input Parameters:")
            sw.WriteLine(Now & " --     CustomerID=" & CustomerID)
            sw.WriteLine(Now & " --     ProductCode=" & ProductCode)
            sw.WriteLine(Now & " --     OrderNo=" & OrderNo)
            sw.WriteLine(Now & " --     SerialNo=" & SerialNo)
            sw.WriteLine(Now & " --     Language=" & Language)
            sw.WriteLine(Now & " -- Message = " & ex.Message)
            sw.WriteLine(Now & " -- StackTrace = " & ex.StackTrace)
            sw.WriteLine(Now & " -- Caller IP = " & HttpContext.Current.Request.UserHostAddress)
            sw.Close()
            Return ErrCodeAndDescription(1, "", ex.Message & " :: " & ex.StackTrace)
        End Try

    End Function

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

    Private Function ErrCodeAndDescription(ByVal ErrCode As String, Optional ByVal NewCustomerID As String = "", Optional ByVal ERRORDESC As String = "Server Error") As activateResult
        Dim ECD As New activateResult
        ECD.ERRORCODE = ErrCode
        ECD.NewCustomerID = NewCustomerID

        Select Case ErrCode
            Case "0"
                ECD.ERRORDESC = "Success."
            Case "1"
                ECD.ERRORDESC = ERRORDESC
            Case "10"
                ECD.ERRORDESC = """CustomerID"" not found OR invalid format."
            Case "11"
                ECD.ERRORDESC = """ProductCode"" not found OR invalid format."
            Case "12"
                ECD.ERRORDESC = """OrderNo"" not found OR invalid format."
            Case "13"
                ECD.ERRORDESC = """SerialNo"" invalid format."
            Case Else
                ECD.ERRORDESC = "Unknown Error Found."
        End Select

        Return ECD
    End Function
    Public Structure activateResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public NewCustomerID As String
    End Structure

    Private Function IsDomainAvailable(ByVal DomainName As String) As String
        Dim ErrMsg As String = ""
        Dim Service As New com.u_d.webservices.UniversalDomainServices
        Dim Result As com.u_d.webservices.ReturnMsg
        Result = Service.isDomainAvailable(DomainName)
        If Result.ERRORCODE.ToString <> "0" Then
            ErrMsg = Result.ERRORDESC
        End If
        Return ErrMsg
    End Function

    Private Sub chkNewCompanyOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkNewCompanyOption.CheckedChanged
        If chkNewCompanyOption.Checked Then
            listCompany.Enabled = False
            txtCompanyName.Enabled = True
        Else
            listCompany.Enabled = True
            txtCompanyName.Enabled = False
        End If

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

    Private Function GetLivePassword(ByVal CustomerID As String) As String
        Dim LiveID As String = GetLiveCustomerID("2", CustomerID)
        WriteDebugInfo("LiveID = " & LiveID)
        Dim Password As String = GetLiveID_Password("2", LiveID)
        WriteDebugInfo("Password = " & Password)
        Return Password
    End Function


    Public Function GetLiveCustomerID(ByVal MerchantID As String, ByVal RCustomerID As String) As String
        WriteDebugInfo("In GetLiveCustomerID: MerchantID=" & MerchantID & "-RCustomerID=" & RCustomerID)
        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String = service.GetXML(com.infinimarket.service.XmlFormat.Customer_details)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~merch_id~", MerchantID)
        xmlValue = Replace(xmlValue, "~cust_id~", RCustomerID)
        WriteDebugInfo("Calling GetCustomerLiveId:")
        WriteDebugInfo("xmlValue= " & xmlValue)
        Dim ResultXML As String = service.GetCustomerLiveId(xmlValue)
        WriteDebugInfo("GetCustomerLiveId is ok:")
        WriteDebugInfo("ResultXML= " & ResultXML)
        Dim xmlDoc As New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)
        Dim LiveID As String = xmlDoc.SelectSingleNode("details/customer_live_uid").InnerXml
        WriteDebugInfo("GetLiveCustomerID is ok: LiveID=" & LiveID)
        Return LiveID
    End Function

    Public Function GetLiveID_Password(ByVal MerchantID As String, ByVal LiveID As String) As String
        WriteDebugInfo("In GetLiveID_Password: MerchantID=" & MerchantID & "-LiveID=" & LiveID)

        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String
        Dim ResultXML As String
        Dim xmlDoc As New System.Xml.XmlDocument

        xmlValue = service.GetXML(com.infinimarket.service.XmlFormat.Customer_details)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~cust_luid~", LiveID)

        WriteDebugInfo("Calling GetCustomerInfo:")
        WriteDebugInfo("xmlValue= " & xmlValue)
        ResultXML = service.GetCustomerInfo(xmlValue)
        WriteDebugInfo("ResultXML= " & ResultXML)
        WriteDebugInfo("GetCustomerInfo is ok:")

        xmlDoc = New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)
        Dim LivePassword As String = ""
        LivePassword = xmlDoc.SelectSingleNode("details/Cart_Customer_Pass").InnerText

        WriteDebugInfo("GetLiveID_Password End: LivePassword.Length=" & LivePassword.Length)
        Return LivePassword
    End Function

    Private Function GetPassword() As String
        Dim sPwd As String
        Randomize() : sPwd = CInt(Int(90 * Rnd()) + 10)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & Chr(Int(26 * Rnd()) + 97)
        Randomize() : sPwd = sPwd & CInt(Int(90 * Rnd()) + 10)
        Return sPwd
    End Function
End Class
