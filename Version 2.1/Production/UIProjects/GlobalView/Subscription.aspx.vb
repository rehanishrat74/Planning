Imports System.Web.Security
Imports InfiniLogic.AccountsCentre.BLL

Public Class Subscription
    'Inherits System.Web.UI.Page
    Inherits PageTemplate

#Region "Declarations"
    Private ObjSubscriptionStatus As SubscriptionStatus
    Private StrContinueSignIn As String
    Private StrCurrentServiceLogoUrl As String
    Private ArlImageURLs As ArrayList
    Private Const COLLECTION_SERVICES As String = "CAM"
    Protected WithEvents DGLast3Months As System.Web.UI.WebControls.DataGrid
    Protected WithEvents DGExpired As System.Web.UI.WebControls.DataGrid
    Protected WithEvents BtnSignOut As System.Web.UI.WebControls.Button
    Protected WithEvents BtnRenew As System.Web.UI.WebControls.Button
    Protected WithEvents BtnContinue As System.Web.UI.WebControls.Button

    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell


         
    Protected WithEvents TheMessage As System.Web.UI.WebControls.Literal
#End Region

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "Constructor"
    Sub New()
        MyBase.new()
        ObjSubscriptionStatus = New SubscriptionStatus
    End Sub
#End Region

#Region "Events"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load
        'Put user code to initialize the page here
        CheckIfUserSignedInOrNeedsRedirection()
        If Not IsPostBack Then
            'FillArrayListOfImageURLs()
            RenderCustomerSubscriptionData()
        End If
    End Sub

    Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles BtnContinue.Click
        Continue()
    End Sub

    Private Sub BtnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles BtnRenew.Click
        Renew()
    End Sub

    Private Sub BtnSignOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles BtnSignOut.Click
        SignOut()
    End Sub

    Private Sub BothDataGrids_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) _
        Handles DGLast3Months.ItemDataBound, DGExpired.ItemDataBound
        Dim ImgControl As HtmlImage
        Dim StrImgID As String
        Select Case e.Item.ItemType
            Case ListItemType.AlternatingItem, ListItemType.Item
                'StrCurrentServiceLogoUrl = GetServiceLogoURL(e.Item.DataItem("Service"))
                StrCurrentServiceLogoUrl = GetImage(e.Item.DataItem("ServiceID"))
                If CType(sender, DataGrid).ID = "DGLast3Months" Then
                    StrImgID = "ServiceLogoUrl1"
                Else
                    StrImgID = "ServiceLogoUrl2"
                End If
                ImgControl = CType(e.Item.Cells(0).FindControl(StrImgID), HtmlImage)
                With ImgControl
                    .Src = StrCurrentServiceLogoUrl
                    .Alt = "Service: " & e.Item.DataItem("Service")
                End With
        End Select
    End Sub
#End Region

#Region "Procedures"
        'Show Data in Data Grid, it is used to render the Services and their status on page
    Private Sub RenderCustomerSubscriptionData(Optional ByVal bRecordsFilterChanged As Boolean = False)
        Dim DtCustomerSubscription As DataTable
        Dim htExpiredSubscription As New Hashtable

        With ObjSubscriptionStatus
            'Get Customer's Subscription

            'Last 3 Months Section
            DtCustomerSubscription = .getCustomerServiceStatusByID(.CustSrvStatusBehavior.Last3MonthsPeriod, CustomerID)
            If DtCustomerSubscription.Rows.Count > 0 Then
                DGLast3Months.DataSource = DtCustomerSubscription
                DGLast3Months.DataBind()
                'BtnContinue.Visible = True

                'For Each dr As DataRow In DtCustomerSubscription.Rows
                '    With dr
                '        htExpiredSubscription.Add(.Item("Service"), "Last3Months")
                '    End With
                'Next
            Else
                'BtnContinue.Visible = False
            End If

            'Expired            
            DtCustomerSubscription = .getCustomerServiceStatusByID(.CustSrvStatusBehavior.OverDueDate, CustomerID)
            If DtCustomerSubscription.Rows.Count > 0 Then
                DGExpired.DataSource = DtCustomerSubscription
                DGExpired.DataBind()

                'For Each dr As DataRow In DtCustomerSubscription.Rows
                '    With dr
                '        htExpiredSubscription.Add(.Item("Service"), "OverDueDate")
                '    End With
                'Next
            End If

            'Both
            If DtCustomerSubscription.Rows.Count = 0 And DtCustomerSubscription.Rows.Count = 0 Then
                BtnRenew.Visible = False
                TheMessage.Text = "Dear Customer, currently you have no such services that are expired or about to expired."
            End If

            ''
            'Session("Subscription_ExpiredList") = htExpiredSubscription
        End With
    End Sub

    Private Sub CheckIfUserSignedInOrNeedsRedirection()
        If User.Identity.IsAuthenticated = False Then
            Response.Redirect("/Account/SignIn.aspx")
        Else
            If Not Request.Params("ourl") Is Nothing Then
                StrContinueSignIn = Request.Params("ourl").ToString
            Else
                StrContinueSignIn = "/members/default.aspx"
            End If
        End If
    End Sub

    Private Sub Continue()
        Response.Redirect(StrContinueSignIn)
    End Sub
    Private Sub SignOut()
        Response.Redirect("/Account/SignOut.aspx")
    End Sub
    Private Sub Renew()
        Response.Redirect("/Members/UpdateServices.aspx")
    End Sub

    'Private Function GetServiceLogoURL(ByVal sServiceName As String) As String
    '    Dim sImageURL As String
    '    sServiceName = SubscriptionStatus.GetProperServiceMapping(sServiceName)
    '    For Each sImageURL In ArlImageURLs
    '        If UCase(sServiceName) = "SACCOUNTS" Then Return "/images/logoannual.jpg"
    '        If InStr(sImageURL, sServiceName, CompareMethod.Text) > 0 Then
    '            Return sImageURL
    '            Exit For
    '        End If
    '    Next
    '    'Select Case UCase(sServiceName)
    '    '        'Case "ACCOUNTSPRO" 'NOT USED BY US
    '    '        'sImageURL = "/images/LogoAccountspro.jpg"
    '    '    Case "EXPRESS"
    '    '        sImageURL = "/images/logoexpress.jpg"
    '    '    Case "PAYROLL"
    '    '        sImageURL = "/images/logopayroll.jpg"
    '    '    Case "CTRETURN"
    '    '        sImageURL = "/images/logoctreturn.jpg"
    '    '    Case "SACCOUNTS"
    '    '        sImageURL = "/images/logoannual.jpg"
    '    '    Case "COLLECTION SERVICES"
    '    '        sImageURL = "/images/logocam.jpg"
    '    '        'Case "INFINISHOPS"
    '    '        'sImageURL = ""
    '    'End Select
    'End Function
    'Private Sub FillArrayListOfImageURLs()
    '    ArlImageURLs = New ArrayList
    '    With ArlImageURLs
    '        .Capacity = 6
    '        .Add("/images/Logoaccountspro.jpg")
    '        .Add("/images/logoexpress.jpg")
    '        .Add("/images/logopayroll.jpg")
    '        .Add("/images/logoctreturn.jpg")
    '        .Add("/images/logoannual.jpg")  'TEMPOO Name needs to be changed
    '        .Add("/images/logocam.jpg")
    '    End With
    'End Sub

#End Region

    Private Sub DGExpired_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGExpired.SelectedIndexChanged

    End Sub
End Class
