<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmGroupPolicyForm.aspx.vb" Inherits="WebApp_frmGroupPolicyForm" title="ข้อมูลบริษัทผู้เอาประกัน(Policy Info)" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="~/PageControl/incLife.ascx" tagname="incLife" tagprefix="uc2" %>
<%@ Register src="~/PageControl/incHealth.ascx" tagname="incHealth" tagprefix="uc6" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table cellpadding="0" cellspacing="0" border="0" width="100%">
                    <tr>
                        <td class="SearchBody" align="center" >
                            <table width="950" border="0" cellpadding="0" cellspacing="0" >
                                <tr>
                                    <td style="width:21%" >&nbsp;</td>
                                    <td style="width:9%" >&nbsp;</td>
                                    <td style="width:13%" >&nbsp;</td>
                                    <td style="width:9%" >&nbsp;</td>
                                    <td style="width:20%" >&nbsp;</td>
                                    <td style="width:5%" >&nbsp;</td>
                                    <td style="width:15%" >&nbsp;</td>
                                    <td style="width:8%" >&nbsp;</td>
                                </tr>
                                <tr style="height:30px"  >
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblGroupCode" runat="server" Text="รหัสกลุ่มบริษัท :<br />(Group Code)" ></asp:Label>
                                    </td>
                                    <td align="left"  >
                                        <uc1:txtAutoComplete ID="txtGroupCode" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblPolicyNo" runat="server" Text="เลขที่กรมธรรม์ :<br />(Policy No)" ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtPolicyNo" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblAccountCode" runat="server" Text="รหัสบริษัท :<br />(Account Code)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtAccountCode" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr >
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblPolicyHolder" runat="server" Text="ชื่อผู้ถือกรมธรรม์ :<br />(Policyholder)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtPolicyNane" runat="server" Width="310px" TextMode="MultiLine" Height="40px" TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblAccountName" runat="server" Text="ชื่อบริษัท :<br />(Account Name)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtAccountName" runat="server" Width="310px" Height="40px" TextType="TextView" TextMode="MultiLine"  />
                                    </td>
                                </tr>
                                <tr >
                                    <td  align="right" class="Csslbl" >
                                        วันที่มีผลบังคับ :<br />(Effective Date)
                                    </td>
                                    <td  align="left">
                                        <uc1:txtAutoComplete ID="txtEffectiveDate" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                    <td  align="right" class="Csslbl" >
                                        วันที่สิ้นผลบังคับ :<br />(Expire Date)
                                    </td>
                                    <td  align="left">
                                        <uc1:txtAutoComplete ID="txtExpireDate" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                    <td  align="right" class="Csslbl" >
                                        ปีกรมธรรม์ :<br />(Policy Year)
                                    </td>
                                    <td  align="left">
                                        <uc1:txtAutoComplete ID="txtPolicyYear" runat="server" Width="30px" TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        งวดการชำระเบี้ยประกัน :<br />(Mode of Payment)
                                    </td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtModeOfPayment" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr style="height:50px">
                                    <td align="right"  valign="top" class="Csslbl"  >
                                        <asp:Label ID="lblAddress" runat="server" Text="ที่อยู่ :<br />(Address)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3"  >
                                        <uc1:txtAutoComplete ID="txtAddress" runat="server" TextMode="MultiLine" Height="40px" Width="310px" TextType="TextView" />
                                    </td>
                                    <td align="right" valign="top" class="Csslbl" >
                                        <asp:Label ID="lblAccountStatus" runat="server" Text="สถานะความคุ้มครอง :<br />(Account Status)" ></asp:Label>
                                    </td>
                                    <td align="left" valign="top" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtAccountStatus" runat="server" Width="310px" Height="40px" TextMode="MultiLine" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr style="height:50px">
                                    <td align="right" valign="top" class="Csslbl" >
                                        <asp:Label ID="lblHealthCard" runat="server" Text="บัตรประกันสุขภาพ :<br />(Health Card)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3" >
                                        <uc1:txtAutoComplete ID="txtHealthCard" runat="server"  Width="310px" Height="40px" TextMode="MultiLine"  TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblContactPerson" runat="server" Text="บุคคลที่ติดต่อ :<br />(Contact Person)" ></asp:Label>
                                    </td>
                                    <td colspan="3" align="left">
                                        <uc1:txtAutoComplete ID="txtContactPerson" runat="server" Width="310px" Height="40px" TextMode="MultiLine" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top" class="Csslbl" >
                                        <asp:Label ID="lblFreeCoverAmount" runat="server" Text="ทุนประกันที่ไม่ตรวจสุขภาพ :<br />(Free Cover Limit)" ></asp:Label>
                                    </td>
                                    <td align="left" valign="middle" colspan="3">
                                        <uc1:txtAutoComplete ID="txtFreeCoverAmount" runat="server" Width="80px" TextType="TextView" />
                                    </td>
                                    <td align="right" class="Csslbl" >
                                        <asp:Label ID="lblEmployeeAge" runat="server" Text="คุ้มครองพนักงานที่มีอายุตั้งแต่ :<br />(Employee aged between)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3" class="Csslbl">
                                        <uc1:txtAutoComplete ID="txtEmployeeAgeFrom" runat="server" Width="20px" TextType="TextView" />&nbsp;
                                        ถึง (To)&nbsp;&nbsp;
                                        <uc1:txtAutoComplete ID="txtEmployeeAgeTo" runat="server" Width="20px" TextType="TextView" />&nbsp;ปี (Year)
                                    </td>
                                </tr>
                                <tr><td colspan="8">&nbsp;</td></tr>
                                <tr>
                                    <td colspan="8" align="center">
                                        <asp:ImageButton ID="btnMemberDetail" runat="server" ImageUrl="~/Images/ButtonViewMember.png" />
                                    </td>
                                </tr>
                                <tr><td colspan="8">&nbsp;</td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr><td colspan="4" >&nbsp;</td></tr>
        <tr>
            <td colspan="4" class="CssSubHeadPink" align="center" >
                <asp:Label ID="lblEffectedDate" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" class="CssSubHeadPink" align="center" >
                <asp:Label ID="lblTypeOfInsurance" runat="server" Text="ประเภทการประกัน<br />(Type of Insurance)" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="4" >&nbsp;</td></tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowSorting="true" >
                    <RowStyle CssClass="RowStyle" />
                    <Columns>
                        <asp:TemplateField HeaderText="แผนความคุ้มครอง<br />(Benefit Plan)" SortExpression="benefit_plan" >
                            <HeaderStyle Width="120px" HorizontalAlign="Center" />
                            <ItemStyle Width="120px" HorizontalAlign="Center" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkProtectionPlan" OnClick="GetBenefitDetail" runat="server" Text="<%# Bind('benefit_plan') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ประเภทความคุ้มครอง <br />(Type of Coverage)" SortExpression="benefit_type" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkProtectionType" OnClick="GetBenefitDetail" runat="server" Text="<%# Bind('benefit_type') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="จำนวนเงินเอาประกัน <br />(Sum Insured)" SortExpression="money_amt" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle  HorizontalAlign="Right" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkMoneyAmt" OnClick="GetBenefitDetail" runat="server" Text="<%# Bind('money_amt') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="หมายเหตุ <br />(Remark)" SortExpression="remarks" >
                            <HeaderStyle HorizontalAlign="Center" Width="150px" />
                            <ItemStyle HorizontalAlign="Left" Width="150px" />
                            <ItemTemplate >
                                <asp:LinkButton ID="lnkRemarks" OnClick="GetBenefitDetail" runat="server" Text="<%# Bind('remarks') %>" CommandArgument="<%# Bind('CommandArgument') %>" ></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="benefit_table_code" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField >
                        <asp:BoundField DataField="benefit_table_start_date" >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField >
                        <asp:BoundField DataField="endorse_no"  >
                            <ItemStyle CssClass="zHidden" />
                            <ControlStyle CssClass="zHidden" />
                            <FooterStyle CssClass="zHidden" />
                            <HeaderStyle CssClass="zHidden" />
                        </asp:BoundField >
                    </Columns>
                    <PagerStyle CssClass="PagerStyle" />
                    <PagerSettings Visible="false" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
            </td>
        </tr>
    </table>        
    <uc2:incLife ID="incLife1" runat="server" />
    <uc6:incHealth ID="incHealth1" runat="server" />
</asp:Content>

