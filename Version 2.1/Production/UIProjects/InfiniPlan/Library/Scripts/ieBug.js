// Removes IE7 SWF Gray Box 

window.onload = function(){
	if (document.getElementsByTagName) {
		var objs = document.getElementsByTagName("object");
		for (i=0; i<objs.length; i++) {
			objs[i].outerHTML = objs[i].outerHTML;
		}
	}
}

window.onunload = function() {
	if (document.getElementsByTagName) {
	var objs = document.getElementsByTagName("object");
		for (i=0; i<objs.length; i++) {
			objs[i].outerHTML = "";
		}
	}
}