Imports System.Text
Imports System.Data
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports InfiniLogic.AccountsCentre.BLL



Public Class MessageDefault

    Inherits PageTemplate
    'Inherits System.Web.UI.Page
#Region " Declaration"
    Protected Enum MessageBoxEnum
        INBOX = 1
        SENTBOX = 2
        TRASHBOX = 3
    End Enum
    Protected WithEvents menuarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents membersarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents btpostreply As System.Web.UI.WebControls.Button
    Protected WithEvents chkSent As System.Web.UI.WebControls.CheckBox
    Protected WithEvents txtpMessage As System.Web.UI.WebControls.TextBox
    Protected WithEvents Services As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txtpsubject As System.Web.UI.WebControls.TextBox
    Protected WithEvents inboxGrid As System.Web.UI.WebControls.DataGrid
    Protected WithEvents scriptblock As System.Web.UI.WebControls.Literal
    Protected WithEvents Label1 As System.Web.UI.WebControls.Label
    Protected WithEvents pnlDisplayGrid As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMessageReply As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlDisplayMessage As System.Web.UI.WebControls.Panel
    Protected WithEvents pnlMessageButton As System.Web.UI.WebControls.Panel
    Protected WithEvents btnNew As System.Web.UI.WebControls.Button
    Protected WithEvents btnReplyMessage As System.Web.UI.WebControls.Button
    Protected WithEvents btnNewMessage As System.Web.UI.WebControls.Button
    Protected WithEvents btnStatus As System.Web.UI.WebControls.Button
    Protected CurrentPage As String, CurrentBox As MessageBoxEnum, IsPopup As Boolean = True
    Public messageCount As Int16, CurrentPageNo As Int16
    Protected WithEvents TheMenu As New LeftMenu(180)
    Dim objPanelText As System.Web.UI.LiteralControl
    Dim objDataset As DataSet
    Dim intLoop As Integer = 0
    Dim intBGColor As Integer = 0

    Protected WithEvents contentarea As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents topbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents rightbar As System.Web.UI.HtmlControls.HtmlTableCell
    Protected WithEvents bottombar As System.Web.UI.HtmlControls.HtmlTableCell

    Dim strBGColor As String
#End Region
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

