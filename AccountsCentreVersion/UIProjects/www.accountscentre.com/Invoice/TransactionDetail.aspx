<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ outputcache Duration="1" VaryByParam="None" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransactionDetail.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.TransactionDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Transaction Detail</title>
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
	</HEAD>
	<body id="htmlContentBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		runat="server">
		<form id="formTransactionDetail" method="post" runat="server">
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
						<table border="0" width="600" class="content" cellSpacing="0" cellPadding="0">
							<tr>
								<td width="50%">
									<a class="LINK_BLUE" href="/Members/default.aspx">Home</a>
								</td>
								<td align="right">
									<a class="LINK_BLUE" href="javascript:history.back();">&lt; Back</a></td>
							</tr>
							<tr>
								<td colspan="2" height="5"></td>
							</tr>
						</table>
						<!-- BEGIN OF ORDER DETAILS PANEL --><asp:panel id="pnlOrderDetails" Runat="server" Width="600">
							<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%">My Order 
										Details</TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center"><A name="orderBookMark"></A>
										<asp:DataGrid id="dgrdOrderDetails" Width="100%" Runat="server" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateColumn>
													<HeaderTemplate>
														<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
															<tr bgColor="SteelBlue">
																<td width="20%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Order No.</b></font></td>
																<td width="30%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Date</b></font>
																</td>
																<td width="30%" align="right" style="HEIGHT: 20px"><font color="AliceBlue"><b>Amount</b></font>
																</td>
																<td width="20%" align="center" style="HEIGHT: 20px"><font color="AliceBlue"><b>Download pdf</b></font></td>
															</tr>
														</table>
													</HeaderTemplate>
													<ItemTemplate>
														<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
															<tr>
																<td width="5">
																	<asp:ImageButton ID="imgBtnOrderNo" Runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' ImageUrl="/images/transactiondetailoptions.gif" OnClick="imgBtnOrderNo_Click">
																	</asp:ImageButton></td>
																<td width="17%">
																	<asp:LinkButton Runat="server" ID="lnkOrderNo" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' OnClick=lnkOrderNo_Click>
																		<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>
																	</asp:LinkButton>
																</td>
																<td width="30%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
																<td width="30%" align="right"><%# DataBinder.Eval(Container.DataItem,"Amount") %></td>
																<td width="20%" align="center">
																
																	<a href="#_self1" onclick="javascript:loadPDF(0,'<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>','N');"><img src="/images/download.gif" border=0></a>
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<!-- END OF ORDER DETAILS PANEL -->
						<!-- BEGIN OF INVOICE DETAILS PANEL --><asp:panel id="pnlInvoiceDetails" Runat="server" Width="600">
							<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%">My Invoice 
										Details</TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center"><A name="invoiceBookMark"></A>
										<asp:DataGrid id="dgrdInvoiceDetail" Width="100%" Runat="server" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateColumn>
													<HeaderTemplate>
														<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
															<tr bgColor="SteelBlue">
																<td width="20%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Order No.</b></font></td>
																<td width="24%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Date</b></font>
																</td>
																<td width="18%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Invoice No.</b></font>
																</td>
																<td width="20%" align="right" style="HEIGHT: 20px"><font color="AliceBlue"><b>Amount</b></font>
																</td>
																<td width="20%" align="center" style="HEIGHT: 20px"><font color="AliceBlue"><b>Download pdf</b></font></td>
															</tr>
														</table>
													</HeaderTemplate>
													<ItemTemplate>
														<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
															<tr>
																<td width="3%">
																	<asp:ImageButton ID="imgBtnInvoiceOrderNo" Runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>' ImageUrl="/images/transactiondetailoptions.gif" OnClick="imgBtnInvOrderNo_Click">
																	</asp:ImageButton></td>
																<td width="17%">
																	<asp:LinkButton Runat="server" ID="lnkInvoiceOrderNo" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>' OnClick=lnkInvOrderNo_Click>
																		<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>
																	</asp:LinkButton>
																</td>
																<td width="24%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
																<td width="18%"><%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %></td>
																<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Amount") %></td>
																<td width="20%" align="center">
																	<a href="#_self1" onclick="javascript:loadPDF('<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>','<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>','Y');"><img src="/images/download.gif" border=0></a>
																</td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<!-- END OF INVOICE DETAILS PANEL -->
						<!-- BEGIN OF SPECIFIC ORDER DETAILS PANEL --><asp:panel id="pnlOrder" Runat="server" Width="600">
							<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%">Order Info</TD>
								</TR>
								<TR>
									<TD>Order Number :
										<asp:Label id="lblOrderNo" Runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD height="10"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:DataGrid id="dgrdOrder" Width="100%" Runat="server" AutoGenerateColumns="False">
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
						</asp:panel>
						<!-- END OF SPECIFIC ORDER DETAILS PANEL -->
						<!-- BEGIN OF SPECIFIC Invoice PANEL --><asp:panel id="pnlInvoice" Runat="server" Width="600">
							<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%" colSpan="2">Invoice 
										Info</TD>
								</TR>
								<TR>
									<TD width="20%">Order Number</TD>
									<TD>:
										<asp:Label id="lblInvOrderNo" Runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD>Invoice Number</TD>
									<TD>:
										<asp:Label id="lblInvoiceNo" Runat="server"></asp:Label></TD>
								</TR>
								<TR>
									<TD colSpan="2" height="10"></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="2">
										<asp:DataGrid id="dgrdInvoice" Width="100%" Runat="server" AutoGenerateColumns="False">
											<Columns>
												<asp:TemplateColumn>
													<HeaderTemplate>
														<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
															<tr bgColor="SteelBlue">
																<td width="13%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Product Code</b></font></td>
																<td width="32%" style="HEIGHT: 20px"><font color="AliceBlue"><b>Product Name</b></font></td>
																<td width="15%" style="HEIGHT: 20px" align="right"><font color="AliceBlue"><b>Quantaty</b></font>
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
																<td width="13%"><%# DataBinder.Eval(Container.DataItem,"ProductCode") %></td>
																<td width="32%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
																<td width="15%" align="right"><%# DataBinder.Eval(Container.DataItem,"Quantaty") %></td>
																<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Price") %></td>
																<td width="20%" align="right"><%# DataBinder.Eval(Container.DataItem,"Amount") %></td>
															</tr>
														</table>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</asp:DataGrid></TD>
								</TR>
							</TABLE>
						</asp:panel>
						<!-- END OF SPECIFIC Ivnocie PANEL -->
						<table border="0" width="600" class="content" cellSpacing="0" cellPadding="0">
							<tr>
								<td width="50%">
									<a class="LINK_BLUE" href="/Members/default.aspx">Home</a>
								</td>
								<td align="right">
									<a class="LINK_BLUE" href="javascript:javascript:history.back();">&lt; Back</a></td>
							</tr>
							<tr>
								<td colspan="2" height="5"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</form>
		</TR></TBODY></TABLE>
		<script lang="javscript">
			function loadPDF(orderID,invoiceNo,chInvoice)
			{
				window.open('/Invoice/LoadPdf.aspx?orderID='+orderID+'&invoiceNo='+invoiceNo+'&chInvoice='+chInvoice,'OrderDetail','resizable=1,scrollbars=yes,hegiht=300,width=700');
				return false;
			}
		</script>
	</body>
</HTML>
