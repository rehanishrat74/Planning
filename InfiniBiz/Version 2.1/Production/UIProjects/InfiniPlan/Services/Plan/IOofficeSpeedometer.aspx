<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="IOofficeSpeedometer.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.IOofficeSpeedometer"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Infini-Office</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
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
			document.getElementById("lblPeriod").disabled= false;
			document.getElementById("DrpSelectTime").disabled=false;
			document.getElementById("lblTimePeriod").disabled=false;
				 
 		 }
	
	 function SetZoomValueIO(o,a)
		{
 	 		var idval = o;
 		 	var getidval=document.getElementById("MeterOption");
			getidval.value=idval
			
			document.getElementById("lblPeriod").disabled=true;
			document.getElementById("DrpSelectTime").disabled=true;
			document.getElementById("lblTimePeriod").disabled=true;
 		 }
		 
		 
		 function SetZoomValueSystem(o,a)
			{
 			 	var idval = o;
 				var sysID = a;
 			 
 		  	var getidval=document.getElementById("MeterOption");
			getidval.value=idval
 	 		var getSysidval=document.getElementById("Midentity");
			getSysidval.value=sysID
			
				
			document.getElementById("lblPeriod").disabled=true;
			document.getElementById("DrpSelectTime").disabled=true;
			document.getElementById("lblTimePeriod").disabled=true;
		 
		 }
		 
		
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR><input id="Midentity" type="hidden" name="Midentity">
						<input id="MeterOption" type="hidden" name="MeterOption">
					</td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" width="100%" height="100%" Runat="server">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top" align=center>
															 <asp:panel id="pnlManagerInfiniOffice" Runat="server" Width="95%">
																	<TABLE border="0" height="100%" Width="100%">
																		<TR vAlign="top" Width="100%" >
																			<TD vAlign="top" align="center"  Width="100%" ><BR>
																				<asp:Label id="lblPeriod" runat="server" CssClass="wizardText">Select Period</asp:Label>
																				<asp:DropDownList id="DrpSelectTime" runat="server" CssClass="wizardOptions" AutoPostBack="True">
																					<asp:ListItem Value="Yearly" Selected="True">Yearly</asp:ListItem>
																					<asp:ListItem Value="Biannually ">Biannually </asp:ListItem>
																					<asp:ListItem Value="Quarter">Quarter</asp:ListItem>
																				</asp:DropDownList><BR>
																				<BR>
																				<asp:Label id="lblTimePeriod" runat="server" CssClass="wizardText"></asp:Label><BR>
																				<BR>
																				<ASP:PANEL id="InfiniOfficePanel" Runat="server" CssClass="tableborder1" height="50%" Width="100%" visible="True">
																					<TABLE align="center" height="100%" border="0" Width="95%">
																						<TR vAlign="top">
																							<TD align="center">
																								<DIV class="meterIOffice" id="InfiniOfficeView">
																										<asp:Table id="StaticIO" Runat="server" CssClass="trsettings" Width="100%" Visible="False"></asp:Table>
																								
																									<asp:Table id="InfiniOfficeMeter" Runat="server" Visible="False" CssClass="trsettings" Width="100%"></asp:Table>
																									<ASP:TABLE id="InfiniOfficeAdvanceMeters" runat="server" Visible="False" CssClass="trsettings"
																										Width="100%" Border="0"></ASP:TABLE> 
																												<ASP:BUTTON id="InfiniOfficeimgbtnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																												runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Back"></ASP:BUTTON>
																										</DIV>
																							</TD>
																						</TR>
																					 
																								 
																					</TABLE>
																			</ASP:PANEL> 
																				<!--  <ASP:IMAGEBUTTON id="InfiniOfficezoommeter" runat="server" Visible="True" ImageUrl="/images/infiniplan/zoommeter.jpg"
																					ToolTip="Zoom"></ASP:IMAGEBUTTON>  -->
																				</TD>
																			<TD vAlign="top" align="center"  >
																				<ASP:PANEL id="PanelInfiniOfficeZoom" Runat="server" CssClass="tableborder1"  Visible=False Width="100%" Height="95%">
																					<TABLE height="100%" width="100%" align="center" border="0">
																						<TR vAlign="top" height="70%">
																							<TD align="center" width="100%">
																								<ASP:LABEL id="lblZoomEntity" runat="server" cssclass="flashTitle">+</ASP:LABEL>
																								<DIV class="IOfficeZoomSpace" id="ZoomViewInfiniOffice" align="center">
																									<ASP:TABLE id="ZoomInfiniOfficeMeter" runat="server" CssClass="trsettings" border="0"></ASP:TABLE></DIV>
																							</TD>
																						</TR>
																					<!--	<TR vAlign="top" height="30%">
																							<TD align="center">
																								<ASP:BUTTON id="btnAdvInfiniOffice" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Advanced"></ASP:BUTTON></TD>
																						</TR> -->
																					</TABLE>
																				</ASP:PANEL></TD>
																		</TR>
																		<TR vAlign="top">
																			<TD align="center" width="20%"></TD>
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
		<script>
			if ( document.domain == 'enterprise.infinimation.com')
{
 document.domain='infinimation.com';
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
 parent.resizeFrame(scrollHeight,scrollWidth);
 }
 else 
 {
 }
		</script>
	</body>
</HTML>
