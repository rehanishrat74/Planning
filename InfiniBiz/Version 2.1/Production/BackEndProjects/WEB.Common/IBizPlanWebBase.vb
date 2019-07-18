Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL
Public Interface IBizPlanWebBase

    ReadOnly Property Navigator() As String()
    Function GetCustomerName() As String
    ReadOnly Property GetConnectionData() As ConnectionData
    ReadOnly Property IsPlanOpened() As Boolean
    ReadOnly Property CurrentPlan() As Infinilogic.BusinessPlan.BLL.BusinessPlan
    WriteOnly Property BusinessPlanSummary() As Infinilogic.BusinessPlan.BLL.BusinessPlan

        Property ProductName() As String
    
    WriteOnly Property SetProWebCustomer() As Boolean
    ReadOnly Property GetProWebCustomer() As Boolean
    Property CurrentTableid() As String
    Property CurrentRow() As Integer
    WriteOnly Property SetCustomerCurrency() As String
    ReadOnly Property GetCustomerCurrency() As String

End Interface

 
