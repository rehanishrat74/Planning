#Region "    Imports"
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Data.SqlClient
#End Region
Public Class AddCompany
    Inherits PageTemplate
#Region "REMSR:    Declarations"
    Protected WithEvents txtUserID, txtPassword As TextBox
    Protected WithEvents btnCancel, btnUpdate As Button

    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell



    Protected WithEvents frmAddCompany As HtmlForm
#End Region
#Region "REMSR:    Routines"
    'Events
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrepareMe()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        AddInGlobalView()
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("GlobalView.aspx")
    End Sub
    'Routines    
    Private Sub AddInGlobalView()
        If IsDataValid() = False Then Exit Sub
        Dim iCustomerID As Integer
        If VerifyUserCredentials(txtUserID.Text, txtPassword.Text, iCustomerID) = False Then Exit Sub
        Dim objGlobalView As GlobalView = New GlobalView
        Dim sRetMessage As String, iParentCustomerID As Integer
        iParentCustomerID = Session("ACC_GV_ParentCustomerID")
        sRetMessage = objGlobalView.AddInGlobalView(iParentCustomerID, iCustomerID, False, True)
        If sRetMessage = "" Then
            Dim sqlRegComInfo As SqlDataReader = objGlobalView.GetRegisteredCompanyInfo(iCustomerID) 'Ok
            If sqlRegComInfo.Read() Then
                If IsDBNull(sqlRegComInfo("CompName")) = False Then
                    Session("ACC_GV_LastAddedCompName") = sqlRegComInfo("CompName")
                Else
                    Session("ACC_GV_LastAddedCompName") = ""
                End If
            End If
            If Not sqlRegComInfo Is Nothing Then
                sqlRegComInfo.Close()
                sqlRegComInfo = Nothing
            End If
            Response.Redirect("GlobalView.aspx")
        Else
            ErrorMessage = sRetMessage
        End If
    End Sub
    Private Sub PrepareMe()
        SetFocus(txtUserID)
    End Sub
    Private Sub SetFocus(ByVal ctrl As Control)
        Dim focusScript As String = _
          "<SCRIPT LANGUAGE='javascript'>" & _
          "     document.getElementById('" & ctrl.ClientID & "').focus();" & _
          "</SCRIPT>"
        Me.RegisterStartupScript("FocusScript" & ctrl.ClientID, focusScript)
    End Sub
    Private Function IsDataValid() As Boolean
        Dim sExp As String = "txtUserID-0100100080-You must enter a valid userid,txtpassword-0203400160-You must enter a valid password"
        sExp = ApplyRegularExpressions(sExp)
        If Len(sExp) > 0 Then
            ErrorMessage = sExp
            Return False
        Else
            Return True
        End If
    End Function
#End Region

    Private Sub InitializeComponent()

    End Sub
End Class
