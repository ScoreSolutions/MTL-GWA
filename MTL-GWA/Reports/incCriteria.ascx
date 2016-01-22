<%@ Control Language="VB" AutoEventWireup="false" CodeFile="incCriteria.ascx.vb" Inherits="Reports_incCriteria" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<table width="70%" border="0" cellpadding="0" cellspacing="0" align="center" >
    <tr>
        <td align="center" >
            <table width="100%" border="0" cellpadding="0" cellspacing="0" align="center" >
                <tr >
                    <td align="right" class="style3"><asp:Label ID="lblGroupCode" runat="server" Text="รหัสกลุ่มบริษัท :<br />(Group Code)" ></asp:Label></td>
                  <td align="right">&nbsp;</td>
                    <td height="40" align="left" class="style4">
                      <uc1:txtAutoComplete ID="txtGroupCode" runat="server" Width="100px" IsNotNull="true" />                    </td>
                  <td align="right"><asp:Label ID="lblAccountCode" runat="server" Text="รหัสบริษัท :<br />(Account Code)" ></asp:Label></td>
                    <td align="right">&nbsp;</td>
                    <td align="left">
                        <uc1:txtAutoComplete ID="txtAccountCode" runat="server" Width="60px" IsNotNull="true" />
                        <asp:ImageButton ID="imgShowPop" runat="server" ImageUrl="~/Images/search.png" />
                        <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                        <br />
                        <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
                            BackgroundCssClass="modalBackground" DropShadow="true" >
                        </cc1:ModalPopupExtender>
                        <asp:Panel ID="Panel1" runat="server" Width="700px" >
                            <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" 
                                bgcolor="#ffffff" runat="server">
                                <tr class="popHead">
                                    <td align="left" height="20" >
                                        <asp:Label ID="lblHeader" runat="server" Text="ค้นหาบริษัท" ></asp:Label>
                                    </td>
                                    <td align="right" >
                                        <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
                                    </td>
                                </tr>
                                <tr><td colspan="2">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Panel ID="pnlSearch" runat="server" Width="90%" DefaultButton="btnSearch" >
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center" >
                                            <tr><td colspan="2">&nbsp;</td></tr>
                                                <tr>
                                                    <td width="30%" align="right" >ชื่อบริษัท :&nbsp;<br />(Account Name)&nbsp;</td>
                                                    <td width="70%" align="left" >
                                                        <uc1:txtAutoComplete ID="txtSearchAcName" runat="server" Width="300px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td align="left">
                                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" Height="30px" />
                                                    </td>
                                                </tr>
                                                <tr><td colspan="2">&nbsp;</td></tr>
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
                                        Width="100%" PageSize="5" >
                                            <RowStyle CssClass="RowStyle" />
                                            <Columns> 
                                                <asp:BoundField HeaderText="ลำดับ<br />(No)" DataField="no" HtmlEncode="false" >
                                                    <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="รหัสกลุ่มสมาชิก<br />(Group Code)" SortExpression="grp_code" >
                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkGrpCode" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('grp_code') %>" CommandArgument="<%# Bind('account_code') %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="เลขที่กรมธรรม์<br />(Policy No)" SortExpression="pol_no" >
                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkPolNo" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('pol_no') %>" CommandArgument="<%# Bind('account_code') %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="รหัสบริษัท <br />(Account Code)" SortExpression="account_code" >
                                                    <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkAcCode" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('account_code') %>" CommandArgument="<%# Bind('account_code') %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ชื่อบริษัท <br />(Account Name)" SortExpression="account_name" >
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkAccountName" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('account_name') %>" CommandArgument="<%# Bind('account_code') %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ปีกรมธรรม์<br />(Policy Year)" SortExpression="pol_year" >
                                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkPolYear" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('pol_year') %>" CommandArgument="<%# Bind('account_code') %>" ></asp:LinkButton>
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
                    </td>
                </tr>
                <tr>
                    <td align="right" class="style3"><asp:Label ID="lblPolicyNo" runat="server" Text="เลขที่กรมธรรม์ :<br />(Policy No)" ></asp:Label></td>
                    <td align="right">&nbsp;</td>
                    <td align="left" class="style4">
                        <uc1:txtAutoComplete ID="txtPolicyNo" runat="server" Width="100px" IsNotNull="true"/>
                    </td>
                    <td align="right"><asp:Label ID="lblPolicyYear" runat="server" Text="ปีกรมธรรม์ :<br />(Policy Year)" /></td>
                    <td align="right">&nbsp;</td>
                    <td align="left"><uc1:txtAutoComplete ID="txtPolYear" runat="server" Width="30px" TextKey="TextInt" TextAlign="AlignRight" IsNotNull="true" /></td>
                </tr>

                        
                                     










