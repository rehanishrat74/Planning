Imports System.Resources
Imports System.Globalization
Public Class Resource
    Inherits ResourceManager
    Sub New()
        MyBase.New("InfiniLogic.AccountsCentre.common.strings", System.Reflection.Assembly.GetExecutingAssembly)
    End Sub
    Public ReadOnly Property meGetString(ByVal Key As String) As String
        Get
            Return GetString(Key).Trim
        End Get
    End Property
    Public ReadOnly Property meGetString(ByVal Key As String, ByVal _culture As CultureInfo) As String
        Get
            Return GetString(Key, _culture.CurrentCulture).Trim
        End Get
    End Property
End Class