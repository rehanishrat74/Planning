Option Explicit On 
Option Strict Off

Imports System.Data
Imports InfiniLogic.AccountsCentre.common

Imports System.IO
Imports System.Text

Imports System.Xml

Imports System.Data.Common
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Imports System.Web.UI.WebControls
Public Class OrderDetail
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

    Private ViewState_OrderID As String = "ViewState_OrderID"
    Protected WithEvents lblMsg As System.Web.UI.WebControls.Label
    Protected WithEvents lblOrderNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblPayProcess As System.Web.UI.WebControls.Label
    Protected WithEvents lblShipDate As System.Web.UI.WebControls.Label
    Protected WithEvents lblMerchantNote As System.Web.UI.WebControls.Label
    Protected WithEvents lblTrackID As System.Web.UI.WebControls.Label
    Protected WithEvents lblInvoiceNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblShipStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblPayStatus As System.Web.UI.WebControls.Label
    Protected WithEvents lblShipCharges As System.Web.UI.WebControls.Label
    Protected WithEvents lblVATonShip As System.Web.UI.WebControls.Label
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalAmount As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotalShipCharges As System.Web.UI.WebControls.Label
    Protected WithEvents lblTotal As System.Web.UI.WebControls.Label
    Protected WithEvents pnlOrderDetail As System.Web.UI.WebControls.Panel
    Protected WithEvents tdVATonShip As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btnRepay As System.Web.UI.WebControls.Button
    Protected WithEvents grdProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblMerchant As System.Web.UI.WebControls.Label
    Protected WithEvents lblCustomer As System.Web.UI.WebControls.Label
    Protected WithEvents lblAccountNo As System.Web.UI.WebControls.Label
    Protected WithEvents lblCCode As System.Web.UI.WebControls.Label
    Protected WithEvents lblMLoginID As System.Web.UI.WebControls.Label
    Protected WithEvents lblLoginID As System.Web.UI.WebControls.Label
    Protected WithEvents lblMTelephone As System.Web.UI.WebControls.Label
    Protected WithEvents lblTelephone As System.Web.UI.WebControls.Label
    Protected WithEvents lblMEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblEmail As System.Web.UI.WebControls.Label
    Protected WithEvents lblAddress As System.Web.UI.WebControls.Label
    Protected WithEvents lblStreet As System.Web.UI.WebControls.Label
    Protected WithEvents lblTown As System.Web.UI.WebControls.Label
    Protected WithEvents lblMCountry As System.Web.UI.WebControls.Label
    Protected WithEvents lblCountry As System.Web.UI.WebControls.Label
    Dim _Activity As InfiniLogic.BusinessPlan.BLLRules.Activity



#Region "Class Variables"
    Private ViewState_ResellerID As String = "ViewState_ResellerID"

    Dim cp As New Cryptography
    Dim cText As String
