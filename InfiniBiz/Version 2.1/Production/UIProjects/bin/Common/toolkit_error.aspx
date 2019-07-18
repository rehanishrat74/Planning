<%@ Page Language="vb" AutoEventWireup="false" Codebehind="toolkit_error.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ErrorPage"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<style type="text/css">.style1 { COLOR: #97b1d0 }
	.style2 { COLOR: #4074ad }
	BODY { BACKGROUND-COLOR: #ffffff }
	</style>
	<HEAD>
		<title>ErrorPage</title>
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
									<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr vAlign="top">
											<td align="left" width="2%"><IMG height="118" src="/images/main_logo.jpg" width="132">
											</td>
											<td align="right" width="98%">
												<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td vAlign="top" align="left" bgColor="#fcfcfc" height="81"><table width="100%" height="100%" cellpadding="0" cellspacing="0">
																<tr valign="top">
																	<td align="center"><img src="/images/name.jpg" width="377" height="81"></td>
																	<td align="right"><IMG SRC="/images/formationslogo.jpg" width="228" height="81" border="0" usemap="#Map"></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td vAlign="middle" align="right" height="38">
															<table id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="645" align="right"
																background="/images/blue_bg.jpg" border="0">
																<tr vAlign="middle">
																	<td class="text_fild" align="left" width="12%">&nbsp;</td>
																	<td class="text_fild" align="center" width="7%"><span class="link_text">Search Site</span>
																	</td>
																	<td class="text_fild" align="center" width="15%"><span class="link_text"><asp:textbox id="q" CssClass="text_box" Runat="server" Width="300px"></asp:textbox></span></td>
																	<td class="text_fild" align="center" width="2%"><asp:linkbutton id="btnGO" runat="server" Text="Go" Cssclass="new_customermain_text"></asp:linkbutton></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="right" background="/images/buttons_bg_blue.jpg" bgColor="#4074ad">
												<table cellSpacing="0" cellPadding="0" width="100%" background="/images/buttons_bg_blue.jpg"
													border="0">
													<tr>
														<td width="1"><IMG height="32" src="/images/centre_for_global_business.jpg" width="211"></td>
														<td>
															<table cellSpacing="0" cellPadding="0" width="100" align="right" border="0">
																<tr>
																	<td><A href="http://www.accountscentre.com"><IMG src="/images/home_2.jpg" border="0"></A></td>
																	<td><A href="http://services.centre.biz/?ref=ac"><IMG src="/images/MyAccount.jpg" border="0"></A></td>
																	<td><a href="http://webmail.formationshouse.com"><IMG src="/images/checkemail.jpg" border="0"></a></td>
																	<td><a href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"
																			target="_blank"><IMG src="/images/support.jpg" border="0"></a></td>
																	<td><A href="http://www.formationshouse.com/contact_details.htm"><IMG src="/images/contactus.jpg" border="0"></A></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
												<map name="Map2">
													<area shape="RECT" coords="16,10,71,35" href="/default.aspx">
													<area shape="RECT" coords="82,12,155,42" href="http://www.formationshouse.com/search/ereg/login.php">
													<area shape="RECT" coords="173,16,263,45" href="http://www.u-d.com">
													<area shape="RECT" coords="274,11,346,41" href="http://webmail.formationshouse.com/">
													<area shape="RECT" coords="361,14,425,40" href="/default.aspx">
													<area shape="RECT" target="_blank" coords="440,10,489,44" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse">
													<area shape="RECT" coords="503,6,573,37" href="http://www.formationshouse.com/contact_details.htm">
												</map>
											</td>
										</tr>
										<tr>
											<td vAlign="middle" bgColor="#9fc0df">
												<table id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr vAlign="middle">
														<td width="1%" background="/images/bg2.jpg" height="26">
															<table id="Table7" cellSpacing="2" cellPadding="0" width="95%" border="0">
																<tr>
																	<td><IMG height="31" src="/images/phone.jpg" width="565" useMap="#Map3Map" border="0"></td>
																</tr>
															</table>
														</td>
														<td align="right" width="1%" height="26"><IMG height="28" src="/images/icon2.JPG" width="35">
															<asp:dropdownlist id="ddlACLanguages" runat="server" AutoPostBack="True">
																<asp:ListItem Value="ENGLISH" Selected="True">English</asp:ListItem>
															</asp:dropdownlist></td>
													</tr>
												</table>
												<MAP name="Map3Map">
													<AREA shape="RECT" coords="172,8,299,41" href="http://www.formationshouse.com/fr/index.htm">
													<AREA shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm">
												</MAP>
											</td>
										</tr>
									</table>
									<!--MENU-->
									<table id="tblMenu" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
										<tr>
											<td align="right" width="75%" bgColor="#4173ae" height="30">
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<!--______________________________________________________________________________-->
					</td>
				</TR>
				<TR>
					<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%">
						<!--___________-->
						<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
							<tr valign="top">
								<td width="21%"><table width="153" border="0" cellpadding="0" cellspacing="0">
										<tr valign="top">
											<td height="5" colspan="2" align="left"><img src="\images/emptyimage.jpg" width="2" height="5"></td>
										</tr>
										<tr valign="top">
											<td width="136" align="left" background="\images/crv_topbg.jpg"><img src="\images/crv_services.jpg" width="61" height="31"></td>
											<td width="17"><img src="\images/crv2.jpg" width="17" height="31"></td>
										</tr>
										<tr valign="top">
											<td>
												<table width="163" border="0" align="left" cellpadding="1" cellspacing="0" bgcolor="#ffffff">
													<tr valign="middle">
														<td width="8" height="23" align="center" style="WIDTH: 8px; HEIGHT: 23px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="152" align="left" class="link_text" style="HEIGHT: 23px"><a href="http://www.formationshouse.com/company_formation.htm" class="link_text_over">UK&nbsp; 
																Company Registration</a>
														</td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.formationshouse.com/search/readymade.php" class="link_text_over">Readymade 
																Companies</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.o-c.com" class="link_text_over">Offshore 
																Companies</a></td>
													</tr>
													<tr valign="middle">
														<td height="18" align="center" style="WIDTH: 8px; HEIGHT: 18px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text" style="HEIGHT: 18px"><a href="http://www.accountscentre.com" class="link_text_over">Accountancy 
																Service</a></td>
													</tr>
													<tr valign="middle">
														<td height="19" align="center" style="WIDTH: 8px; HEIGHT: 19px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text" style="HEIGHT: 19px"><a href="http://www.londoncenter.com" class="link_text_over">Virtual 
																London Office</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.graphics4less.com" class="link_text_over">Logo 
																Design</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="89" align="left" class="link_text"><a href="http://www.formationshouse.com/trademark.htm" class="link_text_over">Trademarks</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.formationshouse.com/bank_account_opening_uk.htm" class="link_text_over">Bank 
																Accounts</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.accountscentre.com" class="link_text_over">Payroll 
																Service</a></td>
													</tr>
													<tr valign="middle">
														<td height="18" align="center" style="WIDTH: 8px; HEIGHT: 18px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text" style="HEIGHT: 18px"><a href="http://www.graphics4less.com" class="link_text_over">Business 
																Cards</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td align="left" class="link_text"><a href="http://www.graphics4less.com" class="link_text_over">Stationery 
																Design</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="89" align="left" class="link_text"><a href="http://www.graphics4less.com" class="link_text_over">Website 
																Design</a></td>
													</tr>
													<tr valign="middle">
														<td height="17" align="center" style="WIDTH: 8px; HEIGHT: 17px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text" style="HEIGHT: 17px"><a href="http://www.formationshouse.com/webhosting_services.htm" class="link_text_over">Hosting</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.londoncenter.com" class="link_text_over">Mailing 
																Address</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.londoncenter.com" class="link_text_over">Phone 
																Answering</a></td>
													</tr>
													<tr valign="middle">
														<td height="17" align="center" style="WIDTH: 8px; HEIGHT: 17px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text" style="HEIGHT: 17px"><a href="http://www.accountscentre.com/Products/MerchantAccountOpening.aspx" class="link_text_over">Merchant 
																Accounts</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.infinishops.com" class="link_text_over">E-Commerce 
																Sites</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.formationshouse.com/vat_registration.htm" class="link_text_over">Vat 
																Registration</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" valign="middle" class="link_text"><a href="http://www.formationshouse.com/business_education.htm" class="link_text_over">Business 
																Education</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center" style="WIDTH: 8px"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.formationshouse.com/email.htm" class="link_text_over">Email</a></td>
													</tr>
												</table>
											</td>
											<td background="\images/crv_2linebg.jpg"><img src="\images/crv_2linebg.jpg" width="17" height="16"></td>
										</tr>
										<tr valign="top">
											<td background="\images/crv_bottomlinebg.jpg"><img src="\images/crv_bottomlinebg.jpg" width="15" height="10"></td>
											<td><img src="\images/crv_bottom1.jpg" width="17" height="10"></td>
										</tr>
									</table>
									<table width="153" border="0" cellpadding="0" cellspacing="0">
										<tr valign="top">
											<td width="136" align="left" background="\images/crv_topbg.jpg"><img src="\images/product22.jpg" width="64" height="31"></td>
											<td width="17"><img src="\images/crv2.jpg" width="17" height="31"></td>
										</tr>
										<tr valign="top">
											<td><table width="163" border="0" align="left" cellpadding="1" cellspacing="0" bgcolor="#ffffff">
													<tr valign="middle">
														<td width="10" height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.formationshouse.com" class="link_text_over">Formations 
																House</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.o-c.com" class="link_text_over">Offshore 
																Centre</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.accountscentre.com" class="link_text_over">Accounts 
																Centre</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.londoncenter.com" class="link_text_over">London 
																Center</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.graphics4less.com" class="link_text_over">Graphics4less</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.infinioffice.com" class="link_text_over">InfiniOffice</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.accountscentre.com" class="link_text_over">InfiniAccounts</a></td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text">InfiniPlan</td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text">Biz School</td>
													</tr>
													<tr valign="middle">
														<td height="5" align="center"><img src="\images/greenbt.jpg" width="5" height="5"></td>
														<td width="142" align="left" class="link_text"><a href="http://www.bizstarterpack.com" class="link_text_over">Biz 
																Starter Pack</a></td>
													</tr>
												</table>
											</td>
											<td background="\images/crv_2linebg.jpg"><img src="\images/crv_2linebg.jpg" width="17" height="16"></td>
										</tr>
										<tr valign="top">
											<td background="\images/crv_bottomlinebg.jpg"><img src="\images/crv_bottomlinebg.jpg" width="15" height="10"></td>
											<td><img src="\images/crv_bottom1.jpg" width="17" height="10"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
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
						<table width='100%' border='0' align='center' cellpadding='0' cellspacing='0' bgcolor='#ffffff'
							class='border_both_side'>
							<tr>
								<td colspan='2' align='right' valign='top'><img src='/images/bottom1.jpg' width='558' height='23'></td>
							</tr>
							<tr>
								<td width='68%' align='right' valign='middle' bgcolor='#4b94cf'><div align='center' class='link_text'>
									</div>
								</td>
								<td width='32%' align='right' valign='top' bgcolor='#4b94cf'><img src='/images/bottom2.jpg' width='321' height='23'></td>
							</tr>
						</table>
					</td>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
