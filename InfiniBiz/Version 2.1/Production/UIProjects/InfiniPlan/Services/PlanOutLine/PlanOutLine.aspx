<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanOutLine.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanOutLine"%>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<HTML>
	<HEAD>
		<title>PlanOutLine</title> 
		<!--<STYLE type="text/css">
			*#danish { letter-spacing: 0.3em; 	filter:progid:DXImageTransform.Microsoft.Shadow(color='silver', Direction=135, Strength=5); }
		</STYLE>-->
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../library/Scripts/simModal.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<script type="text/javascript">
			 
		 
			
			function delete_prompt()
			{				
				var return_val = confirm("Are you sure you want to delete the selected Folder?")
				var retValue = document.getElementById("ret_val")
		 
				if (return_val == false)
				{	
					return false
				}	
			}
			
			function restore_prompt()
			{				
				var retValue = document.getElementById("ret_val")				
				var return_val = confirm("Are you sure you want to restore the Default Plan Outline?")
				if (return_val == false)
				{	
					return false
				}				
			}
			</script>
	</HEAD>
	<body>
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr id="trTopMain" runat="server">
						<td vAlign="top" colSpan="2" height="19"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
					</tr>
					<tr vAlign="top">
						<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
						<td vAlign="middle" align="center" height="100%">
							<table height="100%" cellSpacing="0" cellPadding="0" width="99%" border="0">
								<TBODY>
									<tr>
										<td vAlign="top" align="center" colSpan="5" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="lblHeading">Plan Out Line</asp:label></td>
									</tr>
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<tr>
										<td align="center">
											<table dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr>
													<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
													<td class="TableBox_Top" height="3">&nbsp;</td>
													<td class="TableBox_Top_Right" height="3">&nbsp;</td>
												</tr>
												<tr>
													<td class="TableBox_Left" width="0%"></td>
													<td vAlign="top" height="100%">
														<!-- Center Table -->
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr>
																<td align="center"><asp:label id="lblHelpHeading" CssClass="pagecontents" Runat="server"></asp:label></td>
															</tr>
															<tr vAlign="top">
																<td>
																	<br>
																	<table cellSpacing="0" cellPadding="0"  class="GridBodyOutLine" width="100%" align="center" border="0">
																		<!-- new -->
																		
																					<TR   vAlign="top" width="100%">
																							<TD width="100%" height="1">
																								<asp:label id="PlanOutLineHeading" runat="server" width="100%" Height="16px" cssclass="PlanOutLine1"></asp:label></TD>
																						</TR>
																		<TR>
																			<!-- new -->
																			<td vAlign="top" width="100%" height="100%" align=center>
																				<asp:panel id="TreeViewPanel"   Runat="server" align=center>
																					<asp:textbox id="ret_val" style="DISPLAY: none" runat="server" EnableViewState="False"></asp:textbox>
																					<TABLE id="TreeViewTable" width="100%" align="center" border="0"    valign="top">
																						<TR>
																							<TD align=center  colSpan="2" height="12">
																								<asp:label id="exception" runat="server" CssClass="lblErrorMessage" Height="16px">  </asp:label></TD>
																						</TR>
																						<TR vAlign="top">
																							<TD align="center" width="100%" colSpan="2" height="203">
																								<DIV>
																									<iewc:treeview id="TreeView1" cssclass="TrackerCss" runat="server" width="100%" Height="221px" AutoPostBack="True" HoverStyle="filter=none;background-color:#F3F3F3;"
																										SelectedStyle="filter=none;background-color:#F3F3F3;font-weight:bold;font-color:black;" DefaultStyle="font-family:Times New Roman;font-size:14pt;background-color:white;"></iewc:treeview></DIV>
																							</TD>
																						</TR>
																						<TR height="12">
																							<TD align=center   colSpan="2"> 
																							 
																								<asp:label id="lblSelectedNode" runat="server" CssClass="wizardtext"></asp:label> &nbsp;&nbsp;&nbsp;
																								<asp:button id="btnDelete" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Cssclass="MBUTTONACCPRO" Text="Delete"></asp:button>&nbsp;
																								<asp:button id="btnRestore" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Cssclass="MBUTTONACCPRO"></asp:button>
																									 
																									<asp:label id="lblEdit" runat="server" visible=false  Width="100%" Height="1px" cssclass="PlanOutLine1"></asp:label> 
																								</TD>
																						</TR>
																					</TABLE>
																				</asp:panel>	
																			</td>
																			<!-- new -->
																		 
																			 
																								 
																						 
																	</table>
																</td>
																<!-- /new --></tr>
														</table>
													</td>
													<td class="TableBox_Right" width="0%">a
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
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
								</TBODY></table>
					<tr id="trBottomMain" runat="server">
						<td vAlign="bottom" colSpan="2" height="26"><uc1:bizplanfooter id="BizPlanFooter1" runat="server" DESIGNTIMEDRAGDROP="75"></uc1:bizplanfooter></td>
					</tr>
				</TBODY></table>
		</form>
	</body>
</HTML>
