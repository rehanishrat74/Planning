<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ OutputCache Location="None" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdateServices.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.UpdateServices" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Update Services</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/Library/style/Style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<script language="javascript">
		function productmode(c)
		{
		var pckprods = document.getElementsByTagName("input");	
		var rowcount = pckprods.length;	
		var cntr; 
		for(cntr=0;cntr<rowcount;cntr++)
		{
		var ipt = pckprods[cntr];
		if (ipt.type=='checkbox' && ipt.id!=c.id && ipt.value==c.value)
		{ipt.disabled=c.checked?'disabled':'';ipt.checked='';
		}
		}
		}
				
		</script>
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="Form1" method="post" runat="server">
			<INPUT id="IsFormCompeleted22" type="hidden" name="IsFormCompeleted22" runat="server"><input id="hCriteria" type="hidden" value="3" name="hCriteria" runat="server">
			<input id="hSort" type="hidden" value="CompName" name="hSort" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tbody>
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<!--***************************************************************-->
					<tr vAlign="top">
						<!-- BEGIN MAIN BODY CONTENTS -->
						<td height="98%">
							<table class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tbody>
									<tr>
										<td vAlign="top" align="left" width="1%" rowSpan="3"></td>
										<td vAlign="top" align="right" width="99%"><font face="Verdana, Arial, Helvetica, sans-serif" color="#6699cc" size="2"><BR>
												::..:&nbsp;<asp:label id="lblupdateservices" key="acc_members_updateservices_lblupdateservices" Runat="server"></asp:label>&nbsp;&nbsp;<BR>
											</font>
										</td>
									</tr>
									<tr>
										<td style="WIDTH: 604px" vAlign="top" width="604" height="0"></td>
									</tr>
									<tr>
										<td style="WIDTH: 604px" vAlign="top" align="center">
											<!--BEGIN ERROR PANEL -->
											<table class="CONTENT" cellSpacing="1" cellPadding="2" width="100%" border="0">
												<tbody>
													<tr>
														<td class="error" bgColor="white"></td>
													</tr>
												</tbody>
											</table>
											<!--END ERROR PANEL -->
											<!--BEGIN INFORMATION PANEL --><asp:panel id="pnlInformation" runat="server" Width="601px">
												<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0"> <!-- begin dark grey section title -->
																<TR>
																	<TD class="acc_header_backgrounds" id="Td1" runat="server" key="acc_ttinformation" NAME="Td1"></TD>
																</TR> <!-- end dark grey section title -->
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background" cellSpacing="1" cellPadding="2" width="100%"
																			border="0">
																			<TR>
																				<TD class="info" width="100%"><!-- #include virtual="/include/span.htm" --></TD>
																			</TR>
																			<TR>
																				<TD class="info">&nbsp;
																				</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!--END INFORMATION PANEL -->
											<!-- BEGIN COMPANY LIST PANEL --><asp:panel id="pnlCompanyList" Runat="server" Width="600px" BorderWidth="1">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD class="acc_header_backgrounds" id="Td2" height="15" runat="server" key="acc_members_updateservices_ttcompanylist"
															NAME="Td2"></TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-White_background" cellSpacing="1" cellPadding="2" width="100%"
																border="0">
																<TR vAlign="middle" height="20">
																	<TD class="link_text">
																		<asp:Label id="lblselectcompnany" runat="server" key="acc_members_updateservices_lblselectcompany"
																			Width="520px"></asp:Label></TD>
																</TR>
																<TR>
																	<TD></TD>
																</TR>
																<TR>
																	<TD>
																		<asp:ListBox id="listCompany" Runat="server" Width="100%" Rows="10" SelectionMode="Single" BorderStyle="Groove"
																			Font-Size="8pt" CssClass="link_text"></asp:ListBox></TD>
																</TR>
																<TR>
																	<TD align="center">
																		<asp:button id="btnCompanyList" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																			runat="server" key="acc_btnnext" Font-Bold="True" cssclass="acc_mbutton"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!-- END COMPANY LIST PANEL -->
											<!--BEGIN FORM PANEL-->
											<!-- Panel Payment Method ------><asp:panel id="pnlPaymentMethod" runat="server" Width="600px" Visible="False" Height="80px">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR id="hPck" runat="server">
																	<TD class="acc_header_backgrounds" id="Td3" runat="server" key="acc_ttpackagesplans"
																		NAME="Td3"></TD>
																</TR>
																<TR id="dPck" runat="server">
																	<TD>
																		<asp:datagrid id="grdPackages" runat="server" Width="100%" BorderWidth="1px" BorderStyle="None"
																			BackColor="White" AutoGenerateColumns="False" BorderColor="#7BAEE3" CellPadding="3">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<input type="checkbox" id="chkSelect" runat="server" NAME="chkSelect"> <input type="hidden" name="myname" id="hidfield">
																						<asp:Image ID="Checked" ImageUrl="/images/Selected.gif" Visible="False" Runat="server" ImageAlign="AbsMiddle"></asp:Image>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Package Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR id="hPrd" runat="server">
																	<TD class="acc_header_backgrounds" id="Td4" runat="server" key="acc_ttindividualproducts"
																		NAME="Td4"></TD>
																</TR>
																<TR id="dPrd" runat="server">
																	<TD>
																		<asp:datagrid id="grdProducts" runat="server" Width="100%" BorderWidth="1px" BorderStyle="None"
																			Height="100%" BackColor="White" AutoGenerateColumns="False" BorderColor="#7BAEE3" CellPadding="3">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<input type="checkbox" id="chkSelect1" runat="server" NAME="chkSelect1">
																						<asp:Image ID="Checked1" ImageUrl="/images/Selected.gif" Visible="False" Runat="server"></asp:Image>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR> <!-- REM SR -->
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR id="hPPck" runat="server">
																	<TD class="acc_header_backgrounds" id="Td5" runat="server" key="acc_ttrenewpackagesplans"
																		NAME="Td5"></TD>
																</TR>
																<TR id="dPPck" runat="server">
																	<TD>
																		<asp:datagrid id="grdPurchasedPackages" runat="server" Width="100%" BorderWidth="1px" BorderStyle="None"
																			Height="100%" BackColor="White" AutoGenerateColumns="False" BorderColor="#7BAEE3" CellPadding="3">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="facc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<input type="checkbox" id="chkSelect2" runat="server" onClick="productmode(this)" NAME="chkSelect2">
																						<asp:Image ID="Checked2" ImageUrl="/images/Selected.gif" Visible="False" Runat="server"></asp:Image>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid></TD>
																</TR>
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR id="hPPrd" runat="server">
																	<TD class="acc_header_backgrounds" id="Td6" runat="server" key="acc_ttrenewindividualproducts"
																		NAME="Td6"></TD>
																</TR>
																<TR id="dPPrd" runat="server">
																	<TD>
																		<asp:datagrid id="grdPurchasedProducts" runat="server" Width="100%" BorderWidth="1px" BorderStyle="None"
																			Height="100%" BackColor="White" AutoGenerateColumns="False" BorderColor="#7BAEE3" CellPadding="3">
																			<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
																			<ItemStyle Font-Size="XX-Small"></ItemStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																					<ItemTemplate>
																						<input type="checkbox" id="chkSelect3" runat="server" NAME="chkSelect3">
																						<asp:Image ID="Checked3" ImageUrl="/images/Selected.gif" Visible="False" Runat="server"></asp:Image>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Description" HeaderText="Description">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
																					<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="acc_header_backgrounds"></HeaderStyle>
																					<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																				</asp:BoundColumn>
																				<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
																				<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
																			</Columns>
																		</asp:datagrid><BR>
																		<TABLE class="content" cellSpacing="4" cellPadding="0" align="left" border="0">
																			<TR>
																				<TD style="FONT-WEIGHT: bold; WIDTH: 34px">Legends</TD>
																				<TD id="tcExp" style="FONT-WEIGHT: bold" width="13" bgColor="red" runat="server"></TD>
																				<TD style="WIDTH: 125px">
																					<asp:Label id="lblsubscriptionexpired" runat="server" key="acc_members_updateservices_lblsubscriptionexpired"
																						Width="120px"></asp:Label></TD>
																				<TD id="tcAbtExp" style="FONT-WEIGHT: bold" width="13" bgColor="darkblue" runat="server"></TD>
																				<TD>
																					<asp:Label id="lblsubscriptionaboutexpire" runat="server" key="acc_members_updateservices_lblsubscriptionaboutexpire"></asp:Label></TD>
																				<TD width="13"><B>N/A</B></TD>
																				<TD>
																					<asp:Label id="lblavailablepackage" runat="server" key="acc_members_updateregistration_lblavailablepackage"></asp:Label></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR> <!-- REM SR -->
																<TR>
																	<TD>&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD class="acc_header_backgrounds" id="Td7" runat="server" key="acc_ttpaymentmethod"
																		NAME="Td7"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-white_background" cellSpacing="2" cellPadding="0" width="100%"
																			bgColor="white" border="0">
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">&nbsp;</TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="126">&nbsp;
																					<asp:Label id="lblpaymentmode" runat="server" key="acc_members_updateservices_lblpaymentmode"></asp:Label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="289">
																					<asp:radiobuttonlist id="rbtPaymentMethod" runat="server" CssClass="MTBOX">
																						<asp:ListItem Value="Credit Card" Selected="True">Credit 
                                          Card</asp:ListItem>
																						<asp:ListItem Value="Cheque Or Bank Transfer">Cheque 
                                          Or Bank Transfer</asp:ListItem>
																					</asp:radiobuttonlist></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3">&nbsp;</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3">&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="126">&nbsp;
																					<asp:Label id="lbldeliveryaddress" runat="server" key="acc_members_updateservices_lbldeliveryaddress"></asp:Label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="289">
																					<asp:textbox id="txtDeliveryAddress" runat="server" Width="262px" CssClass="MTBOX" Height="74px"
																						TextMode="MultiLine" MaxLength="150"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3">&nbsp;</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3">&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">&nbsp;</TD>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																			<TR>
																				<TD width="126">&nbsp;</TD>
																				<TD width="289">
																					<asp:button id="btnPaymentMethod" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_btnnext" Font-Bold="True" cssclass="acc_mbutton"></asp:button>
																				<TD>&nbsp;</TD>
																				<TD></TD>
																				<TD>&nbsp;</TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlBankTransfer" runat="server" Width="600px" Height="146px">
												<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#cecfce">
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="Td8" bgColor="#c5d8e7" runat="server" key="acc_members_updateservices_ttbanktransfermethod"
																		NAME="Td8"></TD>
																</TR>
																<TR>
																	<TD bgColor="white">
																		<TABLE class="text-outerborder-white_background" cellSpacing="1" cellPadding="2" width="100%"
																			border="0">
																			<TR>
																				<TD vAlign="top" width="173" height="14"></TD>
																				<TD width="9" height="14">&nbsp;
																				</TD>
																				<TD width="252" height="14"></TD>
																				<TD width="109" height="14"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblbankname" runat="server" key="acc_members_updateservices_lblbankname"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtBankName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblchequeno" runat="server" key="acc_members_updateservices_lblchequeno"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtChequeNo" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblsortcode" runat="server" key="acc_members_updateservices_lblsortcode"></asp:Label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtSortCode" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lbltransactionrefno" runat="server" key="acc_members_updateservices_lbltransactionrefno"></asp:Label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtTransactionRefNo" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" width="252"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173"></TD>
																				<TD width="9"></TD>
																				<TD width="252">
																					<asp:button id="btnBankTransfer" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_btnnext" cssclass="acc_mbutton"></asp:button></TD>
																				<TD width="109"></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlCrCardInfo" runat="server" Width="600px" Height="146px">
												<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="Td9" runat="server" key="acc_members_updateservices_ttcreditcardinformation"
																		NAME="Td9"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-white_background" cellSpacing="0" cellPadding="0" width="100%"
																			bgColor="white" border="0">
																			<TR>
																				<TD vAlign="top" width="173" height="14"></TD>
																				<TD width="9" height="14">&nbsp;
																				</TD>
																				<TD width="252" height="14"></TD>
																				<TD width="109" height="14"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblselectcard" runat="server" key=""></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:dropdownlist id="ddlCardNames" runat="server" Width="257px" CssClass="MTBOX">
																						<asp:ListItem Value="Visa Card" Selected="True">Visa Card</asp:ListItem>
																						<asp:ListItem Value="Master Card / Euro Card">Master Card / Euro Card</asp:ListItem>
																						<asp:ListItem Value="Diners Club / Carte Balanche">Diners Club / Carte Balanche</asp:ListItem>
																						<asp:ListItem Value="Discover">Discover</asp:ListItem>
																						<asp:ListItem Value="enRoute">enRoute</asp:ListItem>
																						<asp:ListItem Value="JCB">JCB</asp:ListItem>
																						<asp:ListItem Value="AMEX Card">AMEX Card</asp:ListItem>
																						<asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
																						<asp:ListItem Value="Switch Card">Switch Card</asp:ListItem>
																					</asp:dropdownlist></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblcardholdername2" runat="server" key="acc_members_updateservices_lblcardholdername"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtCardHolderName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="255"
																						EnableViewState="False"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblcardnumber2" runat="server" key="acc_members_updateservices_lblcardnumber"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtCardNumber" runat="server" Width="258px" CssClass="MTBOX" MaxLength="20"
																						EnableViewState="False"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 24px; BORDER-RIGHT-WIDTH: 1px"
																					vAlign="top" borderColor="#7baee3" width="173">
																					<asp:Label id="lblexpirydate2" runat="server" key="acc_members_updateservices_lblexpirydate"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 24px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 24px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="252">
																					<asp:dropdownlist id="ddlMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
																					<asp:dropdownlist id="ddlYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 24px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<P>&nbsp;</P>
																					<P>
																						<asp:Label id="lblcardaddress2" runat="server" key="acc_members_updateservices_lblcardaddress"></asp:Label></P>
																				</TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtCardAddress" runat="server" Width="257px" CssClass="MTBOX" Height="73px"
																						TextMode="MultiLine" MaxLength="255" EnableViewState="False"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblsecuritycode2" runat="server" key="acc_members_updateservices_lblsecuritycode"></asp:Label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:textbox id="txtSecurityCode" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"
																						EnableViewState="False"></asp:textbox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173"></TD>
																				<TD width="9"></TD>
																				<TD width="252"></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173"></TD>
																				<TD width="9"></TD>
																				<TD width="252">
																					<asp:button id="btnCrCardInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_btnnext" cssclass="acc_mbutton"></asp:button></TD>
																				<TD width="109"></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel><asp:panel id="pnlAmexCardInfo" runat="server" Width="600px" Height="84px">
												<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="tdCardHeading" runat="server" key="acc_ttamexcardinfo"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-white_background" cellSpacing="1" cellPadding="2" width="100%"
																			border="0">
																			<TR>
																				<TD align="right" width="173" height="14"></TD>
																				<TD width="9" height="14">&nbsp;
																				</TD>
																				<TD width="252" height="14"></TD>
																				<TD width="109" height="14"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173">
																					<asp:Label id="lblcardholder_name" runat="server" key="acc_members_updateservices_lblcardholdername"></asp:Label>:
																				</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:label id="lblCardName" runat="server" Width="285px"></asp:label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173">
																					<asp:Label id="lblcard_number" runat="server" key="acc_members_updateservices_lblcardnumber"></asp:Label>:
																				</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:label id="lblCardNumber" runat="server" Width="278px"></asp:label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173">
																					<asp:Label id="lblexpiry_date" runat="server" key="acc_members_updateservices_lblexpirydate"></asp:Label>:
																				</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:label id="lblExpiryDate" runat="server" Width="278px"></asp:label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173">
																					<asp:Label id="lblcard_address" runat="server" key="acc_members_updateservices_lblcardaddress"></asp:Label>:</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:label id="lblCardAddress" runat="server" Width="278px"></asp:label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173">
																					<asp:Label id="lblsecurity_code" runat="server" key="acc_members_updateservices_lblsecuritycode"></asp:Label>:
																				</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:label id="lblSecurityCode" runat="server" Width="278px"></asp:label></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					align="right" width="173"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173"><STRONG>
																						<asp:Label id="lblchoosedaterange" runat="server" key="acc_members_updateservices_lblchoosedaterange"></asp:Label></STRONG></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR id="trStartDate" runat="server">
																				<TD id="tdStartDate" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					vAlign="top" borderColor="#7baee3" width="173" runat="server">
																					<asp:Label id="lblstartdate" runat="server" key="acc_members_updateservices_lblstartdate"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9">*</TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:dropdownlist id="ddlAmexSDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
																					<asp:dropdownlist id="ddlAmexSDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR id="trIssueNumber" runat="server">
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
																					borderColor="#7baee3" width="173">
																					<asp:Label id="lblenddate" runat="server" key="acc_members_updateservices_lblenddate"></asp:Label></TD>
																				<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																					borderColor="#7baee3" width="9"></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="252">
																					<asp:TextBox id="txtIssueNumber" runat="server"></asp:TextBox></TD>
																				<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
																					width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173"></TD>
																				<TD width="9"></TD>
																				<TD width="252"></TD>
																				<TD width="109"></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" width="173"></TD>
																				<TD width="9"></TD>
																				<TD width="252">
																					<asp:button id="btnAmexInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																						runat="server" key="acc_btnnext" cssclass="acc_mbutton"></asp:button></TD>
																				<TD width="109"></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!--END FORM PANEL-->
											<!--****************************************************************--><asp:button id="btnRetry" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
												runat="server" key="acc_btnretrypayment" Visible="False" Cssclass="acc_mbutton" CommandName="NO"></asp:button>&nbsp;<asp:button id="btnFinish" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
												runat="server" key="acc_btnfinish" cssclass="acc_mbutton" Visible="False"></asp:button>
											<asp:textbox id="txtHiddenOrderID" runat="server" Visible="False" Text=""></asp:textbox></td>
									</tr>
								</tbody>
							</table>
						</td>
						<td id="rightbar" width="5%" runat="server"></td>
						</TD></tr>
					<tr>
						<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
					</tr>
				</tbody>
			</table>
			&nbsp;</form>
	</body>
</HTML>
