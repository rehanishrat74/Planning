#Region ":::::::::::::::: Imports Liabraries ::::::::::::::::"

Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Web.Mail
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Xml

#End Region

#Region ":::::::::::::::: CLASS -> CXLProcessing ::::::::::::::::"

Public Class CXLProcessing

#Region "<<< <<< <<< <<< <<< Event declaration >>> >>> >>> >>> >>>"

    'Public Delegate Sub ShowInformation(ByVal Message As String, ByVal IsVisible As Boolean)
    'Public ShowError, ShowMessage As ShowInformation

    Public Event DisplayMessage(ByVal Message As String, ByVal IsVisible As Boolean)
    Public Event DisplayError(ByVal Message As String, ByVal IsVisible As Boolean)


#End Region

#Region "<<< <<< <<< <<< <<< CXL and Helper functions/procedures >>> >>> >>> >>> >>>"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intCustID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetLastOrderNo(ByVal intCustID As Integer) As Integer
        Dim dr As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        Dim RetVal As Integer = -1

        Try
            dr = objCXLOrder.AccGetOrderDetails(intCustID, IsLast:=True)

            While dr.Read
                RetVal = CInt(dr("OrderNo"))
            End While

        Catch ex As Exception
        Finally
            dr.Close()
        End Try

        Return RetVal
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''   this mehtod check return order status and if response code is 
    '''     equal to 30 then retunr true else return false
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="LoginID"></param>
    ''' <param name="OrderNo"></param>
    ''' <param name="strStatus"></param>
    ''' <param name="PaymentMethod"></param>
    ''' <param name="IsUpdatePaymentInfo"></param>
    ''' <returns>True if ResponseCode is equal to 30</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	29/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CheckCollectionStatus(ByVal CustomerID As Integer, ByVal LoginID As Integer, ByVal OrderNo As Integer, ByVal strStatus As String, ByVal PaymentMethod As String, Optional ByVal IsUpdatePaymentInfo As Boolean = False, Optional ByRef IsEnableServices As Boolean = False) As Boolean

        Dim ds As New DataSet
        Dim sqlDR As SqlDataReader
        Dim strCollectionTID, strResponseCode, strRefNo, strMsg As String

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~ RESPONSE CODE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' ----------------------------------------------------------------------------------
        '| CASE |   MESSAGE             |       REASON                                      |
        '-----------------------------------------------------------------------------------
        '| 00    | AUTH code: nnnnnn    | The card is accepted and authorisation granted    |
        '|       |                      | ( nnnnnn can be an alphanumeric value between 2   |
        '|       |                      | and 8 digits.                                     |
        '-----------------------------------------------------------------------------------
        '| 2    | Referral B            | The card had been rejected as over ceiling limit. |
        '-----------------------------------------------------------------------------------
        '| 5    | Not Authorised        | Authorisation has been refused.                   |
        '|      | Declined              | Authorisation has been refused.                   |
        '|      | Error Resubmit        | Problem with card data.                           |
        '|      | AAV Fail: nn          | AAV Response code.                                |
        '-----------------------------------------------------------------------------------
        '| 30   | Invalid Merchant      | The merchant number used is not set-up.           |
        '|      | Referral X            | The card has expired.                             |
        '|      | Invalid Trans         | The card has expired.                             |
        '|      | Invalid Amount        | The card has expired.                             |
        '|      | Invalid Card No       | The card has expired.                             |
        '|      | Duplicate Trans       | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 54   | Expired Card          | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 91   | COMMS FAULT           | Returned by CCARD to indicate local Comms fault   |
        '|      |                       | (i.e. modem problem).                             |
        '-----------------------------------------------------------------------------------
        '| 92   | Manual AUTH           | Remote acquirer not responding.                   |
        '-----------------------------------------------------------------------------------
        ' Some response codes and message test may vary according to the acquirer. For a 
        ' definitive list of response codes and messages please refer to the acquirer's
        ' Technical Specification.

        
        Try
            '-----------------------------------
            ds = ConvertXMLToDataSet(strStatus)
            '-----------------------------------            

            If ds.Tables(0).Columns.Count > 2 Then ' CXL Response has more than two column 

                '-------------------------------------------
                strCollectionTID = ds.Tables(0).Rows(0)(0)
                strResponseCode = ds.Tables(0).Rows(0)(1)
                strRefNo = ds.Tables(0).Rows(0)(2)
                strMsg = ds.Tables(0).Rows(0)(3)


                '-------------------------------------------

                If CInt(strResponseCode) = 0 Then   ' CXL Transaction Succesfull
                    '--------------------------------------------------------------------------------------------------------------------------------

                    If PaymentMethod = "CC" Then
                        '-------------------------------------------
                        EnableServices(CustomerID, LoginID, OrderNo)
                        IsEnableServices = True
                        '-------------------------------------------
                    End If

                    '-------------------------------------------------------------------------------
                    If IsUpdatePaymentInfo Then
                        'ShowMessage("Order payment has been successed.<br> Please do not retry.", True)
                        RaiseEvent DisplayMessage("Order payment successfull.<br>PLEASE DO NOT RETRY.", True)
                    End If
                    '-------------------------------------------------------------------------------

                    If CInt(strCollectionTID) < 0 Then
                        '----------------------------------------------------------------------------------------------------------------------------------
                        Dim strBody As String = "<b>Login ID " & LoginID & "<br>Order No. " & OrderNo & "</b><br>Payment has been successed but return TracID is " & strCollectionTID
                        '----------------------------------------------------------------------------------------------------------------------------------

                        '------------------------------------------------------------------------------------------------------------
                        If CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", strBody, MailFormat.Html, _
                                ConfigReader.GetItem(ConfigVariables.EmailBCC)) Then
                            EmailManager.CreatDBLog(CustomerID, "ACSA", strBody.ToString, "", ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", ConfigReader.GetItem(ConfigVariables.SMTPUserID), True)
                        Else
                            EmailManager.CreatDBLog(CustomerID, "ACSA", strBody.ToString, "", ACCMessage.Email_DefaultEmailAddress, "Order Payment by calling CXL.", ConfigReader.GetItem(ConfigVariables.SMTPUserID), False)
                        End If
                        '------------------------------------------------------------------------------------------------------------
                    End If

                    '-------------------------------------------------------------------------------------------------------------------------------------
                ElseIf CInt(strResponseCode) > 0 Then   ' Credit Card Decline
                    '-------------------------------------------------------------------------------------------
                    Select Case CInt(strResponseCode)
                        Case 2, 5, 30, 54, 91, 92

                            RaiseEvent DisplayError(GetPredefinedError(CInt(strResponseCode)), True)

                            '-------------------------------------------------------------------------------------------------------------------------------------------------------
                            Dim strBody As String = "<b>Login ID " & LoginID & "<br>Order No. " & OrderNo & "</b><br>Credit Card declined but return TracID is " & strCollectionTID
                            '-------------------------------------------------------------------------------------------------------------------------------------------------------

                            '------------------------------------------------------------------------------------------------------------
                            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), _
                                    ACCMessage.Email_DefaultEmailAddress, "Calling CXL in Update Services.", strBody, MailFormat.Html, _
                                    ConfigReader.GetItem(ConfigVariables.EmailBCC))
                            '------------------------------------------------------------------------------------------------------------

                            Return True ' because response code is 30

                        Case Else
                            RaiseEvent DisplayError(strMsg, True) : Exit Select
                    End Select

                    '-------------------------------------------------------------------------------------------
                Else    ' < 0 
                    '-------------------------------------------------------------------------------------------
                    If (CInt(strResponseCode <> -500)) Then
                        RaiseEvent DisplayError(strMsg, True)
                    End If

                    ' Error Log
                    AccInsertPaymentErrorLog(CustomerID, OrderNo, Date.Now, strResponseCode, strMsg)
                    '-------------------------------------------------------------------------------------------
                End If


            Else ' CX Transaction failure
                '--------------------------------------------------------------------
                ShowResponseError(CustomerID, OrderNo, ds.Tables(0).Rows(0)(0), ds.Tables(0).Rows(0)(1))
                '--------------------------------------------------------------------
            End If
        Catch ex As Exception
        End Try

        Return False ' because response code is not 30
    End Function

    Private Function GetPredefinedError(ByVal ResponseCode As Integer) As String

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~ RESPONSE CODE ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        ' ----------------------------------------------------------------------------------
        '| CASE |   MESSAGE             |       REASON                                      |
        '-----------------------------------------------------------------------------------
        '| 00    | AUTH code: nnnnnn    | The card is accepted and authorisation granted    |
        '|       |                      | ( nnnnnn can be an alphanumeric value between 2   |
        '|       |                      | and 8 digits.                                     |
        '-----------------------------------------------------------------------------------
        '| 2    | Referral B            | The card had been rejected as over ceiling limit. |
        '-----------------------------------------------------------------------------------
        '| 5    | Not Authorised        | Authorisation has been refused.                   |
        '|      | Declined              | Authorisation has been refused.                   |
        '|      | Error Resubmit        | Problem with card data.                           |
        '|      | AAV Fail: nn          | AAV Response code.                                |
        '-----------------------------------------------------------------------------------
        '| 30   | Invalid Merchant      | The merchant number used is not set-up.           |
        '|      | Referral X            | The card has expired.                             |
        '|      | Invalid Trans         | The card has expired.                             |
        '|      | Invalid Amount        | The card has expired.                             |
        '|      | Invalid Card No       | The card has expired.                             |
        '|      | Duplicate Trans       | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 54   | Expired Card          | The card has expired.                             |
        '-----------------------------------------------------------------------------------
        '| 91   | COMMS FAULT           | Returned by CCARD to indicate local Comms fault   |
        '|      |                       | (i.e. modem problem).                             |
        '-----------------------------------------------------------------------------------
        '| 92   | Manual AUTH           | Remote acquirer not responding.                   |
        '-----------------------------------------------------------------------------------
        ' Some response codes and message test may vary according to the acquirer. For a 
        ' definitive list of response codes and messages please refer to the acquirer's
        ' Technical Specification.

        Select Case ResponseCode
            Case 2
                Return "The card had been rejected as over ceiling limit."
            Case 5
                Return "Authorisation has been refused OR Problem with card data OR AAV Response Code."
            Case 30
                Return "Invalid card number OR The card has expired."
            Case 91
                Return "Returned by CARD to indicate local Communications fault (i.e. modem problem)."
            Case 92
                Return "Remote acquirer not responding."
            Case Else
                Return ""
        End Select
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderNo"></param>
    ''' <param name="ErrorCode"></param>
    ''' <param name="ErrorMsg"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowResponseError(ByVal CustomerID As Integer, ByVal OrderNo As Integer, ByVal ErrorCode As String, ByVal ErrorMsg As String)

        ''' NOTE : first two 
        ''' CRITICAL ERRORS // THAT SHOULD NOT SUPPOSE TO COME IN ANY CONDITION 
        ''' then 'GENERAL(ERRORS)



        If ErrorCode <> "-500" Then
            '-------------------------------------------------------------------------------------------------------------------------------

            '''<ERRORCODE>-903</ERRORCODE>
            '''<ERRORMSG>Transaction is Partially Failed. Please contact system Administrator. </ERRORMSG>"

            '''<ERRORCODE>-1</ERRORCODE>
            ''' <ERRORMSG>Transaction Paritally Failed or All Unsucessfull. Please contact System Administrator </ERRORMSG>

            '''<ERRORCODE>-900</ERRORCODE>
            ''' <ERRORMSG>Collection Service is not available for the specified Merchant. Please contact System Administrator.</ERRORMSG>

            '''<ERRORCODE>-550</ERRORCODE>
            '''<ERRORMSG>Transaction already done before Or Invalid Transaction Amount. Transaction Amount must be more than 0.</ERRORMSG>

            '''<ERRORCODE>-501</ERRORCODE>
            '''<ERRORMSG>Transaction Amount must be less than Remaining Balance Amount of the given Order.</ERRORMSG>


            'ShowMessage("Order is under process. Please contact with administration.", True)
            RaiseEvent DisplayMessage("Order is under process. Please contact with administration.", True)
            '-------------------------------------------------------------------------------------------------------------------------------
        ElseIf ErrorCode = "-500" Then
            '-------------------------------------------------------------------------------------------------------------------------------
            '''<ERRORCODE>-500</ERRORCODE>
            '''<ERRORMSG>Not Approved Floor Limit of customer. Notification has been sent to Administrator and waiting for further acceptance.</ERRORMSG>
            ''' OR
            ''' <ERRORMSG>You are exceding limit of no of transactions allowed per day. Please refer to site Administrator.</ERRORMSG>
            RaiseEvent DisplayError("For order number " & OrderNo & ". <br>" & ErrorMsg, True)
            'ShowError("For order number " & OrderNo & ". <br>" & ErrorMsg, True)
            '-------------------------------------------------------------------------------------------------------------------------------
        End If

        '----------------------------------------------------------------------------------
        AccInsertPaymentErrorLog(CustomerID, OrderNo, Date.Now, ErrorCode, ErrorMsg)
        '
        '----------------------------------------------------------------------------------
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="CustomerUID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="Mode"></param>
    ''' <param name="GenericCode"></param>
    ''' <param name="PaymentMode"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CollectionCXL(ByVal CustomerID As String, ByVal CustomerUID As String, _
                                   ByVal OrderID As String, ByVal Mode As String, _
                                   ByVal GenericCode As String, ByVal PaymentMode As String, ByRef ReturnValue As String) As String

        '---------------------------------------------------------------------------------------------
        Dim strXML As String = "<Data><Sender>ACCOUNTSCENTRE</Sender><MerchantID>2</MerchantID>" & _
                                "<MerchantUID>26</MerchantUID><CustomerID>" & _
                                CustomerID & "</CustomerID><CustomerUID>" & _
                                CustomerUID & "</CustomerUID><OrderID>" & _
                                OrderID & "</OrderID><Mode>" & _
                                Mode & "</Mode><GenericCode>" & _
                                GenericCode & "</GenericCode><PaymentMode>" & _
                                PaymentMode & "</PaymentMode></Data>"

        ReturnValue = "CollectionCXL XML : " & strXML
        '---------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------
        Dim o As New com.webservices.ishops.WebService

        Dim key As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        Dim userid As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        Dim pwd As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        Dim domain As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        Dim res As String = o.CollectionServices(strXML)

        o.Dispose()
        o = Nothing
        '--------------------------------------------------------------------------------------------------------

        Return res
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="ErrorDate"></param>
    ''' <param name="ErrorCode"></param>
    ''' <param name="ErrorMsg"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub AccInsertPaymentErrorLog(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal ErrorDate As DateTime, ByVal ErrorCode As Integer, ByVal ErrorMsg As String)
        Dim objCXLOrder As New CXLOrderProcessing
        objCXLOrder.AccInsertPaymentErrorLog(CustomerID, OrderID, ErrorDate, ErrorCode, ErrorMsg)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="xmlData"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function ConvertXMLToDataSet(ByVal xmlData As String) As DataSet
        Dim stream As StringReader = Nothing
        Dim reader As XmlTextReader = Nothing

        Try
            '---------------------------------
            Dim xmlDS As New DataSet
            stream = New StringReader(xmlData)
            reader = New XmlTextReader(stream)
            xmlDS.ReadXml(reader)
            Return xmlDS
            '---------------------------------
        Catch
            Return Nothing
        Finally
            If Not reader Is Nothing Then reader.Close()
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="LoginID"></param>
    ''' <param name="OrderNo"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub EnableServices(ByVal CustomerID As Integer, ByVal LoginID As Integer, ByVal OrderNo As Integer)

        '-------------------------------------------------------------------------
        Dim objSelectServices As New Administration.BLL.CustomerSelectedServices
        Dim sqlDrOrder As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        Dim strDirectory As String = "D:/CXLProcessRecord"
        Dim strFile As String = "CXLServicesEnable_LogID_" & LoginID & ".txt"
        Dim sbText As New StringBuilder("")
        Dim swFile As StreamWriter = Nothing
        Dim isOpen As Boolean = False
        Dim invoiceDate As Date
        '--------------------------------------------------------------4-----------

        Try
            '-----------------------------------------------------------------------
            'Dim dt As DataTable = objSelectServices.GetCustomerServices(CustomerID)
            'Dim dr As DataRow

            sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, OrderNo, False, True)

            sbText.Append(vbNewLine & "__________________________________________________________________________________" & vbNewLine)
            sbText.Append("Login ID : " & LoginID & vbNewLine & "Customer ID : " & CustomerID & vbNewLine & "Order No. : " & OrderNo & vbNewLine & _
                         "Date : " & Now.ToString & vbNewLine)
            sbText.Append(vbNewLine & "Enabled Service(s)")
            sbText.Append(vbNewLine & "-------------------------------" & vbNewLine)

            '-----------------------------------------------------------------------

            While sqlDrOrder.Read
                invoiceDate = sqlDrOrder("cart_invoice_orderdate")
                '--------------------------------------------------------------------------------------------------------
                ' For Each dr In dt.Rows
                '-----------------------------------------------------------------------------------------------------
                'If dr("ProductCode") = sqlDrOrder("code") Then
                sbText.Append("Start enabled ..... ServiceID : " & sqlDrOrder("ServiceID") & vbTab & "Code : " & sqlDrOrder("Productcode") & vbNewLine)
                objSelectServices.ManageAccountsCentreServices(sqlDrOrder("ServiceID"), CustomerID, LoginID, "Enable", DateAdd(DateInterval.Year, 1, invoiceDate))
                sbText.Append("Finish enabled ..... ServiceID : " & sqlDrOrder("ServiceID") & vbTab & "Code : " & sqlDrOrder("Productcode") & vbNewLine)
                '  Exit For
                'End If
                '-----------------------------------------------------------------------------------------------------
                ' Next
                '--------------------------------------------------------------------------------------------------------
            End While

        Catch ex As Exception
            sbText.Append(vbNewLine & "Exception" & vbNewLine & vbNewLine & ex.Message & vbNewLine & ex.StackTrace)
        Finally
            sqlDrOrder.Close()
        End Try


        Try

            If Not Directory.Exists(strDirectory) Then
                Directory.CreateDirectory(strDirectory)
            End If

            strFile = strDirectory & "/" & strFile

            If File.Exists(strFile) Then
                swFile = File.AppendText(strFile)
            Else
                swFile = File.CreateText(strFile)
            End If

            isOpen = True

            swFile.WriteLine(sbText.ToString)

            swFile.Close()

            isOpen = False
        Catch ex As Exception

            If isOpen Then
                swFile.Close()
            End If
        End Try

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="intCustID"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetOrderNo(ByVal intCustID As Integer) As Integer
        Dim dr As SqlDataReader
        Dim objCXLOrder As New CXLOrderProcessing
        Dim RetVal As Integer = -1

        Try
            dr = objCXLOrder.AccGetOrderDetails(intCustID)
            If dr.Read Then
                RetVal = CInt(dr("OrderNo"))
            End If
        Catch ex As Exception
        Finally
            dr.Close()
        End Try

        Return RetVal
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="PaymentMethod"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetPaymentMethodString() As String
        Dim objCXLOrder As New CXLOrderProcessing
        If objCXLOrder.AccGetPaymentMode() Then
            Return "Live"
        End If

        Return "Test"

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="ReturnValue"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="CustomerID"></param>
    ''' <param name="CardType"></param>
    ''' <param name="CardNo"></param>
    ''' <param name="CardName"></param>
    ''' <param name="CardAddress"></param>
    ''' <param name="CardExpiry"></param>
    ''' <param name="IssueNumber"></param>
    ''' <param name="SecurityCode"></param>
    ''' <param name="StartDate"></param>
    ''' <param name="EndDate"></param>
    ''' <param name="BankName"></param>
    ''' <param name="BankChqNo"></param>
    ''' <param name="BankSortCode"></param>
    ''' <param name="BankRefNo"></param>
    ''' <param name="RPInvAmt"></param>
    ''' <param name="RPPaidAmt"></param>
    ''' <param name="RPOutstandingAmt"></param>
    ''' <param name="RPNewAmt"></param>
    ''' <param name="PayMode"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	23/12/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function RepaymentCXL(ByRef ReturnValue As String, ByVal OrderID As String, ByVal CustomerID As String, _
                                   ByVal CardType As String, ByVal CardNo As String, _
                                   ByVal CardName As String, ByVal CardAddress As String, _
                                   ByVal CardExpiry As String, ByVal IssueNumber As String, _
                                   ByVal SecurityCode As String, ByVal StartDate As String, _
                                   ByVal EndDate As String, ByVal BankName As String, _
                                   ByVal BankChqNo As String, ByVal BankSortCode As String, _
                                   ByVal BankRefNo As String, ByVal RPInvAmt As Double, _
                                   ByVal RPPaidAmt As Double, ByVal RPOutstandingAmt As Double, ByVal RPNewAmt As Double, Optional ByVal PayMode As String = "CC") As String

        '--------------------------------------------------------------------------------------------------------
        Dim strXML As String = "<ShoppingCart>" & _
                             "<OrderInfo>" & _
                             "	<OrderID>" & OrderID & "</OrderID>" & _
                             "	<CustomerID>" & CustomerID & "</CustomerID>" & _
                             "	<MerchantID>2</MerchantID>"
        If PayMode = "CC" Then
            Dim objDate As DateTime

            If CardExpiry <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(CardExpiry, DateTime)
                CardExpiry = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            If StartDate <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(StartDate, DateTime)
                StartDate = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            If EndDate <> String.Empty Then
                '---------------------------------------------------------------------
                objDate = CType(EndDate, DateTime)
                EndDate = objDate.Day & "/" & objDate.Month & "/" & objDate.Year
                '---------------------------------------------------------------------
            End If

            '-------------------------------------------------------------------------
            strXML = strXML & "	<CardType>" & CardType & "</CardType>" & _
                         "	<CardNumber>" & CardNo & "</CardNumber>" & _
                         "	<CardName>" & CardName & "</CardName>" & _
                         "	<CardAddress>" & CardAddress & "</CardAddress>" & _
                         "	<CardExpiry>" & CardExpiry & "</CardExpiry>" & _
                         "	<IssueNumber>" & IssueNumber & "</IssueNumber>" & _
                         "	<SecurityCode>" & SecurityCode & "</SecurityCode>" & _
                         "	<StartDate>" & StartDate & "</StartDate>" & _
                         "	<EndDate>" & EndDate & "</EndDate>" & _
                         "	<BankName></BankName>" & _
                         "	<BankChequeNo></BankChequeNo>" & _
                         "	<BankSortCode></BankSortCode>" & _
                         "	<BankReferenceNumber></BankReferenceNumber>"
            '-------------------------------------------------------------------------
        Else
            '-------------------------------------------------------------------------
            strXML = strXML & "	<CardType></CardType>" & _
                         "	<CardNumber></CardNumber>" & _
                         "	<CardName></CardName>" & _
                         "	<CardAddress></CardAddress>" & _
                         "	<CardExpiry></CardExpiry>" & _
                         "	<IssueNumber></IssueNumber>" & _
                         "	<SecurityCode></SecurityCode>" & _
                         "	<StartDate></StartDate>" & _
                         "	<EndDate></EndDate>" & _
                         "	<BankName> " & BankName & "</BankName>" & _
                         "	<BankChequeNo>" & BankChqNo & "</BankChequeNo>" & _
                         "	<BankSortCode>" & BankSortCode & "</BankSortCode>" & _
                         "	<BankReferenceNumber>" & BankRefNo & "</BankReferenceNumber>"
            '-------------------------------------------------------------------------
        End If

        '----------------------------------------------------------------------------------------
        strXML = strXML & "	<RPInvoiceAmount>" & RPInvAmt & "</RPInvoiceAmount>" & _
                     "	<RPPaidAmount>" & RPPaidAmt & "</RPPaidAmount>" & _
                     "	<RPOutstandingAmount>" & RPOutstandingAmt & "</RPOutstandingAmount>" & _
                     "	<RPNewAmount>" & RPNewAmt & "</RPNewAmount>" & _
                     "</OrderInfo>" & _
                    "</ShoppingCart>"
        '----------------------------------------------------------------------------------------


        ReturnValue = "Repayment XML : " & strXML
        '--------------------------------------------------------------------------------------------------------

        '--------------------------------------------------------------------------------------------------------
        Dim o As New com.webservices.ishops.WebService

        Dim key As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("key"), "xxx")
        Dim userid As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_userid"), key)
        Dim pwd As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_pwd"), key)
        Dim domain As String = DecryptString128Bit(System.Configuration.ConfigurationSettings.AppSettings("ishopswebservices_domain"), key)
        o.Credentials = New System.Net.NetworkCredential(userid, pwd, domain)
        Dim res As String

        res = o.Order_Repayment(strXML)

        o.Dispose()
        o = Nothing
        '--------------------------------------------------------------------------------------------------------
        Return res
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    '''  Calculate the Accounts Centre order amount and also
    '''  return outstanding amount through optional refrense parameter
    ''' </summary>
    ''' <param name="CustomerID"></param>
    ''' <param name="OrderID"></param>
    ''' <param name="SumCartOrderAmount"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	03/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CalculateAccProdAmount(ByVal CustomerID As String, ByVal OrderID As Integer, Optional ByRef SumCartOrderAmount As Double = 0D, Optional ByRef TrackID As Integer = 0) As Double
        '---------------------------------------------
        Dim sqlDrOrder As SqlDataReader
        Dim result As Double = 0
        Dim PreviousPaidAmount, DiscountAmount, _
            CarriageNet, CarriageTaxRate, _
            SumCarriageCharges As Double
        Dim objCXLOrder As New CXLOrderProcessing
        Dim isFirstRecord As Boolean = True
        '---------------------------------------------

        Try
            '-----------------------------------------------------------
            sqlDrOrder = objCXLOrder.AccGetOrderDetails(CustomerID, OrderID)
            '-----------------------------------------------------------

            If sqlDrOrder.Read Then
                If Not IsDBNull(sqlDrOrder.Item("pay_amt")) Then
                    TrackID = sqlDrOrder.Item("pay_amt")
                End If

                'If isFirstRecord Then
                '-------------------------------------------------------------------------
                ' CALCULATION THE SUM OF CART AMOUNT 
                PreviousPaidAmount = Val(sqlDrOrder.Item("pay_amt") & "")
                DiscountAmount = Val(sqlDrOrder.Item("discount") & "")

                'CALCULATE THE TOTAL SHIPMENT CHARGES
                CarriageNet = Val(sqlDrOrder.Item("Carriage") & "")
                CarriageTaxRate = Val(sqlDrOrder.Item("car_tax_rate") & "")
                SumCarriageCharges = CarriageNet + ((CarriageNet * CarriageTaxRate) / 100)

                'isFirstRecord = False
                '-------------------------------------------------------------------------
                'End If

                '----------------------------------------------------------------------------------------------------------
                'result += CDbl(sqlDrOrder("ProdAmount")) ' + CDbl(sqlDrOrder("ProdAmount")) * CDbl(sqlDrOrder("Tax")) / 100)
                result = CDbl(sqlDrOrder("cart_invoice_orderamount"))
                '----------------------------------------------------------------------------------------------------------
            End If

            '---------------------------------------------------------------------------------------
            SumCartOrderAmount = (result + SumCarriageCharges) - DiscountAmount - PreviousPaidAmount
            '---------------------------------------------------------------------------------------

        Catch ex As Exception
        Finally
            '---------------------------------
            If Not sqlDrOrder.IsClosed Then
                sqlDrOrder.Close()
            End If
            '---------------------------------
        End Try

        Return result
    End Function
