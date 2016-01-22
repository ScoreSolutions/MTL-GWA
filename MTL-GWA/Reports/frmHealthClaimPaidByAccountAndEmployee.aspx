<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmHealthClaimPaidByAccountAndEmployee.aspx.vb" Inherits="Reports_frmHealthClaimPaidByAccountAndEmployee" title="รายงานการจ่ายค่าสินไหมตามบริษัทและพนักงาน(Health Claim by Account and Employee)" %>
<%@ Register src="incCriteria.ascx" tagname="incCriteria" tagprefix="uc1" %>
<%@ Register src="~/UserControls/txtAutoComplete.ascx" tagname="txtAutoComplete" tagprefix="uc1" %>
<%@ Register src="~/UserControls/cmbCombobox.ascx" tagname="cmbCombobox" tagprefix="uc2" %>
<%@ Register src="../PageControl/ctlSectionCode.ascx" tagname="ctlSectionCode" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script language="javascript" type="text/javascript" >
        function PrintReport() {
            if (Valid() == true) {
                var ReportName = 'rptHltClmByAccEmp';
                var vGroupCode = document.getElementById('<%=incCriteria1.GroupCode.ClientID %>').value;
                var vAccountCode = document.getElementById('<%=incCriteria1.AccountCode.ClientID %>').value;
                var vPolNo = document.getElementById('<%=incCriteria1.PolicyNo.ClientID %>').value;
                var vPolYear = document.getElementById('<%=incCriteria1.PolicyYear.ClientID %>').value;
                var vSectionCode = document.getElementById('<%=txtSectionCode.ClientID %>').value;
                var vTopLevel = document.getElementById('<%=txtTopLevel.ClientID %>').value;
                var rdoA = document.getElementById("<%=rdiSortType.ClientID %>_0");
                var rdoT = document.getElementById("<%=rdiSortType.ClientID %>_1");

                var vSortType;
                if (rdoA.checked)
                    vSortType = "A";
                else if (rdoT.checked)
                    vSortType = "T";

                var curtime = new Date();

                var pStr = '../Reports/frmReportsPreview.aspx?ReportName=' + ReportName +
                        '&vGroupCode=' + vGroupCode +
                        '&vAccountCode=' + vAccountCode +
                        '&vPolNo=' + vPolNo +
                        '&vPolYear=' + vPolYear +
                        '&vSectionCode=' + vSectionCode +
                        '&vTopLevel=' + vTopLevel +
                        '&vSortType=' + vSortType +
                        '&rnd=' + curtime.getMilliseconds();
                //alert(pStr);
                window.open(pStr, '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);

                //window.open('http://localhost:49395/Default.aspx?ReportName=ILL2010&getTrackNo=TN0401015400009', '_blank', 'height=650,left=600,location=no,menubar=no,toolbar=no,status=yes,resizable=yes,scrollbars=yes', true);
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
                alert("กรุณาระบุรหัสบริษัท Please enter account code.");
                vAccountCode.focus();
                ret = false;
            } else if (vPolNo.value == "") {
                alert("กรุณาระบุเลขที่กรมธรรม์ Please enter policy no.");
                vPolNo.focus();
                ret = false;
            } else if (vPolYear.value == "") {
                alert("กรุณาระบุปีกรมธรรม์ Please enter policy year.");
                vPolYear.focus();
                ret = false;
            }
            return ret;
        }
    </script>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnPrint" >
        <table width="100%" border="0" cellpadding="2" cellspacing="0" class="SearchBody" >
            <tr>
                <td colspan="6" align="center" >
                    <uc1:incCriteria ID="incCriteria1" runat="server"  />
                                    <tr>
                                          <td align="right"><asp:Label ID="lblSectionCode" runat="server" Text="รหัสแผนก :<br />(Section Code)"  ></asp:Label></td>
                                          <td>&nbsp;</td>
                                          <td align="left"><uc3:ctlSectionCode ID="txtSectionCode" runat="server" Width="150px"  /></td>
                                          <td align="right"><asp:Label ID="lblTopLevel" runat="server" Text="Tops Claim :"  /></td>
                                          <td>&nbsp;</td>
                                          <td align="left"><uc1:txtAutoComplete ID="txtTopLevel" runat="server" Width="100px" MaxLength="3" TextKey="TextInt" />
                                            <i>(ไม่เกิน 999)</i>
                                          </td>
                                     </tr>
                                     <tr>
                                          <td align="right"><br /><asp:Label ID="lblSortType" runat="server" Text="ประเภทการจัดอันดับ :<br />(Sort Type)" ></asp:Label></td>
                                          <td>&nbsp;</td>
                                          <td align="left"><asp:RadioButtonList ID="rdiSortType" runat="server" RepeatDirection="Vertical" RepeatColumns="2" >
                                            <asp:ListItem selected Text="Amount" Value="A" ></asp:ListItem>
                                            <asp:ListItem  Text="Time" Value="T"></asp:ListItem>
                                            </asp:RadioButtonList>
                                          </td>
                                          <td>&nbsp;</td>
                                          <td>&nbsp;</td>
                                          <td>&nbsp;</td>
                                     </tr>         

                                    <tr><td colspan="6">&nbsp;</td></tr>
                                    <tr style="height:35px" >
                                        <td align="center" colspan="6">
                                            <asp:ImageButton ID="btnPrint" runat="server" ImageUrl="~/Images/ButtonReportPreview.png" OnClientClick="PrintReport(); return false;" Height="30px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="btnClear" runat="server" ImageUrl="~/Images/ButtonCancel.png" Height="30px" />                                        </td>
                                    </tr>
                                    <tr style="height:35px" >
                                      <td align="center" colspan="6">&nbsp;</td>
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

