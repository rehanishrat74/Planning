<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Downloads.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Downloads_Default" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Downloads</title> 
		<!--<META http-equiv="refresh" content="3;URL=https://www.accountscentre.com/members">-->
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="UIBody" leftmargin="0" rightmargin="0" topmargin="0" bottommargin="0">
		<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
			border="0">
			<tr>
				<td id="topbar" colSpan="2" height="20%" runat="server"></td>
			</tr>
			<tr>
				<td height="10"></td>
			</tr>
			<tr valign="top">
				<td id="contentarea" align="center" runat="server">
					<form id="UIForm" method="post" runat="server">
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td>
									<!-- #include virtual="..\Include\span.htm" -->
								</td>
							</tr>
							<tr>
								<td style="PADDING-LEFT: 5px; FONT-SIZE: small" height="40" Class="MSGBAR">Desktop 
									Applications List</td>
							</tr>
							<tr>
								<td>
									<asp:DataGrid ID="dgDownloads" Runat="server" AutoGenerateColumns="False" CssClass="text-outerborder-light_blue_background"
										CellPadding="5" BorderWidth="0px" BorderStyle="None" ShowHeader="False">
										<ItemStyle VerticalAlign="Top" Font-Size="X-Small" CssClass="frm-section-text"></ItemStyle>
										<Columns>
											<asp:BoundColumn ItemStyle-Width="150" HeaderText="Application" DataField="Name"></asp:BoundColumn>
											<asp:BoundColumn ItemStyle-Width="300" HeaderText="Description" DataField="Description"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="" DataField=""></asp:BoundColumn>
										</Columns>
									</asp:DataGrid></td>
							</tr>
						</table>
					</form>
				</td>
				<td id="rightbar" width="5%" runat="server"></td>
			</tr>
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
			</tr>
		</table>
		</FORM>
	</body>
</HTML>
