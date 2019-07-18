<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SelectCustomer.aspx.vb" Inherits="accounts.infinibiz.Web.SelectCustomer" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Member Home</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="frmSelCustomer" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" style="WIDTH: 100%" width="100%" runat="server">
						<TABLE class="CONTENT" id="layouttable2" height="100%" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<TBODY>
								<TR>
									<td id="rightbar" width="5%" runat="server"></td>
								</TR>
								<tr>
									<TD id="menuarea" vAlign="top" align="left" width="180" runat="server"><include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></TD>
									<td align="center">
										<table cellSpacing="0" cellPadding="0">
											<TBODY>
												<tr>
													<td style="BACKGROUND-COLOR: #34699e" height="60"><font style="FONT-WEIGHT: bold; FONT-SIZE: 17pt" color="#ffffff"><asp:label id="lblcreateglobalview" runat="server">Activate the product on the company</asp:label></font><br>
														<FONT style="FONT-SIZE: 8pt" color="#ffffff">
															<asp:label id="lblwayuwant" runat="server" key="acc_globalview_selectcustomer_lblwayuwant"
																Visible="False"></asp:label></FONT></td>
												</tr>
												<TR>
													<TD class="content" style="HEIGHT: 115px" vAlign="middle" width="100%" bgColor="#edf3f8"
														height="115"><asp:panel id="pnlInactivate" runat="server" Visible="False" height="1.19%" width="100%">
															<asp:datagrid id="dgrdInactivateProducts" runat="server" AutoGenerateColumns="False" CellPadding="1"
																BorderWidth="1px" AllowSorting="True" GridLines="Horizontal" Width="100%" DataKeyField="serialno">
																<SelectedItemStyle BackColor="#EDF3F8"></SelectedItemStyle>
																<ItemStyle CssClass="Content"></ItemStyle>
																<HeaderStyle Font-Bold="True" Height="20px" ForeColor="White" CssClass="Content" VerticalAlign="Top"
																	BackColor="#34699E"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="name"></asp:BoundColumn>
																	<asp:BoundColumn DataField="product"></asp:BoundColumn>
																	<asp:BoundColumn DataField="orderno"></asp:BoundColumn>
																	<asp:BoundColumn DataField="serialno"></asp:BoundColumn>
																	<asp:ButtonColumn Text="Activate" CommandName="Activate"></asp:ButtonColumn>
																</Columns>
															</asp:datagrid>
														</asp:panel><asp:panel id="pnlMsg" runat="server" Visible="False" height="40.42%" width="100%">
															<TABLE class="content" height="25%" width="100%" bgColor="#edf3f8" vAlign="middle">
																<TR>
																	<TD class="content" vAlign="middle" width="100%" bgColor="#34699e" height="25%">
																		<asp:Label id="lblcompany" runat="server" Width="100%" Height="100%" ForeColor="White" CssClass="Content"></asp:Label></TD>
																</TR>
																<TR>
																	<TD class="content" vAlign="middle" align="center" width="100%" bgColor="#edf3f8" height="100%"></TD>
																<TR>
																	<TD class="content" vAlign="middle" align="center" width="100%" bgColor="#edf3f8" height="100%">
																		<asp:Label id="lblMsg" runat="server" Width="100%" Height="100%" CssClass="Content"></asp:Label></TD>
																<TR>
																	<TD class="content" vAlign="middle" align="center" width="100%" bgColor="#edf3f8" height="100%"></TD>
																<TR>
																	<TD class="content" vAlign="middle" align="center" width="100%" bgColor="#edf3f8" height="100%">
																		<asp:LinkButton id="lnkGoBack" Runat="server">Go Back My Account</asp:LinkButton></TD>
																</TR>
															</TABLE>
														</asp:panel></TD>
									</td>
								</tr>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
			</TD></TR>
			<tr>
				<td id="bottombar" width="100%" height="2%" runat="server">
					<asp:LinkButton id="LinkButton1" style="DISPLAY:none" runat="server"></asp:LinkButton></td>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
