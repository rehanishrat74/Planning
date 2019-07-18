<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Speedometer.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.Speedometer" %>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Meter Wizard</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES><LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/ie7Bug.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<script src="../../Library/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
		<script language="javascript"> 
		
		 
		function Ask_BF_Delete()
		{
	 	 	 var strmatername ='aa';
		  var decision;
	 	decision=confirm("Do you want to Delete that Clip from your plan ?" , "");
			var getdecval=document.getElementById("FavClip");
			getdecval.value=decision;
	
		}
		 
		  function SetRbValue(o)
		{
		
		 var idval = o;
				var getidval=document.getElementById("SelectedRowNumber");
		document.getElementById("btnShow").disabled=false;
	     var a = document.getElementById("txt_Name")
			 if (a== null ){ } 
			 else { 
				document.getElementById("txt_Name").disabled=false; 
				document.getElementById("txt_Name").value="";
			    var b = document.getElementById("lblError")
					if (b == null) {} 
					else {
						document.getElementById("lblError").style.display="none" 
						}
				  }		 		
		getidval.value=idval
	 
		  	 }
		 
		function SetRbValue1(o,a)
		{
		var getEditMeter=document.getElementById("editmeter");
		
 		var idval = o;
 		var idClip = a;
 	 
 		var getidval=document.getElementById("SelectedRowNumber");
		 getidval.value=idval
		if(getEditMeter!=null)
		{
		document.getElementById("editmeter").style.display="none" 

		 if (a == 1) {   document.getElementById("editmeter").style.display=""  } 
					else if (a == 0){
					   document.getElementById("editmeter").style.display="none" 
						}
		}    
		 
		 }
 	 
 	 
		function NextSet()
		{
			document.getElementById("btnNext").disabled=false;  
		}
		
		function meterSet()
		{
		document.getElementById("btnNext").disabled=false;
	 	document.getElementById("Imeter").className='td1b'; 
	  	document.getElementById("Icombine").className='';  
		var getid= document.getElementById("IActuals");
		 if (getid == null )
		 {
		 }
		else if (getid!= null ) 
		{
		if (document.getElementById("IActuals").disabled != false )
			{ 
			document.getElementById("IActuals").className='';   
 			}
 		}
		}	
				
		function actSet()
		{
		document.getElementById("btnNext").disabled=false;
		document.getElementById("Imeter").className=''; 
 		document.getElementById("IActuals").className='td1b';   
		document.getElementById("Icombine").className='';    
		}
		
		function devSet()
		{
		document.getElementById("btnNext").disabled=false;
		document.getElementById("Imeter").className=''; 
		document.getElementById("Icombine").className='td1b';
		var getid= document.getElementById("IActuals");
		 if (getid == null )
		 {		 
		 }
		else if (getid!= null ) 
		{
		if (document.getElementById("IActuals").disabled != false )
			{ 
			document.getElementById("IActuals").className='';   
 			}
 		}
		}
	  
 	 
 	 function GetFocus()
  	 {
  	 var getfocusid=document.getElementById("flashpanel");
 	 var metercontrol=document.getElementById("MeterName")
      var metertext = document.getElementById("txt_Name");
   
   		if (metertext.value == null )
		 {		 
		 }
		else if (metertext.value!= null ) 
		{
		metercontrol.value=metertext.value
		}
	 
  	 }
  	 
  	 function GetFocus1()
  	 {
 	 var getfocusid=document.getElementById("flashpanel");
 	 }
 	 
 	 	function delete_prompt()
			{			
			var sMeterId=document.getElementById("SelectedRowNumber");	
			//alert(sMeterId.value);
			if(sMeterId.value=="")
			{
				return false
			}
			var return_val = confirm("Do you want to delete this meter ?")
			if (return_val == false)
			{	
				return false
			}	
			}
			
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0" bgcolor="white">
				<TBODY>
					<tr>
						<td vAlign="top" height="19">
							<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR><input id="SelectedRowNumber" type="hidden" name="SelectedRowNumber"><INPUT id="MeterName" type="hidden" name="MeterName">
							<INPUT id="FavClip" type="hidden" value="-1" name="FavClip" runat="server">
						</td>
					</tr>
					<tr>
						<td vAlign="top" height="100%">
							<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<tr>
										<td vAlign="top" colSpan="3" height="1"><IMG height="5" src="../../images/InfiniPlan/blank.gif" width="1"></td>
									</tr>
									<tr>
										<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
										<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
										<td vAlign="top" width="100%">
											<!-- **************************************************************************************************************************** -->
											<!-- Actual Page Contents are to be written here  -->
											<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
													<tr>
														<td vAlign="top" align="center" height="19" bgcolor="#f3f3f3"><asp:label id="lblHeading" runat="server" CssClass="lblHeading" Width="100%"></asp:label></td>
														<asp:dropdownlist id="cmbMonth" runat="server" CssClass="wizardOptions" Width="38%" Visible="False"
															AutoPostBack="true"></asp:dropdownlist></tr>
													<tr>
														<td align="center"><asp:panel id="testpanel" Runat="server" width="100%" height="100%">
																<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TBODY>
																		<TR>
																			<TD class="TableBox_Top_Left" height="3"><IMG src="../../images/InfiniPlan/blank.gif" width="16"></TD>
																			<TD class="TableBox_Top" height="3">&nbsp;</TD>
																			<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
																		</TR>
																		<TR>
																			<TD class="TableBox_Left" width="0%"></TD>
																			<TD vAlign="top" width="100%" height="100%"><!-- table -->
																				<TABLE height="100%" width="100%" border="0">
																					<TR vAlign="middle" height="100%" Width="100%">
																						<TD vAlign="top" width="100%" height="100%"><!-- Compose --> &nbsp;
																							<ASP:PANEL id="PanelNOProduct" Runat="server" visible="false">
																								<TABLE height="10%" width="100%" border="0">
																									<TR vAlign="middle">
																										<TD vAlign="middle" align="center" width="100%" height="80%">
																											<ASP:LABEL id="lblNoProducts" runat="server" Font-Names="Verdana" Font-Size="8"></ASP:LABEL></TD>
																									</TR>
																								</TABLE>
																							</ASP:PANEL>
																							<ASP:PANEL id="panelcompose" Runat="server" visible="false">
																								<ASP:PANEL id="Panelheading" Runat="server" Height="2%"> <!-- heading table -->
																									<TABLE height="10%" width="100%" border="0">
																										<TR vAlign="middle">
																											<TD vAlign="middle" align="center" height="80%" >
																												<ASP:LABEL id="Heading" runat="server" Width="71%" Height="35px" cssclass="wizardHeader1">InfiniPlan Analysis 
                                Wizard</ASP:LABEL></TD>
																										</TR>
																										<TR vAlign="middle">
																											<TD vAlign="middle" align="center" height="20%">
																												<ASP:LABEL id="Title" runat="server" Width="71%" cssclass="wizardTitle1"></ASP:LABEL></TD>
																										</TR>
																									</TABLE>
																								</ASP:PANEL>
																								<ASP:PANEL id="PanelCentre" Runat="server" Height="25%">
																									<TABLE width="70%" align="center" border="0">
																										<TBODY>
																											<TR vAlign="top">
																												<TD vAlign="top" align="center" height="90%"><!-- innrer  -->
																													<DIV class="tableBorder1">
																														<ASP:LABEL id="flashheader" runat="server" Visible="False" cssclass="flashTitle"></ASP:LABEL>
																														<ASP:LABEL id="helpText" runat="server" CssClass="wizardText" Height="160px">
																															<P class="MsoNormal" style="TEXT-JUSTIFY: inter-ideograph; TEXT-ALIGN: justify"></P>
																														</ASP:LABEL><IMG id="meterimg" src="/images/infiniplan/ImgMeterBasic.jpg" runat="server" visible="false">
																													</DIV>
																												</TD>
																												<TD align="center" width="65%" height="90%">
																													<TABLE height="75%" width="100%" border="0">
																														<TR>
																															<TD align="center" height="10%">
																																<ASP:LABEL id="lblsuggestion" runat="server" CssClass="wizardText"></ASP:LABEL></TD>
																														</TR>
																														<TR>
																															<TD vAlign="top" align="center" height="10%">&nbsp; <!-- test -->
																																<DIV class="ProductGrid" id="gdViews1" align="center">
																																	<TABLE height="5%" width="100%" align="center" border="0">
																																		<TR>
																																			<TD>
																																				<TABLE id="TABLE3" width="100%" align="center" border="0">
																																					<TR vAlign="bottom">
																																						<TD align="center"><IMG id="titleimg" src="/images/infiniplan/ImgTitleBasic.jpg" runat="server" Visible="False"></TD>
																																					</TR>
																																					<TR>
																																						<TD>
																																							<ASP:LABEL id="lblID" runat="server" CssClass="wizardOptions" Visible="False">ID</ASP:LABEL></TD>
																																						<TD>
																																							<ASP:TEXTBOX id="txtID" runat="server" Width="56px" CssClass="wizardText" Visible="False"></ASP:TEXTBOX></TD>
																																						<TD>
																																							<ASP:LABEL id="lblName" runat="server" CssClass="wizardOptions" Visible="False">Name</ASP:LABEL></TD>
																																						<TD>
																																							<ASP:TEXTBOX id="txtName" runat="server" CssClass="wizardText" Visible="False"></ASP:TEXTBOX></TD>
																																						<TD>
																																							<ASP:BUTTON id="btnSearch" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																																								runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Search"></ASP:BUTTON></TD>
																																					</TR>
																																				</TABLE>
																																			</TD>
																																		</TR>
																																		<TR vAlign="top">
																																			<TD vAlign="top" align="center" width="40%" height="5%">
																																				<ASP:PANEL id="PanelImages" runat="server" Width="100%" Visible="False"></ASP:PANEL>
																																				<asp:Panel id="DatePanel" runat="server" Width="100%" Visible="False">
																																					<TABLE width="100%" align="center" border="0">
																																						<TR>
																																							<TD vAlign="top" align="left">
																																								<TABLE height="1%" width="100%" align="center" border="0">
																																									<TR vAlign="top">
																																										<TD class="wizardtext" vAlign="top" align="center">From&nbsp;
																																											<BDP:BDPLITE id="BDPLite1" runat="server" TextBoxColumns="10"></BDP:BDPLITE>&nbsp;To&nbsp;
																																											<BDP:BDPLITE id="BDPLite2" runat="server" TextBoxColumns="10"></BDP:BDPLITE></TD>
																																									</TR>
																																								</TABLE>
																																							</TD>
																																						</TR>
																																						<TR>
																																							<TD align="center" colSpan="5" height="1">
																																								<asp:CheckBox id="chkMTD" runat="server" Width="155px" CssClass="wizardtext" AutoPostBack="True"
																																									Text="Real time monitoring"></asp:CheckBox>
																																								<asp:Label id="CurrentYear" runat="server" CssClass="wizardtext"></asp:Label></TD>
																																						</TR>
																																						<TR>
																																							<TD align="left" colSpan="5" height="1">
																																								<asp:Label id="CurrentYear2" runat="server" CssClass="wizardtext"></asp:Label></TD>
																																						</TR>
																																						<TR>
																																							<TD align="center" colSpan="5" height="1">
																																								<asp:Label id="lblDateError" runat="server" CssClass="lblErrorMessage" Visible="False"></asp:Label><BR>
																																							</TD>
																																						</TR>
																																					</TABLE>
																																				</asp:Panel>
																																				<asp:Panel id="PanelLastYEars" runat="server" Width="100%" Visible="False">
																																					<TABLE width="100%" align="center" border="0">
																																						<TR>
																																							<TD align="left" colSpan="5" height="1">
																																								<asp:CheckBox id="chkboxPreviousYear" runat="server" Width="1%" CssClass="wizardtext" AutoPostBack="True"></asp:CheckBox>
																																								<asp:Label id="lblComparision" runat="server" CssClass="wizardtext">  Compare Intervels (Past Years) </asp:Label><BR>
																																							</TD>
																																						</TR>
																																						<TR>
																																							<TD vAlign="top" align="center">
																																								<TABLE width="100%" align="center" border="0">
																																									<TR vAlign="top">
																																										<TD class="wizardtext" vAlign="top" align="center">From&nbsp;
																																											<BDP:BDPLITE id="Bdplite3" runat="server" TextBoxColumns="10" enable="false"></BDP:BDPLITE>&nbsp;To&nbsp;
																																											<BDP:BDPLITE id="Bdplite4" runat="server" TextBoxColumns="10" enable="false"></BDP:BDPLITE><BR>
																																											<BR>
																																										</TD>
																																									</TR>
																																								</TABLE>
																																							</TD>
																																						</TR>
																																					</TABLE>
																																				</asp:Panel>
																																				<ASP:RADIOBUTTONLIST id="rbCriterialist" runat="server" Visible="False" cssclass="wizardOptions" BorderColor="#FFC0C0">
																																					<ASP:ListItem Value="1">Sales</ASP:ListItem>
																																					<ASP:ListItem Value="2">Cost of Goods sold</ASP:ListItem>
																																				</ASP:RADIOBUTTONLIST>
																																				<ASP:PANEL id="Gridpanel" runat="server" Width="80%" Visible="False" BorderStyle="None">
																																					<BR>
																																					<ASP:DATAGRID id="dgEntity" runat="server" width="100%" Height="100%" cssclass="pagecontents"
																																						AllowPaging="True" AutoGenerateColumns="False" PageSize="5" CellPadding="1">
																																						<ALTERNATINGITEMSTYLE CssClass="alternatingrowitem"></ALTERNATINGITEMSTYLE>
																																						<ITEMSTYLE CssClass="rowitem"></ITEMSTYLE>
																																						<HEADERSTYLE CssClass="itemheader" Height="10px"></HEADERSTYLE>
																																						<COLUMNS>
																																							<ASP:BOUNDCOLUMN Visible="False" HeaderText="planid" DataField="planid"></ASP:BOUNDCOLUMN>
																																							<ASP:BOUNDCOLUMN Visible="False" HeaderText="productid" DataField="productid"></ASP:BOUNDCOLUMN>
																																							<ASP:TEMPLATECOLUMN>
																																								<HEADERSTYLE Width="17px"></HEADERSTYLE>
																																								<ITEMSTYLE Width="17px"></ITEMSTYLE>
																																								<ITEMTEMPLATE>
																																									<ASP:LABEL id="Label2" runat="server"></ASP:LABEL>
																																								</ITEMTEMPLATE>
																																								<FOOTERSTYLE Height="17px"></FOOTERSTYLE>
																																							</ASP:TEMPLATECOLUMN>
																																							<ASP:BOUNDCOLUMN HeaderText="Entity Name" DataField="Entity Name"></ASP:BOUNDCOLUMN>
																																						</COLUMNS>
																																						<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" HorizontalAlign="Right" Mode="NumericPages"
																																							Font-Italic="True"></PAGERSTYLE>
																																					</ASP:DATAGRID>
																																				</ASP:PANEL><BR>
																																				<asp:Label id="lbl_Name" runat="server" Width="82px" CssClass="wizardText" Visible="False">Meter Name</asp:Label>
																																				<asp:TextBox id="txt_Name" runat="server" Visible="False"></asp:TextBox><BR>
																																				<ASP:LABEL id="lblError" runat="server" CssClass="wizardText" Visible="False" ForeColor="Red"></ASP:LABEL></TD>
																																		</TR>
																																	</TABLE> <!-- buttone --></DIV>
																															</TD>
																														</TR>
																													</TABLE>
																													<DIV></DIV> <!-- test --></TD>
																											</TR>
																											<TR vAlign="top" align="left">
																												<TD vAlign="top" align="left" height="60%"></TD><!-- innrer  --></TD>
																					</TR>
																				</TABLE>
															</asp:panel><asp:panel id="PanelButton" Runat="server" Height="35%">
																<TABLE id="Table1" height="100%" width="90%" align="center" border="0">
																	<TR height="5%">
																		<TD align="right">
																			<ASP:BUTTON id="btnCancel" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																				runat="server" Cssclass="MBUTTONACCPRO" Text="Cancel" CausesValidation="False"></ASP:BUTTON></TD>
																		<TD align="right">
																			<ASP:BUTTON id="btnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																				runat="server" Cssclass="MBUTTONACCPRO" Text="Back"></ASP:BUTTON></TD>
																		<TD>
																			<ASP:BUTTON id="btnNext" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																				runat="server" Cssclass="MBUTTONACCPRO" Text="Next"></ASP:BUTTON></TD>
																		<TD>
																			<ASP:BUTTON id="btnShow" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																				runat="server" Cssclass="MBUTTONACCPRO" Text="Save" Enabled="False"></ASP:BUTTON></TD>
																	</TR>
																</TABLE>
															</asp:panel></ASP:PANEL> 
															<!-- /Compose -->
															<!-- Compare --><asp:panel id="PanelCompare" Runat="server" width="100%" visible="false">
																<TABLE height="100%" width="100%" align="center" border="0">
																	<TR vAlign="top" height="100%">
																		<TD vAlign="top" align="center">
																			<ASP:LABEL id="lblCompare" runat="server" Visible="False" cssclass="MeterwizardText"></ASP:LABEL>
																			<asp:Table id="CompareTable" runat="server"></asp:Table></TD>
																	</TR>
																</TABLE>
															</asp:panel>
															<!-- /Compare -- > 
															<!-- Listing --><asp:panel id="Panelnoclip" Runat="server" width="100%" visible="false">
																<TABLE height="100%" width="100%" align="center" border="0">
																	<TR vAlign="top" height="100%">
																		<TD vAlign="top" align="center">
																			<ASP:LABEL id="lblNoClip" runat="server" Visible="False" cssclass="MeterwizardText"></ASP:LABEL></TD>
																	</TR>
																</TABLE>
															</asp:panel><asp:panel id="PanelListing" Width="100%" Runat="server" visible="false">
																<TABLE height="100%" width="100%" align="center" border="0">
																	<TR vAlign="top" height="5%" width="100%">
																		<TD align="center" cssclass="MeterwizardText">
																			<ASP:LABEL id="lblClipHeading" runat="server" cssclass="MeterwizardText"></ASP:LABEL></TD>
																	</TR>
																	<TR vAlign="top" width="100%">
																		<TD align="center" width="100%" height="97%">
																			<TABLE height="100%" width="100%" align="center" border="0">
																				<TR vAlign="top">
																					<TD align="center">
																						<ASP:PANEL id="PanelListingforClips" Width="100%" CssClass="tableborder1" Runat="server" visible="True">
																							<TABLE height="100%" width="100%" align="center" border="0">
																								<TR vAlign="top">
																									<TD align="center" width="80%">
																										<ASP:PANEL id="Panel3" Width="100%" CssClass="tableborder1" Runat="server" visible="True">
																											<TABLE border="0">
																												<TR vAlign="top">
																													<TD>
																														<DIV class="meterSpave1" id="divViews" align="center">
																															<ASP:TABLE id="Listmeter" runat="server" CssClass="trsettings" Border="0"></ASP:TABLE>
																															<ASP:TABLE id="AdvanceMeters" runat="server" Width="10%" CssClass="trsettings" Visible="False"
																																Border="0"></ASP:TABLE></DIV>
																													</TD>
																												</TR>
																											</TABLE>
																										</ASP:PANEL></TD>
																									<TD vAlign="top" align="center" width="25%" rowSpan="2">
																										<ASP:LABEL id="lblMeterName" runat="server" CssClass="wizardtext1"></ASP:LABEL>
																										<ASP:PANEL id="PanelZoom" Width="100%" CssClass="tableborder1" Visible="True" Runat="server"
																											Height="95%" DESIGNTIMEDRAGDROP="1127" HorizontalAlign="Center">
																											<TABLE height="100%" width="100%" align="center" border="0">
																												<TR vAlign="top" height="90%">
																													<TD align="center" width="100%">
																														<ASP:LABEL id="lblZoomEntitName" runat="server" cssclass="flashTitle">+</ASP:LABEL>
																														<DIV class="ZoomSpave" id="divViews1" align="center">
																															<ASP:TABLE id="MeterZoomView" runat="server" CssClass="trsettings" border="0"></ASP:TABLE></DIV>
																													</TD>
																												</TR>
																												<TR vAlign="top" height="10%">
																													<TD align="center"><BR>
																														<ASP:BUTTON id="imgbtnAdv" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																															runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Advanced"></ASP:BUTTON></TD>
																												</TR>
																											</TABLE>
																										</ASP:PANEL></TD>
																								<TR>
																									<TD align="center">
																										<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="190" border="0">
																											<TR>
																												<TD align="center" width="25%">
																													<ASP:IMAGEBUTTON id="editmeter" runat="server" Visible="False" ToolTip="Edit" ImageUrl="/images/infiniplan/editmeter.jpg"></ASP:IMAGEBUTTON></TD>
																												<TD align="center" width="25%">
																													<ASP:IMAGEBUTTON id="zoommeter" runat="server" Visible="True" ToolTip="Zoom" ImageUrl="/images/infiniplan/zoommeter.jpg"></ASP:IMAGEBUTTON></TD> <!-- <TD align="center" width="25%">
																													<ASP:IMAGEBUTTON id="FavroiteMeter" runat="server" Visible="True" ImageUrl="/images/infiniplan/favmeter.jpg"
																														ToolTip="Favroites"></ASP:IMAGEBUTTON></TD> -->
																												<TD align="center" width="25%">
																													<ASP:IMAGEBUTTON id="deletemter" runat="server" Visible="True" ToolTip="Delete" ImageUrl="/images/infiniplan/deletemter.jpg"></ASP:IMAGEBUTTON></TD>
																												<TD align="center" width="25%">
																													<ASP:BUTTON id="imgbtnBack" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																														runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Back"></ASP:BUTTON></TD>
																											</TR>
																										</TABLE>
																									</TD>
																								</TR>
																				</TR>
																			</TABLE>
															</asp:panel></td>
													</tr></table>
										</td>
									</tr></table>
							</asp:panel> 
							<!-- /Listing -->
							<!-- Favorites --><asp:panel id="PanelNoFAvorites" Width="100%" Runat="server" visible="false">
								<TABLE height="100%" width="100%" align="center" border="0">
									<TR vAlign="top" height="100%">
										<TD align="center">
											<ASP:LABEL id="lblnotfavorites" runat="server" Visible="False" cssclass="MeterwizardText"></ASP:LABEL></TD>
									</TR>
								</TABLE>
							</asp:panel><asp:panel id="PanelFavorites" CssClass="tableborder1" Width="100%" Runat="server" visible="false">
								<TABLE height="100%" width="100%" align="center" border="0">
									<TBODY>
										<TR vAlign="top" height="5%">
											<TD align="center">
												<ASP:LABEL id="Label1" runat="server" cssclass="MeterwizardText">This 
                                is a list of all the <B>Favourite</B> 
                                speedometers from this plan. Click on a 
                                <B>Speedometer</B> name to remove it from the 
                                list </ASP:LABEL></TD>
										</TR>
										<TR>
											<TD>
												<TABLE height="100%" width="100%" align="center" border="0">
													<TR vAlign="top">
														<TD width="100%" height="100%">
															<ASP:PANEL id="PanelFav" Width="100%" CssClass="tableborder1" Runat="server" visible="True">
																<TABLE height="100%" width="100%" align="center" border="0">
																	<TBODY>
																		<TR vAlign="top">
																			<TD align="center" width="90%" height="90%">
																				<TABLE height="100%" width="100%" align="center" border="0">
																					<TR>
																						<TD align="center">
																							<DIV class="meterSpaveFavroties" id="maindiv">
																								<ASP:TABLE id="PlanFavTable" Runat="server" Height="60%" align="center"></ASP:TABLE></DIV>
																						</TD>
																					</TR>
																				</TABLE>
																			</TD></TD>
													</TR>
												</TABLE>
							</asp:panel></td>
					</tr>
				</TBODY></table>
			</td></tr></TBODY></table></asp:panel> 
			<!-- /Favorites -->
			<!-- Compare Products --><asp:panel id="PanelCompareProducts" runat="server" Visible="False">
				<TABLE id="Table3" height="1%" width="100%" border="0">
					<TBODY>
						<TR height="1%" width="50%">
							<TD align="center" colSpan="2" height="1%"><ASP:LABEL id="Label3" runat="server" CssClass="lblhelpMessage"> You can 
																								  compare your records by using that menu option .Mention <b>
										From</b> & <b>To</b> Date, click <b>Select</b> button.Then Click <b>Show</b> button. </ASP:LABEL></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
						</TR>
						<TR height="1%" width="50%">
							<TD align="center" colSpan="2"><asp:panel id="Panel2" runat="server" CssClass="tableborder1" Width="50%" Height="32px">
									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
										<TR>
											<TD align="center">
												<ASP:LABEL id="Label4" runat="server" CssClass="wizardText" Visible="True" DESIGNTIMEDRAGDROP="1086">From </ASP:LABEL></TD>
											<TD width="112">
												<BDP:BDPLITE id="BDPLiteFrom" runat="server" Visible="true" TextBoxColumns="12" DESIGNTIMEDRAGDROP="1087"></BDP:BDPLITE></TD>
											<TD align="center">
												<ASP:LABEL id="Label5" runat="server" CssClass="wizardText" Visible="True" DESIGNTIMEDRAGDROP="1088">To </ASP:LABEL></TD>
											<TD width="122">
												<BDP:BDPLITE id="BDPLiteTo" runat="server" Visible="True" TextBoxColumns="12" DESIGNTIMEDRAGDROP="1089"></BDP:BDPLITE></TD>
											<TD align="center"></TD>
										</TR>
									</TABLE>
								</asp:panel><ASP:LABEL id="lblfiscalyear" runat="server" CssClass="wizardText" Visible="True"></ASP:LABEL></TD>
						</TR>
						<TR>
							<TD align="center" colSpan="2">&nbsp;</TD>
						</TR>
						<TR vAlign="top" height="1%" width="50%">
							<TD vAlign="top" align="center" width="30%" height="1%"><ASP:PANEL class="comparetableborder" id="mypanel" Runat="server">
									<TABLE id="Table4" border="0">
										<TR>
											<TD align="left" colSpan="4">
												<asp:Label id="Label7" runat="server" CssClass="lblhelpMessage" Visible="False">
																													<b>Select Product</b> (2)</asp:Label></TD>
										</TR>
										<TR>
											<TD>
												<ASP:LABEL id="lblID_compare" runat="server" CssClass="wizardOptions" Visible="True">ID</ASP:LABEL></TD>
											<TD>
												<ASP:TEXTBOX id="txtID_compare" runat="server" Width="56px" CssClass="wizardText" Visible="True"></ASP:TEXTBOX></TD>
											<TD>
												<ASP:LABEL id="lblName_compare" runat="server" CssClass="wizardOptions" Visible="True">Name</ASP:LABEL></TD>
											<TD>
												<ASP:TEXTBOX id="txtName_compare" runat="server" CssClass="wizardText" Visible="True"></ASP:TEXTBOX></TD>
											<TD>
												<ASP:BUTTON id="btnSearch_compare" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
													runat="server" Visible="True" Cssclass="MBUTTONACCPRO" Text="Search"></ASP:BUTTON></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="5"><BR>
												<ASP:PANEL id="Panel1" runat="server" Width="85%" Visible="True" height="5%">
													<ASP:DATAGRID id="dgActualEntity" runat="server" Visible="True" width="100%" Height="100%" cssclass="pagecontents"
														AllowPaging="True" AutoGenerateColumns="False" PageSize="5" CellPadding="1">
														<ALTERNATINGITEMSTYLE CssClass="alternatingrowitem"></ALTERNATINGITEMSTYLE>
														<ITEMSTYLE CssClass="rowitem"></ITEMSTYLE>
														<HEADERSTYLE CssClass="itemheader" Height="10px"></HEADERSTYLE>
														<COLUMNS>
															<ASP:BOUNDCOLUMN Visible="False" DataField="planid" HeaderText="planid"></ASP:BOUNDCOLUMN>
															<ASP:BOUNDCOLUMN Visible="False" DataField="productid" HeaderText="productid"></ASP:BOUNDCOLUMN>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Width="17px"></HEADERSTYLE>
																<ITEMSTYLE Width="17px"></ITEMSTYLE>
																<ITEMTEMPLATE>
																	<ASP:CHECKBOX id="chkSelect" runat="server" OnCheckedChanged="dgActualEntity_CheckChanged"></ASP:CHECKBOX>
																</ITEMTEMPLATE>
																<FOOTERSTYLE Height="17px"></FOOTERSTYLE>
															</ASP:TEMPLATECOLUMN>
															<ASP:BOUNDCOLUMN DataField="Entity Name" HeaderText="Entity Name"></ASP:BOUNDCOLUMN>
														</COLUMNS>
														<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" Font-Italic="True" Mode="NumericPages" HorizontalAlign="Right"
															BorderStyle="Dotted"></PAGERSTYLE>
													</ASP:DATAGRID>
												</ASP:PANEL><BR>
												<ASP:BUTTON id="btnSelect_compare" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
													runat="server" Visible="True" Cssclass="MBUTTONACCPRO" Text="Select"></ASP:BUTTON>
												<ASP:PANEL id="PanelHoldItems" runat="server" Width="85%" Visible="True">
													<BR>
													<ASP:DATAGRID id="dgHoldEntity" runat="server" Width="100%" CssClass="pagecontents" Visible="True"
														AllowPaging="True" AutoGenerateColumns="True" PageSize="5" CellPadding="1" OnDeleteCommand="dgHoldEntity_DeleteCommand">
														<SELECTEDITEMSTYLE Height="20px"></SELECTEDITEMSTYLE>
														<EDITITEMSTYLE Height="20px"></EDITITEMSTYLE>
														<ALTERNATINGITEMSTYLE Height="20px"></ALTERNATINGITEMSTYLE>
														<ITEMSTYLE Height="20px"></ITEMSTYLE>
														<HEADERSTYLE CssClass="itemheader"></HEADERSTYLE>
														<FOOTERSTYLE Height="20px"></FOOTERSTYLE>
														<COLUMNS>
															<ASP:TEMPLATECOLUMN>
																<HEADERSTYLE Width="17px"></HEADERSTYLE>
																<ITEMTEMPLATE>
																	<ASP:IMAGEBUTTON id="btndelete" Runat="server" Width="17" Height="17" CommandName="Delete" ImageUrl="/images/infiniplan/deleteItem.gif"></ASP:IMAGEBUTTON>
																</ITEMTEMPLATE>
															</ASP:TEMPLATECOLUMN>
														</COLUMNS>
														<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" Font-Italic="True" Mode="NumericPages" HorizontalAlign="Right"
															BorderStyle="Dotted"></PAGERSTYLE>
													</ASP:DATAGRID>
												</ASP:PANEL>
												<asp:Label id="lbl_Name_compare" runat="server" Width="82px" CssClass="wizardText" Visible="False">Meter Name</asp:Label>
												<asp:TextBox id="txt_Name_compare" runat="server" Visible="False"></asp:TextBox>
												<ASP:LABEL id="lblError_compare" runat="server" CssClass="wizardText" Visible="False" ForeColor="Red"></ASP:LABEL></TD>
										</TR>
									</TABLE>
									<BR>
								</ASP:PANEL><BR>
								<ASP:BUTTON id="btnShowComparision" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
									runat="server" Visible="True" Cssclass="MBUTTONACCPRO" Text="Show" Enabled="False"></ASP:BUTTON>&nbsp;<asp:button id="btnNext_Compare" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
									runat="server" Cssclass="MBUTTONACCPRO" Text="Next"></asp:button></TD>
							<TD vAlign="top" align="center" width="30%" height="100%">
								<TABLE id="Table5" height="100%" align="center" border="0">
									<TR vAlign="top" align="centre">
										<TD align="center">
											<DIV class="meterSpaveCompare" id="maindiv"><asp:label id="lblCMeterName" runat="server" CssClass="flashTitle"></asp:label><ASP:TABLE id="PlanCompareTable" Visible="True" Runat="server" width="100%" Height="60%" border="0"
													align="center"></ASP:TABLE></DIV>
										</TD>
									</TR>
								</TABLE>
							</TD>
							</td></TR>
					</TBODY></TABLE>
			</asp:panel>
			<!-- /Compare Products  --> </TD></TR></TBODY></TABLE> 
			<!-- /table --> </TD>
			<td class="TableBox_Right" width="0%"></td>
			</TR>
			<tr>
				<td class="TableBox_Bot_Left" width="0%"></td>
				<td class="TableBox_Bot" width="100%"></td>
				<td class="TableBox_Bot_Right" width="0%"></td>
			</tr>
			</asp:panel></TBODY></TABLE></TD></TR></TBODY></TABLE> 
			<!-- Actual Page Contents are to be written upto here  -->
			<!-- **************************************************************************************************************************** --> 
			</TD></TR></TBODY></TABLE></TD></TR>
			<tr>
				<td vAlign="bottom"><uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></td>
			</tr>
			</TBODY></TABLE></form>
		</TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></FORM></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></FORM> 
		<!-- <script>
document.domain='infinimation.com';
var scrollHeight = parent.frames['servicesFrame'].document.body.scrollHeight  ;
var scrollWidth = parent.frames['servicesFrame'].document.body.scrollWidth  ;
parent.resizeFrame(scrollHeight,scrollWidth);
 
		</script> -->
	</body>
</HTML>
