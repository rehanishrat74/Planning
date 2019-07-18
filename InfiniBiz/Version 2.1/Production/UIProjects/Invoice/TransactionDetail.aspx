<%@ Page Language="vb" AutoEventWireup="false" Codebehind="TransactionDetail.aspx.vb" Inherits="accounts.infinibiz.Web.TransactionDetail" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="serviceslist" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
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
		
		<script lang="javscript">
			function loadPDF(orderID,invoiceNo,chInvoice)
			{
				window.open('/Invoice/LoadPdf.aspx?orderID='+orderID+'&invoiceNo='+invoiceNo+'&chInvoice='+chInvoice,'OrderDetail','resizable=1,scrollbars=yes,hegiht=300,width=700');
				return false;
			}
		</script>
	</HEAD>
	<body id="htmlContentBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		runat="server">
		<form id="formTransactionDetail" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				bgcolor="ffffff" border="0">
				<tr id="trTopMain" runat="server">
					<td id="topbar" height="100" colSpan="2" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td vAlign="top">
												<table border="0" height="100%" class="content" cellpadding="3" cellspacing="3" width="100%">
								<tr height="100%">
									<td id="tdLeftMain" runat="server" valign="top" align="center" width="180" CLASS='objtd' height="100%">
										<include:serviceslist id="ucServicesList" runat="server"></include:serviceslist>
									</td>
									<td valign="top" CLASS='objtd' height="100%" width="100%">
										<!-- BEGIN OF ORDER DETAILS PANEL -->
										<div height="100%" class="scrolldiv">
										<asp:panel id="pnlOrderDetails" Runat="server" Width="100%">
										<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<tr>
														<td vAlign="top"><font size="4">
																<% = CompanyName %>
															</font>
														</td>
													</tr>
													<tr>
														<td height="10px">
														</td>
													</tr>
													<TR>
														<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%" runat="server"
															key="acc_invoice_ttmyorderdetail"></TD>
													</TR>
													<TR>
														<TD height="10px"></TD>
													</TR>
													<TR>
														<TD align="center"><A name="orderBookMark"></A>
															<asp:DataGrid id="dgrdOrderDetails" Width="100%" Runat="server" AutoGenerateColumns="False">
																<Columns>
																	<asp:TemplateColumn>
																		<HeaderTemplate>
																			<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
																				<tr class="acc_header_backgrounds">
																					<td width="30%" style="HEIGHT: 20px" runat="server" key="acc_invoice_ttorderno" ID="Td1">
																					</td>
														</TD>
														<td width="40%" style="HEIGHT: 20px" runat="server" key="acc_ttdate" ID="Td2">
														</td>
														<td width="30%" align="center" style="HEIGHT: 20px" runat="server" key="acc_ttdownloadpdf"
															ID="Td4"></td>
													</TR>
											</TABLE>
																	</HeaderTemplate>
																	<ItemTemplate>
												<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
													<tr>
														<td width="5%">
															<asp:ImageButton ID="imgBtnOrderNo" Runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' ImageUrl="/infiniimages/transactiondetailoptions.gif" OnClick="imgBtnOrderNo_Click">
															</asp:ImageButton>
														</td>
														<td width="25%">
															<asp:LinkButton Runat="server" ID="lnkOrderNo" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' OnClick=lnkOrderNo_Click>
																<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>
															</asp:LinkButton>
														</td>
														<td width="40%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
														<td width="30%" align="center"><a href="#_self2" onclick="javascript:loadPDF(0,'<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>','N');"><img src="/infiniimages/download.gif" border="0"></a></td>
									</td>
								</tr>
							</table>
						</ItemTemplate> </asp:TemplateColumn> </Columns> </asp:DataGrid>
					</td>
				</tr>
			</table>
			</asp:panel> 
			
			<!-- END OF ORDER DETAILS PANEL -->
			<!-- BEGIN OF INVOICE DETAILS PANEL -->
			<!--<asp:panel id="pnlInvoiceDetails" Runat="server" Width="600">
										<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%" runat="server"
													key="acc_invoice_ttmyinvoicedeatils"></TD>
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
																		<tr class="acc_header_backgrounds" bgColor="SteelBlue">
																			<td width="20%" style="HEIGHT: 20px" runat="server" key="acc_invoice_ttorderno" ID="Td5"></td>
																			<td width="24%" style="HEIGHT: 20px" runat="server" key="acc_ttdate" ID="Td6">
																			</td>
																			<td width="18%" style="HEIGHT: 20px" runat="server" key="acc_ttinvoiceno" ID="Td7">
																			</td>
																			<td width="20%" align="right" style="HEIGHT: 20px" runat="server" key="acc_ttamount" ID="Td8">
																			</td>
																			<td width="20%" align="center" style="HEIGHT: 20px" runat="server" key="acc_ttdownloadpdf" ID="Td9"></td>
																		</tr>
																	</table>
																</HeaderTemplate>
																<ItemTemplate>
																	<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
																		<tr>
																			<td width="1">
																				<asp:ImageButton ID="imgBtnInvoiceOrderNo" Runat="server" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>' ImageUrl="/infiniimages/transactiondetailoptions.gif" OnClick="imgBtnInvOrderNo_Click">
																				</asp:ImageButton></td>
																			<td width="17.5%">
																				<asp:LinkButton Runat="server" ID="lnkInvoiceOrderNo" CommandName='<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>' OnClick=lnkInvOrderNo_Click>
																					<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>
																				</asp:LinkButton>
																			</td>
																			<td width="24%"><%# DataBinder.Eval(Container.DataItem,"OrderDate") %></td>
																			<td width="18%"><%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %></td>
																			<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"Amount"),2,0,0,0) %></td>
																			<td width="20%" align="center"><a href="#_self1" onclick="javascript:loadPDF('<%# DataBinder.Eval(Container.DataItem,"OrderNo") %>','<%# DataBinder.Eval(Container.DataItem,"InvoiceNo") %>','Y');"><img src="/infiniimages/download.gif" border=0></a>
																			</td>
																		</tr>
																	</table>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
										</TABLE>
									</asp:panel>-->
			<!-- END OF INVOICE DETAILS PANEL -->
			<!-- BEGIN OF SPECIFIC ORDER DETAILS PANEL -->
			<asp:panel id="pnlOrder" Runat="server" Width="100%">
				<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD class="acc_header_backgrounds" id="Td10" style="HEIGHT: 20px" width="100%" runat="server"
							key="acc_invoice_ttorderinfo"></TD>
					<TR>
						<TD>
							<asp:Label id="lblordernum2" Runat="server" key="acc_invoice_lblordernumber"></asp:Label>:
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
												<tr class="acc_header_backgrounds" bgColor="SteelBlue">
													<td width="80%" style="HEIGHT: 20px" runat="server" key="acc_ttproductname" ID="Td11"></td>
													<td width="20%" style="HEIGHT: 20px" align="center" runat="server" key="acc_ttquantity"
														ID="Td12">
													</td>
													<!--<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttprice"
																	ID="Td13">
																</td>
																<td width="20%" align="right" style="HEIGHT: 20px" runat="server" key="acc_ttamount"
																	ID="Td14">
																</td>-->
												</tr>
											</table>
										</HeaderTemplate>
										<ItemTemplate>
											<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
												<tr>
													<td width="80%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
													<td width="20%" align="center"><%# DataBinder.Eval(Container.DataItem,"Quantaty") %></td>
													<!--<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"UnitPrice"),2,0,0,0) %></td>
																			<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"ProdAmount"),2,0,0,0) %></td>-->
												</tr>
											</table>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:DataGrid></TD>
					</TR>
				</TABLE>
			</asp:panel>
			</div>
			<!-- END OF SPECIFIC ORDER DETAILS PANEL -->
			<!-- BEGIN OF SPECIFIC Invoice PANEL -->
			<!--<asp:panel id="pnlInvoice" Runat="server" Width="600">
										<TABLE class="content" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%" colSpan="2" runat="server"
													key="acc_invoice_ttinvoiceinfo" ID="Td15"></TD>
											</TR>
											<TR>
												<TD width="20%">
													<asp:Label id="lblordernum" Runat="server" key="acc_invoice_lblordernumber"></asp:Label></TD>
												<TD>:
													<asp:Label id="lblInvOrderNo" Runat="server"></asp:Label></TD>
											</TR>
											<TR>
												<TD>
													<asp:Label id="lblinvoicenum" Runat="server" key="acc_invoice_lblinvoicenumber"></asp:Label></TD>
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
																		<tr class="acc_header_backgrounds" bgColor="SteelBlue">
																			<td width="13%" style="HEIGHT: 20px" runat="server" key="acc_ttproductcode" ID="Td16"></td>
																			<td width="32%" style="HEIGHT: 20px" runat="server" key="acc_ttproductname" ID="Td17"></td>
																			<td width="15%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttquantity" ID="Td18">
																			</td>
																			<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttprice" ID="Td19">
																			</td>
																			<td width="20%" align="right" style="HEIGHT: 20px" runat="server" key="acc_ttamount" ID="Td20">
																			</td>
																		</tr>
																	</table>
																</HeaderTemplate>
																<ItemTemplate>
																	<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
																		<tr>
																			<td width="13%"><%# DataBinder.Eval(Container.DataItem,"ProductCode") %></td>
																			<td width="32%"><%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
																			<td width="15%" align="right"><%# FormatNumber(DataBinder.Eval(Container.DataItem,"Quantaty"),2,0,0,0)  %></td>
																			<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"Price"),2,0,0,0)  %></td>
																			<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"Amount"),2,0,0,0)  %></td>
																		</tr>
																	</table>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:DataGrid></TD>
											</TR>
										</TABLE>
									</asp:panel>-->
			<!-- END OF SPECIFIC Ivnocie PANEL -->
			<table border="0" width="100%" class="content" cellSpacing="0" cellPadding="0">
				<tr>
					<td align="right" width="100%">
						<a class="LINK_BLUE" href="javascript:javascript:history.back();" runat="server" key="acc_aback"
							id="ID1"></a>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="5"></td>
				</tr>
			</table>
			</td> </tr> </table> </TD></TR>
			<tr id="trBottomMain" runat="server">
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
			</tr>
			</TBODY></TABLE>
		</form>
		</TR></TBODY></TABLE>
	</body>
</HTML>
