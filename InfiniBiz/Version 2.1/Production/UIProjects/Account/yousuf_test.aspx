<%@ Page Language="vb" AutoEventWireup="false" Codebehind="yousuf_test.aspx.vb" Inherits="accounts.infinibiz.Web.yousuf_test" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>yousuf_test</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Label id="Label1" style="Z-INDEX: 107; LEFT: 56px; POSITION: absolute; TOP: 72px" runat="server">IsInfinishopCustomer</asp:Label>
			<asp:TextBox id="txtMerchantServiceOrderNo" style="Z-INDEX: 123; LEFT: 208px; POSITION: absolute; TOP: 200px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label10" style="Z-INDEX: 117; LEFT: 56px; POSITION: absolute; TOP: 208px" runat="server">OrderNo</asp:Label>
			<asp:Label id="lblErrorDesc" style="Z-INDEX: 122; LEFT: 48px; POSITION: absolute; TOP: 384px"
				runat="server"></asp:Label>
			<asp:Label id="lblErrorCode" style="Z-INDEX: 121; LEFT: 48px; POSITION: absolute; TOP: 344px"
				runat="server"></asp:Label>
			<asp:Button id="btnCallIOService" style="Z-INDEX: 120; LEFT: 592px; POSITION: absolute; TOP: 144px"
				runat="server" Text="Call IO Service"></asp:Button>
			<asp:Label id="Label9" style="Z-INDEX: 119; LEFT: 512px; POSITION: absolute; TOP: 40px" runat="server"
				Font-Bold="True">Call AddMerchant Service</asp:Label>
			<asp:Label id="Label7" style="Z-INDEX: 116; LEFT: 456px; POSITION: absolute; TOP: 120px" runat="server">OrderNo</asp:Label>
			<asp:TextBox id="txtOrderNo" style="Z-INDEX: 113; LEFT: 592px; POSITION: absolute; TOP: 112px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label6" style="Z-INDEX: 115; LEFT: 456px; POSITION: absolute; TOP: 88px" runat="server">ChildID</asp:Label>
			<asp:TextBox id="txtChildID" style="Z-INDEX: 112; LEFT: 592px; POSITION: absolute; TOP: 80px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label5" style="Z-INDEX: 110; LEFT: 56px; POSITION: absolute; TOP: 168px" runat="server">GeneratorID</asp:Label>
			<asp:TextBox id="txtGeneratorID" style="Z-INDEX: 109; LEFT: 208px; POSITION: absolute; TOP: 168px"
				runat="server"></asp:TextBox>
			<asp:TextBox id="txtMerchantURL" style="Z-INDEX: 108; LEFT: 208px; POSITION: absolute; TOP: 136px"
				runat="server"></asp:TextBox>
			<asp:RadioButton id="rbIsInfinishopCustomer" style="Z-INDEX: 100; LEFT: 208px; POSITION: absolute; TOP: 72px"
				runat="server" GroupName="IsInfinishopCustomer" Checked="True" Text="True"></asp:RadioButton>
			<asp:RadioButton id="rbIsNotInfinishopCustomer" style="Z-INDEX: 101; LEFT: 272px; POSITION: absolute; TOP: 72px"
				runat="server" GroupName="IsInfinishopCustomer" Text="False"></asp:RadioButton>
			<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 56px; POSITION: absolute; TOP: 104px" runat="server">MerchantID</asp:Label>
			<asp:TextBox id="txtMerchantID" style="Z-INDEX: 105; LEFT: 208px; POSITION: absolute; TOP: 104px"
				runat="server"></asp:TextBox>
			<asp:Label id="Label4" style="Z-INDEX: 106; LEFT: 56px; POSITION: absolute; TOP: 136px" runat="server">MerchantURL</asp:Label>
			<asp:Button id="btnBuildMerchant" style="Z-INDEX: 111; LEFT: 208px; POSITION: absolute; TOP: 240px"
				runat="server" Text="Build Merchant"></asp:Button>
			<asp:Label id="Label8" style="Z-INDEX: 118; LEFT: 128px; POSITION: absolute; TOP: 32px" runat="server"
				Font-Bold="True">Build Merchant Service</asp:Label>
		</form>
	</body>
</HTML>
