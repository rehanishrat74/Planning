<%@ outputcache Location="None" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Profile.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.Profile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Member Profile</title>
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
												<form name='loginform' action="http://www.formationshouse.com/logaction.php">
												</form>
												<tr>
													<td height="97%" valign="top"><table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
															<tr valign="top">
																<td><table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
																		<tr>
																			<td align="left" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="1">
																					<tr>
																						<td valign="top" style="HEIGHT: 2px">
																							<p><img src="\images/emptyimage.jpg" width="2" height="5"></p>
																						</td>
																					</tr>
																					<tr>
																						<td valign="top"><table width="440" border="0" align="left" cellpadding="0" cellspacing="0">
																								<tr valign="top">
																									<td width="16"><img src="\images/crv1.jpg" width="16" height="31"></td>
																									<td width="1067" valign="bottom" background="\images/crv_topbg.jpg"><table width="77%" border="0" cellspacing="0" cellpadding="0">
																											<tr>
																												<td valign="bottom"><span class="headding">Profile<a name="top"></a></span></td>
																											</tr>
																										</table>
																									</td>
																									<td width="17"><img src="\images/crv2.jpg" width="17" height="31"></td>
																								</tr>
																								<tr valign="top">
																									<td background="\images/crv1bg.jpg"><img src="\images/crv1bg.jpg" width="16" height="5"></td>
																									<td><table width="560" border="0" cellspacing="5" style="WIDTH: 560px; HEIGHT: 1851px">
																											<tr>
																												<td valign="top" class="main_text"><p>Accounts Centre is a complete accounting 
																														information portal, providing accounting, business and taxation related advice. 
																														Focussed exclusively on the small to medium sized companies, Accounts Centre 
																														takes care of your accounts and tax return preparation and E-files them with 
																														the Inland Revenue, while you focus on getting the most out of your business.</p>
																													<p>Registered customers receive the quickest and most personal service simply 
																														either by phone or email. Accounts Centre utilizes a comprehensive CRM 
																														(customer relationship management) focused technology to keep its subscribers 
																														updated on all the relevant information they require. The following are the 
																														four focussed areas where Accounts Centre offers customers assistance:
																													</p>
																													<ul>
																														<li>
																															<a href="#accountancyservices" class="url_text">Accountancy Services </a>
																														<li>
																															<a href="#accountancysolutions" class="url_text">Accountancy Solutions</a>
																														<li>
																															<a href="#accountancysoftwares" class="url_text">Accountancy Softwares</a>
																														<li>
																															<a href="#accountancyproducts" class="url_text">Accountancy Products</a>
																														</li>
																													</ul>
																													<p><strong>Accountancy Services <a name="accountancyservices"></a></strong>
																													</p>
																													<p>These services are divided into the following:
																													</p>
																													<p><strong>Advisory: </strong>Accounts Centre offers free advisory and accounts 
																														review service to all customers. These services are complimentary and aim to 
																														ensure that all your accounts and returns are accurate at the time of E-filing.
																													</p>
																													<p><strong>Collection Services: </strong>Accounts Centre offers merchant processing 
																														services (Collection Services) to customers who wish to conduct online 
																														transactions, especially related to E-commerce. Collection Services may not 
																														only be used for accepting online credit / debit card payments, but can also be 
																														used for receiving payments made through other methods such as Bank Draft, Wire 
																														Transfer and Cheques.
																													</p>
																													<p><strong>E-filing: </strong>Accounts Centre offers E-filing of Payroll, VAT and 
																														Corporate Tax returns, of Annual Accounts and other related forms. These 
																														services, along with the free review services, assure that all your filings are 
																														accurate and on-time.
																													</p>
																													<p><strong>Preparations: </strong>Accounts Centre offers preparation of Annual 
																														Accounts and Corporate Tax Returns for its customers. These services assure 
																														that your accounts and returns are filed according to compliant standards, 
																														accurately and promptly.
																													</p>
																													<p align="right"><span class="url_text"><strong>[ <a href="#top" class="url_text">Back To Top </a>
																																]</strong></span></p>
																													<p><strong>Accountancy Solutions <a name="accountancysolutions"></a></strong>
																													</p>
																													<p>Accounts Centre offers complete accounting solutions for your day-to-day to 
																														specialised business requirements.
																													</p>
																													<p><strong>Infini Shops: </strong>A comprehensive E-commerce solution, which offers 
																														an all-in-one (Website Graphics and Hosting, Merchant processing and 
																														Accounting) service. InfiniShops offers to completely build your website, 
																														provide comprehensive back-end merchandising software (InfiniAccounts Pro-Web), 
																														host your website, set up an online payment solution and provide pro-active 
																														online customer support through Athena.
																													</p>
																													<p align="left"><strong>Payroll:</strong> Accounts Centre offers a free (for a 
																														period of 4 years!) payroll service, with InfiniPayroll software. This solution 
																														is designed to reduce all your payroll related worries.
																													</p>
																													<p align="left"><strong>Book-keeping:</strong> Remove all hassle from your day to 
																														day accounting and book keeping with the Accounts Centre Book-keeping solution. 
																														Useful and intuitive software plus review system and E-filing capabilities help 
																														you stay on top of all your daily accounting requirements.
																													</p>
																													<p align="right"><span class="url_text"><strong>[ <a href="#top" class="url_text">Back To Top </a>
																																]</strong></span></p>
																													<p><strong>Accountancy Softwares <a name="accountancysoftwares"></a></strong>
																													</p>
																													<p>Accounts Centre offers comprehensive accounting software for the needs of a 
																														small to medium sized concern. The Enterprise Accounts Express software is 
																														available as both, a Desktop Application, as well as a Web-based Interface, 
																														which requires only an internet browser and connection to the internet for 
																														usage.
																													</p>
																													<p align="left">For companies interested in setting up an E-commerce based venture 
																														or those currently involved in E-commerce, Accounts Centre offers 
																														InfiniAccounts Pro-Web . Currently the Desktop Application is available 
																														(bundled with the InfiniShops solution) with a soon-to-be-launched Web-based 
																														Interface ( Enterprise ) for all accounting needs of an e-trading company.</p>
																													<p align="right"><span class="url_text"><strong>[ <a href="#top" class="url_text">Back To Top </a>
																																]</strong></span></p>
																													<p><strong>Accountancy Products <a name="accountancyproducts"></a></strong>
																													</p>
																													<p>Accounts Centre offers the following accounting products to suit all business 
																														concerns.
																													</p>
																													<p>The <strong>Basic Accountancy </strong>package offers a simple yet comprehensive 
																														answer to your accounting problems. This offer is unique in that it may be used 
																														singularly or you may choose to add other accounting products to it, according 
																														to your requirements. The <strong>modular (i.e. add-on) </strong>accounting 
																														products, which may be added to the basic accountancy, are:
																													</p>
																													<ul>
																														<li>
																														Free Payroll service for 4 years
																														<li>
																														Outsourced Accounts Department
																														<li>
																															Collection Service (Merchant Processing Service)
																														</li>
																													</ul>
																													<p>Accounts Centre also offers other stand-alone accountancy products that deal 
																														with accounting related to special business scenarios. These products do not 
																														require the purchase of basic accountancy and include:
																													</p>
																													<ul>
																														<li>
																														Extreme Accounting
																														<li>
																														Dormant Company Accounts
																														<li>
																															InfiniShops
																														</li>
																													</ul>
																													<p align="right"><span class="url_text"><strong>[ <a href="#top" class="url_text">Back To Top </a>
																																]</strong></span></p>
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
																<!--******************-->
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
																		<!--******************-->
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
											<!--****************-->
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
