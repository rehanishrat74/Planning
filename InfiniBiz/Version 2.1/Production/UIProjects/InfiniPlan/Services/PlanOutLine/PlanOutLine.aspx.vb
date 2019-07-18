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
    ' Inherits System.Web.UI.Page


    ''Inherits PlanLineBase
    'Inherits System.Web.UI.Page

    Dim ReCall As Boolean
    Dim Plan As BusinessPlan.BLL.BusinessPlan
    Dim dsGetHeadings As DataSet
    Dim dsDeleteHeadings As DataSet
    Dim dsRestoreHeadings As String
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
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents ret_val As System.Web.UI.WebControls.TextBox
    Protected WithEvents PlanOutLineHeading As System.Web.UI.WebControls.Label
    Protected WithEvents TreeView1 As Microsoft.Web.UI.WebControls.TreeView
      Protected WithEvents AjaxPanelTreeView As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents TreeViewPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblEdit As System.Web.UI.WebControls.Label
    Protected WithEvents exception As System.Web.UI.WebControls.Label
    Protected WithEvents lblHelpHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnRestore As System.Web.UI.WebControls.Button
    Protected WithEvents EditAjaxpanel As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblSelectedNode As System.Web.UI.WebControls.Label
    Protected WithEvents btnDelete As System.Web.UI.WebControls.Button
    Protected WithEvents Edit As System.Web.UI.WebControls.Panel




    Public objtext As TextOperations

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub



    Private Sub InitiliazeLanguage()
              Me.btnRestore.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_btnRestore")
                 Me.lblEdit.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_lblEdit")
        Me.lblHelpHeading.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_lblHelpHeading")
        Me.PlanOutLineHeading.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_PlanOutLineHeading")

    End Sub
