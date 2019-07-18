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
		<script src="../../Library/Scripts/ie7Bug.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
		<script language="javascript">
		
		function SetRbValue1(o,a)
		{
 	 		var idval = o;
 	 
 	 
 		var getidval=document.getElementById("SelectedRowNumber");
		 getidval.value=idval
	  document.getElementById("editmeter").style.display="" 
		 }
		 
		 function SetZoomValue(o,a )
		{
			var idval = o;
 	 
 	 
 		var getidval=document.getElementById("SelectedRowNumber");
		 getidval.value=idval
 	    document.getElementById("editmeter").style.display="none" 
 	  
		 
		 }
 	 
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor=white>
				<tr>
					<td height="19" vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR><input id="SelectedRowNumber" type="hidden" name="SelectedRowNumber">
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
											<td height="19" align="center" valign="top" bgcolor=#F3F3F3>
												<asp:Label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:Label>
											</td>
										</tr>
										<tr>
											<td align="center">
												<asp:Panel ID="testpanel" Runat="server" width="100%" height="100%">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top" height="100%"><!-- Center Table -->
																<asp:panel id="pnlManager" Width="100%" Runat="server" Height="100%">
																	<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<TR>
																			<TD vAlign="top" align="center" height="19">
																				<P>
																					<asp:Label id="lblMsg" runat="server" Visible="True"></asp:Label></P>
																			</TD>
																		</TR>
																		<TR>
																			<TD vAlign="top" align="center" height="100%"><BR> <!-- Listing -->
																				<asp:panel id="Panelnoclip" width="100%" Runat="server" visible="false">
																					<TABLE height="100%" width="100%" align="center" border="0">
																						<TR vAlign="top" height="100%">
																							<TD vAlign="top" align="center"></TD>
																						</TR>
																					</TABLE>
																				</asp:panel>
																				<asp:panel id="mainpanel" Width="100%" Runat="server" visible="false">
																					<TABLE height="100%" width="100%" align="center" border="0">
																						<TBODY>
																							<TR vAlign="top" height="5%" width="100%">
																								<TD align="center"></TD></TD>
																		</TR>
																		<TR vAlign="top" width="100%">
																			<TD align="center" width="100%" height="97%">
																				<TABLE height="100%" width="100%" align="center" border="0">
																					<TR vAlign="top">
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
																																<ASP:TABLE id="AdvanceMeters" runat="server" CssClass="trsettings" Width="10%" Visible="False"
																																	Border="0"></ASP:TABLE></DIV>
																														</TD>
																													</TR>
																												</TABLE>
																											</ASP:PANEL></TD>
																										<TD vAlign="top" align="center" width="25%" rowSpan="2">
																											<ASP:LABEL id="lblMeterName" runat="server" CssClass="wizardtext1"></ASP:LABEL>
																											<ASP:PANEL id="PanelZoom" CssClass="tableborder1" Width="100%" Runat="server" Height="95%"
																												Visible="True" HorizontalAlign="Center" DESIGNTIMEDRAGDROP="1127">
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
																																runat="server" Visible="False" Text="Advanced" Cssclass="MBUTTONACCPRO"></ASP:BUTTON></TD>
																													</TR>
																												</TABLE>
																											</ASP:PANEL></TD>
																									<TR>
																										<TD align="center">
																											<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="190" border="0">
																												<TR>
																													<TD align="center" width="20%">
																														<ASP:IMAGEBUTTON id="editmeter" runat="server" Visible="False" ToolTip="Edit" ImageUrl="/images/infiniplan/editmeter.jpg"></ASP:IMAGEBUTTON></TD>
																													<TD align="center" width="20%">
																														<ASP:IMAGEBUTTON id="zoommeter" runat="server" Visible="True" ToolTip="Zoom" ImageUrl="/images/infiniplan/zoommeter.jpg"></ASP:IMAGEBUTTON></TD>
																													<TD align="center" width="25%">
																														<ASP:BUTTON id="imgbtnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																															runat="server" Visible="False" Text="Back" Cssclass="MBUTTONACCPRO"></ASP:BUTTON></TD>
																												</TR>
																											</TABLE>
																										</TD>
																									</TR>
																					</TR>
																				</TABLE>
																</asp:panel></TD>
														</TR>
													</TABLE></td>
										</tr>
									</table> </asp:panel><!-- /Listing --></td>
							</tr>
						</table>
						</asp:Panel></td>
					<TD class="TableBox_Right" width="0%"></TD>
				</tr>
				<TR>
					<TD class="TableBox_Bot_Left" width="0%"></TD>
					<TD class="TableBox_Bot" width="100%"></TD>
					<TD class="TableBox_Bot_Right" width="0%"></TD>
				</TR>
				</asp:Panel>
			</table>
			</td> </tr> </table> 
			<!-- Actual Page Contents are to be written upto here  -->
			<!-- **************************************************************************************************************************** -->
			</td> </tr> </table></TD></TR>
			<tr>
				<td vAlign="bottom">
					<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
				</td>
			</tr>
			</TBODY></TABLE>
		</form>
		<script>
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
parent.resizeFrame(scrollHeight,scrollWidth);
 
		</script>
	</body>
</HTML>
