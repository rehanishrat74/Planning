<%@ OutputCache Location="None" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Page Language="vb" autoeventwireup="false" codebehind="NewCustomer.aspx.vb" Inherits="accounts.infinibiz.Web.NewCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Sign Up</title>
		<meta content="1" name="cbignore">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form1" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<!--***************************************************************-->
					<tr vAlign="top">
						<!-- BEGIN MAIN BODY CONTENTS -->
						<TD id="menuarea" vAlign="top" align="left" width="5%" runat="server"></TD>
						<td height="98%">
							<table class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tbody>
									<tr>
										<td vAlign="top" align="right" width="99%"><font color="#6699cc" size="2"><BR>
												::..:
												<asp:label id="lblaccregistration" Runat="server" key="acc_account_newcustomer_lblaccregistration"></asp:label>
												&nbsp;<BR>
											</font>
										</td>
									</tr>
									<tr>
										<td style="WIDTH: 604px" vAlign="top" width="604" height="0">
											<table class="CONTENT" width="100%" align="right" border="0">
												<tr>
													<td vAlign="top" align="center"><asp:label id="lblErrorInfoMsg" Font-Bold="True" Width="100%" Runat="server"></asp:label></td>
												</tr>
												<tr>
													<td vAlign="top">
														<P><BR>
															<asp:label id="lblpara" Runat="server" key="acc_account_newcustomer_lblpara"></asp:label>
															<A href="/Services/" runat="server" key="acc_clickhere" ID="A1"></A>&nbsp;&nbsp;&nbsp;&nbsp;
														</P>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td style="WIDTH: 604px" vAlign="top" align="center">
											<!--BEGIN ERROR PANEL -->
											<table class="CONTENT" cellSpacing="1" cellPadding="2" width="100%" bgColor="#ffffff" border="0">
												<tbody>
													<tr>
														<td class="error" bgColor="white"></td>
													</tr>
												</tbody>
											</table>
											<!--END ERROR PANEL -->
											<!--BEGIN INFORMATION PANEL --><asp:panel id="pnlInformation" runat="server" Width="601px">
												<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0"> <!-- begin dark grey section title -->
																<TR>
																	<TD class="acc_header_backgrounds" id="Td1" runat="server" key="acc_members_updateservices_ttinformation"
																		NAME="Td1"></TD>
																</TR> <!-- end dark grey section title -->
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-light_blue_background" style="BORDER-COLLAPSE: collapse"
																			cellSpacing="1" cellPadding="2" width="100%" bgColor="#f6f5f5" border="0">
																			<TR>
																				<TD class="info" width="100%"><!-- #include virtual="/include/span.htm" --></TD>
																			</TR>
																			<TR>
																				<TD class="info">&nbsp;
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!--END INFORMATION PANEL -->
											<!--BEGIN FORM PANEL--><asp:panel id="pnlCustomerDetail" runat="server" Width="601px" Height="228px">
												<TABLE class="CONTENT" cellSpacing="2" cellPadding="1" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="Td2" bgColor="#c5d8e7" runat="server" key="acc_account_newcustomer_ttcustomerdetail"
																		NAME="Td2"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-white_background" cellSpacing="1" cellPadding="2" width="100%"
																			bgColor="#f6f5f5" border="0">
																			<TR>
																				<TD vAlign="top" width="21%"></TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblinvoicename1" runat="server" key="acc_account_newcustomer_lblinvoicename"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblInvoiceName" runat="server" Width="384px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top">
																					<DIV align="right">
																						<asp:Label id="lblContactName1" runat="server" key="acc_members_profile_lblcontactname"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD>&nbsp;
																				</TD>
																				<TD class="error">&nbsp;
																				</TD>
																				<TD>
																					<asp:Label id="lblContactName" runat="server" Width="380px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblstreet1" runat="server" key="acc_members_profile_lblstreet"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblStreet" runat="server" Width="381px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblcity" runat="server" key="acc_members_profile_lblcity"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblTown" runat="server" Width="382px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblstate1" runat="server" key="acc_members_profile_lblstate"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblState" runat="server" Width="381px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblpostcode1" runat="server" key="acc_members_profile_lblpostcode"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblPostCode" runat="server" Width="383px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblcountry1" runat="server" key="acc_members_profile_lblcountry"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblCountry" runat="server" Width="381px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lbltelephone1" runat="server" key="acc_members_profile_lbltelephone"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblPh" runat="server" Width="382px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblfax1" runat="server" key="acc_members_profile_lblfax"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblFax" runat="server" Width="385px"></asp:Label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="right">
																						<asp:Label id="lblemail1" runat="server" key="acc_lblemail"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">
																					<asp:Label id="lblEmail" runat="server" Width="383px"></asp:Label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlCustomerRegistration" runat="server" Width="600px" Height="59px">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="Td3" style="HEIGHT: 15px" bgColor="#c5d8e7" runat="server"
																		key="acc_account_newcustomer_ttcustomerregistration" NAME="Td3"></TD>
																</TR>
																<TR>
																	<TD align="left"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background" cellSpacing="1" cellPadding="2" width="100%"
																			bgColor="white" border="0">
																			<TR>
																				<TD vAlign="top" width="21%"></TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" height="17">
																					<DIV align="left">
																						<asp:Label id="lblinvoicename2" runat="server" key="acc_account_newcustomer_lblinvoicename"></asp:Label></DIV>
																				</TD>
																				<TD height="17">&nbsp;
																				</TD>
																				<TD class="error" height="17">*</TD>
																				<TD height="17">&nbsp;
																					<asp:textbox id="txtInvoiceName" runat="server" CssClass="MTBOX" MaxLength="55"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<DIV align="left">
																							<asp:Label id="lblcontactname2" runat="server" key="acc_members_profile_lblcontactname"></asp:Label></DIV>
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtContactName" runat="server" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
																			</TR>
																			<TR id="trPassword" runat="server">
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblpassword" runat="server" key="acc_lblpassword"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtPassword" runat="server" CssClass="MTBOX" MaxLength="16" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR id="trPasswordConfirm" runat="server">
																				<TD vAlign="top" width="21%">
																					<asp:Label id="lblconfirmpassword" runat="server" key="acc_lblconfirmpassword"></asp:Label></TD>
																				<TD width="2%"></TD>
																				<TD class="error" width="2%">*</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtConfirmPassword" runat="server" CssClass="MTBOX" MaxLength="16" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblstreet2" runat="server" key="acc_members_profile_lblstreet"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtStreet" runat="server" CssClass="MTBOX" MaxLength="60"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblcity2" runat="server" key="acc_members_profile_lblcity"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtTown" runat="server" CssClass="MTBOX" MaxLength="30"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblstatecounty" runat="server" key="acc_account_newcustomer_lblstate&amp;county"></asp:Label>:
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtState" runat="server" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblpostcode2" runat="server" key="acc_members_profile_lblpostcode"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtPostCode" runat="server" CssClass="MTBOX" MaxLength="30"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="HEIGHT: 17px" vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblcountry2" runat="server" key="acc_members_profile_lblcountry"></asp:Label></DIV>
																				</TD>
																				<TD style="HEIGHT: 17px" width="2%">&nbsp;
																				</TD>
																				<TD class="error" style="HEIGHT: 17px" width="2%">*
																				</TD>
																				<TD style="HEIGHT: 17px" width="75%">&nbsp;
																					<asp:dropdownlist id="ddlCountry" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lbltelephone" runat="server" key="acc_members_profile_lbltelephone"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtTelephone" runat="server" CssClass="MTBOX" MaxLength="80"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblfax2" runat="server" key="acc_members_profile_lblfax"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">&nbsp;
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtFax" runat="server" CssClass="MTBOX" MaxLength="80"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblemail2" runat="server" key="acc_lblemail"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtEmailAddress" runat="server" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">
																						<asp:Label id="lblnotes" runat="server" key="acc_members_profile_lblnotes"></asp:Label></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">&nbsp;
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtNotes" runat="server" CssClass="MTBOX" MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left"></DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%"></TD>
																				<TD width="75%">&nbsp;
																					<asp:button id="btnCreateAccount" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_btnnext" Cssclass="MBUTTON"></asp:button></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!-- Panel Payment Method ------><asp:panel id="pnlPaymentMethod" runat="server" Width="600px" Height="80px">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
																<% if Me.grdPackages.Visible then %>
																<TR>
																	<TD class="acc_header_backgrounds" runat="server" key="acc_members_updateservices_ttpackagesplans"
																		ID="Td4" NAME="Td4"></TD>
																</TR>
																<% end if %>
																<TR>
																	<TD>
																		<asp:datagrid id="grdPackages" runat="server" Width="100%" CssClass="text-outerborder-White_background"
																			AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkSelect" AutoPostBack="false" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Package Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="40%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductTax" HeaderText="ProductTax"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<% if me.grdProducts.visible %>
																<TR>
																	<TD class="acc_header_backgrounds" runat="server" key="acc_members_updateservices_ttindividualproducts"
																		ID="Td5" NAME="Td5"></TD>
																</TR>
																<% end if %>
																<TR>
																	<TD>
																		<asp:datagrid id="grdProducts" runat="server" Width="100%" CssClass="text-outerborder-White_background"
																			AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3"
																			Height="100%">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkSelect1" AutoPostBack="false" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="40%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductTax" HeaderText="ProductTax"></asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
																				</asp:TemplateColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD class="acc_header_backgrounds" runat="server" key="acc_members_updateservices_ttpaymentmethod"
																		ID="Td6" NAME="Td6"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background" cellSpacing="2" cellPadding="0" width="100%"
																			bgColor="#f6f5f5" border="0">
																			<TBODY>
																				<TR>
																					<TD width="205" style="WIDTH: 205px">&nbsp;</TD>
																					<TD width="289">&nbsp;</TD>
																					<TD>&nbsp;</TD>
																					<TD></TD>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD width="205" style="WIDTH: 205px">&nbsp;
																						<asp:Label id="lblpaymentmode" runat="server" key="acc_members_updateservices_lblpaymentmode"></asp:Label>:</TD>
																					<TD width="289">
																						<asp:radiobuttonlist id="rbtPaymentMethod" runat="server" CssClass="MTBOX">
																							<asp:ListItem Value="Credit Card" Selected="True">Credit 
                                          Card</asp:ListItem>
																							<asp:ListItem Value="Cheque Or Bank Transfer">Cheque 
                                          Or Bank Transfer</asp:ListItem>
																						</asp:radiobuttonlist></TD>
																	</TD>
																	<TD>&nbsp;</TD>
																	<TD></TD>
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD width="205" style="WIDTH: 205px">&nbsp;<asp:Label id="lbldeliveryaddress" runat="server" key="acc_members_updateservices_lbldeliveryaddress"></asp:Label>
																		:</TD>
																	<TD width="289">
																		<asp:textbox id="txtDeliveryAddress" runat="server" Width="262px" Height="74px" CssClass="MTBOX"
																			MaxLength="150" TextMode="MultiLine"></asp:textbox></TD>
																	<TD>&nbsp;</TD>
																	<TD></TD>
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD width="205" style="WIDTH: 205px">&nbsp;</TD>
																	<TD width="289">&nbsp;</TD>
																	<TD>&nbsp;</TD>
																	<TD></TD>
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD width="205" style="WIDTH: 205px">&nbsp;</TD>
																	<TD width="289">
																		<asp:button id="btnPaymentMethod" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																			runat="server" Font-Bold="True" Cssclass="MBUTTON" key="acc_btnnext"></asp:button>
																	<TD>&nbsp;</TD>
																	<TD></TD>
																	<TD>&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
										</td>
									</tr>
								</tbody>
							</table>
							</asp:panel><asp:panel id="pnlBankTransfer" runat="server" Width="600px" Height="146px">
								<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD bgColor="#cecfce">
											<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
												<TR>
													<TD class="acc_header_backgrounds" id="Td7" bgColor="#c5d8e7" runat="server" key="acc_members_updateservices_ttbanktransfermethod"
														NAME="Td7"></TD>
												</TR>
												<TR>
													<TD>
														<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
															cellSpacing="1" cellPadding="2" width="100%" bgColor="#f6f5f5" border="0">
															<TR>
																<TD vAlign="top" width="173" height="14"></TD>
																<TD width="9" height="14">&nbsp;
																</TD>
																<TD width="252" height="14"></TD>
																<TD width="109" height="14"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblbankname" runat="server" key="acc_members_updateservices_lblbankname"></asp:Label></TD>
																<TD class="error" width="9"></TD>
																<TD width="252">
																	<asp:textbox id="txtBankName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblchequeno" runat="server" key="acc_members_updateservices_lblchequeno"></asp:Label></TD>
																<TD class="error" width="9"></TD>
																<TD width="252">
																	<asp:textbox id="txtChequeNo" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblsortcode" runat="server" key="acc_members_updateservices_lblsortcode"></asp:Label></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:textbox id="txtSortCode" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lbltransactionrefno" runat="server" key="acc_members_updateservices_lbltransactionrefno"></asp:Label></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:textbox id="txtTransactionRefNo" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252"></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:button id="btnBankTransfer" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																		runat="server" key="acc_btnnext" Cssclass="MBUTTON"></asp:button></TD>
																<TD width="109"></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlCrCardInfo" runat="server" Width="600px" Height="146px">
								<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
									<TR>
										<TD bgColor="#cecfce">
											<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
												<TR>
													<TD class="acc_header_backgrounds" id="Td8" bgColor="#c5d8e7" runat="server" key="acc_members_updateservices_ttcreditcardinformation"
														NAME="Td8"></TD>
												</TR>
												<TR>
													<TD>
														<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
															cellSpacing="0" cellPadding="0" width="100%" bgColor="white" border="0">
															<TR>
																<TD vAlign="top" width="173" height="14"></TD>
																<TD width="9" height="14">&nbsp;
																</TD>
																<TD width="252" height="14"></TD>
																<TD width="109" height="14"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblselectcard" runat="server" key="acc_members_updateservices_lblselectcard"></asp:Label></TD>
																<TD class="error" width="9">*</TD>
																<TD width="252">
																	<asp:dropdownlist id="ddlCardNames" runat="server" Width="257px" CssClass="MTBOX">
																		<asp:ListItem Value="Visa Card" Selected="True">Visa Card</asp:ListItem>
																		<asp:ListItem Value="Master Card / Euro Card">Master Card / Euro Card</asp:ListItem>
																		<asp:ListItem Value="Diners Club / Carte Balanche">Diners Club / Carte Balanche</asp:ListItem>
																		<asp:ListItem Value="Discover">Discover</asp:ListItem>
																		<asp:ListItem Value="enRoute">enRoute</asp:ListItem>
																		<asp:ListItem Value="JCB">JCB</asp:ListItem>
																		<asp:ListItem Value="AMEX Card">AMEX Card</asp:ListItem>
																		<asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
																		<asp:ListItem Value="Switch Card">Switch Card</asp:ListItem>
																	</asp:dropdownlist></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblcardholdername2" runat="server" key="acc_members_updateservices_lblcardholdername"></asp:Label></TD>
																<TD class="error" width="9">*</TD>
																<TD width="252">
																	<asp:textbox id="txtCardHolderName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblcardnumber2" runat="server" key="acc_members_updateservices_lblcardnumber"></asp:Label></TD>
																<TD class="error" width="9">*</TD>
																<TD width="252">
																	<asp:textbox id="txtCardNumber" runat="server" Width="258px" CssClass="MTBOX" MaxLength="20"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD style="HEIGHT: 18px" vAlign="top" width="173">
																	<asp:Label id="lblexpirydate2" runat="server" key="acc_members_updateservices_lblexpirydate"></asp:Label></TD>
																<TD class="error" style="HEIGHT: 18px" width="9">*</TD>
																<TD style="HEIGHT: 18px" width="252">
																	<asp:dropdownlist id="ddlMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
																	<asp:dropdownlist id="ddlYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																<TD style="HEIGHT: 18px" width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<P>&nbsp;</P>
																	<P>
																		<asp:Label id="lblcardaddress2" runat="server" key="acc_members_updateservices_lblcardaddress"></asp:Label></P>
																</TD>
																<TD class="error" width="9">*</TD>
																<TD width="252">
																	<asp:textbox id="txtCardAddress" runat="server" Width="257px" Height="73px" CssClass="MTBOX"
																		MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173">
																	<asp:Label id="lblsecuritycode2" runat="server" key="acc_members_updateservices_lblsecuritycode"></asp:Label></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:textbox id="txtSecurityCode" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252"></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:button id="btnCrCardInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																		runat="server" key="acc_btnnext" Cssclass="MBUTTON"></asp:button></TD>
																<TD width="109"></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlAmexCardInfo" runat="server" Width="600px" Height="84px">
								<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
									<TR>
										<TD>
											<TABLE class="CONTENT" width="100%" border="0">
												<TR>
													<TD class="acc_header_backgrounds" id="tdCardHeading" runat="server">&nbsp;AMEX 
														Card Information
													</TD>
												</TR>
												<TR>
													<TD>
														<TABLE class="text-outerborder-white_background" cellSpacing="1" cellPadding="2" width="100%"
															border="0">
															<TR>
																<TD align="right" width="173" height="14"></TD>
																<TD width="9" height="14">&nbsp;
																</TD>
																<TD width="252" height="14"></TD>
																<TD width="109" height="14"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173">
																	<asp:Label id="lblcardholder_name" runat="server" key="acc_members_updateservices_lblcardholdername"></asp:Label>:
																</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:label id="lblCardName" runat="server" Width="285px"></asp:label></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173">
																	<asp:Label id="lblcard_number" runat="server" key="acc_members_updateservices_lblcardnumber"></asp:Label>:
																</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:label id="lblCardNumber" runat="server" Width="278px"></asp:label></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173">
																	<asp:Label id="lblexpiry_date" runat="server" key="acc_members_updateservices_lblexpirydate"></asp:Label>:
																</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:label id="lblExpiryDate" runat="server" Width="278px"></asp:label></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173">
																	<asp:Label id="lblcard_address" runat="server" key="acc_members_updateservices_lblcardaddress"></asp:Label>:</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:label id="lblCardAddress" runat="server" Width="278px"></asp:label></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173">
																	<asp:Label id="lblsecurity_code" runat="server" key="acc_members_updateservices_lblsecuritycode"></asp:Label>:
																</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:label id="lblSecurityCode" runat="server" Width="278px"></asp:label></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	align="right" width="173"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																	borderColor="#7baee3" width="173"><STRONG>
																		<asp:Label id="lblchoosedaterange" runat="server" key="acc_members_updateservices_lblchoosedaterange"></asp:Label></STRONG></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR id="trStartDate" runat="server">
																<TD id="tdStartDate" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																	vAlign="top" borderColor="#7baee3" width="173" runat="server">
																	<asp:Label id="lblstartdate" runat="server" key="acc_members_updateservices_lblstartdate"></asp:Label></TD>
																<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																	borderColor="#7baee3" width="9">*</TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																	borderColor="#7baee3" width="252">
																	<asp:dropdownlist id="ddlAmexSDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
																	<asp:dropdownlist id="ddlAmexSDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																	borderColor="#7baee3" width="109"></TD>
															</TR>
															<TR id="trIssueNumber" runat="server">
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																	borderColor="#7baee3" width="173">
																	<asp:Label id="lblenddate" runat="server" key="acc_members_updateservices_lblenddate"></asp:Label></TD>
																<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																	borderColor="#7baee3" width="9"></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="252">
																	<asp:TextBox id="txtIssueNumber" runat="server"></asp:TextBox></TD>
																<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																	width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252"></TD>
																<TD width="109"></TD>
															</TR>
															<TR>
																<TD vAlign="top" width="173"></TD>
																<TD width="9"></TD>
																<TD width="252">
																	<asp:button id="btnAmexInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																		runat="server" key="acc_btnnext" cssclass="acc_mbutton"></asp:button></TD>
																<TD width="109"></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</asp:panel>
							<!--END FORM PANEL-->
							<!--****************************************************************--><asp:button id="btnRetry" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
								runat="server" key="acc_btnretrypayment" Cssclass="MBUTTON" Visible="False" CommandName="NO"></asp:button>&nbsp;
							<asp:button id="btnFinish" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
								runat="server" key="acc_btnfinish" Cssclass="MBUTTON" Visible="False"></asp:button><asp:textbox id="txtHiddenCustomerID" runat="server" Text="" Visible="False"></asp:textbox><asp:textbox id="txtHiddenOrderID" runat="server" Text="" Visible="False"></asp:textbox></td>
					</tr>
				</tbody>
			</table>
			</TD></TD></TR>
			<tr>
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
			</tr>
			</TBODY></TABLE>
		</form>
		<script>
		//this modification is done by Yousuf
	var structureCell;
	function ShowHide( ref ) 
	{ 			  
		var structure  = document.getElementById(ref);
		var structureHR  = document.getElementById(ref+'hr');
		if( ref.indexOf('pack')==0)
			structureCell= document.getElementById('grdPackages__ctl2_packcell');
		else
			structureCell= document.getElementById('grdProducts__ctl2_procell');
		
		if(structureCell==null)
		{
		if( ref.indexOf('pack')==0)
			structureCell= document.getElementById('grdPackages__ctl3_packcell');
		else
			structureCell= document.getElementById('grdProducts__ctl3_procell');
		}
			
		if (structure.style.display =='none') 
		{ 
			structure.style.display =''; 
			structureCell.width = "45%";
			structureHR.innerText = '[Hide]';
		} 
		else 
		{ 
			structure.style.display ='none'; 
			structureCell.width = "10%";
			structureHR.innerText = '[Show]';
		} 
	} 
	//end modification
		
	function Checking(name,value)
	{
		var prodList=GetProducList(value);
		var chkBoxes,myChkBox,myChkBoxName;
		var index;		
		
		var selectedCheckBoxes=document.getElementsByName(name);		
		var selectedCheckBox=selectedCheckBoxes[0];	
		
		
		for(index=0;index<prodList.length;index++)
		{			
			myChkBoxName=GetCheckBoxName(prodList[index]);	
		
			if(myChkBoxName!=''){
				chkBoxes=document.getElementsByName(myChkBoxName);
				
				myChkBox=chkBoxes[0];
				if(myChkBoxName!=name){
					if (selectedCheckBox.checked){
						myChkBox.disabled=true;
						
					}else
					{
						myChkBox.disabled=false;				
					}
				}
			}
		}			
	}
	
	function GetCheckBoxName(prodName)
	{		
		var index;		
		
		for(index=0;index<checkBoxValues.length;index++)
		{				
			if(checkBoxValues[index]==prodName)
			{			
				return checkBoxNames[index];
			}
		}		
		return '';
	}//end of GetCheckBoxName
	
	function GetProducList(prodName)
	{
		var index,innerIndex;
				
		for(index=0;index<productName.length;index++)
		{	
			if(productName[index]==prodName)
			{		
				return productValues[index];
			}
		}		
		return '';
	}//end of GetProducList	
	
		</script>
		<% =productJavaScript %>
		<% =checkBoxJavaScript %>
		<% =defaultSelectionScript %>
	</body>
</HTML>
