Imports System.Text
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL

Public Class TextExporter

#Region "....................Private Shared Variables"

    Private Shared _FontCollection As Hashtable  'Collection of all fonts that can be used

#End Region

#Region "...................Private Variables"

    Private _RTFStrings As New ArrayList        'Collection for all RTFs
    Private _FontCodeStrings As New ArrayList   'Fonts' intialization code collection
    Private _FontTable As New Hashtable         'For keeping the record of fonts used
    Private _ColorTable As New Hashtable        'Color initialization code collection
    Private _FontNum As Integer = -1
    Private _objTable As New TableExporter
    'Private _objChart As New ChartExporter

#Region "Constants"

    Private Const startStringStart As String = "{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl" 'RTF starting string
    Private Const startStringEnd As String = "viewkind1\uc1" 'RTF's end of Start string
    Private Const pageSettingStringLandScape As String = "\landscape\paperw16840\paperh11907\margl283\margt283\margr283\margb283\" 'RTF's page setting string
    'Private Const pageSettingStringPortrait As String = "\paperh16840\paperw11907\margl283\margt283\margr283\margb283\" 'RTF's page setting string
    Private Const pageSettingStringPortrait As String = "\paperh16840\paperw11907\" 'RTF's page setting string

    'Const pageSettingString As String = "\paperw16840\paperh11907\margl283\margt283\margr283\margb283\" 'RTF's page setting string
    Private Const endString As String = "\par}" ' RTF's ending string
    Private Const fontEndString As String = "\fcharset" 'Font's recognization string 
    Private Const colorTblString As String = "{\colortbl ;" 'Font Color table's starting string
    Private Const colorCallString As String = "\cf" 'Font Color's calling string
    Private Const _pageBreak As String = "\page"

#End Region

#End Region

#Region "........................Properties "

    Public ReadOnly Property PageBreak() As String
        Get
            Return _pageBreak
        End Get
    End Property

#End Region

