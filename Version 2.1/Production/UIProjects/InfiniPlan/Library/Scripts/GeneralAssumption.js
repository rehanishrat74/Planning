

		function HighlightRow(ctl) {
			if (ctl.id.indexOf("_txtDay") != -1) { //textbox called function - reassign to TR tag
				var rowName = ctl.id.substring(0,ctl.id.indexOf("_txtDay"));
				ctl = document.getElementById(rowName);
			}
			//Reset previous highlighted row to original color
			var grid = document.getElementById(GetGridName(ctl.id));
			var CurrentRowHighlighted = grid.getAttribute("CurrentRowHighlighted");
			if (CurrentRowHighlighted != null && CurrentRowHighlighted != "") {
				//A previous row was highlighted
				document.getElementById(CurrentRowHighlighted).style.backgroundColor = grid.getAttribute("CurrentRowOriginalColor");
			}
		    
			//Store current row's id and original background color
			grid.setAttribute("CurrentRowHighlighted",ctl.id);
			grid.setAttribute("CurrentRowOriginalColor",ctl.style.backgroundColor);	
			
			//Temporarily change row's highlight color
			ctl.style.backgroundColor="#C0D7F0";
		}
