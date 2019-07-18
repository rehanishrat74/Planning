#Region "::::::::::::::::::: Import Liabrariess :::::::::::::::::::"

Imports InfiniLogic.AccountsCentre.BLL
Imports WebSupergoo.ABCpdf4
Imports System.IO
Imports System.Data.SqlClient

#End Region

#Region "::::::::::::::::::: CLASS --> TransactionDetail :::::::::::::::::::"


Public Class TransactionDetail
    Inherits PageTemplate

#Region "<<< <<< <<< <<< <<< Web Form Designer Generated Code >>> >>> >>> >>> >>>"

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents pnlOrderDetails As System.Web.UI.WebControls.Panel
    Protected WithEvents dgrdOrderDetails As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgrdInvoiceDetail As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlInvoiceDetails As System.Web.UI.WebControls.Panel

    Private objUser As AccountsCentre.BLL.User
    Private objCXLOrder As New CXLOrderProcessing
    Protected WithEvents lblOrderNo As System.Web.UI.WebControls.Label
    Protected WithEvents pnlOrder As System.Web.UI.WebControls.Panel
    Protected WithEvents dgrdOrder As System.Web.UI.WebControls.DataGrid
    Public CompanyName, strPageRequest As String
    Protected WithEvents lblInvOrderNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblInvoiceNo As System.Web.UI.WebControls.Label
    Protected WithEvents dgrdInvoice As System.Web.UI.WebControls.DataGrid
    Protected WithEvents pnlInvoice As System.Web.UI.WebControls.Panel

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Evnet handlers >>> >>> >>> >>> >>>"

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        objUser = New AccountsCentre.BLL.User

        CompanyName = Session("CompanyName")

        'Put user code to initialize the page here
        If Not IsPostBack Then
            ShowPanels(False, False, False, False)
            strPageRequest = Session("LinkRequest")


            If strPageRequest = "OrderDetails" Then
                Try
                    SetOrderDetails()
                    ShowPanels(True, False, False, False)
                    Session("LinkRequest") = strPageRequest
                Catch ex As Exception
                End Try
            ElseIf strPageRequest = "InvoiceDetails" Then
                Try
                    SetInvoiceDetails()
                    ShowPanels(False, True, False, False)
                    Session("LinkRequest") = strPageRequest
                Catch ex As Exception
                End Try
            End If

        End If

        'Reset for future purpose
        Session("CompanyName") = CompanyName
    End Sub

    Protected Sub lnkOrderNo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)

        Try
            SetOrderInfo(lnk.CommandName)
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub imgBtnOrderNo_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim imgBtn As ImageButton = CType(sender, ImageButton)

        Try
            SetOrderInfo(imgBtn.CommandName)
        Catch ex As Exception
        End Try

    End Sub

    Protected Sub lnkInvOrderNo_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim lnk As LinkButton = CType(sender, LinkButton)
        Try
            SetInvoiceInfo(lnk.CommandArgument, lnk.CommandName)
        Catch ex As Exception
        End Try


    End Sub

    Protected Sub imgBtnInvOrderNo_Click(ByVal sender As Object, ByVal e As ImageClickEventArgs)
        Dim imgBtn As ImageButton = CType(sender, ImageButton)

        Try
            SetInvoiceInfo(imgBtn.CommandArgument, imgBtn.CommandName)
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "<<< <<< <<< <<< <<< Helper functions/Procedure >>> >>> >>> >>> >>>"


    Private Sub SetOrderDetails()

        Trace.Write("Start to set data source for order details.")
        Dim dr As SqlDataReader

        Try
            dr = objCXLOrder.AccGetOrderDetails(CustomerID)
            dgrdOrderDetails.DataSource = dr
            dgrdOrderDetails.DataBind()

            Trace.Write("End to set data source for order details.")
        Catch ex As Exception
        Finally

        End Try

    End Sub

    Private Sub SetInvoiceDetails()

        Trace.Write("Start to set data source for Invoice details.")
        Dim dr As SqlDataReader

        Try
            dr = objCXLOrder.AccGetInvoiceDetails(CustomerID)
            dgrdInvoiceDetail.DataSource = dr
            dgrdInvoiceDetail.DataBind()
            Trace.Write("End to set data source for Invoice details.")
        Catch ex As Exception
        Finally
            If dr.IsClosed Then
                dr.Close()
            End If
        End Try
    End Sub

    Private Sub SetOrderInfo(ByVal OrderID As Integer)

        lblOrderNo.Text = OrderID

        Dim dr As SqlDataReader

        Try
            Trace.Write("Start to set data source for specific order no. " & OrderID)

            dr = objCXLOrder.AccGetOrderDetails(CustomerID, OrderID)
            dgrdOrder.DataSource = dr
            dgrdOrder.DataBind()

            Trace.Write("End to set data source for specific order no. " & OrderID)

            ShowPanels(False, False, True, False)
        Catch ex As Exception
        Finally
            If Not dr.IsClosed Then
                dr.Close()
            End If
        End Try


    End Sub

    Private Sub SetInvoiceInfo(ByVal InvoiceNo As Integer, ByVal OrderID As Integer)

        lblInvOrderNo.Text = OrderID
        lblInvoiceNo.Text = InvoiceNo

        Dim dr As SqlDataReader

        Try
            Trace.Write("Start to set data source for specific invoice no. " & InvoiceNo)
            dr = objCXLOrder.AccGetInvoiceInfo(InvoiceNo)
            dgrdInvoice.DataSource = dr
            dgrdInvoice.DataBind()

            Trace.Write("End to set data source for specific invoice no. " & InvoiceNo)
            ShowPanels(False, False, False, True)
        Catch ex As Exception
        Finally

            If Not dr.IsClosed Then
                dr.Close()
            End If
        End Try

    End Sub

    Private Sub ShowPanels(ByVal isOrderDetail As Boolean, ByVal isInvoiceDetail As Boolean, ByVal isOrder As Boolean, ByVal isInvoice As Boolean)

        pnlOrderDetails.Visible = isOrderDetail
        pnlInvoiceDetails.Visible = isInvoiceDetail
        pnlOrder.Visible = isOrder
        pnlInvoice.Visible = isInvoice
    End Sub

#End Region

End Class

#End Region

#Region "::::::::::::::::::: Enum --> PDFFileSize :::::::::::::::::::"

Public Enum PDFFileSize
    A3
    A4
    A5
    B4
    B5
    Letter
    Legal
    Tabloid
    Ledger
    Statement
    Executive
    Folio
    Quarto
End Enum

#End Region