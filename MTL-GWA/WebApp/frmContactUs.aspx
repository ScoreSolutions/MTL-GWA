<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmContactUs.aspx.vb" Inherits="WebApp_frmContactUs" title="ติดต่อเรา" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="SearchBody">
                    <tr>
                        <td  align="center" style="height:350px" valign="top" >
                            <table width="80%" border="0" cellpadding="9" cellspacing="2" align="center" >
                                <tr><td colspan="3"></td></tr>
                                <tr>
                                    <td height="20" colspan="3"></td>
                                </tr>
                                <tr>
                                  <td></td>
                                  <td width="1"></td>
                                  <td align="left" ><asp:RadioButtonList ID="rdiSendType" runat="server">
                                    <asp:ListItem Text="แจ้งฝ่ายดำเนินงานประกันกลุ่ม (Contact Group Insurance Administration Department)" Value="1" selected></asp:ListItem>
                                    <asp:ListItem Text="แจ้งฝ่ายการตลาดประกันกลุ่ม (Contact Group Insurance Marketing Department)" Value="2" ></asp:ListItem>
                                    <asp:ListItem Text="แจ้งทั้ง 2 ฝ่าย (Contact both departments)" Value="3" ></asp:ListItem>
                                  </asp:RadioButtonList></td>
                                </tr>
                                <tr >
                                  <td width="182" height="56" align="right"><asp:Label ID="lblAccountCode" runat="server" Text="รหัสบริษัท :<br />(Account Code)" ></asp:Label> &nbsp;&nbsp;</td>
                                    <td width="1" align="right">&nbsp;</td>
                                    <td width="537" align="left">
                                        <uc2:cmbCombobox ID="cmbAccountCode" runat="server" Width="425px" IsDefaultValue="false" />
                                        <uc1:txtAutoComplete ID="txtID" runat="server" Visible="false" />
                                        <uc1:txtAutoComplete ID="txtMenuID" runat="server" Visible="false" />
                                        <asp:Label ID="lblContactUsType" runat="server" Visible="false"></asp:Label>                                  </td>
                                </tr>
                                <tr >
                                    <td height="56" align="right" valign="top" ><asp:Label ID="lblDescription" runat="server" Text="รายละเอียดคำถาม :<br />(Description)" ></asp:Label> &nbsp;&nbsp;</td>
                                    <td width="1" height="56" align="right" valign="top" >&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtDescription" runat="server" TextMode="MultiLine" Height="200px" Width="425px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr >
                                    <td height="57" align="right"><asp:Label ID="lblSendBackMail" runat="server" Text="อีเมล์สำหรับติดต่อกลับ :<br />(Reply Mail)" ></asp:Label>&nbsp;&nbsp;</td>
                                    <td height="57" align="right">&nbsp;</td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtSendBackMail" runat="server" Width="425px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr style="height:35px" >
                                    <td colspan="3" align="center">
                                        <asp:ImageButton ID="btnSend" runat="server" ImageUrl="~/Images/ButtonSend.png" Height="30px" />&nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                    </td>
                                </tr>
                                <tr style="height:35px" >
                                  <td colspan="3" align="center">&nbsp;</td>
                                </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

