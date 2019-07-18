Imports Infinilogic.AccountsCentre
Imports Infinilogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.IO
Imports Administration.BLL
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Text
Imports System.Collections.Specialized
Imports Microsoft.Toolkits.EnterpriseLocalization
Imports System.Resources
Imports System.threading
Imports System.Globalization


Public Class PageTemplate
    Inherits Infinilogic.AccountsCentre.BLL.PageBase
    'Declaration For Multilingual
    Protected _culture As CultureInfo
    Protected rs As ElementResourceSet

    '--------------------Session Constant Variables---------------------
    Public Const Session_ServiceID As String = "Session_ServiceID"
    Public Const Session_ParentUID As String = "Session_ParentUID"
    Public Const Session_ParentPassword As String = "Session_ParentPassword"
    Public Const Session_ResellerID As String = "Session_ResellerID"
    '********************************************************************************
    'updated by Muhammad Ubaid on 27-Feb-2007
    Public Const session_IsEmployee As String = "session_IsEmployee"
    Public Const session_EmployeeID As String = "session_EmployeeID"
    '********************************************************************************
    '-------------------------------------------------------------------

    ' Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    ' Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    ' Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
#Region " Controls used on this page "





    Protected RGG As common.RegularExpressions
    Const strNullString As String = ""

    REM SR
    Protected IsHomePage As Boolean
    REM SR

