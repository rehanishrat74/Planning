Option Explicit On 
Option Strict Off

Imports System.IO
Imports System.Text

Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports Infinilogic.BusinessPlan.Web.Common
Imports Infinilogic.BusinessPlan.BLLRules


Imports System.Web.UI.WebControls

Public Class WebTracker
    Inherits BizPlanWebBase
    ' Inherits System.Web.UI.Page

#Region "Variables"

    Public objPlanvb As Plan
    Dim SessionStart As String
    Dim SessionEnd As String
    Dim dateStart As String
    Dim dateEnd As String
    Shared dsProduct As DataSet
    Dim strSelection As String
    Protected WithEvents Username As System.Web.UI.WebControls.Label
    Protected WithEvents Se_CurrentWeek As System.Web.UI.WebControls.Label
    Dim DataView1 As DataView
    Protected WithEvents ShowHistory As System.Web.UI.WebControls.Button
    Dim pass As String
    Dim site_name, site_code, site_url, domain_name As String
    Dim bol, bol1, bol2 As Boolean
    Dim sessionInfo As New com.webtracker.webservices.sessionInfo
    Dim WebTrackerServices As New com.webtracker.webservices.WebTrackerServices
    Dim trackInfo As com.webtracker.webservices.trackInfo
    Protected WithEvents lblFAQs As System.Web.UI.WebControls.Label
    Protected WithEvents dgProducts As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgProductActivity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgProductReferrer As System.Web.UI.WebControls.DataGrid
    Protected WithEvents childgrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dgActivity As System.Web.UI.WebControls.DataGrid
    Protected WithEvents lblOption As System.Web.UI.WebControls.Label
    Protected WithEvents lblHeading As System.Web.UI.WebControls.Label
    Protected WithEvents DatePanel As System.Web.UI.WebControls.Panel
    Protected WithEvents testpanel As System.Web.UI.WebControls.Panel
    Dim detailInfo As New com.webtracker.webservices.detailInfo
    Protected WithEvents myCurrentPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents historytable As System.Web.UI.WebControls.Table
    Protected WithEvents userInformation As System.Web.UI.WebControls.Label
    Protected WithEvents test As System.Web.UI.WebControls.Label
    Protected WithEvents ddlHisrotyOption As System.Web.UI.WebControls.DropDownList 'RadioButtonList
    Protected WithEvents AjaxPanel1 As MagicAjax.UI.Controls.AjaxPanel
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents BDPLiteFrom As BasicFrame.WebControls.BDPLite
    Protected WithEvents BDPLiteTo As BasicFrame.WebControls.BDPLite
    Protected WithEvents myHistoryPanel As System.Web.UI.WebControls.Panel
    Protected WithEvents id1 As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents id2 As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents id3 As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents id4 As System.Web.UI.HtmlControls.HtmlInputRadioButton
    Protected WithEvents lbtnProduct As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbtnTrackActivity As System.Web.UI.WebControls.LinkButton
    Protected WithEvents lbtnTrackReferrer As System.Web.UI.WebControls.LinkButton
    Protected WithEvents Se_Today As System.Web.UI.WebControls.Label
    Protected WithEvents Se_LastDay As System.Web.UI.WebControls.Label
    Protected WithEvents Se_LastMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Se_Period As System.Web.UI.WebControls.Label
    Protected WithEvents tdLeftMain1 As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents SessionTable As System.Web.UI.WebControls.Table
    Dim ContentToWrite As String = String.Empty
    Dim isession As Integer
    Dim _xmldoc As New XmlDocument
    Dim _xmlElement1 As XmlElement
    Dim _xmlAttribute1 As XmlAttribute
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents Today As System.Web.UI.WebControls.Label
    Protected WithEvents Lastday As System.Web.UI.WebControls.Label
    Protected WithEvents LastMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Period As System.Web.UI.WebControls.Label
    Protected WithEvents lblHead As System.Web.UI.WebControls.Label
    Protected WithEvents tdLeftMain As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents CurrentMonth As System.Web.UI.WebControls.Label
    Protected WithEvents Se_CurrentMonth As System.Web.UI.WebControls.Label
    Protected WithEvents chkTime As System.Web.UI.WebControls.DropDownList
    Dim dstest As DataSet

#End Region '

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Page.Trace.Write("In Page Load")

        SetFocus(testpanel)
        CurPage = 2
        CurItem = 0
        Dim dataTblMerchantInfo As System.Data.DataTable

        Try
            dataTblMerchantInfo = objPlanvb.getMerchantInformation(GetConnectionData)
            If dataTblMerchantInfo.Rows.Count > 0 Then
                domain_name = dataTblMerchantInfo.Rows(0).Item("domain_name")
                Session("Domain") = domain_name
                site_url = "http://" + domain_name
                Page.Trace.Write("url = " & site_url)
                DisplayTracker()
            End If
            SessionCount()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        lblHeading.Attributes.Add("onload()", "javascript:void(); return detete()")

        ' History Panel

        If Session("date") Is Nothing Then
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
        ElseIf Session("date") = 1 Then
            BDPLiteFrom.Enabled = True
            BDPLiteTo.Enabled = True
        End If

        Dim IstLoad As String = IIf(viewstate("Tracker") Is Nothing, 1, viewstate("Tracker"))

        If IstLoad = 1 Then
            Try
                ddlHisrotyOption.SelectedIndex = 0
                ddlHisrotyOption_SelectedIndexChanged(sender, e)
                viewstate("Tracker") = IIf(IstLoad = "1", "2", "2")

            Catch ex As Exception
                Session("Tracker") = Nothing
                Trace.Warn("Error in  Session( Tracker )")
            End Try
        Else

        End If
        Page.Trace.Write("In Page Load End ")

    End Sub


