<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Planing.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Planing"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>InfiniPlan</title>
		<META http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<LINK href="../../Library/Styles/Products.css" type="text/css" rel="stylesheet"></LINK>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
								<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
								<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="90%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" Runat="server" height="100%" width="100%">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top">
																<TABLE class="TableBody" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD height="20"></TD>
																	</TR>
																	<TR>
																		<TD width="2%"></TD>
																		<TD vAlign="top" align="left" width="40%">
																			<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
																				<TR>
																					<TD><SPAN class="Main_Head"><STRONG>InfiniPlan</STRONG></SPAN></TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Create Plan</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">Create a new plan using a step-by-step wizard. The wizard 
																							asks you some questions and based on the answers, creates a template of the 
																							plan for you. You can modify that plan later-on.
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Select Plan </U></STRONG>
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">Select a plan to open it and continue work on that plan. 
																							You can select a sample plan or a plan previously saved by you. Sample plans 
																							are available for your reference. You can also customize the sample plans if 
																							they are closely related to your business. To create a new plan, use the Create 
																							Plan option.</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>My Documents</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The exported plans are maintained using My Document option. 
																							Use this option to access all the exported plans.
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Speedometer Manager</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The Speedometer option gives you a global view of all the 
																							favorite meters.&nbsp; Use this option to quickly access a meter that you had 
																							put in the favorites list.
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="60%">
																			<TABLE class="TableBody" id="Table1" width="100%" align="center" border="0" runat="server">
																				<TR>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgCreate" width="48" height="48" Runat="server" alt="Create"></asp:imagebutton><BR>
																					</TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgSelect" runat="server" width="48" height="48" alt="Select" border="0"></asp:imagebutton><BR>
																					</TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgMyDoc" runat="server" width="48" height="48" alt="Document" border="0"></asp:imagebutton><BR>
																					</TD>
																				</TR>
																				<TR>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%">Create Plan
																					</TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Select Plan</SPAN></TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">My Documents</SPAN></TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																					<TD align="center" width="9%">&nbsp;</TD>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgMeterManager" runat="server" width="48" height="48" alt="Speedometer" border="0"></asp:imagebutton><BR>
																					</TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgText" runat="server" width="48" height="48" alt="Text" border="0"></asp:imagebutton><BR>
																					</TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgTable" runat="server" width="48" height="48" alt="Table" border="0"></asp:imagebutton><BR>
																					</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Speedometers</SPAN></TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Text</SPAN></TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Table</SPAN></TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																					<TD align="center" width="9%">&nbsp;</TD>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgChart" runat="server" width="48" height="48" alt="Chart"></asp:imagebutton></TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgPrint" runat="server" width="48" height="48" alt="Print"></asp:imagebutton></TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgWizard" runat="server" width="48" height="48" alt="Wizard"></asp:imagebutton></TD>
																				</TR>
																				<TR>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%">Chart</TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Print</SPAN>
																					</TD>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%">Plan Wizard
																					</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																					<TD align="center" width="9%">&nbsp;</TD>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgBusinessTracker" runat="server" width="48" height="48" alt="Business Tracker"></asp:imagebutton></TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgMeterWizard" runat="server" width="48" height="48" alt="Meter Wizard"></asp:imagebutton></TD>
																					<TD vAlign="top" align="center" width="9%">
																						<asp:imagebutton id="imgClose" runat="server" width="48" height="48" alt="Close"></asp:imagebutton></TD>
																				</TR>
																				<TR>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%">Business Tracker</TD>
																					<TD vAlign="top" align="center" width="9%"><SPAN class="wizardtext">Meter Wizard </SPAN></TD>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%">Close Plan
																					</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																					<TD align="center" width="9%">&nbsp;</TD>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%" colspan=3>
																						<asp:imagebutton id="imgSamplePlan" runat="server"   alt="Sample Plans" ></asp:imagebutton></TD>
																				 			</TR>
																				<TR>
																					<TD class="wizardtext" vAlign="top" align="center" width="9%" colspan=3>Sample Plans</TD>
																					 
																				</TR>
																				<TR>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																					<TD align="center" width="9%">&nbsp;</TD>
																					<TD vAlign="top" align="center" width="9%">&nbsp;</TD>
																				</TR>
																			</TABLE>
																			<BR>
																			 </TD>
																	</TR>
																	<TR>
																		<TD width="2%"></TD>
																		<TD vAlign="top" align="left" colSpan="2">
																			<TABLE cellSpacing="1" cellPadding="1" width="100%" border="0">
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Text</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The text allow you to give summary of you plan.&nbsp; Use 
																							this option for details about you business and required information.
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Table</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The Table option allow you to put data into tabular form 
																							.&nbsp; In tables computations are performed on you given values and it will 
																							show you corresponding results.
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Charts</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The charts give you a graphical representation of the data 
																							of a particular plan. All the charts of a plan are available here. You can 
																							change the type of charts as well (e.g. from Bar chart to Pie chart etc.)</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Print</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">The charts give you a graphical representation of the data 
																							of a particular plan. All the charts of a plan are available here. You can 
																							change the type of charts as well (e.g. from Bar chart to Pie chart etc.)</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD><SPAN class="Pro_Head2"><STRONG><U>Plan Wizard</U></STRONG></SPAN></TD>
																				</TR>
																				<TR>
																					<TD><SPAN class="Pro_Content2">Plan Wizard option 
                                is used to change the values, entered while 
                                creating a plan. This option works only after a 
                                plan has been opened. </SPAN></TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Business Tracker</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">Business Tracker works in the same way as the speedometer. 
																							It also gives you a comparison between the estimated values and the actual 
																							values, but in a tabular format. Using this option you can have an idea about 
																							how closely the business plan has been followed and how accurate were the 
																							approximate values (entered while creating the plan)</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Meter Wizard</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">When you create a plan you enter estimated values however 
																							after you start your business, the actual values become available. The Meter 
																							Wizard generates a comparison between the actual and estimated values in a 
																							graphical format. Using this option you can have an idea about how closely the 
																							business plan has been followed and how accurate were the approximate values 
																							(entered while creating the plan)
																						</P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>&nbsp;</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Head2"><STRONG><U>Close Plan</U></STRONG></P>
																					</TD>
																				</TR>
																				<TR>
																					<TD>
																						<P class="Pro_Content2">Closing a plan saves it in the InfiniEnterprise system. You 
																							can continue work on that plan at some later time. Once a plan is closed you 
																							can open another plan using Select Plan option. Only one plan can be opened at 
																							a time.
																						</P>
																					</TD>
																				</TR>
																			</TABLE>
																			<P>&nbsp;</P>
																		</TD>
																		<TD width="2%"></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD class="TableBox_Right" width="0%">&nbsp;@</TD>
														</TR>
														<TR>
															<TD class="TableBox_Bot_Left" width="0%"></TD>
															<TD class="TableBox_Bot" width="100%"></TD>
															<TD class="TableBox_Bot_Right" width="0%"></TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
									</table>
									<asp:imagebutton id="ImageButton1" runat="server" Width="40px" Height="38px" src="/images/infiniplan/blank.gif"></asp:imagebutton>
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
