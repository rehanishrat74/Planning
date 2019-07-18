#Region "Imports"
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
#End Region

Public Class GatewayRegistration
#Region "Constructors and Declarations"

    Public Sub New()
        'DAL.SqlHelper.ConnectionString = DAL.Connection.GetConnectionString
    End Sub
#End Region

    Public Function UpdateGatewayPIN(ByVal CustomerID As Integer, ByVal CTRPINCode As String, ByVal PAYEPINCode As String) As DataTable
        Dim sqlParams() As SqlParameter
        sqlParams = New SqlParameter(2) {}

        sqlParams(0) = New SqlParameter("@UserID", SqlDbType.VarChar, 10)
        sqlParams(0).Value = CustomerID

        sqlParams(1) = New SqlParameter("@CTRPINCode", SqlDbType.VarChar, 25)
        sqlParams(1).Value = CTRPINCode
        sqlParams(2) = New SqlParameter("@PAYEPINCode", SqlDbType.VarChar, 25)
        sqlParams(2).Value = PAYEPINCode

        Return DAL.SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "DBSERVER.infiniShopMainDB.dbo.ACC_GatewyeRegistration", sqlParams).Tables(0)
    End Function

    Public Function IsGetGatewayPinActivated(ByVal CustomerID As Integer) As Boolean

        Dim cmd As New CommandData
        Dim sqlDR As SqlDataReader
        Dim isGatewayActivated As Boolean = False

        With cmd
            Try
                .CmdText = "DBServer.InfinishopMainDb.dbo.ACC_GetGatewayPIN"
                .AddParameter("@CustomerID", CustomerID)
                sqlDR = .Execute(ExecutionType.ExecuteReader)

                With sqlDR
                    While .Read
                        isGatewayActivated = IIf(IsDBNull(.Item("CTRPINCode")) OrElse .Item("CTRPINCode") = "", False, True)

                        If .Item("IsPayroll") Then
                            isGatewayActivated = IIf(IsDBNull(.Item("PAYEPinCode")) OrElse .Item("PAYEPinCode") = "", False, True)
                        End If
                    End While
                End With

            Catch ex As Exception
            Finally
                If Not sqlDR.IsClosed Then
                    sqlDR.Close()
                End If

                .CloseConnection()
            End Try
        End With

        Return isGatewayActivated
    End Function

    Public Function GetGatewayPIN(ByVal CustomerID As Integer) As SqlDataReader
        Dim cmd As New CommandData
        Dim sqlDR As SqlDataReader

        With cmd
            Try
                .CmdText = "DBServer.InfinishopMainDb.dbo.ACC_GetGatewayPIN"
                .AddParameter("@CustomerID", CustomerID)
                sqlDR = .Execute(ExecutionType.ExecuteReader)

            Catch ex As Exception
                If Not sqlDR.IsClosed Then
                    sqlDR.Close()
                End If

                .CloseConnection()
            End Try
        End With

        Return sqlDR
    End Function
End Class
