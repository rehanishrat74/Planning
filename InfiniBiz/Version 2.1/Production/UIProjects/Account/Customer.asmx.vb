#Region "Libraries"
Imports System.Web.Services
Imports System.Data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Collections.Specialized
Imports Administration.BLL
#End Region
<System.Web.Services.WebService(Namespace:="http://tempuri.org/accounts.infinibiz.Web/Customer")> _
Public Class Customer
    Inherits System.Web.Services.WebService
    Private Page_Base As New PageBase

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

    <WebMethod(CacheDuration:=90)> _
    Public Function getCustomerInfo(ByVal info() As customerInfo) As customerInfoResult
        System.Web.HttpContext.Current.Trace.Warn("getCustomerInfo START")

        If info Is Nothing OrElse info.Length = 0 Then
            System.Web.HttpContext.Current.Trace.Warn("info can't be null")
            Dim objcustomerInfoResult As New customerInfoResult
            objcustomerInfoResult.ERRORCODE = -15
            objcustomerInfoResult.ERRORDESC = "info can't be null"
            HttpContext.Current.Trace.Warn("ERRORCODE=" & objcustomerInfoResult.ERRORCODE)
            HttpContext.Current.Trace.Warn("ERRORDESC=" & objcustomerInfoResult.ERRORDESC)
            Return objcustomerInfoResult
        End If

        '---------For Tracing purpose---------Start
        For i As Integer = 0 To info.Length - 1
            System.Web.HttpContext.Current.Trace.Warn("customerID=" & info(i).customerID & " - refferID=" & info(i).refferID & " - productCode=" & info(i).productCode & " - quantity=" & info(i).quantity & " - entityID=" & info(i).entityID & " - globalCompanyID=" & info(i).globalCompanyID)
            If info(i).customerID = "" Then
                Dim objcustomerInfoResult As New customerInfoResult
                objcustomerInfoResult.ERRORCODE = -16
                objcustomerInfoResult.ERRORDESC = "info(" & i & ").customerID can't be empty"
                HttpContext.Current.Trace.Warn("ERRORCODE=" & objcustomerInfoResult.ERRORCODE)
                HttpContext.Current.Trace.Warn("ERRORDESC=" & objcustomerInfoResult.ERRORDESC)

                Return objcustomerInfoResult
            End If
            If info(i).refferID = "" Then
                Dim objcustomerInfoResult As New customerInfoResult
                objcustomerInfoResult.ERRORCODE = -17
                objcustomerInfoResult.ERRORDESC = "info(" & i & ").refferID can't be empty"
                HttpContext.Current.Trace.Warn("ERRORCODE=" & objcustomerInfoResult.ERRORCODE)
                HttpContext.Current.Trace.Warn("ERRORDESC=" & objcustomerInfoResult.ERRORDESC)

                Return objcustomerInfoResult
            End If
            If info(i).productCode = "" Then
                Dim objcustomerInfoResult As New customerInfoResult
                objcustomerInfoResult.ERRORCODE = -18
                objcustomerInfoResult.ERRORDESC = "info(" & i & ").productCode can't be empty"
                HttpContext.Current.Trace.Warn("ERRORCODE=" & objcustomerInfoResult.ERRORCODE)
                HttpContext.Current.Trace.Warn("ERRORDESC=" & objcustomerInfoResult.ERRORDESC)

                Return objcustomerInfoResult
            End If
        Next
        '---------For Tracing purpose---------End

        Dim sCustomerID As New System.Collections.Stack
        Dim sReferrer As New System.Collections.Stack
        Dim sProductCode As New System.Collections.Stack
        Dim sQuantity As New System.Collections.Stack
        Dim sEntityID As New System.Collections.Stack
        Dim sGlobalCompanyID As New System.Collections.Stack

        Dim APIResellerCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("APIResellerCodeList")
        System.Web.HttpContext.Current.Trace.Warn("APIResellerCodeList = " & APIResellerCodeList)
        Dim ResellerProCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("ResellerProCodeList")
        System.Web.HttpContext.Current.Trace.Warn("ResellerProCodeList  = " & ResellerProCodeList)
        'Dim InfinishopMerchatCodeList As String = System.Configuration.ConfigurationSettings.AppSettings("InfinishopMerchatCodeList")
        'System.Web.HttpContext.Current.Trace.Warn("InfinishopMerchatCodeList  = " & InfinishopMerchatCodeList)

        Dim ResellerProCode_Or_ProPlusCode_Available As Boolean = False
        Dim APIResellerCode_Available As Boolean = False
        Dim Infinishop_Available As Boolean = False
        Dim AC_Referrer_Code = "1009" 'AC referrer code

        ''Updated by MFK 16 JAN 2007 to add customerid in result
        Dim R_CustomerID As String = String.Empty

        For i As Integer = 0 To info.Length - 1

            If IsProductCodeAvailable(info(i).productCode, ResellerProCodeList) Then
                sReferrer.Push(info(i).refferID)
                sCustomerID.Push(info(i).customerID)
                sProductCode.Push(info(i).productCode)
                sQuantity.Push(info(i).quantity)
                sEntityID.Push(info(i).entityID)
                sGlobalCompanyID.Push(info(i).globalCompanyID)

                sReferrer.Push(AC_Referrer_Code)  'Adding AC referrer code
                sCustomerID.Push(info(i).customerID)
                sProductCode.Push(info(i).productCode)
                sQuantity.Push(info(i).quantity)
                sEntityID.Push(info(i).entityID)
                sGlobalCompanyID.Push(info(i).globalCompanyID)

                ResellerProCode_Or_ProPlusCode_Available = True
            ElseIf IsProductCodeAvailable(info(i).productCode, APIResellerCodeList) Then

                sReferrer.Push(info(i).refferID)
                sCustomerID.Push(info(i).customerID)
                sProductCode.Push(info(i).productCode)
                sQuantity.Push(info(i).quantity)
                sEntityID.Push(info(i).entityID)
                sGlobalCompanyID.Push(info(i).globalCompanyID)
                APIResellerCode_Available = True
            ElseIf Merchant.IsInfiniShopAvailable_Package(info(i).productCode) Then
                sReferrer.Push(info(i).refferID)
                sCustomerID.Push(info(i).customerID)
                sProductCode.Push(info(i).productCode)
                sQuantity.Push(info(i).quantity)
                sEntityID.Push(info(i).entityID)
                sGlobalCompanyID.Push(info(i).globalCompanyID)
                Infinishop_Available = True
            Else
                'New Modification
                sReferrer.Push(info(i).refferID)
                sCustomerID.Push(info(i).customerID)
                sProductCode.Push(info(i).productCode)
                sQuantity.Push(info(i).quantity)
                sEntityID.Push(info(i).entityID)
                sGlobalCompanyID.Push(info(i).globalCompanyID)
            End If
            If R_CustomerID Is String.Empty Then
                R_CustomerID = info(i).customerID
            End If
        Next

        'API Reseller(528): RefferID: 1012
        'Reseller Pro(529): RefferID: 1005
        'Reseller Pro Plus(530): RefferID: 1005
        If Not APIResellerCode_Available Then
            If ResellerProCode_Or_ProPlusCode_Available Then
                sReferrer.Push("1012")
                sCustomerID.Push(R_CustomerID)    'this id was previously blank("") and is updated by MFK on 16 Jan 2007
                sProductCode.Push("3094")
                sQuantity.Push("1")
                sEntityID.Push("-1")
                sGlobalCompanyID.Push("-1")

                'sReferrer.Push("1002")
                'sCustomerID.Push(R_CustomerID)    'Add referer of Virtual Office
                'sProductCode.Push("3094")
                'sQuantity.Push("1")
            ElseIf Not ResellerProCode_Or_ProPlusCode_Available AndAlso Infinishop_Available Then
                'if Reseller Pro/ProPlus is not available and 
                'Infinishop is available then show Website Admin

                If R_CustomerID <> "26" Then
                    sReferrer.Push("1005")
                    sCustomerID.Push(R_CustomerID)
                    sProductCode.Push("526")
                    sQuantity.Push("1")
                    sEntityID.Push("-1")
                    sGlobalCompanyID.Push("-1")
                End If

                'sReferrer.Push("1002")
                'sCustomerID.Push(R_CustomerID)    'Add referer of Virtual Office
                'sProductCode.Push("3094")
                'sQuantity.Push("1")
            End If
        End If


        Dim TotalRec As Integer = sReferrer.Count - 1
        Dim SepcialCase_PHP As Boolean = False
        If TotalRec = 0 Then
            TotalRec += 1
            SepcialCase_PHP = True
        End If

        Dim Result(TotalRec) As customerInfo
        System.Web.HttpContext.Current.Trace.Warn("Result Values:")
        For i As Integer = 0 To TotalRec
            If SepcialCase_PHP AndAlso i = 1 Then
                Result(i) = New customerInfo
                Result(i).refferID = Result(0).refferID
                Result(i).customerID = Result(0).customerID
                Result(i).productCode = Result(0).productCode
                Result(i).quantity = Result(0).quantity
                Result(i).entityID = Result(0).entityID
                Result(i).globalCompanyID = Result(0).globalCompanyID
            Else
                Result(i) = New customerInfo
                Result(i).refferID = sReferrer.Pop
                Result(i).customerID = sCustomerID.Pop
                Result(i).productCode = sProductCode.Pop
                Result(i).quantity = sQuantity.Pop
                Result(i).entityID = sEntityID.Pop
                Result(i).globalCompanyID = sGlobalCompanyID.Pop
            End If
            System.Web.HttpContext.Current.Trace.Warn("customerID=" & Result(i).customerID & " - refferID=" & Result(i).refferID & " - productCode=" & Result(i).productCode & " - quantity=" & Result(i).quantity & " - entityID=" & Result(i).entityID & " - globalCompanyID=" & Result(i).globalCompanyID)
        Next
        Dim cInfoResult As New customerInfoResult
        cInfoResult.ERRORCODE = "0"
        cInfoResult.ERRORDESC = "Operation Completed Successfully"
        cInfoResult.info = Result


        System.Web.HttpContext.Current.Trace.Warn("getCustomerInfo END")
        Return cInfoResult
    End Function

    Private Function IsProductCodeAvailable(ByVal ProductCode As String, _
                                           ByVal ProductCodeList As String) As Boolean
        Dim ProductCodeListArray() As String = ProductCodeList.Split(New Char() {","})
        For Each Item As String In ProductCodeListArray
            If Item.ToUpper = ProductCode.ToUpper Then
                Return True     'ProductCode found!
            End If
        Next
        Return False            'ProductCode not found!
    End Function

    'Public Shared Function IsInfiniShopAvailable_Package(ByVal PackageCode As String) As Boolean
    '    Dim Result As Boolean
    '    Dim HList As Hashtable = HttpContext.Current.Application("IsInfiniShopAvailable_Package_HashTable")

    '    'If Hashtable not found the create a new instance
    '    If HList Is Nothing Then
    '        HttpContext.Current.Trace.Write("HList is Nothing")
    '        HList = New Hashtable
    '    Else
    '        HttpContext.Current.Trace.Write("HList is not Nothing")
    '    End If

    '    'If PackageCode not found in Hashtable then add it
    '    If Not HList.Contains(PackageCode) Then
    '        HttpContext.Current.Trace.Write("PackageCode (" & PackageCode & ") not found in HList")

    '        HttpContext.Current.Trace.Write("Calling IsInfiniShopAvailable_Package")
    '        Dim IsAvailable As Boolean = Merchant.IsInfiniShopAvailable_Package(PackageCode)
    '        HttpContext.Current.Trace.Write("IsInfiniShopAvailable_Package is ok")

    '        HList.Add(PackageCode, IsAvailable)
    '    End If

    '    Result = HList(PackageCode)

    '    HttpContext.Current.Trace.Write("Result = " & Result)
    '    Return Result
    'End Function

    '''----------------------------------------------------------------------------------
    ''' Project  : CustomerProcessing_Proj
    ''' Class  : CustomerProcessing
    '''----------------------------------------------------------------------------------
    '''----------------------------------------------------------------------------------
    '''<summary>
    '''    This is a WebMethod.
    '''</summary>
    '''<param name="productinfo"></param>
    '''<returns>getActivationInfoResult </returns>
    '''<remarks>
    '''</remarks>
    '''<history>
    '''	[win.yousuf]	22/05/2006 Created
    ''' [win.yousuf]    25/05/2006 Modify
    ''' [win.yousuf]    11/12/2006 Modify
    '''</history>
    '''----------------------------------------------------------------------------------
    <WebMethod(enableSession:=True)> _
    Public Function getActivationInfo(ByVal productinfo As activationinfo) As getActivationInfoResult
        Dim logUniquePath As String = "d:\CustomerProcessing Trace\" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Dim FileName As String = "getActivationInfo.txt"

        WriteDebugInfo("getActivationInfo is called with parameters:", logUniquePath, FileName)
        WriteDebugInfo("    CustomerID:" & productinfo.customerid, logUniquePath, FileName)
        WriteDebugInfo("    ProductCode:" & productinfo.productcode, logUniquePath, FileName)
        WriteDebugInfo("    OrderNo:" & productinfo.orderno, logUniquePath, FileName)
        WriteDebugInfo("    SerialNo:" & productinfo.serialno, logUniquePath, FileName)
        WriteDebugInfo("    Language:" & productinfo.language, logUniquePath, FileName)
        WriteDebugInfo("    Serviceid:" & productinfo.serviceid, logUniquePath, FileName)

        Dim RESULT As New getActivationInfoResult
        Try
            Dim ResellerID As String = ""
            '---------------Trim OrderNo----------Start
            'Modified by:   M.Yousuf
            'Date:          Feb 22, 2007
            'Description:   OrderID can be duplicate so from now it will concatenate with
            '               reseller id and length of resellerid
            'Example:       112606       5295     06
            '               ------       ----     --
            '               ResellerID   OrderID  Len(ResellerID's Length)
            '
            '               Last two digits show the length of Resellerid
            '               which is: 112606
            '               remaining digits are orderid: 5295
            Dim LongOrderID As String = System.Configuration.ConfigurationSettings.AppSettings("LongOrderID")
            WriteDebugInfo("LongOrderID=" & LongOrderID, logUniquePath, FileName)
            If LongOrderID = "1" Then
                WriteDebugInfo("New FH OrderID format found!", logUniquePath, FileName)
                Dim ResellerIDLength As Integer = productinfo.orderno.Substring(productinfo.orderno.Length - 2)
                ResellerID = productinfo.orderno.Substring(0, ResellerIDLength)
                HttpContext.Current.Trace.Write("ResellerID=" & ResellerID)
                productinfo.orderno = productinfo.orderno.Substring(ResellerIDLength, productinfo.orderno.Length - ResellerIDLength - 2)
                HttpContext.Current.Trace.Write("OrderNo==" & productinfo.orderno)

                'Check that this activation is new 
                Dim objIsServiceActivatedResult As New BizAPI_Service.IsOrderActivatedResult
                objIsServiceActivatedResult = BizAPI_Service.IsOrderActivated(ResellerID, productinfo.orderno, productinfo.productcode, productinfo.serialno)
                If objIsServiceActivatedResult.ServiceAlreadyActivated Then
                    Dim ECD As New getActivationInfoResult
                    ECD.ERRORCODE = -20
                    ECD.link = ""
                    ECD.variablename = ""
                    ECD.value = ""
                    ECD.ERRORDESC = "This product already activated with provided serial number"

                    Try
                        WriteDebugInfo("customerid=" & productinfo.customerid & ECD.ERRORDESC, logUniquePath, FileName)
                        WriteDebugInfo("productcode=" & productinfo.productcode & ECD.ERRORDESC, logUniquePath, FileName)
                        WriteDebugInfo("orderno=" & productinfo.orderno & ECD.ERRORDESC, logUniquePath, FileName)
                        WriteDebugInfo("serialno=" & productinfo.serialno & ECD.ERRORDESC, logUniquePath, FileName)
                    Catch ex As Exception
                    End Try
                    Return ECD
                End If
            End If
            '---------------Trim OrderNo----------End

            '------------------------Validation of Input parameter------------------------
            Dim valid As New Validation
            Dim ErrCode As Integer
            WriteDebugInfo("Validate Calling", logUniquePath, FileName)
            ErrCode = valid.Validate(productinfo.customerid _
                                    , productinfo.productcode _
                                    , productinfo.orderno _
                                    , productinfo.serialno _
                                    , productinfo.language)
            WriteDebugInfo("Validate is ok with ErrCode=" & ErrCode, logUniquePath, FileName)

            WriteDebugInfo("Calling ClearParentSelfEntry", logUniquePath, FileName)
            Infinilogic.AccountsCentre.BLL.User.ClearParentSelfEntry(productinfo.customerid)
            WriteDebugInfo("ClearParentSelfEntry is ok", logUniquePath, FileName)

            If ErrCode > 0 Then

                Dim ECD As New getActivationInfoResult
                ECD.ERRORCODE = ErrCode
                ECD.link = ""
                ECD.variablename = ""
                ECD.value = ""

                Select Case ErrCode
                    Case "0"
                        ECD.ERRORDESC = "Success."
                    Case "10"
                        ECD.ERRORDESC = """CustomerID"" not found OR invalid format."
                    Case "11"
                        ECD.ERRORDESC = """ProductCode"" not found OR invalid format."
                    Case "12"
                        ECD.ERRORDESC = """OrderNo"" not found OR invalid format."
                    Case "13"
                        ECD.ERRORDESC = """SerialNo"" invalid format."
                    Case Else
                        ECD.ERRORDESC = "Unknown Error Found."
                End Select

                WriteDebugInfo("ECD.ERRORDESC = " & ECD.ERRORDESC, logUniquePath, FileName)
                Try
                    WriteDebugInfo("customerid=" & productinfo.customerid & ECD.ERRORDESC, logUniquePath, FileName)
                    WriteDebugInfo("productcode=" & productinfo.productcode & ECD.ERRORDESC, logUniquePath, FileName)
                    WriteDebugInfo("orderno=" & productinfo.orderno & ECD.ERRORDESC, logUniquePath, FileName)
                    WriteDebugInfo("serialno=" & productinfo.serialno & ECD.ERRORDESC, logUniquePath, FileName)
                Catch ex As Exception
                End Try
                Return ECD
            End If
            '------------------------------------done--------------------------------------

            '--------------------Manage Session Start-------------------------
            WriteDebugInfo("Session.SessionID=" & Session.SessionID, logUniquePath, FileName)
            Dim SessionID As String = Session.SessionID
            Dim loginid As String
            Dim customerid As String = productinfo.customerid
            WriteDebugInfo("customerid = " & customerid, logUniquePath, FileName)

            '--------------------
            WriteDebugInfo("Calling GetCustomerLoginID -- customerID=" & productinfo.customerid, logUniquePath, FileName)
            loginid = Infinilogic.AccountsCentre.BLL.User.GetCustomerUID(customerid)
            WriteDebugInfo("done. loginid=" & loginid, logUniquePath, FileName)
            '--------------------

            Dim password As String
            Dim logkey As String
            Dim objUser As New Infinilogic.AccountsCentre.BLL.User
            Dim strGKey, strLogKey, strDatabaseName, cid As String
            Dim strshort As Short
            Dim bl As Boolean
            WriteDebugInfo("calling VerifySignIn", logUniquePath, FileName)
            objUser.VerifySignIn(loginid, password, cid, logkey, strshort, strDatabaseName, bl)
            WriteDebugInfo("test", logUniquePath, FileName)
            WriteDebugInfo("VerifySignIn is ok", logUniquePath, FileName)
            Dim crypt As New Infinilogic.AccountsCentre.common.Cryptography
            password = crypt.DeCrypt(password, logkey)
            WriteDebugInfo("Password=" & password, logUniquePath, FileName)


            Dim objSecureQueryString As New SecureQueryString
            'WriteDebugInfo("calling GetCustomerLoginID", logUniquePath, FileName)
            'loginid = ServicesManager.GetCustomerLoginID(customerid)
            'WriteDebugInfo("done!", logUniquePath, FileName)

            With objSecureQueryString
                .Add("UserID", loginid)
                .Add(PageTemplate.ACC_SessionID, SessionID)
                .Add("serviceid", productinfo.serviceid)
                .Add("Password", password)
                .Add("ResellerID", ResellerID)
                .ExpireTime = Now.AddSeconds(60)
                RESULT.ERRORCODE = "0"
                RESULT.ERRORDESC = "Opperation successful"
                Dim myData As String = productinfo.customerid & "^" & productinfo.productcode & "^" & productinfo.orderno & "^" & productinfo.serialno & "^" & productinfo.language
                .Add("detail", myData)

                'RESULT.link = CommonBase.Resources(ACC_Resource.ACC_AUTOLOGIN) & "?q=" & objSecureQueryString.ToString() '& "&detail=" & myData
                RESULT.link = "https://" & HttpContext.Current.Request.Url.Host & "/Account/DoLogin.aspx?q=" & objSecureQueryString.ToString()   '& "&detail=" & myData
                
                RESULT.variablename = "sid"
                RESULT.value = SessionID

                SignIn(SessionID, loginid)
            End With
            '--------------------Manage Session End-------------------------

            Dim detail As String

            WriteDebugInfo("getActivationInfo is end with Result:!", logUniquePath, FileName)
            WriteDebugInfo("    ERRORCODE=" & RESULT.ERRORCODE, logUniquePath, FileName)
            WriteDebugInfo("    ERRORDESC=" & RESULT.ERRORDESC, logUniquePath, FileName)
            WriteDebugInfo("    LINK=" & RESULT.link, logUniquePath, FileName)
            WriteDebugInfo("    VARIABLENAME=" & RESULT.variablename, logUniquePath, FileName)
            WriteDebugInfo("    VALUE=" & RESULT.value, logUniquePath, FileName)
        Catch ex As Exception
            WriteDebugInfo("EXCEPTION", logUniquePath, FileName)
            WriteDebugInfo("Message:" & ex.Message, logUniquePath, FileName)
            WriteDebugInfo("Source:" & ex.Source, logUniquePath, FileName)
            WriteDebugInfo("StackTrace:" & ex.StackTrace, logUniquePath, FileName)
            If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
                System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\EXCEPTION CustomerProcessing.asmx.vb Trace.txt")
            sw.WriteLine(Now & " -- " & "EXCEPTION")
            sw.WriteLine(Now & " -- " & "Message:" & ex.Message)
            sw.WriteLine(Now & " -- " & "Source:" & ex.Source)
            sw.WriteLine(Now & " -- " & "Source:" & ex.StackTrace)
            sw.Flush()
            sw.WriteLine("orderno=" & productinfo.orderno)
            sw.WriteLine("customerid=" & productinfo.customerid)
            sw.Close()

            Dim ECD1 As New getActivationInfoResult
            ECD1.ERRORCODE = 1
            ECD1.ERRORDESC = ex.Message & " - " & ex.StackTrace
            ECD1.link = ""
            ECD1.variablename = ""
            ECD1.value = ""
            Return ECD1
        End Try
        Return RESULT
    End Function

    '''----------------------------------------------------------------------------------
    ''' Project  : CustomerProcessing_Proj
    ''' Class  : CustomerProcessing
    ''' 
    '''----------------------------------------------------------------------------------
    '''<summary>
    '''    This is a WebMethod.
    '''</summary>
    '''<param name="CustomerID"></param>
    '''<param name="ProductCode"></param>
    '''<param name="OrderNo"></param>
    '''<param name="SerialNo"></param>
    '''<param name="Language"></param>
    '''<param name="CompanyName"></param>
    '''<returns>Return One Dimesional Array (0)=ErrCode, (1)=Description</returns>
    '''<remarks>
    '''</remarks>
    '''<history>
    '''	[win.yousuf]	22/05/2006 Created
    '''</history>
    '''----------------------------------------------------------------------------------
    '<WebMethod(enableSession:=True)> _
    'Public Function activate(ByVal CustomerID As Integer _
    '                                , ByVal ProductCode As String _
    '                                , ByVal OrderNo As Integer _
    '                                , ByVal SerialNo As Integer _
    '                                , ByVal Language As String _
    '                                , ByVal CompanyName As String) As activateResult
    '    Dim logUniquePath As String = "d:\CustomerProcessing Trace\" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
    '    Dim FileName As String = "activate.txt"

    '    Try
    '        WriteDebugInfo("CustomerID=" & CustomerID, logUniquePath, FileName, True)
    '        WriteDebugInfo("ProductCode=" & ProductCode, logUniquePath, FileName, True)
    '        WriteDebugInfo("OrderNo=" & OrderNo, logUniquePath, FileName, True)
    '        WriteDebugInfo("SerialNo=" & SerialNo, logUniquePath, FileName, True)
    '        WriteDebugInfo("Language=" & Language, logUniquePath, FileName, True)
    '        WriteDebugInfo("CompanyName=" & CompanyName, logUniquePath, FileName, True)
    '        '------------------------Validation of Input parameter------------------------
    '        Dim valid As New Validation
    '        Dim ErrCode As Integer
    '        WriteDebugInfo("Validate Calling", logUniquePath, FileName, True)
    '        ErrCode = valid.Validate(CustomerID, ProductCode, OrderNo, SerialNo, Language)
    '        WriteDebugInfo("Validate is ok with ErrCode=" & ErrCode, logUniquePath, FileName, True)
    '        If ErrCode > 0 Then
    '            WriteDebugInfo(Now & " -- Input Parameters:", logUniquePath, FileName, True)
    '            WriteDebugInfo(Now & " --     CustomerID=" & CustomerID, logUniquePath, FileName, True)
    '            WriteDebugInfo(Now & " --     ProductCode=" & ProductCode, logUniquePath, FileName, True)
    '            WriteDebugInfo(Now & " --     OrderNo=" & OrderNo, logUniquePath, FileName, True)
    '            WriteDebugInfo(Now & " --     SerialNo=" & SerialNo, logUniquePath, FileName, True)
    '            WriteDebugInfo(Now & " --     Language=" & Language, logUniquePath, FileName, True)
    '            Return ErrCodeAndDescription(ErrCode)
    '        End If
    '        '------------------------------------done--------------------------------------

    '        Dim processor As New DataProcessor(logUniquePath)
    '        Dim NewCustomerID As Integer
    '        Dim Success As Boolean

    '        '-------------------------------------------------------------------------------
    '        Dim sCustomerAction As String = ""
    '        Dim oACRegBLL As New ACRegistrationBLL
    '        Dim dtACUByID As DataTable
    '        WriteDebugInfo("Calling GetACUserRecordByID", logUniquePath, FileName, True)
    '        dtACUByID = oACRegBLL.GetACUserRecordByID(CustomerID)
    '        WriteDebugInfo("GetACUserRecordByID is ok", logUniquePath, FileName, True)

    '        If (Not InfiniLogic.AccountsCentre.BLL.User.IsAvailableInACCustomerGrouping(CustomerID)) OrElse (dtACUByID Is Nothing OrElse Not (dtACUByID.Rows.Count > 0)) Then
    '            'Register New Customer and make it AccountsCentreUser
    '            WriteDebugInfo("CreateSubCustomer is calling", logUniquePath, FileName, True)
    '            NewCustomerID = processor.CreateSubCustomer(CustomerID)
    '            WriteDebugInfo("CreateSubCustomer is ok and NewCustomerID=" & NewCustomerID, logUniquePath, FileName, True)

    '            WriteDebugInfo("Calling AddAccountsCentreUser", logUniquePath, FileName, True)
    '            InfiniLogic.AccountsCentre.BLL.User.AddAccountsCentreUser(NewCustomerID, CompanyName)
    '            WriteDebugInfo("AddAccountsCentreUser is ok", logUniquePath, FileName, True)

    '            Try
    '                WriteDebugInfo("Calling AddAccountsCentreGrouping", logUniquePath, FileName, True)
    '                InfiniLogic.AccountsCentre.BLL.User.AddAccountsCentreGrouping(CustomerID, NewCustomerID)
    '                WriteDebugInfo("AddAccountsCentreGrouping is ok", logUniquePath, FileName, True)
    '            Catch ex As Exception
    '                WriteDebugInfo("EXCEPTION::", logUniquePath, FileName, True)
    '                WriteDebugInfo("    Message:: " & ex.Message, logUniquePath, FileName, True)
    '                WriteDebugInfo("    Source:: " & ex.Source, logUniquePath, FileName, True)
    '            End Try

    '            WriteDebugInfo("Calling AddResellerCustomersDetail", logUniquePath, FileName, True)
    '            InfiniLogic.AccountsCentre.BLL.User.AddResellerCustomersDetail(CustomerID, NewCustomerID)
    '            WriteDebugInfo("AddResellerCustomersDetail is ok", logUniquePath, FileName, True)
    '        Else
    '            WriteDebugInfo("Found AccountsCentreUser or AccountsCentreCustomerGrouping Record!!", logUniquePath, FileName, True)
    '            NewCustomerID = CustomerID
    '            CustomerID = InfiniLogic.AccountsCentre.BLL.User.GetParentID(NewCustomerID)
    '        End If
    '        '-------------------------------------------------------------------------------

    '        WriteDebugInfo("MapCustomerSelectedService is calling:", logUniquePath, FileName, True)
    '        WriteDebugInfo("    ChildCustomerID=" & NewCustomerID, logUniquePath, FileName, True)
    '        WriteDebugInfo("    ProductCode=" & ProductCode, logUniquePath, FileName, True)
    '        WriteDebugInfo("    OrderNo=" & OrderNo, logUniquePath, FileName, True)
    '        Success = processor.MapCustomerSelectedService(NewCustomerID, ProductCode, OrderNo)
    '        WriteDebugInfo("MapCustomerSelectedService is ok and return = " & Success, logUniquePath, FileName, True)

    '        '--------------------------------Inform To FH----------------------------------
    '        WriteDebugInfo("Create IBZservices Object", logUniquePath, FileName, True)
    '        Dim FHService As New FHResellerCustomer.IBZservices
    '        WriteDebugInfo("done!", logUniquePath, FileName, True)
    '        WriteDebugInfo("Set Activation Info", logUniquePath, FileName, True)

    '        WriteDebugInfo("CustomerID=" & CustomerID, logUniquePath, FileName, True)
    '        WriteDebugInfo("OrderNo=" & OrderNo, logUniquePath, FileName, True)
    '        WriteDebugInfo("NewCustomerID=" & NewCustomerID, logUniquePath, FileName, True)
    '        WriteDebugInfo("CompanyName=" & CompanyName, logUniquePath, FileName, True)

    '        Dim ActivationInfo As New FHResellerCustomer.activationinfo
    '        ActivationInfo.customerid = CustomerID
    '        ActivationInfo.orderno = OrderNo
    '        ActivationInfo.entityid = NewCustomerID
    '        ActivationInfo.entityname = CompanyName
    '        ''Updated by MFK on 12 JAN 2007 to vary referrer according to productcode
    '        Select Case ProductCode
    '            Case "528", "529"   'for resellerpro, resellerpro-plus referer is 1005
    '                ActivationInfo.referrer = "1005"
    '            Case "530"   'for api reseller referer is 1012
    '                ActivationInfo.referrer = "1012"
    '            Case Else 'for other acc products ... referer is 1009
    '                ActivationInfo.referrer = "1009"
    '        End Select
    '        WriteDebugInfo("Referrer=" & ActivationInfo.referrer, logUniquePath, FileName, True)
    '        WriteDebugInfo("done!", logUniquePath, FileName, True)
    '        WriteDebugInfo("Set pcodeinfo", logUniquePath, FileName, True)
    '        Dim PCodeInfo(0) As FHResellerCustomer.pcodeinfo
    '        PCodeInfo(0) = New FHResellerCustomer.pcodeinfo
    '        WriteDebugInfo("ProductCode = " & ProductCode, logUniquePath, FileName, True)
    '        PCodeInfo(0).productcode = ProductCode
    '        PCodeInfo(0).serialno = SerialNo
    '        PCodeInfo(0).newserialno = SerialNo
    '        PCodeInfo(0).renewable = 0
    '        PCodeInfo(0).renewduration = 0
    '        WriteDebugInfo("done!", logUniquePath, FileName)
    '        ActivationInfo.productcodes = PCodeInfo

    '        WriteDebugInfo("ActivateProduct Calling", logUniquePath, FileName, True)
    '        Dim ReturnMSG As FHResellerCustomer.returnmsg
    '        ReturnMSG = FHService.activateProducts(ActivationInfo)
    '        WriteDebugInfo("ActivateProduct is ok", logUniquePath, FileName)
    '        WriteDebugInfo("ERRCODE=" & ReturnMSG.ERRORCODE.ToString(), logUniquePath, FileName, True)
    '        WriteDebugInfo("ERRDESC=" & ReturnMSG.ERRORDESC.ToString(), logUniquePath, FileName, True)

    '        If Not ReturnMSG.ERRORCODE.ToString().Trim().Equals("0") Then
    '            Dim serviceParameter As New System.Text.StringBuilder
    '            serviceParameter.Append("customerid=" & CustomerID & "::")
    '            serviceParameter.Append("orderno=" & OrderNo & "::")
    '            serviceParameter.Append("entityid=" & CustomerID & "::")
    '            serviceParameter.Append("entityname=" & CompanyName & "::")
    '            serviceParameter.Append("referrer=" & 1009 & "::")
    '            serviceParameter.Append("productcode=" & ProductCode & "::")
    '            serviceParameter.Append("SerialNo=" & SerialNo & "::")
    '            serviceParameter.Append("renewable=" & 0 & "::")
    '            serviceParameter.Append("renewduration=" & 0)

    '            InfiniLogic.AccountsCentre.BLL.User.AddWebServiceLog("accounts.infinibiz.com/account/customer.asmx.vb", _
    '                                "activate", _
    '                                "http://webservices.infinibiz.com/customer.php", _
    '                                "activateProducts", _
    '                                serviceParameter.ToString, ReturnMSG.ERRORCODE.ToString, ReturnMSG.ERRORDESC)
    '        End If
    '        '------------------------------------done--------------------------------------

    '        Return ErrCodeAndDescription(0, NewCustomerID)
    '    Catch ex As Exception
    '        If Not System.IO.Directory.Exists("d:\CustomerProcessing Trace") Then
    '            System.IO.Directory.CreateDirectory("d:\CustomerProcessing Trace")
    '        End If
    '        Dim sw As System.IO.StreamWriter
    '        sw = System.IO.File.AppendText("d:\CustomerProcessing Trace\Exception Trace.txt")
    '        sw.WriteLine(Now & " -- EXCEPTION")
    '        sw.WriteLine(Now & " -- Input Parameters:")
    '        sw.WriteLine(Now & " --     CustomerID=" & CustomerID)
    '        sw.WriteLine(Now & " --     ProductCode=" & ProductCode)
    '        sw.WriteLine(Now & " --     OrderNo=" & OrderNo)
    '        sw.WriteLine(Now & " --     SerialNo=" & SerialNo)
    '        sw.WriteLine(Now & " --     Language=" & Language)
    '        sw.WriteLine(Now & " -- Message = " & ex.Message)
    '        sw.WriteLine(Now & " -- StackTrace = " & ex.StackTrace)
    '        sw.WriteLine(Now & " -- Caller IP = " & HttpContext.Current.Request.UserHostAddress)
    '        sw.Close()
    '        Return ErrCodeAndDescription(1)
    '    End Try

    'End Function



    Public Structure getActivationInfoResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public link As String
        Public variablename As String
        Public value As String
    End Structure

    Public Structure activateResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public NewCustomerID As String
    End Structure

    Public Structure activationinfo
        Public customerid As String
        Public productcode As String
        Public orderno As String
        Public serialno As String
        Public language As String
        Public serviceid As String
    End Structure

    Public Structure customerInfoResult
        Public ERRORCODE As String
        Public ERRORDESC As String
        Public info() As customerInfo
    End Structure

    Public Structure customerInfo
        Public customerID As String
        Public refferID As String
        Public productCode As String
        Public quantity As Integer
        Public entityID As String
        Public globalCompanyID As String
    End Structure


#Region "Private Function"

    '''----------------------------------------------------------------------------------
    ''' Project  : CustomerProcessing_Proj
    ''' Class  : CustomerProcessing
    ''' 
    '''----------------------------------------------------------------------------------
    '''<summary>
    '''    This function is used to generate error description against error code
    '''</summary>
    '''<param name="ErrCode">Reseller Login ID</param>
    '''<param name="NewCustomerID">Optional Parameter</param>
    '''<param name="OrderID">Optional Parameter</param>
    '''<returns>Return One Dimesional Array</returns>
    '''<remarks>
    '''</remarks>
    '''<history>
    '''	[win.yousuf]	22/05/2006 Created
    '''</history>
    '''----------------------------------------------------------------------------------
    Private Function ErrCodeAndDescription(ByVal ErrCode As String, Optional ByVal NewCustomerID As String = "") As activateResult
        Dim ECD As New activateResult
        ECD.ERRORCODE = ErrCode
        ECD.NewCustomerID = NewCustomerID

        Select Case ErrCode
            Case "0"
                ECD.ERRORDESC = "Success."
            Case "1"
                ECD.ERRORDESC = "Server Error."
            Case "10"
                ECD.ERRORDESC = """CustomerID"" not found OR invalid format."
            Case "11"
                ECD.ERRORDESC = """ProductCode"" not found OR invalid format."
            Case "12"
                ECD.ERRORDESC = """OrderNo"" not found OR invalid format."
            Case "13"
                ECD.ERRORDESC = """SerialNo"" invalid format."
            Case Else
                ECD.ERRORDESC = "Unknown Error Found."
        End Select

        Return ECD
    End Function

    '''----------------------------------------------------------------------------------
    ''' Project  : Reseller
    ''' Class  : Validation
    ''' 
    '''----------------------------------------------------------------------------------
    '''<summary>
    '''    This function is used in IOTracing 
    '''</summary>
    '''<param name="sText"></param>
    '''<remarks>
    '''</remarks>
    '''<history>
    '''	[win.yousuf]	22/05/2006 Created
    '''</history>
    '''----------------------------------------------------------------------------------
    Private Sub WriteDebugInfo(ByVal sText As String, ByVal Path As String, ByVal FileName As String, Optional ByVal byForceIOTrace As Boolean = False)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") OrElse byForceIOTrace = True Then
            If Not System.IO.Directory.Exists(Path) Then
                System.IO.Directory.CreateDirectory(Path)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(Path & "\" & FileName)
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        ElseIf System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("2") Then
            System.Web.HttpContext.Current.Trace.Write(sText)
        End If
    End Sub
#End Region

    '---------------These below function are for Login Service-------------------
#Region ":::::::::::::::::::::Login Services:::::::::::::::::::::::::"
    <WebMethod(enableSession:=True)> _
    Public Function autoLogin(ByVal logininfo As AutoLoginStruct) As AutoLoginResult
        Dim logUniquePath As String = "d:\CustomerProcessing Trace\" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Dim FileName As String = "autoLogin.txt"
        WriteDebugInfo("----In AutoLogin-------", logUniquePath, FileName)
        Dim autologinReturnMsg As AutoLoginResult
        Dim SessionID As String = logininfo.serviceid

        Try
            If Not IsNumeric(logininfo.customerid) And (Not IsNumeric(logininfo.customerid)) Then
                WriteDebugInfo("autoLoginEmployee", logUniquePath, FileName)

                WriteDebugInfo("logininfo.customerid = " & logininfo.customerid, logUniquePath, FileName)
                WriteDebugInfo("logininfo.password = " & logininfo.password, logUniquePath, FileName)

                If logininfo.customerid = "" Then
                    autologinReturnMsg.ERRORCODE = "1"
                    autologinReturnMsg.ERRORDESC = "Parameter customerid is empty"
                    WriteDebugInfo("ErrorDesc" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                    Return autologinReturnMsg
                Else
                    logininfo.loginid = logininfo.customerid
                End If

                If logininfo.password = "" Then
                    autologinReturnMsg.ERRORCODE = "2"
                    autologinReturnMsg.ERRORDESC = "Parameter password is empty"
                    WriteDebugInfo("ErrorDesc" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                    Return autologinReturnMsg
                End If

                'If logininfo.serviceid = "" Then
                '    autologinReturnMsg.ERRORCODE = "3"
                '    autologinReturnMsg.ERRORDESC = "Parameter serviceid is empty"
                '    WriteDebugInfo("ErrorDesc" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                '    Return autologinReturnMsg
                'End If

                autologinReturnMsg = autoLoginEmployee(logininfo)
                WriteDebugInfo("ERRORCODE=" & autologinReturnMsg.ERRORCODE, logUniquePath, FileName)
                WriteDebugInfo("ErrorDesc=" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                Return autologinReturnMsg
            Else
                If logininfo.password = "" Then
                    autologinReturnMsg.ERRORCODE = "4"
                    autologinReturnMsg.ERRORDESC = "Parameter password is empty"
                    WriteDebugInfo("ErrorDesc" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                    Return autologinReturnMsg
                End If
                If logininfo.customerid = "" Then
                    autologinReturnMsg.ERRORCODE = "5"
                    autologinReturnMsg.ERRORDESC = "Parameter loginid is empty"
                    WriteDebugInfo("ErrorDesc" & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)
                    Return autologinReturnMsg
                End If

                Dim objSecureQueryString As New SecureQueryString
                WriteDebugInfo("Calling GetCustomerLoginID ", logUniquePath, FileName)
                logininfo.loginid = ServicesManager.GetCustomerLoginID(logininfo.customerid)
                WriteDebugInfo("GetCustomerLoginID is ok: logininfo.loginid = " & logininfo.loginid, logUniquePath, FileName)

                With objSecureQueryString
                    .Add("UserID", logininfo.loginid)
                    .Add("Password", logininfo.password)
                    .Add(PageTemplate.ACC_SessionID, SessionID)
                    .Add("serviceid", logininfo.serviceid)
                    .ExpireTime = Now.AddSeconds(60)
                    With autologinReturnMsg
                        .ERRORCODE = Errorcode.Successful
                        .ERRORDESC = "Operation Successful"
                        .value = SessionID
                        .newwin = "0"
                        .variablename = "sid"  'this variable is not used by www.accoutscentre.com so "n" is a dummy value 
                        .winparam = ""
                        .link = "https://" & HttpContext.Current.Request.Url.Host & "/Account/DoLogin.aspx?q=" + objSecureQueryString.ToString()
                        WriteDebugInfo("link=" & .link, logUniquePath, FileName)
                    End With

                    WriteDebugInfo("Calling SignIn: ", logUniquePath, FileName)
                    WriteDebugInfo("    SessionID= " & SessionID, logUniquePath, FileName)
                    WriteDebugInfo("    logininfo.loginid= " & logininfo.loginid, logUniquePath, FileName)
                    SignIn(SessionID, logininfo.loginid)
                    WriteDebugInfo("SignIn is ok: ", logUniquePath, FileName)
                End With
            End If
        Catch e As Exception
            With autologinReturnMsg
                .ERRORCODE = Errorcode.UnknownError
                .ERRORDESC = e.Message
            End With
        End Try

        WriteDebugInfo("ERRORCODE = " & autologinReturnMsg.ERRORCODE, logUniquePath, FileName)
        WriteDebugInfo("ERRORDESC = " & autologinReturnMsg.ERRORDESC, logUniquePath, FileName)

        Return autologinReturnMsg
    End Function
    '<WebMethod(enableSession:=True)> _
    Public Function autoLoginEmployee(ByVal logininfo As AutoLoginStruct) As AutoLoginResult
        Dim logUniquePath As String = "d:\CustomerProcessing Trace\" & Now.Year & "-" & Now.Month & "-" & Now.Day & " " & Now.Hour & "." & Now.Minute & "." & Now.Second & "." & Now.Millisecond
        Dim FileName As String = "autoLogin.txt"
        WriteDebugInfo("----In autoLoginEmployee-------", logUniquePath, FileName)
        Dim autologinReturnMsg As AutoLoginResult
        Dim SessionID As String = logininfo.serviceid
        Dim isEmployee As String = "False"

        Try
            With logininfo
                .employeeid = "0" : .employeepassword = "0" : .merchantuserid = "0"
            End With

            Dim objSecureQueryString As New SecureQueryString
            'WriteDebugInfo("Before logininfo.loginid = " & logininfo.loginid, logUniquePath, FileName)
            'If Not IsNumeric(logininfo.loginid) Then

            WriteDebugInfo("calling setEmployeeInfo()", logUniquePath, FileName)
            Dim EmployeeInfoSet As Boolean = setEmployeeInfo(logininfo)
            WriteDebugInfo("setEmployeeInfo is ok:", logUniquePath, FileName)
            WriteDebugInfo("EmployeeInfoSet=" & EmployeeInfoSet, logUniquePath, FileName)

            WriteDebugInfo("isEmployee = true", logUniquePath, FileName)
            If Not EmployeeInfoSet Then
                With autologinReturnMsg
                    .ERRORCODE = Errorcode.UnknownError
                    .ERRORDESC = "Invalid UserID/Password of Employee"
                End With
                Return autologinReturnMsg
                Exit Function
            End If
            WriteDebugInfo("isEmployee = true", logUniquePath, FileName)
            isEmployee = "true"
            'Else
            'logininfo.loginid = ServicesManager.GetCustomerLoginID(logininfo.customerid)
            '    With autologinReturnMsg
            '        .ERRORCODE = Errorcode.UnknownError
            '        .ERRORDESC = "Invalid UserID/Password of Employee"
            '    End With
            '    Return autologinReturnMsg
            '    Exit Function
            'End If
            'WriteDebugInfo("After logininfo.loginid = " & logininfo.loginid, logUniquePath, FileName)
            With objSecureQueryString
                WriteDebugInfo("logininfo.customerid=" & logininfo.customerid, logUniquePath, FileName)
                .Add("UserID", logininfo.customerid)
                WriteDebugInfo("logininfo.password=" & logininfo.password, logUniquePath, FileName)
                .Add("Password", logininfo.password)
                WriteDebugInfo("SessionID=" & SessionID, logUniquePath, FileName)
                .Add(PageTemplate.ACC_SessionID, SessionID)
                WriteDebugInfo("logininfo.serviceid=" & logininfo.serviceid, logUniquePath, FileName)
                .Add("serviceid", logininfo.serviceid)
                WriteDebugInfo("isEmployee=" & isEmployee, logUniquePath, FileName)
                .Add("isEmployee", isEmployee)
                WriteDebugInfo("logininfo.employeeid=" & logininfo.employeeid, logUniquePath, FileName)
                .Add("Employeeid", logininfo.employeeid)
                WriteDebugInfo("logininfo.merchantuserid=" & logininfo.merchantuserid, logUniquePath, FileName)
                .Add("merchantuserid", logininfo.merchantuserid)

                .ExpireTime = Now.AddSeconds(60)


                With autologinReturnMsg
                    .ERRORCODE = Errorcode.Successful
                    .ERRORDESC = "Operation Successful"
                    .value = SessionID
                    .newwin = "0"
                    .variablename = "sid"  'this variable is not used by www.accoutscentre.com so "n" is a dummy value 
                    .winparam = ""
                    'WriteDebugInfo("10", logUniquePath, FileName)
                    .link = "https://" & HttpContext.Current.Request.Url.Host & "/Account/DoLogin.aspx?q=" + objSecureQueryString.ToString()
                    'WriteDebugInfo("11", logUniquePath, FileName)
                End With

                WriteDebugInfo("calling SignIn", logUniquePath, FileName)
                WriteDebugInfo("    SessionID=" & SessionID, logUniquePath, FileName)
                WriteDebugInfo("    logininfo.loginid=" & logininfo.customerid, logUniquePath, FileName)
                SignIn(SessionID, logininfo.customerid)
                WriteDebugInfo("SignIn is ok", logUniquePath, FileName)
            End With
        Catch e As Exception

            With autologinReturnMsg
                .ERRORCODE = Errorcode.UnknownError
                .ERRORDESC = e.Message
            End With
        End Try
        Return autologinReturnMsg
    End Function

    '<WebMethod()> _
    Public Sub SignIn(ByVal SessionID As String, ByVal CustomerID As Integer)
        If Not SessionID Is Nothing Then
            Dim colSignedInUsers As Hashtable
            If AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN) Is Nothing Then
                colSignedInUsers = New Hashtable

            Else
                colSignedInUsers = AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN)

            End If

            If Not colSignedInUsers.ContainsKey(SessionID) Then colSignedInUsers.Add(SessionID, CustomerID)

            AppDomain.CurrentDomain.SetData(PageTemplate.ACC_USERS_SIGN_IN, colSignedInUsers)
        End If
        'Application(PageTemplate.ACC_USERS_SIGN_IN) = colSignedInUsers

    End Sub

    <WebMethod()> _
    Public Function logOff(ByVal logoffinfo As AutoLogOffStruct) As logoffReturnMsg

        If Not AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN) Is Nothing Then

            Dim SessionID As String = logoffinfo.sid

            Dim colSignedInUsers As Hashtable

            colSignedInUsers = AppDomain.CurrentDomain.GetData(PageTemplate.ACC_USERS_SIGN_IN)

            colSignedInUsers.Remove(SessionID)

            AppDomain.CurrentDomain.SetData(PageTemplate.ACC_USERS_SIGN_IN, colSignedInUsers)

        End If

        Dim logoffReturnMsg As New logoffReturnMsg

        logoffReturnMsg.ERRORCODE = Errorcode.Successful
        logoffReturnMsg.ERRORDESC = "Operation Successful"

        Return logoffReturnMsg

    End Function

    '<WebMethod()> _
    'Public Function authenticateEmployee(ByVal loginInfo As authenticateStruct) As authenticateResult
    '    ''' Created by Muhammad Ubaid
    '    ''' Date 01-March-2007
    '    ''' This web service authenticate the Employee
    '    Dim authenticateReturnMsg As authenticateResult
    '    Dim objXml As New System.Xml.XmlDocument
    '    Dim XmlNode As System.Xml.XmlNode
    '    If loginInfo.loginid = "" OrElse loginInfo.password = "" Then
    '        authenticateReturnMsg.ERRORCODE = "1"
    '        authenticateReturnMsg.ERRORDESC = "Parameter loginid is empty"
    '        Return authenticateReturnMsg
    '    End If
    '    Try
    '        Dim autologinInfo As AutoLoginStruct
    '        autologinInfo.loginid = loginInfo.loginid
    '        autologinInfo.password = loginInfo.password
    '        If Not setEmployeeInfo(autologinInfo) Then
    '            With authenticateReturnMsg
    '                .ERRORCODE = Errorcode.InvalidInfo
    '                .ERRORDESC = "Employee ID/Password is not vaild"
    '            End With
    '            Return authenticateReturnMsg
    '            Exit Function
    '        End If
    '        With authenticateReturnMsg
    '            .ERRORCODE = Errorcode.Successful
    '            .ERRORDESC = "Success"
    '        End With
    '        Return authenticateReturnMsg
    '    Catch ex As Exception
    '        authenticateReturnMsg.ERRORCODE = Errorcode.UnknownError
    '        authenticateReturnMsg.ERRORDESC = "Unknown Error"
    '    End Try
    'End Function

    <WebMethod()> _
    Public Function SingleSignin(ByVal info As SingleSigninInfo) As SingleSigninResult
        ''' Created by M. Yousuf
        ''' Date Dec 14, 2006
        System.Web.HttpContext.Current.Trace.Warn("------In SingleSignin---------")
        Dim Result As SingleSigninResult
        Dim objXml As New System.Xml.XmlDocument
        Dim XmlNode As System.Xml.XmlNode

        If info.loginid = "" OrElse info.password = "" Then
            System.Web.HttpContext.Current.Trace.Warn("loginid=" & info.loginid)
            System.Web.HttpContext.Current.Trace.Warn("password=" & info.password)
            Result.ERRORCODE = "1"
            Result.ERRORDESC = "Parameter loginid/password is empty"
            Return Result
        End If

        Try

            If Not IsNumeric(info.loginid) Then
                'if EmployeeID(@) found then execute this block
                System.Web.HttpContext.Current.Trace.Warn("Calling IsValidEmployee")
                Dim ValidEmployee As Boolean = IsValidEmployee(info)
                System.Web.HttpContext.Current.Trace.Warn("IsValidEmployee is ok")
                System.Web.HttpContext.Current.Trace.Warn("ValidEmployee=" & ValidEmployee)

                If ValidEmployee Then
                    Result.ERRORCODE = "0"
                    Result.ERRORDESC = "Operation Completed Successfully"
                    Result.InternalCustomerUID = info.loginid
                    Result.InternalCustomerID = info.loginid
                Else
                    Result.ERRORCODE = "-30"
                    Result.ERRORDESC = "Invalid EmployeeID/Password [" & info.loginid & ", " & info.password & "]"
                End If
            Else
                'if Normal customer found then execute this block
                System.Web.HttpContext.Current.Trace.Warn("Calling IsValidCustomer")
                Dim SignInBool As Boolean = IsValidCustomer(info.loginid, info.password)
                System.Web.HttpContext.Current.Trace.Warn("IsValidCustomer---OK")

                If SignInBool Then
                    Result.InternalCustomerID = GetInfiniShopMainDB_CustomerID(info.loginid)
                    System.Web.HttpContext.Current.Trace.Warn("Calling InfiniLogic.AccountsCentre.BLL.User.GetCustomerUID(" & Result.InternalCustomerID & ")")
                    Result.InternalCustomerUID = Infinilogic.AccountsCentre.BLL.User.GetCustomerUID(Result.InternalCustomerID)
                    System.Web.HttpContext.Current.Trace.Warn("GetCustomerUID is ok:")
                    System.Web.HttpContext.Current.Trace.Warn("Result.InternalCustomerID=" & Result.InternalCustomerID)
                    System.Web.HttpContext.Current.Trace.Warn("Result.InternalCustomerUID=" & Result.InternalCustomerUID)
                    Result.ERRORCODE = "0"
                    Result.ERRORDESC = "Operation Completed Successfully"
                Else
                    Result.ERRORCODE = "-20"
                    Result.ERRORDESC = "Invalid UserID/Password [" & info.loginid & ", " & info.password & "]"
                End If
            End If
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("Exception occur in authenticate" & ex.Message & " " & ex.Source)
            System.Web.HttpContext.Current.Trace.Warn("Stack Trace in authenticate" & ex.StackTrace)
            Result.ERRORCODE = "-11"
            Result.ERRORDESC = "Unknown Error: Message=" & ex.Message
        End Try

        System.Web.HttpContext.Current.Trace.Warn("ERRORCODE=" & Result.ERRORCODE)
        System.Web.HttpContext.Current.Trace.Warn("ERRORDESC=" & Result.ERRORDESC)
        Return Result
    End Function

    Private Function IsValidEmployee(ByVal info As SingleSigninInfo) As Boolean
        Try
            Dim EmployeeID As String = info.loginid
            Dim EmployeePassword As String = info.password

            Dim LoginInfo As New AutoLoginStruct
            LoginInfo.customerid = EmployeeID
            LoginInfo.password = EmployeePassword

            Dim IsValid As Boolean = False

            IsValid = setEmployeeInfo(LoginInfo)

            Return IsValid

            'Dim dsEmployee As DataSet = BLL.MerchantEmployee.GetEmployeeMerchant(EmplyeeID)
            'If dsEmployee Is Nothing OrElse dsEmployee.Tables.Count = 0 OrElse dsEmployee.Tables(0).Rows.Count = 0 Then
            '    'Employee not found!
            '    Return False
            'End If
            'Dim DB_Encrypt_Password As String = dsEmployee.Tables(0).Rows(0).Item("employeePass")
            'Dim LogKey As String = dsEmployee.Tables(0).Rows(0).Item("LogKey")
            'Dim objCryptography As New Infinilogic.AccountsCentre.common.Cryptography

            'Dim DBPlainPassword As String = objCryptography.DeCrypt(DB_Encrypt_Password, LogKey)

            'If DBPlainPassword.Trim <> EmplyeePassword.Trim Then
            '    'Invalid Password
            '    Return False
            'End If

            ''All check completed successfully
            'Return True
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        End Try
    End Function

    Function IsValidCustomer(ByVal LiveID As String, ByVal Password As String) As Boolean
        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String = service.GetXML(com.infinimarket.service.XmlFormat.Customer_login)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~cust_luid~", LiveID)
        xmlValue = Replace(xmlValue, "~pwd~", Password)
        Dim ResultXML As String = service.LoginCustomer(xmlValue)
        Dim xmlDoc As New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)
        Dim Success As Boolean
        If Not xmlDoc.SelectSingleNode("login/loginKey") Is Nothing Then
            If xmlDoc.SelectSingleNode("login/loginKey").InnerXml <> "" Then
                Success = True 'Login success
            Else
                Success = False
            End If
        Else
            Success = False
        End If
        Return Success
    End Function

    Function GetInfiniShopMainDB_CustomerID(ByVal LiveID As String) As String
        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String = service.GetXML(com.infinimarket.service.XmlFormat.Customer_details)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~cust_luid~", LiveID)
        xmlValue = Replace(xmlValue, "~merch_id~", "2")
        Dim ResultXML As String = service.GetCustomerChildID_By_MerchantID(xmlValue)
        Dim xmlDoc As New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)
        Dim M2CustomerID As String = xmlDoc.SelectSingleNode("details/Customer_Child_Id").InnerXml
        Return M2CustomerID
    End Function



