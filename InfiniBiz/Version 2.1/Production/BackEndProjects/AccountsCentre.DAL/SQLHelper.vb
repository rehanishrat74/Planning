'*********************************************************************
' Namespce: InfiniPayroll.DAL
'
' Class: SqlHelper
' Description:
' Provides the access to data source by different helper functions.

' Class: SqlHelperParameterCache
' Description:
' Provides the supporting functions to execute the tasks for SQLHelper class.
'*********************************************************************

#Region "Import Libraries"
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections

#End Region

'*********************************************************************
Public NotInheritable Class SqlHelper
    Public Shared InfiniMainDB As String
#Region " Private methods & constructors"


    '*********************************************************************
    '
    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new SqlHelper()".
    '
    '*********************************************************************
    Private Shared _strConnectionString As String

    Private Sub New()
    End Sub 'New

    Public Shared Property ConnectionString()
        Get
            ConnectionString = _strConnectionString
        End Get
        Set(ByVal Value)
            _strConnectionString = Value
        End Set
    End Property

    '***********EstablishConnection**********************************************************
    ' This method establish connection to the database.
    ' If the connection is not established it will return false, else true.

    Public Shared Function EstablishConnection(Optional ByVal strConnectionString As String = "") As Boolean

        If strConnectionString = "" Then
            'Dim objConnection1 As New Connection()
            strConnectionString = Connection.GetConnectionString
            'Else
            '   strConnectionString = strConnectionString
        End If
        Dim objConnection As New SqlConnection(strConnectionString)
        objConnection.Open()
        If objConnection.State = ConnectionState.Open Then
            EstablishConnection = True
        Else
            EstablishConnection = False
        End If
    End Function

    Public Shared Function EstablishAdminConnection() As String


        Return Connection.GetConnectionString


    End Function

    Public Shared Function OpenDataAdapter(ByVal SqlQuery As String, ByVal Conn As SqlConnection) As SqlDataAdapter
        Conn.Open()
        Dim sqlda As New SqlDataAdapter(SqlQuery, Conn)
        Return sqlda
    End Function
    '*********AttachParameters *******************************************************
    '
    ' This method is used to attach array of SqlParameters to a SqlCommand.
    ' 
    ' This method will assign a value of DbNull to any parameter with a direction of
    ' InputOutput and a value of null.  
    ' 
    ' This behavior will prevent default values from being used, but
    ' this will be the less common case than an intended pure output parameter (derived as InputOutput)
    ' where the user provided no input value.
    ' 
    ' param name="command" The command to which the parameters will be added
    ' param name="commandParameters" an array of SqlParameters tho be added to command
    '
    '*********************************************************************

    Private Shared Sub AttachParameters(ByVal command As SqlCommand, ByVal commandParameters() As SqlParameter)
        Dim p As SqlParameter
        For Each p In commandParameters
            'check for derived output value with no value assigned
            If p.Direction = ParameterDirection.InputOutput And p.Value Is Nothing Then
                p.Value = Nothing
            End If
            command.Parameters.Add(p)
        Next p
    End Sub 'AttachParameters

    '*********AssignParameterValues************************************************************
    '
    ' This method assigns an array of values to an array of SqlParameters.
    ' 
    ' param name="commandParameters" array of SqlParameters to be assigned values
    ' param name="parameterValues" array of objects holding the values to be assigned
    '
    '*********************************************************************

    Private Shared Sub AssignParameterValues(ByVal commandParameters() As SqlParameter, ByVal parameterValues() As Object)

        Dim i As Short
        Dim j As Short

        If (commandParameters Is Nothing) And (parameterValues Is Nothing) Then
            'do nothing if we get no data
            Return
        End If

        ' we must have the same number of values as we pave parameters to put them in
        If commandParameters.Length <> parameterValues.Length Then
            Throw New ArgumentException("Parameter count does not match Parameter Value count.")
        End If

        'value array
        j = commandParameters.Length - 1
        For i = 0 To j
            commandParameters(i).Value = parameterValues(i)
        Next

    End Sub 'AssignParameterValues

    '***********PrepareCommand**********************************************************
    '
    ' This method opens (if necessary) and assigns a connection, transaction, command type and parameters 
    ' to the provided command.
    ' 
    ' param name="command" the SqlCommand to be prepared
    ' param name="connection" a valid SqlConnection, on which to execute this command
    ' param name="transaction" a valid SqlTransaction, or 'null'
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParameters to be associated with the command or 'null' if no parameters are required
    '
    '*********************************************************************

    Private Shared Sub PrepareCommand(ByVal command As SqlCommand, _
                                                            ByVal connection As SqlConnection, _
                                                            ByVal transaction As SqlTransaction, _
                                                            ByVal commandType As CommandType, _
                                                            ByVal commandText As String, _
                                                            ByVal commandParameters() As SqlParameter)

        'if the provided connection is not open, we will open it
        If connection.State <> ConnectionState.Open Then
            connection.Open()
        End If

        'associate the connection with the command
        command.Connection = connection
        command.CommandTimeout = 60 * 60
        'set the command text (stored procedure name or SQL statement)
        command.CommandText = commandText

        'if we were provided a transaction, assign it.
        If Not (transaction Is Nothing) Then
            command.Transaction = transaction
        End If

        'set the command type
        command.CommandType = commandType

        'attach the command parameters if they are provided
        If Not (commandParameters Is Nothing) Then
            AttachParameters(command, commandParameters)
        End If

        Return
    End Sub 'PrepareCommand

    Protected Shared Function GetConnectionString(ByVal CustomerID As Int32) As String
        If CustomerID > 0 Then Return Connection.GetConnectionString(CustomerID)

        Return Connection.GetConnectionString(True)

    End Function
