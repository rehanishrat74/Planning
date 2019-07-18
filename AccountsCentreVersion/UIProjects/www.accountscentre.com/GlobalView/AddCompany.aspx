<%@ Page Language="vb" AutoEventWireup="false" Codebehind="AddCompany.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.AddCompany" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
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
		<form id="frmAddCompany" method="post" runat="server">
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
										<table cellSpacing="0" cellPadding="0">
											<tr>
												<!-- #Include virtual="..\Include\Span.htm"-->
											</tr>
											<tr>
												<td style="BACKGROUND-COLOR: #34699e" colSpan="2" height="60"><font style="FONT-WEIGHT: bold; FONT-SIZE: 17pt" color="#ffffff">&nbsp;&nbsp;Add 
														Company&nbsp; </font>
													<br>
													<FONT style="FONT-SIZE: 8pt" color="#ffffff">&nbsp;&nbsp;&nbsp;Accounts Centre will 
														allow complete access to our services... </FONT>
												</td>
											</tr>
											<tr>
												<td class="content" style="HEIGHT: 37px" vAlign="top" width="565" bgColor="#edf3f8"
													colSpan="2" height="30"><br>
													<font size="3"><SPAN class="content">&nbsp;&nbsp; To add another Accounts Centre 
															registered company into Global View Please enter information&nbsp; &nbsp; 
															&nbsp;to begin..</SPAN> </font>
													<br>
													<br>
												</td>
											</tr>
											<tr>
												<td class="content" vAlign="middle" width="90" bgColor="#fbfbfb"><font size="1">&nbsp;&nbsp;<STRONG>User 
															ID<br>
														</STRONG>&nbsp;&nbsp;<STRONG>Password</STRONG></font>
													<P></P>
													<p align="left">&nbsp;</p>
												</td>
												<td vAlign="middle" noWrap align="left" width="314" bgColor="#fbfbfb">
													<p><br>
														<asp:textbox id="txtUserID" runat="server" cssclass="mtbox" name="txtUserID" Width="200px"></asp:textbox><br>
														<asp:textbox id="txtPassword" runat="server" cssclass="mtbox" name="txtPassword" Width="200px"
															TextMode="Password"></asp:textbox></p>
													<font color="#000080">
														<asp:button id="btnUpdate" onmouseover="this.className='MBUTTONON';" style="FONT-WEIGHT: bold"
															onmouseout="this.className='MBUTTON';" cssclass="MBUTTON" name="btnUpdate" Runat="server"
															value="Update" Width="120px" Text="Update Global View"></asp:button>
														<asp:button id="btnCancel" onmouseover="this.className='MBUTTONON';" style="FONT-WEIGHT: bold"
															onmouseout="this.className='MBUTTON';" Width="72px" name="btnUpdate" cssclass="MBUTTON"
															Text="Cancel" value="Update" Runat="server"></asp:button></font>
													<p></p>
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
								</tr>
							</TBODY>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
