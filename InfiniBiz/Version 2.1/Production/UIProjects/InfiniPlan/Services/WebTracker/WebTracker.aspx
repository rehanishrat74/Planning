<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebTracker.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebTracker"%>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<HTML>
	<HEAD>
		<title>Web Tracker</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../Library/Styles/infinistyles.css" type="text/css" rel="stylesheet">
			<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
			<script language="JavaScript" type="text/JavaScript">
		
		<!--
		function MM_openBrWindow(theURL,winName,features) { //v2.0
			window.open(theURL,winName,features);
		}
		function _changelang(){ 
	//   lang = document.forms("UIMainForm").langmenu.options[langmenu.selectedIndex]; 
		lang = document.getElementById("langmenu")
			if (lang.value != ""){ 
			link = "http://www.infinishops.com/" + lang.value; 
			window.location.href = link; 
			} 
		} 
		function formsubmit(){
			document.all.submit1.value="yes";
			document.all.callingname.value="index";
			loginform.submit();
		}
	//-->
			</script>
	</HEAD>
	<body onload="Init();">
		<table height="359" cellSpacing="0" cellPadding="0" width="100%" border="0">
			<tr>
				<td>
					<form id="UIMainForm" runat="server">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" height="19">
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" colSpan="3" height="6"><IMG height="6" src="/images/InfiniPlan/blank.gif" width="1"></td>
										</tr>
										<tr>
											<td vAlign="top" width="0%"></td>
											<td vAlign="top">
												<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
													<tr>
														<td vAlign="top" align="right" height="100%">
															<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr vAlign="top">
																	<td width="16"><IMG height="25" src="/images/InfiniPlan/crv1.jpg" width="16"></td>
																	<td vAlign="bottom" width="1067" background="/images/InfiniPlan/crv_topbg.jpg">
																	</td>
																	<td width="17"><IMG height="26" src="/images/infiniplan/crv2.jpg" width="17"></td>
																</tr>
																<tr vAlign="top">
																	<td background="/images/infiniplan/crv1bg.jpg" width="16">&nbsp;</td>
																	<td>
																		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr vAlign="top">
																				<td vAlign="top">
																					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD vAlign="top" height="15">
																								<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
																									<TR>
																										<TD class="headding" height="20">Web Tracker</TD>
																									</TR>
																									<TR>
																										<TD class="headding" height="20"></TD>
																									</TR>
																								</TABLE>
																							</TD>
																						</TR>
																						<tr vAlign="top">
																							<td vAlign="top">
																								<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
																									<tbody>
																										<tr>
																											<td>
																												<table id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																													<tbody>
																														<tr>
																															<td vAlign="top">
																																<table id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="130" border="0">
																																	<tbody>
																																		<tr>
																																			<td vAlign="bottom" colSpan="3"><IMG src="/images/InfiniPlan/user_01.jpg"></td>
																																		</tr>
																																		<tr>
																																			<td vAlign="top" background="/images/InfiniPlan/user_02.jpg"><IMG src="/images/infiniplan/user_02.jpg">
																																			</td>
																																			<td vAlign="top" width="185" height="100%">
																																				<table id="Table6" cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
																																					<tbody>
																																						<tr>
																																							<td height="10"></td>
																																						</tr>
																																						<TR>
																																							<td>
																																								<div class="text_style2" id="onlineVisiter" height="30"></div>
																																							</td>
																																						<tr>
																																						<tr>
																																							<td class="text_style2" id="detector" vAlign="middle" height="22"></td>
																																						</tr>
																																		</tr>
																																	</tbody></table>
																															</td>
																															<td background="/images/InfiniPlan/user_04.jpg"><IMG height="323" src="/images/InfiniPlan/user_04.jpg" width="12">
																															</td>
																														</tr>
																														<tr>
																															<td colSpan="3"><IMG height="29" src="/images/infiniplan/user_05.jpg" width="208">
																															</td>
																														</tr>
																													</tbody></table>
																											</td>
																											<td vAlign="top" align="left" width="100%">
																												<table id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																													<tbody>
																														<tr vAlign="left">
																															<td>
																																<table id="Table8" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																																	<tbody>
																																		<tr height="30">
																																			<td vAlign="top" align="right"><IMG src="/images/infiniplan/user_detail_01.jpg"></td>
																																			<td vAlign="top" background="/images/InfiniPlan/topbg.jpg"><IMG src="/images/infiniplan/user_detail_02.jpg"></td>
																																			<td vAlign="top"><IMG src="/images/infiniplan/user_detail_03.jpg"></td>
																																		</tr>
																																		<tr>
																																			<td vAlign="top" align="right" background="/images/InfiniPlan/user_detail_04.jpg"><IMG src="/images/infiniplan/user_detail_04.jpg">
																																			</td>
																																			<td vAlign="top" align="left" width="100%">
																																				<table id="Table9" height="200" width="100%">
																																					<tbody>
																																						<tr vAlign="top">
																																							<td vAlign="top" height="250">
																																								<table id="Table10" borderColor="#d6e3f7" height="250" cellSpacing="0" cellPadding="0"
																																									width="100%" align="center" border="1">
																																									<tr vAlign="top">
																																										<td id="userInfo" borderColor="#ffffff"></td>
																																									</tr>
																																								</table>
																																							</td>
																																						</tr>
																																						<tr>
																																							<td vAlign="top">
																																								<div id="uHeader" style="DISPLAY: block">
																																									<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" border="1">
																																										<tr class="text_style2">
																																										</tr>
																																										<tr class="text_style2" bgColor="#edf3fb">
																																											<td align="center" width="5%">Sr.#</td>
																																											<td align="center" width="30%" height="25">From URL:
																																											</td>
																																											<td align="center" width="35%">To URL:
																																											</td>
																																											<td align="center" width="30%">Started Time
																																											</td>
																																										</tr>
																																									</table>
																																								</div>
																																							</td>
																																						</tr>
																																						<tr>
																																							<td vAlign="top" height="100%">
																																								<table id="Table11" borderColor="#d6e3f7" height="100%" cellSpacing="0" cellPadding="0"
																																									width="100%" align="center" border="1">
																																									<tr vAlign="top">
																																										<td vAlign="top" borderColor="#ffffff" height="180">
																																											<div id="urlHistory" style="DISPLAY: none; OVERFLOW: auto; WIDTH: 100%; HEIGHT: 177px"></div>
																																										</td>
																																									</tr>
																																								</table>
																																							</td>
																																						</tr>
																																					</tbody></table>
																																			</td>
																																			<td background="/images/InfiniPlan/user_detail_06.jpg"><IMG height="323" src="/images/InfiniPlan/user_detail_06.jpg" width="12">
																																			</td>
																																		</tr>
																																		<tr>
																																			<td vAlign="top" align="right"><IMG height="29" src="/images/InfiniPlan/user_detail_07.jpg" width="11">
																																			</td>
																																			<td vAlign="top" background="/images/InfiniPlan/bottomBg.jpg"><IMG height="29" src="/images/infiniplan/user_detail_08.jpg" width="185">
																																			</td>
																																			<td><IMG height="29" src="/images/InfiniPlan/user_detail_09.jpg" width="12">
																																			</td>
																																		</tr>
																																	</tbody></table>
																															</td>
																														</tr>
																													</tbody></table>
																											</td>
																										</tr>
																									</tbody></table>
																							</td>
																						</tr>
																						</tbody></table>
																				</td>
																			</tr>
																		</table>
																	</td>
																</tr>
															</table>
														</td>
														<td background="/images/InfiniPlan/crv_2linebg.jpg">&nbsp;</td>
													</tr>
													<tr vAlign="top">
														<td width="16"><IMG height="10" src="/images/InfiniPlan/crv_1bottom.jpg" width="16"></td>
														<td background="/images/InfiniPlan/crv_bottomlinebg.jpg"><IMG height="10" src="/images/InfiniPlan/crv_bottomlinebg.jpg" width="15"></td>
														<td><IMG height="10" src="/images/InfiniPlan/crv_bottom1.jpg" width="17"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
								<td vAlign="top" align="right" width="0%">&nbsp;</td>
							</tr>
						</table>
				</td>
			</tr>
		</table>
		</form><map name="Map3MapMapMap"><area onclick="MM_openBrWindow('http://www.formationshouse.com/itl_pop.htm','','width=312,height=110')"
				shape="RECT" coords="469,8,592,30" href="#"><area shape="RECT" coords="153,9,280,42" href="http://www.formationshouse.com/fr/index.htm"><area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm"></map></td></tr></table><map name="Map"><area shape="RECT" target="_blank" coords="433,3,623,47" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"></map><map name="Map3MapMap"><area onclick="MM_openBrWindow('http://www.formationshouse.com/itl_pop.htm','','width=312,height=110')"
				shape="RECT" coords="469,8,592,30" href="#"><area shape="RECT" coords="153,9,280,42" href="http://www.formationshouse.com/fr/index.htm"><area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm"></map><map name="Map2Map"><area shape="RECT" coords="478,14,547,30" href="http://webmail.formationshouse.com"><area shape="RECT" coords="375,15,464,29" href="http://www.formationshouse.com/web_site_administration.htm"><area shape="RECT" coords="286,19,356,30" href="http://www.formationshouse.com/search/ereg/login.php"><area shape="RECT" coords="563,16,626,31" href="..\accounting.htm"><area shape="RECT" target="_blank" coords="643,17,692,30" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"><area shape="RECT" coords="707,15,771,30" href="..\contact.htm"><area shape="RECT" coords="230,18,265,31" href="..\index.htm"></map>
	</body>
</HTML>
