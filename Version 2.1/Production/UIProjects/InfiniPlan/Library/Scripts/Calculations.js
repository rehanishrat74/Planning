var LastRow = 0
var CellExpressions 
var Expr
var NextToken
var CurrentToken
var CurrentPosition 
var CurrentCell

var EndOfStream = 0
var Unknown = 1
var LeftRoundBracket = 2
var RightRoundBracket = 3
var LeftSquareBracket = 4
var RightSquareBracket = 5
var Colon = 6
var Comma = 7
var ConcatinationOperator = 8
var PowerOperator = 9
var PlusMinusOperator = 10
var MultiplyDivideOperator = 11
var IntegerLiteral = 12
var FloatLiteral = 13
var Identifier = 14
var RowKeyword = 15
var ColumnKeyword = 16
var StringLiteral = 17


function Init()
{
	var CellChanged = ""
	var table = document.getElementById("bgTable")
	if(table==null)
		return
	if(table.hasChildNodes())
		LastRow = table.firstChild.childNodes.length-2
		
	var Labels=table.getElementsByTagName("span")
	var Texts=table.getElementsByTagName("input")
	var LabelExpressionsCount = 0
	var TextExpressionsCount = 0
	var cell
	var ctl
	var Row
	var Column
	var j = 0
	for(var i=0;i<Texts.length;i++)
	{
		ctl=Texts[i]
		Expr=ctl.getAttribute("Expr")
		if(Expr!=null)
			TextExpressionsCount++
	}
	var LabelCells = new Array(LabelExpressionsCount)
	var TextCells = new Array(TextExpressionsCount)
	j=0
	for(var i=0;i<Labels.length;i++)
	{
		ctl=Labels[i]
		Expr=ctl.getAttribute("Expr")
		if(Expr!=null)
		{
			Row=ctl.getAttribute("Row")
			Column=ctl.getAttribute("Col")
			cell = new Cell(Row, Column)
			cell.Expression = Expr
			LabelCells[j]=cell
			j++
		}
	}
	j=0
	for(var i=0;i<Texts.length;i++)
	{
		ctl=Texts[i]
		Expr=ctl.getAttribute("Expr")
		if(Expr!=null)
		{
			Row=ctl.getAttribute("Row")
			Column=ctl.getAttribute("Col")
			cell = new Cell(Row, Column)
			cell.Expression = Expr
			TextCells[j]=cell
			j++
		}
	}
	CellExpressions=LabelCells.concat(TextCells)
}

function Calculate(Row, Column)
{
	var cell
	var el
	el=document.getElementById(GetID(Row, Column))
	for(var i=0;i<CellExpressions.length;i++)
	{
		cell=CellExpressions[i]
		//if(cell.Row>=Row && cell.Column>=Column)
		//{
		if(el.Dependents.indexOf(cell.Row + "-" + cell.Column)!=-1)
		{
			el=document.getElementById(GetID(cell.Row, cell.Column))
			el.setAttribute("value","X")
			if(el.hasChildNodes())
				el.firstChild.nodeValue="X"
		}
		//}
	}

	el=document.getElementById(GetID(Row, Column));
	for(var i=0;i<CellExpressions.length;i++)
	{
		cell=CellExpressions[i]
		//if(cell.Row>=Row && cell.Column>=Column)
		if(el.Dependents.indexOf(cell.Row + "-" + cell.Column)!=-1)
		{
			EvaluateCell(cell.Row, cell.Column)
		}
	}
}

function EvaluateCell(Row, Column)
{
		var cell = document.getElementById(GetID(Row, Column))
        Expr=cell.getAttribute("Expr")
        Expr=Expr.toUpperCase()
        var value=Parse(new Cell(Row, Column))
		cell.setAttribute("value", value)
		if(cell.hasChildNodes())
			cell.firstChild.nodeValue=value
	    return value
}

function IsDigit(ch)
{
	var code = ch.charCodeAt(0)
	if (code>=48 && code <58)
		return 1;
	else
		return 0;
}

function IsLetter(ch)
{
	ch=ch.toUpperCase()
	var code = ch.charCodeAt(0)
	if (code>=65 && code <91)
		return 1;
	else
		return 0;
}

function Token(Type, Lexeme)
{
this.Type = Type
this.Lexeme = Lexeme
}

function Match(Type)
{
	if ( NextToken.Type == Type )
	{
		CurrentToken = NextToken
		NextToken = GetNextToken()
		return 1
	}
	else
	{
		alert("Missing " + Type)
		CurrentPosition == Expr.Length
		return 0
	}
}

function Advance()
{
	CurrentToken = NextToken
	NextToken = GetNextToken()
}

function NextCharacter()
{
    if ( CurrentPosition < Expr.length )
        return Expr.charAt(CurrentPosition)
    else
        return ""
}

