Option Strict Off

#Region "......................Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.web
#End Region
Imports system.Math
Imports System.data



Imports System.Web.UI.WebControls
Imports System.IO
Public Class Plan
    Inherits BusinessTable
    Private Sub New()
    End Sub
    Public Sub New(ByRef connData As ConnectionData, ByRef currentPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan)
        MyBase.New(connData, currentPlan)

        Me.TableName = "Plan"
        Caption = "Plan Summary"

        PopulateDataTable()
        PostProcess()
    End Sub

    Public Shared Function GetMerchantMeters(ByVal Customerid As String, ByVal Fromdate As String, ByVal Todate As String, ByVal Fromdatelastday As String, ByVal Todatedaylastday As String, ByVal getCurrency As String) As String

        Dim connData As New ConnectionData
        Dim dsCurrent As DataView, dsPrevious As DataView
        Dim cust_id As Integer = Customerid
        Dim RetNode As String
        Try
            Dim ds As DataSet
            connData.CustomerID = cust_id
            Dim cmda As New SqlCommand

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.ConnectionTimeOut = 0
            'If cust_id <> "2" Then
            cmd.CmdText = "BPL_MerchantMeter"
            cmd.AddParameter("@Fromdate", Fromdate)
            cmd.AddParameter("@Todate", Todate)
            cmd.AddParameter("@Fromdatelastday", Fromdatelastday)
            cmd.AddParameter("@Todatedaylastday", Todatedaylastday)
            cmd.AddParameter("@MIdentity", Customerid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            RetNode = GetMerchantMetersXML(ds, getCurrency)
            'dsCurrent = Plan.ProfitAndLossStatement(cust_id, Fromdate, Todate)
            'dsPrevious = Plan.ProfitAndLossStatement(cust_id, Fromdatelastday, Todatedaylastday)
            'GetMerchantMetersXMLForM2(dsCurrent, dsPrevious, getCurrency)
            ' End If
            Return RetNode
            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
        Catch ex As Exception

            Dim body As String
            'Server.ClearError()
            'body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
            '        "Machine            : " & MyBase.Server.MachineName & "<br>" & _
            '        "Source     : " & ex.Source.ToString & "<br>" & _
            '        "Messege    : " & ex.Message.ToString & "<br>"
            'CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        Finally

        End Try
    End Function

    Public Shared Function GetMerchantMetersXML(ByVal ds As DataSet, ByVal Currency As String) As String
        Dim Nodeitem As StringBuilder


        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder

        Nodeitem.Append("<Root>")

        Nodeitem.Append("<Product" + CStr(0) + ">")
        Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(1)) + qoute + " />")
        Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(0)) + qoute + " />")

        Nodeitem.Append("</Product" + CStr(0) + ">")


        Nodeitem.Append("</Root>")



        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function




    Public Shared Function GetPlanProducts(ByRef connData As ConnectionData, ByVal planId As String) As DataTable

        Dim ds As New DataSet
        Dim cmd As New CommandData(connData.CustomerID)

        cmd.AddParameter("@PlanId", planId)
        cmd.CmdText = "BPL_GetPlanProducts"

        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds.Tables(0)
    End Function

    Public Shared Function GetCurrencyName(ByRef connData As ConnectionData, ByVal Planid As String) As DataSet
        Dim command As New InfiniCommand("BPL_GetPlanCurrencyName")
        command.AddParameter("@PlanID", Planid)

        Return DataAccess.ExecuteDataSet(connData, command)

    End Function

    Public Shared Function getMerchantInformation(ByRef connData As ConnectionData) As DataTable

        Dim planid As String
        Dim Trackerid As String, str_userid As String, str_loginid As String, impid As String
        Dim str_domain As String, str_logininfo As String

        Dim cmd As New CommandData(connData.CustomerID)
        cmd.AddParameter("@CustomerId", connData.CustomerID)


        cmd.CmdText = "bpl_GetMerchat_WebTracker"

        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)

    End Function

    Public Shared Function GetProfileCurrency(ByRef connData As ConnectionData, ByVal Planid As String) As DataSet

        Dim cmd As New CommandData(connData.CustomerID)
        cmd.AddParameter("@CustomerId", connData.CustomerID)

        cmd.CmdText = "BPL_GetCustomerCurrency"

        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
    End Function

#Region " Grid Control Method"

    Public Shared Function GetMultiSelPageCounts(ByVal PlanID As String, ByRef connData As ConnectionData, ByVal lt As MultiGridTypes) As Integer

        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.AddParameter("@MIdentity", connData.CustomerID)
            cmd.AddParameter("@PlanID", PlanID)
            Select Case lt
                Case MultiGridTypes.Product
                    cmd.CmdText = "BPL_Pro_PageCount"
                Case MultiGridTypes.Expenses
                    cmd.CmdText = "BPL_Pro_PageCountExpenses"
            End Select

            Dim PCount As Integer
            PCount = CType(cmd.Execute(ExecutionType.ExecuteScalar), Integer)
            cmd = Nothing
            Return PCount
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try

    End Function

    Public Shared Function GetList(ByRef connData As ConnectionData, ByVal Planid As String, ByVal grid As MultiGridTypes, Optional ByVal Flag As String = "1", Optional ByVal PageType As Integer = 0, _
                     Optional ByVal CompareValue As String = "-1") As DataTable
        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        Dim dtProducts As DataTable
        ds = New DataSet
        cmd.AddParameter("@flag", Flag)
        cmd.AddParameter("@PageType", PageType)
        cmd.AddParameter("@CompareValue", CompareValue)
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@MIdentity", connData.CustomerID)
        Select Case grid
            Case MultiGridTypes.Product
                cmd.CmdText = "BPL_Pro_ProductList"
            Case MultiGridTypes.Expenses
                cmd.CmdText = "BPL_Pro_ExpenseList"
        End Select

        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        dtProducts = ds.Tables(0)

        Return dtProducts
    End Function

    Public Shared Function GetMultiList(ByRef connData As ConnectionData, ByVal PlanID As String, ByVal GT As MultiGridTypes, _
    ByVal ChkGoClick As Boolean, Optional ByVal Flag As String = "1", Optional ByVal PageType As Integer = 0, _
    Optional ByVal comparevalue As String = "-1", Optional ByVal ID As String = "", _
    Optional ByVal Name As String = "") As DataTable
        ' Dim command As New InfiniCommand("BPL_GetBusinessPlans")
        Dim cmd As New CommandData(connData.CustomerID)
        Try
            If ChkGoClick = False Then
                Select Case GT
                    Case MultiGridTypes.Product
                        cmd.CmdText = "BPL_Pro_ProductList"
                    Case MultiGridTypes.Expenses
                        cmd.CmdText = "BPL_Pro_ExpenseList"
                End Select

                cmd.AddParameter("@flag", Flag)
                cmd.AddParameter("@PageType", PageType)
                cmd.AddParameter("@CompareValue", comparevalue)
                cmd.AddParameter("@Planid", PlanID)
                cmd.AddParameter("@MIdentity", connData.CustomerID)
            Else
                Select Case GT
                    Case MultiGridTypes.Product
                        cmd.CmdText = "BPL_Pro_MultiProducts"
                    Case MultiGridTypes.Expenses
                        cmd.CmdText = "BPL_Pro_MultiExpense"
                End Select

                cmd.AddParameter("@ID", ID)
                cmd.AddParameter("@Name", Name)
                cmd.AddParameter("@Planid", PlanID)
                cmd.AddParameter("@MIdentity", connData.CustomerID)
            End If

            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds.Tables(0)

        Catch ex As Exception

            Throw New Exception(ex.Message)

        End Try

    End Function
    Public Shared Function InsertImportedRecords(ByRef connData As ConnectionData, ByVal Plan As String, ByVal xmlString As StringBuilder, ByVal grid As MultiGridTypes, ByVal UIID As Integer) As String
        Dim XML As String = xmlString.ToString

        Dim cmd As New CommandData(connData.CustomerID)
        Try
            cmd.AddParameter("@Plan", Plan)
            cmd.AddParameter("@XML", XML)
            cmd.AddParameter("@UIID", UIID)
            cmd.AddParameter("@MIdentity", connData.CustomerID)
            Select Case grid
                Case MultiGridTypes.Product
                    cmd.CmdText = "BPL_Pro_InsertProducts_XML"
                Case MultiGridTypes.Expenses
                    cmd.CmdText = "BPL_Pro_InserExpense_XML"
            End Select


            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return "'"
        Catch ex As Exception
            Throw New Exception("xInsertDynamicFromM2" & ex.Message)
        End Try

    End Function
    Public Shared Function FetchRecordInfo(ByVal connData As ConnectionData, ByVal GT As MultiGridTypes, ByVal Planid As String) As Boolean
        Dim cmd As New CommandData(connData.CustomerID)

        Try
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@MIdentity", connData.CustomerID)

            Select Case GT
                Case MultiGridTypes.Product
                    cmd.CmdText = "BPL_Pro_ProductRecords"
                    '     cmd.CmdText = "TestRecords"

                Case MultiGridTypes.Expenses
                    'cmd.CmdText = "TestRecords"
                    cmd.CmdText = "BPL_Pro_ExpenseRecords"
            End Select
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

    Public Shared Function RowIndex(ByVal connData As ConnectionData, ByVal ProductID As String, ByVal GT As MultiGridTypes, ByVal Planid As String) As Integer
        Dim cmd As New CommandData(connData.CustomerID)

        Try
            cmd.AddParameter("@Planid", Planid)




            Select Case GT
                Case MultiGridTypes.Product
                    '      cmd.AddParameter("@ProductID", ProductID)
                    cmd.CmdText = "BPL_Pro_ProductGetRow"
                    '     cmd.CmdText = "TestRecords"

                Case MultiGridTypes.Expenses
                    '     cmd.AddParameter("@ProductID", ProductID)

                    'cmd.CmdText = "TestRecords"
                    cmd.CmdText = "BPL_Pro_ExpensesGetRow"
            End Select
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return CType(ds.Tables(0).Rows(0).Item(0), Integer)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

