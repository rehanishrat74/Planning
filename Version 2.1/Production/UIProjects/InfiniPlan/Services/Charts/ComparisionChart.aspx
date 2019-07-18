<%@ OutPutCache Location="None"%>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ComparisionChart.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.ComparisionChart" enableViewState="false" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<HTML xmlns:o>
	<HEAD>
		<title>Comparision Charts</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<link href="../../Library/Styles/MainStyle.css" rel="stylesheet" type="text/css">
			<SCRIPT LANGUAGE="javascript" type="text/javascript">

function changeText()
  {
    
	var x=document.getElementById("cmbPlanProducts")
	document.getElementById("txtHoldValues").innerText=x.options[x.selectedIndex].text;
  }
			</SCRIPT>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<TBODY>
					<tr>
						<td height="100%" vAlign="top">
							<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0">
								<tr>
									<td vAlign="top" width="55" height="462"></td>
									<td vAlign="top" width="100%" height="462">
										<!-- **************************************************************************************************************************** -->
										<!-- Actual Page Contents are to be written here  -->
										<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td height="10" valign="top">
													<asp:Label id="lblMessage" runat="server" CssClass="lblErrorMessage" Width="100%"></asp:Label>
												</td>
											</tr>
											<tr width="100%">
												<td align="center">
													<table height="100%" cellSpacing="0" cellPadding="0" border="0">
														<tr>
															<td class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></td>
															<td class="TableBox_Top" height="3" align="center">&nbsp; &nbsp;</td>
															<td class="TableBox_Top_Right" height="3">&nbsp;</td>
														</tr>
														<tr>
															<td class="TableBox_Left" width="0%" valign="top">
															</td>
															<td height="100%" valign="top" align="center">
																<!-- Center Table -->
																<asp:Panel id="pnlChart" runat="server" Width="664px" Height="440px" HorizontalAlign="Center">
																	<asp:label id="lblHeading" runat="server" Font-Names="tahoma" Font-Bold="True" Font-Underline="True"
																		Font-Size="Medium"></asp:label>
																	<BR>
																	<BR>
																	<asp:TextBox id="txtHoldValues" runat="server" width="0px" BorderStyle="None"></asp:TextBox>
																	<asp:label id="lblChartPeriods" runat="server" Font-Names="tahoma" Font-Bold="True" Font-Size="X-Small"></asp:label>
																	<BR>
																	<BR>
																	<TABLE width="60%">
																		<TR width="100%">
																			<TD align="center" width="40%">
																				<asp:label id="lblPlanProducts" runat="server" CssClass="lblGeneral">  Select a product:</asp:label></TD>
																			<TD width="60%">
																				<asp:DropDownList id="cmbPlanProducts" runat="server" CssClass="wizardoptions" width="100%" onchange="changeText();"
																					AutoPostBack="true"></asp:DropDownList></TD>
																		</TR>
																	</TABLE>
																	<P>
																		<asp:label id="lblSelect" runat="server" Width="24%" CssClass="lblGeneral" Height="20px"></asp:label>
																		<asp:dropdownlist id="cboCharts" runat="server" Width="35%" CssClass="wizardoptions" Height="86px"
																			AutoPostBack="True">
																			<asp:ListItem Value="0">ColumnClustered</asp:ListItem>
																			<asp:ListItem Value="46">Column3D</asp:ListItem>
																			<asp:ListItem Value="47">ColumnClustered3D</asp:ListItem>
																			<asp:ListItem Value="1">ColumnStacked</asp:ListItem>
																			<asp:ListItem Value="2">ColumnStacked100</asp:ListItem>
																			<asp:ListItem Value="49">ColumnStacked1003D</asp:ListItem>
																			<asp:ListItem Value="48">ColumnStacked3D</asp:ListItem>
																			<asp:ListItem Value="6">Line</asp:ListItem>
																			<asp:ListItem Value="7">LineMarkers</asp:ListItem>
																			<asp:ListItem Value="50">Bar3D</asp:ListItem>
																			<asp:ListItem Value="3">BarClustered</asp:ListItem>
																			<asp:ListItem Value="4">BarStacked</asp:ListItem>
																			<asp:ListItem Value="5">BarStacked100</asp:ListItem>
																			<asp:ListItem Value="18">Pie</asp:ListItem>
																			<asp:ListItem Value="58">Pie3D</asp:ListItem>
																			<asp:ListItem Value="19">PieExploded</asp:ListItem>
																			<asp:ListItem Value="59">PieExploded3D</asp:ListItem>
																			<asp:ListItem Value="12">SmoothLine</asp:ListItem>
																			<asp:ListItem Value="13">SmoothLineMarkers</asp:ListItem>
																			<asp:ListItem Value="60">Area3D</asp:ListItem>
																			<asp:ListItem Value="31">AreaStacked100</asp:ListItem>
																		</asp:dropdownlist></P>
																	<IMG 
                        src="DisplayCharts.aspx?fname=<%=cchartFileName%>">
																	<asp:PlaceHolder id="chHolder" runat="server"></asp:PlaceHolder>
																	<CENTER><BR>
																		<asp:button id="btnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																			Cssclass="MBUTTONACCPRO" Runat="server"></asp:button></CENTER>
																</asp:Panel>
																<!-- dsads -->
															</td>
															<td class="TableBox_Right" width="0%">&nbsp;&nbsp;&nbsp;</td>
														</tr>
														<tr width="100%">
															<td class="TableBox_Bot_Left" width="0%"></td>
															<td class="TableBox_Bot" width="100%"></td>
															<td class="TableBox_Bot_Right" width="0%"></td>
														</tr>
													</table>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
		</form>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
