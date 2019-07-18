Option Strict Off
Option Explicit On 
Imports System.IO
Imports System.Text

Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Web
Imports System.Xml

Public Class AnalyzerBase

    Dim _Activity As Infinilogic.BusinessPlan.BLLRules.Activity

    Public Function RenderDataGrid(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal _stage As GridStages, ByVal countryName As String) As DataTable
        Dim _dt As DataTable
        Select Case _stage
            Case GridStages.Product
                _dt = RenderDataGridforProduct(Customerid, StartDate, EndDate, DomainName)
            Case GridStages.Order
                _dt = RenderDataGridforOrder(Customerid, StartDate, EndDate, DomainName, countryName)
            Case GridStages.Visit
                _dt = RenderDataGridforVisit(Customerid, StartDate, EndDate, DomainName, countryName)
            Case GridStages.Keywords
                _dt = RenderDataGridforKeywords(Customerid, StartDate, EndDate, DomainName, countryName)
            Case GridStages.Oppertiunity
                _dt = RenderDataGridforOppertiunity(Customerid, StartDate, EndDate, DomainName, countryName)
            Case GridStages.Referrer
                _dt = RenderDataGridforReferrer(Customerid, StartDate, EndDate, DomainName, countryName)
        End Select
        Return _dt
    End Function

    Public Function BuidDataTableProductCatagory() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable

            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            ' dt.Columns.Add("Cat3", Type.GetType("System.String"))
            dt.Columns.Add("Categories", Type.GetType("System.String"))

            ' dt.Columns.Add("Code", Type.GetType("System.String"))
            ' dt.Columns.Add("ProductID", Type.GetType("System.String"))
            ' dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("Count", Type.GetType("System.String"))
            
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    
    Public Function RenderDataGridforProductCatagory(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("Get Parent ProductCatagory Starts ")
        Try

            Dim _dsCategory As DataSet
            Dim _dtCategory As DataTable = Me.BuidDataTableProductCatagory()
            Dim _dsProduct As DataSet = _Activity.RenderDataGridforProduct(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsProduct Is Nothing And _dsProduct.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetailCategory(Customerid, _dsProduct.Tables(0))

            End If

            _dsCategory = _Activity.RenderDataGridforProductCategory(Customerid, System.Web.HttpContext.Current.Session("ProductIDAsXML"))
            If Not _dsCategory Is Nothing And _dsCategory.Tables(0).Rows.Count > 0 Then
                'SSSSSSSSSSSSSSSSSS

                Dim _drCat As DataRow

                For Each _drCat In _dsCategory.Tables(0).Rows


                    Dim _tempRowCat As DataRow
                    _tempRowCat = _dtCategory.NewRow()




                    Dim _count1 As String = counter
                    _tempRowCat("Sr") = _count1


                    Dim _Category As String = _drCat("Categories")


                    Dim _Count As String = _drCat("Count")
                    _tempRowCat("Count") = _Count

                    'Dim _strCount As New StringBuilder
                    '_strCount.Append(String.Format(" <a HREF='javascript:OpenWindow(""" & _Category & """)'   id={0}>" & _Count & "</a>  ", _Category))
                    '_tempRowCat("Count") = _strCount.ToString

                    Dim _sbCategory As New StringBuilder
                    _sbCategory.Append("<table width='100%'><tr><td width='40%'></td><td align='left' class='AnalyzerText' width='60%'>" & _Category.ToString & "</td> </tr></table>")
                    _tempRowCat("Categories") = _sbCategory

                    '_Category = System.Web.HttpUtility.UrlEncode(_Category)
                    Dim chr() As Byte
                    chr = System.Text.ASCIIEncoding.ASCII.GetBytes(_Category)
                    _Category = System.Convert.ToBase64String(chr)

                    Dim _Details As New StringBuilder
                    _Details.Append(String.Format(" <a HREF='javascript:OpenWindow(""" & _Category & """)'   id={0}> <img src='/images/infiniplan/Magnifier.Gif' border=0>  </a>  ", _Category))
                    _tempRowCat("Details") = _Details.ToString

                    counter += 1
                    _dtCategory.Rows.Add(_tempRowCat)

                Next

                'SSSSSSSSSSSSssssss

            End If

            _dtCategory.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent ProductCatagory end")
            Return _dtCategory
        Catch ex As Exception
            Dim _Err As String = ex.Message
            System.Web.HttpContext.Current.Trace.Warn("Get Parent ProductCatagory exception  " & ex.Message)
            Throw ex
        End Try
    End Function


    Private Sub EmptyRowOppertunity1(ByRef row As DataRow)

        row("Category") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Cat3") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("ProductName") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Code") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
        row("Parent") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("ProductId") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

    End Sub


    Public Function BuidDataTableProduct() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("ProductIDs", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("URLs", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforProduct(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("Get Parent Product Starts ")
        Try
            Dim _dtProduct As DataTable = Me.BuidDataTableProduct()
            Dim _dsProduct As DataSet = _Activity.RenderDataGridforProduct(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsProduct Is Nothing And _dsProduct.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetail(Customerid, _dsProduct.Tables(0))
                Dim _dr As DataRow

                For Each _dr In _dsProduct.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtProduct.NewRow()

                    Dim _count As String = counter
                    _tempRow("sr") = _count

                    Dim _customer As String = _dr("CustomerID")
                    _tempRow("CustomerIDs") = _customer

                    'Dim _ProductName As String = _dr("ProductName")
                    '_tempRow("ProductName") = _ProductName

                    Dim productID As String = _dr("ProductId").ToString().Trim() & ""
                    _tempRow("ProductIds") = productID
                    Dim productName As String = _dr("ProductName").ToString().Trim() & ""


                    If productID = "0" Then
                        _tempRow("ProductName") = "&nbsp;"
                    Else
                        _tempRow("ProductName") = productName
                    End If


                    Dim _URL As String = _dr("URL")
                    _tempRow("URLs") = _URL


                    Dim _Detail As New StringBuilder
                    _Detail.Append(" <a HREF=javascript:OpenWindow('" & _customer & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
                    _tempRow("Details") = _Detail.ToString

                    counter += 1
                    _dtProduct.Rows.Add(_tempRow)

                Next
            End If

            _dtProduct.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Product end")
            Return _dtProduct

        Catch ex As Exception
            Dim _Err As String = ex.Message
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Product exception  " & ex.Message)
            Throw ex
        End Try


    End Function

    Public Function BuidDataTableProductOverview() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("ProductIDs", Type.GetType("System.String"))
            dt.Columns.Add("OrderCount", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforProductOverview(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("OverView Product Starts ")
        Try
            Dim _dtProductOverview As DataTable = Me.BuidDataTableProductOverview()
            Dim _dsProductOverview As DataSet = _Activity.RenderDataGridforProductOverView(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsProductOverview Is Nothing And _dsProductOverview.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetail(Customerid, _dsProductOverview.Tables(0))
                Dim _dr As DataRow

                For Each _dr In _dsProductOverview.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtProductOverview.NewRow()

                    Dim _count As String = counter
                    _tempRow("sr") = _count


                    Dim productID As String = _dr("ProductId").ToString().Trim() & ""
                    _tempRow("ProductIds") = productID
                    Dim productName As String = _dr("ProductName").ToString().Trim() & ""


                    If productID = "0" Then
                        _tempRow("ProductName") = "&nbsp;"
                    Else
                        _tempRow("ProductName") = productName
                    End If

                    Dim _orderCount As Integer = Me.GetOrderCountbyProductID(StartDate, EndDate, productID, Customerid)
                    Dim TotalOrders As String = _orderCount

                    _tempRow("OrderCount") = TotalOrders

                    counter += 1
                    _dtProductOverview.Rows.Add(_tempRow)

                Next
            End If

            _dtProductOverview.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("OverView Product end")
            Return _dtProductOverview

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("OverView Product exception " & ex.Message)
            Throw ex
        End Try


    End Function
    Public Function GetOrderCountbyProductID(ByVal StartDate As String, ByVal EndDate As String, ByVal ProductID As String, ByVal Customerid As Integer) As Integer


        Try

            Dim OrderCount As Int32
            OrderCount = _Activity.GetOrderCountbyProductID(StartDate, EndDate, ProductID, Customerid)

            Return OrderCount
        Catch ex As Exception

        End Try

    End Function

    Public Function BuidDataTableOrder() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("OrderIDs", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            '  dt.Columns.Add("Trackid", Type.GetType("System.String"))
            dt.Columns.Add("Customers", Type.GetType("System.String"))


            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforOrder(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("Get Parent orders Starts ")
        Try

            Dim _dtOrder As DataTable = Me.BuidDataTableOrder()
            Dim _list As New ArrayList
            Dim dr As DataRow
            Dim dtCustomerIDs As DataTable

            If CountryName = "Default" Then
                dtCustomerIDs = _Activity.GetOrderCount(Customerid, StartDate, EndDate, DoaminName)

            Else
                dtCustomerIDs = _Activity.GetOrderCountByCountry(Customerid, StartDate, EndDate, DoaminName, CountryName)

            End If
            Dim _dsOrder As DataSet
            _list.Clear()
            Dim counter As Integer = 1
            For Each dr In dtCustomerIDs.Rows
                If Not _list.Contains(dr("CustomerID")) Then
                    _list.Add(dr("CustomerID"))

                    Dim _str As String = dr("CustomerID")
                    ' Dim _dsOrder As DataSet = _Activity.RenderDataGridforOrder(Customerid, StartDate, EndDate, DoaminName)
                    _dsOrder = _Activity.GetCustomerOrderDetail(Customerid, StartDate, EndDate, CStr(dr("CustomerID")))


                    If Not _dsOrder Is Nothing And _dsOrder.Tables(0).Rows.Count > 0 Then
                        Me.GetProductDetail(Customerid, _dsOrder.Tables(0))
                        Dim _dr As DataRow

                        For Each _dr In _dsOrder.Tables(0).Rows

                            Dim _tempRow As DataRow
                            _tempRow = _dtOrder.NewRow()

                            Dim _count As String = counter
                            Dim sno As String = counter
                            _tempRow("Sr") = sno

                            Dim ProductId As String = _dr("ProductId").ToString().Trim() & ""

                            Dim productName As String = _dr("ProductName").ToString().Trim() & ""
                            If ProductId = "0" Then
                                _tempRow("ProductName") = "&nbsp;"
                            Else
                                _tempRow("ProductName") = productName
                            End If

                            Dim OrderId As String = _dr("OrderId") & ""
                            _tempRow("OrderIds") = OrderId

                            Dim _IP As String = dr("IP") & ""
                            _tempRow("IP") = _IP


                            Dim _country As String = dr("country") & ""
                            _tempRow("country") = _country


                            Dim CustomerInfo As String = _dr("Customer")
                            _tempRow("CustomerIDs") = CustomerInfo

                            Dim CustID As String = _dr("Name") & " &nbsp;" & _dr("CustomerID") & ""
                            _tempRow("Customers") = CustID

                            Dim _trackid As String = _dr("Trackid")
                            ' _tempRow("Trackid") = _trackid


                            Dim _Detail As New StringBuilder
                            _Detail.Append(" <a HREF=javascript:OpenOrderWindow('" & OrderId & "','" & _trackid & "')   id=" & CustomerInfo & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
                            _tempRow("Details") = _Detail.ToString


                            _dtOrder.Rows.Add(_tempRow)
                            counter += 1
                        Next
                    End If

                End If

            Next
            _dsOrder.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent orders end")
            Return _dtOrder
        Catch ex As Exception

            System.Web.HttpContext.Current.Trace.Warn("Get Parent orders exception  " & ex.Message)
            Throw ex
        End Try


    End Function

    Public Function BuidDataTableVisit() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("OrderDetails", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Orders", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforVisit(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable
        Try
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Visits Starts ")
            Dim _clist As New ArrayList
            Dim _cid As String = ""
            Dim _dtVisit As DataTable = Me.BuidDataTableVisit()
            Dim _dsVisit As DataSet

            If CountryName = "Default" Then
                _dsVisit = _Activity.RenderDataGridforVisit(Customerid, StartDate, EndDate, DoaminName)

            Else

                _dsVisit = _Activity.RenderDataGridforVisitByCountry(Customerid, StartDate, EndDate, DoaminName, CountryName)

            End If
            Dim counter As Integer = 1
            If Not _dsVisit Is Nothing And _dsVisit.Tables(0).Rows.Count > 0 Then

                Dim _dr As DataRow

                For Each _dr In _dsVisit.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtVisit.NewRow()

                    Dim _count As String = counter
                    _tempRow("Sr") = _count

                    Dim _customer As String = _dr("CustomerID")
                    _tempRow("CustomerIDs") = _customer

                    Dim _country As String = _dr("Country")
                    _tempRow("Country") = _country


                    Dim _ip As String = _dr("ip")
                    _tempRow("ip") = _ip


                    Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
                    Dim TotalOrders As String = _orderCount
                    _tempRow("Orders") = TotalOrders

                    If Not _clist.Contains(_dr("CustomerID")) Then
                        _clist.Add(_dr("CustomerID"))
                        _tempRow("Orders") = TotalOrders
                    Else
                        If TotalOrders = "0" Then _tempRow("Orders") = "0" Else _tempRow("Orders") = "-"
                    End If

                    Dim _custid As New StringBuilder
                    If _dr("CustomerID") = _cid Or _cid = "" Then
                        _cid = _dr("CustomerID")
                    Else
                        _cid = _dr("CustomerID")
                    End If

                    Dim _Detail As New StringBuilder
                    _Detail.Append(" <a HREF=javascript:OpenWindow('" & _customer & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
                    _tempRow("OrderDetails") = _Detail.ToString

                    counter += 1
                    _dtVisit.Rows.Add(_tempRow)
                Next
            End If

            _dsVisit.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Visits end")
            Return _dtVisit
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Parent  Visits exception " & ex.Message)

            Throw ex
        End Try


    End Function

    Public Function BuidDataTableKeywords() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("OrderDetails", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Order", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforKeywords(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable
        Try


            Dim _dtVisit As DataTable = Me.BuidDataTableKeywords()
            Dim _dsVisit As DataSet = _Activity.RenderDataGridforVisit(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsVisit Is Nothing And _dsVisit.Tables(0).Rows.Count > 0 Then

                Dim _dr As DataRow

                For Each _dr In _dsVisit.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtVisit.NewRow()

                    Dim _count As String = counter
                    _tempRow("Sr") = _count

                    Dim _customer As String = _dr("CustomerID")
                    _tempRow("CustomerID") = _customer

                    Dim _country As String = _dr("Country")
                    _tempRow("Country") = _country


                    Dim _ip As String = _dr("ip")
                    _tempRow("ip") = _ip

                    Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
                    Dim TotalOrders As String = _orderCount

                    _tempRow("Order") = TotalOrders

                    Dim _Detail As New StringBuilder
                    _Detail.Append(" <a HREF=javascript:OpenWindow('" & _customer & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
                    _tempRow("OrderDetails") = _Detail.ToString


                    counter += 1
                    _dtVisit.Rows.Add(_tempRow)

                Next
            End If

            _dsVisit.AcceptChanges()
            Return _dtVisit
        Catch ex As Exception
            Dim _Err As String = ex.Message
        End Try


    End Function



    Public Function BuidDataTableOppertiunity() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable '
            ' dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Sid", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("URLs", Type.GetType("System.String"))
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforOppertiunity(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable
        Try
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Opportunity Starts ")
            Dim sid As Integer = 0
            Dim _dtOppertiunity As DataTable = Me.BuidDataTableOppertiunity()
            Dim _dsOppertiunity As DataSet
            If CountryName = "Default" Then
                _dsOppertiunity = _Activity.RenderDataGridforOppertinuty(Customerid, StartDate, EndDate, DoaminName)

            Else
                _dsOppertiunity = _Activity.RenderDataGridforOppertinutyByCountry(Customerid, StartDate, EndDate, DoaminName, CountryName)


            End If

            Dim counter As Integer = 1
            If Not _dsOppertiunity Is Nothing And _dsOppertiunity.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetail(Customerid, _dsOppertiunity.Tables(0))
                Dim _dr As DataRow


                For Each _dr In _dsOppertiunity.Tables(0).Rows

                    Dim _tempRow As DataRow, _nullrow As DataRow
                    _tempRow = _dtOppertiunity.NewRow()

                    Dim _count As String = counter
                    _tempRow("Sr") = _count

                    Dim _Sid As String = _dr("Sid")
                    _tempRow("Sid") = _Sid

                    Dim _customer As String = _dr("CustomerID")
                    _tempRow("CustomerIDs") = _customer

                    Dim _country As String = _dr("Country")
                    _tempRow("Country") = _country


                    Dim _ip As String = _dr("ip")
                    _tempRow("ip") = _ip

                    Dim ProductId As String = _dr("ProductId").ToString().Trim() & ""


                    Dim productName As String = _dr("ProductName").ToString().Trim() & ""
                    If ProductId = "0" Then
                        _tempRow("ProductName") = "&nbsp;"
                    Else
                        _tempRow("ProductName") = productName
                    End If


                    Dim _URL As String = _dr("URL")
                    ' _tempRow("URLs") = _URL

                    Dim _sbURL As New StringBuilder
                    _sbURL.Append("<table width='100%'><tr><td align='left' class='AnalyzerText' width='100%'>" & _URL.ToString & "</td> </tr></table>")
                    _tempRow("URLs") = _sbURL.ToString



                    'Dim _Detail As New StringBuilder
                    '_Detail.Append(" <a HREF=javascript:OpenWindow('" & _customer & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
                    '_tempRow("Details") = _Detail.ToString



                    If _dr("Sid") = sid Or sid = 0 Then
                        sid = _dr("Sid")
                    Else
                        sid = _dr("Sid")
                        _nullrow = _dtOppertiunity.NewRow()
                        EmptyRowOppertunity(_nullrow)
                        _dtOppertiunity.Rows.Add(_nullrow)
                    End If
                    counter += 1
                    _dtOppertiunity.Rows.Add(_tempRow)
                Next
            End If

            _dsOppertiunity.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Opportunity end")
            Return _dtOppertiunity
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Opportunity exception " & ex.Message)
            Throw ex
        End Try


    End Function
    Private Sub EmptyRowOppertunity(ByRef row As DataRow)

        ' row("Details") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Sid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("CustomerIDs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("Country") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
        row("IP") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("ProductName") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        row("URLs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

    End Sub

    Public Function BuidDataTableReferrer() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Sid", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))

            dt.Columns.Add("Orders", Type.GetType("System.String"))



            dt.Columns.Add("Referrers", Type.GetType("System.String"))
            '  dt.Columns.Add("URLs", Type.GetType("System.String"))



            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforReferrer(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal CountryName As String) As DataTable
        Try
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Referrer Starts ")
            Dim _sum As Integer = 0, order As Integer
            Dim _clist As New ArrayList, _rlist As New ArrayList, _c As New ArrayList
            Dim _ref As String = ""
            Dim _cid As String = ""
            Dim _dtReferrer As DataTable = Me.BuidDataTableReferrer()
            Dim _dsReferrer As DataSet


            If CountryName = "Default" Then
                _dsReferrer = _Activity.RenderDataGridforReferrer(Customerid, StartDate, EndDate, DoaminName)

            Else
                _dsReferrer = _Activity.RenderDataGridforReferrerByCountry(Customerid, StartDate, EndDate, DoaminName, CountryName)

            End If

            Dim counter As Integer = 1
            If Not _dsReferrer Is Nothing And _dsReferrer.Tables(0).Rows.Count > 0 Then


                Dim _dr As DataRow
                Dim _rowRef As DataRow
                Dim _rowcid As DataRow

                For Each _dr In _dsReferrer.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtReferrer.NewRow()

                    Dim _count As String = counter
                    _tempRow("Sr") = _count

                    Dim _customer As String = _dr("CustomerID")

                    _tempRow("CustomerIDs") = _customer

                    Dim _Referrerpart As String = _dr("Referrerpart")
                    _tempRow("Referrers") = _Referrerpart

                    Dim _referrer As String = _dr("Referrer")
                    '_tempRow("URLs") = _referrer

                    'Dim _sbURL As New StringBuilder
                    '_sbURL.Append("<table width='100%'><tr><td align='left' class='AnalyzerText' width='100%'>" & _referrer & "</td> </tr></table>")
                    '_tempRow("URLs") = _sbURL.ToString

                    Dim _country As String = _dr("Country")
                    _tempRow("Country") = _country

                    Dim _ip As String = _dr("ip")
                    _tempRow("ip") = _ip

                    Dim _sid As String = _dr("sid")
                    _tempRow("Sid") = _sid

                    'Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
                    'Dim TotalOrders As String = _orderCount
                    '_tempRow("OrdersbyCid") = TotalOrders

                    Dim _orderCount As Integer = Me.GetOrderCountBySessionID(StartDate, EndDate, _sid, _customer, Customerid)   'Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
                    Dim TotalOrders As String = _orderCount
                    _tempRow("Orders") = TotalOrders

                    Dim _custid As New StringBuilder
                    If _dr("CustomerID") = _cid Or _cid = "" Then
                        _cid = _dr("CustomerID")
                        _custid.Append(" <td align='center' class='bottomlnk' width='50%'> ")
                        _custid.Append("  </td>")
                    Else
                        _cid = _dr("CustomerID")
                        _custid.Append(" <td align='center' class='bottomlnk' width='50%'> <img src=/images/infiniplan/asteric.GIF border=0>")
                        _custid.Append("  </td>")
                    End If

                    Dim _Detail As New StringBuilder
                    _Detail.Append("<table><tr><td align='center' class='bottomlnk' width='50%'> <a HREF=javascript:OpenOrderWindowChildReferrer('" & _customer & "','" & _sid & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>   </td> " & _custid.ToString & " </tr></table>")
                    _tempRow("Details") = _Detail.ToString

                    If _dr("Referrerpart") = _ref Or _ref = "" Then
                        _ref = _dr("Referrerpart")
                    Else
                        _ref = _dr("Referrerpart")
                        _rowRef = _dtReferrer.NewRow()
                        EmptyRowReferrer(_rowRef, _sum)
                        _sum = 0
                        _dtReferrer.Rows.Add(_rowRef)
                    End If

                    counter += 1
                    _dtReferrer.Rows.Add(_tempRow)
                Next
            End If
            _dsReferrer.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Referrer end")
            Return _dtReferrer
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Parent Referrer exception  " & ex.Message)
            Throw ex
        End Try
    End Function

    Private Sub EmptyRowReferrer(ByRef rowRef As DataRow, ByVal s As Integer)
        rowRef("Details") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

        rowRef("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRef("CustomerIDs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRef("Sid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

        rowRef("Referrers") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRef("Country") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
        rowRef("IP") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRef("Orders") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        '_tempRow("Sid")

    End Sub
    Private Sub EmptyRowReferrercid(ByRef rowRefcid As DataRow)
        rowRefcid("Details") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRefcid("Sid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

        rowRefcid("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRefcid("CustomerIDs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRefcid("Referrers") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRefcid("Country") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
        rowRefcid("IP") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
        rowRefcid("Orders") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

    End Sub

    Public Function BuidDataTableReferrerOverview() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            '    dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
            dt.Columns.Add("Referrers", Type.GetType("System.String"))
            dt.Columns.Add("Orders", Type.GetType("System.String"))
            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforReferrerOverview(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("OverView  Referrer Starts ")
        Try
            Dim _list As New ArrayList

            Dim _sum As Integer = 0
            Dim _dtReferrerOverview As DataTable = Me.BuidDataTableReferrerOverview()
            Dim _dsReferrerOverview As DataSet = _Activity.RenderDataGridforReferrerOverView(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsReferrerOverview Is Nothing And _dsReferrerOverview.Tables(0).Rows.Count > 0 Then
                Dim _dr As DataRow

                For Each _dr In _dsReferrerOverview.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtReferrerOverview.NewRow()

                    Dim _count As String = counter
                    _tempRow("sr") = _count


                    Dim Referrer As String = _dr("Referrer").ToString().Trim() & ""
                    _tempRow("Referrers") = Referrer


                    Dim _refDetail As DataSet = _Activity.DetailReferrerOverView(Referrer, StartDate, EndDate, DoaminName)
                    Dim _orderCount As Integer = 0
                    Dim TotalOrders As String
                    _list.Clear()
                    For Each item As DataRow In _refDetail.Tables(0).Rows

                        _orderCount = Me.GetOrderCountBySessionID(StartDate, EndDate, CStr(item(0)), CStr(item(2)), Customerid)

                        If _orderCount <> "0" Then
                            TotalOrders = TotalOrders + _orderCount
                        End If

                    Next

                    If TotalOrders Is Nothing Then
                        TotalOrders = "0"
                    End If
                    _tempRow("Orders") = TotalOrders
                    TotalOrders = 0


                    counter += 1
                    _dtReferrerOverview.Rows.Add(_tempRow)


                Next
            End If

            _dtReferrerOverview.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("OverView Referrer end")
            Return _dtReferrerOverview

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("OverView Referrer exception  " & ex.Message)
            Throw ex
        End Try

    End Function
    Public Function GetOrderCountBySessionID(ByVal StartDate As String, ByVal EndDate As String, ByVal SeID As String, ByVal Customerid As String, ByVal MID As Integer) As Integer


        Try

            Dim OrderCount As Int32
            OrderCount = _Activity.GetOrderCountbyMIDSession(StartDate, EndDate, SeID, Customerid, MID)

            Return OrderCount
        Catch ex As Exception

        End Try

    End Function

    Public Function GetOrderCount(ByVal StartDate As String, ByVal EndDate As String, ByVal Customerid As String, ByVal MID As Integer) As Integer
        Dim OrderCount As Integer

        Try
            System.Web.HttpContext.Current.Trace.Warn("GetOrderCount starts")
            If Customerid.Length <= 10 Then
                OrderCount = _Activity.GetOrderCountbyMID(StartDate, EndDate, Customerid, MID)
                System.Web.HttpContext.Current.Trace.Warn("GetOrderCount  ends" & CStr(OrderCount))
                Return OrderCount
            Else
                Return 0
            End If

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("GetOrderCount  exception" & ex.Message)
            Throw ex
        End Try

    End Function
    Private Sub GetProductDetail(ByVal Customerid As Integer, ByRef drs As DataTable)


        Dim ds As DataSet
        Try

            Dim _ProductIDAsXML As String = GetProductIDAsXML(drs)
            '  System.Web.HttpContext.Current.Session("ProductIDAsXML") = Nothing
            '  System.Web.HttpContext.Current.Session("ProductIDAsXML") = _ProductIDAsXML
            ds = _Activity.GetProductDetails(Customerid, _ProductIDAsXML)

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

    Private Sub GetProductDetailCategory(ByVal Customerid As Integer, ByRef drs As DataTable)


        Dim ds As DataSet
        Try

            Dim _ProductIDAsXML As String = GetProductIDAsXMLCategory(drs)
            System.Web.HttpContext.Current.Session("ProductIDAsXML") = Nothing
            System.Web.HttpContext.Current.Session("ProductIDAsXML") = _ProductIDAsXML
            ds = _Activity.GetProductDetails(Customerid, _ProductIDAsXML)

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

    Private Function GetProductIDAsXMLCategory(ByRef drs As DataTable) As String


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
                xw.WriteAttributeString("cid", dr("CustomerID").ToString().Trim())
                xw.WriteEndElement()


            Next
            xw.WriteEndElement()

            Return sb.ToString()

        Catch ex As Exception

        End Try

    End Function

    Public Function RenderChildDataGridforProduct(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Get Child Product Starts ")
            Dim _dsProduct As DataSet = _Activity.RenderDataGridforProductDetail(Customerid, StartDate, EndDate, DoaminName)
            System.Web.HttpContext.Current.Trace.Warn("Get Child Product end")
            Return _dsProduct

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Child Product exception " & ex.Message)
            Throw ex
        End Try


    End Function

    Public Function RenderChildDataGridforOrder(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataSet

        Try
            System.Web.HttpContext.Current.Trace.Warn("Get Child orders Starts ")
            Dim _dsOrder As DataSet = _Activity.RenderDataGridforOrderDetail(Customerid, StartDate, EndDate, DoaminName)
            System.Web.HttpContext.Current.Trace.Warn("Get Child orders end")
            Return _dsOrder

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Child orders exception  " & ex.Message)
            Throw ex
        End Try


    End Function

    Public Function BuidDataTableChildVisit() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Customers", Type.GetType("System.String"))
            dt.Columns.Add("Name", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))

            dt.Columns.Add("OrderDate", Type.GetType("System.String"))
            dt.Columns.Add("ProductIDs", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderDataGridforChildVist(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet
        System.Web.HttpContext.Current.Trace.Warn("Get Child Visits Starts ")
        Try
            Dim _dtVist As DataTable = Me.BuidDataTableChildVisit()
            Dim _dsVist As DataSet = _Activity.RenderDataGridforVisitDetail(Customerid, StartDate, EndDate, DoaminName, _mid)
            Dim counter As Integer = 1
            If Not _dsVist Is Nothing And _dsVist.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetail(_mid, _dsVist.Tables(0))
                Dim _dr As DataRow

                For Each _dr In _dsVist.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtVist.NewRow()

                    Dim _count As String = counter
                    _tempRow("sr") = _count

                    Dim _customerID As String = _dr("CustomerID")
                    _tempRow("CustomerIDs") = _customerID

                    'Dim _ProductName As String = _dr("ProductName")
                    '_tempRow("ProductName") = _ProductName

                    Dim productID As String = _dr("ProductId").ToString().Trim() & ""
                    _tempRow("ProductIDs") = productID
                    Dim productName As String = _dr("ProductName").ToString().Trim() & ""

                    If productID = "0" Then
                        _tempRow("ProductName") = "&nbsp;"
                    Else
                        _tempRow("ProductName") = productName
                    End If


                    Dim _Customer As String = _dr("Customer")
                    _tempRow("Customers") = _Customer

                    Dim _Name As String = _dr("Name")
                    _tempRow("Name") = _Name

                    Dim _OrderId As String = _dr("OrderId")
                    '   _tempRow("OrderIds") = _OrderId

                    Dim _OrderDate As String = _dr("OrderDate")
                    _tempRow("OrderDate") = _OrderDate

                    Dim _trackID As String = _dr("Trackid")

                    Dim _Detail As New StringBuilder
                    _Detail.Append(" <a HREF=javascript:OpenOrderWindowOrder('" & _OrderId & "','" & _trackID & "')   id=" & _Customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>" & _OrderId & "  </a>  ")
                    _tempRow("Details") = _Detail.ToString

                    counter += 1
                    _dtVist.Rows.Add(_tempRow)

                Next
            End If

            _dtVist.AcceptChanges()

            Dim ds As New DataSet
            ds.Tables.Add(_dtVist)
            System.Web.HttpContext.Current.Trace.Warn("Get Child Visits end")
            Return ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Child Visits exception " & ex.Message)
            Throw ex
        End Try


    End Function
    Public Function RenderChildDataGridforVist(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet

        Try
            Dim _dsVist As DataSet = RenderDataGridforChildVist(Customerid, StartDate, EndDate, DoaminName, _mid)

            Return _dsVist

        Catch ex As Exception
            Dim _Err As String = ex.Message
        End Try


    End Function

    Public Function BuidDataTableChildReferrer() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Details", Type.GetType("System.String"))
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Sid", Type.GetType("System.String"))
            dt.Columns.Add("Customers", Type.GetType("System.String"))
            dt.Columns.Add("Name", Type.GetType("System.String"))
            dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))

            dt.Columns.Add("OrderDate", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function
    Public Function RenderChildDataGridforReferrer(ByVal _sessionId As String, ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet
        System.Web.HttpContext.Current.Trace.Warn("Get Child Referrer Starts ")
        Try
            Dim _dtReferrer As DataTable = Me.BuidDataTableChildReferrer()
            Dim _dsReferrer As DataSet = _Activity.RenderDataGridforReferrerDetailbySid(_sessionId, Customerid, StartDate, EndDate, DoaminName, _mid)
            Dim counter As Integer = 1
            If Not _dsReferrer Is Nothing And _dsReferrer.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetail(_mid, _dsReferrer.Tables(0))
                Dim _dr As DataRow

                For Each _dr In _dsReferrer.Tables(0).Rows

                    Dim _tempRow As DataRow
                    _tempRow = _dtReferrer.NewRow()

                    Dim _count As String = counter
                    _tempRow("sr") = _count

                    Dim _sid As String = _dr("sessionLogId")
                    _tempRow("Sid") = _sid

                    Dim _customerID As String = _dr("CustomerID")
                    _tempRow("CustomerIDs") = _customerID


                    Dim productID As String = _dr("ProductId").ToString().Trim() & ""

                    Dim productName As String = _dr("ProductName").ToString().Trim() & ""

                    If productID = "0" Then
                        _tempRow("ProductName") = "&nbsp;"
                    Else
                        _tempRow("ProductName") = productName
                    End If


                    Dim _Customer As String = _dr("Customer")
                    _tempRow("Customers") = _Customer

                    Dim _Name As String = _dr("Name")
                    _tempRow("Name") = _Name

                    Dim _OrderId As String = _dr("OrderId")
                    '  _tempRow("OrderIds") = _OrderId

                    Dim _OrderDate As String = _dr("OrderDate")
                    _tempRow("OrderDate") = _OrderDate

                    Dim _trackID As String = _dr("Trackid")

                    Dim _Detail As New StringBuilder
                    _Detail.Append(" <a HREF=javascript:OpenOrderWindowOrder('" & _OrderId & "','" & _trackID & "')   id=" & _Customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>" & _OrderId & "  </a>  ")
                    _tempRow("Details") = _Detail.ToString

                    counter += 1
                    _dtReferrer.Rows.Add(_tempRow)

                Next
            End If

            _dtReferrer.AcceptChanges()

            Dim ds As New DataSet
            ds.Tables.Add(_dtReferrer)
            System.Web.HttpContext.Current.Trace.Warn("Get Child Referrer end")
            Return ds

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Get Child Referrer exception  " & ex.Message)
            Throw ex
        End Try


    End Function


    Public Function BuidDataTableChildProductCatagory() As DataTable


        Dim dt As DataTable
        Try
            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))
            dt.Columns.Add("Code", Type.GetType("System.String"))
            dt.Columns.Add("Product_id", Type.GetType("System.String"))
            dt.Columns.Add("Category", Type.GetType("System.String"))
            '  dt.Columns.Add("Cid", Type.GetType("System.String"))
            dt.Columns.Add("Date", Type.GetType("System.String"))
            dt.Columns.Add("InfinimeID", Type.GetType("System.String"))
            dt.Columns.Add("Name", Type.GetType("System.String"))
            dt.Columns.Add("Address", Type.GetType("System.String"))
            dt.Columns.Add("Email", Type.GetType("System.String"))
            dt.Columns.Add("Contract", Type.GetType("System.String"))

            Return dt
        Catch ex As Exception
            Throw ex
        End Try


    End Function

    Public Function RenderDataGridforChildProductCatagory(ByVal Customerid As Integer, ByVal _categoryName As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
        System.Web.HttpContext.Current.Trace.Warn("Get BuidDataTableChildProductCatagory Starts ")
        Try

            Dim _dsCategory As DataSet
            Dim _dtCategory As DataTable = Me.BuidDataTableChildProductCatagory()
            Dim _dsProduct As DataSet = _Activity.RenderDataGridforProduct(Customerid, StartDate, EndDate, DoaminName)
            Dim counter As Integer = 1
            If Not _dsProduct Is Nothing And _dsProduct.Tables(0).Rows.Count > 0 Then
                Me.GetProductDetailCategory(Customerid, _dsProduct.Tables(0))

            End If

            _dsCategory = _Activity.RenderDataGridforProductCategoryChild(Customerid, _categoryName, System.Web.HttpContext.Current.Session("ProductIDAsXML"))
            If Not _dsCategory Is Nothing And _dsCategory.Tables(0).Rows.Count > 0 Then
                'SSSSSSSSSSSSSSSSSS

                Dim _drCat As DataRow

                For Each _drCat In _dsCategory.Tables(0).Rows


                    Dim _tempRowCat As DataRow
                    _tempRowCat = _dtCategory.NewRow()

                    Dim _count1 As String = counter '"<input type=image id=" & counter & " runat=server src='/images/infiniplan/toggleDLplus.gif'>"
                    _tempRowCat("Sr") = _count1
                    Dim _ProductName As String = _drCat("ProductName")
                    _tempRowCat("ProductName") = _ProductName

                    Dim _Code As String = _drCat("Code")
                    _tempRowCat("Code") = _Code

                    Dim _Product_id As String = _drCat("Product_id")
                    _tempRowCat("Product_id") = _Product_id

                    Dim _Category As String = _drCat("Category")
                    _tempRowCat("Category") = _Category

                    'Dim _Cid As String = _drCat("Cid")
                    '_tempRowCat("Cid") = _Cid

                    Dim _Date As String = _drCat("Date")
                    _tempRowCat("Date") = _Date

                    Dim _InfinimeID As String = _drCat("InfinimeID")
                    _tempRowCat("InfinimeID") = _InfinimeID

                    Dim _Name As String = _drCat("Name")
                    _tempRowCat("Name") = _Name

                    Dim _Address As String = _drCat("Address")
                    _tempRowCat("Address") = _Address

                    Dim _Email As String = _drCat("Email")
                    _tempRowCat("Email") = _Email

                    Dim _Contract As String = _drCat("Contract")
                    _tempRowCat("Contract") = _Contract


                    counter += 1
                    _dtCategory.Rows.Add(_tempRowCat)

                Next

                'SSSSSSSSSSSSssssss

            End If

            _dtCategory.AcceptChanges()
            System.Web.HttpContext.Current.Trace.Warn("Get BuidDataTableChildProductCatagory end")
            Return _dtCategory
        Catch ex As Exception
            Dim _Err As String = ex.Message
            System.Web.HttpContext.Current.Trace.Warn("Get BuidDataTableChildProductCatagory exception  " & ex.Message)
            Throw ex
        End Try
    End Function


End Class

'Public Function BuidDataTableReferrer() As DataTable


'    Dim dt As DataTable
'    Try
'        dt = New DataTable
'        dt.Columns.Add("Details", Type.GetType("System.String"))
'        dt.Columns.Add("Sr", Type.GetType("System.String"))
'        dt.Columns.Add("Sid", Type.GetType("System.String"))
'        dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
'        dt.Columns.Add("Country", Type.GetType("System.String"))
'        dt.Columns.Add("IP", Type.GetType("System.String"))
'        dt.Columns.Add("OrdersbyCid", Type.GetType("System.String"))
'        dt.Columns.Add("Ordersbysid", Type.GetType("System.String"))



'        dt.Columns.Add("Referrers", Type.GetType("System.String"))
'        '  dt.Columns.Add("URLs", Type.GetType("System.String"))



'        Return dt
'    Catch ex As Exception
'        Throw ex
'    End Try


'End Function
'Public Function RenderDataGridforReferrer(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable
'    Try

'        Dim _sum As Integer = 0, order As Integer
'        Dim _clist As New ArrayList, _rlist As New ArrayList, _c As New ArrayList
'        _clist.Clear()
'        _c.Clear()
'        _rlist.Clear()

'        Dim _ref As String = ""

'        Dim _cid As String = ""
'        Dim _dtReferrer As DataTable = Me.BuidDataTableReferrer()
'        Dim _dsReferrer As DataSet = _Activity.RenderDataGridforReferrer(Customerid, StartDate, EndDate, DoaminName)
'        '  Dim _dsReferrerOverview As DataSet = _Activity.RenderDataGridforReferrerOverView(Customerid, StartDate, EndDate, DoaminName)

'        Dim counter As Integer = 1
'        If Not _dsReferrer Is Nothing And _dsReferrer.Tables(0).Rows.Count > 0 Then


'            Dim _dr As DataRow
'            Dim _rowRef As DataRow
'            Dim _rowcid As DataRow

'            For Each _dr In _dsReferrer.Tables(0).Rows

'                Dim _tempRow As DataRow
'                _tempRow = _dtReferrer.NewRow()

'                Dim _count As String = counter
'                _tempRow("Sr") = _count

'                Dim _customer As String = _dr("CustomerID")

'                _tempRow("CustomerIDs") = _customer

'                Dim _Referrerpart As String = _dr("Referrerpart")
'                _tempRow("Referrers") = _Referrerpart

'                '  Dim _referrer As String = _dr("Referrer")
'                '_tempRow("URLs") = _referrer

'                'Dim _sbURL As New StringBuilder
'                '_sbURL.Append("<table width='100%'><tr><td align='left' class='AnalyzerText' width='100%'>" & _referrer.ToString & "</td> </tr></table>")
'                '_tempRow("URLs") = _sbURL.ToString

'                Dim _country As String = _dr("Country")
'                _tempRow("Country") = _country

'                Dim _ip As String = _dr("ip")
'                _tempRow("ip") = _ip

'                Dim _sid As String = _dr("sid")
'                _tempRow("Sid") = _sid



'                Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
'                Dim TotalOrders As String = _orderCount
'                _tempRow("OrdersbyCid") = TotalOrders

'                Dim _orderCount1 As Integer = Me.GetOrderCountBySessionID(StartDate, EndDate, _sid, _customer, Customerid)  'Me.GetOrderCount(StartDate, EndDate, _customer, Customerid)
'                Dim TotalOrders1 As String = _orderCount1
'                _tempRow("Ordersbysid") = TotalOrders1
'                _tempRow("OrdersbyCid") = TotalOrders


'                Dim _custid As New StringBuilder
'                If _dr("CustomerID") = _cid Or _cid = "" Then
'                    _cid = _dr("CustomerID")
'                    _custid.Append(" <td align='center' class='bottomlnk' width='50%'> ")
'                    _custid.Append("  </td>")
'                Else
'                    _cid = _dr("CustomerID")
'                    _custid.Append(" <td align='center' class='bottomlnk' width='50%'> <img src=/images/infiniplan/asteric.GIF border=0>")
'                    _custid.Append("  </td>")
'                End If



'                If Not _clist.Contains(_dr("CustomerID")) And Not _rlist.Contains(_dr("Referrerpart")) Then
'                    _clist.Add(_dr("CustomerID"))
'                    _rlist.Add(_dr("Referrerpart"))
'                    '_tempRow("Orders") = TotalOrders
'                    _tempRow("Ordersbysid") = TotalOrders1
'                    _tempRow("OrdersbyCid") = TotalOrders
'                ElseIf Not _clist.Contains(_dr("CustomerID")) And _rlist.Contains(_dr("Referrerpart")) Then
'                    _clist.Add(_dr("CustomerID"))
'                    ' _tempRow("Orders") = TotalOrders
'                    _tempRow("Ordersbysid") = TotalOrders1
'                    _tempRow("OrdersbyCid") = TotalOrders
'                ElseIf _clist.Contains(_dr("CustomerID")) And Not _rlist.Contains(_dr("Referrerpart")) Then
'                    _rlist.Add(_dr("Referrerpart"))
'                    ' _tempRow("Orders") = TotalOrders
'                    _tempRow("Ordersbysid") = TotalOrders1
'                    _tempRow("OrdersbyCid") = TotalOrders
'                ElseIf _clist.Contains(_dr("CustomerID")) And _rlist.Contains(_dr("Referrerpart")) Then
'                    ' If TotalOrders = "0" Then _tempRow("Orders") = "0" Else _tempRow("Orders") = "-"
'                    If TotalOrders = "0" Then _tempRow("OrdersbyCid") = "0" Else _tempRow("OrdersbyCid") = "-"
'                Else
'                End If


'                Dim _Detail As New StringBuilder
'                _Detail.Append("<table><tr><td align='center' class='bottomlnk' width='50%'> <a HREF=javascript:OpenWindow('" & _customer & "')   id=" & _customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>   </td> " & _custid.ToString & " </tr></table>")
'                _tempRow("Details") = _Detail.ToString

'                If _dr("Referrerpart") = _ref Or _ref = "" Then

'                    _ref = _dr("Referrerpart")
'                Else
'                    _ref = _dr("Referrerpart")
'                    _rowRef = _dtReferrer.NewRow()
'                    EmptyRowReferrer(_rowRef, _sum)
'                    _sum = 0
'                    _dtReferrer.Rows.Add(_rowRef)
'                End If

'                counter += 1
'                _dtReferrer.Rows.Add(_tempRow)
'            Next
'        End If
'        _dsReferrer.AcceptChanges()
'        Return _dtReferrer
'    Catch ex As Exception
'        Dim _Err As String = ex.Message
'    End Try
'End Function
'Private Sub EmptyRowReferrer(ByRef rowRef As DataRow, ByVal s As Integer)
'    rowRef("Details") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

'    rowRef("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRef("CustomerIDs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    ' 
'    rowRef("Referrers") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'      rowRef("Country") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
'    rowRef("IP") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRef("OrdersbyCid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRef("Ordersbysid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"


'End Sub
'Private Sub EmptyRowReferrercid(ByRef rowRefcid As DataRow)
'    rowRefcid("Details") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

'    rowRefcid("Sr") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRefcid("CustomerIDs") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRefcid("Referrers") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRefcid("Country") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td> </td></tr></table>"
'    rowRefcid("IP") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRefcid("OrdersbyCid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"
'    rowRefcid("Ordersbysid") = "<table bgcolor='#ECF4FC' height='100%' width='100%'><tr><td>  </td></tr></table>"

'End Sub
'Public Function BuidDataTableReferrerOverview() As DataTable


'    Dim dt As DataTable
'    Try
'        dt = New DataTable
'        dt.Columns.Add("Sr", Type.GetType("System.String"))
'        '    dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
'        dt.Columns.Add("Referrers", Type.GetType("System.String"))
'        dt.Columns.Add("Orders", Type.GetType("System.String"))
'        Return dt
'    Catch ex As Exception
'        Throw ex
'    End Try


'End Function
'Public Function RenderDataGridforReferrerOverview(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String) As DataTable

'    Try
'        Dim _list As New ArrayList

'        Dim _sum As Integer = 0
'        Dim _dtReferrerOverview As DataTable = Me.BuidDataTableReferrerOverview()
'        Dim _dsReferrerOverview As DataSet = _Activity.RenderDataGridforReferrerOverView(Customerid, StartDate, EndDate, DoaminName)
'        Dim counter As Integer = 1
'        If Not _dsReferrerOverview Is Nothing And _dsReferrerOverview.Tables(0).Rows.Count > 0 Then
'            Dim _dr As DataRow

'            For Each _dr In _dsReferrerOverview.Tables(0).Rows

'                Dim _tempRow As DataRow
'                _tempRow = _dtReferrerOverview.NewRow()

'                Dim _count As String = counter
'                _tempRow("sr") = _count


'                Dim Referrer As String = _dr("Referrer").ToString().Trim() & ""
'                _tempRow("Referrers") = Referrer


'                Dim _refDetail As DataSet = _Activity.DetailReferrerOverView(Referrer, StartDate, EndDate, DoaminName)
'                Dim _orderCount As Integer
'                Dim TotalOrders As String
'                _list.Clear()
'                For Each item As DataRow In _refDetail.Tables(0).Rows

'                    If Not _list.Contains(item(2)) Then
'                        _list.Add(item(2))
'                        _orderCount = Me.GetOrderCount(StartDate, EndDate, CStr(item(2)), Customerid)

'                        If _orderCount <> "0" Then
'                            TotalOrders = TotalOrders + _orderCount
'                        End If
'                    End If
'                Next
'                _tempRow("Orders") = TotalOrders
'                TotalOrders = 0


'                counter += 1
'                _dtReferrerOverview.Rows.Add(_tempRow)


'            Next
'        End If

'        _dtReferrerOverview.AcceptChanges()



'        Return _dtReferrerOverview

'    Catch ex As Exception
'        Dim _Err As String = ex.Message
'    End Try


'End Function
'Public Function GetOrderCountBySessionID(ByVal StartDate As String, ByVal EndDate As String, ByVal SeID As String, ByVal Customerid As String, ByVal MID As Integer) As Integer


'    Try

'        Dim OrderCount As Int32
'        OrderCount = _Activity.GetOrderCountbyMIDSession(StartDate, EndDate, SeID, Customerid, MID)

'        Return OrderCount
'    Catch ex As Exception

'    End Try

'End Function
'Public Function RenderChildDataGridforReferrer(ByVal Customerid As String, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet

'    Try
'        Dim _dsReferrer As DataSet = RenderDataGridforChildReferrer(Customerid, StartDate, EndDate, DoaminName, _mid)

'        Return _dsReferrer

'    Catch ex As Exception
'        Dim _Err As String = ex.Message
'    End Try


'End Function
'Public Function BuidDataTableChildReferrer() As DataTable


'    Dim dt As DataTable
'    Try
'        dt = New DataTable
'        dt.Columns.Add("Details", Type.GetType("System.String"))
'        dt.Columns.Add("Sr", Type.GetType("System.String"))
'        dt.Columns.Add("Sid", Type.GetType("System.String"))
'        dt.Columns.Add("Customers", Type.GetType("System.String"))
'        dt.Columns.Add("Name", Type.GetType("System.String"))
'        dt.Columns.Add("CustomerIDs", Type.GetType("System.String"))
'        dt.Columns.Add("OrderIds", Type.GetType("System.String"))
'        dt.Columns.Add("OrderDate", Type.GetType("System.String"))
'        dt.Columns.Add("ProductName", Type.GetType("System.String"))

'        Return dt
'    Catch ex As Exception
'        Throw ex
'    End Try


'End Function
'Public Function RenderDataGridforChildReferrer(ByVal Customerid As Integer, ByVal StartDate As String, ByVal EndDate As String, ByVal DoaminName As String, ByVal _mid As Integer) As DataSet

'    Try
'        Dim _dtReferrer As DataTable = Me.BuidDataTableChildReferrer()
'        Dim _dsReferrer As DataSet = _Activity.RenderDataGridforReferrerDetail(Customerid, StartDate, EndDate, DoaminName, _mid)
'        Dim counter As Integer = 1
'        If Not _dsReferrer Is Nothing And _dsReferrer.Tables(0).Rows.Count > 0 Then
'            Me.GetProductDetail(_mid, _dsReferrer.Tables(0))
'            Dim _dr As DataRow

'            For Each _dr In _dsReferrer.Tables(0).Rows

'                Dim _tempRow As DataRow
'                _tempRow = _dtReferrer.NewRow()

'                Dim _count As String = counter
'                _tempRow("sr") = _count

'                Dim _sid As String = _dr("sessionLogId")
'                _tempRow("Sid") = _sid

'                Dim _customerID As String = _dr("CustomerID")
'                _tempRow("CustomerIDs") = _customerID


'                Dim productID As String = _dr("ProductId").ToString().Trim() & ""

'                Dim productName As String = _dr("ProductName").ToString().Trim() & ""

'                If productID = "0" Then
'                    _tempRow("ProductName") = "&nbsp;"
'                Else
'                    _tempRow("ProductName") = productName
'                End If


'                Dim _Customer As String = _dr("Customer")
'                _tempRow("Customers") = _Customer

'                Dim _Name As String = _dr("Name")
'                _tempRow("Name") = _Name

'                Dim _OrderId As String = _dr("OrderId")
'                _tempRow("OrderIds") = _OrderId

'                Dim _OrderDate As String = _dr("OrderDate")
'                _tempRow("OrderDate") = _OrderDate

'                Dim _trackID As String = _dr("Trackid")

'                Dim _Detail As New StringBuilder
'                _Detail.Append(" <a HREF=javascript:OpenOrderWindowOrder('" & _OrderId & "','" & _trackID & "')   id=" & _Customer & "> <img src=/images/infiniplan/Magnifier.Gif border=0>  </a>  ")
'                _tempRow("Details") = _Detail.ToString

'                counter += 1
'                _dtReferrer.Rows.Add(_tempRow)

'            Next
'        End If

'        _dtReferrer.AcceptChanges()

'        Dim ds As New DataSet
'        ds.Tables.Add(_dtReferrer)
'        Return ds

'    Catch ex As Exception
'        Dim _Err As String = ex.Message
'    End Try


'End Function
