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
class  FlashPackages.MerchantActualSpeedoMeter {
	
	private var intervalID;
	private var initDegree; 
	private var sqrRoot;
	private var productActualValue; 
	private var productEstimatedValue;
	private var newActualValue;
	private var productName; 
	private var needleMoveFrom; 
	private var needleMoveTo; 
	function MerchantActualSpeedoMeter(  Customerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd, getCurrency,Name ) {
		//trace("*** MerchantActualSpeedoMeter ***")
		var stockservice = new WebService("http://accounts.infinibiz.com/MeterTesting/MeterViewService.asmx?wsdl"); 	// WebService Object 
		   var myObj = stockservice.GetMerchantMeters(  Customerid,dateStart, dateEnd,PreviousdayStart ,PreviousdayEnd,  getCurrency,Name );
		//  var myObj = stockservice.GetMerchantMeters(  "2", "1 march 2009 00:00:00.000", "27 march 2009 23:59:59.000" , "1 jan 2008 00:00:00.000" , "31 dec 2008 23:59:59.000" , "A",Name  );
			
		//These are below 6 conditios , uncomment one -by-one and check colors
		 
			myObj.onResult = function(result) {
			var getResult:String = result;
			var myXml:XML = new XML(getResult);
			myXml.ignoreWhite = true;
			var productsList:Array = myXml.firstChild.firstChild.childNodes;
			  productActualValue=      parseInt(productsList[1].attributes.ProPrices);  // Sets Actual Value;
			  productEstimatedValue=     parseInt(productsList[0].attributes.PlanPrices); // Sets Estimated Value; 

			newActualValue =  productActualValue+productEstimatedValue; 
			productName = Name; // productsList[0].attributes.ProductName;  // Sets Product Name
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
			// Test code 
			//needleMoveFrom = Math.round((getdegree.number)
			//trace("needle" + _root._currentframe.val)
			//trace(webservice("http://accoutns.infinibiz.com/metertesting/" + _root.endFill())
			//moveneelde.Exit();   
			
			//test code 	
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
						
			 //_root.from_txt.text ="From: "+ dateStart ;
			 //_root.To_txt.text ="To: "+ dateEnd;
			 
			 var monthShortName:Array = new Array("Jan", "Feb", "March", "April", "May", "June", "July", "Aug", "Sept", "Oct", "Nov", "Dec");
			 var monthName:Array = new Array("January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December");

				
			var  dtStart=dateStart.substring(0,dateStart.indexOf(" 00"));
			var  dtEnd=dateEnd.substring(0,dateEnd.indexOf(" 23"));
			var dtPreStart=PreviousdayStart.substring(0,PreviousdayStart.indexOf(" 00"))
			var dtPreEnd=PreviousdayEnd.substring(0,PreviousdayEnd.indexOf(" 23"))
				
			 for(var i=0; i <= 11 ;i++)
			 { 
			 	dtEnd = searchAndReplace(dtEnd, monthName[i],monthShortName[i]);
			 	dtStart = searchAndReplace(dtStart, monthName[i],monthShortName[i]);
				dtPreStart = searchAndReplace(dtPreStart, monthName[i],monthShortName[i]);
				dtPreEnd = searchAndReplace(dtPreEnd, monthName[i],monthShortName[i]);
			 } 
							 
			 
			 
			 /// Nisar Addition
			 
			 var dtCurYear= dtStart;
			 var iLengthCurYear=dtCurYear.length-4;
			 var sAuctualDate=dtStart.substring(0,dtStart.length-5) + " - " + dtEnd.substring(0,dtEnd.length-5)+ " " +dtCurYear.substring(iLengthCurYear,dtCurYear.length) ; 
			 _root.actual_date.text=sAuctualDate;
			 var dtPreYear= dtPreStart;
			 var iLengthPreYear=dtPreYear.length-4;
			 var sEstimatedDate=dtPreStart.substring(0,dtPreStart.length-5) + " - " + dtPreEnd.substring(0,dtPreEnd.length-5)+ " " +dtPreYear.substring(iLengthPreYear,dtPreYear.length) ; 
			_root.interval_txt.text=sEstimatedDate;
			 
			 /// Nisar Addition End
			 
			 
			 
			var a=dateEnd.replace
			 
				_root.interval_txt._visible = true 
				_root.dateinterval_txt._visible = true 
				 
				 var dtYear=dtPreStart;
				var ilestart=dtYear.length-4;
				_root.dateinterval_txt.text= dtPreStart.substring(0,dtPreStart.length-5) + " - " + dtPreEnd.substring(0,dtPreEnd.length-5)+ " " +dtYear.substring(ilestart,dtYear.length) ; // "From :"+ SInterval ;
				trace(_root.dateinterval_txt.text)
				
				//_root.interval_txt.text=_root.dateinterval_txt.text;
				//_root.interval_txt.text= dtStart ;
				//_root.interval_txt.text= dtPreStart.substring(0,dtPreStart.length-5) + " - " + dtPreEnd.substring(0,dtPreEnd.length-5)+ " " +dtYear.substring(ilestart,dtYear.length) ; // "From :"+ SInterval ;

			 

			 
			
		//@-------------------------------------------------------------------
		//@ Hover Tooltip 
		//@-------------------------------------------------------------------
			_root.hover_mc.productActualValue = productActualValue;
			_root.hover_mc.productEstimatedValue = productEstimatedValue;
			_root.hover_mc.productName = productName;
			_root.tooltip_mc.swapDepths(100000000)
			_root.hover_mc.onRollOver = function() {
				_root.tooltip_mc._visible = true;
				_root.tooltip_mc._alpha=100;
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
	function searchAndReplace(holder, searchfor, replacement) {
	var temparray = holder.split(searchfor);
	var holder = temparray.join(replacement);
	return (holder);
	};
	
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
			colorObj.setRGB(0xffcc00 ); //Yellow Color 
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
					colorObj.setRGB(0xffcc00)  // Yellow
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
			trace("saira" )
			trace(actualPrice + " = " + estimatedPrice)
			colorObj.setRGB(0x66cc00); // greenCOLOR 
			meterSpeed =0;
			new Tween(_root.needle_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140, 0, 1, true);
			 
		
		for(var i=-140;i<0;i+=3){
					var DynScale_mc:MovieClip =  _root.pie_mc.duplicateMovieClip("NextBlock"+i,i);
					new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, DynScale_mc._rotation , i, 1, true);
					new Color(DynScale_mc).setRGB(0x66cc00); //Green 
			}
		
		}
		else if(actualPrice == 0 && estimatedPrice == 0) {
			trace("actualPrice = 0 and  estimatedPrice = 0 " )
					// _root.pie_mc._visible=false;
		for(var i=-140;i<140;i+=3){
			var DynScale_mc:MovieClip =  _root.pie_mc.duplicateMovieClip("NextBlock"+i,i);
			new Tween(DynScale_mc, "_rotation", mx.transitions.easing.Regular.easeOut, -140 , i, 1.8, true);
			new Color(DynScale_mc).setRGB(0xff0000); // Red
			}
		
		}
		else{
			("Here..")
			trace("actualPrice > estimatedPrice" )
			trace(actualPrice + " > " + estimatedPrice)
			colorObj.setRGB(0x66cc00) //  green  COLOR 

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
				colorObj.setRGB(0x000000)	// black Color; 
				}
			
			} 
		}
	}
}//@ End Constructor  
}//@ End Class 

