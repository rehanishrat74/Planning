Public Class Help
    Public Shared PlanWizard As String
    Public Shared FinancialData As String
    Public Shared GeneralAssumption As String
    Public Shared Payroll As String
    Public Shared PlanSummary As String
    Public Shared IncomeStatement As String
    Public Shared BalanceSheet As String
    Public Shared CashFlow As String
    Public Shared Milestone As String
    Public Shared MarketAnalysis As String
    Public Shared IndustryPerformance As String
    Public Shared PastPerformanceWizard As String
    Public Shared PastPerformance As String
    Public Shared StartupWizard As String
    Public Shared Startup As String
    Public Shared BreakEven As String
    Public Shared SalesForecast As String
    Public Shared Charts As String
    Public Shared Ratios As String

    Public Sub New()
        'Write respective help text here 
        PlanWizard = "PlanWizard"
        FinancialData = "FinancialData"
        GeneralAssumption = "Infini Business Plan completes this Table automatically, based on the numbers you provided in the Plan Wizard. You can use the Plan Summary  or this table to change the fields at any time."
        Payroll = "The structure of this table depends on a choice you made with the Business Plan Wizard, when you started this plan. If you chose to divide expenses into categories, then you'll have a more detailed personnel plan that divides your people into four types. If not, then you have a simple list of either people by name, position, or departments. In both cases, you can insert rows and delete rows as you need to, and of course change the labels using the Edit Row Label command on the Edit menu. "
        PlanSummary = "This table gives you the General Values of Business. On basis of these values Infini Business Plan Decides and evaluates other table Values"
        IncomeStatement = "This  Income statement is also called profit and loss statement, or Pro Forma Income ('pro forma' is an accounting term for projected). It has protected areas because it gets its numbers for sales, cost of sales, personnel costs, interest, and taxes from other tables. You can 't type into those rows because that information is created by other tables. "
        BalanceSheet = "The balance sheet presents a picture of your financial position on some specified day, usually the end of the month or the end of the year. Your financial position is your assets, liabilities, and capital. Liabilities are the same as debts, and capital is the same as equity. This is called balance because of the rule that capital is equal to assets less liabilities. "
        CashFlow = "This is cash flow, the most important table in your plan. Profits alone don't guarantee cash, and even profitable companies go under when they can't pay their bills, so this analysis is critical to your success. "
        Milestone = "This table is focused on implementation. Use it to list the specific activities that are the core of your plan. In your planning and implementation chapter, in the standard outline, you have topics for discussing marketing programs and sales programs. Each program should be on this list, with its name, person responsible, department, budget, and deadline date. As your plan gets going, fill in the actual spending and date of completion, and you'll automatically see (in the far right columns) the plan-vs.-actual analysis for completion dates and budget. "
        MarketAnalysis = "The market analysis focus on potential customers, not actual customers." & _
                        "Once you understand the idea of potential customers, then your problem is information gathering and making estimates."
        IndustryPerformance = "This table gives you the ratios/values of Industry"
        PastPerformanceWizard = "This Wizard ask you about some OnGoing Business Values. On Basis of these values Infini Business Plan forecast the values of Other tables"
        PastPerformance = "The structure of this table depends on a choice you made with the Business Plan Wizard, when you started this plan. If you chose to divide expenses into categories, then you'll have a more detailed personnel plan that divides your people into four types. If not, then you have a simple list of either people by name, position, or departments. In both cases, you can insert rows and delete rows as you need to, and of course change the labels using the Edit Row Label command on the Edit menu. "
        StartupWizard = "This Wizard ask you about some Startup Business Values. On Basis of these values Infini Business Plan forecast the values of Other tables"
        Startup = "This table helps you estimate start-up costs, and loads your starting balances into the balance sheet. It sometimes generates questions about the loss at start-up and the left to finance rows. "
        BreakEven = "This Table gives you the details of break-even analysis. Technically, a break-even analysis defines the Estimated Monthly Fixed Cost as costs that would continue even if you went broke. Instead, you may want to use your regular running fixed costs, including payroll and normal expenses. This will give you a better picture of financial realities."
        SalesForecast = "The structure of this table depends on a choice you made with the Plan Wizard. If you chose to forecast by value only, then you have a simpler forecast with one group of rows for sales and another group for cost of sales. Otherwise, you have five groups of matching rows: a first group of rows for unit sales, then a group for price per unit, then a group for sales(multiplying units times price), then one for unit costs, then one for cost of sales (multiplying units times cost). "
        Charts = "You can view Charts of different categories."
        Ratios = "The Ratios table describes the Financial ratios like Current Ratio, Sales Growth etc."
    End Sub



End Class
