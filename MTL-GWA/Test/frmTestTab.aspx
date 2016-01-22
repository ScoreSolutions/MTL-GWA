<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmTestTab.aspx.vb" Inherits="Test_frmTestTab" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style  type="text/css">


</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Button ID="TestMail" runat="server" Text="TestMail" />
    <br />
    Mail :
    <asp:TextBox ID="testSendMail" runat="server"></asp:TextBox><br />
    CC :
    <asp:TextBox ID="testMailCC" runat="server"></asp:TextBox>
</asp:Content>

