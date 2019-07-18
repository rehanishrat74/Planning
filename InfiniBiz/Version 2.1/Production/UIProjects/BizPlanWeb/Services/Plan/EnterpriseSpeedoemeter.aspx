<%@ Page Language="vb" AutoEventWireup="false" Codebehind="EnterpriseSpeedoemeter.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.EnterpriseSpeedoemeter"%>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Enterprise Speedoemeter</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES><LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
		<script language="javascript">
		function SetZoomValue(o,a)
		{
 	 		var idval = o;
 		 
 	 
 		var getidval=document.getElementById("MeterOption");
		 getidval.value=idval
 
		 }
		 
		
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR><input id="MeterOption" type="hidden" name="MeterOption">
					</td>
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
									<table height="90%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" width="100%" height="100%" Runat="server">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top">
																<asp:panel id="pnlManager" Runat="server">
																	<TABLE border="0">
																		<TR valign="top">
																			<TD align="center" width="70%">
																				<asp:Label id="lblPeriod" runat="server" CssClass="wizardText">Select Period</asp:Label>
																				<asp:DropDownList id="DrpSelectTime" runat="server" CssClass="wizardOptions" AutoPostBack="True">
																					<asp:ListItem Value="Yearly" Selected="True">Yearly</asp:ListItem>
																					<asp:ListItem Value="Biannually ">Biannually </asp:ListItem>
																					<asp:ListItem Value="Quarter">Quarter</asp:ListItem>
																				</asp:DropDownList>
																				<br>
																				<br>
																				<asp:Label id="lblTimePeriod" runat="server" CssClass="wizardText"></asp:Label><BR>
																				<br>
																				<ASP:PANEL id="EnterprisePanel" Runat="server" CssClass="tableborder1" Width="100%" visible="True">
																					<TABLE align="center">
																						<TR vAlign="top">
																							<TD align="center">
																								<DIV class="meterEnterpriseManager" id="enterpriseView">
																									<asp:Table id="EnterpriseMeter" Runat="server" CssClass="trsettings" Width="100%" Visible="False"></asp:Table>
																									<ASP:TABLE id="EnterpriseAdvanceMeters" runat="server" CssClass="trsettings" Width="100%" Visible="False"
																										Border="0"></ASP:TABLE></DIV>
																							</TD>
																						</TR>
																					</TABLE>
																				</ASP:PANEL><br>
																				<ASP:IMAGEBUTTON id="Enterprisezoommeter" runat="server" Visible="True" ToolTip="Zoom" ImageUrl="/images/infiniplan/zoommeter.jpg"></ASP:IMAGEBUTTON>
																				<ASP:BUTTON id="EnterpriseimgbtnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																					runat="server" Visible="False" Text="Back" Cssclass="MBUTTONACCPRO"></ASP:BUTTON>
																			</TD>
																			<TD align="center" width="30%">
																				<ASP:PANEL id="PanelEnterpriseZoom" Runat="server" CssClass="tableborder1" Width="100%" Height="95%">
																					<TABLE height="100%" width="100%" align="center" border="0">
																						<TR vAlign="top" height="70%">
																							<TD align="center" width="100%">
																								<ASP:LABEL id="lblZoomEntity" runat="server" cssclass="flashTitle">+</ASP:LABEL>
																								<DIV class="EnterpriseZoomSpace" id="ZoomViewEnteriprse" align="center">
																									<ASP:TABLE id="ZoomEnteriprseMeter" runat="server" CssClass="trsettings" border="0"></ASP:TABLE></DIV>
																							</TD>
																						</TR>
																						<TR vAlign="top" height="30%">
																							<TD align="center">
																								<ASP:BUTTON id="btnAdv" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Visible="True" Text="Advanced" Cssclass="MBUTTONACCPRO"></ASP:BUTTON></TD>
																						</TR>
																					</TABLE>
																				</ASP:PANEL></TD>
																		</TR>
																		<TR valign="top">
																			<TD align="center" width="20%">
																			</TD>
																		</TR>
																	</TABLE>
																</asp:panel></TD>
															<TD class="TableBox_Right" width="0%">&nbsp;@</TD>
														</TR>
														<TR>
															<TD class="TableBox_Bot_Left" width="0%"></TD>
															<TD class="TableBox_Bot" width="100%"></TD>
															<TD class="TableBox_Bot_Right" width="0%"></TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
									</table>
									<asp:imagebutton id="ImageButton1" runat="server" Width="40px" Height="38px" src="/images/infiniplan/blank.gif"></asp:imagebutton>
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
<script>
 document.domain='infinimation.com';
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight - 40  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
 parent.resizeFrame(scrollHeight,scrollWidth);
		</script>