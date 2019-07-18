Imports System.Web

Public Class DownloadHandler

    Implements IHttpHandler

    Public ReadOnly Property IsReusable() As Boolean _
    Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

    Public Sub ProcessRequest(ByVal context As HttpContext) _
    Implements IHttpHandler.ProcessRequest
        context.Response.Redirect("../members/download.aspx")
    End Sub

End Class
