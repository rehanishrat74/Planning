Option Explicit On 
Option Strict Off

Imports System.IO
Imports System.Text

Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Imports System.Web.UI.WebControls

Public Class Products
    '  Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim site_name, site_code, site_url, domain_name As String
    Public _objTCP As TrackerCustomerPoint
    Public objPlanvb As Plan
  
    Protected WithEvents Caption As System.Web.UI.WebControls.Label
    Protected WithEvents historytable As System.Web.UI.WebControls.Table
    Protected WithEvents myHistoryPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected Shared WithEvents dgProduct As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgProductChildGrid As System.Web.UI.WebControls.DataGrid
    Dim dateStart As String
    Dim ds_domain As DataSet
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents url As System.Web.UI.WebControls.Label
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow

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

        Page.Trace.Write("In Page Load")


        CurPage = 2
        CurItem = 0
        Dim dataTblMerchantInfo As System.Data.DataTable

        Try
            dataTblMerchantInfo = _objTCP.getMerchantInformation(GetConnectionData)
            If dataTblMerchantInfo.Rows.Count > 0 Then
                domain_name = dataTblMerchantInfo.Rows(0).Item("domain_name")
                Session("Domain") = domain_name
                site_url = "http://" + domain_name
                Page.Trace.Write("url = " & site_url)

                If Not Request.QueryString("MID") Is Nothing Then

                    Session("TrackProduct") = True


                    ds_domain = Me.GetCurrentSessions(Me.domain_name)
                    If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                        dateStart = Date.Now.AddDays(-10).ToLongDateString + " " + "00:00:00.000"
                        Session("SessionStart") = dateStart
                        LoadProductParentGridByProductData(dateStart)

                        Caption.Text = "Products"
                    End If

                End If
            End If

            If Not Request.QueryString("ProductSession") Is Nothing Then
                LoadProductChildGridByProductData(Request.QueryString("ProductSession"))
                Caption.Text = "Products Detail"
            End If

            If Not Request.QueryString("OrderbyProductId") Is Nothing Then
                LoadVisitChildGridByOrderData(Request.QueryString("OrderbyProductId"))
                Caption.Text = "Order Details"
            End If

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("In Page Load End ")

    End Sub

    Private Function LoadVisitChildGridByOrderData(ByVal _ProductID As String) As String

        Page.Trace.Write("In LoadCustomerSpecificSessionActivity")
        Dim _dsOrder As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.DTChildGridByOrderData()

        Try
            Dim sb As StringBuilder
            Dim sw As StringWriter

            Dim parseComp As String
            _dsOrder = _objTCP.GetVisitChildOrderDetailByProduct(GetConnectionData, Session("SessionStart"), _ProductID)
            If Not _dsOrder Is Nothing And _dsOrder.Tables.Count = 1 Then
                Me.GetProductDetail(_dsOrder.Tables(0))
                Dim dr As DataRow
                For Each dr In _dsOrder.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno


                    Dim Customer As String = dr("Customer") & ""
                    temp_dr("Customer") = Customer

                    Dim CustomerID As String = dr("CustomerID") & ""
                    temp_dr("CustomerID") = CustomerID

                    Dim OrderId As String = dr("OrderId") & ""
                    temp_dr("OrderId") = OrderId

                    Dim OrderDate As String = dr("OrderDate") & ""
                    temp_dr("OrderDate") = OrderDate

                    Dim ProductId As String = dr("ProductId").ToString().Trim() & ""

                    Dim ProductCode As String = dr("ProductCode") & ""
                    temp_dr("ProductCode") = ProductCode

                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If ProductId = "0" Then
                        temp_dr("ProductName") = "&nbsp;"
                    Else
                        temp_dr("ProductName") = "<a href='" & site_url & "/?ProURL_ID=" & ProductId & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)
                Next
            End If
            dt.AcceptChanges()

            dgProductChildGrid.DataSource = dt
            dgProductChildGrid.DataBind()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSessionActivity End")

    End Function

    Private Function DTChildGridByOrderData() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Customer", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("OrderId", Type.GetType("System.String"))
            dt.Columns.Add("OrderDate", Type.GetType("System.String"))
            '   dt.Columns.Add("ProductId", Type.GetType("System.String"))
            dt.Columns.Add("ProductCode", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Shared Sub dgProduct_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgProduct.SortCommand

        Dim _instanceWebTracker As New Products

        _instanceWebTracker.SortColumn(e.SortExpression)
    End Sub

    Private Function SortColumn(ByVal expresssion As String) As String

        Try


            Dim order As String = IIf(Session("SortOrder") Is Nothing, "DESC", Session("SortOrder"))

            Dim DataTable1 As DataTable

            DataTable1 = Me.GetOrderParentGridData(Session("Domain"), Session("SessionStart"))

            Dim view As DataView = DataTable1.DefaultView
            view.Sort = expresssion & " " & order
            dgProduct.DataSource = view

            dgProduct.DataBind()
            Session("SortOrder") = IIf(order = "DESC", "ASC", "DESC")
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Function

    Private Function DTChildGridByOrderData1() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Customer", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("OrderId", Type.GetType("System.String"))
            dt.Columns.Add("OrderDate", Type.GetType("System.String"))
            '   dt.Columns.Add("ProductId", Type.GetType("System.String"))
            dt.Columns.Add("ProductCode", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function LoadProductParentGridByProductData(ByVal dateStart As String) As String
        Page.Trace.Write("In LoadCustomerSpecificSession")
        Try
            dgProduct.DataSource = GetOrderParentGridData(Me.domain_name, dateStart)
            dgProduct.DataBind()
            dgProduct.Visible = True

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSession End")

    End Function

    Public Function GetOrderParentGridData(ByVal DomainName As String, ByVal dateStart As String) As DataTable

        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.DTParentGrid()

        Try



            ds = _objTCP.GetProductParentGridData(GetConnectionData, DomainName, dateStart)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer

                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno


                    Dim _Productid As String = dr("Productid") & ""
                    temp_dr("Productid") = _Productid


                    Dim VisitCount As String = dr("VisitCount") & ""
                    Dim ProductCount As New StringBuilder
                    ProductCount.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
                    ProductCount.Append(" <tr>")
                    ProductCount.Append(" <td align='center'>")
                    ProductCount.Append(" <a HREF=javascript:ProductDetail('" & _Productid & "','" & "Products.aspx" & "') class='bottomlnk' id=" & _Productid & ">" & VisitCount & "   </a> &nbsp;")
                    ProductCount.Append(" </td>")
                    ProductCount.Append(" </tr>")
                    ProductCount.Append("</table>")
                    temp_dr("VisitCount") = ProductCount.ToString




                    '*

                    Dim _orderCount As Integer = Me.GetOrderCountByProduct(Session("SessionStart"), _Productid)
                    Dim TotalOrders As String = _orderCount

                    Dim Order As New StringBuilder

                    If TotalOrders = "0" Then

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'  >")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center' class='bottomlnk'>")
                        Order.Append("0 ")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")
                        temp_dr("TotalOrder") = Order.ToString
                    Else

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center'>")
                        Order.Append(" <a HREF=javascript:OrderbyProductId('" & _Productid & "','" & "Products.aspx" & "') class='bottomlnk' id=" & _Productid & ">" & TotalOrders & "   </a> &nbsp;")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")
                        temp_dr("TotalOrder") = Order.ToString
                    End If
                    '*

                    Dim productID As String = dr("Productid").ToString().Trim() & ""
                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If productID = "0" Then
                        temp_dr("ProductName") = "&nbsp;"
                    Else
                        temp_dr("ProductName") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception

        End Try
    End Function

    Public Function GetOrderCountByProduct(ByVal StartDate As String, ByVal Productid As String) As Integer
        Page.Trace.Write("In GetOrderCountByProduct")

        Try

            Dim OrderCount As Int32
            OrderCount = _objTCP.GetVisitOrderCountByProduct(GetConnectionData, StartDate, Productid)
            Page.Trace.Write("OrderCount :" & OrderCount)
            Return OrderCount
        Catch ex As Exception
            Page.Trace.Warn("Exception  :" & ex.Message)
        End Try
        Page.Trace.Write("GetVisitOrderCountByProduct End")
    End Function

    Private Function LoadProductChildGridByProductData(ByVal _ProID As String) As String
        Page.Trace.Write("In LoadCustomerSpecificSession")
        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.DTChildGridByProductData()

        Try
            Dim a As String

            Dim sb As StringBuilder
            Dim sw As StringWriter

            Dim parseComp As String
            ds = _objTCP.GetProductChildCustomerDetail(GetConnectionData, Session("SessionStart"), Me.domain_name, _ProID)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    If dr("referrer") <> "" And dr("ProductId") <> "0" Then
                        ' Start Condition 
                        Dim temp_dr As DataRow
                        Dim Product As String

                        temp_dr = dt.NewRow()
                        Dim sno As String = counter
                        temp_dr("Sr") = sno

                        Dim startedTime As String = dr("TimeStamp") & ""
                        temp_dr("StartedTime") = startedTime

                        Dim fromURL As String = dr("referrer") & ""
                        If fromURL = "/" Then
                            fromURL = "Default.aspx"
                        End If
                        temp_dr("FromURL") = fromURL

                        Dim ip As String = dr("ip") & ""
                        temp_dr("IP") = ip

                        Dim _countryName As String
                        If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                        temp_dr("Country") = _countryName

                        Dim cusomterid As String = dr("customer_uid") & ""
                        temp_dr("CustomerID") = cusomterid

                        Dim productID As String = dr("ProductId").ToString().Trim() & ""
                        Dim productName As String = dr("ProductName").ToString().Trim() & ""
                        If productID = "0" Then
                            temp_dr("Product") = "&nbsp;"
                        Else
                            temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                        End If
                        counter += 1
                        dt.Rows.Add(temp_dr)
                    End If
                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()

            dgProductChildGrid.DataSource = dt
            dgProductChildGrid.DataBind()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSession End")

    End Function

    Private Function DTParentGrid() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))


            dt.Columns.Add("Productid", Type.GetType("System.String"))
            dt.Columns.Add("VisitCount", Type.GetType("System.String"))
            dt.Columns.Add("TotalOrder", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))


            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function DTChildGridByProductData() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("Product", Type.GetType("System.String"))
            dt.Columns.Add("FromURL", Type.GetType("System.String"))
            dt.Columns.Add("StartedTime", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))


            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetCurrentSessions(ByVal _DomainName As String) As DataSet

        Dim ds As DataSet
        Try
            ds = _objTCP.GetCurrentSessions(GetConnectionData, _DomainName)
            Return ds
        Catch ex As Exception

            Page.Trace.Warn("Exception :" & ex.Message)

        Finally
        End Try
    End Function

    Private Sub GetProductDetail(ByRef drs As DataTable)

        Page.Trace.Write("In GetProductDetail")
        Dim ds As DataSet
        Try

            Dim _ProductIDAsXML As String = GetProductIDAsXML(drs)
            ds = _objTCP.GetProductDetailByProductIDs(GetConnectionData, _ProductIDAsXML)

            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim drToUpdate As DataRow
                    For Each drToUpdate In drs.Rows
                        If dr("product_id").ToString().Trim() = drToUpdate("ProductId").ToString().Trim() Then
                            drToUpdate("ProductName") = dr("cart_product_name")
                        End If
                    Next
                Next
            End If

            drs.AcceptChanges()

        Catch ex As Exception

            Throw ex
        Finally
        End Try

    End Sub

    Private Function GetProductIDAsXML(ByRef drs As DataTable) As String


        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter
            Dim xw As XmlTextWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)
            xw = New XmlTextWriter(sw)

            xw.WriteStartElement("Root")
            Dim dr As DataRow
            For Each dr In drs.Rows
                xw.WriteStartElement("Product")
                xw.WriteAttributeString("id", dr("ProductId").ToString().Trim())
                xw.WriteEndElement()
            Next
            xw.WriteEndElement()

            Return sb.ToString()

        Catch ex As Exception
        End Try

    End Function

End Class
