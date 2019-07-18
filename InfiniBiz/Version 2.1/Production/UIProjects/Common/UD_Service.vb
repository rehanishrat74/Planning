
Public Class UD_Service
    Private LogUniquePath As String
    Public Sub New(ByVal LogPath As String)
        LogUniquePath = LogPath
    End Sub

    Public Shared Function IsDomainAvailable(ByVal DomainName As String) As Boolean

        Dim Service As New com.u_d.webservices.UniversalDomainServices
        Dim Result As com.u_d.webservices.ReturnMsg
        Result = Service.isDomainAvailable(DomainName)

        HttpContext.Current.Trace.Warn("Result.ERRORCODE = " & Result.ERRORCODE.ToString)
        HttpContext.Current.Trace.Warn("Result.ERRORDESC = " & Result.ERRORDESC.ToString)

        If Result.ERRORCODE.ToString = "0" Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function RegTestDomain(ByVal DomainName As String, _
                                        ByVal CompanyName As String, _
                                        ByVal CustomerID As String, _
                                        ByVal Hosting As Boolean, _
                                        ByVal Email As String, _
                                        ByVal AlreadyHaveDomain As Boolean) As RegTestDomainResult
        WriteDebugInfo("In RegTestDomain:")
        WriteDebugInfo("    DomainName:" & DomainName)
        WriteDebugInfo("    CompanyName:" & CompanyName)
        WriteDebugInfo("    CustomerID:" & CustomerID)
        WriteDebugInfo("    Hosting:" & Hosting)
        WriteDebugInfo("    Email:" & Email)
        WriteDebugInfo("    AlreadyHaveDomain:" & AlreadyHaveDomain)

        Dim Result As New RegTestDomainResult

        Try
            Dim U_DRefererID = System.Configuration.ConfigurationSettings.AppSettings("U_DRefererID").ToString
            Dim testService As New test.com.u_d.webservices.UniversalDomainServices
            Dim testMemberInfo As New test.com.u_d.webservices.MemberInfo
            Dim testReturnMsg As test.com.u_d.webservices.ReturnMsg
            testMemberInfo.companyname = CompanyName
            testMemberInfo.email = Email
            testMemberInfo.isocode = "GB"
            testMemberInfo.name = ""
            testMemberInfo.password = ""
            WriteDebugInfo("Calling testService.regDomain")
            testReturnMsg = testService.regDomain(DomainName, _
                                U_DRefererID, _
                                CompanyName, _
                                CustomerID, _
                                "", _
                                Hosting, _
                                testMemberInfo)
            WriteDebugInfo("testService.regDomain is ok")
            WriteDebugInfo("testReturnMsg.ERRORCODE=" & testReturnMsg.ERRORCODE.ToString)
            WriteDebugInfo("testReturnMsg.ERRORDESC=" & testReturnMsg.ERRORDESC)

            Result.ERRORCODE = testReturnMsg.ERRORCODE.ToString
            Result.ERRORDESC = testReturnMsg.ERRORDESC
            Return Result
        Catch ex As Exception
            WriteDebugInfo("Exception:")
            WriteDebugInfo("    Message: = " & ex.Message)
            WriteDebugInfo("    Message: = " & ex.StackTrace)
            Result.ERRORCODE = -1
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
        Finally
            WriteDebugInfo("RegTestDomain Finished")
        End Try

        Return Result
    End Function

    Public Structure RegTestDomainResult
        Public ERRORCODE As String
        Public ERRORDESC As String
    End Structure

    Public Function RegLiveDomain(ByVal DomainName As String, _
                                    ByVal CompanyName As String, _
                                    ByVal CustomerID As String, _
                                    ByVal Hosting As Boolean, _
                                    ByVal Email As String, _
                                    ByVal AlreadyHaveDomain As Boolean) As RegLiveDomainResult
        WriteDebugInfo("In RegLiveDomain:")
        WriteDebugInfo("    DomainName:" & DomainName)
        WriteDebugInfo("    CompanyName:" & CompanyName)
        WriteDebugInfo("    CustomerID:" & CustomerID)
        WriteDebugInfo("    Hosting:" & Hosting)
        WriteDebugInfo("    Email:" & Email)
        WriteDebugInfo("    AlreadyHaveDomain:" & AlreadyHaveDomain)

        Dim Result As New RegLiveDomainResult
        Try
            Dim U_DRefererID = System.Configuration.ConfigurationSettings.AppSettings("U_DRefererID").ToString
            Dim service As New com.u_d.webservices.UniversalDomainServices
            Dim MemberInfo As New com.u_d.webservices.MemberInfo
            Dim ReturnMsg As com.u_d.webservices.ReturnMsg
            MemberInfo.companyname = CompanyName
            MemberInfo.email = Email
            MemberInfo.isocode = "GB"
            MemberInfo.name = ""
            MemberInfo.password = ""
            WriteDebugInfo("Calling regDomain")
            ReturnMsg = service.regDomain(DomainName, _
                                U_DRefererID, _
                                CompanyName, _
                                CustomerID, _
                                "", _
                                Hosting, _
                                MemberInfo, _
                                AlreadyHaveDomain)
            WriteDebugInfo("regDomain is ok")
            WriteDebugInfo("ReturnMsg.ERRORCODE=" & ReturnMsg.ERRORCODE.ToString)
            WriteDebugInfo("ReturnMsg.ERRORDESC=" & ReturnMsg.ERRORDESC)

            Result.ERRORCODE = ReturnMsg.ERRORCODE.ToString
            Result.ERRORDESC = ReturnMsg.ERRORDESC
            Return Result
        Catch ex As Exception
            WriteDebugInfo("Exception:")
            WriteDebugInfo("    Message: = " & ex.Message)
            WriteDebugInfo("    Message: = " & ex.StackTrace)
            Result.ERRORCODE = -1
            Result.ERRORDESC = "EXCEPTION: " & ex.Message
        Finally
            WriteDebugInfo("RegLiveDomain Finished")
        End Try

        Return Result
    End Function

    Public Structure RegLiveDomainResult
        Public ERRORCODE As String
        Public ERRORDESC As String
    End Structure

    Private Sub WriteDebugInfo(ByVal sText As String)
        If System.Configuration.ConfigurationSettings.AppSettings("IOTraceEnable").Equals("1") Then
            Dim dirPath As String = LogUniquePath
            If Not System.IO.Directory.Exists(dirPath) Then
                System.IO.Directory.CreateDirectory(dirPath)
            End If
            Dim sw As System.IO.StreamWriter
            sw = System.IO.File.AppendText(LogUniquePath)
            sw.WriteLine(Now & " -- " & sText)
            sw.Close()
        End If
    End Sub

End Class
