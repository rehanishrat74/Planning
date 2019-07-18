<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Charts.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Charts"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Charts</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlInitialAnalysis" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				runat="server" Width=100%>
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>	<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD>
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
														<DIV class="heading" align="center">Past Performance</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypPastPerformance" Runat="server" ImageUrl="/images/InfiniPlan/map/past-performance.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=5"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">View the past performances of your company in terms of sales, 
															capitals, and assets.
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
						<TD>
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
														<DIV class="heading" align="center">Market Analysis</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypMarketAnalysis" Runat="server" ImageUrl="/images/InfiniPlan/map/market-analysis.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=4"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your potential customers, growth rate in different types of charts. <STRONG></STRONG>
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
						<TD>
							<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" align="center"
								border="0">
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
													<DIV class="heading" align="center">Benchmark</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="75">
													<DIV align="center">
														<asp:HyperLink id="hypBenchmark" Runat="server" ImageUrl="/images/InfiniPlan/map/Benchmark-.gif"
															width="48" NavigateUrl="../Charts/Chart.aspx?chartID=0"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<P align="left">View any benchmark that you have desired to achieve in different 
														types of charts. <STRONG></STRONG>
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
												<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<DIV align="center"></DIV>
						</TD>
					</TR>
					<TR>
						<TD>
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
														<DIV class="heading" align="center">Highlight</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypHighlight" Runat="server" ImageUrl="/images/InfiniPlan/map/highlight.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=3"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View any Business highlights that you have made in different types of charts. <STRONG>
																</STRONG>
															</P>
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</TD>
										<TD vAlign="top" width="10">
											<TABLE height="100%" cellSpacing="0" cellPadding="0" width="10" align="right" border="0">
												<TR>
													<TD vAlign="top" width="10" height="1%"><IMG height="7" src="/images/InfiniPlan/b4cor2.gif" width="10"></TD>
												</TR>
												<TR>
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
						<TD>
							<DIV align="center"></DIV>
						</TD>
						<TD>
							<DIV align="center"></DIV>
						</TD>
					</TR>	<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/illustrations.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="pnlMonthlyAnalysis" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 432px"
				runat="server" Width=100%>
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>	<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD>
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
														<DIV class="heading" align="center">Profit Monthly</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypProfitMonthly" Runat="server" ImageUrl="/images/InfiniPlan/map/profit-monthly.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=6"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your company's monthly profit in different types of charts. <STRONG></STRONG>
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
						<TD>
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
														<DIV class="heading" align="center">Gross Margin Monthly</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypGrossMarginMonthly" Runat="server" ImageUrl="/images/InfiniPlan/map/Gross-Margin-Monthly.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=8"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your company's monthly Gross Margin in different types of charts. <STRONG></STRONG>
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
						<TD>
							<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" align="center"
								border="0">
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
													<DIV class="heading" align="center">Sales Monthly</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="75">
													<DIV align="center">
														<asp:HyperLink id="hypSalesMonthly" Runat="server" ImageUrl="/images/InfiniPlan/map/Sales-Monthly.gif"
															width="48" NavigateUrl="../Charts/Chart.aspx?chartID=11"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<P align="left">View your company's monthly sales in different types of charts. <STRONG>
														</STRONG>
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
												<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<DIV align="center"></DIV>
						</TD>
					</TR>	<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/illustrations.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>&nbsp;
			<asp:Panel id="pnlYearlyAnalysis" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 648px"
				runat="server" Width=100%>
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>	<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD>
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
														<DIV class="heading" align="center">Profit Yearly</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypProfitYearly" Runat="server" ImageUrl="/images/InfiniPlan/map/Profit-Monthly.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=7"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your company's Yearly profit in different types of charts. <STRONG></STRONG>
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
						<TD>
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
														<DIV class="heading" align="center">Gross Margin Yearly</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypGrossMarginYearly" Runat="server" ImageUrl="/images/InfiniPlan/map/Gross-Margin-Yearly.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=9"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your company's Yearly Gross Margin in different types of charts. <STRONG></STRONG>
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
						<TD>
							<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" align="center"
								border="0">
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
													<DIV class="heading" align="center">Sales Yearly</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="75">
													<DIV align="center">
														<asp:HyperLink id="hypSalesYearly" Runat="server" ImageUrl="/images/InfiniPlan/map/Sales-Yearly.gif"
															width="48" NavigateUrl="../Charts/Chart.aspx?chartID=10"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<P align="left">View your company's Yearly sales in different types of charts. <STRONG></STRONG>
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
												<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<DIV align="center"></DIV>
						</TD>
					</TR>	<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/illustrations.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="pnlFinancialStatements" style="Z-INDEX: 104; LEFT: 8px; POSITION: absolute; TOP: 864px"
				runat="server" Height="15px" Width=100%>
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>	<TR>
						<TD><BR>
							<BR>
						</TD>
					</TR>
					<TR>
						<TD   width=50%>
							<DIV align=right >
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
														<DIV class="heading" align="center">Break Even Analysis<BR>
														</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="61">
														<DIV align="center">
															<asp:HyperLink id="hypBreakEvenAnalysis" Runat="server" ImageUrl="/images/InfiniPlan/map/Break-Even-Analysis.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=1"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View whether revenue achieved is equal or more than what was expected in 
																different types of charts. <STRONG></STRONG>
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
														<DIV class="heading" align="center">Cash Flow Analysis</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypCashFlowAnalysis" Runat="server" ImageUrl="/images/InfiniPlan/map/Cash-Flow-Analysis.gif"
																width="48" NavigateUrl="../Charts/Chart.aspx?chartID=2"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your company's Flow of Cash in different types of charts.
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
						<TD width="216">
							<DIV align="center"></DIV>
						</TD>
					</TR>
					<TR>
						<TD align="center" colSpan="3"><BR>
							<BR>
							<A href="/InfiniPlan/Services/Map/illustrations.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
					</TR>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
