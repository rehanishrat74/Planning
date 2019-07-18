<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ outputcache Location="None" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdatePayementInfo.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.UpdatePayementInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UpdatePayementInfo</title>
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
				<td vAlign="top"><font size="4">
						<% = CompanyName %>
					</font>
				</td>
			</tr>
			<tr>
				<td height="5"></td>
			</tr>
			
			<tr vAlign="top">
				<td vAlign="top" align="center">
					<table class="content" cellSpacing="0" cellPadding="0" width="600" border="0">
						<tr>
							<td width="50%"><A class="LINK_BLUE" href="/Members/default.aspx">Home</A>
							</td>
							<td align="right"><A class="LINK_BLUE" href="javascript:javascript:history.back();">&lt; 
									Back</A></td>
						</tr>
						<tr>
							<td colSpan="2" height="5"></td>
						</tr>
						<tr>
							<TD colSpan="2" width="600" align=center class="info" >
								<!-- #include virtual="/include/span.htm" -->
							</TD>
						</tr>
						<tr>
							<td colSpan="2" height="5"></td>
						</tr>
					</table>
					<asp:datagrid id="dgrdUpdatePayInfo" BorderWidth="0" CssClass="content" Width="600" AutoGenerateColumns="False"
						Runat="server">
						<Columns>
							<asp:TemplateColumn>
								<HeaderTemplate>
									<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
										<tr bgColor="SteelBlue">
											<td width="25%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Order No.</b></font></td>
											<td width="50%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Date</b></font>
											</td>
											<td width="15%" align="center" style="HEIGHT: 20px"><font color="AliceBlue"><b>Pay</b></font>
											</td>
											<td width="10%" align="center" style="HEIGHT: 20px"><font color="AliceBlue"><b>Detail</b></font></td>
										</tr>
									</table>
								</HeaderTemplate>
								<ItemTemplate>
									<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
										<tr>
											<td width="25%"><%# DataBinder.Eval(Container.DataItem,"OrderNo") %></td>
											<td width="50%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
											<td width="15%" align="center">
												<asp:LinkButton Runat="server" ID="lnkPay" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"Status") %>' OnClick=lnkPay_Click>
																		Pay
																	</asp:LinkButton></td>
											<td width="10%" align="center">
											<a href="#_self1" onclick="javascript:showOrder('<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>');" >Detail</a> 
											</td>
										</tr>
									</table>
								</ItemTemplate>
							</asp:TemplateColumn>
						</Columns>
					</asp:datagrid>
					<!-- BEGIN OF SPECIFIC ORDER DETAILS PANEL --><asp:panel id="pnlOrder" Width="600" Runat="server" Visible="False" Wrap=True >
						<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD height="5" width="600"></TD>
							</TR>
							<TR>
								<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="600">Order Info</TD>
							</TR>
							<TR>
								<TD width="600">Order Number :
									<asp:Label id="lblOrderNo" Runat="server"></asp:Label>
									<asp:Label id="lblStatus" Runat="server" Visible="False"></asp:Label></TD>
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
													<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
														<tr bgColor="SteelBlue">
															<td width="40%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Product Name</b></font></td>
															<td width="20%" style="HEIGHT: 20px" align="right"><font color="AliceBlue"><b>Quantaty</b></font>
															</td>
															<td width="20%" style="HEIGHT: 20px" align="right"><font color="AliceBlue"><b>Price</b></font>
															</td>
															<td width="20%" align="right" style="HEIGHT: 20px" align="right"><font color="AliceBlue"><b>Amount</b></font>
															</td>
														</tr>
													</table>
												</HeaderTemplate>
												<ItemTemplate>
													<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
														<tr>
															<td width="40%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
															<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Quantaty") %></td>
															<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"UnitPrice") %></td>
															<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"ProdAmount") %></td>
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
								<TD class="acc_header_backgrounds">&nbsp;Payment Method</TD>
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
												width="126">&nbsp;Payment Mode :</TD>
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
												width="126">&nbsp;Delivery Address :</TD>
											<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
												width="289">
												<asp:textbox id="txtDeliveryAddress" runat="server" CssClass="MTBOX" Width="262px" Height="74px"
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
													runat="server" Width="63px" Font-Bold="True" Text="Next >>" cssclass="acc_mbutton"></asp:button>
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
									<TABLE class="CONTENT" width="100%" border="0">
										<TR>
											<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;Bank Transfer Method
											</TD>
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
															borderColor="#7baee3" width="173">Bank Name</TD>
														<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
															borderColor="#7baee3" width="9"></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="252">
															<asp:textbox id="txtBankName" runat="server" CssClass="MTBOX" Width="258px" MaxLength="50"></asp:textbox></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="109"></TD>
													</TR>
													<TR>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
															borderColor="#7baee3" width="173">Cheque No.</TD>
														<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
															borderColor="#7baee3" width="9"></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="252">
															<asp:textbox id="txtChequeNo" runat="server" CssClass="MTBOX" Width="258px" MaxLength="10"></asp:textbox></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="109"></TD>
													</TR>
													<TR>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
															borderColor="#7baee3" width="173">Sort Code</TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="9"></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="252">
															<asp:textbox id="txtSortCode" runat="server" CssClass="MTBOX" Width="258px" MaxLength="10"></asp:textbox></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="109"></TD>
													</TR>
													<TR>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
															borderColor="#7baee3" width="173">Transaction Ref. No.</TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="9"></TD>
														<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
															width="252">
															<asp:textbox id="txtTransactionRefNo" runat="server" CssClass="MTBOX" Width="256px" MaxLength="10"></asp:textbox></TD>
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
																runat="server" Text="Next >>" cssclass="acc_mbutton"></asp:button></TD>
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
											<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;Credit Card Information
											</TD>
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
														<TD vAlign="top" width="173">Select Card
														</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:dropdownlist id="ddlCardNames" runat="server" CssClass="MTBOX" Width="257px">
																<asp:ListItem Value="Visa Card" Selected="True">Visa Card</asp:ListItem>
																<asp:ListItem Value="Master Card / Euro Card">Master Card / Euro Card</asp:ListItem>
																<asp:ListItem Value="Diners Club / Carte Balanche">Diners Club / Carte Balanche</asp:ListItem>
																<asp:ListItem Value="Discover">Discover</asp:ListItem>
																<asp:ListItem Value="enRoute">enRoute</asp:ListItem>
																<asp:ListItem Value="JCB">JCB</asp:ListItem>
																<asp:ListItem Value="AMEX Card">AMEX Card</asp:ListItem>
																<asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
															</asp:dropdownlist></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Card Holder Name</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:textbox id="txtCardHolderName" runat="server" CssClass="MTBOX" Width="258px" MaxLength="255"></asp:textbox></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Card Number</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:textbox id="txtCardNumber" runat="server" CssClass="MTBOX" Width="258px" MaxLength="20"></asp:textbox></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Expiry Date (mm / yyyy)&nbsp;</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:dropdownlist id="ddlMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
															<asp:dropdownlist id="ddlYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">
															<P>&nbsp;</P>
															<P>Card&nbsp;Address
															</P>
														</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:textbox id="txtCardAddress" runat="server" CssClass="MTBOX" Width="257px" Height="73px"
																TextMode="MultiLine" MaxLength="255"></asp:textbox></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Security&nbsp;Code&nbsp;</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:textbox id="txtSecurityCode" runat="server" CssClass="MTBOX" Width="256px" MaxLength="10"></asp:textbox></TD>
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
																runat="server" Text="Next >>" Cssclass="MBUTTON"></asp:button></TD>
														<TD width="109"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</asp:panel><asp:panel id="pnlAmexCardInfo" runat="server" Width="597" Height="84px">
						<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#cecfce">
									<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
										<TR>
											<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;AMEX Card Information
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
													cellSpacing="1" cellPadding="2" width="100%" bgColor="#f6f5f5" border="0">
													<TR>
														<TD align="right" width="173" height="14"></TD>
														<TD width="9" height="14">&nbsp;
														</TD>
														<TD width="252" height="14"></TD>
														<TD width="109" height="14"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card Holder Name :
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:label id="lblCardName" runat="server" Width="285px"></asp:label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card Number :
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:label id="lblCardNumber" runat="server" Width="278px"></asp:label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Expiry Date (mm / yyyy)&nbsp;:
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:label id="lblExpiryDate" runat="server" Width="278px"></asp:label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card&nbsp;Address :</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:label id="lblCardAddress" runat="server" Width="278px"></asp:label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Security&nbsp;Code&nbsp;:
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:label id="lblSecurityCode" runat="server" Width="278px"></asp:label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173"></TD>
														<TD width="9"></TD>
														<TD width="252"></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173"><STRONG>Choose Date Range</STRONG></TD>
														<TD width="9"></TD>
														<TD width="252"></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Start&nbsp;Date (mm / yyyy)</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:dropdownlist id="ddlAmexSDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
															<asp:dropdownlist id="ddlAmexSDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">End Date (mm / yyyy)</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:dropdownlist id="ddlAmexEDMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
															<asp:dropdownlist id="ddlAmexEDYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
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
															<asp:button id="btnAmexInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																runat="server" Text="Next >>" Cssclass="MBUTTON"></asp:button></TD>
														<TD width="109"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</asp:panel><asp:panel id="pnlDrCardInfo" runat="server" Width="601px" Height="71px">
						<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
							<TR>
								<TD bgColor="#cecfce">
									<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
										<TR>
											<TD class="acc_header_backgrounds" bgColor="#c5d8e7">&nbsp;Debit Card Information
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE class="text-outerborder-White_background" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
													cellSpacing="1" cellPadding="2" width="100%" bgColor="white" border="0">
													<TR>
														<TD align="right" width="173" height="14"></TD>
														<TD width="9" height="14">&nbsp;
														</TD>
														<TD width="252" height="14"></TD>
														<TD width="109" height="14"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card Holder Name :
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:Label id="lblCardName1" runat="server" Width="285px"></asp:Label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card Number :
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:Label id="lblCardNumber1" runat="server" Width="278px"></asp:Label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Expiry Date (mm / yyyy)&nbsp;:
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:Label id="lblExpiryDate1" runat="server" Width="278px"></asp:Label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Card&nbsp;Address :</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:Label id="lblCardAddress1" runat="server" Width="278px"></asp:Label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173">Security&nbsp;Code&nbsp;:
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:Label id="lblSecurityCode1" runat="server" Width="278px"></asp:Label></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD align="right" width="173"></TD>
														<TD width="9"></TD>
														<TD width="252"></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173"><STRONG>Choose Date Range</STRONG></TD>
														<TD width="9"></TD>
														<TD width="252"></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Issue&nbsp;Date (mm / yyyy)</TD>
														<TD class="error" width="9">*</TD>
														<TD width="252">
															<asp:DropDownList id="ddlDrCardSDMonth" runat="server" CssClass="MTBOX"></asp:DropDownList>&nbsp;/
															<asp:DropDownList id="ddlDrCardSDYear" runat="server" CssClass="MTBOX"></asp:DropDownList></TD>
														<TD width="109"></TD>
													</TR>
													<TR>
														<TD vAlign="top" width="173">Issue Number
														</TD>
														<TD width="9"></TD>
														<TD width="252">
															<asp:TextBox id="txtIssueNo" runat="server" CssClass="MTBOX" Width="158px" MaxLength="10"></asp:TextBox></TD>
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
															<asp:Button id="btnDrCardInfo" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																runat="server" Text="Next >>" Cssclass="MBUTTON"></asp:Button></TD>
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
					<!-- END OF PANELS -->
					<table class="content" cellSpacing="0" cellPadding="0" width="600" border="0">
						<tr>
							<td width="50%"><A class="LINK_BLUE" href="/Members/default.aspx">Home</A>
							</td>
							<td align="right"><A class="LINK_BLUE" href="javascript:javascript:history.back();">&lt; 
									Back</A></td>
						</tr>
						<tr>
							<td colSpan="2" height="5"></td>
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
