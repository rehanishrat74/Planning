<%@ OutPutCache Location="None"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Chart.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Chart" enableViewState="false"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<HTML xmlns:o>
	<HEAD>
		<title>Charts</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<link href="../../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
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
											<td height="10" valign="top" align="center" bgcolor="#f3f3f3">
												<asp:Label id="lblHeading" runat="server" CssClass="lblHeading" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="10" valign="top">
												<asp:Label id="lblMessage" runat="server" CssClass="lblErrorMessage" Width="100%"></asp:Label>
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
															<!-- Center Table -->
															<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td valign="top" align="center">
																		<!-- Center Table -->
																		<P>
																			<TABLE id="tblcontents" cellSpacing="1" cellPadding="1" width="100%" border="0" class="pagecontents"
																				runat="server">
																				<TR>
																					<TD>
																						<P><SPAN>
																								<BR>
																							</SPAN></P>
																						<P>&nbsp;</P>
																						<P>
																							<o:p>&nbsp;</o:p></P>
																					</TD>
																				</TR>
																			</TABLE>
																		</P>
																		<asp:Panel id="pnlChart" runat="server" Width="664px" Height="440px">
																			<P>
																				<asp:label id="lblSelect" runat="server" Width="35%" CssClass="lblGeneral1" Height="20px"></asp:label>
																				<asp:dropdownlist id="cboCharts" runat="server" Width="327px" Height="5%" AutoPostBack="True">
																					<asp:ListItem Value="0">ColumnClustered</asp:ListItem>
																					<asp:ListItem Value="46">Column3D</asp:ListItem>
																					<asp:ListItem Value="47">ColumnClustered3D</asp:ListItem>
																					<asp:ListItem Value="1">ColumnStacked</asp:ListItem>
																					<asp:ListItem Value="2">ColumnStacked100</asp:ListItem>
																					<asp:ListItem Value="49">ColumnStacked1003D</asp:ListItem>
																					<asp:ListItem Value="48">ColumnStacked3D</asp:ListItem>
																					<asp:ListItem Value="6">Line</asp:ListItem>
																					<asp:ListItem Value="7">LineMarkers</asp:ListItem>
																					<asp:ListItem Value="50">Bar3D</asp:ListItem>
																					<asp:ListItem Value="3">BarClustered</asp:ListItem>
																					<asp:ListItem Value="4">BarStacked</asp:ListItem>
																					<asp:ListItem Value="5">BarStacked100</asp:ListItem>
																					<asp:ListItem Value="18">Pie</asp:ListItem>
																					<asp:ListItem Value="58">Pie3D</asp:ListItem>
																					<asp:ListItem Value="19">PieExploded</asp:ListItem>
																					<asp:ListItem Value="59">PieExploded3D</asp:ListItem>
																					<asp:ListItem Value="12">SmoothLine</asp:ListItem>
																					<asp:ListItem Value="13">SmoothLineMarkers</asp:ListItem>
																					<asp:ListItem Value="60">Area3D</asp:ListItem>
																					<asp:ListItem Value="31">AreaStacked100</asp:ListItem>
																				</asp:dropdownlist></P>
																			<P><IMG 
                              src="DisplayCharts.aspx?fname=<%=chartFileName%>">
																				<asp:PlaceHolder id="chHolder" runat="server"></asp:PlaceHolder></P>
																			<P>&nbsp;</P>
																		</asp:Panel>
																	</td>
																</tr>
																<tr>
																	<td height="10" valign="top" align="center"><img src="/images/InfiniPlan/blank.gif" width="1" height="10">
																		<asp:Button id="btnBack" runat="server" Width="120px" CssClass="buttonCSS" Text="Previous Task"
																			Visible="False"></asp:Button>&nbsp;
																		<asp:Button id="btnNext" runat="server" Width="120px" CssClass="buttonCSS" Text="Next Task"
																			Visible="False"></asp:Button></td>
																</tr>
															</table>
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
									<!-- **************************************************************************************************************************** -->
								</td>
							</tr>
							<tr>
								<td height="10" valign="top"><img src="/images/InfiniPlan/blank.gif" width="1" height="10"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR>
			<tr id="trBottomMain" runat="server">
				<td vAlign="bottom">
					<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
				</td>
			</tr>
			</TABLE>
		</form>
		<script>
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +60  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
parent.resizeFrame(scrollHeight,scrollWidth);
 
		</script>
	</body>
</HTML>
