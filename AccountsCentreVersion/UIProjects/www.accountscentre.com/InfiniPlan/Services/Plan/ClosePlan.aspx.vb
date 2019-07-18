Imports Infinilogic.BusinessPlan.Web.Common

Public Class ClosePlan
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page

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
        'Put user code to initialize the page here

        BusinessPlanSummary = Nothing
        Session("LinkTable") = Nothing
        Session("LinkChart") = Nothing
        Session("clipval") = Nothing
        Session("STG") = Nothing
        Session("selectedval") = Nothing

        Session("SelectIndex") = Nothing
        Session("List") = Nothing
        Session("QID") = Nothing
        Session("bit") = Nothing
        Session("optionbit") = Nothing
        Session("Setclip") = Nothing
        Session("singleproduct") = Nothing

        Session("LoadList") = Nothing

        Session("ds") = Nothing
        Session("MID") = Nothing
        Session("MName") = Nothing
        Session("FLAnalysisid") = Nothing
        Response.Redirect("/InfiniPlan/Services/Plan/Home.aspx")
       
    End Sub

End Class
