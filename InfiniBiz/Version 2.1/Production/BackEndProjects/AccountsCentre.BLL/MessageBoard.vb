Imports System.Data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Public NotInheritable Class MessageBoard
    Public Shared Function GetInbox(ByVal mUserID As Object) As Object
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim sqlStr As String = "select * ,isnull((select [name] from " & SqlHelper.InfiniMainDB & "Customer where customer_id=M.userid),'ADMIN') as sendername from " & SqlHelper.InfiniMainDB & "messages M where (mStatus='N' OR mStatus='R') and (parentid=0) and (useridto='" & mUserID & "' OR userid='" & mUserID & "') order by datetime desc"
        ''SqlHelper.ConnectionString = Connection.GetConnectionString
        GetInbox = SqlHelper.ExecuteDataset(0, CommandType.Text, sqlStr)
    End Function

    Public Shared Function GetTrashbox(ByVal mUserID As Object) As Object
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim sqlStr As String = "select * ,isnull((select [name] from " & SqlHelper.InfiniMainDB & "customer where cart_customer_uid=M.userid),'ADMIN') as sendername from " & SqlHelper.InfiniMainDB & "messages M where mStatus='D' and useridto='" & mUserID & "' order by datetime desc"
        ''SqlHelper.ConnectionString = Connection.GetConnectionString
        GetTrashbox = SqlHelper.ExecuteDataset(0, CommandType.Text, sqlStr)
    End Function
    Public Shared Function GetSentbox(ByVal mUserID As Object) As Object
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim sqlStr As String = "select * ,'ADMIN' as sendername from " & SqlHelper.InfiniMainDB & "Sentmessages M where userid='" & mUserID & "' order by datetime desc"
        ''SqlHelper.ConnectionString = Connection.GetConnectionString
        GetSentbox = SqlHelper.ExecuteDataset(0, CommandType.Text, sqlStr)       '
    End Function

    Public Shared Function GetInboxMessage(ByVal msgid As Object) As DataSet
        Dim _cDataset As DataSet
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT * ,isnull((select [name] from " & SqlHelper.InfiniMainDB & "Customer where customer_id=M.userid),(select [name] from " & SqlHelper.InfiniMainDB & "AccountsCentreAdminUsers where userid=M.userid)) as sendername from " & SqlHelper.InfiniMainDB & "Messages M Where (msgid=" & msgid & " or parentid=" & msgid & ");update " & SqlHelper.InfiniMainDB & "Messages set mStatus='R' where (msgid=" & msgid & " or parentid=" & msgid & ")"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        _cDataset = SqlHelper.ExecuteDataset(0, CommandType.Text, SqlStr)
        Return _cDataset
    End Function
    Public Shared Function GetSentboxMessage(ByVal msgid As Object) As DataSet
        Dim _cDataset As DataSet
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT *, isnull((select [name] from " & SqlHelper.InfiniMainDB & "Customer where customer_id=M.userid),(select [name] from " & SqlHelper.InfiniMainDB & "AccountsCentreAdminUsers where userid=M.userid)) as sendername from " & SqlHelper.InfiniMainDB & "SentMessages M Where msgid=" & msgid
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        _cDataset = SqlHelper.ExecuteDataset(0, CommandType.Text, SqlStr)
        Return _cDataset
    End Function
    Public Shared Function GetMessageCount(ByVal mUserID As Object) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "select top 1 (select count(*) from " & SqlHelper.InfiniMainDB & "messages where useridto='" & mUserID & "' and mStatus='N') as unread ,(select count(*) from " & SqlHelper.InfiniMainDB & "messages where useridto='" & mUserID & "') as total from " & SqlHelper.InfiniMainDB & "messages"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        Return datareader
        'datareader.Close()
    End Function
    Public Shared Function GetNotification(ByVal UserId As Object) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT top 1  * from " & SqlHelper.InfiniMainDB & "AccountscentreNotifications Where userid=" & UserId & " order by [date] desc "
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        'datareader.Read()
        GetNotification = datareader
    End Function
    Public Shared Function GetNotifications(ByVal mUserID As Object) As Object
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim sqlStr As String = "select * from " & SqlHelper.InfiniMainDB & "AccountscentreNotifications where userid=" & mUserID & " order by [date] desc"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        GetNotifications = SqlHelper.ExecuteDataset(0, CommandType.Text, sqlStr)
    End Function
    Public Shared Sub DeleteInboxMessages(ByVal msgs As Object)
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "update " & SqlHelper.InfiniMainDB & "messages set mStatus='D' where msgid in (" & msgs & "0)"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        SqlHelper.ExecuteNonQuery(0, CommandType.Text, SqlStr)
    End Sub
    Public Shared Sub DeleteSentboxMessages(ByVal msgs As Object)
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "delete " & SqlHelper.InfiniMainDB & "Sentmessages where msgid in (" & msgs & "0)"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        SqlHelper.ExecuteNonQuery(0, CommandType.Text, SqlStr)
    End Sub
    Public Shared Sub DeleteTrashboxMessages(ByVal msgs As Object)
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "delete " & SqlHelper.InfiniMainDB & "messages where msgid in (" & msgs & "0)"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        SqlHelper.ExecuteNonQuery(0, CommandType.Text, SqlStr)
    End Sub
    Public Shared Sub RestoreMessages(ByVal msgs As Object)
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "update " & SqlHelper.InfiniMainDB & "messages set mStatus='N' where msgid in (" & msgs & "0)"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        SqlHelper.ExecuteNonQuery(0, CommandType.Text, SqlStr)


    End Sub
    Public Shared Sub PostInboxMessage(ByVal userIDfrom, ByVal userIDto, ByVal Service, ByVal subject, ByVal message, ByVal parentid)
        Dim arParams() As SqlParameter = New SqlParameter(7) {}
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        arParams(0) = New SqlParameter("@userid", userIDfrom)
        arParams(1) = New SqlParameter("@useridto", userIDto)
        arParams(2) = New SqlParameter("@service", Service)
        arParams(3) = New SqlParameter("@mDate", Date.Now)
        arParams(4) = New SqlParameter("@subject", subject)
        arParams(5) = New SqlParameter("@message", message)
        arParams(6) = New SqlParameter("@parentid", parentid)
        arParams(7) = New SqlParameter("@isNewMessage", "y")
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "POSTNEWMESSAGE", arParams)
    End Sub
    Public Shared Sub PostSentboxMessage(ByVal userIDfrom, ByVal userIDto, ByVal Service, ByVal subject, ByVal message)
        Dim arParams() As SqlParameter = New SqlParameter(5) {}
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        arParams(0) = New SqlParameter("@userid", userIDfrom)
        arParams(1) = New SqlParameter("@useridto", userIDto)
        arParams(2) = New SqlParameter("@service", Service)
        arParams(3) = New SqlParameter("@mDate", Date.Now)
        arParams(4) = New SqlParameter("@subject", subject)
        arParams(5) = New SqlParameter("@message", message)
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, SqlHelper.InfiniMainDB & "POSTSENTMESSAGE", arParams)
    End Sub

    Public Shared Function GetNewsletterList() As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT id,[date] from " & SqlHelper.InfiniMainDB & "AccountscentreNewsletters order by [date] desc"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        'datareader.Read()
        GetNewsletterList = datareader
    End Function
    Public Shared Function GetNewsletter(ByVal Id As Object) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT * from " & SqlHelper.InfiniMainDB & "AccountscentreNewsletters where Id=" & Id
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        'datareader.Read()
        GetNewsletter = datareader
    End Function
    Public Shared Function GetTaxUpdatesList() As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT id,[date] from " & SqlHelper.InfiniMainDB & "AccountscentreTaxUpdates order by [date] desc"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        'datareader.Read()
        GetTaxUpdatesList = datareader
    End Function
    Public Shared Function GetTaxUpdate(ByVal Id As Object) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT * from " & SqlHelper.InfiniMainDB & "AccountscentreTaxUpdates where Id=" & Id
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        'datareader.Read()
        GetTaxUpdate = datareader
    End Function
    Public Shared Function GetSystemParameter(ByVal Para As Object) As Object
        Dim datareader As SqlDataReader
        SqlHelper.InfiniMainDB = "DBSERVER.InfinishopMainDB.dbo."
        Dim SqlStr As String = "SELECT * from " & SqlHelper.InfiniMainDB & "AccountscentreParameters where paraid='" & Para & "'"
        'SqlHelper.ConnectionString = Connection.GetConnectionString
        datareader = SqlHelper.ExecuteReader(0, CommandType.Text, SqlStr)
        If datareader.Read() Then
            GetSystemParameter = datareader("Paravalue")
        Else
            GetSystemParameter = ""
        End If
        datareader.Close()
    End Function

    Public Shared Function GetMessageDetails(ByVal mid As String) As DataSet
        Dim objDataSet As New DataSet
        Dim sqlParam() As SqlParameter = New SqlParameter(0) {}
        'SqlHelper.ConnectionString = Connection.GetConnectionString("DBGateway")
        sqlParam(0) = New SqlParameter("@mid", SqlDbType.NVarChar, 50)
        sqlParam(0).Value = mid
        objDataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "MSG_GetMessageDetails", sqlParam)
        Return objDataSet
    End Function

    Public Shared Function GetAdministratorList() As DataSet
        Dim objDataSet As New DataSet
        objDataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "MSG_GetAdministratorList")
        Return objDataSet
    End Function

    Public Shared Function GetInboxMessages(ByVal mid As String) As DataSet
        Dim objDataSet As New DataSet
        Dim sqlParam() As SqlParameter = New SqlParameter(0) {}
        'SqlHelper.ConnectionString = Connection.GetConnectionString("DBGateway")
        sqlParam(0) = New SqlParameter("@mid", SqlDbType.NVarChar, 50)
        sqlParam(0).Value = mid
        objDataSet = SqlHelper.ExecuteDataset(0, CommandType.StoredProcedure, "MSG_GetInboxMessage", sqlParam)
        Return objDataSet
    End Function
    Public Shared Function ChangeStatus(ByVal msgid As Integer) As String
        Dim objDataset As New DataSet
        Dim sqlParam() As SqlParameter = New SqlParameter(0) {}
        'SqlHelper.ConnectionString = Connection.GetConnectionString("DBGateway")
        sqlParam(0) = New SqlParameter("@msgid", SqlDbType.NVarChar, 50)
        sqlParam(0).Value = msgid
        SqlHelper.ExecuteNonQuery(0, CommandType.StoredProcedure, "MSG_ChangeStatus", sqlParam)
        Return "Record Successfully Updated....."
    End Function
End Class
