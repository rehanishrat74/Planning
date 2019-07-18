<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="inbox.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MessageInbox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Messages - Inbox</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft FrontPage 5.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="msgform" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<TR>
					<TD id="menuarea" vAlign="top" align="center" width="180" runat="server"><include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></TD>
					<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server">
						<TABLE class="content" id="tblDisplayGrid" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD vAlign="top" align="left" width="100%"><asp:panel id="pnlDisplayGrid" Width="100%" Runat="server">
										<TABLE id="" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD>
													<asp:datagrid id="inboxGrid" runat="server" Width="100%" OnPageIndexChanged="inboxGrid_Page" AllowPaging="True"
														AutoGenerateColumns="False" OnItemDataBound="inboxGrid_ItemDataBound" BackColor="LightSteelBlue">
														<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#BCC0D1"></ItemStyle>
														<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="White" BackColor="MidnightBlue"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="subject" HeaderText="Subject">
																<HeaderStyle Width="30%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="sendername" HeaderText="Sender">
																<HeaderStyle Width="23%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="service" HeaderText="Service">
																<HeaderStyle Width="20%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="Datetime" HeaderText="Date/Time">
																<HeaderStyle Width="24%"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="mstatus"></asp:BoundColumn>
															<asp:BoundColumn Visible="False" DataField="mstatus"></asp:BoundColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="3%"></HeaderStyle>
																<ItemTemplate>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn Visible="False" DataField="msgid"></asp:BoundColumn>
														</Columns>
														<PagerStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" BackColor="LightGray"
															Mode="NumericPages"></PagerStyle>
													</asp:datagrid></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 23px" align="right" width="100%">
													<asp:Button class="MBUTTON" id="btnNew" onmouseover="this.className='MBUTTONON';" runat="server"
														BorderWidth="1px" BorderStyle="Solid" BorderColor="#336699" Height="18px" key="acc_message_inbox_btnnew"></asp:Button>&nbsp;<INPUT class="MBUTTON" id="btnback" onmouseover="this.className='MBUTTONON';" style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; WIDTH: 93px; BORDER-BOTTOM: #336699 1px solid; HEIGHT: 18px"
														onclick="javascript:javascript:history.back();" type="button" name="btnback" runat="server" key="acc_btnback">
													<!--<INPUT class="MBUTTON" onmouseover="this.className='MBUTTONON';" style="WIDTH: 53px; HEIGHT: 19px" onclick="DeleteMessages()" onmouseout="this.className='MBUTTON';" type="button" value="Delete">
													<INPUT id="allcheck" onclick="checkAll(this);" type="checkbox" name="allcheck"--></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<tr>
								<td><asp:panel id="pnlMessageButton" Width="100%" Runat="server" Height="16px">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD align="left" bgColor="#e2effe">
													<asp:Button class="MBUTTON" id="btnReplyMessage" onmouseover="this.className='MBUTTONON';" runat="server"
														BorderWidth="1px" BorderStyle="Solid" BorderColor="#336699" Height="18px" key="acc_message_inbox_btnreplymessage"></asp:Button>
													<asp:Button class="MBUTTON" id="btnNewMessage" onmouseover="this.className='MBUTTONON';" runat="server"
														BorderWidth="1px" BorderStyle="Solid" BorderColor="#336699" Height="18px" key="acc_message_inbox_btnnew"></asp:Button>
													<asp:Button class="MBUTTON" id="btnStatus" onmouseover="this.className='MBUTTONON';" runat="server"
														BorderWidth="1px" BorderStyle="Solid" BorderColor="#336699" Height="18px" key="acc_message_inbox_btnstatus"></asp:Button></TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><br>
								</td>
							</tr>
							<TR>
								<TD style="HEIGHT: 310px" align="center"><asp:panel id="pnlMessageReply" Width="98%" Runat="server">
										<TABLE id="tblReplyMessage" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="HEIGHT: 20px" align="left"><STRONG><FONT color="#336699" size="2">
															<asp:Label id="lblsubject" runat="server" key="acc_message_lblsubject"></asp:Label>:</FONT></STRONG>
													<asp:textbox id="txtpsubject" runat="server" Width="515px" CssClass="mtbox"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 21px" align="left"><STRONG><FONT color="#336699" size="2">
															<asp:Label id="lblservice" runat="server" key="acc_message_lblservice"></asp:Label>:</FONT>
														<asp:dropdownlist id="Services" runat="server" Width="271px" CssClass="mtbox">
															<asp:ListItem Value="General">General</asp:ListItem>
															<asp:ListItem Value="Book keeping">Book keeping</asp:ListItem>
															<asp:ListItem Value="Payroll">Payroll</asp:ListItem>
															<asp:ListItem Value="Corporation Tax Return eFiling">Corporation Tax Return eFiling</asp:ListItem>
															<asp:ListItem Value="Company Annual Accounts">Company Annual Accounts</asp:ListItem>
														</asp:dropdownlist></STRONG></TD>
											</TR>
											<TR>
												<TD align="right">
													<asp:textbox id="txtpMessage" runat="server" Width="100%" Height="223px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
											</TR>
											<TR>
												<TD align="right" width="100%">&nbsp;&nbsp; <INPUT class="MBUTTON" id="Button1" onmouseover="this.className='MBUTTONON';" onclick="PostMessage();"
														onmouseout="this.className='MBUTTON';" type="button" name="Button1" runat="server" Width="81px" key="acc_message_btnpost/reply">&nbsp;<INPUT class="MBUTTON" id="Button2" onmouseover="this.className='MBUTTONON';" style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; WIDTH: 93px; BORDER-BOTTOM: #336699 1px solid; HEIGHT: 18px"
														onclick="javascript:javascript:history.back();" type="button" name="Button2" runat="server" key="acc_btnback"></TD>
											</TR>
										</TABLE>
									</asp:panel></TD>
							</TR>
							<TR>
								<TD align="center"><asp:panel id="pnlDisplayMessage" style="OVERFLOW: auto" Width="100%" Runat="server" HorizontalAlign="Justify"
										Font-Names="ververdana" Font-Size="XX-Small"></asp:panel></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<include:bottombar id="Bottonbar1" runat="server"></include:bottombar><asp:literal id="scriptblock" runat="server"></asp:literal>
		<script>



var dMessages="";			

function DeleteMessages(){
if(dMessages=="") 
alert("Please select a message to delete");
else{
if(confirm("Are you sure to delete selected messages")==true){
	msgform.action=myUrl+"?ACT=DEL&MSG="+dMessages;
	msgform.submit();}
}
}

function RestoreMessages(){
if(dMessages=="") 
alert("Please select a message to Restore");
else{
if(confirm("Are you sure to Restore selected messages")==true){
	msgform.action=myUrl+"?ACT=RES&MSG="+dMessages;
	msgform.submit();}
}
}

function checkAll(o){
var oo;
for(var ic=1;ic<=mm;ic++){
	oo=document.getElementById("M"+ic);
	oo.checked=o.checked;
}
CheckClicked();
}
function CheckClicked(o){
var oo;
dMessages="";
for(var ic=1;ic<=mm;ic++){
	oo=document.getElementById("M"+ic);
	if (oo.checked==true) dMessages=dMessages+oo.name+",";
}
//window.status="check=" +  t;


}

function PostMessage(){	
	myUrl="inbox.aspx";
	msgform.action = myUrl+"?ACT=POST";	
	msgform.submit(); 
}
		</script>
	</body>
</HTML>
