<%@ Page Language="vb" AutoEventWireup="false" Codebehind="individual.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Gatewaysindividual" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Inland Revenue Gateway -individual</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
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
						<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
							border="0">
							<TR>
								<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD id="gatewayarea" runat="server" vAlign="top" align="left" width="80%">
									<TABLE class="content" id="Table5" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD style="HEIGHT: 9px" colspan="2" class="acc_header_backgrounds">&nbsp;Individuals</TD>
										</TR>
										<TR>
											<br>
											<TD width="4" style="HEIGHT: 9px"></TD>
											<TD valign="top" style="HEIGHT: 17px">
												<P></P>
												<P></P>
												<P></P>
												<P><STRONG>Not available</STRONG></P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 21px" width="4"></TD>
											<TD style="HEIGHT: 21px" vAlign="bottom">
												<asp:Literal id="Literal1" runat="server"></asp:Literal></TD>
										</TR>
										<TR>
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
