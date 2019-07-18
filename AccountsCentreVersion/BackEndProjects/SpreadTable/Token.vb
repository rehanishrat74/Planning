Option Explicit On 
Option Strict On

Public Class Token
    Public Type As TokenType
    Public Lexeme As String
#Region "Constructors"
    Public Sub New()
        Me.Type = TokenType.Unknown
        Me.Lexeme = ""
    End Sub
    Public Sub New(ByVal Type As TokenType)
        Me.Type = Type
        Me.Lexeme = ""
    End Sub
    Public Sub New(ByVal Type As TokenType, ByVal Lexeme As String)
        Me.Type = Type
        Me.Lexeme = Lexeme
    End Sub

#End Region
End Class

Public Enum TokenType
    LeftRoundBracket
    RightRoundBracket
    LeftSquareBracket
    RightSquareBracket
    LeftCurlyBracket
    RightCurlyBracket
    Hash
    Colon
    ConcatinationOperator
    Comma
    PowerOperator
    PlusMinusOperator
    MultiplyDivideOperator
    RowKeyword
    ColumnKeyword
    IntegerLiteral
    FloatLiteral
    StringLiteral
    Identifier
    Unknown
    EndOfSttream
End Enum