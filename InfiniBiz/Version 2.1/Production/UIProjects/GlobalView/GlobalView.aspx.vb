#Region "    Imports"
Imports InfiniLogic.AccountsCentre.Common
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Security
Imports System.Data.SqlClient
#End Region

Public Class GlobalViewUI
    Inherits PageTemplate
#Region "Declarations n Constructor"
    Private objGlobalView As GlobalView
    Protected WithEvents dgridSummaryInformation As System.Web.UI.WebControls.DataGrid
    Protected WithEvents txtSearch As System.Web.UI.WebControls.TextBox
    Protected WithEvents ServicesList1 As Web.ServicesList

    'AC_CR_00005
    'Protected WithEvents litCompCount As System.Web.UI.WebControls.Literal
    'Protected WithEvents litRegCompCount As System.Web.UI.WebControls.Literal
    'Protected WithEvents litExcCompCount As System.Web.UI.WebControls.Literal
    'Protected WithEvents litUnRegCompCount As System.Web.UI.WebControls.Literal

    'Protected WithEvents lnkbtnTotalCompanies As System.Web.UI.WebControls.LinkButton
    'Protected WithEvents lnkbtnRegCompanies As System.Web.UI.WebControls.LinkButton
    'Protected WithEvents lnkbtnExcludedCompanies As System.Web.UI.WebControls.LinkButton
    'Protected WithEvents lnkbtnUnregCompanies As System.Web.UI.WebControls.LinkButton

    'Protected WithEvents btnAddParentUser As System.Web.UI.WebControls.Button
    'Protected WithEvents btnExclude As System.Web.UI.WebControls.Button
    'Protected WithEvents btnDoNotExclude As System.Web.UI.WebControls.Button

    'Protected WithEvents litSelectionMode As System.Web.UI.WebControls.Label

    'Protected WithEvents btnSortByName As HtmlInputButton
    'Protected WithEvents btnSortByIncorporation As HtmlInputButton
    'Protected WithEvents btnSortByARD As HtmlInputButton
    'Protected WithEvents dgridGlobalView As System.Web.UI.WebControls.DataGrid
    'Protected WithEvents litIncDate As System.Web.UI.WebControls.Literal
    'Protected WithEvents litARD As System.Web.UI.WebControls.Literal
    'Protected WithEvents drpCompanyList As System.Web.UI.WebControls.ListBox
    'Protected WithEvents litSelComp As System.Web.UI.WebControls.Literal
    'AC_CR_00005

    Protected WithEvents btnAddaCompany As System.Web.UI.WebControls.LinkButton
    Protected WithEvents litSearchComp As System.Web.UI.WebControls.Literal
    Protected WithEvents litFHMessage As System.Web.UI.WebControls.Literal

    Protected WithEvents hCriteria As HtmlInputHidden
    Protected WithEvents hSort As HtmlInputHidden

    Protected WithEvents frmGlobalView As System.Web.UI.HtmlControls.HtmlForm    

    Private dtCompanies As DataTable
    Public dvCompanies As DataView

    Private mbIsDue As Boolean
    Private mbHasAnnualAccountsData As Boolean

    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnGo As System.Web.UI.WebControls.ImageButton
    Protected WithEvents lblglobalview As System.Web.UI.WebControls.Label

    Private mbOnlySummary As Boolean
    Protected WithEvents Td2 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected idxtopbar As IndexHeader

    Public Sub New()
        objGlobalView = New GlobalView
    End Sub
#End Region

