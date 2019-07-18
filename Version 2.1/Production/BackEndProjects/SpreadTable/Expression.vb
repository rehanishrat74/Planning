Imports DirectedGraph

Public Class Expression
#Region "Private Members"
    Private _ExpressionText As String
    Private _CompiledText As String
    Private _SpreadTable As ISpreadTable
    Private _AssociatedCell As Cell
    Private _Compiled As Boolean
    Private _depGraph As TabularGraph
#End Region
#Region "Properties"
    Public Property Text() As String
        Get
            Return _ExpressionText
        End Get
        Set(ByVal Value As String)
            ResetExpression()
            _ExpressionText = Value
        End Set
    End Property
    Public ReadOnly Property CompiledText() As String
        Get
            If _Compiled Then
                Return _CompiledText
            Else
                Return Compile(_depGraph)
            End If
        End Get
    End Property
    Public Property SpreadTable() As ISpreadTable
        Get
            Return _SpreadTable
        End Get
        Set(ByVal Value As ISpreadTable)
            _SpreadTable = Value
            _CompiledText = ""
            _Compiled = False
        End Set
    End Property
    Public Property AssociatedCell() As Cell
        Get
            Return _AssociatedCell
        End Get
        Set(ByVal Value As Cell)
            _AssociatedCell = Value
            _CompiledText = ""
            _Compiled = False
        End Set
    End Property
#End Region
#Region "Constructors"
    Public Sub New()
        ResetExpression()
    End Sub
    Public Sub New(ByVal ExpressionText As String)
        ResetExpression()
        _ExpressionText = ExpressionText
    End Sub
    Public Sub New(ByVal ExpressionText As String, ByVal Table As ISpreadTable)
        ResetExpression()
        _ExpressionText = ExpressionText
        _SpreadTable = Table
    End Sub
    Public Sub New(ByVal ExpressionText As String, ByVal Table As ISpreadTable, ByVal AssociatedCell As Cell)
        ResetExpression()
        _ExpressionText = ExpressionText
        _SpreadTable = Table
        _AssociatedCell = AssociatedCell
    End Sub
#End Region
#Region "Public Methods"
    Public Function Parse(ByVal graph As TabularGraph) As String
        _depGraph = graph
        Dim Parser As ExpressionParser
        If _Compiled Then
            Parser = New ExpressionParser(_CompiledText, _depGraph)
        Else
            Parser = New ExpressionParser(_ExpressionText, _depGraph)
        End If
        Parser.GetCellValue2 = AddressOf _SpreadTable.GetCellValue
        Parser.GetColumnNumber2 = AddressOf _SpreadTable.GetColumnNumber
        Parser.FunctionCall2 = AddressOf _SpreadTable.FunctionCall_Handler
        Dim Value As String = Parser.Parse(_AssociatedCell, _CompiledText)
        _Compiled = True
        Return Value
    End Function
    Public Function Compile(ByVal graph As TabularGraph) As String
        _depGraph = graph
        Dim Parser As New ExpressionParser(_ExpressionText, _depGraph)
        Parser.GetCellValue2 = AddressOf _SpreadTable.GetCellValue
        Parser.GetColumnNumber2 = AddressOf _SpreadTable.GetColumnNumber
        Parser.FunctionCall2 = AddressOf _SpreadTable.FunctionCall_Handler
        _CompiledText = Parser.CompileExpression(_AssociatedCell)
        _Compiled = True
        Return _CompiledText
    End Function
#End Region
#Region "Private Methods"
    Private Sub ResetExpression()
        _ExpressionText = ""
        _CompiledText = ""
        _Compiled = False
    End Sub
#End Region
End Class
