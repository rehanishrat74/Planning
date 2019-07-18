Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common

Public Class MembersProfile
    Inherits MembersDefault

    'Inherits System.Web.UI.Page
#Region "Declaration"
    Protected WithEvents compname As System.Web.UI.WebControls.TextBox
    Protected WithEvents compregno As System.Web.UI.WebControls.TextBox
    Protected WithEvents CompTaxRefID As System.Web.UI.WebControls.TextBox
    Protected WithEvents compaddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents comppostcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents compcity As System.Web.UI.WebControls.TextBox
    Protected WithEvents compcountry As System.Web.UI.WebControls.DropDownList
    Protected WithEvents compphone As System.Web.UI.WebControls.TextBox
    Protected WithEvents compfax As System.Web.UI.WebControls.TextBox
    Protected WithEvents compemail As System.Web.UI.WebControls.TextBox
    Protected WithEvents compwebsite As System.Web.UI.WebControls.TextBox
    Protected WithEvents compDirector As System.Web.UI.WebControls.TextBox
    Protected WithEvents compSec As System.Web.UI.WebControls.TextBox
    'Protected WithEvents compSec As System.Web.UI.WebControls.TextBox
    Protected WithEvents compperson As System.Web.UI.WebControls.TextBox
    Protected WithEvents compdesignation As System.Web.UI.WebControls.TextBox
    Protected WithEvents compcontact As System.Web.UI.WebControls.TextBox
    Protected WithEvents complinbuss As System.Web.UI.WebControls.TextBox
    Protected WithEvents compdesbuss As System.Web.UI.WebControls.TextBox
    Protected WithEvents compemps As System.Web.UI.WebControls.TextBox
    Protected WithEvents compwork As System.Web.UI.WebControls.TextBox
    Protected WithEvents pform As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents returnurl As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents msgarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlCompanyProfile As System.Web.UI.WebControls.Panel
    Protected WithEvents name As System.Web.UI.WebControls.TextBox
    Protected WithEvents street As System.Web.UI.WebControls.TextBox
    Protected WithEvents town As System.Web.UI.WebControls.TextBox
    Protected WithEvents postcode As System.Web.UI.WebControls.TextBox
    Protected WithEvents country As System.Web.UI.WebControls.DropDownList
    Protected WithEvents cont_name As System.Web.UI.WebControls.TextBox
    Protected WithEvents telephone As System.Web.UI.WebControls.TextBox
    Protected WithEvents cart_customer_email As System.Web.UI.WebControls.TextBox
    Protected WithEvents cart_customer_notes As System.Web.UI.WebControls.TextBox
    Protected WithEvents cart_customer_state As System.Web.UI.WebControls.TextBox
    Protected WithEvents litCPPostCode As System.Web.UI.WebControls.Literal
    Protected WithEvents litPPPostCode As System.Web.UI.WebControls.Literal
    Protected WithEvents fax As System.Web.UI.WebControls.TextBox
    Private _PPUKBased As Boolean
    Protected WithEvents txtpayereference As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtNINO As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtaccountRefarenceNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtpayeofficeNo As System.Web.UI.WebControls.TextBox
    ' Protected WithEvents CompState As System.Web.UI.WebControls.TextBox
    Protected WithEvents Textbox1 As System.Web.UI.WebControls.TextBox

    Protected WithEvents pnlCustomerRegistration As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlExpress As System.Web.UI.WebControls.Panel
    Protected WithEvents PnlPayroll As System.Web.UI.WebControls.Panel
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents oFile As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents txtvatnumber As System.Web.UI.WebControls.TextBox
    Protected WithEvents CompState As System.Web.UI.WebControls.TextBox
    Protected WithEvents dtIntendedFinYear As System.Web.UI.WebControls.TextBox 'InfiniLogic.AccountsCentre.Web.datecontrol

    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents txtAccountOfficeReference As System.Web.UI.WebControls.TextBox
    

    Private _CPUKBased As Boolean
