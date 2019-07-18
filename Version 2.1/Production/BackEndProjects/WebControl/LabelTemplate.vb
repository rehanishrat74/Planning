#Region "Imports "
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Data
#End Region

Public Class LabelTemplate
    Implements ITemplate

#Region "Memebers"
    Private _id As String
    Private _columnName As String
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

    '<asp:Label CssClass="textBold" id="lblColumnTotalDay_0" runat="server" />
    Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn
        Dim lbl As New Label
        lbl.ID = _id
        lbl.Attributes.Add("class", _cssClass)
        If Not (_columnName Is Nothing) Then
            AddHandler lbl.DataBinding, AddressOf OnDataBind
        End If
        'lbl.DataBinding += New EventHandler(this.OnDataBinding)
        container.Controls.Add(lbl)
    End Sub

#End Region

    Private Sub OnDataBind(ByVal sender As Object, ByVal e As EventArgs)
        Dim lbl As Label = CType(sender, Label)
        Dim container As DataGridItem = CType(lbl.NamingContainer, DataGridItem)
        Dim drv As DataRowView = CType(container.DataItem, DataRowView)
        If Not (drv Is Nothing) Then
            ' Dim s As String = CType(drv.Item(0), String).ToString
            If (_columnName = "Industry Performance") Or (_columnName = "Heading") Or (_columnName = "Milestones") Or (_columnName = "Potential Customers") Then lbl.Width = Unit.Pixel(200) 'Else lbl.Width = Unit.Pixel(100)
            lbl.Text = drv.Item(_columnName)
        End If
    End Sub

    'If (_columnName = "Heading") Then lbl.Width = Unit.Pixel(200)

End Class
