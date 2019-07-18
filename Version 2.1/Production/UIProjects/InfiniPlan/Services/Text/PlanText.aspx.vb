Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Public Class PlanText
    Inherits TextBase
    ' Inherits System.Web.UI.Page

#Region "........................ Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblTableHeading As System.Web.UI.WebControls.Label
    Protected WithEvents btnUpdate As System.Web.UI.WebControls.Button
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents ftbText As FreeTextBoxControls.FreeTextBox
    Protected WithEvents lblErrorMessage As System.Web.UI.WebControls.Label
    Protected WithEvents btnBack As System.Web.UI.WebControls.Button
    Protected WithEvents btnNext As System.Web.UI.WebControls.Button
    Protected WithEvents tblcontents As System.Web.UI.HtmlControls.HtmlTable

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "......................Private Members"

    Dim headingID As String = ""

#End Region

#Region "......................Event Handlers "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try
            If (Not IsNothing(Request.QueryString("hid"))) Then
                headingID = Request.QueryString("hid")
                lblErrorMessage.Visible = False
                lblTableHeading.Visible = True
                btnUpdate.Visible = False
                ftbText.Visible = False
                If Not (Page.IsPostBack) Then
                    If (Not headingID.Length = 0) Then
                        Dim ds As DataSet = TextOperations.GetPlanTextHeadings(GetConnectionData, CurrentPlan)
                        Dim drArr() As DataRow = ds.Tables(0).Select("HeadingID = '" & headingID & "'")
                        lblTableHeading.Text = CStr(drArr(0).Item(2))
                        lblTableHeading.Visible = True
                        Dim textDetails As String = TextOperations.GetPlanTextData(GetConnectionData, CurrentPlan, headingID)
                        ftbText.Text = textDetails
                        ftbText.Visible = True
                        btnUpdate.Visible = True
                        tblcontents.Visible = False
                    Else
                        tblcontents.Visible = True
                    End If
                End If
                ftbText.AllowHtmlMode = False
                ftbText.EnableHtmlMode = False
                ftbText.TabMode = FreeTextBoxControls.TabMode.Disabled
                ftbText.UpdateToolbar = True

                CurPage = 1
                If (headingID.Length <> 0) Then
                    Dim fullheading As String = headingID
                    Dim headingpart As String() = fullheading.Split("_"c)
                    Dim value As String = headingpart(1)
                    CurItem = CInt(value)
                Else
                    CurItem = 147
                End If

                navController = New PlanNavigator(Me, GetConnectionData, CurrentPlan, NavigatorBase.RemoveSpaces(lblTableHeading.Text))

            Else
                Response.Redirect("/InfiniPlan/Services/Text/PlanCover.aspx")
            End If

        Catch ex As Exception
            Dim str As String = ex.Message
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim writtenHTML As String = ftbText.Text
        Dim result As Boolean = TextOperations.UpdateHtmlData(GetConnectionData, CurrentPlan, headingID, writtenHTML)
        If (result) Then
            lblErrorMessage.Text = "Record has been updated."
        Else
            lblErrorMessage.Text = "Record has not been updated due to some technical error."
        End If
        lblErrorMessage.Visible = True
        ftbText.Visible = True
        btnUpdate.Visible = True

    End Sub

#End Region

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim url As String = navController.MoveForward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Dim url As String = navController.MoveBackward(0)
        If url <> "" Then Response.Redirect(url)
    End Sub
End Class
