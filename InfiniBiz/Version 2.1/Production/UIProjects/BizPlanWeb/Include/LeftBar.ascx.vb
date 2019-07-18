
#Region " Menu"


'Imports Infinilogic.BusinessPlan.Web.Common
'Imports Infinilogic.BusinessPlan.BLL
'Imports Infinilogic.BusinessPlan.BLLRules
'Imports skmMenu
'Imports System.Text

'Public Class LeftBar
'    Inherits System.Web.UI.UserControl
'    Dim menuHashTable As New Hashtable
'    Dim _navArray() As String
'    'Public lblMain As String
'    Public secondMenuTitle As String
'    Public istMenuTitle As String
'    Dim Menucount As StringBuilder
'    Dim imgPath As String = " imgpath=""/images/folder.gif"" "

'    Dim TextNode As New StringBuilder

'    Protected WithEvents Menu1 As skmMenu.Menu
'    Protected WithEvents contMenu1 As System.Web.UI.HtmlControls.HtmlTable
'    Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable
'    Protected WithEvents contMenu2 As System.Web.UI.HtmlControls.HtmlTable
'    Protected WithEvents tblText As System.Web.UI.HtmlControls.HtmlTable
'    Protected WithEvents tblMenu2 As System.Web.UI.HtmlControls.HtmlTable
'    Dim dtUserRigths As DataTable
'    Dim EmployeemainNavigator As StringBuilder
'    Dim ObjCustomer As CustomerStatus
'    Dim MybasePage As BizPlanWebBase
'    'Protected WithEvents Menu1 As skmMenu.Menu
'    'Protected WithEvents contMenu1 As System.Web.UI.HtmlControls.HtmlTable
'    'Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable
'    'Protected WithEvents contMenu2 As System.Web.UI.HtmlControls.HtmlTable
'    'Protected WithEvents tblText As System.Web.UI.HtmlControls.HtmlTable
'    'Protected WithEvents tblMenu2 As System.Web.UI.HtmlControls.HtmlTable
'    Dim MenuNode As New StringBuilder
'    Public bool As Boolean

'    Dim objBll As New AccountsCentre.BLL.AccountingTreeView
'    Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult
'    Dim mySampleURL As String
'#Region " Web Form Designer Generated Code "

'    'This call is required by the Web Form Designer.
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

'    End Sub
'    Protected WithEvents menuTextHeadings As skmMenu.Menu

'    'NOTE: The following placeholder declaration is required by the Web Form Designer.
'    'Do not delete or move it.
'    Private designerPlaceholderDeclaration As System.Object

'    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
'        'CODEGEN: This method call is required by the Web Form Designer
'        'Do not modify it using the code editor.
'        InitializeComponent()
'    End Sub

'#End Region

'    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        'Put user code to initialize the page here

'        Dim tmpMenu As MenuItem
'        Dim basePage As BizPlanWebBase

'        basePage = CType(Me.Page, BizPlanWebBase)
'        bool = ObjCustomer.CustomerSerivceStatus(basePage.GetConnectionData)


'        BllResult = _
'        objBll.Encrypt_MerchantAndEmployee(115161, "", True)


