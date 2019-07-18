<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MessagePopup.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MessagePopup" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>MessagePopup</title>
		<meta name="cbwords" content="">
		<meta name="cbcat" content="">
		<meta http-equiv="Content-Language" content="en">
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE class="content" id="Table3" cellSpacing="0" cellPadding="0" width="449" border="0"
				style="WIDTH: 449px; HEIGHT: 297px">
				<TR>
					<TD style="WIDTH: 712px; HEIGHT: 1px" align="left">
						<asp:Label id="Label1" runat="server" CssClass="content" Width="570px" Font-Bold="True" ForeColor="Red"></asp:Label></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 712px; HEIGHT: 18px" align="left"><STRONG>Subject </STRONG>
						<asp:textbox id="txtpsubject" runat="server" Width="557px" CssClass="mtbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 712px; HEIGHT: 21px" align="left"><STRONG>Service
							<asp:dropdownlist id="Services" runat="server" Width="271px" CssClass="mtbox">
								<asp:ListItem Value="General">General</asp:ListItem>
								<asp:ListItem Value="Book keeping">Book keeping</asp:ListItem>
								<asp:ListItem Value="Payroll">Payroll</asp:ListItem>
								<asp:ListItem Value="Corporation Tax Return eFiling">Corporation Tax Return eFiling</asp:ListItem>
								<asp:ListItem Value="Company Annual Accounts">Company Annual Accounts</asp:ListItem>
								<asp:ListItem Value="Company Annual Accounts">Dormant Company Account</asp:ListItem>
								<asp:ListItem Value="Customer Accounts Management">Collection Service</asp:ListItem>
							</asp:dropdownlist></STRONG></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 713px" align="right">
						<asp:textbox id="txtpMessage" runat="server" Width="611px" CssClass="mtbox" TextMode="MultiLine"
							Height="223px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 713px" align="right">
						<asp:checkbox id="chkSent" runat="server" CssClass="tx1" Text="Copy to sent Messages" TextAlign="Left"></asp:checkbox>&nbsp;
						<asp:button id="btpostreply" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';"
							runat="server" Width="47px" CssClass="MBUTTON" Text="Post" Font-Bold="True"></asp:button>&nbsp;
						<input type="button" id="Close" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';"
							onclick="window.close();" Class="MBUTTON" Width="51px" value="Close">&nbsp;&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
