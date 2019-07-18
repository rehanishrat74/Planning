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
class FlashPackages.ActualSpeedoMeter {
	private var intervalID;
	private var initDegree;
	private var sqrRoot;
	private var productActualValue;
	private var productEstimatedValue;
	private var newActualValue;
	private var productName;
	private var needleMoveFrom;
	private var needleMoveTo;
	
	function ActualSpeedoMeter(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption, SInterval, EInterval, testInterval  ) {
		//trace("*** ActualSpeedoMeter ***")
		 var stockservice = new WebService("http://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl");
		  var myObj  = stockservice.GetSingleNodesXML_Basic(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption,SInterval,EInterval,testInterval   );
	 	// var myObj = stockservice.GetSingleNodesXML_Basic("U_7", "U_1", "2", "1 jan 2009", "31 jan 2009", "1", "1", "A", "1",0, 0, "false" );
		 
		    var inputType ;
 			myObj.onResult = function(result) {
			var getResult:String = result;
			var myXml:XML = new XML(getResult);
			myXml.ignoreWhite = true;
			var productsList:Array = myXml.firstChild.firstChild.childNodes;
			 productActualValue =   parseInt(productsList[2].attributes.ProPrices);  // Sets Actual Value;
			  productEstimatedValue =    parseInt(productsList[1].attributes.PlanPrices); // Sets Estimated Value; 
			 inputType =   GetOption; 
			 newActualValue = productActualValue+productEstimatedValue;
			 productName = productsList[0].attributes.ProductName;
			// Sets Product Name
			//@ Getting Degree for Actual Value Needle     
			var criteriacolor:Color = new Color(_root.criteria_mc);
			//@-------------------------------------------------------------------
			var prodegree = newActualValue/140;
			var product = productActualValue-productEstimatedValue;
			var getDegree = product/prodegree;
			//@--------------------------------------------------------------------
			//@ Getting Degree for Esimated Value 
			//---------------------------------------------------------------------
			var initValue = newActualValue/140;
			var newInitValue = productEstimatedValue-productActualValue;
			var getDegree2 = newInitValue/initValue;
			//---------------------------------------------------------------------
			//@ Trigonometry Logic for getting Degree Between Estimated and Actual Value 
			//---------------------------------------------------------------------
			needleMoveTo = Math.round(getDegree);
			needleMoveFrom = Math.round(getDegree2);
			 
			 
			var sqrArea = Math.round((needleMoveFrom*needleMoveFrom)+(needleMoveTo*needleMoveTo));
			sqrRoot = Math.round(Math.sqrt(sqrArea));
			 
			if (needleMoveTo<0) {
//				 dynamicCircle(-needleMoveFrom,needleMoveTo,sqrRoot,productActualValue,productEstimateValue)
				dynamicCircle(-needleMoveFrom, needleMoveTo, sqrRoot, productActualValue, productEstimatedValue);
				//@ Creating Dynamic Cricle
			} else {
				 
				dynamicCircle(needleMoveFrom, -needleMoveTo, sqrRoot, productActualValue, productEstimatedValue);
			}
			//---------------------------------------------------------------------
			//@--------------------------------------------------------------------
			//@ Sets Value in All Text Boxes  
			//@-------------------------------------------------------------------
			var formula = newActualValue/4;
			_root.tb1_txt.text = 0;
			_root.tb2_txt.text = Math.round(formula*1);
			_root.tb3_txt.text = Math.round(formula*2);
			_root.tb4_txt.text = Math.round(formula*3);
			_root.tb5_txt.text = Math.round(formula*4);
			_root.ActualPrice_txt.text = productActualValue+" "+getCurrency;
			_root.from_txt.text = "From: "+ProSdate;
			_root.To_txt.text = "To: "+ProEdate;
			if (testInterval == true) {
				 
				_root.interval_txt._visible = true;
				_root.dateinterval_txt._visible = true;
				_root.dateinterval_txt.text = SInterval+" (to) "+EInterval;
				// "From :"+ SInterval ;
				_root.interval_txt.text = "Interval";
			} else {
				 
				_root.dateinterval_txt._visible = false;
				_root.interval_txt._visible = false;
			}
			if (GetOption == "1") {
				 
				criteriacolor.setRGB(0x3333FF);
				// Blue
			} else if (GetOption == "2") {
				 
				criteriacolor.setRGB(0x00FFFF);
				// Light Blue
			}
			else if (GetOption == "3") {
				 
				criteriacolor.setRGB(0xBC8F8F  );
				// rosybrown   
			}
			//@------------------------------------------------------------------- 
			//@ Hover Tooltip 
			//@-------------------------------------------------------------------
			_root.hover_mc.productActualValue = productActualValue;
			_root.hover_mc.productEstimatedValue = productEstimatedValue;
			_root.hover_mc.productName = productName;
			_root.tooltip_mc.swapDepths(100000000);
			_root.hover_mc.onRollOver = function() {
				_root.tooltip_mc._visible = true;
				_root.tooltip_mc._alpha = 100;
				_root.tooltip_mc.tooltipProductName_txt.text = this.productName;
				//Tooltip Product Name Box  
				_root.tooltip_mc.toolTipActualValue_txt.text = this.productActualValue+" "+getCurrency;
				//Tooltip Actual Value Box  
				_root.tooltip_mc.toolTipEstimatedValue_txt.text = this.productEstimatedValue+" "+getCurrency;
				//Tooltip Estimated Value Box			startDrag(_root.tooltip_mc,true); 
				startDrag(_root.tooltip_mc, true);
			};
			_root.hover_mc.onRollOut = function() {
				_root.tooltip_mc._visible = false;
			};
			//@-------------------------------------------------------------------
		};
		//@ End Web Service Function 
		//@-------------------------------------------------------------------
		function dynamicCircle(moveFrom, moveTo, numbersOfPie, actualPrice, estimatedPrice) {
			 
			trace("moveTo: "+moveTo)
		var i:Number =  new Number();
		var rotation:Number = new Number(-142); 
		var pieMC = Math.round(numbersOfPie/2);
		var colorObj:Color = new Color(_root.pie_mc)
		var meterSpeed:Number = 2;
		if(actualPrice<estimatedPrice && actualPrice != 0  ){
			trace("actualPrice  < estimatedPrice" )
			//  colorObj.setRGB(0x66cc00 );   // Green Color 
			   colorObj.setRGB(0xffcc00 );  // yellow color
			
			if (inputType == "1")
				{
					   colorObj.setRGB(0xffcc00 );  // yellow color
					 
				}
				else if (inputType == "2")
				{
					 colorObj.setRGB(0x66cc00 );   // Green Color 
						 
				}
			 
		_root.onEnterFrame=function(){
				i++;
				rotation+=3;
				_root.pie_mc.duplicateMovieClip("newPie_mc"+i,i);
				_root["newPie_mc"+i]._rotation=rotation;
				
				if(rotation<=moveFrom){
					_root.needle_mc._rotation=rotation;
					}
				
				if(rotation>=-moveTo){
					delete this.onEnterFrame;
				}
				if(rotation>=moveFrom){	
				if (inputType == "1")
				{
					colorObj.setRGB(0xffcc00) 
					// Yellow
				}
				else if (inputType == "2")
				{
					colorObj.setRGB(0x000000 ) 
						// Black
				}
				}
				
			}
		}
			else if (actualPrice<estimatedPrice && actualPrice == 0) {
				trace("actualPrice = 0  , estimatedPrice");
				  
				if (inputType == "1")
				{
					colorObj.setRGB(0xffcc00);
					// Yellow
				}
				else  if (inputType == "2") 
				{
					colorObj.setRGB(0x000000);
					// Black
				}
				 _root.onEnterFrame = function() {
					i++;
					rotation += 3;
					_root.pie_mc.duplicateMovieClip("newPie_mc"+i, i);
					_root["newPie_mc"+i]._rotation = rotation;
					//_root.needle_mc._rotation=rotation;
					if (i>=47*2) {
						delete this.onEnterFrame;
					}
				};
			} else if (actualPrice == estimatedPrice && actualPrice != 0 && estimatedPrice != 0) {
				trace("actualPrice  = estimatedPrice");
				 
				colorObj.setRGB(0x66cc00);
				// greenCOLOR 
				meterSpeed = 0;
				new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, 0, 1, true);
				for (var i = -140; i<0; i += 3) {
					var DynScale_mc:MovieClip = _root.pie_mc.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1, true);
					new Color(DynScale_mc).setRGB(0x66cc00);
					// Green Color 
				}
			} else if (actualPrice == 0 && estimatedPrice == 0) {
				trace("actualPrice = 0 and  estimatedPrice = 0 ");
				// _root.pie_mc._visible=false;
				for (var i = -140; i<140; i += 3) {
					var DynScale_mc:MovieClip = _root.pie_mc.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, i, 1.8, true);
					
					if (inputType == "1")
					{
						new Color(DynScale_mc).setRGB(0xff0000);
						// Read
					}
					else if (inputType == "2")
					{
						new Color(DynScale_mc).setRGB(0xffFFFF );
					}
					
					
				}
			} else {
				 
				trace("actualPrice > estimatedPrice");
				
				if (inputType == "1") {
						colorObj.setRGB(0x66cc00); //  green COLOR  
						} else if (inputType == "2") {
							colorObj.setRGB(0xffcc00); //  green COLOR 
						}
						
		 		 
				
				_root.onEnterFrame = function() {
					i++;
					rotation += 3;
					_root.pie_mc.duplicateMovieClip("newPie_mc"+i, i);
					_root["newPie_mc"+i]._rotation = rotation;
					_root.needle_mc._rotation = rotation;
					if (_root.needle_mc._rotation>=Math.round(-moveTo)) {
						delete _root.onEnterFrame;
					}
					if (_root.needle_mc._rotation>=Math.round(moveFrom)) {
						 trace(inputType)
						if (inputType == "1") {
						colorObj.setRGB(0x000000);  // black Color; 
						} else if (inputType == "2") {
							 colorObj.setRGB(0xffcc00); // yellow Color; 
						}
					}
				};
			}
		}
	}
	//@ End Constructor  
}
//@ End Class 
