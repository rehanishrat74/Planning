'Imports InfiniLogic.AccountsCentre.common
Imports System.data
Imports System.Data.SqlClient
Imports System.IO
Imports InfiniLogic.AccountsCentre.DAL
Imports System.text

Public Class MethodCalls

    Public Shared Function InsertData(ByVal QuestionId As String, ByVal Question As String, ByVal Answer As String, ByVal EmployeeID As Integer, ByVal Customerid As Integer) As String
 
        Dim cmd As New CommandData(Customerid)
        Try
            Dim Qbtye() As Byte, Abtye() As Byte
            Qbtye = System.Convert.FromBase64String(Question)
            Abtye = System.Convert.FromBase64String(Answer)
            Dim DQuestion As String, DAnswer As String
            DQuestion = System.Text.Encoding.ASCII.GetString(Qbtye)
            DAnswer = System.Text.Encoding.ASCII.GetString(Qbtye)
            cmd.BeginTransaction("Tran", True, IsolationLevel.RepeatableRead)
            cmd.CmdText = "ACCOUNTSPRO_CREATE_FAQS_QUESTION_WS"
            cmd.AddParameter("@QuestionId", QuestionId)
            cmd.AddParameter("@Question", DQuestion)
            cmd.AddParameter("@Answer", DAnswer)
            cmd.AddParameter("@EmployeeID", EmployeeID)
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            Dim RetNode As String = QuestionId + " Record Inserted"
            cmd.Commit()
            Return RetNode
        Catch ex As Exception
            cmd.RollBack()
            Throw New Exception(ex.Message)
        End Try
   
    End Function

    Public Shared Function UpdateQuestionDate(ByVal QuestionId As String, ByVal Question As String, ByVal Customerid As Integer) As String
        Try
            Dim Qbtye() As Byte
            Qbtye = System.Convert.FromBase64String(Question)
            Dim DQuestion As String, DAnswer As String
            DQuestion = System.Text.Encoding.ASCII.GetString(Qbtye)
            Dim cmd As New CommandData(Customerid)
            cmd.CmdText = "ACCOUNTSPRO_CREATE_FAQS_UPDATEQUESTION_WS"
            cmd.AddParameter("@QuestionId", QuestionId)
            cmd.AddParameter("@Question", DQuestion)
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            Dim RetNode As String = QuestionId + " Question updated"
            Return RetNode
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
 
    End Function


    Public Shared Function UpdateAnswerDate(ByVal QuestionId As String, ByVal Answer As String, ByVal Customerid As Integer) As String
        Try
            Dim dsReturn As DataSet
            Dim cmd As New CommandData(Customerid)
            Dim Abtye() As Byte
            Abtye = System.Convert.FromBase64String(Answer)
            Dim DAnswer As String
            DAnswer = System.Text.Encoding.ASCII.GetString(Abtye)
            cmd.CmdText = "ACCOUNTSPRO_CREATE_FAQS_UPDATEANSWERS_WS"
            cmd.AddParameter("@QuestionId", QuestionId)
            cmd.AddParameter("@Answer", DAnswer)
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.Execute(ExecutionType.ExecuteNonQuery)
            Dim RetNode As String = QuestionId + " Answer updated"
            Return RetNode
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
       
    End Function

 


End Class



