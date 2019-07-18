#Region "Imports"
Imports sql = System.Data.SqlClient
Imports dal = InfiniLogic.AccountsCentre.DAL
Imports System.IO
#End Region

Public Class GlobalView
#Region " Declarations"
    Private objFHServices As com.formationshouse.www.FHservices

    Public Sub New()
        'DAL.SqlHelper.ConnectionString = DAL.Connection.GetConnectionString
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

        Dim sw As StreamWriter = Nothing

        Try


            Dim strFile As String = ("D:\GlobalView.txt")

            'If File.Exists(strFile) Then
            '    File.Delete(strFile)
            'End If

            'sw = File.CreateText(strFile)
            'sw.WriteLine("Gloabl View Tracing Starts")


            Dim dsCompanies As New DataSet("Companies")

            'sw.WriteLine("Calling getRegisteredCompanies(CustomerID Function")

            Dim dtACCompanies As DataTable

            'Modified by:   M.Yousuf
            'Date:          Aug 29, 2007
            'Desc:          In case of employee CustomerID is equal to MemberCustomerID
            '               so this function does not return data "getRegisteredCompanies"
            If Not Web.HttpContext.Current.Session("session_EmployeeID") Is Nothing _
                    OrElse Convert.ToString(Web.HttpContext.Current.Session("session_EmployeeID")).Length > 0 Then
                dtACCompanies = GetRegisteredCompanies_MemberCustomerID(CustomerID)
            Else
                dtACCompanies = getRegisteredCompanies(CustomerID)
            End If

            'sw.WriteLine("Successfully called getRegisteredCompanies(CustomerID Function")

            If dtFHCompanies Is Nothing Then
                'sw.WriteLine("ZERO FH company.")
                Return dtACCompanies
            End If

            ' To delete parent id from companies list
            'If dtFHCompanies.Rows.Count > 0 Then
            '    Dim rowIndex As Integer = -1
            '    For Each dr As DataRow In dtACCompanies.Rows
            '        rowIndex += 1
            '        If dr("MemberCustomerID") = CustomerID Then
            '            Exit For
            '        End If
            '    Next

            '    If rowIndex <> -1 AndAlso rowIndex < dtACCompanies.Rows.Count Then
            '        dtACCompanies.Rows.RemoveAt(rowIndex)
            '        sw.WriteLine("Parent[ " & CustomerID & " ] row delted.")
            '    End If
            'End If



            dtFHCompanies.TableName = "FHCompanies"
            dsCompanies.Merge(dtFHCompanies)

            'sw.WriteLine("Merging FMH companies")

            dtACCompanies.TableName = "ACCompanies"
            dsCompanies.Merge(dtACCompanies)

            'sw.WriteLine("Merging ACC companies")

            Dim rCompanyName As DataRelation

            Dim parent As DataColumn = dsCompanies.Tables("FHCompanies").Columns("CompanyNumber")

            Dim child As DataColumn = dsCompanies.Tables("ACCompanies").Columns("CompRegNo")               'xDim child As DataColumn = dsCompanies.Tables("ACCompanies").Columns("CompName")

            Dim sRelationName As String = "FH_AC_CompanyName"

            rCompanyName = New DataRelation(sRelationName, parent, child, False)

            dsCompanies.Relations.Add(rCompanyName)

            'sw.WriteLine("Merged successfully")

            Dim r As DataRow, iCntr As Integer = 1
            For Each r In dsCompanies.Tables("FHCompanies").Rows

                Dim rRegComp() As DataRow = r.GetChildRows(dsCompanies.Relations.Item(0))

                If rRegComp.Length = 0 Then
                    Dim rACCompany As DataRow
                    rACCompany = dtACCompanies.NewRow

                    With rACCompany

                        'sw.WriteLine("using Condition rACCompany")

                        .Item("CompName") = r.Item("CompanyName")

                        If IsDBNull(r.Item("CompanyName")) = False Then

                            .Item("UpperCompName") = UCase(CType(r.Item("CompanyName"), String))

                            'sw.WriteLine("using .Item(UpperCompName)")

                        Else

                            .Item("UpperCompName") = ""

                        End If
                        .Item("CompRegNo") = r.Item("CompanyNumber")

                        .Item("CompFax") = r.Item("Fax")

                        .Item("CompEmail") = r.Item("Email")

                        .Item("CompPhone") = r.Item("Telephone")

                        .Item("CompWebSite") = r.Item("Website")

                        .Item("FullAddress") = r.Item("Address")

                        .Item("CompDirector") = r.Item("Director")

                        .Item("CompSec") = r.Item("Secretary")

                        .Item("IncDate") = r.Item("IncorporationDate")

                        .Item("TaggedCompName") = r.Item("CompanyName")

                        .Item("GVStatus") = 0


                        Dim eFilingDate As String = Nothing
                        If IsDBNull(r.Item("ARD")) = False AndAlso IsValidARD(r.Item("ARD")) Then

                            If r.Item("ARD") = "29/2" Or r.Item("ARD") = "29/02" Then
                                eFilingDate = "28/02"

                            ElseIf r.Item("ARD") <> "" Then
                                eFilingDate = r.Item("ARD")

                            End If
                        End If

                        If eFilingDate <> Nothing Then .Item("eFilingDate") = eFilingDate

                        'sw.WriteLine("using .Item(eFilingDate)")
                        ''===============================================================
                        'Dim strDate() As String

                        'If .Item("ToYear") <> Nothing Then
                        '    .Item("eFillingDate") = .Item("ARD") & "/" & (CInt(.Item("ToYear")) + 1).ToString()
                        'Else
                        '    Dim dtInc As DateTime = CDate(.Item("IncDate"))
                        '    .Item("eFillingDate") = .Item("ARD") & "/" & (dtInc.Year + 1).ToString()
                        'End If
                        ''===============================================================

                        .Item("ARD") = r.Item("ARD")

                        .Item("ID") = "Z_" + CStr(iCntr)

                        'sw.WriteLine("using r.Item(DissolvedDate) : " & r.Item("DissolvedDate"))

                        '.Item("DissolvedDate") = IIf(IsDBNull(r.Item("DissolvedDate")), "", r.Item("DissolvedDate"))

                        'sw.WriteLine("used r.Item(DissolvedDate) : " & r.Item("DissolvedDate"))

                        .Item("Dormant") = IIf(IsDBNull(r.Item("Dormant")), "", r.Item("Dormant"))

                        'sw.WriteLine("used r.Item(Dormant) : " & r.Item("Dormant"))

                        iCntr += 1
                    End With

                    dtACCompanies.Rows.Add(rACCompany)

                Else
                    If IsDBNull(r.Item("IncorporationDate")) = False Then : If r.Item("IncorporationDate") <> Nothing Then

                            rRegComp(0).Item("IncDate") = r.Item("IncorporationDate")

                            'sw.WriteLine("used r.Item(IncorporationDate) : " & r.Item("IncorporationDate"))

                        End If : End If

                    If IsDBNull(r.Item("ARD")) = False AndAlso IsValidARD(r.Item("ARD")) Then : If r.Item("ARD") <> Nothing Then

                            rRegComp(0).Item("ARD") = r.Item("ARD")
                            'sw.WriteLine("used r.Item(ARD) : " & r.Item("ARD"))

                        End If : End If

                    'rRegComp(0).Item("DissolvedDate") = IIf(IsDBNull(r.Item("DissolvedDate")), "", r.Item("DissolvedDate"))

                    'rRegComp(0).Item("Dormant") = IIf(IsDBNull(r.Item("Dormant")), "", r.Item("Dormant"))


                End If
            Next r

            dsCompanies.Dispose() : dsCompanies = Nothing

            parent.Dispose() : parent = Nothing

            child.Dispose() : child = Nothing

            rCompanyName = Nothing

            'sw.WriteLine("returning values in the end")

            If bUpdateINCnARDs = False Then

                If UpdateINCnARDs(dtACCompanies) = True Then

                    bUpdateINCnARDs = True

                    'sw.WriteLine("bUpdateINCnARDs = True")

                End If
            End If

            dtACCompanies.DefaultView.Sort = "ID"

            'sw.WriteLine("dtACCompanies.DefaultView.Sort")
            '            sw.Close()

            Return dtACCompanies



        Catch ex As Exception

            Return Nothing
        Finally
            If Not sw Is Nothing Then
                'sw.Close()
            End If

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
    Private Function getRegisteredCompanies(ByVal CustomerID As Integer, Optional ByVal DBSchemaType As Integer = 2) As DataTable
        Dim sqlParams(1) As sql.SqlParameter
        sqlParams(0) = New sql.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = CustomerID
        sqlParams(1) = New sql.SqlParameter("@DBSchemaType", SqlDbType.Int)
        sqlParams(1).Value = DBSchemaType

        Return DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "ACC_GetRegisteredCompanies", sqlParams).Tables(0)
    End Function

    Private Function GetRegisteredCompanies_MemberCustomerID(ByVal MemberCustomerID As Integer, Optional ByVal DBSchemaType As Integer = 2) As DataTable
        Dim sqlParams(1) As sql.SqlParameter
        sqlParams(0) = New sql.SqlParameter("@MemberCustomerID", SqlDbType.BigInt)
        sqlParams(0).Value = MemberCustomerID
        sqlParams(1) = New sql.SqlParameter("@DBSchemaType", SqlDbType.Int)
        sqlParams(1).Value = DBSchemaType

        Return DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBServer.InfinishopMainDB.dbo.RSS_GetRegisteredCompanies_MemberCustomerID", sqlParams).Tables(0)
    End Function

    Private Function getFormationHouseCompanies(ByVal LoginID As Object) As DataTable
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

            '-------------------------
            WriteCompanyInfo(CInfos)
            '-------------------------

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
                    'sValue = Choose(iCnt, CInfo.companyname, CInfo.companynumber, CInfo.eincdate, CInfo.telephone, CInfo.fax, CInfo.email, CInfo.domainname, getAddressString(CInfo.address), sDirsNSects(0), sDirsNSects(1), CInfo.ard, CInfo.dissolvedate, CInfo.dormant)
                    sValue = Choose(iCnt, CInfo.companyname, CInfo.companynumber, CInfo.eincdate, CInfo.telephone, CInfo.fax, CInfo.email, CInfo.domainname, getAddressString(CInfo.address), sDirsNSects(0), sDirsNSects(1), CInfo.ardcurrent, CInfo.dissolvedate, CInfo.dormant)
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

    Private Sub WriteCompanyInfo(ByVal cinfoArray() As com.formationshouse.www.CompanyInfo)

        Dim objSW As StreamWriter = Nothing
        Dim cinfo As com.formationshouse.www.CompanyInfo
        Dim strFile As String = "D:\GlobalViewCompanyInfo.txt"

        Try
            If File.Exists(strFile) Then
                objSW = File.AppendText(strFile)
            Else
                objSW = File.CreateText(strFile)
            End If

            objSW.WriteLine("_______________________________________________________________________________________________")
            objSW.WriteLine(Date.Today.ToString & vbNewLine)
            objSW.WriteLine("_______________________________________________________________________________________________")

            For Each cinfo In cinfoArray
                objSW.WriteLine("Company Name " & vbTab & vbTab & ": " & cinfo.companyname)
                objSW.WriteLine("Company No. " & vbTab & vbTab & ": " & cinfo.companynumber)
                objSW.WriteLine("Ard         " & vbTab & vbTab & ": " & cinfo.ard)
                objSW.WriteLine("Ard Last " & vbTab & vbTab & ": " & cinfo.ardlast)
                objSW.WriteLine("Ard Next " & vbTab & vbTab & ": " & cinfo.ardnext)
                'objSW.WriteLine("Dissolve Date " & vbTab & vbTab & ": " & cinfo.dissolvedate)
                objSW.WriteLine("Dormant " & vbTab & vbTab & ": " & cinfo.dormant)
                objSW.WriteLine("Inc. Date " & vbTab & vbTab & ": " & cinfo.eincdate)
                objSW.WriteLine("Email " & vbTab & vbTab & ": " & cinfo.email)
                objSW.WriteLine("Sub-Account " & vbTab & vbTab & ": " & cinfo.subaccount & vbNewLine)
                objSW.WriteLine("******************************************************************************************")
            Next

            objSW.Flush()

        Catch ex As Exception
        Finally
            If Not objSW Is Nothing Then
                objSW.Close()
            End If

        End Try
    End Sub
#End Region
End Class

#Region "Trust All Certificates... It is used because it will communicate server to server"
Public Class TrustAllCertificatePolicy
    Implements System.Net.ICertificatePolicy
    Public Sub New()
    End Sub
    Public Function CheckValidationResult(ByVal sp As System.net.ServicePoint, ByVal cert As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal req As System.Net.WebRequest, ByVal problem As Integer) As Boolean Implements System.Net.ICertificatePolicy.CheckValidationResult
        Return True
    End Function
End Class
#End Region