#End Region

    Public WriteOnly Property ErrorLabel() As String
        'Get
        '    Return CType(Page.FindControl("Bottonbar1"), BottomBar).ErrorLabel
        'End Get
        Set(ByVal Value As String)
            CType(Page.FindControl("Bottonbar1").FindControl("tbl_Error"), HtmlTable).Visible = True
            CType(Page.FindControl("Bottonbar1").FindControl("td_ErrorMsg"), HtmlTableCell).InnerHtml = Value
        End Set
    End Property

    Protected Function ApplyRegularExpressions(ByVal Exp As String) As String        '
        Dim temp As Object, temp1 As Object, ic As Int16, msg As String = ""
        RGG = New common.RegularExpressions
        temp = Split(Exp, ",")
        For ic = 0 To UBound(temp)
            temp1 = Split(temp(ic), "-")
            RGG.Add(temp1(0) & "", temp1(1) & "", temp1(2) & "")
        Next
        msg = RGG.ScanPage(Me)
        RGG = Nothing
        Return msg
    End Function
    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load      '
        If Not IsPostBack Then
            If Len(Session("UserUID")) = 0 And User.Identity.IsAuthenticated Then
                Response.Redirect("/account/signout.aspx")
            Else
                'If Len(Session("UserEmail")) = 0 And User.Identity.IsAuthenticated Then
                '    If Not Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 23) = "UPDATEREGISTRATION.ASPX" Then
                '        Response.Redirect("/members/UpdateRegistration.aspx")
                '    End If
                'End If
            End If
        End If
        If Session("ACC_ISUPDATESERVICES_VISITED") And LCase(Request.Url.AbsolutePath) <> "/members/updateservices.aspx" Then
            Session.Remove("ACC_ISUPDATESERVICES_VISITED")
            Session.Remove("ACC_ISFORMCOMPLETED")
            ' Session.Remove("ACC_RENEW_PRODUCT")
            Session.Remove(Me.ACC_ORDER_HERE_LINK)
        End If
        'Session("ACC_ISUPDATESERVICES_VISITED") = Session("ACC_ISUPDATESERVICES_VISITED")
    End Sub

    Shared Sub AuthMailMessage(ByVal Mail As System.Web.Mail.MailMessage, ByVal UserID As String, ByVal Password As String)
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserID) 'set your username here
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password) 'set your password here
    End Sub


    Public Function SendEmailForServiceEnable(ByVal intCustomerID As String, Optional ByVal colEnableWebApp As System.Collections.Specialized.NameValueCollection = Nothing, Optional ByVal colEnableDesktopApp As System.Collections.Specialized.NameValueCollection = Nothing, Optional ByVal TemplateCode As String = "LGIN", Optional ByVal OrderNo As Integer = 0) As String

        Dim sbDisableWebApplication As New StringBuilder
        Dim sbDisableDesktopApplication As New StringBuilder

        Dim colEnableWebApplication As New System.Collections.Specialized.NameValueCollection
        Dim colEnableDesktopApplication As New System.Collections.Specialized.NameValueCollection
        Dim colDisableWebApplication As New System.Collections.Specialized.NameValueCollection
        Dim colDisableDesktopApplication As New System.Collections.Specialized.NameValueCollection

        Dim objEmail As New Email
        Dim ds As DataSet
        Dim useremail As String
        Dim strEmail As String, strAddress As String, strPhone As String, strPostCode As String, strCountry As String
        Dim strTown As String, strCompName As String
        Dim strAllocatedto As String
        Dim objCustomer As New CustomerSelectedServices
        ds = objCustomer.GetCustomer(intCustomerID)

        strEmail = objEmail.GetAccountCenterUserEmail(intCustomerID)

        useremail = ConfigReader.GetItem(ConfigVariables.SMTPUserID)
        useremail = "Infinibiz  <" & useremail & ">"

        '  If strStatus = "Enable" Then

        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer
        Dim dsEmailContent As DataSet
        dsEmailContent = objCustomer.SelectEmailContent(TemplateCode)
        strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        intActive = dsEmailContent.Tables(0).Rows(0).Item("Active")

        If intActive <> 0 Then
            Dim dsCustomers As DataSet
            Dim strMessage As String
            Dim strName As String
            Dim strLogin As String
            Dim strPassowrd, strOrderNo As String


            strOrderNo = IIf(OrderNo > 0, OrderNo.ToString, String.Empty)

            dsCustomers = objCustomer.SelectCustomers(intCustomerID)
            strName = dsCustomers.Tables(0).Rows(0).Item("Name")
            strLogin = dsCustomers.Tables(0).Rows(0).Item("cart_customer_uid")
            strPassowrd = dsCustomers.Tables(0).Rows(0).Item("cart_customer_pass")

            strAddress = strAddress & ds.Tables(0).Rows(0).Item("street")
            strAddress = strAddress & "<br>" & ds.Tables(0).Rows(0).Item("town")
            strAddress = strAddress & "<br>" & ds.Tables(0).Rows(0).Item("postcode")
            strAddress = strAddress & "<br>" & ds.Tables(0).Rows(0).Item("country")
            strPhone = ds.Tables(0).Rows(0).Item("telephone")

            Dim strpas1 As String = objCustomer.Crypt(strLogin, strPassowrd)
            Dim i As Integer

            Dim sbEnableWebApplication As New StringBuilder
            Dim sbEnableDesktopApplication As New StringBuilder

            If colEnableWebApp Is Nothing And colEnableDesktopApp Is Nothing Then
                For i = 0 To colEnableWebApplication.Count - 1
                    sbEnableWebApplication.Append("<li>" + colEnableWebApplication.Item(i) + "<br>")
                Next
            Else
                For i = 0 To colEnableWebApp.Count - 1
                    sbEnableWebApplication.Append("<li>" + colEnableWebApp.Item(i) + "<li><br>")
                Next
            End If

            Return SelectEmailContent(TemplateCode, strName, strLogin, strpas1, strAddress, sbEnableWebApplication.ToString, OrderNo)
            objCustomer.InsertEmailLog(intCustomerID, TemplateCode, strMessage)
        End If

    End Function

    Public Function SelectEmailContent(ByVal TemplateName As String, ByVal Name As String, ByVal strLoginID As String, Optional ByVal strpassword As String = "", Optional ByVal strCustomerAddress As String = "", Optional ByVal strServicesInformation As String = "", Optional ByVal OrderNo As Integer = 0) As String
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
        strbuilder.Replace("[OrderID]", IIf(OrderNo > 0, OrderNo.ToString, String.Empty)).ToString()
        strbuilder.Replace("\Administration\images\logo.jpg", "https:\\www.accountscentre.com\images\logo.jpg")
        Return strbuilder.ToString

    End Function

    Public Shared Function isProductSelected(ByVal productCode As String, ByVal ParamArray Grids() As DataGrid) As String

        For Each grid As DataGrid In Grids

            For Each GridItem As DataGridItem In grid.Items
                If GridItem.Cells(4).Text.Equals(productCode) Then
                    Dim myCheckbox As Object
                    myCheckbox = New CheckBox
                    myCheckbox = CType(GridItem.Cells(0).Controls(1), CheckBox)
                    If myCheckbox.Checked Then Return True
                End If
            Next
        Next
        Return False
    End Function

    Public Function GetSelectedProducts(ByVal IsHTMLCheckbox As Boolean, ByVal ParamArray Grids() As DataGrid) As NameValueCollection
        Dim products As New NameValueCollection

        For Each grid As DataGrid In Grids

            For Each GridItem As DataGridItem In grid.Items
                Dim myCheckbox As Object
                If IsHTMLCheckbox Then
                    myCheckbox = New HtmlInputCheckBox
                    myCheckbox = CType(GridItem.Cells(0).Controls(1), HtmlInputCheckBox)

                Else
                    myCheckbox = New CheckBox
                    myCheckbox = CType(GridItem.Cells(0).Controls(1), CheckBox)

                End If



                If myCheckbox.Checked Then products.Add(GridItem.Cells(1).Text.ToString, GridItem.Cells(1).Text.ToString)

            Next

        Next

        'Dim str As String

        'For i As Integer = 0 To products.Count - 1
        '    str &= products.Item(i)
        'Next
        Return products

    End Function


    'Code For MultiLingual

    Public Sub load_culture(ByVal culture As String)
        'If Not IsPostBack Then
        'Settings.LoadCultureDropDownList(drpSelectLanguage, CultureDropDownTypes.NativeName, Nothing)
        'If Not Session("SelectedCulture") Is Nothing Then
        '    _culture = Session("SelectedCulture")
        'End If
        'If _culture Is Nothing Then 'Session("SelectedCulture") Is Nothing Then
        '_culture = New CultureInfo("en")
        'Session("SelectedCulture") = _culture
        'End If
        'Thread.CurrentThread.CurrentUICulture = _culture
        'Else
        System.Web.HttpContext.Current.Trace.Warn("Culture=" & culture)
        _culture = New CultureInfo("en")
        '_culture = New CultureInfo(culture)
        '_culture = Session("SelectedCulture")
        Thread.CurrentThread.CurrentUICulture = _culture
        'End If
    End Sub
    Public Function load_culturevalue(ByVal header_name As String) As String
        rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
        Return rs.GetProperty(header_name, "System.Web.UI.WebControls.Label", "Text")
    End Function

    Public Function load_gridheader(ByVal header_name As String) As String
        rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
        Return rs.GetProperty(header_name, "System.Web.UI.HtmlControls.HtmlTableCell", "InnerText")
    End Function

    'Public Function DebugWrite(ByVal str As String)
    '    Dim sw As StreamWriter
    '    sw = File.AppendText("c:\DebugLog.txt")
    '    sw.WriteLine(str + " " + "-------" + Now())
    '    sw.Close()
    'End Function

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Error

        Try
            Dim Ex As Exception
            Ex = Server.GetLastError
            Dim body As String
            Server.ClearError()

            Dim To_EmailAddress As String = "errors@infinibiz.com"
            Dim From_EmailAddress As String = ConfigReader.GetItem(ConfigVariables.SMTPUserID)
            Dim Email_Subject As String = "ERROR :: " & Request.Url.Host

            'body = ExceptionFormatter.Formatter.GetFormattedString(ex)
            body = ExceptionFormatter2.Formatter.HandleException(ex, To_EmailAddress, From_EmailAddress, Email_Subject)
            HttpContext.Current.Trace.Write("Body --> " & body)

            Dim mail As New System.Web.Mail.MailMessage
            mail.To = To_EmailAddress
            mail.From = From_EmailAddress
            mail.Subject = Email_Subject
            mail.Body = body
            mail.BodyFormat = System.Web.Mail.MailFormat.Html
            System.Web.Mail.SmtpMail.SmtpServer = ConfigReader.GetItem(ConfigVariables.SMTPSERVER)

            If ConfigReader.GetItem(ConfigVariables.SMTP_Authentication) = "1" Then
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigReader.GetItem(ConfigVariables.SMTPUserID)) 'set your username here
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigReader.GetItem(ConfigVariables.SMTPPassword))  'set your password here
            End If
            System.Web.Mail.SmtpMail.Send(mail)

            Server.Transfer("../account/ErrorPage.aspx")
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("PageBase EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        Finally

        End Try

    End Sub

    'Protected Sub ShowBottomBarError(ByRef BottomBar As Control, ByVal ErrorMessage As String, Optional ByVal HeaderMessage As String = "")

    '    Dim Error_Table As HtmlTable = CType(BottomBar.FindControl("tbl_Error"), HtmlTable)
    '    Dim Error_Header As HtmlTableCell = CType(BottomBar.FindControl("td_ErrorHeader"), HtmlTableCell)
    '    Dim Error_Message As HtmlTableCell = CType(BottomBar.FindControl("td_ErrorMsg"), HtmlTableCell)

    '    Error_Table.Visible = True

    '    If HeaderMessage <> String.Empty Then
    '        Error_Header.Visible = True
    '        Error_Header.InnerHtml = "<strong>" & HeaderMessage & "</strong>"
    '    End If

    '    Error_Message.InnerHtml = "<ul><li>" & ErrorMessage.Replace("^", "</li><li>") & "</li></ul>"

    'End Sub


End Class
