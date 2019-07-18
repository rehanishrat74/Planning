Imports InfiniLogic.AccountsCentre.BLL

Public Class StartDownload_Default
    Inherits PageTemplate

    Private _oDownload As New Downloads

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcessPage()
    End Sub

    Private Sub ProcessPage()
        Dim sServiceID As String = Session("ACC_DOWNLOAD_SERVICEID")
        Session("ACC_DOWNLOAD_SERVICEID") = Nothing
        If sServiceID = "" Or sServiceID = Nothing Then
            DownloadFile(sServiceID)
        End If
    End Sub

    Private Sub DownloadFile(ByVal sSrvID As String)
        Dim sSrvName As String
        Dim iSrvID As Integer = CInt(sSrvID)
        sSrvName = [Enum].GetName(GetType(ServiceID), iSrvID)

        Dim strFilname As String = Microsoft.VisualBasic.Switch(sSrvName = "AccountsPro", "AccountsProsetup.exe")
        Dim FilePath As String = Server.MapPath("..\Files\" & strFilname)

        Response.ContentType = "Application/exe"
        Dim downloadFile As System.IO.FileStream = New System.IO.FileStream(FilePath, IO.FileMode.Open)
        Response.Write(downloadFile.Length() & "#")
        downloadFile.Close()

        _oDownload.SetCSSStatus(CustomerID, iSrvID, False)
        Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(FilePath))
        Response.WriteFile(FilePath)
        Response.Flush()
        Server.Transfer("default.aspx", True)
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        _oDownload = Nothing
    End Sub
End Class
