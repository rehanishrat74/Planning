<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Default.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.DefaultPage" buffer="True" %>
<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Welcome to Accounts Centre</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta http-equiv="Content-Language" content="en">
		<meta name="cbwords" content='accountscentre, accounting business'>
		<meta name="cbcat" content='Accounting'>
		<link href='/library/style/indexstyle.css' type='text/css' rel="stylesheet">
	</HEAD>
	<body bottommargin="0" leftmargin="0" topmargin="0" rightmargin="0" runat="server" ID="Body1">
		<form id="Form1" method="post" runat="server">
			
			<cc1:OrderHere id="OrderHere1" runat="server" Visible="False"></cc1:OrderHere>
			<table id="toplayouttable" width="98%" height="100%" cellspacing="0" cellpadding="0" border="0"
				class="CONTENT" align="center">
				<tr>
					<td id="topbar" colspan="2" height="20%" runat="server">
						<include:topbar id="idxTopBar" runat="server"></include:topbar>
					</td>
				</tr>
				<tr>
				<!--Rem SR -->
				<tr>
					<td height="97%" valign="top">
						<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td width="21%">
								</td>
								<td></td>
							</tr>
						</table>
					</td>
					<td>
						<!--Rem SR-->
						<table cellpadding="0" cellspacing="0" width="758" height="100%">
							<tr>
								<td id="contentarea" runat="server" width="100%" vAlign="top">
									<TABLE class="border_both_side" id="Table1" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<!--	<TD align="left" width="203">&nbsp;&nbsp;<A id="signinlink" style="FONT-WEIGHT: bold; FONT-SIZE: x-small; COLOR: darkblue" href="account/signin.aspx"
													runat="server"><B> AccountsCentre Sign In</B></A></TD> -->
											<TD class="errormessage" id="MessageBar" runat="server" align="left">
											</TD>
										</TR>
									</TABLE>
									<TABLE class="content" id="Table2" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<td class="Idx_Left_Border">
												<include:leftbar id="idxLeftBar" runat="server"></include:leftbar>
											</td>
											<TD id="homepage" runat="server" align="left" valign="top">
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
						<!--Rem SR-->
					</td>
				</tr>
			</table>
			</TD></TR> 
			<!--Rem SR -->
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
			</tr>
			</TABLE>
		</form>
	</body>
</HTML>
