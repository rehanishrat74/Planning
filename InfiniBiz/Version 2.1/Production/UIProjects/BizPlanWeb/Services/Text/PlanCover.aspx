<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"		%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanCover.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanCover"%>
<HTML>
	<HEAD>
		<title>Text</title>
		<meta content="False" name="vs_showGrid">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<!--<LINK href="../../Library/Styles/main.css" type="text/css" rel="stylesheet">-->
			<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
				<script src="../../Library/Scripts/PlanWizard.js"></script>
				<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" height="100%" width="100%" bgcolor="white">
				<tr id="trTopMain" runat="server">
				</tr>
				<tr>
					<td vAlign="top" height="19"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" border="0" width="100%" height="100%">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table class="centretable" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
										<tr>
											<td vAlign="top" align="center" bgcolor="#f3f3f3" height="19">
												<asp:label id="lblTableHeading" runat="server" Cssclass="lblHeading" Width="100%" Height="1%"></asp:label>
											</td>
										</tr>
										<tr>
											<td vAlign="top" align="center">
												<table cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<TR>
														<TD class="TableBox_Left"></TD>
														<TD align="center"><asp:label id="lblErrorMessage" runat="server" CssClass="lblErrorMessage" Width="100%"></asp:label></TD>
														<TD class="TableBox_Right"></TD>
													</TR>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<!--<td align="center" style="padding-top:20px">-->
														<td align="center" valign="top">
															<TABLE id="Table1" border="0" cellSpacing="0" width="40%" height="100%">
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%" colSpan="1" rowSpan="1"><div Class="page-section-text1"><asp:label id="lblPlanTitle" runat="server" Height="7px"></asp:label>
																		</div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><INPUT class="Covertxtfields" id="txtPlanTitle" type="text" name="txtPlanTitle" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%" height="40"><div Class="page-section-text1"><asp:label id="lblDate" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%" height="40"></TD>
																	<TD width="49.5%" height="40"><INPUT class="Covertxtfields" id="txtDate" type="text" name="txtDate" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%" colSpan="1" rowSpan="1"><div Class="page-section-text1"><asp:label id="lblCopyNumber" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><INPUT class="Covertxtfields" id="txtCopyNo" type="text" name="txtCopyNo" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblOwner" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><INPUT class="Covertxtfields" id="txtOwnership" type="text" name="txtOwnership" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblName" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><TEXTAREA class="CovertxtArea" id="txtName" name="txtName" rows="2" cols="20" runat="server"></TEXTAREA></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblTitle" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><INPUT class="Covertxtfields" id="txtTitle" type="text" name="txtTitle" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblAddress" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><TEXTAREA class="CovertxtArea" id="txtAddress" name="txtAddress" rows="2" cols="20" runat="server"></TEXTAREA></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblPhone" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%" height="24"></TD>
																	<TD width="49.5%" height="24"><INPUT class="Covertxtfields" id="txtPhoneNo" type="text" name="txtPhoneNo" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%"><div Class="page-section-text1"><asp:label id="lblMisc" runat="server"></asp:label></div>
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"><INPUT class="Covertxtfields" id="txtMisc" type="text" name="txtMisc" runat="server"></TD>
																</TR>
																<TR>
																	<TD vAlign="middle" align="left" width="30.5%">&nbsp;
																	</TD>
																	<TD width="1%"></TD>
																	<TD width="49.5%"></TD>
																</TR>
																<TR>
																	<TD colspan="3" width="20.5%" align="center">
																		<asp:button id="btnUpdateText" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
																			onmouseout="this.className='MBUTTONACCPRO';" Width="96px"></asp:button>&nbsp;
																	</TD>
																</TR>
															</TABLE>
														</td>
														<td class="TableBox_Right" width="0%">aa
														</td>
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
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
		<script>
 
document.domain='infinimation.com';
 
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth;
 
parent.resizeFrame(scrollHeight,scrollWidth);
 
		</script>
	</body>
</HTML>
