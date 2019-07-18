<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ActivityDetail.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.ActivityDetail"%>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Activity Details</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../../Library/Styles/Analyzer.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
	<script language=javascript>
 
	
	function OpenOrderWindowOrder(OrderID,trackid)
	{
 	if (!(OrderID==''))
		{
		var page = 'orderDetail.aspx?OrderID='+OrderID+ "&TrackID="+trackid;
	//	alert(page);
		window.open(page, '','toolbar=no,menubar=no,scrollbars=no,resizable=no,status=no,location=no,directories=no,copyhistory=no,height=550,width=550')  ;
		}	
	}
	
	
		</script>
	</HEAD>
	
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="99%" cellSpacing="0" cellPadding="0" width="98%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" Runat="server" height="100%" width="100%">
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="/images/InfiniPlan/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top" align=center>
																<asp:Label id="lblHeader" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="#006699"></asp:Label>
																<DIV class="AnalyzerchildGrid" id="ParentDiv">
																	<asp:Label id="lblNo" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="#006699"></asp:Label>
																	<asp:DataGrid id="dgDetail" width="100%" Runat="server" CssClass="table_gray_border" Visible="True"
																		AutoGenerateColumns="true" GridLines="Both" AllowSorting="false">
																		<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																		<AlternatingItemStyle HorizontalAlign="Center" CssClass="wizardtext" BackColor="#F3F3F3"></AlternatingItemStyle>
																	</asp:DataGrid></DIV>
															</TD>
															<TD class="TableBox_Right" width="0%">&nbsp;.</TD>
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
									<!-- Actual Page Contents are to be written upto here  -->
									<!-- **************************************************************************************************************************** --></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
