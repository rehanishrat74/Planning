
Public Class MarketPlaceService
    Public Shared Function GetLiveCustomerID(ByVal MerchantID As String, ByVal RCustomerID As String) As String
        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String = service.GetXML(com.infinimarket.service.XmlFormat.Customer_details)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~merch_id~", MerchantID)
        xmlValue = Replace(xmlValue, "~cust_id~", RCustomerID)

        Dim ResultXML As String = service.GetCustomerLiveId(xmlValue)

        Dim xmlDoc As New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)

        Dim LiveID As String = xmlDoc.SelectSingleNode("details/customer_live_uid").InnerXml
        Return LiveID
    End Function

    Public Shared Function GetLiveID_Password(ByVal MerchantID As String, ByVal LiveID As String) As String
        Dim service As New com.infinimarket.service._Default
        Dim xmlValue As String
        Dim ResultXML As String
        Dim xmlDoc As New System.Xml.XmlDocument
        xmlValue = service.GetXML(com.infinimarket.service.XmlFormat.Customer_details)
        xmlValue = Replace(xmlValue, "~ref_id~", "005")
        xmlValue = Replace(xmlValue, "~cust_luid~", LiveID)

        ResultXML = service.GetCustomerInfo(xmlValue)
        xmlDoc = New System.Xml.XmlDocument
        xmlDoc.LoadXml(ResultXML)
        Dim LivePassword As String = ""
        LivePassword = xmlDoc.SelectSingleNode("details/Cart_Customer_Pass").InnerText

        Return LivePassword
    End Function

    Public Shared Function GetLivePassword(ByVal CustomerID As String) As String
        Dim LiveID As String = MarketPlaceService.GetLiveCustomerID("2", CustomerID)
        Dim Password As String = MarketPlaceService.GetLiveID_Password("2", LiveID)
        Return Password
    End Function
End Class
