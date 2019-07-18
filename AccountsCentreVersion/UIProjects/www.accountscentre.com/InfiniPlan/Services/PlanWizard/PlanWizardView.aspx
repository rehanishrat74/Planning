<%@ Register TagPrefix="uc1" TagName="PlanWizardNav" Src="PlanWizardNav.ascx" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanWizardView.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanWizardView" %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>PlanWizardView</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body onload="checkStatus()" onunload="unloadWizard()" MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="center">
				<tr>
					<td height="19" vAlign="top" colSpan="2">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td height="6">
					</td>
				</tr>
				<tr>
					<td align="center" vAlign="top"><asp:label id="lblHeader" runat="server" CssClass="lblHeading" Width="100%">Plan Wizard</asp:label>
						<table border="0" width="100%" height="96%" cellpadding="0" cellspacing="0" align="center">
							<tr>
								<td vAlign="top" colSpan="5" height="1" align="center"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<!--start-->
							<tr>
								<td align="center">
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0" dir="ltr">
										<tr>
											<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
											<td class="TableBox_Top" height="3">&nbsp;</td>
											<td class="TableBox_Top_Right" height="3">&nbsp;</td>
										</tr>
										<tr>
											<td class="TableBox_Left" width="0%"></td>
											<td height="100%" valign="top">
												<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR valign="middle">
														<TD vAlign="top" align="right">
															<uc1:PlanWizardNav id="PlanWizardNav1" runat="server"></uc1:PlanWizardNav>
														</TD>
														<TD vAlign="top" align="center"><INPUT id="hdnIsNew" type="hidden" runat="server" NAME="hdnIsNew"><INPUT id="hdnStatus" runat="server" type="hidden" NAME="hdnStatus">
															<DIV style="WIDTH: 592px; POSITION: relative; HEIGHT: 430px" ms_positioning="GridLayout">
																<asp:label id="lblText" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 120px" runat="server"
																	Width="228px" Height="56px" CssClass="wizardText" BorderWidth="1px" BorderStyle="None">Label</asp:label><asp:radiobutton id="optFirst" style="Z-INDEX: 103; LEFT: 288px; POSITION: absolute; TOP: 208px"
																	runat="server" Width="144px" GroupName="optionSelect" CssClass="wizardOptions"></asp:radiobutton><asp:radiobutton id="optSecond" style="Z-INDEX: 106; LEFT: 288px; POSITION: absolute; TOP: 240px"
																	runat="server" Width="144px" GroupName="optionSelect" CssClass="wizardOptions"></asp:radiobutton><asp:radiobutton id="optThird" style="Z-INDEX: 107; LEFT: 288px; POSITION: absolute; TOP: 272px"
																	runat="server" Width="144px" GroupName="optionSelect" CssClass="wizardOptions"></asp:radiobutton><asp:dropdownlist id="cmbDateMonth" style="Z-INDEX: 108; LEFT: 288px; POSITION: absolute; TOP: 200px"
																	runat="server" Width="96px" CssClass="wizardOptions"></asp:dropdownlist><asp:textbox id="txtAnswer" style="Z-INDEX: 109; LEFT: 288px; POSITION: absolute; TOP: 200px"
																	runat="server" Height="20px" Width="152px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px"></asp:textbox><asp:textbox id="txtDateYear" style="Z-INDEX: 110; LEFT: 392px; POSITION: absolute; TOP: 200px"
																	runat="server" Width="48px" Height="20px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px" MaxLength="4"></asp:textbox>
																<asp:button id="btnNext" style="Z-INDEX: 105; LEFT: 264px; POSITION: absolute; TOP: 392px" runat="server"
																	Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"></asp:button><asp:button id="btnBack" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 392px" runat="server"
																	Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"></asp:button><asp:button id="btnFinish" style="Z-INDEX: 102; LEFT: 432px; POSITION: absolute; TOP: 392px"
																	runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"></asp:button>
																<asp:Label id="lblUnit" style="Z-INDEX: 111; LEFT: 336px; POSITION: absolute; TOP: 200px" runat="server"
																	Height="20px" Width="48px" CssClass="wizardOptions"></asp:Label>
																<TABLE id="Table2" style="Z-INDEX: 112; LEFT: 16px; WIDTH: 560px; POSITION: absolute; TOP: 0px; HEIGHT: 104px"
																	cellSpacing="0" cellPadding="0" width="560" border="0">
																	<TR>
																		<TD class="wizardHeader" vAlign="middle" align="center">
																			<asp:Label id="lblPlanWizardHeading" runat="server" Width="332px" /></TD>
																	</TR>
																	<TR>
																		<TD class="wizardTitle" vAlign="middle" align="center"><asp:label id="lblTitle" runat="server" Width="378px">Label</asp:label></TD>
																	</TR>
																</TABLE>
																<DIV class="tableBorder" style="Z-INDEX: 113; LEFT: 16px; WIDTH: 256px; POSITION: absolute; TOP: 120px; HEIGHT: 261px"
																	ms_positioning="GridLayout">
																	<asp:label id="lblHelp" style="Z-INDEX: 119; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
																		CssClass="wizardHelp" Height="245" Width="241"></asp:label></DIV>
																<asp:button id="btnCancel" style="Z-INDEX: 114; LEFT: 32px; POSITION: absolute; TOP: 392px"
																	runat="server" Cssclass="MBUTTONACCPRO" onmouseover="this.className='MBUTTONACCPROON';"
																	onmouseout="this.className='MBUTTONACCPRO';" CausesValidation="False"></asp:button>
																<asp:Label id="lblError" style="Z-INDEX: 115; LEFT: 296px; POSITION: absolute; TOP: 320px"
																	runat="server" Height="24px" Width="216px" cssclass="lblMultiOption_Style"></asp:Label>
																<asp:DropDownList id="DDlCurrency" style="Z-INDEX: 116; LEFT: 280px; POSITION: absolute; TOP: 176px"
																	runat="server" CssClass="wizardOptions"></asp:DropDownList>
															</DIV>
														</TD>
													</TR>
												</table>
											</td>
											<td class="TableBox_Right" width="0%"></td>
										</tr>
										<tr>
											<td class="TableBox_Bot_Left" width="0%"></td>
											<td class="TableBox_Bot" width="100%"></td>
											<td class="TableBox_Bot_Right" width="0%"></td>
										</tr>
									</table>
								</td>
							</tr>
							<!--end -->
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="bottom" colSpan="2">
						<uc1:BizPlanFooter id="BizPlanFooter1" runat="server"></uc1:BizPlanFooter>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
