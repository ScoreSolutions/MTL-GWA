<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmHealthClaimPaidByBenefit.aspx.vb" Inherits="Reports_frmHealthClaimPaidByBenefit" title="Untitled Page" %>
<%@ Register src="incCriteria.ascx" tagname="incCriteria" tagprefix="uc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" >
        function PrintReport() {
            if (Valid() == true) {
                var ReportName = 'rptHltClmByBenefit';
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
            var vGroupCode = document.getElementById('<%=incCriteria1.GroupCode.ClientID %>');
            var vAccountCode = document.getElementById('<%=incCriteria1.AccountCode.ClientID %>');
            var vPolNo = document.getElementById('<%=incCriteria1.PolicyNo.ClientID %>');
            var vPolYear = document.getElementById('<%=incCriteria1.PolicyYear.ClientID %>');

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
        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="SearchBody" height="200" >
            <tr>
                <td colspan="6" valign="top">
                    <uc1:incCriteria ID="incCriteria1" runat="server" />
            <tr>
                <td colspan="6" align="center" height="20"></td>
            </tr>
            <tr>
                <td colspan="6" align="center">
                    <asp:ImageButton ID="btnPrint" runat="server" Height="30px"  ImageUrl="~/Images/ButtonReportPreview.png" onclientclick="PrintReport(); return false;" />            
&nbsp;&nbsp;
                    <asp:ImageButton ID="btnClear" runat="server" Height="30px" ImageUrl="~/Images/ButtonCancel.png" />
                </td>
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

