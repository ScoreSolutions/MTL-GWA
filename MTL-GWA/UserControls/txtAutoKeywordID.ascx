<%@ Control Language="VB" AutoEventWireup="false" CodeFile="txtAutoKeywordID.ascx.vb" Inherits="UserControls_txtAutoKeywordID" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:TextBox runat="server" ID="TextBox1" Width="350px" autocomplete="off" />
<asp:Label ID="Label1" runat="server" ForeColor="Red" Text="*"></asp:Label>
<asp:Label ID="lblValidText" runat="server" ForeColor="Red" ></asp:Label>
<cc1:AutoCompleteExtender
        runat="server" 
        ID="autoComplete1" 
        TargetControlID="TextBox1"
        ServicePath="~/Template/AjaxScript.asmx"
        ServiceMethod = "GetTextAutoComplete"
        MinimumPrefixLength="1" 
        CompletionInterval="500"
        UseContextKey="true"
        EnableCaching="true"
        CompletionSetCount="10" FirstRowSelected="true"
        CompletionListCssClass="autocomplete_completionListElement" 
        CompletionListItemCssClass="autocomplete_listItem" 
        CompletionListHighlightedItemCssClass="autocomplete_highlightedListItem"
        ShowOnlyCurrentWordInCompletionListItem="true"  >
</cc1:AutoCompleteExtender>     
<asp:HiddenField ID="txtTbName" runat="server" Value="DEFAULT" />
<asp:HiddenField ID="txtFldName" runat="server" Value="DEFAULT" />