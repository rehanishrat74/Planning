Public Class Test_Yousuf
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

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
        Dim ds As DataTable = Infinilogic.AccountsCentre.BLL.CustomerProfile.GetCountries()
        DataGrid1.DataSource = ds
        DataGrid1.DataBind()

        Dim ds2 As DataTable = Infinilogic.AccountsCentre.BLL.CustomerProfile.GetCountries()
        DataGrid1.DataSource = ds2
        DataGrid1.DataBind()

        DataGrid1.DataSource = ds2
        DataGrid1.DataBind()

        DataGrid1.DataSource = ds2
        DataGrid1.DataBind()
    End Sub

    'Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
    '    Trace.Write("Start Page_PreRender" & Now)
    '    MyBase.OnPreRender(e)
    '    Trace.Write("End Page_PreRender" & Now)
    'End Sub
End Class
