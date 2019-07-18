/*
  ------------------------------------------------------------------
 |   Actual to Estimated SpeedOMeter Meter Class					|
 |   Developed By : S.Zeeshan Ali									|
 |   version: 0.8													|
 |   Dated: 15/09/2007												|
 |   copyright: InfiniLogic(Pvt.)Ltd.								|
  ------------------------------------------------------------------
*/
//@----------------------------------------------------------------------
	import mx.services.*;
	import mx.transitions.Tween;
//----------------------------------------------------------------------
class  FlashPackages.MerchantDeviationScale {
	private var intervalID;
	private var initDegree; 
	private var sqrRoot;
	private var productActualValue; 
	private var productEstimatedValue;
	private var sumOfActualValue;
	private var productName; 
	private var needleMoveFrom; 
	private var needleMoveTo; 
	function MerchantDeviationScale( setCustomerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd, getCurrency,Name) {
		//trace("*** ActualSpeedoMeter ***")
		 var stockservice = new WebService("http://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl"); 	// WebService Object 
		 
		  var myObj = stockservice.GetMerchantMeters(  setCustomerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd,  getCurrency,Name );
		//  var myObj = stockservice.GetMerchantMeters(  "115161", "17 April 2008 00:00:00.000", "17 April 2008 23:59:59.000" , "16 April 2008 00:00:00.000" , "16 April 2008 23:59:59.000" , "A",Name  );
			
		myObj.onResult = function(result) 
		 {
		 var getResult:String = result;
		 var myXml:XML = new XML(getResult);
		 myXml.ignoreWhite = true;
		 var productsList:Array = myXml.firstChild.firstChild.childNodes;
		_root.arrow_mc._visible=false;
		productActualValue =   parseInt(productsList[1].attributes.ProPrices); 
		productEstimatedValue =   parseInt(productsList[0].attributes.PlanPrices); 
		productName = Name ; // productsList[0].attributes.ProductName; 
		 
		sumOfActualValue = productActualValue*2;
		
		_root.SM_ZeroTB_txt.text = "0";
		for (var loop = 0; loop<=4; loop++) {
			var devideSMTBValues:Number = Math.round((sumOfActualValue*loop)/4);
			_root["SMTextBox"+loop].text = devideSMTBValues ;
		}
		
		// Returns Esimated Value in Degree 
		//---------------------------------------------
			var prodegree = sumOfActualValue/280;
			var product = productEstimatedValue-productActualValue //ActualValue-givenVal;
			var estDegree = product/prodegree;
		//----------------------------------------------
		
		// Returns Actual Value in Degree 
		//-----------------------------------------------
			
			var prodegree = sumOfActualValue/280;
			var product = productActualValue-productEstimatedValue //ActualValue-givenVal;
			var actDegree = product/prodegree;
		//-----------------------------------------------
			var variation = productActualValue-productEstimatedValue;
			var getActualValueInDegree = actDegree;
			var getEstimatedValueInDegree = estDegree;
			new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, _root.needle_mc._rotation , getEstimatedValueInDegree, 1.8, true);
			
			if(productActualValue == productEstimatedValue && productEstimatedValue!=0 && productActualValue!=0){
				   trace("est =  act");
				for(var i=-140;i<getEstimatedValueInDegree;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					new Color(DynScale_mc).setRGB(0x66cc00); // Green
					}
			}
			else if (productEstimatedValue>sumOfActualValue){
				  trace("est >  act + est ");
				// ESTIMATED GRATER THAN SUM OF ACTUAL VALUE 
				for(var i=-140;i<140;i+=3){
					
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					new Color(DynScale_mc).setRGB(0xffcc00); //  YELLOW
					var tween  = new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, _root.needle_mc._rotation , 140, 1.8, true);
				}
				tween.onMotionFinished = function() {
    				_root.arrow_mc._visible=true;
					};

			}
			else if (productEstimatedValue>productActualValue){
				   trace("est > act");
				for(var i=-140;i<getEstimatedValueInDegree;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					if(i<0){new Color(DynScale_mc).setRGB(0xffcc00 )  ;} // Green
					else{new Color(DynScale_mc).setRGB(0xffcc00); // Yellow
					}
				}
			}
					
