<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Notifications.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MessageNotifications" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Messages - Notifications</title>
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
					<td id="contentarea" runat="server" width="679" vAlign="top">
						<TABLE class="content" id="Table1" height="225" cellSpacing="0" cellPadding="0" width="703"
							border="0" style="WIDTH: 703px; HEIGHT: 225px">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD id="membersarea" runat="server" vAlign="top" align="left" width="80%">
									<TABLE class="content" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="WIDTH: 612px" vAlign="top" align="left">
												<asp:datagrid id="nGrid" runat="server" BackColor="White" AutoGenerateColumns="False" AllowPaging="True"
													Width="100%">
													<ItemStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="Black" BackColor="White"></ItemStyle>
													<HeaderStyle Font-Size="XX-Small" Font-Names="Verdana" ForeColor="White" BackColor="MidnightBlue"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="notification" HeaderText="Notification">
															<HeaderStyle Width="100%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Date" HeaderText="Date/Time">
															<HeaderStyle Width="0%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
													</Columns>
													<PagerStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" BackColor="LightGray"
														Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 612px" align="right" runat="server" id="notification"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td id="rightbar" width="5%" runat="server" style="HEIGHT: 157px"></td>
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
