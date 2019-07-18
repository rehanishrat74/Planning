﻿/* 
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

class FlashPackages.TwoBarGraph {
	private	var estamitedBarMovement;
	private	var percentage;
	function TwoBarGraph(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption,SInterval,EInterval,testInterval) {
		trace("** Welcome to in 2BarGraph **");
		init();
		trace(_root.estimatedBar_mc._yscale)
		trace(_root.actEstBar_mc._yscale)
		 var stockservice = new WebService("http://ac.infiniplan.com/MeterTesting/MeterViewService.asmx?wsdl");// WebService Object 
		 
					 
		  var myObj = stockservice.GetSingleNodesXML_Basic(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption,SInterval,EInterval,testInterval);
		
		 //   var myObj = stockservice.GetSingleNodesXML_Basic("U_38", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
				
		 myObj.onResult = function(result) {
			 var getResult:String = result;
			 var myXml:XML = new XML(getResult);
			 
			 
			 myXml.ignoreWhite = true;
			 var productsList:Array = myXml.firstChild.firstChild.childNodes;
			

			
			
	var ActualBarValue =  parseInt(productsList[2].attributes.ProPrices);  // Sets Actual Value; 
	var EstimatedBarValue =  parseInt(productsList[1].attributes.PlanPrices); // Sets Estimated Value; 
	var productName = productsList[0].attributes.ProductName;// Sets Product Name
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
		
		setColor(_root.actualBar_mc,0xff3300)// RED 
		setColor(_root.actEstBar_mc,0xffCC00)// ORGANE Color
		setColor(_root.estimatedBar_mc,0xffCC00)// YELLOW
		
		}
			else if (EstimatedBarValue>ActualBarValue && EstimatedBarValue!=0 && ActualBarValue!=0 ){
				trace("actualPrice  < estimatedPrice" )
				trace(ActualBarValue + " < " + EstimatedBarValue)
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0,-100 , 1, true);
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
				new Tween(_root.actEstBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
				setColor(_root.actEstBar_mc,0xff9900) // Yellow Color 
				setColor(_root.estimatedBar_mc,0xffcc00)
				}
			else if(ActualBarValue == 0 && EstimatedBarValue ==0){
				trace("actualPrice = 0 and  estimatedPrice = 0 " )
				setColor(_root.actualBar_mc,0x000000)
				setColor(_root.estimatedBar_mc,0x000000)
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				_root.actEstBar_mc._yscale=0;
				}
			else if(ActualBarValue==0 && EstimatedBarValue >ActualBarValue){
				 trace("actualPrice = 0 ,  estimatedPrice > 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0x000000)// BLACK Color
				setColor(_root.estimatedBar_mc,0xffCC00)// YELLOW
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				_root.actEstBar_mc._yscale=0;

				}
			else if(EstimatedBarValue==0 && ActualBarValue >EstimatedBarValue){
				 trace("actualPrice > 0 ,  estimatedPrice = 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0xff0000);// RED Color
				setColor(_root.estimatedBar_mc,0x000000);
				 setColor(_root.actEstBar_mc,0xff0000);
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				new Tween(_root.actEstBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				}	
			else if(EstimatedBarValue ==0 && ActualBarValue>EstimatedBarValue ){
				 trace("actualPrice > 0 ,  estimatedPrice = 0 " )
			trace(ActualBarValue + " , " + EstimatedBarValue)
				setColor(_root.actualBar_mc,0x66cc00)
				new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -100, 1, true);
				new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -5, 1, true);
				}
		else{
			trace("actualPrice = estimatedPrice1" )
			trace(ActualBarValue + "= " + EstimatedBarValue)
			setColor(_root.actualBar_mc,0x66cc00)	//GREEN 
			setColor(_root.estimatedBar_mc,0xffCC00)// YELLOW
			_root.actEstBar_mc._yscale=0;
			estamitedBarMovement = new Tween(_root.estimatedBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true);
			var actualBarMovement = new Tween(_root.actualBar_mc, "_yscale", mx.transitions.easing.Regular.easeOut, 0, -percentage, 1, true)
	}

	_root.hover_mc.onRollOver=function(){
		_root.tolltip_mc._visible = true;
		_root.tolltip_mc._alpha = 80;
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
			_root["tb_"+i]._width = 30; //  TextBox Width
			_root["tb_"+i]._height = 15;// Text Box Height 
			_root["tb_"+i]._x = 8;
			_root["tb_"+i]._y = -5+spacer;
			_root["tb_"+i].text = Math.round(formula*temp);
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