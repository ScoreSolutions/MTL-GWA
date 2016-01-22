<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ctlBrowseFile.ascx.vb" Inherits="UserControls_ctlBrowseFile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<cc1:AsyncFileUpload ID="FileBrowse" runat="server" Width="300px" Height ="24px" 
    FailedValidation="False" />
<asp:Button ID="Button1" runat="server" Text="Upload" CssClass="CssBtn" 
    Width="80px" />