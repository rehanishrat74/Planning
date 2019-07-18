<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Profile.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MembersProfile" ValidateRequest="false" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ outputcache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Member Profile</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/main.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colspan="2" height="20%" runat="server">
							<include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
							<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD id="menuares" vAlign="top" align="center" width="180" runat="server">
											<include:serviceslist id="ucServicesList" runat="server"></include:serviceslist></TD>
										<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server">
											<input id="returnurl" type="hidden" name="returnurl" runat="server">
											<asp:panel id="pnlCustomerRegistration" runat="server" Height="59px" Width="608px">
												<TABLE class="CONTENT" style="WIDTH: 608px; HEIGHT: 372px" cellSpacing="0" cellPadding="0"
													width="608" border="0">
													<TR>
														<TD>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD id="msgarea" colSpan="2" runat="server"></TD>
																</TR>
																<TR>
																	<TD class="acc_header_backgrounds">Personal Profile</TD>
																</TR>
																<TR>
																	<TD align="left"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background" style="WIDTH: 600px; HEIGHT: 286px" cellSpacing="1"
																			cellPadding="2" width="600" bgColor="white" border="0">
																			<TR>
																				<TD width="5"></TD>
																				<TD vAlign="top" width="284"></TD>
																				<TD width="17">&nbsp;
																				</TD>
																				<TD class="error" width="17"></TD>
																				<TD width="100" colSpan="1" rowSpan="1"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184" height="17">
																					<DIV align="left">Complete Name
																					</DIV>
																				</TD>
																				<TD height="17">&nbsp;
																				</TD>
																				<TD class="error" height="17">*</TD>
																				<TD height="17">&nbsp;
																					<asp:textbox id="name" runat="server" Width="317px" MaxLength="55" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Street
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="street" runat="server" Width="317px" MaxLength="60" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Town / City</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="town" runat="server" Width="317px" MaxLength="30" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">State / County</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="cart_customer_state" runat="server" Width="317px" MaxLength="255" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Country
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:dropdownlist id="country" runat="server" Width="317px" CssClass="MTBOX" AutoPostBack="True">
																						<asp:ListItem Value="United Kingdom" Selected="True">United Kingdom</asp:ListItem>
																					</asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Post code
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="postcode" runat="server" MaxLength="30" CssClass="MTBOX"></asp:textbox><STRONG>
																						<asp:Literal id="litPPPostCode" runat="server" Text="(AA9 9AA)"></asp:Literal></STRONG></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Contact name
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">&nbsp;
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="cont_name" runat="server" Width="317px" MaxLength="255" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Telephone
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="telephone" runat="server" Width="317px" MaxLength="80" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Fax
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">&nbsp;
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="fax" runat="server" Width="317px" MaxLength="80" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Email
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">*
																				</TD>
																				<TD width="75%">&nbsp;
																					<asp:textbox id="cart_customer_email" runat="server" Width="317px" MaxLength="50" CssClass="MTBOX"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 4px"></TD>
																				<TD vAlign="top" width="184">
																					<DIV align="left">Notes
																					</DIV>
																				</TD>
																				<TD width="2%">&nbsp;
																				</TD>
																				<TD class="error" width="2%">&nbsp;
																				</TD>
																				<TD width="100%">&nbsp;
																					<asp:textbox id="cart_customer_notes" runat="server" Width="317px" MaxLength="255" CssClass="MTBOX"
																						TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																		</TABLE>
																		&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</asp:panel>
											<!--COMPANY PROFILE--><asp:panel id="pnlCompanyProfile" runat="server" Height="1108px" Width="600px">
												<TABLE class="CONTENT" width="100%" border="0">
													<TR>
														<TD class="acc_header_backgrounds">Company Profile</TD>
													</TR>
													<TR>
														<TD align="right" width="5">
															<TABLE class="text-outerborder-White_background" style="WIDTH: 592px; HEIGHT: 829px" cellSpacing="1"
																cellPadding="2" width="592" bgColor="white" border="0">
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px" width="964" colSpan="1" rowSpan="1">Company Name</TD>
																	<TD width="5" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:textbox id="compname" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Company Registration Number</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compregno" runat="server" Width="115px" MaxLength="8" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px" colSpan="1" rowSpan="1">Tax Reference ID</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																	<TD>&nbsp;
																		<asp:textbox id="CompTaxRefID" runat="server" Width="115px" CssClass="mtbox"></asp:textbox>&nbsp;<STRONG>(999 
																			99999 99999)</STRONG></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Director(s)</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compDirector" runat="server" Width="318px" Height="66px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Secretary(ies)</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compSec" runat="server" Width="318px" Height="54px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px" height="1"></TD>
																	<TD style="WIDTH: 964px" colSpan="4" height="1"></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px"><STRONG>Other Information</STRONG></TD>
																	<TD style="WIDTH: 42px" height="17"></TD>
																	<TD class="error" style="WIDTH: 8px" height="17"></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Registered Address</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:textbox id="compaddress" runat="server" Width="318px" Height="41px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Country</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:dropdownlist id="compcountry" runat="server" Width="317px" CssClass="MTBOX" AutoPostBack="True">
																			<asp:ListItem Value="United Kingdom" Selected="True">United Kingdom</asp:ListItem>
																		</asp:dropdownlist></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Postcode</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:textbox id="comppostcode" runat="server" Width="115px" MaxLength="30" CssClass="mtbox" DESIGNTIMEDRAGDROP="29"></asp:textbox>&nbsp;
																		<STRONG>
																			<asp:Literal id="litCPPostCode" runat="server" Text="(AA9 9AA)"></asp:Literal></STRONG></TD>
																	</STRONG></TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">City</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:textbox id="compcity" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">State/County</TD>
																	<TD style="WIDTH: 42px" height="17"></TD>
																	<TD class="error" style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="CompState" runat="server" Width="115px" MaxLength="30" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Phone Number</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD>&nbsp;
																		<asp:textbox id="compphone" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Fax Number</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compfax" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px; HEIGHT: 18px"></TD>
																	<TD style="WIDTH: 964px; HEIGHT: 18px">Email Address</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD style="HEIGHT: 18px">&nbsp;
																		<asp:textbox id="compemail" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Website (if any)</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compwebsite" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Contact Person</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compperson" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Designation</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compdesignation" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Contact Number</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compcontact" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">Line of business</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="complinbuss" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px"></TD>
																	<TD style="WIDTH: 964px">
																		<P>Brief description of business
																			<BR>
																			(Upto 250 characters)</P>
																	</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD>&nbsp;
																		<asp:textbox id="compdesbuss" runat="server" Width="317px" Height="40px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px; HEIGHT: 8px"></TD>
																	<TD style="WIDTH: 964px; HEIGHT: 8px">Number of employees</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD style="HEIGHT: 8px">&nbsp;
																		<asp:textbox id="compemps" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px; HEIGHT: 1px"></TD>
																	<TD style="WIDTH: 964px; HEIGHT: 1px">Work days in a week</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD style="WIDTH: 8px" height="17"></TD>
																	<TD style="HEIGHT: 1px">&nbsp;
																		<asp:textbox id="compwork" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px; HEIGHT: 7px"></TD>
																	<TD style="WIDTH: 964px; HEIGHT: 7px">Intended financial year end</TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																	<TD style="HEIGHT: 7px">&nbsp;
																		<asp:TextBox id="dtIntendedFinYear" Width="115px" CssClass="mtbox" Runat="server"></asp:TextBox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 2px; HEIGHT: 7px"></TD>
																	<TD style="WIDTH: 964px; HEIGHT: 7px"></TD>
																	<TD style="WIDTH: 42px" height="17">&nbsp;
																	</TD>
																	<TD class="error" style="WIDTH: 8px" height="17">&nbsp;</TD>
																	<TD style="WIDTH: 45px; HEIGHT: 7px" vAlign="top" align="left" colsspan="2">
																		<TABLE class="content" id="xTable1" style="WIDTH: 327px; HEIGHT: 24px" cellSpacing="0"
																			cellPadding="0" width="327" border="0">
																			<TR>
																				<TD style="HEIGHT: 18px" width="120"><STRONG>&nbsp;&nbsp;DD/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MM/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;YYYY
																					</STRONG>
																				</TD>
																				<TD style="WIDTH: 91px; HEIGHT: 18px" align="right"></TD>
																			</TR>
																		</TABLE>
																	</TD>
																</TR>
																<TR>
																	<TD class="text-outerborder-White_background-No_Border" align="right" colSpan="5">
																		<asp:Panel id="pnlExpress" runat="server" Width="590px" Height="58px" CssClass="text-outerborder-White_background-No_Border">
																			<TABLE class="text-outerborder-White_background-No_Border" id="Table2" width="100%" border="0">
																				<TR>
																					<TD style="WIDTH: 2px; HEIGHT: 22px"></TD>
																					<TD style="WIDTH: 839px; HEIGHT: 7px">VAT Number</TD>
																					<TD style="WIDTH: 34px" height="22"></TD>
																					<TD class="error" style="WIDTH: 17px" height="22"></TD>
																					<TD style="HEIGHT: 1px" align="left">&nbsp;
																						<asp:textbox id="txtvatnumber" runat="server" Width="115px" MaxLength="8" CssClass="mtbox" DESIGNTIMEDRAGDROP="841"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 2px; HEIGHT: 7px"></TD>
																					<TD style="WIDTH: 839px; HEIGHT: 7px">Company Logo</TD>
																					<TD style="WIDTH: 35px" height="17"></TD>
																					<TD class="error" style="WIDTH: 17px" width="17" height="17"></TD>
																					<TD style="HEIGHT: 7px">&nbsp;&nbsp;<INPUT class="mtbox" id="oFile" style="WIDTH: 328px; HEIGHT: 16px" type="file" size="35"
																							name="oFile" runat="server"></TD>
																				</TR>
																			</TABLE>
																		</asp:Panel></TD>
																</TR>
																<TR>
																	<TD class="text-outerborder-White_background-No_Border" align="right" colSpan="5">
																		<asp:Panel id="PnlPayroll" runat="server" Width="590px" CssClass="text-outerborder-White_background-No_Border"
																			ForeColor="Black">
																			<TABLE class="text-outerborder-White_background-No_Border" id="Table3" width="100%" border="0">
																				<TR>
																					<TD style="WIDTH: 4px; HEIGHT: 20px"></TD>
																					<TD style="WIDTH: 223px; HEIGHT: 20px">PAYE Reference Number</TD>
																					<TD style="WIDTH: 8px; HEIGHT: 20px" height="20">&nbsp;
																					</TD>
																					<TD class="error" style="WIDTH: 2px; HEIGHT: 20px" height="20"><FONT size="2">*</FONT></TD>
																					<TD style="HEIGHT: 20px" align="left">&nbsp;
																						<asp:textbox id="txtpayereference" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"
																							DESIGNTIMEDRAGDROP="2174"></asp:textbox>&nbsp;<FONT size="2">e.g A210</FONT></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 4px"></TD>
																					<TD style="WIDTH: 223px; HEIGHT: 7px">PAYE Office Number</TD>
																					<TD style="WIDTH: 8px" height="17"></TD>
																					<TD class="error" style="WIDTH: 2px" height="17"><FONT size="2">*</FONT></TD>
																					<TD style="HEIGHT: 1px">&nbsp;
																						<asp:textbox id="txtpayeofficeNo" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																							999</FONT></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 4px"></TD>
																					<TD style="WIDTH: 223px; HEIGHT: 7px">Account PAYE number</TD>
																					<TD style="WIDTH: 8px" height="17"></TD>
																					<TD class="error" style="WIDTH: 2px" height="17"><FONT size="2">*</FONT></TD>
																					<TD style="HEIGHT: 1px">&nbsp;
																						<asp:textbox id="txtaccountRefarenceNo" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																							999</FONT></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 4px; HEIGHT: 17px"></TD>
																					<TD style="WIDTH: 223px; HEIGHT: 17px">National Inssurance Number</TD>
																					<TD style="WIDTH: 8px; HEIGHT: 17px" height="17"></TD>
																					<TD class="error" style="WIDTH: 2px; HEIGHT: 17px" height="17"><FONT size="2">*</FONT></TD>
																					<TD style="HEIGHT: 17px">&nbsp;
																						<asp:textbox id="txtNINO" runat="server" Width="168px" MaxLength="9" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																							AB123456C</FONT></TD>
																				</TR>
																				<TR>
																					<TD style="WIDTH: 4px"></TD>
																					<TD style="WIDTH: 223px; HEIGHT: 7px">Account Office Reference</TD>
																					<TD style="WIDTH: 8px" height="17"></TD>
																					<TD class="error" style="WIDTH: 2px" height="17">*</TD>
																					<TD style="HEIGHT: 1px">
																						<P>&nbsp;
																							<asp:textbox id="txtAccountOfficeReference" runat="server" Width="168px" MaxLength="17" CssClass="mtbox"></asp:textbox><FONT size="2">&nbsp;e.g 
																								999PP1234567P</FONT></P>
																					</TD>
																				</TR>
																			</TABLE>
																		</asp:Panel></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR align="right">
														<TD>
															<asp:Button id="btnUpdate" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';"
																Width="69px" Text=" Update " Runat="server" cssclass="acc_mbutton"></asp:Button></TD>
													</TR>
												</TABLE>
											</asp:panel>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
						</td>
						<td id="rightbar" width="5%" runat="server"></td>
					</tr>
					<tr>
						<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
					</tr>
		</form>
		</TBODY></TABLE>
		<script>
function UpdateProfile(){
pform.action="profile.aspx?ACT=UPDATE"
pform.submit ();
}
		</script>
	</body>
</HTML>
