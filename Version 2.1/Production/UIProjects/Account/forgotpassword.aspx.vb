Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Security
Imports System.Data.SqlClient
'Imports InfiniLogic.Text
Imports InfiniLogic.AccountsCentre.Common

Public Class ForgotPassword

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

    Private _strDatabaseName As String = String.Empty
    Protected WithEvents txtuserid As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtEmail As System.Web.UI.WebControls.TextBox

    Protected WithEvents pnlBody As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMessage As System.Web.UI.WebControls.Panel
    Protected WithEvents btnForgotPassword As System.Web.UI.WebControls.Button
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents txtSurName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtFirstName As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSecondName As System.Web.UI.WebControls.TextBox
    
    Protected WithEvents lnkbtnSign As System.Web.UI.WebControls.LinkButton

    '   Public Shared ReadOnly SignInAttemptFailed As String = ACCMessage.Account_SignInAttemptFailed


    '  Private _objUser As New User()
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
        If Not Page.IsPostBack Then
            '**************(MNS)****************
            SetFocus(txtEmail)
            '***********************************
        End If

    End Sub


    Private Function ForgotPassword_DataSet()

        Dim ds As New DataSet()

        Dim objUser As New User()
        Dim objCryptography As New Cryptography()
        Dim strCustomerName As String

        Dim strEmail, strName, strPassword, strLogKey, strCartCustomerUID, strDecryptPassword, strCompanyName, _
               strTo, strFrom, strSubject, strBody, strBodyEmailAddress As String



        strCustomerName = Trim(txtSurName.Text) & " " & Trim(txtFirstName.Text) & " " & Trim(txtSecondName.Text)

        Dim i, j As Integer

        i = 0
        j = 0
        strBodyEmailAddress = String.Empty

        strEmail = Trim(txtEmail.Text)
        strName = strCustomerName
        ds = objUser.ForgotPassword(strEmail, strName)

        If Not IsNothing(ds) Then

            j = Convert.ToInt64(ds.Tables(0).Rows.Count)

            strTo = strEmail.ToString
            strFrom = ACCMessage.Email_DefaultEmailAddress
            strSubject = ACCMessage.Email_ResendPassword
            strBody = "The following are the credentials of your account: " & vbCrLf

            For i = 0 To j - 1

                Dim dr As DataRow = ds.Tables(0).Rows(i)

                strPassword = dr("cart_customer_pass")
                strLogKey = dr("logkey")
                strCartCustomerUID = dr("cart_customer_uid")


                If IsDBNull(dr("CompanyName")) = False Then
                    strCompanyName = dr("CompanyName")
                Else
                    strCompanyName = String.Empty
                End If

                strDecryptPassword = objCryptography.DeCrypt(strPassword, strLogKey)

                strBodyEmailAddress = strBodyEmailAddress & vbCrLf & _
                                    " Company Name :" & strCompanyName & vbCrLf & _
                                    " Sign-in ID :" & strCartCustomerUID & vbCrLf & _
                                    " Password  :" & strDecryptPassword & vbCrLf & vbCrLf


                strPassword = String.Empty
                strLogKey = String.Empty
                strDecryptPassword = String.Empty

            Next

            strBody = strBody & vbCrLf & _
                            strBodyEmailAddress

            objUser.SendEMail(strTo, strFrom, strSubject, strBody)

            InfoMessage = ACCMessage.Email_ForgotPassword

        Else

            ErrorMessage = ACCMessage.Account_ForgotPassword


        End If


    End Function


    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("/account/forgotpassword.aspx")

    End Sub

    Private Function VerifyEmailAddress() As Boolean

        VerifyEmailAddress = False ' Intentionally make it
        Dim objRegExp As New RegularExpressions() ' Object of InfinLogic library
        Dim strReturnMessage As String = String.Empty

        '=========================================
        ' Regular Expression syntax:
        ' --                    ---                        ----          -
        ' 00                   000                       0000        0
        ' Category ID     Expression ID        Length     Optional *

        '* If field is optional then, value will be 1.
        '===========================================

        ' Add the controls 
        objRegExp.Add("txtEmail", "0400302550", "Email")
        objRegExp.Add("txtSurName", "0700502550", "Surname")
        objRegExp.Add("txtFirstName", "0700502550", "First Name")
        If txtSecondName.Text = "" Then GoTo NotPerformRE_On_This_Feild
        objRegExp.Add("txtSecondName", "0700502550", "Second Name")
        ' Get the return message
NotPerformRE_On_This_Feild:
        strReturnMessage = objRegExp.ScanPage(Me)

        ' Now make decision, whether error has been returned or not 
        If strReturnMessage = "" Then
            ' None of the control voilates business rules
            VerifyEmailAddress = True
        Else
            ' When form controls voilate the business rules
            VerifyEmailAddress = False
            strReturnMessage = "<li>" & Replace(strReturnMessage, ",", "<li>")
            ErrorMessage = "Please enter valid data in the following field(s):" & "<Br>" & strReturnMessage
        End If

        objRegExp = Nothing

    End Function

    Private Sub btnForgotPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForgotPassword.Click
        If VerifyEmailAddress() = True Then
            ForgotPassword_DataSet()
            pnlMessage.Visible = True
            pnlBody.Visible = False
        Else
            pnlBody.Visible = False
            pnlMessage.Visible = True
        End If
        pnlMessage.Visible = True
    End Sub

    Private Sub lnkbtnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkbtnSign.Click
        Response.Redirect("/account/SignIn.aspx")
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

End Class