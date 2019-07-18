Public MustInherit Class NavigatorBase

    Public MustOverride Function MoveForward(ByVal headingType As Integer) As String
    Public MustOverride Function MoveBackward(ByVal headingType As Integer) As String

    Public Shared Function RemoveSpaces(ByVal name As String) As String

        Dim index As Integer
        index = name.IndexOf(" ")
        While (index > -1)
            name = name.Replace(" ", "")
            index = name.IndexOf(" ")
        End While
        Return name
    End Function

End Class
