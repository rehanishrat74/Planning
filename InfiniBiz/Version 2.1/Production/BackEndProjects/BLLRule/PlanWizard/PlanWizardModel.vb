Imports System.Resources
Imports System.Globalization
Imports System.Threading
Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.Common

Public Class PlanWizardModel
    Implements IPlanWizardModel

#Region "Public/Private Members"

    Private _connData As ConnectionData
    Private _query As IPlanWizardQuery
    Private _resMgr As ResourceManager
    Private businessPlan As BusinessPlan.BLL.BusinessPlan
    Private QuerySettings As QuerySettingsList
    Private modelState As WizardState

    Public Event StateChanged() Implements IPlanWizardModel.StateChanged
    Public Event WizardStarted() Implements IPlanWizardModel.WizardStarted
    Public Event WizardFinished(ByVal exists As Boolean, ByVal errMessage As String) Implements IPlanWizardModel.WizardFinished
    Public Event NewPlanCreated(ByVal planName As String) Implements IPlanWizardModel.NewPlanCreated

#End Region

#Region "Constructors"

    Public Sub New(ByRef connData As ConnectionData)
        _connData = connData
        _resMgr = New ResourceManager("Infinilogic.BusinessPlan.BLLRules.PlanWizard", System.Reflection.Assembly.GetExecutingAssembly)
        modelState.isNew = True
        modelState.isBasic = True

        businessPlan = New BusinessPlan.BLL.BusinessPlan
        SetPlanDefault()

        '_query = New PlanWizardQuery
        QuerySettings = New QuerySettingsList
        SetQuery(PlanQueries.start)
    End Sub

    Public Sub New(ByRef connData As ConnectionData, ByVal queryID As PlanQueries, ByVal bPlan As BusinessPlan.BLL.BusinessPlan, ByVal iIsNew As Boolean, ByVal iIsBasic As Boolean)
        _connData = connData
        _resMgr = New ResourceManager("Infinilogic.BusinessPlan.BLLRules.PlanWizard", System.Reflection.Assembly.GetExecutingAssembly)
        modelState.isNew = iIsNew
        modelState.isBasic = iIsBasic

        businessPlan = bPlan
        '_query = New PlanWizardQuery
        QuerySettings = New QuerySettingsList
        SetQuery(queryID)
    End Sub

    Public Sub New(ByRef connData As ConnectionData, ByVal queryID As PlanQueries, ByVal bPlan As BusinessPlan.BLL.BusinessPlan, ByVal wizState As WizardState)
        _connData = connData
        _resMgr = New ResourceManager("Infinilogic.BusinessPlan.BLLRules.PlanWizard", System.Reflection.Assembly.GetExecutingAssembly)
        modelState = wizState

        businessPlan = bPlan
        '_query = New PlanWizardQuery
        QuerySettings = New QuerySettingsList
        SetQuery(queryID)
    End Sub

#End Region

#Region "Interface Implementation"

    Public Sub ChangeNext(ByVal queryResponse As IPlanWizardResponse) Implements IPlanWizardModel.ChangeNext

        'Dim qResponse As PlanWizardResponse = CType(queryResponse, PlanWizardResponse)
        SetPlanObject(queryResponse)
        SetQuery(NavigateForward(queryResponse))

        RaiseEvent StateChanged()
    End Sub

    Public Sub ChangeBack(ByVal queryResponse As IPlanWizardResponse) Implements IPlanWizardModel.ChangeBack

        'Dim qResponse As PlanWizardResponse = CType(queryResponse, PlanWizardResponse)
        SetPlanObject(queryResponse)
        SetQuery(NavigateBackward(queryResponse))

        RaiseEvent StateChanged()
    End Sub

    Public Sub Finish(ByVal queryResponse As IPlanWizardResponse) Implements IPlanWizardModel.Finish

        'Dim qResponse As PlanWizardResponse = CType(queryResponse, PlanWizardResponse)
        SetPlanObject(queryResponse)
        SetQuery(NavigateForward(queryResponse))

        If modelState.isNew Then
            If Plan.IfPlanAlreadyExists(_connData, businessPlan) Then
                If modelState.isBasic Then
                    SetQuery(PlanQueries.bPlanTitle)
                Else
                    SetQuery(PlanQueries.planTitle)
                End If

                RaiseEvent WizardFinished(True, _resMgr.GetString("PW_Error_PlanAlreadyExists"))
            Else
                RaiseEvent WizardFinished(False, "")
            End If
        Else
            If businessPlan.PlanName <> Plan.PlanNameByID(_connData, businessPlan.PlanID) Then
                If Plan.IfPlanAlreadyExists(_connData, businessPlan) Then
                    SetQuery(PlanQueries.planTitle)
                    RaiseEvent WizardFinished(True, _resMgr.GetString("PW_Error_PlanAlreadyExists"))
                Else
                    RaiseEvent WizardFinished(False, "")
                End If
            Else
                RaiseEvent WizardFinished(False, "")
            End If
        End If

    End Sub

    Public Sub Start() Implements IPlanWizardModel.Start

        RaiseEvent WizardStarted()
    End Sub

    Public Sub Save() Implements IPlanWizardModel.Save
        If modelState.isBasic Then
            businessPlan.PersonnelBurden = 0
            businessPlan.EstimatedTaxRate = 0
        End If

        If modelState.isNew Then
            Plan.CreateNewBusinessPlan(_connData, businessPlan)
            RaiseEvent NewPlanCreated(businessPlan.PlanName)
        Else
            Dim tempPlan As Plan = New Plan(_connData, businessPlan)
            tempPlan.SaveBusinessPlan(_connData, businessPlan)
            RaiseEvent NewPlanCreated(businessPlan.PlanName)
        End If
    End Sub

    Public Function GetPlan() As BusinessPlan.BLL.BusinessPlan Implements IPlanWizardModel.GetPlan
        Return businessPlan
    End Function

    Public Function GetPlanWizardQuery() As IPlanWizardQuery Implements IPlanWizardModel.getPlanWizardQuery
        Return _query
    End Function

    Public Function GetPlanWizardQueryByID(ByVal queryID As PlanQueries) As IPlanWizardQuery Implements IPlanWizardModel.getPlanWizardQueryByID
        Return _query
    End Function

    Public Function GetPlanSettingsList() As QuerySettingsList Implements IPlanWizardModel.GetPlanSettingsList
        SetQuerySettingsList()
        Return QuerySettings
    End Function

    Public Sub SetWizardState(ByVal state As WizardState) Implements IPlanWizardModel.SetWizardState
        modelState = state
    End Sub

    Public Function GetWizardState() As WizardState Implements IPlanWizardModel.GetWizardState
        Return modelState
    End Function

