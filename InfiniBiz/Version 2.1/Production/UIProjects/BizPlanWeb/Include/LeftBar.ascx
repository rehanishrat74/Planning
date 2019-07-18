<%@ Import  Namespace="Infinilogic.BusinessPlan.Web.Common" %>
<%@ Register TagPrefix="cc1" Namespace="skmMenu" Assembly="skmMenu" %>
<%@ Control Language="vb" Codebehind="LeftBar.ascx.vb" Inherits="Infinilogic.BusinessPlan.Web.LeftBar"  %>
<%@ Register TagPrefix="Include" TagName="IndexLeft" Src="/Library/components/ServicesList.ascx" %>
<!--<LINK href="../Library/Styles/MainStyle.css" type="text/css" rel="stylesheet"> -->
<%
if Not ( NavigationLinks is Nothing ) then 
%>
<script>

 


function showdiv(divid,imgid)
{
var div=document.getElementById(divid)
var img=document.getElementById(imgid)
//var a=document.all.divid.innerHTML;

    if(div.style.display=='block')
    {
		img.src='/images/InfiniPlannew_leftbar_top_2nd.gif'
        div.style.display='none';
        
    }
    else if(div.style.display=='none')
    {
  //      hideall();
        img.src='/images/InfiniPlannew_leftbar_top_2ndtoparrow.gif'
        div.style.display='block';
    }
}

</script>
 

<!--<table id="contMenu1" cellSpacing="0" cellPadding="0" width="180" border="0" runat="server">
	<tr>
		<td vAlign="top" width="5" height="1"><IMG height="1" src="/images/InfiniPlanblank.gif" width="5"></td>
		<td vAlign="top" width="133" height="1">
			<TABLE id="tblMenuHeader" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD vAlign="top" align="left" width="194">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="175" border="0">
							<TR onmouseover="this.style.cursor='hand'" onclick='showdiv("menu1","leftimg1")'>
								<TD vAlign="top"><IMG src="/images/InfiniPlan/arrow_cat_new.jpg"></TD>
								<TD vAlign="middle" align="left" width="100%" class="link-linkmenu"><%=istMenuTitle%></TD>
								<TD vAlign="top" align="right"><IMG id='leftimg1' alt="Click to Expand / Collapse" src="" height="1" width="0"></A></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<DIV id="menu1" style="DISPLAY: block">
							<TABLE id="tblCont2" class="tableborder" cellSpacing="0" cellPadding="0" width="173" border="0">
								<TR>
									<TD vAlign="top" colSpan="3"><IMG height="2" src="/images/InfiniPlanblank.gif" width="1"></TD>
								</TR>
								<TR>
									<TD vAlign="top" width="2"><IMG height="1" src="/images/InfiniPlanblank.gif" width="2"></TD>
									<TD vAlign="top" width="169">
										<TABLE id="tblMenu1" cellSpacing="0" cellPadding="0" width="169" border="0" runat="server">
										</TABLE>
									</TD>
									<TD vAlign="top" align="right" width="2"><IMG height="1" src="/images/InfiniPlanblank.gif" width="2"></TD>
								</TR>
								<TR>
									<TD vAlign="top" colSpan="3"><IMG height="2" src="/images/InfiniPlanblank.gif" width="1"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td vAlign="top">&nbsp;</td>
		<td vAlign="top">&nbsp;</td>
	</tr>
</table>
<table id="contMenu2" cellSpacing="0" cellPadding="0" width="180" border="0" runat="server">
	<tr>
		<td vAlign="top" width="5" height="1"><IMG height="1" src="/images/InfiniPlanblank.gif" width="5"></td>
		<td vAlign="top" width="133" height="1">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
				<TR>
					<TD vAlign="top" align="left" width="194">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="175" border="0">
							<TR onmouseover="this.style.cursor='hand'" onclick='showdiv("q1","leftimg")'>
								<TD vAlign="top"><IMG src="/images/InfiniPlan/arrow_cat_new.jpg"></TD>
								<TD vAlign="middle" align="left" class="link-linkmenu" width="100%"><%=secondMenuTitle%></TD>
								<TD vAlign="top" align="right" width="23"><A href="javascript:"><IMG id="leftimg" height="1" alt="Click to Expand / Collapse" src=" " width="0" border="0"></A></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<DIV id="q1" cssclass="InfiniBizMenu" style="DISPLAY: block">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="173" border="0" class="tableborder">
								<TR>
									<TD vAlign="top" colSpan="3"><IMG height="2" src="/images/InfiniPlanblank.gif" width="1"></TD>
								</TR>
								<TR>
									<TD vAlign="top" width="1"><IMG src="/images/InfiniPlan/blankarrow.jpg"></TD>
									<TD vAlign="top" width="169">
										<TABLE id="tblText" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
											<TR>
												<TD onmouseover="this.style.cursor='hand'" onmouseout="this.style.cursor='hand'" vAlign="middle"
													height="20">
													<cc1:menu id="Menu1" runat="server" layout="Vertical" menufadedelay="1"></cc1:menu></TD>
											</TR>
										</TABLE>
										<TABLE id="tblMenu2" cellSpacing="0" cellPadding="0" width="148" border="0" runat="server">
										</TABLE>
									</TD>
									<TD vAlign="top" align="right" width="2"><IMG height="1" src="/images/InfiniPlanblank.gif" width="2"></TD>
								</TR>
								<TR>
									<TD vAlign="top" colSpan="3"><IMG height="2" src="/images/InfiniPlanblank.gif" width="1"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</td>
	</tr>
	<tr>
		<td vAlign="top" height="50">&nbsp;</td>
		<td vAlign="top" height="50">&nbsp;</td>
	</tr>
</table>
<%
Else 
%>
<table cellSpacing="0" cellPadding="0" width="180" border="0" id="Table5">
	<tr>
		<td vAlign="top" width="5" height="1"><IMG height="1" src="/images/InfiniPlanblank.gif" width="5"></td>
		<td vAlign="top" width="133" height="1"><IMG height="1" src="/images/InfiniPlanblank.gif" width="5"></td>
	</tr>
</table>
<p class="leftlink">
	<%
End If 
%>
</p> -->

<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" height=100%>
	<TR >
		<TD height=100%>
		<div style="height:100%;">
			<Include:IndexLeft id="Index_Left" runat="server" SelProdCode="108"></Include:IndexLeft></TD></div>
	</TR>
</TABLE>
