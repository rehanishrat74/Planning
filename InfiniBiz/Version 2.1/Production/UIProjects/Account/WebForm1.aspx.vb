Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm1
    Inherits System.Web.UI.Page
    ' Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
    Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents Button2 As System.Web.UI.WebControls.Button
    Protected WithEvents txtCustomerID As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtProductCode As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtOrderNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtSerialNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtLanguage As System.Web.UI.WebControls.TextBox
    Protected WithEvents ErrMsg As System.Web.UI.WebControls.Label
    Protected WithEvents Emsg As System.Web.UI.WebControls.Label
    Protected WithEvents Button3 As System.Web.UI.WebControls.Button
    Protected WithEvents tblAuthenticateEmployee As System.Web.UI.WebControls.Table

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
        'Button1_Click(sender, e)
        'Dim service As New infinibiz_Services.Customer
        'Dim info As New infinibiz_Services.SingleSigninInfo
        'info.loginid = "51879"
        'info.password = "a"
        'Dim Result As infinibiz_Services.SingleSigninResult
        'Result = service.SingleSignin(info)

        'Button2_Click(sender, e)


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objWeb As New Customer
        Dim sinfo As New SingleSigninInfo
        Dim sinfoR As SingleSigninResult

        sinfo.loginid = Trim(TextBox1.Text)
        sinfo.password = Trim(TextBox2.Text)
        sinfoR = objWeb.SingleSignin(sinfo)

        Dim loginstruct As New AutoLoginStruct
        Dim loginresult As AutoLoginResult

        loginstruct.loginid = Trim(sinfoR.InternalCustomerUID)
        loginstruct.customerid = Trim(sinfoR.InternalCustomerID)
        loginstruct.password = Trim(sinfo.password)

        loginstruct.serviceid = Session.SessionID
        loginresult = objWeb.autoLogin(loginstruct)
        If loginresult.ERRORCODE = "0" Then
            Response.Redirect(loginresult.link)
        End If
        ErrMsg.Text = loginresult.ERRORCODE & " - " & loginresult.ERRORDESC
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim objWeb As New Customer
        Dim Result As Customer.getActivationInfoResult
        Dim ProductInfo As New Customer.activationinfo
        ProductInfo.customerid = txtCustomerID.Text
        ProductInfo.language = txtLanguage.Text
        ProductInfo.orderno = txtOrderNo.Text
        ProductInfo.productcode = txtProductCode.Text
        ProductInfo.serialno = txtSerialNo.Text
        ProductInfo.serviceid = ""
        Result = objWeb.getActivationInfo(ProductInfo)
        If Result.ERRORCODE = "0" Then
            Response.Redirect(Result.link)
        End If
        Emsg.Text = Result.ERRORCODE & " - " & Result.ERRORDESC

    End Sub

    Private Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objWeb As New infinibiz_Services.Customer
        Dim loginstruct As New infinibiz_Services.AutoLoginStruct
        Dim loginresult As infinibiz_Services.AutoLoginResult
        loginstruct.loginid = Me.TextBox1.Text
        loginstruct.customerid = Me.TextBox1.Text
        loginstruct.password = Me.TextBox2.Text
        loginstruct.serviceid = Session.SessionID
        loginresult = objWeb.autoLogin(loginstruct)
        If loginresult.ERRORCODE = "0" Then
            Response.Redirect(loginresult.link)
        End If
        ErrMsg.Text = loginresult.ERRORCODE & " - " & loginresult.ERRORDESC


    End Sub
End Class
