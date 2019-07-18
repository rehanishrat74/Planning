Option Explicit On 

Imports DirectedGraph

Public Class SpreadTable
    Inherits System.Data.DataTable
    Implements ISpreadTable
    Public Event FunctionCall(ByVal FunctionName As String, ByVal ParameterList As ArrayList, ByRef ReturnValue As String)

#Region "Private Members"
    Private DepGraph As TabularGraph
    Private OneTimeExpressions As Hashtable
    Private CellExpressions As Hashtable
    Private CellEditable As Hashtable
    Private Cells As Collection
    Protected CalculationFlag As Boolean
#End Region
#Region "Constructor"
    Public Sub New()
        Cells = New Collection
        CellExpressions = New Hashtable(CInt((Rows.Count * Columns.Count) / 4))
        OneTimeExpressions = New Hashtable(CInt((Rows.Count * Columns.Count) / 4))
        CalculationFlag = True
        CellEditable = New Hashtable(1000)
    End Sub
#End Region
#Region "Public Methods"
    Public Sub Calculate() Implements ISpreadTable.Calculate
        Try
            GenerateGraph()
            CalculationFlag = True
            Dim CurrentCell As Cell
            Dim Expression As String
            For Each CurrentCell In Cells
                CurrentCell.Evaluated = False
                Rows(CurrentCell.Row)(CurrentCell.Column) = "X"
            Next
            For Each CurrentCell In Cells
                Try
                    Rows(CurrentCell.Row)(CurrentCell.Column) = EvaluateCell(CurrentCell.Row, CurrentCell.Column)
                Catch ex As Exception
                    Rows(CurrentCell.Row)(CurrentCell.Column) = "Error: " & ex.Message
                    'Throw New ApplicationException("Error: " & ex.Message)
                End Try
            Next
            Dim TempCells As New Collection
            For Each CurrentCell In Cells
                If CurrentCell.EvaluateOnce Then
                    TempCells.Add(GetKey(CurrentCell.Row, CurrentCell.Column))
                End If
            Next
            Dim Key As String
            For Each Key In TempCells
                OneTimeExpressions.Add(Key, CellExpressions(Key))
                Cells.Remove(Key)
                CellExpressions.Remove(Key)
            Next
            CalculationFlag = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Function IsCellEditable(ByVal Row As Integer, ByVal Column As Integer) As Boolean Implements ISpreadTable.IsCellEditable

        Return CellEditable.Contains(GetKey(Row, Column))
    End Function
    Public Sub checkCellEditable(ByVal a As String, ByVal Row As Integer, ByVal Column As Integer)
        If IsCellEditable(Row, Column) Then
            CellEditable.Remove(GetKey(Row, Column))
        End If

        CellEditable.Add(GetKey(Row, Column), True)
    End Sub

    Public Sub AddExpressionToCell(ByVal Expression As String, ByVal Row As Integer, ByVal Column As Integer) Implements ISpreadTable.AddExpressionToCell
        If IsExpression(Row, Column) Then
            Cells.Remove(GetKey(Row, Column))
            CellExpressions.Remove(GetKey(Row, Column))
        End If
        Dim C As New Cell(Row, Column)
        Cells.Add(C, GetKey(Row, Column))
        CellExpressions.Add(GetKey(Row, Column), New Expression(Expression, Me, C))
    End Sub
    Public Sub AddExpressionToCell(ByVal Expression As String, ByVal Row As Integer, ByVal Column As Integer, ByVal EvaluateOnce As Boolean) Implements ISpreadTable.AddExpressionToCell
        If IsExpression(Row, Column) Then
            Cells.Remove(GetKey(Row, Column))
            CellExpressions.Remove(GetKey(Row, Column))
        End If
        Dim C As New Cell(Row, Column)
        C.EvaluateOnce = True
        Cells.Add(C, GetKey(Row, Column))
        CellExpressions.Add(GetKey(Row, Column), New Expression(Expression, Me, C))
    End Sub
    Public Sub RemoveExpressionFromCell(ByVal Row As Integer, ByVal Column As Integer) Implements ISpreadTable.RemoveExpressionFromCell
        If IsExpression(Row, Column) Then
            Cells.Remove(GetKey(Row, Column))
            CellExpressions.Remove(GetKey(Row, Column))
        End If
    End Sub
    Public Function IsExpression(ByVal Row As Integer, ByVal Column As Integer) As Boolean Implements ISpreadTable.IsExpression
        Return CellExpressions.Contains(GetKey(Row, Column))
    End Function
    Public Function WasExpression(ByVal Row As Integer, ByVal Column As Integer) As Boolean Implements ISpreadTable.WasExpression
        Return OneTimeExpressions.Contains(GetKey(Row, Column))
    End Function
    Public Function GetCellExpression(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.GetCellExpression
        If IsExpression(Row, Column) And CellExpressions.Contains(GetKey(Row, Column)) Then
            Return CType(CType(CellExpressions.Item(GetKey(Row, Column)), Expression).Text, String)
        Else
            Return ""
        End If
    End Function
    Public Function GetCompiledCellExpression(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.GetCompiledCellExpression
        If IsExpression(Row, Column) And CellExpressions.Contains(GetKey(Row, Column)) Then
            Return CType(CType(CellExpressions.Item(GetKey(Row, Column)), Expression).CompiledText, String)
        Else
            Return ""
        End If
    End Function
    Public Function EvaluateCell(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.EvaluateCell
        'If Row = 14 And Column = 14 Then
        '    MsgBox(CType(CellExpressions(GetKey(Row, Column)), Expression).Text)
        'End If
        Return CType(CellExpressions(GetKey(Row, Column)), Expression).Parse(DepGraph)
    End Function
    Public Function GetDepCellString(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.GetAllDepCellString
        Return DepGraph.DepCellString(Row, Column)
    End Function
    Public Function GetAllDepCellString(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.GetDepCellString
        Return DepGraph.AllDepCellString(Row, Column)
    End Function
#End Region
#Region "Private Methods"
    Private Function GetKey(ByVal Row As Integer, ByVal Column As Integer) As String
        Return Row & "," & Column
    End Function
    Private Function GetKey(ByVal cell As Cell) As Object
        Return GetKey(cell.Row, cell.Column)
    End Function
    Private Sub GenerateGraph()

        DepGraph = New TabularGraph(Me.Rows.Count, Me.Columns.Count)
        
        For i As Integer = 0 To Me.Rows.Count - 1
            For j As Integer = 0 To Me.Columns.Count - 1
                DepGraph.AddNode(i.ToString() & "-" & j.ToString())
            Next
        Next

    End Sub
#End Region
#Region "Data Table Events"
    Private Sub SpreadTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles MyBase.ColumnChanged
        If Not CalculationFlag Then Calculate()
    End Sub
#End Region
#Region "Parser Handlers"
    'Private Function GetCellValue2(ByVal Row As Integer, ByVal Column As Integer) As String
    '    If IsExpression(Row, Column) Then
    '        Dim c As Cell = CType(Cells(GetKey(Row, Column)), Cell)
    '        If Not c.Evaluated Then
    '            c.Evaluated = True
    '            Dim str As String = EvaluateCell(Row, Column)
    '            Return str
    '        Else
    '            Return Rows(Row)(Column)
    '        End If
    '    Else
    '        Return Rows(Row)(Column)
    '    End If
    '    Return ""
    'End Function
    Public Function GetCellValue(ByVal Row As Integer, ByVal Column As Integer) As String Implements ISpreadTable.GetCellValue
        If IsExpression(Row, Column) And CStr(Rows(Row)(Column)) = "X" Then
            Dim Value As String = EvaluateCell(Row, Column)
            Rows(Row)(Column) = Value
            Return Value
        End If
        Return CStr(Rows(Row)(Column))
    End Function
    Public Function GetColumnNumber(ByVal ColumnName As String) As Integer Implements ISpreadTable.GetColumnNumber
        Return Columns(ColumnName).Ordinal
    End Function
    Public Sub FunctionCall_Handler(ByVal FunctionName As String, ByVal ParameterList As ArrayList, ByRef ReturnValue As String) Implements ISpreadTable.FunctionCall_Handler
        RaiseEvent FunctionCall(FunctionName, ParameterList, ReturnValue)
    End Sub
#End Region
    Public Sub Compile()
        GenerateGraph()
        Dim Expr As Expression
        Dim ExprCell As Cell
        For Each ExprCell In Cells
            Expr = CType(CellExpressions(GetKey(ExprCell)), Expression)
            Expr.Compile(DepGraph)
        Next
    End Sub
End Class
