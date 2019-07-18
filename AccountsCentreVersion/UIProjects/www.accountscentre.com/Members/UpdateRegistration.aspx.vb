#Region "Imports Libraries"

Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common

#End Region


Public Class UpdateRegistration

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region "Page Control "

    Protected WithEvents Panel8 As System.Web.UI.WebControls.Panel
    Protected WithEvents Textbox12 As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnSave As System.Web.UI.WebControls.Button
    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel
    Protected WithEvents txtEmailAddress As System.Web.UI.WebControls.TextBox
    Protected WithEvents pnlRegistration As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel6 As System.Web.UI.WebControls.Panel

#End Region

#Region "User Defined Variables"

    Dim intCustomerID As Integer = CustomerId

#End Region

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
        '*********(MNS)************
        SetFocus(txtEmailAddress)
        '**************************

        If Not Page.IsPostBack Then

            ' pnlRegistration.Visible = True

        End If

    End Sub

    '*****************************************
    '' SetFocus Function (MNS)
    Private Sub SetFocus(ByVal ctrl As Control)
        ' Define the JavaScript function for the specified control.
        Dim focusScript As String = "<script language='javascript'>" & _
          "document.getElementById('" + ctrl.ClientID & _
          "').focus();</script>"

        ' Add the JavaScript code to the page.
        Page.RegisterStartupScript("FocusScript", focusScript)
    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If VerifyEmail() = True Then

            UpdateRegistration()

        Else

            pnlInformation.Visible = True

        End If

    End Sub

    Private Function VerifyEmail() As Boolean

        VerifyEmail = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions() ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty
        Dim strMsg As String

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        objRegExp.Add("txtEmailAddress", "0400302550", "Email")

        ' Get the return message
        strReturnMessage = objRegExp.ScanPage(Me)

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyEmail = True
        Else
            ' When form controls voilate the business rules
            VerifyEmail = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br><Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    Private Sub UpdateRegistration()

        Dim objUser As New User()

        Dim strEmail As String

        strEmail = txtEmailAddress.Text

        Dim bolMsg As Boolean

        bolMsg = objUser.UpdateCustomerRegistration(intCustomerID, strEmail)

        If bolMsg Then

            Response.Redirect("https://www.accoutnscentre.com/members/defaulat.aspx")

            'Else

            '    infomessage = "Error in data saving"

            '    pnlInformation.Visible = True

        End If

    End Sub

End Class
