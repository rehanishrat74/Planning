 
//@----------------------------------------------------------------------
import mx.services.*;
import mx.transitions.Tween;
//----------------------------------------------------------------------
class FlashPackages.EnterpriseDeviationROI {
	private var intervalID;
	private var initDegree;
	private var sqrRoot;
	private var productActualValue;
	private var productEstimatedValue;
	private var sumOfActualValue;
	private var productName;
	private var needleMoveFrom;
	private var needleMoveTo;
 
	function EnterpriseDeviationROI(Customerid, dateStart, dateEnd, LastStartDate, LastEndDate, getCurrency, meterName, meterType) {
		 
		 var stockservice = new WebService("http://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl");
		// WebService Object 
  		  var myObj = stockservice.LoadEnterpriseMeters(  Customerid,dateStart, dateEnd,LastStartDate ,LastEndDate,  getCurrency,meterType );
			  //  var myObj = stockservice.LoadEnterpriseMeters("115161", "may 7 2007  00:00:00.000", "may 6 2008 23:59:59.000", "may 7 2006  00:00:00.000", "may 6 2007 23:59:59.000", "A", "ROI");
			var InputType  
			myObj.onResult = function(result) {
			var getResult:String = result;
			var myXml:XML = new XML(getResult);
			myXml.ignoreWhite = true;
			 InputType = myXml.firstChild.attributes.meterType;
			var productsList:Array = myXml.firstChild.firstChild.childNodes;
			_root.arrow_mc._visible = false;
			productActualValue =      parseInt(productsList[1].attributes.ProPrices); 
			productEstimatedValue =  parseInt(productsList[0].attributes.PlanPrices); 
			productName = meterName;
			// productsList[0].attributes.ProductName; 
			sumOfActualValue = productActualValue*2;
			_root.SM_ZeroTB_txt.text = "0";
			for (var loop = 0; loop<=4; loop++) {
				var devideSMTBValues:Number = Math.round((sumOfActualValue*loop)/4);
				_root["SMTextBox"+loop].text = devideSMTBValues;
			}
			// Returns Esimated Value in Degree 
			//---------------------------------------------
			var prodegree = sumOfActualValue/280;
			var product = productEstimatedValue-productActualValue;
			//ActualValue-givenVal;
			var estDegree = product/prodegree;
			//----------------------------------------------
			// Returns Actual Value in Degree 
			//-----------------------------------------------
			var prodegree = sumOfActualValue/280;
			var product = productActualValue-productEstimatedValue;
			//ActualValue-givenVal;
			var actDegree = product/prodegree;
			//-----------------------------------------------
			var variation = productActualValue-productEstimatedValue;
			var getActualValueInDegree = actDegree;
			var getEstimatedValueInDegree = estDegree;
			new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, _root.needle_mc._rotation, getEstimatedValueInDegree, 1.8, true);
			if (productActualValue == productEstimatedValue && productEstimatedValue != 0 && productActualValue != 0) {
				trace("act = est");
				for (var i = -140; i<getEstimatedValueInDegree; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1.8, true);
						
					new Color(DynScale_mc).setRGB(0x66cc00); // Green
				}
			} else if (productEstimatedValue>sumOfActualValue) {
				trace("est = 2 * act");
				// ESTIMATED GRATER THAN SUM OF ACTUAL VALUE 
				for (var i = -140; i<140; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1.8, true);
					if (InputType == "Sales" || InputType == "Profit" || InputType == "ROI" ) {
						new Color(DynScale_mc).setRGB(0xffcc00); //  YELLOW
					} else if (InputType == "COGS" || InputType == "Overheads") {
						new Color(DynScale_mc).setRGB(0x000000); // black
					}
					var tween = new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, _root.needle_mc._rotation, 140, 1.8, true);
				}
				tween.onMotionFinished = function() {
					_root.arrow_mc._visible = true;
				};
			} else if (productEstimatedValue>productActualValue) {
				trace("est > act");
				for (var i = -140; i<getEstimatedValueInDegree; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1.8, true);
					if (i<0) {
						if (InputType == "Sales" || InputType == "Profit" ) {
							new Color(DynScale_mc).setRGB(0x66cc00); // Green
						} else if (InputType == "COGS" || InputType == "Overheads") {
							new Color(DynScale_mc).setRGB(0x66cc00); // Green
						}
						else if (InputType == "ROI")  {
							new Color(DynScale_mc).setRGB(0xffcc00); // yellow
						}
					} else {
						if (InputType == "Sales" || InputType == "Profit"  ) {
							new Color(DynScale_mc).setRGB(0xffcc00); // yellow
						} else if (InputType == "COGS" || InputType == "Overheads") {
							new Color(DynScale_mc).setRGB(0x000000); // Black
						}
						else if (InputType == "ROI")  {
							new Color(DynScale_mc).setRGB(0xffcc00); // yellow
						}
					}
				}
			} else if (productEstimatedValue<productActualValue) {
				// ESTIMATED LESS THAN ACTUAL
				trace("est < act");
				for (var i = -140; i<0; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1.8, true);
					if (i<getEstimatedValueInDegree) {
						if (InputType == "Sales" || InputType == "Profit" ) {
							new Color(DynScale_mc).setRGB(0x66cc00); //  Green  COLOR 
						} else if (InputType == "COGS" || InputType == "Overheads") {
							new Color(DynScale_mc).setRGB(0x66cc00); //  Green  COLOR 
						} else if ( InputType == "ROI") {
							new Color(DynScale_mc).setRGB(0xffcc00); //  yellow  COLOR 
						}
					} else {
						if (InputType == "Sales" || InputType == "Profit" ) {
							new Color(DynScale_mc).setRGB(0x000000);
							//  black
						} else if (InputType == "COGS" || InputType == "Overheads") {
							new Color(DynScale_mc).setRGB(0xffcc00); //  Yellow
						} else if (  InputType == "ROI") {
							new Color(DynScale_mc).setRGB(0x000000);
						}
					}
				}
			} else if (productEstimatedValue>productActualValue && productActualValue == 0) {
				// ACTUAL = 0
			} else if (productEstimatedValue<productActualValue && productEstimatedValue == 0) {
				// ESTIMATED LESS THAN ACTUAL
				trace("est = 0 and act > 0 ");
				for (var i = 140; i<0; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation, i, 1.8, true);
					if (i<getEstimatedValueInDegree) {
						new Color(DynScale_mc).setRGB(0xffcc00); //    Yellow
					} else {
						new Color(DynScale_mc).setRGB(0xff0000); // red
					}
				}
			} else {
				trace("act=est=0");
				for (var i = -140; i<140; i += 3) {
					var DynScale_mc:MovieClip = _root.dynScale.duplicateMovieClip("NextBlock"+i, i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, i, 1.8, true);
					 
						if (InputType == "Sales" || InputType == "Profit" || InputType == "ROI")
						{
							trace('a');
							new Color(DynScale_mc).setRGB(0xff0000); // red
						}
							else if (InputType == "COGS" || InputType == "Overheads" )
						{
							trace('b');
							new Color(DynScale_mc).setRGB(0xFFFFFF); // Whitle
						}
			
						
					 
				}
			}
			// VARIATION SCALE 
			//------------------------------------------------------------------------------------
			trace(variation);
			if (variation>0) {
				trace("+ve");
				if (InputType == "Sales" || InputType == "Profit" || InputType == "ROI") {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 22, 1, true);
				} else if (InputType == "COGS" || InputType == "Overheads") {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 171, 1, true);
				}
			} else if (variation == 0) {
				trace("0");
				new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 98, 1, true);
			} else {
				trace("-ve");
				if (InputType == "Sales" || InputType == "Profit" || InputType == "ROI") {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 171, 1, true);
				} else if (InputType == "COGS" || InputType == "Overheads") {
					new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Regular.easeOut, 98, 22, 1, true);
				}
			}
			//------------------------------------------------------------------------------------
			_root.vtb_zero.text = "0";
			for (var loop = 0; loop<=3; loop++) {
				var devideVBTBValues:Number = Math.round((variation*loop)/3);
				_root["vtb"+loop].text = Math.abs(devideVBTBValues)+" "+ "%";
				_root["_vtb"+loop].text = "-"+_root["vtb"+loop].text;
			}
			// TOOL TIP 
			//---------------------------------------------------------------------------------
			_root.hover_mc.productActualValue = productActualValue;
			_root.hover_mc.productEstimatedValue = productEstimatedValue;
			_root.hover_mc.productName = productName;
			_root.tooltip_mc.swapDepths(_root.getNextHighestDepth());
			_root.hover_mc.onRollOver = function() {
				_root.tooltip_mc._visible = true;
				_root.tooltip_mc._alpha = 100;
				_root.tooltip_mc.tooltipProductName_txt.text = this.productName;
				//Tooltip Product Name Box  
				_root.tooltip_mc.toolTipActualValue_txt.text = this.productActualValue+" "+ "%";
				//Tooltip Actual Value Box  
				_root.tooltip_mc.toolTipEstimatedValue_txt.text = this.productEstimatedValue+" "+"%";
				//Tooltip Estimated Value Box			startDrag(_root.tooltip_mc,true); 
				
				//_root.tooltip_mc.variation_txt.text = variation;
				
					if (InputType == "Sales" || InputType == "Profit" || InputType == "ROI")
						{
							_root.tooltip_mc.variation_txt.text =   variation ;
						}
							else if (InputType == "COGS" || InputType == "Overheads" )
						{
							if ( variation > 0 ) 
							{
								_root.tooltip_mc.variation_txt.text = "-"+  variation  ;
							}
							else if ( variation < 0 )
							{
							_root.tooltip_mc.variation_txt.text =   Math.abs(variation) ;
							}
						}
							
				startDrag(_root.tooltip_mc, true);
			};
			_root.hover_mc.onRollOut = function() {
				_root.tooltip_mc._visible = false;
			};
			//-------------------------------------------------------------------------------------
		};
		//@ End Constructor  
	}
}
//@ End Class 
