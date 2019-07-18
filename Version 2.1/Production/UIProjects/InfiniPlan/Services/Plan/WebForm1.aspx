<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="Infinilogic.BusinessPlan.Web.WebForm1"%>
<%@ Register TagPrefix="bdp" Namespace="BasicFrame.WebControls" Assembly="BasicFrame.WebControls.BasicDatePicker" %>
<%@ Register TagPrefix="BusinessPlan" TagName="Files" src="../../Include/Files.ascx"		      %>
<%@ Register TagPrefix="BusinessPlan" TagName="LeftBar" src="../../Include/LeftBar.ascx"		  %>
<%@ Register TagPrefix="uc1" TagName="BizPlanFooter" Src="../../Include/BizPlanFooter.ascx" %>
<%@ Register TagPrefix="BusinessPlan" TagName="HeaderBar" src="../../Include/HeaderBar.ascx"      %>
<%@ Register TagPrefix="BizPlan" Namespace="Infinilogic.BusinessPlan.WebControls" Assembly="Infinilogic.BusinessPlan.WebControls" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<%@ Register TagPrefix="ajax" Namespace="MagicAjax.UI.Controls" Assembly="MagicAjax" %>
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
		  	 
 

		function SetRbValue1(o)
		{
 
 
		var idval = o;
 		var getidval=document.getElementById("SelectedRowNumber");
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
							<!--        Header Bar  --><BUSINESSPLAN:HEADERBAR id="Headerbar1" runat="server"></BUSINESSPLAN:HEADERBAR></td>
					</tr>
					<tr>
						<td vAlign="top" height="100%">
							<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TBODY>
									<tr>
										<td vAlign="top" width="1%"><BUSINESSPLAN:LEFTBAR id="Leftbar2" runat="server"></BUSINESSPLAN:LEFTBAR></td>
										<td vAlign="top" width="1"><IMG height="1" src="../../images/InfiniPlan/blank.gif" width="20"></td>
										<td vAlign="top" width="100%">
											<!-- **************************************************************************************************************************** -->
											<!-- Actual Page Contents are to be written here  -->
											<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TBODY>
              <tr>
														<td align="center"><asp:panel id="testpanel" Runat="server" width="100%" height="100%">
																<TABLE dir="ltr" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="TableBox_Top_Left" height="3"><IMG src="\images\blank.gif" width="16"></TD>
																		<TD class="TableBox_Top" height="3">&nbsp;
																		</TD>
																		<TD class="TableBox_Top_Right" height="3">&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD class="TableBox_Left" width="0%"></TD>
																		<TD vAlign="top" width="100%">
																			<asp:Panel id="PanelCompareProducts" runat="server">
																				<TABLE id="Table3" height="1%" width="100%" border="0">
																					<TBODY>
																						<TR height="1%" width="50%">
																							<TD align="center" colSpan="2" height="1%">
																								<ASP:LABEL id="Label2" runat="server" CssClass="lblhelpMessage"> You can 
																								  compare your records by using that menu option .Mention <b>From</b> & <b>To</b> Date, click <b>Select</b> button.Then Click <b>Show</b> button. </ASP:LABEL></TD>
																						</TR>
																						<TR>
																							<TD>&nbsp;</TD>
																						</TR>
																						<TR height="1%" width="50%">
																							<TD align="center" colSpan="2">
																								<asp:Panel id="Panel2" runat="server" CssClass="tableborder1" Width="50%" Height="32px">
																									<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="center" border="0">
																										<TR>
																											<TD align="center">
																												<ASP:LABEL id="Label1" runat="server" CssClass="wizardText" Visible="True" DESIGNTIMEDRAGDROP="1086">From </ASP:LABEL></TD>
																											<TD width="112">
																												<BDP:BDPLITE id="BDPLiteFrom" runat="server" Visible="true" DESIGNTIMEDRAGDROP="1087" TextBoxColumns="12"></BDP:BDPLITE></TD>
																											<TD align="center">
																												<ASP:LABEL id="Label3" runat="server" CssClass="wizardText" Visible="True" DESIGNTIMEDRAGDROP="1088">To </ASP:LABEL></TD>
																											<TD width="122">
																												<BDP:BDPLITE id="BDPLiteTo" runat="server" Visible="True" DESIGNTIMEDRAGDROP="1089" TextBoxColumns="12"></BDP:BDPLITE></TD>
																											<TD align="center"></TD>
																										</TR>
																									</TABLE>
																								</asp:Panel>
																								<ASP:LABEL id="lblfiscalyear" runat="server" CssClass="wizardText" Visible="True"></ASP:LABEL></TD>
																						</TR>
																						<TR>
																							<TD align="center" colSpan="2">&nbsp;</TD>
																						</TR>
																						<TR vAlign="top" height="1%" width="50%">
																							<TD vAlign="top" align="center" width="30%" height="1%">
																								<ASP:PANEL class="comparetableborder" id="mypanel" Runat="server">
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
																												<ASP:TEXTBOX id="txtID_compare" runat="server" CssClass="wizardText" Width="56px" Visible="True"></ASP:TEXTBOX></TD>
																											<TD>
																												<ASP:LABEL id="lblName_compare" runat="server" CssClass="wizardOptions" Visible="True">Name</ASP:LABEL></TD>
																											<TD>
																												<ASP:TEXTBOX id="txtName_compare" runat="server" CssClass="wizardText" Visible="True"></ASP:TEXTBOX></TD>
																											<TD>
																												<ASP:BUTTON id="btnSearch_compare" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																													runat="server" Visible="True" Text="Search" Cssclass="MBUTTONACCPRO"></ASP:BUTTON></TD>
																										</TR>
																										<TR>
																											<TD align="center" colSpan="5"><BR>
																												<ASP:PANEL id="Panel1" runat="server" height="5%" Width="85%" Visible="True">
																													<ASP:DATAGRID id="dgActualEntity" runat="server" width="100%" Height="100%" Visible="True" cssclass="pagecontents"
																														CellPadding="1" PageSize="5" AutoGenerateColumns="False" AllowPaging="True">
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
																													runat="server" Visible="True" Text="Select" Cssclass="MBUTTONACCPRO"></ASP:BUTTON>
																												<ASP:PANEL id="PanelHoldItems" runat="server" Width="85%" Visible="True">
																													<BR>
																													<ASP:DATAGRID id="dgHoldEntity" runat="server" CssClass="pagecontents" Width="100%" Visible="True"
																														CellPadding="1" PageSize="5" AutoGenerateColumns="True" AllowPaging="True" OnDeleteCommand="dgHoldEntity_DeleteCommand">
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
																												<asp:Label id="lbl_Name_compare" runat="server" CssClass="wizardText" Width="82px" Visible="False">Meter Name</asp:Label>
																												<asp:TextBox id="txt_Name_compare" runat="server" Visible="False"></asp:TextBox>
																												<ASP:LABEL id="lblError_compare" runat="server" CssClass="wizardText" Visible="False" ForeColor="Red"></ASP:LABEL></TD>
																										</TR>
																									</TABLE>
																									<BR>
																								</ASP:PANEL><BR>
																								<ASP:BUTTON id="btnShowComparision" onmouseover="this.className='MBUTTONACCPROON';" onmouseout="this.className='MBUTTONACCPRO';"
																									runat="server" Visible="True" Text="Show" Cssclass="MBUTTONACCPRO" Enabled="False"></ASP:BUTTON></TD>
																							<TD vAlign="top" align="center" width="30%" height="100%">
																								<TABLE id="Table5" height="100%" align="center" border="0">
																									<TR vAlign="top" align="centre">
																										<TD align="center">
																											<DIV class="meterSpaveCompare" id="maindiv">
																												<ASP:TABLE id="PlanCompareTable" width="100%" Runat="server" Height="60%" Visible="True" border="0"
																													align="center"></ASP:TABLE></DIV>
																										</TD>
																									</TR>
																								</TABLE>
																							</TD></TD>
																	</TR>
																</TABLE>
															</asp:panel></td>
														<TD class="TableBox_Right" width="0%"></TD>
													</tr>
                    <TR>
														<TD class="TableBox_Bot_Left" width="0%"></TD>
														<TD class="TableBox_Bot" width="100%">
														</TD>
														<TD class="TableBox_Bot_Right" width="0%"></TD>
													</TR></asp:panel></TBODY></table>
										</td>
									</tr>
								</TBODY></table> <!-- Actual Page Contents are to be written upto here  --> <!-- **************************************************************************************************************************** --></td>
					</tr>
				</TBODY></table>
			</TD></TR>
			<TR>
				<TD vAlign="bottom">
					<uc1:bizplanfooter id="BizPlanFooter1" runat="server"></uc1:bizplanfooter></TD>
			</TR>
			</TBODY></TABLE></form>
	</body>
</HTML>
