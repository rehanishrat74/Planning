<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CatagoryAnalytics.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.CatagoryAnalytics"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Category Analyzer</title>
		<LINK href="../../Library/Styles/Analyzer.css" type="text/css" rel="stylesheet"></LINK>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
		<script language="javascript">
  
		
		function OpenWindow(catName)
	{

 	if (!(catName==''))
		{
		var page = 'CategoryDetail.aspx?catName='+catName
		 alert(page);
		 escape(String) 

		window.open(page, '','toolbar=no,menubar=no,scrollbars=no,resizable=no,status=no,location=no,directories=no,copyhistory=no,height=350,width=550')  ;
		}	
	}
	
  
	 
	 function callme(o)
	 {
	alert(o);
	 }
	
	 
		</script>
	</HEAD>
	<body>
		<form id="Form2" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="85%" border="0">
				<tr vAlign="top">
					<td vAlign="top" width="100%" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
							 	<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" Runat="server" height="100%" width="100%">
											
													<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD class="TableBox_Top_Left" height="3"><IMG src="/images/blank.gif" width="16"></TD>
															<TD class="TableBox_Top" height="3">&nbsp;</TD>
															<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
														</TR>
														<TR>
															<TD class="TableBox_Left" width="0%"></TD>
															<TD vAlign="top">
																<AJAX:AJAXPANEL id="AjaxPanel1" runat="server"></AJAX:AJAXPANEL>
																<asp:Panel id="myAnalyzerPanel" Runat="server">
																	<TABLE height="100%" width="100%" align="left" border="1"> <!-- Date Row Start -->
																		<TR vAlign="top" height="1%">
																			<TD align="center"><!-- Date Div Start -->
																				<DIV id="HistoryVisitors">
																					<TABLE width="100%" align="left" border="0">
																						<TR vAlign="top">
																							<TD align="center" colSpan="2">
																								<TABLE class="table_gray_border" width="100%" align="center" border="0">
																									<TR>
																										<TD vAlign="middle" align="center" width="30%">
																											<asp:Label id="lblSelect" Runat="server" CssClass="AnalyzerText">Time : </asp:Label>
																											<asp:DropDownList id="ddlHisrotyOption" Runat="server" CssClass="AnalyzerText" AutoPostBack="True"
																												Width="50%">
																												<asp:ListItem Value="Today"></asp:ListItem>
																												<asp:ListItem Value="YesterDay"></asp:ListItem>
																												<asp:ListItem Value="This Week"></asp:ListItem>
																												<asp:ListItem Value="This Month"></asp:ListItem>
																												<asp:ListItem Value="Last Month"></asp:ListItem>
																												<asp:ListItem Value=""></asp:ListItem>
																											</asp:DropDownList></TD>
																										<TD class="AnalyzerText" vAlign="middle" align="center" width="5%">OR</TD>
																										<TD vAlign="top" align="center" width="50%">
																											<TABLE height="1" width="100%" border="0">
																												<TR vAlign="top">
																													<TD vAlign="top" align="left" width="90%">
																														<asp:Panel id="DatePanel" Runat="server" Enabled="True">
																															<TABLE height="1" width="100%" align="left" border="0">
																																<TR vAlign="top">
																																	<TD class="AnalyzerText" vAlign="top" align="center" width="90%">From&nbsp;
																																		<BDP:BDPLITE id="BDPLiteFrom" runat="server" TextBoxColumns="10"></BDP:BDPLITE>&nbsp;To&nbsp;
																																		<BDP:BDPLITE id="BDPLiteTo" runat="server" TextBoxColumns="10"></BDP:BDPLITE></TD>
																																	<TD width="10%">
																																		<asp:imagebutton id="imgGo" Runat="server" ImageUrl="/images/infiniplan/GO.gif"></asp:imagebutton></TD>
																																</TR>
																															</TABLE>
																														</asp:Panel></TD>
																												</TR>
																											</TABLE>
																										</TD>
																									</TR>
																								</TABLE>
																							</TD>
																						</TR>
																					</TABLE>
																				</DIV> <!-- Date Div end --></TD>
																		</TR> <!-- Date Row End --> <!-- DDash Row Start  --> <!--  Dash Row End  --> <!-- Parent dataGrid Row  starts-->
																		<TR vAlign="top" height="99%">
																			<TD align="center" width=100%>
																				<TABLE border="0">
																					<TR vAlign="top">
																						<TD align="center" width="90%">&nbsp;&nbsp;
																							<asp:Label id="lblDate" Runat="server" CssClass="AnalyzerText"></asp:Label><BR>
																						</TD>
																						<TD align="right" width="10%"  class="AnalyzerText"><A href="/InfiniPlan/Services/ActivityAnalyze/ActivityAnalyzer.aspx" runat="server"
																								 >Advance</A> &nbsp;</TD>
																					</TR>
																					<TR>
																						<TD colSpan="4">
																							<DIV class="CatagoryParentGrid" id="ParentDiv">
																								<asp:Label id="lblNo" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="#006699"></asp:Label><BR>
																								<TABLE width="100%">
																									<TR>
																										<TD align="left" width="100%">
																											<asp:DataGrid id="dgCatagory" width="100%" Runat="server" CssClass="table_gray_border" Visible="True"
																												AllowSorting="false" GridLines="Both" AutoGenerateColumns="true">
																												<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																												<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																												<AlternatingItemStyle HorizontalAlign="Center" CssClass="AnalyzerText" BackColor="#F3F3F3"></AlternatingItemStyle>
																											</asp:DataGrid></TD>
																									</TR>
																								</TABLE>
																							</DIV>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR> <!--Parent dataGrid Row end--> <!--child  dataGrid Row  starts--> <!--child dataGrid Row  starts--></TABLE>
																</asp:Panel></TD>
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
		<script>
		
		
		if ( document.domain == 'enterprise.infinimation.com')
{
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100 ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth ;
parent.resizeFrame(scrollHeight,scrollWidth);
}
else 
{
}
		</script>
	</body>
</HTML>
