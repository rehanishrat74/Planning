<%@ Control Language="vb" AutoEventWireup="false" Codefile="CtlDate.ascx.vb" Inherits="CtlDate"%>

<script language=javascript >
function ValidateDate(Doc)
{
var Day,Month,Year;
var Valid = true;

Day = document.getElementById(Doc + "_" + 'DDLDate').value
Month = document.getElementById(Doc + "_" + 'DDLMonth').value
Year = document.getElementById(Doc + "_" + 'DDLYear').value

// Leap Year Checking
if(Month == 2)
{
	if (Day == 29 && Year % 4 != 0)
	{
			Valid = false;
	}
	
	if (Day > 29)
	{
		Valid = false;
	}
}

if (Day > 30)
{
	if (Month != 1 && Month != 3 && Month != 5 && Month != 7 && Month != 8 && Month != 10 && Month != 12)
	{
		Valid = false;
	}
}

if (Valid == false)
{
	alert("Please Enter Valid Date.")
	//MultilangualAlert("jsMsg_InvalidDate");
	document.getElementById(Doc + "_" + 'DDLDate').focus();
}

}

</script>
<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
	<TR>
		<TD style="WIDTH: 51px"><asp:dropdownlist class="TableBody" id="DDLDate" runat="server">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
				<asp:ListItem Value="8">8</asp:ListItem>
				<asp:ListItem Value="9">9</asp:ListItem>
				<asp:ListItem Value="10">10</asp:ListItem>
				<asp:ListItem Value="11">11</asp:ListItem>
				<asp:ListItem Value="12">12</asp:ListItem>
				<asp:ListItem Value="13">13</asp:ListItem>
				<asp:ListItem Value="14">14</asp:ListItem>
				<asp:ListItem Value="15">15</asp:ListItem>
				<asp:ListItem Value="16">16</asp:ListItem>
				<asp:ListItem Value="17">17</asp:ListItem>
				<asp:ListItem Value="18">18</asp:ListItem>
				<asp:ListItem Value="19">19</asp:ListItem>
				<asp:ListItem Value="20">20</asp:ListItem>
				<asp:ListItem Value="21">21</asp:ListItem>
				<asp:ListItem Value="22">22</asp:ListItem>
				<asp:ListItem Value="23">23</asp:ListItem>
				<asp:ListItem Value="24">24</asp:ListItem>
				<asp:ListItem Value="25">25</asp:ListItem>
				<asp:ListItem Value="26">26</asp:ListItem>
				<asp:ListItem Value="27">27</asp:ListItem>
				<asp:ListItem Value="28">28</asp:ListItem>
				<asp:ListItem Value="29">29</asp:ListItem>
				<asp:ListItem Value="30">30</asp:ListItem>
				<asp:ListItem Value="31">31</asp:ListItem>
			</asp:dropdownlist>-</TD>
		<TD style="WIDTH: 58px"><asp:dropdownlist id="DDLMonth" class="TableBody" runat="server" Width="48px">
				<asp:ListItem Value="1">Jan</asp:ListItem>
				<asp:ListItem Value="2">Feb</asp:ListItem>
				<asp:ListItem Value="3">Mar</asp:ListItem>
				<asp:ListItem Value="4">Apr</asp:ListItem>
				<asp:ListItem Value="5">May</asp:ListItem>
				<asp:ListItem Value="6">Jun</asp:ListItem>
				<asp:ListItem Value="7">Jul</asp:ListItem>
				<asp:ListItem Value="8">Aug</asp:ListItem>
				<asp:ListItem Value="9">Sep</asp:ListItem>
				<asp:ListItem Value="10">Oct</asp:ListItem>
				<asp:ListItem Value="11">Nov</asp:ListItem>
				<asp:ListItem Value="12">Dec</asp:ListItem>
			</asp:dropdownlist>-</TD>
		<TD><asp:dropdownlist class="TableBody" id="DDLYear" runat="server"></asp:dropdownlist></TD>
	</TR>
</TABLE>
