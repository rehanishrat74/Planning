#Region "Imports "
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data
#End Region


Public Class TextBoxTemplate
    Implements ITemplate

#Region "Members"

    Private _columnName As String
    Private _id As String
    Private _cssClass As String

#End Region

#Region "Constructor"

    Public Sub New(ByVal id As String, ByVal columnName As String, ByVal cssClass As String)
        _id = id
        _columnName = columnName
        _cssClass = cssClass
    End Sub


#End Region

#Region "ITemplate Implementation "

    '   <input type="text" ID='txtDay_0' onfocus="HighlightRow(this)"
    '           onblur="CalculateTotals(this)" class="textbox" 
    '           Runat="server" MaxLength="2" 
    '           value='<%# DataBinder.Eval(Container.DataItem,"Mon1") %>' />
    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn

        Dim tb As New HtmlInputText
        tb.ID = _id
        tb.MaxLength = 10
        ' tb.Attributes.Add("class", _cssClass)
        AddHandler tb.DataBinding, AddressOf OnDataBinding
        container.Controls.Add(tb)


    End Sub

#End Region

    Private Sub OnDataBinding(ByVal sender As Object, ByVal e As EventArgs)
        Dim tb As HtmlInputText = CType(sender, HtmlInputText)
        Dim container As DataGridItem = CType(tb.NamingContainer, DataGridItem)
        Dim drv As DataRowView = CType(container.DataItem, DataRowView)
        'If IsDBNull(drv(_columnName)) Then
        '    tb.Value = ""
        'Else
        tb.Value = drv.Item(_columnName)
        'End If
        '((DataRowView)container.DataItem)[_colName].ToString()
    End Sub

End Class

