<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CompanyList.aspx.vb" Inherits="accounts.infinibiz.Web.CompanyList"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>accounts.infinibiz.com Service Registration</title>
		<meta content="True" name="vs_snapToGrid">
		<meta content="True" name="vs_showGrid">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form2" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				bgColor="#ffffff" border="0">
				<tr>
					<td id="topbar" colSpan="2" height="100" runat="server"><include:topbar id="idxTopBar1" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" vAlign="top" align="center" width="100%" runat="server">
						<div class="scrolldiv" style="HEIGHT: 100%"><asp:panel id="pnlMessage" Visible="False" BorderWidth="1" Runat="server" Width="600px">
								<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="acc_header_backgrounds" id="Td2" height="15" runat="server" NAME="Td1">Messages
										</TD>
									<TR>
										<TD height="8"></TD>
									</TR>
									<TR>
										<TD>
											<UL>
												<LI>
													<asp:Label id="lblMessage" Width="100%" Runat="server" CssClass="rss_error_text"></asp:Label></LI></UL>
										</TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="pnlCompanyList" BorderWidth="1" Runat="server" Width="600px" Height="280px">
								<TABLE class="content" id="Memeberpage" cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD class="acc_header_backgrounds" id="Td1" height="15" runat="server" NAME="Td1">Required 
											Information
										</TD>
									</TR>
									<TR>
									</TR>
									<TR>
										<TD align="center">
											<TABLE class="text-outerborder-White_background" cellSpacing="1" cellPadding="2" width="100%"
												border="0">
												<TR>
													<TD height="8"></TD>
												</TR>
												<TR vAlign="middle" height="20">
													<TD class="link_text">
														<asp:label id="lblselectcompnany" runat="server" Width="520px">Please select the company from the list below:</asp:label>:</TD>
												</TR>
												<TR>
													<TD></TD>
												</TR>
												<TR>
													<TD>
														<asp:listbox id="listCompany" Width="100%" Runat="server" CssClass="link_text" Font-Size="8pt"
															BorderStyle="Groove" SelectionMode="Single" Rows="10"></asp:listbox></TD>
												</TR>
												<TR>
													<TD align="center">
														<TABLE height="30" width="511">
															<TR>
																<TD class="link_text" align="left" width="200">
																	<asp:CheckBox id="chkNewCompanyOption" Runat="server" Text="Enter New Company Name" AutoPostBack="True"></asp:CheckBox>&nbsp;
																</TD>
																<TD class="link_text">
																	<asp:TextBox id="txtCompanyName" runat="server" Width="256px" Enabled="False"></asp:TextBox></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD align="center">
											<asp:Panel id="pnlResellerQuestion" Runat="server" Visible="False">
												<TABLE cellSpacing="1" cellPadding="2" width="521">
													<TR class="link_text">
														<TD width="87">
															<asp:Label id="lblCurrencyDB" Runat="server">Currency</asp:Label></TD>
														<TD>
															<asp:DropDownList id="ddlCurrencyDB" Width="298px" Runat="server"></asp:DropDownList></TD>
													</TR>
													<TR class="link_text" id="trAPIResellerDomainInfo" runat="server">
														<TD width="87">
															<asp:Label id="Label2" Runat="server">Domain Name</asp:Label></TD>
														<TD>
															<asp:TextBox id="txtAPIResellerURL" Width="288px" Runat="server"></asp:TextBox>
															<asp:Label id="Label3" runat="server" ForeColor="Gray">(www.yourdomain.com)</asp:Label></TD>
													</TR>
													<TR class="link_text" id="trDomainInfo" runat="server">
														<%--
														<TD width="87">
															<asp:Label id="lblDomainName" Runat="server" Visible="False">Domain Name</asp:Label></TD>
														<TD>
															<TABLE class="link_text" cellSpacing="1" cellPadding="2">
																<TR>
																	<TD>
																		<asp:Label id="Label4" runat="server" Visible="False">www.</asp:Label></TD>
																	<TD>
																		<asp:TextBox id="txtURL" Width="147px" Runat="server" Visible="False"></asp:TextBox>
																		<asp:Label id="Label1" Runat="server" Visible="False">.</asp:Label>
																		<asp:DropDownList id="ddlExtention" Runat="server" Visible="False">
																			<asp:ListItem Value="com">com</asp:ListItem>
																			<asp:ListItem Value="net">net</asp:ListItem>
																			<asp:ListItem Value="org">org</asp:ListItem>
																			<asp:ListItem Value="euc.eu">euc.eu</asp:ListItem>
																			<asp:ListItem Value="eu">eu</asp:ListItem>
																			<asp:ListItem Value="co.uk">co.uk</asp:ListItem>
																		</asp:DropDownList></TD>
																	<TD>
																		<asp:button id="btnCheckAvailability" runat="server" Width="104px" Visible="False" CssClass="acc_mbuttonon"
																			Text="Check Availability"></asp:button></TD>
																	<TD></TD>
																</TR>
															</TABLE>
														</TD>
													--%>
													</TR>
													<TR class="link_text">
														<TD colSpan="2">
															<asp:Label id="lblemail" runat="server" Text="Do you want to authorize us to contact your customer for email reminders:"></asp:Label>
															<asp:DropDownList id="ddlemail" runat="server">
																<asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
																<asp:ListItem Value="0">No</asp:ListItem>
															</asp:DropDownList></TD>
													</TR>
												</TABLE>
											</asp:Panel></TD>
									</TR>
									<TR>
										<TD height="5"></TD>
									</TR>
									<TR>
										<TD align="center">
											<asp:button id="btnContinue" runat="server" CssClass="acc_mbuttonon" Text="Continue"></asp:button></TD>
									</TR>
								</TABLE>
								<TABLE width="100%" align="center">
									<TR>
										<TD class="link_text" align="center">
											<DIV id="waitmsg" style="DISPLAY: none" name="waitmsg">Please wait, your service is 
												being activated .....</DIV>
										</TD>
									</TR>
									<TR>
										<TD align="center">
											<SCRIPT language="javascript" src="..\Library\javascript\xp_progress.js"></SCRIPT>
											<SCRIPT>
											var bar1= createBar(300,15,'white',1,'black','gray',85,7,3,"");
											bar1.hideBar();
											</SCRIPT>
										</TD>
									</TR>
								</TABLE>
							</asp:panel>
							<!-- END COMPANY LIST PANEL --><asp:panel id="pnlSuccess" runat="server" BorderWidth="1" Width="600px" HorizontalAlign="Center">
								<TABLE id="Table1" height="86" cellSpacing="1" cellPadding="1" width="472" border="0">
									<TR>
										<TD vAlign="top" align="left" colSpan="2">
											<asp:Label id="lblwaitmsg" runat="server" Width="100%" CssClass="link_text">Congratulation! Your [SERVICENAME] has been activated. You can now use your service.</asp:Label></TD>
									</TR>
									<TR>
										<TD vAlign="top" align="center" width="50%">
											<asp:Button id="btnStartAC" runat="server" CssClass="acc_mbuttonon" Text="Start using Accounting Service"></asp:Button>
											<asp:Button id="btnGotoResellerSystem" runat="server" Visible="False" CssClass="acc_mbuttonon"
												Text="Start using Reseller System"></asp:Button></TD>
										<TD vAlign="top" align="center" width="50%">
											<asp:Button id="btnMyAccount" runat="server" CssClass="acc_mbuttonon" Text="My Account"></asp:Button></TD>
									</TR>
								</TABLE>
							</asp:panel></div>
					</td>
				</tr>
				<tr>
					<td id="bottombar" colSpan="2" height="29" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</form>
		<script language="javascript">
	function wait()
	{
		waitmsg.style.display= "";
		bar1.showBar();
	}
		</script>
	</body>
</HTML>
