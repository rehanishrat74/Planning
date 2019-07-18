'Changed by - Win-saira

Option Strict On
Option Explicit On 

#Region "Imports"

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports System.Data.SqlClient
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common


#End Region
Public Class SalesForecast
    Inherits BusinessTable
    Public status As Boolean
    Public Objstatus As CustomerStatus
    Dim ProRowHash As Hashtable
#Region "Constructors"
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)
        status = Objstatus.CustomerSerivceStatus(connData)
        Dim ds As DataSet
        Me.TableName = "SalesForecast"
        Caption = "Sales Forecast"
        If status = True Then
            Dim command As New InfiniCommand("BPL_GetSalesForecastLinked")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ProRowHash = New Hashtable(50)
            ds = DataAccess.ExecuteDataSet(connData, command)
            If ds.Tables.Count <> 0 Then
                Dim a As Integer
                For a = 0 To ds.Tables(0).Rows.Count - 1
                    If CType(ds.Tables(0).Rows(a).Item(19), String) <> "0" Then
                        ProRowHash.Add(ds.Tables(0).Rows(a).ItemArray(17), ds.Tables(0).Rows(a).ItemArray(19))
                    End If
                Next
            End If

        Else
            Dim command As New InfiniCommand("BPL_GetSalesForecast")
            command.AddParameter("@PlanID", currentPlan.PlanID)
            ProRowHash = New Hashtable(50)
            ds = DataAccess.ExecuteDataSet(connData, command)

            If ds.Tables.Count <> 0 Then
                Dim a As Integer
                For a = 0 To ds.Tables(0).Rows.Count - 1
                    If CType(ds.Tables(0).Rows(a).Item(19), String) <> "0" Then
                        ProRowHash.Add(ds.Tables(0).Rows(a).ItemArray(17), ds.Tables(0).Rows(a).ItemArray(19))
                    End If
                Next

            End If
        End If

        If currentPlan.SalesForecastType = SalesForecastType.Value Then
            PopulateValueDataTable(ds, currentPlan)
        Else
            PopulateUnitDataTable(ds, currentPlan)
        End If
        PostProcess()
    End Sub
#End Region

