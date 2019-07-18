'#Region ".................. Imports "

'Imports Infinilogic.BusinessPlan.Common
'Imports Infinilogic.BusinessPlan.BLL
'Imports Infinilogic.BusinessPlan.DAL
'Imports Infinilogic.BusinessPlan.BLLRules
'Imports System.Text
'Imports System.Xml
'Imports System.Xml.Xsl
'Imports System.IO
'Imports Owc11

'#End Region

'Public Class PlanExporter

'#Region "............... Private Members "

'    Private connData As ConnectionData
'    Private currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan

'    ' Exporter Objects 
'    Private _textExporter As TextExporter
'    Private _tablesExporter As TableExporter
'    Private _chartExporter As ChartExporter
'    Private dsAllTables As DataSet


'    Private _xslPath As String
'    Private _includeTables As Boolean
'    Private _includeCharts As Boolean

'#End Region

'#Region ".................Constructor "

'    Public Sub New(ByVal cnData As ConnectionData, ByVal currPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
'        connData = cnData
'        currentPlan = currPlan
'    End Sub

'#End Region

'#Region ".................Public Methods "

'    Public Function ExportPlan(ByVal currentFolderPath As String, ByVal options As ExportPlanOptions) As String
'        _includeTables = options.IncludeTables
'        _includeCharts = options.IncludeCharts
'        _xslPath = currentFolderPath
'        RemoveFiles(currentFolderPath)
'        Return Export()
'    End Function

'#End Region

'#Region "................... Private Methods "

'    Private Function Export() As String


'        _textExporter = New TextExporter
'        _tablesExporter = New TableExporter
'        _chartExporter = New ChartExporter(connData, currentPlan)


'        Dim ds As DataSet = TextOperations.GetTextHeadings(connData, currentPlan)
'        Dim headingsTable As DataTable = ds.Tables(0)
'        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 0")


'        Dim sb As New StringBuilder(1024 * 100) ' 100K
'        ' Append the Starting RTF , necessary for the whole File 
'        ' Get the RTF Epilog , with portrait settings
'        sb.Append(_textExporter.GetEpilogRTF(PageLayout.Portrait))

'        ' Prepare the required TOC for all objects Accordingly
'        PrepareTOC(headingRows, headingsTable, sb)

'        ' Prepare the required RTF for all objects Accordingly
'        PrepareRTFs(headingRows, headingsTable, sb)

'        ' Get the RTF Prolog 
'        _textExporter.GetPrologRTF(sb)
'        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
'        ' if any ambiguity was found , it can be checked by opening this code 
'        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
'        'Dim fs As New FileStream(_xslPath & "myfile.rtf", FileMode.OpenOrCreate)
'        'Dim tw As New StreamWriter(fs)
'        'tw.Write(sb.ToString)
'        'tw.Close()
'        Return sb.ToString
'    End Function

'    Private Sub PrepareTOC(ByRef headingRows() As DataRow, ByRef headingsTable As DataTable, ByRef sb As StringBuilder)

'        Dim dr As DataRow
'        Dim headingNo As Integer = 0
'        Dim tblTOC As New DataTable
'        Dim rowTOC As DataRow

'        tblTOC.Columns.Add("Title")
'        tblTOC.Columns.Add("Page No")

'        'For each row in the headings table append numnering order
'        'and also create a table for the TOC
'        For Each dr In headingRows
'            headingNo += 1

'            'Append the numbering
'            rowTOC = tblTOC.NewRow()
'            rowTOC.Item("Title") = headingNo.ToString() & ". " & CStr(dr("HeadingName"))
'            rowTOC.Item("Page No") = ""
'            tblTOC.Rows.Add(rowTOC)

'            If (CInt(dr("HeadingType")) = 0) Then
'                ' if it is Text Heading , it may have Subheadings , check for it 
'                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

'                If (children.Length > 0) Then
'                    ' if there are any subheadings , traverse them too , accordingly.
'                    PrepareTOC(children, headingsTable, sb, 1, headingNo & ".", tblTOC)
'                End If
'            End If

'        Next

'        Dim tmp As New StringBuilder(1024 * 10)
'        tmp.Append(_tablesExporter.CreateDataTable(tblTOC, TextAlignment.Right, 70, 8))
'        _textExporter.TableDataFonts(tmp, "Arial", 12)
'        sb.Append(tmp)
'        sb.Append("\page")

'    End Sub

'    Private Function PrepareTOC(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String, ByVal tblTOC As DataTable) As Integer

'        Dim dr As DataRow
'        Dim headingNo As Integer = 0
'        Dim rowTOC As DataRow
'        Dim leadingSpaces As String = ""

