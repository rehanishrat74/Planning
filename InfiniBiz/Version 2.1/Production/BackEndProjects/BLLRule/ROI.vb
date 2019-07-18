Option Strict Off

#Region "Imports"

Imports System.data
Imports system.Math
Imports System.Data.SqlClient

Imports System.Web.UI.WebControls
Imports System.IO


Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL


#End Region

Public Class ROI

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

    'Current date 
    'percentage 

    
    Public Shared Function BSLastRecord(ByVal CustomerID As Integer) As String

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As CommandData
        Dim _strFA_NC_DET As String, _strCA_NC_DET As String, _strCL_NC_DET As String, _strCR_NC_DET As String, _strContString As String

        'Fixed Assets
        _objCmd = New CommandData(CustomerID)
        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_BSLASTRECORD"
            .AddParameter("@MIdentity", CustomerID)

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
                .AddParameter("@MIdentity", customerID)
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
            .AddParameter("@MIdentity", customerID)
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORPANDL" & ex.Message)
            End Try

            Return _ds
        End With

    End Function

    Public Shared Function GetModifiedBalanceSheetCurrentAmt(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETAMT"

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

    Public Shared Function GetModifiedBalanceSheetYTDAmt(ByVal CustomerID As Integer, ByVal _mydate As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETYTDAMT"

            .AddParameter("@mydate", _mydate)
            .AddParameter("@MIdentity", CustomerID)
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETYTDAMT" & ex.Message)
            End Try

            Return _ds

        End With
    End Function

    Public Shared Function BalanceSheet(ByVal connData As ConnectionData, ByVal datefrom As Date, ByVal dateto As Date) As DataView

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
        CheckFinancialYear(connData)

        'Get last record from pro_nc_det with respactive sales,purchase,overhead,direct expance
        _strLastRecord = BSLastRecord(connData.CustomerID)

        _strArry = _strLastRecord.Split(","c)

        _strFA = _strArry(0)
        _strCA = _strArry(1)
        _strCL = _strArry(2)
        _strCR = _strArry(3)

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        _ds = GetLedgerIDForBS(connData.CustomerID)
        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
        _newAmt = GetModifiedBalanceSheetCurrentAmt(connData.CustomerID, datefrom, dateto)
        _newYtd = GetModifiedBalanceSheetYTDAmt(connData.CustomerID, _myFEDate)
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
                        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
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
                        '      _tblRow("current") = _dblCATogleCurrentAmt
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
        _ds = GetLedgerIDForPANDF(connData.CustomerID)
        _PLSnewAmt = GetModifiedProfitAndLossCurrentAmt(connData.CustomerID, datefrom, dateto)
        _PLSnewYtd = GetModifiedProfitAndLossCurrentYTD(connData.CustomerID, _firstDate, _myFEDate)
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
        _dblBalanceSalesGross = _dblSales - _dblPurchase - _dblExpense
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

    Public Shared Sub CheckFinancialYear(ByRef connData As ConnectionData)

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As New CommandData(connData.CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_FINANCIALYEAR"
            Try
                _objCmd.AddParameter("@MIdentity", connData.CustomerID)
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
