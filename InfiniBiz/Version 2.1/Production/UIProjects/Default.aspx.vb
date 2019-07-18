Imports System.Web
Imports InfiniLogic.AccountsCentre.common

Public Class DefaultPage

    'Inherits System.Web.UI.Page
    Inherits PageTemplate
    REM SR
    Protected Sub New()
        IsHomePage = True
    End Sub
    REM SR

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
        '**************************************************************************************************
        ' Muhammad Ubaid
        '**************************************************************************************************
        Response.Redirect("/account/Signout.aspx")
        '**************************************************************************************************
    End Sub

End Class
