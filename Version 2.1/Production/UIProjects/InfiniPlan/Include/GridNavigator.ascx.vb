  
Public Class GridNavigator
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected WithEvents txtFrom As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtTo As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSearch As System.Web.UI.WebControls.Button
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents dgProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgInvItems As System.Web.UI.WebControls.DataGrid
    Protected WithEvents btnShowAll As System.Web.UI.WebControls.Button
    Protected WithEvents btnCreateInvoice As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents GNavigator As GridNavigator
    Protected WithEvents lblTitleofGrid As System.Web.UI.WebControls.Label
    Private _selectedLedgers As DataTable
    Protected WithEvents lblIDSearch As System.Web.UI.WebControls.Label
    Protected WithEvents lblNameSearch As System.Web.UI.WebControls.Label
    Protected WithEvents InvoiceItems As System.Web.UI.WebControls.Label
    Protected WithEvents btnFirst As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnPrev As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnNext As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnLast As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnShowListing As System.Web.UI.WebControls.LinkButton
    Protected WithEvents PageNo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents LastPageNo As System.Web.UI.HtmlControls.HtmlInputHidden
    Protected WithEvents GridName As System.Web.UI.HtmlControls.HtmlInputHidden



    'Protected WithEvents data_grid As DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Public Event FirstPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event LastPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event NextPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event PreviousPageClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Public Event ShowListClicked(ByVal sender As System.Object, ByVal e As System.EventArgs)


#Region "Properties"

    Public Property CurrentPageIndex() As Integer
        Get
            Return CInt(PageNo.Value)
        End Get
        Set(ByVal Value As Integer)
            PageNo.Value = CType(Value, String)
            PagingLogic()
        End Set
    End Property

    Public Property LastPageIndex() As Integer
        Get
            Return CInt(LastPageNo.Value)
        End Get
        Set(ByVal Value As Integer)

            LastPageNo.Value = CType(Value, String)
            PagingLogic()
        End Set
    End Property

    Public WriteOnly Property Grid() As String
        Set(ByVal Value As String)
            'data_grid = Value
            GridName.Value = Value
            'data_grid.AllowPaging = False
            CType(Me.Parent.FindControl(GridName.Value), DataGrid).AllowPaging = False
        End Set
    End Property

    Public WriteOnly Property ShowNavigator() As Boolean
        Set(ByVal Value As Boolean)
            btnShowListing.Visible = Not Value
            ' data_grid.AllowPaging = Not Value
            CType(Me.Parent.FindControl(GridName.Value), DataGrid).AllowPaging = Not Value
            ButtonsVisibility(Value)
        End Set
    End Property

#End Region

#Region " Events   "
 
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnFirst.ToolTip = "First"
        btnLast.ToolTip = "Last"
        btnPrev.ToolTip = "Previous"
        btnNext.ToolTip = "Next"
    End Sub

    Public Sub btnShowListing_Click(ByVal o As Object, ByVal e As System.EventArgs) Handles btnShowListing.Click
        'btnShowListing.Visible = False
        'ButtonsVisibility(True)
        'data_grid.AllowPaging = False
        ShowNavigator = True
        CurrentPageIndex = 0
        RaiseEvent ShowListClicked(0, e)
    End Sub

    Private Sub FirstPage(ByVal o As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnFirst.Click

        CurrentPageIndex = 0
        RaiseEvent FirstPageClicked(o, e)
    End Sub

    Private Sub LastPage(ByVal o As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnLast.Click
        CurrentPageIndex = CType(LastPageNo.Value, Integer)
        RaiseEvent LastPageClicked(o, e)
    End Sub

    Private Sub PreviousPage(ByVal o As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnPrev.Click
        CurrentPageIndex = CurrentPageIndex - 1
        RaiseEvent PreviousPageClicked(o, e)
    End Sub

    Private Sub NextPage(ByVal o As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnNext.Click
       
            CurrentPageIndex = CurrentPageIndex + 1
            RaiseEvent NextPageClicked(o, e)

      
    End Sub

#End Region

#Region "Private Subroutines"

    Private Sub ButtonsVisibility(ByVal vis As Boolean)
        btnFirst.Visible = vis
        btnPrev.Visible = vis
        btnNext.Visible = vis
        btnLast.Visible = vis
    End Sub

    Public Sub PagingLogic()

        If PageNo.Value = CType(0, String) Then

            btnFirst.Enabled = False
            btnFirst.ImageUrl = "/images/InfiniPlan/ipfirstpgd.gif"

            btnPrev.Enabled = False
            btnPrev.ImageUrl = "/images/InfiniPlan/ipprevpgd.gif"


            btnNext.Enabled = True
            btnNext.ImageUrl = "/images/InfiniPlan/ipnextpg.gif"

            btnLast.Enabled = True
            btnLast.ImageUrl = "/images/InfiniPlan/iplastpg.gif"

        ElseIf PageNo.Value = LastPageNo.Value Then
            btnNext.Enabled = False
            btnNext.ImageUrl = "/images/InfiniPlan/ipnextpgd.gif"

            btnLast.Enabled = False
            btnLast.ImageUrl = "/images/InfiniPlan/iplastpgd.gif"

            btnFirst.Enabled = True
            btnFirst.ImageUrl = "/images/InfiniPlan/ipfirstpg.gif"

            btnPrev.Enabled = True
            btnPrev.ImageUrl = "/images/InfiniPlan/ipprevpg.gif"

        Else
            btnFirst.Enabled = True
            btnFirst.ImageUrl = "/images/InfiniPlan/ipfirstpg.gif"

            btnPrev.Enabled = True
            btnPrev.ImageUrl = "/images/InfiniPlan/ipprevpg.gif"

            btnNext.Enabled = True
            btnNext.ImageUrl = "/images/InfiniPlan/ipnextpg.gif"

            btnLast.Enabled = True
            btnLast.ImageUrl = "/images/InfiniPlan/iplastpg.gif"
        End If
        RecordChecking()

    End Sub

    Public Function RecordChecking() As Integer
        If LastPageIndex = 0 Then

            btnFirst.Enabled = False
            btnFirst.ImageUrl = "/images/InfiniPlan/ipfirstpgd.gif"

            btnPrev.Enabled = False
            btnPrev.ImageUrl = "/images/InfiniPlan/ipprevpgd.gif"

            btnNext.Enabled = False
            btnNext.ImageUrl = "/images/InfiniPlan/ipnextpgd.gif"

            btnLast.Enabled = False
            btnLast.ImageUrl = "/images/InfiniPlan/iplastpgd.gif"

        End If
    End Function
#End Region
 
End Class
