Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLL

Public Class PlanNavigator
    Inherits NavigatorBase

    Private _view As Page
    Private _connData As BusinessPlan.DAL.ConnectionData
    Private _curPlan As BusinessPlan.BLL.BusinessPlan
    Private _curItem As String

    Public Sub New(ByVal view As Page, ByVal connData As BusinessPlan.DAL.ConnectionData, ByVal curPlan As BusinessPlan.BLL.BusinessPlan, ByVal curItem As String)
        Me._view = view
        Me._connData = connData
        Me._curPlan = curPlan
        Me._curItem = curItem
    End Sub

    Public Overrides Function MoveForward(ByVal headingType As Integer) As String
        Dim dr As DataRow
        Dim drArray As DataRow()
        Dim headingsTable As DataTable = TextOperations.GetPlanTextHeadings(_connData, _curPlan).Tables(0)

        For Each dr In headingsTable.Rows
            If RemoveSpaces(CStr(dr.Item(1))) = _curItem And CInt(dr.Item(6)) = headingType Then
                drArray = headingsTable.Select("ParentHeadingID=" & CStr(dr.Item(0)))
                If drArray.Length = 0 Then
                    drArray = headingsTable.Select("(headingType=0 or headingType=1 or headingType=2) and HeadingID>" & CInt(dr.Item(0)) & " and ParentHeadingID=" & CInt(dr.Item(2)))
                End If

                Dim parent As Integer = CInt(dr.Item(2))
                While drArray.Length = 0
                    drArray = headingsTable.Select("(headingType=0 or headingType=1 or headingType=2) and HeadingID>" & parent & " and ParentHeadingID=" & CInt(headingsTable.Select("HeadingID=" & parent)(0).Item(2)))
                    parent = CInt(headingsTable.Select("HeadingID=" & parent)(0).Item(2))
                End While

                If drArray.Length > 0 Then
                    If CInt(drArray(0).Item(6)) = 0 Then
                        Return "/InfiniPlan/Services/Text/PlanText.aspx?hid=" & CInt(drArray(0).Item(0))
                    ElseIf CInt(drArray(0).Item(6)) = 1 Then
                        Return "/InfiniPlan/Services/Tables/Table.aspx?tableID=" & TablesBase.GetTableID(RemoveSpaces(CStr(drArray(0).Item(1))))
                    ElseIf CInt(drArray(0).Item(6)) = 2 Then
                        Return "/InfiniPlan/Services/Charts/Chart.aspx?chartID=" & ChartsBase.GetChartID(RemoveSpaces(CStr(drArray(0).Item(1))))
                    Else
                        Return ""
                    End If
                End If
            End If
        Next

        Return ""
    End Function

    Public Overrides Function MoveBackward(ByVal headingType As Integer) As String
        Dim headingsTable As DataTable = TextOperations.GetPlanTextHeadings(_connData, _curPlan).Tables(0)

    End Function

End Class
