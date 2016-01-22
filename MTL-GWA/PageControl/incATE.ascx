<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incATE.ascx.vb" Inherits="PageControl_incATE" %>

<%@ Register Src="../UserControls/txtAutoComplete.ascx" TagName="txtBox" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Panel ID="Panel1" runat="server" Width="650">
    <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
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
                <b><asp:Label ID="lblTitle" runat="server" Text="ค่ารักษาพยาบาลเนื่องจากอุบัติเหตุ" /></b>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table border="0"  cellpadding="0" cellspacing="0" width="95%" align="center" style="border-style: solid; border-width: 1px;">
                    <tr><td colspan="2">&nbsp;</td></tr>
                    <tr>
                        <td width="80%" align="left" >- ค่าชดเชยการรักษาพยาบาลสูงสุดต่ออุบัติเหตุแต่ละครั้ง</td>
                        <td width="20%" align="left" >200,000 บาท</td>
                    </tr>
                    <tr><td colspan="2">&nbsp;</td></tr>
                </table>
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
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>