#End Region
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Sub ChangeComboValueTo(ByVal cmb As DropDownList, ByVal Value As Object)
        Dim o As Object, i As Int32 = 0
        For Each o In cmb.Items
            If o.Value = Value Then
                cmb.SelectedIndex = i
                Exit Sub
            End If

            i = i + 1
        Next
    End Sub
    Sub ChangeComboTo(ByVal cmb As DropDownList, ByVal Value As Object)
        Dim o As Object, i As Int32 = 0

        For Each o In cmb.Items
            If o.text = Value Then
                cmb.SelectedIndex = i
                Exit Sub
            End If
            i = i + 1
        Next
    End Sub
    Sub ShowProfile()
        Dim t As Object, oReader As Object, temp, temp1 As Object, i As Integer, tx As System.Web.UI.WebControls.TextBox, sx As New Collection
        Dim chk As WebControls.CheckBox

        oReader = CustomerProfile.GetProfile(CustomerID)
        REM SR
        Dim sNameNLengthForCustomer As String
        sNameNLengthForCustomer = ",name-250,street-60,town-30,country-255,cont_name-30,telephone-80,fax-80,cart_customer_email-255,cart_customer_notes-255,postcode-30,cart_customer_state-255"
        REM SR

        REM SR CR_00001
        Dim sNameNLengthForGatewayRegistration As String
        'sNameNLengthForGatewayRegistration = ",UserCode-10,Password-10,PinCode-10"
        REM SR CR_00001

        temp = Split("compname-50,compregno-8,CompTaxRefID-20,compaddress-255,comppostcode-30,compcity-50,compcountry-50,compphone-20,compfax-20,compemail-255,compwebsite-255,compDirector-255,compSec-255,compperson-50,compdesignation-50,compcontact-20,complinbuss-50,compdesbuss-250,compemps-8,compwork-2,compstate-250" & sNameNLengthForCustomer, ",")
        For i = 0 To UBound(temp)
            temp1 = Split(temp(i), "-")
            sx.Add(Val(temp1(1)) & "", temp1(0))
        Next
        For Each t In pnlCompanyProfile.Controls
            If TypeOf t Is TextBox Then
                'Response.Write(t.id & "<BR>")

                tx = t
                If tx.ID = "dtIntendedFinYear" Then

                Else

                    tx.Text = IIf(IsDBNull(oReader(tx.ID)), "", oReader(tx.ID))
                    tx.Attributes.Add("maxlength", sx(tx.ID) & "")
                End If

            ElseIf TypeOf t Is DropDownList Then
                REM SR CR_00001
                Dim li As ListItem, sSearchText As String

                If IsDBNull(oReader("compaddress")) OrElse oReader("compaddress") = "" Then
                    BindCountry(compcountry)
                Else
                    BindCountry(compcountry, oReader("compcountry"))
                End If



                sSearchText = IIf(IsDBNull(oReader("compcountry")), "", oReader("compcountry"))
                'BindCountry(compcountry, sSearchText)

                'li = compcountry.Items.FindByText(sSearchText.ToUpper)
                'If Not li Is Nothing Then

                '    compcountry.ClearSelection()
                '   compcountry.SelectedValue = li.Value
                CPUKBased = (compcountry.SelectedItem.Text = "UNITED KINGDOM")
                UKBasedSettings(CPUKBased)

                REM SR CR_00001
            End If
        Next

        For Each t In pnlCustomerRegistration.Controls
            If TypeOf t Is DropDownList Then
                Dim li As ListItem, sSearchText As String
                sSearchText = IIf(IsDBNull(oReader("country")), "", oReader("country"))
                li = country.Items.FindByText(sSearchText.ToUpper)
                If Not li Is Nothing Then
                    country.ClearSelection()
                    country.SelectedValue = li.Value
                    PPUKBased = li.Value.ToUpper = "GBR"
                    litPPPostCode.Text = IIf(PPUKBased, "AA9 9AA", "")
                Else
                    litPPPostCode.Text = ""
                    PPUKBased = False
                End If
            ElseIf TypeOf t Is TextBox Then
                tx = t
                tx.Text = IIf(IsDBNull(oReader(tx.ID)), "", oReader(tx.ID))
                tx.Attributes.Add("maxlength", sx(tx.ID) & "")
            End If
        Next

        sx = Nothing

        REM SR CR_00001
        postcode.MaxLength = IIf(PPUKBased, "8", "30")
        comppostcode.MaxLength = IIf(CPUKBased, "8", "30")
        REM SR CR_00001
        If IsDBNull(oReader("Compyear")) = False And Len(oReader("Compyear") & "") > 0 Then
            't = Split(oReader("Compyear"), "/")
            'dtIntendedFinYear.SetDate(oReader("Compyear"))
            dtIntendedFinYear.Text = (oReader("Compyear"))
            'ChangeComboTo(cmbDD, t(0))
            'ChangeComboTo(cmbMM, t(1))
            'ChangeComboTo(cmbYYYY, t(2))

            'Response.Write("Comp=" & oReader("Compyear"))

            'Else

            'ChangeComboValueTo(cmbDD, Date.Today.Day.ToString)
            'ChangeComboValueTo(cmbMM, Date.Today.Month.ToString)
            'ChangeComboValueTo(cmbYYYY, Date.Today.Year.ToString)
            'dtIntendedFinYear.SetDate(Now)
        End If

        Dim objCustomerProfile As New AccountsCentre.BLL.CustomerProfile

        Dim Sname As String
        Dim bpnlExpress As Boolean = IsServiceAllowed("Express") Or IsServiceAllowed("AccountsProWeb")

        If isserviceAllowed("Express") Then
            Sname = "Express"

        ElseIf isserviceAllowed("AccountsProWeb") Then
            Sname = "AccountsProWeb"
        End If

        Try


            If bpnlExpress = True Then 'And (Sname = "Express" OrElse Sname = "AccountsProWeb") Then
                pnlExpress.Visible = True
                Dim dsEpressData As DataSet

                dsEpressData = objCustomerProfile.GetExpressData(CustomerID, Sname)
                txtvatnumber.Text = dsEpressData.Tables(0).Rows(0).Item("VATNo")
            Else
                pnlExpress.Visible = False
            End If
        Catch ex As Exception

        End Try

        Try

            Dim bpnlPayroll As Boolean = IsServiceAllowed("Payroll")

            If bpnlPayroll = True Then
                PnlPayroll.Visible = True
                Dim ds As DataSet

                ds = objCustomerProfile.GetPayrollData(CustomerID)
                txtpayeofficeNo.Text = ds.Tables(0).Rows(0).Item("PAYEOfficeNo")   '_objEmployerData.PAYEOfficeNo
                txtpayereference.Text = ds.Tables(0).Rows(0).Item("PAYEReferenceNo")   ' _objEmployerData.PAYEReferenceNo
                txtaccountRefarenceNo.Text = ds.Tables(0).Rows(0).Item("AccountReferenceNo") '_objEmployerData.AccountReferenceNo
                txtNINO.Text = ds.Tables(0).Rows(0).Item("NINO") '_objEmployerData.NINO
                txtAccountOfficeReference.Text = ds.Tables(0).Rows(0).Item("AccountOfficeReference")
            Else
                PnlPayroll.Visible = False
            End If
        Catch ex As Exception

        End Try

    End Sub
    Sub UpdateProfile()
        Dim exp As String, msg As String

        CPUKBased = (compcountry.SelectedValue.ToUpper = "GBR")
        PPUKBased = (country.SelectedValue.ToUpper = "GBR")

        comppostcode.Text = UCase(comppostcode.Text)
        'exp = "compname-0700400500-Company Name,compregno-0100100080-Company Registration Number,CompTaxRefID-0500100200-Company Tax Reference ID,compaddress-0203502550-Company Address,comppostcode-0701400080-Company Postcode,compcity-0700400500-Company City Name,compcountry-0700400500-Company Country Name,compphone-0700600200-Company Phone Number,compfax-0700600200-Company Fax Number,compemail-0400302550-Company Email Address,compwebsite-0400402551-Company website Address,compDirector-0203502550-Company Direcotors Info,compSec-0203502550-Company Seceratories Info,compperson-0700400500-Company Contact Person Name,compdesignation-0700400500-Company Contact Designation,compcontact-0700600200-Company Contact Phone Number,complinbuss-0700400500-Company Line Of Business,compdesbuss-0203500500-Company Business Description,compemps-0100100080-Company Total Employees,compwork-0110000020-Company Work Days In A Week"

        REM SR
        Dim sPPexp As String, sPPmsg As String
        If PPUKBased = True Then
            sPPexp = "name-0700502500-Complete Name,street-0700300600-Street,town-0700300300-Town,cart_customer_state-0700302550-State,PostCode-0400200300-Postcode,Cont_name-0700300301-Contact Name,telephone-0700600800-Telephone,fax-0700600801-Fax,cart_customer_email-0400302550-Email,cart_customer_notes-0203502551-Notes"
        Else
            sPPexp = "name-0700502500-Complete Name,street-0700300600-Street,town-0700300300-Town,cart_customer_state-0700302550-State,PostCode-0203700300-Postcode,Cont_name-0700300301-Contact Name,telephone-0700600800-Telephone,fax-0700600801-Fax,cart_customer_email-0400302550-Email,cart_customer_notes-0203502551-Notes"
        End If
        sPPmsg = ApplyRegularExpressions(sPPexp)
        If Len(sPPmsg) > 0 Then sPPmsg = "<BR><B>Personal Profile</B><BR>" & sPPmsg & "<BR>"
        REM SR

        REM SR CR_00001
        'xexp = "compname-0700300500-Company name,compregno-0203400080-Company registration number,CompTaxRefID-0500100200-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0701400080-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compwebsite-0400402551-Website,compDirector-0203502550-Director(s),compSec-0203502550-Secerator(ies),compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
        'If UKCompanyStatus = CompanyStatus.BothCompaniesHouseAndFormationsHouse Then
        '    exp = "CompTaxRefID-0500100201-Tax reference ID,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
        '    'exp = "compname-0700300500-Company name,compregno-0203400080-Company registration number,compaddress-0203502550-Registered address,comppostcode-0701400080-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compwebsite-0400402551-Website,compDirector-0203502550-Director(s),compSec-0203502550-Secerator(ies)"

        'ElseIf CPUKBased = true Then
        '    exp = "CompTaxRefID-0500100201-Tax reference ID,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
        '    'exp = "compname-0700300500-Company name,compregno-0203400081-Company registration number,CompTaxRefID-0500100201-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0203700300-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compwebsite-0400402551-Website,compDirector-0203502551-Director(s),compSec-0203502551-Secerator(ies),compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
        'Else

        '    exp = "compname-0700300500-Company name,compregno-0203400080-Company registration number,CompTaxRefID-0500100200-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0701400080-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compwebsite-0400402551-Website,compDirector-0203502550-Director(s),compSec-0203502550-Secerator(ies),compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
        'End If

        If UKCompanyStatus = CompanyStatus.BothCompaniesHouseAndFormationsHouse Then
            'exp = "CompTaxRefID-0500100201-Tax reference ID,compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week"
            exp = "dtIntendedFinYear-0400100100-Intended financial year end ,CompTaxRefID-0500100201-Tax reference ID,compemail-0400302550-Email,compphone-0700600200-Phone Number,compDirector-0203502550-Director(s),compSec-0203502550-Secerator(ies),comppostcode-0701400080-Postcode,compcity-0700300500-City,compaddress-0203502550-Registered address"
        ElseIf CPUKBased = True Then
            exp = "dtIntendedFinYear-0400100100-Intended financial year end,compname-0700300500-Company name,compregno-0203400080-Company registration number,CompTaxRefID-0500100200-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0701400080-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compDirector-0203502550-Director(s),compSec-0203502550-Secerator(ies),compemail-0400302550-Email"
        Else
            'exp = "compname-0700300500-Company name,compregno-0203400081-Company registration number,CompTaxRefID-0500100201-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0203700300-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compfax-0700600200-Fax number,compemail-0400302550-Email,compwebsite-0400402551-Website,compDirector-0203502551-Director(s),compSec-0203502551-Secerator(ies),compperson-0700300500-Contact Person,compdesignation-0700300500-Designation,compcontact-0700600200-Contact number,complinbuss-0700300500-Line of business,compdesbuss-0203502500-Business description,compemps-0100100080-Number of employees,compwork-0110000020-Work days in a week,UserID-0203700251-Gateway User ID,PinCode-0203700251-Gateway PIN Code"
            exp = "dtIntendedFinYear-0400100100-Intended financial year end,compname-0700300500-Company name,compregno-0203400081-Company registration number,CompTaxRefID-0500100201-Tax reference ID,compaddress-0203502550-Registered address,comppostcode-0203700300-Postcode,compcity-0700300500-City,compcountry-0700300500-Country,compphone-0700600200-Phone Number,compDirector-0203502551-Director(s),compSec-0203502551-Secerator(ies),compemail-0400302550-Email"
        End If


        REM SR CR_00001
        msg = ApplyRegularExpressions(exp)

        REM SR
        If Len(msg) > 0 Then msg = "<BR><B>Company Profile</B><BR>" & msg
        msg = sPPmsg & msg
        REM SR

        If Left(UCase(compwebsite.Text), 7) <> "HTTP://" And Len(compwebsite.Text) > 0 Then compwebsite.Text = "http://" & compwebsite.Text
        'If InStr(msg, "Company registration number") <= 0 Then
        '    Dim i As Int16, b As Boolean = False
        '    For i = 65 To 130
        '        If InStr(compregno.Text, Chr(i)) > 0 Then
        '            b = True
        '            Exit For
        '        End If
        '    Next
        '    If b Then msg = msg & ",Company registration number"
        'End If
        If Len(msg) > 0 Then
            msgarea.InnerHtml = "<font color=red><b>Please Correct the following Fields</b> <BR>" & Replace(msg, ",", "<BR>") & "</font>"
        Else
            REM SR
            'CustomerProfile.UpdateProfile(CustomerID, compname.Text, compregno.Text, compaddress.Text, comppostcode.Text, compcity.Text, compcountry.Text, compphone.Text, compfax.Text, compemail.Text, compwebsite.Text, compperson.Text, compdesignation.Text, compcontact.Text, complinbuss.Text, compdesbuss.Text, compemps.Text, compwork.Text, cmbDD.SelectedItem.Text & "/" & cmbMM.SelectedItem.Text & "/" & cmbYYYY.SelectedItem.Text, compDirector.Text, compSec.Text, CompTaxRefID.Text, "")
            Dim strCountryCode As String, strCountry As String, strCompCountry
            Dim objUser As New User
            'strCountryCode = objUser.GetCountryCode(country.SelectedItem.Text)
            strCountryCode = country.SelectedItem.Value
            strCountry = country.SelectedItem.Text
            strCompCountry = compcountry.SelectedItem.Text
            REM SR

            Dim Checked As Boolean

            Dim Logo As String, LogoName As String
            Dim Sname As String
            Dim bpnlExpress As Boolean = IsServiceAllowed("Express") Or IsServiceAllowed("AccountsProWeb")



            Dim _objcustomerProfile As New CustomerProfile
            If bpnlExpress = True Then

                If isserviceAllowed("Express") Then
                    Sname = "Express"

                ElseIf isserviceAllowed("AccountsProWeb") Then
                    Sname = "AccountsProWeb"
                End If



                Dim ArrFile As Byte() = New Byte(oFile.PostedFile.ContentLength - 1) {}

                If oFile.PostedFile.ContentLength > 1 Then

                    Dim oType As String
                    oType = oFile.PostedFile.ContentType
                    If oType <> "image/pjpeg" And oType <> "image/gif" And oType <> "image/bmp" Then
                        ErrorMessage = "ERROR: Please select image file.  <BR>"
                        Exit Sub
                    End If
                End If

                If oFile.PostedFile.ContentLength > 1 Then

                    oFile.PostedFile.InputStream.Read(ArrFile, 0, oFile.PostedFile.ContentLength)
                    LogoName = oFile.PostedFile.FileName
                    Checked = True
                    _objcustomerProfile.UpdateCompanyInfo(CustomerID, compname.Text, street.Text, _
                     compcity.Text, comppostcode.Text, compcountry.SelectedValue, compphone.Text, _
                    compfax.Text, compemail.Text, txtvatnumber.Text, ArrFile, LogoName, Checked, Sname)
                Else
                    LogoName = ""
                    Checked = False
                    _objcustomerProfile.UpdateCompanyInfo(CustomerID, compname.Text, street.Text, _
                    compcity.Text, comppostcode.Text, compcountry.SelectedValue, compphone.Text, _
                   compfax.Text, compemail.Text, txtvatnumber.Text, ArrFile, LogoName, Checked, Sname)
                End If

            End If



            '_objcustomerProfile.UpdateCompanyInfo(customerID, compname.Text, street.Text, _
            '          compcity.Text, comppostcode.Text, compcountry.SelectedValue, compphone.Text, _
            '         compfax.Text, compemail.Text, txtvatnumber.Text, ArrFile, LogoName, Checked)

            Dim bpnlPayroll As Boolean = IsServiceAllowed("Payroll")

            If bpnlPayroll = True Then
                If VerifyFormData() = False Then
                    Exit Sub
                End If
            End If

            'Dim m As Boolean = _objcustomerProfile.Update(customerID, street.Text, _
            'compcity.Text, comppostcode.Text, compcountry.SelectedValue, compphone.Text, _
            'compfax.Text, compemail.Text, cart_customer_state.Text, compname.Text, txtpayeofficeNo.Text, txtpayereference.Text, txtaccountRefarenceNo.Text, txtNINO.Text, complinbuss.Text, compemps.Text, _
            '2002)

            'Dim dttest As String = Convert.ToString(dtIntendedFinYear.GetDate)
            Dim dttest As String = dtIntendedFinYear.Text
            Dim strCompYear As String

            'strCompYear = IIf(IsDBNull(compemps.Text), "0", compemps.Text)

            If compemps.Text Is Nothing Or compemps.Text = "" Then
                strCompYear = "0"
            End If

            Dim m As Boolean = _objcustomerProfile.Update(CustomerID, street.Text, _
            compcity.Text, comppostcode.Text, compcountry.SelectedValue, compphone.Text, _
            compfax.Text, compemail.Text, cart_customer_state.Text, compname.Text, txtpayeofficeNo.Text, txtpayereference.Text, txtaccountRefarenceNo.Text, txtNINO.Text, complinbuss.Text, strCompYear, _
            False, compregno.Text, Now, Now, "Weekly", txtAccountOfficeReference.Text)

            REM SR CR_00001
            'xCustomerProfile.UpdateProfile(CustomerID, compname.Text, compregno.Text, compaddress.Text, comppostcode.Text, compcity.Text, compcountry.Text, compphone.Text, compfax.Text, compemail.Text, compwebsite.Text, compperson.Text, compdesignation.Text, compcontact.Text, complinbuss.Text, compdesbuss.Text, compemps.Text, compwork.Text, cmbDD.SelectedItem.Text & "/" & cmbMM.SelectedItem.Text & "/" & cmbYYYY.SelectedItem.Text, compDirector.Text, compSec.Text, CompTaxRefID.Text, "", name.Text, street.Text, town.Text, strCountry, cont_name.Text, telephone.Text, fax.Text, cart_customer_email.Text, cart_customer_notes.Text, postcode.Text, cart_customer_state.Text, strCountryCode)            
            'CustomerProfile.UpdateProfile(CustomerID, compname.Text, compregno.Text, compaddress.Text, comppostcode.Text, compcity.Text, strCompCountry, compphone.Text, compfax.Text, compemail.Text, compwebsite.Text, compperson.Text, compdesignation.Text, compcontact.Text, complinbuss.Text, compdesbuss.Text, compemps.Text, compwork.Text, cmbDD.SelectedItem.Text & "/" & cmbMM.SelectedItem.Text & "/" & cmbYYYY.SelectedItem.Text, compDirector.Text, compSec.Text, CompTaxRefID.Text, "", name.Text, street.Text, town.Text, strCountry, cont_name.Text, telephone.Text, fax.Text, cart_customer_email.Text, cart_customer_notes.Text, postcode.Text, cart_customer_state.Text, strCountryCode)
            CustomerProfile.UpdateProfile(CustomerID, compname.Text, compregno.Text, compaddress.Text, comppostcode.Text, compcity.Text, strCompCountry, compphone.Text, compfax.Text, compemail.Text, compwebsite.Text, compperson.Text, compdesignation.Text, compcontact.Text, complinbuss.Text, compdesbuss.Text, compemps.Text, compwork.Text, dttest, compDirector.Text, compSec.Text, CompTaxRefID.Text, "", name.Text, street.Text, town.Text, strCountry, cont_name.Text, telephone.Text, fax.Text, cart_customer_email.Text, cart_customer_notes.Text, postcode.Text, cart_customer_state.Text, strCountryCode)

            'IsGatewayRegistered = PinCode.Text.Length <> 0
            'GatewayUserCode = UserCode.Text
            'GatewayPassword = Password.Text
            'GatewayPINCode = PinCode.Text
            REM SR CR_00001

            CheckRedirection()

            'Response.Redirect(Request.UrlReferrer.AbsoluteUri.ToString())
            Response.Redirect("/members/default.aspx")

            'ShowProfile()
        End If

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        msgarea.InnerHtml = ""

        If Not IsPostBack Then

            VerifyCustomerbyFH()

            FillCombo()
            ShowProfile()
            '**************(MNS)****************
            SetFocus(name)
            '***********************************
        End If
        'End If

    End Sub




    Public Sub VerifyCustomerbyFH()

        If UKCompanyStatus = CompanyStatus.BothCompaniesHouseAndFormationsHouse Then
            '        Dim objFH As New InfiniLogic.AccountsCentre.BLL.com.formationshouse.www.FHservices

            Try


                Dim objProfile As New AccountsCentre.BLL.CustomerProfile
                Dim str() As String
                str = objProfile.UpdateFHCustomerDataToAC(CustomerID)
                If Not str(1) Is Nothing Then
                    compname.ReadOnly = True
                    compregno.ReadOnly = True
                    compwebsite.ReadOnly = True
                    compaddress.ReadOnly = True
                    compDirector.ReadOnly = True
                    compSec.ReadOnly = True
                    compcountry.Enabled = False
                    compcity.ReadOnly = True
                    comppostcode.ReadOnly = True
                    'compemail.ReadOnly = True
                    'compfax.ReadOnly = True
                    'compphone.ReadOnly = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TheMenu_BeforeRender() Handles TheMenu.BeforeRender
        '  TheMenu("PROF").IsSelected = True
        'TheMenu("MEM1").IsImage = False
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
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        UpdateProfile()
    End Sub
    Private Sub FillCombo()
        With country
            .DataTextField = "country_name"
            .DataValueField = "country_code"
            .DataSource = CustomerProfile.GetCountries()
            .DataBind()
        End With
        With compcountry
            .DataTextField = "country_name"
            .DataValueField = "country_code"
            .DataSource = CustomerProfile.GetCountries()
            .DataBind()
        End With
    End Sub
    REM SR CR_00001
    Private Sub UKBasedSettings(Optional ByVal bIsUKBased As Boolean = False)
        If UKCompanyStatus = CompanyStatus.BothCompaniesHouseAndFormationsHouse Then
            compcountry.SelectedValue = "GBR"
            compcountry.Enabled = False
            compname.Enabled = False
            compregno.Enabled = False
            bIsUKBased = True
        Else
            compname.Enabled = True
            compregno.Enabled = True
            compcountry.Enabled = True
        End If
        If bIsUKBased Then
            compcountry.SelectedItem.Text = CommonBase.Resources(ACC_Resource.DefaultCountry)
        Else
            ' UserCode.Text = ""
            '' Password.Text = ""
            'PinCode.Text = ""
        End If

        'UserCode.Enabled = bIsUKBased
        'Password.Enabled = bIsUKBased
        'PinCode.Enabled = bIsUKBased

        CPUKBased = bIsUKBased
        litCPPostCode.Text = IIf(CPUKBased, "AA9 9AA", "")
        comppostcode.MaxLength = IIf(CPUKBased, "8", "30")
    End Sub
    Private Sub country_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles country.SelectedIndexChanged
        PPUKBased = (country.SelectedValue.ToUpper = "GBR")
        litPPPostCode.Text = IIf(PPUKBased, "AA9 9AA", "")
        postcode.MaxLength = IIf(PPUKBased, "8", "30")
    End Sub
    Protected Property PPUKBased() As Boolean
        Get
            Return _PPUKBased
        End Get
        Set(ByVal Value As Boolean)
            _PPUKBased = Value
        End Set
    End Property
    Protected Property CPUKBased() As Boolean
        Get
            Return _CPUKBased
        End Get
        Set(ByVal Value As Boolean)
            _CPUKBased = Value
        End Set
    End Property
    Private Sub compcountry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles compcountry.SelectedIndexChanged
        CPUKBased = (compcountry.SelectedValue.ToUpper = "GBR")
        litCPPostCode.Text = IIf(CPUKBased, "AA9 9AA", "")
        UKBasedSettings(CPUKBased)
    End Sub
    Private Function VerifyFormData() As Boolean

        VerifyFormData = False ' Intentionally make it
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

        objRegExp.Add("txtpayeofficeNo", "0107100030", "PAYE Office No.")
        objRegExp.Add("txtpayereference", "0203400100", "PAYE Reference No. ")
        objRegExp.Add("txtaccountRefarenceNo", "0203400350", "Account Reference No.")
        objRegExp.Add("txtNINO", "0701300500", "National Insurance No. (NINO)")
        objRegExp.Add("dtIntendedFinYear", "0400100100", "Intended financial year end")
        objRegExp.Add("txtAccountOfficeReference", "0702200170", "Account Office Reference is invalid.")

        strReturnMessage &= objRegExp.ScanPage(Me)
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyFormData = True
        Else
            ' When form controls voilate the business rules
            VerifyFormData = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            msgarea.InnerHtml = "<font color=""Red""> Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage & "</font>"

        End If
        objRegExp = Nothing
    End Function
    REM SR CR_00001

End Class