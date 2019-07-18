<%@ Register TagPrefix="uc1" TagName="PlanWizardNav" Src="PlanWizardNav.ascx" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="StartOption.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.StartOption"%>
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
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" align="centre">
				<tr>
					<td height="19" vAlign="top" colSpan="2">
						<!--        Header Bar  -->
						<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
					</td>
				</tr>
				<tr>
					<td align="center">
						<table border="0">
							<TR>
								<TD vAlign="top" align="right">
								</TD>
								<TD vAlign="top"><INPUT id="hdnIsNew" type="hidden" runat="server" NAME="hdnIsNew"><INPUT id="hdnStatus" runat="server" type="hidden" NAME="hdnStatus">
									<DIV style="WIDTH: 536px; POSITION: relative; HEIGHT: 428px" ms_positioning="GridLayout">
										<asp:label id="lblText" style="Z-INDEX: 100; LEFT: 288px; POSITION: absolute; TOP: 128px" runat="server"
											Width="228px" Height="56px" CssClass="wizardText" BorderWidth="1px" BorderStyle="None"></asp:label><asp:dropdownlist id="cmbDateMonth" style="Z-INDEX: 104; LEFT: 368px; POSITION: absolute; TOP: 248px"
											runat="server" Width="96px" CssClass="wizardOptions"></asp:dropdownlist><asp:textbox id="txtTitle" style="Z-INDEX: 105; LEFT: 368px; POSITION: absolute; TOP: 200px"
											runat="server" Height="20px" Width="152px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px"></asp:textbox><asp:textbox id="txtDateYear" style="Z-INDEX: 106; LEFT: 472px; POSITION: absolute; TOP: 248px"
											runat="server" Width="48px" Height="20px" CssClass="wizardOptions" BorderStyle="Solid" BorderWidth="1px" MaxLength="4"></asp:textbox><asp:button id="btnNext" style="Z-INDEX: 103; LEFT: 352px; POSITION: absolute; TOP: 384px" runat="server"
											Text=" Next " CssClass="wizardButton"></asp:button><asp:button id="btnBack" style="Z-INDEX: 102; LEFT: 288px; POSITION: absolute; TOP: 384px" runat="server"
											Text=" Back " CssClass="wizardButton"></asp:button><asp:button id="btnFinish" style="Z-INDEX: 101; LEFT: 448px; POSITION: absolute; TOP: 384px"
											runat="server" Text=" Finish " CssClass="wizardButton"></asp:button>
										<TABLE id="Table2" style="Z-INDEX: 107; LEFT: 16px; WIDTH: 504px; POSITION: absolute; TOP: 0px; HEIGHT: 104px"
											cellSpacing="0" cellPadding="0" width="504" border="0">
											<TR>
												<TD class="wizardHeader" vAlign="middle" align="center">
													<asp:Label id="Label1" runat="server" Width="332px">InfiniPlan Wizard</asp:Label></TD>
											</TR>
											<TR>
												<TD class="wizardTitle" vAlign="middle" align="center"><asp:label id="lblTitle" runat="server" Width="378px">Plan title and start date</asp:label></TD>
											</TR>
										</TABLE>
										<DIV class="tableBorder" style="Z-INDEX: 108; LEFT: 16px; WIDTH: 256px; POSITION: absolute; TOP: 120px; HEIGHT: 261px"
											ms_positioning="GridLayout">
											<asp:label id="lblHelp" style="Z-INDEX: 119; LEFT: 8px; POSITION: absolute; TOP: 8px" runat="server"
												CssClass="wizardHelp" Height="245" Width="241">Kindly choose a name for your business plan, which will appear as title on the header of all the pages, including the cover page. Also provide a start date from which you will start working according to your plan.</asp:label></DIV>
										<asp:button id="btnCancel" style="Z-INDEX: 109; LEFT: 32px; POSITION: absolute; TOP: 384px"
											runat="server" Text="Cancel" CssClass="wizardButton" CausesValidation="False"></asp:button>
										<asp:Label id="lblError" style="Z-INDEX: 110; LEFT: 296px; POSITION: absolute; TOP: 320px"
											runat="server" Height="24px" Width="216px" cssclass="lblMultiOption_Style"></asp:Label>
										<asp:label id="Label2" style="Z-INDEX: 111; LEFT: 288px; POSITION: absolute; TOP: 208px" runat="server"
											BorderStyle="None" BorderWidth="1px" CssClass="wizardText" Height="16px" Width="64px">Plan title</asp:label>
										<asp:label id="Label3" style="Z-INDEX: 112; LEFT: 288px; POSITION: absolute; TOP: 248px" runat="server"
											BorderStyle="None" BorderWidth="1px" CssClass="wizardText" Height="16px" Width="64px">Start date</asp:label>
									</DIV>
								</TD>
							</TR>
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
