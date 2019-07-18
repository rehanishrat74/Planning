#Region "Imports"
Imports sql = System.Data.SqlClient
Imports dal = InfiniLogic.AccountsCentre.DAL
#End Region

Public Class AnnualAccounts

#Region "Constructors and Declarations"
    Public Sub New()
        'DAL.SqlHelper.ConnectionString = DAL.Connection.GetConnectionString
    End Sub
#End Region

#Region "Public Functions"
    Public Function GetAnnualAccountsStatus(ByVal CustomerID As Integer) As DataTable
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(0) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        Return DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_GetAnnualAccountsStatus", sqlParams).Tables(0)
    End Function
    Public Function GetAnnualAccountsStatus(ByVal CustomerID As Integer, ByVal sARD As String, ByVal dtIncDate As Date) As DataTable
        Dim dtblAnnualAccounts As DataTable
        dtblAnnualAccounts = GetAnnualAccountsStatus(CustomerID)
        Dim dcCol As DataColumn

        Dim iCnt As Integer
        For iCnt = 1 To 3
            dcCol = New DataColumn
            dcCol.ColumnName = Choose(iCnt, "ARD", "DueDate", "Status")
            dcCol.DataType = Choose(iCnt, System.Type.GetType("System.DateTime"), System.Type.GetType("System.DateTime"), System.Type.GetType("System.String"))
            dtblAnnualAccounts.Columns.Add(dcCol)
        Next iCnt

        Dim dr As DataRow

        Dim iYearStart As Integer
        Dim iMonth As Integer, iDay As Integer, strARD() As String
        Dim dtARD As Date, dtDueDate As Date
        Dim isOverDue As Boolean = False

        Dim isArdNext As Boolean = False
        Dim isArdLast As Boolean = False
        Dim dtArdNext, dtArdLast As Date

        'First Process records returned by SP
        For Each dr In dtblAnnualAccounts.Rows
            strARD = Split(dr("vARD"), "/")

            iDay = strARD(0)
            iMonth = strARD(1)
            iYearStart = dr("FromYear")

            If iDay = 29 And iMonth = 2 And IsDate(iDay & "/" & MonthName(iMonth) & "/" & dr("ToYear")) = False Then
                iDay = 28
                'Return Nothing
                'Exit Function
            End If

            dtARD = DateValue(iDay & "/" & MonthName(iMonth) & "/" & dr("ToYear"))
            dtDueDate = DateAdd(DateInterval.Month, 9, dtARD)

            dr("ARD") = dtARD
            dr("DueDate") = dtDueDate
            dr("Status") = GetStatus(dtARD, dtDueDate, dr("IsSubmitted"))


            'If IsDBNull(dr("IsSubmitted")) = False Then
            '    If dr("IsSubmitted") = True Then
            '        dr("Status") = "SUBMITTED"
            '    End If
            'End If

            If IsDBNull(dr("ArdNext")) Then
                dr("Status") = GetStatus(dtARD, dtDueDate, dr("IsSubmitted"))
                isArdNext = False


                'If isOverDue Then
                '    dr("Status") = "CLOSED/HALT"
                'End If

                'If (dr("Status") = "OVER DUE") Then
                '    isOverDue = True
                'End If
            Else
                isArdNext = True
                dtArdNext = DateValue(dr("ArdNext"))


                If Not IsDBNull(dr("ArdLast")) Then

                    isArdLast = True
                    dtArdLast = DateValue(dr("ArdLast"))


                    If dtDueDate <= dtArdLast Then
                        dr("Status") = "SUBMITTED"
                    Else
                        dr("Status") = GetStatus(dtARD, dtArdNext, dr("IsSubmitted"))
                    End If
                Else
                    isArdLast = False

                    dr("Status") = GetStatus(dtARD, dtArdNext, dr("IsSubmitted"))
                End If
            End If

        Next

        'Then add Records of years not entered in database with the help of ARD and IncDate (if available)
        If sARD <> "" And dtIncDate <> Nothing Then
            strARD = Split(sARD, "/")

            iDay = strARD(0)
            iMonth = strARD(1)
            iYearStart = Year(dtIncDate)

            Dim iCntr As Integer, iResult As Integer
            For iCntr = iYearStart To Year(Today)

                dtblAnnualAccounts.DefaultView.Sort = "FromYear"
                iResult = dtblAnnualAccounts.DefaultView.Find(iCntr)

                If iResult < 0 Then
                    Dim drAnnualAccounts As DataRow
                    drAnnualAccounts = dtblAnnualAccounts.NewRow

                    'CustomerID, Year, ARD, DueDate, SubmissionDate, Status, ToYear
                    If iDay = 29 And iMonth = 2 And IsDate(iDay & "/" & MonthName(iMonth) & "/" & iCntr + 1) = False Then
                        iDay = 28
                        'Return Nothing
                        'Exit Function
                    End If


                    dtARD = DateValue(iDay & "/" & MonthName(iMonth) & "/" & iCntr + 1)
                    dtDueDate = DateAdd(DateInterval.Month, 9, dtARD)
                    With drAnnualAccounts
                        .Item("CustomerID") = CustomerID
                        .Item("Year") = Trim(Str(iCntr)) & "-" & Trim(Str(iCntr + 1))
                        .Item("ARD") = dtARD
                        .Item("DueDate") = dtDueDate
                        .Item("Status") = GetStatus(dtARD, dtDueDate)
                        .Item("FromYear") = iCntr


                        If Not isArdNext Then
                            .Item("Status") = GetStatus(dtARD, dtDueDate)

                        Else


                            If Not IsDBNull(dr("ArdLast")) Then



                                If dtDueDate <= dtArdLast Then
                                    .Item("Status") = "SUBMITTED"
                                Else
                                    .Item("Status") = GetStatus(dtARD, dtArdNext)
                                End If
                            Else

                                .Item("Status") = GetStatus(dtARD, dtArdNext)
                            End If
                        End If
                    End With
                    dtblAnnualAccounts.Rows.Add(drAnnualAccounts)

                End If
            Next
        End If

        ''Due status will be checked easily later by filter
        Return dtblAnnualAccounts
    End Function
    Public Function IsCTReturnAllowed(ByVal CustomerID As Integer) As Boolean
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(1) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        sqlParams(1) = New sql.SqlParameter("@iServiceID", SqlDbType.Int)
        sqlParams(1).Direction = ParameterDirection.Input
        sqlParams(1).Value = ServiceID.CTReturn

        Dim sqlDR As sql.SqlDataReader
        sqlDR = DAL.SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_IsServiceAllowed", sqlParams)
        Dim bHasRows As Boolean = sqlDR.HasRows

        If Not sqlDR Is Nothing Then
            sqlDR.Close()
            sqlDR = Nothing
        End If

        Return bHasRows
    End Function
