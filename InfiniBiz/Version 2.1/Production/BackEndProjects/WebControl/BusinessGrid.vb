
#Region "Imports "
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Drawing
Imports Infinilogic.Data
#End Region

' Modified by Saira 
' Date - 9/3/2006

<DefaultProperty("Text"), ToolboxData("<{0}:BusinessGrid runat=server></{0}:BusinessGrid>")> _
Public Class BusinessGrid
    Inherits System.Web.UI.WebControls.DataGrid


#Region "............        Instance  Members  ............."

    Private _topHeaderColor As String = "#C0C0C0"
    Dim _editable As Boolean = True
    Dim _autoGenerateBusinessGrid As Boolean = True
    'Private dt As DataTable
    Private dt As SpreadTable
#End Region

#Region "Constructor"

    Public Sub New()
        'Add default property values
        Me.AutoGenerateColumns = False
        Me.ShowFooter = True
        Me.Font.Bold = True
        Me.Font.Name = "Arial"
        Me.ForeColor = Color.Black
        Me.BackColor = Color.White
        Me.CellPadding = 6
        Me.CellSpacing = 0
        Me.BorderStyle = BorderStyle.Solid
        Me.BorderWidth = New Unit("1")
        Me.BorderColor = Color.Black
        Me.Width = New Unit("40%")
        Me.EnableViewState = False
    End Sub
#End Region

#Region "Properties "

    <Bindable(True), Category("Appearance"), DefaultValue("#C0C0C0")> _
    Property TopHeaderColor() As String
        Get
            Return _topHeaderColor
        End Get
        Set(ByVal Value As String)
            _topHeaderColor = Value
        End Set
    End Property

    Public Property Editable() As Boolean
        Get
            Return _editable
        End Get
        Set(ByVal Value As Boolean)
            _editable = Value
        End Set
    End Property

    Public Property AutoGenerateBusinessGrid() As Boolean
        Get
            Return _autoGenerateBusinessGrid
        End Get
        Set(ByVal Value As Boolean)
            _autoGenerateBusinessGrid = Value
        End Set
    End Property
#End Region

