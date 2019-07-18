Imports InfiniLogic.AccountsCentre.BLL
Imports WebSupergoo.ABCpdf4
Imports System.IO
Imports System.Data.SqlClient

Public Class LoadPdf
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

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

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            CreatePDF(CInt(Request.Item("orderID")), CInt(Request.Item("invoiceNo")), CChar(Request.Item("chInvoice")))
        Catch ex As Exception
            ' Session("Ex") = ex.Message

        End Try
    End Sub

    Private Sub CreatePDF(ByVal OrderID As Integer, ByVal InvoiceNo As Integer, ByVal chInvoice As Char)

        Dim objUser As New User

        Dim invoice_data As SqlDataReader  'DataSet
        Dim CustomerName As String = " "
        Dim street As String = " "
        Dim postal As String = " "
        Dim city As String = " "
        Dim country As String = " "
        Dim TelNo As String = " "

        Dim SD As String = " " ' Service description
        Dim Quantity As String = " "
        Dim Net As String = " "
        Dim Vat As String = " "
        Dim Total As String = " "
        ' Dim COM_VAT_NO As String
        Dim in_date As String
        'Dim cont_name As String
        Dim templateHTML As String
        Dim replace1 As String
        Dim replace2 As String
        Dim teststr As String '' 
        Dim snet As String = Net
        Dim svat As String = Vat
        Dim stotal As String = Total
        Dim sn, sv, st As Double

        Try
            invoice_data = objUser.AccGetInvoiceRptPdf(InvoiceNo, chInvoice)

        Catch ex As Exception
            invoice_data.Close()
            Exit Sub
        End Try

        '  invoice_data = objUser.AccGetInvoiceRptPdf(InvoiceNo, chInvoice)

        Dim drHtml As SqlDataReader

        Try
            ' my
            drHtml = objUser.AccGetInvoicePdfTemplate
            'Dim dtHtml As DataTable = objUser.AccGetInvoicePdfTemplate
            '' Here is the base 64 encoded string
            If drHtml.Read Then
                teststr = drHtml.Item(0)
            End If
            'teststr = dtHtml.Rows(0).Item(0)

            drHtml.Close()

        Catch EX As Exception
            drHtml.Close()
            ' Response.Redirect("www.accountscentre.com/AccountsPro/Default.aspx")
            Exit Sub

        End Try

        '' Convert base 64  to string
        templateHTML = System.Text.Encoding.ASCII.GetString(System.Convert.FromBase64String(teststr))

        '' Insert the table html in the given edited template
        '' Fixed html which we will insert our tables through the given html

        '' replace 1 holds the html for displaying customer information
        replace1 = "<table ><tr><td><!--CustomerName--><br></td></tr><tr><td><!--Street--><br></td></tr><tr><td><!--Postal--><br></td></tr><tr><td><!--City--><br></td></tr><tr><td><!--Country--><br></td></tr><tr><td><!--Email--><br></td></tr></table>"

        '' Report text to be fixed depending on the invoice type

        Dim report_type As String '= invoice_data.Tables(0).Rows(0).Item("Inv_Type")
        Dim fix As String
        Dim isInvoiceData As Boolean
        isInvoiceData = False   ' Mark as data already read

        If invoice_data.Read Then
            report_type = invoice_data.Item("Inv_Type")
            isInvoiceData = True
        End If


        templateHTML = Replace(templateHTML, "<!--INVOICEHEADING-->", "SERVICE INVOICE/PRODUCT INVOICE")
        '' fix contains the html for invoice table initial row
        fix = "<table border='0' width='100%' id='table5' cellspacing='2' cellpadding='0' class='constanttable'><tr><td class='constheadtd' align='left' width='7%'>No.</td><td class='constheadtd'  align='left' width='36%'>Product Description</td><td class='constheadtd' align='right' width='10%'>Quantity</td><td class='constheadtd' align='right' width='15%'>Net</td><td class='constheadtd' align='right'  width='15%'>VAT</td><td class='constheadtd' align='right' width='17%'>Amount</td></tr><!--APPEND-->"
        templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", fix)
        
        Dim drCust As SqlDataReader
        Dim CompanyName, CompanyEmail, CompanyAddress, CompanyState, CompanyZip, _
            CompanyPhone, CompanyFax, CompanyCity, CompanyPostCode, CompanyCountry, _
            CompanyUrl, ContactName As String

        Try
            drCust = objUser.AccGetCustomerData(CustomerID)
            With drCust
                If .Read Then
                    CustomerName = drCust.Item("name").ToString() ' customer name
                    street = drCust.Item("Street").ToString() ' street
                    postal = drCust.Item("PostCode").ToString() ' postal
                    city = drCust.Item("town").ToString() ' town
                    country = drCust.Item("country").ToString() ' country
                    ContactName = drCust.Item("cont_name").ToString()
                    TelNo = drCust.Item("telephone").ToString() ' telephone
                    CompanyName = drCust.Item("CompName").ToString()
                    CompanyAddress = drCust.Item("CompAddress").ToString()
                    CompanyCity = drCust.Item("CompCity").ToString()
                    CompanyState = drCust.Item("CompState").ToString()
                    CompanyCountry = drCust.Item("CompCountry").ToString()
                    CompanyPostCode = drCust.Item("CompPostCode").ToString()
                    CompanyPhone = drCust.Item("CompPhone").ToString()
                    CompanyFax = drCust.Item("CompFax").ToString()
                    CompanyEmail = drCust.Item("CompEmail").ToString()
                    CompanyUrl = drCust.Item("CompWebsite").ToString()
                End If
            End With
        Catch ex As Exception
        Finally
            If Not drCust.IsClosed Then
                drCust.Close()
            End If
        End Try

        Dim SerialNo As Integer = 1

        '' if there exists an invoice then process it
        If (isInvoiceData) Then

            '' Run the process for all rows
            With invoice_data
                Do
                    '' for each row in the dataset add html for row
                    '' make the tables ( products table's html from the dataset number of rowxs
                    fix = "<tr><td align='left'><!--NO--></td><td align='left'><!--SD--></td><td align='right'><!--QTY--></td><td align='right'><!--net--></td><td align='right'><!--vat--></td>	<td align='right'><!--total--></td></tr><!--APPEND--><!--ENDTABLE-->"

                    templateHTML = Replace(templateHTML, "<!--APPEND-->", fix)

                  

                    SD = .Item("details").ToString() ' description
                    Quantity = CInt(.Item("qty")).ToString  ' TID
                    Net = .Item("net").ToString() ' net
                    sn = sn + Net
                    Net = FormatNumber(Net, 2, TriState.False, TriState.False, TriState.False)
                    Vat = .Item("vat").ToString() ' vat
                    Vat = FormatNumber(Vat, 2, TriState.False, TriState.False, TriState.False)
                    sv = sv + Vat
                    Total = .Item("Gross").ToString() ' amount
                    Total = FormatNumber(Total, 2, TriState.False, TriState.False, TriState.False)

                    st = st + Total
                    '''COM_VAT_NO = dsCust.Tables(0).Rows(t).Item(12).ToString()  ' customer name
                    in_date = .Item("inv_date").ToString()

                    Dim time_separator() As String
                    Dim Yes As String = "Yes"
                    Dim width As Integer = 593
                    Dim height As Integer = 103

                    time_separator = in_date.Split(" ") ' get only the date widout the hash and time
                    in_date = time_separator(0)


                    '' Replace variables in html commented tags
                    templateHTML = Replace(templateHTML, "<!--CUSTOMERINFO-->", replace1)
                    templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", replace2)
                    If chInvoice = "N" Then
                        templateHTML = Replace(templateHTML, "<!--INVOICENO-->", "")
                    Else
                        templateHTML = Replace(templateHTML, "<!--INVOICENO-->", InvoiceNo)
                    End If

                    templateHTML = Replace(templateHTML, "<!--DATE-->", in_date)

                    Try
                        templateHTML = Replace(templateHTML, "<!--IMAGE_SRC-->", "http://www.accountscentre.com/PDF/DrawPdfLogo.aspx?customerid=" & CustomerID)
                    Catch ex As Exception

                    End Try

                    templateHTML = Replace(templateHTML, "<!--NO-->", SerialNo)
                    templateHTML = Replace(templateHTML, "<!--SD-->", SD)
                    templateHTML = Replace(templateHTML, "<!--QTY-->", Quantity)
                    templateHTML = Replace(templateHTML, "<!--net-->", Net)

                    If Vat = ".00" Then
                        Vat = "0.00"
                    End If

                    templateHTML = Replace(templateHTML, "<!--vat-->", Vat)
                    templateHTML = Replace(templateHTML, "<!--total-->", Total)


                    SerialNo += 1

                Loop Until .Read = False
            End With

        End If
        templateHTML = Replace(templateHTML, "<!--CustomerName-->", CustomerName)
        templateHTML = Replace(templateHTML, "<!--Street-->", street)
        templateHTML = Replace(templateHTML, "<!--Postal-->", postal)
        templateHTML = Replace(templateHTML, "<!--City-->", city)
        templateHTML = Replace(templateHTML, "<!--Country-->", country)
        templateHTML = Replace(templateHTML, "<!--Tel-->", TelNo)
        templateHTML = Replace(templateHTML, "<!--City-->", city)
        templateHTML = Replace(templateHTML, "Company Name", CompanyName)
        templateHTML = Replace(templateHTML, "Trading Address Line 1", CompanyAddress)
        templateHTML = Replace(templateHTML, "Trading Address Line 2", "")
        templateHTML = Replace(templateHTML, "City", CompanyCity)
        templateHTML = Replace(templateHTML, "State", CompanyState)
        templateHTML = Replace(templateHTML, "Company Name", CompanyCountry)
        templateHTML = Replace(templateHTML, "Zip", CompanyPostCode)
        templateHTML = Replace(templateHTML, "Tel:000-0000", "Tel: " & CompanyPhone)
        templateHTML = Replace(templateHTML, "Fax:000-0000", "Fax: " & CompanyFax)
        templateHTML = Replace(templateHTML, "abc@xyz.com", CompanyEmail)
        templateHTML = Replace(templateHTML, "www.abc.com", CompanyUrl)
        templateHTML = Replace(templateHTML, "<!--CONTACTNAME-->", ContactName)
        If chInvoice = "N" Then
            templateHTML = Replace(templateHTML, "<!--ORDERNO-->", InvoiceNo)
        Else
            templateHTML = Replace(templateHTML, "<!--ORDERNO-->", OrderID)
        End If


        Dim endhtm As String = "<tr></<tr><tr></tr><tr><td colspan=4></td><td class='constheadtd'  align='right'>Total Vat </td><td class='constheadtd'  align='right'>Total Net </td></tr><tr><td colspan=4></td><td align='right'><!--TV--></td><td align='right'><!--TN--></td></tr><tr><td colspan=4></td><td class='constheadtd' align='right'>Grand Total :</td><td  align='right'><!--TGT--></td></tr>"
        templateHTML = Replace(templateHTML, "<!--APPEND-->", "<!--BOTTOM--></table>")

        templateHTML = Replace(templateHTML, "<!--BOTTOM-->", endhtm)

        Dim strSn, strSv, strSt As String
        strSn = sn.ToString
        strSv = sv.ToString
        strSt = st.ToString

        If strSn.IndexOf(".") < 0 Then
            strSn += ".00"
        End If

        If strSv.IndexOf(".") < 0 Then
            strSv += ".00"
        End If

        If strSt.IndexOf(".") < 0 Then
            strSt += ".00"
        End If

        templateHTML = Replace(templateHTML, "<!--TN-->", strSn)   ' total net
        templateHTML = Replace(templateHTML, "<!--TV-->", strSv)   ' total vat
        templateHTML = Replace(templateHTML, "<!--TGT-->", strSt)  ' total gross amount ( small box)


        'Response.Write(templateHTML)
        '''''''''''''''''''''''''''''''Save as pdf

        Dim pdf_doc2 As New Doc
        Dim strtempfilename As String = Server.MapPath("\PDF\temp_" & CustomerID & ".pdf")

        Dim finfo As New FileInfo(strtempfilename)
        If (finfo.Exists) Then
            finfo.Delete()
        End If
        finfo = Nothing

        If Not invoice_data.IsClosed Then
            invoice_data.Close()
        End If


        Dim str As String = Server.MachineName()

        'pdf_doc2.AddImage("http://localhost/PDF/DrawPdfLogo.aspx?customerid=" & CustomerID)
        pdf_doc2.AddImage(templateHTML)

        Try

            'Server.Execute("/members/pdf/DrawPdfLogo.aspx")
            pdf_doc2.Save(strtempfilename)
        Catch ex As Exception

        End Try
        ' pdf_doc2.Clear()
        ''''''''''''''''''''''''''''' Read the pdf
        Dim objFileInfo As System.IO.FileInfo = New System.IO.FileInfo(strtempfilename)
        Dim objFS As FileStream
        Try

            objFS = New FileStream(strtempfilename, FileMode.Open, FileAccess.Read)

        Catch ex As Exception

        End Try
        Dim objBR As New BinaryReader(objFS)
        Dim pdffiledata() As Byte
        pdffiledata = objBR.ReadBytes(objFileInfo.Length)

        objBR.Close()
        objFS.Close()

        If pdffiledata.Length > 1 Then
            With Response
                .Clear()
                .ClearHeaders()
                .ClearContent()
                .ContentType = "application/pdf"
                '.AddHeader("content-disposition", "inline; filename=" & strtempfilename)
                .BinaryWrite(CType(pdffiledata, Byte()))
                .End() ' it is breaking the thread so dont use it 
            End With
        End If


    End Sub
End Class

