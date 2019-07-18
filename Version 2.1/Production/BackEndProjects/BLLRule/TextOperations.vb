Option Strict On

#Region "Imports "

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.Data
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports InfiniLogic.Text

#End Region

Public Class TextOperations

#Region "Public Methods"

    Public Shared Function GetTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataSet
        Dim command As New InfiniCommand("BPL_GetTextHeadings")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        ' 0 for Common : 1 for Products : 2 for Services : 3 for Both
        command.AddParameter("@businessGoods", GetBusinessGoods(currentPlan.BusinessGoods))
        '0 for Common : 1 for Ongoing : 2 for Startup Plans
        command.AddParameter("@IsOngoing", GetBusinessStatus(currentPlan.IsOngoing))

        Dim ds As DataSet = DataAccess.ExecuteDataSet(connData, command)
        Return ds
    End Function

    Public Shared Function GetTextData(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal headingID As Integer) As String

        Dim command As New InfiniCommand("BPL_GetTextDataDetails")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        command.AddParameter("@headingID", headingID)

        Dim data As String
        Dim reader As IDataReader = DataAccess.ExecuteDataReader(connData, command)

        If (reader.Read) Then
            data = CStr(reader(2))
        End If

        Return data
    End Function

    Public Shared Function InsertTextData(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal headingID As Integer, ByVal textDetails As String) As Boolean

        Dim command As New InfiniCommand("BPL_InsertTextDetails")
        command.AddParameter("@PlanID", currentPlan.PlanID)
        command.AddParameter("@headingID", headingID)
        command.AddParameter("@data", textDetails)

        DataAccess.ExecuteNonQuery(connData, command)

    End Function

#Region ".........................BizPlan Web Methods"

    Public Shared Function GetPlanTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As DataSet

        Dim cmd As New CommandData(connData.CustomerID)
        Dim ds As DataSet
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_GetTextHeadings"
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            ' 0 for Common : 1 for Products : 2 for Services : 3 for Both
            cmd.AddParameter("@businessGoods", GetBusinessGoods(currentPlan.BusinessGoods))
            '0 for Common : 1 for Ongoing : 2 for Startup Plans
            cmd.AddParameter("@IsOngoing", GetBusinessStatus(currentPlan.IsOngoing))

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()

            cmd.Commit()

        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        Return ds
    End Function
#Region " PlanoutLine"
    Public Shared Function InsertPlanTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal HeadingId As Object, ByVal HeadingName As String, ByVal ParentHeadingId As String, ByVal InsertID As Integer) As String

        Dim cmd As New CommandData(connData.CustomerID)
        Dim ds As DataSet
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_InsertTextHeading"
            cmd.AddParameter("@HeadingId", HeadingId)

            cmd.AddParameter("@HeadingName", HeadingName)
            cmd.AddParameter("@ParentHeadingId", ParentHeadingId)
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            cmd.AddParameter("@businessGoods", GetBusinessGoods(currentPlan.BusinessGoods))
            cmd.AddParameter("@IsOngoing", GetBusinessStatus(currentPlan.IsOngoing))
            cmd.AddParameter("@InsertID", InsertID)

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()

            cmd.Commit()

        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        'Return ds
    End Function

    Public Shared Function DeletePlanTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal id As Integer) As DataSet

        Dim cmd As New CommandData(connData.CustomerID)
        Dim ds As DataSet
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_DeleteTextDataHeading"
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            cmd.AddParameter("@id", id)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()

            cmd.Commit()

        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        'Return ds
    End Function
    Public Shared Function RestorePlanTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan) As String

        Dim cmd As New CommandData(connData.CustomerID)
        Dim ds As DataSet
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_RestoreTextHeadingDefaults"
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()

            cmd.Commit()

        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        'Return ds
    End Function

    Public Shared Function ReNamePlanTextHeadings(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal IndexId As Integer, ByVal HeadingID As String, ByVal HeadingName As String) As String

        Dim cmd As New CommandData(connData.CustomerID)
        Dim ds As DataSet
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_RenameTextHeading"
            cmd.AddParameter("@IndexId", IndexId)
            cmd.AddParameter("@Headingid", HeadingID)
            cmd.AddParameter("@HeadingName", HeadingName)
            cmd.AddParameter("@PlanID", currentPlan.PlanID)


            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            cmd.ClearParameters()

            cmd.Commit()

        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        'Return ds
    End Function

#End Region
    Public Shared Function GetPlanTextData(ByRef connData As ConnectionData, ByVal currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal headingID As String) As String

        Dim cmd As New CommandData(connData.CustomerID)
        Dim reader As SqlDataReader
        Dim textDetails As String
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_GetTextDataDetails"
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            cmd.AddParameter("@headingID", headingID)

            reader = CType(cmd.Execute(ExecutionType.ExecuteReader), SqlDataReader)
            If (reader.Read) Then
                textDetails = CStr(reader(3))
            End If
            reader.Close()
            cmd.ClearParameters()
            cmd.Commit()
        Catch sqle As SqlException
            cmd.RollBack()
        Catch ex As Exception
            cmd.RollBack()
        End Try
        Return textDetails
    End Function

    Public Shared Function UpdateHtmlData(ByRef connData As ConnectionData, ByRef currentPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan, ByVal headingID As String, ByVal htmlDetails As String) As Boolean

        Dim reValidator As New RegularExpressions

        reValidator.ScanControl(htmlDetails, "0203509991")
        Dim cmd As New CommandData(connData.CustomerID)
        Dim flag As Boolean = False
        Dim textDetails As String
        Try
            cmd.BeginTransaction()
            cmd.CmdText = "BPL_UpdateHtmlDetails"
            cmd.AddParameter("@PlanID", currentPlan.PlanID)
            cmd.AddParameter("@headingID", headingID)
            cmd.AddParameter("@data", htmlDetails)

            flag = CBool(cmd.Execute(ExecutionType.ExecuteNonQuery))
            cmd.ClearParameters()
            cmd.Commit()
        Catch sqle As SqlException
            cmd.RollBack()
            Return flag
        Catch ex As Exception
            cmd.RollBack()
            Return flag
        End Try
        Return flag

    End Function

#End Region



#End Region

#Region "Private Shared Methods "

    Private Shared Function GetBusinessGoods(ByVal businessGoods As BusinessGoodsType) As Integer
        Select Case businessGoods
            Case BusinessGoodsType.Products
                Return 1
            Case BusinessGoodsType.Services
                Return 2
            Case BusinessGoodsType.Both
                Return 3
            Case Else
                Return 0
        End Select

    End Function

    Private Shared Function GetBusinessStatus(ByVal IsOngoing As Boolean) As Integer
        If IsOngoing Then
            Return 1
        Else
            Return 2
        End If
        Return 0
    End Function
#End Region

End Class
