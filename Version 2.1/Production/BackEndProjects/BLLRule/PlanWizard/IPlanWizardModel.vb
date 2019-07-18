Public Interface IPlanWizardModel

    Event StateChanged()
    Event WizardStarted()
    Event WizardFinished(ByVal exists As Boolean, ByVal errMessage As String)
    Event NewPlanCreated(ByVal planName As String)
    Sub ChangeNext(ByVal queryResponse As IPlanWizardResponse)
    Sub ChangeBack(ByVal queryResponse As IPlanWizardResponse)
    Sub Finish(ByVal queryResponse As IPlanWizardResponse)
    Sub Start()
    Sub Save()
    Sub SetWizardState(ByVal state As WizardState)
    Function GetWizardState() As WizardState
    Function GetPlan() As BusinessPlan.BLL.BusinessPlan
    'Function GetPlanWizardQuery() As PlanWizardQuery
    ' Function GetPlanWizardQueryByID(ByVal queryID As PlanQueries) As PlanWizardQuery
    Function GetPlanSettingsList() As QuerySettingsList
    Function GetPlanWizardQuery() As IPlanWizardQuery
    Function GetPlanWizardQueryByID(ByVal queryID As PlanQueries) As IPlanWizardQuery

End Interface

Public Structure WizardState
    Dim isNew As Boolean
    Dim isBasic As Boolean
End Structure