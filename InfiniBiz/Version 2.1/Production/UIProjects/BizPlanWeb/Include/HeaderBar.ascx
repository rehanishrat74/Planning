<%@ Control Language="vb" AutoEventWireup="false" Codebehind="HeaderBar.ascx.vb" Inherits="Infinilogic.BusinessPlan.Web.HeaderBar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<%@ Register TagPrefix="uc1" TagName="IndexHeader" Src="../../Library/components/IndexHeader.ascx" %>
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td vAlign="top" height="0%" colspan=3>
			<uc1:IndexHeader id="IndexHeader1" runat="server"></uc1:IndexHeader>
		</td>
	</tr>
	<tr>
		<td vAlign="middle" class="lblHeading" height="30" width=30% align=center>
			<%=PlanName%>
		</td>
		<td vAlign="middle" class="lblHeading" height="30" width=40%>
		</td>
		<td vAlign="middle" class="lblHeading" height="30" width=30%>
		</td>
	</tr>
</table>
<!--
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
		<td vAlign="middle" width="22%"><IMG height="20" src="/BizPlanWeb/images/InfiniPlan/new_topleft_1st.gif" width="279">
		</td>
		<td vAlign="middle" align="right" width="78%" background="/BizPlanWeb/images/InfiniPlan/new_topleft_bkgd.gif">
			<%
						If ( PlanFlag ) then 
					%>
			<table width="262" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td width="140" align="right"><a href="/BizPlanWeb/Services/welcome.aspx"><img src="/BizPlanWeb/images/InfiniPlan/new_home_bt.gif" width="71" height="20" border="0"></a></td>
					<td width="40" align="right"><img src="/BizPlanWeb/images/InfiniPlan/blank.gif" width="40" height="8"></td>
					<td width="96" align="right"><a href="/BizPlanWeb/Services/Plan/ClosePlan.aspx"><img src="/BizPlanWeb/images/InfiniPlan/new_closeplan_bt.gif" width="96" height="20" border="0"></a></td>
					<td width="22" align="right"><img src="/BizPlanWeb/images/InfiniPlan/blank.gif" width="20" height="8"></td>
				</tr>
			</table>
			<%
						End If 
					%>
		</td>
	</tr>
</table>
-->
