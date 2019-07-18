<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanPreferences.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanPreferences"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<HTML>
	<HEAD>
		<title>Export Plan</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/BusinessGrid.js"></script>
		<script src="../../Library/Scripts/Calculations.js"></script>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../library/Scripts/simModal.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor=white>
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
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" height="19" bgcolor=#F3F3F3><asp:label id="lblHeading" runat="server" CssClass="lblHeading" Width="100%"></asp:label></td>
										</tr>
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
														<td vAlign="top" height="100%">
															<!-- Center Table -->
															<asp:panel id="pnlManager" Runat="server">
																<TABLE height="100%" width="100%"> <!--  row -->
																	<TR>
																		<TD vAlign="top" align="center" height="2%">
																			<asp:label id="lblErrorMessage" runat="server" Width="100%" CssClass="lblErrorMessage">aa</asp:label></TD>
																	</TR> <!--  row -->
																	<TR vAlign="top">
																		<TD align="center" height="5%">
																			<TABLE class="centerTable" id="tblExported" width="98%" runat="server">
																				<TR class="alternatingRowItem" vAlign="top">
																					<TD vAlign="middle" align="center" width="225">
																						<asp:label id="lblPlanPref" runat="server" cssclass="lblPlanPreferences_Style" Font-Bold="True"></asp:label></TD>
																					<TD vAlign="middle" align="center" width="370">
																						<asp:imagebutton id="ImgBtntnExportPlan" runat="server" ImageUrl="/images/infiniplan/PlanWordIcon.bmp"></asp:imagebutton><BR>
																						<asp:linkbutton id="lnkRtfFile" runat="server" Width="208px"></asp:linkbutton></TD>
																					<TD vAlign="middle" align="center" width="30%">
																						<asp:label id="lblDateExported" runat="server" Width="168px" cssclass="lblPlanPreferences_Style'"
																							Font-Bold="True"></asp:label></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR> <!--  row -->
																	<TR vAlign="top">
																		<TD vAlign="top" align="center">
																			<TABLE class="centerTable" width="98%">
																				<TR class="alternatingrowItem">
																					<TD align="center" colSpan="2" height="5"></TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" colSpan="2"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="1"></TD>
																				</TR>
																				<TR class="rowItem" vAlign="top">
																					<TD width="329">
																						<asp:label id="lblPlanName" runat="server" Width="100%" CssClass="pagecontents" Font-Bold="True"></asp:label></TD>
																					<TD width="50%">
																						<asp:textbox id="txtPlanSaveName" runat="server" Width="100%" CssClass="pagecontents"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" colSpan="2"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="1"></TD>
																				</TR>
																				<TR class="alternatingRowItem">
																					<TD width="329" height="19">
																						<asp:label id="lblIncludeTables" runat="server" Width="100%" CssClass="pagecontents" Font-Bold="True"></asp:label></TD>
																					<TD width="50%" height="19">
																						<asp:dropdownlist id="ddlIncludeTables" runat="server" Width="80px" CssClass="pagecontents">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR class="alternatingRowItem">
																					<TD width="329" height="14">
																						<asp:label id="lblChartInclude" runat="server" Width="100%" CssClass="pagecontents" Font-Bold="True"></asp:label></TD>
																					<TD width="50%" height="14">
																						<asp:dropdownlist id="ddlIncludeCharts" runat="server" Width="80px" CssClass="pagecontents">
																							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
																							<asp:ListItem Value="0">No</asp:ListItem>
																						</asp:dropdownlist></TD>
																				</TR>
																				<TR class="alternatingRowItem">
																					<TD colSpan="2">
																						<asp:checkbox id="chkDownload" runat="server" Width="100%" CssClass="pagecontents" Font-Bold="True"></asp:checkbox></TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" colSpan="2"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="1"></TD>
																				</TR>
																				<TR class="rowItem">
																					<TD align="center" width="100%" colSpan="2">
																						<asp:button id="btnExport" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																							runat="server" Cssclass="MBUTTONACCPRO"></asp:button></TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</asp:panel>
															<!-- Center Table -->
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
	</body>
</HTML>
