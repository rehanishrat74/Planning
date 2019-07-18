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
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</TR> <!--***************************************************************-->
				<TR vAlign="top"> <!-- BEGIN MAIN BODY CONTENTS -->
					<TD height="98%">
						<TABLE class="CONTENT" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" align="left" width="1%" rowSpan="3">
									<include:leftbar id="idxLeftBar" runat="server"></include:leftbar>
								</TD>
								<TD vAlign="top" align="right" width="99%"><FONT face="Verdana, Arial, Helvetica, sans-serif" color="#6699cc" size="2"><BR>
										::..: Accounts Centre Update Registration &nbsp;<BR>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 604px" vAlign="top" width="604" height="0">
									<TABLE class="CONTENT" id="Table3" width="100%" align="right" border="0">
										<TR>
											<TD vAlign="top">
												<P><BR>
													To use our services, you must&nbsp;provide us with a valid Email 
													Address.&nbsp;&nbsp;&nbsp;&nbsp;
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
											<TD class="error" bgColor="white"></TD>
										</TR>
									</TABLE> <!--END ERROR PANEL --> <!--BEGIN INFORMATION PANEL -->
									<asp:panel id="pnlInformation" runat="server" Width="601px">
										<TABLE class="CONTENT" id="Table5" cellSpacing="1" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="#cecfce">
													<TABLE class="CONTENT" id="Table6" width="100%" bgColor="#ffffff" border="0"> <!-- begin dark grey section title -->
														<TR>
															<TD class="acc_subheading">&nbsp;Information</TD>
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
														<TD class="acc_subheading" bgColor="#c5d8e7">Customer Registration Update</TD>
													</TR>
													<TR>
														<TD align="left"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE class="text-outerborder-light_blue_background" id="Table13" cellSpacing="1" cellPadding="2"
																width="100%" bgColor="white" border="0" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; BORDER-RIGHT-WIDTH: 1px">
																<TR>
																	<TD vAlign="top" width="21%"></TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%"></TD>
																	<TD width="75%"></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="21%">
																		<DIV align="left">Email
																		</DIV>
																	</TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%">*
																	</TD>
																	<TD width="75%">&nbsp;
																		<asp:textbox id="txtEmailAddress" runat="server" Width="264px" CssClass="MTBOX" MaxLength="50"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD vAlign="top" width="21%">
																		<DIV align="left"></DIV>
																	</TD>
																	<TD width="2%">&nbsp;
																	</TD>
																	<TD class="error" width="2%"></TD>
																	<TD width="75%">&nbsp;
																		<asp:button id="btnSave" runat="server" Width="63px" cssclass="acc_mbutton" onmouseover="this.className='acc_mbuttonon';" onmouseout="this.className='MBUTTON';" Text="Save"></asp:button></TD>
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
					<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</TR>
			</TABLE>
		</FORM>
	</body>
</HTML>
