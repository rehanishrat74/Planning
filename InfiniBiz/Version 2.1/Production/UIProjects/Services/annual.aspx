<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="annual.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServicesAnnual" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o>
	<HEAD>
		<title>Accounts Centre - Online Services - Annual Accounts</title>
		<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
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
								<TD id="servicearea" runat="server" vAlign="top" align="left" width="80%">
									<TABLE class="content" id="Table6" style="WIDTH: 473px; HEIGHT: 143px" cellSpacing="0"
										cellPadding="0" width="473" border="0">
										<TR>
											<TD class="acc_header_backgrounds" style="HEIGHT: 9px" colspan="3">&nbsp;Annual 
												Accounts</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 94px" vAlign="top"></TD>
											<TD style="HEIGHT: 94px" vAlign="top">
												<TABLE class="content" id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%"
													border="0">
													<TR>
														<TD style="WIDTH: 262px" vAlign="top" width="262"><br>
															<P align="justify"><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold">All 
																	UK registered companies are required to submit their annual accounts 
																	(abbreviated or in detail) to Companies House and HMRC (along with the Company 
																	Tax Return) annually.</SPAN></P>
															<P align="justify"><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold"></SPAN><SPAN style="mso-ansi-language: EN-US; mso-bidi-font-weight: bold">Accounts 
																	Centre offers you the facility to easily prepare your annual accounts in the 
																	required format. If you are an InfiniAccounts Accounting software user, all you 
																	have to do is upload your Infini Accounts database. Otherwise, kindly upload 
																	your prepared accounts in Excel formatted worksheet(s).
																	<o:p></o:p></SPAN></P>
															<P align="justify">
																<br>
																&nbsp;</P>
														</TD>
														<TD vAlign="top" align="right">
															<asp:Literal id="Literal2" runat="server"></asp:Literal></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="HEIGHT: 94px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 5px; HEIGHT: 6px" vAlign="top"></TD>
											<TD style="HEIGHT: 6px" vAlign="top">
												<P align="justify">
													<asp:Literal id="Literal1" runat="server"></asp:Literal></P>
											</TD>
											<TD style="HEIGHT: 6px"></TD>
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
