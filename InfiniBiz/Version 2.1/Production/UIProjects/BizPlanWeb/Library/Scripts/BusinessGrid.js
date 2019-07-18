var ChangedCells
	function CellChanged(Cell)
	{
		var Row = Cell.getAttribute("Row")
		var Column = Cell.getAttribute("Col")
		var Value = Cell.getAttribute("value")
		if(ChangedCells==undefined)
			ChangedCells = Row + "," + Column + "," + Value
		else
			ChangedCells += ";" + Row + "," + Column + "," + Value
			
	}

	//Added by Syed Afaq Ali - win-afaq on August 22, 2005
	function SelectNextCell(Row,Col)
	{
		if(event.keyCode==37)	//key left pressed
		{
			//var cell= document.getElementById(GetID(Row,parseInt(Col)-1))
		}
		else if(event.keyCode==39)	//key right pressed
		{
			//var cell= document.getElementById(GetID(Row,parseInt(Col)+1))
		}
		else if(event.keyCode==38)	//key up pressed
		{
			//Get the cell
			var cell= document.getElementById(GetID(parseInt(Row)-1,Col))
			while(cell!=undefined)	//check if it exists
			{
				//check if it is an editable text box
				if(cell.type=="text" && cell.value!="" && cell.Expr==undefined)
				{
					cell.focus()
					break
				}
				else	//else select previous cell
				{
					cell= document.getElementById(GetID(parseInt(cell.Row)-1,cell.Col))
				}
			}
		}
		else if(event.keyCode==40)	//key down pressed
		{
			//Get the cell
			var cell= document.getElementById(GetID(parseInt(Row)+1,Col))
			while(cell!=undefined)	//check if it exists
			{
				//check if it is an editable text box
				if(cell.type=="text" && cell.value!="" && cell.Expr==undefined)
				{
					cell.focus()
					break
				}
				else	//else select next cell
				{
					cell= document.getElementById(GetID(parseInt(cell.Row)+1,cell.Col))
				}
			}
		}
	}
	//Added by Syed Afaq Ali - win-afaq on August 20, 2005
	function CopyRest()
	{
		var x=document.getElementById("SelectedRowNumber");
		var y=document.getElementById("SelectedColNumber");
		
		var cell= document.getElementById(GetID(x.value, y.value))
		var cellValue=cell.value
		do
		{
			cell = document.getElementById(GetID(cell.Row, parseInt(cell.Col)+1))
			if(cell != undefined)
			{
				if(cell.type=="text" && cell.Expr==undefined)
				{
					cell.value=cellValue
					CellChanged(cell)
					Calculate(parseInt(cell.Row), parseInt(cell.Col))
				}
			}				
		}while(cell != undefined)
		
	//	Calculate(parseInt(x.value), parseInt(y.value))
		//alert(x.value + "," + y.value)
		return false
	}
	//Added by Syed Afaq Ali - win-afaq on August 20, 2005
	function confirmNavigation()
	{
		if(ChangedCells==undefined)
		{
			return true
		}
		else
		{
			return confirm("The changes you have made will be lost.\nContinue?")
		}
	}
	//Added by Syed Afaq Ali - win-afaq on August 17, 2005
	function DeleteRow()
	{
		ConfirmSave();
		if (confirm("Are you sure you want to delete?")==false)return false;
		else return true;
	}
	//Added by Syed Afaq Ali - win-afaq on August 19, 2005
	function RenameRow()
	{
		var x=document.getElementById("NewRowName")
		var NewRowName
		
		ConfirmSave();
		while(1)
		{
			NewRowName=prompt("Enter new name of the row:")
			if(NewRowName=="undefined") alert("You must enter a row name");
			else if(NewRowName==null) return false;
			else break;
		}
				
		x.setAttribute("value",NewRowName)
	}
	
	function UpdateGrid()
	{
		if(ChangedCells==undefined)
		{
			alert("No changes to update");
			return false;
		}
		else
		{
			var x=document.getElementById("ChangedCells");
			x.setAttribute("value",ChangedCells)
		}
	}
	function RowSelected(Row)
	{
		var x=document.getElementById("SelectedRowNumber");
		x.setAttribute("value",Row.getAttribute("Row"))
	}
	//Added by Syed Afaq Ali - win-afaq on August 22, 2005
	function SelectCell(Row,Col)
	{
		var x=document.getElementById("SelectedRowNumber");
		var y=document.getElementById("SelectedColNumber");
		x.setAttribute("value",Row)
		y.setAttribute("value",Col)
		//alert(x.value + "," + y.value)
	}
	function GetNewRowName()
	{
		var x=document.getElementById("NewRowName")
		var NewRowName
		
		ConfirmSave()
		while(1)
		{
			NewRowName=prompt("Enter name of new row to insert:")
			if(NewRowName=="undefined") alert("You must enter a row name");
			else if(NewRowName==null) return false;
			else break;
		}
				
		x.setAttribute("value",NewRowName)
	}
	function StopImport()
	{
		 	 
			  alert("You must enter a row name");
	 
	}
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
		//document.getElementById(CurrentRowHighlighted).style.backgroundColor = grid.getAttribute("CurrentRowOriginalColor");
		document.getElementById(CurrentRowHighlighted).className = grid.getAttribute("CurrentRowOriginalColor");
	}
	
	//Store current row's id and original background color
	grid.setAttribute("CurrentRowHighlighted",ctl.id);
	//grid.setAttribute("CurrentRowOriginalColor",ctl.style.backgroundColor);	
	grid.setAttribute("CurrentRowOriginalColor",ctl.className);
	
	//Temporarily change row's highlight color
	//ctl.style.backgroundColor="#C0D7F0";
	ctl.className="GridItemOnClick";
}

