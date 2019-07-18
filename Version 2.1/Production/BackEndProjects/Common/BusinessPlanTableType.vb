

Public Enum BusinessPlanTableType As Integer

    ' PlanSummary
    GeneralAssumption
    ' Here in b/w , One of the following enumeration will come 
    BreakEvenAnalysis
    MarketAnalysis
    Payroll
    SalesForecast
    Expenses
    Milestones
    IncomeStatement
    CashFlow
    BalanceSheet
    Ratios
    'Test
End Enum

Public Enum OngoingTableType
    ' PlanSummary
    GeneralAssumption
    PastPerformance
    BreakEvenAnalysis
    MarketAnalysis
    Payroll
    SalesForecast
    Expenses
    Milestones
    IncomeStatement
    CashFlow
    BalanceSheet
    Ratios
    ' IntegratedBalancesheet
    'CashDetails
    'SupportTable
    'LiabilitiesTable
End Enum

Public Enum StartupTableType
    '  PlanSummary
    GeneralAssumption
    StartupDetails
    BreakEvenAnalysis
    MarketAnalysis
    Payroll
    SalesForecast
    Expenses
    Milestones
    IncomeStatement
    CashFlow
    BalanceSheet
    Ratios
    'IntegratedBalancesheet
    'CashDetails
    'SupportTable
    'LiabilitiesTable
End Enum

Public Enum TableStatus

    TEmpty0
    TEmpty1
    TEmpty2
    TEmpty3
    TEmpty4
    SalesForecast  ' TFill = 5 
    Expenses   ' TFill = 6 
    TEmpty7
    IncomeStatement  ' TFill = 8 
    
    
End Enum