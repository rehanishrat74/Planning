<%@ Page Language="vb" AutoEventWireup="false" validateRequest="False" Codebehind="PlanText.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanText"%>
<%@ Register TagPrefix="ftb" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"		%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		%>
<HTML xmlns:o>
	<HEAD>
		<title>Text</title>
		<Link href="../../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css">
			<LINK href="../../Library/Styles/GridStyles.css" type="text/css" rel="stylesheet">
				<script src="../../Library/Scripts/PlanWizard.js"></script>
				<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form1" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="white">
				<tr id="trTopMain" runat="server">
					<td height="19" vAlign="top"><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0" bgcolor="white">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%" id="tdLeftMain" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="16" align="center" valign="top" bgcolor="#f3f3f3">
											 	<asp:Label id="lblTableHeading" runat="server" Width="100%" CssClass="lblHeading"> </asp:Label>
											</td>
										</tr>
										<tr>
											<td align="center">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir="ltr">
													<tr>
														<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
														<td class="TableBox_Top" height="3">&nbsp;</td>
														<td class="TableBox_Top_Right" height="3">&nbsp;</td>
													</tr>
													<tr>
														<td class="TableBox_Left" width="0%"></td>
														<td height="100%" valign="top">
															<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
																<tr>
																	<td height="1%" valign="top" align="center"><img src="/images/InfiniPlan/blank.gif" width="1" height="10">&nbsp;
																		<asp:Label id="lblErrorMessage" runat="server" CssClass="lblErrorMessage" Width="100%"></asp:Label>
																		<br>
																		<TABLE id="tblcontents" cellSpacing="1" cellPadding="1" width="100%" border="0" class="pagecontents"
																			runat="server">
																			<TR>
																				<TD><SPAN>
																						<P align="justify"><SPAN>&nbsp;
</SPAN></P>
																					</SPAN>
																				</TD>
																			</TR>
																		</TABLE>
																	</td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="100%" height="60%">
																		  <div id="gridDiv" class="textSpace"> 
																		<ftb:FreeTextBox id="ftbText" ToolbarBackColor="#f2f2f2"   runat="Server" width="100%" BackColor="WhiteSmoke" GutterBackColor="WhiteSmoke"
																			EditorBorderColorDark="Gainsboro" EditorBorderColorLight="Gainsboro" 
																			ToolbarBackgroundImage="false" Height="250px" UseToolbarBackGroundImage="false" ToolbarStyleConfiguration="NotSet"
																			toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat;BulletedList,NumberedList,Indent,Outdent;CreateLink|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;Cut,Copy,Paste,Delete;Undo,Redo,InsertRule,NetSpell,InsertTable"
																			GutterBorderColorLight="Gainsboro" GutterBorderColorDark="192, 0, 0"></ftb:FreeTextBox>
																		 </div>  
																	</td>
																</tr>
																<tr>
																	<td valign="top"></td>
																</tr>
																<tr>
																	<td align="center" valign="top" height="10%">
																		<asp:Button id="btnUpdate" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
																			onmouseout="this.className='MBUTTONACCPRO';" Text="Update Text"></asp:Button>
																	</td>
																</tr>
																<TR>
																	<TD vAlign="top" align="center">
																		<!--<asp:Button id="btnBack" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
																			onmouseout="this.className='MBUTTONACCPRO';" Width="120px" Text="Previous Task" Visible="False"></asp:Button>&nbsp;
																		<asp:Button id="btnNext" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
																			onmouseout="this.className='MBUTTONACCPRO';" Width="120px" Text="Next Task" Visible="False"></asp:Button>-->
																		<asp:Label id="Label1" runat="server" BackColor="Gray"></asp:Label></TD>
																</TR>
															</table>
														</td>
														<td class="TableBox_Right" width="0%">&nbsp;@</td>
													</tr>
													<tr>
														<td class="TableBox_Bot_Left" width="0%"></td>
														<td class="TableBox_Bot" width="100%"></td>
														<td class="TableBox_Bot_Right" width="0%"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter></td>
				</tr>
			</table>
		</form>
 
	</body>
</HTML>
