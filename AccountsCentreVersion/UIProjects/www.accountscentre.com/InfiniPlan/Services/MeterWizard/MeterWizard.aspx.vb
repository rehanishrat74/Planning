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

Public Class MeterWizard
    ' Inherits System.Web.UI.Page
    Inherits MeterWizardBase


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Public td As TableCell
    Public tr As TableRow
    Public spaceCounter As Integer
    Dim dspopulateTeee As DataSet
    Dim dsFAvoritesClip As DataSet
    Dim nodeindex As Integer
    Public bita As Integer
    Dim pid As New StringBuilder
    Public obj As CustomerStatus
    Dim pidouter As New StringBuilder
    Dim str As String = "test"
    Protected WithEvents FavClip As System.Web.UI.HtmlControls.HtmlInputHidden

    Public dsLoadSaveClip As DataSet
    Public _selectedEntity As DataTable
    Public strEntityID As String
    Public strMetername As String
    Public strCriteriaId As String
    Public strClipType As String
    Dim dtSearch As DataTable
    Private Const Select_Entity_List As String = "Select_Entity_List_Key"
    Protected WithEvents btnSelect As System.Web.UI.WebControls.Button
    Protected WithEvents Imeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents IActuals As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Icombine As System.Web.UI.WebControls.ImageButton
    Protected WithEvents rbImeter As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbIActuals As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbIcombine As System.Web.UI.WebControls.RadioButton
    Protected WithEvents PanelImages As System.Web.UI.WebControls.Panel

    Protected WithEvents viewGraph As System.Web.UI.WebControls.Button
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents lblID As System.Web.UI.WebControls.Label
    Protected WithEvents txtID As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblNamr As System.Web.UI.WebControls.Label
    Protected WithEvents txtName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblError1 As System.Web.UI.WebControls.Label
    Dim ds As DataSet
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents btnFinish As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Imagebutton2 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Imagebutton3 As System.Web.UI.WebControls.ImageButton
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
    Protected WithEvents flashpanel As System.Web.UI.WebControls.Panel

    Protected WithEvents PanelNOProduct As System.Web.UI.WebControls.Panel
    Protected WithEvents PanelButton As System.Web.UI.WebControls.Panel
    Protected WithEvents helpText As System.Web.UI.WebControls.Label
    Protected WithEvents lblsuggestion As System.Web.UI.WebControls.Label
    Protected WithEvents lblNoProducts As System.Web.UI.WebControls.Label
    Protected WithEvents dgEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Gridpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents rbCriterialist As System.Web.UI.WebControls.RadioButtonList
    Protected WithEvents PanelCentre As System.Web.UI.WebControls.Panel
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents flashheader As System.Web.UI.WebControls.Label
    Protected WithEvents flashTable As System.Web.UI.WebControls.Table
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Protected WithEvents dgActualEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents dgHoldEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PanelHoldItems As System.Web.UI.WebControls.Panel
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
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents Ajaxpanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Panel4 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents Ajaxpanel2 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Button4 As System.Web.UI.WebControls.Button
    Protected WithEvents Ajaxpanel3 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
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
    Protected WithEvents flashheader11 As System.Web.UI.WebControls.Label
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
    Public strFavDecision As String

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
    Public TitleStart() As String = {"Speedometer Wizard", "Analysis Criteria", "Speedometer Type", "Product or Service Selection"}

    Public SuggestionStart() As String = {"Click <b>Next</b> button to start the <b>Speedometer Wizard</b>", "Select the desired type of analysis. Click <b>Next</b> button to continue", "Select the desired type of Speedometer. <b>Click</b> Next button to continue", "  Select the desired product or service and save the Speedometer"}

    Public helpStart As String = "The <b>Speedometer Wizard</b> helps you create <b>Speedometers</b> for your business plan." _
    & " A Speedometer gives you an analysis of the plan you created. It compares the data entered at the time  " _
    & " of plan creation with the actual sales and expenses records within your accounts."


    Public helpCriteria As String = "In this step you can select the type of analysis for the <b>Speedometer</b>. Different types give analysis about different aspects of your plan"

    Public helpClip As String = "In this step you can select the type of <b>Speedometer</b>. Different types present the analysis from different perspectives."
    Public helpSelectEntity As String = "In this step you can select a desired product(s) or service(s) to analyse its performance. You can only select one product or service if you are creating an <b>Estimate</b> or <b>Deviation Speedometer</b>. However the speedometer with <b>Actual</b> as the speedometer type can have multiple products or services selected simultaneously."

