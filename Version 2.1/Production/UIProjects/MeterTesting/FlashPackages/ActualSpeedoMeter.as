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
class  FlashPackages.ActualSpeedoMeter {
	
	private var intervalID;
	private var initDegree; 
	private var sqrRoot;
	private var productActualValue; 
	private var productEstimatedValue;
	private var newActualValue;
	private var productName; 
	private var needleMoveFrom; 
	private var needleMoveTo; 
	function ActualSpeedoMeter(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption,SInterval,EInterval,testInterval) {
		//trace("*** ActualSpeedoMeter ***")
		var stockservice = new WebService("https://ac.infiniplan.com/MeterTesting/MeterViewService.asmx?wsdl"); 	// WebService Object 
		
		var myObj = stockservice.GetSingleNodesXML_Basic(getSelectedPro, Planid, Customerid, ProSdate, ProEdate, PlanSdate, PlanEdate, getCurrency, GetOption,SInterval,EInterval,testInterval);
		
		//These are below 6 conditios , uncomment one -by-one and check colors
		
		//  var myObj = stockservice.GetSingleNodesXML_Basic("U_55", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
			 // var myObj = stockservice.GetSingleNodesXML_Basic("U_36", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
		 //var myObj = stockservice.GetSingleNodesXML_Basic("U_39", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
			 // var myObj = stockservice.GetSingleNodesXML_Basic("U_42", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
			//  var myObj = stockservice.GetSingleNodesXML_Basic("U_41", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
			//  var myObj = stockservice.GetSingleNodesXML_Basic("U_48", "U_3", "114887", "1 jan 2007", "31 dec 2007", "1", "12", "A", "1","1 jan 2007","31 Jan 2007","false");
			
			
			myObj.onResult = function(result) {
			var getResult:String = result;
			var myXml:XML = new XML(getResult);
			myXml.ignoreWhite = true;
			var productsList:Array = myXml.firstChild.firstChild.childNodes;
			productActualValue= parseInt(productsList[2].attributes.ProPrices);  // Sets Actual Value;
			productEstimatedValue=  parseInt(productsList[1].attributes.PlanPrices); // Sets Estimated Value; 
			newActualValue = productActualValue+productEstimatedValue; 
			productName = productsList[0].attributes.ProductName;  // Sets Product Name
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
			
			trace("needleMoveFrom: "+needleMoveFrom)
			trace("needleMoveTo: "+needleMoveTo)
			var sqrArea = Math.round((needleMoveFrom*needleMoveFrom)+(needleMoveTo*needleMoveTo))
			sqrRoot = Math.round(Math.sqrt(sqrArea));
		trace("needleMoveFrom" +needleMoveFrom)
		if(needleMoveTo < 0){
			trace("A")
			dynamicCircle(-needleMoveFrom,needleMoveTo,sqrRoot,productActualValue,productEstimatedValue); //@ Creating Dynamic Cricle
		}else{
				trace("B")
				dynamicCircle(needleMoveFrom,-needleMoveTo,sqrRoot,productActualValue,productEstimatedValue);
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
			_root.ActualPrice_txt.text = productActualValue +" "+ getCurrency;
			 
			_root.from_txt.text ="From: "+ ProSdate  ;
			_root.To_txt.text ="To: "+ ProEdate;
			if (testInterval ==  true  )
			{
				trace("teue");
				_root.interval_txt._visible = true 
				_root.dateinterval_txt._visible = true 
				 
				 _root.dateinterval_txt.text= SInterval + " (to) " + EInterval; // "From :"+ SInterval ;
				_root.interval_txt.text="Interval";
				 
			}
			else 
			{
				trace(testInterval);
				 _root.dateinterval_txt._visible =  false  
				 _root.interval_txt._visible =  false 
				 
				
			}
			 
  
			if ( GetOption== "1" )
			{
				trace("a");
				criteriacolor.setRGB(0x3333FF)
			}
			else if ( GetOption== "2" )
			{
				trace("b");
					criteriacolor.setRGB(0x00FFFF)
			}
			
		//@-------------------------------------------------------------------
		//@ Hover Tooltip 
		//@-------------------------------------------------------------------
			_root.hover_mc.productActualValue = productActualValue;
			_root.hover_mc.productEstimatedValue = productEstimatedValue;
			_root.hover_mc.productName = productName;
			_root.tooltip_mc.swapDepths(100000000)
			_root.hover_mc.onRollOver = function() {
				_root.tooltip_mc._visible = true;
				_root.tooltip_mc._alpha=80;
				_root.tooltip_mc.tooltipProductName_txt.text = this.productName;			//Tooltip Product Name Box  
				_root.tooltip_mc.toolTipActualValue_txt.text = this.productActualValue+" "+ getCurrency;		//Tooltip Actual Value Box  
				_root.tooltip_mc.toolTipEstimatedValue_txt.text = this.productEstimatedValue+" "+ getCurrency;//Tooltip Estimated Value Box			startDrag(_root.tooltip_mc,true); 
				startDrag(_root.tooltip_mc, true);
			};
			_root.hover_mc.onRollOut = function() {
				_root.tooltip_mc._visible = false;
				
			};
		//@-------------------------------------------------------------------
		};

	
	//@ End Web Service Function 
	//@-------------------------------------------------------------------
	
	
	function dynamicCircle(moveFrom,moveTo,numbersOfPie, actualPrice, estimatedPrice){
		trace("moveTo: "+moveTo)
		var i:Number =  new Number();
		var rotation:Number = new Number(-142); 
		var pieMC = Math.round(numbersOfPie/2);
		var colorObj:Color = new Color(_root.pie_mc)
		var meterSpeed:Number = 2;
		if(actualPrice<estimatedPrice && actualPrice != 0  ){
			trace("actualPrice  < estimatedPrice" )
			trace("Here...")
			trace(actualPrice + " < " + estimatedPrice)
			colorObj.setRGB(0xFF9933); //Blue Color 
			// var myTween:Tween = new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, moveTo, 1, true);
		 
 
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
					colorObj.setRGB(0xffcc00) 
				}
				
			}
		}
		else if(actualPrice<estimatedPrice && actualPrice ==0 ){
			trace("actualPrice = 0  , estimatedPrice" )
			trace(actualPrice + " , " + estimatedPrice)
			colorObj.setRGB(0xffcc00); // YELLOW COLOR 
			//trace( -moveTo + ":" +"1")
			//var myTween:Tween = new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, -moveTo, 1, true);
			_root.onEnterFrame=function(){
				i++;
				rotation+=3;
				_root.pie_mc.duplicateMovieClip("newPie_mc"+i,i);
				_root["newPie_mc"+i]._rotation=rotation;
				//_root.needle_mc._rotation=rotation;
				if(i>=47*2){
					
					delete this.onEnterFrame;
				}	
			}
		}
		else if(actualPrice == estimatedPrice && actualPrice!=0 && estimatedPrice!=0){
			trace("actualPrice  = estimatedPrice" )
			trace(actualPrice + " = " + estimatedPrice)
			colorObj.setRGB(0x66cc00); // greenCOLOR 
			meterSpeed =0;
			new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, 0, 1, true);
			_root.pie_mc._rotation=0;
		}
		else if(actualPrice == 0 && estimatedPrice == 0) {
			trace("actualPrice = 0 and  estimatedPrice = 0 " )
			
			 _root.pie_mc._visible=false;
		}
		else{
			("Here..")
			trace("actualPrice > estimatedPrice" )
			trace(actualPrice + " > " + estimatedPrice)
			colorObj.setRGB(0xffcc00) //  RED COLOR 

			_root.onEnterFrame=function(){
				i++;
				rotation+=3
				_root.pie_mc.duplicateMovieClip("newPie_mc"+i,i);
				_root["newPie_mc"+i]._rotation=rotation ;
				_root.needle_mc._rotation=rotation

			if(_root.needle_mc._rotation >=Math.round(-moveTo)){
				delete _root.onEnterFrame;
				}
			if(_root.needle_mc._rotation >= Math.round(moveFrom)){
				colorObj.setRGB(0xff0000)	// RED Color; 
				}
			
			} 
		}
	}
}//@ End Constructor  
}//@ End Class 

