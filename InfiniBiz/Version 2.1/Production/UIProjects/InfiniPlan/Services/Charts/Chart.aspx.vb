
Imports System.Reflection
Imports System.io
Imports Infinilogic.BusinessPlan.Web
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports OWC11

Public Class Chart
    Inherits ChartsBase
    ' Inherits System.Web.UI.Page

    Dim dtUserRigths As DataTable


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents cboCharts As System.Web.UI.WebControls.DropDownList
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlChart As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMessage As System.Web.UI.WebControls.Label
    Protected WithEvents chHolder As System.Web.UI.WebControls.PlaceHolder
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents tblcontents As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lblSelect As System.Web.UI.WebControls.Label
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
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
        Me.lblHeading.Text = ResMgr.GetString("bizplanweb_services_charts_chart_lblHeading")
        Me.lblSelect.Text = ResMgr.GetString("bizplanweb_services_charts_chart_lblSelect")

    End Sub

#End Region

#Region ".................. Private Members"

    ' this is only used to kill the file , if it already exists with the same name.
    Dim tmpCurrentFileName As String = "Chart_" & GetCustomerID & "_" & Now.Millisecond & ".gif"
    ' Actual FileName used to create chart with 
    Public chartFileName As String = "ClientCharts\" & tmpCurrentFileName
    Dim chartType As ChartChartTypeEnum = ChartChartTypeEnum.chChartTypeArea
    Dim chartID As Integer = -1

#End Region

#Region ".................. Event Hadlers "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

         If (File.Exists(Server.MapPath("./ClientCharts") & "\" & tmpCurrentFileName)) Then
            Kill(Server.MapPath("./ClientCharts") & "\" & tmpCurrentFileName)
        End If

        chHolder.Controls.Clear()
        lblMessage.Visible = False

        If Not IsNothing(Request.QueryString("chartID")) Then
            chartID = CInt(Request.QueryString("chartID"))
            Session("LinkChart") = chartID
        Else
            If IsNothing(Session("LinkChart")) Then
                ''chartID = 0
                ''' Nisr Addition 
                If Not Session("merchantProUserID") Is Nothing Then
                    chartID = RetunrChartId()
                Else
                    chartID = 0
                End If
                '''' end
            Else
            chartID = CType(Session("LinkChart"), Integer)
            End If
        End If

        tblcontents.Visible = False
        RemoveFiles(Server.MapPath("./ClientCharts"))
        If Not CInt(cboCharts.SelectedItem.Value) < 0 Then
            chartType = CType(cboCharts.SelectedItem.Value, ChartChartTypeEnum)
        End If
        ProcessChart(chartFileName, chartID, chartType)
        CurPage = 2
        CurItem = chartID
        navController = New PlanNavigator(Me, GetConnectionData, CurrentPlan, GetChartNameFromID(chartID, CurrentPlan))

    End Sub
    Public Function RetunrChartId() As Integer
        Dim iRetrun As Integer
        Dim i As Integer
        Dim expression As String = System.String.Empty
        Dim dr() As DataRow
        dtUserRigths = TextOperations.GetPlanRights(GetConnectionData, CType(Session("merchantProUserID"), String), False)
        dr = dtUserRigths.Select("  Modelid  = 66")
        iRetrun = Convert.ToInt16(dr(0)("ModelOptionId"))
        Return iRetrun - 1
    End Function
    Private Sub cboCharts_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (chartID > -1) Then
            Dim chartType As ChartChartTypeEnum
            chHolder.Controls.Clear()
            chartType = CType(cboCharts.SelectedItem.Value, ChartChartTypeEnum)
            'ProcessChart(chartFileName, chartID, chartType)
            'imgChart.ImageUrl = Server.MapPath(".") & "\" & chartFileName

            'Dim strImageTag As String = "<Img src='./" & chartFileName & "' />"

            ' Put the img control in Chart Place Holder 
            'chHolder.Controls.Add(New LiteralControl(strImageTag))

            'imgChart.ImageUrl = "./" & chartFileName

        End If
    End Sub

#End Region

#Region ".................. Private Helper MEthods "

    Private Function ProcessChart(ByVal chartFileName As String, ByVal chartID As Integer, ByVal chartType As ChartChartTypeEnum) As String
        'Try
        pnlChart.Visible = True
        Dim assemName As String = "Infinilogic.BusinessPlan.BLLRules"
        Dim typeName As String = assemName & "." & Navigator(chartID) & "Chart"
        'Dim typeName As String = assemName & "." & [Enum].GetName(GetType(BusinessPlanChartType), chartID) & "Chart"
        Dim asmbly As [Assembly] = [Assembly].Load(assemName)
        Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)
        chartClass.GenerateChart(GetConnectionData, CurrentPlan, Server.MapPath(".") & "\" & chartFileName, chartType)
        'Catch ex As Exception
        '    lblMessage.Text = "The " & cboCharts.SelectedItem.Text & " Chart type is not Supported for " & [Enum].GetName(GetType(BusinessPlanChartType), chartID) & "."
        '    lblMessage.ForeColor = Color.Red
        '    lblMessage.Visible = True

        'End Try
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
    End Sub 'RemoveFiles

#End Region

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim url As String = navController.MoveBackward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim url As String = navController.MoveForward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub
End Class
