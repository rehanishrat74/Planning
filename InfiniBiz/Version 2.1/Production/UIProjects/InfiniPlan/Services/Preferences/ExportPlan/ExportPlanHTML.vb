Option Strict Off

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLL


Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Web
Imports System.Reflection
Imports Owc11
Imports Word
'Imports Microsoft.Office.Core


Public Class ExportPlanHTML

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
    Private connData As Infinilogic.BusinessPlan.DAL.ConnectionData
    Private curPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Private curPath As String
#End Region

#Region "Public methods"

    Sub New(ByVal con As ConnectionData, ByVal plan As BusinessPlan.BLL.BusinessPlan)
        connData = con
        curPlan = plan
    End Sub

    '======================================================
    'This function gets returns the rtf by using word
    'automation. First it get the HTML through other methods.
    '======================================================
    Function GetPlanRTF(ByVal currentFolderPath As String, ByVal options As ExportPlanOptions) As String

        curPath = currentFolderPath
        Dim htmlString As String = GetPlanHTML(currentFolderPath, options)
        Dim AE As New ASCIIEncoding
        Dim ByteArray As Byte() = AE.GetBytes(htmlString)
        Dim savedFileName As String

        Dim fileObj As System.IO.FileStream = File.OpenWrite(currentFolderPath & curPlan.PlanName & ".htm") 'curPlan.PlanName & ".htm")
        fileObj.Write(ByteArray, 0, ByteArray.GetLength(0))
        fileObj.Close()

        Dim wordDoc As Word.DocumentClass = New Word.DocumentClass
        Dim wordObj As Word.ApplicationClass = New Word.ApplicationClass
        Try
            wordDoc = wordObj.Documents.Open(currentFolderPath & curPlan.PlanName & ".htm")
            If options.FileExtension = "doc" Then
                wordDoc.SaveAs(currentFolderPath & curPlan.PlanName & ".doc", Word.WdSaveFormat.wdFormatDocument)
                savedFileName = currentFolderPath & curPlan.PlanName & ".doc"
            Else
                wordDoc.SaveAs(currentFolderPath & curPlan.PlanName & ".rtf", Word.WdSaveFormat.wdFormatRTF)
                savedFileName = currentFolderPath & curPlan.PlanName & ".rtf"
            End If

            'Embed images into the word document
            Dim oField As Word.Field
            For Each oField In wordDoc.Fields
                If oField.Type = Word.WdFieldType.wdFieldIncludePicture Then
                    oField.LinkFormat.SavePictureWithDocument = True
                End If
            Next
        Catch ex As Exception

        Finally
            wordDoc.Close(True)
            wordObj.Quit()
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc)
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wordObj)
            GC.Collect()
        End Try

        fileObj = File.OpenRead(savedFileName)
        Dim rtfArray(fileObj.Length) As Byte
        fileObj.Read(rtfArray, 0, CInt(fileObj.Length))
        fileObj.Close()

        Return AE.GetString(rtfArray)

    End Function

    Function GetPlanHTML(ByVal currentFolderPath As String, ByVal options As ExportPlanOptions) As String
        _IncludeTables = options.IncludeTables
        _IncludeCharts = options.IncludeCharts
        RemoveFiles(currentFolderPath)
        Return ExportPlanInHTML()
    End Function

    '================================================================
    'Prepares TOC to be displayed as Hyperlink
    '================================================================
    Public Function GetTOCHTML(ByVal targetPage As String, ByVal targetFrame As String) As String

        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 0")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        PrepareTOC(headingRows, headingsTable, sb, True, targetPage, targetFrame)
        Return sb.ToString

    End Function

    '================================================================
    'Prepares Plan without TOC
    '================================================================
    Public Function GetPlanHTML() As String

        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 0")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        PreparePlan(headingRows, headingsTable, sb)
        Return sb.ToString

    End Function

#End Region

