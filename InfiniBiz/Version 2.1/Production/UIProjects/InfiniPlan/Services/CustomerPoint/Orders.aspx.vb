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

Public Class Orders
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

#Region "Variables"

    Public _objTCP As TrackerCustomerPoint
    Dim SessionStart As String
    Dim SessionEnd As String
    Dim dateStart As String

    Shared dsProduct As DataSet
    Dim strSelection As String
    Protected WithEvents Username As System.Web.UI.WebControls.Label
    Dim DataView1 As DataView
    Protected WithEvents ShowHistory As System.Web.UI.WebControls.Button
    Dim pass As String
    Dim site_name, site_code, site_url, domain_name As String
    Dim bol, bol1, bol2 As Boolean
    Dim sessionInfo As New com.webtracker.webservices.sessionInfo
    Dim WebTrackerServices As New com.webtracker.webservices.WebTrackerServices
    Dim trackInfo As com.webtracker.webservices.trackInfo
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected Shared WithEvents dgOrder As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgOrderChildGrid As System.Web.UI.WebControls.DataGrid

    Protected WithEvents lblOption As System.Web.UI.WebControls.Label
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Dim detailInfo As New com.webtracker.webservices.detailInfo
    Protected WithEvents mpHoriz As Microsoft.Web.UI.WebControls.MultiPage
    Protected WithEvents myCurrentPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents historytable As System.Web.UI.WebControls.Table
 
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel

    Protected WithEvents myHistoryPanel As System.Web.UI.WebControls.Panel
   
 
    Protected WithEvents SessionTable As System.Web.UI.WebControls.Table
    Dim ContentToWrite As String = String.Empty
    Dim isession As Integer
    Dim _xmldoc As New XmlDocument
    Dim _xmlElement1 As XmlElement
    Dim _xmlAttribute1 As XmlAttribute
    Protected WithEvents Caption As System.Web.UI.WebControls.Label
    Dim dstest As DataSet

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Page.Trace.Write("In Page Load")
 
        Dim dataTblMerchantInfo As System.Data.DataTable

        Try
            dataTblMerchantInfo = _objTCP.getMerchantInformation(GetConnectionData)
            If dataTblMerchantInfo.Rows.Count > 0 Then
                domain_name = dataTblMerchantInfo.Rows(0).Item("domain_name")
                Session("Domain") = domain_name
                site_url = "http://" + domain_name
                Page.Trace.Write("url = " & site_url)

            End If


            If Not Request.QueryString("MID") Is Nothing Then
                Page.Trace.Write("In lbtnProduct_Click")
                Session("TrackProduct") = True
                Dim dPreMonth As New Date
                Dim ds_domain As DataSet
                ds_domain = Me.GetCurrentSessions(Me.domain_name)
                If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                    dateStart = Date.Now.AddDays(-10).ToLongDateString + " " + "00:00:00.000"
                    Session("SessionStart") = dateStart
                    LoadOrderParentGridByOrderData(dateStart)
                End If
                Caption.Text = "Orders"
            End If



            If Not Request.QueryString("OrderSession") Is Nothing Then
                LoadOrderChildGridByOrderData(Request.QueryString("OrderSession"))
                Caption.Text = "Order Details"
            End If

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("In Page Load End ")

    End Sub
 
    Private Shared Sub dgOrder_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgOrder.SortCommand

        Dim _instanceWebTracker As New Orders

        _instanceWebTracker.SortColumn(e.SortExpression)
    End Sub
    Private Function SortColumn(ByVal expresssion As String) As String


        Dim order As String = IIf(Session("SortOrder") Is Nothing, "DESC", Session("SortOrder"))

        Dim DataTable1 As DataTable

        DataTable1 = Me.GetOrderParentGridData(Session("Domain"), Session("SessionStart"))

        Dim view As DataView = DataTable1.DefaultView
        view.Sort = expresssion & " " & order
        dgOrder.DataSource = view

        dgOrder.DataBind()
        Session("SortOrder") = IIf(order = "DESC", "ASC", "DESC")
    End Function
    Private Function GetCurrentSessions(ByVal _DomainName As String) As DataSet

        Dim ds As DataSet
        Try
            ds = BLLRules.WebTracker.GetCurrentSessions(GetConnectionData, _DomainName)
            Return ds
        Catch ex As Exception

            Page.Trace.Warn("Exception :" & ex.Message)

        Finally
        End Try
    End Function
 
    ' Parent order
    Private Function LoadOrderParentGridByOrderData(ByVal dateStart As String) As String

        Page.Trace.Write("In ExecuteForProduct_History")
        Try
            dgOrder.AllowSorting = True
            dgOrder.DataSource = Me.GetOrderParentGridData(Me.domain_name, dateStart)
            dgOrder.DataBind()
            dgOrder.Visible = True

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForProduct_History End")
    End Function
    Private Function GetOrderParentGridData(ByVal DomainName As String, ByVal dateStart As String) As DataTable
        Dim dt As DataTable = Me.DTParentGrid()
        Dim dsProduct As DataSet
        Dim counter As Integer = 1
        Try
            dsProduct = _objTCP.GetOrderParentGridData(GetConnectionData, dateStart, DomainName)

            If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

                Dim dr As DataRow
                For Each dr In dsProduct.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    temp_dr = dt.NewRow()

                    Dim _CheckorderCount As Integer = Me.GetOrderCount(Session("SessionStart"), CStr(dr("UniQueSession")))
                    If _CheckorderCount > 0 Then

                        Dim sno As String = counter
                        temp_dr("Sr") = sno


                        Dim UniQueSession As String = dr("UniQueSession") & ""
                        temp_dr("UniQueSession") = UniQueSession

                        Dim _orderCount As Integer = Me.GetOrderCount(Session("SessionStart"), UniQueSession)
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
                            temp_dr("TotalOrders") = Order.ToString
                        Else

                            Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
                            Order.Append(" <tr>")
                            Order.Append(" <td align='center'>")
                            Order.Append(" <a HREF=javascript:OrdersDetail('" & UniQueSession & "','" & "Orders.aspx" & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalOrders & "   </a> &nbsp;")
                            Order.Append(" </td>")
                            Order.Append(" </tr>")
                            Order.Append("</table>")
                            temp_dr("TotalOrders") = Order.ToString
                        End If

                        Dim _ip As String = dr("IP") & ""
                        temp_dr("IP") = _ip

                        Dim _countryName As String
                        If dr("Country") = "" Then _countryName = "N/A" & "" Else _countryName = dr("Country") & ""
                        temp_dr("Country") = _countryName




                        counter += 1S
                        dt.Rows.Add(temp_dr)
                    End If


                    '    End If



                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
    End Function
    Private Function DTParentGrid() As System.Data.DataTable

        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("UniQueSession", Type.GetType("System.String"))
            dt.Columns.Add("TotalOrders", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' Child order
    Private Function LoadOrderChildGridByOrderData(ByVal _CustID As String) As String

        Page.Trace.Write("In LoadCustomerSpecificSessionActivity")
        Dim _dsOrder As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.DTChildGridByOrderData()

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter



            Dim parseComp As String
            _dsOrder = _objTCP.GetOrderChildCustomerDetail(GetConnectionData, Session("SessionStart"), _CustID)
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

            dgOrderChildGrid.DataSource = dt
            dgOrderChildGrid.DataBind()

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

    'Order Count and Detail
    Public Function GetOrderCount(ByVal StartDate As String, ByVal Customerid As String) As Integer
        Page.Trace.Write("In GetOrderCount")

        Try

            Dim OrderCount As Int32
            OrderCount = _objTCP.GetVisitOrderCount(GetConnectionData, StartDate, Customerid)
            Page.Trace.Write("OrderCount :" & OrderCount)
            Return OrderCount
        Catch ex As Exception
            Page.Trace.Warn("Exception  :" & ex.Message)
        End Try
        Page.Trace.Write("GetOrderCount End")
    End Function

    'Product Names
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
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
        Page.Trace.Write("GetProductDetail End")
    End Sub
    Private Function GetProductIDAsXML(ByRef drs As DataTable) As String

        Page.Trace.Write("In GetProductIDAsXML")
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
            Page.Trace.Warn("EXception : " & ex.Message)
        End Try

    End Function



    Private Sub InitializeComponent()

    End Sub
End Class




