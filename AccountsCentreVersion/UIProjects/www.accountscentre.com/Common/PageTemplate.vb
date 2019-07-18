Imports InfiniLogic.AccountsCentre.BLL
Imports System.IO
Imports InfiniLogic.AccountsCentre.common
Imports Administration.BLL
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Text
Imports System.Collections.Specialized

Public Class PageTemplate
    Inherits InfiniLogic.AccountsCentre.BLL.PageBase

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

    End Sub

    Shared Sub AuthMailMessage(ByVal Mail As System.Web.Mail.MailMessage, ByVal UserID As String, ByVal Password As String)
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", UserID) 'set your username here
        Mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", Password) 'set your password here
    End Sub

    Private Sub Page_Error(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles MyBase.Error
        'Try
        '    Dim Ex As Exception
        '    Dim body As String

        '    Ex = Server.GetLastError
        '    Server.ClearError()
        '    body = "Source     : " & Ex.Source.ToString & "<br>" & _
        '            "Messege    : " & Ex.Message.ToString & "<br>" & _
        '            "Stack Trace: " & Ex.StackTrace.ToString & "<br>"

        '    CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "errors@accountscentre.com", "Accountscentre Administration", body, Mail.MailFormat.Html)

        'Catch ex As Exception

        'Finally
        '    Response.Redirect("/Common/ErrorPage.aspx")
        'End Try
    End Sub





    Public Function SendEmailForServiceEnable(ByVal intCustomerID As String, Optional ByVal colEnableWebApp As System.Collections.Specialized.NameValueCollection = Nothing, Optional ByVal colEnableDesktopApp As System.Collections.Specialized.NameValueCollection = Nothing) As String

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
        useremail = "ACCOUNTS CENTRE <" & useremail & ">"

        '  If strStatus = "Enable" Then

        Dim strEmailTemplate As String
        Dim strTemplateSubject As String, intActive As Integer
        Dim dsEmailContent As DataSet
        dsEmailContent = objCustomer.SelectEmailContent("LGIN")
        strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        intActive = dsEmailContent.Tables(0).Rows(0).Item("Active")

        If intActive <> 0 Then
            Dim dsCustomers As DataSet
            Dim strMessage As String
            Dim strName As String
            Dim strLogin As String
            Dim strPassowrd As String

            dsCustomers = objCustomer.SelectCustomers(intCustomerID)
            strName = dsCustomers.Tables(0).Rows(0).Item("Name")
            strLogin = dsCustomers.Tables(0).Rows(0).Item("cart_customer_uid")
            strPassowrd = dsCustomers.Tables(0).Rows(0).Item("cart_customer_pass")

            strAddress = "<List>" & strAddress & ds.Tables(0).Rows(0).Item("street") & "</List>"
            strAddress = strAddress & "<List>" & ds.Tables(0).Rows(0).Item("town") & "</List>"
            strAddress = strAddress & "<List>" & ds.Tables(0).Rows(0).Item("postcode") & "</List>"
            strAddress = strAddress & "<List>" & ds.Tables(0).Rows(0).Item("country") & "</List>"
            strPhone = ds.Tables(0).Rows(0).Item("telephone")

            Dim strpas1 As String = objCustomer.Crypt(strLogin, strPassowrd)
            Dim i As Integer

            Dim sbEnableWebApplication As New StringBuilder
            Dim sbEnableDesktopApplication As New StringBuilder

            If colEnableWebApp Is Nothing And colEnableDesktopApp Is Nothing Then
                For i = 0 To colEnableWebApplication.Count - 1
                    sbEnableWebApplication.Append("&lt;li>" + colEnableWebApplication.Item(i) + "&lt;/li><br/>")
                Next

                'When Collection parameter is send through Order.aspx

                'For i = 0 To colEnableDesktopApplication.Count - 1
                '    sbEnableDesktopApplication.Append("<li>" + colEnableDesktopApplication.Item(i) + "</li> <br/>")
                'Next
            Else
                For i = 0 To colEnableWebApp.Count - 1
                    sbEnableWebApplication.Append("&lt;li>" + colEnableWebApp.Item(i) + "&lt;/li><br/>")
                Next


                'For i = 0 To colEnableDesktopApp.Count - 1
                '    sbEnableDesktopApplication.Append("<li>" + colEnableDesktopApp.Item(i) + "</li> <br/>")
                'Next

            End If

            Dim x As Integer

            Dim strXml As String
            Dim strXMLDestop As String
            Dim strXmlWeb As String

            If colEnableWebApp Is Nothing And colEnableDesktopApp Is Nothing Then
                For x = 0 To colEnableWebApplication.Count - 1
                    strXmlWeb = strXmlWeb + "<List>" & colEnableWebApplication(x) _
                                & "</List>"
                Next


                'For x = 0 To colEnableDesktopApplication.Count - 1
                '    strXMLDestop = strXMLDestop + "<List>" & colEnableDesktopApplication(x) _
                '                & "</List>"
                'Next
            Else
                For x = 0 To colEnableWebApp.Count - 1
                    strXmlWeb = strXmlWeb + "<List>" & colEnableWebApp(x) _
                                & "</List>"
                Next


                'For x = 0 To colEnableDesktopApp.Count - 1
                '    strXMLDestop = strXMLDestop + "<List>" & colEnableDesktopApp(x) _
                '                & "</List>"
                'Next

            End If





            strXml = "<EmailTemplate><Name>" & strName & "</Name>" _
                    & "<WebApplication>" & strXmlWeb & "</WebApplication>" _
                    & "<DesktopApplication>" & strXMLDestop & "</DesktopApplication>" _
                    & "<Address>" & strAddress & "</Address>" _
                    & "<LoginID>" & strLogin & "</LoginID>" _
                    & "<Password>" & strpas1 & "</Password>" _
                    & "<Phone>" & strPhone & "</Phone></EmailTemplate>"


            Dim objxml As New XmlDocument
            Dim objxsl As New XslTransform

            objxsl.Load(Server.MapPath("\Data\xml\serviceenable.xsl"))
            objxml.LoadXml(strXml)

            Dim xslArglist As New XsltArgumentList

            xslArglist.AddParam("WebServicesList", "", sbEnableWebApplication.ToString)
            xslArglist.AddParam("DesktopApplicationList", "", sbEnableDesktopApplication.ToString)
            xslArglist.AddParam("CustomerName", "", strName)
            xslArglist.AddParam("Phone", "", strPhone)
            'xslArglist.AddParam("Password", "", strpas1)

            Dim sb As New StringBuilder(1000)
            Dim sw As New System.IO.StringWriter(sb)

            objxsl.Transform(objxml.CreateNavigator, xslArglist, sw, Nothing)
            'objxsl.Transform(objxml.CreateNavigator, xslArglist, Response.Output, Nothing)

            'objEmail.SendToClient(strEmail, useremail, sb.ToString, strTemplateSubject)

            Return sb.ToString
            objCustomer.InsertEmailLog(intCustomerID, "LGIN", strMessage)
        End If

        'ElseIf strStatus = "Disable" Then

        '    Dim StrServisename As String
        '    Dim strEmailTemplate As String
        '    Dim strTemplateSubject As String, intActive As Integer
        '    Dim dsEmailContent As DataSet
        '    dsEmailContent = objCustomer.SelectEmailContent("DISB")
        '    strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        '    strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")
        '    intActive = dsEmailContent.Tables(0).Rows(0).Item("Active")

        '    If intActive <> 0 Then


        '        Dim dsCustomers As DataSet
        '        Dim strMessage As String
        '        Dim strName As String
        '        Dim strLogin As String
        '        Dim strPassowrd As String

        '        dsCustomers = objCustomer.SelectCustomers(intCustomerID)
        '        strName = dsCustomers.Tables(0).Rows(0).Item("Name")
        '        strLogin = dsCustomers.Tables(0).Rows(0).Item("cart_customer_uid")
        '        strPassowrd = dsCustomers.Tables(0).Rows(0).Item("cart_customer_pass")


        '        Dim strpas1 As String = objCustomer.Crypt(strLogin, strPassowrd)

        '        Dim i As Integer


        '        For i = 0 To colDisableWebApplication.Count - 1
        '            Dim strDisableWebApplicatiion As String
        '            strDisableWebApplicatiion = colDisableWebApplication.Item(i)
        '            sbDisableWebApplication.Append("<li>" + strDisableWebApplicatiion + "<BR>")
        '            Dim dt3 As DataTable
        '            dt3 = objCustomer.GetCustomerServiceExpiryDate(0, 0, intCustomerID, strDisableWebApplicatiion)
        '            Dim strServiceExpiryDate As String = dt3.Rows(0).Item("DueDate")
        '            sbDisableWebApplication.Append(strServiceExpiryDate & "<br>")
        '            Dim m As String = sbDisableWebApplication.ToString
        '        Next

        '        Dim strbuilder As New StringBuilder(strEmailTemplate)
        '        strbuilder.Replace("[Name]", strName).ToString()
        '        strbuilder.Replace("[LoginID]", strLogin).ToString()

        '        strbuilder.Replace("[WebServices]", sbDisableWebApplication.ToString)
        '        strMessage = strbuilder.ToString

        '        objEmail.SendToClient(strEmail, useremail, strMessage, strTemplateSubject)
        '        objCustomer.InsertEmailLog(intCustomerID, "DISB", strMessage)

        '    End If
        '   End If

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




End Class
