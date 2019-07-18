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
					else if(p==2) window.navigate(_HOSTNAME + "/Express/?_CustomerId=" + document.all("CusId"));///services/bookkeeping.aspx");
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
					if(p==0) window.navigate("/infodesk/default.aspx");
					else if(p==1) window.navigate("/products/profile.aspx");
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
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(7);' >&nbsp;|&nbsp;Global View &nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand'  >&nbsp;|&nbsp;Available&nbsp;Services&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif", "0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoAvailableService(\"/Gateway/Registration.aspx\")'>Activate Government Gateway PIN</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					
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
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(1);'>Annual Accounts                                  </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "Express":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(2);'>Book&nbsp;keeping</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "CTReturn":								
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(3);'>Corporation&nbsp;Tax</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
								break;
							case "AccountManagement":
								appendSTMI("false","<a style='cursor:hand' onclick='GotoServices(4);'>Collection Service                               </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
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
					appendSTMI("false","<a style='cursor:hand'  >&nbsp;|&nbsp;Infinibiz&nbsp;Profile&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");		
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(0);' >Menu                                 </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");		
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(3);' >Profile                                 </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");		
					//***************(MNS)******************
					if	(currentuser=='' ) {
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(2);' >Registration</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(4);' >Sign In                             </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					}
					else {
					appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(5);' >Sign&nbsp;Out</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					//appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(6);' >Update Services</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					//appendSTMI("false","<a style='cursor:hand' onclick='GotoMembers(7);' >Global View</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled"); 
					}
					//**************************************
					appendSTMI("false","Menu&nbsp;Item&nbsp;1","left","middle","","","-1","-1","0","sepline","#aca899","#c0c0c0","blank.gif","1","-1","-1","","","-1","-1","0","","","_self","Arial","9pt","#0000ff","normal","normal","none","Arial","9pt","#000099","normal","normal","none","1","solid","#c0c0c0","#c0c0c0","#ffffff","#000000","#c0c0c0","#c0c0c0","#000000","#ffffff","","","","tiled","tiled");
					endSTMB();
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(2);' >&nbsp;|&nbsp;FAQs&nbsp;|</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#3f75ac","","1","-1","-1","blank.gif","blank.gif","0","0","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#ffffff","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					beginSTMB("auto","0","0","vertically","arrow_r.gif","0","0","2","3","#3f75ac","","tiled","#aca899","0","solid","0","Fade","23","6","0","0","0","0","0","3","#999999","false","#aca899","#aca899","#aca899","complex");	
					/*appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(1);' >About Us                            </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(2);' >FAQs                            </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(3);' >Newsletter                                  </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(4);' >New Services                              </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='GotoInfoDesk(5);' >Tax&nbsp;Updates</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenMessageBoard();' >Message Archive                             </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","Online&nbsp;Assistance","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenEmailPopup();' >Send Email                                </a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");
					appendSTMI("false","<a style='cursor:hand' onclick='OpenMessagePopup();' >Talk&nbsp;with&nbsp;your&nbsp;Accountant</a>","left","middle","","","-1","-1","0","normal","#3f75ac","#ffffff","","1","-1","-1","blank.gif","blank.gif","6","-1","0","","","_self","Verdana","8pt","#ffffff","normal","normal","none","Verdana","8pt","#3f75ac","normal","normal","none","0","none","#fffff7","#fffff7","#000000","#000000","#fffff7","#fffff7","#000000","#000000","","","","tiled","tiled");*/
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