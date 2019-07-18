Imports Microsoft.Web.UI.WebControls

Public Class WebForm1
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ItemsGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents tr As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents ret_val As System.Web.UI.WebControls.TextBox
    Protected WithEvents ret_val2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTest As System.Web.UI.WebControls.TextBox
    Protected WithEvents trv1 As Microsoft.Web.UI.WebControls.TreeView
    Protected WithEvents trv As Microsoft.Web.UI.WebControls.TreeView
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim Cart As DataTable
    Dim CartView As DataView
    Public Sub bulidTree()
        Dim tv As New TreeView
        Dim tn As New TreeNode
        tn.Text = "<Table  width=99%  id = # 135#headingid=#U_4#parentid = #U_0#headingtype=#0# InsertOrder=#1 # ><Tr><Td align=left width=100%> <font size=2 Font-Bold=True color= SteelBlue>1. Executive Summary</Font></td><td></td></tr></Table>"
        trv.Nodes.Add(tn)
        Dim tn1 As New TreeNode
        tn1.Text = "<Table  width=94%  id = # 136#headingid=#U_5#parentid = #U_4#headingtype=#0# InsertOrder=#4 # ><Tr><Td align=left width=100% ><font size=2 Font-Bold=True color= SteelBlue>1.1. Objectives</Font></td><td></td></tr></Table>"
        tn.Nodes.Add(tn1)
        tn1 = New TreeNode
        tn1.Text = "<Table  width=94%  id = # 137#headingid=#U_6#parentid = #U_4#headingtype=#0# InsertOrder=#5 # ><Tr><Td align=left width=100% ><font size=2 Font-Bold=True color= SteelBlue>1.2. Mission</Font></td><td></td></tr></Table>"
        tn1.NavigateUrl = "aspx.net"
        tn.Nodes.Add(tn1)
        'trv.Nodes.Add(tn)
        tn = New TreeNode
        tn.Text = "Company Information"
        trv.Nodes.Add(tn)
        tn1 = New TreeNode
        tn1.Text = "Owner Information"
        tn.Nodes.Add(tn1)

    End Sub
    Function CreateDataSource() As ICollection
        Dim dt As New DataTable
        Dim dr As DataRow

        dt.Columns.Add(New DataColumn("IntegerValue", GetType(Int32)))
        dt.Columns.Add(New DataColumn("StringValue", GetType(String)))
        dt.Columns.Add(New DataColumn("CurrencyValue", GetType(Double)))

        Dim i As Integer
        For i = 0 To 9
            dr = dt.NewRow()

            dr(0) = i
            dr(1) = "Item " & i.ToString()
            dr(2) = 1.23 * (i + 1)

            dt.Rows.Add(dr)
        Next i

        Dim dv As New DataView(dt)
        Return dv
    End Function 'CreateDataSource
    Sub Item_Bound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)

        Label1.Text = Label1.Text & " " & e.Item.ItemIndex
    End Sub 'Item_Bound 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'If Not IsPostBack Then
        '    ' Need to load this data only once.
        '    ItemsGrid.DataSource = CreateDataSource()
        '    ItemsGrid.DataBind()
        'End If
        Try
            If Not IsPostBack Then
                bulidTree()
                Button1.Attributes.Add("onClick", "javascript:void(0);return rename_prompt('Comapay');")
                'tv.Nodes.Add(tn)
                'Panel1.Controls.Add(tv)
            Else
                'TextBox1.Text = trv.SelectedNodeIndex
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Response.Write("Nisar")
        'Dim tv As New TreeView
        'Dim tn As New TreeNode
        'tn.Text = "My node"
        'Dim tn1 As New TreeNode
        'tn1.Text = "Sub Node"
        'tn.Nodes.Add(tn1)
        'tv.Nodes.Add(tn)
        'Panel1.Controls.Add(tv)
        Dim RenameNodeValue As String = TextBox1.Text
        'Dim strtext As String = txtTest.Text

        trv.Nodes.Clear()
        bulidTree()

    End Sub
End Class
