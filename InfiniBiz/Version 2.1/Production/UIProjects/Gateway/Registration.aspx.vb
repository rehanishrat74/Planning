Public Class Registration
    Inherits PageTemplate

    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents gatewayarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
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
    Protected WithEvents pnlPaye As System.Web.UI.WebControls.Panel
    Protected WithEvents tdPaye As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trPaye As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdCompany As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lblactivategateway As System.Web.UI.WebControls.Label
    Protected WithEvents lblactivated As System.Web.UI.WebControls.Label
    Protected WithEvents Td3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td4 As System.Web.UI.HtmlControls.HtmlTableCell

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


        'If ChkPaye.Checked = True Or chkComapny.Checked = True Then
        '    btnSave.Visible = True
        '    btnCancel.Visible = True
        'Else : ChkPaye.Checked = False And chkComapny.Checked = False
        '    btnSave.Visible = False
        '    btnCancel.Visible = False
        'End If

        If Not IsPostBack Then
            'If Session("CTRPINCode") <> "" Then
            '    txtCTRPincode.Text = Session("CTRPINCode")
            'End If
            'If Session("PAYEPINCode") <> "" Then
            '    txtPayePinCode.Text = Session("PAYEPINCode")
            'End If

            LoadGatewayPIN()

            If Request.UrlReferrer Is Nothing Then
                lnkContinue.NavigateUrl = "/members/default.aspx"
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

        If chkComapny.Checked Then
            DisplayButtons(True)
        Else
            DisplayButtons(pnlPaye.Visible)
        End If
    End Sub

    Private Sub chkComapny_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkComapny.CheckedChanged
        If chkComapny.Checked = True Then
            pnlCompanyTax.Visible = True
        Else
            pnlCompanyTax.Visible = False
        End If
        If ChkPaye.Checked Then
            DisplayButtons(True)
        Else
            DisplayButtons(pnlCompanyTax.Visible)
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
        'Session("CTRPINCode") = txtCTRPincode.Text
        'Session("PAYEPINCode") = txtPayePinCode.Text
        If txtCTRPincode.Text <> "" OrElse txtPayePinCode.Text <> "" Then
            'Dim strScript As String = "<script> function showAlert(){" _
            '                            & "alert('Your link with the Gateway has been activated.');" _
            '                            & "window.navigate('/Members/Default.aspx');" _
            '                            & " }showAlert();</script> "

            'RegisterClientScriptBlock("clientScript", strScript)
            tblActivationResult.Visible = True
            tblActivateGateWay.Visible = False
        End If

        LoadGatewayPIN()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        'txtCTRPincode.Text = Session("CTRPINCode")
        'txtPayePinCode.Text = Session("PAYEPINCode")

        pnlPaye.Visible = False
        pnlCompanyTax.Visible = False

        ChkPaye.Checked = False
        chkComapny.Checked = False

        LoadGatewayPIN()
    End Sub

    Private Sub LoadGatewayPIN()
        Dim sqlDR As System.data.SqlClient.SqlDataReader

        Try
            tdCompany.InnerHtml = "&nbsp;"

            sqlDR = objRegistration.GetGatewayPIN(CustomerID)

            With sqlDR
                While .Read
                    If (Not IsDBNull(.Item("CTRPINCode"))) AndAlso (.Item("CTRPINCode") <> "") Then
                        tdCompany.InnerHtml = "<b>[ Activated : " & .Item("CTRPINCode") & " ]</b>"
                        txtCTRPincode.Text = .Item("CTRPINCode")
                    End If

                    If .Item("IsPayroll") Then
                        trPaye.Visible = True
                        tdPaye.InnerHtml = "&nbsp;"

                        If (Not IsDBNull(.Item("PAYEPinCode"))) AndAlso (.Item("PAYEPinCode") <> "") Then
                            tdPaye.InnerHtml = "<b>[ Activated : " & .Item("PAYEPinCode") & " ]</b>"
                            txtPayePinCode.Text = .Item("PAYEPinCode")
                        End If
                    End If
                End While
            End With

        Catch ex As Exception
        Finally
            If Not sqlDR.IsClosed Then
                sqlDR.Close()
            End If
        End Try

        DisplayButtons(False)

    End Sub

    Private Sub DisplayButtons(ByVal IsVisible As Boolean)
        btnSave.Visible = IsVisible
        btnCancel.Visible = IsVisible

    End Sub


End Class
