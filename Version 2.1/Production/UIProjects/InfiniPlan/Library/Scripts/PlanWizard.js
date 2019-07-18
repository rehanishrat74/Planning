var pageID

function SelectPlanNav(navOption)
{
	/*if(navOption==6)	//6 stands for show Plan wizard
	{
		//StartWizard(1)
	}
	else*/ if(navOption==4)	//4 stands for show Plan preview
	{
		StartPreview()
	}
	else
	{
		return true;
	}
	return false
}

function StartPreview()
{
	url = "/InfiniPlan/Services/PlanPreview/PlanPreview.htm";
	window.open(url,null,"height=600,width=900,left=20,top=20,status=yes,toolbar=no,menubar=yes,location=no,scrollbars=yes,top=20,resizable=yes");
	return false
}

function StartWizard(wizType)
{
	var url="/InfiniPlan/Services/PlanWizard/PlanWizardView.aspx"
	if(wizType==0)	//0 stands for without nav
	{
		openSimDialog(url + "?nav=0", 550, 425,changeWindowURL);
		pageID="PM"
	}
	else		//else with nav
	{
		openSimDialog(url + "?nav=1", 800, 440,changeWindowURL);
	}
	//var wizard=window.open(url,0,"dialogWidth:800px;dialogHeight:500px");
	return false
}

function changeWindowURL()
{
	if(pageID=="PM")
	{
		window.navigate("/InfiniPlan/Services/Welcome.aspx")
	}
	else
	{
		window.navigate(window.location.href)
	}
}

function WizardCancel()
{
	handleCancel( );
    //window.close();
    return false;
}

function checkStatus()
{	
/*	if (opener && opener.blockEvents)opener.blockEvents();
	var status= document.getElementById("hdnStatus")
	if (status.value=="0")
	{
		closeme()
	}
	else if (status.value=="2")
	{
		if (opener && !opener.closed && opener.dialogWin)opener.dialogWin.returnFunc();
		closeme()
	}*/
}

function unloadWizard()
{
	if (opener && opener.unblockEvents)opener.unblockEvents( )
}







// handle click of OK button
function handleOK( ) {
    if (opener && !opener.closed && opener.dialogWin) {
        opener.dialogWin.returnFunc();
    } else {
        alert("You have closed the main window.\n\nNo action will be taken on the " +
              "choices in this dialog box.");
    }
    closeme( );
    return false;
}
   
// handle click of Cancel button
function handleCancel( ) {
    closeme( );
    return false;
}

// close the dialog
function closeme( ) {
    window.close( );
}