<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm2.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebForm2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<ajax:ajaxpanel id="AjaxPanelTreeView" runat="server" height="99%" width="100%">
				<iewc:TreeView id="TreeView1" runat="server" AutoPostBack="True">
					<iewc:TreeNode Text="Node0"></iewc:TreeNode>
					<iewc:TreeNode Text="Node1"></iewc:TreeNode>
					<iewc:TreeNode Text="Node2">
						<iewc:TreeNode Text="Node4"></iewc:TreeNode>
						<iewc:TreeNode Text="Node5"></iewc:TreeNode>
						<iewc:TreeNode Text="Node6"></iewc:TreeNode>
					</iewc:TreeNode>
					<iewc:TreeNode Text="Node3"></iewc:TreeNode>
				</iewc:TreeView>
			</ajax:ajaxpanel>
			<ajax:ajaxpanel id="Ajaxpanel1" runat="server" height="99%" width="100%">
				<TABLE>
					<TR>
						<TD>sdf
							<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>d</TD>
					</TR>
				</TABLE>
			</ajax:ajaxpanel>
		</form>
	</body>
</HTML>
