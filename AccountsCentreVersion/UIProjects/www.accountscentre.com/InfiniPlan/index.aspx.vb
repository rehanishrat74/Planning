Imports Infinilogic.BusinessPlan.Web.Common

Public Class index
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents imgbtnNewPlan As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnLastPlan As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnSamplePlan As System.Web.UI.WebControls.ImageButton
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtPlanName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblPlanName As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlanDescription As System.Web.UI.WebControls.Label
    Protected WithEvents txtPlanDescription As System.Web.UI.WebControls.TextBox
    Protected WithEvents ddlStartMonth As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblStartMonth As System.Web.UI.WebControls.Label
    Protected WithEvents lblStartYear As System.Web.UI.WebControls.Label
    Protected WithEvents ddlStartYear As System.Web.UI.WebControls.DropDownList
    Protected WithEvents ddlBusinessStatus As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents ddlBusinessGoods As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtSTR As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtSalesOnCreditPercent As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtCollectionPeriod As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPaymentDays As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSTIRate As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents lblTableHeading As System.Web.UI.WebControls.Label
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Form3 As System.Web.UI.HtmlControls.HtmlForm

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
        'UIPManager.StartOpenNavigationTask("Tables", "PlanWelcome", Nothing)
    End Sub

End Class
