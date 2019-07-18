function FAQ_doToggleDL(x){
	var zDD=document.getElementById('FAQ_DL').getElementsByTagName('dd');
	var zDT=document.getElementById('FAQ_DL').getElementsByTagName('dt');	
		zDD[x].className=(zDD[x].className=='hideDD')?'showDD':'hideDD';
		zDT[x].className=(zDT[x].className=='DTplus')?'DTminus':'DTplus';	
}
function FAQ_ToggleDLopen(){//we open all of them
	var zDD=document.getElementById('FAQ_DL').getElementsByTagName('dd');
	var zDT=document.getElementById('FAQ_DL').getElementsByTagName('dt');	
	for(var i=0;i<zDT.length;i++){
		zDD[i].className='showDD';
		zDT[i].className='DTminus';
	}
	return false;
}
function FAQ_ToggleDLclose(){//we close all of them	
	var zDD=document.getElementById('FAQ_DL').getElementsByTagName('dd');
	var zDT=document.getElementById('FAQ_DL').getElementsByTagName('dt');	
	for(var i=0;i<zDT.length;i++){
		zDD[i].className='hideDD';
		zDT[i].className='DTplus';
	}
	return false;	
}
function FAQ_ToggleDL(){
if (document.getElementById && document.getElementsByTagName){			
	var zDT=document.getElementById('FAQ_DL').getElementsByTagName('dt');
	var zDD=document.getElementById('FAQ_DL').getElementsByTagName('dd');
	var ToggleON = document.getElementById('FAQ_ToggleON');
	var ToggleOFF = document.getElementById('FAQ_ToggleOFF');	
	if (ToggleON && ToggleOFF){// Show All - Hide All "links"
		ToggleON.onclick = FAQ_ToggleDLopen;
		ToggleON.title = "Show all answers";
		ToggleON.href = "#";		
		ToggleOFF.onclick = FAQ_ToggleDLclose;	
		ToggleOFF.title = "Hide all answers";
		ToggleOFF.href = "#";		
	}
	for(var i=0;i<zDT.length;i++){
		var zContent = zDT[i].innerHTML;
		var zHref = "<a href='#' onclick=\"FAQ_doToggleDL("+i+");return false\" title='Show/hide the answer'>";
		zDT[i].innerHTML = zHref + zContent + "</a>";
		zDD[i].className='hideDD';
		zDT[i].className='DTplus';
		}
	}
}
