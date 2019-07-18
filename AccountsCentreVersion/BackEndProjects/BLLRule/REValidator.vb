Imports Infinilogic.Text

Public Class REValidator

    Private Shared reValidator As New Infinilogic.Text.RegularExpressions

    Public Shared Function IsNumber(ByVal value As String, ByVal len As Integer) As Boolean

    End Function

    Public Shared Function IsPositiveNumber(ByVal value As String, ByVal len As Integer) As Boolean
        Return reValidator.ScanControl(value, "010020" & Format(len Mod 1000, "000") & "0")
    End Function

    Public Shared Function IsNegativeNumber(ByVal value As String, ByVal len As Integer) As Boolean

    End Function

    Public Shared Function IsDecimal(ByVal value As String, ByVal decPlaces As Integer) As Boolean
        If decPlaces = 0 Then
            Return reValidator.ScanControl(value, "0104600200")
        Else
            Return reValidator.IsExpressionValid("^([1-9]{1}\d*(\.\d{1,2})?|0(\.\d{1," & decPlaces.ToString() & "})?)$", value)
        End If
    End Function

    Public Shared Function IsPositiveDecimal(ByVal value As String, ByVal decPlaces As Integer) As Boolean

    End Function

    Public Shared Function IsNegativeDecimal(ByVal value As String, ByVal decPlaces As Integer) As Boolean

    End Function

    Public Shared Function IsBetweenZeroOne(ByVal value As String) As Boolean

    End Function

    Public Shared Function IsShortUKDate(ByVal value As String) As Boolean
        Return reValidator.ScanControl(value, "0400100100")
    End Function

    Public Shared Function IsLongUKDate(ByVal value As String) As Boolean

    End Function

    Public Shared Function IsName(ByVal value As String) As Boolean
        Return reValidator.IsExpressionValid("^(([A-Z]|[a-z])*(( )([A-Z]|[a-z])*)*)$", value)
    End Function

    Public Shared Function IsIdentifier(ByVal value As String) As Boolean
        Return reValidator.IsExpressionValid("^(([A-Z]|[a-z]|[0-9])*(( )([A-Z]|[a-z]|[0-9])*)*)$", value)
    End Function

    Public Shared Function IsText(ByVal value As String) As Boolean
        Return reValidator.IsExpressionValid("^((([A-Z]|[a-z]|[0-9])+([,]|[.]|['])*)*(( )([A-Z]|[a-z]|[0-9]|[,]|[.]|['])*)*)$", value)
    End Function

    Public Shared Function IsPercentage(ByVal value As String) As Boolean
        If value = "100" Or value = "100.00" Or value = "100.0" Then
            Return True
        Else
            Return reValidator.IsExpressionValid("^(.)?([1-9]{1}\d*(\.\d{1,3})?|0(\.\d{1,3})?)$", value)
            '  Return reValidator.IsExpressionValid("^(\d{1,2}(\.\d{1,2})?)|(\.\d{1,2})$", value)
        End If
    End Function

    Public Shared Function IsCalendarYear(ByVal value As String) As Boolean
        Return reValidator.ScanControl(value, "0106900040")
    End Function

    Public Shared Function IsTitle(ByVal value As String) As Boolean
        Return reValidator.ScanControl(value, "0203502560")
    End Function

End Class