#Region " Country work "

    'Activity
    Private Sub dgActivity_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgActivity.ItemCommand

        Trace.Warn("--------- :: dgActivity_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                If e.CommandName = "LoadgridActivity" Then
                    Dim _dg As DataGrid
                    _dg = Me.dgActivity.Items(e.Item.ItemIndex).FindControl("childgridActivity")
                    _dg.Visible = Not _dg.Visible
                    If _dg.Visible Then BindChildActivityGrid(e.Item.ItemIndex)
                End If
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: dgActivity_ItemCommand ex.Message:: --------------" & ex.Message)
            Dim strError As String = ex.Message
        End Try
        Trace.Warn("--------- :: dgActivity_ItemCommand :: --------------")
    End Sub
    Public Sub childgridActivity_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)



        Trace.Warn("--------- :: childgridActivity_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = source.Items(e.Item.ItemIndex).FindControl("childgridActivityDetail")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildActivityGridDetail(e.Item.ItemIndex, source)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: childgridActivity_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: childgridActivity_ItemCommand :: --------------")
    End Sub
    Public Sub BindChildActivityGrid(ByVal index As Integer)
        Trace.Warn("--------- :: BindChildActivityGrid :: --------------")
        Dim strCountry As String = CType(Me.dgActivity.Items(index).FindControl("lblActCountry"), Label).Text
        Trace.Warn("--------- :: BindChildActivityGrid strCountry:: --------------" & strCountry)

        CType(Me.dgActivity.Items(index).FindControl("childgridActivity"), DataGrid).Visible = True
        CType(Me.dgActivity.Items(index).FindControl("childgridActivity"), DataGrid).DataSource = BLLRules.WebTracker.GetTotalHistory_CountryName_IPActivity(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry)
        CType(Me.dgActivity.Items(index).FindControl("childgridActivity"), DataGrid).DataBind()

    End Sub
    Public Sub BindChildActivityGridDetail(ByVal index As Integer, ByVal source As DataGrid)
        Trace.Warn("--------- :: BindChildActivityGridDetail :: --------------")
        Dim strCountry As String = CType(source.Items(index).FindControl("Country_activity"), Label).Text
        Dim IPAddress As String = CType(source.Items(index).FindControl("IP_Activity"), Label).Text
        Trace.Warn("--------- :: BindChildActivityGridDetail strCountry:: --------------" & strCountry)

        CType(source.Items(index).FindControl("childgridActivityDetail"), DataGrid).Visible = True
        CType(source.Items(index).FindControl("childgridActivityDetail"), DataGrid).DataSource = Me.GetTotalHistory_CountryName_IPDetailActivity(Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry, IPAddress)
        CType(source.Items(index).FindControl("childgridActivityDetail"), DataGrid).DataBind()

    End Sub
    Private Function GetTotalHistory_CountryName_IPDetailActivity(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String, ByVal IPAddress As String) As DataTable
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

        Dim dt As DataTable
 
        dt = New DataTable
        dt.Columns.Add("Sr", Type.GetType("System.String"))
        dt.Columns.Add("UniQueSession", Type.GetType("System.String"))
        dt.Columns.Add("IP", Type.GetType("System.String"))
        dt.Columns.Add("Country", Type.GetType("System.String"))

        Dim dsProduct As DataSet
        Dim counter As Integer = 1
        Try
            dsProduct = BLLRules.WebTracker.GetTotalHistory_CountryName_IPDetailActivity(GetConnectionData, StartDate, EndDate, DomainName, CountryName, IPAddress)

            If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

                Dim dr As DataRow
                For Each dr In dsProduct.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    temp_dr = dt.NewRow()

                    Dim sno As String = counter
                    temp_dr("Sr") = sno

                    Dim UniQueSession As String = dr("UniQueSession") & ""
                    Dim _UniQueSession As New StringBuilder
                    _UniQueSession.Append(" <a HREF=javascript:getDetails_CustomerActivity('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & UniQueSession & "   </a> &nbsp;")
                    temp_dr("UniQueSession") = _UniQueSession

                    
 
                    Dim _ip As String = dr("IP") & ""
                    temp_dr("IP") = _ip

                    Dim _countryName As String
                    If CStr(dr("Country")) = "" Then _countryName = "N/A" & "" Else _countryName = CStr(dr("Country")) & ""
                    temp_dr("Country") = _countryName




                    counter += 1S
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Trace.Warn("--------- :: GetTotalHistory_CountryName :: x.message --------------" & ex.Message)

            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

    End Function
   
    'Private Function GetUserLog_HistoryActivity_CountryDetail(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal strName As String) As DataTable
    '    Trace.Warn("--------- :: GetUserLog_HistoryActivity_CountryDetail :: --------------")

    '    Dim dt As DataTable = Me.BuildDT()
    '    Dim ds As DataSet
    '    Dim counter As Integer = 1
    '    Try
    '        ds = BLLRules.WebTracker.BPL_WEBTRACKER_GetUserLog_ActivityHistory_CountryDetail(GetConnectionData, StartDate, EndDate, DomainName, strName)

    '        If Not ds Is Nothing And ds.Tables.Count = 1 Then
    '            Dim dr As DataRow
    '            For Each dr In ds.Tables(0).Rows
    '                Dim oldString As String, newString As String
    '                Dim startStr As Integer, endStr As Integer, indexDiff As Integer
    '                ' Start Condition 
    '                Dim temp_dr As DataRow
    '                Dim Product As String

    '                temp_dr = dt.NewRow()
    '                Dim sno As String = counter
    '                temp_dr("Sr") = sno



    '                Dim ip As String = dr("ip") & ""
    '                temp_dr("IP") = ip

    '                Dim _countryName As String
    '                If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
    '                temp_dr("Country") = _countryName


    '                Dim cusomterid As String = dr("customer_uid") & ""

    '                Dim _customerID As New StringBuilder
    '                _customerID.Append(" <a HREF=javascript:getDetails_CustomerActivity('" & cusomterid & "') class='bottomlnk' id=" & cusomterid & ">" & cusomterid & "   </a> &nbsp;")
    '                temp_dr("CustomerID") = _customerID.ToString

    '                counter += 1
    '                dt.Rows.Add(temp_dr)

    '                ' Start Condition 
    '            Next
    '        End If
    '        dt.AcceptChanges()
    '        Return dt
    '    Catch ex As Exception
    '        Trace.Warn("--------- :: GetUserLog_HistoryActivity_CountryDetail ::  ex.Message --------------" & ex.Message)

    '        Page.Trace.Warn("EXception : " & ex.Message)
    '        Throw ex
    '    Finally
    '    End Try
    '    Trace.Warn("--------- :: GetUserLog_HistoryActivity_CountryDetail :: --------------")

    'End Function

   
    Private Sub dgProductActivity_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductActivity.ItemCommand

        Trace.Warn("--------- :: dgProductActivity_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = Me.dgProductActivity.Items(e.Item.ItemIndex).FindControl("childgrid")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildGrid(e.Item.ItemIndex)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: dgProductActivity_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: dgProductActivity_ItemCommand :: --------------")
    End Sub
    Public Sub childgeid_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)



        Trace.Warn("--------- :: childgeid_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = source.Items(e.Item.ItemIndex).FindControl("childgridDetail")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildGridDetail(e.Item.ItemIndex, source)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: childgeid_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: childgeid_ItemCommand :: --------------")
    End Sub
    Public Sub BindChildGrid(ByVal index As Integer)
        Trace.Warn("--------- :: BindChildGrid :: --------------")

        Dim strCountry As String = CType(Me.dgProductActivity.Items(index).FindControl("lblCountry"), Label).Text
        Trace.Warn("--------- :: BindChildGrid strCountry:: --------------" & strCountry)
        CType(Me.dgProductActivity.Items(index).FindControl("childgrid"), DataGrid).DataSource = BLLRules.WebTracker.GetTotalHistory_CountryName_IP(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry) 'GetTotalHistory_CountryName(Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry)
        CType(Me.dgProductActivity.Items(index).FindControl("childgrid"), DataGrid).DataBind()

    End Sub
    Public Sub BindChildGridDetail(ByVal index As Integer, ByVal source As DataGrid)
        Trace.Warn("--------- :: BindChildGridDetail :: --------------")
        Dim strCountry As String = CType(source.Items(index).FindControl("Country_ip"), Label).Text
        Dim IPAddress As String = CType(source.Items(index).FindControl("IP_ip"), Label).Text

        Trace.Warn("--------- :: BindChildGrid BindChildGridDetail:: --------------" & strCountry)
        CType(source.Items(index).FindControl("childgridDetail"), DataGrid).DataSource = Me.GetTotalHistory_CountryName_IPDetail(Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry, IPAddress)
        CType(source.Items(index).FindControl("childgridDetail"), DataGrid).DataBind()
        Trace.Warn("--------- :: BindChildGrid BindChildGridDetail:: --------------" & IPAddress)

    End Sub
    Private Function GetTotalHistory_CountryName_IPDetail(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal CountryName As String, ByVal IPAddress As String) As DataTable
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

        Dim dt As DataTable = Me.BuildDataTableForSessionHistory()
        Dim dsProduct As DataSet
        Dim counter As Integer = 1
        Try
            dsProduct = BLLRules.WebTracker.GetTotalHistory_CountryName_IPDetail(GetConnectionData, StartDate, EndDate, DomainName, CountryName, IPAddress)

            If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

                Dim dr As DataRow
                For Each dr In dsProduct.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    temp_dr = dt.NewRow()

                    Dim sno As String = counter
                    temp_dr("Sr") = sno

                    Dim UniQueSession As String = dr("UniQueSession") & ""
                    temp_dr("UniQueSession") = UniQueSession



                    Dim ProductVisited As String = dr("ProductVisited") & ""
                    Dim Sessions As New StringBuilder
                    Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
                    Sessions.Append(" <tr>")
                    Sessions.Append(" <td align='center'>")
                    Sessions.Append(" <a HREF=javascript:getDetails_Customer('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & ProductVisited & "   </a> &nbsp;")
                    Sessions.Append(" </td>")
                    Sessions.Append(" </tr>")
                    Sessions.Append("</table>")

                    temp_dr("ProductVisited") = Sessions.ToString

                    Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, UniQueSession)
                    Dim TotalOrders As String = _orderCount

                    Dim Order As New StringBuilder

                    If TotalOrders = "0" Then

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'  >")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center' class='bottomlnk'>")
                        Order.Append("0 ")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    Else

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center'>")
                        Order.Append(" <a HREF=javascript:LoadDiv('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalOrders & "   </a> &nbsp;")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    End If

                    Dim _ip As String = dr("IP") & ""
                    temp_dr("IP") = _ip

                    Dim _countryName As String
                    If CStr(dr("Country")) = "" Then _countryName = "N/A" & "" Else _countryName = CStr(dr("Country")) & ""
                    temp_dr("Country") = _countryName




                    counter += 1S
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Trace.Warn("--------- :: GetTotalHistory_CountryName :: x.message --------------" & ex.Message)

            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

    End Function

    'Referrer

    Private Sub dgProductReferrer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgProductReferrer.ItemCommand

        Trace.Warn("--------- :: dgProductReferrer_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = Me.dgProductReferrer.Items(e.Item.ItemIndex).FindControl("childgridReferrer")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildGridReferrer(e.Item.ItemIndex)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: dgProductReferrer_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: dgProductReferrer_ItemCommand :: --------------")
    End Sub
    Public Sub childgeidReferrer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Trace.Warn("--------- :: childgeidReferrer_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = source.Items(e.Item.ItemIndex).FindControl("childgridDetailReferrer")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildGridDetailReferrer(e.Item.ItemIndex, source)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: childgeidReferrer_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: childgeidReferrer_ItemCommand :: --------------")
    End Sub
    Public Sub childgridDetailReferrer_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs)

        Trace.Warn("--------- :: childgeidReferrer_ItemCommand :: --------------")
        Try
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim _dg As DataGrid
                _dg = source.Items(e.Item.ItemIndex).FindControl("childgridDetailReferrerbyIP")
                _dg.Visible = Not _dg.Visible
                If _dg.Visible Then BindChildGridDetailReferrerBYIP(e.Item.ItemIndex, source)
            End If
        Catch ex As Exception
            Trace.Warn("--------- :: childgeidReferrer_ItemCommand ex.Message:: --------------" & ex.Message)

            Dim strError As String = ex.Message
        End Try

        Trace.Warn("--------- :: childgeidReferrer_ItemCommand :: --------------")
    End Sub

    Public Sub BindChildGridReferrer(ByVal index As Integer)
        Trace.Warn("--------- :: BindChildGridReferrer :: --------------")

        Dim strReferrer As String = CType(Me.dgProductReferrer.Items(index).FindControl("lblReferrer"), Label).Text
        Trace.Warn("--------- :: BindChildGrid strCountry:: --------------" & strReferrer)
        CType(Me.dgProductReferrer.Items(index).FindControl("childgridReferrer"), DataGrid).DataSource = BLLRules.WebTracker.GetTotalHistory_UniqueReferrer(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strReferrer) 'GetTotalHistory_CountryName(Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strCountry)
        CType(Me.dgProductReferrer.Items(index).FindControl("childgridReferrer"), DataGrid).DataBind()

    End Sub
    Public Sub BindChildGridDetailReferrer(ByVal index As Integer, ByVal source As DataGrid)
        Trace.Warn("--------- :: BindChildGridDetail :: --------------")
        Dim strChildReferrer As String = CType(source.Items(index).FindControl("lblChildReferrer"), Label).Text
        Dim strChildRefCountry As String = CType(source.Items(index).FindControl("lblChildRefCountry"), Label).Text

        Trace.Warn("--------- :: BindChildGridReferrer BindChildGridDetail:: --------------" & strChildReferrer)
        CType(source.Items(index).FindControl("childgridDetailReferrer"), DataGrid).DataSource = BLLRules.WebTracker.GetTotalHistory_UniqueReferrerCountry(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strChildReferrer, strChildRefCountry)
        CType(source.Items(index).FindControl("childgridDetailReferrer"), DataGrid).DataBind()
        Trace.Warn("--------- :: BindChildGridReferrer BindChildGridDetail:: --------------" & strChildRefCountry)

    End Sub
    Public Sub BindChildGridDetailReferrerBYIP(ByVal index As Integer, ByVal source As DataGrid)
        Trace.Warn("--------- :: BindChildGridDetailReferrerBYIP :: --------------")
        Dim strChildReferrer As String = CType(source.Items(index).FindControl("referrer_Ref"), Label).Text
        Dim strChildRefCountry As String = CType(source.Items(index).FindControl("referrer_country"), Label).Text
        Dim strChildRefIP As String = CType(source.Items(index).FindControl("referrer_ip"), Label).Text

        Trace.Warn("--------- :: BindChildGridDetailReferrerBYIP  :: --------------" & strChildReferrer)
        CType(source.Items(index).FindControl("childgridDetailReferrerbyIP"), DataGrid).DataSource = Me.GetTotalReferrer_CountryName_IPDetail(Session("SessionStart"), Session("SessionEnd"), Me.domain_name, strChildReferrer, strChildRefCountry, strChildRefIP)
        CType(source.Items(index).FindControl("childgridDetailReferrerbyIP"), DataGrid).DataBind()
        Trace.Warn("--------- :: BindChildGridDetailReferrerBYIP BindChildGridDetailReferrerBYIP:: --------------" & strChildRefCountry)

    End Sub

    Private Function GetTotalReferrer_CountryName_IPDetail(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String, ByVal ReferrerName As String, ByVal CountryName As String, ByVal IPAddress As String) As DataTable
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

        Dim dt As DataTable = Me.BuildDTReferrer()
        Dim dsProduct As DataSet
        Dim counter As Integer = 1
        Try
            dsProduct = BLLRules.WebTracker.GetTotalReferrer_CountryName_IPDetail(GetConnectionData, StartDate, EndDate, DomainName, ReferrerName, CountryName, IPAddress)

            If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

                Dim dr As DataRow
                For Each dr In dsProduct.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    temp_dr = dt.NewRow()

                    Dim sno As String = counter
                    temp_dr("Sid") = sno

                    Dim UniQueSession As String = dr("UniQueSession") & ""
                    temp_dr("UniQueSession") = UniQueSession

                    Dim Referrer As String = dr("Referrer") & ""
                    temp_dr("Referrer") = Referrer

                    Dim ProductVisited As String = dr("ProductVisited") & ""
                    Dim Sessions As New StringBuilder
                    Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
                    Sessions.Append(" <tr>")
                    Sessions.Append(" <td align='center'>")
                    Sessions.Append(" <a HREF=javascript:getDetails_CustomerReferrer('" & UniQueSession & "~" & Referrer & "') class='bottomlnk' id=" & UniQueSession & ">" & ProductVisited & "   </a> &nbsp;")
                    Sessions.Append(" </td>")
                    Sessions.Append(" </tr>")
                    Sessions.Append("</table>")

                    temp_dr("ProductVisited") = Sessions.ToString

                    Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, UniQueSession)
                    Dim TotalOrders As String = _orderCount

                    Dim Order As New StringBuilder

                    If TotalOrders = "0" Then

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'  >")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center' class='bottomlnk'>")
                        Order.Append("0 ")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    Else

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center'>")
                        Order.Append(" <a HREF=javascript:LoadDiv('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalOrders & "   </a> &nbsp;")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    End If

                    Dim _ip As String = dr("IP") & ""
                    temp_dr("IP") = _ip

                    Dim _countryName As String
                    If CStr(dr("Country")) = "" Then _countryName = "N/A" & "" Else _countryName = CStr(dr("Country")) & ""
                    temp_dr("Country") = _countryName




                    counter += 1S
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Trace.Warn("--------- :: GetTotalHistory_CountryName :: x.message --------------" & ex.Message)

            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
        Trace.Warn("--------- :: GetTotalHistory_CountryName :: --------------")

    End Function
    Private Function BuildDTReferrer() As System.Data.DataTable

        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Sid", Type.GetType("System.String"))
            dt.Columns.Add("UniQueSession", Type.GetType("System.String"))
            dt.Columns.Add("Referrer", Type.GetType("System.String"))
            dt.Columns.Add("ProductVisited", Type.GetType("System.String"))
            dt.Columns.Add("TotalOrders", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function LoadCustomerSpecificSessionReferrer(ByVal _CustID As String, ByVal _referrer As String) As String
        Page.Trace.Write("In LoadCustomerSpecificSessionReferrer")
        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForUserHistory()

        Try
            Dim a As String

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' 	content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            ds = BLLRules.WebTracker.GetCustomerHistoryDetailReferrer(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, _CustID, _referrer)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    '  If dr("ProductId") <> "0" Then  'dr("referrer") <> "" And 
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno

                    Dim startedTime As String = dr("TimeStamp") & ""
                    temp_dr("StartedTime") = startedTime

                    Dim fromURL As String = dr("tourl") & ""
                    If fromURL = "/" Then
                        fromURL = "Default.aspx"
                    End If
                    temp_dr("FromURL") = fromURL

                    Dim ip As String = dr("ip") & ""
                    temp_dr("IP") = ip

                    Dim _countryName As String
                    If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                    temp_dr("Country") = _countryName
                    '
                    Dim cusomterid As String = dr("customer_uid") & ""
                    temp_dr("CustomerID") = cusomterid

                    Dim referrer As String = dr("referrer") & ""
                    temp_dr("referrer") = referrer

                    Dim productID As String = dr("ProductId").ToString().Trim() & ""
                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If productID = "0" Then
                        temp_dr("Product") = "&nbsp;"
                    Else
                        temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)
                    '   End If
                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForUser_History()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()
            If dg.Items.Count = 0 Then
                dg.Visible = False

            End If
        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSessionReferrer End")

    End Function


#End Region

    Private Sub ddlHisrotyOption_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHisrotyOption.SelectedIndexChanged

        lblOption.Text = ""
        If ddlHisrotyOption.SelectedIndex = 0 Then
            DatePanel.Enabled = False
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("date") = Nothing
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        ElseIf ddlHisrotyOption.SelectedIndex = 1 Then
            DatePanel.Enabled = False
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("date") = Nothing
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        ElseIf ddlHisrotyOption.SelectedIndex = 2 Then
            DatePanel.Enabled = False
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("date") = Nothing
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        ElseIf ddlHisrotyOption.SelectedIndex = 3 Then
            DatePanel.Enabled = False
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("date") = Nothing
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        ElseIf ddlHisrotyOption.SelectedIndex = 4 Then
            DatePanel.Enabled = False
            BDPLiteFrom.Enabled = False
            BDPLiteTo.Enabled = False
            BDPLiteFrom.SelectedValue = ""
            BDPLiteTo.SelectedValue = ""
            Session("date") = Nothing
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        ElseIf ddlHisrotyOption.SelectedIndex = 5 Then

            DatePanel.Enabled = True

            BDPLiteFrom.Enabled = True
            BDPLiteTo.Enabled = True
            Session("date") = 1
            lbtnProduct.Enabled = True
            lbtnTrackActivity.Enabled = True
            lbtnTrackReferrer.Enabled = True
            lbtnProduct_Click(sender, e)
        End If

    End Sub

    Private Sub lbtnProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtnProduct.Click
        Trace.Warn("--------- :: lbtnProduct_Click :: --------------")
        Page.Trace.Write("In lbtnProduct_Click")
        Session("TrackProduct") = True
        Dim dPreMonth As New Date
        Dim ds_domain As DataSet

        ds_domain = Me.GetCurrentSessions(Me.domain_name)

        If ddlHisrotyOption.SelectedIndex = 0 Then
            lblOption.Text = " Today Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Product)

            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 1 Then
            lblOption.Text = "Yesterday Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Product)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 2 Then
            lblOption.Text = "This Week Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                Dim week As New TimeSpan(6, 23, 59, 59)
                dateStart = Date.Today.Subtract(week).ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Product)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 3 Then
            lblOption.Text = " This Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                dateStart = CurrentmonthStart
                dateEnd = CurrentmonthEnd
                ExecuteForActivity_History(CurrentmonthStart, CurrentmonthEnd, HistroyType.Product)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 4 Then
            lblOption.Text = " Last Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                dateStart = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
                Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
                Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
                dateEnd = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Product)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 5 Then
            lblOption.Text = " Period Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then

                If (BDPLiteFrom.SelectedValue) Is Nothing Then
                    dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                    Session("dateStart") = Date.Now.ToLongDateString
                    BDPLiteFrom.SelectedValue = Session("dateStart")
                Else
                    dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                End If

                If BDPLiteTo.SelectedValue Is Nothing Then
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                    Session("dateTo") = Date.Now.ToLongDateString
                    BDPLiteTo.SelectedValue = Session("dateTo")
                Else
                    dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                End If

                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Product)
            End If
        End If

        Session("SessionStart") = dateStart
        Session("SessionEnd") = dateEnd

        Trace.Warn("--------- :: lbtnProduct_Click ::Session(SessionStart) --------------" & Session("SessionStart"))
        Trace.Warn("--------- :: lbtnProduct_Click ::   Session(SessionEnd) --------------" & Session("SessionEnd"))



    End Sub

    Private Sub lbtnTrackActivity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtnTrackActivity.Click
        Session("TrackProduct") = False

        Dim dateStart As String
        Dim dateEnd As String
        Dim dPreMonth As New Date
        Dim ds_domain As DataSet

        ds_domain = Me.GetCurrentSessions(Me.domain_name)

        If ddlHisrotyOption.SelectedIndex = 0 Then
            lblOption.Text = " Today Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.000"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Actity)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 1 Then
            lblOption.Text = " Yesterday"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.000"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Actity)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 2 Then
            lblOption.Text = " This Week"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim week As New TimeSpan(6, 23, 59, 59)
                Dim CurrentweekStart As String = Date.Today.Subtract(week).ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
                dateStart = CurrentweekStart
                dateEnd = CurrentmonthEnd
                ExecuteForActivity_History(CurrentweekStart, CurrentmonthEnd, HistroyType.Actity)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 3 Then
            lblOption.Text = " This  Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
                dateStart = CurrentmonthStart
                dateEnd = CurrentmonthEnd
                ExecuteForActivity_History(CurrentmonthStart, CurrentmonthEnd, HistroyType.Actity)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 4 Then
            lblOption.Text = " Last Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.000"
                dateStart = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
                Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
                Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
                dateEnd = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.000"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Actity)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 5 Then
            lblOption.Text = " Custom Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then

                If (BDPLiteFrom.SelectedValue) Is Nothing Then
                    dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                    Session("dateStart") = Date.Now.ToLongDateString
                    BDPLiteFrom.SelectedValue = Session("dateStart")
                Else
                    dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                End If

                If BDPLiteTo.SelectedValue Is Nothing Then
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.000"
                    Session("dateTo") = Date.Now.ToLongDateString
                    BDPLiteTo.SelectedValue = Session("dateTo")
                Else
                    dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.000"
                End If

                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Actity)
            End If
        End If
        Session("SessionStart") = dateStart
        Session("SessionEnd") = dateEnd

        Trace.Warn("--------- :: lbtnProduct_Click ::Session(SessionStart) --------------" & Session("SessionStart"))
        Trace.Warn("--------- :: lbtnProduct_Click ::   Session(SessionEnd) --------------" & Session("SessionEnd"))



    End Sub

    Private Sub lbtnTrackReferrer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbtnTrackReferrer.Click
        Trace.Warn("--------- :: lbtnTrackReferrer_Click :: --------------")
        Page.Trace.Write("In lbtnTrackReferrer_Click")
        Session("TrackProduct") = True
        Dim dPreMonth As New Date
        Dim ds_domain As DataSet

        ds_domain = Me.GetCurrentSessions(Me.domain_name)

        If ddlHisrotyOption.SelectedIndex = 0 Then
            lblOption.Text = " Today Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Referrer)

            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 1 Then
            lblOption.Text = "Yesterday Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dateStart = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Referrer)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 2 Then
            lblOption.Text = "This Week Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                Dim week As New TimeSpan(6, 23, 59, 59)
                dateStart = Date.Today.Subtract(week).ToLongDateString + " " + "00:00:00.000"
                dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Referrer)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 3 Then
            lblOption.Text = " This Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                dateStart = CurrentmonthStart
                dateEnd = CurrentmonthEnd
                ExecuteForActivity_History(CurrentmonthStart, CurrentmonthEnd, HistroyType.Referrer)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 4 Then
            lblOption.Text = " Last Month"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
                dPreMonth = Now.AddMonths(-1)
                Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
                Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
                Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
                Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
                dateStart = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
                Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
                Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
                dateEnd = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.999"
                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Referrer)
            End If
        ElseIf ddlHisrotyOption.SelectedIndex = 5 Then
            lblOption.Text = " Period Activity"
            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then

                If (BDPLiteFrom.SelectedValue) Is Nothing Then
                    dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                    Session("dateStart") = Date.Now.ToLongDateString
                    BDPLiteFrom.SelectedValue = Session("dateStart")
                Else
                    dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                End If

                If BDPLiteTo.SelectedValue Is Nothing Then
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                    Session("dateTo") = Date.Now.ToLongDateString
                    BDPLiteTo.SelectedValue = Session("dateTo")
                Else
                    dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                End If

                ExecuteForActivity_History(dateStart, dateEnd, HistroyType.Referrer)
            End If
        End If

        Session("SessionStart") = dateStart
        Session("SessionEnd") = dateEnd

        Trace.Warn("--------- :: lbtnTrackReferrer_Click ::Session(SessionStart) --------------" & Session("SessionStart"))
        Trace.Warn("--------- :: lbtnTrackReferrer_Click ::   Session(SessionEnd) --------------" & Session("SessionEnd"))



    End Sub

    Private Sub dgProductActivity_SortCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) Handles dgProductActivity.SortCommand

        'Dim _instanceWebTracker As New WebTracker

        '_instanceWebTracker.SortColumn(e.SortExpression)
    End Sub

    Private Function SortColumn(ByVal expresssion As String) As String


        Dim order As String = IIf(Session("SortOrder") Is Nothing, "DESC", Session("SortOrder"))

        Dim DataTable1 As DataTable
        If Session("TrackProduct") = True Then
            DataTable1 = Me.GetTotalHistory(Session("SessionStart"), Session("SessionEnd"), Session("Domain"))
        Else
            DataTable1 = Me.GetUserLog_HistoryActivity(Session("SessionStart"), Session("SessionEnd"), Session("Domain"))   '("2008-12-26 00:00:00.000", "2008-12-26 23:59:59.999", "www.business4less.co.uk")

        End If

        Dim view As DataView = DataTable1.DefaultView
        view.Sort = expresssion & " " & order
        dgProductActivity.DataSource = view

        dgProductActivity.DataBind()
        Session("SortOrder") = IIf(order = "DESC", "ASC", "DESC")
    End Function

    Private Sub SessionCount()

        Page.Trace.Write("In Session Count ")

        Dim dateStart As String
        Dim dateEnd As String
        Dim dPreMonth As New Date
        Dim ds_domain As DataSet
        Dim Count As Integer
        ds_domain = Me.GetCurrentSessions(Me.domain_name)


        If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then
            dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
            dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
            Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, dateStart, dateEnd, Me.domain_name).Tables(0).Rows(0).Item(0)
            Se_Today.Text = Count

            dateStart = Date.Now.AddDays(-1).ToLongDateString + " " + "00:00:00.000"
            dateEnd = Date.Now.AddDays(-1).ToLongDateString + " " + "23:59:59.999"
            Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, dateStart, dateEnd, Me.domain_name).Tables(0).Rows(0).Item(0)
            Se_LastDay.Text = Count



            Dim week As New TimeSpan(6, 23, 59, 59)
            Dim CurrentweekStart As String = Date.Today.Subtract(week).ToLongDateString + " " + "00:00:00.000"

            Dim CurrentWeekEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
            Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, CurrentweekStart, CurrentWeekEnd, Me.domain_name).Tables(0).Rows(0).Item(0)
            Se_CurrentWeek.Text = Count

            dPreMonth = Now.AddMonths(-1)
            Dim dFirstPreMonth As New Date(dPreMonth.Year, dPreMonth.Month, 1)
            Dim dFirstCurMonth As New Date(Now.Year, Now.Month, 1)
            Dim CurrentmonthStart As String = dFirstCurMonth.ToLongDateString + " " + "00:00:00.000"
            Dim CurrentmonthEnd As String = Date.Now.ToLongDateString + " " + "23:59:59.999"
            Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, CurrentmonthStart, CurrentmonthEnd, Me.domain_name).Tables(0).Rows(0).Item(0)
            Se_CurrentMonth.Text = Count

            dateStart = dFirstPreMonth.ToLongDateString + " " + "00:00:00.000"
            Dim daysinmonth As Integer = dPreMonth.Now.DaysInMonth(dPreMonth.Year, dPreMonth.Month)
            Dim PreviousmonthEnd As New Date(dPreMonth.Year, dPreMonth.Month, daysinmonth)
            dateEnd = PreviousmonthEnd.ToLongDateString + " " + "23:59:59.999"
            Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, dateStart, dateEnd, Me.domain_name).Tables(0).Rows(0).Item(0)
            Se_LastMonth.Text = Count


        End If


        If ddlHisrotyOption.SelectedIndex = 4 Then

            If Not ds_domain Is Nothing And ds_domain.Tables.Count = 1 Then

                If (BDPLiteFrom.SelectedValue) Is Nothing Then
                    dateStart = Date.Now.ToLongDateString + " " + "00:00:00.000"
                    Session("dateStart") = Date.Now.ToLongDateString
                    BDPLiteFrom.SelectedValue = Session("dateStart")
                Else
                    dateStart = BDPLiteFrom.SelectedDateFormatted.Replace("-", " ") + " " + "00:00:00.000"
                End If

                If BDPLiteTo.SelectedValue Is Nothing Then
                    dateEnd = Date.Now.ToLongDateString + " " + "23:59:59.999"
                    Session("dateTo") = Date.Now.ToLongDateString
                    BDPLiteTo.SelectedValue = Session("dateTo")
                Else
                    dateEnd = BDPLiteTo.SelectedDateFormatted.Replace("-", " ") + " " + "23:59:59.999"
                End If
                Count = BLLRules.WebTracker.ExecuteForSession_History(GetConnectionData, dateStart, dateEnd, Me.domain_name).Tables(0).Rows(0).Item(0)

                Se_Period.Text = Count

            End If
        Else
            Se_Period.Text = ""
        End If

        Page.Trace.Write("In Session Count End")

    End Sub

