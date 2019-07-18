'Imports System.Web.Services
'Imports System.text
'Imports InfiniLogic.BusinessPlan.Web.Common


'Imports InfiniLogic.BusinessPlan.BLL

'Imports InfiniLogic.BusinessPlan.DAL
'Imports InfiniLogic.AccountsCentre.DAL
'Imports System.Data.SqlClient
'Imports System.Windows.Forms

'Imports System.web
'<System.Web.Services.WebService(Namespace:="http://www.MeterTesting.com")> _
'Public Class Service1
'    Inherits System.Web.Services.WebService

'#Region " Web Services Designer Generated Code "
'    Private cust_id As String
'    Public Sub New()

'        'This call is required by the Web Services Designer.
'        InitializeComponent()

'        'Add your own initialization code after the InitializeComponent() call

'    End Sub





'    'Required by the Web Services Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Web Services Designer
'    'It can be modified using the Web Services Designer.  
'    'Do not modify it using the code editor.
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

'    End Sub

'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        'CODEGEN: This procedure is required by the Web Services Designer
'        'Do not modify it using the code editor.
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'#End Region

'    ' WEB SERVICE EXAMPLE
'    ' The HelloWorld() example service returns the string Hello World.
'    ' To build, uncomment the following lines then save and build the project.
'    ' To test this web service, ensure that the .asmx file is the start page
'    ' and press F5.
'    '
'    'Public Property Customerid() As String
'    '    Get
'    '        Return Session("id")
'    '    End Get
'    '    Set(ByVal Value As String)
'    '        cust_id = Value
'    '        Session("id") = cust_id
'    '    End Set
'    'End Property

'    <WebMethod()> _
'    Public Function HelloWorld() As String
'        Return "Hello test World"
'    End Function

'    <WebMethod()> _
'     Public Function getMessage() As String
'        Return "Flash Remoting makes web services easy!"
'    End Function

'    <WebMethod()> _
'      Public Function getMessage1(ByRef Dat As String) As String

'        Return "Flash Remoting makes web services easy!"
'    End Function

'    '  <WebMethod()> _
'    'Public Function GetNodes() As String()

'    '      Try
'    '          Dim ds As DataSet
'    '          Dim cmd As New CommandData(114181)

'    '          cmd.CmdText = "BPL_GetProductNodes"
'    '          ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
'    '          Dim str1() As String = callmeforNodes(ds)
'    '          Return str1
'    '      Catch ex As Exception
'    '          Dim str As String = ex.Message
'    '      End Try

'    '  End Function
'    '  Public Function callmeforNodes(ByVal ds As DataSet) As String()
'    '      Dim item As StringBuilder
'    '      Dim loop1 As Integer
'    '      item = New StringBuilder
'    '      For loop1 = 0 To ds.Tables(0).Rows.Count - 1
'    '          item.Append(CStr(ds.Tables(0).Rows(loop1).Item(0)) + ",")
'    '      Next
'    '      Dim strMenu() As String = item.ToString.Remove(item.ToString.LastIndexOf(","c), 1).Split(","c)
'    '      Return strMenu
'    '  End Function

'    '    <WebMethod()> _
'    'Public Function GetNodesWebXML1() As String

'    '        Try
'    '            Dim ds As DataSet

'    '            Dim cmd As New CommandData(114181)
'    '            cmd.CmdText = "bpl_GetNodesXML"
'    '            cmd.AddParameter("@PRODUCT_ID", "0")
'    '            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
'    '            Dim RetNode As String = callmeforNodeXML(ds)
'    '            Return RetNode
'    '        Catch ex As Exception
'    '            Dim str As String = ex.Message
'    '        End Try

'    '    End Function

'    <WebMethod()> _
'         Public Function GetSingleNodesXML(ByVal PRODUCT_ID As String, ByVal Planid As String, ByVal Customerid As String, ByVal ProSdate As String, ByVal ProEdate As String, ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String, ByVal SingleAnalysisOption As String) As String
'        'Public Function GetSingleNodesXML(ByVal PRODUCT_ID As String) As String

'        Dim connData As New ConnectionData

'        Dim cust_id As Integer = Customerid
'        Dim intPlanSdate As Integer = PlanSdate
'        Dim intPlanEdate As Integer = PlanEdate
'        Try
'            Dim ds As DataSet
'            connData.CustomerID = cust_id

'            Dim cmd As New CommandData(connData.CustomerID)
'            cmd.CmdText = "bpl_GetSingleNodesXML"
'            cmd.AddParameter("@MIdentity", Customerid)
'            cmd.AddParameter("@PRODUCT_ID", PRODUCT_ID)
'            cmd.AddParameter("@Planid", Planid)

