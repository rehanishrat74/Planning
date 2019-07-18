<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PlanManager.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.PlanManager"%>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls"%>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Plan Manager</title>
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
						<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
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
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" width="97%" bgColor="#f3f3f3" height="19"><asp:label id="lblHeading" runat="server" CssClass="lblHeading" Width="97%">Sample Plan</asp:label>
													<asp:button id="Button1" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																					runat="server" Width="10%" Visible=False  Font-Size="8pt" Text="enterprise" Cssclass="MBUTTONACCPRO"></asp:button>
																					<asp:button id="Button2" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																					runat="server" Width="10%" Visible=False   Font-Size="8pt" Text="iooffice" Cssclass="MBUTTONACCPRO"></asp:button>
											</td>
										</tr>
										<tr>
											<td align="center"><asp:panel id="testpanel" Runat="server" width="100%" height="100%">
													<TABLE dir="ltr" height="99%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top">
																<asp:panel id="pnlSamplePlans" runat="server" CssClass="TDPlanManager_Style" Width="100%" Visible="True">
																	<TABLE height="100%" width="100%" align="center" border="0">
																		<TR vAlign="top" height="15%">
																			<TD>
																				<TABLE class="GridBody" height="100%" width="100%" bgColor="#f3f3f3" border="0">
																					<TR vAlign="middle">
																						<TD vAlign="middle" align="left" width="7%">
																							<asp:Label id="Label3" runat="server" CssClass="wizardText">
																								<b>Plan Name</b></asp:Label></TD>
																						<TD vAlign="middle" align="left" width="22%">
																							<asp:TextBox id="txtPlanName" runat="server" CssClass="txtbox" Width="100%"></asp:TextBox></TD>
																						<TD vAlign="middle" align="center" width="1%">
																							<asp:ImageButton id="btnGo" runat="server" ToolTip="Search" ImageUrl="/images/InfiniPlan/GO.gif"></asp:ImageButton>
																							
																						</TD>
																				 
																						<TD vAlign="middle" width="30%" align=center>
																							<DIV class="sampleplanhelp"><IMG id="imgerror" src="/images/infiniplan/error.gif" runat="server" visible="false">
																								<asp:label id="lblerror" CssClass="lblErrorMessage1" Runat="server" visible="false"></asp:label></DIV>
																						</TD>
																						<td width="10%" align=right><asp:linkButton id="btnAdvSearch" runat="server"> </asp:linkButton></td>
																					</TR>
																					<TR vAlign="middle">
																						<TD vAlign="middle" align="left" colSpan="5">
																							<asp:label id="lblMyPlan" Runat="server" CssClass="wizardText"></asp:label><BR>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR>
																		<TR height="75%">
																			<TD class="TDPlanManager_Style" width="100%"><!-- SamplePlanGrid -->
																				<asp:panel id="Panel2" runat="server" Width="100%" Visible="True" Height="275">
																				
																	<asp:datagrid cssclass="GridBody" id="ExistingPlanGrid" runat="server" Visible="True" PageSize="10"
																						CellPadding="3" AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True" width="100%">
																						<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																						<ItemStyle CssClass="GridInnerLines"></ItemStyle>
																						<HeaderStyle CssClass="GridHeaderBar" Height="10"></HeaderStyle>
																						<Columns>
																							<asp:BoundColumn Visible="False" DataField="PlanID" HeaderText="PlanId"></asp:BoundColumn>
																							<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%" ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif"
																								ItemStyle-Font-Size="10">
																								<ItemTemplate>
																									<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenPlan.aspx?pid={0}") %>' ID="Hyperlink2">
																									</asp:HyperLink>
																								</ItemTemplate>
																							</asp:TemplateColumn>
																							<asp:BoundColumn DataField="BusinessDescription" HeaderStyle-Width="40%" ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif"
																								ItemStyle-Font-Size="7.5">
																								<HeaderStyle Width="40%" HorizontalAlign="Left"></HeaderStyle>
																							</asp:BoundColumn>
																							<asp:BoundColumn DataField="DateCreated" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="10"
																								HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif"
																								ItemStyle-Font-Size="7.5"></asp:BoundColumn>
																							<asp:TemplateColumn>
																								<HeaderStyle Width="15%" HorizontalAlign="left"></HeaderStyle>
																								<ItemStyle HorizontalAlign="left"></ItemStyle>
																								<ItemTemplate>
																									<asp:ImageButton ID="Delete" Runat="server" ImageUrl="/images/InfiniPlan/del.gif" CommandName="Delete"
																										Height="10" Width="25"></asp:ImageButton>
																								</ItemTemplate>
																								<FooterStyle HorizontalAlign="Center"></FooterStyle>
																							</asp:TemplateColumn>
																							<asp:BoundColumn Visible="False" DataField="PlanID"></asp:BoundColumn>
																						</Columns>
																						<PagerStyle cssclass="ExportedPlans_PagerStyle1" HorizontalAlign="Left" Font-Italic="True" Mode="NumericPages"></PagerStyle>
																					</asp:datagrid>
																					
																					<asp:datagrid cssclass="GridBody" id="SamplePlanGrid" runat="server" Visible="False" PageSize="10"
																						CellPadding="3" AutoGenerateColumns="False" GridLines="Vertical" AllowPaging="True" width="100%">
																						<AlternatingItemStyle CssClass="alternatingrowitem"></AlternatingItemStyle>
																						<ItemStyle CssClass="GridInnerLines"></ItemStyle>
																						<HeaderStyle CssClass="GridHeaderBar" Height="10"></HeaderStyle>
																						<Columns>
																							<asp:TemplateColumn HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="40%" ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif"
																								ItemStyle-Font-Size="10">
																								<ItemTemplate>
																									<asp:HyperLink runat="server" cssclass="leftlink" Text='<%# DataBinder.Eval(Container, "DataItem.BusinessName") %>' NavigateUrl='<%# DataBinder.Eval(Container, "DataItem.PlanID", "/InfiniPlan/Services/Plan/OpenSamplePlans.aspx?pid={0}") %>' ID="Hyperlink4" NAME="Hyperlink2">
																									</asp:HyperLink>
																								</ItemTemplate>
																							</asp:TemplateColumn>
																							<asp:BoundColumn DataField="BusinessDescription" HeaderStyle-Width="60%" ItemStyle-Font-Names="Verdana, Arial, Helvetica, sans-serif"
																								ItemStyle-Font-Size="7.5">
																								<HeaderStyle Width="75%" HorizontalAlign="Left"></HeaderStyle>
																							</asp:BoundColumn>
																						</Columns>
																						<PagerStyle cssclass="ExportedPlans_PagerStyle1" HorizontalAlign="Left" Font-Italic="True" Mode="NumericPages"></PagerStyle>
																					</asp:datagrid>
																				</asp:panel><!-- SamplePlanGrid --></TD>
																		</TR>
																		<TR height="15%">
																			<TD align="center">
																				<asp:button id="BtnBack" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
																					runat="server" Width="10%" Visible="False" Font-Size="8pt" Text="Back" Cssclass="MBUTTONACCPRO"></asp:button></TD>
																		</TR>
																	</TABLE>
																</asp:panel></TD>
															<TD class="TableBox_Right" width="0%">&nbsp;@</TD>
														</TR>
														<TR>
															<TD class="TableBox_Bot_Left" width="0%"></TD>
															<TD class="TableBox_Bot" width="100%"></TD>
															<TD class="TableBox_Bot_Right" width="0%"></TD>
														</TR>
													</TABLE>
												</asp:panel>
										
												</td>
										</tr>
									</table>
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
<script>
if ( document.domain == 'enterprise.infinimation.com')
{
 document.domain =  'infinimation.com'
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
parent.resizeFrame(scrollHeight,scrollWidth);
  }
else 
{
}		</script>