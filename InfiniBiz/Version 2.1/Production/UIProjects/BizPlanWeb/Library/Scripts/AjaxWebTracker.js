var x = 6
var y = 1
var xmlHttp; 
 var requestURL = 'https://accounts.infinibiz.com/InfiniPlan/Services/Plan/WebTracker.aspx?str=' 
//var requestURL = 'http://enterprise.infinimation.com/InfiniPlan/Services/Plan/WebTracker.aspx?str=' 

var is_ie = (navigator.userAgent.indexOf('MSIE') >= 0) ? 1 : 0; 
var is_ie5 = (navigator.appVersion.indexOf("MSIE 5.5")!=-1) ? 1 : 0; 
var is_opera = ((navigator.userAgent.indexOf("Opera6")!=-1)||(navigator.userAgent.indexOf("Opera/6")!=-1)) ? 1 : 0; 
//netscape, safari, mozilla behave the same??? 
var is_netscape = (navigator.userAgent.indexOf('Netscape') >= 0) ? 1 : 0; 
// Display XMLHTTP Response
function xmlHttp_Get(xmlhttp, url){
	xmlhttp.open('GET', url, true); 
	xmlhttp.send(null); 
} 
// Checks Browser Availablity 
function GetXmlHttpObject(handler){
    var objXmlHttp = null;    
    if (is_ie){ 
	var strObjName = (is_ie5) ? 'Microsoft.XMLHTTP' : 'Msxml2.XMLHTTP'; 
	try{ 
	objXmlHttp = new ActiveXObject(strObjName); 
	objXmlHttp.onreadystatechange = handler; 
	} 
	catch(e){ 
	alert('IE detected, but object could not be created. Verify that active scripting and activeX controls are enabled'); 
	return; 
	} 
} 
	else if (is_opera){ 
	alert('Opera detected. The page may not behave as expected.'); 
	return; 
	} 
    else{ 
	objXmlHttp = new XMLHttpRequest(); 
	objXmlHttp.onload = handler; 
	objXmlHttp.onerror = handler; 
	} 
    return objXmlHttp; 
	} 

// Display the Visiter 
//--------------------------------------------
function show_data()
{	
	var url = requestURL + 'Refresh';
	xmlHttp = GetXmlHttpObject(stateChangeHandler);
	xmlHttp_Get(xmlHttp, url); 
	}
// Verify the response and display
function stateChangeHandler(){ 
	if (xmlHttp.readyState == 4 ){ 
	var str = xmlHttp.responseText;
	if(str == ''){
	document.getElementById("onlineVisiter").innerHTML = "No One is Online..."  ; 
	document.getElementById("userInfo").innerHTML = ""   ; 
	document.getElementById("urlHistory").innerHTML = "" ;
	
//	document.getElementById("uHeader").innerHTML = "" ; 
	}
	else{
	document.getElementById("onlineVisiter").innerHTML = str ;
	
	}
}
}	 
//--------------------------------------------------------	
//End Display Visiter     
// Display Upated DATA  
function startTimer()
{
	x = x-y
	window.status = "Infinishop Web Tracker"
	setTimeout("startTimer()", 600)
	if(x==0)
	{
		
		show_data();
		x=6;
		}
}
// display users Current Visisted Info.
//----------------------------------------------------------------------- 
function getDetails(detailD)
{
	var url = requestURL + 'UpDetail_' + detailD ; 
	xmlHttp = GetXmlHttpObject(stateChangeHandlerGetDetail);
	xmlHttp_Get(xmlHttp, url);
	}
function stateChangeHandlerGetDetail()
{ 
	if(xmlHttp.readyState == 4 )
	{ 
		var str = xmlHttp.responseText
		document.getElementById('userInfo').innerHTML = str;
		document.getElementById('urlHistory').innerHTML = "";
		document.getElementById('urlHistory').style.display = "none";
		
	//	document.getElementById('uHeader').style.display = "none"; 
		}//else {
		//	document.getElementById('userInfo').innerHTML="<img src=/Images/loader.gif /> <span class='text_style2'>Loading....</span>";
		//}
} 
//--------------------------------------------------------------------------
// End Current Visisted Info 
// display users Previous Visisted Info. 
//-----------------------------------------------------------------------------------
function getDetails2(detailD)
{
	var url = requestURL + 'DownDetail_' + detailD ; 
	xmlHttp = GetXmlHttpObject(stateChangeHandlerGetDetail2); 
	xmlHttp_Get(xmlHttp, url);
	}			
function stateChangeHandlerGetDetail2()
{ 
	if(xmlHttp.readyState == 4 )
	{ 
	document.getElementById('urlHistory').style.display="block"
	document.getElementById('urlHistory').innerHTML=""
	var str = xmlHttp.responseText
	document.getElementById('urlHistory').innerHTML ="<table width='100%'height='0' cellSpacing='0' bordercolor='f3f3f3' cellPadding='0'  border='1'  >" + str + "</table>"; 
	document.getElementById('uHeader').style.display = "block"; 
	}///else{
	//document.getElementById('urlHistory').innerHTML="<img src=/Images/loader.gif /> <span class='text_style2'>Loading....</span>";
	//}
	
} 
//--------------------------------------------------------------------------
// End Privious  Visisted Info 
// Initilize program and display.. 
//-------------------------------------------------------
function Init()
{
	document.getElementById('onlineVisiter').innerHTML="<img src=/Images/Infiniplan/loader.gif />" + " &nbsp Loading..."
	startTimer();
	}
//-------------------------------------------------------
// End Initilization 

function sendQuery(operatorJid, customerJid){
var var1 = "?customerjid="+customerJid;
var var2 = "&operatorjid="+operatorJid;
 var Qs = "http://accounts.infinibiz.com/InfiniPlan/Services/Plan/WebTracker.aspx"+var1+var2;
//var Qs = "http://enterprise.infinimation.com/InfiniPlan/Services/Plan/WebTracker.aspx"+var1+var2;

window.location.href = Qs;

}
