<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="accounts.infinibiz.Web.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
		function test()
		{
		alert("test")
		}
			
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table border="1">
				<tr>
					<td colspan="2">
						<asp:Label ID="ErrMsg" Runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label1" runat="server" Width="109px">Id</asp:label>
					</td>
					<td>
						<asp:textbox id="TextBox1" runat="server">343440</asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label2" runat="server" Width="112px">Passward</asp:label>
					</td>
					<td>
						<asp:textbox id="TextBox2" runat="server">a</asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
					</td>
					<td>
						<asp:button id="Button1" runat="server" Height="32" Width="89" Text="Merchant"></asp:button>
						<asp:Button id="Button3" runat="server" Width="89px" Text="Employee" Height="32px"></asp:Button>
					</td>
				</tr>
			</table>
			<br>
			<table border="1">
				<tr>
					<td colspan="2">
						<asp:Label ID="Emsg" Runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label8" runat="server">CustomerID</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtCustomerID" runat="server">114462</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label3" runat="server">ProductCode</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtProductCode" runat="server">527</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label4" runat="server">OrderNo</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtOrderNo" runat="server">1126062532406</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label5" runat="server" Visible="False">SerialNo</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtSerialNo" runat="server" Visible="False">1</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Label id="Label6" runat="server" Visible="False">Language</asp:Label>
					</td>
					<td>
						<asp:TextBox id="txtLanguage" runat="server" Visible="False">eng</asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
					</td>
					<td>
						<asp:button id="Button2" runat="server" Height="32px" Width="88px" Text="Login"></asp:button>
					</td>
				</tr>
			</table>
			<P>&nbsp;</P>
			<P>
				<asp:Table id="tblAuthenticateEmployee" runat="server" Width="240px" Height="25%" BorderWidth="1"
					BorderColor='#33cccc'>
					<asp:TableRow>
						<asp:TableCell>
							<asp:Label Runat="server" ID="lblCode">Code</asp:Label>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label Runat="server" ID="lblCodeText" ForeColor="#669966">2</asp:Label>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell>
							<asp:Label Runat="server" ID="lblDecs">Description</asp:Label>
						</asp:TableCell>
						<asp:TableCell>
							<asp:Label Runat="server" ID="lblDecsText" ForeColor="#ff9966">Description</asp:Label>
						</asp:TableCell>
					</asp:TableRow>
					<asp:TableRow>
						<asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
							<asp:Button Runat="server" ID="btnAuthenticateEmployee" Text="Authenticate"></asp:Button>
						</asp:TableCell>
					</asp:TableRow>
				</asp:Table></P>
		</form>
	</body>
</HTML>
