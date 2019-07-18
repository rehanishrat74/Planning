Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Web.Security


Public Class ServicesList
    Inherits System.Web.UI.UserControl



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents litAvailableSrv As System.Web.UI.WebControls.Literal
    Protected WithEvents mExpress As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mAccountsProWeb As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mPayroll As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mCTReturn As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mSAccounts As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mCams As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mDCA As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mBPLN As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tblAvailableServices As System.Web.UI.WebControls.Table
    Protected WithEvents tblToPurchaseServices As System.Web.UI.WebControls.Table
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
    Protected WithEvents tdAvailableServices As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdToPurchaseServices As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdGatewayPIN As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents ccOrderHere As InfiniLogic.AccountsCentre.BLL.OrderHere
    Protected WithEvents lblavailableservices As System.Web.UI.WebControls.Label
    Protected WithEvents lblupdateservices As System.Web.UI.WebControls.Label

    'Protected WithEvents DivTreeView As HtmlGenericControl
    Protected WithEvents DivTreeView As HtmlTableCell

    Protected WithEvents hdnlblCompName As System.Web.UI.WebControls.TextBox

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        LblXML.ID = "LblXML"
        Me.Controls.Add(LblXML)
        LblXML.Visible = False
    End Sub

#End Region

    Private ReadOnly Property CustomerID() As Int32
        Get
            Trace.Write("Service List Customer ID : " & Page.User.Identity.Name)
            Return Int32.Parse(Page.User.Identity.Name)
        End Get
    End Property

    Private thisProdNodeXML As String
    Private thisSelProdCode As String
    '  Shared LastSelectedCulture As System.Globalization.CultureInfo
    Protected WithEvents LblXML As New Label


    Private Property ProdNodeXML() As String
        Get
            Return thisProdNodeXML
        End Get
        Set(ByVal Value As String)
            thisProdNodeXML = Value
        End Set
    End Property

    Public Property SelProdCode() As String
        Get
            Return thisSelProdCode
        End Get
        Set(ByVal Value As String)
            thisSelProdCode = Value
        End Set
    End Property

    'Dim CustomerID As String
    Dim SelCompanyName As String = String.Empty
    Dim SelCustomerId As String = String.Empty
    Dim sRegID As String, sRegUserID As String, sGVCompName As String, sGVCompNumber As String

    Dim objGlobalView As New Web.GlobalViewUI

    Private ReadOnly Property IsServiceExpired(ByVal SName As String) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAlreadyExpired"), Hashtable)
            Return servicesExpired.ContainsValue(SName)
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Trace.Warn("LEFT BAR of Accounts.infinibiz.com loaded.")
        'Modified by : Muhammad Furqan Khan  24-JUL-2007
        'Disable functionality if page is viewed inside infinioffice
        If Not IsNothing(Session(PageTemplate.Session_InsideIO)) AndAlso Session(PageTemplate.Session_InsideIO) Then
            Me.Visible = False
        Else
            'CODE FOR SALESREPORTS
            Session("PID") = (New Infinilogic.AccountsCentre.BLL.User).GetCustomerID(Session(PageTemplate.Session_ParentUID))
            Trace.Write("Services List Page Load")
            'Put user code to initialize the page here
            'Dim CurrentCulture As System.Globalization.CultureInfo = Session("SelectedCulture")

            'If Not IsNothing(Viewstate("LastSelectedCulture")) Then ''' if the culture settings are not changed there is not need for Redrawing left bar
            '    If CurrentCulture.Equals(ViewState("LastSelectedCulture")) Then Exit Sub
            'End If

            'Viewstate("LastSelectedCulture") = Session("SelectedCulture")

            ProdNodeXML = LblXML.Text
            Dim strProductCode As String = Request.QueryString("orderhere")

            If (strProductCode <> "") Then
                If isValidProductCode(strProductCode) Then

                    If (strProductCode = "CP57" OrElse strProductCode = "CP58") Then
                        strProductCode = "CP53"
                    End If

                    ccOrderHere.ProductCode = strProductCode
                    Session.Remove("RenewProductCode")
                    Dim ee As New ImageClickEventArgs(1, 1)
                    ccOrderHere.OrderHere_Click(Me, ee)
                Else
                    'Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Hom))
                    ' PageBase.RedirectToErrorPage(ACC_Error_Messages.ACC_Service_Not_Available_For_Sale)
                End If

            End If
            Dim objGatewayRegistration As New GatewayRegistration
            'If Not PageBase.isEmployee Then
            '    tdGatewayPIN.Visible = Not objGatewayRegistration.IsGetGatewayPinActivated(CustomerID)
            'Else
            '    tdGatewayPIN.Visible = False
            'End If

            '        If Request.Params.Get("__EVENTTARGET") <> String.Empty AndAlso Request.Params.Get("__EVENTARGUMENT") <> String.Empty Then
            SelCompanyName = Request.Params.Get("__EVENTTARGET")
            SelCustomerId = Request.Params.Get("__EVENTARGUMENT")

            '       End If

            PrepareMe()

            'If SelCompanyName <> Nothing OrElse SelCustomerId <> Nothing Then
            '    If Not SelCompanyName.IndexOf("dgridSummaryInformation:") >= 0 Then

            '        Try


            '            objGlobalView.dvCompanies.Sort = "MemberCustomerID"
            '            If SelCustomerId <> String.Empty Then
            '                Dim SelIndex As Int16 = objGlobalView.dvCompanies.Find(SelCustomerId)

            '                With objGlobalView


            '                    If Not IsDBNull(.dvCompanies(SelIndex).Item("MemberCustomerID")) Then sRegID = .dvCompanies(SelIndex).Item("MemberCustomerID") Else sRegID = String.Empty '11
            '                    If Not IsDBNull(.dvCompanies(SelIndex).Item("cart_customer_uid")) Then sRegUserID = .dvCompanies(SelIndex).Item("cart_customer_uid") Else sRegUserID = String.Empty '11
            '                    If Not IsDBNull(.dvCompanies(SelIndex).Item("CompName")) Then sGVCompName = .dvCompanies(SelIndex).Item("CompName") Else sGVCompName = String.Empty '11
            '                    If Not IsDBNull(.dvCompanies(SelIndex).Item("CompRegNo")) Then sGVCompNumber = .dvCompanies(SelIndex).Item("CompRegNo") Else sGVCompNumber = String.Empty '11

            '                    Dim strurl As String = String.Format("https://accounts.infinibiz.com/GlobalView/GlobalView.aspx?sRegID={0}&sRegUserID={1}&sGVCompName={2}&sGVCompNumber={3}", sRegID, sRegUserID, sGVCompName, sGVCompNumber)
            '                    Response.Redirect(strurl)
            '                    'Server.Transfer(strurl)

            '                End With
            '            Else
            '                sRegID = String.Empty
            '                sRegUserID = String.Empty
            '                sGVCompName = SelCompanyName
            '                sGVCompNumber = String.Empty

            '                Dim strurl As String = String.Format("https://accounts.infinibiz.com/GlobalView/GlobalView.aspx?sRegID={0}&sRegUserID={1}&sGVCompName={2}&sGVCompNumber={3}", sRegID, sRegUserID, sGVCompName, sGVCompNumber)
            '                Response.Redirect(strurl)
            '            End If


            '        Catch ex As Exception
            '            Throw ex
            '        End Try
            '    End If
            'End If

            'CustomerID = SelCustomerId
        End If
    End Sub

    Private Function isValidProductCode(ByVal strProductCode As String) As Boolean

        Dim ds As New DataSet
        'Dim objUser As New User
        Dim str As String = ""

        ds = User.ACC_GetProductsToSale 'objUser.ACC_UpdatePackageProductDetails(CustomerID, PackageOptions.EnableSale, ServiceOptions.EnableSale)
        For Each table As DataTable In ds.Tables
            For Each row As DataRow In table.Rows
                str &= row.Item("ProductCode") & " , "
                If row.Item("ProductCode") = strProductCode Then
                    Return True
                    '----- CTReturn ------------------ Annual Accounts --------------------------- Package Code ----
                ElseIf (strProductCode = "CP57" OrElse strProductCode = "CP58") AndAlso row.Item("ProductCode") = "CP53" Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function


    Private Sub PrepareMe()
        Trace.Write("Prepare Me")
        Dim XML As String = ""
        Dim sqlDR As SqlClient.SqlDataReader
        Dim dt As DataTable = Nothing
        Dim dr() As DataRow

        Dim serviceName, productCode, url As String
        '****************************************************************
        'Update by Muhammad Ubaid 
        'for ReSeller
        '*****************************************************************
        Dim ServicesCounter As Integer = 0
        Dim CustomerServices(0) As String
        Dim Productxml As New System.Xml.XmlDocument
        Dim ProductNode As System.Xml.XmlNode
        Dim productList As System.Xml.XmlNodeList
        Dim IsDuplicate As Boolean = False
        '*****************************************************************
        Dim serviceId As String

        Dim expired_products As String = "" 'This line is modified by Yousuf

        Dim SelCompNodeList As New ArrayList

        Try
            sqlDR = ServicesManager.AllowedServicesMenu(CustomerID)
            If Session("ACC_GV_ProcessCompany") = Nothing Then Exit Try

            Dim employeeID As String = Session("merchantProUserID")
            Dim ParentCustID As String = Session("ACC_GV_ParentCustomerID")
            Dim EmployeeAllowedProd() As String
            If Session("merchantProUserID") <> Nothing Then EmployeeAllowedProd = (New User).FetchAllowedProductsForUser(employeeID, ParentCustID)



            Dim Count As Int16 = 0
            With sqlDR
                While .Read

                    serviceName = .Item("MenuName")
                    productCode = .Item("ProductCode")
                    url = .Item("url")

                    CustomerServices(ServicesCounter) = productCode
                    ReDim Preserve CustomerServices(CustomerServices.Length)
                    ServicesCounter += 1



                    Dim SearchResult As Int16
                    If Session("merchantProUserID") <> Nothing Then
                        SearchResult = Array.BinarySearch(EmployeeAllowedProd, productCode)
                    Else
                        SearchResult = 1
                    End If

                    If productCode = "CP57" OrElse productCode = "CP58" Then
                        productCode = "CP53"
                    End If

                    If SearchResult >= 0 Then
                        If IsNumeric(Session("ACC_GV_SRegId")) And productCode <> SelProdCode Then
                            If IsServiceExpired(.Item("Name")) Then
                                XML &= "<child text=""" & serviceName & """ value=""https://www.accountscentre.com/default.aspx?OrderHere=" & productCode & "&IsRenew=Y"" imgpath=""\images/folder.gif"" /> "

                                'Start: Muhammad Furqan Khan 26-APR-2007
                                'following condition was added due to url of infinishops.
                                'previously this url was combined with accounts.infinibiz url. it had to be separeted.
                            ElseIf url.ToLower.StartsWith("http:") OrElse url.ToLower.StartsWith("https:") OrElse url.ToLower.StartsWith("www.") Then
                                XML &= "<child text=""" & serviceName & """ value=""" & url & """ imgpath=""\images/folder.gif"" />"
                                'End: Muhammad Furqan Khan 26-APR-2007

                            Else
                                XML &= "<child text=""" & serviceName & """ value=""https://" & Request.Url.Host & url & """ imgpath=""\images/folder.gif"" />"
                            End If
                        End If
                    End If
                End While
            End With
            'Session("expired_products") = expired_products  'This line is modified by Yousuf
            Session(PageBase.ACC_ORDER_HERE_LINK) = expired_products
            sqlDR.Close()

        Catch ex As Exception
            Throw ex
        Finally
            If Not sqlDR.IsClosed Then
                sqlDR.Close()
            End If
        End Try


        Dim Nodes_Level_2 As String

        Nodes_Level_2 &= "<child text=""GlobalView"" value=""https://" & Request.Url.Host & "/globalview/globalview.aspx"" imgpath=""\images/folder.gif"" />"

        'CODE FOR SALES REPORTS
        'Nodes_Level_2 &= AddParentNode("Sales Report", PrepareSalesReportsNode, , "\images/folder.gif")
        Nodes_Level_2 &= "<child text=""Sales Report"" value=""https://" & Request.Url.Host & "/SalesReport/SalesReport.aspx"" imgpath=""\images/folder.gif"" />"

        'Start: Muhammad Furqan Khan 26-APR-2007
        'following line was edited to add url so that user can
        'browse back to company home page.
        Nodes_Level_2 &= AddParentNode(Session("ACC_GV_ProcessCompany"), XML, "https://" & Request.Url.Host & "/members/default.aspx", "\images/folder.gif")
        'End: Muhammad Furqan Khan 26-APR-2007

        Nodes_Level_2 &= AddParentNode("InfiniBiz Profile", PrepareIBizProfileNodes(), , "\images/folder.gif")
        Nodes_Level_2 &= PrepareFaqNode()
        If ProdNodeXML <> String.Empty Then Nodes_Level_2 &= ProdNodeXML

        PrepareTreeView("Accounting Services", Nodes_Level_2, Nothing, "\images/AccServices.gif")


    End Sub


    'Private Sub PrepareMePrivious()
    '    Dim sqlDR As SqlClient.SqlDataReader
    '    Dim dt As DataTable = Nothing
    '    Dim dr() As DataRow
    '    Dim hRow As TableRow
    '    Dim hCell As TableCell
    '    Dim serviceName, productCode As String
    '    '****************************************************************
    '    'Update by Muhammad Ubaid 
    '    'for ReSeller
    '    '*****************************************************************
    '    Dim ServicesCounter As Integer = 0
    '    Dim CustomerServices(0) As String
    '    Dim Productxml As New System.Xml.XmlDocument
    '    Dim ProductNode As System.Xml.XmlNode
    '    Dim productList As System.Xml.XmlNodeList
    '    Dim IsDuplicate As Boolean = False
    '    '*****************************************************************
    '    Dim serviceId As String

    '    Dim expired_products As String = "" 'This line is modified by Yousuf
    '    Dim ChildCompanies() As Web.GlobalViewUI.ChildCompany = (New Web.GlobalViewUI).ChildCompanies
    '    Dim Nodes_Level_3 As New ArrayList
    '    Dim CNodeList As New ArrayList

    '    For Each Company As Web.GlobalViewUI.ChildCompany In ChildCompanies
    '        If (Company.CompanyName <> Session("ACC_GV_ProcessCompany")) Then
    '            Dim CNode As New com.infinibiz.reseller.ParentNode
    '            CNode = New com.infinibiz.reseller.ParentNode
    '            CNode.text = Company.CompanyName
    '            CNode.link = "Javascript:__doPostBack('" & Company.CompanyName & "','" & Company.CustomerID & "');"
    '            CNodeList.Add(CNode)
    '        End If
    '    Next

    '    Dim SelCompNodeList As New ArrayList

    '    Try

    '        tdAvailableServices.Visible = False
    '        sqlDR = ServicesManager.AllowedServicesMenu(CustomerID)
    '        If Session("ACC_GV_ProcessCompany") = Nothing Then Exit Try
    '        'Dim CNode() As com.infinibiz.reseller.ParentNode = New com.infinibiz.reseller.ParentNode(20) {}
    '        'Dim CNodeList As New ArrayList
    '        Dim Count As Int16 = 0
    '        With sqlDR
    '            While .Read
    '                'tdAvailableServices.Visible = True
    '                'hRow = New TableRow
    '                'hCell = GetServiceCell()
    '                serviceName = .Item("MenuName")
    '                productCode = .Item("ProductCode")
    '                CustomerServices(ServicesCounter) = productCode
    '                ReDim Preserve CustomerServices(CustomerServices.Length)
    '                ServicesCounter += 1

    '                If productCode = "CP57" OrElse productCode = "CP58" Then
    '                    productCode = "CP53"
    '                End If

    '                'If IsServiceExpired(.Item("Name")) Then
    '                '    hCell.Text = "<a target=_self href='https://www.accountscentre.com/default.aspx?OrderHere=" & productCode & "&IsRenew=Y' class='IBIZ_Link'>" & serviceName & " <font color='#ff0000'><b><blink>Renew</blink></b></font></a>"
    '                '    ' hCell.Text = "<a href='https://www.accountscentre.com/members/updateservices.aspx' class='link_text_over'>" & serviceName & " <font color='#ff0000'><b><blink>Renew</blink></b></font></a>"
    '                '    expired_products = expired_products + productCode + "^" 'This line is modified by Yousuf
    '                'Else
    '                '    hCell.Text = "<a href='https://accounts.infinibiz.com" & .Item("URL") & "'  class='IBIZ_Link'>" & serviceName & "</a>"
    '                'End If
    '                'hRow.Cells.Add(GetBulletCell)
    '                'hRow.Cells.Add(hCell)
    '                'tblAvailableServices.CellPadding = 0 : tblAvailableServices.CellSpacing = 0
    '                'tblAvailableServices.Rows.Add(hRow)
    '                If IsNumeric(Session("ACC_GV_SRegId")) Then
    '                    Dim CNode As New com.infinibiz.reseller.ParentNode
    '                    CNode = New com.infinibiz.reseller.ParentNode
    '                    CNode.text = serviceName
    '                    CNode.link = "https://accounts.infinibiz.com" & .Item("URL")
    '                    SelCompNodeList.Add(CNode)
    '                End If
    '                'CNode(Count) = New com.infinibiz.reseller.ParentNode
    '                'CNode(Count).text = serviceName
    '                'CNode(Count).link = "https://accounts.infinibiz.com" & .Item("URL")
    '                'Count += 1
    '            End While
    '            'Nodes_Level_3.Add(AddParentNode(CompanyName, CNodeList))

    '        End With
    '        'Session("expired_products") = expired_products  'This line is modified by Yousuf
    '        Session(PageBase.ACC_ORDER_HERE_LINK) = expired_products
    '        sqlDR.Close()
    '        tdToPurchaseServices.Visible = False
    '        '**********************************************************************************************
    '        'Add by Muhammad Ubaid 
    '        'for ReSeller
    '        '**************************************************
    '        Dim ProductsXml As String = ""
    '        ProductsXml = ServicesManager.GetReSellerProducts(ServicesManager.GetReSellerID(CustomerID))
    '        ' ProductsXml = ServicesManager.GetReSellerProducts("123454")

    '        If Trim(ProductsXml) <> "" Then

    '            Productxml.LoadXml(Trim(ProductsXml))
    '            '<NewDataSet>
    '            '  <Table>
    '            '    <id>CP56</id>
    '            '    <name>Enterprise - Accounts Express</name>
    '            '  </Table>
    '            '</NewDataSet>
    '            productList = Productxml.SelectNodes("//Table")
    '            For Each ProductNode In productList
    '                tdToPurchaseServices.Visible = True
    '                hRow = New TableRow
    '                hCell = GetServiceCell()
    '                serviceName = ProductNode.Item("name").InnerText
    '                serviceId = ProductNode.Item("id").InnerText
    '                For Each item As Object In CustomerServices
    '                    If UCase(Trim(item)) = UCase(Trim(serviceId)) Then
    '                        IsDuplicate = True
    '                    End If
    '                Next
    '                If Not IsDuplicate Then
    '                    If serviceId = "CP57" OrElse serviceId = "CP58" Then
    '                        serviceId = "CP53"
    '                    End If

    '                    If serviceId = "104" Then
    '                        hCell.Text = "<a target=_self href='" & Request.Url.AbsolutePath & "' class='IBIZ_Link'>" & serviceName & "</a>"
    '                    Else
    '                        hCell.Text = "<a target=_self href='http://services.infinibiz.com" & Request.Url.AbsolutePath & "?OrderHere=" & serviceId & "' class='IBIZ_Link'>" & serviceName & "</a>"
    '                    End If
    '                    If Not PageBase.isEmployee Then
    '                        hRow.Cells.Add(GetBulletCell)
    '                        hRow.Cells.Add(hCell)
    '                        ' tblToPurchaseServices.Rows.Add(hRow)
    '                    End If

    '                End If
    '            Next
    '        End If
    '        '**********************************************************************************************

    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Not sqlDR.IsClosed Then
    '            sqlDR.Close()
    '        End If
    '    End Try


    '    Dim Nodes_Level_2 As New ArrayList
    '    'Nodes_Level_2.Add(AddParentNode("Global View", Nodes_Level_3))
    '    Nodes_Level_2.Add(AddParentNode("Global View", CNodeList))
    '    Nodes_Level_2.Add(AddParentNode(Session("ACC_GV_ProcessCompany"), SelCompNodeList))
    '    Nodes_Level_2.Add(AddParentNode("InfiniBiz Profile", PrepareIBizProfileNodes()))
    '    Nodes_Level_2.Add(PrepareFaqNode())
    '    PrepareTreeView("Accounting Services", Nodes_Level_2, , "\images/AccServices.gif")

    'End Sub

    Private Function GetBulletCell() As TableCell
        Dim hBulletCell As TableCell = New TableCell
        With hBulletCell
            .Width = Unit.Pixel(1)
            .Height = Unit.Pixel(5)
            .HorizontalAlign = HorizontalAlign.Center
            .VerticalAlign = VerticalAlign.Middle
            '.Text = "<img src='/images/greenbt.jpg' width=5 height=5>"
            .Text = "<img src='/images/arrow_cat_new.jpg'>"

        End With

        Return hBulletCell
    End Function

    Private Function GetServiceCell() As TableCell
        Dim hCell As TableCell = New TableCell

        With hCell
            .Width = Unit.Pixel(142)
            .Height = Unit.Pixel(5)
            .HorizontalAlign = HorizontalAlign.Left
            .VerticalAlign = VerticalAlign.Middle
            .CssClass = "link_text"
        End With

        Return hCell
    End Function

    Private Function PrepareTreeView(ByVal TreeViewName As String, ByVal ChildNodesXML As String, Optional ByVal LinkURL As String = Nothing, Optional ByVal ImageURL As String = Nothing)
        Trace.Write("Prepare Treeview ")
        Dim objuser As New User

        Dim objRssServices As New com.infinibiz.reseller.ResellerServices
        Dim Callerinfo As New com.infinibiz.reseller.CallerInfo
        Dim PNode As New com.infinibiz.reseller.ParentNode
        Dim TreeViewResult As New com.infinibiz.reseller.GetTreeViewResult

        'Dim ds As DataSet = objuser.GetParentChildProfile(CustomerID)
        'Dim ParentUID As String

        'If (Not ds Is Nothing) AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
        '    Trace.Warn("Parent Customer Found")
        '    ParentUID = ds.Tables(0).Rows(0).Item("Cart_Customer_uid")
        'End If

        With Callerinfo
            .customeruid = Session(PageTemplate.Session_ParentUID)
            .language = "eng"
            .referrer = "1009"
            .sessionid = Session(PageTemplate.Session_ServiceID)
        End With

        Dim xml As String

        xml = "<parent text=""" & TreeViewName & """ value="""" imgpath=""" & ImageURL & """>" & ChildNodesXML & "</parent>"
        xml = "<root>" & xml & "</root>"

        Trace.Write(String.Format("Calling GetTreeViewByXML Customeruid={0}, language={1}, referer={2}, sessionid={3}", Session(PageTemplate.Session_ParentUID), "eng", "1009", Session(PageTemplate.Session_ServiceID)))
        TreeViewResult = objRssServices.GetTreeViewByXML(Callerinfo, xml)
        Trace.Write("ErrorCode = " & TreeViewResult.ErrorCode)
        Trace.Write("ErrorDesc = " & TreeViewResult.ErrorDesc)
        'Trace.Write(TreeViewResult.ResultHTML)
        'TreeViewResult.ResultHTML = TreeViewResult.ResultHTML.Replace("http://", "https://")
        If TreeViewResult.ErrorCode = "0" Then
            DivTreeView.InnerHtml = TreeViewResult.ResultHTML
        End If


    End Function

    Function AddParentNode(ByVal PNodeName As String, ByVal ChildNodesXML As String, Optional ByVal LinkUrl As String = Nothing, Optional ByVal ImageUrl As String = Nothing) As String

        If IsNothing(ChildNodesXML) Or ChildNodesXML = String.Empty Then
            Return String.Empty
        End If

        Dim xml As String

        xml = "<parent text=""" & PNodeName & """ value=""" & LinkUrl & """ imgpath=""" & ImageUrl & """>" & ChildNodesXML & _
            "</parent>"

        Return xml

    End Function

    Function PrepareIBizProfileNodes() As String

        Dim xml As String
        xml = "<child text=""Menu"" value=""https://" & Request.Url.Host & "/members/default.aspx"" imgpath=""\images/folder.gif"" />"
        xml &= "<child text=""Profile"" value=""https://" & Request.Url.Host & "/members/profile.aspx"" imgpath=""\images/folder.gif"" />"
        xml &= "<child text=""Sign Out"" value=""https://" & Request.Url.Host & "/Account/signout.aspx"" imgpath=""\images/folder.gif"" />"
        Return xml

    End Function

    Function PrepareFaqNode() As String

        Dim xml As String
        xml = "<child text=""FAQs"" value=""https://" & Request.Url.Host & "/members/faq.aspx"" imgpath=""\images/folder.gif"" />"
        Return xml

    End Function

    Function PrepareSalesReportsNode() As String
        Dim xml As String
        Dim ds As DataSet = GetAllChildCompaniesHavingPro()
        Dim dr As DataRow

        If ds.Tables(0).Rows.Count <> 0 Then
            For Each dr In ds.Tables(0).Rows
                Session("InfiniBizProdSummerise") = CType(dr.Item(1), String)
                Session("InfiniBizChildID") = CType(dr.Item(0), String)
                xml &= "<child text=""" & dr.Item(1) & """ value=""https://" & Request.Url.Host & "/SalesReport/SalesReport.aspx?vmx=" & dr.Item(0) & """ imgpath=""\images/folder.gif"" /> "
            Next
        End If
        Return xml

    End Function

    Function GetAllChildCompaniesHavingPro() As DataSet
        Dim xml As String
        With New CommandData
            .CmdText = "DBServer.InfinishopMainDB.dbo.ADMIN_GETCHILDCOMPANIESHAVINGPRO"
            .AddParameter("@Customerid", Session("PID"))
            Return .Execute(ExecutionType.ExecuteDataSet)
        End With
    End Function

End Class

