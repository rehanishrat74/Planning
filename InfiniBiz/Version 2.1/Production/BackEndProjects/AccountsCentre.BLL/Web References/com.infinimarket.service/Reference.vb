﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.2300
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
'This source code was auto-generated by Microsoft.VSDesigner, Version 1.1.4322.2300.
'
Namespace com.infinimarket.service
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="_DefaultSoap", [Namespace]:="http://tempuri.org/SingleSignIn/_Default")>  _
    Public Class _Default
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = "http://service.infinimarket.com/Default.asmx"
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/AddUser", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function AddUser(ByVal User_Id As String) As String
            Dim results() As Object = Me.Invoke("AddUser", New Object() {User_Id})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginAddUser(ByVal User_Id As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("AddUser", New Object() {User_Id}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndAddUser(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/isSignIn", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function isSignIn(ByVal _Xml As String) As String
            Dim results() As Object = Me.Invoke("isSignIn", New Object() {_Xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginisSignIn(ByVal _Xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("isSignIn", New Object() {_Xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndisSignIn(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/SignOut", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function SignOut(ByVal _Xml As String) As String
            Dim results() As Object = Me.Invoke("SignOut", New Object() {_Xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginSignOut(ByVal _Xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("SignOut", New Object() {_Xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndSignOut(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/RegisterCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RegisterCustomer(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("RegisterCustomer", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginRegisterCustomer(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RegisterCustomer", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndRegisterCustomer(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/RegisterCustomerWithCustomerView", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RegisterCustomerWithCustomerView(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("RegisterCustomerWithCustomerView", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginRegisterCustomerWithCustomerView(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RegisterCustomerWithCustomerView", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndRegisterCustomerWithCustomerView(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/LoginCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LoginCustomer(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("LoginCustomer", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginLoginCustomer(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LoginCustomer", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndLoginCustomer(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/LoginFormationHouseCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function LoginFormationHouseCustomer(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("LoginFormationHouseCustomer", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginLoginFormationHouseCustomer(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("LoginFormationHouseCustomer", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndLoginFormationHouseCustomer(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomerChildId_By_LiveUid_Domain", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetCustomerChildId_By_LiveUid_Domain(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetCustomerChildId_By_LiveUid_Domain", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetCustomerChildId_By_LiveUid_Domain(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomerChildId_By_LiveUid_Domain", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetCustomerChildId_By_LiveUid_Domain(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomerChildID_By_MerchantID", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetCustomerChildID_By_MerchantID(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetCustomerChildID_By_MerchantID", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetCustomerChildID_By_MerchantID(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomerChildID_By_MerchantID", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetCustomerChildID_By_MerchantID(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetMerchantLiveId", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetMerchantLiveId(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetMerchantLiveId", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetMerchantLiveId(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetMerchantLiveId", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetMerchantLiveId(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomerLiveId", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetCustomerLiveId(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetCustomerLiveId", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetCustomerLiveId(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomerLiveId", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetCustomerLiveId(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomerInfo", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetCustomerInfo(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetCustomerInfo", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetCustomerInfo(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomerInfo", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetCustomerInfo(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/CreateCustomerView", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function CreateCustomerView(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("CreateCustomerView", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginCreateCustomerView(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("CreateCustomerView", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndCreateCustomerView(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/RegisterMerchant", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RegisterMerchant(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("RegisterMerchant", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginRegisterMerchant(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RegisterMerchant", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndRegisterMerchant(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetCustomerAllChildIds", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetCustomerAllChildIds(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("GetCustomerAllChildIds", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetCustomerAllChildIds(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetCustomerAllChildIds", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetCustomerAllChildIds(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/AutoRegisterFormationsHouseCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function AutoRegisterFormationsHouseCustomer(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("AutoRegisterFormationsHouseCustomer", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginAutoRegisterFormationsHouseCustomer(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("AutoRegisterFormationsHouseCustomer", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndAutoRegisterFormationsHouseCustomer(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/RegisterFormationHouseCustomer", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RegisterFormationHouseCustomer(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("RegisterFormationHouseCustomer", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginRegisterFormationHouseCustomer(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RegisterFormationHouseCustomer", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndRegisterFormationHouseCustomer(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/Update_Customer_As_Seller", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function Update_Customer_As_Seller(ByVal _xml As String) As String
            Dim results() As Object = Me.Invoke("Update_Customer_As_Seller", New Object() {_xml})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginUpdate_Customer_As_Seller(ByVal _xml As String, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("Update_Customer_As_Seller", New Object() {_xml}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndUpdate_Customer_As_Seller(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SingleSignIn/_Default/GetXML", RequestNamespace:="http://tempuri.org/SingleSignIn/_Default", ResponseNamespace:="http://tempuri.org/SingleSignIn/_Default", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function GetXML(ByVal xmlEnum As XmlFormat) As String
            Dim results() As Object = Me.Invoke("GetXML", New Object() {xmlEnum})
            Return CType(results(0),String)
        End Function
        
        '<remarks/>
        Public Function BeginGetXML(ByVal xmlEnum As XmlFormat, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("GetXML", New Object() {xmlEnum}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndGetXML(ByVal asyncResult As System.IAsyncResult) As String
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),String)
        End Function
    End Class
    
    '<remarks/>
    <System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://tempuri.org/SingleSignIn/_Default")>  _
    Public Enum XmlFormat
        
        '<remarks/>
        Customer_Registeration
        
        '<remarks/>
        Customer_login
        
        '<remarks/>
        Customer_details
        
        '<remarks/>
        Customer_View
    End Enum
End Namespace
