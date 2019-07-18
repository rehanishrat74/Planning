<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="InfiniLogic.BusinessPlan.Web.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan FAQs</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table height="10%" cellSpacing="0" cellPadding="0" width="10%" border="0" bgcolor="white">
				<tr>
					<td> 
						<asp:Label id="Label1" runat="server">User</asp:Label></td>
					<td> 
						<asp:TextBox id="txtUser" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td> 
						<asp:Label id="Label2" runat="server">Password</asp:Label></td>
					<td> 
						<asp:TextBox id="txtPwd" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colSpan="2"> 
						<asp:Button id="btnLogin" runat="server" Text="Login"></asp:Button></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
