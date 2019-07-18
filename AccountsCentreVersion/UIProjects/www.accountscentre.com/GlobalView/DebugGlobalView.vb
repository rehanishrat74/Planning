#Region "Imports"
Imports sql = System.Data.SqlClient
Imports dal = InfiniLogic.AccountsCentre.DAL
Imports System.Web

#End Region

Public Class DebugGlobalView
#Region " Declarations"
    Private objFHServices As com.formationshouse.www.FHservices

    Public Sub New()
        DAL.SqlHelper.ConnectionString = DAL.Connection.GetConnectionString
    End Sub
#End Region

#Region " Public Functions"
    Public Function GetParentUserGlobalViewStatus(ByVal CustomerID As Integer) As sql.SqlDataReader
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(0) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        Return DAL.SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_ParentUserGlobalViewStatus", sqlParams)
    End Function
    Public Function getAllCompaniesByFH(ByVal CustomerID As Integer, ByRef dtFHCompanies As DataTable, ByVal bUpdateINCnARDs As Boolean) As DataTable
        Try

            HttpContext.Current.Trace.Write("AgaingetData start")

            Dim dsCompanies As New DataSet("Companies")
            HttpContext.Current.Trace.Write("customerid=" & CustomerID)
            Dim dtACCompanies As DataTable = getRegisteredCompanies(CustomerID)
            HttpContext.Current.Trace.Write("33")
            If dtFHCompanies Is Nothing Then Return dtACCompanies
            HttpContext.Current.Trace.Write("35")
            dtFHCompanies.TableName = "FHCompanies"
            dsCompanies.Merge(dtFHCompanies)
            HttpContext.Current.Trace.Write("38")
            dtACCompanies.TableName = "ACCompanies"
            dsCompanies.Merge(dtACCompanies)
            HttpContext.Current.Trace.Write("41")
            Dim rCompanyName As DataRelation

            Dim parent As DataColumn = dsCompanies.Tables("FHCompanies").Columns("CompanyNumber")
            HttpContext.Current.Trace.Write("45")
            Dim child As DataColumn = dsCompanies.Tables("ACCompanies").Columns("CompRegNo")               'xDim child As DataColumn = dsCompanies.Tables("ACCompanies").Columns("CompName")
            HttpContext.Current.Trace.Write("47")
            Dim sRelationName As String = "FH_AC_CompanyName"

            rCompanyName = New DataRelation(sRelationName, parent, child, False)
            HttpContext.Current.Trace.Write("51")
            dsCompanies.Relations.Add(rCompanyName)
            HttpContext.Current.Trace.Write("53")
            Dim r As DataRow, iCntr As Integer = 1
            For Each r In dsCompanies.Tables("FHCompanies").Rows
                HttpContext.Current.Trace.Write("56")
                Dim rRegComp() As DataRow = r.GetChildRows(dsCompanies.Relations.Item(0))
                HttpContext.Current.Trace.Write("58")
                If rRegComp.Length = 0 Then
                    Dim rACCompany As DataRow
                    rACCompany = dtACCompanies.NewRow
                    HttpContext.Current.Trace.Write("62")
                    With rACCompany
                        HttpContext.Current.Trace.Write("64")
                        .Item("CompName") = r.Item("CompanyName")
                        HttpContext.Current.Trace.Write("66")
                        If IsDBNull(r.Item("CompanyName")) = False Then
                            HttpContext.Current.Trace.Write("68")
                            .Item("UpperCompName") = UCase(CType(r.Item("CompanyName"), String))
                            HttpContext.Current.Trace.Write("78")
                        Else
                            HttpContext.Current.Trace.Write("72")
                            .Item("UpperCompName") = ""
                            HttpContext.Current.Trace.Write("74")
                        End If
                        .Item("CompRegNo") = r.Item("CompanyNumber")
                        HttpContext.Current.Trace.Write("77")
                        .Item("CompFax") = r.Item("Fax")
                        HttpContext.Current.Trace.Write("79")
                        .Item("CompEmail") = r.Item("Email")
                        HttpContext.Current.Trace.Write("81")
                        .Item("CompPhone") = r.Item("Telephone")
                        HttpContext.Current.Trace.Write("83")
                        .Item("CompWebSite") = r.Item("Website")
                        HttpContext.Current.Trace.Write("85")
                        .Item("FullAddress") = r.Item("Address")
                        HttpContext.Current.Trace.Write("87")
                        .Item("CompDirector") = r.Item("Director")
                        HttpContext.Current.Trace.Write("89")
                        .Item("CompSec") = r.Item("Secretary")
                        HttpContext.Current.Trace.Write("91")
                        .Item("IncDate") = r.Item("IncorporationDate")
                        HttpContext.Current.Trace.Write("93")
                        .Item("TaggedCompName") = r.Item("CompanyName")
                        HttpContext.Current.Trace.Write("95")
                        .Item("GVStatus") = 0
                        HttpContext.Current.Trace.Write("97")

                        Dim eFilingDate As Date = Nothing
                        If IsDBNull(r.Item("ARD")) = False AndAlso IsValidARD(r.Item("ARD")) Then
                            HttpContext.Current.Trace.Write("101")
                            If r.Item("ARD") = "29/2" Or r.Item("ARD") = "29/02" Then
                                eFilingDate = CDate("28/February/" & "/" & Year(Date.Today))
                                HttpContext.Current.Trace.Write("104")
                            ElseIf r.Item("ARD") <> "" Then
                                eFilingDate = CDate(r.Item("ARD") & "/" & Year(Date.Today))
                                HttpContext.Current.Trace.Write("107")
                            End If
                        End If

                        If eFilingDate <> Nothing Then .Item("eFilingDate") = eFilingDate
                        HttpContext.Current.Trace.Write("112")
                        .Item("ARD") = r.Item("ARD")
                        HttpContext.Current.Trace.Write("114")
                        .Item("ID") = "Z_" + CStr(iCntr)
                        HttpContext.Current.Trace.Write("116")
                        .Item("DissolvedDate") = r.Item("DissolvedDate")
                        HttpContext.Current.Trace.Write("118")
                        .Item("Dormant") = IIf(IsDBNull(r.Item("Dormant")), "", r.Item("Dormant"))
                        HttpContext.Current.Trace.Write("120")
                        iCntr += 1
                    End With

                    dtACCompanies.Rows.Add(rACCompany)
                    HttpContext.Current.Trace.Write("125")
                Else
                    If IsDBNull(r.Item("IncorporationDate")) = False Then : If r.Item("IncorporationDate") <> Nothing Then
                            HttpContext.Current.Trace.Write("128")
                            rRegComp(0).Item("IncDate") = r.Item("IncorporationDate")
                            HttpContext.Current.Trace.Write("130")
                        End If : End If

                    If IsDBNull(r.Item("ARD")) = False AndAlso IsValidARD(r.Item("ARD")) Then : If r.Item("ARD") <> Nothing Then
                            HttpContext.Current.Trace.Write("134")
                            rRegComp(0).Item("ARD") = r.Item("ARD")
                            HttpContext.Current.Trace.Write("136")
                        End If : End If

                    rRegComp(0).Item("DissolvedDate") = r.Item("DissolvedDate")
                    HttpContext.Current.Trace.Write("140")
                    rRegComp(0).Item("Dormant") = IIf(IsDBNull(r.Item("Dormant")), "", r.Item("Dormant"))
                    HttpContext.Current.Trace.Write("142")
                End If
            Next r

            dsCompanies.Dispose() : dsCompanies = Nothing
            HttpContext.Current.Trace.Write("147")
            parent.Dispose() : parent = Nothing
            HttpContext.Current.Trace.Write("149")
            child.Dispose() : child = Nothing
            HttpContext.Current.Trace.Write("151")
            rCompanyName = Nothing

            If bUpdateINCnARDs = False Then
                HttpContext.Current.Trace.Write("154")
                If UpdateINCnARDs(dtACCompanies) = True Then
                    HttpContext.Current.Trace.Write("157")
                    bUpdateINCnARDs = True

                End If
            End If
            HttpContext.Current.Trace.Write("162")
            dtACCompanies.DefaultView.Sort = "ID"
            HttpContext.Current.Trace.Write("164")
            Return dtACCompanies
        Catch ex As Exception
            HttpContext.Current.Trace.Write("167")
            Return Nothing
        End Try
    End Function
    Public Function getAllCompanies(ByVal CustomerID As Integer, ByVal LoginID As String, ByRef bFHProblem As Boolean) As DataTable
        Dim dsCompanies As New DataSet("Companies")

        Dim dtFHCompanies As DataTable = getFormationHouseCompanies(LoginID)

        bFHProblem = dtFHCompanies Is Nothing
        Return dtFHCompanies
    End Function
    Public Function GetUserInformation(ByVal CustomerID As Integer) As sql.SqlDataReader
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(0) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        Return DAL.SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_GetGlobalViewInfo", sqlParams)
    End Function
    Public Function GetRegisteredCompanyInfo(ByVal CustomerID As Integer) As sql.SqlDataReader
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(0) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        Return DAL.SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_GetRegisteredCompanyInfo", sqlParams)
    End Function
    Public Function AddInGlobalView(ByVal CustomerID As Integer, ByVal MemberCustomerID As Integer, Optional ByVal bAsExcluded As Boolean = False, Optional ByVal bReturnDuplicateErrorMsg As Boolean = False) As String
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(4) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        sqlParams(1) = New sql.SqlParameter("@nMemberCustomerID", SqlDbType.BigInt)
        sqlParams(1).Direction = ParameterDirection.Input
        sqlParams(1).Value = MemberCustomerID

        sqlParams(2) = New sql.SqlParameter("@bAsExcluded", SqlDbType.Bit)
        sqlParams(2).Direction = ParameterDirection.Input
        sqlParams(2).Value = bAsExcluded

        sqlParams(3) = New sql.SqlParameter
        sqlParams(3).Direction = ParameterDirection.ReturnValue

        sqlParams(4) = New sql.SqlParameter("@bCheckACU", SqlDbType.Bit)
        sqlParams(4).Direction = ParameterDirection.Input
        sqlParams(4).Value = True


        Try
            DAL.SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "DBSERVER.Infinishopmaindb.dbo.ACC_AddInGlobalView", sqlParams)
            If sqlParams(3).Value = 3 Then
                Return "Customer with the given ID is <b>NOT</b> a Registered member of <B>Accounts Centre</B>."
                'ElseIf sqlParams(3).Value = 2 Then
                '    Return "Customer with the given ID is already a part of <B>Global View</B> as an <B>Excluded</B> Customer."
                'ElseIf sqlParams(3).Value = 1 Then
                '    Return "Customer with the given ID is already a part of <B>Global View</B>."
            ElseIf sqlParams(3).Value = 1 Then
                Return "There were some errors. Retry later."
            End If
        Catch sqlEx As sql.SqlException
            If sqlEx.Number = 2627 Then
                If bReturnDuplicateErrorMsg Then
                    Return "Customer with the given ID is already added in a <B>Global View</B>."
                Else
                    Return ""
                End If
            End If
            Throw sqlEx
        End Try
    End Function
    Public Function getDirectorNSecretary(ByVal FHDirsNSects As com.formationshouse.www.OfficerInfo()) As String()
        Const MAXLIMIT As Integer = 500

        Dim sDirSec(1) As String
        Dim FHDirNSec As com.formationshouse.www.OfficerInfo

        'if FHDirNSec.corporate is 0 then it is non corporate and it means there will be no forename available 
        'if FHDirNSec.type is 0 Then it is Director else if it is 1 then it is Secretary

        Dim bSurNameSpace As Boolean
        Dim bForenameSpaceNComa As Boolean
        Dim sTempName As String

        For Each FHDirNSec In FHDirsNSects
            If FHDirNSec.type = 0 Then 'Director

                bSurNameSpace = Len(Trim(FHDirNSec.surname)) > 0
                bForenameSpaceNComa = bSurNameSpace Or (Len(Trim(FHDirNSec.forename)) > 0)
                sTempName = FHDirNSec.surname + IIf(bSurNameSpace, " ", "") + FHDirNSec.forename & IIf(bForenameSpaceNComa, ",", "")

                If Len(sDirSec(0) + sTempName) <= MAXLIMIT Then sDirSec(0) += sTempName

            ElseIf FHDirNSec.type = 1 Then  'Secretary

                bSurNameSpace = Len(Trim(FHDirNSec.surname)) > 0
                bForenameSpaceNComa = bSurNameSpace Or (Len(Trim(FHDirNSec.forename)) = 0)
                sTempName = FHDirNSec.surname + IIf(bSurNameSpace, " ", "") + FHDirNSec.forename & IIf(bForenameSpaceNComa, ",", "")

                If Len(sDirSec(1) + sTempName) <= MAXLIMIT Then sDirSec(1) += sTempName
            End If
        Next

        If Len(sDirSec(0)) >= 1 And Right(sDirSec(0), 1) = "," Then sDirSec(0) = Left(sDirSec(0), Len(sDirSec(0)) - 1)
        If Len(sDirSec(1)) >= 1 And Right(sDirSec(1), 1) = "," Then sDirSec(1) = Left(sDirSec(1), Len(sDirSec(1)) - 1)

        Return sDirSec
    End Function
    Public Function getAddressString(ByVal FHAddInfo As com.formationshouse.www.AddressInfo) As String
        Dim sAddress As String
        If Not FHAddInfo Is Nothing Then
            sAddress = FHAddInfo.line1 + IIf(Len(FHAddInfo.line1) > 0, " ", "")
            sAddress += FHAddInfo.line2 + IIf(Len(FHAddInfo.line2) > 0, " ", "")
            sAddress += FHAddInfo.line3 + IIf(Len(FHAddInfo.line3) > 0, " ", "")
            sAddress += FHAddInfo.country

            sAddress += IIf(Len(sAddress) > 0, ",", "")

            If Len(sAddress) >= 1 And Right(sAddress, 1) = "," Then sAddress = Left(sAddress, Len(sAddress) - 1)
        End If
        Return sAddress
    End Function
    Public Function getCompanyAddressString(ByVal FHAddInfo As com.formationshouse.www.AddressInfo) As String
        Dim sAddress As String = ""
        If Not FHAddInfo Is Nothing Then
            sAddress = FHAddInfo.line1 + IIf(Len(FHAddInfo.line1) > 0, " ", "")
            sAddress += FHAddInfo.line2 + IIf(Len(FHAddInfo.line2) > 0, " ", "")
            sAddress += FHAddInfo.line3
        End If
        Return sAddress
    End Function
    Public Shared Function SetARD(ByVal CompanyName As String, ByVal CompanyNumber As String, ByVal LastARD As Date) As String
        Dim objFHS As com.formationshouse.www.FHservices
        objFHS = New com.formationshouse.www.FHservices
        Dim ci As New com.formationshouse.www.cinfo
        Try : With ci
                .companyname = CompanyName
                .companynumber = CompanyNumber
                .lastArd = Format(LastARD, "yyyy-mm-dd")
            End With
            Return objFHS.setLastArd(ci)
        Finally
            If IsNothing(objFHS) = False Then
                objFHS.Dispose()
                objFHS = Nothing
            End If
            If IsNothing(ci) = False Then ci = Nothing
        End Try
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

