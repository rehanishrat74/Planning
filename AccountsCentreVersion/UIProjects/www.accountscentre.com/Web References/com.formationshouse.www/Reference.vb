﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.2032
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2032.
'
Namespace com.formationshouse.www
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="FHservicesBinding", [Namespace]:="urn:FHservices")>  _
    Public Class FHservices
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://webservices.formationshouse.com/authuser.php"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:FHservices#authUser", RequestNamespace:="urn:FHservices", ResponseNamespace:="urn:FHservices")>  _
        Public Function authUser(ByVal loginid As String, ByVal password As String) As <System.Xml.Serialization.SoapElementAttribute("return")> ReturnMsg
            Dim results() As Object = Me.Invoke("authUser", New Object() {loginid, password})
            Return CType(results(0),ReturnMsg)
        End Function
        
        '<remarks/>
        Public Function BeginauthUser(ByVal loginid As String, ByVal password As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("authUser", New Object() {loginid, password}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndauthUser(ByVal asyncResult As System.IAsyncResult) As ReturnMsg
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),ReturnMsg)
        End Function
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.SoapTypeAttribute("ReturnMsg", "urn:FHservices")>  _
    Public Class ReturnMsg
        
        '<remarks/>
        Public ERRORCODE As Decimal
        
        '<remarks/>
        Public LCODE As String
        
        '<remarks/>
        Public UI As String
    End Class
End Namespace
