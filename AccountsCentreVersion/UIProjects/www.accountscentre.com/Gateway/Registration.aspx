<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Registration.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Registration" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Inland Revenue Gateway</title>
		<meta name="cbwords" content='Gateway,Government Gateway,Gateway Registration,Efiling'>
		<meta name="cbcat" content='Accounting'>
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" ID="Body1">
		<form id="Form1" method="post" runat="server">
			<table id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0"
				class="CONTENT">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" runat="server" width="95%">
						<br>
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD id="gatewayarea" runat="server" vAlign="top" align="left">
									<TABLE class="content" id="tblActivateGateWay" WIDTH="100%" style=" HEIGHT: 253px" cellSpacing="0"
										cellPadding="0" border="0" runat="server">
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
														<TD>
															<asp:checkbox id="chkComapny" AutoPostBack="True" Runat="server" Text="Company Tax Return PIN Code"
																Font-Bold="True" CssClass="Text-Style-Independent"></asp:checkbox></TD>
													</TR>
													<TR>
														<TD>
															<asp:checkbox id="ChkPaye" AutoPostBack="True" Runat="server" Text="PAYE PIN Code" Font-Bold="True"
																CssClass="Text-Style-Independent"></asp:checkbox></TD>
													</TR>
												</TABLE>
												<BR>
												&nbsp;
												<asp:panel id="pnlCompanyTax" runat="server" Width="100%" Visible="False">
													<TABLE id="Table4" style="WIDTH: 720px; HEIGHT: 24px">
														<TR>
															<TD id="Td1" style="WIDTH: 353px" align="right" width="353" runat="server"><B><FONT size="2">Enter 
																		your Corporation Tax Online activation PIN</FONT></B></TD>
															<TD vAlign="top" align="right" width="50%">
																<asp:textbox id="txtCTRPincode" runat="server" CssClass="mtbox" Width="309px" MaxLength="25"></asp:textbox></TD>
														</TR>
													</TABLE>
												</asp:panel>
												<asp:panel id="pnlPaye" Runat="server" Width="100%" Visible="false">
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
												<TABLE id="Table7" align="center" style="WIDTH: 145px; HEIGHT: 43px">
													<TR align="center">
														<TD align="left">
															<asp:button id="btnSave" Runat="Server" Text="Submit" Visible="false" Cssclass="MBUTTON"></asp:button></TD>
														<TD align="center">
															<asp:button id="btnCancel" Runat="Server" Text="Cancel" Visible="false" Cssclass="MBUTTON"></asp:button></TD>
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
														<TD vAlign="middle" width="100%" style="PADDING-LEFT: 4px">
															<P><BR>
																<B>Information has been saved.</B></P>
															<P><STRONG>Your link with the Gateway has been activated.</STRONG></P>
															<P></P>
														</TD>
													<tr>
														<td style="Padding-Left: 4px"><asp:HyperLink id="lnkContinue" Runat="server">Continue</asp:HyperLink></td>
													</tr>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
			</td> </tr>
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
			</tr>
			</table>
		</form>
	</body>
</HTML>