#Region " Helper Functions"
    Private Function getRegisteredCompanies(ByVal CustomerID As Integer) As DataTable
        Dim sqlParams() As sql.SqlParameter
        sqlParams = New sql.SqlParameter(0) {}

        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Direction = ParameterDirection.Input
        sqlParams(0).Value = CustomerID

        Return DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBGateWay.dbo.ACC_GetRegisteredCompanies", sqlParams).Tables(0)
    End Function
    Private Function getFormationHouseCompanies(ByVal LoginID As Integer) As DataTable
        'Create Formation House Services Instance and Get Company Infos
        Try
            System.Net.ServicePointManager.CertificatePolicy = New TrustAllCertificatePolicy
            objFHServices = New com.formationshouse.www.FHservices
            Dim CInfos() As com.formationshouse.www.CompanyInfo
            CInfos = objFHServices.getCompanies(LoginID)

            'Create Data Table with columns having Company Info Structure
            Dim tblFHCompanies As New System.Data.DataTable
            Dim col As DataColumn
            Dim iCnt As Int16

            For iCnt = 1 To 13
                col = New DataColumn
                col.ColumnName = Choose(iCnt, "CompanyName", "CompanyNumber", "IncorporationDate", "Telephone", "Fax", "Email", "Website", "Address", "Director", "Secretary", "ARD", "DissolvedDate", "Dormant")
                tblFHCompanies.Columns.Add(col)
            Next iCnt

            'Fill the table with rows reflecting each individual Company Info
            Dim CInfo As com.formationshouse.www.CompanyInfo
            Dim r As DataRow
            For Each CInfo In CInfos
                Dim sDirsNSects(1) As String
                r = tblFHCompanies.NewRow()

                If Not CInfo.officerinfo Is Nothing Then
                    sDirsNSects = getDirectorNSecretary(CInfo.officerinfo)
                End If

                For iCnt = 1 To 13
                    Dim sValue As String
                    sValue = Choose(iCnt, CInfo.companyname, CInfo.companynumber, CInfo.eincdate, CInfo.telephone, CInfo.fax, CInfo.email, CInfo.domainname, getAddressString(CInfo.address), sDirsNSects(0), sDirsNSects(1), CInfo.ard, CInfo.dissolvedate, CInfo.dormant)
                    If iCnt = 3 Or iCnt = 12 Then
                        If sValue <> "0000-00-00" And Not sValue Is Nothing And sValue <> "" Then
                            Dim sMonth, sDay, sYear As String
                            sYear = Left(sValue, 4)
                            sMonth = Mid(sValue, 6, 2)
                            sMonth = MonthName(sMonth)
                            sDay = Right(sValue, 2)
                            sValue = sDay & "-" & sMonth & "-" & sYear
                            r.Item(iCnt - 1) = sValue
                        End If
                    ElseIf iCnt = 11 Then
                        If sValue <> "0000-00-00" And Not sValue Is Nothing And sValue <> "" Then
                            Dim sMonth, sDay, sYear As String
                            sYear = Left(sValue, 4)
                            sMonth = Mid(sValue, 6, 2)
                            sDay = Right(sValue, 2)
                            sValue = sDay & "/" & sMonth
                            r.Item(iCnt - 1) = sValue
                        End If
                    Else
                        r.Item(iCnt - 1) = sValue
                    End If

                Next iCnt

                tblFHCompanies.Rows.Add(r)
            Next CInfo

            Return tblFHCompanies
        Catch ex As Exception
            Return Nothing
        Finally
            If IsNothing(objFHServices) = False Then
                objFHServices.Dispose()
                objFHServices = Nothing
            End If
        End Try
    End Function
    Private Function UpdateINCnARDs(ByVal dtRegisteredCompanies As DataTable) As Boolean
        Dim dv As DataView
        Try
            dv = dtRegisteredCompanies.DefaultView
            'dv.RowFilter = "IncDate Is NULL OR ARD Is NULL OR TRIM(ARD) = ''"

            Dim alCustomerIDs, alCompanyNames As ArrayList
            alCustomerIDs = New ArrayList
            alCompanyNames = New ArrayList

            Dim sCompanyName As String

            For iCnt As Integer = 0 To dv.Count - 1
                alCustomerIDs.Add(dv.Item(iCnt)("MemberCustomerID"))
                If IsDBNull(dv.Item(iCnt)("CompName")) = False Then
                    sCompanyName = dv.Item(iCnt)("CompName")
                Else
                    sCompanyName = ""
                End If
                alCompanyNames.Add(sCompanyName)
            Next iCnt

            If Not IsNothing(dv) Then
                dv.Dispose()
                dv = Nothing
            End If

            objFHServices = New com.formationshouse.www.FHservices
            Dim card() As com.formationshouse.www.companyard = objFHServices.getArd(alCompanyNames.ToArray(Type.GetType("System.String")))

            Dim sbXML As New System.Text.StringBuilder
            sbXML.Append("<ROOT>")

            For Each ca As com.formationshouse.www.companyard In card
                Dim idx As Integer = alCompanyNames.IndexOf(ca.companyname)
                If idx >= 0 Then
                    If IsDate(ca.incdate) And IsDate(ca.ard) Then

                        Dim dtIncDate As Date, saARD() As String, sARD As String
                        dtIncDate = ca.incdate
                        saARD = Split(ca.ard, "-")
                        sARD = saARD(2) & "/" & saARD(1)  'dd/mm
                        sbXML.Append("<Customer ID=""" & alCustomerIDs.Item(idx) & """ ARD=""" & sARD & """ INCDATE=""" & Format(dtIncDate, "MM/dd/yyyy") & """/>")
                    End If
                End If
            Next ca

            'For Each r As DataRow In dtRegisteredCompanies.Rows
            '    If IsDBNull(r.Item("MemberCustomerID")) = False AndAlso IsDBNull(r.Item("IncDate")) = False AndAlso IsDBNull(r.Item("ARD")) = False Then : If r.Item("MemberCustomerID") <> Nothing AndAlso IsDate(r.Item("IncDate")) Then
            '            sbXML.Append("<Customer ID=""" & r.Item("MemberCustomerID") & """ ARD=""" & r.Item("ARD") & """ INCDATE=""" & Format(r.Item("IncDate"), "MM/dd/yyyy") & """/>")
            '        End If : End If
            'Next r
            sbXML.Append("</ROOT>")

            Dim sqlParams() As sql.SqlParameter
            sqlParams = New sql.SqlParameter(0) {}

            sqlParams(0) = New sql.SqlParameter("@vINCnARDs", SqlDbType.VarChar, 8000)
            sqlParams(0).Direction = ParameterDirection.Input
            sqlParams(0).Value = sbXML.ToString

            DAL.SqlHelper.ExecuteScalar(0, CommandType.StoredProcedure, "DBSERVER.InfinishopMainDB.dbo.ACC_UpdateINCnARDs", sqlParams)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If Not IsNothing(dv) Then
                dv.Dispose()
                dv = Nothing
            End If
        End Try
    End Function
#End Region
End Class

#Region "Trust All Certificates... It is used because it will communicate server to server"
'Public Class TrustAllCertificatePolicy
'    Implements System.Net.ICertificatePolicy
'    Public Sub New()
'    End Sub
'    Public Function CheckValidationResult(ByVal sp As System.net.ServicePoint, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal req As System.Net.WebRequest, ByVal problem As Integer) As Boolean Implements System.Net.ICertificatePolicy.CheckValidationResult
'        Return True
'    End Function
'End Class
#End Region