#Region "Online Current  Users"

    Private Sub DisplayTracker()
        Page.Trace.Write("In DisplayTracker")
        Try
            Dim urlParam As String = Me.Page.Request.Params("str")
            Dim temp() As String = urlParam.Split("_"c)
            If temp(0) = "Refresh" Then
                Page.Trace.Write("Refresh")
                TrackOnlineUser()
            End If
            If temp(0) = "UserDetail" Then
                Page.Trace.Write("UserDetail")
                TrackUserDetails(temp(1))
            End If
            If temp(0) = "UserLog" Then
                Page.Trace.Write("UserLog")
                TrackUserLog(temp(1), temp(0))
            End If
            If temp(0) = "Session" Then
                Page.Trace.Write("Session")
                TrackUserLog(temp(1), temp(0))
            End If

            If temp(0) = "Order" Then
                Page.Trace.Write("Order")
                LoadOrderSpecificSession(temp(1))
            End If
            If temp(0) = "CustomerID" Then
                Page.Trace.Write("CustomerID")
                LoadCustomerSpecificSession(temp(1))
               End If
            If temp(0) = "CustomerIDReferrer" Then
                Page.Trace.Write("CustomerIDReferrer")
                LoadCustomerSpecificSessionReferrer(temp(1).Split("~").GetValue(0), temp(1).Split("~").GetValue(1))

            End If
            If temp(0) = "CustomerActivityID" Then
                Page.Trace.Write("CustomerActivityID")
                LoadCustomerSpecificSessionActivity(temp(1))
            End If

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("In DisplayTracker End")
    End Sub

    Private Sub TrackOnlineUser()

        Page.Trace.Write("In TrackOnlineUser")
        Dim ds As DataSet
        Dim counter As Integer = 1

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            ds = Me.GetCurrentSessions(Me.domain_name)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows

                    Dim session_id As String
                    session_id = dr("sid").ToString()

                    Dim customer_uid As String
                    customer_uid = dr.Item("customer_uid").ToString()

                    Dim customer_type As String
                    customer_type = dr.Item("customerType") & ""

                    sw.WriteLine("<table border='0' cellspacing='0' cellpadding='0' width='100%' borderColor='#f5f5f5'>")
                    sw.WriteLine(" <tr height='22' onMouseOver='this.style.backgroundColor=" & Chr(34) & "#d3d3d3" & Chr(34) & "' onMouseOut='this.style.backgroundColor=" & Chr(34) & "#f5f5f5" & Chr(34) & "' bgColor='#f5f5f5' borderColor='#C0C0C0'>")
                    sw.WriteLine("  <td  align='right' width='20%'><img src='/images/infiniplan/msngrmen.jpg'/></td>")
                    If customer_type = "annonymus" Then
                        sw.WriteLine("  <td  width='80%' align='left' id=" & session_id & " onClick='getDetails(this.id)' onMouseOver='this.style.cursor=" & Chr(34) & "pointer" & Chr(34) & "' class='bottomlnk' >" & counter & " - " & "Annonymus" & "</td>")
                    ElseIf customer_type = "registered" Then
                        sw.WriteLine("  <td width='80%' align='left' id=" & session_id & " onClick='getDetails(this.id)' onMouseOver='this.style.cursor=" & Chr(34) & "pointer" & Chr(34) & "' class='bottomlnk' >" & counter & " - " & customer_uid & "</td>")

                    End If

                    sw.WriteLine(" </tr>")
                    sw.WriteLine("</table>")
                    counter += 1

                Next
            End If

            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("TrackOnlineUser End")
    End Sub

    Private Sub TrackUserDetails(ByVal _SessionID As String)

        Page.Trace.Write("In TrackUserDetails")
        Dim ds As DataSet

        Try

            Dim customer_uid As String
            Dim customer_type As String
            Dim userIP As String
            Dim userBrowser As String
            Dim jabber_id As String
            Dim operator_id As String

            Dim visit_datetime As String
            Dim _countryName As String

            Dim urlVisited As String
            Dim lastAction As String
            Dim lastVisitedURL As String

            Dim startTime As String

            Try

                ds = Me.GetUserDetail(_SessionID)
                If Not ds Is Nothing And ds.Tables.Count = 1 Then
                    If ds.Tables(0).Rows.Count = 1 Then
                        Dim dr As DataRow = ds.Tables(0).Rows(0)
                        userIP = dr("ip").ToString()
                        userBrowser = dr("browser") & ""
                        customer_uid = dr("customer_uid") & ""
                        customer_type = dr("customerType").ToString()
                        jabber_id = dr("JabberId") & ""
                        operator_id = dr("OperatorJabberID") & ""
                        lastAction = dr("lastAction") & ""
                        lastVisitedURL = dr("lastVisitedURL") & ""
                        startTime = dr("datetime") & ""
                        If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                    End If
                End If

                If lastVisitedURL = "/" Then
                    lastVisitedURL = "Default.aspx"
                End If

            Catch ex As Exception
                Me.Context.Trace.Warn("Exception : ", ex.Message & vbCrLf & ex.StackTrace)
            End Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<table width='100%' border='0' cellpadding='5' cellspacing='0' bordercolor='#D6E3F7' >")
            sw.WriteLine(" <tr >")
            sw.WriteLine("  <td bordercolor='#FFFFFF' width='650'>")
            sw.WriteLine("   <table border=0>")
            sw.WriteLine("    <tr><td class='text_style2'> <b>Web Site: </b></td><td class='text_style2' colspan=2>" & site_url & " </td></tr>")
            sw.WriteLine("    <tr><td class='text_style2'> <b>User ID: </b></td><td class='text_style2' colspan=2>" & customer_uid + " (" + customer_type & ") </td> ")
            sw.WriteLine("     <td align='right' class='text_style2'> <b>Started Time: </b></td><td class='text_style2'  >" & startTime & " </td></tr>")
            sw.WriteLine("    <tr><td class='text_style2'> <b>User IP: </b></td><td class='text_style2' colspan=2 >" & userIP & " </td></tr>")
            sw.WriteLine("  <tr><td class='text_style2'> &nbsp;&nbsp;<b>Country: </b></td><td class='text_style2' colspan=2 >")

            sw.WriteLine(_countryName)

            sw.WriteLine(" </td></tr>")

            sw.WriteLine("   </table>")
            sw.WriteLine("  </td>")
            sw.WriteLine(" </tr>")
            sw.WriteLine(" <tr height='20'>")
            sw.WriteLine(" <td> ")
            sw.WriteLine("  <a HREF='javascript:getDetails_Product(" & _SessionID & ")' class='bottomlnk' id=" & _SessionID & "> <img src='/images/infiniplan/TrackProduct.png'  border=0 />  </a> &nbsp;")
            sw.WriteLine("   <a HREF='javascript:getDetails_Activity(" & _SessionID & ")' class='bottomlnk' id=" & _SessionID & "> <img src='/images/infiniplan/TrackActivity.png'  border=0 /> </a>")

            sw.WriteLine("  </td>")


            sw.WriteLine(" </tr>")

            sw.WriteLine("</table>")

            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("TrackUserDetails End")
    End Sub

    Private Sub TrackUserLog(ByVal _SessionIDStr As String, ByVal Type As String)

        If Type = "UserLog" Then

            ExecuteForProduct(_SessionIDStr)
        ElseIf Type = "Session" Then

            ExecuteForActivity(_SessionIDStr)
        End If

    End Sub

    Private Function ExecuteForProduct(ByVal _SessionID As String) As String
        Page.Trace.Write("In ExecuteForProduct")

        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForUserHistory()

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            ds = Me.GetUserLog(_SessionID)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    If dr("referrer") <> "" And dr("ProductId") <> "0" Then
                        temp_dr = dt.NewRow()
                        Dim sno As String = counter
                        temp_dr("Sr") = sno
                        Dim startedTime As String = dr("TimeStamp") & ""
                        temp_dr("StartedTime") = startedTime
                        Dim fromURL As String = dr("referrer") & ""
                        If fromURL = "/" Then
                            fromURL = "Default.aspx"
                        End If
                        temp_dr("FromURL") = fromURL
                        Dim productID As String = dr("ProductId").ToString().Trim() & ""
                        Dim productName As String = dr("ProductName").ToString().Trim() & ""
                        If productID = "0" Then
                            temp_dr("Product") = "&nbsp;"
                        Else
                            temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                        End If
                        counter += 1
                        dt.Rows.Add(temp_dr)
                    End If
                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForUserHistory()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForProduct End")
    End Function

    Private Function ExecuteForActivity(ByVal _SessionID As String) As String
        Page.Trace.Write("In ExecuteForActivity")

        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForUserHistory()

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            ds = Me.GetUserLog(_SessionID)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno
                    Dim startedTime As String = dr("TimeStamp") & ""
                    temp_dr("StartedTime") = startedTime
                    Dim fromURL As String = dr("referrer") & ""
                    If fromURL = "/" Then
                        fromURL = "Default.aspx"
                    End If
                    temp_dr("FromURL") = fromURL
                    Dim productID As String = dr("ProductId").ToString().Trim() & ""
                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If productID = "0" Then
                        temp_dr("Product") = "&nbsp;"
                    Else
                        temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForUserHistory()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()

        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForActivity End")
    End Function

    Private Function BuildDataTableForUserHistory() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))

            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("Product", Type.GetType("System.String"))
            dt.Columns.Add("FromURL", Type.GetType("System.String"))
            dt.Columns.Add("referrer", Type.GetType("System.String"))
            dt.Columns.Add("StartedTime", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))


            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function BuildDataGridForUserHistory() As System.Web.UI.WebControls.DataGrid

        Dim dg As System.Web.UI.WebControls.DataGrid

        Try

            dg = New System.Web.UI.WebControls.DataGrid

            Dim col1 As System.Web.UI.WebControls.BoundColumn
            col1 = New System.Web.UI.WebControls.BoundColumn
            col1.HeaderStyle.CssClass = "text_style3"
            col1.HeaderText = "Sr.#"
            col1.DataField = "Sr"
            col1.ItemStyle.Wrap = True
            col1.ItemStyle.CssClass = "text_style2"
            col1.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)

            Dim col2 As System.Web.UI.WebControls.BoundColumn
            col2 = New System.Web.UI.WebControls.BoundColumn
            col2.HeaderStyle.CssClass = "text_style3"
            col2.HeaderText = "FromURL"
            col2.DataField = "FromURL"
            col2.ItemStyle.Wrap = True
            col2.ItemStyle.CssClass = "text_style2"
            col2.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)

            Dim col4 As System.Web.UI.WebControls.BoundColumn
            col4 = New System.Web.UI.WebControls.BoundColumn
            col4.HeaderStyle.CssClass = "text_style3"
            col4.HeaderText = "StartedTime"
            col4.DataField = "StartedTime"
            col4.ItemStyle.Wrap = True
            col4.ItemStyle.CssClass = "text_style2"
            col4.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)

            Dim col5 As System.Web.UI.WebControls.BoundColumn
            col5 = New System.Web.UI.WebControls.BoundColumn
            col5.HeaderStyle.CssClass = "text_style3"
            col5.HeaderText = "Product"
            col5.DataField = "Product"
            col5.ItemStyle.Wrap = True
            col5.ItemStyle.CssClass = "text_style2"
            col5.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)

            dg.Columns.Add(col1)
            dg.Columns.Add(col5)
            dg.Columns.Add(col2)
            dg.Columns.Add(col4)


            dg.AutoGenerateColumns = False
            dg.CssClass = "GridWidth"
            dg.GridLines = GridLines.Both
            dg.ShowHeader = True
            dg.ShowFooter = False

            Return dg

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetCurrentSessions(ByVal _DomainName As String) As DataSet

        Dim ds As DataSet
        Try
            ds = BLLRules.WebTracker.GetCurrentSessions(GetConnectionData, _DomainName)
            Return ds
        Catch ex As Exception

            Page.Trace.Warn("Exception :" & ex.Message)

        Finally
        End Try
    End Function

    Private Function GetProductName(ByVal Productid As Integer) As String

        Dim ds As DataSet
        Try
            ds = BLLRules.WebTracker.GetProductName(GetConnectionData, Productid)
            Return ds.Tables(0).Rows(0).Item(2)
        Catch ex As Exception
            Page.Trace.Warn("Exception :" & ex.Message)

            Throw ex
        Finally

        End Try
    End Function

    Private Function GetUserDetail(ByVal _SessionID As Integer) As DataSet

        Dim ds As DataSet
        Try
            ds = BLLRules.WebTracker.GetUserDetail(GetConnectionData, _SessionID)
            Return ds
        Catch ex As Exception
            Page.Trace.Warn("Exception :" & ex.Message)
            Throw ex
        Finally
        End Try
    End Function

    Private Function GetUserLog(ByVal _SessionID As Integer) As DataSet

        Dim ds As DataSet
        Try
            ds = BLLRules.WebTracker.GetUserLog(GetConnectionData, _SessionID)
            Return ds
        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
    End Function

