Option Explicit On 
Option Strict Off
Imports System.IO
Imports System.Text

Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules

Public Class CategoryDetail
    ' Inherits System.Web.UI.Page

    Inherits BizPlanWebBase
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents lblNo As System.Web.UI.WebControls.Label
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents dgCategoryDetail1 As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgCategoryDetail As System.Web.UI.WebControls.DataGrid

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Dim _baseAnalyzer As New AnalyzerBase
    Dim _Activity As InfiniLogic.BusinessPlan.BLLRules.Activity
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        Dim _dt As DataTable

        Dim _sessionId As String
        Dim _categoryName As String = Request.QueryString("catName")
        Dim chr() As Byte

        chr = System.Convert.FromBase64String(_categoryName)
        _categoryName = System.Text.ASCIIEncoding.ASCII.GetString(chr)

      

        Dim dateStart As String = Session("PeriodStartCat")
        Dim dateEnd As String = Session("PeriodToCat")
        Dim _domain As String = Session("DomainNameCat")
        Dim _mid As Integer = GetConnectionData.CustomerID

        Trace.Warn("_cid" & _categoryName)

        Trace.Warn("dateStartCat" & dateStart)
        Trace.Warn("dateEndCat" & dateEnd)
        Trace.Warn("_domainCat" & _domain)
        Trace.Warn("_mid" & _mid)
        Trace.Warn(" -----------------CategoryDetail Page_Load Starts --------------------------- ")
        Try

            lblHeader.Text = "Category"
            Trace.Warn(" -----------------Category CategoryDetail Page_Load Starts --------------------------- ")
            _dt = _baseAnalyzer.RenderDataGridforChildProductCatagory(_mid, _categoryName, dateStart, dateEnd, _domain)
            ' Dim _ds As DataSet = _Activity.RenderDataGridforProductCategoryChild(_mid, _categoryName, System.Web.HttpContext.Current.Session("ProductIDAsXML"))
            dgCategoryDetail.DataSource = _dt
            dgCategoryDetail.DataBind()
        Catch ex As Exception
            Dim _err As String = ex.Message
            Trace.Warn(" -----------------CategoryDetail Page_Load Error --------------------------- " & ex.Message)
        End Try
        Trace.Warn(" -----------------CategoryDetail Page_Load end --------------------------- ")

    End Sub

End Class