'        'For each row in the headings table append numnering order
'        'and also create a table for the TOC
'        Dim i As Integer
'        For i = 0 To nestingLevel
'            leadingSpaces = leadingSpaces & "   "
'        Next

'        For Each dr In headingRows
'            headingNo += 1

'            rowTOC = tblTOC.NewRow()
'            rowTOC.Item("Title") = leadingSpaces & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName"))
'            rowTOC.Item("Page No") = ""
'            tblTOC.Rows.Add(rowTOC)

'            If (CInt(dr("HeadingType")) = 0) Then
'                ' if it is Text Heading , it may have Subheadings , check for it 
'                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

'                If (children.Length > 0) Then
'                    ' if there are any subheadings , traverse them too , accordingly.
'                    nestingLevel = PrepareTOC(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".", tblTOC)
'                End If
'            End If

'        Next

'        Return nestingLevel - 1

'    End Function

'    Private Sub PrepareRTFs(ByRef headingRows() As DataRow, ByRef headingsTable As DataTable, ByRef sb As StringBuilder)

'        If (dsAllTables Is Nothing) Then
'            dsAllTables = TextExporter.GetPlanTables(connData, currentPlan, True)
'        End If


'        Dim dr As DataRow
'        Dim headingNo As Integer = 0
'        For Each dr In headingRows
'            headingNo += 1

'            ' Print the first Heading and its text 
'            ' Then see if it has Subheadings , if so , recursively Print them too.
'            Dim heading As String = CStr(dr("HeadingName"))
'            Dim htmlString As String
'            Dim rtfString As String
'            Dim headingText As String
'            Try
'                ' Check if some heading makes an incident, catch it 
'                If (CInt(dr("HeadingType")) = 0) Then
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = "<h1> " & headingNo.ToString() & ". " & heading & "</h1>"
'                    rtfString = Html2RtfConvertor.TransformIntoRTF(heading, _xslPath, GetStylesheetParams())
'                    headingText = _textExporter.RTFElimination(rtfString)
'                    rtfString = headingText & TextOperations.GetTextData(connData, currentPlan, CInt(dr("HeadingID")))
'                    'rtfString = _textExporter.RTFElimination(rtfString)
'                    ' Add them to the StringBuilder 
'                    sb.Append(rtfString)
'                ElseIf (CInt(dr("HeadingType")) = 1 And _includeTables = True) Then   'And _includeTables = True
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = "<h1> " & headingNo.ToString() & ". " & heading & "</h1>"
'                    ' If it is a Table 
'                    Dim tableName As String = CStr(dr("HeadingName"))
'                    tableName = Trim(tableName.Substring(tableName.IndexOf(":") + 1))

'                    Dim spaceIndex As Integer = tableName.IndexOf(" ")
'                    While (spaceIndex > -1)
'                        tableName = tableName.Remove(spaceIndex, 1)
'                        spaceIndex = tableName.IndexOf(" ")
'                    End While

'                    Dim dt As DataTable = dsAllTables.Tables(tableName)
'                    If Not (dt Is Nothing) Then
'                        Dim tmp As New StringBuilder(1024 * 10)
'                        tmp.Append(_tablesExporter.CreateDataTable(dt, TextAlignment.Right, 15, 2))
'                        _textExporter.TableDataFonts(tmp, "Arial", 9)
'                        sb.Append(tmp)
'                    End If
'                ElseIf (CInt(dr("HeadingType")) = 2 And _includeCharts = True) Then    'And _includeCharts = True
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = "<h1> " & headingNo.ToString() & ". " & heading & "</h1>"
'                    ' If it is a Chart 
'                    Dim chartName As String = CStr(dr("HeadingName"))
'                    chartName = chartName.Replace(" ", "")
'                    Dim chartFileName As String = _xslPath & connData.CustomerID & "_" & Now.Millisecond & ".GIF"
'                    ' Draw the chart 
'                    Dim chartRTF As String = _chartExporter.ExportChart(chartFileName, chartName)  ' OWC11.ChartChartTypeEnum.chChartTypeBar3D
'                    ' Add the chart in the Plan RTF 
'                    sb.Append(chartRTF)
'                End If
'            Catch ex As Exception
'                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
'            End Try

'            If (CInt(dr("HeadingType")) = 0) Then
'                ' if it is Text Heading , it may have Subheadings , check for it 
'                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

'                If (children.Length > 0) Then
'                    ' if there are any subheadings , traverse them too , accordingly.
'                    PrepareRTFs(children, headingsTable, sb, 1, headingNo & ".")
'                End If
'            End If
'        Next

'    End Sub

'    Private Function PrepareRTFs(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String) As Integer

'        If (dsAllTables Is Nothing) Then
'            dsAllTables = TextExporter.GetPlanTables(connData, currentPlan, True)
'        End If


