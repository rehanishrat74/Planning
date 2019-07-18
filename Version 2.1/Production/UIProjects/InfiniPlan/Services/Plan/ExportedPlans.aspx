<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ExportedPlans.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.ExportedPlans"%>
<HTML>
	<HEAD>
		<title>Exported Plans</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
			<script src="../../Library/Scripts/PlanWizard.js"></script>
			<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" height="15"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:label></td>
										</tr>
										<tr>
											<td>
												<asp:label id="Label2" runat="server" Font-Size="2pt">.</asp:label></td>
										</tr>
										<tr vAlign="top">
											<td align="center">
												<asp:panel id="Panel5" runat="server" Width="100%" Visible="true" height="100%">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
																<TD align="center">
																	<asp:label id="lblMsg" runat="server"></asp:label></TD>
															</TR>
															<TR vAlign="top" height="100%" width="100%">
																<TD width="100%" height="100%">
																	<DIV class="PlanExport" id="test" align="justify" width="100%">
																		<asp:panel id="Panel2" runat="server" Width="100%" height="100%" Visible="true">
																			<asp:datagrid id="dgExportedPlans" runat="server" Width="100%" PageSize="9" AllowPaging="True"
																				CellPadding="3" AutoGenerateColumns="False" GridLines="Vertical" cssclass="GridSamplePlans">
																				<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																				<ItemStyle CssClass="rowitem"></ItemStyle>
																				<HeaderStyle CssClass="itemheader"></HeaderStyle>
																				<Columns>
																					<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left">
																						<HeaderStyle Width="25%"></HeaderStyle>
																						<ItemTemplate>
																							<asp:Label runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanName") %>' ID="Label1" NAME="Label1">
																							</asp:Label>
																						</ItemTemplate>
																						<EditItemTemplate>
																							<asp:TextBox runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.PlanName") %>' ID="Textbox1" NAME="Textbox1">
																							</asp:TextBox>
																						</EditItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="PlanDescription">
																						<HeaderStyle Width="29%" HorizontalAlign="Left"></HeaderStyle>
																					</asp:BoundColumn>
																					<asp:TemplateColumn>
																						<HeaderStyle Width="25%" HorizontalAlign="Left"></HeaderStyle>
																						<ItemTemplate>
																							<asp:HyperLink runat="server" CssClass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.PlanFileName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/ExportedPlans.aspx?bid={0}") %>' ID="Hyperlink1" NAME="Hyperlink1">
																							</asp:HyperLink>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:BoundColumn DataField="ExportDate" DataFormatString="{0:MM/dd/yyyy}">
																						<HeaderStyle Width="25%" HorizontalAlign="Left"></HeaderStyle>
																					</asp:BoundColumn>
																				</Columns>
																				<PagerStyle cssclass="ExportedPlans_PagerStyle" Font-Italic="True" HorizontalAlign="Left" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid>
																		</asp:panel></DIV>
																</TD>
															</TR></TABLE>
												</asp:panel></td>
											<td class="TableBox_Right" width="0%"></td>
										</tr>
										<tr>
											<td class="TableBox_Bot_Left" width="0%"></td>
											<td class="TableBox_Bot" width="100%"></td>
											<td class="TableBox_Bot_Right" width="0%"></td>
										</tr>
									</table>
									</asp:panel></td>
							</tr>
						</table>
					</td>
					<!-- Actual Page Contents are to be written upto here  -->
					<!-- **************************************************************************************************************************** --> 
					</TD></tr>
			</table>
			</TD></TR>
			<tr>
				<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE></form>
	</body>
</HTML>
