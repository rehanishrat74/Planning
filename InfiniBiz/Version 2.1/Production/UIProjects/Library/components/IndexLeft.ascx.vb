Imports Microsoft.Toolkits.EnterpriseLocalization
Imports System.Threading
Imports System.Globalization
Public Class IndexLeft
    Inherits System.Web.UI.UserControl
    Public lblindexleft As String
    Protected rs As ElementResourceSet
    Protected _culture As CultureInfo
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
    End Sub
    Private Sub load_culture()
        If Not IsPostBack Then

            rs = Settings.CurrentManager.GetResourceSet(Thread.CurrentThread.CurrentUICulture, True, True)
            lblindexleft = rs.GetProperty("acc_components_indexleft_lblindexleft", "System.Web.UI.WebControls.Label", "Text", True)
        Else
            _culture = Session("SelectedCulture")
            rs = Settings.CurrentManager.GetResourceSet(_culture, True, True)
            lblindexleft = rs.GetProperty("acc_components_indexleft_lblindexleft", "System.Web.UI.WebControls.Label", "Text", True)
        End If

    End Sub

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.PreRender
        'Modified by : Muhammad Furqan Khan  24-JUL-2007
        'Disable functionality if page is viewed inside infinioffice
        If Not IsNothing(Session(PageTemplate.Session_InsideIO)) AndAlso Session(PageTemplate.Session_InsideIO) Then
            Me.Visible = False
        Else
            load_culture()
        End If
    End Sub
End Class
