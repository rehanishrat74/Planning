<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Subscription.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Subscription" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Serivce's Subscription Status</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="MainBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="MainForm" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<!--TOP BAR-->
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<!--TOP BAR-->
					<!--MAIN CONTENT AREA-->
					<tr>
						<TD id="menuarea" vAlign="top" align="left" runat="server"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
						<td vAlign="top">
							<table id="maintable" width="100%" align="center">
								<!--SOME DESCRIPTIVE TEXT-->
								<tr>
									<td class="content" height="50"><asp:literal id="TheMessage" Runat="server">Dear Customer, You 
            have been using following services to facilitate your business 
            process. Here you are provided with the <B>Service's Subscription Status</B> that needs your attention. Thanks. </asp:literal></td>
								</tr>
								<!--FIRST GRID WITH SERVICES ABOUT TO EXPIRED-->
								<TR>
									<TD vAlign="top" align="center" width="100%"><asp:datagrid id="DGLast3Months" runat="server" Width="100%" AutoGenerateColumns="False" bgcolor="#edf3f8">
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="HEADING"></HeaderStyle>
													<HeaderTemplate>
														Services with Subscription being expired within 3 months
													</HeaderTemplate>
													<ItemTemplate>
														<table id="SubscriptionLast3Months" width="100%">
															<tr>
																<td rowspan="3" width="40%">
																	<!--
																	<b>Service </b>
																	<%# DataBinder.Eval(Container.DataItem, "Service")%>
																	-->
																	<img id="ServiceLogoUrl1" runat="server">
																</td>
															</tr>
															<tr style="FONT-WEIGHT: bold; COLOR: red">
																<td width="30%">Due Date</td>
																<td width="30%">
																	<%# DataBinder.Eval(Container.DataItem, "DueDate", "{0:d}")%>
																</td>
															</tr>
															<tr>
																<td width="30%">Last Subscription Date</td>
																<td width="30%">
																	<%# DataBinder.Eval(Container.DataItem, "LastSubscriptionDate", "{0:d}")%>
																</td>
															</tr>
															<tr>
																<td></td>
																<td>
																</td>
																<td>
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
								<!--SECOND GRID WITH SERVICES ALREADY EXPIRED-->
								<TR>
									<TD vAlign="top" align="center" width="100%"><asp:datagrid id="DGExpired" runat="server" Width="100%" AutoGenerateColumns="False" bgcolor="#edf3f8">
											<Columns>
												<asp:TemplateColumn>
													<HeaderStyle CssClass="HEADING"></HeaderStyle>
													<HeaderTemplate>
														Services with Subscription already expired
													</HeaderTemplate>
													<ItemTemplate>
														<table id="SubscriptionExpired" width="100%">
															<tr>
																<td rowspan="3" width="40%">
																	<!--
																	<b>Service </b>
																	<%# DataBinder.Eval(Container.DataItem, "Service")%>
																	-->
																	<img id="ServiceLogoUrl2" runat="server">
																</td>
															</tr>
															<tr style="FONT-WEIGHT: bold; COLOR: red">
																<td width="30%">Expired on</td>
																<td width="30%">
																	<%# DataBinder.Eval(Container.DataItem, "DueDate", "{0:d}")%>
																</td>
															</tr>
															<tr>
																<td width="30%">Last Subscribed on</td>
																<td width="30%">
																	<%# DataBinder.Eval(Container.DataItem, "LastSubscriptionDate", "{0:d}")%>
																</td>
															</tr>
															<tr>
																<td></td>
																<td>
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:datagrid></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="right" width="100%"></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="right" width="100%"><asp:button id="BtnRenew" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
											runat="server" Text="Renew Service..." cssclass="acc_mbutton"></asp:button>&nbsp;
										<asp:button id="BtnContinue" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
											runat="server" Text="Continue..." cssclass="acc_mbutton"></asp:button>&nbsp;
										<asp:button id="BtnSignOut" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
											runat="server" Text="Sign Out" cssclass="acc_mbutton"></asp:button></TD>
								</TR>
							</table>
						</td>
					</tr>
					<!--MAIN CONTENT AREA-->
					<!--BOTTOM BAR-->
					<tr>
						<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
					</tr>
					<!--BOTTOM BAR--></tbody></table>
		</form>
	</body>
</HTML>