#End Region

#Region " Business Tracker"


    Public Shared Function KeyStatus(ByRef connData As ConnectionData, ByVal Planid As String) As Boolean

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)

        cmd.AddParameter("@Midentity", connData.CustomerID)
        cmd.CmdText = "BPL_Pro_AnnualBalanceSheetPro"
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

    End Function

    Public Shared Function GetMonthlyIncomeStatemnt(ByRef connData As ConnectionData, ByVal Planid As String, _
    ByVal periodid As Integer, ByVal ForcastType As Integer) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@periodid", periodid)
        If ForcastType = 0 Then
            cmd.CmdText = "BPL_Pro_MonthlyIncomeStatemnt"
        ElseIf ForcastType = 1 Then
            cmd.CmdText = "BPL_Pro_ValueMonthlyIncomeStatemnt"
        End If
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function


    Public Shared Function GetMonthlyIncomeStatemntPro(ByRef connData As ConnectionData, ByVal Planid As String, _
    ByVal DateFrom As String) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@DateFrom", DateFrom)
        cmd.AddParameter("@Midentity", connData.CustomerID)
        cmd.CmdText = "BPL_Pro_MonthlyIncomeStatemntPro"
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function

    Public Shared Function GetYearlyBalanseSheetPro(ByRef connData As ConnectionData, ByVal Planid As String, _
        ByVal DateFrom As String) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@DateFrom", DateFrom)
        cmd.AddParameter("@Midentity", connData.CustomerID)
        cmd.CmdText = "BPL_Pro_AnnualBalanceSheetPro"
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function

    Public Shared Function GetMonthlyBalanseSheetPro(ByRef connData As ConnectionData, ByVal Planid As String, _
    ByVal DateFrom As String) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@DateFrom", DateFrom)
        cmd.AddParameter("@Midentity", connData.CustomerID)
        cmd.CmdText = "BPL_Pro_MonthlyBalanceSheetPro"
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function

    Public Shared Function GetAnnualIncomeStatemntPro(ByRef connData As ConnectionData, ByVal Planid As String, _
  ByVal DateFrom As String) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)
        cmd.AddParameter("@DateFrom", DateFrom)
        cmd.AddParameter("@Midentity", connData.CustomerID)
        cmd.CmdText = "BPL_Pro_AnnualIncomeStatemntPro"
        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function

    Public Shared Function GetAnnualIncomeStatemnt(ByRef connData As ConnectionData, ByVal Planid As String, ByVal ForcastType As Integer) As DataSet

        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        ds = New DataSet
        cmd.AddParameter("@Planid", Planid)

        If ForcastType = 0 Then
            cmd.CmdText = "BPL_Pro_AnnualIncomeStatemnt"
        ElseIf ForcastType = 1 Then
            cmd.CmdText = "BPL_Pro_ValueAnnualIncomeStatemnt"
        End If



        ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
        Return ds
    End Function

#End Region

#Region "Planoutline"

    Public Shared Function GetHeading(ByVal connData As ConnectionData, ByVal PlanID As String) As DataSet
        Dim command As New InfiniCommand("BPL_GetPlanOutLineHeading")
        command.AddParameter("@PlanID", PlanID)
        Return DataAccess.ExecuteDataSet(connData, command)
    End Function


