				var _HOSTNAME = "https://accounts.infinibiz.com"																
				function changeTopMenuClass(o){
					if(o.className=="")	o.className="Topmenutext"; else o.className="";
					}
				/* 
				function Gotogateway(p){
					if(p==0) window.navigate("/gateway/default.aspx");
					else if(p==1) window.navigate(_HOSTNAME + "/gateway/CTReturn.aspx");
					else if(p==2) window.navigate(_HOSTNAME + "/gateway/individual.aspx");
					else if(p==3) window.navigate(_HOSTNAME + "/gateway/payroll.aspx");
				}
				*/
				function Gotohome(){window.navigate("/default.aspx");}	
				function GotoServices(p){
					if(p==0) window.navigate("/services/default.aspx");
					else if(p==1) window.navigate(_HOSTNAME + "/Ctreturn/Forms/introduction.aspx");///services/annual.aspx");
					else if(p==2) window.navigate(_HOSTNAME + "/Express/");///services/bookkeeping.aspx");
					else if(p==3) window.navigate(_HOSTNAME + "/Ctreturn/Forms/");///services/corporationtax.aspx");
					else if(p==4) window.navigate(_HOSTNAME + "/CAM/Service/");///services/customer.aspx");
					else if(p==5) window.navigate(_HOSTNAME + "/Payroll/");///services/payroll.aspx");
					else if(p==6) window.navigate(_HOSTNAME + "/Ctreturn/Forms/DCAccounts.aspx");///services/Dormant.aspx");
					else if(p==7) window.navigate(_HOSTNAME + "/accountspro/default.aspx");///services/accountsproweb.aspx");
						
				}
				function GotoMembers(p){
					if(p==0) window.navigate(_HOSTNAME + "/members/default.aspx");
					else if(p==1) window.navigate("/members/default1.aspx");
					else if(p==2) window.navigate(_HOSTNAME + "/account/NewCustomer.aspx");
					else if(p==3) window.navigate(_HOSTNAME + "/members/profile.aspx");	
					else if(p==4) window.navigate(_HOSTNAME + "/account/signin.aspx");
					else if(p==5) window.navigate("/account/signout.aspx");
					else if(p==6) window.navigate(_HOSTNAME + "/members/ServiceRegistration.aspx");
					else if(p==7) window.navigate(_HOSTNAME + "/globalview/GlobalView.aspx");
					
				}
				
				function GotoAvailableService(url){
					window.navigate(_HOSTNAME + url);
				}
				function GotoInfiniShop(url){
				window.navigate(url);
				}
				function GotoInfoDesk(p){
					if(p==0) window.navigate("/products/profile.aspx");
					else if(p==1) window.navigate("/infodesk/aboutus.aspx");
					else if(p==2) window.navigate("/members/faq.aspx");
					else if(p==3) window.navigate(_HOSTNAME + "/infodesk/newsletters.aspx");
					else if(p==4) window.navigate(_HOSTNAME + "/infodesk/newservices.aspx");
					else if(p==5) window.navigate(_HOSTNAME + "/infodesk/taxupdates.aspx");
				}
						
				function OpenMessageBoard(){window.navigate(_HOSTNAME + "/message/inbox.aspx");}
				//function Gotogateway(){window.navigate("gateway.aspx");}
					
					beginSTM("uueoehr","static","0","0","none","false","true","310","0","0","0","","blank.gif");
					beginSTMB("auto","0","0","horizontally","blank.gif","0","0","0","4","#3f75ac","","tiled","#3f75ac","0","none","0","Normal","50","0","0","0","0","0","0","0","#000000","false","#3f75ac","#3f75ac","#3f75ac","none");
					//appendSTMI("false","<a style='cursor:hand' onclick='Gotohome();' >&nbsp;|&nbsp;Home&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#3f75ac","#3f75ac","#3f75ac","#3f75ac","#3f75ac","#3f75ac","#3f75ac","#3f75ac","","","","tiled","tiled");
					//appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(5);' >&nbsp;|&nbsp;My Account&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(7);'  >&nbsp;| &#1043;&#1083;&#1086;&#1073;&#1072;&#1083;&#1100;&#1085;&#1099;&#1081; &#1055;&#1088;&#1086;&#1089;&#1084;&#1086;&#1090;&#1088; &nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' >&nbsp;|&nbsp;&#1044;&#1086;&#1089;&#1090;&#1091;&#1087;&#1085;&#1099;&#1077; &#1059;&#1089;&#1083;&#1091;&#1075;&#1080;&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif", "0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoAvailableService(\"/Gateway/Registration.aspx\")'>&#1040;&#1082;&#1090;&#1080;&#1074;&#1080;&#1079;&#1072;&#1094;&#1080;&#1103; &#1043;&#1086;&#1089;&#1091;&#1076;&#1072;&#1088;&#1089;&#1090;&#1074;&#1077;&#1085;&#1085;&#1086;&#1075;&#1086; &#1043;&#1077;&#1090;&#1074;&#1101;&#1081; PIN</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					
					var index 
					for(index=0;index<availableServices.length;index++)
					{
						if(availableServices[index]!='')
							//appendSTMI("false","<a style='cursor:hand' onclick='GotoAvailableService(\""+availableServices[index]+"\")'>"+availableServicesName[index]+"</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");					
							if (ProductCode[index]!=104)// Updated by Muhammad Ubaid for InfiniShop
							{
							appendSTMI("false","<a style='cursor:hand' onclick='GotoAvailableService(\""+availableServices[index]+"\")'>"+availableServicesName[index]+"</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
							}
							else
							{
							appendSTMI("false","<a style='cursor:hand' onclick='GotoInfiniShop(\""+availableServices[index]+"\")'>"+availableServicesName[index]+"</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
							}			
						else
							appendSTMI("false","<a style='cursor:hand' onclick='GotoAvailableService(\"/globalView/globalview.aspx\")'>"+availableServicesName[index]+"</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
						/*switch(availableServices[index])
						{
							case "SAccounts":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(1);'>&#1043;&#1086;&#1076;&#1086;&#1074;&#1086;&#1081; &#1054;&#1090;&#1095;&#1077;&#1090;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "Express":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(2);'>Book&nbsp;keeping</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "CTReturn":								
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(3);'>Corporation&nbsp;Tax</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "AccountManagement":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(4);'>&#1059;&#1089;&#1083;&#1091;&#1075;&#1080; &#1050;&#1086;&#1083;&#1083;&#1077;&#1082;&#1094;&#1080;&#1086;&#1085;&#1080;&#1088;&#1086;&#1074;&#1072;&#1085;&#1080;&#1103;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "Payroll":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(5);'>Payroll                             </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0", "","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "DCAccounts":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(6);'>Dormant Company Account      </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0", "","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "AccountsProWeb":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(7);'>Accounts Pro (web)                                  </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0", "","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
						}*/
					} // end of for loop
					appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");
					endSTMB();
					/* Gate way removed 
					appendSTMI("false","<a style='cursor:hand' onclick='Gotogateway(0);' >&nbsp;|&nbsp;Gateway&nbsp;Registration&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");
					appendSTMI("false","<a style='cursor:hand' onclick='Gotogateway(1);'>Corporation Tax                           </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='Gotogateway(2);'>Individual</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='Gotogateway(3);'>PAYE&nbsp;and&nbsp;NIC</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");
					endSTMB();
					*/
					/* Infodesk move to Consult menu
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(0);' >&nbsp;|&nbsp;Info&nbsp;Desk&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");		
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(1);' >About Us                            </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(2);' >FAQs                            </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(3);' >Newsletter                                  </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(4);' >New Services                              </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(5);' >Tax&nbsp;Updates</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					*/
				//***************(MNS)******************
					//appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");
					//endSTMB();
					appendSTMI("false","<a style='cursor:hand' >&nbsp;|&nbsp;&#1055;&#1088;&#1086;&#1092;&#1072;&#1081;&#1083; Accounts Center&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");		
				    appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(0);' >&#1052;&#1077;&#1085;&#1102; Accounts Center</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");		
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(3);' >&#1055;&#1088;&#1086;&#1092;&#1072;&#1081;&#1083;                                 </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");		
					//***************(MNS)******************
					if	(currentuser=='' ) {
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(2);' >&#1056;&#1077;&#1075;&#1080;&#1089;&#1090;&#1088;&#1072;&#1094;&#1080;&#1103;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(4);' >&#1042;&#1093;&#1086;&#1076; &#1089; &#1057;&#1080;&#1089;&#1090;&#1077;&#1084;&#1091;                             </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					}
					else {
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(5);' >&#1042;&#1099;&#1093;&#1086;&#1076; &#1080;&#1079; &#1057;&#1080;&#1089;&#1090;&#1077;&#1084;&#1099;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					/*appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(6);' >&#1052;&#1086;&#1076;&#1077;&#1088;&#1085;&#1080;&#1079;&#1080;&#1088;&#1086;&#1074;&#1072;&#1085;&#1085;&#1099;&#1077; &#1059;&#1089;&#1083;&#1091;&#1075;&#1080;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(7);' >&#1043;&#1083;&#1086;&#1073;&#1072;&#1083;&#1100;&#1085;&#1099;&#1081; &#1055;&#1088;&#1086;&#1089;&#1084;&#1086;&#1090;&#1088;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); */
					}
					//**************************************
					appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");
					endSTMB();
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(2);'>&nbsp;|&#1063;&#1072;&#1089;&#1090;&#1086; &#1047;&#1072;&#1076;&#1072;&#1074;&#1072;&#1077;&#1084;&#1099;&#1077; &#1042;&#1086;&#1087;&#1088;&#1086;&#1089;&#1099;&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");	
					/*appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(1);' >&#1054; &#1053;&#1072;&#1089;                           </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(2);' >&#1063;&#1072;&#1089;&#1090;&#1086; &#1047;&#1072;&#1076;&#1072;&#1074;&#1072;&#1077;&#1084;&#1099;&#1077; &#1042;&#1086;&#1087;&#1088;&#1086;&#1089;&#1099;                          </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(3);' >&#1048;&#1085;&#1092;&#1086;&#1088;&#1084;&#1072;&#1094;&#1080;&#1086;&#1085;&#1085;&#1099;&#1081; &#1041;&#1080;&#1083;&#1102;&#1090;&#1077;&#1085;&#1100;                                  </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(4);' >&#1053;&#1086;&#1074;&#1099;&#1077; &#1059;&#1089;&#1083;&#1091;&#1075;&#1080;                            </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(5);' >&#1052;&#1086;&#1076;&#1077;&#1088;&#1085;&#1080;&#1079;&#1072;&#1094;&#1080;&#1103; &#1053;&#1072;&#1083;&#1086;&#1075;&#1086;&#1074;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenMessageBoard();' >&#1040;&#1088;&#1093;&#1080;&#1074;&#1085;&#1086;&#1077; &#1057;&#1086;&#1086;&#1073;&#1097;&#1077;&#1085;&#1080;&#1077;                           </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","&#1055;&#1086;&#1076;&#1076;&#1077;&#1088;&#1078;&#1082;&#1072; &#1074; &#1054;&#1085;&#1083;&#1072;&#1081;&#1085;","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenEmailPopup();' >&#1054;&#1090;&#1087;&#1088;&#1072;&#1074;&#1080;&#1090;&#1100; &#1069;-&#1087;&#1086;&#1095;&#1090;&#1091;                                </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenMessagePopup();' >&#1055;&#1086;&#1075;&#1086;&#1074;&#1086;&#1088;&#1080;&#1090;&#1100; &#1089; &#1074;&#1072;&#1096;&#1080;&#1084; &#1041;&#1091;&#1093;&#1075;&#1072;&#1083;&#1090;&#1077;&#1088;&#1086;&#1084;</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");*/
					appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");	
					endSTMB();
					endSTMB();
					endSTM();

	//alert(usertitle.innerHTML);
		function OpenMessagePopup(){
			if	(currentuser=="" ) window.navigate(_HOSTNAME + "/account/signin.aspx");
			else window.open(_HOSTNAME + "/message/messagepopup.aspx","messagepopup", "height=305,width=610,toolbar=no, menubar=no, location=no,status=0");	
		}
		function OpenEmailPopup(){	
			//if	(currentuser=="" ) window.navigate("/account/signin.aspx");
			//else 
			window.open("/message/emailpopup.aspx","emailpopup", "height=317,width=567,toolbar=no, menubar=no, location=no,status=0");	
		}
		function OpenChatPopup(){	
			//window.open("/message/userchatpopup.html","chatpopup", "height=400,width=500,toolbar=no, menubar=no, location=no,status=0");	
			window.open("/message/emailpopup.aspx","emailpopup", "height=317,width=567,toolbar=no, menubar=no, location=no,status=0");	
		}		
		function OpennewWindow(U,N){
			window.open(U,N);	
		}
		function Initialize(){
			if (currentuser!="") usertitle.innerHTML="<font color=white size=2><b>" + currentuser + "</b></font>";
		}
		function OpenDownloadWindow(D){	
			window.open("/members/download.aspx?DWD="+D ,"DownloadWindow", "height=100,width=400,toolbar=no, menubar=no, location=no,status=0");	
		}