#End Region

#Region "Settings according to user input"

    Private Sub SetPlanObject(ByVal qResponse As IPlanWizardResponse)

        Dim PWresp As PlanWizardResponse
        Dim MRlist As MultipleResponseList

        If qResponse.ViewID = PlanQueries.PlanParticulars Or qResponse.ViewID = PlanQueries.bPlanParticulars Or qResponse.ViewID = PlanQueries.PlanStartAndTitle Or qResponse.ViewID = PlanQueries.bPlanStartAndTitle Then
            MRlist = CType(qResponse, MultipleResponseList)
        Else
            PWresp = CType(qResponse, PlanWizardResponse)
        End If

        Select Case qResponse.ViewID
            Case PlanQueries.start

            Case PlanQueries.basicAdvanced
                If PWresp.SelectionID = 0 Then
                    businessPlan.DisplayExpense = False
                    'businessPlan.StandardOrLongTerm = StandardLongTerm.StandardTerm
                    'businessPlan.PersonnelBurden = 0
                    'businessPlan.EstimatedTaxRate = 0
                    modelState.isBasic = True
                Else
                    modelState.isBasic = False
                End If


            Case PlanQueries.PlanParticulars
                businessPlan.BusinessName = MRlist.item(0).SelectionText
                businessPlan.CompanyBusinessOwnership = MRlist.item(1).SelectionText
                businessPlan.ContactDetails = MRlist.item(2).SelectionText

            Case PlanQueries.businessType
                If PWresp.SelectionID = 0 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Products
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Services
                    businessPlan.SalesForecastType = SalesForecastType.Value
                ElseIf PWresp.SelectionID = 2 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Both
                End If
            Case PlanQueries.manageInventory
                If PWresp.SelectionID = 0 Then
                    businessPlan.ManageInventory = True
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.ManageInventory = False
                End If
            Case PlanQueries.inventoryTurnover
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.InventoryTurnover = CSng(PWresp.SelectionText)
            Case PlanQueries.sellOnCredit
                If PWresp.SelectionID = 0 Then
                    businessPlan.SellOnCredit = True
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.SellOnCredit = False
                End If
            Case PlanQueries.salesOnCredit
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.SalesOnCreditPercent = CSng(PWresp.SelectionText)
            Case PlanQueries.collectionDays
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.CollectionPeriod = CInt(PWresp.SelectionText)
            Case PlanQueries.salesForcastType
                If PWresp.SelectionID = 0 Then
                    businessPlan.SalesForecastType = BLL.SalesForecastType.Units
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.SalesForecastType = BLL.SalesForecastType.Value
                End If
            Case PlanQueries.categorizedExpense
                If PWresp.SelectionID = 0 Then
                    businessPlan.DisplayExpense = True
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.DisplayExpense = False
                End If
            Case PlanQueries.personalBurden
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.PersonnelBurden = CSng(PWresp.SelectionText)
            Case PlanQueries.shortTermInterestRate
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.ShortTermInterestRate = CSng(PWresp.SelectionText)
            Case PlanQueries.longTermInterestRate
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.LongTermInterestRate = CSng(PWresp.SelectionText)
            Case PlanQueries.taxRate
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.EstimatedTaxRate = CSng(PWresp.SelectionText)
            Case PlanQueries.nonPayrollExpense
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.NonPayrollCashExpense = CSng(PWresp.SelectionText)
            Case PlanQueries.paymentDays
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.PaymentDays = CInt(PWresp.SelectionText)
            Case PlanQueries.startupOrOngoing
                If PWresp.SelectionID = 0 Then
                    businessPlan.IsOngoing = False
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.IsOngoing = True
                End If
            Case PlanQueries.PlanStartAndTitle

                If Not REValidator.IsIdentifier(MRlist.item(0).SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in title.")
                End If
                businessPlan.PlanName = Trim(MRlist.item(0).SelectionText)

                If Not REValidator.IsCalendarYear(MRlist.item(1).SelectionID.ToString()) Then
                    Throw New BizPlanInvalidDataException("Invalid month.")
                End If
                businessPlan.StartYear = CInt(MRlist.item(1).SelectionID)
                businessPlan.StartMonth = MRlist.item(1).SelectionText

            Case PlanQueries.planStartDate
                If Not REValidator.IsCalendarYear(PWresp.SelectionID.ToString()) Then
                    Throw New BizPlanInvalidDataException("Invalid month.")
                End If
                businessPlan.StartYear = CInt(PWresp.SelectionID)
                businessPlan.StartMonth = PWresp.SelectionText
            Case PlanQueries.standardOrLongTerm
                If PWresp.SelectionID = 0 Then
                    businessPlan.StandardOrLongTerm = StandardLongTerm.StandardTerm
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.StandardOrLongTerm = StandardLongTerm.LongTerm
                End If
            Case PlanQueries.planTitle
                If Not REValidator.IsIdentifier(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in title.")
                End If
                businessPlan.PlanName = Trim(PWresp.SelectionText)
            Case PlanQueries.planDescription
                If Not REValidator.IsText(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in description.")
                End If
                businessPlan.BusinessDescription = Trim(PWresp.SelectionText)

                'For Basic Wizard
            Case PlanQueries.bPlanParticulars
                businessPlan.BusinessName = MRlist.item(0).SelectionText
                businessPlan.CompanyBusinessOwnership = MRlist.item(1).SelectionText
                businessPlan.ContactDetails = MRlist.item(2).SelectionText

            Case PlanQueries.bBusinessType
                If PWresp.SelectionID = 0 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Products
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Services
                ElseIf PWresp.SelectionID = 2 Then
                    businessPlan.BusinessGoods = BLL.BusinessGoodsType.Both
                End If
            Case PlanQueries.bManageInventory
                If PWresp.SelectionID = 0 Then
                    businessPlan.ManageInventory = True
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.ManageInventory = False
                End If
            Case PlanQueries.bInventoryTurnover
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.InventoryTurnover = CSng(PWresp.SelectionText)
            Case PlanQueries.bSellOnCredit
                If PWresp.SelectionID = 0 Then
                    businessPlan.SellOnCredit = True
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.SellOnCredit = False
                End If
            Case PlanQueries.bSalesOnCredit
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.SalesOnCreditPercent = CSng(PWresp.SelectionText)
            Case PlanQueries.bCollectionDays
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.CollectionPeriod = CInt(PWresp.SelectionText)
            Case PlanQueries.bSalesForcastType
                If PWresp.SelectionID = 0 Then
                    businessPlan.SalesForecastType = BLL.SalesForecastType.Units
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.SalesForecastType = BLL.SalesForecastType.Value
                End If
            Case PlanQueries.bPersonalBurden
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.PersonnelBurden = CSng(PWresp.SelectionText)
            Case PlanQueries.bInterestRate
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.ShortTermInterestRate = CSng(PWresp.SelectionText)
                businessPlan.LongTermInterestRate = CSng(PWresp.SelectionText)
            Case PlanQueries.bTaxRate
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.EstimatedTaxRate = CSng(PWresp.SelectionText)
            Case PlanQueries.bNonPayrollExpense
                If Not REValidator.IsPercentage(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.NonPayrollCashExpense = CSng(PWresp.SelectionText)
            Case PlanQueries.bPaymentDays
                If Not REValidator.IsPositiveNumber(PWresp.SelectionText, 3) Then
                    Throw New BizPlanInvalidDataException("Invalid value.")
                End If
                businessPlan.PaymentDays = CInt(PWresp.SelectionText)
            Case PlanQueries.bStartupOrOngoing
                If PWresp.SelectionID = 0 Then
                    businessPlan.IsOngoing = False
                ElseIf PWresp.SelectionID = 1 Then
                    businessPlan.IsOngoing = True
                End If
            Case PlanQueries.bPlanStartAndTitle

                If Not REValidator.IsIdentifier(MRlist.item(0).SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in title.")
                End If
                businessPlan.PlanName = Trim(MRlist.item(0).SelectionText)

                If Not REValidator.IsCalendarYear(MRlist.item(1).SelectionID.ToString()) Then
                    Throw New BizPlanInvalidDataException("Invalid month.")
                End If
                businessPlan.StartYear = CInt(MRlist.item(1).SelectionID)
                businessPlan.StartMonth = MRlist.item(1).SelectionText

            Case PlanQueries.bPlanStartDate
                If Not REValidator.IsCalendarYear(PWresp.SelectionID.ToString()) Then
                    Throw New BizPlanInvalidDataException("Invalid year.")
                End If
                businessPlan.StartYear = CInt(PWresp.SelectionID)
                businessPlan.StartMonth = PWresp.SelectionText
            Case PlanQueries.bPlanTitle
                If Not REValidator.IsTitle(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in title.")
                End If
                businessPlan.PlanName = Trim(PWresp.SelectionText)
            Case PlanQueries.bPlanDescription
                If Not REValidator.IsTitle(PWresp.SelectionText) Then
                    Throw New BizPlanInvalidDataException("Invalid characters used in description.")
                End If
                businessPlan.BusinessDescription = Trim(PWresp.SelectionText)
            Case PlanQueries.bCurrency
                businessPlan.Currency = PWresp.SelectionText
            Case PlanQueries.Currency
                businessPlan.Currency = PWresp.SelectionText
            Case PlanQueries.finish

        End Select
    End Sub

    Private Sub SetPlanDefault()

        Dim command As New InfiniCommand("BPL_GetWizardDefaults")
        Dim ds As DataSet = DataAccess.ExecuteDataSet(_connData, command)

        Dim currencycommand As New InfiniCommand("BPL_GetCustomerCurrency")
        currencycommand.AddParameter("@customerID", _connData.CustomerID)
        Dim currencyds As DataSet = DataAccess.ExecuteDataSet(_connData, currencycommand)
 
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

 

        businessPlan.PlanName = CStr(ds.Tables(0).Rows(PlanQueries.planTitle).Item(0))

        Try
            command = New InfiniCommand("BPL_GetAccCenterUser")
            command.AddParameter("@CustomerID", _connData.CustomerID)
            ds = DataAccess.ExecuteDataSet(_connData, command)
        Catch ex As Exception

        End Try
        businessPlan.BusinessName = businessPlan.PlanName
        businessPlan.CompanyBusinessOwnership = CStr(IfDBNull(ds.Tables(0).Rows(0).Item("Owner"), ""))
        businessPlan.ContactDetails = CStr(IfDBNull(ds.Tables(0).Rows(0).Item("Contact"), ""))

        'businessPlan.CustomerStatus =  
         
    End Sub

    Private Sub SetQuery(ByVal queryID As PlanQueries)

        Dim PWqry As New PlanWizardQuery
        Dim MQlist As New MultipleQueryList

        'Set the selected ID or Text
        Select Case queryID
            Case PlanQueries.start
                PWqry.ViewID = PlanQueries.start
                PWqry.ViewType = QuestionTypes.none
                PWqry.ValidationType = ValidationTypes.None
                PWqry.Title = ""
                PWqry.Text = "PW_Text_Start"
                'PWqry.Text = ""
                PWqry.HelpText = "PW_Help_Start"
                'PWqry.HelpText = ""
                PWqry.SelectionID = 0
                PWqry.SelectionText = ""
                _query = PWqry
                Return
            Case PlanQueries.basicAdvanced
                If modelState.isBasic Then
                    PWqry.SelectionID = 0
                Else
                    PWqry.SelectionID = 1
                End If


                'For advanced wizard
            Case PlanQueries.PlanParticulars

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.BusinessName
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.CompanyBusinessOwnership
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.ContactDetails
                MQlist.Add(PWqry)

            Case PlanQueries.businessType
                PWqry.SelectionID = businessPlan.BusinessGoods
            Case PlanQueries.manageInventory
                PWqry.SelectionID = CInt(businessPlan.ManageInventory)
            Case PlanQueries.inventoryTurnover
                PWqry.SelectionText = businessPlan.InventoryTurnover.ToString()
            Case PlanQueries.sellOnCredit
                PWqry.SelectionID = CInt(businessPlan.SellOnCredit)
            Case PlanQueries.salesOnCredit
                PWqry.SelectionText = businessPlan.SalesOnCreditPercent.ToString()
            Case PlanQueries.collectionDays
                PWqry.SelectionText = businessPlan.CollectionPeriod.ToString()
            Case PlanQueries.salesForcastType
                PWqry.SelectionID = businessPlan.SalesForecastType
            Case PlanQueries.categorizedExpense
                PWqry.SelectionID = CInt(businessPlan.DisplayExpense)
            Case PlanQueries.personalBurden
                PWqry.SelectionText = businessPlan.PersonnelBurden.ToString()
            Case PlanQueries.shortTermInterestRate
                PWqry.SelectionText = businessPlan.ShortTermInterestRate.ToString()
            Case PlanQueries.longTermInterestRate
                PWqry.SelectionText = businessPlan.LongTermInterestRate.ToString()
            Case PlanQueries.taxRate
                PWqry.SelectionText = businessPlan.EstimatedTaxRate.ToString()
            Case PlanQueries.nonPayrollExpense
                PWqry.SelectionText = businessPlan.NonPayrollCashExpense.ToString()
            Case PlanQueries.paymentDays
                PWqry.SelectionText = businessPlan.PaymentDays.ToString()
            Case PlanQueries.startupOrOngoing
                If businessPlan.IsOngoing Then
                    PWqry.SelectionID = 1
                Else
                    PWqry.SelectionID = 0
                End If
            Case PlanQueries.PlanStartAndTitle

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.PlanName
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.StartMonth
                PWqry.SelectionID = businessPlan.StartYear
                MQlist.Add(PWqry)
            Case PlanQueries.Currency
                PWqry.SelectionText = businessPlan.Currency
            Case PlanQueries.planStartDate
                PWqry.SelectionText = businessPlan.StartMonth
                PWqry.SelectionID = businessPlan.StartYear
            Case PlanQueries.standardOrLongTerm
                PWqry.SelectionID = CInt(businessPlan.StandardOrLongTerm)
            Case PlanQueries.planTitle
                PWqry.SelectionText = businessPlan.PlanName
            Case PlanQueries.planDescription
                PWqry.SelectionText = businessPlan.BusinessDescription
            Case PlanQueries.finish
                PWqry.ViewID = PlanQueries.finish
                PWqry.ViewType = QuestionTypes.none
                PWqry.ValidationType = ValidationTypes.None
                PWqry.Title = ""
                PWqry.Text = "PW_Text_Finish"
                'PWqry.Text = ""
                PWqry.HelpText = "PW_Help_Finish"
                'PWqry.HelpText = ""
                PWqry.SelectionID = 0
                PWqry.SelectionText = ""
                _query = PWqry
                Return




                'For Basic Wizard
            Case PlanQueries.bPlanParticulars

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.BusinessName
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.CompanyBusinessOwnership
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.ContactDetails
                MQlist.Add(PWqry)

            Case PlanQueries.bBusinessType
                PWqry.SelectionID = businessPlan.BusinessGoods
            Case PlanQueries.bManageInventory
                PWqry.SelectionID = CInt(businessPlan.ManageInventory)
            Case PlanQueries.bInventoryTurnover
                PWqry.SelectionText = businessPlan.InventoryTurnover.ToString()
            Case PlanQueries.bSellOnCredit
                PWqry.SelectionID = CInt(businessPlan.SellOnCredit)
            Case PlanQueries.bSalesOnCredit
                PWqry.SelectionText = businessPlan.SalesOnCreditPercent.ToString()
            Case PlanQueries.bCollectionDays
                PWqry.SelectionText = businessPlan.CollectionPeriod.ToString()
            Case PlanQueries.bSalesForcastType
                PWqry.SelectionID = businessPlan.SalesForecastType
            Case PlanQueries.bPersonalBurden
                PWqry.SelectionText = businessPlan.PersonnelBurden.ToString()
            Case PlanQueries.bInterestRate
                PWqry.SelectionText = businessPlan.ShortTermInterestRate.ToString()
            Case PlanQueries.bTaxRate
                PWqry.SelectionText = businessPlan.EstimatedTaxRate.ToString()
            Case PlanQueries.bNonPayrollExpense
                PWqry.SelectionText = businessPlan.NonPayrollCashExpense.ToString()
            Case PlanQueries.bPaymentDays
                PWqry.SelectionText = businessPlan.PaymentDays.ToString()
            Case PlanQueries.bStartupOrOngoing
                If businessPlan.IsOngoing Then
                    PWqry.SelectionID = 1
                Else
                    PWqry.SelectionID = 0
                End If
            Case PlanQueries.bPlanStartAndTitle

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.PlanName
                MQlist.Add(PWqry)

                PWqry = New PlanWizardQuery
                PWqry.SelectionText = businessPlan.StartMonth
                PWqry.SelectionID = businessPlan.StartYear
                MQlist.Add(PWqry)
            Case PlanQueries.bCurrency
                PWqry.SelectionText = businessPlan.Currency
            Case PlanQueries.bPlanStartDate
                PWqry.SelectionText = businessPlan.StartMonth
                PWqry.SelectionID = businessPlan.StartYear
            Case PlanQueries.bPlanTitle
                PWqry.SelectionText = businessPlan.PlanName
            Case PlanQueries.bPlanDescription
                PWqry.SelectionText = businessPlan.BusinessDescription
        End Select



        If queryID = PlanQueries.PlanParticulars Or queryID = PlanQueries.bPlanParticulars Then

            ' Chkit(MQlist, queryID, MQlist.Count)
            MQlist.ViewID = queryID
            _query = MQlist

        ElseIf queryID = PlanQueries.PlanStartAndTitle Or queryID = PlanQueries.bPlanStartAndTitle Then

            MQlist.ViewID = queryID
            _query = MQlist

        Else

            'Get query data
            Dim queryTag, optionTag As String
            Dim optionItem As QueryOption

            Dim command As New InfiniCommand("BPL_GetWizardItems")
            command.AddParameter("@QueryID", CInt(queryID))
            Dim ds As DataSet = DataAccess.ExecuteDataSet(_connData, command)

            'Set the view ID
            PWqry.ViewID = queryID

            'Get the tag to use with resource file
            queryTag = CStr(ds.Tables(0).Rows(0).Item(1))

            'Set the view type
            Select Case CInt(ds.Tables(0).Rows(0).Item(2))
                Case 0
                    PWqry.ViewType = QuestionTypes.yesNo
                Case 1
                    PWqry.ViewType = QuestionTypes.options
                Case 2
                    PWqry.ViewType = QuestionTypes.text
                Case 3
                    PWqry.ViewType = QuestionTypes.calendarDate
                Case 7
                    PWqry.ViewType = QuestionTypes.Currency
            End Select

            'Set the validation type
            Select Case CInt(ds.Tables(0).Rows(0).Item(3))
                Case 0
                    PWqry.ValidationType = ValidationTypes.None
                Case 1
                    PWqry.ValidationType = ValidationTypes.Number
                Case 2
                    PWqry.ValidationType = ValidationTypes.Percentage
                Case 3
                    PWqry.ValidationType = ValidationTypes.Text
                Case 4
                    PWqry.ValidationType = ValidationTypes.CalendarDate
                Case 5
                    PWqry.ValidationType = ValidationTypes.PlanCurrency

            End Select

            'Get the string from the resource file
            PWqry.Title = "PW_Title_" & queryTag
            PWqry.Text = "PW_Text_" & queryTag
            PWqry.HelpText = "PW_Help_" & queryTag

            'Get the Wizard Query Options
            PWqry.OptionItemList.Clear()
            For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
                optionTag = CStr(ds.Tables(1).Rows(i).Item(1))
                optionItem = New QueryOption
                optionItem.OptionID = CInt(ds.Tables(1).Rows(i).Item(0))
                optionItem.OptionText = "PW_" & queryTag & "_" & optionTag
                PWqry.OptionItemList.Add(optionItem)
            Next

            _query = PWqry

        End If

    End Sub

    Private Sub Chkit(ByVal MQlist As MultipleQueryList, ByVal queryID As PlanQueries, ByVal Count As Integer)
        'Get query data


        Dim queryTag, optionTag As String
        Dim optionItem As QueryOption

        Dim command As New InfiniCommand("BPL_GetWizardItems")
        command.AddParameter("@QueryID", CInt(queryID))
        Dim ds As DataSet = DataAccess.ExecuteDataSet(_connData, command)

        'Set the view ID
        MQlist.item(0).ViewID = queryID


        'Get the tag to use with resource file
        queryTag = CStr(ds.Tables(0).Rows(0).Item(1))

        'Set the view type
        Select Case CInt(ds.Tables(0).Rows(0).Item(2))
            Case 0
                '  MQlist.item(0).ViewID = QuestionTypes.yesNo
            Case 1
                MQlist.item(0).ViewType = QuestionTypes.options
            Case 2
                MQlist.item(0).ViewType = QuestionTypes.text
            Case 3
                MQlist.item(0).ViewType = QuestionTypes.calendarDate
        End Select

        'Set the validation type
        Select Case CInt(ds.Tables(0).Rows(0).Item(3))
            Case 0
                MQlist.item(0).ValidationType = ValidationTypes.None
            Case 1
                MQlist.item(0).ValidationType = ValidationTypes.Number
            Case 2
                MQlist.item(0).ValidationType = ValidationTypes.Percentage
            Case 3
                MQlist.item(0).ValidationType = ValidationTypes.Text
            Case 4
                MQlist.item(0).ValidationType = ValidationTypes.CalendarDate
        End Select

        'Get the string from the resource file
        MQlist.item(0).Title = "PW_Title_" & queryTag
        MQlist.item(0).Text = "PW_Text_" & queryTag
        MQlist.item(0).HelpText = "PW_Help_" & queryTag

        'Get the Wizard Query Options
        MQlist.item(0).OptionItemList.Clear()
        For i As Integer = 0 To ds.Tables(1).Rows.Count - 1
            optionTag = CStr(ds.Tables(1).Rows(i).Item(1))
            optionItem = New QueryOption
            optionItem.OptionID = CInt(ds.Tables(1).Rows(i).Item(0))
            optionItem.OptionText = "PW_" & queryTag & "_" & optionTag
            MQlist.item(0).OptionItemList.Add(optionItem)
        Next

        _query = MQlist
    End Sub

    Private Sub SetQuerySettingsList()

        Dim command As New InfiniCommand("BPL_GetWizardTags")
        Dim ds As DataSet = DataAccess.ExecuteDataSet(_connData, command)

        QuerySettings.Clear()
        QuerySettings.Add(PlanQueries.businessType, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.businessType).Item(0)), businessPlan.BusinessGoods.ToString())
        QuerySettings.Add(PlanQueries.manageInventory, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.manageInventory).Item(0)), businessPlan.ManageInventory.ToString())
        If businessPlan.ManageInventory Then QuerySettings.Add(PlanQueries.inventoryTurnover, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.inventoryTurnover).Item(0)), businessPlan.InventoryTurnover.ToString())
        QuerySettings.Add(PlanQueries.sellOnCredit, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.sellOnCredit).Item(0)), businessPlan.SellOnCredit.ToString())
        If businessPlan.SellOnCredit Then QuerySettings.Add(PlanQueries.salesOnCredit, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.salesOnCredit).Item(0)), businessPlan.SalesOnCreditPercent.ToString())
        If businessPlan.SellOnCredit Then QuerySettings.Add(PlanQueries.collectionDays, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.collectionDays).Item(0)), businessPlan.CollectionPeriod.ToString())
        If businessPlan.BusinessGoods = BusinessGoodsType.Products Or businessPlan.BusinessGoods = BusinessGoodsType.Both Then QuerySettings.Add(PlanQueries.salesForcastType, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.salesForcastType).Item(0)), businessPlan.SalesForecastType.ToString())
        QuerySettings.Add(PlanQueries.categorizedExpense, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.categorizedExpense).Item(0)), businessPlan.DisplayExpense.ToString())
        QuerySettings.Add(PlanQueries.personalBurden, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.personalBurden).Item(0)), businessPlan.PersonnelBurden.ToString())
        QuerySettings.Add(PlanQueries.shortTermInterestRate, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.shortTermInterestRate).Item(0)), businessPlan.ShortTermInterestRate.ToString())
        QuerySettings.Add(PlanQueries.longTermInterestRate, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.longTermInterestRate).Item(0)), businessPlan.LongTermInterestRate.ToString())
        QuerySettings.Add(PlanQueries.taxRate, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.taxRate).Item(0)), businessPlan.EstimatedTaxRate.ToString())
        QuerySettings.Add(PlanQueries.nonPayrollExpense, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.nonPayrollExpense).Item(0)), businessPlan.NonPayrollCashExpense.ToString())
        QuerySettings.Add(PlanQueries.paymentDays, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.paymentDays).Item(0)), businessPlan.PaymentDays.ToString())
        If businessPlan.IsOngoing Then
            QuerySettings.Add(PlanQueries.startupOrOngoing, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.startupOrOngoing).Item(0)), _resMgr.GetString("PW_" & CStr(ds.Tables(0).Rows(PlanQueries.startupOrOngoing).Item(0)) & "_Ongoing"))
        Else
            QuerySettings.Add(PlanQueries.startupOrOngoing, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.startupOrOngoing).Item(0)), _resMgr.GetString("PW_" & CStr(ds.Tables(0).Rows(PlanQueries.startupOrOngoing).Item(0)) & "_Startup"))
        End If
        QuerySettings.Add(PlanQueries.Currency, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.Currency).Item(0)), businessPlan.Currency)
        QuerySettings.Add(PlanQueries.planStartDate, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.planStartDate).Item(0)), businessPlan.StartMonth.ToString() & " " & businessPlan.StartYear.ToString())
        'QuerySettings.Add(PlanQueries.standardOrLongTerm, _resMgr.GetString("PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.standardOrLongTerm).Item(0))), businessPlan.StandardOrLongTerm.ToString())
        QuerySettings.Add(PlanQueries.planTitle, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.planTitle).Item(0)), businessPlan.PlanName)
        QuerySettings.Add(PlanQueries.planDescription, "PW_Title_" & CStr(ds.Tables(0).Rows(PlanQueries.planDescription).Item(0)), businessPlan.BusinessDescription)

    End Sub

