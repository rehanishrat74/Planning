Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase

Public Class ProductsServicesSummary
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents hypProductServices As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypProductServicesDescription As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypcompetitive As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypfuture As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("ProductsServicesSummary start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Company summary 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 11")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =11 ")
            Trace.Write("Text  Modelid  = 65 ,11 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypProductServices.Enabled = True
            Else
                Me.hypProductServices.Enabled = False
            End If
            daArray = Nothing


            'Company Ownership 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 12 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 12 ")
            Trace.Write("Text  Modelid  = 65 ,12 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypProductServicesDescription.Enabled = True
            Else
                Me.hypProductServicesDescription.Enabled = False
            End If
            daArray = Nothing


            'Company History 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 13 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =13")
            Trace.Write("Text  Modelid  = 65 ,13 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypcompetitive.Enabled = True
            Else
                Me.hypcompetitive.Enabled = False
            End If
            daArray = Nothing


            'Company Location & Facilities 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 14 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 14")
            Trace.Write("Text  Modelid  = 65 ,14 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypfuture.Enabled = True
            Else
                Me.hypfuture.Enabled = False
            End If
            daArray = Nothing


            Trace.Write("ProductsServicesSummary start page")


        Catch ex As Exception
            Trace.Warn("ProductsServicesSummary start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

    End Sub

End Class
