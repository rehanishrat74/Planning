Public Class WebServices

#Region " Protected Variables "

    Protected _XMLNodes As Hashtable
    Protected _WebSrvc As WebService

#End Region

#Region " Constructors "

    Private Sub New()

    End Sub

    Public Sub New(ByVal WebSrvc As WebService)
        _WebSrvc = WebSrvc
    End Sub

#End Region

#Region " Public Functions "

    Public Function CollectionSeriviceValidate(ByVal strXML As String) As String
        Dim CXLResponse As String
        Dim _objInfiniWebService As New InfiniShopsWS.WebService
        Try
            CXLResponse = _objInfiniWebService.CollectionServices(strXML)
        Catch ex As Exception
            CXLResponse = "Error:" & ex.Message
        End Try
        Return CXLResponse
    End Function

    'Public Function CallWebService() As String
    '    Return Microsoft.VisualBasic.Switch(_WebSrvc = WebService.CollectionServices, "", _
    '        '   _WebSrvc = WebService.OrderNew, PlaceOrder)

    'End Function

    Public Function AddXMLNode(ByVal strnodeName As String, Optional ByVal strnodeValue As String = "")
        _XMLNodes.Add(strnodeName, strnodeValue)
    End Function

    Public Function SetWebService(ByVal WebSrvc As WebService)
        _WebSrvc = WebSrvc
        _XMLNodes.Clear()
    End Function

    Public Function CreateXML(ByVal nodes As Hashtable) As String
        Dim str As String
        'For Each str In nodes.
        '    With nodes

        '    End With
        'Next
    End Function

#End Region

#Region " Private & Protected functions "

    Protected Function NewOrder() As String
        Dim CXLResponse As String
        Dim _objInfiniWebService As New InfiniShopsWS.WebService
        With _objInfiniWebService
            Try
                CXLResponse = .Order_New(GetCollectionServiceString)
                Return GetOrderID(CXLResponse)
            Catch e As EntryPointNotFoundException
                CXLResponse = "Error:" & e.Message
            End Try
        End With
        'Return
    End Function

    Protected Function CollectionService() As String
        Dim strNewOrder As New Text.StringBuilder(1000)

        CollectionSeriviceValidate("")
    End Function

    Protected Function GetCollectionServiceString() As String
        Dim strXML As New Text.StringBuilder(1000)
        Dim str As String

        With strXML
            Select Case _WebSrvc
                Case WebService.CollectionServices
                    '-------------------------------------------
                    .Append("<Data>")
                    .Append("<Sender>" & _XMLNodes.Item("Sender") & "</Sender>")
                    .Append("<MerchantID>" & _XMLNodes.Item("MerchantID") & "</MerchantID>")
                    .Append("<CustomerID>" & _XMLNodes.Item("CustomerID") & "</CustomerID>")
                    .Append("<MerchantUID>" & _XMLNodes.Item("MerchantUID") & "</MerchantUID>")
                    .Append("<CustomerUID>" & _XMLNodes.Item("CustomerUID") & "</CustomerUID>")
                    .Append("<OrderID>" & _XMLNodes.Item("OrderID") & "</OrderID>")
                    .Append("<PaymentMode>" & _XMLNodes.Item("PaymentMode") & "</PaymentMode>")
                    .Append("<Mode>" & _XMLNodes.Item("Mode") & "</Mode>")
                    .Append("<GenericCode>826</GenericCode>")
                    .Append("</Data>")

                    '-------------------------------------------
                Case WebService.OrderNew

                    .Append("<ShoppingCart>")
                    .Append("<OrderInfo>")
                    .Append("<Date>" & _XMLNodes.Item("Date") & "</Date>")
                    .Append("<PromiseShipeDate>" & _XMLNodes.Item("PromiseShipeDate") & "</PromiseShipeDate>")
                    .Append("<ShipeDate>" & _XMLNodes.Item("ShipeDate") & "</ShipeDate>")
                    .Append("<CardType>" & _XMLNodes.Item("CardType") & "</CardType>")
                    .Append("<CardName>" & _XMLNodes.Item("CardName") & "</CardName>")
                    .Append("<CardNumber>" & _XMLNodes.Item("CardNumber") & "</CardNumber>")
                    .Append("<CardAddress>" & _XMLNodes.Item("CardAddress") & "</CardAddress>")
                    .Append("<DeliveryAddress" & _XMLNodes.Item("DeliveryAddress") & "</DeliveryAddress>")
                    .Append("<StartDate" & _XMLNodes.Item("StartDate") & "</StartDate>")
                    .Append("<EndDate" & _XMLNodes.Item("EndDate") & "</EndDate>")
                    .Append("<CardExpires" & _XMLNodes.Item("CardExpires") & "</CardExpires>")
                    .Append("<IssueNumber" & _XMLNodes.Item("IssueNumber") & "</IssueNumber>")
                    .Append("<SecurityCode" & _XMLNodes.Item("SecurityCode") & "</SecurityCode>")
                    .Append("<PaymentProcessBy" & _XMLNodes.Item("PaymentProcessBy") & "</PaymentProcessBy>")
                    .Append("<CountryCode" & _XMLNodes.Item("CountryCode") & "</CountryCode>")
                    .Append("<CurrencyCode" & _XMLNodes.Item("CurrencyCode") & "</CurrencyCode>")
                    .Append("<GenericCode" & _XMLNodes.Item("GenericCode") & "</GenericCode>")
                    .Append("<TaxCode" & _XMLNodes.Item("TaxCode") & "</TaxCode>")
                    .Append("<TaxRate" & _XMLNodes.Item("TaxRate") & "</TaxRate>")
                    .Append("<OrderAmount" & _XMLNodes.Item("OrderAmount") & "</OrderAmount>")
                    .Append("<CustomerID" & _XMLNodes.Item("CustomerID") & "</CustomerID>")
                    .Append("<Ac" & _XMLNodes.Item("Ac") & "</Ac>")
                    .Append("<MerchantID" & _XMLNodes.Item("MerchantID") & "</MerchantID>")
                    .Append("</OrderInfo>")
                    .Append("<Products>")
                    .Append(_XMLNodes.Item("ProductDetails"))
                    .Append("<Product/>")
                    .Append("</Products>")
                    .Append("<Questions>")
                    .Append("</Questions>")
                    .Append("</ShoppingCart>")

                    '-------------------------------------------

            End Select

            Return .ToString

        End With

    End Function


    Protected Function GetOrderID(ByVal CXLResponse As String) As String

    End Function

#End Region

End Class

Public Enum WebService
    OrderNew
    CollectionServices
End Enum

