<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Tables.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Tables"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Tables</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlFinancialStatements" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px"
				runat="server" Width=100% Height="593px">
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>		<tr>
					<td><br>
						<br>
					</td>
				</tr>
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
														<DIV class="heading" align="center">Balance Sheet</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypBalanceSheet" Runat="server" ImageUrl="/images/InfiniPlan/map/balance-sheet.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=10"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your Company's balances in a tabular form. <STRONG></STRONG>
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
														<DIV class="heading" align="center">Cash Flow Statement</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypCashFlowStatement" Runat="server" ImageUrl="/images/InfiniPlan/map/Cash-Flow-Statement.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=9"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View your Company's flow of cash in tabular form. <STRONG></STRONG>
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
													<DIV class="heading" align="center">Income Statement</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="75">
													<DIV align="center">
														<asp:HyperLink id="hypIncomeStatement" Runat="server" ImageUrl="/images/InfiniPlan/map/Income-Statement.gif"
															width="48" NavigateUrl="../Tables/Table.aspx?tableID=8"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<P>View whether the company made profit or loss in the financial year in tabular 
														form. <STRONG></STRONG>
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
														<DIV class="heading" align="center">Break Even Analysis</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypBreakEvenAnalysis" Runat="server" ImageUrl="/images/InfiniPlan/map/Break-Even-Analysis.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=2"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View whether revenue achieved is equal or more than what was expected in tabular 
																form. <STRONG></STRONG>
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
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/b5cor1.gif" width="10"></TD>
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
														<DIV class="heading" align="center">Expenses</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypExpenses" Runat="server" ImageUrl="/images/InfiniPlan/map/expenses.gif" width="48"
																NavigateUrl="../Tables/Table.aspx?tableID=6"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View the company's expenses in tabular form. <STRONG></STRONG>
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
							<DIV align="center">
								<TABLE class="bg" height="142" cellSpacing="0" cellPadding="0" width="248" border="0">
									<TR>
										<TD vAlign="top" width="10" height="100%">
											<TABLE cellSpacing="0" cellPadding="0" width="10" border="0">
												<TR>
													<TD vAlign="top" height="1%"><IMG height="7" src="/images/InfiniPlan/b5cor1.gif" width="10"></TD>
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
														<DIV class="heading" align="center">Ratios</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypRatios" Runat="server" ImageUrl="/images/InfiniPlan/map/Ratios.gif" width="48"
																NavigateUrl="../Tables/Table.aspx?tableID=11"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View the ratios of your company's profit and loss in tabular form. <STRONG></STRONG>
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
													<TD vAlign="top" height="99%"><IMG height="135" src="/images/InfiniPlan/b3rvbg.gif" width="10"></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
								</TABLE>
							</DIV>
						</TD>
					</TR>
					<TR>
						<TD>
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
													<DIV class="heading" align="center">Payroll</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="75">
													<DIV align="center">
														<asp:HyperLink id="hypPayroll" Runat="server" ImageUrl="/images/InfiniPlan/map/payroll.gif" width="48"
															NavigateUrl="../Tables/Table.aspx?tableID=4"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<DIV align="left">
														<P><STRONG>: </STRONG>View your company's salaries, wages, bonuses and deductions 
															in tabular form. <STRONG></STRONG>
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
						</TD>
						<TD>&nbsp;</TD>
						<TD>&nbsp;</TD>
					</TR>	<tr>
					<td colspan='3' align="center"><BR>
						<BR>
						<a href="/InfiniPlan/Services/Map/illustrations.aspx"><img border="0" src="/Images/infiniplan/back.gif"></a></td>
				</tr>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="pnlBasicInformation" style="Z-INDEX: 102; LEFT: 8px; POSITION: absolute; TOP: 600px"
				runat="server" Width=100% Wrap="False" Height="380px">
				<TABLE style="WIDTH: 784px; HEIGHT: 146px" cellSpacing="8" cellPadding="0" width="784"
					border="0" align=center>		<tr>
					<td><br>
						<br>
					</td>
				</tr>
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
														<DIV class="heading" align="center">General Assumptions</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypGeneralAssumptions" Runat="server" ImageUrl="/images/InfiniPlan/map/General-Assumptions.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=0"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View and manage general assumptions such as Tax Rates, Inventories etc in 
																tabular form. <STRONG></STRONG>
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
														<DIV class="heading" align="center">Startup Details</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypStartupDetails" Runat="server" ImageUrl="/images/InfiniPlan/map/Startup-Details.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=1"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View and manage basic startup details like expenses, assets, funds in tabular 
																form. <STRONG></STRONG>
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
													<DIV class="heading" align="center">Past performance</DIV>
												</TD>
											</TR>
											<TR>
												<TD vAlign="top" height="61">
													<DIV align="center">
														<asp:HyperLink id="hypPastPerformance" Runat="server" ImageUrl="/images/InfiniPlan/map/Past-Performance.gif"
															width="48" NavigateUrl="../Tables/Table.aspx?tableID=12"></asp:HyperLink></DIV>
												</TD>
											</TR>
											<TR>
												<TD class="text" vAlign="top" height="1%">
													<P align="left">View and manage the past performances of your company in terms of 
														sales, capitals, assets in tabular form. <STRONG></STRONG>
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
														<DIV class="heading" align="center">Market Analysis</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypMarketAnalysis" Runat="server" ImageUrl="/images/InfiniPlan/map/Market-Analysis.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=3"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View and analyze your potential customers, growth rate in tabular form. <STRONG></STRONG>
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
					</TR>	<tr>
					<td colspan='3' align="center"><BR>
						<BR>
						<a href="/InfiniPlan/Services/Map/illustrations.aspx"><img border="0" src="/Images/infiniplan/back.gif"></a></td>
				</tr>
				</TABLE>
			</asp:Panel>
			<asp:Panel id="pnlForeCast" style="Z-INDEX: 103; LEFT: 8px; POSITION: absolute; TOP: 1008px"
				runat="server" Height="27px" Width=100% Visible="False">
				<TABLE cellSpacing="8" cellPadding="0" width="744" border="0" align=center>		<tr>
					<td><br>
						<br>
					</td>
				</tr>
					<TR>
						<TD width=50%>
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
														<DIV class="heading" align="center">Milestone</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypMilestones" Runat="server" ImageUrl="/images/InfiniPlan/map/Milestone.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=7"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P>View and manage any milestones that you have set to achieve in tabular form.
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
														<DIV class="heading" align="center">Sales Forecast</DIV>
													</TD>
												</TR>
												<TR>
													<TD vAlign="top" height="75">
														<DIV align="center">
															<asp:HyperLink id="hypSalesForecast" Runat="server" ImageUrl="/images/InfiniPlan/map/Sales-Forecast.gif"
																width="48" NavigateUrl="../Tables/Table.aspx?tableID=5"></asp:HyperLink></DIV>
													</TD>
												</TR>
												<TR>
													<TD class="text" vAlign="top" height="1%">
														<DIV align="left">
															<P><STRONG>: </STRONG>View and manage the sales you forecast for the financial year 
																in tabular form.
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
					 
					</TR>	<tr>
					<td colspan='3' align="center"><BR>
						<BR>
						<a href="/InfiniPlan/Services/Map/illustrations.aspx"><img border="0" src="/Images/infiniplan/back.gif"></a></td>
				</tr>
				</TABLE>
			</asp:Panel>
		</form>
	</body>
</HTML>