#End Region

#Region " ExecuteReader overloads"


    ' this enum is used to indicate whether the connection was provided by the caller, or created by SqlHelper, so that
    ' we can set the appropriate CommandBehavior when calling ExecuteReader()
    Private Enum SqlConnectionOwnership
        ' Connection is owned and managed by SqlHelper
        Internal
        ' Connection is owned and managed by the caller
        [External]
    End Enum ' SqlConnectionOwnership

    ' Execute a SqlCommand (that returns a resultset and takes no parameters) against the database specified in 
    ' the connection string. 
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(CommandType.StoredProcedure, "GetOrders")
    ' Parameters:
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal customerid As Int32, ByVal commandType As CommandType, ByVal commandText As String) As SqlDataReader
        ' Pass through the call providing null for the set of SqlParameters
        Return ExecuteReader(customerid, commandType, commandText, CType(Nothing, SqlParameter()))
    End Function ' ExecuteReader

    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' e.g.:  
    ' Dim dr As SqlDataReader = ExecuteReader(CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24))
    ' Parameters:
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParamters used to execute the command 
    ' Returns: A SqlDataReader containing the resultset generated by the command 
    Public Overloads Shared Function ExecuteReader(ByVal customerid As Int32, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Dim cn As New SqlConnection(GetConnectionString(customerid))
        '  Try
        cn.Open()
        Return ExecuteReader(cn, commandType, commandText, commandParameters)
        'Finally
        '    cn.Dispose()
        ' End Try
    End Function

    ' Create and prepare a SqlCommand, and call ExecuteReader with the appropriate CommandBehavior.
    ' If we created and opened the connection, we want the connection to be closed when the DataReader is closed.
    ' If the caller provided the connection, we want to leave it to them to manage.
    ' Parameters:
    ' -connection - a valid SqlConnection, on which to execute this command 
    ' -commandType - the CommandType (stored procedure, text, etc.) 
    ' -commandText - the stored procedure name or T-SQL command 
    ' -commandParameters - an array of SqlParameters to be associated with the command or ' null' if no parameters are required 
    ' Returns: SqlDataReader containing the results of the command 
    Public Overloads Shared Function ExecuteReader(ByVal connection As SqlConnection, _
                                                     ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        ' Create a command and prepare it for execution
        Dim cmd As New SqlCommand

        ' Create a reader
        Dim dr As SqlDataReader

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

        ' Call ExecuteReader with the appropriate CommandBehavior
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        'dr = cmd.ExecuteReader() ' Furqan has commented  the above line 

        ' return the data reader
        Return dr
    End Function ' ExecuteReader

    Public Overloads Shared Function ExecuteReader(ByVal customerid As Int32, ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray commandParameters() As SqlParameter) As SqlDataReader
        Dim cn As New SqlConnection(GetConnectionString(customerid))
        '  Try
        cn.Open()
        Return ExecuteReader(cn, commandType, commandText, commandParameters)
        'Finally
        '    cn.Dispose()
        ' End Try
    End Function

#End Region

#Region " ExecuteNonQuery overloads"

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns no resultset) against the database specified in the connection string 
    ' using the provided parameters.
    '
    ' e.g.:  
    '  int result = ExecuteNonQuery(CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    '
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParamters used to execute the command
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************
    Public Overloads Shared Function ExecuteNonQuery(ByVal Customerid As Int32, ByVal commandType As CommandType, _
                                                     ByVal commandText As String, _
                                                     ByVal ParamArray commandParameters() As SqlParameter) As Integer
        'create & open a SqlConnection, and dispose of it after we are done.

        'Dim cn As New SqlConnection(_strConnectionString)
        Dim cn As New SqlConnection(GetConnectionString(Customerid))

        Try
            cn.Open()
            'call the overload that takes a connection in place of the connection string


            Return ExecuteNonQuery(cn, commandType, commandText, commandParameters)

        Catch e As SqlException
            Throw New Exception(e.Message & e.LineNumber, e)

        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteNonQuery

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns no resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  int result = ExecuteNonQuery(connString, "PublishOrders", 24, 36);
    '
    ' param name="connectionString" a valid connection string for a SqlConnection
    ' param name="spName" the name of the stored prcedure
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal customerid As Int32, ByVal spName As String, _
                                                     ByVal ParamArray parameterValues() As Object) As Integer
        Dim commandParameters As SqlParameter()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)

            commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnectionString(Customerid), spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteNonQuery(customerid, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteNonQuery(customerid, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteNonQuery

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns no resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int result = ExecuteNonQuery(conn, CommandType.StoredProcedure, "PublishOrders", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connection" a valid SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an int representing the number of rows affected by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteNonQuery(ByVal connection As SqlConnection, _
                                                    ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As Integer

        'create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Integer

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

        cmd.CommandTimeout = 300
        'finally, execute the command.
        retval = cmd.ExecuteNonQuery()

        'detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval

    End Function 'ExecuteNonQuery

#End Region

#Region " ExecuteDataset overloads"

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(connString, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal customerid As Int32, ByVal commandType As CommandType, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet
        'create & open a SqlConnection, and dispose of it after we are done.
        Dim cn As New SqlConnection(GetConnectionString(customerid))
        Try
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteDataset(commandType, cn, commandText, commandParameters)
        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteDataset

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns a resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(connString, "GetOrders", 24, 36);
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection
    ' param name="spName" the name of the stored procedure
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal customerid As Int32, ByVal spName As String, _
                                                    ByVal ParamArray parameterValues() As Object) As DataSet

        Dim commandParameters As SqlParameter()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnectionString(customerid), spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteDataset(customerid, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteDataset(customerid, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteDataset

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  DataSet ds = ExecuteDataset(conn, CommandType.StoredProcedure, "GetOrders", new SqlParameter("@prodid", 24));
    '
    ' param name="connection" a valid SqlConnection
    ' param name="commandType" the CommandType (stored procedure, text, etc.)
    ' param name="commandText" the stored procedure name or T-SQL command
    ' param name="commandParameters" an array of SqlParamters used to execute the command
    ' returns a dataset containing the resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteDataset(ByVal commandType As CommandType, _
                                                    ByVal connection As SqlConnection, _
                                                    ByVal commandText As String, _
                                                    ByVal ParamArray commandParameters() As SqlParameter) As DataSet

        'create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim ds As New DataSet
        Dim da As SqlDataAdapter
        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

        'create the DataAdapter & DataSet
        da = New SqlDataAdapter(cmd)

        'fill the DataSet using default values for DataTable names, etc.
        da.Fill(ds)

        'detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        'return the dataset
        Return ds

    End Function 'ExecuteDataset

#End Region

#Region " ExecuteScalar overloads"

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a 1x1 resultset) against the database specified in the connection string 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(connString, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal customerid As Int32, ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        'create & open a SqlConnection, and dispose of it after we are done.
        Dim cn As New SqlConnection(GetConnectionString(customerid))
        Try
            cn.Open()

            'call the overload that takes a connection in place of the connection string
            Return ExecuteScalar(cn, commandType, commandText, commandParameters)
        Finally
            cn.Dispose()
        End Try
    End Function 'ExecuteScalar

    '*********************************************************************
    '
    ' Execute a stored procedure via a SqlCommand (that returns a 1x1 resultset) against the database specified in 
    ' the connection string using the provided parameter values.  This method will query the database to discover the parameters for the 
    ' stored procedure (the first time each stored procedure is called), and assign the values based on parameter order.
    ' 
    ' This method provides no access to output parameters or the stored procedure's return value parameter.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(connString, "GetOrderCount", 24, 36);
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="parameterValues" an array of objects to be assigned as the input values of the stored procedure 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal customerid As Int32, ByVal spName As String, _
                                                   ByVal ParamArray parameterValues() As Object) As Object
        Dim commandParameters As SqlParameter()

        'if we receive parameter values, we need to figure out where they go
        If Not (parameterValues Is Nothing) And parameterValues.Length > 0 Then
            'pull the parameters for this stored procedure from the parameter cache (or discover them & populate the cache)
            commandParameters = SqlHelperParameterCache.GetSpParameterSet(GetConnectionString(customerid), spName)

            'assign the provided values to these parameters based on parameter order
            AssignParameterValues(commandParameters, parameterValues)

            'call the overload that takes an array of SqlParameters
            Return ExecuteScalar(customerid, CommandType.StoredProcedure, spName, commandParameters)
            'otherwise we can just call the SP without params
        Else
            Return ExecuteScalar(customerid, CommandType.StoredProcedure, spName)
        End If
    End Function 'ExecuteScalar

    '*********************************************************************
    '
    ' Execute a SqlCommand (that returns a 1x1 resultset) against the specified SqlConnection 
    ' using the provided parameters.
    ' 
    ' e.g.:  
    '  int orderCount = (int)ExecuteScalar(conn, CommandType.StoredProcedure, "GetOrderCount", new SqlParameter("@prodid", 24));
    ' 
    ' param name="connection" a valid SqlConnection 
    ' param name="commandType" the CommandType (stored procedure, text, etc.) 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters used to execute the command 
    ' returns an object containing the value in the 1x1 resultset generated by the command
    '
    '*********************************************************************

    Public Overloads Shared Function ExecuteScalar(ByVal connection As SqlConnection, _
                                                   ByVal commandType As CommandType, _
                                                   ByVal commandText As String, _
                                                   ByVal ParamArray commandParameters() As SqlParameter) As Object
        'create a command and prepare it for execution
        Dim cmd As New SqlCommand
        Dim retval As Object

        PrepareCommand(cmd, connection, CType(Nothing, SqlTransaction), commandType, commandText, commandParameters)

        'execute the command & return the results
        retval = cmd.ExecuteScalar()

        'detach the SqlParameters from the command object, so they can be used again
        cmd.Parameters.Clear()

        Return retval

    End Function 'ExecuteScalar
#End Region

End Class 'SqlHelper


'*********************************************************************
'
' SqlHelperParameterCache provides functions to leverage a static cache of procedure parameters, and the
' ability to discover parameters for stored procedures at run-time.
'
'*********************************************************************

Public NotInheritable Class SqlHelperParameterCache

    '*********************************************************************
    '
    ' Since this class provides only static methods, make the default constructor private to prevent 
    ' instances from being created with "new SqlHelperParameterCache()".
    '
    '*********************************************************************

    Private Sub New()
    End Sub 'New 

#Region "Private methods"


    Private Shared paramCache As Hashtable = Hashtable.Synchronized(New Hashtable)

    '*********************************************************************
    '
    ' resolve at run time the appropriate set of SqlParameters for a stored procedure
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="includeReturnValueParameter" whether or not to include their return value parameter 
    '
    '*********************************************************************

    Private Shared Function DiscoverSpParameterSet(ByVal connectionString As String, _
                                                   ByVal spName As String, _
                                                   ByVal includeReturnValueParameter As Boolean, _
                                                   ByVal ParamArray parameterValues() As Object) As SqlParameter()

        Dim cn As New SqlConnection(connectionString)
        Dim cmd As SqlCommand = New SqlCommand(spName, cn)
        Dim discoveredParameters() As SqlParameter

        Try
            cn.Open()
            cmd.CommandType = CommandType.StoredProcedure
            SqlCommandBuilder.DeriveParameters(cmd)
            If Not includeReturnValueParameter Then
                cmd.Parameters.RemoveAt(0)
            End If

            discoveredParameters = New SqlParameter(cmd.Parameters.Count - 1) {}
            cmd.Parameters.CopyTo(discoveredParameters, 0)
        Finally
            cmd.Dispose()
            cn.Dispose()

        End Try

        Return discoveredParameters

    End Function 'DiscoverSpParameterSet

    'deep copy of cached SqlParameter array
    Private Shared Function CloneParameters(ByVal originalParameters() As SqlParameter) As SqlParameter()

        Dim i As Short
        Dim j As Short = originalParameters.Length - 1
        Dim clonedParameters(j) As SqlParameter

        For i = 0 To j
            clonedParameters(i) = CType(CType(originalParameters(i), ICloneable).Clone, SqlParameter)
        Next

        Return clonedParameters
    End Function 'CloneParameters

    
#End Region

#Region "Public methods"


    '*********************************************************************
    '
    ' add parameter array to the cache
    '
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' param name="commandParameters" an array of SqlParamters to be cached 
    '
    '*********************************************************************

    Public Shared Sub CacheParameterSet(ByVal connectionString As String, _
                                        ByVal commandText As String, _
                                        ByVal ParamArray commandParameters() As SqlParameter)
        Dim hashKey As String = connectionString + ":" + commandText

        paramCache(hashKey) = commandParameters
    End Sub 'CacheParameterSet

    '*********************************************************************
    '
    ' Retrieve a parameter array from the cache
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="commandText" the stored procedure name or T-SQL command 
    ' returns an array of SqlParamters
    '
    '*********************************************************************

    Public Shared Function GetCachedParameterSet(ByVal connectionString As String, ByVal commandText As String) As SqlParameter()
        Dim hashKey As String = connectionString + ":" + commandText
        Dim cachedParameters As SqlParameter() = CType(paramCache(hashKey), SqlParameter())

        If cachedParameters Is Nothing Then
            Return Nothing
        Else
            Return CloneParameters(cachedParameters)
        End If
    End Function 'GetCachedParameterSet

    '*********************************************************************
    '
    ' Retrieves the set of SqlParameters appropriate for the stored procedure
    ' 
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' returns an array of SqlParameters
    '
    '*********************************************************************

    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, ByVal spName As String) As SqlParameter()
        Return GetSpParameterSet(connectionString, spName, False)
    End Function 'GetSpParameterSet 

    '*********************************************************************
    '
    ' Retrieves the set of SqlParameters appropriate for the stored procedure
    ' 
    ' This method will query the database for this information, and then store it in a cache for future requests.
    ' 
    ' param name="connectionString" a valid connection string for a SqlConnection 
    ' param name="spName" the name of the stored procedure 
    ' param name="includeReturnValueParameter" a bool value indicating whether the return value parameter should be included in the results 
    ' returns an array of SqlParameters
    '
    '*********************************************************************

    Public Overloads Shared Function GetSpParameterSet(ByVal connectionString As String, _
                                                       ByVal spName As String, _
                                                       ByVal includeReturnValueParameter As Boolean) As SqlParameter()

        Dim cachedParameters() As SqlParameter
        Dim hashKey As String

        hashKey = connectionString + ":" + spName
        If includeReturnValueParameter = True Then
            hashKey = hashKey + ":include ReturnValue Parameter"
        End If

        cachedParameters = CType(paramCache(hashKey), SqlParameter())

        If (cachedParameters Is Nothing) Then
            paramCache(hashKey) = DiscoverSpParameterSet(connectionString, spName, includeReturnValueParameter)
            cachedParameters = CType(paramCache(hashKey), SqlParameter())

        End If

        Return CloneParameters(cachedParameters)

    End Function 'GetSpParameterSet
#End Region

End Class 'SqlHelperParameterCache