Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports System.web

Public Class Validation
    Public Shared Function Validate(ByVal Value As String, ByVal RegEx As String) As Boolean
        If RegEx = "" Then
            Return True
        End If
        Dim objRegExp As New RegularExpressions
        '=========================================
        ' Regular Expression syntax:
        ' --                    ---             ----       -
        ' 00                   000              0000       0
        ' Category ID     Expression ID         Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================


        Return objRegExp.ScanControl(Value, RegEx)
        'Return objRegExp.IsExpressionValid(RegEx, Value)
    End Function

    Public Shared Function IsUserAllowed(ByVal UserID As String) As Boolean
        If UserID = 26 Then
            Dim Validate26User As String = System.Configuration.ConfigurationSettings.AppSettings("Validate26User")
            HttpContext.Current.Trace.Write("Validate26User=" & Validate26User)
            If Validate26User = "0" Then Return True

            Dim IPClient As String = IIf(HttpContext.Current.Request.ServerVariables("http_X_Forwarded_For") Is Nothing, HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.ServerVariables("http_X_Forwarded_For"))
            IPClient = IPClient.Trim
            System.Web.HttpContext.Current.Trace.Warn("Current IP --> " & IPClient)
            HttpContext.Current.Trace.Write("Current IP --> " & IPClient.Trim)
            HttpContext.Current.Trace.Write("Path --> " & System.Configuration.ConfigurationSettings.AppSettings("User") & "user.xml")


            Dim IPXML As New System.Xml.XmlDocument
            Dim IPAllowed As String
            Dim Node As Xml.XmlNode
            IPXML.Load(System.Configuration.ConfigurationSettings.AppSettings("User") & "user.xml")
            Node = IPXML.SelectSingleNode("//user[ip='" & IPClient & "']")
            If Not Node Is Nothing Then
                IPAllowed = Node.InnerText.Trim
            Else
                HttpContext.Current.Trace.Warn("Invalid IP Node!")
                Return False
            End If
            HttpContext.Current.Trace.Write("User IP --> " & IPAllowed.Trim)

            If IPAllowed.Trim <> IPClient.Trim Then
                HttpContext.Current.Trace.Warn("Invalid IP Found!")
                Return False
            Else
                Return True
            End If
        End If
        Return True
    End Function


End Class
