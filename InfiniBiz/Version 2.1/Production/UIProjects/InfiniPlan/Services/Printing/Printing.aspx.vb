Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Microsoft.Web.UI.WebControls

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class Printing
    ' Inherits System.Web.UI.Page
    Inherits PrintingBase
    Dim dtUserRigths As DataTable
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
 
    Dim redirectURL As String
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lnkPlanPreview As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkExportPlan As System.Web.UI.WebControls.HyperLink
    Protected WithEvents lnkPlanOutline As System.Web.UI.WebControls.HyperLink
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Dim daArray As Array, daArrayChild As Array, daSelectArray As Array
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Private Sub InitiliazeLanguage()
      
    End Sub
    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       

        lnkPlanPreview.Attributes.Add("onClick", "javascript:void(0);return GetFocus();")

        If Not IsNothing(Request.QueryString("printid")) And Not Page.IsPostBack Then
            CurPage = 3
            CurItem = CType(Request.QueryString("printid"), Integer)
            Select Case CurItem
                Case 0
                    '  lnkPlanPreview_Click(sender, e)
                    CurPage = 3
                    CurItem = 0
                    lnkPlanPreview.Enabled = True
                    lnkExportPlan.Enabled = True
                 
                    Exit Sub
                    redirectURL = Nothing '"/InfiniPlan/Services/PlanPreview/PlanPreview.htm"
                Case 1
                    redirectURL = "/InfiniPlan/Services/Preferences/PlanPreferences.aspx"
                    Response.Redirect(redirectURL)
                Case 2

                    redirectURL = "/InfiniPlan/Services/PlanOutLine/PlanOutLine.aspx"
                    Response.Redirect(redirectURL)
                Case 10
                    SetFocus()
                    redirectURL = Nothing
            End Select

        Else
            If Not Page.IsPostBack Then

                CurPage = 3
                CurItem = 0
            End If
        End If

        If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
            Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
            Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
        ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
            Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
            dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
        End If

    End Sub
    Private Sub Printoptions()
        'Print

        'Plan Preview
        Trace.Write("plan print modelid = 68 and modeloptionid=1")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=1 ")
        Trace.Write("plan print modelid = 68,1" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.lnkPlanPreview.Enabled = True
        Else
            Me.lnkPlanPreview.Enabled = False
        End If
        daArrayChild = Nothing

        'Export Plan
        Trace.Write("plan print modelid = 68 and modeloptionid=2")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=2 ")
        Trace.Write("plan print modelid = 68,2" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.lnkExportPlan.Enabled = True
        Else
            Me.lnkExportPlan.Enabled = False
        End If
        daArrayChild = Nothing

        '  Plan Outline
        Trace.Write("plan print modelid = 68 and modeloptionid=3")
        daArrayChild = dtUserRigths.Select("  Modelid  = 68 and modeloptionid=3 ")
        Trace.Write("plan print modelid = 68,3" + Str(daArrayChild.Length))
        If daArrayChild.Length > 0 Then
            Me.lnkPlanOutline.Enabled = True
        Else
            Me.lnkPlanOutline.Enabled = False
        End If
        daArrayChild = Nothing
        '/Print
    End Sub

    Private Sub SetFocus()
        Dim Script As New System.Text.StringBuilder

        With Script
            .Append("<script language='javascript'>")

            .Append("GetFocus();")
            .Append("</script>")
        End With
        RegisterStartupScript("setFocus", Script.ToString())
    End Sub


End Class