function GetIntegerLexeme()
{
	var Lexeme = ""
	while( CurrentPosition < Expr.length )
		if(IsDigit(NextCharacter()))
		{
			Lexeme=Lexeme.concat(NextCharacter())
			CurrentPosition++
		}
		else
			return Lexeme
	return Lexeme
}

function GetNextToken()
{
	var TempToken = new Token(Unknown,"")
	if (CurrentPosition > Expr.length - 1 )
		return new Token(EndOfStream)
	var nc = NextCharacter()
	switch(nc)
	{
		case "(":
			CurrentPosition++
			return new Token(LeftRoundBracket, "(")
		case ")":
			CurrentPosition++
			return new Token(RightRoundBracket, ")")
		case "[":
			CurrentPosition++
			return new Token(LeftSquareBracket, "[")
		case "]":
			CurrentPosition++
			return new Token(RightSquareBracket, "]")
		case ":":
			CurrentPosition++
			return new Token(Colon, ":")
		case ",":
			CurrentPosition++
			return new Token(Comma, ",")
		case "&":
			CurrentPosition++
			return new Token(ConcatinationOperator, "&")
		case "^":
			CurrentPosition++
			return new Token(PowerOperator, "^")
		case "+":
			CurrentPosition++
			return new Token(PlusMinusOperator, "+")
		case "-":
			CurrentPosition++
			return new Token(PlusMinusOperator, "-")
		case "*":
			CurrentPosition++
			return new Token(MultiplyDivideOperator, "*")
		case "/":
			CurrentPosition++
			return new Token(MultiplyDivideOperator, "/")
		case "'":
			CurrentPosition++
			TempToken.Type = StringLiteral
			while(NextCharacter() != "'" )
			{
				TempToken.Lexeme = TempToken.Lexeme.concat(NextCharacter())
				CurrentPosition++
			}
			CurrentPosition++
			return TempToken
	}
	if (IsDigit(nc))
	{
		TempToken.Type = IntegerLiteral
		TempToken.Lexeme = NextCharacter()
		CurrentPosition++
		TempToken.Lexeme = TempToken.Lexeme.concat(GetIntegerLexeme())
		if ( NextCharacter() == "." )
		{
			CurrentPosition++
			TempToken.Lexeme = TempToken.Lexeme.concat(".")
			TempToken.Type = FloatLiteral
			TempToken.Lexeme = TempToken.Lexeme.concat(GetIntegerLexeme())
		}
		return TempToken
	}
	if ( IsLetter(nc) )
	{
		TempToken.Type = Identifier
		TempToken.Lexeme = NextCharacter()
		CurrentPosition++
		while( CurrentPosition < Expr.length )
			if( IsLetter(NextCharacter()) )
			{
				TempToken.Lexeme = TempToken.Lexeme.concat(NextCharacter())
				CurrentPosition++
			}
			else
				break
		if ( TempToken.Lexeme == "R" ) TempToken.Type = RowKeyword
		if ( TempToken.Lexeme == "C" ) TempToken.Type = ColumnKeyword
		return TempToken
	}
	return new Token(Unknown)
}














function Cell(Row, Column)
{
	this.Row=Row
	this.Column=Column
	this.Value=""
	this.Expression=""
	this.Evaluated=0
}

function CellRange()
{
	this.StartCell=new Cell(0,0)
	this.EndCell=new Cell(0,0)
}

function Parse(CurrentCell)
{
	this.CurrentCell=CurrentCell
	var value
	CurrentPosition = 0
    NextToken = GetNextToken()
    value = ExpressionOptional()
	if (!(NextToken.Type == EndOfStream))
		alert("Parse Error")
    return value
}

function ExpressionListOptional()
{
    if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == LeftSquareBracket || NextToken.Type == PlusMinusOperator)
    {
		var List = new Array()
		List=ExpressionList(List)
        return List
    }
    else
        return new Array()
}

function ExpressionList(List)
{
	if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == PlusMinusOperator)
	{
        var value = Expression()
        List=List.concat(value)
        List=ExpressionListRestOptional(List)
        return List
    }
    else if(NextToken.Type == LeftSquareBracket)
    {
        var cells = GetCellsFromRange(CellRangeSpecifier())
        List=List.concat(cells)
        List=ExpressionListRestOptional(List)
        return List
    }
    else
        alert("Parse Error")
}

function ExpressionListRestOptional(List)
{
    if(NextToken.Type == Comma)
    {
        Advance()
        List=ExpressionList(List)
    }
    return List
}

function ExpressionOptional()
{
    if(NextToken.Type == Identifier || NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == PlusMinusOperator)
        return Expression()
}

