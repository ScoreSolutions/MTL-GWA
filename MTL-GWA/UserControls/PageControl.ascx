<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PageControl.ascx.vb" Inherits="UserControls_PageControl" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" id="TABLE1" style="background-color: #FFCCFF">
    <tr>
        <td style="padding-top:3px; padding-bottom:3px; width:300px">
            <asp:LinkButton ID="lnbBack" runat="server" >[<]</asp:LinkButton>
            Page
            <asp:DropDownList ID="cmbPage" runat="server" CssClass="zComboBox" Width="50px" AutoPostBack="True" >
            </asp:DropDownList>
            From
            <asp:Label ID="lblTotalPage" runat="server"></asp:Label>
            Page(s)
            <asp:LinkButton ID="lnbNext" runat="server" >[>]</asp:LinkButton>
        </td>
        <td style="padding-top:3px; padding-bottom:3px; padding-right:5px" align="right">
            <asp:Label ID="lblSummary" runat="server"></asp:Label>
            <asp:TextBox ID="txtPageIndex" runat="server" Visible="false" />
        </td>
    </tr>
</table>
