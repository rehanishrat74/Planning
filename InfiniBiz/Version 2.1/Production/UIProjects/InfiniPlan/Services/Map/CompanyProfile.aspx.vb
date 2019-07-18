Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase


Public Class CompanyProfile
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim dtUserRigths As DataTable
    Dim daArray As Array
    Protected WithEvents hypCompanySummary As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypcompanyownership As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypcompnayhistory As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hypCompanyLocationFacilities As System.Web.UI.WebControls.HyperLink

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
            Trace.Write("CompanyProfile start page")

            If Infinilogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not Infinilogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(Infinilogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Company summary 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 7")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =7 ")
            Trace.Write("Text  Modelid  = 65 ,7 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypCompanySummary.Enabled = True
            Else
                Me.hypCompanySummary.Enabled = False
            End If
            daArray = Nothing


            'Company Ownership 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 8 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 8 ")
            Trace.Write("Text  Modelid  = 65 ,8 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypcompanyownership.Enabled = True
            Else
                Me.hypcompanyownership.Enabled = False
            End If
            daArray = Nothing


            'Company History 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 9 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid =9")
            Trace.Write("Text  Modelid  = 65 ,9 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypcompnayhistory.Enabled = True
            Else
                Me.hypcompnayhistory.Enabled = False
            End If
            daArray = Nothing


            'Company Location & Facilities 
            Trace.Write("Text  Modelid  = 65 and modeloptionid = 10 ")
            daArray = dtUserRigths.Select("  Modelid  = 65 and modeloptionid = 10")
            Trace.Write("Text  Modelid  = 65 ,10 :" + Str(daArray.Length))
            If daArray.Length > 0 Then
                Me.hypCompanyLocationFacilities.Enabled = True
            Else
                Me.hypCompanyLocationFacilities.Enabled = False
            End If
            daArray = Nothing

 
            Trace.Write("CompanyProfile start page")


        Catch ex As Exception
            Trace.Warn("CompanyProfile start page" + ex.Message)
            Response.Redirect("../Plan/PlanManager.aspx")
        End Try

    End Sub

End Class
