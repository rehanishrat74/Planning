/* 
-------------------------------------+	
	Developed By S.Zeeshan Ali 		 |
	Dated: 23/Nov/2007  			 |
 	Infinilogic (Pvt.)Ltd.			 | 
-------------------------------------+
*/

//@---------------------------------------------------
	import mx.transitions.Tween;// imports Tween Class
	import mx.services.*;//imports WebService 
//@---------------------------------------------------

class FlashPackages.MerchantTwoBarGraph {
	private	var estamitedBarMovement;
	private	var percentage;
	function MerchantTwoBarGraph(Customerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd, getCurrency,Name) {
		trace("** Welcome to in 2BarGraph **");
		init();
		trace(_root.estimatedBar_mc._yscale)
		trace(_root.actEstBar_mc._yscale)
		   var stockservice = new WebService("http://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl");// WebService Object 
		 
					 
		   var myObj = stockservice.GetMerchantMeters(  Customerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd,  getCurrency );
		 //  var myObj = stockservice.GetMerchantMeters(  "115161", "1 april 2008 00:00:00.000", "24 april 2008 23:59:59.000" , "1 mar 2008 00:00:00.000" , "31 mar 2008 23:59:59.000" , "A","Test" );
			
		 myObj.onResult = function(result) {
			 var getResult:String = result;
			 var myXml:XML = new XML(getResult);
			 
			 
			 myXml.ignoreWhite = true;
			 var productsList:Array = myXml.firstChild.firstChild.childNodes;
						
	var ActualBarValue =     parseInt(productsList[1].attributes.ProPrices);  // Sets Actual Value; 
	var EstimatedBarValue =   parseInt(productsList[0].attributes.PlanPrices); // Sets Estimated Value; 
	var productName =  Name; // productsList[0].attributes.ProductName;// Sets Product Name
	var colorObj:Color = new Color(_root.actualBar_mc)
	percentage = ActualBarValue/EstimatedBarValue*100
	 
	if(ActualBarValue>=EstimatedBarValue){ 	textBoxBuilder(ActualBarValue);	}
	else{	textBoxBuilder(EstimatedBarValue);	}
	
	if(ActualBarValue>EstimatedBarValue && ActualBarValue !=0 && EstimatedBarValue!=0 ){
		percentage = EstimatedBarValue/ActualBarValue*100
		trace("actualPrice  > estimatedPrice" )
			trace(ActualBarValue + " > " + EstimatedBarValue)
		new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
		var actEstBar = new Tween(_root.actEstBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
		_root.actualBar_mc._yscale=0;
		actEstBar.onMotionFinished =function(){
			new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);			
			}
		
		setColor(_root.actualBar_mc,0x00000)// black  ff3300 
		setColor(_root.actEstBar_mc,0x66cc00 )// Green Color
		setColor(_root.estimatedBar_mc,0x66cc00 ) //Green
		
		}
			else if (EstimatedBarValue>ActualBarValue && EstimatedBarValue!=0 && ActualBarValue!=0 ){
				trace("actualPrice  < estimatedPrice" )
				 
				//new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
				//new Tween(_root.actEstBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
				
				_root.estimatedBar_mc._yscale = 0;
				trace("-percentage: "+percentage)
				
				var EstActBar = new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
						EstActBar.onMotionFinished = function() {
					new Tween(_root.EstActBar, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				};
				setColor(_root.EstActBar, 0x000000 );
					// Yellow Color 
					setColor(_root.estimatedBar_mc, 0x000000);
					//Green
					setColor(_root.actualBar_mc, 0xffcc00 );
					//Green
				
				}
			else if(ActualBarValue == 0 && EstimatedBarValue ==0){
				trace("actualPrice = 0 and  estimatedPrice = 0 " )
				setColor(_root.actualBar_mc,0xff3300)
				setColor(_root.estimatedBar_mc,0xff3300)
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				_root.actEstBar_mc._yscale=0;
				}
			else if(ActualBarValue==0 && EstimatedBarValue >ActualBarValue){
				 trace("actualPrice = 0 ,  estimatedPrice > 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0xff3300)
				setColor(_root.estimatedBar_mc,0x000000)
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				_root.actEstBar_mc._yscale=0;

				}
			else if(EstimatedBarValue==0 && ActualBarValue >EstimatedBarValue){
				 trace("actualPrice > 0 ,  estimatedPrice = 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0x000000);// Black Color
				setColor(_root.estimatedBar_mc,0xff0000);
				//Red Color
				 setColor(_root.actEstBar_mc,0x000000);
				 // Black
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.actEstBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				}	
			else if(EstimatedBarValue ==0 && ActualBarValue>EstimatedBarValue ){
				 trace("actualPrice > 0 ,  estimatedPrice = 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0x66cc00)
				//Green
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				}
		else{
			trace("actualPrice = estimatedPrice1" )
			trace(ActualBarValue + "= " + EstimatedBarValue)
			setColor(_root.actualBar_mc,0x66cc00)	//GREEN 
			setColor(_root.estimatedBar_mc,0x66cc00) //Green
			_root.actEstBar_mc._yscale=0;
			estamitedBarMovement = new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
			var actualBarMovement = new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true)
	}

	_root.hover_mc.onRollOver=function(){
		_root.tolltip_mc._visible = true;
		_root.tolltip_mc._alpha = 100;
			startDrag(_root.tolltip_mc, true);
		_root.tolltip_mc._x = 15;
		_root.tolltip_mc._y = 50;
		_root.tolltip_mc.Caption_ActualPrice.text = ActualBarValue+" "+ getCurrency;  
		_root.tolltip_mc.Caption_EstimatedPrice.text = EstimatedBarValue+" "+ getCurrency;
		_root.tolltip_mc.Caption_productName.text = productName;
		_root.tolltip_mc.swapDepths(_root.getNextHighestDepth());
		}
	_root.hover_mc.onRollOut=function(){ _root.tolltip_mc._visible = false; }
	_root.acl_tb.text = ActualBarValue;// Display Actuall Value in TextBox;
	_root.est_tb.text = EstimatedBarValue;// Display Estimated Value in TextBox;

	};
//@-------------------------------------------------------
	function textBoxBuilder(tbValue) {
		var spacer = 0;
		var formula = tbValue/4;
		var textFormat:TextFormat = new TextFormat();
		textFormat.size = 11; // Font Size 
		textFormat.align = "right";// Font Align 
		textFormat.font = "Arial";// Font Family 
		textFormat.bold = true; // Bold 
		var temp = 5;
		for (var i=0; i<5; i++) {
			spacer += 43;
			temp--;
			_root.createTextField("tb_"+i, i, null, null, null, null);
			_root["tb_"+i]._width = 45; //  TextBox Width
			_root["tb_"+i]._height = 15;// Text Box Height 
			_root["tb_"+i]._x = 8;
			_root["tb_"+i]._y = -5+spacer;
			_root["tb_"+i].text = Math.round(formula*temp) + " " + getCurrency;
			_root["tb_"+i].border=0;
			_root["tb_"+i].selectable=false;
			_root["tb_"+i].setTextFormat(textFormat);
		}
	}		
//}
//@-------------------------------------------------------------------
//@-------------------------------------------------------------------
	function init(){
		_root.actualBar_mc._y = 225;
		_root.estimatedBar_mc._y= 225;
		_root.actEstBar_mc._y=225
		_root.estimatedBar_mc._yscale= 0;
		_root.actEstBar_mc._yscale=0;
		_root.EstActBar._y = 225;
			_root.EstActBar._yscale = 0;
		_root.actualBar_mc._yscale=0;
		_root.estTop_mc._y = 0  
		_root.estimatedBar_mc.swapDepths(_root.scale_lines_mc)
		_root.actualBar_mc.swapDepths(_root.scale_lines_mc)
		_root.tolltip_mc._visible=false;
		}
//@-------------------------------------------------------------------

	function setColor(obj,clr){
		var getColor:Color = new Color(obj)
		getColor.setRGB(clr);
		}
}
}