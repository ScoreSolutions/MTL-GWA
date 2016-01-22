<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmHealthClaimPaidByRelationship.aspx.vb" Inherits="Reports_frmHealthClaimPaidByRelationship" title="รายงานการจ่ายค่าสินไหมตามความสัมพันธ์(Health Claim by Relationship)" %>
<%@ Register src="incCriteria.ascx" tagname="incCriteria" tagprefix="uc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <script language="javascript" type="text/javascript" >
        function PrintReport() {
            if (Valid() == true) {
                var ReportName = 'rptHltClmByPlanRelation';
                var vGroupCode = document.getElementById('<%=incCriteria1.GroupCode.ClientID %>').value;
                var vAccountCode = document.getElementById('<%=incCriteria1.AccountCode.ClientID %>').value;
                var vPolNo = document.getElementById('<%=incCriteria1.PolicyNo.ClientID %>').value;
                var vPolYear = document.getElementById('<%=incCriteria1.PolicyYear.ClientID %>').value;
                var curtime = new Date();

                var pStr = '../Reports/frmReportsPreview.aspx?ReportName=' + ReportName +
                        '&vGroupCode=' + vGroupCode +
                        '&vAccountCode=' + vAccountCode +
                        '&vPolNo=' + vPolNo +
                        '&vPolYear=' + vPolYear +
                        '&rnd=' + curtime.getMilliseconds();

                window.open(pStr, '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);
            }
        }

        function Valid() {
            var ret = true;
            var vGroupCode = document.getElementById('ctl00_ContentPlaceHolder1_incCriteria1_txtGroupCode_TextBox1');
            var vAccountCode = document.getElementById('ctl00_ContentPlaceHolder1_incCriteria1_txtAccountCode_TextBox1');
            var vPolNo = document.getElementById('ctl00_ContentPlaceHolder1_incCriteria1_txtPolicyNo_TextBox1');
            var vPolYear = document.getElementById('ctl00_ContentPlaceHolder1_incCriteria1_txtPolYear_TextBox1');

            if (vGroupCode.value == "") {
                alert("กรุณาระบุรหัสกลุ่มบริษัท (Please enter group code.)");
                vGroupCode.focus();
                ret = false;
            } else if (vAccountCode.value == "") {
                alert("กรุณาระบุรหัสบริษัท (Please enter account code.)");
                vAccountCode.focus();
                ret = false;
            } else if (vPolNo.value == "") {
                alert("กรุณาระบุเลขที่กรมธรรม์ (Please enter policy no.)");
                vPolNo.focus();
                ret = false;
            } else if (vPolYear.value == "") {
                alert("กรุณาระบุปีกรมธรรม์ (Please enter policy year.)");
                vPolYear.focus();
                ret = false;
            }
            return ret;
        }
    </script>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPrint" >
        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="SearchBody" >
            <tr>
                <td colspan="4" align="center" ><br /><br />
                    <uc1:incCriteria ID="incCriteria1" runat="server" />
                                    <tr><td colspan="4">&nbsp;</td></tr>
                                    <tr style="height:35px" >
                                        <td align="center" colspan="6">
                                            <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Images/ButtonReportPreview.png" OnClientClick="PrintReport(); return false;" Height="30px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                        </td>
                                    </tr>
                                    <tr style="height:35px" >
                                      <td align="center" colspan="4">&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>   
                </td>
            </tr>
        </table>
     </asp:Panel>
</asp:Content>

