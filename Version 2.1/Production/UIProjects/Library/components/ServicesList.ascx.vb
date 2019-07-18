Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.common
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient


Public Class ServicesList
    Inherits System.Web.UI.UserControl



#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents litAvailableSrv As System.Web.UI.WebControls.Literal
    Protected WithEvents mExpress As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mAccountsProWeb As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mPayroll As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mCTReturn As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mSAccounts As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mCams As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mDCA As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents mBPLN As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tblAvailableServices As System.Web.UI.WebControls.Table
    Protected WithEvents tblToPurchaseServices As System.Web.UI.WebControls.Table
    Protected WithEvents Literal1 As System.Web.UI.WebControls.Literal
    Protected WithEvents tdAvailableServices As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdToPurchaseServices As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents tdGatewayPIN As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents ccOrderHere As InfiniLogic.AccountsCentre.BLL.OrderHere

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private ReadOnly Property CustomerID() As Int32
        Get
            Trace.Write("Service List Customer ID : " & Page.User.Identity.Name)
            Return Int32.Parse(Page.User.Identity.Name)
        End Get
    End Property

    Private ReadOnly Property IsServiceExpired(ByVal SName As String) As Boolean
        Get
            Dim servicesExpired As Hashtable = CType(Session("ServicesAlreadyExpired"), Hashtable)
            Return servicesExpired.ContainsValue(SName)
        End Get
    End Property

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here

        Dim strProductCode As String = Request.QueryString("orderhere")


        If (strProductCode <> "") Then
            If isValidProductCode(strProductCode) Then

                If (strProductCode = "CP57" OrElse strProductCode = "CP58") Then
                    strProductCode = "CP53"
                End If

                ccOrderHere.ProductCode = strProductCode

                
                    Session.Remove("RenewProductCode")
                    Dim ee As New ImageClickEventArgs(1, 1)
                    ccOrderHere.OrderHere_Click(Me, ee)



            Else

                'Response.Redirect(CommonBase.Resources(ACC_Resource.ACC_Hom))
                '    PageBase.RedirectToErrorPage(ACC_Error_Messages.ACC_Service_Not_Available_For_Sale)

            End If

        End If

        Dim objGatewayRegistration As New GatewayRegistration

        'tdGatewayPIN.Visible = Not objGatewayRegistration.IsGetGatewayPinActivated(CustomerID)

        PrepareMe()
    End Sub

    Private Function isValidProductCode(ByVal strProductCode As String) As Boolean

        Dim ds As New DataSet
        'Dim objUser As New User
        Dim str As String = ""

        ds = User.ACC_GetProductsToSale 'objUser.ACC_UpdatePackageProductDetails(CustomerID, PackageOptions.EnableSale, ServiceOptions.EnableSale)
        For Each table As DataTable In ds.Tables
            For Each row As DataRow In table.Rows
                str &= row.Item("ProductCode") & " , "
                If row.Item("ProductCode") = strProductCode Then
                    Return True
                    '----- CTReturn ------------------ Annual Accounts --------------------------- Package Code ----
                ElseIf (strProductCode = "CP57" OrElse strProductCode = "CP58") AndAlso row.Item("ProductCode") = "CP53" Then
                    Return True
                End If
            Next
        Next
        Return False
    End Function

    Private Sub PrepareMe()

        Dim sqlDR As SqlClient.SqlDataReader
        Dim dt As DataTable = Nothing
        Dim dr() As DataRow
        Dim hRow As TableRow
        Dim hCell As TableCell
        Dim serviceName As String

        Try

            tdAvailableServices.Visible = False

            sqlDR = ServicesManager.AllowedServicesMenu(CustomerID)
            With sqlDR
                While .Read
                    tdAvailableServices.Visible = True

                    hRow = New TableRow
                    hCell = GetServiceCell()

                    serviceName = .Item("MenuName")

                    If IsServiceExpired(.Item("Name")) Then
                        hCell.Text = "<a target=_self href='https://www.accountscentre.com/members/updateservices.aspx?OrderHere=" & .Item("ProductCode") & "&IsRenew=Y' class='link_text_over'>" & serviceName & " <font color='#ff0000'><b><blink>Renew</blink></b></font></a>"
                        ' hCell.Text = "<a href='https://www.accountscentre.com/members/updateservices.aspx' class='link_text_over'>" & serviceName & " <font color='#ff0000'><b><blink>Renew</blink></b></font></a>"
                    Else
                        hCell.Text = "<a href='https://www.accountscentre.com" & .Item("URL") & "'  class='link_text_over'>" & serviceName & "</a>"
                    End If

                    hRow.Cells.Add(GetBulletCell)
                    hRow.Cells.Add(hCell)
                    tblAvailableServices.Rows.Add(hRow)
                End While
            End With


            sqlDR.Close()
            tdToPurchaseServices.Visible = False

            sqlDR = ServicesManager.GetPurchasebleServices(CustomerID)
            With sqlDR
                While .Read

                    tdToPurchaseServices.Visible = True
                    hRow = New TableRow
                    hCell = GetServiceCell()

                    serviceName = .Item("MenuName")

                    hCell.Text = "<a target=_self href='https://www.accountscentre.com" & Request.Url.AbsolutePath & "?OrderHere=" & .Item("ProductCode") & "' class='link_text_over'>" & serviceName & "</a>"

                    hRow.Cells.Add(GetBulletCell)
                    hRow.Cells.Add(hCell)
                    tblToPurchaseServices.Rows.Add(hRow)

                End While
            End With
        Catch ex As Exception
        Finally
            If Not sqlDR.IsClosed Then
                sqlDR.Close()
            End If
        End Try

    End Sub

    Private Function GetBulletCell() As TableCell
        Dim hBulletCell As TableCell = New TableCell
        With hBulletCell
            .Width = Unit.Pixel(8)
            .Height = Unit.Pixel(5)
            .HorizontalAlign = HorizontalAlign.Center
            '.VerticalAlign = VerticalAlign.Top
            .Text = "<img src='/images/greenbt.jpg' width=5 height=5>"
        End With

        Return hBulletCell
    End Function

    Private Function GetServiceCell() As TableCell
        Dim hCell As TableCell = New TableCell

        With hCell
            .Width = Unit.Pixel(142)
            .Height = Unit.Pixel(5)
            .VerticalAlign = VerticalAlign.Top
            .CssClass = "link_text"
        End With

        Return hCell
    End Function


End Class
