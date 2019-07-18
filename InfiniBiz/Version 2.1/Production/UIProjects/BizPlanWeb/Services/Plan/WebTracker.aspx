<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebTracker.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebTracker"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<HTML>
	<HEAD>
		<title>Web Tracker</title>
		<Link href="../../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css">
			<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
				<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
				<LINK href="../../Library/Styles/infinistyles.css" type="text/css" rel="stylesheet"></LINK>
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
	<body class="cngbody" onload="Init();">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr id="Tr1" runat="server">
					<td height="19" vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TBODY>
											<tr>
												<td height="19" align="center" valign="top">
													<asp:Label id="lblHeading" Width="100%" cssclass="lblHeading" runat="server">Web Tracker</asp:Label></td>
								</td>
							</tr>
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
																<tr>
																	<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
																	<td class="TableBox_Top" height="3">&nbsp;</td>
																	<td class="TableBox_Top_Right" height="3">&nbsp;</td>
																</tr>
																<tr vAlign="top">
																	<td class="TableBox_Left" width="0%"></td>
																	<td>
																		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<tr vAlign="top">
																				<td vAlign="top">
																					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
																																			<td vAlign="top" align="right" height="65"><IMG src="/images/infiniplan/user_detail_01.jpg"></td>
																																			<td vAlign="top" background="/images/InfiniPlan/topbg.jpg" height="65"><IMG src="/images/infiniplan/user_detail_02.jpg"> </td>
																																			<td vAlign="top" height="65"><IMG src="/images/infiniplan/user_detail_03.jpg"></td>
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
														<td class="TableBox_Right" width="0%">&nbsp;@</td>
													</tr>
													<tr vAlign="top">
														<td class="TableBox_Bot_Left" width="0%"></td>
														<td class="TableBox_Bot" width="100%"></td>
														<td class="TableBox_Bot_Right" width="0%"></td>
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
			</td> </tr> </table></TD></TR>
			<tr id="trBottomMain" runat="server">
				<td vAlign="bottom">
					<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
				</td>
			</tr>
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
