<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanManager.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanManager"%>
<HTML>
	<HEAD>
		<title>Plan Manager</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody" onfocus="return checkModal()" onclick="checkModal()">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TBODY>
					<tr>
						<td vAlign="top" height="19">
							<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
					</tr>
					<tr>
						<td vAlign="top" height="100%">
							<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" dir=<%=Session("dir")%>>
								<TBODY>
									<tr>
										<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
									</tr>
									<tr>
										<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
										<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
										<td vAlign="top" width="100%">
											<!-- **************************************************************************************************************************** -->
											<!-- Actual Page Contents are to be written here  -->
											<table cellSpacing="0" cellPadding="0" width="100%" height="100%" border="0">
												<TBODY>
													<tr width="100%">
														<td align="center" width="100%"><asp:label id="lblHeading" runat="server" Height="90%" CssClass="lblHeading" Width="100%"></asp:label></td>
													</tr>
													<tr>
														<td><asp:label id="Label2" Font-Name="verdena" Font-Size="2pt" Runat="server" cssclass="lblPlanManager_Style">.</asp:label></td>
													</tr>
													<tr vAlign="top">
														<td align="center">
															<asp:panel id="Panel5" runat="server" Width="100%" Visible="true" height="100%">
																<TABLE cellSpacing="0" cellPadding="0" height="100%" width="100%" border="0" dir=ltr>
																	<TBODY>
																		<TR>
																			<TD class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></TD>
																			<TD class="TableBox_Top" height="3">&nbsp;</TD>
																			<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
																		</TR>
																		<TR>
																			<TD class="TableBox_Left" width="0%"></TD>
																			<TD vAlign="top" height="100%"><!-- Center Table -->
																				<asp:panel id="pnlManager" Width="100%" Runat="server">
																					<TABLE height="100%" width="100%"></TD>
																		</TR>
																		<TR>
																			<TD>
																				<asp:label id="lblMsg" runat="server" Font-Size="10" Font-Name="verdena" Font-Bold="True"></asp:label></TD>
																		</TR>
																		<TR vAlign="top" height="100%" width="100%">
																			<TD width="100%" height="100%">
																				<asp:panel id="Panel2" runat="server" Width="100%" height="100%" Visible="true">
																					<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" dir=<%=Session("dir")%>>
																						<TR align="center" width="100%">
																							<TD align="left" width="100%">
																							<IEWC:TABSTRIP id="MainTStrip" style="FONT-WEIGHT: normal" runat="server" Width="73.5%" Height="100%"   
																									ForeColor="Desktop" Font-Size="xsmall" TargetID="mpHoriz" SepDefaultStyle="border-bottom:solid 0px steelblue;"
																									Font-Names="Times New Roman" TabDefaultStyle="border:solid 1px steelblue;background:white;padding-left:5px;padding-right:5px;text-align:center"
																									TabHoverStyle="width:25%;background:#ECF4FC;FONT-WEIGHT: bold;" TabSelectedStyle="width:25%;border:solid 2px steelblue;background:#ECF4FC;padding-left:5px;padding-right:5px;FONT-WEIGHT: bold;">
																							<IEWC:TAB DefaultStyle="width:25%;height:12%;"></IEWC:TAB>
																									<IEWC:TABSEPARATOR></IEWC:TABSEPARATOR>
																									<IEWC:TAB DefaultStyle="width:25%;height:12%;"></IEWC:TAB>
																									<IEWC:TABSEPARATOR></IEWC:TABSEPARATOR>
																									<IEWC:TAB DefaultStyle="width:25%;height:12%;"></IEWC:TAB>
																									<IEWC:TABSEPARATOR></IEWC:TABSEPARATOR>
																									<IEWC:TAB DefaultStyle="width:25%;height:12%;"></IEWC:TAB>
																									<IEWC:TABSEPARATOR DefaultStyle="width:100%;"></IEWC:TABSEPARATOR>
																								</IEWC:TABSTRIP>
																							</TD>
																						</TR>
																						<TR>
																							<TD>
																								<DIV class="PlanManagerSpace" id="test" align="justify">
																									<IEWC:MULTIPAGE id="mpHoriz" runat="server" Width="100%" Height="100%" Font-Size="Larger">
																										<IEWC:PAGEVIEW>
																											<asp:panel id="Panel1" runat="server" Width="100%" height="100%" Visible="true">
																												<TABLE width="100%" align="center" border="0">
																													<TR>
																														<TD colSpan="2" valign="top" height="100%">
																															<asp:label id="space1" Runat="server" Font-Size="11" Width="100%" Font-Name="verdena" cssclass="lblSpace1PlanManager_Style" >.</asp:label>
																															<asp:label id="Label1" Runat="server" height="100%" Font-Name="verdena">
																																<p class="MsoNormal" style='text-align:justify'><u><span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Tahoma;
