Public Class TabularGraph
    Inherits AdjacencyList

    Protected _Rows As Integer
    Protected _Cols As Integer

    Public Property Rows() As Integer
        Get
            Return _Rows
        End Get
        Set(ByVal Value As Integer)
            _Rows = Value
        End Set
    End Property

    Public Property Cols() As Integer
        Get
            Return _Cols
        End Get
        Set(ByVal Value As Integer)
            _Cols = Value
        End Set
    End Property

    Public ReadOnly Property DepCellString(ByVal row As Integer, ByVal col As Integer) As String
        Get
            Return item(row, col).DependentCellsString
        End Get
    End Property

    Public ReadOnly Property AllDepCellString(ByVal row As Integer, ByVal col As Integer) As String
        Get
            Return item(row, col).AllDependentCellsString
        End Get
    End Property

    Default Public Overloads ReadOnly Property item(ByVal row As Integer, ByVal col As Integer) As GraphNode
        Get
            Return item((_Cols * row) + col)
        End Get
    End Property

    Public Sub New(ByVal rows As Integer, ByVal cols As Integer)
        _Rows = rows
        _Cols = cols
    End Sub

    Public Overloads Overrides Sub AddEdge(ByVal source As GraphNode, ByVal target As GraphNode)
        For i As Integer = 0 To source.EdgeCount - 1
            If source.EdgeByID(i).TargetNode Is target Then Return
        Next
        source.AddEdge(target)
    End Sub

End Class
