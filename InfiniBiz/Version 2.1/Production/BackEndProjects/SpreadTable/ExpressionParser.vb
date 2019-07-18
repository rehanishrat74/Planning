Option Explicit On 

Imports DirectedGraph

Public Class ExpressionParser
#Region "Private Members"
    Private Lexer As ExpressionLexer
    Private Expressions As ArrayList
    Private CurrentCell As Cell
    Private LastCell As Cell
    Private depGraph As TabularGraph
#End Region
#Region "Public Members"
    Public Delegate Function GetCellValue(ByVal Row As Integer, ByVal Column As Integer) As String
    Public Delegate Function GetColumnNumber(ByVal ColumnName As String) As Integer
    Public Delegate Sub FunctionCall(ByVal FunctionName As String, ByVal ParameterList As ArrayList, ByRef ReturnValue As String)
    Public GetCellValue2 As GetCellValue
    Public GetColumnNumber2 As GetColumnNumber
    Public FunctionCall2 As FunctionCall
#End Region
#Region "Constructor"
    Public Sub New(ByVal Expression As String, ByVal graph As TabularGraph)
        Me.Lexer = New ExpressionLexer(Expression)
        depGraph = graph
    End Sub
#End Region
#Region "Public Methods"
    Public Function Parse(ByVal CurrentCell As Cell) As String
        If Not Me.CurrentCell Is Nothing Then LastCell = Me.CurrentCell
        Me.CurrentCell = CurrentCell
        Lexer.StopEmission()
        Parse = ExpressionOptional()
        Lexer.StartEmission()
        If Not Lexer.EndOfStream Then Throw New System.Exception("Parse Error")
        Me.CurrentCell = LastCell
    End Function
    Public Function Parse(ByVal CurrentCell As Cell, ByRef CompiledExpression As String) As String
        If Not Me.CurrentCell Is Nothing Then LastCell = Me.CurrentCell
        Me.CurrentCell = CurrentCell
        Parse = ExpressionOptional()
        If Not Lexer.EndOfStream Then Throw New System.Exception("Parse Error")
        Me.CurrentCell = LastCell
        CompiledExpression = Lexer.Emission
    End Function
    Public Function CompileExpression(ByVal CurrentCell As Cell) As String
        If Not Me.CurrentCell Is Nothing Then LastCell = Me.CurrentCell
        Me.CurrentCell = CurrentCell
        ExpressionOptional()
        If Not Lexer.EndOfStream Then Throw New System.Exception("Parse Error")
        Me.CurrentCell = LastCell
        Return Lexer.Emission
    End Function
