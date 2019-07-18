Imports Infinilogic.BusinessPlan.BLLRules

Public Class PlanWizardController

    Friend WithEvents model As IPlanWizardModel
    Friend WithEvents view As PlanWizardView

    Public Sub New(ByVal model As IPlanWizardModel)
        Me.model = model
    End Sub

    Public Sub viewNext(ByVal queryResponse As IPlanWizardResponse)
        model.ChangeNext(queryResponse)
    End Sub

    Public Sub viewBack(ByVal queryResponse As IPlanWizardResponse)
        model.ChangeBack(queryResponse)
    End Sub

    Public Sub viewCancel(ByVal queryResponse As IPlanWizardResponse)

    End Sub

    Public Sub viewFinish(ByVal queryResponse As IPlanWizardResponse)
        model.Finish(queryResponse)
    End Sub

    Public Sub viewSave(ByVal save As Boolean)
        If save Then model.Save()
    End Sub

    Public Sub viewStart()
        model.Start()
    End Sub
    Public Function GetNextView(ByVal viewid As PlanQueries) As String
        If (viewid = PlanQueries.PlanParticulars Or viewid = PlanQueries.bPlanParticulars) Then
            Return "/InfiniPlan/Services/PlanWizard/MultiOptions.aspx"
        ElseIf (viewid = PlanQueries.PlanStartAndTitle Or viewid = PlanQueries.bPlanStartAndTitle) Then
            Return "/InfiniPlan/Services/PlanWizard/StartOption.aspx"
        Else
            Return "/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"
        End If
    End Function
End Class
