<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdatePaymentInfoDetail.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.UpdatePaymentInfoDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>Update Payment Information Detail</title>
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
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE class="content" cellSpacing="0" cellPadding="0" width="75%" border="0" align="center">
				<TR>
					<TD class="acc_header_backgrounds" style="HEIGHT: 20px" width="100%" runat="server"
						key="acc_invoice_ttorderdetail"></TD>
				</TR>
				<TR>
					<TD><asp:Label id="lblordernumber" Runat="server" key="acc_invoice_lblordernumber"></asp:Label>
						<asp:Label id="lblOrderNo" Runat="server"></asp:Label></TD>
				</TR>
				<TR>
					<TD height="10"></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:DataGrid id="dgrdOrder" Runat="server" Width="100%" AutoGenerateColumns="False">
							<Columns>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
											<tr class="acc_header_backgrounds" bgColor="SteelBlue">
											<td width="32%" style="HEIGHT: 20px" runat="server" key="acc_ttproductname" ID="Td17"></td>
											<td width="15%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttquantity" ID="Td18"></td>
											<td width="20%" style="HEIGHT: 20px" align="right" runat="server" key="acc_ttprice" ID="Td19"></td>
										    <td width="20%" align="right" style="HEIGHT: 20px" runat="server" key="acc_ttamount" ID="Td20"></td>
											</tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<table border="0" width="100%" cellpadding="0" cellspacing="0" class="content">
											<tr>
												<td width="40%">&nbsp;<%# DataBinder.Eval(Container.DataItem,"ProductName") %></td>
												<td width="20%" align="right"><%# FormatNumber(DataBinder.Eval(Container.DataItem,"Quantaty"),0,0,0,0) %></td>
												<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"UnitPrice"),2,0,0,0) %></td>
												<td width="20%" align="right">£&nbsp;<%# FormatNumber(DataBinder.Eval(Container.DataItem,"ProdAmount"),2,0,0,0) %>&nbsp;</td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:DataGrid></TD>
				</TR>
				<tr>
					<td align="center"><input type="submit" runat="server" key="acc_message_btnclose" value="Close" onclick='javascript:window.close();'></td>
				</tr>
			</TABLE>
		</form>
	</body>
</HTML>
