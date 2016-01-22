<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmDownloadImportFile.aspx.vb" Inherits="WebApp_frmDownloadAdminImportFile" title="นำเข้าเอกสาร" %>
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
                                <tr><td height="24" colspan="3">&nbsp;</td>
                              </tr>
                                <tr>
                                    <td height="32" align="right" ><asp:Label ID="lblFileCategory" runat="server" Text="หมวดหมู่ : "></asp:Label></td>
                                    <td colspan="2" align="left">
                                        <uc3:cmbComboBox ID="cmbFileCategory" runat="server" Width="200px" AutoPosBack="true" DefaultDisplay="ทั้งหมด" />
                                        <uc1:txtAutoComplete ID="txtID" runat="server"  IsNotNull="true" Text="0" Visible="false" />                                    </td>
                                </tr>
                                <tr>
                                    <td width="26%" height="30" align="right" >เลือกไฟล์ :&nbsp;</td>
                                    <td width="45%" align="left" >
                                        <uc4:ctlBrowseFile ID="ctlFileUpload" runat="server" VisibleUploadButton="false" Width="280px" />
                                    </td>
                                    <td width="29%" align="left" ><font color="red">*</font>
                                      <asp:Label ID="lblFileLimit" runat="server" Font-Italic="true" Text="Limit 5Mb"></asp:Label>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td align="left" ><font color="gray">(เฉพาะไฟล์ Word, Excel และ PDF เท่านั้น)</font></td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td height="28" align="right">รายละเอียด :&nbsp;</td>
<td colspan="2" align="left">
                                        <uc1:txtAutoComplete ID="txtFileDesc" runat="server" Width="400px" IsNotNull="true" />                                    </td>
                                </tr>
                                <tr>
                                    <td >&nbsp;</td>
                                    <td colspan="2" align="left">
                                        <br /><asp:RadioButtonList ID="rdiStdType" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2" AutoPostBack="true" >
                                            <asp:ListItem Text="เอกสารมาตรฐาน&nbsp;&nbsp;&nbsp;" Value="1" Selected ></asp:ListItem>
                                            <asp:ListItem Text="เอกสารเฉพาะบริษัท" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <uc1:txtAutoComplete ID="txtAccountCode" runat="server" Width="100px" Enabled="false" />                                    </td>
                                </tr>
                                <tr>
                                    <td height="35">&nbsp;</td>
                                  <td colspan="2" align="left"><asp:CheckBox ID="chkActive" runat="server" Text="แสดงในหน้าดาวน์โหลด" /></td>
                                </tr>
                                <tr><td colspan="3">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:ImageButton ID="btnSave" runat="server" ImageUrl="~/Images/ButtonSave.png" Height="30px" />                                        
                                        &nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                        
                                        &nbsp;
                                        <asp:ImageButton ID="btnUserViewer" runat="server" ImageUrl="~/Images/ButtonUserView.png" Height="30px" />                                                                            </td>
                                </tr>
                                <tr><td height="38" colspan="3">&nbsp;</td>
                              </tr>
                                <tr>
                                    <td colspan="3">                                    </td>
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
                            <asp:GridView ID="gvFileList" runat="server" AllowSorting="true" AllowPaging="true" 
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
                                    <asp:BoundField  DataField="file_category" HeaderText="หมวดหมู่" SortExpression="file_category" >
                                        <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="file_desc" HeaderText="รายละเอียด" SortExpression="file_desc" >
                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="active_name" HeaderText="แสดงในหน้าดาวน์โหลด" SortExpression="active_name" >
                                        <ItemStyle Width="100px" HorizontalAlign="Left"></ItemStyle>
                                        <HeaderStyle Width="100px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField  DataField="import_date" HeaderText="วันที่นำเข้า"  HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" SortExpression="import_date" >
                                        <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                                        <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField  ShowHeader="false" >
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lnkEdit" OnClick="lnkEdit_Click" runat="server" ImageUrl="~/Images/editor.gif" CommandArgument='<%# Bind("id")  %>' ToolTip="Edit" ></asp:ImageButton>
                                            <asp:ImageButton ID="lnkDelete" OnClick="lnkDelete_Click" runat="server" ImageUrl="~/Images/icn_close.png" CommandArgument='<%# Bind("id")  %>' ToolTip="Delete"
                                             OnClientClick="return confirm('Are you sure?');" ></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle Width="80px" />
                                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerSettings Visible="false" />
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

