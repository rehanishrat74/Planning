<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="OrderDetail.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.OrderDetail"%>
<HTML>
	<HEAD>
		<title>Order Details</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<LINK href="../../Library/Styles/Order.css" type="text/css" rel="stylesheet"></LINK>
 	</HEAD>
	<body class="body" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<STYLE>.Header_invoice { FONT-WEIGHT: bold; FONT-SIZE: 18px; BACKGROUND-IMAGE: url(/images/infiniplan//bg3.gif); COLOR: #000000; BACKGROUND-REPEAT: repeat-x; FONT-STYLE: normal; FONT-FAMILY: Arial, Helvetica, sans-serif; TEXT-DECORATION: none }
			</STYLE>
			<div style="OVERFLOW: auto; WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; POSITION: static; HEIGHT: 100%; BORDER-BOTTOM-STYLE: none">
				<TABLE cellSpacing="0" cellPadding="0" width="100%">
					<TR>
						<TD class="Header_invoice" align="right" height="100">Order Details
						</TD>
					</TR>
					<TR>
						<TD height="19">
							<asp:Label id="lblMsg" runat="server" CssClass="errorHighlight" EnableViewState="False"></asp:Label></TD>
					</TR>
					<asp:Panel id="pnlOrderDetail" runat="server">
						<TR>
							<TD>
								<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
									<TR class="gridColumnHeader">
										<TD style="HEIGHT: 16px" width="20%"></TD>
										<TD style="HEIGHT: 16px" width="40%">Merchant</TD>
										<TD style="HEIGHT: 16px" width="40%">Customer</TD>
									</TR>
									<TR>
										<TD width="20%">Name:</TD>
										<TD width="40%">
											<asp:Label id="lblMerchant" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblCustomer" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
									</TR>
									<TR>
										<TD width="20%">Account Number:</TD>
										<TD width="40%">
											<asp:Label id="lblAccountNo" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblCCode" runat="server" EnableViewState="False" Width="99px"></asp:Label></TD>
									</TR>
									<TR>
										<TD width="20%">Login ID:</TD>
										<TD width="40%">
											<asp:Label id="lblMLoginID" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblLoginID" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
									</TR>
									<TR>
										<TD width="20%">Telephone:</TD>
										<TD width="40%">
											<asp:Label id="lblMTelephone" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblTelephone" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
									</TR>
									<TR>
										<TD width="20%">Email:</TD>
										<TD width="40%">
											<asp:Label id="lblMEmail" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblEmail" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
									</TR>
									<TR>
										<TD style="HEIGHT: 17px" width="20%">Address:</TD>
										<TD style="HEIGHT: 17px" width="40%">
											<asp:Label id="lblAddress" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD style="HEIGHT: 17px" width="40%">
											<asp:Label id="lblStreet" runat="server" EnableViewState="False" Height="16px"></asp:Label>
											<asp:Label id="lblTown" runat="server" EnableViewState="False" Height="16px"></asp:Label></TD>
									</TR>
									<TR>
										<TD width="20%">Country:</TD>
										<TD width="40%">
											<asp:Label id="lblMCountry" runat="server" EnableViewState="False" Width="186px" Height="16px"></asp:Label></TD>
										<TD width="40%">
											<asp:Label id="lblCountry" runat="server" EnableViewState="False" Width="120px" Height="13px"></asp:Label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD height="10"></TD>
						</TR>
						<TR>
							<TD>
								<TABLE width="100%">
									<TR class="gridColumnHeader">
										<TD colSpan="3">Order Details
										</TD>
									</TR>
									<TR>
										<TD>Order No</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblOrderNo" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Payment Process By</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblPayProcess" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Shipment Date</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblShipDate" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Merchant Note</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblMerchantNote" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Track ID</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblTrackID" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Invoice No</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblInvoiceNo" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Shipment Status</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblShipStatus" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Payment Status</TD>
										<TD>:</TD>
										<TD>
											<TABLE width="100%">
												<TR>
													<TD>
														<asp:Label id="lblPayStatus" runat="server" EnableViewState="False"></asp:Label></TD>
													<TD>
														<asp:Button id="btnRepay" runat="server" Enabled="False" Visible="False" Text="Repay"></asp:Button></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD>Shipment Charges</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblShipCharges" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD id="tdVATonShip" runat="server">VAT on Shipment Charges @</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="lblVATonShip" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
									<TR>
										<TD>Order Ref #</TD>
										<TD>:</TD>
										<TD>
											<asp:Label id="Label1" runat="server" EnableViewState="False" Width="100%"></asp:Label></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD height="30"></TD>
						</TR>
						<TR>
							<TD>
								<TABLE cellSpacing="0" cellPadding="0" width="100%">
									<TR>
										<TD>
											<asp:datagrid id="grdProducts" runat="server" EnableViewState="False" CssClass="gridTable" Width="100%"
												AutoGenerateColumns="False">
												<HeaderStyle CssClass="gridColumnHeader"></HeaderStyle>
												<Columns>
													<asp:BoundColumn Visible="False" DataField="prod_code" HeaderText="Product Code"></asp:BoundColumn>
													<asp:BoundColumn DataField="cart_product_name" HeaderText="Product Name">
														<HeaderStyle HorizontalAlign="Left" Width="250px"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="prodQty" HeaderText="Quantity">
														<HeaderStyle Width="50px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="prodUnitPrice" HeaderText="Unit Price">
														<HeaderStyle HorizontalAlign="Right" Width="90px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="prodDiscount" HeaderText="Discount">
														<HeaderStyle HorizontalAlign="Right" Width="65px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="prodTaxAmount" HeaderText="Tax">
														<HeaderStyle HorizontalAlign="Right" Width="50px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="prodAmount" HeaderText="Amount">
														<HeaderStyle HorizontalAlign="Right" Width="50px"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
											</asp:datagrid></TD>
									</TR>
									<TR>
										<TD height="10"></TD>
									</TR>
									<TR>
										<TD width="100%">
											<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
												<TR>
													<TD vAlign="top" align="left" width="60%"></TD>
													<TD style="FONT-WEIGHT: bold; BACKGROUND-COLOR: #cccccc" align="right" width="30%">Total 
														Amount&nbsp;&nbsp;
													</TD>
													<TD align="right" width="10">
														<asp:Label id="lblTotalAmount" runat="server" EnableViewState="False" Width="100px"></asp:Label></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="left" width="346"></TD>
													<TD style="FONT-WEIGHT: bold; WIDTH: 25%; BACKGROUND-COLOR: #cccccc" align="right">Shipment 
														Charges&nbsp;&nbsp;
													</TD>
													<TD align="right" width="100">
														<asp:Label id="lblTotalShipCharges" runat="server" EnableViewState="False" Width="100px"></asp:Label></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="left" width="346"></TD>
													<TD style="FONT-WEIGHT: bold; WIDTH: 20%; BACKGROUND-COLOR: #cccccc" align="right">Total&nbsp;&nbsp;
													</TD>
													<TD align="right" width="100">
														<asp:Label id="lblTotal" runat="server" EnableViewState="False" Width="100px"></asp:Label></TD>
												</TR>
												<TR>
													<TD align="left" colSpan="2"></TD>
												</TR>
												<TR>
													<TD colSpan="2">&nbsp;
													</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
					</asp:Panel></TABLE>
			</div>
			<!--
</asp:Content>
-->
		</form>
	</body>
</HTML>
