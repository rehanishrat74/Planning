<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="CategoryDetail.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.CategoryDetail"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Category Details</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES>
		<LINK href="../../Library/Styles/Analyzer.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript">
		</script>
		<script language="javascript">
		function Toggle2(count)
		{
		//alert(1);
			var index = "trTest" + count;
			var ctr = document.getElementById(index)
			//alert(ctr);
			if (document.getElementById(index).style.display=="none" )
			{
				//alert(2);
				ctr.style.display='' 
				document.getElementById("imgToggle").src="/images/infiniplan/toggleDLminus.gif"
			}
			else {
			//alert(3);
			ctr.style.display='none' 
			document.getElementById("imgToggle").src="/images/infiniplan/toggleDLplus.gif"
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
															<TD vAlign="top" align="center">
																<asp:Label id="lblHeader" Runat="server" ForeColor="#006699" CssClass="AnalyzerTextMagnify"></asp:Label>
																<DIV class="AnalyzerchildGrid" id="ParentDiv">
																	<asp:Label id="lblNo" Runat="server" ForeColor="#006699" CssClass="AnalyzerTextMagnify"></asp:Label>
																	<asp:DataGrid id="dgCategoryDetail1" width="100%" Runat="server" CssClass="table_gray_border"
																		AllowSorting="false" GridLines="Both" AutoGenerateColumns="true" Visible="True">
																		<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																		<AlternatingItemStyle HorizontalAlign="Center" CssClass="wizardtext" BackColor="#F3F3F3"></AlternatingItemStyle>
																	</asp:DataGrid>
																	<asp:DataGrid id="dgCategoryDetail" width="100%" Runat="server" CssClass="table_gray_border" AllowSorting="false"
																		GridLines="Both" AutoGenerateColumns="False" Visible="True">
																		<HeaderStyle HorizontalAlign="Center" CssClass="text_style_dg" BackColor="Gainsboro"></HeaderStyle>
																		<ItemStyle HorizontalAlign="Center" CssClass="AnalyzerText"></ItemStyle>
																 
																		<Columns>
																			<asp:TemplateColumn>
																				<HeaderTemplate>
																					<table width="100%" border='1' cellspacing='0' cellpadding='0' bordercolor="white"  >
																						<tr>
																						<td align="center" width="1px" > &nbsp;&nbsp; 
																								 
																							</td>
																							<td align="center" width="15%">
																								<asp:Label ID="Label48" Runat="server" CssClass="wizardtext"  Font-Bold=True > Date.</asp:Label>
																							</td>
																							<td align="center" width="13%">
																								<asp:Label ID="Label49" Runat="server" CssClass="wizardtext" Font-Bold=True  > InfinimeID </asp:Label>
																							</td>
																							<td align="center" width="26%">
																								<asp:Label ID="Label50" Runat="server" CssClass="wizardtext"  Font-Bold=True > Name</asp:Label>
																							</td>
																							<td align="center" width="18%">
																								<asp:Label ID="Label53" Runat="server" CssClass="wizardtext"  Font-Bold=True > Address</asp:Label>
																							</td>
																							<td align="center" width="46%">
																								<asp:Label ID="Label54" Runat="server" CssClass="wizardtext"  Font-Bold=True >Contract</asp:Label>
																							</td>
																							
																							 
																						</tr>
																					</table>
																				</HeaderTemplate>
																				<ItemTemplate>
																					<table width="100%" cellspacing='0' cellpadding='0' border="1" bordercolor='#f5f5f5'  >
																						<tr>
																						<td align="center" width="1px" >  
																							<img onclick="Toggle2(<%# DataBinder.Eval(Container.DataItem, "Sr")%>)" src="/images/infiniplan/toggleDLplus.gif" id=imgToggle>
																						</td>
																						<td align="center" width="15%">
																								<asp:Label ID="Label56" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Date")%>
																								</asp:Label></td>
																							<td align="center" width="13%">
																								<asp:Label ID="Label57" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "InfinimeID")%>
																								</asp:Label></td>
																							<td align="center" width="26%">
																								<asp:Label ID="Label58" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Name")%>
																								</asp:Label>
																							</td>
																							<td align="center" width="18%">
																								<asp:Label ID="Label59" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Address")%>
																								</asp:Label>
																							<td align="center" width="28%">
																								<asp:Label ID="Label60" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Email")%>
																								</asp:Label><br>
																								<asp:Label ID="Label7" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Contract")%>
																								</asp:Label>
																								
																								</td>
																						</tr>
																						<tr id="trTest<%# DataBinder.Eval(Container.DataItem, "Sr")%>" style="Display:none" >
																							 <td width="1px"></td>
																							 <td colspan=5>
																							 <table border=1    bordercolor=WhiteSmoke    align=center  width=100%>
																							 <tr bgcolor=WhiteSmoke>
																							 <td width="33%" align=center >
																								<asp:Label ID="Label4" Runat="server" CssClass="wizardtext" Font-Bold=True>
																								 Product Name 
																								</asp:Label>
																							
																							</td>
																							<td width="33%" align=center >
																								<asp:Label ID="Label5" Runat="server" CssClass="wizardtext" Font-Bold=True>
																									 Code 
																								</asp:Label>
																							
																							</td>
																							<td width="33%" align=center >
																								<asp:Label ID="Label6" Runat="server"	CssClass="wizardtext" Font-Bold=True>
																								 Product ID
																								</asp:Label>
																							
																							</td>
																							 </tr>
																							 
																							 <tr>
																							 <td width="33%" align=center >
																								<asp:Label ID="Label1" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "ProductName")%>
																								</asp:Label>
																							
																							</td>
																							<td width="33%" align=center >
																								<asp:Label ID="Label2" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Code")%>
																								</asp:Label>
																							
																							</td>
																							<td width="33%" align=center >
																								<asp:Label ID="Label3" Runat="server" CssClass="wizardtext">
																									<%# DataBinder.Eval(Container.DataItem, "Product_id")%>
																								</asp:Label>
																							
																							</td>
																							 </tr></table>
																							 
																							 </td>
																							
																							
																						</tr>
																					</table>
																				</ItemTemplate>
																			</asp:TemplateColumn>
																		</Columns>
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
