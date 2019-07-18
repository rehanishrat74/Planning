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

Public Class PlanContents
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

        If Not Request.QueryString("pageID") Is Nothing Then
            If CInt(Request.QueryString("pageID")) = 0 Then
                'Response.Write(PrepareCoverRTF())
                Response.Write(PlanEx.GetCoverHTML())
            ElseIf CInt(Request.QueryString("pageID")) = 1 Then
                'Response.Write(PrepareLegalHtml())
                Response.Write(PlanEx.GetLegalHtml())
            Else
                _IncludeTables = True
                _IncludeCharts = True
                'tblMain.Rows(0).Cells(0).InnerHtml = ExportPlanInHTML()
                'Response.Write(ExportPlanInHTML())
                Response.Write(PlanEx.GetPlanContentsHTML())
            End If
        Else
            _IncludeTables = True
            _IncludeCharts = True
            'tblMain.Rows(0).Cells(0).InnerHtml = ExportPlanInHTML()
            'Response.Write(ExportPlanInHTML())
            Response.Write(PlanEx.GetPlanContentsHTML())
        End If
    End Sub

    Private Function GetPageBeginingHTML(ByVal PlanName As String) As String
        Dim HTML As String
        HTML = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>"
        HTML += "<html><head><title>" & PlanName & "</title><LINK REL=stylesheet Type='text/css' HREF='PlanPreview.css'><script language='vbscript' src='../../Library/Scripts/ClientSideCharting.vbs'></script></head>"
        HTML += "<body>"
        Return HTML
    End Function

    Private Function GetPageEndingHTML() As String
        Return "</body></html>"
    End Function

    Private Function ExportPlanInHTML() As String
        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_0'")

        ChartingScript = "<script language='vbscript'>" & vbCrLf
        ChartingScript += "Sub Window_onLoad()" & vbCrLf

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan"))

        PrepareRTFs(headingRows, headingsTable, sb)

        ChartingScript += "End Sub" & vbCrLf
        'ChartingScript += "Sub DrawChart(xmlDoc, chartSpace)" & vbCrLf
        'ChartingScript += "chartSpace.XMLData = xmlDoc.xml" & vbCrLf
        'ChartingScript += "End Sub" & vbCrLf
        ChartingScript += "</script>" & vbCrLf

        If _IncludeCharts Then sb.Append(ChartingScript)

        sb.Append(GetPageEndingHTML())

        Return sb.ToString
    End Function

    Private Function GetChartHTML(ByVal ChartName As String) As String
        Dim ChartHTML As String
        Dim ChartID As Integer = ChartsBase.GetChartID(ChartName)
        'Dim XMLData As String
        'Dim Chart As IChartGenerator = ProcessChart(ChartName, ChartChartTypeEnum.chChartTypeLine, XMLData)
        AddChartToScript(ChartName)
        'ChartHTML = "<P align='center'><object classid='clsid:0002E530-0000-0000-C000-000000000046' id='" & ChartName & "Source'></object>"
        'ChartHTML += "<OBJECT classid='clsid:0002E500-0000-0000-C000-000000000046' height=384 id='" & ChartName & "' style='HEIGHT: 75%; WIDTH: 80%' width=576 Caption='" & ChartName & "' Type='" & CInt(Chart.ChartType) & "'></OBJECT>" 'Caption='" & ChartName & " '"' Type='" & Type & 
        ChartHTML = "<P align='center'><xml id='" & ChartName & "Source' src='../Charts/GetChartXML.aspx?chartID=" & ChartID & "'></xml> "
        ChartHTML += "<OBJECT classid='clsid:0002E55D-0000-0000-C000-000000000046' height=384 id='" & ChartName & "' style='HEIGHT: 75%; WIDTH: 80%' width=576 Caption='" & ChartName & "' Type='" & CInt(ChartChartTypeEnum.chChartTypeLine) & "'></OBJECT>" 'Caption='" & ChartName & " '"' Type='" & Type & 
        ChartHTML += "</P>"
        Return ChartHTML
    End Function

    Private Function ProcessChart(ByVal ChartName As String, ByVal chartType As ChartChartTypeEnum, ByRef XMLData As String) As IChartGenerator
        Dim assemName As String = "Infinilogic.BusinessPlan.BLLRules"
        Dim typeName As String = assemName & "." & ChartName & "Chart"
        'Dim typeName As String = assemName & "." & [Enum].GetName(GetType(BusinessPlanChartType), chartID) & "Chart"
        Dim asmbly As [Assembly] = [Assembly].Load(assemName)
        Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)
        'XMLData = chartClass.GetChartXML2(GetConnectionData, CurrentPlan, chartType)
        Return chartClass  '.GetChartXML(GetConnectionData, CurrentPlan)
    End Function

    Private Sub AddChartToScript(ByVal ChartName As String)
        ChartingScript += "DrawChart " & ChartName & "Source, " & ChartName & vbCrLf
        'Dim ChartID As Integer = ChartsBase.GetChartID(ChartName) ' CInt(CType([Enum].Parse(GetType(BusinessPlanChartType), ChartName), BusinessPlanChartType))
        'ChartingScript += "DSCInit " & ChartName & "Source, " & ChartID.ToString & vbCrLf
        'ChartingScript += "DrawChart " & ChartName & ", " & ChartName & "Source" & vbCrLf
    End Sub

    Private Function GetHTML(ByVal dt As DataTable) As String
        Dim HTML As String
        Dim Row As DataRow
        Dim Column As DataColumn

        HTML = "<P><table width='80%' align='center' border='1' cellspacing=0 celllpading=1>"
        HTML += "<tr>"
        For Each Column In dt.Columns
            If Not Column.ColumnName = "ID" Then
                HTML += "<th>" & Column.Caption & "</th>"
            End If
        Next
        HTML += "</tr>"

        For Each Row In dt.Rows
            HTML += "<tr>"
            For Each Column In dt.Columns
                If Not Column.ColumnName = "ID" Then
                    HTML += "<td>" & CStr(Row(Column)) & "</td>"
                End If
            Next
            HTML += "</tr>"
        Next
        HTML += "</table></P>"
        Return HTML
    End Function

    Private Sub PrepareRTFs(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        If (dsAllTables Is Nothing) Then
            dsAllTables = TextExporter.GetPlanTables(GetConnectionData, CurrentPlan, True)
        End If

        Dim dr As DataRow
        Dim headingNo As Integer = 0
        For Each dr In headingRows
            headingNo += 1

            ' Print the first Heading and its text 
            ' Then see if it has Subheadings , if so , recursively Print them too.
            Dim heading As String = CStr(dr("HeadingName"))
            Dim htmlString As String
            Dim rtfString As String
            Dim headingText As String
            Try
                ' Check if some heading makes an incident, catch it 
                If (CInt(dr("HeadingType")) = 0) Then
                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
                    heading = "<a name='" & headingNo.ToString() & ". " & heading & "'><h2> " & headingNo.ToString() & ". " & heading & "</h2></a>"
                    htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(dr("HeadingID")))
                    ' Add them to the StringBuilder 
                    sb.Append(heading)
                    sb.Append(htmlString)
                ElseIf (CInt(dr("HeadingType")) = 1 And _IncludeTables) Then   'And _includeTables = True
                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
                    heading = "<a name='" & headingNo.ToString() & ". " & heading & "'><h2> " & headingNo.ToString() & ". " & "Table: " & heading & "</h2></a>"
                    ' If it is a Table 
                    Dim tableName As String = CStr(dr("HeadingName"))
                    tableName = Trim(tableName.Substring(tableName.IndexOf(":") + 1))

                    Dim spaceIndex As Integer = tableName.IndexOf(" ")
                    While (spaceIndex > -1)
                        tableName = tableName.Remove(spaceIndex, 1)
                        spaceIndex = tableName.IndexOf(" ")
                    End While
                    Dim dt As DataTable = dsAllTables.Tables(tableName)
                    If Not (dt Is Nothing) Then
                        sb.Append(heading)
                        sb.Append(GetHTML(dt))
                    End If
                ElseIf (CInt(dr("HeadingType")) = 2 And _IncludeCharts) Then    'And _includeCharts = True
                    heading = "<a name='" & headingNo.ToString() & ". " & heading & "'><h2> " & headingNo.ToString() & ". " & "Chart: " & heading & "</h2></a>"
                    Dim chartName As String = CStr(dr("HeadingName"))
                    chartName = chartName.Replace(" ", "")
                    sb.Append(heading)
                    sb.Append(GetChartHTML(chartName))
                End If
            Catch ex As Exception
                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
            End Try

            If (CInt(dr("HeadingType")) = 0) Then
                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PrepareRTFs(children, headingsTable, sb, 1, headingNo & ".")
                End If
            End If
        Next
    End Sub

    Private Function PrepareRTFs(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String) As Integer
        If (dsAllTables Is Nothing) Then
            dsAllTables = TextExporter.GetPlanTables(GetConnectionData, CurrentPlan, True)
        End If

        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim headingTagStart As String
        Dim headingTagEnd As String

        For Each dr In headingRows
            headingNo += 1
            If nestingLevel = 1 Then
                headingTagStart = "<h3> "
                headingTagEnd = "</h3>"
            Else
                headingTagStart = "<h3> "
                headingTagEnd = "</h3>"
            End If

            ' Print the first Heading and its text 
            ' Then see if it has Subheadings , if so , recursively Print them too.
            Dim heading As String = CStr(dr("HeadingName"))
            Dim htmlString As String
            Dim rtfString As String
            Dim headingText As String
            Try
                ' Check if some heading makes an incident, catch it 
                If (CInt(dr("HeadingType")) = 0) Then
                    heading = "<a name='" & headingPrefix & headingNo.ToString() & ". " & heading & "'>" & headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd & "</a>"
                    htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(dr("HeadingID")))
                    ' Add them to the StringBuilder 
                    sb.Append(heading)
                    sb.Append(htmlString)
                ElseIf (CInt(dr("HeadingType")) = 1 And _IncludeTables = True) Then   'And _includeTables = True
                    heading = "<a name='" & headingPrefix & headingNo.ToString() & ". " & heading & "'>" & headingTagStart & headingPrefix & headingNo.ToString() & ". " & " Table: " & heading & headingTagEnd & "</a>"
                    Dim tableName As String = CStr(dr("HeadingName"))
                    tableName = Trim(tableName.Substring(tableName.IndexOf(":") + 1))

                    Dim spaceIndex As Integer = tableName.IndexOf(" ")
                    While (spaceIndex > -1)
                        tableName = tableName.Remove(spaceIndex, 1)
                        spaceIndex = tableName.IndexOf(" ")
                    End While
                    Dim dt As DataTable = dsAllTables.Tables(tableName)
                    If Not (dt Is Nothing) Then
                        sb.Append(heading)
                        sb.Append(GetHTML(dt))
                    End If
                ElseIf (CInt(dr("HeadingType")) = 2 And _IncludeCharts) Then    'And _includeCharts = True
                    heading = "<a name='" & headingPrefix & headingNo.ToString() & ". " & heading & "'>" & headingTagStart & headingPrefix & headingNo.ToString() & ". " & " Chart: " & heading & headingTagEnd & "</a>"
                    Dim chartName As String = CStr(dr("HeadingName"))
                    chartName = chartName.Replace(" ", "")
                    sb.Append(heading)
                    sb.Append(GetChartHTML(chartName))
                End If
            Catch ex As Exception
                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
            End Try

            If (CInt(dr("HeadingType")) = 0) Then
                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CStr(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PrepareRTFs(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".")
                End If
            End If
        Next
        Return nestingLevel - 1
    End Function

    Private Function PrepareCoverRTF() As String
        Dim sb As New StringBuilder(1024 * 100) ' 100K
        Try
            Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
            Dim headingsTable As DataTable = ds.Tables(0)
            Dim CoverheadingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_147'")
            Dim htmlString As String

            sb.Append(GetPageBeginingHTML("Exported Plan"))

            sb.Append("<p class='pageBreak'></p>")


            sb.Append("<a name='CoverPage'><table align=center width=100%><tr><td align=center valign=top>")

            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(0)("HeadingID")))
            htmlString = "<h1>" & htmlString & "</h1><br><br>"
            sb.Append(htmlString)

            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(1)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(2)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)

            sb.Append("</td></tr><tr><td align=center valign=middle> <font face=verdana size=2>")

            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(3)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(4)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(5)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(6)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(7)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br><br><br><br>"
            sb.Append(htmlString)


            sb.Append("</font></td></tr><tr><td align=center valign=bottom>")

            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(CoverheadingRows(8)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b>"
            sb.Append(htmlString)
            sb.Append("</td></tr></table><br><br><br>")

            sb.Append("<p class='pageBreak'></p>")

            sb.Append(GetPageEndingHTML())
        Catch ex As Exception
            Throw New Exception("Error in Cover Page")
        End Try

        Return sb.ToString()
    End Function

    Private Function PrepareLegalHtml() As String
        Dim sb As New StringBuilder(1024 * 100) ' 100K
        Try
            Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
            Dim headingsTable As DataTable = ds.Tables(0)
            Dim LegalRows() As DataRow = headingsTable.Select("HeadingId='U_148'")
            Dim htmlString As String

            sb.Append(GetPageBeginingHTML("Exported Plan"))

            sb.Append("<p class='pageBreak'></p>")
            sb.Append("<a name='LegalPage'><center><p><H2>Confidentiality Agreement</h2></p></center><BR><BR>")
            htmlString = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(LegalRows(0)("HeadingID")))
            sb.Append(htmlString)
            sb.Append("<p class='pageBreak'></p>")

            sb.Append(GetPageEndingHTML())
        Catch ex As Exception
            Throw New Exception("Error in LegalPage Page")
        End Try

        Return sb.ToString()
    End Function

#End Region

    Private Sub PlanContents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Response.Flush()
        Response.Close()
    End Sub

End Class
