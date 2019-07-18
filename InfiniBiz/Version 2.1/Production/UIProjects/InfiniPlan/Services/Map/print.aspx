<%@ Page Language="vb" AutoEventWireup="false" Codebehind="print.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.print"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>print</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlPrint" runat="server" Width="100%" Height="216px">
				<TABLE cellSpacing="8" cellPadding="0" align="center" border="0">
					<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD align="right" width="50%">
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/cor3.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
														<DIV class="heading" align="center">My Documents</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypMyDocuments" NavigateUrl="/InfiniPlan/Services/Plan/ExportedPlans.aspx" height="47"
																width="48" ImageUrl="/images/InfiniPlan/map/my-documents.gif" Runat="server"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>Maintain all your exported plans. <STRONG></STRONG>
															</P>
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<TD width="248">
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/b2cor3.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
														<DIV class="heading" align="center">Print</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:ImageButton id="ibtnPrintDetail" width="48" ImageUrl="/images/InfiniPlan/map/print.gif" Runat="server"></asp:ImageButton></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<P align="left">Plan Preview, Export Plan.<BR>
														</P>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/PlanRoot.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="PnlPrintDetail" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"
				runat="server" Width="100%" Height="216px" Visible="False">
				<TABLE cellSpacing="8" cellPadding="0" width="744" align="center" border="0">
					<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD align="right" width="50%">
							<DIV align="right">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/cor3.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
														<DIV class="heading" align="center">Plan Preview<BR>
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypPlanPreview" NavigateUrl="../Printing/Printing.aspx?printid=0" width="48"
																ImageUrl="/images/InfiniPlan/map/plan-preview.gif" Runat="server"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">Have a preview of the plan before printing.</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<TD width="248">
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/b2cor3.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
														<DIV class="heading" align="center">Export Plan</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypExportPlan" NavigateUrl="../Printing/Printing.aspx?printid=1" width="48"
																ImageUrl="/images/InfiniPlan/map/export-plan.gif" Runat="server"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">Export the plan when it is completed and documented.
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<TD width="216">
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/cor1.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/lvbg.gif" height="98%"><IMG height="125" src="/images/InfiniPlan/lvimg.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="bottom" height="1%"><IMG height="10" src="/images/InfiniPlan/b2cor3.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
										<TD class="bg" vAlign="top" background="/images/InfiniPlan/gbg.gif">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD vAlign="top" background="/images/InfiniPlan/tbg.gif" height="1%">
														<DIV class="heading" align="center">Plan OutLine</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypPlanoutline" NavigateUrl="../Printing/Printing.aspx?printid=2" width="48" ImageUrl="/images/InfiniPlan/map/plan_outline.gif"
																Runat="server"></asp:HyperLink></DIV> 
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">Edit plan headings.</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/rvimg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/print.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
		<DIV align="center"></DIV>
	</body>
</HTML>
