<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Orders.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Orders"%>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<HTML>
	<HEAD>
		<title>Orders</title>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK><LINK href="../../Library/Styles/infinistyles.css" type="text/css" rel="stylesheet"></LINK>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
		<script language="javascript">
		{
		 function OrdersDetail(Sessionid,PageName)
		{
	 
		window.parent.OrdersDetail(Sessionid,PageName);
		}
	 
		  
			} 
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" border="0" valign="top">
				<tr vAlign="top">
					<td vAlign="top" height="100%">
						<asp:panel id="testpanel" Runat="server" width="100%" height="100%">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD></TD>
								</TR>
								<TR vAlign="top">
									<TD vAlign="top" align="left">
										<ajax:AjaxPanel id="AjaxPanel1" runat="server">
											<asp:Panel id="myHistoryPanel" Runat="server">
												<TABLE align="left" border="0">
													<TR vAlign="top" align="center">
														<TD vAlign="top" align="center" width="100%">
															<DIV class="VisitParent" id="HistoryDetail">
																<asp:Label id="Caption" Runat="server" Font-Underline="True" CssClass="CaptionStyle"></asp:Label>
																<asp:Table id="historytable" width="100%" Runat="server" EnableViewState="True" Border="0">
																	<asp:TableRow EnableViewState="True">
																		<asp:TableCell ID="GridCell" EnableViewState="True">
																			<asp:datagrid id="dgOrder" Width="100%" Runat="server" CssClass="wizardtext" EnableViewState="True"
																				CellSpacing="0" CellPadding="1" GridLines="Both" AutoGenerateColumns="True" AllowSorting="True">
																				<HeaderStyle CssClass="text_style4" ForeColor="#777777"></HeaderStyle>
																				<ItemStyle CssClass="text_style2" Height="22pt"></ItemStyle>
																				<PagerStyle HorizontalAlign="Right" PageButtonCount="15" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid>
																			<asp:datagrid id="dgOrderChildGrid" Width="100%" Runat="server" CssClass="wizardtext" EnableViewState="True"
																				CellSpacing="0" CellPadding="1" GridLines="Both" AutoGenerateColumns="True">
																				<HeaderStyle CssClass="text_style4" ForeColor="#777777"></HeaderStyle>
																				<ItemStyle CssClass="text_style2" Height="22pt"></ItemStyle>
																				<PagerStyle HorizontalAlign="Right" PageButtonCount="15" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid>
																		</asp:TableCell>
																	</asp:TableRow>
																</asp:Table></DIV>
														</TD>
													</TR>
												</TABLE>
											</asp:Panel>
										</ajax:AjaxPanel></TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</tr>
			</table>
		</form>
		<script>
		
		
		if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100 ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
parent.resizeFrame(scrollHeight,scrollWidth);
}
else 
{
}
		</script>
	</body>
</HTML>
