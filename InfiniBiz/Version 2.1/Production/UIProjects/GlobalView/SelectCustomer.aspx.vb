Imports InfiniLogic.AccountsCentre.BLL

Public Class SelectCustomer
    Inherits PageTemplate
    Protected WithEvents frmSelCustomer As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents dgrdInactivateProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblcreateglobalview As System.Web.UI.WebControls.Label
    Protected WithEvents lblwayuwant As System.Web.UI.WebControls.Label
    Protected WithEvents pnlInactivate As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMsg As System.Web.UI.WebControls.Panel
    Protected WithEvents Panel1 As System.Web.UI.WebControls.Panel
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblcompany As System.Web.UI.WebControls.Label
    Protected WithEvents lnkGoBack As System.Web.UI.WebControls.LinkButton
    Protected WithEvents LinkButton1 As System.Web.UI.WebControls.LinkButton


    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell

#Region "Event Handlers"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not IsPostBack Then
            If Session("ACC_GV_ProcessCompany") = Nothing Then
                Response.Redirect("GlobalView.aspx")
            Else
                GetInactivateProducts()
            End If
        End If
    End Sub
    'Private Sub btnCurrentCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If chkExclude.Checked = True Then
    '        ExcludeCompany()
    '    Else
    '        MemberCompany()
    '    End If
    'End Sub
    'Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ExcludeCompany()
    'End Sub
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
    Private Sub GetInactivateProducts()
        '''Created by Muhammad Ubaid
        '''
        '''
        Try
            Me.dgrdInactivateProducts.DataSource = InfiniLogic.AccountsCentre.BLL.ServicesManager.GetInactivateProducts(CustomerID)
            Me.dgrdInactivateProducts.Columns.Item(0).HeaderText = CStr(Session("ACC_GV_ProcessCompany")).Trim
            Me.dgrdInactivateProducts.DataBind()

            If Me.dgrdInactivateProducts.Columns.Count > 0 Then
                Me.pnlInactivate.Visible = True
                Me.pnlMsg.Visible = False
            Else
                Me.pnlInactivate.Visible = False
                Me.pnlMsg.Visible = True
                Me.lblMsg.Text = "You have no In-Active Product"
                Me.lblcompany.Text = CStr(Session("ACC_GV_ProcessCompany")).Trim
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgrdInactivateProducts_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdInactivateProducts.ItemCommand
        '''Created by Muhammad Ubaid
        If e.CommandName = "Activate" Then
            'Try
            '    Dim infinibiz_Services As New infinibiz_Services.Customer
            '    ' Dim result As infinibiz_Services.activateResult
            '    Dim Index As Int64 = e.Item.ItemIndex
            '    Dim Product = Me.dgrdInactivateProducts.Items(Index).Cells(1).Text, Lang = "en", companyName As String = CStr(Session("ACC_GV_ProcessCompany")).Trim
            '    Dim orderno = Me.dgrdInactivateProducts.Items(Index).Cells(2).Text, serialNo = Me.dgrdInactivateProducts.Items(Index).Cells(3).Text, cId As Int64 = CustomerID
            '    Dim acc_process_company As String = Session("ACC_GV_CompanyNumber")
            '    ' result = infinibiz_Services.activate(cId, Product, orderno, serialNo, Lang, companyName)
            '    If result.ERRORCODE = 0 Then
            '        Response.Redirect("/Globalview/Globalview.aspx")
            '    Else
            '        Me.pnlInactivate.Visible = False
            '        Me.pnlMsg.Visible = True
            '        Me.lblMsg.Text = "There is problem to activate service.."
            '        Me.lblcompany.Text = CStr(Session("ACC_GV_ProcessCompany")).Trim
            '    End If
            'Catch ex As Exception
            'End Try
        End If
    End Sub

    Private Sub lnkGoBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkGoBack.Click
        '''Created by Muhammad Ubaid
        Response.Redirect("/account/signout.aspx")
    End Sub
End Class