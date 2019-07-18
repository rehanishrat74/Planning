<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Download.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Download" %>
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
	<body id="UIBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
	<form id="UIForm" method="post" runat="server">
		<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
			border="0">
			<tr>
				<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
			</tr>
			<tr>
				<td height="10"></td>
			</tr>
			<tr vAlign="top">
				<td id="contentarea" align="center" runat="server">
					
						<table cellSpacing="0" cellPadding="0">
							<tr>
								<td>
									<!-- #include virtual="..\Include\span.htm" --></td>
							</tr>
							<tr>
								<td class="MSGBAR" style="PADDING-LEFT: 5px; FONT-SIZE: small" height="40">Desktop 
									Applications List</td>
							</tr>
							<tr>
								<td>
									<asp:datagrid id="dgDownloads" ShowHeader="False" BorderStyle="Solid" BorderColor="#000000" BorderWidth="1px"
										CellPadding="5" AutoGenerateColumns="False" Runat="server">
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Status"></asp:BoundColumn>
											<asp:BoundColumn ItemStyle-VerticalAlign="Bottom" ItemStyle-CssClass="frm-section-text" ItemStyle-Font-Size="13"
												DataField="Name" HeaderText="Application">
												<ItemStyle Width="150px"></ItemStyle>
											</asp:BoundColumn>
											<asp:ButtonColumn ItemStyle-VerticalAlign="Bottom" ItemStyle-CssClass="frm-section-text" Text="Download"
												HeaderText="Download" CommandName="Download"></asp:ButtonColumn>
											<asp:TemplateColumn HeaderText="Image">
												<ItemTemplate>
													<asp:ImageButton id="DownloadImage" runat="server"></asp:ImageButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid>
								</td>
							</tr>
						</table>
					
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