#End Region


    Private Function ExecuteForActivity_History(ByVal StartDate As String, ByVal EndDate As String, ByVal HistoryType As Integer) As String
        Trace.Warn("--------- :: ExecuteForActivity_History :: --------------")

        If HistoryType = HistroyType.Product Then
            ExecuteForProduct_History(StartDate, EndDate)
        ElseIf HistoryType = HistroyType.Actity Then
            ExecuteForActivity_History(StartDate, EndDate)
        ElseIf HistoryType = HistroyType.Referrer Then
            ExecuteForProduct_Referrer(StartDate, EndDate)
        End If


    End Function

    ' History Activity 
    Private Function ExecuteForActivity_History(ByVal StartDate As String, ByVal EndDate As String) As String
        Trace.Warn("--------- :: ExecuteForActivity_History :: --------------")

        Page.Trace.Write("In ExecuteForActivity_History")
        Try
            dgActivity.AllowSorting = True
            dgActivity.DataSource = BLLRules.WebTracker.GetUserLog_HistoryActivity_Country(GetConnectionData, StartDate, EndDate, Me.domain_name)

            dgActivity.DataBind()
            dgActivity.Visible = True
            dgProductActivity.Visible = False
            dgProductReferrer.Visible = False
        Catch ex As Exception
            Trace.Warn("--------- :: ExecuteForActivity_History :: --------------")

            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForActivity_History End")
        Trace.Warn("--------- :: ExecuteForActivity_History :: --------------")

    End Function
    Private Function GetUserLog_HistoryActivity(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataTable
        Dim dt As DataTable = Me.BuildDT()
        Dim ds As DataSet
        Dim counter As Integer = 1
        Try
            ds = BLLRules.WebTracker.GetUserLog_HistoryActivity(GetConnectionData, StartDate, EndDate, DomainName)

            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno



                    Dim ip As String = dr("ip") & ""
                    temp_dr("IP") = ip

                    Dim _countryName As String
                    If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                    temp_dr("Country") = _countryName


                    Dim cusomterid As String = dr("customer_uid") & ""

                    Dim _customerID As New StringBuilder
                    _customerID.Append(" <a HREF=javascript:getDetails_CustomerActivity('" & cusomterid & "') class='bottomlnk' id=" & cusomterid & ">" & cusomterid & "   </a> &nbsp;")
                    temp_dr("CustomerID") = _customerID.ToString

                    counter += 1
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
    End Function
    Private Function BuildDT() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    ' History Referrer 
    Private Function ExecuteForProduct_Referrer(ByVal StartDate As String, ByVal EndDate As String) As String
        Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

        Page.Trace.Write("In ExecuteForProduct_History")
        Try

            dgProductReferrer.DataSource = BLLRules.WebTracker.GetTotalHistory_CountryReferrer(GetConnectionData, StartDate, EndDate, Me.domain_name) ' Me.GetTotalHistory(StartDate, EndDate, Me.domain_name)
            dgProductReferrer.DataBind()
            dgProductReferrer.Visible = True
            dgProductActivity.Visible = False
            dgActivity.Visible = False

        Catch ex As Exception
            Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForProduct_History End")
        Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

    End Function
    'Private Function GetTotalHistoryReferrer(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataTable
    '    Dim dt As DataTable = Me.BuildDataTableForSessionHistory()
    '    Dim dsProduct As DataSet
    '    Dim counter As Integer = 1
    '    Try
    '        dsProduct = BLLRules.WebTracker.GetTotalHistory(GetConnectionData, StartDate, EndDate, DomainName)

    '        If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

    '            Dim dr As DataRow
    '            For Each dr In dsProduct.Tables(0).Rows
    '                Dim oldString As String, newString As String
    '                Dim startStr As Integer, endStr As Integer, indexDiff As Integer
    '                ' Start Condition 
    '                Dim temp_dr As DataRow
    '                Dim Product As String
    '                temp_dr = dt.NewRow()

    '                Dim sno As String = counter
    '                temp_dr("Sr") = sno

    '                Dim UniQueSession As String = dr("UniQueSession") & ""
    '                temp_dr("UniQueSession") = UniQueSession

    '                'Dim TotalSessions As String = dr("TotalSessions") & ""
    '                'Dim Sessions As New StringBuilder
    '                'Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
    '                'Sessions.Append(" <tr>")
    '                'Sessions.Append(" <td align='center'>")
    '                'Sessions.Append(" <a HREF=javascript:getDetails_Customer('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalSessions & "   </a> &nbsp;")
    '                'Sessions.Append(" </td>")
    '                'Sessions.Append(" </tr>")
    '                'Sessions.Append("</table>")
    '                'temp_dr("TotalSessions") = TotalSessions

    '                Dim ProductVisited As String = dr("ProductVisited") & ""
    '                Dim Sessions As New StringBuilder
    '                Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
    '                Sessions.Append(" <tr>")
    '                Sessions.Append(" <td align='center'>")
    '                Sessions.Append(" <a HREF=javascript:getDetails_Customer('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & ProductVisited & "   </a> &nbsp;")
    '                Sessions.Append(" </td>")
    '                Sessions.Append(" </tr>")
    '                Sessions.Append("</table>")

    '                temp_dr("ProductVisited") = Sessions.ToString

    '                Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, UniQueSession)
    '                Dim TotalOrders As String = _orderCount

    '                Dim Order As New StringBuilder

    '                If TotalOrders = "0" Then

    '                    Order.Append("<table border='0' cellspacing='0' cellpadding='0'  >")
    '                    Order.Append(" <tr>")
    '                    Order.Append(" <td align='center' class='bottomlnk'>")
    '                    Order.Append("0 ")
    '                    Order.Append(" </td>")
    '                    Order.Append(" </tr>")
    '                    Order.Append("</table>")

    '                    temp_dr("TotalOrders") = Order.ToString
    '                Else



    '                    Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
    '                    Order.Append(" <tr>")
    '                    Order.Append(" <td align='center'>")
    '                    Order.Append(" <a HREF=javascript:LoadDiv('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalOrders & "   </a> &nbsp;")
    '                    Order.Append(" </td>")
    '                    Order.Append(" </tr>")
    '                    Order.Append("</table>")

    '                    temp_dr("TotalOrders") = Order.ToString
    '                End If

    '                Dim _ip As String = dr("IP") & ""
    '                temp_dr("IP") = _ip

    '                Dim _countryName As String
    '                If dr("Country") = "" Then _countryName = "N/A" & "" Else _countryName = dr("Country") & ""
    '                temp_dr("Country") = _countryName




    '                counter += 1S
    '                dt.Rows.Add(temp_dr)

    '                ' Start Condition 
    '            Next
    '        End If
    '        dt.AcceptChanges()
    '        Return dt
    '    Catch ex As Exception
    '        Page.Trace.Warn("EXception : " & ex.Message)
    '        Throw ex
    '    Finally
    '    End Try
    'End Function
    'Private Function BuildDataTableForSessionReferrer() As System.Data.DataTable

    '    Dim dt As DataTable
    '    Try
    '        dt = New DataTable
    '        dt.Columns.Add("Sr", Type.GetType("System.String"))
    '        dt.Columns.Add("UniQueSession", Type.GetType("System.String"))
    '        ' dt.Columns.Add("TotalSessions", Type.GetType("System.String"))
    '        dt.Columns.Add("ProductVisited", Type.GetType("System.String"))
    '        dt.Columns.Add("TotalOrders", Type.GetType("System.String"))
    '        dt.Columns.Add("IP", Type.GetType("System.String"))
    '        dt.Columns.Add("Country", Type.GetType("System.String"))
    '        Return dt
    '    Catch ex As Exception
    '        Throw ex
    '    End Try

    'End Function

    ' History Product 

    Private Function ExecuteForProduct_History(ByVal StartDate As String, ByVal EndDate As String) As String
        Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

        Page.Trace.Write("In ExecuteForProduct_History")
        Try
            dgProductActivity.AllowSorting = True
            dgProductActivity.DataSource = BLLRules.WebTracker.GetTotalHistory_Country(GetConnectionData, StartDate, EndDate, Me.domain_name) ' Me.GetTotalHistory(StartDate, EndDate, Me.domain_name)
            dgProductActivity.DataBind()
            dgProductActivity.Visible = True
            dgActivity.Visible = False
            dgProductReferrer.Visible = False
        Catch ex As Exception
            Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("ExecuteForProduct_History End")
        Trace.Warn("--------- :: ExecuteForProduct_History :: --------------")

    End Function
    Private Function GetTotalHistory(ByVal StartDate As String, ByVal EndDate As String, ByVal DomainName As String) As DataTable
        Dim dt As DataTable = Me.BuildDataTableForSessionHistory()
        Dim dsProduct As DataSet
        Dim counter As Integer = 1
        Try
            dsProduct = BLLRules.WebTracker.GetTotalHistory(GetConnectionData, StartDate, EndDate, DomainName)

            If Not dsProduct Is Nothing And dsProduct.Tables.Count = 1 Then

                Dim dr As DataRow
                For Each dr In dsProduct.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    ' Start Condition 
                    Dim temp_dr As DataRow
                    Dim Product As String
                    temp_dr = dt.NewRow()

                    Dim sno As String = counter
                    temp_dr("Sr") = sno

                    Dim UniQueSession As String = dr("UniQueSession") & ""
                    temp_dr("UniQueSession") = UniQueSession

                    'Dim TotalSessions As String = dr("TotalSessions") & ""
                    'Dim Sessions As New StringBuilder
                    'Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
                    'Sessions.Append(" <tr>")
                    'Sessions.Append(" <td align='center'>")
                    'Sessions.Append(" <a HREF=javascript:getDetails_Customer('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalSessions & "   </a> &nbsp;")
                    'Sessions.Append(" </td>")
                    'Sessions.Append(" </tr>")
                    'Sessions.Append("</table>")
                    'temp_dr("TotalSessions") = TotalSessions

                    Dim ProductVisited As String = dr("ProductVisited") & ""
                    Dim Sessions As New StringBuilder
                    Sessions.Append("<table border='0' cellspacing='0' cellpadding='0'   borderColor='#f5f5f5'>")
                    Sessions.Append(" <tr>")
                    Sessions.Append(" <td align='center'>")
                    Sessions.Append(" <a HREF=javascript:getDetails_Customer('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & ProductVisited & "   </a> &nbsp;")
                    Sessions.Append(" </td>")
                    Sessions.Append(" </tr>")
                    Sessions.Append("</table>")

                    temp_dr("ProductVisited") = Sessions.ToString

                    Dim _orderCount As Integer = Me.GetOrderCount(StartDate, EndDate, UniQueSession)
                    Dim TotalOrders As String = _orderCount

                    Dim Order As New StringBuilder

                    If TotalOrders = "0" Then

                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'  >")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center' class='bottomlnk'>")
                        Order.Append("0 ")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    Else



                        Order.Append("<table border='0' cellspacing='0' cellpadding='0'>")
                        Order.Append(" <tr>")
                        Order.Append(" <td align='center'>")
                        Order.Append(" <a HREF=javascript:LoadDiv('" & UniQueSession & "') class='bottomlnk' id=" & UniQueSession & ">" & TotalOrders & "   </a> &nbsp;")
                        Order.Append(" </td>")
                        Order.Append(" </tr>")
                        Order.Append("</table>")

                        temp_dr("TotalOrders") = Order.ToString
                    End If

                    Dim _ip As String = dr("IP") & ""
                    temp_dr("IP") = _ip

                    Dim _countryName As String
                    If dr("Country") = "" Then _countryName = "N/A" & "" Else _countryName = dr("Country") & ""
                    temp_dr("Country") = _countryName




                    counter += 1S
                    dt.Rows.Add(temp_dr)

                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Return dt
        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
    End Function
    Private Function BuildDataTableForSessionHistory() As System.Data.DataTable

        Dim dt As DataTable
        Try
            dt = New DataTable
            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("UniQueSession", Type.GetType("System.String"))
            ' dt.Columns.Add("TotalSessions", Type.GetType("System.String"))
            dt.Columns.Add("ProductVisited", Type.GetType("System.String"))
            dt.Columns.Add("TotalOrders", Type.GetType("System.String"))
            dt.Columns.Add("IP", Type.GetType("System.String"))
            dt.Columns.Add("Country", Type.GetType("System.String"))
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function


    ' Order Detail 
    Private Function LoadOrderSpecificSession(ByVal _CustID As String) As String

        Page.Trace.Write("In LoadCustomerSpecificSessionActivity")
        Dim _dsOrder As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForOrderHistory()

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' 	content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            _dsOrder = BLLRules.WebTracker.GetCustomerOrderDetail(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), _CustID)
            If Not _dsOrder Is Nothing And _dsOrder.Tables.Count = 1 Then
                Me.GetProductDetail(_dsOrder.Tables(0))
                Dim dr As DataRow
                For Each dr In _dsOrder.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno


                    Dim Customer As String = dr("Customer") & ""
                    temp_dr("Customer") = Customer

                    Dim CustomerID As String = dr("CustomerID") & ""
                    temp_dr("CustomerID") = CustomerID

                    Dim OrderId As String = dr("OrderId") & ""
                    temp_dr("OrderId") = OrderId

                    Dim OrderDate As String = dr("OrderDate") & ""
                    temp_dr("OrderDate") = OrderDate

                    Dim ProductId As String = dr("ProductId").ToString().Trim() & ""

                    Dim ProductCode As String = dr("ProductCode") & ""
                    temp_dr("ProductCode") = ProductCode



                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If ProductId = "0" Then
                        temp_dr("ProductName") = "&nbsp;"
                    Else
                        temp_dr("ProductName") = "<a href='" & site_url & "/?ProURL_ID=" & ProductId & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForOrder_History()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()
        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSessionActivity End")

    End Function
    Private Function BuildDataTableForOrderHistory() As System.Data.DataTable

        Dim dt As DataTable

        Try

            dt = New DataTable

            dt.Columns.Add("Sr", Type.GetType("System.String"))
            dt.Columns.Add("Customer", Type.GetType("System.String"))
            dt.Columns.Add("CustomerID", Type.GetType("System.String"))
            dt.Columns.Add("OrderId", Type.GetType("System.String"))
            dt.Columns.Add("OrderDate", Type.GetType("System.String"))
            dt.Columns.Add("ProductId", Type.GetType("System.String"))
            dt.Columns.Add("ProductCode", Type.GetType("System.String"))
            dt.Columns.Add("ProductName", Type.GetType("System.String"))

            Return dt

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function BuildDataGridForOrder_History() As System.Web.UI.WebControls.DataGrid

        Dim dg As System.Web.UI.WebControls.DataGrid

        Try

            dg = New System.Web.UI.WebControls.DataGrid

            Dim col1 As System.Web.UI.WebControls.BoundColumn
            col1 = New System.Web.UI.WebControls.BoundColumn
            col1.HeaderStyle.CssClass = "text_style3"
            col1.HeaderText = "Sr.#"
            col1.DataField = "Sr"
            col1.ItemStyle.Wrap = True
            col1.ItemStyle.CssClass = "text_style2"
            col1.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)

            Dim col2 As System.Web.UI.WebControls.BoundColumn
            col2 = New System.Web.UI.WebControls.BoundColumn
            col2.HeaderStyle.CssClass = "text_style3"
            col2.HeaderText = "Customer"
            col2.DataField = "Customer"
            col2.ItemStyle.Wrap = True
            col2.ItemStyle.CssClass = "text_style2"
            col2.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)


            Dim col3 As System.Web.UI.WebControls.BoundColumn
            col3 = New System.Web.UI.WebControls.BoundColumn
            col3.HeaderStyle.CssClass = "text_style3"
            col3.HeaderText = "Customer ID"
            col3.DataField = "CustomerID"
            col3.ItemStyle.Wrap = True
            col3.ItemStyle.CssClass = "text_style2"
            col3.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)



            Dim col4 As System.Web.UI.WebControls.BoundColumn
            col4 = New System.Web.UI.WebControls.BoundColumn
            col4.HeaderStyle.CssClass = "text_style3"
            col4.HeaderText = "Order Id"
            col4.DataField = "OrderId"
            col4.ItemStyle.Wrap = True
            col4.ItemStyle.CssClass = "text_style2"
            col4.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)

            Dim col5 As System.Web.UI.WebControls.BoundColumn
            col5 = New System.Web.UI.WebControls.BoundColumn
            col5.HeaderStyle.CssClass = "text_style3"
            col5.HeaderText = "Order No"
            col5.DataField = "OrderNo"
            col5.ItemStyle.Wrap = True
            col5.ItemStyle.CssClass = "text_style2"
            col5.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)

            Dim col6 As System.Web.UI.WebControls.BoundColumn
            col6 = New System.Web.UI.WebControls.BoundColumn
            col6.HeaderStyle.CssClass = "text_style3"
            col6.HeaderText = "Order Date"
            col6.DataField = "OrderDate"
            col6.ItemStyle.Wrap = True
            col6.ItemStyle.CssClass = "text_style2"
            col6.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)

            Dim col7 As System.Web.UI.WebControls.BoundColumn
            col7 = New System.Web.UI.WebControls.BoundColumn
            col7.HeaderStyle.CssClass = "text_style3"
            col7.HeaderText = "Product Id"
            col7.DataField = "ProductId"
            col7.ItemStyle.Wrap = True
            col7.ItemStyle.CssClass = "text_style2"
            col7.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)


            Dim col8 As System.Web.UI.WebControls.BoundColumn
            col8 = New System.Web.UI.WebControls.BoundColumn
            col8.HeaderStyle.CssClass = "text_style3"
            col8.HeaderText = "Product Code"
            col8.DataField = "ProductCode"
            col8.ItemStyle.Wrap = True
            col8.ItemStyle.CssClass = "text_style2"
            col8.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)


            Dim col9 As System.Web.UI.WebControls.BoundColumn
            col9 = New System.Web.UI.WebControls.BoundColumn
            col9.HeaderStyle.CssClass = "text_style3"
            col9.HeaderText = "Product Name"
            col9.DataField = "ProductName"
            col9.ItemStyle.Wrap = True
            col9.ItemStyle.CssClass = "text_style2"
            col9.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)


            dg.Columns.Add(col1)
            dg.Columns.Add(col2)
            dg.Columns.Add(col3)
            dg.Columns.Add(col4)
            dg.Columns.Add(col6)
            dg.Columns.Add(col8)
            dg.Columns.Add(col9)

            dg.AutoGenerateColumns = False
            dg.CssClass = "GridWidth"
            dg.GridLines = GridLines.Both
            dg.ShowHeader = True
            dg.ShowFooter = False

            Return dg

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Customer Detail ( Product based)
    Private Function LoadCustomerSpecificSession(ByVal _CustID As String) As String
        Page.Trace.Write("In LoadCustomerSpecificSession")
        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForUserHistory()

        Try
            Dim a As String

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' 	content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            ds = BLLRules.WebTracker.GetCustomerHistoryDetail(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, _CustID)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer
                    If dr("ProductId") <> "0" Then  'dr("referrer") <> "" And 
                        ' Start Condition 
                        Dim temp_dr As DataRow
                        Dim Product As String

                        temp_dr = dt.NewRow()
                        Dim sno As String = counter
                        temp_dr("Sr") = sno

                        Dim startedTime As String = dr("TimeStamp") & ""
                        temp_dr("StartedTime") = startedTime

                        Dim fromURL As String = dr("referrer") & ""
                        If fromURL = "/" Then
                            fromURL = "Default.aspx"
                        End If
                        temp_dr("FromURL") = fromURL

                        Dim ip As String = dr("ip") & ""
                        temp_dr("IP") = ip

                        Dim _countryName As String
                        If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                        temp_dr("Country") = _countryName
                        '
                        Dim cusomterid As String = dr("customer_uid") & ""
                        temp_dr("CustomerID") = cusomterid

                        Dim referrer As String = dr("referrer") & ""
                        temp_dr("referrer") = referrer

                        Dim productID As String = dr("ProductId").ToString().Trim() & ""
                        Dim productName As String = dr("ProductName").ToString().Trim() & ""
                        If productID = "0" Then
                            temp_dr("Product") = "&nbsp;"
                        Else
                            temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                        End If
                        counter += 1
                        dt.Rows.Add(temp_dr)
                    End If
                    ' Start Condition 
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForUser_History()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()
         
        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try

        Page.Trace.Write("LoadCustomerSpecificSession End")

    End Function
    Private Function BuildDataGridForUser_History() As System.Web.UI.WebControls.DataGrid

        Dim dg As System.Web.UI.WebControls.DataGrid

        Try

            dg = New System.Web.UI.WebControls.DataGrid

            Dim col1 As System.Web.UI.WebControls.BoundColumn
            col1 = New System.Web.UI.WebControls.BoundColumn
            col1.HeaderStyle.CssClass = "text_style3"
            col1.HeaderText = "Sr.#"
            col1.DataField = "Sr"
            col1.ItemStyle.Wrap = True
            col1.ItemStyle.CssClass = "text_style2"
            col1.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)

            Dim col2 As System.Web.UI.WebControls.BoundColumn
            col2 = New System.Web.UI.WebControls.BoundColumn
            col2.HeaderStyle.CssClass = "text_style3"
            col2.HeaderText = "Customer ID"
            col2.DataField = "CustomerID"
            col2.ItemStyle.Wrap = True
            col2.ItemStyle.CssClass = "text_style2"
            col2.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(99)


            Dim col3 As System.Web.UI.WebControls.BoundColumn
            col3 = New System.Web.UI.WebControls.BoundColumn
            col3.HeaderStyle.CssClass = "text_style3"
            col3.HeaderText = "FromURL"
            col3.DataField = "FromURL"
            col3.ItemStyle.Wrap = True
            col3.ItemStyle.CssClass = "text_style2"
            col3.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)

            Dim col31 As System.Web.UI.WebControls.BoundColumn
            col31 = New System.Web.UI.WebControls.BoundColumn
            col31.HeaderStyle.CssClass = "text_style3"
            col31.HeaderText = "referrer"
            col31.DataField = "referrer"
            col31.ItemStyle.Wrap = True
            col31.ItemStyle.CssClass = "text_style2"
            col31.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(136)




            Dim col4 As System.Web.UI.WebControls.BoundColumn
            col4 = New System.Web.UI.WebControls.BoundColumn
            col4.HeaderStyle.CssClass = "text_style3"
            col4.HeaderText = "StartedTime"
            col4.DataField = "StartedTime"
            col4.ItemStyle.Wrap = True
            col4.ItemStyle.CssClass = "text_style2"
            col4.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)

            Dim col5 As System.Web.UI.WebControls.BoundColumn
            col5 = New System.Web.UI.WebControls.BoundColumn
            col5.HeaderStyle.CssClass = "text_style3"
            col5.HeaderText = "Product"
            col5.DataField = "Product"
            col5.ItemStyle.Wrap = True
            col5.ItemStyle.CssClass = "text_style2"
            col5.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)

            Dim col6 As System.Web.UI.WebControls.BoundColumn
            col6 = New System.Web.UI.WebControls.BoundColumn
            col6.HeaderStyle.CssClass = "text_style3"
            col6.HeaderText = "IP"
            col6.DataField = "IP"
            col6.ItemStyle.Wrap = True
            col6.ItemStyle.CssClass = "text_style2"
            col6.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(99)

            Dim col7 As System.Web.UI.WebControls.BoundColumn
            col7 = New System.Web.UI.WebControls.BoundColumn
            col7.HeaderStyle.CssClass = "text_style3"
            col7.HeaderText = "Country"
            col7.DataField = "Country"
            col7.ItemStyle.Wrap = True
            col7.ItemStyle.CssClass = "text_style2"
            col7.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(99)


            dg.Columns.Add(col1)
            dg.Columns.Add(col2)
            dg.Columns.Add(col5)
            dg.Columns.Add(col3)
            dg.Columns.Add(col31)
            dg.Columns.Add(col4)
            dg.Columns.Add(col6)
            dg.Columns.Add(col7)


            dg.AutoGenerateColumns = False
            dg.CssClass = "GridWidth"
            dg.GridLines = GridLines.Both
            dg.ShowHeader = True
            dg.ShowFooter = False

            Return dg

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    'Customer Activity (All urls)
    Private Function LoadCustomerSpecificSessionActivity(ByVal _CustID As String) As String
        Page.Trace.Write("In LoadCustomerSpecificSessionActivity")

        Dim ds As DataSet

        Dim counter As Integer = 1
        Dim chkBool As Boolean
        Dim dt As DataTable = Me.BuildDataTableForUserHistory()

        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)

            sw.WriteLine("<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.0 Transitional//EN'>")
            sw.WriteLine("<html>")
            sw.WriteLine("<head>")
            sw.WriteLine("<title></title>")
            sw.WriteLine("<meta name='GENERATOR' content='Microsoft Visual Studio .NET 7.1'>")
            sw.WriteLine("<meta name='vs_targetSchema' 	content='http://schemas.microsoft.com/intellisense/ie5'>")
            sw.WriteLine("</head>")
            sw.WriteLine("<body>")

            Dim parseComp As String
            ds = BLLRules.WebTracker.GetCustomerHistoryDetail(GetConnectionData, Session("SessionStart"), Session("SessionEnd"), Me.domain_name, _CustID)
            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Me.GetProductDetail(ds.Tables(0))
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim oldString As String, newString As String
                    Dim startStr As Integer, endStr As Integer, indexDiff As Integer

                    Dim temp_dr As DataRow
                    Dim Product As String

                    temp_dr = dt.NewRow()
                    Dim sno As String = counter
                    temp_dr("Sr") = sno

                    Dim startedTime As String = dr("TimeStamp") & ""
                    temp_dr("StartedTime") = startedTime

                    Dim fromURL As String = dr("referrer") & ""
                    If fromURL = "/" Then
                        fromURL = "Default.aspx"
                    End If
                    temp_dr("FromURL") = fromURL

                    Dim ip As String = dr("ip") & ""
                    temp_dr("IP") = ip

                    Dim _countryName As String
                    If dr("CountryName") = "" Then _countryName = "N/A" & "" Else _countryName = dr("CountryName") & ""
                    temp_dr("Country") = _countryName

                    Dim cusomterid As String = dr("customer_uid") & ""
                    temp_dr("CustomerID") = cusomterid

                    Dim productID As String = dr("ProductId").ToString().Trim() & ""
                    Dim productName As String = dr("ProductName").ToString().Trim() & ""
                    If productID = "0" Then
                        temp_dr("Product") = "&nbsp;"
                    Else
                        temp_dr("Product") = "<a href='" & site_url & "/?ProURL_ID=" & productID & "' target='_blank'>" & productName & "</a>"
                    End If
                    counter += 1
                    dt.Rows.Add(temp_dr)
                Next
            End If
            dt.AcceptChanges()
            Dim dg As System.Web.UI.WebControls.DataGrid
            dg = Me.BuildDataGridForUser_History()
            dg.DataSource = dt
            dg.DataBind()
            ContentToWrite = Me.GetDataGridMarkupForUserHistory(dg)
            sw.Write(ContentToWrite)
            sw.WriteLine("</body>")
            sw.WriteLine("</html>")
            ContentToWrite = sb.ToString()
            Page.Trace.Write("ContentToWrite :" & ContentToWrite)
            Me.Page.Response.Clear()
            Me.Page.Response.Write(ContentToWrite)
            Me.Page.Response.End()
        Catch ex As Exception
            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)
        End Try
        Page.Trace.Write("LoadCustomerSpecificSessionActivity End")
    End Function

    'Order Count and Detail
    Public Function GetOrderCount(ByVal StartDate As String, ByVal EndDate As String, ByVal Customerid As String) As Integer
        Page.Trace.Write("In GetOrderCount")

        Try

            Dim OrderCount As Int32
            OrderCount = BLLRules.WebTracker.GetOrderCount(GetConnectionData, StartDate, EndDate, Customerid)
            Page.Trace.Write("OrderCount :" & OrderCount)
            Return OrderCount
        Catch ex As Exception
            Page.Trace.Warn("Exception  :" & ex.Message)
        End Try
        Page.Trace.Write("GetOrderCount End")
    End Function
    Private Function GetOrdersIDAsXML(ByRef drs As DataTable) As String
        Page.Trace.Write("In GetOrdersIDAsXML")
        Try

            _xmlElement1 = _xmldoc.CreateElement("Root")
            _xmldoc.AppendChild(_xmlElement1)
            Dim dr As DataRow
            For Each dr In drs.Rows
                _xmldoc.DocumentElement.AppendChild(element(dr("UniQueSession").ToString().Trim()))
            Next

            Return _xmldoc.OuterXml.Trim

        Catch ex As Exception
            Page.Trace.Warn("Exception :" & ex.Message)
        End Try
        Page.Trace.Write("GetOrdersIDAsXML End")
    End Function
    Private Function GetOrderIDAsXML(ByRef drs As DataTable, ByVal _CustID As String) As String

        Page.Trace.Write("In GetProductIDAsXML")
        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter
            Dim xw As XmlTextWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)
            xw = New XmlTextWriter(sw)

            xw.WriteStartElement("Root")
            Dim dr As DataRow
            For Each dr In drs.Select("customer_uid='" & _CustID & "'")
                xw.WriteStartElement("Product")
                xw.WriteAttributeString("id", dr("ProductId").ToString().Trim())
                xw.WriteEndElement()
            Next
            xw.WriteEndElement()

            Return sb.ToString()

        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
        End Try

    End Function
    Private Sub GetOrderDetail(ByRef drs As DataTable, ByVal _CustID As String)

        Page.Trace.Write("In GetProductIDAsXML")
        Dim ds As DataSet
        Try

            Dim _OrderIDAsXML As String = GetOrderIDAsXML(drs, _CustID)
            ds = BLLRules.WebTracker.GetProductDetails(GetConnectionData, _OrderIDAsXML)

            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim drToUpdate As DataRow
                    For Each drToUpdate In drs.Rows
                        If dr("product_id").ToString().Trim() = drToUpdate("ProductId").ToString().Trim() Then
                            drToUpdate("ProductName") = dr("cart_product_name")
                        End If
                    Next
                Next
            End If

            drs.AcceptChanges()

        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try

    End Sub
    Public Function element(ByVal val As String) As XmlElement

        Me._xmlElement1 = _xmldoc.CreateElement("Customer")
        Me._xmlAttribute1 = _xmldoc.CreateAttribute("id")
        Me._xmlAttribute1.Value = val
        Me._xmlElement1.Attributes.Append(_xmlAttribute1)
        Return Me._xmlElement1

    End Function

    'Product Names
    Private Sub GetProductDetail(ByRef drs As DataTable)

        Page.Trace.Write("In GetProductDetail")
        Dim ds As DataSet
        Try

            Dim _ProductIDAsXML As String = GetProductIDAsXML(drs)
            ds = BLLRules.WebTracker.GetProductDetails(GetConnectionData, _ProductIDAsXML)

            If Not ds Is Nothing And ds.Tables.Count = 1 Then
                Dim dr As DataRow
                For Each dr In ds.Tables(0).Rows
                    Dim drToUpdate As DataRow
                    For Each drToUpdate In drs.Rows
                        If dr("product_id").ToString().Trim() = drToUpdate("ProductId").ToString().Trim() Then
                            drToUpdate("ProductName") = dr("cart_product_name")
                        End If
                    Next
                Next
            End If

            drs.AcceptChanges()

        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
            Throw ex
        Finally
        End Try
        Page.Trace.Write("GetProductDetail End")
    End Sub
    Private Function GetProductIDAsXML(ByRef drs As DataTable) As String

        Page.Trace.Write("In GetProductIDAsXML")
        Try

            Dim sb As StringBuilder
            Dim sw As StringWriter
            Dim xw As XmlTextWriter

            sb = New StringBuilder
            sw = New StringWriter(sb)
            xw = New XmlTextWriter(sw)

            xw.WriteStartElement("Root")
            Dim dr As DataRow
            For Each dr In drs.Rows
                xw.WriteStartElement("Product")
                xw.WriteAttributeString("id", dr("ProductId").ToString().Trim())
                xw.WriteEndElement()
            Next
            xw.WriteEndElement()

            Return sb.ToString()

        Catch ex As Exception
            Page.Trace.Warn("EXception : " & ex.Message)
        End Try

    End Function


    Private Sub SetFocus(ByVal FocusControl As Control)

        Dim Script As New System.Text.StringBuilder
        Dim ClientID As String = FocusControl.ClientID
        With Script
            .Append("<script language='javascript'>")
            .Append("document.getElementById('")
            .Append(ClientID)
            .Append("').focus();")
            .Append("</script>")
        End With
        RegisterStartupScript("setFocus", Script.ToString())

    End Sub
    Private Function GetDataGridMarkupForUserHistory(ByRef dg As System.Web.UI.WebControls.DataGrid) As String

        Dim sb As StringBuilder
        Dim sw As StringWriter
        Dim hw As HtmlTextWriter

        Try

            sb = New StringBuilder
            sw = New StringWriter(sb)
            hw = New HtmlTextWriter(sw)

            dg.RenderControl(hw)

            Return sb.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Private Sub InitializeComponent()

    End Sub


    Private Sub dgActivity_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgActivity.ItemDataBound

    End Sub




