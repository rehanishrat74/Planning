Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Microsoft.Web.UI.WebControls

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class PlanOutLine

    Inherits PlanLineBase
    'Inherits System.Web.UI.Page


    ''Inherits PlanLineBase
    'Inherits System.Web.UI.Page

    Dim ReCall As Boolean
    Dim Plan As BusinessPlan.BLL.BusinessPlan
    Dim dsGetHeadings As DataSet
    Dim dsDeleteHeadings As DataSet
    Dim headingid As String
    Dim indexid As Integer
    Dim headingtype As Integer
    Dim InsertOrder As Integer
    Dim parentid As String
    Dim nodeindex As String
    Dim selectednodetext As String
    Dim getnodevalues As String()
    Dim refreshsender As System.Object
    Dim refreshe As System.EventArgs
    Private _pageID As Integer = -1
#Region " Web Form Designer Generated Code "
    Dim root As TreeNode
    Dim istchildNode As TreeNode
    Dim secondchildNode As TreeNode
    Private curPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Public ObjPlan As Plan
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents RadioButton1 As System.Web.UI.WebControls.RadioButton
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents rbtAll As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbtAny As System.Web.UI.WebControls.RadioButton
    Protected WithEvents TreeView2 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents test As System.Web.UI.WebControls.Button

    Protected WithEvents txtNewNode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtRenameNode As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents imgbtnCancelInsert As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnCancelRename As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Imagebutton4 As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImgText As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImgTable As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents ImgChart As System.Web.UI.HtmlControls.HtmlImage
    Protected WithEvents opertion_type As System.Web.UI.WebControls.TextBox
    Protected WithEvents TreeViewPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents AjaxPanelTreeView As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents ret_val As System.Web.UI.WebControls.TextBox
    Protected WithEvents PlanOutLineHeading As System.Web.UI.WebControls.Label
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents EditAjaxpanel As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents lblEdit As System.Web.UI.WebControls.Label
    Protected WithEvents exception As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelp As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents btnInsert As System.Web.UI.WebControls.Button
    Protected WithEvents rbRoot As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbChild As System.Web.UI.WebControls.RadioButton
    Protected WithEvents lblSelectedNodeTop As System.Web.UI.WebControls.Label
    Protected WithEvents btnRename As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnDelete As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblHelpHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnRestore As System.Web.UI.WebControls.Button
    Protected WithEvents lblSelectedNode As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label




    Public objtext As TextOperations

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub



    Private Sub InitiliazeLanguage()
        Me.rbRoot.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_rbRoot")
        Me.rbChild.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_rbChild")
        Me.btnRestore.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnRestore")
        Me.btnCancel.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnCancel")
        'Me.btnRename.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnRename")
        Me.btnInsert.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnInsert")
        'Me.btnDelete.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnDelete")
        ' Me.imgbtnCancelInsert.ToolTip = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_imgbtnCancelInsert")
        ' Me.imgbtnCancelRename.ToolTip = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_imgbtnCancelRename")
        Me.lblHelp.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_lblHelp")
        Me.lblEdit.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_lblEdit")
        Me.lblHelpHeading.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_lblHelpHeading")
        Me.PlanOutLineHeading.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_PlanOutLineHeading")

    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt();")
        'btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt();")
        btnDelete.Attributes.Add("onClick", "javascript:void(0);return delete_prompt();")
        btnRestore.Attributes.Add("onClick", "javascript:void(0);return restore_prompt();")



        If Not IsNothing(Request.QueryString("LineID")) Then _pageID = CInt(Request.QueryString("LineID"))
        Dim a As Object = Session("planid")

        If _pageID < 0 Then

        Else
            If (Not Page.IsPostBack) Then
                Dim redirectURL As String
                Select Case _pageID
                    Case 1 ' if it is table
                        redirectURL = "/InfiniPlan/Services/Text/PlanText.aspx"
                    Case 2 ' if it is table
                        redirectURL = "/InfiniPlan/Services/Tables/Table.aspx"
                    Case 3 ' if it is table
                        redirectURL = "/InfiniPlan/Services/Charts/Chart.aspx"


                End Select
                Response.Redirect(redirectURL)
            End If
        End If


        Plan = New BusinessPlan.BLL.BusinessPlan(CurrentPlan)
        'imgbtnCancelInsert.ToolTip = "Cancel Insert"
        'imgbtnCancelRename.ToolTip = "Cancel Rename"

        If Not IsPostBack Then
            BuildTree()
            'new
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex("0").Text

        Else
            Session("SelectIndex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("SelectIndex"), String)
            'new
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex(nodeindex).Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex(nodeindex).Text) & "');")
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex(nodeindex).Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex(nodeindex).Text
            ParameterSeetings()
            If (headingtype = 1 Or headingtype = 2) Then
                btnDelete.Enabled = False
                rbChild.Enabled = False
                btnRename.Enabled = False
                ' txtRenameNode.Enabled = False
            Else
                btnDelete.Enabled = True
                rbChild.Enabled = True
                btnRename.Enabled = True
                'txtRenameNode.Enabled = True
            End If
            exception.Text = ""
            Session("SelectIndex") = Nothing
        End If
        If (Page.IsPostBack) Then
            'HandlePostBack()
        End If


    End Sub

    Private Sub ParameterSeetings()
        selectednodetext = TreeView1.GetNodeFromIndex(nodeindex).Text
        'btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt(" & RemoveHTML(selectednodetext) & ");")
        getnodevalues = selectednodetext.Split("#"c)
        indexid = CInt(getnodevalues(1))
        headingid = getnodevalues(3)
        parentid = getnodevalues(5)
        headingtype = CInt(getnodevalues(7))
        InsertOrder = CInt(getnodevalues(9))
    End Sub

    Private Sub BuildTree()
        dsGetHeadings = objtext.GetPlanTextHeadings(GetConnectionData, Plan)

        Dim dtHeading As DataTable
        Dim drRoot() As DataRow
        Dim dristchild() As DataRow
        Try
            dtHeading = dsGetHeadings.Tables(0)
            drRoot = dtHeading.Select("[Parentheadingid] ='U_0' and headingtype<>3 and headingtype<>4")

            Dim drsecondchild() As DataRow
            Dim rootid As Integer
            Dim istchildid As Integer
            Dim secondchildid As Integer

            Dim rootlevel As DataRow
            Dim rootNodeName As String
            Dim istName As String

            Dim rootPlanid As String
            Dim istchildheadingtype As Integer
            Dim secondchildheadingtype As Integer
            Dim rootheadingtype As Integer
            Dim rootInstuctions As String
            Dim rootInsertOrder As Integer
            Dim istchildInsertOrder As Integer
            Dim secondchildInsertOrder As Integer
            Dim stringmerge As String

            Dim secondName As String
            Dim istChildNodeName As String
            Dim secondChildNodeName As String
            Dim i As Integer = 0
            Dim level1 As Integer = 1
            Dim rootheadingid As String
            Dim rootparentheadingid As String
            For Each rootlevel In drRoot

                root = New TreeNode
                i = i + 1
                rootid = CInt(rootlevel.Item(0))
                rootheadingid = CStr(rootlevel.Item(1))
                rootNodeName = CStr(rootlevel.Item(2))
                rootparentheadingid = CStr(rootlevel.Item(3))
                rootPlanid = CStr(rootlevel.Item(4))
                rootheadingtype = CInt(rootlevel.Item(7))
                rootInsertOrder = CInt(rootlevel.Item(9))

                'root.ImageUrl = "/../../images/InfiniPlan/root.gif"
                'root.ExpandedImageUrl = "/../../images/InfiniPlan/root.gif"
                '  root.CheckBox = True

                root.Text = "<Table  width=99%  id =" & " # " & rootid & "#" & "headingid=" & "#" & rootheadingid & "#" & "parentid = " & "#" & rootparentheadingid & "#" & "headingtype=" & "#" & rootheadingtype & "#" & " InsertOrder=" & "#" & rootInsertOrder & " #" & " ><Tr><Td align=left width=100%> <font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & " " & rootNodeName & "</Font></td><td></td></tr></Table>"

                TreeView1.Nodes.Add(root)

                istName = CStr(rootlevel.Item(1))
                dristchild = dtHeading.Select("parentheadingid ='" & istName & " ' ")

                Dim istchildheadingid As String
                Dim istchildparentheadingid As String
                Dim istchildlevel As DataRow
                Dim level2 As Integer = 1
                For Each istchildlevel In dristchild

                    istchildNode = New TreeNode
                    i = i + 1
                    '     istchildNode.CheckBox = True
                    istchildid = CInt(istchildlevel.Item(0))
                    istchildheadingid = CStr(istchildlevel.Item(1))
                    istChildNodeName = CStr(istchildlevel.Item(2))
                    istchildparentheadingid = CStr(istchildlevel.Item(3))
                    istchildheadingtype = CInt(istchildlevel.Item(7))
                    istchildInsertOrder = CInt(istchildlevel.Item(9))
                    If (istchildheadingtype = 1) Then
                        istchildNode.ImageUrl = "/images/InfiniPlan/PlanTable.gif"
                    ElseIf (istchildheadingtype = 2) Then
                        istchildNode.ImageUrl = "/images/InfiniPlan/PlanChart.gif"
                    Else

                    End If

                    istchildNode.Text = "<Table  width=94%  id =" & " # " & istchildid & "#" & "headingid=" & "#" & istchildheadingid & "#" & "parentid = " & "#" & istchildparentheadingid & "#" & "headingtype=" & "#" & istchildheadingtype & "#" & " InsertOrder=" & "#" & istchildInsertOrder & " #" & " ><Tr><Td align=left width=100% ><font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & level2 & "." & " " & istChildNodeName & "</Font></td><td></td></tr></Table>"
                    root.Nodes.Add(istchildNode)

                    secondName = CStr(istchildlevel.Item(1))
                    drsecondchild = dtHeading.Select("parentheadingid ='" & secondName & " ' ")
                    Dim secondchildlevel As DataRow
                    Dim level3 As Integer = 1
                    Dim secondchildheadingid As String
                    Dim secondchildparentheadingid As String
                    For Each secondchildlevel In drsecondchild

                        secondchildNode = New TreeNode

                        '     secondchildNode.CheckBox = True
                        i = i + 1
                        secondchildid = CInt(secondchildlevel.Item(0))
                        secondchildheadingid = CStr(secondchildlevel.Item(1))
                        secondChildNodeName = CStr(secondchildlevel.Item(2))
                        secondchildparentheadingid = CStr(secondchildlevel.Item(3))
                        secondchildheadingtype = CInt(secondchildlevel.Item(7))
                        secondchildInsertOrder = CInt(secondchildlevel.Item(9))
                        If (secondchildheadingtype = 1) Then
                            secondchildNode.ImageUrl = "/images/InfiniPlan/PlanTable.gif"
                        ElseIf (secondchildheadingtype = 2) Then
                            secondchildNode.ImageUrl = "/images/InfiniPlan/PlanChart.gif"

                        Else

                        End If
                        secondchildNode.Text = "<Table   width=89%   id =" & " # " & secondchildid & "#" & "headingid=" & "#" & secondchildheadingid & "#" & "parentid = " & "#" & secondchildparentheadingid & "#" & "headingtype=" & "#" & secondchildheadingtype & "#" & " InsertOrder=" & "#" & secondchildInsertOrder & " #" & " ><Tr><Td align=left width=100%><font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & level2 & "." & level3 & "." & " " & secondChildNodeName & "</Font></td><td></td></tr></Table>"
                        istchildNode.Nodes.Add(secondchildNode)
                        level3 = level3 + 1
                    Next
                    level2 = level2 + 1
                Next
                level1 = level1 + 1
            Next
        Catch ex As exception
            Dim strExcetion As String = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
            '   lblMessage.Text = strExcetion
        End Try

    End Sub

    Private Sub btnInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        Try
            Dim MaxCount As Integer = 5
            Session("getindex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("getindex"), String)
            Dim NewNodeValue As String = ret_val.Text
            If (NewNodeValue = "") Then
                NewNodeValue = "Untitled Node"
            End If
            ParameterSeetings()
            If (nodeindex.Length < MaxCount) Then
                If (rbRoot.Checked = True) Then
                    objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, parentid, InsertOrder)
                ElseIf (rbChild.Checked = True) Then
                    objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, headingid, InsertOrder)

                End If
            ElseIf (nodeindex.Length = MaxCount) Then
                If (rbRoot.Checked = True) Then
                    objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, parentid, InsertOrder)

                ElseIf (rbChild.Checked = True) Then
                    Throw New exception("Not insert Child , Insert Aborted")
                End If
            End If

            'txtNewNode.Text = ""

            If (rbRoot.Checked = True) Then
                exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_FolderCreated")
            Else
                exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_SubFolderCreated")
            End If

        Catch ex As exception
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception_insert")
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex("0").Text
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")

        End Try
        Session("getindex") = Nothing
        TreeView1.Nodes.Clear()
        BuildTree()
        'new
        ret_val.Text = ""
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnDelete.Click
        Try

            Session("getindex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("getindex"), String)
            ParameterSeetings()

            Dim dtHeadingCheck As DataTable
            Dim drRowCheck As DataRow()
            Dim dsDeleteCheck As DataSet = objtext.GetPlanTextHeadings(GetConnectionData, Plan)
            dtHeadingCheck = dsDeleteCheck.Tables(0)
            'drRoot = dtHeading.Select("[Parentheadingid] ='U_0' ")
            drRowCheck = dtHeadingCheck.Select("[Parentheadingid] = '" & headingid & " '")

            If drRowCheck.Length > 0 Then
                Throw New exception("Node may has child, Delete Aborted")

            Else
                dsDeleteHeadings = objtext.DeletePlanTextHeadings(GetConnectionData, Plan, indexid)
            End If
            'new
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_FolderDeleted")

        Catch ex As exception
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception_Delete")
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex("0").Text
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")

        End Try
        Session("getindex") = Nothing
        TreeView1.Nodes.Clear()
        BuildTree()
    End Sub

    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click

        Try
            Dim strGetDefaults As String = objtext.RestorePlanTextHeadings(GetConnectionData, Plan)
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_Restore")
            TreeView1.Nodes.Clear()
            BuildTree()

        Catch ex As exception
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex("0").Text
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")


        End Try

    End Sub


    Private Sub btnRename_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnRename.Click

        Try
            Session("getindex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("getindex"), String)
            ParameterSeetings()
            Dim RenameNodeValue As String = ret_val.Text
            If (RenameNodeValue = "") Then
                RenameNodeValue = "Rename Node"
            End If

            Dim strRenameHeading As String = objtext.ReNamePlanTextHeadings(GetConnectionData, Plan, indexid, headingid, RenameNodeValue)
            TreeView1.Nodes.Clear()
            BuildTree()
            'new
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_FolderRenamed")
            'txtRenameNode.Text = ""
            ret_val.Text = ""

        Catch ex As exception
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
            lblSelectedNodeTop.Text = TreeView1.GetNodeFromIndex("0").Text
            btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")
            btnInsert.Attributes.Add("onClick", "javascript:void(0);return insert_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "');")

        End Try


    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("/InfiniPlan/services/welcome.aspx")
    End Sub

    Private Sub imgbtnCancelInsert_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnCancelInsert.Click
        txtNewNode.Text = ""
    End Sub


    Private Sub imgbtnCancelRename_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnCancelRename.Click
        txtRenameNode.Text = ""
    End Sub



    Private Sub InitializeComponent()

    End Sub

    'Private Sub HandlePostBack()
    '    Dim EventTarget As String = Request.Form("__EVENTTARGET").ToString()
    '    Select Case opertion_type.Text
    '        Case "btnInsert_Click"
    '            insert_Node()

    '        Case "btnRename_Click"
    '            rename_Node()

    '        Case "btnDelete_Click"
    '            delete_Node()

    '        Case "btnRestore_Click"
    '            restore_Node()

    '    End Select
    'End Sub
    'Public Sub insert_Node()
    '    Try
    '        Dim MaxCount As Integer = 5
    '        Session("getindex") = TreeView1.SelectedNodeIndex
    '        nodeindex = CType(Session("getindex"), String)
    '        'Dim NewNodeValue As String = txtNewNode.Text
    '        Dim NewNodeValue As String = ret_val.Text
    '        If (NewNodeValue = "") Then
    '            NewNodeValue = "Untitled Node"
    '        End If
    '        ParameterSeetings()
    '        If (nodeindex.Length < MaxCount) Then
    '            If (rbRoot.Checked = True) Then
    '                objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, parentid, InsertOrder)
    '            ElseIf (rbChild.Checked = True) Then
    '                objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, headingid, InsertOrder)

    '            End If
    '        ElseIf (nodeindex.Length = MaxCount) Then
    '            If (rbRoot.Checked = True) Then
    '                objtext.InsertPlanTextHeadings(GetConnectionData, Plan, headingid, NewNodeValue, parentid, InsertOrder)

    '            ElseIf (rbChild.Checked = True) Then
    '                Throw New exception("Not insert Child , Insert Aborted")
    '            End If
    '        End If

    '        txtNewNode.Text = ""
    '        'new
    '        If (rbRoot.Checked = True) Then
    '            exception.Text = "Folder Created"
    '        Else
    '            exception.Text = "Sub-Folder Created"
    '        End If
    '    Catch ex As exception
    '        exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception_insert")
    '    End Try
    '    Session("getindex") = Nothing
    '    TreeView1.Nodes.Clear()
    '    BuildTree()



    'End Sub

    'Private Sub rename_Node()

    '    Try
    '        Session("getindex") = TreeView1.SelectedNodeIndex
    '        nodeindex = CType(Session("getindex"), String)
    '        ParameterSeetings()
    '        Dim RenameNodeValue As String = ret_val.Text
    '        If (RenameNodeValue = "") Then
    '            RenameNodeValue = "Rename Node"
    '        End If

    '        Dim strRenameHeading As String = objtext.ReNamePlanTextHeadings(GetConnectionData, Plan, indexid, headingid, RenameNodeValue)
    '        TreeView1.Nodes.Clear()
    '        BuildTree()
    '        btnRename.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('" & RemoveHTML(TreeView1.GetNodeFromIndex(nodeindex).Text) & "');")
    '        'new
    '        exception.Text = "Node Renamed"

    '    Catch ex As exception
    '        exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
    '    End Try
    '    txtRenameNode.Text = ""


    'End Sub

    'Private Sub delete_Node()
    '    Try

    '        Session("getindex") = TreeView1.SelectedNodeIndex
    '        nodeindex = CType(Session("getindex"), String)
    '        ParameterSeetings()

    '        Dim dtHeadingCheck As DataTable
    '        Dim drRowCheck As DataRow()
    '        Dim dsDeleteCheck As DataSet = objtext.GetPlanTextHeadings(GetConnectionData, Plan)
    '        dtHeadingCheck = dsDeleteCheck.Tables(0)
    '        'drRoot = dtHeading.Select("[Parentheadingid] ='U_0' ")
    '        drRowCheck = dtHeadingCheck.Select("[Parentheadingid] = '" & headingid & " '")

    '        If drRowCheck.Length > 0 Then
    '            Throw New exception("Node may has child, Delete Aborted")

    '        Else
    '            dsDeleteHeadings = objtext.DeletePlanTextHeadings(GetConnectionData, Plan, indexid)
    '        End If

    '        'new
    '        exception.Text = "node deleted"

    '    Catch ex As exception
    '        exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception_Delete")
    '    End Try
    '    Session("getindex") = Nothing
    '    TreeView1.Nodes.Clear()
    '    BuildTree()

    'End Sub

    'Private Sub restore_Node()

    '    Try
    '        Dim strGetDefaults As String = objtext.RestorePlanTextHeadings(GetConnectionData, Plan)
    '        exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_Restore")
    '        TreeView1.Nodes.Clear()
    '        BuildTree()
    '        exception.Text = "Plan Outline restored to original"

    '    Catch ex As exception
    '        exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
    '    End Try

    'End Sub

    Function RemoveHTML(ByVal strText As String) As String
        Dim strInput As String
        Dim strOutput As String
        strOutput = Regex.Replace(strText, "<[^>]*>", "")
        Return strOutput
    End Function



End Class
