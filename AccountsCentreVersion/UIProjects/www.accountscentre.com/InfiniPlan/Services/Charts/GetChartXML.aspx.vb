Imports Infinilogic.BusinessPlan.web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports Infinilogic.BusinessPlan.BLL
Imports System.Text
Imports System.IO
Imports System.Xml
Imports System.Xml.Xsl
Imports System.Web
Imports System.Reflection
Imports Owc11
Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.DAL

Public Class GetChartXML
    Inherits ChartsBase
    'Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        'Put user code to initialize the page here
        Dim chartID As Integer = CInt(Request.QueryString("chartID"))
        'If chartID >= 0 Then
        Response.Write(GetChartXML(chartID))
        'End If
    End Sub

    Private Function GetChartXML(ByVal chartID As Integer) As String

        Try
            Dim assemName As String = "Infinilogic.BusinessPlan.BLLRules"
            Dim typeName As String = assemName & "." & Navigator(chartID) & "Chart"
            Dim asmbly As [Assembly] = [Assembly].Load(assemName)
            Dim chartClass As IChartGenerator = CType(asmbly.CreateInstance(typeName), IChartGenerator)
            Return chartClass.GetChartXML(GetConnectionData(), CurrentPlan)
        Catch ex As Exception
            Return ex.Message
        End Try

    End Function

    Private Sub PlanContents_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        Response.Flush()
        Response.Close()
    End Sub

End Class