#End Region

    Public Shared Function LastRecord(ByVal CustomerID As Integer) As String

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As New CommandData(CustomerID)
        Dim _strSales_NC_DET As String, _strPurchase_NC_DET As String, _strExpance_NC_DET As String, _strOverhead_NC_DET As String, _strContString As String

        'Sales 
        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_SALESRECORD_NC"
            .AddParameter("@MIdentity", CustomerID)
            Try
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_SALESRECORD_NC" & ex.Message)
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows
            _strSales_NC_DET = _dr.Item(0)
        Next
        _ds.Dispose()

        'Purchase
        With _objCmd
            .ClearParameters()
            .AddParameter("@MIdentity", CustomerID)
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_PURCHASERECORD_NC"
            Try
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_PURCHASERECORD_NC" & ex.Message)
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows
            _strPurchase_NC_DET = _dr.Item(0)
        Next
        _ds.Dispose()

        'Direct Expanse
        With _objCmd
            .ClearParameters()
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_EXPENSERECORD_NC"
            .AddParameter("@MIdentity", CustomerID)
            Try
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_EXPENSERECORD_NC" & ex.Message)
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows
            _strExpance_NC_DET = _dr.Item(0)
        Next
        _ds.Dispose()

        'Overhead's
        With _objCmd
            .ClearParameters()
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_OVERHEADRECORD_NC"
            Try
                .AddParameter("@MIdentity", CustomerID)
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_OVERHEADRECORD_NC" & ex.Message)
            Finally
                _objCmd = Nothing
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows
            _strOverhead_NC_DET = _dr.Item(0)
        Next
        _ds.Dispose()

        _strContString = _strSales_NC_DET & "," & _strPurchase_NC_DET & "," & _strExpance_NC_DET & "," & _strOverhead_NC_DET

        Return _strContString
    End Function
    Private Shared _firstDate As Date
    Private Shared _lastDate As Date
    Public Shared Function ProfitAndLossStatement(ByVal CustomerID As Integer, ByVal datefrom As Date, ByVal dateto As Date) As DataView

        Dim _ds As DataSet, _dr As DataRow, _ds1 As DataSet, _dr1 As DataRow
        Dim _strChk As String, _strLastRecord As String, _strArry() As String, _lowLID As String, _highLID As String
        Dim _strSA As String, _strPA As String, _strEP As String, _strOH As String, _mHead As String, _mHDesc As String
        Dim _currentAmt As Double, _yTDAmt As Double, _bolChkSA As Boolean, _bolChkPur As Boolean, _bolChkExp As Boolean, _bolChkOh As Boolean
        Dim _myFEDate As Date
        Dim _dblGrPSales As Double, _dblGrpPurchase As Double, _dblGrpExpense As Double, _dblGrpOverhead As Double
        Dim _dblGrPYTDSales As Double, _dblGrpYTDPurchase As Double, _dblGrpYTDExpense As Double, _dblGrpYTDOverhead As Double

        'Creating DataTable
        Dim _tbl As New DataTable
        Dim _tblRow As DataRow
        Dim _category As New DataColumn("Category", GetType(String))
        Dim _description As New DataColumn("Description", GetType(String))
        Dim _current As New DataColumn("Current", GetType(Double))
        Dim _yTD As New DataColumn("YTD", GetType(Double))

        'Add The Column to the Datatable's Columns Collection
        _tbl.Columns.Add(_category)
        _tbl.Columns.Add(_description)
        _tbl.Columns.Add(_current)
        _tbl.Columns.Add(_yTD)

        'Check Financial Year
        CheckFinancialYear(CustomerID)

        'Get last record from pro_nc_det with respactive sales,purchase,overhead,direct expance
        _strLastRecord = LastRecord(CustomerID)

        _strArry = _strLastRecord.Split(","c)

        _strSA = _strArry(0)
        _strPA = _strArry(1)
        _strEP = _strArry(2)
        _strOH = _strArry(3)

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        _ds = GetLedgerIDForPANDF(CustomerID)

        For Each _dr In _ds.Tables(0).Rows
            _mHDesc = _dr.Item("Description")
            _mHead = _dr.Item("category")
            _lowLID = _dr.Item("Low")
            _highLID = _dr.Item("High")

            'Get CurrentYear Amt
            _currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

            'Get YTD Amt
            _myFEDate = DateSerial(Year(_lastDate), Month(dateto), dateto.Day)
            _yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

            If _currentAmt <> 0 Or _yTDAmt <> 0 Then

                'Enter New values In DataTable
                If _mHead = "Sales" Then

                    If _bolChkSA = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkSA = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _currentAmt < 0 Then
                        _tblRow("current") = Format(Abs(_currentAmt), "0.00")
                    Else
                        _tblRow("current") = Format((-_currentAmt), "0.00")
                    End If
                    _dblGrPSales += CType(_tblRow("Current"), Double)

                    If _yTDAmt < 0 Then
                        _tblRow("YTD") = Format(Abs(_yTDAmt), "0.00")
                    Else
                        _tblRow("YTD") = Format((-_yTDAmt), "0.00")
                    End If
                    _tbl.Rows.Add(_tblRow)
                    _dblGrPYTDSales += CType(_tblRow("YTD"), Double)

                End If

                If _mHead = "Purchases" Then

                    If _bolChkPur = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkPur = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    _tblRow("current") = Format(_currentAmt, "0.00")
                    _dblGrpPurchase += CType(_tblRow("Current"), Double)

                    _tblRow("YTD") = Format(_yTDAmt, "0.00")
                    _dblGrpYTDPurchase += CType(_tblRow("YTD"), Double)
                    _tbl.Rows.Add(_tblRow)

                End If

                If _mHead = "Direct Expenses" Then

                    If _bolChkExp = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkExp = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    _tblRow("current") = Format(_currentAmt, "0.00")
                    _dblGrpExpense += CType(_tblRow("Current"), Double)
                    _tblRow("YTD") = Format(Abs(_yTDAmt), "0.00")
                    _dblGrpYTDExpense += CType(_tblRow("YTD"), Double)
                    _tbl.Rows.Add(_tblRow)

                End If

                If _mHead = "Overheads" Then

                    If _bolChkOh = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkOh = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc
                    _tblRow("current") = Format(Abs(_currentAmt), "0.00")
                    _dblGrpOverhead += CType(_tblRow("Current"), Double)
                    _tblRow("YTD") = Format(Abs(_yTDAmt), "0.00")
                    _dblGrpYTDOverhead += CType(_tblRow("YTD"), Double)
                    _tbl.Rows.Add(_tblRow)

                End If

            End If

            If _mHead = "Sales" And _strSA = _mHDesc And _bolChkSA = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Sales"
                _tblRow("Current") = _dblGrPSales
                _tblRow("YTD") = _dblGrPYTDSales
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Purchases" And _strPA = _mHDesc And _bolChkPur Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Purchases"
                _tblRow("Current") = _dblGrpPurchase
                _tblRow("YTD") = _dblGrpYTDPurchase
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Direct Expenses" And _strEP = _mHDesc And _bolChkExp Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Direct Expenses"
                _tblRow("Current") = _dblGrpExpense
                _tblRow("YTD") = _dblGrpYTDExpense
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Overheads" And _strOH = _mHDesc And _bolChkOh Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Overheads"
                _tblRow("Current") = _dblGrpOverhead
                _tblRow("YTD") = _dblGrpYTDOverhead
                _tbl.Rows.Add(_tblRow)
            End If

        Next

        'Adding Gross P&L Amt In Datatable
        _tblRow = _tbl.NewRow()
        _tblRow("Category") = ""
        _tblRow("Description") = "Gross Profit / Loss :"
        _tblRow("Current") = (_dblGrPSales - _dblGrpPurchase - _dblGrpExpense)
        _tblRow("YTD") = (_dblGrPYTDSales - _dblGrpYTDPurchase - _dblGrpYTDExpense)
        _tbl.Rows.Add(_tblRow)

        _tblRow = _tbl.NewRow()
        _tblRow("Category") = ""
        _tblRow("Description") = "Net Profit / Loss :"
        _tblRow("Current") = (_dblGrPSales - _dblGrpPurchase - _dblGrpExpense) - (_dblGrpOverhead)
        _tblRow("YTD") = (_dblGrPYTDSales - _dblGrpYTDPurchase - _dblGrpYTDExpense) - (_dblGrpYTDOverhead)
        _tbl.Rows.Add(_tblRow)

        Dim Dv As DataView = New DataView(_tbl)
        Return Dv

    End Function

    Public Shared Function GetProfitAndLossCurrentAmt(ByVal CustomerID As Integer, ByVal _lowLID As String, ByVal _highLID As String, ByVal _dateFrom As Date, ByVal _dateTo As Date) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETPROFITANDLOSSAMT"
            .AddParameter("@lowLID", _lowLID)
            .AddParameter("@highLID", _highLID)
            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETPROFITANDLOSSAMT" & ex.Message)
            Finally
                _objCmd = Nothing
            End Try

            For Each _dr In _ds.Tables(0).Rows
                _debit += CType(_dr.Item("SumOfdebit"), Double)
                _credit += CType(_dr.Item("SumOfcredit"), Double)
            Next
            _ds.Dispose()
            _ds = Nothing

            _totalAmt = Format(_debit - _credit, "0.00")
            Return _totalAmt

        End With
    End Function

    Public Shared Function GetLedgerIDForPANDF(ByVal customerID As Integer) As DataSet

        Dim _objCmd As New CommandData(customerID)
        Dim _ds As DataSet

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETLEDGERIDFORPANDL"

            Try
                .AddParameter("@MIdentity", customerID)
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORPANDL" & ex.Message)
            Finally
                _objCmd = Nothing
            End Try

            Return _ds
        End With

    End Function

    Public Shared Sub CheckFinancialYear(ByVal CustomerID As Integer)

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_FINANCIALYEAR"
            Try
                _objCmd.AddParameter("@MIdentity", CustomerID)
                _ds = .Execute(ExecutionType.ExecuteDataSet)
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            Finally
                _objCmd = Nothing
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows

            _firstDate = CType(_dr(0), Date)
            _lastDate = CType(_dr(1), Date)
        Next

        _ds.Dispose()
        _ds = Nothing

    End Sub

    Public Overrides Sub Save()
        Dim _changedCells As New Hashtable
        Dim h As New Hashtable(Rows.Count)
        Dim dr As DataRow
        Dim i As Integer = 0
        For Each dr In Rows
            h.Add(dr, i)
            i += 1
        Next
        Dim NewText As String
        Dim Row As Integer
        Dim e As DataColumnChangeEventArgs
        For Each e In ChangedCells
            Row = CInt(h(e.Row))
            If (Val(e.Row("ID")) > 0) Then
                If Not (e.Column.Ordinal = 13 Or e.Column.ColumnName = "ID") Then
                    NewText = CStr(e.ProposedValue)
                    ' Update for All Columns Except Totals And ID
                    Dim tmpSummary As BLL.BusinessPlan = _CurrentPlan
                    If Row = 4 Then
                        If (Len(NewText) <> 4 Or IsNumeric(Trim(NewText)) = False) Then
                            Throw New Exception("Invalid Start Year Value")
                            NewText = CStr(tmpSummary.StartYear)
                        End If
                    End If
                    If Row = 5 Then
                        Dim startingMonth As String = Trim(NewText)
                        Select Case startingMonth
                            Case "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                                NewText = startingMonth
                            Case Else
                                Throw New Exception("Invalid Start Month Value")
                                NewText = tmpSummary.StartMonth
                        End Select
                    End If
                    If Row = 7 Then
                        If Not ((Trim(NewText).ToLower = "startup") Or (Trim(NewText).ToLower = "ongoing")) Then
                            Throw New Exception("Invalid Business Status Value")
                            If tmpSummary.IsOngoing Then NewText = "OnGoing" Else NewText = "StartUp"
                        End If
                    End If
                    If Row = 8 Then
                        If Not ((Trim(NewText).ToLower = "products") Or (Trim(NewText).ToLower = "services") Or (Trim(NewText).ToLower = "both")) Then
                            Throw New Exception("Invalid Business Goods Value")
                            NewText = tmpSummary.BusinessGoods.ToString
                        End If
                    End If
                    _changedCells.Add(e.Row(0), Trim(NewText))
                End If
            End If
        Next
        If (_changedCells.Count > 0) Then
            Dim key As String
            For Each key In _changedCells.Keys
                SaveRecs(key, CStr(_changedCells.Item(key)))
            Next
            _changedCells.Clear()
        End If
        Saved()
    End Sub
    Private Sub SaveRecs(ByVal cat As String, ByVal value As String)
        Dim tmpSummary As BLL.BusinessPlan = _CurrentPlan
        Select Case (cat)
            Case "Plan Description"
                tmpSummary.BusinessDescription = value
            Case "StartYear"
                tmpSummary.StartYear = CInt(value)
            Case "StartMonth"
                tmpSummary.StartMonth = value
            Case "Business Status"
                If value = "OnGoing" Then
                    tmpSummary.IsOngoing = True
                Else
                    tmpSummary.IsOngoing = False
                End If
            Case "BusinessGoods"
                tmpSummary.BusinessGoods = CType(CInt(value), BusinessGoodsType)
            Case "EstimatedStockTurnOverRate %"
                tmpSummary.InventoryTurnover = CSng(value)
            Case "SalesOnCreditPercent"
                tmpSummary.SalesOnCreditPercent = CSng(value)
            Case "CollectionPeriod"
                tmpSummary.CollectionPeriod = CInt(value)
            Case "Payment Days"
                tmpSummary.PaymentDays = CInt(value)
            Case "ShortTermInterestRate %"
                tmpSummary.ShortTermInterestRate = CSng(value)
            Case "LongTermInterestRate %"
                tmpSummary.LongTermInterestRate = CSng(value)
            Case "EstimatedTaxRate %"
                tmpSummary.EstimatedTaxRate = CSng(value)
            Case "NonPayrollCashExpenses %"
                tmpSummary.NonPayrollCashExpense = CSng(value)
            Case "Product"
                tmpSummary.ProductCategoryName = value
            Case "SalesAndDistribution"
                tmpSummary.SDCategoryName = value
            Case "GenralAndAdministration"
                tmpSummary.GACategoryName = value
            Case "Others"
                tmpSummary.OtherCategoryName = value
        End Select
        _CurrentPlan.BusinessDescription = tmpSummary.BusinessDescription
        _CurrentPlan.BusinessGoods = tmpSummary.BusinessGoods
        _CurrentPlan.PlanID = tmpSummary.PlanID
        _CurrentPlan.PlanName = tmpSummary.PlanName
        _CurrentPlan.IsOngoing = tmpSummary.IsOngoing
        _CurrentPlan.CollectionPeriod = tmpSummary.CollectionPeriod
        _CurrentPlan.DisplayExpense = tmpSummary.DisplayExpense
        _CurrentPlan.InventoryTurnover = tmpSummary.InventoryTurnover
        _CurrentPlan.EstimatedTaxRate = tmpSummary.EstimatedTaxRate
        _CurrentPlan.GACategoryName = tmpSummary.GACategoryName
        _CurrentPlan.LongTermInterestRate = tmpSummary.LongTermInterestRate
        _CurrentPlan.NonPayrollCashExpense = tmpSummary.NonPayrollCashExpense
        _CurrentPlan.OtherCategoryName = tmpSummary.OtherCategoryName
        _CurrentPlan.PastPerformanceData = tmpSummary.PastPerformanceData
        _CurrentPlan.PaymentDays = tmpSummary.PaymentDays
        _CurrentPlan.ProductCategoryName = tmpSummary.ProductCategoryName
        _CurrentPlan.SalesOnCreditPercent = tmpSummary.SalesOnCreditPercent
        _CurrentPlan.SDCategoryName = tmpSummary.SDCategoryName
        _CurrentPlan.ShortTermInterestRate = tmpSummary.ShortTermInterestRate
        _CurrentPlan.StartMonth = tmpSummary.StartMonth
        _CurrentPlan.StartupData = tmpSummary.StartupData
        _CurrentPlan.StartYear = tmpSummary.StartYear
        _CurrentPlan.ManageInventory = tmpSummary.ManageInventory
        _CurrentPlan.PersonnelBurden = tmpSummary.PersonnelBurden
        SaveBusinessPlan(_ConnData, _CurrentPlan)
    End Sub

