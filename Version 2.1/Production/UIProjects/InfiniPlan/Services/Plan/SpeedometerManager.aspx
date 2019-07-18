<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SpeedometerManager.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.SpeedometerManager"%>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Speedometer Manager</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css"></link>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
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
								<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="19" align="center" valign="top">
												<asp:Label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:Label>
											</td>
										</tr>
										<tr>
											<td align="center">
												<asp:Panel ID="testpanel" Runat="server" width="100%" height="100%">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TBODY>
															<TR>
																<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
																<TD class="TableBox_Top" height="3">&nbsp;</TD>
																<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
															</TR>
															<TR>
																<TD class="TableBox_Left" width="0%"></TD>
																<TD vAlign="top" height="100%"><!-- Center Table -->
																	<asp:panel id="pnlManager" Width="100%" Runat="server" Height="100%">
																		<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD vAlign="top" align="center">
																					<P>
																						<asp:Label id="lblMsg" runat="server" Visible="True"></asp:Label></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" align="center" height="100%"><BR>
																					<asp:Panel id="mainpanel" CssClass="tableborder" height="76%" width="100%" Runat="server">
																						<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center"
																							border="0">
																							<TR vAlign="middle" align="center" height="100%">
																								<TD align="center" width="100%" height="50%">
																									<DIV class="meterSpaveFavroties" id="maindiv">
																										<asp:table id="Table1" runat="server" align="center"></asp:table></DIV>
																									<BR>
																								</TD>
																							</TR>
																						</TABLE>
																					</asp:Panel></TD>
																			</TR>
																		</TABLE>
																	</asp:panel></TD>
																<TD class="TableBox_Right" width="0%"></TD>
															</TR>
															<TR>
																<TD class="TableBox_Bot_Left" width="0%"></TD>
																<TD class="TableBox_Bot" width="100%"></TD>
																<TD class="TableBox_Bot_Right" width="0%"></TD>
															</TR>
												</asp:Panel>
									</table>
								</td>
							</tr>
						</table>
						<!-- Actual Page Contents are to be written upto here  -->
						<!-- **************************************************************************************************************************** -->
					</td>
				</tr>
			</table>
			</TD></TR>
			<tr>
				<td vAlign="bottom">
					<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
				</td>
			</tr>
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
