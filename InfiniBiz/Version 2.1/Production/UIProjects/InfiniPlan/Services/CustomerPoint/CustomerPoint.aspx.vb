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

Public Class CustomerPoint
    ' Inherits System.Web.UI.Page
    Inherits BizPlanWebBase

    Dim dateStart As String
    Dim dateEnd As String
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
        Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents ParentFrame As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ChildFrams As System.Web.UI.HtmlControls.HtmlGenericControl
    Protected WithEvents ChildFrame As System.Web.UI.HtmlControls.HtmlGenericControl
    Dim parenturl As String = "/InfiniPlan/Services/CustomerPoint/Visit.aspx"
    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object
    Protected WithEvents lblTime As System.Web.UI.WebControls.Label
    Dim _QueryString As String

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
        Try

            Trace.Warn("CustomerPoint page load")

        dateStart = Date.Now.AddDays(-9).ToLongDateString + " " + "00:00:00.000"
        dateEnd = Date.Now.ToLongDateString + " " + CStr(Now.Hour) + ":" + CStr(Now.Minute) + ":" + CStr(Now.Second) + "." + CStr(Now.Millisecond)

            Trace.Warn(dateStart)
            Trace.Warn(dateEnd)
        lblTime.Text = "Date from : <b>" + dateStart + "</b> " + "&nbsp;   To : <b>" + dateEnd + "</b>"

        Trace.Write("CustomerPoint page load ")
        _QueryString = Request.QueryString("ParentPageURL")

        If Not _QueryString Is Nothing Then
            LoadParentPage(_QueryString)
        End If
        Trace.Write("CustomerPoint page load end")
        Catch ex As Exception
            Trace.Warn("CP page Load " + ex.Message)
        End Try

        


    End Sub

    Public Function LoadParentPage(ByVal _QueryString As String)
        Try

       
        Trace.Write("LoadParentPage page load ")
        Dim _parentFrame As HtmlControl

        _parentFrame = CType(Me.FindControl("ParentFrame"), HtmlControl)
        _parentFrame.Attributes("src") = Request.QueryString("ParentPageURL").Replace(",", "?")

            Trace.Write("LoadParentPage page load ")

        Catch ex As Exception
            Trace.Warn("CP LoadParentPage " + ex.Message)
        End Try
    End Function
End Class
