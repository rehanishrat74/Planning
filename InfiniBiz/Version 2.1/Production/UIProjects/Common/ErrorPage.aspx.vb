Imports Microsoft.VisualBasic
Imports Infinilogic.AccountsCentre
Imports Infinilogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.DAL

Imports System.Resources

Public Class ErrorPage
    Inherits PageTemplate
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblErrorHeading As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrorText As System.Web.UI.WebControls.Label
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell

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
        'Put user code to initialize the page here
        Dim id As Integer
        Try
            ID = CInt(Request("id"))
            Dim strMsg As String = IIf(CommonBase.ErrorMessages(id) Is Nothing, "", CommonBase.ErrorMessages(id))

            If strMsg <> "" Then

                lblErrorHeading.Text = MyPageResource("ERROR")    '"ERROR!"
                lblErrorText.Text = strMsg

            End If

        Catch ee As Exception


        End Try
        CheckShowBackButton(id)



    End Sub

    Protected Sub CheckShowBackButton(ByVal id As ACC_Error_Messages)
        Select Case id
            Case ACC_Error_Messages.ACC_No_Product_Avaiable_For_Purchase, _
                ACC_Error_Messages.ACC_Selected_Service_Already_Purchased
                lblErrorHeading.Text = MyPageResource("IMPORTANT")  '"ERROR!"
                btnBack.Visible = True
        End Select
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        RedirectTo(BLL.ACC_Redirection.HOMEPAGE)
    End Sub
End Class