'        If BllResult.IsSuccess Then
'            '''''Biz plan logic for creating URLs'

'            'Following is sample of how you transfer your pageinfo to gateway page.
'            'But this supports only 1 query string.
'            'If you want to send more than 1 query strings then encrypt them into 1 secure query string.
'            Dim myPageUrlWithMyQueryString As String = "/BizPlan/SamplePlan.aspx?PlanID="

'            mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & myPageUrlWithMyQueryString & "&config=" & CType(BllResult.ReturnObject, String)
'            ''''''''''''''''''''''''''''''''''''''
'        Else

'        End If
'        EmployeemainNavigator = New StringBuilder
'        If Not Session("merchantProUserID") Is Nothing Then

'            dtUserRigths = TextOperations.GetPlanRights(basePage.GetConnectionData, CType(Session("merchantProUserID"), String))

'            Dim dr As DataRow
'            Dim da As Array
'            EmployeemainNavigator.Append("Home,")
'            Dim da1 As Array = dtUserRigths.Select("  Modelid  = 67 or Modelid  = 68 or Modelid  = 70 ")
'            If da1.Length > 0 Then
'                EmployeemainNavigator.Append("Plan Manager,")
'            End If
'            If (bool = True) Then
'                da = dtUserRigths.Select(" Modelid  = 69 or  Modelid  = 65 or Modelid  = 66 ")
'            Else
'                da = dtUserRigths.Select(" Modelid  = 69 or    Modelid  = 66 ")
'            End If


'            For Each dr In da
'                EmployeemainNavigator.Append(CStr(dr(2)) + ",")
'            Next

'            Dim strMenu() As String = EmployeemainNavigator.ToString.Remove(EmployeemainNavigator.ToString.LastIndexOf(","c), 1).Split(","c)
'            If basePage.Navigator.Length = 12 Or basePage.Navigator.Length = 13 Or basePage.Navigator.Length = 2 Or basePage.Navigator.Length = 3 Then
'                _navArray = basePage.Navigator
'            Else
'                _navArray = strMenu
'            End If
'        Else
'            _navArray = basePage.Navigator
'        End If
'        istMenuTitle = basePage.ResMgr.GetString("bizplan_menu_title_PlanNavigator")
'        createMenus(basePage)
'        CType(Me.FindControl("Index_Left").FindControl("LblXML"), Label).Text = MenuNode.ToString

'    End Sub


'    Public Sub SetTextHeadings(ByVal dt As DataTable, ByVal basePage As BizPlanWebBase)

'        Dim qoute As Char = """"c
'        Dim dr As DataRow
'        Dim tmpMenu As MenuItem
'        Dim da As Array
'        da = dt.Select("ParentHeadingID = 'U_0' and (headingtype=3 or headingtype=4)")
'        For Each dr In da
'            Dim headingID As String = CStr(dr(1))
'            Dim headingText As String = CStr(dr(2))

'            If CInt(dr(7)) = 3 Then
'                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/Text/PlanCover.aspx" & "&config=" & CType(BllResult.ReturnObject, String)

'                'TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1"" >")
'                TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + ">")
'            Else
'                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1)) & "&config=" & CType(BllResult.ReturnObject, String)

'                'TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1"">")
'                TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + ">")
'            End If
'            TextNode.Append("</outerchild>")


'            tmpMenu = CreateMenuItems(dt, headingText, headingID, basePage)
'            If CInt(dr(7)) = 3 Then
'                tmpMenu.Url = "/InfiniPlan/Services/Text/PlanCover.aspx"
'            Else
'                tmpMenu.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1))

'            End If
'            tmpMenu.Text = headingText
'            Menu1.Items.Add(tmpMenu)
'        Next

'        'old headings
'        da = dt.Select("ParentHeadingID ='U_0' and headingtype=0 ")

'        For Each dr In da
'            Dim headingID As String = CStr(dr(1))
'            Dim headingText As String = CStr(dr(2))
'            mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1)) & "&config=" & CType(BllResult.ReturnObject, String)

'            'TextNode.Append("<child" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1"" >")
'            TextNode.Append("<child" + " text=" + qoute + headingText + qoute + " value=" + qoute + mySampleURL + qoute + ">")
'            TextNode.Append("</child>")
'            tmpMenu = CreateMenuItems(dt, headingText, headingID, basePage)
'            ' tmpMenu.Text = headingText
'            ' tmpMenu.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1))
'            ' Menu1.Items.Add(tmpMenu)
'        Next
'        Menu1.HighlightTopMenu = False
'        Menu1.Opacity = CStr(100)
'        Menu1.zIndex = 100
'        Menu1.Cursor = skmMenu.MouseCursor.Pointer

'    End Sub


'    Private Function CreateMenuItems(ByVal dt As DataTable, ByVal headingText As String, ByVal headingID As String, ByVal basePage As BizPlanWebBase) As MenuItem
'        Dim qoute As Char = """"c
'        Dim tmpMenu As New MenuItem
'        Dim da As Array = dt.Select("ParentHeadingID = '" & headingID & "'")

'        If (da.Length > 0 And headingText <> "Cover Page") Then
'            Dim dr As DataRow
'            'TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + "" + qoute + imgPath + " collapse=""1"" >")
'            TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + "" + qoute + " >")
'            For Each dr In da
'                Dim subHeadingID As String = CStr(dr(1))
'                Dim subHeadingText As String = CStr(dr(2))

'                Dim subItem As MenuItem = CreateMenuItems(dt, subHeadingText, subHeadingID, basePage)
'                Dim HeadingType As Integer = CInt(dr("HeadingType"))

'                Select Case HeadingType
'                    Case 0
'                        subItem.Text = subHeadingText
'                        subItem.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & subHeadingID
'                        'mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & mySampleURL & "&config=" & CType(BllResult.ReturnObject, String)
'                        mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & subItem.Url & "&config=" & CType(BllResult.ReturnObject, String)

'                        'TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1"">")
'                        TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + mySampleURL + qoute + ">")
'                        TextNode.Append("</innerchild>")
'                    Case 1
'                        subItem.Text = "Table: " + subHeadingText
'                        subItem.Url = "/InfiniPlan/Services/Tables/Table.aspx?tableID=" & Table.GetTableID(subHeadingText.Replace(" ", ""))
'                        mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & subItem.Url & "&config=" & CType(BllResult.ReturnObject, String)

'                        'TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1"" >")
'                        TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + mySampleURL + qoute + " >")
'                        TextNode.Append("</innerchild>")
'                    Case 2
'                        subItem.Text = "Chart: " + subHeadingText
'                        subItem.Url = "/InfiniPlan/Services/Charts/Chart.aspx?chartID=" & Chart.GetChartID(subHeadingText.Replace(" ", ""))
'                        mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & subItem.Url & "&config=" & CType(BllResult.ReturnObject, String)

'                        'TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + subItem.Url + qoute + imgPath + " collapse=""1"">")
'                        TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + mySampleURL + qoute + ">")
'                        TextNode.Append("</innerchild>")
'                End Select
'                tmpMenu.SubItems.Add(subItem)
'            Next
'            TextNode.Append("</outerchild>")
'        End If
'        Return tmpMenu

'    End Function

'    Private Sub createMenus(ByVal basePage As BizPlanWebBase)
'        Dim IndexMenu() As String
'        Dim navMenu1 As Array, navMenu2 As Array, navCounter As Integer, navLabel As String
'        Dim navCounter1 As Integer, navLabel1 As String
'        Dim navRow As HtmlTableRow
'        Dim navCell As HtmlTableCell
'        Dim objPlanBase As PlanBase = New PlanBase
'        Dim qoute As Char = """"c
'        Dim strtest As String
'        If TypeOf (Page) Is IPlanBase Then
'            If CType(Session("Bar"), Integer) = 1 Then
'                navMenu1 = NavigationLinks
'                navMenu2 = Nothing
'            Else
'                If Not Session("merchantProUserID") Is Nothing Then
'                    Dim strGetRgihts As String() = PlanRights()
'                    navMenu1 = strGetRgihts
'                    navMenu2 = NavigationLinks
'                    IndexMenu = Menucount.ToString.Remove(Menucount.ToString.LastIndexOf(","c), 1).Split(","c)
'                Else
'                    navMenu1 = objPlanBase.Navigator
'                    navMenu2 = NavigationLinks

'                End If

'            End If
'        Else
'            navMenu1 = NavigationLinks
'            navMenu2 = Nothing
'        End If

'        If tblMenu1.Rows.Count = 0 Then
'            navCounter = 0
'            With MenuNode
'                '.Append("<upperparent" + " text=" + qoute + "InfiniPlan" + qoute + imgPath + "  >")
'                .Append("<upperparent" + " text=" + qoute + "InfiniPlan" + qoute + "  >")

'                For Each navLabel In navMenu1
'                    navRow = New HtmlTableRow
'                    navCell = New HtmlTableCell
'                    navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
'                    navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
'                    If TypeOf (Page) Is IPlanBase And CType(Session("Bar"), Integer) = Nothing Then
'                        If (Page.GetType.FullName = "ASP.PlanCover_aspx") Then
'                            basePage.CurPage = 1S
'                        End If

'                        Dim pass As Integer = navCounter
'                        ' second menu i.e home 
'                        If Not IndexMenu Is Nothing Then
'                            navCounter = CType(IndexMenu.GetValue(navCounter), Integer)
'                        Else
'                            navCounter = navCounter
'                        End If
'                        If basePage.CurPage = navCounter Then

'                            mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/welcome.aspx?cmd=" + navCounter1.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                            'MenuNode.Append("<parent" + CType(navCounter, String) + _
'                            '                       " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + mySampleURL + navCounter.ToString() + qoute + imgPath + "  >")
'                            MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + "  >")

'                            '=========================Sub Menu Table & Chart =====================================

'                            If TypeOf (Page) Is ITablesBase Or TypeOf (Page) Is IChartsBase Then
'                                tblText.Visible = False
'                                tblMenu2.Visible = True
'                                If tblMenu2.Rows.Count <= 1 Then
'                                    navCounter1 = 0

'                                    For Each navLabel1 In navMenu2
'                                        navRow = New HtmlTableRow
'                                        navCell = New HtmlTableCell

'                                        navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
'                                        navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")

'                                        If TypeOf (Page) Is IChartsBase Then
'                                            If navCounter1 <= 11 Then
'                                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "Chart.aspx?chartID=" + navCounter1.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                                                'MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_chart_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + "  />")
'                                                MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_chart_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + "  />")
'                                                secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_chart_" + "Plan Charts")
'                                            Else

'                                            End If
'                                        ElseIf TypeOf (Page) Is ITablesBase Then
'                                            mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "Table.aspx?tableID=" + navCounter1.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                                            'MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_table_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + "  />")
'                                            MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_table_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + "  />")
'                                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_tabel_" + "Plan Tables")
'                                        End If
'                                        navRow.Cells.Add(navCell)
'                                        tblMenu2.Rows.Add(navRow)
'                                        navCounter1 += 1
'                                    Next

'                                End If

'                            ElseIf TypeOf (Page) Is IPlanBusinessTracker Then
'                                If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
'                                    tblText.Visible = False
'                                    tblMenu2.Visible = True
'                                    If tblMenu2.Rows.Count <= 1 Then
'                                        navCounter1 = 0
'                                        For Each navLabel1 In navMenu2
'                                            navRow = New HtmlTableRow
'                                            navCell = New HtmlTableCell
'                                            navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
'                                            navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
'                                            If TypeOf (Page) Is IPlanBusinessTracker Then
'                                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "PlanTracker.aspx?NavigationD=" + navCounter1.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                                                'MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_tracker_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1""/>")
'                                                MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_tracker_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + "/>")
'                                                secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Tracker_Business Tracker")
'                                            End If
'                                            navRow.Cells.Add(navCell)
'                                            tblMenu2.Rows.Add(navRow)
'                                            navCounter1 += 1
'                                        Next

'                                    End If
'                                End If
'                            ElseIf TypeOf (Page) Is IMeterWizardBase Then
'                                If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
'                                    Dim boolCheck As Boolean = ObjCustomer.AnyEntityExsists(basePage.CurrentPlan.PlanID, basePage.GetConnectionData)

'                                    If boolCheck = True Then
'                                        tblText.Visible = False
'                                        tblMenu2.Visible = True
'                                        If tblMenu2.Rows.Count <= 1 Then
'                                            navCounter1 = 0
'                                            For Each navLabel1 In navMenu2
'                                                navRow = New HtmlTableRow
'                                                navCell = New HtmlTableCell
'                                                navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
'                                                navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
'                                                If TypeOf (Page) Is IMeterWizardBase Then
'                                                    mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "Speedometer.aspx?AnalysisID=" + navCounter1.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                                                    'MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_meter_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " collapse=""1""/>")
'                                                    MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_meter_" + navLabel1) + qoute + " value=" + qoute + mySampleURL + qoute + "/>")
'                                                    secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Meter_Speedometer Manager")
'                                                End If
'                                                navRow.Cells.Add(navCell)
'                                                tblMenu2.Rows.Add(navRow)


'                                                navCounter1 += 1
'                                            Next
'                                        End If
'                                    End If
'                                End If

'                            ElseIf (TypeOf (Page) Is ITextBase) Then
'                                tblText.Visible = True
'                                tblMenu2.Visible = False
'                                secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_text_" + "Plan Texts")
'                                If (Menu1.Items.Count < 1) Then
'                                    Dim ds As DataSet = TextOperations.GetPlanTextHeadings(basePage.GetConnectionData, basePage.CurrentPlan)
'                                    SetTextHeadings(ds.Tables(0), basePage)
'                                End If
'                                MenuNode.Append(TextNode.ToString)
'                            End If
'                            MenuNode.Append("</parent" + CType(navCounter, String) + ">")
'                            '========================= Sub Menu Table & Chart =====================================
'                        Else
'                            mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/welcome.aspx?cmd=" + navCounter.ToString() & "&config=" & CType(BllResult.ReturnObject, String)

'                            'MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " />")
'                            MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + " />")
'                        End If
'                        navCounter = pass
'                    Else
'                        'First Menu home 
'                        If basePage.CurPage = navCounter Then
'                            If CType(Session("Bar"), Integer) = 1 Then
'                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/Plan/" + RemoveSpaces(navLabel) + ".aspx" & "&config=" & CType(BllResult.ReturnObject, String)
'                                'MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute & "/InfiniPlan/Services/Plan/" + RemoveSpaces(navLabel) + ".aspx" & qoute + imgPath + " />")
'                                MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + " />")
'                            Else
'                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & RemoveSpaces(navLabel) + ".aspx" & "&config=" & CType(BllResult.ReturnObject, String)
'                                'MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + RemoveSpaces(navLabel) + ".aspx" + qoute + imgPath + " />")
'                                MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + " />")
'                            End If

'                        Else
'                            'First Menu   plan manager, exported plans , FAqs
'                            If CType(Session("Bar"), Integer) = 1 Then
'                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & "/InfiniPlan/Services/Plan/" + RemoveSpaces(navLabel) + ".aspx" & "&config=" & CType(BllResult.ReturnObject, String)
'                                ''''MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " />")
'                                MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + " />")
'                                '  MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/" + RemoveSpaces(navLabel) + ".aspx" + qoute + imgPath + " />")
'                            Else
'                                ' MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + RemoveSpaces(navLabel) + ".aspx" + qoute + imgPath + " />")
'                                mySampleURL = "http://" & System.Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?goto=" & RemoveSpaces(navLabel) + ".aspx" & "&config=" & CType(BllResult.ReturnObject, String)
'                                'MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + imgPath + " />")
'                                MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) + qoute + " value=" + qoute + mySampleURL + qoute + " />")
'                            End If
'                        End If
'                    End If
'                    navRow.Cells.Add(navCell)
'                    tblMenu1.Rows.Add(navRow)

