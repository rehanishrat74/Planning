<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OpenPlan.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.OpenPlan"%>
<HTML>
	<HEAD>
		<title>Plan Manager</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" 
dir=<%=Session("dir")%>>
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
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" height="19"><asp:label id="lblMessage" runat="server" Width="100%">Label</asp:label></td>
										</tr>
										<tr>
											<td vAlign="top" height="10"><IMG height="10" src="../../images/InfiniPlan/blank.gif" width="1"></td>
										</tr>
										<tr>
											<td vAlign="top" height="311">
												<!-- Center Table --><asp:datagrid id="dgPlanList" runat="server" Width="728px" AutoGenerateColumns="False" Height="2px" cssClass="OpenPlan_dataGrid"
													CellPadding="3" GridLines="Vertical">
													<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
													<ItemStyle CssClass="rowitem"></ItemStyle>
													<HeaderStyle CssClass="itemheader"></HeaderStyle>
													<Columns>
														<asp:TemplateColumn>
															<ItemTemplate>
																<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenPlan.aspx?pid={0}") %>' ID="Hyperlink1" NAME="Hyperlink1">
																</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="BusinessDescription">
															<HeaderStyle Width="55%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle HorizontalAlign="Center" Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton ID="Delete" Runat="server" ImageUrl="../../images/InfiniPlan/del.gif" CommandName="Delete"
																	Height="20" Width="20"></asp:ImageButton>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="PlanID"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" cssclass="Pager_style" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></td>
										</tr>
										<tr>
											<td vAlign="top" height="10"><IMG height="10" src="../images/InfiniPlan/blank.gif" width="1"></td>
										</tr>
										<tr>
											<td vAlign="top" align="center" height="19"></td>
										</tr>
									</table>
									<asp:label id="Label1" runat="server">Label</asp:label>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
