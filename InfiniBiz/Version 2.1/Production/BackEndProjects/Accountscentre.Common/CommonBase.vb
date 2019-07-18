Imports System.Web.HttpContext
Imports System.Resources
Imports System.Web.Caching
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Text
Imports System.Web.UI.WebControls
Imports System.Collections.Specialized



Public Class CommonBase

    'Public Shared ASSEMBLY_NAME As String = "InfiniLogic.AccountsCentre.Common." & System.Reflection.Assembly.GetExecutingAssembly.GetName(False).Name
    Public Shared ASSEMBLY_NAME As String = System.Reflection.Assembly.GetExecutingAssembly.GetName().Name & "."


    Public Shared ReadOnly Property CurrentTaxYear(Optional ByVal dtCurrent As Date = #1/1/1900#) As Int16
        Get
            If dtCurrent = #1/1/1900# Then dtCurrent = Now()

            dtCurrent = Now()
            Dim intCurrentYear As Int16 = Year(dtCurrent)
            Dim dtTaxyearStartDate As Date = New Date(intCurrentYear, 4, 6)
            If dtCurrent < dtTaxyearStartDate Then intCurrentYear -= 1

            Return intCurrentYear
        End Get
    End Property

    Public Shared Function GetTaxYear(ByVal dtCurrent As Date) As Short
        Dim intCurrentYear As Int16 = Year(dtCurrent)
        Dim dtTaxyearStartDate As Date = New Date(intCurrentYear, 4, 6)
        If dtCurrent < dtTaxyearStartDate Then intCurrentYear -= 1

        Return intCurrentYear
    End Function
    Public Shared ReadOnly Property TaxYearDates(ByVal TaxYearDateType As TaxYearDate) As Date
        Get

            Select Case TaxYearDateType
                Case TaxYearDate.StartDate
                    Return New Date(CurrentTaxYear, 4, 6)
                Case TaxYearDate.EndDate
                    Return New Date(CurrentTaxYear + 1, 4, 5)
                Case TaxYearDate.EOYEfilingStartDate
                    Return New Date(CurrentTaxYear + 1, 4, 6)
                Case TaxYearDate.EOYEfilingEndDate
                    Return New Date(CurrentTaxYear + 1, 5, 19)
            End Select

        End Get
    End Property

    Public Shared Function SendEmail(ByVal mFrom As Object, ByVal mTo As Object, ByVal mSubject As Object, ByVal mBody As Object, Optional ByVal mMailFormat As System.Web.Mail.MailFormat = System.Web.Mail.MailFormat.Text, Optional ByVal strBCC As String = "", Optional ByVal strCC As String = "") As String

        Dim mail As New System.Web.Mail.MailMessage
        If CStr(mTo).Trim <> mFrom.Trim Then
            mail.To = mTo
            mail.From = mFrom
            If strBCC <> "" OrElse strBCC <> mFrom Then mail.Bcc = strBCC
            If strCC <> "" OrElse strCC <> mFrom Then mail.Cc = strCC
            mail.Subject = mSubject
            mail.Body = mBody
            mail.BodyFormat = mMailFormat
            System.Web.Mail.SmtpMail.SmtpServer = ConfigReader.GetItem(ConfigVariables.SMTPSERVER)

            If ConfigReader.GetItem(ConfigVariables.SMTP_Authentication) = "1" Then
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1") 'basic authentication
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", ConfigReader.GetItem(ConfigVariables.SMTPUserID)) 'set your username here
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", ConfigReader.GetItem(ConfigVariables.SMTPPassword))  'set your password here
            End If
            Try
                System.Web.Mail.SmtpMail.Send(mail)
                SendEmail = ""
                'Raise mail sucess event
            Catch ex As Exception
                SendEmail = ex.Message
                'Raise mail fail event            
            Finally
                mail = Nothing
            End Try
        End If
    End Function

    Public Shared Function XMLTransform(ByVal XMLFileName As String, ByVal XSLFileName As String) As System.IO.StringWriter
        Dim sb As New StringBuilder(1000)
        Dim sw As New System.IO.StringWriter(sb)
        Dim xt As New XslTransform
        Dim strXMLPath As String = Current.Server.MapPath("." & "\" & XMLFileName)
        Dim strXSLPath As String = Current.Server.MapPath(".") & "\" & XSLFileName
        Dim xmldoc As New XmlDocument
        xmldoc.Load(strXMLPath)
        xt.Load(strXSLPath)
        xt.Transform(xmldoc.CreateNavigator, Nothing, sw, Nothing)
        Return sw
    End Function


    Public Shared Sub WriteAppLog(ByVal logname As String, ByVal message As String, ByVal Source As String, _
                                        Optional ByVal machinename As String = ".", _
                                        Optional ByVal type As System.Diagnostics.EventLogEntryType = EventLogEntryType.Information, _
                                        Optional ByVal eventID As Integer = 0, Optional ByVal category As Short = 0)

        'Dim myLog As New EventLog(logname, machinename, Source)
        'With myLog

        '    Try
        '        If Not .SourceExists(Source) Then .CreateEventSource(Source, logname)
        '        .WriteEntry(message, type, eventID, category)
        '    Finally
        '        .Close()
        '        .Dispose()
        '    End Try

        'End With

    End Sub



    Public Shared ReadOnly Property Message(ByVal msg As ACC_Messages) As String
        Get
            Dim objResourceMaganger As New ResourceManager(ASSEMBLY_NAME & "ACC_Messages", System.Reflection.Assembly.GetExecutingAssembly)
            Return objResourceMaganger.GetString([Enum].GetName(GetType(ACC_Messages), msg))
        End Get
    End Property


    Public Shared ReadOnly Property Resources(ByVal res As ACC_Resource) As String
        Get
            Dim objResourceMaganger As New ResourceManager(ASSEMBLY_NAME & "ACCResource", System.Reflection.Assembly.GetExecutingAssembly)
            Return objResourceMaganger.GetString([Enum].GetName(GetType(ACC_Resource), res))
        End Get
    End Property


    Public Shared ReadOnly Property ErrorMessages(ByVal errMsg As ACC_Error_Messages) As String
        Get
            Dim objResourceMaganger As New ResourceManager(ASSEMBLY_NAME & "ACC_Error_Messages", System.Reflection.Assembly.GetExecutingAssembly)
            Return objResourceMaganger.GetString([Enum].GetName(GetType(ACC_Error_Messages), errMsg))
        End Get
    End Property

    Public Shared ReadOnly Property EmailMessages(ByVal id As ACC_Email_Messages) As String
        Get
            Dim objResourceMaganger As New ResourceManager(ASSEMBLY_NAME & "ACC_Email_Messages", System.Reflection.Assembly.GetExecutingAssembly)
            Return objResourceMaganger.GetString([Enum].GetName(GetType(ACC_Email_Messages), id))
        End Get
    End Property


    Public Shared Function CreateList(ByVal col As NameValueCollection) As String
        Dim strBuilder As New StringBuilder(100)
        With strBuilder

            .Append("<ul>")
            For i As Integer = 0 To col.Count - 1
                .Append("<li>" & col.Item(i) & "</li>")
            Next
            .Append("</ul>")

            Return strBuilder.ToString
        End With
    End Function

    Public Shared Sub SetMessages(ByVal lbl As System.Web.UI.HtmlControls.HtmlGenericControl, ByVal ParamArray strMsgs As String())
        Dim strErr As New StringBuilder(25)
        With strErr

            .Append("<ul>")
            For Each Str As String In strMsgs
                .Append("<li>")
                .Append(Str)
                .Append("</li>")
            Next
            .Append("</ul>")

        End With

        With lbl
            .InnerHtml = strErr.ToString
            .Disabled = False
            .Visible = True
        End With
    End Sub


    Public Shared Function ValidCON(ByVal Number As String, ByVal CONType As CON) As Boolean

        Try


            Dim FixedValue As Integer
            If CONType = CONType.SCON Then
                FixedValue = 51
            ElseIf CONType = CON.ECON Then
                FixedValue = 37
            End If
            Dim refrenceNumber As Char() = Number.ToCharArray()
            Dim mulNumber, Total, Remainder, Result As Integer
            Dim checkLetter As Char() = {"A", "B", "C", "D", "E", "F", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "T", "W", "X", "Y"}
            Dim i As Integer = 1
            Dim j As Integer = 0

            Dim range As Integer = Number.Substring(1, 7)


            If refrenceNumber.Length < 9 Then
                Return False
            ElseIf CONType = CON.ECON Then
                If Not (refrenceNumber(0) = "E") Then
                    Return False
                ElseIf Not (range >= 3000000 And range <= 3999999) Then
                    Return False
                End If

            ElseIf Char.IsDigit(refrenceNumber(8)) Then
                Return False
            ElseIf CONType = CON.SCON Then
                If Not (refrenceNumber(0) = "S") Then
                    Return False
                End If
                For j = 1 To 7
                    If Not Char.IsDigit(Number.Substring(1, 7), i) Then
                        Return False
                    End If
                Next
            End If


            While (i < refrenceNumber.Length - 1)
                mulNumber += Microsoft.VisualBasic.Val(refrenceNumber(i)) * (9 - i)
                i = i + 1
            End While

            Total = mulNumber + FixedValue
            Remainder = Math.DivRem(Total, 19, Result)
            Dim lastLetter As Char = refrenceNumber(refrenceNumber.Length - 1)


            Return lastLetter = checkLetter(Result)

        Catch ex As Exception
            Return False
        End Try

        Return False

    End Function

    ' 18 Apr 2007: Function Created by Danish Faiz
    Public Shared Sub ShowBottomBarError(ByRef BottomBar As System.Web.UI.Control, ByVal ErrorMessage As String, Optional ByVal HeaderMessage As String = "")

        Dim Error_Table As System.Web.UI.HtmlControls.HtmlTable = CType(BottomBar.FindControl("tbl_Error"), System.Web.UI.HtmlControls.HtmlTable)
        Dim Error_Header As System.Web.UI.HtmlControls.HtmlTableCell = CType(BottomBar.FindControl("td_ErrorHeader"), System.Web.UI.HtmlControls.HtmlTableCell)
        Dim Error_Message As System.Web.UI.HtmlControls.HtmlTableCell = CType(BottomBar.FindControl("td_ErrorMsg"), System.Web.UI.HtmlControls.HtmlTableCell)

        Error_Table.Visible = True

        If HeaderMessage <> String.Empty Then
            Error_Header.Visible = True
            Error_Header.InnerHtml = "<strong>" & HeaderMessage & "</strong>"
        End If

        Error_Message.InnerHtml = "<ul><li>" & ErrorMessage.Replace("^", "</li><li>") & "</li></ul>"

    End Sub


    Public Shared Function IsProductCodeAvailable(ByVal ProductCode As String, _
                                           ByVal ProductCodeList As String) As Boolean
        Dim ProductCodeListArray() As String = ProductCodeList.Split(New Char() {","})
        For Each Item As String In ProductCodeListArray
            If Item.ToUpper = ProductCode.ToUpper Then
                Return True     'ProductCode found!
            End If
        Next
        Return False            'ProductCode not found!
    End Function



End Class

Public Enum ACC_Resource
    DefaultCountry
    ACC_Home
    ACC_ERROR_PAGE
    ACC_SIGNIN
    ACC_AUTOLOGIN
    ACC_SIGNOUT
    ACC_ERROR_STYLE
    ACC_INFO_STYLE
    ACC_GLOBALVIEW
End Enum


Public Enum ACC_Messages
    New_Account_Created_Msg
End Enum

Public Enum ACC_Error_Messages
    DefaultMsg
    ACC_Service_Not_Available_For_Sale
    ACC_Selected_Service_Already_Purchased
    ACC_No_Product_Avaiable_For_Purchase
End Enum

Public Enum ACC_Email_Messages
    New_Account_Email_Template
End Enum


Public Enum TaxYearDate
    StartDate
    EndDate
    EOYEfilingStartDate
    EOYEfilingEndDate
End Enum


Public Enum CON
    SCON = 1
    ECON = 2
End Enum