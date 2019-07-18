Imports Infinilogic.AccountsCentre.DAL
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.Common
Imports System.Data.SqlClient

Public Class DataAccess

    ' Methods  that are commented belong to BizPlan.DAL,these were active before integrating DAL Version 2.0
    'Public Overloads Shared Function ExecuteDataSet(ByRef connData As ConnectionData, _
    '                                                            ByRef cmd As InfiniCommand) As DataSet
    '    Dim ds As DataSet
    '    Try
    '        Dim df As IDataFactory = DataSource.GetDataFactory(connData)
    '        ds = df.ExecuteDataset(connData, cmd)
    '    Catch sqle As SqlException
    '        ds = Nothing
    '        Throw New Exception("ExecuteDataSet Method :" & sqle.Message)
    '    Catch e As Exception
    '        ds = Nothing
    '        Throw New Exception("ExecuteDataSet Method :" & e.Message)
    '    End Try
    '    Return ds
    'End Function

    Public Overloads Shared Function ExecuteDataSet(ByRef connData As ConnectionData, _
                                                            ByRef cmd As InfiniCommand) As DataSet
        Dim ds As DataSet
        Dim cmdData As CommandData
        Try
            If (connData.CustomerID = -1) Then
                Dim df As IDataFactory = DataSource.GetDataFactory(connData)
                ds = df.ExecuteDataset(connData, cmd)
            Else
                cmdData = PrepareCommandData(connData, cmd)
                ds = CType(cmdData.Execute(ExecutionType.ExecuteDataSet), DataSet)
            End If
        Catch sqle As SqlException
            ds = Nothing
            Throw New Exception("ExecuteDataSet Method :" & sqle.Message)
        Catch e As Exception
            ds = Nothing
            Throw New Exception("ExecuteDataSet Method :" & e.Message)
        End Try
        Return ds
    End Function

    'Public Shared Function ExecuteDataReader(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand) As IDataReader

    '    Dim reader As IDataReader
    '    Try
    '        Dim df As IDataFactory = DataSource.GetDataFactory(connData)
    '        reader = df.ExecuteReader(connData, cmd)
    '    Catch sqle As SqlException
    '        reader = Nothing
    '        Throw New Exception("ExecuteDataReader Method :" & sqle.Message)
    '    Catch e As Exception
    '        reader = Nothing
    '        Throw New Exception("ExecuteDataReader Method :" & e.Message)
    '    End Try
    '    Return reader
    'End Function

    Public Shared Function ExecuteDataReader(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand) As IDataReader

        Dim reader As IDataReader
        Dim cmdData As CommandData
        Try
            If (connData.CustomerID = -1) Then
                Dim df As IDataFactory = DataSource.GetDataFactory(connData)
                reader = df.ExecuteReader(connData, cmd)
            Else
                cmdData = PrepareCommandData(connData, cmd)
                reader = CType(cmdData.Execute(ExecutionType.ExecuteReader), IDataReader)
            End If
        Catch sqle As SqlException
            reader = Nothing
            Throw New Exception("ExecuteDataReader Method :" & sqle.Message)
        Catch e As Exception
            reader = Nothing
            Throw New Exception("ExecuteDataReader Method :" & e.Message)
        End Try
        Return reader
    End Function

    'Public Shared Sub ExecuteNonQuery(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand)

    '    Dim returnValue As Integer
    '    Try
    '        Dim df As IDataFactory = DataSource.GetDataFactory(connData)
    '        returnValue = df.ExecuteNonQuery(connData, cmd)
    '    Catch sqle As SqlException
    '        Throw New Exception("ExecuteNonQuery Method : " & sqle.Message)
    '    Catch e As Exception
    '        Throw New Exception("ExecuteNonQuery Method : " & e.Message)
    '    End Try
    'End Sub

    Public Shared Sub ExecuteNonQuery(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand)

        Dim returnValue As Integer
        Dim cmdData As CommandData
        Try
            If (connData.CustomerID = -1) Then
                Dim df As IDataFactory = DataSource.GetDataFactory(connData)
                returnValue = df.ExecuteNonQuery(connData, cmd)
            Else
                cmdData = PrepareCommandData(connData, cmd)
                returnValue = CInt(cmdData.Execute(ExecutionType.ExecuteNonQuery))
            End If
        Catch sqle As SqlException
            Throw New Exception("ExecuteNonQuery Method : " & sqle.Message)
        Catch e As Exception
            Throw New Exception("ExecuteNonQuery Method : " & e.Message)
        End Try
    End Sub

    'Public Shared Function ExecuteScalar(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand) As Object

    '    Dim Obj As Object
    '    Try
    '        Dim df As IDataFactory = DataSource.GetDataFactory(connData)
    '        Obj = df.ExecuteScalar(connData, cmd)
    '    Catch sqle As SqlException
    '        Throw New Exception("ExecuteNonQuery Method : " & sqle.Message)
    '    Catch e As Exception
    '        Throw New Exception("ExecuteNonQuery Method : " & e.Message)
    '    End Try

    '    Return (Obj)
    'End Function

    Public Shared Function ExecuteScalar(ByRef connData As ConnectionData, ByRef cmd As InfiniCommand) As Object

        Dim Obj As Object
        Dim cmdData As CommandData
        Try
            If (connData.CustomerID = -1) Then
                Dim df As IDataFactory = DataSource.GetDataFactory(connData)
                Obj = df.ExecuteScalar(connData, cmd)
            Else
                cmdData = PrepareCommandData(connData, cmd)
                Obj = cmdData.Execute(ExecutionType.ExecuteScalar)
            End If

        Catch sqle As SqlException
            Throw New Exception("ExecuteNonQuery Method : " & sqle.Message)
        Catch e As Exception
            Throw New Exception("ExecuteNonQuery Method : " & e.Message)
        End Try

        Return (Obj)
    End Function

#Region "Private Methods"

    Private Shared Function PrepareCommandData(ByVal connData As ConnectionData, ByVal cmd As InfiniCommand) As CommandData

        Dim cmdData As New CommandData(connData.CustomerID)
        cmdData.CmdText = cmd.CommandName
        AttachParameters(cmdData, cmd)
        Return cmdData
    End Function


    Private Shared Sub AttachParameters(ByVal cmdData As CommandData, ByVal cmd As InfiniCommand)
        Dim paramList As ArrayList = cmd.Parameters
        If (Not paramList Is Nothing) Then
            Dim iParam As InfiniParameter
            For Each iParam In paramList
                cmdData.AddParameter(iParam.Name, iParam.Value)
            Next
        End If

    End Sub


#End Region
End Class
