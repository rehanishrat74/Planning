/* Changed by : Win-Saira
   Date: 1 sept 208 */

var t;
var x = 6;
var y = 1;
var xmlHttp; 
 
  
var requestURL;
if (document.domain == 'enterprise.infinimation.com')
{
 requestURL = 'http://enterprise.infinimation.com/InfiniPlan/Services/Plan/WebTracker.aspx?str=' 
}
else 
{
 requestURL = 'https://accounts.infinibiz.com/InfiniPlan/Services/Plan/WebTracker.aspx?str=' 
}

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
function GetXmlHttpObject(handler)
{
    var objXmlHttp = null;    
    if (is_ie)
    { 
		var strObjName = (is_ie5) ? 'Microsoft.XMLHTTP' : 'Msxml2.XMLHTTP'; 
		try
		{ 
			objXmlHttp = new ActiveXObject(strObjName); 
			objXmlHttp.onreadystatechange = handler; 
		} 
		catch(e)
		{ 
			alert('IE detected, but object could not be created. Verify that active scripting and activeX controls are enabled'); 
			return; 
		} 
	} 
	else if (is_opera)
	{ 
		alert('Opera detected. The page may not behave as expected.'); 
		return; 
	} 
    else
    { 
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
	clearTimeout(t);
	//debugger;
	var url = requestURL + 'Refresh';
	xmlHttp = GetXmlHttpObject(stateChangeHandler);
	xmlHttp_Get(xmlHttp, url); 
} 
// Verify the response and display
function stateChangeHandler()
{ 
	if (xmlHttp.readyState == 4 )
	{ 
	 
		var str = xmlHttp.responseText;
		if(str == '')
		{
			document.getElementById("onlineVisiter").innerHTML = "web tracker online "
			document.getElementById("userInfo").innerHTML = ""; 
			document.getElementById("urlHistory").innerHTML = "";
	}
		else
		{
			//debugger;
			document.getElementById("onlineVisiter").innerHTML = str;
			startTimer();
		}
	}
}

//--------------------------------------------------------	
//End Display Visiter     
// Display Upated DATA  
function startTimer()
{
	//debugger;
	window.status = "Infinishop Web Tracker";
	t = setTimeout("show_data()", 5000);
	}
// display users Current Visisted Info.
//----------------------------------------------------------------------- 
function getDetails(detailID)
{
	//debugger;
	var url = requestURL + 'UserDetail_' + detailID; 
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
}
	 
} 
//--------------------------------------------------------------------------
// End Current Visisted Info 
// display users Previous Visisted Info. 
//-----------------------------------------------------------------------------------
function getDetails_Product(detailID)
{
 //debugger;
	var url = requestURL + 'UserLog_' + detailID; 
	xmlHttp = GetXmlHttpObject(stateChangeHandlerGetDetail_Product); 
	xmlHttp_Get(xmlHttp, url);
}			
function stateChangeHandlerGetDetail_Product()
{ 
	if(xmlHttp.readyState == 4 )
	{ 
		 		var str = xmlHttp.responseText
		   		 document.getElementById('urlHistory').innerHTML =  str  
		    	 }
	  } 
 function getDetails_Activity(detailID)
{
 //debugger;
	var url = requestURL + 'Session_' + detailID; 
	xmlHttp = GetXmlHttpObject(stateChangeHandlerGetDetail_Activity); 
	xmlHttp_Get(xmlHttp, url);
}			
function stateChangeHandlerGetDetail_Activity()
{ 
	if(xmlHttp.readyState == 4 )
	{ 
		 		var str = xmlHttp.responseText
		   		 document.getElementById('urlHistory').innerHTML =  str  
		    	 }
	  } 
//--------------------------------------------------------------------------
// End Privious  Visisted Info 
// Initilize program and display.. 
//-------------------------------------------------------
function Init()
{
	//debugger;
	document.getElementById('onlineVisiter').innerHTML="<img src=/Images/Infiniplan/loader.gif />" + " &nbsp Loading..."
	startTimer();
	}
//-------------------------------------------------------
// End Initilization 

function sendQuery(operatorJid, customerJid){
var var1 = "?customerjid="+customerJid;
var var2 = "&operatorjid="+operatorJid;
 var Qs;
if (document.domain == 'enterprise.infinimation.com')
{
 Qs = "http://enterprise.infinimation.com/InfiniPlan/Services/Plan/WebTracker.aspx"+var1+var2;
 }
 else 
 {
   Qs = "http://accounts.infinibiz.com/InfiniPlan/Services/Plan/WebTracker.aspx"+var1+var2;
 }
window.location.href = Qs;
}
