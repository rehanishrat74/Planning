Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports System.Data.SqlClient
Imports System.IO

Public Class Downloads_Default
    Inherits PageTemplate

    Protected WithEvents UIForm As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgDownloads As System.Web.UI.WebControls.DataGrid
    Protected WithEvents UIBody As System.Web.UI.HtmlControls.HtmlGenericControl
    Private _oDownload As New Downloads

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcessPage()
    End Sub

    Private Sub ProcessPage()
        With dgDownloads
            Dim dtView As DataView = _oDownload.GetServicesByOptions(CustomerID, ACC_ServiceOptions.DesktopApplication + ACC_ServiceOptions.Downloadable).DefaultView
            dtView.RowFilter = ""
            .DataSource = dtView
            .DataBind()
        End With
    End Sub

    Private Sub dgDownloads_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDownloads.ItemDataBound
        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item, ListItemType.SelectedItem
                Dim lnkbtn As New WebControls.LinkButton
                Dim imgbtn As New WebControls.ImageButton
                Dim sID As String = e.Item.DataItem("ID")
                Dim sImgURL As String = GetImage(sID)
                Select Case e.Item.DataItem("Mode")
                    Case 1
                        lnkbtn.Text = "Download Now"
                        lnkbtn.CommandName = "DOWNLOAD"
                    Case 0
                        lnkbtn.Text = "Purchase Now"
                        lnkbtn.CommandName = "PURCHASE"
                End Select

                imgbtn.ImageUrl = sImgURL
                imgbtn.CommandName = lnkbtn.CommandName
                imgbtn.CommandArgument = sID
                imgbtn.ID = "IMG_" & imgbtn.CommandName & "_" & sID

                lnkbtn.CommandArgument = sID
                lnkbtn.ID = "LNK_" & lnkbtn.CommandName & "_" & sID

                AddHandler lnkbtn.Command, AddressOf ProcessCommand
                AddHandler imgbtn.Command, AddressOf ProcessCommand

                e.Item.Cells(2).Controls.Add(imgbtn)
                e.Item.Cells(2).Controls.Add(New HtmlGenericControl("BR"))
                e.Item.Cells(2).Controls.Add(lnkbtn)
        End Select
    End Sub

    Private Sub ProcessCommand(ByVal s As Object, ByVal e As CommandEventArgs)
        Select Case e.CommandName
            Case "DOWNLOAD" : DownloadService(e.CommandArgument)
            Case "PURCHASE" : Purchase(e.CommandArgument)
        End Select
    End Sub

    Private Sub DownloadService(ByVal sSrvID As String)
        Dim sSrvName As String
        Dim iSrvID As Integer = CInt(sSrvID)
        sSrvName = [Enum].GetName(GetType(ServiceID), iSrvID)

        Dim strFilname As String = Microsoft.VisualBasic.Switch(sSrvName = "AccountsPro", "AccountsProsetup.exe")
        Dim FilePath As String = Server.MapPath("..\Files\" & strFilname)
        DownloadFile(FilePath)
    End Sub

    Private Sub Purchase(ByVal sSrvID As String)
        Response.Redirect("updateservices.aspx")
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        _oDownload = Nothing
    End Sub

    Private Sub dgDownloads_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDownloads.ItemCommand

    End Sub
End Class




'Private Sub DownloadFile()
'    _strServiceName = Request.QueryString("ServiceID")

'    Dim _objEncryption As New SecureQueryString(_strServiceName)

'    _intServiceID = CInt(_objEncryption.Item("id"))

'    _intServiceID = 8

'    _strServiceName = [Enum].GetName(GetType(ServiceID), _intServiceID)

'    Dim dbReader As SqlDataReader

'    If IsServiceAllowed(_strServiceName) Then

'        Dim _objUser As New User

'        If _objUser.ACC_VerifyDownloadAllowed(ServiceOptions.Downloadable, ACC_ServiceOptions.DesktopApplication, _intServiceID) Then

'            Dim strFilname As String = Microsoft.VisualBasic.Switch(_strServiceName = "AccountsPro", "AccountsProsetup.exe")

'            Dim FilePath As String = Server.MapPath("..\Files\" & strFilname)

'            Response.ContentType = "Application/exe"
'            Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(FilePath))
'            Response.WriteFile(FilePath)
'            Response.End()

'        End If

'    End If
'End Sub

'Case 1
'    lnkbtn.Text = "Request Download Now"
'    lnkbtn.CommandName = "REQUEST"

'Private Sub RequestDownload(ByVal sSrvID As String)
'    Dim sSrvName As String, iSrvID As Integer = CInt(sSrvID)
'    sSrvName = [Enum].GetName(GetType(ServiceID), iSrvID)

'    Dim sSubject As String
'    sSubject = "Desktop App Download Request - Customer: " & Session("UserUID") & ",Service: " & sSrvName

'    'TODO: "GET EMAIL CONTENT FROM TAUHEED BHAI"
'    Dim sEmailContent As String
'    sEmailContent = "PUT EMAIL CONTENT OVER HERE - Customer: " & Session("UserUID") & ",Service: " & sSrvName

'    CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), ConfigReader.GetItem(ConfigVariables.SMTPUserID), sSubject, sEmailContent)
'End Sub
'Case "REQUEST" : RequestDownload(e.CommandArgument)

'Download Code
''''''Response.ContentType = "Application/exe"
''''''Dim downloadFile As System.IO.FileStream = New System.IO.FileStream(FilePath, IO.FileMode.Open)
''''''Response.Write(downloadFile.Length() & "#")
''''''downloadFile.Close()
'_oDownload.SetCSSStatus(CustomerID, iSrvID, False)
''''''Response.AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(FilePath))
''''''Response.WriteFile(FilePath)
''''''Response.End()
