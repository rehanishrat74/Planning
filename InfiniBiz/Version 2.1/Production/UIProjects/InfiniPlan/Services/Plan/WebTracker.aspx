<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ OutputCache Duration="1" VaryByParam="*" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
  <%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebTracker.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebTracker"%>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="uc" TagName="GridControl" Src="../../Include/GridControl.ascx" %>
<HTML>
	<HEAD>
		<title>Web Tracker</title>
		<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<LINK href="../../Library/Styles/infinistyles.css" type="text/css" rel="stylesheet"></LINK>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<script src="../../Library/Scripts/AjaxWebTracker.js" type="text/JavaScript"></script>
		<script language="javascript">
		{
 
			function Loadit(o)
			{
		 	 alter('a');
			var r_id = document.getElementById(o) 
			var id_val = r_id.value
			
			var getidval=document.getElementById("rbUserSelection");
			getidval.value=id_val                                                                                              
			 
			 var panel = document.getElementById("DatePanel")
			document.getElementById("ShowHistory").disabled=false;
			
			
			if (id_val == 1)
			
			 
			{
			if (panel == null) {}
			else 
			{ 
		 
			document.getElementById("DatePanel").disabled=true;
			document.getElementById("BDPLiteFrom").disabled=true; 
			document.getElementById("BDPLiteTo").disabled=true;  
			
			}
			}
	 		
	 		if (id_val == 2)
			{
			if (panel == null) {}
			else 
			{  
 
			}
				document.getElementById("DatePanel").disabled=true;
			document.getElementById("BDPLiteFrom").disabled=true; 
			document.getElementById("BDPLiteTo").disabled=true;  
			}
	 		
	 		if (id_val == 3)
			{
		 	if (panel == null) {}
			else 
			{ 
		 
			}
				document.getElementById("DatePanel").disabled=true;
			document.getElementById("BDPLiteFrom").disabled=true; 
			document.getElementById("BDPLiteTo").disabled=true;  
			}
	 		
	 		if (id_val == 4)
			 
			{
			
			var currentState = document.getElementById("DatePanel").style.display;

			 
			if (panel == null) {  
			 
			}
			else 
			{  
			 	document.getElementById("DatePanel").disabled=false ;
			document.getElementById("BDPLiteFrom").disabled=false ; 
			document.getElementById("BDPLiteTo").disabled=false ;  
		 
			}
			}
			}
 	}
 	
  
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			 
			<table height=700px cellSpacing="0" cellPadding="0" width="100%" border="0" valign="top">
				<tr vAlign="top">
					<td vAlign="top" height="100%"><input id="rbUserSelection" type="hidden" name="rbUserSelection">
						<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
							</tr>
							<tr>
							 		
							 	<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
								<td vAlign="top" width="100%">
									<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td vAlign="top" align="center" height="19"><asp:label id="lblHeading" runat="server" cssclass="lblHeading" Width="100%">Web Tracker</asp:label></td>
										</tr>
										<tr vAlign="top">
											<td vAlign="top" height="19">
												<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td vAlign="top" colSpan="3" height="1"><IMG height="6" src="/images/InfiniPlan/blank.gif" width="1"></td>
													</tr>
													<tr>
														<td vAlign="top" width="0%"></td>
														<td vAlign="top">
															<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="right" border="0">
																<tr vAlign="top">
																	<td vAlign="top" align="right" height="100%"><asp:panel id="testpanel" Runat="server" width="100%" height="100%">
																			<TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
																					<TD class="TableBox_Top" height="3">&nbsp;</TD>
																					<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
																				</TR>
																				<TR vAlign="bottom">
																					<TD class="TableBox_Left" width="0%"></TD>
																					<TD vAlign="top" align="left">&nbsp;  
																				<!--		<IEWC:TABSTRIP id="MainTStrip" style="FONT-WEIGHT: normal" runat="server" Width="73.5%" TabSelectedStyle="width:35%;border:solid 2px #C0C0C0;background:#f5f5f5;padding-left:5px;padding-right:5px;FONT-WEIGHT: bold;"
																							TabHoverStyle="width:35%;background:#f5f5f5;FONT-WEIGHT: bold;" TabDefaultStyle="border:solid 1px #C0C0C0;background:white;padding-left:5px;padding-right:5px;text-align:center"
																							Font-Names="Times New Roman" SepDefaultStyle="border-bottom:solid 0px #C0C0C0;" TargetID="mpHoriz"
																							Font-Size="xsmall" ForeColor="#10436B" Height="7%">
																							<iewc:Tab Text="Online Tracker" DefaultStyle="width:35%;height:12%;"></iewc:Tab>
																							<iewc:TabSeparator></iewc:TabSeparator>
																							<iewc:Tab Text="History Tracker" DefaultStyle="width:35%;height:12%;"></iewc:Tab>
																							<iewc:TabSeparator></iewc:TabSeparator>
																							 
																							<iewc:TabSeparator DefaultStyle="width:100%;"></iewc:TabSeparator>
																						</IEWC:TABSTRIP>
																						<IEWC:MULTIPAGE id="mpHoriz" runat="server" Font-Size="Larger">
																						<IEWC:PAGEVIEW>  <asp:Panel id="myCurrentPanel" Runat="server" CssClass="TrackerBorder">
																							<TABLE height="87%" cellSpacing="0" cellPadding="0" width="95%" align="center" border="0">
																								<TR vAlign="top">
																									<TD vAlign="top" align="center">
																										<TABLE height="95%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																											<TR vAlign="top">
																												<TD vAlign="top">
																													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
																														<TR>
																															<TD align="center">
																																<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																																	<TR>
																																		<TD vAlign="top" align="left" width="25%">
																																			<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="220" align="center"
																																				border="0">
																																				<TR>
																																					<TD>&nbsp;</TD>
																																				</TR>
																																				<TR vAlign="top">
																																					<TD vAlign="top" align="left" colSpan="3">
																																						<P>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG src="/images/InfiniPlan/online-users.png">
																																							<asp:label id="Username" Runat="server" CssClass="lblTracker">
																																			Online Users </asp:label></P>
																																					</TD>
																																				</TR>
																																				<TR>
																																					<TD vAlign="top" align=center  width="230" height="100%">
																																						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
																																							<TR>
																																								<TD height="10"></TD>
																																							</TR>
																																							<TR>
																																								<TD vAlign="top" align=center width="100%">
																																									<DIV class="OnlineUsers_4" id="onlineVisiter"></DIV>
																																								</TD>
																																							<TR>
																																							<TR>
																																								<TD class="text_style2" id="detector" vAlign="middle" height="10"></TD>
																																							</TR>
																																				</TR>
																																			</TABLE>
																																		</TD>
																																		<TD></TD>
																																	</TR>
																																	<TR>
																																		<TD colSpan="3"></TD>
																																	</TR>
																																</TABLE>
																															</TD>
																															<TD vAlign="top" align=center width="75%">
																																<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																																	<TR vAlign="left">
																																		<TD>
																																			<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																																				<TR>
																																					<TD vAlign="top" align="right" height="65"></TD>
																																					<TD vAlign="middle" align="center" height="65"><IMG src="/images/InfiniPlan/user-info.png">
																																						<asp:Label id="userInformation" Runat="server" CssClass="lblTracker"> 	User's Information</asp:Label></TD>
																																				</TR>
																																				<TR>
																																					<TD vAlign="top" align="right"></TD>
																																					<TD vAlign="top" align=center width="100%">
																																						<TABLE id="Table9" height="200" width="100%" border="0">
																																							<TR vAlign="top" height="125">
																																								<TD vAlign="top" align=center>
																																									<DIV class="UserDetail_3" id="userInfo"></DIV>
																																								</TD>
																																							</TR>
																																							<TR height="1%">
																																								<TD vAlign="top">
																																									<DIV id="uHeader" style="DISPLAY: block">
																																										<TABLE borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="492" border="0" text-align="justify">
																																											<TR class="text_style2">
																																											</TR>
																																										</TABLE>
																																									</DIV>
																																								</TD>
																																							</TR>
																																							<TR height="98%">
																																								<TD vAlign="top" height="100" align=center>
																																									<DIV class="UserHistory_4" id="urlHistory"></DIV>
																																								</TD>
																																							</TR>
																																						</TABLE>
																																					</TD>
																																					<TD></TD>
																																				<TR>
																																					<TD vAlign="top" align="right"></TD>
																																					<TD vAlign="top"></TD>
																																					<TD></TD>
																																				</TR>
																																			</TABLE>
																																		</TD>
																																	</TR>
																																</TABLE>
																															</TD>
																														</TR>
																													</TABLE>
																												</TD>
																											</TR>
																										</TABLE>
																									</TD>
																								</TR>
																							</TABLE></TD>
																				</TR>
																			</TABLE>
																		</asp:panel>  </IEWC:PAGEVIEW>
																		<IEWC:PAGEVIEW> -->
																						<ajax:AjaxPanel id="AjaxPanel1" runat="server">
																							<asp:Panel id="myHistoryPanel" Runat="server" CssClass="TrackerBorder_1">
																								<TABLE height="100%" align="left" border="0"  >
																									<TR>
																										<TD align="left">
																											<DIV  class=UserHistory_DatePanel id="HistoryVisitors">
																												<TABLE align="left" border="0" width=100%>
																													<TR> <!--<TD vAlign="top" align="center"   ><IMG src="/images/InfiniPlan/user_history.png">
																												<asp:Label id="Label1" Runat="server" CssClass="lblTracker"><u>History Option</u></asp:Label></TD> -->
																														<TD>
																															<TABLE align="center">
																																<TR align="center">
																																	<TD><IMG src="/images/InfiniPlan/user-info.png">
																																	</TD>
																																	<TD>
																																		<asp:Label id="Label2" Runat="server" CssClass="lblTracker">Total Visitors : </asp:Label></TD>
																																	<TD>&nbsp;
																																		<asp:Label id="Today" Runat="server" CssClass="wizardtext">Today</asp:Label>
																																		<asp:Label id="Se_Today" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																																	<TD>
																																		<asp:Label id="Lastday" Runat="server" CssClass="wizardtext">: Yesterday</asp:Label>
																																		<asp:Label id="Se_LastDay" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																																	<TD>
																																		<asp:Label id="Label13" Runat="server" CssClass="wizardtext">: This Week</asp:Label>
																																		<asp:Label id="Se_CurrentWeek" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																															
																																	<TD>
																																		<asp:Label id="CurrentMonth" Runat="server" CssClass="wizardtext">: This Month</asp:Label>
																																		<asp:Label id="Se_CurrentMonth" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																																	<TD>
																																		<asp:Label id="LastMonth" Runat="server" CssClass="wizardtext">: Last Month</asp:Label>
																																		<asp:Label id="Se_LastMonth" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																																	<TD>
																																		<asp:Label id="Period" Runat="server" CssClass="wizardtext">: Custom</asp:Label>
																																		<asp:Label id="Se_Period" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label></TD>
																																</TR>
																															</TABLE>
																														</TD>
																													</TR>
																													<TR vAlign="top">
																														<TD align="center" colSpan="2">
																															<TABLE align="center"  width=100%  class="table_gray_border2" border=0>
																																 
																																<TR>
																																	<TD align=center  width=50%  >
																																	<asp:Label id="Label8" Runat="server" CssClass="wizardtext">Select Time : </asp:Label>
																																		
																																	
																																		<asp:DropDownList id="ddlHisrotyOption"   Width=70% Runat="server" CssClass="wizardtext" AutoPostBack="True">
																																		 <asp:ListItem Value="Today"></asp:ListItem>
																																			<asp:ListItem Value="YesterDay"></asp:ListItem>
																																			<asp:ListItem Value="This Week"></asp:ListItem>
																																			<asp:ListItem Value="This Month"></asp:ListItem>
																																			<asp:ListItem Value="Last Month"></asp:ListItem>
																																			<asp:ListItem Value="Custom (Use Calander) "></asp:ListItem>
																																		</asp:DropDownList>
																																	<TD vAlign="top" align="center" width=50%>
																																		<TABLE height="1" width="100%" border="0">
																																			<TR vAlign="top">
																																				<TD vAlign="top">
																																					<asp:Panel id="DatePanel" Runat="server" Enabled="False"  >
																																						<TABLE height="1" align="center">
																																							<TR vAlign="top">
																																								<TD class="wizardtext" vAlign="top" align="center">From&nbsp;
																																									<BDP:BDPLITE id="BDPLiteFrom" runat="server" TextBoxColumns="10" enable="false"></BDP:BDPLITE>&nbsp;To&nbsp;
																																									<BDP:BDPLITE id="BDPLiteTo" runat="server" TextBoxColumns="10" enable="false"></BDP:BDPLITE></TD>
																																							</TR>
																																						</TABLE>
																																					</asp:Panel></TD>
																																			</TR>
																																		</TABLE>
																																	</TD>
																																</TR>
																																<TR align="center" valign=top>
																																	<TD align="center" colSpan="2" valign=top>
																																		<asp:LinkButton id="lbtnProduct" runat="server" CssClass="bottomlnk" Enabled="False" Visible="True">
																																			<img src='/images/infiniplan/TrackProduct.png' border="0" />
																																		</asp:LinkButton>&nbsp;
																																		<asp:LinkButton id="lbtnTrackActivity" runat="server" CssClass="bottomlnk" Enabled="False" Visible="True">
																																			<img src='/images/infiniplan/TrackActivity.png' border="0" /></asp:LinkButton> 
																																			&nbsp;
																																		<asp:LinkButton id="lbtnTrackReferrer" runat="server" CssClass="bottomlnk" Enabled="False" Visible="True">
																																			<img src='/images/infiniplan/TrackReferrer.png' border="0" /></asp:LinkButton>
																																			</TD>
																																</TR>
																																<TR>
																																</TR>
																															</TABLE>
																														</TD>
																													</TR>
																												</TABLE>
																											</DIV>
																										</TD>
																									<TR vAlign="top" align="left">
																										<TD vAlign="top" align="left" width="100%">
																											<asp:Label id="lblOption" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label>&nbsp;
																											<DIV  class=UserHistory_5 id="HistoryDetail">
																												<asp:Table id="historytable" width="100%" Runat="server" Border="0" EnableViewState="True"  >
																													<asp:TableRow EnableViewState="True">
																														<asp:TableCell ID="GridCell" EnableViewState="True">
																															 <asp:DataGrid id="dgActivity" Width="100%" Runat="server" CssClass="wizardtext" EnableViewState="True"
																																CellSpacing="0" CellPadding="1" GridLines="Both" AutoGenerateColumns=False AllowSorting="True">
																																<HeaderStyle CssClass="text_style4" ForeColor="#777777"></HeaderStyle>
																																<ItemStyle CssClass="text_style2" Height="22pt"></ItemStyle>
																																<PagerStyle HorizontalAlign="Right" PageButtonCount="15" Mode="NumericPages"></PagerStyle>
																															
																															<Columns>
																																	<asp:TemplateColumn>
																																		<HeaderTemplate>
																																			<table width=100% border='0' cellspacing='0' cellpadding='0'  bordercolor='#f5f5f5'  bgcolor="Gainsboro"> <!--bordercolor='#f5f5f5'-->
																																				<tr>
																					 
																																					<td align="center" width="13%"> 
																																						<asp:Label ID="Label4" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					 																														<td align="center" width="13%">
																																						<asp:Label ID="Label9" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label10" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td>
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID="Label11" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label>
																																				 </td>  <td align=center  width=13%> 		<asp:Label ID="Label12" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label>
																																				 </td>  <td align=center  width=13% colspan=2> 	 <asp:LinkButton id="Linkbutton1" Runat=server  Width=100%   CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="LoadgridActivity"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "Country")%></asp:LinkButton>
																																				 </td></tr>
																					 
																																		<asp:Label ID="lblActCountry" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "Country")%> ></asp:Label>
																		 
																			 															<tr>
																																					<td colspan="7" align="center">
																																						<asp:DataGrid width="95%" ID="childgridActivity" class="table_gray_border"  AutoGenerateColumns=False Runat="server" Visible="False"
																																							GridLines="Both"  OnItemCommand="childgridActivity_ItemCommand"  AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor="#ECF4FC"></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center" CssClass="wizardtext" BackColor=white></ItemStyle>
																																								<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor="#ECF4FC"></AlternatingItemStyle>
																																				<Columns>
																																						<asp:TemplateColumn>
																																		<HeaderTemplate>
																																			<table width=100% border='1'  height=1 cellspacing='0' cellpadding='0' bordercolor=#C0C0C0   > 
																																				<tr>
																																					 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label24" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label26" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label27" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td>
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				   <td align=center  width=13%> <asp:Label ID="Label29" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label>
																																				</td>  <td align=center  width=13%> 		<asp:Label ID="Label31" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label>
																																					</td>  <td align=center  width=13% colspan=2> 	 <asp:LinkButton id="Linkbutton3" Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="LoadInnerGrid"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "Country")%></asp:LinkButton>
																																					</td>
																																				</tr>
																																						
																																					<asp:Label ID="Country_activity" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "Country")%> ></asp:Label>
																																					<asp:Label ID="Label33" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "UniQueSession")%> ></asp:Label>
																			 																		<asp:Label ID="IP_Activity" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "ip")%> ></asp:Label>
																			 																
																			 																	 <tr>
																																					<td colspan="7" align="center">
																																						<asp:DataGrid width=95% ID="childgridActivityDetail" Visible=False class="table_gray_border2"     AutoGenerateColumns=true Runat="server"  
																																							GridLines="Both" AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor=LightBlue ></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor=#F3F3F3>
																																							</AlternatingItemStyle>
																																						 
																																						 
																																						
																																						</asp:DataGrid>
																																					</td>
																																				</tr>
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																						
																																						</Columns>
																																						</asp:DataGrid>
																																					</td>
																																				</tr>
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																</Columns>
																															</asp:DataGrid>
																															</asp:DataGrid> 
																															<asp:DataGrid id="dgProductActivity" Visible="False" Width="100%" CellSpacing="0" CellPadding="1"
																																GridLines="Both" AutoGenerateColumns="False" AllowSorting="True" EnableViewState="True" Runat="server"
																																CssClass="wizardtext" runat="server">
																																<Columns>
																																	<asp:TemplateColumn>
																																		<HeaderTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' bordercolor=#C0C0C0  bgcolor="Gainsboro"> 
																																				<tr>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label7" Runat="server" CssClass="text_style_dg"> Sr.</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label1" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label3" Runat="server" CssClass="text_style_dg"> ProductVisited </asp:Label>
																																					</td>
																																					<!--<td align="center" width="13%">
																																						<asp:Label ID="Label4" Runat="server" CssClass="text_style_dg"  > TotalOrders </asp:Label>
																																					</td>-->
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label5" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label6" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td>
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID=Sr Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Sr")%></asp:Label>
																																					</td> <td align=center  width=13%> <asp:Label ID="UniQueSession" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label>
																																					</td> <td align=center  width=13%> 		<asp:Label ID="ProductVisited" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "ProductVisited")%></asp:Label>
																																						</td> <!--<td align=center  width=13%> 		<asp:Label ID="TotalOrders" Runat=server   ><%# DataBinder.Eval(Container.DataItem, "TotalOrders")%> </asp:Label> 
																																					</td> --><td align=center  width=13%> 		<asp:Label ID="IP" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label>
																																					</td>  <td align=center  width=13% colspan=2> 	 <asp:LinkButton id=lnkbtn Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="LoadInnerGrid"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "Country")%></asp:LinkButton>
																																					</td>
																																				</tr>
																																						
																																					<asp:Label ID="lblCountry" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "Country")%> ></asp:Label>
																																					<asp:Label ID="lblUniQueSession" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "UniQueSession")%> ></asp:Label>
																			 																	 <tr>
																																					<td colspan="7" align="center">
																																						<asp:DataGrid width=95% ID="childgrid" class="table_gray_border2"   OnItemCommand="childgeid_ItemCommand" AutoGenerateColumns=False Runat="server" Visible="False"
																																							GridLines="Both"   AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor="#ECF4FC"></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor=AliceBlue ></AlternatingItemStyle>
																																						<Columns>
																																						<asp:TemplateColumn>
																																					<HeaderTemplate>
																																			<table width=100% border='1'  height=1 cellspacing='0' cellpadding='0' bordercolor=#C0C0C0   > 
																																				<tr>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label14" Runat="server" CssClass="text_style_dg"> Sr.</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label15" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label16" Runat="server" CssClass="text_style_dg"> ProductVisited </asp:Label>
																																					</td>
																																					<!--<td align="center" width="13%">
																																						<asp:Label ID="Label4" Runat="server" CssClass="text_style_dg"  > TotalOrders </asp:Label>
																																					</td>-->
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label17" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label18" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td>
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID="Label19" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Sr")%></asp:Label>
																																					</td> <td align=center  width=13%> <asp:Label ID="Label20" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label>
																																					</td> <td align=center  width=13%> 		<asp:Label ID="Label21" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "ProductVisited")%></asp:Label>
																																						</td> <!--<td align=center  width=13%> 		<asp:Label ID="TotalOrders" Runat=server   ><%# DataBinder.Eval(Container.DataItem, "TotalOrders")%> </asp:Label> 
																																					</td> --><td align=center  width=13%> 		<asp:Label ID="Label22" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label>
																																					</td>  <td align=center  width=13% colspan=2> 	 <asp:LinkButton id="Linkbutton2" Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="LoadInnerGrid"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "Country")%></asp:LinkButton>
																																					</td>
																																				</tr>
																																						
																																					<asp:Label ID="Country_ip" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "Country")%> ></asp:Label>
																																					<asp:Label ID="UniQueSession_ip" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "UniQueSession")%> ></asp:Label>
																			 																		<asp:Label ID="IP_ip" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "ip")%> ></asp:Label>
																			 																
																			 																	 <tr>
																																					<td colspan="7" align="center">
																																						<asp:DataGrid width=95% ID="childgridDetail" Visible=False class="table_gray_border2"     AutoGenerateColumns=true Runat="server"  
																																							GridLines="Both" AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor=LightBlue ></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor=#F3F3F3>
																																							</AlternatingItemStyle>
																																						 
																																						 
																																						
																																						</asp:DataGrid>
																																					</td>
																																				</tr>
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																						
																																						</Columns>
																																						 
																																						 
																																						
																																						</asp:DataGrid>
																																					</td>
																																				</tr>
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																</Columns>
																															</asp:DataGrid>
																															<asp:DataGrid id="dgProductReferrer" Visible="False" Width="100%" CellSpacing="0" CellPadding="1"
																																GridLines="Both" AutoGenerateColumns=False  bgcolor="Gainsboro"    EnableViewState="True" Runat="server"
																																CssClass="wizardtext" runat="server">
																																<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg"   ></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor=#F3F3F3>
																																							</AlternatingItemStyle>
																																						<Columns>
																																	<asp:TemplateColumn>
																																		<HeaderTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' bordercolor=#C0C0C0  bgcolor="Gainsboro"> 
																																				<tr>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label23" Runat="server" CssClass="text_style_dg"> Sid.</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label25" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					  <td align="center" width="26%">
																																						<asp:Label ID="Label30" Runat="server" CssClass="text_style_dg"  > Referrer</asp:Label>
																																					</td> 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label35" Runat="server" CssClass="text_style_dg"> ProductVisited</asp:Label>
																																					</td>
																																					 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label32" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label34" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td >
																																					
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID="Label37" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Sid")%></asp:Label></td> 
																																				<td align=center  width=13%> <asp:Label ID="Label38" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label></td> 
																																				<td align=center  width=26%> 	 <asp:LinkButton id="Linkbutton4" Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="LoadInnerGrid"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "referrer")%></asp:LinkButton></td>
																																				<td align=center  width=13%> 		<asp:Label ID="Label41" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "ProductVisited")%></asp:Label> 
																																				<td align=center  width=13%> 		<asp:Label ID="TotalOrders" Runat=server  CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "country")%> </asp:Label> </td> 
																																				<td align=center  width=13%> 		<asp:Label ID="Label40" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label></td>
																																					
																																				</tr>
																																						
																																					<asp:Label ID="lblReferrer" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "referrer")%> ></asp:Label>
																																					<asp:Label ID="lblUniQueSessionReferrer" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "UniQueSession")%> ></asp:Label>
																			 																	 <tr><td colspan=6 align=center>
																			 																	 
																																						<asp:DataGrid width=95% ID="childgridReferrer" class="table_gray_border2"   OnItemCommand="childgeidReferrer_ItemCommand" AutoGenerateColumns=False Runat="server" Visible="False"
																																							GridLines="Both"   AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor="#ECF4FC"></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																						<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor="#ECF4FC"></AlternatingItemStyle>
																																						<Columns>
																																					 
																																						<asp:TemplateColumn>
																																					<HeaderTemplate>
																																			<table width=100% border='1'  height=1 cellspacing='0' cellpadding='0' bordercolor=#C0C0C0   > 
																																				<tr>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label28" Runat="server" CssClass="text_style_dg"> Sid.</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label36" Runat="server" CssClass="text_style_dg"> UniQueSession </asp:Label>
																																					</td>
																																					  <td align="center" width="26%">
																																						<asp:Label ID="Label39" Runat="server" CssClass="text_style_dg"  > Referrer</asp:Label>
																																					</td> 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label42" Runat="server" CssClass="text_style_dg"> ProductVisited</asp:Label>
																																					</td>
																																					 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label43" Runat="server" CssClass="text_style_dg"> IP </asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label51" Runat="server" CssClass="text_style_dg"> Country </asp:Label>
																																					</td >
																																					
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		<ItemTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' borderColor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID="Label44" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Sid")%></asp:Label></td> 
																																				<td align=center  width=13%> <asp:Label ID="Label45" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label></td> 
																																						<td align=center  width=26%> 		<asp:Label ID="Label47" Runat=server  CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "Referrer")%> </asp:Label> </td> 
																																		
																																				<td align=center  width=13%> 		<asp:Label ID="Label46" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "ProductVisited")%></asp:Label> 
																																					<td align=center  width=13%> 		<asp:Label ID="Label52" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "IP")%></asp:Label></td>
																																				<td align=center  width=13%> 	 <asp:LinkButton id="Linkbutton5" Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="InnerReferrerGrid"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "Country")%></asp:LinkButton></td>
																																				
																																				</tr>
																																						
																																					<asp:Label ID="lblChildReferrer" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "referrer")%> ></asp:Label>
																																					<asp:Label ID="lblChildRefCountry" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "country")%> ></asp:Label>
																			 																		 
																			 																<tr><td align=center colspan=6>
																			 																	 <!-- 3rd grid will come -->
																			 																	 <asp:DataGrid width=95% ID="childgridDetailReferrer" Visible=False class="table_gray_border2"  OnItemCommand="childgridDetailReferrer_ItemCommand"   AutoGenerateColumns=False  Runat="server"  
																																							GridLines="Both" AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor=LightBlue ></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor=LightBlue>
																																							</AlternatingItemStyle>
																																						 <Columns>
																																	<asp:TemplateColumn>
																																		<HeaderTemplate>
																																			<table width=100% border='1' cellspacing='0' cellpadding='0' bordercolor=white   bgcolor=LightBlue> 
																																				<tr>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label48" Runat="server" CssClass="text_style_cdg" BackColor=LightBlue> Sid.</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label49" Runat="server" CssClass="text_style_cdg" BackColor=LightBlue> UniQueSession </asp:Label>
																																					</td>
																																					  <td align="center" width="26%">
																																						<asp:Label ID="Label50" Runat="server" CssClass="text_style_cdg"  BackColor=LightBlue> Referrer</asp:Label>
																																					</td> 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label53" Runat="server" CssClass="text_style_cdg" BackColor=LightBlue> ProductVisited</asp:Label>
																																					</td>
																																					 
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label54" Runat="server" CssClass="text_style_cdg" BackColor=LightBlue>Country</asp:Label>
																																					</td>
																																					<td align="center" width="13%">
																																						<asp:Label ID="Label55" Runat="server" CssClass="text_style_cdg" BackColor=LightBlue>   IP </asp:Label>
																																					</td >
																																					
																																				</tr>
																																			</table>
																																		</HeaderTemplate>
																																		
																																		
																																		<ItemTemplate>
																																			<table width=100%   cellspacing='0' cellpadding='0'  border=1 bordercolor='#f5f5f5'>
																																				<tr>
																																				 <td align=center  width=13%> <asp:Label ID="Label56" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Sid")%></asp:Label></td> 
																																				<td align=center  width=13%> <asp:Label ID="Label57" Runat=server CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "UniQueSession")%></asp:Label></td> 
																																						<td align=center  width=26%> 		<asp:Label ID="Label58" Runat=server  CssClass="wizardtext" ><%# DataBinder.Eval(Container.DataItem, "Referrer")%> </asp:Label> </td> 
																																		
																																				<td align=center  width=13%> 		<asp:Label ID="Label59" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "ProductVisited")%></asp:Label> 
																																					<td align=center  width=13%> 		<asp:Label ID="Label60" Runat=server CssClass="wizardtext"><%# DataBinder.Eval(Container.DataItem, "Country")%></asp:Label></td>
																																				<td align=center  width=13%> 	 <asp:LinkButton id="Linkbutton6" Runat=server  Width=100%    CssClass="wizardtext" onmouseover="this.className='text_style_dghover'; " CommandName="InnerReferrerGridDetail"  onmouseout="this.className='wizardtext1';"> <%# DataBinder.Eval(Container.DataItem, "IP")%></asp:LinkButton></td>
																																				
																																				</tr>
																																						
																																					<asp:Label ID="referrer_Ref" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "referrer")%> ></asp:Label>
																																					<asp:Label ID="referrer_country" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "country")%> ></asp:Label>
																			 																		 <asp:Label ID="referrer_ip" Runat=server  Visible=false  text = <%# DataBinder.Eval(Container.DataItem, "ip")%> ></asp:Label>
																			 																		
																			 																<tr><td align=center colspan=6>
																			 																	 <!-- 3rd grid will come -->
																			 																	 <asp:DataGrid width=95% ID="childgridDetailReferrerbyIP" Visible=False class="table_gray_border2"  AutoGenerateColumns=true Runat="server"  
																																							GridLines="Both" AllowSorting="false">
																																							<HeaderStyle HorizontalAlign="Center" CssClass="text_style_cdg" BackColor=LightSteelBlue  ></HeaderStyle>
																																							<ItemStyle HorizontalAlign="Center"  CssClass="wizardtext"  BackColor=white ></ItemStyle>
																																							<AlternatingItemStyle HorizontalAlign=Center CssClass="wizardtext" BackColor='#f5f5f5'  >
																																							</AlternatingItemStyle></asp:DataGrid></td></tr>
