<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CompanyProfile.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.CompanyProfile" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>CompanyProfile</title>
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
				<tr align="left" valign="top">
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Company 
														summary
													</div>
												</td>
											</tr>
											<tr>
												<td height="72" valign="top"><div align="center">
														<asp:HyperLink id="hypCompanySummary" Runat="server" ImageUrl="/images/InfiniPlan/Map/Company-Summary.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Text/PlanText.aspx?hid=U_9"></asp:HyperLink>
													</div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">Write the summary of the 
														company e.g. how it was formed and by whom.</div>
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Company 
														Ownership
													</div>
												</td>
											</tr>
											<tr>
												<td height="72" valign="top"><div align="center">
														<asp:HyperLink id="hypcompanyownership" Runat="server" ImageUrl="/images/InfiniPlan/Map/companyownership.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Text/PlanText.aspx?hid=U_10"></asp:HyperLink>
													</div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><div align="left">Write the details about the 
														company’s ownership.</div>
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
											<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Company 
													History
												</div>
											</td>
										</tr>
										<tr>
											<td height="72" valign="top"><div align="center">
													<asp:HyperLink id="hypcompnayhistory" Runat="server" ImageUrl="/images/InfiniPlan/Map/compnayhistory.gif"
														width="48" height="47" NavigateUrl="/InfiniPlan/Services/Text/PlanText.aspx?hid=U_11"></asp:HyperLink>
												</div>
											</td>
										</tr>
										<tr>
											<td height="1%" valign="top" class="text"><div align="left">Write a brief history about 
													the company.</div>
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
				<tr align="left" valign="top">
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
												<td height="1%" valign="top" background="/images/InfiniPlan/tbg.gif"><div align="center" class="heading">Company 
														Location &amp; Facilities
													</div>
												</td>
											</tr>
											<tr>
												<td height="60" valign="top"><div align="center">
														<asp:HyperLink id="hypCompanyLocationFacilities" Runat="server" ImageUrl="/images/InfiniPlan/Map/Company-Location-&amp;-Facilities.gif"
															width="48" height="47" NavigateUrl="/InfiniPlan/Services/Text/PlanText.aspx?hid=U_13"></asp:HyperLink>
													</div>
												</td>
											</tr>
											<tr>
												<td height="1%" valign="top" class="text"><p align="left">Write about where the company 
														is located and what facilities it is providing.</p>
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
						</div>
					</td>
					<td><div align="center">
						</div>
					</td>
				</tr>
				<TR valign="top">
					<TD align="center" colSpan="3" valign="top">
						<br>
						<br>
						<A href="/InfiniPlan/Services/Map/Text.aspx"><IMG src="/Images/infiniplan/back.gif" border="0"></A></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
