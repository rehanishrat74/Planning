Public Class Registration
    Inherits PageTemplate

    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents gatewayarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlPaye As System.Web.UI.WebControls.Panel
    Protected WithEvents txtCTRPincode As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlCompanyTax As System.Web.UI.WebControls.Panel
    Protected WithEvents ChkPaye As System.Web.UI.WebControls.CheckBox
    Protected WithEvents chkComapny As System.Web.UI.WebControls.CheckBox
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents txtPayePinCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents btnCancel As System.Web.UI.WebControls.Button
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tblActivationResult As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents tblActivateGateWay As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents lnkContinue As System.Web.UI.WebControls.HyperLink


    Protected WithEvents TheMenu As New LeftMenu(150)
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


    Dim objRegistration As New InfiniLogic.AccountsCentre.BLL.GatewayRegistration

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        If ChkPaye.Checked = True Or chkComapny.Checked = True Then
            btnSave.Visible = True
            btnCancel.Visible = True
        Else : ChkPaye.Checked = False And chkComapny.Checked = False
            btnSave.Visible = False
            btnCancel.Visible = False
        End If

        If Not IsPostBack Then
            If Session("CTRPINCode") <> "" Then
                txtCTRPincode.Text = Session("CTRPINCode")
            End If
            If Session("PAYEPINCode") <> "" Then
                txtPayePinCode.Text = Session("PAYEPINCode")
            End If

            If Request.UrlReferrer Is Nothing Then
                lnkContinue.NavigateUrl = "/default.aspx"
            Else
                lnkContinue.NavigateUrl = Request.UrlReferrer.ToString()
            End If
        End If
    End Sub
    Private Sub ChkPaye_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkPaye.CheckedChanged
        If ChkPaye.Checked = True Then
            pnlPaye.Visible = True
        Else
            pnlPaye.Visible = False
        End If
    End Sub


    Private Sub chkComapny_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkComapny.CheckedChanged

        If chkComapny.Checked = True Then
            pnlCompanyTax.Visible = True

        Else

            pnlCompanyTax.Visible = False
        End If
    End Sub





    Private Sub menuarea_Init(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'With TheMenu
        '    .AddItem("IMG", "/images/GatewayRegistration.jpg", "/gateway/default.aspx", True)
        '    .AddItem("CORP", "    ::. Corporation Tax", "ctreturn.aspx")
        '    .AddItem("INDV", "    ::. Individuals", "individual.aspx")
        '    .AddItem("PAYE", "    ::. PAYE And NIC", "Payroll.aspx")
        '    '.AddItem("MEM1", "/images/index1.jpg", "", True, , False)
        'End With
        'menuarea.InnerHtml = TheMenu.Render
        If Right(UCase(Request.ServerVariables("SCRIPT_NAME")), 12) = "DEFAULT.ASPX" Then gatewayarea.InnerHtml = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSystemParameter("GATEWAYPAGE")
        TheMenu = Nothing
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        objRegistration.UpdateGatewayPIN(CustomerID, txtCTRPincode.Text, txtPayePinCode.Text)
        Session("CTRPINCode") = txtCTRPincode.Text
        Session("PAYEPINCode") = txtPayePinCode.Text
        If txtCTRPincode.Text <> "" OrElse txtPayePinCode.Text <> "" Then
            'Dim strScript As String = "<script> function showAlert(){" _
            '                            & "alert('Your link with the Gateway has been activated.');" _
            '                            & "window.navigate('/Members/Default.aspx');" _
            '                            & " }showAlert();</script> "

            'RegisterClientScriptBlock("clientScript", strScript)
            tblActivationResult.Visible = True
            tblActivateGateWay.Visible = False
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtCTRPincode.Text = Session("CTRPINCode")
        txtPayePinCode.Text = Session("PAYEPINCode")
    End Sub
End Class