//Added by Syed Afaq Ali - win-afaq on August 23, 2005
function HighlightCurrentRow(Row)
{
	var ctlRow = document.getElementById(GetRowID(Row))
	
	//Reset previous highlighted row to original color
	var grid = document.getElementById(GetGridName(ctlRow.id));
	var CurrentRowHighlighted = grid.getAttribute("CurrentRowHighlighted");
	if (CurrentRowHighlighted != null && CurrentRowHighlighted != "")
	{
		//A previous row was highlighted
		//document.getElementById(CurrentRowHighlighted).style.backgroundColor = grid.getAttribute("CurrentRowOriginalColor");
		document.getElementById(CurrentRowHighlighted).className = grid.getAttribute("CurrentRowOriginalColor");
	}
	
	//Store current row's id and original background color
	grid.setAttribute("CurrentRowHighlighted",ctlRow.id);
	//grid.setAttribute("CurrentRowOriginalColor",ctlRow.style.backgroundColor);	
	grid.setAttribute("CurrentRowOriginalColor",ctlRow.className);	
	
	//Temporarily change row's highlight color
	//ctlRow.style.backgroundColor="#C0D7F0";
	ctlRow.className="GridItemOnClick";
}

/*
function GetCellID(Row, Column)
{
	return "bgTable_"+ Row + "_" + Column
}*/
function GetGridName(ctlID)
{
	return ctlID.substring(0,ctlID.indexOf("_"));
}

//Added by Syed Afaq Ali - win-afaq on August 17, 2005
function catchEnter()
{
	if(event.keyCode == 13)return false;
	else return true;
}

//Added by Syed Afaq Ali - win-afaq on August 17, 2005
function ConfirmSave()
{
	var y=document.getElementById("ChangedCells")
	var z=document.getElementById("Save")
		
	if(ChangedCells==undefined)
	{
		z.setAttribute("value","No")
	}
	else
	{
		if (confirm("Changed values will be updated.\nContinue?")==false)
		{
			y.setAttribute("value",undefined)
			z.setAttribute("value","No")
		}
		else
		{
			y.setAttribute("value",ChangedCells)
			z.setAttribute("value","Yes")
		}
	}
}

