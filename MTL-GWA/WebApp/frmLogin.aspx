<%@ Page Language="VB" MasterPageFile="~/Template/LoginMasterPage.master" AutoEventWireup="false" CodeFile="frmLogin.aspx.vb" Inherits="WebApp_frmLogin" title="เข้าสู่ระบบ (Login)" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1000"  border="0" cellpadding="0" cellspacing="0" align="center">
        <tr style="height:650px">
            <td width="100%" align="center" style="background-position: center center; background-image:url('../Images/ScrLogin.jpg'); background-repeat:no-repeat;">
                <table width="50%" border="0" cellpadding="0" cellspacing="0" align="center" >
                    <tr style="height:50px" >
                        <td colspan="3">&nbsp;</td>
                    </tr>
                    <tr><td colspan="3">&nbsp;</td></tr>
                    <tr><td colspan="3">&nbsp;</td></tr>
                    <tr style="height:40px">
                        <td width="18%">&nbsp;</td>
                        <td align="right" width="40%"><font color="white"><b>ชื่อผู้ใช้ (User ID) :</b></font>&nbsp;</td>
                        <td align="left" width="32%">
                            <asp:TextBox ID="txtUserName" runat="server" Width="120px" CssClass="txtLogin" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height:40px">
                        <td >&nbsp;</td>
                        <td align="right"><font color="white"><b>รหัสผ่าน (Password) :</b></font>&nbsp;</td>
                        <td align="left">
                            <asp:TextBox ID="txtPasswd" runat="server" Width="120px" TextMode="Password" CssClass="txtLogin" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height:20px" >
                        <td >&nbsp;</td>
                        <td >&nbsp;</td>
                        <td align="left" >
                            <asp:Button ID="btnLogin" runat="server" Text="เข้าสู่ระบบ (Login)" CssClass="btnLogin" Width="120px" />
                        </td>
                    </tr>
                    <tr style="height:"20px">
                        <td>&nbsp;</td>
                        <td align="center" colspan="2"  >
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="btnForgotPassword" runat="server" Text="ลืมรหัสผ่าน (Forgot Your Password?)" Font-Size="11px" Font-Names="Tahoma" ForeColor="White" />
                        </td>
                    </tr>
                </table>
            </td>
           
        </tr>
        <tr>
             <td align="left" valign="bottom" >
                <asp:LinkButton ID="likSystemPage" runat="server" Text="." ForeColor="White"  ></asp:LinkButton>
                
                
                <asp:Panel ID="Panel1" runat="server" Width="650">
                    <table id="Table1" width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff"
                        style="border: solid 0px 0px 0px 0px #ff0000" runat="server">
                        <tr >
                            <td align="left" >
                                <asp:TextBox ID="txtSystemUser" runat="server"></asp:TextBox> <br />
                                <asp:TextBox ID="txtSystemPassword" TextMode="Password" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:button ID="btnSystemLogin" runat="server" Text="Login" />&nbsp;&nbsp;
                                <asp:button ID="btnSystemPopClose" runat="server" Text="Close" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Button ID="Button1" runat="server" Text="Button" Width="0px" CssClass="zHidden" />
                <cc1:ModalPopupExtender ID="zPop" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
                    BackgroundCssClass="modalBackground" DropShadow="true" >
                </cc1:ModalPopupExtender>
            </td>
        </tr>
    </table>
</asp:Content>