'            cmd.AddParameter("@ProSdate", ProSdate)
'            cmd.AddParameter("@ProEdate", ProEdate)
'            cmd.AddParameter("@PlanSdate", intPlanSdate)
'            cmd.AddParameter("@PlanEdate", intPlanEdate)

'            ds = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet)
'            Dim RetNode As String = callmeforNodeXML(ds, getCurrency, SingleAnalysisOption)
'            Return RetNode
'        Catch ex As Exception
'            Dim str As String = ex.Message
'        End Try

'    End Function
'    Public Function callmeforNodeXML(ByVal ds As DataSet, ByVal Currency As String, ByVal SingleAnalysisOption As String) As String
'        Dim Nodeitem As StringBuilder
'        Dim loop1 As Integer
'        Dim MTD As String = "June"
'        Dim MTY As String = "2007"
'        Dim qoute As Char = """"c
'        Nodeitem = New StringBuilder
'        If SingleAnalysisOption = ID.ist Then
'            Nodeitem.Append("<Root>")
'            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
'                Nodeitem.Append("<Product" + CStr(loop1) + ">")
'                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
'                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(5)) + qoute + " />")
'                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(4)) + qoute + " />")
'                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(4), Double), "f") + Currency + qoute + " />")
'                Nodeitem.Append("</Product" + CStr(loop1) + ">")

'            Next
'            Nodeitem.Append("</Root>")
'        ElseIf SingleAnalysisOption = ID.second Then
'            Nodeitem.Append("<Root>")
'            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
'                Nodeitem.Append("<Product" + CStr(loop1) + ">")
'                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
'                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(7)) + qoute + " />")
'                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(6)) + qoute + " />")
'                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(6), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(6), Double), "f") + Currency + qoute + " />")
'                Nodeitem.Append("</Product" + CStr(loop1) + ">")

'            Next
'            Nodeitem.Append("</Root>")
'        ElseIf SingleAnalysisOption = ID.third Then
'            Nodeitem.Append("<Root>")
'            For loop1 = 0 To ds.Tables(0).Rows.Count - 1
'                Nodeitem.Append("<Product" + CStr(loop1) + ">")
'                Nodeitem.Append("<Path ProductName=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(3)) + qoute + "/>")
'                Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(5)) + qoute + " />")
'                Nodeitem.Append("<Path ProPrices=" + qoute + CStr(ds.Tables(0).Rows(loop1).Item(4)) + qoute + " />")
'                Nodeitem.Append("<Path MTD=" + qoute + Format(CType(ds.Tables(0).Rows(loop1).Item(4), Double), "f") + Currency + qoute + "  MTY=" + qoute + Format(CType(ds.Tables(1).Rows(loop1).Item(4), Double), "f") + Currency + qoute + " />")
'                Nodeitem.Append("</Product" + CStr(loop1) + ">")

'            Next
'            Nodeitem.Append("</Root>")
'        End If

'        Dim strNode = Nodeitem.ToString
'        Return strNode

'    End Function

'    <WebMethod()> _
'       Public Function GetMultipleNodesXML(ByVal PRODUCT_IDs As String, ByVal Planid As String, ByVal Customerid As String, ByVal ProSdate As String, ByVal ProEdate As String, ByVal PlanSdate As String, ByVal PlanEdate As String, ByVal getCurrency As String, ByVal MultiAnalysisOption As String) As String
'        Dim connData As New ConnectionData
'        'Public Function GetMultipleNodesXML(ByVal PRODUCT_IDs As String) As String
'        Dim cust_id As Integer = Customerid
'        Dim intPlanSdate As Integer = PlanSdate
'        Dim intPlanEdate As Integer = PlanEdate
'        Try
'            Dim dtvalueMTD As DataTable
'            Dim dtvalueMTY As DataTable
'            connData.CustomerID = cust_id

'            Dim cmd As New CommandData(connData.CustomerID)

'            cmd.CmdText = "bpl_GetNodesXML"
'            cmd.AddParameter("@MIdentity", Customerid)
'            cmd.AddParameter("@PRODUCT_ID", "0")
'            cmd.AddParameter("@Planid", Planid)

'            cmd.AddParameter("@ProSdate", ProSdate)
'            cmd.AddParameter("@ProEdate", ProEdate)
'            cmd.AddParameter("@PlanSdate", intPlanSdate)
'            cmd.AddParameter("@PlanEdate", intPlanEdate)

