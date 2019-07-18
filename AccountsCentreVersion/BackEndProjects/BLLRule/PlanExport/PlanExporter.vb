Option Strict Off

#Region ".................. Imports "

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.BLL

Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Web
Imports System.Reflection
Imports Owc11
Imports Word

#End Region

Public Class PlanExporter

#Region "............. Private Members "

    Private _PlanID As Integer
    Private _IncludeTables As Boolean
    Private _IncludeCharts As Boolean

    Private dsAllTables As DataSet
    Private ChartingScript As String
    Private connData As Infinilogic.BusinessPlan.DAL.ConnectionData
    Private curPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Private curPath As String

#End Region

#Region "Constructors"

    Sub New(ByVal con As ConnectionData, ByVal plan As BusinessPlan.BLL.BusinessPlan)

        connData = con
        curPlan = plan

    End Sub

#End Region

#Region "Public methods for preview"

    Public Function GetPlanContentsHTML() As String

        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_0'")

        _IncludeTables = True
        _IncludeCharts = True

        ChartingScript = "<script language='vbscript'>" & vbCrLf
        ChartingScript += "Sub Window_onLoad()" & vbCrLf

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan", "<LINK REL=stylesheet Type='text/css' HREF='../../Library/Styles/PlanPreview.css'><script language='vbscript' src='../../Library/Scripts/ClientSideCharting.vbs'></script>"))

        PrepareContentsHTML(headingRows, headingsTable, sb)

        ChartingScript += "End Sub" & vbCrLf
        'ChartingScript += "Sub DrawChart(xmlDoc, chartSpace)" & vbCrLf
        'ChartingScript += "chartSpace.XMLData = xmlDoc.xml" & vbCrLf
        'ChartingScript += "End Sub" & vbCrLf
        ChartingScript += "</script>" & vbCrLf

        If _IncludeCharts Then sb.Append(ChartingScript)

        sb.Append(GetPageEndingHTML())

        Return sb.ToString

    End Function

    Public Function GetPlanTOCHTML() As String

        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_0'")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan", "<BASE target='main'><LINK href='../../Library/Styles/MainStyle.css' type='text/css' rel='stylesheet'>"))

        sb.Append(GetInstructionsHTML())

        PrepareTOCHTML(headingRows, headingsTable, sb)

        sb.Append(GetPageEndingHTML())

        Return sb.ToString

    End Function

    Public Function GetCoverHTML() As String

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        Try
            Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
            Dim headingsTable As DataTable = ds.Tables(0)
            Dim CoverheadingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_147'")
            Dim htmlString As String

            sb.Append(GetPageBeginingHTML("Exported Plan", "<LINK href='../../Library/Styles/MainStyle.css' type='text/css' rel='stylesheet'>"))

            sb.Append("<p class='pageBreak'></p>")


            sb.Append("<a name='CoverPage'><table align=center width=100%><tr><td align=center valign=top>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(0)("HeadingID")))
            htmlString = "<h1>" & htmlString & "</h1><br><br>"
            sb.Append(htmlString)

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(1)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(2)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)

            sb.Append("</td></tr><tr><td align=center valign=middle> <font face=verdana size=2>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(3)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(4)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(5)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(6)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(7)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br><br><br><br>"
            sb.Append(htmlString)


            sb.Append("</font></td></tr><tr><td align=center valign=bottom>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(8)("HeadingID")))
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

    Public Function GetLegalHtml() As String

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        Try
            Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
            Dim headingsTable As DataTable = ds.Tables(0)
            Dim LegalRows() As DataRow = headingsTable.Select("HeadingId='U_148'")
            Dim htmlString As String

            sb.Append(GetPageBeginingHTML("Exported Plan", "<LINK href='../../Library/Styles/MainStyle.css' type='text/css' rel='stylesheet'>"))

            sb.Append("<p class='pageBreak'></p>")
            ' sb.Append("<a name='LegalPage'><center><p><H2>Confidentiality Agreement</h2></p></center><BR><BR>")
            sb.Append("<a name='LegalPage'><center><p></p></center><BR><BR>")
            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(LegalRows(0)("HeadingID")))
            sb.Append(htmlString)
            sb.Append("<p class='pageBreak'></p>")

            sb.Append(GetPageEndingHTML())
        Catch ex As Exception
            Throw New Exception("Error in LegalPage Page")
        End Try

        Return sb.ToString()

    End Function

#End Region

#Region "Private methods for preview"

    Private Sub PrepareTOCHTML(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)

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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID")) & "'")

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PrepareTOCHTML(children, headingsTable, sb, 1, headingNo & ".", tblTOC)
                End If
            End If

        Next

        sb.Append(GetTOCHTML(tblTOC))
        sb.Append("<br>")

    End Sub

    Private Function PrepareTOCHTML(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String, ByVal tblTOC As DataTable) As Integer

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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID")) & "'")

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PrepareTOCHTML(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".", tblTOC)
                End If
            End If
        Next
        Return nestingLevel - 1

    End Function

    Private Sub PrepareContentsHTML(ByRef headingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)

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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(dr("HeadingID")))
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
                        sb.Append(GetTableHTML(dt))
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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID")) & "'")

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PrepareContentsHTML(children, headingsTable, sb, 1, headingNo & ".")
                End If
            End If
        Next

    End Sub

    Private Function PrepareContentsHTML(ByRef headingRows As Array, ByRef headingsTable As DataTable, ByRef sb As StringBuilder, ByVal nestingLevel As Integer, ByVal headingPrefix As String) As Integer

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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(dr("HeadingID")))
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
                        sb.Append(GetTableHTML(dt))
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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID")) & "'")

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PrepareContentsHTML(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".")
                End If
            End If
        Next
        Return nestingLevel - 1

    End Function

    Private Function GetChartHTML(ByVal ChartName As String) As String

        Dim ChartHTML As String
        Dim ChartID As Integer = GetChartID(ChartName)
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

    Private Function GetInstructionsHTML() As String
        Return "<p class='lblNote' align=center>If you cannot view the charts <a href='http://www.microsoft.com/downloads/details.aspx?familyid=7287252C-402E-4F72-97A5-E0FD290D4B76&displaylang=en' target='_blank'><font color='#0000FF'>click here</font></a> to download MS Office Web Components 11.</p>"
    End Function