mso-bidi-font-weight:bold'>New Plan:</span></u><span class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-ansi-language:EN-US'> The New Plan tab allows you to create
a new plan through an interactive wizard.</span><br>
																																	<br>
																																	<u>
																																		<span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Tahoma;mso-bidi-font-weight:bold'>Recent Plans</span></u><span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Tahoma;
mso-bidi-font-weight:bold'>:</span><span class="spanPlanManager_Style" lang="EN-GB" style='mso-bidi-font-family:Verdana;mso-ansi-language:EN-US'></span><span class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-ansi-language:EN-US'>The Recent Plan tab allows you to view and access the five most recent
plans that you have been working on. These plans are arranged according to
their frequency of use.</span><br>
																																	<br>
																																	<u>
																																		<span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Tahoma;mso-bidi-font-weight:bold'>My Plans:</span></u><span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-bidi-font-weight:bold'> My
Plan tab lists all the plans that you have created in InfiniPlan along with
their date of creation. It also allows you to edit as well as delete a previous
plan.</span><br>
																																	<br>
																																	<span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-ansi-language:EN-US'></span><u><span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Tahoma;mso-bidi-font-weight:bold'>Sample Plan:</span></u><span lang="EN-GB" class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-ansi-language:EN-US'></span><span class="spanPlanManager_Style" style='mso-bidi-font-family:Verdana;mso-ansi-language:
