<%@ Control Language="vb" AutoEventWireup="false" Codebehind="BottomBar.ascx.vb" Inherits="accounts.infinibiz.Web.BottomBar" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
		<TABLE id="tbl_Error" runat="server" visible="false" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD id="td_ErrorHeader" visible="false" class="rss_error_text" runat="server"></TD>
				</TR>
				<TR>
					<TD id="td_ErrorMsg" class="rss_error_text" runat="server"></TD>
				</TR>
		</TABLE>	
<table cellSpacing="0" cellPadding="0" width="100%">	
	<tr class="IBIZ_BottomBar" vAlign="middle">
		<td class="IBIZ_BottomBar">&nbsp;
		</td>
		<td class="IBIZ_BottomBar" style="WIDTH: 65px; TEXT-ALIGN: center"><IMG id="img_wait" alt="" src="\Images/loaded.gif" name="img_wait"></td>
		<td class="IBIZ_BottomBar" style="VERTICAL-ALIGN: middle; WIDTH: 95px; TEXT-ALIGN: center"><span id="dateContainer" style="FONT-SIZE: 8pt; VERTICAL-ALIGN: middle; COLOR: #000000; FONT-FAMILY: Tahoma,Trebuchet MS,Verdana"
				runat="server"></span></td>
	</tr>
</table>
