<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterUsersSearch.aspx.vb" Inherits="WebApp_frmMasterUsersSearch" title="รายชื่อผู้ใช้ระบบ" %>

<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register src="../UserControls/ctlButton.ascx" tagname="ctlButton" tagprefix="uc4" %>
<%@ Register src="../PageControl/ctlBrokerCode.ascx" tagname="ctlBrokerCode" tagprefix="uc5" %>
<%@ Register src="../PageControl/ctlAccountCode.ascx" tagname="ctlAccountCode" tagprefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td class="SearchBody" align="center"><br /><br />
                            <table width="85%" border="0" cellpadding="0" cellspacing="2" >
                                <tr>
                                    <td width="15%" colspan="2" >&nbsp;ค้นหา</td>
                                    <td width="35%">&nbsp;</td>
                                    <td width="20%" colspan="2">&nbsp;</td>
                                    <td width="30%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="34" align="right"><asp:Label ID="lblUserID" runat="server" Text="User ID : " ></asp:Label></td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtUserID" runat="server" Width="150px" />                                    </td>
                                    <td align="right"><asp:Label ID="lblUserType" runat="server" Text="User Type : " ></asp:Label></td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left"  >
                                        <uc3:cmbComboBox ID="cmbUserType" runat="server" Width="150px" />                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" >Broker Code : </td>
                                    <td align="right" >&nbsp;</td>
                                    <td align="left" ><uc5:ctlBrokerCode ID="ctlBrokerCode1" runat="server" Width="150px" />                                    </td>
                                    <td align="right" >Account Code : </td>
                                    <td align="right" >&nbsp;</td>
                                    <td align="left" >
                                        <uc6:ctlAccountCode ID="ctlAccountCode1" runat="server" Width="150px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="40" align="right"><asp:Label ID="lblUserNameThai" runat="server" Text="User Name(Thai) : " ></asp:Label></td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtUserNameThai" runat="server" Width="150px" />                                    </td>
                                    <td align="right"><asp:Label ID="lblUserNameEng" runat="server" Text="User Name(Eng) : " ></asp:Label></td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left"  >
                                        <uc1:txtAutoComplete ID="txtUserNameEng" runat="server" Width="150px" />                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">&nbsp;</td>
                                </tr>
                                <tr><td colspan="6" align="center"><asp:ImageButton ID="btnSearch" runat="server" Height="30px" ImageUrl="~/Images/ButtonSearch.png" />                                
                                  &nbsp;&nbsp;&nbsp;
                                  <asp:ImageButton ID="btnClear" runat="server" Height="30px" ImageUrl="~/Images/ButtonCancel.png" />                                  
                                  &nbsp;&nbsp;&nbsp;&nbsp;</td></tr>
                                <tr>
                                  <td colspan="6">&nbsp;</td>
                                </tr>
                                <tr>
                                  <td colspan="6">&nbsp;</td>
                                </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tr>
            <td class="CssSubHeadPink" colspan="4" align="center" >
                <asp:Label ID="lblDisplayData" runat="server" Text="แสดงข้อมูล" Visible="false" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="left">
                <uc2:PageControl ID="pc1" runat="server" Visible="false"  />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvUsersList" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="true" AllowSorting="true" PageSize="20"  >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField HeaderText="" DataField="id"  >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ลำดับ" DataField="no" >
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="User ID" SortExpression="user_id" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkUserID" OnClick="UsersList_Click" runat="server" Text="<%# Bind('user_id') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Type" SortExpression="user_type" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkUserType" OnClick="UsersList_Click" runat="server" Text="<%# Bind('user_type') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name(Thai)" SortExpression="user_name_t">
                            <HeaderStyle HorizontalAlign="Center"  />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkUserNameThai" OnClick="UsersList_Click" runat="server" Text="<%# Bind('user_name_t') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name(Eng)" SortExpression="user_name_e">
                            <HeaderStyle HorizontalAlign="Center"  />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkUserNameEng" OnClick="UsersList_Click" runat="server" Text="<%# Bind('user_name_e') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Email" SortExpression="user_email">
                            <HeaderStyle HorizontalAlign="Center" Width="120px"  />
                            <ItemStyle HorizontalAlign="Left" Width="120px"  />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkUserEmail" OnClick="UsersList_Click" runat="server" Text="<%# Bind('user_email') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" ShowHeader="false" >
                            <HeaderStyle HorizontalAlign="Center" Width="50px"  />
                            <ItemStyle HorizontalAlign="Center" Width="50px"  />
                            <ItemTemplate >
                                <asp:ImageButton ID="imgDel" runat="server" ImageUrl="~/Images/closewindows.png" OnClick="DeleteUser_Click" OnClientClick="return confirm('ยืนยันการลบข้อมูล ?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                    <PagerSettings Visible="false" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
</asp:Content>