#Region ".........................Business Plan Methods "
    Protected Overrides Sub AddHeadings()
        Columns.Add(New DataColumn("", GetType(String)))
        Columns.Add(New DataColumn(" ", GetType(String)))
        Columns.Add(New DataColumn("ID", GetType(String), "1"))
    End Sub

    Private Function PopulateDataTable() As DataTable
        Dim dt As DataTable = Me
        Dim dr As DataRow
        AddHeadings()

        ' method to populate data in TList 
        Dim tmpSummary As InfiniLogic.BusinessPlan.BLL.BusinessPlan = _currentPlan
        'dr = AddNewRow("BusinessID")
        'dr.Item(1) = tmpSummary.PlanID
        'dr.Item("ID") = "1"
        dr = AddNewRow("Plan Name", "")
        dr.Item(1) = tmpSummary.PlanName
        'dr.Item(2) = "0"
        AddNewRow("Plan Description", "").Item(1) = tmpSummary.BusinessDescription
        AddNewRow("", "")
        AddNewRow("StartYear", "").Item(1) = tmpSummary.StartYear
        AddNewRow("StartMonth", "").Item(1) = tmpSummary.StartMonth
        AddNewRow("", "")
        Dim BusinessStatus As String
        If tmpSummary.IsOngoing Then
            BusinessStatus = "OnGoing"
        Else
            BusinessStatus = "Startup"
        End If
        AddNewRow("Business Status", "").Item(1) = BusinessStatus
        AddNewRow("BusinessGoods", "").Item(1) = tmpSummary.BusinessGoods
        If tmpSummary.BusinessGoods = BusinessGoodsType.Products Or tmpSummary.BusinessGoods = BusinessGoodsType.Both Then
            AddNewRow("EstimatedStockTurnOverRate %", "").Item(1) = tmpSummary.InventoryTurnover
        End If

        If tmpSummary.ManageInventory = True Then
            'AddNewRow("SalesOnCreditPercent").Item(1) = tmpSummary.SalesOnCreditPercent
            AddNewRow("CollectionPeriod", "").Item(1) = tmpSummary.CollectionPeriod
        End If
        AddNewRow("", "")
        AddNewRow("Payment Days", "").Item(1) = tmpSummary.PaymentDays
        AddNewRow("ShortTermInterestRate %", "").Item(1) = tmpSummary.ShortTermInterestRate
        AddNewRow("LongTermInterestRate %", "").Item(1) = tmpSummary.LongTermInterestRate
        AddNewRow("EstimatedTaxRate %", "").Item(1) = tmpSummary.EstimatedTaxRate
        AddNewRow("NonPayrollCashExpenses %", "").Item(1) = tmpSummary.NonPayrollCashExpense
        AddNewRow("SalesOnCreditPercent", "").Item(1) = tmpSummary.SalesOnCreditPercent
        AddNewRow("", "")
        If tmpSummary.DisplayExpense = True Then
            AddNewRow("Product", "").Item(1) = tmpSummary.ProductCategoryName
            AddNewRow("SalesAndDistribution", "").Item(1) = tmpSummary.SDCategoryName
            AddNewRow("GenralAndAdministration", "").Item(1) = tmpSummary.GACategoryName
            AddNewRow("Others", "").Item(1) = tmpSummary.OtherCategoryName
        End If
        Return dt
    End Function
    Public Shared Function IfPlanAlreadyExists(ByVal connData As ConnectionData, ByVal BusinessName As String) As Boolean
        Dim command As New InfiniCommand("BPL_IfPlanExists")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@BusinessName", BusinessName)
        Return CBool(DataAccess.ExecuteScalar(connData, command))
    End Function
    Public Shared Function IfPlanAlreadyExists(ByVal connData As ConnectionData, ByRef bPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Boolean
        Dim command As New InfiniCommand("BPL_IfPlanExists")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@BusinessName", bPlan.PlanName)
        Return CBool(DataAccess.ExecuteScalar(connData, command))
    End Function
    ' Changed by Win-Saira , DAte : 2/3/2006
    Public Shared Sub SaveSamplePlan(ByVal connData As ConnectionData, ByVal planID As String, ByVal planName As String)
        Dim command As New InfiniCommand("BPL_SaveSamplePlan")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", planID)

        If planName <> "" Then
            command.AddParameter("@NewPlanName", planName)
        End If
        command.AddParameter("@PlanDate", Date.Now)
        DataAccess.ExecuteNonQuery(connData, command)
    End Sub
    ' Changed by Win-Saira , DAte : 2/3/2006
    Public Shared Sub PermanentlyDeletePlan(ByVal connData As ConnectionData, ByVal planID As String)
        Dim command As New InfiniCommand("BPL_PermanentlyDeletePlan")

        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", planID)
        DataAccess.ExecuteNonQuery(connData, command)
    End Sub

    Public Shared Function PlanNameByID(ByVal connData As ConnectionData, ByVal planID As String) As String
        Dim command As New InfiniCommand("BPL_GetPlanNameByID")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", planID)
        Return CStr(DataAccess.ExecuteScalar(connData, command))
    End Function
    Public Shared Function SearchPlanByName(ByVal connData As ConnectionData, ByVal Planname As String) As DataSet
        Dim command As New InfiniCommand("BPL_GetPlanNameBySearch")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@Planname", Planname)
        Return DataAccess.ExecuteDataSet(connData, command)
    End Function

    Public Shared Function SearchSamplePlanByName(ByVal connData As ConnectionData, ByVal Planname As String) As DataSet
        Dim command As New InfiniCommand("DBSERVER.BizPlanSamples.DBO.BPL_GetSamplePlanNameBySearch")
        command.AddParameter("@Planname", Planname)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds

    End Function


    ' Creat new plan when new plan button is click  

    Public Shared Function CreateNewBusinessPlan(ByVal connData As ConnectionData, ByRef bPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Boolean
        Dim command As New InfiniCommand("BPL_InsertNewPlan")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@businessName", bPlan.PlanName)
        command.AddParameter("@IsOngoing", bPlan.IsOngoing)
        command.AddParameter("@businessGoods", bPlan.BusinessGoods)
        command.AddParameter("@stockManagement", bPlan.ManageInventory)
        command.AddParameter("@salesOnCredit", bPlan.SalesOnCreditPercent)
        command.AddParameter("@collectionPeriod", bPlan.CollectionPeriod)
        command.AddParameter("@displayExpense", bPlan.DisplayExpense)
        command.AddParameter("@stockTurnover", bPlan.InventoryTurnover)
        command.AddParameter("@shortTermInterestRate", bPlan.ShortTermInterestRate)
        command.AddParameter("@longTermInterestRate", bPlan.LongTermInterestRate)
        command.AddParameter("@estimatedTaxRate", bPlan.EstimatedTaxRate)
        command.AddParameter("@nonPayrollCashExpense", bPlan.NonPayrollCashExpense)
        command.AddParameter("@startYear", bPlan.StartYear)
        command.AddParameter("@startMonth", bPlan.StartMonth)
        command.AddParameter("@PaymentDays", bPlan.PaymentDays)
        command.AddParameter("@Products", IIf(bPlan.ProductCategoryName = "", "Products", bPlan.ProductCategoryName))
        command.AddParameter("@SalesAndDistribution", IIf(bPlan.SDCategoryName = "", "SalesAndDistribution", bPlan.SDCategoryName))
        command.AddParameter("@GenralAndAdministration", IIf(bPlan.GACategoryName = "", "GeneralAndAdministration", bPlan.GACategoryName))
        command.AddParameter("@Others", IIf(bPlan.OtherCategoryName = "", "Others", bPlan.OtherCategoryName))
        command.AddParameter("@businessDescription", bPlan.BusinessDescription)
        command.AddParameter("@PersonnelBurden", bPlan.PersonnelBurden)
        command.AddParameter("@SellOnCredit", bPlan.SellOnCredit)
        command.AddParameter("@StandardLongTerm", bPlan.StandardOrLongTerm)
        command.AddParameter("@SalesForecastType", bPlan.SalesForecastType)
        command.AddParameter("@IBusinessName", bPlan.BusinessName)
        command.AddParameter("@CompanyBusinessOwnerShip", bPlan.CompanyBusinessOwnership)
        command.AddParameter("@ContactDetails", bPlan.ContactDetails)
        command.AddParameter("@Currency", bPlan.Currency)
        command.AddParameter("@PlanDate", Date.Now)
        DataAccess.ExecuteNonQuery(connData, command)
    End Function
    'Tht method call whn user click Finished button

    Public Function SaveBusinessPlan(ByVal connData As ConnectionData, ByRef bPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Boolean
        Dim command As New InfiniCommand("BPL_UpdatePlan")

        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", bPlan.PlanID)
        command.AddParameter("@businessName", bPlan.PlanName)
        command.AddParameter("@IsOngoing", bPlan.IsOngoing)
        command.AddParameter("@businessGoods", bPlan.BusinessGoods)
        command.AddParameter("@stockManagement", bPlan.ManageInventory)
        command.AddParameter("@salesOnCredit", bPlan.SalesOnCreditPercent)
        command.AddParameter("@collectionPeriod", bPlan.CollectionPeriod)
        command.AddParameter("@displayExpense", bPlan.DisplayExpense)
        command.AddParameter("@stockTurnover", bPlan.InventoryTurnover)
        command.AddParameter("@shortTermInterestRate", bPlan.ShortTermInterestRate)
        command.AddParameter("@longTermInterestRate", bPlan.LongTermInterestRate)
        command.AddParameter("@estimatedTaxRate", bPlan.EstimatedTaxRate)
        command.AddParameter("@nonPayrollCashExpense", bPlan.NonPayrollCashExpense)
        command.AddParameter("@startYear", bPlan.StartYear)
        command.AddParameter("@startMonth", bPlan.StartMonth)
        command.AddParameter("@PaymentDays", bPlan.PaymentDays)
        command.AddParameter("@Products", IIf(bPlan.ProductCategoryName = "", "Products", bPlan.ProductCategoryName))
        command.AddParameter("@SalesAndDistribution", IIf(bPlan.SDCategoryName = "", "SalesAndDistribution", bPlan.SDCategoryName))
        command.AddParameter("@GenralAndAdministration", IIf(bPlan.GACategoryName = "", "GeneralAndAdministration", bPlan.GACategoryName))
        command.AddParameter("@Others", IIf(bPlan.OtherCategoryName = "", "Others", bPlan.OtherCategoryName))
        command.AddParameter("@businessDescription", bPlan.BusinessDescription)
        command.AddParameter("@PersonnelBurden", bPlan.PersonnelBurden)
        command.AddParameter("@StandardLongTerm", bPlan.StandardOrLongTerm)
        command.AddParameter("@SellOnCredit", bPlan.SellOnCredit)
        command.AddParameter("@SalesForecastType", bPlan.SalesForecastType)
        'command.AddParameter("@IBusinessName", bPlan.BusinessName)
        'command.AddParameter("@CompanyBusinessOwnerShip", bPlan.CompanyBusinessOwnerShip)
        'command.AddParameter("@ContactDetails", bPlan.ContactDetails)
        If GetCurrency(bPlan.Currency) = True Then
            command.AddParameter("@Currency", CStr(HttpContext.Current.Session("CurrencyValue")))
        Else
            command.AddParameter("@Currency", bPlan.Currency)
            HttpContext.Current.Session("CurrencyValue") = bPlan.Currency
        End If
        command.AddParameter("@PlanDate", Date.Now)

        DataAccess.ExecuteNonQuery(connData, command)
    End Function
    Private Function GetCurrency(ByVal value As String) As Boolean
        Dim strSessionCurrency As String()
        Dim strValueCurrency As String()

        strSessionCurrency = Split(CStr(HttpContext.Current.Session("CurrencyValue")), ",")
        strValueCurrency = Split(value, ",")

        If strValueCurrency.Length > 1 Then
            If Not strSessionCurrency(0) = strValueCurrency(0) Then Return False
        End If

        Return True
    End Function
    Public Shared Function LoadPlanList(ByVal connData As ConnectionData) As ArrayList
        Dim command As New InfiniCommand("BPL_GetBusinessPlans")
        command.AddParameter("@MIdentity", connData.CustomerID)

        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)
        Dim businessPlans As New ArrayList(10)
        Dim Index As Integer = 0
        While rd.Read
            Dim b As New BusinessTypes
            b.PlanID = CInt(rd(0))
            b.PlanName = CStr(rd(1))
            b.BusinessDescription = CStr(rd(2))
            b.BusinessStatus = CStr(rd(3))
            businessPlans.Add(b)
        End While
        Return businessPlans
    End Function
    Public Shared Function LoadSamplePlanList(ByVal connData As ConnectionData) As ArrayList

        Dim command As New InfiniCommand("BPL_GetSamplePlansList")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)
        Dim businessPlans As New ArrayList(10)
        Dim Index As Integer = 0
        While rd.Read()
            Dim b As New BusinessTypes
            b.PlanID = CInt(rd(0))
            b.PlanName = CStr(rd(1))
            b.BusinessDescription = CStr(rd(2))
            b.BusinessStatus = CStr(rd(3))
            businessPlans.Add(b)
        End While
        Return businessPlans
    End Function
    'Public Shared Function GetBusinessType(ByVal connData As ConnectionData) As ArrayList
    '    Dim rd As SqlDataReader = DataAccess.ExecuteDataReader(connData, New InfiniCommand("BusinessTypes"))
    '    Dim businessPlans As New ArrayList(10)
    '    Dim Index As Integer = 0
    '    While rd.Read
    '        Dim b As New BusinessTypes
    '        b.PlanID = rd(0)
    '        b.PlanName = rd(1)
    '        b.BusinessDescription = rd(2)
    '        b.BusinessStatus = rd(3)
    '        businessPlans.Add(b)
    '    End While
    '    Return businessPlans
    'End Function

    Public Shared Function GetBusinessSummary(ByVal connData As ConnectionData, ByVal businessID As Integer) As InfiniLogic.BusinessPlan.BLL.BusinessPlan

        Dim command As New InfiniCommand("BusinessPlanSummary")
        command.AddParameter("@PlanID", businessID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)

        Dim b As New InfiniLogic.BusinessPlan.BLL.BusinessPlan

        If rd.Read() Then
            b.PlanID = CStr(rd("BusinessID"))
            b.PlanName = CStr(rd("PlanName"))
            b.BusinessDescription = CStr(rd("BusinessDescription"))
            b.IsOngoing = CBool(rd("IsOngoing"))
            b.BusinessGoods = CType(CInt(rd("BusinessGoods")), BusinessGoodsType)
            b.CollectionPeriod = CInt(rd("CollectionPeriod"))
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.InventoryTurnover = CSng(rd("EstimatedStockTurnOver"))
            b.EstimatedTaxRate = CSng(rd("EstimatedTaxRate"))
            If b.DisplayExpense = True Then
                b.GACategoryName = CStr(rd("GenralAndAdministration"))
                b.OtherCategoryName = CStr(rd("Others"))
                b.ProductCategoryName = CStr(rd("Products"))
                b.SDCategoryName = CStr(rd("SalesAndDistribution"))
            End If

            b.LongTermInterestRate = CSng(rd("LongTermInterestRate"))
            b.NonPayrollCashExpense = CSng(rd("NonPayrollCashExpenses"))
            b.SalesOnCreditPercent = CSng(rd("SalesOnCreditPercent"))
            b.ShortTermInterestRate = CSng(rd("ShortTermInterestRate"))
            b.StartMonth = CStr(rd("StartMonth"))
            b.StartYear = CInt(rd("StartYear"))
            b.PaymentDays = CInt(rd("PaymentDays"))
            b.ManageInventory = CBool(rd("StockManagement"))
            'If b.CollectionPeriod = "" Then
            '    b.ManageInventory = False
            'Else
            '    b.ManageInventory = True
            'End If
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.PersonnelBurden = CSng(rd("PersonalBurden"))
            b.StandardOrLongTerm = CType(CInt(rd("StandardLongTerm")), StandardLongTerm)
            b.SalesForecastType = CType(CInt(rd("SalesForecastType")), SalesForecastType)
        End If
        Return b
    End Function
    'Tht method call whn user click Finished button then load its plan id 

    Public Shared Function GetBusinessSummary(ByVal connData As ConnectionData, ByVal businessName As String) As InfiniLogic.BusinessPlan.BLL.BusinessPlan
        Dim businessID As String
        Dim command As New InfiniCommand("BPL_GetBusinessID")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@businessName", businessName)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)
        If rd.Read Then
            businessID = CStr(rd(0))
        End If
        Return GetBusinessPlanSummary(connData, businessID)
    End Function

    'change on 21aprl 2006 by win-saira
    Public Shared Function GetCurrencySymbols(ByVal connData As ConnectionData) As DataSet
        Dim dsCurrency As DataSet = DataAccess.ExecuteDataSet(connData, New InfiniCommand("BPL_GetCurrencySymbol"))
        Return dsCurrency
    End Function

    Public Shared Function GetListValue(ByVal connData As ConnectionData, ByRef Text As String) As DataSet
        Dim command As New InfiniCommand("BPL_GetListValue")
        command.AddParameter("@ListValue", Text)

        Return DataAccess.ExecuteDataSet(connData, command)
    End Function
#End Region

#Region "..........................Business Plan Web Methods"

    Public Shared Function GetPlansList(ByVal connData As ConnectionData) As DataTable
        Dim command As New InfiniCommand("BPL_GetBusinessPlans")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds.Tables(0)
    End Function

    ' New Code    ' Win-saira  Date :27/02/2006
    Public Shared Function GetLastPlanTest(ByVal connData As ConnectionData) As DataTable

        Dim command As New InfiniCommand("BPL_CheckLastPlan")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("Date", Date.Now)

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds.Tables(0)
    End Function
    ' New Code    ' Win-saira  Date :27/02/2006

    Public Shared Function GetEmployeeLastPlan(ByVal connData As ConnectionData) As DataTable
        Dim MIdentity As Integer
        Try
            Dim command As New InfiniCommand("BPL_CheckEmployeePlan")
            command.AddParameter("@MIdentity", connData.CustomerID)
            Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
            Return ds.Tables(0)
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try

    End Function

    Public Shared Function GetLastPlan(ByVal connData As ConnectionData) As DataTable
        Dim MIdentity As Integer
        Try
            Dim command As New InfiniCommand("BPL_CheckLastPlan")
            command.AddParameter("@MIdentity", connData.CustomerID)
            Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
            Return ds.Tables(0)
        Catch ex As Exception
            Dim str As String = ex.Message
        End Try

    End Function


    Public Shared Function GetSamplePlansListFromRemoteServer(ByVal connData As ConnectionData) As DataTable
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, New InfiniCommand("BPL_GetSamplePlansListFromRemoteServer"))
        Return ds.Tables(0)
    End Function
    Public Shared Function GetSamplePlansList(ByVal connData As ConnectionData) As DataTable

        Dim command As New InfiniCommand("BPL_GetSamplePlansList")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds.Tables(0)
    End Function

    Public Shared Function GetExportedPlansList(ByVal connData As ConnectionData) As DataTable
        Dim command As New InfiniCommand("BPL_GetExportedPlansList")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds.Tables(0)
    End Function

    Public Shared Function GetLastPlanID(ByVal connData As ConnectionData) As Integer
        Dim command As New InfiniCommand("BPL_GetLastPlanID")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim DataReader As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)

        If DataReader.Read() Then
            Return CInt(DataReader("PlanID"))
        End If
        'Dim planID As Integer = CInt(DataAccess.ExecuteScalar(connData, New InfiniCommand("BPL_GetLastPlanID")))
        'Return planID
    End Function

    Public Shared Function CheckifPlanExistsWithTheSameName(ByVal connData As ConnectionData, ByVal PlanName As String) As Integer
        Dim command As New InfiniCommand("BPL_CheckPlanWithSameName")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanName", PlanName)
        Dim DataReader As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)

        If DataReader.Read() Then
            Return CInt(DataReader("PlanID"))
        End If
    End Function
    Public Shared Function CopyPlanAndGetBusinessPlanSummary(ByVal connData As ConnectionData, ByVal businessID As String) As InfiniLogic.BusinessPlan.BLL.BusinessPlan

        Dim str As String = CType(GetProfileCurrency(connData, businessID).Tables(0).Rows(0).Item(0), String)
        HttpContext.Current.Session("CopyPlanid") = Nothing

        Dim command As New InfiniCommand("BPL_CopyPlanAndGetBusinessPlanSummary")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", businessID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)
        Dim currencyValue As String()
        Dim b As New InfiniLogic.BusinessPlan.BLL.BusinessPlan

        If rd.Read() Then
            b.PlanID = CStr(rd("PlanID"))
            HttpContext.Current.Session("CopyPlanid") = b.PlanID
            b.PlanName = CStr(rd("BusinessName"))
            b.BusinessDescription = CStr(rd("BusinessDescription"))
            b.IsOngoing = CBool(rd("IsOngoing"))
            b.BusinessGoods = CType(CInt(rd("BusinessGoods")), BusinessGoodsType)
            b.CollectionPeriod = CInt(rd("CollectionPeriod"))
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.InventoryTurnover = CSng(rd("EstimatedStockTurnOver"))
            b.EstimatedTaxRate = CSng(rd("EstimatedTaxRate"))
            If b.DisplayExpense = True Then
                b.GACategoryName = CStr(rd("GenralAndAdministration"))
                b.OtherCategoryName = CStr(rd("Others"))
                b.ProductCategoryName = CStr(rd("Products"))
                b.SDCategoryName = CStr(rd("SalesAndDistribution"))
            End If

            b.LongTermInterestRate = CSng(rd("LongTermInterestRate"))
            b.NonPayrollCashExpense = CSng(rd("NonPayrollCashExpenses"))
            b.SalesOnCreditPercent = CSng(rd("SalesOnCredit"))
            b.ShortTermInterestRate = CSng(rd("ShortTermInterestRate"))
            b.StartMonth = CStr(rd("StartMonth"))
            b.StartYear = CInt(rd("StartYear"))
            b.PaymentDays = CInt(rd("PaymentDays"))
            b.ManageInventory = CBool(rd("StockManagement"))
            b.SellOnCredit = CBool(rd("SellOnCredit"))
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.PersonnelBurden = CSng(rd("PersonalBurden"))
            b.StandardOrLongTerm = CType(CInt(rd("StandardLongTerm")), StandardLongTerm)
            b.SalesForecastType = CType(CInt(rd("SalesForecastType")), SalesForecastType)
            HttpContext.Current.Session("CurrencyValue") = CStr(rd("Currency")) 'str
            'b.Currency = str


            If IsNothing(HttpContext.Current.Session("CurrencyValue")) Or CStr(HttpContext.Current.Session("CurrencyValue")) = "" Then HttpContext.Current.Session("CurrencyValue") = CStr(rd("Currency"))

            currencyValue = Split(str, ",")
            If currencyValue.Length - 1 > 0 Then
                b.Currency = currencyValue(1)
            Else
                b.Currency = CStr(rd("Currency"))
            End If

        End If
        Return b
    End Function
    Public Shared Function CheckIfItIsASamplePlan(ByVal connData As ConnectionData, ByVal planID As String) As Boolean
        Dim result As Boolean = False
        Dim command As New InfiniCommand("BPL_GetBusinessPlanInfoByPlanID")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", planID)
        Dim DataReader As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)

        If DataReader.Read() Then
            If CBool(DataReader("SamplePlan")) = True Then
                result = True
            End If
        End If

        Return result
    End Function

    ' Get Summary when new plan is going to load either by ist time or by Wizard changings 
    Public Shared Function GetBusinessPlanSummary(ByVal connData As ConnectionData, ByVal businessID As String) As InfiniLogic.BusinessPlan.BLL.BusinessPlan
        Dim command As New InfiniCommand("BPL_GetBusinessPlanSummary")
        command.AddParameter("@MIdentity", connData.CustomerID)
        command.AddParameter("@PlanID", businessID)
        Dim rd As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)
        Dim currencyValue As String()
        Dim b As New InfiniLogic.BusinessPlan.BLL.BusinessPlan

        If rd.Read() Then
            b.PlanID = CStr(rd("PlanID"))
            b.PlanName = CStr(rd("BusinessName"))
            b.BusinessDescription = CStr(rd("BusinessDescription"))
            b.IsOngoing = CBool(rd("IsOngoing"))
            b.BusinessGoods = CType(CInt(rd("BusinessGoods")), BusinessGoodsType)
            b.CollectionPeriod = CInt(rd("CollectionPeriod"))
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.InventoryTurnover = CSng(rd("EstimatedStockTurnOver"))
            b.EstimatedTaxRate = CSng(rd("EstimatedTaxRate"))
            If b.DisplayExpense = True Then
                b.GACategoryName = CStr(rd("GenralAndAdministration"))
                b.OtherCategoryName = CStr(rd("Others"))
                b.ProductCategoryName = CStr(rd("Products"))
                b.SDCategoryName = CStr(rd("SalesAndDistribution"))
            End If

            b.LongTermInterestRate = CSng(rd("LongTermInterestRate"))
            b.NonPayrollCashExpense = CSng(rd("NonPayrollCashExpenses"))
            b.SalesOnCreditPercent = CSng(rd("SalesOnCredit"))
            b.ShortTermInterestRate = CSng(rd("ShortTermInterestRate"))
            b.StartMonth = CStr(rd("StartMonth"))
            b.StartYear = CInt(rd("StartYear"))
            b.PaymentDays = CInt(rd("PaymentDays"))
            b.ManageInventory = CBool(rd("StockManagement"))
            b.SellOnCredit = CBool(rd("SellOnCredit"))
            b.DisplayExpense = CBool(rd("DisplayExpense"))
            b.PersonnelBurden = CSng(rd("PersonalBurden"))
            b.StandardOrLongTerm = CType(CInt(rd("StandardLongTerm")), StandardLongTerm)
            b.SalesForecastType = CType(CInt(rd("SalesForecastType")), SalesForecastType)
            HttpContext.Current.Session("CurrencyValue") = CStr(rd("Currency"))


            '//it is use convert id + currency type into only currency type

            If IsNothing(HttpContext.Current.Session("CurrencyValue")) Or CStr(HttpContext.Current.Session("CurrencyValue")) = "" Then HttpContext.Current.Session("CurrencyValue") = CStr(rd("Currency"))

            currencyValue = Split(CStr(rd("Currency")), ",")
            If currencyValue.Length - 1 > 0 Then
                b.Currency = currencyValue(1)
            Else
                b.Currency = CStr(rd("Currency"))
            End If

        End If
        Return b
    End Function
    ' ' New Code    ' Win-saira  Date :27/02/2006

    Public Shared Function SaveBusinessPlanSummary(ByVal connData As ConnectionData, ByRef bPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan) As Boolean

        Dim flag As Boolean = True
        Dim cmd As New CommandData(connData.CustomerID)
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_InsertNewPlan"
            cmd.AddParameter("@businessName", bPlan.PlanName)
            cmd.AddParameter("@IsOngoing", bPlan.IsOngoing)
            cmd.AddParameter("@businessGoods", bPlan.BusinessGoods)
            cmd.AddParameter("@stockManagement", bPlan.ManageInventory)
            cmd.AddParameter("@salesOnCredit", bPlan.SalesOnCreditPercent)
            cmd.AddParameter("@collectionPeriod", bPlan.CollectionPeriod)
            cmd.AddParameter("@displayExpense", bPlan.DisplayExpense)
            cmd.AddParameter("@stockTurnover", bPlan.InventoryTurnover)
            cmd.AddParameter("@shortTermInterestRate", bPlan.ShortTermInterestRate)
            cmd.AddParameter("@longTermInterestRate", bPlan.LongTermInterestRate)
            cmd.AddParameter("@estimatedTaxRate", bPlan.EstimatedTaxRate)
            cmd.AddParameter("@nonPayrollCashExpense", bPlan.NonPayrollCashExpense)
            cmd.AddParameter("@startYear", bPlan.StartYear)
            cmd.AddParameter("@startMonth", bPlan.StartMonth)
            cmd.AddParameter("@PaymentDays", bPlan.PaymentDays)
            cmd.AddParameter("@Products", IIf(bPlan.ProductCategoryName = "", "Products", bPlan.ProductCategoryName))
            cmd.AddParameter("@SalesAndDistribution", IIf(bPlan.SDCategoryName = "", "SalesAndDistribution", bPlan.SDCategoryName))
            cmd.AddParameter("@GenralAndAdministration", IIf(bPlan.GACategoryName = "", "GeneralAndAdministration", bPlan.GACategoryName))
            cmd.AddParameter("@Others", IIf(bPlan.OtherCategoryName = "", "Others", bPlan.OtherCategoryName))
            cmd.AddParameter("@businessDescription", bPlan.BusinessDescription)
            cmd.AddParameter("@PersonnelBurden", bPlan.PersonnelBurden)
            cmd.AddParameter("@StandardLongTerm", bPlan.StandardOrLongTerm)
            cmd.AddParameter("@SalesForecastType", bPlan.SalesForecastType)
            cmd.AddParameter("@Currency", bPlan.Currency)

            cmd.AddParameter("@PlanDate", Date.Now)
            flag = CBool(cmd.Execute(ExecutionType.ExecuteNonQuery))
            cmd.ClearParameters()
            cmd.Commit()
        Catch ex As Exception
            flag = False
            cmd.RollBack()
        End Try
        Return flag

    End Function

    ' ' New Code    ' Win-saira  Date :27/02/2006


    Public Shared Function SaveExportedPlan(ByRef connData As ConnectionData, ByRef bPlan As InfiniLogic.BusinessPlan.BLL.BusinessPlan, ByVal options As ExportPlanOptions, ByRef planRTF As String) As Boolean
        Dim flag As Boolean = False
        Dim cmd As New CommandData(connData.CustomerID)
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_SaveExportedPlan"
            cmd.AddParameter("@PlanID", bPlan.PlanID)
            cmd.AddParameter("@exportedPlan", planRTF)
            cmd.AddParameter("@fileName", options.FileName)
            cmd.AddParameter("@mimeType", options.MimeType)
            cmd.AddParameter("@fileExtension", options.FileExtension)
            cmd.AddParameter("@exportDate", Now)
            cmd.AddParameter("@includeTables", options.IncludeTables)
            cmd.AddParameter("@includeCharts", options.IncludeCharts)
            flag = CBool(cmd.Execute(ExecutionType.ExecuteNonQuery))
            cmd.ClearParameters()
            cmd.Commit()
        Catch ex As Exception
            flag = False
            cmd.RollBack()
        End Try
        Return flag
    End Function

    Public Shared Function GetExportedPlan(ByRef connData As ConnectionData, ByVal businessID As String) As DataSet
        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_GetExportedPlan"
            cmd.AddParameter("@PlanID", businessID)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()
            cmd.Commit()
        Catch ex As Exception
            ds = Nothing
            cmd.RollBack()
        End Try
        Return ds
    End Function


    Public Shared Function GetSelectedSymbols(ByVal connData As ConnectionData, ByVal businessID As Integer) As DataSet
        Dim command As New InfiniCommand("BPL_GetSelectedSymbol")
        command.AddParameter("@PlanID", businessID)
        Return DataAccess.ExecuteDataSet(connData, command)

    End Function
#End Region







End Class
