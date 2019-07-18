''' -----------------------------------------------------------------------------
''' Project	 : GraphDemo
''' Class	 : GraphNode
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     This class represents a node of a graph. Each adjacency list contains a list of such nodes.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.afaq]	2/3/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class GraphNode

#Region "Private Members"

    Private _NodeName As String
    Private _EdgeList As GraphEdgeList
    Private _VisitStatus As NodeVisitStatus

#End Region

#Region "Friend Properties"

    Friend Property VisitStatus() As NodeVisitStatus
        Get
            Return _VisitStatus
        End Get
        Set(ByVal Value As NodeVisitStatus)
            _VisitStatus = Value
        End Set
    End Property

#End Region

#Region "Public Properties"

    Public Property NodeName() As String
        Get
            Return _NodeName
        End Get
        Set(ByVal Value As String)
            _NodeName = Value
        End Set
    End Property

    Public ReadOnly Property EdgeCount() As Integer
        Get
            Return _EdgeList.Count
        End Get
    End Property

    Public ReadOnly Property EdgeByID(ByVal id As Integer) As GraphEdge
        Get
            Return _EdgeList.Item(id)
        End Get
    End Property

    Public ReadOnly Property DependentCellsString() As String
        Get
            Dim str As String = ""
            For i As Integer = 0 To Me.EdgeCount - 1
                str += Me.EdgeByID(i).TargetNode.NodeName & ";"
            Next
            If str.Length > 0 Then
                str = str.Substring(0, str.Length - 1)
            End If
            Return str
        End Get
    End Property

    Public ReadOnly Property AllDependentCellsString() As String
        Get
            Dim str As String = ""
            For i As Integer = 0 To Me.EdgeCount - 1
                str += Me.EdgeByID(i).TargetNode.NodeName & ";"
                Dim str1 As String = Me.EdgeByID(i).TargetNode.AllDependentCellsString
                If str1 <> "" Then
                    str += str1 & ";"
                End If
            Next
            If str.Length > 0 Then
                str = str.Substring(0, str.Length - 1)
            End If
            Return str
        End Get
    End Property

#End Region

#Region "Constructors"

    Friend Sub New()
        _EdgeList = New GraphEdgeList(Me)
        _VisitStatus = NodeVisitStatus.UnVisited
    End Sub

    Friend Sub New(ByVal Name As String)
        _NodeName = Name
        _EdgeList = New GraphEdgeList(Me)
        _VisitStatus = NodeVisitStatus.UnVisited
    End Sub

#End Region

#Region "Friend Methods"

    Friend Sub AddEdge(ByVal TargetNode As GraphNode)
        _EdgeList.Add(TargetNode)
    End Sub

#End Region

End Class

''' -----------------------------------------------------------------------------
''' Project	 : GraphDemo
''' Class	 : GraphNodeList
''' 
''' -----------------------------------------------------------------------------
''' <summary>
'''     A list of nodes containing the edges list to other nodes. Each adjacency list has a reference
'''     to such a list.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.afaq]	2/3/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class GraphNodeList

#Region "Private Members"

    Private _list As New ArrayList

#End Region

#Region "Public Properties"

    Default Public ReadOnly Property Item(ByVal id As Integer) As GraphNode
        Get
            Return CType(_list(id), GraphNode)
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return _list.Count
        End Get
    End Property

#End Region

#Region "Friend Methods"

    Friend Sub Add()
        _list.Add(New GraphNode)
    End Sub

    Friend Sub Add(ByVal Name As String)
        _list.Add(New GraphNode(Name))
    End Sub

    Friend Sub Add(ByVal Node As GraphNode)
        _list.Add(Node)
    End Sub

    Friend Sub Clear()
        _list.Clear()
    End Sub

#End Region

End Class

Friend Enum NodeVisitStatus

    UnVisited = 0
    PartiallyVisited
    Visited

End Enum