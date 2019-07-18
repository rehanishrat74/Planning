<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="SaveSamplePlan.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.SaveSamplePlan"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>SaveSamplePlan</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<script src="../../Library/Scripts/Common.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<INPUT type="hidden" id="hdnPlanName" runat="server" NAME="hdnPlanName"> <INPUT type="hidden" id="hdnPlanID" runat="server" NAME="hdnPlanID">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" 
dir=<%=Session("dir")%>>
				<tr>
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" height="19"><asp:label id="lblMessage" runat="server" Width="100%" CssClass="wizardTitle"></asp:label></td>
										</tr>
										<tr>
											<td vAlign="top" height="10"><IMG height="10" src="../../images/InfiniPlan/blank.gif" width="1"></td>
										</tr>
										<tr>
											<td vAlign="top" height="311" align="center">
												<!-- Center Table -->
												<table id="Options" width="100%">
													<tr>
														<td valign="top" height='30'></td>
													</tr>
													<tr>
														<td valign="middle" height='30'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
													</tr>
												</table>
												<TABLE id="tblSavePlan" height="75" cellSpacing="1" cellPadding="1" width="485" border="0"
													runat="server">
													<TR>
														<TD colspan="3" align="center" height="41">
															<asp:Label id="lblSavePlan" runat="server" CssClass="MultilingulLinkStyle"></asp:Label>
														</TD>
													</TR>
													<TR>
														<TD width="35%">&nbsp;</TD>
														<TD width="30%">&nbsp;</TD>
														<TD width="35%">&nbsp;</TD>
													</TR>
													<TR>
														<TD align="right" width="35%">
															<asp:button id="btnSubmit" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';" Width="53px"></asp:button></TD>
														<TD align="center" width="30%">
															<asp:Button id="btnNo" runat="server" Width="53px" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';"></asp:Button></TD>
														<TD align="left" width="35%">
															<asp:Button id="btnCancel" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';" Width="53px"></asp:Button></TD>
													</TR>
												</TABLE>
												<TABLE id="tblReplacePlan" height="75" cellSpacing="1" cellPadding="1" width="485" border="0"
													runat="server">
													<TR>
														<TD align="center" colSpan="3" height="42">
															<asp:Label id="lblOverwritePlan" runat="server" CssClass="MultilingulLinkStyle"></asp:Label>
														</TD>
													</TR>
													<TR>
														<TD width="35%">&nbsp;
														</TD>
														<TD width="30%">&nbsp;
														</TD>
														<TD width="35%">&nbsp;
														</TD>
													</TR>
													<TR>
														<TD align="right" width="35%">
															<asp:button id="btnReplaceYes" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';" Width="53px"></asp:button></TD>
														<TD align="center" width="30%">
															<asp:Button id="btnReplaceNo" runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';" Width="53px"></asp:Button></TD>
														<TD align="left" width="35%">
															<asp:Button id="btnReplaceCancel" runat="server" Width="53px" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
 onmouseout="this.className='MBUTTONACCPRO';"></asp:Button></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td vAlign="top" height="10"><IMG height="10" src="../images/InfiniPlan/blank.gif" width="1"></td>
										</tr>
										<tr>
											<td vAlign="top" align="center" height="19"></td>
										</tr>
									</table>
									<asp:imagebutton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:imagebutton><asp:label id="Label1" runat="server">Label</asp:label>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="bottom">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
