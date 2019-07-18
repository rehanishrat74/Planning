<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Registration.aspx.vb" Inherits="accounts.infinibiz.Web.Registration" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Inland Revenue Gateway</title>
		<meta content="Gateway,Government Gateway,Gateway Registration,Efiling" name="cbwords">
		<meta content="Accounting" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<link href="http://services.infinibiz.com/images/main.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form1" method="post" runat="server">
			<table class="CONTENT" id="layouttable1" height="100%" width="100%" cellpadding="0" cellspacing="0"
				bgcolor="white" border="0">
				<tr>
					<td id="topbar" colSpan="2" height="100" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td>
						<div class="scrolldiv" style="height:100%">
							<table class="CONTENT" id="layouttable" height="100%" width="100%" cellpadding="0" cellspacing="0"
								bgcolor="white" border="0">
								<tr width="100%">
									<td id="contentarea" width="100%" runat="server">
										<TABLE class="content" id="Table1" height="100%" width="100%" cellSpacing="3" cellPadding="3"
											width="100%" border="0">
											<TR>
												<TD id="menuarea" vAlign="top" align="center" width="180" runat="server" CLASS='objtd'>
													<include:serviceslist id="ucServicesList" runat="server"></include:serviceslist>
												</TD>
												<TD id="gatewayarea" vAlign="top" align="left" runat="server" width="100%" CLASS='objtd'>
													<TABLE class="content" id="tblActivateGateWay" style="HEIGHT: 253px" cellSpacing="0" cellPadding="0"
														width="100%" border="0" runat="server">
														<TR>
															<TD class="MSGBAR" style="HEIGHT: 9px" colSpan="3" runat="server" key="acc_gateway_registration_ttactivategateway"
																ID="Td1" NAME="Td1"></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 125px" vAlign="middle"></TD>
															<TD style="HEIGHT: 125px" vAlign="top" align="left">
																<TABLE class="content" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD vAlign="middle" width="100%">
																			<P style="WIDTH: 100%; HEIGHT: 39px" align="justify"><BR>
																				<B>
																					<asp:Label ID="lblactivategateway" Runat="server" key="acc_gateway_registration_lblactivategateway"></asp:Label>
																				</B>
																			</P>
																		</TD>
																	</TR>
																</TABLE>
																<TABLE id="Table3" width="100%">
																	<TR>
																		<TD width="40%"><asp:checkbox id="chkComapny" CssClass="Text-Style-Independent" Font-Bold="True" ForeColor="Black"
																				key="acc_gateway_registration_chkcompany" Runat="server" AutoPostBack="True"></asp:checkbox></TD>
																		<td id="tdCompany" runat="server" class="Text-Style-Independent">&nbsp;</td>
																	</TR>
																	<TR id="trPaye" runat="server">
																		<TD><asp:checkbox id="ChkPaye" CssClass="Text-Style-Independent" Font-Bold="True" ForeColor="Black"
																				key="acc_gateway_registration_chkpaye" Runat="server" AutoPostBack="True"></asp:checkbox></TD>
																		<td id="tdPaye" runat="server" class="Text-Style-Independent">&nbsp;</td>
																	</TR>
																</TABLE>
																<BR>
																&nbsp;
																<asp:panel id="pnlCompanyTax" runat="server" Visible="False" Width="100%">
																	<TABLE id="Table4" style="WIDTH: 720px; HEIGHT: 24px">
																		<TR>
																			<TD id="Td2" style="WIDTH: 353px" align="right" width="353" runat="server" key="acc_gateway_registration_tttaxpin"></TD>
																			<TD vAlign="top" align="right" width="50%">
																				<asp:textbox id="txtCTRPincode" runat="server" CssClass="mtbox" Width="309px" MaxLength="25"></asp:textbox></TD>
																		</TR>
																	</TABLE>
																</asp:panel><asp:panel id="pnlPaye" Runat="server" Visible="false" Width="100%">
																	<TABLE id="Table5" style="WIDTH: 720px; HEIGHT: 26px">
																		<TR>
																			<TD id="Td3" style="WIDTH: 352px" align="right" width="352" runat="server" key="acc_gateway_registration_ttpayepin"><B><FONT size="2">&nbsp;&nbsp;&nbsp;&nbsp;</FONT>&nbsp;<FONT size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																					</FONT>&nbsp;<FONT size="1">&nbsp; </FONT></B>
																			</TD>
																			<TD vAlign="top" align="right" width="50%">&nbsp;
																				<asp:textbox id="txtPayePinCode" runat="server" CssClass="mtbox" Width="310px" MaxLength="25"></asp:textbox></TD>
																		</TR>
																	</TABLE>
																</asp:panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<TABLE id="Table7" style="WIDTH: 145px; HEIGHT: 43px" align="center">
																	<TR align="center">
																		<TD align="left"><asp:button id="btnSave" key="acc_btnsubmit" Runat="Server" Width="60px" CssClass="acc_mbuttonon"
																				onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='acc_mbutton';"></asp:button></TD>
																		<TD align="center"><asp:button id="btnCancel" key="acc_btncancel" Runat="Server" Width="60px" CssClass="acc_mbuttonon"
																				onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='acc_mbutton';"></asp:button></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
													<TABLE class="content" id="tblActivationResult" cellSpacing="0" cellPadding="0" width="100%"
														border="0" runat="server" Visible="False">
														<TR>
															<TD class="MSGBAR" colSpan="3" height="9" runat="server" key="acc_gateway_registration_ttsuccessfullyactivated"
																ID="Td4" NAME="Td4"></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 125px" vAlign="top" align="left">
																<TABLE class="content" id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD style="PADDING-LEFT: 4px" vAlign="middle" width="100%">
																			<asp:Label id="lblactivated" Runat="server" key="acc_gateway_registration_lblactivated"></asp:Label>
																		</TD>
																	<tr>
																		<td style="PADDING-LEFT: 4px"><asp:hyperlink id="lnkContinue" Runat="server" key="acc_acontinue"></asp:hyperlink></td>
																	</tr>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td id="bottombar" colSpan="2" height="29" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
