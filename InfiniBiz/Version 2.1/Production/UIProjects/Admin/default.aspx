<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.admin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Welcome To Accountscentre Administration</TITLE>
		
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<meta name="cbignore" content ="1">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<!--	<!--#INCLUDE VIRTUAL="/include/header.htm"-->
	</HEAD>
	<BODY bgColor="#ffffff" leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<table class="tx1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr vAlign="top">
				<td style="HEIGHT: 3px" bgColor="#d3d3d3" colSpan="2"></td>
				<td width="3%" background="images/line.jpg" rowSpan="3"><IMG height="6" src="line.jpg" width="61"></td>
			</tr>
			<tr vAlign="top">
				<td style="WIDTH: 188px; HEIGHT: 122px" width="188"></td>
				<td style="HEIGHT: 122px" vAlign="top" align="left" width="95%">
					<TABLE class="tx1" id="Table2" style="WIDTH: 721px; HEIGHT: 318px" height="318" cellSpacing="0" cellPadding="0" width="721" border="0">
						<TR>
							<TD vAlign="top" align="middle">
								<form id="Form1" action="" runat="server">
									<TABLE class="tx1" id="Table3" style="WIDTH: 287px; HEIGHT: 220px" cellSpacing="2" cellPadding="0" width="287" border="0">
										<TR>
											<TD style="HEIGHT: 53px" align="middle"><STRONG>Welcome to AccountsCenter 
													Administration website.</STRONG></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 8px" vAlign="center" align="middle"><asp:label id="Label3" runat="server" Width="241px" Font-Bold="True" ForeColor="Red" Height="2px"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 78px" vAlign="top" align="middle">
												<TABLE class="tx1" id="Table1" style="WIDTH: 259px; HEIGHT: 54px" cellSpacing="0" cellPadding="0" width="259" border="0">
													<TR>
														<TD style="WIDTH: 104px"><STRONG>User ID</STRONG></TD>
														<TD align="right"><asp:textbox id="TextBox1" runat="server" Width="150px" CssClass="mtbox" MaxLength="20"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 104px; HEIGHT: 24px"><STRONG>Password</STRONG></TD>
														<TD style="HEIGHT: 24px" align="right"><asp:textbox id="TextBox2" runat="server" Width="150px" CssClass="mtbox" MaxLength="20" TextMode="Password"></asp:textbox></TD>
													</TR>
												</TABLE>
												<P>&nbsp;&nbsp;&nbsp;
													<asp:button id="Button1" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';" runat="server" Width="53px" Font-Bold="True" CssClass="MBUTTON" Text="Sign In"></asp:button></P>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 33px">
												<BR>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 25px" vAlign="top" align="right"></TD>
										</TR>
									</TABLE>
								</form>
							</TD>
						</TR>
					</TABLE>
				</td>
			</tr>
		</table>
	</BODY>
</HTML>
