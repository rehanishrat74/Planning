Imports System.Web
Imports InfiniLogic.AccountsCentre.common

Public Class DefaultPage

    'Inherits System.Web.UI.Page
    Inherits PageTemplate
    Protected WithEvents homepage As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents signinlink As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents MessageBar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents OrderHere1 As InfiniLogic.AccountsCentre.BLL.OrderHere



    Protected WithEvents idxTopBar As IndexHeader
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
        Response.Redirect("https://ac.infiniplan.com/account/signin.aspx")
        Dim strProductCode As String = Request.QueryString("orderhere")

        If (strProductCode <> "") Then
            If isValidProductCode(strProductCode) Then

                OrderHere1.ProductCode = strProductCode
                Dim ee As New ImageClickEventArgs(1, 1)
                OrderHere1.OrderHere_Click(Me, ee)

            Else

                'Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Hom))
                '   RedirectToErrorPage(ACC_Error_Messages.ACC_Service_Not_Available_For_Sale)

            End If

        End If


        'If User.Identity.IsAuthenticated Then Response.Redirect("/members/member.aspx")
        'Put user code to initialize the page here
        'test

        'homepage.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("HOMEPAGE")
        'If User.Identity.IsAuthenticated Then

        '    signinlink.InnerHtml = "<B>Accounts Centre Sign Out</B>"
        '    signinlink.HRef = "account/signout.aspx"

        'Else
        '    signinlink.InnerHtml = "<B>Accounts Centre Sign In</B>"
        '    signinlink.HRef = "https://www.accountscentre.com/account/signin.aspx"
        'End If
        'MessageBar.InnerHtml = ""
    End Sub

    Public Function isValidProductCode(ByVal strProductCode As String) As Boolean

        Dim ds As New DataSet
        ds = BLL.User.ACC_GetProductsToSale()
        For Each table As DataTable In ds.Tables
            For Each row As DataRow In table.Rows
                If row.Item("ProductCode") = strProductCode Then Return True
            Next
        Next
        Return False
    End Function

    'Private Sub idxTopBar_LanguageChanged(ByVal sLanguageName As String) Handles idxTopBar.LanguageChanged
    '    ChangeLanguage()
    'End Sub

    Private Sub idxTopBar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles idxTopBar.Load
        ChangeLanguage()
    End Sub

    Private Sub ChangeLanguage()
        'Dim Parameter As String, sCurrentLanguage As String
        'sCurrentLanguage = idxTopBar.CurrentLanguage
        'Parameter = IIf(sCurrentLanguage = "ENGLISH" OrElse sCurrentLanguage = "DEFAULT", "HOMEPAGE", "UNDERCONSTRUCTION")
        'homepage.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("HOMEPAGE")
    End Sub

    Private Sub idxTopBar_InfiniOfficeServiceError(ByVal errorCode As String, ByVal errorDescription As String) Handles idxTopBar.InfiniOfficeServiceError
        MessageBar.InnerHtml = errorDescription
    End Sub

End Class