#End Region

#Region "Navigator"

    Private Function NavigateForward(ByVal qResponse As IPlanWizardResponse) As PlanQueries

        Dim PWresp As PlanWizardResponse
        Dim MRlist As MultipleResponseList

        If qResponse.ViewID = PlanQueries.PlanParticulars Or qResponse.ViewID = PlanQueries.bPlanParticulars Or qResponse.ViewID = PlanQueries.PlanStartAndTitle Or qResponse.ViewID = PlanQueries.bPlanStartAndTitle Then
            MRlist = CType(qResponse, MultipleResponseList)
        Else
            PWresp = CType(qResponse, PlanWizardResponse)
        End If


        Dim nextQuery As PlanQueries

        Select Case qResponse.ViewID
            Case PlanQueries.start
                nextQuery = PlanQueries.basicAdvanced

                'Check for basic or advanced wizard
            Case PlanQueries.basicAdvanced
                If PWresp.SelectionID = 0 Then
                    modelState.isBasic = True



                    nextQuery = PlanQueries.businessType
                ElseIf PWresp.SelectionID = 1 Then
                    modelState.isBasic = False
                    nextQuery = PlanQueries.bBusinessType
                End If



                'For Advanced Wizard

            Case PlanQueries.businessType
                nextQuery = PlanQueries.manageInventory
            Case PlanQueries.manageInventory
                If PWresp.SelectionID = 0 Then
                    nextQuery = PlanQueries.inventoryTurnover
                ElseIf PWresp.SelectionID = 1 Then
                    nextQuery = PlanQueries.sellOnCredit
                End If
            Case PlanQueries.inventoryTurnover
                nextQuery = PlanQueries.sellOnCredit
            Case PlanQueries.sellOnCredit
                If PWresp.SelectionID = 0 Then
                    nextQuery = PlanQueries.salesOnCredit
                ElseIf PWresp.SelectionID = 1 Then
                    If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                        nextQuery = PlanQueries.categorizedExpense
                    Else
                        nextQuery = PlanQueries.salesForcastType
                    End If
                End If
            Case PlanQueries.salesOnCredit
                nextQuery = PlanQueries.collectionDays
            Case PlanQueries.collectionDays
                If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                    nextQuery = PlanQueries.categorizedExpense
                Else
                    nextQuery = PlanQueries.salesForcastType
                End If
            Case PlanQueries.salesForcastType
                nextQuery = PlanQueries.categorizedExpense
            Case PlanQueries.categorizedExpense
                nextQuery = PlanQueries.personalBurden
            Case PlanQueries.personalBurden
                nextQuery = PlanQueries.shortTermInterestRate
            Case PlanQueries.shortTermInterestRate
                nextQuery = PlanQueries.longTermInterestRate
            Case PlanQueries.longTermInterestRate
                nextQuery = PlanQueries.taxRate
            Case PlanQueries.taxRate
                nextQuery = PlanQueries.nonPayrollExpense
            Case PlanQueries.nonPayrollExpense
                nextQuery = PlanQueries.paymentDays
            Case PlanQueries.paymentDays
                nextQuery = PlanQueries.startupOrOngoing
            Case PlanQueries.startupOrOngoing
                nextQuery = PlanQueries.Currency
            Case PlanQueries.Currency
                nextQuery = PlanQueries.planStartDate
            Case PlanQueries.planStartDate
                nextQuery = PlanQueries.planTitle



            Case PlanQueries.planTitle
                nextQuery = PlanQueries.planDescription
            Case PlanQueries.planDescription
                If modelState.isNew Then
                    nextQuery = PlanQueries.finish
                Else
                    nextQuery = PlanQueries.planDescription
                End If





                'For Basic Wizard
                'Case PlanQueries.bBusinessType
                '    nextQuery = PlanQueries.bBusinessType
            Case PlanQueries.bBusinessType
                nextQuery = PlanQueries.manageInventory
            Case PlanQueries.bManageInventory
                If PWresp.SelectionID = 0 Then
                    nextQuery = PlanQueries.bInventoryTurnover
                ElseIf PWresp.SelectionID = 1 Then
                    nextQuery = PlanQueries.bSellOnCredit
                End If
            Case PlanQueries.bInventoryTurnover
                nextQuery = PlanQueries.bSellOnCredit
            Case PlanQueries.bSellOnCredit
                If PWresp.SelectionID = 0 Then
                    nextQuery = PlanQueries.bSalesOnCredit
                ElseIf PWresp.SelectionID = 1 Then
                    If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                        nextQuery = PlanQueries.bInterestRate
                    Else
                        nextQuery = PlanQueries.bSalesForcastType
                    End If
                End If
            Case PlanQueries.bSalesOnCredit
                nextQuery = PlanQueries.bCollectionDays
            Case PlanQueries.bCollectionDays
                If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                    nextQuery = PlanQueries.bInterestRate
                Else
                    nextQuery = PlanQueries.bSalesForcastType
                End If
            Case PlanQueries.bSalesForcastType
                nextQuery = PlanQueries.bInterestRate
                'nextQuery = PlanQueries.bPersonalBurden
                'Case PlanQueries.bPersonalBurden
                'nextQuery = PlanQueries.bInterestRate
            Case PlanQueries.bInterestRate
                nextQuery = PlanQueries.bNonPayrollExpense
                'nextQuery = PlanQueries.bTaxRate
                'Case PlanQueries.bTaxRate
                'nextQuery = PlanQueries.bNonPayrollExpense
            Case PlanQueries.bNonPayrollExpense
                nextQuery = PlanQueries.bPaymentDays
            Case PlanQueries.bPaymentDays
                nextQuery = PlanQueries.bStartupOrOngoing
            Case PlanQueries.bStartupOrOngoing
                nextQuery = PlanQueries.bCurrency
            Case PlanQueries.bCurrency
                nextQuery = PlanQueries.bPlanStartDate
            Case PlanQueries.bPlanStartDate
                nextQuery = PlanQueries.bPlanTitle
            Case PlanQueries.bPlanTitle
                nextQuery = PlanQueries.bPlanDescription
            Case PlanQueries.bPlanDescription
                If modelState.isNew Then
                    nextQuery = PlanQueries.finish
                Else
                    nextQuery = PlanQueries.bPlanDescription
                End If




            Case PlanQueries.finish
                nextQuery = PlanQueries.finish
        End Select

        Return nextQuery

    End Function

    Private Function NavigateBackward(ByVal qResponse As IPlanWizardResponse) As PlanQueries

        Dim nextQuery As PlanQueries

        Select Case qResponse.ViewID
            Case PlanQueries.start
                nextQuery = PlanQueries.start
            Case PlanQueries.basicAdvanced
                nextQuery = PlanQueries.start

                'For Advanced Wizard

            Case PlanQueries.businessType
                If modelState.isNew Then
                    nextQuery = PlanQueries.basicAdvanced
                Else
                    nextQuery = PlanQueries.basicAdvanced
                End If

                'change 
                'Case PlanQueries.Currency
                '    nextQuery = PlanQueries.businessType
                'change 

            Case PlanQueries.manageInventory
                nextQuery = PlanQueries.businessType
            Case PlanQueries.inventoryTurnover
                nextQuery = PlanQueries.manageInventory
            Case PlanQueries.sellOnCredit
                If businessPlan.ManageInventory = False Then
                    nextQuery = PlanQueries.manageInventory
                ElseIf businessPlan.ManageInventory = True Then
                    nextQuery = PlanQueries.inventoryTurnover
                End If
            Case PlanQueries.salesOnCredit
                nextQuery = PlanQueries.sellOnCredit
            Case PlanQueries.collectionDays
                nextQuery = PlanQueries.salesOnCredit
            Case PlanQueries.salesForcastType
                If businessPlan.SellOnCredit = False Then
                    nextQuery = PlanQueries.sellOnCredit
                ElseIf businessPlan.SellOnCredit = True Then
                    nextQuery = PlanQueries.collectionDays
                End If
            Case PlanQueries.categorizedExpense
                If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                    If businessPlan.SellOnCredit = False Then
                        nextQuery = PlanQueries.sellOnCredit
                    ElseIf businessPlan.SellOnCredit = True Then
                        nextQuery = PlanQueries.collectionDays
                    End If
                Else
                    nextQuery = PlanQueries.salesForcastType
                End If
            Case PlanQueries.personalBurden
                nextQuery = PlanQueries.categorizedExpense
            Case PlanQueries.shortTermInterestRate
                nextQuery = PlanQueries.personalBurden
            Case PlanQueries.longTermInterestRate
                nextQuery = PlanQueries.shortTermInterestRate
            Case PlanQueries.taxRate
                nextQuery = PlanQueries.longTermInterestRate
            Case PlanQueries.nonPayrollExpense
                nextQuery = PlanQueries.taxRate
            Case PlanQueries.paymentDays
                nextQuery = PlanQueries.nonPayrollExpense
            Case PlanQueries.startupOrOngoing
                nextQuery = PlanQueries.paymentDays
            Case PlanQueries.Currency
                nextQuery = PlanQueries.startupOrOngoing
            Case PlanQueries.planStartDate
                nextQuery = PlanQueries.Currency
            Case PlanQueries.planTitle
                nextQuery = PlanQueries.planStartDate

            Case PlanQueries.planDescription
                nextQuery = PlanQueries.planTitle






                'For Basic Wizard
                'Case PlanQueries.bPlanParticulars
                '    If modelState.isNew Then
                '        nextQuery = PlanQueries.basicAdvanced
                '    Else
                '        nextQuery = PlanQueries.bPlanParticulars
                '    End If
            Case PlanQueries.bBusinessType
                If modelState.isNew Then
                    nextQuery = PlanQueries.basicAdvanced
                Else
                    nextQuery = PlanQueries.basicAdvanced
                End If
            Case PlanQueries.bManageInventory
                nextQuery = PlanQueries.bBusinessType
            Case PlanQueries.bInventoryTurnover
                nextQuery = PlanQueries.bManageInventory
            Case PlanQueries.bSellOnCredit
                If businessPlan.ManageInventory = False Then
                    nextQuery = PlanQueries.bManageInventory
                ElseIf businessPlan.ManageInventory = True Then
                    nextQuery = PlanQueries.bInventoryTurnover
                End If
            Case PlanQueries.bSalesOnCredit
                nextQuery = PlanQueries.bSellOnCredit
            Case PlanQueries.bCollectionDays
                nextQuery = PlanQueries.bSalesOnCredit
            Case PlanQueries.bSalesForcastType
                If businessPlan.SellOnCredit = False Then
                    nextQuery = PlanQueries.bSellOnCredit
                ElseIf businessPlan.SellOnCredit = True Then
                    nextQuery = PlanQueries.bCollectionDays
                End If
                'Case PlanQueries.bPersonalBurden
                '    If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                '        If businessPlan.SellOnCredit = False Then
                '            nextQuery = PlanQueries.bSellOnCredit
                '        ElseIf businessPlan.SellOnCredit = True Then
                '            nextQuery = PlanQueries.bCollectionDays
                '        End If
                '    Else
                '        nextQuery = PlanQueries.bSalesForcastType
                '    End If
            Case PlanQueries.bInterestRate
                If businessPlan.BusinessGoods = BusinessGoodsType.Services Then
                    If businessPlan.SellOnCredit = False Then
                        nextQuery = PlanQueries.bSellOnCredit
                    ElseIf businessPlan.SellOnCredit = True Then
                        nextQuery = PlanQueries.bCollectionDays
                    End If
                Else
                    nextQuery = PlanQueries.bSalesForcastType
                End If
                'nextQuery = PlanQueries.bPersonalBurden
                'Case PlanQueries.bTaxRate
                'nextQuery = PlanQueries.bInterestRate
            Case PlanQueries.bNonPayrollExpense
                nextQuery = PlanQueries.bInterestRate
                'nextQuery = PlanQueries.bTaxRate
            Case PlanQueries.bPaymentDays
                nextQuery = PlanQueries.bNonPayrollExpense
            Case PlanQueries.bStartupOrOngoing
                nextQuery = PlanQueries.bPaymentDays
            Case PlanQueries.bCurrency
                nextQuery = PlanQueries.bStartupOrOngoing
            Case PlanQueries.bPlanStartDate
                nextQuery = PlanQueries.bCurrency
            Case PlanQueries.bPlanTitle
                nextQuery = PlanQueries.bPlanStartDate
            Case PlanQueries.bPlanDescription
                nextQuery = PlanQueries.bPlanTitle



            Case PlanQueries.finish
                If modelState.isNew Then
                    If modelState.isBasic Then
                        nextQuery = PlanQueries.bPlanDescription
                    Else
                        nextQuery = PlanQueries.planDescription
                    End If
                Else
                    nextQuery = PlanQueries.planDescription
                End If
        End Select

        Return nextQuery

    End Function

#End Region

#Region "Private helper functions"

    Private Function GetMonthName(ByVal month As Integer) As String

        Select Case month
            Case 1
                Return "January"
            Case 2
                Return "February"
            Case 3
                Return "March"
            Case 4
                Return "April"
            Case 5
                Return "May"
            Case 6
                Return "June"
            Case 7
                Return "July"
            Case 8
                Return "August"
            Case 9
                Return "September"
            Case 10
                Return "October"
            Case 11
                Return "November"
            Case 12
                Return "December"
        End Select

    End Function

    Private Function GetMonthNumber(ByVal month As String) As Integer

        Select Case month
            Case "January"
                Return 1
            Case "February"
                Return 2
            Case "March"
                Return 3
            Case "April"
                Return 4
            Case "May"
                Return 5
            Case "June"
                Return 6
            Case "July"
                Return 7
            Case "August"
                Return 8
            Case "September"
                Return 9
            Case "October"
                Return 10
            Case "November"
                Return 11
            Case "December"
                Return 12
        End Select

    End Function

    Private Function IfDBNull(ByVal dbValue As Object, ByVal replacement As Object) As Object
        If IsDBNull(dbValue) Then
            Return replacement
        Else
            Return dbValue
        End If
    End Function

#End Region

End Class