#Region "Event Handlers"
    Private Sub Grid_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SetAttributes()
    End Sub

    Private Sub Grid_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.PreRender
        'SetAttributes()
        RegisterClientScript()
    End Sub

    Private Sub Grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.DataBinding

        ' it assign the datatable to the instance member " dt "
        Dim view As DataView = CType(Me.DataSource, DataView)
        dt = CType(view.Table, SpreadTable)
        ' Generate Appropriate Columns 
        FillTemplates()
        Me.Attributes.Add("ColumnCount", Me.Columns.Count)
    End Sub

    Private Sub Grid_ItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles MyBase.ItemCreated
        Dim row As DataGridItem = e.Item
        Dim dg As DataGrid = CType(sender, DataGrid)
        Dim t As Table = CType(dg.Controls(0), Table)
        Dim totalWeeks As Integer '= this._RowDayCellsCount / 7
        Dim source As DataView = CType(Me.DataSource, DataView)


        row.Height = System.Web.UI.WebControls.Unit.Point(20)
        If (row.ItemType = ListItemType.Header) Then

            row.ID = "headerRow"
            ' create Top grouping header 
            Dim headerRow As New DataGridItem(row.ItemIndex - 1, 0, ListItemType.Header)
            headerRow.ID = "headerRow_2"
            headerRow.CssClass = "heading1"
            headerRow.Height = New Unit(20, UnitType.Pixel)

            '//Add header cell that spans totals and PASCodes columns
            Dim rightHeaderCell As TableCell = New TableCell
            rightHeaderCell.HorizontalAlign = HorizontalAlign.Center
            rightHeaderCell.BackColor = Color.FromName(_topHeaderColor)
            rightHeaderCell.ColumnSpan = 1
            rightHeaderCell.CssClass = "heading1"

        End If
        'dt = CType(Me.DataSource, DataView).Table.Clone
        If (row.ItemType = ListItemType.Item Or row.ItemType = ListItemType.AlternatingItem) Then
            row.Attributes.Add("Row", CStr(t.Rows.Count - 1))
            row.Attributes.Add("onClick", "HighlightRow(this);RowSelected(this)")
            'row.Attributes.Add("onkeyup", "HighlightRow(this);RowSelected(this)")
            If (Me.Editable) Then
                Dim strID As String
                If dt.Columns.Contains("ID") Then
                    strID = row.DataItem("ID")
                End If
                Dim s As String = e.Item.Attributes.Item("Expr")
                If (strID = "") Then

                    ' if the ID Column is Empty , then disable the row
                    ' it might be Total aur Headings Row , in the middle 
                    row.Attributes.Add("class", "itemtotal")
                    'row.Attributes.Add("onClick", "javascript:window.status='You cannot edit this row.'")
                Else
                    ' Otherwise Highlight row  on Click 
                    If (row.ItemType = ListItemType.Item) Then
                        row.Attributes.Add("class", "itemstyle")
                    Else
                        row.Attributes.Add("class", "alternatingitemstyle")
                    End If
                End If
                row.ID = CStr(t.Rows.Count - 1)
            Else
                ' Freeze Whole Grid (Disable whole grid)
                row.ID = CStr(t.Rows.Count - 1)
                row.Attributes.Add("class", "itemtotal")
            End If
        End If
        If (row.ItemType = ListItemType.Footer) Then
            row.ID = "footerrow" & t.Rows.Count.ToString
            'If Not (Me.Editable) Then
            'row.Cells(me.Columns.Count-1).FindControl (
            'End If
        End If
    End Sub

    Private Sub Grid_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles MyBase.ItemDataBound
        '   Handle row count totals - totalAcross int

        Dim row As DataGridItem = e.Item
        Dim rowNumber As Integer = row.DataSetIndex
        Dim i As Integer
        If (row.ItemType = ListItemType.Header) Then
            row.CssClass = "GridHeaderBar"
        End If
        If (row.ItemType = ListItemType.Item Or row.ItemType = ListItemType.AlternatingItem) Then

            ' get the row ID if its empty , the row is Uneditable
            Dim strID As String = ""
            If (Me.Editable) Then
                If dt.Columns.Contains("ID") Then
                    strID = row.DataItem("ID")
                    row.Attributes.Add("CategoryID", strID)
                End If
            End If

            Dim bg As BusinessGrid = CType(sender, BusinessGrid)
            Dim dv As DataView = CType(bg.DataSource, DataView)
            Dim st As ISpreadTable = dv.Table

            For i = 0 To row.Cells.Count - 1
                Dim cell As TableCell = CType(row.Cells(i), TableCell)
                Dim ctl As Control
                For Each ctl In cell.Controls
                    If (TypeOf (ctl) Is HtmlInputText) Then
                        'cell.Attributes.Add("title", "You can edit this Value.")
                        Dim tb As HtmlInputText = CType(ctl, HtmlInputText)

                        tb.Attributes.Add("Row", rowNumber)
                        tb.Attributes.Add("Col", i)
                        tb.Attributes.Add("Dependents", dt.GetAllDepCellString(rowNumber, i))
                        tb.Attributes.Add("onfocus", "SelectCell(" & rowNumber & "," & i & ");HighlightCurrentRow(" & rowNumber & ");")
                        tb.Attributes.Add("onkeydown", "SelectNextCell(" & rowNumber & "," & i & ");")
                        If st.IsExpression(rowNumber, i) Then
                            Dim str As String = st.GetCompiledCellExpression(rowNumber, i)
                            tb.Attributes.Add("Expr", Str)
                        End If
                        'it is for incomestatemt expences or any row tht is uneditable with no expression on it
                        If (st.IsCellEditable(rowNumber, i)) Then

                            tb.Attributes.Add("readonly", "true")
                            tb.Attributes.Add("class", "alternatingitemstyletextbox")

                            '    'If (Me.Editable = False) Then tb.Disabled = True :tb
                        ElseIf (strID = "" Or st.IsExpression(rowNumber, i) Or st.WasExpression(rowNumber, i)) Then
                            tb.Attributes.Add("readonly", "true")
                            tb.Attributes.Add("class", "itemtotaltextbox")
                        Else
                            If (row.ItemType = ListItemType.Item) Then
                                tb.Attributes.Add("class", "itemstyletextbox")
                            Else
                                tb.Attributes.Add("class", "alternatingitemstyletextbox")
                            End If
                            tb.Attributes.Add("onchange", "CellChanged(this);Calculate(" & rowNumber & "," & i & ")")  'this.value=this.firstChild.nodeValue;abc()")
                        End If

                        Try
                            Dim tbValue As Integer = 0
                            If (tb.Value <> "") Then tbValue = Integer.Parse(tb.Value)
                            ' making row total here, on this line 
                            ' then making column total  , on this line
                        Catch ex As Exception
                        End Try
                    ElseIf (TypeOf (ctl) Is Label) Then
                    Dim lbl As Label = CType(ctl, Label)
                    lbl.Attributes.Add("Row", rowNumber)
                    lbl.Attributes.Add("Col", i)
                    lbl.Attributes.Add("Dependents", dt.GetDepCellString(rowNumber, i))
                    lbl.Attributes.Add("value", 0)
                    If st.IsExpression(rowNumber, i) Then
                        Dim str As String = st.GetCompiledCellExpression(rowNumber, i)
                        lbl.Attributes.Add("Expr", str)
                    End If
                    lbl.Attributes.Add("class", "itemHeadingColumn")
                        End If  ' if ctl is HTMLInputText
                Next
            Next
        End If
    End Sub

