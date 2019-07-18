Imports System.IO
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.DAL

Public Class DownloadHandler


    Public Shared Sub DownloadFile(ByRef response As System.Web.HttpResponse, ByVal connData As ConnectionData, ByVal businessID As String)

        Dim dt As System.Data.DataTable
        Dim planRTF As String

        Dim objStream As Stream
        Dim filename As String, mimetype As String
        Dim ds As DataSet = Plan.GetExportedPlan(connData, businessID)
        dt = ds.Tables(0)
        If Not dt.Rows.Count = 0 Then
            If Not IsDBNull(dt.Rows(0).Item("ExportedPlan")) Then planRTF = CStr(dt.Rows(0).Item("ExportedPlan"))
            If Not IsDBNull(dt.Rows(0).Item("DefaultFilename")) Then filename = CStr(dt.Rows(0).Item("DefaultFilename")) & "." & CStr(dt.Rows(0).Item("DefaultFileExtension"))
            If Not IsDBNull(dt.Rows(0).Item("MimeType")) Then mimetype = CStr(dt.Rows(0).Item("MimeType"))
            response.Clear()
            response.AddHeader("Content-Disposition", "attachment; filename=" & filename)
            response.ContentType = mimetype
            response.Output.Write(planRTF)
            response.Flush()
            response.End()
        End If
    End Sub
End Class



