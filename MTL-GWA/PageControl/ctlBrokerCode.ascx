<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlBrokerCode.ascx.vb" Inherits="PageControl_ctlBrokerCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<uc1:txtAutoComplete ID="txtCode" runat="server" TextAlign="AlignCenter" Width="60px" AutoPosBack="true" />
<asp:ImageButton ID="imgShowPop" runat="server" ImageUrl="~/Images/search.png" />
<uc1:txtAutoComplete ID="txtName" runat="server" TextType="TextView" Width="300px" />

<asp:Panel ID="Panel1" runat="server" Width="650">
    <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
        <tr class="popHead">
            <td align="left" >
                <asp:Label ID="lblHeader" runat="server" Text="ค้นหา Broker" ></asp:Label>
            </td>
            <td align="right" >
                <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Panel ID="pnlSearch" runat="server" Width="90%" DefaultButton="btnSearch" >
                    <table border="0" cellpadding="0" cellspacing="0" width="90%" align="center" >
                        <tr><td colspan="2">&nbsp</td></tr>
                        <tr>
                            <td width="30%" align="right" >Broker Name :&nbsp;</td>
                            <td width="70%" align="left" >
                                <uc1:txtAutoComplete ID="txtSearchBrName" runat="server" Width="300px" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td align="left">
                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" Height="30px" />
                            </td>
                        </tr>
                        <tr><td colspan="2">&nbsp</td></tr>
                    </table>
                </asp:Panel>
                <cc1:RoundedCornersExtender ID="RoundedCornersExtender1" TargetControlID="pnlSearch" Corners="All"
                 runat="server" BorderColor="#FFCCFF" >
                </cc1:RoundedCornersExtender>
            </td>
        </tr>
        <tr><td colspan="2">&nbsp;</td></tr>
        <tr>
            <td colspan="2">
                <uc2:PageControl ID="pc1" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                AllowPaging="true" AllowSorting="true" CssClass="GridViewStyle" 
                Width="100%" PageSize="10" >
                    <RowStyle CssClass="RowStyle" />
                    <Columns> 
                        <asp:BoundField HeaderText="ลำดับ" DataField="no" >
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Broker Code" SortExpression="broker_code" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkBrCode" OnClick="GetBrokerDetail" runat="server" Text="<%# Bind('broker_code') %>" CommandArgument="<%# Bind('broker_code') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Broker Name" SortExpression="broker_name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkBrName" OnClick="GetBrokerDetail" runat="server" Text="<%# Bind('broker_name') %>" CommandArgument="<%# Bind('broker_code') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <PagerSettings Visible="false" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
<cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
    BackgroundCssClass="modalBackground" DropShadow="true">
</cc1:ModalPopupExtender>