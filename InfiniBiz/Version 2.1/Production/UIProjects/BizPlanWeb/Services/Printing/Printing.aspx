<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Printing.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Printing"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan Printing</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css"></link>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
		<script language="javascript">
function GetFocus()
{
SelectPlanNav(4)
 
}
	
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
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
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="19" align="center" valign="top" Width="100%" bgcolor=#F3F3F3>
												<asp:Label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:Label>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td height="100%" valign="top">
															<asp:Panel ID="pnlManager" Runat="server" Height="100%">
																<TABLE id="myTable" height="302" width="400" align="center" border="0">
																	<TR vAlign="top" height="100%" width="100%">
																		<TD vAlign="middle" align="center"><A onclick="javascript:void(0);return SelectPlanNav(4);" href="/InfiniPlan/Services/Printing/Printing.aspx?printid=0"><IMG Visible=False id="ImagebuttonPreview" height="48" src="/images/InfiniPlan/plan_preview.jpg" width="55"	border="0" runat="server" > </A>
																			<BR>
																			<BR>
																			<asp:LinkButton id="lnkPlanPreview" runat="server" CssClass="MultilingulLinkStyle" Visible="False"></asp:LinkButton></TD>
																		<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/Printing/Printing.aspx?printid=1"><IMG Visible=False id="ImagebuttonExport" src="/images/InfiniPlan/export.jpg" border="0" runat="server"> </A>
																			<BR>
																			<BR>
																			<asp:LinkButton id="lnkExportPlan" runat="server" CssClass="MultilingulLinkStyle" Visible="False"
																				Text=""></asp:LinkButton></TD>
																		<TD vAlign="middle" align="center"><A href="/InfiniPlan/Services/Printing/Printing.aspx?printid=2"><IMG id="ImagebuttonPlanoutline" src="/images/InfiniPlan/PlanOutLine.jpg" border="0" runat="server" Visible="false"> </A>
																			<BR>
																			<BR>
																			<asp:LinkButton id="lnkPlanOutline" runat="server" CssClass="MultilingulLinkStyle" Text=""></asp:LinkButton></TD>
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
	 <!-- <script>
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
parent.resizeFrame(scrollHeight,scrollWidth);
 
		</script> -->
	</body>
</HTML>
