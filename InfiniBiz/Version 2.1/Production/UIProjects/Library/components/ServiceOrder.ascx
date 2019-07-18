<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ServiceOrder.ascx.vb" Inherits="InfiniLogic.AccountsCentre.Web.ServiceOrder" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="/Library/style/Style.css" type="text/css" rel="stylesheet">
<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
<table class="Content" cellSpacing="0" cellPadding="0" width="600" border="0">
	<tr>
		<td><br>
			<br>
		</td>
	</tr>
	<tr>
		<td><asp:panel id="pnlInfomration" Runat="server">
				<TABLE class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="100%"
					border="0">
					<TR>
						<TD class="acc_header_backgrounds" id="Td1" colSpan="2" NAME="Td1" key="acc_ttinformation"
							runat="server"></TD>
					</TR>
					<TR>
						<TD class="info" id="tdInformation" width="100%" bgColor="#f6f5f5" runat="server">&nbsp;</TD>
					</TR>
				</TABLE>
				<BR>
			</asp:panel><asp:panel id="pnlGrid" Runat="server" Width="100%">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR id="trPackagesPlanHeading" runat="server">
						<TD class="acc_header_backgrounds" id="Td2" align="right" colSpan="2" NAME="Td2" key="acc_ttpackagesplans"
							runat="server"></TD>
					</TR>
					<TR id="trPackagesPlanGrid" runat="server">
						<TD>
							<asp:datagrid id="grdPackages" runat="server" Width="100%" CssClass="text-outerborder-White_background"
								AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3">
								<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
								<ItemStyle Font-Size="XX-Small"></ItemStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkSelect" AutoPostBack="false" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ProductName" HeaderText="Package Name">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="40%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Description" HeaderText="Description">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductTax" HeaderText="ProductTax"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Details">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid><BR>
						</TD>
					</TR>
					<TR id="trProductsHeading" runat="server">
						<TD class="acc_header_backgrounds" id="Td3" colSpan="2" NAME="Td3" key="acc_acc_ttindividualproducts"
							runat="server"></TD>
					</TR>
					<TR id="trProductsGrid" runat="server">
						<TD>
							<asp:datagrid id="grdProducts" runat="server" Width="100%" CssClass="text-outerborder-White_background"
								AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3"
								Height="100%">
								<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
								<ItemStyle Font-Size="XX-Small"></ItemStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:CheckBox id="chkSelect1" AutoPostBack="false" runat="server"></asp:CheckBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="40%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="Description" HeaderText="Description">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductTax" HeaderText="ProductTax"></asp:BoundColumn>
									<asp:TemplateColumn HeaderText="Details">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="10%" CssClass="acc_header_backgrounds"></HeaderStyle>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid><BR>
						</TD>
					</TR>
					<TR id="trRenewPackagesHeading" runat="server">
						<TD class="acc_header_backgrounds" id="Td4" NAME="Td4" key="acc_ttrenewpackagesplans"
							runat="server"></TD>
					</TR>
					<TR id="trRenewPackagesGrid" runat="server">
						<TD>
							<asp:datagrid id="grdPurchasedPackages" runat="server" Width="100%" CssClass="text-outerborder-White_background"
								AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3"
								Height="100%">
								<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
								<ItemStyle Font-Size="XX-Small"></ItemStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<input type="checkbox" id="chkSelect2" runat="server" onClick="productmode(this)" NAME="chkSelect2">
											<asp:Image ID="Checked2" ImageUrl="/images/Selected.gif" Visible="False" Runat="server"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Description" HeaderText="Description">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
									<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
								</Columns>
							</asp:datagrid><BR>
						</TD>
					</TR>
					<TR id="trRenewProductsHeading" runat="server">
						<TD class="acc_header_backgrounds" id="Td5" NAME="Td5" key="acc_ttrenewindividualproducts"
							runat="server"></TD>
					</TR>
					<TR id="trRenewProductsGrid" runat="server">
						<TD>
							<asp:datagrid id="grdPurchasedProducts" runat="server" Width="100%" CssClass="text-outerborder-White_background"
								AutoGenerateColumns="False" BorderStyle="None" BorderWidth="1px" BorderColor="#7BAEE3" CellPadding="3"
								Height="100%">
								<SelectedItemStyle Font-Size="XX-Small" Font-Bold="True"></SelectedItemStyle>
								<ItemStyle Font-Size="XX-Small"></ItemStyle>
								<Columns>
									<asp:TemplateColumn>
										<HeaderStyle Font-Size="X-Small" Width="4%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<input type="checkbox" id="chkSelect3" runat="server" NAME="chkSelect3">
											<asp:Image ID="Checked3" ImageUrl="/images/Selected.gif" Visible="False" Runat="server"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="ProductName" HeaderText="Product Name">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="31%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Description" HeaderText="Description">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="50%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" VerticalAlign="Top"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Sale_Price" HeaderText="Cost/Year" DataFormatString="{0:c}">
										<HeaderStyle Font-Size="X-Small" HorizontalAlign="Center" Width="15%" CssClass="frm-section-text"></HeaderStyle>
										<ItemStyle Font-Size="X-Small" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="ProductCode"></asp:BoundColumn>
									<asp:BoundColumn DataField="ProductTax" HeaderText="ProductTax" Visible="False"></asp:BoundColumn>
								</Columns>
							</asp:datagrid><BR>
						</TD>
					</TR>
					<TR id="trLegends" runat="server">
						<TD>
							<TABLE class="content" cellSpacing="4" cellPadding="0" align="left" border="0">
								<TR>
									<TD style="FONT-WEIGHT: bold">Legends</TD>
									<TD id="tcExp" style="FONT-WEIGHT: bold" width="13" bgColor="red" runat="server"></TD>
									<TD>
										<asp:Label id="lblsubscriptionexpired" key="acc_members_updateservices_lblsubscriptionexpired"
											runat="server" Width="120px"></asp:Label></TD>
									<TD id="tcAbtExp" style="FONT-WEIGHT: bold" width="13" bgColor="darkblue" runat="server"></TD>
									<TD>
										<asp:Label id="lblsubscriptionaboutexpire" key="acc_members_updateservices_lblsubscriptionaboutexpire"
											runat="server"></asp:Label></TD>
									<TD width="13"><B>N/A</B></TD>
									<TD>
										<asp:Label id="lblavailablepackage" key="acc_members_updateregistration_lblavailablepackage"
											runat="server"></asp:Label></TD>
								</TR>
							</TABLE>
							<BR>
						</TD>
					</TR>
				</TABLE>
			</asp:panel><asp:datagrid id="dgrdOrder" Runat="server" Width="100%" AutoGenerateColumns="False" CssClass="text-outerborder-White_background"
				Visible="False">
				<Columns>
					<asp:TemplateColumn>
						<HeaderTemplate>
							<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
								<tr class="acc_header_backgrounds">
									<td width="40%" style="HEIGHT: 15px" runat="server" key="acc_ttproductname" ID="Td6"
										NAME="Td6"></td>
									<td width="20%" style="HEIGHT: 15px" align="right" runat="server" key="acc_ttquantity"
										ID="Td7" NAME="Td7">
									</td>
									<td width="20%" style="HEIGHT: 15px" align="right" runat="server" key="acc_ttprice"
										ID="Td8" NAME="Td8">
									</td>
									<td width="20%" align="right" style="HEIGHT: 15px" runat="server" key="acc_ttamount"
										ID="Td9" NAME="Td9">
									</td>
								</tr>
							</table>
						</HeaderTemplate>
						<ItemTemplate>
							<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
								<tr>
									<td width="40%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
									<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Quantaty") %></td>
									<td width="20%" align="right"><%# FormatAmount(DataBinder.Eval(Container.DataItem,"UnitPrice")) %></td>
									<td width="20%" align="right"><%# FormatAmount(DataBinder.Eval(Container.DataItem,"ProdAmount")) %></td>
								</tr>
							</table>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid>
			<table class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<tr id="trDiscount" height="17" runat="server" key="tttotal">
					<td width="50%"><b>Discount</b></td>
					<td id="tdDiscount" align="right" runat="server"></td>
				</tr>
				<tr class="acc_header_backgrounds" id="trOrderToal" height="17" runat="server" key="tttotal">
					<td width="50%">Total</td>
					<td class="acc_header_backgrounds" id="tdOrderAmount" align="right" runat="server"></td>
				</tr>
			</table>
			<br>
			<!-- BEGIN PANEL - Payment Method --><asp:panel id="pnlPaymentOptions" Runat="server" Width="100%">
				<TABLE class="text-outerborder-White_background" cellSpacing="0" cellPadding="0" width="100%"
					border="0">
					<TR>
						<TD class="acc_header_backgrounds" id="Td10" colSpan="2" NAME="Td10" key="acc_members_updateservices_ttpaymentmethod"
							runat="server"></TD>
					</TR>
					<TR>
						<TD colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD style="WIDTH: 212px" align="left" width="212">&nbsp;
							<asp:Label id="lblpaymentmode" key="acc_members_updateservices_lblpaymentmode" runat="server"></asp:Label>:</TD>
						<TD align="left">
							<asp:radiobuttonlist id="rbtPaymentMethod" runat="server" CssClass="MTBOX">
								<asp:ListItem Value="Credit Card" Selected="True">Credit 
                                          Card</asp:ListItem>
								<asp:ListItem Value="Cheque Or Bank Transfer">Cheque 
                                          Or Bank Transfer</asp:ListItem>
							</asp:radiobuttonlist></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 212px" align="left">&nbsp;
							<asp:Label id="lbldeliveryaddress" key="acc_members_updateservices_lbldeliveryaddress" runat="server"></asp:Label>:</TD>
						<TD align="left">
							<asp:textbox id="txtDeliveryAddress" runat="server" Width="262px" CssClass="MTBOX" Height="74px"
								MaxLength="150" TextMode="MultiLine"></asp:textbox></TD>
					</TR>
					<TR>
						<TD colSpan="2"></TD>
					</TR>
					<TR>
						<TD style="WIDTH: 212px"></TD>
						<TD>
							<asp:button id="btnPaymentMethod" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
								key="acc_btnnext" runat="server" cssclass="acc_mbutton" Font-Bold="True"></asp:button></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlBankTransfer" runat="server" Width="600px" Height="146px">
				<TABLE class="CONTENT" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD bgColor="#cecfce">
							<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
								<TR>
									<TD class="acc_header_backgrounds" id="Td11" bgColor="#c5d8e7" key="acc_members_updateservices_ttbanktransfermethod"
										runat="server"></TD>
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
													<asp:Label id="lblbankname" key="acc_members_updateservices_lblbankname" runat="server"></asp:Label></TD>
												<TD class="error" width="9"></TD>
												<TD width="252">
													<asp:textbox id="txtBankName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblchequeno" key="acc_members_updateservices_lblchequeno" runat="server"></asp:Label></TD>
												<TD class="error" width="9"></TD>
												<TD width="252">
													<asp:textbox id="txtChequeNo" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblsortcode" key="acc_members_updateservices_lblsortcode" runat="server"></asp:Label></TD>
												<TD width="9"></TD>
												<TD width="252">
													<asp:textbox id="txtSortCode" runat="server" Width="258px" CssClass="MTBOX" MaxLength="10"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lbltransactionrefno" key="acc_members_updateservices_lbltransactionrefno" runat="server"></asp:Label></TD>
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
														key="acc_btnnext" runat="server" Cssclass="MBUTTON"></asp:button></TD>
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
						<TD bgColor="#cecfce">
							<TABLE class="CONTENT" width="100%" bgColor="#ffffff" border="0">
								<TR>
									<TD class="acc_header_backgrounds" id="Td12" bgColor="#c5d8e7" key="acc_members_updateservices_ttcreditcardinformation"
										runat="server"></TD>
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
												<TD style="HEIGHT: 32px" vAlign="top" width="173">
													<asp:Label id="lblselectcard" key="acc_members_updateservices_lblselectcard" runat="server"></asp:Label></TD>
												<TD class="error" style="HEIGHT: 32px" width="9">*</TD>
												<TD style="HEIGHT: 32px" width="252">
													<asp:dropdownlist id="cmbCardNames" runat="server" Width="257px" CssClass="MTBOX">
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
												<TD style="HEIGHT: 32px" width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblcardholdername2" key="acc_members_updateservices_lblcardholdername" runat="server"></asp:Label></TD>
												<TD class="error" width="9">*</TD>
												<TD width="252">
													<asp:textbox id="txtCardHolderName" runat="server" Width="258px" CssClass="MTBOX" MaxLength="255"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblcardnumber2" key="acc_members_updateservices_lblcardnumber" runat="server"></asp:Label></TD>
												<TD class="error" width="9">*</TD>
												<TD width="252">
													<asp:textbox id="txtCardNumber" runat="server" Width="258px" CssClass="MTBOX" MaxLength="20"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblexpirydate2" key="acc_members_updateservices_lblexpirydate" runat="server"></asp:Label></TD>
												<TD class="error" width="9">*</TD>
												<TD width="252">
													<asp:dropdownlist id="cmbExpiryMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;
													<asp:dropdownlist id="cmbExpiryYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<P>&nbsp;</P>
													<P>
														<asp:Label id="lblcardaddress2" key="acc_members_updateservices_lblcardaddress" runat="server"></asp:Label></P>
												</TD>
												<TD class="error" width="9">*</TD>
												<TD width="252">
													<asp:textbox id="txtCardAddress" runat="server" Width="257px" CssClass="MTBOX" Height="73px"
														MaxLength="255" TextMode="MultiLine"></asp:textbox></TD>
												<TD width="109"></TD>
											</TR>
											<TR>
												<TD vAlign="top" width="173">
													<asp:Label id="lblsecuritycode2" key="acc_members_updateservices_lblsecuritycode" runat="server"></asp:Label></TD>
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
														key="acc_btnnext" runat="server" Cssclass="MBUTTON"></asp:button></TD>
												<TD width="109"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlCards" runat="server" Width="600px" Height="84px">
				<TABLE class="CONTENT" cellSpacing="1" cellPadding="0" width="100%" border="0">
					<TR>
						<TD>
							<TABLE class="CONTENT" width="100%" border="0">
								<TR>
									<TD class="acc_header_backgrounds" id="tdCardHeading" runat="server">&nbsp;AMEX 
										Card Information
									</TD>
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
													<asp:Label id="lblcardholder_name" key="acc_members_updateservices_lblcardholdername" runat="server"></asp:Label>:
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
													<asp:Label id="lblcard_number" key="acc_members_updateservices_lblcardnumber" runat="server"></asp:Label>:
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
													<asp:Label id="lblexpiry_date" key="acc_members_updateservices_lblexpirydate" runat="server"></asp:Label>:
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
													<asp:Label id="lblcard_address" key="acc_members_updateservices_lblcardaddress" runat="server"></asp:Label>:</TD>
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
													<asp:Label id="lblsecurity_code" key="acc_members_updateservices_lblsecuritycode" runat="server"></asp:Label>:
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
														<asp:Label id="lblchoosedaterange" key="acc_members_updateservices_lblchoosedaterange" runat="server"></asp:Label></STRONG></TD>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
													width="9"></TD>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
													width="252"></TD>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" borderColor="#7baee3"
													width="109"></TD>
											</TR>
											<TR id="trStartDate" runat="server">
												<TD id="tdStartDate" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 11px; BORDER-RIGHT-WIDTH: 1px"
													vAlign="top" borderColor="#7baee3" width="173" runat="server">
													<asp:Label id="lblstartdate" key="acc_members_updateservices_lblstartdate" runat="server"></asp:Label></TD>
												<TD class="error" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 11px; BORDER-RIGHT-WIDTH: 1px"
													borderColor="#7baee3" width="9">*</TD>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 11px; BORDER-RIGHT-WIDTH: 1px"
													borderColor="#7baee3" width="252">
													<asp:dropdownlist id="cmbStartMonth" runat="server" CssClass="MTBOX"></asp:dropdownlist>&nbsp;/
													<asp:dropdownlist id="cmbStartYear" runat="server" CssClass="MTBOX"></asp:dropdownlist></TD>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; HEIGHT: 11px; BORDER-RIGHT-WIDTH: 1px"
													borderColor="#7baee3" width="109"></TD>
											</TR>
											<TR id="trIssueNumber" runat="server">
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px" vAlign="top"
													borderColor="#7baee3" width="173">
													<asp:Label id="lblenddate" key="acc_members_updateservices_lblenddate" runat="server"></asp:Label></TD>
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
														key="acc_btnnext" runat="server" cssclass="acc_mbutton"></asp:button></TD>
												<TD width="109"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</asp:panel></td>
	</tr>
	<tr>
		<td><asp:label id="lblOrderNo" Runat="server" Visible="False"></asp:label><asp:label id="lblRetry" Runat="server" Visible="False"></asp:label><asp:label id="lblCustomerID" Runat="server" Visible="False"></asp:label><asp:label id="lblpostback_check" runat="server" Width="96px" Visible="False"></asp:label></td>
	</tr>
	<tr>
		<td align="center"><asp:button id="btnRetry" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
				runat="server" key="acc_btnretry" Visible="False" cssclass="acc_mbutton"></asp:button>&nbsp;<asp:button id="btnFinish" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
				runat="server" key="acc_btnfinish" Visible="False" cssclass="acc_mbutton"></asp:button>
			<asp:button id="btnServiceNext" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
				runat="server" key="acc_btnnext" Visible="False" cssclass="acc_mbutton" CommandName="Service"></asp:button></td>
	</tr>
