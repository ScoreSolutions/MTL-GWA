<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmUsersProfile.aspx.vb" Inherits="WebApp_frmUsersProfile" title="ข้อมูลผู้ใช้งาน" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center"  >
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="SearchBody" align="center" >
                            <table width="80%" border="0" cellspacing="3" align="center" >
                                <tr>
                                    <td width="25%" height="31" colspan="2" ><uc1:txtAutoComplete ID="txtUserID" runat="server" Visible="false" />&nbsp;</td>
                                    <td width="25%" >&nbsp;</td>
                                    <td width="25%" colspan="2" >&nbsp;</td>
                                    <td width="25%" >&nbsp;</td>
                                </tr>
                                <tr  style="height:40px" >
                                    <td  align="right">
                                        <asp:Label ID="lblUserFullNameThai" runat="server" Text="ชื่อผู้ใช้ระบบ(ไทย) :<br />(User Name Thai)" ></asp:Label>                                    </td>
                                    <td  align="left">&nbsp;</td>
                                    <td align="left" colspan="4">
                                        <uc1:txtAutoComplete ID="txtUserFullNameThai" runat="server" Width="200px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr  style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblUserFillNameEng" runat="server" Text="ชื่อผู้ใช้ระบบ (อังกฤษ) :<br />(User Name English)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left" colspan="4">
                                        <uc1:txtAutoComplete ID="txtUserFillNameEng" runat="server" Width="200px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr  style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblEffectDate" runat="server" Text="วันที่เริ่มต้นใช้งานระบบ :<br />(User Start Date)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtEffectDate" runat="server" Width="120px" TextType="TextView" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblExpireDate" runat="server" Text="วันที่สิ้นสุดการใช้งานระบบ :<br />(User End Date)" ></asp:Label>                                    </td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtExpireDate" runat="server" Width="120px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr  style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblUserType" runat="server" Text="ประเภทผู้ใช้งาน :<br />(User Type)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtUserType" runat="server" Width="120px" TextType="TextView" />                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblUserLevel" runat="server" Text="ระดับผู้ใช้งาน :<br />(User Level)" ></asp:Label>                                    </td>
                                    <td align="right">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtUserLevel" runat="server" Width="120px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr  style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblMail" runat="server" Text="อีเมล์ :<br />(E-Mail)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left" colspan="4">
                                        <uc1:txtAutoComplete ID="txtMail" runat="server" Width="200px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr  style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblTel" runat="server" Text="เบอร์ติดต่อ :<br />(Tel)" ></asp:Label>                                    </td>
                                    <td align="left">&nbsp;</td>
                                    <td align="left" colspan="4">
                                        <uc1:txtAutoComplete ID="txtTel" runat="server" Width="200px" IsNotNull="true"  />                                    </td>
                                </tr>
                                <tr style="height:40px">
                                    <td align="right">
                                        <asp:Label ID="lblLastLogin" runat="server" Text="คุณใช้งานครั้งล่าสุดเมื่อ :<br />(Last Login Date)" ></asp:Label>                                    </td>
                                  <td align="left">&nbsp;</td>
                                    <td align="left" colspan="4">
                                        <uc1:txtAutoComplete ID="txtLastLogin" runat="server" Width="200px" TextType="TextView" />                                    </td>
                                </tr>
                                <tr style="height:40px">
                                    <td colspan="6" align="center">
                                        
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />                                        
                                        &nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                                                            </td>
                                </tr>
                                <tr><td colspan="6" >&nbsp;</td></tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