End Class

Public Enum HistroyType

    Product
    Actity
    Referrer

End Enum

'#Region " Fucntion Out of CAll"

'    Private Function GetCustomerHistoryDetail(ByVal StartDate As String, ByVal EndDate As String, ByVal _DomainName As String, ByVal _CustomerIDs As String) As DataSet

'        Dim ds As DataSet
'        Try
'            ds = BLLRules.WebTracker.GetCustomerHistoryDetail(GetConnectionData, StartDate, EndDate, _DomainName, _CustomerIDs)
'            Return ds
'        Catch ex As Exception
'            Page.Trace.Warn("EXception : " & ex.Message)
'            Throw ex
'        Finally
'        End Try
'    End Function
'    Private Function GetCustomerOrderDetail(ByVal StartDate As String, ByVal EndDate As String, ByVal _CustomerIDs As String) As DataSet

'        Dim ds As DataSet
'        Try
'            ds = BLLRules.WebTracker.GetCustomerOrderDetail(GetConnectionData, StartDate, EndDate, _CustomerIDs)
'            Return ds
'        Catch ex As Exception
'            Page.Trace.Warn("EXception : " & ex.Message)
'            Throw ex
'        Finally
'        End Try
'    End Function


'    Private Function MySqlDataTable(ByVal Query As String) As DataTable
'        Page.Trace.Write("In MySqlDataTable")

