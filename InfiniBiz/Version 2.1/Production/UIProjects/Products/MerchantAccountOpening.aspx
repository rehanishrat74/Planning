<%@ outputcache Location="None" %>
<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="rightbar" Src="\library\components\IndexRight.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MerchantAccountOpening.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.MerchantAccountOpening" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - MerchantAccountOpening</title>
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
		<LINK href="main.css" type="text/css" rel="stylesheet">
		<style type="text/css">BODY { BACKGROUND-COLOR: #ffffff }
	.style4 { COLOR: #4173ae; FONT-FAMILY: "Lucida Grande", Arial, Verdana, sans-serif; TEXT-DECORATION: none }
	.style5 { FONT-SIZE: 14px }
	.style6 { FONT-SIZE: 10px }
		</style>
	</HEAD>
	<body id="Body1" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" runat="server">
		<form id="pform" action="" method="post" runat="server">
			<table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				border="0">
				<TBODY>
					<tr>
						<td id="topbar" colSpan="2" height="20%" runat="server"><include:topbar id="idxTopBar" runat="server"></include:topbar></td>
					</tr>
					<tr>
						<td id="contentarea" width="95%" runat="server">
							<TABLE class="content" id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="100%"
								border="0">
								<TBODY>
									<TR>
										<TD id="menuares" vAlign="top" align="left" width="5%" runat="server"><include:leftbar id="idxLeftBar" runat="server"></include:leftbar></TD>
										<TD id="membersarea" vAlign="top" align="left" width="80%" runat="server"><input id="returnurl" type="hidden" name="returnurl" runat="server">
											<!--COMPANY PROFILE-->
											<table class="border_both_side" height="100%" cellSpacing="0" cellPadding="0" width="778"
												align="center" bgColor="#ffffff" border="0">
												<tr>
													<td vAlign="top" height="2%">
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
														</table>
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr>
																<td vAlign="middle" bgColor="#9fc0df">
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0" dwcopytype="CopyTableRow">
																	</table>
																</td>
															</tr>
														</table>
														<map name="Map2">
															<area shape="RECT" coords="311,15,396,38" href="http://www.formationshouse.comhttps://www.formationshouse.com/search/ereg/login.php">
															<area shape="RECT" coords="407,15,496,39" href="http://www.u-d.com/">
															<area shape="RECT" coords="516,16,577,47" href="accounting.htm">
															<area shape="RECT" target="_blank" coords="611,15,662,44" href="http://live.formationshouse.com/index.php?SCREEN=chat_login&amp;openmode=AUTO&amp;greeting=helloformationshouse">
															<area shape="RECT" coords="698,16,763,35" href="contact.htm">
															<area shape="RECT" coords="245,18,280,31" href="index.htm">
														</map>
													</td>
												</tr>
												<tr>
													<td vAlign="top" height="97%">
														<!--Multilingual-->
														<asp:Label ID="lblmerchantaccountopening" Runat="server" key="acc_products_lblmerchantaccountopening_lblmerchantaccountopening"></asp:Label>
														<!--***************-->
														</td>
        
    <td width="21%"> <include:rightbar id="idxRightBar" runat="server"></include:rightbar> 
    </td>
      </tr></table>
													</td>
												</tr>
											</table>
										</TD>
									</TR>
								</TBODY>
							</TABLE>
							<!--***************--></td>
						</TD></tr>
				</TBODY>
			</table>
			</TD>
			<td id="rightbar" width="5%" runat="server"></td>
			</TR>
			<tr>
				<td id="bottombar" colSpan="2" height="2%" runat="server"><include:bottombar id="Bottonbar1" runat="server"></include:bottombar></td>
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
