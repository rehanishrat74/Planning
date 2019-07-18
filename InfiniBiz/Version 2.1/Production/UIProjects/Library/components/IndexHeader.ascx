<%@ Control Language="vb" AutoEventWireup="false" Codebehind="IndexHeader.ascx.vb" Inherits="accounts.infinibiz.Web.IndexHeader" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<link href="https://reseller.infinibiz.com/App_Themes/IBiz/IBIZ.css" rel="stylesheet"
	type="text/css">
<link href="/library/style/menu.css" type="text/css" rel="stylesheet">
<!-- Express Style Sheet -->
<LINK href="/library/style/Express.css" type="text/css" rel="stylesheet">
<!-- Payroll Style Sheet -->
<LINK href="/library/style/Payroll.css" type="text/css" rel="stylesheet">
<!-- InfiniPlan Style Sheet -->
<LINK href="/library/style/InfiniPlan.css" type="text/css" rel="stylesheet">
<!-- InfiniHR Style Sheet -->
<LINK href="/library/style/InfiniHR.css" type="text/css" rel="stylesheet">
<!-- AccountsPro Style Sheet -->
<LINK href="/library/style/AccountsPro.css" type="text/css" rel="stylesheet">
<!-- Cam Style Sheet -->
<link href="https://services.infinibiz.com/images/main.css" rel="stylesheet" type="text/css">
<link href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
<script language="JavaScript1.2" src="/library/javascript/stm31.js" type="text/javascript"></script>
<script language="javascript">
			function isEnterKey(){
				if(event.keyCode == 13 )
					return true;
				else
					return false;}
</script>
<style> .d_1_ { PADDING-RIGHT: 15px; BACKGROUND: #f3f3f3; MARGIN: 0px; HEIGHT: 30px; TEXT-ALIGN: right } .d_2_ { FONT-WEIGHT: bold; FONT-SIZE: 11px; FLOAT: left; COLOR: black; PADDING-TOP: 7px; FONT-FAMILY: tahoma; TEXT-DECORATION: none } .d_3_ { FLOAT: left; PADDING-TOP: 4px } .d_4_ { FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #3e3e3e; FONT-FAMILY: tahoma } .d_5_ { FLOAT: right; PADDING-TOP: 4px } .d_6_ { FONT-WEIGHT: bold; FONT-SIZE: 11px; COLOR: #2f7dbb; PADDING-TOP: 7px; FONT-FAMILY: tahoma; TEXT-DECORATION: none } </style>
<%=CurrentUserScript %>
<table class="border_both_side" id="Table1" cellSpacing="0" cellPadding="0" width="100%"
	style="DISPLAY:none" align="center" border="0">
	<tr>
		<td>
			<asp:Panel ID="GetThisVisibleFalse" Runat="server" Visible="false">
				<DIV align="left"><SPAN class="penalheading">
						<asp:dropdownlist id="drpSelectLanguage" Width="150px" AutoPostBack="True" runat="server">
							<asp:ListItem Value="fr">Other Languages</asp:ListItem>
							<asp:ListItem Value="en">English</asp:ListItem>
							<asp:ListItem Value="fr">French</asp:ListItem>
							<asp:ListItem Value="it">Italian</asp:ListItem>
							<asp:ListItem Value="ru">Russian</asp:ListItem>
							<asp:ListItem Value="cn">??</asp:ListItem>
							<asp:ListItem Value="ar">??????????</asp:ListItem>
						</asp:dropdownlist></SPAN></DIV>
			</asp:Panel>
			<table width="100%" border="0" cellspacing="0" cellpadding="0">
				<tr>
					<td height="100%" width="100%" bgcolor="#ffffff" style="BACKGROUND-POSITION-X: right; BACKGROUND-IMAGE: url(https://services.infinibiz.com/images/top_bg.jpg); BACKGROUND-REPEAT: no-repeat">
						<div>
							<img src="/images/logos.jpg"></div>
						<div style='FLOAT:right'>
							<div style='WIDTH:100%;HEIGHT:55px;TEXT-ALIGN:right' class="text">
								<img src="/images/athena.gif">
							</div>
							<div style='WIDTH:100%;TEXT-ALIGN:left'>
								<div style='FLOAT:left;WIDTH:290px;PADDING-TOP:9px;HEIGHT:36px'>
									<span align="center" class="text">Search&nbsp;</span><span><input name="textfield" type="text" size="32"></span><span class="text" align="center">&nbsp;Go</span></div>
								<div style='FLOAT:left'>
									<img src="https://services.infinibiz.com/images/home_button.gif" width="74" height="37"
										border="0" usemap="#Map" align="abstop"></div>
							</div>
						</div>
					</td>
				</tr>
				<tr>
					<td class="objtd">
						<asp:Panel ID="pnlGeneralBar" Runat="server">
							<%--
							<%= ToolBarHTML %>
							--%>
						</asp:Panel>
					</td>
				</tr>
			</table>
			<!--MENU-->
		</td>
	</tr>
	<tr>
		<td>
			<table id="tblMenu" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td align="right" bgcolor="#f3f3f3" width="75%" height="30">
						<script language="javascript" src="<%=js_path%>"></script>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
			<img src="/images/logos.jpg" alt="Infinibiz" ></td>
		<td align="right" nowrap>
			<img src="/images/athena.gif">
			</td>
	</tr>
	<tr>
		<td colspan="2" style="WIDTH:100%">
			<div class='IBIZ_HeaderToolbar'>
				<div style="FLOAT: right">
					<div style="FLOAT: left">
						<img src="/images/separator.gif" width="7" height="19" align="absMiddle" alt="">
					</div>
					<div style="FLOAT: left" onmousedown='this.className="IBIZ_HeaderToolbar-button_active"'
						onmouseup='this.className="IBIZ_HeaderToolbar-button_hover"' onmouseover='this.className="IBIZ_HeaderToolbar-button_hover"'
						onmouseout='this.className="IBIZ_HeaderToolbar-button"' class="IBIZ_HeaderToolbar-button">
						<a id="homeLink" runat="server"  href="#" style="COLOR: black; TEXT-DECORATION: none">
							<img border="0" src="/images/home.gif" align="absMiddle" alt=""><span align="absMiddle" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px">Home</span></a></div>
					<div style="FLOAT: left">
						<img src="/images/separator.gif" width="7" height="19" align="absMiddle" alt="">
					</div>
					<div style="FLOAT: left" onmousedown='this.className="IBIZ_HeaderToolbar-button_active"'
						onmouseup='this.className="IBIZ_HeaderToolbar-button_hover"' onmouseover='this.className="IBIZ_HeaderToolbar-button_hover"'
						onmouseout='this.className="IBIZ_HeaderToolbar-button"' class="IBIZ_HeaderToolbar-button">
						<a href="mailto:info@infinibiz.com" style="COLOR: black; TEXT-DECORATION: none"><img border="0" src="/images/feedback.gif" align="absMiddle" alt=""><span align="absMiddle" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px">Feedback</span></a></div>
				</div>
			</div>
		</td>
	</tr>
</table>
<!--SC--><map name="Map"><area shape="RECT" target="_blank" coords="433,3,623,47" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse"><area shape="RECT" coords="303,2,427,39" href="http://webmail.formationshouse.com/"></map><map name="Map3"><area shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm"><area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm"></map>