'        Try


'            Dim historyDt As DataTable
'            Dim dateQuerry As String
'            dateQuerry = Query
'            Dim mySqldb As New Infinilogic.BusinessPlan.BLLRules.MySqlLayer

'            mySqldb.h_ConString()
'            mySqldb.h_Connection()
'            historyDt = mySqldb.h_DatTable(dateQuerry)
'            mySqldb.dispose()

'            Return historyDt
'        Catch ex As Exception
'            Dim str As String = ex.Message
'            Page.Trace.Warn("ex.message = " & ex.Message & vbCrLf & "ex.StrackTrace = " & ex.StackTrace)

'        End Try

'        Page.Trace.Write("MySqlDataTable End")
'    End Function


'    Private Function BuildDataGridForSession_History() As System.Web.UI.WebControls.DataGrid

'        Page.Trace.Write("In GetProductIDAsXML")
'        Dim dg As System.Web.UI.WebControls.DataGrid
'        Try

'            dg = New System.Web.UI.WebControls.DataGrid
'            dg.AllowSorting = True

'            Dim col1 As System.Web.UI.WebControls.BoundColumn
'            col1 = New System.Web.UI.WebControls.BoundColumn

'            col1.HeaderStyle.CssClass = "text_style3"
'            col1.HeaderText = "Sr."
'            col1.DataField = "Sr"
'            col1.ItemStyle.Wrap = True
'            col1.ItemStyle.CssClass = "text_style2"
'            col1.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(30)

