Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL

Public Interface IAccountsCentreBase
    ReadOnly Property DatabaseName() As String
    ReadOnly Property DataSource() As String
    ReadOnly Property CustomerID() As Integer
    ReadOnly Property ServiceName() As String
    ReadOnly Property IsServiceAllowed(ByVal serviceName As String) As Boolean
    ReadOnly Property GetConnectionData() As ConnectionData

    Property IsCustomer() As Boolean

    Property ErrorMeassage() As String
    Property InfoMessage() As String

    Sub CheckService(ByVal serviceid As ServiceID)

    Function SignInAccountsCentreUSer(ByVal strUserID As String, ByVal strPassword As String) As String

End Interface

Public Enum ServiceID
    Express = 1
    Payroll = 2
    CTReturn = 3
    AccountManagement = 5
    InfiniShops = 6
    SAccounts = 7
    AccountsPro = 8
End Enum