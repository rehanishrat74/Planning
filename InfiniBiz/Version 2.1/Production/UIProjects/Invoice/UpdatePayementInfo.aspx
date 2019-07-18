<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdatePayementInfo.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.UpdatePayementInfo" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Update Order's Payement</title>
		<META http-equiv="Content-Type" content="text/html; charset=windows-1252">
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft FrontPage 6.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<form id="formTransactionDetail" method="post" runat="server">
	</HEAD>
	<BODY id="htmlContentBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
			border="0">
			<tr>
				<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
			</tr>
			<tr>
				<td vAlign="top" colSpan="2"><font size="4">
						<% = CompanyName %>
					</font>
				</td>
			</tr>
			<tr>
				<td colSpan="2" height="5"></td>
			</tr>
			<tr vAlign="top">
				<td vAlign="top">
					<table class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<tr>
							<td vAlign="top" align="center" width="180"><include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></td>
							<td width="3">&nbsp;</td>
							<td vAlign="top">
								<table class="content" cellSpacing="0" cellPadding="0" width="600" border="0">
									<tr>
										<TD class="info" align="center" width="600" colSpan="2">
											<!--BEGIN INFORMATION PANEL --><asp:panel id="pnlInformation" runat="server" Visible="False" Width="601px">
												<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0"> <!-- begin dark grey section title -->
																<TR>
																	<TD class="acc_header_backgrounds" runat="server" key="acc_ttinformation" ID="Td1"></TD>
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
											<!--END INFORMATION PANEL --></TD>
									</tr>
									<tr>
										<td colSpan="2" height="5"></td>
									</tr>
								</table>
								<asp:datagrid id="dgrdUpdatePayInfo" Width="600" Runat="server" AutoGenerateColumns="False">
									<Columns>
										<asp:TemplateColumn>
											<HeaderTemplate>
												<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
													<tr class="acc_header_backgrounds" bgColor="SteelBlue">
														<td width="25%" height="20px" runat="server" key="acc_ttordernumber" ID="Td2"></td>
														<td width="45%" height="20px" runat="server" key="acc_ttdate" ID="Td3">
														</td>
														<td width="20%" align="center" height="20px" runat="server" key="acc_ttretrypayment" ID="Td4">
														</td>
														<td width="10%" align="center" height="20px" runat="server" key="acc_ttdetail" ID="Td5"></td>
													</tr>
												</table>
											</HeaderTemplate>
											<ItemTemplate>
												<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
													<tr>
														<td width="25%" height="20px"><%# DataBinder.Eval(Container.DataItem,"OrderNo") %></td>
														<td width="45%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
														<td width="20%" align="center">
															<asp:LinkButton Runat="server" ID="lnkPay" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Status") %>' OnClick=lnkPay_Click>
																		Retry Payment
																	</asp:LinkButton></td>
														<td width="10%" align="center"><a href="#_self1" onclick="javascript:showOrder('<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>');" >Detail</a>
														</td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:TemplateColumn>
									</Columns>
								</asp:datagrid>
								<!-- BEGIN OF SPECIFIC ORDER DETAILS PANEL --><asp:panel id="pnlOrder" Visible="False" Width="600" Runat="server" Wrap="True">
									<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="600" height="5"></TD>
										</TR>
										<TR>
											<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="600" runat="server" key="acc_ttorderinfo" ID="Td6"></TD>
										</TR>
										<TR>
											<TD width="600">
												<asp:Label id="lblOrderNo" Runat="server"></asp:Label>
												<asp:Label id="lblStatus" Visible="False" Runat="server"></asp:Label></TD>
										</TR>
										<TR>
											<TD height="10"></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:DataGrid id="dgrdOrder" Width="600" AutoGenerateColumns="False" Runat="server">
													<Columns>
														<asp:TemplateColumn>
															<HeaderTemplate>
																<table  border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
																	<tr class="acc_header_backgrounds" bgColor="SteelBlue">
																		<td width="40%" style="HEIGHT: 20px" runat="server" key="acc_ttproductname" ID="Td7"></td>
																		<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttquantity"
																			ID="Td8"></td>
																		<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttprice"
																			ID="Td9"></td>
																		<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttamount"
																			ID="Td10"></td>
																	</tr>
																</table>
															</HeaderTemplate>
															<ItemTemplate>
																<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
																	<tr>
																		<td width="40%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
																		<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Quantaty") %></td>
																		<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"UnitPrice"),2,0,0,0) %></td>
																		<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"ProdAmount"),2,0,0,0) %></td>
																	</tr>
																</table>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
												</asp:DataGrid></TD>
										</TR>
									</TABLE>
								</asp:panel><br>
								<!-- END OF SPECIFIC ORDER DETAILS PANEL -->
								<!-- BEGIN Cheque or Bank Panel --><asp:panel id="pnlChkBank" Width="600px" Runat="server" Height="146px">
									<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>&nbsp;
											</TD>
										</TR>
										<TR>
											<TD class="acc_header_backgrounds" runat="server" key="acc_members_updateservices_ttpaymentmethod" ID="Td11"></TD>
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
															<asp:Label id="lblpaymentmode" runat="server" key="acc_members_updateservices_lblpaymentmode"></asp:Label>:</TD>
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
															<asp:Label id="lbldeliveryaddress" runat="server" key="acc_members_updateservices_lbldeliveryaddress"></asp:Label>:</TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="289">
															<asp:textbox id="txtDeliveryAddress" runat="server" Width="262px" Height="74px" CssClass="MTBOX"
																MaxLength="150" TextMode="MultiLine"></asp:textbox></TD>
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
																runat="server" key="acc_btnnext" cssclass="acc_mbutton" Font-Bold="True"></asp:button>
														<TD>&nbsp;</TD>
														<TD></TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</asp:panel>
								<!-- END Cheque or Bank Panel --><asp:panel id="pnlBankTransfer" runat="server" Width="600px" Height="146px">
									<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#cecfce">
												<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
													<TR>
														<TD class="acc_header_backgrounds" id="Td12" bgColor="#c5d8e7" runat="server" key="acc_members_updateservices_ttbanktransfermethod"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																cellSpacing="1" cellPadding="2" width="100%" bgColor="#f6f5f5" border="0">
																<TR>
																	<TD vAlign="top" width="173" height="14"></TD>
																	<TD width="9" height="14">&nbsp;
																	</TD>
																	<TD width="252" height="14"></TD>
																	<TD width="109" height="14"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblbankname" runat="server" key="acc_members_updateservices_lblbankname"></asp:Label></TD>
																	<TD class="error" width="9"></TD>
																	<TD width="252">
																		<asp:textbox id="txtBankName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblchequeno" runat="server" key="acc_members_updateservices_lblchequeno"></asp:Label></TD>
																	<TD class="error" width="9"></TD>
																	<TD width="252">
																		<asp:textbox id="txtChequeNo" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblsortcode" runat="server" key="acc_members_updateservices_lblsortcode"></asp:Label></TD>
																	<TD width="9"></TD>
																	<TD width="252">
																		<asp:textbox id="txtSortCode" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lbltransactionrefno" runat="server" key="acc_members_updateservices_lbltransactionrefno"></asp:Label></TD>
																	<TD width="9"></TD>
																	<TD width="252">
																		<asp:textbox id="txtTransactionRefNo" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																	<TD width="109"></TD>
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
																		<asp:button id="btnBankTransfer" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																			runat="server" key="acc_btnnext" Cssclass="MBUTTON"></asp:button></TD>
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
								<!-- BEGINF PANELS --><asp:panel id="pnlCrCardInfo" runat="server" Width="600px" Height="146px">
									<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#cecfce">
												<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
													<TR>
														<TD class="acc_header_backgrounds" id="Td13" bgColor="#c5d8e7" runat="server" key="acc_members_updateservices_ttcreditcardinformation"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																cellSpacing="0" cellPadding="0" width="100%" bgColor="white" border="0">
																<TR>
																	<TD vAlign="top" width="173" height="14"></TD>
																	<TD width="9" height="14">&nbsp;
																	</TD>
																	<TD width="252" height="14"></TD>
																	<TD width="109" height="14"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblselectcard" runat="server" key="acc_members_updateservices_lblselectcard"></asp:Label></TD>
																	<TD class="error" width="9">*</TD>
																	<TD width="252">
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
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblcardholdername2" runat="server" key="acc_members_updateservices_lblcardholdername"></asp:Label></TD>
																	<TD class="error" width="9">*</TD>
																	<TD width="252">
																		<asp:textbox id="txtCardHolderName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblcardnumber2" runat="server" key="acc_members_updateservices_lblcardnumber"></asp:Label></TD>
																	<TD class="error" width="9">*</TD>
																	<TD width="252">
																		<asp:textbox id="txtCardNumber" runat="server" Width="258px" CssClass="MTBOX" MaxLength="20"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblexpirydate2" runat="server" key="acc_members_updateservices_lblexpirydate"></asp:Label></TD>
																	<TD class="error" width="9">*</TD>
																	<TD width="252">
																		<asp:dropdownlist id="ddlMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
																		<asp:dropdownlist id="ddlYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<P>&nbsp;</P>
																		<P>
																			<asp:Label id="lblcardaddress2" runat="server" key="acc_members_updateservices_lblcardaddress"></asp:Label></P>
																	</TD>
																	<TD class="error" width="9">*</TD>
																	<TD width="252">
																		<asp:textbox id="txtCardAddress" runat="server" Width="257px" Height="73px" CssClass="MTBOX"
																			MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
																	<TD width="109"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="173">
																		<asp:Label id="lblsecuritycode2" runat="server" key="acc_members_updateservices_lblsecuritycode"></asp:Label></TD>
																	<TD width="9"></TD>
																	<TD width="252">
																		<asp:textbox id="txtSecurityCode" runat="server" Width="256px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
																	<TD width="109"></TD>
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
																			runat="server" key="acc_btnnext" Cssclass="MBUTTON"></asp:button></TD>
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
																	<TD id="tdStartDate" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																		vAlign="top" borderColor="#7baee3" width="173" runat="server">
																		<asp:Label id="lblstartdate" runat="server" key="acc_members_updateservices_lblstartdate"></asp:Label></TD>
																	<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																		borderColor="#7baee3" width="9">*</TD>
																	<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																		borderColor="#7baee3" width="252">
																		<asp:dropdownlist id="ddlAmexSDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
																		<asp:dropdownlist id="ddlAmexSDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
																	<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 19px; BORDER-RIGHT-WIDTH: 1px"
																		borderColor="#7baee3" width="109"></TD>
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
								
								
								<asp:Panel ID="pnlRetryPayment" Runat="server" Visible="False" Width="601px">
									<TABLE class="CONTENT" width="100%" border="0">
										<TR>
											<TD align="center">
												<asp:button id="btnRetry" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
													runat="server" Visible="true" Width="100px" Text="Retry Payment" Cssclass="acc_mbutton"
													CommandName="NO"></asp:button>&nbsp;
												<asp:button id="btnFinish" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
													runat="server" Visible="true" Width="100px" Text="Finish" Cssclass="acc_mbutton" CommandName="NO"></asp:button></TD>
										</TR>
									</TABLE>
								</asp:Panel>
								<!-- END OF PANELS -->
								<table class="content" cellSpacing="0" cellPadding="0" width="600" border="0">
									<tr>
										<td align="right" width="100%"><A class="LINK_BLUE" href="javascript:javascript:history.back();" runat="server" key="acc_aback" id="id1"></A></td>
									</tr>
									<tr>
										<td colSpan="2" height="5"></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
			</tr>
		</table>
		</FORM></TD></TR></TBODY></TABLE>
		<script lang="javscript">
			function showOrder(order)
			{
				window.open('/Invoice/UpdatePaymentInfoDetail.aspx?order='+order,'OrderDetail','resizable=1,scrollbars=yes,hegiht=300,width=700');
				return false;
			}
		</script>
	</BODY>
</HTML>
