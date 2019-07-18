<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ErrorPage.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.ErrorPage"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<HTML>
	<HEAD>
		<title>Plan Manager</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
	</HEAD>
	<body class="cngbody">
		<!-- **************************************************************************************************************************** -->
		<!-- Actual Page Contents are to be written here  -->
		<form id="Form2" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td height="19" vAlign="top">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="100%" vAlign="top">
						<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="/images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="19" align="center" valign="top">
											</td>
										</tr>
										<tr>
											<td height="10" valign="top"><img src="/images/InfiniPlan/blank.gif" width="1" height="10">&nbsp;
												<asp:Label id="lblError" runat="server" Width="648px" CssClass="MultilingulLinkStyle"></asp:Label>
											</td>
										</tr>
										<tr>
											<td height="311" valign="top">
												<!-- Center Table -->
												<TABLE WIDTH="500" BORDER="0" CELLPADDING="0" CELLSPACING="0">
													<TR>
														<TD COLSPAN="7" align="center">&nbsp;

														</TD>
													</TR>
													<TR>
														<TD COLSPAN="7">
															<img src="/images/InfiniPlan/Blank.gif" width="500" height="14"></TD>
													</TR>
													<TR>
														<TD COLSPAN="3">
															<img src="/images/InfiniPlan/Blank.gif" width="200" height="90"></TD>
														<TD>
															<!-- <IMG SRC="/images/InfiniPlan/chooseplan_04.jpg" WIDTH="109" HEIGHT="90" ALT=""> -->
														</TD>
														<TD COLSPAN="3">
															<img src="/images/InfiniPlan/Blank.gif" width="191" height="90">
														</TD>
													</TR>
													<TR>
														<TD COLSPAN="7">
															<img src="/images/InfiniPlan/Blank.gif" width="500" height="16">
														</TD>
													</TR>
													<TR>
														<TD>
															<img src="/images/InfiniPlan/Blank.gif" width="18" height="96"></TD>
														<TD>
															<!--<IMG SRC="/images/InfiniPlan/chooseplan_08.jpg" WIDTH="115" HEIGHT="96" ALT=""> -->
														</TD>
														<TD COLSPAN="3">
															<img src="/images/InfiniPlan/Blank.gif" width="234" height="96"></TD>
														<TD>
														</TD>
														<TD>
															<img src="/images/InfiniPlan/Blank.gif" width="21" height="96"></TD>
													</TR>
													<TR>
														<TD COLSPAN="7">
															<IMG SRC="/images/InfiniPlan/chooseplan_12.jpg" WIDTH="500" HEIGHT="9" ALT="">
														</TD>
													</TR>
													<TR>
														<TD COLSPAN="3">
															<img src="/images/InfiniPlan/Blank.gif" width="200" height="88"></TD>
														<TD>
														<!-- <IMG SRC="/images/InfiniPlan/chooseplan_14.jpg" WIDTH="109" HEIGHT="88" ALT=""></TD> -->
														<TD COLSPAN="3">
															<img src="/images/InfiniPlan/Blank.gif" width="191" height="88"></TD>
													</TR>
													<TR>
														<TD COLSPAN="7">
															<img src="/images/InfiniPlan/Blank.gif" width="500" height="19"></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td height="10" valign="top"><img src="../images/InfiniPlan/blank.gif" width="1" height="10"></td>
										</tr>
										<tr>
											<td height="19" align="center" valign="top">
											</td>
										</tr>
									</table>
									<asp:ImageButton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:ImageButton>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** -->
								</td>
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