'            dtvalueMTD = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(0)
'            dtvalueMTY = CType(cmd.Execute(ExecutionType.ExecuteDataSet), DataSet).Tables(1)
'            Dim RetNode As String = callmeforMultipleNodeXML(dtvalueMTD, dtvalueMTY, PRODUCT_IDs, getCurrency, MultiAnalysisOption)
'            Return RetNode
'        Catch ex As Exception
'            Dim str As String = ex.Message
'        End Try

'    End Function

'    Public Function callmeforMultipleNodeXML(ByVal dtMTD As DataTable, ByVal dtMTY As DataTable, ByVal PRODUCTS_IDs As String, ByVal Currency As String, ByVal MultiAnalysisOption As String) As String

'        Dim intloop As Integer
'        Dim Nodeitem As StringBuilder
'        Dim Product_id As String() = PRODUCTS_IDs.Split(",")
'        Dim dr_Product As DataRow
'        Dim dr_ProductYear As DataRow
'        Dim da_Product As Array
'        Dim da_ProductYearly As Array
'        Dim qoute As Char = """"c
'        Nodeitem = New StringBuilder

'        Nodeitem.Append("<Root>")
'        If MultiAnalysisOption = ID.ist Then
'            For intloop = 0 To Product_id.Length - 1
'                da_Product = dtMTD.Select("productid='" & Product_id(intloop) & "'")
'                da_ProductYearly = dtMTY.Select("productid='" & Product_id(intloop) & "'")
'                For Each dr_Product In da_Product
'                    Nodeitem.Append("<Product" + CStr(intloop) + ">")
'                    Nodeitem.Append("<Path ProductName=" + qoute + CStr(dr_Product(3)) + qoute + "/>")
'                    Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(dr_Product(5)) + qoute + " />")
'                    Nodeitem.Append("<Path ProPrices=" + qoute + CStr(dr_Product(4)) + qoute + " />")
'                    Nodeitem.Append("<Path MTD=" + qoute + Format(CType(dr_Product(4), Double), "f") + qoute + "  MTY=" + qoute + Currency + qoute + " />")
'                    Nodeitem.Append("</Product" + CStr(intloop) + ">")
'                Next
'            Next
'        ElseIf MultiAnalysisOption = ID.second Then
'            For intloop = 0 To Product_id.Length - 1
'                da_Product = dtMTD.Select("productid='" & Product_id(intloop) & "'")
'                da_ProductYearly = dtMTY.Select("productid='" & Product_id(intloop) & "'")
'                For Each dr_Product In da_Product
'                    Nodeitem.Append("<Product" + CStr(intloop) + ">")
'                    Nodeitem.Append("<Path ProductName=" + qoute + CStr(dr_Product(3)) + qoute + "/>")
'                    Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(dr_Product(7)) + qoute + " />")
'                    Nodeitem.Append("<Path ProPrices=" + qoute + CStr(dr_Product(6)) + qoute + " />")
'                    Nodeitem.Append("<Path MTD=" + qoute + Format(CType(dr_Product(6), Double), "f") + qoute + "  MTY=" + qoute + Currency + qoute + " />")
'                    Nodeitem.Append("</Product" + CStr(intloop) + ">")
'                Next
'            Next
'        ElseIf MultiAnalysisOption = ID.third Then
'            For intloop = 0 To Product_id.Length - 1
'                da_Product = dtMTD.Select("productid='" & Product_id(intloop) & "'")
'                da_ProductYearly = dtMTY.Select("productid='" & Product_id(intloop) & "'")
'                For Each dr_Product In da_Product
'                    Nodeitem.Append("<Product" + CStr(intloop) + ">")
'                    Nodeitem.Append("<Path ProductName=" + qoute + CStr(dr_Product(3)) + qoute + "/>")
'                    Nodeitem.Append("<Path PlanPrices=" + qoute + CStr(dr_Product(5)) + qoute + " />")
'                    Nodeitem.Append("<Path ProPrices=" + qoute + CStr(dr_Product(4)) + qoute + " />")
'                    Nodeitem.Append("<Path MTD=" + qoute + Format(CType(dr_Product(4), Double), "f") + qoute + "  MTY=" + qoute + Currency + qoute + " />")
'                    Nodeitem.Append("</Product" + CStr(intloop) + ">")
'                Next
'            Next

'        End If



'        Dim strNode = Nodeitem.ToString
'        Return strNode

'    End Function
'End Class


'Public Enum ID
'    start
'    ist
'    second
'    third
'End Enum

