Public Class ConfigReader

    Public Shared CONNECTION_FILE_PATH As String = AppDomain.CurrentDomain.BaseDirectory & "/Data/XML/initLoc.xml"

    ''' GetItem function does not check updation of Initloc.xml File on file System
    ''' So if the InitLoc.xml file is changed then modifications will not be made on user side
    ''' For Updates application must be restarted

    Public Shared Function GetItem(ByVal itemName As ConfigVariables) As String
        Dim strName As String = GettemName(itemName)

        If AppDomain.CurrentDomain.GetData(strName) Is Nothing Then 'OrElse IsConfigFileModififed() Then
            Dim _XMLREad As New pwdsqlsrvdotnet.clspassword
            _XMLREad.xmlfilepath = CONNECTION_FILE_PATH
            AppDomain.CurrentDomain.SetData(strName, _XMLREad.ExPath(strName))
        End If
        Return AppDomain.CurrentDomain.GetData(strName)
    End Function

    Protected Shared Function IsConfigFileModififed() As Boolean
        Dim strConfigFileModifiedDate As String = "ACC_CONFIGFILE_MODIFIED_DATE"

        With AppDomain.CurrentDomain
            If .GetData(strConfigFileModifiedDate) Is Nothing Then
                .SetData(strConfigFileModifiedDate, IO.File.GetLastWriteTime(CONNECTION_FILE_PATH))
                Return True
            Else
                Return .GetData(strConfigFileModifiedDate) = IO.File.GetLastWriteTime(CONNECTION_FILE_PATH)

            End If

        End With
    End Function

    Protected Shared Function GettemName(ByVal ItemName As ConfigVariables) As String
        Return Microsoft.VisualBasic.Switch(ItemName = ConfigVariables.SQLUserID, "SQLUID_DataCentre", _
                                            ItemName = ConfigVariables.SQLPassword, "SQLPWD_DataCentre", _
                                            ItemName = ConfigVariables.SMTPUserID, "SMPTPUSER", _
                                            ItemName = ConfigVariables.SMTPSERVER, "SMTPSERVER", _
                                            ItemName = ConfigVariables.SMTPPassword, "SMPTPPASSWORD", _
                                            ItemName = ConfigVariables.SQLAdminID, "SQLUID_DataCentreAdmin", _
                                            ItemName = ConfigVariables.SQLAdminPassword, "SQLPWD_DataCentreAdmin", _
                                            ItemName = ConfigVariables.SQLAdminMailConfirmation, "ADMINEMAILCONFIRMATION", _
                                            ItemName = ConfigVariables.SMTP_Authentication, "SMPTP_AUTHENTICATION", _
                                            ItemName = ConfigVariables.DataSource, "DATASOURCE", _
                                            ItemName = ConfigVariables.EmailBCC, "EMAIL_BCC", _
                                            ItemName = ConfigVariables.InitialCatalog, "INITIALCATALOG", _
                                            ItemName = ConfigVariables.MySqlUserID, "MySqlUser", _
                                            ItemName = ConfigVariables.MYSQLPassword, "MySqlPwd", _
                                            ItemName = ConfigVariables.MYSQLDB, "MySqlDb", _
                                            ItemName = ConfigVariables.MYSQLServerIP, "MysqlSrv", _
                                            ItemName = ConfigVariables.CXLUserID, "CXLPASSPORTUID", _
                                            ItemName = ConfigVariables.CXLPassword, "CXLPASSPORTPWD", _
                                            ItemName = ConfigVariables.CXLServerIP, "CXLSRV", _
                                            ItemName = ConfigVariables.D, "D", _
                                            ItemName = ConfigVariables.E, "E", _
                                            ItemName = ConfigVariables.N, "N", _
                                            ItemName = ConfigVariables.IO_MySqlUser, "IO_MySqlUser", _
                                            ItemName = ConfigVariables.IO_MySqlPassword, "IO_MySqlPassword", _
                                            ItemName = ConfigVariables.IO_MySqlDatabase, "IO_MySqlDatabase", _
                                            ItemName = ConfigVariables.IO_MySqlServer, "IO_MySqlServer", _
                                            ItemName = ConfigVariables.FH_MySqlUser, "FH_MySqlUser", _
                                            ItemName = ConfigVariables.FH_MySqlPassword, "FH_MySqlPassword", _
                                            ItemName = ConfigVariables.FH_MySqlDatabase, "FH_MySqlDatabase", _
                                            ItemName = ConfigVariables.FH_MySqlServer, "FH_MySqlServer", _
                                            ItemName = ConfigVariables.NAT_MySqlUser, "NAT_MySqlUser", _
                                            ItemName = ConfigVariables.NAT_MySqlPassword, "NAT_MySqlPassword", _
                                            ItemName = ConfigVariables.NAT_MySqlDatabase, "NAT_MySqlDatabase", _
                                            ItemName = ConfigVariables.NAT_MySqlServer, "NAT_MySqlServer", _
                                            ItemName = ConfigVariables.NAT_Server, "NAT_Server", _
                                            ItemName = ConfigVariables.NAT_Port, "NAT_Port")
    End Function


End Class

Public Enum ConfigVariables

    SQLUserID
    SQLPassword
    SQLAdminID
    SQLAdminPassword
    SQLAdminMailConfirmation
    SMTPUserID
    SMTPPassword
    SMTP_Authentication
    SMTPSERVER
    DataSource
    InitialCatalog
    EmailBCC
    MySqlUserID
    MYSQLPassword
    MYSQLServerIP
    MYSQLDB
    CXLUserID
    CXLPassword
    CXLServerIP
    D
    E
    N

    IO_MySqlUser
    IO_MySqlPassword
    IO_MySqlDatabase
    IO_MySqlServer

    FH_MySqlUser
    FH_MySqlPassword
    FH_MySqlDatabase
    FH_MySqlServer

    NAT_MySqlUser
    NAT_MySqlPassword
    NAT_MySqlDatabase
    NAT_MySqlServer

    NAT_Server
    NAT_Port
End Enum
