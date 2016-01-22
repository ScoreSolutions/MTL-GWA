<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlButton.ascx.vb" Inherits="UserControls_ctlButton" %>
<table border="0" cellpadding="0" cellspacing="0"  >
    <tr runat="server" id="trBtn" >
        <td width="5px" ><img src="../Images/btnL.png" runat="server" alt="" style="cursor:pointer;" /></td>
        <td align="center" id="tS" runat="server" style="background-image:url('../Images/btnM.png');background-repeat:repeat-x;cursor:pointer;"  >
            <asp:LinkButton ID="likLink1" runat="server" Font-Bold="true" ForeColor="White" ></asp:LinkButton>
        </td>
        <td width="5px" ><img src="../Images/btnR.png" runat="server" alt="" style="cursor:pointer;" /></td>
    </tr>    
</table>
