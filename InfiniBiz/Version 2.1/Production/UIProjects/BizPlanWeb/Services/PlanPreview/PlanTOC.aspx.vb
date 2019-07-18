Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.BLL
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Web
Imports System.Reflection
Imports Owc11

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL

Public Class PlanTOC
    Inherits PlanPreviewBase
    '  Inherits BizPlanWebBase
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

#Region "............. Private Members "
    Private _textExporter As TextExporter
    Private _tablesExporter As TableExporter
    'Dim _chartExporter As WebChartExporter
    Private _PlanID As Integer
    Private _IncludeTables As Boolean
    Private _IncludeCharts As Boolean
    '    ' Exporter Objects 
    Private dsAllTables As DataSet
    Private ChartingScript As String
    'Protected WithEvents leftBar As New Infinilogic.BusinessPlan.Web.LeftBar
#End Region

#Region "................... Private Methods "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Dim PlanEx As New PlanExporter(GetConnectionData, CurrentPlan)

        _IncludeTables = True
        _IncludeCharts = True
        'tblMain.Rows(0).Cells(0).InnerHtml = ExportPlanInHTML()
        'Response.Write(ExportTOCInHTML())
        Response.Write(PlanEx.GetPlanTOCHTML())
    End Sub

    Private Function GetPageBeginingHTML(ByVal PlanName As String) As String
        Dim HTML As String
        HTML = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>"
        HTML += "<html><head><BASE target='main'><title>" & PlanName & "</title><LINK REL=stylesheet Type='text/css' HREF='PlanPreview.css'><LINK href='../../Library/Styles/MainStyle.css' type='text/css' rel='stylesheet'></head>"
        HTML += "<body>"
        Return HTML
    End Function

    Private Function GetPageEndingHTML() As String
        Return "</body></html>"
    End Function

    Private Function GetInstructionsHTML() As String
        Return "<p class='lblNote' align=center>If you cannot view the charts <a href='http://www.microsoft.com/downloads/details.aspx?familyid=7287252C-402E-4F72-97A5-E0FD290D4B76&displaylang=en' target='_blank'><font color='#0000FF'>click here</font></a> to download MS Office Web Components 11.</p>"
    End Function

    Private Function ExportTOCInHTML() As String
        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 0")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan"))
        sb.Append(GetInstructionsHTML())

        PrepareTOC(headingRows, headingsTable, sb)

        sb.Append(GetPageEndingHTML())

        Return sb.ToString
    End Function

    Private Function GetTOCHTML(ByVal dt As DataTable) As String
        Dim HTML As String
        Dim Row As DataRow
        Dim Column As DataColumn

        HTML = "<P><table width='200' align='left' border='0'>"
        HTML += "<tr>"
        If Not dt.Columns(0).ColumnName = "ID" Then
            HTML += "<th class='OutlineHeader' height='30' valign='top'>" & dt.Columns(0).Caption & "</th>"
        End If
        HTML += "</tr>"

        HTML += "<tr>"
        If Not dt.Columns(0).ColumnName = "ID" Then
            HTML += "<td nowrap><a class='leftlink' href='/InfiniPlan/Services/PlanPreview/PlanContents.aspx?pageID=0'>Cover Page</a></td>"
        End If
        HTML += "</tr>"

        HTML += "<tr>"
        If Not dt.Columns(0).ColumnName = "ID" Then
            HTML += "<td nowrap><a class='leftlink' href='/InfiniPlan/Services/PlanPreview/PlanContents.aspx?pageID=1'>Legal Page</a></td>"
        End If
        HTML += "</tr>"

        For Each Row In dt.Rows
            HTML += "<tr>"
            If Not dt.Columns(0).ColumnName = "ID" Then
                HTML += "<td nowrap>" & CStr(Row(dt.Columns(0))) & "</td>"
            End If
            HTML += "</tr>"
        Next
        HTML += "</table></P>"
        Return HTML
    End Function

    Private Sub PrepareTOC(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)

        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim tblTOC As New DataTable
        Dim rowTOC As DataRow

        tblTOC.Columns.Add("P l a n &nbsp;&nbsp;&nbsp; O u t l i n e")
        tblTOC.Columns.Add("Page No")

        'For each row in the headings table append numbering order
        'and also create a table for the TOC
        For Each dr In headingRows
            headingNo += 1

            If (CInt(dr("HeadingType")) = 0) Then
                'Append the numbering
                rowTOC = tblTOC.NewRow()
                rowTOC.Item(0) = "<a class='leftlink' href='/InfiniPlan/Services/PlanPreview/PlanContents.aspx#" & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "'>" & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "</a>"
                rowTOC.Item("Page No") = ""
                tblTOC.Rows.Add(rowTOC)

                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PrepareTOC(children, headingsTable, sb, 1, headingNo & ".", tblTOC)
                End If
            End If

        Next

        sb.Append(GetTOCHTML(tblTOC))
        sb.Append("<br>")

    End Sub

    Private Function PrepareTOC(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String, ByVal tblTOC As DataTable) As Integer
        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim rowTOC As DataRow
        Dim leadingSpaces As String = ""

        'For each row in the headings table append numnering order
        'and also create a table for the TOC
        Dim i As Integer
        For i = 0 To nestingLevel
            leadingSpaces = leadingSpaces & "&nbsp;&nbsp;"
        Next

        For Each dr In headingRows
            headingNo += 1

            rowTOC = tblTOC.NewRow()
            rowTOC.Item(0) = leadingSpaces & "<a class='leftlink' href='/InfiniPlan/Services/PlanPreview/PlanContents.aspx#" & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "'>" & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "</a>"
            rowTOC.Item("Page No") = ""
            tblTOC.Rows.Add(rowTOC)

            If (CInt(dr("HeadingType")) = 0) Then
                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PrepareTOC(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".", tblTOC)
                End If
            End If
        Next
        Return nestingLevel - 1
    End Function
#End Region

    Private Sub PlanTOC_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Response.Flush()
        Response.Close()
    End Sub

End Class
