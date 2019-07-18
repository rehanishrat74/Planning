function getPlanName()
{
	var x=document.getElementById("hdnPlanName");
	var NewPlanName;
	
	while(1)
	{
		NewPlanName=prompt("Enter new name for the Plan:");
		if ((NewPlanName=="undefined") || (NewPlanName=="")) alert("You must enter a plan name");
		else if (NewPlanName==null) return false;
		else if(!isValidName(NewPlanName)) alert("Please enter a valid Plan name.");
		else break;
	}
			
	x.setAttribute("value",NewPlanName);

	return true;
}

// validates that the entry is formatted as an email address
function isValidName(planName)
{
    var str = planName;
    var re = /^([A-Za-z0-9 ,._]*)$/;
    if (!str.match(re)) {
        return false;
    } else {
        return true;
    }
}