'        Dim dr As DataRow
'        Dim headingNo As Integer = 0
'        Dim headingTagStart As String
'        Dim headingTagEnd As String

'        For Each dr In headingRows
'            headingNo += 1
'            If nestingLevel = 1 Then
'                headingTagStart = "<h2> "
'                headingTagEnd = "</h2>"
'            Else
'                headingTagStart = "<h2> "
'                headingTagEnd = "</h2>"
'            End If

'            ' Print the first Heading and its text 
'            ' Then see if it has Subheadings , if so , recursively Print them too.
'            Dim heading As String = CStr(dr("HeadingName"))
'            Dim htmlString As String
'            Dim rtfString As String
'            Dim headingText As String
'            Try
'                ' Check if some heading makes an incident, catch it 
'                If (CInt(dr("HeadingType")) = 0) Then
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd
'                    rtfString = Html2RtfConvertor.TransformIntoRTF(heading, _xslPath, GetStylesheetParams())
'                    headingText = _textExporter.RTFElimination(rtfString)
'                    rtfString = headingText & TextOperations.GetTextData(connData, currentPlan, CInt(dr("HeadingID")))
'                    'rtfString = _textExporter.RTFElimination(rtfString)
'                    ' Add them to the StringBuilder 
'                    sb.Append(rtfString)
'                ElseIf (CInt(dr("HeadingType")) = 1 And _includeTables = True) Then   'And _includeTables = True
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd
'                    ' If it is a Table 
'                    Dim tableName As String = CStr(dr("HeadingName"))
'                    tableName = Trim(tableName.Substring(tableName.IndexOf(":") + 1))

'                    Dim spaceIndex As Integer = tableName.IndexOf(" ")
'                    While (spaceIndex > -1)
'                        tableName = tableName.Remove(spaceIndex, 1)
'                        spaceIndex = tableName.IndexOf(" ")
'                    End While

'                    Dim dt As DataTable = dsAllTables.Tables(tableName)
'                    If Not (dt Is Nothing) Then
'                        Dim tmp As New StringBuilder(1024 * 10)
'                        tmp.Append(_tablesExporter.CreateDataTable(dt, TextAlignment.Right, 15, 2))
'                        _textExporter.TableDataFonts(tmp, "Arial", 9)
'                        sb.Append(tmp)
'                    End If
'                ElseIf (CInt(dr("HeadingType")) = 2 And _includeCharts = True) Then    'And _includeCharts = True
'                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
'                    heading = headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd
'                    ' If it is a Chart 
'                    Dim chartName As String = CStr(dr("HeadingName"))
'                    chartName = chartName.Replace(" ", "")
'                    Dim chartFileName As String = _xslPath & connData.CustomerID & "_" & Now.Millisecond & ".GIF"
'                    ' Draw the chart 
'                    Dim chartRTF As String = _chartExporter.ExportChart(chartFileName, chartName)  ' OWC11.ChartChartTypeEnum.chChartTypeBar3D
'                    ' Add the chart in the Plan RTF 
'                    sb.Append(chartRTF)
'                End If
'            Catch ex As Exception
'                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
'            End Try

'            If (CInt(dr("HeadingType")) = 0) Then
'                ' if it is Text Heading , it may have Subheadings , check for it 
'                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

'                If (children.Length > 0) Then
'                    ' if there are any subheadings , traverse them too , accordingly.
'                    nestingLevel = PrepareRTFs(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".")
'                End If
'            End If
'        Next

'        Return nestingLevel - 1

'    End Function

'    Private Function GetStylesheetParams() As XsltArgumentList

'        Dim xslargs As New XsltArgumentList
'        xslargs.AddParam("page-start-number", "", "1")
'        xslargs.AddParam("header-font-size-default", "", "21")
'        xslargs.AddParam("footer-font-size-default", "", "21")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")
'        'xslargs.AddParam("page-start-number", "", "1")

'        Return xslargs
'    End Function

'    Private Sub RemoveFiles(ByVal strPath As String) '
'        Dim di As DirectoryInfo = New DirectoryInfo(strPath)
'        Dim fiArr As FileInfo() = di.GetFiles()
'        Dim fi As FileInfo
'        For Each fi In fiArr
'            If (fi.Extension.ToString().ToLower = ".gif" Or fi.Extension.ToString = ".GIF") Then
'                ' if file is older than 2 minutes, we'll clean it up
'                Dim min As New TimeSpan(0, 0, 30)
'                If fi.CreationTime < DateTime.Now.Subtract(min) Then
'                    fi.Delete()
'                End If
'            End If
'        Next fi
'    End Sub 'RemoveFiles
'#End Region

'End Class