#End Region

#Region "<<< <<< <<< <<< <<< Encryption/Decryption procedure >>> >>> >>> >>> >>>"

    Private Function EncryptString128Bit(ByVal vstrTextToBeEncrypted As String, _
                                    ByVal vstrEncryptionKey As String) As String

        Dim bytValue() As Byte
        Dim bytKey() As Byte
        Dim bytEncoded() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim objMemoryStream As New MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim objRijndaelManaged As RijndaelManaged


        '   **********************************************************************
        '   ******  Strip any null character from string to be encrypted    ******
        '   **********************************************************************

        vstrTextToBeEncrypted = StripNullCharacters(vstrTextToBeEncrypted)

        '   **********************************************************************
        '   ******  Value must be within ASCII range (i.e., no DBCS chars)  ******
        '   **********************************************************************

        bytValue = Encoding.ASCII.GetBytes(vstrTextToBeEncrypted.ToCharArray)

        intLength = Len(vstrEncryptionKey)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        If intLength >= 32 Then
            vstrEncryptionKey = Strings.Left(vstrEncryptionKey, 32)
        Else
            intLength = Len(vstrEncryptionKey)
            intRemaining = 32 - intLength
            vstrEncryptionKey = vstrEncryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytKey = Encoding.ASCII.GetBytes(vstrEncryptionKey.ToCharArray)

        objRijndaelManaged = New RijndaelManaged

        '   ***********************************************************************
        '   ******  Create the encryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
              objRijndaelManaged.CreateEncryptor(bytKey, bytIV), _
              CryptoStreamMode.Write)
            objCryptoStream.Write(bytValue, 0, bytValue.Length)

            objCryptoStream.FlushFinalBlock()

            bytEncoded = objMemoryStream.ToArray
            objMemoryStream.Close()
            objCryptoStream.Close()
        Catch



        End Try

        '   ***********************************************************************
        '   ******   Return encryptes value (converted from  byte Array to   ******
        '   ******   a base64 string).  Base64 is MIME encoding)             ******
        '   ***********************************************************************

        Return Convert.ToBase64String(bytEncoded)

    End Function

    Private Function DecryptString128Bit(ByVal vstrStringToBeDecrypted As String, _
                                        ByVal vstrDecryptionKey As String) As String

        Dim bytDataToBeDecrypted() As Byte
        Dim bytTemp() As Byte
        Dim bytIV() As Byte = {121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62}
        Dim objRijndaelManaged As New RijndaelManaged
        Dim objMemoryStream As MemoryStream
        Dim objCryptoStream As CryptoStream
        Dim bytDecryptionKey() As Byte

        Dim intLength As Integer
        Dim intRemaining As Integer
        Dim intCtr As Integer
        Dim strReturnString As String = String.Empty
        Dim achrCharacterArray() As Char
        Dim intIndex As Integer

        '   *****************************************************************
        '   ******   Convert base64 encrypted value to byte array      ******
        '   *****************************************************************

        bytDataToBeDecrypted = Convert.FromBase64String(vstrStringToBeDecrypted)

        '   ********************************************************************
        '   ******   Encryption Key must be 256 bits long (32 bytes)      ******
        '   ******   If it is longer than 32 bytes it will be truncated.  ******
        '   ******   If it is shorter than 32 bytes it will be padded     ******
        '   ******   with upper-case Xs.                                  ****** 
        '   ********************************************************************

        intLength = Len(vstrDecryptionKey)

        If intLength >= 32 Then
            vstrDecryptionKey = Strings.Left(vstrDecryptionKey, 32)
        Else
            intLength = Len(vstrDecryptionKey)
            intRemaining = 32 - intLength
            vstrDecryptionKey = vstrDecryptionKey & Strings.StrDup(intRemaining, "X")
        End If

        bytDecryptionKey = Encoding.ASCII.GetBytes(vstrDecryptionKey.ToCharArray)

        ReDim bytTemp(bytDataToBeDecrypted.Length)

        objMemoryStream = New MemoryStream(bytDataToBeDecrypted)

        '   ***********************************************************************
        '   ******  Create the decryptor and write value to it after it is   ******
        '   ******  converted into a byte array                              ******
        '   ***********************************************************************

        Try

            objCryptoStream = New CryptoStream(objMemoryStream, _
               objRijndaelManaged.CreateDecryptor(bytDecryptionKey, bytIV), _
               CryptoStreamMode.Read)

            objCryptoStream.Read(bytTemp, 0, bytTemp.Length)

            objCryptoStream.FlushFinalBlock()
            objMemoryStream.Close()
            objCryptoStream.Close()

        Catch

        End Try

        '   *****************************************
        '   ******   Return decypted value     ******
        '   *****************************************

        Return StripNullCharacters(Encoding.ASCII.GetString(bytTemp))

    End Function

    Private Function StripNullCharacters(ByVal vstrStringWithNulls As String) As String

        Dim intPosition As Integer
        Dim strStringWithOutNulls As String

        intPosition = 1
        strStringWithOutNulls = vstrStringWithNulls

        Do While intPosition > 0
            intPosition = InStr(intPosition, vstrStringWithNulls, vbNullChar)

            If intPosition > 0 Then
                strStringWithOutNulls = Left$(strStringWithOutNulls, intPosition - 1) & _
                                  Right$(strStringWithOutNulls, Len(strStringWithOutNulls) - intPosition)
            End If

            If intPosition > strStringWithOutNulls.Length Then
                Exit Do
            End If
        Loop

        Return strStringWithOutNulls

    End Function

