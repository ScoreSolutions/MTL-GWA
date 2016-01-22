<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmClaimImportFile.aspx.vb" Inherits="WebApp__frmClaimImportFile" title="บริการด้านสินไหม >> นำเข้าเอกสาร" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/ctlBrowseFile.ascx" tagname="ctlBrowseFile" tagprefix="uc4" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                    <tr>
                        <td class="SearchBody" align="center" >
                            <table border="0" cellpadding="0" cellspacing="2" width="60%" >
                                <tr>
                                    <td height="28" colspan="2">
                                      <asp:HiddenField ID="txtID" runat="server" Value="0" />                                    </td>
                              </tr>
                                <tr>
                                    <td height="28" align="right" ><asp:Label ID="lblServiceCategory" runat="server" Text="ประเภทบริการ : "></asp:Label></td>
                              <td align="left">
                                        <asp:RadioButtonList ID="rdiServiceCategory" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" RepeatLayout="Flow" AutoPostBack="true" >
                                            <asp:ListItem Text="สินไหมประกันสุขภาพ&nbsp;&nbsp;&nbsp;&nbsp;" Value="1" Selected></asp:ListItem>
                                            <asp:ListItem Text="สินไหม:ประกันชีวิต,อุบัติเหตุ,ทุพพลภาพ" Value="2" ></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <font color="red">*</font>                                    </td>
                                </tr>
                                <tr>
                                    <td width="20%" height="39" align="right" >เลือกไฟล์ :&nbsp;</td>
                      <td width="80%" align="left" >
                        <table border="0" cellpadding="0" cellspacing="0" width="85%" >
<tr>
                                                <td width="80%">
                                                    <uc4:ctlBrowseFile ID="ctlFileUpload" runat="server" 
                                                        VisibleUploadButton="false" Width="330px" />                                                </td>
                                          <td width="20%" align="left">
                                                    <font color="red">*</font>
                                                    <asp:Label ID="lblFileLimit" runat="server" Font-Italic="true" Text="Limit 5Mb"></asp:Label>                                                </td>
                                            </tr>
                                        </table>                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td align="left" ><font color="gray">(เฉพาะไฟล์ Word, Excel และ PDF เท่านั้น)</font></td>
                                </tr>
                                <tr>
                                    <td height="38" align="right">รายละเอียด :&nbsp;</td>
                      <td align="left">
                                        <uc1:txtAutoComplete ID="txtFileDesc" runat="server" Width="400px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="38" align="right">ลำดับการแสดง :&nbsp;</td>
                      <td align="left">
                                        <uc1:txtAutoComplete ID="txtOrderSeq" runat="server" Width="50px" IsNotNull="true" TextKey="TextInt" TextAlign="AlignRight" />
                                        <asp:HiddenField ID="txtOrderSeqTmp" runat="server" />
                                        <asp:CheckBox ID="chkActive" runat="server" Text="แสดงในหน้าจอผู้ใช้งาน" />                                    </td>
                                </tr>
                                <tr><td colspan="2">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />                                        
                                        &nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                        
                                        &nbsp;
                                        <asp:ImageButton ID="btnUserViewer" runat="server" ImageUrl="~/Images/ButtonUserView.png" Height="30px" />                                                                            </td>
                                </tr>
                                <tr><td height="29" colspan="2">&nbsp;</td>
                              </tr>
                            </table>
                      </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                    <tr>
                        <td colspan="4" class="CssSubHeadPink" ><asp:Label ID="lblDisplayData" runat="server" Text="แสดงข้อมูล"></asp:Label> </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                    <tr>
                        <td colspan="4" align="left">
                            <uc2:PageControl ID="pcTop" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:GridView ID="gvFileList" runat="server" AllowPaging="true" AllowSorting="true" 
                                AutoGenerateColumns="False" BackColor="White" PageSize="20" 
                                BorderColor="#999999" BorderWidth="1px" CellPadding="1" 
                                CssClass="GridViewStyle" GridLines="Vertical" Width="100%" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id">
                                        <ControlStyle CssClass="zHidden" />
                                        <FooterStyle CssClass="zHidden" />
                                        <HeaderStyle CssClass="zHidden" />
                                        <ItemStyle CssClass="zHidden" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="ลำดับการแสดง<br />(Display Order)" SortExpression="order_seq" >
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                        <ItemTemplate >
                                            <asp:LinkButton ID="lnkOrderSeq" runat="server" Text="<%# Bind('order_seq') %>" CommandName="lblOrderSeqClick" ></asp:LinkButton>
                                            <uc1:txtAutoComplete ID="txtOrderSeq" runat="server" Width="30px" Text="<%# Bind('order_seq') %>"  Visible="false" />
                                            <asp:Button ID="btnSaveOrderSeq" runat="server" Visible="false" Width="50px" Text="บันทึก" CssClass="CssBtn" OnClick="btnSaveOrderSeq_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField  DataField="service_category" SortExpression="service_category" HeaderText="ประเภทบริการ <br />(Ries)" HtmlEncode="false" >
                                        <ItemStyle Width="120px" HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="file_desc" SortExpression="file_desc" HeaderText="รายละเอียด <br />(Descriptions)"  HtmlEncode="false" >
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="active_name" SortExpression="active_name" HeaderText="แสดงในหน้าจอผู้ใช้งาน <br />(Display)"  HtmlEncode="false" >
                                        <ItemStyle Width="120px" HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="import_date" SortExpression="import_date" HeaderText="วันที่นำเข้า <br />(Last Updated)"  HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" >
                                        <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="" >
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" OnClick="lnkEdit_Click" runat="server" ImageUrl="~/Images/editor.gif" CommandArgument='<%# Bind("id")  %>' ToolTip="Edit" ></asp:ImageButton>
                                            <asp:ImageButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" ImageUrl="~/Images/icn_close.png" CommandArgument='<%# Bind("id")  %>' ToolTip="Delete"
                                             OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerSettings Visible="false" />
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                            <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
     </table>
</asp:Content>