#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
       
        If Not IsPostBack Then
            BuildTree()
            'new
                lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"
       
        Else
            Session("SelectIndex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("SelectIndex"), String)
            'new
                lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex(nodeindex).Text) & "</b>"
               ParameterSeetings()
            If (headingtype = 1 Or headingtype = 2) Then
                btnDelete.Enabled = False
                     ' txtRenameNode.Enabled = False
            Else
                btnDelete.Enabled = True
                     'txtRenameNode.Enabled = True
            End If
            exception.Text = ""
            Session("SelectIndex") = Nothing
        End If
        If (Page.IsPostBack) Then
            'HandlePostBack()
        End If
        CurPage = 3
        CurItem = 2

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
        Trace.Write(" BuildTree start")
        dsGetHeadings = objtext.GetOutLineHeadings(GetConnectionData, Plan)

        Dim dtHeading As DataTable
        Dim drRoot() As DataRow
        Dim dristchild() As DataRow
        Try
            dtHeading = dsGetHeadings.Tables(0)
            drRoot = dtHeading.Select("([Parentheadingid] ='U_0' or [Parentheadingid] ='S_0') and headingtype<>1 and headingtype<>2 and headingtype<>3  and headingtype<>4 ")

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
                Trace.Write(rootheadingid)

                'root.ExpandedImageUrl = "/../../images/InfiniPlan/root.gif"
                '  root.CheckBox = True
                If rootparentheadingid.IndexOf("S") <> -1 Then
                    root.ImageUrl = "/images/InfiniPlan/no.png"
                    root.Text = "<Table  width=99%  id =" & " # " & rootid & "#" & "headingid=" & "#" & rootheadingid & "#" & "parentid = " & "#" & rootparentheadingid & "#" & "headingtype=" & "#" & rootheadingtype & "#" & " InsertOrder=" & "#" & rootInsertOrder & " #" & " ><Tr><Td align=left width=100%> <font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & " " & rootNodeName & "</Font></td><td></td></tr></Table>"

                Else
                    root.Text = "<Table  width=99%  id =" & " # " & rootid & "#" & "headingid=" & "#" & rootheadingid & "#" & "parentid = " & "#" & rootparentheadingid & "#" & "headingtype=" & "#" & rootheadingtype & "#" & " InsertOrder=" & "#" & rootInsertOrder & " #" & " ><Tr><Td align=left width=100%> <font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & " " & rootNodeName & "</Font></td><td></td></tr></Table>"

                End If

                TreeView1.Nodes.Add(root)

                istName = CStr(rootlevel.Item(1))
                'dristchild = dtHeading.Select("parentheadingid ='" & istName & " ' ")

                dristchild = dtHeading.Select("(parentheadingid ='" & istName & " ' ) or (parentheadingid ='" & istName.Replace("U", "S") & " ' )")

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
                    'If (istchildheadingtype = 1) Then
                    '    istchildNode.ImageUrl = "/images/InfiniPlan/PlanTable.jpg"
                    'ElseIf (istchildheadingtype = 2) Then
                    '    istchildNode.ImageUrl = "/images/InfiniPlan/PlanChart.jpg"
                    'Else

                    'End If
                    Trace.Write(istchildheadingid)
                    If istchildheadingid.IndexOf("S") <> -1 Then
                        istchildNode.ImageUrl = "/images/InfiniPlan/no.png"
                        istchildNode.Text = "<Table  width=94%  id =" & " # " & istchildid & "#" & "headingid=" & "#" & istchildheadingid & "#" & "parentid = " & "#" & istchildparentheadingid & "#" & "headingtype=" & "#" & istchildheadingtype & "#" & " InsertOrder=" & "#" & istchildInsertOrder & " #" & " ><Tr><Td align=left width=100% ><font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & level2 & "." & " " & istChildNodeName & "</Font></td><td></td></tr></Table>"
                    Else
                        istchildNode.Text = "<Table  width=94%  id =" & " # " & istchildid & "#" & "headingid=" & "#" & istchildheadingid & "#" & "parentid = " & "#" & istchildparentheadingid & "#" & "headingtype=" & "#" & istchildheadingtype & "#" & " InsertOrder=" & "#" & istchildInsertOrder & " #" & " ><Tr><Td align=left width=100% ><font size=2 Font-Bold=True color= SteelBlue>" & level1 & "." & level2 & "." & " " & istChildNodeName & "</Font></td><td></td></tr></Table>"

                    End If
                    root.Nodes.Add(istchildNode)

                    secondName = CStr(istchildlevel.Item(1))
                    ' drsecondchild = dtHeading.Select("parentheadingid ='" & secondName & " ' ")
                    drsecondchild = dtHeading.Select("(parentheadingid ='" & secondName & " ' ) or (parentheadingid ='" & secondName.Replace("U", "S") & " ' )")
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
                        'If (secondchildheadingtype = 1) Then
                        '    secondchildNode.ImageUrl = "/images/InfiniPlan/PlanTable.jpg"
                        'ElseIf (secondchildheadingtype = 2) Then
                        '    secondchildNode.ImageUrl = "/images/InfiniPlan/PlanChart.jpg"

                        'Else

                        'End If
                        Trace.Write(secondchildheadingid)
                        If secondchildheadingid.IndexOf("S") <> -1 Then
                            secondchildNode.ImageUrl = "/images/InfiniPlan/no.png"
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
            Trace.Warn(" BuildTree " + ex.Message)
            Dim strExcetion As String = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
            '   lblMessage.Text = strExcetion
        End Try
        Trace.Write(" BuildTree end")
    End Sub

    
    Private Sub btnRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRestore.Click

        Try
            Trace.Write(" btnRestore_Click start")
            Session("getindex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("getindex"), String)
            ParameterSeetings()

            Dim dtHeadingCheck As DataTable
            Dim drRowCheck As DataRow()
            Dim dsRestoreCheck As DataSet = objtext.GetOutLineHeadings(GetConnectionData, Plan)
            dtHeadingCheck = dsRestoreCheck.Tables(0)

            drRowCheck = dtHeadingCheck.Select("[Parentheadingid] = '" & headingid & " '")
            Trace.Write(" btnRestore_Click start" + headingid)
            Trace.Write(" btnRestore_Click drRowCheck.Length" + CStr(drRowCheck.Length))
            If drRowCheck.Length <= 0 Then
                dsRestoreHeadings = objtext.RestorePlanTextHeadings(GetConnectionData, Plan, indexid)
                exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_Restore")
                exception.ForeColor = Color.Black

            Else
                dsRestoreHeadings = objtext.RestorePlanTextHeadings(GetConnectionData, Plan, indexid)
                exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_Restore")
                exception.ForeColor = Color.Black
            End If

        Catch ex As exception
            Trace.Warn(" btnRestore_Click  " + ex.Message)
            exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception")
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"

        End Try
        Session("getindex") = Nothing
        TreeView1.Nodes.Clear()
        BuildTree()
        Trace.Write(" btnRestore_Click end")
    End Sub

    

    Function RemoveHTML(ByVal strText As String) As String
        Dim strInput As String
        Dim strOutput As String
        strOutput = Regex.Replace(strText, "<[^>]*>", "")
        Return strOutput
    End Function

    Private Overloads Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            Trace.Write(" btnDelete_Click start")
            Session("getindex") = TreeView1.SelectedNodeIndex
            nodeindex = CType(Session("getindex"), String)
            ParameterSeetings()

            Dim dtHeadingCheck As DataTable
            Dim drRowCheck As DataRow()
            Dim dsDeleteCheck As DataSet = objtext.GetOutLineHeadings(GetConnectionData, Plan)
            dtHeadingCheck = dsDeleteCheck.Tables(0)
            'drRoot = dtHeading.Select("[Parentheadingid] ='U_0' ")
            drRowCheck = dtHeadingCheck.Select("[Parentheadingid] = '" & headingid & " '")
            Trace.Write(" btnDelete_Click start" + headingid)
            Trace.Write(" btnDelete_Click drRowCheck.Length" + CStr(drRowCheck.Length))
            If drRowCheck.Length > 0 Then
                exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_exception_Delete")
                exception.ForeColor = Color.Red
            Else
                dsDeleteHeadings = objtext.DeletePlanTextHeadings(GetConnectionData, Plan, indexid)
                exception.Text = "Selected node has been deleted."
                exception.ForeColor = Color.Black
            End If
            'new
            ' exception.Text = ResMgr.GetString("BizPlanWeb_Services_PlanOutLine_PlanOutLine_message_FolderDeleted")

        Catch ex As exception
            Trace.Warn(" btnDelete_Click  " + ex.Message)
        Finally
            lblSelectedNode.Text = "Selected Node is <b>" & RemoveHTML(TreeView1.GetNodeFromIndex("0").Text) & "</b>"

        End Try
        Session("getindex") = Nothing
        TreeView1.Nodes.Clear()
        BuildTree()
        Trace.Write(" btnDelete_Click end")
    End Sub

End Class