#End Region

#Region "<<< <<< <<< <<< <<< Shared Functions >>> >>> >>> >>> >>>"

    Public Shared Function GetProuctsDependencies() As String
        Dim ht As New Hashtable(20)
        Dim dt As DataTable = BLL.ServicesManager.GetServicesDependencies  'GetPackagesList()
        Dim str As String
        Dim objProdCode As New ArrayList(20)

        For Each dr As DataRow In dt.Rows
            With ht
                If .Contains(dr("PackageCode")) Then
                    ' If CStr(dr("ProductCode")) <> CStr(dr("PackageCode")) Then
                    str = CStr(.Item(dr("PackageCode"))) & "," & CStr(dr("ProductCode"))
                    .Remove(dr("PackageCode"))
                    'End If
                Else
                    str = CStr(dr("ProductCode"))
                    objProdCode.Add(dr("PackageCode"))
                End If

                ' If CStr(dr("PackageCode")) <> CStr(dr("ProductCode")) Then
                .Add(dr("PackageCode"), str)
                ' End If



            End With
        Next

        Dim strBF As New System.Text.StringBuilder("<script> var productName=new Array(), productValues=new Array();")
        Dim items() As String

        For i As Integer = 0 To objProdCode.Count - 1
            items = Split(ht(objProdCode(i)), ",")
            If items Is Nothing Then
                items = New String(0) {""}
            End If

            For j As Integer = 0 To items.Length - 1
                If j = 0 Then
                    strBF.Append(vbNewLine & "productValues[" & i & "]=new Array(); productName[" & i & "]='" & objProdCode(i) & "';  ")
                End If

                strBF.Append(vbNewLine & vbTab & "productValues[" & i & "][" & j & "]='" & items(j) & "';  ")
            Next
        Next

        strBF.Append("</script>")
        Return strBF.ToString

    End Function

    Public Shared Function InsertOrderIntoCxlRobot(ByVal isCreditCard As Boolean, ByVal LoginID As String, ByVal OrderID As Integer, ByVal OrderAmount As Double, ByVal IsRepayment As Boolean, ByVal CardNumber As String, ByVal CardType As String, ByVal CardName As String, ByVal CardAddress As String, ByVal SecurityCode As String, ByVal IssueNo As String, ByVal GenericCode As String, ByVal CurrencyCode As String, ByVal StartDate As String, ByVal CardExpiryDate As String, Optional ByVal TrackID As Integer = 0) As Boolean
        Dim sw As System.IO.StreamWriter
        sw = System.IO.File.CreateText("d:\CXL Processing Trace File.txt")
        sw.WriteLine("In InsertOrderIntoCxlRobot")
        sw.Flush()
        Dim returnVal As Boolean = True

        'Palcing order in CXL Robot

        Dim strPaymentMode As String

        If isCreditCard Then
            strPaymentMode = "cc"
        Else
            strPaymentMode = "cb"
            StartDate = "1/1/2000"
            CardExpiryDate = "1/1/2000"
        End If

        SetStringToEmptyIfNull(CardNumber)
        SetStringToEmptyIfNull(CardType)
        SetStringToEmptyIfNull(CardName)
        SetStringToEmptyIfNull(CardAddress)
        SetStringToEmptyIfNull(SecurityCode)
        SetStringToEmptyIfNull(IssueNo)

        sw.WriteLine("Create InsertInCalls_atcs.InsertionInCalls_Atcs")
        sw.Flush()
        Dim objCxlRobot As New InsertInCalls_atcs.InsertionInCalls_Atcs
        sw.WriteLine("InsertInCalls_atcs.InsertionInCalls_Atcs ok")
        sw.Flush()

        Dim strExpiry() As String = Split(CardExpiryDate, "/")
        Dim dteCardExpire As Date
        Try
            dteCardExpire = New Date(strExpiry(2), strExpiry(0), strExpiry(1)) 'old changed
            sw.WriteLine("CardExpiryDate(old changes): " & CardExpiryDate)
            sw.Flush()
        Catch ex1 As Exception
            Try
                dteCardExpire = New Date(strExpiry(2), strExpiry(1), strExpiry(0)) 'new changed
                sw.WriteLine("CardExpiryDate(new changes): " & CardExpiryDate)
                sw.Flush()
            Catch ex2 As Exception
                Throw ex2
            End Try
        End Try


        sw.WriteLine("New CardExpiryDate: " & dteCardExpire.ToString())
        sw.Flush()


        Dim strStart() As String = Split(StartDate, "/")

        sw.WriteLine("StartDate: " & StartDate.ToString())
        sw.Flush()

        Dim dteStartDate As New Date(strStart(2), strStart(0), strStart(1))

        sw.WriteLine("New dteStartDate: " & dteStartDate.ToString())
        sw.Flush()

        Dim strRepayment As String = IIf(IsRepayment, "r", "n")

        sw.WriteLine("Calling InsertOrder")
        sw.Flush()
        returnVal = objCxlRobot.InsertOrder(2, 26, LoginID, OrderID, OrderAmount, strRepayment, CardNumber, CardType, CardName, CardAddress, dteCardExpire, SecurityCode, IssueNo, strPaymentMode, GenericCode, CurrencyCode, dteStartDate, "AC", TrackID)
        sw.WriteLine("InsertOrder is ok and returnVAl: " & returnVal)
        sw.Flush()
        objCxlRobot = Nothing

        sw.Close()
        Return returnVal
    End Function


    Private Shared Sub SetStringToEmptyIfNull(ByRef Value As String)
        If Value Is Nothing Then Value = ""
    End Sub
