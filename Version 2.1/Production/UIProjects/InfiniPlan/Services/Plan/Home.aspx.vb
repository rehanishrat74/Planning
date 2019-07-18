Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.DAL

Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.Common

Imports System.Xml
Public Class Home
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    '   Private _connData As ConnectionData

    Protected WithEvents Form2 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents lblError As System.Web.UI.WebControls.Label
    Dim Objplan As Plan
    Dim ObjCustomer As CustomerStatus
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents pnlManager As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents btnStart As System.Web.UI.WebControls.Button
    Dim businessPlan As Infinilogic.BusinessPlan.BLL.BusinessPlan
    Protected WithEvents txtText4 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText5 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText6 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText7 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText8 As System.Web.UI.WebControls.Label
    Protected WithEvents txtText9 As System.Web.UI.WebControls.Label
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
        InitiliazeLanguage()
    End Sub

#End Region

    Private Sub InitiliazeLanguage()

        'Dim str As String = ResMgr.GetString("bizplanweb_services_plan_welcome_lnkHome")
        'Me.lblHeading1.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading1")
        'Me.lblHeading2.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading2")
        'Me.lblHeading3.Text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading3")
        Me.btnStart.Text = ResMgr.GetString("bizplanweb_services_plan_home_btnStart")
        'Me.txtText1.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText1")
        'Me.txtText2.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText2")
        'Me.txtText3.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText3")
        Me.txtText4.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText4")
        Me.txtText5.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText5")
        Me.txtText6.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText6")
        Me.txtText7.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText7")
        Me.txtText8.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText8")
        Me.txtText9.Text = ResMgr.GetString("bizplanweb_services_plan_home_txtText9")
        ' Me.lblHeading.text = ResMgr.GetString("bizplanweb_services_plan_home_lblHeading")

    End Sub


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
 


        ''Web Traffic analysis
        'Dim sessionInfo As New com.webtracker.webservices.sessionInfo
        'Dim WebTrackerServices As New com.webtracker.webservices.WebTrackerServices
        'Dim trackInfo As com.webtracker.webservices.trackInfo
        'Dim detailInfo As New com.webtracker.webservices.detailInfo
        'sessionInfo.siteUrl = "formationshouse"
        'sessionInfo.siteName = "Formation House"
        'sessionInfo.siteCode = "e00a50be33607571abbd60a988267b5f"
        'trackInfo = WebTrackerServices.startSession(sessionInfo)
        'Dim data As String = trackInfo.data
        'Dim xmlDoc As New XmlDocument
        'Dim nodelist As XmlNodeList
        'Dim xNode As XmlNode
        'xmlDoc.LoadXml(data)
        'detailInfo.sessionId = trackInfo.ERRORDESC
        'detailInfo.trackId = "737"
        'trackInfo = WebTrackerServices.getTrackDetails(detailInfo)
        'Dim sre As String = trackInfo.data
        'trackInfo = WebTrackerServices.getTrackHistory(detailInfo)
        'Dim str As String = trackInfo.data
        ''Web Traffic analysis


        Dim BoolStatus As Boolean
        BoolStatus = ObjCustomer.CustomerSerivceStatus(GetConnectionData)
        SetProWebCustomer = BoolStatus

        'If BoolStatus = True Then
        '    Dim bool As Boolean = Objplan.BasePlanCheck(GetConnectionData)

        '    If bool = False Then
        '        businessPlan = New businessPlan.BLL.BusinessPlan
        '        SetPlanDefault()
        '        Objplan.CreateNewBaseBusinessPlan(GetConnectionData, businessPlan)
        '    Else

        '    End If


        'End If
        If IsPlanOpened Then
            Response.Redirect("/InfiniPlan/Services/Welcome.aspx")
        End If
        CurPage = 0
        CurItem = 0

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Response.Redirect("/InfiniPlan/Services/Plan/PlanManager.aspx")
    End Sub

    Private Sub SetPlanDefault()

        Dim command As New InfiniCommand("BPL_GetWizardDefaults")
        Dim ds As DataSet = DataAccess.ExecuteDataSet(GetConnectionData, command)

        Dim currencycommand As New InfiniCommand("BPL_GetCustomerCurrency")
        currencycommand.AddParameter("@customerID", GetConnectionData.CustomerID)
        Dim currencyds As DataSet = DataAccess.ExecuteDataSet(GetConnectionData, currencycommand)

        businessPlan.BusinessGoods = CType(CInt(ds.Tables(0).Rows(PlanQueries.businessType).Item(0)), BusinessGoodsType) 'BLL.BusinessGoodsType.Products
        businessPlan.ManageInventory = CBool(CInt(ds.Tables(0).Rows(PlanQueries.manageInventory).Item(0)))
        businessPlan.InventoryTurnover = CSng(ds.Tables(0).Rows(PlanQueries.inventoryTurnover).Item(0))
        businessPlan.SellOnCredit = CBool(CInt(ds.Tables(0).Rows(PlanQueries.sellOnCredit).Item(0)))
        businessPlan.SalesOnCreditPercent = CSng(ds.Tables(0).Rows(PlanQueries.salesOnCredit).Item(0))
        businessPlan.CollectionPeriod = CInt(ds.Tables(0).Rows(PlanQueries.collectionDays).Item(0))

        businessPlan.SalesForecastType = CType(CInt(ds.Tables(0).Rows(PlanQueries.salesForcastType).Item(0)), BLL.SalesForecastType)
        businessPlan.DisplayExpense = CBool(CInt(ds.Tables(0).Rows(PlanQueries.categorizedExpense).Item(0)))
        businessPlan.PersonnelBurden = CSng(ds.Tables(0).Rows(PlanQueries.personalBurden).Item(0))
        businessPlan.ShortTermInterestRate = CSng(ds.Tables(0).Rows(PlanQueries.shortTermInterestRate).Item(0))
        businessPlan.LongTermInterestRate = CSng(ds.Tables(0).Rows(PlanQueries.longTermInterestRate).Item(0))
        businessPlan.EstimatedTaxRate = CSng(ds.Tables(0).Rows(PlanQueries.taxRate).Item(0))
        businessPlan.NonPayrollCashExpense = CSng(ds.Tables(0).Rows(PlanQueries.nonPayrollExpense).Item(0))
        businessPlan.PaymentDays = CInt(ds.Tables(0).Rows(PlanQueries.paymentDays).Item(0))
        businessPlan.IsOngoing = CBool(CInt(ds.Tables(0).Rows(PlanQueries.startupOrOngoing).Item(0)))
        businessPlan.StartYear = System.DateTime.Now.Year
        businessPlan.StartMonth = CStr(ds.Tables(0).Rows(PlanQueries.planStartDate).Item(0))
        businessPlan.BusinessDescription = CStr(ds.Tables(0).Rows(PlanQueries.planDescription).Item(0))
        businessPlan.StandardOrLongTerm = CType(CInt(ds.Tables(0).Rows(PlanQueries.standardOrLongTerm).Item(0)), StandardLongTerm)
        'businessPlan.Currency = CStr(ds.Tables(0).Rows(PlanQueries.Currency).Item(0))

        businessPlan.Currency = CStr(currencyds.Tables(0).Rows(0).Item(0))



        businessPlan.PlanName = "Infini Base Plan" ' CStr(ds.Tables(0).Rows(PlanQueries.planTitle).Item(0))

        Try
            command = New InfiniCommand("BPL_GetAccCenterUser")
            command.AddParameter("@CustomerID", GetConnectionData.CustomerID)
            ds = DataAccess.ExecuteDataSet(GetConnectionData, command)
        Catch ex As Exception

        End Try
        businessPlan.BusinessName = businessPlan.PlanName
        businessPlan.CompanyBusinessOwnership = CStr(IfDBNull(ds.Tables(0).Rows(0).Item("Owner"), ""))
        businessPlan.ContactDetails = CStr(IfDBNull(ds.Tables(0).Rows(0).Item("Contact"), ""))

        'businessPlan.CustomerStatus =  

    End Sub

    Private Function IfDBNull(ByVal dbValue As Object, ByVal replacement As Object) As Object
        If IsDBNull(dbValue) Then
            Return replacement
        Else
            Return dbValue
        End If
    End Function

   
End Class
