<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Home.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Home"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<HTML xmlns:o>
	<HEAD>
		<title>Plan Home </title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<!-- **************************************************************************************************************************** -->
		<!-- Actual Page Contents are to be written here  -->
		<form id="Form2" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" border="0" height="100%" cellPadding="0" cellSpacing="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" align="right"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td align="center">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir="ltr">
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
																<TABLE class="pageContents" height="100%" cellSpacing="0" cellPadding="0" width="100%"
																	border="0">
																	<TR vAlign="top">
																		<TD vAlign="top"><!--<asp:Label id="lblHeading1" runat="server" cssclass="lblHomePage_Style" Font-Bold="True"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText1" runat="server"></asp:Label><BR>
																			<BR>
																			<asp:Label id="lblHeading2" runat="server" cssclass="lblHomePage_Style" Font-Bold="True"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText2" runat="server"></asp:Label><BR>
																			<BR>
																			<asp:Label id="lblHeading3" runat="server" cssclass="lblHomePage_Style" Font-Bold="True"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText3" runat="server"></asp:Label><BR>-->
																			<asp:Label id="txtText4" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText5" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText6" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<asp:Label id="txtText7" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<asp:Label id="txtText8" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<BR>
																			<asp:Label id="txtText9" runat="server" Font-Size="10pt" Font-Names="Verdana"></asp:Label><BR>
																			<BR>
																			<BR>
																			<asp:Button id="btnStart" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																				runat="server" Cssclass="MBUTTONACCPRO" Width="64px" Text=""></asp:Button></TD>
																	</TR>
																	<TR>
																		<TD>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD>&nbsp;</TD>
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
