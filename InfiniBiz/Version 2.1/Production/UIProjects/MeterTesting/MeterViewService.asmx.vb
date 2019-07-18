 


'Imports System.Web.Services
'Imports System.text
'Imports Infinilogic.BusinessPlan.Web.Common
'Imports System.Resources
'Imports System.Threading
'Imports System.Math
'Imports Infinilogic.BusinessPlan.Common
'Imports Infinilogic.BusinessPlan.BLL
'Imports Infinilogic.BusinessPlan.DAL
'Imports Infinilogic.AccountsCentre.DAL
'Imports System.Data.SqlClient
'Imports System.Windows.Forms
'Imports System.web
'Imports System
'Imports System.Globalization
'Imports System.Web.UI
'Imports System.Web.UI.HtmlControls
'Imports System.Web.UI.UserControl
'Imports System.Web.HttpContext
'Imports System.Web.Security

Imports InfiniLogic.AccountsCentre.common
Imports System.Web.Services
Imports System.data
Imports System.Math
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.IO
Imports InfiniLogic.BusinessPlan.BLLRules
Imports InfiniLogic.BusinessPlan.BLL
Imports InfiniLogic.BusinessPlan.DAL
Imports InfiniLogic.AccountsCentre.DAL
Imports System.text

<System.Web.Services.WebService(Namespace:="http://www.MeterTesting.com")> _
Public Class MeterViewService
    Inherits System.Web.Services.WebService

#Region " Web Services Designer Generated Code "
    Private cust_id As String
    Public Sub New()

        'This call is required by the Web Services Designer.
        InitializeComponent()

        'Add your own initialization code after the InitializeComponent() call

    End Sub





    'Required by the Web Services Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Web Services Designer
    'It can be modified using the Web Services Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        'CODEGEN: This procedure is required by the Web Services Designer
        'Do not modify it using the code editor.
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

