
#Region "......................Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.Common
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Text
Imports System.Web
#End Region


Public Class WebTracker


    'Tracker 
    Public Shared Function GetVisitsCount(ByVal Customerid As Integer, ByVal StartDate As String, ByVal DomainName As String) As Integer
        Dim _VisitsCount As Integer

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DomainName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMEROINT_GetVisitCount"
        _VisitsCount = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows.Count

        Return _VisitsCount

    End Function
    Public Shared Function GetProductCount(ByRef Customerid As Integer, ByVal StartDate As String, ByVal DomainName As String) As Integer
        Dim _productCount As Integer

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DomainName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetProductCount"
        _productCount = CInt(CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0).Rows(0).Item(0))

        Return _productCount
    End Function
    Public Shared Function GetOrderCount(ByRef Customerid As Integer, ByVal StartDate As String, ByVal DoaminName As String) As DataTable

        Dim cmd As New CommandData
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@DomainName", DoaminName)
        cmd.CmdText = "DBSERVER.TRACKER.DBO.CUSTOMERPOINT_GetCustomerIDsList"
        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)


    End Function
    Public Shared Function PostOrderCount(ByVal Midentity As Integer, ByVal Customerid As String, ByVal StartDate As String, ByVal DoaminName As String) As Integer

        Dim cmd As New CommandData(Midentity)
        cmd.AddParameter("@StartDate", StartDate)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.AddParameter("@midentity", Midentity)
        cmd.CmdText = "CUSTOMERPOINT_GetOrderCountByCustomerID"
        Return CType(cmd.Execute(ExecutionType.ExecuteScalar), Integer)


    End Function
    Public Shared Function getMerchantInformation(ByRef Customerid As Integer) As DataTable

        Dim planid As String
        Dim Trackerid As String, str_userid As String, str_loginid As String, impid As String
        Dim str_domain As String, str_logininfo As String

        Dim cmd As New CommandData(Customerid)
        cmd.AddParameter("@CustomerId", Customerid)
        cmd.CmdText = "CUSTOMERPOINT_GetDomainNameByCustomerID"

        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)

    End Function
    Public Shared Function GetMenuForTracker(ByVal CustomerpointID As String) As DataSet

        Dim cmd As New CommandData
        cmd.AddParameter("@CustomerpointID", CustomerpointID)
        cmd.CmdText = "DBSERVER.INFINISHOPMAINDB.DBO.CUSTOMEROINT_GetNodebyCustomerPointID"
        Return CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

    End Function


    Public Shared Function GetCurrentSessions(ByVal connData As ConnectionData, ByVal _DomainName As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetCurrentSessions")
            _InfiniCommand.AddParameter("@DomainName", _DomainName, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetUserDetail(ByVal connData As ConnectionData, ByVal SessionID As Integer) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserDetail")
            _InfiniCommand.AddParameter("@sid", SessionID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetUserLog(ByVal connData As ConnectionData, ByVal SessionID As Integer) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserLog")
            _InfiniCommand.AddParameter("@sid", SessionID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetUserLog_Histroy(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserLog_History")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetUserLog_HistoryActivity(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserLog_ActivityHistory")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Shared Function BPL_WEBTRACKER_GetUserLog_ActivityHistory_CountryDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal StrCountry As String) As DataSet
        Web.HttpContext.Current.Trace.Warn(" BPL_WEBTRACKER_GetUserLog_ActivityHistory_CountryDetail Start ")

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserLog_ActivityHistory_CountryDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", StrCountry, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(StrCountry)

            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If

            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn(" BPL_WEBTRACKER_GetUserLog_ActivityHistory_CountryDetail Start :" & ex.Message)

            Throw ex
        End Try

    End Function
    Public Shared Function GetUserLog_HistoryActivity_Country(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn(" GetUserLog_HistoryActivity_Country Start ")

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetUserLog_ActivityHistory_Country")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)

            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)

            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn(" GetUserLog_HistoryActivity_Country Start " & ex.Message)

            Throw ex
        End Try

    End Function


    Public Shared Function GetCustomerHistoryDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal _CustomerIDs As String) As DataSet
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetCustomerHistoryDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn(" GetTotalHistory Start ")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalSessionsInfo")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn(" GetTotalHistory Start " & ex.Message)

            Throw ex
        End Try

    End Function


    'Referrer base sorting 
    Public Shared Function GetTotalHistory_CountryReferrer(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_Country starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetReferrer")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_Country starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory_UniqueReferrer(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal ReferrerUrl As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_UniqueReferrer starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_UniQueReferrer")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerName", ReferrerUrl, System.Data.DbType.String)

            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(ReferrerUrl)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_UniqueReferrer starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory_UniqueReferrerCountry(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal ReferrerUrl As String, ByVal ReferrerCountry As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_UniqueReferrerCountry starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_UniQueReferrer_ByCountry")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerName", ReferrerUrl, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerCountry", ReferrerCountry, System.Data.DbType.String)

            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(ReferrerUrl)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_UniqueReferrerCountry starts" & ex.Message)
            Throw ex
        End Try
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_UniqueReferrerCountry end ")
    End Function
    Public Shared Function GetTotalReferrer_CountryName_IPDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal ReferrerName As String, ByVal CountryName As String, ByVal IP As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalReferrer_CountryName_IPDetail starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As Infinilogic.BusinessPlan.DAL.InfiniCommand

            _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetReferrerBy_IPDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerName", ReferrerName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerCountry", CountryName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@ReferrerIP", IP, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(ReferrerName)
            Web.HttpContext.Current.Trace.Warn(CountryName)
            Web.HttpContext.Current.Trace.Warn(IP)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalReferrer_CountryName_IPDetail starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetCustomerHistoryDetailReferrer(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal _CustomerIDs As String, ByVal Referrer As String) As DataSet
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetCustomerHistoryDetailReferrer")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            _InfiniCommand.AddParameter("@Referrer", Referrer, System.Data.DbType.StringFixedLength)

            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function



    'Name based sorting
    Public Shared Function GetTotalHistory_Country(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_Country starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_Country")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_Country starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory_CountryName(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", CountryName, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts" & ex.Message)
            Throw ex
        End Try

    End Function

    'IP based sorting for products
    Public Shared Function GetTotalHistory_CountryName_IPDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String, ByVal IP As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_IPDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", CountryName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@IP", IP, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(IP)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory_CountryName_IP(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_IP")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", CountryName, System.Data.DbType.String)

            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName starts" & ex.Message)
            Throw ex
        End Try

    End Function

    'IP based sorting for All Activity (product _ activity)
    Public Shared Function GetTotalHistory_CountryName_IPDetailActivity(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String, ByVal IP As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName_IPDetailActivity starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetActivityHistory_IPDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", CountryName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@IP", IP, System.Data.DbType.String)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Web.HttpContext.Current.Trace.Warn(IP)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName_IPDetailActivity starts" & ex.Message)
            Throw ex
        End Try

    End Function
    Public Shared Function GetTotalHistory_CountryName_IPActivity(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String) As DataSet
        Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName_IPActivity starts")
        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            ' _InfiniCommand = New Infinilogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetTotalHistory_CountryName")

            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetActivityHistory_IP")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CountryName", CountryName, System.Data.DbType.String)

            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            Web.HttpContext.Current.Trace.Warn(StartDate)
            Web.HttpContext.Current.Trace.Warn(EndDate)
            Web.HttpContext.Current.Trace.Warn(DomainName)
            Dim _loop As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                For _loop = 0 To ds.Tables(0).Columns.Count - 1
                    Web.HttpContext.Current.Trace.Warn(ds.Tables(0).Columns(_loop).Caption & " : " & CStr(ds.Tables(0).Rows(0).Item(_loop)))
                Next
            End If
            Return ds

        Catch ex As Exception
            Web.HttpContext.Current.Trace.Warn("GetTotalHistory_CountryName_IPActivity starts" & ex.Message)
            Throw ex
        End Try

    End Function


    Public Shared Function ExecuteForSession_History(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetSessionCount")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@DomainName", DomainName, System.Data.DbType.String)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetOrderCount(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal Customerid As String) As Integer

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("BPL_WEBTRACKER_GetOrderCount")

            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CustomerId", Customerid, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)
            If ds.Tables(0).Rows.Count <> 0 Then
                Return CInt(ds.Tables(0).Rows(0).Item(0))
            Else
                Return 0
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetCustomerOrderDetail(ByVal connData As ConnectionData, ByVal StartDate As String, ByVal EndDate As String, ByVal _CustomerIDs As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("BPL_WEBTRACKER_GetCustomerOrderDetail")
            _InfiniCommand.AddParameter("@StartDate", StartDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@EndDate", EndDate, System.Data.DbType.String)
            _InfiniCommand.AddParameter("@CustomerID", _CustomerIDs, System.Data.DbType.StringFixedLength)
            _InfiniCommand.AddParameter("@midentity", connData.CustomerID, System.Data.DbType.UInt32)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetProductName(ByVal connData As ConnectionData, ByVal _Product As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("BPL_WEBTRACKER_GetProductName")
            _InfiniCommand.AddParameter("@MIdentity", connData.CustomerID, System.Data.DbType.UInt32)
            _InfiniCommand.AddParameter("@ProductId", _Product, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetProductDetails(ByVal connData As ConnectionData, ByVal _Products As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("BPL_WEBTRACKER_GETPRODUCTDETAILS")
            _InfiniCommand.AddParameter("@merchant_id", connData.CustomerID, System.Data.DbType.UInt32)
            _InfiniCommand.AddParameter("@products", _Products, System.Data.DbType.StringFixedLength)
            Return DataAccess.ExecuteDataSet(connData, _InfiniCommand)

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetCountryFromIP(ByVal connData As ConnectionData, ByVal _IP As String) As String

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetCountryFromIP")

            _InfiniCommand.AddParameter("@IP", _IP, System.Data.DbType.StringFixedLength)
            Return CStr(DataAccess.ExecuteDataSet(connData, _InfiniCommand).Tables(0).Rows(0).Item(0))

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Public Shared Function GetCountryFromIPCoursor(ByVal connData As ConnectionData, ByVal _SessionID As String) As DataSet

        Dim ds As DataSet

        Try

            Dim _InfiniCommand As InfiniLogic.BusinessPlan.DAL.InfiniCommand
            _InfiniCommand = New InfiniLogic.BusinessPlan.DAL.InfiniCommand("DBSERVER.TRACKER.DBO.BPL_WEBTRACKER_GetCountryFromIP")


            _InfiniCommand.AddParameter("@sid", _SessionID, System.Data.DbType.StringFixedLength)
            ds = DataAccess.ExecuteDataSet(connData, _InfiniCommand)

            Return ds

        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
