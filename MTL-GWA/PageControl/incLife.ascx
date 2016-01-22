<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incLife.ascx.vb" Inherits="PageControl_incLife" %>

<%@ Register Src="../UserControls/txtAutoComplete.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Panel ID="Panel1" runat="server" Width="750px"  >
    <table id="Table1" width="100%"  border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server" valign="top" >
        <tr class="popHead">
            <td align="left" >
                <asp:Label ID="lblHeader" runat="server" Text="รายละเอียดกรมธรรม์ >> ข้อมูลผลประโยชน์ความคุ้มครอง :" ></asp:Label>
            </td>
            <td align="right" >
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <uc1:txtBox ID="txtID" runat="server" Visible="false" Text="0" />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                &nbsp;&nbsp;&nbsp;
                <b><asp:Label ID="lblTitle" runat="server" Text="การประกันชีวิต" /></b>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <div style="width:95%;height:300px;border-style:solid;border-width:1px;overflow:scroll;overflow-x: hidden;">
                    <table border="0"  cellpadding="0" cellspacing="0" width="95%" >
                        <asp:Label ID="lblLifeDesc" runat="server"></asp:Label>
                        <tr><td colspan="2">&nbsp;</td></tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="left" >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                หมายเหตุ : โปรดศึกษารายละเอียดเพิ่มเติมในกรมธรรม์
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Remark : Please learn more details in the policy.</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" align="center" >
                <asp:Button ID="btnClose" runat="server" Text="ปิด" Width="60px" CssClass="CssBtn" />&nbsp;
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
    </table>
</asp:Panel>
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true"  >
</cc1:ModalPopupExtender>