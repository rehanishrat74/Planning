' Modified by - Win-saira  

Imports System.Data
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.AccountsCentre.DAL
Imports System.Resources
Imports System.Globalization
Imports System.Threading
Imports System.Reflection
Imports System.web

Imports System
 
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.UserControl
Imports System.Web.HttpContext
Imports System.Web.Security
Imports ACC_DAL = InfiniLogic.AccountsCentre.DAL
Imports ACC_BLL = InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
 
Imports System.Data.SqlClient
 

 

Public MustInherit Class BusinessTable
    Inherits SpreadTable
    Implements IBusinessTable
    Public Shared DisplayName As String
    Private _resMgr As ResourceManager
    Public Shared collect As New ArrayList
    Public CurrencyValue As String



#Region "Private Members"
    Private RowsTable As Hashtable
    Private RowsRegister As Hashtable
    Private tablesList As New ArrayList
    Private RowTableRegisterStatus As Hashtable

    Private RowRegisterStatus As Hashtable
    Private StartTime As Long
    Private LastRowName As String
#End Region
#Region "Public Members"
    Public Currency As String
    Public Caption As String
    Public Shared LoadingTimes As String
    Public Shared ReadOnly Property IsPeriodic() As Boolean
        Get
            Return True
        End Get
    End Property
#End Region
#Region "Protected Members"
    Protected _ConnData As ConnectionData
    Protected _CurrentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Protected _NeedsToBeSaved As Boolean
    Protected ChangedCells As ArrayList
    Protected _IsEditable As Boolean
#End Region

#Region "Constructors"
    Public Sub New()
        DefaultView.AllowNew = False
        DefaultView.AllowDelete = False
        _NeedsToBeSaved = False
        ChangedCells = New ArrayList
        RowsTable = New Hashtable(100)
        RowsRegister = New Hashtable(100)
        RowTableRegisterStatus = New Hashtable(100)
        RowRegisterStatus = New Hashtable(100)
        _IsEditable = True
        LastRowName = ""
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        StartTime = System.DateTime.Now.Ticks
        _ConnData = connData
        _CurrentPlan = currentPlan
        DefaultView.AllowNew = False
        DefaultView.AllowDelete = False
        _NeedsToBeSaved = False
        ChangedCells = New ArrayList
        RowsTable = New Hashtable(100)
        RowsRegister = New Hashtable(100)
        RowTableRegisterStatus = New Hashtable(100)
        RowRegisterStatus = New Hashtable(100)
        _IsEditable = True
        LastRowName = ""
        CurrencyValue = _CurrentPlan.Currency
    End Sub
