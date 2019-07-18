Option Strict On
Option Explicit On 


Public MustInherit Class DatabaseHelper
    Implements IDataFactory

    Public Overridable Function ExecuteReader(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As IDataReader Implements IDataFactory.ExecuteReader

    End Function

    Public Overridable Function ExecuteDataset(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As DataSet Implements IDataFactory.ExecuteDataset

    End Function

    Public Overridable Function ExecuteNonQuery(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As Integer Implements IDataFactory.ExecuteNonQuery

    End Function

    Public Overridable Function ExecuteScalar(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As Object Implements IDataFactory.ExecuteScalar

    End Function


End Class
