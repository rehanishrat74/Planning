<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ServicesList.ascx.vb" Inherits="Infinilogic.AccountsCentre.Web.ServicesList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<STYLE>
	 BLINK { COLOR: red }
</STYLE>
<script>		
	
	// blink text
	 function doBlink() {
	 	var blink = document.all.tags("BLINK")
	 	for (var i=0; i<blink.length; i++)
	 		blink[i].style.visibility = blink[i].style.visibility == "" ? "hidden" : ""
	 }

	 function startBlink() {
	 	if (document.all)
	 		setInterval("doBlink()",500)
	 }
	
	 window.onload = startBlink;
	
	//--------------------------------------------------------


	function GatewayRegistration(){
	window.navigate("/Gateway/Registration.aspx")
	}
</script>
<table cellSpacing="0" cellPadding="0" border="0" width=180>
	<tr>
		<td height="10"></td>
	</tr>
	<tr>
		<td id="tdGatewayPIN" runat="server"><IMG title="Activate Gateway Services" onclick="GatewayRegistration();" height="40" alt=""
				src="/images/GatawayPin.Gif"><cc1:OrderHere id="ccOrderHere" runat="server" Visible="False"></cc1:OrderHere>
		</td>
	</tr>
	<tr>
		<td class="Idx_Left_Border" id="tdAvailableServices" runat="server" name="tdAvailableServices">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="Idx_Right_Border">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr valign="top">
								<td class="Idx_Top_Border" height="23"><div class="acc_heading">Available Services</div>
								</td>
							</tr>
							<tr>
								<td width="100%"><asp:table id="tblAvailableServices" Width="100%" Runat="server" CssClass="CONTENT"></asp:table></td>
							</tr>
							<tr>
								<td class="Idx_Bottom_Border">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td height="3"></td>
	</tr>
	<tr>
		<td class="Idx_Left_Border" id="tdToPurchaseServices" runat="server" name="tdToPurchaseServices">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td class="Idx_Right_Border">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr valign="top">
								<td class="Idx_Top_Border" height="23">
									<div class="acc_heading">Update Services</div>
								</td>
							</tr>
							<tr>
								<td width="100%"><asp:table id="tblToPurchaseServices" CssClass="CONTENT" Runat="server" Width="100%"></asp:table></td>
							</tr>
							<tr>
								<td class="Idx_Bottom_Border">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