#End Region
#Region " Methods"
    'generic method for Deleting Box message from message archive 
    'use by its child pages like inbox.aspx,sentbox.aspx,trashbox.aspx
    Protected Sub DeleteBoxMessages(ByVal WhichBox As MessageBoxEnum, ByVal MSGS As Object)
        Select Case WhichBox
            Case MessageBoxEnum.INBOX
                InfiniLogic.AccountsCentre.BLL.MessageBoard.DeleteInboxMessages(MSGS)
            Case MessageBoxEnum.SENTBOX
                InfiniLogic.AccountsCentre.BLL.MessageBoard.DeleteSentboxMessages(MSGS)
            Case MessageBoxEnum.TRASHBOX
                InfiniLogic.AccountsCentre.BLL.MessageBoard.DeleteTrashboxMessages(MSGS)
        End Select
    End Sub
    'generic method for Restoring message from message archive 
    'use by its child page like trashbox.aspx
    Protected Sub RestoreMessages(ByVal MSGS As Object)
        InfiniLogic.AccountsCentre.BLL.MessageBoard.RestoreMessages(MSGS)
    End Sub
    'generic method for display message archive to its child pages 
    'use by its child pages like inbox.aspx,sentbox.aspx,trashbox.aspx
    Protected Sub ShowBox(ByVal WhichBox As MessageBoxEnum)
        messageCount = 0
        inboxGrid.PageSize = 5
        CurrentBox = WhichBox
        inboxGrid.CurrentPageIndex = IIf(CurrentPageNo >= 0, CurrentPageNo, 1)
        Select Case WhichBox
            Case MessageBoxEnum.INBOX
                CurrentPage = "inbox.aspx"
                inboxGrid.DataSource = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetInbox(customerid)
            Case MessageBoxEnum.SENTBOX
                CurrentPage = "sentbox.aspx"
                inboxGrid.DataSource = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSentbox(customerid)
            Case MessageBoxEnum.TRASHBOX
                CurrentPage = "trashbox.aspx"
                inboxGrid.DataSource = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetTrashbox(customerid)
        End Select
        inboxGrid.DataBind()
        pnlDisplayGrid.Visible = True
        pnlMessageButton.Visible = False
        pnlDisplayMessage.Visible = False
        pnlMessageReply.Visible = False
    End Sub
    'generic method for displaying whole message from message archive 
    'use by its child page like inbox.aspx,sentbox.aspx,trashbox.aspx
    Protected Sub ShowBoxMessage(ByVal WhichBox As MessageBoxEnum, ByVal MsgId As Object)
        Dim oReader As Object
        Dim userName As String
        Dim ltMessage As New System.Web.UI.WebControls.Literal
        Dim strMessageDetails As String
        objDataset = New DataSet
        Select Case WhichBox
            Case MessageBoxEnum.INBOX, MessageBoxEnum.TRASHBOX
                objDataset = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetInboxMessage(MsgId)
            Case MessageBoxEnum.SENTBOX
                objDataset = InfiniLogic.AccountsCentre.BLL.MessageBoard.GetSentboxMessage(MsgId)
        End Select
        For intLoop = 0 To objDataset.Tables(0).Rows.Count - 1
            If intBGColor = 0 Then
                strBGColor = "White"
                intBGColor = 1
            Else
                strBGColor = "#F2F6FA"
                intBGColor = 0
            End If
            strMessageDetails = strMessageDetails + "<Table Border=0 cellspacing=0 cellpadding=0 width='100%' bgcolor=" + strBGColor + ">"
            strMessageDetails = strMessageDetails + "<TR bgcolor='#e2effe'>"
            strMessageDetails = strMessageDetails + "<TD>&nbsp;&nbsp;"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "<TD>"
            strMessageDetails = strMessageDetails + "<Font face='verdana' size='2'>" + objDataset.Tables(0).Rows(intLoop).Item("sendername") + "</font"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "<TD>"
            strMessageDetails = strMessageDetails + "<Font face='verdana' size='2'>" + objDataset.Tables(0).Rows(intLoop).Item("datetime") + "</font"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "<TD>"
            If objDataset.Tables(0).Rows(intLoop).Item("Subject") <> "" Then
                strMessageDetails = strMessageDetails + "<Font face='verdana' size='2'>&lt;" + objDataset.Tables(0).Rows(intLoop).Item("Subject") + "&gt;</font>"
            Else
                strMessageDetails = strMessageDetails + "<Font face='verdana' size='2'>&lt;no subject&gt;</font>"
            End If
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "</TR>"
            strMessageDetails = strMessageDetails + "<TR>"
            strMessageDetails = strMessageDetails + "<TD>"
            strMessageDetails = strMessageDetails + "<BR>"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "</TR>"
            strMessageDetails = strMessageDetails + "<TR>"
            strMessageDetails = strMessageDetails + "<TD>&nbsp;&nbsp;"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "<TD colspan='3'>"
            strMessageDetails = strMessageDetails + "<font face='verdana' size='2' color='#336699'>" + objDataset.Tables(0).Rows(intLoop).Item("message") + "</font>"
            strMessageDetails = strMessageDetails + "<br>"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "</TR>"
            strMessageDetails = strMessageDetails + "<TR>"
            strMessageDetails = strMessageDetails + "<TD>"
            strMessageDetails = strMessageDetails + "<BR>"
            strMessageDetails = strMessageDetails + "<BR>"
            strMessageDetails = strMessageDetails + "</TD>"
            strMessageDetails = strMessageDetails + "</TR>"
            strMessageDetails = strMessageDetails + "</Table>"
            strMessageDetails = strMessageDetails + "<P/>"
            Session("messageid") = objDataset.Tables(0).Rows(intLoop).Item("msgid")
            Session("UserIDTo") = objDataset.Tables(0).Rows(0).Item("userid")
            Session("UserID") = objDataset.Tables(0).Rows(0).Item("useridto")
            Session("ParentID") = objDataset.Tables(0).Rows(intLoop).Item("ParentID")
            Session("Subject") = objDataset.Tables(0).Rows(intLoop).Item("Subject")
            Session("Service") = objDataset.Tables(0).Rows(intLoop).Item("service")
        Next
        ltMessage.Text = strMessageDetails
        pnlDisplayMessage.Controls.Add(ltMessage)
        pnlDisplayMessage.Visible = True
        pnlMessageButton.Visible = True
        pnlMessageReply.Visible = False
        pnlDisplayGrid.Visible = False
        objDataset.Dispose()
    End Sub
    Protected Sub PostMessage()
        Dim strUserID As String
        Dim intParentID As Integer
        Dim strMessageType As String
        If CType(Session("ParentID"), String) = "" Then
            intParentID = 0
        ElseIf CType(Session("ParentID"), String) = "0" Then
            intParentID = Session("messageid")
        Else
            intParentID = Session("parentid")
        End If        
        If IsDBNull(Session("UserIDTo")) Then
            strUserID = Application("DefaultAdmin")
        Else
            If CType(Session("UserIDTo"), String) = "" Then
                strUserID = Application("DefaultAdmin")
            Else
                strUserID = Session("UserIDTo")
            End If
        End If
        InfiniLogic.AccountsCentre.BLL.MessageBoard.PostInboxMessage(customerid, strUserID, Services.SelectedItem.Text, txtpsubject.Text, txtpMessage.Text, intParentID)
        'If chkSent.Checked = True Then
        '    MessageBoard.PostSentboxMessage(customerid, Application("DefaultAdmin"), Services.SelectedItem.Text, txtpsubject.Text, txtpMessage.Text)
        'End If
        txtpMessage.Text = ""
        txtpsubject.Text = ""
        If Not IsPopup Then
            ShowBox(CurrentBox)
            'Else
            'Label1.Text = "Message has been posted press |Close| Button to Close this window"

        End If
        ShowBox(MessageBoxEnum.INBOX)
        Session("UserIDTo") = ""
        Session("ParentID") = ""
        Response.Redirect("inbox.aspx")
        pnlDisplayGrid.Visible = True
        pnlDisplayMessage.Visible = False
        pnlMessageReply.Visible = False
    End Sub

