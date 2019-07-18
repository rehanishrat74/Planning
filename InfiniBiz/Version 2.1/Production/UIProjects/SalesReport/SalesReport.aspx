<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SalesReport.aspx.vb" Inherits="accounts.infinibiz.Web.SalesReport" %>
<%@ Register TagPrefix="uc1" TagName="ServicesList" Src="../Library/components/ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/DateCtrl.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>accounts.infinibiz.com - Sales Report</title>
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
																		<td class="objtd" vAlign="top" width="80%"><strong><font size="5"><asp:label id="lblglobalview" runat="server">Company Sales Report</asp:label></font></strong><br>
																			<table class="content" cellSpacing="0" cellPadding="0" width="100%" height="100%">
																				<TR width="100%">
																					<TD id="Td2" style="HEIGHT: 12px" vAlign="top" width="11%" runat="server" NAME="Td2">
																					<table class="content" height="100%" cellSpacing="0" cellPadding="0" width="60%" border="0">
																					<TBODY>
																						<tr>
																							<td width="15%">From : <uc1:datecontrol id="DCFROM" runat="server"></uc1:datecontrol></td>
																							<td width="15%">To : <uc1:datecontrol id="DCTO" runat="server"></uc1:datecontrol></td>
																							<td align="left" width="10%"><asp:button id="btnFind" runat="server" Text="Find" Width="70px"></asp:button></td>
																						</TR>
																					</TBODY>
																					</table>
																					</TD>
																				</TR>
																				<tr vAlign="top">
																					<td vAlign="top" width="100%" colSpan="3" height="100%"><asp:datagrid id="dgridSummaryInformation" runat="server" width="100%" CellPadding="1" BorderWidth="1px"
																							AllowSorting="True" AutoGenerateColumns="False" GridLines="Horizontal">
																							<ItemStyle CssClass="IBIZ_GridView"></ItemStyle>
																							<HeaderStyle Height="20px" CssClass="IBIZ_GridView_Header" VerticalAlign="Top"></HeaderStyle>
																							<Columns>
																								<asp:BoundColumn DataField="CompanyName" HeaderText="Company Name">
																									<ItemStyle Width="400px"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="bybank" HeaderText="By Bank" DataFormatString="{0:00}">
																									<ItemStyle Font-Bold="True" Width="100px" HorizontalAlign="left"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="bycc" HeaderText="By Credit Card" DataFormatString="{0:00}">
																									<ItemStyle Font-Bold="True" Width="100px" HorizontalAlign="left"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn datafield="Other" HeaderText="Others" DataFormatString="{0:00}">
																									<ItemStyle Font-Bold="True" Width="100px" HorizontalAlign="left"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn datafield="bygross" HeaderText="Gross" DataFormatString="{0:00}">
																									<ItemStyle Font-Bold="True" Width="100px" HorizontalAlign="left"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:TemplateColumn>
																									<HeaderStyle Width="5%" HorizontalAlign="Center"></HeaderStyle>
																									<ItemStyle Width="5%" HorizontalAlign="Center"></ItemStyle>
																									<ItemTemplate>
																										<asp:HyperLink id="Detail" runat="server" NavigateUrl="#"></asp:HyperLink>
																									</ItemTemplate>
																								</asp:TemplateColumn>
																								<asp:BoundColumn datafield="childID" >
																									<HeaderStyle Width="0%" CssClass="Invisible"></HeaderStyle>
																									<ItemStyle Width="0%" CssClass="Invisible"></ItemStyle>
																								</asp:BoundColumn>
																							</Columns>
																						</asp:datagrid></td>
																				<tr>
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