EN-US'> These plans are available in the Sample
Plan tab. The sample plans can be edited according to your preferences.
<o:p></o:p></span></p>
																															</asp:label></TD>
																													</TR>
																													<TR>
																														<TD align="left" width="100%" height="100%" colSpan="2"><br>
																															<asp:button id="imgBtnNewPlan" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																																runat="server" Width="15%" Cssclass="MBUTTONACCPRO" Font-Size="8pt" Text="New Plan"></asp:button></TD>
																													</TR>
																												</TABLE>
																											</asp:panel>
																										</IEWC:PAGEVIEW>
																										<IEWC:PAGEVIEW>
																											<asp:panel id="Panel3" runat="server" Width="100%" height="100%" Visible="true">
																												<TABLE width="100%" align="center" border="0">
																													<TR>
																														<TD><asp:label id="space2" Runat="server" Font-Size="11" Visible="False" Width="100%" Font-Name="verdena" cssClass="lblSpace1PlanManager_Style" >.</asp:label>
																															<asp:label id="lblLastPlan" Runat="server"  ></asp:label>
																															</TD>
																													</TR>
																													<TR vAlign="top"> <!-- LastPlanGrid -->
																														<TD width="100%" height="100%">
																															<asp:datagrid id="LastPlanGrid" runat="server" Height="100%" Width="100%" cssclass="GridSamplePlans"
																																GridLines="Vertical" AutoGenerateColumns="False" CellPadding="3" PageSize="10">
																																<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																																<ItemStyle CssClass="rowitem"></ItemStyle>
																																<HeaderStyle CssClass="itemheader" Height="10" HorizontalAlign="Left"></HeaderStyle>
																																<Columns>
																																	<asp:BoundColumn Visible="False" DataField="PlanID" HeaderText="PlanId"></asp:BoundColumn>
																																	<asp:BoundColumn Visible="False" DataField="LastPlan"></asp:BoundColumn>
																																	<asp:TemplateColumn HeaderText="Plan Name" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%">
																																		<ItemTemplate>
																																			<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenPlan.aspx?pid={0}") %>' ID="Hyperlink1">
																																			</asp:HyperLink>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																	<asp:BoundColumn DataField="BusinessDescription">
																																		<HeaderStyle HorizontalAlign="Left" Width="45%"></HeaderStyle>
																																	</asp:BoundColumn>
																																	<asp:BoundColumn DataField="DateCreated" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
																																		HeaderStyle-Width="10%"></asp:BoundColumn>
																																</Columns>
																																<PagerStyle HorizontalAlign="Left" cssclass="ExportedPlans_PagerStyle" Font-Italic="True" Mode="NumericPages"></PagerStyle>
																															</asp:datagrid>
																															<DIV></DIV> <!-- LastPlanGrid --></TD>
																													</TR>
																												</TABLE>
																											</asp:panel>
																										</IEWC:PAGEVIEW>
																										<IEWC:PAGEVIEW>
																											<asp:panel id="Panel4" runat="server" Width="100%" height="100%" Visible="true">
																												<TABLE width="100%" align="center" border="0">
																													<TR>
																														<TD><asp:label id="space3" Runat="server" Font-Size="11" Visible="False" Width="100%" Font-Name="verdena" cssclass="lblSpace1PlanManager_Style" >.</asp:label>
																															<asp:label id="lblMyPlan" Runat="server"  ></asp:label>
																															
																														</TD>
																													</TR>
																													<TR>
																														<TD width="100%"><!--Existing Plan Grid -->
																															<asp:datagrid id="ExistingPlanGrid" runat="server" width="100%" Height="100%" cssclass="GridSamplePlans"
																																GridLines="Vertical" AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" PageSize="8">
																																<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																																<ItemStyle CssClass="rowitem"></ItemStyle>
																																<HeaderStyle CssClass="itemheader" Height="10"></HeaderStyle>
																																<Columns>
																																	<asp:BoundColumn Visible="False" DataField="PlanID" HeaderText="PlanId"></asp:BoundColumn>
																																	<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%">
																																		<ItemTemplate>
																																			<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenPlan.aspx?pid={0}") %>' ID="Hyperlink2">
																																			</asp:HyperLink>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																	<asp:BoundColumn DataField="BusinessDescription">
																																		<HeaderStyle HorizontalAlign="Left" Width="30%"></HeaderStyle>
																																	</asp:BoundColumn>
																																	<asp:BoundColumn DataField="DateCreated" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10%"
																																		HeaderStyle-HorizontalAlign="Center"></asp:BoundColumn>
																																	<asp:TemplateColumn>
																																		<HeaderStyle Width="15%" HorizontalAlign="Center"></HeaderStyle>
																																		<ItemStyle HorizontalAlign="Center"></ItemStyle>
																																		<ItemTemplate>
																																			<asp:ImageButton ID="Delete" Runat="server" ImageUrl="/images/InfiniPlan/del.gif" CommandName="Delete"
																																				Height="10" Width="25"></asp:ImageButton>
																																		</ItemTemplate>
																																		<FooterStyle HorizontalAlign="Center"></FooterStyle>
																																	</asp:TemplateColumn>
																																	<asp:BoundColumn Visible="False" DataField="PlanID"></asp:BoundColumn>
																																</Columns>
																																<PagerStyle BorderStyle="Dotted" HorizontalAlign="Left" cssclass="ExportedPlans_PagerStyle1" Font-Italic="True" 
																																	Mode="NumericPages"></PagerStyle>
																															</asp:datagrid><!--	Existing Plan Grid--></TD>
																													</TR>
																												</TABLE>
																											</asp:panel>
																										</IEWC:PAGEVIEW>
																										<IEWC:PAGEVIEW>
																											<asp:panel id="Panel6" runat="server" Width="100%" height="100%" Visible="true">
																												<TABLE width="100%" align="center" border="0">
																													<TR>
																														<TD class="TDPlanManager_Style" width="100%"><!-- SamplePlanGrid -->
																															<asp:datagrid id="SamplePlanGrid" runat="server" width="100%" Height="100%" cssclass="GridSamplePlans"
																																GridLines="Vertical" AutoGenerateColumns="False" CellPadding="3" AllowPaging="True" PageSize="8">
																																<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																																<ItemStyle CssClass="rowitem"></ItemStyle>
																																<HeaderStyle CssClass="itemheader" Height="10"></HeaderStyle>
																																<Columns>
																																	<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%">
																																		<ItemTemplate>
																																			<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenSamplePlans.aspx?pid={0}") %>' ID="Hyperlink4" NAME="Hyperlink2">
																																			</asp:HyperLink>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																	<asp:BoundColumn DataField="BusinessDescription" HeaderStyle-Width="60%">
																																		<HeaderStyle Width="75%" HorizontalAlign="Left"></HeaderStyle>
																																	</asp:BoundColumn>
																																</Columns>
																																<PagerStyle BorderStyle="Dotted" cssclass="ExportedPlans_PagerStyle1" HorizontalAlign="Left" Font-Italic="True" Mode="NumericPages"></PagerStyle>
																															</asp:datagrid><!-- SamplePlanGrid --></TD>
																													</TR>
																												</TABLE>
																											</asp:panel>
																										</IEWC:PAGEVIEW>
																									</IEWC:MULTIPAGE>
																									<DIV></DIV>
																								</DIV>
																							</TD>
																						</TR>
																					</TABLE>
																				</asp:panel></TD>
																		</TR></TABLE>
															</asp:panel></td>
														<td class="TableBox_Right" width="0%"></td>
													</tr>
													<tr>
														<td class="TableBox_Bot_Left" width="0%"></td>
														<td class="TableBox_Bot" width="100%"></td>
														<td class="TableBox_Bot_Right" width="0%"></td>
													</tr>
												</TBODY>
											</table>
											</asp:panel></td>
									</tr>
								</TBODY></table>
							<!-- Actual Page Contents are to be written upto here  -->
							<!-- **************************************************************************************************************************** --></td>
					</tr>
				</TBODY></table>
			</TD></TR>
			<tr>
				<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE>
		</form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></FORM>
	</body>
</HTML>
