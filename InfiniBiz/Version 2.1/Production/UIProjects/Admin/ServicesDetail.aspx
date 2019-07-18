<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ServicesDetail.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServicesAdmin2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Welcome To Accountscentre Administration</TITLE>
		<meta name="cbignore" content="1">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!--	<!--#INCLUDE VIRTUAL="/include/header.htm"-->
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<table class="tx1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr vAlign="top">
				<td style="HEIGHT: 3px" bgColor="#d3d3d3" colSpan="2"></td>
				<td width="3%" background="images/line.jpg" rowSpan="3"><IMG height="6" src="line.jpg" width="61"></td>
			</tr>
			<tr vAlign="top">
				<td style="WIDTH: 188px; HEIGHT: 122px" width="188"></td>
				<td style="HEIGHT: 122px" vAlign="top" align="left" width="95%">
					<TABLE class="tx1" id="Table2" style="WIDTH: 721px; HEIGHT: 318px" height="318" cellSpacing="0"
						cellPadding="0" width="721" border="0">
						<TR>
							<TD vAlign="top" align="center">
								<form id="Form1" action="" runat="server">
									<TABLE class="tx1" id="Table3" style="WIDTH: 597px; HEIGHT: 220px" cellSpacing="2" cellPadding="0"
										width="597" border="0">
										<TR>
											<TD style="HEIGHT: 53px" align="center"><STRONG>AccountsCenter Administration.</STRONG></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 8px" vAlign="middle" align="center"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 78px" vAlign="top" align="left"><asp:datagrid id="DataGrid1" runat="server" Font-Names="Verdana" GridLines="Vertical" CellPadding="3"
													BackColor="White" BorderWidth="1px" BorderStyle="None" BorderColor="#999999" AutoGenerateColumns="False" Width="640px" Height="120px">
													<SelectedItemStyle Font-Size="X-Small" Font-Bold="True" ForeColor="White" BackColor="#008A8C"></SelectedItemStyle>
													<EditItemStyle Font-Size="X-Small" ForeColor="White" BackColor="Navy"></EditItemStyle>
													<AlternatingItemStyle Font-Size="X-Small" BackColor="Gainsboro"></AlternatingItemStyle>
													<ItemStyle Font-Size="X-Small" ForeColor="Black" BackColor="#EEEEEE"></ItemStyle>
													<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#000084"></HeaderStyle>
													<FooterStyle ForeColor="Black" BackColor="#CCCCCC"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Name" HeaderText="Service Name">
															<HeaderStyle Width="25%"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Description" HeaderText="Service Description">
															<HeaderStyle Width="50%"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn ItemStyle-ForeColor="#0033ff">
															<HeaderStyle Width="25%"></HeaderStyle>
															<ItemStyle Font-Size="X-Small" Font-Bold="True" Wrap="False" ForeColor="Yellow"></ItemStyle>
															<ItemTemplate>
																<a href='<%# GetUrl(container.dataItem("ID")) %>'   ID="link" onmouseover="this.style.cursor='hand'">
																	<%# GetStatus(container.dataItem("ID")) %>
																</a>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" ForeColor="Black" BackColor="#999999" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 33px" align="right"><asp:hyperlink id="HyperLink1" runat="server" Width="161px" Height="8px" Font-Underline="True"
													ForeColor="Navy" NavigateUrl="ServicesAdmin.aspx">Process Another Customer</asp:hyperlink></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 25px" vAlign="top" align="right"></TD>
										</TR>
									</TABLE>
								</form>
							</TD>
						</TR>
					</TABLE>
				</td>
			</tr>
		</table>
	</BODY>
</HTML>