function Expression()
{
    if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == PlusMinusOperator)
    {
            var value = PlusMinusExpression()
            value=ExpressionRestOptional(value)
            return value
    }
    else
        alert("Parse Error")
}

function ExpressionRestOptional(Operand)
{
    if(NextToken.Type == ConcatinationOperator)
    {
            Advance()
            Operand += Expression()
            return Operand
    }
    return Operand
}

function PlusMinusExpression()
{
    if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == PlusMinusOperator)
    {
        var value = Term()
        value = PlusMinusExpressionRestOptional(value)
        return value
    }
    else
        alert("Parse Error")
}

function PlusMinusExpressionRestOptional(Operand)
{
    if(NextToken.Type == PlusMinusOperator)
    {
        Advance()
        if(CurrentToken.Lexeme == "+")
            return parseFloat(Operand) + parseFloat(PlusMinusExpression())
        else if(CurrentToken.Lexeme == "-")
            return Operand - PlusMinusExpression()
    }
    return Operand
}

function Term()
{
    if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == PlusMinusOperator)
    {
        var value = PowerExpression()
        value = TermRestOptional(value)
        return value
    }
    else
		alert("Parse Error")
}

function TermRestOptional(Operand)
{
    if(NextToken.Type == MultiplyDivideOperator)
    {
        Advance()
        if(CurrentToken.Lexeme == "*")
            return Operand * Term()
        else if(CurrentToken.Lexeme == "/")
        {
            var Operand2 = Term()
            if(Operand2 == 0)
                return 0
            else
                return Operand / Operand2
        }
    }
    return Operand
}

function PowerExpression()
{
    if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier || NextToken.Type == PlusMinusOperator)
    {
		var value = Factor()
		var value = PowerExpressionRestOptional(value)
		return value
	}
    else
        alert("Parse Error")
}

function PowerExpressionRestOptional(Operand)
{
    if(NextToken.Type == PowerOperator)
    {
            Advance()
            return Math.pow(Operand, PowerExpression())
    }
    return Operand
}

function Factor()
{
	if(NextToken.Type == LeftRoundBracket || NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword || NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral || NextToken.Type == Identifier)
            return PrimaryExpression()
    else if(NextToken.Type == PlusMinusOperator)
    {
		Advance()
		if(CurrentToken.Lexeme == "+")
			return PrimaryExpression()
		else
			return -PrimaryExpression()
    }
    else
        alert("Parse Error")
}

function CellRangeSpecifier()
{
    var cRange = new CellRange()
    if(NextToken.Type == LeftSquareBracket)
    {
        Advance()
        cRange.StartCell = CellReference()
        Match(Colon)
        cRange.EndCell = CellReference()
        Match(RightSquareBracket)
    }
    return cRange
}

function CellReference()
{
    var Row
    var Column
    if(NextToken.Type == RowKeyword)
    {
        Row = RowReference()
        Column = ColumnReferenceOptional()
    }
    else if(NextToken.Type == ColumnKeyword)
    {
        Row = CurrentCell.Row
        Column = ColumnReference()
    }
    else
        alert("Parse Error")
    var c = new Cell(Row, Column)
    c.Value = GetCellValue(Row, Column)
   // alert(Row+","+Column)
    return c
}

function RowReference()
{
    if(NextToken.Type == RowKeyword)
    {
        Advance()
        return Index("R")
    }
    else
        alert("Parse Error")
}

function ColumnReferenceOptional()
{
    if(NextToken.Type == ColumnKeyword)
        return ColumnReference()
    else
        return CurrentCell.Column
}

function ColumnReference()
{
    if(NextToken.Type == ColumnKeyword)
    {
        Advance()
        return Index("C")
    }
    else
        alert("Parse Error")
}

function Index(ReferenceType)
{
    if(NextToken.Type == IntegerLiteral)
    {
        Advance()
        return CurrentToken.Lexeme
    }
    else if(NextToken.Type == LeftSquareBracket)
    {
        Advance()
        if(ReferenceType == "C" && NextToken.Type == Identifier)
        {
            Match(Identifier)
			Match(RightSquareBracket)
            return GetColumnNumber(CurrentToken.Lexeme)
        }
        else
        {
            var value = Expression()
            if(ReferenceType == "R")
                value = parseInt(value) + parseInt(CurrentCell.Row)
            else if(ReferenceType == "C")
                value = parseInt(value) + parseInt(CurrentCell.Column)
			Match(RightSquareBracket)
            return value
        }
    }
    else
        alert("Parse Error")
}

