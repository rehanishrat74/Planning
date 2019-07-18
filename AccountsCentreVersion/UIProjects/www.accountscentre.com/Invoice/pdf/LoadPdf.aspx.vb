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
            Session("Ex") = ex.Message

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


        If report_type = "Inv" Then
            templateHTML = Replace(templateHTML, "<!--INVOICEHEADING-->", "SERVICE INVOICE/PRODUCT INVOICE")
            '' fix contains the html for invoice table initial row
            fix = "<table border='0' width='100%' id='table5' cellspacing='2' cellpadding='0' class='constanttable'><tr><td class='constheadtd'>No.</td><td class='constheadtd'>Product Description</td><td class='constheadtd'>Quantity</td><td class='constheadtd'>Net</td><td class='constheadtd'>VAT</td><td class='constheadtd'>Amount</td></tr><!--APPEND-->"
            templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", fix)
        End If

        If report_type = "Crd" Then
            templateHTML = Replace(templateHTML, "<!--INVOICEHEADING-->", "SERVICE CREDIT NOTE/PRODUCT CREDIT NOTE")
            fix = "<table border='0' width='100%' id='table5' cellspacing='2' cellpadding='0' class='constanttable'><tr><td class='constheadtd'>No.</td><td class='constheadtd'>Service Description</td><td class='constheadtd'>Quantity</td><td class='constheadtd'>Net</td><td class='constheadtd'>VAT</td><td class='constheadtd'>Amount</td></tr><!--APPEND-->"
            templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", fix)
        End If
        If report_type = "Acm" Then
            templateHTML = Replace(templateHTML, "<!--INVOICEHEADING-->", "ACCUMULATED INVOICE")
            fix = "<table border='0' width='100%' id='table5' cellspacing='2' cellpadding='0' class='constanttable'><tr><td class='constheadtd'>No.</td><td class='constheadtd'>Service Description</td><td class='constheadtd'>Quantity</td><td class='constheadtd'>Net</td><td class='constheadtd'>VAT</td><td class='constheadtd'>Amount</td></tr><!--APPEND-->"
            templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", fix)

        End If

        If report_type = "Srv" Then
            templateHTML = Replace(templateHTML, "<!--INVOICEHEADING-->", "SERVICE INVOICE")
            fix = "<table border='0' width='100%' id='table5' cellspacing='2' cellpadding='0' class='constanttable'><tr><td class='constheadtd'>No.</td><td class='constheadtd'>Service Description</td><td class='constheadtd'>Quantity</td><td class='constheadtd'>Net</td><td class='constheadtd'>VAT</td><td class='constheadtd'>Amount</td></tr><!--APPEND-->"
            templateHTML = Replace(templateHTML, "<!--PRODUCTLIST-->", fix)
        End If

        Dim drCust As SqlDataReader

        Try
            drCust = objUser.AccGetCustomerData(CustomerID)
            With drCust
                If .Read Then
                    CustomerName = drCust.Item("name").ToString() ' customer name
                    street = drCust.Item("Street").ToString() ' street
                    postal = drCust.Item("PostCode").ToString() ' postal
                    city = drCust.Item("town").ToString() ' town
                    country = drCust.Item("country").ToString() ' country
                    TelNo = drCust.Item("telephone").ToString() ' telephone
                End If
            End With
        Catch ex As Exception
        Finally
            drCust.Close()
        End Try

        '' if there exists an invoice then process it
        If (isInvoiceData) Then

            '' Run the process for all rows
            With invoice_data
                Do
                    '' for each row in the dataset add html for row
                    '' make the tables ( products table's html from the dataset number of rowxs
                    fix = "<tr><td><!--NO--></td><td><!--SD--></td><td><!--QTY--></td><td><!--net--></td><td><!--vat--></td>	<td><!--total--></td></tr><!--APPEND--><!--ENDTABLE-->"

                    templateHTML = Replace(templateHTML, "<!--APPEND-->", fix)

                    SD = .Item("details").ToString() ' description
                    Quantity = .Item("qty").ToString() ' TID
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
                    templateHTML = Replace(templateHTML, "<!--INVOICENO-->", InvoiceNo)
                    templateHTML = Replace(templateHTML, "<!--DATE-->", in_date)

                    Try
                        templateHTML = Replace(templateHTML, "<!--IMAGE_SRC-->", "http://localhost/Invoice/pdf/DrawPdfLogo.aspx?customerid=" & CustomerID & "&Currenttime=" & Now.ToString)
                    Catch ex As Exception

                    End Try

                    templateHTML = Replace(templateHTML, "<!--NO-->", InvoiceNo)
                    templateHTML = Replace(templateHTML, "<!--SD-->", SD)
                    templateHTML = Replace(templateHTML, "<!--QTY-->", Quantity)
                    templateHTML = Replace(templateHTML, "<!--net-->", Net)
                    templateHTML = Replace(templateHTML, "<!--vat-->", Vat)
                    templateHTML = Replace(templateHTML, "<!--total-->", Total)

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

        Dim endhtm As String = "<tr></<tr><tr></tr><tr><td colspan=4></td><td class='constheadtd'>Total Net </td><td class='constheadtd'>Total Vat </td></tr><tr><td colspan=4></td><td><!--TN--></td><td><!--TV--></td></tr><tr><td colspan=4></td><td class='constheadtd'>Grand Total</td><td><!--TGT--></td></tr>"
        templateHTML = Replace(templateHTML, "<!--APPEND-->", "<!--BOTTOM--></table>")

        templateHTML = Replace(templateHTML, "<!--BOTTOM-->", endhtm)
        templateHTML = Replace(templateHTML, "<!--TN-->", sn.ToString)   ' total net
        templateHTML = Replace(templateHTML, "<!--TV-->", sv.ToString)   ' total vat
        templateHTML = Replace(templateHTML, "<!--TGT-->", st.ToString)  ' total gross amount ( small box)


        'Response.Write(templateHTML)
        '''''''''''''''''''''''''''''''Save as pdf

        Dim pdf_doc2 As New Doc
        Dim strtempfilename As String = Server.MapPath("\invoice\pdf\temp_" & customerid & ".pdf")

        Dim finfo As New FileInfo(strtempfilename)
        If (finfo.Exists) Then
            finfo.Delete()
        End If
        finfo = Nothing

        'invoice_data.Close()
        'Response.Redirect("/Invoice/pdf/DrawPdfLogo.aspx?customerid=" & CustomerID & "&Currenttime=" & Now.ToString)
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

        invoice_data.Close()
    End Sub
End Class
