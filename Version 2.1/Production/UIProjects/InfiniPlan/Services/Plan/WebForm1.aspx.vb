Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Drawing

 
Imports Microsoft.Web.UI.WebControls

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml


Imports System.Reflection
Imports System.Data.SqlClient

Imports System.web


Public Class WebForm1
    '  Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim AnalysisId As String
    Dim pidouter As New StringBuilder
    Dim pid As New StringBuilder
    Dim dtSearch As DataTable
    Public boolMetername As Boolean
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents Table2 As System.Web.UI.WebControls.Table
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents BDPLite1 As BasicFrame.WebControls.BDPLite
    Protected WithEvents BDPLite2 As BasicFrame.WebControls.BDPLite
    Public dsClip As DataSet
    Dim ds As DataSet

    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents PanelCompareProducts As System.Web.UI.WebControls.Panel
    Protected WithEvents PlanCompareTable As System.Web.UI.WebControls.Table
    Protected WithEvents btnShowComparision As System.Web.UI.WebControls.Button
    Protected WithEvents lblError_compare As System.Web.UI.WebControls.Label
    Protected WithEvents txt_Name_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents lbl_Name_compare As System.Web.UI.WebControls.Label
    Protected WithEvents dgHoldEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents PanelHoldItems As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSelect_compare As System.Web.UI.WebControls.Button
    Protected WithEvents dgActualEntity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnSearch_compare As System.Web.UI.WebControls.Button
    Protected WithEvents txtName_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblName_compare As System.Web.UI.WebControls.Label
    Protected WithEvents txtID_compare As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblID_compare As System.Web.UI.WebControls.Label
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents mypanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblfiscalyear As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLiteTo As BasicFrame.WebControls.BDPLite
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLiteFrom As BasicFrame.WebControls.BDPLite
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel2 As System.Web.UI.WebControls.Panel
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Public obj As CustomerStatus
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tsHoriz As Microsoft.Web.UI.WebControls.TabStrip

    Private _dt As BusinessTable
    Public totLibality As Double
    Public totassets As Double
    Public TOLLib_CAp As Double
    Private Const Select_Entity_List As String = "Select_Entity_List_Key"
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Public _selectedEntity As DataTable
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
   Dim movie As String
    Public BPObject As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dsFAvoritesClip As DataSet
        dsFAvoritesClip = obj.GetFavroitesClipListing("U_3", GetConnectionData)
        'If dsFAvoritesClip.Tables(0).Rows.Count = 0 Then
        '    PanelCompareProducts.Visible = False

        '    ' lblnotfavorites.Text = "The <b> Favourites List</b>  is empty. <p>To add a <b> Speedometer</b>  to the list, click the <b> Add to Favourites</b>  link on <b> Meter Listing</b>  page.</p>"
        'ElseIf dsFAvoritesClip.Tables(0).Rows.Count > 0 Then
        '    PanelCompareProducts.Visible = True


        'End If

        If Not Page.IsPostBack Then




            GetEntity()
            _selectedEntity = CType(Session(Select_Entity_List), DataTable)
            If _selectedEntity Is Nothing Then _selectedEntity = GetTable_Entity()
            Session(Select_Entity_List) = _selectedEntity

        Else



        End If

        SetFocus(testpanel)

        Dim td As TableCell
        Dim tr As TableRow
        td = New TableCell
        tr = New TableRow
        Dim tr_Br As New TableRow
        Dim tc_Br As New TableCell

         

        movie = "+"


        td.Text = movie
        'tc_Br.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgActuals.jpg'  visible= true runat='server'>"
        tr.Attributes.Add("class", "trsettings")
        tr.Controls.Add(td)
        tr_Br.Attributes.Add("class", "trsettings")
        tr_Br.Cells.Add(tc_Br)
        PlanCompareTable.Rows.Add(tr)
        PlanCompareTable.Rows.Add(tr_Br)
 
        lblfiscalyear.Text = "(Fiscal year:<b>Jan 2007 </b> To <b> Dec 2007</b>)"
        BDPLiteFrom.SelectedValue = "Jan 2007"
        BDPLiteTo.SelectedValue = "Dec 2007"

    End Sub

    Public Sub GetEntity()

        Try

            ds = obj.FetchProduct("U_3", GetConnectionData)
            Session("ds") = ds.Tables(0)
        Catch ex As BizPlanDBInvalidDataException
            Dim str As String = ex.Message
        End Try

        dgActualEntity.DataSource = ds
        dgActualEntity.DataBind()


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

        If Not ValidateFields() Then
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

        dtSearch = obj.SearchEntity(GetConnectionData, "U_3", strID, strName)


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
        '  Session(Select_Entity_List) = dtSearch




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

    Private Function ValidateFields() As Boolean
        If Trim(txtID_compare.Text) = "" And Trim(txtName_compare.Text) = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btnShowComparision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowComparision.Click
        If Not txt_Name_compare.Text = "" Then

            If Not REValidator.IsIdentifier(txt_Name_compare.Text) Then
                lblError_compare.Text = "Error:Give Valid Meter name"
                txt_Name_compare.Text = ""
                lblError_compare.Visible = True
                Exit Sub
            End If

            boolMetername = obj.GetMeterName(txt_Name_compare.Text.ToUpper.Trim, "U_3", GetConnectionData)
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
        Session("ProStartdate") = BDPLiteFrom.SelectedValue
        Session("ProEndDate") = BDPLiteTo.SelectedValue
        Session("PlanStartDate") = 1
        Session("PlanEndDate") = 12
        Dim movie1 As String
        Dim movieZoom1 As String
        Dim strFlashVar As String = "getProducts=" & CType(Session("List"), String) + "&getPlanid=" & "U_3" + "&Customerid=" & CType(GetConnectionData.CustomerID, String) _
                   & "&ProStartDate=" & CType(Session("ProStartdate"), String) + "&ProEndDate=" & CType(Session("ProEnddate"), String) + "&PlanStartDate=" & CType(Session("PlanStartdate"), String) + "&PlanEndDate=" & CType(Session("PlanEnddate"), String) + "&Currency=" & "A" _
           & "&AnalysisOption=" & "1"
        movie1 = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MultipleProductsGraph' align='middle'>" _
          & "<param name='allowScriptAccess' value='sameDomain' /> " _
            & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
          & "<param name='movie' value='\MeterTesting\MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
          & "</object> <br> "

        movieZoom1 = "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='90' height='90' id='MultipleProductsGraph' align='middle'>" _
        & "<param name='allowScriptAccess' value='sameDomain' /> " _
          & "<PARAM NAME=FlashVars VALUE='" & strFlashVar + "'>" _
        & "<param name='movie' value='\MeterTesting\MultipleProductsGraph.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
        & "</object> <br> "
        Session("SetclipLarge") = movie1
        Session("Setclip") = movieZoom1

        Dim td1 As TableCell
        Dim tr1 As TableRow
        td1 = New TableCell
        tr1 = New TableRow
        Dim tr_Br1 As New TableRow
        Dim tc_Br1 As New TableCell


        td1.Text = movie1
        Session("movie") = movie1
        tc_Br1.Text = "<br><IMG id='meterlistimg1' src='/images/infiniplan/ImgActuals.jpg'  visible= true runat='server'>"
        tr1.Attributes.Add("class", "trsettings")
        tr1.Controls.Add(td1)
        tr_Br1.Attributes.Add("class", "trsettings")
        tr_Br1.Cells.Add(tc_Br1)
        PlanCompareTable.Rows.Add(tr1)
        PlanCompareTable.Rows.Add(tr_Br1)

        btnShowComparision.Enabled = False

        Dim Entitycode As String = ""
        Dim multipleEntityName As String = obj.GetManyNodes(CType(Session("List"), String), "U_3", GetConnectionData, CType(Session("ProStartdate"), String), CType(Session("ProEnddate"), String), CType(Session("PlanStartdate"), String), CType(Session("PlanEnddate"), String), "A")
        obj.InsertEntity(txt_Name_compare.Text, "U_3", "1", "rbIActuals.Checked", multipleEntityName, CType(Session("List"), String), CType(Session("Setclip"), String), CType(Session("SetclipLarge"), String), Entitycode, CType(Session("ProStartdate"), String), CType(Session("ProEnddate"), String), CType(Session("PlanStartdate"), String), CType(Session("PlanEnddate"), String), "0", "0", False, GetConnectionData)

    End Sub


End Class