function PrimaryExpression()
{
    if(NextToken.Type == RowKeyword || NextToken.Type == ColumnKeyword)
            return CellReference().Value
	else if(NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral || NextToken.Type == StringLiteral)
            return Literal()
    else if(NextToken.Type == Identifier)
    {
        Advance()
        var FunctionName = CurrentToken.Lexeme
        Match(LeftRoundBracket)
        var value = ExecuteFunction(FunctionName, ExpressionListOptional())
        Match(RightRoundBracket)
        return value
    }
    else if(NextToken.Type == LeftRoundBracket)
    {
        Advance()
        var value = Expression()
        Match(RightRoundBracket)
        return value
    }
    else
        alert("Parse Error")
}

function Literal()
{
	if(NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral)
		return NumericLiteral()
    else if(NextToken.Type == StringLiteral)
    {
        Advance()
        return CurrentToken.Lexeme
    }
    else
		alert("Parse Error")
}

function NumericLiteral()
{
	if(NextToken.Type == IntegerLiteral || NextToken.Type == FloatLiteral)
	{
	    Advance()
        return CurrentToken.Lexeme
    }
    else
        alert("Parse Error")
}

function ExecuteFunction(FunctionName, ParameterList)
{
    switch(FunctionName)
    {
        case "SUM":
            return Sum(ParameterList)
        case "ROUND":
            return Round(parseFloat(ParameterList[0]), parseInt(ParameterList[1]))
        case "MIN":
            if(parseFloat(ParameterList[0]) >= parseFloat(ParameterList[1]))
                return ParameterList[1]
            else
                return ParameterList[0]
        case "MAX":			 
            if(parseFloat(ParameterList[0]) >= parseFloat(ParameterList[1]))
                return ParameterList[0]
            else
                return ParameterList[1]                
        case "COLUMN":
            return CurrentCell.Column
        case "IFNOTZERO":
            if(parseFloat(ParameterList[0]) == 0)
                return 0
            else
                return 1
        default:
			alert(FunctionName)
            return 0
    }
    return ParameterList[0]
}

function Round(Number, Digits)
{
	var factor = Math.pow(10,Digits)
	return Math.round(Number*factor)/factor
}

function Sum(ParameterList)
{
    var Sum2 = 0
    var i
    for(i=0;i<ParameterList.length;i++)
		Sum2+=parseFloat(ParameterList[i])
    return Sum2
}

function GetCellsFromRange(Range)
{
	var RowStart=Range.StartCell.Row
	var RowEnd=Range.EndCell.Row
	var ColumnStart=Range.StartCell.Column
	var ColumnEnd=Range.EndCell.Column
	var temp
	if(RowStart=="")
		RowStart=0
	else
		RowStart = parseInt(RowStart)
	if(RowEnd=="")
		RowEnd=0
	else
		RowEnd = parseInt(RowEnd)
	if(RowStart>RowEnd)
	{
		temp=RowEnd
		RowEnd=RowStart
		RowStart=temp
	}
	if(ColumnStart>ColumnEnd)
	{
		temp=ColumnEnd
		ColumnEnd=ColumnStart
		ColumnStart=ColumnEnd
	}
	var RangeSize = Math.abs((RowEnd - RowStart + 1)*(ColumnEnd - ColumnStart + 1))
	var cells = new Array(RangeSize)
	var x=0
    for(var i = RowStart; i<=RowEnd; i++)
        for(var j = ColumnStart; j<=ColumnEnd; j++)
            cells[x++]=GetCellValue(i,j)
    return cells
}

function GetCellValue(Row, Column)
{
	var cell = document.getElementById(GetID(Row, Column))

	var LastExpr = Expr
	var LastNextToken = NextToken
	var LastCurrentToken = CurrentToken
	var LastCurrentPosition = CurrentPosition

    Expr=cell.getAttribute("Expr")
	if(Expr!=null && cell.getAttribute("value") == "X")
		value=EvaluateCell(Row, Column)
	else
		value=cell.getAttribute("value")
		
	Expr = LastExpr
	NextToken = LastNextToken
	CurrentToken = LastCurrentToken
	CurrentPosition = LastCurrentPosition
	if(value=="") 
		return 0
	else
		return value
}

function GetColumnNumber(ColumnName)
{
	if(ColumnName=="ID")
		return 13
	else
		return 0
}

function GetID(Row, Column)
{
	return "bgTable_"+ Row + "_" + Column
}

//Added by Syed Afaq Ali - win-afaq on August 22, 2005
function GetRowID(Row)
{
	return "bgTable_"+ Row
}

function IsNumeric(passedVal)
{

var ValidChars = "0123456789.()-";
var IsNumber=true;
var Char;
	if(passedVal == "")
		return false;
	for (i = 0; i < passedVal.length && IsNumber == true; i++)
	{
		Char = passedVal.charAt(i);
		if (ValidChars.indexOf(Char) == -1)
			IsNumber = false;
	}
	return IsNumber;
}

