<%@ Page Language="vb" AutoEventWireup="false" Codebehind="emailpopup.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.emailpopup" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Send Email</title>
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<meta name="cbwords" content="" >
		<meta name="cbcat" content="" >
		<meta http-equiv="Content-Language" content="en" >
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<%if request("PAGE")="" then %>
		<form id="Form1" method="post" runat="server">
			<TABLE class="content" id="Table3" style="WIDTH: 567px; HEIGHT: 282px" cellSpacing="0" cellPadding="0" width="567" border="0">
				<TR>
					<TD vAlign="top" align="left"></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="right"><STRONG>Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </STRONG>
						<asp:textbox id="email" runat="server" Width="501px" CssClass="mtbox"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" align="right"><STRONG>Subject&nbsp;&nbsp;
							<asp:textbox id="txtpsubject" runat="server" CssClass="mtbox" Width="502px"></asp:textbox></STRONG>
					</TD>
				</TR>
				<TR>
					<TD align="right"><asp:textbox id="txtpMessage" runat="server" CssClass="mtbox" Width="570px" TextMode="MultiLine" Height="223px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD align="right">&nbsp;
						<asp:button id="btpostreply" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';" runat="server" CssClass="MBUTTON" Width="46px" Text="Send" Font-Bold="True"></asp:button>
						&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
		<%else%>
		<TABLE class="content" id="Table1" style="WIDTH: 571px; HEIGHT: 52px" cellSpacing="0" cellPadding="0" width="571" border="0">
			<TR>
				<TD style="WIDTH: 272px; HEIGHT: 99px"></TD>
				<TD style="WIDTH: 119px; HEIGHT: 99px"></TD>
				<TD style="HEIGHT: 99px"></TD>
			</TR>
			<TR>
				<TD style="HEIGHT: 25px" align="middle" colSpan="3"><STRONG>Your email has been sent to 
						customer support</STRONG></TD>
			</TR>
			<TR>
				<TD style="WIDTH: 272px"></TD>
				<TD style="WIDTH: 119px">
					<input type="button" id="Button1" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';" OnClick="window.navigate('emailpopup.aspx');" Class="MBUTTON" Width="66px" value="Send Another"></TD>
				<TD>
					<input type="button" id="Button1" onmouseover="this.className='MBUTTONON';" onmouseout="this.className='MBUTTON';" OnClick="window.close();" Class="MBUTTON" Width="66px" value="Close"></TD>
			</TR>
		</TABLE>
		<%end if%>
	</body>
</HTML>