'            Dim col2 As System.Web.UI.WebControls.BoundColumn
'            col2 = New System.Web.UI.WebControls.BoundColumn
'            col2.HeaderStyle.CssClass = "text_style3"
'            col2.HeaderText = "UniQue Session"
'            col2.DataField = "UniQueSession"
'            col2.ItemStyle.Wrap = True
'            col2.ItemStyle.CssClass = "text_style2"
'            col2.ItemStyle.HorizontalAlign = HorizontalAlign.Center

'            Dim col3 As System.Web.UI.WebControls.BoundColumn
'            col3 = New System.Web.UI.WebControls.BoundColumn
'            col3.HeaderStyle.CssClass = "text_style3"
'            col3.HeaderText = "Total Navigations"
'            col3.DataField = "TotalSessions"
'            col3.ItemStyle.Wrap = True
'            col3.ItemStyle.CssClass = "text_style2"
'            col3.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)


'            Dim col4 As System.Web.UI.WebControls.BoundColumn
'            col4 = New System.Web.UI.WebControls.BoundColumn
'            col4.HeaderStyle.CssClass = "text_style3"
'            col4.HeaderText = "Product Visited"
'            col4.DataField = "ProductVisited"
'            col4.ItemStyle.Wrap = True
'            col4.ItemStyle.CssClass = "text_style2"
'            col4.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(102)

