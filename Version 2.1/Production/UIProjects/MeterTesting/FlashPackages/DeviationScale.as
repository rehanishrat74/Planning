/*
 +-----------------------------------------------------------------------+
 |   DEVIATION SCALE CLASS												 |
 |   author: S.Zeeshan Ali												 |
 |   version: 0.8														 |
 |   Dated: 29/05/2007													 |
 |   copyright: InfiniLogic(Pvt.)Ltd.									 |
 +-----------------------------------------------------------------------+ 
*/
// Import reference for required Classes 
//----------------------------------------------------------------------
import mx.services.*;
import mx.xpath.XPathAPI;
import mx.transitions.Tween;
//----------------------------------------------------------------------
// Creating Speed-o-Meter Class named Source. 
//----------------------------------------------------------------------
class FlashPackages.DeviationScale {
	var i:Number;
	//Constructor
	//-----------
	function DeviationScale(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption) {
		trace("Welcome");
		_root.attachMovie("caption", "caption_", 1);
		_root.caption_._visible = false;
		XMLWebService(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption);
		//trace(XMLWebService());
	}
	//Calling Web Service for which is giving XML as String.
	//------------------------------------------------------
	function XMLWebService(gerProduct, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption) {
		var stockservice = new WebService("https://ac.infiniplan.com/MeterTesting/MeterViewService.asmx?wsdl");
		   var myObj = stockservice.GetSingleNodesXML(gerProduct, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption);
		//    var myObj = stockservice.GetSingleNodesXML("U_51", "U_3", "114887", "jan 2007", "27sep2007", "1", "9", "A", "1");
		myObj.onResult = function(result) {
			var getResult:String = result;
			var myXml:XML = new XML(getResult);
			myXml.ignoreWhite = true;
			var productsList:Array = myXml.firstChild.childNodes;
			for (i=0; i<productsList.length; i++) {
				var productValues:Array = productsList[i].childNodes;
				var productName:String = productValues[0].attributes.ProductName;
				var endTo:Number = productValues[1].attributes.PlanPrices;
				// Estimated Price
				var actuallValue:Number = parseInt(productValues[2].attributes.ProPrices);
				// Actual Price
				_root.tb1_txt.text = actuallValue-actuallValue;
				_root.tb2_txt.text = Math.round(actuallValue/2);
				_root.tb3_txt.text = Math.round(actuallValue);
				_root.tb4_txt.text = Math.round(actuallValue*1.5);
				_root.tb5_txt.text = Math.round(actuallValue*2);
				_root.MTD_txt.text = productValues[3].attributes.MTD;
				_root.MTY_txt.text = productValues[3].attributes.MTY;
				var aclVlaue = actuallValue;
				var estmValue = endTo;
				var DeviatedValue = aclVlaue-estmValue;
				_root.sb7_txt.text = Math.abs(Math.round(DeviatedValue))+""+getCurrency;
				_root.sb6_txt.text = Math.abs(Math.round(DeviatedValue/2))+""+getCurrency;
				_root.sb5_txt.text = Math.abs(Math.round(DeviatedValue/4))+""+getCurrency;
				_root.sb4_txt.text = 0;
				_root.sb3_txt.text = "-"+Math.abs(Math.round(DeviatedValue/4))+""+getCurrency;
				_root.sb2_txt.text = "-"+Math.abs(Math.round(DeviatedValue/2))+""+getCurrency;
				_root.sb1_txt.text = "-"+Math.abs(Math.round(DeviatedValue))+""+getCurrency;
				var setEstmValue = endTo/2;
				if (setEstmValue>actuallValue) {
					var rotaion = getDegrees(144, setEstmValue);
					_root.newVlu_txt.text = endTo;
				} else {
					var rotaion = getDegrees(actuallValue, setEstmValue);
				}
				/*trace("+--------------------------------------+");
				trace("| Product Name : "+productName);
				"				trace("| Actual Value : "+actuallValue);
				trace("| Estimated Value: "+endTo);
				trace("+--------------------------------------+");
				*/
			}
			trace(getCurrency);
			if (GetOption == "1") {
				_root.options.text = "Managed Sales";
			} else if (GetOption == "2") {
				_root.options.text = "Managed COGS";
			} else if (GetOption == "3") {
				_root.options.text = "Managed Expense";
			}
			_root.DynamicTxt1.text = "Blue pointer represents variation of actual value from the ";
			_root.DynamicTxt2.text = "estimated values in "+getCurrency;
			_root.hover_mc.productPrice = actuallValue;
			_root.hover_mc.estimatedPrice = endTo;
			_root.hover_mc.deviations = Math.abs(Math.round(actuallValue-endTo));
			_root.hover_mc.onRollOver = function() {
				_root.caption_._visible = true;
				_root.caption_._alpha = 75;
				_root.caption_.proName_txt.text = productName;
				_root.caption_.apCaption.text = "Actual Price:";
				_root.caption_.epCaption.text = "Estimated Price:";
				_root.caption_.dvCaption.text = "Deviation:";
				_root.caption_.ap_txt.text = this.productPrice+" "+getCurrency;
				_root.caption_.ep_txt.text = this.estimatedPrice+" "+getCurrency;
				var dev = this.productPrice-this.estimatedPrice;
				_root.caption_.dv_txt.text = dev+" "+getCurrency;
				startDrag("caption_", true);
			};
			_root.hover_mc.onRollOut = function() {
				_root.caption_._visible = false;
			};
			var minValue = 0;
			var max = _root.hover_mc.productPrice;
			var niddleVal = _root.hover_mc.estimatedPrice;
			var tolValue = Math.round(niddleVal*100/max);
			var setTolvalue = Math.abs(Math.round(tolValue*3));
			var minusValue = 169-setTolvalue;
			//trace("##################### "+actuallValue)
			trace("Product Price "+max);
			trace("estimatedPrice"+niddleVal);
			if (niddleVal>max && max<>0) {				// est > act 
				trace("1");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 165, 2, true);
				if (endTo>=(aclVlaue*2)) {
					var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, 150, 2, true);
				//@ Niddle Fluctuation     
					//@-------------------------------------------------------
					myTween.onMotionFinished = function() {
						Motion(_root.niddle_mc);
					};
					//@ End Method
					//@--------------------------------------------------------
					
				} else {
					var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, rotaion, 2, true);
				}
			} else if (niddleVal == max && max<>0) {				//est=act and act <> 0 
				trace("2");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 90, 2, true);
				var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, rotaion, 2, true);
			} else if (niddleVal == max && max == 0) {				// est == act ,act = 0 
				trace("3");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 90, 2, true);
				var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, -138, 2, true);
			} else if (niddleVal>max && max == 0) {				// est >act  , act =0 
				trace("4");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 165, 2, true);
				var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, 150, 2, true);
				//@ Niddle Fluctuation     
					//@-------------------------------------------------------
					myTween.onMotionFinished = function() {
						Motion(_root.niddle_mc);
					};
					//@ End Method
					//@--------------------------------------------------------
					
			} else if (max>niddleVal && max<>0 && niddleVal<>0) {
				//act > est , est<>act<>0
				trace("5");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 20, 2, true);
				 
					var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, rotaion, 2, true);
				 
			} else if (max>niddleVal && niddleVal == 0) {
				//act > est , est =0
				trace("6");
				var myTween2:Tween = new Tween(_root.deviationNiddle_mc, "_y", mx.transitions.easing.Back.easeOut, _root.deviationNiddle_mc._y, 20, 2, true);
				  
					var myTween:Tween = new Tween(_root.niddle_mc, "_rotation", mx.transitions.easing.Back.easeOut, _root.niddle_mc._rotation, rotaion, 2, true);
				 
			}
			
			//@ Niddle Fluctuation  Method 
				//@----------------------------------------------------
				function Motion(object) {
					_root.onEnterFrame = function() {
						if (object._rotation == 150) {
							object._rotation = 149;
						} else {
							object._rotation = 150;
						}
					};
				}
				//@ End Method 
				//@-----------------------------------------------------
				
		};
		function getDegrees(totalPro, givenPro) {
			this.totalPro = totalPro*2;
			this.givenPro = givenPro;
			var myPro = totalPro/2;
			if (givenPro>myPro) {
				var variation = 180-30;
				var perDegree = myPro/variation;
				var products = givenPro-myPro;
				var degree = (products/perDegree);
				return degree;
			}
			if (givenPro<myPro) {
				var variation = 180-42;
				var perDegree = myPro/variation;
				var products = givenPro-myPro;
				var degree = (products/perDegree);
				return degree;
			}
			if (givenPro=myPro) {
				var degree = 0;
				return degree;
			}
		}
	}
}
//----------------------------------------------------------------------
// End Class; 
