<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Welcome.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Welcome" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../Include/Files.ascx"		%>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../Include/LeftBar.ascx"		%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../Include/HeaderBar.ascx"		%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<HTML>
	<HEAD>
		<title>Welcome</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../Library/Scripts/PlanWizard.js"></script>
		<script src="../library/Scripts/simModal.js"></script>
		<LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="white" border="0">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center">
												<table dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top">
															<!-- Center Table --><asp:panel id="pnlManager" height="100%" Runat="server">
																<TABLE height="100%" width="100%" border="0">
																	<TR>
																		<TD vAlign="top" width="100%"><!-- ****************************************************************************************************************************->    
																			 <!-- Actual Page Contents are to be written upto here  -->  <!-- **************************************************************************************************************************** -->
																			<TABLE cellSpacing="8" cellPadding="0" width="744" align="center" border="0">
																				<TR>
																					<TD><BR>
																						<BR>
																					</TD>
																				</TR>
																				<TR vAlign="top" align="left">
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
																													<DIV class="heading" align="center">
																														<DIV class="heading" align="center">Text</DIV>
																													</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="62">
																													<DIV align="center">
																														<asp:HyperLink id="lnkText" height="47" Runat="server" width="48"  NavigateUrl="/InfiniPlan/Services/Text/PlanText.aspx" ImageUrl="/images/InfiniPlan/MainPage/Text.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">
																														<DIV align="left">Enter all the necessary texts related to the business plan.
																														</DIV>
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
																													<DIV class="heading" align="center">Tables</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="75">
																													<DIV align="center">
																														<asp:HyperLink id="lnkTable" height="47" Runat="server" width="48" NavigateUrl="/InfiniPlan/Services/Tables/Table.aspx" ImageUrl="/images/InfiniPlan/MainPage/Tables.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">Financial Statements, Basic Information, Forecast
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
																												<DIV class="heading" align="center">Charts
																												</DIV>
																											</TD>
																										</TR>
																										<TR>
																											<TD vAlign="top" height="58">
																												<DIV align="center">
																													<asp:HyperLink id="lnkCharts" height="47" Runat="server" width="48" NavigateUrl="/InfiniPlan/Services/Charts/Chart.aspx" ImageUrl="/images/InfiniPlan/MainPage/Charts.jpg"></asp:HyperLink></DIV>
																											</TD>
																										</TR>
																										<TR>
																											<TD class="text" vAlign="top" height="1%">
																												<DIV align="left">Initial Analysis, Monthly Analysis, Yearly Analysis, Financial 
																													Statement.</DIV>
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
																											<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
																										</TR>
																									</TABLE>
																								</TD>
																							</TR>
																						</TABLE>
																						<DIV align="center"></DIV>
																					</TD>
																				</TR>
																				<TR vAlign="top" align="left">
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
																													<DIV class="heading" align="center">Print
																													</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="75">
																													<DIV align="center">
																														<asp:HyperLink id="lnkPrint" height="47" Runat="server" width="48" NavigateUrl="/InfiniPlan/Services/Printing/Printing.aspx" ImageUrl="/images/InfiniPlan/MainPage/Printer.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<P align="left">Plan Preview,Plan Export..
																													</P>
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
																					<TD>
																						<DIV align="center">
																							<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
																								<TR>
																									<TD vAlign="top" width="10" height="100%">
																										<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																											<TR>
																												<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/b5cor1.gif" width="10"></TD>
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
																													<DIV class="heading" align="center">Plan Wizard
																													</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="75">
																													<DIV align="center">
																														<asp:HyperLink id="lnkPlanWizard" height="47" Runat="server" width="48" NavigateUrl="/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx" ImageUrl="/images/InfiniPlan/MainPage/PlanWizard.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">Create and edit any plan feature.…</DIV>
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
																					<TD>
																						<DIV align="center">
																							<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
																								<TR>
																									<TD vAlign="top" width="10" height="100%">
																										<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
																											<TR>
																												<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/b5cor1.gif" width="10"></TD>
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
																													<DIV class="heading" align="center">Business Tracker</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="75">
																													<DIV align="center">
																														<asp:HyperLink id="lnkPlanTracker" height="47" Runat="server" width="48"  NavigateUrl="/InfiniPlan/Services/Business%20Tracker/PlanTracker.aspx" ImageUrl="/images/InfiniPlan/MainPage/BusinessTrakker.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">Reports, Charts.…</DIV>
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
																				</TR>
																				<TR vAlign="top" align="left">
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
																													<DIV class="heading" align="center">
																														<DIV class="heading" align="center">Meter Wizard</DIV>
																													</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="62">
																													<DIV align="center">
																														<asp:HyperLink id="lnkPlanMeter" height="47" Runat="server" width="48"    NavigateUrl="/InfiniPlan/Services/MeterWizard/Speedometer.aspx" ImageUrl="/images/InfiniPlan/MainPage/MeterWizard.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">
																														<DIV align="left">Compose Meter, Meter Listing.
																														</DIV>
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
																												<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/cor3.gif" width="10"></TD>
																											</TR>
																										</TABLE>
																									</TD>
																									<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
																										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																											<TR>
																												<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
																													<DIV class="heading" align="center">Close Plan
																													</DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD vAlign="top" height="62">
																													<DIV align="center">
																														<asp:HyperLink id="lnkClosePlan" height="47" Runat="server" width="48" NavigateUrl="/InfiniPlan/Services/Plan/ClosePlan.aspx" ImageUrl="/images/InfiniPlan/MainPage/ClosePlan.jpg"></asp:HyperLink></DIV>
																												</TD>
																											</TR>
																											<TR>
																												<TD class="text" vAlign="top" height="1%">
																													<DIV align="left">
																														<DIV align="left">Closing the plan will save the changes and will take you out that 
																															plan.
																														</DIV>
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
																						<DIV align="left"></DIV>
																					</TD>
																				</TR>
																				<TR vAlign="top">
																					<TD vAlign="top" align="center" colSpan="3"><A href="/InfiniPlan/Services/Map/PlanManagement.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</asp:panel></td>
														<td class="TableBox_Right" width="0%">&nbsp;@</td>
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
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
		<script>
if ( document.domain == 'enterprise.infinimation.com')
{
 document.domain='infinimation.com';
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight   ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
 parent.resizeFrame(scrollHeight,scrollWidth);
 }
 else 
 {
 
 }
		</script>
	</BODY>
</HTML>
