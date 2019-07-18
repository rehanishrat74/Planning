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


Imports System.Web.UI.WebControls

Public Class ActivityDetail
    Inherits BizPlanWebBase
    '  Inherits System.Web.UI.Page
    Dim _baseAnalyzer As New AnalyzerBase


#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents lblHeader As System.Web.UI.WebControls.Label
    Protected WithEvents dgDetail As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblNo As System.Web.UI.WebControls.Label

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
        Trace.Warn(" -----------------ActivityDetail Page_Load Starts --------------------------- ")
        Try

            Dim _ds As DataSet
            Dim _parent As String = Session("stage")
            Dim _sessionId As String
            Dim _cid As String = Request.QueryString("cid")
            Dim _stage As String = Request.QueryString("stage")
            Dim dateStart As String = Session("PeriodStart")
            Dim dateEnd As String = Session("PeriodTo")
            Dim _domain As String = Session("DomainName")
            Dim _mid As Integer = GetConnectionData.CustomerID
            Trace.Warn("_parent" & _parent)
            Trace.Warn("_cid" & _cid)
            Trace.Warn("_stage" & _stage)
            Trace.Warn("dateStart" & dateStart)
            Trace.Warn("dateEnd" & dateEnd)
            Trace.Warn("_domain" & _domain)
            Trace.Warn("_mid" & _mid)
  
            If _parent = "1" Then
                lblHeader.Text = "Product"
                Trace.Warn(" -----------------Product ActivityDetail Page_Load Starts --------------------------- ")
                _ds = _baseAnalyzer.RenderChildDataGridforProduct(_cid, dateStart, dateEnd, _domain)
                'ElseIf _parent = "2" Then
                '    lblHeader.Text = "Order "
                '    _ds = _baseAnalyzer.RenderChildDataGridforOrder(_cid, dateStart, dateEnd, _domain)
            ElseIf _parent = "3" Then
                Trace.Warn(" -----------------Referrer ActivityDetail Page_Load Starts --------------------------- ")
                lblHeader.Text = "Visit "
                _ds = _baseAnalyzer.RenderChildDataGridforVist(_cid, dateStart, dateEnd, _domain, _mid)
            ElseIf _parent = "6" Then
                Trace.Warn(" -----------------Referrer ActivityDetail Page_Load Starts --------------------------- ")
                _sessionId = Request.QueryString("Sid")
                lblHeader.Text = "Referrer"
                _ds = _baseAnalyzer.RenderChildDataGridforReferrer(_sessionId, _cid, dateStart, dateEnd, _domain, _mid)
            End If
            If _ds.Tables(0).Rows.Count = 0 Or _ds Is Nothing Then
                lblNo.Text = "Record not found"
            Else
                dgDetail.DataSource = _ds
                dgDetail.DataBind()
            End If

        Catch ex As Exception
            Dim _err As String = ex.Message
            Trace.Warn(" -----------------ActivityDetail Page_Load Starts --------------------------- " & ex.Message)
        End Try
        Trace.Warn(" -----------------ActivityDetail Page_Load Starts --------------------------- ")
    End Sub

End Class
