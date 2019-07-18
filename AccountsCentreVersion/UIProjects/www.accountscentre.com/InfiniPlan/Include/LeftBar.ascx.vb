Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules
Imports skmMenu

Public Class LeftBar
    Inherits System.Web.UI.UserControl
    Dim menuHashTable As New Hashtable
    Dim _navArray() As String
    'Public lblMain As String
    Public secondMenuTitle As String
    Public istMenuTitle As String
    Public boolCheck As Boolean
    Public obj As CustomerStatus
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents menuTextHeadings As skmMenu.Menu
    Protected WithEvents Menu1 As skmMenu.Menu
    Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblMenu2 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblText As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents contMenu1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents contMenu2 As System.Web.UI.HtmlControls.HtmlTable

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
        Dim basePage As BizPlanWebBase
        basePage = CType(Me.Page, BizPlanWebBase)
        _navArray = basePage.Navigator
        istMenuTitle = basePage.ResMgr.GetString("bizplan_menu_title_PlanNavigator")

        'If (basePage.IsPlanOpened()) Then
        '    ' This is to be Uncommented , after integration with Accounts Centre
        '    lblMain = basePage.CurrentPlan.PlanName
        'Else
        '    ' This is to be Uncommented , after integration with Accounts Centre
        '    lblMain = basePage.GetCustomerName
        'End If

        createMenus(basePage)

        If (Page.IsPostBack = False) Then
            '  PopulateMenuHashTable()
            If (TypeOf (basePage) Is ITextBase) Then
                If (Menu1.Items.Count < 1) Then
                    Dim ds As DataSet = TextOperations.GetPlanTextHeadings(basePage.GetConnectionData, basePage.CurrentPlan)
                    SetTextHeadings(ds.Tables(0), basePage)
                End If
            End If
        End If
    End Sub

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

    Public Sub SetTextHeadings(ByVal dt As DataTable, ByVal basePage As BizPlanWebBase)
        Dim dr As DataRow
        Dim tmpMenu As MenuItem
        Dim da As Array
        'Dim basePage As BizPlanWebBase
        'basePage = CType(Me.Page, BizPlanWebBase)
        'Dim ds As DataSet = TextOperations.GetPlanTextHeadings(basePage.GetConnectionData, basePage.CurrentPlan)

        ' New headings
        da = dt.Select("ParentHeadingID = 'U_0' and (headingtype=3 or headingtype=4)")

        For Each dr In da
            Dim headingID As String = CStr(dr(1))
            Dim headingText As String = CStr(dr(2))
            ' Dim headingText As String = CStr(dr(1))
            tmpMenu = CreateMenuItems(dt, headingText, headingID, basePage)

            'tmpMenu = CreateMenuItems(dt, headingText, headingID)
            tmpMenu.Text = headingText
            tmpMenu.MouseOverCssClass = "link-linkmenu5"
            If CInt(dr(7)) = 3 Then
                tmpMenu.Url = "/InfiniPlan/Services/Text/PlanCover.aspx"
            Else
                tmpMenu.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1))
            End If
            Dim fullheading As String = headingID
            Dim headingpart As String() = fullheading.Split("_"c)
            Dim value As String = headingpart(1)

            If basePage.CurItem = CInt(value) Then
                tmpMenu.CssClass = "link-linkmenu4"
            Else
                tmpMenu.CssClass = "link-linkmenu2c"
                Dim da2 As System.Data.DataRow() = dt.Select("HeadingID = '" & basePage.CurItem & "'")
                If da2.Length > 0 Then
                    If CStr(da2(0).Item(2)) = headingID Then
                        tmpMenu.CssClass = "link-linkmenu2c"
                    End If
                End If
            End If
            Menu1.Items.Add(tmpMenu)

        Next


        'old headings
        da = dt.Select("ParentHeadingID ='U_0' and headingtype=0 ")

        For Each dr In da
            Dim headingID As String = CStr(dr(1))
            Dim headingText As String = CStr(dr(2))
            tmpMenu = CreateMenuItems(dt, headingText, headingID, basePage)

            '  tmpMenu = CreateMenuItems(dt, headingText, headingID)
            'tmpMenu.CssClass = ""
            'tmpMenu = New MenuItem
            tmpMenu.Text = headingText
            tmpMenu.MouseOverCssClass = "link-linkmenu5"
            '")
            tmpMenu.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CStr(dr(1))
            Dim fullheading As String = headingID
            Dim headingpart As String() = fullheading.Split("_"c)
            Dim value As String = headingpart(1)
            If basePage.CurItem = CInt(value) Then
                tmpMenu.CssClass = "link-linkmenu4"
            Else
                tmpMenu.CssClass = "link-linkmenu2c"
                Dim da2 As System.Data.DataRow() = dt.Select("HeadingID = '" & basePage.CurItem & "'")
                If da2.Length > 0 Then
                    If CStr(da2(0).Item(2)) = headingID Then
                        tmpMenu.CssClass = "link-linkmenu4"
                    End If
                End If
            End If
            Menu1.Items.Add(tmpMenu)
        Next

        Menu1.CssClass = "link-linkmenu2b"

        Menu1.HighlightTopMenu = False
        Menu1.Opacity = CStr(100)
        Menu1.zIndex = 100
        Menu1.Cursor = skmMenu.MouseCursor.Pointer

    End Sub


    Private Function CreateMenuItems(ByVal dt As DataTable, ByVal headingText As String, ByVal headingID As String, ByVal basePage As BizPlanWebBase) As MenuItem

        Dim tmpMenu As New MenuItem
        'tmpMenu.Text = headingText
        'tmpMenu.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & headingID

        Dim da As Array = dt.Select("ParentHeadingID = '" & headingID & "'")

        If (da.Length > 0) Then
            Dim dr As DataRow
            For Each dr In da
                Dim subHeadingID As String = CStr(dr(1))
                Dim subHeadingText As String = CStr(dr(2)) 'basePage.ResMgr.GetString(CStr(menuHashTable.Item(subHeadingID)))

                '  Dim subHeadingText As String = CStr(dr(2))
                Dim subItem As MenuItem = CreateMenuItems(dt, subHeadingText, subHeadingID, basePage)
                Dim HeadingType As Integer = CInt(dr("HeadingType"))
                Select Case HeadingType
                    Case 0
                        subItem.Text = subHeadingText
                        subItem.Url = "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & subHeadingID
                    Case 1
                        subItem.Text = "Table: " + subHeadingText
                        subItem.Url = "/InfiniPlan/Services/Tables/Table.aspx?tableID=" & Table.GetTableID(subHeadingText.Replace(" ", ""))
                    Case 2
                        subItem.Text = "Chart: " + subHeadingText
                        subItem.Url = "/InfiniPlan/Services/Charts/Chart.aspx?chartID=" & Chart.GetChartID(subHeadingText.Replace(" ", ""))
                End Select

                subItem.CssClass = "tableBorder" '"text_menu_simple"
                subItem.MouseOverCssClass = "link-linkmenu4"
                tmpMenu.SubItems.Add(subItem)

            Next
        End If

        'Else
        Return tmpMenu

    End Function


    Private Sub createMenus(ByVal basePage As BizPlanWebBase)

        Dim navMenu1 As Array, navMenu2 As Array, navCounter As Integer, navLabel As String
        Dim navRow As HtmlTableRow
        Dim navCell As HtmlTableCell
        Dim objPlanBase As PlanBase = New PlanBase

        If TypeOf (Page) Is IPlanBase Then
            navMenu1 = objPlanBase.Navigator
            navMenu2 = CheckChatValues(NavigationLinks)
            'navMenu2 = NavigationLinks
        Else
            navMenu1 = NavigationLinks
            navMenu2 = Nothing
        End If


        If tblMenu1.Rows.Count = 0 Then
            navCounter = 0
            For Each navLabel In navMenu1
                navRow = New HtmlTableRow
                navCell = New HtmlTableCell

                navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'") ', this.style.backgroundColor='#8FB4DA'")
                navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'") ', this.style.backgroundColor='#CFE2F5'")
                navCell.Attributes.Add("vAlign", "top")
                navCell.Attributes.Add("height", "19")
                'navRow.Attributes.Add("onmouseover", "this.class='link-linkmenu4'")

                If TypeOf (Page) Is IPlanBase Then
                    If (Page.GetType.FullName = "ASP.PlanCover_aspx") Then
                        basePage.CurPage = 1
                    End If
                    ' second menu i.e home 
                    If basePage.CurPage = navCounter Then
                        navRow.Attributes.Add("class", "link-linkmenu3")
                        navCell.InnerHtml = "<img src='/images/InfiniPlan/blankarrow.jpg'  ><A class='link-linkmenu3' href='/InfiniPlan/Services/welcome.aspx?cmd=" & navCounter.ToString() & "' onclick='javascript:void(0);return SelectPlanNav(" & navCounter.ToString() & ");'>" & basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'

                        navRow.Attributes.Add("class", "link-linkmenu2")
                        If (navLabel = "Tables" Or navLabel = "Texts" Or navLabel = "Charts" Or navLabel = "Business Tracker" Or navLabel = "MeterWizard") Then

                            navCell.InnerHtml = "<img src='/images/InfiniPlan/arrow.jpg'  ><A class='link-linkmenu3' href='/InfiniPlan/Services/welcome.aspx?cmd=" & navCounter.ToString() & "' onclick='javascript:void(0);return SelectPlanNav(" & navCounter.ToString() & ");'>" & basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                        Else
                            navCell.InnerHtml = "<img src='/images/InfiniPlan/blankarrow.jpg'  ><A class='link-linkmenu3' href='/InfiniPlan/Services/welcome.aspx?cmd=" & navCounter.ToString() & "' onclick='javascript:void(0);return SelectPlanNav(" & navCounter.ToString() & ");'>" & basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'

                        End If


                    Else
                        ' second menu i.e  text,table,chart,..... close plan
                        navRow.Attributes.Add("class", "link-linkmenu2")
                        If (navLabel = "Tables" Or navLabel = "Texts" Or navLabel = "Charts" Or navLabel = "Business Tracker" Or navLabel = "MeterWizard") Then

                            navCell.InnerHtml = "<img src='/images/InfiniPlan/arrow.jpg'  ><A class='link-linkmenu2' href='/InfiniPlan/Services/welcome.aspx?cmd=" & navCounter.ToString() & "' onclick='javascript:void(0);return SelectPlanNav(" & navCounter.ToString() & ");'>" & basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                        Else
                            navCell.InnerHtml = "<img src='/images/InfiniPlan/blankarrow.jpg'  ><A class='link-linkmenu2' href='/InfiniPlan/Services/welcome.aspx?cmd=" & navCounter.ToString() & "' onclick='javascript:void(0);return SelectPlanNav(" & navCounter.ToString() & ");'>" & basePage.ResMgr.GetString("bizplan_menu_menu2_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'

                        End If

                    End If
                Else
                    'First Menu home 
                    If basePage.CurPage = navCounter Then
                        navRow.Attributes.Add("class", "link-linkmenu3")
                        navCell.InnerHtml = "<img src='/images/InfiniPlan/bluearrow.jpg'  ><A class='link-linkmenu3' href='" & RemoveSpaces(navLabel) & ".aspx'>" & basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                    Else
                        'First Menu   plan manager, exported plans , FAqs
                        navRow.Attributes.Add("class", "link-linkmenu2")
                        navCell.InnerHtml = "<img src='/images/InfiniPlan/blankarrow.jpg'  ><A class='link-linkmenu2' href='" & RemoveSpaces(navLabel) & ".aspx'>" & basePage.ResMgr.GetString("bizplan_menu_menu1_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                    End If
                End If
                navRow.Cells.Add(navCell)
                tblMenu1.Rows.Add(navRow)

                navCounter += 1
            Next
        End If

        'third menu i.e text  
        If (TypeOf (Page) Is ITextBase) Then
            tblText.Visible = True
            tblMenu2.Visible = False
            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_text_" + "Plan Texts")

            'third menu Plan Tracker
        ElseIf TypeOf (Page) Is IPlanBusinessTracker Then
            If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
                tblText.Visible = False
                tblMenu2.Visible = True
                If tblMenu2.Rows.Count <= 1 Then
                    navCounter = 0
                    For Each navLabel In navMenu2
                        navRow = New HtmlTableRow
                        navCell = New HtmlTableCell
                        navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
                        navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
                        navCell.Attributes.Add("vAlign", "middle")
                        navCell.Attributes.Add("height", "19")
                        navCell.Attributes.Add("onmouseover", "this.className ='MouseOverColor' ;")
                        navCell.Attributes.Add("onmouseout", "this.className ='MouseOutColor';")
                        If TypeOf (Page) Is IPlanBusinessTracker Then
                            If basePage.CurItem = navCounter Then
                                navRow.Attributes.Add("class", "link-linkmenu4")
                                navCell.InnerHtml = "<A class='link-linkmenu4' href='PlanTracker.aspx?NavigationD=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_tracker_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            Else
                                navRow.Attributes.Add("class", "link-linkmenu2")
                                navCell.InnerHtml = "<A class='link-linkmenu2' href='PlanTracker.aspx?NavigationD=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_tracker_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            End If
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Tracker_Business Tracker")

                        End If

                        navRow.Cells.Add(navCell)
                        tblMenu2.Rows.Add(navRow)


                        navCounter += 1
                    Next
                End If
            Else
                tblText.Visible = False
                tblMenu2.Visible = False
                contMenu2.Visible = False


            End If
            'Meter
            ElseIf TypeOf (Page) Is IMeterWizardBase Then
            If basePage.GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
                boolCheck = obj.AnyEntityExsists(basePage.CurrentPlan.PlanID, basePage.GetConnectionData)
                If boolCheck = True Then
                    tblText.Visible = False
                tblMenu2.Visible = True
                If tblMenu2.Rows.Count <= 1 Then
                    navCounter = 0
                    For Each navLabel In navMenu2
                        navRow = New HtmlTableRow
                        navCell = New HtmlTableCell
                        navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
                        navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
                        navCell.Attributes.Add("vAlign", "middle")
                        navCell.Attributes.Add("height", "19")
                        navCell.Attributes.Add("onmouseover", "this.className ='MouseOverColor' ;")
                        navCell.Attributes.Add("onmouseout", "this.className ='MouseOutColor';")
                        If TypeOf (Page) Is IMeterWizardBase Then
                            If basePage.CurItem = navCounter Then
                                navRow.Attributes.Add("class", "link-linkmenu4")
                                    navCell.InnerHtml = "<A class='link-linkmenu4' href='MeterWizard.aspx?AnalysisID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_meter_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            Else
                                navRow.Attributes.Add("class", "link-linkmenu2")
                                    navCell.InnerHtml = "<A class='link-linkmenu2' href='MeterWizard.aspx?AnalysisID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_meter_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            End If
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_Meter_Speedometer Manager")

                        End If

                        navRow.Cells.Add(navCell)
                        tblMenu2.Rows.Add(navRow)


                        navCounter += 1
                    Next
                End If

                '/Meter 
                Else
                    tblText.Visible = False
                    tblMenu2.Visible = False
                    contMenu2.Visible = False
                End If
            Else
                    tblText.Visible = False
                    tblMenu2.Visible = False
                    contMenu2.Visible = False
                End If
                'third menu i.e   table ,charts
            ElseIf TypeOf (Page) Is ITablesBase Or TypeOf (Page) Is IChartsBase Then
                tblText.Visible = False
                tblMenu2.Visible = True

                If tblMenu2.Rows.Count <= 1 Then
                    navCounter = 0
                    For Each navLabel In navMenu2
                        navRow = New HtmlTableRow
                        navCell = New HtmlTableCell

                        navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'") ', this.style.backgroundColor='#8FB4DA'")
                        navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'") ', this.style.backgroundColor='#CFE2F5'")
                        navCell.Attributes.Add("vAlign", "middle")
                        navCell.Attributes.Add("height", "19")
                        navCell.Attributes.Add("onmouseover", "this.className ='MouseOverColor' ;")
                        navCell.Attributes.Add("onmouseout", "this.className ='MouseOutColor';")
                        'navCell.Attributes.Add("onmouseover", "this.style.border='1px solid #9CC3DE'")
                        If TypeOf (Page) Is IChartsBase Then
                            If basePage.CurItem = navCounter Then
                                navRow.Attributes.Add("class", "link-linkmenu4")
                                navCell.InnerHtml = "<A class='link-linkmenu4' href='Chart.aspx?chartID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_chart_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            Else
                                navRow.Attributes.Add("class", "link-linkmenu2")
                                navCell.InnerHtml = "<A class='link-linkmenu2' href='Chart.aspx?chartID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_chart_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            End If
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_chart_" + "Plan Charts")
                        ElseIf TypeOf (Page) Is ITablesBase Then
                            If basePage.CurItem = navCounter Then
                                navRow.Attributes.Add("class", "link-linkmenu4")
                                navCell.InnerHtml = "<A class='link-linkmenu4' href='Table.aspx?tableID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_table_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            Else
                                navRow.Attributes.Add("class", "link-linkmenu2")
                                navCell.InnerHtml = "<A class='link-linkmenu2' href='Table.aspx?tableID=" & navCounter.ToString() & "'>" & basePage.ResMgr.GetString("bizplan_menu_table_" + navLabel) & "</A>" ' onclick='javascript:void(0);return confirmNavigation();'
                            End If
                            secondMenuTitle = basePage.ResMgr.GetString("bizplan_menu_secondmenutitle_tabel_" + "Plan Tables")
                        End If

                        navRow.Cells.Add(navCell)
                        tblMenu2.Rows.Add(navRow)

                        'class="tableborder"
                        navCounter += 1
                    Next
                End If
            Else
                contMenu2.Attributes.Add("style", "display:none")
            End If

    End Sub

    Public Sub PopulateMenuHashTable()

        menuHashTable.Clear()
        menuHashTable.Add("U_4", "bizplan_menu_ExecutiveSummary")
        menuHashTable.Add("U_5", "bizplan_menu_Objectives")
        menuHashTable.Add("U_6", "bizplan_menu_Mission")
        menuHashTable.Add("U_7", "bizplan_menu_Keystosuccess")
        menuHashTable.Add("U_9", "bizplan_menu_CompanySummary")
        menuHashTable.Add("U_10", "bizplan_menu_CompanyOwnerShip")
        menuHashTable.Add("U_11", "bizplan_menu_CompanyHistory")
        menuHashTable.Add("U_12", "bizplan_menu_StartupSummary")
        menuHashTable.Add("U_13", "bizplan_menu_CompanyLocationsAndFacilities")
        menuHashTable.Add("U_14", "bizplan_menu_Products")
        menuHashTable.Add("U_15", "bizplan_menu_Services")
        menuHashTable.Add("U_16", "bizplan_menu_ProductsAndServices")
        menuHashTable.Add("U_32", "bizplan_menu_ProductDescription")
        menuHashTable.Add("U_33", "bizplan_menu_ServicesDescription")
        menuHashTable.Add("U_34", "bizplan_menu_ProductsAndServicesDescription")
        menuHashTable.Add("U_35", "bizplan_menu_CompetitiveComparision")
        menuHashTable.Add("U_36", "bizplan_menu_CompetitiveComparision")
        menuHashTable.Add("U_37", "bizplan_menu_CompetitiveComparision")
        menuHashTable.Add("U_38", "bizplan_menu_SalesLiterature")
        menuHashTable.Add("U_39", "bizplan_menu_SalesLiterature")
        menuHashTable.Add("U_40", "bizplan_menu_SalesLiterature")
        menuHashTable.Add("U_41", "bizplan_menu_Sourcing")
        menuHashTable.Add("U_42", "bizplan_menu_Fulfillment")
        menuHashTable.Add("U_43", "bizplan_menu_Sourcing")
        menuHashTable.Add("U_44", "bizplan_menu_Technology")
        menuHashTable.Add("U_45", "bizplan_menu_Technology")
        menuHashTable.Add("U_46", "bizplan_menu_Technology")
        menuHashTable.Add("U_47", "bizplan_menu_FutureProducts")
        menuHashTable.Add("U_48", "bizplan_menu_FurtureServices")
        menuHashTable.Add("U_49", "bizplan_menu_ServiceAndSupport")
        menuHashTable.Add("U_50", "bizplan_menu_FutureProducts")
        menuHashTable.Add("U_51", "bizplan_menu_MarketAnalysisSummary")
        menuHashTable.Add("U_52", "bizplan_menu_MarketSegmentation")
        menuHashTable.Add("U_53", "bizplan_menu_IndustryAnalysis")
        menuHashTable.Add("U_54", "bizplan_menu_TargetMarketSegmentStartegy")
        menuHashTable.Add("U_55", "bizplan_menu_TargetMarketSegmentStrategy")
        menuHashTable.Add("U_56", "bizplan_menu_MarketNeeds")
        menuHashTable.Add("U_57", "bizplan_menu_MarketTrends")
        menuHashTable.Add("U_58", "bizplan_menu_MarketGrowth")
        menuHashTable.Add("U_59", "bizplan_menu_ServiceBusinessAnalysis")
        menuHashTable.Add("U_60", "bizplan_menu_IndustryAnalysis")
        menuHashTable.Add("U_61", "bizplan_menu_BusinessParticipants")
        menuHashTable.Add("U_62", "bizplan_menu_DistributingaService")
        menuHashTable.Add("U_63", "bizplan_menu_CompetitionAndBuyingPatterns")
        menuHashTable.Add("U_64", "bizplan_menu_MainCompetitors")
        menuHashTable.Add("U_65", "bizplan_menu_IndustryParticipants")
        menuHashTable.Add("U_66", "bizplan_menu_DistributionPatterns")
        menuHashTable.Add("U_67", "bizplan_menu_CompetitionsAndBuyingPatterns")
        menuHashTable.Add("U_68", "bizplan_menu_MainCompetitors")
        menuHashTable.Add("U_69", "bizplan_menu_StrategyAndImplementationSummary")
        menuHashTable.Add("U_70", "bizplan_menu_MarketingStrategy")
        menuHashTable.Add("U_71", "bizplan_menu_PricingStrategy")
        menuHashTable.Add("U_72", "bizplan_menu_PromotionStrategy")
        menuHashTable.Add("U_73", "bizplan_menu_DistributionStrategy")
        menuHashTable.Add("U_74", "bizplan_menu_ServiceAndSupport")
        menuHashTable.Add("U_75", "bizplan_menu_MarketingPrograms")
        menuHashTable.Add("U_76", "bizplan_menu_SalesStrategy")
        menuHashTable.Add("U_77", "bizplan_menu_StrategicAlliances")
        menuHashTable.Add("U_78", "bizplan_menu_PricingStrategy")
        menuHashTable.Add("U_79", "bizplan_menu_SalesStrategy")
        menuHashTable.Add("U_80", "bizplan_menu_StrategicAlliances")
        menuHashTable.Add("U_81", "bizplan_menu_Milestones")
        menuHashTable.Add("U_82", "bizplan_menu_StrategyPyramids")
        menuHashTable.Add("U_83", "bizplan_menu_ValueProposition")
        menuHashTable.Add("U_84", "bizplan_menu_CompetitiveEdge")
        menuHashTable.Add("U_85", "bizplan_menu_MarketingStrategy")
        menuHashTable.Add("U_86", "bizplan_menu_PositioningStatements")
        menuHashTable.Add("U_87", "bizplan_menu_PricingStrategy")
        menuHashTable.Add("U_88", "bizplan_menu_PromotionStrategy")
        menuHashTable.Add("U_89", "bizplan_menu_DistributionStrategy")
        menuHashTable.Add("U_90", "bizplan_menu_SalesStrategy")
        menuHashTable.Add("U_91", "bizplan_menu_SalesForecast")
        menuHashTable.Add("U_92", "bizplan_menu_SalesPrograms")
        menuHashTable.Add("U_93", "bizplan_menu_Milestones")
        menuHashTable.Add("U_94", "bizplan_menu_ManagementSummary")
        menuHashTable.Add("U_95", "bizplan_menu_ManagementTeam")
        menuHashTable.Add("U_96", "bizplan_menu_PersonalPlan")
        menuHashTable.Add("U_97", "bizplan_menu_OrganizationalStructure")
        menuHashTable.Add("U_98", "bizplan_menu_ManagementTeam")
        menuHashTable.Add("U_99", "bizplan_menu_PersonalPlan")
        menuHashTable.Add("U_100", "bizplan_menu_OrganizationalStructure")
        menuHashTable.Add("U_101", "bizplan_menu_ManagementTeams")
        menuHashTable.Add("U_102", "bizplan_menu_ManagementTeamGaps")
        menuHashTable.Add("U_103", "bizplan_menu_PersonalPlan")
        menuHashTable.Add("U_104", "bizplan_menu_OtherManagementConsiderations")
        menuHashTable.Add("U_105", "bizplan_menu_FinancialPlan")
        menuHashTable.Add("U_106", "bizplan_menu_ImportantAssumptions")
        menuHashTable.Add("U_107", "bizplan_menu_KeyFinancialIndicators")
        menuHashTable.Add("U_108", "bizplan_menu_BreakEvenAnalysis")
        menuHashTable.Add("U_109", "bizplan_menu_ProjectedProfitAndLoss")
        menuHashTable.Add("U_110", "bizplan_menu_ProjectedCashflow")
        menuHashTable.Add("U_111", "bizplan_menu_ProjectedBalanceSheet")
        menuHashTable.Add("U_112", "bizplan_menu_BusinessRatios")
        menuHashTable.Add("U_113", "bizplan_menu_Highlights")
        menuHashTable.Add("U_114", "bizplan_menu_StartupDetails")
        menuHashTable.Add("U_115", "bizplan_menu_Startup")
        menuHashTable.Add("U_116", "bizplan_menu_MarketAnalysis")
        menuHashTable.Add("U_117", "bizplan_menu_MarketAnalysis")
        menuHashTable.Add("U_118", "bizplan_menu_SalesForecast")
        menuHashTable.Add("U_119", "bizplan_menu_SalesMonthly")
        menuHashTable.Add("U_121", "bizplan_menu_Milestones")
        menuHashTable.Add("U_123", "bizplan_menu_SalesYearly")
        menuHashTable.Add("U_124", "bizplan_menu_SalesForecast")
        menuHashTable.Add("U_125", "bizplan_menu_SalesMonthly")
        menuHashTable.Add("U_126", "bizplan_menu_Payroll")
        menuHashTable.Add("U_127", "bizplan_menu_Payroll")
        menuHashTable.Add("U_128", "bizplan_menu_Payroll")
        menuHashTable.Add("U_129", "bizplan_menu_GeneralAssumption")
        menuHashTable.Add("U_130", "bizplan_menu_Benchmark")
        menuHashTable.Add("U_131", "bizplan_menu_BreakEvenAnalysis")
        menuHashTable.Add("U_132", "bizplan_menu_BreakEvenAnalysis")
        menuHashTable.Add("U_133", "bizplan_menu_BreakEvenAnalysis")
        menuHashTable.Add("U_134", "bizplan_menu_IncomeStatement")
        menuHashTable.Add("U_135", "bizplan_menu_CashFlow")
        menuHashTable.Add("U_136", "bizplan_menu_CashFlow")
        menuHashTable.Add("U_137", "bizplan_menu_BalanceSheet")
        menuHashTable.Add("U_138", "bizplan_menu_RatiosAnalysis")
        menuHashTable.Add("U_139", "bizplan_menu_PastPerformance")
        menuHashTable.Add("U_140", "bizplan_menu_PastPerformance")
        menuHashTable.Add("U_141", "bizplan_menu_Milestones")
        menuHashTable.Add("U_144", "bizplan_menu_SalesForecast")
        menuHashTable.Add("U_145", "bizplan_menu_SalesYearly")
        menuHashTable.Add("U_146", "bizplan_menu_Milestones")
        menuHashTable.Add("U_147", "bizplan_menu_CoverPage")
        menuHashTable.Add("U_148", "bizplan_menu_LegalPage")
        menuHashTable.Add("U_149", "bizplan_menu_PlanTitle")
        menuHashTable.Add("U_150", "bizplan_menu_Date")
        menuHashTable.Add("U_151", "bizplan_menu_PlanCopyNumber")
        menuHashTable.Add("U_152", "bizplan_menu_Ownership")
        menuHashTable.Add("U_153", "bizplan_menu_Name")
        menuHashTable.Add("U_154", "bizplan_menu_Title")
        menuHashTable.Add("U_155", "bizplan_menu_Address")
        menuHashTable.Add("U_156", "bizplan_menu_PhoneNumber")
        menuHashTable.Add("U_157", "bizplan_menu_Misc")

    End Sub
    Function CheckChatValues(ByVal values() As String) As String()
        If Not values.Length > 10 Then Return values

        Dim chartValues(values.Length - 2) As String
        For Each s As String In values
            If s.ToString = "Comparative" Then
                Array.Copy(values, chartValues, values.Length - 1)
                Return chartValues
            End If
        Next
        Return values
    End Function
End Class
