<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Sentbox.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MessageSentbox" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Messages - Sentbox</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" ID="Body1">
		<form id="msgform" method="post" runat="server">
			<table id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0"
				class="CONTENT">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" runat="server" width="679" style="WIDTH: 679px">
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="center" width="180">
									<include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></TD>
								<TD id="membersarea" runat="server" vAlign="top" align="left" width="80%">
									<TABLE class="content" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="WIDTH: 612px" vAlign="top" align="left">
												<asp:datagrid id="inboxGrid" runat="server" BackColor="LightSteelBlue" OnItemDataBound="inboxGrid_ItemDataBound"
													AutoGenerateColumns="False" AllowPaging="True" Width="611px" OnPageIndexChanged="inboxGrid_Page">
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
														<asp:BoundColumn Visible="False" DataField="isnew"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="isnew"></asp:BoundColumn>
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
											<TD style="WIDTH: 612px; HEIGHT: 23px" align="right">
												<INPUT class="MBUTTON" onmouseover="this.className='MBUTTONON';" onclick="DeleteMessages()"
													onmouseout="this.className='MBUTTON';" type="button" value="Delete"> <INPUT id="allcheck" onclick="checkAll(this);" type="checkbox" name="allcheck"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 612px; HEIGHT: 1px" align="left"><STRONG>Subject </STRONG>
												<asp:textbox id="txtpsubject" runat="server" Width="557px" CssClass="mtbox"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 612px; HEIGHT: 21px" align="left"><STRONG>Service
													<asp:dropdownlist id="Services" runat="server" Width="271px" CssClass="mtbox">
														<asp:ListItem Value="General">General</asp:ListItem>
														<asp:ListItem Value="Book keeping">Book keeping</asp:ListItem>
														<asp:ListItem Value="Payroll">Payroll</asp:ListItem>
														<asp:ListItem Value="Corporation Tax Return eFiling">Corporation Tax Return eFiling</asp:ListItem>
														<asp:ListItem Value="Company Annual Accounts">Company Annual Accounts</asp:ListItem>
													</asp:dropdownlist></STRONG></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 612px" align="right">
												<asp:textbox id="txtpMessage" runat="server" Width="611px" CssClass="mtbox" TextMode="MultiLine"
													Height="223px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 612px" align="right">
												<asp:checkbox id="chkSent" runat="server" CssClass="tx1" Text="Copy to sent Messages" TextAlign="Left"></asp:checkbox>&nbsp;&nbsp;
												<asp:button id="btpostreply" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';"
													runat="server" Width="81px" CssClass="MBUTTON" Text="Post/Reply" Font-Bold="True"></asp:button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td id="rightbar" width="5%" runat="server"></td>
				</tr>
				<tr>
					<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</tr>
			</table>
		</form>
		<asp:Literal id="scriptblock" runat="server"></asp:Literal>
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
		</script>
	</body>
</HTML>
