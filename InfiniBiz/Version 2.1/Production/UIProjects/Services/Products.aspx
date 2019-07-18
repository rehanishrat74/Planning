<%@ outputcache Location="None" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Products.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Products" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Products</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" ID="Body1">
		<form id="Form2" method="post" runat="server">
			<table id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0"
				class="CONTENT">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" runat="server" width="95%" style="HEIGHT: 120px">
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD id="servicearea" runat="server" vAlign="top" align="center" width="80%">
									<asp:panel id="pnlPaymentMethod" runat="server" Width="600px" Height="80px">
										<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="#cecfce">
													<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
														<TR>
															<TD class="acc_header_backgrounds">&nbsp;Packages Plans</TD>
														</TR>
														<TR>
															<TD>
																<asp:datagrid id="grdPackages" runat="server" Width="590px" AutoGenerateColumns="False" BorderStyle="None"
																	BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3">
																	<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																	<ItemStyle Font-Size="XX-Small"></ItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ProductName" HeaderText="Package Name">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Description" HeaderText="Description">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
														<TR>
															<TD>&nbsp;
															</TD>
														</TR>
														<TR>
															<TD class="acc_header_backgrounds">&nbsp;Individual&nbsp;Products</TD>
														</TR>
														<TR>
															<TD>
																<asp:datagrid id="grdProducts" runat="server" Width="590px" AutoGenerateColumns="False" BorderStyle="None"
																	BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3">
																	<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																	<ItemStyle Font-Size="XX-Small"></ItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Description" HeaderText="Description">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																			<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="frm-section-text"></HeaderStyle>
																			<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																</asp:datagrid></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td id="rightbar" width="5%" runat="server" style="HEIGHT: 120px"></td>
				</tr>
				<tr>
					<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
