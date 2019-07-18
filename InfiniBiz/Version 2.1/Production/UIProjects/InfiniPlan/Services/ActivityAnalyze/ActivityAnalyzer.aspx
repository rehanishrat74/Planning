<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ActivityAnalyzer.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.ActivityAnalyzer"%>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ActivityAnalyzer</title>
		<LINK href="../../Library/Styles/Analyzer.css" type="text/css" rel="stylesheet"></LINK>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
		<script language="javascript">
		function SetCursor(me, url)
	{
	 if (!(url==''))
		{
		me.style.cursor='hand'; 
		}
	}
		
		function OpenWindow(cid,stage)
	{
 	if (!(cid==''))
		{
		var page = 'ActivityDetail.aspx?cid='+cid+'&stage='+stage 
		window.open(page, '','toolbar=no,menubar=no,scrollbars=no,resizable=no,status=no,location=no,directories=no,copyhistory=no,height=350,width=550')  ;
		}	
	}
	
	function OpenOrderWindow(OrderID,trackid)
	{
 	if (!(OrderID==''))
		{
		var page = 'orderDetail.aspx?OrderID='+OrderID+ "&TrackID="+trackid;
	//	alert(page);
		window.open(page, '','toolbar=no,menubar=no,scrollbars=no,resizable=no,status=no,location=no,directories=no,copyhistory=no,height=550,width=550')  ;
		}	
	}
	
	function OpenOrderWindowChildReferrer(cid, Sid)
	{
 	if (!(cid==''))
		{
		var page = 'ActivityDetail.aspx?cid='+cid+ "&Sid="+Sid;
	 	//alert(page);
		window.open(page, '','toolbar=no,menubar=no,scrollbars=no,resizable=no,status=no,location=no,directories=no,copyhistory=no,height=350,width=550')  ;
		}	
	}
	
	function callme(o)
	{
	if (o.checked == true)
	{
  
 	document.getElementById("DatePanel").disabled=false;
 	 document.getElementById("lblSelect").disabled=true;
 	 document.getElementById("ddlHisrotyOption").disabled=true; 
 	  document.getElementById("BDPLiteFrom").disabled=false;
 	   document.getElementById("BDPLiteTo").disabled=false;
 	    document.getElementById("imgGo").disabled=false;
 
 	
	}
	if (o.checked ==false )
	{
	document.getElementById("DatePanel").disabled=true;
 document.getElementById("lblSelect").disabled=false ;
 	 document.getElementById("ddlHisrotyOption").disabled=false;
 	  	  document.getElementById("BDPLiteFrom").disabled=true;
 	   document.getElementById("BDPLiteTo").disabled=true;
 	    document.getElementById("imgGo").disabled=true;
	}
	
	}
		</script>
	</HEAD>
	<body>
		<form id="Form2" method="post" runat="server">
			<table height="90%" align="left" cellSpacing="0" cellPadding="0" width="85%" border="0">
				<tr valign="top">
					<td vAlign="top" width="100%" height="100%">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
							 	<td vAlign="top" width="100%">
									<!-- **************************************************************************************************************************** -->
									<!-- Actual Page Contents are to be written here  -->
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td align="center"><asp:panel id="testpanel" width="90%" height="100%" Runat="server" visible=true>
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
																	<TABLE height="100%" width="100%" align="left" border="0"> <!-- Date Row Start -->
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
																											<asp:DropDownList id="ddlHisrotyOption" Runat="server" CssClass="AnalyzerText" Width="50%" AutoPostBack="True">
																												<asp:ListItem Value="Today"></asp:ListItem>
																												<asp:ListItem Value="YesterDay"></asp:ListItem>
																												<asp:ListItem Value="This Week"></asp:ListItem>
																												<asp:ListItem Value="This Month"></asp:ListItem>
																												<asp:ListItem Value="Last Month"></asp:ListItem>
																												<asp:ListItem Value=""></asp:ListItem>
																											</asp:DropDownList></TD>
																										<TD class="AnalyzerText" vAlign="middle" align="center" width="10%">OR</TD>
																										<TD vAlign="top" align="center" width="60%">
																											<TABLE height="1" width="100%" border="0">
																												<TR vAlign="top">
																													<TD class="AnalyzerText" vAlign="middle" align="right" width="20%">
																														<asp:Label id="lblCustom" Runat="server" CssClass="AnalyzerText" Visible="False">Custom Time : </asp:Label><INPUT class="AnalyzerText" id="countrychk" onclick="callme(this)" type="checkbox" runat="server"
																															visible="false" NAME="countrychk">
																													</TD>
																													<TD vAlign="top" align="left" width="80%">
																														<asp:Panel id="DatePanel" Runat="server" Enabled="True">
																															<TABLE height="1" width="95%" align="left" border="0">
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
																		</TR> <!-- Date Row End --> <!-- DDash Row Start  -->
																		<TR vAlign="top" height="1%">
																			<TD>
																				<TABLE class="table_blue_border" id="lnktable" width="99%" align="center" runat="server">
																					<TR align="center">
																						<TD id="tdproduct">
																							<asp:LinkButton id="lbProduct" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																						<TD id="tdorder">
																							<asp:LinkButton id="lbOrders" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																						<TD id="tdvisit">
																							<asp:LinkButton id="lbVisits" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																						<TD id="tdkey">
																							<asp:LinkButton id="lbKeywords" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																						<TD id="tdopp">
																							<asp:LinkButton id="lbOpportunity" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																						<TD id="tdreferrer">
																							<asp:LinkButton id="lbReferrer" onmouseover="this.className='text_style_dghover'; " onmouseout="this.className='AnalyzerText';"
																								runat="server" CssClass="AnalyzerText"></asp:LinkButton></TD>
																					</TR>
																				</TABLE>
																			</TD>
																		</TR> <!--  Dash Row End  --> <!-- Parent dataGrid Row  starts-->
																		<TR vAlign="top" height="99%">
																			<TD align="center">
																				<TABLE border="0">
																					<TR vAlign="top">
																						<TD align="center" colSpan="3">
																							<asp:Label id="lblDate" Runat="server" CssClass="AnalyzerText"></asp:Label><BR>
																						</TD>
																					</TR>
																					<TR>
																						<TD align="center" width="30%">
																							<asp:Label id="lblHeader1" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="blue"></asp:Label></TD>
																						<TD align="center" width="40%">
																							<asp:Label id="lblHeader" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="blue"></asp:Label></TD>
																						<TD align="right" width="30%">
																							<asp:Label id="lblCountry" Runat="server" CssClass="AnalyzerText" Visible="False">Country :</asp:Label>
																							<asp:DropDownList id="ddlCountry" Runat="server" CssClass="AnalyzerText" Width="60%" AutoPostBack="True"
																								Visible="False">
																								<asp:ListItem Value="Today">Today</asp:ListItem>
																							</asp:DropDownList>&nbsp;&nbsp;
																						</TD>
																					</TR>
																					<TR>
																						<TD colSpan="3">
																							<asp:Panel id="overviewpanel" Runat="server" Visible="False">
																								<DIV class="AnalyzerOverView" id="viewDiv">
																									<asp:DataGrid id="dgOverView" Runat="server" width="100%" CssClass="table_gray_border" Visible="False"
																										AutoGenerateColumns="true" GridLines="Both" AllowSorting="false">
																										<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																										<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																										<AlternatingItemStyle HorizontalAlign="Center" CssClass="AnalyzerText" BackColor="#F3F3F3"></AlternatingItemStyle>
																									</asp:DataGrid></DIV>
																							</asp:Panel><BR>
																							<DIV class="AnalyzerParentGrid" id="ParentDiv">
																								<asp:Label id="lblNo" Runat="server" CssClass="AnalyzerTextMagnify" ForeColor="#006699"></asp:Label>
																								<asp:DataGrid id="dgParent" Runat="server" width="100%" CssClass="table_gray_border" Visible="True"
																									AutoGenerateColumns="true" GridLines="Both" AllowSorting="false">
																									<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																									<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																									<AlternatingItemStyle HorizontalAlign="Center" CssClass="AnalyzerText" BackColor="#F3F3F3"></AlternatingItemStyle>
																								</asp:DataGrid></DIV>
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
var scrollWidth =  1000//parent.frames['servicesFrame'].document.body.scrollWidth ;
parent.resizeFrame_activityanalyze(scrollHeight,scrollWidth);
}
else 
{
}
		</script>
	</body>
</HTML>
