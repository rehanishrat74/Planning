<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ outputcache Location="None" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SignIn.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.SignIn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Sign In</title>
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
							<table width="600" cellspacing="1" border="0" align="left">
								<tr>
									<td></td>
									<td colspan="3" height="40">
										<div class="content" style="COLOR: red"> <!-- #include virtual="/include/span.htm" -->
										</div>
									</td>
								</tr>
								<tr valign="top">
									<td width="7%" bgcolor="#edf3f8"><img src="/images/sign-in.jpg" width="52" height="196"></td>
									<td width="40%" bgcolor="#edf3f8">
										<table cellspacing="1" cellpadding="0">
											<tr>
												<td valign="top"><span class="style26">Accounts Centre Sign In </span>
												</td>
											</tr>
											<tr>
												<td valign="top" class="style29"><p align="justify" class="content">
														<font face="Verdana" style="FONT-SIZE: 8pt">
															<br>
															Accounts Centre will allow complete access to our services..</font><font face="Verdana" style="FONT-SIZE: 9pt">
														</font>
													</p>
												</td>
											</tr>
											<tr>
												<td valign="top" class="content"><p class="content">
														<br>
														<span class="content" align="justify">You can now use your Accounts Centre Sign In 
															information to log in on: Formations House and Graphics4Less.</span><br>
														&nbsp;<br>
													</p>
												</td>
											</tr>
										</table>
										<table width="100%" height="36%" border="0" align="center" cellpadding="0" cellspacing="2"
											class="content">
											<tr valign="top" bgcolor="#fbfbfb">
												<td width="34%"><b>User ID</b></td>
												<td width="66%"><asp:textbox id="txtuserid" runat="server" width="150px" cssclass="mtbox" maxlength="250">42504905</asp:textbox></td>
											</tr>
											<tr valign="top" bgcolor="#fbfbfb">
												<td><b>Password</b></td>
												<td><asp:textbox id="txtpassword" runat="server" width="150px" cssclass="mtbox" maxlength="50">sa</asp:textbox></td>
											</tr>
											<tr valign="top" bgcolor="#fbfbfb">
												<td height="24">&nbsp;</td>
												<td bgcolor="#fbfbfb">
													<font color="#000080">
														<asp:button id="btnSignin" cssclass="acc_mbutton" onmouseover="this.className='acc_mbuttonon';"
															onmouseout="this.className='MBUTTON';" runat="server" width="53px" font-bold="True" text="Sign In"></asp:button>
													</font>
												</td>
											</tr>
										</table>
									</td>
									<td width="58%" bgcolor="#fbfbfb"><table width="100%" height="36%" border="0" align="center" cellpadding="0" cellspacing="3"
											class="content">
											<tr valign="top" bgcolor="#fbfbfb">
												<td height="24"><span class="style29"> <span style="FONT-WEIGHT: 700; FONT-SIZE: 9pt">New 
															Customers</span><br>
														<span style="FONT-WEIGHT: 400"><span style="FONT-SIZE: 8pt">
																<br>
																New Customers Please click Register below to begin..</span><span style="FONT-SIZE: 9pt"><br>
															</span><font color="#ff0000"><span style="FONT-SIZE: 9pt">
																	<br>
																</span></font></span><span style="FONT-SIZE: 9pt"><a href="https://www.accountscentre.com/account/newcustomer.aspx" style="TEXT-DECORATION:none">
																<b>Register...</b></a> </span>
														<br>
														<br>
														<span class="content" align="justify">If you have forgotten your User ID or 
															Password, please click the link below. After Providing some information you 
															will receive a notification via email.</span></span>
												</td>
											</tr>
											<tr valign="top" bgcolor="#fbfbfb">
												<td height="24">
													<p class="style29"><b><span class="style31"> <span style="FONT-SIZE: 9pt">
																	<br>
																	<a href="https://www.accountscentre.com/account/forgotpassword.aspx" style="TEXT-DECORATION:none">
																		Forgot Password...</a></STRONG><a href="/account/forgotpassword.aspx" style="TEXT-DECORATION:none"></a></span></span></b></p>
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
