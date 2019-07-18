Public Class yousuf_test
    Inherits PageTemplate

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Label4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMerchantID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label3 As System.Web.UI.WebControls.Label
    Protected WithEvents rbIsNotInfinishopCustomer As System.Web.UI.WebControls.RadioButton
    Protected WithEvents rbIsInfinishopCustomer As System.Web.UI.WebControls.RadioButton
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMerchantURL As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtGeneratorID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label5 As System.Web.UI.WebControls.Label
    Protected WithEvents btnBuildMerchant As System.Web.UI.WebControls.Button
    Protected WithEvents txtChildID As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtOrderNo As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label7 As System.Web.UI.WebControls.Label
    Protected WithEvents Label8 As System.Web.UI.WebControls.Label
    Protected WithEvents Label9 As System.Web.UI.WebControls.Label
    Protected WithEvents btnCallIOService As System.Web.UI.WebControls.Button
    Protected WithEvents lblErrorCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblErrorDesc As System.Web.UI.WebControls.Label
    Protected WithEvents Label10 As System.Web.UI.WebControls.Label
    Protected WithEvents txtMerchantServiceOrderNo As System.Web.UI.WebControls.TextBox

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
    End Sub

    Private Sub btnBuildMerchant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildMerchant.Click
        Dim CurrencyDBID As String = "1"
        Dim MerchantID As String = txtMerchantID.Text
        Dim MerchantURL As String = txtMerchantURL.Text
        Dim GeneratorID As String = txtGeneratorID.Text
        Dim SendEmail As Boolean = False
        Dim IsInfinishopCustomer = rbIsInfinishopCustomer.Checked
        Dim OrderNo = txtMerchantServiceOrderNo.Text

        Dim objBuildMerchantResult As Infinilogic.AccountsCentre.BLL.Merchant.BuildMerchantResult
        Trace.Write("Calling Merchant Service:")
        Trace.Write("    IsInfinishopCustomer=" & IsInfinishopCustomer)
        Trace.Write("    CurrencyDBID=" & CurrencyDBID)
        Trace.Write("    MerchantID =" & MerchantID)
        Trace.Write("    MerchantURL =" & MerchantURL)
        Trace.Write("    GeneratorID =" & GeneratorID)

        objBuildMerchantResult = InfiniLogic.AccountsCentre.BLL.Merchant.BuildMerchant(IsInfinishopCustomer, CurrencyDBID, MerchantID, MerchantURL, GeneratorID, OrderNo, SendEmail)
        Trace.Write("Merchant Service is ok")

        Trace.Write("objBuildMerchantResult.ERRORCODE=" & objBuildMerchantResult.ErrorCode)
        Trace.Write("objBuildMerchantResult.ERRORDESC=" & objBuildMerchantResult.ErrorDesc)

        lblErrorCode.Text = objBuildMerchantResult.ErrorCode
        lblErrorDesc.Text = objBuildMerchantResult.ErrorDesc
    End Sub

    Private Sub btnCallIOService_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCallIOService.Click
        Dim ChildID As String = txtChildID.Text
        Dim OrderNo As String = txtOrderNo.Text

        Try
            Dim objIOService As New InfiniLogic.AccountsCentre.BLL.InfiniOfficeService
            Trace.Write("Calling CallIOServices: ChildID = " & ChildID & " - OrderID=" & OrderNo)
            objIOService.CallIOServices(ChildID, OrderNo)
            Trace.Write("CallIOServices is ok")

            lblErrorCode.Text = 0
            lblErrorDesc.Text = "Operation Completed Successfully"
        Catch ex As Exception
            lblErrorCode.Text = 10
            lblErrorDesc.Text = ex.Message
        End Try
    End Sub
End Class
