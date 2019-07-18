<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="UpdateRegistration.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.UpdateRegistration" %>
<%@ outputcache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>UpdateRegistration</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft FrontPage 6.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" type="text/css" href="../Library/style/Style.css">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="CONTENT" id="layouttable" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</TR> <!--***************************************************************-->
				<TR vAlign="top"> <!-- BEGIN MAIN BODY CONTENTS -->
					<TD height="98%">
						<TABLE class="CONTENT" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" align="left" width="1%" rowSpan="3"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
								<TD vAlign="top" align="right" width="99%"><FONT face="Verdana, Arial, Helvetica, sans-serif" color="#6699cc" size="2"><BR>
										::..:
										<asp:label id="lblaccupdatereg" runat="server" key="acc_members_updateregistration_lblaccupdatereg"></asp:label>&nbsp;<BR>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 604px" vAlign="top" width="604" height="0">
									<TABLE class="CONTENT" id="Table3" width="100%" align="right" border="0">
										<TR>
											<TD vAlign="top">
												<P><BR>
													&nbsp;&nbsp;&nbsp;
												</P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 604px" vAlign="top" align="left"><!--BEGIN ERROR PANEL -->
									<TABLE class="CONTENT" id="Table4" cellSpacing="1" cellPadding="2" width="100%" bgColor="#ffffff"
										border="0">
										<TR>
											<TD class="error" bgColor="white">
												<asp:Label id="lblvalidemail" runat="server" key="acc_members_updateregistration_lblvalidemailaddress"></asp:Label></TD>
										</TR>
									</TABLE> <!--END ERROR PANEL --> <!--BEGIN INFORMATION PANEL --><asp:panel id="pnlInformation" runat="server" Width="601px">
										<TABLE class="CONTENT" id="Table5" cellSpacing="1" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="#cecfce">
													<TABLE class="CONTENT" id="Table6" width="100%" bgColor="#ffffff" border="0"> <!-- begin dark grey section title -->
														<TR>
															<TD class="acc_subheading" id="Td1" runat="server" key="acc_ttinformation"></TD>
														</TR> <!-- end dark grey section title -->
														<TR>
															<TD>
																<TABLE class="text-outerborder-light_blue_background" id="Table7" cellSpacing="1" cellPadding="2"
																	width="100%" bgColor="#f6f5f5" border="0">
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
									</asp:panel><!--END INFORMATION PANEL --> <!--BEGIN FORM PANEL-->
									<TABLE class="CONTENT" id="Table11" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#cecfce">
												<TABLE class="CONTENT" id="Table12" width="100%" bgColor="#ffffff" border="0">
													<TR>
														<TD class="acc_subheading" bgColor="#c5d8e7" runat="server" key="acc_members_updateregistration_ttregupdate"
															ID="Td2"></TD>
													</TR>
													<TR>
														<TD align="left"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-light_blue_background" id="Table13" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px"
																cellSpacing="1" cellPadding="2" width="100%" bgColor="white" border="0">
																<TR>
																	<TD vAlign="top" width="21%"></TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%"></TD>
																	<TD width="75%"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="21%">
																		<DIV align="left"><asp:label id="lblemail" runat="server" key="acc_lblemail"></asp:label></DIV>
																	</TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%">*
																	</TD>
																	<TD width="75%">&nbsp;
																		<asp:textbox id="txtEmailAddress" runat="server" Width="264px" MaxLength="50" CssClass="MTBOX"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="21%">
																		<DIV align="left"></DIV>
																	</TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%"></TD>
																	<TD width="75%">&nbsp;
																		<asp:button id="btnSave" runat="server" cssclass="acc_mbutton" onmouseover="this.className='acc_mbuttonon';"
																			onmouseout="this.className='MBUTTON';" key="acc_btnsave"></asp:button></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE> <!-- Panel Payment Method ------> <!--END FORM PANEL--> <!--****************************************************************--></TD>
							</TR>
						</TABLE>
					</TD>
					<TD id="rightbar" width="5%" runat="server"></TD>
					</TD></TR>
				<TR>
					<td id="bottombar" colSpan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
