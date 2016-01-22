<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFAQDetail.aspx.vb" Inherits="WebApp_frmFAQDetail" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" valign="top" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td  align="center" valign="top">
                            <asp:Label ID="lblQuestionDetail" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr><td>&nbsp;</td></tr>
                    <tr><td align="left" ><asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/ButtonBackToFAQ.png" /></td></tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
</asp:Content>