#End Region
    Private Sub ShowOrderDetails()
        lblMsg.Text = String.Empty
        lblMsg.ForeColor = Drawing.Color.Red
        Dim orderID As String = Request.QueryString("OrderID")
        Dim Trackid As String = Request.QueryString("Trackid")
        Dim Session_MerchantID As Integer

        Session_MerchantID = GetConnectionData.CustomerID



        Dim dblOrderAmt As Double
        '
        If Not (orderID Is Nothing) And orderID.Trim <> String.Empty And Session_MerchantID > 0 Then

            Dim drOrderInfo As DataRow = _Activity.GetOrderInfo(Session_MerchantID, orderID)
            If Not drOrderInfo Is Nothing Then
                ViewState(ViewState_OrderID) = orderID
                ViewState(ViewState_ResellerID) = Session_MerchantID
                lblOrderNo.Text = orderID

                Dim dsMerchantInfo As DataSet = _Activity.GetMerchantInfo_MerchantID(Session_MerchantID)

                If Not dsMerchantInfo Is Nothing And dsMerchantInfo.Tables.Count <> 0 And dsMerchantInfo.Tables(0).Rows.Count <> 0 Then
                    Dim PayProcessBy As String = dsMerchantInfo.Tables(0).Rows(0).Item("ccProcBy")

                    Select Case UCase(PayProcessBy)
                        Case "W"
                            PayProcessBy = "World Pay"
                        Case "P"
                            PayProcessBy = "Paypal"
                        Case "PE"
                            PayProcessBy = "Paypal Express"
                        Case "G"
                            PayProcessBy = "Google Checkout"
                        Case "A", "C"
                            PayProcessBy = "Accounts Centre"
                        Case "S"
                            PayProcessBy = "Self"
                    End Select
                    lblPayProcess.Text = PayProcessBy
                End If


                lblShipDate.Text = drOrderInfo("cart_invoice_shipdate") & ""
                lblMerchantNote.Text = drOrderInfo("merchantNote") & ""
                lblTrackID.Text = drOrderInfo("trackId") & ""
                lblInvoiceNo.Text = IIf(Val(drOrderInfo("InvoiceNo") & "") = 0, "", Session_MerchantID & " / " & Val(drOrderInfo("InvoiceNo") & ""))
                lblShipStatus.Text = IIf(drOrderInfo("cart_invoice_shipdate") & "" = "", "Not Shipped", drOrderInfo("cart_invoice_shipdate") & "")

                Dim PayStatus As String = String.Empty
                Dim PayStatusFlag As String = drOrderInfo("Payment_Status") & ""

                '--------------Modification---------Start
                'Date: 02-April-2009
                HttpContext.Current.Trace.Write("Calling GETINVOICEPAYSTATUS")
                Dim PaidInvoice As Boolean '= CAM.ADMIN.BLL.Invoices.GETINVOICEPAYSTATUS(Session_MerchantID, drOrderInfo("InvoiceNo"))   '///Modified by GQ on 14052009 due to error in null value
                If Not IsDBNull(drOrderInfo("InvoiceNo")) Then
                    PaidInvoice = _Activity.GETINVOICEPAYSTATUS(Session_MerchantID, drOrderInfo("InvoiceNo"))
                End If
                HttpContext.Current.Trace.Write("GETINVOICEPAYSTATUS is ok: PaidInvoice=" & PaidInvoice)
                If Not PaidInvoice Then
                    PayStatusFlag = ""
                End If
                '--------------Modification---------End

                Select Case PayStatusFlag
                    Case "", "R", "N"
                        PayStatus = "Processing"
                    Case "Y"
                        PayStatus = "Payment Processed"
                    Case "P"
                        PayStatus = "Partial Payment"
                    Case "D"
                        PayStatus = "Declined"
                End Select
                Dim MerchantID As String = Session_MerchantID
                Trace.Write("MerchantID = " & MerchantID)



                Dim objResult As Infinilogic.BusinessPlan.BLLRules.Activity.GetPaymentModeResult
                objResult = _Activity.GetPaymentMode(MerchantID, orderID)
                If objResult.PaymentMode.ToUpper = "CC" Then

                ElseIf objResult.PaymentMode.ToUpper = "CB" Then

                Else
                    Dim IsCouponAvailable As Boolean = False
                    Try
                        IsCouponAvailable = _Activity.IsCouponAvailable(MerchantID, orderID)
                    Catch ex As Exception
                    End Try


                    If IsCouponAvailable Then
                        btnRepay.Text = "Process Order"
                        btnRepay.Visible = True
                    Else
                        btnRepay.Visible = False
                    End If
                End If
                lblPayStatus.Text = PayStatus

                If Not IsDBNull(drOrderInfo("PurchaseOrderRefNo")) Then Label1.Text = drOrderInfo("PurchaseOrderRefNo") Else Label1.Text = "N/A"



                Dim MerchantCurrencySign As String = _Activity.GetCurrencySign(Session_MerchantID)
                lblShipCharges.Text = MerchantCurrencySign & " " & FormatNumber(Val(drOrderInfo("Carriage") & ""), 2, , , TriState.False)
                lblVATonShip.Text = MerchantCurrencySign & " " & FormatNumber(Val(drOrderInfo("vat_on_shipment_charges") & ""), 2, , , TriState.False)
                tdVATonShip.InnerText = "VAT on Shipment Charges @" & FormatNumber(Val(drOrderInfo("car_tax_rate") & ""), 2, , , TriState.False) & " %"

                Dim carig As Double = FormatNumber(Val(drOrderInfo("Carriage") & ""), 2, , , TriState.False)
                Dim carig_amt As Double = FormatNumber(Val(drOrderInfo("Carriage_Amount") & ""), 2, , , TriState.False)


                Dim dtOrderProducts As DataTable = _Activity.GetOrderedProducts(Session_MerchantID, orderID)
                If Not dtOrderProducts Is Nothing Then
                    If dtOrderProducts.Rows.Count > 0 Then
                        Dim sumAmount As Double = 0
                        dtOrderProducts.Columns.Add("prodQty")
                        dtOrderProducts.Columns.Add("prodUnitPrice")
                        dtOrderProducts.Columns.Add("prodTaxAmount")
                        dtOrderProducts.Columns.Add("prodAmount")
                        dtOrderProducts.Columns.Add("prodDiscount")
                        For Each drProduct As DataRow In dtOrderProducts.Rows
                            Dim temp As String = FormatNumber(Val(drProduct("qty") & ""), 2)
                            drProduct("prodQty") = FormatNumber(Val(drProduct("qty") & ""), 2, , , TriState.False)

                            temp = FormatNumber(Val(drProduct("unitprice") & ""), 2)
                            drProduct("prodUnitPrice") = FormatNumber(Val(drProduct("unitprice") & ""), 2, , , TriState.False)

                            temp = FormatNumber(Val(drProduct("Tax_Amount") & ""), 2)
                            drProduct("prodTaxAmount") = FormatNumber(Val(drProduct("Tax_Amount") & ""), 2, , , TriState.False)

                            temp = FormatNumber(Val(drProduct("Amount") - drProduct("Discount") & ""), 2)
                            drProduct("prodAmount") = FormatNumber(Val(drProduct("Amount") & ""), 2, , , TriState.False)
                            sumAmount += FormatNumber(Val(drProduct("Amount") & ""), 2, , , TriState.False)

                            temp = FormatNumber(Val(drProduct("Discount") & ""), 2)
                            drProduct("prodDiscount") = FormatNumber(Val(drProduct("Discount") & ""), 2, , , TriState.False)
                            dblOrderAmt += drProduct("Discount")


                        Next
                        grdProducts.DataSource = dtOrderProducts
                        grdProducts.DataBind()

                        lblTotalAmount.Text = MerchantCurrencySign & " " & " " & FormatNumber(sumAmount, 2, , , TriState.False)
                        lblTotalShipCharges.Text = lblShipCharges.Text
                        lblTotal.Text = MerchantCurrencySign & " " & " " & FormatNumber(sumAmount + carig + carig_amt, 2, , , TriState.False)

                        ''''''''''''''''''''''''''''''''''''''
                    End If

                Else
                    lblMsg.Text = "Products Not Available."
                End If
                '''''''''''''''''''''''''''''''''''''''
            Else
                lblMsg.Text = "No Record Found!"
                pnlOrderDetail.Visible = False
            End If
            IntializeControls(Session_MerchantID, Trackid)
        Else
            lblMsg.Text = "Invalid OrderID."
        End If
    End Sub


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Page.IsPostBack Then
            ShowOrderDetails()
        End If
    End Sub


    Private Sub InitializeComponent()

    End Sub
    Protected Sub IntializeControls(ByVal muid As Integer, ByVal rid As Integer)
        Dim cid As Integer
        Dim _cDataSet, _cDataset2 As DataSet


        Dim strLogKey As String

        Dim RetryEnableFlag As Boolean = False
        _cDataSet = _Activity.GetRequestDetail(rid, muid)
        _cDataset2 = _Activity.GetMerchantLogKeyByRequest(rid)

        If Not _cDataset2.Tables(0).Rows.Count = 0 Then
            If Not IsDBNull(_cDataset2.Tables(0).Rows(0).Item("LogKey")) Then strLogKey = _cDataset2.Tables(0).Rows(0).Item("LogKey")
        End If
        cText = "Invoice Charges"
        If Not _cDataSet.Tables(0).Rows.Count = 0 Then
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mname")) Then lblMerchant.Text = _cDataSet.Tables(0).Rows(0).Item("mname")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("publicid")) Then lblAccountNo.Text = cp.DeCrypt(CStr(_cDataSet.Tables(0).Rows(0).Item("publicid")), strLogKey)
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("acctnum")) Then lblMLoginID.Text = _cDataSet.Tables(0).Rows(0).Item("acctnum")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mTelephone")) Then lblMTelephone.Text = _cDataSet.Tables(0).Rows(0).Item("mTelephone")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mStreet")) Then lblAddress.Text = _cDataSet.Tables(0).Rows(0).Item("mStreet")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mTown")) Then lblAddress.Text = lblAddress.Text + "   " + _cDataSet.Tables(0).Rows(0).Item("mTown")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mCountry")) Then lblMCountry.Text = _cDataSet.Tables(0).Rows(0).Item("mCountry")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("mEmail")) Then lblMEmail.Text = _cDataSet.Tables(0).Rows(0).Item("mEmail")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("name")) Then lblCustomer.Text = _cDataSet.Tables(0).Rows(0).Item("name")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("loginid")) Then lblLoginID.Text = _cDataSet.Tables(0).Rows(0).Item("loginid")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("code")) Then lblCCode.Text = _cDataSet.Tables(0).Rows(0).Item("code")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("street")) Then lblStreet.Text = _cDataSet.Tables(0).Rows(0).Item("street")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("town")) Then lblTown.Text = _cDataSet.Tables(0).Rows(0).Item("town")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("telephone")) Then lblTelephone.Text = _cDataSet.Tables(0).Rows(0).Item("telephone")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("email")) Then lblEmail.Text = _cDataSet.Tables(0).Rows(0).Item("email")
            If Not IsDBNull(_cDataSet.Tables(0).Rows(0).Item("country")) Then lblCountry.Text = _cDataSet.Tables(0).Rows(0).Item("country")


        End If
    End Sub

End Class
