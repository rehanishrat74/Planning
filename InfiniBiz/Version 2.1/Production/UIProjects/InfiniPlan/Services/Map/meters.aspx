<%@ Page Language="vb" AutoEventWireup="false" Codebehind="meters.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.meters"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>meters</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:panel id="pnlMeter" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
				Width="100%" Height="208px">
				<TABLE cellSpacing="8" cellPadding="0" width="744" align="center" border="0">
					<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD width="50%">
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
														<DIV class="heading" align="center">Speedometers
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypSpeedoMeters" Runat="server" ImageUrl="/images/InfiniPlan/map/speedometers.gif"
																width="48" height="47" NavigateUrl="/InfiniPlan/Services/Plan/SpeedometerManager.aspx"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">View the profit and loss of all of your plans globally
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
														<DIV class="heading" align="center">Meter Wizard</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:ImageButton id="iBtnMeterWizard" Runat="server" ImageUrl="/images/InfiniPlan/map/meter-wizard.gif"
																width="48" height="47"></asp:ImageButton></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<P align="left">Compose Meter, Meter Listing.<BR>
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
						<TD width="216">
							<DIV align="center"></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/PlanRoot.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:panel><asp:panel id="pnlMeterWizard" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 8px"
				runat="server" Width="100%" Height="224px" Visible="False">
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
														<DIV class="heading" align="center">Compose Meter
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypComposeMeter" Runat="server" ImageUrl="/images/InfiniPlan/map/compose-meter.gif"
																width="48" NavigateUrl="../MeterWizard/Speedometer.aspx?AnalysisID=0"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">To compose meter for viewing business status.</DIV>
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
														<DIV class="heading" align="center">Meter Listing</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypMeterListing" Runat="server" ImageUrl="/images/InfiniPlan/map/meter-listing.gif"
																width="48" NavigateUrl="../MeterWizard/Speedometer.aspx?AnalysisID=1"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">To view and edit meter for  business status.</DIV>
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
							<DIV align="center"></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/Meters.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:panel></form>
	</body>
</HTML>
