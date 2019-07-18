#Region "Libraries"
Imports InfiniLogic.Text
#End Region

Public Class Validation

    Public Function Validate(ByVal CustomerID As String _
                           , ByVal ProductCode As String _
                           , ByVal OrderNo As String _
                           , ByVal SerialNo As String _
                           , ByVal Language As String) As Integer
        Dim valid As New InfiniLogic.Text.RegularExpressions
        If Not valid.ScanControl(CustomerID, "0100200080") Then Return 10
        If Not valid.ScanControl(ProductCode, "0203400080") Then Return 11
        If Not valid.ScanControl(OrderNo, "0100200050") Then Return 12
        If Not valid.ScanControl(SerialNo, "0100200020") Then Return 13
        'If Not valid.ScanControl(Language, "0100200050") Then Return 14

        Return 0    '0 means ok
    End Function
End Class
