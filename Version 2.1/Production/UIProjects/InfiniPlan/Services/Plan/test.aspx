<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="test.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.test"%>
<%@ Register  TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Address Book</title>
		<LINK href="/Administration/Library/styleSheets/styles.css" type="text/css" rel="stylesheet">
		</LINK>
		<LINK href="/Administration/Library/styleSheets/main2.css" type="text/css" rel="stylesheet">
		</LINK>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table>
				<tr>
					<td>
						<iewc:tabstrip id="tsHoriz" style="FONT-WEIGHT: bold" runat="server" TabSelectedStyle="border:solid 1px black;border-bottom:none;background:white;padding-left:5px;padding-right:5px;"
							TabHoverStyle="color:blue" TabDefaultStyle="border:solid 1px black;background:#dddddd;padding-left:5px;padding-right:5px;"
							TargetID="mpHoriz" SepDefaultStyle="border-bottom:solid 1px #000000;" ForeColor="Desktop" Font-Size="Larger"
							BackColor="SteelBlue" Font-Names="Arial" Width="600px">
							<iewc:Tab Text="Add"></iewc:Tab>
							<iewc:TabSeparator></iewc:TabSeparator>
							<iewc:Tab Text="View"></iewc:Tab>
							<iewc:TabSeparator></iewc:TabSeparator>
							<iewc:TabSeparator DefaultStyle="width:100%;"></iewc:TabSeparator>
						</iewc:tabstrip>
						<iewc:multipage id="mpHoriz" runat="server" Width="100%" Height="100%" Font-Size="Larger">
							<iewc:PageView>
								<asp:panel id="plnMain" runat="server" Width="100%" cssclass="text-outerborder-light_blue_background"
									Visible="true">
									<TABLE>
										<TR>
											<TD class="page-section-text" style="HEIGHT: 15px" vAlign="top" align="right" width="100%"
												bgColor="#e2effe" colSpan="2">
												<asp:Label id="Label1" Width="592px" Font-Size="Small" ForeColor="#0000C0" Runat="server" Text="View"
													Font-Bold="True">::..:Add Address</asp:Label><BR>
											</TD>
										</TR>
									</TABLE>
									<TABLE align="center">
										<TR>
										</TR>
										<TR>
											<TD style="WIDTH: 130px" align="center"><BR> <!-- #include virtual="../../include/span.htm" --></TD>
										</TR>
										<TR>
											<TD><BR>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblName" Width="56px" cssclass="frm-section-text" Runat="server" Text="Name">Name</asp:Label></TD>
											<TD class="textarea">
												<asp:TextBox id="txtName" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
										</TR>
										<TR>
											<TD style="WIDTH: 49px; HEIGHT: 20px">
												<asp:Label id="lblEmail" Width="56px" cssclass="frm-section-text" Runat="server" Text="E-Mail">E-Mail</asp:Label></TD>
											<TD style="HEIGHT: 20px">
												<asp:TextBox id="txtEmail" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblPhone" Width="56px" cssclass="frm-section-text" Runat="server" Text="Phone">Phone</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtPhone" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblCity" Width="56px" cssclass="frm-section-text" Runat="server" Text="City">City</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtCity" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblStreet" Width="56px" cssclass="frm-section-text" Runat="server" Text="Street">Street</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtStreet" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblStatus" Width="56px" cssclass="frm-section-text" Runat="server" Text="Status"></asp:Label></TD>
											<TD>
												<asp:TextBox id="txtStatus" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 49px">
												<asp:Label id="lblWork" Width="56px" cssclass="frm-section-text" Runat="server" Text="Work"></asp:Label></TD>
											<TD class="text">
												<asp:TextBox id="txtWork" runat="server" cssclass="text-outerborder-light_blue_background"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2"><BR>
												<asp:Button id="btnUpdate" runat="server" Width="51px" Text="Update" CssClass="frm-button"></asp:Button>
												<asp:Button id="btnSave" runat="server" Text="Save" CssClass="frm-button"></asp:Button>
												<asp:Button id="btnExit" runat="server" Width="44px" Visible="false" Text="Exit" CssClass="frm-button"></asp:Button><BR>
												<asp:Label id="chkID" runat="server" Visible="False"></asp:Label><BR>
											</TD>
										</TR>
										<TR>
										</TR>
									</TABLE>
								</asp:panel>
							</iewc:PageView>
							<iewc:PageView>
								<asp:panel id="Panel1" runat="server" Width="70%" cssclass="text-outerborder-light_blue_background"
									Visible="true" height="50%">
									<TABLE align="right">
										<TR>
											<TD></TD>
										</TR>
										<TR>
											<TD class="page-section-text" style="HEIGHT: 15px" vAlign="top" align="right" width="100%"
												bgColor="#e2effe" colSpan="2">
												<asp:Label id="Label2" Width="592px" Font-Size="Small" ForeColor="#0000C0" Runat="server" Text="View"
													Font-Bold="True">::..:View Address</asp:Label><BR>
											</TD>
										<TR>
											<TD><BR>
											</TD>
										</TR>
									</TABLE>
									<TABLE align="center">
										<TR>
											<TD width="3%"></TD>
											<BR>
											<BR>
											<BR>
											<TD borderColor="#336699" width="60%">
												<asp:datagrid id="dgShowEmailAddress" runat="server" Width="584px" BorderStyle="Solid" BorderColor="#336699"
													PageSize="20" AutoGenerateColumns="False" AllowPaging="True">
													<SelectedItemStyle CssClass="GridSelectedRow"></SelectedItemStyle>
													<EditItemStyle HorizontalAlign="Left"></EditItemStyle>
													<AlternatingItemStyle HorizontalAlign="Left" CssClass="GridAlternatingRow"></AlternatingItemStyle>
													<ItemStyle Font-Size="12pt" CssClass="GridItemCell"></ItemStyle>
													<HeaderStyle Font-Size="12pt" CssClass="GridColumnHeading"></HeaderStyle>
													<Columns>
														<asp:BoundColumn HeaderText=".">
															<HeaderStyle HorizontalAlign="Left" ForeColor="#6699FF" Width="12px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="ID" HeaderText="ID">
															<HeaderStyle HorizontalAlign="Left" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Name" HeaderText="Name">
															<HeaderStyle Width="15%" HorizontalAlign="Left" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="EmailAddress" HeaderText="EmailAddress">
															<HeaderStyle HorizontalAlign="Left" Width="23%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Phone" HeaderText="Phone">
															<HeaderStyle HorizontalAlign="Left" Width="16%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="City" HeaderText="City">
															<HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Street" HeaderText="Street">
															<HeaderStyle HorizontalAlign="Left" Width="15%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Status" HeaderText="Status">
															<HeaderStyle HorizontalAlign="Left" Width="13%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Work" HeaderText="Work">
															<HeaderStyle HorizontalAlign="Left" Width="23%" CssClass="GridColumnHeading"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<ItemTemplate>
																<table class="table">
																	<tr>
																		<td class="td">
																			<input type="hidden" id="HInput" runat="server" NAME="HInput" />
																			<asp:ImageButton ID="EditMail" runat="server" Font-Size="12" ImageUrl="/administration/images/bmpArrows.gif"
																				Height="20" CommandName="SELECT" AlternateText="Click here to Edit"></asp:ImageButton>
																		</td>
																	</tr>
																</table>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle VerticalAlign="Bottom" Visible="False" Font-Size="X-Small" Font-Names="Verdana"
														Font-Bold="True" HorizontalAlign="Left" ForeColor="#336699" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
											<TD width="1%"><BR>
												<BR>
											</TD>
										</TR>
									</TABLE>
									<BR>
									<BR>
								</asp:panel>
							</iewc:PageView>
						</iewc:multipage></td>
				</tr>
			</table>
		</form>
		<script>

function EmailFields()
{

}


		</script>
	</body>
</HTML>
