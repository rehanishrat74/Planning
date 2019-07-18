Option Strict On

Public Class AccessQueries
    Private Shared _SqlStr As String
    Public Shared Function GetQueryString(ByRef _cmd As InfiniCommand) As String

        Dim SPName As String, SPQuery As String = ""

        'SPName = _cmd.CommandName

        'Select Case UCase(SPName)
        '    Case "BP_GENERALASSUMPTIONDATA"
        '        SPQuery = GetGeneralAssumption(_cmd)
        'End Select
        Return SPQuery
    End Function
End Class
