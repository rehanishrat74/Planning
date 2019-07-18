Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports InfiniLogic.AccountsCentre.BLL.PageBase
Imports System.Drawing

Public Class Planing
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page
    Dim dtUserRigths As DataTable
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents imgSamplePlan As System.Web.UI.WebControls.ImageButton
    Dim daArray As Array
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Table1 As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents imgCreate As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgSelect As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgMeterManager As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgPrint As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgBusinessTracker As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgMeterWizard As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgClose As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgMyDoc As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgText As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgTable As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgChart As System.Web.UI.WebControls.ImageButton
    Protected WithEvents imgWizard As System.Web.UI.WebControls.ImageButton

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



        Try
            Trace.Write("Planning start page")
   
            If InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee AndAlso (Not Session("merchantProUserID") Is Nothing) Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                Trace.Write("Session( merchantProUserID ) " + CStr(Session("merchantProUserID")))

                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
            ElseIf Not InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee Then
                Trace.Write("InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee " + CStr(InfiniLogic.AccountsCentre.BLL.PageBase.isEmployee))
                dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), True)
            End If

            'Create 
            daArray = dtUserRigths.Select("  Modelid  = 59 ")
            Trace.Write("create" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgCreate.ImageUrl = "/images/InfiniPlan/MainPage/CreatePlan.jpg"
                imgCreate.Enabled = True
            Else
                imgCreate.ImageUrl = "/images/InfiniPlan/MainPage/CreatePlan_grey.jpg"
                imgCreate.Enabled = False
            End If
            daArray = Nothing

            'Select
            daArray = dtUserRigths.Select("  Modelid  = 61 ")
            Trace.Write("Select" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgSelect.ImageUrl = "/images/InfiniPlan/MainPage/SelectPlan.jpg"
                imgSelect.Enabled = True
            Else
                imgSelect.ImageUrl = "/images/InfiniPlan/MainPage/SelectPlan_grey.jpg"
                imgSelect.Enabled = False
            End If
            daArray = Nothing

            'Doc
            daArray = dtUserRigths.Select("  Modelid  = 62 ")
            Trace.Write("Document" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgMyDoc.ImageUrl = "/images/InfiniPlan/MainPage/MyDocuments.jpg"
                imgMyDoc.Enabled = True
            Else
                imgMyDoc.ImageUrl = "/images/InfiniPlan/MainPage/MyDocuments_grey.jpg"
                imgMyDoc.Enabled = False
            End If
            daArray = Nothing


            'Spd Manager
            daArray = dtUserRigths.Select("  Modelid  =63  ")
            Trace.Write("Speedoemter" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgMeterManager.ImageUrl = "/images/InfiniPlan/MainPage/Speedometer.jpg"
                imgMeterManager.Enabled = True
            Else
                imgMeterManager.ImageUrl = "/images/InfiniPlan/MainPage/Speedometer_grey.jpg"
                imgMeterManager.Enabled = False
            End If

            'Spd Manager
            daArray = dtUserRigths.Select("  Modelid  = 159  ")
            Trace.Write("Sample Plan" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgSamplePlan.ImageUrl = "/images/InfiniPlan/MainPage/Sample_Plan.jpg"
                imgSamplePlan.Enabled = True
            Else
                imgSamplePlan.ImageUrl = "/images/InfiniPlan/MainPage/Sample_Plan.jpg"
                imgSamplePlan.Enabled = False
            End If

            'Text
            daArray = dtUserRigths.Select("  Modelid  =65 ")
            Trace.Write("Text" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgText.ImageUrl = "/images/InfiniPlan/MainPage/Text.jpg"
                imgText.Enabled = True
            Else
                imgText.ImageUrl = "/images/InfiniPlan/MainPage/Text_grey.jpg"
                imgText.Enabled = False
            End If

            'Table
            daArray = dtUserRigths.Select("  Modelid  =66 ")
            Trace.Write("table" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgTable.ImageUrl = "/images/InfiniPlan/MainPage/Tables.jpg"
                imgTable.Enabled = True
            Else
                imgTable.ImageUrl = "/images/InfiniPlan/MainPage/Tables_grey.jpg"
                imgTable.Enabled = False
            End If

            'Chart
            daArray = dtUserRigths.Select("  Modelid  =67 ")
            Trace.Write("chart" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgChart.ImageUrl = "/images/InfiniPlan/MainPage/Charts.jpg"
                imgChart.Enabled = True
            Else
                imgChart.ImageUrl = "/images/InfiniPlan/MainPage/Charts_gray.jpg"
                imgChart.Enabled = False
            End If


            'Print
            daArray = dtUserRigths.Select("  Modelid  =68 ")
            Trace.Write("print" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgPrint.ImageUrl = "/images/InfiniPlan/MainPage/Printer.jpg"
                imgPrint.Enabled = True
            Else
                imgPrint.ImageUrl = "/images/InfiniPlan/MainPage/Printer_grey.jpg"
                imgPrint.Enabled = False
            End If


            'Wizard
            daArray = dtUserRigths.Select("  Modelid  =69 ")
            Trace.Write("wizard" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgWizard.ImageUrl = "/images/InfiniPlan/MainPage/PlanWizard.jpg"
                imgWizard.Enabled = True
            Else
                imgWizard.ImageUrl = "/images/InfiniPlan/MainPage/PlanWizard_grey.jpg"
                imgWizard.Enabled = False
            End If


            'Tracker
            daArray = dtUserRigths.Select("  Modelid  =70 ")
            Trace.Write("Tracker" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgBusinessTracker.ImageUrl = "/images/InfiniPlan/MainPage/BusinessTrakker.jpg"
                imgBusinessTracker.Enabled = True
            Else
                imgBusinessTracker.ImageUrl = "/images/InfiniPlan/MainPage/BusinessTrakker_grey.jpg"
                imgBusinessTracker.Enabled = False
            End If


            'Meter Wizard
            daArray = dtUserRigths.Select("  Modelid  =144 ")
            Trace.Write("Meter Wizard" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgMeterWizard.ImageUrl = "/images/InfiniPlan/MainPage/MeterWizard.jpg"
                imgMeterWizard.Enabled = True
            Else
                imgMeterWizard.ImageUrl = "/images/InfiniPlan/MainPage/MeterWizard_grey.jpg"
                imgMeterWizard.Enabled = False
            End If


            'Close Plan
            daArray = dtUserRigths.Select("  Modelid  =148 ")
            Trace.Write("Close" + Str(daArray.Length))
            If daArray.Length > 0 Then
                imgClose.ImageUrl = "/images/InfiniPlan/MainPage/ClosePlan.jpg"
                imgClose.Enabled = True
            Else
                imgClose.ImageUrl = "/images/InfiniPlan/MainPage/ClosePlan_grey.jpg"
                imgClose.Enabled = False
            End If




            Trace.Write("Planning start page end ")
        Catch ex As Exception
            Trace.Warn("Planning start page" + ex.Message)
        End Try
    End Sub
 

    Private Sub imgCreate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCreate.Click

        Response.Redirect("/InfiniPlan/Services/Plan/CreatePlan.aspx")
    End Sub

    Private Sub imgSelect_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSelect.Click
        Response.Redirect("/InfiniPlan/Services/Plan/PlanManager.aspx")
    End Sub

    Private Sub imgMyDoc_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMyDoc.Click
        Response.Redirect("/InfiniPlan/Services/Plan/ExportedPlans.aspx")
    End Sub

    Private Sub imgMeterManager_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMeterManager.Click
        Response.Redirect("/InfiniPlan/Services/Plan/SpeedometerManager.aspx")
    End Sub

    Private Sub imgText_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgText.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=0")
    End Sub

    Private Sub imgTable_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgTable.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=1")
    End Sub

    Private Sub imgChart_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgChart.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=2")
    End Sub

    Private Sub imgPrint_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgPrint.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=3")
    End Sub

    Private Sub imgWizard_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgWizard.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=4")
    End Sub

    Private Sub imgBusinessTracker_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBusinessTracker.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=5")
    End Sub

    Private Sub imgMeterWizard_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgMeterWizard.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=6")
    End Sub

    Private Sub imgClose_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgClose.Click
        Response.Redirect("/InfiniPlan/Services/welcome.aspx?cmd=7")
    End Sub

    Private Sub imgSamplePlan_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgSamplePlan.Click
        Response.Redirect("/InfiniPlan/Services/Plan/SamplePlan.aspx")
    End Sub
End Class
