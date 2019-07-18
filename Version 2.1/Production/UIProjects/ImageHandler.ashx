<%@ webhandler class="ImageHandler" %>
Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.IO


Public Class ImageHandler
    Implements System.Web.IHttpHandler

    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
        InfiniLogic.AccountsCentre.Web.ImageHandler.WriteProductImage(context)
    End Sub
End Class
