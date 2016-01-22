<%@ Page Language="VB" MasterPageFile="~/Template/LoginMasterPage.master" AutoEventWireup="false" CodeFile="frmForgotPassword.aspx.vb" Inherits="WebApp_frmForgotPassword" title="ลืมรหัสผ่าน(Forgot Password)" %>

<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1000"  border="0" cellpadding="0" cellspacing="0" align="center">
        <tr style="height:650px">
            <td width="100%" align="center" style="background-position: center center; background-image:url('../Images/ScrForgotPassword.jpg'); background-repeat:no-repeat;">
                <br />
                <asp:Panel ID="pnlForgotPassword" runat="server" Width="60%" BorderColor="#e30076" BorderWidth="1" BackColor="#FFFFFF" >
                    <table width="100%" border="0" cellpadding="2" cellspacing="0" align="center" >
                        <tr><td>&nbsp;</td></tr>
                        <tr>
                            <td class="CssSubHeadPink" colspan="3" align="center" >ลืมรหัสผ่าน(Forgot Password)</td>
                            <td align="right" width="24">
                                <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Images/closewindows.png" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center" >
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                    <tr >
                                        <td align="left" width="100%" valign="middle" >
                                            <table id="tbForgotPassword" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%" >
                                                <tr><td>&nbsp;</td></tr>
                                                <tr>
                                                    <td align="center" colspan="2" ><b>กรุณากรอกชื่อเข้าระบบและอีเมล์ (Please enter your user id and email address)</b></td>
                                                </tr>
                                                <tr>
                                                    <td width="50%" align="right">ชื่อเข้าระบบ (User ID) :&nbsp;</td>
                                                    <td width="50%" align="left">
                                                        <uc1:txtAutoComplete ID="txtUserID" runat="server" IsNotNull="true" Width="150px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">อีเมล์ (E-Mail) :&nbsp;</td>
                                                    <td align="left">
                                                        <uc1:txtAutoComplete ID="txtMail" runat="server" IsNotNull="true"  Width="150px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td align="left">
                                                        <asp:ImageButton ID="btnForgotPassword" runat="server" ImageUrl="~/Images/ButtonForgotPassword.png" Height="30px" />&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <table id="tbSendMailComplete" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%" visible="false" >
                                                <tr><td>&nbsp;</td></tr>
                                                <tr>
                                                    <td align="center"  >
                                                        ระบบได้ทำการส่งรหัสผ่านให้กับคุณไปยังอีเมล์ 
                                                        <b><asp:Label ID="lblUserEMail" runat="server" ></asp:Label> </b> 
                                                        เป็นที่เรียบร้อยแล้ว<br />
                                                        Your password already sent to <asp:Label ID="lblUserEmailEng" runat="server" Font-Bold="True" ></asp:Label>
                                                        . Please check your mailbox. <br />
                                                         <br />  
                                                    </td>
                                                </tr>
                                                <tr><td>&nbsp;</td></tr>
                                                <tr><td>&nbsp;</td></tr>
                                                <tr>
                                                    <td align="right" >
                                                        <asp:LinkButton ID="likLogin" runat="server" Text="เข้าสู่ระบบ" ></asp:LinkButton>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                            <table id="tbSendMailError" runat="server" border="0" cellpadding="0" cellspacing="2" width="100%" visible="false" >
                                                <tr><td >&nbsp;</td></tr>
                                                <tr>
                                                    <td align="center" >
                                                        <b>เกิดข้อผิดพลาด</b>
                                                    </td>
                                                </tr>
                                                <tr><td>&nbsp;</td></tr>
                                                <tr>
                                                    <td align="center"  >
                                                        <asp:Label ID="lblErrMessage" runat="server" Text="อีเมล์ของท่านไม่ถูกต้อง" ForeColor="Red" ></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr><td>&nbsp;</td></tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="likForgotPassword" runat="server" Width="120px" Text="ลืมรหัสผ่าน" CssClass="btnLogin" ></asp:Button>&nbsp;
                                                        <asp:Button ID="likLogin2" runat="server" Text="เข้าสู่ระบบ" Width="120px" CssClass="btnLogin" ></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr><td>&nbsp;</td></tr>
                                    <tr><td>&nbsp;</td></tr>
                               </table>
                            </td>
                        </tr>
                     </table>     
                 </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

