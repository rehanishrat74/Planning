<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ActivationMessage.aspx.vb" Inherits="accounts.infinibiz.Web.ActivationMessage"%>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Product Activation</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table style="WIDTH:100%;HEIGHT:100%" bgColor="white">
				<tr>
					<td>
						<include:topbar id="idxTopBar1" runat="server"></include:topbar>
					</td>
				</tr>
				<tr style="WIDTH:100%;HEIGHT:100%">
					<td align="center" valign="top">
						<br>
						<br>
						<table width="780" cellspacing="0" cellpadding="0" class="text-outerborder-White_background"
							align="center">
							<tr>
								<td><div align="center">
										<table border="0" width="780">
											<tr>
												<td height="21">&nbsp;</td>
											</tr>
											<tr>
												<td height="3" bgcolor="#999999" width="1"><img src="" height="3" width="1"></td>
											<tr>
												<td height="23">&nbsp;</td>
											</tr>
											<tr>
												<td height="23"><font size="5" color="#999999">Congratulations!</font></td>
											</tr>
											<tr>
												<td height="23">&nbsp;</td>
											</tr>
											<tr>
												<td><font size="2" face="Verdana">Your service has been activated.</font></td>
											</tr>
											<tr id="trWebsite2" runat="server">
												<td><font size="2">&nbsp;</font></td>
											</tr>
											<tr id="trWebsite1" runat="server">
												<td align="center"><div align="left">
														<font size="2" face="Verdana, Arial, Helvetica, sans-serif">You can now visit your 
															site at <strong>
																<asp:HyperLink id="hlnkWebsite" runat="server" Target="_blank"></asp:HyperLink></strong></font></div>
												</td>
											</tr>
											<tr>
												<td height="21">
												</td>
											</tr>
											<tr>
												<td height="21" align="center"><asp:Button id="btnMyAccount" runat="server" CssClass="acc_mbuttonon" Text="My Account"></asp:Button></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
