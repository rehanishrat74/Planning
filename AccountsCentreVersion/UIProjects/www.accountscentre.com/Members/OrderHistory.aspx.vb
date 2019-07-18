Imports InfiniLogic.AccountsCentre.DAL

Public Class OrderHistory
    Inherits MembersDefault
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
   
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgOrders As System.Web.UI.WebControls.DataGrid
    

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
        Dim cmdData As New CommandData(customerid)
        Dim ds As DataSet

        With cmdData
            .AddParameter("@CustomerID", Request("i"))
            .CmdText = "INFINISHOPS_ORDER_GETALL"
            ds = .Execute(ExecutionType.ExecuteDataSet)
        End With

        With dgOrders
            .DataSource = ds.Tables(0)
            .DataBind()
        End With
    End Sub

End Class
