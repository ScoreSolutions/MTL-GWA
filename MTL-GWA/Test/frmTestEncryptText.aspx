<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmTestEncryptText.aspx.vb" Inherits="Test_frmTestEncryptText" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="EnCrypt" />
    <asp:Button ID="Button2" runat="server" Text="DeCrypt" />
    
    <asp:Button ID="btnQuery" runat="server" Text="Query" />
</asp:Content>

