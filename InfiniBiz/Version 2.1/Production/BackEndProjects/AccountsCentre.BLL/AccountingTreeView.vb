Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.common
Imports System.Data

''' <summary>
''' Created by Muhammad Furqan Khan for embedded accounting services in InfiniOffice
''' </summary>
''' <remarks></remarks>
Public Class AccountingTreeView

#Region "User defined variables/constants"
    Private Const ExpiryDuration_Hours As Int16 = 5

    Public Structure AccTreeView
        Dim Text As String
        Dim URL As String
        Dim ChildNodes() As AccTreeView
    End Structure

    Public Structure FunctionResult
        Dim IsSuccess As Boolean
        Dim ErrorDesc As String
        Dim ReturnObject As Object
    End Structure

    Public Structure FolderInfo
        Dim ServiceID As String
        Dim ModelID As String
        'Dim URL As String
    End Structure

    Public Structure LinkInfo
        Dim Text As String
        Dim URL As String
    End Structure

    Private AccountingServicesURL As String = "https://" & Web.HttpContext.Current.Request.Url.Host & "/account/accountingservices.aspx?"
    Private InfiniMarketServicesURL As String = System.Configuration.ConfigurationSettings.AppSettings("MarketPlaceDomainName") & "/account/accountingservices.aspx?"
    Private ResellerServicesURL As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerServiceDomainName") & "/account/accountingservices.aspx?"
#End Region