</table>
<script>
	//this modification is done by Yousuf
	var structureCell;
	function ShowHide( ref ) 
	{ 			  
		var structure  = document.getElementById(ref);
		var structureHR  = document.getElementById(ref+'hr');
		if( ref.indexOf('pack')==0)
			structureCell= document.getElementById('ucServiceOrder_grdPackages__ctl3_packcell');
		else
			structureCell= document.getElementById('ucServiceOrder_grdProducts__ctl3_procell');
			
		if (structure.style.display =='none') 
		{ 
			structure.style.display =''; 
			structureCell.width = "45%";
			structureHR.innerText = '[Hide]';
		} 
		else 
		{ 
			structure.style.display ='none'; 
			structureCell.width = "10%";
			structureHR.innerText = '[Show]';
		} 
	} 
	//end modification
	
	function Checking(name,value)
	{
		var prodList=GetProducList(value);
		var chkBoxes,myChkBox,myChkBoxName;
		var index;		
		
		var selectedCheckBoxes=document.getElementsByName(name);		
		var selectedCheckBox=selectedCheckBoxes[0];	
		
		
		for(index=0;index<prodList.length;index++)
		{			
			myChkBoxName=GetCheckBoxName(prodList[index]);	
		
			if(myChkBoxName!=''){
				chkBoxes=document.getElementsByName(myChkBoxName);
				
				myChkBox=chkBoxes[0];
				if(myChkBoxName!=name){
					if (selectedCheckBox.checked){
						myChkBox.disabled=true;
						
					}else
					{
						myChkBox.disabled=false;				
					}
				}
			}
		}			
	}
	
	function GetCheckBoxName(prodName)
	{		
		var index;		
		
		for(index=0;index<checkBoxValues.length;index++)
		{				
			if(checkBoxValues[index]==prodName)
			{			
				return checkBoxNames[index];
			}
		}		
		return '';
	}//end of GetCheckBoxName
	
	function GetProducList(prodName)
	{
		var index,innerIndex;
				
		for(index=0;index<productName.length;index++)
		{	
			if(productName[index]==prodName)
			{		
				return productValues[index];
			}
		}		
		return '';
	}//end of GetProducList	
	
</script>
<% =productJavaScript %>
<% =checkBoxJavaScript %>
<% =defaultSelectionScript %>
