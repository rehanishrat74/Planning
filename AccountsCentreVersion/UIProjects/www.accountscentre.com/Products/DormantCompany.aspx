<%@ outputcache Location="None" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DormantCompany.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.DormantCompany" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Dormant Company</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/main.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colspan="2" height="20%" runat="server">
							<include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
							<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD id="menuares" vAlign="top" align="left" width="5%" runat="server"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
										<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server">
											<input id="returnurl" type="hidden" name="returnurl" runat="server"> 
											<!--COMPANY PROFILE-->
											<table width="778" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"
												bgcolor="#ffffff" class="border_both_side">
												<tr>
													<td height="97%" valign="top"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
															<tr valign="top">
																<td><table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
																		<tr>
																			<td align="left" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="1">
																					<tr>
																						<td valign="top">
																							<table width="100%" border="0" cellspacing="0" cellpadding="0">
																								<tr>
																									<td align="center" valign="top" class="banner_headidng"><div align="center"><img src="\images/dormant_company_accounts_ba.jpg" width="372" height="59"></div>
																									</td>
																								</tr>
																								<tr>
																									<td valign="top"><table width="97%" border="0" cellspacing="0" cellpadding="0">
																											<tr>
																												<td width="50%" align="center" valign="top">
																													<div align="center"><img src="\images/dormant_company_pic.jpg" width="219" height="192" style="WIDTH: 219px; HEIGHT: 192px"><br>
																													</div>
																												</td>
																												<td width="50%" valign="top"><div align="center">
																														<table width="264" border="0" align="left" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
																															style="WIDTH: 264px; HEIGHT: 246px">
																															<tr valign="middle" class="banner_text">
																																<td height="3" colspan="2" align="center" class="banner_text"><div align="left">
																																		<table width="100%" border="0" cellspacing="0" cellpadding="0">
																																			<tr>
																																				<td width="1">&nbsp;</td>
																																				<td valign="middle" class="banner_text"><strong> <font style="FONT-SIZE: 11pt">&nbsp;</font></strong></td>
																																			</tr>
																																		</table>
																																	</div>
																																</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td width="10" height="2" align="center" valign="top" class="banner_text">
																																	<table width="10" height="13" border="0" align="center" cellpadding="0" cellspacing="0">
																																		<tr>
																																			<td width="1" height="6"><img src="\images/blank.gif" width="2" height="2"></td>
																																		</tr>
																																		<tr>
																																			<td align="center" valign="top">&nbsp;</td>
																																		</tr>
																																	</table>
																																</td>
																																<td width="215" rowspan="4" align="left" valign="top" class="banner_text"><p>Single-click 
																																		E-filing to Companies House
																																	</p>
																																	<p>Single-click E-filing to Tax office
																																	</p>
																																</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td height="5" align="center" valign="top" class="banner_text"><table width="10" height="13" border="0" align="center" cellpadding="0" cellspacing="0">
																																		<tr>
																																			<td width="1" height="6"><img src="\images/blank.gif" width="2" height="2"></td>
																																		</tr>
																																		<tr>
																																			<td align="center" valign="top">&nbsp;</td>
																																		</tr>
																																	</table>
																																</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td height="5" align="center" valign="top" class="banner_text">&nbsp;</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td height="5" align="center" valign="top" class="banner_text">&nbsp;</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td height="5" align="center" valign="top" class="banner_text"><table width="10" height="13" border="0" align="center" cellpadding="0" cellspacing="0">
																																		<tr>
																																			<td width="1" height="6"><img src="\images/blank.gif" width="2" height="2"></td>
																																		</tr>
																																		<tr>
																																			<td align="center" valign="top">&nbsp;</td>
																																		</tr>
																																	</table>
																																</td>
																																<td align="left" class="banner_text"><p>&nbsp;</p>
																																	<p align="left">
																																		<cc1:OrderHere id="OrderHere1" runat="server" ProductCode="CP54"></cc1:OrderHere>
																																	&nbsp;
																																	<p>&nbsp;</p>
																																</td>
																															</tr>
																															<tr valign="middle" class="banner_text">
																																<td height="5" align="center" class="banner_jpg">&nbsp;</td>
																																<td align="left" class="banner_text"><div align="center"></div>
																																</td>
																															</tr>
																														</table>
																													</div>
																												</td>
																											</tr>
																										</table>
																									</td>
																								</tr>
																							</table>
																						</td>
																					</tr>
																					<tr>
																						<td valign="top"><table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
																								<tr valign="top">
																									<td width="16"><img src="\images/crv1.jpg" width="16" height="31"></td>
																									<td width="1067" valign="bottom" background="\images/crv_topbg.jpg"><table width="77%" border="0" cellspacing="0" cellpadding="0">
																											<tr>
																												<td valign="bottom" class="headding">
																													Dormant Company Accounts</td>
																											</tr>
																										</table>
																									</td>
																									<td width="17"><img src="\images/crv2.jpg" width="17" height="31"></td>
																								</tr>
																								<tr valign="top">
																									<td background="\images/crv1bg.jpg"><img src="\images/crv1bg.jpg" width="16" height="5"></td>
																									<td><table width="97%" border="0" cellspacing="5">
																											<tr>
																												<td valign="top" class="main_text"><p>A company that has no significant financial 
																														transactions during a financial year is a dormant company. It means that the 
																														accounts submitted are in an abbreviated form and do not carry much detail. 
																														There is also no requirement for a profit and loss account or a directors' 
																														report to be included in the abbreviated accounts.
																													</p>
																													<p>
																														Accounts Centre offers e-filing of your dormant company's accounts as well as 
																														annual return for a bargain price of £75 only.
																													</p>
																												</td>
																											</tr>
																											<tr>
																												<td valign="top">&nbsp;</td>
																											</tr>
																										</table>
																									</td>
																									<td background="\images/crv_2linebg.jpg"><img src="\images/crv_2linebg.jpg" width="17" height="16"></td>
																								</tr>
																								<tr valign="top">
																									<td><img src="\images/crv_1bottom.jpg" width="16" height="10"></td>
																									<td background="\images/crv_bottomlinebg.jpg"><img src="\images/crv_bottomlinebg.jpg" width="15" height="10"></td>
																									<td><img src="\images/crv_bottom1.jpg" width="17" height="10"></td>
																								</tr>
																							</table>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</table>
																</td>
																<!--*****************-->
																<td width="21%"><table width="100%" border="0" cellpadding="0" cellspacing="0">
																		<tr align="left" valign="top">
																			<td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
																					<tr>
																						<td colspan="2"><img src="\images/emptyimage.jpg" width="2" height="5"></td>
																					</tr>
																					<tr>
																						<td width="8%" height="21" background="\images/right_left.jpg">&nbsp;</td>
																						<td width="92%" background="\images/right_top.jpg">&nbsp;</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																		<tr valign="top">
																			<td width="2%">&nbsp;</td>
																			<td width="98%"><table width="100%" border="0" align="center" cellpadding="0" cellspacing="5">
																					<tr>
																						<td align="center" valign="top" class="right_side_text"><p class="url_text2"><a href="/Products/ExtremeAccounting.aspx" class="url_text2">Extreme 
																									Accounting £500 </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="right_side_text"><a href="/Products/ExtremeAccounting.aspx"><img src="\images/extreme_small_pic.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle" class="url_text2"><p>
																								<a href="/Products/ExtremeAccounting.aspx" class="url_text2">On a tight deadline? 
																									Prepare and file your accounts in
																									<br>
																									7 workings days! </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="right_side_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="style4"><p class="url_text2"><a href="/Products/OutSourcedAccounts.aspx" class="url_text2">Outsourced 
																									Accounts Department £300 </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle" class="right_side_text"><a href="/Products/OutSourcedAccounts.aspx"><img src="\images/outsourced_small_pic.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top"><span class="url_text"><font color="#ffffff" size="2" face="Arial" class="url_text2"></font></span>
																							<p class="url_text2"><a href="/Products/OutSourcedAccounts.aspx" class="url_text2">Handles 
																									daily bookkeeping; Files VAT and tax returns; Deals with customer and supplier 
																									enquiries. </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle" class="url_text2"><p><a href="/Products/DormantCompany.aspx" class="url_text2">Dormant 
																									Company Accounts £75 </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle"><a href="/Products/DormantCompany.aspx"><img src="\images/dormant_samll_pic.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text2"><a href="http://www.o-c.com" class="url_text2">
																							</a>
																							<p><a href="/Products/DormantCompany.aspx" class="url_text2">Single-click E-filing to 
																									both, Companies House and Tax office</a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle"><p class="url_text2"><a href="/Products/ManagedE-CommerceWebsitesBanner.aspx" class="url_text2">Managed 
																									E-commerce Websites
																									<br>
																									£50 per month </a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="middle" class="right_side_text"><a href="/Products/ManagedE-CommerceWebsitesBanner.aspx"><img src="\images/managed_e-commerce_small.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text2">
																							<p><a href="/Products/ManagedE-CommerceWebsitesBanner.aspx" class="url_text2">Pro-active 
																									E-commerce web site management Complete web site creation and support services</a>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text2"><a href="/Products/MerchantAccountOpening.aspx" class="url_text2">Merchants 
																								Accounts</a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text2"><a href="/Products/MerchantAccountOpening.aspx"><img src="\images/merchant_account_smoll.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><span class="url_text2"><a href="/Products/MerchantAccountOpening.aspx" class="url_text2">Merchant 
																									processing solutions for both on- and off-shore companies</a></span></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><a href="/Products/Profile.aspx"><img src="\images/profile_small.jpg" width="66" height="61" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><span class="url_text2"><a href="/Products/Profile.aspx" class="url_text2">Profile</a></span></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><img src="\images/greyline.jpg" width="102" height="1"></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><a href="/Products/FAQ.aspx"><img src="\images/formationfaq.jpg" width="71" height="62" border="0"></a></td>
																					</tr>
																					<tr>
																						<td align="center" valign="top" class="url_text"><a href="/Products/FAQ.aspx" class="url_text2">FAQ's</a></td>
																					</tr>
																				</table>
																				<div align="center"><img src="\images/greyline.jpg" width="102" height="1"></div>
																			</td>
																		</tr>
																		<!--*****************-->
																		<tr valign="top">
																			<td>&nbsp;</td>
																			<td>&nbsp;</td>
																		</tr>
																	</table>
																	<p>&nbsp;</p>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<map name="Map3">
												<area shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm">
												<area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm">
											</map>
											<!-- *************************-->
										</TD>
						</td>
					</tr>
				</TBODY>
			</table>
			</TD>
			<td id="rightbar" width="5%" runat="server"></td>
			</TR>
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
			</tr>
		</form>
		</TBODY></TABLE>
		<script>
function UpdateProfile(){
pform.action="profile.aspx?ACT=UPDATE"
pform.submit ();
}
		</script>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
