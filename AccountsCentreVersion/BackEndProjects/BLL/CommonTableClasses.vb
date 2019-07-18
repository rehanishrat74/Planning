' Modified by - Win-saira 

Public Class ChangedCell
    Public Row As Integer
    Public Column As Integer
    Public Value As String
    Public Sub New(ByVal Row As Integer, ByVal Column As Integer, ByVal Value As String)
        Me.Row = Row
        Me.Column = Column
        Me.Value = Value
    End Sub
End Class
Public Class CellValue
    Public CategoryID As String
    Public Value As String
    Public Sub New(ByVal CategoryID As String, ByVal Value As String)
        Me.CategoryID = CategoryID
        Me.Value = Value
    End Sub
End Class
Public Class PeriodicCellValue
    Inherits CellValue
    Public PeriodID As String
    Public Sub New(ByVal PeriodID As String, ByVal CategoryID As String, ByVal Value As String)
        MyBase.New(CategoryID, Value)
        Me.PeriodID = PeriodID
    End Sub
End Class

#Region "Startup "

Public Class StartupCategory

    Public CategoryID As String
    Public CategoryName As String
    Public CategoryTotal As Single

End Class

Public Class StartupTable
    Public CashRequirement As Single
    Public StartupInventory As Single
    Public OtherShortTermAssets As Single
    Public LongTermAssets As Single
    Public UnpaidExpenses As Single
    Public ShortTermLoan As Single
    Public InterestFreeShortTermLiabilities As Single
    Public LongTermLiabilities As Single
    Public TotalInvestment As Single
End Class

#End Region

#Region " MarketAnalysisCell"

Public Class MarketAnalysisCell
    ' Modified by Saira 
    ' Date - 9/3/2006

    ' This is Potential Customer Name 
    Public CellTitle As String
    ' This is Analysis Year 
    Public CellYear As String
    ' This is Analysis Value 
    Public AnalysisValue As Single
    Public PCID As String
    Public CellBizID As String
    Public GrowthRate As Single
End Class

#End Region

#Region "PastPerformance "

Public Class PastPerformanceCell
    Public CellBizID As Integer
    Public AccountID As String
    Public AccountName As String
    Public AccountParentID As String
    Public PerformanceYear As Integer
    Public PerformanceValue As Integer

End Class

Public Class PastPerformanceCategory

    Public CategoryName As String
    Public CategoryID As Integer
    Public CategoryTotal As Integer

End Class

Public Class PastperformanceTable
    Public Year As Integer
    Public Sales As Single
    Public GrossMargin As Single
    Public CollectionPeriod As Integer
    Public InventoryTurnOver As Single
    Public OperatingExpenses As Single
    Public Cash As Single
    Public AccountsReceiveable As Single
    Public Inventory As Single
    Public OtherShortTermAssets As Single
    Public CapitalAssets As Single
    Public AccumulatedDepreciation As Single
    Public ShortTermNotes As Single
    Public OtherShortTermLiabilities As Single
    Public AccountsPayable As Single
    Public LongTermLiabilities As Single
    Public PaidInCapital As Single
    Public RetainedEarning As Single
    Public Earning As Single
    Public PaymentDays As Integer
    Public SalesOnCreditPercent As Single

End Class

#End Region

#Region "Milestones"

Public Class Milestone
    Public BizID As String
    Public MilestoneNo As String
    Public MilestoneName As String
    Public PlanStartDate As DateTime
    Public PlanEndDate As DateTime
    Public Budget As Double
    Public Manager As String
    Public Department As String
End Class

#End Region

#Region "BreakEven"

Public Class BreakEvenValues
    Public BreakEvenId As String

    Public PlanID As String
    Public APURevenue As Single     ' Average Per Unit Revenue 
    Public APUVariableCost As Single ' Average Per Unit Variable Cost 
    Public EstMonthlyFixCost As Single ' Estimated Monthly Fix Cost 

End Class

#End Region

#Region "...........Export Options Class "
Public Class ExportPlanOptions
    Public FileName As String = "Untitled"
    Public MimeType As String
    Public FileExtension As String = ".rtf"
    Public IncludeTables As Boolean
    Public IncludeCharts As Boolean
End Class
#End Region
