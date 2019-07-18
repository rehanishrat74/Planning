Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO

Public Class FAQ
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub

    Private Sub InitiliazeLanguage()

        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_plan_faqs_lblHeading")
        Me.lblFAQs.Text = ResMgr.GetString("bizplanweb_services_plan_faqs_lblFAQs")


    End Sub


#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        'If GetProWebCustomer = True Then
        '    CurPage = 4
        '    CurItem = 0
        'Else
        '    CurPage = 3
        '    CurItem = 0
        'End If

        If GetProWebCustomer = True Then
            CurPage = 4
            CurItem = 0
        Else
            CurPage = 3
            CurItem = 0
        End If
    End Sub

End Class
