<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="BottomBar" src="Include/BottomBar.ascx"	  %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="index.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.index"%>
<HTML>
	<HEAD>
		<title>Plan Manager</title>
		<BusinessPlan:Files id="file1" runat="server"></BusinessPlan:Files>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
	</HEAD>
	<body class="cngbody">
		<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
			<tr>
				<td height="19" vAlign="top">
					<!--        Header Bar  -->
					<BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR>
				</td>
			</tr>
			<tr>
				<td height="100%" vAlign="top">
					<table width="100%" height="100%" border="0" cellPadding="0" cellSpacing="0">
						<tr>
							<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/InfiniPlan/InfiniPlan/blank.gif" width="1"></td>
						</tr>
						<tr>
							<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
							<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/InfiniPlan/InfiniPlan/blank.gif" width="20"></td>
							<td vAlign="top" width="100%">
								<!-- **************************************************************************************************************************** -->
								<!-- Actual Page Contents are to be written here  -->
								<form id="Form2" method="post" runat="server">
									<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
										<TBODY>
											<tr>
												<td height="19" align="center" valign="top">
												</td>
											</tr>
											<tr>
												<td height="10" valign="top"><img src="../../images/InfiniPlan/InfiniPlan/blank.gif" width="1" height="10"></td>
											</tr>
											<tr>
												<td height="311" valign="top">
									<!-- Center Table -->
								</form>
								<FORM id="Form1" method="post" runat="server">
									<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" align="center" height="19">
												<asp:Label id="lblTableHeading" runat="server" Width="622px" text="Plan Summary"></asp:Label></TD>
										</TR>
										<TR>
											<TD vAlign="top" height="10"><IMG height="10" src="../images/InfiniPlan/InfiniPlan/blank.gif" width="1"></TD>
										</TR>
										<TR>
											<TD vAlign="top" height="260">
												<DIV class="gridSpace" id="gridDiv">&nbsp;</DIV>
												<DIV class="gridSpace">&nbsp;</DIV>
												<DIV class="gridSpace">&nbsp;</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;%</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;%</DIV>
												<DIV class="gridSpace">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;%</DIV> <!-- <%'	<BIZPLAN:BUSINESSGRID id="bgPlanSummary" runat="server" StartYear="1900" StartMonth="1" AutoGenerateBusinessGrid="True"
														'Editable="True" CellSpacing="0" CellPadding="0"></BIZPLAN:BUSINESSGRID> %> --></TD>
										</TR>
										<TR>
											<TD vAlign="top" height="10"><IMG height="10" src="../images/InfiniPlan/InfiniPlan/blank.gif" width="1"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" height="19">
												<asp:Button id="btnUpdate" runat="server" CssClass="buttonStyle" Text="Update Table"></asp:Button></TD>
										</TR>
									</TABLE>
								</FORM>
								<FORM id="Form3" method="post" runat="server">
									<asp:Label id="Label7" runat="server" Width="208px">Short Term Interest Rate(%)</asp:Label>
									<asp:TextBox id="txtSTIRate" runat="server" Width="78px"></asp:TextBox>
									<asp:TextBox id="txtPaymentDays" runat="server" Width="78px"></asp:TextBox>
									<asp:Label id="Label6" runat="server" Width="144px">Payment Days</asp:Label>
									<asp:Label id="Label5" runat="server" Width="144px">Collection Period</asp:Label>
									<asp:TextBox id="txtCollectionPeriod" runat="server" Width="78px"></asp:TextBox>
									<asp:TextBox id="txtSalesOnCreditPercent" runat="server" Width="78px"></asp:TextBox>
									<asp:Label id="Label4" runat="server" Width="144px">Sales On Credit</asp:Label>
									<asp:TextBox id="txtSTR" runat="server" Width="78px"></asp:TextBox>
									<asp:DropDownList id="ddlBusinessGoods" runat="server">
										<asp:ListItem Value="1">Products</asp:ListItem>
										<asp:ListItem Value="2">Services</asp:ListItem>
										<asp:ListItem Value="3">Both</asp:ListItem>
									</asp:DropDownList>
									<asp:Label id="Label3" runat="server" Width="144px">Business Goods</asp:Label>
									<asp:Label id="Label1" runat="server" Width="144px">Business Status</asp:Label>
									<asp:DropDownList id="ddlBusinessStatus" runat="server" Width="80px">
										<asp:ListItem Value="1">Ongoing</asp:ListItem>
										<asp:ListItem Value="2">Startup</asp:ListItem>
									</asp:DropDownList>
									<asp:DropDownList id="ddlStartYear" runat="server" Width="80px">
										<asp:ListItem Value="1999">1999</asp:ListItem>
										<asp:ListItem Value="2000">2000</asp:ListItem>
										<asp:ListItem Value="2001">2001</asp:ListItem>
										<asp:ListItem Value="2002">2002</asp:ListItem>
										<asp:ListItem Value="2003">2003</asp:ListItem>
										<asp:ListItem Value="2004">2004</asp:ListItem>
										<asp:ListItem Value="2005">2005</asp:ListItem>
										<asp:ListItem Value="2006">2006</asp:ListItem>
									</asp:DropDownList>
									<asp:Label id="lblStartYear" runat="server" Width="144px">Start Year</asp:Label>
									<asp:Label id="lblStartMonth" runat="server" Width="144px">Start Month </asp:Label>
									<asp:DropDownList id="ddlStartMonth" runat="server" Width="102px">
										<asp:ListItem Value="1">January</asp:ListItem>
										<asp:ListItem Value="2">February</asp:ListItem>
										<asp:ListItem Value="3">March</asp:ListItem>
										<asp:ListItem Value="4">April</asp:ListItem>
										<asp:ListItem Value="5">May</asp:ListItem>
										<asp:ListItem Value="6">June</asp:ListItem>
										<asp:ListItem Value="7">July</asp:ListItem>
										<asp:ListItem Value="8">August</asp:ListItem>
										<asp:ListItem Value="9">September</asp:ListItem>
										<asp:ListItem Value="10">October</asp:ListItem>
										<asp:ListItem Value="11">November</asp:ListItem>
										<asp:ListItem Value="12">December</asp:ListItem>
									</asp:DropDownList>
									<DIV class="gridSpace">
										<asp:TextBox id="txtPlanDescription" runat="server" Height="48px" Width="100%" TextMode="MultiLine"></asp:TextBox></DIV>
									<DIV class="gridSpace">
										<asp:Label id="lblPlanDescription" runat="server" Width="296px">Business Plan Description</asp:Label></DIV>
									<asp:Label id="lblPlanName" runat="server" Width="336px">Business Plan Name </asp:Label>
									<asp:TextBox id="txtPlanName" runat="server" Width="250px"></asp:TextBox>
								<!--
												<table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td colspan="2" valign="top"><img src="../../images/InfiniPlan/InfiniPlan/top_head_planchoose.jpg" width="519" height="24"></td>
													</tr>
													<tr>
														<td colspan="2" valign="top"><img src="../../images/InfiniPlan/InfiniPlan/blank.gif" width="1" height="5"></td>
													</tr>
													<tr>
														<td width="0%" valign="top"><img src="../../images/InfiniPlan/InfiniPlan/blank.gif" width="100" height="1"></td>
														<td width="100%" valign="top"><img src="../../images/InfiniPlan/InfiniPlan/choose_plan.jpg" width="466" height="300"></td>
													</tr>
												</table> -->
								<!--
												<asp:linkbutton id="btnNewPlan" style="Z-INDEX: 105; LEFT: 256px; POSITION: absolute; TOP: 152px"
													runat="server" Height="32px" Width="177px">Create New Plan</asp:linkbutton>
												<asp:linkbutton id="btnLastPlan" style="Z-INDEX: 102; LEFT: 256px; POSITION: absolute; TOP: 216px"
													runat="server" Height="32" Width="177">Continue Last Plan</asp:linkbutton>
												<asp:linkbutton id="btnOpenPlan" style="Z-INDEX: 103; LEFT: 256px; POSITION: absolute; TOP: 264px"
													runat="server" Height="32px" Width="177px">Open an Existing Plan</asp:linkbutton>
												<asp:linkbutton id="btnInstantPlan" style="Z-INDEX: 104; LEFT: 256px; POSITION: absolute; TOP: 312px"
													runat="server" Height="32px" Width="177px">Create Instant Plan</asp:linkbutton>
												-->
							</td>
						</tr>
						<tr>
							<td height="10" valign="top"><img src="../images/InfiniPlan/InfiniPlan/blank.gif" width="1" height="10"></td>
						</tr>
						<tr>
							<td height="19" align="center" valign="top">
							</td>
						</tr>
					</table>
					<asp:ImageButton id="ImageButton1" runat="server" Width="40px" Height="38px"></asp:ImageButton></FORM> 
					<!-- Actual Page Contents are to be written upto here  -->
					<!-- **************************************************************************************************************************** -->
				</td>
			</tr>
		</table>
		</TD></TR>
		<tr>
			<td vAlign="bottom"><BUSINESSPLAN:BOTTOMBAR id="BottomBar1" runat="server"></BUSINESSPLAN:BOTTOMBAR>
			</td>
		</tr>
		</TBODY></TABLE>
	</body>
</HTML>
