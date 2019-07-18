 <%@ Page Language="vb" AutoEventWireup="false" Codebehind="ServicesAdmin.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServicesAdmin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<TITLE>Welcome To Accountscentre Administration</TITLE>
		<meta name="cbignore" content ="1">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
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
											<TD style="HEIGHT: 53px" align="middle"><STRONG> AccountsCenter Administration.</STRONG></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 8px" vAlign="center" align="middle"><asp:label id="lblErrorMessage" runat="server" Width="348px" Font-Bold="True" ForeColor="Red" Height="2px"></asp:label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 78px" vAlign="top" align="right">
												<TABLE class="tx1" id="Table1" style="WIDTH: 259px; HEIGHT: 54px" cellSpacing="0" cellPadding="0" width="259" border="0">
													<TR>
														<TD style="WIDTH: 91px"><STRONG>Customer ID</STRONG></TD>
														<TD align="left"><asp:textbox id="TxtCustomerId" runat="server" Width="132px" CssClass="mtbox" MaxLength="20" Height="23px"></asp:textbox></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 91px; HEIGHT: 24px"><STRONG></STRONG></TD>
														<TD style="HEIGHT: 24px" align="right">
															<P align="left">&nbsp;</P>
															<P align="left">
																<asp:button id="Button1" runat="server" Width="89px" Text="Get Services"></asp:button></P>
														</TD>
													</TR>
												</TABLE>
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
