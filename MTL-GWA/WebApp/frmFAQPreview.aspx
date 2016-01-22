<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmFAQPreview.aspx.vb" Inherits="WebApp_frmFAQPreview" title="คำถามที่พบบ่อย" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/ctlTab.ascx" tagname="ctlTab" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="center">
    <table width="100%" border="0">
      <tr>
        <td  >
            <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                <tr id="trTab" runat="server" >
                    <td align="left" width="100%" >
                        <table border="0" cellpadding="0" cellspacing="0" >
                            <tr>
                                <td><uc4:ctlTab ID="btnTabPolicyService" runat="server"  TabText="บริการกรมธรรม์ (Policy Service)" ActiveTab="true" /></td>
                                <td><uc4:ctlTab ID="btnTabHealthClaimService" runat="server"  TabText="การประกันสุขภาพ (Health Insurance)" ActiveTab="false" /></td>
                                <td><uc4:ctlTab ID="btnTabLifeClaimService" runat="server"  TabText="การประกันชีวิต (Life Insurance)" ActiveTab="false" /></td>
                            </tr>
                        </table>                        
                    </td>
                </tr>
           </table>
           <table width="100%" border="0" cellpadding="0" cellspacing="0" class="SearchBody" id="tbMain" runat="server" >
                <tr >
                    <td  colspan="4" align="center"  width="100%" >
                        <asp:Label ID="lblFAQList" runat="server" ></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="left">&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:LinkButton ID="likMoreQuestion" runat="server">คำถามทั้งหมด (More Questions)...</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="pnlMoreQuestion" runat="server" Visible="false" >
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                <tr>
                                    <td colspan="4" align="center" >
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                            <tr>
                                                <td class="SearchBody" align="center">
                                                    <table width="60%" border="0" cellpadding="0" cellspacing="2" >
                                                      <tr>
                                                            <td width="24%">&nbsp;</td>
                                                            <td width="76%">&nbsp;</td>
                                                      </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblPolicyServiceType" runat="server" Text="หมวดหมู่คำถาม :<br />(Category) " ></asp:Label>&nbsp;</td>
                                                            <td align="left" >
                                                                <uc3:cmbComboBox ID="cmbPolicyServiceTypeID" runat="server" Width="300px" IsNotNull="false" DefaultDisplay="ทั้งหมด" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right"><asp:Label ID="lblQuestion" runat="server" Text="คำถาม :<br />(Question) " ></asp:Label>&nbsp;</td>
                                                            <td align="left"  >
                                                                <uc1:txtAutoComplete ID="txtQuestion" runat="server" Width="300px" />
                                                            </td>
                                                        </tr>
                                                        <tr><td colspan="2">&nbsp;</td></tr>
                                                        <tr>
                                                            <td colspan="2" align="center">
                                                                <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" />&nbsp;
                                                                <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" />
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
                                <tr>
                                    <td class="CssSubHeadPink" colspan="4" align="center" >
                                        <asp:Label ID="lblDisplayData" runat="server" Text="....แสดงข้อมูล....<br />Search Result" ></asp:Label>
                                    </td>
                                </tr>
                                <tr><td colspan="4">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="4">
                                        <uc2:PageControl ID="pcTop" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:GridView ID="gvQuestionList" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="true" AllowSorting="true" PageSize="20"  >
                                            <RowStyle CssClass="RowStyle" />
                                            <Columns>
                                                <asp:BoundField HeaderText="" DataField="id" >
                                                    <ControlStyle CssClass="zHidden" />
                                                    <FooterStyle CssClass="zHidden" />
                                                    <HeaderStyle CssClass="zHidden" />
                                                    <ItemStyle CssClass="zHidden" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="หมวดหมู่คำถาม <br />(Categories)" DataField="question_category" SortExpression="question_category" HtmlEncode="false" >
                                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="คำถาม <br />(Questions)" SortExpression="question"  >
                                                    <HeaderStyle HorizontalAlign="Center"  />
                                                    <ItemStyle HorizontalAlign="Left" Wrap="true"  />
                                                    <ItemTemplate >
                                                        <asp:LinkButton ID="lnkQuestion" OnClick="GetQuestionDetail"  runat="server" Text="<%# Bind('question') %>" CommandArgument="<%# Bind('id') %>" ></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="มีไฟล์แนบ <br />(Attached File)" DataField="is_file" SortExpression="is_file" HtmlEncode="false" >
                                                    <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="วันที่ตั้งคำถาม <br />(Post Date)" DataField="question_date" SortExpression="question_date" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}"  >
                                                    <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                    <ItemStyle HorizontalAlign="Center" Width="120px" />
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
                        </asp:Panel>
                    </td>
                </tr>
                <tr >
                    <td width="25%" >&nbsp;</td>
                    <td width="25%" >&nbsp;</td>
                    <td width="25%" >&nbsp;</td>
                    <td width="25%" >&nbsp;</td>
                </tr>
            </table>
        </td>
      </tr>
    </table>
</div>
</asp:Content>

