<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFAQForm.aspx.vb" Inherits="WebApp_frmFAQForm" title="คำถามที่พบบ่อย (FAQ)" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc4" %>
<%@ Register src="../UserControls/ctlTab.ascx" tagname="ctlTab" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
 

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <ul>
        <li></li>
    </ul>
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td class="SearchBody" align="center">
                            <table width="100%" border="0" cellpadding="0" cellspacing="3" >
                                <tr>
                                    <td width="20%"><uc1:txtAutoComplete ID="txtID" runat="server" Visible="false" Text="0" /></td>
                                    <td width="30%">&nbsp;</td>
                                    <td width="20%">&nbsp;</td>
                                    <td width="30%">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="29" align="right"><asp:Label ID="lblPolicyServiceType" runat="server" Text="หมวดหมู่คำถาม : "  ></asp:Label></td>
                      <td align="left" colspan="3">
                                        <uc3:cmbComboBox ID="cmbPolicyServiceTypeID" runat="server" Width="300px" 
                                            IsNotNull="true" AutoPosBack="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="29" align="right"><asp:Label ID="lblQuestion" runat="server" Text="คำถาม : " ></asp:Label></td>
<td align="left" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtQuestion" runat="server" Width="600px" IsNotNull="true" MaxLength="500" />
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td height="62" align="right" valign="middle" ><asp:Label ID="lblAnswer" runat="server" Text="คำตอบ : " ></asp:Label></td>
<td align="left" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtAnswer" runat="server" Width="600px" TextMode="MultiLine" Height="50px" MaxLength="500" IsNotNull="true" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="32" align="right"><asp:Label ID="lblOrderSeq" runat="server" Text="ลำดับการแสดงผล : " ></asp:Label></td>
<td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtOrderSeq" TextAlign="AlignRight" TextKey="TextInt" runat="server" Width="40px" IsNotNull="true" />&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lblOrderSeq1" runat="server" Visible="false" ></asp:Label>
                                        <asp:CheckBox ID="chkActive" runat="server" Text="แสดงในหน้าจอผู้ใช้งาน" Checked="true" />
                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                                <tr >
                                    <td colspan="4" align="center" >
                                        <table border="0" cellpadding="0" cellspacing="0" width="70%">
                                            <tr>
                                                <td align="left">
                                                    <p>&nbsp;</p>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" Height="27px" 
                                                            ImageUrl="~/Images/bg/search-1.png"/>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" Height="27px" 
                                                            ImageUrl="~/Images/bg/attached.png" />
                                                    <asp:Panel ID="Panel1" runat="server">
                                                      <table border="0" cellpadding="0" cellspacing="0" width="100%" class="SearchBody" >
                                                                    <tr><td colspan="3">&nbsp;</td></tr>
                                                                    <tr>
                                                                        <td width="20%" height="36" align="right">เลือกไฟล์ :&nbsp;</td>
                                                          <td width="52%" align="left">
                                                  <uc4:ctlBrowseFile ID="ctlFileUpload" runat="server" VisibleUploadButton="false" Width="350px" />
                                                                      </td>
                                                                  <td width="28%" align="left">
                                                                <asp:Label ID="lblFileLimit" runat="server" Font-Italic="True" Text="Limit 5Mb"></asp:Label>
                                                                        </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                            <td align="left" ><font color="gray">(เฉพาะไฟล์ Word, Excel และ PDF เท่านั้น)</font></td>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                                    <tr>
                                                                        <td height="36" align="right">รายละเอียด :&nbsp;</td>
                                                          <td align="left" colspan="2">
                                            <uc1:txtAutoComplete ID="txtFileDesc" runat="server" Width="250" IsNotNull="true" />
                                                                            <asp:ImageButton ID="btnAddFile" runat="server" ImageUrl="~/Images/ButtonAdd.png" Height="25px" />
                                                                            <uc1:txtAutoComplete ID="txtFaqFileID" runat="server" Visible="False" 
                                                                                Text="0" />
                                                                            <uc1:txtAutoComplete ID="txtRowIndex" runat="server" Visible="False" />                                                                      </td>
                                                        </tr>
                                                                    <tr><td colspan="3">&nbsp;</td></tr>
                                                                    <tr>
                                                                        <td colspan="3" align="center" >
                                                                            <asp:GridView ID="gvFileList" runat="server" 
                                                                                AutoGenerateColumns="False" BackColor="White" PageSize="20" 
                                                                                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                                                                                CssClass="GridViewStyle" GridLines="Vertical" >
                                                                                <RowStyle CssClass="RowStyle" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="id" HeaderText="id">
                                                                                        <ControlStyle CssClass="zHidden" />
                                                                                        <FooterStyle CssClass="zHidden" />
                                                                                        <HeaderStyle CssClass="zHidden" />
                                                                                        <ItemStyle CssClass="zHidden" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField  DataField="no" HeaderText="ลำดับ" >
                                                                                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField  DataField="file_desc" HeaderText="รายละเอียด" >
                                                                                        <ItemStyle Width="300px" HorizontalAlign="Left"></ItemStyle>
                                                                                        <HeaderStyle Width="300px" HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField ShowHeader="False" >
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="lnkDelete" runat="server" ImageUrl="~/Images/icn_close.png" CommandArgument='<%# Bind("id")  %>' CommandName="DeleteFile" ToolTip="Delete"
                                                                                             OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="50px" />
                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle CssClass="PagerStyle" />
                                                                                <HeaderStyle CssClass="HeaderStyle" />
                                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr><td colspan="3">&nbsp;</td></tr>
                                                      </table>
                                                    </asp:Panel>
                                                    <asp:Panel ID="Panel2" runat="server">
                                                    	<table border="0" cellpadding="0" cellspacing="0" width="100%" class="SearchBody">
                                                                    <tr><td colspan="2">&nbsp;</td></tr>
                                                                    <tr>
                                                                        <td width="20%" height="41" align="right">คำค้น :&nbsp;</td>
                                                                  <td width="80%" align="left" >
                                                            <uc1:txtAutoComplete ID="txtKeyword" runat="server" Width="250" IsNotNull="false" />
                                                                            <uc1:txtAutoComplete ID="txtFaqKeywordID" runat="server" Visible="False" 
                                                                                Text="0" />
                                                                  <asp:ImageButton ID="btnAddKeyword" runat="server" ImageUrl="~/Images/ButtonAdd.png" Height="25px" />
                                                                      </td>
                                                          </tr>
                                                                    <tr>
                                                                      <td colspan="2">&nbsp;</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" align="center" >
                                                                            <asp:GridView ID="gvKeywordList" runat="server" 
                                                                                AutoGenerateColumns="False" BackColor="White" PageSize="20" 
                                                                                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                                                                                CssClass="GridViewStyle" GridLines="Vertical" >
                                                                                <RowStyle CssClass="RowStyle" />
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="id" HeaderText="id">
                                                                                        <ControlStyle CssClass="zHidden" />
                                                                                        <FooterStyle CssClass="zHidden" />
                                                                                        <HeaderStyle CssClass="zHidden" />
                                                                                        <ItemStyle CssClass="zHidden" />
                                                                                    </asp:BoundField>
                                                                                    
                                                                                    <asp:BoundField  DataField="no" HeaderText="ลำดับ" >
                                                                                        <ItemStyle Width="30px" HorizontalAlign="Center"></ItemStyle>
                                                                                        <HeaderStyle Width="30px" HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField  DataField="keyword" HeaderText="คำค้น" >
                                                                                        <ItemStyle Width="300px" HorizontalAlign="Left"></ItemStyle>
                                                                                        <HeaderStyle Width="300px" HorizontalAlign="Center"></HeaderStyle>
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField ShowHeader="False" >
                                                                                        <ItemTemplate>
                                                                                            <asp:ImageButton ID="lnkDelete" runat="server" ImageUrl="~/Images/icn_close.png" CommandArgument='<%# Bind("id")  %>' CommandName="DeleteKeyword" ToolTip="Delete"
                                                                                             OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                                                                        </ItemTemplate>
                                                                                        <HeaderStyle Width="50px" />
                                                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerStyle CssClass="PagerStyle" />
                                                                                <HeaderStyle CssClass="HeaderStyle" />
                                                                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                    <tr><td colspan="2">&nbsp;</td></tr>
                                                      </table>
                                                    </asp:Panel>
                                              </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />&nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />&nbsp;
                                        <asp:ImageButton ID="btnUserViewer" runat="server" ImageUrl="~/Images/ButtonUserView.png" Height="30px" />
                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
</asp:Content>

