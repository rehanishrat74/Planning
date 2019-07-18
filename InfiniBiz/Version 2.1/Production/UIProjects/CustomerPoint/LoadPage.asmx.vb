Imports InfiniLogic
Imports System.IO
Imports System.text
Imports System.data
Imports System.Data.SqlClient
Imports InfiniLogic.AccountsCentre.DAL
Imports InfiniLogic.AccountsCentre.BLL
Imports System.Web.Services
Imports System.Xml

<System.Web.Services.WebService(Namespace := "http://tempuri.org/CustomerPoint/LoadPage")> _
Public Class LoadPage
    Inherits System.Web.Services.WebService
    Dim site_name, site_code, site_url, domain_name, Menu As String
#Region " Web Services Designer Generated Code "

    Public Sub New()
        MyBase.New()

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
        components = New System.ComponentModel.Container()
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

    ' WEB SERVICE EXAMPLE
    ' The HelloWorld() example service returns the string Hello World.
    ' To build, uncomment the following lines then save and build the project.
    ' To test this web service, ensure that the .asmx file is the start page
    ' and press F5.
    '
    '<WebMethod()> _
    'Public Function HelloWorld() As String
    '   Return "Hello World"
    'End Function
    Dim _CPMethods As CustomerPointMethods
    Dim MenuNode As StringBuilder
    Dim qoute As Char = """"c
    Dim imgPath As String = " imgpath=""/images/misc/folder.gif"" "
    Dim strLoadMethod As String() = {"C_1", "C_2", "C_3"}
    <WebMethod(EnableSession:=True)> _
    Public Function InvokeCustomerPoint(ByVal CustomerID As Integer, ByVal CustomerpointID As String) As String

        If CustomerpointID = strLoadMethod(0) Then

            Return CreateMenuForTracker(CustomerID, CustomerpointID)

        ElseIf CustomerpointID = strLoadMethod(1) Then

            Return CreateMenuForTest(CustomerID, CustomerpointID)

        ElseIf CustomerpointID = strLoadMethod(2) Then

            Return CreateMenuForTest(CustomerID, CustomerpointID)

        End If

    End Function
    Public Structure EncryptResult
        Dim ErrorCode As Int16
        Dim ErrorDesc As String
        Dim AppendText As String
    End Structure

    'Public Function GetBizPlanServices(ByVal LoginInfo As UserInfo) As String
    '    Dim str As String = Encrypt_Merchant(LoginInfo).AppendText
    '    Dim result As String

    '    result = "<upperparent text='InfiniPlan'>" _
    '    & "<parent0 text='Home' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=Home.aspx&config=" & str & "' />" _
    '    & "<parent1 text='Plan Manager' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=PlanManager.aspx&config=" & str & " ' /> " _
    '    & "<parent2 text='Speedometer Manager' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=" & str & "' />" _
    '    & "<parent3 text='Exported Plans' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=ExportedPlans.aspx&config=" & str & "' />" _
    '    & "<parent4 text='FAQs' value='http://accounts.infinibiz.com/account/accountingservices.aspx?goto=FAQs.aspx&config=" & str & " ' /> " _
    '    & "</upperparent>"


    '    Return result
    'End Function

    Public Function Encrypt_Merchant(ByVal CustomerID As String) As EncryptResult
        Dim result As New EncryptResult
        result.ErrorCode = 0
        result.ErrorDesc = "Operation Completed Successfully."

        System.Web.HttpContext.Current.Trace.Warn("START : Encrypt_Merchant " & Now.ToString)
        System.Web.HttpContext.Current.Trace.Warn("LoginInfo.CustomerID = " & CustomerID)

        If CustomerID Is Nothing OrElse Not IsNumeric(CustomerID) Then
            result.ErrorCode = -1
            result.ErrorDesc = "Invalid CustomerID."
        Else
            Dim objBll As New AccountsCentre.BLL.AccountingTreeView
            Dim BllResult As AccountsCentre.BLL.AccountingTreeView.FunctionResult = objBll.Encrypt_Merchant(CustomerID)
            If BllResult.IsSuccess Then
                result.AppendText = BllResult.ReturnObject
            Else
                result.ErrorCode = -2
                result.ErrorDesc = BllResult.ErrorDesc
            End If
        End If

        System.Web.HttpContext.Current.Trace.Warn("result.ErrorCode = " & result.ErrorCode)
        System.Web.HttpContext.Current.Trace.Warn("result.ErrorDesc = " & result.ErrorDesc)
        System.Web.HttpContext.Current.Trace.Warn("END : Encrypt_Merchant " & Now.ToString)

        Return result
    End Function

    Public Function CreateMenuForTracker(ByVal CustomerID As Integer, ByVal CustomerpointID As String) As String
        Dim counter As Integer = 0, _orderCount As Integer = 0
        Dim _peroidStartDate As String
        Dim _countArray As New ArrayList
        Dim dtCustomerIDs As DataTable
        Dim dr As DataRow, _drNodes As DataRow
        Dim _LoadXMLTable As DataTable
        Dim _sBuilder As StringBuilder
        Dim _sWriter As StringWriter
        Dim _xmlWriter As XmlTextWriter
        Dim Result As New ResultMessage
        Dim _list As New ArrayList
        Dim dataTblMerchantInfo As System.Data.DataTable
        Dim Encrypt_MerchantURL As String
        Dim PageDomain As String = "http://" + System.Web.HttpContext.Current.Request.Url.Host + "/account/accountingservices.aspx?goto="

        Encrypt_MerchantURL = Encrypt_Merchant(CustomerID).AppendText
     
        Try

            dataTblMerchantInfo = _CPMethods.getMerchantInformation(CustomerID)
            If dataTblMerchantInfo.Rows.Count > 0 Then
                domain_name = dataTblMerchantInfo.Rows(0).Item("domain_name")
                site_url = "http://" + domain_name
                System.Web.HttpContext.Current.Trace.Warn("site_url" + site_url)
                System.Web.HttpContext.Current.Trace.Warn("Menu Xml Starts")
                _peroidStartDate = Date.Now.AddDays(-10).ToLongDateString + " " + "00:00:00.000"
                dtCustomerIDs = _CPMethods.GetOrderCount(CustomerID, _peroidStartDate, domain_name)
                _list.Clear()
                For Each dr In dtCustomerIDs.Rows
                    If Not _list.Contains(dr("CustomerID")) Then
                        _list.Add(dr("CustomerID"))
                        _orderCount = _orderCount + _CPMethods.PostOrderCount(CustomerID, CStr(dr("CustomerID")), _peroidStartDate, domain_name)
                    End If
                Next
                _countArray.Add(_CPMethods.GetVisitsCount(CustomerID, _peroidStartDate, domain_name))
                _countArray.Add(_CPMethods.GetProductCount(CustomerID, _peroidStartDate, domain_name))
                _countArray.Add(_orderCount)
                _sBuilder = New StringBuilder
                _sWriter = New StringWriter(_sBuilder)
                _xmlWriter = New XmlTextWriter(_sWriter)

                _xmlWriter.WriteStartElement("CustomerPoint")
                _xmlWriter.WriteAttributeString("text", "Customer Point")
                _xmlWriter.WriteAttributeString("value", "")
                _xmlWriter.WriteAttributeString("imgpath", "/images/misc/folder.gif")
                _xmlWriter.WriteAttributeString("collapse", "0")
                _LoadXMLTable = _CPMethods.GetMenuForTracker(CustomerpointID).Tables(0)

                For Each _drNodes In _LoadXMLTable.Rows
                    _xmlWriter.WriteStartElement(_drNodes("NodeName").ToString().Trim())
                    _xmlWriter.WriteAttributeString("text", _drNodes("NodeName").ToString().Trim() & "(" & _countArray(counter) & ")")

                    '   _xmlWriter.WriteAttributeString("value", PageDomain & _drNodes("StartUPURL").ToString().Trim() _
                    '& "?ParentPageURL=" & _drNodes("NodeURL").ToString().Trim() & _drNodes("ParentPage").ToString().Trim() _
                    '& ",MID=" & CustomerID & "&config=" & Encrypt_MerchantURL)


                    _xmlWriter.WriteAttributeString("value", _drNodes("StartUPURL").ToString().Trim() _
                 & "?ParentPageURL=" & _drNodes("NodeURL").ToString().Trim() & _drNodes("ParentPage").ToString().Trim() _
                 & ",MID=" & CustomerID)

                    _xmlWriter.WriteAttributeString("imgpath", "/images/misc/folder.gif")
                    _xmlWriter.WriteAttributeString("collapse", "1")
                    _xmlWriter.WriteEndElement()
                    counter += 1
                Next
                _xmlWriter.WriteEndElement()
                System.Web.HttpContext.Current.Trace.Warn("Menu Xml ends")
            End If
            System.Web.HttpContext.Current.Trace.Warn("Menu Xml")
            System.Web.HttpContext.Current.Trace.Write(_sBuilder.ToString)
            Return _sBuilder.ToString

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
            Result.Message = "CreateMenuForTracker" + ex.Message
            Return Result.ToString
        End Try
    End Function

    Public Function CreateMenuForTest(ByVal CustomerID As Integer, ByVal CustomerpointID As String) As String
        Dim Result As New ResultMessage
        Dim _list As New ArrayList
        Dim Encrypt_MerchantURL As String
        Try
            System.Web.HttpContext.Current.Trace.Warn("Menu Xml Starts")
            Dim counter As Integer = 0, _orderCount As Integer = 0

            Encrypt_MerchantURL = Encrypt_Merchant(CustomerID).AppendText
            Dim dtCustomerIDs As DataTable
            Dim dr As DataRow, _drNodes As DataRow
            Dim _LoadXMLTable As DataTable
            Dim _sBuilder As StringBuilder
            Dim _sWriter As StringWriter
            Dim _xmlWriter As XmlTextWriter
            Dim PageDomain As String = "http://" + System.Web.HttpContext.Current.Request.Url.Host + "/account/accountingservices.aspx?goto="


            _sBuilder = New StringBuilder
            _sWriter = New StringWriter(_sBuilder)
            _xmlWriter = New XmlTextWriter(_sWriter)

            _xmlWriter.WriteStartElement("CustomerPoint")
            _xmlWriter.WriteAttributeString("text", "Customer Point")
            _xmlWriter.WriteAttributeString("value", "")
            _xmlWriter.WriteAttributeString("imgpath", "/images/misc/folder.gif")
            _xmlWriter.WriteAttributeString("collapse", "0")
            _LoadXMLTable = _CPMethods.GetMenuForTracker(CustomerpointID).Tables(0)

            For Each _drNodes In _LoadXMLTable.Rows
                _xmlWriter.WriteStartElement(_drNodes("NodeName").ToString().Trim())
                _xmlWriter.WriteAttributeString("text", _drNodes("NodeName").ToString().Trim())
                _xmlWriter.WriteAttributeString("value", PageDomain & _drNodes("StartUPURL").ToString().Trim() _
                & "?ParentPageURL=" & _drNodes("NodeURL").ToString().Trim() _
                & _drNodes("ParentPage").ToString().Trim() & ",MID=" & CustomerID & "&config=" & Encrypt_MerchantURL)
                _xmlWriter.WriteAttributeString("imgpath", "/images/folder.gif")
                _xmlWriter.WriteAttributeString("collapse", "1")
                _xmlWriter.WriteEndElement()
            Next

            _xmlWriter.WriteEndElement()
            System.Web.HttpContext.Current.Trace.Warn("Menu Xml ends")
            Return _sBuilder.ToString

        Catch ex As Exception
            System.Web.HttpContext.Current.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
            Result.Message = "CreateMenuForTracker" + ex.Message
            Return Result.ToString
        End Try
    End Function



End Class

Public Structure ResultMessage
    Public Message As String
End Structure