#End Region
#Region "Protected Methods"
    'Protected Function UpdateCellValue(ByVal ConnData As ConnectionData, ByVal CellValue As PeriodicCellValue) As Boolean
    'End Function
    Public Function aa(ByVal rowName As String, ByVal insertPosition As Integer) As Boolean
        Dim fullName As String = rowName

        Return True

    End Function


    Protected Function RowNameExists(ByVal rowName As String, ByVal insertPosition As Integer) As Boolean
        'Dim fullName As String = GetNewRowFullName(rowName, insertPosition)
        'If RowsRegister.ContainsKey(fullName) Then
        '    Return True
        'Else
        '    Return False
        'End If

        If tablesList.Contains(rowName.ToUpper.Trim) Then Return True

        Dim currentRowName As String()
        currentRowName = Split(CType(tablesList(insertPosition), String), ".")

        If currentRowName.Length - 1 > 0 Then
            Return tablesList.Contains(currentRowName(0) & "." & rowName.ToUpper.Trim)
        Else
            Return tablesList.Contains(CType(tablesList(insertPosition), String) & "." & rowName.ToUpper.Trim)
        End If

        Return False
    End Function

    Public Function RowNameExistsPro(ByVal rowName As String, ByVal insertPosition As Integer) As Boolean
        Dim fullName As String = GetNewRowFullName(rowName, insertPosition)
        If RowsRegister.ContainsKey(fullName) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub PostProcess()
        Dim dc As DataColumn
        For Each dc In Columns
            dc.Caption = GetDisplayNameForColumnName(dc.ColumnName, _CurrentPlan)
        Next
        Calculate()
        Saved()
        LoadingTimes += (Caption & ":" & vbTab & Math.Round((System.DateTime.Now.Ticks - StartTime) / 10000000, 3) & vbCrLf)
    End Sub
    Protected Sub Saved()
        AcceptChanges()
        _NeedsToBeSaved = False
        ChangedCells.Clear()
    End Sub
    Protected Overridable Sub AddDBTable(ByVal Table As DataTable, ByVal NestingLevel As Integer)
        Dim drTemp As DataRow
        For Each drTemp In Table.Rows
            If Table.Columns.Contains("Unit") Then
                If (UnitTypes.None = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    If checkExistingColumn(Table.Columns) = True Then
                        If CStr(drTemp.Item("proCode")) <> "0" And Not IsNothing(drTemp.Item("proCode")) Then AddDBRow(drTemp, NestingLevel, "", ImageTypes.ShowImage)
                        If CStr(drTemp.Item("proCode")) = "0" Then AddDBRow(drTemp, NestingLevel, "")
                    Else
                        AddDBRow(drTemp, NestingLevel, "")
                    End If
                ElseIf (UnitTypes.Currecny = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    If checkExistingColumn(Table.Columns) = True Then
                        If CStr(drTemp.Item("proCode")) <> "0" Then AddDBRow(drTemp, NestingLevel, _CurrentPlan.Currency, ImageTypes.ShowImage)
                        If CStr(drTemp.Item("proCode")) = "0" Then AddDBRow(drTemp, NestingLevel, _CurrentPlan.Currency)
                    Else
                        AddDBRow(drTemp, NestingLevel, "")
                    End If
                ElseIf (UnitTypes.Percent = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    If checkExistingColumn(Table.Columns) = True Then
                        If CStr(drTemp.Item("proCode")) <> "0" Then AddDBRow(drTemp, NestingLevel, "", ImageTypes.ShowImage)
                        If CStr(drTemp.Item("proCode")) = "0" Then AddDBRow(drTemp, NestingLevel, "")
                    Else
                        AddDBRow(drTemp, NestingLevel, "")
                    End If
                End If
            Else
                AddDBRow(drTemp, NestingLevel, "")
            End If

        Next
    End Sub
    Protected Overridable Sub AddDBTable(ByVal Table As DataTable, ByVal NestingLevel As Integer, ByVal EnableCheck As Boolean)
        Dim drTemp As DataRow
        Dim ROWloopval As Integer = 1
        For Each drTemp In Table.Rows
            If Table.Columns.Contains("Unit") Then
                If (UnitTypes.None = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, "", ROWloopval, EnableCheck)
                ElseIf (UnitTypes.Currecny = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, _CurrentPlan.Currency, ROWloopval, EnableCheck)
                ElseIf (UnitTypes.Percent = CType(drTemp.Item("Unit"), UnitTypes)) Then
                    AddDBRow(drTemp, NestingLevel, "", ROWloopval, EnableCheck)
                End If
            Else
                AddDBRow(drTemp, NestingLevel, "", ROWloopval, EnableCheck)
            End If
            ROWloopval = ROWloopval + 1
        Next

    End Sub
    Protected Overridable Sub AddDBRow(ByVal Row As DataRow, ByVal NestingLevel As Integer, ByVal Unit As String _
    , ByVal ROWloopval As Integer, ByVal RowEnable As Boolean)
        Dim drTemp As DataRow
        Dim i As Integer, j As Integer
        Dim Str As String
        For i = 1 To NestingLevel
            Str = Str & "-"
        Next
        drTemp = AddNewRow(Str & CStr(Row(0)), Unit, ROWloopval, RowEnable)

        j = 1
        For i = 1 To Columns.Count - 1
            drTemp(i) = Row(j)
            If i = 12 Then i += 1
            j += 1
        Next
    End Sub

    Protected Overridable Sub AddDBRow(ByVal Row As DataRow, ByVal NestingLevel As Integer, ByVal Unit As String)
        Dim drTemp As DataRow
        Dim i As Integer, j As Integer
        Dim Str As String
        For i = 1 To NestingLevel
            Str = Str & "-"
        Next
        drTemp = AddNewRow(Str & CStr(Row(0)), Unit)

        j = 1
        For i = 1 To Columns.Count - 1
            drTemp(i) = Row(j)
            If i = 12 Then i += 1
            j += 1
        Next
    End Sub
    Protected Overridable Sub AddDBRow(ByVal Row As DataRow, ByVal NestingLevel As Integer, ByVal Unit As String, ByVal showImage As Integer)
        Dim drTemp As DataRow
        Dim i As Integer, j As Integer
        Dim Str As String
        For i = 1 To NestingLevel
            Str = Str & "-"
        Next
        'drTemp = AddNewRow(Str & CStr(Row(0)), Unit)

        If showImage = ImageTypes.ShowImage Then
            drTemp = AddNewRow(Str & CStr(Row(0)), Unit, ImageTypes.ShowImage)
        Else
            drTemp = AddNewRow(Str & CStr(Row(0)), Unit)
        End If


        j = 1
        For i = 1 To Columns.Count - 1
            drTemp(i) = Row(j)
            If i = 12 Then i += 1
            j += 1
        Next
    End Sub

    Protected Function AddNewRow(ByVal heading As String, ByVal Unit As String _
    , ByVal ROWloopval As Integer, ByVal EditRow As Boolean) As DataRow
        Dim currencyUnit As String()
        Dim drTemp As DataRow = NewRow()
        drTemp(0) = heading
        Dim s As String = GetRowKey(heading)
        Dim dc As DataColumn
        For Each dc In Columns
            If dc.Ordinal > 0 Then
                drTemp.Item(dc.Ordinal) = ""
            End If
        Next


        drTemp = AddNewRow(drTemp, EditRow)
        currencyUnit = Split(Unit, " ")
        If currencyUnit.Length > 1 Then
            drTemp(0) = heading + " " + currencyUnit(1)
        Else
            drTemp(0) = heading + " " + Unit
        End If
        Return drTemp
    End Function
    Public Shared Function GetDisplayNameForColumnName(ByVal ColumnName As String, ByVal CurrentPlan As BLL.BusinessPlan) As String

        Dim displayYear As Integer

        Select Case ColumnName
            Case "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                Return GetDisplayNameForMonthName(ColumnName, CurrentPlan)
            Case "YearTotal", "Year0", "Total"
                displayYear = CInt(CurrentPlan.StartYear)
            Case "Year1"
                displayYear = CInt(CurrentPlan.StartYear) + 1
            Case "Year2"
                displayYear = CInt(CurrentPlan.StartYear) + 2
            Case "Year3"
                displayYear = CInt(CurrentPlan.StartYear) + 3
            Case "Year4"
                displayYear = CInt(CurrentPlan.StartYear) + 4
            Case Else
                Return ColumnName
        End Select
        If CurrentPlan.StartMonth <> "Jan" Then displayYear += 1
        Return "FY" + CStr(displayYear)

    End Function

    Private Shared Function GetDisplayNameForMonthName(ByVal MonthName As String, ByVal CurrentPlan As BLL.BusinessPlan) As String
        Dim MonthID As Integer = CInt([Enum].Parse(GetType(BusinessPlanMonths), MonthName))
        Dim StartMonthID As Integer = CInt([Enum].Parse(GetType(BusinessPlanMonths), CurrentPlan.StartMonth))
        MonthID = (MonthID + StartMonthID) Mod 12
        Return [Enum].GetName(GetType(BusinessPlanMonths), MonthID)

        '  Dim DisplayName As String = [Enum].GetName(GetType(BusinessPlanMonths), MonthID)
        '  Return DisplayName
    End Function

    Protected Overridable Sub AddHeadings()
        Columns.Add(New DataColumn("Heading", GetType(String)))
        Columns.Add(New DataColumn("Jan", GetType(String)))
        Columns.Add(New DataColumn("Feb", GetType(String)))
        Columns.Add(New DataColumn("Mar", GetType(String)))
        Columns.Add(New DataColumn("Apr", GetType(String)))
        Columns.Add(New DataColumn("May", GetType(String)))
        Columns.Add(New DataColumn("Jun", GetType(String)))
        Columns.Add(New DataColumn("Jul", GetType(String)))
        Columns.Add(New DataColumn("Aug", GetType(String)))
        Columns.Add(New DataColumn("Sep", GetType(String)))
        Columns.Add(New DataColumn("Oct", GetType(String)))
        Columns.Add(New DataColumn("Nov", GetType(String)))
        Columns.Add(New DataColumn("Dec", GetType(String)))
        Columns.Add(New DataColumn("YearTotal", GetType(String)))
        Columns.Add(New DataColumn("Year1", GetType(String)))
        Columns.Add(New DataColumn("Year2", GetType(String)))
        Columns.Add(New DataColumn("Year3", GetType(String)))
        Columns.Add(New DataColumn("Year4", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String)))
    End Sub

    Protected Function AddNewRow(ByVal heading As String, ByVal Unit As String) As DataRow
        Dim drTemp As DataRow = NewRow()
        Dim currencyUnit As String()
        drTemp(0) = heading
        Dim dc As DataColumn
        For Each dc In Columns
            If dc.Ordinal > 0 Then
                drTemp.Item(dc.Ordinal) = ""
            End If
        Next
        drTemp = AddNewRow(drTemp)
        currencyUnit = Split(Unit, " ")
        If currencyUnit.Length > 1 Then
            drTemp(0) = heading + " " + currencyUnit(1)
        Else
            drTemp(0) = heading + " " + Unit
        End If
        Return drTemp
    End Function
    '// new changes

    Protected Function AddNewRow(ByVal heading As String, ByVal Unit As String, ByVal showImage As Integer) As DataRow

        Dim navCell As HtmlTableCell = New HtmlTableCell

        ' navCell.InnerHtml = "<width='1000'> <img src='/images/InfiniPlan/link_icon.gif'   >"
        'navCell.InnerHtml = "<width='1000'> <img src='http://www.accountscentre.com/images/InfiniPlan/link_icon.gif'   >"
        Dim str As String = "http://" & System.Web.HttpContext.Current.Request.Url.Host
        navCell.InnerHtml = "<width='1000'> <img src='" & str & "/images/InfiniPlan/link_icon.gif'   >"
        navCell.Attributes.Add("vAlign", "bottom")
        Dim currencyUnit As String()


        Dim drTemp As DataRow = NewRow()
        drTemp(0) = heading
        Dim dc As DataColumn
        For Each dc In Columns
            If dc.Ordinal > 0 Then
                drTemp.Item(dc.Ordinal) = ""
            End If
        Next
        drTemp = AddNewRow(drTemp)
        currencyUnit = Split(Unit, " ")
        If currencyUnit.Length > 1 Then
            drTemp(0) = heading + " " + currencyUnit(1) + "" + navCell.InnerHtml
        Else
            drTemp(0) = heading + " " + Unit + "" + navCell.InnerHtml
        End If
        Return drTemp
    End Function

    Protected Function AddNewRow(ByVal Row As DataRow) As DataRow
        Rows.Add(Row)
        Dim s As String = GetRowKey(Row)
        If Not s = "" Then
            Dim str As String = GetRowFullName(Row)
            If Not RowsRegister.ContainsKey(str) Then
                RowsRegister.Add(str, Rows.Count - 1)
                tablesList.Add(str.ToUpper)     '// use for finding specific name...
            End If
            If Not RowsTable.ContainsKey(s) Then
                RowsTable.Add(s, Rows.Count - 1)
            End If
        Else
            tablesList.Add("")          '// Add blank rows into array
        End If
        Return Row
    End Function
    Protected Function AddNewRow(ByVal Row As DataRow, ByVal setEditRow As Boolean) As DataRow
        Rows.Add(Row)
        Dim s As String = GetRowKey(Row)
        If Not s = "" Then
            Dim str As String = GetRowFullName(Row)

            If Not RowRegisterStatus.Contains(str) Then

                RowRegisterStatus.Add(str, Rows.Count - 1)
                '[ checkCellEditable(str, Rows.Count - 1)
            End If
            If Not RowsRegister.ContainsKey(str) Then
                RowsRegister.Add(str, Rows.Count - 1)
                tablesList.Add(str.ToUpper)     '// use for finding specific name...
            End If
            If Not RowsTable.ContainsKey(s) Then
                RowsTable.Add(s, Rows.Count - 1)
            End If

            Dim aRow As Integer = GetRowNumber(s)
            Dim dc As DataColumn
            For Each dc In Columns
                If Not (dc.Ordinal = 0 Or dc.ColumnName = "ID") Then
                    checkCellEditable(s, aRow, dc.Ordinal)
                End If
            Next

        Else
            tablesList.Add("")          '// Add blank rows into array
        End If

        Return Row
    End Function
    Protected Sub AddRowNumber(ByVal RowHeading As String, ByVal RowNumber As Integer)
        Dim s As String = GetRowKey(RowHeading)
        If Not s = "" Then
            If Not RowsTable.ContainsKey(s) Then
                RowsTable.Add(s, RowNumber)
            End If
        End If
    End Sub
    Protected Sub MakeSumRow(ByVal StartingRow As Integer, ByVal EndingRow As Integer, ByVal RowNumber As Integer)
        AddExpressionToRow("Sum([R" & StartingRow & ":R" & EndingRow & "])", RowNumber)
    End Sub
    Protected Sub MakeSumRow(ByVal StartingRow As Integer, ByVal EndingRow As Integer, ByVal RowNumber As Integer, ByVal EvaluateOnce As Boolean)
        AddExpressionToRow("Sum([R" & StartingRow & ":R" & EndingRow & "])", RowNumber, EvaluateOnce)
    End Sub
    Protected Sub MakeSumColumn(ByVal StartingColumn As Integer, ByVal EndingColumn As Integer, ByVal StartingRow As Integer, ByVal EndingRow As Integer, ByVal ColumnNumber As Integer)
        Dim i As Integer
        For i = StartingRow To EndingRow
            MakeSumColumn(StartingColumn, EndingColumn, i, ColumnNumber)
        Next
    End Sub
    Protected Sub MakeSumColumn(ByVal StartingColumn As Integer, ByVal EndingColumn As Integer, ByVal RowNumber As Integer, ByVal ColumnNumber As Integer)
        AddExpressionToCell("Sum([C" & StartingColumn & ":C" & EndingColumn & "])", RowNumber, ColumnNumber)
    End Sub
    Protected Sub MakeDifferenceRow(ByVal FirstRow As Integer, ByVal SecondRow As Integer, ByVal ResultRow As Integer)
        AddExpressionToRow("R" & FirstRow & "-" & "R" & SecondRow, ResultRow)
    End Sub
    Protected Sub MakeDifferenceRow(ByVal FirstRow As Integer, ByVal SecondRow As Integer, ByVal ResultRow As Integer, ByVal EvaluateOnce As Boolean)
        AddExpressionToRow("R" & FirstRow & "-" & "R" & SecondRow, ResultRow, EvaluateOnce)
    End Sub
    Protected Sub MakePercentageRow(ByVal DividendRow As Integer, ByVal DivisorRow As Integer, ByVal ResultRow As Integer)
        AddExpressionToRow("Round(100*R" & DividendRow & "/R" & DivisorRow & ",2)&'%'", ResultRow)
    End Sub
    Protected Sub MakePercentageRow(ByVal DividendRow As Integer, ByVal DivisorRow As Integer, ByVal ResultRow As Integer, ByVal EvaluateOnce As Boolean)
        AddExpressionToRow("Round(100*R" & DividendRow & "/R" & DivisorRow & ",2)&'%'", ResultRow, EvaluateOnce)
    End Sub
    Protected Sub AddExpressionToRow(ByVal Expression As String, ByVal Row As Integer)
        Dim dc As DataColumn
        For Each dc In Columns
            If Not (dc.Ordinal = 0 Or dc.ColumnName = "ID") Then
                AddExpressionToCell(Expression, Row, dc.Ordinal)
            End If
        Next
    End Sub
    Protected Sub AddExpressionToRow(ByVal Expression As String, ByVal Row As Integer, ByVal EvaluateOnce As Boolean)
        Dim dc As DataColumn
        For Each dc In Columns
            If Not (dc.Ordinal = 0 Or dc.ColumnName = "ID") Then
                AddExpressionToCell(Expression, Row, dc.Ordinal, EvaluateOnce)
            End If
        Next
    End Sub
    Protected Sub AddExpressionToRow(ByVal Expression As String, ByVal Row As Integer, ByVal StartingColumn As Integer, ByVal EndingColumn As Integer)
        Dim i As Integer
        For i = StartingColumn To EndingColumn
            AddExpressionToCell(Expression, Row, i)
        Next
    End Sub
    Protected Sub AddExpressionToRow(ByVal Expression As String, ByVal Row As Integer, ByVal StartingColumn As Integer, ByVal EndingColumn As Integer, ByVal EvaluateOnce As Boolean)
        Dim i As Integer
        For i = StartingColumn To EndingColumn
            AddExpressionToCell(Expression, Row, i, EvaluateOnce)
        Next
    End Sub
    Protected Sub AddExpressionToColumn(ByVal Expression As String, ByVal StartingRow As Integer, ByVal EndingRow As Integer, ByVal ColumnNumber As Integer)
        Dim i As Integer
        For i = StartingRow To EndingRow
            AddExpressionToCell(Expression, i, ColumnNumber)
        Next
    End Sub
#End Region
#Region "Private Methods"
    Private Function checkExistingColumn(ByVal dc As DataColumnCollection) As Boolean
        Dim fieldName As String = "proCode"       '// this is fixed field name
        For i As Integer = 0 To dc.Count - 1
            If dc.Item(i).ColumnName.ToUpper = fieldName.ToUpper Then
                Return True
            End If
        Next

        Return False
    End Function
    Private Function GetNewRowFullName(ByVal rowName As String, ByVal insertPosition As Integer) As String
        Dim hashEnum As System.Collections.IDictionaryEnumerator = RowsRegister.GetEnumerator()
        Dim currentRowFullName As String
        Do While hashEnum.MoveNext
            If CInt(RowsRegister.Item(hashEnum.Key)) = insertPosition Then
                currentRowFullName = CStr(hashEnum.Key)
                Exit Do
            End If
        Loop
        Return currentRowFullName.Substring(0, currentRowFullName.LastIndexOf("."c) + 1) & rowName
    End Function
    Private Function GetRowKey(ByVal Row As DataRow) As String
        Dim Key As String = CStr(Row(0))
        Key = Key.TrimStart(CChar("-")).TrimEnd(CChar(" "))
        Return Key
    End Function
    Private Function GetRowLevel(ByVal Row As DataRow) As Integer
        Dim Key As String = CStr(Row(0))
        Dim Level As Integer = 0
        While Key.StartsWith("-")
            Key = Key.Substring(1)
            Level += 1
        End While
        Return Level
    End Function
    Private Function GetRowKey(ByVal RowHeading As String) As String
        Dim Key As String = RowHeading
        Key = Key.TrimStart(CChar("-")).TrimEnd(CChar(" "))
        Return Key
    End Function
    Private Function GetRowFullName(ByVal Row As DataRow) As String
        If Not GetRowKey(Row) = "" Then
            LastRowName = LastRowName & "."
            Dim Level As Integer = GetRowLevel(Row)
            Dim Key As String = LastRowName
            Dim CurrentPostion As Integer = 0
            While Level > 0 And Not Key.IndexOf(".") = -1
                CurrentPostion = Key.IndexOf(".")
                Key = Key.Substring(CurrentPostion + 1)
                Level -= 1
            End While
            If LastRowName.Substring(0, CurrentPostion) = "" Then
                LastRowName = GetRowKey(Row).Trim(CChar("."))
            Else
                LastRowName = LastRowName.Substring(0, LastRowName.Length - Key.Length) & GetRowKey(Row).Trim(CChar("."))
            End If
            Return LastRowName
        End If
    End Function
#End Region
#Region "Event Handlers"
    Private Sub BusinessTable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles MyBase.ColumnChanging
        If Not CalculationFlag Then
            _NeedsToBeSaved = True
            ChangedCells.Add(e)
        End If
    End Sub
    Private Sub BusinessTable_FunctionCall(ByVal FunctionName As String, ByVal ParameterList As System.Collections.ArrayList, ByRef ReturnValue As String) Handles MyBase.FunctionCall
        Select Case FunctionName
            Case "GETROWNUMBER"
                ReturnValue = CStr(GetRowNumber(CStr(ParameterList(0))))
        End Select
    End Sub
#End Region
#Region "Interface Implementation Code"
    Public ReadOnly Property IsEditable() As Boolean Implements IBusinessTable.IsEditable
        Get
            Return _IsEditable
        End Get
    End Property
    Public ReadOnly Property NeedsToBeSaved() As Boolean Implements IBusinessTable.NeedsToBeSaved
        Get
            Return _NeedsToBeSaved
        End Get
    End Property
    '< ProWeb>
    Public Overridable Function InsertProductWithPro(ByVal Position As Integer, ByVal RowName As String, ByVal Goods As Infinilogic.BusinessPlan.BLL.BusinessGoodsType) As Boolean Implements IBusinessTable.InsertProductWithPro
    End Function
    Public Overridable Function RowNum(ByVal RowNumber As Integer) As Object Implements IBusinessTable.RowNum
    End Function
    Public Overridable Function DeleteProductWithPro(ByVal RowNumber As Integer) As Boolean Implements IBusinessTable.DeleteProductWithPro
    End Function
    Public Overridable Function RenameProductWithPro(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean Implements IBusinessTable.RenameProductWithPro

    End Function
    '< /ProWeb>
    Public Overridable Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean Implements IBusinessTable.InsertRow
        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_InsertError")
    End Function



    Public Overridable Function DeleteRow(ByVal RowNumber As Integer) As Boolean Implements IBusinessTable.DeleteRow
        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_DeleteError")
    End Function

    Public Overridable Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean Implements IBusinessTable.RenameRow
        Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RenameError")
    End Function
    Public Function ApplyCellChanges(ByVal ChangedCells As Collection) As Boolean Implements IBusinessTable.ApplyCellChanges
        Try
            Dim ChangedCell As ChangedCell
            For Each ChangedCell In ChangedCells
                Rows(ChangedCell.Row)(ChangedCell.Column) = ChangedCell.Value
            Next
            Save()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Overridable Sub Save() Implements IBusinessTable.Save
        Dim CellValues As New ArrayList
        Dim NewText As String
        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            If (Val(e.Row("ID")) > 0) Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    CellValues.Add(New PeriodicCellValue(e.Column.ColumnName, CStr(e.Row("ID")), NewText))
                End If
            End If
        Next
        If (CellValues.Count > 0) Then
            UpdateCellValues(_ConnData, CellValues)
            CellValues.Clear()
        End If
        Saved()
    End Sub
    Protected Overridable Function UpdateCellValues(ByVal ConnData As ConnectionData, ByVal CellValues As ArrayList) As Boolean
        Dim command As InfiniCommand
        Dim sp As PeriodicCellValue
        For Each sp In CellValues
            Try
                'UpdateCellValue(ConnData, sp)
            Catch e As Exception
                Return False
            End Try
        Next
    End Function
    Public Function GetRowNumber(ByVal RowTitle As String) As Integer Implements IBusinessTable.GetRowNumber
        If RowTitle.IndexOf(".") = -1 Then
            If RowsTable.ContainsKey(RowTitle) Then
                Return CInt(RowsTable(RowTitle))
            Else
                Throw New Exception("Row '" & RowTitle & "' not found")
            End If
        Else
            Return GetRowNumberFromFullName(RowTitle)
        End If
    End Function
    Public Function GetRowNumberFromFullName(ByVal RowName As String) As Integer Implements IBusinessTable.GetRowNumberFromFullName
        RowName = RowName.TrimStart(CChar("."))
        If RowsRegister.ContainsKey(RowName) Then
            Return CInt(RowsRegister(RowName))
        Else
            Throw New Exception("Row '" & RowName & "' not found")
        End If
    End Function
#End Region
#Region "Shared Methods"
    Public Shared Function CreateTable(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String) As IBusinessTable
        Dim TableType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + TableName)
        Dim args As Object() = {ConnData, CurrentPlan}
        Return CType(Activator.CreateInstance(TableType, args), IBusinessTable)
    End Function

    Public Shared Function CreateAnualBalaceSheet(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String) As IBusinessTable
        Dim TableType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + TableName)
        Dim args As Object() = {ConnData, CurrentPlan}
        Return CType(Activator.CreateInstance(TableType, args), IBusinessTable)
    End Function

    Public Shared Function CreateMonthlyBalaceSheet(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String, ByVal IOPeriod As Integer) As IBusinessTable
        Dim TableType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + TableName)
        Dim args As Object() = {ConnData, CurrentPlan, IOPeriod}
        Return CType(Activator.CreateInstance(TableType, args), IBusinessTable)
    End Function

    Public Shared Function CreateAnnualIOforPayroll(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String) As IBusinessTable
        Dim TableType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + TableName)
        Dim args As Object() = {ConnData, CurrentPlan, 1}
        Return CType(Activator.CreateInstance(TableType, args), IBusinessTable)
    End Function


    Public Shared Function CreateMonthlyIOforPayroll(ByVal ConnData As ConnectionData, ByVal CurrentPlan As BLL.BusinessPlan, ByVal TableName As String, ByVal IOPeriod As Integer) As IBusinessTable
        Dim TableType As Type = ([Assembly].Load("Infinilogic.BusinessPlan.BLLRules")).GetType("Infinilogic.BusinessPlan.BLLRules." + TableName)
        Dim args As Object() = {ConnData, CurrentPlan, 1, IOPeriod}
        Return CType(Activator.CreateInstance(TableType, args), IBusinessTable)
    End Function
    Public Shared Function GetMonthYearNameFromID(ByVal ID As Integer) As String
        Dim MonthYearName As String
        ID -= 1
        If ID < 12 Then
            MonthYearName = [Enum].GetName(GetType(BusinessPlanMonths), ID)
        ElseIf ID > 12 Then
            MonthYearName = [Enum].GetName(GetType(BusinessPlanYears), ID - 13)
        End If
        Return MonthYearName.ToUpper
    End Function
#End Region
#Region "Public Methods"

#End Region
End Class