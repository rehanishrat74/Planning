Public Interface ISpreadTable
    Inherits IDisposable
    Sub Calculate()
    Sub AddExpressionToCell(ByVal Expression As String, ByVal Row As Integer, ByVal Column As Integer)
    Sub AddExpressionToCell(ByVal Expression As String, ByVal Row As Integer, ByVal Column As Integer, ByVal EvaluateOnce As Boolean)
    Sub RemoveExpressionFromCell(ByVal Row As Integer, ByVal Column As Integer)
    Function IsExpression(ByVal Row As Integer, ByVal Column As Integer) As Boolean
    Function IsCellEditable(ByVal Row As Integer, ByVal Column As Integer) As Boolean

    Function WasExpression(ByVal Row As Integer, ByVal Column As Integer) As Boolean
    Function GetCellExpression(ByVal Row As Integer, ByVal Column As Integer) As String
    Function GetCompiledCellExpression(ByVal Row As Integer, ByVal Column As Integer) As String
    Function EvaluateCell(ByVal Row As Integer, ByVal Column As Integer) As String
    Function GetDepCellString(ByVal Row As Integer, ByVal Column As Integer) As String
    Function GetAllDepCellString(ByVal Row As Integer, ByVal Column As Integer) As String
    Function GetCellValue(ByVal Row As Integer, ByVal Column As Integer) As String
    Function GetColumnNumber(ByVal ColumnName As String) As Integer
    Sub FunctionCall_Handler(ByVal FunctionName As String, ByVal ParameterList As ArrayList, ByRef ReturnValue As String)
End Interface
