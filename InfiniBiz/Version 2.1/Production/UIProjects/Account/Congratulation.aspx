<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Congratulation.aspx.vb" Inherits="accounts.infinibiz.Web.Congratulation" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Congratulation</title>
		<meta name="cbignore" content="1">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<TABLE class="CONTENT" id="layouttable" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<td id="topbar" colspan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
				</TR> <!--***************************************************************-->
				<TR vAlign="top"> <!-- BEGIN MAIN BODY CONTENTS -->
					<TD id="menuarea" runat="server" vAlign="top" align="left" width="5%">
						<include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
					<TD height="98%">
						<TABLE class="CONTENT" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="top" align="right" width="99%"><FONT face="Verdana, Arial, Helvetica, sans-serif" color="#6699cc" size="2"><BR>
										::..: Accounts Centre Registration &nbsp;<BR>
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 604px" vAlign="top" width="604" height="0">
									<TABLE class="CONTENT" id="Table3" width="100%" align="right" border="0">
										<TR>
											<TD vAlign="top">
												<P><BR>
													To use our services, you must be a registered member of either Accounts Centre, 
													or any of our partner websites. Being a registered member, you can access all 
													services that you have subscribed for, and also receive valuable information on 
													tax, legal and accounting matters, that are directly or indirectly targetted 
													towards helping you help your <FONT color="#003366">business</FONT>.
												</P>
												<P>Please fill out the form below to register with Accounts Centre. Once you 
													register, you will receive a confirmation email containing your User ID and 
													Password.
													<BR>
													<BR>
													For more information on other services, <A href="/Services">click here.</A>&nbsp;&nbsp;&nbsp;
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
									<asp:panel id="Panel8" runat="server" Width="601px">
										<TABLE class="CONTENT" id="Table5" cellSpacing="1" cellPadding="0" width="100%" border="0">
											<TR>
												<TD bgColor="#cecfce">
													<TABLE class="CONTENT" id="Table6" width="100%" bgColor="#ffffff" border="0"> <!-- begin dark grey section title -->
														<TR>
															<TD class="HEADING">&nbsp;Information</TD>
														</TR> <!-- end dark grey section title -->
														<TR>
															<TD>
																<TABLE class="CONTENT" id="Table7" cellSpacing="1" cellPadding="2" width="100%" bgColor="#f6f5f5"
																	border="0">
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
									</asp:panel><!--END INFORMATION PANEL --> <!--BEGIN FORM PANEL--> <!-- Panel Payment Method ------>  <!--END FORM PANEL--> <!--****************************************************************--></TD>
							</TR>
						</TABLE>
					</TD>
					<TD id="rightbar" width="5%" runat="server"></TD>
					</TD></TR>
				<TR>
					<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
				</TR>
			</TABLE>
			&nbsp;
		</FORM>
	</body>
</HTML>
