﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.573.
'
Namespace com.webservices.ishops
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WebServiceSoap", [Namespace]:="WebService")>  _
    Public Class WebService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://ishops.webservices.com/webservices.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/CollectionServices", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CollectionServices(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("CollectionServices", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginCollectionServices(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CollectionServices", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCollectionServices(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/CRM", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CRM(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("CRM", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginCRM(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CRM", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCRM(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/Order_New", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Order_New(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("Order_New", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginOrder_New(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Order_New", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndOrder_New(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/Order_Repayment", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Order_Repayment(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("Order_Repayment", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginOrder_Repayment(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Order_Repayment", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndOrder_Repayment(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/Approve_FloorLimit", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Approve_FloorLimit(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("Approve_FloorLimit", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginApprove_FloorLimit(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Approve_FloorLimit", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndApprove_FloorLimit(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("WebService/Auto_Generate_Invoice_Update_ProOrderInvoice", RequestNamespace:="WebService", ResponseNamespace:="WebService", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Auto_Generate_Invoice_Update_ProOrderInvoice(ByVal sXml As String) As String
            Dim results() As Object = Me.Invoke("Auto_Generate_Invoice_Update_ProOrderInvoice", New Object() {sXml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginAuto_Generate_Invoice_Update_ProOrderInvoice(ByVal sXml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Auto_Generate_Invoice_Update_ProOrderInvoice", New Object() {sXml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndAuto_Generate_Invoice_Update_ProOrderInvoice(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
    End Class
End Namespace