#End Region
#Region " Events"
    'Initialize menu on he left bar of each page in this area this 
    'functionally is inherited by its child pages
    Private Sub menuarea_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuarea.Init

        'With TheMenu
        '    .AddItem("IMG", "/images/messageboard.jpg", "/message/default.aspx", True)
        '    .AddItem("INB", ">> Inbox", "Inbox.aspx")
        '    '.AddItem("SNT", ">> Sent Messages", "sentbox.aspx")
        '    '.AddItem("TRS", ">> Trash can", "trashbox.aspx")
        '    .AddItem("NTS", ">> Notifications", "Notifications.aspx")
        'End With
        'menuarea.InnerHtml = TheMenu.Render
        'TheMenu = Nothing
        'IsPopup = False
    End Sub
    'callback for the generic grid in any box pages like inbox.aspx and sentbox.aspx
    'format grid cell as required.
    Public Sub inboxGrid_ItemDataBound(ByVal sender As Object, ByVal e As DataGridItemEventArgs)
        Dim t As String, p As String
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem
                messageCount = messageCount + 1
                If e.Item.DataItem("mStatus") = "R" Then e.Item.BackColor = System.Drawing.Color.White
                t = e.Item.Cells(0).Text
                If t = "&nbsp;" Or t.Length <= 0 Then
                    p = "No Subject"
                    t = p
                Else
                    If t.Length > 25 Then p = t.Substring(0, 25) & ".." Else p = t
                End If

                e.Item.Cells(0).Text = "<a style='cursor:hand' onclick=" & Chr(34) & "window.navigate('" & CurrentPage & "?MSG=" & e.Item.DataItem("msgid") & "')" & Chr(34) & " onmouseover=" & Chr(34) & "this.className='MSGON';" & Chr(34) & " onmouseout=" & Chr(34) & "this.className='';" & Chr(34) & " >" & p & "</a>"
                e.Item.Cells(0).ToolTip = t
                'e.Item.Cells(6).Text = "<input type=checkbox style='cursor:hand' id=M" & messageCount & " name=" & e.Item.DataItem("msgid") & "  onclick=" & Chr(34) & "CheckClicked(this);" & Chr(34) & " value=false>"
                scriptblock.Text = "<SCRIPT>var mm=" & messageCount & ",myUrl=" & Chr(34) & CurrentPage & Chr(34) & ";</script>"
        End Select

    End Sub
    'another callback for the generic grid in any box pages like inbox.aspx and sentbox.aspx
    'change display data page of grid.
    Public Sub inboxGrid_Page(ByVal Sender As Object, ByVal E As DataGridPageChangedEventArgs)
        inboxGrid.CurrentPageIndex = E.NewPageIndex
        CurrentPageNo = E.NewPageIndex
        ShowBox(CurrentBox)
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Session("MSGMODE") = "NEW"
        pnlMessageReply.Visible = True
        pnlDisplayGrid.Visible = False
        pnlDisplayMessage.Visible = False
        txtpsubject.Text = ""
        txtpMessage.Text = ""
        Session("UserIDTo") = Application("DefaultAdmin")
        Session("parentid") = ""
    End Sub
    Private Sub btnStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim strUserID As String
        Dim intParentID As Integer
        Dim strMessageType As String
        Dim intMessageID As Integer
        Dim strMessage As String

        If CType(Session("ParentID"), String) = "" Then
            intParentID = 0
        ElseIf CType(Session("ParentID"), String) = "0" Then
            intParentID = Session("messageid")
        Else
            intParentID = Session("parentid")
        End If

        If (CType(CustomerID, String) = CType(Session("UserIDTo"), String)) Then
            If IsDBNull(Session("UserID")) = False Then
                strUserID = Session("UserID")
            Else
                strUserID = ""
            End If
        End If

            If CType(Session("parentid"), Integer) = 0 Then
                intMessageID = Session("messageid")
            Else
                intMessageID = Session("parentid")
            End If
            InfiniLogic.AccountsCentre.BLL.MessageBoard.PostInboxMessage(customerid, strUserID, Session("Service"), "Complete Message Status", "User Have Complete this Message Status", intParentID)
            'strMessage = InfiniLogic.AccountsCentre.BLL.MessageBoard.changeStatus(intMessageID)
            Response.Redirect("inbox.aspx")
    End Sub
    Private Sub btnNewMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewMessage.Click
        Session("MSGMODE") = "NEW"
        pnlMessageReply.Visible = True
        pnlDisplayGrid.Visible = False
        pnlDisplayMessage.Visible = False
        btnNewMessage.Enabled = False
        txtpsubject.Text = ""
        txtpMessage.Text = ""
        Session("UserIDTo") = Application("DefaultAdmin")
        Session("parentid") = ""
    End Sub
    Private Sub btnReplyMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReplyMessage.Click
        Session("MSGMODE") = "REPLY"
        If (CType(CustomerID, String) = CType(Session("UserIDTo"), String)) Then
            Session("UserIDTo") = Session("UserID")
        End If
        pnlMessageReply.Visible = True
        pnlDisplayGrid.Visible = False
        pnlDisplayMessage.Visible = False
        txtpsubject.Text = "Re:" & Session("subject")
        txtpMessage.Text = ""
        btnReplyMessage.Enabled = False
    End Sub
#End Region


    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
