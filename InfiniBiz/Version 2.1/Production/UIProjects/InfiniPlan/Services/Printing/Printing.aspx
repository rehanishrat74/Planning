<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Printing.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Printing"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan Printing</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css"></link>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
		<script language="javascript">
function GetFocus()
{
SelectPlanNav(4)
 
}
	
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="white">
				<tr id="trTopMain" runat="server">
					<td height="19" vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="19" align="center" valign="top" Width="100%" bgcolor="#f3f3f3">
												<asp:Label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:Label>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td height="100%" valign="top">
															<asp:Panel ID="pnlManager" Runat="server" Height="100%">
																<TABLE cellSpacing="8" cellPadding="0" width="744" align="center" border="0">
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
																									<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
																										<DIV class="heading" align="center">Plan Preview</DIV>
																									</TD>
																								</TR>
																								<TR>
																									<TD vAlign="top" height="75">
																										<DIV align="center">
																											<asp:HyperLink id="lnkPlanPreview" Runat="server" width="48" ImageUrl="/images/InfiniPlan/map/plan-preview.gif"
																												NavigateUrl="/InfiniPlan/Services/Printing/Printing.aspx?printid=0" height="47"></asp:HyperLink></DIV>
																									</TD>
																								</TR>
																								<TR>
																									<TD class="text" vAlign="top" height="1%">
																										<DIV align="left">Have a preview of the plan before printing.</DIV>
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
																										<DIV class="heading" align="center">Export Plan
																										</DIV>
																									</TD>
																								</TR>
																								<TR>
																									<TD vAlign="top" height="75">
																										<DIV align="center">
																											<asp:HyperLink id="lnkExportPlan" Runat="server" width="48" ImageUrl="/images/InfiniPlan/map/export-plan.gif"
																												NavigateUrl="/InfiniPlan/Services/Printing/Printing.aspx?printid=1" height="47"></asp:HyperLink></DIV>
																									</TD>
																								</TR>
																								<TR>
																									<TD class="text" vAlign="top" height="1%">Export the plan when it is completed and 
																										documented.
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
																									<DIV class="heading" align="center">Plan OutLine</DIV>
																								</TD>
																							</TR>
																							<TR>
																								<TD vAlign="top" height="75">
																									<DIV align="center">
																										<asp:HyperLink id="lnkPlanOutline" Runat="server" width="48" ImageUrl="/images/InfiniPlan/map/plan_outline.gif"
																											NavigateUrl="/InfiniPlan/Services/Printing/Printing.aspx?printid=2" height="47"></asp:HyperLink></DIV>
																								</TD>
																							</TR>
																							<TR>
																								<TD class="text" vAlign="top" height="1%">Edit plan headings.
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
																	<TR>
																		<TD align="center" colSpan="3"><BR>
																			<BR>
																			<A href="/InfiniPlan/Services/Map/PlanRoot.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
																	</TR>
																</TABLE>
															</asp:Panel>
														</td>
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
									<asp:ImageButton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:ImageButton>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
					</td>
				</tr>
			</table>
		</form>
		<script>
	   if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
parent.resizeFrame(scrollHeight,scrollWidth);
 }
 else 
 {
 
 }
		</script>
	</body>
</HTML>
