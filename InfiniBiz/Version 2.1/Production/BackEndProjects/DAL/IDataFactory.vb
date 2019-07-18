
Public Interface IDataFactory

    Function ExecuteDataset(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As DataSet

    Function ExecuteReader(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As IDataReader

    Function ExecuteNonQuery(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As Integer

    Function ExecuteScalar(ByVal connData As ConnectionData, ByRef objCommand As InfiniCommand) As Object

End Interface
