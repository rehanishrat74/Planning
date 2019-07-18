<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ProductActivation.aspx.vb" Inherits="accounts.infinibiz.Web.ProductActivation" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>accounts.infinibiz.com - Product Activation</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
		<script>
			function EnableChk(cname)
				{				
					var ctrl = document.getElementById(cname);
					ctrl.checked = true
				}
			function Hide()
				{
					var obj = document.getElementById("tblActivateButtons");
					//alert(obj);
					obj.style.display='none';
				}
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				bgColor="#ffffff" border="0">
				<tr>
					<td id="topbar" colSpan="2" height="100" runat="server"><include:topbar id="idxTopBar1" runat="server"></include:topbar></td>
				</tr>
				<tr>
					<td id="contentarea" vAlign="top" align="center" width="100%" runat="server">
						<div class="scrolldiv" style="HEIGHT: 100%">
							<table class="CONTENT" width="600">
								<tr id="trMessage" runat="server">
									<td>
										<TABLE class="text-outerborder-White_background" width="100%">
											<TR>
												<td>
													<asp:label id="lblMessage" Runat="server" CssClass="rss_error_text" EnableViewState="False"
														Width="95%" ForeColor="#0000cc"></asp:label>
													<asp:label id="lblError" Runat="server" CssClass="rss_error_text" EnableViewState="False" Width="95%"></asp:label>
												</td>
											</TR>
										</TABLE>
									</td>
								</tr>
								<tr>
									<td><asp:panel id="pnlCompanyInformation" Runat="server" BorderWidth="1">
											<TABLE class="text-outerborder-White_background" width="100%">
												<TR>
													<TD class="acc_header_backgrounds" colSpan="2">Step 1: Company Information
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">
														<asp:RadioButton id="rb1" Runat="server" Checked="True" Text="Select Company Name" GroupName="CompanyName"></asp:RadioButton></TD>
													<TD width="50%">
														<asp:ListBox id="lstCompanyName" Width="95%" Runat="server" BorderStyle="Groove" SelectionMode="Single"
															Rows="5"></asp:ListBox></TD>
												</TR>
												<TR>
													<TD width="50%">
														<asp:RadioButton id="rb2" Runat="server" Text="Enter New Company Name" GroupName="CompanyName"></asp:RadioButton></TD>
													<TD width="50%">
														<asp:TextBox id="txtCompanyName" Width="95%" Runat="server"></asp:TextBox></TD>
												</TR>
												<TR id="trAPIResellerDomainInfo" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label101" Runat="server">Domain Name</asp:label></TD>
													<TD width="50%">
														<TABLE cellSpacing="0" cellPadding="0" width="95%">
															<TR>
																<TD width="100%">
																	<asp:TextBox id="txtAPIResellerURL" Width="100%" Runat="server"></asp:TextBox></TD>
																<TD>
																	<asp:Label id="Label11" runat="server" ForeColor="Gray">(www.yourdomain.com)</asp:Label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR id="trCurrency" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label1" Runat="server">Select Currency</asp:label></TD>
													<TD width="50%">
														<asp:DropDownList id="ddlCurrencyDB" Runat="server"></asp:DropDownList></TD>
												</TR>
												<TR id="trResellerQuestion" runat="server">
													<TD width="50%" colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:Label id="lblemail" runat="server" Text="Do you want to authorize us to contact your customer for email reminders:"></asp:Label>
														<asp:DropDownList id="ddlemail" runat="server">
															<asp:ListItem Selected="True" Value="1">Yes</asp:ListItem>
															<asp:ListItem Value="0">No</asp:ListItem>
														</asp:DropDownList></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<tr>
									<td><asp:panel id="pnlIShopDomainInfo" Runat="server" BorderWidth="1" Visible="False">
											<TABLE class="text-outerborder-White_background" width="100%">
												<TR>
													<TD class="acc_header_backgrounds" colSpan="2">Step 2: Domain Information</TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">
														<TABLE width="100%">
															<TR>
																<TD>
																	<asp:RadioButton id="rbRegDomainInfo" Runat="server" Checked="True" Text="Register My Domain" GroupName="DomainName"></asp:RadioButton></TD>
																<TD align="right">
																	<asp:Label id="label121" Runat="server">www.</asp:Label></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="50%">
														<TABLE width="95%">
															<TR vAlign="top">
																<TD width="100%">
																	<asp:TextBox id="txtRegDomainName" Width="100%" Runat="server" ToolTip="Only Domain Name Required"></asp:TextBox></TD>
																<TD>.&nbsp;
																	<asp:DropDownList id="ddlExtention" Runat="server">
																		<asp:ListItem Value="com" Selected="True">com</asp:ListItem>
																		<asp:ListItem Value="net">net</asp:ListItem>
																		<asp:ListItem Value="org">org</asp:ListItem>
																		<asp:ListItem Value="euc.eu">euc.eu</asp:ListItem>
																		<asp:ListItem Value="eu">eu</asp:ListItem>
																		<asp:ListItem Value="co.uk">co.uk</asp:ListItem>
																	</asp:DropDownList></TD>
																<TD>
																	<asp:ImageButton id="btnCheckAvailability" Runat="server" ToolTip="Check Domain Availability" ImageUrl="..\images\search.jpg"></asp:ImageButton><%-- <asp:Button id="btnCheckAvailability" CssClass="acc_mbuttonon" Runat="server" Text="Check!"
																		ToolTip="Check Domain Availability"></asp:Button> --%></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 15px"></TD>
												</TR>
												<TR>
													<TD width="50%">
														<TABLE width="100%">
															<TR>
																<TD>
																	<asp:RadioButton id="rbAlreadyRegDomainName" Runat="server" Text="Domain Already Registered" GroupName="DomainName"></asp:RadioButton></TD>
																<TD align="right">
																	<asp:Label id="Label14" Runat="server" Visible="false">www.</asp:Label></TD>
															</TR>
														</TABLE>
													</TD>
													<TD width="50%">
														<TABLE width="95%">
															<TR>
																<TD width="100%">
																	<asp:TextBox id="txtAlreadyRegDomainName" Width="95%" Runat="server"></asp:TextBox></TD>
																<TD>
																	<asp:Label id="Label12" runat="server" ForeColor="Gray">(www.yourdomain.com)</asp:Label></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<tr>
									<td><asp:panel id="pnlPaymentProcessor" Runat="server" BorderWidth="1">
											<TABLE class="text-outerborder-White_background" width="100%">
												<TR>
													<TD class="acc_header_backgrounds" colSpan="2">Step 3: Payment Processor
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label4" Runat="server">Payment Process By</asp:label></TD>
													<TD width="50%">
														<asp:DropDownList id="ddlPaymentProcessBy" Runat="server" AutoPostBack="True"></asp:DropDownList></TD>
												</TR>
												<TR id="trPaymentProcessorID" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="lblPaymentProcessorID" Runat="server">[PaymentProcessorName] ID</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtPaymentProcessorID" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR id="trPaymentProcessorPassword" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="lblPaymentProcessorPassword" Runat="server">[PaymentProcessorName] Password</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtPaymentProcessorPassword" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR id="trPaymentProcessorCertificate" vAlign="top" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="lblPaymentProcessorCertificate" Runat="server">[PaymentProcessorName] Certificate</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtPaymentProcessorCertificate" Width="95%" Runat="server" TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR id="trPaymentProcessorCurrency" vAlign="top" runat="server">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="lblPaymentProcessorCurrency" Runat="server">[PaymentProcessorName] Currency</asp:label></TD>
													<TD width="50%">
														<asp:DropDownList id="ddlPaymentProcessorCurrency" Runat="server"></asp:DropDownList>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<tr>
									<td align="center"><asp:button id="btnNext" Runat="server" CssClass="acc_mbuttonon" Text="Next"></asp:button></td>
								</tr>
								<tr>
									<td><asp:panel id="pnlBank_OR_CheckDetail" Runat="server" BorderWidth="1" Visible="False">
											<TABLE class="text-outerborder-White_background" width="100%">
												<TR>
													<TD class="acc_header_backgrounds">Step 4: Bank/Cheque Detail
													</TD>
													<TD class="acc_header_backgrounds" align="right">
														<DIV class="text-outerborder-White_background"><I>(Optional)</I>
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label2" Runat="server">Cheque Payable to</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtChequePayableTo" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label3" Runat="server">Cheque Address</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtChequeAddress" Width="95%" Runat="server" TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<tr>
									<td><asp:panel id="pnlBankTransferDetail" Runat="server" BorderWidth="1" Visible="False">
											<TABLE class="text-outerborder-White_background" width="100%">
												<TR>
													<TD class="acc_header_backgrounds">Step 5: Bank Transfer Detail
													</TD>
													<TD class="acc_header_backgrounds" align="right">
														<DIV class="text-outerborder-White_background"><I>(Optional)</I>
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label5" Runat="server">Bank Name</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBankName" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label6" Runat="server">Bank Address</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBankAddress" Width="95%" Runat="server" TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label9" Runat="server">Bank Account Name</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBankAccountName" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label7" Runat="server">Bank Account Number</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBankAccountNumber" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label8" Runat="server">Bank Sort Code</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBankSortCode" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label19" Runat="server">BIC</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtBIC" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label110" Runat="server">IBAN No</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtIBANNo" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR vAlign="top">
													<TD width="50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<asp:label id="Label111" Runat="server">Swift code</asp:label></TD>
													<TD width="50%">
														<asp:textbox id="txtSwiftCode" Width="95%" Runat="server"></asp:textbox></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
								<tr>
									<td>
										<asp:panel id="pnlBankNote" Runat="server" BorderWidth="1" Visible="False">
											<TABLE cellSpacing="5" cellPadding="5">
												<TR>
													<TD vAlign="top">Note :
													</TD>
													<TD>This information is required to merchants' customers who want to pay either 
														through direct bank transfer or cheque.
													</TD>
												</TR>
											</TABLE>
										</asp:panel>
									</td>
								</tr>
								<tr>
									<td align="center">
										<table id="tblActivateButtons">
											<tr>
												<td><asp:button id="btnBack" Runat="server" CssClass="acc_mbuttonon" Text="Back" Visible="False"></asp:button></td>
												<td><asp:button id="btnActivate" Runat="server" CssClass="acc_mbuttonon" Text="Activate" Visible="False"></asp:button></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td align="center">
										<DIV id="waitmsg" style="DISPLAY: none" name="waitmsg">Please wait, your service is 
											being activated .....</DIV>
									</td>
								</tr>
								<tr>
									<td align="center">
										<SCRIPT language="javascript" src="..\Library\javascript\xp_progress.js"></SCRIPT>
										<SCRIPT>
											var bar1= createBar(300,15,'white',1,'black','gray',85,7,3,"");
											bar1.hideBar();
										</SCRIPT>
									</td>
								</tr>
								<tr>
									<td align="center">
										<asp:panel id="pnlSuccess" runat="server" Width="500" BorderWidth="1" HorizontalAlign="Center">
											<TABLE id="Table1" cellSpacing="5" cellPadding="5" width="100%" border="0">
												<TR>
													<TD vAlign="top" align="left" colSpan="2"><%-- <asp:Label id="lblwaitmsg" runat="server" Width="100%" CssClass="link_text">Congratulation! Your [SERVICENAME] has been activated. You can now use your service.</asp:Label> --%>
														<asp:Label id="lblwaitmsg" runat="server" Width="100%" CssClass="link_text">Congratulation! Your service has been activated. You can now use your service.</asp:Label></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
												<TR>
													<TD vAlign="top" align="center" width="50%">
														<asp:Button id="btnStartAC" runat="server" CssClass="acc_mbuttonon" Text="Start using Accounting Service"></asp:Button>
														<asp:Button id="btnGotoResellerSystem" runat="server" CssClass="acc_mbuttonon" Text="Start using Reseller System"
															Visible="False"></asp:Button></TD>
													<TD vAlign="top" align="center" width="50%">
														<asp:Button id="btnMyAccount" runat="server" CssClass="acc_mbuttonon" Text="My Account"></asp:Button></TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 7px" colSpan="2"></TD>
												</TR>
											</TABLE>
										</asp:panel></td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td id="bottombar" colSpan="2" height="29" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
				</tr>
			</table>
		</form>
		<script language="javascript">
			function wait()
			{
				var obj = document.getElementById("waitmsg")
				obj.style.display= "";
				bar1.showBar();
			}
			function _HideBar()
			{
				var obj = document.getElementById("waitmsg")
				obj.style.display= "none";
				bar1.hideBar();
			}
		</script>
	</body>
</HTML>
