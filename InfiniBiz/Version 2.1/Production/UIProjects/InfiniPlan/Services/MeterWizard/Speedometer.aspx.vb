Option Strict Off
Option Explicit On 

Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Microsoft.Web.UI.WebControls
Imports System.Net
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml
Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Security.Cryptography.X509Certificates
Imports System.web

Public Class Speedometer
    ' Inherits System.Web.UI.Page
    Inherits MeterWizardBase
    Dim dtUserRigths As DataTable
    Dim Zoomid As String

#Region " Web Form Designer Generated Code "


    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
#Region "Varables"


    Public td As TableCell
    Public tr As TableRow
    Public spaceCounter As Integer
    Dim dspopulateTeee As DataSet
    Dim dsFAvoritesClip As DataSet
    Dim nodeindex As Integer
    Public bita As Integer
    Dim pid As New StringBuilder
    Dim SetCurrency As String
    Public obj As CustomerStatus
    Dim pidouter As New StringBuilder
    Dim str As String = "test"
    Protected WithEvents FavClip As System.Web.UI.HtmlControls.HtmlInputHidden
    Dim tsTimeSpanStart As TimeSpan
    Dim tsTimeSpanEnd As TimeSpan
    Dim Array() As String = [Enum].GetNames(GetType(FlashCriteriaType))
    Public month As New Hashtable
    Public movie As String
    Public updatedClip As String
    Public updatedLargeClip As String
    Public RealTimeBit As Boolean
    Public movieZoom As String
    Public boolMetername As Boolean
    Dim PRODUCT_ID As String
    Public cont As Integer = -1
    Public currecnyval As String
    Public objPlanvb As Plan
    Dim boolCheck As Boolean

    Public dsLoadSaveClipCompare As DataSet
    Public dsLoadSaveClip As DataSet
    Public _selectedEntity As DataTable
    Public strEntityID As String
    Public strMetername As String
    Public strCriteriaId As String
    Public strClipType As String
    Dim dtSearch As DataTable
    Private Const Select_Entity_List As String = "Select_Entity_List_Key"

    Protected WithEvents FavroiteMeter As System.Web.UI.WebControls.ImageButton


    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents lblID As System.Web.UI.WebControls.Label
    Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNamr As System.Web.UI.WebControls.Label
    Dim movieCompare As String
    Dim movieZoomCompare As String
    Protected WithEvents CurrentYear As System.Web.UI.WebControls.Label
    Protected WithEvents CurrentYear2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblError1 As System.Web.UI.WebControls.Label
    Dim ds As DataSet
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblZoomEntitName As System.Web.UI.WebControls.Label

    Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
    Dim criteria As String
    Dim clipcriteria As String
    Protected WithEvents Heading As System.Web.UI.WebControls.Label
    Protected WithEvents Title As System.Web.UI.WebControls.Label
    Protected WithEvents Panelheading As System.Web.UI.WebControls.Panel
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents btnShow As System.Web.UI.WebControls.Button
    Protected WithEvents ImageButton4 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents PanelZoom As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelNOProduct As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelButton As System.Web.UI.WebControls.Panel
    Protected WithEvents helpText As System.Web.UI.WebControls.Label
    Protected WithEvents lblsuggestion As System.Web.UI.WebControls.Label
    Protected WithEvents lblNoProducts As System.Web.UI.WebControls.Label
    Protected WithEvents dgEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Gridpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelLastYEars As System.Web.UI.WebControls.Panel

    Protected WithEvents rbCriterialist As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents PanelCentre As System.Web.UI.WebControls.Panel
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents flashheader As System.Web.UI.WebControls.Label
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Public AnalysisId As String
    Public QSAnalysisId As Integer
    Private designerPlaceholderDeclaration As System.Object
    Public stage As Integer
    Public deleteId As String

    Public favroitesId As String
    Public RemovefavroitesId As String
    Protected WithEvents lblName As System.Web.UI.WebControls.Label

    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents panelcompose As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelListing As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelFavorites As System.Web.UI.WebControls.Panel
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMeterName As System.Web.UI.WebControls.Label
    Protected WithEvents btnEdit As System.Web.UI.WebControls.Button
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents btnFavorites As System.Web.UI.WebControls.Button
    Protected WithEvents AjaxPanelTreeView As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Ajaxpanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents Ajaxpanel3 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents AjaxPanelMeterview As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents lblNoClip As System.Web.UI.WebControls.Label
    Protected WithEvents lblClipHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Panelnoclip As System.Web.UI.WebControls.Panel
    Public bit As Boolean = True
    Protected WithEvents Button5 As System.Web.UI.WebControls.Button
    Protected WithEvents aa As System.Web.UI.WebControls.Button
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lblnotfavorites As System.Web.UI.WebControls.Label
    Protected WithEvents PanelNoFAvorites As System.Web.UI.WebControls.Panel
    Protected WithEvents Table3 As System.Web.UI.WebControls.Table
    Protected WithEvents PanelFavorites1 As System.Web.UI.WebControls.Panel
    Protected WithEvents PlanFavTable As System.Web.UI.WebControls.Table
    Protected WithEvents PanelFav As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelListingforClips As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents cmbMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents meterimg As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents favimage As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Img1 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents titleimg As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl_Name As System.Web.UI.WebControls.Label
    Protected WithEvents txt_Name As System.Web.UI.WebControls.TextBox
    Protected WithEvents Listmeter As System.Web.UI.WebControls.Table

    Protected WithEvents MeterZoomView As System.Web.UI.WebControls.Table
    Protected WithEvents editmeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents deletemter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents zoommeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblDateError As System.Web.UI.WebControls.Label
    Protected WithEvents DatePanel As System.Web.UI.WebControls.Panel
    Protected WithEvents Label71 As System.Web.UI.WebControls.Label
    Protected WithEvents lblComparision As System.Web.UI.WebControls.Label


    Protected WithEvents chkboxPreviousYear As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblErrorMessage3 As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrorMessage4 As System.Web.UI.WebControls.Label
    Protected WithEvents asdasd As System.Web.UI.WebControls.Label
    Protected WithEvents Bdplite3 As BasicFrame.WebControls.BDPLite
    Protected WithEvents Bdplite4 As BasicFrame.WebControls.BDPLite

    Protected WithEvents RadioButton2 As System.Web.UI.WebControls.RadioButton


    Protected WithEvents BDPLite2 As BasicFrame.WebControls.BDPLite
    Protected WithEvents Error2 As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLite1 As BasicFrame.WebControls.BDPLite
    Protected WithEvents PanelImages As System.Web.UI.WebControls.Panel


    Protected WithEvents AdvanceMeters As System.Web.UI.WebControls.Table
    Protected WithEvents imgbtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents imgbtnAdv As System.Web.UI.WebControls.Button
    Protected WithEvents lblCompare As System.Web.UI.WebControls.Label
    Protected WithEvents PanelCompare As System.Web.UI.WebControls.Panel
    Protected WithEvents CompareTable As System.Web.UI.WebControls.Table
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLiteFrom As BasicFrame.WebControls.BDPLite
    Protected WithEvents BDPLiteTo As BasicFrame.WebControls.BDPLite
    Protected WithEvents lblfiscalyear As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents lblID_compare As System.Web.UI.WebControls.Label
    Protected WithEvents txtID_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblName_compare As System.Web.UI.WebControls.Label
    Protected WithEvents txtName_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch_compare As System.Web.UI.WebControls.Button
    Protected WithEvents dgActualEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSelect_compare As System.Web.UI.WebControls.Button
    Protected WithEvents dgHoldEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PanelHoldItems As System.Web.UI.WebControls.Panel
    Protected WithEvents lbl_Name_compare As System.Web.UI.WebControls.Label
    Protected WithEvents txt_Name_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblError_compare As System.Web.UI.WebControls.Label
    Protected WithEvents mypanel As System.Web.UI.WebControls.Panel
    Protected WithEvents btnShowComparision As System.Web.UI.WebControls.Button
    Protected WithEvents PlanCompareTable As System.Web.UI.WebControls.Table
    Protected WithEvents PanelCompareProducts As System.Web.UI.WebControls.Panel
    Protected WithEvents btnNext_Compare As System.Web.UI.WebControls.Button
    Protected WithEvents lblCMeterName As System.Web.UI.WebControls.Label
    Protected WithEvents chkMTD As System.Web.UI.WebControls.CheckBox
    Protected WithEvents lblService As System.Web.UI.WebControls.Label
    Protected WithEvents ddlService As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblScope As System.Web.UI.WebControls.Label
    Protected WithEvents ddlScope As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblInfinidoc As System.Web.UI.WebControls.Label
    Protected WithEvents rbProductOption As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents chkQuantity As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkCurrency As System.Web.UI.WebControls.CheckBox
    Protected WithEvents ad As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Public strFavDecision As String
#End Region

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Public TitleStart() As String = {"Speedometer Wizard", "Analysis Criteria", "Speedometer Time Period", "Product or Service Selection"}

    Public SuggestionStart() As String = {"Click <b>Next</b> button to start the <b>Speedometer Wizard</b>", "Select the desired type of analysis. Click <b>Next</b> button to continue", "Select the desired time period of Speedometer. <b>Click</b> Next button to continue", "  Select the desired product or service and save the Speedometer"}

    Public helpStart As String = "The <b>Speedometer Wizard</b> helps you create <b>Speedometers</b> for your business plan." _
    & " A Speedometer gives you an analysis of the plan you created. It compares the data entered at the time  " _
    & " of plan creation with the actual sales and expenses records within your accounts."


    Public helpCriteria As String = "In this step you can select the type of analysis for the <b>Speedometer</b>. Different types give analysis about different aspects of your plan"

    Public helpClip As String = "In this step you can select the time period of <b>Speedometer</b>. You can select Past yeas also for comparing current year data with past records."
    Public helpSelectEntity As String = "In this step you can select a desired product(s) or service(s) to analyse its performance. You can only select one product or service if you are creating an <b>Estimate</b> or <b>Deviation Speedometer</b>. However the speedometer with <b>Actual</b> as the speedometer type can have multiple products or services selected simultaneously."

