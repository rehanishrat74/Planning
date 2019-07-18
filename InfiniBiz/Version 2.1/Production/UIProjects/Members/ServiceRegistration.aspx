<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ServiceRegistration.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServiceRegistration" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="PurchasedService" Src="\library\components\ServiceOrder.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Service Registration</title>
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
			<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form2" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colSpan="2" height="30" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" vAlign="top" width="100%" runat="server">
							<TABLE class="content" id="Memeberpage" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<TR>
										<td width="5">&nbsp;</td>
										<TD vAlign="top" align="center" width="100%"><include:purchasedservice id="ucServiceOrder" runat="server" PageName="Service Registarion"></include:purchasedservice><asp:panel id="pnlAuhtenticate" Visible="False" Runat="server" Width="100%">
												<TABLE cellSpacing="1" width="600" border="0">
													<TR>
														<TD colSpan="3" height="0">
															<DIV class="content" style="COLOR: red"><!-- #include virtual="/include/span.htm" --></DIV>
														</TD>
													</TR>
													<TR>
														<TD vAlign="top">
															<TABLE class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="100%">
																<TR id="Tr1" runat="server" NAME="Tr1">
																	<TH class="acc_header_backgrounds" noWrap align="left" runat="server" key="acc_account_signin_ttexsistinglogin">
																		<IMG src="/images/php_login.gif">
																	</TH>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="PHP-Table-Deftable" width="100%">
																			<TR>
																				<TD class="PHP-TD-Deftd" align="center" colSpan="2"><BR>
																					<asp:Label id="lbluseridpassword" runat="server" key="acc_account_signin_lbluserid&amp;password"></asp:Label><BR>
																				</TD>
																			</TR>
																			<TR>
																				<TD class="PHP-TD-Deftd" align="right" width="50%">
																					<asp:Label id="Label1" runat="server" Width="254px" key="acc_customerID"></asp:Label></TD>
																				<TD>
																					<asp:TextBox id="txtCustomerID" runat="server" CssClass="MTBOX"></asp:TextBox></TD>
																			</TR>
																			<TR>
																				<TD class="PHP-TD-Deftd" align="right" width="50%">
																					<asp:Label id="lblpassword" runat="server" Width="260px" key="acc_lblpassword"></asp:Label>:
																				</TD>
																				<TD>
																					<asp:TextBox id="txtPassword" runat="server" CssClass="MTBOX" TextMode="Password"></asp:TextBox></TD>
																			</TR>
																			<TR>
																				<TD align="center" width="50%" colSpan="2">
																					<asp:Button id="btnLogin" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_account_signin_btnlogin" CssClass="MBUTTON"></asp:Button></TD>
																			</TR>
																			<TR>
																				<TD class="PHP-TD-Deftd" align="right" width="50%" colSpan="2"><A href="https://www.accountscentre.com/account/forgotpassword.aspx" key="acc_account_signin_aforgotpassword"></A></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
															<BR>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="100%">
																<TR id="Tr2" runat="server" NAME="Tr2">
																	<TH class="acc_header_backgrounds" noWrap align="left" runat="server" key="acc_account_signin_ttnewcustomer">
																		<IMG src="/images/php_newcustomer.gif">
																	</TH>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="PHP-Table-Deftable" width="100%">
																			<TR>
																				<TD class="PHP-TD-Deftd" vAlign="top" align="center"><BR>
																					<asp:Label id="lblnewcustomer" runat="server" key="acc_account_signin_lblnewcustomer"></asp:Label><BR>
																					<BR>
																				</TD>
																			</TR>
																			<TR>
																				<TD class="PHP-TD-Deftd" align="center">
																					<asp:Button id="btnSignUP" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_account_signin_btnnewcustomer" CssClass="MBUTTON"></asp:Button></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlSingUp" Visible="False" Runat="server" Width="100%">
												<TABLE class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="600">
													<TR>
														<TH class="acc_header_backgrounds" noWrap align="left" runat="server" key="acc_members_serviceregistration_ttcustomerinfo">
															<IMG src="/images/php_newcustomer.gif">
														</TH>
													</TR>
													<TR>
														<TD>
															<TABLE class="PHP-Table-Deftable" cellSpacing="1" cellPadding="2" width="100%" border="0">
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
																			<asp:Label id="lblinvoicename1" runat="server" key="acc_account_newcustomer_lblinvoicename"></asp:Label></DIV>
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
																				<asp:Label id="lblContactName1" runat="server" key="acc_members_profile_lblcontactname"></asp:Label></DIV>
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
																			<asp:Label id="lblpassword1" runat="server" key="acc_lblpassword"></asp:Label></DIV>
																	</TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%">*
																	</TD>
																	<TD width="75%">&nbsp;
																		<asp:textbox id="txtSignUpPwd" runat="server" CssClass="MTBOX" TextMode="Password" MaxLength="16"></asp:textbox></TD>
																</TR>
																<TR id="trPasswordConfirm" runat="server">
																	<TD vAlign="top" width="21%">
																		<asp:Label id="lblconfirmpassword" runat="server" key="acc_lblconfirmpassword"></asp:Label></TD>
																	<TD width="2%"></TD>
																	<TD class="error" width="2%">*</TD>
																	<TD width="75%">&nbsp;
																		<asp:textbox id="txtConfirmPassword" runat="server" CssClass="MTBOX" TextMode="Password" MaxLength="16"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="21%">
																		<DIV align="left">
																			<asp:Label id="lblstreet2" runat="server" key="acc_members_profile_lblstreet"></asp:Label></DIV>
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
																			<asp:Label id="lblcity2" runat="server" key="acc_members_profile_lblcity"></asp:Label></DIV>
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
																			<asp:Label id="lblstatecounty" runat="server" key="acc_account_newcustomer_lblstate&amp;county"></asp:Label></DIV>
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
																	<TD vAlign="top" width="21%" height="17">
																		<DIV align="left">
																			<asp:Label id="lblcountry2" runat="server" key="acc_members_profile_lblcountry"></asp:Label></DIV>
																	</TD>
																	<TD width="2%" height="17">&nbsp;
																	</TD>
																	<TD class="error" width="2%" height="17">*
																	</TD>
																	<TD width="75%" height="17">&nbsp;
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
																		<asp:textbox id="txtNotes" runat="server" CssClass="MTBOX" TextMode="MultiLine" MaxLength="255"></asp:textbox></TD>
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
																			runat="server" key="acc_btnnext" CssClass="MBUTTON"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!-- BEGIN COMPANY LIST PANEL --><asp:panel id="pnlCompanyList" Visible="False" Runat="server" Width="600px" BorderWidth="1">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="acc_header_backgrounds" id="Td1" height="15" runat="server" NAME="Td1" key="acc_members_updateservices_ttcompanylist"></TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-White_background" cellSpacing="1" cellPadding="2" width="100%"
																border="0">
																<TR vAlign="middle" height="20">
																	<TD class="link_text">
																		<asp:Label id="lblselectcompnany" runat="server" Width="520px" key="acc_members_updateservices_lblselectcompany"></asp:Label>:</TD>
																</TR>
																<TR>
																	<TD></TD>
																</TR>
																<TR>
																	<TD>
																		<asp:ListBox id="listCompany" Width="100%" Runat="server" CssClass="link_text" Rows="10" SelectionMode="Single"
																			BorderStyle="Groove" Font-Size="8pt"></asp:ListBox></TD>
																</TR>
																<TR>
																	<TD align="center">
																		<asp:button id="btnCompanyList" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																			runat="server" key="acc_btnnext" Font-Bold="True" cssclass="mbutton"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!-- END COMPANY LIST PANEL --><asp:label id="lblCustomerID" runat="server" Visible="False"></asp:label></TD>
									</TR>
								</TBODY></TABLE>
						</td>
						<td id="rightbar" width="5%" runat="server"><asp:label id="lblStatus" Runat="server" text="" visible="False"></asp:label></td>
					</tr>
					<tr>
						<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
					</tr>
				</TBODY></table>
		</form>
		</TR></TBODY></TABLE></TR></TBODY></TABLE></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
