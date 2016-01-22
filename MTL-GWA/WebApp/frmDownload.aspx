<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDownload.aspx.vb" Inherits="WebApp_frmDownload" title="ดาวน์โหลด(Download)" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc4" %>
<%@ Register src="../UserControls/ctlTab.ascx" tagname="ctlTab" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr><td >&nbsp;</td></tr>
                    <tr >
                        <td align="left" width="100%" >
                            <table border="0" cellpadding="0" cellspacing="0" align="left" >
                                <tr>
                                    <td><uc2:ctlTab ID="btnTabManual" runat="server" TabText="คู่มือประกันกลุ่ม(Group Insurance Handbook)" ActiveTab="true" /></td>
                                    <td><uc2:ctlTab ID="btnTabForm" runat="server" TabText="แบบฟอร์ม (Forms)"  ActiveTab="false" /></td>
                                    <td><uc2:ctlTab ID="btnTabOther" runat="server" TabText="อื่นๆ (Others)" ActiveTab="false" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
               </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="SearchBody"  >
                    <tr >
                        <td width="100%"  align="center" valign="top"  >
                            <asp:Label ID="lblFileList" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr><td >&nbsp;</td></tr>
                </table>
            </td>
        </tr>
     </table>     
</asp:Content>

