
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports InfiniLogic.BusinessPlan.BLLRules.MySqlLayer
Imports Infinilogic.MYSql.DAL
Imports System.Web.HttpContext

Public NotInheritable Class MySqlLayer
    Implements IDisposable

    Private Shared h_ConStr As String
    Public Shared h_Con As New MySqlConnection
    Public Shared h_Adptr As MySqlDataAdapter
    Private Shared h_sqlCmd As MySqlCommand
    Private Shared h_Dts As DataSet
    Private Shared d_DataTbl As DataTable


    Public Shared Sub h_ConString()
        '   h_ConStr = "server=192.168.9.206; user id=tracker_bot; password=tracker_bot; database=website_tracker; pooling=false; " ' Configuration.ConfigurationSettings.AppSettings.Item("MySqlConnection").ToString
        Current.Trace.Warn("Connection String Start Here...!")
        h_ConStr = Configuration.ConfigurationSettings.AppSettings.Item("MySqlConnection").ToString
        Current.Trace.Warn("Connection String --> " & h_ConStr)
        Current.Trace.Warn("Connection String End Here...!")

        ''Dim obj As New MySql_CommandData(MySql_Connection.ConnectTo.OtherMySqlDB)
    End Sub

    Public Shared Sub h_Connection()
        Current.Trace.Warn("h_Connection Start here...!")
        Current.Trace.Warn("h_Con.State --> " & h_Con.State)
        Current.Trace.Warn("h_ConStr --> " & h_ConStr)
        If Not h_Con.State = ConnectionState.Open Then
            'h_Con = New MySqlConnection(h_ConStr)
            h_Con.ConnectionString = h_ConStr
            h_Con.Open()
        End If
    End Sub

    Public Shared Sub h_Adpter(ByVal h_Queryy As String)
        'h_Adptr = New MySqlDataAdapter(h_Queryy, h_Con)
    End Sub

    Public Shared Function h_DatTable(ByVal querry As String) As DataTable
        h_sqlCmd = New MySqlCommand(querry, h_Con)
        h_Adptr = New MySqlDataAdapter(h_sqlCmd)
        d_DataTbl = New DataTable
        h_Adptr.Fill(d_DataTbl)
        Return d_DataTbl
    End Function

    Public Sub dispose() Implements IDisposable.Dispose
        If Not Me.h_Con.State.Closed = ConnectionState.Closed Then
            h_Con.Close()
        End If
        h_Adptr.Dispose()
        d_DataTbl.Dispose()
    End Sub


    Public Function GetTrackingDetail(ByVal Query As String) As DataTable

        Dim cmd As MySql_CommandData = Nothing

        Try
            cmd = New MySql_CommandData(MySql_Connection.ConnectTo.OtherMySqlDB)
            cmd.CmdType = CommandType.Text
            cmd.CmdText = Query
            Dim ds As DataSet = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Return ds.Tables(0)
        Catch ex As Exception
            Dim str As String = ex.Message
        Finally
            If (Not cmd Is Nothing) Then
                cmd.CloseConnection()
            End If
        End Try

    End Function


    'End Function

End Class