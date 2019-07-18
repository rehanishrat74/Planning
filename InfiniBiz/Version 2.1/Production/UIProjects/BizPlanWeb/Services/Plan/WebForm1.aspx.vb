Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules
Imports System.Diagnostics
Imports System.IO

 
Imports Microsoft.Web.UI.WebControls

Imports Infinilogic.BusinessPlan.DAL
Imports Infinilogic.BusinessPlan.BLL

Imports Infinilogic.BusinessPlan.Common
Imports Infinilogic.BusinessPlan.Web
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Xml

Public Class WebForm1
    'Inherits System.Web.UI.Page
    Inherits BizPlanWebBase
    Dim obj As Plan
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Protected WithEvents ImageButton1 As System.Web.UI.WebControls.ImageButton
    Protected WithEvents trTopMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents Table1 As System.Web.UI.WebControls.Table

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
    Private bsDV As New DataView
    Private bsDV1 As New DataView
    Dim objBS As BalancesheetReport
    Dim test As String
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

 
        Dim web As New com.service1.www.Service1
        web.HelloWorld()

        Dim tr As TableRow
        Dim td As TableCell

        tr = New TableRow
        td = New TableCell
        Dim str As String = "saira"
        str = str.Replace("saira", "gul")
        td.Text = str
        tr.Controls.Add(td)
        Table1.Rows.Add(tr)

    End Sub

    'cell.Text = "<script type='text/javascript'>AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0','width','325','height','220','src','\\MeterTesting\\MerchantDeviationScale','allowScriptAccess','sameDomain','bgcolor','#ffffff','quality','high','align','middle','id','MerchantActuallSpeedOMeter','FlashVars','" & strFlashVarDay & "','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','\\MeterTesting\\MerchantDeviationScale' ); </script> " _
    '& "<noscript> " _
    '& "<object classid='clsid:d27cdb6e-ae6d-11cf-96b8-444553540000' codebase='https://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=8,0,0,0' width='325' height='220' id='MerchantActuallSpeedOMeter' align='middle'>" _
    '& "<param name='allowScriptAccess' value='sameDomain' /> " _
    '& "<PARAM NAME=FlashVars VALUE='" & strFlashVarDay + "'>" _
    '& "<param name='movie' value='\MeterTesting\MerchantDeviationScale.swf' /><param name='quality' value='high' /><param name='bgcolor' value='#ffffff' />" _
    '& "</object> " _
    '& "</noscript>" _
    '& "<br> "


End Class
