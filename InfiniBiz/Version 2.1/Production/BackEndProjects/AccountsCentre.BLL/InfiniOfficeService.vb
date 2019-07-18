Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Web.Mail

Public Class InfiniOfficeService

#Region "User defined variables/constants"
    Const Referer As String = "Accounts Centre"
    Const InfiniHRProducCode As String = "237"
    Const InfiniShopProducCode As String = "104"
    Const ServiceURL As String = "http://services.crm.infinioffice.com/common.php?wsdl"
    Public Const EXTRA_SERVICES_HR_NAME As String = "HR"
    Public Const EXTRA_SERVICES_HR_TYPE As String = "1"
    Const IShopEmailTemplateName As String = "ISOP"
#End Region

#Region "Data Access Layer"
    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Function GetParentChildProfile(ByVal ChildID As Int64) As DataSet
        Try
            With New CommandData
                Dim oType As String = String.Empty
                .AddParameter("@CHILDID", ChildID)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_GetParentChildProfile"
                Dim dsData As DataSet
                dsData = .Execute(ExecutionType.ExecuteDataSet)
                ReplaceDbNullWithEmptyString(dsData)
                Return dsData
            End With
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.InfiniOfficeService.vb"" ""Function : GetParentChildProfile"" Description :" & ex.Message)
        End Try
    End Function

    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Sub InsertIOServiceErrorInDatabase(ByVal Referer As String, ByVal ChildID As Int64, ByVal MerchantID As String, ByVal ServiceMethod As String, ByVal Description As String, Optional ByVal ErrorFixed As Boolean = False)
        Try
            With New CommandData
                Dim oType As String = String.Empty
                .AddParameter("@REF", Referer)
                .AddParameter("@CHILDID", ChildID)
                .AddParameter("@MERCHANTID", MerchantID)
                .AddParameter("@SERVICEURL", ServiceURL)
                .AddParameter("@SERVICEMETHOD", ServiceMethod)
                .AddParameter("@ERRORDESC", Description)
                .AddParameter("@SUCCESS", ErrorFixed)
                .CmdText = "DbServer.InfiniShopMainDb.dbo.ACC_SetIOServiceError"
                .Execute(ExecutionType.ExecuteNonQuery)
            End With
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.InfiniOfficeService.vb"" ""Function : InsertIOServiceErrorInDatabase"" Description :" & ex.Message)
        End Try
    End Sub

    'Created by Muhammad Furqan Khan on 20th Sept 2006
    Private Function OrderInfo(ByVal OrderID As Integer) As DataSet
        Try
            Dim sqlParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            sqlParam(0) = New SqlClient.SqlParameter("@UID", SqlDbType.Int)
            sqlParam(0).Value = OrderID
            OrderInfo = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.DBO.ADMIN_OrderInformation", sqlParam)
            Return OrderInfo
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.InfiniOfficeService.vb"" ""Function : OrderInfo"" Description :" & ex.Message)
        End Try
    End Function

    'Created by Muhammad Furqan Khan on 21st Sept 2006
    Public Function DecryptPassword(ByVal LoginID As String, ByVal EncyptPassword As String) As Object
        Try
            Dim logKey As String = String.Empty
            Dim blnStatus As Boolean
            Dim ds As DataSet
            With New CommandData
                .AddParameter("@UserID", LoginID)
                .CmdText = "DBSERVER.InfinishopMainDB.DBO.ADMIN_VerifySignInGetLogKey"
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With
            If Not IsNothing(ds) AndAlso ds.Tables.Count > 0 Then
                Dim dr As DataRow = ds.Tables(0).Rows(0)
                If Not IsDBNull(dr.Item(1)) Then logKey = dr.Item(1)
            End If
            Dim objCryptography As New Cryptography
            Return objCryptography.EnCrypt(EncyptPassword, logKey)
        Catch ex As Exception
            Throw New Exception("Error in ""File : Bll.InfiniOfficeService.vb"" ""Function : DecryptPassword"" Description :" & ex.Message)
        End Try
    End Function
