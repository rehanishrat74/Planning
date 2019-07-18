<%@ Page Language="vb" AutoEventWireup="false" Codebehind="DormantCompany.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.DormantCompany" %>
<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="rightbar" Src="\library\components\IndexRight.ascx" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ outputcache Location="None" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - Dormant Company</title>
		<meta content="" name="cbwords">
		<meta content="" name="cbcat">
		<meta http-equiv="Content-Language" content="en">
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="/library/style/style.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/main.css" type="text/css" rel="stylesheet">
		<LINK href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colspan="2" height="20%" runat="server">
							<include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
							<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD id="menuares" vAlign="top" align="left" width="5%" runat="server"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
										<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server">
											<input id="returnurl" type="hidden" name="returnurl" runat="server"> 
											<!--COMPANY PROFILE-->
											<table width="778" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"
												bgcolor="#ffffff" class="border_both_side">
												<tr>
													<td height="97%" valign="top">
														<!--Multilingual -->
														<asp:label id="lbldormantcompany" runat="server" key="acc_products_dormantcompany_lbldormantcompany"></asp:label>
														<!--*******************-->
														</td>
        
    <td width="21%"> <include:rightbar id="idxRightBar" runat="server"></include:rightbar> 
    </td>
      </tr></table>
													</td>
												</tr>
											</table>
											<map name="Map3">
												<area shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm">
												<area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm">
											</map>
											<!-- *************************-->
										</TD>
						</td>
					</tr>
				</TBODY>
			</table>
			</TD>
			<td id="rightbar" width="5%" runat="server"></td>
			</TR>
			<tr>
				<td id="bottombar" colspan="2" height="2%" runat="server"><include:BottomBar id="Bottonbar1" runat="server"></include:BottomBar></td>
			</tr>
		</form>
		</TBODY></TABLE>
		<script>
function UpdateProfile(){
pform.action="profile.aspx?ACT=UPDATE"
pform.submit ();
}
		</script>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
