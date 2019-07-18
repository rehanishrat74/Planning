Option Explicit On 
Option Strict On

Public Class Cell
    Public Row As Integer
    Public Column As Integer
    Public Value As String
    Public Evaluated As Boolean
    Public EvaluateOnce As Boolean
#Region "Constructors"
    Public Sub New()
        Row = 0
        Column = 0
        Value = ""
        Evaluated = False
    End Sub
    Public Sub New(ByVal Row As Integer, ByVal Column As Integer)
        Me.Row = Row
        Me.Column = Column
        Value = ""
        Evaluated = False
    End Sub
#End Region
End Class
