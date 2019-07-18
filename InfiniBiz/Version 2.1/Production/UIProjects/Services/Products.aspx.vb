#Region "Imports Libraries"

Imports InfiniLogic.AccountsCentre.BLL

#End Region

Public Class Products

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents servicearea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents TheMenu As New LeftMenu
    Protected WithEvents grdPackages As System.Web.UI.WebControls.DataGrid
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlPaymentMethod As System.Web.UI.WebControls.Panel
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell




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
    End Sub

    Private Sub menuarea_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuarea.Init

        'With TheMenu

        '    .AddItem("IMG", "/images/productsinfo.jpg", "https://www.accountscentre.com/services/products.aspx", True)
        '    If User.Identity.IsAuthenticated Then
        '        .AddItem("SGNN", "::. Sign Out", "https://www.accountscentre.com/account/signout.aspx")
        '        .AddItem("UPSRV", "::. Update Services", "https://www.accountscentre.com/Members/UpdateServices.aspx")
        '    Else
        '        .AddItem("SGNN1", "::. Sign In", "https://www.accountscentre.com/account/signin.aspx")
        '        .AddItem("REGR", "::. Registration", "https://www.accountscentre.com/Account/newcustomer.aspx")
        '    End If

        'End With

        'menuarea.InnerHtml = TheMenu.Render

        'TheMenu = Nothing

    End Sub

    Private Sub pnlPaymentMethod_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPaymentMethod.Load


        If Not Page.IsPostBack Then

            ' INSERT AMOUNT IN PRODUCT SELECTION OF REGISTRATION PROCESS
            Dim ds As New DataSet

            ds = BLL.User.ACC_GetProductsToSale()

            grdPackages.DataSource = ds.Tables(0)
            grdPackages.DataBind()

            grdProducts.DataSource = ds.Tables(1)
            grdProducts.DataBind()

        End If

    End Sub

End Class
