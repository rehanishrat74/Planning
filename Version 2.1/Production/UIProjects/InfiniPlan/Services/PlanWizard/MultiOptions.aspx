<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="uc1" TagName="PlanWizardNav" Src="PlanWizardNav.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MultiOptions.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.MultiOptions"%>
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
										<asp:label id="lblText" style="Z-INDEX: 101; LEFT: 32px; POSITION: absolute; TOP: 128px" runat="server"
											Width="486px" Height="56px" CssClass="wizardText" BorderWidth="1px" BorderStyle="None">Please provide the following particulars about your plan which will be displayed on the cover page of the final document.</asp:label><asp:button id="btnNext" style="Z-INDEX: 104; LEFT: 352px; POSITION: absolute; TOP: 384px" runat="server"
											Text=" Next " CssClass="wizardButton"></asp:button><asp:button id="btnBack" style="Z-INDEX: 103; LEFT: 288px; POSITION: absolute; TOP: 384px" runat="server"
											Text=" Back " CssClass="wizardButton"></asp:button><asp:button id="btnFinish" style="Z-INDEX: 102; LEFT: 448px; POSITION: absolute; TOP: 384px"
											runat="server" Text=" Finish " CssClass="wizardButton"></asp:button>
										<TABLE id="Table2" style="Z-INDEX: 105; LEFT: 16px; WIDTH: 504px; POSITION: absolute; TOP: 0px; HEIGHT: 104px"
											cellSpacing="0" cellPadding="0" width="504" border="0">
											<TR>
												<TD class="wizardHeader" vAlign="middle" align="center">
													<asp:Label id="Label1" runat="server" Width="332px">InfiniPlan Wizard</asp:Label></TD>
											</TR>
											<TR>
												<TD class="wizardTitle" vAlign="middle" align="center"><asp:label id="lblTitle" runat="server" Width="378px">Plan Particulars</asp:label></TD>
											</TR>
										</TABLE>
										<asp:button id="btnCancel" style="Z-INDEX: 106; LEFT: 32px; POSITION: absolute; TOP: 384px"
											runat="server" Text="Cancel" CssClass="wizardButton" CausesValidation="False"></asp:button>
										<asp:Label id="lblError" style="Z-INDEX: 107; LEFT: 144px; POSITION: absolute; TOP: 344px"
											runat="server" Height="24px" Width="248px" cssclass="lblMultiOption_Style" ></asp:Label>
										<asp:Label id="Label2" style="Z-INDEX: 108; LEFT: 48px; POSITION: absolute; TOP: 208px" runat="server"
											CssClass="wizardText">Business Name</asp:Label>
										<asp:Label id="Label3" style="Z-INDEX: 109; LEFT: 48px; POSITION: absolute; TOP: 256px" runat="server"
											CssClass="wizardText">Company Business Ownership</asp:Label>
										<asp:Label id="Label4" style="Z-INDEX: 110; LEFT: 48px; POSITION: absolute; TOP: 296px" runat="server"
											CssClass="wizardText">Contact Details</asp:Label>
										<asp:TextBox id="txtBusinessName" style="Z-INDEX: 111; LEFT: 256px; POSITION: absolute; TOP: 208px"
											runat="server"></asp:TextBox>
										<asp:TextBox id="txtOwnership" style="Z-INDEX: 112; LEFT: 256px; POSITION: absolute; TOP: 256px"
											runat="server"></asp:TextBox>
										<asp:TextBox id="txtContact" style="Z-INDEX: 113; LEFT: 256px; POSITION: absolute; TOP: 296px"
											runat="server"></asp:TextBox>
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