#Region "Export Functions"

    '================================================================
    'This method uses other methods to return HTML of complete pln
    '================================================================
    Private Function ExportPlanInHTML() As String
        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 0")
        Dim CoverHeadingRows() As DataRow = headingsTable.Select("ParentHeadingID=147")
        Dim LegalRows() As DataRow = headingsTable.Select("HeadingId=148")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan"))

        PrepareCover(CoverHeadingRows, headingsTable, sb)
        PrepareLegalHtml(LegalRows, headingsTable, sb)
        PrepareTOC(headingRows, headingsTable, sb, False)
        PreparePlan(headingRows, headingsTable, sb)

        sb.Append(GetPageEndingHTML())
        Return sb.ToString
    End Function

    '================================================================
    'This method prepares a data table of TOC and then returns its HTML
    '================================================================
    Private Sub PrepareTOC(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal hlTOC As Boolean, Optional ByVal targetPage As String = "", Optional ByVal targetFrame As String = "")

        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim tblTOC As New DataTable
        Dim rowTOC As DataRow

        tblTOC.Columns.Add("Title")
        tblTOC.Columns.Add("Page No")

        'For each row in the headings table append numnering order
        'and also create a table for the TOC
        For Each dr In headingRows
            headingNo += 1

            If (CInt(dr("HeadingType")) = 0) Then
                'Append the numbering
                rowTOC = tblTOC.NewRow()
                'rowTOC.Item("Title") = "<a href='#" & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "' target='_parent'>" & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "</a>"
                rowTOC.Item("Title") = headingNo.ToString() & ". " & CStr(dr("HeadingName"))
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

        If hlTOC Then
            sb.Append(GetTOCHTML(tblTOC, targetPage, targetFrame))
        Else
            sb.Append(GetTableHTML(tblTOC))
        End If

        sb.Append("<br>")
    End Sub

    '================================================================
    'Supports last function
    '================================================================
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
            'rowTOC.Item("Title") = leadingSpaces & "<a href='#" & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "' target='_parent'>" & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName")) & "</a>"
            rowTOC.Item("Title") = leadingSpaces & headingPrefix & headingNo.ToString() & ". " & CStr(dr("HeadingName"))
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

    '================================================================
    'Prepares HTML of the complete plan text
    '================================================================


    Private Sub PrepareCover(ByRef CoverheadingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim htmlString As String

        Try

            sb.Append("<center>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(0)("HeadingID")))
            htmlString = "<h1>" & htmlString & "</h1><br>"
            sb.Append(htmlString)

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(1)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(2)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br><br><br>"
            sb.Append(htmlString)

            sb.Append("<font face=verdana size=2>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(3)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(4)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(5)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(6)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(7)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br><br><br><br>"
            sb.Append(htmlString)


            sb.Append("</font>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(CoverheadingRows(8)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b>"
            sb.Append(htmlString)
            sb.Append("</center><BR><br><BR><br><BR><br>")
        Catch ex As Exception
            Throw New Exception("Error in Cover Page")
        End Try

    End Sub
    Private Sub PrepareLegalHtml(ByRef legalRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim htmlString As String
        Try
            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(legalRows(0)("HeadingID")))
            sb.Append("<center><p><H2>Confidentiality Agreement</h2></p></center><BR><BR>" & htmlString & "<BR><BR><BR><BR>")
        Catch ex As Exception
            Throw New Exception("Error in LegalPage Page")
        End Try
    End Sub

    Private Sub PreparePlan(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        If (dsAllTables Is Nothing) Then
            dsAllTables = TextExporter.GetPlanTables(connData, curPlan, True)
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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(dr("HeadingID")))
                    ' Add them to the StringBuilder 
                    sb.Append(heading)
                    sb.Append(htmlString)
                ElseIf (CInt(dr("HeadingType")) = 1 And _IncludeTables) Then   'And _includeTables = True
                    'sb.Append(_textExporter.GetStyledHeading(heading, 14, TextAlignment.Left, "Arial"))
                    heading = "<a name='" & headingNo.ToString() & ". " & heading & "'><h2> " & headingNo.ToString() & ". " & heading & "</h2></a>"
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
                        sb.Append(GetTableHTML(dt))
                    End If
                ElseIf (CInt(dr("HeadingType")) = 2 And _IncludeCharts) Then    'And _includeCharts = True
                    heading = "<a name='" & headingNo.ToString() & ". " & heading & "'><h2> " & headingNo.ToString() & ". " & heading & "</h2></a>"
                    Dim chartName As String = CStr(dr("HeadingName"))
                    chartName = chartName.Replace(" ", "")
                    Dim chartFileName As String = curPath & connData.CustomerID & "_" & Now.Millisecond & ".GIF"
                    sb.Append(heading)
                    sb.Append(GetChartHTML(chartFileName, chartName))
                End If
            Catch ex As Exception
                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
            End Try

            If (CInt(dr("HeadingType")) = 0) Then
                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PreparePlan(children, headingsTable, sb, 1, headingNo & ".")
                End If
            End If
        Next
    End Sub

    '================================================================
    'Supports last function
    '================================================================
    Private Function PreparePlan(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String) As Integer
        If (dsAllTables Is Nothing) Then
            dsAllTables = TextExporter.GetPlanTables(connData, curPlan, True)
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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CInt(dr("HeadingID")))
                    ' Add them to the StringBuilder 
                    sb.Append(heading)
                    sb.Append(htmlString)
                ElseIf (CInt(dr("HeadingType")) = 1 And _IncludeTables = True) Then   'And _includeTables = True
                    heading = "<a name='" & headingPrefix & headingNo.ToString() & ". " & heading & "'>" & headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd & "</a>"
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
                        sb.Append(GetTableHTML(dt))
                    End If
                ElseIf (CInt(dr("HeadingType")) = 2 And _IncludeCharts) Then    'And _includeCharts = True
                    heading = "<a name='" & headingPrefix & headingNo.ToString() & ". " & heading & "'>" & headingTagStart & headingPrefix & headingNo.ToString() & ". " & heading & headingTagEnd & "</a>"
                    Dim chartName As String = CStr(dr("HeadingName"))
                    chartName = chartName.Replace(" ", "")
                    Dim chartFileName As String = curPath & connData.CustomerID & "_" & Now.Millisecond & ".GIF"
                    sb.Append(heading)
                    sb.Append(GetChartHTML(chartFileName, chartName))
                End If
            Catch ex As Exception
                Throw New Exception("Data that caused the error.  " & heading & " kindly check it.")
            End Try

            If (CInt(dr("HeadingType")) = 0) Then
                ' if it is Text Heading , it may have Subheadings , check for it 
                Dim children As Array = headingsTable.Select("ParentHeadingID = " & CInt(dr("HeadingID")))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PreparePlan(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".")
                End If
            End If
        Next
        Return nestingLevel - 1
    End Function

    '================================================================
    'Converts a data table to HTML
    '================================================================
    Private Function GetTableHTML(ByVal dt As DataTable) As String
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

    '================================================================
    'Converts a chart image to HTML
    '================================================================
    Private Function GetChartHTML(ByVal ChartFileName As String, ByVal ChartName As String) As String
        Dim ChartHTML As String
        Dim assemName As String = "Infinilogic.BusinessPlan.BLLRules"
        Dim typeName As String = assemName & "." & ChartName & "Chart"
        Dim asmbly As [Assembly] = [Assembly].Load(assemName)
        Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)

        chartClass.GenerateChart(connData, curPlan, ChartFileName, ChartChartTypeEnum.chChartTypeColumnClustered)

        ChartHTML = "<P align='center'><img src='" & ChartFileName & "' "
        'ChartHTML += " height=384 id='" & ChartName & "' style='HEIGHT: 75%; WIDTH: 80%' "
        ChartHTML += "></P>"

        Return ChartHTML
    End Function

    '================================================================
    'Converts a TOC table to HTML with hyperlinks
    '================================================================
    Private Function GetTOCHTML(ByVal dt As DataTable, ByVal targetPage As String, ByVal targetFrame As String) As String
        Dim HTML As String
        Dim Row As DataRow
        Dim Column As DataColumn

        HTML = "<P><table width='300' align='center' border='1'>"
        HTML += "<tr>"
        If Not dt.Columns(0).ColumnName = "ID" Then
            HTML += "<th>" & dt.Columns(0).Caption & "</th>"
        End If
        HTML += "</tr>"
        For Each Row In dt.Rows
            HTML += "<tr>"
            If Not dt.Columns(0).ColumnName = "ID" Then
                HTML += "<td nowrap><a href='#" & CStr(Row(dt.Columns(0))) & "'>" & CStr(Row(dt.Columns(0))) & "</a></td>"
            End If
            HTML += "</tr>"
        Next
        HTML += "</table></P>"
        Return HTML
    End Function

#End Region

#Region "Helper Functions"
    Private Function GetPageBeginingHTML(ByVal PlanName As String) As String
        Dim HTML As String
        HTML = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>"
        HTML += "<html><head><title>" & PlanName & "</title></head>"
        HTML += "<body>"
        Return HTML
    End Function
    Private Function GetPageEndingHTML() As String
        Return "</body></html>"
    End Function
    Private Sub RemoveFiles(ByVal strPath As String) '
        Try
            Dim di As DirectoryInfo = New DirectoryInfo(strPath)
            Dim fiArr As FileInfo() = di.GetFiles()
            Dim fi As FileInfo
            For Each fi In fiArr
                If (fi.Extension.ToString().ToLower = ".gif" Or fi.Extension.ToString = ".GIF" Or fi.Extension.ToString.ToLower() = ".rtf" Or fi.Extension.ToString = ".RTF" Or fi.Extension.ToString.ToLower() = ".doc" Or fi.Extension.ToString = ".DOC" Or fi.Extension.ToString.ToLower() = ".htm" Or fi.Extension.ToString = ".HTM") Then
                    ' if file is older than 2 minutes, we'll clean it up
                    Dim min As New TimeSpan(0, 0, 30)
                    If fi.CreationTime < DateTime.Now.Subtract(min) Then
                        fi.Delete()
                    End If
                End If
            Next fi
        Catch ex As Exception

        End Try
    End Sub 'RemoveFiles

    Private Sub EmbedImages(ByVal filename As String)

        Try
            Dim word_app As New Word.Application

            word_app.Documents.Open( _
                filename:=filename & ".rtf", _
                ConfirmConversions:=False, _
                ReadOnly:=True, _
                AddToRecentFiles:=False, _
                Format:=Word.WdOpenFormat.wdOpenFormatAuto)

            With word_app.Selection.Find
                .ClearFormatting()
                .Replacement.ClearFormatting()
                .Text = "^g"
                .Replacement.Text = ""
                .Forward = True
                .Wrap = Word.WdFindWrap.wdFindContinue
                .Format = False
                .MatchCase = False
                .MatchWholeWord = False
                .MatchWildcards = False
                .MatchSoundsLike = False
                .MatchAllWordForms = False
                .Execute(Replace:=Word.WdReplace.wdReplaceAll)
            End With

            ' Save the file.
            word_app.ActiveDocument.SaveAs( _
                filename:="E:\target.doc", _
                AddToRecentFiles:=False)

            CType(word_app, Word.ApplicationClass).Quit()
            word_app = Nothing

            'MsgBox("Okay")
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try

    End Sub

#End Region


End Class
