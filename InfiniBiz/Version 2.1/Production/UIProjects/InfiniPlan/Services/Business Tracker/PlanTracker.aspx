<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanTracker.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanTracker" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<HTML xmlns:o>
	<HEAD>
		<title>Plan Tracker</title>
	 		<script src="../../Library/Scripts/BusinessGrid.js"></script>
		<script src="../../Library/Scripts/Calculations.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
				<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
	</HEAD>
	<body class="cngbody" onkeydown="return catchEnter();" onload="Init()">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="white" border="0">
				<tr id="trTopMain" runat="server">
				</tr>
				<tr>
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" height="100%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%" height="100%"><! 
									--****************************************************************************************************************************--> 
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR vAlign="top" width="100%">
											<TD align="center" width="100%" bgColor="#f3f3f3" height="1"><asp:label id="lblHeading" runat="server" width="100%" Height="16px" CssClass="lblHeading">Business Tracker</asp:label></TD>
										</TR>
										<tr>
											<td align="center">
												<table dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr vAlign="top" height="90%">
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top" height="100%">
															<!-- Center Table --><asp:panel id="pnlManager" Runat="server">
																<TABLE height="50%" width="100%" border="0">
																	<TBODY>
																		<TR height="50%">
																			<TD vAlign="top" width="100%">
																				<TABLE width="100%" border="0">
																					<TR>
																						<TD>
																							<asp:panel id="Mainpanel" runat="server" Visible="True">
																								<TABLE width="100%" border="0">
																									<TR>
																										<TD colSpan="2">
																											<TABLE width="100%" border="0">
																												<TR>
																												<TR>
																													<TD vAlign="top" width="85%"></TD>
																													<TD vAlign="top" align="left" width="15%"></TD>
																												</TR>
																												<TR>
																													<TD vAlign="top" align="center" colSpan="2">
																														<asp:Label id="lblFirstHelp" style="TEXT-ALIGN: center" runat="server"></asp:Label>
																														<asp:Label id="lblSecondHelp" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana"
																															Font-Size="8"></asp:Label>
																														<asp:HyperLink id="WizardCurrecny" runat="server" Font-Names="Verdana" Font-Size="8" Font-Bold="True"
																															NavigateUrl="/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx">Plan Wizard</asp:HyperLink>
																														<asp:Label id="lblThirddHelp" style="TEXT-ALIGN: center" runat="server" Font-Names="Verdana"
																															Font-Size="8"></asp:Label></TD>
																												</TR>
																											</TABLE>
																										</TD>
																									</TR>
																								</TABLE>
																							</asp:panel></TD>
																					</TR>
																					<TR>
																						<TD align="center" width="100%">
																							<asp:panel id="standardpanel" Runat="server" Visible="True"   >
																								<!--<TABLE width="99%" align="left" border="1">
																									<TR>
																										<TD colSpan="4">
																											<asp:Label id="lblStandardHead" runat="server"></asp:Label></TD>
																									</TR>
																									<TR>
																										<TD width="50%" colSpan="2" height="84">
																											<asp:Label id="lblIO" runat="server"></asp:Label></TD>
																										<TD vAlign="top" align="center" height="84">
																											<asp:ImageButton id="ImgButMonthlyIO" runat="server" ImageUrl="/images/InfiniPlan/Income_monthly.jpg"
																												cssClass="PlanTracker_ImageButton"></asp:ImageButton><BR>
																											<asp:Linkbutton id="lnkMonthlyIO" runat="server" Font-Names="verdana" Font-Size="8pt"></asp:Linkbutton></TD>
																										<TD vAlign="top" align="center" height="84">
																											<asp:ImageButton id="ImgButAnnualIO" runat="server" ImageUrl="/images/InfiniPlan/Income_yearly.jpg"
																												cssClass="PlanTracker_ImageButton"></asp:ImageButton><BR>
																											<asp:Linkbutton id="lnkAnnualIO" runat="server" Font-Names="verdana" Font-Size="8pt"></asp:Linkbutton></TD>
																									</TR>
																									<TR>
																										<TD vAlign="top" width="50%" colSpan="2">
																											<asp:Label id="lblBS" runat="server"></asp:Label></TD>
																										<TD vAlign="top" align="center">
																											<P>
																												<asp:ImageButton id="ImgButMonthlyBS" runat="server" ImageUrl="/images/InfiniPlan/Balance_monthly.jpg"
																													cssClass="PlanTracker_ImageButton"></asp:ImageButton><BR>
																												<asp:Linkbutton id="lnkMonthlyBS" runat="server" Font-Names="verdana" Font-Size="8pt"></asp:Linkbutton></P>
																										</TD>
																										<TD vAlign="top" align="center">
																											<asp:ImageButton id="ImgButAnnualBS" runat="server" ImageUrl="/images/InfiniPlan/Balance_yearly.jpg"
																												cssClass="PlanTracker_ImageButton"></asp:ImageButton><BR>
																											<asp:Linkbutton id="lnkAnnualBS" runat="server" Font-Names="verdana" Font-Size="8pt"></asp:Linkbutton></TD>
																									</TR>
																								</TABLE>-->
																								<TABLE cellSpacing="8" cellPadding="0" width="714" align="center" border="0">
																									<TR>
																										<TD><BR>
																											<BR>
																										</TD>
																									</TR>
																									<TR>
																										<TD>
																											<DIV align="center">
																												<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
																													<TR>
																														<TD vAlign="top" width="10" height="100%">
																															<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																																<TR>
																																	<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/cor3.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
																															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																																<TR>
																																	<TD vAlign="top" background='background="/images/InfiniPlan/tbg.gif"' height="1%">
																																		<DIV class="heading" align="center">Monthly Income Statment</DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="75">
																																		<DIV align="center">
																																			<asp:hyperlink id="hypIncome_monthly" width="48" Runat="server" NavigateUrl="/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=1"
																																				ImageUrl="/images/InfiniPlan/Income_monthly.jpg"></asp:hyperlink></DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD class="text" vAlign="top" height="1%">
																																		<DIV align="left">This report compares the actual income and expense of your 
																																			business with the estimated figures on monthly basis
																																		</DIV>
																																	</TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD vAlign="top" width="10">
																															<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
																																<TR>
																																	<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																													</TR>
																												</TABLE>
																											</DIV>
																										</TD>
																										<TD>
																											<DIV align="center">
																												<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
																													<TR>
																														<TD vAlign="top" width="10" height="100%">
																															<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																																<TR>
																																	<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/b2cor3.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
																															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																																<TR>
																																	<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
																																		<DIV class="heading" align="center">Yearly Income Statment</DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="75">
																																		<DIV align="center">
																																			<asp:hyperlink id="hypIncome_yearly" width="48" Runat="server" NavigateUrl="/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=2"
																																				ImageUrl="/images/InfiniPlan/Income_yearly.jpg"></asp:hyperlink></DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD class="text" vAlign="top" height="1%">
																																		<DIV align="left">The report gives you an yearly based comparison of your actual 
																																			income statement with your estimated figures.</DIV>
																																	</TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD vAlign="top" width="10">
																															<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
																																<TR>
																																	<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																													</TR>
																												</TABLE>
																											</DIV>
																										</TD>
																										<TD>
																											<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" align="center"
																												border="0">
																												<TR>
																													<TD vAlign="top" width="10" height="100%">
																														<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																															<TR>
																																<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
																															</TR>
																															<TR>
																																<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
																															</TR>
																															<TR>
																																<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/b2cor3.gif" width="10"></TD>
																															</TR>
																														</TABLE>
																													</TD>
																													<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
																														<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																															<TR>
																																<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
																																	<DIV class="heading" align="center">Monthly Balance Sheet
																																	</DIV>
																																</TD>
																															</TR>
																															<TR>
																																<TD vAlign="top" height="75">
																																	<DIV align="center">
																																		<asp:hyperlink id="hypBalance_monthly" width="48" Runat="server" NavigateUrl="/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=3"
																																			ImageUrl="/images/InfiniPlan/Balance_monthly.jpg" height="47"></asp:hyperlink></DIV>
																																</TD>
																															</TR>
																															<TR>
																																<TD class="text" vAlign="top" height="1%">The report compares your actual balance 
																																	sheet with the expected balance sheet on monthly basis.</TD>
																															</TR>
																														</TABLE>
																													</TD>
																													<TD vAlign="top" width="10">
																														<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
																															<TR>
																																<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
																															</TR>
																															<TR>
																																<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
																															</TR>
																														</TABLE>
																													</TD>
																												</TR>
																											</TABLE>
																											<DIV align="center"></DIV>
																										</TD>
																									</TR>
																									<TR>
																										<TD>
																											<DIV align="center">
																												<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
																													<TR>
																														<TD vAlign="top" width="10" height="100%">
																															<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																																<TR>
																																	<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/cor3.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
																															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																																<TR>
																																	<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
																																		<DIV class="heading" align="center">Yearly Balance Sheet</DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="75">
																																		<DIV align="center">
																																			<asp:hyperlink id="hypBalance_yearly" width="48" Runat="server" NavigateUrl="/InfiniPlan/Services/Business Tracker/FinancialReports.aspx?_report=4"
																																				ImageUrl="/images/InfiniPlan/Balance_yearly.jpg" height="47"></asp:hyperlink></DIV>
																																	</TD>
																																</TR>
																																<TR>
																																	<TD class="text" vAlign="top" height="1%">
																																		<DIV align="left">This report gives you a yearly based comparison of the actual 
																																			balance sheet and your expected balance sheet.</DIV>
																																	</TD>
																																</TR>
																															</TABLE>
																														</TD>
																														<TD vAlign="top" width="10">
																															<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
																																<TR>
																																	<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/b4cor2.gif" width="10"></TD>
																																</TR>
																																<TR>
																																	<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
																																</TR>
																															</TABLE>
																														</TD>
																													</TR>
																												</TABLE>
																											</DIV>
																										</TD>
																										<TD>&nbsp;</TD>
																										<TD>&nbsp;</TD>
																									</TR>
																									<TR>
																										<TD align="center" colSpan="3"><BR>
																											<BR>
																											<A href="/InfiniPlan/Services/Map/Illustrations.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
																									</TR>
																								</TABLE>
																							</asp:panel></TD>
																					</TR>
																					<TR>
																						<TD width="100%">
																							<asp:panel id="pnlTrackerCharts" Runat="server" Visible="false">
																								<TABLE width="99%" border="0">
																									<TR>
																									</TR>
																									<TR>
																										<TD colSpan="3">
																											<asp:Label id="lblChartHelp" runat="server"></asp:Label></TD>
																									</TR>
																									<TR>
																										<TD align="center"><BR>
																											<BR>
																											<asp:panel id="Panel1" width="50%" Runat="server" Visible="True" BorderWidth="1" cssClass="tracker_Panel">
																												<TABLE align="center">
																													<TBODY>
																														<TR>
																															<TD align="center"><BR>
																																<asp:Label id="lblChartSelection" runat="server"></asp:Label></TD>
																														</TR>
																														<TR>
																															<TD align="center"><BR>
																																<asp:RadioButton id="optMonthlyChart" runat="server" width="180px" CssClass="wizardOptions" GroupName="trackerOption"
																																	checked="true"></asp:RadioButton></TD>
																														</TR>
																														<TR>
																															<TD align="center">
																																<asp:RadioButton id="optAnnualChart" runat="server" width="180px" CssClass="wizardOptions" GroupName="trackerOption"></asp:RadioButton></TD>
																														<TR>
																															<TD align="center">
																																<P><BR>
																																	<BR>
																																	<asp:button id="btnOk" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																																		Runat="server" Cssclass="MBUTTONACCPRO" Width="20%"></asp:button></P>
																																<P>&nbsp;</P>
																															</TD></TD>
																									</TR>
																								</TABLE>
																							</asp:panel></TD>
																					</TR>
																				</TABLE>
															</asp:panel></td>
													</tr>
													<TR>
														<TD align="center" width="100%"><asp:panel id="pnlTrackerChartsOption" Runat="server" Visible="false">
																<TABLE width="99%" align="left" border="0">
																	<TR>
																		<TD>
																			<asp:label id="lblAnnaulchart" runat="server" Visible="False"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD>
																			<asp:label id="lblMonthlychart" runat="server" Visible="False"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD align="center"><BR>
																			<BR>
																			<asp:panel id="Panel2" width="50%" Runat="server" Visible="True" BorderWidth="1" cssClass="tracker_Panel">
																				<BR>
																				<TABLE>
																					<TR>
																						<TD>
																							<asp:label id="lblSelectMonth" runat="server" width="35%" CssClass="wizardHelp"></asp:label>
																							<asp:DropDownList id="cmbMonth" runat="server" width="40%" CssClass="wizardOptions"></asp:DropDownList>
																							<asp:label id="lblChartYear" runat="server"></asp:label></TD>
																					<TR>
																						<TD>
																							<asp:label id="lblSelectChartType" runat="server" width="35%" CssClass="wizardHelp"></asp:label>
																							<asp:DropDownList id="cmbChartType" runat="server" width="40%" CssClass="wizardOptions"></asp:DropDownList></TD>
																					</TR>
																					<TR>
																						<TD align="center" width="450"><BR>
																							<asp:button id="btnShow" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																								Runat="server" Cssclass="MBUTTONACCPRO"></asp:button>
																							<asp:button id="btnback" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																								Runat="server" Cssclass="MBUTTONACCPRO"></asp:button>
																							<P>&nbsp;</P>
																						</TD>
																					</TR>
																				</TABLE>
																			</asp:panel></TD>
																	</TR>
																</TABLE>
															</asp:panel></TD>
													</TR>
												</table>
											</td>
										</tr>
									</table>
									</asp:panel></td>
								<td class="TableBox_Right" width="0%"></td>
							</tr>
							<tr>
								<td class="TableBox_Bot_Left" width="0%"></td>
								<td class="TableBox_Bot" width="100%"></td>
								<td class="TableBox_Bot_Right" width="0%"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<!-- Actual Page Contents are to be written upto here  -->
			<!-- **************************************************************************************************************************** --> 
			</TD></TR></TBODY></TABLE></TD></TR>
			<tr id="trBottomMain" runat="server">
				<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE></form>
		<script>
	if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100 ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth - 10 ;
parent.resizeFrame(scrollHeight,scrollWidth);
 }
 else 
 {
 }
		</script>
	</body>
</HTML>
