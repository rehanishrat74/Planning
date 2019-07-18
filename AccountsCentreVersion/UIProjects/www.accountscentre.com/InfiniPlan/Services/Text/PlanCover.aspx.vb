Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Public Class PlanCover
    ' Inherits System.Web.UI.Page

    Inherits TextBase
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents btnUpdate As System.Web.UI.HtmlControls.HtmlInputButton
    Protected WithEvents lblErrorMessage As System.Web.UI.WebControls.Label
    Protected WithEvents lblPlanTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblCopyNumber As System.Web.UI.WebControls.Label
    Protected WithEvents lblOwner As System.Web.UI.WebControls.Label
    Protected WithEvents lblName As System.Web.UI.WebControls.Label
    Protected WithEvents lblTitle As System.Web.UI.WebControls.Label
    Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblPhone As System.Web.UI.WebControls.Label
    Protected WithEvents lblMisc As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdateText As System.Web.UI.WebControls.Button
    Protected WithEvents txtPlanTitle As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtDate As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtCopyNo As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtOwnership As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtName As System.Web.UI.HtmlControls.HtmlTextArea
    Protected WithEvents txtTitle As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtAddress As System.Web.UI.HtmlControls.HtmlTextArea
    Protected WithEvents txtPhoneNo As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents txtMisc As System.Web.UI.HtmlControls.HtmlInputText
    Protected WithEvents lblTableHeading As System.Web.UI.WebControls.Label

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitiliazeLanguage()
    End Sub


    Private Sub InitiliazeLanguage()

        Me.lblTableHeading.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblTableHeading")
        Me.btnUpdateText.Text = ResMgr.GetString("bizplanweb_services_text_plancover_btnUpdateText")
        Me.lblPlanTitle.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblPlanTitle")
        Me.lblDate.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblDate")
        Me.lblCopyNumber.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblCopyNumber")
        Me.lblOwner.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblOwner")
        Me.lblName.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblName")
        Me.lblTitle.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblTitle")
        Me.lblAddress.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblAddress")
        Me.lblPhone.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblPhone")
        Me.lblMisc.Text = ResMgr.GetString("bizplanweb_services_text_plancover_lblMisc")

    End Sub

#End Region

    Dim arrdata(8) As String
    Dim counter As Integer
    Dim headingid As Integer
    Dim childid As String
    Dim drArr() As DataRow
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CurItem = 147
        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
        drArr = ds.Tables(0).Select("HeadingType = 5")
        If Not Page.IsPostBack Then
            For counter = 0 To drArr.Length - 1
                childid = CStr(drArr(counter).Item(1))
                arrdata(counter) = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, CStr(childid))
            Next
            txtPlanTitle.Value = arrdata(0)
            txtDate.Value = arrdata(1)
            txtCopyNo.Value = arrdata(2)
            txtOwnership.Value = arrdata(3)
            txtName.Value = arrdata(4)
            txtTitle.Value = arrdata(5)
            txtAddress.Value = arrdata(6)
            txtPhoneNo.Value = arrdata(7)
            txtMisc.Value = arrdata(8)
        End If
    End Sub



    Private Sub btntextupdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim result As Boolean = True
        arrdata(0) = txtPlanTitle.Value
        arrdata(1) = txtDate.Value
        arrdata(2) = txtCopyNo.Value
        arrdata(3) = txtOwnership.Value
        arrdata(4) = txtName.Value
        arrdata(5) = txtTitle.Value
        arrdata(6) = txtAddress.Value
        arrdata(7) = txtPhoneNo.Value
        arrdata(8) = txtMisc.Value
        If txtPlanTitle.Value = "" Then txtPlanTitle.Value = CurrentPlan.PlanName

        For counter = 0 To drArr.Length - 1
            childid = CStr(drArr(counter).Item(0))
            result = TextOperations.UpdateHtmlData(GetConnectionData, CurrentPlan, CStr(childid), arrdata(counter))
            If result = False Then
                Exit For
            End If
        Next
        If (result) Then
            lblErrorMessage.Text = "Record has been updated."
        Else
            lblErrorMessage.Text = "Record has not been updated due to some technical error."
        End If
        lblErrorMessage.Visible = True
    End Sub

    Private Sub btnUpdateText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateText.Click
        Dim result As Boolean = True
        arrdata(0) = txtPlanTitle.Value
        arrdata(1) = txtDate.Value
        arrdata(2) = txtCopyNo.Value
        arrdata(3) = txtOwnership.Value
        arrdata(4) = txtName.Value
        arrdata(5) = txtTitle.Value
        arrdata(6) = txtAddress.Value
        arrdata(7) = txtPhoneNo.Value
        arrdata(8) = txtMisc.Value
        For counter = 0 To drArr.Length - 1
            childid = CStr(drArr(counter).Item(1))
            result = TextOperations.UpdateHtmlData(GetConnectionData, CurrentPlan, CStr(childid), arrdata(counter))
            If result = False Then
                Exit For
            End If
        Next
        If (result) Then
            lblErrorMessage.Text = ResMgr.GetString("bizplan_error_no_lblErrorMessage")
        Else
            lblErrorMessage.Text = ResMgr.GetString("bizplan_error_yes_lblErrorMessage")
        End If
        lblErrorMessage.Visible = True
    End Sub

    Private Sub txtMisc_ServerChange(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
