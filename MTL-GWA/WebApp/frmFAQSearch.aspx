<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFAQSearch.aspx.vb" Inherits="WebApp_frmFAQSearch" title="รายการคำถามที่พบบ่อย(FAQ Search)" EnableEventValidation="False" %>
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
                        <td class="SearchBody" align="center">
                            <table width="60%" border="0" cellpadding="0" cellspacing="2" >
                          <tr>
                                    <td width="28%" height="25">&nbsp;</td>
                            <td width="72%">&nbsp;</td>
                              </tr>
                                <tr>
                                    <td height="35" align="right"><asp:Label ID="lblPolicyServiceType" runat="server" Text="หมวดหมู่คำถาม : " ></asp:Label>&nbsp;</td>
                      <td align="left" >
                                        <uc3:cmbComboBox ID="cmbPolicyServiceTypeID" runat="server" Width="300px" IsNotNull="false" DefaultDisplay="ทั้งหมด" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="29" align="right"><asp:Label ID="lblQuestion" runat="server" Text="คำถาม : " ></asp:Label>&nbsp;</td>
                      <td align="left"  >
                                        <uc1:txtAutoComplete ID="txtQuestion" runat="server" Width="300px" />
                                    </td>
                                </tr>
                                
                                <tr><td colspan="2">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" Height="30px" />&nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />&nbsp;
                                        <asp:ImageButton ID="btnUserViewer" runat="server" ImageUrl="~/Images/ButtonUserView.png" Height="30px" />
                                    </td>
                                </tr>
                                <tr><td height="39" colspan="4">&nbsp;</td>
                              </tr>
                            </table>
                      </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tr>
            <td class="CssSubHeadPink" colspan="4" align="center" >
                <asp:Label ID="lblDisplayData" runat="server" Text="แสดงข้อมูล" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="left">
                <uc2:PageControl ID="pc1" runat="server"  />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="gvQuestionList" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="true" AllowSorting="true" PageSize="20"  >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField  DataField="id" HeaderText="id" >
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                            <ItemStyle CssClass="zHidden" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="ลำดับการแสดง" SortExpression="order_seq" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center"  />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkOrderSeq" runat="server" Text="<%# Bind('order_seq') %>" CommandName="lblOrderSeqClick" ></asp:LinkButton>
                                <uc1:txtAutoComplete ID="txtOrderSeq" runat="server" Width="30px" Text="<%# Bind('order_seq') %>"  Visible="false" />
                                <asp:Button ID="btnSaveOrderSeq" runat="server" Visible="false" Width="50px" Text="บันทึก" OnClick="btnSaveOrderSeq_Click" CssClass="CssBtn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="หมวดหมู่คำถาม" DataField="question_category" SortExpression="question_category" >
                            <HeaderStyle Width="150px" HorizontalAlign="Center" />
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="คำถาม" SortExpression="question" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkQuestion" OnClick="GetQuestionDetail" runat="server" Text="<%# Bind('question') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="มีไฟล์แนบ" DataField="is_file" SortExpression="is_file" >
                            <HeaderStyle HorizontalAlign="Center" Width="80px" />
                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="แสดงในหน้าจอผู้ใช้งาน" DataField="active_status" SortExpression="active_status" >
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField  DataField="question_date" SortExpression="question_date" HeaderText="วันที่ตั้งคำถาม"  HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" >
                            <ItemStyle Width="120px" HorizontalAlign="Center"></ItemStyle>
                            <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>
                        </asp:BoundField>
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
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
    </table>
</asp:Content>

