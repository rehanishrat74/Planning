Imports InfiniLogic.AccountsCentre.DAL
Imports System.Data.SqlClient

Public Class SubscriptionStatus
    'This Class checks the Subscription of Customers
    'that wether the Customer is allowed to use or not and
    'should it renew its subscription with in 3 months
#Region "Declarations"
    'Allowable Service Status
    Public Enum CustSrvStatusBehavior
        AllCustomers = 0
        Last3MonthsPeriod = 1
        OverDueDate = 2
        Last3MonthsPeriodAndOverDueDate = 3
    End Enum
    'Allowable Stored Procedure Mode
    Public Enum CustSrvMode
        CustomersWithSomeStatus = 0
        DistinctCustomers = 1
        CustomersCount = 2
    End Enum
#End Region

#Region "Constructor"
    Public Sub New()
        'SqlHelper.ConnectionString = Connection.GetConnectionString()
    End Sub
#End Region

#Region "Procedures"

    Public Function getServicesHashTableByStatus(ByVal eServiceStatus As CustSrvStatusBehavior, ByVal iCustomerID As Integer) As Hashtable
        Dim HtServiceNamesAndId As New Hashtable
        Dim DrCustomerStatus As SqlDataReader

        DrCustomerStatus = getCustomerServiceStatusByIDDataReader(eServiceStatus, iCustomerID)
        While DrCustomerStatus.Read
            HtServiceNamesAndId.Add(DrCustomerStatus("ServiceID"), DrCustomerStatus("Service"))
        End While


        If Not DrCustomerStatus Is Nothing Then
            DrCustomerStatus.Close()
            DrCustomerStatus = Nothing
        End If

        'returning the ArrayList of String values 
        Return HtServiceNamesAndId
    End Function
    Public Shared Function GetProperServiceMapping(ByVal sServiceName As String) As String
        If UCase(sServiceName).Equals("COLLECTION SERVICES") = True Then
            GetProperServiceMapping = "CAM"
        ElseIf UCase(sServiceName).Equals("CAM") = True Then
            GetProperServiceMapping = "COLLECTION SERVICES"
        Else
            GetProperServiceMapping = sServiceName
        End If
    End Function

    'It is used to disable service only for the customer to whom it has expired
    Public Sub updateCustSelSrvStatusIfAnySrvExpired(ByVal iCustomerID As Integer)
        Dim DtCustomerExpiredServices As DataTable
        Dim DrDataRow As DataRow
        Dim prmCustSrvStatus() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}

        DtCustomerExpiredServices = getCustomerServiceStatusByID(CustSrvStatusBehavior.OverDueDate, iCustomerID)

        'Customer ID
        prmCustSrvStatus(0) = New SqlClient.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        prmCustSrvStatus(0).Direction = ParameterDirection.Input
        prmCustSrvStatus(0).Value = iCustomerID


        For Each DrDataRow In DtCustomerExpiredServices.Rows
            'Service ID
            prmCustSrvStatus(1) = New SqlClient.SqlParameter("@iServiceID", SqlDbType.Int)
            prmCustSrvStatus(1).Direction = ParameterDirection.Input
            prmCustSrvStatus(1).Value = DrDataRow("ServiceID")

            SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "DBGateway.dbo.Admin_UpdateCustomerSelectedServicesStatus", prmCustSrvStatus)
        Next
        prmCustSrvStatus = Nothing
    End Sub

    'Given a valid Customer ID and Staus of Subscription that must be one from the enum "CustSrvStatusBehavior" defined above, it returns the DataTable
    'having details of that Service and its Status
    Public Function getCustomerServiceStatusByID(ByVal eCustSrvStatusBehavior As CustSrvStatusBehavior, ByVal iCustomerID As Integer) As DataTable
        Dim prmCustSrvStatus() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        'Service Status
        prmCustSrvStatus(0) = New SqlClient.SqlParameter("@tiStatus", SqlDbType.TinyInt)
        prmCustSrvStatus(0).Direction = ParameterDirection.Input
        prmCustSrvStatus(0).Value = eCustSrvStatusBehavior
        'Customer ID
        prmCustSrvStatus(1) = New SqlClient.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        prmCustSrvStatus(1).Direction = ParameterDirection.Input
        prmCustSrvStatus(1).Value = iCustomerID

        getCustomerServiceStatusByID = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBGateway.dbo.Admin_GetCustomerServiceStatus", prmCustSrvStatus).Tables(0)
        prmCustSrvStatus = Nothing
    End Function
    Public Function getCustomerServiceStatusByIDDataReader(ByVal eCustSrvStatusBehavior As CustSrvStatusBehavior, ByVal iCustomerID As Integer) As SqlDataReader
        Dim prmCustSrvStatus() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
        'Service Status
        prmCustSrvStatus(0) = New SqlClient.SqlParameter("@tiStatus", SqlDbType.TinyInt)
        prmCustSrvStatus(0).Direction = ParameterDirection.Input
        prmCustSrvStatus(0).Value = eCustSrvStatusBehavior
        'Customer ID
        prmCustSrvStatus(1) = New SqlClient.SqlParameter("@nCustomerID", SqlDbType.BigInt)
        prmCustSrvStatus(1).Direction = ParameterDirection.Input
        prmCustSrvStatus(1).Value = iCustomerID

        getCustomerServiceStatusByIDDataReader = SqlHelper.ExecuteReader(0, CommandType.StoredProcedure, "DBGateway.dbo.Admin_GetCustomerServiceStatus", prmCustSrvStatus)
        prmCustSrvStatus = Nothing
    End Function

#End Region
End Class