#End Region

    Public Shared Function IsCompanyNameAvailableForRegistration(ByVal ParentCustomerID As String, ByVal CompanyName As String) As IsCompanyNameAvailableResult
        Dim Result As New IsCompanyNameAvailableResult
        Dim IOService As New IOService_company.IOservices
        Dim CompanyInfo As New IOService_company.IsCompanyExistsData
        Dim CompanyExistsReturnMessage As IOService_company.IsCompanyExistsReturnMessage
        CompanyInfo.customerid = ParentCustomerID
        CompanyInfo.companyname = CompanyName
        CompanyExistsReturnMessage = IOService.IsCompanyExists(CompanyInfo)
        System.Web.HttpContext.Current.Trace.Write("CompanyExistsReturnMessage.ERRORCODE=" & CompanyExistsReturnMessage.ERRORCODE)
        System.Web.HttpContext.Current.Trace.Write("CompanyExistsReturnMessage.ERRORDESC=" & CompanyExistsReturnMessage.ERRORDESC)
        System.Web.HttpContext.Current.Trace.Write("CompanyExistsReturnMessage.GLOBALID=" & CompanyExistsReturnMessage.GLOBALID)

        If CompanyExistsReturnMessage.ERRORCODE <> 0 Then
            Result.IsAvailable = False
            Result.GlobalID = CompanyExistsReturnMessage.GLOBALID
        Else
            Result.IsAvailable = True
            Result.GlobalID = CompanyExistsReturnMessage.GLOBALID
        End If

        Return Result
    End Function

    'Created by Muhammad Furqan Khan on 20th Sept 2006
    Public Function CallIOServices(ByVal ChildID As String, ByVal OrderID As String) As String
        Dim GlobalCompanyID As String
        'Try
        Dim MerchantID As String = String.Empty
        Dim MerchantUID As String = String.Empty
        If Not IsNothing(ChildID) AndAlso ChildID.Trim <> String.Empty Then
            GlobalCompanyID = InformIOAboutNewMerchant(ChildID, MerchantID, MerchantUID)
            If Not IsNothing(OrderID) AndAlso OrderID.Trim <> String.Empty Then
                If IsInfiniHRAvailable(OrderID) Then
                    InformIOAboutNewHRProcess(ChildID, MerchantID, MerchantUID)
                End If
            End If
        End If

        'Catch ex As Exception

        'End Try
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Try
        If IsInfiniShopAvailable(OrderID) Then
            SendEmailToIShopCustomer(ChildID)
        End If
        'Catch ex As Exception
        'End Try

        Return GlobalCompanyID
    End Function

    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Sub InformIOAboutNewHRProcess(ByVal ChildID As String, ByVal MerchantID As String, ByVal MerchantUID As String)
        Dim ServiceMethod As String = "AddHRProcess"
        Try
            Dim MerchantPassword As String = String.Empty
            Dim drParentProfile As DataRow = GetParentChildProfile(ChildID).Tables(0).Rows(0)
            If MerchantID = String.Empty OrElse MerchantUID = String.Empty Then
                MerchantID = drParentProfile("customer_id")
                MerchantUID = drParentProfile("cart_customer_uid")
            End If
            MerchantPassword = DecryptPassword(MerchantUID, drParentProfile("cart_customer_pass"))
            Dim iowebservice As New com.infinioffice.crm.services.CRMservices
            Dim errorResponse As New com.infinioffice.crm.services.ErrorResponse
            Dim servicesInfo As New com.infinioffice.crm.services.ServicesInfo
            Dim extraServices(0) As com.infinioffice.crm.services.ExtraServices
            'errorResponse = iowebservice.AddHRProcess(MerchantID, MerchantUID, ChildID)
            ''''''''''set extraServices for serviceInfo''''''''''
            extraServices(0) = New com.infinioffice.crm.services.ExtraServices
            extraServices(0).serviceName = EXTRA_SERVICES_HR_NAME
            extraServices(0).serviceType = EXTRA_SERVICES_HR_TYPE
            '''''''''''''''''''''''''''''''''''''
            '''''''set serviceInfo''''''''''''
            servicesInfo.merchantId = MerchantID
            servicesInfo.merchantUid = MerchantUID
            servicesInfo.merchantPassword = MerchantPassword
            servicesInfo.childId = ChildID
            servicesInfo.extraServices = extraServices
            ''''''''''''''''''''''''''''''''''''
            errorResponse = iowebservice.AddProcesses(servicesInfo)

            If errorResponse.errorCode <> 0 Then
                SetIOServiceError(ChildID, MerchantID, ServiceMethod, "IO Service Error : " & errorResponse.errorCode & " - " & errorResponse.errorDesc, False, "HR Merchant ID not sent to IO DB due to some error.")
            Else
                SetIOServiceError(ChildID, MerchantID, ServiceMethod, String.Empty, True)
            End If
        Catch ex As Exception
            SetIOServiceError(ChildID, MerchantID, ServiceMethod, ex.Message, False, "HR Merchant ID not sent to IO DB due to some error.")
        End Try
    End Sub

    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Function InformIOAboutNewMerchant(ByVal ChildID As String, Optional ByRef MerchantID As String = "", Optional ByRef MerchantUID As String = "") As String
        Dim ServiceMethod As String = "AddMerchant"
        Dim GlobalCompanyID As String = "-1"
        Try
            Dim dsProfile As DataSet = GetParentChildProfile(ChildID)
            Dim drParentProfile As DataRow = dsProfile.Tables(0).Rows(0)
            Dim drChildProfile As DataRow = dsProfile.Tables(1).Rows(0)
            Dim IOwebservice As New com.infinioffice.crm.services.CRMservices
            Dim MerchantData As New com.infinioffice.crm.services.MerchantData
            Dim ErrorResponse As New com.infinioffice.crm.services.AddMerchantErrorResponse
            With MerchantData
                MerchantID = drParentProfile("customer_id")
                MerchantUID = drParentProfile("cart_customer_uid")
                .city = drParentProfile("town")         'in acc town/city are same
                .town = drParentProfile("town")
                .comments = drParentProfile("cart_customer_notes")
                .country = drParentProfile("country")      'in acc state/country are same
                .state = drParentProfile("country")
                .email = drParentProfile("cart_customer_email")
                .firstName = drParentProfile("name")
                .merchantId = drParentProfile("customer_id")
                .merchantPassword = DecryptPassword(MerchantUID, drParentProfile("cart_customer_pass"))
                .merchantUid = drParentProfile("cart_customer_uid")
                .postalCode = drParentProfile("postcode")
                .street = drParentProfile("street")
                .telephone = drParentProfile("telephone")
            End With
            Dim childCompanyName As String = drChildProfile("compname")
            Dim childLoginID As String = drChildProfile("cart_customer_uid")
            ErrorResponse = IOwebservice.AddMerchant(MerchantData, childCompanyName, ChildID, childLoginID)

            Web.HttpContext.Current.Trace.Write("ErrorResponse.errorCode = " & ErrorResponse.errorCode)
            Web.HttpContext.Current.Trace.Write("ErrorResponse.errorDesc = " & ErrorResponse.errorDesc)
            Web.HttpContext.Current.Trace.Write("ErrorResponse.globalId = " & ErrorResponse.globalId)

            If ErrorResponse.errorCode <= -1 Then
                SetIOServiceError(ChildID, MerchantID, ServiceMethod, "IO Service Error : " & ErrorResponse.errorCode & " - " & ErrorResponse.errorDesc, False)
            Else
                GlobalCompanyID = ErrorResponse.globalId
                System.Web.HttpContext.Current.Trace.Write("GlobalCompanyID = " & GlobalCompanyID)
                SetIOServiceError(ChildID, MerchantID, ServiceMethod, String.Empty, True)
            End If
        Catch ex As Exception
            SetIOServiceError(ChildID, MerchantID, ServiceMethod, ex.Message, False)
        End Try
        Return GlobalCompanyID
    End Function

    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Sub SetIOServiceError(ByVal ChildID As String, ByVal MerchantID As String, ByVal ServiceMethod As String, ByVal Description As String, ByVal IsSuccess As Boolean, Optional ByVal HRErrorSubject As String = "")
        Try
            InsertIOServiceErrorInDatabase(Referer, ChildID, MerchantID, ServiceMethod, Description, IsSuccess)
        Catch ex As Exception
            Description += "<br>Also, error was not logged in database because<br> " & ex.Message
        Finally
            If Not IsSuccess Then
                Dim errorFrom As String = ConfigReader.GetItem(ConfigVariables.SMTPUserID)
                Dim errorTo As String = "errors@infinibiz.com" ' "furqan@infinilogic.com"
                Dim errorSubject As String = String.Empty
                If HRErrorSubject = String.Empty Then
                    errorSubject = "Merchant ID not sent to IO DB due to some error."
                Else
                    errorSubject = HRErrorSubject
                End If
                Dim errorBody As String = "Following is the trace of error<br>"
                errorBody += "Merchant ID : " & ChildID & "<br>"
                errorBody += "Description : " & Description
                CommonBase.SendEmail(errorFrom, errorTo, errorSubject, errorBody, MailFormat.Html)
            End If
        End Try
    End Sub

    'Created by Muhammad Furqan Khan on 20th Sept 2006
    Private Function IsInfiniHRAvailable(ByVal OrderID As Long) As Boolean
        Dim dtOrderDetails As New DataTable
        dtOrderDetails = OrderInfo(OrderID).Tables(0)
        For Each drDetail As DataRow In dtOrderDetails.Rows
            If Not IsNothing(drDetail("ProductCode")) AndAlso CStr(drDetail("ProductCode")).Trim = InfiniHRProducCode Then
                Return True
            End If
        Next
        Return False
    End Function

    'Created by Muhammad Furqan Khan on 19th Sept 2006
    Private Sub ReplaceDbNullWithEmptyString(ByRef DsData As DataSet)
        If Not IsNothing(DsData) Then
            For Each dtdata As DataTable In DsData.Tables
                For Each drdata As DataRow In dtdata.Rows
                    Dim columns As Int32 = drdata.ItemArray.Length
                    For counter As Int32 = 0 To columns - 1
                        If IsDBNull(drdata(counter)) Then
                            drdata(counter) = String.Empty
                            On Error Resume Next
                        End If
                    Next
                Next
            Next
        End If
    End Sub

    'Created by Muhammad Furqan Khan on 08th Nov 2006
    Private Function IsInfiniShopAvailable(ByVal OrderID As Long) As Boolean
        Dim dtOrderDetails As New DataTable
        dtOrderDetails = OrderInfo(OrderID).Tables(0)
        For Each drDetail As DataRow In dtOrderDetails.Rows
            If Not IsNothing(drDetail("ProductCode")) AndAlso CStr(drDetail("ProductCode")).Trim = InfiniShopProducCode Then
                Return True
            End If
        Next
        Return False
    End Function

    'Created by Muhammad Furqan Khan on 08th Nov 2006
    Private Sub SendEmailToIShopCustomer(ByVal ChildID As String)
        ''''''' get customer profile '''''''''''''
        'Dim dsProfile As DataSet = GetParentChildProfile(ChildID)
        'Dim drChildProfile As DataRow = dsProfile.Tables(1).Rows(0)
        'Dim childName As String = drChildProfile("name")
        'Dim childLoginID As String = drChildProfile("cart_customer_uid")
        'Dim childPassword As String = DecryptPassword(childLoginID, drChildProfile("cart_customer_pass"))
        'Dim childEmail As String = drChildProfile("cart_customer_email")

        ''''''' prepare email template and send ''''''''
        'Dim objTemplate As New TemplateReader
        'Dim dsEmailContent As DataSet
        'Dim strEmailTemplate, strImageURL As String
        'Dim strTemplateSubject As String, intActive As Integer

        'dsEmailContent = objTemplate.SelectEmailContent(IShopEmailTemplateName)
        'strEmailTemplate = dsEmailContent.Tables(0).Rows(0).Item("content")
        'strTemplateSubject = dsEmailContent.Tables(0).Rows(0).Item("Subject")

        'Dim strbuilder As New System.Text.StringBuilder(strEmailTemplate)
        'strbuilder.Replace("[Name]", childName).ToString()
        'strbuilder.Replace("[User ID]", childLoginID).ToString()
        'strbuilder.Replace("[Password]", childPassword).ToString()
        'Dim strBody As String = strbuilder.ToString
        'Dim strBCC As String = ConfigReader.GetItem(ConfigVariables.EmailBCC)
        'Dim strFrom As String = ConfigReader.GetItem(ConfigVariables.SMTPUserID)

        'If CommonBase.SendEmail(strFrom, childEmail, strTemplateSubject, strBody, MailFormat.Html, strBCC) = "" Then
        '    EmailManager.CreatDBLog(ChildID, IShopEmailTemplateName, strbuilder.ToString, childName, childEmail, strTemplateSubject, strFrom, True)
        'Else
        '    EmailManager.CreatDBLog(ChildID, IShopEmailTemplateName, strbuilder.ToString, childName, childEmail, strTemplateSubject, strFrom, False)
        'End If
    End Sub

    Public Structure IsCompanyNameAvailableResult
        Public IsAvailable As Boolean
        Public GlobalID As String
    End Structure
End Class

