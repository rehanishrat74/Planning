<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Nisar_Test.WebForm1"%>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<HTML>
	<HEAD>
		<script type="text/javascript">
			function _init()
			{				
				alert('ss')
				//scrollTo(0,0)
				document.getElementById("trv").scrollLeft=0;				
			}
			
			function rename_prompt(selectedNode)
			{
				
				var name
				var retValue = document.getElementById("TextBox1")		

		
				name = prompt("Are you sure you want to rename "+selectedNode+" to","")
				if (name!=null)
				{
					retValue.value = name					
				}
				else
				{
					return false
				}
				//	_init()
			}
		</script>
	</HEAD>
	<body>
		<form id="Form2" method="post" runat="server">
			<h3>DataGrid ItemDataBound Example</h3>
			<asp:datagrid id="ItemsGrid" runat="server" AutoGenerateColumns="true" OnItemDataBound="Item_Bound"
				ShowFooter="true" CellPadding="3" BorderWidth="1" BorderColor="black">
				<HeaderStyle BackColor="#00aaaa"></HeaderStyle>
				<FooterStyle BackColor="#00aaaa"></FooterStyle>
			</asp:datagrid>
			<asp:textbox id="ret_val" style="DISPLAY: none" runat="server" EnableViewState="False"></asp:textbox><asp:textbox id="TextBox1" style="DISPLAY: none" runat="server"></asp:textbox><br>
			<asp:label id="Label1" runat="server" Text="Order of items data bound: "></asp:label><br>
			<asp:label id="Label2" runat="server" Text="Note: The -1's refer to the header and footer."></asp:label>
			<asp:TextBox ID="txtTest" Runat="server"></asp:TextBox>"
			<div>
			<table>
				<tr>
					<td>heading information</td>
				</tr>
				<tr><td>
					<table>
						<tr>
						<td>Left Bar</td>
						<td>
							<table>
								<tr>
									<td>Tree View </td>
								</tr>
								<tr>
									<td>
										<asp:Panel ID="myPanel" Runat="server">
											<div>
												<iewc:treeview id="trv" runat="server" Height="230px" Width="300px" DefaultStyle="font-family:Times New Roman;font-size:14pt;background-color:white;"
											SelectedStyle="filter=none;background-color:LightSteelBlue;&#13;&#10;font-weight:bold;font-color:#ffffff;"
											HoverStyle="filter=none;background-color:#ECF4FC;" AutoPostBack="True"></iewc:treeview>
											</div>
										</asp:Panel>
									</td>
								</tr>
							</table>
						</td>
						</tr>
					</table>
				</td></tr>
				<tr><td>footer information</td></tr>
			</table>
				<asp:Panel id="Panel1" runat="server" Height="200px">
					<TABLE>
						
							<TR>
								<TD>Tree View Example</TD>
							</TR>
							<TR vAlign="top">
								<TD align="left" width="100%" colSpan="2" height="183">
									<DIV>
										<iewc:treeview id="trv1" runat="server" Height="230px" Width="300px" DefaultStyle="font-family:Times New Roman;font-size:14pt;background-color:white;"
											SelectedStyle="filter=none;background-color:LightSteelBlue;&#13;&#10;font-weight:bold;font-color:#ffffff;"
											HoverStyle="filter=none;background-color:#ECF4FC;" AutoPostBack="True"></iewc:treeview></DIV>
				
				
				</TD></TR>
				<tr><td>nisar khan</td></tr></TABLE>
				</asp:Panel>
				</div>
				<asp:Button id="Button1" runat="server" Text="Button" Width="144px"></asp:Button>
		</form>
		</DIV>
	</body>
</HTML>
