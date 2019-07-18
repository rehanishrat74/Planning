Option Explicit On 
Option Strict On

Public Class CellRange
    Public StartCell As Cell
    Public EndCell As Cell
    Public ReadOnly Property IsUnitCell() As Boolean
        Get
            If EndCell Is Nothing Then Return True
            If StartCell.Row = EndCell.Row And StartCell.Column = EndCell.Column Then Return True
            Return False
        End Get
    End Property
End Class
