Imports InfiniLogic.AccountsCentre.BLL
Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient
Imports System.Data
Imports System.Net

Public Class MembersMember
    Inherits PageTemplate

    Protected idxtopbar As IndexHeader

#Region "<<< <<< <<< <<< <<< Declarations >>> >>> >>> >>> >>>"
    Protected WithEvents compName As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pWebsite As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pRegNo As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pAddress As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pTel As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pFax As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Pemail As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents PCPerson As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pDirectors As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents sExpress As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sPayroll As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sCTReturn As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sSAccounts As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sCams As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sDCA As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents pGateway As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sNotifications As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sExpress1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sExpress2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sExpress3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sExpress4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sExpress5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sPayroll6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CTReturn1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CTReturn2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CTReturn3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CTReturn4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sSAccounts1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sSAccounts2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sSAccounts3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sSAccounts4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sSAccounts5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Cams1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Cams2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Cams3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Cams4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Cams5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pNotification As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pUnreadMsg As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pTotalMsg As System.Web.UI.HtmlControls.HtmlTableCell
    'Protected WithEvents AccountsPro As System.Web.UI.HtmlControls.HtmlTable

    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents sAccountsProWeb As System.Web.UI.HtmlControls.HtmlTable
    Protected WithEvents sAccountsProWeb1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sAccountsProWeb2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sAccountsProWeb3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sAccountsProWeb4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents sAccountsProWeb5 As System.Web.UI.HtmlControls.HtmlTableCell

    Protected WithEvents pSeceratory As System.Web.UI.HtmlControls.HtmlTableCell

    Private htExpiredSubscription As New Hashtable
#End Region

#Region "<<< <<< <<< <<< <<< Annual Accounts Declarations >>> >>> >>> >>> >>>"

    Protected WithEvents pnlAnnualAccountsStatus As System.Web.UI.WebControls.Panel
    Protected WithEvents litIncDate As System.Web.UI.WebControls.Literal
    Protected WithEvents litARD As System.Web.UI.WebControls.Literal
    Protected WithEvents dgridAnnualAccounts As System.Web.UI.WebControls.DataGrid
    Private mbIsDue As Boolean
    Private mbHasAnnualAccountsData As Boolean
    Private mbOnlySummary As Boolean
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents lnkOrderDetails As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lnkInvoiceDetails As System.Web.UI.WebControls.LinkButton
    Protected WithEvents pnlAnnualACFiled As System.Web.UI.WebControls.Panel
    Protected WithEvents dgrdAnnualACFiled As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrdCTReturnFiled As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlCTReturnFiled As System.Web.UI.WebControls.Panel
    Protected WithEvents dgrdDCAccountsFiled As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlDCAccountsFiled As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlDocArchive As System.Web.UI.WebControls.Panel
    Protected WithEvents lblunread As System.Web.UI.WebControls.Label
    Protected WithEvents lbltotal As System.Web.UI.WebControls.Label
    Protected WithEvents lblincorporationdate As System.Web.UI.WebControls.Label
    Protected WithEvents lblaccreferencedate As System.Web.UI.WebControls.Label
    Protected WithEvents lblThereIsNoRecord As System.Web.UI.WebControls.Label
    Protected WithEvents Td1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents A1 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td3 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td4 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td5 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td6 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td7 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents Td8 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents A2 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents A3 As System.Web.UI.HtmlControls.HtmlAnchor
    Protected WithEvents Td9 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents IShops_btn As System.Web.UI.WebControls.ImageButton

    Public _CompanyName As String

#End Region

