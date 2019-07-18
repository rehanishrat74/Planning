<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MembersMember" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Member Home</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form2" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr>
					<td id="topbar" colSpan="2" height="20%" runat="server">
						<include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" style="WIDTH: 100%" width="100%" runat="server" valign="top">
						<TABLE class="content" width="100%" id="Memeberpage" cellSpacing="0" cellPadding="0" border="0">
							<TR>
								<TD vAlign="top" width="100%">
									<TABLE class="content" id="Table2" style="PADDING-LEFT: 10px; HEIGHT: 72px" cellSpacing="0"
										cellPadding="0" width="100%" border="0">
										<tr>
											<td align="left" colspan="2">
												<font size="4">
													<% =_CompanyName %>
												</font>
											</td>
											<td>
											</td>
										</tr>
										<TR>
											<TD vAlign="top" colSpan="3">
												<P align="justify">
													<TABLE id="sNotifications" style="WIDTH: 600px; BORDER-COLLAPSE: collapse" cellPadding="0"
														width="566" border="0" runat="server">
														<tr>
															<td height="30"></td>
														</tr>
														<tr>
															<td class="acc_header_backgrounds" style="HEIGHT: 20px">Online Orders</td>
														</tr>
														<tr>
															<td><table width="100%" border="0" class="content">
																	<tr>
																		<td width="2"></td>
																		<td></td>
																	</tr>
																	<tr>
																		<td><% Session("CompanyName")=_CompanyName %></td>
																		<td style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																			borderColor="#7baee3" height="5"><asp:LinkButton id="lnkOrderDetails" runat="server" CssClass="LINK-BLUE">Order Details</asp:LinkButton></td>
																	</tr>
																	<tr>
																		<td></td>
																		<td style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																			borderColor="#7baee3" height="5"><asp:LinkButton id="lnkInvoiceDetails" runat="server" CssClass="LINK-BLUE">Invoice Details</asp:LinkButton></td>
																	</tr>
																	<tr>
																		<td></td>
																		<td style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																			borderColor="#7baee3" height="5"><a class="LINK-BLUE" href="/Invoice/UpdatePayementInfo.aspx">Update 
																				Payement Information</a></td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td height="30"></td>
														</tr>
														<TR>
															<TD class="acc_header_backgrounds" style="HEIGHT: 20px">Messages &amp; 
																Notifications</TD>
														</TR>
														<TR>
															<TD vAlign="top">
																<TABLE class="text-outerborder-White_background" id="Table1" style=" BORDER-TOP-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px"
																	height="100%" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="frm-section-text" style="WIDTH: 150px; HEIGHT: 8px" bgColor="#4682b4" colSpan="2">Messages</TD>
																		<TD align="right" rowSpan="4">
																			<TABLE class="content" id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%"
																				border="0">
																				<TR>
																					<TD class="frm-section-text" style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT: 0px solid; WIDTH: 10px; HEIGHT: 14px; BORDER-RIGHT-WIDTH: 0px"
																						bgColor="#4682b4" colSpan="2">Notification</TD>
																				</TR>
																				<TR>
																					<TD style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px"
																						borderColor="#7baee3" width="5"></TD>
																					<TD id="pNotification" style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-RIGHT-WIDTH: 0px"
																						vAlign="top" borderColor="#7baee3" runat="server"></TD>
																				</TR>
																				<tr>
																					<TD style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; WIDTH: 16px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																						borderColor="#7baee3" align="right" height="5"></TD>
																					<td style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																						borderColor="#7baee3" align="right" height="5"><A class="LINK-BLUE" href="/Message/Notifications.aspx">Notifications 
																							Archive</A></td>
																				</tr>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: 0px solid; BORDER-LEFT-WIDTH: 0px; WIDTH: 150px; BORDER-BOTTOM: 0px solid; HEIGHT: 17px"
																			borderColor="#ffffff">&nbsp;Unread</TD>
																		<TD id="pUnreadMsg" style="BORDER-TOP-WIDTH: 0px; BORDER-RIGHT: 0px solid; BORDER-LEFT-WIDTH: 0px; WIDTH: 48px; HEIGHT: 17px"
																			borderColor="#7baee3" align="right" width="48" runat="server"></TD>
																	</TR>
																	<TR>
																		<TD style="BORDER-TOP-WIDTH: 0px; BORDER-RIGHT: 0px solid; BORDER-LEFT-WIDTH: 0px; WIDTH: 150px; BORDER-BOTTOM: 0px solid; HEIGHT: 15px"
																			borderColor="#ffffff">&nbsp;Total</TD>
																		<TD id="pTotalMsg" style="BORDER-TOP-WIDTH: 0px; BORDER-RIGHT: 0px solid; BORDER-LEFT-WIDTH: 0px; WIDTH: 48px; HEIGHT: 15px"
																			borderColor="#7baee3" align="right" width="48" runat="server"></TD>
																	</TR>
																	<TR>
																		<TD style="BORDER-TOP-WIDTH: 0px; BORDER-RIGHT: 0px solid; BORDER-LEFT-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px"
																			vAlign="top" borderColor="#7baee3" align="right" colSpan="2"><A class="LINK-BLUE" href="/Message/inbox.aspx">Messages 
																				Archive</A></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<!---->
														<tr valign="top" style="PADDING-TOP: 20px">
															<td colspan="2" valign="top">
																<asp:Panel runat="server" id="pnlAnnualAccountsStatus" Width="100%">
                        <TABLE class="content" cellSpacing="0" cellPadding="0" width="100%">
																		<TR>
																			<TD class="acc_header_backgrounds" vAlign="middle" colSpan="9" height="20"><STRONG>Annual 
																					Accounts Status</STRONG></TD>
																		</TR>
																		<TR>
																			<TD class="Content" style="COLOR: black" vAlign="top" colSpan="10" height="30">Incorporation 
																				Date is <STRONG>
																					<asp:Literal id="litIncDate" runat="server" Text=""></asp:Literal></STRONG>Accounts 
																				Reference Date is <STRONG>
																					<asp:Literal id="litARD" runat="server" Text=""></asp:Literal></STRONG><BR>
																			</TD>
																		</TR>
																		<TR>
																			<TD style="COLOR: black" width="100%" colSpan="9">
																				<asp:Literal id="litThereIsNoRecord" runat="server" Text="<br>There is no data available for Annual Accounts Status"></asp:Literal>
																				<asp:datagrid id="dgridAnnualAccounts" runat="server" CssClass="content" OnItemDataBound="dgridAnnualAccounts_ItemDataBound"
																					AutoGenerateColumns="False" width="100%" BorderWidth="0" ShowHeader="True" CellPadding="0"
																					CellSpacing="0">
																					<Columns>
																						<asp:TemplateColumn>
																							<HeaderTemplate>
																								<table cellspacing="0" cellpadding="0" Class="content" width="100%">
																									<tr>
																										<td width="15%" height="26" valign="middle" bgcolor="#fbfbfb"><strong>Financial Year</strong></td>
																										<td width="15%" colspan="2" valign="middle" bgcolor="#fbfbfb"><strong>ARD Date</strong></td>
																										<td width="25%" colspan="4" valign="middle" bgcolor="#fbfbfb"><strong> Submission Due 
																												Date<br>
																												(ARD +9 Months)</strong></td>
																										<td width="15%" valign="middle" bgcolor="#fbfbfb"><strong>Submitted On</strong></td>
																										<td width="30%" valign="middle" bgcolor="#fbfbfb"><strong>Accounts Status</strong></td>
																									</tr>
																								</table>
																							</HeaderTemplate>
																							<ItemTemplate>
																								<table cellpadding="0" cellspacing="0" Class="content" width="100%">
																									<tr>
																										<td width="15%" height="13" valign="top"><%# Databinder.Eval(Container.DataItem, "Year") %></td>
																										<td width="15%" colspan="2" valign="top"><%# Databinder.Eval(Container.DataItem, "ARD", "{0:d}") %></td>
																										<td width="25%" colspan="4" valign="top"><%# Databinder.Eval(Container.DataItem, "DueDate","{0:d}") %></td>
																										<td width="15%" valign="top"><%# Databinder.Eval(Container.DataItem, "SubmissionDate","{0:d}") %></td>
																										<td width="30%" valign="top"><strong>
																												<asp:Label ID=lblStatus Runat=server Text='<%# Databinder.Eval(Container.DataItem, "Status")%>'>
																												</asp:Label></strong></td>
																									</tr>
																								</table>
																							</ItemTemplate>
																						</asp:TemplateColumn>
																					</Columns>
																				</asp:datagrid></TD>
																		</TR>
																	</TABLE></FONT>
																</asp:Panel>
															</td>
														</tr>
													</TABLE>
												</P>
											</TD>
											<td valign="top" rowspan="4">
												<table>
													<tr>
														<td>
															<IMG title="Activate Gateway Services" style="WIDTH: 180px; CURSOR: hand; HEIGHT: 40px"
																onclick="GatewayRegistration();" alt="" src="/images/GatawayPin.Gif" height="40"
																width="180">
														</td>
													</tr>
													<tr>
														<td class="acc_heading">
															<asp:Literal ID="litAvailableSrv" Runat="server" Text="Available Services" Visible="False"></asp:Literal>
														</td>
													</tr>
													<tr>
														<TD id="mExpress" vAlign="middle" align="left" runat="server">
															<asp:ImageButton ID="imgBtnExpress" Runat="server" ImageUrl="/images/LogoRenewExpress.gif" title="Use Online Accounting"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD id="mAccountsProWeb" vAlign="middle" align="left" runat="server">
															<asp:ImageButton ID="imgBtnAccProWeb" Runat="server" ImageUrl="/images/LogoRenewAccountsProWeb.gif"
																title="Use Online Accounting" style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD id="mPayroll" vAlign="middle" align="left" runat="server">
															<asp:ImageButton ID="imgBtnPayroll" Runat="server" ImageUrl="/images/LogoRenewPayroll.gif" title="Use Infini Payroll"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD id="mCTReturn" vAlign="middle" align="left" runat="server">
															<asp:ImageButton ID="imgBtnCTReturn" Runat="server" ImageUrl="/images/LogoRenewCTReturn.gif" title="Use Corporation Tax Return"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD id="mSAccounts" vAlign="middle" align="left" runat="server">
															<asp:ImageButton ID="imgBtnSAccounts" Runat="server" ImageUrl="/images/LogoRenewAnnual.gif" title="Use Statutory Accounts"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD vAlign="top" align="left" runat="server" id="mCams">
															<asp:ImageButton ID="imgBtnCams" Runat="server" ImageUrl="/images/LogoRenewCams.gif" title="Use Customer Account Management"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<TD vAlign="top" align="left" runat="server" id="mDCA">
															<asp:ImageButton ID="imgBtnDCA" Runat="server" ImageUrl="/images/LogoRenewDCA.gif" title="Use Customer Account Management"
																style="CURSOR: hand"></asp:ImageButton>
														</TD>
													</tr>
													<tr>
														<td valign="top" align="left" runat="server" id="mBPLN">
															<asp:ImageButton ID="imgBtnBizPlan" Runat="server" ImageUrl="/images/LogoRenewBizPlan.gif" title="Use Biz Plan"
																style="CURSOR: hand"></asp:ImageButton>
														</td>
													</tr>
												</table>
											</td>
										</TR>
										<!--CODE COMMENT THREE-->
										<tr>
											<td colspan="2"></td>
										</tr>
										<tr>
											<td colspan="2"></td>
										</tr>
										<tr>
											<td colspan="2"></td>
										</tr>
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
			<script>
	function GatewayRegistration(){
	window.navigate("/Gateway/Registration.aspx")
	}
			</script>
		</form>
	</body>
</HTML>
