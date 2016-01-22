<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlTab.ascx.vb" Inherits="UserControls_ctlTab" %>
<table border="0" cellpadding="0" cellspacing="0" id="tbName" runat="server"  >
    <tr>
        <td width="5px" ><img src="" runat="server" id="tL" alt="" /></td>
        <td align="center" id="tS" runat="server"  >
            <asp:LinkButton ID="libLink1" runat="server" Font-Bold="true"  ></asp:LinkButton>
        </td>
        <td width="5px" ><img src="" runat="server" id="tR" alt="" /></td>
    </tr>    
</table>
<asp:HiddenField ID="_ActiveTab" runat="server" Value="false" />