'            Dim col5 As System.Web.UI.WebControls.BoundColumn
'            col5 = New System.Web.UI.WebControls.BoundColumn
'            col5.HeaderStyle.CssClass = "text_style3"
'            col5.HeaderText = "Total Orders"
'            col5.DataField = "TotalOrders"
'            col5.ItemStyle.Wrap = True
'            col5.ItemStyle.CssClass = "text_style2"
'            col5.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(100)

'            Dim col6 As System.Web.UI.WebControls.BoundColumn
'            col6 = New System.Web.UI.WebControls.BoundColumn
'            col6.HeaderStyle.CssClass = "text_style3"
'            col6.SortExpression = "IP"
'            col6.HeaderText = "IP"
'            col6.DataField = "IP"
'            col6.ItemStyle.Wrap = True
'            col6.ItemStyle.CssClass = "text_style2"
'            col6.ItemStyle.HorizontalAlign = HorizontalAlign.Center


'            Dim col7 As System.Web.UI.WebControls.BoundColumn
'            col7 = New System.Web.UI.WebControls.BoundColumn
'            '   col7.SortExpression = "Country"
'            col7.HeaderStyle.CssClass = "text_style3"
'            col7.HeaderText = "Country"
'            col7.DataField = "Country"
'            col7.ItemStyle.Wrap = True
'            col7.ItemStyle.CssClass = "text_style2"
'            col7.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(99)



'            dg.Columns.Add(col1)
'            dg.Columns.Add(col2)

'            dg.Columns.Add(col3)
'            dg.Columns.Add(col4)
'            dg.Columns.Add(col5)
'            dg.Columns.Add(col6)
'            dg.Columns.Add(col7)


'            dg.AutoGenerateColumns = False
'            dg.CssClass = "GridWidth"
'            dg.GridLines = GridLines.Both
'            dg.ShowHeader = True
'            dg.ShowFooter = False

'            Return dg

'        Catch ex As Exception
'            Throw ex
'        End Try

'    End Function


'    Private Function BuildDG() As System.Web.UI.WebControls.DataGrid

'        Dim dg As System.Web.UI.WebControls.DataGrid

'        Try

'            dg = New System.Web.UI.WebControls.DataGrid


'            Dim col1 As System.Web.UI.WebControls.BoundColumn
'            col1 = New System.Web.UI.WebControls.BoundColumn
'            col1.HeaderStyle.CssClass = "text_style3"
'            col1.HeaderText = "Sr.#"
'            col1.DataField = "Sr"
'            col1.ItemStyle.Wrap = True
'            col1.ItemStyle.CssClass = "text_style2"
'            col1.ItemStyle.HorizontalAlign = HorizontalAlign.Center

'            col1.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(50)

'            Dim col2 As System.Web.UI.WebControls.BoundColumn
'            col2 = New System.Web.UI.WebControls.BoundColumn
'            col2.HeaderStyle.CssClass = "text_style3"
'            col2.HeaderText = "Customer ID"
'            col2.DataField = "CustomerID"

'            col2.ItemStyle.HorizontalAlign = HorizontalAlign.Center



'            Dim col3 As System.Web.UI.WebControls.BoundColumn
'            col3 = New System.Web.UI.WebControls.BoundColumn
'            col3.HeaderStyle.CssClass = "text_style3"
'            col3.HeaderText = "FromURL"
'            col3.DataField = "FromURL"



'            Dim col4 As System.Web.UI.WebControls.BoundColumn
'            col4 = New System.Web.UI.WebControls.BoundColumn
'            col4.HeaderStyle.CssClass = "text_style3"
'            col4.HeaderText = "StartedTime"
'            col4.DataField = "StartedTime"
'            Dim col5 As System.Web.UI.WebControls.BoundColumn
'            col5 = New System.Web.UI.WebControls.BoundColumn
'            col5.HeaderStyle.CssClass = "text_style3"
'            col5.HeaderText = "Product"
'            col5.DataField = "Product"

'            Dim col6 As System.Web.UI.WebControls.BoundColumn
'            col6 = New System.Web.UI.WebControls.BoundColumn
'            col6.HeaderStyle.CssClass = "text_style3"
'            col6.HeaderText = "IP"
'            col6.SortExpression = "IP"
'            col6.DataField = "IP"
'            col6.ItemStyle.Wrap = True
'            col6.ItemStyle.CssClass = "text_style2"
'            col6.ItemStyle.HorizontalAlign = HorizontalAlign.Center

'            Dim col7 As System.Web.UI.WebControls.BoundColumn
'            col7 = New System.Web.UI.WebControls.BoundColumn
'            col7.HeaderStyle.CssClass = "text_style3"
'            ' col7.SortExpression = "Country"
'            col7.HeaderText = "Country"
'            col7.DataField = "Country"
'            col7.ItemStyle.Wrap = True
'            col7.ItemStyle.CssClass = "text_style2"
'            col7.ItemStyle.Width = System.Web.UI.WebControls.Unit.Pixel(99)


'            dg.Columns.Add(col1)
'            dg.Columns.Add(col2)
'            dg.Columns.Add(col6)
'            dg.Columns.Add(col7)


'            dg.AutoGenerateColumns = False
'            dg.CssClass = "GridWidthActivity"
'            dg.GridLines = GridLines.Both
'            dg.ShowHeader = True
'            dg.ShowFooter = False

'            Return dg

'        Catch ex As Exception
'            Throw ex
'        End Try

'    End Function


'    Private Function SortURL(ByVal url As String) As String
'        If url.IndexOf("&customerId=") = -1 And url.IndexOf("&customerJID=") - 1 Then
'            bol1 = True
'            Return url
'        Else
'            Dim customerJID, customerId, removeJid, urlStr2 As String
'            Dim urlStr, JidIndex, IdIndex As Integer
'            customerJID = "&customerJID"
'            customerId = "&customerId"
'            urlStr = url.IndexOf(url)
'            JidIndex = url.IndexOf(customerJID)
'            removeJid = url.Substring(urlStr, JidIndex)
'            IdIndex = url.IndexOf(customerId)
'            urlStr2 = url.Substring(urlStr, IdIndex)
'            Return urlStr2
'        End If
'    End Function

'    Private Function parseCustomerId(ByVal url As String) As String
'        If url.IndexOf("&customerId=") = -1 And url.IndexOf("&customerJID=") = -1 Then
'            bol2 = True
'            Return url
'        Else
'            Dim search_str, jabberId, splitJabberId, parseCId As String
'            search_str = "&customerId="
'            Dim start_index As Integer = url.IndexOf(search_str)
'            jabberId = url.Substring(start_index)
'            splitJabberId = url.IndexOf("&customerJID")
'            parseCId = url.Substring(url.IndexOf(url), splitJabberId)
'            Dim splitCustomerId As String() = parseCId.Split("=")
'            Return splitCustomerId(1)
'        End If
'    End Function

'    Private Function ParseOpreatorId(ByVal url As String) As String
'        If url.IndexOf("operatorJID") = -1 Then
'            bol1 = True
'            Dim Str As String = "Operator is not Available!"
'            Return Str
'        Else
'            Dim search_str As String = "operatorJID="
'            Dim start_index As Integer = url.IndexOf(search_str)
'            Dim operatorId As String = url.Substring(start_index)
'            Dim splitOperatorId As String() = operatorId.Split("=")
'            If splitOperatorId(1) = "null" Or splitOperatorId(1) = "undefined" Then
'                splitOperatorId(1) = "Operator is not Available!"
'            End If
'            Return splitOperatorId(1)
'        End If
'    End Function

'    Private Function ParseJabberId(ByVal url As String) As String
'        If url.IndexOf("&customerId=") = -1 Or url.IndexOf("&customerJID=") = -1 Or url.IndexOf("operatorJID=") = -1 Then
'            bol = True
'            Return url
'        Else
'            Dim ind_JabberId As Integer = url.IndexOf("&customerJID=")
'            Dim jabberId As String = url.Substring(ind_JabberId)
'            Dim ind_OperatorId As Integer = jabberId.IndexOf("&operatorJID=")
'            Dim splitUrl As String() = jabberId.Split("&")
'            Dim splitJabberId As String() = splitUrl(1).Split("=")
'            Return splitJabberId(1)
'        End If
'    End Function

'    Private Sub InitializeComponent()

'    End Sub

'#End Region

