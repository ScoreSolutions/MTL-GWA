<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmUsersChangePassword.aspx.vb" Inherits="WebApp_frmUsersChangePassword" title="เปลี่ยนรหัสผ่าน" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="SearchBody" align="center"  valign="top" >
                            <table width="60%" border="0" cellpadding="0" cellspacing="0" align="center" >
                                <tr><td height="39" colspan="3" >&nbsp;</td></tr>
                                <tr >
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblUserName" runat="server" Text="ชื่อเข้าระบบ :<br />(User ID)" ></asp:Label>                                    </td>
                                    <td width="1%" align="left">&nbsp;</td>
                                    <td width="67%" align="left">
                                        <uc1:txtAutoComplete ID="txtUserName" runat="server" Width="200px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr style="height:40px" >
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblOldPassword" runat="server" Text="รหัสผ่านเดิม :<br />(Old Password)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtOldPassword" runat="server" Width="200px" TextMode="Password" MaxLength="18" />                                    </td>
                                </tr>
                                <tr style="height:40px" >
                                    <td align="right" class="Csslbl">
                                        <asp:Label ID="lblNewPassword" runat="server" Text="รหัสผ่านใหม่ :<br />(New Password)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtNewPassword" runat="server" Width="200px" TextMode="Password" MaxLength="18" />                                    </td>
                                </tr>
                                <tr style="height:40px" >
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblConfirmPassword" runat="server" Text="ยืนยันรหัสผ่านใหม่ :<br />(Confirm New Password)" ></asp:Label>                                    </td>
                                  <td align="left">&nbsp;</td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtConfirmPassword" runat="server" Width="200px" TextMode="Password" />                                    </td>
                                </tr>
                                <tr><td colspan="3" >&nbsp;</td></tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:ImageButton ID="btnChangePassword" runat="server" ImageUrl="~/Images/ButtonChangePassword.png" Height="30px" />                                                                                &nbsp;&nbsp;
                                    <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px"  />                                    </td>
                                </tr>
                                <tr><td colspan="3" >&nbsp;</td></tr>
                                <tr>
                                    <td colspan="3" align="left" class="Csslbl" >
                                        <b>เกณฑ์การตั้งรหัสผ่าน</b>
                                    </td>
                                </tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">1. ป้อนตัวอักษรภาษาอังกฤษหรือตัวเลขความยาวไม่เกิน 18 หลัก และ ต่ำสุด 6 หลัก</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">2.	ตัวอักษรตัวแรกจะต้องไม่เป็นตัวเลข</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">3.	ห้ามมีตัวอักษรหรือตัวเลขตัวเดียวกันเรียงกันมากกว่า 2 ตัว</td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" class="Csslbl" valign="top" >
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <font color="#e30076"> >> ตัวอย่างที่ถูก : job715 หรือ j7o1b5</font>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3" class="Csslbl">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <font color="#FF0000"> >> ตัวอย่างที่ผิด : jjjb715 หรือ job7771</font>
                                    </td>
                                </tr>
                                <tr><td colspan="3">&nbsp;</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">4.	รหัสผ่านต้องไม่ซ้ำกัน 5 ครั้งก่อนหน้านี้ที่กำหนดมาแล้ว</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">5.	เป็นตัวอักษรผสมตัวเลข หรือเป็นตัวอักษรอย่างเดียว</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px" class="Csslbl">6.  รหัสผ่านใหม่มีอายุ 90 วัน นับตั้งแต่วันที่เปลี่ยนรหัสผ่าน (ระบบจะเตือนล่วงหน้า 7 วันก่อนครบกำหนด) </td></tr>
                                <tr><td colspan="3" >&nbsp;</td></tr>
                                
                                <tr>
                                    <td colspan="3" align="left" >
                                        <b>Setting password:</b><br />
                                        To minimize the potential risk of unauthorized access to important data and use of computing resources, password must be set according to the below conditions;
                                    </td>
                                </tr>
                                <tr><td align="left" colspan="3" style="height:30px">1. Password must be in Englist, and contains at least 6 characters but not more than 18 characters.</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px">2. The first characters must be in Englist letter.</td></tr>
                                <tr>
                                    <td align="left" colspan="3" style="height:30px">
                                        3. Not allow more than 2 repeated letters or numbers.<br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <font color="#e30076"> >> Sample(correct) : job715 or j7o1b5</font><br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <font color="#FF0000"> >> Sample (Wrong) : jjjb715 or job7771</font>
                                    </td>
                                </tr>
                                <tr><td align="left" colspan="3" style="height:30px">4. New password must be differed from previous 5 passwords.</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px">5. Composes of letters and number combination, or pure letter.</td></tr>
                                <tr><td align="left" colspan="3" style="height:30px">6. New password will be valid 90 days from the password's setting date (System will notify user 7 days in advance when log-in)</td></tr>
                            </table>
                          <p>&nbsp;</p>
                      <p>&nbsp;</p>
                      <p>&nbsp;</p></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

