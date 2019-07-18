<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SelectCustomer.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.SelectCustomer" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Member Home</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="frmSelCustomer" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" style="WIDTH: 100%" width="100%" runat="server">
						<TABLE class="CONTENT" id="layouttable2" height="100%" cellSpacing="0" cellPadding="0"
							width="100%" border="0">
							<TBODY>
								<TR>
									<td id="rightbar" width="5%" runat="server"></td>
								</TR>
								<tr>
									<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%">
										<include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
									<td align="center">
										<table cellpadding="0" cellspacing="0">
											<tr>
												<td style="BACKGROUND-COLOR: #34699e" height="60">
													<font color="#ffffff" style="FONT-WEIGHT: bold; FONT-SIZE: 17pt">&nbsp; Create 
														Global View&nbsp;Member Company</font>
													<br>
													<FONT color="#ffffff" style="FONT-SIZE: 8pt">&nbsp;&nbsp;&nbsp;&nbsp; Organize the 
														way you want... </FONT>
												</td>
											</tr>
											<tr>
												<td width="565" height="30" valign="middle" bgcolor="#edf3f8" class="content" style="HEIGHT: 37px">
													<strong><font size="3">&nbsp;&nbsp;
															<asp:Literal Runat="server" ID="litCompanyName" Text=""></asp:Literal>
															<br>
														</font></strong>
												</td>
											</tr>
											<tr>
												<td class="content" height="55" align="left" valign="middle" nowrap bgcolor="#edf3f8"
													style="HEIGHT: 55px">
													<strong><font size="3">&nbsp;&nbsp; Mark as Separate Company</font><br>
														&nbsp;&nbsp;&nbsp;<asp:CheckBox id="chkExclude" runat="server" Width="100%" Text="Allow this company to be signed-in with its own User ID and Password."
															cssclass="content"></asp:CheckBox>
													</strong>
												</td>
											</tr>
											<tr>
												<td height="15" valign="top" bgcolor="#fbfbfb">&nbsp;</td>
											</tr>
											<tr>
												<td height="58" valign="middle" bgcolor="#edf3f8">
													<div align="center">
														<p>
															<font color="#000080">
																<asp:Button Text="Exclude Company" id="btnNewCustomer" class="MBUTTON" onmouseover="this.className='MBUTTONON';"
																	onmouseout="this.className='MBUTTON';" style="FONT-WEIGHT:bold" runat="server" Width="153"
																	Visible="False"></asp:Button>
																<asp:Button class="MBUTTON" id="btnCurrentCustomer" onmouseover="this.className='MBUTTONON';"
																	style="FONT-WEIGHT: bold" onmouseout="this.className='MBUTTON';" Width="153" Runat="server"
																	Text="Continue..."></asp:Button>
															</font>
														</p>
													</div>
												</td>
											</tr>
											<tr>
												<td height="99">&nbsp;</td>
											</tr>
										</table>
									</td>
								</tr>
							</TBODY>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td width="100%" id="bottombar" height="2%" runat="server"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