#End Region
#Region "Recursive Descent - Parser Code"
    Private Function ExpressionListOptional() As ArrayList
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.LeftSquareBracket, TokenType.PlusMinusOperator, TokenType.Hash
                ExpressionListOptional = ExpressionList()
            Case Else
                ExpressionListOptional = New ArrayList
        End Select
    End Function
    Private Function ExpressionList() As ArrayList
        ExpressionList = New ArrayList
        ExpressionList(ExpressionList)
    End Function
    Private Sub ExpressionList(ByRef List As ArrayList)
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.PlusMinusOperator, TokenType.Hash
                Dim str As String = Expression()
                List.Add(str)
                ExpressionListRestOptional(List)
            Case TokenType.LeftSquareBracket
                Dim cells As ArrayList = GetCellsFromRange(CellRangeSpecifier)
                List.AddRange(cells)
                ExpressionListRestOptional(List)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Sub
    Private Sub ExpressionListRestOptional(ByRef List As ArrayList)
        Select Case Lexer.NextTokenType
            Case TokenType.Comma
                Lexer.Advance()
                ExpressionList(List)
        End Select
    End Sub
    Private Function ExpressionOptional() As String
        Select Case Lexer.NextTokenType
            Case TokenType.Identifier, TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.PlusMinusOperator, TokenType.Hash
                ExpressionOptional = Expression()
        End Select
    End Function
    Private Function Expression() As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.PlusMinusOperator, TokenType.Hash
                Expression = PlusMinusExpression()
                ExpressionRestOptional(Expression)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Sub ExpressionRestOptional(ByRef Operand As String)
        Select Case Lexer.NextTokenType
            Case TokenType.ConcatinationOperator
                Lexer.Advance()
                Operand = Operand & Expression()
        End Select
    End Sub
    Private Function PlusMinusExpression() As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.PlusMinusOperator, TokenType.Hash
                PlusMinusExpression = Term()
                PlusMinusExpressionRestOptional(PlusMinusExpression)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Sub PlusMinusExpressionRestOptional(ByRef Operand As String)
        Select Case Lexer.NextTokenType
            Case TokenType.PlusMinusOperator
                Lexer.Advance()
                If Lexer.CurrentToken.Lexeme = "+" Then
                    Operand = CStr(Val2(Operand) + Val2(PlusMinusExpression()))
                ElseIf Lexer.CurrentToken.Lexeme = "-" Then
                    Operand = CStr(Val2(Operand) - Val2(PlusMinusExpression()))
                End If
        End Select
    End Sub
    Private Function Term() As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.PlusMinusOperator, TokenType.Hash
                Term = PowerExpression()
                TermRestOptional(Term)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Sub TermRestOptional(ByRef Operand As String)
        Select Case Lexer.NextTokenType
            Case TokenType.MultiplyDivideOperator
                Lexer.Advance()
                If Lexer.CurrentToken.Lexeme = "*" Then
                    Operand = CStr(Val2(Operand) * Val2(Term()))
                ElseIf Lexer.CurrentToken.Lexeme = "/" Then
                    Dim Operand2 As String = Term()
                    If Val2(Operand2) = 0 Then
                        Operand = "0"
                    Else
                        Operand = CStr(Val2(Operand) / Val2(Operand2))
                    End If
                End If
        End Select
    End Sub
    Private Function PowerExpression() As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.PlusMinusOperator, TokenType.Hash
                PowerExpression = Factor()
                PowerExpressionRestOptional(PowerExpression)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Sub PowerExpressionRestOptional(ByRef Operand As String)
        Select Case Lexer.NextTokenType
            Case TokenType.PowerOperator
                Lexer.Advance()
                Operand = CStr(Val2(Operand) ^ Val2(PowerExpression()))
        End Select
    End Sub
    Private Function Factor() As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.Identifier, TokenType.Hash
                Factor = PrimaryExpression()
            Case TokenType.PlusMinusOperator
                Lexer.Advance()
                If Lexer.CurrentToken.Lexeme = "+" Then
                    Factor = PrimaryExpression()
                Else
                    Factor = CStr(-Val2(PrimaryExpression()))
                End If
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function CellSpecifier() As ArrayList '***not being used anywhere
        Select Case Lexer.NextTokenType
            Case TokenType.Identifier, TokenType.LeftRoundBracket, TokenType.RowKeyword, TokenType.ColumnKeyword, TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral, TokenType.PlusMinusOperator
                Expression()
            Case TokenType.LeftSquareBracket
                Return GetCellsFromRange(CellRangeSpecifier)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function CellRangeSpecifier() As CellRange
        CellRangeSpecifier = New CellRange
        Select Case Lexer.NextTokenType
            Case TokenType.LeftSquareBracket
                Lexer.Advance()
                CellRangeSpecifier.StartCell = CellReference()
                Lexer.Match(TokenType.Colon)
                CellRangeSpecifier.EndCell = CellReference()
                Lexer.Match(TokenType.RightSquareBracket)
        End Select
    End Function
    Private Function CellReference() As Cell
        Dim Row As Integer, Column As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.RowKeyword
                Row = RowReference()
                Column = ColumnReferenceOptional()
            Case TokenType.ColumnKeyword
                Row = CurrentCell.Row
                Column = ColumnReference()
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
        CellReference = New Cell(Row, Column)
        CellReference.Value = CellValue(Row, Column)
        depGraph.AddEdge(depGraph.item(Row, Column), depGraph.item(CurrentCell.Row, CurrentCell.Column))
    End Function
    Private Function RowReference() As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.RowKeyword
                Lexer.Advance()
                RowReference = RowIndex()
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function ColumnReference() As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.ColumnKeyword
                Lexer.Advance()
                ColumnReference = Index(CChar("C"))
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function ColumnReferenceOptional() As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.ColumnKeyword
                ColumnReferenceOptional = ColumnReference()
            Case Else
                ColumnReferenceOptional = CurrentCell.Column
        End Select
    End Function
    Private Function RowIndex() As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.IntegerLiteral, TokenType.LeftSquareBracket
                RowIndex = Index(CChar("R"))
            Case TokenType.LeftCurlyBracket
                Lexer.StopEmission()
                Lexer.Advance()
                RowIndex = CInt(Val2(Expression()))
                Lexer.Match(TokenType.RightCurlyBracket)
                Lexer.StartEmission()
                Lexer.Emit(CStr(RowIndex))
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function Index(ByVal ReferenceType As Char) As Integer
        Select Case Lexer.NextTokenType
            Case TokenType.IntegerLiteral
                Lexer.Advance()
                Index = CInt(Val2(Lexer.CurrentToken.Lexeme))
            Case TokenType.LeftSquareBracket
                Lexer.Advance()
                If ReferenceType = "C" And Lexer.LookAhead.Type = TokenType.Identifier Then
                    Lexer.Match(TokenType.Identifier)
                    Index = GetColumnNumber2.Invoke(Lexer.CurrentToken.Lexeme)
                Else
                    Index = CInt(Val2(Expression))
                    If ReferenceType = "R" Then
                        Index += CurrentCell.Row
                    ElseIf ReferenceType = "C" Then
                        Index += CurrentCell.Column
                    End If
                End If
                Lexer.Match(TokenType.RightSquareBracket)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function PrimaryExpression() As String
        Select Case Lexer.NextTokenType
            Case TokenType.RowKeyword, TokenType.ColumnKeyword
                PrimaryExpression = CellReference.Value
            Case TokenType.IntegerLiteral, TokenType.FloatLiteral, TokenType.StringLiteral
                PrimaryExpression = Literal()
            Case TokenType.Identifier
                Lexer.Advance()
                PrimaryExpression = FunctionRest(Lexer.CurrentToken.Lexeme.ToUpper)
                'Dim FunctionName As String = Lexer.CurrentToken.Lexeme.ToUpper
                'If FunctionName = "COLUMN" Then
                '    Lexer.TakeBackLastEmission()
                '    Lexer.StopEmission()
                '    Lexer.Match(TokenType.LeftRoundBracket)
                '    PrimaryExpression = ExecuteFunction(FunctionName, ExpressionListOptional)
                '    Lexer.Match(TokenType.RightRoundBracket)
                '    Lexer.StartEmission()
                '    Lexer.Emit(PrimaryExpression)
                'Else
                '    Lexer.Match(TokenType.LeftRoundBracket)
                '    PrimaryExpression = ExecuteFunction(FunctionName, ExpressionListOptional)
                '    Lexer.Match(TokenType.RightRoundBracket)
                'End If
            Case TokenType.LeftRoundBracket
                Lexer.Advance()
                PrimaryExpression = Expression()
                Lexer.Match(TokenType.RightRoundBracket)
            Case TokenType.Hash
                Lexer.Advance()
                Dim Params As New ArrayList
                Params.Add(PrimaryExpression())
                PrimaryExpression = ExecuteFunction("GETROWNUMBER", Params)
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function FunctionRest(ByVal FunctionName As String) As String
        Select Case Lexer.NextTokenType
            Case TokenType.LeftRoundBracket
                Lexer.Match(TokenType.LeftRoundBracket)
                FunctionRest = ExecuteFunction(FunctionName, ExpressionListOptional)
                Lexer.Match(TokenType.RightRoundBracket)
            Case TokenType.LeftSquareBracket
                Dim AutoEmissionWasEnabled As Boolean = Lexer.IsAutoEmissionEnabled
                If AutoEmissionWasEnabled Then
                    Lexer.TakeBackLastEmission()
                    Lexer.StopEmission()
                End If
                Lexer.Match(TokenType.LeftSquareBracket)
                FunctionRest = ExecuteFunction(FunctionName, ExpressionListOptional)
                Lexer.Match(TokenType.RightSquareBracket)
                If AutoEmissionWasEnabled Then
                    Lexer.StartEmission()
                    Lexer.Emit(FunctionRest)
                End If
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function Literal() As String
        Select Case Lexer.NextTokenType
            Case TokenType.IntegerLiteral, TokenType.FloatLiteral
                Literal = NumericLiteral()
            Case TokenType.StringLiteral
                Lexer.Emit("'")
                Lexer.Advance()
                Lexer.Emit("'")
                Literal = Lexer.CurrentToken.Lexeme
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
    Private Function NumericLiteral() As String
        Select Case Lexer.NextTokenType
            Case TokenType.IntegerLiteral, TokenType.FloatLiteral
                Lexer.Advance()
                NumericLiteral = Lexer.CurrentToken.Lexeme
            Case Else
                Throw New System.Exception("Parse Error")
        End Select
    End Function
