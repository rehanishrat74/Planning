<%@ register tagprefix="include" tagname="gridnavigator" src="gridnavigator.ascx" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="GridControl.ascx.vb" Inherits="Infinilogic.BusinessPlan.Web.GridControl" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet">
<!-- <script src="../Scripts/AjaxCallObject.js"></script> -->
<table class="tablebackground" cellSpacing="0" cellPadding="0" width="422" align="left"
	border="0">
	<tr>
		<td>
			<table class="tablebodyshade" cellSpacing="0" cellPadding="2" width="100%" align="center"
				border="0">
				<tr width="100%">
					<td align="center"><asp:label id="lbltitleofgrid" Text="Product Import" runat="server" font-bold="true" cssClass="ControlHeading"
							Visible="False"></asp:label></td>
					<TD align="center"></TD>
				</tr>
				<tr>
					<td></td>
				</tr>
				<TR>
					<TD class="downbar" colSpan="2">
						<TABLE width="100%">
							<TR width="100%">
								<td width="100%" colSpan="4">
									<table width="100%">
										<TBODY>
											<tr width="100%">
												<td><asp:label id="Search" cssClass="page-section-text" Runat="server"></asp:label></td>
								</td>
							</TR>
							<tr>
								<td><asp:label id="SearchTest" CssClass="pagecontents" Runat="server"></asp:label></td>
							</tr>
						</TABLE>
					</TD>
				<tr>
					<TD width="20%"><asp:label id="lblidsearch" runat="server" CssClass="pagecontents"></asp:label>&nbsp;<asp:textbox id="txtfrom" runat="server" CssClass="ControlId" maxlength="9"></asp:textbox></TD>
					<TD width="40%"><asp:label id="lblnamesearch" runat="server" CssClass="pagecontents"></asp:label>&nbsp;<asp:textbox id="txtto" runat="server" maxlength="255" cssclass="Covertxtfields"></asp:textbox></TD>
					<TD align="left"><asp:button id="btnsearch" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
							runat="server" Cssclass="MBUTTONACCPRO" Font-Size="8pt"></asp:button></TD>
				</tr>
			</table>
		</td>
	</tr>
	<TR>
		<TD class="error" colSpan="2"><asp:label id="lblerror" width="100%" runat="server" CssClass="lblErrorMessage" visible="false"></asp:label></TD>
	</TR>
	<TR>
		<TD></TD>
	</TR>
	<TR>
		<TD colSpan="2" height="20%" align="center">
			<DIV class="GridControl1" id="gridDiv1">
				<asp:datagrid id="dgProducts" CssClass="wizardtext" Runat="server" AutoGenerateColumns="True"
					GridLines="Both" AllowPaging="True" CellPadding="1" CellSpacing="0" EnableViewState="True"
					Width="100%"   >
					<FooterStyle Height="20px"></FooterStyle>
					<SelectedItemStyle Height="20px"></SelectedItemStyle>
					<EditItemStyle Height="20px"></EditItemStyle>
					<AlternatingItemStyle Height="20px"></AlternatingItemStyle>
					<ItemStyle Height="20px" CssClass="wizardtext"></ItemStyle>
					<Columns>
						<asp:TemplateColumn>
							<HeaderStyle Width="17px"></HeaderStyle>
							<ItemStyle Width="17px" CssClass="wizardtext"></ItemStyle>
							<ItemTemplate>
								<asp:CheckBox id="chkSelect" runat="server" OnCheckedChanged="dgProducts_CheckChanged"></asp:CheckBox>
							</ItemTemplate>
							<FooterStyle Height="17px"></FooterStyle>
						</asp:TemplateColumn>
					</Columns>
					<PagerStyle HorizontalAlign="Right" PageButtonCount="15" Mode="NumericPages"></PagerStyle>
				</asp:datagrid></DIV>
		</TD>
	</TR>
	<TR>
		<TD align="right" colSpan="2">
			<include:gridnavigator id="gnavigator" runat="server"></include:gridnavigator>
		</TD>
	</TR>
	<TR>
		<TD class="Subheading" colSpan="2"><STRONG><asp:label id="InvoiceItems" Runat="server"></asp:label></STRONG></TD>
	</TR>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<TR>
		<TD colSpan="2"><asp:datagrid id="dgInvItems" runat="server" Visible="False" CssClass="pagecontents" AutoGenerateColumns="True"
				CellPadding="1" Width="100%" OnDeleteCommand="dgInvItems_DeleteCommand">
				<SelectedItemStyle Height="20px"></SelectedItemStyle>
				<EditItemStyle Height="20px"></EditItemStyle>
				<AlternatingItemStyle Height="20px"></AlternatingItemStyle>
				<ItemStyle Height="20px"></ItemStyle>
				<HeaderStyle CssClass="itemheader"></HeaderStyle>
				<FooterStyle Height="20px"></FooterStyle>
				<Columns>
					<asp:TemplateColumn>
						<HeaderStyle Width="17px"></HeaderStyle>
						<ItemTemplate>
							<asp:ImageButton ID="btndelete" Runat="server" ImageUrl="/images/InfiniPlan/deleteItem.gif" Width="17"
								Height="17" CommandName="Delete"></asp:ImageButton>
						</ItemTemplate>
					</asp:TemplateColumn>
				</Columns>
			</asp:datagrid></TD>
	</TR>
	<TR align="center">
		<TD>
			<TABLE>
				<TR>
					<TD class="subheading" colSpan="2"><asp:button id="btnImport" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
							runat="server" Cssclass="MBUTTONACCPRO" Font-Size="8pt" Width="49pt"></asp:button></TD>
					<TD></TD>
					<TD>
						<asp:button id="btncancel" onmouseover="this.className='MBUTTONACCPROON'; " onmouseout="this.className='MBUTTONACCPRO';"
							runat="server" Cssclass="MBUTTONACCPRO" Font-Size="8pt"></asp:button></TD>
				</TR>
			</TABLE>
		</TD>
	</TR>
</table>
</TD></TR></TBODY></TABLE>
