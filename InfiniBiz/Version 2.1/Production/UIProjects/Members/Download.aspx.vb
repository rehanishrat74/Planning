Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration.ConfigurationSettings

Public Class Download
    Inherits PageTemplate

    Protected WithEvents UIForm As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents dgDownloads As System.Web.UI.WebControls.DataGrid
    Protected WithEvents UIBody As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell

    Private _oDownload As New Downloads

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Not Page.IsPostBack Then
            With dgDownloads
                Dim dtView As DataView = _oDownload.GetServicesByOptions(CustomerID, ACC_ServiceOptions.DesktopApplication).DefaultView
                .DataSource = dtView
                .DataBind()
            End With
        End If

    End Sub

    Private Sub dgDownloads_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgDownloads.ItemCommand
        Dim dm As New DownloadManager(CustomerID)
        If (dm.CheckPermission) Then
            dm.Download(e.Item.Cells(0).Text)
        End If
    End Sub

    Private Sub dgDownloads_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgDownloads.ItemDataBound
        If e.Item.ItemIndex <> -1 Then
            Dim AvailableForDownload As Boolean = CType(e.Item.Cells(1).Text, Long) And ACC_ServiceOptions.Downloadable
            CType(e.Item.Cells(3).Controls(0), LinkButton).Enabled = AvailableForDownload

            Dim ImgBtn As ImageButton = CType(e.Item.Cells(4).Controls(1), ImageButton)

            ImgBtn.ImageUrl = GetImage(e.Item.Cells(0).Text)
            ImgBtn.Enabled = AvailableForDownload
            'ImgBtn.ImageUrl = GetImage(ServiceID.AccountsPro)

        End If
    End Sub

End Class

Public Class DownloadManager

    Private Shared Customers As ArrayList
    Private CustomerID As Integer

    Shared Sub New()
        Customers = New ArrayList
    End Sub

    Public Sub New(ByVal CustomerID As Integer)
        CustomerID = CustomerID
    End Sub

    Public Function CheckPermission() As Boolean
        Return Not Customers.Contains(CustomerID)
    End Function

    Private Function GetFilePath() As String
        Return System.Web.HttpContext.Current.Server.MapPath(AppSettings.Get("DownloadFolder"))
    End Function

    Private Function GetFileName(ByVal SID As ServiceID) As String
        Return AppSettings.Get([Enum].GetName(GetType(ServiceID), SID))
    End Function

    Public Sub Download(ByVal SID As ServiceID)

        Customers.Add(CustomerID)

        With HttpContext.Current.Response

            Dim FilePath As String = GetFilePath() & GetFileName(SID)
            .ContentType = "Application/exe"
            .AppendHeader("content-disposition", "attachment; filename=" + System.IO.Path.GetFileName(FilePath))

            Dim fs As FileStream = File.Open(FilePath, FileMode.Open, FileAccess.Read)
            Dim iPos As Integer = 0
            Const iSize As Integer = 1024 * 100
            Dim arrByte(fs.Length - 1) As Byte

            fs.Read(arrByte, 0, arrByte.Length)
            fs.Close()

            While .IsClientConnected AndAlso iPos < arrByte.Length

                .OutputStream.Write(arrByte, iPos, iSize)
                .Flush()
                iPos = iPos + iSize
                'Threading.Thread.Sleep(100)

            End While

            Customers.Remove(CustomerID)

        End With

    End Sub

End Class
