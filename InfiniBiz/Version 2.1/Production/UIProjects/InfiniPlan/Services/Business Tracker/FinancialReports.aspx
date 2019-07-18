<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FinancialReports.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.FinancialReports"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HEAD>
	<title>Plan Tracker Reports</title>
	<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
	<script src="../../Library/Scripts/BusinessGrid.js"></script>
	<script src="../../Library/Scripts/Calculations.js"></script>
	<script src="../../Library/Scripts/PlanWizard.js"></script>
	<script src="../../Library/Scripts/simModal.js"></script>
	<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
		<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
</HEAD>
<body class="cngbody" onkeydown="return catchEnter();" onload="Init()">
	<form id="Form2" method="post" runat="server">
		<!-- **************************************************************************************************************************** -->
		<!-- Actual Page Contents are to be written here  -->
		<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
			<tr>
				<td vAlign="top">
					<!--        Header Bar  --></td>
			</tr>
			<tr width="100%">
				<td align="center">
					<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
							<td class="TableBox_Top" height="3">&nbsp;</td>
							<td class="TableBox_Top_Right" height="3">&nbsp;</td>
						</tr>
						<tr>
							<td class="TableBox_Left" width="0%"></td>
							<td vAlign="top" align="center" height="100%">
								<!-- Center Table --><asp:panel id="pnlManager" Runat="server" Width="880px">
									<TABLE height="100%" width="100%">
										<TR>
											<TD>
												<TABLE id="Table2" height="100%" width="100%">
													<TBODY>
														<TR>
															<TD height="1%">
																<TABLE id="Table3" height="1%" width="873">
																	<TBODY>
																		<TR>
																			<TD align="center" vAlign="top" colSpan="2">
																				<asp:label id="lblName" runat="server" Font-Size="Small" Font-Bold="True" Font-Names="tahoma"
																					EnableViewState="False"></asp:label></TD>
																		</TR>
																		<tr>
																			<td align="center" colSpan="2" height="1%" vAlign="top"><asp:label id="lblType" runat="server" Font-Underline="True" CssClass="sheetType"></asp:label></td>
																		</tr>
																		<tr>
																			<td colSpan="2">&nbsp;</td>
																		</tr>
																		<TR height="1%" width="100%">
																			<td width="50%" align="center"><asp:label id="YearHead" runat="server"   Font-Underline="True"
																					CssClass="sheetTypesettings"></asp:label></td>
																			<TD align="center" width="50%" height="2"><asp:label id="MonthSelect" runat="server" Font-Size="X-Small" Font-Bold="True" Font-Names="tahoma"
																					Visible="False" ForeColor="Black"></asp:label><asp:dropdownlist id="cmbMonth" runat="server" Width="38%" CssClass="wizardOptions" Visible="False"
																					AutoPostBack="true"></asp:dropdownlist><asp:label id="Click" runat="server" Font-Size="XX-Small" Font-Names="tahoma" Visible="False">&nbsp;</asp:label></TD>
																		</TR>
																<!--
																			<TR vAlign="middle" width="100%">
																				<TD align="right">
																					<asp:imagebutton id="lnkFirst" runat="server" ImageUrl="/images/InfiniPlan/lnkFirst.gif" Visible="False"></asp:imagebutton></TD>
																				<TD align="right">
																					<asp:imagebutton id="lnkBackMonth" runat="server" ImageUrl="/images/InfiniPlan/lnkBackMonth.gif"
																						Visible="False"></asp:imagebutton></TD>
																				<TD align="left">
																					<asp:imagebutton id="lnkNextMonth" runat="server" ImageUrl="/images/InfiniPlan/lnkNextMonth.gif"
																						Visible="False"></asp:imagebutton></TD>
																				<TD align="left">
																					<asp:imagebutton id="lnkLast" runat="server" ImageUrl="/images/InfiniPlan/lnkLast.gif" Visible="False"></asp:imagebutton></TD>
																			</TR> -->
															</TD>
														</TR>
													</TBODY></TABLE>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<TABLE id="Table5">
													<TR>
														<TD align="center"><asp:panel id="AnnualHeader" Runat="server" Visible="False">
																<TABLE id="aa" height="60" width="841">
																	<TR>
																		<TD class="ReportHeader1" align="left" width="40%" rowSpan="2">
																			<asp:Label id="lblCategoriesDescription" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center">
																			<asp:Label id="lblPrevious" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="50%" colSpan="3">
																			<asp:Label id="lblComparison" runat="server"></asp:Label>
																			<asp:label id="lblTime" runat="server" Font-Names="tahoma" Font-Bold="True" Font-Size="X-Small"
																				Font-Underline="True" Visible="False"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD align="center" width="20%" bgColor="#f3f3f3">
																			<asp:DropDownList id="ddlPreviosYears" runat="server" Width="100%" CssClass="PreviousYearsOptions"
																				AutoPostBack="true" align="center"></asp:DropDownList></TD>
																		<TD class="ReportHeader" align="center" width="13%">
																			<asp:Label id="lblActual" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="13%">
																			<asp:Label id="lblEstimated" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="13%">
																			<asp:Label id="lblDeviation" runat="server"></asp:Label></TD>
																	</TR>
																</TABLE>
															</asp:panel><asp:panel id="MonthlyPanel" Runat="server" Visible="False">
																<TABLE id="Table6" width="100%" align="center">
																	<TR>
																		<TD class="ReportHeader1" align="left" width="50%" rowSpan="2">
																			<asp:Label id="lblCategoriesDescriptionM" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="50%" colSpan="3">
																			<asp:Label id="lblComparisonM" runat="server"></asp:Label></TD>
																	</TR>
																	<TR>
																		<TD class="ReportHeader" align="center" width="15%">
																			<asp:Label id="lblActualM" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="15%">
																			<asp:Label id="lblEstimatedM" runat="server"></asp:Label></TD>
																		<TD class="ReportHeader" align="center" width="15%">
																			<asp:Label id="lblDeviationM" runat="server"></asp:Label></TD>
																	</TR>
																</TABLE>
															</asp:panel>
															<DIV class="ReportSpace" id="ReportSpace"><asp:table id="Main" width="100%" Runat="server"  ></asp:table></DIV>
															<BR>
															<asp:button id="btnHome" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																runat="server" Cssclass="MBUTTONACCPRO" Text="Home"></asp:button>&nbsp; 
															&nbsp;
															<asp:button id="btnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																runat="server" Cssclass="MBUTTONACCPRO" Text=" Back "></asp:button></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE></td>
						</tr>
					</table>
					</asp:panel>
				</td>
				<td class="TableBox_Right" width="0%">&nbsp;&nbsp;&nbsp;</td>
			</tr>
			<tr width="100%">
				<td class="TableBox_Bot_Left" width="0%"></td>
				<td class="TableBox_Bot" width="100%"></td>
				<td class="TableBox_Bot_Right" width="0%"></td>
			</tr>
		</table>
		</TD></TR></TBODY></TABLE> 
		<!-- Actual Page Contents are to be written upto here  -->
		<!-- **************************************************************************************************************************** --></form>
</body>
<script>
	if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth -100 ;
parent.resizeFrame(scrollHeight,scrollWidth);
 }
  else 
 {
  }
</script>