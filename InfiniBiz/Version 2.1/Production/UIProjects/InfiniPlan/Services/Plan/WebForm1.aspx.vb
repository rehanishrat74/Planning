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

Public Class WebForm1
    ' Inherits BizPlanWebBase
    Inherits System.Web.UI.Page
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents txtUser As System.Web.UI.WebControls.TextBox
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents txtPwd As System.Web.UI.WebControls.TextBox
    Protected WithEvents btnLogin As System.Web.UI.WebControls.Button




    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub


    Private Sub InitializeComponent()

    End Sub
End Class


