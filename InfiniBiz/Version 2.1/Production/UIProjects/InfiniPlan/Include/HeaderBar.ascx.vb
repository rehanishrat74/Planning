Imports Infinilogic.BusinessPlan.Web.Common


Public Class HeaderBar
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents imgBtnPlanManager As System.Web.UI.WebControls.ImageButton

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private _planFlag As Boolean
    Private _planName As String = ""
    Private _customerName As String = "InvalidCustomerWithoutLogin"



    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Dim basePage As BizPlanWebBase
        basePage = CType(Me.Page, BizPlanWebBase)
        Trace.Warn("basePage" & basePage.Page.ID)
        _planFlag = basePage.IsPlanOpened()
        Trace.Warn("_planFlag" & _planFlag)
        If (_planFlag) Then
            '  This is to be Uncommented , after integration with Accounts Centre
            _planName = basePage.CurrentPlan.PlanName
        Else
            '    This is to be Uncommented , after integration with Accounts Centre
            _customerName = basePage.GetCustomerName
        End If
        Trace.Warn("-------------- InfiniPlan Header Bar --------------")
        Trace.Warn(CType(_planFlag, String))
        'Trace.Warn(_planName)



    End Sub

#Region "Properties"

    Public ReadOnly Property CustomerName() As String
        Get
            Return _customerName
        End Get
    End Property

    Public ReadOnly Property PlanName() As String
        Get
            Return _planName
        End Get
    End Property

    Public ReadOnly Property PlanFlag() As Boolean
        Get
            Return _planFlag
        End Get
    End Property

#End Region



End Class
