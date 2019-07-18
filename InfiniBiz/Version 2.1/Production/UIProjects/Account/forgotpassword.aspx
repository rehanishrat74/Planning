<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Page Language="vb" autoeventwireup="false" codebehind="forgotpassword.aspx.vb" Inherits="accounts.infinibiz.Web.ForgotPassword" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Forgot Password</title>
		<meta name="cbwords" content='Password,Forgot Password,Signin Problem'>
		<meta name="cbcat" content='Accounting'>
		<meta http-equiv="Content-Language" content="en">
		<meta name="cbignore" content="1">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server">
		<form id="Form2" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
						</TD>
					</tr>
					<tr>
						<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%">
							<include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
						<td id="contentarea" valign="top" align="center" width="700" runat="server">
							<table class="content" cellspacing="3" cellpadding="0" width="732" align="center" border="0"
								style="WIDTH: 732px; HEIGHT: 19px">
								<tbody>
									<tr>
										<td height="10">
										</td>
									</tr>
								</tbody>
							</table>
							<table class="content" cellspacing="3" cellpadding="0" width="732" align="center" border="0"
								style="WIDTH: 732px; HEIGHT: 226px">
								<tbody>
									<tr valign="top">
										<td width="9%">
											<img height="229" src="/images/forgot.jpg" width="52" style="WIDTH: 52px; HEIGHT: 229px"></td>
										<td width="50%" bgcolor="#edf3f8">
											<table class="content" cellspacing="0" cellpadding="0" width="350" align="center" border="0"
												style="WIDTH: 350px; HEIGHT: 79px">
												<tbody>
													<tr>
														<td valign="top" style="WIDTH: 323px" runat="server" key="acc_account_forgotpassword_ttsigninproblem">
														</td>
													</tr>
													<tr>
														<td valign="top" style="WIDTH: 323px">
														</td>
													</tr>
													<tr>
														<td valign="top" style="WIDTH: 323px; HEIGHT: 62px">
															<p>
																<asp:Label id="lblsigninproblem" runat="server" Width="160px" key="acc_account_forgotpassword_lblsigninproblem"></asp:Label>
															</p>
														</td>
													</tr>
												</tbody>
											</table>
											<P>&nbsp;</P>
											<P>&nbsp;</P>
											<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												<asp:LinkButton id="lnkbtnSign" runat="server" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Small"
													key="acc_account_forgotpassword_asignin"></asp:LinkButton></P>
										</td>
										<td id="Message" width="41%" bgcolor="#edf3f8">
											<asp:Panel id="pnlMessage" runat="server" Width="293px" BackColor="#EDF3F8" Visible="False">
												<DIV style="COLOR: red"><!-- #include virtual="/include/span.htm" --></DIV>
												<TABLE style="WIDTH: 286px; HEIGHT: 61px" width="286">
													<TR>
														<TD></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 19px" align="center">
															<asp:Button id="btnBack" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																runat="server" key="acc_btnback" cssclass="acc_mbutton"></asp:Button></TD>
													</TR>
													<TR>
														<TD vAlign="bottom" align="left"><FONT color="#ff0066" size="1"></FONT></TD>
													</TR>
												</TABLE>
											</asp:Panel>
											<asp:Panel id="pnlBody" runat="server" Width="292px" Height="147px" BackColor="#EDF3F8">
												<TABLE class="content" style="WIDTH: 291px; HEIGHT: 150px" height="150" cellSpacing="5"
													cellPadding="0" width="291" align="center" bgColor="#edf3f8" border="0">
													<TR vAlign="top" bgColor="#fbfbfb">
														<TD style="HEIGHT: 11px" width="50%" bgColor="#edf3f8" colSpan="1" rowSpan="1"><B>
																<asp:Label id="lblemail" runat="server" key="acc_lblemail" Width="64px"></asp:Label><FONT class="Error">&nbsp;*</FONT></B></TD>
														<TD style="HEIGHT: 11px" vAlign="top" align="left" width="65%">
															<asp:textbox id="txtEmail" runat="server" Width="169px" CssClass="mtbox" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 90px; HEIGHT: 13px" height="13"><B>
																<asp:Label id="lblsurname" key="acc_account_forgotpassword_lblsurname" Runat="server"></asp:Label><FONT class="Error">&nbsp;*</FONT></B></TD>
														<TD style="HEIGHT: 13px" vAlign="top" align="left" width="65%" colSpan="1" rowSpan="1">
															<asp:textbox id="txtSurName" runat="server" Width="169px" CssClass="mtbox" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 90px; HEIGHT: 13px" height="13"><B>
																<asp:Label id="lblfirstname" key="acc_account_forgotpassword_lblfirstname" Runat="server"></asp:Label><FONT class="Error">&nbsp;*</FONT></B></TD>
														<TD style="HEIGHT: 13px" vAlign="top" align="left" width="65%">
															<asp:textbox id="txtFirstName" runat="server" Width="169px" CssClass="mtbox" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 90px; HEIGHT: 18px" height="18"><B>
																<asp:Label id="lblsecondname" key="acc_account_forgotpassword_lblsecondname" Runat="server"></asp:Label></B></TD>
														<TD style="HEIGHT: 18px" vAlign="top" align="left" width="65%">
															<asp:textbox id="txtSecondName" runat="server" Width="169px" CssClass="mtbox" MaxLength="250"></asp:textbox></TD>
													</TR>
													<TR vAlign="top" bgColor="#fbfbfb">
														<TD style="WIDTH: 90px; HEIGHT: 18px" bgColor="#edf3f8" height="18"><B></B></TD>
														<TD style="HEIGHT: 18px" vAlign="top" align="left" bgColor="#edf3f8">
															<asp:button id="btnForgotPassword" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';"
																runat="server" key="acc_account_signin_forgotpassword" Width="106px" Font-Bold="True" CssClass="MBUTTON"></asp:button></TD>
													</TR>
													<TR vAlign="top" bgColor="#fbfbfb">
													</TR>
												</TABLE>
											</asp:Panel>
										</td>
									</tr>
								</tbody>
							</table>
						</td>
						<td id="rightbar" width="5%" runat="server">
						</td>
					</tr>
					<tr>
						<td id="bottombar" colspan="2" height="2%" runat="server">
						</td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
