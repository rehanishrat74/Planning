<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ServicesList" Src="../Library/components/ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProductSummaryDetails.aspx.vb" Inherits="accounts.infinibiz.Web.ProductSummaryDetails" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts.infinibiz.com - Product Sales Details Report</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<link href="http://services.infinibiz.com/images/main.css" type="text/css" rel="stylesheet">
		<style type="text/css"> A:link { COLOR: #000000; TEXT-DECORATION: none } A:visited { COLOR: #000000; TEXT-DECORATION: none } A:hover { COLOR: rgb(255,128,0); TEXT-DECORATION: underline } </style>
		<script language="javascript">
	function changeSelectedRowColor(Index,bool)
		{
		Index = Index + 1
		var objGrd;
			objGrd = document.all("dgridsummaryinformation")
			if(bool==1)
				{
				//objGrd.rows(Index).style.background="#F3F3F3"
				}
			else
				{
				objGrd.rows(Index).style.background="#ffffff"
				}
		}
		function popUp()
		{
			var tblPopUp;
			var divPopUp;
			
			alert("in");
			tblPopUp = new document.createElement("Table") 
			alert(tblPopUp.rows.length);
				
		}
		</script>
	</HEAD>
	<body id="bdyGlobalView" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		runat="server">
		<FORM id="frmGlobalView" name="frmGlobalView" action="default.aspx" method="post" encType="multipart/form-data"
			runat="server">
			<input id="hCriteria" type="hidden" value="3" name="hCriteria" runat="server"> <input id="hSort" type="hidden" value="CompName" name="hSort" runat="server">
			<table style="HEIGHT: 100%" borderColor="yellow" cellSpacing="0" cellPadding="0" width="100%"
				align="center" bgColor="white" border="0">
				<tr>
					<td height="100">
						<!-- Header --><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td vAlign="top">
						<table height="100%" width="100%">
							<tr>
								<td class="objtd" vAlign="top" align="center" width="180" colSpan="1">
									<uc1:ServicesList id="ServicesList1" runat="server"></uc1:ServicesList></td>
								<td align="center">
									<!-- Content -->
									<div class="scrolldiv" style="HEIGHT: 100%">
										<table class="CONTENT" id="tblContent" style="BACKGROUND: url(http://services.infinibiz.com/images/bg.gif)"
											borderColor="blue" cellSpacing="0" cellPadding="0" width="100%" bgColor="white" border="0"
											valign="top" height="100%">
											<tr vAlign="top">
												<td>
													<table class="CONTENT" id="layouttable" cellSpacing="0" cellPadding="0" width="100%" height="100%">
														<TR vAlign="top">
															<TD id="menuarea" vAlign="top" align="left" runat="server"></TD>
															<TD id="contentarea" style="PADDING-LEFT: 0px" vAlign="top" width="100%">
																<table class="content" cellSpacing="0" cellPadding="0" width="100%" border="0" height="100%">
																	<tr>
																		<td class="objtd" vAlign="top" width="80%"><strong><font size="5"><asp:label id="lblglobalview" runat="server">Product Sales Detail Report</asp:label></font></strong><br>
																			<table class="content" cellSpacing="0" cellPadding="0" width="100%" height="100%">
																				<TR width="100%">
																					<TD id="Td2" style="HEIGHT: 12px" vAlign="top" width="11%" runat="server" NAME="Td2"></TD>
																				</TR>
																				<tr vAlign="top">
																					<td vAlign="top" width="100%" colSpan="3" height="85%">
																						<asp:datagrid CssClass="TableBody" id="dgProduct" runat="server" AutoGenerateColumns="False" Width="100%"
																							ShowFooter="True" EnableViewState="False" AllowPaging="False" GridLines="None">
																							<FooterStyle Font-Bold="True" BorderWidth="0px"></FooterStyle>
																							<AlternatingItemStyle Wrap="False" BorderColor="White"></AlternatingItemStyle>
																							<ItemStyle Wrap="False" Height="18px" BorderWidth="0px" BorderColor="White" CssClass="IBIZ_GridView"></ItemStyle>
																							<HeaderStyle Font-Name="Verdana" Font-Bold="True" Wrap="False" BorderWidth="0px" CssClass="IBIZ_GridView_Header"></HeaderStyle>
																							<Columns>
																								<asp:BoundColumn DataField="code">
																									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10%"></HeaderStyle>
																									<ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="10%"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="Description">
																									<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="40%"></HeaderStyle>
																									<ItemStyle Font-Bold="True" HorizontalAlign="Left" Width="40%"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="Quantity" DataFormatString="{0:0.00}">
																									<HeaderStyle HorizontalAlign="Right" Width="15%"></HeaderStyle>
																									<ItemStyle Font-Bold="True" HorizontalAlign="Right" Width="15%"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:templatecolumn>
																									<HeaderStyle HorizontalAlign="Right" Width="15%"></HeaderStyle>
																									<ItemStyle HorizontalAlign="Right" Font-Bold="True" Width="15%"></ItemStyle>
																									<ItemTemplate>
																										<%# format(DataBinder.Eval(Container.DataItem, "SaleTotal"),"0.00") %>
																									</ItemTemplate>
																								</asp:templatecolumn>
																								<asp:TemplateColumn>
																									<ItemStyle Width="1%"></ItemStyle>
																									<ItemTemplate>
																										<asp:PlaceHolder ID="Expanded" Runat="server" Visible="True">
																											<tr>
																												<td width="0"></td>
																												<td colspan="8">
																													<asp:DataGrid id="dgDetail" DataSource ='<%# Container.DataItem.CreateChildView("ProductRelation") %>' runat="server" Width="100%" BorderStyle="Solid" CellPadding="0" AutoGenerateColumns="False" BorderWidth="0px" Font-Name="Verdana" GridLines="None" ItemStyle-BorderColor="#ffffff" Font-Size="11px" ShowFooter = true >
																														<SelectedItemStyle Font-Bold="True" Height="20px"></SelectedItemStyle>
																														<EditItemStyle Wrap="False"></EditItemStyle>
																														<AlternatingItemStyle Wrap="False"></AlternatingItemStyle>
																														<ItemStyle Wrap="False" Height="20px"></ItemStyle>
																														<HeaderStyle Font-Underline="True" Wrap="False" Height="20px" ForeColor="Black" BackColor="white"></HeaderStyle>
																														<FooterStyle Wrap="False" Height="20px" HorizontalAlign="Right" Font-Bold="True"></FooterStyle>
																														<Columns>
																															<asp:BoundColumn DataField="code">
																																<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10%"></HeaderStyle>
																																<ItemStyle Wrap="False" HorizontalAlign="Left" width="10%"></ItemStyle>
																															</asp:BoundColumn>
																															<asp:BoundColumn DataField="inv_no">
																																<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10%"></HeaderStyle>
																																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="10%"></ItemStyle>
																															</asp:BoundColumn>
																															<asp:BoundColumn DataField="inv_date" DataFormatString="{0:dd/MM/yyyy}">
																																<HeaderStyle Wrap="False" HorizontalAlign="Left" Width="10%"></HeaderStyle>
																																<ItemStyle Wrap="False" HorizontalAlign="Left" Width="10%"></ItemStyle>
																															</asp:BoundColumn>
																															<asp:BoundColumn DataField="qty" DataFormatString="{0:0.00}">
																																<headerstyle HorizontalAlign="Right" width="10%"></headerstyle>
																																<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
																															</asp:BoundColumn>
																															<asp:BoundColumn DataField="price" DataFormatString="{0:0.00}">
																																<headerstyle HorizontalAlign="Right" width="10%"></headerstyle>
																																<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
																															</asp:BoundColumn>
																															<asp:BoundColumn DataField="Sale" DataFormatString="{0:0.00}">
																																<headerstyle HorizontalAlign="Right" width="10%"></headerstyle>
																																<ItemStyle HorizontalAlign="Right" Width="10%"></ItemStyle>
																															</asp:BoundColumn>
																														</Columns>
																													</asp:DataGrid>
																												</td>
																											</tr>
																										</asp:PlaceHolder>
																									</ItemTemplate>
																								</asp:TemplateColumn>
																							</Columns>
																						</asp:datagrid>
																					</td>
																				</tr>
																				<tr>
																					<td align="center">
																						<asp:button id="btnBack" runat="server" Width="88px" Text="Back"></asp:button>
																					</td>
																				</tr>
																			</table>
																		</td>
																	</tr>
																</table>
															</TD>
														</TR>
													</table>
												</td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="29">
						<!-- Footer --><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</FORM>
	</body>
</HTML>