#End Region
#Region ":::::::::::::::::::::;Employee:::::::::::::::::::::::::"
    Private Function setEmployeeInfo(ByRef loginInfo As AutoLoginStruct) As Boolean
        'Merchant_id, 3
        'LogKey, 5
        'LogType, 6
        'UserName, 7
        'isVailEmployee, 9
        Try
            Dim EmployeeInfo(10) As String
            With EmployeeInfo
                .SetValue(loginInfo.customerid, 0) : .SetValue(loginInfo.password, 1) : .SetValue("0", 2)
                .SetValue("0", 3) : .SetValue("0", 4) 'merchantPassword 4
                .SetValue("0", 5) : .SetValue("0", 6) : .SetValue("0", 7) : .SetValue("0", 8)
                .SetValue("0", 9) : .SetValue("0", 10)
            End With

            System.Web.HttpContext.Current.Trace.Warn("calling BLL.User.setEmpEmployerID()")
            BLL.User.setEmpEmployerID(EmployeeInfo)
            System.Web.HttpContext.Current.Trace.Warn("BLL.User.setEmpEmployerID is ok")
            If CBool(EmployeeInfo.GetValue(9)) Then
                With loginInfo
                    .customerid = EmployeeInfo.GetValue(2) 'Merchant_uid, 2
                    .password = EmployeeInfo.GetValue(4) 'merchantPass, 4
                    .employeeid = EmployeeInfo.GetValue(0) 'employeePass, 0
                    .employeepassword = EmployeeInfo.GetValue(1) 'employeePass, 1
                    .merchantuserid = EmployeeInfo.GetValue(10) 'merchantuserid
                    '.Url = SelectUrl.Employee
                    '.Url = SelectUrl.AccountCentre
                End With
            End If
            Return CBool(EmployeeInfo.GetValue(9))
        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION:")
            System.Web.HttpContext.Current.Trace.Warn("MESSAGE:" & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("SOURCE:" & ex.Source)
            Throw ex
        End Try
    End Function
#End Region
End Class
#Region ":::::::::::::::::::;AutoLogin Structures:::::::::::::::::::::::::::::"


Public Structure AutoLoginStruct
    Public customerid As String
    Public password As String
    Public serviceid As String
    Public language As String
    'Public code1 As String
    'Public code2 As String
    'Public reSellerId As String
    Public loginid As String
    Friend employeeid As String
    Friend employeepassword As String
    Friend merchantuserid As String
End Structure

Public Structure AutoLoginResult
    Public ERRORCODE As String
    Public ERRORDESC As String
    Public newwin As String
    Public winparam As String
    Public variablename As String
    Public value As String
    Public link As String
    'Public sessionvar As String -> variablename
    'Public sessionid As String -> value
    'Public url As String -> link

End Structure

Public Structure AutoLogOffStruct
    Public sid As String
    Public refId As String
End Structure

Public Structure logoffReturnMsg
    Public ERRORCODE As String
    Public ERRORDESC As String
End Structure
Public Enum Errorcode
    Successful = 0
    InvalidInfo = -1
    Session_Destruction_Failed = -2
    UnknownError = -11
End Enum
#End Region
#Region ":::::::::::::::::::;Login Structures:::::::::::::::::::::::::::::"
Public Structure SingleSigninResult
    Public ERRORCODE As String
    Public ERRORDESC As String
    Public InternalCustomerID As String
    Public InternalCustomerUID As String
    'Public info() As ExtraInfo
End Structure

Public Structure ExtraInfo
    Public CustomerID As String
    Public MerchantID As String
End Structure

Public Structure SingleSigninInfo
    Public loginid As String
    Public password As String
End Structure

Public Structure authenticateResult
    Public ERRORCODE As String
    Public ERRORDESC As String
    Public customerid As String
End Structure
Public Structure authenticateStruct
    Public loginid As String
    Public password As String
End Structure
#End Region

