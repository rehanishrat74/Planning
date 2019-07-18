Imports Infinilogic.BusinessPlan.BLL
Imports Infinilogic.BusinessPlan.BLLRules

Public Class PlanWizardNav
    Inherits System.Web.UI.UserControl

    Private viewID As PlanQueries

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents tblMenu1 As System.Web.UI.HtmlControls.HtmlTable

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

    Public WriteOnly Property CurrentView() As PlanQueries
        Set(ByVal Value As PlanQueries)
            viewID = Value
        End Set
    End Property

    Public WriteOnly Property CurrentPlan() As QuerySettingsList
        Set(ByVal Value As QuerySettingsList)

            Dim navCell As HtmlTableCell
            Dim navRow As HtmlTableRow
            If tblMenu1.Rows.Count <= 1 Then
                For i As Integer = 0 To Value.Count - 1
                    navRow = New HtmlTableRow
                    navRow.Height = "20"

                    navCell = New HtmlTableCell
                    navCell.Attributes.Add("onmouseover", "this.style.cursor='hand'")
                    navCell.Attributes.Add("onmouseout", "this.style.cursor='hand'")
                    navCell.Attributes.Add("vAlign", "middle")
                    navCell.Attributes.Add("height", "20")
                    navCell.NoWrap = True
                    navCell.InnerHtml = "<A class='leftlink' href='PlanWizardView.aspx?queryID=" & Value.item(i).QueryID & "'>" & Value.item(i).QueryName & "</A>"
                    If viewID = Value.item(i).QueryID Then
                        navRow.Attributes.Add("class", "leftlinkSel")
                    Else
                        navRow.Attributes.Add("class", "leftlink")
                    End If
                    'navCell.InnerHtml = navCell.InnerText & "<img src='../../images/InfiniPlan/ArrowBack.bmp' height='10' width='10'>"
                    navRow.Cells.Add(navCell)

                    navCell = New HtmlTableCell
                    If Value.item(i).QueryID = PlanQueries.planDescription Or Value.item(i).QueryID = PlanQueries.planTitle Then
                        If Value.item(i).QueryValue.Length > 10 Then
                            navCell.InnerText = Value.item(i).QueryValue.Substring(0, 10) & "..."
                        Else
                            navCell.InnerText = Value.item(i).QueryValue
                        End If
                    Else
                        navCell.InnerText = Value.item(i).QueryValue
                    End If
                    navCell.NoWrap = False
                    navRow.Cells.Add(navCell)

                    tblMenu1.Rows.Add(navRow)
                Next
            End If
            navRow = New HtmlTableRow
            tblMenu1.Rows.Add(navRow)

        End Set
    End Property

End Class
