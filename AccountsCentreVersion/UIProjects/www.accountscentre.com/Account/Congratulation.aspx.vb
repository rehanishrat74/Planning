#Region "Imports Libraries"

Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.Common
Imports System.Web.Mail

#End Region

'http://www.accountscentre.com/Account/NewCustomer.aspx

Public Class Congratulation

    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region "Controls used in page."

    Protected WithEvents Panel8 As System.Web.UI.WebControls.Panel
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents pnlInformation As System.Web.UI.WebControls.Panel

#End Region

#Region " Web Form Designer Generated Code "

    '    This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        '        CODEGEN: This method call is required by the Web Form Designer
        '        Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        infomessage = ACCMessage.Account_UpdateCustomerServices
    End Sub

End Class