'                    navCounter += 1
'                Next
'                .Append("</upperparent>")
'            End With


'        End If

'        If (TypeOf (Page) Is ITextBase) Then

'        Else
'            contMenu2.Attributes.Add("style", "display:none")
'        End If

'    End Sub

'    Public Function PlanRights() As String()
'        Dim dr As DataRow

'        Dim InternalMenu As StringBuilder
'        InternalMenu = New StringBuilder

'        Menucount = New StringBuilder
'        InternalMenu.Append("Home,")
'        Menucount.Append("0,")
'        Dim daMenu As Array

'        If bool = True Then
'            If HttpContext.Current.Session("CopyPlanid") Is Nothing Then
'                daMenu = dtUserRigths.Select(" Modelid  = 68 ")
'            Else
'                daMenu = dtUserRigths.Select(" Modelid  = 70 ")
'            End If

'        Else
'            If HttpContext.Current.Session("CopyPlanid") Is Nothing Then
'                daMenu = dtUserRigths.Select(" Modelid  = 68 and modeloptionid <> 8 and modeloptionid <> 9 ")
'            Else
'                daMenu = dtUserRigths.Select(" Modelid  = 70 and modeloptionid <> 8 and modeloptionid <> 9 ")
'            End If

'        End If


'        If daMenu.Length > 0 Then
'            For Each dr In daMenu
'                InternalMenu.Append(CStr(dr(4)) + ",")
'                Menucount.Append(CStr(dr(3)) + ",")
'            Next
'        End If
'        InternalMenu.Append("Close Plan,")

