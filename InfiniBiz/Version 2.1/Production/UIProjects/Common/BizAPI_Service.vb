Imports System.Data
Public Class BizAPI_Service

    Public Shared Sub AddOrderTrack(ByVal ResellerID As String, ByVal OrderID As String, ByVal CompanyID As String, ByVal ProductCode As String, ByVal FHSerialNo As Integer)
        ''--------------------------OrderID Modification----------------------Start
        ''Modified(by) : M.Yousuf()
        ''Date:          Sep 27, 2007
        ''Description:   OrderID can be duplicate so from now it will concatenate with
        ''               reseller id and length of resellerid
        ''Example:       112606       5295     06
        ''               ------       ----     --
        ''               ResellerID   OrderID  Len(ResellerID's Length)

        ''               Last two digits show the length of Resellerid
        ''               which is: 112606
        ''               remaining digits are orderid: 5295
        Dim LongOrderID As String = System.Configuration.ConfigurationSettings.AppSettings("LongOrderID")
        HttpContext.Current.Trace.Write("LongOrderID = " & LongOrderID)
        If LongOrderID = "1" Then
            Dim FH_OrderNo As String
            Dim ResellerIDLength As String = IIf((ResellerID.Length & "").Length = 1, "0" & ResellerID.Length, ResellerID.Length)
            FH_OrderNo = ResellerID & OrderID & ResellerIDLength
            HttpContext.Current.Trace.Write("OrderDetails.orderno = " & FH_OrderNo)
            HttpContext.Current.Trace.Write("Before OrderID=" & OrderID)
            OrderID = FH_OrderNo
            HttpContext.Current.Trace.Write("After OrderID=" & OrderID)
        End If

        Dim Service As New com.reseller.webservices1.ServiceActivation
        Dim Info(0) As com.reseller.webservices1.ActivationTrackInfo
        Dim Detail(0) As com.reseller.webservices1.ActivationTrackDetail
        Dim Result As com.reseller.webservices1.AddOrderActivationTrackResult
        Info(0) = New com.reseller.webservices1.ActivationTrackInfo
        Info(0).CompanyID = CompanyID
        Info(0).OrderID = OrderID
        Info(0).ResellerID = ResellerID
        Detail(0) = New com.reseller.webservices1.ActivationTrackDetail
        Detail(0).FHSerialNo = FHSerialNo
        Detail(0).ProductCode = ProductCode
        Info(0).Detail = Detail

        HttpContext.Current.Trace.Write("Calling AddOrderActivationTrack")
        Result = Service.AddOrderActivationTrack(Info)
        HttpContext.Current.Trace.Write("AddOrderActivationTrack is ok")
        HttpContext.Current.Trace.Write("ERRORCODE" & Result.ERRORCODE)
        HttpContext.Current.Trace.Write("ERRORDESC" & Result.ERRORDESC)
    End Sub

    Public Shared Function IsOrderActivated(ByVal ResellerID As String, ByVal OrderID As Long, ByVal ProductCode As String, ByVal FHSerialNo As Integer) As IsOrderActivatedResult
        ''--------------------------OrderID Modification----------------------Start
        ''Modified(by) : M.Yousuf()
        ''Date:          Sep 27, 2007
        ''Description:   OrderID can be duplicate so from now it will concatenate with
        ''               reseller id and length of resellerid
        ''Example:       112606       5295     06
        ''               ------       ----     --
        ''               ResellerID   OrderID  Len(ResellerID's Length)

        ''               Last two digits show the length of Resellerid
        ''               which is: 112606
        ''               remaining digits are orderid: 5295
        Dim LongOrderID As String = System.Configuration.ConfigurationSettings.AppSettings("LongOrderID")
        HttpContext.Current.Trace.Write("LongOrderID = " & LongOrderID)
        If LongOrderID = "1" Then
            Dim FH_OrderNo As String
            Dim ResellerIDLength As String = IIf((ResellerID.Length & "").Length = 1, "0" & ResellerID.Length, ResellerID.Length)
            FH_OrderNo = ResellerID & OrderID & ResellerIDLength
            HttpContext.Current.Trace.Write("OrderDetails.orderno = " & FH_OrderNo)
            HttpContext.Current.Trace.Write("Before OrderID=" & OrderID)
            OrderID = FH_OrderNo
            HttpContext.Current.Trace.Write("After OrderID=" & OrderID)
        End If

        Dim Service As New com.reseller.webservices1.ServiceActivation
        Dim Info As New com.reseller.webservices1.IsOrderActivatedInfo
        Dim objIsOrderActivatedResult As com.reseller.webservices1.IsOrderActivatedResult
        Dim Result As New IsOrderActivatedResult
        Info.FHSerialNo = FHSerialNo
        Info.OrderID = OrderID
        Info.ProductCode = ProductCode
        Info.ResellerID = ResellerID

        objIsOrderActivatedResult = Service.IsOrderActivated(Info)

        HttpContext.Current.Trace.Write("ERRORCODE" & objIsOrderActivatedResult.ERRORCODE)
        HttpContext.Current.Trace.Write("ERRORDESC" & objIsOrderActivatedResult.ERRORDESC)
        Result.CompanyID = objIsOrderActivatedResult.CompanyID
        Result.ServiceAlreadyActivated = objIsOrderActivatedResult.OrderAlreadyActivated

        Return Result
    End Function
    Public Structure IsOrderActivatedResult
        Public ServiceAlreadyActivated As Boolean
        Public CompanyID As Long
    End Structure
End Class
