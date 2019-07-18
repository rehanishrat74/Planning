<%@ Register TagPrefix="uc1" TagName="IndexHeader" Src="../Library/components/IndexHeader.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="toolkit_error.aspx.vb" Inherits="accounts.infinibiz.Web.ErrorPage"%>
<%@ Register TagPrefix="uc1" TagName="IndexLeft" Src="../Library/components/IndexLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="BottomBar" Src="../Library/components/BottomBar.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<style type="text/css">.style1 { COLOR: #97b1d0 }
	.style2 { COLOR: #4074ad }
	BODY { BACKGROUND-COLOR: #ffffff }
		</style>
		<LINK href="/library/style/indexstyle.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<script language="JavaScript1.2" src="/library/javascript/stm31.js" type="text/javascript"></script>
		<style type="text/css">.style1 { COLOR: #97b1d0 }
	.style2 { COLOR: #4074ad }
	BODY { BACKGROUND-COLOR: #ffffff }
		</style>
		<meta name="cbignore" content="1">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="CONTENT" id="layouttable" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td id="topbar" colspan="2" height="20%" runat="server">
						<!--_____________________________________________________________________________-->
						<table class="border_both_side" id="Table12" height="100%" cellSpacing="0" cellPadding="0"
							width="100%" align="center" bgColor="#ffffff" border="0">
							<tr>
								<td vAlign="top">
									<uc1:IndexHeader id="IndexHeader1" runat="server"></uc1:IndexHeader>
								</td>
							</tr>
						</table>
						<!--______________________________________________________________________________-->
					</td>
				</TR>
				<TR>
					<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%">
						<!--___________--> z 
						<!--___________-->
					</TD>
					<TD id="contentarea" vAlign="top" width="95%" runat="server">
						<TABLE id="Table1" cellSpacing="5" cellPadding="5" width="100%" border="0">
							<TR>
								<TD vAlign="top" height="29">
									<asp:Label id="lblErrorHeading" runat="server" CssClass="acc_error_heading" text="We are experiencing technical difficulties in loading this page."></asp:Label></TD>
							</TR>
							<TR>
								<TD vAlign="top"><FONT size="2">
										<P>
											<asp:Label id="lblErrorText" runat="server" CssClass="acc_error_text" text="We apologise for this error as we could not comply with your request. A notification of this error has been sent to our systems administrators who are already working to resolve this problem."></asp:Label>
									</FONT></P></TD>
							</TR>
						</TABLE>
						<asp:Button id="btnBack" runat="server" CssClass="acc_mbutton" Text="Back"></asp:Button>
					</TD>
					<TD id="rightbar" width="5%" runat="server"></TD>
				</TR>
				<TR>
					<td id="bottombar" colspan="2" height="2%" runat="server">
						<uc1:BottomBar id="BottomBar1" runat="server"></uc1:BottomBar>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
