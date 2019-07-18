<%@ Register TagPrefix="cc1" Namespace="InfiniLogic.AccountsCentre.BLL" Assembly="InfiniLogic.AccountsCentre.BLL" %>
<%@ Control Language="vb" AutoEventWireup="false" Codebehind="ServicesList.ascx.vb" Inherits="accounts.infinibiz.Web.ServicesList" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>

<link href="https://reseller.infinibiz.com/App_Themes/IBiz/IBIZ.css" rel="stylesheet" type="text/css">
<table style="height: 100%;" class="IBIZ_Penal" cellspacing="0" cellpadding="0">
    <tr>
        <td class="IBIZ_TreeView_Header">
            Available Services</td>
    </tr>
    <tr valign="top">
        <td>
            <div class="IBIZ_TreeView_Content" style="width: 200px">
                <table style="width: 100%; padding-top: 10px;" cellpadding="0" cellspacing="0">
                    <tr>
                        <td id="DivTreeView" runat="server" valign="top"></td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
