<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterAuthorization.aspx.vb" Inherits="WebApp_frmMasterAuthorization" title="กำหนดสิทธิ์การใช้งาน" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0"  class="SearchBody">
        <tr>
            <td colspan="4" align="center"  ><br /><br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="60%" AllowPaging="true" AllowSorting="true"  >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField HeaderText="ลำดับ" DataField="no" >
                            <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            <ItemStyle HorizontalAlign="Center" Width="30px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="User Type" DataField="user_type_name" >
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="สิทธิ์การใช้งาน" >
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                            <ItemTemplate >
                                <asp:LinkButton ID="likAuth" runat="server" Text="สิทธิ์การใช้งาน" CommandArgument="<%# Bind('user_type_code') %>" CommandName="AuthList" ></asp:LinkButton>                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>                           
            <br /></td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
    
    <asp:Panel ID="Panel1" runat="server" Width="900px" >
        <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
            style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
            <tr class="popHead">
                <td align="left" colspan="2" >
                    <asp:Label ID="lblHeader" runat="server" Text="สิทธิ์การใช้งานสำหรับ " ></asp:Label>
                </td>
                <td align="right" >
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />
                    <asp:TextBox ID="txtUserType" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td colspan="2" align="left">เมนูที่ไม่มีสิทธิ์</td>
                <td align="left">เมนูที่มีสิทธิ์</td>
            </tr>
            <tr>
                <td width="47%" >
                    <div style="overflow:scroll;height:400px"  >
                        <asp:GridView ID="gvNoSelect" runat="server" AutoGenerateColumns="False" 
                        AllowSorting="true" CssClass="GridViewStyle" 
                        Width="100%" >
                            <RowStyle CssClass="RowStyle" />
                            <Columns> 
                                <asp:TemplateField ShowHeader="false" >
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkH" runat="server" OnCheckedChanged="chkH_OnCheckedChanged" AutoPostBack="true" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Module" SortExpression="module_name" DataField="module_name" >
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Menu" SortExpression="menu_name" DataField="menu_name" >
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="module_id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>
                            </Columns>
                            <PagerStyle CssClass="PagerStyle" />
                            <PagerSettings Visible="false" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </div>
                </td>
                <td width="6%" align="center" >
                    <asp:Button ID="btnSelect" runat="server" Text=">" Width="40px" /><br /><br />
                    <asp:Button ID="btnNoSelect" runat="server" Text="<" Width="40px"  />
                </td>
                <td width="47%">
                    <div style="overflow:scroll;height:400px"  >
                        <asp:GridView ID="gvSelected" runat="server" AutoGenerateColumns="False" 
                        AllowSorting="true" CssClass="GridViewStyle" 
                        Width="100%" >
                            <RowStyle CssClass="RowStyle" />
                            <Columns> 
                                <asp:TemplateField ShowHeader="false" >
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkH" runat="server" OnCheckedChanged="chkH_OnCheckedChanged" AutoPostBack="true" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Module" SortExpression="module_name" DataField="module_name" >
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle Width="150px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Menu" SortExpression="menu_name" DataField="menu_name" >
                                    <HeaderStyle Width="200px" HorizontalAlign="Center" />
                                    <ItemStyle Width="200px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="module_id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>
                                <asp:BoundField DataField="menu_id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>
                                <%--<asp:BoundField DataField="id" >
                                    <ControlStyle CssClass="zHidden" />
                                    <FooterStyle CssClass="zHidden" />
                                    <HeaderStyle CssClass="zHidden" />
                                    <ItemStyle CssClass="zHidden" />
                                </asp:BoundField>--%>
                            </Columns>
                            <PagerStyle CssClass="PagerStyle" />
                            <PagerSettings Visible="false" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <AlternatingRowStyle CssClass="AltRowStyle" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
            <tr>
                <td colspan="3">
                    <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr><td colspan="3">&nbsp;</td></tr>
        </table>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" DropShadow="true">
    </cc1:ModalPopupExtender>
</asp:Content>