#Region "Private Methods"
    Private Sub PopulateUnitDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()

        AddNewRow("Unit Sales", "")
        AddDBTable(ds.Tables(0), 1)
        AddNewRow("-Total Unit Sales", "")
        AddNewRow("", "")
        AddNewRow("Unit Prices", "")
        AddDBTable(ds.Tables(1), 1)
        AddNewRow("", "")
        AddNewRow("Sales", "")
        AddDBTable(ds.Tables(0), 1)
        AddNewRow("-Total Sales", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Direct Unit Costs", "")
        AddDBTable(ds.Tables(2), 1)
        AddNewRow("", "")
        AddNewRow("Direct Cost of Sales", "")
        AddDBTable(ds.Tables(0), 1)
        AddNewRow("-Total Direct Cost of Sales", currentPlan.Currency)

        MakeSumColumn(1, 12, GetRowNumber("Unit Sales") + 1, GetRowNumber("Unit Sales.Total Unit Sales") - 1, 13)
        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R{#'Unit Sales'+1}:R[-1]])", GetRowNumber("Unit Sales.Total Unit Sales"))

        Else
            AddExpressionToRow("0", GetRowNumber("Unit Sales.Total Unit Sales"))
        End If


        Dim offset As Integer
        Dim i As Integer
        Dim UnitSalesRow As Integer = GetRowNumber("Unit Sales")
        Dim UnitPricesRow As Integer = GetRowNumber("Unit Prices")

        Dim SalesRow As Integer = GetRowNumber("Sales")
        Dim TotalSalesRow As Integer = GetRowNumber("Total Sales")
        For i = SalesRow + 1 To TotalSalesRow - 1
            offset = i - SalesRow
            AddExpressionToRow("R{" & CStr(offset + UnitSalesRow) & "}*R{" & CStr(offset + UnitPricesRow) & "}", i)
            'MakeSumColumn(1, 12, i, i, 13)
        Next


        Dim DirectUnitPricesRow As Integer = GetRowNumber("Direct Unit Costs")
        Dim TotalDirectCostOfSalesRow As Integer = GetRowNumber("Total Direct Cost of Sales")
        Dim DirectCostOfSalesRow As Integer = GetRowNumber("Direct Cost of Sales")
        For i = DirectCostOfSalesRow + 1 To TotalDirectCostOfSalesRow - 1
            offset = i - DirectCostOfSalesRow
            AddExpressionToRow("R{" & CStr(offset + UnitSalesRow) & "}*R{" & CStr(offset + DirectUnitPricesRow) & "}", i)
            'MakeSumColumn(1, 12, i, i, 13)
        Next

        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R{#'Sales'+1}:R[-1]])", GetRowNumber("Sales.Total Sales"))
        Else
            AddExpressionToRow("0", GetRowNumber("Sales.Total Sales"))
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R{#'Direct Cost of Sales'+1}:R[-1]])", TotalDirectCostOfSalesRow)
        Else
            AddExpressionToRow("0", TotalDirectCostOfSalesRow)
        End If

        'AddExpressionToColumn("Sum([C1:C12])/12", GetRowNumber("Unit Prices") + 1, SalesRow - 2, 13)
        'AddExpressionToColumn("R{#('Sales.'&RowName())}/R{#('Unit Sales.'&RowName())}", GetRowNumber("Unit Prices") + 1, SalesRow - 2, 13)
        'AddExpressionToColumn("Round(Sum([C1:C12])/12,2)", GetRowNumber("Direct Unit Costs") + 1, DirectCostOfSalesRow - 2, 13)
        'AddExpressionToColumn("Round(R{#('Direct Cost of Sales.'&RowName())}/R{#('Unit Sales.'&RowName())},2)", GetRowNumber("Direct Unit Costs") + 1, DirectCostOfSalesRow - 2, 13)

        '========================================================
        '=========Building expression for the unit prices========
        '========================================================
        Dim expr As String
        Dim j As Integer
        Dim productsCount As Integer = SalesRow - GetRowNumber("Unit Prices") - 2
        For i = 1 To productsCount
            expr = "(0"
            For j = 1 To 12
                expr += "+(R" + (GetRowNumber("Unit Sales") + i).ToString() + "C" + j.ToString() + "*R" + (GetRowNumber("Unit Prices") + i).ToString() + "C" + j.ToString() + ")"
            Next
            expr += ")/R" + (GetRowNumber("Unit Sales") + i).ToString() + "C13"
            AddExpressionToCell("ROUND(" + expr + ",2)", GetRowNumber("Unit Prices") + i, 13)
        Next
        '========================================================
        '=========Building expression for Direct Unit Costs======
        '========================================================
        For i = 1 To productsCount
            expr = "(0"
            For j = 1 To 12
                expr += "+(R" + (GetRowNumber("Unit Sales") + i).ToString() + "C" + j.ToString() + "*R" + (GetRowNumber("Direct Unit Costs") + i).ToString() + "C" + j.ToString() + ")"
            Next
            expr += ")/R" + (GetRowNumber("Unit Sales") + i).ToString() + "C13"
            AddExpressionToCell("ROUND(" + expr + ",2)", GetRowNumber("Direct Unit Costs") + i, 13)
        Next
        '========================================================

    End Sub

    Private Sub PopulateValueDataTable(ByRef ds As DataSet, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan)
        AddHeadings()

        AddNewRow("Sales", "")
        AddDBTable(ds.Tables(1), 1)
        AddNewRow("-Total Sales", currentPlan.Currency)
        AddNewRow("", "")
        AddNewRow("Direct Cost of Sales", "")
        AddDBTable(ds.Tables(2), 1)
        AddNewRow("-Total Direct Cost of Sales", currentPlan.Currency)

        MakeSumColumn(1, 12, GetRowNumber("Sales") + 1, GetRowNumber("Sales.Total Sales") - 1, 13)
        If ds.Tables(1).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R{#'Sales'+1}:R[-1]])", GetRowNumber("Sales.Total Sales"))
        Else
            AddExpressionToRow("0", GetRowNumber("Sales.Total Sales"))
        End If

        MakeSumColumn(1, 12, GetRowNumber("Direct Cost of Sales") + 1, GetRowNumber("Total Direct Cost of Sales") - 1, 13)
        If ds.Tables(2).Rows.Count > 0 Then
            AddExpressionToRow("Sum([R{#'Direct Cost of Sales'+1}:R[-1]])", GetRowNumber("Total Direct Cost of Sales"))
        Else
            AddExpressionToRow("0", GetRowNumber("Total Direct Cost of Sales"))
        End If
    End Sub

    Private Sub UpdateNumberOfUnits(ByRef connData As ConnectionData, ByVal arr As ArrayList)
        Dim pc As PeriodicCellValue
        Dim cmd As New InfiniCommand("BPL_UpdateNoOfProductUnitsSold")

        For Each pc In arr
            cmd.AddParameter("@PlanID", _CurrentPlan.PlanID)
            cmd.AddParameter("@ProductID", pc.CategoryID)
            cmd.AddParameter("@Period", pc.PeriodID)
            cmd.AddParameter("@CellValue", pc.Value)
            DataAccess.ExecuteNonQuery(connData, cmd)
            cmd.ClearParameters()
        Next
    End Sub
    Private Sub UpdateUnitCost(ByRef connData As ConnectionData, ByVal arr As ArrayList)
        Dim pc As PeriodicCellValue
        Dim cmd As New InfiniCommand("BPL_UpdateProductCost")

        For Each pc In arr
            cmd.AddParameter("@PlanID", _currentplan.PlanID)
            cmd.AddParameter("@ProductID", pc.CategoryID)
            cmd.AddParameter("@Period", pc.PeriodID)
            cmd.AddParameter("@CellValue", pc.Value)
            DataAccess.ExecuteNonQuery(connData, cmd)
            cmd.ClearParameters()
        Next
    End Sub
    Private Sub UpdateUnitPrice(ByRef connData As ConnectionData, ByVal arr As ArrayList)
        Dim pc As PeriodicCellValue
        Dim cmd As New InfiniCommand("BPL_UpdateProductPrice")

        For Each pc In arr
            cmd.AddParameter("@PlanID", _currentplan.PlanID)
            cmd.AddParameter("@ProductID", pc.CategoryID)
            cmd.AddParameter("@Period", pc.PeriodID)
            cmd.AddParameter("@CellValue", pc.Value)
            DataAccess.ExecuteNonQuery(connData, cmd)
            cmd.ClearParameters()
        Next
    End Sub
    Private Function AddProduct(ByVal Name As String, ByVal UIiD As Object) As Boolean
        For i As Integer = 0 To Me.Rows.Count - 1
            If CStr(Me.Rows(i).Item(0)).Trim("-"c) = Name Then Return False
        Next
        Dim command As New InfiniCommand("BPL_InsertProduct")
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        command.AddParameter("@ProductName", Name)
        command.AddParameter("@UIiD", UIiD)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function DeleteProduct(ByVal ProductID As String) As Boolean
        Dim command As New InfiniCommand("BPL_DeleteProduct")
        command.AddParameter("@ProductID", ProductID)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
    Private Function RenameProduct(ByVal ProductID As String, ByVal NewName As String) As Boolean
        Dim command As New InfiniCommand("BPL_RenameProduct")
        command.AddParameter("@ProductID", ProductID)
        command.AddParameter("@ProductName", NewName)
        command.AddParameter("@PlanID", _CurrentPlan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function
#End Region

#Region "Public Methods"
    Public Overrides Function RowNum(ByVal Position As Integer) As Object
        If (Position = -1) Then
            Return ""
        Else
            Return (Me.Rows(Position).Item("id"))
        End If


    End Function
    Public Overrides Function InsertRow(ByVal Position As Integer, ByVal RowName As String) As Boolean
        'If Not rowNameExists(RowName, Position) Then
        '    Try
        '        AddProduct(RowName)
        '        Return True
        '    Catch ex As Exception
        '        Return False
        '    End Try
        'Else
        '    Throw New BizPlanDBInvalidDataException("Row Already Exists.")
        'End If

        If (Position = -1) Then
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowSelectError")
            'Dim SetPosotion As String = ""
            'Try
            '    AddProduct(RowName, SetPosotion)

            '    Return True
            ' Catch ex As Exception
            '   Return False
            '  End Try
        ElseIf (Position <> -1) Then
            If Not rowNameExists(RowName, Position) Then
                Try
                    AddProduct(RowName, Me.Rows(Position).Item("id"))

                    Return True
                Catch ex As Exception
                    Return False
                End Try
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
            End If
        End If



    End Function
    Public Overrides Function DeleteRow(ByVal RowNumber As Integer) As Boolean
        Try
            Dim ID As String = CStr(Rows(RowNumber)("ID"))
            If ID.Length > 0 Then
                DeleteProduct(ID)
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_DeleteError")

            End If
            Return True
        Catch ex As Exception

            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_DeleteError")

            Return False
        End Try
    End Function
    Public Overrides Function RenameRow(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        If Not rowNameExists(NewName, RowNumber) Then
            If Trim(NewName) = "" Then Return False
            Dim rowID As String = CStr(Rows(RowNumber)("ID"))
            If ProRowHash.Count <> 0 Then
                If ProRowHash.ContainsKey(rowID) Then
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_LinkedRow")
                    Return False
                End If
            End If

            Try
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    RenameProduct(ID, NewName)
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")

                End If
                Return True
            Catch ex As Exception

                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")

                Return False
            End Try
        Else
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        End If
    End Function

#Region " Proweb"
    ' < ProWeb> 

    Public Overrides Function InsertProductWithPro(ByVal position As Integer, ByVal RowName As String, ByVal Goods As InfiniLogic.BusinessPlan.BLL.BusinessGoodsType) As Boolean
        If (position = -1) Then
            Dim SetPosition As String = ""

            Try
                AddProductToAccountsPro(RowName, SetPosition, Goods)
            Catch ex As Exception
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
            End Try
        ElseIf (position <> -1) Then
            If Not rowNameExists(RowName, position) Then
                Try
                    AddProductToAccountsPro(RowName, Me.Rows(position).Item("id"), Goods)
                Catch ex As Exception
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
                End Try
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
            End If
        End If
    End Function

    Private Function AddProductToAccountsPro(ByVal Name As String, ByVal UIiD As Object, ByVal Goods As InfiniLogic.BusinessPlan.BLL.BusinessGoodsType) As Boolean

        For i As Integer = 0 To Me.Rows.Count - 1
            If CStr(Me.Rows(i).Item(0)).Trim("-"c) = Name Then Return False
        Next
        Try

            Dim ProdName As String = Name
            Dim Description As String = "Test"
            Dim Sup_Ac As String = ""
            Dim Sales_Price As Int32 = 0
            Dim Cost_Price As Int32 = 0
            Dim Tax_Code As String = "T0"
            Dim Tax_Rate As Integer = 0
            Dim Stock As Int32 = 0
            Dim Nc As String = "10000"
            Dim TranDateTime As Date = CType(Now.ToShortDateString(), Date)
            Dim Cat1 As Integer = 1
            Dim Cat2 As Integer = 0
            Dim Cat3 As Integer = 0
            Dim Cat4 As Integer = 0
            Dim Manufacture As Integer = 0
            Dim aa As String = CType(Goods, String)


            Dim command As New InfiniCommand("BPL_CreateProductWithPro")
            command.AddParameter("@PlanID", _CurrentPlan.PlanID)
            command.AddParameter("@ProductName", Name)
            command.AddParameter("@UIiD", UIiD)
            command.AddParameter("@Description", Description)
            command.AddParameter("@Sales_Price", Sales_Price)
            command.AddParameter("@Cost_Price", Cost_Price)
            command.AddParameter("@Sup_Ac", Sup_Ac)
            command.AddParameter("@Tax_Code", Tax_Code)
            command.AddParameter("@Tax_Rate", Tax_Rate)
            command.AddParameter("@Stock", Stock)
            command.AddParameter("@Nc", Nc)
            command.AddParameter("@TranDateTime", TranDateTime)
            command.AddParameter("@Cat1", Cat1)
            command.AddParameter("@Cat2", Cat2)
            command.AddParameter("@Cat3", Cat3)
            command.AddParameter("@Cat4", Cat4)
            command.AddParameter("@Manufacture", Manufacture)
            command.AddParameter("@Goods", Goods)
            DataAccess.ExecuteNonQuery(_connData, command)
            Return True

        Catch ex As Exception
            Dim ErrorStr As String = ex.Message
        End Try
    End Function

    Public Overrides Function DeleteProductWithPro(ByVal RowNumber As Integer) As Boolean
        Try
            Dim ID As String = CStr(Rows(RowNumber)("ID"))
            If ID.Length > 0 Then
                DeleteProductAccountsPro(ID)
            Else
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_DeleteError")
            End If
        Catch ex As Exception
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_DeleteError")
        End Try
    End Function

    Private Function DeleteProductAccountsPro(ByVal ProductID As String) As String
        Try
            Dim ErrorMessage As String = ""
            Dim command As New InfiniCommand("BPL_DeleteProductWithPro")
            command.AddParameter("@ProductID", ProductID)
            command.AddParameter("@PlanId", _currentplan.PlanID)
            command.AddParameter("@ErrorMessage", ErrorMessage)
            Dim str As String = CStr(DataAccess.ExecuteScalar(_connData, command))
            Return str
        Catch ex As Exception
            Dim StrError As String = ex.Message
        End Try
    End Function

    Public Overrides Function RenameProductWithPro(ByVal RowNumber As Integer, ByVal NewName As String) As Boolean
        If Not rowNameExists(NewName, RowNumber) Then
            If Trim(NewName) = "" Then Return False
            Try
                Dim ID As String = CStr(Rows(RowNumber)("ID"))
                If ID.Length > 0 Then
                    RenameProductWithAccountsPro(ID, NewName)
                Else
                    Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
                End If
                Return True
            Catch ex As Exception
                Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_CellRenameError")
            End Try
        Else
            Throw New BizPlanDBInvalidDataException("bizplanweb_services_plan_planmanager_RowExsistError")
        End If
    End Function

    Private Function RenameProductWithAccountsPro(ByVal ProductID As String, ByVal NewName As String) As Boolean

        Dim command As New InfiniCommand("BPL_UpdateProductWithPro")
        command.AddParameter("@ProductID", ProductID)
        command.AddParameter("@ProductName", NewName)
        command.AddParameter("@PlanId", _currentplan.PlanID)
        DataAccess.ExecuteNonQuery(_connData, command)
    End Function

    ' </ProWeb> 
#End Region

    Public Overrides Sub Save()
        Dim _numberOfUnits As New ArrayList
        Dim _unitCost As New ArrayList
        Dim _unitPrice As New ArrayList
        Dim h As New Hashtable(Rows.Count)
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In Rows
            h.Add(dr, i)
            i += 1
        Next
        Dim numVal() As String

        Dim NewText As String
        Dim Row As Integer, Column As Integer
        Dim e As DataColumnChangeEventArgs

        Dim SalesRow As Integer = GetRowNumber("Sales")
        Dim TotalSalesRow As Integer = GetRowNumber("Sales.Total Sales")
        Dim DirectCostOfSalesRow As Integer = GetRowNumber("Direct Cost of Sales")

        For Each e In ChangedCells
            Row = CInt(h(e.Row))
            Dim strIdVal As String = Trim(CType(e.Row("ID"), String))
            numVal = Split(strIdVal, "_")

            If (numVal(1).TrimStart("0"c) > "0") Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    If Not REValidator.IsDecimal(NewText, 0) Then
                        Throw New BizPlanInvalidDataException("Invalid data. Please check the values entered.")
                    End If
                    ' Update for All Columns Except Totals And ID
                    Dim pc As New PeriodicCellValue(CStr(e.Column.ColumnName).ToUpper, CStr(e.Row.Item("ID")), NewText)

                    If _CurrentPlan.SalesForecastType = SalesForecastType.Value Then '_CurrentPlan.BusinessGoods = BusinessGoodsType.Services Then
                        If (Row > DirectCostOfSalesRow And Row < GetRowNumber("Total Direct Cost of Sales")) Then
                            _unitCost.Add(pc)
                        ElseIf (Row > SalesRow And Row < TotalSalesRow) Then
                            _unitPrice.Add(pc)
                        End If
                    Else
                        Dim UnitSalesRow As Integer = GetRowNumber("Unit Sales")
                        Dim TotalUnitSalesRow As Integer = GetRowNumber("Unit Sales.Total Unit Sales")
                        Dim DirectUnitCostsRow As Integer = GetRowNumber("Direct Unit Costs")
                        Dim UnitPricesRow As Integer = GetRowNumber("Unit Prices")
                        If (Row > DirectUnitCostsRow And Row < DirectCostOfSalesRow) Then
                            _unitCost.Add(pc)
                        ElseIf (Row > UnitPricesRow And Row < SalesRow) Then
                            _unitPrice.Add(pc)
                        ElseIf (Row > UnitSalesRow And Row < TotalUnitSalesRow) Then
                            _numberOfUnits.Add(pc)
                        End If
                    End If
                End If
            End If
        Next

        If (_numberOfUnits.Count > 0) Then
            UpdateNumberOfUnits(_ConnData, _numberOfUnits)
            _numberOfUnits.Clear()
        End If

        If (_unitCost.Count > 0) Then
            UpdateUnitCost(_ConnData, _unitCost)
            _unitCost.Clear()
        End If

        If (_unitPrice.Count > 0) Then
            UpdateUnitPrice(_ConnData, _unitPrice)
            _unitPrice.Clear()
        End If
        Saved()
    End Sub
    Public Function GetTotalSales() As DataRow
        Return Rows(GetRowNumber("Total Sales"))
    End Function
    Public Function GetCostOfUnitSales() As DataRow
        Return Rows(GetRowNumber("Total Direct Cost of Sales"))
    End Function
#End Region
End Class