#End Region

#Region "Private Helper Routines / Methods"
    Private Sub FillTemplates()
        If (_autoGenerateBusinessGrid) Then
            ' If Autogenerate is true then remove any design time columns 
            Me.Columns.Clear()

            Dim dr As DataRow
            Dim dc As DataColumn

            'For Each dr In dt.Rows
            For Each dc In dt.Columns
                Dim columnName As String = dc.Caption '.ColumnName
                If (dc.Ordinal = 0 Or dc.ColumnName = "Heading") Then
                    Dim tcRowTitle As New TemplateColumn
                    Dim lblRowTitle As New LabelTemplate(dc.Ordinal, dc.ColumnName, "")
                    tcRowTitle.ItemTemplate = lblRowTitle
                    tcRowTitle.HeaderText = dc.Caption   ' "Title"
                    tcRowTitle.ItemStyle.Width = Unit.Pixel(200)
                    Me.Columns.Add(tcRowTitle)
                ElseIf (dc.ColumnName = "YearTotal") Then
                    ' Now Build the Totals Column
                    Dim tcTotals As New TemplateColumn  ' build a template column 
                    Dim lblRowTotals As New LabelTemplate(dc.Ordinal, dc.ColumnName, "")      ' Item Template 
                    tcTotals.ItemTemplate = lblRowTotals
                    tcTotals.ItemStyle.Width = New Unit("80")
                    tcTotals.HeaderText = columnName '"Total"
                    ' Add it in the grid columns 
                    Me.Columns.Add(tcTotals)
                ElseIf (dc.ColumnName = "ID") Then

                    ' Now Build the HIDDEN ID Column
                    Dim idColumn As New TemplateColumn  ' build a template column 
                    Dim lblRowIDs As New LabelTemplate(dc.Ordinal, dc.ColumnName, "")
                    idColumn.Visible = False
                    idColumn.ItemTemplate = lblRowIDs
                    idColumn.ItemStyle.Width = New Unit("80")
                    idColumn.HeaderText = "IDs"
                    ' Add it in the grid columns 
                    Me.Columns.Add(idColumn)
                Else
                    Dim i As Integer
                    Dim tc As TemplateColumn = New TemplateColumn
                    tc.ItemStyle.Width = New Unit("10%")
                    tc.HeaderText = columnName ' _monthNames(i)
                    Dim tbItem As New TextBoxTemplate(dc.Ordinal, dc.ColumnName, "")
                    tc.ItemTemplate = tbItem
                    Me.Columns.Add(tc)
                End If
            Next
        End If


    End Sub

    Private Sub SetAttributes()

    End Sub

    Private Sub RegisterClientScript()
        'dim manager as ResourceManager = new ResourceManager(this.GetType());
        Dim jscript As String  '= manager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture,true,true).GetString("LibraryScript");
        Me.Page.RegisterClientScriptBlock("WeekGrid_Script", jscript)
    End Sub
#End Region

End Class
