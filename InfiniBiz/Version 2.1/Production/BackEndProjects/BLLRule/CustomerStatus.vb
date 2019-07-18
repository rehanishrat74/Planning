#Region "......................Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Windows.Forms

Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Common
Imports System.Text
#End Region


Public Class CustomerStatus

    Public Shared Function CustomerSerivceStatus(ByVal connData As ConnectionData) As Boolean
        Try

            Dim command As New InfiniCommand("BizPlan_ServiceCheck")
            command.AddParameter("@CustomerId", connData.CustomerID)
            Dim DataReader As SqlDataReader = CType(DataAccess.ExecuteDataReader(connData, command), SqlDataReader)

            If DataReader.Read() Then
                ' If CStr(DataReader("CustomerID")) = "2" Or CStr(DataReader("CustomerID")) = "99654" Then
                If CStr(DataReader("CustomerID")) = CStr(connData.CustomerID) Then

                    Return True
                End If
            Else
                Return False
            End If

        Catch ex As Exception
            Dim StrError As String = ex.Message
        End Try

    End Function


    Public Shared Function GetComapnyName(ByVal connData As ConnectionData) As DataSet

        Try
            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetCompanyName"
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try


    End Function
    Public Shared Function Get_FlashClip(ByVal planid As String, ByVal connData As ConnectionData) As DataSet
        Try


            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetClipByPlanid"
            cmd.AddParameter("@Planid", planid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function getMeterNumber(ByVal planid As String, ByVal connData As ConnectionData) As String
        Try


            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetindexforTree"
            cmd.AddParameter("@Planid", planid)
            Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
            If rd.Read Then
                Return CType(Val(rd.Item(0)) - 1, String)
            Else

            End If
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function
    Public Shared Function GetPlansName(ByVal planid As String, ByVal connData As ConnectionData) As String
        Dim cmd As New CommandData(connData.CustomerID)
        cmd.CmdText = "BPL_GetPlanNameByID"
        cmd.AddParameter("@MIdentity", connData.CustomerID)
        cmd.AddParameter("@Planid", planid)
        Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
        If rd.Read Then
            Return CType(rd.Item(0), String)
        Else

        End If


    End Function



    Public Shared Function GetPlansListforMeters(ByVal connData As ConnectionData) As DataSet
        Dim command As New InfiniCommand("BPL_ManagerPlansClip")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        Return ds
    End Function

    Public Shared Function GetPlansListforMeters_IO(ByVal connData As ConnectionData) As DataSet
        Dim command As New InfiniCommand("BPL_ManagerPlansClip_IO")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        Return ds
    End Function

    Public Shared Function GetPlansListforMeters_IOSystem(ByVal CustomerID As Integer) As DataSet
        Dim MIdentity As Integer = 0
        Dim ds As DataSet
        Dim cmd As New CommandData(CustomerID)

        Try
            cmd.CmdText = "BPL_ManagerPlansClip_IO"
            cmd.AddParameter("@MIdentity", CustomerID)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

    End Function


    Public Shared Function GetPlansListforMeters_Enterprise(ByVal connData As ConnectionData) As DataSet
        Dim command As New InfiniCommand("BPL_ManagerPlansClip_Enterprise")
        command.AddParameter("@MIdentity", connData.CustomerID)
        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

        Return ds
    End Function

    Public Shared Function GetPlansListforMeters_EnterPriseSystem(ByVal CustomerID As Integer) As DataSet
        Dim MIdentity As Integer = 0
        Dim ds As DataSet
        Dim cmd As New CommandData(CustomerID)

        Try
            cmd.CmdText = "BPL_ManagerPlansClip_Enterprise"
            cmd.AddParameter("@MIdentity", CustomerID)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

    End Function

    'Public Shared Function GetPlansListforMeters(ByVal connData As ConnectionData) As DataTable
    '    Dim command As New InfiniCommand("BPL_GetClipforCustomer")
    '    command.AddParameter("@MIdentity", connData.CustomerID)
    '    Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)

    '    Return ds.Tables(0)
    'End Function

    Public Shared Function CheckforClipbyPlanid(ByVal planid As String, ByVal connData As ConnectionData) As Boolean
        Dim cmd As New CommandData(connData.CustomerID)
        cmd.CmdText = "BPL_CheckforClipbyPlanid"
        cmd.AddParameter("@Planid", planid)
        Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
        If rd.Read Then

            Return True
        Else
            Return False
        End If


    End Function
    Public Shared Function Getplanids(ByVal connData As ConnectionData) As DataSet
        Try
            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetClipByPlanid"

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function CheckClipsStatus(ByVal Planid As String, ByVal connData As ConnectionData) As Boolean
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_CheckClipExsistForPlan"
            cmd.AddParameter("@Planid", Planid)

            Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
            If rd.Read Then

                Return True
            Else
                Return False
            End If


        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function AnyEntityExsists(ByVal Planid As String, ByRef connData As ConnectionData) As Boolean
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.AddParameter("@Planid", Planid)
            cmd.CmdText = "BPL_GetProductname"
            Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
            If rd.Read Then

                Return True
            Else
                Return False
            End If
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try



    End Function

    Public Shared Function GetSystemMeters(ByRef connData As ConnectionData) As Integer

        Dim MIdentity As Integer = 0
        Dim ds As DataSet
        Dim cmd As New CommandData(connData.CustomerID)

        Try
            With cmd
                .ClearParameters()
                .CmdType = CommandType.StoredProcedure
                .CmdText = "ACCOUNTSPRO_IODOC_GETSYSTEMID"
                .AddParameter("@MIdentity", connData.CustomerID)
                ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            End With

            If ds.Tables(0).Rows.Count > 0 Then

                MIdentity = CType(ds.Tables(0).Rows(0).Item(0), Integer)
            End If

            Return MIdentity

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

    End Function


    Public Shared Function GetEntityByPID(ByVal Planid As String, ByVal AnalysisId As String, ByVal connData As ConnectionData) As DataSet
        Try
            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_SelectEntityClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@AnalysisId", AnalysisId)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    'Checked 
    Public Shared Function GetNodes(ByVal PRODUCT_ID As String, ByVal connData As ConnectionData) As DataRow
        Try
            Dim ds As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetEntityName"
            cmd.AddParameter("@PRODUCT_ID", PRODUCT_ID)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds.Tables(0).Rows(0)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function


    Public Shared Function GetManyNodes(ByVal PRODUCT_IDs As String, ByVal PlanID As String, ByVal connData As ConnectionData, ByVal ProSdate As String, ByVal ProEdate As String, ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String) As String
        Dim intPlanSdate As Integer = CInt(PlanSdate)
        Dim intPlanEdate As Integer = CInt(PlanEdate)
        If ProSdate = "" Then ProSdate = Format(Date.Now, "dd MMM yyyy")
        If ProEdate = "" Then ProEdate = Format(Date.Now, "dd MMM yyyy")

        Try
            Dim dt As DataTable
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetNodesXML"
            cmd.AddParameter("@MIdentity", connData.CustomerID)
            cmd.AddParameter("@PRODUCT_ID", "0")

            cmd.AddParameter("@Planid", PlanID)


            cmd.AddParameter("@ProSdate", ProSdate)
            cmd.AddParameter("@ProEdate", ProEdate)
            cmd.AddParameter("@PlanSdate", intPlanSdate)
            cmd.AddParameter("@PlanEdate", intPlanEdate)
            dt = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)
            Dim RetNode As String = CallMultipleNodeXML(dt, PRODUCT_IDs)
            Return RetNode


        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function CallMultipleNodeXML(ByVal dt As DataTable, ByVal PRODUCTS_IDs As String) As String

        Dim intloop As Integer
        Dim Nodeitem As StringBuilder
        Dim Product_id As String() = PRODUCTS_IDs.Split(","c)
        Dim dr_Product As DataRow
        Dim da_Product As Array
        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder

        For intloop = 0 To Product_id.Length - 1
            da_Product = dt.Select("productid='" & Product_id(intloop) & "'")
            For Each dr_Product In da_Product
                Nodeitem.Append(CStr(dr_Product(1)) + ",")
            Next
        Next
        Dim strNode As String = Nodeitem.ToString
        Return strNode


    End Function

    Public Shared Function updateRealTimeDate(ByVal MeterId As String, ByVal updatedClip As String, ByVal updatedLargeClip As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_UpdateRealtimeDate"
            cmd.AddParameter("@MeterId", MeterId)
            cmd.AddParameter("@updatedClip", updatedClip)
            cmd.AddParameter("@updatedLargeClip", updatedLargeClip)

            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return CType(ds.Tables(0).Rows(0).Item(3), String)


        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try
    End Function

    Public Shared Function updateRealTimeDate_System(ByVal MeterId As String, ByVal updatedClip As String, ByVal updatedLargeClip As String, ByVal CustomerID As Integer) As String
        Try
            Dim cmd As New CommandData(CustomerID)
            cmd.CmdText = "BPL_UpdateRealtimeDate"
            cmd.AddParameter("@MeterId", MeterId)
            cmd.AddParameter("@updatedClip", updatedClip)
            cmd.AddParameter("@updatedLargeClip", updatedLargeClip)

            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return CType(ds.Tables(0).Rows(0).Item(3), String)


        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try
    End Function

    Public Shared Function InsertEntity(ByVal MeterName As String, ByVal Planid As String, ByVal CriteriaId As String, _
    ByVal ClipType As String, ByVal EntityName As String, ByVal EntityId As String, ByVal Clip As String, ByVal LargeClip As String, _
    ByVal Code As String, ByVal ProStartdate As String, ByVal ProEnddate As String, ByVal PlanStartdate As String, ByVal PlanEnddate As String, _
    ByVal StartInterval As String, ByVal EndInterval As String, ByVal chkBit As Boolean, ByVal connData As ConnectionData, _
     ByVal boolRealTime As Boolean, ByVal boolScope As Boolean, ByVal boolService As Boolean, ByVal boolCurrency As Boolean) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            If chkBit = True Then
                If StartInterval = "" Then StartInterval = Format(Date.Now, "dd MMM yyyy")
                If EndInterval = "" Then EndInterval = Format(Date.Now, "dd MMM yyyy")


            End If
            cmd.CmdText = "BPL_InsertMeters"
            cmd.AddParameter("@MeterName", MeterName)
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@CriteriaId", CriteriaId)
            cmd.AddParameter("@ClipType", ClipType)
            cmd.AddParameter("@EntityName", EntityName)
            cmd.AddParameter("@EntityId", EntityId)
            cmd.AddParameter("@Clip", Clip)
            cmd.AddParameter("@LargeClip", LargeClip)
            cmd.AddParameter("@Code", Code)
            cmd.AddParameter("@ProStartdate", ProStartdate)
            cmd.AddParameter("@ProEnddate", ProEnddate)
            cmd.AddParameter("@PlanStartdate", PlanStartdate)
            cmd.AddParameter("@PlanEnddate", PlanEnddate)
            cmd.AddParameter("@StartInterval", StartInterval)
            cmd.AddParameter("@EndInterval", EndInterval)
            cmd.AddParameter("@chkBit", chkBit)
            cmd.AddParameter("@chkRealTime", boolRealTime)
            cmd.AddParameter("@boolScope", boolScope)
            cmd.AddParameter("@boolService", boolService)
            cmd.AddParameter("@boolCurrency", boolCurrency)
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim stra As String = ex.Message
        End Try

    End Function

    Public Shared Function InsertEntity(ByVal MeterName As String, ByVal Planid As String, ByVal CriteriaId As String, _
  ByVal ClipType As String, ByVal EntityName As String, ByVal EntityId As String, ByVal Clip As String, ByVal LargeClip As String, _
  ByVal Code As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_InsertInfr"
            cmd.AddParameter("@MeterName", MeterName)
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@CriteriaId", CriteriaId)
            cmd.AddParameter("@ClipType", ClipType)
            cmd.AddParameter("@EntityName", EntityName)
            cmd.AddParameter("@EntityId", EntityId)
            cmd.AddParameter("@Clip", Clip)
            cmd.AddParameter("@LargeClip", LargeClip)
            cmd.AddParameter("@Code", Code)
            cmd.AddParameter("@Time", Date.Now)

            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function



    Public Shared Function UpdateEntity(ByVal Analysisid As String, ByVal MeterName As String, ByVal Planid As String, ByVal CriteriaId As String, _
    ByVal ClipType As String, ByVal EntityName As String, ByVal EntityId As String, ByVal Clip As String, ByVal LargeClip As String, ByVal Code As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_UpdateMeterInfr"
            cmd.AddParameter("@Analysisid", Analysisid)
            cmd.AddParameter("@MeterName", MeterName)
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@CriteriaId", CriteriaId)
            cmd.AddParameter("@ClipType", ClipType)
            cmd.AddParameter("@EntityName", EntityName)
            cmd.AddParameter("@EntityId", EntityId)
            cmd.AddParameter("@Clip", Clip)
            cmd.AddParameter("@Code", Code)
            cmd.AddParameter("@LargeClip", LargeClip)
            cmd.AddParameter("@Time", Date.Now)
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function





    Public Shared Function UpdateEntity(ByVal Analysisid As String, ByVal MeterName As String, ByVal Planid As String, ByVal CriteriaId As String, _
    ByVal ClipType As String, ByVal EntityName As String, ByVal EntityId As String, ByVal Clip As String, ByVal LargeClip As String, _
    ByVal Code As String, ByVal ProStartdate As String, ByVal ProEnddate As String, ByVal PlanStartdate As String, _
    ByVal PlanEnddate As String, ByVal StartInterval As String, ByVal EndInterval As String, ByVal chkBit As Boolean, _
    ByVal connData As ConnectionData, ByVal boolRealTime As Boolean, ByVal boolScope As Boolean, ByVal boolService As Boolean, ByVal boolCurrency As Boolean) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            If chkBit = True Then
                If StartInterval = "" Then StartInterval = Format(Date.Now, "dd MMM yyyy")
                If EndInterval = "" Then EndInterval = Format(Date.Now, "dd MMM yyyy")

            End If
            cmd.CmdText = "BPL_UpdateMeterInformation"
            cmd.AddParameter("@Analysisid", Analysisid)
            cmd.AddParameter("@MeterName", MeterName)
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@CriteriaId", CriteriaId)
            cmd.AddParameter("@ClipType", ClipType)
            cmd.AddParameter("@EntityName", EntityName)
            cmd.AddParameter("@EntityId", EntityId)
            cmd.AddParameter("@Clip", Clip)
            cmd.AddParameter("@Code", Code)
            cmd.AddParameter("@LargeClip", LargeClip)
            cmd.AddParameter("@ProStartdate", ProStartdate)
            cmd.AddParameter("@ProEnddate", ProEnddate)
            cmd.AddParameter("@PlanStartdate", PlanStartdate)
            cmd.AddParameter("@PlanEnddate", PlanEnddate)
            cmd.AddParameter("@StartInterval", StartInterval)
            cmd.AddParameter("@EndInterval", EndInterval)
            cmd.AddParameter("@chkBit", chkBit)
            cmd.AddParameter("@chkRealTime", boolRealTime)
            cmd.AddParameter("@boolScope", boolScope)
            cmd.AddParameter("@boolService", boolService)
            cmd.AddParameter("@boolCurrency", boolCurrency)
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim strz As String = ex.Message
        End Try

    End Function



    Public Shared Function DeleteEntity(ByVal Planid As String, ByVal AnalysisId As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_DeltetEntityClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@AnalysisId", AnalysisId)

            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function


    Public Shared Function Add_Fav_Entity(ByVal Planid As String, ByVal favroitesId As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetFavoriteEntityClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@favroitesId", favroitesId)
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function


    Public Shared Function GetZoomView(ByVal Planid As String, ByVal ZoomId As String, ByVal connData As ConnectionData) As DataSet
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetZoomClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@ZoomId", ZoomId)
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return ds

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function GetPlanidZoomView(ByVal ZoomId As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetZoomClipPlanId"

            cmd.AddParameter("@ZoomId", ZoomId)
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return CType(ds.Tables(0).Rows(0).Item(0), String)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function GetZoomViewSystem(ByVal Planid As String, ByVal ZoomId As String, ByVal CustomerID As Integer) As DataSet
        Try
            Dim cmd As New CommandData(CustomerID)
            cmd.CmdText = "BPL_GetZoomClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@ZoomId", ZoomId)
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return ds

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function GetPlanidZoomViewSystem(ByVal ZoomId As String, ByVal CustomerID As Integer) As String
        Try
            Dim cmd As New CommandData(CustomerID)
            cmd.CmdText = "BPL_GetZoomClipPlanId"

            cmd.AddParameter("@ZoomId", ZoomId)
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)

            Return CType(ds.Tables(0).Rows(0).Item(0), String)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function


    Public Shared Function Remove_Fav_Entity(ByVal Planid As String, ByVal RemovefavroitesId As String, ByVal connData As ConnectionData) As String
        Try
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_RemoveFavoriteEntityClip"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@RemovefavroitesId", RemovefavroitesId)
            cmd.Execute(ExecutionType.ExecuteNonQuery)

        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function
    Public Shared Function Get_favoritesClip(ByVal Planid As String, ByVal connData As ConnectionData) As DataSet
        Try
            Dim dsGetClipsFav As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_SetFavoriteClip"
            cmd.AddParameter("@Planid", Planid)

            dsGetClipsFav = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return dsGetClipsFav
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function GetFavroitesClipListing(ByVal Planid As String, ByVal connData As ConnectionData) As DataSet
        Try
            Dim dssetClipsFav As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetFavroitesClipListing"
            cmd.AddParameter("@Planid", Planid)

            dssetClipsFav = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return dssetClipsFav
        Catch ex As BizPlanDBInvalidDataException
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function SearchEntity(ByRef connData As ConnectionData, ByVal Planid As String, Optional ByVal ID As String = "", Optional ByVal Name As String = "") As DataTable
        Try
            Dim dsSearchResult As DataSet
            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_SearchEntity"
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@ID", ID)
            cmd.AddParameter("@Name", Name)
            dsSearchResult = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return dsSearchResult.Tables(0)
        Catch ex As Exception
            Dim str1 As String = ex.Message
        End Try

    End Function

    Public Shared Function FetchProduct(ByVal Planid As String, ByRef connData As ConnectionData) As DataSet
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.AddParameter("@Planid", Planid)
            cmd.CmdText = "BPL_GetProductname"
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try



    End Function



    Public Shared Function PopulateMeterTreeManager(ByVal planid As String, ByRef connData As ConnectionData) As String
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_SetClipListingManager"
            cmd.AddParameter("@Planid", planid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return CType(ds.Tables(0).Rows(0).Item(0), String)
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try

    End Function

    Public Shared Function PopulateMeterTreeManagerSystem(ByVal planid As String, ByRef CustomerID As Integer) As String
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(CustomerID)
            cmd.CmdText = "BPL_SetClipListingManager"
            cmd.AddParameter("@Planid", planid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return CType(ds.Tables(0).Rows(0).Item(0), String)
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try

    End Function

    Public Shared Function PopulateMeterTree(ByVal planid As String, ByRef connData As ConnectionData) As DataSet
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_SetClipListing"
            cmd.AddParameter("@Planid", planid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try



    End Function

    Public Shared Function GetMeterName(ByVal MeterName As String, ByVal planid As String, ByRef connData As ConnectionData) As Boolean
        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetMeterName"
            cmd.AddParameter("@MeterName", MeterName)
            cmd.AddParameter("@Planid", planid)
            Dim rd As SqlDataReader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
            If rd.Read Then

                Return True
            Else
                Return False
            End If

        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try



    End Function


    Public Shared Function FetchEntity(ByVal Planid As String, ByRef connData As ConnectionData) As DataSet

        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetProductname"
            cmd.AddParameter("@Planid", Planid)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try

    End Function
    Public Shared Function CTR(ByRef connData As ConnectionData) As DataSet

        Dim ds As DataSet
        Try

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "BPL_GetCriteriaforSelection"
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds
        Catch ex As BizPlanDBInvalidDataException
            Dim strError As String = ex.Message
        End Try

    End Function

End Class


Public Enum FlashCriteriaType As Integer

    ProductServiceAnalysis
    COGSAnalysis
    '  GPAnalysis
    ExpensesAnalysis
    ' EBITAnalysis
    '  AssetsAnalysis
    ' TLandEquityAnalysis

End Enum


Public Enum Stages As Integer

    WelcomePage
    CriteriaSelection
    MovieSelection
    ProductSelection

End Enum

Public Enum BasicStages As Integer

    WelcomePage
    CriteriaSelection
    TimeSelection
    ProductSelection

End Enum

Public Enum clip As Integer

    rbImeter
    rbIActuals
    rbIcombine

End Enum

Public Enum Btrack As Integer
    zero
    one
    two
    three
End Enum