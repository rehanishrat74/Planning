<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Table.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Table"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<HTML xmlns:o>
	<HEAD>
		<title>Table</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/BusinessGrid.js"></script>
		<script src="../../Library/Scripts/Calculations.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../Scripts/AjaxCallObject.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="cngbody" onkeydown="return catchEnter();" onload="Init()">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19" colSpan="3">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%" width="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<tr>
									<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
								</tr>
								<tr>
									<td vAlign="top" width="1%" height="100%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
									<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
									<td vAlign="top" width="100%" height="100%" colSpan="3">
										<!-- ******************************************************************* -->
										<!-- Actual Page Contents are to be written here  -->
										<input id="SelectedRowNumber" type="hidden" value="-1" name="SelectedRowNumber">
										<input id="NewRowName" type="hidden" name="NewRowName"> <input id="SelectedColNumber" type="hidden" value="0" name="SelectedColNumber">
										<input id="ChangedCells" type="hidden" name="ChangedCells"> <input id="Save" type="hidden" name="Save">
										<table cellSpacing="0" cellPadding="0" height="100%" width="100%" border="0">
											<TBODY>
												<tr>
													<td vAlign="top" align="center" height="20" bgcolor="#f3f3f3"><asp:label id="lblHeader" runat="server" CssClass="lblHeading" Width="100%"></asp:label><asp:label id="lblMessage" runat="server" CssClass="lblErrorMessage" Width="100%"></asp:label></td>
												</tr>
												<tr>
													<td vAlign="top" height="10"><IMG height="10" src="/images/InfiniPlan/blank.gif" width="1">&nbsp;
														<TABLE class="pagecontents" id="tblcontents" cellSpacing="1" cellPadding="1" width="100%"
															border="0" runat="server">
															<TR>
																<TD>
																	<P><SPAN></SPAN></P>
																</TD>
															</TR>
														</TABLE>
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
																	<!-- Center Table -->
																	<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
																		<tr>
																			<td align="center">
																				<table width="100%" border="0" height="100%" align="center">
																					<tr valign=top>
																						<td align="center" valign=top><asp:panel id="GridControlPanel" Width="100%" Visible="False" Runat="server">
																								<DIV align="center">
																									<ajax:AjaxPanel id="AjaxPanel1" runat="server">
																										<UC:GRIDCONTROL id="ChooseGrid1" runat="server"></UC:GRIDCONTROL>
																									</ajax:AjaxPanel></DIV>
																							</asp:panel>
																						</td>
																					</tr>
																					<tr>
																						<td align="center"><asp:panel id="Panel1" Width="100%" Visible="False" Runat="server">
																								<TABLE width="100%" border="0">
																									<TR>
																										<TD align="center">
																											<asp:Label id="msg" Runat="server" cssclass="pagecontents"></asp:Label></TD>
																									</TR>
																									<TR>
																										<TD align="center"><BR>
																											<BR>
																											<asp:Button id="btnImportBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																												runat="server" CssClass="MBUTTONACCPRO" Text=" "></asp:Button></TD>
																									</TR>
																								</TABLE>
																							</asp:panel></td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																		<!-- Row -->
																		<tr>
																			<td>&nbsp;</td>
																		</tr>
																		<tr>
																			<td vAlign="top">
																				<!-- Center Table Start  --><asp:panel id="gridPanel" Width="100%" Runat="server">
																					<DIV class="gridSpace1" id="gridDiv">
																						<BIZPLAN:BUSINESSGRID id="bgTable" runat="server" GridLines="Vertical" ShowFooter="False" CellSpacing="0"
																							CellPadding="0" AutoGenerateColumns="false">
																							<COLUMNS>
																								<ASP:TEMPLATECOLUMN HeaderText="Column0">
																									<ITEMSTYLE Width="10%"></ITEMSTYLE>
																									<ITEMTEMPLATE></ITEMTEMPLATE>
																								</ASP:TEMPLATECOLUMN>
																								<ASP:TEMPLATECOLUMN HeaderText="Column1">
																									<ITEMSTYLE Width="10%"></ITEMSTYLE>
																									<ITEMTEMPLATE></ITEMTEMPLATE>
																								</ASP:TEMPLATECOLUMN>
																								<ASP:TEMPLATECOLUMN HeaderText="Column2">
																									<ITEMSTYLE Width="10%"></ITEMSTYLE>
																									<ITEMTEMPLATE></ITEMTEMPLATE>
																								</ASP:TEMPLATECOLUMN>
																							</COLUMNS>
																							<SELECTEDITEMSTYLE BackColor="Red"></SELECTEDITEMSTYLE>
																						</BIZPLAN:BUSINESSGRID></DIV>
																				</asp:panel> </td>
																		</tr>
																		<!-- Row -->
																		<tr>
																			<td vAlign="top" height="3"><IMG height="10" src="../images/InfiniPlan/blank.gif" width="1"></td>
																		</tr>
																		<!-- Row -->
																		<tr align="center">
																			<TD vAlign="top" align="center">
																				<table width="70%" align=center >
																					<tr>
																						<td align="center"><asp:button id="InsertButton" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="1" onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Cssclass="MBUTTONACCPRO"></asp:button></td>
																						<td align="center"><asp:button id="ImportButton" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="2"
																								onmouseout="this.className='MBUTTONACCPRO';" runat="server" Visible="True" Cssclass="MBUTTONACCPRO" Enabled="false"></asp:button></td>
																						<td align="center"><asp:button id="DeleteButton" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="2" onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Cssclass="MBUTTONACCPRO"></asp:button></td>
																						<td align="center"><asp:button id="btnRename" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="3" onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Cssclass="MBUTTONACCPRO"></asp:button></td>
																						<td align="center"><asp:button id="btnUpdate" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="3" onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Cssclass="MBUTTONACCPRO"></asp:button></td>
																						<td align="center"><asp:button id="btnCopyRest" onmouseover="this.className='MBUTTONACCPROON';" tabIndex="3" onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Cssclass="MBUTTONACCPRO"></asp:button></td>
																					</tr>
																				</table>
																			</TD>
																		</tr>
																		<!-- Row -->
																		<tr>
																			<td>
																				<table width="60%">
																					<tr>
																						<td align="right"></td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</table>
																	<!-- Center Table -->
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
										<!-- Actual Page Contents  are to be written upto here  -->
										<!-- ********************************************************************************************************* -->
									</td>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" align="center" width="100%" colSpan="5"><asp:button id="btnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
							runat="server" Width="120px" Visible="False" Cssclass="MBUTTONACCPRO"></asp:button>&nbsp;
						<asp:button id="btnNext" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
							runat="server" Width="120px" Visible="False" Cssclass="MBUTTONACCPRO"></asp:button></TD>
				</TR>
			</table>
			</TD></TR></TR>
			<tr id="trBottomMain" runat="server">
				<td vAlign="bottom" colSpan="5"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE>
		</form>
		</TD></TR></TBODY></TABLE>
		<script>
		if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight + 50  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth + 50 ;
parent.resizeFrame(scrollHeight,scrollWidth);
 }
  else 
 {
 }
		</script>
	</body>
</HTML>
