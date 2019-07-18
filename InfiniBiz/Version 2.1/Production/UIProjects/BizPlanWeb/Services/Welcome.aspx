<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Welcome.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Welcome" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../Include/Files.ascx"		%>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../Include/LeftBar.ascx"		%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../Include/HeaderBar.ascx"		%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<HTML>
	<HEAD>
		<title>Welcome</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<script src="../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../Library/Scripts/PlanWizard.js"></script>
		<script src="../library/Scripts/simModal.js"></script>
		<link href="../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css">
	</HEAD>
	<BODY class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
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
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center">
												<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top">
															<!-- Center Table -->
															<asp:panel id="pnlManager" Runat="server" height="100%">
																<TABLE height="100%" width="100%">
																	<TR>
																		<TD vAlign="top" width="100%"><!-- **************************************************************************************************************************** -->  <!-- Actual Page Contents are to be written here  -->
																			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD vAlign="top" align="center">
																						<TABLE id="myTable" height="70%" width="100%" align="center" border="0">
																							<TR vAlign="top" height="50%" width="100%">
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=0" ><IMG  Visible=False id="ImagebuttonText" src="/images/InfiniPlan/text.jpg" border="0" runat="server" >
																									</A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkText"  Visible=False runat="server" CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=1"><IMG  Visible=False id="ImagebuttonTable" src="/images/InfiniPlan/tables.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkTable"    runat="server" Visible=False CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=2"><IMG  Visible=False id="ImagebuttonChart" height="48" src="/images/InfiniPlan/charts.jpg" width="48"
																											border="0" runat="server"></A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkCharts" runat="server"  Visible=False CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=3"><IMG  Visible=False id="ImagebuttonPrint" height="48" src="/images/InfiniPlan/printer.jpg" width="48"
																											border="0" runat="server"></A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkPrint" runat="server"  Visible=False CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																							</TR>
																							<TR>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=4"><IMG  Visible=False id="ImagebuttonWizarf" src="/images/InfiniPlan/wizard.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkPlanWizard" runat="server"  Visible=False CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=5"><IMG id="ImagebuttonTracker" src="/images/InfiniPlan/tracker.jpg" Visible=False border="0" runat="server">
																									</A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkPlanTracker"  Visible=False runat="server" CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=6"><IMG  Visible=False id="ImagebuttonMeter" src="/images/InfiniPlan/meterwizard.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkPlanMeter"  Visible=False runat="server" CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																								<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/welcome.aspx?cmd=7"><IMG   id="ImagebuttonClose" height="48" src="/images/InfiniPlan/close.jpg" width="48"
																											align="bottom" border="0" runat="server"> </A>
																									<BR>
																									<BR>
																									<asp:LinkButton id="lnkClosePlan" runat="server" CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
																							</TR>
																						</TABLE>
																					</TD>
																				</TR>
																			</TABLE> <!-- Actual Page Contents are to be written upto here  --> <!-- **************************************************************************************************************************** --></TD>
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
	</BODY>
</HTML>
<script>
 document.domain='infinimation.com';
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight   ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
 parent.resizeFrame(scrollHeight,scrollWidth);
 </script>