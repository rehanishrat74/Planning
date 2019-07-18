Imports System.IO
Imports System.text
Imports System.data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL

Public Class MethodCalls

    Public Function InsertProductQuestionAnswer(ByVal QuestionId As Integer, ByVal Question As String, ByVal Answer As String, ByVal CategoryId As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As String

        Customerid = GetSystemID(Customerid)

        Dim cmd As New CommandData(Customerid)
        Dim Qbtye() As Byte, Abtye() As Byte
        Dim DQuestion As String, DAnswer As String
        Dim IdsArray As String()
        Dim cat1, cat2, cat3, cat4, cat5, cat6, cat7, cat8 As Integer

        IdsArray = CategoryId.Split(","c)

        If IdsArray.Length = 1 Then
            cat1 = CInt(CategoryId)
            cat2 = 0
            cat3 = 0
            cat4 = 0
            cat5 = 0
            cat6 = 0
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 2 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = 0
            cat4 = 0
            cat5 = 0
            cat6 = 0
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 3 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = 0
            cat5 = 0
            cat6 = 0
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 4 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = CInt(IdsArray(3))
            cat5 = 0
            cat6 = 0
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 5 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = CInt(IdsArray(3))
            cat5 = CInt(IdsArray(4))
            cat6 = 0
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 6 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = CInt(IdsArray(3))
            cat5 = CInt(IdsArray(4))
            cat6 = CInt(IdsArray(5))
            cat7 = 0
            cat8 = 0
        ElseIf IdsArray.Length = 7 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = CInt(IdsArray(3))
            cat5 = CInt(IdsArray(4))
            cat6 = CInt(IdsArray(5))
            cat7 = CInt(IdsArray(6))
            cat8 = 0
        ElseIf IdsArray.Length = 8 Then
            cat1 = CInt(IdsArray(0))
            cat2 = CInt(IdsArray(1))
            cat3 = CInt(IdsArray(2))
            cat4 = CInt(IdsArray(3))
            cat5 = CInt(IdsArray(4))
            cat6 = CInt(IdsArray(5))
            cat7 = CInt(IdsArray(6))
            cat8 = CInt(IdsArray(7))
        End If

        Try

            Qbtye = System.Convert.FromBase64String(Question)
            Abtye = System.Convert.FromBase64String(Answer)

            DQuestion = System.Text.Encoding.ASCII.GetString(Qbtye)
            DAnswer = System.Text.Encoding.ASCII.GetString(Qbtye)

            cmd.BeginTransaction("Tran", True, IsolationLevel.RepeatableRead)
            cmd.ClearParameters()
            cmd.CmdType = CommandType.StoredProcedure
            cmd.CmdText = "ACCOUNTSPRO_IODOC_INSERTQUESTIONANSWER"
            cmd.AddParameter("@QuestionId", QuestionId)
            cmd.AddParameter("@Question", DQuestion)
            cmd.AddParameter("@Answer", DAnswer)
            'cmd.AddParameter("@CategoryId", CategoryId)
            cmd.AddParameter("@cat1", cat1)
            cmd.AddParameter("@cat2", cat2)
            cmd.AddParameter("@cat3", cat3)
            cmd.AddParameter("@cat4", cat4)
            cmd.AddParameter("@cat5", cat5)
            cmd.AddParameter("@cat6", cat6)
            cmd.AddParameter("@cat7", cat7)
            cmd.AddParameter("@cat8", cat8)
            cmd.AddParameter("@EmployeeId", EmployeeId)
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            Dim RetNode As String = "Record Inserted"
            cmd.Commit()
            Return RetNode

        Catch ex As Exception
            cmd.RollBack()
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function UpdateQuestionAnswer(ByVal QuestionId As Integer, ByVal Question As String, ByVal Answer As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As String

        Customerid = GetSystemID(Customerid)

        Dim cmd As New CommandData(Customerid)
        Dim Qbtye() As Byte, Abtye() As Byte
        Dim DQuestion As String, DAnswer As String

        Try

            Qbtye = System.Convert.FromBase64String(Question)
            DQuestion = System.Text.Encoding.ASCII.GetString(Qbtye)

            Abtye = System.Convert.FromBase64String(Answer)
            DAnswer = System.Text.Encoding.ASCII.GetString(Abtye)

            cmd.ClearParameters()
            cmd.CmdType = CommandType.StoredProcedure
            cmd.CmdText = "ACCOUNTSPRO_IODOC_UPDATEQUESTIONANSWERS"
            cmd.AddParameter("@QuestionId", QuestionId)
            cmd.AddParameter("@Question", DQuestion)
            cmd.AddParameter("@Answer", DAnswer)
            cmd.AddParameter("@EmployeeId", EmployeeId)
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            Dim RetNode As String = "Question updated"
            Return RetNode

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function InsertCategory(ByVal CategoryId As Integer, ByVal CategoryName As String, ByVal ParentId As Integer, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As String

        Customerid = GetSystemID(Customerid)

        Dim cmd As New CommandData(Customerid)
        Dim Abtye() As Byte

        Try
            Abtye = System.Convert.FromBase64String(CategoryName)
            CategoryName = System.Text.Encoding.ASCII.GetString(Abtye)

            With cmd
                .ClearParameters()
                .CmdType = CommandType.StoredProcedure
                .CmdText = "ACCOUNTSPRO_IODOC_ADDCATEGORY"
                .AddParameter("@CategoryId", CategoryId)
                .AddParameter("@CategoryName", CategoryName)
                .AddParameter("@ParentId", ParentId)
                .AddParameter("@EmployeeId", EmployeeId)
                .AddParameter("@MIdentity", Customerid)
                .Execute(ExecutionType.ExecuteNonQuery)
            End With

            Dim RetNode As String = "Inserted Category."
            Return RetNode

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Public Function UpdateCategory(ByVal CategoryId As Integer, ByVal CategoryName As String, ByVal Customerid As Integer, ByVal EmployeeId As Integer) As String

        Customerid = GetSystemID(Customerid)

        Dim cmd As New CommandData(Customerid)
        Dim Abtye() As Byte

        Try
            Abtye = System.Convert.FromBase64String(CategoryName)
            CategoryName = System.Text.Encoding.ASCII.GetString(Abtye)

            With cmd
                .ClearParameters()
                .CmdType = CommandType.StoredProcedure
                .CmdText = "ACCOUNTSPRO_IODOC_UPDATECATEGORY"
                .AddParameter("@CategoryId", CategoryId)
                .AddParameter("@CategoryName", CategoryName)
                .AddParameter("@EmployeeId", EmployeeId)
                .AddParameter("@MIdentity", Customerid)
                .Execute(ExecutionType.ExecuteNonQuery)
            End With

            Dim RetNode As String = "Category updated"
            Return RetNode

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Function GetSystemID(ByVal CompanyId As Integer) As Integer

        Dim MIdentity As Integer = 0
        Dim ds As DataSet
        Dim cmd As New CommandData(CompanyId)

        Try
            With cmd
                .ClearParameters()
                .CmdType = CommandType.StoredProcedure
                .CmdText = "ACCOUNTSPRO_IODOC_GETSYSTEMID"
                .AddParameter("@MIdentity", CompanyId)
                ds = .Execute(ExecutionType.ExecuteDataSet)
            End With

            If ds.Tables(0).Rows.Count > 0 Then
                MIdentity = ds.Tables(0).Rows(0).Item(0)
            End If

            Return MIdentity

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            ds.Dispose()
            ds = Nothing
        End Try

    End Function

End Class