#End Region

    Public Sub UpdateInvoiceInfo(ByVal OrderID As Integer, ByVal CreditCardType As String, ByVal CreditCardName As String, ByVal CreditCardNo As String, ByVal CreditCardAddress As String, ByVal CardExpireDate As Date, ByVal IssueNo As String, ByVal SecurityCode As String, ByVal StartDate As Date, ByVal EndDate As Date, ByVal BankName As String, ByVal ChequeNo As String, ByVal SortCode As String, ByVal BankTransferNo As String, Optional ByVal CCStatus As String = "N")
        Dim objUser As New User

        objUser.UpdateInvoiceInfo(OrderID, CreditCardType, CreditCardName, CreditCardNo, CreditCardAddress, CardExpireDate, IssueNo, SecurityCode, StartDate, EndDate, BankName, ChequeNo, SortCode, BankTransferNo, CCStatus)

        objUser = Nothing
    End Sub

    Public Function GetProductUpgrade(Optional ByVal ProductCode As String = Nothing) As DataTable
        Dim ds As DataSet
        Dim cmd As New CommandData

        Try
            With cmd
                .CmdText = "DbServer.InfinishopMaindb.dbo.Admin_GetUpgradeProductByCode"

                If Not ProductCode Is Nothing Then .AddParameter("@ProductCode", ProductCode)

                ds = .Execute(ExecutionType.ExecuteDataSet)

                If ds.Tables.Count > 0 Then Return ds.Tables(0)
            End With
        Catch ex As Exception
        Finally
            cmd.CloseConnection()
        End Try

        Return Nothing

    End Function

    Public Sub UpdateSalePrice(ByVal OrderID As Integer, ByVal ProductCode As String, ByVal ProductAmount As Double)
        Dim cmd As New CommandData

        Try
            With cmd
                .CmdText = "DbServer.M2.dbo.ACC_UpdateInvoiceSalePrice"
                .AddParameter("@OrderID", OrderID)
                .AddParameter("@ProductCode", ProductCode)
                .AddParameter("@Amount", ProductAmount)

                .Execute(ExecutionType.ExecuteNonQuery)
            End With
        Catch ex As Exception
        Finally
            cmd.CloseConnection()
        End Try
    End Sub
End Class

#End Region
