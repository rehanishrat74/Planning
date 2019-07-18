<%@ Page Language="vb" autoeventwireup="false" codebehind="NewCustomer.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.NewCustomer" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Sign Up</title>
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
												::..: Accounts Centre Registration &nbsp;<BR>
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
															To use our services, you must be a registered member of either Accounts Centre, 
															or any of our partner websites. Being a registered member, you can access all 
															services that you have subscribed for, and also receive valuable information on 
															tax, legal and accounting matters, that are directly or indirectly targeted 
															towards helping you help your <FONT color="#003366">business</FONT>.
														</P>
														<P></P>
														<P>Please fill out the form below to register with Accounts Centre. Once you 
															register, you will receive a confirmation email containing your User ID and 
															Password.
															<BR>
															<BR>
															For more information on other services, <A href="/Services/">click here.</A>&nbsp;&nbsp;&nbsp;&nbsp;
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
																	<TD class="acc_header_backgrounds">&nbsp;Information</TD>
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
																	<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp; Customer Detail</TD>
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
																					<DIV align="right">Invoice Name :
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
																					<DIV align="right">Contact&nbsp;Name :
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
																					<DIV align="right">Street :
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
																					<DIV align="right">Town :
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
																					<DIV align="right">State :
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
																					<DIV align="right">Postcode :
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
																					<DIV align="right">Country :
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
																					<DIV align="right">Telephone :
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
																					<DIV align="right">Fax :
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
																					<DIV align="right">Email :
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
																	<TD class="acc_header_backgrounds" bgColor="#c5d8e7">Customer Registration</TD>
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
																					<DIV align="left">Invoice Name</DIV>
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
																						<DIV align="left">Contact Name
																						</DIV>
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
																					<DIV align="left">Password
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtPassword" runat="server" CssClass="MTBOX" MaxLength="16" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR id="trPasswordConfirm" runat="server">
																				<TD vAlign="top" width="21%">Confirm Password</TD>
																				<TD width="2%"></TD>
																				<TD class="error" width="2%">*</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="txtConfirmPassword" runat="server" CssClass="MTBOX" MaxLength="16" TextMode="Password"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="21%">
																					<DIV align="left">Street
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
																					<DIV align="left">Town / City</DIV>
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
																					<DIV align="left">State / County</DIV>
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
																					<DIV align="left">Post code
																					</DIV>
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
																					<DIV align="left">Country
																					</DIV>
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
																					<DIV align="left">Telephone
																					</DIV>
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
																					<DIV align="left">Fax
																					</DIV>
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
																					<DIV align="left">Email
																					</DIV>
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
																					<DIV align="left">Notes
																					</DIV>
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
																						runat="server" Cssclass="MBUTTON" Text="Next >>"></asp:button></TD>
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
																	<TD class="acc_header_backgrounds">&nbsp;Packages Plans</TD>
																</TR>
																<% end if %>
																<TR>
																	<TD>
																		<asp:datagrid id="grdPackages" runat="server" Width="590px" CssClass="text-outerborder-White_background"
																			CellPadding="3" BorderColor="#7BAEE3" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="frm-section-text"></HeaderStyle>
																					<ItemStyle VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkSelect" AutoPostBack="false" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
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
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<% if me.grdProducts.visible %>
																<TR>
																	<TD class="acc_header_backgrounds">&nbsp;Individual&nbsp;Products</TD>
																</TR>
																<% end if %>
																<TR>
																	<TD>
																		<asp:datagrid id="grdProducts" runat="server" Width="590px" Height="100%" CssClass="text-outerborder-White_background"
																			CellPadding="3" BorderColor="#7BAEE3" BorderWidth="1px" BorderStyle="None" AutoGenerateColumns="False">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="frm-section-text"></HeaderStyle>
																					<ItemStyle VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkSelect1" AutoPostBack="false" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
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
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD class="acc_header_backgrounds">&nbsp;Payment Method</TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background" cellSpacing="2" cellPadding="0" width="100%"
																			bgColor="#f6f5f5" border="0">
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">&nbsp;</TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;Payment Mode :</TD>
																				<TD width="289">
																					<asp:radiobuttonlist id="rbtPaymentMethod" runat="server" CssClass="MTBOX">
																						<asp:ListItem Value="Credit Card" Selected="True">Credit 
                                          Card</asp:ListItem>
																						<asp:ListItem Value="Cheque Or Bank Transfer">Cheque 
                                          Or Bank Transfer</asp:ListItem>
																					</asp:radiobuttonlist></TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;Delivery Address :</TD>
																				<TD width="289">
																					<asp:textbox id="txtDeliveryAddress" runat="server" Width="262px" Height="74px" CssClass="MTBOX"
																						MaxLength="150" TextMode="MultiLine"></asp:textbox></TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">&nbsp;</TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">
																					<asp:button id="btnPaymentMethod" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" Width="63px" Font-Bold="True" Cssclass="MBUTTON" Text="Next >>"></asp:button>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlBankTransfer" runat="server" Width="600px" Height="146px">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;Bank Transfer Method
																	</TD>
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
																				<TD vAlign="top" width="173">Bank Name</TD>
																				<TD class="error" width="9"></TD>
																				<TD width="252">
																					<asp:textbox id="txtBankName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Cheque No.</TD>
																				<TD class="error" width="9"></TD>
																				<TD width="252">
																					<asp:textbox id="txtChequeNo" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Sort Code</TD>
																				<TD width="9"></TD>
																				<TD width="252">
																					<asp:textbox id="txtSortCode" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Transaction Ref. No.</TD>
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
																						runat="server" Cssclass="MBUTTON" Text="Next >>"></asp:button></TD>
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
																	<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;Credit Card Information
																	</TD>
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
																				<TD vAlign="top" width="173">Select Card
																				</TD>
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
																					</asp:dropdownlist></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Card Holder Name</TD>
																				<TD class="error" width="9">*</TD>
																				<TD width="252">
																					<asp:textbox id="txtCardHolderName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Card Number</TD>
																				<TD class="error" width="9">*</TD>
																				<TD width="252">
																					<asp:textbox id="txtCardNumber" runat="server" Width="258px" CssClass="MTBOX" MaxLength="20"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Expiry Date (mm / yyyy)&nbsp;</TD>
																				<TD class="error" width="9">*</TD>
																				<TD width="252">
																					<asp:dropdownlist id="ddlMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
																					<asp:dropdownlist id="ddlYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">
																					<P>&nbsp;</P>
																					<P>Card&nbsp;Address
																					</P>
																				</TD>
																				<TD class="error" width="9">*</TD>
																				<TD width="252">
																					<asp:textbox id="txtCardAddress" runat="server" Width="257px" Height="73px" CssClass="MTBOX"
																						MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173">Security&nbsp;Code&nbsp;</TD>
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
																						runat="server" Cssclass="MBUTTON" Text="Next >>"></asp:button></TD>
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
																					align="right" width="173">Card Holder Name :
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
																					align="right" width="173">Card Number :
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
																					align="right" width="173">Expiry Date (mm / yyyy)&nbsp;:
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
																					align="right" width="173">Card&nbsp;Address :</TD>
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
																					align="right" width="173">Security&nbsp;Code&nbsp;:
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
																					borderColor="#7baee3" width="173"><STRONG>Choose Date Range</STRONG></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR id="trStartDate" runat="server">
																				<TD id="tdStartDate" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					vAlign="top" borderColor="#7baee3" width="173" runat="server">Start&nbsp;Date 
																					(mm / yyyy)</TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:dropdownlist id="ddlAmexSDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
																					<asp:dropdownlist id="ddlAmexSDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR id="trIssueNumber" runat="server">
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">Issue Number</TD>
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
																						runat="server" Text="Next >>" cssclass="acc_mbutton"></asp:button></TD>
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
												runat="server" Width="100px" Text="Retry Payment" Cssclass="MBUTTON" Visible="False" CommandName="NO"></asp:button>&nbsp;
											<asp:button id="btnFinish" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
												runat="server" Width="100px" Text="Finish >>" Cssclass="MBUTTON" Visible="False"></asp:button><asp:textbox id="txtHiddenCustomerID" runat="server" Text="" Visible="False"></asp:textbox><asp:textbox id="txtHiddenOrderID" runat="server" Text="" Visible="False"></asp:textbox></td>
									</tr>
								</tbody>
							</table>
						</td>
						</TD></tr>
					<tr>
						<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
