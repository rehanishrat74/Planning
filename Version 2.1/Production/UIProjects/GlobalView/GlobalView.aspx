<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GlobalView.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.GlobalViewUI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Global View</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<STYLE>A:link { COLOR: #00008b; TEXT-DECORATION: none }
	A:visited { COLOR: #00008b; TEXT-DECORATION: none }
	A:active { COLOR: #ff0000; TEXT-DECORATION: underline }
	A:hover { COLOR: #ff0000; TEXT-DECORATION: underline }
		</STYLE>
	</HEAD>
	<body id="bdyGlobalView" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		runat="server">
		<FORM id="frmGlobalView" name="frmGlobalView" action="default.aspx" method="post" encType="multipart/form-data"
			runat="server">
			<input id="hCriteria" type="hidden" value="3" name="hCriteria" runat="server"> <input id="hSort" type="hidden" value="CompName" name="hSort" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%">
				<tbody>
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<TR vAlign="top">
						<TD id="menuarea" vAlign="top" align="left" runat="server"></TD>
						<TD id="contentarea" style="PADDING-LEFT: 0px" vAlign="top" width="100%">
							<table class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td vAlign="top" width="80%"><strong><font size="6">Global View</font></strong><br>
										<asp:linkbutton id="btnAddaCompany" style="FONT-WEIGHT: bold" Font-Underline="True" ForeColor="Blue"
											Runat="server" Text="Click here to add another company registered at Accounts Centre." type="button"></asp:linkbutton><br>
										<font color="red">
											<asp:literal id="litFHMessage" runat="server" Text="Error: Temporarily Formations House's Companies information is not available.<BR>"></asp:literal></font><br>
										<!-- #include virtual="..\Include\span.htm" -->
										<!-- CODE COMMENT TWO-->
										<table class="content" cellSpacing="0" cellPadding="0" width="100%">
											<TR width="100%">
												<TD style="HEIGHT: 12px" vAlign="top" width="11%"><asp:literal id="litSearchComp" Runat="server" Text="Search Company"></asp:literal></TD>
												<td width="50%"><asp:textbox id="txtSearch" runat="server" Width="95%" cssclass="content"></asp:textbox></td>
												<td align="left">
													<asp:ImageButton id="btnGo" runat="server" ImageUrl="/images/GO.gif"></asp:ImageButton></td>
											</TR>
											<tr vAlign="top">
												<td vAlign="top" width="100%" height="100%" colSpan="3">
													<div style="OVERFLOW: scroll" height="50px"><asp:datagrid id="dgridSummaryInformation" runat="server" width="100%" GridLines="Horizontal"
															AutoGenerateColumns="False" AllowSorting="True" BorderWidth="1px" CellPadding="1">
															<SelectedItemStyle BackColor="#EDF3F8"></SelectedItemStyle>
															<ItemStyle CssClass="Content"></ItemStyle>
															<HeaderStyle Font-Bold="True" Height="20px" ForeColor="White" CssClass="Content" VerticalAlign="Top"
																BackColor="#34699E"></HeaderStyle>
															<Columns>
																<asp:ButtonColumn Text="Company Name" DataTextField="CompName" SortExpression="CompName" HeaderText="Company Name"
																	CommandName="SELECT">
																	<ItemStyle ForeColor="Blue"></ItemStyle>
																</asp:ButtonColumn>
																<asp:BoundColumn DataField="IncDate" SortExpression="IncDate" HeaderText="Incorporation Date" DataFormatString="{0:d}">
																	<ItemStyle Width="100px"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="eFilingDate" SortExpression="eFilingDate" HeaderText="Accounts Reference Date"
																	DataFormatString="{0:d}">
																	<ItemStyle Width="100px"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Status" SortExpression="Status" HeaderText="Annual Accounts Status">
																	<ItemStyle Font-Bold="True" Width="100px"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn SortExpression="DissolvedDate, Dormant" HeaderText="Company Status">
																	<ItemStyle Font-Bold="True" Width="100px"></ItemStyle>
																</asp:BoundColumn>
																<asp:ButtonColumn Visible="False" Text="Login" SortExpression="MemberCustomerID" HeaderText="Action"
																	CommandName="SELECT">
																	<ItemStyle ForeColor="Blue"></ItemStyle>
																</asp:ButtonColumn>
																<asp:BoundColumn Visible="False" DataField="cart_customer_uid" HeaderText="cart_customer_uid"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="GVStatus" HeaderText="GVStatus"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="CompEmail" HeaderText="CompEmail"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="CompRegNo" HeaderText="CompRegNo"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="MemberCustomerID" HeaderText="MemberCustomerID"></asp:BoundColumn>
																<asp:BoundColumn Visible="False" DataField="CompName" SortExpression="CompName" HeaderText="CompanyName"></asp:BoundColumn>
															</Columns>
														</asp:datagrid></div>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<!--CODE COMMENT THREE-->
								<tr>
									<td height="10"></td>
								</tr>
							</table>
						</TD>
					</TR>
				</tbody>
			</table>
			<table width="100%">
				<tr vAlign="bottom" width="100%">
					<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