#Region "<<< <<< <<< <<< <<< Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Event handlers >>> >>> >>> >>> >>>"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        If (IsServiceAvailable(CustomerID, 16) AndAlso Not CBool(Session(session_IsEmployee))) Then
            IShops_btn.Visible = True
        End If

        Trace.Write("Page Load : Customer ID -> " & CustomerID)
        'AC_CR_00005
        'ShowProfile()        
        'ShowGateway()
        Trace.Write("Page Load Calling LoadExpiredList()")
        LoadExpiredList()

        Trace.Write("Page Load Calling ShowServices(True)")
        ShowServices(True)

        Trace.Write("Page Load Calling LoadAnnualAccountsStatusGrid()")
        LoadAnnualAccountsStatusGrid()
        'AC_CR_00005
        'Trace.Write("Page Load Calling ShowNotification()")
        ShowNotification()

        Trace.Write("Page Load Calling LoadFiledDocuments()")
        LoadFiledDocuments()

        'Trace.Write("Page Load Calling ShowMessages()")
        'ShowMessages()
    End Sub

    Public Sub dgridAnnualAccounts_ItemDataBound(ByVal s As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                Dim lblStatus As Label = CType(e.Item.FindControl("lblStatus"), Label)
                If lblStatus.Text = "DUE" Then
                    lblStatus.ForeColor = Color.DarkOrange
                ElseIf lblStatus.Text = "OVER DUE" Then
                    lblStatus.ForeColor = Color.Red
                End If
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Response.Redirect("https://" & Request.Url.Host & "/members/profile.aspx")
    End Sub

    'Private Sub imgBtnExpress_Click(ByVal sender As SysappendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(7);' >&nbsp;|&nbsp;Global View &nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");tem.Object, ByVal e As System.Web.UI.ImageClickEventArgs)

    '    If imgBtnExpress.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/Express/")
    '    End If
    'End Sub

    'Private Sub imgBtnAccProWeb_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnAccProWeb.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/AccountsPro/")
    '    End If
    'End Sub

    'Private Sub imgBtnPayroll_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnPayroll.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/Payroll/")
    '    End If
    'End Sub

    'Private Sub imgBtnCTReturn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnCTReturn.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/CTReturn/")
    '    End If
    'End Sub

    'Private Sub imgBtnSAccounts_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnSAccounts.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/CTReturn/Forms/Introduction.aspx")
    '    End If
    'End Sub

    'Private Sub imgBtnCams_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnCams.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/CAM/Service/")
    '    End If
    'End Sub

    'Private Sub imgBtnDCA_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnDCA.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/ctreturn/forms/dcaccounts.aspx")
    '    End If
    'End Sub

    Private Sub lnkOrderDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkOrderDetails.Click
        Session("LinkRequest") = "OrderDetails"
        Response.Redirect("/Invoice/TransactionDetail.aspx")
    End Sub

    Private Sub lnkInvoiceDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkInvoiceDetails.Click
        Session("LinkRequest") = "InvoiceDetails"
        Response.Redirect("/Invoice/TransactionDetail.aspx")
    End Sub

    'Private Sub imgBtnBizPlan_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs)
    '    If imgBtnBizPlan.CommandName = "Expired" Then
    '        Response.Redirect("/Members/UpdateServices.aspx")
    '    Else
    '        Response.Redirect("/BizPlanWeb/Services/Plan/Home.aspx")
    '    End If

    'End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="source"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	05/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub dgrdAnnualACFiled_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdAnnualACFiled.ItemCommand, dgrdCTReturnFiled.ItemCommand, dgrdDCAccountsFiled.ItemCommand
        '--------------------------------------------------------------------------------
        DownloadDocuments(CInt((CType(source, DataGrid)).Items(e.Item.ItemIndex).Cells(2).Text))
        '--------------------------------------------------------------------------------
    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Helper Functions/Procedures >>> >>> >>> >>> >>>"

    Private Sub LoadAnnualAccountsStatusGrid()
        Dim dtblAnnualAccounts As DataTable, dgrid As DataGrid
        dgrid = dgridAnnualAccounts
        dgrid.Visible = False

        Dim oUser As New InfiniLogic.AccountsCentre.BLL.User, dtblACU As DataTable
        dtblACU = oUser.GetACUserRecordByID(CustomerID)

        If IsNothing(dtblACU) = False AndAlso dtblACU.Rows.Count > 0 Then

            _CompanyName = dtblACU.Rows(0).Item("CompName")

            Dim sARD As String, dtIncDate As Date

            If IsDBNull(dtblACU.Rows(0).Item("ARD")) = False AndAlso IsValidARD(dtblACU.Rows(0).Item("ARD")) Then
                sARD = dtblACU.Rows(0).Item("ARD")
                litARD.Text = sARD

                Dim strARDDate() As String
                strARDDate = Split(sARD, "/")
                If strARDDate.Length = 2 AndAlso IsNumeric(strARDDate(0)) AndAlso strARDDate(0) >= 1 AndAlso strARDDate(0) <= 31 AndAlso strARDDate(1) >= 1 AndAlso strARDDate(1) <= 12 Then
                    litARD.Text = strARDDate(0) & ", " & MonthName(strARDDate(1))
                End If
            Else
                sARD = ""
                litARD.Text = "Not Available"
            End If

            If IsDBNull(dtblACU.Rows(0).Item("IncDate")) Then
                dtIncDate = Nothing
                litIncDate.Text = "Not Available"
            Else
                dtIncDate = dtblACU.Rows(0).Item("IncDate")
                litIncDate.Text = Format(dtIncDate, "dd MMMM, yyyy")
            End If

            If sARD <> "" AndAlso (dtIncDate <> Nothing) Then
                Dim objAnnualAccounts As New AnnualAccounts
                dtblAnnualAccounts = objAnnualAccounts.GetAnnualAccountsStatus(CustomerID, sARD, dtIncDate)
            End If

            'dgrid = CType(dgridGlobalView.Items(0).FindControl("dgridAnnualAccounts"), DataGrid)
            'Dim litThereIsNoRecord As System.Web.UI.WebControls.Literal
            'litThereIsNoRecord = CType(dgridGlobalView.Items(0).FindControl("litThereIsNoRecord"), Literal)

            If dtblAnnualAccounts Is Nothing Then
                lblThereIsNoRecord.Visible = True
                Exit Sub
            End If

            If dtblAnnualAccounts.Rows.Count > 0 Then
                dgrid.Visible = True
                dgrid.DataSource = dtblAnnualAccounts
                set_culture("dtblAnnualAccounts")
                dgrid.DataBind()
                mbHasAnnualAccountsData = True

                'Check wether it has any Due Financial Years
                Dim dvDueStatus As DataView
                dvDueStatus = dtblAnnualAccounts.DefaultView
                dvDueStatus.RowFilter = "Status='DUE' or Status='OVER DUE'"

                If dvDueStatus.Count > 0 Then
                    mbIsDue = True
                Else
                    mbIsDue = False
                End If
                lblThereIsNoRecord.Visible = False
            Else
                lblThereIsNoRecord.Visible = True
            End If

        End If
    End Sub

    Sub ShowNotification()
        'Dim oReader As Object
        'oReader = MessageBoard.GetNotification(CustomerID)
        'If oReader.read() Then
        '    pNotification.InnerHtml = oReader("Notification")
        'Else
        '    pNotification.InnerHtml = "No new Notifications"
        'End If

        'oReader = Nothing
    End Sub

    Sub ShowMessages()
        'Dim oReader As SqlClient.SqlDataReader
        'Try
        '    oReader = MessageBoard.GetMessageCount(CustomerID)
        '    If oReader.Read() Then
        '        pUnreadMsg.InnerText = oReader("unread")
        '        pTotalMsg.InnerText = oReader("total")
        '    Else
        '        pUnreadMsg.InnerText = "0"
        '        pTotalMsg.InnerText = "0"
        '    End If
        'Finally
        '    If Not oReader.IsClosed Then oReader.Close()
        '    If Not oReader Is Nothing Then oReader = Nothing
        'End Try

    End Sub

    Sub ShowServices(ByVal bOnlyIconMode As Boolean)
        'Dim cValues As Object, mUser As New User
        'Dim bAnyServiceEnabled As Boolean = False

        'litAvailableSrv.Visible = False
        'mDCA.Visible = False
        ''sDCA.Visible = False
        ''sExpress.Visible = False
        'mExpress.Visible = False
        'REM SR
        ''sAccountsProWeb.Visible = False
        'mAccountsProWeb.Visible = False
        'REM SR
        ''sPayroll.Visible = False
        'mPayroll.Visible = False
        ''sCTReturn.Visible = False
        'mCTReturn.Visible = False
        ''sSAccounts.Visible = False
        'mSAccounts.Visible = False
        ''AccountsPro.Visible = False
        ''sCams.Visible = False
        'mCams.Visible = False
        'mBPLN.Visible = False

        ''If IsServiceAllowed("AccountsPro") Then
        ''    AccountsPro.Visible = True
        ''End If
        'If IsServiceAllowed("Express") Then
        '    bAnyServiceEnabled = True
        '    'sExpress.Visible = True
        '    mExpress.Visible = True
        '    'Try
        '    '    cValues = mUser.ExpressAccountSummary(CustomerID)
        '    '    If cValues.read() Then
        '    '        sExpress1.InnerHtml = Format(Val("" & cValues("Trunover")), "0.00")
        '    '        sExpress2.InnerHtml = Format(Val("" & cValues("Profit")), "0.00")
        '    '        'sExpress2.InnerHtml = "" & cValues("Profit")
        '    '        sExpress3.InnerHtml = Format(Val("" & cValues("CashBank")), "0.00")
        '    '        sExpress4.InnerHtml = Format(Val("" & cValues("Receipt")), "0.00")
        '    '        sExpress5.InnerHtml = Format(Val("" & cValues("Payment")), "0.00")
        '    '    End If
        '    'Catch ee As Exception
        '    'End Try

        '    If IsExpiredSubscription("Express") Then
        '        imgBtnExpress.ImageUrl = "/images/LogoRenewExpress.gif"
        '        imgBtnExpress.CommandName = "Expired"
        '    Else
        '        imgBtnExpress.ImageUrl = "/images/logoExpress.jpg"
        '        imgBtnExpress.CommandName = "NotExpired"
        '    End If
        'End If

        'REM SR
        'If IsServiceAllowed("AccountsProWeb") Then
        '    bAnyServiceEnabled = True
        '    'sAccountsProWeb.Visible = True
        '    mAccountsProWeb.Visible = True

        '    If IsExpiredSubscription("AccountsProWeb") Then
        '        imgBtnAccProWeb.ImageUrl = "/images/LogoRenewAccountsProWeb.gif"
        '        imgBtnAccProWeb.CommandName = "Expired"
        '    Else
        '        imgBtnAccProWeb.ImageUrl = "/images/LogoAccountsproWeb.jpg"
        '        imgBtnAccProWeb.CommandName = "NotExpired"
        '    End If
        '    Try
        '        ''''cValues = mUser.ExpressAccountSummary(CustomerID)
        '        ''''If cValues.read() Then
        '        ''''    sExpress1.InnerHtml = Format(Val("" & cValues("Trunover")), "0.00")
        '        ''''    sExpress2.InnerHtml = Format(Val("" & cValues("Profit")), "0.00")
        '        ''''    'sExpress2.InnerHtml = "" & cValues("Profit")
        '        ''''    sExpress3.InnerHtml = Format(Val("" & cValues("CashBank")), "0.00")
        '        ''''    sExpress4.InnerHtml = Format(Val("" & cValues("Receipt")), "0.00")
        '        ''''    sExpress5.InnerHtml = Format(Val("" & cValues("Payment")), "0.00")
        '        ''''End If
        '    Catch ee As Exception
        '    End Try
        'End If
        'REM SR        
        'If IsServiceAllowed("Payroll") Then
        '    bAnyServiceEnabled = True
        '    'sPayroll.Visible = True
        '    mPayroll.Visible = True
        '    'Try
        '    '    cValues = mUser.EmployerSummary(CustomerID)
        '    '    If cValues.read() Then
        '    '        sPayroll1.InnerHtml = cValues("TotalEmployee")
        '    '        sPayroll2.InnerHtml = Format(Val("" & cValues("GrossPay")), "0.00")
        '    '        sPayroll3.InnerHtml = Format(Val("" & cValues("Deduction")), "0.00")
        '    '        sPayroll4.InnerHtml = Format(Val("" & cValues("NetPay")), "0.00")
        '    '        sPayroll5.InnerHtml = Format(Val("" & cValues("Allowances")), "0.00")
        '    '    End If
        '    'Catch ee As Exception
        '    'End Try
        '    If IsExpiredSubscription("Payroll") Then
        '        imgBtnPayroll.ImageUrl = "/images/LogoRenewPayroll.gif"
        '        imgBtnPayroll.CommandName = "Expired"
        '    Else
        '        imgBtnPayroll.ImageUrl = "/images/logo-payroll.jpg"
        '        imgBtnPayroll.CommandName = "NotExpired"
        '    End If
        'End If
        'If IsServiceAllowed("CTReturn") Then
        '    bAnyServiceEnabled = True
        '    'sCTReturn.Visible = True
        '    mCTReturn.Visible = True
        '    'Try
        '    '    cValues = mUser.GetCTRSummary(CustomerID)
        '    '    ' If cValues.read() Then
        '    '    CTReturn1.InnerHtml = Format(Val("" & cValues(1)), "0.00")
        '    '    CTReturn2.InnerHtml = Format(Val("" & cValues(2)), "0.00")
        '    '    CTReturn3.InnerHtml = Format(Val("" & cValues(3)), "0.00")
        '    '    CTReturn4.InnerHtml = Format(Val("" & cValues(4)), "0.00")
        '    '    'End If
        '    'Catch ee As Exception
        '    'End Try
        '    If IsExpiredSubscription("CTReturn") Then
        '        imgBtnCTReturn.ImageUrl = "/images/LogoRenewCTReturn.gif"
        '        imgBtnCTReturn.CommandName = "Expired"
        '    Else
        '        imgBtnCTReturn.ImageUrl = "/images/logoCTReturn.jpg"
        '        imgBtnCTReturn.CommandName = "NotExpired"
        '    End If
        'End If
        'If IsServiceAllowed("SAccounts") OrElse IsServiceAllowed("CTReturn") Then
        '    bAnyServiceEnabled = True
        '    'sSAccounts.Visible = True
        '    mSAccounts.Visible = True
        '    'Try
        '    '    'Dim cc As Collection
        '    '    'cc = mUser.GetSTASummary(CustomerID)
        '    '    cValues = mUser.GetSTASummary(CustomerID)

        '    '    ' If cValues.read() Then
        '    '    sSAccounts1.InnerHtml = Format(Val("" & cValues(1)), "0.00")
        '    '    sSAccounts2.InnerHtml = Format(Val("" & cValues(2)), "0.00")
        '    '    sSAccounts3.InnerHtml = Format(Val("" & cValues(3)), "0.00")
        '    '    'sSAccounts3.InnerHtml = cc.Item(3) & "," & CustomerID.ToString
        '    '    sSAccounts4.InnerHtml = Format(Val("" & cValues(4)), "0.00")
        '    '    sSAccounts5.InnerHtml = Format(Val("" & cValues(5)), "0.00")
        '    '    'End If
        '    'Catch ee As Exception
        '    'End Try
        '    If IsExpiredSubscription("SAccounts") Then
        '        imgBtnSAccounts.ImageUrl = "/images/LogoRenewAnnual.gif"
        '        imgBtnSAccounts.CommandName = "Expired"
        '    Else
        '        imgBtnSAccounts.ImageUrl = "/images/LogoAnnual.jpg"
        '        imgBtnSAccounts.CommandName = "NotExpired"
        '    End If
        'End If

        'If IsServiceAllowed("AccountManagement") Then
        '    bAnyServiceEnabled = True
        '    'sCams.Visible = True
        '    mCams.Visible = True
        '    'cValues = mUser.GetCAMSummary(CustomerID)
        '    ''Try
        '    'Cams1.InnerHtml = Format(Val("" & cValues(1)), "0.00")
        '    'Cams2.InnerHtml = Format(Val("" & cValues(2)), "0.00")
        '    'Cams3.InnerHtml = Format(Val("" & cValues(3)), "0.00")
        '    If IsExpiredSubscription("AccountManagement") Then
        '        imgBtnCams.ImageUrl = "/images/LogoRenewCams.gif"
        '        imgBtnCams.CommandName = "Expired"
        '    Else
        '        imgBtnCams.ImageUrl = "/images/logoCam.jpg"
        '        imgBtnCams.CommandName = "NotExpired"
        '    End If
        'End If

        'If IsServiceAllowed("DCAccounts") Then
        '    bAnyServiceEnabled = True
        '    mDCA.Visible = True
        '    'sDCA.Visible = True
        '    If IsExpiredSubscription("DCAccounts") Then
        '        imgBtnDCA.ImageUrl = "/images/LogoRenewDCA.gif"
        '        imgBtnDCA.CommandName = "Expired"
        '    Else
        '        imgBtnDCA.ImageUrl = "/images/Logo-DCA.jpg"
        '        imgBtnDCA.CommandName = "NotExpired"
        '    End If
        'End If


        'If IsServiceAllowed("InfiniBizPlan") Then
        '    bAnyServiceEnabled = True
        '    mBPLN.Visible = True

        '    If IsExpiredSubscription("InfiniBizPlan") Then
        '        imgBtnBizPlan.ImageUrl = "/images/LogoRenewBizPlan.gif"
        '        imgBtnBizPlan.CommandName = "Expired"
        '    Else
        '        imgBtnBizPlan.ImageUrl = "/images/LogoBizPlan.jpg"
        '        imgBtnBizPlan.CommandName = "NotExpired"
        '    End If
        'End If

        'mUser = Nothing
        'litAvailableSrv.Visible = bAnyServiceEnabled
    End Sub

    Sub ShowGateway()
        Dim strHtml As String = "", PayeId As Object, CtrID As Object
        strHtml = "<table class=content border=0 cellspacing=0 cellpadding=0 width='100%'>"

        If CustomerProfile.IsGatewayReady(CustomerID, "CTReturn", PayeId, CtrID) Then
            strHtml = strHtml & "<tr><td width='80%'>Corporation Tax Online</td><td width='20%' align=right><IMG src='/images/checked.gif' ></td></tr>"
            strHtml = strHtml & "<tr><td>User ID</td><td align=right >" & CtrID & "</td></tr>"
        Else
            strHtml = strHtml & "<tr><td width='80%'>Corporation Tax Online</td><td width='20%' align=right><IMG src='/images/uncheck.gif' ></td></tr>"
            strHtml = strHtml & "<tr><td>User ID</td><td align=right ></td></tr>"
        End If

        strHtml = strHtml & "<tr><td height=15px></td><td ></td></tr>"

        If CustomerProfile.IsGatewayReady(CustomerID, "Payroll", PayeId, CtrID) Then
            strHtml = strHtml & "<tr><td>PAYE and NIC(Payroll)</td><td  align=right><IMG src='/images/checked.gif' ></td></tr>"
            strHtml = strHtml & "<tr><td>User ID</td><td align=right >" & PayeId & "</td></tr>"
        Else
            strHtml = strHtml & "<tr><td>PAYE and NIC(Payroll)</td><td  align=right><IMG src='/images/uncheck.gif' ></td></tr>"
            strHtml = strHtml & "<tr><td>User ID</td><td align=right ></td></tr>"
        End If
        strHtml = strHtml & "</table>"
        pGateway.InnerHtml = strHtml

    End Sub

    Sub ShowProfile()
        Dim t As Object, oReader As SqlClient.SqlDataReader
        Try
            oReader = CustomerProfile.GetProfile(CustomerID)
            compName.InnerHtml = "<b>" & IIf(IsDBNull(oReader("CompName")), "", oReader("CompName")) & "</b>"
            pRegNo.InnerText = IIf(IsDBNull(oReader("CompRegNo")), "", oReader("CompRegNo"))
            pAddress.InnerText = IIf(IsDBNull(oReader("CompAddress")), "", oReader("CompAddress"))
            pTel.InnerText = IIf(IsDBNull(oReader("CompPhone")), "", oReader("CompPhone"))
            pFax.InnerText = IIf(IsDBNull(oReader("CompFax")), "", oReader("CompFax"))
            Pemail.InnerText = IIf(IsDBNull(oReader("CompEmail")), "", oReader("CompEmail"))
            PCPerson.InnerText = IIf(IsDBNull(oReader("CompPerson")), "", oReader("CompPerson"))
            pDirectors.InnerHtml = Replace(IIf(IsDBNull(oReader("CompDirector")), "", oReader("CompDirector")), vbCrLf, "<BR>")
            pSeceratory.InnerHtml = Replace(IIf(IsDBNull(oReader("CompSec")), "", oReader("CompSec")), vbCrLf, "<BR>")
            pWebsite.InnerHtml = "<a style='cursor:hand' onclick=" & Chr(34) & "OpennewWindow('" & oReader("compwebsite") & "','Member_Home_Page');" & Chr(34) & ">" & oReader("compwebsite") & "</a>"
        Finally
            If Not oReader.IsClosed AndAlso Not oReader Is Nothing Then
                oReader.Close()
                oReader = Nothing
            End If
        End Try
        oReader = Nothing
    End Sub

    Private Function IsValidARD(ByVal sARD As String) As Boolean
        If Trim(sARD) = "" Then GoTo fls 'No Blank
        Dim strARD() As String = Split(sARD, "/")
        If strARD.Length <> 2 Then GoTo fls 'must have two parts sep. with /
        If IsNumeric(strARD(0)) = False Then GoTo fls ' first part must be numeric
        If IsNumeric(strARD(1)) = False Then GoTo fls ' second part must also be numeric
        If Not (strARD(0) >= 1 AndAlso strARD(0) <= 31) Then GoTo fls ' 1st part is day so should not exceed 31
        If Not (strARD(1) >= 1 AndAlso strARD(1) <= 12) Then GoTo fls ' 2nd part is mon so should not exceed 12
tru:
        Return True
fls:
        Return False
    End Function

    Private Sub LoadExpiredList()
        ' Session("Subscription_ExpiredList") = CType(Session("Subscription_ExpiredList"), Hashtable)
        Dim ObjSubscriptionStatus As New SubscriptionStatus
        Dim DtCustomerSubscription As DataTable

        With ObjSubscriptionStatus
            'Get Customer's Subscription

            'Last 3 Months Section
            DtCustomerSubscription = .getCustomerServiceStatusByID(.CustSrvStatusBehavior.Last3MonthsPeriod, CustomerID)
            For Each dr As DataRow In DtCustomerSubscription.Rows
                With dr
                    htExpiredSubscription.Add(.Item("Service"), "Last3Months")
                End With
            Next

            'Expired            
            DtCustomerSubscription = .getCustomerServiceStatusByID(.CustSrvStatusBehavior.OverDueDate, CustomerID)

            For Each dr As DataRow In DtCustomerSubscription.Rows
                With dr
                    htExpiredSubscription.Add(.Item("Service"), "OverDueDate")
                End With
            Next
        End With
    End Sub

    Private Function IsExpiredSubscription(ByVal strService As String) As Boolean
        If htExpiredSubscription Is Nothing Then
            Return False
        Else
            Return htExpiredSubscription.Contains(strService)
        End If
    End Function

    Private Sub LoadFiledDocuments()
        Dim objCD As New CustomerDocuments
        Dim dTable As New DataTable
        Dim isAnyAccounts As Boolean = False

        With objCD
            '----------------------------------------------
            'Annual Accounts
            dTable = .GetAccCustomerFile(CustomerID:=CustomerID, ServiceID:=ServiceType.AnnualAccounts)
            If (Not dTable Is Nothing) AndAlso (dTable.Rows.Count > 0) Then
                pnlAnnualACFiled.Visible = True
                With dgrdAnnualACFiled
                    .DataSource = dTable
                    set_culture("dgrdAnnualACFiled")
                    .DataBind()
                End With

                isAnyAccounts = True
            End If
            '----------------------------------------------

            '----------------------------------------------
            'CT Retun
            dTable = .GetAccCustomerFile(CustomerID:=CustomerID, ServiceID:=ServiceType.CTReturn)
            If (Not dTable Is Nothing) AndAlso (dTable.Rows.Count > 0) Then
                pnlCTReturnFiled.Visible = True
                With dgrdCTReturnFiled
                    .DataSource = dTable
                    set_culture("dgrdCTReturnFiled")
                    .DataBind()
                End With

                isAnyAccounts = True
            End If
            '----------------------------------------------

            '----------------------------------------------
            'Dormant Accounts (DC)
            dTable = .GetAccCustomerFile(CustomerID:=CustomerID, ServiceID:=ServiceType.DCAccounts)
            If (Not dTable Is Nothing) AndAlso (dTable.Rows.Count > 0) Then
                pnlDCAccountsFiled.Visible = True
                With dgrdDCAccountsFiled
                    .DataSource = dTable
                    set_culture("dgrdDCAccountsFiled")
                    .DataBind()
                End With

                isAnyAccounts = True
            End If
            '----------------------------------------------
        End With

        '------------------------------------
        pnlDocArchive.Visible = isAnyAccounts
        '------------------------------------
    End Sub
    Private Sub set_culture(ByVal grid_name As String)
        load_culture(idxtopbar.CultureName)
        Select Case grid_name
            Case "dtblAnnualAccounts"
                'Me.dtblAnnualAccounts.Columns(1).HeaderText = load_culturevalue("acc_ghpackagename")
                'Me.dtblAnnualAccountsColumns(2).HeaderText = load_culturevalue("acc_ghdescription")
                'Me.dtblAnnualAccounts.Columns(3).HeaderText = load_culturevalue("acc_ghcostyear")

            Case "dgrdAnnualACFiled"
                Me.dgrdAnnualACFiled.Columns(0).HeaderText = load_culturevalue("acc_members_default_ghfinancialyear")
                Me.dgrdAnnualACFiled.Columns(1).HeaderText = load_culturevalue("acc_members_default_ghdocument")
                'lbldownload = load_culturevalue("acc_members_default_ghdownload")

            Case "dgrdCTReturnFiled"
                Me.dgrdCTReturnFiled.Columns(0).HeaderText = load_culturevalue("acc_members_default_ghfinancialyear")
                Me.dgrdCTReturnFiled.Columns(1).HeaderText = load_culturevalue("acc_members_default_ghdocument")

            Case "dgrdDCAccountsFiled"
                Me.dgrdDCAccountsFiled.Columns(0).HeaderText = load_culturevalue("acc_members_default_ghfinancialyear")
                Me.dgrdDCAccountsFiled.Columns(1).HeaderText = load_culturevalue("acc_members_default_ghdocument")

        End Select
    End Sub
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="RecordID"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[win.abid]	05/01/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub DownloadDocuments(ByVal RecordID As Integer)
        '---------------------------------
        Dim strContentType As String = ""
        Dim strFileName As String = "CustomDoc" & Date.Today.Month & Date.Today.Day & Date.Today.Year
        Dim objCD As New CustomerDocuments
        Dim dTable As New DataTable
        Dim intDocType As Integer
        Dim FileData() As Byte
        '---------------------------------

        '------------------------------------------------------
        dTable = objCD.GetAccCustomerFile(RecordID)
        If dTable Is Nothing Then Exit Sub ' don't load there is an exception
        '------------------------------------------------------

        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        With dTable
            If .Rows.Count > 0 Then
                With .Rows(0)
                    '------------------------------------------
                    intDocType = .Item("DocType")
                    FileData = CType(.Item("FileData"), Byte())
                    '------------------------------------------
                End With
            End If
        End With

        dTable = Nothing
        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        '--------------------------------------------------------
        Select Case intDocType
            Case DocType.MSWord
                '------------------------------------
                strContentType = "application/msword"
                strFileName &= ".doc"
                Exit Select
                '------------------------------------
            Case DocType.MSExcel
                '------------------------------------
                strContentType = "application/vnd.ms-excel"
                strFileName &= ".xls"
                Exit Select
                '------------------------------------
            Case DocType.PDF
                '------------------------------------
                strContentType = "application/pdf"
                strFileName &= ".pdf"
                Exit Select
                '------------------------------------
        End Select
        '--------------------------------------------------------


        '---------------------------------------------------------------
        With Response
            '-----------------------------------------------------
            .Clear()
            .ClearHeaders()
            .ClearContent()
            .ContentType = strContentType
            .AddHeader("content-disposition", "inline: filename=" & strFileName)
            .BinaryWrite(FileData)
            .End()
            '------------------------------------------------------
        End With
        '---------------------------------------------------------------
    End Sub

#End Region

    Private Sub IShops_btn_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles IShops_btn.Click
        GoInfiniCRM()
    End Sub
    Public Sub GoInfiniCRM()

        'Dim dtb As New DataTable
        Dim loginInfo() As String

        Dim CRMS As New com.infinioffice.crm.services.CRMservices
        Dim LoginResponse As New com.infinioffice.crm.services.LoginResponse
        Dim UID As String
        Dim UserPassword As String

        loginInfo = GetAutoLoginInfo(CustomerID)

        If (loginInfo(0) <> Nothing) Then
            UID = loginInfo(0)
            UserPassword = loginInfo(1)

            Try
                LoginResponse = CRMS.LoginMerchant(CustomerID, UID, UserPassword, CustomerID)
            Catch ex As Exception
                Response.Redirect("/Members/Default.aspx")
                'Response.Redirect("/InfiniHr/Default.aspx?Error_Code=-1")
                'Throw New Exception(ex.Message)
            End Try

            If (LoginResponse.errorCode = "0") Then
                'If (Me.ISURLVaild(LoginResponse.url) = True) Then
                Response.Redirect(LoginResponse.url)
                'End If
            Else
                Response.Redirect("/InfiniHr/Default.aspx?Error_Code=-2")
            End If

        End If

        'If (dtb.Rows.Count <> 0) Then
        '    UID = dtb.Rows(0)("uid")
        '    UserPassword = dtb.Rows(0)("Pass")

        '    Try
        '        LoginResponse = CRMS.LoginMerchant(CustomerID, UID, UserPassword, CustomerID)
        '    Catch ex As Exception
        '        Response.Redirect("/Members/Default.aspx")
        '        'Response.Redirect("/InfiniHr/Default.aspx?Error_Code=-1")
        '        'Throw New Exception(ex.Message)
        '    End Try

        '    If (LoginResponse.errorCode = "0") Then
        '        If (Me.ISURLVaild(LoginResponse.url) = True) Then
        '            Response.Redirect(LoginResponse.url)
        '        End If
        '    Else
        '        Response.Redirect("/InfiniHr/Default.aspx?Error_Code=-2")
        '    End If

        'End If
    End Sub

    'Modified By:   M.Yousuf
    'Date:          June 29, 2007
    'Desc:
    'IOffice url is passed in this method. and server to server
    'communication is not possible due to security issue
    'so no need to validate a url of website. incase of validation
    'use webservice
    'Public Function ISURLVaild(ByVal url As String) As Boolean
    '    HttpContext.Current.Trace.Warn("In ISURLVaild")
    '    HttpContext.Current.Trace.Warn("    url=" & url)
    '    Dim req As HttpWebRequest
    '    Dim res As HttpWebResponse = Nothing

    '    Dim r As System.IO.StreamReader = Nothing
    '    Dim ex As Exception     'error exeption holder 
    '    Dim pge As String       'page holder 
    '    Dim status As Boolean = False

    '    Try
    '        ' request url 
    '        req = req.Create(url)

    '        'get page 
    '        res = req.GetResponse()
    '        r = New System.IO.StreamReader(res.GetResponseStream())
    '        pge = r.ReadToEnd

    '        If (pge <> Nothing) Then
    '            status = True
    '        End If
    '    Catch ex
    '        status = False
    '    Finally
    '        pge = Nothing
    '        If Not r Is Nothing Then
    '            HttpContext.Current.Trace.Warn("r Is Not Nothing")
    '            r.Close()
    '        Else
    '            HttpContext.Current.Trace.Warn("r Is Nothing")
    '        End If

    '        If Not res Is Nothing Then
    '            HttpContext.Current.Trace.Warn("res Is Not Nothing")
    '            res.Close()
    '        Else
    '            HttpContext.Current.Trace.Warn("res Is Nothing")
    '        End If
    '    End Try

    '    HttpContext.Current.Trace.Warn("ISURLVaild is ok: status=" & status)
    '    Return status
    'End Function
    Public Shared Function GetAutoLoginInfo(ByRef customerId As Integer) As String()

        Dim loginInfo() As String = New String(1) {}
        Dim objUser As New InfiniLogic.AccountsCentre.BLL.User
        Dim objCryptography As New InfiniLogic.AccountsCentre.common.Cryptography
        'Dim strLogKey, intReturnValue, _strDatabaseName As String
        'Dim Status As Boolean

        Dim logKey As String = objUser.AccGetLogKey(customerId)

        Dim ds As DataSet = objUser.GetCustomerData(customerId)
        Dim password = ds.Tables(0).Rows(0).Item(19)
        Dim deCryptPassword As String = objCryptography.DeCrypt(password, logKey)
        loginInfo(0) = ds.Tables(0).Rows(0).Item(12)
        loginInfo(1) = deCryptPassword
        Return loginInfo

    End Function

    Public Function IsServiceAvailable(ByRef customerId As Integer, ByRef ServiceID As Integer) As Boolean
        Dim cmd As New CommandData(0)
        Dim flag As Integer
        Try
            cmd.AddParameter("@CustomerID", customerId)
            cmd.AddParameter("@ServiceID", ServiceID)
            cmd.CmdText = "dbserver.infinishopmaindb.dbo.ADMIN_CheckServiceForCustomer"
            flag = cmd.Execute(ExecutionType.ExecuteScalar)
            Return flag
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        Finally
            cmd.CloseConnection()
            cmd = Nothing
        End Try



    End Function


End Class

Enum ServiceType
    CTReturn = 3
    AnnualAccounts = 7
    DCAccounts = 9
End Enum

Enum DocType
    MSWord = 0
    MSExcel = 1
    PDF = 2
End Enum
