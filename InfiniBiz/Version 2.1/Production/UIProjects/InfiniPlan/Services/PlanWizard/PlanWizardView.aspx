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
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="white"
				border="0">
				<tr id="trTopMain" runat="server">
					<td vAlign="top" colSpan="2" height="19">
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
				</tr>
				<tr>
					<td id="tdLeftMain" vAlign="top" width="1%" runat="server"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
					<td vAlign="top" align="center" bgColor="#f3f3f3"><asp:label id="lblHeader" runat="server" Width="100%" CssClass="lblHeading">Plan Wizard</asp:label>
						<table height="96%" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="white"
							border="0">
							<tr>
								<td vAlign="top" align="center" colSpan="5" height="1"><IMG height="5" src="/images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<!--start-->
							<tr>
								<td align="center">
									<table dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></td>
											<td class="TableBox_Top" height="3">&nbsp;</td>
											<td class="TableBox_Top_Right" height="3">&nbsp;</td>
										</tr>
										<tr>
											<td class="TableBox_Left" width="0%"></td>
											<td vAlign="top" height="100%">
												<table height="100%" cellSpacing="0" cellPadding="0" border="0">
													<tr>
														<td>&nbsp;</td>
													</tr>
													<TR vAlign="middle">
														<TD vAlign="top" align="right" class=wizardtext><uc1:planwizardnav id="PlanWizardNav1" runat="server"></uc1:planwizardnav></TD>
														<TD vAlign="top"><INPUT id="hdnIsNew" type="hidden" name="hdnIsNew" runat="server"><INPUT id="hdnStatus" type="hidden" name="hdnStatus" runat="server">
															<DIV style="WIDTH: 492px; POSITION: relative; HEIGHT: 430px" ms_positioning="GridLayout"><asp:label id="lblText" style="Z-INDEX: 101; LEFT: 280px; POSITION: absolute; TOP: 120px" runat="server"
																	Width="228px" CssClass="wizardText" BorderStyle="None" BorderWidth="1px" Height="56px">Label</asp:label><asp:radiobutton id="optFirst" style="Z-INDEX: 103; LEFT: 288px; POSITION: absolute; TOP: 208px"
																	runat="server" Width="144px" CssClass="wizardOptions" GroupName="optionSelect"></asp:radiobutton><asp:radiobutton id="optSecond" style="Z-INDEX: 106; LEFT: 288px; POSITION: absolute; TOP: 240px"
																	runat="server" Width="144px" CssClass="wizardOptions" GroupName="optionSelect"></asp:radiobutton><asp:radiobutton id="optThird" style="Z-INDEX: 107; LEFT: 288px; POSITION: absolute; TOP: 272px"
																	runat="server" Width="144px" CssClass="wizardOptions" GroupName="optionSelect"></asp:radiobutton><asp:dropdownlist id="cmbDateMonth" style="Z-INDEX: 108; LEFT: 288px; POSITION: absolute; TOP: 200px"
																	runat="server" Width="96px" CssClass="wizardOptions"></asp:dropdownlist><asp:textbox id="txtAnswer" style="Z-INDEX: 109; LEFT: 288px; POSITION: absolute; TOP: 200px"
																	runat="server" Width="152px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px" Height="20px"></asp:textbox><asp:textbox id="txtDateYear" style="Z-INDEX: 110; LEFT: 392px; POSITION: absolute; TOP: 200px"
																	runat="server" Width="48px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px" Height="20px" MaxLength="4"></asp:textbox><asp:button id="btnNext" onmouseover="this.className='MBUTTONACCPROON';" style="Z-INDEX: 105; LEFT: 264px; POSITION: absolute; TOP: 392px"
																	onmouseout="this.className='MBUTTONACCPRO';" runat="server" Cssclass="MBUTTONACCPRO"></asp:button><asp:button id="btnBack" onmouseover="this.className='MBUTTONACCPROON';" style="Z-INDEX: 104; LEFT: 152px; POSITION: absolute; TOP: 392px"
																	onmouseout="this.className='MBUTTONACCPRO';" runat="server" Cssclass="MBUTTONACCPRO"></asp:button><asp:button id="btnFinish" onmouseover="this.className='MBUTTONACCPROON';" style="Z-INDEX: 102; LEFT: 368px; POSITION: absolute; TOP: 392px"
																	onmouseout="this.className='MBUTTONACCPRO';" runat="server" Cssclass="MBUTTONACCPRO"></asp:button><asp:label id="lblUnit" style="Z-INDEX: 111; LEFT: 336px; POSITION: absolute; TOP: 200px" runat="server"
																	Width="48px" CssClass="wizardOptions" Height="20px"></asp:label>
																<TABLE id="Table2" style="Z-INDEX: 112; LEFT: 16px; POSITION: absolute; TOP: 0px; HEIGHT: 104px"
																	cellSpacing="0" cellPadding="0" width="490" border="0">
																	<TR>
																		<TD class="wizardHeader1" vAlign="middle" align="center"><asp:label id="lblPlanWizardHeading" runat="server" Width="332px"></asp:label></TD>
																	</TR>
																	<TR>
																		<TD class="wizardTitle1" vAlign="middle" align="center"><asp:label id="lblTitle" runat="server" Width="378px">Label</asp:label></TD>
																	</TR>
																</TABLE>
																<DIV class="tableBorder1" style="Z-INDEX: 113; LEFT: 16px; WIDTH: 256px; POSITION: absolute; TOP: 120px; HEIGHT: 261px"
																	ms_positioning="GridLayout"><asp:label id="lblHelp" style="Z-INDEX: 119; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
																		Width="241" CssClass="wizardHelp" Height="245"></asp:label></DIV>
																<asp:button id="btnCancel" onmouseover="this.className='MBUTTONACCPROON';" style="Z-INDEX: 114; LEFT: 32px; POSITION: absolute; TOP: 392px"
																	onmouseout="this.className='MBUTTONACCPRO';" runat="server" Cssclass="MBUTTONACCPRO" CausesValidation="False"></asp:button><asp:label id="lblError" style="Z-INDEX: 115; LEFT: 296px; POSITION: absolute; TOP: 320px"
																	runat="server" Width="216px" Height="24px" cssclass="lblMultiOption_Style"></asp:label><asp:dropdownlist id="DDlCurrency" style="Z-INDEX: 116; LEFT: 280px; POSITION: absolute; TOP: 176px"
																	runat="server" CssClass="wizardOptions"></asp:dropdownlist></DIV>
														</TD>
													</TR>
												</table>
											</td>
											<td class="TableBox_Right" width="0%">aa
											</td>
										</tr>
										<tr>
											<td class="TableBox_Bot_Left" width="0%"></td>
											<td class="TableBox_Bot" width="100%"></td>
											<td class="TableBox_Bot_Right" width="0%"></td>
										</tr>
									</table>
								</td>
							</tr>
							<!--end --></table>
					</td>
				</tr>
				<tr id="trBottomMain" runat="server">
					<td vAlign="bottom" colSpan="2"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
				</tr>
			</table>
		</form>
		<script>
	if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth -20 ;
parent.resizeFrame(scrollHeight,scrollWidth);
 }
 
 else 
 {
 }
		</script>
	</body>
</HTML>
