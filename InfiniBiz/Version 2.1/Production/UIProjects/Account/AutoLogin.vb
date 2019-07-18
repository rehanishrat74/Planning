Imports InfiniLogic.AccountsCentre.common
Public Class AutoLogin
    Public Shared Function ValidateIP(ByVal oRequest As Object) As Boolean
        Return True 'IsIPAllowed(oRequest.ServerVariables("REMOTE_ADDR"))
    End Function
    Private Shared Function IsIPAllowed(ByVal sCallerIP As String) As Boolean
        Return True 'ConfigurationSettings.AppSettings("ValidCallerIPs").IndexOf(sCallerIP) <> -1
    End Function
    Public Shared Sub WriteDebugInfo(ByVal sText As String)
        'CommonBase.WriteAppLog("Accountscentre", sText, "Class AutoLogin WriteDebugInfo()", , Diagnostics.EventLogEntryType.Error)
        'Dim sw As System.IO.StreamWriter
        'sw = System.IO.File.AppendText("C:\DebugInfo.txt")
        'sw.WriteLine(sText)
        'sw.Close()
    End Sub
End Class