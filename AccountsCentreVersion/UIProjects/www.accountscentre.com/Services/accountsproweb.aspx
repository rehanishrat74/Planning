<%@ Page Language="vb" AutoEventWireup="false" Codebehind="accountsproweb.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.AccountsProWeb" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o>
	<HEAD>
		<title>Accounts Centre - Online Services - Accounts Pro (web)</title>
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
											<TD class="acc_header_backgrounds" colspan="3">&nbsp;Accounts Pro (web)</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 138px" vAlign="top"></TD>
											<TD style="HEIGHT: 138px" vAlign="top">
												<TABLE class="content" id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD style="WIDTH: 262px" vAlign="top" width="262">
															<P align="justify">
																<br>
																<SPAN lang="EN-GB">InfiniAccounts-Pro is a sophisticated accounting tool, which 
																	allows you to save time and effort, when managing your company’s merchandising 
																	accounts. Based on sound accounting principles, it offers the following 
																	features:</SPAN></P>
															<UL style="MARGIN-TOP: 0in" type="disc">
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in; mso-layout-grid-align: none">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold">Assets Register
																		<o:p></o:p></SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in; mso-layout-grid-align: none">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold">Stock Manager
																		<o:p></o:p></SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in; mso-layout-grid-align: none">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold">Bank Reconciliation
																		<o:p></o:p></SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in">
																	<SPAN lang="EN-GB">Customer Management</SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in">
																	<SPAN lang="EN-GB">Vendor Management</SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in">
																	<SPAN lang="EN-GB">VAT Management</SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold">Budgeting</SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l0 level1 lfo2; tab-stops: list .5in">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold"></SPAN><SPAN lang="EN-GB">E-commerce<SPAN style="mso-bidi-font-weight: bold">
																			<o:p></o:p></SPAN></SPAN>
																<LI class="MsoNormal" style="LINE-HEIGHT: 150%; mso-list: l1 level1 lfo1; tab-stops: list .5in">
																	<SPAN lang="EN-GB" style="mso-bidi-font-weight: bold">Reports, including Financial 
																		reports, i.e. Balance Sheet and Profit &amp; Loss Statement</SPAN></LI></UL>
														</TD>
														<TD vAlign="top" align="right">
															<asp:Literal id="Literal2" runat="server"></asp:Literal></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="HEIGHT: 138px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 74px" vAlign="top"></TD>
											<TD style="HEIGHT: 74px" vAlign="top">
											</TD>
											<TD style="HEIGHT: 74px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 7px" vAlign="top"></TD>
											<TD style="HEIGHT: 7px" vAlign="top">
												<P align="justify">
													<asp:Literal id="Literal1" runat="server"></asp:Literal></P>
											</TD>
											<TD style="HEIGHT: 7px"></TD>
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
