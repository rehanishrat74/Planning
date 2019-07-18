<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CreatePlan.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.CreatePlan"%>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Create Plan</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css"></link>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
				<tr>
					<td height="19" vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0" bgcolor="white">
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
											<td height="19" align="center" valign="top" Width="100%" bgcolor="#f3f3f3">
												<asp:Label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:Label>
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
															<asp:Panel ID="pnlManager" Runat="server">
																<TABLE height="100%" width="100%">
																	<TR>
																		<TD>
																			<asp:panel id="Panel1" runat="server" Width="100%" height="100%" Visible="true">
																				<TABLE width="100%" align="center" border="0">
																					<TR>
																						<TD vAlign="top" colSpan="2" height="100%">
																							<asp:label id="Label1" Runat="server" height="100%" CssClass=wizardtext>
																								<p class="MsoNormal"><span lang="EN-US">InfiniPlan helps you create business plans
easily with the help of a wizard. There are also some sample plans available
for your reference. </span></p>
																								<p class="MsoNormal"><span lang="EN-US">To create a new plan, click the <b>New Plan</b>
button. This will take you to the Plan Wizard, where you answer some questions
and the wizard creates a plan according to those answers. </span></p>
																								<p class="MsoNormal"><span lang="EN-US">You can also open previously saved plans
and sample plans from the Select Plan page. To open a plan, click on the <b>Select Plan</b> node in the left hand window and follow instructions.</span></p>
																								<p class="MsoNormal"><span lang="EN-US">Please note that once you have opened a
plan, you can not create another plan. To create another plan, first you have
to close the currently opened plan. Use the <b>Close Plan</b> node in the left
hand window or a <b style='mso-bidi-font-weight:normal'>Close Plan</b> button to
close a plan. </span></p>
																							</asp:label></TD>
																					</TR>
																					<TR>
																						<TD align=center  width="100%" colSpan="2" height="100%">
																							<P>&nbsp;</P>
																							<P><BR>
																								<asp:button id="imgBtnNewPlan" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Width="15%" Font-Size="8pt" Text="New Plan" Cssclass="MBUTTONACCPRO"></asp:button>
																								<asp:button id="btnClosePlan" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Width="15%" Font-Size="8pt" Text="Close Plan" Cssclass="MBUTTONACCPRO"></asp:button></P>
																						</TD>
																					</TR>
																				</TABLE>
																			</asp:panel></TD>
																	</TR>
																</TABLE>
															</asp:Panel>
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
									<asp:ImageButton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:ImageButton>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
					</td>
				</tr>
			</table>
		</form>
		<script>
		if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +30;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
parent.resizeFrame(scrollHeight,scrollWidth);
}
else 
{
}
		</script>
	</body>
</HTML>
