<%@ Register TagPrefix="uc1" TagName="ServicesList" Src="../Library/components/ServicesList.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Profile.aspx.vb" Inherits="accounts.infinibiz.Web.MembersProfile" ValidateRequest="false" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ outputcache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Member Profile</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" border="0"
				bgcolor="ffffff" width="100%">
				<TBODY>
					<tr id="trTopMain" runat="server">
						<td id="topbar" colSpan="2" height="100" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
														<TABLE class="content" id="Table1" height="100%" cellSpacing="3" cellPadding="3" width="100%">
									<TR>
										<TD id="tdLeftMain" runat="server" vAlign="top" align="left" width="5%" CLASS='objtd'>
											<uc1:ServicesList id="ServicesList1" runat="server"></uc1:ServicesList>
										</TD>
										<TD id="membersarea" vAlign="top" align="center" width="100%" runat="server" CLASS='objtd'>
										<div class="scrolldiv" style="height:100%">
											<input id="returnurl" type="hidden" name="returnurl" runat="server">
											<br>
											<asp:panel id="pnlCustomerRegistration" runat="server" Width="600px">
												<TABLE class="CONTENT" style="WIDTH: 100%" cellSpacing="0" cellPadding="0">
													<TR>
														<TD CLASS='objtd'>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD id="msgarea" colSpan="2" runat="server"></TD>
																</TR>
																<TR>
																	<TD class="acc_header_backgrounds" id="Td1" runat="server" key="acc_members_profile_ttpersonalprofile"
																		NAME="Td1"></TD>
																</TR>
																<TR>
																	<TD align="left"></TD>
																</TR>
																<TR>
																	<TD>
																		<TABLE class="text-outerborder-White_background-No_Border" style="WIDTH: 600px; HEIGHT: 286px" cellSpacing="1"
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
																					<DIV align="left">
																						<asp:Label id="lblCompletename" runat="server" key="acc_members_profile_lblcompletename"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblstreet" runat="server" key="acc_members_profile_lblstreet"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblcity" runat="server" key="acc_members_profile_lblcity"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblstate" runat="server" key="acc_members_profile_lblstate"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblcountry" runat="server" key="acc_members_profile_lblcountry"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblpostcode" runat="server" key="acc_members_profile_lblpostcode"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblcontactname" runat="server" key="acc_members_profile_lblcontactname"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lbltelephone" runat="server" key="acc_members_profile_lbltelephone"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblfax" runat="server" key="acc_members_profile_lblfax"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblemail" runat="server" key="acc_lblemail"></asp:Label></DIV>
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
																					<DIV align="left">
																						<asp:Label id="lblnotes" runat="server" key="acc_members_profile_lblnotes"></asp:Label></DIV>
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
											<br>
											<!--COMPANY PROFILE-->
											<asp:panel id="pnlCompanyProfile" runat="server" Width="608px">
												<table width="100%" height="100%" cellspacing="0" cellpadding="0">
													<tr>
														<td CLASS='objtd'>
															<TABLE class="CONTENT" width="100%" border="0">
																<TR>
																	<TD class="acc_header_backgrounds" id="Td2" runat="server" key="acc_members_profile_ttcompanyprofile"
																		NAME="Td2"></TD>
																</TR>
																<TR>
																	<TD align="right" width="5">
																		<TABLE class="text-outerborder-White_background-No_Border" style="WIDTH: 592px; HEIGHT: 829px" cellSpacing="1"
																			cellPadding="2" width="592" bgColor="white" border="0">
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px" width="964" colSpan="1" rowSpan="1">
																					<asp:Label id="lblcompanyname" runat="server" key="acc_members_profile_lblcompanyname"></asp:Label></TD>
																				<TD width="5" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																				<TD>&nbsp;
																					<asp:textbox id="compname" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblcompanyregistrationnumber" runat="server" key="acc_members_profile_lblcompanyregistrationnumber"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compregno" runat="server" Width="115px" MaxLength="8" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px" colSpan="1" rowSpan="1">
																					<asp:Label id="lbltaxreferenceID" runat="server" key="acc_members_profile_lbltaxreferenceID"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																				<TD>&nbsp;
																					<asp:textbox id="CompTaxRefID" runat="server" Width="115px" CssClass="mtbox"></asp:textbox>&nbsp;<STRONG>(999 
																						99999 99999)</STRONG></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lbldirectors" runat="server" key="acc_members_profile_lbldirectors"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compDirector" runat="server" Height="66px" Width="318px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblsecretary" runat="server" key="acc_members_profile_lblsecretary"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17"><%If CPUKBased = True Then%>*<%End If%></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compSec" runat="server" Height="54px" Width="318px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px" height="1"></TD>
																				<TD style="WIDTH: 964px" colSpan="4" height="1"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px"><STRONG>
																						<asp:Label id="lblotherinformation" runat="server" key="acc_members_profile_lblotherinformation"></asp:Label></STRONG></TD>
																				<TD style="WIDTH: 42px" height="17"></TD>
																				<TD class="error" style="WIDTH: 8px" height="17"></TD>
																				<TD></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblregisteredaddress" runat="server" key="acc_members_profile_lblregisteredaddress"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																				<TD>&nbsp;
																					<asp:textbox id="compaddress" runat="server" Height="41px" Width="318px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 12px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 12px">
																					<asp:Label id="lblcountry2" runat="server" key="acc_members_profile_lblcountry"></asp:Label></TD>
																				<TD style="WIDTH: 42px; HEIGHT: 12px" height="12">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px; HEIGHT: 12px" height="12">*</TD>
																				<TD style="HEIGHT: 12px">&nbsp;
																					<asp:dropdownlist id="compcountry" runat="server" Width="317px" CssClass="MTBOX" AutoPostBack="True">
																						<asp:ListItem Value="United Kingdom" Selected="True">United Kingdom</asp:ListItem>
																					</asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 16px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 16px">
																					<asp:Label id="lblCurrency" runat="server" Text="Currency"></asp:Label></TD>
																				<TD style="WIDTH: 42px; HEIGHT: 16px" height="16">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px; HEIGHT: 16px" height="16">*</TD>
																				<TD style="HEIGHT: 16px">&nbsp;
																					<asp:dropdownlist id="compCurrency" runat="server" Width="317px" CssClass="MTBOX" Font-Names="Arial"></asp:dropdownlist></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblpostcode2" runat="server" key="acc_members_profile_lblpostcode"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																				<TD>&nbsp;
																					<asp:textbox id="comppostcode" runat="server" Width="115px" MaxLength="30" CssClass="mtbox" DESIGNTIMEDRAGDROP="29"></asp:textbox>&nbsp;
																					<STRONG>
																						<asp:Literal id="litCPPostCode" runat="server" Text="(AA9 9AA)"></asp:Literal></STRONG></TD>
																				</STRONG></TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 21px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 21px">
																					<asp:Label id="lblcity2" runat="server" key="acc_members_profile_lblcity"></asp:Label></TD>
																				<TD style="WIDTH: 42px; HEIGHT: 21px" height="21">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px; HEIGHT: 21px" height="21">*</TD>
																				<TD style="HEIGHT: 21px">&nbsp;
																					<asp:textbox id="compcity" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblstate2" runat="server" key="acc_members_profile_lblstate"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17"></TD>
																				<TD class="error" style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="CompState" runat="server" Width="115px" MaxLength="30" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblphonenumber" runat="server" key="acc_members_profile_lbltelephone"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																				<TD>&nbsp;
																					<asp:textbox id="compphone" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblfax2" runat="server" key="acc_members_profile_lblfax"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compfax" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 18px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 18px">
																					<asp:Label id="lblemail2" runat="server" key="acc_lblemail"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD class="error" style="WIDTH: 8px" height="17">*</TD>
																				<TD style="HEIGHT: 18px">&nbsp;
																					<asp:textbox id="compemail" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblwebsite" runat="server" key="acc_members_profile_lblwebsite"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compwebsite" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lblcontactperson" runat="server" key="acc_members_profile_lblcontactperson"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compperson" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lbldesignation" runat="server" key="acc_members_profile_lbldesignation"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compdesignation" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 21px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 21px">
																					<asp:Label id="lblcontactnumber" runat="server" key="acc_members_profile_lblcontactnumber"></asp:Label></TD>
																				<TD style="WIDTH: 42px; HEIGHT: 21px" height="21">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px; HEIGHT: 21px" height="21"></TD>
																				<TD style="HEIGHT: 21px">&nbsp;
																					<asp:textbox id="compcontact" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<asp:Label id="lbllineofbusiness" runat="server" key="acc_members_profile_lbllineofbusiness"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="complinbuss" runat="server" Width="317px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px"></TD>
																				<TD style="WIDTH: 964px">
																					<P>
																						<asp:Label id="lbldescriptionofbusiness" runat="server" key="acc_members_profile_lbldescriptionofbusiness"></asp:Label></P>
																				</TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD>&nbsp;
																					<asp:textbox id="compdesbuss" runat="server" Height="40px" Width="317px" CssClass="mtbox" TextMode="MultiLine"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 8px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 8px">
																					<asp:Label id="lblnumberofemployee" runat="server" key="acc_members_profile_lblnumberofemployee"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD style="HEIGHT: 8px">&nbsp;
																					<asp:textbox id="compemps" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 1px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 1px">
																					<asp:Label id="lblworkdays" runat="server" key="acc_members_profile_lblworkdays"></asp:Label></TD>
																				<TD style="WIDTH: 42px" height="17">&nbsp;
																				</TD>
																				<TD style="WIDTH: 8px" height="17"></TD>
																				<TD style="HEIGHT: 1px">&nbsp;
																					<asp:textbox id="compwork" runat="server" Width="115px" CssClass="mtbox"></asp:textbox></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 2px; HEIGHT: 7px"></TD>
																				<TD style="WIDTH: 964px; HEIGHT: 7px">
																					<asp:Label id="lblfinancialyear" runat="server" key="acc_members_profile_lblfinancialyear"></asp:Label></TD>
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
																					<asp:Panel id="pnlExpress" runat="server" Height="58px" Width="590px" CssClass="text-outerborder-White_background-No_Border">
																						<TABLE class="text-outerborder-White_background-No_Border" id="Table2" width="100%" border="0">
																							<TR>
																								<TD style="WIDTH: 2px; HEIGHT: 22px"></TD>
																								<TD style="WIDTH: 839px; HEIGHT: 22px">
																									<asp:Label id="lblvatnumber" runat="server" key="acc_members_profile_lblvatnumber"></asp:Label></TD>
																								<TD style="WIDTH: 34px; HEIGHT: 22px" height="22"></TD>
																								<TD class="error" style="WIDTH: 17px; HEIGHT: 22px" height="22"></TD>
																								<TD style="HEIGHT: 22px" align="left">&nbsp;
																									<asp:textbox id="txtvatnumber" runat="server" Width="115px" MaxLength="8" CssClass="mtbox" DESIGNTIMEDRAGDROP="841"></asp:textbox></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 2px; HEIGHT: 22px"></TD>
																								<TD style="WIDTH: 839px; HEIGHT: 22px">
																									<asp:Label id="lblcompanylogo" runat="server" key="acc_members_profile_lblcompanylogo"></asp:Label></TD>
																								<TD style="WIDTH: 34px; HEIGHT: 22px" height="22"></TD>
																								<TD class="error" style="WIDTH: 17px; HEIGHT: 22px" height="22"></TD>
																								<TD style="HEIGHT: 22px" align="left">&nbsp;
																									<INPUT class="acc_mbutton" id="oFile" style="WIDTH: 318px; HEIGHT: 22px" type="file" size="35"  onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='acc_mbutton';"
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
																								<TD style="WIDTH: 223px; HEIGHT: 20px">
																									<asp:Label id="lblpayereferencenumber" runat="server" key="acc_members_profile_lblpayereferencenumber"></asp:Label></TD>
																								<TD style="WIDTH: 8px; HEIGHT: 20px" height="20">&nbsp;
																								</TD>
																								<TD class="error" style="WIDTH: 2px; HEIGHT: 20px" height="20"><FONT size="2">*</FONT></TD>
																								<TD style="HEIGHT: 20px" align="left">&nbsp;
																									<asp:textbox id="txtpayereference" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"
																										DESIGNTIMEDRAGDROP="2174"></asp:textbox>&nbsp;<FONT size="2">e.g A210</FONT></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 4px"></TD>
																								<TD style="WIDTH: 223px; HEIGHT: 7px">
																									<asp:Label id="lblpayeofficenumber" runat="server" key="acc_members_profile_lblpayeofficenumber"></asp:Label></TD>
																								<TD style="WIDTH: 8px" height="17"></TD>
																								<TD class="error" style="WIDTH: 2px" height="17"><FONT size="2">*</FONT></TD>
																								<TD style="HEIGHT: 1px">&nbsp;
																									<asp:textbox id="txtpayeofficeNo" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																										999</FONT></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 4px"></TD>
																								<TD style="WIDTH: 223px; HEIGHT: 7px">
																									<asp:Label id="lblacc_payenumber" runat="server" key="acc_members_profile_lblaccpayenumber"></asp:Label></TD>
																								<TD style="WIDTH: 8px" height="17"></TD>
																								<TD class="error" style="WIDTH: 2px" height="17"><FONT size="2">*</FONT></TD>
																								<TD style="HEIGHT: 1px">&nbsp;
																									<asp:textbox id="txtaccountRefarenceNo" runat="server" Width="168px" MaxLength="8" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																										999</FONT></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 4px; HEIGHT: 17px"></TD>
																								<TD style="WIDTH: 223px; HEIGHT: 17px">
																									<asp:Label id="lblnationalinsurance" runat="server" key="acc_members_profile_lblnationalinsurance"></asp:Label></TD>
																								<TD style="WIDTH: 8px; HEIGHT: 17px" height="17"></TD>
																								<TD class="error" style="WIDTH: 2px; HEIGHT: 17px" height="17"><FONT size="2">*</FONT></TD>
																								<TD style="HEIGHT: 17px">&nbsp;
																									<asp:textbox id="txtNINO" runat="server" Width="168px" MaxLength="9" CssClass="mtbox"></asp:textbox>&nbsp;<FONT size="2">e.g 
																										AB123456C</FONT></TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 4px"></TD>
																								<TD style="WIDTH: 223px; HEIGHT: 7px">
																									<asp:Label id="lblacc_offreference" runat="server" key="acc_members_profile_lblaccoffreference"></asp:Label></TD>
																								<TD style="WIDTH: 8px" height="17"></TD>
																								<TD class="error" style="WIDTH: 2px" height="17">*</TD>
																								<TD style="HEIGHT: 1px">
																									<P>&nbsp;
																										<asp:textbox id="txtAccountOfficeReference" runat="server" Width="168px" MaxLength="17" CssClass="mtbox"></asp:textbox><FONT size="2">&nbsp;e.g 
																											999PP1234567P</FONT></P>
																								</TD>
																							</TR>
																							<TR>
																								<TD style="WIDTH: 4px"></TD>
																								<TD style="WIDTH: 223px; HEIGHT: 7px">
																									<asp:Label id="lblECON" runat="server" text="ECON"></asp:Label>
																								</TD>
																								<TD style="WIDTH: 8px" height="17"></TD>
																								<TD class="error" style="WIDTH: 2px" height="17"></TD>
																								<TD style="HEIGHT: 1px">
																									<P>&nbsp;
																										<asp:textbox id="txtECON" runat="server" Width="168px" MaxLength="17" CssClass="mtbox"></asp:textbox><FONT size="2">&nbsp;e.g 
																											E3000000E</FONT></P>
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
																		<asp:Button id="btnUpdate" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='acc_mbutton';"
																			key="acc_btnupdate" Runat="server" cssclass="acc_mbutton"></asp:Button></TD>
																</TR>
															</TABLE>
														</td>
													</tr>
												</table>
											</asp:panel>
											</div>
										</TD>
									</TR>
								</TABLE>
						</td>
					</tr>
					<tr id="trBottomMain" runat="server">
						<td id="bottombar" colSpan="2" height="29" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
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