#End Region

#Region "Public methods for export"

    Public Function GetPlanRTF(ByVal currentFolderPath As String, ByVal options As ExportPlanOptions) As String

        curPath = currentFolderPath
        Dim htmlString As String = GetPlanHTML(currentFolderPath, options)
        Dim AE As New UTF8Encoding  ' ASCIIEncoding
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

#End Region

#Region "Private methods for export"

    Function GetPlanHTML(ByVal currentFolderPath As String, ByVal options As ExportPlanOptions) As String
        _IncludeTables = options.IncludeTables
        _IncludeCharts = options.IncludeCharts
        RemoveFiles(currentFolderPath)
        Return ExportPlanInHTML()
    End Function

    Private Function ExportPlanInHTML() As String
        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(connData, curPlan)
        Dim headingsTable As DataTable = ds.Tables(0)
        Dim headingRows() As DataRow = headingsTable.Select("ParentHeadingID = 'U_0'")
        Dim CoverHeadingRows() As DataRow = headingsTable.Select("ParentHeadingID='U_147'")
        Dim LegalRows() As DataRow = headingsTable.Select("HeadingId='U_148'")

        Dim sb As New StringBuilder(1024 * 100) ' 100K
        sb.Append(GetPageBeginingHTML("Exported Plan", ""))

        PrepareCoverForExport(CoverHeadingRows, headingsTable, sb)
        PrepareLegalForExport(LegalRows, headingsTable, sb)
        PrepareTOC(headingRows, headingsTable, sb, False)
        PreparePlan(headingRows, headingsTable, sb)

        sb.Append(GetPageEndingHTML())
        Return sb.ToString

    End Function

    Private Sub PrepareCoverForExport(ByRef CoverheadingRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim htmlString As String

        Try

            sb.Append("<center>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(0)("HeadingID")))
            htmlString = "<h1>" & htmlString & "</h1><br>"
            sb.Append(htmlString)

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(1)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(2)("HeadingID")))
            htmlString = "<h3>" & htmlString & "</h3><br><br><br>"
            sb.Append(htmlString)

            sb.Append("<font face=verdana size=2>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(3)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(4)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(5)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(6)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br>"
            sb.Append(htmlString)


            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(7)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b><br><br><br><br><br>"
            sb.Append(htmlString)


            sb.Append("</font>")

            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(CoverheadingRows(8)("HeadingID")))
            htmlString = "<b>" & htmlString & "</b>"
            sb.Append(htmlString)
            sb.Append("</center><BR><br><BR><br><BR><br>")
        Catch ex As Exception
            Throw New Exception("Error in Cover Page")
        End Try

    End Sub

    Private Sub PrepareLegalForExport(ByRef legalRows As DataRow(), ByRef headingsTable As DataTable, ByRef sb As StringBuilder)
        Dim dr As DataRow
        Dim headingNo As Integer = 0
        Dim htmlString As String
        Try
            htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(legalRows(0)("HeadingID")))
            ' sb.Append("<center><p><H2>Confidentiality Agreement</h2></p></center><BR><BR>" & htmlString & "<BR><BR><BR><BR>")
            sb.Append("<center><p></p></center><BR><BR>" & htmlString & "<BR><BR><BR><BR>")
        Catch ex As Exception
            Throw New Exception("Error in LegalPage Page")
        End Try
    End Sub

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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID") & "'"))

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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID") & "'"))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PrepareTOC(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".", tblTOC)
                End If
            End If
        Next
        Return nestingLevel - 1
    End Function

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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(dr("HeadingID")))
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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID") & "'"))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    PreparePlan(children, headingsTable, sb, 1, headingNo & ".")
                End If
            End If
        Next
    End Sub

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
                    htmlString = TextOperations.GetPlanTextData(connData, curPlan, CStr(dr("HeadingID")))
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
                Dim children As Array = headingsTable.Select("ParentHeadingID = '" & CStr(dr("HeadingID") & "'"))

                If (children.Length > 0) Then
                    ' if there are any subheadings , traverse them too , accordingly.
                    nestingLevel = PreparePlan(children, headingsTable, sb, nestingLevel + 1, headingPrefix & headingNo.ToString() & ".")
                End If
            End If
        Next
        Return nestingLevel - 1
    End Function

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

