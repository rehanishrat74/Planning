var horizontal_offset="9px" 
var vertical_offset="0" 
var ie=document.all
var ns6=document.getElementById&&!document.all

function getposOffset(what, offsettype){
    var totaloffset=(offsettype=="left")? what.offsetLeft : what.offsetTop;
    var parentEl=what.offsetParent;
    while (parentEl!=null){
        totaloffset=(offsettype=="left")? totaloffset+parentEl.offsetLeft : totaloffset+parentEl.offsetTop;
        parentEl=parentEl.offsetParent;
    }
    return totaloffset;
}

function iecompattest(){
    return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
}

function clearbrowseredge(obj, whichedge){
    var edgeoffset=(whichedge=="rightedge")? parseInt(horizontal_offset)*-1 : parseInt(vertical_offset)*-1
    if (whichedge=="rightedge"){
        var windowedge=ie && !window.opera? iecompattest().scrollLeft+iecompattest().clientWidth-30 : window.pageXOffset+window.innerWidth-40
        dropmenuobj.contentmeasure=dropmenuobj.offsetWidth
        if (windowedge-dropmenuobj.x < dropmenuobj.contentmeasure)
            edgeoffset=dropmenuobj.contentmeasure+obj.offsetWidth+parseInt(horizontal_offset)
    }
    else{
        var windowedge=ie && !window.opera? iecompattest().scrollTop+iecompattest().clientHeight-15 : window.pageYOffset+window.innerHeight-18
        dropmenuobj.contentmeasure=dropmenuobj.offsetHeight
        if (windowedge-dropmenuobj.y < dropmenuobj.contentmeasure)
            edgeoffset=dropmenuobj.contentmeasure-obj.offsetHeight
    }
    return edgeoffset
}

function showhint(menucontents, controlID, tipwidth, success){
    if ((ie||ns6) && document.getElementById("hintbox")){
        var obj = document.getElementById(controlID);
        dropmenuobj=document.getElementById("hintbox")
   
		var fname;
		if(success==1)
   			fname= "/images/yes.png";
   		else
   			fname= "/images/no.png";
   			
        dropmenuobj.innerHTML="<img src='"+fname+"' height='16'/>&nbsp;"+menucontents
        dropmenuobj.style.left.align='top';
        dropmenuobj.style.left=dropmenuobj.style.top=-500
        if (tipwidth!=""){
            dropmenuobj.widthobj=dropmenuobj.style
            dropmenuobj.widthobj.width=tipwidth
        }

		dropmenuobj.style.left = getposOffset(obj, "left");
		dropmenuobj.style.top = getposOffset(obj, "top") +25  ;
		
		
		dropmenuobj.style.visibility="visible";
        
        /*
        dropmenuobj.x=getposOffset(obj, "left")
        dropmenuobj.y=getposOffset(obj, "top")
        dropmenuobj.style.left=dropmenuobj.x-clearbrowseredge(obj, "rightedge")+obj.offsetWidth+"px"
        dropmenuobj.style.top=dropmenuobj.y-clearbrowseredge(obj, "bottomedge")+"px"
        dropmenuobj.style.visibility="visible"
        */
        setTimeout("hidetip()",5000); 
        //obj.onmouseout=hidetip
    }
}

function hidetip(e){
	dropmenuobj.style.visibility="hidden"
	dropmenuobj.style.left="-500px"
}

function createhintbox(){
	//<div id="hintbox" />
	/*
	var divblock=document.createElement("div")
	divblock.setAttribute("id", "hintbox")
	document.body.appendChild(divblock)
	*/
}

if (window.addEventListener)
window.addEventListener("load", createhintbox, false)
else if (window.attachEvent)
window.attachEvent("onload", createhintbox)
else if (document.getElementById)
window.onload=createhintbox