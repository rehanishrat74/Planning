Public Class BizPlanException
    Inherits System.Exception

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub

End Class


Public Class BizPlanDBException
    Inherits BizPlanException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub

End Class

Public Class BizPlanDBInvalidDataException
    Inherits BizPlanDBException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub

End Class

Public Class BizPlanInvalidDataException
    Inherits BizPlanDBException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub

End Class

Public Class BizPlanCreationException
    Inherits BizPlanException

    Public Sub New(ByVal msg As String)
        MyBase.New(msg)
    End Sub

End Class