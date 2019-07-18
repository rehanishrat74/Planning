<%@ outputcache Location="None" %>
<%@ Register TagPrefix="uc1" TagName="datecontrol" Src="../Library/components/datecontrol.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="FAQ.aspx.vb" Inherits="InfiniLogic.AccountsCentre.Web.FAQ" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Accounts Centre - FAQ</title>
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
		<LINK href="/library/style/main.css" type="text/css" rel="stylesheet">
		<script>
var httpSiteName = "http://www.formationshouse.com";
function _select_lang() 
{ 
	var lang = _langmenu.options[_langmenu.selectedIndex].value; 
	if (lang != "") 
		window.location.href = httpSiteName + lang; 
	 
}
function ShowTr(id)
{
	var o = document.getElementById(id);
	if (o.style.display == "none")
		o.style.display = "block";
	else
		o.style.display = "none";
}
		</script>
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
											<table width="778" height="100%" border="0" align="center" cellpadding="0" cellspacing="0"
												bgcolor="#ffffff" class="border_both_side">
												<form action="http://www.formationshouse.com/logaction.php" name="loginform">
												</form>
												<tr>
													<td vAlign="top" height="97%">
														<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr vAlign="top">
																<td>
																	<table cellSpacing="0" cellPadding="0" width="99%" align="right" border="0">
																		<tr>
																			<td vAlign="top" align="left">
																				<table cellSpacing="1" cellPadding="0" width="100%" border="0">
																					<tr>
																						<td vAlign="top">
																							<p><IMG height="5" src="\images/emptyimage.jpg" width="2"></p>
																						</td>
																					</tr>
																					<tr>
																						<td vAlign="top">
																							<table style="WIDTH: 568px; " cellSpacing="0" cellPadding="0" width="568"
																								align="left" border="0">
																								<tr vAlign="top">
																									<td width="13"><IMG height="31" src="\images/crv1.jpg" width="16"></td>
																									<td vAlign="bottom" width="1067" background="\images/crv_topbg.jpg">
																										<table cellSpacing="0" cellPadding="0" width="77%" border="0">
																											<tr>
																												<td vAlign="bottom"><span class="headding">FAQs</span></td>
																											</tr>
																										</table>
																									</td>
																									<td width="17"><IMG height="31" src="\images/crv2.jpg" width="17"></td>
																								</tr>
																								<tr vAlign="top">
																									<td background="\images/crv1bg.jpg"><IMG height="5" src="\images/crv1bg.jpg" width="16"></td>
																									<td>
																										<table style="WIDTH: 565px;" cellSpacing="5" width="565" border="0">
																											<tr>
																												<td class="main_text" vAlign="top">
																													<br>
																													<strong><font size=3>Accounts Centre related :</font></strong>
																													<ul>																														
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ1');" href="#_self1"><b>How do I become 
																																		a member of Accounts Centre?</b></A> </strong>
																															<p id="AccQ1" style="DISPLAY: none"><font color="#000000">In order to become a member 
																																	of Accounts Centre, you must be subscribed to at least one of its services. </font>
																															</p>
																															<p id="AccQ1h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">[ <A class="url_text" onclick="ShowHide('AccQ1');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ2');" href="#_self1"><b>How does Anytime, Anywhere Access work?</b></A> </strong>
																															<p id="AccQ2" style="DISPLAY: none"><font color="#000000">‘Anytime, Anywhere Access’ means you can work on your accounting from anywhere with an Internet connection (e.g. from the road, a client site, or in your home office after hours). All that is required is an internet connection and your computer in order to register, subscribe and then login to begin using the Accounts Centre accounting solutions. In this manner, your business finances are always available to you in an update manner.</font>
																															</p>
																															<p id="AccQ2h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">[ <A class="url_text" onclick="ShowHide('AccQ2');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ3');" href="#_self1"><b>Can anyone become a member of Accounts Centre?</b></A> </strong>
																															<p id="AccQ3" style="DISPLAY: none"><font color="#000000">Yes, all Private Limited Companies, incorporated in the United Kingdom, can subscribe to Accounts Centre.</font>
																															</p>
																															<p id="AccQ3h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ3');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ4');" href="#_self1"><b>How do I subscribe?</b></A> </strong>
																															<p id="AccQ4" style="DISPLAY: none"><font color="#000000">To subscribe, please visit the member's registration page, and fill out the given simple form. </font>
																															</p>
																															<p id="AccQ4h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ4');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ5');ShowHideControl('AccQ5i');ShowHideControl('AccQ5j');" href="#_self1"><b>Do I have a choice to subscribe to all or part of the Accounts Centre services?</b></A> </strong>
																															<p id="AccQ5" style="DISPLAY: none">
																																<font color="#000000">Yes, you certainly have a choice when registering for services at Accounts Centre. You may register for all or a mix of the following:			
																																</font>
																															</p>
																															<ul id="AccQ5i" style="DISPLAY:none" class="main_text">
																																	<li><font color="#000000">Services</font></li>
																																	<li><font color="#000000">Accounting Solutions</font></li>
																																	<li><font color="#000000">Softwares</font></li>
																																	<li><font color="#000000">Products</font></li>
																																</ul>
																															<p id="AccQ5j" style="DISPLAY: none">
																																<font color="#000000">You can subscribe, as you require, to all or some of the above when registering with Accounts Centre. For a detailed description of the above list, please visit the Profile page.
																																</font>
																															</p>
																															<p id="AccQ5h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ5');ShowHideControl('AccQ5i');ShowHideControl('AccQ5j');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ6');" href="#_self1"><b>I’m a member of Formations House/ Graphics4Less: do I need to register with Accounts Centre?</b></A> </strong>
																															<p id="AccQ6" style="DISPLAY: none"><font color="#000000">
																															No, you can use the customer ID already assigned to you to log on to Accounts Centre. 
																															<br>
																															If you have previously formed a company through Formations House, you will see its accounting related details, in Accounts Centre Global View, after you have logged in.
																															<br>
																															You can also switch back to Formations House/Graphics4Less from Accounts Centre, if you logged in using the Formations House/Graphics4Less user ID.</font>
																															</p>
																															<p id="AccQ6h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ6');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ7');" href="#_self1">
																															<b>I have formed more than one company from Formations House: how do I view their information in Accounts Centre?</b></A> </strong>
																															<p id="AccQ7" style="DISPLAY: none"><font color="#000000">All the companies formed using Formations House online company formation service can be viewed on the Global View page of Accounts Centre. As soon as a company is formed through Formations House, it is also entered into the Accounts Centre database, where it can be viewed and subscribed to various accounting softwares/services.
																															</font>
																															</p>
																															<p id="AccQ7h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ7');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ8');" href="#_self1">
																															<b>What kind of software or hardware do I need to use Accounts Centre?
																															</b></A> </strong>
																															<p id="AccQ8" style="DISPLAY: none"><font color="#000000">Accounts Centre offers an online accounting system, where the only software and/or hardware that you require is a computer, an internet browser (preferably IE 5 or higher) and an internet connection.<br> 
																															You do not need to buy costly software and database licenses, servers, routers, RAID-array drives or any other complex and expensive computing services. All of the technology required to operate your accounting system is provided by Accounts Centre, directly over the Internet.
																															</font>
																															</p>
																															<p id="AccQ8h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ8');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ9');" href="#_self1">
																															<b>How long does it take to install the Accounts Centre software(s)?
																															</b></A> </strong>
																															<p id="AccQ9" style="DISPLAY: none"><font color="#000000">InfiniAccounts softwares work just like any other software, however instead of installing it on your computer, you access it through your internet browser (preferably IE 5 and above). 
																															</font>
																															</p>
																															<p id="AccQ9h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ9');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ10');" href="#_self1">
																															<b>Do I need to back up my data safe when I am using the Accounts Centre software(s)?
																															</b></A> </strong>
																															<p id="AccQ10" style="DISPLAY: none"><font color="#000000">You do not need to worry about maintaining or losing valuable data due to computer or human error, since your data is backed up automatically. New features In InfiniAccounts software(s) are added automatically so you never have to purchase or install additional software.
																															</font>
																															</p>
																															<p id="AccQ10h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ10');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ11');" href="#_self1">
																															<b>Will InfiniAccounts work on a dialup modem?
																															</b></A> </strong>
																															<p id="AccQ11" style="DISPLAY: none"><font color="#000000">
																															Yes; the Accounts Centre system is designed to be extremely bandwidth-efficient, therefore, it has no large/heavy graphics, long periods of download or complicated operational plug-ins to install. Accounts Centre servers are linked directly to the Internet backbone with multiple, ultra-high-speed OC-3 and OC-12 connections, which minimizes the problems of Internet congestion that plague conventional Internet-based services. As a result, even using a standard 56K dialup modem, you will find acceptable performance. 
																															However, the use of T1, DSL or any broadband Internet connectivity for high-speed data transfer is highly recommended.
																															</font>
																															</p>
																															<p id="AccQ11h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ11');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ12');" href="#_self1">
																															<b>Can you ensure that no one else will access my data?
																															</b></A> </strong>
																															<p id="AccQ12" style="DISPLAY: none"><font color="#000000">Your critical financial data is stored on firewall-protected servers. Once you sign up, only the people whom you yourself invite can access your data. Each user has a unique login and password, and you can track their activity with the always-on activity log. Your data belongs to you and no one at Accounts Centre has access to your password. No one can see your information without your authorization.
																															</font>
																															</p>
																															<p id="AccQ12h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ12');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ13');" href="#_self1">
																															<b>Is it safe to transmit my data over the Internet? 
																															</b></A> </strong>
																															<p id="AccQ13" style="DISPLAY: none"><font color="#000000">
																															Accounts Centre uses encrypted transmission of information between the servers. Secure Socket Layer (SSL) helps ensure that your information is protected during transmission over the Internet. Accounts Centre utilizes the 128-bit SSL encryption, which is also used by banks and online trading and financial companies for their information transfers and security over the Internet. 
																															</font>
																															</p>
																															<p id="AccQ13h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ13');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ14');" href="#_self1">
																															<b>What is E-filing? And how long does the E-filing process take?
																															</b></A> </strong>
																															<p id="AccQ14" style="DISPLAY: none"><font color="#000000">
																															Electronically filing is known as E-filing. If the internet connection is stable and the details of CT600 are correct and match with the records of Inland Revenue, the actual process of E-filing will take no more than 15 min.
																															</font>
																															</p>
																															<p id="AccQ14h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ14');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ15');" href="#_self1">
																															<b>Will I be able to print out and/or save a copy of my Tax Return form?
																															</b></A> </strong>
																															<p id="AccQ15" style="DISPLAY: none"><font color="#000000">
																															Yes, as you finish filling-in your CT600 form, click the PRINT button, given at the end of the last page of form, to take a printout to save as a hardcopy. To save online, click the SAVE button, which provides the Tax Return form in the PDF format.
																															</font>
																															</p>
																															<p id="AccQ15h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ15');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ16');" href="#_self1">
																															<b>Will I be reminded of the due (and over-due) date(s) of my Annual Accounts and CT600?
																															</b></A> </strong>
																															<p id="AccQ16" style="DISPLAY: none"><font color="#000000">
																															Accounts Centre’s automated service will send out reminders, at the end of your company’s financial year and/or when you only have less then 3 months left for filing of accounts and returns.
																															</font>
																															</p>
																															<p id="AccQ16h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ16');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ17');" href="#_self1">
																															<b>Do all companies have to submit audited accounts and records?
																															</b></A> </strong>
																															<p id="AccQ17" style="DISPLAY: none"><font color="#000000">
																															No, all companies are not required to submit audited accounts. Auditing is mandatory only when a turnover threshold is reached i.e. when the company has a turnover of over £1 million per annum and a balance sheet value of over £1.4 million.
Companies falling below this threshold are considered small companies. They may submit abbreviated financial statements which do not require to be audited. 
																															</font>
																															</p>
																															<p id="AccQ17h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ17');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ18');ShowHideControl('AccQ18i');ShowHideControl('AccQ18j');ShowHideControl('AccQ18k');" href="#_self1">
																															<b>What are abbreviated accounts?
																															</b></A> </strong>
																															<p id="AccQ18" style="DISPLAY: none"><font color="#000000">A company that qualifies as a small or as a dormant company may file abbreviated accounts, consisting of:
																															</font>
																															</p>
																															<ul id="AccQ18i" style="DISPLAY:none" class="main_text">
																																	<li><font color="#000000">An abbreviated version of the balance sheet together with abbreviated notes.</font></li>
																																	<li><font color="#000000">A statement immediately above the signature[s] of the director[s] that they have relied upon the exemptions available to the company as a small-sized company.</font></li>
																																	<li><font color="#000000">A special auditor's report stating that the requirements for qualifying as a small-sized company have been met. </font></li>
																																	<li><font color="#000000">A copy of special auditor's report must be included in the full accounts issued to shareholders. </font></li>
																																</ul>
																															<p id="AccQ18j" style="DISPLAY: none">
																																<font color="#000000">
																																There is no requirement for a profit and loss account or a directors' report to be included in the abbreviated accounts. 
																																<br><br>
																																A company that qualifies as a medium-sized company may file abbreviated accounts consisting of:
																																</font>
																															</p>
																															<ul id="AccQ18k" style="DISPLAY:none" class="main_text">
																																	<li><font color="#000000">The full balance sheet together with notes and a statement immediately above the signature[s] of the director[s] that they have relied upon the exemptions available to the company as a medium-sized company.</font></li>
																																	<li><font color="#000000">A profit and loss account which can be abbreviated and does not need to disclose turnover.</font></li>
																																	<li><font color="#000000">A special auditor's report stating that the requirements for qualifying as medium-sized have been met. A copy of this statement must be included in the full accounts issued to shareholders. Director's report.</font></li>
																																</ul>
																															<p id="AccQ18h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ18');ShowHideControl('AccQ18i');ShowHideControl('AccQ18j');ShowHideControl('AccQ18k');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ19');" href="#_self1">
																															<b>What does SME stand for?
																															</b></A> </strong>
																															<p id="AccQ19" style="DISPLAY: none"><font color="#000000">
																															According to HMRC, an SME is a company with fewer than 250 employees, and either annual turnover not exceeding £50M or a balance sheet totaling £43M, and which is not part of a larger enterprise that would fail these tests.
																															</font>
																															</p>
																															<p id="AccQ19h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ19');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ20');" href="#_self1">
																															<b>I do not have my tax reference number: whom should I contact?
																															</b></A> </strong>
																															<p id="AccQ20" style="DISPLAY: none"><font color="#000000">Your company’s Tax Reference number (UTR) is present on form CT41G and form CT603; if you don’t have these forms please call 0207 667 2557.
																															</font>
																															</p>
																															<p id="AccQ20h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ20');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ21');" href="#_self1">
																															<b>If I fail to file on time, how will that affect my company?
																															</b></A> </strong>
																															<p id="AccQ21" style="DISPLAY: none"><font color="#000000">In case you are unable to file your tax returns on time, you are usually required pay heavy penalties.
																															</font>
																															</p>
																															<p id="AccQ21h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ21');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ22');" href="#_self1">
																															<b>What is the Government Gateway? 
																															</b></A> </strong>
																															<p id="AccQ22" style="DISPLAY: none"><font color="#000000">The UK government has created an electronic gateway to collect information from people. This has led to facilities such as electronic filing (E-filing) of various documents and forms that are periodically required to be submitted to HMRC and other government organisations.
																															</font>
																															</p>
																															<p id="AccQ22h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ22');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ23');" href="#_self1">
																															<b>Do I require a Gateway registration?
																															</b></A> </strong>
																															<p id="AccQ23" style="DISPLAY: none"><font color="#000000">The Gateway is an important feature in the strategy to provide a singular point of connectivity where all government departments are quickly available for communication and transaction with the people. This means that once you've registered for Gateway services, you no longer need to send forms and documents to HMRC manually, as all is done electronically, including the transfer of secure information and instant updates in your database maintained at HMRC.
																															</font>
																															</p>
																															<p id="AccQ23h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ23');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ24');ShowHideControl('AccQ24i');" href="#_self1">
																															<b>What is Gateway Activation PIN and how do I activate the PIN?
																															</b></A> </strong>
																															<p id="AccQ24" style="DISPLAY: none"><font color="#000000">
																															When a company registers itself with the Government Gateway for online filing, an Activation PIN is sent to the registered office address of the company within 7 days of registration. The PIN can be activated on the Government Gateway website. Accounts Centre customers can submit the PIN by following the steps given below:
																															</font>
																															</p>
																															<ul id="AccQ24i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">Login to www.accountscentre.com</font></li>
																																	<li><font color="#000000">On the Global View page, click on the Company Name.</font></li>
																																	<li><font color="#000000">Now click on the “Activate your Government Gateway PIN” blinking button.</font></li>
																																	<li><font color="#000000">Check the appropriate box.</font></li>
																																	<li><font color="#000000">Enter the Activation PIN already sent to you by Government Gateway.</font></li>
																																	<li><font color="#000000">Click Submit to submit the PIN.</font></li>
																																</ul>
																															<p id="AccQ24h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ24');ShowHideControl('AccQ24i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ25');ShowHideControl('AccQ25i');ShowHideControl('AccQ25j');" href="#_self1">
																															<b>How can Accounts Centre help me with Gateway registration?
																															</b></A> </strong>
																															<p id="AccQ25" style="DISPLAY: none"><font color="#000000">
																															Accounts Centre is one of the first accounting service providers to facilitate its clients by helping them quickly register with the Gateway for E-filing, in relation to Payroll matters and Company Tax Returns. If you are a registered member of Accounts Centre, you can simply place a request for Gateway registration, for the following:
																															</font>
																															</p>
																															<ul id="AccQ25i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">PAYE</font></li>
																																	<li><font color="#000000">Corporation Tax</font></li>
																																	</ul>
																															<p id="AccQ25j" style="DISPLAY: none"><font color="#000000">
																															You will have to place a separate request for each of the above services, which will take approximately 5-10 minutes of processing time.
																															</font>
																															</p>
																															<p id="AccQ25h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ25');ShowHideControl('AccQ25i');ShowHideControl('AccQ25j');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ26');" href="#_self1">
																															<b>I have other queries: Whom do I contact?
																															</b></A> </strong>
																															<p id="AccQ26" style="DISPLAY: none"><font color="#000000">
																															If you have any further queries regarding Accounts Centre and any of its services/products, please call (numbers given above) or send an email to <A class="url_text" href="mailto:support@accountscentre.com">
																															support@accountscentre.com</A>
																															</font>
																															</p>
																															<p id="AccQ26h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ26');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																														</ul>
																														<br>
																														<strong><font size=3>Collection Services (merchant processing) related :</font></strong>
																														<ul>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ27');" href="#_self1">
																															<b>What are Collection services (merchant processing services)?
																															</b></A> </strong>
																															<p id="AccQ27" style="DISPLAY: none"><font color="#000000">Accounts Centre offers its merchant processing services (Collection Services) to all its customers who wish to conduct online transactions, especially related to E-commerce. Collection Services may not only be used for accepting online credit / debit card payments, but can also be used for receiving payments made through other methods such as Bank Draft, Wire Transfer and Cheques. 
																															</font>
																															</p>
																															<p id="AccQ27h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ27');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ28');ShowHideControl('AccQ28i');" href="#_self1">
																															<b>What are the advantages of using Collection Service?
																															</b></A> </strong>
																															<p id="AccQ28" style="DISPLAY: none"><font color="#000000">Collection Services offers the following advantages over other online payment collection services:
																															</font>
																															</p>
																															<ul id="AccQ28i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">Efficient Setup.</font></li>
																																	<li><font color="#000000">Simplified and reduced fee structure.</font></li>
																																	<li><font color="#000000">Ease of Setup as there is no need to go through separate procedures for merchant account opening and payment gateway setup.</font></li>
																																	<li><font color="#000000">No need to contact 3rd party intermediaries.</font></li>
																																	<li><font color="#000000">For customers who require a UK bank account and are unable to do so on the basis of non-residency or other problems, Collection Services offers a viable alternative.</font></li>
																																</ul>
																															<p id="AccQ28h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ28');ShowHideControl('AccQ28i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ29');" href="#_self1">
																															<b>Are there any related costs other than the set up costs for Collection Services?
																															</b></A> </strong>
																															<p id="AccQ29" style="DISPLAY: none"><font color="#000000">
																															The Fee for merchant processing, Collection Service is £250.00 (one time setup fee). There are no annual charges for this service. For offshore customers the setup fee is £150.00.
																															<br>
																															The customers are going to be charged 4-5% per transaction, which can be reviewed and can vary depending upon the customer’s business activities. Additionally, 10% of transaction amount will be kept as the rolling reserve for 6 months, to take care of charge backs. There are no other penalties for charge backs. 
																															</font>
																															</p>
																															<p id="AccQ29h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ29');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ30');" href="#_self1">
																															<b>Are there any limits to transaction per month? 
																															</b></A> </strong>
																															<p id="AccQ30" style="DISPLAY: none"><font color="#000000">
																															Since Collection Services offers validation and clearing of online transactions, there is a limit of no more than 10 possible transactions per each 24 hours. 
																															</font>
																															</p>
																															<p id="AccQ30h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ30');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ31');" href="#_self1">
																															<b>How will I receive payments?
																															</b></A> </strong>
																															<p id="AccQ31" style="DISPLAY: none"><font color="#000000">
																															Initially, the payments will be sent to you after 30 days. If there are no significant charge backs for first 3 months, this 30 days period will be brought down to 2 weeks. 
																															<br><br>
																															You must nominate a regular current bank account, where your payment will be sent through bank transfer. Accounts Centre will not use cheques, drafts or any other methods to transfer payment. This is to make sure that the payment is sent out to the actual customer and no frauds occur.
																															</font>
																															</p>
																															<p id="AccQ31h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ31');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															</ul>
																														<br>
																														<strong><font size=3>CT600 related :</font></strong>
																														<ul>
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ32');" href="#_self1">
																															<b>What is Corporation Tax?
																															</b></A> </strong>
																															<p id="AccQ32" style="DISPLAY: none"><font color="#000000">Corporation tax is the tax on your company’s taxable income.
																															</font>
																															</p>
																															<p id="AccQ32h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ32');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ33');" href="#_self1">
																															<b>What is CT600?
																															</b></A> </strong>
																															<p id="AccQ33" style="DISPLAY: none"><font color="#000000">Ct600 is the company tax return form which has to submit along with the company accounts, for the period covered by the return and computations how values have been entered in the return form the figures on Accounts.
																															</font>
																															</p>
																															<p id="AccQ33h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ33');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ34');" href="#_self1">
																															<b>What accounts do I need to attach with CT600 form?
																															</b></A> </strong>
																															<p id="AccQ34" style="DISPLAY: none"><font color="#000000">A company’s statutory accounts, audited and declared by the Director(s), are to be attached with the CT600 form. In case the company is dormant, it has to attach Dormant Company Accounts with declaration by Director(s) of the company.
																															</font>
																															</p>
																															<p id="AccQ34h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ34');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ35');" href="#_self1">
																															<b>When do I have to file/send in my Ct600 form?  
																															</b></A> </strong>
																															<p id="AccQ35" style="DISPLAY: none"><font color="#000000">
																															A company can file its CT600 at any time after the end of its financial period but before 9 months after the end of company’s financial period and three months after the company receives a “NOTICE TO DELIVER A COMPANY TAX RETURN FORM CT600” from HM Revenue & Customs.
																															</font>
																															</p>
																															<p id="AccQ35h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ35');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ36');" href="#_self1">
																															<b>How do I know that my Tax Return has been received by HMRC?
																															</b></A> </strong>
																															<p id="AccQ36" style="DISPLAY: none"><font color="#000000">In case of e-filing, HMRC provides you acknowledgment at the end of the CT600 e-filing process, which you may wish to save to avoid any problem. In case you are submitting the tax return manually, you can get the acknowledgement by calling at your local HMRC.
																															</font>
																															</p>
																															<p id="AccQ36h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ36');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ37');" href="#_self1">
																															<b>My company is dormant; do I still need to file CT600?
																															</b></A> </strong>
																															<p id="AccQ37" style="DISPLAY: none"><font color="#000000">Yes, you are still required to file the Ct600 form, however it is filed empty.
																															</font>
																															</p>
																															<p id="AccQ37h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ37');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ38');" href="#_self1">
																															<b>I am not a UK resident: do I still need to file CT600?
																															</b></A> </strong>
																															<p id="AccQ38" style="DISPLAY: none"><font color="#000000">If your company is in UK, even if you live any where else in the world, you are still required to file CT600.
																															</font>
																															</p>
																															<p id="AccQ38h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ38');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															</ul>
																														<br>
																														<strong><font size=3>Annual Returns related :</font></strong>
																														<ul>
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ39');ShowHideControl('AccQ39i');ShowHideControl('AccQ39j');ShowHideControl('AccQ39k');" href="#_self1">
																															<b>What are Annual Returns?
																															</b></A> </strong>
																															<p id="AccQ39" style="DISPLAY: none"><font color="#000000">
																															An annual return contains certain company information accurate up to the made-up date. It is distinct from a company's annual accounts. An annual return must contain the following information: 
																															</font>
																															</p>
																															<ul id="AccQ39i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">The name of the company.</font></li>
																																	<li><font color="#000000">Its registered number.</font></li>
																																	<li><font color="#000000">The type of company it is, for example, private or public.</font></li>
																																	<li><font color="#000000">The registered office address of the company.</font></li>
																																	<li><font color="#000000">The address where certain company registers are kept if not at the registered office</font></li>
																																	<li><font color="#000000">The principal business activities of the company.</font></li>
																																	<li><font color="#000000">The name and address of the company secretary.</font></li>
																																	<li><font color="#000000">The name, usual residential address, date of birth, nationality and business occupation of all the company's directors.</font></li>
																																	<li><font color="#000000">The date to which the annual return is made-up (the made-up date).</font></li>
																																</ul>
																															<p id="AccQ39j" style="DISPLAY: none"><font color="#000000">
																															And if the company has share capital, the annual return must also contain:
																															</font>
																															</p>
																															<ul id="AccQ39k" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">The nominal value of total issued share capital.</font></li>
																																	<li><font color="#000000">The names and addresses of shareholders.</font></li>
																																	<li><font color="#000000">The number and type of shares held or transferred from other shareholders.</font></li>
																																</ul>
																															<p id="AccQ39h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ39');ShowHideControl('AccQ39i');ShowHideControl('AccQ39j');ShowHideControl('AccQ39k');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ40');ShowHideControl('AccQ40i');" href="#_self1">
																															<b>What is the made up date?
																															</b></A> </strong>
																															<p id="AccQ40" style="DISPLAY: none"><font color="#000000">
																															This is the date at which all the information in an annual return must be correct. The made-up date is usually the anniversary of: 
																															</font>
																															</p>
																															<ul id="AccQ40i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">The incorporation of the company.<br>or</font></li>
																																	<li><font color="#000000">The made-up date of the previous annual return registered at Companies House.</font></li>
																																</ul>
																															<p id="AccQ40h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ40');ShowHideControl('AccQ40i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ41');" href="#_self1">
																															<b>What information does Companies House require?
																															</b></A> </strong>
																															<p id="AccQ41" style="DISPLAY: none"><font color="#000000">
																															Companies House requires the following information from the Director(s) of a Limited Liability Company: the company management, activities, capital structure and accounts. The directors are personally liable to provide the above information to the Companies House on the appropriate occasions. 
																															</font>
																															</p>
																															<p id="AccQ41h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ41');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ42');ShowHideControl('AccQ42i');" href="#_self1">
																															<b>What kind of company accounts and records are required to be maintained?
																															</b></A> </strong>
																															<p id="AccQ42" style="DISPLAY: none"><font color="#000000">
																															All companies are required to maintain a proper record of incomes, expenditures, assets and liabilities of the business. A proper set of financial statements (profit and loss account, balance sheet, cash flow statements etc.) are to be submitted to the Companies House annually. 
																															<br><br>
																															Limited liability companies are required to file their annual financial statements and returns with the Companies House before the closing date. Any delays will give rise to penalties. The set of accounts include:
																															</font>
																															</p>
																															<ul id="AccQ42i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">A profit and loss account (income and expenditure account);</font></li>
																																	<li><font color="#000000">A balance sheet, signed by the director;</font></li>
																																	<li><font color="#000000">An auditors' report (this would apply to companies with turnover over £1m per annum);</font></li>
																																	<li><font color="#000000">A directors' report, signed by the company directors and secretary; </font></li>
																																	<li><font color="#000000">Notes to the accounts;</font></li>
																																	<li><font color="#000000">Group accounts (where appropriate);</font></li>
																																</ul>
																															<p id="AccQ42h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ42');ShowHideControl('AccQ42i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ43');" href="#_self1">
																															<b>When must the annual return be delivered to Companies House?
																															</b></A> </strong>
																															<p id="AccQ43" style="DISPLAY: none"><font color="#000000">
																															All annual returns must be delivered to Companies House within 28 days of the made-up date given on the form.
																															</font>
																															</p>
																															<p id="AccQ43h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ43');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ44');ShowHideControl('AccQ44i');" href="#_self1">
																															<b>What is the difference a Corporation Tax Return and Annual Returns?
																															</b></A> </strong>
																															<p id="AccQ44" style="DISPLAY: none"><font color="#000000">
																															Corporation Tax is the tax charged on the profits of the company for which Company has to file a corporation tax return (form Ct600), within nine months of the end of the company’s financial period. Corporation Tax Return Contains the details of the company’s liability to corporation tax or details losses available to carry forward to setoff against future profits.
																															<br><br>
																															Annual Returns are filed on the form 363, containing the following information of a company:
																															</font>
																															</p>
																															<ul id="AccQ44i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">The name of the company.</font></li>
																																	<li><font color="#000000">The company's registered number.</font></li
																																	><li><font color="#000000">The type of company - private or public.</font></li>
																																	<li><font color="#000000">The company's registered address.</font></li>
																																	<li><font color="#000000">The address where certain company registers are kept - if different from the registered address.</font></li>
																																	<li><font color="#000000">The principal business activities of the company.</font></li>
																																	<li><font color="#000000">The name and address of the company secretary.</font></li>
																																	<li><font color="#000000">The name, residential address, date of birth, nationality and business occupation of all the company's directors.</font></li>
																																	<li><font color="#000000">The company's made-up date along with the name, registration number, type, address a company must submit.</font></li>
																																	<li><font color="#000000">Share capital information.</font></li>
																																	
																																</ul>
																															<p id="AccQ44h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ44');ShowHideControl('AccQ44i');" href="#_self1">Hide</A> ] </span></strong>																																																																
																															</p>				
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ45');" href="#_self1">
																															<b>What is a dormant company?
																															</b></A> </strong>
																															<p id="AccQ45" style="DISPLAY: none"><font color="#000000">
																															A company that has made no significant financial transactions during a financial year is a dormant company. This means there are no entries in company's accounting records, except for the records of the amount paid for shares when the company is first formed.
																															</font>
																															</p>
																															<p id="AccQ45h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ45');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ46');" href="#_self1">
																															<b>My company is dormant. Do I still have to send accounts and a return?
																															</b></A> </strong>
																															<p id="AccQ46" style="DISPLAY: none"><font color="#000000">
																															Yes, dormant companies do need to submit accounts and returns to Companies House. However, since no active trading activity is carried out, these accounts are in an abbreviated form and do not carry too much detail.
																															</font>
																															</p>
																															<p id="AccQ46h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ46');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															</ul>
																														<br>
																														<strong><font size=3>Annual Accounts related :</font></strong>
																														<ul>
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ47');" href="#_self1">
																															<b>What is the period that the accounts should cover?
																															</b></A> </strong>
																															<p id="AccQ47" style="DISPLAY: none"><font color="#000000">
																															A company's first accounts’ record must begin from the day of incorporation. The first financial year must end on the 'accounting reference date' (ARD). Subsequent accounts start on the day following the year-end date of the previous accounts and end on the next 'accounting reference date'.
																															</font>
																															</p>
																															<p id="AccQ47h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ47');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ48');" href="#_self1">
																															<b>How is accounting reference date (ARD) set?
																															</b></A> </strong>
																															<p id="AccQ48" style="DISPLAY: none"><font color="#000000">
																															The accounting reference date is the date each year, to which accounts will be drawn up. The date depends on the date of incorporation as it is the last day of the month in which the first anniversary of incorporation falls. For example, if your company is incorporated on 2nd July this year, the accounting reference date will be 31st July, and its first financial year must end on 31st July next year.
																															</font>
																															</p>
																															<p id="AccQ48h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ48');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ49');" href="#_self1">
																															<b>Can the accounting reference date (ARD) be changed?
																															</b></A> </strong>
																															<p id="AccQ49" style="DISPLAY: none"><font color="#000000">
																															Yes. You may change it by sending in the Form 225 to the Companies House registrar. You must do this during the accounting period affected by the change or during the period allowed for delivering the associated accounts to the Companies House.
																															</font>
																															</p>
																															<p id="AccQ49h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ49');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ50');ShowHideControl('AccQ50i');" href="#_self1">
																															<b>How long do I have to deliver accounts?
																															</b></A> </strong>
																															<p id="AccQ50" style="DISPLAY: none"><font color="#000000">The first accounts of a private company must be delivered:
																															</font>
																															</p>
																															<ul id="AccQ50i" style="DISPLAY:none" class="main_text">																															
																																	<li><font color="#000000">Within 22 months of the incorporation date.<br>or</font></li>
																																	<li><font color="#000000">If the accounting reference period is more than 12 months, within 22 months of the date of incorporation or 3 from the end of accounting reference period, whichever is longer.</font></li>
																																</ul>
																															<p id="AccQ50h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ50');ShowHideControl('AccQ50i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ51');ShowHideControl('AccQ51i');" href="#_self1">
																															<b>What happens when the accounts are filed late?
																															</b></A> </strong>
																															<p id="AccQ51" style="DISPLAY: none"><font color="#000000">
																															A late filing of accounts is penalized depending on the delay and the company status. The currently applicable penalties are: 
																															</font>
																															</p>
																															
																													<table id="AccQ51i" style="DISPLAY: none" cellSpacing="0" cellPadding="0" width="100%">
																														<tr class="main_text">
																															<td vAlign="top" width="58%">
																																<p><strong>Length of delay </strong>
																																</p>
																															</td>
																															<td vAlign="top" width="42%">
																																<p><strong>Private Company </strong>
																																</p>
																															</td>
																														</tr>
																														<tr class="main_text">
																															<td vAlign="top">
																																<p>3 months or less
																																</p>
																															</td>
																															<td vAlign="top">
																																<p>£100
																																</p>
																															</td>
																														</tr>
																														<tr class="main_text">
																															<td vAlign="top">
																																<p>3 months one day to 6 months
																																</p>
																															</td>
																															<td vAlign="top">
																																<p>£250
																																</p>
																															</td>
																														</tr>
																														<tr class="main_text">
																															<td vAlign="top">
																																<p>6 months one day to 12 months
																																</p>
																															</td>
																															<td vAlign="top">
																																<p>£500
																																</p>
																															</td>
																														</tr>
																														<tr class="main_text">
																															<td vAlign="top">
																																<p>More than 12 months
																																</p>
																															</td>
																															<td vAlign="top">
																																<p>£1,000
																																</p>
																															</td>
																														</tr>
																													</table>
																															<p id="AccQ51h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ51');ShowHideControl('AccQ51i');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																															
																															<li class="url_text">
																															<strong><A class="url_text" onclick="ShowHide('AccQ52');" href="#_self1">
																															<b>Does Companies House notify when the accounts and returns are to be filed?
																															</b></A> </strong>
																															<p id="AccQ52" style="DISPLAY: none"><font color="#000000">
																															Yes, Companies House delivers several letters annually to companies and concerned officials. These letters include different notifications for submission of various documents and other company related information. Directors of a company are responsible to maintain this correspondence and they must be aware of the appropriate due dates for the different events.
																															<br><br>
																															Please make sure that Companies House has your correct registered office address. All the correspondence from Companies House, Inland Revenue and other government departments is received at this registered office address.
																															</font>
																															</p>
																															<p id="AccQ52h" style="DISPLAY: none" align="right"><strong>&nbsp;<span class="url_text">
																																[ <A class="url_text" onclick="ShowHide('AccQ52');" href="#_self1">Hide</A> ] </span></strong>
																															</p>
																															
																														
																												</td>
																											</tr>
																											<tr>
																												<td vAlign="top">&nbsp;</td>
																											</tr>
																										</table>
																									</td>
																									<td background="\images/crv_2linebg.jpg"><IMG height="16" src="\images/crv_2linebg.jpg" width="17"></td>
																								</tr>
																								<tr vAlign="top">
																									<td><IMG height="10" src="\images/crv_1bottom.jpg" width="16"></td>
																									<td background="\images/crv_bottomlinebg.jpg"><IMG height="10" src="\images/crv_bottomlinebg.jpg" width="15"></td>
																									<td><IMG height="10" src="\images/crv_bottom1.jpg" width="17"></td>
																								</tr>
																							</table>
																						</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																	</table>
																</td>
																<td width="21%">
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<tr vAlign="top" align="left">
																			<td colSpan="2">
																				<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																					<tr>
																						<td colSpan="2"><IMG height="5" src="\images/emptyimage.jpg" width="2"></td>
																					</tr>
																					<tr>
																						<td width="8%" background="\images/right_left.jpg" height="21">&nbsp;</td>
																						<td width="92%" background="\images/right_top.jpg">&nbsp;</td>
																					</tr>
																				</table>
																			</td>
																		</tr>
																		<tr vAlign="top">
																			<td width="2%">&nbsp;</td>
																			<td width="98%">
																				<table cellSpacing="5" cellPadding="0" width="100%" align="center" border="0">
																					<tr>
																						<td class="right_side_text" vAlign="top" align="center">
																							<p class="url_text2"><A class="url_text2" href="/Products/ExtremeAccounting.aspx">Extreme 
																									Accounting £500 </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="right_side_text" vAlign="top" align="center"><A href="/Products/ExtremeAccounting.aspx"><IMG height="61" src="\images/extreme_small_pic.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="middle" align="center">
																							<p><A class="url_text2" href="/Products/ExtremeAccounting.aspx">On a tight deadline? 
																									Prepare and file your accounts in
																									<br>
																									7 workings days! </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="right_side_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td class="style4" vAlign="top" align="center">
																							<p class="url_text2"><A class="url_text2" href="/Products/OutSourcedAccounts.aspx">Outsourced 
																									Accounts Department £300 </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="right_side_text" vAlign="middle" align="center"><A href="/Products/OutSourcedAccounts.aspx"><IMG height="61" src="\images/outsourced_small_pic.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td vAlign="top" align="center"><span class="url_text"><font class="url_text2" face="Arial" color="#ffffff" size="2"></font></span>
																							<p class="url_text2"><A class="url_text2" href="/Products/OutSourcedAccounts.aspx">Handles 
																									daily bookkeeping; Files VAT and tax returns; Deals with customer and supplier 
																									enquiries. </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="middle" align="center">
																							<p><A class="url_text2" href="/Products/DormantCompany.aspx">Dormant Company Accounts 
																									£75 </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td vAlign="middle" align="center"><A href="/Products/DormantCompany.aspx"><IMG height="61" src="\images/dormant_samll_pic.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="top" align="center"><a class="url_text2" href="http://www.o-c.com"></a>
																							<p><A class="url_text2" href="/Products/DormantCompany.aspx">Single-click E-filing to 
																									both, Companies House and Tax office</A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td vAlign="middle" align="center">
																							<p class="url_text2"><A class="url_text2" href="/Products/ManagedE-CommerceWebsitesBanner.aspx">Managed 
																									E-commerce Websites
																									<br>
																									£50 per month </A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="right_side_text" vAlign="middle" align="center"><A href="/Products/ManagedE-CommerceWebsitesBanner.aspx"><IMG height="61" src="\images/managed_e-commerce_small.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="top" align="center">
																							<p><A class="url_text2" href="/Products/ManagedE-CommerceWebsitesBanner.aspx">Pro-active 
																									E-commerce web site management Complete web site creation and support services</A>
																							</p>
																						</td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="top" align="center"><A class="url_text2" href="/Products/MerchantAccountOpening.aspx">Merchants 
																								Accounts</A></td>
																					</tr>
																					<tr>
																						<td class="url_text2" vAlign="top" align="center"><A href="/Products/MerchantAccountOpening.aspx"><IMG height="61" src="\images/merchant_account_smoll.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><span class="url_text2"><A class="url_text2" href="/Products/MerchantAccountOpening.aspx">Merchant 
																									processing solutions for both on- and off-shore companies</A></span></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><A href="/Products/Profile.aspx"><IMG height="61" src="\images/profile_small.jpg" width="66" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><span class="url_text2"><A class="url_text2" href="/Products/Profile.aspx">Profile</A></span></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><A href="/Products/FAQ.aspx"><IMG height="62" src="\images/formationfaq.jpg" width="71" border="0"></A></td>
																					</tr>
																					<tr>
																						<td class="url_text" vAlign="top" align="center"><A class="url_text2" href="/Products/FAQ.aspx">FAQ's</A></td>
																					</tr>
																				</table>
																				<div align="center"><IMG height="1" src="\images/greyline.jpg" width="102"></div>
																			</td>
																		</tr>
																		<!--******************-->
																		<tr vAlign="top">
																			<td>&nbsp;</td>
																			<td>&nbsp;</td>
																		</tr>
																	</table>
																	<p>&nbsp;</p>
																</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
											<map name="Map3">
												<area shape="RECT" coords="172,7,299,40" href="http://www.formationshouse.com/fr/index.htm">
												<area shape="RECT" coords="1,9,151,71" href="http://www.formationshouse.com/de/index.htm">
											</map>
											<!-- *******************--></TD>
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

			// Show or Hide the content
			function ShowHide( ref ) 
			{ 			  
				var structure  = document.getElementById(ref); 
				var hideStructure  = document.getElementById(ref+'h');
			  
				if (structure.style.display =='none') 
				{ 
					structure.style.display =''; 
					hideStructure.style.display ='';
				} 
				else 
				{ 
					structure.style.display ='none'; 
					hideStructure.style.display ='none';
				} 
			} 
			
			// Show or Hide  the content
			function ShowHideControl( ref ) 
			{ 			  
				var structure  = document.getElementById(ref); 				
			  
				if (structure.style.display =='none') 
				{ 
					structure.style.display =''; 
				} 
				else 
				{ 
					structure.style.display ='none'; 
				} 
			} 
		</script>
		</TD></TR></TBODY></TABLE>
	</body>
</HTML>
