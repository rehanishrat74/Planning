Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL


Public Class DrawPdfLogo
    Inherits System.Web.UI.Page
    'Inherits PageTemplate
   

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Dim objUser As New User

        Dim dr As SqlDataReader

        Try
            dr = objUser.AccGetCompanyInfo
            If dr.Read Then
                Response.BinaryWrite(CType(dr.Item("Logo"), Byte()))
            End If

        Catch ex As Exception
        Finally
            dr.Close()
        End Try
    End Sub

End Class
