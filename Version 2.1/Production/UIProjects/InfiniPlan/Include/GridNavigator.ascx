<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GridNavigator.ascx.vb" Inherits="Infinilogic.BusinessPlan.Web.GridNavigator" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
<table id="Table1" cellspacing="0" cellpadding="0" width="100" border="0"   >
	<tr align="right" class="TableBody">
		<td><asp:ImageButton id="btnFirst" CssClass="label" runat="server" ImageUrl="/images/InfiniPlan/ipfirstpg.gif"></asp:ImageButton></td>
		<td><asp:ImageButton id="btnPrev" CssClass="label" runat="server" ImageUrl="/images/InfiniPlan/ipprevpg.gif"></asp:ImageButton></td>
		<td><asp:ImageButton id="btnNext" CssClass="label" runat="server" ImageUrl="/images/InfiniPlan/ipnextpg.gif"></asp:ImageButton></td>
		<td><asp:ImageButton id="btnLast" CssClass="label" runat="server" ImageUrl="/images/InfiniPlan/iplastpg.gif"></asp:ImageButton></td>
		<td align="right"><asp:LinkButton id="btnShowListing" CssClass="ControlText" runat="server" Visible="False">Show List</asp:LinkButton></td>
	</tr>
</table>
<input type="hidden" id="PageNo" runat="server" value="0" name="PageNo"> <input type="hidden" id="LastPageNo" runat="server" value="0" name="LastPageNo">
<input type="hidden" id="GridName" runat="server" name="GridName">
 