#End Region
#Region "Support Functions"
    Private Function GetCellsFromRange(ByVal Range As CellRange) As ArrayList
        Dim i As Integer, j As Integer
        Dim RowStep As Integer, ColumnStep As Integer
        If Range.StartCell.Row <= Range.EndCell.Row Then RowStep = 1 Else RowStep = -1
        If Range.StartCell.Column <= Range.EndCell.Column Then ColumnStep = 1 Else ColumnStep = -1
        GetCellsFromRange = New ArrayList
        For i = Range.StartCell.Row To Range.EndCell.Row Step RowStep
            For j = Range.StartCell.Column To Range.EndCell.Column Step ColumnStep
                GetCellsFromRange.Add(CellValue(i, j))
                depGraph.AddEdge(depGraph.item(i, j), depGraph.item(CurrentCell.Row, CurrentCell.Column))
            Next
        Next
    End Function
    Private Function ExecuteFunction(ByVal FunctionName As String, ByVal ParameterList As ArrayList) As String
        Select Case FunctionName
            Case "SUM"
                Return Sum(ParameterList)
            Case "COLUMN"
                Return CStr(CurrentCell.Column)
            Case "ROUND"
                Return CStr(Math.Round(Val2(ParameterList(0)), CInt(ParameterList(1))))
            Case "MIN"
                If (Val2(ParameterList(0)) >= Val2(ParameterList(1))) Then
                    Return CStr(ParameterList(1))
                Else
                    Return CStr(ParameterList(0))
                End If
            Case "MAX"
                If (Val2(ParameterList(0)) >= Val2(ParameterList(1))) Then
                    Return CStr(ParameterList(0))
                Else
                    Return CStr(ParameterList(1))
                End If
            Case "ROW"
                Return CStr(CurrentCell.Row)
            Case "ROWNAME"
                Return CellValue(CurrentCell.Row, 0).TrimStart(CChar("-"))
            Case Else
                FunctionCall2.Invoke(FunctionName, ParameterList, ExecuteFunction)
        End Select
    End Function
    Private Function Sum(ByVal ParameterList As ArrayList) As String
        Dim x As String
        Dim Sum2 As Single
        For Each x In ParameterList
            x = x.TrimEnd(CChar("%"))
            Sum2 += CSng(Val2(x))
        Next
        Return CStr(Sum2)
    End Function
    Private Function Val2(ByVal Str As Object) As Single
        Return CSng(Val(CStr(Str).TrimEnd(CChar("%"))))
    End Function
    Private Function CellValue(ByVal Row As Integer, ByVal column As Integer) As String
        If Not (Row = CurrentCell.Row And column = CurrentCell.Column) Then
            Return GetCellValue2.Invoke(Row, column)
        Else
            Throw New ApplicationException("Recursive Formula")
        End If
    End Function
#End Region
End Class
