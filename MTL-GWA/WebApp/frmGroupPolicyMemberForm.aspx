<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmGroupPolicyMemberForm.aspx.vb" Inherits="WebApp_frmGroupPolicyMemberForm" title="รายละเอียดผู้เอาประกัน(Member Info)" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
                <table width="100%" border="0" cellpadding="0" cellspacing="2" >
                    <tr>
                        <td class="SearchBody" align="center" >
                            <table width="950" border="0" cellpadding="0" cellspacing="2" >
                                <tr><td colspan="6">&nbsp;</td></tr>
                                <tr height='30px'>
                                    <td width="20%" align="right">
                                        <asp:Label ID="lblGroupCode" runat="server" Text="รหัสกลุ่มบริษัท :<br />(Group Code)" ></asp:Label> 
                                    </td>
                                    <td width="20%" align="left">
                                        <uc1:txtAutoComplete ID="txtGroupCode" runat="server" Width="200px" TextType="TextView" />
                                    </td>
                                    <td width="15%" align="right">
                                        <asp:Label ID="lblPolNo" runat="server" Text="เลขที่กรมธรรม์ :<br>(Policy No)" ></asp:Label>
                                    </td>
                                    <td width="15%" align="left">
                                        <uc1:txtAutoComplete ID="txtPolNo" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                    <td width="15%" align="right">
                                        <asp:Label ID="lblAccountCode" runat="server" Text="รหัสบริษัท :<br />(Account Code)"></asp:Label>
                                    </td>
                                    <td width="15%" align="left">
                                        <uc1:txtAutoComplete ID="txtAccountCode" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right">
                                        <asp:Label ID="lblAccountName" runat="server" Text="ชื่อบริษัท :<br />(Account Name)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="3">
                                        <uc1:txtAutoComplete ID="txtAccountName" runat="server" Width="470" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblPolYear" runat="server" Text="ปีกรมธรรม์ :<br />(Policy Year)"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtPolYear" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right">
                                        <asp:Label ID="lblMemberName" runat="server" Text="ชื่อ - สกุล ผู้เอาประกัน :<br />(Insured Name)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtMemberName" runat="server" Width="200px" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblMemberNo" runat="server" Text="รหัสผู้เอาประกัน :<br />(Member ID)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtMemberNo" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                    <td align="right"><asp:Label ID="lblEmployeeNo" runat="server" Text="รหัสพนักงาน :<br />(Employee ID)"></asp:Label> </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtEmployeeNo" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right">
                                        <asp:Label ID="lblBirthDate" runat="server" Text="วัน/เดือน/ปี เกิด :<br />(Birth Date)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="50%"><uc1:txtAutoComplete ID="txtBirthDate" runat="server" Width="70px" TextType="TextView" /></td>
                                                <td width="25%"><asp:Label ID="lblAge" runat="server" Text="อายุ :<br />(Age)" ></asp:Label></td>
                                                <td width="25%"><uc1:txtAutoComplete ID="txtAge" runat="server" Width="50px" TextType="TextView" /></td>
                                            </tr>
                                        </table>                                
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblRelation" runat="server" Text="ความสัมพันธ์ :<br />(Relationship)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtRelation" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblGender" runat="server" Text="เพศ :<br />(Sex)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtGender" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right">
                                        <asp:Label ID="lblEffectDate" runat="server" Text="วันที่มีผลบังคับ :<br />(Effect Date)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtEffectDate" runat="server" Width="200px" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblExpireDate" runat="server" Text="วันที่สิ้นผลบังคับ :<br />(Expiry Date)" ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtExpireDate" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblBankAccountNo" runat="server" Text="เลขที่บัญชีธนาคาร :<br />(Bank Account No)" ></asp:Label>
                                    </td>
                                    <td align="left">
                                        <uc1:txtAutoComplete ID="txtBankAccountNo" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right" valign="top">
                                        <asp:Label ID="lblMemberStatus" runat="server" Text="สถานะความคุ้มครอง :<br />(Member Insured Status)" ></asp:Label>
                                    </td>
                                    <td colspan="3" align="left" >
                                        <uc1:txtAutoComplete ID="txtMemberStatus" runat="server"  Width="470px" TextType="TextView" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblMeditation" runat="server" Text="การพิจารณารับประกัน :<br />(Underwriting Status) " ></asp:Label>
                                    </td>
                                    <td align="left" >
                                        <uc1:txtAutoComplete ID="txtMeditation" runat="server" Width="120px" TextType="TextView" />
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right" valign="top">
                                        <asp:Label ID="lblHealthCardNo" runat="server" Text="บัตรประกันสุขภาพ :<br />(Health Card)" ></asp:Label>
                                    </td>
                                    <td align="left" colspan="2" >
                                        <uc1:txtAutoComplete ID="txtHealthCard" runat="server" Height="40px" TextMode="MultiLine" Width="340px" TextType="TextView" />
                                    </td>
                                    <td align="left" colspan="3" >
                                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td align="right" style="width:80px" valign="top" >
                                                    <asp:Label ID="lblSection" runat="server" Text="แผนก :&nbsp;<br />(Section)&nbsp;" ></asp:Label>
                                                </td>
                                                <td align="left">
                                                    <uc1:txtAutoComplete ID="txtSection" runat="server" Height="40px" TextMode="MultiLine" Width="332px" TextType="TextView" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr height='30px'>
                                    <td align="right" valign="top">
                                        <asp:Label ID="lblHealthPlanRemarks" runat="server" Text="หมายเหตุ แผนประกันสุขภาพ :<br />(Health Plan Remark)" ></asp:Label>
                                    </td>
                                    <td colspan="4" align="left" >
                                        <uc1:txtAutoComplete ID="txtHealthPlanRemarks" runat="server" TextMode="MultiLine" Height="50px" Width="600px" TextType="TextView" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="btnBack" runat="server" CssClass="CssBtn" Width="120px" Text="กลับหน้าค้นหา" />
                                    </td>
                                </tr>
                                <tr><td colspan="6">&nbsp;</td></tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" >&nbsp;</td>
        </tr>
        <tbody id="tbNonHealth" runat="server">
            <tr>
                <td class="CssSubHeadPink" colspan="4" align="center" >
                    <asp:Label ID="lblBenefitDetail" runat="server" Text="" ></asp:Label>
                </td>
            </tr>
            <tr><td colspan="4">&nbsp;</td></tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="gvLife" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="true" AllowSorting="true" >
                        <RowStyle CssClass="RowStyle" />
                        <Columns>
                            <asp:BoundField HeaderText="ลำดับ<br />(No)" DataField="seq" HtmlEncode="false" >
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="แผน<br />(Plan)" DataField="plan" SortExpression="plan"  HtmlEncode="false"  >
                                <HeaderStyle Width="120px" HorizontalAlign="Center" />
                                <ItemStyle Width="120px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="ผลประโยชน์ความคุ้มครอง <br />(Benefit)" DataField="benefit" SortExpression="benefit"  HtmlEncode="false"  >
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="จำนวนเงินผลประโยชน์ (บาท)<br />(Amount)" DataField="money_amt" SortExpression="money_amt"  HtmlEncode="false"  >
                                <HeaderStyle  HorizontalAlign="Center" Width="350px"  />
                                <ItemStyle  HorizontalAlign="Right" Width="350px"  />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="หมายเหตุ<br />(Remarks)" DataField="remarks" SortExpression="remarks"  HtmlEncode="false"  >
                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="PagerStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerSettings Visible="false" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView> 
                    <asp:TextBox ID="txtSortFieldLife" runat="server" Visible="False" Width="15px"></asp:TextBox>
                    <asp:TextBox ID="txtSortDirLife" runat="server" Visible="False" Width="15px"></asp:TextBox>
                </td>
            </tr>
            <tr><td colspan="4">&nbsp;</td></tr>
        </tbody>
        <tr>
            <td class="CssSubHeadPink" colspan="4" align="center" >
                <asp:Label ID="lblHealthPlan" runat="server" Text="" ></asp:Label>
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
        <tr>
            <td colspan="4" align="left">
                <asp:TabContainer ID="TabContainer1" runat="server" Width="100%" >
                    <asp:TabPanel runat="server" ID="tabHealth1" >
                        <HeaderTemplate>
                            <asp:Label ID="lblHealth1" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="gvHealth1" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="false" AllowSorting="true" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:BoundField HeaderText="ลำดับ<br />(No)" DataField="seq" HtmlEncode="false"  >
                                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ผลประโยชน์ความคุ้มครอง<br />(Benefit)" DataField="benefit" SortExpression="benefit" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="จำนวนเงินผลประโยชน์ (บาท) <br />(Amount)" DataField="money_amt" SortExpression="money_amt" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="หมายเหตุ<br />(Remarks)" DataField="remarks" SortExpression="remarks" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerSettings Visible="false" />
                            </asp:GridView>   
                            <asp:TextBox ID="txtSortFieldH1" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtSortDirH1" runat="server" Visible="False" Width="15px"></asp:TextBox>   
                        </ContentTemplate>
                    </asp:TabPanel>
                    
                    
                    <asp:TabPanel runat="server" ID="tabHealth2" Visible="false" >
                        <HeaderTemplate>
                            <asp:Label ID="lblHealth2" runat="server"></asp:Label>
                        </HeaderTemplate>
                        <ContentTemplate>
                            <asp:GridView ID="gvHealth2" runat="server" AutoGenerateColumns="False" CssClass="GridViewStyle" Width="100%" AllowPaging="true" AllowSorting="true" >
                                <RowStyle CssClass="RowStyle" />
                                <Columns>
                                    <asp:BoundField HeaderText="ลำดับ<br />(No)" DataField="seq" HtmlEncode="false"  >
                                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="ผลประโยชน์ความคุ้มครอง <br />(Benefit)" DataField="benefit" SortExpression="benefit" HtmlEncode="false"  >
                                        <HeaderStyle Width="300px" HorizontalAlign="Center" />
                                        <ItemStyle Width="300px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="จำนวนเงินผลประโยชน์ (บาท) <br />(Amount)" DataField="money_amt" SortExpression="money_amt" HtmlEncode="false"  >
                                        <HeaderStyle Width="400px" HorizontalAlign="Center" />
                                        <ItemStyle Width="400px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="หมายเหตุ<br />(Remarks)" DataField="remarks" SortExpression="remarks" HtmlEncode="false"  >
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerStyle CssClass="PagerStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <PagerSettings Visible="false" />
                            </asp:GridView>      
                            <asp:TextBox ID="txtSortFieldH2" runat="server" Visible="False" Width="15px"></asp:TextBox>
                            <asp:TextBox ID="txtSortDirH2" runat="server" Visible="False" Width="15px"></asp:TextBox>   
                        </ContentTemplate>
                    </asp:TabPanel>
                </asp:TabContainer>                     
            </td>
        </tr>
        <tr><td colspan="4">&nbsp;</td></tr>
    </table>    
</asp:Content>

