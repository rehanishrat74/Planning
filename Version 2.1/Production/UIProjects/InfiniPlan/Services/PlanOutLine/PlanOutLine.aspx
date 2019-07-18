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
		</STYLE>--><BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../library/Scripts/simModal.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<script type="text/javascript">
			function _init()
			{				
				alert('ss')
				//scrollTo(0,0)
				document.getElementById("TreeView1").scrollLeft=0;				
			}
			function changeContent(id,shtml)
				{					
					if (document.getElementById || document.all) {
						var el = document.getElementById? document.getElementById(id): document.all[id];
						if (el && typeof el.innerHTML != "undefined") el.innerHTML = shtml;
					}
				}
			
			function showTooltip(id,txtsource)
				{	
					text = document.getElementById(txtsource)
					changeContent(id,text.innerHTML)	
				}
				
			function insert_prompt(selectedNode)
			{
				var name
				var retValue = document.getElementById("ret_val")				
				var rb_Root = document.getElementById("rbRoot")
				var rb_Child = document.getElementById("rbChild")
				if(rb_Root.checked==true)
					{
						name=prompt("The New Folder will be created after "+selectedNode,"")
					}
				else
					{
						name=prompt("The New Folder will be created as a Sub Folder of "+selectedNode,"")
					}				
				if (name!=null)
				{					
					//__doPostBack("btnInsert_Click",name)
					retValue.value = name					
				}
				else
				{
					return false
				}
			}
			
			function rename_prompt(selectedNode)
			{
				
				var name
				var retValue = document.getElementById("ret_val")				
				name = prompt("Are you sure you want to rename "+selectedNode+" to","")
				if (name!=null)
				{
					retValue.value = name					
				}
				else
				{
					return false
				}
				//	_init()
			}
			
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
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<TBODY>
					<tr>
						<td vAlign="top" height="19" colspan="2"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
					</tr>
					<tr vAlign="top">
						<td vAlign="middle" align="center" height="100%">
							<table height="100%" cellSpacing="0" cellPadding="0" width="99%" border="0">
								<TBODY>
									<tr>
										<td vAlign="top" colSpan="5" height="1" align="center"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"><asp:label id="lblHeader" runat="server" CssClass="lblHeading" Width="100%">Plan Out Line</asp:label></td>
									</tr>
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<tr>
										<td>&nbsp;</td>
									</tr>
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
														<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
															<tr>
																<td>&nbsp;</td>
															</tr>
															<tr valign="top">
																<td><table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
																		<!-- new -->
																		<TBODY>
																			<TR>
																				<td vAlign="top" width="4%"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20">
																				</td>
																				<!-- new -->
																				<td width="229" height="100%"><asp:panel id="TreeViewPanel" height="100%" Runat="server">
																					<!--	<ajax:ajaxpanel id="AjaxPanelTreeView" runat="server" height="99%" width="100%"> -->
																							<asp:textbox id="ret_val" style="DISPLAY: none" runat="server" EnableViewState="False"></asp:textbox>
																							<TABLE id="TreeViewTable" align="center" valign="top">
																								<TR class="TRPlanOutLine_Style" vAlign="top" width="100%">
																									<TD width="100%" height="1">
																										<asp:label id="PlanOutLineHeading" runat="server" width="100%" cssclass="PlanOutLine" Height="16px"></asp:label></TD>
																								</TR>
																								<TR vAlign="top">
																									<TD align="left" width="100%" colSpan="2" height="183">
																										<DIV>
																											<iewc:treeview id="TreeView1" runat="server" Width="300px" Height="230px" AutoPostBack="True" HoverStyle="filter=none;background-color:#ECF4FC;"
																												SelectedStyle="filter=none;background-color:LightSteelBlue;&#13;&#10;font-weight:bold;font-color:#ffffff;"
																												DefaultStyle="font-family:Times New Roman;font-size:14pt;background-color:white;"></iewc:treeview></DIV>
																									</TD>
																								</TR>
																								<TR>
																									<TD height="17"></TD>
																								</TR>
																								<TR>
																									<TD vAlign="bottom" align="left" width="100%" colSpan="2"><!--style="padding-top:10px"-->
																										<asp:button id="btnCancel" onmouseover="this.className='MBUTTONACCPROON';changeContent('ToolTip','Go Home')"
																											onmouseout="this.className='MBUTTONACCPRO';showTooltip('ToolTip','idleTxt')" runat="server"
																											Cssclass="MBUTTONACCPRO"></asp:button></TD>
																								</TR>
																							</TABLE>
																						<!-- </ajax:ajaxpanel> -->
																					</asp:panel></td>
																</td>
																<!-- new -->
																<td vAlign="top" width="20" height="100%"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20">
																</td>
																<!-- new -->
																<td width="461" height="100%"><ajax:ajaxpanel id="EditAjaxpanel" runat="server" height="0.04%" width="100%">
																		<TABLE id="EditTable" height="293" width="520" align="center" valign="top">
																			<TR class="TRPlanOutLine_Style" vAlign="top" width="100%">
																				<TD width="100%" colSpan="2">
																					<asp:label id="lblEdit" runat="server" Width="100%" cssclass="PlanOutLine" Height="16px"></asp:label></TD>
																			</TR>
																			<TR>
																				<TD align="center" colSpan="2">
																					<asp:label id="exception" runat="server" CssClass="lblErrorMessage" Height="16px"></asp:label></TD>
																			</TR>
																			<TR>
																				<TD align="left" colSpan="2">
																					<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%">
																						<TR>
																							<TD width="434">
																								<asp:Label id="lblSelectedNodeTop" runat="server" CssClass="selectedNodeToplbl"></asp:Label></TD>
																							<TD>
																								<asp:ImageButton id="btnDelete" onmouseover="showTooltip('ToolTip','deleteBtnTxt')" onmouseout="showTooltip('ToolTip','idleTxt')"
																									runat="server" ImageUrl="/images/InfiniPlan/delete1.jpg"></asp:ImageButton>
																								<asp:ImageButton id="btnRename" onmouseover="showTooltip('ToolTip','renameBtnTxt')" onmouseout="showTooltip('ToolTip','idleTxt')"
																									runat="server" ImageUrl="/images/InfiniPlan/rename.png"></asp:ImageButton></TD>
																						</TR>
																					</TABLE>
																				</TD>
																			<TR>
																				<TD align="center" colSpan="2">
																					<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TR>
																							<TD align="center" height="3">
																								<TABLE id="Table6" height="60" cellSpacing="0" cellPadding="0" width="416" border="0">
																									<TR>
																										<TD width="100%">
																											<asp:button id="btnInsert" onmouseover="this.className='MBUTTONACCPROON';showTooltip('ToolTip','insertBtnTxt');"
																												onmouseout="this.className='MBUTTONACCPRO';showTooltip('ToolTip','idleTxt')" runat="server"
																												Width="89px" Height="18px" Cssclass="MBUTTONACCPRO" DESIGNTIMEDRAGDROP="1747"></asp:button></TD>
																										<TD align="right"></TD>
																									</TR>
																									<TR>
																										<TD width="100%">
																											<asp:radiobutton id="rbRoot" onmouseover="showTooltip('ToolTip','rbRootTxt')" onmouseout="showTooltip('ToolTip','idleTxt')"
																												runat="server" cssclass="OutLineOptions" Height="4px" Text="Create folder" GroupName="rbChild"
																												Checked="True"></asp:radiobutton>
																											<asp:radiobutton id="rbChild" onmouseover="showTooltip('ToolTip','rbChildTxt')" onmouseout="showTooltip('ToolTip','idleTxt')"
																												runat="server" cssclass="OutLineOptions" Height="4px" Text="Create subfolder"></asp:radiobutton></TD>
																										<TD align="right"></TD>
																									</TR>
																								</TABLE>
																							</TD>
																						</TR>
																					</TABLE>
																				</TD>
																			</TR>
																			<TR>
																				<TD align="center" colSpan="2" height="200%">
																					<TABLE id="Table7" height="98" cellSpacing="0" cellPadding="0" width="317" align="center"
																						border="0">
																						<TR>
																							<TD vAlign="top" align="center">
																								<DIV class="selectedNodelbl" style="WIDTH: 298px" align="center">
																									<asp:Label id="lblSelectedNode" runat="server"></asp:Label></DIV>
																							</TD>
																						</TR>
																						<TR>
																							<TD class="PlanOutlineToolTip" vAlign="top" align="left" colSpan="2" height="115">
																								<DIV id="Tooltip" align="left">use the buttons to perform different operations</DIV>
																							</TD>
																						</TR>
																					</TABLE>
																				<TD>
																					<asp:label id="lblHelp" style="DISPLAY: none" runat="server" CssClass="pagecontents"></asp:label></TD>
																			</TR>
																			<TR>
																				<TD align="center" colSpan="2">
																					<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
																						<TBODY>
																							<TR>
																								<TD align="right">
																									<asp:label id="lblHelpHeading" CssClass="pagecontents" Runat="server"></asp:label></TD>
																								<TD align="right">
																									<asp:button id="btnRestore" onmouseover="this.className='MBUTTONACCPROON';showTooltip('ToolTip','restoreBtnTxt')"
																										onmouseout="this.className='MBUTTONACCPRO';showTooltip('ToolTip','idleTxt')" runat="server"
																										Width="101%" Cssclass="MBUTTONACCPRO"></asp:button></TD>
																							</TR>
																			</TR>
																			<TR>
																			</TR>
																		</TABLE>
																	</ajax:ajaxpanel></td>
																<td vAlign="top" width="5%"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="24">
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
										<!-- /new --></tr>
								</TBODY></table>
						</td>
						<td class="TableBox_Right" width="0%"></td>
					</tr>
					<tr>
						<td class="TableBox_Bot_Left" width="0%"></td>
						<td class="TableBox_Bot" width="100%"></td>
						<td class="TableBox_Bot_Right" width="0%"></td>
					</tr>
				</TBODY></table>
			</TD></TR> 
			<!-- **************************************************************************************************************************** -->
			<!-- Actual Page Contents are to be written here  --> </TBODY></TABLE>
			<tr>
				<td vAlign="bottom" height="26"><uc1:bizplanfooter id="BizPlanFooter1" runat="server" DESIGNTIMEDRAGDROP="75"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE>
		</form>
	</body>
</HTML>
