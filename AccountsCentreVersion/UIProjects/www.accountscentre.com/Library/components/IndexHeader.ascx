<%@ Control Language="vb" AutoEventWireup="false" Codebehind="IndexHeader.ascx.vb" Inherits="InfiniLogic.AccountsCentre.Web.IndexHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="/library/style/indexstyle.css" type="text/css" rel="stylesheet">
<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
<script language="JavaScript1.2" src="/library/javascript/stm31.js" type="text/javascript"></script>
<script language="javascript">
			function isEnterKey(){
				if(event.keyCode == 13 )
					return true;
				else
					return false;}
</script>
<style type="text/css">.style1 { COLOR: #97b1d0 }
	.style2 { COLOR: #4074ad }
	BODY { BACKGROUND-COLOR: #ffffff }
</style>
<% =CurrentUserScript %>
<table class="border_both_side" id="Table1" height="100%" cellSpacing="0" cellPadding="0"
	width="100%" align="center" bgColor="#ffffff" border="0">
	<tr>
		<td vAlign="top">
			<table id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr vAlign="top">
					<td align="left" width="2%"><IMG height="118" src="/images/main_logo.jpg" width="132">
					</td>
					<td align="right" width="98%">
						<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top" align="right" bgColor="#fcfcfc" height="81"><IMG height="81" src="/images/formationslogo.jpg" width="605" useMap="#Map" border="0"></td>
							</tr>
							<tr>
								<td vAlign="middle" align="right" height="38">
									<table id="Table4" cellSpacing="0" cellPadding="0" width="645" align="right" background="/images/blue_bg.jpg"
										border="0">
										<tr vAlign="middle">
											<td class="text_fild" align="left" width="12%"><IMG height="37" src="/images/infiniofficelogin.jpg" width="77">
											</td>
											<td class="text_fild" vAlign="middle" align="right" width="5%">Login&nbsp;&nbsp;
											</td>
											<td align="right"><asp:textbox id="txtUserID" Text="" CssClass="text_box" runat="server"></asp:textbox></td>
											<td class="text_fild" align="right" width="10%">&nbsp;Password&nbsp;&nbsp;
											</td>
											<td align="right" width="16%"><asp:textbox id="txtPassword" onkeydown="if (isEnterKey()) btnLogin.click();" Text="" CssClass="text_box"
													runat="server" TextMode="Password"></asp:textbox></td>
											<td class="text_fild" align="center" width="6%"><asp:linkbutton id="btnLogin" Text="Enter" runat="server" name="btnLogin" Cssclass="new_customermain_text"></asp:linkbutton></td>
											<td class="text_fild" align="center"><IMG height="23" src="/images/new_customer.gif" width="5"></td>
											<td align="center" width="10%"><A class="new_customermain_text" href="https://www.centre.biz/registration/signup.php">New 
													Customer </A>
											</td>
											<td class="text_fild" align="center" width="1%"><IMG height="23" src="/images/new_customer.gif" width="5"></td>
											<td class="text_fild" align="center" width="7%"><span class="link_text">Search Site</span>
											</td>
											<td class="text_fild" align="center" width="15%"><span class="link_text"><asp:textbox id="q" CssClass="text_box" Runat="server"></asp:textbox></span></td>
											<td class="text_fild" align="center" width="2%"><asp:linkbutton id="btnGO" Text="Go" runat="server" Cssclass="new_customermain_text"></asp:linkbutton></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<table id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" align="right" background="/images/buttons_bg_blue.jpg" bgColor="#4074ad">
						<table cellSpacing="0" cellPadding="0" width="100%" background="/images/buttons_bg_blue.jpg"
							border="0">
							<tr>
								<td vAlign="top" background="/images/buttons_bg_blue.jpg" bgColor="#4073ac">
									<IMG height="30" src="/images/buttons1.jpg" width="202"></td>
								<td align="right" background="/images/buttons_bg_blue.jpg" bgColor="#4073ac">
									<div>
										<table align="right" width="100" cellpadding="0" cellspacing="0">
											<tr>
												<!--<IMG height="32" src="/images/buttons2.jpg" width="576" useMap="#Map2" border="0">-->
												<td><a href="/default.aspx"><IMG height="32" src="/images/home_2.jpg" border="0"></a></td>
												<td><asp:LinkButton id="lnkFHAutoLogin" runat="server"><IMG height="32" src="/images/companyadmin_3.jpg" border="0"></asp:LinkButton></td>
												<td><a href="http://www.u-d.com"><IMG height="32" src="/images/websiteadmin_4.jpg" border="0"></a></td>
												<td><a href="http://webmail.formationshouse.com/"><IMG height="32" src="/images/checkemail_5.jpg" border="0"></a></td>
												<td><a href="/default.aspx"><IMG height="32" src="/images/accounting_6.jpg" border="0"></a></td>
												<td><a href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"><IMG height="32" src="/images/support_7.jpg" border="0"></a></td>
												<td><a href="http://www.formationshouse.com/contact_details.htm"><IMG height="32" src="/images/contactus_8.jpg" border="0"></a></td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
						<map name="Map2">
							<area shape="RECT" coords="16,10,71,35" href="/default.aspx">
							<area shape="RECT" coords="82,12,155,42" href="http://www.formationshouse.com/search/ereg/login.php">
							<area shape="RECT" coords="173,16,263,45" href="http://www.u-d.com">
							<area shape="RECT" coords="274,11,346,41" href="http://webmail.formationshouse.com/">
							<area shape="RECT" coords="361,14,425,40" href="/default.aspx">
							<area shape="RECT" target="_blank" coords="440,10,489,44" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse">
							<area shape="RECT" coords="503,6,573,37" href="http://www.formationshouse.com/contact_details.htm">
						</map>
					</td>
				</tr>
				<tr>
					<td vAlign="middle" bgColor="#9fc0df">
						<table id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr vAlign="middle">
								<td width="1%" background="/images/bg2.jpg" height="26">
									<table id="Table7" cellSpacing="2" cellPadding="0" width="95%" border="0">
										<tr>
											<td><IMG height="31" src="/images/phone.jpg" width="565" useMap="#Map3Map" border="0"></td>
										</tr>
									</table>
								</td>
								<td align="right" width="1%" height="26"><IMG height="28" src="/images/icon2.JPG" width="35">
									<asp:dropdownlist id="ddlACLanguages" runat="server" AutoPostBack="True">
										<asp:ListItem Selected="True" Value="ENGLISH">English</asp:ListItem>
										<asp:ListItem Value="GERMAN">German</asp:ListItem>
										<asp:ListItem Value="SPANISH">Spanish</asp:ListItem>
										<asp:ListItem Value="FRENCH">French</asp:ListItem>
									</asp:dropdownlist></td>
							</tr>
						</table>
						<MAP name="Map3Map">
							<AREA shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm">
							<AREA shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm">
						</MAP>
					</td>
				</tr>
			</table>
			<!--MENU-->
			<table id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<TD align="left" width="25%" bgColor="#4173ae">&nbsp;<A id="signinlink" style="FONT-WEIGHT: bold; FONT-SIZE: x-small; COLOR: white; TEXT-DECORATION: none"
							href="https://www.accountscentre.com/account/signin.aspx" runat="server"><B> AccountsCentre 
								SignIn</B></A></TD>
					<td align="right" width="75%" bgColor="#4173ae" height="30">
						<script language="javascript" src="/library/javascript/accmenu.js"></script>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--SC--><map name="Map"><area shape="RECT" target="_blank" coords="433,3,623,47" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"><area shape="RECT" coords="303,2,427,39" href="http://webmail.formationshouse.com/"></map><map name="Map3"><area shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm"><area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm"></map>
