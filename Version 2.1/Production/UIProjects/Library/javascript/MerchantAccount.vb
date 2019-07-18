#Region "Imports"
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports System.Data.SqlClient
#End Region

Public Class MerchantAccount
#Region "Variable"
    Dim ds As DataSet
    Dim cp As New Cryptography()
    Private _merchantUID As Integer
    Private _mName As String
    Private _mEmail As String
    Private _pBalance As Double
    Private _mBalance As Double
    Private _sqlQuery As String
    Private _bid As Integer
    Private _bDefault As String
    Private _publicID As String
    Dim strLogKey As String
    Dim _cdataset As DataSet
#End Region

#Region "Properties"
    ' **********************************************************************************
    ' Public Properties....
    ' Created by: Suresh Kumar
    ' Last Update: 01/16/2004
    ' Version 1.0
    ' Purpose: Set or Get Data 
    '************************************************************************************
    Public Property MerchantUID() As Integer
        Get
            Return _merchantUID
        End Get
        Set(ByVal Value As Integer)
            _merchantUID = Value
        End Set
    End Property
    Public Property MerchantName() As String
        Get
            Return _mName
        End Get
        Set(ByVal Value As String)
            _mName = Value
        End Set
    End Property
    Public Property MerchantEmail() As String
        Get
            Return _mEmail
        End Get
        Set(ByVal Value As String)
            _mEmail = Value
        End Set
    End Property
    Public Property MerchantBalance() As String
        Get
            Return _mBalance
        End Get
        Set(ByVal Value As String)
            _mBalance = Value
        End Set
    End Property
    Public Property MerchantPendingBalance()
        Get
            Return _pBalance
        End Get
        Set(ByVal Value)
            _pBalance = Value
        End Set
    End Property
    Public Property BankID() As Integer
        Get
            Return _bid
        End Get
        Set(ByVal Value As Integer)
            _bid = Value
        End Set
    End Property
    Public Property BankDefault() As String
        Get
            Return _bDefault
        End Get
        Set(ByVal Value As String)
            _bDefault = Value
        End Set
    End Property
    Public Property PublicID() As String
        Get
            Return _publicID
        End Get
        Set(ByVal Value As String)
            _publicID = Value
        End Set
    End Property
#End Region

#Region "Function/Sub Routines"
    Public Sub GetMerchantInformation()
        'bankAC.GetLogKey(MerchantUID)
        ds = New DataSet()
        Dim ds2 As New DataSet
        Dim arParam As SqlParameter
        Dim sqlparam1 As SqlParameter() = New SqlParameter(0) {}
        arParam = New SqlParameter("@merchantUid", SqlDbType.Int, 4)
        arParam.Value = MerchantUID
        ds = DBHandler.ExecuteDataset(MerchantUID, CommandType.StoredProcedure, "CAM_PendingBalance", arParam)
        If Not ds.Tables(0).Rows.Count = 0 Then
            MerchantUID = ds.Tables(0).Rows(0).Item("mautono")
            MerchantName = ds.Tables(0).Rows(0).Item("Name")
            MerchantEmail = ds.Tables(0).Rows(0).Item("cart_customer_email")
            PublicID = ds.Tables(0).Rows(0).Item("publicid")
        Else
            MerchantUID = 0
            MerchantName = ""
            MerchantEmail = ""
            MerchantBalance = 0.0
        End If
        'SqlHelper.ConnectionString = Connection.GetConnectionString(MerchantUID)
        sqlparam1(0) = New SqlParameter("@merchantUid", SqlDbType.NVarChar, 50)
        sqlparam1(0).Value = MerchantUID
        ds2 = DBHandler.ExecuteDataset(MerchantUID, CommandType.StoredProcedure, "CAM_PendingBalance2", sqlparam1)
        If Not ds2.Tables(0).Rows.Count = 0 Then
            If Not IsDBNull(ds2.Tables(0).Rows(0).Item("MBal")) Then MerchantBalance = CDbl(ds2.Tables(0).Rows(0).Item("MBal"))
        End If
        If Not ds2.Tables(1).Rows.Count = 0 Then
            If Not IsDBNull(ds2.Tables(1).Rows(0).Item("PBAL")) Then MerchantPendingBalance = CDbl(ds2.Tables(1).Rows(0).Item("PBAL"))
        Else
            MerchantPendingBalance = 0
        End If
        If Not ds2.Tables(2).Rows.Count = 0 Then
            If Not IsDBNull(ds2.Tables(2).Rows(0).Item("BAuto")) Then BankID = ds2.Tables(2).Rows(0).Item("BAuto")
        Else
            BankID = 0
        End If
        If Not ds2.Tables(3).Rows.Count = 0 Then
            If Not IsDBNull(ds2.Tables(3).Rows(0).Item("bnkDefault")) Then BankDefault = ds2.Tables(3).Rows(0).Item("bnkDefault")
        Else
            BankDefault = "N"
        End If
        ds = Nothing
    End Sub
    Public Function GetMerchantLogkey(ByVal mid As Integer) As DataSet
        _cdataset = New DataSet
        Dim sqlParam As SqlParameter() = New SqlParameter(0) {}
        sqlParam(0) = New SqlParameter("@mid", SqlDbType.NVarChar, 50)
        sqlParam(0).Value = mid
        _cdataset = DBHandler.ExecuteDataset(mid, CommandType.StoredProcedure, "CAM_GetMerchantLogKey", sqlParam)
        Return _cdataset
    End Function

    Public Shared Function GetMerchantBalanceActivity(ByVal MerchantID As Integer) As DataSet
        Dim sqlParam() As SqlParameter = New SqlParameter(0) {}
        sqlParam(0) = New SqlParameter("@mid", MerchantID)
        GetMerchantBalanceActivity = DBHandler.ExecuteDataset(MerchantID, CommandType.StoredProcedure, "CAM_GetProcessedInvoicesDetails", sqlParam)
    End Function

#End Region
End Class


