<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanManagement.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanManagement"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PlanManagement</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="744" border="0" cellspacing="8" cellpadding="0" align="center">
				<tr>
					<td><br>
						<br>
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Create 
														Plan</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><asp:HyperLink  ID="hypCreatePlan" Runat="server" ImageUrl="/images/InfiniPlan/map/Create-Plan.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Plan/CreatePlan.aspx"></asp:HyperLink></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">
														Create your Business Plan by entering its basic details.
													</div>
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Select 
														Plan</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><asp:HyperLink ID="hypSelectPlan" Runat="server" ImageUrl="/images/InfiniPlan/map/select-plan.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Plan/PlanManager.aspx"></asp:HyperLink></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><p align="left">
														Select the business plan whose information you need to view or manage.
													</p>
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
											<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Close 
													Plan</div>
											</td>
										</tr>
										<tr>
											<td height="75" valign="top"><div align="center"><asp:HyperLink ID="hypClosePlan" Runat="server" ImageUrl="/images/InfiniPlan/map/closeplan.gif"
														width="48" height="47" NavigateUrl="/InfiniPlan/Services/welcome.aspx?cmd=7"></asp:HyperLink></div>
											</td>
										</tr>
										<tr>
											<td height="1%" valign="top" class="text">
												<div align="left">Closing the plan will save the changes and will take you out that 
													plan.
												</div>
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Plan 
														Wizard</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><asp:HyperLink ID="hypPlanWizard" Runat="server" ImageUrl="/images/InfiniPlan/map/planwizard.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/welcome.aspx?cmd=4"></asp:HyperLink></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">
														<p>Create and edit any plan feature.</p>
													</div>
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
												<td height="1%" valign="top" style="WIDTH: 143px"><img src="/images/InfiniPlan/b5cor1.gif" width="10" height="7"></td>
											</tr>
											<tr>
												<td height="98%" valign="top" background="/images/InfiniPlan/images/lvbg.gif" style="WIDTH: 143px"><img src="/images/InfiniPlan/lvimg.gif" width="10" height="125"></td>
											</tr>
											<tr>
												<td height="1%" valign="bottom" style="WIDTH: 134px" colSpan="1" rowSpan="1"><img src="/images/InfiniPlan/cor3.gif" width="10" height="10"></td>
											</tr>
										</table>
									</td>
									<td valign="top" background="/images/InfiniPlan/gbg.gif" class="bg"><table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Sample 
														Plans</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><asp:HyperLink ID="hypSamplePlan" Runat="server" ImageUrl="/images/InfiniPlan/map/sampleplan.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Plan/SamplePlan.aspx?"></asp:HyperLink></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">view a list of our already 
														created sample plans.</div>
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Text</div>
												</td>
											</tr>
											<tr>
												<td height="75" valign="top"><div align="center"><asp:HyperLink ID="hypText" Runat="server" ImageUrl="/images/InfiniPlan/map/text.gif" width="48"
															height="47" NavigateUrl="/InfiniPlan/Services/Map/Text.aspx"></asp:HyperLink></div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">
														Enter all the necessary texts related to the business plan.
													</div>
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
					<td colspan='3' align="center"><BR>
						<BR>
						<a href="/InfiniPlan/Services/Map/PlanRoot.aspx"><img border="0" src="/Images/infiniplan/back.gif"></a></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
