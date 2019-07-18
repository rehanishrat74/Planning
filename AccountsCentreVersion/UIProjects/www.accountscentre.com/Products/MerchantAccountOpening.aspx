<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MerchantAccountOpening.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MerchantAccountOpening" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ outputcache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - MerchantAccountOpening</title>
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
		<LINK href="main.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { BACKGROUND-COLOR: #ffffff }
	.style4 { COLOR: #4173ae; FONT-FAMILY: "Lucida Grande", Arial, Verdana, sans-serif; TEXT-DECORATION: none }
	.style5 { FONT-SIZE: 14px }
	.style6 { FONT-SIZE: 10px }
		</style>
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
							<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD id="menuares" vAlign="top" align="left" width="5%" runat="server"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
										<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server"><input id="returnurl" type="hidden" name="returnurl" runat="server">
											<!--COMPANY PROFILE-->
											<table class="border_both_side" height="100%" cellSpacing="0" cellPadding="0" width="778"
												align="center" bgColor="#ffffff" border="0">
												<tr>
													<td vAlign="top" height="2%">
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
														</table>
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr>
																<td vAlign="middle" bgColor="#9fc0df">
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0" dwcopytype="CopyTableRow">
																	</table>
																</td>
															</tr>
														</table>
														<map name="Map2">
															<area shape="RECT" coords="311,15,396,38" href="http://www.formationshouse.comhttps://www.formationshouse.com/search/ereg/login.php">
															<area shape="RECT" coords="407,15,496,39" href="http://www.u-d.com/">
															<area shape="RECT" coords="516,16,577,47" href="accounting.htm">
															<area shape="RECT" target="_blank" coords="611,15,662,44" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse">
															<area shape="RECT" coords="698,16,763,35" href="contact.htm">
															<area shape="RECT" coords="245,18,280,31" href="index.htm">
														</map>
													</td>
												</tr>
												<tr>
													<td vAlign="top" height="97%">
														<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr vAlign="top">
																<td>
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<tr>
																			<td class="banner_headidng" vAlign="top" align="center"><IMG height="60" src="\images/merchant_account_banner.jpg" width="525"></td>
																		</tr>
																		<TR>
																			<td vAlign="top">
																				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																					<tr>
																						<td vAlign="top">
																							<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																								<tr>
																									<td vAlign="top" align="center" width="16%"><IMG style="WIDTH: 208px; HEIGHT: 160px" height="160" src="\images/merchant_account_pic.jpg"
																											width="208"></td>
																									<td vAlign="top" width="84%"><br>
																										<table cellSpacing="0" cellPadding="0" width="320" align="left" bgColor="#ffffff" border="0">
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" width="9" height="5"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left" width="218">Complete Merchant solution</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td vAlign="middle" align="center" height="5"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left">Easy set up process</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="5"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left">Merchant account setup</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td vAlign="middle" align="center" height="5"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left">Zero initial deposit required!</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td vAlign="middle" align="center" height="5"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left">Credit / Debit card processing facilities
																												</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="2"><IMG height="5" src="\images/greenbt.jpg" width="5"></td>
																												<td class="banner_text" align="left">Accounting services</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="1">&nbsp;</td>
																												<td class="banner_text" align="left">&nbsp;</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="2" rowSpan="2">&nbsp;</td>
																												<td class="banner_text" align="left"><font color="#ff0000">*</font><em><font size="1">Rates 
																															may vary</font></em></td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td class="banner_text" align="left">&nbsp;</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="5" rowSpan="2">&nbsp;</td>
																												<td class="banner_text" align="left">
																													<div align="center"><cc1:OrderHere id="OrderHere1" runat="server" ProductCode="CP36"></cc1:OrderHere></ASP:IMAGEBUTTON></div>
																												</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td class="banner_text" align="left">&nbsp;</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td align="center" height="5" rowSpan="2">&nbsp;</td>
																												<td class="banner_text" align="left">
																													<div align="center"><a href="http://www.formationshouse.com/optional_services.htm"><IMG height="22" src="\images/optional_services.jpg" width="119" border="0"></a>
																													</div>
																												</td>
																											</tr>
																											<tr class="banner_text" vAlign="middle">
																												<td class="banner_text" align="left">&nbsp;</td>
																											</tr>
																										</table>
																									</td>
																								</tr>
																							</table>
																						</td>
																					</tr>
																				</table>
																				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																					<tr vAlign="top">
																						<td width="16"><IMG height="31" src="\images/crv1.jpg" width="16"></td>
																						<td vAlign="bottom" background="\images/crv_topbg.jpg">
																							<table cellSpacing="0" cellPadding="0" width="77%" border="0">
																								<tr>
																									<td vAlign="bottom"><span class="headding">MERCHANT ACCOUNT </span><span class="headding">
																											OPENING</span></td>
																								</tr>
																							</table>
																						</td>
																						<td width="17"><IMG height="31" src="\images/crv2.jpg" width="17"></td>
																					</tr>
																					<tr vAlign="top">
																						<td background="\images/crv1bg.jpg"><IMG height="5" src="\images/crv1bg.jpg" width="16"></td>
																						<td>
																							<table cellSpacing="0" width="100%" border="0">
																								<tr>
																									<td vAlign="top">
																										<p class="main_text">A Merchant account is a "bank account" established with a 
																											payment processor for conducting credit / debit card transactions. Any merchant 
																											who wants to take payments through credit / debit card, must establish a 
																											merchant account. Merchant account processing services are usually provided by 
																											a bank or a third party processor to the merchant. These services include 
																											authorization of credit cards, transfer of funds through the financial 
																											institutions (MasterCard/Visa), depositing of funds to checking accounts, 
																											merchant billing, and account activity reporting.</p>
																										<p class="main_text">Formations House offers a complete Merchant solution including 
																											Merchant account and credit / debit card processing facilities. This Merchant 
																											services package is offered in combination with Formations House Accounting 
																											services package.</p>
																										<p><span class="main_text">The set up cost for this service is £150 for UK companies 
																												and £250 for offshore companies. There will also be a charge of 4%-8% per 
																												transaction for both, offshore and onshore (UK), customers. Please note that 
																												the transaction fee may be increased or decreased based on the nature of 
																												business and the business activity.</span></p>
																										<p class="main_text">It takes approx 2 weeks to complete this procedure. To order, 
																											please email your order request to <A class="url_text" href="mailto:info@formationshouse.com">
																												info@formationshouse.com</A> with a description of your business activities 
																											(intended or ongoing). After reviewing the business description and activities 
																											you will be advised about the actual transaction rate that you will be charged.</p>
																										<p class="main_text">The following information and documents are required to setup 
																											the service:</p>
																										<ul>
																											<li class="main_text">
																												<span class="main_text">Company name</span>
																											<li class="main_text">
																											Registration number
																											<li class="main_text">
																											Copy of the certificate of registration
																											<li class="main_text">
																											Copy of the articles and memorandum of association
																											<li class="main_text">
																											Two proofs of identity e.g. notarized copy of passport and notarized copy of 
																											driving license
																											<li class="main_text">
																											Two proofs of residence e.g. 2 notarized copies of utility bills
																											<li class="main_text">
																												Notarized bank statement for last three months
																											</li>
																										</ul>
																										<p align="center"><a href="http://www.formationshouse.com/optional_services.htm"><IMG height="22" src="\images/optional_services.jpg" width="119" border="0"></a>
																										</p>
																									</td>
																								</tr>
																							</table>
																						</td>
																						<td background="\images/crv_2linebg.jpg"><IMG height="16" src="\images/crv_2linebg.jpg" width="17"></td>
																					</tr>
																					<tr vAlign="top">
																						<td height="11"><IMG height="10" src="\images/crv_1bottom.jpg" width="16"></td>
																						<td background="\images/crv_bottomlinebg.jpg"><IMG height="10" src="\images/crv_bottomlinebg.jpg" width="15"></td>
																						<td><IMG height="10" src="\images/crv_bottom1.jpg" width="17"></td>
																					</tr>
																				</table>
																			</td>
																		</TR>
																	</table>
																	<p>&nbsp;</p>
																</td>
																<!--*****************-->
																<td width="21%">
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<TBODY>
																			<tr vAlign="top" align="left">
																				<td colSpan="2">
																					<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<tr>
																							<td colSpan="2"><IMG height="5" src="\images/emptyimage.jpg" width="2"></td>
																						</tr>
																						<tr>
																							<td width="8%" background="\images/right_left.jpg" height="21">&nbsp;</td>
																							<td width="92%" background="\images/right_top.jpg">&nbsp;</td>
																						</tr>
																					</table>
																				</td>
																			</tr>
																			<tr vAlign="top">
																				<td width="2%">&nbsp;</td>
																				<td width="98%">
																					<table cellSpacing="5" cellPadding="0" width="100%" align="center" border="0">
																						<tr>
																							<td class="right_side_text" vAlign="top" align="center">
																								<p class="url_text2"><A class="url_text2" href="/Products/ExtremeAccounting.aspx">Extreme 
																										Accounting £500 </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="right_side_text" vAlign="top" align="center"><A href="/Products/ExtremeAccounting.aspx"><IMG height="61" src="\images/extreme_small_pic.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="middle" align="center">
																								<p><A class="url_text2" href="/Products/ExtremeAccounting.aspx">On a tight deadline? 
																										Prepare and file your accounts in
																										<br>
																										7 workings days! </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="right_side_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td class="style4" vAlign="top" align="center">
																								<p class="url_text2"><A class="url_text2" href="/Products/OutSourcedAccounts.aspx">Outsourced 
																										Accounts Department £300 </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="right_side_text" vAlign="middle" align="center"><A href="/Products/OutSourcedAccounts.aspx"><IMG height="61" src="\images/outsourced_small_pic.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td vAlign="top" align="center"><span class="url_text"><font class="url_text2" face="Arial" color="#ffffff" size="2"></font></span>
																								<p class="url_text2"><A class="url_text2" href="/Products/OutSourcedAccounts.aspx">Handles 
																										daily bookkeeping; Files VAT and tax returns; Deals with customer and supplier 
																										enquiries. </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="middle" align="center">
																								<p><A class="url_text2" href="/Products/DormantCompany.aspx">Dormant Company Accounts 
																										£75 </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td vAlign="middle" align="center"><A href="/Products/DormantCompany.aspx"><IMG height="61" src="\images/dormant_samll_pic.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="top" align="center"><a class="url_text2" href="http://www.o-c.com"></a>
																								<p><A class="url_text2" href="/Products/DormantCompany.aspx">Single-click E-filing to 
																										both, Companies House and Tax office</A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td vAlign="middle" align="center">
																								<p class="url_text2"><A class="url_text2" href="/Products/ManagedE-CommerceWebsitesBanner.aspx">Managed 
																										E-commerce Websites
																										<br>
																										£50 per month </A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="right_side_text" vAlign="middle" align="center"><A href="/Products/ManagedE-CommerceWebsitesBanner.aspx"><IMG height="61" src="\images/managed_e-commerce_small.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="top" align="center">
																								<p><A class="url_text2" href="/Products/ManagedE-CommerceWebsitesBanner.aspx">Pro-active 
																										E-commerce web site management Complete web site creation and support services</A>
																								</p>
																							</td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="top" align="center"><A class="url_text2" href="/Products/MerchantAccountOpening.aspx">Merchants 
																									Accounts</A></td>
																						</tr>
																						<tr>
																							<td class="url_text2" vAlign="top" align="center"><A href="/Products/MerchantAccountOpening.aspx"><IMG height="61" src="\images/merchant_account_smoll.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><span class="url_text2"><A class="url_text2" href="/Products/MerchantAccountOpening.aspx">Merchant 
																										processing solutions for both on- and off-shore companies</A></span></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><A href="/Products/Profile.aspx"><IMG height="61" src="\images/profile_small.jpg" width="66" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><span class="url_text2"><A class="url_text2" href="/Products/Profile.aspx">Profile</A></span></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><A href="/Products/FAQ.aspx"><IMG height="62" src="\images/formationfaq.jpg" width="71" border="0"></A></td>
																						</tr>
																						<tr>
																							<td class="url_text" vAlign="top" align="center"><A class="url_text2" href="/Products/FAQ.aspx">FAQ's</A></td>
																						</tr>
																					</table>
																					<div align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></div>
																				</td>
																			</tr>
																<!--******************--></tr>
														</table>
													</td>
												</tr>
											</table>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<!--***************--></td>
						</TD></tr>
				</TBODY>
			</table>
			</TD>
			<td id="rightbar" width="5%" runat="server"></td>
			</TR>
			<tr>
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
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