#End Region

    Private Function IsValidARD(ByVal sARD As String) As Boolean
        If Trim(sARD) = "" Then GoTo fls 'No Blank
        Dim strARD() As String = Split(sARD, "/")
        If strARD.Length <> 2 Then GoTo fls 'must have two parts sep. with /
        If IsNumeric(strARD(0)) = False Then GoTo fls ' first part must be numeric
        If IsNumeric(strARD(1)) = False Then GoTo fls ' second part must also be numeric
        If Not (strARD(0) >= 1 AndAlso strARD(0) <= 31) Then GoTo fls ' 1st part is day so should not exceed 31
        If Not (strARD(1) >= 1 AndAlso strARD(1) <= 12) Then GoTo fls ' 2nd part is mon so should not exceed 12
tru:
        Return True
fls:
        Return False
    End Function


#Region "Helper Functions"
    Private Function GetStatus(ByVal dtARD As Date, ByVal dtDueDate As Date, Optional ByVal bSubmitted As Boolean = False) As String
        If bSubmitted = True Then
            Return "SUBMITTED"
        ElseIf Today < dtARD Then
            Return "NOT DUE"
        ElseIf Today >= dtARD And Today <= dtDueDate Then
            Return "DUE"
        ElseIf Today > dtDueDate Then
            Return "OVER DUE"
        End If
    End Function
#End Region

End Class
