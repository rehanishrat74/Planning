''' -----------------------------------------------------------------------------
''' Project	 : GraphDemo
''' Class	 : AdjacencyList
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     Adjacency list is a data structure used to represent a directed graph. Algoritms are used
'''     on this list to identify dependency and cycles.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.afaq]	2/3/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class AdjacencyList

#Region "Private Members"

    Protected _ListName As String
    Protected _NodeList As GraphNodeList

#End Region

#Region "Public Properties"

    Public Property ListName() As String
        Get
            Return _ListName
        End Get
        Set(ByVal Value As String)
            _ListName = Value
        End Set
    End Property

    Public ReadOnly Property NodeCount() As Integer
        Get
            Return _NodeList.Count
        End Get
    End Property

    Default Public ReadOnly Property Item(ByVal id As Integer) As GraphNode
        Get
            Return CType(_NodeList.Item(id), GraphNode)
        End Get
    End Property

#End Region

#Region "Constructors"

    Public Sub New()
        _NodeList = New GraphNodeList
    End Sub

    Public Sub New(ByVal name As String)
        _ListName = name
        _NodeList = New GraphNodeList
    End Sub

#End Region

#Region "Public Methods"

    Public Sub AddNode(ByVal Name As String)
        _NodeList.Add(Name)
    End Sub

    Public Sub AddNode()
        _NodeList.Add()
    End Sub

    Public Overridable Sub AddEdge(ByVal source As GraphNode, ByVal target As GraphNode)
        source.AddEdge(target)
    End Sub

    Public Overridable Sub AddEdge(ByVal source As Integer, ByVal target As Integer)
        item(source).AddEdge(item(target))
    End Sub

    Public Sub Clear()
        _NodeList.Clear()
    End Sub

#End Region

#Region "Graph Operations"

    Public Function DetectCycles() As Boolean

        Dim cycles As Boolean = False

        For i As Integer = 0 To _NodeList.Count - 1
            For j As Integer = 0 To _NodeList.Count - 1
                _NodeList.Item(j).VisitStatus = NodeVisitStatus.UnVisited
            Next
            cycles = cycles Or TraverseDFS(_NodeList.Item(i))
        Next

        Return cycles

    End Function

    Public Function GetDependentNodes(ByVal node As GraphNode) As GraphNodeList

        Dim depNodes As New GraphNodeList

        For i As Integer = 0 To node.EdgeCount - 1
            depNodes.Add(node.EdgeByID(i).TargetNode)
        Next

        Return depNodes

    End Function

    Private Function TraverseDFS(ByVal node As GraphNode) As Boolean

        If node.VisitStatus = NodeVisitStatus.PartiallyVisited Then
            Return True
        End If

        node.VisitStatus = NodeVisitStatus.PartiallyVisited
        For i As Integer = 0 To node.EdgeCount - 1
            If TraverseDFS(node.EdgeByID(i).TargetNode) Then Return True
        Next
        node.VisitStatus = NodeVisitStatus.Visited
        Return False

    End Function

#End Region

End Class
