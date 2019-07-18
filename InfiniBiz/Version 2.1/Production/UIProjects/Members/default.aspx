<%@ Page Language="vb" AutoEventWireup="false" Codebehind="default.aspx.vb" Inherits="accounts.infinibiz.Web.MembersMember" %>
<%@ outputcache Location="None" %>
<%@ Register TagPrefix="Include" TagName="ServicesList" Src="\library\components\ServicesList.ascx" %>
<%@ Register TagPrefix="Include" TagName="leftbar" Src="\library\components\IndexLeft.ascx" %>
<%@ Register TagPrefix="Include" TagName="BottomBar" Src="\library\components\BottomBar.ascx" %>
<%@ Register TagPrefix="Include" TagName="topbar" Src="\library\components\IndexHeader.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>Member Home</title>
    <meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
    <meta content="" name="cbwords">
    <meta content="" name="cbcat">
    <meta http-equiv="Content-Language" content="en">
    <meta content="Microsoft FrontPage 6.0" name="GENERATOR">
    <meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
    <meta content="JavaScript" name="vs_defaultClientScript">
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
    <link href="/library/style/style.css" type="text/css" rel="stylesheet">
    <link href="/library/style/AccountscentreCommon.css" type="text/css" rel="stylesheet">
</head>
<body id="htmlContentBody" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		runat="server">
    <form id="Form2" method="post" runat="server">
        <table class="CONTENT" id="layouttable" height="100%" cellSpacing="0" cellPadding="0" width="100%"
				bgcolor="ffffff" border="0">
            <tr id="trTopMain" runat="server">
                <td id="topbar" colspan="2" height="100" runat="server">
                    <include:topbar id="idxTopBar" runat="server"></include:topbar>
                </td>
            </tr>
            <tr>
                <td id="contentarea" valign="top" width="100%" colspan="2" runat="server">
                    <table class="content" id="Memeberpage" bordercolor="yellow" height="100%" cellspacing="0"
                        cellpadding="0" width="100%" border="0">
                        <tr>
                            <td valign="top" width="100%" height="100%">
                                <table border="0" height="100%" class="content" cellpadding="3" cellspacing="3" width="100%">
                                    <tr height="100%">
                                        <td id="tdLeftMain" runat="server" class="objtd" valign="top" align="center" width="180"
                                            rowspan="4">
                                            <include:serviceslist id="ucServicesList" runat="server"></include:serviceslist>
                                        </td>
                                        <td valign="top" class='objtd' height="100%" width="100%">
                                            <div class="scrolldiv" style="height: 100%">
                                                <table id="sNotifications" style="width: 100%; border-collapse: collapse" cellpadding="0"
                                                    width="100%" border="0" runat="server">
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            <table cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <font size="4">
                                                                            <% =_CompanyName %>
                                                                        </font>
                                                                    </td>
                                                                    <td align="right">
                                                                        <asp:ImageButton ID="IShops_btn" runat="server" Visible="False" ImageUrl="../images/ishop.jpg">
                                                                        </asp:ImageButton></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="acc_header_backgrounds" id="Td1" style="height: 20px" runat="server" key="acc_members_default_ttonlineorders">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table class="content" width="100%" border="0">
                                                                <tr>
                                                                    <td width="2">
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 15px">
                                                                        <% Session("CompanyName") = _CompanyName%>
                                                                    </td>
                                                                    <td style="border-top-width: 0px; border-bottom-width: 0px; color: black; border-right-width: 0px"
                                                                        bordercolor="#7baee3" height="15">
                                                                        <asp:LinkButton ID="lnkOrderDetails" runat="server" key="acc_members_default_lkorderdetails"
                                                                            CssClass="LINK-BLUE"></asp:LinkButton></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td style="border-top-width: 0px; border-bottom-width: 0px; color: black; border-right-width: 0px"
                                                                        bordercolor="#7baee3" height="5">
                                                                        <asp:LinkButton ID="lnkInvoiceDetails" runat="server" Visible="False" key="acc_members_default_lkinvoicedetails"
                                                                            CssClass="LINK-BLUE"></asp:LinkButton></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <!--<td style="BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; COLOR: black; BORDER-RIGHT-WIDTH: 0px"
																		borderColor="#7baee3" height="5"><A class="LINK-BLUE" id="A1" href="/Invoice/UpdatePayementInfo.aspx" runat="server"
																			CssClass="LINK-BLUE" key="acc_members_default_aupdateorderpayment"></A></td>-->
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="30">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlDocArchive" Visible="False" Width="600" runat="server">
                                                                <table class="CONTENT" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr class="acc_header_backgrounds" style="height: 20px">
                                                                        <td id="Td2" runat="server" key="acc_members_default_ttdocarchive">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Panel ID="pnlAnnualACFiled" Visible="False" runat="server" Width="600">
                                                                                <table class="CONTENT" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr style="height: 20px">
                                                                                        <td id="Td3" runat="server" key="acc_members_default_ttannualaccounts">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DataGrid ID="dgrdAnnualACFiled" CssClass="CONTENT" runat="server" Width="50%"
                                                                                                AutoGenerateColumns="False">
                                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="AliceBlue"></HeaderStyle>
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="FileYear" HeaderText="Financial Year"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn Text="Download" HeaderText="Document" CommandName="Select"></asp:ButtonColumn>
                                                                                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                            <br>
                                                                            <asp:Panel ID="pnlCTReturnFiled" Visible="False" runat="server" Width="600">
                                                                                <table class="CONTENT" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr style="height: 20px">
                                                                                        <td id="Td4" runat="server" key="acc_members_default_ttcompanytax">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DataGrid ID="dgrdCTReturnFiled" CssClass="CONTENT" runat="server" Width="50%"
                                                                                                AutoGenerateColumns="False">
                                                                                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="AliceBlue"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="FileYear" HeaderText="Financial Year"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn Text="Download" HeaderText="Document" CommandName="Select"></asp:ButtonColumn>
                                                                                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                            <br>
                                                                            <asp:Panel ID="pnlDCAccountsFiled" Visible="False" runat="server" Width="600">
                                                                                <table class="CONTENT" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr style="height: 20px">
                                                                                        <td id="Td5" style="background-color: #fbfbfb" runat="server" key="acc_members_default_ttdormantcompanyaccounts">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DataGrid ID="dgrdDCAccountsFiled" CssClass="CONTENT" runat="server" Width="50%"
                                                                                                AutoGenerateColumns="False">
                                                                                                <HeaderStyle HorizontalAlign="Center" Font-Bold="True" BackColor="AliceBlue"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                                                <Columns>
                                                                                                    <asp:BoundColumn DataField="FileYear" HeaderText="Financial Year"></asp:BoundColumn>
                                                                                                    <asp:ButtonColumn Text="Download" HeaderText="Document" CommandName="Select"></asp:ButtonColumn>
                                                                                                    <asp:BoundColumn Visible="False" DataField="ID"></asp:BoundColumn>
                                                                                                </Columns>
                                                                                            </asp:DataGrid></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                    <tr style="padding-top: 20px" valign="top">
                                                        <td valign="top" colspan="2">
                                                            <asp:Panel ID="pnlAnnualAccountsStatus" runat="server" Width="100%">
                                                                <table class="content" cellspacing="0" cellpadding="0" width="100%">
                                                                    <tr>
                                                                        <td class="acc_header_backgrounds" id="Td9" valign="middle" colspan="9" height="20"
                                                                            runat="server" key="acc_members_default_ttannualaccountsstatus">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="Content" style="color: black" valign="top" colspan="10" height="30">
                                                                            <asp:Label ID="lblincorporationdate" runat="server" key="acc_members_default_lblincorporationdate"></asp:Label>
                                                                            <asp:Literal ID="litIncDate" runat="server" Text=""></asp:Literal></STRONG>
                                                                            <asp:Label ID="lblaccreferencedate" runat="server" key="acc_members_default_lblaccreferencedate"></asp:Label><strong>
                                                                                <asp:Literal ID="litARD" runat="server" Text=""></asp:Literal></strong><br>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="color: black" width="100%" colspan="9">
                                                                            <asp:Label ID="lblThereIsNoRecord" runat="server" key="acc_members_default_lblthereisnorecord"></asp:Label>
                                                                            <asp:DataGrid ID="dgridAnnualAccounts" runat="server" CssClass="content" AutoGenerateColumns="False"
                                                                                CellSpacing="0" CellPadding="0" ShowHeader="True" BorderWidth="0" Width="100%"
                                                                                OnItemDataBound="dgridAnnualAccounts_ItemDataBound">
                                                                                <Columns>
                                                                                    <asp:TemplateColumn>
                                                                                        <HeaderTemplate>
                                                                                            <table cellspacing="0" cellpadding="0" class="content" width="100%">
                                                                                                <tr>
                                                                                                    <td width="15%" height="26" valign="middle" bgcolor="#fbfbfb" runat="server" key="acc_members_default_ttfinancialyear"
                                                                                                        id="Td10">
                                                                                                    </td>
                                                                                                    <td width="15%" colspan="2" valign="middle" bgcolor="#fbfbfb" runat="server" key="acc_members_default_ttARDdate"
                                                                                                        id="Td11">
                                                                                                    </td>
                                                                                                    <td width="25%" colspan="4" valign="middle" bgcolor="#fbfbfb" runat="server" key="acc_members_default_ttsubmissiondate"
                                                                                                        id="Td12">
                                                                                                    </td>
                                                                                                    <td width="15%" valign="middle" bgcolor="#fbfbfb" runat="server" key="acc_members_default_ttsubmittedon"
                                                                                                        id="Td13">
                                                                                                    </td>
                                                                                                    <td width="30%" valign="middle" bgcolor="#fbfbfb" runat="server" key="acc_members_default_ttaccountsstatus"
                                                                                                        id="Td14">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                </strong></table>
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <table cellpadding="0" cellspacing="0" class="content" width="100%">
                                                                                                <tr>
                                                                                                    <td width="15%" height="13" valign="top">
                                                                                                        <%# Databinder.Eval(Container.DataItem, "Year") %>
                                                                                                    </td>
                                                                                                    <td width="15%" colspan="2" valign="top">
                                                                                                        <%# Databinder.Eval(Container.DataItem, "ARD", "{0:d}") %>
                                                                                                    </td>
                                                                                                    <td width="25%" colspan="4" valign="top">
                                                                                                        <%# Databinder.Eval(Container.DataItem, "DueDate","{0:d}") %>
                                                                                                    </td>
                                                                                                    <td width="15%" valign="top">
                                                                                                        <%# Databinder.Eval(Container.DataItem, "SubmissionDate","{0:d}") %>
                                                                                                    </td>
                                                                                                    <td width="30%" valign="top">
                                                                                                        <strong>
                                                                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Databinder.Eval(Container.DataItem, "Status")%>'>
                                                                                                            </asp:Label>
                                                                                                        </strong>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateColumn>
                                                                                </Columns>
                                                                            </asp:DataGrid></td>
                                                                    </tr>
                                                                </table>
                                                                </FONT></asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!--CODE COMMENT THREE-->
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td id="rightbar" width="0%" runat="server">
                </td>
            </tr>
            <tr id="trBottomMain" runat="server">
                <td id="bottombar" colspan="2" height="29" runat="server">
                    <include:bottombar id="Bottonbar1" runat="server"></include:bottombar>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
