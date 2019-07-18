<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MeterWizard.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.MeterWizard"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML xmlns:o xmlns:u1>
	<HEAD>
		<title>Meter Wizard</title>
		<BUSINESSPLAN:FILES id="file1" runat="server"></BUSINESSPLAN:FILES><LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"></LINK>
		<script src="../../Library/Scripts/GeneralAssumption.js"></script>
		<script src="../../Library/Scripts/PlanWizard.js"></script>
		<script src="../../Library/Scripts/simModal.js"></script>
		<script src="../../Library/Scripts/FAQ_ToggleDL.js"></script>
		<!--<script type="text/javascript" src="FAQ_ToggleDL/FAQ_ToggleDL.js"></script>-->
		<script language="javascript">
		
		function callme(o)
		{
		 var strmatername =o;
		  var decision;
	 	decision=confirm("Do you want to add '" +strmatername+  "' Clip to your Favorites ?" , "");
		var getdecval=document.getElementById("FavClip");
		getdecval.value=decision;
	 	alert("You entered: " + getdecval.value)
	 	session("aa")=getdecval.value
	 	
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
		</script>
	</HEAD>
	<body class="cngbody">
		<form id="Form2" method="post" runat="server">
			<a name="top"></a><!-- Top of Page Anchor -->
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
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
											<tr>
												<td vAlign="top" align="center" height="19"><asp:label id="lblHeading" runat="server" Width="100%" CssClass="lblHeading"></asp:label></td>
												<asp:dropdownlist id="cmbMonth" runat="server" Width="38%" CssClass="wizardOptions" AutoPostBack="true"
													Visible="False"></asp:dropdownlist></tr>
											<tr>
												<td align="center"><asp:panel id="testpanel" height="100%" width="100%" Runat="server">
														<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<TBODY>
																<TR>
																	<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
																	<TD class="TableBox_Top" height="3">&nbsp;</TD>
																	<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
																</TR>
																<TR>
																	<TD class="TableBox_Left" width="0%"></TD>
																	<TD vAlign="top" height="100%"><!-- table -->
																		<TABLE height="100%" width="100%" border="0">
																			<TR vAlign="middle" height="100%" Width="100%">
																				<TD vAlign="middle" width="100%" height="100%"><!-- Compose -->
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
																									<TD vAlign="middle" align="center" height="80%">
																										<ASP:LABEL id="Heading" runat="server" Width="70%" Height="35px" cssclass="wizardHeader1">InfiniPlan Analysis 
                                Wizard</ASP:LABEL></TD>
																								</TR>
																								<TR vAlign="middle">
																									<TD vAlign="middle" align="center" height="20%">
																										<ASP:LABEL id="Title" runat="server" Width="70%" cssclass="wizardTitle1"></ASP:LABEL></TD>
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
																												</ASP:LABEL><IMG id="meterimg" src="/images/infiniplan/ImgMeter.jpg" runat="server" visible="false">
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
																																				<TD align="center"><IMG id="titleimg" src="/images/infiniplan/ImgTitle.jpg" runat="server" Visible="False"></TD>
																																			</TR>
																																			<TR>
																																				<TD>
																																					<ASP:LABEL id="lblID" runat="server" CssClass="wizardOptions" Visible="False">ID</ASP:LABEL></TD>
																																				<TD>
																																					<ASP:TEXTBOX id="txtID" runat="server" CssClass="wizardText" Width="56px" Visible="False"></ASP:TEXTBOX></TD>
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
																																		<ASP:PANEL id="PanelImages" runat="server" Width="100%" Visible="False">
																																			<TABLE height="0%" width="0%" align="center" border="0">
																																				<TR>
																																					<TD align="center" width="100" height="131">
																																						<TABLE height="0%" width="0%" align="center" border="0" vAlign="middle">
																																							<TR>
																																								<TD vAlign="middle" align="center">
																																									<ASP:IMAGEBUTTON id="Imeter" runat="server" Visible="False" ImageUrl="/images/infiniplan/meter.jpg"></ASP:IMAGEBUTTON><BR>
																																								</TD>
																																							</TR>
																																						</TABLE>
																																					</TD>
																																					<TD align="center" width="100" height="131">
																																						<TABLE height="0%" width="0%" align="center" border="0">
																																							<TR>
																																								<TD vAlign="middle" align="center">
																																									<ASP:IMAGEBUTTON id="IActuals" runat="server" Visible="False" ImageUrl="/images/infiniplan/Actuals.jpg"></ASP:IMAGEBUTTON><BR>
																																								</TD>
																																							</TR>
																																						</TABLE>
																																					</TD>
																																					<TD align="center" width="100" height="131">
																																						<TABLE height="0%" width="0%" align="center" border="0">
																																							<TR>
																																								<TD vAlign="middle" align="center">
																																									<ASP:IMAGEBUTTON id="Icombine" runat="server" Visible="False" ImageUrl="/images/infiniplan/combine.jpg"></ASP:IMAGEBUTTON><BR>
																																								</TD>
																																							</TR>
																																						</TABLE>
																																					</TD>
																																				</TR>
																																				<TR>
																																					<TD align="center" width="30%">
																																						<ASP:RADIOBUTTON id="rbImeter" runat="server" Visible="False" cssclass="wizardOptions" Text="Single"
																																							GroupName="rbgroup"></ASP:RADIOBUTTON></TD>
																																					<TD align="center" width="30%">
																																						<ASP:RADIOBUTTON id="rbIActuals" runat="server" Visible="False" cssclass="wizardOptions" Text="Multiple"
																																							GroupName="rbgroup"></ASP:RADIOBUTTON></TD>
																																					<TD align="center" width="30%">
																																						<ASP:RADIOBUTTON id="rbIcombine" runat="server" Visible="False" cssclass="wizardOptions" Text="Deviation"
																																							GroupName="rbgroup"></ASP:RADIOBUTTON></TD>
																																				</TR>
																																			</TABLE>
																																		</ASP:PANEL>
																																		<ASP:RADIOBUTTONLIST id="rbCriterialist" runat="server" Visible="False" cssclass="wizardOptions" BorderColor="#FFC0C0"></ASP:RADIOBUTTONLIST>
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
																																				<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" BorderStyle="Dotted" HorizontalAlign="Right"
																																					Mode="NumericPages" Font-Italic="True"></PAGERSTYLE>
																																			</ASP:DATAGRID>
																																		</ASP:PANEL>
																																		<ASP:PANEL id="Panel1" runat="server" Width="85%" Visible="True" height="5%">
																																			<ASP:DATAGRID id="dgActualEntity" runat="server" Visible="False" width="100%" Height="100%" cssclass="pagecontents"
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
																																							<ASP:CHECKBOX id="chkSelect" runat="server" OnCheckedChanged="dgActualEntity_CheckChanged"></ASP:CHECKBOX>
																																						</ITEMTEMPLATE>
																																						<FOOTERSTYLE Height="17px"></FOOTERSTYLE>
																																					</ASP:TEMPLATECOLUMN>
																																					<ASP:BOUNDCOLUMN HeaderText="Entity Name" DataField="Entity Name"></ASP:BOUNDCOLUMN>
																																				</COLUMNS>
																																				<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" BorderStyle="Dotted" HorizontalAlign="Right"
																																					Mode="NumericPages" Font-Italic="True"></PAGERSTYLE>
																																			</ASP:DATAGRID>
																																		</ASP:PANEL><BR>
																																		<ASP:BUTTON id="btnSelect" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																																			runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="Select"></ASP:BUTTON>
																																		<ASP:PANEL id="PanelHoldItems" runat="server" Width="85%" Visible="True">
																																			<BR>
																																			<ASP:DATAGRID id="dgHoldEntity" runat="server" CssClass="pagecontents" Width="100%" Visible="False"
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
																																							<ASP:IMAGEBUTTON id="btndelete" Width="17" Runat="server" Height="17" ImageUrl="/images/infiniplan/deleteItem.gif"
																																								CommandName="Delete"></ASP:IMAGEBUTTON>
																																						</ITEMTEMPLATE>
																																					</ASP:TEMPLATECOLUMN>
																																				</COLUMNS>
																																				<PAGERSTYLE CssClass="ExportedPlans_PagerStyle1" BorderStyle="Dotted" HorizontalAlign="Right"
																																					Mode="NumericPages" Font-Italic="True"></PAGERSTYLE>
																																			</ASP:DATAGRID>
																																		</ASP:PANEL>
																																		<asp:Label id="lbl_Name" runat="server" CssClass="wizardText" Width="82px" Visible="False">Meter Name</asp:Label>
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
																		runat="server" Cssclass="MBUTTONACCPRO" Text="Save" Enabled="False"></ASP:BUTTON>
																	<ASP:BUTTON id="viewGraph" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																		runat="server" Visible="False" Cssclass="MBUTTONACCPRO" Text="View MyClip"></ASP:BUTTON></TD>
															</TR>
															<TR vAlign="top" height="65%">
																<TD vAlign="top" align="center" colSpan="4" height="65%"><BR>
																	<ASP:PANEL id="flashpanel" CssClass="td1b" Width="90%" Visible="False" Runat="server">
																		<TABLE height="100%" width="100%" align="center" border="0">
																			<TR height="5%" width="100%">
																				<TD align="center">
																					<ASP:LABEL id="flashheader11" runat="server" cssclass="flashTitle"></ASP:LABEL></TD>
																			</TR>
																			<TR vAlign="top" height="95%" width="100%">
																				<TD vAlign="top" align="center">
																					<ASP:TABLE id="flashTable" runat="server" Height="90%" HorizontalAlign="Center"></ASP:TABLE>&nbsp;
																				</TD>
																			</TR>
																		</TABLE>
																	</ASP:PANEL></TD>
															</TR>
															<TR vAlign="top" height="15%">
																<TD></TD>
															</TR>
														</TABLE>
													</asp:panel></ASP:PANEL> 
													<!-- /Compose -->
													<!-- Listing --><asp:panel id="Panelnoclip" height="100%" width="100%" Runat="server" visible="false">
														<TABLE height="100%" width="100%" align="center" border="0">
															<TR vAlign="top" height="100%">
																<TD align="center">
																	<ASP:LABEL id="lblNoClip" runat="server" Visible="False" cssclass="MeterwizardText"></ASP:LABEL></TD>
															</TR>
														</TABLE>
													</asp:panel><asp:panel id="PanelListing" Width="100%" Runat="server" visible="false">
														<TABLE height="100%" width="100%" align="center" border="0">
															<TR vAlign="top" height="5%">
																<TD align="center">
																	<ASP:LABEL id="lblClipHeading" runat="server" cssclass="MeterwizardText"></ASP:LABEL></TD>
															</TR>
															<TR vAlign="bottom">
																<TD align="center" height="95%">
																	<TABLE height="98%" width="97%" align="center" border="0">
																		<TR vAlign="top">
																			<TD align="center">
																				<ASP:PANEL id="PanelListingforClips" CssClass="tableborder1" Width="100%" Runat="server" height="100%"
																					visible="True">
																					<TABLE height="100%" width="100%" align="center" border="0">
																						<TR vAlign="top">
																							<TD align="center" width="40%">
																								<ASP:LABEL id="Label3" runat="server" cssclass="wizardtext1">Select clip by click 
                                below of any one </ASP:LABEL><BR>
																								<BR>
																								<ASP:PANEL id="Panel3" CssClass="tableborder1" Width="90%" Runat="server" height="88%" visible="True">
																									<TABLE border="0">
																										<TR>
																											<TD align="center">
																												<ASP:LABEL id="Label4" runat="server" CssClass="selectedNodeToplbl"></ASP:LABEL></TD>
																										</TR>
																										<TR>
																											<TD>
																												<DIV class="MeterList" id="divViews" align="center">
																													<IEWC:TREEVIEW id="TreeView1" tabIndex="5" runat="server" AutoPostBack="True" DefaultStyle="font-family:Times New Roman;font-size:14pt;background-color:white;"
																														SelectedStyle="filter=none;background-color:LightSteelBlue;&#13;&#10;font-weight:bold;font-color:#ffffff;"
																														HoverStyle="filter=none;background-color:#ECF4FC;"></IEWC:TREEVIEW></DIV>
																											</TD>
																										</TR>
																									</TABLE>
																								</ASP:PANEL></TD>
																							<TD vAlign="top" align="center" width="60%">
																								<AJAX:AJAXPANEL id="Ajaxpanel2" runat="server" width="100%">
																									<ASP:LABEL id="lblMeterName" runat="server" CssClass="wizardtext1"></ASP:LABEL>
																								</AJAX:AJAXPANEL><BR>
																								<BR>
																								<ASP:PANEL id="Panel4" CssClass="tableborder1" Width="90%" Runat="server" Height="70%" HorizontalAlign="Center">
																									<TABLE height="60%" width="100%" align="center" border="0">
																										<TR height="70%">
																											<TD width="100%">
																												<ASP:TABLE id="Table2" runat="server" CssClass="trsettings" Height="80%" HorizontalAlign="Center"></ASP:TABLE>&nbsp;
																											</TD>
																										</TR>
																									</TABLE>
																								</ASP:PANEL></TD>
																						</TR>
																					</TABLE>
																				</ASP:PANEL></TD>
																		</TR>
																	</TABLE>
																</TD>
															</TR>
														</TABLE>
													</asp:panel>
													<!-- /Listing -->
													<!-- Favorites --><asp:panel id="PanelNoFAvorites" Width="100%" height="100%" Runat="server" visible="false">
														<TABLE height="100%" width="100%" align="center" border="0">
															<TR vAlign="top" height="100%">
																<TD align="center">
																	<ASP:LABEL id="lblnotfavorites" runat="server" Visible="False" cssclass="MeterwizardText"></ASP:LABEL></TD>
															</TR>
														</TABLE>
													</asp:panel><asp:panel id="PanelFavorites" Width="100%" CssClass="tableborder1" Runat="server" visible="false"
														Height="100%">
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
																					<ASP:PANEL id="PanelFav" CssClass="tableborder1" Width="100%" Runat="server" height="100%"
																						visible="True">
																						<TABLE height="100%" width="100%" align="center" border="0">
																							<TBODY>
																								<TR vAlign="top">
																									<TD align="center" width="100%" height="100%">
																										<DIV class="meterSpave1" id="maindiv">
																											<ASP:TABLE id="PlanFavTable" Runat="server" Height="80%" HorizontalAlign="Center"></ASP:TABLE></DIV>
																									</TD></TD>
																			</TR>
																		</TABLE>
													</asp:panel></td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
							</asp:panel> 
							<!-- /Favorites --></td>
					</tr>
				</TBODY>
			</table>
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
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
