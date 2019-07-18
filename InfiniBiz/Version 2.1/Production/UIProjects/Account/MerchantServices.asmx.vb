Imports InfiniLogic
Imports System.Web.Services

<System.Web.Services.WebService(Namespace:="http://tempuri.org/accounts.infinibiz.Web/MerchantServices")> _
Public Class MerchantServices
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub

    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    <WebMethod(EnableSession:=True)> _
    Public Function GetTreeView_Merchant(ByVal LoginInfo As LoginInfo_Merchant) As AccTreeViewResult
        Dim result As New AccTreeViewResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."
        result.AccTreeView = Nothing

        System.Web.HttpContext.Current.Trace.Warn("START : GetTreeView_Merchant " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & LoginInfo.CustomerID)

        If LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetTreeView_Merchant(LoginInfo.CustomerID)
            If BllResult.IsSuccess Then
                result.AccTreeView = BllResult.ReturnObject
            Else
                result.ErrorCode = -2
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : GetTreeView_Merchant " & Now.ToString)

        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetTreeView_Employee(ByVal LoginInfo As LoginInfo_Employee) As AccTreeViewResult
        Dim result As New AccTreeViewResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."
        result.AccTreeView = Nothing

        System.Web.HttpContext.Current.Trace.Warn("START : GetTreeView_Employee " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & LoginInfo.CustomerID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.EmployeeID = " & LoginInfo.EmployeeID)

        If LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        ElseIf LoginInfo.EmployeeID Is Nothing OrElse LoginInfo.EmployeeID.Length = 0 Then
            result.ErrorCode = -2
            result.ErrorDesc = "Invalid EmployeeID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetTreeView_Employee(LoginInfo.CustomerID, LoginInfo.EmployeeID)
            If BllResult.IsSuccess Then
                result.AccTreeView = BllResult.ReturnObject
            Else
                result.ErrorCode = -3
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : GetTreeView_Employee " & Now.ToString)

        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
   Public Function GetTreeView() As AccTreeViewResult
        Dim result As New AccTreeViewResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."
        result.AccTreeView = Nothing

        System.Web.HttpContext.Current.Trace.Warn("START : GetTreeView " & Now.ToString)
        Dim objBll As New AccountsCentre.BLL.AccountingTreeView
        Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetTreeView
        If BllResult.IsSuccess Then
            result.AccTreeView = BllResult.ReturnObject
        Else
            result.ErrorCode = -3
            result.ErrorDesc = BllResult.ErrorDesc
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : GetTreeView " & Now.ToString)

        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
       Public Function Encrypt_Merchant(ByVal LoginInfo As LoginInfo_Merchant) As EncryptResult
        Dim result As New EncryptResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."

        System.Web.HttpContext.Current.Trace.Warn("START : Encrypt_Merchant " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & LoginInfo.CustomerID)

        If LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.Encrypt_Merchant(LoginInfo.CustomerID)
            If BllResult.IsSuccess Then
                result.AppendText = BllResult.ReturnObject
            Else
                result.ErrorCode = -2
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : Encrypt_Merchant " & Now.ToString)

        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
       Public Function Encrypt_MerchantAndEmployee(ByVal LoginInfo As UserInfo) As EncryptResult
        Dim result As New EncryptResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."

        System.Web.HttpContext.Current.Trace.Warn("START : Encrypt_MerchantAndEmployee " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.IsMerchant = " & LoginInfo.IsMerchant)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & LoginInfo.CustomerID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.EmployeeID = " & LoginInfo.EmployeeID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.FHSessionID = " & LoginInfo.FHSessionID)
        System.Web.HttpContext.Current.Trace.Warn("Before LoginInfo.IoReturnURL = " & LoginInfo.IoReturnURL)

        If LoginInfo.FHSessionID Is Nothing Then
            LoginInfo.FHSessionID = ""
        End If
        If LoginInfo.IoReturnURL Is Nothing Then
            LoginInfo.IoReturnURL = ""
        Else
            LoginInfo.IoReturnURL = LoginInfo.IoReturnURL.Replace("=", "//equal//").Replace("&", "//amp//")
        End If

        System.Web.HttpContext.Current.Trace.Warn("After LoginInfo.IoReturnURL = " & LoginInfo.IoReturnURL)

        If LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        ElseIf Not LoginInfo.IsMerchant AndAlso (LoginInfo.EmployeeID Is Nothing OrElse LoginInfo.EmployeeID.Trim.Length = 0) Then
            result.ErrorCode = -2
            result.ErrorDesc = "Invalid EmployeeID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.Encrypt_MerchantAndEmployee(LoginInfo.CustomerID, LoginInfo.EmployeeID, LoginInfo.IsMerchant, LoginInfo.IoReturnURL, LoginInfo.FHSessionID)
            If BllResult.IsSuccess Then
                result.AppendText = BllResult.ReturnObject
            Else
                result.ErrorCode = -3
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : Encrypt_MerchantAndEmployee " & Now.ToString)

        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetAllowedFolders(ByVal LoginInfo As UserInfo) As AllowedFoldersResult
        Dim result As New AllowedFoldersResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."

        System.Web.HttpContext.Current.Trace.Warn("START : GetAllowedFolders " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.IsMerchant = " & LoginInfo.IsMerchant)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & LoginInfo.CustomerID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.EmployeeID = " & LoginInfo.EmployeeID)

        If LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        ElseIf Not LoginInfo.IsMerchant AndAlso (LoginInfo.EmployeeID Is Nothing OrElse LoginInfo.EmployeeID.Length = 0) Then
            result.ErrorCode = -2
            result.ErrorDesc = "Invalid EmployeeID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetAllowedFolders(LoginInfo.CustomerID, LoginInfo.EmployeeID, LoginInfo.IsMerchant)
            If BllResult.IsSuccess Then
                result.AllowedIDs = BllResult.ReturnObject
            Else
                result.ErrorCode = -3
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        If result.AllowedIDs Is Nothing Then
            System.Web.HttpContext.Current.Trace.Warn("result.AllowedIDs Is Nothing")
        ElseIf result.AllowedIDs.LongLength = 0 Then
            System.Web.HttpContext.Current.Trace.Warn("result.AllowedIDs.LongLength = 0")
        Else
            System.Web.HttpContext.Current.Trace.Warn("result.AllowedIDs.LongLength = " & result.AllowedIDs.LongLength)
            If LoginInfo.CustomerID = 2 OrElse LoginInfo.CustomerID = 122277 OrElse LoginInfo.CustomerID = 115161 Then
                System.Web.HttpContext.Current.Trace.Warn("*********************************************")
                For Each finfo As AccountsCentre.BLL.AccountingTreeView.FolderInfo In result.AllowedIDs
                    System.Web.HttpContext.Current.Trace.Warn("------------")
                    System.Web.HttpContext.Current.Trace.Warn("     ModelID = " & finfo.ModelID)
                    System.Web.HttpContext.Current.Trace.Warn("     ServiceID = " & finfo.ServiceID)
                Next
                System.Web.HttpContext.Current.Trace.Warn("*********************************************")
            End If
        End If
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : GetAllowedFolders " & Now.ToString)
        Return result
    End Function

    <WebMethod(EnableSession:=True)> _
    Public Function GetFolderLinks(ByVal info As UserAndFolderInfo) As FolderLinksResult
        Dim result As New FolderLinksResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."

        System.Web.HttpContext.Current.Trace.Warn("START : GetFolderLinks " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & info.LoginInfo.CustomerID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.IsMerchant = " & info.LoginInfo.IsMerchant)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.EmployeeID = " & info.LoginInfo.EmployeeID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.FHSessionID = " & info.LoginInfo.FHSessionID)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.IoReturnURL = " & info.LoginInfo.IoReturnURL)
        System.Web.HttpContext.Current.Trace.Warn("Finfo.ServiceID = " & info.Finfo.ServiceID)
        System.Web.HttpContext.Current.Trace.Warn("Finfo.ModelID = " & info.Finfo.ModelID)

        If info.LoginInfo.CustomerID Is Nothing OrElse Not IsNumeric(info.LoginInfo.CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        ElseIf Not info.LoginInfo.IsMerchant AndAlso (info.LoginInfo.EmployeeID Is Nothing OrElse info.LoginInfo.EmployeeID.Length = 0) Then
            result.ErrorCode = -2
            result.ErrorDesc = "Invalid EmployeeID."
        ElseIf info.Finfo.ServiceID Is Nothing OrElse Not IsNumeric(info.Finfo.ServiceID) Then
            result.ErrorCode = -3
            result.ErrorDesc = "Invalid ServiceID."
        ElseIf info.Finfo.ModelID Is Nothing OrElse Not IsNumeric(info.Finfo.ModelID) Then
            result.ErrorCode = -4
            result.ErrorDesc = "Invalid ModelID"
        Else
            If info.LoginInfo.IoReturnURL Is Nothing Then
                info.LoginInfo.IoReturnURL = ""
            End If
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetFolderLinks(info.LoginInfo.CustomerID, info.LoginInfo.EmployeeID, info.LoginInfo.IsMerchant, info.Finfo.ServiceID, info.Finfo.ModelID, info.LoginInfo.IoReturnURL, info.LoginInfo.FHSessionID)
            If BllResult.IsSuccess Then
                result.Links = BllResult.ReturnObject
            Else
                result.ErrorCode = -5
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : GetFolderLinks " & Now.ToString)
        Return result
    End Function

#Region "REPLICAS TO TEST ABOVE SERVICE METHODS"

    '<WebMethod(EnableSession:=True)> _
    '  Public Function Encrypt_Merchant2(ByVal CustomerID As Int64) As EncryptResult
    '    Dim result As New EncryptResult
    '    result.ErrorCode = 0
    '    result.ErrorDesc = "Operation Completed Successfully."

    '    System.Web.HttpContext.Current.Trace.Warn("START : Encrypt_Merchant " & Now.ToString)
    '    System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & CustomerID)


    '    Dim objBll As New AccountsCentre.BLL.AccountingTreeView
    '    Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.Encrypt_Merchant(CustomerID)
    '    If BllResult.IsSuccess Then
    '        result.AppendText = BllResult.ReturnObject
    '    Else
    '        result.ErrorCode = -2
    '        result.ErrorDesc = BllResult.ErrorDesc
    '    End If

    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
    '    System.Web.HttpContext.Current.Trace.Warn("END : Encrypt_Merchant " & Now.ToString)

    '    Return result
    'End Function

    '<WebMethod(EnableSession:=True)> _
    '    Public Function GetTreeView_Employee2(ByVal CompanyID As String, ByVal EmployeeID As String) As AccTreeViewResult
    '    Dim result As New AccTreeViewResult
    '    result.ErrorCode = 0
    '    result.ErrorDesc = "Operation Completed Successfully."
    '    result.AccTreeView = Nothing

    '    System.Web.HttpContext.Current.Trace.Warn("START : GetTreeView_Employee " & Now.ToString)
    '    System.Web.HttpContext.Current.Trace.Warn("CompanyID = " & CompanyID)
    '    System.Web.HttpContext.Current.Trace.Warn("EmployeeID = " & EmployeeID)

    '    If CompanyID Is Nothing OrElse Not IsNumeric(CompanyID) Then
    '        result.ErrorCode = -1
    '        result.ErrorDesc = "Invalid CustomerID."
    '    ElseIf EmployeeID Is Nothing OrElse EmployeeID.Length = 0 Then
    '        result.ErrorCode = -2
    '        result.ErrorDesc = "Invalid EmployeeID."
    '    Else
    '        Dim objBll As New AccountsCentre.BLL.AccountingTreeView
    '        Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetTreeView_Employee(CompanyID, EmployeeID)
    '        If BllResult.IsSuccess Then
    '            result.AccTreeView = BllResult.ReturnObject
    '        Else
    '            result.ErrorCode = -3
    '            result.ErrorDesc = BllResult.ErrorDesc
    '        End If
    '    End If

    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
    '    System.Web.HttpContext.Current.Trace.Warn("END : GetTreeView_Employee " & Now.ToString)

    '    Return result
    'End Function
    '<WebMethod(EnableSession:=True)> _
    'Public Function GetTreeView_Merchant2(ByVal CompanyID As String) As AccTreeViewResult
    '    Dim result As New AccTreeViewResult
    '    result.ErrorCode = 0
    '    result.ErrorDesc = "Operation Completed Successfully."
    '    result.AccTreeView = Nothing

    '    System.Web.HttpContext.Current.Trace.Warn("START : GetTreeView_Merchant " & Now.ToString)
    '    System.Web.HttpContext.Current.Trace.Warn("CompanyID = " & CompanyID)

    '    If CompanyID Is Nothing OrElse Not IsNumeric(CompanyID) Then
    '        result.ErrorCode = -1
    '        result.ErrorDesc = "Invalid CustomerID."
    '    Else
    '        Dim objBll As New AccountsCentre.BLL.AccountingTreeView
    '        Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetTreeView_Merchant(CompanyID)
    '        If BllResult.IsSuccess Then
    '            result.AccTreeView = BllResult.ReturnObject
    '        Else
    '            result.ErrorCode = -2
    '            result.ErrorDesc = BllResult.ErrorDesc
    '        End If
    '    End If

    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
    '    System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
    '    System.Web.HttpContext.Current.Trace.Warn("END : GetTreeView_Merchant " & Now.ToString)

    '    Return result
    'End Function

    '  <WebMethod(EnableSession:=True)> _
    '  Public Function GetAllowedFolderIDs2(ByVal CustomerID As String, ByVal EmployeeID As String, ByVal isMerchant As Boolean) As AllowedFoldersResult
    '      Dim result As New AllowedFoldersResult
    '      result.ErrorCode = 0
    '      result.ErrorDesc = "Operation Completed Successfully."

    '      System.Web.HttpContext.Current.Trace.Warn("START : GetAllowedFolderIDs " & Now.ToString)
    '      System.Web.HttpContext.Current.Trace.Warn("IsMerchant = " & isMerchant)
    '      System.Web.HttpContext.Current.Trace.Warn("CustomerID = " & CustomerID)
    '      System.Web.HttpContext.Current.Trace.Warn("EmployeeID = " & EmployeeID)

    '      If CustomerID Is Nothing OrElse Not IsNumeric(CustomerID) Then
    '          result.ErrorCode = -1
    '          result.ErrorDesc = "Invalid CustomerID."
    '      ElseIf Not isMerchant AndAlso (EmployeeID Is Nothing OrElse EmployeeID.Length = 0) Then
    '          result.ErrorCode = -2
    '          result.ErrorDesc = "Invalid EmployeeID."
    '      Else
    '          Dim objBll As New AccountsCentre.BLL.AccountingTreeView
    '          Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetAllowedFolders(CustomerID, EmployeeID, isMerchant)
    '          If BllResult.IsSuccess Then
    '              result.AllowedIDs = BllResult.ReturnObject
    '          Else
    '              result.ErrorCode = -3
    '              result.ErrorDesc = BllResult.ErrorDesc
    '          End If
    '      End If

    '      System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
    '      System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
    '      System.Web.HttpContext.Current.Trace.Warn("END : GetAllowedFolderIDs " & Now.ToString)
    '      Return result
    '  End Function

    '  <WebMethod(EnableSession:=True)> _
    'Public Function GetFolderLinks2(ByVal customerID As String, ByVal EmployeeID As String, ByVal isMerchant As Boolean, ByVal serviceID As String, ByVal modelID As String) As FolderLinksResult
    '      Dim result As New FolderLinksResult
    '      result.ErrorCode = 0
    '      result.ErrorDesc = "Operation Completed Successfully."

    '      System.Web.HttpContext.Current.Trace.Warn("START : GetFolderLinks " & Now.ToString)
    '      System.Web.HttpContext.Current.Trace.Warn("ServiceID = " & serviceID)
    '      System.Web.HttpContext.Current.Trace.Warn("ModelID = " & modelID)

    '      If customerID Is Nothing OrElse Not IsNumeric(customerID) Then
    '          result.ErrorCode = -1
    '          result.ErrorDesc = "Invalid CustomerID."
    '      ElseIf Not isMerchant AndAlso (EmployeeID Is Nothing OrElse EmployeeID.Length = 0) Then
    '          result.ErrorCode = -2
    '          result.ErrorDesc = "Invalid EmployeeID."
    '      ElseIf serviceID Is Nothing OrElse Not IsNumeric(serviceID) Then
    '          result.ErrorCode = -3
    '          result.ErrorDesc = "Invalid ServiceID."
    '      ElseIf modelID Is Nothing OrElse Not IsNumeric(modelID) Then
    '          result.ErrorCode = -4
    '          result.ErrorDesc = "Invalid ModelID"
    '      Else
    '          Dim objBll As New AccountsCentre.BLL.AccountingTreeView
    '          Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.GetFolderLinks(customerID, EmployeeID, isMerchant, serviceID, modelID)
    '          If BllResult.IsSuccess Then
    '              result.Links = BllResult.ReturnObject
    '          Else
    '              result.ErrorCode = -5
    '              result.ErrorDesc = BllResult.ErrorDesc
    '          End If
    '      End If

    '      System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
    '      System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
    '      System.Web.HttpContext.Current.Trace.Warn("END : GetFolderLinks " & Now.ToString)
    '      Return result
    '  End Function

#End Region

#Region "InfiniPlan Menu"


    <WebMethod(EnableSession:=True)> _
      Public Function GetBizPlanServices(ByVal LoginInfo As UserInfo) As String
        Dim str As String = Encrypt_MerchantAndEmployee(LoginInfo).AppendText
        Dim result As String

        result = "<upperparent text='InfiniPlan'>" _
        & "<parent0 text='Home' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=Home.aspx&config=" & str & "' />" _
        & "<parent1 text='Plan Manager' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=PlanManager.aspx&config=" & str & " ' /> " _
        & "<parent2 text='Speedometer Manager' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=" & str & "' />" _
        & "<parent3 text='Exported Plans' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=ExportedPlans.aspx&config=" & str & "' />" _
        & "<parent4 text='FAQs' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=FAQs.aspx&config=" & str & " ' /> " _
        & "</upperparent>"


        Return result
    End Function
#End Region

End Class

#Region "TreeView Structures"

Public Structure LoginInfo_Employee
    Dim CustomerID As String
    'Dim Password As String
    Dim EmployeeID As String
End Structure

Public Structure LoginInfo_Merchant
    Dim CustomerID As String
    'Dim Password As String
End Structure

Public Structure AccTreeViewResult
    Dim ErrorCode As Int16
    Dim ErrorDesc As String
    Dim AccTreeView As AccountsCentre.BLL.AccountingTreeView.AccTreeView
End Structure

Public Structure EncryptResult
    Dim ErrorCode As Int16
    Dim ErrorDesc As String
    Dim AppendText As String
End Structure

Public Structure UserInfo
    Dim CustomerID As String
    Dim EmployeeID As String
    Dim IsMerchant As Boolean
    Dim IoReturnURL As String
    Dim FHSessionID As String
End Structure

Public Structure AllowedFoldersResult
    Dim ErrorCode As Int16
    Dim ErrorDesc As String
    Dim AllowedIDs() As AccountsCentre.BLL.AccountingTreeView.FolderInfo
End Structure

Public Structure UserAndFolderInfo
    Dim LoginInfo As UserInfo
    Dim Finfo As AccountsCentre.BLL.AccountingTreeView.FolderInfo
End Structure

Public Structure FolderLinksResult
    Dim ErrorCode As Int16
    Dim ErrorDesc As String
    Dim Links() As AccountsCentre.BLL.AccountingTreeView.LinkInfo
End Structure

Public Structure BizPlanServicesResult
    Dim ErrorCode As Int16
    Dim ErrorDesc As String
    Dim BizPlanTreeViewXML As String
End Structure

Public Structure AccTreeView
    Dim Text As String
    Dim URL As String
    Dim Tabs() As TabInfo
    Dim ChildNodes() As AccTreeView
End Structure

Public Structure TabInfo
    Dim Title As String
    Dim Url As String
End Structure

#End Region
