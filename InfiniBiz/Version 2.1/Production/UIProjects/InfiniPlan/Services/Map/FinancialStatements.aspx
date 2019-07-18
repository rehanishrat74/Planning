<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FinancialStatements.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.FinancialStatements"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>FinancialStatements</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD> 
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="744" border="0" cellspacing="8" cellpadding="0">
				<tr>
					<td><div align="center">
							<table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
								<tr>
									<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Projected 
														Balance Sheet</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/projected_balance_sheet_r.gif" width="48" height="47"
															border="0"></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left"></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
											<tr>
												<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="99%" valign="top"><img src="/images/InfiniPlan/rvimg.gif" width="10" height="135"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
					<td><div align="center">
							<table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
								<tr>
									<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom"><img src="/images/InfiniPlan/b2cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Projected 
														Cash Flow</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/projected_cash_flow_r.gif" width="48" height="47"
															border="0"></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text">
													<div align="left"></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
											<tr>
												<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="99%" valign="top"><img src="/images/InfiniPlan/rvimg.gif" width="10" height="135"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
					<td><table width="248" height="142" border="0" align="center" cellpadding="0" cellspacing="0"
							class="bg">
							<tr>
								<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
										</tr>
										<tr>
											<td height="1%" valign="bottom"><img src="/images/InfiniPlan/b2cor3.gif" width="10" height="10"></td>
										</tr>
									</table>
								</td>
								<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Projected 
													Profit &amp; Loss</div>
											</td>
										</tr>
										<tr>
											<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/projected_profit_loss_r.gif" width="48" height="47"
														border="0"></div>
											</td>
										</tr>
										<tr>
											<td height="1%" valign="top" class="text">&nbsp;</td>
										</tr>
									</table>
								</td>
								<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
										<tr>
											<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="99%" valign="top"><img src="/images/InfiniPlan/b3rvbg.gif" width="10" height="135"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
						<div align="center"></div>
					</td>
				</tr>
				<tr>
					<td><div align="center">
							<table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
								<tr>
									<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Break 
														Even Analysis</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/break_even_analysis_r.gif" width="48" height="47"
															border="0"></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left"></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
											<tr>
												<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/b4cor2.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="99%" valign="top"><img src="/images/InfiniPlan/b3rvbg.gif" width="10" height="135"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
					<td><div align="center">
							<table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
								<tr>
									<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top"><img src="/images/InfiniPlan/b5cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Financial 
														Plan</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/financial_plan_r.gif" width="48" height="47" border="0"></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left"></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
											<tr>
												<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/b4cor2.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="99%" valign="top"><img src="/images/InfiniPlan/b3rvbg.gif" width="10" height="135"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
					<td><div align="center">
							<table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
								<tr>
									<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top"><img src="/images/InfiniPlan/b5cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Business 
														Ratio</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/business_ratio_r.gif" width="48" height="47" border="0"></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left"></div>
												</td>
											</tr>
										</table>
									</td>
									<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
											<tr>
												<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="99%" valign="top"><img src="/images/InfiniPlan/b3rvbg.gif" width="10" height="135"></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td><table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
							<tr>
								<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
										</tr>
										<tr>
											<td height="1%" valign="bottom"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
										</tr>
									</table>
								</td>
								<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Management 
													Summary</div>
											</td>
										</tr>
										<tr>
											<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/management_summary_r.gif" width="48" height="47"
														border="0"></div>
											</td>
										</tr>
										<tr>
											<td height="1%" valign="top" class="text"><div align="left"></div>
											</td>
										</tr>
									</table>
								</td>
								<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
										<tr>
											<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="99%" valign="top"><img src="/images/InfiniPlan/rvimg.gif" width="10" height="135"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td><table width="248" height="142" border="0" cellpadding="0" cellspacing="0" class="bg">
							<tr>
								<td width="10" height="100%" valign="top"><table width="10" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top"><img src="/images/InfiniPlan/cor1.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="98%" valign="top" background="/images/InfiniPlan/lvbg.gif"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
										</tr>
										<tr>
											<td height="1%" valign="bottom"><img src="/images/InfiniPlan/b2cor3.gif" width="10" height="10"></td>
										</tr>
									</table>
								</td>
								<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Personal 
													Plan</div>
											</td>
										</tr>
										<tr>
											<td height="75" valign="top"><div align="center"><img src="/images/InfiniPlan/personal_plan_r.gif" width="48" height="47" border="0"></div>
											</td>
										</tr>
										<tr>
											<td height="1%" valign="top" class="text"><div align="left"></div>
											</td>
										</tr>
									</table>
								</td>
								<td width="10" valign="top"><table width="10" height="100%" border="0" align="right" cellpadding="0" cellspacing="0">
										<tr>
											<td width="10" height="1%" valign="top"><img src="/images/InfiniPlan/cor2.gif" width="10" height="7"></td>
										</tr>
										<tr>
											<td height="99%" valign="top"><img src="/images/InfiniPlan/rvimg.gif" width="10" height="135"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
