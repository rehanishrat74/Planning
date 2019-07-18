<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../Include/HeaderBar.ascx"		%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../Include/LeftBar.ascx"		%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../Include/Files.ascx"		%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Welcome.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Welcome" %>
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
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="19"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" aa>
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center">
												<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top">
															<!-- Center Table -->
															<asp:panel id="pnlManager" Runat="server">
																<TABLE height="100%" width="100%">
																	<TR>
																		<TD vAlign="top" width="100%"><!-- **************************************************************************************************************************** -->  <!-- Actual Page Contents are to be written here  -->
																			<TABLE height="70%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD vAlign="top" align="center">
																						<TABLE id="myTable" height="70%" align="center">
																							<TR height="50%">
																								<TD vAlign="top" align="center" height="122"><A href="/InfiniPlan/Services/welcome.aspx?cmd=0"><IMG id="Imagebutton2" src="/images/InfiniPlan/home.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkHome" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD vAlign="top" align="center" width="119"><A href="/InfiniPlan/Services/welcome.aspx?cmd=1"><IMG id="Imagebutton1" src="/images/InfiniPlan/text.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkText" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD vAlign="top" align="center" width="117"><A href="/InfiniPlan/Services/welcome.aspx?cmd=2"><IMG id="Imagebutton3" src="/images/InfiniPlan/tables.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkTable" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD vAlign="top" align="center" width="119" height="142"><A href="/InfiniPlan/Services/welcome.aspx?cmd=3"><IMG id="Imagebutton4" height="80" src="/images/InfiniPlan/charts.jpg" width="73" border="0"
																											runat="server"> </A>
																									<BR>
																									<asp:LinkButton id="lnkCharts" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																							</TR>
																							<TR height="50%">
																								<TD align="center" width="119"><A onclick="javascript:void(0);return SelectPlanNav(4);" href="/InfiniPlan/Services/welcome.aspx?cmd=4"><IMG id="Imagebutton5" height="82" src="/images/InfiniPlan/plan_preview.jpg" width="68"
																											border="0" runat="server"> </A>
																									<BR>
																									<asp:LinkButton id="lnkPlanPreview" runat="server" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD align="center" width="119"><A href="/InfiniPlan/Services/welcome.aspx?cmd=5"><IMG id="Imagebutton6" src="/images/InfiniPlan/export.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkExportPlan" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD align="center" width="119"><A href="/InfiniPlan/Services/welcome.aspx?cmd=7"><IMG id="Imagebutton7" src="/images/InfiniPlan/wizard.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkPlanWizard" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																								<TD align="center" width="119"><A href="/InfiniPlan/Services/welcome.aspx?cmd=9"><IMG id="Imagebutton8" src="/images/InfiniPlan/close.jpg" border="0" runat="server">
																									</A>
																									<BR>
																									<asp:LinkButton id="lnkClosePlan" runat="server" Text="" CssClass="MultilingulLinkStyle"></asp:LinkButton></TD>
																							</TR> <!-- 
												 
													--></TABLE>
																					</TD>
																				</TR>
																			</TABLE> <!-- Actual Page Contents are to be written upto here  --> <!-- **************************************************************************************************************************** --></TD>
																	</TR>
																</TABLE>
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
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
