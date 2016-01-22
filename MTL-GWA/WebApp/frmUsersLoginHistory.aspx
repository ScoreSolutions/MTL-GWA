<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmUsersLoginHistory.aspx.vb" Inherits="WebApp_frmUsersLoginHistory" title="ประวัติการเข้าใช้งาน" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="SearchBody" align="center" valign="top" height="250" >
                            <table width="60%" border="0" cellpadding="0" cellspacing="0" align="center" >
                                <tr><td height="38" colspan="3">&nbsp;</td></tr>
                                <tr>
                                    <td height="44" align="right"><asp:Label ID="lblUserID" runat="server" Text="ชื่อเข้าระบบ :<br />(User ID)" /></td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">
                                        <asp:Label ID="lblUserID1" runat="server" ></asp:Label>
                                        <uc1:txtAutoComplete ID="txtUserID" runat="server" Width="250px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr >
                                    <td width="30%" align="right"><asp:Label ID="lblSearchDate" runat="server" Text="วันที่เข้าใช้งาน :<br />(Login Date) " ></asp:Label></td>
                                    <td width="1%" align="left">&nbsp;</td>
                                    <td width="69%" align="left">
                                        <uc2:txtDate ID="txtDateFrom" runat="server" AutoPosBack="true" />&nbsp;&nbsp;ถึง&nbsp;&nbsp;&nbsp;
                                        <uc2:txtDate ID="txtDateTo" runat="server" />                                    </td>
                                </tr>
                                <tr >
                                    <td height="10" colspan="7" align="center"></td>
                                </tr>
                                <tr style="height:35px" >
                                  <td colspan="7" align="center"><asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" Height="30px" />                                  
                                    &nbsp;&nbsp;
                                    <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" /></td>
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
            <td colspan="4" class="CssSubHeadPink" ><asp:Label ID="lblDisplayData" runat="server" Text="แสดงข้อมูล <br /> Search Result" Visible="false" ></asp:Label> </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" align="left"  >
                <uc3:PageControl ID="pcTop" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="true" AllowSorting="true" CssClass="GridViewStyle" Width="100%"  >
                    <RowStyle CssClass="RowStyle" />
                    <Columns> 
                        <asp:BoundField HeaderText="ลำดับ <br />(No)" DataField="no" HtmlEncode="false" >
                            <HeaderStyle Width="10%" HorizontalAlign="Center" />
                            <ItemStyle Width="10%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="ชื่อเข้าระบบ <br />(User ID)" DataField="user_id" SortExpression="user_id"  HtmlEncode="false" >
                            <HeaderStyle Width="30%" HorizontalAlign="Center" />
                            <ItemStyle Width="30%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="วันที่เข้าใช้งาน <br />(Login Date)" DataField="login_date" SortExpression="login_date" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" >
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="เวลาที่เข้าใช้งาน <br />(Login Time)" DataField="login_time" SortExpression="login_time" DataFormatString="{0:hh:mm tt}" HtmlEncode="false">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="เวลาที่ออกจากระบบ <br />(Logout Time)" DataField="logout_time" SortExpression="logout_time" DataFormatString="{0:hh:mm tt}" HtmlEncode="false">
                            <HeaderStyle Width="20%" HorizontalAlign="Center" />
                            <ItemStyle Width="20%" HorizontalAlign="Center" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>  
            </td>
         </tr>
    </table>
</asp:Content>

