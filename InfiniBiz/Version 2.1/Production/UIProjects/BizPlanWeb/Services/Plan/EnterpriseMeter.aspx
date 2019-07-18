<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EnterpriseMeter.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.EnterpriseMeter"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Enterprise Meter</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES><LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center">
												<table dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top" height="100%"><asp:panel id="pnlManager1" Runat="server">
																<TABLE height="100%" width="100%">
																	<TR>
																		<TD align="center">
																			<ASP:PANEL id="mainpanel1" CssClass="tableborder1" Width="100%" Runat="server" visible="True">
																				<TABLE height="100%" width="100%" align="center" border="0">
																					<TR vAlign="top">
																						<TD align="center" width="80%">
																							<ASP:PANEL id="Panel3" CssClass="tableborder1" Width="100%" Runat="server" visible="True">
																								<TABLE border="0">
																									<TR vAlign="top">
																										<TD align="left">
																											<DIV class="meterSpavemanger" id="divViews">
																												<ASP:TABLE id="MerchantMeter" runat="server" CssClass="trsettings" Border="0"></ASP:TABLE>
																												<ASP:TABLE id="Listmeter" runat="server" CssClass="trsettings" Border="0"></ASP:TABLE>
																												<ASP:TABLE id="AdvanceMeters" runat="server" CssClass="trsettings" Width="10%" Border="0" Visible="False"></ASP:TABLE></DIV>
																										</TD>
																									</TR>
																								</TABLE>
																							</ASP:PANEL></TD>
																						<TD vAlign="top" align="center" width="25%" rowSpan="2">
																							<ASP:LABEL id="lblMeterName" runat="server" CssClass="wizardtext1"></ASP:LABEL>
																							<ASP:PANEL id="PanelZoom" CssClass="tableborder1" Width="100%" Runat="server" Height="95%"
																								Visible="True" DESIGNTIMEDRAGDROP="1127" HorizontalAlign="Center">
																								<TABLE height="100%" width="100%" align="center" border="0">
																									<TR vAlign="top" height="90%">
																										<TD align="center" width="100%">
																											<ASP:LABEL id="lblZoomEntitName" runat="server" cssclass="flashTitle">+</ASP:LABEL>
																											<DIV class="ZoomSpave" id="divViews1" align="center">
																												<ASP:TABLE id="MeterZoomView" runat="server" CssClass="trsettings" border="0"></ASP:TABLE></DIV>
																										</TD>
																									</TR>
																									<TR vAlign="top" height="10%">
																										<TD align="center">
																											<ASP:BUTTON id="imgbtnAdv" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																												runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Advance"></ASP:BUTTON></TD>
																									</TR>
																								</TABLE>
																							</ASP:PANEL></TD>
																					<TR>
																						<TD align="center">
																							<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="190" border="0">
																								<TR>
																									 	<TD align="center" width="20%">
																										<ASP:IMAGEBUTTON id="zoommeter" runat="server" Visible="True" ToolTip="Zoom" ImageUrl="/images/infiniplan/zoommeter.jpg"></ASP:IMAGEBUTTON></TD>
																									<TD align="center" width="25%">
																										<ASP:BUTTON id="imgbtnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																											runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Back"></ASP:BUTTON></TD>
																								</TR>
																							</TABLE>
																						</TD>
																					</TR>
																	</TR>
																</TABLE>
															</asp:panel></td>
													</tr>
												</table>
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
						<asp:imagebutton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:imagebutton>
						<!-- Actual Page Contents are to be written upto here  -->
						<!-- **************************************************************************************************************************** --></td>
				</tr>
			</table>
			</TD></TR>
			<tr id="trBottomMain" runat="server">
				<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TABLE></form>
	</body>
</HTML>
