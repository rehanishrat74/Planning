<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebForm1"%>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan FAQs</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
 
	<SCRIPT LANGUAGE="JavaScript"> 
		function SpeakText() { 
		 try
     {
        var voice = new ActiveXObject("SAPI.SpVoice");
       	var my_test = " hello how are you "; 
		VoiceObj.Speak( my_test, 1 ); 
    }
     catch(oException){
     alert(oException.message);
     }
 } 
 
	</SCRIPT> 
 	</HEAD>
	
	
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor=white>
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
													<input onclick="SpeakText();" type="button" value="SpeakText"> 
													
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top">
																<P>
																	<asp:Label id="Label1" runat="server">Label</asp:Label></P>
																<P>
																	<asp:Table id="Table1" runat="server"></asp:Table></P>
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
