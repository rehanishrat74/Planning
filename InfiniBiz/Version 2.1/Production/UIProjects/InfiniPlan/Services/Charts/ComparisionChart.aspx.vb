Imports System.Reflection
Imports System.io
Imports Infinilogic.BusinessPlan.Web
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports OWC11

Public Class ComparisionChart
    ' Inherits System.Web.UI.Page
    Inherits ChartsBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents txtHoldValues As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlChart As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblChartPeriods As System.Web.UI.WebControls.Label
    Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
    Protected WithEvents cboCharts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblPlanProducts As System.Web.UI.WebControls.Label
    Protected WithEvents cmbPlanProducts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents chHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button


    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()

        InitiliazeLanguage()
    End Sub

    Private Sub InitiliazeLanguage()
        Me.lblSelect.Text = ResMgr.GetString("bizplanweb_services_charts_chart_lblSelect")
        Me.btnBack.Text = ResMgr.GetString("bizplan_menu_tracker_Charts_btnBack")
    End Sub

#End Region

#Region ".................. Private Members"

    ' this is only used to kill the file , if it already exists with the same name.
    Dim tmpCurrentFileName As String = "Chart_" & GetCustomerID & "_" & Now.Millisecond & ".gif"
    ' Actual FileName used to create chart with 
    Public cchartFileName As String = "ClientCharts\" & tmpCurrentFileName
    Dim chartType As ChartChartTypeEnum = ChartChartTypeEnum.chChartTypeArea
    Dim chartID As Integer = 0
#End Region

#Region ".................. Event Hadlers "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If (File.Exists(Server.MapPath("./ClientCharts") & "\" & tmpCurrentFileName)) Then
            Kill(Server.MapPath("./ClientCharts") & "\" & tmpCurrentFileName)
        End If

        chHolder.Controls.Clear()
        lblMessage.Visible = False


        Session("ProductName") = ""
        PopulateProductDropDown()
        If Not txtHoldValues.Text = "" Then cmbPlanProducts.Items.FindByText(txtHoldValues.Text).Selected = True
        If cmbPlanProducts.Items.Count > 0 Then Session("ProductName") = cmbPlanProducts.SelectedItem.Text

        lblHeading.Text = CurrentPlan.PlanName

        PopulateChartPeriod()       '// insert text into lblchartperiods

        chartID = 12        '// fixed because this chart process is not related to other chart process

        RemoveFiles(Server.MapPath("./ClientCharts"))
        If Not CInt(cboCharts.SelectedItem.Value) < 0 Then
            chartType = CType(cboCharts.SelectedItem.Value, ChartChartTypeEnum)
        End If
        ProcessChart(cchartFileName, chartID, chartType)
        CurPage = 3
        CurItem = chartID
        navController = New PlanNavigator(Me, GetConnectionData, CurrentPlan, GetChartNameFromID(chartID, CurrentPlan))
    End Sub

    Private Sub cboCharts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (chartID > -1) Then
            Dim chartType As ChartChartTypeEnum
            chHolder.Controls.Clear()
            chartType = CType(cboCharts.SelectedItem.Value, ChartChartTypeEnum)
        End If
    End Sub

#End Region

#Region ".................. Private Helper MEthods "

    Private Function ProcessChart(ByVal chartFileName As String, ByVal chartID As Integer, ByVal chartType As ChartChartTypeEnum) As String
        pnlChart.Visible = True
        Dim assemName As String = "Infinilogic.BusinessPlan.BLLRules"
        Dim typeName As String = assemName & "." & Navigator(chartID) & "Chart"     '// get chart name like chart.vb
        Dim asmbly As [Assembly] = [Assembly].Load(assemName)
        Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)
        chartClass.GenerateChart(GetConnectionData, CurrentPlan, Server.MapPath(".") & "\" & chartFileName, chartType)
    End Function

    Private Sub RemoveFiles(ByVal strPath As String) '
        Dim di As DirectoryInfo = New DirectoryInfo(strPath)
        Dim fiArr As FileInfo() = di.GetFiles()
        Dim fi As FileInfo
        For Each fi In fiArr
            If (fi.Extension.ToString().ToLower = ".gif") Then
                ' if file is older than 2 minutes, we'll clean it up
                Dim min As New TimeSpan(0, 2, 0)
                If fi.CreationTime < DateTime.Now.Subtract(min) Then
                    fi.Delete()
                End If
            End If
        Next fi
    End Sub
    Private Sub PopulateProductDropDown()
        Dim chartValue As String()      '// hold values that come from tracker page
        Dim objPlan As Plan
        Dim dt As New DataTable


        chartValue = CType(HttpContext.Current.Session("CompChartValues"), String())

        If chartValue.Length > 0 Then

            If chartValue(5) = "Sales / Product" Then       '// check selected chart types
                cmbPlanProducts.Visible = True
                lblPlanProducts.Visible = True
                dt = objPlan.GetPlanProducts(GetConnectionData, CurrentPlan.PlanID)

                If dt.Rows.Count > 0 Then
                    cmbPlanProducts.Items.Clear()
                    For i As Integer = 0 To dt.Rows.Count - 1
                        '// fill selected product through db
                        cmbPlanProducts.Items.Add(New ListItem(dt.Rows(i).Item(3).ToString, CStr(i)))
                    Next
                End If

            Else
                cmbPlanProducts.Visible = False
                lblPlanProducts.Visible = False
            End If
        End If
    End Sub
    Private Sub PopulateChartPeriod()
        Dim chartValue As String()

        chartValue = CType(HttpContext.Current.Session("CompChartValues"), String())

        If chartValue.Length > 0 Then

            If chartValue(0) = "Annual Chart" Then
                lblChartPeriods.Text = chartValue(4) & " to " & chartValue(6)       '// set the xaxis value
            Else
                lblChartPeriods.Text = chartValue(3)
            End If
        End If
    End Sub
#End Region

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("/InfiniPlan/Services/Business Tracker/PlanTracker.aspx?NavigationD=1")
    End Sub
End Class
