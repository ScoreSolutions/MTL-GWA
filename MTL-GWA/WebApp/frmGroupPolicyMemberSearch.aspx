<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmGroupPolicyMemberSearch.aspx.vb" Inherits="WebApp_frmGroupPolicyMemberSearch" title="ค้นหาข้อมูลผู้เอาประกัน(Member Search)" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="../UserControls/PageControl.ascx" tagname="PageControl" tagprefix="uc2" %>
<%@ Register src="../UserControls/cmbComboBox.ascx" tagname="cmbComboBox" tagprefix="uc3" %>
<%@ Register src="../PageControl/ctlSectionCode.ascx" tagname="ctlSectionCode" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                    <tr>
                        <td class="SearchBody" align="center" >
                            <table width="100%" border="0" cellpadding="0" cellspacing="5" >
                                <tr>
                                    <td width="25%">&nbsp;</td>
                                    <td width="12%">&nbsp;</td>
                                    <td width="4%">&nbsp;</td>
                                    <td width="8%">&nbsp;</td>
                                    <td width="8%">&nbsp;</td>
                                    <td width="15%">&nbsp;</td>
                                    <td width="12%">&nbsp;</td>
                                    <td width="10%">&nbsp;</td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblGroupCode" runat="server" Text="รหัสกลุ่มบริษัท :<br />(Group Code)" ></asp:Label></td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtGroupCode" runat="server" Width="100px" TextType="TextView" />
                                    </td>
                                    <td align="right" colspan="2" ><asp:Label ID="lblPolNo" runat="server" Text="เลขที่กรมธรรม์ :<br />(Policy No)" ></asp:Label></td>
                                    <td align="left" colspan="2">
                                        <uc1:txtAutoComplete ID="txtPolNo" runat="server" Width="100px" TextType="TextView" />
                                    </td>
                                    <td align="right"><asp:Label ID="lblAcCode" runat="server" Text="รหัสบริษัท :<br />(Account Code)" ></asp:Label></td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtAcCode" runat="server" Width="100px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblAcName" runat="server" Text="ชื่อบริษัท :<br />(Account Name)" ></asp:Label></td>
                                    <td align="left" colspan="5" >
                                        <uc1:txtAutoComplete ID="txtAcName" runat="server" Width="480px" TextType="TextView" />
                                    </td>
                                    <td align="right"><asp:Label ID="lblPolYear" runat="server" Text="ปีกรมธรรม์ :<br />(Policy Year)" ></asp:Label></td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtPolYear" runat="server" Width="100px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblMemberNo" runat="server" Text="รหัสผู้เอาประกัน(ถ้ามี) :<br />(Insured Member ID)" ></asp:Label></td>
                                    <td align="left" >
                                        <asp:Label ID="lblMemberNo1" runat="server" Font-Size="9pt"  ></asp:Label><asp:TextBox ID="txtMemberNo_2" runat="server" Width="80px" MaxLength="7" CssClass="TextBox" ></asp:TextBox> -
                                        <asp:TextBox ID="txtMemberNo_3" runat="server" Width="20px" MaxLength="2"  CssClass="TextBox" Text="" ></asp:TextBox>
                                    </td>
                                    <td align="left" >หรือ<br />or</td>
                                    <td align="right" colspan="2"><asp:Label ID="lblEmployeeNo" runat="server" Text="รหัสพนักงาน(ถ้ามี) :<br />(Employee ID)" ></asp:Label></td>
                                    <td align="left" colspan="2" >
                                        <uc1:txtAutoComplete ID="txtEmployeeNo" runat="server" Width="150px" />
                                    </td>
                                    <td align="left" >หรือ<br />or</td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblHealthCardNo" runat="server" Text="เลขที่บัตรประกันสุขภาพ(ถ้ามี) :<br />(Healthcare Card No)" ></asp:Label></td>
                                    <td align="left" colspan="2" >
                                        <asp:Label ID="lblHealthCardNo1" runat="server" Font-Size="9pt"  ></asp:Label><asp:TextBox ID="txtHealthCardNo_2" runat="server" Width="80px" MaxLength="7" CssClass="TextBox" ></asp:TextBox> -
                                        <asp:TextBox ID="txtHealthCardNo_3" runat="server" Width="20px" MaxLength="2" CssClass="TextBox" Text="" ></asp:TextBox>
                                    </td>
                                    <td colspan="5" align="left" >หรือ<br />or</td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblMemberName" runat="server" Text="ชื่อผู้เอาประกัน (ตามบัตรประกันสุขภาพ) : <br />(Insured Name)" ></asp:Label></td>
                                    <td align="left" colspan="2" >
                                        <uc1:txtAutoComplete ID="txtMemberName" runat="server" Width="200px" />
                                    </td>
                                    <td align="right" colspan="2" ><asp:Label ID="lblMemberSurname" runat="server" Text="นามสกุล :<br />(Surname)" ></asp:Label></td>
                                    <td align="left" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtMemberSurname" runat="server" Width="200px" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right"><asp:Label ID="lblSection" runat="server" Text="แผนก : <br />(Section)" ></asp:Label></td>
                                    <td align="left" colspan="7">
                                        <uc4:ctlSectionCode ID="ctlSectionCode1" runat="server" Width="550px" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td colspan="8" align="center">
                                        <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/Images/ButtonSearch.png" />&nbsp;&nbsp;
                                        <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" />&nbsp;&nbsp;
                                        <asp:ImageButton ID="btnBack" runat="server" ImageUrl="~/Images/ButtonBackToPolicyInfo.png" />
                                    </td>
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
        <tr >
            <td colspan="4" class="CssSubHeadPink" align="center" ><asp:Label ID="lblDisplayData" runat="server" Text="....แสดงข้อมูล....<br />Search Result" Visible="false"></asp:Label> </td>
        </tr>
        <tr>
            <td colspan="4" align="left" >
                <uc2:PageControl ID="pcTop" runat="server" Visible="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="true" AllowSorting="true" PageSize="20" CssClass="GridViewStyle" Width="100%">
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:BoundField HeaderText="ลำดับ<br />(No)" DataField="no" HtmlEncode="false" >
                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="รหัสพนักงาน <br />(Employee ID)" SortExpression="employee_no" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkEmployeeNo" OnClick="GetMemberDetail" runat="server" Text="<%# Bind('employee_no') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="รหัสผู้เอาประกัน<br />(Member ID)" SortExpression="member_no" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkMemberNo" OnClick="GetMemberDetail" runat="server" Text="<%# Bind('member_no') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ชื่อ - สกุล ผู้เอาประกัน<br />(Insured Name)" SortExpression="member_name" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkMemberName" OnClick="GetMemberDetail" runat="server" Text="<%# Bind('member_name') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ความสัมพันธ์ <br />(Relationship)" SortExpression="relation" >
                            <HeaderStyle Width="100px" HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkRelation" OnClick="GetMemberDetail" runat="server" Text="<%# Bind('relation') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ<br />(Remarks)" SortExpression="remarks" >
                            <HeaderStyle Width="150px" HorizontalAlign="Center" />
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkRemarks" OnClick="GetMemberDetail" runat="server" Text="<%# Bind('remarks') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <PagerSettings Visible="false" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                <asp:TextBox ID="txtSortField" runat="server" Visible="False" Width="15px"></asp:TextBox>
                <asp:TextBox ID="txtSortDir" runat="server" Visible="False" Width="15px"></asp:TextBox>
            </td>
         </tr>
    </table>
    
    <script type="text/javascript">   
        $(function(){  
            $("input[name*='txtHealthCardNo_']").keyup(function(event){  
                if(event.keyCode==8){  
                    if($(this).val().length==0){  
                        $(this).prev("input").focus();    
                    }  
                    return false;  
                }             
                if($(this).val().length==$(this).attr("maxLength")){  
                    $(this).next("input").focus();  
                }
            });

            $("input[name*='txtMemberNo_']").keyup(function(event) {
                if (event.keyCode == 8) {
                    if ($(this).val().length == 0) {
                        $(this).prev("input").focus();
                    }
                    return false;
                }
                if ($(this).val().length == $(this).attr("maxLength")) {
                    $(this).next("input").focus();
                }
            });
        });
    </script>
</asp:Content>

