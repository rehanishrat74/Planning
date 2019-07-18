Imports InfiniLogic.AccountsCentre.BLL

Public Class SelectCustomer
    Inherits PageTemplate

    Protected WithEvents btnCurrentCustomer As System.Web.UI.WebControls.Button
    Protected WithEvents btnNewCustomer As System.Web.UI.WebControls.Button
    Protected WithEvents frmSelCustomer As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents chkExclude As System.Web.UI.WebControls.CheckBox
    Protected WithEvents litCompanyName As System.Web.UI.WebControls.Literal
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell


    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell

#Region "Event Handlers"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        If Session("ACC_GV_ProcessCompany") = Nothing Then
            Response.Redirect("GlobalView.aspx")
        Else
            litCompanyName.Text = Session("ACC_GV_ProcessCompany")
            If Session("ACC_GV_ProcessCompany") <> "" And Session("ACC_GV_ProcessCompany") <> Nothing Then
                litCompanyName.Text &= " (Company No:" & Session("ACC_GV_CompanyNumber") & ")"
            End If
        End If


    End Sub
    Private Sub btnCurrentCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurrentCustomer.Click
        If chkExclude.Checked = True Then
            ExcludeCompany()
        Else
            MemberCompany()
        End If
    End Sub
    Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustomer.Click
        ExcludeCompany()
    End Sub
    Private Sub MemberCompany()
        Session("ACC_GV_RegistrationMode") = RegistrationMode.MemberOfGlobalView
        Response.Redirect("/Account/NewCustomer.aspx")
    End Sub
    Private Sub ExcludeCompany()
        'SignOutDestroy(True)    'Signout but do not abandon the session!!
        Session("ACC_GV_RegistrationMode") = RegistrationMode.ExcludedFromGlobalView
        Response.Redirect("/Account/NewCustomer.aspx")
    End Sub
#End Region

    Private Sub InitializeComponent()

    End Sub
End Class