#Region "User defined private functions"
    Private Function GetTreeNodes(ByVal MerchantID As Int64, ByVal IOEmployeeID As String, ByVal IsMerchant As Boolean) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData(MerchantID)
            With cmd
                .CmdText = "IBIZ_GETLINKS"
                .AddParameter("@MIDENTITY", MerchantID)
                If IOEmployeeID Is Nothing Then
                    .AddParameter("@EMPLOYEEID", DBNull.Value)
                Else
                    .AddParameter("@EMPLOYEEID", IOEmployeeID)
                End If
                .AddParameter("@ISMERCHANT", IsMerchant)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                ds = Nothing
            ElseIf ds.Tables(1) Is Nothing OrElse ds.Tables(1).Rows.Count = 0 Then
                ds = Nothing
            End If
            If ds Is Nothing Then
                result.IsSuccess = False
                result.ErrorDesc = "No rights found."
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetTreeNodes. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        result.ReturnObject = ds
        Return result
    End Function

    Private Function GetAllTreeNodes() As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData
            With cmd
                .CmdText = "DBSERVER.INFINISHOPMAINDB.DBO.IBIZ_GETALLLINKS"
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                ds = Nothing
            ElseIf ds.Tables(1) Is Nothing OrElse ds.Tables(1).Rows.Count = 0 Then
                ds = Nothing
            End If
            If ds Is Nothing Then
                result.IsSuccess = False
                result.ErrorDesc = "No nodes found."
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetAllTreeNodes. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        result.ReturnObject = ds
        Return result
    End Function

    Private Function CreateTreeView(ByVal MerchantID As String, ByVal MerchantUID As String, ByVal DsData As DataSet) As AccTreeView
        Dim objTreeView As New AccTreeView
        objTreeView.Text = "Accounting Services"
        objTreeView.URL = GetURL(MerchantID, MerchantUID, "/members/default.aspx", 0, False, "", "")
        Dim child_Service(DsData.Tables(0).Rows.Count - 1) As AccTreeView
        For ServiceCounter As Int16 = 0 To DsData.Tables(0).Rows.Count - 1
            Dim ServiceID As String = DsData.Tables(0).Rows(ServiceCounter)("ID")
            'DsData.Tables(1).Columns("ServiceID").Expression = ServiceID
            Dim DvParent As Data.DataView = DsData.Tables(1).DefaultView
            DvParent.RowFilter = "ServiceID = " & ServiceID
            Dim child_Parent(DvParent.Count - 1) As AccTreeView
            For ParentCounter As Int16 = 0 To DvParent.Count - 1 'DsData.Tables(1).Rows.Count - 1
                Dim ParentNodeID As String = DvParent(ParentCounter)("ModelID") 'DsData.Tables(1).Rows(ParentCounter)("ModelID")
                'DsData.Tables(2).Columns("ModelID").Expression = ParentNodeID
                Dim DvChild As Data.DataView = DsData.Tables(2).DefaultView
                DvChild.RowFilter = "ModelID = " & ParentNodeID
                Dim child_Links(DvChild.Count - 1) As AccTreeView
                For ChildCounter As Int16 = 0 To DvChild.Count - 1 'DsData.Tables(2).Rows.Count - 1
                    child_Links(ChildCounter) = New AccTreeView
                    child_Links(ChildCounter).Text = DvChild(ChildCounter)("MODELOPTIONNAME") 'DsData.Tables(2).Rows(ChildCounter)("MODELOPTIONNAME")
                    child_Links(ChildCounter).URL = GetURL(MerchantID, MerchantUID, DvChild(ChildCounter)("LINKURL"), 0, False, "", "") 'DsData.Tables(2).Rows(ChildCounter)("LINKURL"))
                Next
                child_Parent(ParentCounter) = New AccTreeView
                child_Parent(ParentCounter).Text = DvParent(ParentCounter)("MODELNAME") 'DsData.Tables(1).Rows(ParentCounter)("MODELNAME")
                child_Parent(ParentCounter).URL = GetURL(MerchantID, MerchantUID, DvParent(ParentCounter)("LINKURL"), 0, False, "", "") 'DsData.Tables(1).Rows(ParentCounter)("LINKURL"))
                child_Parent(ParentCounter).ChildNodes = child_Links
            Next
            child_Service(ServiceCounter) = New AccTreeView
            child_Service(ServiceCounter).Text = DsData.Tables(0).Rows(ServiceCounter)("MENUNAME")
            child_Service(ServiceCounter).URL = GetURL(MerchantID, MerchantUID, DsData.Tables(0).Rows(ServiceCounter)("SERVICEURL"), 0, False, "", "")
            child_Service(ServiceCounter).ChildNodes = child_Parent
        Next
        objTreeView.ChildNodes = child_Service
        Return objTreeView
    End Function

    Private Function GetURL(ByVal MerchantID As String, ByVal MerchantUID As String, ByVal PageURL As Object, ByVal serviceID As Integer, ByVal IsMerchant As Boolean, ByVal IoEmployeeID As String, ByVal UserID As String) As String
        Dim returnURL As String = ""
        If Not (PageURL Is DBNull.Value) AndAlso PageURL.ToString.Trim.Length > 0 Then
            PageURL = CStr(PageURL).Replace("=", "//equal//")
            If MerchantID <> "" Then
                Dim objSecure As New SecureQueryString
                With objSecure
                    .Add("MerchantID", MerchantID)
                    .Add("MerchantUID", MerchantUID)
                    .Add("PageURL", PageURL)
                    .Add("IsMerchant", IsMerchant)
                    If Not IsMerchant Then
                        .Add("IoEmployeeID", IoEmployeeID)
                        .Add("UserID", UserID)
                    End If
                    'System.Web.HttpContext.Current.Trace.Warn("PageURL = " & PageURL)
                    .ExpireTime = Now.AddHours(ExpiryDuration_Hours)
                End With
                If serviceID = 25 Then
                    returnURL = InfiniMarketServicesURL & "q=" & objSecure.ToString
                ElseIf serviceID = 26 Then
                    returnURL = ResellerServicesURL & "q=" & objSecure.ToString
                Else
                    returnURL = AccountingServicesURL & "q=" & objSecure.ToString
                End If

            Else
                If serviceID = 25 Then
                    returnURL = InfiniMarketServicesURL & "goto=" & PageURL & "&config="
                ElseIf serviceID = 26 Then
                    returnURL = ResellerServicesURL & "goto=" & PageURL & "&config="
                Else
                    returnURL = AccountingServicesURL & "goto=" & PageURL & "&config="
                End If
            End If
        End If
        Return returnURL
    End Function

    Private Function GetLoginID(ByVal CustomerID As String) As String
        Dim ds As DataSet = (New InfiniLogic.AccountsCentre.BLL.User).GetCustomerData(CustomerID)
        Dim MerchantLoginID As String = ""
        If Not (ds.Tables(0).Rows.Count < 1) Then    ' if dataset is not empty
            Dim strMerchantLoginID As String = ""
            Dim dt1 As DataTable = ds.Tables(0)
            Dim dr1 As DataRow = dt1.Rows(0)

            If Not IsDBNull(dr1.Item(7)) Then strMerchantLoginID = dr1.Item("cart_Customer_UID")
            MerchantLoginID = strMerchantLoginID
        End If
        Return MerchantLoginID
    End Function

    Private Function GetMerchantProModel(ByVal merchantID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData
            With cmd
                .CmdText = "DBSERVER.INFINISHOPMAINDB.DBO.IBIZ_GetMerchantProModel"
                .AddParameter("@MERCHANTID", merchantID)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                result.ReturnObject = Nothing
            Else
                result.ReturnObject = ds.Tables(0)
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetMerchantProModel. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        Return result
    End Function

    Private Function GetMerchantProModelDetail(ByVal merchantID As Int64, ByVal modelID As Int64, ByVal serviceID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData
            With cmd
                .CmdText = "DBSERVER.INFINISHOPMAINDB.DBO.IBIZ_GetMerchantProModelDetail"
                .AddParameter("@MERCHANTID", merchantID)
                .AddParameter("@MODELID", modelID)
                .AddParameter("@SERVICEID", serviceID)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                result.ReturnObject = Nothing
            Else
                result.ReturnObject = ds.Tables(0)
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetMerchantProModelDetail. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        Return result
    End Function

    Private Function GetEmployeeProModel(ByVal merchantID As Int64, ByVal ioEmployeeID As String) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData(merchantID)
            With cmd
                .CmdText = "IBIZ_GetEmployeeProModel"
                .AddParameter("@MIDENTITY", merchantID)
                .AddParameter("@IOEMPLOYEEID", ioEmployeeID)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                result.ReturnObject = Nothing
            Else
                result.ReturnObject = ds.Tables(0)
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetEmployeeProModel. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        Return result
    End Function

    Private Function GetEmployeeProModelDetail(ByVal merchantID As Int64, ByVal ioEmployeeID As String, ByVal modelID As Int64, ByVal serviceID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData(merchantID)
            With cmd
                .CmdText = "IBIZ_GetEmployeeProModelDetail"
                .AddParameter("@MIDENTITY", merchantID)
                .AddParameter("@IOEMPLOYEEID", ioEmployeeID)
                .AddParameter("@MODELID", modelID)
                .AddParameter("@SERVICEID", serviceID)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                result.ReturnObject = Nothing
            Else
                result.ReturnObject = ds.Tables(0)
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in GetEmployeeProModel. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

        Return result
    End Function

    Private Function CreateProModelStructure(ByVal merchantID As String, ByVal merchantUID As String, ByVal dt As DataTable) As FolderInfo()
        Dim drPendingTransactions() As DataRow = dt.Select("SERVICEID = 5 and MODELID = 79")
        If (Not drPendingTransactions Is Nothing) AndAlso drPendingTransactions.Length > 0 Then
            If Not ShowPendingTransactionLink(merchantID) Then
                dt.Rows.Remove(drPendingTransactions(0))
                dt.AcceptChanges()
            End If
        End If

        Dim result(dt.Rows.Count - 1) As FolderInfo

        For counter As Int64 = 0 To dt.Rows.Count - 1
            result(counter) = New FolderInfo
            With result(counter)
                .ServiceID = dt.Rows(counter)("SERVICEID")
                .ModelID = dt.Rows(counter)("MODELID")
                '.URL = GetURL(merchantID, merchantUID, dt.Rows(counter)("LINKURL"))
            End With
        Next
        Return result
    End Function

    Private Function CreateProModelDetailStructure(ByVal merchantID As String, ByVal merchantUID As String, ByVal dt As DataTable, ByVal serviceID As Integer, ByVal IsMerchant As Boolean, ByVal IoEmployeeID As String, ByVal UserID As String) As LinkInfo()
        Dim result(dt.Rows.Count - 1) As LinkInfo
        For counter As Int64 = 0 To dt.Rows.Count - 1
            result(counter) = New LinkInfo
            With result(counter)
                .Text = dt.Rows(counter)("MODELOPTIONNAME")
                .URL = GetURL(merchantID, merchantUID, dt.Rows(counter)("LINKURL"), serviceID, IsMerchant, IoEmployeeID, UserID)
            End With
        Next
        Return result
    End Function

    Private Function ShowPendingTransactionLink(ByVal MerchantID As Int64) As Boolean
        '[InfiniShopMainDB].[dbo].[CAM_CHECK_PAYPROCESSOR] 
        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            cmd = New CommandData
            With cmd
                .CmdText = "DBServer.InfiniShopMaindb.dbo.CAM_CHECK_PAYPROCESSOR"
                .AddParameter("@customerID", MerchantID)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Finally
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try
    End Function

    Private Function GetUserIDByIoEmployeeId(ByVal ioEmployeeID As String, ByVal MerchantId As Int64) As String
        Dim cmd As CommandData
        Dim ds As DataSet = Nothing
        Try
            Dim userid As String = ""
            cmd = New CommandData
            With cmd
                .CmdText = "DBServer.InfiniShopMaindb.dbo.IBIZ_GetUserIdByIoEmployeeId"
                .AddParameter("@MIDENTITY", MerchantId)
                .AddParameter("@IOEMPLOYEEID", ioEmployeeID)
                userid = .Execute(ExecutionType.ExecuteScalar)
            End With
            Return userid
        Finally
            If Not (cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try
    End Function

#End Region

    Public Function GetTreeView_Merchant(ByVal MerchantID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim MerchantUID As String = GetLoginID(MerchantID)

        result = GetTreeNodes(MerchantID, Nothing, True)
        If result.IsSuccess Then
            result.ReturnObject = CreateTreeView(MerchantID, MerchantUID, result.ReturnObject)
        End If
        Return result
    End Function

    Public Function GetTreeView_Employee(ByVal MerchantID As Int64, ByVal IOEmployeeID As String) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Dim MerchantUID As String = GetLoginID(MerchantID)

        result = GetTreeNodes(MerchantID, IOEmployeeID, False)
        If result.IsSuccess Then
            result.ReturnObject = CreateTreeView(MerchantID, MerchantUID, result.ReturnObject)
        End If
        Return result
    End Function

    Public Function GetTreeView() As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        result = GetAllTreeNodes()
        If result.IsSuccess Then
            result.ReturnObject = CreateTreeView("", "", result.ReturnObject)
        End If
        Return result
    End Function

    Public Function Encrypt_Merchant(ByVal MerchantID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Try
            Dim MerchantUID As String = GetLoginID(MerchantID)
            Dim objsecure As New SecureQueryString
            With objsecure
                .Add("IsMerchant", True)
                .Add("MerchantID", MerchantID)
                .Add("MerchantUID", MerchantUID)
                .ExpireTime = Now.AddHours(ExpiryDuration_Hours)
            End With
            result.IsSuccess = True
            result.ErrorDesc = ""
            result.ReturnObject = objsecure.ToString
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in Encrypt_Merchant. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            result.ReturnObject = Nothing
        End Try
        Return result
    End Function

    Public Function Encrypt_MerchantAndEmployee(ByVal MerchantID As Int64, ByVal IoEmployeeID As String, ByVal IsMerchant As Boolean) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        Try
            Dim MerchantUID As String = GetLoginID(MerchantID)
            Dim objsecure As New SecureQueryString
            With objsecure
                .Add("IsMerchant", IsMerchant)
                .Add("MerchantID", MerchantID)
                .Add("MerchantUID", MerchantUID)
                If Not IsMerchant Then
                    .Add("IoEmployeeID", IoEmployeeID)
                    .Add("UserID", GetUserIDByIoEmployeeId(IoEmployeeID, MerchantID))
                End If
                .ExpireTime = Now.AddHours(ExpiryDuration_Hours)
            End With
            result.IsSuccess = True
            result.ErrorDesc = ""
            result.ReturnObject = objsecure.ToString
        Catch ex As Exception
            result.IsSuccess = False
            result.ErrorDesc = "Exception occured in Encrypt_Merchant. Message = " & ex.Message & " " & vbNewLine & _
                                "StackTrace = " & ex.StackTrace
            result.ReturnObject = Nothing
        End Try
        Return result
    End Function

    Public Function GetAllowedFolders(ByVal merchantID As String, ByVal ioEmployeeID As String, ByVal isMerchant As Boolean) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing

        If isMerchant Then
            result = GetMerchantProModel(merchantID)
        Else
            result = GetEmployeeProModel(merchantID, ioEmployeeID)
        End If
        If result.IsSuccess AndAlso Not (result.ReturnObject Is Nothing) Then
            Dim MerchantUID As String = GetLoginID(merchantID)
            result.ReturnObject = CreateProModelStructure(merchantID, MerchantUID, result.ReturnObject)
        End If
        Return result
    End Function

    Public Function GetFolderLinks(ByVal merchantID As String, ByVal ioEmployeeID As String, ByVal isMerchant As Boolean, ByVal serviceID As Int64, ByVal modelID As Int64) As FunctionResult
        Dim result As New FunctionResult
        result.IsSuccess = True
        result.ErrorDesc = ""
        result.ReturnObject = Nothing
        Dim userID As String = String.Empty
        If isMerchant Then
            result = GetMerchantProModelDetail(merchantID, modelID, serviceID)
        Else
            result = GetEmployeeProModelDetail(merchantID, ioEmployeeID, modelID, serviceID)
            userID = GetUserIDByIoEmployeeId(ioEmployeeID, merchantID)
        End If
        If result.IsSuccess AndAlso Not (result.ReturnObject Is Nothing) Then
            Dim MerchantUID As String = GetLoginID(merchantID)
            result.ReturnObject = CreateProModelDetailStructure(merchantID, MerchantUID, result.ReturnObject, serviceID, isMerchant, ioEmployeeID, userID)
        End If
        Return result
    End Function

End Class