#Region "Event Handlres"
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Trace.Warn("In GlobalView Load")
        Session("ACC_Application_Path") = True


        'If User.Identity.IsAuthenticated Then
        '    DebugWrite("----Wel come in Globalview---------------")
        '   If Not IsPostBack Then
        PrepareMe()
        '   End If
        'Else
        '    Response.Redirect("http://www.infinibiz.com/account/index.php")
        'End If
        Me.dgridSummaryInformation.Attributes.Add("htmlName", "dgridsummaryinformation")
        Trace.Warn("GlobalView Load End")
    End Sub
    Private Sub dgridSummaryInformation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgridSummaryInformation.SelectedIndexChanged
        lnkCompany_Click(sender, e)
    End Sub

    'AC_CR_00005
    'Private Sub drpCompanyList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles drpCompanyList.SelectedIndexChanged
    '    'SearchData(drpCompanyList.SelectedItem.Text)
    '    SearchData(drpCompanyList.SelectedItem.Value)
    'End Sub
    'Private Sub dgridGlobalView_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgridGlobalView.PageIndexChanged
    '    SetGridSource(e.NewPageIndex)
    '    drpCompanyList.ClearSelection()
    '    'xdrpCompanyList.SelectedValue = UCase(dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("CompName"))
    '    drpCompanyList.SelectedValue = dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("ID")
    '    PreparePanels()
    'End Sub
    'Private Sub lnkbtnRegCompanies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnRegCompanies.Click
    '    SetCriteria(1)
    '    PrepareMe(True, "GVStatus=1 or GVStatus=4")
    'End Sub
    'Private Sub lnkbtnExcludedCompanies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnExcludedCompanies.Click
    '    SetCriteria(2)
    '    PrepareMe(True, "GVStatus=2")
    'End Sub
    'Private Sub lnkbtnTotalCompanies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnTotalCompanies.Click
    '    SetCriteria(3)
    '    PrepareMe(True)
    'End Sub
    'Private Sub lnkbtnUnregCompanies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkbtnUnregCompanies.Click
    '    SetCriteria(0)
    '    PrepareMe(True, "GVStatus=0")
    'End Sub
    'Private Sub btnExclude_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExclude.Click
    '    ExcludeCompany()
    'End Sub
    'Private Sub btnDoNotExclude_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDoNotExclude.Click
    '    DoNotExcludeCompany()
    'End Sub
    'Private Sub btnSortByARD_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSortByARD.ServerClick
    '    hSort.Value = "eFilingDate"
    '    PrepareMe(True)
    'End Sub
    'Private Sub btnSortByName_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSortByName.ServerClick
    '    hSort.Value = "CompName"
    '    PrepareMe(True)
    'End Sub
    'Private Sub btnSortByIncorporation_ServerClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSortByIncorporation.ServerClick
    '    hSort.Value = "IncDate"
    '    PrepareMe(True)
    'End Sub
    'AC_CR_00005

    Public Sub btnSearch_Click()
        'SearchData(txtSearch.Text, True)
        'txtSearch.Text = ""
    End Sub
    Private Sub btnAddaCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddaCompany.Click  'AC_CR_00005 , btnAddParentUser.Click
        ProcessAddCompany("Add a Company")
    End Sub
    Public Sub lnkCompany_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
        lnkCompany_Click(sender, New EventArgs)
    End Sub
    'AC_CR_00005
    'Public Sub lnkCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim iptRegID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegID"), HtmlInputHidden)
    '    Dim iptRegUserID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegUserID"), HtmlInputHidden)
    '    Dim iptGVCompName As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVCompName"), HtmlInputHidden)
    '    Dim iptGVCompNumber As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVCompNumber"), HtmlInputHidden)

    '    Dim sRedirectURL As String
    '    Dim sCompanyName As String

    '    If sender.id = "btnCTReturn" Then
    '        sRedirectURL = "/CTReturn/Forms"
    '    ElseIf sender.id = "btnSubscribe" Then
    '        sRedirectURL = "/Members/UpdateServices.aspx"
    '    Else
    '        sRedirectURL = ""
    '    End If

    '    ProcessCompany(Trim(iptRegID.Value), Trim(iptRegUserID.Value), sRedirectURL, Trim(iptGVCompName.Value), Trim(iptGVCompNumber.Value))
    'End Sub
    Public Sub lnkCompany_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim sRegID, sRegUserID, sGVCompName, sGVCompNumber As String

        With dgridSummaryInformation
            sRegID = .SelectedItem.Cells(11).Text '  CType(.Items(0).FindControl("RegID"), HtmlInputHidden)
            sRegUserID = .SelectedItem.Cells(7).Text ' CType(.Items(0).FindControl("RegUserID"), HtmlInputHidden)
            sGVCompName = .SelectedItem.Cells(12).Text
            'CType(.Items(0).FindControl("GVCompName"), HtmlInputHidden)
            sGVCompNumber = .SelectedItem.Cells(10).Text 'CType(.Items(0).FindControl("GVCompNumber"), HtmlInputHidden)
        End With
        Dim sRedirectURL As String
        Dim sCompanyName As String

        If sender.id = "btnCTReturn" Then
            sRedirectURL = "/CTReturn/Forms"
        ElseIf sender.id = "btnSubscribe" Then
            sRedirectURL = "/Members/UpdateServices.aspx"
        Else
            sRedirectURL = ""
        End If

        ProcessCompany(sRegID, sRegUserID, sRedirectURL, sGVCompName, sGVCompNumber)
    End Sub
    'AC_CR_00005
    Public Sub CancelUploadFile(ByVal s As Object, ByVal e As EventArgs)
        PreparePanels()
    End Sub
    Public Sub SaveUploadedFile(ByVal s As Object, ByVal e As EventArgs)
        If Request.Files.Count > 0 Then
            Dim fPosted As System.Web.HttpPostedFile, strFileName As String(), strFolderPath As String
            fPosted = Request.Files(0)
            strFileName = fPosted.FileName.Split("\")
            If strFileName(UBound(strFileName)) = "" Then
                ErrorMessage = "You must select the file to upload"
            ElseIf fPosted.ContentLength = 0 Then
                ErrorMessage = "File with no data can not be saved."
            Else
                strFolderPath = Request.MapPath(".") & "\AnnualAccountsExcelSheets\"
                If System.IO.Directory.Exists(strFolderPath) = False Then
                    System.IO.Directory.CreateDirectory(strFolderPath)
                End If
                fPosted.SaveAs(strFolderPath & Session("UserUID") & "_" & Format(Today, "dd_MM_yyyy_") & strFileName(UBound(strFileName)))
                fPosted = Nothing
                InfoMessage = "File uploaded successfully."
                PreparePanels()
            End If
        End If
    End Sub
    Public Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        SetPanelsVisibilty(False, False, True)
    End Sub
    Public Sub dgridAnnualAccounts_ItemDataBound(ByVal s As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                Dim lblStatus As Label = CType(e.Item.FindControl("lblStatus"), Label)
                If lblStatus.Text = load_culturevalue("er_acc_globalview_globalview_statusdue") Then
                    lblStatus.ForeColor = Color.DarkOrange
                ElseIf lblStatus.Text = load_culturevalue("er_acc_globalview_globalview_statusoverdue") Then
                    lblStatus.ForeColor = Color.Red
                End If
        End Select
    End Sub
    Private Sub dgridSummaryInformation_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgridSummaryInformation.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                If e.Item.Cells(4).Text = load_culturevalue("er_acc_globalview_globalview_statusdue") Then
                    e.Item.Cells(4).ForeColor = Color.DarkOrange
                    e.Item.Attributes.Add("onmouseover", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'1')")
                    e.Item.Attributes.Add("onmouseout", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'0')")
                ElseIf e.Item.Cells(4).Text = load_culturevalue("er_acc_globalview_globalview_statusoverdue") Then
                    e.Item.Cells(4).ForeColor = Color.Red
                    e.Item.Attributes.Add("onmouseover", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'1')")
                    e.Item.Attributes.Add("onmouseout", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'0')")
                End If

                If IsDBNull(e.Item.DataItem("DissolvedDate")) = False AndAlso IsDate(e.Item.DataItem("DissolvedDate")) Then
                    e.Item.Cells(5).Text = load_culturevalue("er_acc_globalview_globalview_dissolved")
                    e.Item.Cells(5).ForeColor = Color.Red
                    e.Item.Attributes.Add("onmouseover", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'1')")
                    e.Item.Attributes.Add("onmouseout", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'0')")
                ElseIf IsDBNull(e.Item.DataItem("Dormant")) = False AndAlso e.Item.DataItem("Dormant") = 1 Then
                    e.Item.Cells(5).Text = load_culturevalue("er_acc_globalview_globalview_dormant")
                    e.Item.Cells(5).ForeColor = Color.DarkOrange
                    e.Item.Attributes.Add("onmouseover", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'1')")
                    e.Item.Attributes.Add("onmouseout", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'0')")
                Else
                    e.Item.Cells(5).Text = load_culturevalue("er_acc_globalview_globalview_active")
                    e.Item.Cells(5).ForeColor = Color.Green
                    e.Item.Attributes.Add("onmouseover", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'1')")
                    e.Item.Attributes.Add("onmouseout", "javaScript:changeSelectedRowColor(" & e.Item.ItemIndex & ",'0')")

                End If

                If IsNumeric(e.Item.Cells(11).Text) = False Then
                    CType(e.Item.Cells(6).Controls(0), LinkButton).Text = load_culturevalue("er_acc_globalview_globalview_register")
                End If

                'Modified By:   M.Yousuf
                'Date:          Feb 06, 2007
                'Check the Reseller Enabled Compnay and include
                '-----------------Show all API Reseller based company's ResellerID----------Start
                If IsNumeric(e.Item.Cells(7).Text) = True Then
                    Dim CompanyUID As String = e.Item.Cells(7).Text
                    Dim objUser As New InfiniLogic.AccountsCentre.BLL.User
                    Dim CompanyID As String = objUser.GetCustomerID(CompanyUID)

                    Dim ds As DataSet = objUser.IsReseller(CompanyID)

                    If (Not (ds Is Nothing)) AndAlso ds.Tables.Count <> 0 AndAlso ds.Tables(0).Rows.Count <> 0 Then
                        Dim IsEnabled As Boolean = ds.Tables(0).Rows(0).Item("Enable")
                        Dim IsAPIReseller As Boolean = objUser.IsAPIReseller(CompanyID)
                        If IsEnabled AndAlso IsAPIReseller Then
                            CType(e.Item.FindControl("lblResellerUID"), Label).Text = CompanyUID
                        End If
                    End If
                End If
                '-----------------Show all API Reseller based company's ResellerID----------End
        End Select

    End Sub
#End Region

#Region "Public Properties"
    Public ReadOnly Property GVStatus() As String
        Get
            If mbOnlySummary Then
                GVStatus = 0
            Else
                If dvCompanies.Count > 0 Then
                    'AC_CR_00005
                    'GVStatus = dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item(17)
                    'AC_CR_00005
                Else
                    GVStatus = 2
                End If
            End If
        End Get
    End Property
#End Region

#Region "Helper Routines"
    Private Sub PrepareMe(Optional ByVal bRefreshCombo As Boolean = False, Optional ByVal sGVStatusFilter As String = "NA")
        mbOnlySummary = False
        '/.................................................................................        
        Session("ACC_GV_ProcessCompany") = Nothing
        Session("ACC_GV_CompanyNumber") = Nothing

        'Session vars are being expired after some time but do not redirect to Sign in page
        'and it keeps itself signed in so in this case its redirected to sign out page.

        If Session("ACC_GV_ParentCustomerID") = Nothing Then SignInTheParent()

        Trace.Write("Appending the Dataview with Companies Info")

        Trace.Write("Parent Customer ID" & Session("ACC_GV_ParentCustomerID") & ".")

        dtCompanies = objGlobalView.getAllCompaniesByFH(Session("ACC_GV_ParentCustomerID"), Session("ACC_GV_Companies"), True)
        dvCompanies = dtCompanies.DefaultView

        Trace.Warn("dvCompanies = dtCompanies.DefaultView")

        Trace.Write("start sorting the filering values")

        If sGVStatusFilter = "NA" Then : dvCompanies.RowFilter = GetFilterString()
        Else : dvCompanies.RowFilter = sGVStatusFilter : End If

        Trace.Write("start sorting the grid values")


        If hSort.Value = "" Then : dvCompanies.Sort = "CompName"
        Else : dvCompanies.Sort = hSort.Value : End If
        '................................................................................./

        Trace.Write("Pass the sorting func and entering into Postback condition")


        If Not IsPostBack Or bRefreshCombo Then

            GetGlobalViewCompaniesAndInfo(Session("ACC_GV_ParentCustomerID"))

            Trace.Write("ByPass GlobalViewCompandInfo Func")

            '''AC_CR_00005
            '''litCompCount.Text = CStr(dtCompanies.Rows.Count)
            '''litRegCompCount.Text = CStr(Session("ACC_GV_RegCompCount"))
            '''litExcCompCount.Text = CStr(Session("ACC_GV_ExcCompCount"))
            '''litUnRegCompCount.Text = dtCompanies.Rows.Count - Session("ACC_GV_ExcCompCount") - Session("ACC_GV_RegCompCount")

            litFHMessage.Visible = Not Session("ACC_GV_FormationsHouseAvailable")

            Trace.Write("Pass Formationshouse webservice status message")

            If dvCompanies.Count > 0 Then

                Trace.Write("Entering into Companies greater than 0 condtion")


                mbOnlySummary = True
                btnAddaCompany.Text = "Click here to add another company registered at Accounts Centre."

                Dim sCompanyName As String
                If IsDBNull(Session("ACC_GV_LastAddedCompName")) = False Then
                    sCompanyName = CStr(Session("ACC_GV_LastAddedCompName"))
                Else
                    sCompanyName = ""
                End If

                Trace.Write("Passing first 1st inner conditon")

                Session("ACC_GV_LastAddedCompName") = Nothing
                If sCompanyName <> "" Then
                    SearchData(sCompanyName)
                    InfoMessage = "Company added into <B>Global View</B> successfully"
                End If

                Trace.Write("Passing first 2nd inner conditon")

                SetVisibility(True, True)

                Trace.Write("Passing SetVisibility fucntion")

                ProcessIfUserCanBeAddedToGlobalView()

                Trace.Write("Passing ProcessIfUserCanBeAddedToGlobalView fucntion")

                ShowSummaryInformation(True)

                Trace.Write("Passing ShowSummaryInformation fucntion")

            Else
                ''''AC_CR_00005
                ''''btnAddParentUser.Visible = False
                ''''If litCompCount.Text = "0" Then
                CreateGlobalView()
                System.Web.HttpContext.Current.Trace.Warn("Passing CreateGlobalView fucntion")


                ''''Else
                ''''    InfoMessage = "There is no company existed in this section."
                ''''    btnAddaCompany.Text = "Add a Company"
                ''''    SetVisibility(False, True)
                ''''End If
            End If
        End If
        Trace.Write("Exit from all functions")


    End Sub
    Private Sub ShowCompanyDetail(Optional ByVal bRefreshCombo As Boolean = False)
        RenderData(bRefreshCombo)
        PreparePanels()
        SetVisibility(True, False)
    End Sub
    Private Sub AddCompany()
        Response.Redirect("AddCompany.aspx")
    End Sub
    Private Sub DoNotExcludeCompany()
        'AC_CR_00005
        'Dim iptGVStatus As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVStatus"), HtmlInputHidden)
        'Dim sError As String = "There were some problems performing this operation. Retry later."

        'If iptGVStatus Is Nothing Then ErrorMessage = sError : Exit Sub

        'If iptGVStatus.Value <> 2 Then
        '    ErrorMessage = "Only <b>Separated Companies</b> can be Marked as <b>Only Global View Member</b>."
        '    Exit Sub
        'End If

        'Dim iptRegID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegID"), HtmlInputHidden)
        'Dim sParentID As String = Session("ACC_GV_ParentCustomerID")

        'If sParentID = Nothing Or iptRegID Is Nothing Then ErrorMessage = sError : Exit Sub

        'Dim sResult As String
        'sResult = objGlobalView.AddInGlobalView(sParentID, iptRegID.Value)
        'If sResult = "" Then
        '    PrepareMe(True)
        '    InfoMessage = "Company has been Marked as only Global View Member."
        'Else
        '    ErrorMessage = "Company can not be Marked as <b>Only Global View Member</b>."
        'End If
        'AC_CR_00005
    End Sub
    Private Sub ExcludeCompany()
        'AC_CR_00005
        'Dim iptGVStatus As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVStatus"), HtmlInputHidden)
        'Dim sError As String = "There were some problems performing this operation. Retry later."

        'If iptGVStatus Is Nothing Then ErrorMessage = sError : Exit Sub

        'If iptGVStatus.Value = 4 Then
        '    ErrorMessage = "<b>Parent Comapany</b> is already a Separate company."
        '    Exit Sub
        'ElseIf iptGVStatus.Value <> 1 Then
        '    ErrorMessage = "Only <b>Registered Companies</b> can be Marked as Separate company."
        '    Exit Sub
        'End If

        'Dim iptRegID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegID"), HtmlInputHidden)
        'Dim sParentID As String = Session("ACC_GV_ParentCustomerID")

        'If sParentID = Nothing Or iptRegID Is Nothing Then ErrorMessage = sError : Exit Sub
        'Dim sResult As String
        'sResult = objGlobalView.AddInGlobalView(sParentID, iptRegID.Value, True)
        'If sResult = "" Then
        '    Dim iptGVCompName As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVCompName"), HtmlInputHidden)
        '    Dim GVCompEmail As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("GVCompEmail"), HtmlInputHidden)
        '    Dim RegUserID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegUserID"), HtmlInputHidden)
        '    Dim strPassword As String = GetUserPassword(RegUserID.Value)
        '    SendEmailToInformAboutOperation("COMPANY_HAS_BEEN_SEPERATED", iptGVCompName.Value, GVCompEmail.Value, RegUserID.Value, strPassword)
        '    PrepareMe(True)
        '    InfoMessage = "Company has been Marked as Separate company."
        'Else
        '    ErrorMessage = "Company can not be Marked as Separate company."
        'End If
        'AC_CR_00005
    End Sub
    Private Function CreateGlobalView() As Boolean
        Dim sResult As String
        sResult = objGlobalView.AddInGlobalView(CustomerID, CustomerID)
        If sResult = "" Then
            REM SR No Need to update global view as its being always refreshed in PrepareMe() procedure
            '''''Dim dtCompanies As DataTable = CType(Session("ACC_GV_Companies"), DataTable)
            ''''Dim sqlRegComInfo As SqlDataReader = objGlobalView.GetRegisteredCompanyInfo(CustomerID) 'OK
            ''''If sqlRegComInfo.Read() Then
            ''''    Dim dr As DataRow = dtCompanies.NewRow
            ''''    dr("MemberCustomerID") = sqlRegComInfo("MemberCustomerID")
            ''''    dr("CompName") = sqlRegComInfo("CompName")
            ''''    dr("CompRegNo") = sqlRegComInfo("CompRegNo")
            ''''    dr("ARD") = sqlRegComInfo("ARD")
            ''''    dr("IncDate") = sqlRegComInfo("IncDate")
            ''''    dr("CompAddress") = sqlRegComInfo("CompAddress")
            ''''    dr("CompCity") = sqlRegComInfo("CompCity")
            ''''    dr("CompCountry") = sqlRegComInfo("CompCountry")
            ''''    dr("CompPhone") = sqlRegComInfo("CompPhone")
            ''''    dr("CompFax") = sqlRegComInfo("CompFax")
            ''''    dr("CompEmail") = sqlRegComInfo("CompEmail")
            ''''    dr("CompWebsite") = sqlRegComInfo("CompWebsite")
            ''''    dr("CompSec") = sqlRegComInfo("CompSec")
            ''''    dr("CompDirector") = sqlRegComInfo("CompDirector")
            ''''    dr("FullAddress") = sqlRegComInfo("FullAddress")
            ''''    dr("cart_customer_uid") = sqlRegComInfo("cart_customer_uid")
            ''''    dr("UpperCompName") = sqlRegComInfo("UpperCompName")
            ''''    dr("GVStatus") = sqlRegComInfo("GVStatus")
            ''''    dtCompanies.Rows.Add(dr)
            ''''    Session("ACC_GV_RegCompCount") += 1
            ''''End If
            ''''If Not sqlRegComInfo Is Nothing Then
            ''''    sqlRegComInfo.Close()
            ''''    sqlRegComInfo = Nothing
            ''''End If
            PrepareMe(True)
            Return True
        Else
            Return False
            'InfoMessage = "<b>Global View</b> created successfully.<P>"
            'ErrorMessage = "<b>Global View</b> is already created. Try Signing in again to have updated <b>Global View</b>.<P>"
        End If
    End Function
    Private Sub SignInTheParent()
        Dim sParentUserUID As String = ParentUserID
        FormsAuthentication.SignOut()
        SignInAccountsCentreUSer(sParentUserUID, "DUMMYPASSWORD", bSilentMode:=True, bDoNotRedirect:=True)
    End Sub
    Private Sub SetVisibility(ByVal bShow As Boolean, ByVal bOnlySummary As Boolean)
        'AC_CR_00005
        'dgridGlobalView.Visible = bShow AndAlso Not bOnlySummary
        'drpCompanyList.Visible = bShow
        'litSelComp.Visible = bShow
        'AC_CR_00005
        litSearchComp.Visible = bShow
        txtSearch.Visible = bShow
        btnGo.Visible = bShow
        'AC_CR_00005
        'btnSortByARD.Visible = bShow
        'btnSortByIncorporation.Visible = bShow
        'btnSortByName.Visible = bShow
        'AC_CR_00005
        dgridSummaryInformation.Visible = bShow
    End Sub
    Private Sub SearchData(ByVal sCompanyName As String, Optional ByVal bSearchByName As Boolean = False)
        Dim IntItemIndex As Integer
        IntItemIndex = FindInGrid(dgridSummaryInformation, sCompanyName)
        If IntItemIndex = -1 Then
            'InfoMessage = "Company with the given name not found."
            litFHMessage.Visible = True
            litFHMessage.Text = "Company with the given name not found."
        End If
        'If bSearchByName = True Then
        '    'Dim sTempSort As String
        '    'sTempSort = dvCompanies.Sort
        '    dvCompanies.Sort = "CompName"
        '    IntItemIndex = dvCompanies.Find(sCompanyName)
        '    'dvCompanies.Sort = sTempSort
        '    If IntItemIndex > -1 Then
        '        'Dim sID As String = dvCompanies.Item(IntItemIndex).Item("ID")
        '        'SearchData(sID)
        '    Else
        '        InfoMessage = "Company with the given name not found."
        '        Exit Sub
        '    End If
        'Else  '(if search by id then)
        '    'Dim sTempSort As String
        '    'sTempSort = dvCompanies.Sort
        '    dvCompanies.Sort = "ID"
        '    IntItemIndex = dvCompanies.Find(sCompanyName)
        '    'dvCompanies.Sort = sTempSort
        'End If

        'If IntItemIndex > -1 Then            
        '    'AC_CR_00005
        '    'SetGridSource(IntItemIndex)
        '    'drpCompanyList.SelectedValue = Nothing
        '    ''xdrpCompanyList.SelectedValue = drpCompanyList.Items.FindByValue(UCase(sCompanyName)).Value
        '    'Dim li As ListItem
        '    'li = drpCompanyList.Items.FindByValue(sCompanyName)
        '    'If Not li Is Nothing Then
        '    '    drpCompanyList.SelectedValue = li.Value
        '    'Else
        '    '    InfoMessage = "Company with the given name not found."
        '    'End If
        '    'AC_CR_00005
        'Else
        '    dgridSummaryInformation.SelectedIndex = Nothing
        '    InfoMessage = "Company with the given name not found."
        'End If
        'xPreparePanels()
        'AC_CR_00005
        'ShowCompanyDetail()
        'AC_CR_00005
    End Sub
    Private Sub SetGridSource(ByVal intIndex As Integer)
        'AC_CR_00005
        'dgridGlobalView.DataSource = dvCompanies
        'dgridGlobalView.CurrentPageIndex = intIndex
        'dgridGlobalView.DataBind()
        'AC_CR_00005
    End Sub
    Private Sub ProcessAddCompany(ByVal sCommandText As String)
        Select Case sCommandText
            Case "Create Global View", "Add Parent User As Company"
                If CreateGlobalView() = True Then : InfoMessage = "<b>Global View</b> created successfully.<P>"
                Else : ErrorMessage = "<b>Global View</b> is already created. Try Signing in again to have updated <b>Global View</b>.<P>"
                End If
            Case "Add a Company"
                AddCompany()
        End Select
    End Sub
    Private Sub ShowSummaryInformation(Optional ByVal bRefreshCombo As Boolean = False)
        'Drop Down List
        'AC_CR_00005
        'With drpCompanyList
        '    If (Not IsPostBack) Or bRefreshCombo = True Then
        '        .DataSource = dvCompanies
        '        If hCriteria.Value = 3 Or hCriteria.Value = 1 Then
        '            .DataTextField = "TaggedCompName"
        '        Else
        '            .DataTextField = "CompName"
        '        End If

        '        .DataValueField = "ID"
        '        .DataBind()
        '    End If
        'End With
        'AC_CR_00005
        'Global View Data Grid
        With dgridSummaryInformation
            .DataSource = dvCompanies
            set_culture()


            Trace.Warn("Thread.CurrentThread.CurrentUICulture.Name=" & System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
            Trace.Write("Calling DataBind")
            .DataBind()
            Trace.Write("DataBind is ok")
        End With
    End Sub

    Private Sub set_culture()
        'load_culture(idxtopbar.CultureName)
        'dgridSummaryInformation.Columns(0).HeaderText = load_gridheader("acc_globalview_globalview_ghcompanyname")
        'dgridSummaryInformation.Columns(1).HeaderText = load_gridheader("acc_globalview_globalview_ghincorporationdate")
        'dgridSummaryInformation.Columns(2).HeaderText = load_gridheader("acc_globalview_globalview_ghaccountsreferencedate")
        'dgridSummaryInformation.Columns(3).HeaderText = load_gridheader("acc_globalview_globalview_ghannualaccountsstatus")
        'dgridSummaryInformation.Columns(4).HeaderText = load_gridheader("acc_globalview_globalview_ghcompanystatus")
    End Sub



    Private Sub RenderData(Optional ByVal bRefreshCombo As Boolean = False)
        'Global View Data Grid
        'AC_CR_00005
        'With dgridGlobalView
        '    If bRefreshCombo = True Then .CurrentPageIndex = 0
        '    .DataSource = dvCompanies
        '    .DataBind()
        'End With
        'AC_CR_00005
    End Sub
    Private Sub ProcessCompany(ByVal sRegisteredID As String, ByVal sRegisteredUserID As String, ByVal sRedirectURL As String, ByVal sCompName As String, ByVal sCompNumber As String)
        Dim strDummyPassword = "DUMMYPASSWORD"
        Session("ACC_GV_ProcessCompany") = sCompName
        Session("ACC_GV_CompanyNumber") = sCompNumber
        Session("ACC_GV_SRegId") = sRegisteredID

        If IsNumeric(sRegisteredID) Then
            'Signout and Signin Child Company
            If (sRegisteredID <> CustomerID) Then
                FormsAuthentication.SignOut()
                SignInAccountsCentreUSer(sRegisteredUserID, strDummyPassword, bSilentMode:=True, bDoNotRedirect:=sRedirectURL <> "")
            End If
            If sRedirectURL <> "" Then
                Response.Redirect(sRedirectURL)
            Else
                Response.Redirect("/Members/Default.aspx")
            End If
        Else
            'Sign in the parent!
            'SignInTheParent()
            Session("ACC_GV_ProcessCompany") = sCompName
            Session("ACC_GV_CompanyNumber") = sCompNumber
            Response.Redirect("/globalview/selectCustomer.aspx")
        End If
    End Sub
    'AC_CR_00005
    Private Sub PreparePanels()
        '    ' Grid with Status: Show only if it is registered or excluded
        '    Dim pnlAnnualAccounts As Panel = CType(dgridGlobalView.Items(0).FindControl("pnlAnnualAccountsStatus"), Panel)
        '    If GVStatus = 0 Then    'If Unregistered Company
        '        pnlAnnualAccounts.Visible = False
        '        Exit Sub
        '    Else                    'If Excluded or Regisered Company
        '        pnlAnnualAccounts.Visible = True
        '    End If
        '    LoadAnnualAccountsStatusGrid()

        '    ' Inc Date and ARD: Show always
        '    With dvCompanies
        '        If IsDBNull(.Item(dgridGlobalView.CurrentPageIndex).Item("IncDate")) Then
        '            CType(dgridGlobalView.Items(0).FindControl("litIncDate"), Literal).Text = "Not Available"
        '        Else
        '            CType(dgridGlobalView.Items(0).FindControl("litIncDate"), Literal).Text = Format(.Item(dgridGlobalView.CurrentPageIndex).Item("IncDate"), "dd MMMM, yyyy")
        '        End If

        '        If IsDBNull(.Item(dgridGlobalView.CurrentPageIndex).Item("ARD")) Then
        '            CType(dgridGlobalView.Items(0).FindControl("litARD"), Literal).Text = "Not Available"
        '        Else
        '            Dim strARDDate() As String
        '            strARDDate = Split(.Item(dgridGlobalView.CurrentPageIndex).Item("ARD"), "/")
        '            If strARDDate.Length = 2 AndAlso IsNumeric(strARDDate(0)) AndAlso strARDDate(0) >= 1 AndAlso strARDDate(0) <= 31 AndAlso strARDDate(1) >= 1 AndAlso strARDDate(1) <= 12 Then
        '                CType(dgridGlobalView.Items(0).FindControl("litARD"), Literal).Text = strARDDate(0) & ", " & MonthName(strARDDate(1))
        '            End If
        '        End If
        '    End With

        '    ' Panels: Show only if any one year is due and for only those that are registered and not excluded        
        '    If GVStatus = 2 Or (mbHasAnnualAccountsData = True And mbIsDue = False) Then
        '        SetPanelsVisibilty(False, False, False)
        '        Exit Sub
        '    End If

        '    'It is confirmed now that it has no data of annual accounts (thus no ARD and IncDate) so now it is
        '    'not possible to check for due or not!
        '    Dim objAnnualAccounts As New AnnualAccounts
        '    Dim iptRegID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegID"), HtmlInputHidden)
        '    If objAnnualAccounts.IsCTReturnAllowed(iptRegID.Value) Then
        '        SetPanelsVisibilty(False, True, False)
        '    Else
        '        SetPanelsVisibilty(True, False, False)
        '    End If
    End Sub
    'AC_CR_00005
    Private Sub SetPanelsVisibilty(ByVal bSubscribe As Boolean, ByVal bCTReturn As Boolean, ByVal bUpload As Boolean)
        Exit Sub 'There are no such panels existed in the grid!
        'CType(dgridGlobalView.Items(0).FindControl("pnlSubscription"), Panel).Visible = bSubscribe
        'CType(dgridGlobalView.Items(0).FindControl("pnlCTReturn"), Panel).Visible = bCTReturn
        'CType(dgridGlobalView.Items(0).FindControl("pnlUpload"), Panel).Visible = bUpload
    End Sub
    Private Sub LoadAnnualAccountsStatusGrid()
        'AC_CR_00005
        'Dim dtblAnnualAccounts As DataTable, dgrid As DataGrid
        'dgrid = CType(dgridGlobalView.Items(0).FindControl("dgridAnnualAccounts"), DataGrid)
        'dgrid.Visible = False

        'Dim iptRegID As HtmlInputHidden = CType(dgridGlobalView.Items(0).FindControl("RegID"), HtmlInputHidden)
        'If iptRegID.Value <> "" Then
        '    Dim sARD As String, dtIncDate As Date
        '    If IsDBNull(dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("ARD")) Then
        '        sARD = ""
        '    Else
        '        sARD = dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("ARD")
        '    End If

        '    If IsDBNull(dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("IncDate")) Then
        '        dtIncDate = Nothing
        '    Else
        '        dtIncDate = dvCompanies.Item(dgridGlobalView.CurrentPageIndex).Item("IncDate")
        '    End If

        '    Dim objAnnualAccounts As New AnnualAccounts
        '    dtblAnnualAccounts = objAnnualAccounts.GetAnnualAccountsStatus(iptRegID.Value, sARD, dtIncDate)
        '    dgrid = CType(dgridGlobalView.Items(0).FindControl("dgridAnnualAccounts"), DataGrid)
        '    Dim litThereIsNoRecord As System.Web.UI.WebControls.Literal
        '    litThereIsNoRecord = CType(dgridGlobalView.Items(0).FindControl("litThereIsNoRecord"), Literal)

        '    If dtblAnnualAccounts Is Nothing Then
        '        litThereIsNoRecord.Visible = True
        '        Exit Sub
        '    End If

        '    If dtblAnnualAccounts.Rows.Count > 0 Then
        '        dgrid.Visible = True
        '        dgrid.DataSource = dtblAnnualAccounts
        '        dgrid.DataBind()
        '        mbHasAnnualAccountsData = True

        '        'Check wether it has any Due Financial Years
        '        Dim dvDueStatus As DataView
        '        dvDueStatus = dtblAnnualAccounts.DefaultView
        '        dvDueStatus.RowFilter = "Status='DUE' or Status='OVER DUE'"

        '        If dvDueStatus.Count > 0 Then
        '            mbIsDue = True
        '        Else
        '            mbIsDue = False
        '        End If
        '        litThereIsNoRecord.Visible = False
        '    Else
        '        litThereIsNoRecord.Visible = True
        '    End If

        'End If
        'AC_CR_00005
    End Sub
    Private Sub ProcessIfUserCanBeAddedToGlobalView()
        Dim iCustomerID As Integer
        If Session("ACC_GV_ParentCustomerID") <> Nothing Then
            iCustomerID = Session("ACC_GV_ParentCustomerID")
        Else
            iCustomerID = CustomerID
        End If
        Dim sqlDRParentUser As SqlDataReader = objGlobalView.GetParentUserGlobalViewStatus(iCustomerID) 'OK
        If sqlDRParentUser.Read() Then
            If sqlDRParentUser.Item(1) <> 0 Then
                'AC_CR_00005
                'btnAddParentUser.Visible = True
                'AC_CR_00005
                GoTo B4End
            End If
        End If
        'AC_CR_00005
        'btnAddParentUser.Visible = False
        'AC_CR_00005
B4End:
        If Not sqlDRParentUser Is Nothing Then
            sqlDRParentUser.Close()
            sqlDRParentUser = Nothing
        End If
    End Sub
    Private Sub GetGlobalViewCompaniesAndInfo(ByVal CustomerID As Int32)
        Dim sqlDR As SqlDataReader
        sqlDR = objGlobalView.GetUserInformation(CustomerID)
        If sqlDR.Read() Then
            Session("ACC_GV_RegCompCount") = sqlDR("TotalRegComp")
            Session("ACC_GV_ExcCompCount") = sqlDR("TotalExcComp")
        Else
            Session("ACC_GV_RegCompCount") = 0
            Session("ACC_GV_ExcCompCount") = 0
        End If
        If Not sqlDR Is Nothing Then
            If sqlDR.IsClosed = False Then sqlDR.Close()
            sqlDR = Nothing
        End If
    End Sub
    Private Sub SetCriteria(ByVal iCriteria As Integer)
        'lnkbtnTotalCompanies.CssClass = IIf(iCriteria = 3, "text-outerborder-light_blue_background", "")
        'lnkbtnRegCompanies.CssClass = IIf(iCriteria = 1, "text-outerborder-light_blue_background", "")
        'lnkbtnUnregCompanies.CssClass = IIf(iCriteria = 0, "text-outerborder-light_blue_background", "")
        'lnkbtnExcludedCompanies.CssClass = IIf(iCriteria = 2, "text-outerborder-light_blue_background", "")

        'AC_CR_00005
        'litSelectionMode.Text = Switch(iCriteria = 0, "Unregistered Companies", iCriteria = 1, "Registered Companies", iCriteria = 2, "Separated Companies", iCriteria = 3, "All Companies")
        'AC_CR_00005

        hCriteria.Value = iCriteria
    End Sub
    Private Sub SendEmailToInformAboutOperation(ByVal sOperationName As String, ByVal ParamArray PA() As String)
        Select Case sOperationName
            Case "COMPANY_HAS_BEEN_SEPERATED"
                Dim strEmailContent, strSubject, strTo, sCompanyName, strUserID, strPassword As String

                sCompanyName = PA(0)
                strTo = PA(1)
                strSubject = "Company Status Notification with new Account Credentials"
                strUserID = PA(2)
                strPassword = PA(3)

                strEmailContent = "The company " & sCompanyName & " has now been marked for separation from Global View." & vbCrLf & _
                                "Please find new account credentials below: " & vbCrLf & vbCrLf & _
                                "User ID: " & strUserID & vbCrLf & _
                                "Password: " & strPassword & vbCrLf & vbCrLf & _
                                "You can use this new User ID and Password to view and operate this company." & vbCrLf & vbCrLf & _
                                "Thank you." & vbCrLf & vbCrLf & _
                                "For further information and assistance regarding our services, " & vbCrLf & vbCrLf & _
                                "Email:   support@accountscentre.com " & vbCrLf & _
                                "Phone:  +44 (0)207 016 2729 (9am - 1pm on weekdays)"
                CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), strTo, strSubject, strEmailContent)
        End Select
    End Sub
    Private Function GetFilterString() As String
        Select Case hCriteria.Value
            Case 0 : Return "GVStatus=0"
            Case 1 : Return "GVStatus=1 or GVStatus=4"
            Case 2 : Return "GVStatus=2"
            Case Else : Return ""
        End Select
    End Function
#End Region

    Private Sub dgridSummaryInformation_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgridSummaryInformation.SortCommand
        dgridSummaryInformation.SelectedIndex = -1
        If hSort.Value = "DissolvedDate, Dormant" Then
            dvCompanies.Sort = "DissolvedDate DESC, Dormant DESC"
        ElseIf hSort.Value = e.SortExpression Then
            dvCompanies.Sort = e.SortExpression & " DESC"
        Else
            dvCompanies.Sort = e.SortExpression
        End If
        hSort.Value = e.SortExpression
        ShowSummaryInformation()
    End Sub

    Private Function FindInGrid(ByRef grd As System.Web.UI.WebControls.DataGrid, ByVal sCompanyName As String) As Integer
        grd.SelectedIndex = -1
        Dim gi As System.Web.UI.WebControls.DataGridItem
        For Each gi In grd.Items
            Dim d1 As String = Trim(gi.Cells(12).Text.ToUpper)
            Dim d2 As String = Trim(sCompanyName.ToUpper)

            If Trim(gi.Cells(12).Text.ToUpper) = Trim(sCompanyName.ToUpper) Then
                grd.SelectedIndex = gi.ItemIndex
                Return gi.ItemIndex
            End If
        Next
        Return -1
    End Function

    Private Sub InitializeComponent()

    End Sub

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnGo.Click
        SearchData(txtSearch.Text, True)
        txtSearch.Text = ""
    End Sub
End Class