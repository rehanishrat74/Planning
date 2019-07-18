Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Public Class print
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Protected WithEvents pnlPrint As System.Web.UI.WebControls.Panel
    Protected WithEvents hypMyDocuments As System.Web.UI.WebControls.HyperLink
    Protected WithEvents ibtnPrintDetail As System.Web.UI.WebControls.ImageButton
    Protected WithEvents hypPlanPreview As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypExportPlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypPlanoutline As System.Web.UI.WebControls.HyperLink

    Protected WithEvents Hyperlink1 As System.Web.UI.WebControls.HyperLink
    Protected WithEvents PnlPrintDetail As System.Web.UI.WebControls.Panel
    Dim daArray As Array, daArrayChild As Array, daSelectArray As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

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
        Try
            Trace.Write("print start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            PrintPlan()
            MyDocument()
          
 

        Catch ex As Exception
            Trace.Warn("print start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

    End Sub

    Private Sub PrintPlan()

        'Select
        Trace.Write("select modelid = 61 ")
        daSelectArray = dtUserRigths.Select("  Modelid  = 61 ")
        Trace.Write("Select" + Str(daSelectArray.Length))
        If daSelectArray.Length > 0 Then
            Me.ibtnPrintDetail.Enabled = True
            'Print
            Trace.Write("print modelid = 68 ")
            daArray = dtUserRigths.Select("  Modelid  = 68 ")
            Trace.Write("print" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.ibtnPrintDetail.Enabled = True

                Printoptions()
            Else
                Me.ibtnPrintDetail.Enabled = False
            End If
            daArray = Nothing
        Else
            Me.ibtnPrintDetail.Enabled = False

        End If
        daSelectArray = Nothing
    End Sub

    Private Sub Printoptions()
        'Print

        'Plan Preview
        Trace.Write("plan print modelid = 68 and modeloptionid=1")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=1 ")
        Trace.Write("plan print modelid = 68,1" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypPlanPreview.Enabled = True
        Else
            Me.hypPlanPreview.Enabled = False
        End If
        daArrayChild = Nothing

        'Export Plan
        Trace.Write("plan print modelid = 68 and modeloptionid=2")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=2 ")
        Trace.Write("plan print modelid = 68,2" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypExportPlan.Enabled = True
        Else
            Me.hypExportPlan.Enabled = False
        End If
        daArrayChild = Nothing

        '  Plan Outline
        Trace.Write("plan print modelid = 68 and modeloptionid=3")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=3 ")
        Trace.Write("plan print modelid = 68,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.hypPlanoutline.Enabled = True
        Else
            Me.hypPlanoutline.Enabled = False
        End If
        daArrayChild = Nothing
        '/Print
    End Sub

    Private Sub MyDocument()
        'My doc
        Trace.Write("My doc modelid = 62  ")
        daArray = dtUserRigths.Select("  Modelid  = 62 ")
        Trace.Write("My doc " + Str(daArray.Length))
        If daArray.Length > 0 Then
            Me.hypMyDocuments.Enabled = True
        Else
            Me.hypMyDocuments.Enabled = False
        End If
        daArray = Nothing
    End Sub

    Private Sub ibtnPrintDetail_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnPrintDetail.Click

        Try
            If CurrentPlan.PlanID = Nothing Then
                Response.Redirect("../Plan/PlanManager.aspx")
            End If
        Catch ex As Exception
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try
        Me.pnlPrint.Visible = False
        Me.PnlPrintDetail.Visible = True

    End Sub



    Private Sub pnlPrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnlPrint.Load

        'Print

        ' 
        Trace.Write("plan print modelid = 68 and (modeloptionid=1,2,3)")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and (modeloptionid=1 or modeloptionid=2 or modeloptionid=3) ")
        Trace.Write("plan print modelid = 68,1,2,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.PnlPrintDetail.Enabled = True
        Else
            Me.PnlPrintDetail.Enabled = False
        End If
        daArrayChild = Nothing
    End Sub
End Class
