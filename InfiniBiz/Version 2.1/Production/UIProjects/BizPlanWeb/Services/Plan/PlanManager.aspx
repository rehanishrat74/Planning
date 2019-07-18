<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanManager.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanManager"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls"%>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls"%>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan Manager</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES><LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="#ffffff">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" width="97%" height="19" bgcolor="#f3f3f3"><asp:label id="lblHeading" runat="server" Width="97%" CssClass="lblHeading"></asp:label>
											</td>
										</tr>
										<tr vAlign="top">
											<td align="center">
												<table dir="ltr" height="85%" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td vAlign="top" height="100%"><asp:panel id="pnlManager" Runat="server">
																<TABLE height="100%" width="100%" border="0">
																	<TR vAlign="top">
																		<TD>
																			<asp:panel id="PanelUserPlans" runat="server" CssClass="managerSearch" Width="100%" Visible="true"> <!-- panel -->
																				<TABLE width="100%" align="center" border="0">
																					<TR>
																						<TD>
																							<asp:panel id="Panel1" runat="server" CssClass="datagrid-data" Width="100%" Visible="true">
																								<TABLE align="center" border="0">
																									<TR>
																										<TD align="left" width="5%">
																											<asp:Label id="Label3" runat="server" CssClass="wizardText">Plan</asp:Label></TD>
																										<TD align="left" width="10%">
																											<asp:TextBox id="txtPlanName" runat="server"></asp:TextBox></TD>
																										<TD>
																											<asp:ImageButton id="btnGo" runat="server" ImageUrl="/images/InfiniPlan/GO.gif" ToolTip="Search"></asp:ImageButton>
																											<asp:ImageButton id="btnAdvSearch" runat="server" ImageUrl="/images/InfiniPlan/AdvanceSearch.Gif"
																												ToolTip="Advance"></asp:ImageButton></TD>
																										<TD></TD>
																										<TD>
																											<asp:label id="lblerror" CssClass="lblErrorMessage1" Runat="server"></asp:label></TD>
																									</TR>
																									<TR>
																										<TD align="left" colSpan="5">
																											<asp:label id="lblMyPlan" CssClass="wizardText" Runat="server"></asp:label></TD>
																									</TR>
																									<TR>
																									</TR>
																								</TABLE>
																							</asp:panel></TD>
																					</TR>
																					<TR>
																						<TD width="100%"><!--Existing Plan Grid --><BR>
																							<BR>
																							<asp:datagrid id="ExistingPlanGrid" runat="server" width="100%" AllowPaging="True" GridLines="Both"
																								AutoGenerateColumns="False" CellPadding="3" PageSize="10" Height="100%">
																								<AlternatingItemStyle></AlternatingItemStyle>
																								<ItemStyle CssClass="GridInnerLines"></ItemStyle>
																								<HeaderStyle CssClass="GridHeaderBar" Height="10"></HeaderStyle>
																								<Columns>
																									<asp:BoundColumn Visible="False" DataField="PlanID" HeaderText="PlanId"></asp:BoundColumn>
																									<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="30%">
																										<ItemTemplate>
																											<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenPlan.aspx?pid={0}") %>' ID="Hyperlink2">
																											</asp:HyperLink>
																										</ItemTemplate>
																									</asp:TemplateColumn>
																									<asp:BoundColumn DataField="BusinessDescription"    ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size=8>
																										<HeaderStyle HorizontalAlign="Left" Width="30%" ></HeaderStyle>
																									</asp:BoundColumn>
																									<asp:BoundColumn DataField="DateCreated" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="10"
																										HeaderStyle-HorizontalAlign="Center"  ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size=8></asp:BoundColumn>
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
																								<PagerStyle HorizontalAlign="Left" Font-Italic="True" Mode="NumericPages" CssClass="GridInnerLines"></PagerStyle>
																							</asp:datagrid><!--	Existing Plan Grid--></TD>
																					</TR>
																				</TABLE> <!-- panel --></asp:panel><BR>
																			<asp:panel id="PanelSmaplePlans" runat="server" Width="100%" Visible="False">
																				<TABLE width="100%" align="center" border="0">
																					<TR>
																						<TD align="center">
																							<asp:label id="lblSmaplePlans" Runat="server"></asp:label><BR>
																							<BR>
																						</TD>
																					</TR>
																					<TR>
																						<TD class="TDPlanManager_Style" width="100%"><!-- SamplePlanGrid -->
																							<asp:datagrid id="SamplePlanGrid" runat="server" width="100%" AllowPaging="True" GridLines="Vertical"
																								AutoGenerateColumns="False" CellPadding="3" PageSize="10" Height="100%" cssclass="GridSamplePlans1">
																								<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																								<ItemStyle CssClass="GridInnerLines"></ItemStyle>
																								<HeaderStyle CssClass="GridHeaderBar" Height="10"></HeaderStyle>
																								<Columns>
																									<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%"  ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size=10>
																										<ItemTemplate>
																											<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenSamplePlans.aspx?pid={0}") %>' ID="Hyperlink4" NAME="Hyperlink2">
																											</asp:HyperLink>
																										</ItemTemplate>
																									</asp:TemplateColumn>
																									<asp:BoundColumn DataField="BusinessDescription" HeaderStyle-Width="60%"  ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif" ItemStyle-Font-Size=10>
																										<HeaderStyle Width="75%" HorizontalAlign="Left"></HeaderStyle>
																									</asp:BoundColumn>
																								</Columns>
																								<PagerStyle cssclass="ExportedPlans_PagerStyle1" HorizontalAlign="Left" Font-Italic="True" Mode="NumericPages"></PagerStyle>
																							</asp:datagrid><!-- SamplePlanGrid --></TD>
																					</TR>
																				</TABLE>
																			</asp:panel><BR>
																			<asp:panel id="Panelbtnback" runat="server" Width="100%" Visible="False">
																				<TABLE width="100%" align="center" border="0">
																					<TR vAlign="top">
																						<TD align="center">
																							<asp:button id="BtnBack" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																								runat="server" Width="10%" Font-Size="8pt" Cssclass="MBUTTONACCPRO" Text="Back"></asp:button></TD>
																					</TR>
																				</TABLE>
																			</asp:panel></TD>
																	</TR>
																</TABLE>
															</asp:panel></td>
														<td class="TableBox_Right" width="0%">&nbsp;@</td>
													</tr>
													<tr>
														<td class="TableBox_Bot_Left" width="0%"></td>
														<td class="TableBox_Bot" width="100%"></td>
														<td class="TableBox_Bot_Right" width="0%"></td>
													</tr>
												</table>
												<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>
											</td>
										</tr>
									</table>
									<asp:imagebutton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:imagebutton>
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
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight - 40  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
 parent.resizeFrame(scrollHeight,scrollWidth);
		</script>
	</body>
</HTML>
