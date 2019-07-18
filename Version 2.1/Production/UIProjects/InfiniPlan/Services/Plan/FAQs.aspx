<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FAQ.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.FAQ" %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan FAQs</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css"></link>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
	</HEAD>
	<body class="cngbody" onload="FAQ_ToggleDL()">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" 
dir=<%=Session("dir")%>>
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
											<td align="center" style="padding-top:5px">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir=ltr>
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td height="100%" valign="top">
															<!-- Center Table -->
															<asp:Panel ID="pnlManager" Runat="server">
																<TABLE height="100%" width="100%" 
dir=<%=Session("dir")%>>
																	<!--<TR>
																		<TD align="right"><DIV  style="display:none" id="FAQ_ToggleON">Open All</DIV>
																			<DIV class="FAQTopOfPageLink" id="FAQ_ToggleOFF">Close All</DIV>
																		</TD>
																	</TR>-->
																	<TR>
																		<TD>
																			<asp:Label id="lblFAQs" runat="server" text=""></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD align="center"><!--<a class = "ShowHideAnchors" href="#top"> top </a>--> <!--<a href="#top"> <img src="../../images/InfiniPlan/up_arrow.jpg"> </a>--><A href="#top">
																				<DIV class="FAQTopOfPageLink" align="center">Top of Page</DIV>
																			</A>
																		</TD>
																	</TR>
																</TABLE>
															</asp:Panel>
														</td>
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
									<asp:ImageButton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:ImageButton>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="bottom">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