'        If bool = True Then
'            Menucount.Append("10,")
'        Else
'            Menucount.Append("8,")
'        End If


'        Dim strinnerMenu() As String = InternalMenu.ToString.Remove(InternalMenu.ToString.LastIndexOf(","c), 1).Split(","c)
'        Return strinnerMenu
'    End Function


'    Public Function RemoveSpaces(ByVal name As String) As String

'        Dim index As Integer
'        index = name.IndexOf(" ")
'        While (index > -1)
'            name = name.Replace(" ", "")
'            index = name.IndexOf(" ")
'        End While
'        Return name
'    End Function


'#Region "Properties"

'    Public ReadOnly Property NavigationLinks() As String()
'        Get
'            Return _navArray
'        End Get
'    End Property

'#End Region


'End Class

#End Region



Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports skmMenu
Imports System.Text


Public Class LeftBar
    Inherits System.Web.UI.UserControl
    Dim menuHashTable As New Hashtable
    Dim _navArray() As String
    'Public lblMain As String
    Public secondMenuTitle As String
    Public istMenuTitle As String
    Dim Menucount As StringBuilder
    Dim imgPath As String = " imgpath=""/images/folder.gif"" "

    Dim TextNode As New StringBuilder
    Dim NoPlan As String()
    Dim LoadPlan As String()
    Protected WithEvents Menu1 As skmMenu.Menu
    Protected WithEvents contMenu1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents contMenu2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblText As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblMenu2 As System.Web.UI.HtmlControls.HtmlTable
    Dim dtUserRigths As DataTable
    Dim EmployeemainNavigator As StringBuilder
    Dim ObjCustomer As CustomerStatus
    Dim MybasePage As BizPlanWebBase
    'Protected WithEvents Menu1 As skmMenu.Menu
    'Protected WithEvents contMenu1 As System.Web.UI.HtmlControls.HtmlTable
    'Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable
    'Protected WithEvents contMenu2 As System.Web.UI.HtmlControls.HtmlTable
    'Protected WithEvents tblText As System.Web.UI.HtmlControls.HtmlTable
    'Protected WithEvents tblMenu2 As System.Web.UI.HtmlControls.HtmlTable
    Dim MenuNode As New StringBuilder
    Public bool As Boolean
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents menuTextHeadings As skmMenu.Menu

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Dim IndexMenu() As String
    Dim navMenu1 As Array, navMenu2 As Array, navCounter As Integer, navLabel As String
    Dim navCounter1 As Integer, navLabel1 As String
    Dim navRow As HtmlTableRow
    Dim navCell As HtmlTableCell
    Dim objPlanBase As PlanBase = New PlanBase
    Dim qoute As Char = """"c
    Dim strtest As String
    Dim PageUrls() As String = {"PlanPreferences_aspx", "PlanWizardView_aspx", "PlanOutLine_aspx", "PlanPreferences_aspx", "PlanTracker_aspx", "Speedometer_aspx", "Printing_aspx"}
     
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Put user code to initialize the page here

        Dim tmpMenu As MenuItem
        Dim basePage As BizPlanWebBase

        basePage = CType(Me.Page, BizPlanWebBase)
        bool = ObjCustomer.CustomerSerivceStatus(basePage.GetConnectionData)

        EmployeemainNavigator = New StringBuilder
         

        _navArray = basePage.Navigator
        istMenuTitle = basePage.ResMgr.GetString("bizplan_menu_title_PlanNavigator")
        createMenus(basePage)
        CType(Me.FindControl("Index_Left").FindControl("LblXML"), Label).Text = MenuNode.ToString

    End Sub


    Public Sub SetTextHeadings(ByVal dt As DataTable, ByVal basePage As BizPlanWebBase)

        Dim qoute As Char = """"c
        Dim dr As DataRow
        Dim tmpMenu As MenuItem
        Dim da As Array
        da = dt.Select("ParentHeadingID = 'U_0' and (headingtype=3 or headingtype=4)")
        For Each dr In da
            Dim headingID As String = CStr(dr(1))
            Dim headingText As String = CStr(dr(2))

            If CInt(dr(7)) = 3 Then
                TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + "/InfiniPlan/Services/Text/PlanCover.aspx" + qoute + imgPath + " collapse=""1"" >")
            Else
                TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1)) + qoute + imgPath + " collapse=""1"">")
            End If
            TextNode.Append("</outerchild>")
        Next
        'old headings

        da = dt.Select("ParentHeadingID ='U_0' and headingtype=0 ")
        For Each dr In da
            Dim headingID As String = CStr(dr(1))
            Dim headingText As String = CStr(dr(2))
            TextNode.Append("<child" + " text=" + qoute + headingText + qoute + " value=" + qoute + "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1)) + qoute + imgPath + " collapse=""1"" >")

            CreateMenuItems(dt, headingText, headingID, basePage)
            TextNode.Append("</child>")
        Next
        
    End Sub
 
    Private Function CreateMenuItems(ByVal dt As DataTable, ByVal headingText As String, ByVal headingID As String, ByVal basePage As BizPlanWebBase) As MenuItem
        Dim qoute As Char = """"c
        Dim tmpMenu As New MenuItem
        Dim da As Array = dt.Select("ParentHeadingID = '" & headingID & "'")
        If (da.Length > 0 And headingText <> "Cover Page") Then
            Dim dr As DataRow
            '   TextNode.Append("<outerchild" + " text=" + qoute + headingText + qoute + " value=" + qoute + "" + qoute + imgPath + " collapse=""1"" >")
            For Each dr In da
                Dim subHeadingID As String = CStr(dr(1))
                Dim subHeadingText As String = CStr(dr(2))
                Dim subItem As MenuItem = CreateMenuItems(dt, subHeadingText, subHeadingID, basePage)
                Dim HeadingType As Integer = CInt(dr("HeadingType"))
                Select Case HeadingType
                    Case 0
                        subItem.Text = subHeadingText
                        subItem.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & subHeadingID
                        TextNode.Append("<innerchild" + " text=" + qoute + subItem.Text + qoute + " value=" + qoute + subItem.Url + qoute + imgPath + " collapse=""1"">")
                        TextNode.Append("</innerchild>")
                End Select
                tmpMenu.SubItems.Add(subItem)
            Next
            '  TextNode.Append("</outerchild>")
        End If
        Return tmpMenu

    End Function

    Private Sub createMenus(ByVal basePage As BizPlanWebBase)
       
        If TypeOf (Page) Is IPlanBase Then
            If CType(Session("Bar"), Integer) = 1 Then
                navMenu1 = NavigationLinks
                navMenu2 = Nothing
            Else
                If Not Session("merchantProUserID") Is Nothing And CType(Session("Bar"), Integer) = Nothing Then
                    'Dim strGetRgihts As String() = PlanRights()
                    'navMenu1 = strGetRgihts
                    'navMenu2 = NavigationLinks
                    'IndexMenu = Menucount.ToString.Remove(Menucount.ToString.LastIndexOf(","c), 1).Split(","c)
                    navMenu1 = objPlanBase.Navigator
                    navMenu2 = NavigationLinks
                Else
                    navMenu1 = objPlanBase.Navigator
                    navMenu2 = NavigationLinks
                End If
            End If
        Else
            navMenu1 = NavigationLinks
            navMenu2 = Nothing
        End If
        If tblMenu1.Rows.Count = 0 Then
            navCounter = 0
            With MenuNode
                .Append("<upperparent" + " text=" + qoute + "InfiniPlan" + qoute + imgPath + "  >")
                For Each navLabel In navMenu1
                    navRow = New HtmlTableRow
                    navCell = New HtmlTableCell
                    If TypeOf (Page) Is IPlanBase And CType(Session("Bar"), Integer) = Nothing Then
                        If (Page.GetType.FullName = "ASP.PlanCover_aspx") Then
                            basePage.CurPage = 0
                        End If
                        Dim pass As Integer = navCounter
                        ' second menu i.e home 
                        If Not IndexMenu Is Nothing Then
                            'navCounter = CType(IndexMenu.GetValue(navCounter), Integer)
                            navCounter = navCounter
                        Else
                            navCounter = navCounter
                        End If
                        If basePage.CurPage = navCounter Then
                            If navCounter = 0 Then
                                MenuNode.Append("<parent00     text=" + qoute + "Create Plan" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/CreatePlan.aspx" + qoute + imgPath + " collapse=""0""/>")

                                MenuNode.Append("<parent01     text=" + qoute + "Select Plan" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/PlanManager.aspx" + qoute + imgPath + " collapse=""0""/>")
                                MenuNode.Append("<parent02 text=" + qoute + "My Docments" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/ExportedPlans.aspx" + qoute + imgPath + " collapse=""1""/>")

                                If bool = True Then
                                    MenuNode.Append("<parent03 text=" + qoute + "Speedometers" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/SpeedometerManager.aspx" + qoute + imgPath + " collapse=""1""/>")
                                End If
                                MenuNode.Append("<parent04 text=" + qoute + "Web Tracker" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/WebTracker.aspx" + qoute + imgPath + " collapse=""1""/>")

                            End If

                            MenuNode.Append("<parent" + CType(navCounter, String) + _
                                                                   " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + "/InfiniPlan/Services/welcome.aspx?cmd=" + (navCounter).ToString() + qoute + imgPath + "  >")
                            SubMenu(basePage)
                        Else
                            If navCounter = 0 Then
                                MenuNode.Append("<parent00     text=" + qoute + "Create Plan" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/CreatePlan.aspx" + qoute + imgPath + " collapse=""0""/>")

                                MenuNode.Append("<parent01     text=" + qoute + "Select Plan" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/PlanManager.aspx" + qoute + imgPath + " collapse=""0""/>")
                                MenuNode.Append("<parent02 text=" + qoute + "My Docments" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/ExportedPlans.aspx" + qoute + imgPath + " collapse=""1""/>")
                                If bool = True Then
                                    MenuNode.Append("<parent03 text=" + qoute + "Speedometers" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/SpeedometerManager.aspx" + qoute + imgPath + " collapse=""1""/>")
                                End If
                                MenuNode.Append("<parent04 text=" + qoute + "Web Tracker" + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/WebTracker.aspx" + qoute + imgPath + " collapse=""1""/>")

                            End If
                            MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) + qoute + " value=" + qoute + "/InfiniPlan/Services/welcome.aspx?cmd=" + (navCounter).ToString() + qoute + imgPath + " />")
                        End If
                        navCounter = pass
                    Else
                        'new 
                        Dim text As String
                        'First Menu home First Menu   plan manager, exported plans , FAqs
                        text = basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel)
                        If text = "Plan Manager" Then text = "Select Plan"
                        If text = "Speedometer Manager" Then text = "Speedometers"
                        If text = "Exported Plans" Then text = "My Docments"
                        If text = "Web Tracker" Then text = "Web Tracker"
                        If CType(Session("Bar"), Integer) = 1 Then
                            MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + text + qoute + " value=" + qoute + "/InfiniPlan/Services/Plan/" + RemoveSpaces(navLabel) + ".aspx" + qoute + imgPath + " collapse=""1"">")
                        Else
                            MenuNode.Append("<parent" + CType(navCounter, String) + " text=" + qoute + text + qoute + " value=" + qoute + RemoveSpaces(navLabel) + ".aspx" + qoute + imgPath + " collapse=""0"">")
                        End If
                        MenuNode.Append("</parent" + CType(navCounter, String) + ">")
                        NoPlan = objPlanBase.Navigator
                        Dim intloop As Integer
                        Dim intloop12 As Integer
                        If bool = True Then
                            If navCounter + 1 = 5 Then
                                For intloop = 0 To NoPlan.Length - 1
                                    If Not basePage.CurrentPlan Is Nothing Then intloop12 = intloop Else intloop12 = navCounter - 1
                                    intloop12 = intloop
                                    MenuNode.Append("<parent" + CType(intloop, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + NoPlan(intloop)) + qoute + " value=" + qoute + "/InfiniPlan/Services/welcome.aspx?cmd=" + intloop12.ToString() + qoute + imgPath + " collapse=""0""/>")
                                Next
                            End If
                        Else
                            If navCounter + 1 = 4 Then
                                For intloop = 0 To NoPlan.Length - 1
                                    If Not basePage.CurrentPlan Is Nothing Then intloop12 = intloop Else intloop12 = navCounter
                                    intloop12 = intloop
                                    MenuNode.Append("<parent" + CType(intloop, String) + " text=" + qoute + basePage.ResMgr.GetString("bizplan_menu_menu2_" + NoPlan(intloop)) + qoute + " value=" + qoute + "/InfiniPlan/Services/welcome.aspx?cmd=" + intloop12.ToString() + qoute + imgPath + " collapse=""0""/>")
                                Next
                            End If
                        End If


                        'new 
                    End If
                    navRow.Cells.Add(navCell)
                    tblMenu1.Rows.Add(navRow)
                    navCounter += 1
                Next
                .Append("</upperparent>")
            End With
        End If
    End Sub

    ' this method check for menu when plan has loaded , to terminate the Select plan node 
    Function MenuPage(ByVal basePage As BizPlanWebBase) As Boolean
        If basePage.GetType.Name = PageUrls(0) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(1) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(2) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(3) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(4) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(5) Then
            Return True
        ElseIf basePage.GetType.Name = PageUrls(6) Then
            Return True
        Else
            Return False
        End If



    End Function

    Public Function SubMenu(ByVal basePage As BizPlanWebBase) As String
        If TypeOf (Page) Is ITablesBase Or TypeOf (Page) Is IChartsBase Then
            If tblMenu2.Rows.Count <= 1 Then
                navCounter1 = 0

                For Each navLabel1 In navMenu2
                    navRow = New HtmlTableRow
                    navCell = New HtmlTableCell
                    If TypeOf (Page) Is IChartsBase Then
                        If navCounter1 <= 11 Then
                            MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_chart_" + navLabel1) + qoute + " value=" + qoute + "Chart.aspx?chartID=" + navCounter1.ToString() + qoute + imgPath + " />")
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_chart_" + "Plan Charts")
                        Else
                        End If
                    ElseIf TypeOf (Page) Is ITablesBase Then
                        MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_table_" + navLabel1) + qoute + " value=" + qoute + "Table.aspx?tableID=" + navCounter1.ToString() + qoute + imgPath + "  />")
                        secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_tabel_" + "Plan Tables")
                    End If
                    navRow.Cells.Add(navCell)
                    tblMenu2.Rows.Add(navRow)
                    navCounter1 += 1
                Next

            End If

        ElseIf TypeOf (Page) Is IPlanBusinessTracker Then
            If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
                If tblMenu2.Rows.Count <= 1 Then
                    navCounter1 = 0
                    For Each navLabel1 In navMenu2
                        navRow = New HtmlTableRow
                        navCell = New HtmlTableCell
                        navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
                        navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
                        If TypeOf (Page) Is IPlanBusinessTracker Then
                            MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_tracker_" + navLabel1) + qoute + " value=" + qoute + "PlanTracker.aspx?NavigationD=" + navCounter1.ToString() + qoute + imgPath + " collapse=""1""/>")
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Tracker_Business Tracker")
                        End If
                        navRow.Cells.Add(navCell)
                        tblMenu2.Rows.Add(navRow)
                        navCounter1 += 1
                    Next
                End If
            End If
        ElseIf TypeOf (Page) Is IMeterWizardBase Then
            If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
                Dim boolCheck As Boolean = ObjCustomer.AnyEntityExsists(basePage.CurrentPlan.PlanID, basePage.GetConnectionData)
                If boolCheck = True Then
                    If tblMenu2.Rows.Count <= 1 Then
                        navCounter1 = 0
                        For Each navLabel1 In navMenu2
                            navRow = New HtmlTableRow
                            navCell = New HtmlTableCell
                            If TypeOf (Page) Is IMeterWizardBase Then
                                MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_meter_" + navLabel1) + qoute + " value=" + qoute + "Speedometer.aspx?AnalysisID=" + navCounter1.ToString() + qoute + imgPath + " collapse=""1""/>")
                                secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Meter_Speedometer Manager")
                            End If
                            navRow.Cells.Add(navCell)
                            tblMenu2.Rows.Add(navRow)
                            navCounter1 += 1
                        Next
                    End If
                End If
            End If
        ElseIf TypeOf (Page) Is IPrintingBase Or TypeOf (Page) Is IPlanLineBase Or TypeOf (Page) Is IPlanPreferencesBase Then
            If tblMenu2.Rows.Count <= 1 Then
                navCounter1 = 0
                For Each navLabel1 In navMenu2
                   
                    navRow = New HtmlTableRow
                    navCell = New HtmlTableCell
                    If TypeOf (Page) Is IPrintingBase Or TypeOf (Page) Is IPlanLineBase Or TypeOf (Page) Is IPlanPreferencesBase Then
                        If navLabel1 = "Plan Preview" Then
                            MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_printing_" + navLabel1) + qoute + " value=" + qoute + "/InfiniPlan/Services/Printing/Printing.aspx?printid=" + "1" + navCounter1.ToString() + qoute + imgPath + " collapse=""1""/>")
                        Else
                            MenuNode.Append("<parent" + CType(navCounter1, String) + " text =" + qoute + basePage.ResMgr.GetString("bizplan_menu_printing_" + navLabel1) + qoute + " value=" + qoute + "/InfiniPlan/Services/Printing/Printing.aspx?printid=" + navCounter1.ToString() + qoute + imgPath + " collapse=""1""/>")

                        End If
                        secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Meter_Speedometer Manager")
                    End If
                    navRow.Cells.Add(navCell)
                    tblMenu2.Rows.Add(navRow)
                    navCounter1 += 1
                Next
            End If

        ElseIf (TypeOf (Page) Is ITextBase) Then
            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_text_" + "Plan Texts")
            If (Menu1.Items.Count < 1) Then
                Dim ds As DataSet = TextOperations.GetPlanTextHeadings(basePage.GetConnectionData, basePage.CurrentPlan)
                SetTextHeadings(ds.Tables(0), basePage)
            End If
            MenuNode.Append(TextNode.ToString)

        ElseIf (TypeOf (Page) Is IWebTrackerBase) Then

        End If
        MenuNode.Append("</parent" + CType(navCounter, String) + ">")
    End Function

    Public Function PlanRights() As String()
        Dim dr As DataRow

        Dim InternalMenu As StringBuilder
        InternalMenu = New StringBuilder

        Menucount = New StringBuilder
        InternalMenu.Append("Home,")
        Menucount.Append("0,")
        Dim daMenu As Array

        If bool = True Then
            If HttpContext.Current.Session("CopyPlanid") Is Nothing Then
                daMenu = dtUserRigths.Select(" Modelid  = 68 ")
            Else
                daMenu = dtUserRigths.Select(" Modelid  = 70 ")
            End If

        Else
            If HttpContext.Current.Session("CopyPlanid") Is Nothing Then
                daMenu = dtUserRigths.Select(" Modelid  = 68 and modeloptionid <> 8 and modeloptionid <> 9 ")
            Else
                daMenu = dtUserRigths.Select(" Modelid  = 70 and modeloptionid <> 8 and modeloptionid <> 9 ")
            End If

        End If
 
        If daMenu.Length > 0 Then
            For Each dr In daMenu
                InternalMenu.Append(CStr(dr(4)) + ",")
                Menucount.Append(CStr(dr(3)) + ",")
            Next
        End If
        InternalMenu.Append("Close Plan,")

        If bool = True Then
            Menucount.Append("10,")
        Else
            Menucount.Append("8,")
        End If
 
        Dim strinnerMenu() As String = InternalMenu.ToString.Remove(InternalMenu.ToString.LastIndexOf(","c), 1).Split(","c)
        Return strinnerMenu
    End Function
 
    Public Function RemoveSpaces(ByVal name As String) As String

        Dim index As Integer
        index = name.IndexOf(" ")
        While (index > -1)
            name = name.Replace(" ", "")
            index = name.IndexOf(" ")
        End While
        Return name
    End Function


#Region "Properties"

    Public ReadOnly Property NavigationLinks() As String()
        Get
            Return _navArray
        End Get
    End Property

#End Region


End Class
