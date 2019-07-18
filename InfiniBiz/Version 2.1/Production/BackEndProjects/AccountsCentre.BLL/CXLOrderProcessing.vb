Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Data
Imports System.Text.RegularExpressions

''' -----------------------------------------------------------------------------
''' Project	 : AccountsCentre.BLL
''' Class	 : AccountsCentre.BLL.CXLOrderProcessing
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' 
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[win.abid]	06/01/2006	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class CXLOrderProcessing

    Public Function AccGetOrderDetails(ByVal CustomerID As Integer, Optional ByVal OrderID As Integer = -1, Optional ByVal IsLast As Boolean = False, Optional ByVal IsServiceList As Boolean = False, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetOrderDetail"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)
                If OrderID <> -1 Then
                    .AddParameter("@OrderNo", OrderID, ParameterDirection.Input)
                End If

                If IsLast Then
                    .AddParameter("@IsLast", IsLast, ParameterDirection.Input)
                End If

                If IsServiceList Then
                    .AddParameter("@IsService", IsServiceList, ParameterDirection.Input)
                End If

                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        '--------
        Return dr
        '--------
    End Function

    Public Function AccGetInvoiceDetails(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetInvoiceDetails"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetInvoiceInfo(ByVal InvocieNo As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetInvoiceInfo"

                'Parameters
                .AddParameter("@InvoiceNo", InvocieNo, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetCustomerData(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetCustomerData"

                'Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With
        Return dr
    End Function

    Public Function AccGetInvoiceRptPdf(ByVal InvocieNo As Integer, ByVal chInvRpt As Char, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "Acc_GetInvoiceRptPdf"

                'Parameters
                .AddParameter("@InvoiceNo", InvocieNo, ParameterDirection.Input)
                .AddParameter("@IsInvRpt", chInvRpt.ToString, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try

        End With

        Return dr
    End Function

    Public Function AccGetPaymentInfo(ByVal CustomerID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "ACC_GetPaymentInfoByCustID"

                ' Parameters
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr

    End Function

    Public Function AccGetInvoicePdfTemplate(Optional ByVal MerchantID As Integer = 2) As SqlDataReader

        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "Acc_GetInvoiceTemplate"
                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function

    Public Function AccGetCompanyInfo(Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "Acc_GetCompanyInfo"
                dr = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With
        Return dr
    End Function

    Public Function AccGetProductDetail(ByVal ProductCode As String, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmdData As New CommandData(MerchantID)
        Dim dr As SqlDataReader

        With cmdData
            Try
                .CmdText = "ACC_GetProductDetails"

                .AddParameter("@Code", ProductCode, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function

    Public Function AccGetPaymentMode() As Boolean
        Dim cmdData As New CommandData
        Dim isLive As Boolean = False

        With cmdData
            Try
                .CmdText = "Dbserver.InfinishopMainDb.dbo.Acc_GetPaymentMode"
                isLive = CType(.Execute(ExecutionType.ExecuteScalar), Boolean)
            Catch ex As Exception
            Finally
                .CloseConnection()
            End Try
        End With

        Return isLive

    End Function

    Public Sub AccInsertPaymentErrorLog(ByVal CustomerID As Integer, ByVal OrderID As Integer, ByVal ErrorDate As DateTime, ByVal ErrorCode As Integer, ByVal ErrorMsg As String)

        Dim cmdData As New CommandData

        With cmdData
            Try
                '---------------------------------------------------------------------------------
                .CmdText = "DbServer.InfinishopMainDb.dbo.Acc_InsertPaymentErrorLog"
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)
                .AddParameter("@OrderID", OrderID, ParameterDirection.Input)
                .AddParameter("@ErrorDate", ErrorDate, ParameterDirection.Input)
                .AddParameter("@ErrorCode", ErrorCode, ParameterDirection.Input)
                .AddParameter("@ErrorMsg", ErrorMsg, ParameterDirection.Input)
                .Execute(ExecutionType.ExecuteNonQuery)
                '---------------------------------------------------------------------------------
            Catch ex As Exception
                Trace.Write("AccInsertPaymentErrorLog generate excception : " & ex.Message)
            Finally
                .CloseConnection()
            End Try
        End With
    End Sub

    Public Function AccGetLogKey(ByVal CustomerID As Integer) As String
        Dim cmd As New CommandData
        Dim dr As SqlDataReader

        With cmd
            Try
                .CmdText = "DbServer.InfinishopMainDb.dbo.ACC_GetLogKey"
                .CmdType = CommandType.StoredProcedure
                .AddParameter("@CustomerID", CustomerID, ParameterDirection.Input)

                dr = .Execute(ExecutionType.ExecuteReader)

                If dr.Read Then
                    Return dr.Item(0)
                End If
            Catch ex As Exception
            Finally
                dr.Close()
                .CloseConnection()
            End Try
        End With
        Return ""
    End Function

    Public Function AccGetResponseCode(ByVal OrderID As Integer, Optional ByVal MerchantID As Integer = 2) As SqlDataReader
        Dim cmddata As New CommandData(MerchantID)
        Dim dr As SqlDataReader
        With cmddata
            Try
                .CmdText = "ACC_GetResponseCode"
                .AddParameter("@OrderID", OrderID)

                dr = .Execute(ExecutionType.ExecuteReader)
            Catch ex As Exception
                dr.Close()
                .CloseConnection()
            End Try
        End With

        Return dr
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' VerifyCreditCardNumber return true if passing
    ''' credit card and its number is perfect.
    ''' </summary>
    ''' <param name="CreditCardName"></param>
    ''' <param name="CreditCardNumber"></param>
    ''' <param name="SecurityCode"></param>
    ''' <param name="ErrorMessage"></param>
    ''' <returns>True/False</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	20/02/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function VerifyCreditCardNumber(ByVal CreditCardName As String, ByVal CreditCardNumber As String, ByVal SecurityCode As String, ByRef ErrorMessage As String) As Boolean
        '----------------------------------------------
        ' Default return false & ErrorMessage is empty
        VerifyCreditCardNumber = False
        ErrorMessage = ""
        '----------------------------------------------

        '------------------------------------------------------------------------------------------------
        ' Local Variable Declaration
        Dim prefixes As Integer
        Dim isCheckDigit As Boolean = True  ' LUHN's formula required for card

        ' Error Declaration
        Const errorUnknownCard As String = "<li>Unknown card type<br>"
        Const errorNoCardProvided As String = "<li>No card number provided<br>"
        Const errorInvalidCardNoFormat As String = "<li>Credit card number is in invalid format<br>"
        Const errorInvalidCardNo As String = "<li>Credit card number is invalid<br>"
        Const errorInappropriateDigits As String = "<li>Credit card number has an inappropriate number of digits<br>"

        '   NOTE
        '   ~~~~~
        '   For more information download javascript file from 
        '   URL -->   http://www.braemoor.co.uk/software/creditcard.shtml
        '------------------------------------------------------------------------------------------------

        '--------------------------------------------------------------
        'Credit Card List
        '~~~~~~~~~~~~~~~~
        '1) Visa Card 
        '2) Master Card / Euro Card
        '3) Diners Club / Carte Balanche
        '4) Discover
        '5) enRoute
        '6) JCB
        '7) AMEX Card
        '8) Debit Card
        '9) Switch Card

        ' Verify Card Name and Length of Card Number
        Select Case UCase(CreditCardName)
            Case "VISA CARD"
                '----------------------------------------------------------
                'Visa Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 13,16
                '2) Prefixes                : 4
                '3) Length of Security Code : 3
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 13 OrElse .Length = 16 Then
                        '-----------------------------------------
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 1))

                        If prefixes <> 4 Then
                            ErrorMessage &= errorInvalidCardNo
                        End If
                        '-----------------------------------------

                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

                With SecurityCode
                    If .Length <> 0 AndAlso .Length <> 3 Then
                        '----------------------------------------------------------
                        ErrorMessage &= "<li>Security code must be three digits long<br>"
                        '----------------------------------------------------------
                    End If
                End With

            Case "MASTER CARD / EURO CARD"
                '----------------------------------------------------------
                'Master / Euro Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 16
                '2) Prefixes                : 51,52,53,54,55
                '3) Length of Security Code : 3
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 16 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 2))

                        If prefixes < 51 OrElse prefixes > 55 Then
                            ErrorMessage &= errorInvalidCardNo
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

                With SecurityCode
                    If .Length <> 0 AndAlso .Length <> 3 Then
                        '----------------------------------------------------------
                        ErrorMessage &= "<li>Security code must be three digits long<br>"
                        '----------------------------------------------------------
                    End If
                End With

            Case "DINERS CLUB / CARTE BALANCHE"
                '----------------------------------------------------------
                'Diners Club / Carte Balanche Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 14
                '2) Prefixes                : 300,301,302,303,304,305,36,38
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 14 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 2))

                        If prefixes <> 36 AndAlso prefixes <> 38 Then
                            '-----------------------------------------------
                            prefixes = CInt(.Substring(0, 3))

                            If prefixes < 301 OrElse prefixes > 305 Then
                                '-----------------------------------------
                                ErrorMessage &= errorInvalidCardNo
                                '-----------------------------------------
                            End If
                            '-----------------------------------------------
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

            Case "DISCOVER"
                '----------------------------------------------------------
                'Discover Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 16
                '2) Prefixes                : 6011
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 16 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 4))

                        If prefixes <> 6011 Then
                            '-----------------------------------------
                            ErrorMessage &= errorInvalidCardNo
                            '-----------------------------------------
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

            Case "ENROUTE"
                '----------------------------------------------------------
                'Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 15
                '2) Prefixes                : 2014,2149
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 15 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 4))

                        If prefixes <> 2014 AndAlso prefixes <> 2149 Then
                            '-----------------------------------------
                            ErrorMessage &= errorInvalidCardNo
                            '-----------------------------------------
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

            Case "JCB"
                '----------------------------------------------------------
                'JCB Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 15,16
                '2) Prefixes                : 3,1800,2131
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 15 OrElse .Length = 16 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 1))

                        If prefixes <> 3 Then
                            '-----------------------------------------------
                            prefixes = CInt(.Substring(0, 4))

                            If prefixes <> 1800 AndAlso prefixes <> 2131 Then
                                '-----------------------------------------
                                ErrorMessage &= errorInvalidCardNo
                                '-----------------------------------------
                            End If
                            '-----------------------------------------------
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

            Case "AMEX CARD"
                '----------------------------------------------------------
                'AMEX Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 15
                '2) Prefixes                : 34,37
                '3) Length of Security Code : 4
                '4) Check Digits            : TRUE
                '----------------------------------------------------------

                With CreditCardNumber
                    If .Length = 15 Then
                        '-----------------------------------------
                        prefixes = CInt(.Substring(0, 2))

                        If prefixes <> 34 AndAlso prefixes <> 37 Then
                            ErrorMessage &= errorInvalidCardNo
                        End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

                With SecurityCode
                    If .Length <> 0 AndAlso .Length <> 4 Then
                        '----------------------------------------------------------
                        ErrorMessage &= "<li>Security code must be four digits long<bR>"
                        '----------------------------------------------------------
                    End If
                End With

            Case "DEBIT CARD"
                '----------------------------------------------------------
                'Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : 16
                '2) Prefixes                : UnKnown
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : UnKnown
                '----------------------------------------------------------
                'isCheckDigit = False

                With CreditCardNumber
                    If .Length >= 14 AndAlso .Length <= 16 Then
                        '-----------------------------------------
                        'prefixes = CInt(.Substring(0, 2))

                        'If prefixes <> 34 AndAlso prefixes <> 37 Then
                        '    ErrorMessage &= errorInvalidCardNo
                        'End If
                        '-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With

            Case "SWITCH CARD"
                '----------------------------------------------------------
                'Card's Properties
                '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                '1) Length                  : UnKnown
                '2) Prefixes                : UnKnown
                '3) Length of Security Code : UnKnown
                '4) Check Digits            : UnKnown
                '----------------------------------------------------------
                'isCheckDigit = False

                With CreditCardNumber
                    If .Length >= 16 AndAlso .Length <= 19 Then
                        ''-----------------------------------------
                        'prefixes = CInt(.Substring(0, 2))

                        'If prefixes <> 34 AndAlso prefixes <> 37 Then
                        '    ErrorMessage &= errorInvalidCardNo
                        'End If
                        ''-----------------------------------------
                    Else
                        '------------------------------------------
                        ErrorMessage &= errorInappropriateDigits
                        '------------------------------------------
                    End If
                End With
            Case Else
        End Select
        '----------------------------------------------

        If ErrorMessage = "" Then
            '------------------------------------------
            VerifyCreditCardNumber = True
            If isCheckDigit AndAlso (Not Me.LUHNFormula(CreditCardNumber)) Then
                '-------------------------------------------------------------------------------------------------------------
                VerifyCreditCardNumber = False
                ErrorMessage = errorInvalidCardNoFormat
                '-------------------------------------------------------------------------------------------------------------
            End If
            '------------------------------------------
        Else
            '-----------------------------
            VerifyCreditCardNumber = False
            '-----------------------------
        End If

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' </summary>
    ''' <param name="CardNumber"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	20/02/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function LUHNFormula(ByVal CardNumber As String) As Boolean
        '-------------------------------------------------------
        ' Declaration
        Dim checkSum, calc, loopCounter, multiplier As Integer
        checkSum = 0
        multiplier = 1
        LUHNFormula = False
        '-------------------------------------------------------

        With CardNumber
            'Process each digit one by one starting at the right
            loopCounter = .Length - 1

            While loopCounter >= 0

                'Extract the next digit and multiply by 1 or 2 on alternative digits.
                calc = CInt(.Chars(loopCounter).ToString) * multiplier

                'If the result is in two digits add 1 to the checksum total
                If calc > 9 Then
                    checkSum += 1
                    calc -= 10
                End If

                'Add the units element to the checksum total
                checkSum += calc

                'Switch the value of j
                multiplier = IIf(multiplier = 1, 2, 1)

                ' decreament loopCounter
                loopCounter -= 1
            End While

        End With

        'All done - if checksum is divisible by 10, it is a valid modulus 10.
        'If not, report an error.

        ' If checkSum is multiple of 10 then return true
        If checkSum Mod 10 = 0 Then
            LUHNFormula = True
        End If

    End Function
    Public Function GetReSellerOrderDetails(ByVal CustomerID As Integer, Optional ByVal OrderID As Integer = -1, Optional ByVal IsLast As Boolean = False, Optional ByVal IsServiceList As Boolean = False, Optional ByVal MerchantID As Integer = 2) As DataSet
        ''' Created by Muhammad Ubaid
        ''' It returns the ReSellerOrders
        Dim cmdData As New CommandData(MerchantID)
        Dim ds As DataSet
        With cmdData
            Try
                .CmdType = CommandType.StoredProcedure
                .CmdText = "Acc_Get_ReSeller_Customer_Order"
                .AddParameter("@CustomerId", CustomerID)

                If OrderID <> -1 Then
                    .AddParameter("@OrderNo", OrderID, ParameterDirection.Input)
                End If

                If IsLast Then
                    .AddParameter("@IsLast", IsLast, ParameterDirection.Input)
                End If

                If IsServiceList Then
                    .AddParameter("@IsService", IsServiceList, ParameterDirection.Input)
                End If

                ds = .Execute(ExecutionType.ExecuteDataSet)

            Catch ex As Exception
                .CloseConnection()
            End Try
        End With
        Return ds
    End Function
End Class
