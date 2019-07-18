<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderHistory.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.OrderHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>OrderHistory</title>
		<meta name="cbwords" content="" >
		<meta name="cbcat" content="" >
		<meta http-equiv="Content-Language" content="en" >
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<table border="0" width="100%" id="table1" cellspacing="1" style="BORDER-COLLAPSE: collapse">
			<tr>
				<td id="topbar" colSpan="2" height="16%" runat="server"></td>
			<tr>
				<td>
					<form id="Form1" method="post" runat="server">
						<table border="0" width="100%" id="table2" cellspacing="1" style="BORDER-COLLAPSE: collapse">
							<tr>
								<td id="menuarea" runat="server" vAlign="top" align="left" width="5%"></td>
								<td>&nbsp;
									<asp:DataGrid id="dgOrders" runat="server" Width="100%" CssClass="datagrid-header"></asp:DataGrid></td>
							</tr>
						</table>
					</form>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"></td>
			</tr>
		</table>
	</body>
</HTML>
