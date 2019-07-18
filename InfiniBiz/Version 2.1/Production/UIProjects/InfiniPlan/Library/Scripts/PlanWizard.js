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

function date(minusDay)
        {
         var m_names = new Array("Jan", "Feb", "Mar","Apr","May","JUN","JUL","Aug","Sep","Oct","Nov","Dec");
                    
                    var month , lMonth
                    var now = new Date();
                    /*var hour        = now.getHours();
                    var minute      = now.getMinutes();
                    var second      = now.getSeconds();-*/
                    var monthnumber = now.getMonth() + 1;
                    var monthday    = now.getDate();
                    var year        =  now.getYear();
                    var minusDate
                    
                    var isLeapYear = year % 4 == 0 
                    
                    month = m_names[monthnumber - 1]
                    isLeapYear = false; 
                                                                  
                    if((monthday - minusDay) <= 0 ) 
                    {
                            lMonth = m_names[monthnumber - 2]
                             
                             if((monthnumber )% 2 == 0)
                             {
                             
                                minusDate = 31 - ( -1 * (monthday - minusDay)) + "/"+ lMonth  + "/" + year
                             }
                             else
                             {
                                if((monthnumber)== 9 )
                                {
                                
                                minusDate = 31 - ( -1 * (monthday - minusDay)) + "/"+ lMonth  + "/" + year
                                }
                                else if((monthnumber)== 1 )
                                {
                                 minusDate = 31 - ( -1 * (monthday - minusDay)) + "/"+ m_names[11]  + "/" + (year-1)
                                }
                                else
                                {
                                    if((monthnumber)== 3 )
                                    {
                                     if(isLeapYear)
                                     {
                                      
                                      minusDate = 29 - ( -1 * (monthday - minusDay)) + "/"+ lMonth  + "/" + year
                                     }else
                                     {
                                      
                                       minusDate = 28 - ( -1 * (monthday - minusDay)) + "/"+ lMonth  + "/" + year
                                     }
                                    }
                                    else
                                    {
                                    
                                    minusDate = 30 - ( -1 * (monthday - minusDay)) + "/"+ lMonth  + "/" + year
                                    }
                                }
                             }
                      
                     } 
                     else 
                     {
                      minusDate = (monthday - minusDay) + "/"+ month  + "/" + year
                     }
                     alert(minusDate);
                    return minusDate;                        
        }
function SetDate()
{
 var today = new Date();
   var in_a_week  = new Date().setDate(today.getDate()+7);
   var ten_days_ago=new Date().setDate(today.getDate()-10);
   
 
var today_date  = new Date();
alert(today_date.getDate()); //displays 15
today_date.setDate(25);
alert(today_date.getDate()); //displays 25

 
}