#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Session("Tracker") = 1

        deletemter.Attributes.Add("onClick", "javascript:void(0);return delete_prompt();")
        FavroiteMeter.Visible = False
        CheckScope()
        addMonthds()
        meterimg.Visible = False
        Dim dsName As DataSet = objPlanvb.GetCurrencyName(GetConnectionData, CurrentPlan.PlanID)
        Dim strName As String = CType(dsName.Tables(0).Rows(0).Item(0), String)
        ' Checking for same currency as Accountscentre 
        If GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
            boolCheck = obj.AnyEntityExsists(CurrentPlan.PlanID, GetConnectionData)
            ' Checking for Any linked product or service Exsist or not  
            If boolCheck = True Then
                lblClipHeading.Text = "This is a list of all the <b>Speedometers</b> from the plan:<b>" + CurrentPlan.PlanName '+ "'</b><p>   To add a <b>Speedometer</b> to the <b>Favourites List</b>, click on the <b>Add to Favourites</b> link under the <b>Speedometer</b></p>"
                SetFocus(testpanel)
                Session("Speedometer") = Nothing
                Dim RecordWebService As New com.metertesting.www.MeterViewService
                CurPage = 6
                dspopulateTeee = obj.PopulateMeterTree(CurrentPlan.PlanID, GetConnectionData)

                dsFAvoritesClip = obj.Get_favoritesClip(CurrentPlan.PlanID, GetConnectionData)
                If Not IsNothing(Request.QueryString("DID")) And Not Page.IsPostBack Then
                    deleteId = Request.QueryString("DID")
                    obj.DeleteEntity(CurrentPlan.PlanID, deleteId, GetConnectionData)
                    Response.Redirect("Speedometer.aspx?AnalysisID=1")
                End If
                If Not IsNothing(Request.QueryString("FID")) And Not Page.IsPostBack Then
                    favroitesId = Request.QueryString("FID")
                    If Not Request.Form.Item("FavClip") Is Nothing Then
                        strFavDecision = Request.Form.Item("FavClip")
                    End If
                    obj.Add_Fav_Entity(CurrentPlan.PlanID, favroitesId, GetConnectionData)
                    Response.Redirect("Speedometer.aspx?AnalysisID=1")
                End If
                If Not IsNothing(Request.QueryString("RFID")) And Not Page.IsPostBack Then
                    RemovefavroitesId = Request.QueryString("RFID")
                    If Not Request.Form.Item("FavClip") Is Nothing Then
                        strFavDecision = Request.Form.Item("FavClip")
                    End If
                    obj.Remove_Fav_Entity(CurrentPlan.PlanID, RemovefavroitesId, GetConnectionData)
                    Response.Redirect("Speedometer.aspx?AnalysisID=2")
                End If
                If Not IsNothing(Request.QueryString("CID")) And Not Page.IsPostBack Then
                    Dim ComparisionId As String = Request.QueryString("CID")

                    Session("Cid") = ComparisionId
                    Response.Redirect("Speedometer.aspx?AnalysisID=3")
                End If
                If Not IsNothing(Request.QueryString("QID")) And Not Page.IsPostBack Then
                    stage = 3
                    Session("STG") = stage
                    btnBack.Enabled = True
                    Session("QID") = 1
                    btnShow_Click(sender, e)
                    CollectiveSettings()
                    CurPage = 6
                    CurItem = 0
                    lblHeading.Text = "Edit Meter"
                    panelcompose.Visible = True
                    PanelButton.Visible = True
                Else
                    If Not Page.IsPostBack Then
                        addMonthdsToBPLITE()
                        QSAnalysisId = CInt(Request.QueryString("AnalysisID"))
                        CurPage = 6
                        CurItem = QSAnalysisId
                        Session("item") = QSAnalysisId

                        If QSAnalysisId = 0 Then
                            If Not Session("merchantProUserID") Is Nothing Then
                                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
                                Dim dr As DataRow
                                If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 1 ").Length > 0 Then
                                    Session("LoadList") = Nothing
                                    Session("test") = Nothing
                                    lblHeading.Text = "Create a Meter"
                                    panelcompose.Visible = True
                                    PanelButton.Visible = True
                                    titleimg.Visible = True
                                    Session("MID") = Nothing
                                    Session("SelectIndex") = Nothing
                                    stage = 0
                                    Session("STG") = stage
                                    bit = False
                                    Session("bit") = bit
                                Else
                                    lblHeading.Text = "Meter Listing"
                                    PanelListing.Visible = True
                                    editmeter.Visible = False
                                    QSAnalysisId = 1
                                    If dspopulateTeee.Tables(0).Rows.Count = 0 Then
                                        PanelListing.Visible = False
                                        Panelnoclip.Visible = True
                                        lblNoClip.Visible = True
                                        lblNoClip.Text = "The Speedometer list is empty. To create a speedometer, click the <b>Compose Meter</b> link."
                                    Else
                                    End If
                                    Session("STG") = stage
                                    bit = False
                                End If
                            Else
                                Session("LoadList") = Nothing
                                Session("test") = Nothing
                                lblHeading.Text = "Create a Meter"
                                panelcompose.Visible = True
                                PanelButton.Visible = True
                                titleimg.Visible = True
                                Session("MID") = Nothing
                                Session("SelectIndex") = Nothing
                                stage = 0
                                Session("STG") = stage
                                bit = False
                                Session("bit") = bit
                            End If
                        ElseIf QSAnalysisId = 1 Then
                            lblHeading.Text = "Meter Listing"
                            PanelListing.Visible = True
                            '''Nisar Addition
                            If Not Session("merchantProUserID") Is Nothing Then
                                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
                                Dim dr As DataRow
                                If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 1 ").Length > 0 Then editmeter.Visible = True
                            Else
                                editmeter.Visible = True
                            End If
                            '''' end
                            If dspopulateTeee.Tables(0).Rows.Count = 0 Then
                                PanelListing.Visible = False
                                Panelnoclip.Visible = True
                                lblNoClip.Visible = True
                                lblNoClip.Text = "The Speedometer list is empty. To create a speedometer, click the <b>Compose Meter</b> link."
                            Else
                            End If
                            Session("STG") = stage
                            bit = False
                        ElseIf QSAnalysisId = 2 Then
                            lblHeading.Text = "Favourite Speedometer List from current plan"
                            If dsFAvoritesClip.Tables(0).Rows.Count = 0 Then
                                PanelFavorites.Visible = False
                                PanelNoFAvorites.Visible = True
                                lblnotfavorites.Visible = True
                                lblnotfavorites.Text = "The <b> Favourites List</b>  is empty. <p>To add a <b> Speedometer</b>  to the list, click the <b> Add to Favourites</b>  link on <b> Meter Listing</b>  page.</p>"
                            ElseIf dsFAvoritesClip.Tables(0).Rows.Count > 0 Then
                                PanelFavorites.Visible = True
                                LoadFlashFilesfromDb()
                            End If
                        ElseIf QSAnalysisId = 3 Then
                            addMonthdsToBPLITECompare()
                            If Not Session("Cid") Is Nothing Then
                                ComparativeSettings(Session("Cid"))
                            Else
                                lblHeading.Text = "Compare Comparision"
                                PanelCompareProducts.Visible = True
                                btnNext_Compare.Enabled = False
                                lblCompare.Visible = True
                                Dim td As TableCell
                                Dim tr As TableRow
                                td = New TableCell
                                tr = New TableRow
                                Dim tr_Br As New TableRow
                                Dim tc_Br As New TableCell
                                movie = "+"
                                td.Text = movie
                                tr.Attributes.Add("class", "trsettings")
                                tr.Controls.Add(td)
                                tr_Br.Attributes.Add("class", "trsettings")
                                tr_Br.Cells.Add(tc_Br)
                                PlanCompareTable.Rows.Add(tr)
                                PlanCompareTable.Rows.Add(tr_Br)
                            End If
                            Session("Cid") = Nothing
                        End If
                        GetEntity()
                        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
                        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
                        Session(Select_Entity_List) = _selectedEntity
                        PageLoadSettings()
                        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
                        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
                        Session(Select_Entity_List) = _selectedEntity
                        If dspopulateTeee.Tables(0).Rows.Count > 0 And QSAnalysisId = 1 Then
                            If Not IsNothing(Request.QueryString("Editid")) Then
                                '  Load_treeView(CType(dspopulateTeee.Tables(0).Rows(0).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(1), String))
                                Session("strMeterId") = Request.QueryString("Editid")
                                Editmeter1()
                            ElseIf Not IsNothing(Request.QueryString("Zoomid")) Then
                                Session("strMeterId") = Request.QueryString("Zoomid")
                                ZoomSmall()

                            ElseIf Not IsNothing(Request.QueryString("Deleteid")) Then
                                Session("strMeterId") = Request.QueryString("Deleteid")
                                DeleteMeter()

                            Else
                                Load_treeView(CType(dspopulateTeee.Tables(0).Rows(0).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(1), String))


                            End If

                        End If
                    Else
                        If dspopulateTeee.Tables(0).Rows.Count > 0 And Session("STG") = 0 Then
                            Load_treeView(CType(dspopulateTeee.Tables(0).Rows(0).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(nodeindex).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(1), String))
                        End If
                        stage = CType(Session("STG"), Integer)
                        titleimg.Visible = False
                        btnBack.Enabled = True
                    End If
                    DefaultSettings()

                    CurItem = CType(Session("item"), Integer)
                End If
            Else
                ' ELSE Checking for Any linked product or service Exsist or not 
                SetFocus(testpanel)
                lblHeading.Text = "Create a Meter"
                lblNoProducts.Text = "<p class=MsoNormal style='mso-layout-grid-align:none;text-autospace:none'><span " _
                             & "style='font-size:8.0pt;font-family:Verdana;color:black'>The Speedometer Wizard" _
                            & " is inaccessible due to lack of required data. To enable the Speedometer Wizard" _
                            & " follow these steps:<o:p></o:p></span></p>" _
                            & "<p class=MsoNormal style='mso-layout-grid-align:none;text-autospace:none'><span" _
                            & "style='font-size:8.0pt;font-family:Verdana;color:black'>- Import (Product/Services) into" _
                            & " InfiniPlan table (Sales Forecast).<o:p></o:p></span></p>" _
                            & "<p class=MsoNormal><span style='font-size:8.0pt;font-family:Verdana;color:black'>- Enter" _
                            & " estimated values for the products in the above mentioned table.</span><span" _
                            & "style='font-size:8.0pt;font-family:Verdana'><o:p></o:p></span></p>"
                PanelNOProduct.Visible = True
            End If
        Else
            'ELSE Checking for same currency as Accountscentre 
            SetFocus(testpanel)
            currecnyval = CType(Session("CurrecnyName"), String) + " " + CType(GetCustomerCurrency.Split(","c).GetValue(1), String)
            lblHeading.Text = "Create a Meter"
            lblNoProducts.Text = ResMgr.GetString("BizPlan_Services_Meter_PlanMeter_lblFirstHelp") + "<p> Please use <a href ='/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx' ><b>Plan Wizard</b> </a> " _
          & " to change the currency of your business plan (" + strName + " " + CurrentPlan.Currency + ") according to your Accounts Centre profile ( " + currecnyval + ").</p>"
            PanelNOProduct.Visible = True
            Session("currency") = "1"
            Session("SelectIndex") = Nothing
            CurPage = 6
            CurItem = 0
        End If
      

    End Sub

    Private Sub CheckScope()

        If ddlScope.SelectedIndex = 0 Then
            lblService.Enabled = False
            ddlService.Enabled = False

        ElseIf ddlScope.SelectedIndex = 1 Then
            lblService.Enabled = True
            ddlService.Enabled = True
            lblService.Visible = True
            ddlService.Visible = True
        End If

    End Sub

    Private Sub ComparativeSettings(ByVal ComparisionId As String)

        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
        Session(Select_Entity_List) = _selectedEntity
        dsLoadSaveClipCompare = obj.GetEntityByPID(CurrentPlan.PlanID, ComparisionId, GetConnectionData)
        lblHeading.Text = "Compare Comparision"
        PanelCompareProducts.Visible = True
        btnNext_Compare.Enabled = False
        lblCompare.Visible = True
        strCriteriaId = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(2), String)
        strMetername = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(6), String)
        Session("ProStartdateCompare") = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(7), String)
        Session("ProEnddateCompare") = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(8), String)
        Session("PlanStartdateCompare") = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(9), String)
        Session("PlanEnddateCompare") = CType(dsLoadSaveClipCompare.Tables(0).Rows(0).Item(10), String)
        Dim td_Movie As TableCell
        Dim tr_Movie As TableRow
        td_Movie = New TableCell
        tr = New TableRow
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        movie = dsLoadSaveClipCompare.Tables(1).Rows(0).Item(1)
        td_Movie.Text = movie
        tr_Movie.Attributes.Add("class", "trsettings")
        tr_Movie.Controls.Add(td_Movie)
        tr_Br.Attributes.Add("class", "trsettings")
        tr_Br.Cells.Add(tc_Br)
        PlanCompareTable.Rows.Add(tr_Movie)
        PlanCompareTable.Rows.Add(tr_Br)

    End Sub

    Private Sub addMonthdsToBPLITE()

        Dim formatedDAte As String
        If Not Request.QueryString("QID") Is Nothing Then
            dsLoadSaveClip = obj.GetEntityByPID(CurrentPlan.PlanID, Request.QueryString("QID"), GetConnectionData)
            Session("PlanStartdate") = dsLoadSaveClip.Tables(0).Rows(0).Item(9)
            Session("PlanEnddate") = dsLoadSaveClip.Tables(0).Rows(0).Item(10)
            Session("ProStartdate") = dsLoadSaveClip.Tables(0).Rows(0).Item(7)
            Session("ProEnddate") = dsLoadSaveClip.Tables(0).Rows(0).Item(8)

        Else
            ''CurrentYear.Text = " (Fiscal Year is from <b>" + cmbMonth.Items(0).Text + "</b> to <b> " + cmbMonth.Items(11).Text + "</b>)"
            CurrentYear.Text = " (Fiscal Year is from <b>" + cmbMonth.Items(0).Text
            CurrentYear2.Text = " </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp   to <b> " + cmbMonth.Items(11).Text + "</b>)"
            BDPLite1.SelectedValue = cmbMonth.Items(0).Text ' DateTime.Today
            Dim qoute As Char = "/"c
            Dim strGetDate As String() = Date.Parse(cmbMonth.Items(11).Text).ToShortDateString.Split(qoute)
            formatedDAte = CStr(Date.DaysInMonth(CInt(strGetDate(2)), CInt(strGetDate(1))))
            BDPLite2.SelectedValue = formatedDAte + " " + cmbMonth.Items(11).Text
        End If

    End Sub

    Private Sub addMonthdsToBPLITECompare()

        Dim formatedDAte As String
        Dim qoute As Char = "/"c
        Dim strGetDate As String() = Date.Parse(cmbMonth.Items(11).Text).ToShortDateString.Split(qoute)
        formatedDAte = CStr(Date.DaysInMonth(CInt(strGetDate(2)), CInt(strGetDate(1))))
        BDPLiteFrom.SelectedValue = cmbMonth.Items(0).Text
        BDPLiteTo.SelectedValue = formatedDAte + " " + cmbMonth.Items(11).Text


    End Sub

    Private Sub addMonthds()

        cmbMonth.Items.Clear()
        Dim startingYear As Integer
        Dim startingMonth As Integer
        startingYear = CurrentPlan.StartYear
        startingMonth = CInt([Enum].Parse(GetType(BusinessPlanMonths), CurrentPlan.StartMonth))


        Dim strKeyMonthArry As String() = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", _
                "Aug", "Sep", "Oct", "Nov", "Dec"}

        For i As Integer = 0 To 11
            cmbMonth.Items.Add(New ListItem(strKeyMonthArry.GetValue(startingMonth).ToString & " " & startingYear, CStr(i)))
            startingMonth += 1
            If startingMonth > 11 Then
                startingYear += 1
                startingMonth = 0

            End If
        Next
        Dim formatedDAte As String

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click

        flashheader.Visible = False
        Try
            If stage = BasicStages.WelcomePage Then
                WizardFarwardTrack(BasicStages.WelcomePage)
            End If
            If stage = BasicStages.CriteriaSelection Then
                WizardFarwardTrack(BasicStages.CriteriaSelection)
            End If
            If stage = BasicStages.TimeSelection Then
                WizardFarwardTrack(BasicStages.TimeSelection)

            End If
            If stage = BasicStages.ProductSelection Then
                WizardFarwardTrack(BasicStages.ProductSelection)
            End If
            If Not Session("LoadList") Is Nothing Then
                Session("LoadList") = Nothing
                Session("test") = Nothing
                Response.Redirect("Speedometer.aspx?AnalysisID=1")
            Else
            End If
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try

    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        If Not txt_Name.Text = "" Then
            If Not REValidator.IsIdentifierforMeter(txt_Name.Text) Then
                lblError.Text = "Error:Give Valid Meter name"
                txt_Name.Text = ""
                lblError.Visible = True
                Exit Sub
            End If
            boolMetername = obj.GetMeterName(txt_Name.Text.ToUpper.Trim, CurrentPlan.PlanID, GetConnectionData)
            If boolMetername = True Then   '// use to check it is already exits 
                lblError.Text = "Error:Name alreadt Exsist.Plz give some else proper name "
                lblError.Visible = True
                txt_Name.Text = ""
                Exit Sub
            End If
        Else
            If Not IsNothing(Request.QueryString("QID")) Then
            Else
                lblError.Text = "Error:Give proper Meter name"
                lblError.Visible = True

                Exit Sub
            End If
        End If
        txt_Name.Enabled = False
        Dim inttrack As Integer
        If Not Session("QID") Is Nothing Then
        Else
            inttrack = 1
            Session("QID") = inttrack
        End If

        If Not IsNothing(Request.QueryString("QID")) And CType(Session("QID"), Integer) = 1 Then
            btnNext.Enabled = False
            FUN_ALterMovie()
            inttrack = CType(Session("QID"), Integer) + 1
            Session("QID") = inttrack
        Else
            FUN_CreateMovie()
        End If
        btnShow.Enabled = False
        '''' Nisar Add
        '''btnNext.Enabled = True
        btnNext.Enabled = False
        If Not Session("merchantProUserID") Is Nothing Then
            Dim dtUserRigths As DataTable
            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            Dim dr As DataRow
            If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 2 ").Length > 0 Then
                btnNext.Enabled = True
            Else
                btnNext.Enabled = False
            End If
        Else
            btnNext.Enabled = True
        End If


        ''''' end
        Session("LoadList") = 1
        Session("test") = 1

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Session("LoadList") = Nothing
        Session("clipval") = Nothing
        Session("STG") = Nothing
        Session("selectedval") = Nothing
        Session("List") = Nothing
        Session("QID") = Nothing
        Session("bit") = Nothing
        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        Session("SetclipLarge") = Nothing
        Session("singleproduct") = Nothing
        Session(Select_Entity_List) = Nothing
        Session("ds") = Nothing
        Session("MID") = Nothing
        Session("MName") = Nothing
        Session("FLAnalysisid") = Nothing
        Response.Redirect("Speedometer.aspx")

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        flashheader.Visible = False
        Title.Width = Title.Width.Percentage(75)
        Heading.Width = Heading.Width.Percentage(75)
        Try
            Session("LoadList") = Nothing
            stage = CType(Session("STG"), Integer) - 1
            If stage = BasicStages.WelcomePage Then
                WizardBackTrack(BasicStages.WelcomePage)
            ElseIf stage = BasicStages.CriteriaSelection Then
                WizardBackTrack(BasicStages.CriteriaSelection)
            ElseIf stage = BasicStages.TimeSelection Then
                WizardBackTrack(BasicStages.TimeSelection)
                btnNext.Enabled = True
            End If
        Catch ex As BizPlanDBInvalidDataException
        End Try

    End Sub

    Function WizardBackTrack(ByVal decision As Integer) As Integer

        If decision = BasicStages.WelcomePage Then
            PanelLastYEars.Visible = False
            DatePanel.Visible = False
            btnBack.Enabled = False
            titleimg.Visible = True

            rbCriterialist.Visible = False
            Title.Text = TitleStart(0)
            lblsuggestion.Text = SuggestionStart(0)
            helpText.Text = helpStart
            btnNext.Enabled = True
            Session("STG") = stage
            lblScope.Visible = False
            ddlScope.Visible = False
            lblService.Visible = False
            ddlService.Visible = False
            rbCriterialist.Items.Clear()
        ElseIf decision = BasicStages.CriteriaSelection Then
            btnNext.Enabled = False
            Title.Text = TitleStart(1)
            lblsuggestion.Text = SuggestionStart(1)

            helpText.Text = helpCriteria
            rbCriterialist.Items.Clear()
            rbCriterialist.Items.Add(New ListItem("Sales", "1"))
            rbCriterialist.Items.Add(New ListItem("Cost of Goods sold", "2"))

            rbCriterialist.Visible = True
            lblScope.Visible = True
            ddlScope.Visible = True
            If Not Session("selectedval") Is Nothing Then
                rbCriterialist.SelectedIndex = CType(Session("selectedval"), Integer)
                btnNext.Enabled = True
            Else
            End If
            DatePanel.Visible = False
            PanelLastYEars.Visible = False
            rbCriterialist.Visible = True
            lblScope.Visible = True
            ddlScope.Visible = True
            lblService.Visible = True
            ddlService.Visible = True
            lblError.Visible = False
            btnNext.Enabled = True
            Session("STG") = stage
            rbCriterialist.SelectedIndex = CType(Session("selectedval"), Integer)
            bit = False
            Session("bit") = bit
        ElseIf decision = BasicStages.TimeSelection Then
            lbl_Name.Visible = False
            txt_Name.Visible = False
            Title.Text = TitleStart(2)
            lblsuggestion.Text = SuggestionStart(2)
            helpText.Text = helpClip
            DatePanel.Visible = True
            btnNext.Enabled = True
            rbCriterialist.Visible = False
            rbCriterialist.Visible = False
            lblScope.Visible = False
            ddlScope.Visible = False
            lblService.Visible = False
            ddlService.Visible = False
            lblError.Visible = False
            lblInfinidoc.Visible = False
            PanelLastYEars.Visible = True
            lblComparision.Visible = True
            BDPLite1.Visible = True
            chkMTD.Visible = True
            CurrentYear.Text = " (Fiscal Year is from <b>" + cmbMonth.Items(0).Text
            CurrentYear2.Text = " </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp   to <b> " + cmbMonth.Items(11).Text + "</b>)"

            BDPLite2.Visible = True
            Bdplite3.Visible = True
            Bdplite4.Visible = True
            Bdplite3.Enabled = False
            Bdplite4.Enabled = False
            chkboxPreviousYear.Visible = True
            lblDateError.Visible = True
            dgEntity.Visible = False
            lblID.Visible = False
            lblName.Visible = False
            txtID.Visible = False
            txtName.Visible = False
            btnSearch.Visible = False
            Session("STG") = stage
            BDPLite1.SelectedValue = Session("ProStartdate")
            BDPLite2.SelectedValue = Session("ProEnddate")
            If chkboxPreviousYear.Checked = True Then
                Bdplite3.SelectedValue = Session("StartInterval")
                Bdplite4.SelectedValue = Session("EndInterval")
                Bdplite3.Enabled = True
                Bdplite4.Enabled = True
            Else
                Bdplite3.SelectedValue = Session("StartInterval")
                Bdplite4.SelectedValue = Session("EndInterval")
                Bdplite4.SelectedValue = Nothing
                Bdplite4.SelectedValue = Nothing
            End If
        End If

    End Function

    Function WizardFarwardTrack(ByVal decision As Integer) As String

        If decision = BasicStages.WelcomePage Then
            DatePanel.Visible = False
            PanelLastYEars.Visible = False
            stage = stage + 1
            Session("STG") = stage
        ElseIf decision = BasicStages.CriteriaSelection Then
            If rbCriterialist.SelectedItem Is Nothing Then
                btnNext.Enabled = False
                rbCriterialist.Items.Clear()
                Title.Text = TitleStart(1)
                lblsuggestion.Text = SuggestionStart(1)
                helpText.Text = helpCriteria
                rbCriterialist.Items.Add(New ListItem("Sales", "1"))
                rbCriterialist.Items.Add(New ListItem("Cost of Goods sold", "2"))

                rbCriterialist.Visible = True
                lblScope.Visible = True
                ddlScope.Visible = True
                lblService.Visible = True
                ddlService.Visible = True
                If Not Session("selectedval") Is Nothing Then
                    rbCriterialist.SelectedIndex = CType(Session("selectedval"), Integer)
                    btnNext.Enabled = True
                Else
                End If
                Session("STG") = stage
            Else
                stage = CType(Session("STG"), Integer) + 1
                criteria = CType(CType(rbCriterialist.SelectedItem.Value, Integer) - 1, String)
                Session("selectedval") = criteria
                Session("STG") = stage
            End If
        ElseIf decision = BasicStages.TimeSelection Then
            If (Not BDPLite1.SelectedValue Is Nothing) And (Not BDPLite2.SelectedValue Is Nothing) Then
                Session("clipval") = clipcriteria
                If CType(Session("bit"), Boolean) = False Then
                    stage = CType(Session("STG"), Integer)
                    Session("bit") = True
                    If chkboxPreviousYear.Checked = True Then
                        Bdplite3.Enabled = True
                        Bdplite3.Enabled = True
                    Else
                        Bdplite3.Enabled = False
                        Bdplite4.Enabled = False
                    End If
                Else
                    Session("ProStartdate") = BDPLite1.SelectedDateFormatted.Replace("-", " ") ' BDPLite1.SelectedValue
                    Session("ProEnddate") = BDPLite2.SelectedDateFormatted.Replace("-", " ")  'BDPLite2.SelectedValue

                    Yearmatch()

                    stage = CType(Session("STG"), Integer) + 1
                    Session("STG") = stage
                End If
            Else
                Session("bit") = True
                stage = CType(Session("STG"), Integer)
                Title.Text = TitleStart(2)
            End If
            Title.Text = TitleStart(2)
            lblsuggestion.Text = SuggestionStart(2)
            helpText.Text = helpClip
            DatePanel.Visible = True
            btnNext.Enabled = True
            rbCriterialist.Visible = False
            rbCriterialist.Visible = False
            lblScope.Visible = False
            ddlScope.Visible = False
            lblService.Visible = False
            ddlService.Visible = False
            lblError.Visible = False
            PanelLastYEars.Visible = True
            lblComparision.Visible = True
            BDPLite1.Visible = True
            chkMTD.Visible = True

            BDPLite2.Visible = True
            Bdplite3.Visible = True
            Bdplite4.Visible = True
            chkboxPreviousYear.Visible = True
            lblDateError.Visible = True
        ElseIf decision = BasicStages.ProductSelection Then

            If rbProductOption.SelectedIndex = 1 Then
                If Request.QueryString("QID") Is Nothing Then
                    lbl_Name.Visible = True
                    txt_Name.Visible = True
                    txt_Name.Enabled = False
                Else
                    lbl_Name.Visible = False
                    txt_Name.Visible = False
                    txt_Name.Enabled = False
                End If
                Session("STG") = stage
                txt_Name.Text = ""
                DatePanel.Visible = False
                PanelLastYEars.Visible = False
                stage = CType(Session("STG"), Integer)
                lblError.Visible = True
                rbCriterialist.Visible = False
                rbCriterialist.Visible = False
                lblScope.Visible = False
                ddlScope.Visible = False
                lblService.Visible = False
                ddlService.Visible = False
                Title.Text = TitleStart(3)
                lblsuggestion.Text = SuggestionStart(3)
                helpText.Text = helpSelectEntity
                dgEntity.Visible = True
                GetProducts()
                btnNext.Enabled = False
                lblID.Visible = True
                lblName.Visible = True
                txtID.Visible = True
                txtName.Visible = True
                btnSearch.Visible = True
            ElseIf rbProductOption.SelectedIndex = 0 Then
                If Request.QueryString("QID") Is Nothing Then
                    lbl_Name.Visible = True
                    txt_Name.Visible = True
                    txt_Name.Enabled = False
                Else
                    lbl_Name.Visible = False
                    txt_Name.Visible = False
                    txt_Name.Enabled = False
                End If
                Session("STG") = stage
                txt_Name.Text = ""
                DatePanel.Visible = False
                PanelLastYEars.Visible = False
                stage = CType(Session("STG"), Integer)
                lblError.Visible = True
                rbCriterialist.Visible = False
                rbCriterialist.Visible = False
                lblScope.Visible = False
                ddlScope.Visible = False
                lblService.Visible = False
                ddlService.Visible = False
                Title.Text = TitleStart(3)
                lblsuggestion.Text = SuggestionStart(3)
                helpText.Text = helpSelectEntity
                ' dgEntity.Visible = True
                ' GetProducts()
                btnNext.Enabled = False
                '  lblID.Visible = True
                ' lblName.Visible = True
                '  txtID.Visible = True
                ' txtName.Visible = True
                '  btnSearch.Visible = True
                lblInfinidoc.Visible = True
                btnShow.Enabled = True
                txt_Name.Enabled = True

            End If



            End If

    End Function

    Public Sub Yearmatch()

        If chkboxPreviousYear.Checked = True Then
            Session("StartInterval") = Bdplite3.SelectedDateFormatted.Replace("-", " ")
            Session("EndInterval") = Bdplite4.SelectedDateFormatted.Replace("-", " ")
            Session("ProStartdate") = BDPLite1.SelectedDateFormatted.Replace("-", " ")
            Session("ProEnddate") = BDPLite2.SelectedDateFormatted.Replace("-", " ")
            Session("PlanStartdate") = 0
            Session("PlanEnddate") = 0
            Bdplite3.Enabled = True
            Bdplite4.Enabled = True
        Else
            If (BDPLite1.SelectedDate.Year < CurrentPlan.StartYear) Or (BDPLite2.SelectedDate.Year > cmbMonth.Items.Item(11).ToString.Split(" ").GetValue(1)) Then
                Session("PlanStartdate") = 0
                Session("PlanEnddate") = 0
                Session("StartInterval") = 0
                Session("EndInterval") = 0
            Else
                Session("ProStartdate") = BDPLite1.SelectedDateFormatted.Replace("-", " ")
                Session("ProEnddate") = BDPLite2.SelectedDateFormatted.Replace("-", " ")
                Session("StartInterval") = 0
                Session("EndInterval") = 0
                Dim strDate1() As String = BDPLite1.SelectedDateFormatted.Replace("-", " ").Split(" ")
                Dim StrParts1 As String = strDate1(1) + " " + strDate1(2)
                Session("PlanStartdate") = Val(cmbMonth.Items.FindByText(StrParts1).Value) + 1
                Dim strDate2() As String = BDPLite2.SelectedDateFormatted.Replace("-", " ").Split(" ")
                Dim StrParts2 As String = strDate2(1) + " " + strDate2(2)
                Session("PlanEnddate") = Val(cmbMonth.Items.FindByText(StrParts2).Value) + 1
            End If
        End If

    End Sub

    Public Sub YearmatchCompare()

        If (BDPLiteFrom.SelectedDate.Year < CurrentPlan.StartYear) Or (BDPLiteTo.SelectedDate.Year > cmbMonth.Items.Item(11).ToString.Split(" ").GetValue(1)) Then
            Session("PlanStartdateCompare") = 0
            Session("PlanEnddateCompare") = 0
        Else
            Dim strDateFrom() As String = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ").Split(" ")
            Dim StrPartsFrom As String = strDateFrom(1) + " " + strDateFrom(2)
            Session("PlanStartdateCompare") = Val(cmbMonth.Items.FindByText(StrPartsFrom).Value) + 1
            Dim strDateTo() As String = BDPLiteTo.SelectedDateFormatted.Replace("-", " ").Split(" ")
            Dim StrPartsTo As String = strDateTo(1) + " " + strDateTo(2)
            Session("PlanEnddateCompare") = Val(cmbMonth.Items.FindByText(StrPartsTo).Value) + 1
        End If

    End Sub

    Public Sub CollectiveSettings()

        Title.Text = TitleStart(3)
        lblsuggestion.Text = SuggestionStart(3)
        helpText.Text = CType(Session("SetclipLarge"), String)  'helpStart
        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
        Session(Select_Entity_List) = _selectedEntity
        rbCriterialist.Visible = False
        rbCriterialist.Visible = False
        lblScope.Visible = False
        ddlScope.Visible = False
        lblService.Visible = False
        ddlService.Visible = False
        If CType(Session("clipval"), String) = "rbImeter.Checked" Then
            dgEntity.Visible = True
            GetProducts()
            btnNext.Enabled = False
            Heading.Width = Heading.Width.Percentage(75)
            Title.Width = Title.Width.Percentage(75)
            txtName.Visible = True
            lblName.Visible = True
            lblID.Visible = True
            txtID.Visible = True
            btnSearch.Visible = True
        End If
        If strEntityID = "*" Then
            dgEntity.Visible = False
            lblInfinidoc.Visible = True
            btnNext.Enabled = False
            Heading.Width = Heading.Width.Percentage(75)
            Title.Width = Title.Width.Percentage(75)
            rbProductOption.SelectedIndex = 0
            txtName.Visible = False
            lblName.Visible = False
            lblID.Visible = False
            txtID.Visible = False
            btnSearch.Visible = False
        Else
            txtName.Visible = True
            lblName.Visible = True
            lblID.Visible = True
            txtID.Visible = True
            btnSearch.Visible = True
            dgEntity.Visible = True
            GetProducts()
            btnNext.Enabled = False
            Heading.Width = Heading.Width.Percentage(75)
            Title.Width = Title.Width.Percentage(75)
        End If

     
        bit = True
        Session("bit") = bit

    End Sub

    Public Sub FUN_ALterMovie()

        Dim test As Integer
        AnalysisId = Request.QueryString("QID")
        Try


        dsLoadSaveClip = obj.GetEntityByPID(CurrentPlan.PlanID, AnalysisId, GetConnectionData)

        strCriteriaId = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(2), String)
        strClipType = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(3), String)
        strEntityID = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(4), String)
        Session("MID") = AnalysisId
        strMetername = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(6), String)
        Session("MName") = strMetername
        Session("clipval") = strClipType
        Session("selectedval") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(2), Integer) - 1
        Session("FLAnalysisid") = strCriteriaId
        Session("ProStartdate") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(7), String)
        Session("ProEnddate") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(8), String)
        Session("PlanStartdate") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(9), String)
            Session("PlanEnddate") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(10), String)
            chkboxPreviousYear.Checked = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(13), String)
            chkCurrency.Checked = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(16), String)
            If CType(dsLoadSaveClip.Tables(0).Rows(0).Item(14), Boolean) = True Then
                ddlScope.SelectedIndex = 1
            Else
                ddlScope.SelectedIndex = 0
            End If

            If CType(dsLoadSaveClip.Tables(0).Rows(0).Item(15), Boolean) = True Then
                ddlService.SelectedIndex = 1

            Else
                ddlService.SelectedIndex = 0

            End If



        Catch ex As Exception
            Dim str As String = ex.Message
        End Try

        If chkboxPreviousYear.Checked = True Then
            Session("StartInterval") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(11), String)
            Session("EndInterval") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(12), String)
        Else
            Session("StartInterval") = 0 ' Nothing
            Session("EndInterval") = 0 '  Nothing
        End If

        flashheader.Visible = True
        flashheader.Text = strMetername
        td = New TableCell
        tr = New TableRow
        meterimg.Visible = True
        movie = dsLoadSaveClip.Tables(1).Rows(0).Item(1)
        movieZoom = dsLoadSaveClip.Tables(1).Rows(0).Item(0)
        Session("Setclip") = movieZoom
        Session("SetclipLarge") = movie

    End Sub

    Public Sub FUN_CreateMovie()

        bita = 1
        Session("optionbit") = bita
        PRODUCT_ID = Request.Form.Item("SelectedRowNumber")
        Session("singleproduct") = PRODUCT_ID
        LoadMovie_Create()
        lblService.Visible = False
        ddlService.Visible = False
        Session("singleproduct") = Nothing
        Dim CriteriaId As String
        If rbCriterialist.SelectedItem Is Nothing Then
            CriteriaId = "1"
        Else
            CriteriaId = rbCriterialist.SelectedItem.Value
        End If
        Session("clipval") = "rbImeter.Checked"
        Dim ClipType As String = CType(Session("clipval"), String)
        If Not Session("MID") Is Nothing Then
            Dim EntityName As String
            Dim Entitycode As String
            If rbProductOption.SelectedIndex = 0 Then
                EntityName = "All Products"
                Entitycode = "*"
                obj.UpdateEntity(CType(Session("MID"), String), CType(Session("MName"), String), CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, "*", CType(Session("Setclip"), String), CType(Session("SetclipLarge"), String), Entitycode, Session("ProStartdate"), Session("ProEnddate"), Session("PlanStartdate"), Session("PlanEnddate"), Session("StartInterval"), Session("EndInterval"), chkboxPreviousYear.Checked, GetConnectionData, chkMTD.Checked, ddlScope.SelectedIndex, ddlService.SelectedIndex, chkCurrency.Checked)
            ElseIf (rbProductOption.SelectedIndex = 1) Then
                EntityName = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(0), String)
                Entitycode = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(1), String)
                obj.UpdateEntity(CType(Session("MID"), String), CType(Session("MName"), String), CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, PRODUCT_ID, CType(Session("Setclip"), String), CType(Session("SetclipLarge"), String), Entitycode, Session("ProStartdate"), Session("ProEnddate"), Session("PlanStartdate"), Session("PlanEnddate"), Session("StartInterval"), Session("EndInterval"), chkboxPreviousYear.Checked, GetConnectionData, chkMTD.Checked, ddlScope.SelectedIndex, ddlService.SelectedIndex, chkCurrency.Checked)
            End If
        Else
            Dim EntityName As String
            Dim Entitycode As String
            If rbProductOption.SelectedIndex = 0 Then
                EntityName = "All Products"
                Entitycode = "*"
                obj.InsertEntity(txt_Name.Text, CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, "*", CType(Session("Setclip"), String), CType(Session("SetclipLarge"), String), Entitycode, Session("ProStartdate"), Session("ProEnddate"), Session("PlanStartdate"), Session("PlanEnddate"), Session("StartInterval"), Session("EndInterval"), chkboxPreviousYear.Checked, GetConnectionData, chkMTD.Checked, ddlScope.SelectedIndex, ddlService.SelectedIndex, chkCurrency.Checked)
            ElseIf rbProductOption.SelectedIndex = 1 Then
                EntityName = (CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(0), String))
                Entitycode = (CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(1), String))
                obj.InsertEntity(txt_Name.Text, CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, PRODUCT_ID, CType(Session("Setclip"), String), CType(Session("SetclipLarge"), String), Entitycode, Session("ProStartdate"), Session("ProEnddate"), Session("PlanStartdate"), Session("PlanEnddate"), Session("StartInterval"), Session("EndInterval"), chkboxPreviousYear.Checked, GetConnectionData, chkMTD.Checked, ddlScope.SelectedIndex, ddlService.SelectedIndex, chkCurrency.Checked)
            End If
        End If
        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        Session("SetclipLarge") = Nothing

    End Sub

    Public Sub LoadMovie_Create()

        Dim Clipanalysisid As String
        flashheader.Visible = True
        If Not Request.Form.Item("MeterName") Is Nothing Then
            If Not Request.Form.Item("MeterName") = "" Then
                flashheader.Text = Request.Form.Item("MeterName")
            Else
                flashheader.Text = CType(Session("MNAme"), String)
            End If
        Else
            flashheader.Text = CType(Session("MNAme"), String)
        End If

        If Not rbCriterialist.SelectedItem Is Nothing Then
            Clipanalysisid = rbCriterialist.SelectedItem.Value
        Else
            Clipanalysisid = CType(Session("FLAnalysisid"), String)
        End If
        td = New TableCell
        tr = New TableRow
        Dim intervalState As String
        Dim CurrencyCheck As String
        If chkboxPreviousYear.Checked = True Then
            intervalState = "1"
        Else
            intervalState = "0"
        End If

        If chkCurrency.Checked = True Then
            CurrencyCheck = "1"
            SetCurrency = CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1)
        Else
            CurrencyCheck = "0"
            SetCurrency = "  "
        End If


        meterimg.Visible = True
        If chkboxPreviousYear.Checked = True Then
            If Session("StartInterval") = "" Then Session("StartInterval") = Format(Date.Now, "dd MMM yyyy")
            If Session("EndInterval") = "" Then Session("EndInterval") = Format(Date.Now, "dd MMM yyyy")
        End If
        Dim strRowId As String
        If Request.Form.Item("SelectedRowNumber") = "" Then
            strRowId = "*"

        Else
            strRowId = Request.Form.Item("SelectedRowNumber")
        End If


        Dim strFlashVar As String = "getProducts=" & strRowId + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
        & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) _
        & "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & SetCurrency _
        & "&AnalysisOption=" & Clipanalysisid + "&StartInterval=" & CType(Session("StartInterval"), String) + "&EndInterval=" & CType(Session("EndInterval"), String) + "&ChkInterval=" & intervalState

        movie = "  <object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='220' id='ActuallSpeedOMeter' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        & "<param name='movie' value='/MeterTesting/ActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
         & "<embed src='/MeterTesting/ActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='200' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
        & "</object>  <br> "

        'movie = "<script type='text/javascript'>AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0','width','200','height','220','src','\\MeterTesting\\ActuallSpeedOMeter','allowScriptAccess','sameDomain','bgcolor','#ffffff','quality','high','align','middle','id','ActuallSpeedOMeter','FlashVars','" & strFlashVar & "','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','\\MeterTesting\\ActuallSpeedOMeter' ); </script> " _
        '    & "<noscript> " _
        '    & "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='220' id='ActuallSpeedOMeter' align='middle'>" _
        '    & "<param name='allowScriptAccess' value='sameDomain' /> " _
        '    & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        '    & "<param name='movie' value='\MeterTesting\ActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        '    & "</object> " _
        '    & "</noscript>" _
        '    & "<br> "

        movieZoom = " <object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='ActuallSpeedOMeter' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        & "<param name='movie' value='/MeterTesting/ActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        & "<embed src='/MeterTesting/ActuallSpeedOMeter.swf?" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
         & "</object>  <br> "

        'movieZoom = "<script type='text/javascript'>AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0','width','90','height','90','src','\\MeterTesting\\ActuallSpeedOMeter','allowScriptAccess','sameDomain','bgcolor','#ffffff','quality','high','align','middle','id','ActuallSpeedOMeter','FlashVars','" & strFlashVar & "','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','\\MeterTesting\\ActuallSpeedOMeter' ); </script> " _
        '   & "<noscript> " _
        '   & "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='ActuallSpeedOMeter' align='middle'>" _
        '   & "<param name='allowScriptAccess' value='sameDomain' /> " _
        '   & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        '   & "<param name='movie' value='\MeterTesting\ActuallSpeedOMeter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        '   & "</object> " _
        '   & "</noscript>" _
        '   & "<br> "


        Session("SetclipLarge") = movie
        Session("Setclip") = movieZoom
        Heading.Width = Heading.Width.Percentage(75)
        Title.Width = Title.Width.Percentage(75)
        helpText.Text = CType(Session("SetclipLarge"), String)

    End Sub

    Private Sub dgEntity_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgEntity.PageIndexChanged

        dgEntity.CurrentPageIndex = e.NewPageIndex
        GetProducts()

    End Sub

    Private Sub dgEntity_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgEntity.ItemCreated

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            e.Item.Attributes.Add("onmousemove", "this.style.backgroundColor='#ECF4FC';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white';")
        End If

    End Sub

    Private Sub dgEntity_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgEntity.ItemDataBound

        If e.Item.ItemType = ListItemType.AlternatingItem Or e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.SelectedItem Then
            Dim r As Label
            r = CType(e.Item.FindControl("Label2"), Label)
            r.Text = "<input type=radio name='myradiogroup' onclick='SetRbValue(this.value)' value=" & CType(e.Item.Cells(1).Text, String) & ">" + r.Text
        End If
        If e.Item.ItemType = ListItemType.Header Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridHeaderBar"
            Next
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridInnerLines"
            Next
        End If

    End Sub

    Public Sub Load_treeView(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)
 
        Dim _row As TableRow
        Dim _rowIcons As TableRow
        Dim _column As TableCell
        Dim _columnIcons As TableCell
        Dim inloopChk, outloopChk, counter, countVal, iloc, maxCount, rowDiff, interRowVal As Integer
        Dim totalRows As Integer = dspopulateTeee.Tables(0).Rows.Count
        Dim trRowscount As Integer = CInt(Math.Ceiling(totalRows / 5))

        For outloopChk = 1 To trRowscount
            _row = New TableRow
            _rowIcons = New TableRow
            _row.Attributes.Add("class", "SmallMeter")
            _rowIcons.Attributes.Add("class", "SmallMeter")
            counter = 4
            maxCount = counter + iloc
            rowDiff = totalRows - maxCount
            If (rowDiff <= 0) Then
                interRowVal = (totalRows - inloopChk)
                interRowVal = interRowVal - 1 + inloopChk
            Else
                interRowVal = maxCount
            End If
            maxCount = interRowVal
            For inloopChk = countVal To maxCount
                _column = New TableCell
                _columnIcons = New TableCell
                'Realtime Work 
                movie = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(3), String)

                A_id = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(0), String)
                MeterName = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(1), String)
                Dim Clip As String = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(4), String)

                RealTimeBit = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(5), String)
                If RealTimeBit = True Then
                    Dim largeMeter As String = CType(dspopulateTeee.Tables(0).Rows(inloopChk).Item(6), String)

                    Dim ToDay As String = movie.Substring(movie.IndexOf("ProEndDate=") + 11, (movie.IndexOf("PlanStartDate=") - 12) - movie.IndexOf("ProEndDate="))
                    Dim ToDayLarge As String = largeMeter.Substring(largeMeter.IndexOf("ProEndDate=") + 11, (largeMeter.IndexOf("PlanStartDate=") - 12) - largeMeter.IndexOf("ProEndDate="))

                    updatedClip = movie.Replace(ToDay, Date.Now.ToLongDateString)
                    updatedLargeClip = largeMeter.Replace(ToDayLarge, Date.Now.ToLongDateString)
                    If (ToDay <> Date.Now.ToLongDateString) Then
                        movie = obj.updateRealTimeDate(A_id, updatedClip, updatedLargeClip, GetConnectionData)
                    Else
                        movie = movie
                    End If


                Else

                End If
                'Realtime works
                Dim _sbMovie As New StringBuilder
                Dim _sbOptions As New StringBuilder
                _sbMovie.Append(movie)
                _column.Text = _sbMovie.ToString

                'st.Append("<a href='Speedometer.aspx?AnalysisID=1&Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/editmetersmall.jpg' style='border-style: none'  runat=server ID='edit'></a>")
                'st.Append("<a href='Speedometer.aspx?AnalysisID=1&Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom'></a>")
                'st.Append("<a href='Speedometer.aspx?AnalysisID=1&Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete'></a>")
              
                '_column.Text = movie + "<input type=radio name='myradiogroup' onclick='SetRbValue1(this.value,1)' value=" & CType(A_id, String) & ">" _
                '& MeterName + "<a href='Speedometer.aspx?AnalysisID=1&Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='Img1'></a>"
                ' _column.Text = movie + "<input type=radio name='myradiogroup' onclick='SetRbValue1(this.value,1)' value=" & CType(A_id, String) & "> <a href='speedometer.aspx?ZoomID=" + CType(A_id, String) + "' runat=server > " + MeterName + "</a>"
                'deletemter.Attributes.Add("onClick", "javascript:void(0);return delete_prompt();")

 
 
                _sbOptions.Append(" <a href='Speedometer.aspx?AnalysisID=1&Editid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/editmetersmall.jpg' style='border-style: none'  runat=server ID='edit' alt='Edit'></a>   ")
                _sbOptions.Append("<a href='Speedometer.aspx?AnalysisID=1&Zoomid=" & CType(A_id, String) & "' runat=server > <img src='/images/infiniplan/zoommetersmall.jpg' style='border-style: none'  runat=server ID='zoom' alt='Zoom'></a>   ")
                _sbOptions.Append("<a href='Speedometer.aspx?AnalysisID=1&Deleteid=" & CType(A_id, String) & "&isDeleted=' runat=server  ><img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete' alt='Delete'></a><br>")

                '   st1.Append("<a href='Speedometer.aspx?AnalysisID=1&Deleteid=" & CType(A_id, String) & "&isDeleted=' runat=server onclick=javascript:SetdeleteMeter('" & A_id.Trim & "');><img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete'></a><br>")
                '   st1.Append("<a href='#'   runat=server onclick=javascript:SetdeleteMeter('" & A_id.Trim & "');><img src='/images/infiniplan/deletemtersmall.jpg' style='border-style: none'  runat=server ID='delete'></a><br>")

                _sbOptions.Append(MeterName)
                _sbOptions.Append("<br>")
                _columnIcons.Text = _sbOptions.ToString
               
                _row.Cells.Add(_column)
                _rowIcons.Cells.Add(_columnIcons)
            Next
            Listmeter.Controls.Add(_row)
            Listmeter.Controls.Add(_rowIcons)
            iloc = counter + iloc + 1
            countVal = iloc
        Next
        Listmeter.Controls.Add(_row)
        Listmeter.Controls.Add(_rowIcons)

    End Sub

    Public Sub Load_treeViewAdvance(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)

        Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, Session("strMeterId"), GetConnectionData)
        Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
        Dim Barmeter As String = ZoomEntity.Replace("/MeterTesting/ActuallSpeedOMeter.swf", "/MeterTesting/2barGraph.swf")
        Barmeter = Barmeter.Replace("'width','200'", "'width','150'")
        Barmeter = Barmeter.Replace("'height','220'", "'height','260'")
        Barmeter = Barmeter.Replace("width='200'", "width='150'")
        Barmeter = Barmeter.Replace("height='220'", "height='260'")
        Dim _row As TableRow
        Dim _barcolumn As TableCell
        Dim _devcolumn As TableCell
        Dim _space As TableCell
        _row = New TableRow
        _devcolumn = New TableCell
        _barcolumn = New TableCell
        _space = New TableCell
        _barcolumn.Text = Barmeter
        _space.Text = "&nbsp"
        Dim devMeter As String = ZoomEntity.Replace("/MeterTesting/ActuallSpeedOMeter.swf", "/MeterTesting/DeviationScale.swf")
        devMeter = devMeter.Replace("width='200'", "width='320'")
        devMeter = devMeter.Replace("height='220'", "height='220'")
        devMeter = devMeter.Replace("'width','200'", "'width','320'")
        devMeter = devMeter.Replace("'height','220'", "'height','220'")
        _devcolumn.Text = devMeter
        _row.Cells.Add(_devcolumn)
        _row.Cells.Add(_space)
        _row.Cells.Add(_barcolumn)
        AdvanceMeters.Controls.Add(_row)

    End Sub

    Public Sub LoadFlashFilesfromDb()

        Dim loopa As Integer, loopb As Integer
        Dim td_movie As TableCell
        Dim tr_movie As TableRow
        tr_movie = New TableRow
        tr_movie.Attributes.Add("class", "SmallMeter")
        For loopa = 0 To dsFAvoritesClip.Tables(0).Rows.Count - 1
            td_movie = New TableCell
            movie = CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(4), String)
            td_movie.Text = movie + " <a href='Speedometer.aspx?RFID=" + CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(0), String) + "' " _
                & "id='FAV" + CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(0), String) + "' runat=server class='trsettings'   ><u>" + CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(1), String) + "   " + "</u>(Remove)</a>"
            tr_movie.Cells.Add(td_movie)
        Next
        PlanFavTable.Rows.Add(tr_movie)

    End Sub

    Function RemoveHTML(ByVal strText As String) As String

        Dim strInput As String
        Dim strOutput As String
        strOutput = Regex.Replace(strText, "<[^>]*>", "")
        Return strOutput

    End Function

    Sub PageLoadSettings()

        stage = BasicStages.WelcomePage
        Session("STG") = stage
        btnBack.Enabled = False
        Session("selectedval") = Nothing
        Title.Text = TitleStart(0)
        lblsuggestion.Text = SuggestionStart(0)
        helpText.Text = helpStart

    End Sub

    Sub DefaultSettings()

        rbCriterialist.Attributes.Add("onClick", "javascript:NextSet();")
        btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")
        If Not Session("MID") Is Nothing Then
            btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus1();")
        Else
            btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")
        End If
        If PanelButton.Visible = True Then
        End If
        lblError.Text = ""

    End Sub

    Private Sub SetFocus(ByVal FocusControl As Control)

        Dim Script As New System.Text.StringBuilder
        Dim ClientID As String = FocusControl.ClientID
        With Script
            .Append("<script language='javascript'>")
            .Append("document.getElementById('")
            .Append(ClientID)
            .Append("').focus();")
            .Append("</script>")
        End With
        RegisterStartupScript("setFocus", Script.ToString())

    End Sub

    Public Sub GetProducts()

        Gridpanel.Visible = True
        Dim ds As DataSet
        Dim dt As DataTable
        Try
            ds = obj.FetchEntity(CurrentPlan.PlanID, GetConnectionData)
            dt = ds.Tables(0)
        Catch ex As BizPlanDBInvalidDataException
            Dim str As String = ex.Message
        End Try
        dgEntity.DataSource = dt
        dgEntity.DataBind()

    End Sub

    Private Function GetTable_Entity() As DataTable

        Dim EntTable As New DataTable("SetItems")
        Dim dc As DataColumn
        dc = New DataColumn("Productid", GetType(String))
        EntTable.Columns.Add(dc)
        dc = New DataColumn("Entity Name", GetType(String))
        EntTable.Columns.Add(dc)
        Return EntTable

    End Function

    Private Sub viewGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Me.Response.Redirect("Multiplegraphs.aspx")

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If Not ValidateFields() Then
            lblError.Visible = True
            lblError.Text = "Enter criteria for search"
            Exit Sub
        End If
        Dim strID As String
        Dim strName As String
        strID = txtID.Text
        strName = txtName.Text
        dtSearch = obj.SearchEntity(GetConnectionData, CurrentPlan.PlanID, strID, strName)
        If (dtSearch.Rows.Count <= 0) Then
            lblError.Text = "No Record found"
            lblError.Visible = True
            txtID.Text = ""
            txtName.Text = ""
            Exit Sub
        End If
        lblError.Text = ""
        lblError.Visible = False
        dgEntity.AllowPaging = True
        dgEntity.CurrentPageIndex = 0
        dgEntity.DataSource = dtSearch
        dgEntity.DataBind()
        txtID.Text = ""
        txtName.Text = ""

    End Sub

    Private Function ValidateFields() As Boolean

        If Trim(txtID.Text) = "" And Trim(txtName.Text) = "" Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub editmeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles editmeter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            If clipslection = "rbIActuals.Checked" Then
                Response.Redirect("Speedometer.aspx?CID=" + strMeterId)
            Else
                Response.Redirect("Speedometer.aspx?QID=" + strMeterId)
            End If
        End If

    End Sub

    Private Sub ZoomSmall()
        PanelZoom.Visible = True
        lblZoomEntitName.Visible = True
        MeterZoomView.Visible = True
        Dim strMeterId As String = Session("strMeterId")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            'Dim tr As New TableRow
            'Dim td As New TableCell
            'td.Text = ZoomEntity
            'tr.Cells.Add(td)
            'Dim tr_Br As New TableRow
            'Dim tc_Br As New TableCell
            'tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"
            'tr_Br.Attributes.Add("class", "trsettings")
            'tr_Br.Cells.Add(tc_Br)
            'MeterZoomView.Controls.Add(tr)
            'MeterZoomView.Rows.Add(tr_Br)

        End If


        If strMeterId = "" Then
            Exit Sub
        Else
            deletemter.Visible = False
            FavroiteMeter.Visible = False
            editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = ZoomEntity
            tr.Cells.Add(td)
            Dim tr_Br As New TableRow
            Dim tc_Br As New TableCell
            tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"
            tr_Br.Attributes.Add("class", "trsettings")
            tr_Br.Cells.Add(tc_Br)
            MeterZoomView.Controls.Add(tr)
            MeterZoomView.Rows.Add(tr_Br)
        End If
        Load_treeViewAdvance(strMeterId, "", "")
        AdvanceMeters.Visible = True
        Listmeter.Visible = False
        Session("Load") = 1


    End Sub

    Private Sub DeleteMeter()

        Dim strMeterId As String = Session("strMeterId")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
                    Response.Redirect("Speedometer.aspx?DID=" + strMeterId)
        End If


    End Sub

    Private Sub Editmeter1()

        Dim strMeterId As String = Session("strMeterId")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            If clipslection = "rbIActuals.Checked" Then
                Response.Redirect("Speedometer.aspx?CID=" + strMeterId)
            Else
                Response.Redirect("Speedometer.aspx?QID=" + strMeterId)
            End If
        End If
    End Sub

    Private Sub zoommeter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles zoommeter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Session("strMeterId") = strMeterId
            lblZoomEntitName.Visible = True
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim dt As DataTable = ds.Tables(0)
            Dim da As Array = dt.Select("cliptype='rbIActuals.Checked'")
            Dim dr As DataRow
            Dim clipslection As String
            For Each dr In da
                clipslection = dr(5)
            Next
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            'Dim tr As New TableRow
            'Dim td As New TableCell
            'td.Text = ZoomEntity
            'tr.Cells.Add(td)
            'Dim tr_Br As New TableRow
            'Dim tc_Br As New TableCell
            'tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"
            'tr_Br.Attributes.Add("class", "trsettings")
            'tr_Br.Cells.Add(tc_Br)
            'MeterZoomView.Controls.Add(tr)
            'MeterZoomView.Rows.Add(tr_Br)
            imgbtnAdv_Click(sender, e)
        End If
    End Sub

    Private Sub imgbtnAdv_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgbtnAdv.Click

        Dim strMeterId As String = Session("strMeterId")
        If strMeterId = "" Then
            Exit Sub
        Else
            deletemter.Visible = False
            FavroiteMeter.Visible = False
            Editmeter.Visible = False
            zoommeter.Visible = False
            imgbtnAdv.Visible = False
            imgbtnBack.Visible = True
            lblZoomEntitName.Visible = True
            imgbtnAdv.Visible = False
            Dim ds As DataSet = obj.GetZoomView(CurrentPlan.PlanID, strMeterId, GetConnectionData)
            Dim ZoomEntity As String = CType(ds.Tables(0).Rows(0).Item(4), String)
            Dim Name As String = CType(ds.Tables(0).Rows(0).Item(1), String)
            lblZoomEntitName.Text = Name
            Dim tr As New TableRow
            Dim td As New TableCell
            td.Text = ZoomEntity
            tr.Cells.Add(td)
            Dim tr_Br As New TableRow
            Dim tc_Br As New TableCell
            tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeterBasic.jpg'  visible= true runat='server'>"
            tr_Br.Attributes.Add("class", "trsettings")
            tr_Br.Cells.Add(tc_Br)
            MeterZoomView.Controls.Add(tr)
            MeterZoomView.Rows.Add(tr_Br)
        End If
        Load_treeViewAdvance(strMeterId, "", "")
        AdvanceMeters.Visible = True
        Listmeter.Visible = False
        Session("Load") = 1

    End Sub

    Private Sub deletemter_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles deletemter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            'If (MessageBox.Show("Do you really want to delete selected record(s)?", "Delete Warning", MessageBoxButtons.YesNo, _
            '               MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, 0, False) = Windows.Forms.DialogResult.Yes) Then
            '    Response.Redirect("Speedometer.aspx?DID=" + strMeterId)
            'End If
            Response.Redirect("Speedometer.aspx?DID=" + strMeterId)
        End If

    End Sub

    Private Sub FavroiteMeter_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles FavroiteMeter.Click

        Dim strMeterId As String = Request.Form.Item("SelectedRowNumber")
        If strMeterId = "" Then
            lblZoomEntitName.Text = "+"
            imgbtnAdv.Visible = False
            Exit Sub
        Else
            Response.Redirect("Speedometer.aspx?FID=" + strMeterId)
        End If

    End Sub

    Private Sub chkboxPreviousYear_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkboxPreviousYear.CheckedChanged

        lblService.Visible = False
        ddlService.Visible = False

        If chkboxPreviousYear.Checked = True Then
            Bdplite3.Enabled = True
            Bdplite4.Enabled = True
        Else
            Bdplite3.Enabled = False
            Bdplite4.Enabled = False
            Bdplite3.SelectedValue = Nothing
            Bdplite4.SelectedValue = Nothing
        End If


    End Sub

    Private Sub imgbtnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgbtnBack.Click

        deletemter.Visible = True
        FavroiteMeter.Visible = True
        '''' Nisar Addition

        '''editmeter.Visible = True
        Editmeter.Visible = False
        Dim dtUserRigths As DataTable

        If Not Session("merchantProUserID") Is Nothing Then

            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            Dim dr As DataRow
            If dtUserRigths.Select("  Modelid  = 70 And ModelOptionId = 1 ").Length > 0 Then Editmeter.Visible = True
        Else
            Editmeter.Visible = True
        End If

        '''' end
        zoommeter.Visible = True
        imgbtnAdv.Visible = False
        imgbtnBack.Visible = False

        AdvanceMeters.Visible = False
        Listmeter.Visible = True


        PanelZoom.Visible = False
        lblZoomEntitName.Visible = False
        MeterZoomView.Visible = False


    End Sub

    Private Sub dgActualEntity_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgActualEntity.ItemDataBound

        If e.Item.ItemType = ListItemType.Header Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridHeaderBar"
            Next
        End If
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            Dim i As Integer
            For i = 0 To e.Item.Cells.Count - 1
                e.Item.Cells(i).CssClass = "GridInnerLines"
            Next
        End If

    End Sub

    Public Sub dgHoldEntity_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgHoldEntity.DeleteCommand

        Dim query As String
        Dim pCode As String = e.Item.Cells(1).Text
        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
        query = "ProductId='" & pCode & "'"
        Dim drArr() As DataRow = _selectedEntity.Select(query)
        _selectedEntity.Rows.Remove(drArr(0))
        BindHoldEntityGrid()
        BindProductsGrid(CType(Session("ds"), DataTable))

    End Sub

    Private Sub BindHoldEntityGrid()

        Dim selectedProducts As DataTable = CType(Session(Select_Entity_List), DataTable)
        If Not (selectedProducts Is Nothing) Then
            If (selectedProducts.Rows.Count > 0) Then
                dgHoldEntity.DataSource = selectedProducts
                dgHoldEntity.CurrentPageIndex = 0
                dgHoldEntity.DataBind()
                dgHoldEntity.Visible = True
            Else
                dgHoldEntity.Visible = False
            End If
        Else
            dgHoldEntity.Visible = False
        End If

    End Sub

    Private Sub BindProductsGrid(ByRef dt As DataTable)

        dgActualEntity.DataSource = dt
        dgActualEntity.DataBind()

    End Sub

    Private Sub dgActualEntity_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgActualEntity.ItemCreated

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            e.Item.Attributes.Add("onmousemove", "this.style.backgroundColor='#ECF4FC';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white';")
        End If

    End Sub

    Public Sub GetEntity()
        Try
            ds = obj.FetchProduct(CurrentPlan.PlanID, GetConnectionData)
            Session("ds") = ds.Tables(0)
        Catch ex As BizPlanDBInvalidDataException
            Dim str As String = ex.Message
        End Try
        dgActualEntity.DataSource = ds
        dgActualEntity.DataBind()
    End Sub

    Private Sub dgActualEntity_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgActualEntity.PageIndexChanged

        dgActualEntity.CurrentPageIndex = e.NewPageIndex
        BindProductsGrid(CType(Session("ds"), DataTable))
        lblCMeterName.Text = "+"

    End Sub

    Public Sub dgActualEntity_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim query As String
        Dim pCode As String
        Dim chkTemp As CheckBox = CType(sender, CheckBox)
        Dim dgi As DataGridItem
        dgi = CType(chkTemp.Parent.Parent, DataGridItem)
        If (chkTemp.Checked = True) Then
            pCode = dgi.Cells(1).Text
            _selectedEntity = CType(Session(Select_Entity_List), DataTable)
            If _selectedEntity.Rows.Count >= 10 Then
                dgActualEntity.CurrentPageIndex = 0
                BindProductsGrid(CType(Session("ds"), DataTable))
                Exit Sub
            Else
                Dim dr As DataRow = _selectedEntity.NewRow
                dr("Productid") = pCode : dr("Entity Name") = dgi.Cells(3).Text
                _selectedEntity.Rows.Add(dr)
                Session(Select_Entity_List) = _selectedEntity
            End If
        Else
        End If
        BindHoldEntityGrid()
    End Sub

    Private Sub dgHoldEntity_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgHoldEntity.ItemDataBound

        e.Item.Cells(1).Visible = False

    End Sub

    Private Sub dgHoldEntity_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgHoldEntity.PageIndexChanged

        dgHoldEntity.CurrentPageIndex = e.NewPageIndex
        dgHoldEntity.DataSource = CType(Session(Select_Entity_List), DataTable)
        dgHoldEntity.DataBind()

    End Sub

    Private Sub btnSearch_compare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch_compare.Click

        If Not ValidateFields_Compare() Then
            lblError_compare.Visible = True
            lblError_compare.Text = "Enter criteria for search"
            txtID_compare.Text = ""
            txtName_compare.Text = ""
            txt_Name_compare.Visible = False
            lbl_Name_compare.Visible = False
            Exit Sub
        End If
        Dim strID As String
        Dim strName As String
        strID = txtID_compare.Text
        strName = txtName_compare.Text
        dtSearch = obj.SearchEntity(GetConnectionData, CurrentPlan.PlanID, strID, strName)
        If (dtSearch.Rows.Count <= 0) Then
            lblError_compare.Text = "No Record found"
            lblError_compare.Visible = True
            txtID_compare.Text = ""
            txtName_compare.Text = ""
            txt_Name_compare.Visible = False
            lbl_Name_compare.Visible = False
            Exit Sub
        End If
        lblError_compare.Text = ""
        lblError_compare.Visible = False
        dgActualEntity.AllowPaging = True
        dgActualEntity.CurrentPageIndex = 0
        dgActualEntity.DataSource = dtSearch
        dgActualEntity.DataBind()
        txtID_compare.Text = ""
        txtName_compare.Text = ""
    End Sub

    Private Sub btnSelect_compare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect_compare.Click
        Session("List") = Nothing
        Dim count As Integer

        Dim _itemrows As DataTable = CType(Session(Select_Entity_List), DataTable)
        If Not Session(Select_Entity_List) Is Nothing Then
            For count = 0 To _itemrows.Rows.Count() - 1
                pid.Append(CType(_itemrows.Rows(count).Item(0), String) + ",")
                ' pidouter.Append(CType(_itemrows.Rows(count).Item(1), String))
            Next
            btnShowComparision.Enabled = True
            Session("List") = pid.ToString
            pid = Nothing
            ' pidouter = Nothing
            Session(Select_Entity_List) = Nothing
            GetEntity()
            _selectedEntity = CType(Session(Select_Entity_List), DataTable)
            If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
            Session(Select_Entity_List) = _selectedEntity
            If _itemrows.Rows.Count = 0 Then
                lblError_compare.Visible = True
                lblError_compare.Text = "Select entity"
                btnShowComparision.Enabled = False
                btnShowComparision.Enabled = False
                '  flashpanel.Visible = False
                txt_Name_compare.Visible = False
                lbl_Name_compare.Visible = False
            Else
                btnShowComparision.Visible = True
                lblError_compare.Visible = False
                btnShowComparision.Enabled = True
                txt_Name_compare.Visible = True
                lbl_Name_compare.Visible = True
                txt_Name_compare.Text = ""
                txt_Name_compare.Enabled = True
            End If
            BindHoldEntityGrid()
        Else
            lblError_compare.Text = "select row"
            lblError_compare.Visible = True
        End If
    End Sub

    Private Function ValidateFields_Compare() As Boolean
        If Trim(txtID_compare.Text) = "" And Trim(txtName_compare.Text) = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnShowComparision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowComparision.Click
        If Not txt_Name_compare.Text = "" Then
            If Not REValidator.IsIdentifierforMeter(txt_Name_compare.Text) Then
                lblError_compare.Text = "Error:Give Valid Meter name"
                txt_Name_compare.Text = ""
                lblError_compare.Visible = True
                Exit Sub
            End If
            boolMetername = obj.GetMeterName(txt_Name_compare.Text.ToUpper.Trim, CurrentPlan.PlanID, GetConnectionData)
            If boolMetername = True Then   '// use to check it is already exits 
                lblError_compare.Text = "Error:Name alreadt Exsist.Plz give some else proper name "
                lblError_compare.Visible = True
                txt_Name_compare.Text = ""
                Exit Sub
            End If
        Else
            lblError_compare.Text = "Error:Give proper Meter name"
            lblError_compare.Visible = True
            Exit Sub
        End If

        txt_Name_compare.Enabled = False
        lblError_compare.Visible = False
        YearmatchCompare()
        Session("ProStartdateCompare") = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ")
        Session("ProEnddateCompare") = BDPLiteTo.SelectedDateFormatted.Replace("-", " ")
        Dim strFlashVar As String = "getProducts=" & CType(Session("List"), String) + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
                   & "&ProStartDate=" & CType(Session("ProStartdateCompare"), String) + "&ProEndDate=" & CType(Session("ProEnddateCompare"), String) + "&PlanStartDate=" & CType(Session("PlanStartdateCompare"), String) + "&PlanEndDate=" & CType(Session("PlanEnddateCompare"), String) + "&Currency=" & "A" _
           & "&AnalysisOption=" & "1"

        movieCompare = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MultipleProductsGraph' align='middle'>" _
          & "<param name='allowScriptAccess' value='sameDomain' /> " _
            & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
          & "<param name='movie' value='/MeterTesting/MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        & "<embed src='/MeterTesting/MultipleProductsGraph.swf" + strFlashVar + "' quality='high' width='325' height='220' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
        & "</object> <br> "

        movieZoomCompare = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='MultipleProductsGraph' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        & "<param name='movie' value='/MeterTesting/MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
  & "<embed src='/MeterTesting/MultipleProductsGraph.swf" + strFlashVar + "' quality='high' width='90' height='90' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash'embed>" _
 & "</object> <br> "

        Session("SetclipLargeCompare") = movieCompare
        Session("SetclipCompare") = movieZoomCompare

        Dim td_ist As TableCell
        Dim tr_ist As TableRow
        td_ist = New TableCell
        tr_ist = New TableRow
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell

        td_ist.Text = movieCompare
        Session("movie") = movieCompare
        tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgActuals.jpg'  visible= true runat='server'>"
        tr_ist.Attributes.Add("class", "trsettings")
        tr_ist.Controls.Add(td_ist)
        tr_Br.Attributes.Add("class", "trsettings")
        tr_Br.Cells.Add(tc_Br)
        PlanCompareTable.Rows.Add(tr_ist)
        PlanCompareTable.Rows.Add(tr_Br)
        btnShowComparision.Enabled = False

        Dim Entitycode As String = ""
        Dim multipleEntityName As String = obj.GetManyNodes(CType(Session("List"), String), CurrentPlan.PlanID, GetConnectionData, CType(Session("ProStartdateCompare"), String), CType(Session("ProEnddateCompare"), String), CType(Session("PlanStartdateCompare"), String), CType(Session("PlanEnddateCompare"), String), CurrentPlan.Currency)
        obj.InsertEntity(txt_Name_compare.Text, CurrentPlan.PlanID, "1", "rbIActuals.Checked", multipleEntityName, CType(Session("List"), String), CType(Session("SetclipCompare"), String), CType(Session("SetclipLargeCompare"), String), Entitycode, CType(Session("ProStartdateCompare"), String), CType(Session("ProEnddateCompare"), String), CType(Session("PlanStartdateCompare"), String), CType(Session("PlanEnddateCompare"), String), "0", "0", False, GetConnectionData, chkMTD.Checked, ddlScope.SelectedIndex, ddlService.SelectedIndex, chkCurrency.Checked)
        btnNext_Compare.Enabled = True
        lblCMeterName.Visible = True
        lblCMeterName.Text = txt_Name_compare.Text
    End Sub

    Private Sub btnNext_Compare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext_Compare.Click

        Response.Redirect("Speedometer.aspx?AnalysisID=1")

    End Sub

    Private Sub chkMTD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMTD.CheckedChanged
        If chkMTD.Checked = True Then
            Dim dtFrom As New Date(Now.Year, Now.Month, 1)
            BDPLite1.SelectedDate = dtFrom
            Dim dtTo As New Date
            dtTo = Now.Date
            BDPLite2.SelectedDate = dtTo
            Dim chkRealTime As Boolean = False
        Else
            Dim formatedDAte As String
            BDPLite1.SelectedValue = cmbMonth.Items(0).Text ' DateTime.Today
            Dim qoute As Char = "/"c
            Dim strGetDate As String() = Date.Parse(cmbMonth.Items(11).Text).ToShortDateString.Split(qoute)
            formatedDAte = CStr(Date.DaysInMonth(CInt(strGetDate(2)), CInt(strGetDate(1))))
            BDPLite2.SelectedValue = formatedDAte + " " + cmbMonth.Items(11).Text

        End If
    End Sub

    Private Sub rbCriterialist_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCriterialist.SelectedIndexChanged

    End Sub

    Private Sub chkCurrency_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If chkCurrency.Checked = True Then
            ddlService.Visible = False
            lblService.Visible = False
        Else
            ddlService.Visible = False
            lblService.Visible = False

        End If
    End Sub
End Class
