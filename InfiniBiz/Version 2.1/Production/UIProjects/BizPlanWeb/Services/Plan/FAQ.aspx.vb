Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO
 
Public Class FAQ
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading3 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText3 As System.Web.UI.WebControls.Label

    Dim ObjCustomer As CustomerStatus
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnStart As System.Web.UI.WebControls.Button
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        InitiliazeLanguage()
    End Sub

#End Region
    Dim aa As Plan
    Private Sub InitiliazeLanguage()

        
    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        'Put user code to initialize the page here
       
    End Sub

    
End Class
