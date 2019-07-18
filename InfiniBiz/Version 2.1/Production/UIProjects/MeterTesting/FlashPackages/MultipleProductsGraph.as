import mx.services.*;
import mx.transitions.Tween;
class FlashPackages.MultipleProductsGraph {
	var spacer = 0;
	var i:Number;
	var j:Number;
	var ScaleBgColor:Color;
	var setScaleBgColor = 0xf3f3f3;
	var toolTipTransparency = 70;
	// Class Contructor;
	function MultipleProductsGraph(productSelectedValues, setVarPlanid, setCustomerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption) {
		MultipleProductsGraphLayout();
		WebServiceCaller(productSelectedValues, setVarPlanid, setCustomerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption);
	}
	function MultipleProductsGraphLayout() {
		for (i=0; i<10; i++) {
			spacer += 26.5;
			_root.createTextField("actuallValue_"+i, _root.getNextHighestDepth(), 5+spacer, 10, 25, 18);
			_root.createTextField("estimatedValue_"+i, _root.getNextHighestDepth(), 5+spacer, 175, 30, 100);
			_root.attachMovie("scale", "scale_"+i, _root.getNextHighestDepth(), {_x:25+spacer, _y:245});
			ScaleBgColor = new Color(_root["scale_"+i].scaleBg_mc);
			ScaleBgColor.setRGB(setScaleBgColor);
			_root["scale_"+i].scaleBg_mc._yscale = -875;
			_root["scale_"+i].scaleBg_mc._y = -70;
			_root["scale_"+i].scale_mc._yscale = -0;
			_root["scale_"+i].scale_mc._y = -70*2;
			_root["scale_"+i].Baseline_mc._y =-70*2
			_root["scale_"+i].shadow_mc._yscale = -0; 
			_root["scale_"+i].shadow_mc._y = -70*2;
			setMcColor(_root.mainBorder_mc, 0xD6E7F7);
			setMcColor(_root.innerBdr_mc, 0xD6E7F7);
		}
	}//
	function WebServiceCaller(productSelectedValues, setVarPlanid, setCustomerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption) {
		var stockservice = new WebService("https://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl");
		   // var myObj = stockservice.GetMultipleNodesXML(productSelectedValues,setVarPlanid,setCustomerid,ProSdate,ProEdate,PlanSdate,PlanEdate,getCurrency,GetOption);
		  var myObj = stockservice.GetMultipleNodesXML("U_1,U_93,", "U_2", "115161", "jan 2007", "19sep2007", "1", "9", "A", "1");
		var textBoxFormat:TextFormat = new TextFormat();
		with (textBoxFormat) {
			font = "Tahoma";
			bold = false;
			size = 9;
			align = "center";
			color = 0x3366CC;
			 trace(GetOption);
			if (GetOption == "1") {
				_root.options.text = "Managed Sales";
			} else if (GetOption == "2") {
				_root.options.text = "Managed COGS";
			} else if (GetOption == "3") {
				_root.options.text = "Managed Expense";
			}
			_root.cValue.text = "Value in "+getCurrency; 
		}
		myObj.onResult = function(result) {
			var getResult:String = result;
			//trace(getResult);
			var XMLLayout:XML = new XML(getResult);
			XMLLayout.ignoreWhite = true;
			var productsList:Array = XMLLayout.firstChild.childNodes;
			var getActuallPrice:Array = new Array();
			var getEstimatedPrice:Array = new Array();
			var getProductName:Array = new Array();
			for (j=0; j<productsList.length; j++) {
				getProductName[j] = productsList[j].firstChild;
				getActuallPrice[j] = productsList[j].firstChild.nextSibling.nextSibling;
				getEstimatedPrice[j] = productsList[j].firstChild.nextSibling;
				var getProName:String = getProductName[j].attributes.ProductName;
				var actuallPrice:Number = parseInt(getActuallPrice[j].attributes.ProPrices);
				var estimatedPrice:Number = getEstimatedPrice[j].attributes.PlanPrices;
				var actuallValueBox = _root["actuallValue_"+j];
				var estimatedValueBox = _root["estimatedValue_"+j];
				actuallValueBox.text = actuallPrice+getCurrency;
				actuallValueBox.setTextFormat(textBoxFormat);
				estimatedValueBox.text = estimatedPrice+getCurrency;
				estimatedValueBox.setTextFormat(textBoxFormat);
				var scaleObj:MovieClip = _root["scale_"+j].scale_mc;
				var colorObj:Color = new Color(scaleObj);
				var scaleShadowObj:MovieClip = _root["scale_"+j].shadow_mc;
				//var _global.getScaleValue:Number = Math.ceil((estimatedPrice*100)/actuallPrice);
				if (actuallPrice == 0) {
					 
				} else {
					_global.getScaleValue = Math.ceil(((actuallPrice-estimatedPrice)*100)/actuallPrice);
				}
				if (actuallPrice<estimatedPrice) {
					 _global.getScaleValue = Math.ceil(((estimatedPrice-actuallPrice)*100)/estimatedPrice);
				}
				var setScaleValue:Number = _global.getScaleValue*21;
 
				if (actuallPrice == estimatedPrice && actuallPrice == 0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, -21, .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, (-21/2), .8, true);
					colorObj.setRGB(0xCC0000);
					//trace("1");
				} else if (actuallPrice == 0 && estimatedPrice<>0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0,1950/2, .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0,1950/2, .8, true);
					colorObj.setRGB(0xCC0000);
					//trace("2");
				} else if (actuallPrice>estimatedPrice && estimatedPrice<>0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, (-setScaleValue/2), .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, (-setScaleValue/2), .8, true);
					colorObj.setRGB(0xffcc00); // Yellow
					//trace("3");
				} else if (estimatedPrice>actuallPrice && actuallPrice<>0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0,   (setScaleValue/2) , .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0,  (setScaleValue/2), .8, true);
					colorObj.setRGB(0xCC0000);
					 //trace("1"); 
					trace("4");
					 
				} else if (actuallPrice>estimatedPrice && estimatedPrice == 0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, (-2200/2), .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, (-2200/2), .8, true);
					colorObj.setRGB(0xffcc00); // Yellow
					trace("5");
				} else if (actuallPrice == estimatedPrice && actuallPrice<>0) {
					var myTween:Tween = new Tween(scaleObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, -22, .8, true);
					var myTween2:Tween = new Tween(scaleShadowObj, "_yscale", mx.transitions.easing.Regular.easeOut, -0, -22, .8, true);
					colorObj.setRGB(0x66cc00); // Green
					trace("6");
				}
				
				scaleObj.productName = getProName;
				scaleObj.productPrice = actuallPrice;
				scaleObj.estimatedPrice = estimatedPrice;
				scaleObj.setVariatons = _global.getScaleValue;
				scaleObj.onRollOver = function() {
					_root.caption_._visible = true;
					_root.caption_._alpha = toolTipTransparency;
					_root.caption_.proName_txt.text = this.productName;
					_root.caption_.apCaption.text = "Actual Price:";
					_root.caption_.epCaption.text = "Estimated Price:";
					_root.caption_.prCaption.text = "Variation:";
					var dav = this.productPrice-this.estimatedPrice;
					//trace(dav);
					_root.caption_.ap_txt.text = this.productPrice+"  "+getCurrency;
					_root.caption_.ep_txt.text = this.estimatedPrice+"  "+getCurrency;
					if (this.productPrice == this.estimatedPrice && this.productPrice === 0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					} else if (this.estimatedPrice>this.productPrice && this.productPrice === 0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					} else if (this.productPrice>this.estimatedPrice && this.estimatedPrice<>0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					} else if (this.estimatedPrice>this.productPrice && this.productPrice<>0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					} else if (this.productPrice>this.estimatedPrice && this.estimatedPrice == 0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					} else if (this.productPrice == this.estimatedPrice && this.productPrice<>0) {
						_root.caption_.vr_txt.text = dav+" , "+this.setVariatons+" % ";
					}
					startDrag("caption_", true);
				};
				scaleObj.onRollOut = function() {
					_root.caption_._visible = false;
				};
			}
		};
	}
	// Method for Movie Border Colors
	//----------------------------------------------------------
	function setMcColor(Obj_mc, obj_clr) {
		var setColor:Color = new Color(Obj_mc);
		setColor.setRGB(obj_clr);
	}
	//----------------------------------------------------------
	//End Method;
}
