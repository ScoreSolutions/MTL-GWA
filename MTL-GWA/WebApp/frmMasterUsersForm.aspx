<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmMasterUsersForm.aspx.vb" Inherits="WebApp_frmMasterUsersForm" title="ข้อมูลผู้ใช้งาน" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="~/UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc4" %>
<%@ Register src="~/UserControls/txtDate.ascx" tagname="txtDate" tagprefix="uc2" %>
<%@ Register src="~/PageControl/ctlBrokerCode.ascx" tagname="ctlBrokerCode" tagprefix="uc5" %>
<%@ Register src="~/PageControl/ctlAccountCode.ascx" tagname="ctlAccountCode" tagprefix="uc6" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="SearchBody" >
        <tr>
            <td width="65%" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td align="center"><br /><br />
                            <table width="100%" border="0" cellpadding="0" cellspacing="2" >
                                <tr>
                                    <td width="20%"><uc1:txtAutoComplete ID="txtID" runat="server" Visible="false" /></td>
                                    <td width="30%">&nbsp;</td>
                                    <td width="20%">&nbsp;</td>
                                    <td width="30%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                      <asp:Label ID="lblUserID" runat="server" Text="User ID : "  ></asp:Label>                                    </td>
                      <td align="left" >
                                        <uc1:txtAutoComplete ID="txtUserID" runat="server" IsNotNull="true" Width="150px" MaxLength="18" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblPassword" runat="server" Text="Password : "  ></asp:Label>                                    </td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtPassword" runat="server" IsNotNull="true" Width="150px" TextMode="Password" MaxLength="18" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="27" align="right">
                                      <asp:Label ID="lblStartDate" runat="server" Text="Start Date : "  ></asp:Label>                                    </td>
                              <td align="left">
                                        <uc2:txtDate ID="txtStartDate" runat="server"  IsNotNull="true" DefaultCurrentDate="true" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblExpireDate" runat="server" Text="Expire Date : "  ></asp:Label>                                    </td>
                                    <td align="left">
                                        <uc2:txtDate ID="txtExpireDate" runat="server" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="27" align="right">
                                      <asp:Label ID="lblPasswordDate" runat="server" Text="Password Date : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc2:txtDate ID="txtPasswordDate" runat="server"  IsNotNull="true" />                                    </td>
                                </tr>
                                <tr><td height="35" colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td height="32" align="right">
                                      <asp:Label ID="lblUserType" runat="server" Text="User Type : "  ></asp:Label>                                    </td>
                                <td align="left" colspan="3">
                                      <uc3:cmbComboBox ID="cmbUserType" runat="server" Width="150px" IsNotNull="false" IsDefaultValue="false" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="26" align="right">
                                      <asp:Label ID="lblBrokerCode" runat="server" Text="Borker Code : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc5:ctlBrokerCode ID="ctlBrokerCode1" runat="server" />
                                        **For Broker                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                      <asp:Label ID="lblAccountCode" runat="server" Text="Account Code : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc6:ctlAccountCode ID="ctlAccountCode1" runat="server" />
                                        **For Member                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td height="28" align="right">
                                      <asp:Label ID="lblUserNameThai" runat="server" Text="User Name (Thai) : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtUserNameThai" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                      <asp:Label ID="lblUserNameEng" runat="server" Text="User Name(English) : " ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtUserNameEng" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                    <asp:Label ID="lblCompanyName" runat="server" Text="Company Name : "  ></asp:Label>                                    </td>
                      <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtCompanyName" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="29" align="right">
                                    <asp:Label ID="lblTel" runat="server" Text="Telephone : "  ></asp:Label>                                    </td>
                              <td align="left">
                                        <uc1:txtAutoComplete ID="txtTel" runat="server" Width="150px" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblUserLevel" runat="server" Text="User Level : "  ></asp:Label>                                    </td>
                                    <td align="left" >
                                      <uc3:cmbComboBox ID="cmbUserLevel" runat="server" Width="132px" IsDefaultValue="false" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                    <asp:Label ID="lblUserEmail" runat="server" Text="User E-Mail : "  ></asp:Label>                                    </td>
                      <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtUserEmail" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                    <asp:Label ID="lblDiscReason" runat="server" Text="Discharge Reason : "  ></asp:Label>                                    </td>
                      <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtDiscReason" runat="server" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" align="right">
                                  <asp:Label ID="lblEmailOfMarketing" runat="server" Text="E-Mail Of Marketing : "  ></asp:Label>                                    </td>
                            <td align="left" colspan="3">
                                  <uc1:txtAutoComplete ID="txtEmailOfMarketing" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">
                                    <asp:Label ID="lblEmailOfMarketingCC" runat="server" Text="CC : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtEmailOfMarketingCC" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="32" align="right">
                                    <asp:Label ID="lblEmailOfClaim" runat="server" Text="E-Mail Of Claim : "  ></asp:Label>                                    </td>
              <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtEmailOfClaim" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="24" align="right">
                                    <asp:Label ID="lblEmailOfClaimCC" runat="server" Text="CC : "  ></asp:Label>                                    </td>
                              <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtEmailOfClaimCC" runat="server" IsNotNull="true" Width="450px" />                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="lblInputPerson" runat="server" Text="Input Person : "  ></asp:Label>                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtInputPerson" runat="server" Width="150px" TextType="TextView" Text="SYSTEM" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblMntDate" runat="server" Text="Mnt Date : "  ></asp:Label>                                    </td>
                                    <td align="left" >
                                      <uc2:txtDate ID="txtMntDate" runat="server" DefaultCurrentDate="true" VisibleImg="false" />                                    </td>
                                </tr>
                                <tr><td height="40" colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="btnResponseCompany" runat="server" ImageUrl="~/Images/ButtonContactAccount.png" Height="30px" Visible="false" />                                    </td>
                                </tr>
                                <tr>
                                  <td height="30" colspan="4" align="center">&nbsp;</td>
                              </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
            <td width="35%" valign="top" align="left"  >
                <br /><br />
                <h2><b>เกณฑ์การตั้งรหัสผ่าน</b></h2>
                1. ป้อนตัวอักษรภาษาอังกฤษหรือตัวเลขความยาวไม่เกิน 18 หลัก และ ต่ำสุด 6 หลัก<br />
                2.	ตัวอักษรตัวแรกจะต้องไม่เป็นตัวเลข<br />
                3.	ห้ามมีตัวอักษรหรือตัวเลขตัวเดียวกันเรียงกันมากกว่า 2 ตัว <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <font color="#e30076"> >> ตัวอย่างที่ถูก : job715 หรือ j7o1b5</font><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <font color="#FF0000"> >> ตัวอย่างที่ผิด : jjjb715 หรือ job7771</font><br />
                4.	รหัสผ่านต้องไม่ซ้ำกัน 5 ครั้งก่อนหน้านี้ที่กำหนดมาแล้ว<br />
                5.	เป็นตัวอักษรผสมตัวเลข หรือเป็นตัวอักษรอย่างเดียว<br />
                6.  รหัสผ่านใหม่มีอายุ 90 วัน นับตั้งแต่วันที่เปลี่ยนรหัสผ่าน <br />(ระบบจะเตือนล่วงหน้า 7 วันก่อนครบกำหนด)
                
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
    
    <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
    <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" DropShadow="true">
    </cc1:ModalPopupExtender>
    
    <asp:Panel ID="Panel1" runat="server" Width="750" Height="500" ScrollBars="Auto" >
        <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
            style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
            <tr class="popHead">
                <td align="left" >
                    <asp:Label ID="lblHeader" runat="server" Text="บริษัทที่รับผิดชอบ" ></asp:Label>                </td>
                <td align="right" >
                    <asp:ImageButton ID="imgClose" runat="server" ImageUrl="../Images/closewindows.png" />                </td>
            </tr>
            <tr>
                <td>&nbsp;                </td>
                <td>
                    <uc1:txtAutoComplete ID="txtResponseCompanyID" runat="server" Visible="false" Text="0" />                </td>
            </tr>
            <tr>
                <td colspan="2" align="left">
                    <table border="0"  cellpadding="0" cellspacing="2" width="95%" align="center" style="border-style: solid; border-width: 1px;">
                        <tr><td colspan="2">&nbsp;</td></tr>
                        <tr>
                            <td width="20%" align="left" >User ID : </td>
                            <td width="80%" align="left" >
                                <uc1:txtAutoComplete ID="txtResUser" runat="server" TextType="TextView" Width="200px" />                            </td>
                        </tr>
                        <tr>
                            <td align="left" >Account Code :</td>
                            <td align="left" >
                                <uc6:ctlAccountCode ID="ctlResAccount" runat="server" />                            </td>
                        </tr>
                        <tr>
                            <td align="left" >Group Code :</td>
                            <td align="left" >
                                <uc1:txtAutoComplete ID="txtResGroupCode" runat="server" TextType="TextView" Width="100px" />                            </td>
                        </tr>
                        <tr>
                            <td align="left" >Policy No :</td>
                            <td align="left" >
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                    <tr>
                                        <td align="left"><uc1:txtAutoComplete ID="txtResPolNo" runat="server" TextType="TextView" Width="100px" />  </td>
                                        <td align="right">Policy Year : </td>
                                        <td align="left"><uc1:txtAutoComplete ID="txtResPolYear" runat="server" TextType="TextView" Width="40px" /></td>
                                        <td align="right">User GPO : </td>
                                        <td align="left"><uc1:txtAutoComplete ID="txtResUserGPO" runat="server" TextType="TextView" Width="80px" /></td>
                                        <td align="right">Language : </td>
                                        <td align="left"><uc1:txtAutoComplete ID="txtResLanguage" runat="server" TextType="TextView" Width="30px" /></td>
                                    </tr>
                                </table>                            </td>
                        </tr>
                    </table>                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" >
                  
                      <asp:ImageButton ID="btnResSave" runat="server" Text="บันทึก" ImageUrl="~/Images/ButtonSave.png" Height="30px" />                      
                      &nbsp;
                      <asp:ImageButton ID="btnResCancel" runat="server" Text="ยกเลิก" ImageUrl="~/Images/ButtonCancel.png"  Height="30px" />                      
                   </td>
            </tr>
            <tr>
                <td colspan="2" align="left"><uc7:PageControl ID="pc1" runat="server" Visible="false" /></td>
            </tr>
            <tr style="height:200px" >
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    AllowPaging="true" AllowSorting="true" CssClass="GridViewStyle" 
                    Width="100%" PageSize="10" >
                        <RowStyle CssClass="RowStyle" />
                        <Columns> 
                            <asp:BoundField HeaderText="No" DataField="no" >
                                <HeaderStyle Width="25px" HorizontalAlign="Center" />
                                <ItemStyle Width="25px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Group Code" SortExpression="grp_code" DataField="grp_code" >
                                <HeaderStyle Width="80px" HorizontalAlign="Center" />
                                <ItemStyle Width="80px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account Code" SortExpression="ac_code" DataField="ac_code" >
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle Width="100px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Account Name" SortExpression="ac_name" DataField="ac_name" >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Policy No" SortExpression="pol_no" DataField="pol_no" >
                                <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Width="70px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Policy Year" SortExpression="pol_year" DataField="pol_year" >
                                <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Width="70px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="User GPO" SortExpression="user_gpo_id" DataField="user_gpo_id" >
                                <HeaderStyle Width="70px" HorizontalAlign="Center" />
                                <ItemStyle Width="70px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:BoundField HeaderText="Language" SortExpression="language" DataField="language" >
                                <HeaderStyle Width="60px" HorizontalAlign="Center" />
                                <ItemStyle Width="60px" HorizontalAlign="Center" />                            </asp:BoundField>
                            <asp:TemplateField ShowHeader="false" >
                                <ItemTemplate>
                                    <asp:ImageButton ID="lnkEdit" runat="server" ImageUrl="~/Images/editor.gif" CommandName="EDIT" CommandArgument='<%# Bind("id")  %>' ToolTip="Edit" Visible="false" ></asp:ImageButton>
                                    <asp:ImageButton ID="lnkDelete" runat="server" ImageUrl="~/Images/icn_close.png" CommandName="DELETE" CommandArgument='<%# Bind("id")  %>' ToolTip="Delete"
                                     OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <PagerSettings Visible="false" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                    <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>                </td>
            </tr>
            <tr><td colspan="2">&nbsp;</td></tr>
        </table>
    </asp:Panel>
    
</asp:Content>

