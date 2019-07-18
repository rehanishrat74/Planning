<%@ Page Language="vb" AutoEventWireup="false" Codebehind="GlobalView.aspx.vb" Inherits="accounts.infinibiz.Web.GlobalViewUI" %>
<%@ Register TagPrefix="uc1" TagName="ServicesList" Src="../Library/components/ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Global View</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<!--<link href="https://services.infinibiz.com/images/main.css" type="text/css" rel="stylesheet">-->
		<style type="text/css"> a:link { text-decoration: none; color: #000000;}
	a:visited { text-decoration: none; color: #000000; }
	a:hover { text-decoration: underline; color: rgb(255,128,0); }
		</style>
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
										<table class="CONTENT" id="tblContent" style="BACKGROUND: url(https://services.infinibiz.com/images/bg.gif)"
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
																		<td class="objtd" vAlign="top" width="80%"><strong><font size="5"><asp:label id="lblglobalview" runat="server" key="acc_globalview_globalview_lblglobalview"></asp:label></font></strong><br>
																			<asp:linkbutton id="btnAddaCompany" style="FONT-WEIGHT: bold" key="acc_globalview_globalview_btnAddaCompany"
																				Visible="False" type="button" Runat="server" ForeColor="Blue" Font-Underline="True"></asp:linkbutton><br>
																			<font color="red">
																				<asp:literal id="litFHMessage" runat="server" Text="Error: Temporarily Formations House's Companies information is not available.<BR>"></asp:literal></font><br>
																			<table class="content" cellSpacing="0" cellPadding="0" width="100%" height="100%">
																				<TR width="100%">
																					<TD id="Td2" style="HEIGHT: 12px" vAlign="top" width="11%" runat="server" NAME="Td2"><asp:literal id="litSearchComp" Runat="server"></asp:literal></TD>
																					<td width="50%"><asp:textbox id="txtSearch" runat="server" cssclass="content" Width="95%"></asp:textbox></td>
																					<td align="left"><asp:imagebutton id="btnGo" runat="server" key="acc_globalview_globalview_btngo"></asp:imagebutton></td>
																				</TR>
																				<tr vAlign="top">
																					<td vAlign="top" width="100%" colSpan="3" height="100%"><asp:datagrid id="dgridSummaryInformation" runat="server" width="100%" CellPadding="1" BorderWidth="1px"
																							AllowSorting="True" AutoGenerateColumns="False" GridLines="Horizontal">
																							<ItemStyle CssClass="IBIZ_GridView"></ItemStyle>
																							<HeaderStyle Height="20px" CssClass="IBIZ_GridView_Header" VerticalAlign="Top"></HeaderStyle>
																							<Columns>
																								<asp:ButtonColumn Text="Company Name" DataTextField="CompName" SortExpression="CompName" HeaderText="Company Name"
																									CommandName="SELECT">
																									<ItemStyle ForeColor="Blue"></ItemStyle>
																								</asp:ButtonColumn>
																								<asp:TemplateColumn>
																									<ItemStyle Width="100px"></ItemStyle>
																									<HeaderTemplate>
																										Reseller ID
																									</HeaderTemplate>
																									<ItemTemplate>
																										<asp:Label ID="lblResellerUID" Runat="server"></asp:Label>
																									</ItemTemplate>
																								</asp:TemplateColumn>
																								<asp:BoundColumn DataField="IncDate" SortExpression="IncDate" HeaderText="Incorporation Date" DataFormatString="{0:d}">
																									<ItemStyle Width="100px"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="eFilingDate" SortExpression="eFilingDate" HeaderText="Accounts Reference Date"
																									DataFormatString="{0:d}">
																									<ItemStyle Width="100px"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="Status" SortExpression="Status" HeaderText="Annual Accounts Status">
																									<ItemStyle Font-Bold="True" Width="100px"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn SortExpression="DissolvedDate, Dormant" HeaderText="Company Status">
																									<ItemStyle Font-Bold="True" Width="100px"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:ButtonColumn Visible="False" Text="Login" SortExpression="MemberCustomerID" HeaderText="Action"
																									CommandName="SELECT">
																									<ItemStyle ForeColor="Blue"></ItemStyle>
																								</asp:ButtonColumn>
																								<asp:BoundColumn Visible="False" DataField="cart_customer_uid" HeaderText="cart_customer_uid"></asp:BoundColumn>
																								<asp:BoundColumn Visible="False" DataField="GVStatus" HeaderText="GVStatus"></asp:BoundColumn>
																								<asp:BoundColumn Visible="False" DataField="CompEmail" HeaderText="CompEmail"></asp:BoundColumn>
																								<asp:BoundColumn Visible="False" DataField="CompRegNo" HeaderText="CompRegNo"></asp:BoundColumn>
																								<asp:BoundColumn Visible="False" DataField="MemberCustomerID" HeaderText="MemberCustomerID"></asp:BoundColumn>
																								<asp:BoundColumn Visible="False" DataField="CompName" SortExpression="CompName" HeaderText="CompanyName"></asp:BoundColumn>
																							</Columns>
																						</asp:datagrid></td>
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
