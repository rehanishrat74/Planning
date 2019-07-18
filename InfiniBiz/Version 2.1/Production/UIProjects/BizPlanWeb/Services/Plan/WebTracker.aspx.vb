Option Explicit On 
Option Strict Off
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules

#Region "WebTracker"
Imports System.Web.UI.WebControls

Public Class WebTracker
    Inherits BizPlanWebBase
    'Inherits System.Web.UI.Page
    Public objPlanvb As Plan

    Dim username, pass As String
    'Dim project_url As String = WebBuilderEngine.Layout.ContentManagement.GetContent("settings/webTracker/projectname")
    Dim site_name, site_code, site_url, userId, domain_name As String
    Dim bol, bol1, bol2 As Boolean
    Dim sessionInfo As New com.webtracker.webservices.sessionInfo
    Dim WebTrackerServices As New com.webtracker.webservices.WebTrackerServices
    Dim trackInfo As com.webtracker.webservices.trackInfo
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents Tr1 As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents trBottomMain As System.Web.UI.HtmlControls.HtmlTableRow
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Dim detailInfo As New com.webtracker.webservices.detailInfo
    ' Dim objVisitor As Visitor.Page
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CurPage = 2
        CurItem = 0
        ' domain_name = "www.business4less.co.uk" 'dataTblMerchantInfo.Rows(0).Item("domain_name")
      
        Dim dataTblMerchantInfo As System.Data.DataTable
       
        dataTblMerchantInfo = objPlanvb.getMerchantInformation(GetConnectionData)
          If dataTblMerchantInfo.Rows.Count > 0 Then
            domain_name = dataTblMerchantInfo.Rows(0).Item("domain_name")
        End If
        Dim MySqlQuery As String = "select * from projects where projectname = '" & domain_name & "'"
        Try
            site_name = MySqlDataTable(MySqlQuery).Rows(0).Item("caption")
            site_code = MySqlDataTable(MySqlQuery).Rows(0).Item("code")
            site_url = MySqlDataTable(MySqlQuery).Rows(0).Item("projectname")

            If Me.Page.Request.Params("str") Is Nothing Then
            Else
                sessionInfo.siteUrl = site_url
                sessionInfo.siteName = site_name
                sessionInfo.siteCode = site_code
                DisplayTracker()
            End If
        Catch ex As Exception
            'LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
            ' Throw ex
        End Try

        lblHeading.Attributes.Add("onload()", "javascript:void(); return detete()")
    End Sub

    Private Function MySqlDataTable(ByVal Query As String) As DataTable
        Try


            Dim historyDt As DataTable
            Dim dateQuerry As String
            dateQuerry = Query
            Dim mySqldb As New InfiniLogic.BusinessPlan.BLLRules.MySqlLayer
            ' historyDt = mySqldb.GetTrackingDetail(Query)

            '''' Nisar Addition start
            'mySqldb.h_ConString()
            'mySqldb.h_Connection()
            'mySqldb.h_Adpter(dateQuerry)
            'historyDt = mySqldb.h_DatTable(dateQuerry)

            historyDt = mySqldb.GetTrackingDetail(dateQuerry)
            Return historyDt
        Catch ex As Exception
            Dim str As String = ex.Message
            ' LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            'Throw ex
        End Try
    End Function

    Private Sub TrackOnlineMerchant()
        Try
            trackInfo = WebTrackerServices.startSession(sessionInfo)
            Dim data As String = trackInfo.data
            Dim xmlDoc As New XmlDocument
            Dim nodelist As XmlNodeList
            Dim xNode As XmlNode
            xmlDoc.LoadXml(data)
            nodelist = xmlDoc.SelectNodes("/tracker/user")
            Dim Counter As Integer = nodelist.Count - 1
            Dim TEMP1 As String
            For x As Integer = 0 To Counter
                userId = nodelist.Item(x).ChildNodes(0).InnerText()
                Dim createDetail As String = userId
                TEMP1 = TEMP1 & "<table border='1' cellspacing='0' cellpadding='0' width='160' borderColor='ffffff'><tr height='22' onMouseOver=this.style.backgroundColor='#FDFDDF' onMouseOut=this.style.backgroundColor='#EDF3FB' bgColor='#EDF3FB' borderColor='#EDF3FB'  ><td><img src='/images/infiniplan/msngrmen.jpg'/></td><td id=" & userId & "  onClick='getDetails(this.id)' onMouseOver=this.style.cursor='hand' class='bottomlnk' >Guest " & userId & "</td></tr></table>"
            Next
            Me.Page.Response.Clear()
            Me.Page.Response.Write(TEMP1)
            Me.Page.Response.End()
        Catch ex As Exception
            ' LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
    End Sub
    Private Sub TrackMerchantDetails(ByVal getDetails As String)
        Try
            trackInfo = WebTrackerServices.startSession(sessionInfo)
            Dim data As String = trackInfo.data
            ' Dim detailLayout As String = Core.UICache.GetCache(":Layouts/WebTracker_UI/User_Details")
            Dim xmlDoc As New XmlDocument
            Dim nodelist As XmlNodeList
            Dim xNode As XmlNode
            xmlDoc.LoadXml(data)
            nodelist = xmlDoc.SelectNodes("/tracker/user")
            Dim Counter As Integer = nodelist.Count - 1
            Dim TEMP1 As String
            detailInfo.sessionId = trackInfo.ERRORDESC
            detailInfo.trackId = getDetails
            trackInfo = WebTrackerServices.getTrackDetails(detailInfo)
            Dim getData As String = trackInfo.data
            xmlDoc.LoadXml(getData)
            nodelist = xmlDoc.SelectNodes("/userinfo")
            userId = getDetails
            Dim userIP, userBrowser, urlVisited, lastAction, lastVisistedURL, jabber_id, operator_id, customer_id, startTime As String
            Try
                userIP = nodelist.Item(0).ChildNodes(0).InnerText
                userBrowser = nodelist.Item(0).ChildNodes(1).InnerText
                urlVisited = nodelist.Item(0).ChildNodes(2).InnerText
                lastAction = nodelist.Item(0).ChildNodes(3).InnerText
                lastVisistedURL = SortURL(lastAction)
                customer_id = parseCustomerId(lastAction)

                If customer_id.Length > 12 Then : customer_id = "Anonyms"
                Else : customer_id = "Registerd"
                End If
                jabber_id = ParseJabberId(lastAction)
                operator_id = ParseOpreatorId(lastAction)

                jabber_id = jabber_id & " <img src='/images/infiniplan/chat.gif' onClick=""sendQuery('" & operator_id & "','" & jabber_id & "')"">"

                If bol = True Then : jabber_id = "Not Found!"
                End If
                startTime = nodelist.Item(0).ChildNodes(4).InnerText
                'detailLayout = Replace(detailLayout, "~site_url~", site_url)
                'detailLayout = Replace(detailLayout, "~userId~", userId)
                'detailLayout = Replace(detailLayout, "~customer_id~", customer_id)
                'detailLayout = Replace(detailLayout, "~userIP~", userIP)
                'detailLayout = Replace(detailLayout, "~userBrowser~", userBrowser)
                'detailLayout = Replace(detailLayout, "~urlVisited~", urlVisited)
                'detailLayout = Replace(detailLayout, "~lastVisistedURL~", lastVisistedURL)
                'detailLayout = Replace(detailLayout, "~jabber_id~", jabber_id)
                'detailLayout = Replace(detailLayout, "~operator_id~", operator_id)
                'detailLayout = Replace(detailLayout, "~startTime~", startTime)
                If lastVisistedURL = "/" Then : lastVisistedURL = "Default.aspx"
                End If
            Catch ex As Exception
                Me.Context.Trace.Warn("Exception : ", ex.Message & vbCrLf & ex.StackTrace)
            End Try
            'Dim detail_layout As String = detailLayout
            Dim detail_layout As String = "<table width='100%' border='0' cellpadding='5' cellspacing='0' bordercolor='#D6E3F7' ><tr ><td bordercolor='#FFFFFF' width='650'><table><tr height='10'><td><tr><td class='text_style2' >Web Site: </td><td class='text_style2' >" & site_url & " </td></tr><tr><td class='text_style2' >User ID: </td><td class='text_style2' >" & userId & " </td></tr><tr><td class='text_style2' >User Type: </td><td class='text_style2' >" & customer_id & " </td></tr><tr><td class='text_style2' >User IP: </td><td class='text_style2' >" & userIP & " </td></tr><tr><td class='text_style2' >Browser Version: </td><td class='text_style2' >" & userBrowser & " </td></tr><tr><td class='text_style2' >Visited URLs: </td><td class='text_style2' >" & urlVisited & " </td></tr><tr><td class='text_style2' >Last Action On: </td><td class='text_style2' >" & lastVisistedURL & " </td></tr><tr><td class='text_style2' > Jabber ID: </td><td class='text_style2' >" & jabber_id & " </td></tr><tr><td class='text_style2' > Operator ID: </td><td class='text_style2' >" & operator_id & " </td></tr><tr><td class='text_style2' >Started Time: </td><td class='text_style2' >" & startTime & " </td></tr></tr><tr height='20'><td><A HREF='javascript:getDetails2(" + userId + ")' class='bottomlnk' id=" & userId & "   > Track User's Movement </a></td></tr></td></tr></table></td></tr></table>"
            Me.Page.Response.Clear()
            Me.Page.Response.Write(detail_layout)
            Me.Page.Response.End()
        Catch ex As Exception
            '  LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
    End Sub
    Private Sub TrackMerchantHistory(ByVal getDetails As String)
        Try
            trackInfo = WebTrackerServices.startSession(sessionInfo)
            Dim data As String = trackInfo.data
            Dim xmlDoc As New XmlDocument
            Dim nodelist As XmlNodeList
            Dim xNode As XmlNode
            xmlDoc.LoadXml(data)
            nodelist = xmlDoc.SelectNodes("/tracker/user")
            Dim Counter As Integer = nodelist.Count - 1
            Dim TEMP1 As String
            detailInfo.sessionId = trackInfo.ERRORDESC
            detailInfo.trackId = getDetails
            trackInfo = WebTrackerServices.getTrackHistory(detailInfo)
            xmlDoc.LoadXml(trackInfo.data)
            nodelist = xmlDoc.SelectNodes("/userhistory/historyitem")
            Dim junk As String
            For i As Integer = 0 To nodelist.Count - 1
                Dim sno As String = nodelist.Item(i).ChildNodes(0).InnerText
                Dim startedTime As String = nodelist.Item(i).ChildNodes(1).InnerText
                Dim fromURL As String = nodelist.Item(i).ChildNodes(2).InnerText
                Dim toURL, JID As String
                Try
                    toURL = nodelist.Item(i).ChildNodes(3).InnerText
                    JID = ParseJabberId(toURL)
                    If bol = True Then
                        JID = "Not Found!"
                    End If
                Catch ex As Exception
                    Me.Context.Trace.Warn("Exception : ", ex.Message & vbCrLf & ex.StackTrace)
                End Try
                Dim sortedURL As String = SortURL(toURL)
                If sortedURL = "/" Then
                    sortedURL = "Default.aspx"
                ElseIf fromURL = "/" Then
                    fromURL = "Default.aspx"
                End If
                Dim table As String = "<tr height='22' class='text_style2' onMouseOver=this.style.backgroundColor='#FDFDDF' onMouseOut=this.style.backgroundColor='#FFFFFF'  ><td width='5%' align='center'  >" & sno & "</td><td width='20%'>" & fromURL & "</td><td width='45%'>" & sortedURL & "</td><td width='25%' align='center' >" & startedTime & "</td></tr>"
                junk = junk & table
            Next
            Me.Page.Response.Clear()
            Me.Page.Response.Write(junk)
            Me.Page.Response.End()
        Catch ex As Exception
            'LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            'Throw ex
        End Try
    End Sub
    Private Sub DisplayTracker()
        Try
            Dim urlParam As String = Me.Page.Request.Params("str")
            Dim temp() As String = urlParam.Split("_"c)
            If temp(0) = "Refresh" Then
                TrackOnlineMerchant()
            End If
            If temp(0) = "UpDetail" Then
                TrackMerchantDetails(temp(1))
            End If
            If temp(0) = "DownDetail" Then
                TrackMerchantHistory(temp(1))
            End If
        Catch ex As Exception
            ' LogErrors.LogErrorsToEMSdb(CType(userId, Integer), "www.infinishops.com", ex)
            '  Throw ex
            ' Response.Write(ex.Message)
        End Try
    End Sub

    Private Function SortURL(ByVal url As String) As String
        If url.IndexOf("&customerId=") = -1 And url.IndexOf("&customerJID=") - 1 Then
            bol1 = True
            Return url
        Else
            Dim customerJID, customerId, removeJid, urlStr2 As String
            Dim urlStr, JidIndex, IdIndex As Integer
            customerJID = "&customerJID"
            customerId = "&customerId"
            urlStr = url.IndexOf(url)
            JidIndex = url.IndexOf(customerJID)
            removeJid = url.Substring(urlStr, JidIndex)
            IdIndex = url.IndexOf(customerId)
            urlStr2 = url.Substring(urlStr, IdIndex)
            Return urlStr2
        End If
    End Function
    Private Function parseCustomerId(ByVal url As String) As String
        If url.IndexOf("&customerId=") = -1 And url.IndexOf("&customerJID=") = -1 Then
            bol2 = True
            Return url
        Else
            Dim search_str, jabberId, splitJabberId, parseCId As String
            search_str = "&customerId="
            Dim start_index As Integer = url.IndexOf(search_str)
            jabberId = url.Substring(start_index)
            splitJabberId = url.IndexOf("&customerJID")
            parseCId = url.Substring(url.IndexOf(url), splitJabberId)
            Dim splitCustomerId As String() = parseCId.Split("=")
            Return splitCustomerId(1)
        End If
    End Function
    Private Function ParseOpreatorId(ByVal url As String) As String
        If url.IndexOf("operatorJID") = -1 Then
            bol1 = True
            Dim Str As String = "Operator is not Available!"
            Return Str
        Else
            Dim search_str As String = "operatorJID="
            Dim start_index As Integer = url.IndexOf(search_str)
            Dim operatorId As String = url.Substring(start_index)
            Dim splitOperatorId As String() = operatorId.Split("=")
            If splitOperatorId(1) = "null" Or splitOperatorId(1) = "undefined" Then
                splitOperatorId(1) = "Operator is not Available!"
            End If
            Return splitOperatorId(1)
        End If
    End Function
    Private Function ParseJabberId(ByVal url As String) As String
        If url.IndexOf("&customerId=") = -1 Or url.IndexOf("&customerJID=") = -1 Or url.IndexOf("operatorJID=") = -1 Then
            bol = True
            Return url
        Else
            Dim ind_JabberId As Integer = url.IndexOf("&customerJID=")
            Dim jabberId As String = url.Substring(ind_JabberId)
            Dim ind_OperatorId As Integer = jabberId.IndexOf("&operatorJID=")
            Dim splitUrl As String() = jabberId.Split("&")
            Dim splitJabberId As String() = splitUrl(1).Split("=")
            Return splitJabberId(1)
        End If
    End Function

    Private Sub InitializeComponent()

    End Sub
End Class
#End Region
