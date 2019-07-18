var xmlhttp;
    function createXMLHttp(){
        // code for Mozilla, etc.
        if (window.XMLHttpRequest){
          xmlhttp=new XMLHttpRequest()
          }
        // code for IE
        else if (window.ActiveXObject){
          xmlhttp=new ActiveXObject("Microsoft.XMLHTTP")
          }
        return xmlhttp;  
    }
    function callAsync(url, sAction, req, ctrID, toolTipLen){
        xmlhttp = createXMLHttp();
        xmlhttp.open("POST", url, true);
        xmlhttp.onreadystatechange = responseFound;
        xmlhttp.setRequestHeader("Content-Type","text/xml;charset=utf-8")
        xmlhttp.setRequestHeader("SOAPAction",sAction)
        xmlhttp.send(req);
    }

    function responseFound() {
       if (xmlhttp.readyState != 4)  { 
            return; 
       }
       var res = xmlhttp.responseXML;
        if (navigator.appVersion.indexOf("MSIE")!=-1){
			var methodName = res.selectSingleNode("//MethodName").text; 
			    
			if (methodName == "IsDomainNameAvailable"){
           		checkDomainNameResponse(res);
           	}
           	if (methodName == "IsCompanyNameAvailable"){
           		checkCompanyNameResponse(res);
           	}
        }
    }

	var url  = 'https://accounts.infinibiz.com/Account/CommonServices.asmx'
    function checkDomainName(txtid, ddlid, toolTipLen)
    {
		alert("checkDomainName");
        var sAction = 'http://accounts.infinibiz.Web/CommonServices/IsDomainNameAvailable' ;
        if (navigator.appVersion.indexOf("MSIE")!=-1){
            var objddlid = document.getElementById(ddlid);
            var objtxtid = document.getElementById(txtid);
		    String.prototype.trim = function() {
			    return this.replace(/^\s+|\s+$/g,"");
		    }
		    objtxtid.value = objtxtid.value.trim();
		    if(objtxtid.value.indexOf('www.') != -1)
		        objtxtid.value.replace('www.', 'www');
    		    
            if(objtxtid.value.length!=0){
		        var dName = objtxtid.value +  objddlid.options[objddlid.selectedIndex].value
		        var req = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><IsDomainNameAvailable xmlns="http://accounts.infinibiz.Web/CommonServices"><ControlID>'+txtid+'</ControlID><DomainName>'+dName+'</DomainName><ToolTipLen>'+toolTipLen+'</ToolTipLen></IsDomainNameAvailable></soap:Body></soap:Envelope>';
                callAsync(url, sAction, req, txtid, toolTipLen);
            }
        }
    }
    
    function checkDomainNameResponse(res)
    {
		alert("checkDomainNameResponse");
		var result = res.selectSingleNode("//IsDomainNameAvailableResult/Response").text;
        var bresult;
        var controlID;
        var toolTipLen;
        var toolTip;    
        
        controlID = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        toolTipLen = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        bresult = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        
        toolTip = result;
        if (toolTip.length != 0){
            showhint(toolTip, controlID, toolTipLen, bresult);
        }
    }
    
    function checkCompanyName(txtid, toolTipLen)
    {
		var sAction = 'http://accounts.infinibiz.Web/CommonServices/IsCompanyNameAvailable'
		if (navigator.appVersion.indexOf("MSIE")!=-1){
            var objtxtid = document.getElementById(txtid);
            /*
		    String.prototype.trim = function() {
			    return this.replace(/^\s+|\s+$/g,"");
		    }
		    objtxtid.value = objtxtid.value.trim();
        	*/	    
            if(objtxtid.value.length!=0){
		        var cName = objtxtid.value
		        var req = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><IsCompanyNameAvailable xmlns="http://accounts.infinibiz.Web/CommonServices"><ControlID>'+txtid+'</ControlID><CompanyName>'+cName+'</CompanyName><ToolTipLen>'+toolTipLen+'</ToolTipLen></IsCompanyNameAvailable></soap:Body></soap:Envelope>';
                callAsync(url, sAction, req, txtid, toolTipLen);
            }
        }
    }
    
    function checkCompanyNameResponse(res)
    {
		var result = res.selectSingleNode("//IsCompanyNameAvailableResult/Response").text;
        var bresult;
        var controlID;
        var toolTipLen;
        var toolTip;       
        
        controlID = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        toolTipLen = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        bresult = result.substring(0, result.indexOf('>'));
        result = result.substring(result.indexOf('>') +1, result.length );
        
        toolTip = result;
        if (toolTip.length != 0){
            showhint(toolTip, controlID, toolTipLen, bresult);
        }
    }