</table>
</ItemTemplate>
																																		
																																		</asp:TemplateColumn>
																																		
																																		</Columns> 
																																						 
																																						
																																						</asp:DataGrid></td></tr>
																			 																	 <!-- /3rd grid will come -->
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																						</Columns>
																																						</asp:DataGrid>
																																					
																			 																	 
																			 																	 </td></tr>
																																			</table>
																																		</ItemTemplate>
																																	</asp:TemplateColumn>
																																</Columns>
																															</asp:DataGrid>
																														</asp:TableCell>
																													</asp:TableRow>
																												</asp:Table></DIV>
																											<asp:Label id="lblHead" Runat="server" CssClass="wizardtext1" Font-Bold="True"></asp:Label>&nbsp;
																											<DIV class="TrackeSessions" id="DetailDiv"><BR>
																												<asp:Table id="SessionTable" width="100%" Runat="server" Border="0"></asp:Table></DIV>
																										</TD>
																									</TR>
																				</TR>
																			</TABLE>
																		</asp:panel></ajax:AjaxPanel> <!--</IEWC:PAGEVIEW> 
															 
															</IEWC:MULTIPAGE> --></td>
																	<TD class="TableBox_Right" width="0%">&nbsp; .</TD>
																</tr>
																<TR vAlign="top">
																	<TD class="TableBox_Bot_Left" width="0%"></TD>
																	<TD class="TableBox_Bot" width="100%"></TD>
																	<TD class="TableBox_Bot_Right" width="0%"></TD>
																</TR>
															</table>
															</asp:panel></td>
													</tr>
												</table>
											</td>
											<td vAlign="top" align="right" width="0%">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</td></tr></table></form>
		<script language="javascript" type="text/javascript">
			Init();
			
		
		</script>
<script>
		
		
		if ( document.domain == 'enterprise.infinimation.com')
{
 
document.domain='infinimation.com';
 var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight +100 ;
var scrollWidth = 1000 //parent.frames['servicesFrame'].document.body.scrollWidth ;
parent.resizeFrame(scrollHeight,scrollWidth);
}
else 
{
}
		</script>
	</body>
</HTML>
