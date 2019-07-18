Option Explicit On 
Option Strict On

#Region " Imports "

Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Xml.XPath
Imports System.Text
Imports System.Text.Encoding

#End Region
Public Class RegExpLib


    Private APPLICATION_PATH As String = System.AppDomain.CurrentDomain.BaseDirectory & "\Data\XML\Catalog.xml" ' returns the web application path. e.g. C:\
    Private _CategoryId As Integer
    Private _ExpressionId As Integer
    'Private Shared _XmlDoc As XmlDocument
    Private _XmlDoc As XmlDocument
    Private _LastModified As Date

#Region "Contructors"
    Public Sub New()
        LoadRegExpLibrary()
    End Sub
#End Region

#Region "Properties"

    Private Property CategoryId() As Integer
        Get
            Return _CategoryId
        End Get
        Set(ByVal Value As Integer)
            _CategoryId = Value
        End Set
    End Property

    Private Property ExpressionId() As Integer
        Get
            Return _ExpressionId
        End Get
        Set(ByVal Value As Integer)
            _ExpressionId = Value
        End Set
    End Property

    Private ReadOnly Property Library() As XmlDocument
        Get
            Dim doc As New XmlDocument
            Dim currentTime As Date = File.GetLastWriteTime(APPLICATION_PATH)
            If (currentTime <> _LastModified) Then
                _LastModified = File.GetLastWriteTime(APPLICATION_PATH)
                doc.Load(APPLICATION_PATH)
                _XmlDoc = doc
            End If
            Return _XmlDoc
        End Get
    End Property

#End Region

    Public Function GetExpression(ByVal configurationString As String) As String
        Parse(configurationString)
        Dim expression As String = GetValue(CategoryId, ExpressionId)
        If (IsNothing(expression)) Then
            Throw New NoSuchExpresssionException(CategoryId & "," & ExpressionId)
        End If
        Return expression
    End Function


#Region "Private Methods "

    Private Sub Parse(ByVal configurationString As String)

        Dim categoryNumber As Integer = Integer.Parse(configurationString.Substring(0, 2))
        Dim expressionNumber As Integer = Integer.Parse(configurationString.Substring(2))
        If (categoryNumber < 1 Or categoryNumber > 99) Then
            Throw New InvalidCategoryException(categoryNumber)
        End If
        If (expressionNumber < 1 Or expressionNumber > 999) Then
            Throw New ExpresssionNotFoundException(expressionNumber)
        End If

        CategoryId = categoryNumber
        ExpressionId = expressionNumber

    End Sub

    Private Sub LoadRegExpLibrary()
        Dim doc As New XmlDocument
        doc.Load(APPLICATION_PATH)
        _XmlDoc = doc
    End Sub

    Private Function GetValue(ByVal categoryId As Integer, ByVal expressionId As Integer) As String

        ' Expression to return actual node
        '"/RegularExpressionsCatalog/Categories/Category[@id='1']/Expression[@id='1']/Pattern"
        Dim doc As XmlDocument = Library
        Dim nav As XPathNavigator = doc.DocumentElement.CreateNavigator()
        Dim exp As String = "//Categories/Category[@id='" & categoryId & "']/Expression[@id='" & expressionId & "']/Pattern/."
        Dim iterator As XPathNodeIterator = CType(nav.Evaluate(exp), XPathNodeIterator)
        Dim name As String
        Dim value As String
        While (iterator.MoveNext)
            value = iterator.Current.Value
        End While
        Return value
    End Function

#End Region


#Region "Private Exception Classes "

    Private Class InvalidCategoryException
        Inherits System.Exception

        Public Sub New(ByVal categoryNumber As Integer)
            MyBase.New("Invalid Category ID Specified (" & categoryNumber & ")")
        End Sub

    End Class

    Private Class ExpresssionNotFoundException
        Inherits System.Exception

        Public Sub New(ByVal expressionNumber As Integer)
            MyBase.New("Invalid Expression ID Specified (" & expressionNumber & ")")
        End Sub

    End Class

    Private Class NoSuchExpresssionException
        Inherits System.Exception

        Public Sub New(ByVal str As String)
            MyBase.New("No Such Expression Exists - " & str)
        End Sub

    End Class

#End Region


End Class