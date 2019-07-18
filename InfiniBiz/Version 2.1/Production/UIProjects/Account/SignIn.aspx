<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SignIn.aspx.vb" Inherits="accounts.infinibiz.Web.SignIn" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Sign In</title>
		<meta name="cbignore" content="1">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="/library/style/style.css" type="text/css" rel="stylesheet">
		<style type="text/css">
.style15 { FONT-SIZE: 14px; COLOR: #000000; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
.style17 { FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
.style18 { FONT-SIZE: 9px; COLOR: #000000; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
.style26 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #000000; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
.style27 { FONT-SIZE: 9px; COLOR: #000000 }
.style29 { FONT-SIZE: 9px; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
.style31 { FONT-SIZE: 9px; COLOR: #ff0000; FONT-FAMILY: Verdana, Arial, Helvetica, sans-serif }
</style>
</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" id="Body1">
		<form id="Form2" method="post" runat="server">
			<table id="layouttable" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0"
				class="CONTENT">
				<tbody>
					<tr>
						<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
						<td id="contentarea" runat="server" width="700" align="right" valign="top">
							<table width="500" cellspacing="1" border="0" align="center">
								<tr>
									<td colspan="3" height="40">
										<div class="content" style="COLOR: red"> <!-- #include virtual="/include/span.htm" -->
										</div>
									</td>
								</tr>
								<tr>
									<td valign="top">
										<table width="100%" class="PHP-Table-Container" cellpadding="0" cellspacing="0">
											<tr>
												<th nowrap align="left" class="PHP-TH-Defth" runat="server" key="acc_account_signin_ttexsistinglogin">
													<img src="/images/php_login.gif">
												</th>
											</tr>
											<tr>
												<td>
													<table width="100%" class="PHP-Table-Deftable">
														<tr>
															<td colspan="2" class="PHP-TD-Deftd" align="center"><br>
																<asp:Label id="lbluseridpassword" runat="server" key="acc_account_signin_lbluserid&amp;password"></asp:Label>
																<br>
															</td>
														</tr>
														<tr>
															<td width="50%" align="right" class="PHP-TD-Deftd"><asp:Label id="lblcustomerID" runat="server" key="acc_customerID" Width="217px"></asp:Label></td>
															<td>
																<asp:TextBox id="txtCustomerID" runat="server" CssClass="PHP-DefText"></asp:TextBox></td>
														</tr>
														<TR>
															<TD align="right" width="50%" class="PHP-TD-Deftd"><asp:Label id="lblpassword" runat="server" key="acc_lblpassword" Width="221px"></asp:Label>
															</TD>
															<TD>
																<asp:TextBox id="txtPassword" runat="server" TextMode="Password" CssClass="PHP-DefText"></asp:TextBox></TD>
														</TR>
														<TR>
															<TD align="center" width="50%" colSpan="2">
																<asp:Button id="btnLogin" runat="server"  CssClass="PHP-DefButton" key="acc_account_signin_btnlogin"></asp:Button></TD>
														</TR>
														<TR>
															<TD align="right" width="50%" colSpan="2" class="PHP-TD-Deftd"><a href="https://www.accountscentre.com/account/forgotpassword.aspx" key="acc_account_signin_forgotpassword"></a></TD>
														</TR>
													</table>
												</td>
											</tr>
										</table>
										<br>
									</td>
								</tr>
								<tr>
									<td><table width="100%" class="PHP-Table-Container" cellpadding="0" cellspacing="0">
											<tr>
												<th nowrap align="left" class="PHP-TH-Defth" runat="server" key="acc_account_signin_ttnewcustomer">
													<img src="/images/php_newcustomer.gif">
												</th>
											</tr>
											<tr>
												<td>
													<table width="100%" class="PHP-Table-Deftable">
														<tr>
															<td valign="top" class="PHP-TD-Deftd" align="center"><br>
																<asp:Label id="lblnewcustomer" runat="server" key="acc_account_signin_lblnewcustomer"></asp:Label>
													<br>
																<br>
															</td>
														</tr>
														<tr>
															<td align="center" class="PHP-TD-Deftd">
																<asp:Button id="btnSignUP"  runat="server" key="acc_account_signin_btnnewcustomer" CssClass="PHP-DefButton"></asp:Button></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
					<tr>
						<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
					</tr>
				</tbody>
			</table>
		</form>
	</body>
</HTML>
