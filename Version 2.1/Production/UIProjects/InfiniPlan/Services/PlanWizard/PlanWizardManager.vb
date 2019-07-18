Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules

Public MustInherit Class PlanWizardManager

    Public Shared Function GetModel(ByVal conndata As ConnectionData) As IPlanWizardModel
        Dim model As PlanWizardModel = New PlanWizardModel(conndata)
        Return model
    End Function

    Public Shared Function GetModel(ByVal conndata As ConnectionData, ByVal queryID As PlanQueries, ByVal plan As BusinessPlan.BLL.BusinessPlan, ByVal iIsNew As Boolean, ByVal iIsBasic As Boolean) As IPlanWizardModel
        Dim model As PlanWizardModel = New PlanWizardModel(conndata, queryID, plan, iIsNew, iIsBasic)
        Return model
    End Function
    Public Shared Function GetModel(ByVal conndata As ConnectionData, ByVal plan As BusinessPlan.BLL.BusinessPlan, ByVal queryID As PlanQueries, ByVal wizState As WizardState) As IPlanWizardModel
        Dim model As PlanWizardModel = New PlanWizardModel(conndata, queryID, plan, wizState)
        Return model
    End Function

End Class
