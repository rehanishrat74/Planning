<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Dormant.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServicesDCA" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o>
	<HEAD>
		<title>Accounts Centre - Online Services - Corporation Tax</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" ID="Body1">
		<form id="Form1" method="post" runat="server">
			<table id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0"
				class="CONTENT">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" runat="server" width="95%"><br>
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD id="servicearea" runat="server" vAlign="top" align="left" width="80%">
									<TABLE class="content" id="Table6" style="WIDTH: 473px; HEIGHT: 253px" cellSpacing="0"
										cellPadding="0" width="473" border="0">
										<TR>
											<TD class="acc_header_backgrounds" style="HEIGHT: 15px" colspan="3">&nbsp;Dormant 
												Accounts</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 90px" vAlign="top"></TD>
											<TD style="HEIGHT: 90px" vAlign="top">
												<TABLE class="content" id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD style="WIDTH: 262px" vAlign="top" width="262"><br>
															<P align="justify"><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold">Accounts 
																	Centre provides the Dormant Accounts E-Filing service, for those companies who 
																	have not traded or engaged in any financial activity throughout their financial 
																	year. For such companies, the rules are more relaxed and there are minimal 
																	requirements to file with the Companies House. <SPAN style="mso-tab-count: 1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																	</SPAN>
																	<o:p></o:p></SPAN>
															</P>
															<P class="MsoNormal" style="LINE-HEIGHT: 150%"><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold">
																	<o:p>&nbsp;</o:p></SPAN></P>
															<P class="MsoNormal" style="LINE-HEIGHT: 150%"><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold">Using 
																	the Accounts Centre service, your corporation tax return will also be filed 
																	with HMRC. In case, you have never e-filed your returns before, an automatic 
																	request will also be placed for Government Gateway registration, which can be 
																	then used to E-file in the future.
																	<o:p></o:p></SPAN></P>
															<P align="justify">&nbsp;</P>
														</TD>
														<TD vAlign="top" align="right">
															<asp:Literal id="Literal2" runat="server"></asp:Literal></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="HEIGHT: 90px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 129px" vAlign="top"></TD>
											<TD style="HEIGHT: 129px" vAlign="top">
												<P align="justify">
													<asp:Literal id="Literal1" runat="server"></asp:Literal>
												</P>
											</TD>
											<TD style="HEIGHT: 129px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px"></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
					<td id="rightbar" width="5%" runat="server"></td>
				</tr>
				<tr>
					<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