#Region ".....................Public Methods"

    Public Sub New()

        _FontCollection = InitializeFonts()

    End Sub

    Public Function GetFontsCollection() As Hashtable
        Return _FontCollection
    End Function

    'Function for cleansing of RTF by removing starting and ending strings
    Public Function RTFElimination(ByVal RTF As String) As String

        Dim tempRTF As String = RTF

        'If tempRTF.Length > 0 Then

        tempRTF = tempRTF.Remove(0, Len(startStringStart))

        tempRTF = RemoveExtraBraces(tempRTF)

        tempRTF = NormalizeString(tempRTF)

        tempRTF = RTFFontsElimination(tempRTF)

        tempRTF = RTFColorTableElimination(tempRTF)


        ' remove start string , if present
        Dim startStringindex As Integer = tempRTF.IndexOf(startStringEnd)
        If (startStringindex > -1) Then
            tempRTF = tempRTF.Remove(0, tempRTF.IndexOf(startStringEnd) + Len(startStringEnd))
        End If

        ' Remove end String , if present
        Dim endStringIndex As Integer = tempRTF.IndexOf(endString)
        If (endStringIndex > -1) Then
            tempRTF = tempRTF.Remove(Len(tempRTF) - Len(endString), Len(endString))
        End If

        tempRTF = "\pard" & tempRTF & "\par "

        'End If
        _RTFStrings.Add(tempRTF)

        Return tempRTF

    End Function

    Public Function ExportRTF(ByVal strHeading As ArrayList, ByVal strTableData As String, ByVal strChartData As String) As String

        Dim strInternal As String
        Dim i As Integer

        strInternal = startStringStart

        For i = 0 To _FontCodeStrings.Count - 1

            strInternal = strInternal & CStr(_FontCodeStrings(i))

        Next

        strInternal = strInternal & "}" & colorTblString

        For i = 1 To _ColorTable.Count

            strInternal = strInternal & CStr(_ColorTable.Item(i))

        Next

        strInternal = strInternal + "}" + pageSettingStringPortrait + startStringEnd

        For i = 0 To _RTFStrings.Count - 1

            strInternal = strInternal & CStr(strHeading(i)) & CStr(_RTFStrings(i))

        Next

        strInternal = strInternal & strTableData & strChartData & endString

        Return strInternal

    End Function

    Public Function GetEpilogRTF(ByVal page As PageLayout) As String

        Dim strInternal As String
        Dim i As Integer

        strInternal = startStringStart

        For i = 0 To _FontCodeStrings.Count - 1

            strInternal = strInternal & CStr(_FontCodeStrings(i))

        Next

        strInternal = strInternal + "}" + colorTblString

        For i = 1 To _ColorTable.Count

            strInternal = strInternal & CStr(_ColorTable.Item(i))

        Next

        If (page = PageLayout.Portrait) Then
            strInternal = strInternal + "}" + pageSettingStringPortrait + startStringEnd
        Else
            strInternal = strInternal + "}" + pageSettingStringLandScape + startStringEnd
        End If


        'For i = 0 To _RTFStrings.Count - 1

        '    strInternal = strInternal + strHeading(i) + _RTFStrings(i)

        'Next

        'strInternal = strInternal & endString

        Return strInternal

    End Function

    Public Sub GetPrologRTF(ByRef strInternal As StringBuilder)
        strInternal.Append(endString)
    End Sub

    Public Shared Function GetPlanTables(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal completePlan As Boolean) As DataSet
        'Dim tableExp As New TableExporter
        'Dim textExp As New TextExporter
        Dim i As Integer

        ' Make a Dataset
        Dim ds As New DataSet("Tables")
        Dim dt As DataTable

        ' Ratios Table
        Dim RatiosTable As Ratios = New Ratios(connData, currentPlan)
        ds.Tables.Add(RatiosTable)

        ' BalanceSheet Table
        Dim bsheet As BalanceSheet = RatiosTable.GetBalanceSheet 'New BalanceSheet(connData, currentPlan)
        TruncateTable(CType(bsheet, DataTable), completePlan)
        ds.Tables.Add(bsheet)

        ' CashFlow Table
        Dim CashFlowTable As CashFlow = bsheet.GetCashFlow
        TruncateTable(CType(CashFlowTable, DataTable), completePlan)
        ds.Tables.Add(CashFlowTable)

        ' IncomeStatement Table
        Dim IncStatement As IncomeStatement = bsheet.GetIncomeStatement()
        TruncateTable(CType(IncStatement, DataTable), completePlan)
        ds.Tables.Add(IncStatement)

        ' SalesForeCast Table
        Dim salesfore As SalesForecast = IncStatement.GetSalesForecast
        TruncateTable(CType(salesfore, DataTable), completePlan)
        ds.Tables.Add(salesfore)

        ' Payroll Table
        Dim PayrollTable As Payroll = IncStatement.GetPayroll
        TruncateTable(CType(PayrollTable, DataTable), completePlan)
        ds.Tables.Add(PayrollTable)


        ' GeneralAssumption Table
        Dim GATable As GeneralAssumption = IncStatement.GetGeneralAssumption
        TruncateTable(CType(GATable, DataTable), completePlan)
        ds.Tables.Add(GATable)


        If currentPlan.IsOngoing Then
            ' PastPerformance Table
            dt = New PastPerformance(connData, currentPlan)
            If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
            ds.Tables.Add(dt)
        Else
            ' Startup Table
            dt = New StartupDetails(connData, currentPlan)
            If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
            ds.Tables.Add(dt)
        End If

        ' MarketAnalysis Table
        dt = New MarketAnalysis(connData, currentPlan)
        'TruncateTable(dt, completePlan, True)
        If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
        ds.Tables.Add(dt)

        ' BreakEven Table
        dt = New BreakEvenAnalysis(connData, currentPlan)
        If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
        ds.Tables.Add(dt)

        ' MileStones Table
        dt = New Milestones(connData, currentPlan)
        If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
        ds.Tables.Add(dt)

        Return ds
    End Function

    Private Shared Sub TruncateTable(ByRef dt As DataTable, ByVal completePlan As Boolean)
        Dim i As Integer
        If (completePlan) Then
            For i = 1 To 12
                dt.Columns.RemoveAt(1)
            Next
        End If
        If dt.Columns.Contains("ID") Then dt.Columns.Remove("ID")
    End Sub

    Public Function TableFonts(ByRef strTable As String, ByVal fontName As String) As String

        Dim fontString As String

        If Not _FontTable.Contains(fontName) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fontName, _FontNum) 'Adding font to font table 
            strTable = strTable.Replace("\f0", "\f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fontName)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strTable = strTable.Replace("\f0", "\f" & CStr(_FontTable.Item(fontName)))
        End If

        Return strTable

    End Function

    Public Function TableFontsWithSize(ByRef strTable As String, ByVal fontName As String, ByVal fontSize As Integer) As String

        Dim fontString As String

        If Not _FontTable.Contains(fontName) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fontName, _FontNum) 'Adding font to font table 
            strTable = strTable.Replace("\f0", "\f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fontName)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strTable = strTable.Replace("\f0", "\f" & CStr(_FontTable.Item(fontName)))
        End If

        strTable = strTable.Replace("\fs14", "\fs" & fontSize * 2)

        Return strTable

    End Function


#Region "Headings"

    Public Function GetStyledHeading(ByVal heading As String, ByVal fonts As String) As String

        Dim fontString As String
        Dim strStartString As String = "\par \pard\qc\b\f0\fs24\par "
        Dim strEndString As String = "\b0\fs20\par\pard "

        If Not _FontTable.Contains(fonts) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fonts, _FontNum) 'Adding font to font table 
            strStartString = strStartString.Replace("f0", "f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fonts)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strStartString = strStartString.Replace("f0", "f" & CStr(_FontTable.Item(fonts)))
        End If


        Return strStartString & heading & strEndString

    End Function

    Public Function GetStyledHeading(ByVal heading As String, ByVal fontSize As Integer, ByVal fonts As String) As String

        Dim strStartString As String = "\par \pard\qc\b\f0\fs" & fontSize * 2
        Dim strEndString As String = "\b0\f0\fs24\par "
        Dim fontString As String

        If Not _FontTable.Contains(fonts) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fonts, _FontNum) 'Adding font to font table 
            strStartString = strStartString.Replace("f0", "f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fonts)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strStartString = strStartString.Replace("f0", "f" & CStr(_FontTable.Item(fonts)))
        End If

        Return strStartString & heading & strEndString

    End Function

    Public Function GetStyledHeading(ByVal heading As String, ByVal fontSize As Integer, ByVal alignment As TextAlignment, ByVal fonts As String) As String

        Dim strStartString As String = "\par \pard\qc\b\f0\fs" & fontSize * 2
        Dim strEndString As String = "\b0\f0\fs24\par "
        Dim fontString As String

        Select Case alignment

            Case TextAlignment.Centre

                strStartString = "\par \pard\qc\b\f0\fs" & fontSize * 2 & " "

            Case TextAlignment.Left

                strStartString = "\par \pard\ql\b\f0\fs" & fontSize * 2 & " "

            Case TextAlignment.Right

                strStartString = "\par \pard\qr\b\f0\fs" & fontSize * 2 & " "

        End Select

        If Not _FontTable.Contains(fonts) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fonts, _FontNum) 'Adding font to font table 
            strStartString = strStartString.Replace("f0", "f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fonts)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strStartString = strStartString.Replace("f0", "f" & CStr(_FontTable.Item(fonts)))
        End If

        Return strStartString & heading & strEndString

    End Function

#End Region

#Region "Fonts "

    Public Function GetFonts(ByVal font As String) As String

        'Dim strFont As String = "{\fonttbl{\f" + fontNum + "\fswiss\fcharset0 " + font + ";}"

        'fontNum += 1

        '      Return strFont

    End Function

    Public Sub TableDataFonts(ByRef strTable As StringBuilder, ByVal fontName As String)

        Dim fontString As String

        If Not _FontTable.Contains(fontName) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fontName, _FontNum) 'Adding font to font table 
            strTable.Replace("\f0", "\f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fontName)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strTable.Replace("\f0", "\f" & CStr(_FontTable.Item(fontName)))
        End If
    End Sub

    Public Sub TableDataFonts(ByRef strTable As StringBuilder, ByVal fontName As String, ByVal fontSize As Integer)
        Dim fontString As String

        If Not _FontTable.Contains(fontName) Then ' Checking whether the font is already intialized
            _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
            _FontTable.Add(fontName, _FontNum) 'Adding font to font table 
            strTable.Replace("\f0", "\f" & _FontNum) ' Replacing the font reference id with the new intialized id
            fontString = CStr(_FontCollection.Item(fontName)) 'Getting font intialization code from collection
            fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
            _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
        Else
            'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
            strTable.Replace("\f0", "\f" & CStr(_FontTable.Item(fontName)))
        End If

        strTable.Replace("\fs14", "\fs" & fontSize * 2)
    End Sub

    'Public Function TableDataFonts(ByVal strTable As String, ByVal fonts As String) As String

    '    Dim fontString As String

    '    If Not _FontTable.Contains(fonts) Then ' Checking whether the font is already intialized
    '        _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
    '        _FontTable.Add(fonts, _FontNum) 'Adding font to font table 
    '        strTable = strTable.Replace("\f0", "\f" & _FontNum) ' Replacing the font reference id with the new intialized id
    '        fontString = _FontCollection.Item(fonts) 'Getting font intialization code from collection
    '        fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
    '        _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
    '    Else
    '        'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
    '        strTable = strTable.Replace("\f0", "\f" & _FontTable.Item(fonts))
    '    End If


    '    Return strTable

    'End Function

#End Region

#End Region

#Region "..........................Private Methods "

    Private Shared Function InitializeFonts() As Hashtable

        Dim tmp As New Hashtable(85)
        Dim str As String = "{\f"

        tmp.Add("Algerian", str & "\fdecor\fprq2\fcharset0 Algerian;}")
        tmp.Add("Arial", str & "\fswiss\fprq2\fcharset0 Arial;}")
        tmp.Add("Arial Black", str & "\fswiss\fprq2\fcharset0 Arial Black;}")
        tmp.Add("Arial Narrow", str & "\fswiss\fprq2\fcharset0 Arial Narrow;}")
        tmp.Add("Arial Unicode MS", str & "\fswiss\fprq2\fcharset0 Arial Unicode MS;}")
        tmp.Add("Baskerville Old Face", str & "\froman\fprq2\fcharset0 Baskerville Old Face;}")
        tmp.Add("Bauhaus 93", str & "\fdecor\fprq2\fcharset0 Bauhaus 93;}")
        tmp.Add("Bell MT", str & "\froman\fprq2\fcharset0 Bell MT;}")
        tmp.Add("Berlin Sans FB", str & "\fswiss\fp\fcharset0 Berlin Sans FB;}")
        tmp.Add("Berlin Sans FB Demi", str & "\fswiss\fprq2\fcharset0 Berlin Sans FB Demi;}")
        tmp.Add("Bernard MT Condensed", str & "\froman\fprq2\fcharset0 Bernard MT Condensed;}")
        tmp.Add("Bodoni MT Poster Compressed", str & "\froman\fprq2\fcharset0 Bodoni MT Poster Compressed;}")
        tmp.Add("Book Antiqua", str & "\froman\fprq2\fcharset0 Book Antiqua;}")
        tmp.Add("Bookman Old Style", str & "\froman\fprq2\fcharset0 Bookman Old Style;}")
        tmp.Add("Bookshelf Symbol 7", str & "\fnil\fprq2\fcharset2 Bookshelf Symbol 7;}")
        tmp.Add("Britannic Bold", str & "\fswiss\fprq2\fcharset0 Britannic Bold;}")
        tmp.Add("Broadway", str & "\fdecor\fprq2\fcharset0 Broadway;}")
        tmp.Add("Brush Script MT", str & "\fscript\fprq2\fcharset0 Brush Script MT;}")
        tmp.Add("Californian FB", str & "\froman\fprq2\fcharset0 Californian FB;}")
        tmp.Add("Centaur", str & "\froman\fprq2\fcharset0 Centaur;}")
        tmp.Add("Century", str & "\froman\fprq2\fcharset0 Century;}")
        tmp.Add("Century Gothic", str & "\fswiss\fprq2\fcharset0 Century Gothic;}")
        tmp.Add("Chiller", str & "\fdecor\fprq2\fcharset0 Chiller;}")
        tmp.Add("Colonna MT", str & "\fdecor\fprq2\fcharset0 Colonna MT;}")
        tmp.Add("Comic Sans MS", str & "\fscript\fprq2\fcharset0 Comic Sans MS;}")
        tmp.Add("Cooper Black", str & "\froman\fprq2\fcharset0 Cooper Black;}")
        tmp.Add("Courier New", str & "\fmodern\fprq1\fcharset0 Courier New;}")
        tmp.Add("Estrangelo Edessa", str & "\fscript\fprq2\fcharset0 Estrangelo Edessa;}")
        tmp.Add("Footlight MT Light", str & "\froman\fprq2\fcharset0 Footlight MT Light;}")
        tmp.Add("Freestyle Script", str & "\fscript\fprq2\fcharset0 Freestyle Script;}")
        tmp.Add("Garamond", str & "\froman\fprq2\fcharset0 Garamond;}")
        tmp.Add("Georgia", str & "\froman\fprq2\fcharset0 Georgia;}")
        tmp.Add("Haettenschweiler", str & "\fswiss\fprq2\fcharset0 Haettenschweiler;}")
        tmp.Add("Harlow Solid Italic", str & "\fdecor\fprq2\fcharset0 Harlow Solid Italic;}")
        tmp.Add("Harrington", str & "\fdecor\fprq2\fcharset0 Harrington;}")
        tmp.Add("High Tower Text", str & "\froman\fprq2\fcharset0 High Tower Text;}")
        tmp.Add("Impact", str & "\fswiss\fprq2\fcharset0 Impact;}")
        tmp.Add("Informal Roman", str & "\fscript\fprq2\fcharset0 Informal Roman;}")
        tmp.Add("Jokerman", str & "\fdecor\fprq2\fcharset0 Jokerman;}")
        tmp.Add("Juice ITC", str & "\fdecor\fprq2\fcharset0 Juice ITC;}")
        tmp.Add("Kristen ITC", str & "\fscript\fprq2\fcharset0 Kristen ITC;}")
        tmp.Add("Kunstler Script", str & "\fscript\fprq2\fcharset0 Kunstler Script;}")
        tmp.Add("Lucida Bright", str & "\froman\fprq2\fcharset0 Lucida Bright;}")
        tmp.Add("Lucida Calligraphy", str & "\fscript\fprq2\fcharset0 Lucida Calligraphy;}")
        tmp.Add("Lucida Console", str & "\fmodern\fprq1\fcharset0 Lucida Console;}")
        tmp.Add("Lucida Fax", str & "\froman\fprq2\fcharset0 Lucida Fax;}")
        tmp.Add("Lucida Handwriting", str & "\fscript\fprq2\fcharset0 Lucida Handwriting;}")
        tmp.Add("Lucida Sans Unicode", str & "\fswiss\fprq2\fcharset0 Lucida Sans Unicode;}")
        tmp.Add("Magneto", str & "\fdecor\fprq2\fcharset0 Magneto;}")
        tmp.Add("Marlett", str & "\fnil\fprq2\fcharset2 Marlett;}")
        tmp.Add("Matura MT Script Capitals", str & "\fscript\fprq2\fcharset0 Matura MT Script Capitals;}")
        tmp.Add("Microsoft Sans Serif", str & "\fswiss\fprq2\fcharset0 Microsoft Sans Serif;}")
        tmp.Add("Mistral", str & "\fscript\fprq2\fcharset0 Mistral;}")
        tmp.Add("Modern", str & "\froman\fprq2\fcharset255 Modern;}")
        tmp.Add("Modern No. 20", str & "\froman\fprq2\fcharset0 Modern No. 20;}")
        tmp.Add("Monotype Corsiva", str & "\fscript\fprq2\fcharset0 Monotype Corsiva;}")
        tmp.Add("MS Reference Sans Serif", str & "\fswiss\fprq2\fcharset0 MS Reference Sans Serif;}")
        tmp.Add("MS Reference Specialty", str & "\fnil\fprq2\fcharset2 MS Reference Specialty;}")
        tmp.Add("MT Extra", str & "\froman\fprq2\fcharset2 MT Extra;}")
        tmp.Add("Niagara Engraved", str & "\fdecor\fprq2\fcharset0 Niagara Engraved;}")
        tmp.Add("Niagara Solid", str & "\fdecor\fprq2\fcharset0 Niagara Solid;}")
        tmp.Add("Old English Text MT", str & "\fscript\fprq2\fcharset0 Old English Text MT;}")
        tmp.Add("Onyx", str & "\fdecor\fprq2\fcharset0 Onyx;}")
        tmp.Add("Palatino Linotype", str & "\froman\fprq2\fcharset0 Palatino Linotype;}")
        tmp.Add("Parchment", str & "\fscript\fprq2\fcharset0 Parchment;}")
        tmp.Add("Playbill", str & "\fdecor\fprq2\fcharset0 Playbill;}")
        tmp.Add("Poor Richard", str & "\froman\fprq2\fcharset0 Poor Richard;}")
        tmp.Add("Ravie", str & "\fdecor\fprq2\fcharset0 Ravie;}")
        tmp.Add("Showcard Gothic", str & "\fdecor\fprq2\fcharset0 Showcard Gothic;}")
        tmp.Add("Snap ITC", str & "\fdecor\fprq2\fcharset0 Snap ITC;}")
        tmp.Add("Stencil", str & "\fdecor\fprq2\fcharset0 Stencil;}")
        tmp.Add("Symbol", str & "\froman\fprq2\fcharset2 Symbol;}")
        tmp.Add("Tahoma", str & "\fswiss\fprq2\fcharset0 Tahoma;}")
        tmp.Add("Tempus Sans ITC", str & "\fdecor\fprq2\fcharset0 Tempus Sans ITC;}")
        tmp.Add("Times New Roman", str & "\froman\fprq2\fcharset0 Times New Roman;}")
        tmp.Add("Trebuchet MS", str & "\fswiss\fprq2\fcharset0 Trebuchet MS;}")
        tmp.Add("Verdana", str & "\fswiss\fprq2\fcharset0 Verdana;}")
        tmp.Add("Viner Hand ITC", str & "\fscript\fprq2\fcharset0 Viner Hand ITC;}")
        tmp.Add("Vivaldi", str & "\fscript\fprq2\fcharset0 Vivaldi;}")
        tmp.Add("Vladimir Script", str & "\fscript\fprq2\fcharset0 Vladimir Script;}")
        tmp.Add("Webdings", str & "\froman\fprq2\fcharset2 Webdings;}")
        tmp.Add("Wide Latin", str & "\froman\fprq2\fcharset0 Wide Latin;}")
        tmp.Add("Wingdings", str & "\fnil\fprq2\fcharset2 Wingdings;}")
        tmp.Add("Wingdings 2", str & "\froman\fprq2\fcharset2 Wingdings 2;}")
        tmp.Add("Wingdings 3", str & "\froman\fprq2\fcharset2 Wingdings 3;}")
        tmp.Add("ZWAdobeF", str & "\fnil\fprq2\fcharset0 ZWAdobeF;}")

        Return tmp

    End Function

    'Function for eliminating Font Initialization RTF's Code
    Private Function RTFFontsElimination(ByVal RTF As String) As String

        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim j As Integer = Len(RTF)
        Dim l As Integer = 0
        Dim tmpRTF As String
        Dim fontString As String
        Dim fontComp As Boolean
        Dim fontRefID As String

        While (i <= j)

            If Not i = 0 And fontComp = False Then
                i -= 1
            End If

            'to get the occurence of font initialization starting string
            If Not RTF.IndexOf("{", i) = -1 Then

                i = RTF.IndexOf("{", i)

            End If

            'to get the occurence of font intialization ending string
            If Not RTF.IndexOf(fontEndString, i) = -1 Then

                k = RTF.IndexOf(fontEndString, i)

            End If

            'Removing the font intialization string from rtf
            If Not (RTF.IndexOf("{", i) = -1 Or RTF.IndexOf(fontEndString, i) = -1) Then

                fontRefID = RTF.Substring(i + 2, 2) 'font's reference id e.g. "f0...fn"
                RTF = RTF.Remove(i, (k + 2 + Len(fontEndString)) - i)

                'Placing the font intialization string for all rtf in a single hashtable
                If Not RTF.Substring(0, 1) = "}" Then

                    tmpRTF = RTF.Substring(0, RTF.IndexOf(";}")) 'Placing the font name in a temporary string
                    RTF = RTF.Remove(0, RTF.IndexOf(";}") + 2) 'Removing the remaining part of selected font's intialization

                    While l <= Len(tmpRTF)

                        If IsNumeric(tmpRTF.Substring(l, 1)) Then
                            tmpRTF = tmpRTF.Remove(l, 1) 'Removing if any extra character from temporary font string
                        Else
                            Exit While
                        End If

                    End While

                    tmpRTF = NormalizeString(tmpRTF)  'Removing blank spaces from right and left of the font name string

                    _FontCollection = InitializeFonts()

                    If Not _FontTable.Contains(tmpRTF) Then ' Checking whether the font is already intialized
                        _FontNum += 1 'Setting font intialization reference id e.g. "f0....fn"
                        _FontTable.Add(tmpRTF, _FontNum) 'Adding font to font table 
                        RTF = RTF.Replace(fontRefID, "f" & _FontNum) ' Replacing the font reference id with the new intialized id
                        fontString = CStr(_FontCollection.Item(tmpRTF)) 'Getting font intialization code from collection
                        fontString = fontString.Replace("{\f", "{\f" & _FontNum) 'placing font reference id 
                        _FontCodeStrings.Add(fontString) 'Adding font intialization code to use with upcoming rtfs
                    Else
                        'If font is already contained and intialized in the font table then just replacing font's reference id in rtf
                        RTF = RTF.Replace(fontRefID, "f" & CStr(_FontTable.Item(tmpRTF)))
                    End If

                End If

                j = Len(RTF)

            Else

                fontComp = True

            End If

            i += 1

        End While

        If (RTF.Length > 0) Then RTF = RTF.Remove(0, 1)

        Return RTF

    End Function

    Private Function RTFColorTableElimination(ByVal RTF As String) As String

        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim colorCount As Integer
        Dim colorini As New ArrayList

        If RTF.IndexOf(colorTblString) > 0 Then

            RTF = RTF.Remove(0, RTF.IndexOf(colorTblString) + Len(colorTblString))

            If Not _ColorTable.Count < 1 Then

                For i = 0 To Len(RTF)

                    If Not i >= Len(RTF) - Len(colorCallString) Then

                        If RTF.Substring(i, Len(colorCallString)) = colorCallString Then

                            colorini.Add(RTF.Substring(i + Len(colorCallString), 1))

                        End If

                    End If

                Next

                colorini.Sort()

                i = 0

                While i <= colorini.Count - 1
                    If CInt(colorini(i)) <= _ColorTable.Count Then
                        colorini.RemoveAt(i)
                    Else
                        i += 1
                    End If
                End While

                i = 0
                If Not colorini.Count < 1 Then
                    colorini.Sort()
                    RTF = RTF.Replace(colorCallString & CStr(colorini(i)), colorCallString & 0)
                End If

            End If

            i = 0

            While i <= Len(RTF)

                If RTF.Substring(0, 4) = "\red" Then

                    j += 1

                    If Not _ColorTable.ContainsValue(RTF.Substring(0, RTF.IndexOf(";") + 1)) Then
                        _ColorTable.Add(_ColorTable.Values.Count + 1, RTF.Substring(0, RTF.IndexOf(";") + 1))
                        RTF = RTF.Replace(colorCallString & j, colorCallString & _ColorTable.Values.Count)
                    End If
                    RTF = RTF.Remove(0, RTF.IndexOf(";") + 1)

                End If

                i += 1

            End While

            If RTF.Substring(0, 1) = "}" Then

                RTF = RTF.Remove(0, 1)

            End If

        End If

        Return RTF

    End Function

    Private Function NormalizeString(ByRef rtfToNormalize As String) As String
        Dim b() As Char = New Char(3) {}
        b(0) = ControlChars.Cr
        b(1) = ControlChars.Lf
        b(2) = ControlChars.Lf
        rtfToNormalize = rtfToNormalize.Trim(b)
        Return rtfToNormalize
    End Function

    Private Function RemoveExtraBraces(ByRef rtfTT As String) As String

        Dim rtfToTrim As New StringBuilder(rtfTT)
        'Dim rtfTemp As New StringBuilder(rtfTT)

        Dim braceStack As New Stack(10)
        Dim openingBrace As Char = Convert.ToChar("{")
        Dim closingBrace As Char = Convert.ToChar("}")
        Dim i As Integer
        Dim endLimit As Integer = rtfToTrim.Length - 1
        For i = 0 To endLimit - 1
            Dim currentChar As Char = rtfToTrim.Chars(i)
            If (currentChar = closingBrace) Then
                If (braceStack.Count > 0) Then
                    braceStack.Pop()
                Else
                    rtfToTrim = rtfToTrim.Remove(i, 1)
                    endLimit -= 1
                End If

            ElseIf (currentChar = openingBrace) Then
                braceStack.Push(openingBrace)
            End If
        Next

        Return rtfToTrim.ToString
    End Function


#End Region

End Class

#Region "....................Enumerations "

Public Enum TextAlignment

    Left = 0
    Right = 1
    Centre = 2

End Enum

Public Enum PageLayout
    Portrait = 0
    Lanscape
End Enum

#End Region