			else if (productEstimatedValue>productActualValue){
				   trace("est =  act");
				// ESTIMATED GRATER THAN ACTUAL 
				for(var i=-140;i<getEstimatedValueInDegree;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					if(i<0){new Color(DynScale_mc).setRGB(0xff9900);}// ORANGE
					else{new Color(DynScale_mc).setRGB(0xffcc00);}// YELLOW
				}
			}			
			else if (productEstimatedValue<productActualValue){
				   trace("est <  act");
				// ESTIMATED LESS THAN ACTUAL
				
				for(var i=-140;i<0;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					if(i<getEstimatedValueInDegree){new Color(DynScale_mc).setRGB(0x66cc00 );} // Green
					else{new Color(DynScale_mc).setRGB(0x000000);} // Black
				}
			}
			else if (productEstimatedValue>productActualValue && productActualValue == 0){
				// ACTUAL = 0
			}

			else if (productEstimatedValue<productActualValue && productEstimatedValue==0){
				// ESTIMATED LESS THAN ACTUAL
				 
				    trace("est = 0   act >0");
				for(var i=140;i<0;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1.8, true);
					if(i<getEstimatedValueInDegree){new Color(DynScale_mc).setRGB(0xffcc00); }// Yellow
					else{new Color(DynScale_mc).setRGB(0xff0000);} // red
				}
			}else{
				   trace("est = 0   act >0");
				for(var i=-140;i<140;i+=3){
					var DynScale_mc:MovieClip =  _root.dynScale.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140 , i, 1.8, true);
					if(i<0){new Color(DynScale_mc).setRGB(0xff0000);}// red
					else{new Color(DynScale_mc).setRGB(0xff0000);}// Red
				}
		
				}
			
	
	
		// VARIATION SCALE 
		//------------------------------------------------------------------------------------
			if (variation>0) {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 22, 1, true);
				} else if (variation == 0) {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 98, 1, true);
				} else {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 171, 1, true);
			}
		//------------------------------------------------------------------------------------
	_root.vtb_zero.text = "0";
		for (var loop = 0; loop<=3; loop++) {
			var devideVBTBValues:Number = Math.round((variation*loop)/3);
			_root["vtb"+loop].text = Math.abs(devideVBTBValues) + " " + getCurrency;
			_root["_vtb"+loop].text = "-"+_root["vtb"+loop].text  ;
		}
	
	
			// TOOL TIP 
			//---------------------------------------------------------------------------------
			_root.hover_mc.productActualValue = productActualValue;
			_root.hover_mc.productEstimatedValue = productEstimatedValue;
			_root.hover_mc.productName = productName;
			_root.tooltip_mc.swapDepths(_root.getNextHighestDepth())
			_root.hover_mc.onRollOver = function() {
				_root.tooltip_mc._visible = true;
				_root.tooltip_mc._alpha=100;
				_root.tooltip_mc.tooltipProductName_txt.text = this.productName;			//Tooltip Product Name Box  
				_root.tooltip_mc.toolTipActualValue_txt.text = this.productActualValue+" "+ getCurrency;		//Tooltip Actual Value Box  
				_root.tooltip_mc.toolTipEstimatedValue_txt.text = this.productEstimatedValue+" "+ getCurrency;//Tooltip Estimated Value Box			startDrag(_root.tooltip_mc,true); 
				_root.tooltip_mc.variation_txt.text = variation
				startDrag(_root.tooltip_mc, true);
			};
			_root.hover_mc.onRollOut = function() {
				_root.tooltip_mc._visible = false;
			};
		//-------------------------------------------------------------------------------------
			
}//@ End Constructor  
	}
}//@ End Class 

