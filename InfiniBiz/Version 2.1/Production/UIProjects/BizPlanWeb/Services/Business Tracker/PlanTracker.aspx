<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanTracker.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanTracker" %>
<HTML xmlns:o>
	<HEAD>
		<title>Plan Tracker</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
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
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
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
								<td vAlign="top" width="1%" height="100%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%" height="100%"><! 
									--****************************************************************************************************************************--> 
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR vAlign="top" width="100%">
											<TD align="center" width="100%" height="1" bgcolor="#F3F3F3"><asp:label id="lblHeading" runat="server" width="100%" CssClass="lblHeading" Height="16px">Business Tracker</asp:label></TD>
										</TR>
										<tr>
											<td align="center">
												<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" dir="ltr">
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
																							<asp:panel id="standardpanel" Runat="server" Visible="True">
																								<TABLE width="99%" align="left" border="0">
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
																											<asp:panel id="Panel1" width="50%" Runat="server" Visible="True" cssClass="tracker_Panel" BorderWidth="1">
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
														<TD align="center" width="100%">
															<asp:panel id="pnlTrackerChartsOption" Runat="server" Visible="false">
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
																			<asp:panel id="Panel2" width="50%" Runat="server" Visible="True" cssClass="tracker_Panel" BorderWidth="1">
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
									</asp:panel>
								</td>
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
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
<script>
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100 ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth - 10 ;
parent.resizeFrame(scrollHeight,scrollWidth);
 
</script>