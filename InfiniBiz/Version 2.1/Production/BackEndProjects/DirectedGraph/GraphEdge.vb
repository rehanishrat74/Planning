''' -----------------------------------------------------------------------------
''' Project	 : GraphDemo
''' Class	 : GraphEdge
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     This class contains the destination node's reference. The source node has the reference
'''     of a list of such nodes.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.afaq]	2/3/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class GraphEdge

#Region "Private Members"

    Private _TargetNode As GraphNode
    Private _SourceNode As GraphNode

#End Region

#Region "Public Properties"

    Public ReadOnly Property TargetNode() As GraphNode
        Get
            Return _TargetNode
        End Get
    End Property

    Public ReadOnly Property SourceNode() As GraphNode
        Get
            Return _SourceNode
        End Get
    End Property

#End Region

#Region "Constructors"

    Friend Sub New(ByVal source As GraphNode, ByVal target As GraphNode)
        _SourceNode = source
        _TargetNode = target
    End Sub

#End Region

End Class

''' -----------------------------------------------------------------------------
''' Project	 : GraphDemo
''' Class	 : GraphEdgeList
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     A list of edges containing the destination nodes. The source node has the reference
'''     of this list.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.afaq]	2/3/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class GraphEdgeList

#Region "Private Members"

    Private _list As New ArrayList
    Private _sourcenode As GraphNode

#End Region

#Region "Public Properties"

    Default Public ReadOnly Property Item(ByVal id As Integer) As GraphEdge
        Get
            Return CType(_list(id), GraphEdge)
        End Get
    End Property

    Public ReadOnly Property SourceNode() As GraphNode
        Get
            Return _sourcenode
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return _list.Count
        End Get
    End Property

#End Region

#Region "Constructors"

    Friend Sub New(ByVal source As GraphNode)
        _sourcenode = source
    End Sub

#End Region

#Region "Friend Methods"

    Friend Sub Add(ByVal target As GraphNode)
        _list.Add(New GraphEdge(_sourcenode, target))
    End Sub

    Friend Sub Clear()
        _list.Clear()
    End Sub

#End Region

End Class