#Region "Helper Procedures"

    Private Function GetPageBeginingHTML(ByVal PlanName As String, ByVal LinkFiles As String) As String
        Dim HTML As String
        HTML = "<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'><meta http-equiv='Content-Type' content='text/html; charset=utf-8'>"
        HTML += "<html><head><title>" & PlanName & "</title>" & LinkFiles & "</head>"
        HTML += "<body>"
        Return HTML
    End Function

    Private Function GetPageEndingHTML() As String
        Return "</body></html>"
    End Function

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

    Private Function GetChartID(ByVal ChartName As String) As Integer

        Select Case ChartName
            Case "Startup"
                Return 5
            Case "Benchmark"
                Return 0
            Case "BreakEvenAnalysis"
                Return 1
            Case "CashFlow"
                Return 2
            Case "Highlights"
                Return 3
            Case "MarketAnalysis"
                Return 4
            Case "PastPerformance"
                Return 5
            Case "ProfitMonthly"
                Return 6
            Case "ProfitYearly"
                Return 7
            Case "GrossMarginMonthly"
                Return 8
            Case "GrossMarginYearly"
                Return 9
            Case "SalesYearly"
                Return 10
            Case "SalesMonthly"
                Return 11
        End Select
        Return 0

    End Function

#End Region

End Class
