Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Public Class EnterpriseMeter
    ' Inherits BizPlanWebBase
    Inherits System.Web.UI.Page
 
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tsHoriz As Microsoft.Web.UI.WebControls.TabStrip

    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Private _dt As BusinessTable
    Public totLibality As Double
    Public totassets As Double
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Public TOLLib_CAp As Double
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents MerchantMeter As System.Web.UI.WebControls.Table
    Protected WithEvents Listmeter As System.Web.UI.WebControls.Table
    Protected WithEvents AdvanceMeters As System.Web.UI.WebControls.Table
    Protected WithEvents Panel3 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMeterName As System.Web.UI.WebControls.Label
    Protected WithEvents lblZoomEntitName As System.Web.UI.WebControls.Label
    Protected WithEvents MeterZoomView As System.Web.UI.WebControls.Table
    Protected WithEvents imgbtnAdv As System.Web.UI.WebControls.Button
    Protected WithEvents PanelZoom As System.Web.UI.WebControls.Panel
    Protected WithEvents editmeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents zoommeter As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgbtnBack As System.Web.UI.WebControls.Button
    Protected WithEvents pnlManager1 As System.Web.UI.WebControls.Panel
    Protected WithEvents mainpanel1 As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.

        InitializeComponent()
    End Sub

#End Region
    Dim ObjCustomer As CustomerStatus
    Private bsDV As New DataView
    Dim Objplan As Plan
    Dim dtUserRigths As DataTable

    Public BPObject As InfiniLogic.BusinessPlan.BLL.BusinessPlan
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        
    End Sub


End Class
