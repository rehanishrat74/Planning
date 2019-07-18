#Region "Imports"
Imports System.data
Imports system.Math
Imports System.Data.SqlClient
Imports Infinilogic.DAL
Imports System.Web.UI.WebControls
Imports System.IO



Imports Infinilogic.BusinessPlan.BLLRules


Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common

Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml


#End Region

Public Class BalancesheetReport

    Private CustId As Integer
    Private Shared _firstDate As Date
    Private Shared _lastDate As Date
    Shared _newAmt As DataSet
    Shared _newYtd As DataSet
    Shared _PLSnewAmt As DataSet
    Shared _PLSnewYtd As DataSet
    Public Property CustomerID() As Integer
        Get
            Return CustId
        End Get
        Set(ByVal Value As Integer)
            CustId = Value
        End Set
    End Property

    Public Shared Function BSLastRecord(ByVal CustomerID As Integer) As String

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As CommandData
        Dim _strFA_NC_DET As String, _strCA_NC_DET As String, _strCL_NC_DET As String, _strCR_NC_DET As String, _strContString As String

        'Fixed Assets
        _objCmd = New CommandData(CustomerID)
        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_BSLASTRECORD"
          
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_FIXASSET_NC" & ex.Message)
            End Try
        End With
        _strFA_NC_DET = CStr(_ds.Tables(0).Rows(0).Item(0))

        _strCA_NC_DET = CStr(_ds.Tables(1).Rows(0).Item(0))

        _strCL_NC_DET = CStr(_ds.Tables(2).Rows(0).Item(0))

        _strCR_NC_DET = CStr(_ds.Tables(3).Rows(0).Item(0))


        _strContString = _strFA_NC_DET & "," & _strCA_NC_DET & "," & _strCL_NC_DET & "," & _strCR_NC_DET

        Return _strContString
    End Function

    Public Shared Function GetLedgerIDForBS(ByVal customerID As Integer) As DataSet

        Dim _objCmd As New CommandData(customerID)
        Dim _ds As DataSet

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETLEDGERIDFORBS"

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORBS" & ex.Message)
            End Try

            Return _ds
        End With

    End Function

   
    Public Shared Function GetBalanceSheetCurrentAmt(ByVal daAllLedgersAMT As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double

        For Each _dr In daAllLedgersAMT
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)

        Next
        _totalAmt = _debit - _credit
        Return _totalAmt


    End Function

    Public Shared Function GetBalanceSheetCurrentYTD(ByVal daAllLedgersYTD As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double



        For Each _dr In daAllLedgersYTD
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next
       

        _totalAmt = _debit - _credit
        Return _totalAmt


    End Function

    Public Shared Function GetLedgerIDForPANDF(ByVal customerID As Integer) As DataSet

        Dim _objCmd As New CommandData(customerID)
        Dim _ds As DataSet

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETLEDGERIDFORPANDL"

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORPANDL" & ex.Message)
            End Try

            Return _ds
        End With

    End Function

    'Public Shared Function GetBalanceSheetCurrentAmt(ByVal CustomerID As Integer, ByVal _lowLID As String, ByVal _highLID As String, ByVal _dateFrom As Date, ByVal _dateTo As Date) As Double

    '    Dim _ds As DataSet, _dr As DataRow
    '    Dim _debit As Double, _credit As Double, _totalAmt As Double
    '    Dim _objCmd As New CommandData(CustomerID)

    '    With _objCmd
    '        .CmdType = CommandType.StoredProcedure
    '        .CmdText = "ACCOUNTSPRO_GETBALANCESHEETAMT"
    '        .AddParameter("@lowLID", _lowLID)
    '        .AddParameter("@highLID", _highLID)
    '        .AddParameter("@dateFrom", _dateFrom)
    '        .AddParameter("@dateTo", _dateTo)

    '        Try
    '            _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
    '        Catch ex As Exception
    '            Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
    '        End Try

    '        For Each _dr In _ds.Tables(0).Rows
    '            _debit += CType(_dr.Item("SumOfdebit"), Double)
    '            _credit += CType(_dr.Item("SumOfcredit"), Double)
    '        Next
    '        _ds.Dispose()
    '        _ds = Nothing

    '        _totalAmt = _debit - _credit
    '        Return _totalAmt

    '    End With
    'End Function
    Public Shared Function GetModifiedBalanceSheetCurrentAmt(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try

            'For Each _dr In _ds.Tables(0).Rows
            '    _debit += CType(_dr.Item("SumOfdebit"), Double)
            '    _credit += CType(_dr.Item("SumOfcredit"), Double)
            'Next
            '_ds.Dispose()
            '_ds = Nothing

            '_totalAmt = _debit - _credit
            Return _ds

        End With
    End Function
    Public Shared Function GetModifiedBalanceSheetYTDAmt(ByVal CustomerID As Integer, ByVal _mydate As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETYTDAMT"

            .AddParameter("@mydate", _mydate)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETYTDAMT" & ex.Message)
            End Try

            Return _ds

        End With
    End Function
    'Public Shared Function GetBalanceSheetYTDAmt(ByVal CustomerID As Integer, ByVal _lowLID As String, ByVal _highLID As String, ByVal _mydate As Date) As Double

    '    Dim _ds As DataSet, _dr As DataRow
    '    Dim _debit As Double, _credit As Double, _totalAmt As Double
    '    Dim _objCmd As New CommandData(CustomerID)

    '    With _objCmd
    '        .CmdType = CommandType.StoredProcedure
    '        .CmdText = "ACCOUNTSPRO_GETBALANCESHEETYTDAMT"
    '        .AddParameter("@lowLID", _lowLID)
    '        .AddParameter("@highLID", _highLID)
    '        .AddParameter("@mydate", _mydate)

    '        Try
    '            _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
    '        Catch ex As Exception
    '            Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETYTDAMT" & ex.Message)
    '        End Try

    '        For Each _dr In _ds.Tables(0).Rows
    '            _debit += CType(_dr.Item("SumOfdebit"), Double)
    '            _credit += CType(_dr.Item("SumOfcredit"), Double)
    '        Next
    '        _ds.Dispose()
    '        _ds = Nothing

    '        _totalAmt = _debit - _credit
    '        Return _totalAmt

    '    End With
    'End Function


    'Public Shared Function BalanceSheet1(ByVal CustomerID As Integer, ByVal datefrom As Date, ByVal dateto As Date) As DataView

    '    Dim _ds As DataSet, _dr As DataRow, _ds1 As DataSet, _dr1 As DataRow
    '    Dim _strChk As String, _strLastRecord As String, _strArry() As String, _lowLID As String, _highLID As String, _togle As String
    '    Dim _strSA As String, _strFA As String, _strCA As String, _strCL As String, _strCR As String, _mHead As String, _mHDesc As String
    '    Dim _currentAmt As Double, _yTDAmt As Double, _bolChkFA As Boolean, _bolChkCA As Boolean, _bolChkCL As Boolean, _bolChkCR As Boolean
    '    Dim _myFEDate As Date
    '    Dim _dblGrPFA As Double, _dblGrpCA As Double, _dblGrpCL As Double, _dblGrpCR As Double, _dblCATogleCurrentAmt As Double, _dblCATogleYTDAmt As Double
    '    Dim _dblGrPYTDFA As Double, _dblGrpYTDCA As Double, _dblGrpYTDCL As Double, _dblGrpYTDCR As Double, _dblCLTogleCurrentAmt As Double, _dblCLTogleYTDAmt As Double

    '    'Creating DataTable
    '    Dim _tbl As New DataTable
    '    Dim _tblRow As DataRow
    '    Dim _category As New DataColumn("Category", GetType(String))
    '    Dim _description As New DataColumn("Description", GetType(String))
    '    Dim _current As New DataColumn("Current", GetType(Double))
    '    Dim dr As DataRow
    '    Dim daAllLedgers As Array

    '    'Add The Column to the Datatable's Columns Collection
    '    _tbl.Columns.Add(_category)
    '    _tbl.Columns.Add(_description)
    '    _tbl.Columns.Add(_current)


    '    'Get last record from pro_nc_det with respactive sales,purchase,overhead,direct expance
    '    _strLastRecord = BSLastRecord(CustomerID)

    '    _strArry = _strLastRecord.Split(","c)

    '    _strFA = _strArry(0)
    '    _strCA = _strArry(1)
    '    _strCL = _strArry(2)
    '    _strCR = _strArry(3)

    '    'Get LedgerID's against Sales, Purchases, Over Head, Expenses
    '    _ds = GetLedgerIDForBS(CustomerID)
    '    _new = GetModifiedBalanceSheetCurrentAmt(CustomerID, datefrom, dateto)
    '    For Each _dr In _ds.Tables(0).Rows
    '        _mHDesc = CType(_dr.Item("Description"), String)
    '        _mHead = CType(_dr.Item("category"), String)
    '        _lowLID = CType(_dr.Item("Low"), String)
    '        _highLID = CType(_dr.Item("High"), String)
    '        _togle = CType(_dr.Item("togle"), String)
    '        'Get CurrentYear Amt For Balance Sheet

    '        daAllLedgers = _new.Tables(0).Select("transid > '" & _lowLID & "'" & " and transid < '" & _highLID & "'")
    '        If (daAllLedgers.Length > 0) Then
    '            _currentAmt = GetBalanceSheetCurrentAmt(daAllLedgers)
    '        Else
    '            _currentAmt = 0
    '        End If
    '        ' 'Get CurrentYear Amt
    '        '   _currentAmt = GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)


    '        If _currentAmt <> 0 Then

    '            If _mHead = "Fixed Assets" Then

    '                If _bolChkFA = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkFA = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                _tblRow("current") = _currentAmt
    '                _dblGrPFA += CType(_tblRow("Current"), Double)


    '                _tbl.Rows.Add(_tblRow)
    '            End If

    '            If _mHead = "Current Assets" Then

    '                If _bolChkCA = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCA = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _togle = "Y" Then
    '                    '  _dblCATogleCurrentAmt = 0 'GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '                    daAllLedgers = _new.Tables(0).Select("transid > '" & _lowLID & "'" & " and transid < '" & _highLID & "'")
    '                    If (daAllLedgers.Length > 0) Then
    '                        _dblCATogleCurrentAmt = GetBalanceSheetCurrentAmt(daAllLedgers)
    '                    End If

    '                Else
    '                    _dblGrpCA += _currentAmt
    '                End If

    '                If _dblCATogleCurrentAmt > 0 And _togle = "Y" Then
    '                    _dblGrpCA += _dblCATogleCurrentAmt
    '                End If

    '                If _togle = "Y" Then
    '                Else
    '                    _dblGrpYTDCA += _yTDAmt
    '                End If



    '                If _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 Then 'And _dblCATogleYTDAmt > 0 Then

    '                    _tblRow("current") = 0.0
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 Then 'And _dblCATogleYTDAmt < 0 Then

    '                    _tblRow("current") = _dblCATogleCurrentAmt
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 Then 'And _dblCATogleYTDAmt > 0 Then
    '                    _tblRow("current") = 0.0
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "N" Then
    '                    _tblRow("current") = _currentAmt
    '                    _tbl.Rows.Add(_tblRow)

    '                End If

    '            End If

    '            If _mHead = "Current Liabilities" Then

    '                If _bolChkCL = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCL = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _togle = "Y" Then
    '                    '  _dblCLTogleCurrentAmt = 0 'GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '                    daAllLedgers = _new.Tables(0).Select("transid > '" & _lowLID & "'" & " and transid < '" & _highLID & "'")
    '                    If (daAllLedgers.Length > 0) Then
    '                        _dblCLTogleCurrentAmt = GetBalanceSheetCurrentAmt(daAllLedgers)
    '                    End If

    '                Else
    '                    If _currentAmt < 0 Then
    '                        _dblGrpCL += Abs(_currentAmt)
    '                    Else
    '                        _dblGrpCL += -_currentAmt
    '                    End If
    '                End If

    '                If _dblCLTogleCurrentAmt < 0 And _togle = "Y" Then
    '                    _dblGrpCL += Abs(_dblCLTogleCurrentAmt)
    '                End If



    '                If _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 Then 'And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = _dblCLTogleCurrentAmt
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt > 0 Then 'And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = CStr(0.0)
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt = 0 Then 'And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = CStr(0.0)
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "N" Then

    '                    If _currentAmt < 0 Then
    '                        _tblRow("current") = Abs(_currentAmt)
    '                    Else
    '                        _tblRow("current") = -_currentAmt
    '                    End If

    '                    _tbl.Rows.Add(_tblRow)
    '                End If
    '            End If

    '            If _mHead = "Capital & Reserves" Then

    '                If _bolChkCR = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCR = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _currentAmt < 0 Then
    '                    _tblRow("Current") = Abs(_currentAmt)
    '                Else
    '                    _tblRow("Current") = -_currentAmt
    '                End If
    '                _dblGrpCR += CType(_tblRow("Current"), Double)

    '                _tbl.Rows.Add(_tblRow)
    '            End If

    '        End If

    '        If _mHead = "Fixed Assets" And _strFA = _mHDesc And _bolChkFA = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Fixed Assets"
    '            _tblRow("Current") = _dblGrPFA
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Current Assets" And _strCA = _mHDesc And _bolChkCA = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Current Assets"
    '            _tblRow("Current") = _dblGrpCA
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Current Liabilities" And _strCL = _mHDesc And _bolChkCL = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Current Liabilities"
    '            _tblRow("Current") = _dblGrpCL
    '            _tbl.Rows.Add(_tblRow)
    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "[Current Assets] - [Liabilities] :"
    '            _tblRow("Current") = _dblGrpCA - _dblGrpCL

    '            _tbl.Rows.Add(_tblRow)

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Net Assets :"
    '            _tblRow("Current") = (_dblGrPFA + _dblGrpCA) - _dblGrpCL

    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Capital & Reserves" And _strCR = _mHDesc And _bolChkCR = True Then
    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Capital & Reserves"
    '            _tblRow("Current") = _dblGrpCR
    '            _tbl.Rows.Add(_tblRow)
    '        End If
    '    Next

    '    _ds.Dispose()
    '    _ds = Nothing

    '    Dim _dblSales As Double, _dblYTDSales As Double, _dblPurchase As Double, _dblYTDPurchase As Double
    '    Dim _dblExpense As Double, _dblYTDExpense As Double, _dblOverhead As Double, _dblYTDOverhead As Double
    '    Dim _dblBalanceSalesGross As Double, _dblBalanceYTDSalesGross As Double, _dblNet As Double, _dblYTDNet As Double

    '    If _mHead = "Capital & Reserves" And _bolChkCR = False And _bolChkCA = False And _bolChkCL = False And _bolChkFA = False Then
    '        Exit Function
    '    Else
    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = "Capital & Reserves"
    '        _tblRow("Description") = ""
    '        _tbl.Rows.Add(_tblRow)
    '    End If

    '    'Get LedgerID's against Sales, Purchases, Over Head, Expenses
    '    _ds = GetLedgerIDForPANDF(CustomerID)

    '    For Each _dr In _ds.Tables(0).Rows
    '        _mHDesc = CType(_dr.Item("Description"), String)
    '        _mHead = CType(_dr.Item("category"), String)
    '        _lowLID = CType(_dr.Item("Low"), String)
    '        _highLID = CType(_dr.Item("High"), String)

    '        If _mHead = "Sales" Then
    '            '   'Get CurrentYear Amt
    '            _currentAmt = 0 ' GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '            '
    '            If _currentAmt < 0 Then
    '                _dblSales += Abs(_currentAmt)
    '            Else
    '                _dblSales += -_currentAmt
    '            End If

    '        End If

    '        If _mHead = "Purchases" Then
    '            _currentAmt = 0 'GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '            _dblPurchase = _currentAmt
    '        End If

    '        If _mHead = "Direct Expenses" Then
    '            _currentAmt = 0 'GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '            _dblExpense = _currentAmt
    '        End If

    '        If _mHead = "Overheads" Then
    '            _currentAmt = 0 'GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '            _dblOverhead += _currentAmt
    '        End If

    '    Next

    '    'Calculating Sales, Purchase & Expense
    '    _dblBalanceSalesGross = _dblSales - _dblPurchase - _dblExpense
    '    _dblNet = _dblBalanceSalesGross - _dblOverhead

    '    If _dblNet <> 0 Or _dblGrpCR <> 0 Then
    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = ""
    '        _tblRow("Description") = "P & L Account"
    '        _tblRow("Current") = _dblNet

    '        _tbl.Rows.Add(_tblRow)

    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = ""
    '        _tblRow("Description") = "Net Capital :"
    '        _tblRow("Current") = _dblGrpCR + _dblNet

    '        _tbl.Rows.Add(_tblRow)
    '    End If

    '    Dim Dv As DataView = New DataView(_tbl)
    '    Return Dv

    'End Function

    Public Shared Function BalanceSheet(ByVal CustomerID As Integer, ByVal datefrom As Date, ByVal dateto As Date) As DataView

        Dim _ds As DataSet, _dr As DataRow, _ds1 As DataSet, _dr1 As DataRow
        Dim _strChk As String, _strLastRecord As String, _strArry() As String, _lowLID As String, _highLID As String, _togle As String
        Dim _strSA As String, _strFA As String, _strCA As String, _strCL As String, _strCR As String, _mHead As String, _mHDesc As String
        Dim _currentAmt As Double, _yTDAmt As Double, _bolChkFA As Boolean, _bolChkCA As Boolean, _bolChkCL As Boolean, _bolChkCR As Boolean
        Dim _myFEDate As Date
        Dim _dblGrPFA As Double, _dblGrpCA As Double, _dblGrpCL As Double, _dblGrpCR As Double, _dblCATogleCurrentAmt As Double, _dblCATogleYTDAmt As Double
        Dim _dblGrPYTDFA As Double, _dblGrpYTDCA As Double, _dblGrpYTDCL As Double, _dblGrpYTDCR As Double, _dblCLTogleCurrentAmt As Double, _dblCLTogleYTDAmt As Double
        Dim daAllLedgersAMT As Array
        Dim daAllLedgersYTD As Array
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
        _strLastRecord = BSLastRecord(CustomerID)

        _strArry = _strLastRecord.Split(","c)

        _strFA = _strArry(0)
        _strCA = _strArry(1)
        _strCL = _strArry(2)
        _strCR = _strArry(3)

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        _ds = GetLedgerIDForBS(CustomerID)
        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
        _newAmt = GetModifiedBalanceSheetCurrentAmt(CustomerID, datefrom, dateto)
        _newYtd = GetModifiedBalanceSheetYTDAmt(CustomerID, _myFEDate)
        For Each _dr In _ds.Tables(0).Rows
            _mHDesc = CType(_dr.Item("Description"), String)
            _mHead = CType(_dr.Item("category"), String)
            _lowLID = CType(_dr.Item("Low"), String)
            _highLID = CType(_dr.Item("High"), String)
            _togle = CType(_dr.Item("togle"), String)
            'Get CurrentYear Amt For Balance Sheet
            ' _currentAmt = 0 ' GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

            daAllLedgersAMT = _newAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
            If (daAllLedgersAMT.Length > 0) Then
                _currentAmt = GetBalanceSheetCurrentAmt(daAllLedgersAMT)
            Else
                _currentAmt = 0
            End If

            'Get YTD Amt
            daAllLedgersYTD = _newYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
            If (daAllLedgersYTD.Length > 0) Then
                _yTDAmt = GetBalanceSheetCurrentYTD(daAllLedgersYTD)
            Else
                _yTDAmt = 0
            End If


            If _currentAmt <> 0 Or _yTDAmt <> 0 Then

                If _mHead = "Fixed Assets" Then

                    If _bolChkFA = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkFA = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    _tblRow("current") = _currentAmt
                    _dblGrPFA += CType(_tblRow("Current"), Double)

                    _tblRow("YTD") = _yTDAmt
                    _dblGrPYTDFA += CType(_tblRow("YTD"), Double)
                    _tbl.Rows.Add(_tblRow)
                End If

                If _mHead = "Current Assets" Then

                    If _bolChkCA = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkCA = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _togle = "Y" Then
                        ' _dblCATogleCurrentAmt = 0 ' GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                        daAllLedgersAMT = _newAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersAMT.Length > 0) Then
                            _dblCATogleCurrentAmt = GetBalanceSheetCurrentAmt(daAllLedgersAMT)
                        Else
                            _dblCATogleCurrentAmt = 0
                        End If

                    Else
                        _dblGrpCA += _currentAmt
                    End If

                    If _dblCATogleCurrentAmt > 0 And _togle = "Y" Then
                        _dblGrpCA += _dblCATogleCurrentAmt
                    End If

                    If _togle = "Y" Then
                        '    _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
                        ' _dblCATogleYTDAmt = GetModifiedBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)
                        daAllLedgersYTD = _newYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersYTD.Length > 0) Then
                            _dblCATogleYTDAmt = GetBalanceSheetCurrentYTD(daAllLedgersYTD)
                        Else
                            _dblCATogleYTDAmt = 0
                        End If

                    Else
                        _dblGrpYTDCA += _yTDAmt
                    End If

                    If _dblCATogleYTDAmt > 0 And _togle = "Y" Then
                        _dblGrpYTDCA += _dblCATogleYTDAmt
                    End If

                    If _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then

                        _tblRow("current") = 0.0
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = 0.0
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) = 0 Then

                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = 0.0
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then

                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then

                        _tblRow("current") = 0.0
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                    ElseIf _mHead = "Current Assets" And _togle = "N" Then
                        _tblRow("current") = _currentAmt
                        _tblRow("YTD") = _yTDAmt
                        _tbl.Rows.Add(_tblRow)

                    End If

                End If

                If _mHead = "Current Liabilities" Then

                    If _bolChkCL = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkCL = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _togle = "Y" Then
                        '   _dblCLTogleCurrentAmt = GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                        daAllLedgersAMT = _newAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersAMT.Length > 0) Then
                            _dblCLTogleCurrentAmt = GetBalanceSheetCurrentAmt(daAllLedgersAMT)
                        Else
                            _dblCLTogleCurrentAmt = 0
                        End If

                    Else
                        If _currentAmt < 0 Then
                            _dblGrpCL += Abs(_currentAmt)
                        Else
                            _dblGrpCL += -_currentAmt
                        End If
                    End If

                    If _dblCLTogleCurrentAmt < 0 And _togle = "Y" Then
                        _dblGrpCL += Abs(_dblCLTogleCurrentAmt)
                    End If

                    If _togle = "Y" Then
                        '_myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
                        ' _dblCLTogleYTDAmt = GetModifiedBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)
                        daAllLedgersYTD = _newYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersYTD.Length > 0) Then
                            _dblCLTogleYTDAmt = GetBalanceSheetCurrentYTD(daAllLedgersYTD)
                        Else
                            _dblCLTogleYTDAmt = 0
                        End If

                    Else
                        If _yTDAmt < 0 Then
                            _dblGrpYTDCL += Abs(_yTDAmt)
                        Else
                            _dblGrpYTDCL += -_yTDAmt
                        End If
                    End If

                    If _dblCLTogleYTDAmt < 0 And _togle = "Y" Then
                        _dblGrpYTDCL += Abs(_dblCLTogleYTDAmt)
                    End If

                    If _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt < 0 Then

                        _tblRow("current") = _dblCLTogleCurrentAmt
                        _tblRow("YTD") = _dblCLTogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt > 0 Then

                        _tblRow("current") = Abs(_dblCLTogleCurrentAmt)
                        _tblRow("YTD") = CStr(0.0)
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt = 0 Then

                        _tblRow("current") = CStr(Abs(_dblCLTogleCurrentAmt))
                        _tblRow("YTD") = CStr(0.0)
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt > 0 And _dblCLTogleYTDAmt < 0 Then

                        _tblRow("current") = CStr(0.0)
                        _tblRow("YTD") = CStr(Abs(_dblCLTogleYTDAmt))
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt = 0 And _dblCLTogleYTDAmt < 0 Then

                        _tblRow("current") = CStr(0.0)
                        _tblRow("YTD") = CStr(Abs(_dblCLTogleYTDAmt))
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt = 0 And _dblCLTogleYTDAmt > 0 Then
                        'Nothing is required

                    ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt > 0 And _dblCLTogleYTDAmt > 0 Then

                    ElseIf _mHead = "Current Liabilities" And _togle = "N" Then

                        If _currentAmt < 0 Then
                            _tblRow("current") = Abs(_currentAmt)
                        Else
                            _tblRow("current") = -_currentAmt
                        End If

                        If _yTDAmt < 0 Then
                            _tblRow("YTD") = Abs(_yTDAmt)
                        Else
                            _tblRow("YTD") = -_yTDAmt
                        End If
                        _tbl.Rows.Add(_tblRow)
                    End If
                End If

                If _mHead = "Capital & Reserves" Then

                    If _bolChkCR = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkCR = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _currentAmt < 0 Then
                        _tblRow("Current") = Abs(_currentAmt)
                    Else
                        _tblRow("Current") = -_currentAmt
                    End If
                    _dblGrpCR += CType(_tblRow("Current"), Double)

                    If _yTDAmt < 0 Then
                        _tblRow("YTD") = Abs(_yTDAmt)
                    Else
                        _tblRow("YTD") = -_yTDAmt
                    End If
                    _dblGrpYTDCR += CType(_tblRow("YTD"), Double)

                    _tbl.Rows.Add(_tblRow)
                End If

            End If

            If _mHead = "Fixed Assets" And _strFA = _mHDesc And _bolChkFA = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Fixed Assets"
                _tblRow("Current") = _dblGrPFA
                _tblRow("YTD") = _dblGrPYTDFA
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Current Assets" And _strCA = _mHDesc And _bolChkCA = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Current Assets"
                _tblRow("Current") = _dblGrpCA
                _tblRow("YTD") = _dblGrpYTDCA
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Current Liabilities" And _strCL = _mHDesc And _bolChkCL = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Current Liabilities"
                _tblRow("Current") = _dblGrpCL
                _tblRow("YTD") = _dblGrpYTDCL
                _tbl.Rows.Add(_tblRow)

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "[Current Assets] - [Liabilities] :"
                _tblRow("Current") = _dblGrpCA - _dblGrpCL
                _tblRow("YTD") = _dblGrpYTDCA - _dblGrpYTDCL
                _tbl.Rows.Add(_tblRow)

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Net Assets :"
                _tblRow("Current") = (_dblGrPFA + _dblGrpCA) - _dblGrpCL
                _tblRow("YTD") = (_dblGrPYTDFA + _dblGrpYTDCA) - _dblGrpYTDCL
                _tbl.Rows.Add(_tblRow)
            End If

            If _mHead = "Capital & Reserves" And _strCR = _mHDesc And _bolChkCR = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Capital & Reserves"
                _tblRow("Current") = _dblGrpCR
                _tblRow("YTD") = _dblGrpYTDCR
                _tbl.Rows.Add(_tblRow)
            End If

        Next

        _ds.Dispose()
        _ds = Nothing

        Dim _dblSales As Double, _dblYTDSales As Double, _dblPurchase As Double, _dblYTDPurchase As Double
        Dim _dblExpense As Double, _dblYTDExpense As Double, _dblOverhead As Double, _dblYTDOverhead As Double
        Dim _dblBalanceSalesGross As Double, _dblBalanceYTDSalesGross As Double, _dblNet As Double, _dblYTDNet As Double
        Dim daPLSLedgersAMT As Array
        Dim daPLSLedgersYTD As Array
        If _mHead = "Capital & Reserves" And _bolChkCR = False And _bolChkCA = False And _bolChkCL = False And _bolChkFA = False Then
            Exit Function
        Else
            _tblRow = _tbl.NewRow()
            _tblRow("Category") = "Capital & Reserves"
            _tblRow("Description") = ""
            _tbl.Rows.Add(_tblRow)
        End If

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        _ds = GetLedgerIDForPANDF(CustomerID)
        _PLSnewAmt = GetModifiedProfitAndLossCurrentAmt(CustomerID, datefrom, dateto)
        _PLSnewYtd = GetModifiedProfitAndLossCurrentYTD(CustomerID, _firstDate, _myFEDate)
        For Each _dr In _ds.Tables(0).Rows
            _mHDesc = CType(_dr.Item("Description"), String)
            _mHead = CType(_dr.Item("category"), String)
            _lowLID = CType(_dr.Item("Low"), String)
            _highLID = CType(_dr.Item("High"), String)

            If _mHead = "Sales" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If
                '_currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                '_yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

                If _currentAmt < 0 Then
                    _dblSales += Abs(_currentAmt)
                Else
                    _dblSales += -_currentAmt
                End If

                If _yTDAmt < 0 Then
                    _dblYTDSales += Abs(_yTDAmt)
                Else
                    _dblYTDSales += -_yTDAmt
                End If
            End If

            If _mHead = "Purchases" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If
                '_currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                '_yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

                _dblPurchase += _currentAmt
                _dblYTDPurchase += _yTDAmt
            End If

            If _mHead = "Direct Expenses" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If
                '_currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                '_yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

                _dblExpense += _currentAmt
                _dblYTDExpense += _yTDAmt
            End If

            If _mHead = "Overheads" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If
                '_currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                '_yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

                _dblOverhead += _currentAmt
                _dblYTDOverhead += _yTDAmt
            End If

        Next

        'Calculating Sales, Purchase & Expense
        _dblBalanceSalesGross = _dblYTDSales - _dblYTDPurchase - _dblYTDExpense
        _dblBalanceYTDSalesGross = _dblYTDSales - _dblYTDPurchase - _dblYTDExpense

        _dblNet = _dblBalanceSalesGross - _dblOverhead
        _dblYTDNet = _dblBalanceYTDSalesGross - _dblYTDOverhead


        If _dblNet <> 0 And _dblYTDNet <> 0 Or _dblGrpCR <> 0 And _dblGrpYTDCR <> 0 Then

            _tblRow = _tbl.NewRow()
            _tblRow("Category") = ""
            _tblRow("Description") = "P & L Account"
            _tblRow("Current") = _dblNet
            _tblRow("YTD") = _dblYTDNet
            _tbl.Rows.Add(_tblRow)

            _tblRow = _tbl.NewRow()
            _tblRow("Category") = ""
            _tblRow("Description") = "Net Capital :"
            _tblRow("Current") = _dblGrpCR + _dblNet
            _tblRow("YTD") = _dblGrpYTDCR + _dblYTDNet
            _tbl.Rows.Add(_tblRow)

        End If

        Dim Dv As DataView = New DataView(_tbl)
        Return Dv

    End Function

    'Public Shared Function BalanceSheet1(ByVal CustomerID As Integer, ByVal datefrom As Date, ByVal dateto As Date) As DataView

    '    Dim _ds As DataSet, _dr As DataRow, _ds1 As DataSet, _dr1 As DataRow
    '    Dim _strChk As String, _strLastRecord As String, _strArry() As String, _lowLID As String, _highLID As String, _togle As String
    '    Dim _strSA As String, _strFA As String, _strCA As String, _strCL As String, _strCR As String, _mHead As String, _mHDesc As String
    '    Dim _currentAmt As Double, _yTDAmt As Double, _bolChkFA As Boolean, _bolChkCA As Boolean, _bolChkCL As Boolean, _bolChkCR As Boolean
    '    Dim _myFEDate As Date
    '    Dim _dblGrPFA As Double, _dblGrpCA As Double, _dblGrpCL As Double, _dblGrpCR As Double, _dblCATogleCurrentAmt As Double, _dblCATogleYTDAmt
    '    Dim _dblGrPYTDFA As Double, _dblGrpYTDCA As Double, _dblGrpYTDCL As Double, _dblGrpYTDCR As Double, _dblCLTogleCurrentAmt As Double, _dblCLTogleYTDAmt As Double

    '    'Creating DataTable
    '    Dim _tbl As New DataTable
    '    Dim _tblRow As DataRow
    '    Dim _category As New DataColumn("Category", GetType(String))
    '    Dim _description As New DataColumn("Description", GetType(String))
    '    Dim _current As New DataColumn("Current", GetType(Double))
    '    Dim _yTD As New DataColumn("YTD", GetType(Double))

    '    'Add The Column to the Datatable's Columns Collection
    '    _tbl.Columns.Add(_category)
    '    _tbl.Columns.Add(_description)
    '    _tbl.Columns.Add(_current)
    '    _tbl.Columns.Add(_yTD)

    '    'Check Financial Year
    '    CheckFinancialYear(CustomerID)

    '    'Get last record from pro_nc_det with respactive sales,purchase,overhead,direct expance
    '    _strLastRecord = BSLastRecord(CustomerID)

    '    _strArry = _strLastRecord.Split(",")

    '    _strFA = _strArry(0)
    '    _strCA = _strArry(1)
    '    _strCL = _strArry(2)
    '    _strCR = _strArry(3)

    '    'Get LedgerID's against Sales, Purchases, Over Head, Expenses
    '    _ds = GetLedgerIDForBS(CustomerID)

    '    For Each _dr In _ds.Tables(0).Rows
    '        _mHDesc = _dr.Item("Description")
    '        _mHead = _dr.Item("category")
    '        _lowLID = _dr.Item("Low")
    '        _highLID = _dr.Item("High")
    '        _togle = _dr.Item("togle")
    '        'Get CurrentYear Amt For Balance Sheet
    '        _currentAmt = GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '        'Get YTD Amt
    '        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '        _yTDAmt = GetBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)

    '        If _currentAmt <> 0 Or _yTDAmt <> 0 Then

    '            If _mHead = "Fixed Assets" Then

    '                If _bolChkFA = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkFA = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                _tblRow("current") = Format(_currentAmt, "#,##0.00")
    '                _dblGrPFA += CType(_tblRow("Current"), Double)

    '                _tblRow("YTD") = Format(_yTDAmt, "#,##0.00")
    '                _dblGrPYTDFA += CType(_tblRow("YTD"), Double)
    '                _tbl.Rows.Add(_tblRow)
    '            End If

    '            If _mHead = "Current Assets" Then

    '                If _bolChkCA = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCA = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _togle = "Y" Then
    '                    _dblCATogleCurrentAmt = GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '                Else
    '                    _dblGrpCA += Format(_currentAmt, "#,##0.00")
    '                End If

    '                If _dblCATogleCurrentAmt > 0 And _togle = "Y" Then
    '                    _dblGrpCA += Format(_dblCATogleCurrentAmt, "#,##0.00")
    '                End If

    '                If _togle = "Y" Then
    '                    _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '                    _dblCATogleYTDAmt = GetBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)
    '                Else
    '                    _dblGrpYTDCA += Format(_yTDAmt, "#,##0.00")
    '                End If

    '                If _dblCATogleYTDAmt > 0 And _togle = "Y" Then
    '                    _dblGrpYTDCA += Format(_dblCATogleYTDAmt, "#,##0.00")
    '                End If

    '                If _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And _dblCATogleYTDAmt < 0 Then

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And _dblCATogleYTDAmt > 0 Then

    '                    _tblRow("current") = Format(0.0, "#,##0.00")
    '                    _tblRow("YTD") = Format(_dblCATogleYTDAmt, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And _dblCATogleYTDAmt < 0 Then

    '                    _tblRow("current") = Format(_dblCATogleCurrentAmt, "#,##0.00")
    '                    _tblRow("YTD") = Format(0.0, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And _dblCATogleYTDAmt = 0 Then

    '                    _tblRow("current") = Format(_dblCATogleCurrentAmt, "#,##0.00")
    '                    _tblRow("YTD") = Format(0.0, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And _dblCATogleYTDAmt > 0 Then

    '                    _tblRow("current") = Format(_dblCATogleCurrentAmt, "#,##0.00")
    '                    _tblRow("YTD") = Format(_dblCATogleYTDAmt, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And _dblCATogleYTDAmt > 0 Then

    '                    _tblRow("current") = Format(0.0, "#,##0.00")
    '                    _tblRow("YTD") = Format(_dblCATogleYTDAmt, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And _dblCATogleYTDAmt < 0 Then

    '                ElseIf _mHead = "Current Assets" And _togle = "N" Then
    '                    _tblRow("current") = Format(_currentAmt, "#,##0.00")
    '                    _tblRow("YTD") = Format(_yTDAmt, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                End If

    '            End If

    '            If _mHead = "Current Liabilities" Then

    '                If _bolChkCL = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCL = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _togle = "Y" Then
    '                    _dblCLTogleCurrentAmt = GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
    '                Else
    '                    If _currentAmt < 0 Then
    '                        _dblGrpCL += Format(Abs(_currentAmt), "#,##0.00")
    '                    Else
    '                        _dblGrpCL += Format(-_currentAmt, "#,##0.00")
    '                    End If
    '                End If

    '                If _dblCLTogleCurrentAmt < 0 And _togle = "Y" Then
    '                    _dblGrpCL += Format(Abs(_dblCLTogleCurrentAmt), "#,##0.00")
    '                End If

    '                If _togle = "Y" Then
    '                    _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '                    _dblCLTogleYTDAmt = GetBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)
    '                Else
    '                    If _yTDAmt < 0 Then
    '                        _dblGrpYTDCL += Format(Abs(_yTDAmt), "#,##0.00")
    '                    Else
    '                        _dblGrpYTDCL += Format(-_yTDAmt, "#,##0.00")
    '                    End If
    '                End If

    '                If _dblCLTogleYTDAmt < 0 And _togle = "Y" Then
    '                    _dblGrpYTDCL += Format(Abs(_dblCLTogleYTDAmt), "#,##0.00")
    '                End If

    '                If _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = Format(_dblCLTogleCurrentAmt, "#,##0.00")
    '                    _tblRow("YTD") = Format(_dblCLTogleYTDAmt, "#,##0.00")
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt > 0 Then

    '                    _tblRow("current") = Format(Abs(_dblCLTogleCurrentAmt), "#,##0.00")
    '                    _tblRow("YTD") = CStr(Format(0.0, "#,##0.00"))
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt < 0 And _dblCLTogleYTDAmt = 0 Then

    '                    _tblRow("current") = CStr(Format(Abs(_dblCLTogleCurrentAmt), "#,##0.00"))
    '                    _tblRow("YTD") = CStr(Format(0.0, "#,##0.00"))
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt > 0 And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = CStr(Format(0.0, "#,##0.00"))
    '                    _tblRow("YTD") = CStr(Format(Abs(_dblCLTogleYTDAmt), "#,##0.00"))
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt = 0 And _dblCLTogleYTDAmt < 0 Then

    '                    _tblRow("current") = CStr(Format(0.0, "#,##0.00"))
    '                    _tblRow("YTD") = CStr(Format(Abs(_dblCLTogleYTDAmt), "#,##0.00"))
    '                    _tbl.Rows.Add(_tblRow)

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt = 0 And _dblCLTogleYTDAmt > 0 Then
    '                    'Nothing is required

    '                ElseIf _mHead = "Current Liabilities" And _togle = "Y" And _dblCLTogleCurrentAmt > 0 And _dblCLTogleYTDAmt > 0 Then

    '                ElseIf _mHead = "Current Liabilities" And _togle = "N" Then

    '                    If _currentAmt < 0 Then
    '                        _tblRow("current") = Format(Abs(_currentAmt), "#,##0.00")
    '                    Else
    '                        _tblRow("current") = Format(-_currentAmt, "#,##0.00")
    '                    End If

    '                    If _yTDAmt < 0 Then
    '                        _tblRow("YTD") = Format(Abs(_yTDAmt), "#,##0.00")
    '                    Else
    '                        _tblRow("YTD") = Format(-_yTDAmt, "#,##0.00")
    '                    End If
    '                    _tbl.Rows.Add(_tblRow)
    '                End If
    '            End If

    '            If _mHead = "Capital & Reserves" Then

    '                If _bolChkCR = False Then
    '                    _tblRow = _tbl.NewRow()
    '                    _tblRow("Category") = _mHead
    '                    _tblRow("Description") = ""
    '                    _tbl.Rows.Add(_tblRow)
    '                    _bolChkCR = True
    '                End If

    '                _tblRow = _tbl.NewRow()
    '                _tblRow("Category") = ""
    '                _tblRow("Description") = _mHDesc

    '                If _currentAmt < 0 Then
    '                    _tblRow("Current") = Format(Abs(_currentAmt), "#,##0.00")
    '                Else
    '                    _tblRow("Current") = Format(-_currentAmt, "#,##0.00")
    '                End If
    '                _dblGrpCR += CType(_tblRow("Current"), Double)

    '                If _yTDAmt < 0 Then
    '                    _tblRow("YTD") = Format(Abs(_yTDAmt), "#,##0.00")
    '                Else
    '                    _tblRow("YTD") = Format(-_yTDAmt, "#,##0.00")
    '                End If
    '                _dblGrpYTDCR += CType(_tblRow("YTD"), Double)

    '                _tbl.Rows.Add(_tblRow)
    '            End If

    '        End If

    '        If _mHead = "Fixed Assets" And _strFA = _mHDesc And _bolChkFA = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Fixed Assets"
    '            _tblRow("Current") = _dblGrPFA
    '            _tblRow("YTD") = _dblGrPYTDFA
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Current Assets" And _strCA = _mHDesc And _bolChkCA = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Current Assets"
    '            _tblRow("Current") = _dblGrpCA
    '            _tblRow("YTD") = _dblGrpYTDCA
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Current Liabilities" And _strCL = _mHDesc And _bolChkCL = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Current Liabilities"
    '            _tblRow("Current") = _dblGrpCL
    '            _tblRow("YTD") = _dblGrpYTDCL
    '            _tbl.Rows.Add(_tblRow)

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "[Current Assets] - [Liabilities] :"
    '            _tblRow("Current") = _dblGrpCA - _dblGrpCL
    '            _tblRow("YTD") = _dblGrpYTDCA - _dblGrpYTDCL
    '            _tbl.Rows.Add(_tblRow)

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Net Assets :"
    '            _tblRow("Current") = (_dblGrPFA + _dblGrpCA) - _dblGrpCL
    '            _tblRow("YTD") = (_dblGrPYTDFA + _dblGrpYTDCA) - _dblGrpYTDCL
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '        If _mHead = "Capital & Reserves" And _strCR = _mHDesc And _bolChkCR = True Then

    '            _tblRow = _tbl.NewRow()
    '            _tblRow("Category") = ""
    '            _tblRow("Description") = "Total Capital & Reserves"
    '            _tblRow("Current") = _dblGrpCR
    '            _tblRow("YTD") = _dblGrpYTDCR
    '            _tbl.Rows.Add(_tblRow)
    '        End If

    '    Next

    '    _ds.Dispose()
    '    _ds = Nothing

    '    Dim _dblSales As Double, _dblYTDSales As Double, _dblPurchase As Double, _dblYTDPurchase As Double
    '    Dim _dblExpense As Double, _dblYTDExpense As Double, _dblOverhead As Double, _dblYTDOverhead As Double
    '    Dim _dblBalanceSalesGross As Double, _dblBalanceYTDSalesGross As Double, _dblNet As Double, _dblYTDNet As Double

    '    If _mHead = "Capital & Reserves" And _bolChkCR = False And _bolChkCA = False And _bolChkCL = False And _bolChkFA = False Then
    '        Exit Function
    '    Else
    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = "Capital & Reserves"
    '        _tblRow("Description") = ""
    '        _tbl.Rows.Add(_tblRow)
    '    End If

    '    'Get LedgerID's against Sales, Purchases, Over Head, Expenses
    '    _ds = GetLedgerIDForPANDF(CustomerID)

    '    For Each _dr In _ds.Tables(0).Rows
    '        _mHDesc = _dr.Item("Description")
    '        _mHead = _dr.Item("category")
    '        _lowLID = _dr.Item("Low")
    '        _highLID = _dr.Item("High")

    '        If _mHead = "Sales" Then
    '            'Get CurrentYear Amt
    '            _currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '            'Get YTD Amt
    '            _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '            _yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

    '            If _currentAmt < 0 Then
    '                _dblSales += Format(Abs(_currentAmt), "#,##0.00")
    '            Else
    '                _dblSales += Format(-_currentAmt, "#,##0.00")
    '            End If

    '            If _yTDAmt < 0 Then
    '                _dblYTDSales += Format(Abs(_yTDAmt), "#,##0.00")
    '            Else
    '                _dblYTDSales += Format(-_yTDAmt, "#,##0.00")
    '            End If
    '        End If

    '        If _mHead = "Purchases" Then
    '            _currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '            'Get YTD Amt
    '            _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '            _yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

    '            _dblPurchase += Format(_currentAmt, "#,##0.00")
    '            _dblYTDPurchase += Format(_yTDAmt, "#,##0.00")
    '        End If

    '        If _mHead = "Direct Expenses" Then
    '            _currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '            'Get YTD Amt
    '            _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '            _yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

    '            _dblExpense += Format(_currentAmt, "#,##0.00")
    '            _dblYTDExpense += Format(_yTDAmt, "#,##0.00")
    '        End If

    '        If _mHead = "Overheads" Then
    '            _currentAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

    '            'Get YTD Amt
    '            _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
    '            _yTDAmt = GetProfitAndLossCurrentAmt(CustomerID, _lowLID, _highLID, _firstDate, _myFEDate)

    '            _dblOverhead += Format(_currentAmt, "#,##0.00")
    '            _dblYTDOverhead += Format(_yTDAmt, "#,##0.00")
    '        End If

    '    Next

    '    'Calculating Sales, Purchase & Expense
    '    _dblBalanceSalesGross = _dblYTDSales - _dblYTDPurchase - _dblYTDExpense
    '    _dblBalanceYTDSalesGross = _dblYTDSales - _dblYTDPurchase - _dblYTDExpense

    '    _dblNet = Format(_dblBalanceSalesGross - _dblOverhead, "#,##0.00")
    '    _dblYTDNet = Format(_dblBalanceYTDSalesGross - _dblYTDOverhead, "#,##0.00")


    '    If _dblNet <> 0 And _dblYTDNet <> 0 Or _dblGrpCR <> 0 And _dblGrpYTDCR <> 0 Then

    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = ""
    '        _tblRow("Description") = "P & L Account"
    '        _tblRow("Current") = _dblNet
    '        _tblRow("YTD") = _dblYTDNet
    '        _tbl.Rows.Add(_tblRow)

    '        _tblRow = _tbl.NewRow()
    '        _tblRow("Category") = ""
    '        _tblRow("Description") = "Net Capital :"
    '        _tblRow("Current") = _dblGrpCR + _dblNet
    '        _tblRow("YTD") = _dblGrpYTDCR + _dblYTDNet
    '        _tbl.Rows.Add(_tblRow)

    '    End If

    '    Dim Dv As DataView = New DataView(_tbl)
    '    Return Dv

    'End Function


    Public Shared Sub CheckFinancialYear(ByVal CustomerID As Integer)

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_FINANCIALYEAR"
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows

            _firstDate = CType(_dr(0), Date)
            _lastDate = CType(_dr(1), Date)
        Next

        _ds.Dispose()
        _ds = Nothing

    End Sub


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
            ''Added by : Sadia Waleem
            '' Dated: 19th Feb 2007
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETPROFITANDLOSSAMT" & ex.Message)
            End Try

            For Each _dr In _ds.Tables(0).Rows
                _debit += CType(_dr.Item("SumOfdebit"), Double)
                _credit += CType(_dr.Item("SumOfcredit"), Double)
            Next
            _ds.Dispose()
            _ds = Nothing

            _totalAmt = _debit - _credit
            Return _totalAmt

        End With
    End Function

    Public Shared Function GetModifiedProfitAndLossCurrentAmt(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETPROFITANDLOSSAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try

           
            Return _ds

        End With
    End Function

    Public Shared Function GetProfitAndLossCurrentValuesAMT(ByVal daAllLedgers As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double


        For Each _dr In daAllLedgers
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next
    

        _totalAmt = _debit - _credit

        Return _totalAmt
    End Function

    Public Shared Function GetModifiedProfitAndLossCurrentYTD(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETPROFITANDLOSSAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try


            Return _ds

        End With
    End Function

    Public Shared Function GetProfitAndLossCurrentValuesYTD(ByVal daAllLedgers As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double


        For Each _dr In daAllLedgers
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next
      

        _totalAmt = _debit - _credit

        Return _totalAmt
    End Function


End Class
