<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Registration.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Registration" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Inland Revenue Gateway</title>
		<meta content="Gateway,Government Gateway,Gateway Registration,Efiling" name="cbwords">
		<meta content="Accounting" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form1" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" width="95%" runat="server"><br>
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" vAlign="top" align="center" width="180" runat="server">
									<include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></TD>
								<TD id="gatewayarea" vAlign="top" align="left" runat="server">
									<TABLE class="content" id="tblActivateGateWay" style="HEIGHT: 253px" cellSpacing="0" cellPadding="0"
										width="100%" border="0" runat="server">
										<TR>
											<TD class="MSGBAR" style="HEIGHT: 9px" colSpan="3">&nbsp;Activate Gateway Services</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 125px" vAlign="middle"></TD>
											<TD style="HEIGHT: 125px" vAlign="top" align="left">
												<TABLE class="content" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD vAlign="middle" width="100%">
															<P style="WIDTH: 100%; HEIGHT: 39px" align="justify"><BR>
																<B>Please enter your PIN code to activate your Gateway services. You should have 
																	received a PIN code in the post.</B></P>
														</TD>
													</TR>
												</TABLE>
												<TABLE id="Table3" width="100%">
													<TR>
														<TD width="40%"><asp:checkbox id="chkComapny" CssClass="Text-Style-Independent" Font-Bold="True" ForeColor="Black"
																Text="Company Tax Return PIN Code" Runat="server" AutoPostBack="True"></asp:checkbox></TD>
														<td id="tdCompany" runat="server" class="Text-Style-Independent">&nbsp;</td>
													</TR>
													<TR id="trPaye" runat="server">
														<TD><asp:checkbox id="ChkPaye" CssClass="Text-Style-Independent" Font-Bold="True" ForeColor="Black"
																Text="PAYE PIN Code" Runat="server" AutoPostBack="True"></asp:checkbox></TD>
														<td id="tdPaye" runat="server" class="Text-Style-Independent">&nbsp;</td>
													</TR>
												</TABLE>
												<BR>
												&nbsp;
												<asp:panel id="pnlCompanyTax" runat="server" Visible="False" Width="100%">
													<TABLE id="Table4" style="WIDTH: 720px; HEIGHT: 24px">
														<TR>
															<TD id="Td1" style="WIDTH: 353px" align="right" width="353" runat="server"><B><FONT size="2">Enter 
																		your Corporation Tax Online activation PIN</FONT></B></TD>
															<TD vAlign="top" align="right" width="50%">
																<asp:textbox id="txtCTRPincode" runat="server" CssClass="mtbox" Width="309px" MaxLength="25"></asp:textbox></TD>
														</TR>
													</TABLE>
												</asp:panel><asp:panel id="pnlPaye" Runat="server" Visible="false" Width="100%">
													<TABLE id="Table5" style="WIDTH: 720px; HEIGHT: 26px">
														<TR>
															<TD id="Td2" style="WIDTH: 352px" align="right" width="352" runat="server"><B><FONT size="2">Enter 
																		your PAYE Online activation PIN&nbsp;&nbsp;&nbsp;&nbsp;</FONT>&nbsp;<FONT size="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																	</FONT>&nbsp;<FONT size="1">&nbsp; </FONT></B>
															</TD>
															<TD vAlign="top" align="right" width="50%">&nbsp;
																<asp:textbox id="txtPayePinCode" runat="server" CssClass="mtbox" Width="310px" MaxLength="25"></asp:textbox></TD>
														</TR>
													</TABLE>
												</asp:panel>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<TABLE id="Table7" style="WIDTH: 145px; HEIGHT: 43px" align="center">
													<TR align="center">
														<TD align="left"><asp:button id="btnSave" Text="Submit" Runat="Server" Width="60px" Cssclass="MBUTTON"></asp:button></TD>
														<TD align="center"><asp:button id="btnCancel" Text="Cancel" Runat="Server" Width="60px" Cssclass="MBUTTON"></asp:button></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<TABLE class="content" id="tblActivationResult" cellSpacing="0" cellPadding="0" width="100%"
										border="0" runat="server" Visible="False">
										<TR>
											<TD class="MSGBAR" colSpan="3" height="9">&nbsp;Gateway Services Successfully 
												Activated</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 125px" vAlign="top" align="left">
												<TABLE class="content" id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="PADDING-LEFT: 4px" vAlign="middle" width="100%">
															<P><BR>
																<B>Information has been saved.</B></P>
															<P><STRONG>Your link with the Gateway has been activated.</STRONG></P>
															<P></P>
														</TD>
													<tr>
														<td style="PADDING-LEFT: 4px"><asp:hyperlink id="lnkContinue" Runat="server">Continue</asp:hyperlink></td>
													</tr>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			</td></tr>
			<tr>
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
			</tr>
			</table></form>
	</body>
</HTML>