#End Region

    Private CustId As Integer
    Private Shared _firstDate As Date
    Private Shared _lastDate As Date
    Shared _newAmt As DataSet
    Shared _newYtd As DataSet
    Shared _PLSnewAmt As DataSet
    Shared _PLSnewYtd As DataSet
    Private _BSViewCurrent As New DataView
    Private _BSViewPrevious As New DataView
    Private bsDV As New DataView

    Dim str As StringBuilder

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello test World"
    End Function

    <WebMethod()> _
     Public Function getMessage() As String
        Return "Flash Remoting makes web services easy!"
    End Function

    <WebMethod()> _
      Public Function getMessage1(ByRef Dat As String) As String

        Return "Flash Remoting makes web services easy!"
    End Function


    <WebMethod(EnableSession:=True)> _
  Public Function GetSingleNodesXML(ByVal PRODUCT_ID As String, ByVal Planid As String, ByVal Customerid As String, ByVal ProSdate As String, ByVal ProEdate As String, ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String, ByVal SingleAnalysisOption As String) As String

        Dim connData As New ConnectionData

        Dim cust_id As Integer = Customerid
        Dim intPlanSdate As Integer = PlanSdate
        Dim intPlanEdate As Integer = PlanEdate
        Try
            Dim ds As DataSet
            connData.CustomerID = cust_id

            Dim cmd As New CommandData(connData.CustomerID)
            cmd.CmdText = "bpl_GetSingleNodesXML"
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.AddParameter("@PRODUCT_ID", PRODUCT_ID)
            cmd.AddParameter("@Planid", Planid)
            cmd.AddParameter("@ProSdate", ProSdate)
            cmd.AddParameter("@ProEdate", ProEdate)
            cmd.AddParameter("@PlanSdate", intPlanSdate)
            cmd.AddParameter("@PlanEdate", intPlanEdate)

            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Dim RetNode As String = callmeforNodeXML(ds, getCurrency, SingleAnalysisOption)
            Return RetNode
            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
        Catch ex As Exception

            Dim body As String
            Server.ClearError()
            body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
                    "Machine            : " & MyBase.Server.MachineName & "<br>" & _
                    "Source     : " & ex.Source.ToString & "<br>" & _
                    "Messege    : " & ex.Message.ToString & "<br>"
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        Finally


        End Try




    End Function

    Public Function callmeforNodeXML(ByVal ds As DataSet, ByVal Currency As String, ByVal SingleAnalysisOption As String) As String
        Dim Nodeitem As StringBuilder
        Dim loop1 As Integer
        Dim MTD As String = "June"
        Dim MTY As String = "2007"
        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder
        If SingleAnalysisOption = ID.ist Then
            Nodeitem.Append("<Root>")
            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
                Nodeitem.Append("<Product" + CStr(loop1) + ">")
                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(5)) + qoute + " />")
                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(4)) + qoute + " />")
                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(4), Double), "f") + Currency + qoute + " />")
                Nodeitem.Append("</Product" + CStr(loop1) + ">")

            Next
            Nodeitem.Append("</Root>")
        ElseIf SingleAnalysisOption = ID.second Then
            Nodeitem.Append("<Root>")
            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
                Nodeitem.Append("<Product" + CStr(loop1) + ">")
                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(7)) + qoute + " />")
                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(6)) + qoute + " />")
                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(6), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(6), Double), "f") + Currency + qoute + " />")
                Nodeitem.Append("</Product" + CStr(loop1) + ">")

            Next
            Nodeitem.Append("</Root>")
        ElseIf SingleAnalysisOption = ID.third Then
            Nodeitem.Append("<Root>")
            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
                Nodeitem.Append("<Product" + CStr(loop1) + ">")
                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(5)) + qoute + " />")
                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(4)) + qoute + " />")
                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(4), Double), "f") + Currency + qoute + " />")
                Nodeitem.Append("</Product" + CStr(loop1) + ">")

            Next
            Nodeitem.Append("</Root>")
        End If

        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function

    <WebMethod(EnableSession:=True)> _
   Public Function GetMultipleNodesXML(ByVal PRODUCT_IDs As String, ByVal Planid As String, ByVal Customerid As String, ByVal ProSdate As String, ByVal ProEdate As String, ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String, ByVal MultiAnalysisOption As String) As String
        Dim connData As New ConnectionData
        Dim cust_id As Integer = Customerid
        Dim intPlanSdate As Integer = PlanSdate
        Dim intPlanEdate As Integer = PlanEdate
        Try
            Dim dtvalueMTD As DataTable
            Dim dtvalueMTY As DataTable
            connData.CustomerID = cust_id

            Dim cmd As New CommandData(connData.CustomerID)

            cmd.CmdText = "bpl_GetNodesXML"
            cmd.AddParameter("@MIdentity", Customerid)
            cmd.AddParameter("@PRODUCT_ID", "0")
            cmd.AddParameter("@Planid", Planid)

            cmd.AddParameter("@ProSdate", ProSdate)
            cmd.AddParameter("@ProEdate", ProEdate)
            cmd.AddParameter("@PlanSdate", intPlanSdate)
            cmd.AddParameter("@PlanEdate", intPlanEdate)

            dtvalueMTD = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)

            Dim RetNode As String = callmeforMultipleNodeXML(dtvalueMTD, dtvalueMTY, PRODUCT_IDs, getCurrency, MultiAnalysisOption)
            Return RetNode
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
                    "Machine            : " & MyBase.Server.MachineName & "<br>" & _
                    "Source     : " & ex.Source.ToString & "<br>" & _
                    "Messege    : " & ex.Message.ToString & "<br>"
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        End Try

    End Function

    Public Function callmeforMultipleNodeXML(ByVal dtMTD As DataTable, ByVal dtMTY As DataTable, ByVal PRODUCTS_IDs As String, ByVal Currency As String, ByVal MultiAnalysisOption As String) As String

        Dim intloop As Integer
        Dim Nodeitem As StringBuilder
        Dim Product_id As String() = PRODUCTS_IDs.Split(",")
        Dim dr_Product As DataRow
        Dim dr_ProductYear As DataRow
        Dim da_Product As Array
        Dim da_ProductYearly As Array
        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder

        Nodeitem.Append("<Root>")
        If MultiAnalysisOption = ID.ist Then
            For intloop = 0 To Product_id.Length - 1
                da_Product = dtMTD.Select("productid='" & Product_id(intloop) & "'")

                For Each dr_Product In da_Product
                    Nodeitem.Append("<Product" + CStr(intloop) + ">")
                    Nodeitem.Append("<Path ProductName=" + qoute + CStr(dr_Product(3)) + qoute + "/>")
                    Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(dr_Product(5)) + qoute + " />")
                    Nodeitem.Append("<Path ProPrices=" + qoute + CStr(dr_Product(4)) + qoute + " />")
                    Nodeitem.Append("<Path MTD=" + qoute + Format(CType(dr_Product(4), Double), "f") + qoute + "  MTY=" + qoute + Currency + qoute + " />")
                    Nodeitem.Append("</Product" + CStr(intloop) + ">")
                Next
            Next



        End If



        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function

    <WebMethod(EnableSession:=True)> _
  Public Function GetSingleNodesXML_Basic(ByVal PRODUCT_ID As String, ByVal Planid As String _
  , ByVal Customerid As String, ByVal ProSdate As String, ByVal ProEdate As String _
  , ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String _
  , ByVal SingleAnalysisOption As String, ByVal StartInterval As String, ByVal EndInterval As String _
  , ByVal ChkInterval As Boolean) As String
 
        Dim a As Boolean
        Dim connData As New ConnectionData

        Dim cust_id As Integer = Customerid
        Dim intPlanSdate As Integer = PlanSdate
        Dim intPlanEdate As Integer = PlanEdate
        Try
            Dim ds As DataSet
            connData.CustomerID = cust_id

            Dim cmd As New CommandData(connData.CustomerID)
            If PRODUCT_ID = "*" Then
                cmd.CmdText = "BPL_GetNodeXml_BasicAllProducts"
            Else
                cmd.CmdText = "BPL_GetNodeXml_Basic"
            End If


            cmd.AddParameter("@MIdentity", Customerid)
            cmd.AddParameter("@PRODUCT_ID", PRODUCT_ID)
            cmd.AddParameter("@Planid", Planid)

            cmd.AddParameter("@ProSdate", ProSdate)
            cmd.AddParameter("@ProEdate", ProEdate)

            cmd.AddParameter("@PlanSdate", intPlanSdate)
            cmd.AddParameter("@PlanEdate", intPlanEdate)

            cmd.AddParameter("@StartInterval", StartInterval)
            cmd.AddParameter("@EndInterval", EndInterval)
            cmd.AddParameter("@ChkInterval", ChkInterval)
            '   cmd.AddParameter("@QuantityCheck", QuantityCheck)
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Dim RetNode As String = callmeforNodeXML_Basic(ds, getCurrency, SingleAnalysisOption)
            Return RetNode
            System.Web.HttpContext.Current.Trace.Warn(" GetSingleNodesXML_Basic Completed successfully")
        Catch ex As Exception
            Dim body As String
            Server.ClearError()
            body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
                    "Machine            : " & MyBase.Server.MachineName & "<br>" & _
                    "Source     : " & ex.Source.ToString & "<br>" & _
                    "Messege    : " & ex.Message.ToString & "<br>"
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)
        Finally


        End Try




    End Function


    Public Function callmeforNodeXML_Basic(ByVal ds As DataSet, ByVal Currency As String, ByVal SingleAnalysisOption As String) As String
        Dim Nodeitem As StringBuilder


        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder
        If SingleAnalysisOption = ID.ist Then
            Nodeitem.Append("<Root>")

            Nodeitem.Append("<Product" + CStr(0) + ">")
            Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(0).Item(3)) + qoute + "/>")
            Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(5)) + qoute + " />")
            Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(4)) + qoute + " />")
            Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(1).Rows(0).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(2).Rows(0).Item(4), Double), "f") + Currency + qoute + " />")
            Nodeitem.Append("</Product" + CStr(0) + ">")


            Nodeitem.Append("</Root>")
        ElseIf SingleAnalysisOption = ID.second Then
            Nodeitem.Append("<Root>")

            Nodeitem.Append("<Product" + CStr(0) + ">")
            Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(0).Item(3)) + qoute + "/>")
            Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(7)) + qoute + " />")
            Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(6)) + qoute + " />")
            Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(1).Rows(0).Item(6), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(2).Rows(0).Item(6), Double), "f") + Currency + qoute + " />")
            Nodeitem.Append("</Product" + CStr(0) + ">")


            Nodeitem.Append("</Root>")

        ElseIf SingleAnalysisOption = ID.third Then
            Nodeitem.Append("<Root>")

            Nodeitem.Append("<Product" + CStr(0) + ">")
            Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(0).Item(3)) + qoute + "/>")
            Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(5)) + qoute + " />")
            Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(4)) + qoute + " />")
            Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(1).Rows(0).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(2).Rows(0).Item(4), Double), "f") + Currency + qoute + " />")
            Nodeitem.Append("</Product" + CStr(0) + ">")


            Nodeitem.Append("</Root>")


        End If

        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function

    <WebMethod(EnableSession:=True)> _
     Public Function GetMerchantMeters(ByVal Customerid As String, ByVal Fromdate As String, ByVal Todate As String, ByVal Fromdatelastday As String, ByVal Todatedaylastday As String, ByVal getCurrency As String) As String

        Dim connData As New ConnectionData

        Dim dsCurrent As DataView, dsPrevious As DataView
        Dim cust_id As Integer = Customerid
        Dim RetNode As String
        Try
            Dim ds As DataSet
            connData.CustomerID = cust_id
            Dim cmda As New SqlCommand

            Dim cmd As New CommandData(connData.CustomerID)
            ' cmd.ConnectionTimeOut = 0
            'If cust_id <> "2" Then
            cmd.CmdText = "BPL_MerchantMeter"
            cmd.AddParameter("@Fromdate", Fromdate)
            cmd.AddParameter("@Todate", Todate)
            cmd.AddParameter("@Fromdatelastday", Fromdatelastday)
            cmd.AddParameter("@Todatedaylastday", Todatedaylastday)
            cmd.AddParameter("@MIdentity", Customerid)
       

            'dsCurrent = Plan.ProfitAndLossStatement(cust_id, Fromdate, Todate)
            'dsPrevious = Plan.ProfitAndLossStatement(cust_id, Fromdatelastday, Todatedaylastday)
            'RetNode = GetMerchantMetersXMLForM2(dsCurrent, dsPrevious, getCurrency)
            ' End If
            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            RetNode = GetMerchantMetersXML(ds, getCurrency)
            Return RetNode
            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
        Catch ex As Exception

            Dim body As String
            Server.ClearError()
            body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
                    "Machine            : " & MyBase.Server.MachineName & "<br>" & _
                    "Source     : " & ex.Source.ToString & "<br>" & _
                    "Messege    : " & ex.Message.ToString & "<br>"
            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)

        Finally


        End Try




    End Function

    Public Function GetMerchantMetersXML(ByVal ds As DataSet, ByVal Currency As String) As String
        Dim Nodeitem As StringBuilder


        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder

        Nodeitem.Append("<Root>")

        Nodeitem.Append("<Product" + CStr(0) + ">")
        Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(1)) + qoute + " />")
        Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(0).Item(0)) + qoute + " />")

        Nodeitem.Append("</Product" + CStr(0) + ">")


        Nodeitem.Append("</Root>")



        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function

    Public Function GetMerchantMetersXMLForM2(ByVal dvCurrent As DataView, ByVal dvPast As DataView, ByVal Currency As String) As String
        Dim Nodeitem As StringBuilder


        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder

        Nodeitem.Append("<Root>")

        Nodeitem.Append("<Product" + CStr(0) + ">")
        Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(dvPast.Table.Rows(dvPast.Table.Rows.Count - 1).Item("Current")) + qoute + " />")
        Nodeitem.Append("<Path ProPrices=" + qoute + CStr(dvCurrent.Table.Rows(dvCurrent.Table.Rows.Count - 1).Item("Current")) + qoute + " />")

        Nodeitem.Append("</Product" + CStr(0) + ">")


        Nodeitem.Append("</Root>")



        Dim strNode = Nodeitem.ToString
        Return strNode

    End Function


    <WebMethod(EnableSession:=True)> _
    Public Function Calme(ByVal str As String) As String
        Dim Nodeitem As StringBuilder


        Dim qoute As Char = """"c
        Nodeitem = New StringBuilder
        Nodeitem.Append("<Root>")

        Nodeitem.Append("<Product" + CStr(0) + ">")
        Nodeitem.Append("<Path ProductName=" + qoute + str + "hafiz" + qoute + "/>")
        Nodeitem.Append("</Product" + CStr(0) + ">")


        Nodeitem.Append("</Root>")

        Dim strNode = Nodeitem.ToString
        Return strNode
    End Function

    <WebMethod(EnableSession:=True)> _
         Public Function LoadEnterpriseMeters(ByVal Customerid As String, ByVal strStartDate As String, ByVal strEndDate As String, ByVal strStartLastDate As String, ByVal strEndLastDate As String, ByVal getCurrency As String, ByVal strType As String) As String
        Dim RetNode As String
        Dim connData As New ConnectionData
        Dim cust_id As Integer = Customerid
        Dim Meterbit As Integer

        Try
            Dim ds As DataSet
            connData.CustomerID = cust_id

            Dim cmd As New CommandData(connData.CustomerID)

            If Trim(strType) = "Sales" Then
                Meterbit = 1
                cmd.CmdText = "BPL_GetEnterpriseMeterForIO"
                cmd.AddParameter("@MIdentity", Customerid)
                cmd.AddParameter("@Fromdate", strStartDate)
                cmd.AddParameter("@Todate", strEndDate)
                cmd.AddParameter("@FromLastdate", strStartLastDate)
                cmd.AddParameter("@ToLastdate", strEndLastDate)
                cmd.AddParameter("@Meterbit", Meterbit)
                ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                RetNode = GetEnterpriseMetersXML(ds, getCurrency, strType)

            ElseIf Trim(strType) = "COGS" Then
                Meterbit = 2
                cmd.CmdText = "BPL_GetEnterpriseMeterForIO"
                cmd.AddParameter("@MIdentity", Customerid)
                cmd.AddParameter("@Fromdate", strStartDate)
                cmd.AddParameter("@Todate", strEndDate)
                cmd.AddParameter("@FromLastdate", strStartLastDate)
                cmd.AddParameter("@ToLastdate", strEndLastDate)
                cmd.AddParameter("@Meterbit", Meterbit)
                ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                RetNode = GetEnterpriseMetersXML(ds, getCurrency, strType)

            ElseIf Trim(strType) = "Overheads" Then
                Meterbit = 3
                cmd.CmdText = "BPL_GetEnterpriseMeterForIO"
                cmd.AddParameter("@MIdentity", Customerid)
                cmd.AddParameter("@Fromdate", strStartDate)
                cmd.AddParameter("@Todate", strEndDate)
                cmd.AddParameter("@FromLastdate", strStartLastDate)
                cmd.AddParameter("@ToLastdate", strEndLastDate)
                cmd.AddParameter("@Meterbit", Meterbit)
                ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                RetNode = GetEnterpriseMetersXML(ds, getCurrency, strType)

            ElseIf Trim(strType) = "Profit" Then
                Meterbit = 4
                cmd.CmdText = "BPL_GetEnterpriseMeterForIO"
                cmd.AddParameter("@MIdentity", Customerid)
                cmd.AddParameter("@Fromdate", strStartDate)
                cmd.AddParameter("@Todate", strEndDate)
                cmd.AddParameter("@FromLastdate", strStartLastDate)
                cmd.AddParameter("@ToLastdate", strEndLastDate)
                cmd.AddParameter("@Meterbit", Meterbit)
                ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
                RetNode = GetEnterpriseMetersXML(ds, getCurrency, strType)

            ElseIf Trim(strType) = "ROI" Then
                System.Web.HttpContext.Current.Trace.Warn("InfiniPlan RIOCalculation LoadEnterpriseMeters")
                Meterbit = 5
                RetNode = RIOCalculation(Customerid, strStartDate, strEndDate, strStartLastDate, strEndLastDate, strType)
            End If

            Return RetNode

            System.Web.HttpContext.Current.Trace.Warn("Completed successfully")
        Catch ex As Exception

            Dim body As String
            Server.ClearError()
            ''body = "Customer (Devlopment)   : " & Customerid & "<br>" & _
            ''        "Machine            : " & MyBase.Server.MachineName & "<br>" & _
            ''        "Source     : " & ex.Source.ToString & "<br>" & _
            ''        "Messege    : " & ex.Message.ToString & "<br>"

            body = ExceptionFormatter2.Formatter.HandleException(ex, "bizplan.errors@accountscentre.com", "support@infinibiz.com", "InfiniPlan")

            CommonBase.SendEmail(ConfigReader.GetItem(ConfigVariables.SMTPUserID), "bizplan.errors@accountscentre.com", "Speedoemter Errors", body, Mail.MailFormat.Html)

            System.Web.HttpContext.Current.Trace.Warn("EXCEPTION")
            System.Web.HttpContext.Current.Trace.Warn("Message: " & ex.Message)
            System.Web.HttpContext.Current.Trace.Warn("StackTrace: " & ex.StackTrace)



        Finally


        End Try
    End Function


    Dim ListMeterType As String() = {"Sales", "COGS", "Overheads", "Profit", "ROI"}

    Public Function GetEnterpriseMetersXML(ByVal ds As DataSet, ByVal Currency As String, ByVal MeterType As String) As String
        Dim EnterPriseNodeitem As StringBuilder

        Dim PlanSales As Double
        Dim ProSales As Double

        Dim PlanCOGS As Double
        Dim ProCOGS As Double
        Dim PlanOverhead As Double
        Dim ProOverhead As Double
        Dim PlanProfit As Double
        Dim ProProfit As Double
        Dim qoute As Char = """"c
        EnterPriseNodeitem = New StringBuilder

        EnterPriseNodeitem.Append("<Root meterType='" & MeterType.Trim & "'>")
        If Trim(MeterType) = ListMeterType.GetValue(0) Then
            ' Sales 
            PlanSales = ds.Tables(1).Rows(0).Item(0)
            ProSales = ds.Tables(0).Rows(0).Item(0)

            If (ProSales < 0) Then
                ProSales = "0.0"
            End If

            If (PlanSales < 0) Then
                PlanSales = "0.0"
            End If

            EnterPriseNodeitem.Append("<Product" + CStr(0) + ">")
            EnterPriseNodeitem.Append("<Path PlanPrices=" + qoute + CStr(PlanSales) + qoute + " />")
            EnterPriseNodeitem.Append("<Path ProPrices=" + qoute + CStr(ProSales) + qoute + " />")
            EnterPriseNodeitem.Append("</Product" + CStr(0) + ">")

        ElseIf Trim(MeterType) = ListMeterType.GetValue(1) Then
            ' COGS

            PlanCOGS = ds.Tables(1).Rows(0).Item(0)
            ProCOGS = ds.Tables(0).Rows(0).Item(0)

            If (ProCOGS < 0) Then
                ProCOGS = "0.0"
            End If
            If (PlanCOGS < 0) Then
                PlanCOGS = "0.0"
            End If

            EnterPriseNodeitem.Append("<Product" + CStr(0) + ">")
            EnterPriseNodeitem.Append("<Path PlanPrices=" + qoute + CStr(PlanCOGS) + qoute + " />")
            EnterPriseNodeitem.Append("<Path ProPrices=" + qoute + CStr(ProCOGS) + qoute + " />")
            EnterPriseNodeitem.Append("</Product" + CStr(0) + ">")

        ElseIf Trim(MeterType) = ListMeterType.GetValue(2) Then
            ' Overheads 

            PlanOverhead = ds.Tables(1).Rows(0).Item(0) + ds.Tables(3).Rows(0).Item(0)
            ProOverhead = ds.Tables(0).Rows(0).Item(0) + ds.Tables(2).Rows(0).Item(0)


            If (PlanOverhead < 0) Then
                PlanOverhead = "0.0"
            End If
            If (ProOverhead < 0) Then
                ProOverhead = "0.0"
            End If

            EnterPriseNodeitem.Append("<Product" + CStr(0) + ">")
            EnterPriseNodeitem.Append("<Path PlanPrices=" + qoute + CStr(PlanOverhead) + qoute + " />")
            EnterPriseNodeitem.Append("<Path ProPrices=" + qoute + CStr(ProOverhead) + qoute + " />")
            EnterPriseNodeitem.Append("</Product" + CStr(0) + ">")

        ElseIf Trim(MeterType) = ListMeterType.GetValue(3) Then

            PlanProfit = ds.Tables(1).Rows(0).Item(0) - (ds.Tables(3).Rows(0).Item(0) + ds.Tables(5).Rows(0).Item(0) + ds.Tables(7).Rows(0).Item(0))
            ProProfit = ds.Tables(0).Rows(0).Item(0) - (ds.Tables(2).Rows(0).Item(0) + ds.Tables(4).Rows(0).Item(0) + ds.Tables(6).Rows(0).Item(0))


            If (ProProfit < 0) Then
                ProProfit = "0.0"
            End If
            If (PlanProfit < 0) Then
                PlanProfit = "0.0"
            End If

            ' Profit
            EnterPriseNodeitem.Append("<Product" + CStr(0) + ">")
            EnterPriseNodeitem.Append("<Path PlanPrices=" + qoute + CStr(PlanProfit) + qoute + " />")
            EnterPriseNodeitem.Append("<Path ProPrices=" + qoute + CStr(ProProfit) + qoute + " />")
            EnterPriseNodeitem.Append("</Product" + CStr(0) + ">")


        End If

        EnterPriseNodeitem.Append("</Root>")

        Dim strEnterpriseNode = EnterPriseNodeitem.ToString
        Return strEnterpriseNode

    End Function

    Public Function RIOCalculation(ByVal Customerid As String, ByVal startdatefrom As Date, ByVal startdateto As Date, ByVal Previousdatefrom As Date, ByVal Previousdateto As Date, ByVal MeterType As String) As String
        System.Web.HttpContext.Current.Trace.Warn("InfiniPlan RIOCalculation Webservice start")

        Dim _BSXmlAsset As String, _BSXmlAssetFixed As String, _BSXmlCapital As String, _BSXmlAssetPre As String
        Dim _BSXmlAssetFixedPre As String, _BSXmlCapitalPre As String


        _BSViewCurrent = BalanceSheet(Customerid, startdatefrom, startdateto)
        _BSViewPrevious = BalanceSheet(Customerid, Previousdatefrom, Previousdateto)

        If Not _BSViewCurrent Is Nothing Then
            _BSXmlAsset = GetBalanceSheetValues(startdatefrom, startdateto, "Total current Assets")
            _BSXmlAssetFixed = GetBalanceSheetValues(startdatefrom, startdateto, "Total Fixed Assets")
            _BSXmlCapital = GetBalanceSheetValues(startdatefrom, startdateto, "Net Capital :")


        Else

            _BSXmlAsset = "0.0"
            _BSXmlAssetFixed = "0.0"
            _BSXmlCapital = "0.0"


        End If

        If Not _BSViewPrevious Is Nothing Then
            _BSXmlAssetPre = GetBalanceSheetValuesPrevious(Previousdatefrom, Previousdateto, "Total current Assets")
            _BSXmlAssetFixedPre = GetBalanceSheetValuesPrevious(Previousdatefrom, Previousdateto, "Total Fixed Assets")
            _BSXmlCapitalPre = GetBalanceSheetValuesPrevious(Previousdatefrom, Previousdateto, "Net Capital :")


        Else

            _BSXmlAssetPre = "0.0"
            _BSXmlAssetFixedPre = "0.0"
            _BSXmlCapitalPre = "0.0"


        End If



        Dim NodeitemROI As StringBuilder

        Dim qoute As Char = """"c
        NodeitemROI = New StringBuilder
        NodeitemROI.Append("<Root meterType='" & MeterType.Trim & "'>")

        NodeitemROI.Append("<Product" + "ROI" + ">")

        Dim TotalAssets As Double = CType(_BSXmlAsset, Double) + CType(_BSXmlAssetFixed, Double)
        Dim TotalAssetsPre As Double = CType(_BSXmlAssetPre, Double) + CType(_BSXmlAssetFixedPre, Double)


        Dim ROIPrevious As Double
        Dim ROICurrent As Double


        If (TotalAssets <= 0 Or _BSXmlCapital <= 0) Then
            ROICurrent = 0
        Else
            ROICurrent = _BSXmlCapital / TotalAssets * 100
        End If

        If (TotalAssetsPre <= 0 Or _BSXmlCapitalPre <= 0) Then
            ROIPrevious = 0
        Else
            ROIPrevious = _BSXmlCapitalPre / TotalAssetsPre * 100
        End If



        NodeitemROI.Append("<Path PlanPrices=" + qoute + CStr(ROIPrevious.ToString) + qoute + " />")
        NodeitemROI.Append("<Path ProPrices=" + qoute + CStr(ROICurrent.ToString) + qoute + " />") '
        NodeitemROI.Append("</Product" + "ROI" + ">")

        NodeitemROI.Append("</Root>")
        Dim strNodeROI = NodeitemROI.ToString
        System.Web.HttpContext.Current.Trace.Warn("strNodeROI" + strNodeROI)
        Return strNodeROI


    End Function

    Private Function GetBalanceSheetValues(ByVal fromDate As Date, ByVal toDate As Date, ByVal findingValues As String) As String

        _BSViewCurrent.RowFilter = "Description='" & findingValues & "'"
        If _BSViewCurrent.Count > 0 Then
            Dim drvItem As DataRowView = _BSViewCurrent.Item(0)
            Dim Value As Object = drvItem.Item(2)
            Return FormatNumber(_BSViewCurrent.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If
    End Function

    Private Function GetBalanceSheetValuesPrevious(ByVal fromDate As Date, ByVal toDate As Date, ByVal findingValues As String) As String

        _BSViewPrevious.RowFilter = "Description='" & findingValues & "'"
        HttpContext.Current.Trace.Write(_BSViewPrevious.Count.ToString)
        If _BSViewPrevious.Count > 0 Then
            Dim drvItem1 As DataRowView = _BSViewPrevious.Item(0)
            Dim Value1 As Object = drvItem1.Item(2)
            Return FormatNumber(_BSViewPrevious.Item(0).Item(2).ToString, 2, , , 0)
        Else
            Return "0.0"
        End If
    End Function

    Public Shared Function BSLastRecord(ByVal CustomerID As Integer) As String

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As CommandData
        Dim _strFA_NC_DET As String, _strCA_NC_DET As String, _strCL_NC_DET As String, _strCR_NC_DET As String, _strContString As String

        'Fixed Assets
        _objCmd = New CommandData(CustomerID)
        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_BSLASTRECORD"
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_FIXASSET_NC" & ex.Message)
            End Try
        End With
        _strFA_NC_DET = CStr(_ds.Tables(0).Rows(0).Item(0))

        _strCA_NC_DET = CStr(_ds.Tables(1).Rows(0).Item(0))

        _strCL_NC_DET = CStr(_ds.Tables(2).Rows(0).Item(0))

        _strCR_NC_DET = CStr(_ds.Tables(3).Rows(0).Item(0))


        _strContString = _strFA_NC_DET & "," & _strCA_NC_DET & "," & _strCL_NC_DET & "," & _strCR_NC_DET

        Return _strContString
    End Function

    Public Shared Function GetLedgerIDForBS(ByVal customerID As Integer) As DataSet

        Dim _objCmd As New CommandData(customerID)
        Dim _ds As DataSet

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETLEDGERIDFORBS"

            Try
                .AddParameter("@MIdentity", customerID)
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORBS" & ex.Message)
            End Try

            Return _ds
        End With

    End Function

    Public Shared Function GetBalanceSheetCurrentAmt(ByVal daAllLedgersAMT As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double

        For Each _dr In daAllLedgersAMT
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)

        Next
        _totalAmt = _debit - _credit
        Return _totalAmt


    End Function

    Public Shared Function GetBalanceSheetCurrentYTD(ByVal daAllLedgersYTD As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double



        For Each _dr In daAllLedgersYTD
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next


        _totalAmt = _debit - _credit
        Return _totalAmt


    End Function

    Public Shared Function GetLedgerIDForPANDF(ByVal customerID As Integer) As DataSet

        Dim _objCmd As New CommandData(customerID)
        Dim _ds As DataSet

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETLEDGERIDFORPANDL"
            .AddParameter("@MIdentity", customerID)
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETLEDGERIDFORPANDL" & ex.Message)
            End Try

            Return _ds
        End With

    End Function

    Public Shared Function GetModifiedBalanceSheetCurrentAmt(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try

            Return _ds

        End With
    End Function

    Public Shared Function GetModifiedBalanceSheetYTDAmt(ByVal CustomerID As Integer, ByVal _mydate As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETBALANCESHEETYTDAMT"

            .AddParameter("@mydate", _mydate)
            .AddParameter("@MIdentity", CustomerID)
            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETYTDAMT" & ex.Message)
            End Try

            Return _ds

        End With
    End Function

    Public Shared Function BalanceSheet(ByVal Customerid As String, ByVal datefrom As Date, ByVal dateto As Date) As DataView

        System.Web.HttpContext.Current.Trace.Warn("BalanceSheet start ")
        Dim _ds As DataSet, _dr As DataRow, _ds1 As DataSet, _dr1 As DataRow
        Dim _strChk As String, _strLastRecord As String, _strArry() As String, _lowLID As String, _highLID As String, _togle As String
        Dim _strSA As String, _strFA As String, _strCA As String, _strCL As String, _strCR As String, _mHead As String, _mHDesc As String
        Dim _currentAmt As Double, _yTDAmt As Double, _bolChkFA As Boolean, _bolChkCA As Boolean, _bolChkCL As Boolean, _bolChkCR As Boolean
        Dim _myFEDate As Date
        Dim _dblGrPFA As Double, _dblGrpCA As Double, _dblGrpCL As Double, _dblGrpCR As Double, _dblCATogleCurrentAmt As Double, _dblCATogleYTDAmt As Double
        Dim _dblGrPYTDFA As Double, _dblGrpYTDCA As Double, _dblGrpYTDCL As Double, _dblGrpYTDCR As Double, _dblCLTogleCurrentAmt As Double, _dblCLTogleYTDAmt As Double
        Dim daAllLedgersAMT As Array
        Dim daAllLedgersYTD As Array
        'Creating DataTable
        Dim _tbl As New DataTable
        Dim _tblRow As DataRow
        Dim _category As New DataColumn("Category", GetType(String))
        Dim _description As New DataColumn("Description", GetType(String))
        Dim _current As New DataColumn("Current", GetType(Double))
        Dim _yTD As New DataColumn("YTD", GetType(Double))

        'Add The Column to the Datatable's Columns Collection
        _tbl.Columns.Add(_category)
        _tbl.Columns.Add(_description)
        _tbl.Columns.Add(_current)
        _tbl.Columns.Add(_yTD)


        'Check Financial Year
        CheckFinancialYear(Customerid)

        'Get last record from pro_nc_det with respactive sales,purchase,overhead,direct expance
        _strLastRecord = BSLastRecord(Customerid)

        _strArry = _strLastRecord.Split(","c)

        _strFA = _strArry(0)
        _strCA = _strArry(1)
        _strCL = _strArry(2)
        _strCR = _strArry(3)

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        _ds = GetLedgerIDForBS(Customerid)
        '   System.Web.HttpContext.Current.Trace.Warn("sp GetLedgerIDForBS")
        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))

        _newAmt = GetModifiedBalanceSheetCurrentAmt(Customerid, datefrom, dateto)
        _newYtd = GetModifiedBalanceSheetYTDAmt(Customerid, _myFEDate)

        ' System.Web.HttpContext.Current.Trace.Warn("_newAmt")
        'System.Web.HttpContext.Current.Trace.Warn("_newAmt")

        ' HttpContext.Current.Trace.Write("_ds Is Nothing = " & (_ds Is Nothing))
        '  HttpContext.Current.Trace.Write("_ds.Tables.Count=" & _ds.Tables.Count)
        '  HttpContext.Current.Trace.Write("_ds.Tables(0).Rows.Count=" & _ds.Tables(0).Rows.Count)

        For Each _dr In _ds.Tables(0).Rows
            _mHDesc = CType(_dr.Item("Description"), String)
            '  HttpContext.Current.Trace.Write("_mHDesc =" & _mHDesc)
            _mHead = CType(_dr.Item("category"), String)
            '   HttpContext.Current.Trace.Write("_mHead =" & _mHead)
            _lowLID = CType(_dr.Item("Low"), String)
            '   HttpContext.Current.Trace.Write("_lowLID =" & _lowLID)
            _highLID = CType(_dr.Item("High"), String)
            '  HttpContext.Current.Trace.Write("_highLID =" & _highLID)
            _togle = CType(_dr.Item("togle"), String)
            '  HttpContext.Current.Trace.Write("_togle =" & _togle)
            'Get CurrentYear Amt For Balance Sheet
            ' _currentAmt = 0 ' GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)

            '  HttpContext.Current.Trace.Write("Calling _newAmt.Tables(0).Select")
            daAllLedgersAMT = _newAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
            '  HttpContext.Current.Trace.Write("_newAmt.Tables(0).Select is ok")

            '   HttpContext.Current.Trace.Write("daAllLedgersAMT is nothing =" & (daAllLedgersAMT Is Nothing))
            '  HttpContext.Current.Trace.Write("daAllLedgersAMT.Length =" & daAllLedgersAMT.Length)
            If (daAllLedgersAMT.Length > 0) Then
                '   HttpContext.Current.Trace.Write("Calling GetBalanceSheetCurrentAmt")
                _currentAmt = GetBalanceSheetCurrentAmt(daAllLedgersAMT)
                '    HttpContext.Current.Trace.Write("GetBalanceSheetCurrentAmt is ok")
            Else
                _currentAmt = 0
            End If

            'Get YTD Amt
            '   HttpContext.Current.Trace.Write("Calling _newYtd.Tables(0).Select")
            daAllLedgersYTD = _newYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
            '  HttpContext.Current.Trace.Write("_newYtd.Tables(0).Select is ok")

            If (daAllLedgersYTD.Length > 0) Then
                '   HttpContext.Current.Trace.Write("Calling GetBalanceSheetCurrentYTD")
                _yTDAmt = GetBalanceSheetCurrentYTD(daAllLedgersYTD)
                '    HttpContext.Current.Trace.Write("GetBalanceSheetCurrentYTD is ok")
            Else
                _yTDAmt = 0
            End If


            '   HttpContext.Current.Trace.Write("_currentAmt = " & _currentAmt)
            '   HttpContext.Current.Trace.Write("_yTDAmt = " & _yTDAmt)
            If _currentAmt <> 0 Or _yTDAmt <> 0 Then

                If _mHead = "Fixed Assets" Then

                    If _bolChkFA = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkFA = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    _tblRow("current") = _currentAmt
                    _dblGrPFA += CType(_tblRow("Current"), Double)

                    _tblRow("YTD") = _yTDAmt
                    _dblGrPYTDFA += CType(_tblRow("YTD"), Double)
                    _tbl.Rows.Add(_tblRow)
                End If

                If _mHead = "Current Assets" Then

                    If _bolChkCA = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkCA = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _togle = "Y" Then
                        ' _dblCATogleCurrentAmt = 0 ' GetBalanceSheetCurrentAmt(CustomerID, _lowLID, _highLID, datefrom, dateto)
                        daAllLedgersAMT = _newAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersAMT.Length > 0) Then
                            _dblCATogleCurrentAmt = GetBalanceSheetCurrentAmt(daAllLedgersAMT)
                        Else
                            _dblCATogleCurrentAmt = 0
                        End If

                    Else
                        _dblGrpCA += _currentAmt
                    End If

                    If _dblCATogleCurrentAmt > 0 And _togle = "Y" Then
                        _dblGrpCA += _dblCATogleCurrentAmt
                    End If

                    If _togle = "Y" Then
                        _myFEDate = DateSerial(Year(_lastDate), Month(dateto), Day(dateto))
                        ' _dblCATogleYTDAmt = GetModifiedBalanceSheetYTDAmt(CustomerID, _lowLID, _highLID, _myFEDate)
                        daAllLedgersYTD = _newYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                        If (daAllLedgersYTD.Length > 0) Then
                            _dblCATogleYTDAmt = GetBalanceSheetCurrentYTD(daAllLedgersYTD)
                        Else
                            _dblCATogleYTDAmt = 0
                        End If

                    Else
                        _dblGrpYTDCA += _yTDAmt
                    End If

                    If _dblCATogleYTDAmt > 0 And _togle = "Y" Then
                        _dblGrpYTDCA += _dblCATogleYTDAmt
                    End If

                    If _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt < 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then

                        _tblRow("current") = 0.0
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = 0.0
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) = 0 Then

                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = 0.0
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt > 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then
                        '      _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("current") = _dblCATogleCurrentAmt
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And CType(_dblCATogleYTDAmt, Double) > 0 Then

                        _tblRow("current") = 0.0
                        _tblRow("YTD") = _dblCATogleYTDAmt
                        _tbl.Rows.Add(_tblRow)

                    ElseIf _mHead = "Current Assets" And _togle = "Y" And _dblCATogleCurrentAmt = 0 And CType(_dblCATogleYTDAmt, Double) < 0 Then

                    ElseIf _mHead = "Current Assets" And _togle = "N" Then
                        _tblRow("current") = _currentAmt
                        _tblRow("YTD") = _yTDAmt
                        _tbl.Rows.Add(_tblRow)

                    End If

                End If
                If _mHead = "Capital & Reserves" Then

                    If _bolChkCR = False Then
                        _tblRow = _tbl.NewRow()
                        _tblRow("Category") = _mHead
                        _tblRow("Description") = ""
                        _tbl.Rows.Add(_tblRow)
                        _bolChkCR = True
                    End If

                    _tblRow = _tbl.NewRow()
                    _tblRow("Category") = ""
                    _tblRow("Description") = _mHDesc

                    If _currentAmt < 0 Then
                        _tblRow("Current") = Abs(_currentAmt)
                    Else
                        _tblRow("Current") = -_currentAmt
                    End If
                    _dblGrpCR += CType(_tblRow("Current"), Double)

                    If _yTDAmt < 0 Then
                        _tblRow("YTD") = Abs(_yTDAmt)
                    Else
                        _tblRow("YTD") = -_yTDAmt
                    End If
                    _dblGrpYTDCR += CType(_tblRow("YTD"), Double)

                    _tbl.Rows.Add(_tblRow)
                End If

            End If

            ' HttpContext.Current.Trace.Write("Step 2")

            If _mHead = "Fixed Assets" And _strFA = _mHDesc And _bolChkFA = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Fixed Assets"
                _tblRow("Current") = _dblGrPFA
                _tblRow("YTD") = _dblGrPYTDFA
                _tbl.Rows.Add(_tblRow)
            End If

            '   HttpContext.Current.Trace.Write("Step 3")
            If _mHead = "Current Assets" And _strCA = _mHDesc And _bolChkCA = True Then

                _tblRow = _tbl.NewRow()
                _tblRow("Category") = ""
                _tblRow("Description") = "Total Current Assets"
                _tblRow("Current") = _dblGrpCA
                _tblRow("YTD") = _dblGrpYTDCA
                _tbl.Rows.Add(_tblRow)
            End If


        Next

        _ds.Dispose()
        _ds = Nothing

        Dim _dblSales As Double, _dblYTDSales As Double, _dblPurchase As Double, _dblYTDPurchase As Double
        Dim _dblExpense As Double, _dblYTDExpense As Double, _dblOverhead As Double, _dblYTDOverhead As Double
        Dim _dblBalanceSalesGross As Double, _dblBalanceYTDSalesGross As Double, _dblNet As Double, _dblYTDNet As Double
        Dim daPLSLedgersAMT As Array
        Dim daPLSLedgersYTD As Array

        '  HttpContext.Current.Trace.Write("_mHead=" & _mHead)
        '  HttpContext.Current.Trace.Write("_bolChkCR=" & _bolChkCR)
        '  HttpContext.Current.Trace.Write("_bolChkCA=" & _bolChkCA)
        ' HttpContext.Current.Trace.Write("_bolChkCL=" & _bolChkCL)
        '  HttpContext.Current.Trace.Write("_bolChkFA=" & _bolChkFA)
        If _mHead = "Capital & Reserves" And _bolChkCR = False And _bolChkCA = False And _bolChkCL = False And _bolChkFA = False Then
            HttpContext.Current.Trace.Write("Exit Function")
            Exit Function
        Else
            '   HttpContext.Current.Trace.Write("_tbl.NewRow()")
            _tblRow = _tbl.NewRow()
            _tblRow("Category") = "Capital & Reserves"
            _tblRow("Description") = ""
            _tbl.Rows.Add(_tblRow)
        End If

        'Get LedgerID's against Sales, Purchases, Over Head, Expenses
        '   HttpContext.Current.Trace.Write("Calling GetLedgerIDForPANDF")
        _ds = GetLedgerIDForPANDF(Customerid)
        '   HttpContext.Current.Trace.Write("GetLedgerIDForPANDF is ok")

        '   HttpContext.Current.Trace.Write("Calling GetModifiedProfitAndLossCurrentAmt")
        _PLSnewAmt = GetModifiedProfitAndLossCurrentAmt(Customerid, datefrom, dateto)
        '   HttpContext.Current.Trace.Write("GetModifiedProfitAndLossCurrentAmt is ok")

        '    HttpContext.Current.Trace.Write("Calling GetModifiedProfitAndLossCurrentYTD")
        _PLSnewYtd = GetModifiedProfitAndLossCurrentYTD(Customerid, _firstDate, _myFEDate)
        '   HttpContext.Current.Trace.Write("GetModifiedProfitAndLossCurrentYTD is ok")


        '   System.Web.HttpContext.Current.Trace.Warn("_PLSnewAmt")
        '    System.Web.HttpContext.Current.Trace.Warn("_PLSnewYtd")
        For Each _dr In _ds.Tables(0).Rows
            _mHDesc = CType(_dr.Item("Description"), String)
            _mHead = CType(_dr.Item("category"), String)
            _lowLID = CType(_dr.Item("Low"), String)
            _highLID = CType(_dr.Item("High"), String)

            If _mHead = "Sales" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If

                If _currentAmt < 0 Then
                    _dblSales += Abs(_currentAmt)
                Else
                    _dblSales += -_currentAmt
                End If

                If _yTDAmt < 0 Then
                    _dblYTDSales += Abs(_yTDAmt)
                Else
                    _dblYTDSales += -_yTDAmt
                End If
            End If

            If _mHead = "Purchases" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If

                _dblPurchase += _currentAmt
                _dblYTDPurchase += _yTDAmt
            End If

            If _mHead = "Direct Expenses" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If

                _dblExpense += _currentAmt
                _dblYTDExpense += _yTDAmt
            End If

            If _mHead = "Overheads" Then
                daPLSLedgersAMT = _PLSnewAmt.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersAMT.Length > 0) Then
                    _currentAmt = GetProfitAndLossCurrentValuesAMT(daPLSLedgersAMT)
                Else
                    _currentAmt = 0.0
                End If

                daPLSLedgersYTD = _PLSnewYtd.Tables(0).Select("transid >= '" & _lowLID & "'" & " and transid <= '" & _highLID & "'")
                If (daPLSLedgersYTD.Length > 0) Then
                    _yTDAmt = GetProfitAndLossCurrentValuesYTD(daPLSLedgersYTD)
                Else
                    _yTDAmt = 0
                End If

                _dblOverhead += _currentAmt
                _dblYTDOverhead += _yTDAmt
            End If

        Next

        'Calculating Sales, Purchase & Expense
        _dblBalanceSalesGross = _dblSales - _dblPurchase - _dblExpense
        _dblBalanceYTDSalesGross = _dblYTDSales - _dblYTDPurchase - _dblYTDExpense

        _dblNet = _dblBalanceSalesGross - _dblOverhead
        _dblYTDNet = _dblBalanceYTDSalesGross - _dblYTDOverhead

        '  System.Web.HttpContext.Current.Trace.Warn(_dblSales)
        '  System.Web.HttpContext.Current.Trace.Warn(_dblPurchase)
        '   System.Web.HttpContext.Current.Trace.Warn(_dblExpense)
        '  System.Web.HttpContext.Current.Trace.Warn(_dblOverhead)
        '   System.Web.HttpContext.Current.Trace.Warn(_dblNet)



        If _dblNet <> 0 And _dblYTDNet <> 0 Or _dblGrpCR <> 0 And _dblGrpYTDCR <> 0 Then

            _tblRow = _tbl.NewRow()
            _tblRow("Category") = ""
            _tblRow("Description") = "P & L Account"
            _tblRow("Current") = _dblNet
            _tblRow("YTD") = _dblYTDNet
            _tbl.Rows.Add(_tblRow)

            _tblRow = _tbl.NewRow()
            _tblRow("Category") = ""
            _tblRow("Description") = "Net Capital :"
            _tblRow("Current") = _dblGrpCR + _dblNet
            _tblRow("YTD") = _dblGrpYTDCR + _dblYTDNet
            _tbl.Rows.Add(_tblRow)

        End If

        Dim Dv As DataView = New DataView(_tbl)
        Return Dv
        System.Web.HttpContext.Current.Trace.Warn("BalanceSheet end  ")
    End Function

    Public Shared Sub CheckFinancialYear(ByVal Customerid As String)

        Dim _ds As DataSet, _dr As DataRow
        Dim _objCmd As New CommandData(Customerid)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_FINANCIALYEAR"
            Try
                _objCmd.AddParameter("@MIdentity", Customerid)
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("" & ex.Message)
            End Try
        End With

        For Each _dr In _ds.Tables(0).Rows

            _firstDate = CType(_dr(0), Date)
            _lastDate = CType(_dr(1), Date)
        Next

        _ds.Dispose()
        _ds = Nothing

    End Sub

    Public Shared Function GetProfitAndLossCurrentAmt(ByVal CustomerID As Integer, ByVal _lowLID As String, ByVal _highLID As String, ByVal _dateFrom As Date, ByVal _dateTo As Date) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "ACCOUNTSPRO_GETPROFITANDLOSSAMT"
            .AddParameter("@lowLID", _lowLID)
            .AddParameter("@highLID", _highLID)
            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            ''Added by : Sadia Waleem
            '' Dated: 19th Feb 2007
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETPROFITANDLOSSAMT" & ex.Message)
            End Try

            For Each _dr In _ds.Tables(0).Rows
                _debit += CType(_dr.Item("SumOfdebit"), Double)
                _credit += CType(_dr.Item("SumOfcredit"), Double)
            Next
            _ds.Dispose()
            _ds = Nothing

            _totalAmt = _debit - _credit
            Return _totalAmt

        End With
    End Function

    Public Shared Function GetModifiedProfitAndLossCurrentAmt(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETPROFITANDLOSSAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try


            Return _ds

        End With
    End Function

    Public Shared Function GetProfitAndLossCurrentValuesAMT(ByVal daAllLedgers As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double


        For Each _dr In daAllLedgers
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next


        _totalAmt = _debit - _credit

        Return _totalAmt
    End Function

    Public Shared Function GetModifiedProfitAndLossCurrentYTD(ByVal CustomerID As Integer, ByVal _dateFrom As Date, ByVal _dateTo As Date) As DataSet

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double
        Dim _objCmd As New CommandData(CustomerID)

        With _objCmd
            .CmdType = CommandType.StoredProcedure
            .CmdText = "BPL_ACCOUNTSPRO_GETPROFITANDLOSSAMT"

            .AddParameter("@dateFrom", _dateFrom)
            .AddParameter("@dateTo", _dateTo)
            .AddParameter("@MIdentity", CustomerID)

            Try
                _ds = CType(_objCmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
            Catch ex As Exception
                Throw New Exception("ACCOUNTSPRO_GETBALANCESHEETAMT" & ex.Message)
            End Try


            Return _ds

        End With
    End Function

    Public Shared Function GetProfitAndLossCurrentValuesYTD(ByVal daAllLedgers As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double


        For Each _dr In daAllLedgers
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next


        _totalAmt = _debit - _credit

        Return _totalAmt
    End Function


End Class

<System.Web.Services.WebService(Namespace:="http://www.MeterTesting2.com")> _
Class WebserviceTest
    Inherits System.Web.Services.WebService

    Public Shared Function GetProfitAndLossCurrentValuesYTD1(ByVal daAllLedgers As Array) As Double

        Dim _ds As DataSet, _dr As DataRow
        Dim _debit As Double, _credit As Double, _totalAmt As Double


        For Each _dr In daAllLedgers
            _debit += CType(_dr.Item("SumOfdebit"), Double)
            _credit += CType(_dr.Item("SumOfcredit"), Double)
        Next


        _totalAmt = _debit - _credit

        Return _totalAmt
    End Function


End Class

Public Enum ID
    start
    ist
    second
    third
End Enum