#End Region

    Dim Array() As String = [Enum].GetNames(GetType(FlashCriteriaType))
    Public month As New Hashtable
    Public movie As String
    Public boolMetername As Boolean
    Dim PRODUCT_ID As String
    Public cont As Integer = -1
    Public currecnyval As String
    Public objPlanvb As Plan
    Dim boolCheck As Boolean
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Net.ServicePointManager.CertificatePolicy = New CertificateValidation
        meterimg.Visible = False
        Dim dsName As DataSet = objPlanvb.GetCurrencyName(GetConnectionData, CurrentPlan.PlanID)
        Dim strName As String = CType(dsName.Tables(0).Rows(0).Item(0), String)
        ' Checking for same currency as Accountscentre 
        If GetCustomerCurrency = CStr(HttpContext.Current.Session("CurrencyValue")) Then
            boolCheck = obj.AnyEntityExsists(CurrentPlan.PlanID, GetConnectionData)
            ' Checking for Any linked product or service Exsist or not  
            If boolCheck = True Then

                lblClipHeading.Text = "This is a list of all the <b>Speedometers</b> from the plan:<b>" + CurrentPlan.PlanName + "</b><p>   To add a <b>Speedometer</b> to the <b>Favourites List</b>, click on the <b>Add to Favourites</b> link under the <b>Speedometer</b></p>"
                addMonthds()
                SetFocus(testpanel)
                Session("Speedometer") = Nothing
                Dim RecordWebService As New com.metertesting.www.MeterViewService
                CurPage = 9
                dspopulateTeee = obj.PopulateMeterTree(CurrentPlan.PlanID, GetConnectionData)
                dsFAvoritesClip = obj.Get_favoritesClip(CurrentPlan.PlanID, GetConnectionData)

                If Not IsNothing(Request.QueryString("DID")) And Not Page.IsPostBack Then
                    deleteId = Request.QueryString("DID")
                    obj.DeleteEntity(CurrentPlan.PlanID, deleteId, GetConnectionData)
                    Response.Redirect("MeterWizard.aspx?AnalysisID=1")
                End If

                If Not IsNothing(Request.QueryString("FID")) And Not Page.IsPostBack Then
                    favroitesId = Request.QueryString("FID")
                    If Not Request.Form.Item("FavClip") Is Nothing Then
                        strFavDecision = Request.Form.Item("FavClip")
                    End If
                    obj.Add_Fav_Entity(CurrentPlan.PlanID, favroitesId, GetConnectionData)
                    Response.Redirect("MeterWizard.aspx?AnalysisID=1")
                End If

                If Not IsNothing(Request.QueryString("RFID")) And Not Page.IsPostBack Then
                    RemovefavroitesId = Request.QueryString("RFID")
                    If Not Request.Form.Item("FavClip") Is Nothing Then
                        strFavDecision = Request.Form.Item("FavClip")
                    End If
                    obj.Remove_Fav_Entity(CurrentPlan.PlanID, RemovefavroitesId, GetConnectionData)
                    Response.Redirect("MeterWizard.aspx?AnalysisID=2")
                End If

                If Not IsNothing(Request.QueryString("QID")) And Not Page.IsPostBack Then
                    stage = 3
                    flashpanel.Visible = True
                    Session("STG") = stage
                    btnBack.Enabled = True
                    Session("QID") = 1
                    btnShow_Click(sender, e)
                    CollectiveSettings()
                    CurPage = 9
                    CurItem = 0
                    lblHeading.Text = "Edit Meter"
                    panelcompose.Visible = True
                    PanelButton.Visible = True
                Else
                    If Not Page.IsPostBack Then
                        QSAnalysisId = CInt(Request.QueryString("AnalysisID"))
                        CurPage = 9
                        CurItem = QSAnalysisId
                        Session("item") = QSAnalysisId

                        If QSAnalysisId = 0 Then

                            lblHeading.Text = "Create a Meter"
                            panelcompose.Visible = True
                            PanelButton.Visible = True
                            titleimg.Visible = True
                            Session("MID") = Nothing
                            Session("SelectIndex") = Nothing
                        ElseIf QSAnalysisId = 1 Then
                            lblHeading.Text = "Meter Listing"
                            PanelListing.Visible = True
                            If dspopulateTeee.Tables(0).Rows.Count = 0 Then
                                PanelListing.Visible = False
                                Panelnoclip.Visible = True
                                lblNoClip.Visible = True
                                lblNoClip.Text = "The Speedometer list is empty. To create a speedometer, click the <b>Compose Meter</b> link."
                            Else
                            End If
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
                        End If

                        PageLoadSettings()
                        GetEntity()
                        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
                        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
                        Session(Select_Entity_List) = _selectedEntity
                        BuildMetersTree()
                        If dspopulateTeee.Tables(0).Rows.Count > 0 Then
                            If Not Session("SelectIndex") Is Nothing Then
                                lblMeterName.Text = "Selected Meter is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex(CType(Session("SelectIndex"), String)).Text) & "</b>"
                                TreeView1.SelectedNodeIndex = CType(Session("SelectIndex"), String)

                            Else
                                lblMeterName.Text = "Selected Meter is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
                                TreeView1.SelectedNodeIndex = TreeView1.SelectedNodeIndex
                            End If


                        End If

                    Else
                        If dspopulateTeee.Tables(0).Rows.Count > 0 Then
                            If TreeView1.Nodes.Count > 0 Then
                                Session("SelectIndex") = TreeView1.SelectedNodeIndex
                                    nodeindex = CType(Session("SelectIndex"), Integer)
                                lblMeterName.Text = "Selected Meter is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex(CType(nodeindex, String)).Text) & "</b>"
                                Load_treeView(CType(dspopulateTeee.Tables(0).Rows(nodeindex).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(nodeindex).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(nodeindex).Item(1), String))
                            End If
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
        End If
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
        Dim year As Integer
        If startingMonth > (Now.Month - 1) Then
            cmbMonth.Items.FindByText(strKeyMonthArry(Now.Month - 1) & " " & startingYear).Selected = True
            year = startingYear
        Else
            cmbMonth.Items.FindByText(strKeyMonthArry(Now.Month - 1) & " " & CurrentPlan.StartYear).Selected = True
            year = CurrentPlan.StartYear
        End If

        Dim StrLeapMonth As String

        StrLeapMonth = strKeyMonthArry(Now.Month - 1)
        Dim LeapDate As Integer
        If StrLeapMonth = "Feb" And Date.Now.Day = 29 And Date.IsLeapYear(year) = False Then

            LeapDate = Date.Now.Day - 1
        Else
            LeapDate = Date.Now.Day

        End If

        Session("ProStartdate") = cmbMonth.Items(0).Text
        Session("ProEnddate") = CType(LeapDate, String) + cmbMonth.SelectedItem.Text
        Session("PlanStartdate") = Val(cmbMonth.Items(0).Value) + 1
        Session("PlanEnddate") = cmbMonth.SelectedIndex + 1

    End Sub

    Function RemoveHTML(ByVal strText As String) As String
        Dim strInput As String
        Dim strOutput As String
        strOutput = Regex.Replace(strText, "<[^>]*>", "")
        Return strOutput
    End Function

    Public Sub Load_treeView(ByVal Meterid As String, ByVal A_id As String, ByVal MeterName As String)

        Dim td_movie As TableCell
        Dim tr_movie As TableRow
        td_movie = New TableCell
        tr_movie = New TableRow
        movie = Meterid

        td_movie.Text = movie
        tr_movie.Controls.Add(td_movie)
        Table2.Rows.Add(tr_movie)

        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell
        If Meterid.IndexOf("Speed-o-Meter") <> -1 Then
            tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgMeter.jpg'  visible= true runat='server'>"

        ElseIf Meterid.IndexOf("DeviationScale") <> -1 Then
            tc_Br.Text = "<br><IMG id='meterlistimg2' src='/images/infiniplan/ImgDeviation.jpg'  visible= true runat='server'>"

        ElseIf Meterid.IndexOf("MultipleProductsGraph") <> -1 Then
            tc_Br.Text = "<br><IMG id='meterlistimg3' src='/images/infiniplan/ImgActuals.jpg'  visible= true runat='server'>"


        End If
        tr_Br.Attributes.Add("class", "trsettings")
        tr_Br.Cells.Add(tc_Br)
        Table2.Rows.Add(tr_Br)


        Dim tr_Button As New TableRow
        Dim tc_Button As New TableCell
        tr_Button.Attributes.Add("class", "trsettings")
        tc_Button.Text = "<a href='MeterWizard.aspx?QID=" + A_id + "' id='EDIT" + A_id + "' runat=server class='trsettings'><u>Edit</u></a>" _
        & " &nbsp; <a href='MeterWizard.aspx?DID=" + A_id + "' id='DEL" + A_id + "' runat=server class='trsettings'><u>Delete</u></a>" _
        & "&nbsp; <a href='MeterWizard.aspx?FID=" + A_id + "' id='FAV" + A_id + "' runat=server class='trsettings'  ><u>Favorites</u></a>"

        '& "&nbsp; <a href='MeterWizard.aspx?FID=" + A_id + "' id='FAV" + A_id + "' runat=server class='trsettings'  onclick='callme(this.value)' value='" & MeterName & "'><u>Favorites</u></a>"


        tr_Button.Cells.Add(tc_Button)
        Table2.Rows.Add(tr_Button)
 
    End Sub

    Public Sub LoadFlashFilesfromDb()


        Dim loopa As Integer, loopb As Integer




        Dim td_movie As TableCell
        Dim tr_movie As TableRow

        tr_movie = New TableRow
        For loopa = 0 To dsFAvoritesClip.Tables(0).Rows.Count - 1
            td_movie = New TableCell
            movie = CType(dsFAvoritesClip.Tables(0).Rows(loopa).Item(3), String)

            td_movie.Text = movie

            tr_movie.Cells.Add(td_movie)
        Next


        PlanFavTable.Rows.Add(tr_movie)

        'Dim tr_Br As New TableRow
        'Dim tc_Br As New TableCell

        'tc_Br.Text = "&nbsp;"
        'tr_Br.Cells.Add(tc_Br)
        'PlanFavTable.Rows.Add(tr_Br)


        Dim tr_Button As New TableRow
        Dim tc_Button As TableCell
        For loopb = 0 To dsFAvoritesClip.Tables(0).Rows.Count - 1

            tc_Button = New TableCell
            tr_Button.Attributes.Add("class", "trsettings")
            tc_Button.Text = " <a href='MeterWizard.aspx?RFID=" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' " _
                & "id='FAV" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(0), String) + "' runat=server class='trsettings'   ><u>" + CType(dsFAvoritesClip.Tables(0).Rows(loopb).Item(1), String) + "   " + "</u>(Remove)</a>"
            '& "&nbsp; <a href='MeterWizard.aspx?FID=" + A_id + "' id='FAV" + A_id + "' runat=server class='trsettings'  onclick='callme(this.value)' value='" & MeterName & "'><u>Favorites</u></a>"


            tr_Button.Cells.Add(tc_Button)
        Next
        PlanFavTable.Rows.Add(tr_Button)
    End Sub

    Public Sub BuildMetersTree()
        Dim root As TreeNode


        If dspopulateTeee.Tables(0).Rows.Count > 0 Then
            Dim intloop As Integer
            For intloop = 0 To dspopulateTeee.Tables(0).Rows.Count - 1
                root = New TreeNode
                If CType(dspopulateTeee.Tables(0).Rows(intloop).Item(4), String) = "rbImeter.Checked" Then
                    root.ImageUrl = "/images/InfiniPlan/Linemeter.jpg"
                ElseIf CType(dspopulateTeee.Tables(0).Rows(intloop).Item(4), String) = "rbIActuals.Checked" Then
                    root.ImageUrl = "/images/InfiniPlan/LineActuals.jpg"
                ElseIf CType(dspopulateTeee.Tables(0).Rows(intloop).Item(4), String) = "rbIcombine.Checked" Then
                    root.ImageUrl = "/images/InfiniPlan/Linecombine.jpg"
                End If

                root.Text = "<Table  width=99%  id =" & " # " & intloop & "#" & " ><Tr><Td align=left width=100%> <font size=2 Font-Bold=True color= SteelBlue>" & intloop + 1 & "." & " " & CType(dspopulateTeee.Tables(0).Rows(intloop).Item(1), String) & "</Font></td><td></td></tr></Table>"
                TreeView1.Nodes.Add(root)
            Next

        End If
        If dspopulateTeee.Tables(0).Rows.Count > 0 Then
            If Not Session("SelectIndex") Is Nothing Then
                Load_treeView(CType(dspopulateTeee.Tables(0).Rows(CType(Session("SelectIndex"), Integer)).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(CType(Session("SelectIndex"), Integer)).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(CType(Session("SelectIndex"), Integer)).Item(1), String))

            Else
                Load_treeView(CType(dspopulateTeee.Tables(0).Rows(0).Item(3), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(0), String), CType(dspopulateTeee.Tables(0).Rows(0).Item(1), String))

            End If
     
        End If

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        flashheader.Visible = False
        Title.Width = Title.Width.Percentage(70)
        Heading.Width = Heading.Width.Percentage(70)

        Try
            If stage = Stages.WelcomePage Then
                WizardFarwardTrack(Stages.WelcomePage)
            End If

            If stage = Stages.CriteriaSelection Then
                WizardFarwardTrack(Stages.CriteriaSelection)
            End If

            If stage = Stages.MovieSelection Then
                WizardFarwardTrack(Stages.MovieSelection)
            End If

            If stage = Stages.ProductSelection Then
                WizardFarwardTrack(Stages.ProductSelection)
            End If

            If Not Session("LoadList") Is Nothing Then
                Session("LoadList") = Nothing
                Session("test") = Nothing

                Response.Redirect("MeterWizard.aspx?AnalysisID=1")

            Else

            End If

        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message

        End Try


    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click

        'If Not Request.Form.Item("MeterName") Is Nothing Then
        '    If Not Request.Form.Item("MeterName") = "" Then


        '        If Not REValidator.IsIdentifier(Request.Form.Item("MeterName")) Then
        '            lblError.Text = "Error:Give Valid Meter name"
        '            '"The row could not be inserted because the name was invalid."
        '            lblError.Visible = True
        '            flashpanel.Visible = False
        '            '   lblProductIds.Visible = True
        '            Exit Sub
        '        End If

        '        If CType(Request.Form.Item("MeterName"), String).Trim.Length = 0 Then  '// use to check it is already exits 
        '            lblError.Text = "Error:Give proper Meter name"
        '            lblError.Visible = True
        '            '  lblProductIds.Visible = True
        '            flashpanel.Visible = False
        '            Exit Sub
        '        End If

        '        boolMetername = obj.GetMeterName(Request.Form.Item("MeterName").ToUpper.Trim, CurrentPlan.PlanID, GetConnectionData)
        '        If boolMetername = True Then   '// use to check it is already exits 
        '            lblError.Text = "Error:Name alreadt Exsist.Plz give some else proper name "
        '            lblError.Visible = True
        '            flashpanel.Visible = False
        '            '  lblProductIds.Visible = True
        '            Exit Sub
        '        End If
        '    End If
        'End If

        If Not txt_Name.Text = "" Then

            If Not REValidator.IsIdentifier(txt_Name.Text) Then
                lblError.Text = "Error:Give Valid Meter name"
                txt_Name.Text = ""
                lblError.Visible = True
                flashpanel.Visible = False

                Exit Sub
            End If

            boolMetername = obj.GetMeterName(txt_Name.Text.ToUpper.Trim, CurrentPlan.PlanID, GetConnectionData)
            If boolMetername = True Then   '// use to check it is already exits 
                lblError.Text = "Error:Name alreadt Exsist.Plz give some else proper name "
                lblError.Visible = True
                flashpanel.Visible = False
                txt_Name.Text = ""
                Exit Sub
            End If

        Else
            If Not IsNothing(Request.QueryString("QID")) Then

            Else
                lblError.Text = "Error:Give proper Meter name"
                lblError.Visible = True
                flashpanel.Visible = False
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
        btnNext.Enabled = True
        Session("LoadList") = 1
        Session("test") = 1
    End Sub

    Public Sub CollectiveSettings()


        Title.Text = TitleStart(3)
        lblsuggestion.Text = SuggestionStart(3)
        helpText.Text = CType(Session("Setclip"), String)  'helpStart
        GetEntity()
        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
        If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
        Session(Select_Entity_List) = _selectedEntity
        rbCriterialist.Items.Clear()
        Dim ds As DataSet = obj.CTR(GetConnectionData)

        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            rbCriterialist.Items.Add(New ListItem(CType(ds.Tables(0).Rows(i).Item(1), String), CType(ds.Tables(0).Rows(i).Item(0), String)))
        Next
        rbCriterialist.Visible = False
        If CType(Session("clipval"), String) = "rbImeter.Checked" Or CType(Session("clipval"), String) = "rbIcombine.Checked" Then
            dgEntity.Visible = True
            GetProducts()
            btnNext.Enabled = False

            If CType(Session("clipval"), String) = "rbImeter.Checked" Then
                Heading.Width = Heading.Width.Percentage(75)
                Title.Width = Title.Width.Percentage(75)
                rbImeter.Checked = True
            ElseIf CType(Session("clipval"), String) = "rbIcombine.Checked" Then
                Heading.Width = Heading.Width.Percentage(90)
                Title.Width = Title.Width.Percentage(90)
                rbIcombine.Checked = True
            End If
        ElseIf CType(Session("clipval"), String) = "rbIActuals.Checked" Then
            Heading.Width = Heading.Width.Percentage(90)
            Title.Width = Title.Width.Percentage(90)
            dgEntity.Visible = False
            dgActualEntity.Visible = True
            btnNext.Enabled = False
            btnShow.Enabled = False
            btnSelect.Visible = True
            rbIActuals.Checked = True
        End If
        lblID.Visible = True
        lblName.Visible = True
        txtID.Visible = True
        txtName.Visible = True
        btnSearch.Visible = True

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Session("LoadList") = Nothing

        Session("clipval") = Nothing
        Session("STG") = Nothing
        Session("selectedval") = Nothing
        Response.Redirect("MeterWizard.aspx")

        Session("List") = Nothing
        Session("QID") = Nothing
        Session("bit") = Nothing
        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        Session("singleproduct") = Nothing

        Session(Select_Entity_List) = Nothing
        Session("ds") = Nothing
        Session("MID") = Nothing
        Session("MName") = Nothing
        Session("FLAnalysisid") = Nothing
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        flashheader.Visible = False
        Title.Width = Title.Width.Percentage(70)
        Heading.Width = Heading.Width.Percentage(70)
        Try
            Session("LoadList") = Nothing
            stage = CType(Session("STG"), Integer) - 1
            If stage = Stages.WelcomePage Then
                WizardBackTrack(Stages.WelcomePage)
            ElseIf stage = Stages.CriteriaSelection Then
                WizardBackTrack(Stages.CriteriaSelection)
            ElseIf stage = Stages.MovieSelection Then
                WizardBackTrack(Stages.MovieSelection)
                btnNext.Enabled = True
            End If

        Catch ex As BizPlanDBInvalidDataException

        End Try

    End Sub

    Function WizardBackTrack(ByVal decision As Integer) As Integer

        If decision = Stages.WelcomePage Then
            PanelImages.Visible = False
            btnBack.Enabled = False
            titleimg.Visible = True
            rbCriterialist.Visible = False
            Title.Text = TitleStart(0)
            lblsuggestion.Text = SuggestionStart(0)
            helpText.Text = helpStart
            btnNext.Enabled = True
            Session("STG") = stage
            rbCriterialist.Items.Clear()

        ElseIf decision = Stages.CriteriaSelection Then
            CtriteriaStageUP()
            PanelImages.Visible = False
            rbCriterialist.Visible = True
            lblError.Visible = False
            btnNext.Enabled = True
            Icombine.Visible = False
            IActuals.Visible = False
            Imeter.Visible = False
            rbIcombine.Visible = False
            rbIActuals.Visible = False
            rbImeter.Visible = False
            Session("STG") = stage
            rbCriterialist.SelectedIndex = CType(Session("selectedval"), Integer)
            bit = False
            Session("bit") = bit
        ElseIf decision = Stages.MovieSelection Then
            lbl_Name.Visible = False
            txt_Name.Visible = False
            Title.Text = TitleStart(2)
            lblsuggestion.Text = SuggestionStart(2)
            helpText.Text = helpClip
            If CType(Session("selectedval"), Integer) = FlashCriteriaType.ProductServiceAnalysis Or _
               CType(Session("selectedval"), Integer) = FlashCriteriaType.COGSAnalysis _
            Or CType(Session("selectedval"), Integer) = FlashCriteriaType.ExpensesAnalysis Then
                Multipleselect()
            Else
                Singleselect()

            End If
            dgEntity.Visible = False
            dgActualEntity.Visible = False

            flashpanel.Visible = False

            Session("STG") = stage
            btnSelect.Visible = False
            lblID.Visible = False
            lblName.Visible = False
            txtID.Visible = False
            txtName.Visible = False
            btnSearch.Visible = False
        End If

    End Function

    Function WizardFarwardTrack(ByVal decision As Integer) As String

        If decision = Stages.WelcomePage Then
            PanelImages.Visible = False
            stage = stage + 1
            Session("STG") = stage
        ElseIf decision = Stages.CriteriaSelection Then

            If rbCriterialist.SelectedItem Is Nothing Then
                CtriteriaStageUP()
                Session("STG") = stage
            Else
                stage = CType(Session("STG"), Integer) + 1
                criteria = CType(CType(rbCriterialist.SelectedItem.Value, Integer) - 1, String)
                Session("selectedval") = criteria
                Session("STG") = stage
            End If

        ElseIf decision = Stages.MovieSelection Then
            If rbImeter.Checked = True Or rbIActuals.Checked = True Or rbIcombine.Checked = True Then
                ItemSelected()
            Else
                Itemunselected()
            End If

        ElseIf decision = Stages.ProductSelection Then
            If rbImeter.Checked = True Or rbIcombine.Checked = True Then
                If Request.QueryString("QID") Is Nothing Then
                    lbl_Name.Visible = True
                    txt_Name.Visible = True
                    txt_Name.Enabled = False
                Else
                    lbl_Name.Visible = False
                    txt_Name.Visible = False
                    txt_Name.Enabled = False
                End If
            ElseIf rbIActuals.Checked = True Then

                lbl_Name.Visible = False
                txt_Name.Visible = False


            End If




            txt_Name.Text = ""
            setFinalStage()

        End If
    End Function

    Public Sub setFinalStage()
        PanelImages.Visible = False
        stage = CType(Session("STG"), Integer)
        lblError.Visible = True
        rbCriterialist.Visible = False
        rbImeter.Visible = False
        rbIActuals.Visible = False
        rbIcombine.Visible = False
        Imeter.Visible = False
        IActuals.Visible = False
        Icombine.Visible = False
        Title.Text = TitleStart(3)
        lblsuggestion.Text = SuggestionStart(3)
        helpText.Text = helpSelectEntity
        '   lblError.Text = "Criteria : " + Array(Session("selectedval")) + "Clip : " + Session("clipval")
        If CType(Session("selectedval"), Integer) = FlashCriteriaType.ProductServiceAnalysis Then
            If rbImeter.Checked = True Or rbIcombine.Checked = True Then
                dgEntity.Visible = True
                GetProducts()
                btnNext.Enabled = False
            ElseIf rbIActuals.Checked = True Then
                dgEntity.Visible = False
                dgActualEntity.Visible = True
                btnNext.Enabled = False
                btnShow.Enabled = False
                btnSelect.Visible = True
            End If
            lblID.Visible = True
            lblName.Visible = True
            txtID.Visible = True
            txtName.Visible = True
            btnSearch.Visible = True
        ElseIf CType(Session("selectedval"), Integer) = FlashCriteriaType.COGSAnalysis Then
            If rbImeter.Checked = True Or rbIcombine.Checked = True Then
                dgEntity.Visible = True
                GetProducts()
                btnNext.Enabled = False
            ElseIf rbIActuals.Checked = True Then
                dgEntity.Visible = False
                dgActualEntity.Visible = True
                btnNext.Enabled = False
                btnShow.Enabled = False
                btnSelect.Visible = True
            End If

            lblID.Visible = True
            lblName.Visible = True
            txtID.Visible = True
            txtName.Visible = True
            btnSearch.Visible = True
        ElseIf CType(Session("selectedval"), Integer) = FlashCriteriaType.ExpensesAnalysis Then
            If rbImeter.Checked = True Or rbIcombine.Checked = True Then
                dgEntity.Visible = True
                GetProducts2()
                btnNext.Enabled = False
            ElseIf rbIActuals.Checked = True Then
                dgEntity.Visible = False
                dgActualEntity.Visible = True
                btnNext.Enabled = False
                btnShow.Enabled = False
                btnSelect.Visible = True
            End If

            lblID.Visible = True
            lblName.Visible = True
            txtID.Visible = True
            txtName.Visible = True
            btnSearch.Visible = True
        Else
            flashpanel.Visible = False
        End If


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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim a As String = Request.Form.Item("SelectedRowNumber")

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

    Public Sub Itemunselected()
        Session("bit") = True
        stage = CType(Session("STG"), Integer)
        Title.Text = TitleStart(2)
        lblsuggestion.Text = SuggestionStart(2)
        helpText.Text = helpClip
        If criteria = CType(FlashCriteriaType.ProductServiceAnalysis, String) Or _
        criteria = CType(FlashCriteriaType.COGSAnalysis, String) _
        Or criteria = CType(FlashCriteriaType.ExpensesAnalysis, String) Then
            Multipleselect()
        Else
            Singleselect()
        End If

    End Sub

    Public Sub ItemSelected()
        If rbImeter.Checked = True Then clipcriteria = "rbImeter.Checked"
        If rbIActuals.Checked = True Then clipcriteria = "rbIActuals.Checked"
        If rbIcombine.Checked = True Then clipcriteria = "rbIcombine.Checked"

        Session("clipval") = clipcriteria
        If CType(Session("bit"), Boolean) = False Then
            stage = CType(Session("STG"), Integer)
            Title.Text = TitleStart(2)
            lblsuggestion.Text = SuggestionStart(2)
            helpText.Text = helpClip

            If CType(Session("selectedval"), Integer) = FlashCriteriaType.ProductServiceAnalysis Or CType(Session("selectedval"), Integer) = FlashCriteriaType.COGSAnalysis _
            Or CType(Session("selectedval"), Integer) = FlashCriteriaType.ExpensesAnalysis Then
                Multipleselect()
            Else
                Singleselect()
            End If
            If rbIActuals.Visible <> False Then btnNext.Enabled = True
            If rbIActuals.Visible = False Then rbIActuals.Checked = False
            If CType(Session("clipval"), String) <> "rbIActuals.Checked" And rbIActuals.Visible = False Then btnNext.Enabled = True
            Session("bit") = True
        Else
            stage = CType(Session("STG"), Integer) + 1
            Session("STG") = stage
        End If


    End Sub

    Public Sub CtriteriaStageUP()
        btnNext.Enabled = False
        rbCriterialist.Items.Clear()
        Title.Text = TitleStart(1)
        lblsuggestion.Text = SuggestionStart(1)
        helpText.Text = helpCriteria

        Dim ds As DataSet

        ds = obj.CTR(GetConnectionData)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            rbCriterialist.Items.Add(New ListItem(CType(ds.Tables(0).Rows(i).Item(1), String), CType(ds.Tables(0).Rows(i).Item(0), String)))
        Next
        rbCriterialist.Visible = True
        If Not Session("selectedval") Is Nothing Then
            rbCriterialist.SelectedIndex = CType(Session("selectedval"), Integer)
            btnNext.Enabled = True
        Else
        End If

    End Sub

    Public Sub Singleselect()
        PanelImages.Visible = True
        rbCriterialist.Visible = False
        lblError.Visible = False
        btnNext.Enabled = False
        Icombine.Visible = True
        IActuals.Visible = False
        Imeter.Visible = True
        rbIcombine.Visible = True
        rbIActuals.Visible = False
        rbImeter.Visible = True

    End Sub

    Public Sub Multipleselect()
        PanelImages.Visible = True
        rbCriterialist.Visible = False
        lblError.Visible = False
        btnNext.Enabled = False
        Icombine.Visible = True
        IActuals.Visible = True
        Imeter.Visible = True
        rbIcombine.Visible = True
        rbIActuals.Visible = True
        rbImeter.Visible = True

    End Sub

    Sub PageLoadSettings()
        stage = Stages.WelcomePage
        Session("STG") = stage
        btnBack.Enabled = False
        Session("selectedval") = Nothing
        Title.Text = TitleStart(0)
        lblsuggestion.Text = SuggestionStart(0)
        helpText.Text = helpStart

    End Sub

    Sub DefaultSettings()
        Icombine.Enabled = False
        IActuals.Enabled = False
        Imeter.Enabled = False
        rbCriterialist.Attributes.Add("onClick", "javascript:NextSet();")
        rbIcombine.Attributes.Add("onClick", "javascript:devSet();")
        rbImeter.Attributes.Add("onClick", "javascript:meterSet();")
        rbIActuals.Attributes.Add("onClick", "javascript:actSet();")
        btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")
        If Not Session("MID") Is Nothing Then
            btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus1();")
        Else
            btnShow.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")
        End If
        If PanelButton.Visible = True Then
            '        SetFocus(PanelButton)
        End If

        lblError.Text = ""
    End Sub

    Public Sub FUN_ALterMovie()

        AnalysisId = Request.QueryString("QID")
        dsLoadSaveClip = obj.GetEntityByPID(CurrentPlan.PlanID, AnalysisId, GetConnectionData)
        ' StartMovieClip1()


        'Planid (0): "U_1"
        'Analysisid (1): "U_1       "
        '(CriteriaId 2): "1"
        'ClipType (3): "rbImeter.Checked"
        'EntityID (4): "U_1"
        '(5): "CP28 Payroll "

        strCriteriaId = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(2), String)
        strClipType = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(3), String)
        strEntityID = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(4), String)
        Session("MID") = AnalysisId
        strMetername = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(6), String)
        Session("MName") = strMetername

        Session("clipval") = strClipType
        Session("selectedval") = CType(dsLoadSaveClip.Tables(0).Rows(0).Item(2), Integer) - 1
        Session("FLAnalysisid") = strCriteriaId
        LoadMovie_Edit()
        ' SetFocus(flashpanel)

        viewGraph.Visible = False
    End Sub

    Public Sub FUN_CreateMovie()
        StartMovieClip()
        LoadMovie_Create()

        Session("singleproduct") = Nothing
        Dim CriteriaId As String

        If rbCriterialist.SelectedItem Is Nothing Then
            CriteriaId = "1"
        Else
            CriteriaId = rbCriterialist.SelectedItem.Value
        End If

        Dim ClipType As String = CType(Session("clipval"), String)
        If Not Session("MID") Is Nothing Then
            If CType(Session("optionbit"), Integer) = 1 Then
                Dim EntityName As String = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(0), String)
                Dim Entitycode As String = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(1), String)
                obj.UpdateEntity(CType(Session("MID"), String), CType(Session("MName"), String), CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, PRODUCT_ID, CType(Session("Setclip"), String), " ", Entitycode, GetConnectionData)
            ElseIf CType(Session("optionbit"), Integer) = 2 Then
                Dim multipleEntityName As String = obj.GetManyNodes(CType(Session("List"), String), CurrentPlan.PlanID, GetConnectionData, CType(Session("ProStartdate"), String), CType(Session("ProEnddate"), String), CType(Session("PlanStartdate"), String), CType(Session("PlanEnddate"), String), CurrentPlan.Currency)
                Dim Entitycode As String = ""
                obj.UpdateEntity(CType(Session("MID"), String), CType(Session("MName"), String), CurrentPlan.PlanID, CriteriaId, ClipType, multipleEntityName, CType(Session("List"), String), CType(Session("Setclip"), String), " ", Entitycode, GetConnectionData)
            End If

        Else
            If CType(Session("optionbit"), Integer) = 1 Then
                Dim EntityName As String = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(0), String)
                Dim Entitycode As String = CType(obj.GetNodes(PRODUCT_ID, GetConnectionData).Item(1), String)
                obj.InsertEntity(txt_Name.Text, CurrentPlan.PlanID, CriteriaId, ClipType, EntityName, PRODUCT_ID, CType(Session("Setclip"), String), " ", Entitycode, GetConnectionData)
            ElseIf CType(Session("optionbit"), Integer) = 2 Then
                Dim multipleEntityName As String = obj.GetManyNodes(CType(Session("List"), String), CurrentPlan.PlanID, GetConnectionData, CType(Session("ProStartdate"), String), CType(Session("ProEnddate"), String), CType(Session("PlanStartdate"), String), CType(Session("PlanEnddate"), String), CurrentPlan.Currency)
                Dim Entitycode As String = ""
                obj.InsertEntity(txt_Name.Text, CurrentPlan.PlanID, CriteriaId, ClipType, multipleEntityName, CType(Session("List"), String), CType(Session("Setclip"), String), " ", Entitycode, GetConnectionData)
            End If
        End If

        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        viewGraph.Visible = False
    End Sub

    Public Sub StartMovieClip()

        flashpanel.Visible = False
        If rbImeter.Checked = True Or rbIcombine.Checked = True Then
            bita = 1
            Session("optionbit") = bita
            PRODUCT_ID = Request.Form.Item("SelectedRowNumber")
            Session("singleproduct") = PRODUCT_ID

        ElseIf rbIActuals.Checked = True Then
            bita = 2
            Session("optionbit") = bita
            Dim strMultipleProducts As String = CType(Session("List"), String)

        End If

    End Sub

    Public Sub LoadMovie_Edit()
        flashpanel.Visible = False
        flashheader.Visible = True
        flashheader.Text = strMetername
        'td = New TableCell
        'tr = New TableRow

        If strClipType = "rbImeter.Checked" Then
            meterimg.Visible = True
            Dim strFlashVar As String = "getProducts=" & strEntityID + "&getPlanid=" _
            & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
            & "&AnalysisOption=" & CType(Session("FLAnalysisid"), String)

            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='200' id='Speed-o-Meter' align='middle'>" _
                & "<param name='allowScriptAccess' value='sameDomain' />" _
                & "<PARAM NAME=FlashVars VALUE='" + strFlashVar & "'>" _
                & "<param name='movie' value='\MeterTesting\Speed-o-Meter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                & "</object>"
            Session("Setclip") = movie
        ElseIf strClipType = "rbIcombine.Checked" Then
            td = New TableCell
            tr = New TableRow
            meterimg.Visible = True
            meterimg.Src = "/images/infiniplan/ImgDeviation.jpg"
            Dim strFlashVar As String = "getProducts=" & strEntityID + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
     & "&AnalysisOption=" & CType(Session("FLAnalysisid"), String)
            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='200' id='DeviationScale' align='middle'>" _
           & "<param name='allowScriptAccess' value='sameDomain' />" _
            & "<PARAM NAME=FlashVars VALUE='" & strFlashVar & "'>" _
           & "<param name='movie' value='\MeterTesting\DeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
           & "</object>"
            Session("Setclip") = movie

        ElseIf strClipType = "rbIActuals.Checked" Then
            td = New TableCell
            tr = New TableRow
            meterimg.Visible = True
            meterimg.Src = "/images/infiniplan/ImgActuals.jpg"
            Dim strFlashVar As String = "getProducts=" & strEntityID + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
  & "&AnalysisOption=" & CType(Session("FLAnalysisid"), String)
            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='200' id='ACTMeter' align='middle'>" _
     & "<param name='allowScriptAccess' value='sameDomain' />" _
     & "<PARAM NAME=FlashVars VALUE='" & strFlashVar & "'>" _
     & "<param name='movie' value='\MeterTesting\MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
     & "</object>"
            Session("Setclip") = movie
        End If



    End Sub

    Public Sub LoadMovie_Create()
        Dim Clipanalysisid As String
        flashpanel.Visible = False
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

        If rbImeter.Checked = True Then

            meterimg.Visible = True
            Dim strFlashVar As String = "getProducts=" & Request.Form.Item("SelectedRowNumber") + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) _
            & "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
            & "&AnalysisOption=" & Clipanalysisid

            'movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='200' id='Speed-o-Meter' align='middle'>" _
            '    & "<param name='allowScriptAccess' value='sameDomain' />" _
            '    & "<PARAM NAME=FlashVars VALUE='getProducts=" & Request.Form.Item("SelectedRowNumber") + "&getPlanid=" & CurrentPlan.PlanID + "'>" _
            '    & "<param name='movie' value='\MeterTesting\Speed-o-Meter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
            '    & " <embed FlashVars='getProducts=" & Request.Form.Item("SelectedRowNumber") + "&getPlanid=" & CurrentPlan.PlanID + "'  src='\MeterTesting\Speed-o-Meter.swf' quality='high' bgcolor='#ffffff' width='200' height='200' name='Speed-o-Meter' align='middle' allowScriptAccess='sameDomain' type='application/x-shockwave-flash' pluginspage='http://www.macromedia.com/go/getflashplayer' />" _
            '    & "</object> <br>"
            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='200' height='200' id='Speed-o-Meter' align='middle'>" _
               & "<param name='allowScriptAccess' value='sameDomain' />" _
               & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
               & "<param name='movie' value='\MeterTesting\Speed-o-Meter.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
                 & "</object> <br> "
            Session("Setclip") = movie
            Heading.Width = Heading.Width.Percentage(75)
            Title.Width = Title.Width.Percentage(75)
        ElseIf rbIcombine.Checked = True Then
            meterimg.Visible = True
            meterimg.Src = "/images/infiniplan/ImgDeviation.jpg"
            td = New TableCell
            tr = New TableRow
            Dim strFlashVar As String = "getProducts=" & Request.Form.Item("SelectedRowNumber") + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
     & "&AnalysisOption=" & Clipanalysisid
            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='200' id='DeviationScale' align='middle'>" _
           & "<param name='allowScriptAccess' value='sameDomain' />" _
            & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
           & "<param name='movie' value='\MeterTesting\DeviationScale.swf' /><param name='quality' value='high' />" _
           & "</object>"
            Session("Setclip") = movie
            Heading.Width = Heading.Width.Percentage(90)
            Title.Width = Title.Width.Percentage(90)
        ElseIf rbIActuals.Checked = True Then
            td = New TableCell
            tr = New TableRow
            meterimg.Visible = True
            meterimg.Src = "/images/infiniplan/ImgActuals.jpg"
            Dim strFlashVar As String = "getProducts=" & CType(Session("List"), String) + "&getPlanid=" & CurrentPlan.PlanID + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
            & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & CurrentPlan.Currency.Remove(0, CurrentPlan.Currency.IndexOf(" ") + 1) _
    & "&AnalysisOption=" & Clipanalysisid
            movie = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='200' id='ACTMeter' align='middle'>" _
     & "<param name='allowScriptAccess' value='sameDomain' />" _
     & "<PARAM NAME=FlashVars VALUE='" & strFlashVar & "'>" _
     & "<param name='movie' value='\MeterTesting\MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
     & "</object>"
            Session("Setclip") = movie
            Heading.Width = Heading.Width.Percentage(90)
            Title.Width = Title.Width.Percentage(90)
            lbl_Name.Visible = False
            txt_Name.Visible = False

        End If

        'If Me.Page.Session("speedOMeter") = Nothing Then
        '    viewGraph.Visible = False
        'Else
        '    viewGraph.Visible = True
        'End If

        'td.Text = movie
        'tr.Controls.Add(td)
        'flashTable.Rows.Add(tr)
        'flashpanel.Controls.Add(flashTable)

        helpText.Text = CType(Session("Setclip"), String)
        '+ "<br><img src='/images/infiniplan/sm.jpg' />"
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
                lblError.Visible = True
                lblError.Text = "you cant select more entities ,remove any one from below list to select another one. "
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

    'Public Function AllPublishers() As System.Data.SqlClient.SqlDataReader
    '    Dim cmd As New CommandData
    '    cmd.CmdText = "GetProductname"
    '    Dim dataReader As System.Data.SqlClient.SqlDataReader = cmd.Execute(ExecutionType.ExecuteReader)

    '    Return dataReader

    'End Function

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

    Public Sub GetProducts2()
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

    Public Sub checkBoxHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim objRadioList As RadioButtonList = CType(sender, RadioButtonList)
        Dim objDataGridItem As DataGridItem = CType(objRadioList.Parent.Parent, DataGridItem)
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

    Public Sub dgProducts_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim query As String
        Dim pCode As String
        Dim chkTemp As CheckBox = CType(sender, CheckBox)
        Dim dgi As DataGridItem
        dgi = CType(chkTemp.Parent.Parent, DataGridItem)
        If (chkTemp.Checked = True) Then
            pCode = dgi.Cells(1).Text
            _selectedEntity = CType(Session(Select_Entity_List), DataTable)

            If _selectedEntity.Rows.Count >= 10 Then
                lblError.Visible = True
                lblError.Text = "you cant select more entities ,remove any one from below list to select another one. "
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

    Public Sub dgHoldEntity_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)
        Dim query As String
        Dim pCode As String = e.Item.Cells(1).Text


        _selectedEntity = CType(Session(Select_Entity_List), DataTable)
        query = "ProductId='" & pCode & "'"
        Dim drArr() As DataRow = _selectedEntity.Select(query)
        _selectedEntity.Rows.Remove(drArr(0))
        lblError.Text = ""
        BindHoldEntityGrid()


        BindProductsGrid(CType(Session("ds"), DataTable))


    End Sub

    Private Sub BindProductsGrid(ByRef dt As DataTable)
        dgActualEntity.DataSource = dt
        dgActualEntity.DataBind()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Session("List") = Nothing
        Dim count As Integer

        Dim _itemrows As DataTable = CType(Session(Select_Entity_List), DataTable)
        If Not Session(Select_Entity_List) Is Nothing Then
            For count = 0 To _itemrows.Rows.Count() - 1
                pid.Append(CType(_itemrows.Rows(count).Item(0), String) + ",")
                pidouter.Append(CType(_itemrows.Rows(count).Item(1), String))
            Next

            Session("List") = pid.ToString
            'lblProductIds.Text = pid.ToString
            'lblProductName.Text = pidouter.ToString
            pid = Nothing
            pidouter = Nothing
            Session(Select_Entity_List) = Nothing

            GetEntity()
            _selectedEntity = CType(Session(Select_Entity_List), DataTable)
            If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
            Session(Select_Entity_List) = _selectedEntity
            If _itemrows.Rows.Count = 0 Then
                lblError.Visible = True
                lblError.Text = "Select entity"
                btnShow.Enabled = False
                flashpanel.Visible = False
                txt_Name.Visible = False
                lbl_Name.Visible = False


            Else
                btnShow.Visible = True
                lblError.Visible = False
                btnShow.Enabled = True
                If Request.QueryString("QID") Is Nothing Then
                    txt_Name.Visible = True
                    lbl_Name.Visible = True
                    txt_Name.Text = ""
                    txt_Name.Enabled = True
                Else
                    txt_Name.Visible = False
                    lbl_Name.Visible = False

                End If

            End If

            BindHoldEntityGrid()


        Else
            lblError.Text = "select row"
            lblError.Visible = True


        End If

        flashpanel.Visible = False

    End Sub

    Private Sub dgActualEntity_ItemCreated(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgActualEntity.ItemCreated
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Or _
        e.Item.ItemType = ListItemType.SelectedItem Then
            e.Item.Attributes.Add("onmousemove", "this.style.backgroundColor='#ECF4FC';")
            e.Item.Attributes.Add("onmouseout", "this.style.backgroundColor='white';")
        End If
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

    Private Sub dgActualEntity_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgActualEntity.PageIndexChanged


        'If Not _selectedEntity Is Nothing Then
        '    If _selectedEntity.Rows.Count = 10 Then
        '        lblError.Visible = True
        '        lblError.Text = "you cant select more entities ,remove any one from below list to select another one. "
        '        dgActualEntity.CurrentPageIndex = 0
        '        BindProductsGrid(CType(Session("ds"), DataTable))
        '        Exit Sub
        '    End If
        'End If
        dgActualEntity.CurrentPageIndex = e.NewPageIndex
        BindProductsGrid(CType(Session("ds"), DataTable))

    End Sub

    Private Sub dgHoldEntity_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        e.Item.Cells(1).Visible = False
    End Sub

    Private Sub dgHoldEntity_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
        dgHoldEntity.CurrentPageIndex = e.NewPageIndex

        dgHoldEntity.DataSource = CType(Session(Select_Entity_List), DataTable)
        dgHoldEntity.DataBind()

    End Sub

    Private Sub dgEntity_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgEntity.SelectedIndexChanged

    End Sub

    Private Sub viewGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles viewGraph.Click
        Me.Response.Redirect("Multiplegraphs.aspx")
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        flashpanel.Visible = False
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
        If rbImeter.Checked = True Or rbIcombine.Checked = True Then
            dgEntity.AllowPaging = True
            dgEntity.CurrentPageIndex = 0
            dgEntity.DataSource = dtSearch
            dgEntity.DataBind()
            '   Session(Select_Entity_List) = dtSearch
        ElseIf rbIActuals.Checked = True Then


            dgActualEntity.AllowPaging = True
            dgActualEntity.CurrentPageIndex = 0
            dgActualEntity.DataSource = dtSearch
            dgActualEntity.DataBind()
            '  Session(Select_Entity_List) = dtSearch

        End If


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

    Private Sub txt_Name_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Name.TextChanged

    End Sub
End Class


Public Class CertificateValidation
    Implements System.Net.ICertificatePolicy

    'This class handles problems with certificates if ssl (https) is used

    Public Function CheckValidationResult(ByVal srvPoint As ServicePoint, _
    ByVal cert As X509Certificate, ByVal request As WebRequest, ByVal problem As Integer) _
       As Boolean Implements ICertificatePolicy.CheckValidationResult
        Return True
    End Function
End Class

