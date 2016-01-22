<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmGroupPolicySearch.aspx.vb" Inherits="WebApp_frmGroupPolicySearch" title="ค้นหาข้อมูลบริษัทผู้เอาประกัน(Policy Search)" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register src="../UserControls/ctlButton.ascx" tagname="ctlButton" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" valign="middle" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td align="center" >
                            <asp:Panel ID="Panel1" Width="95%" runat="server" DefaultButton="btnSearch"  >
                            
                             <div class="mh">
				<div class="wrapFrameContent blue" id="line_actived">
					<table width="60%" border="0" cellpadding="0" cellspacing="0" align="center" >
                    <tr>
                      <td colspan="6">&nbsp;</td>
                    </tr>
                    <tr >
                      <td width="18%" height="48" align="right"><asp:Label ID="lblGroupCode" runat="server" Text="รหัสกลุ่มบริษัท :&lt;br /&gt;(Group Code)" ></asp:Label></td>
                      <td width="1%" align="left">&nbsp;</td>
                      <td width="26%" align="left"><uc1:txtAutoComplete ID="txtGroupCode" runat="server" 
                              Width="150px" /></td>
                      <td width="20%" align="right"><asp:Label ID="lblPolicyNo" runat="server" Text="เลขที่กรมธรรม์ :&lt;br /&gt;(Policy No)" ></asp:Label></td>
                      <td width="1%" align="left">&nbsp;</td>
                      <td width="34%" align="left"><uc1:txtAutoComplete ID="txtPolicyNo" runat="server" 
                              Width="150px" TextKey="TextInt" /></td>
                      </tr>
                    <tr >
                      <td height="43" align="right"><asp:Label ID="lblAccountCode" runat="server" Text="รหัสบริษัท :&lt;br /&gt;(Account Code)" ></asp:Label></td>
                      <td align="left" >&nbsp;</td>
                      <td align="left" ><uc1:txtAutoComplete ID="txtAccountCode" runat="server" 
                              Width="150px" /></td>
                      <td align="right" ><asp:Label ID="lblAccountName" runat="server" Text="ชื่อบริษัท :&lt;br /&gt;(Account Name)" ></asp:Label></td>
                      <td align="left" >&nbsp;</td>
                      <td align="left" ><uc1:txtAutoComplete ID="txtAccountName" runat="server" 
                              Width="150px" /></td>
                      </tr>
                    <tr style="height:35px" >
                      <td colspan="6" align="center" height="5"></td>
                    </tr>
                    <tr style="height:35px" >
                      <td colspan="6" align="center"><asp:ImageButton runat="server" ID="btnSearch" Height="30px" ImageUrl="~/Images/ButtonSearch.png" />                      
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:ImageButton runat="server" ID="btnClear" Height="30px" ImageUrl="~/Images/ButtonCancel.png" /></td>
                    </tr>
                  </table>
			  </div>
			</div>
                              </asp:Panel>                            
                        </td>
                    </tr>
                </table>
            </td>
      </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="center" class="CssSubHeadPink" >
                <asp:Label ID="lblDisplayData" runat="server" Text="....แสดงข้อมูล....<br />Search Result" Visible="false" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="left">
                <uc2:PageControl ID="pc1" runat="server" Visible="false" />
                <asp:Button ID="btnQuery" runat="server" Text="Query" Visible="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                AllowPaging="true" AllowSorting="true" CssClass="GridViewStyle" 
                Width="100%" PageSize="20" >
                    <RowStyle CssClass="RowStyle" />
                    <Columns> 
                        <asp:BoundField HeaderText="ลำดับ(No)" DataField="no" >
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="รหัสกลุ่มบริษัท<br />(Group Code)" SortExpression="grp_code" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkGroupCode" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('grp_code') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="เลขที่กรมธรรม์<br />(Policy No)" SortExpression="pol_no" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkPolicyNo" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('pol_no') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รหัสบริษัท<br />(Account Code)" SortExpression="account_code" >
                            <HeaderStyle Width="120px" HorizontalAlign="Center" />
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkAccountCode" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('account_code') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อบริษัท<br />(Account Name)" SortExpression="account_name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkAccountName" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('account_name') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่มีผลบังคับ<br />(Effective Date)" SortExpression="effect_date"  >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkEfDate" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('effect_date') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="วันที่สิ้นผลบังคับ<br />(Expiry Date)" SortExpression="expire_date" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkEpDate" OnClick="GetAccountDetail" runat="server" Text="<%# Bind('expire_date') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
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
</asp:Content>

