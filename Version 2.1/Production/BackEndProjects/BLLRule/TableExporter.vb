Imports System.Text

Public Class TableExporter

#Region "Private Variables"

    Private _CellAlingment As TextAlignment = TextAlignment.Right
    Private _DefaultCellWidth As Integer = 2
    Private _RemainingCellsWidth As Integer = 2


#End Region

#Region "Constants"
    Const tableStringStart As String = "\trowd\trqc\trgaph25\trleft36\trbrdrt\brdrs\brdrw10 \trbrdrl\brdrs\brdrw10 \trbrdrb\brdrs\brdrw10 \trbrdrr\brdrs\brdrw10 " ' "\trowd\trgaph25\trleft36\trbrdrt\brdrs\brdrw10 \trbrdrl\brdrs\brdrw10 \trbrdrb\brdrs\brdrw10 \trbrdrr\brdrs\brdrw10 "
    Const tableStringEnd As String = "\pard\nowidctlpar \par "
    Const tableCellString As String = "\clbrdrt\brdrw15\brdrs\clbrdrl\brdrw15\brdrs\clbrdrb\brdrw15\brdrs\clbrdrr\brdrw15\brdrs\cellx"
    Const tableDefRowString As String = "\pard\intbl\qc\b\f0\fs14 " ' "\pard\intbl\b\f0\fs14 "
    Const tableRowString As String = "\pard\intbl\ql\f0\fs14 "  '"\pard\intbl\f0\fs14 "
#End Region

#Region "Public Functions"

    Public Function CreateTable(ByVal ds As DataSet, ByVal cellAlignment As TextAlignment, ByVal defCellWidth As Integer, ByVal remainingCellWidth As Integer) As String
        Dim dt As DataTable
        Dim resultantRTF As New StringBuilder(1024)

        If Not (CType(cellAlignment, Object) Is Nothing) Then
            _CellAlingment = cellAlignment
        End If
        _DefaultCellWidth = defCellWidth
        _RemainingCellsWidth = remainingCellWidth


        For Each dt In ds.Tables
            resultantRTF.Append(tableStringStart)
            resultantRTF.Append(CreateTable(dt, cellAlignment, defCellWidth, remainingCellWidth))
            resultantRTF.Append(tableStringEnd)
        Next
        resultantRTF.Append("\par ")
        Return resultantRTF.ToString

    End Function

    Private Function CreateTable(ByRef dt As DataTable, ByVal cellAlignment As TextAlignment, ByVal defCellWidth As Integer, ByVal remainingCellWidth As Integer) As String
        Dim resultantRTF As String
        If Not (CType(cellAlignment, Object) Is Nothing) Then
            _CellAlingment = cellAlignment
        End If
        _DefaultCellWidth = defCellWidth
        _RemainingCellsWidth = remainingCellWidth

        resultantRTF &= GetHeaderRow(dt)
        resultantRTF &= GetTableRows(dt, False)
        Return resultantRTF
    End Function

    Public Function CreateDataTable(ByRef dt As DataTable, ByVal cellAlignment As TextAlignment, ByVal defCellWidth As Integer, ByVal remainingCellWidth As Integer) As String
        Dim resultantRTF As String
        resultantRTF &= tableStringStart
        If Not (CType(cellAlignment, Object) Is Nothing) Then
            _CellAlingment = cellAlignment
        End If
        _DefaultCellWidth = defCellWidth
        _RemainingCellsWidth = remainingCellWidth
        resultantRTF &= GetHeaderRow(dt)
        resultantRTF &= GetTableRows(dt, False)
        resultantRTF &= tableStringEnd
        Return resultantRTF
    End Function

    Public Function GetHeaderRow(ByRef dt As DataTable) As String

        Dim resultantRTF As String = GetTableCellDefinition(dt)
        resultantRTF &= tableDefRowString
        Dim dc As DataColumn

        For Each dc In dt.Columns
            'Writing header row
            resultantRTF &= dc.ColumnName & "\cell "
        Next
        resultantRTF &= "\b0\row "
        Return resultantRTF
    End Function

    Public Function GetTableRows(ByRef dt As DataTable, ByVal includeDefinition As Boolean) As String

        Dim dr As DataRow
        Dim dc As DataColumn
        Dim CellTextFormat As String
        Dim resultantRTF As String

        If (includeDefinition) Then
            resultantRTF &= GetTableCellDefinition(dt)
        End If

        For Each dr In dt.Rows
            For Each dc In dt.Columns
                'resultantRTF &= dr.Item(dc) & "\cell "
                If dt.Columns.IndexOf(dc) = 0 Then
                    resultantRTF &= tableRowString
                    resultantRTF &= CStr(dr.Item(dc)) & "\cell "
                Else

                    Select Case _CellAlingment

                        Case TextAlignment.Centre

                            CellTextFormat = tableRowString.Replace("\ql", "\qc")
                            resultantRTF &= CellTextFormat

                        Case TextAlignment.Left

                            CellTextFormat = tableRowString
                            resultantRTF &= CellTextFormat

                        Case TextAlignment.Right

                            CellTextFormat = tableRowString.Replace("\ql", "\qr")
                            resultantRTF &= CellTextFormat

                    End Select

                    resultantRTF &= CStr(dr.Item(dc)) & "\cell "

                End If


            Next
            resultantRTF &= "\row "
        Next
        Return resultantRTF
    End Function

#End Region

#Region "Private Functions"

    Private Function GetTableCellDefinition(ByRef dt As DataTable) As String

        Dim i As Integer
        Dim j As Integer = 0
        Dim k As Integer = 10
        Dim str As String
        Dim dc As DataColumn
        For Each dc In dt.Columns
            If dt.Columns.IndexOf(dc) = 0 Then

                j += dc.ColumnName.Length + _DefaultCellWidth
                str = str & tableCellString & j & k

            Else

                j += dc.ColumnName.Length + _RemainingCellsWidth
                str = str & tableCellString & j & k

            End If
            'j += Val(dc.ColumnName.Length) + 3
            'str = str & tableCellString & j & k
        Next
        Return str
    End Function

#End Region

End Class
