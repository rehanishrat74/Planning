Option Explicit On 
Option Strict On

Public Class ExpressionLexer
#Region "Private Members"
    Private Expression As String
    Private _Emission As String
    Private EmitTokens As Boolean
    Private NextToken As Token
    Private _CurrentToken As Token
    Private CurrentPosition As Integer
    Private LastEmissionPosition As Integer
#End Region
#Region "Public Properties"
    Public ReadOnly Property IsAutoEmissionEnabled() As Boolean
        Get
            Return EmitTokens
        End Get
    End Property
    Public ReadOnly Property Emission() As String
        Get
            Return _Emission
        End Get
    End Property
    Public ReadOnly Property CurrentToken() As Token
        Get
            Return _CurrentToken
        End Get
    End Property
    Public ReadOnly Property NextTokenType() As TokenType
        Get
            Return NextToken.Type
        End Get
    End Property
    Public ReadOnly Property LookAhead() As Token
        Get
            Return NextToken
        End Get
    End Property
    Public ReadOnly Property EndOfStream() As Boolean
        Get
            If NextToken.Type = TokenType.EndOfSttream Then Return True Else Return False
        End Get
    End Property
#End Region
#Region "Constructors"
    Public Sub New()
        EmitTokens = True
    End Sub
    Public Sub New(ByVal Expression As String)
        EmitTokens = True
        SetExpression(Expression)
    End Sub
#End Region
#Region "Public Methods"
    Public Sub StartEmission()
        EmitTokens = True
    End Sub
    Public Sub StopEmission()
        EmitTokens = False
    End Sub
    Public Sub SetExpression(ByVal Expression As String)
        Me.Expression = Expression
        CurrentPosition = 0
        NextToken = GetNextToken()
    End Sub
    Public Function Match(ByVal Type As TokenType) As Boolean
        If NextToken.Type = Type Then
            _CurrentToken = NextToken
            NextToken = GetNextToken()
            Emit(_CurrentToken.Lexeme)
            Return True
        Else
            MsgBox("Missing " & Type & vbCrLf & " in expression '" & Expression & "'")
            CurrentPosition = Expression.Length
            Return False
        End If
    End Function
    Public Sub Advance()
        _CurrentToken = NextToken
        NextToken = GetNextToken()
        Emit(_CurrentToken.Lexeme)
    End Sub
#End Region
#Region "Private Methods"
    Public Sub Emit(ByVal Text As String)
        If Not _Emission Is Nothing Then
            LastEmissionPosition = _Emission.Length
        End If
        If EmitTokens Then _Emission = _Emission & Text
    End Sub
    Public Sub TakeBackLastEmission()
        _Emission = _Emission.Substring(0, LastEmissionPosition)
    End Sub
    Private Function NextCharacter() As Char
        If CurrentPosition < Expression.Length Then
            Return CChar(Expression.Substring(CurrentPosition, 1))
        Else
            Return CType("", Char)
        End If
    End Function
    Private Function GetNextToken() As Token
        Dim TempToken As New Token
        If CurrentPosition > Expression.Length - 1 Then
            Return New Token(TokenType.EndOfSttream)
        End If
        Dim NC As String = NextCharacter()
        If Char.IsLetter(CChar(NC)) Then
            TempToken.Type = TokenType.Identifier
            TempToken.Lexeme += NextCharacter()
            CurrentPosition += 1
            While CurrentPosition < Expression.Length
                If Char.IsLetter(NextCharacter) Then
                    TempToken.Lexeme += NextCharacter()
                    CurrentPosition += 1
                Else
                    Exit While
                End If
            End While
            If TempToken.Lexeme = "R" Then TempToken.Type = TokenType.RowKeyword
            If TempToken.Lexeme = "C" Then TempToken.Type = TokenType.ColumnKeyword
            Return TempToken
        End If
        If Char.IsDigit(CChar(NC)) Then
            TempToken.Type = TokenType.IntegerLiteral
            TempToken.Lexeme += NextCharacter()
            CurrentPosition += 1
            GetIntegerLexeme(TempToken.Lexeme)
            If NextCharacter() = "." Then
                CurrentPosition += 1
                TempToken.Lexeme += "."
                TempToken.Type = TokenType.FloatLiteral
                GetIntegerLexeme(TempToken.Lexeme)
            End If
            Return TempToken
        End If
        Select Case NC
            Case "("
                CurrentPosition += 1
                Return New Token(TokenType.LeftRoundBracket, "(")
            Case ")"
                CurrentPosition += 1
                Return New Token(TokenType.RightRoundBracket, ")")
            Case "["
                CurrentPosition += 1
                Return New Token(TokenType.LeftSquareBracket, "[")
            Case "]"
                CurrentPosition += 1
                Return New Token(TokenType.RightSquareBracket, "]")
            Case "{"
                CurrentPosition += 1
                Return New Token(TokenType.LeftCurlyBracket, "{")
            Case "}"
                CurrentPosition += 1
                Return New Token(TokenType.RightCurlyBracket, "}")
            Case "#"
                CurrentPosition += 1
                Return New Token(TokenType.Hash, "#")
            Case ":"
                CurrentPosition += 1
                Return New Token(TokenType.Colon, ":")
            Case ","
                CurrentPosition += 1
                Return New Token(TokenType.Comma, ",")
            Case "&"
                CurrentPosition += 1
                Return New Token(TokenType.ConcatinationOperator, "&")
            Case "^"
                CurrentPosition += 1
                Return New Token(TokenType.PowerOperator, "^")
            Case "+", "-"
                Dim Lexeme As String = NextCharacter()
                CurrentPosition += 1
                Return New Token(TokenType.PlusMinusOperator, Lexeme)
            Case "*", "/"
                Dim Lexeme As String = NextCharacter()
                CurrentPosition += 1
                Return New Token(TokenType.MultiplyDivideOperator, Lexeme)
            Case "'" 'Rocognize Strings
                CurrentPosition += 1
                TempToken.Type = TokenType.StringLiteral
                While Not NextCharacter() = "'"
                    TempToken.Lexeme += NextCharacter()
                    CurrentPosition += 1
                End While
                CurrentPosition += 1
                Return TempToken
        End Select
        Return New Token(TokenType.Unknown)
    End Function
    Private Sub GetIntegerLexeme(ByRef Lexeme As String)
        While CurrentPosition < Expression.Length
            If IsNumeric(NextCharacter) Then
                Lexeme += NextCharacter()
                CurrentPosition += 1
            Else
                Exit While
            End If
        End While
    End Sub
#End Region
End Class
